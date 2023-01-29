# OpenAI.SmartChat.API

## English (En)

Simple reference API that implements [openai.com](https://openai.com) features to interact with ChatGPT. The API contains two main features:
- Completions: For textual interaction
- DALL: For image search. This feature returns:
     - Url: a url containing the web image link, or
     - Base64: a string of the image in base64 format

The project contains a WebAPI and a console application to test the API. You can use any other application (Mobile, Web or Desktop)

### 💻Technologies

- .NET Core 6
    - ASP.NET WebAPI
    - HttpClient

- Components | services
    - Culture config
    - FluentValidation
    - AutoMapper
    - Betalgo.OpenAI.GPT3
    - IdentityServer4.AccessTokenValidation
    - Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer
    - Swashbuckle
        - API version control with Swagger

- Execution | accommodation
    - IIS
    - SelfHosting

### 💡 Architecture and Architectural Styles

- Clean Code
- Domain notification
- Domain validations

### 🎮 Getting started

- Clone SmartChat repository to your local machine
- Open the project in Visual Studio
- Access the link: https://beta.openai.com/account/api-keys
     - Log in or create an account, then generate a token
     - Save the token in a safe place as it is only shown once
     - Add your token in properties/launchSettings.json file in API
- To run both (API and Console):
     - Navigate to Project Solution > right click > Properties
     - Choose "Multiple Startup Projects" option
     - In the "Action" option, change from "None" to "Start" and click Ok
     - Press F5 or the green button (Start)
- Or you can run each project separately

### 💎 Pull-Requests

Open an issue and let's discuss! Do not submit PRs for undiscussed or unapproved features.

If you want to help us, choose an approved issue and implement it.

---

## Portuguese (pt-BR)

API simples de referência que implementa os recursos da [openai.com](https://openai.com) para interagir com o ChatGPT. A API contém dois recursos principais:
- Completions: Para interação textual
- DALL: Para pesquisa de imagens. Este recurso retorna:
    - Url: uma url contendo o link da imagem da web, ou
    - Base64: uma cadeia de caracteres da imagem no formato base64

O projeto contém uma WebAPI e uma aplicação console para testar a API. Você pode utilizar qualquer outra aplicação (Mobile, Web ou Desktop)

### 💻Tecnologias

- .NET Core 6
    - ASP.NET WebAPI
    - HttpClient

- Componentes | Serviços
    - Config de cultura
    - FluentValidation
    - AutoMapper
    - Betalgo.OpenAI.GPT3
    - IdentityServer4.AccessTokenValidation
    - Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer
    - Swashbuckle
        - Controle de versão da API com Swagger

- Execução | Hospedagem
    - IIS
    - SelfHosting

### 💡 Arquitetura e Estilos Arquiteturais

- Código Limpo
- Notificação de domínio
- Validações de domínio

### 🎮 Começando

- Faça o clone do repositório SmartChat para sua máquina local
- Abra o projeto no Visual Studio
- Acesse o link: https://beta.openai.com/account/api-keys
    - Faça login ou crie uma conta, em seguida gere um token
    - Salve o token em um lugar seguro, pois só é mostrado uma vez
    - Adicione seu token no arquivo propriedades/launchSettings.json na API
- Para executar ambos (API e Console):
    - Navegue até a Solução do Projeto> botão direito do mouse > Propriedades
    - Escolha a opção "Vários projetos de inicialização"
    - Na opção "Ação", modifique de "Nenhum" para "Comecar" e clique Ok
    - Pressione F5 ou o botão verde (Comecar)
- Ou você pode executar separadamente cada projeto

### 💎 Pull-Requests

Abra uma issue e vamos discutir! Não envie PRs para recursos não discutidos ou não aprovados.

Se você quiser nos ajudar, escolha um problema aprovado e implemente-o.

---

## Espanhol (Es)

API de referencia simple que implementa funciones de [openai.com](https://openai.com) para interactuar con ChatGPT. La API contiene dos características principales:
- Complementos: Para interacción textual
- DALL: Para la búsqueda de imágenes. Esta característica devuelve:
     - Url: una url que contiene el enlace de la imagen web, o
     - Base64: una cadena de la imagen en formato base64

El proyecto contiene una WebAPI y una aplicación de consola para probar la API. Puedes usar cualquier otra aplicación (Móvil, Web o Escritorio)

### 💻Tecnologías

- .NET Núcleo 6
     - ASP.NET WebAPI
     - HttpCliente

- Componentes | servicios
    - Configuración de la cultura
    - FluentValidation
    - AutoMapeador
    - Betalgo.OpenAI.GPT3
    -IdentityServer4.AccessTokenValidation
    - Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer
    - espadachín
        - Control de versiones de API con Swagger

- Ejecución | alojamiento
     -IIS
     - Autohospedaje

### 💡 Arquitectura y Estilos Arquitectónicos

- Código limpio
- Notificación de dominio
- Validaciones de dominio

### 🎮 Empezando

- Clone el repositorio de SmartChat en su máquina local
- Abra el proyecto en Visual Studio
- Accede al enlace: https://beta.openai.com/account/api-keys
     - Inicie sesión o cree una cuenta, luego genere un token
     - Guarde el token en un lugar seguro ya que solo se muestra una vez
     - Agregue su token en el archivo properties/launchSettings.json en la API
- Para ejecutar ambos (API y Consola):
     - Vaya a Solución de proyecto > haga clic con el botón derecho > Propiedades
     - Elija la opción "Múltiples proyectos de inicio"
     - En la opción "Acción", cambie de "Ninguna" a "Iniciar" y haga clic en Aceptar
     - Presiona F5 o el botón verde (Iniciar)
- O puede ejecutar cada proyecto por separado

### 💎 Solicitudes de extracción

¡Abre un problema y hablemos! No envíe PR para características no discutidas o no aprobadas.

Si quieres ayudarnos, elige un problema aprobado e impleméntalo.
