---
title: Inkobjecten in presentaties beheren op Android
linktitle: Ink beheren
type: docs
weight: 95
url: /nl/androidjava/manage-ink/
keywords:
- inkt
- inktobject
- inktspoor
- ink beheren
- inkt tekenen
- tekenen
- inkt exporteren
- inkweergave
- inkt verbergen
- IInkOptions
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer PowerPoint-inkobjecten, bewerk sporen en penseel-eigenschappen, en beheer de weergave van inkt tijdens export naar PDF, HTML, SVG, TIFF en afbeeldingen met Aspose.Slides voor Android."
---
## **Inleiding**

PowerPoint biedt een inktfunctie waarmee u vrije lijnen kunt tekenen. Inkt kan worden gebruikt om andere objecten te markeren, verbindingen en processen weer te geven, en de aandacht te vestigen op specifieke items op een dia.

Aspose.Slides biedt de typen die nodig zijn om met inktobjecten te werken. Bijvoorbeeld, de [IInk](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iink/) interface vertegenwoordigt een inktobject op een dia.

## **Verschillen tussen gewone objecten en inktobjecten**

Objecten op een PowerPoint-dia worden doorgaans weergegeven door vormobjecten. In de eenvoudigste vorm is een vorm een container die het gebied van het object zelf (het frame) definieert, samen met eigenschappen zoals de containergrootte, vorm en achtergrond. Voor meer informatie, zie [Shape Layout Format](https://docs.aspose.com/slides/nl/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Wanneer PowerPoint echter een inktobject verwerkt, negeert het alle eigenschappen van het objectframe (container) behalve de grootte. De grootte van het containergebied wordt bepaald door de standaard [IShape.getWidth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getWidth--) en [IShape.getHeight](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getHeight--) methoden:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inktsporen**

Een inktspoor is een basiselement dat wordt gebruikt om de traject van een pen vast te leggen terwijl een gebruiker digitale inkt schrijft. Een spoor slaat een reeks verbonden punten op.

De eenvoudigste vorm van codering geeft de X- en Y-coördinaten van elk monsterpunt op. Wanneer alle verbonden punten worden gerenderd, produceren ze een afbeelding zoals deze:

![ink_powerpoint2](ink_powerpoint2.png)

## **Eigenschappen van penselen voor tekenen**

Een penseel wordt gebruikt om lijnen te tekenen die de punten van een inktspoor verbinden. Het penseel heeft zijn eigen kleur en grootte, vertegenwoordigd door de [IInkBrush.getColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iinkbrush/#getColor--) en [IInkBrush.getSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iinkbrush/#getSize--) methoden.

### **Stel inktpenseelkleur in**

Deze Java-code laat zien hoe u de kleur van een inktpenseel instelt:

```java
import android.graphics.Color;
import com.aspose.slides.*;

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

### **Stel inktpenseelgrootte in**

Deze Java-code laat zien hoe u de grootte van een inktpenseel instelt:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    SizeF brushSize = new SizeF(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Over het algemeen komen de breedte en hoogte van een penseel niet overeen, waardoor PowerPoint de penseelgrootte niet weergeeft (de overeenkomstige gegevenssectie is grijs weergegeven). Wanneer de breedte en hoogte van het penseel wel overeenkomen, toont PowerPoint de grootte op deze manier:

![ink_powerpoint3](ink_powerpoint3.png)

Voor de duidelijkheid, laten we de hoogte van het inktobject vergroten en de belangrijke afmetingen bekijken:

![ink_powerpoint4](ink_powerpoint4.png)

De container (frame) houdt geen rekening met de grootte van de penselen – hij gaat er altijd van uit dat de lijndikte nul is (zie de vorige afbeelding).

Daarom moet, om het zichtbare gebied van het volledige inktobject te bepalen, de penseelgrootte van de sporen in aanmerking worden genomen. Hier is het doelobject (het handgeschreven tekstspoor) geschaald naar de grootte van de container (frame). Wanneer de grootte van de container verandert, blijft de penseelgrootte constant, en omgekeerd.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint gebruikt vergelijkbaar gedrag voor tekstobjecten:

![ink_powerpoint6](ink_powerpoint6.png)

## **Inktweergave controleren tijdens export en rendering**

Aspose.Slides biedt de [IInkOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iinkoptions/) interface om te bepalen hoe inktobjecten verschijnen in geëxporteerde of gerenderde output. U kunt de eigenschappen gebruiken om inkt volledig te verbergen of om te wijzigen hoe inktpenseelmaskerbewerkingen worden geïnterpreteerd.

Inkopties zijn beschikbaar via de export‑ of renderopties voor verschillende uitvoertypen:

| Uitvoer | Inkoptie‑eigenschap |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Dia‑afbeelding | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) |

De volgende [IInkOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iinkoptions/) methoden bieden dezelfde twee instellingen:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) bepaalt of inktobjecten worden opgenomen in de output. De standaardwaarde is `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) bepaalt of een maskerbewerking wordt geïnterpreteerd als opacity bij het renderen van een inktpenseel. De standaardwaarde is `true`; roep [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) aan met `false` om in plaats daarvan de ROP‑bewerking te gebruiken.

### **Ink‑objecten verbergen in PDF‑uitvoer**

Standaard blijven inktobjecten zichtbaar tijdens export. Om een schone output te creëren zonder handgeschreven aantekeningen of andere inktinhoud, roep [IInkOptions.setHideInk](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) aan met `true`.

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

### **Ink‑objecten verbergen bij het renderen van een dia als afbeelding**

Om inktobjecten te verbergen bij het renderen van dia's als bitmap‑afbeeldingen, configureer [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) en geef de renderopties door aan [ISlide.getImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-).

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

### **Inktmaskerweergave controleren**

De [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) instelling bepaalt hoe maskerbewerkingen worden geïnterpreteerd bij het renderen van inktpenselen. De standaardwaarde is `true`, wat opacity gebruikt. Om in plaats daarvan de ROP‑bewerking te gebruiken, roep [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) aan met `false`.

Het volgende Java‑voorbeeld exporteert een dia naar SVG en gebruikt ROP‑gebaseerde weergave voor inktmaskerbewerkingen:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    FileOutputStream stream = new FileOutputStream("slide.svg");
    try {
        slide.writeAsSvg(stream, svgOptions);
    } finally {
        stream.close();
    }
} finally {
    presentation.dispose();
}
```

Dezelfde instelling kan worden toegepast via [TiffOptions.getInkOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) bij het exporteren van een presentatie of het renderen van een dia naar TIFF.

### **Kies of u inkt wilt verbergen of behouden**

Wanneer u een schone versie van een geannoteerde presentatie nodig heeft voor distributie zonder review‑markeringen, roep [IInkOptions.setHideInk](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) aan met `true` tijdens het exporteren.

Laat [IInkOptions.getHideInk](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) op de standaardwaarde `false` staan wanneer inktannotaties deel uitmaken van de beoogde inhoud, zoals review‑opmerkingen, handgeschreven notities, markeringen of tekeningen die zichtbaar moeten blijven in het geëxporteerde resultaat. Dit stelt applicaties in staat om afzonderlijke review‑ en definitieve outputs te genereren vanuit dezelfde presentatie zonder de bron‑inkobjecten te wijzigen.

## **Veelgestelde vragen**

**Kan ik de kleur of grootte van een bestaande inktstreep wijzigen?**

Ja. Haal het spoor op via [IInk.getTraces](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iink/#getTraces--), wijzig vervolgens de [IInkTrace.getBrush](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iinktrace/#getBrush--). Roep [IInkBrush.setColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iinkbrush/#setColor-java.lang.Integer-) of [IInkBrush.setSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iinkbrush/#setSize-com.aspose.slides.android.SizeF-) aan om het penseel te wijzigen.

**Verandert het verbergen van inkt de oorspronkelijke presentatie?**

Nee. Het aanroepen van [IInkOptions.setHideInk](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) heeft alleen invloed op het gerenderde of geëxporteerde resultaat; het verwijdert of wijzigt geen inktobjecten in de bronpresentatie.

**Welke exportformaten ondersteunen inkopties?**

U kunt inkopties configureren voor PDF, HTML, SVG, TIFF en bitmap‑dia‑afbeeldingen via de overeenkomende export‑ of renderopties die hierboven worden getoond.

**Verdere lectuur**

* Voor algemene informatie over vormen, zie de sectie [PowerPoint Shapes](https://docs.aspose.com/slides/nl/androidjava/powerpoint-shapes/).
* Voor meer informatie over effectieve waarden, zie [Shape Effective Properties](https://docs.aspose.com/slides/nl/androidjava/shape-effective-properties/#get-effective-font-height-value).
* Voor details over PDF‑export, zie [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/nl/androidjava/convert-powerpoint-to-pdf/).
* Voor details over HTML‑export, zie [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/nl/androidjava/convert-powerpoint-to-html/).
* Voor details over SVG‑export, zie [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/nl/androidjava/render-a-slide-as-an-svg-image/).
* Voor details over TIFF‑export, zie [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/nl/androidjava/convert-powerpoint-to-tiff/).
* Voor details over dia‑naar‑afbeelding rendering, zie [Convert Presentation Slides to Images](https://docs.aspose.com/slides/nl/androidjava/convert-slide/).