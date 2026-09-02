---
title: Beheer PowerPoint-inkobjecten in JavaScript
linktitle: Beheer Inkt
type: docs
weight: 95
url: /nl/nodejs-java/manage-ink/
keywords:
- inkt
- inktobject
- inktspoor
- inkt beheren
- inkt tekenen
- tekening
- inkexport
- inkrendering
- inkt verbergen
- InkOptions
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer PowerPoint-inkobjecten, bewerk sporen en penseleigenschappen, en regel de weergave van inkt tijdens export naar PDF, HTML, SVG, TIFF en afbeeldingen met Aspose.Slides voor Node.js via Java."
---
## **Inleiding**

PowerPoint biedt een inkt‑functie waarmee u vrije hand‑streken kunt tekenen. Inkt kan worden gebruikt om andere objecten te markeren, verbindingen en processen weer te geven, en de aandacht te vestigen op specifieke items op een dia.

Aspose.Slides levert de typen die nodig zijn om met inktobjecten te werken. Bijvoorbeeld, de [Ink](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ink/) klasse vertegenwoordigt een inktobject op een dia.

## **Verschillen tussen reguliere objecten en inktobjecten**

Objecten op een PowerPoint‑dia worden meestal weergegeven door shape‑objecten. In de eenvoudigste vorm is een shape een container die het gebied van het object zelf (het frame) definieert, samen met eigenschappen zoals de container‑grootte, vorm en achtergrond. Voor meer informatie, zie [Shape Layout Format](https://docs.aspose.com/slides/nl/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

Echter, wanneer PowerPoint een inktobject verwerkt, negeert het alle eigenschappen van het objectframe (container) behalve de grootte. De grootte van het container‑gebied wordt bepaald door de standaard [Shape.getWidth](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getWidth--) en [Shape.getHeight](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getHeight--) methoden:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inktsporen**

Een inktspoor is een basiselement dat wordt gebruikt om de trajectorie van een pen vast te leggen terwijl een gebruiker digitale inkt schrijft. Een spoor slaat een reeks verbonden punten op.

De eenvoudigste vorm van codering geeft de X‑ en Y‑coördinaten van elk monsterpunt weer. Wanneer alle verbonden punten worden gerenderd, ontstaat er een afbeelding zoals deze:

![ink_powerpoint2](ink_powerpoint2.png)

## **Penseleigenschappen voor tekenen**

Een penseel wordt gebruikt om lijnen te tekenen die de punten van een inktspoor verbinden. Het penseel heeft zijn eigen kleur en grootte, weergegeven door de [InkBrush.getColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/inkbrush/#getColor--) en [InkBrush.getSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/inkbrush/#getSize--) methoden.

### **Stel inktpenseelkleur in**

Deze JavaScript‑code toont hoe u de kleur van een inktpenseel instelt:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **Stel inktpenseelgrootte in**

Deze JavaScript‑code toont hoe u de grootte van een inktpenseel instelt:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Over het algemeen komen de breedte en hoogte van een penseel niet overeen, waardoor PowerPoint de penseelgrootte niet weergeeft (de corresponderende gegevenssectie wordt grijs weergegeven). Wanneer de breedte en hoogte van het penseel wel overeenkomen, toont PowerPoint de grootte op deze manier:

![ink_powerpoint3](ink_powerpoint3.png)

Voor de duidelijkheid laten we de hoogte van het inktobject vergroten en bekijken we de belangrijke afmetingen:

![ink_powerpoint4](ink_powerpoint4.png)

De container (frame) houdt geen rekening met de grootte van de penselen — hij gaat altijd uit van een lijndikte van nul (zie de vorige afbeelding).

Daarom moet bij het bepalen van het zichtbare gebied van het volledige inktobject rekening worden gehouden met de penseelgrootte van de sporen. Hier is het doelobject (het handgeschreven tekstspoor) geschaald naar de grootte van de container (frame). Wanneer de grootte van de container verandert, blijft de penseelgrootte constant, en omgekeerd.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint gebruikt vergelijkbaar gedrag voor tekstelementen:

![ink_powerpoint6](ink_powerpoint6.png)

## **Inktweergave regelen tijdens export en rendering**

Aspose.Slides levert de [InkOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/inkoptions/) klasse om te bepalen hoe inktobjecten verschijnen in geëxporteerde of gerenderde uitvoer. U kunt de eigenschappen gebruiken om inkt volledig te verbergen of de manier waarop maskeringsbewerkingen van een inktpenseel worden geïnterpreteerd wijzigen.

Inktopties zijn beschikbaar via de export‑ of renderingsopties voor verschillende uitvoertypen:

| Uitvoer | Ink‑opties eigenschap |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

De volgende [InkOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/inkoptions/) methoden bieden dezelfde twee instellingen:

- [InkOptions.getHideInk] bepaalt of inktobjecten worden meegenomen in de uitvoer. De standaardwaarde is `false`.
- [InkOptions.getInterpretMaskOpAsOpacity] bepaalt of een maskeringsbewerking wordt geïnterpreteerd als dekking bij het renderen van een inktpenseel. De standaardwaarde is `true`; roep [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) aan met `false` om in plaats daarvan de ROP‑bewerking te gebruiken.

### **Inktobjecten verbergen in PDF‑uitvoer**

Standaard blijven inktobjecten zichtbaar tijdens export. Om een schone uitvoer zonder handgeschreven aantekeningen of andere inktinhoud te creëren, roep [InkOptions.setHideInk](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) aan met `true`.

Het volgende JavaScript‑voorbeeld exporteert een presentatie naar PDF terwijl alle inktobjecten worden verborgen:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Inktobjecten verbergen bij het renderen van een dia als afbeelding**

Om inktobjecten te verbergen bij het renderen van dia's als bitmap‑afbeeldingen, configureer [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) en geef de renderingsopties door aan [Slide.getImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#getImage-aspose.slides.IRenderingOptions-).

Het volgende JavaScript‑voorbeeld rendert de eerste dia als een PNG‑afbeelding zonder inktobjecten:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Inktmasker‑weergave regelen**

[InkOptions.getInterpretMaskOpAsOpacity] bepaalt hoe maskeringsbewerkingen worden geïnterpreteerd bij het renderen van inktpenselen. De standaardwaarde is `true`, waardoor dekking wordt gebruikt. Om in plaats daarvan de ROP‑bewerking te gebruiken, roep [InkOptions.setInterpretMaskOpAsOpacity] aan met `false`.

Het volgende JavaScript‑voorbeeld exporteert een dia naar SVG en gebruikt ROP‑gebaseerde rendering voor inktmasker‑bewerkingen:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

Dezelfde instelling kan worden toegepast via [TiffOptions.getInkOptions] wanneer u een presentatie exporteert of een dia rendert naar TIFF.

### **Kies of u inkt wilt verbergen of behouden**

Wanneer u een schone versie van een geannoteerde presentatie nodig heeft voor distributie zonder review‑markeringen, roep dan [InkOptions.setHideInk] aan met `true` tijdens de export.

Laat [InkOptions.getHideInk] op de standaardwaarde `false` staan wanneer inktannotaties deel uitmaken van de beoogde inhoud, zoals review‑commentaren, handgeschreven notities, markeringen of tekeningen die zichtbaar moeten blijven in het geëxporteerde resultaat. Hierdoor kunnen toepassingen afzonderlijke review‑ en definitieve uitvoer genereren vanuit dezelfde presentatie zonder de bron‑ink‑objecten te wijzigen.

## **FAQ**

**Kan ik de kleur of grootte van een bestaande inktstreep wijzigen?**

Ja. Haal het spoor op via [Ink.getTraces](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ink/#getTraces--) en wijzig vervolgens de bijbehorende [InkTrace.getBrush](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/inktrace/#getBrush--). Roep [InkBrush.setColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/inkbrush/#setColor-java.awt.Color-) of [InkBrush.setSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/inkbrush/#setSize-java.awt.geom.Dimension2D-) aan om het penseel aan te passen.

**Verandert het verbergen van inkt de bronpresentatie?**

Nee. Het aanroepen van [InkOptions.setHideInk](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) beïnvloedt alleen het gerenderde of geëxporteerde resultaat; het verwijdert of wijzigt de inktobjecten niet in de bronpresentatie.

**Welke exportformaten ondersteunen inktopties?**

U kunt inktopties configureren voor PDF, HTML, SVG, TIFF en bitmap‑dia‑afbeeldingen via de overeenkomstige export‑ of renderingsopties die hierboven worden getoond.

**Meer lezen**

* Om meer te lezen over vormen in het algemeen, zie de sectie [PowerPoint Shapes](https://docs.aspose.com/slides/nl/nodejs-java/powerpoint-shapes/).
* Voor meer informatie over effectieve waarden, zie [Shape Effective Properties](https://docs.aspose.com/slides/nl/nodejs-java/shape-effective-properties/#get-effective-font-height-value).
* Voor details over PDF‑export, zie [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/nl/nodejs-java/convert-powerpoint-to-pdf/).
* Voor details over HTML‑export, zie [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/nl/nodejs-java/convert-powerpoint-to-html/).
* Voor details over SVG‑export, zie [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/nl/nodejs-java/render-a-slide-as-an-svg-image/).
* Voor details over TIFF‑export, zie [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/nl/nodejs-java/convert-powerpoint-to-tiff/).
* Voor details over dia‑naar‑afbeelding rendering, zie [Convert Presentation Slides to Images](https://docs.aspose.com/slides/nl/nodejs-java/convert-slide/).