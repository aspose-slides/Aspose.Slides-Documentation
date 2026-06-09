---
title: Aspose.Slides para .NET 6 multiplataforma (pacote ZIP)
type: docs
weight: 237
url: /pt/net/slides-for-net-6-cross-platform-zip-package/
keywords:
- multiplataforma
- .NET 6
- GLIBC
- csproj
- caminho de destino
- biblioteca dependente
- Aspose.Slides.dll
- System.Drawing.Common
- conflito de nome
- alias externo
- CS0433
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Use o Aspose.Slides para .NET 6 para criar aplicativos C# multiplataforma no Windows, Linux e macOS que criam, editam e convertem arquivos PowerPoint PPT, PPTX e ODP."
---
## **Visão geral**

Este artigo explica como usar Aspose.Slides for .NET 6 Cross-Platform a partir de um pacote ZIP. Ele descreve como baixar o pacote, descompactar os arquivos da pasta `net6.0/crossplatform`, adicionar uma referência a `Aspose.Slides.dll` e configurar o arquivo do projeto para que as bibliotecas dependentes necessárias sejam copiadas para o diretório de saída da aplicação.

O artigo também descreve o conteúdo do pacote cross‑platform, incluindo o assembly principal do Aspose.Slides .NET e as bibliotecas do subsistema gráfico específicas da plataforma para Windows, Linux e macOS.

{{% alert title="Nota" color="primary" %}}
Aspose.Slides for .NET 6 Cross-Platform também está disponível no [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).
{{% /alert %}}

## **Usando o Aspose.Slides Cross-Platform a partir de um Pacote ZIP**

1. Baixe o pacote ZIP da versão mais recente do Aspose.Slides na [Página de Lançamento](https://releases.aspose.com/slides/pt/net/).

2. Descompacte os arquivos de *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* e coloque-os na pasta que será usada para dependências em seu projeto.

3. Adicione uma referência a Aspose.Slides.dll.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   Em nosso exemplo (abaixo), as bibliotecas estão localizadas na pasta do projeto neste caminho: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. Coloque os arquivos restantes (dos quais o Aspose.Slides depende) no diretório de saída adicionando instruções ao arquivo de projeto csproj da seguinte forma:

```xml
<ItemGroup>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x64.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x64.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x86.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x86.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\Aspose.Slides.xml">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>Aspose.Slides.xml</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_x86_64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_x86_64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_arm64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_arm64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```

5. Preste atenção ao `TargetPath`.

   Por padrão, `<CopyToOutputDirectory>` copia arquivos preservando seu caminho relativo, mas precisamos que as bibliotecas dependentes vão para a mesma pasta onde a saída é gerada (localização do Aspose.Slides.dll).

## **Observações**

### **Subsistema Gráfico Proprietário**

Aspose.Slides cross‑platform é uma coleção de bibliotecas:

| Aspose.Slides.dll                                          | Assembly .NET principal responsável por toda a lógica do Aspose.Slides |
| ---------------------------------------------------------- | ---------------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Dependência: implementação do subsistema gráfico para Win x64          |
| aspose.slides.drawing.capi_vc14x86.dll                     | Dependência: implementação do subsistema gráfico para Win x86          |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Dependência: implementação do subsistema gráfico para Linux (x86/x64) |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Dependência: implementação do subsistema gráfico para macOS AMD64 (x86-64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Dependência: implementação do subsistema gráfico para macOS ARM64 (AArch64) |

O Aspose.Slides.dll usa a biblioteca que o sistema em que está sendo executado requer. As bibliotecas geralmente estão localizadas no mesmo local que o Aspose.Slides.dll em qualquer sistema de arquivos.

### **Estrutura do Pacote ZIP**

O pacote ZIP contém a seguinte estrutura de pastas:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* Cada pasta contém assemblies para a respectiva versão .NET. Existem duas versões para net6.0: default e crossplatform. Esta última contém o Aspose.Slides.dll cross‑platform e todas as suas dependências. O conteúdo descompactado desta pasta pode ser usado como adição de dependência em um projeto para desenvolvimento cross‑platform e outras instâncias de uso do Aspose.Slides.

## **Veja Também**

- [Requisitos do Sistema](/slides/pt/net/system-requirements/)