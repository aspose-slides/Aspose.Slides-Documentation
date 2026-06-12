---
title: .NET 6-ondersteuning
type: docs
weight: 235
url: /nl/net/net6/
keywords:
- .NET 6-ondersteuning
- cloudoplossing
- AWS Lambda
- Azure Functions
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "Configureer Aspose.Slides voor .NET 6 om PowerPoint-presentaties (PPT, PPTX en ODP) te maken, bewerken en converteren in moderne, cross-platform C#-applicaties."
---
## **Introductie**

Vanaf [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0) is ondersteuning voor .NET6 geïmplementeerd. Het bijzondere aan deze ondersteuning is dat .NET6 System.Drawing.Common niet meer ondersteunt onder Linux ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) en Slides dit grafische subsysteem zelf implementeert als een C++‑component.

Aspose.Slides voor .NET werkt nu zonder afhankelijkheden van GDI/libgdiplus op:
* Windows
* Linux

_MacOS_-ondersteuning is in ontwikkeling.

## **Slides voor .NET 6 gebruiken op AWS en Azure**

.NET6 is de aanbevolen versie voor Aspose.Slides die in de cloud (AWS, Azure of andere cloud‑oplossingen) wordt gebruikt.

Voorheen, wanneer Aspose.Slides werd gebruikt op een Linux‑host, moesten extra afhankelijkheden (libgdiplus) geïnstalleerd worden, wat vaak onhandig of onpraktisch was (bijvoorbeeld bij gebruik van [AWS Lambda](https://aws.amazon.com/lambda)). Met Slides voor .NET6 zijn die afhankelijkheden niet meer nodig, waardoor implementatie veel eenvoudiger is.

Een andere overweging zijn de problemen die zich voordeden toen Aspose.Slides werd gebruikt in een cloud‑oplossing met een Windows‑host. Bijvoorbeeld, [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) hebben beperkingen voor het proces en veroorzaken problemen tijdens een PDF‑export (zie [deze](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). Het gebruik van Aspose.Slides voor .NET6 lost dit probleem op.

## **Gebruik van het System.Drawing.Common‑pakket en Slides voor .NET 6‑klassen (CS0433: De type bestaat in zowel Slides als System.Drawing.Common‑fout)**

Soms moeten zowel System.Drawing‑ als Slides voor .NET6‑afhankelijkheden in één project worden gebruikt (bijvoorbeeld wanneer het .NET6‑project afhankelijk is van andere pakketten die op hun beurt System.Drawing vereisen). Dit kan verwarrende fouten veroorzaken, zoals de volgende:

* CS0433: Het type 'Image' bestaat zowel in 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' als in 'System.Drawing.Common, Version=6.0.0.0
* CS0433: Het type 'Graphics' bestaat zowel in 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' als in 'System.Drawing.Common, Version=6.0.0.0

In dit geval kun je [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) gebruiken voor Aspose.Slides (versie lager dan 24.8):
1) Selecteer de Aspose.Slides‑assembly in de projectafhankelijkheden en klik vervolgens op **Properties**.
  ![Eigenschappen van Aspose Slides-pakket](package_properties.png)
2) Stel een alias in (bijvoorbeeld "Slides").
  ![Aspose Slides alias](set_alias.png)

Nu worden de types uit System.Drawing.Common standaard gebruikt. De alias voor de externe assembly moet worden gespecifieerd waar Aspose.Slides‑types nodig zijn.

```c#
extern alias Slides;
using Slides::Aspose.Slides;
```

Volledig voorbeeld:

```c#
extern alias Slides;
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```

Vanaf versie 24.8 is de verouderde publieke API met afhankelijkheden van System.Drawing verwijderd. Met betrekking tot het bovenstaande code‑voorbeeld kun je de slide‑afbeelding als volgt verkrijgen.

```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```
De nieuwe API wordt uitgebreider beschreven in [Modern API](/slides/nl/net/modern-api/).