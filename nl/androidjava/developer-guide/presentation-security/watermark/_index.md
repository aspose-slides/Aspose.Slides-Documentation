---
title: Watermerken toevoegen aan presentaties op Android
linktitle: Watermerk
type: docs
weight: 40
url: /nl/androidjava/watermark/
keywords:
- watermerk
- tekstwatermerk
- afbeeldingwatermerk
- watermerk toevoegen
- watermerk wijzigen
- watermerk verwijderen
- watermerk verwijderen
- watermerk toevoegen aan PPT
- watermerk toevoegen aan PPTX
- watermerk toevoegen aan ODP
- watermerk verwijderen van PPT
- watermerk verwijderen van PPTX
- watermerk verwijderen van ODP
- watermerk verwijderen van PPT
- watermerk verwijderen van PPTX
- watermerk verwijderen van ODP
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer tekst‑ en afbeeldingwatermerken in PowerPoint‑ en OpenDocument‑presentaties op Android in Java om een concept, vertrouwelijke informatie en meer aan te geven."
---
## **Introductie**

**Een watermerk** in een presentatie is een tekst‑ of afbeeldingstempel die op een dia of in alle dia’s van een presentatie wordt gebruikt. Meestal wordt een watermerk gebruikt om aan te geven dat de presentatie een concept is (bijv. een “Concept”‑watermerk), dat deze vertrouwelijke informatie bevat (bijv. een “Vertrouwelijk”‑watermerk), om te specificeren van welk bedrijf hij afkomstig is (bijv. een “Bedrijfsnaam”‑watermerk), om de auteur van de presentatie te identificeren, enzovoort. Een watermerk helpt auteursrechtsschendingen te voorkomen door aan te geven dat de presentatie niet gekopieerd mag worden. Watermerken worden zowel in PowerPoint‑ als in OpenOffice‑presentatieformaten gebruikt. In Aspose.Slides kun je een watermerk toevoegen aan PowerPoint‑PPT, PPTX en OpenOffice‑ODP‑bestanden.

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/android-java/), zijn er verschillende manieren om watermerken te maken in PowerPoint‑ of OpenOffice‑documenten en hun ontwerp en gedrag aan te passen. Het gemeenschappelijke aspect is dat je voor tekst‑watermerken de [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/)‑interface moet gebruiken, en voor afbeelding‑watermerken de [PictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pictureframe/)‑klasse of een vorm vullen met een afbeelding. `PictureFrame` implementeert de [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/)‑interface, waardoor je alle flexibele instellingen van het vormobject kunt gebruiken. Omdat `ITextFrame` geen vorm is en de instellingen beperkt zijn, wordt het ingepakt in een [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/)‑object.

Er zijn twee manieren waarop een watermerk kan worden toegepast: op één enkele dia of op alle dia’s van de presentatie. De Slide Master wordt gebruikt om een watermerk op alle dia’s toe te passen — het watermerk wordt aan de Slide Master toegevoegd, daar volledig ontworpen, en vervolgens op alle dia’s toegepast zonder de mogelijkheid om het watermerk op individuele dia’s te bewerken te beïnvloeden.

Een watermerk wordt doorgaans beschouwd als niet te bewerken door andere gebruikers. Om te voorkomen dat het watermerk (of beter gezegd de bovenliggende vorm van het watermerk) wordt bewerkt, biedt Aspose.Slides functionaliteit om vormen te vergrendelen. Een specifieke vorm kan worden vergrendeld op een normale dia of op een Slide Master. Wanneer de watermerkvorm op de Slide Master wordt vergrendeld, is deze op alle dia’s vergrendeld.

Je kunt een naam toekennen aan het watermerk zodat je het later, als je het wilt verwijderen, kunt vinden via de naam van de vormen op de dia.

Je kunt het watermerk op elke gewenste manier ontwerpen; meestal hebben watermerken echter gedeelde kenmerken, zoals gecentreerde uitlijning, rotatie, voorgrondpositie, enzovoort. We zullen in de voorbeelden hieronder laten zien hoe je deze kunt gebruiken.

## **Tekstwatermerk**

### **Tekstwatermerk toevoegen aan een dia**

Om een tekst‑watermerk toe te voegen in PPT, PPTX of ODP, kun je eerst een vorm aan de dia toevoegen en vervolgens een tekst‑frame aan die vorm. Het tekst‑frame wordt vertegenwoordigd door de [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/)‑interface. Dit type is niet afgeleid van [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/), die een breed scala aan eigenschappen biedt voor het flexibel positioneren van het watermerk. Daarom wordt het [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/)‑object ingepakt in een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/)‑object. Om watermerktekst aan de vorm toe te voegen, gebruik je de [addTextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)‑methode zoals hieronder weergegeven.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Zie ook" %}} 
- [Hoe de TextFrame‑klasse te gebruiken](/slides/nl/androidjava/text-formatting/)
{{% /alert %}}

### **Tekstwatermerk toevoegen aan een presentatie**

Wil je een tekst‑watermerk toevoegen aan de gehele presentatie (dwz. alle dia’s tegelijk), voeg het dan toe aan de [MasterSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/masterslide/). De rest van de logica is hetzelfde als bij het toevoegen van een watermerk aan één dia — maak een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/)‑object en voeg vervolgens het watermerk toe met behulp van de [addTextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)‑methode.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Zie ook" %}} 
- [Hoe de Slide Master te gebruiken](/slides/nl/androidjava/slide-master/)
{{% /alert %}}

### **Transparantie van de watermerkvorm instellen**

Standaard wordt de rechthoekvorm gestyled met vul‑ en lijnkleuren. De onderstaande code maakt de vorm transparant.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.getFillFormat().setFillType(FillType.NoFill);
    watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
} finally {
    presentation.dispose();
}
```

### **Lettertype van een tekstwatermerk instellen**

Je kunt het lettertype van het tekst‑watermerk wijzigen zoals hieronder weergegeven.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    textFormat.setLatinFont(new FontData("Arial"));
    textFormat.setFontHeight(50);
} finally {
    presentation.dispose();
}
```

### **Kleur van de watermerktekst instellen**

Om de kleur van de watermerktekst in te stellen, gebruik je deze code:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 150, red = 200, green = 200, blue = 200;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
    fillFormat.setFillType(FillType.Solid);
    fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
} finally {
    presentation.dispose();
}
```

### **Een tekstwatermerk centreren**

Het is mogelijk om het watermerk op een dia te centreren; daarvoor kun je het volgende doen:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    float watermarkWidth = 400;
    float watermarkHeight = 40;
    float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
    float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(
            ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

    ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
} finally {
    presentation.dispose();
}
```

De afbeelding hieronder toont het eindresultaat.

![Het tekstwatermerk](text_watermark.png)

## **Afbeeldingswatermerk**

### **Een afbeeldingswatermerk toevoegen aan een presentatie**

Om een afbeeldingswatermerk toe te voegen aan een presentatiedia, kun je het volgende doen:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    InputStream imageStream = new FileInputStream("watermark.png");
    IPPImage image = presentation.getImages().addImage(imageStream);

    watermarkShape.getFillFormat().setFillType(FillType.Picture);
    watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
} finally {
    presentation.dispose();
}
```

### **Een watermerk vergrendelen tegen bewerking**

Indien het noodzakelijk is om een watermerk te beschermen tegen bewerking, gebruik je de [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--)‑methode op de vorm. Met deze eigenschap kun je de vorm beschermen tegen selectie, grootte‑aanpassing, verplaatsing, groeperen met andere elementen, vergrendeling van de tekst tegen bewerking, en nog veel meer:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    // Vergrendel de watermerkvorm tegen bewerken
    watermarkShape.getAutoShapeLock().setSelectLocked(true);
    watermarkShape.getAutoShapeLock().setSizeLocked(true);
    watermarkShape.getAutoShapeLock().setTextLocked(true);
    watermarkShape.getAutoShapeLock().setPositionLocked(true);
    watermarkShape.getAutoShapeLock().setGroupingLocked(true);
} finally {
    presentation.dispose();
}
```

### **Een watermerk naar voren brengen**

In Aspose.Slides kan de Z‑volgorde van vormen worden ingesteld via de [IShapeCollection.reorder](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-)‑methode. Hiervoor roep je deze methode aan vanuit de lijst met presentatiedia’s en geef je de vormreferentie en het volgnummer door. Op deze manier kun je een vorm naar de voorgrond brengen of naar de achtergrond verplaatsen. Deze functionaliteit is vooral handig wanneer je een watermerk vóór de rest van de presentatie wilt plaatsen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    int shapeCount = slide.getShapes().size();
    slide.getShapes().reorder(shapeCount - 1, watermarkShape);
} finally {
    presentation.dispose();
}
```

### **Watermerkrotatie instellen**

Hier is een code‑voorbeeld van hoe je de rotatie van het watermerk kunt aanpassen zodat het diagonaal over de dia wordt gepositioneerd:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

    watermarkShape.setRotation((float)diagonalAngle);
} finally {
    presentation.dispose();
}
```

### **Een naam toewijzen aan een watermerk**

Aspose.Slides stelt je in staat de naam van een vorm in te stellen. Door de vormnaam te gebruiken, kun je later de vorm vinden om deze aan te passen of te verwijderen. Om de naam van de watermerkvorm in te stellen, wijs je deze toe aan de [IAutoShape.setName](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-)‑methode:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.setName("watermark");
} finally {
    presentation.dispose();
}
```

### **Een watermerk verwijderen**

Om de watermerkvorm te verwijderen, gebruik je de [IAutoShape.getName](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getName--)‑methode om deze in de vormen van de dia te vinden. Vervolgens geef je de watermerkvorm door aan de [IShapeCollection.remove](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)‑methode:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("watermarked.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape[] slideShapes = slide.getShapes().toArray();
    for (IShape shape : slideShapes) {
        if ("watermark".equals(shape.getName()))
        {
            slide.getShapes().remove(shape);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Wat is een watermerk en waarom zou ik het gebruiken?

Een watermerk is een tekst‑ of afbeeldingsoverlay die op dia’s wordt toegepast en helpt intellectueel eigendom te beschermen, merkherkenning te vergroten of ongeautoriseerd gebruik van presentaties te voorkomen.

### Kan ik een watermerk toevoegen aan alle dia’s in een presentatie?

Ja, Aspose.Slides maakt het mogelijk om programmatically een watermerk toe te voegen aan elke dia in een presentatie. Je kunt door alle dia’s itereren en de watermerk‑instellingen afzonderlijk toepassen.

### Hoe kan ik de transparantie van het watermerk aanpassen?

Je kunt de transparantie van het watermerk aanpassen door de vulinstellingen ([getFillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getFillFormat--)) van de vorm te wijzigen. Zo blijft het watermerk subtiel en afleidt het niet van de inhoud van de dia.

### Welke afbeeldingformaten worden ondersteund voor watermerken?

Aspose.Slides ondersteunt diverse afbeeldingformaten zoals PNG, JPEG, GIF, BMP, SVG en meer.

### Kan ik het lettertype en de stijl van een tekstwatermerk aanpassen?

Ja, je kunt elk lettertype, grootte en stijl kiezen om te passen bij het ontwerp van je presentatie en de merkconsistentie te behouden.

### Hoe wijzig ik de positie of oriëntatie van een watermerk?

Je kunt de positie en oriëntatie van het watermerk programmatically aanpassen door de coördinaten, grootte en rotatie‑eigenschappen van de vorm te wijzigen.