---
title: Requisitos do Sistema
type: docs
weight: 60
url: /pt/net/system-requirements/
keywords:
- requisitos do sistema
- sistema operacional
- instalação
- dependências
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Descubra os requisitos do sistema do Aspose.Slides for .NET. Garanta suporte perfeito ao PowerPoint e OpenDocument no Windows, Linux e macOS."
---
## **Introdução**

Aspose.Slides for .NET não requer que o Microsoft PowerPoint esteja instalado porque o Aspose.Slides é um mecanismo independente de criação, conversão, layout de página e renderização de documentos Microsoft PowerPoint.

## **Sistemas Operacionais Compatíveis**

Aspose.Slides for .NET suporta qualquer sistema operacional de 32 bits ou 64 bits onde o .NET ou o framework Mono esteja instalado, incluindo (mas não limitado a):

### **Windows**

- Microsoft Windows 2000 Server ( x64, x86)
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)
- Microsoft Windows 11 ( x64, x86)
- Microsoft Azure

### **Linux**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine e outros)

### **Mac**

- Mac OS X

## **Frameworks Compatíveis**

Aspose.Slides for .NET suporta os frameworks .NET e Mono:

### **.NET Frameworks**

- .NET Framework 2.0
- .NET Framework 3.5
- .NET Framework 4.0
- .NET Framework 4.0_ClientProfile
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.5.2
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.7
- .NET Framework 4.7.2
- .NET 5
- .NET 6
- .NET 7
- .NET 8
- .NET 9
- .NET Core
- Suporte a COM Interop (COM, C++, VBScript)

### **Mono Framework**

- Suporte MONO em plataformas MAC e Linux

## **Ambientes de Desenvolvimento**

Aspose.Slides for .NET pode ser usado para desenvolver aplicações em qualquer ambiente de desenvolvimento que tenha como alvo a plataforma .NET, mas os seguintes ambientes são explicitamente suportados:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Compilações Principais do Aspose.Slides**

Atualmente, existem duas compilações principais do Aspose.Slides — Aspose.Slides.NET e Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Esta é a versão principal do produto. Ela usa o motor gráfico padrão do .NET.
- Em plataformas não‑Windows, pode ser necessário instalar a biblioteca `libgdiplus` e suas dependências.
- Antes da versão Aspose.Slides 25.3, para plataformas não‑Windows, era necessário usar o DLL .NET Standard 2.0 do pacote ZIP do Aspose.Slides.
- A partir da versão Aspose.Slides 25.3, o pacote NuGet pode ser usado diretamente mesmo em sistemas não‑Windows.
- Ao executar em sistemas não‑Windows, sua aplicação deve incluir a seguinte linha na inicialização:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **A partir da versão 25.3, você pode usar este pacote em plataformas que suportam .NET, como Linux aarch64 (ARM64).**

#### **Pacotes Adicionais para Linux Alpine**

Ao executar Aspose.Slides for .NET em um contêiner Alpine Linux, instalar apenas `libgdiplus` pode não ser suficiente. Contêineres Alpine normalmente não incluem fontes por padrão. Se nenhuma fonte estiver disponível, operações de renderização ou conversão podem falhar com um erro semelhante a:

```text
System.ArgumentException: Font '?' cannot be found
```
Para usar Aspose.Slides no Alpine, instale `libgdiplus` juntamente com pelo menos um pacote de fontes.

**Opção 1: Fontes DejaVu**

A opção recomendada é instalar o pacote `ttf-dejavu`:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

O pacote `ttf-dejavu` instala automaticamente as dependências relacionadas a fontes necessárias, como `fontconfig`, `encodings`, `mkfontscale` e `mkfontdir`. Nenhum pacote de fontes adicional é necessário para a maioria dos casos de uso.

**Opção 2: Microsoft Core Fonts**

Se suas apresentações utilizarem fontes específicas da Microsoft, como Arial, Times New Roman, Courier New ou Verdana, instale o Microsoft Core Fonts em vez disso:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Use esta opção somente quando as apresentações processadas exigirem fontes da Microsoft. Para a maioria dos cenários, instalar `ttf-dejavu` é mais simples e confiável.

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Esta é a versão do Aspose.Slides que usa um motor gráfico multiplataforma personalizado desenvolvido pela equipe do Aspose.Slides.  
Em plataformas não‑Windows, a biblioteca `fontconfig` pode ser necessária.

**Plataformas Compatíveis**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Plataformas Não Compatíveis**
- *Windows 11 ARM* (ARM64) — *Não está atualmente sob consideração*

{{%  alert  title="Notes"  color="primary"  %}}  
Para Linux x64, GLIBC 2.23+ é necessário; para Linux ARM64, GLIBC 2.39+ é necessário. Sistemas como CentOS 7 (GLIBC 2.14) não são suportados. Se precisar executar Aspose.Slides no CentOS 7 ou em outros sistemas incompatíveis (por exemplo, Alpine), use o pacote padrão: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **FAQ**

**Preciso ter o Microsoft PowerPoint instalado para conversões e renderização?**

Não, o PowerPoint não é obrigatório; o Aspose.Slides é um mecanismo autônomo para [criar](/slides/pt/net/create-presentation/), modificar, [converter](/slides/pt/net/convert-presentation/) e [renderizar](/slides/pt/net/convert-powerpoint-to-png/) apresentações.

**Quais fontes são necessárias para renderização correta?**

As fontes usadas na apresentação, ou substitutas adequadas, devem estar disponíveis no sistema operacional. No Linux e macOS, instale pacotes de fontes comuns para garantir renderização consistente.

Para contêineres Alpine Linux, instale pelo menos um pacote de fontes além de `libgdiplus`. A configuração mínima recomendada é `libgdiplus` com `ttf-dejavu`. Se forem necessárias fontes da Microsoft como Arial, Times New Roman, Courier New ou Verdana, use `msttcorefonts-installer` juntamente com `fontconfig`.

**Por que uma fonte personalizada é renderizada como substituta ou texto ausente no Linux?**

Se o arquivo de fonte contiver entradas da tabela de nomes inconsistentes ou corrompidas, a pilha de correspondência de fontes do Linux (FreeType/fontconfig) pode selecionar um registro inválido, fazendo com que a fonte não seja resolvida. Usar uma versão da fonte com registros de nome corrigidos ou instalar uma substituta consistente resolve o problema.