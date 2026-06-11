---
title: Hantera upphöjd och nedsänkt text i presentationer i .NET
linktitle: Upphöjd och nedsänkt text
type: docs
weight: 80
url: /sv/net/superscript-and-subscript/
keywords:
- upphöjd
- nedsänkt
- lägg till upphöjd
- lägg till nedsänkt
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Behärska upphöjd och nedsänkt text i Aspose.Slides för .NET och förbättra dina presentationer med professionell textformatering för maximal effekt."
---
## **Översikt**

Aspose.Slides för .NET tillhandahåller funktioner för att integrera upphöjd och nedsänkt text i dina PowerPoint‑presentationer (PPT, PPTX) och OpenDocument (ODP). Oavsett om du behöver markera kemiska formler, matematiska ekvationer eller annotera innehåll med fotnoter, hjälper dessa specialiserade formateringsalternativ till att bevara tydlighet och precision. I den här artikeln lär du dig hur du enkelt använder upphöjd‑ och nedsänkt‑format och säkerställer professionella resultat i varje bild.

## **Lägg till upphöjd och nedsänkt text**

Du kan lägga till upphöjd och nedsänkt text i vilken paragraf som helst i en presentation. För att göra detta med Aspose.Slides måste du använda egenskapen `Escapement` i klassen [PortionFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/portionformat/).

Denna egenskap låter dig ange upphöjd eller nedsänkt text, med värden från -100 % (nedsänkt) till 100 % (upphöjd).

Implementeringssteg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild med dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) av typen `Rectangle` på bilden.
1. Få åtkomst till [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/) som är associerad med [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/).
1. Rensa befintliga paragrafer.
1. Skapa en ny [Paragraph](https://reference.aspose.com/slides/sv/net/aspose.slides/paragraph/) för upphöjd text och lägg till den i paragraf‑samlingen för [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/).
1. Skapa ett nytt text‑portion‑objekt.
1. Sätt egenskapen `Escapement` för text‑portionen till ett värde mellan 0 och 100 för att tillämpa upphöjd (0 betyder ingen upphöjd).
1. Ange någon text för [Portion](https://reference.aspose.com/slides/sv/net/aspose.slides/portion/) och lägg till den i paragrafens portion‑samling.
1. Skapa en ny [Paragraph](https://reference.aspose.com/slides/sv/net/aspose.slides/paragraph/) för nedsänkt text och lägg till den i paragraf‑samlingen.
1. Skapa ett nytt text‑portion‑objekt.
1. Sätt egenskapen `Escapement` för text‑portionen till ett värde mellan 0 och -100 för att tillämpa nedsänkt (0 betyder ingen nedsänkt).
1. Ange någon text för [Portion](https://reference.aspose.com/slides/sv/net/aspose.slides/portion/) och lägg till den i paragrafens portion‑samling.
1. Spara presentationen som en PPTX‑fil.

Följande C#‑kod implementerar dessa steg:

```c#
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Skapa en textruta.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // Skapa ett stycke för upphöjd text.
    IParagraph superPar = new Paragraph();

    // Skapa en textdel med vanlig text.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // Skapa en textdel med upphöjd text.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Skapa ett stycke för nedsänkt text.
    IParagraph paragraph2 = new Paragraph();

    // Skapa en textdel med vanlig text.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // Skapa en textdel med nedsänkt text.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // Lägg till styckena i textrutan.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Upphöjd och nedsänkt text](superscript_and_subscript.png)

## **FAQ**

**Kommer upphöjd och nedsänkt text att bevaras vid export till PDF eller andra format?**

Ja, Aspose.Slides för .NET behåller korrekt upphöjd och nedsänkt formatering när presentationer exporteras till PDF, PPT/PPTX, bilder och andra stödda format. Den specialiserade formateringen förblir intakt i alla utdatafiler.

**Kan upphöjd och nedsänkt text kombineras med andra formateringsstilar såsom fetstil eller kursiv?**

Ja, Aspose.Slides låter dig blanda olika textstilar inom en enda text‑portion. Du kan aktivera fetstil, kursiv, understrykning och samtidigt tillämpa upphöjd eller nedsänkt genom att konfigurera motsvarande egenskaper i [PortionFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/portionformat/).

**Fungerar upphöjd och nedsänkt formatering för text i tabeller, diagram eller SmartArt?**

Ja, Aspose.Slides för .NET stödjer formatering i de flesta objekt, inklusive tabeller och diagramelement. När du arbetar med SmartArt måste du komma åt de relevanta elementen (såsom [SmartArtNode](https://reference.aspose.com/slides/sv/net/aspose.slides.smartart/smartartnode/)) och deras textbehållare, och sedan konfigurera [PortionFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/portionformat/)-egenskaperna på liknande sätt.