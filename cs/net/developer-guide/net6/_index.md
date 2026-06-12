---
title: .NET 6 podpora
type: docs
weight: 235
url: /cs/net/net6/
keywords:
- .NET 6 podpora
- Cloudové řešení
- AWS Lambda
- Azure Functions
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "Konfigurujte Aspose.Slides pro .NET 6 k vytváření, úpravě a konverzi prezentací PowerPoint PPT, PPTX a ODP v moderních multiplatformních C# aplikacích."
---
## **Úvod**

Od verze [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0) byla implementována podpora pro .NET6. Zvláštností této podpory je, že .NET6 již nepodporuje System.Drawing.Common pro Linux ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) a Slides implementuje tento grafický subsystém jako komponentu v C++.

Aspose.Slides pro .NET nyní funguje bez závislostí na GDI/libgdiplus na:
* Windows
* Linux

_Podpora MacOS_ probíhá.

## **Použití Slides pro .NET 6 na AWS a Azure**

.NET6 je preferovaná verze pro Aspose.Slides používanou v cloudu (AWS, Azure nebo jiná cloudová řešení).

V minulosti, když byl Aspose.Slides používán na Linuxovém hostiteli, bylo nutné nainstalovat další závislosti (libgdiplus), což bylo často nepohodlné nebo nepraktické (například při použití [AWS Lambda](https://aws.amazon.com/lambda)). S Slides pro .NET6 již tyto závislosti nejsou potřeba, takže nasazení je mnohem jednodušší.

Dalším faktorem jsou problémy, které nastaly, když byl Aspose.Slides používán v cloudovém řešení na Windows hostiteli. Například [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) mají omezení pro proces a způsobují problémy při exportu PDF (viz [tento](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). Použití Aspose.Slides pro .NET6 tento problém řeší.

## **Použití balíčku System.Drawing.Common a tříd Slides pro .NET 6 (CS0433: Typ existuje v obou Slides a System.Drawing.Common)**

Někdy je nutné v projektu použít jak závislosti System.Drawing, tak Slides pro .NET6 (například když projekt .NET6 závisí na dalších balíčcích, které zase závisí na System.Drawing). To může způsobit chyby, jako jsou tyto:

* CS0433: The type 'Image' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0
* CS0433: The type 'Graphics' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0

V tomto případě můžete použít [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) pro Aspose.Slides (verze starší než 24.8):
1) Vyberte sestavu Aspose.Slides ze závislostí projektu a poté klikněte na **Properties**.
  ![Vlastnosti balíčku Aspose Slides](package_properties.png)
2) Nastavte alias (například „Slides“).
  ![Alias Aspose Slides](set_alias.png)

Nyní budou typy ze System.Drawing.Common použity jako výchozí. Externí alias sestavy by měl být uveden tam, kde jsou potřeba typy Aspose.Slides.

```c#
extern alias Slides;
using Slides::Aspose.Slides;
```

Úplný příklad:

```c#
extern alias Slides;
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```

Od verze 24.8 byl odstraněn zastaralý veřejný API s závislostmi na System.Drawing. Ohledně výše uvedeného kódu můžete získat obrázek snímku následujícím způsobem.

```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```
Nové API je podrobněji popsáno v [Moderní API](/slides/cs/net/modern-api/).