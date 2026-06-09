---
title: .NET 6 Suporte
type: docs
weight: 235
url: /pt/net/net6/
keywords:
- .NET 6 suporte
- Solução em nuvem
- AWS Lambda
- Azure Functions
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "Configure o Aspose.Slides para .NET 6 para criar, editar e converter apresentações PowerPoint PPT, PPTX e ODP em aplicações C# modernas e multiplataforma."
---
## **Introdução**

A partir do [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0), o suporte para .NET6 foi implementado. A peculiaridade desse suporte é que o .NET6 não suporta mais System.Drawing.Common para Linux ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) e o Slides implementa esse subsistema gráfico por conta própria como um componente C++.

Aspose.Slides for .NET agora funciona sem dependências de GDI/libgdiplus em:
* Windows
* Linux

_MacOS_ suporte está em progresso.

## **Usando Slides para .NET 6 na AWS e Azure**

.NET6 é a versão preferida para o Aspose.Slides usado na nuvem (AWS, Azure ou outras soluções de nuvem).

Anteriormente, quando o Aspose.Slides era usado em um host Linux, dependências adicionais (libgdiplus) precisavam ser instaladas e isso muitas vezes era inconveniente ou impraticável (por exemplo, ao usar [AWS Lambda](https://aws.amazon.com/lambda)). Com o Slides para .NET6, essas dependências não são mais necessárias, portanto a implantação é muito mais fácil.

Outra consideração são os problemas que ocorriam quando o Aspose.Slides era usado em uma solução de nuvem com um host Windows. Por exemplo, [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) têm limitações para o processo e resultam em problemas durante uma operação de exportação PDF (veja [este](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). O uso do Aspose.Slides para .NET6 resolve esse problema.

## **Usando o Pacote System.Drawing.Common e Classes Slides para .NET 6 (CS0433: The Type Exists in Both Slides and System.Drawing.Common Error)**

Às vezes, tanto as dependências de System.Drawing quanto as de Slides para .NET6 precisam ser usadas em um projeto (por exemplo, quando o projeto .NET6 depende de outros pacotes, que por sua vez dependem de System.Drawing). Isso pode causar erros de complicação como estes:

* CS0433: The type 'Image' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0
* CS0433: The type 'Graphics' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0

Neste caso, você pode usar [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) para Aspose.Slides (versão menor que 24.8):
1) Selecione o assembly Aspose.Slides das dependências do projeto e então clique em **Properties**.
  ![Aspose Slides package properties](package_properties.png)
2) Defina um alias (por exemplo, "Slides").
  ![Aspose Slides alias](set_alias.png)

Agora, os tipos de System.Drawing.Common serão usados por padrão. O alias de assembly externo deve ser especificado onde os tipos Aspose.Slides são necessários.

```c#
extern alias Slides;
using Slides::Aspose.Slides;
```

Exemplo completo:

```c#
extern alias Slides;
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```

A partir da versão 24.8, a API pública depreciada com dependências em System.Drawing foi removida. Em relação ao exemplo de código acima, você pode obter a imagem do slide como abaixo.

```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```
A nova API é descrita em mais detalhes em [Modern API](/slides/pt/net/modern-api/).