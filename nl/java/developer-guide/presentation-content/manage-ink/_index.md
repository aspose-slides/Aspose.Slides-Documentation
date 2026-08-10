---
title: Inkobjecten in presentaties beheren in Java
linktitle: Ink beheren
type: docs
weight: 95
url: /nl/java/manage-ink/
keywords:
- inkt
- inktobject
- inktspoor
- inkt beheren
- inkt tekenen
- tekenen
- inkt export
- inkt rendering
- inkt verbergen
- IInkOptions
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Beheer PowerPoint-inkobjecten, bewerk sporen en penseleigenschappen, en controleer het uiterlijk van inkt tijdens PDF-, HTML-, SVG-, TIFF- en afbeeldingsexport met Aspose.Slides voor Java."
---
## **Inleiding**

PowerPoint biedt een inktfunctie waarmee u vrije handstreken kunt tekenen. Ink kan worden gebruikt om andere objecten te accentueren, verbindingen en processen te tonen, en de aandacht te vestigen op specifieke items op een dia.

Aspose.Slides levert de benodigde types om met inktobjecten te werken. Bijvoorbeeld, de [IInk](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iink/) interface vertegenwoordigt een inktobject op een dia.

## **Verschillen tussen reguliere objecten en inktobjecten**

Objecten op een PowerPoint-dia worden doorgaans weergegeven door vormobjecten. In de eenvoudigste vorm is een vorm een container die het gebied van het object zelf (het kader) definieert, samen met eigenschappen zoals de containergrootte, vorm en achtergrond. Zie voor meer informatie [Shape Layout Format](https://docs.aspose.com/slides/nl/java/shape-manipulations/#access-layout-formats-for-shape).

Echter, wanneer PowerPoint een inktobject verwerkt, negeert het alle eigenschappen van het objectkader (container) behalve de grootte. De grootte van het containergebied wordt bepaald door de standaard [IShape.getWidth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getWidth--) en [IShape.getHeight](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getHeight--) methoden:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inktsporen**

Een inktspoor is een basiselement dat de trajectorie van een pen registreert terwijl een gebruiker digitale inkt schrijft. Een spoor slaat een reeks verbonden punten op.

De eenvoudigste coderingsvorm geeft de X- en Y-coördinaten van elk monsterpunt op. Wanneer alle verbonden punten worden gerenderd, ontstaat er een afbeelding zoals deze:

![ink_powerpoint2](ink_powerpoint2.png)

## **Penseleigenschappen voor tekenen**

Een penseel wordt gebruikt om lijnen te tekenen die de punten van een inktspoor verbinden. Het penseel heeft zijn eigen kleur en grootte, weergegeven door de methoden [IInkBrush.getColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iinkbrush/#getColor--) en [IInkBrush.getSize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iinkbrush/#getSize--) .

### **Inktpenseelkleur instellen**

Deze Java‑code toont hoe u de kleur van een inktpenseel kunt instellen:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **Inktpenseelgrootte instellen**

Deze Java‑code toont hoe u de grootte van een inktpenseel kunt instellen:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    Dimension brushSize = new Dimension(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Over het algemeen komen de breedte en hoogte van een penseel niet overeen, zodat PowerPoint de penseelgrootte niet weergeeft (het bijbehorende gegevensgedeelte is grijs). Wanneer de breedte en hoogte van het penseel wel overeenkomen, toont PowerPoint de grootte als volgt:

![ink_powerpoint3](ink_powerpoint3.png)

Voor de duidelijkheid vergroten we de hoogte van het inktobject en bekijken we de belangrijke afmetingen:

![ink_powerpoint4](ink_powerpoint4.png)

De container (kader) houdt geen rekening met de grootte van de penselen – hij gaat er altijd van uit dat de lijndikte nul is (zie de vorige afbeelding).

Daarom moet bij het bepalen van het zichtbare gebied van het volledige inktobject rekening worden gehouden met de penseelgrootte van de sporen. Hier is het doelobject (het handgeschreven tekstspoor) geschaald naar de grootte van de container (kader). Wanneer de grootte van de container wijzigt, blijft de penseelgrootte constant, en vice versa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint hanteert vergelijkbaar gedrag voor tekstobjecten:

![ink_powerpoint6](ink_powerpoint6.png)

## **Inktweergave tijdens export en rendering controleren**

Aspose.Slides levert de [IInkOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iinkoptions/) interface om te bepalen hoe inktobjecten verschijnen in geëxporteerde of gerenderde output. U kunt de eigenschappen gebruiken om inkt volledig te verbergen of om te wijzigen hoe inktpenseel‑maskerbewerkingen worden geïnterpreteerd.

Ink‑opties zijn beschikbaar via de export‑ of renderopties voor verschillende uitvoertypen:

| Uitvoer | Ink‑opties eigenschap |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/renderingoptions/#getInkOptions--) |

De volgende [IInkOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iinkoptions/) methoden bieden dezelfde twee instellingen:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iinkoptions/#getHideInk--) bepaalt of inktobjecten worden opgenomen in de output. De standaardwaarde is `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) bepaalt of een maskbewerkingsopdracht wordt geïnterpreteerd als opacity bij het renderen van een inktpenseel. De standaardwaarde is `true`; roep [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) aan met `false` om de ROP‑bewerking te gebruiken.

### **Inktobjecten verbergen in PDF‑output**

Standaard blijven inktobjecten zichtbaar tijdens export. Om een schone output te creëren zonder handgeschreven aantekeningen of andere inktinhoud, roep [IInkOptions.setHideInk](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) aan met `true`.

Het volgende Java‑voorbeeld exporteert een presentatie naar PDF terwijl alle inktobjecten worden verborgen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Inktobjecten verbergen bij het renderen van een dia als afbeelding**

Om inktobjecten te verbergen bij het renderen van dia’s als bitmap‑afbeeldingen, configureer [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/renderingoptions/#getInkOptions--) en geef de renderopties door aan [ISlide.getImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-).

Het volgende Java‑voorbeeld rendert de eerste dia als een PNG‑afbeelding zonder inktobjecten:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Inktmasker rendering beheersen**

De instelling [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) bepaalt hoe mask‑bewerkingen worden geïnterpreteerd bij het renderen van inktpenselen. De standaardwaarde is `true`, wat opacity gebruikt. Om in plaats daarvan de ROP‑bewerking te gebruiken, roep [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) aan met `false`.

Het volgende Java‑voorbeeld exporteert een dia naar SVG en gebruikt ROP‑gebaseerde rendering voor inktmasker‑bewerkingen:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    FileOutputStream stream = new FileOutputStream("slide.svg");
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.writeAsSvg(stream, svgOptions);
} finally {
    presentation.dispose();
}
```

Dezelfde instelling kan worden toegepast via [TiffOptions.getInkOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tiffoptions/#getInkOptions--) bij het exporteren van een presentatie of het renderen van een dia naar TIFF.

### **Kiezen of u inkt wilt verbergen of behouden**

Wanneer u een schone versie van een geannoteerde presentatie nodig heeft voor distributie zonder revisie‑markeringen, roep [IInkOptions.setHideInk](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) aan met `true` tijdens export.

Laat [IInkOptions.getHideInk](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iinkoptions/#getHideInk--) op de standaardwaarde `false` wanneer inktannotaties onderdeel uitmaken van de beoogde inhoud, zoals review‑opmerkingen, handgeschreven notities, markeringen of tekeningen die zichtbaar moeten blijven in het geëxporteerde resultaat. Dit maakt het mogelijk om afzonderlijke review‑ en definitieve output te genereren vanuit dezelfde presentatie zonder de bron‑inkobjecten aan te passen.

## **FAQ**

**Kan ik de kleur of grootte van een bestaande inktstreek wijzigen?**

Ja. Haal het spoor op via [IInk.getTraces](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iink/#getTraces--), wijzig vervolgens zijn [IInkTrace.getBrush](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iinktrace/#getBrush--). Roep [IInkBrush.setColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iinkbrush/#setColor-java.awt.Color-) of [IInkBrush.setSize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iinkbrush/#setSize-java.awt.geom.Dimension2D-) aan om het penseel te wijzigen.

**Verandert het verbergen van inkt de bronpresentatie?**

Nee. Het aanroepen van [IInkOptions.setHideInk](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) heeft alleen invloed op de gerenderde of geëxporteerde output; het verwijdert of wijzigt geen inktobjecten in de bronpresentatie.

**Welke exportformaten ondersteunen inktopties?**

U kunt inktopties configureren voor PDF, HTML, SVG, TIFF en bitmap‑dia‑afbeeldingen via de overeenkomstige export‑ of renderopties die hierboven worden getoond.

**Verdere lectuur**

* Voor algemene informatie over vormen, zie de sectie [PowerPoint Shapes](https://docs.aspose.com/slides/nl/java/powerpoint-shapes/).
* Voor meer informatie over effectieve waarden, zie [Shape Effective Properties](https://docs.aspose.com/slides/nl/java/shape-effective-properties/#get-effective-font-height-value).
* Voor details over PDF‑export, zie [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/nl/java/convert-powerpoint-to-pdf/).
* Voor details over HTML‑export, zie [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/nl/java/convert-powerpoint-to-html/).
* Voor details over SVG‑export, zie [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/nl/java/render-a-slide-as-an-svg-image/).
* Voor details over TIFF‑export, zie [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/nl/java/convert-powerpoint-to-tiff/).
* Voor details over renderen van dia’s naar afbeeldingen, zie [Convert Presentation Slides to Images](https://docs.aspose.com/slides/nl/java/convert-slide/).