---
title: Voeg watermerken toe aan presentaties in Java
linktitle: Watermerk
type: docs
weight: 40
url: /nl/java/watermark/
keywords:
- watermerk
- tekstwatermerk
- afbeeldingwatermerk
- watermerk toevoegen
- watermerk wijzigen
- watermerk verwijderen
- watermerk wissen
- watermerk toevoegen aan PPT
- watermerk toevoegen aan PPTX
- watermerk toevoegen aan ODP
- watermerk verwijderen uit PPT
- watermerk verwijderen uit PPTX
- watermerk verwijderen uit ODP
- watermerk wissen uit PPT
- watermerk wissen uit PPTX
- watermerk wissen uit ODP
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheer tekst‑ en afbeeldingwatermerken in PowerPoint‑ en OpenDocument‑presentaties in Java om een concept, vertrouwelijke informatie, copyright en meer aan te geven."
---
## **Inleiding**

**Een watermerk** in een presentatie is een tekst- of afbeeldingstempel die op een dia of door alle presentatiedia’s heen wordt gebruikt. Gewoonlijk wordt een watermerk gebruikt om aan te geven dat de presentatie een concept is (bijv. een “Concept”-watermerk), dat deze vertrouwelijke informatie bevat (bijv. een “Vertrouwelijk”-watermerk), om te specificeren bij welk bedrijf het hoort (bijv. een “Bedrijfsnaam”-watermerk), om de auteur van de presentatie te identificeren, enz. Een watermerk helpt auteursrechtschendingen te voorkomen door aan te geven dat de presentatie niet gekopieerd mag worden. Watermerken worden gebruikt in zowel PowerPoint‑ als OpenOffice‑presentatieformaten. In Aspose.Slides kunt u een watermerk toevoegen aan PowerPoint‑PPT, PPTX en OpenOffice‑ODP‑bestandsformaten.

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/java/) zijn er verschillende manieren om watermerken te maken in PowerPoint‑ of OpenOffice‑documenten en hun ontwerp en gedrag aan te passen. Het gemeenschappelijke aspect is dat u voor het toevoegen van tekst‑watermerken de [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/)‑interface moet gebruiken, en voor het toevoegen van afbeelding‑watermerken de [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/)‑klasse of een watermerk‑vorm met een afbeelding vult. `PictureFrame` implementeert de [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/)‑interface, waardoor u alle flexibele instellingen van het vormobject kunt gebruiken. Omdat `ITextFrame` geen vorm is en de instellingen beperkt zijn, wordt deze gewrapt in een [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/)‑object.

Er zijn twee manieren om een watermerk toe te passen: op één dia of op alle presentatiedia’s. De Slide Master wordt gebruikt om een watermerk op alle presentatiedia’s toe te passen — het watermerk wordt aan de Slide Master toegevoegd, daar volledig ontworpen, en vervolgens op alle dia’s toegepast zonder de mogelijkheid om het watermerk op individuele dia’s te wijzigen te beïnvloeden.

Een watermerk wordt normaal gezien als niet bewerkbaar door andere gebruikers. Om te voorkomen dat het watermerk (of beter gezegd de bovenliggende vorm van het watermerk) wordt bewerkt, biedt Aspose.Slides functionaliteit voor het vergrendelen van vormen. Een specifieke vorm kan worden vergrendeld op een gewone dia of op een Slide Master. Wanneer de watermerk‑vorm op de Slide Master vergrendeld is, wordt deze op alle presentatiedia’s vergrendeld.

U kunt een naam aan het watermerk geven, zodat u het later, wanneer u het wilt verwijderen, via de naam kunt vinden in de vormen van de dia.

U kunt het watermerk op elke gewenste manier ontwerpen; er zijn echter doorgaans gemeenschappelijke kenmerken bij watermerken, zoals centrering, rotatie, voorgrondpositie, enz. We zullen in de onderstaande voorbeelden laten zien hoe u deze kunt gebruiken.

## **Tekst‑watermerk**

### **Voeg een tekst‑watermerk toe aan een dia**

Om een tekst‑watermerk toe te voegen in PPT, PPTX of ODP, kunt u eerst een vorm aan de dia toevoegen en vervolgens een tekst‑frame aan die vorm. Het tekst‑frame wordt weergegeven door de [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/)‑interface. Dit type erft niet van [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/), die een uitgebreide set eigenschappen heeft voor het flexibel positioneren van het watermerk. Daarom wordt het [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/)‑object gewrapt in een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/)‑object. Om watermerk‑tekst aan de vorm toe te voegen, gebruikt u de [addTextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)‑methode zoals hieronder weergegeven.

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
- [Hoe de TextFrame‑klasse gebruiken](/slides/nl/java/text-formatting/)
{{% /alert %}}

### **Voeg een tekst‑watermerk toe aan een presentatie**

Als u een tekst‑watermerk wilt toevoegen aan de volledige presentatie (dwz. alle dia’s tegelijk), voegt u het toe aan de [MasterSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/masterslide/). De rest van de logica is hetzelfde als bij het toevoegen van een watermerk aan één dia — maak een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/)‑object aan en voeg vervolgens het watermerk toe met behulp van de [addTextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)‑methode.

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
- [Hoe de Slide Master gebruiken](/slides/nl/java/slide-master/)
{{% /alert %}}

### **Stel transparantie van watermerk‑vorm in**

Standaard wordt de rechthoekige vorm opgemaakt met vul‑ en lijnkleuren. De volgende code‑regels maken de vorm transparant.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **Stel het lettertype van een tekst‑watermerk in**

U kunt het lettertype van het tekst‑watermerk wijzigen zoals hieronder weergegeven.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);

presentation.dispose();
```

### **Stel de kleur van het watermerk‑tekst in**

Om de kleur van de watermerk‑tekst in te stellen, gebruikt u deze code:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));

presentation.dispose();
```

### **Centreer een tekst‑watermerk**

Het is mogelijk om het watermerk te centreren op een dia; daarvoor kunt u het volgende doen:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

De onderstaande afbeelding toont het eindresultaat.

![Het tekst‑watermerk](text_watermark.png)

## **Afbeeldings‑watermerk**

### **Voeg een afbeeldings‑watermerk toe aan een presentatie**

Om een afbeeldings‑watermerk toe te voegen aan een presentatiedia, kunt u het volgende doen:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

presentation.dispose();
```

### **Vergrendel een watermerk tegen bewerking**

Indien het nodig is om een watermerk te voorkomen dat het bewerkt wordt, gebruikt u de [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/#getAutoShapeLock--)‑methode op de vorm. Met deze eigenschap kunt u de vorm beschermen tegen selecteren, formaat wijzigen, verplaatsen, groeperen met andere elementen, de tekst vergrendelen tegen bewerking, en nog veel meer:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Vergrendel de watermerkvorm tegen wijzigen
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **Breng een watermerk naar voren**

In Aspose.Slides kan de Z‑volgorde van vormen worden ingesteld via de [IShapeCollection.reorder](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-)‑methode. Om dit te doen, roept u deze methode aan vanuit de lijst met presentatiedia’s en geeft u de vormreferentie en het volgnummer door aan de methode. Op deze manier kunt u een vorm naar voren brengen of naar de achterkant van de dia verplaatsen. Deze functionaliteit is vooral handig als u een watermerk voor de presentatie wilt plaatsen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **Stel rotatie van watermerk in**

Hier volgt een code‑voorbeeld hoe u de rotatie van het watermerk kunt aanpassen zodat het diagonaal over de dia wordt geplaatst:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

Dimension2D slideSize = presentation.getSlideSize().getSize();

double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);

presentation.dispose();
```

### **Stel een naam in voor een watermerk**

Aspose.Slides stelt u in staat de naam van een vorm in te stellen. Door de vormnaam te gebruiken, kunt u later de vorm wijzigen of verwijderen. Om de naam van de watermerk‑vorm in te stellen, wijst u deze toe aan de [IAutoShape.setName](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#setName-java.lang.String-)‑methode:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **Verwijder een watermerk**

Om de watermerk‑vorm te verwijderen, gebruikt u de [IAutoShape.getName](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getName--)‑methode om deze te vinden in de vormen van de dia. Vervolgens geeft u de watermerk‑vorm door aan de [IShapeCollection.remove](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)‑methode:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(shape);
    }
}

presentation.dispose();
```

## **FAQ**

### Wat is een watermerk en waarom zou ik het gebruiken?

Een watermerk is een tekst‑ of afbeelding‑overlay die op dia’s wordt toegepast en helpt intellectueel eigendom te beschermen, de merkherkenning te vergroten, of ongeoorloofd gebruik van presentaties te voorkomen.

### Kan ik een watermerk toevoegen aan alle dia’s in een presentatie?

Ja, Aspose.Slides stelt u in staat programmatically een watermerk toe te voegen aan elke dia in een presentatie. U kunt door alle dia’s itereren en de watermerk‑instellingen individueel toepassen.

### Hoe kan ik de transparantie van het watermerk aanpassen?

U kunt de transparantie van het watermerk aanpassen door de vul‑instellingen ([getFillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getFillFormat--)) van de vorm te wijzigen. Dit zorgt ervoor dat het watermerk subtiel is en de dia‑inhoud niet afleidt.

### Welke afbeeldingformaten worden ondersteund voor watermerken?

Aspose.Slides ondersteunt verschillende afbeeldingformaten zoals PNG, JPEG, GIF, BMP, SVG en meer.

### Kan ik het lettertype en de stijl van een tekst‑watermerk aanpassen?

Ja, u kunt elk lettertype, grootte en stijl kiezen om aan te sluiten bij het ontwerp van uw presentatie en de merkconsistentie te behouden.

### Hoe wijzig ik de positie of oriëntatie van een watermerk?

U kunt de positie en oriëntatie van het watermerk programmatically aanpassen door de coördinaten, grootte en rotatie‑eigenschappen van de vorm te wijzigen.