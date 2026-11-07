---
title: Komprimera presentationer
description: Minska presentationsstorlek genom att komprimera bilder och ta bort oanvänt innehåll.
type: docs
url: /sv/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operationer
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Översikt**

Komprimera bilder, ta bort beskurna bildområden när de inte längre behövs, och välj komprimeringsinställningar för presentationen innan du sparar. Detta är användbart för presentationer med stora fotografier eller upprepat media. Besparingen beror på innehållet och de inställningar du väljer.

## **Exempel på användning**

Detta C#‑exempel laddar `input.pptx`, komprimerar presentationen och sparar den som `compressed.pptx`.

Använd Aspose.Slides for .NET 26.11 eller senare. För installation, se [Installera Aspose.Slides for .NET](/slides/sv/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **Vanliga frågor**

### **Är detta en enskild optimeringsväxel för hela filen?**

Aspose.Slides for .NET 26.11 lägger till [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), som kombinerar borttagning av oanvänd layout/master, inbäddad teckensnittssubsetting och 150‑DPI bildkomprimering. Det tar permanent bort beskurna bildområden. För endast bildbearbetning, använd [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); för finare kontroll, se [exempel på enskild bildkomprimering](/slides/sv/net/examples/optimization-batch/compression/). Dessa nya hjälparfunktioner är specifika för den angivna .NET‑versionen; kontrollera motsvarande guide för andra SDK‑versioner.

### **Påverkar bildkomprimering redigerbar text eller diagram?**

Bildkomprimering riktar sig mot bilddata, inte redigerbar text eller diagramdata. Granska bilderna eftersom storleksändring eller omkomprimering kan minska deras detaljnivå.

### **Hur ska jag välja en upplösning för presentationsbilder?**

Välj ett mål baserat på den visade bildstorleken och avsedd skärm‑ eller utskriftsanvändning. Behåll högre upplösning för stora skärmar, utskrifter och detaljerade diagram, och jämför det renderade resultatet innan du kastar originalet.

## **Guider**

- [Komprimera hela presentationen i .NET](/slides/sv/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Optimera bildhantering i presentationer i .NET](/slides/sv/net/image/)

Relaterad funktion: [Ta bort oanvända master‑mallar, layouter och media](/slides/sv/features/remove-unused-content/).

## Exekverbara .NET‑exempel

- [Minska presentationsstorlek](/slides/sv/net/examples/optimization-batch/compression/)