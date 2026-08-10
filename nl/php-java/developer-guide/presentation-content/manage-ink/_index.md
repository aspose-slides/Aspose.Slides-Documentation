---
title: Beheer PowerPoint-inkobjecten in PHP
linktitle: Ink beheren
type: docs
weight: 95
url: /nl/php-java/manage-ink/
keywords:
- inkt
- inkobject
- inkspoor
- ink beheren
- ink tekenen
- tekening
- inkexport
- inkrenderen
- ink verbergen
- InkOptions
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Beheer PowerPoint-inkobjecten, bewerk sporen en penseel­eigenschappen, en beheer de weergave van inkt tijdens PDF-, HTML-, SVG-, TIFF- en afbeeldingsexport met Aspose.Slides voor PHP via Java."
---
## **Introductie**

PowerPoint biedt een inktfunctie waarmee u vrijvormige streken kunt tekenen. Inkt kan worden gebruikt om andere objecten te markeren, verbindingen en processen weer te geven, en de aandacht te vestigen op specifieke items op een dia.

Aspose.Slides biedt de typen die nodig zijn om met inktobjecten te werken. Bijvoorbeeld, de [Ink](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ink/) klasse vertegenwoordigt een inktobject op een dia.

## **Verschillen tussen gewone objecten en inktobjecten**

Objecten op een PowerPoint‑dia worden doorgaans weergegeven door [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/) objecten. In de eenvoudigste vorm is een shape een container die het gebied van het object zelf (het frame) definieert, samen met eigenschappen zoals de container‑grootte, vorm en achtergrond. Voor meer informatie, zie [Shape Layout Format](https://docs.aspose.com/slides/nl/php-java/shape-manipulations/#access-layout-formats-for-shape).

Wanneer PowerPoint echter een inktobject verwerkt, negeert het alle eigenschappen van het objectframe (container) behalve de grootte. De grootte van het containergebied wordt bepaald door de standaardmethoden [Shape.getWidth](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getWidth) en [Shape.getHeight](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **Inktsporen**

Een inktspoor is een basiselement dat wordt gebruikt om de traject van een pen vast te leggen terwijl een gebruiker digitale inkt schrijft. Een spoor slaat een reeks verbonden punten op.

De eenvoudigste codering specificeert de X‑ en Y‑coördinaten van elk monsterpunt. Wanneer alle verbonden punten worden gerenderd, produceren ze een afbeelding als deze:

![ink_powerpoint2](ink_powerpoint2.png)

## **Penseel‑eigenschappen voor tekenen**

Een penseel wordt gebruikt om lijnen te tekenen die de punten van een inktspoor verbinden. Het penseel heeft zijn eigen kleur en grootte, weergegeven door de methoden [InkBrush.getColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/inkbrush/#getColor) en [InkBrush.getSize](https://reference.aspose.com/slides/nl/php-java/aspose.slides/inkbrush/#getSize).

### **Stel inktpenseelkleur in**

Deze PHP‑code laat zien hoe u de kleur van een inktpenseel instelt:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **Stel inktpenseelgrootte in**

Deze PHP‑code laat zien hoe u de grootte van een inktpenseel instelt:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

In het algemeen komen breedte en hoogte van een penseel niet overeen, zodat PowerPoint de penseelgrootte niet weergeeft (de bijbehorende gegevenssectie wordt grijs). Wanneer breedte en hoogte wel gelijk zijn, toont PowerPoint de grootte op deze manier:

![ink_powerpoint3](ink_powerpoint3.png)

Voor de duidelijkheid vergroten we de hoogte van het inktobject en bekijken we de belangrijke afmetingen:

![ink_powerpoint4](ink_powerpoint4.png)

De container (frame) houdt geen rekening met de grootte van de pennen — hij gaat altijd uit van een lijndikte van nul (zie de vorige afbeelding).

Daarom moet, om het zichtbare gebied van het volledige inktobject te bepalen, de penseelgrootte van de sporen in aanmerking worden genomen. Hier is het doelobject (het handgeschreven tekstspoor) geschaald naar de grootte van de container (frame). Wanneer de grootte van de container verandert, blijft de penseelgrootte constant, en omgekeerd.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint gebruikt vergelijkbaar gedrag voor tekstobjecten:

![ink_powerpoint6](ink_powerpoint6.png)

## **Inktweergave tijdens export en rendering beheren**

Aspose.Slides levert de [InkOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/inkoptions/) klasse om te regelen hoe inktobjecten verschijnen in geëxporteerde of gerenderde uitvoer. U kunt de eigenschappen gebruiken om inkt volledig te verbergen of om te bepalen hoe inkt‑penseelmasker‑operaties worden geïnterpreteerd.

Ink‑opties zijn beschikbaar via de export‑ of renderingsopties voor verschillende uitvoertypen:

| Uitvoer | Ink‑opties eigenschap |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| Dia‑afbeelding | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/renderingoptions/#getInkOptions) |

De volgende [InkOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/inkoptions/) methoden bieden dezelfde twee instellingen:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/nl/php-java/aspose.slides/inkoptions/#getHideInk) bepaalt of inktobjecten worden opgenomen in de uitvoer. De standaardwaarde is `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/nl/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) bepaalt of een masker‑operatie wordt geïnterpreteerd als doorzichtigheid bij het renderen van een inktpenseel. De standaardwaarde is `true`; roep [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/nl/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) aan met `false` om in plaats daarvan de ROP‑operatie te gebruiken.

### **Ink‑objecten verbergen in PDF‑uitvoer**

Standaard blijven inktobjecten zichtbaar tijdens export. Om een schone output zonder handgeschreven aantekeningen of andere inktinhoud te maken, roep [InkOptions.setHideInk](https://reference.aspose.com/slides/nl/php-java/aspose.slides/inkoptions/#setHideInk) aan met `true`.

De volgende PHP‑voorbeeld exporteert een presentatie naar PDF terwijl alle inktobjecten worden verborgen:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Ink‑objecten verbergen bij het renderen van een dia als afbeelding**

Om inktobjecten te verbergen bij het renderen van dia's als bitmap‑afbeeldingen, configureer [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/renderingoptions/#getInkOptions) en geef de renderingsopties door aan [Slide.getImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#getImage).

De volgende PHP‑voorbeeld renderen de eerste dia als PNG‑afbeelding zonder inktobjecten:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **Inktmasker‑rendering beheren**

De instelling [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/nl/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) bepaalt hoe masker‑operaties worden geïnterpreteerd bij het renderen van inktpennen. De standaardwaarde is `true`, wat doorzichtigheid gebruikt. Om in plaats daarvan de ROP‑operatie te gebruiken, roep [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/nl/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) aan met `false`.

De volgende PHP‑voorbeeld exporteert een dia naar SVG en gebruikt ROP‑gebaseerde rendering voor inktmasker‑operaties:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Dezelfde instelling kan worden toegepast via [TiffOptions.getInkOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tiffoptions/#getInkOptions) bij het exporteren van een presentatie of het renderen van een dia naar TIFF.

### **Kies of u inkt wilt verbergen of behouden**

Wanneer u een schone versie van een geannoteerde presentatie wilt distribueren zonder review‑markeringen, roep [InkOptions.setHideInk](https://reference.aspose.com/slides/nl/php-java/aspose.slides/inkoptions/#setHideInk) aan met `true` tijdens export.

Laat [InkOptions.getHideInk](https://reference.aspose.com/slides/nl/php-java/aspose.slides/inkoptions/#getHideInk) op de standaardwaarde `false` staan wanneer inktannotaties deel uitmaken van de beoogde inhoud, zoals review‑opmerkingen, handgeschreven notities, markeringen of tekeningen die zichtbaar moeten blijven in het geëxporteerde resultaat. Dit stelt toepassingen in staat om aparte review‑ en definitieve outputs te genereren vanuit dezelfde presentatie zonder de bron‑ink‑objecten te wijzigen.

## **Veelgestelde vragen**

**Kan ik de kleur of grootte van een bestaande inktstreep aanpassen?**

Ja. Haal het spoor op via [Ink.getTraces](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ink/#getTraces), wijzig vervolgens zijn [InkTrace.getBrush](https://reference.aspose.com/slides/nl/php-java/aspose.slides/inktrace/#getBrush). Roep [InkBrush.setColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/inkbrush/#setColor) of [InkBrush.setSize](https://reference.aspose.com/slides/nl/php-java/aspose.slides/inkbrush/#setSize) aan om het penseel te wijzigen.

**Verandert het verbergen van inkt de bronpresentatie?**

Nee. Het aanroepen van [InkOptions.setHideInk](https://reference.aspose.com/slides/nl/php-java/aspose.slides/inkoptions/#setHideInk) beïnvloedt alleen het gerenderde of geëxporteerde resultaat; het verwijdert of wijzigt geen inktobjecten in de bronpresentatie.

**Welke exportformaten ondersteunen inktopties?**

U kunt inktopties configureren voor PDF, HTML, SVG, TIFF en bitmap‑dia‑afbeeldingen via de corresponderende export‑ of renderingsopties die hierboven worden getoond.

**Verdere lectuur**

* Voor algemene informatie over vormen, zie de [PowerPoint Shapes](https://docs.aspose.com/slides/nl/php-java/powerpoint-shapes/) sectie.
* Voor meer informatie over effectieve waarden, zie [Shape Effective Properties](https://docs.aspose.com/slides/nl/php-java/shape-effective-properties/#get-effective-font-height-value).
* Voor details over PDF‑export, zie [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/nl/php-java/convert-powerpoint-to-pdf/).
* Voor details over HTML‑export, zie [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/nl/php-java/convert-powerpoint-to-html/).
* Voor details over SVG‑export, zie [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/nl/php-java/render-a-slide-as-an-svg-image/).
* Voor details over TIFF‑export, zie [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/nl/php-java/convert-powerpoint-to-tiff/).
* Voor details over dia‑naar‑afbeelding rendering, zie [Convert Presentation Slides to Images](https://docs.aspose.com/slides/nl/php-java/convert-slide/).