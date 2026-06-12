---
title: PPT en PPTX naar JPG converteren in Java
linktitle: PowerPoint naar JPG
type: docs
weight: 60
url: /nl/java/convert-powerpoint-to-jpg/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar JPG
- presentatie naar JPG
- dia naar JPG
- PPT naar JPG
- PPTX naar JPG
- PowerPoint opslaan als JPG
- presentatie opslaan als JPG
- dia opslaan als JPG
- PPT opslaan als JPG
- PPTX opslaan als JPG
- PPT exporteren naar JPG
- PPTX exporteren naar JPG
- Java
- Aspose.Slides
description: "Converteer PowerPoint (PPT, PPTX) dia's naar hoogwaardige JPG-afbeeldingen in Java met Aspose.Slides voor Java, met snelle en betrouwbare code‑voorbeelden."
---
## **Introductie**

Het converteren van PowerPoint- en OpenDocument-presentaties naar JPG-afbeeldingen helpt bij het delen van dia’s, het optimaliseren van de prestaties en het insluiten van inhoud in websites of applicaties. Aspose.Slides stelt u in staat PPTX-, PPT- en ODP-bestanden te transformeren naar JPEG-afbeeldingen van hoge kwaliteit. Deze gids legt verschillende methoden voor conversie uit.

Met deze functies is het eenvoudig uw eigen presentatie‑viewer te implementeren en een miniatuur‑afbeelding voor elke dia te maken. Dit kan handig zijn als u dia’s wilt beschermen tegen kopiëren of de presentatie in alleen‑lezen‑modus wilt tonen. Aspose.Slides maakt het mogelijk om de volledige presentatie of een specifieke dia te converteren naar afbeeldingsformaten.

## **PowerPoint PPT/PPTX naar JPG converteren**

1. Maak een instantie van het type [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation).
2. Haal het dia‑object van het type [ISlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlide) op uit de collectie [Presentation.getSlides()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getSlides--) .
3. Maak een miniatuur‑afbeelding van elke dia en converteer deze vervolgens naar JPG. De methode [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlide#getImage-float-float-) wordt gebruikt om een miniatuur van een dia te verkrijgen; deze retourneert een [Images](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Images)-object als resultaat. De methode [getImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) moet worden aangeroepen op de gewenste dia van het type [ISlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlide); de schalen van de resulterende miniatuur worden aan de methode doorgegeven.
4. Nadat u de dia‑miniatuur heeft verkregen, roep de methode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) aan vanuit het miniatuurobject. Geef de gewenste bestandsnaam en het afbeeldingsformaat door.

{{% alert color="primary" %}}

**Opmerking**: De conversie van PPT/PPTX naar JPG verschilt van de conversie naar andere typen in de Aspose.Slides‑API. Voor andere typen gebruikt u doorgaans de methode [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), maar hier moet u de methode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) gebruiken.

{{% /alert %}} 

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Maakt een afbeelding op volledige schaal
        IImage slideImage = sld.getImage(1f, 1f);

        // Slaat de afbeelding op de schijf op in JPEG-formaat
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint PPT/PPTX naar JPG met aangepaste afmetingen**

Om de afmetingen van de resulterende miniatuur en JPG-afbeelding aan te passen, kunt u de *ScaleX*- en *ScaleY*-waarden instellen door ze door te geven aan de methoden [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlide#getImage-float-float-) :

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // Definieert afmetingen
    int desiredX = 1200;
    int desiredY = 800;
    // Haalt geschaalde waarden van X en Y op
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // Maakt een afbeelding op volledige schaal
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // Slaat de afbeelding op de schijf op in JPEG-formaat
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Reacties renderen bij het opslaan van dia's als afbeeldingen**

Aspose.Slides voor Java biedt een functionaliteit waarmee u opmerkingen in de dia's van een presentatie kunt renderen wanneer u die dia's naar afbeeldingen converteert. Deze Java‑code demonstreert de werking:

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}

Aspose biedt een [GRATIS Collage‑webapp](https://products.aspose.app/slides/nl/collage). Met deze online service kunt u [JPG naar JPG](https://products.aspose.app/slides/nl/collage/jpg) of PNG‑naar‑PNG‑afbeeldingen samenvoegen, [fotogrids](https://products.aspose.app/slides/nl/collage/photo-grid) maken, enzovoort. 

Met behulp van dezelfde principes die in dit artikel worden beschreven, kunt u afbeeldingen van het ene formaat naar het andere converteren. Voor meer informatie, zie deze pagina’s: converteer [afbeelding naar JPG](https://products.aspose.com/slides/nl/java/conversion/image-to-jpg/); converteer [JPG naar afbeelding](https://products.aspose.com/slides/nl/java/conversion/jpg-to-image/); converteer [JPG naar PNG](https://products.aspose.com/slides/nl/java/conversion/jpg-to-png/), converteer [PNG naar JPG](https://products.aspose.com/slides/nl/java/conversion/png-to-jpg/); converteer [PNG naar SVG](https://products.aspose.com/slides/nl/java/conversion/png-to-svg/), converteer [SVG naar PNG](https://products.aspose.com/slides/nl/java/conversion/svg-to-png/).

{{% /alert %}}

## **Veelgestelde vragen**

**Ondersteunt deze methode batch‑conversie?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere dia’s naar JPG in één enkele bewerking.

**Ondersteunt de conversie SmartArt, grafieken en andere complexe objecten?**

Ja, Aspose.Slides rendert alle inhoud, inclusief SmartArt, grafieken, tabellen, vormen en meer. De weergave‑nauwkeurigheid kan echter iets afwijken van PowerPoint, vooral bij het gebruik van aangepaste of ontbrekende lettertypen.

**Zijn er beperkingen voor het aantal dia’s dat verwerkt kan worden?**

Aspose.Slides zelf legt geen strikte limieten op het aantal dia’s dat u kunt verwerken. U kunt echter een out‑of‑memory‑fout tegenkomen bij het werken met grote presentaties of afbeeldingen met hoge resolutie.

## **Zie ook**

Bekijk andere opties om PPT/PPTX naar een afbeelding te converteren, zoals:

- [PPT/PPTX naar SVG conversie](/slides/nl/java/render-a-slide-as-an-svg-image/).