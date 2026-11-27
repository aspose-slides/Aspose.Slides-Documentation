---
title: Komprimera presentationer
description: Minska presentationsstorlek genom att komprimera bilder och ta bort oanvänt innehåll.
type: docs
url: /sv/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Översikt**

Komprimera bilder, ta bort beskurna bildområden när de inte längre behövs, och välj komprimeringsinställningar för presentationen innan du sparar. Detta är användbart för presentationer med stora fotografier eller återkommande media. Hur mycket som sparas beror på innehållet och de inställningar du väljer.

## **Exempel på användning**

Detta C#-exempel läser in `input.pptx`, komprimerar presentationen och sparar den som `compressed.pptx`.

Använd Aspose.Slides for .NET 26.11 eller senare. För installation, se [Installera Aspose.Slides for .NET](/slides/sv/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```


<!-- visual-explanation:compress-presentations:start -->
[![Identiskt skalade bildrenderingar före och efter komprimering, följt av uppmätta PPTX-filstorleksstaplar och lagrade bilddimensioner.](visual-compress-presentations-1adbf86268a5.svg)](visual-compress-presentations-1adbf86268a5.svg)

*Mätt på en syntetisk detaljgrid-fixtur: 584,030 → 128,323 byte. Båda renderingarna använder samma skala och 252 × 336‑punktsram. Komprimeringen tar bort de beskurna marginalerna och minskar den lagrade bilden till 525 × 700 pixlar; hur mycket som sparas beror på indata.*
<!-- visual-explanation:compress-presentations:end -->

## **Vanliga frågor**

### **Är detta en enda optimeringsknapp för hela filen?**

Aspose.Slides for .NET 26.11 lägger till [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), som kombinerar borttagning av oanvänd layout/master, delmängdsbildning av inbäddade teckensnitt och 150‑DPI bildkomprimering. Den tar permanent bort beskurna bildområden. För endast bildbehandling, använd [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); för finare kontroll, se [exempel för enskild bildkomprimering](/slides/sv/net/examples/optimization-batch/compression/). Sedan version 26.11 är samma anrop för hela presentationen också tillgängligt i Java, Node.js via Java, Python via .NET och C++. Exemplet och länkarna på den här sidan är för .NET.

### **Ändrar bildkomprimering redigerbar text eller diagram?**

Bildkomprimering riktar sig mot bilddata, inte redigerbar text eller diagramdata. Granska bilderna eftersom storleksändring eller omkomprimering kan minska deras detaljrikedom.

### **Hur bör jag välja upplösning för presentationsbilder?**

Välj ett mål baserat på den visade bildstorleken och avsedd skärm- eller utskriftsanvändning. Behåll högre upplösning för stora skärmar, utskrifter och detaljerade diagram, och jämför den renderade utdata innan du kastar originalet.

## **Guider**

- [Komprimera hela presentationen i .NET](/slides/sv/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Optimera bildhantering i presentationer i .NET](/slides/sv/net/image/)

Relaterad funktion: [Ta bort oanvända master, layouter och media](/slides/sv/features/remove-unused-content/).

## **Körbara .NET-exempel**

- [Minska presentationsstorlek](/slides/sv/net/examples/optimization-batch/compression/)