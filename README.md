# 💳 Gerenciador de Cartões (Demonstração)

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)
![.NET Version](https://img.shields.io/badge/.NET-10.0-purple.svg)
![SQL Server](https://img.shields.io/badge/SQL%20Server-Local-blue.svg)

Um sistema completo de gerenciamento de cartões de crédito e débito desenvolvido com **ASP.NET Core MVC** e **Entity Framework Core**. O projeto simula um ambiente seguro de cadastro de cartões, aplicando regras de negócio reais e boas práticas de arquitetura web, ideal para fins de estudo e portfólio.

---

## 🚀 Funcionalidades em Destaque (Diferenciais)

Para ir além de um CRUD convencional, este projeto implementa regras reais de negócios e segurança:

* **Identificação Automática de Bandeira:** O sistema analisa o primeiro dígito do cartão em tempo real para inferir a bandeira (Ex: `4` para Visa, `5` para Mastercard, `3` para American Express).
* **Mascaramento de Dados Sensíveis:** Em conformidade visual com boas práticas de segurança, o número completo do cartão e o CVV **nunca** são exibidos abertamente nas telas de listagem. Exibe-se apenas os 4 últimos dígitos (Ex: `**** **** **** 1234`).
* **Validação Matemática com Algoritmo de Luhn:** O campo de número de cartão utiliza a validação nativa `[CreditCard]` do .NET, exigindo que o número passe no cálculo de Luhn (Módulo 10) para ser aceito pelo servidor.
* **Segurança contra Ataques Web:** Implementação de proteção contra falsificação de requisições entre sites (CSRF) usando tokens de validação (`[ValidateAntiForgeryToken]`) em todos os formulários.
* **Validação em Duas Camadas:** Os dados são validados no navegador do usuário (Client-side via jQuery Validation) para melhor experiência, e revalidados no servidor (Server-side via `ModelState`) para garantir a integridade do banco.

---

## 📸 Demonstração do Sistema

> 💡 **Dica para o recrutador:** Como o sistema utiliza validação matemática estrita no campo do cartão, recomendo utilizar dados fictícios gerados por ferramentas de teste (como o gerador da *4Devs* ou similares) para testar os cadastros com sucesso.

### 1. Painel Principal (Listagem)
Exibe os cartões cadastrados em formato de "cards" visuais protegidos, identificando dinamicamente a bandeira de cada um.
![Listagem de Cartões](https://raw.githubusercontent.com/SEU_USUARIO/GerenciadorCartoes/main/prints/index.png)

### 2. Cadastro e Validação
Formulário com máscaras de entrada e validações impeditivas para dados corrompidos ou datas expiradas.
![Cadastro de Cartão](https://raw.githubusercontent.com/SEU_USUARIO/GerenciadorCartoes/main/prints/create.png)

### 3. Exclusão Segura
Tela de confirmação com dados mascarados antes de remover qualquer informação de forma definitiva do banco de dados.
![Exclusão de Cartão](https://raw.githubusercontent.com/SEU_USUARIO/GerenciadorCartoes/main/prints/delete.png)

---

## 🛠️ Tecnologias e Ferramentas Utilizadas

O projeto foi inteiramente desenvolvido em ambiente **Linux (Zorin OS)** utilizando o ecossistema moderno do .NET:

* **Backend & Framework Web:** C# com ASP.NET Core MVC (Net 8.0)
* **Persistência de Dados:** Entity Framework Core (EF Core)
* **Banco de Dados:** Microsoft SQL Server (Rodando em container Docker)
* **Frontend:** HTML5, CSS3, Bootstrap 5, Razor Views e JavaScript (jQuery)
* **IDE/Editor:** Visual Studio Code com extensões oficiais da Microsoft e extensão de SQL Server.

---

## 📐 Conceitos de Engenharia Aplicados

Demonstração prática de conhecimentos exigidos no mercado para desenvolvedores .NET:

* **Injeção de Dependência (DI):** O ciclo de vida do contexto do banco de dados (`DbContext`) é gerenciado nativamente pelo container de DI do ASP.NET Core no arquivo `Program.cs`.
* **Mapeamento Objeto-Relacional (ORM):** Uso do Entity Framework para traduzir entidades C# em tabelas SQL relacionais, eliminando a necessidade de queries SQL manuais acopladas ao código.
* **Programação Assíncrona (Async/Await):** Operações de I/O com o banco de dados (como `ToListAsync` e `SaveChangesAsync`) foram desenvolvidas de forma assíncrona para maximizar a escalabilidade e a performance da aplicação sob alta carga.
* **Migrations:** Histórico de evolução do banco de dados controlado por código, permitindo reprodutibilidade do ambiente em qualquer máquina.

---

## 🏃‍♂️ Como Executar o Projeto Localmente

### Pré-requisitos
* SDK do .NET (Versão 8.0 ou superior)
* Instância do SQL Server ativa (Local ou via Docker)

### Passo a Passo

1. Clone o repositório para sua máquina local:
   ```bash
   git clone [https://github.com/SEU_USUARIO/GerenciadorCartoes.git](https://github.com/SEU_USUARIO/GerenciadorCartoes.git)
   cd GerenciadorCartoes
