---
title: Instalação
type: docs
weight: 70
url: /pt/nodejs-net/installation/
keywords:
- baixar Aspose.Slides
- instalar Aspose.Slides
- instalação do Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Instale Aspose.Slides para Node.js via .NET a partir do npm no Windows ou Linux: pré-requisitos, a substituição do edge-js, uma restauração única do NuGet e um primeiro programa que cria uma apresentação."
---
## **Visão geral**

Aspose.Slides for Node.js via .NET é o pacote npm `aspose.slides.via.net`. Ele executa a biblioteca Aspose.Slides .NET dentro do Node.js através da ponte [edge-js](https://github.com/agracio/edge-js), portanto uma instalação funcional precisa tanto do Node.js quanto do .NET.

Este artigo leva você de uma máquina limpa a um primeiro programa que cria uma apresentação. São quatro etapas: criar um projeto com uma substituição do edge-js, instalar o pacote via npm, restaurar as dependências .NET do pacote uma vez e executar seu script a partir da pasta do projeto.

## **Pré-requisitos**

- **Node.js 22 ou 24 LTS**, compilação x64, de [nodejs.org](https://nodejs.org/en/download).
- **.NET SDK 8 ou posterior**, de [dotnet.microsoft.com](https://dotnet.microsoft.com/download). O runtime .NET sozinho não é suficiente: a etapa de restauração abaixo precisa do SDK, e a ponte também quando seu script é executado. Execute `dotnet --list-sdks` para verificar quais SDKs estão instalados.
- **Somente no Linux**:
  - as ferramentas de compilação `python3`, `make` e `g++`, porque o npm compila o edge-js durante a instalação no Linux;
  - a biblioteca fontconfig, que a biblioteca de desenho nativo do Aspose.Slides carrega.

  No Debian, esses são os pacotes `python3`, `make`, `g++` e `libfontconfig1`.

As etapas deste artigo foram testadas nas seguintes plataformas:

| Plataforma | Resultado |
|---|---|
| Windows x64 com Node.js 22 ou 24 | Funciona. Testado com o Microsoft Visual C++ Redistributable instalado. |
| Linux x64 com Node.js 22 ou 24, onde o OpenSSL do sistema vem da mesma linha de lançamento do OpenSSL incluído no Node.js, como o Debian 13 | Funciona. |
| Linux onde as duas versões do OpenSSL diferem, como o Debian 12 | O Node.js falha com erro de segmentação ao criar uma apresentação. |
| macOS | Não verificado. |

No Linux, compare as duas versões antes de começar. O primeiro comando imprime a versão do OpenSSL incluída no Node.js; o segundo imprime a versão do sistema. Use um sistema onde ambas iniciem com os mesmos números maior e menor, por exemplo `3.5`:

```sh
node -p process.versions.openssl
openssl version
```

Se o comando `openssl` não for encontrado, instale primeiro o pacote `openssl`.

## **Criar um Projeto**

Crie uma pasta para seu projeto, inicialize‑a e adicione uma substituição que indica ao npm qual versão do edge-js instalar:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

O pacote solicita uma versão mais antiga do edge-js cujos binários precompilados para Windows param no Node.js 20, portanto, sem a substituição o primeiro script no Windows falha com “The edge module has not been pre-compiled for node.js version”. O comando grava a substituição na seção `overrides` do `package.json`; adicione‑a antes de instalar o pacote.

## **Instalar o Pacote**

Instale Aspose.Slides for Node.js via .NET a partir do npm:

```sh
npm install aspose.slides.via.net
```

Durante a instalação, o pacote copia suas bibliotecas de desenho nativo (os arquivos cujo nome contém `aspose.slides.drawing.capi`) para a pasta do projeto, ao lado do `package.json`.

O pacote também é publicado como um arquivo ZIP em [releases.aspose.com](https://releases.aspose.com/slides/pt/nodejs-net/). Este artigo cobre apenas a instalação via npm.

## **Restaurar as Dependências .NET**

O pacote contém os assemblies Aspose.Slides .NET, mas não os 20 pacotes NuGet dos quais esses assemblies dependem. Em tempo de execução, o .NET procura por eles no cache de pacotes NuGet: `%USERPROFILE%\.nuget\packages` no Windows, `~/.nuget/packages` no Linux, ou a pasta definida na variável de ambiente `NUGET_PACKAGES`. Se estiverem ausentes, o primeiro script falha com “assembly specified in the dependencies manifest was not found”.

Para preencher o cache, crie uma pasta chamada `deps` na pasta do projeto e salve o seguinte arquivo nela como `deps.csproj`. Cada item `PackageDownload` baixa um pacote na versão exata entre colchetes; nada é compilado.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageDownload Include="Humanizer.Core" Version="[2.14.1]" />
    <PackageDownload Include="Microsoft.Bcl.AsyncInterfaces" Version="[6.0.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Workspaces.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.DotNet.InternalAbstractions" Version="[1.0.0]" />
    <PackageDownload Include="Microsoft.Extensions.DependencyModel" Version="[7.0.0]" />
    <PackageDownload Include="Newtonsoft.Json" Version="[13.0.3]" />
    <PackageDownload Include="System.Composition.AttributedModel" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Convention" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Hosting" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Runtime" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.TypedParts" Version="[6.0.0]" />
    <PackageDownload Include="System.IO.Pipelines" Version="[6.0.3]" />
    <PackageDownload Include="System.Reflection.Metadata" Version="[6.0.1]" />
    <PackageDownload Include="System.Text.Encodings.Web" Version="[7.0.0]" />
    <PackageDownload Include="System.Text.Json" Version="[7.0.0]" />
  </ItemGroup>
</Project>
```

Em seguida, restaure a partir da pasta do projeto:

```sh
dotnet restore deps/deps.csproj
```

Você precisa desta etapa apenas uma vez por máquina, não uma vez por projeto: os pacotes permanecem no cache NuGet e projetos posteriores na mesma máquina os reutilizam. Após a restauração, você pode excluir a pasta `deps`.

## **Executar um Primeiro Programa**

Crie um arquivo chamado `hello.js` na pasta do projeto com o código a seguir. Ele cria uma apresentação, adiciona um retângulo com o texto “Hello, World!” ao primeiro slide e salva o resultado como `hello.pptx`:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Uma nova apresentação contém um slide vazio.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Posição e tamanho estão em pontos (1/72 polegada): x, y, largura, altura.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Libere o objeto .NET que sustenta a apresentação.
    presentation.dispose();
}
```

Execute‑o a partir da pasta do projeto:

```sh
node hello.js
```

O script imprime `Saved hello.pptx`. Abra `hello.pptx` para ver um slide com um retângulo preenchido contendo o texto. Sem licença, o Aspose.Slides também adiciona uma marca d'água de avaliação; veja [Avaliar Aspose.Slides](/slides/pt/nodejs-net/evaluate-aspose-slides/) e [Licenciamento](/slides/pt/nodejs-net/licensing/).

{{% alert color="info" title="Observação" %}}
Execute seus scripts a partir da pasta do projeto, aquela que contém `package.json`. Caminhos relativos como `hello.pptx` são resolvidos em relação à pasta atual, e em algumas máquinas um script iniciado a partir de outra pasta não consegue criar a apresentação.
{{% /alert %}}

A API JavaScript espelha o Aspose.Slides para .NET: as classes mantêm seus nomes .NET, propriedades e métodos usam camelCase (`Slides` torna‑se `slides`, `AddAutoShape` torna‑se `addAutoShape`), e itens de coleções são obtidos com `get(index)`. Não há referência de API separada para este pacote, portanto use a [referência de API Aspose.Slides para .NET](https://reference.aspose.com/slides/pt/net/) para detalhes de classes e membros, por exemplo [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) e [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/shapecollection/addautoshape/).

## **Perguntas Frequentes**

**O que significa “The edge module has not been pre-compiled for node.js version”?**

O npm instalou a versão mais antiga do edge-js que o pacote solicita. Adicione a substituição de [Criar um Projeto](#criar-um-projeto) e execute `npm install` novamente.

**O que significa “assembly specified in the dependencies manifest was not found”?**

As dependências .NET não estão no cache NuGet. A mesma execução também relata “edge.initializeClrFunc is not a function”. Siga [Restaurar as Dependências .NET](#restaurar-as-dependências-.net) uma vez, depois execute seu script novamente.

**O que significa “The edge native module is not available” no Linux?**

O edge-js não foi compilado durante `npm install`, por exemplo porque `python3`, `make` ou `g++` estavam ausentes. O npm não relata isso como erro. Instale as ferramentas de compilação e, em seguida, execute `npm rebuild edge-js` na pasta do projeto.

**Por que a criação de uma apresentação falha com um “Error” vazio?**

No Linux, verifique se a biblioteca fontconfig está instalada (`libfontconfig1` no Debian); sem ela a biblioteca de desenho nativo não pode ser carregada. Em qualquer sistema, verifique também se você está executando o script a partir da pasta do projeto.

**Por que o Node.js trava com falha de segmentação no Linux?**

O OpenSSL do sistema e o OpenSSL incluído no Node.js vêm de linhas de lançamento diferentes. Compare‑os conforme mostrado em [Pré-requisitos](#pré-requisitos) e use uma distribuição ou compilação do Node.js onde eles coincidam.

**Preciso repetir a restauração do NuGet para cada projeto?**

Não. A restauração preenche o cache NuGet para sua conta de usuário, e todo projeto naquela máquina usa o mesmo cache.