---
title: Geavanceerde Tekstextractie uit Presentaties op Android
linktitle: Tekst Extractie
type: docs
weight: 90
url: /nl/androidjava/extract-text-from-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Extraheer snel tekst uit PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Android via Java. Volg onze eenvoudige, stapsgewijze gids om tijd te besparen."
---
## **Overzicht**

Tekst extraheren uit presentaties is een veelvoorkomende maar essentiële taak voor ontwikkelaars die met dia‑inhoud werken. Of je nu werkt met Microsoft PowerPoint‑bestanden in PPT‑ of PPTX‑formaat, of met OpenDocument‑presentaties (ODP), het benaderen en ophalen van tekstgegevens kan cruciaal zijn voor analyse, automatisering, indexering of het migreren van content.

Dit artikel biedt een uitgebreide gids over hoe je efficiënt tekst kunt extraheren uit verschillende presentatieformaten, waaronder PPT, PPTX en ODP, met Aspose.Slides for Android via Java. Je leert hoe je systematisch door presentatiestructuren kunt itereren om de benodigde tekstinhoud nauwkeurig op te halen.

## **Tekst extraheren van een dia**

Aspose.Slides for Android via Java biedt de [SlideUtil](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideutil/) klasse. Deze klasse biedt verschillende overladen statische methoden om alle tekst uit een presentatie of dia te extraheren. Om tekst uit een dia van een presentatie te extraheren, gebruik je de [getAllTextBoxes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) methode. Deze methode accepteert een object van het type [IBaseSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseslide/) als parameter. Bij uitvoering scant de methode de volledige dia op tekst en retourneert een array van objecten van het type [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/), waarbij alle tekstopmaak behouden blijft.

De volgende code‑fragment haalt alle tekst van de eerste dia van de presentatie op:

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

## **Tekst extraheren uit een presentatie**

Om tekst uit de volledige presentatie te scannen, gebruik je de [getAllTextFrames](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) statische methode die wordt blootgesteld door de [SlideUtil](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideutil/) klasse. Het accepteert twee parameters:

1. Eerst een [IPresentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/) object dat een PowerPoint‑ of OpenDocument‑presentatie vertegenwoordigt waaruit tekst wordt geëxtraheerd.
2. Vervolgens een `boolean`‑waarde die aangeeft of de masterslides moeten worden meegenomen bij het scannen van tekst uit de presentatie.

De methode retourneert een array van objecten van het type [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/), inclusief informatie over de tekstopmaak. De onderstaande code scant de tekst en opmaakdetails uit een presentatie, inclusief de masterslides.

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

## **Gecategoriseerde en snelle tekstextractie**

De [PresentationFactory](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationfactory/) klasse biedt ook methoden om alle tekst uit presentaties te extraheren:

```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

Het enum‑argument [TextExtractionArrangingMode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textextractionarrangingmode/) geeft de modus aan voor het organiseren van het resultaat van de tekstextractie en kan worden ingesteld op de volgende waarden:
- `Unarranged` - De ruwe tekst zonder rekening te houden met de positie op de dia.
- `Arranged` - De tekst is gerangschikt in dezelfde volgorde als op de dia.

De ongesorteerde modus kan worden gebruikt wanneer snelheid cruciaal is; hij is sneller dan de gesorteerde modus.

[IPresentationText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationtext/) vertegenwoordigt de ruwe tekst die uit de presentatie is geëxtraheerd. De `getSlidesText`‑methode retourneert een array van objecten van het type [ISlideText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidetext/). Elk object vertegenwoordigt de tekst op de betreffende dia. Het object van het type [ISlideText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidetext/) heeft de volgende methoden:

- `getText` - De tekst binnen de vormen van de dia.
- `getMasterText` - De tekst binnen de vormen van de masterslide die bij deze dia hoort.
- `getLayoutText` - De tekst binnen de vormen van de layout‑slide die bij deze dia hoort.
- `getNotesText` - De tekst binnen de vormen van de notities‑slide die bij deze dia hoort.
- `getCommentsText` - De tekst binnen de opmerkingen die bij deze dia horen.

```java
String presentationPath = "presentation.pptx";
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

**Hoe snel verwerkt Aspose.Slides grote presentaties tijdens tekstextractie?**

Aspose.Slides is geoptimaliseerd voor hoge prestaties en kan zelfs [large presentations](/slides/nl/androidjava/open-presentation/) verwerken, waardoor het geschikt is voor real‑time of bulk‑verwerkingsscenario's.

**Kan Aspose.Slides tekst extraheren uit tabellen en diagrammen binnen presentaties?**

Ja. Aspose.Slides kan tekst extraheren uit tal van dia‑elementen, waaronder tabellen en diagramgerelateerde objecten, zodat je de tekstinhoud in gangbare presentatiestructuren kunt benaderen en analyseren.

**Heb ik een speciale Aspose.Slides‑licentie nodig om tekst uit presentaties te extraheren?**

Je kunt tekst extraheren met de gratis proefversie van Aspose.Slides, hoewel deze [certain limitations](/slides/nl/androidjava/licensing/) heeft, zoals het verwerken van slechts een beperkt aantal dia's. Voor onbeperkt gebruik en om grotere presentaties aan te kunnen, wordt aangeraden een volledige licentie aan te schaffen.