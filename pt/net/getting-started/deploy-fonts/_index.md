---
title: Implementar fontes para Aspose.Slides no Linux e em Docker
linktitle: Implementar fontes
type: docs
weight: 145
url: /pt/net/deploy-fonts/
keywords:
- implantar fontes
- instalar fontes
- fontes no Docker
- fontes no Linux
- fontes ausentes
- substituição de fontes
- fontes principais da Microsoft
- ttf-mscorefonts-installer
- fontes personalizadas
- fonte padrão
- servidor
- contêiner
- conversão PDF
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Implante fontes para Aspose.Slides para .NET em servidores Linux e em contêineres Docker: verifique quais fontes são substituídas, instale pacotes de fontes no Debian, Ubuntu e Alpine, adicione seus próprios arquivos de fonte e defina uma fonte padrão."
---
## **Visão geral**

Aspose.Slides desenha o texto com as fontes que estão disponíveis quando ele renderiza uma apresentação, por exemplo ao converter slides para PDF ou para imagens. Um desktop Windows geralmente tem as fontes que as apresentações utilizam. Servidores e contêineres Linux normalmente têm poucas fontes ou nenhuma, portanto o Aspose.Slides desenha o texto com uma fonte substituta. Uma substituta tem formas de letra e larguras diferentes, de modo que as linhas podem ser quebradas de forma distinta e o texto pode exceder sua forma, e caracteres que a substituta não possui não são desenhados corretamente. Se nenhuma fonte estiver instalada, a conversão é interrompida com erro.

Este artigo mostra como verificar quais fontes o Aspose.Slides substitui, como instalar fontes no Debian, Ubuntu e Alpine Linux, como adicionar seus próprios arquivos de fonte e como definir a fonte usada quando uma fonte está ausente. Os exemplos são executados em Docker nas imagens oficiais .NET, como em [Execute Aspose.Slides para .NET em Docker](/slides/pt/net/how-to-run-aspose-slides-in-docker/). Os comandos de pacote são instruções Dockerfile; em um servidor Linux, execute os mesmos comandos como root.

Para a própria API de fontes, como incorporação de fontes em uma apresentação e regras de fallback e substituição, consulte [Fontes do PowerPoint](/slides/pt/net/powerpoint-fonts/).

## **Verificar quais fontes são substituídas**

O aplicativo de console a seguir relata as fontes que o Aspose.Slides substitui no ambiente atual. Crie uma pasta chamada *FontCheck* e adicione os arquivos abaixo a ela.

*FontCheck.csproj* referencia [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/), o pacote para Debian e Ubuntu. Ele também copia os arquivos de uma pasta opcional *fonts* para a saída da aplicação; a seção [Carregar fontes da pasta da aplicação](#load-fonts-from-the-application-folder) a utiliza.

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
    <None Update="fonts/**" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

</Project>
```

*Program.cs* adiciona uma caixa de texto por nome de fonte a um slide e atribui a fonte através da propriedade [LatinFont](https://reference.aspose.com/slides/pt/net/aspose.slides/baseportionformat/latinfont/). Os nomes das fontes vêm da linha de comando; sem argumentos, a aplicação verifica Calibri, Arial e Times New Roman. Ela imprime as pastas nas quais o Aspose.Slides procura fontes ([FontsLoader.GetFontFolders](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsloader/getfontfolders/)), renderiza o slide para *output/fonts.pdf* e exibe as substituições relatadas por [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/pt/net/aspose.slides/ifontsmanager/getsubstitutions/). As duas etapas opcionais no início, carregar uma pasta *fonts* e ler a variável `DEFAULT_FONT`, são explicadas mais adiante neste artigo.

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// As fontes a verificar: os argumentos de linha de comando ou três fontes comuns do Office.
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// Load the font files from the fonts folder next to the application, if there is one.
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// Use the font named in the DEFAULT_FONT environment variable, if it is set, for text whose font is missing.
var loadOptions = new LoadOptions();
var defaultFont = Environment.GetEnvironmentVariable("DEFAULT_FONT");
if (!string.IsNullOrEmpty(defaultFont))
{
    loadOptions.DefaultRegularFont = defaultFont;
}

var fontFolders = FontsLoader.GetFontFolders().Distinct();
Console.WriteLine($"Font folders: {string.Join(", ", fontFolders)}");

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
for (var i = 0; i < fontNames.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
    shape.TextFrame.Text = $"This text is set in {fontNames[i]}.";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData(fontNames[i]);
}

Directory.CreateDirectory("output");
presentation.Save(Path.Combine("output", "fonts.pdf"), SaveFormat.Pdf);

var substitutions = presentation.FontsManager.GetSubstitutions().ToList();
if (substitutions.Count == 0)
{
    Console.WriteLine("No font substitutions.");
}
else
{
    Console.WriteLine("Font substitutions:");
    foreach (var substitution in substitutions)
    {
        Console.WriteLine($"  {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
    }
}
```

*.dockerignore* mantém os resultados de build locais fora do contexto de build:

```text
bin/
obj/
output/
```

*Dockerfile* compila a aplicação com a imagem SDK .NET e a executa na imagem runtime .NET. O estágio de runtime instala `libfontconfig1`, que o Aspose.Slides.NET6.CrossPlatform requer, e as fontes DejaVu. [Execute Aspose.Slides para .NET em Docker](/slides/pt/net/how-to-run-aspose-slides-in-docker/) explica cada instrução.

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY FontCheck.csproj .
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
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

Construa a imagem e execute a verificação:

```bash
docker build -t font-check .
docker run --rm font-check
```

A imagem contém apenas as fontes DejaVu, portanto as três fontes são substituídas por DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Para verificar as fontes das suas próprias apresentações, passe seus nomes como argumentos, por exemplo `docker run --rm font-check "Segoe UI" Consolas`. Para copiar *output/fonts.pdf* fora do contêiner, use os comandos em [Copie a saída para sua máquina](/slides/pt/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Instalar fontes no Debian e Ubuntu**

### **Microsoft Core Fonts**

O pacote `ttf-mscorefonts-installer` baixa e instala as fontes principais da Microsoft para a web, entre elas Arial, Times New Roman, Courier New, Verdana, Georgia e Trebuchet MS. As fontes são licenciadas sob o contrato de licença de usuário final (EULA) da Microsoft, e o pacote as instala somente após a aceitação da EULA. Uma build Docker não pode responder ao prompt, então o instalador recusa a EULA e não instala fontes, embora `apt-get install` ainda indique sucesso. Aceite a EULA com `debconf-set-selections` **antes** de instalar o pacote.

No *Dockerfile*, substitua a instrução `RUN` que instala os pacotes no estágio de runtime por:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Construa a imagem e execute a verificação novamente com os mesmos dois comandos. Arial e Times New Roman agora estão instalados:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, a fonte padrão de uma apresentação que o Aspose.Slides cria, não está entre as fontes principais, portanto ainda é substituída. Veja [Definir uma fonte padrão para fontes ausentes](#set-a-default-font-for-missing-fonts).

No Debian, o pacote está no componente de repositório `contrib`, que as imagens Debian não habilitam; as imagens padrão .NET 8 e .NET 9 são baseadas no Debian 12. Habilite `contrib` na mesma instrução:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

As imagens .NET 10 baseadas em Ubuntu já habilitam `multiverse`, o componente Ubuntu que contém o pacote.

### **Outros pacotes de fontes**

Debian e Ubuntu também empacotam fontes com licenças livres, por exemplo:

| Pacote | Fontes |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif e Mono, com as mesmas métricas de Arial, Times New Roman e Courier New |
| `fonts-crosextra-carlito` | Carlito, com as mesmas métricas de Calibri |
| `fonts-crosextra-caladea` | Caladea, com as mesmas métricas de Cambria |

Instale‑as com `apt-get install` na mesma instrução `RUN`. O Aspose.Slides.NET6.CrossPlatform não aplica os aliases de fontes da configuração de fontes Linux: com `fonts-liberation` instalado, o texto em Arial ainda é desenhado com a fonte substituta geral, não com Liberation Sans. Para usar uma fonte compatível em métricas no lugar de uma ausente, defina‑a como [fonte padrão](#set-a-default-font-for-missing-fonts) ou adicione uma [regra de substituição de fontes](/slides/pt/net/font-substitution/).

## **Adicionar seus próprios arquivos de fonte**

Fontes que as distribuições não empacotam, como as fontes da sua organização ou outras fontes licenciadas para uso no servidor, podem ser adicionadas como arquivos de fonte. Coloque os arquivos de fonte, por exemplo arquivos *.ttf*, em uma pasta chamada *fonts* dentro da pasta *FontCheck*. Os exemplos abaixo utilizam os arquivos de Carlito, uma fonte com as mesmas métricas de Calibri, que pode ser baixada em [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Instalar as fontes em uma pasta de fontes do sistema**

O Aspose.Slides lê as fontes nas pastas impressas na linha `Font folders`. Para instalar suas fontes para todas as aplicações na imagem, copie‑as para */usr/local/share/fonts*, a pasta de fontes instaladas localmente. Adicione esta instrução ao estágio de runtime do *Dockerfile*, após a instrução `RUN` que instala os pacotes:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **Carregar fontes da pasta da aplicação**

Em vez de instalar as fontes na imagem, você pode distribuí‑las com a aplicação e carregá‑las com [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsloader/loadexternalfonts/). As fontes ficam disponíveis apenas para o Aspose.Slides e são implantadas junto com a aplicação. *FontCheck* faz isso: *FontCheck.csproj* copia a pasta *fonts* para a saída da aplicação, e *Program.cs* passa essa pasta para `LoadExternalFonts` antes de criar a apresentação. [Fonte personalizada](/slides/pt/net/custom-font/) descreve outras formas de fornecer fontes, como carregá‑las da memória.

Reconstrua a imagem e, em seguida, verifique Calibri e Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

A pasta da aplicação agora aparece entre as pastas de fontes, e Carlito não é mais substituída:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **Definir uma fonte padrão para fontes ausentes**

Quando uma fonte está ausente, o Aspose.Slides usa uma substituta que ele escolhe automaticamente. Para escolher você mesmo, defina a propriedade [DefaultRegularFont](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/defaultregularfont/) de [LoadOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/) e passe as opções ao construtor de [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/). *FontCheck* lê o nome da fonte da variável de ambiente `DEFAULT_FONT`. Com Carlito carregada, use‑a para fontes ausentes:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri agora é desenhada com Carlito, cujos caracteres têm as mesmas larguras de Calibri, de modo que o texto mantém suas quebras de linha:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

A fonte padrão substitui toda fonte ausente. Para mapear fontes individuais, por exemplo Arial para Liberation Sans e Calibri para Carlito, use [regras de substituição de fontes](/slides/pt/net/font-substitution/). As regras alteram a saída renderizada, mas `GetSubstitutions` não as reflete, portanto verifique as fontes no arquivo de saída. Para textos asiáticos, também defina [DefaultAsianFont](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/defaultasianfont/); veja [Fonte padrão](/slides/pt/net/default-font/).

## **Instalar fontes no Alpine Linux**

No Alpine Linux, use o pacote Aspose.Slides.NET; [Execute no Alpine Linux](/slides/pt/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) lista as alterações necessárias no projeto. Faça as mesmas alterações em *FontCheck*: substitua a referência ao pacote, adicione a instrução `SetSwitch` ao *Program.cs* e use este estágio de runtime, que também instala as Microsoft Core Fonts:

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs libgdiplus font-dejavu msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

`update-ms-fonts` baixa e instala as mesmas Microsoft Core Fonts que o pacote Debian/Ubuntu, e sua EULA se aplica da mesma forma. `fc-cache` atualiza o cache de fontes.

Com Aspose.Slides.NET no Linux, a biblioteca de configuração de fontes (fontconfig) escolhe a substituta para uma fonte ausente, e `GetSubstitutions` não a relata, portanto *FontCheck* exibe `No font substitutions.` Para ver qual fonte é usada para um nome de fonte, consulte o fontconfig no contêiner:

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

Com as Microsoft Core Fonts instaladas, Arial é usada para Arial:

```text
Arial.ttf: "Arial" "Regular"
```

Sem elas, quando a instrução `RUN` instala apenas `icu-libs libgdiplus font-dejavu`, o mesmo comando exibe:

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **FAQ**

**Por que uma apresentação aparece diferente quando é convertida em um servidor?**

O servidor não possui as fontes usadas pela apresentação, de modo que o Aspose.Slides desenha o texto com uma fonte substituta cujas letras têm larguras diferentes. Execute *FontCheck* com os nomes de fonte da apresentação para ver quais fontes são substituídas, então instale essas fontes ou carregue‑as da pasta da aplicação.

**A build instalou ttf‑mscorefonts‑installer, mas Arial ainda é substituída. Por quê?**

A EULA não foi aceita antes da instalação do pacote, então o instalador pulou as fontes. Adicione o comando `debconf-set-selections` antes de `apt-get install`, conforme mostrado em [Microsoft Core Fonts](#microsoft-core-fonts), e reconstrua a imagem.

**O computador que abre o PDF precisa das fontes?**

Não. Nestes exemplos, o PDF contém as fontes usadas para desenhar o texto, de modo que ele aparece igual em qualquer computador. As fontes são necessárias apenas onde o Aspose.Slides renderiza a apresentação.