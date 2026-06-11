---
title: Avancerad textutvinning från presentationer i Java
linktitle: Extrahera text
type: docs
weight: 90
url: /sv/java/extract-text-from-presentation/
keywords:
- extrahera text
- extrahera text från bild
- extrahera text från presentation
- extrahera text från PowerPoint
- extrahera text från OpenDocument
- extrahera text från PPT
- extrahera text från PPTX
- extrahera text från ODP
- hämta text
- hämta text från bild
- hämta text från presentation
- hämta text från PowerPoint
- hämta text från OpenDocument
- hämta text från PPT
- hämta text från PPTX
- hämta text från ODP
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Snabbt extrahera text från PowerPoint- och OpenDocument-presentationer med Aspose.Slides for Java. Följ vår enkla steg-för-steg-guide för att spara tid."
---
## **Översikt**

Att extrahera text från presentationer är en vanlig men ändå viktig uppgift för utvecklare som arbetar med bildinnehåll. Oavsett om du hanterar Microsoft PowerPoint‑filer i PPT‑ eller PPTX‑format, eller OpenDocument‑presentationer (ODP), kan åtkomst och hämtning av textdata vara kritisk för analys, automatisering, indexering eller innehållsmigrering.

Denna artikel ger en omfattande guide om hur du effektivt extraherar text från olika presentationsformat, inklusive PPT, PPTX och ODP, med Aspose.Slides for Java. Du kommer att lära dig hur du systematiskt itererar genom presentationselement för att exakt hämta den text du behöver.

## **Extrahera text från en bild**

Aspose.Slides for Java tillhandahåller klassen [SlideUtil](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slideutil/). Klassen exponerar flera överlagrade statiska metoder för att extrahera all text från en presentation eller bild. För att extrahera text från en bild i en presentation, använd metoden [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-). Denna metod accepterar ett objekt av typen [IBaseSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibaseslide/) som parameter. När den körs skannar metoden hela bilden efter text och returnerar en array av objekt av typen [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/), med bibehållen textformatering.

Följande kodsnutt extraherar all text från presentationens första bild:

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

## **Extrahera text från en presentation**

För att skanna text från hela presentationen, använd den statiska metoden [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) som exponeras av klassen [SlideUtil](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slideutil/). Den accepterar två parametrar:

1. Först ett [IPresentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentation/)‑objekt som representerar en PowerPoint‑ eller OpenDocument‑presentation från vilken text ska extraheras.
1. För det andra ett `boolean`‑värde som anger om masterbilderna ska inkluderas när text skannas från presentationen.

Metoden returnerar en array av objekt av typen [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/), inklusive information om textformatering. Koden nedan skannar texten och formateringsdetaljerna från en presentation, inklusive masterbilderna.

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

## **Kategoriserad och snabb textutvinning**

Klassen [PresentationFactory](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentationfactory/) tillhandahåller också metoder för att extrahera all text från presentationer:

```java
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

Argumentet [TextExtractionArrangingMode](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textextractionarrangingmode/)‑enum anger läget för organisering av resultatet av textutvinning och kan sättas till följande värden:

- `Unarranged` – Råtext utan hänsyn till dess position på bilden.
- `Arranged` – Texten är ordnad i samma ordning som på bilden.

Det oordnade läget kan användas när hastighet är kritisk; det är snabbare än det ordnade läget.

[IPresentationText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentationtext/) representerar den råa text som extraherats från presentationen. Dess `getSlidesText`‑metod returnerar en array av objekt av typen [ISlideText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islidetext/). Varje objekt representerar texten på den motsvarande bilden. Objektet av typen [ISlideText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islidetext/) har följande metoder:

- `getText` – Texten inom bildens former.
- `getMasterText` – Texten inom masterbildens former som är kopplade till denna bild.
- `getLayoutText` – Texten inom layoutbildens former som är kopplade till denna bild.
- `getNotesText` – Texten inom notes‑bildens former som är kopplade till denna bild.
- `getCommentsText` – Texten inom kommentarer som är kopplade till denna bild.

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

**Hur snabbt behandlar Aspose.Slides stora presentationer vid texteextraktion?**

Aspose.Slides är optimerat för hög prestanda och kan bearbeta även [stora presentationer](/slides/sv/java/open-presentation/), vilket gör det lämpligt för realtids‑ eller massbearbetningsscenarier.

**Kan Aspose.Slides extrahera text från tabeller och diagram i presentationer?**

Ja. Aspose.Slides kan extrahera text från många bildelement, inklusive tabeller och diagramrelaterade objekt, så att du kan komma åt och analysera textinnehåll i vanliga presentationsstrukturer.

**Behöver jag en speciell Aspose.Slides‑licens för att extrahera text från presentationer?**

Du kan extrahera text med den kostnadsfria provversionen av Aspose.Slides, men den har [vissa begränsningar](/slides/sv/java/licensing/), såsom att endast bearbeta ett begränsat antal bilder. För obegränsad användning och för att hantera större presentationer rekommenderas att köpa en full licens.