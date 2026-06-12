---
title: PPT en PPTX omzetten naar JPG in JavaScript
linktitle: PowerPoint naar JPG
type: docs
weight: 60
url: /nl/nodejs-java/convert-powerpoint-to-jpg/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint (PPT, PPTX) dia's omzetten naar hoogwaardige JPG-afbeeldingen in JavaScript met Aspose.Slides voor Node.js via Java met snelle, betrouwbare codevoorbeelden."
---
## **Inleiding**

Het converteren van PowerPoint- en OpenDocument‑presentaties naar JPG‑afbeeldingen helpt bij het delen van dia's, het optimaliseren van de prestaties en het insluiten van inhoud in websites of applicaties. Aspose.Slides stelt je in staat om PPTX‑, PPT‑ en ODP‑bestanden om te zetten naar JPEG‑afbeeldingen van hoge kwaliteit. Deze gids legt verschillende methoden voor conversie uit.

Met deze functies is het eenvoudig om je eigen presentatieweergave te implementeren en een miniatuur van elke dia te maken. Dit kan handig zijn als je de presentatiedia's wilt beschermen tegen kopiëren of de presentatie in alleen‑lezen modus wilt tonen. Aspose.Slides stelt je in staat om de hele presentatie of een specifieke dia om te zetten naar afbeeldingsformaten.

## **PowerPoint PPT/PPTX naar JPG converteren**
1. Maak een instantie van het type [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation).
2. Haal het dia‑object van het type [Slide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Slide) op uit de collectie [Presentation.getSlides()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) .
3. Maak de miniatuur van elke dia en zet deze vervolgens om naar JPG. De methode [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Slide#getImage-float-float-) wordt gebruikt om een miniatuur van een dia te verkrijgen; deze retourneert een [Imagess](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Images)‑object als resultaat. De methode [getImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) moet worden aangeroepen vanuit de gewenste dia van het type [Slide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Slide), waarbij de schalen van de resulterende miniatuur aan de methode worden doorgegeven.
4. Nadat je de miniatuur van de dia hebt verkregen, roep je de methode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/#save) aan vanuit het miniatuurobject. Geef de gewenste bestandsnaam en het afbeeldingformaat door.

{{% alert color="primary" %}}
**Opmerking**: De conversie van PPT/PPTX naar JPG verschilt van de conversie naar andere types in de Aspose.Slides‑API. Voor andere types gebruik je meestal de methode [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-), maar hier moet je de methode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/#save) gebruiken.
{{% /alert %}} 

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Creëert een afbeelding op volledige schaal
        var slideImage = sld.getImage(1.0, 1.0);
        // Slaat de afbeelding op schijf op in JPEG-formaat
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **PowerPoint PPT/PPTX naar JPG met aangepaste afmetingen**
Om de afmetingen van de resulterende miniatuur en JPG‑afbeelding te wijzigen, kun je de *ScaleX*- en *ScaleY*-waarden instellen door ze door te geven aan de [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Slide#getImage-float-float-)‑methoden:

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // Definieert afmetingen
    var desiredX = 1200;
    var desiredY = 800;
    // Verkrijgt geschaalde waarden van X en Y
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Creëert een afbeelding op volledige schaal
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // Slaat de afbeelding op schijf op in JPEG-formaat
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Opmerkingen renderen bij het opslaan van een presentatie als afbeelding**
Aspose.Slides voor Node.js via Java biedt een functionaliteit die je in staat stelt opmerkingen in de dia's van een presentatie te renderen wanneer je die dia's omzet naar afbeeldingen. Deze JavaScript‑code demonstreert de werking:

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}
Aspose biedt een [GRATIS Collage‑webapp](https://products.aspose.app/slides/nl/collage). Met deze online service kun je [JPG naar JPG](https://products.aspose.app/slides/nl/collage/jpg) of PNG naar PNG‑afbeeldingen samenvoegen, [foto‑rasters](https://products.aspose.app/slides/nl/collage/photo-grid) maken, enzovoort. 
{{% /alert %}}

## **Zie ook**

Bekijk andere opties om PPT/PPTX naar afbeelding te converteren, zoals:

- [PPT/PPTX naar SVG-conversie](/slides/nl/nodejs-java/render-a-slide-as-an-svg-image/).

## **FAQ**

**Ondersteunt deze methode batchconversie?**

Ja, Aspose.Slides ondersteunt batchconversie van meerdere dia's naar JPG in één enkele bewerking.

**Ondersteunt de conversie SmartArt, diagrammen en andere complexe objecten?**

Ja, Aspose.Slides rendert alle inhoud, inclusief SmartArt, diagrammen, tabellen, vormen en meer. De renderingsnauwkeurigheid kan echter enigszins afwijken van PowerPoint, vooral bij het gebruik van aangepaste of ontbrekende lettertypen.

**Zijn er beperkingen op het aantal dia's dat verwerkt kan worden?**

Aspose.Slides zelf legt geen strikte limieten op aan het aantal dia's dat je kunt verwerken. Je kunt echter een out‑of‑memory‑fout tegenkomen bij het werken met grote presentaties of afbeeldingen met hoge resolutie.