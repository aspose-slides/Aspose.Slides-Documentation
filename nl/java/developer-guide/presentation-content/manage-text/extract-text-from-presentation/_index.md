---
title: Geavanceerde tekstextractie uit presentaties in Java
linktitle: Tekst extraheren
type: docs
weight: 90
url: /nl/java/extract-text-from-presentation/
keywords:
- tekst extraheren
- tekst extraheren uit dia
- tekst extraheren uit presentatie
- tekst extraheren uit PowerPoint
- tekst extraheren uit OpenDocument
- tekst extraheren uit PPT
- tekst extraheren uit PPTX
- tekst extraheren uit ODP
- tekst ophalen
- tekst ophalen uit dia
- tekst ophalen uit presentatie
- tekst ophalen uit PowerPoint
- tekst ophalen uit OpenDocument
- tekst ophalen uit PPT
- tekst ophalen uit PPTX
- tekst ophalen uit ODP
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Exporteer snel tekst uit PowerPoint- en OpenDocument‑presentaties met Aspose.Slides voor Java. Volg onze eenvoudige, stapsgewijze handleiding om tijd te besparen."
---
## **Overzicht**

Tekst extraheren uit presentaties is een veelvoorkomende maar essentiële taak voor ontwikkelaars die met dia‑inhoud werken. Of je nu werkt met Microsoft PowerPoint‑bestanden in PPT‑ of PPTX‑formaat, of met OpenDocument‑presentaties (ODP), toegang krijgen tot en ophalen van tekstdata kan cruciaal zijn voor analyse, automatisering, indexering of content‑migratie.

Dit artikel biedt een volledige gids over hoe je efficiënt tekst kunt extraheren uit verschillende presentatieformaten, waaronder PPT, PPTX en ODP, met behulp van Aspose.Slides for Java. Je leert hoe je systematisch door presentatie‑elementen kunt itereren om de gewenste tekstinhoud nauwkeurig op te halen.

## **Tekst extraheren uit een dia**

Aspose.Slides for Java biedt de [SlideUtil](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideutil/)‑klasse. Deze klasse bevat verschillende overladen statische methoden om alle tekst uit een presentatie of dia te extraheren. Om tekst uit een dia in een presentatie te extraheren, gebruik je de [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-)‑methode. Deze methode accepteert een object van het type [IBaseSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseslide/) als parameter. Bij uitvoering scant de methode de volledige dia op tekst en retourneert een array van objecten van het type [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/), waarbij eventuele tekstopmaak behouden blijft.

De volgende codefragment extraheren alle tekst uit de eerste dia van de presentatie:

```java
int slideIndex = 0;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(slideIndex);

    ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Tekst extraheren uit een hele presentatie**

Om tekst uit de volledige presentatie te scannen, gebruik je de [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-)‑statische methode van de [SlideUtil](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideutil/)‑klasse. Deze accepteert twee parameters:

1. Ten eerste een [IPresentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/)‑object dat een PowerPoint‑ of OpenDocument‑presentatie vertegenwoordigt waaruit tekst wordt gehaald.
2. Ten tweede een `boolean`‑waarde die aangeeft of de master‑dia’s moeten worden meegenomen bij het scannen van tekst uit de presentatie.

De methode retourneert een array van objecten van het type [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/), inclusief informatie over tekstopmaak. De onderstaande code scant de tekst‑ en opmaakdetails uit een presentatie, inclusief de master‑dia’s.

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    boolean includeMasterSlides = true;
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Gecategoriseerde en snelle tekst‑extractie**

De [PresentationFactory](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentationfactory/)‑klasse biedt eveneens methoden om alle tekst uit presentaties te extraheren:

```java
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

Het argument van het type [TextExtractionArrangingMode](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textextractionarrangingmode/) enum geeft de modus aan voor het ordenen van het resultaat van de tekste‑xtractie en kan worden ingesteld op de volgende waarden:

- `Unarranged` – De ruwe tekst zonder rekening te houden met de positie op de dia.
- `Arranged` – De tekst wordt geordend in dezelfde volgorde als op de dia.

De ongeordende modus kan worden gebruikt wanneer snelheid cruciaal is; hij is sneller dan de geordende modus.

[IPresentationText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationtext/) vertegenwoordigt de ruwe tekst die uit de presentatie is gehaald. Zijn `getSlidesText`‑methode retourneert een array van objecten van het type [ISlideText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidetext/). Elk object vertegenwoordigt de tekst op de bijbehorende dia. Het object van het type [ISlideText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidetext/) heeft de volgende methoden:

- `getText` – De tekst binnen de vormen van de dia.
- `getMasterText` – De tekst binnen de vormen van de master‑dia die bij deze dia hoort.
- `getLayoutText` – De tekst binnen de vormen van de layout‑dia die bij deze dia hoort.
- `getNotesText` – De tekst binnen de vormen van de notities‑dia die bij deze dia hoort.
- `getCommentsText` – De tekst binnen de opmerkingen die bij deze dia horen.

```java
String presentationPath = "presentation.ppt";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **FAQ**

**Hoe snel verwerkt Aspose.Slides grote presentaties tijdens tekst‑extractie?**

Aspose.Slides is geoptimaliseerd voor hoge prestaties en kan zelfs [grote presentaties](/slides/nl/java/open-presentation/) verwerken, waardoor het geschikt is voor realtime‑ of bulk‑verwerking scenario’s.

**Kan Aspose.Slides tekst uit tabellen en grafieken binnen presentaties extraheren?**

Ja. Aspose.Slides kan tekst uit vele dia‑elementen extraheren, waaronder tabellen en grafiekgerelateerde objecten, zodat je toegang krijgt tot en analyse kunt uitvoeren op tekstuele inhoud in gangbare presentatiestructuren.

**Heb ik een speciale Aspose.Slides‑licentie nodig om tekst uit presentaties te extraheren?**

Je kunt tekst extraheren met de gratis proefversie van Aspose.Slides, hoewel deze [bepaalde beperkingen](/slides/nl/java/licensing/) heeft, zoals het verwerken van slechts een beperkt aantal dia’s. Voor onbeperkt gebruik en om grotere presentaties aan te kunnen, wordt aangeraden een volledige licentie aan te schaffen.