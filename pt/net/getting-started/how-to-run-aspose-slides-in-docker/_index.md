---
title: Executar Aspose.Slides for .NET em Docker
linktitle: Docker
type: docs
weight: 140
url: /pt/net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Container Docker
- Construção multi-etapa
- Imagem de contêiner
- Linux
- Ubuntu
- Alpine
- libfontconfig
- libgdiplus
- fontes
- Conversão PDF
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Crie e execute um aplicativo de console Aspose.Slides for .NET no Docker: um Dockerfile multi-etapa nas imagens oficiais .NET, as bibliotecas e fontes Linux necessárias, e como copiar os arquivos gerados para sua máquina."
---
## **Visão geral**

Este artigo mostra como executar Aspose.Slides for .NET em um contêiner Docker. Você cria um pequeno aplicativo de console que cria uma apresentação com uma caixa de texto e a converte para PDF, empacota‑a com um Dockerfile de múltiplas etapas nas imagens oficiais .NET da Microsoft, executa‑a e copia os arquivos gerados para sua máquina. O artigo também lista as bibliotecas Linux e as fontes que o Aspose.Slides necessita no contêiner e termina com uma variante para Alpine Linux.

Você só precisa do Docker na sua máquina. O .NET SDK faz parte da imagem de compilação, portanto não é necessário instalá‑lo. Para instalar o Docker, veja [Obter Docker](https://docs.docker.com/get-started/get-docker/).

## **Escolha o pacote e a imagem base**

As imagens de contêiner .NET 10 padrão são baseadas no Ubuntu 24.04. Nessas imagens, use o pacote [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Ele requer a biblioteca `fontconfig`, e a imagem de runtime do .NET não contém nem essa biblioteca nem fontes, então o Dockerfile deste artigo instala ambos.

Aspose.Slides.NET6.CrossPlatform não funciona no Alpine Linux. Para imagens baseadas em Alpine, use o pacote [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) com `libgdiplus`, conforme descrito em [Executar no Alpine Linux](#run-on-alpine-linux). [Instalação](/slides/pt/net/installation/) compara os dois pacotes.

## **Crie o projeto**

Crie uma pasta chamada *HelloSlidesDocker* e adicione os três arquivos a seguir.

*HelloSlidesDocker.csproj* descreve um aplicativo de console para .NET 10, a versão das imagens de contêiner usadas abaixo, e referencia Aspose.Slides.NET6.CrossPlatform. Defina a versão do pacote para a mais recente listada no [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/).

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Aspose.Slides.NET6.CrossPlatform" Version="26.9.0" />
  </ItemGroup>

</Project>
```

*Program.cs* cria uma [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/), adiciona um retângulo com texto ao seu primeiro slide e salva a apresentação duas vezes com o método [Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/): como PPTX e como PDF. Ambos os arquivos vão para a pasta *output* sob o diretório de trabalho. O aplicativo então lista as fontes que foram substituídas enquanto o PDF era renderizado, usando [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/pt/net/aspose.slides/ifontsmanager/getsubstitutions/), para que você possa ver se o contêiner tem as fontes usadas na apresentação.

```c#
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var outputFolder = "output";
Directory.CreateDirectory(outputFolder);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello from a Docker container!";

var pptxPath = Path.Combine(outputFolder, "hello.pptx");
var pdfPath = Path.Combine(outputFolder, "hello.pdf");
presentation.Save(pptxPath, SaveFormat.Pptx);
presentation.Save(pdfPath, SaveFormat.Pdf);

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"Font substitution: {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

Console.WriteLine($"Saved {pptxPath} and {pdfPath}");
```

*.dockerignore* mantém as pastas *bin* e *obj* de uma compilação local, e a saída de execuções anteriores, fora do contexto de compilação do Docker, de modo que a imagem seja construída apenas a partir dos arquivos‑fonte.

```text
bin/
obj/
output/
```

## **Escreva o Dockerfile**

Adicione um arquivo chamado *Dockerfile* à mesma pasta:

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY HelloSlidesDocker.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:10.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
```

O arquivo tem duas etapas:

- **A etapa de compilação** começa a partir da imagem do .NET SDK. Ela copia o arquivo do projeto e restaura os pacotes NuGet primeiro, de modo que o Docker reutiliza essa camada enquanto o arquivo do projeto não mudar. Em seguida, copia o código‑fonte e publica o aplicativo para */app*.
- **A etapa de runtime** começa a partir da imagem menor de runtime do .NET, que não possui SDK, e copia apenas o aplicativo publicado. Ela instala dois pacotes:
  - `libfontconfig1`: Aspose.Slides.NET6.CrossPlatform carrega esta biblioteca ao iniciar. Sem ela, o aplicativo falha com uma `DllNotFoundException` que menciona `libfontconfig.so.1`.
  - `fonts-dejavu-core`: a imagem de runtime não contém fontes, e o Aspose.Slides precisa de ao menos uma fonte instalada para desenhar texto; sem nenhuma, a conversão interrompe com `InvalidOperationException: Cannot find any fonts installed on the system.` Texto em fontes não instaladas é desenhado com uma fonte substituta. As fontes DejaVu são um conjunto pequeno que permite a renderização do texto; para renderizar apresentações com as fontes para as quais foram projetadas, veja [Implantar fontes](/slides/pt/net/deploy-fonts/).

  `--no-install-recommends` e a remoção das listas de pacotes mantêm a imagem pequena. As últimas linhas criam a pasta *output*, atribuem‑a ao usuário não‑root `app` que as imagens oficiais .NET definem (seu ID de usuário está na variável `APP_UID`), e executam o aplicativo como esse usuário.

Para um aplicativo ASP.NET Core, inicie a etapa de runtime a partir de `mcr.microsoft.com/dotnet/aspnet:10.0` em vez disso. Ela também é baseada na mesma imagem Ubuntu, portanto os mesmos pacotes são necessários.

## **Compilar e executar o contêiner**

Abra um terminal na pasta *HelloSlidesDocker*. Compile a imagem e, em seguida, execute um contêiner a partir dela:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

A primeira compilação baixa as imagens base e os pacotes NuGet, por isso demora mais que compilações subsequentes. O contêiner executa o aplicativo e para. Ele imprime:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

A primeira linha mostra que o texto usa Calibri, a fonte padrão de uma nova apresentação, e que Calibri não está instalada na imagem, de modo que Aspose.Slides desenhou o texto com DejaVu Sans. O texto no PDF é real, selecionável nessa fonte. Sem uma licença, o Aspose.Slides também adiciona uma marca d'água de avaliação a cada slide salvo; veja [Licenciamento](/slides/pt/net/licensing/).

## **Copiar a saída para sua máquina**

Os arquivos estão na pasta */app/output* do contêiner interrompido. Copie‑os para uma pasta *output* na sua máquina e, em seguida, remova o contêiner:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Esses dois comandos funcionam da mesma forma no Bash, PowerShell e no Prompt de Comando do Windows.

No Linux, você pode montar uma pasta da sua máquina no contêiner, de modo que o aplicativo escreva os arquivos diretamente lá:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

A opção `--user` executa o aplicativo com seu ID de usuário e de grupo, permitindo que ele escreva na pasta que você criou e que os arquivos pertençam a você. `--rm` remove o contêiner quando ele para.

## **Executar no Alpine Linux**

Para executar o aplicativo em uma imagem baseada em Alpine, troque para o pacote Aspose.Slides.NET e altere a etapa de runtime. A etapa de compilação permanece a mesma.

1. Em *HelloSlidesDocker.csproj*, substitua a referência ao pacote:

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

2. Em *Program.cs*, adicione esta instrução após as diretivas `using`, antes da primeira chamada ao Aspose.Slides. Ela habilita o suporte ao System.Drawing para Linux que o Aspose.Slides.NET usa:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

3. Em *Dockerfile*, substitua a etapa de runtime (tudo a partir da segunda linha `FROM`) por:

   ```dockerfile
   FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
   ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
   RUN apk add --no-cache icu-libs libgdiplus font-dejavu
   WORKDIR /app
   COPY --from=build /app .
   RUN mkdir output && chown $APP_UID output
   USER $APP_UID
   ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
   ```

A etapa Alpine instala três pacotes e altera uma configuração:

- `libgdiplus` é a biblioteca gráfica que o Aspose.Slides.NET usa no Linux.
- `font-dejavu` fornece fontes. Sem nenhuma fonte, a conversão falha com `System.ArgumentException: Font '?' cannot be found`.
- `icu-libs` e `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` fornecem dados de cultura. As imagens .NET Alpine rodam em modo de globalização invariável por padrão, e nesse modo o Aspose.Slides falha com `CultureNotFoundException` para `en-US`.

Compile, execute e copie a saída com os mesmos comandos acima. Nesta imagem, o aplicativo imprime apenas a linha `Saved`: com Aspose.Slides.NET no Linux, o fontconfig escolhe a substituição para uma fonte ausente, e [GetSubstitutions](https://reference.aspose.com/slides/pt/net/aspose.slides/ifontsmanager/getsubstitutions/) não a lista. [Implantar fontes](/slides/pt/net/deploy-fonts/) mostra como verificar qual fonte foi usada.

## **FAQ**

**O aplicativo para com “Unable to load shared library 'libaspose.slides.drawing.capi…'”. O que está faltando?**

Em imagens Ubuntu e Debian, o pacote `libfontconfig1`; a mensagem lista `libfontconfig.so.1` como o arquivo que não pôde ser aberto. Em Alpine Linux, a mensagem indica que o Aspose.Slides.NET6.CrossPlatform está em uso; troque para Aspose.Slides.NET conforme descrito em [Executar no Alpine Linux](#run-on-alpine-linux).

**Por que o texto no PDF está em uma fonte diferente da do PowerPoint?**

As fontes usadas na apresentação não estão instaladas na imagem, de modo que o Aspose.Slides desenha o texto com uma fonte substituta. A saída do aplicativo nomeia cada fonte substituída. [Implantar fontes](/slides/pt/net/deploy-fonts/) explica como instalar fontes na imagem ou carregá‑las a partir da pasta do aplicativo.

**Preciso do .NET SDK na minha máquina?**

Não. A etapa de compilação cria o aplicativo dentro da imagem SDK. Você só precisa do SDK se quiser compilar e executar o aplicativo fora do Docker; veja [Instalação](/slides/pt/net/installation/).