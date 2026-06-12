---
title: Watermerken toevoegen aan presentaties in Java
linktitle: Watermerk
type: docs
weight: 40
url: /nl/java/watermark/
keywords:
- watermerk
- tekstwatermerk
- afbeeldingswatermerk
- watermerk toevoegen
- watermerk wijzigen
- watermerk verwijderen
- watermerk verwijderen
- watermerk toevoegen aan PPT
- watermerk toevoegen aan PPTX
- watermerk toevoegen aan ODP
- watermerk verwijderen uit PPT
- watermerk verwijderen uit PPTX
- watermerk verwijderen uit ODP
- watermerk verwijderen uit PPT
- watermerk verwijderen uit PPTX
- watermerk verwijderen uit ODP
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheer tekst- en afbeeldingswatermerken in PowerPoint- en OpenDocument-presentaties in Java om een concept, vertrouwelijke informatie, auteursrechten en meer aan te duiden."
---
## **Inleiding**

**Een watermerk** in een presentatie is een tekst- of afbeeldingstempel die op een dia of door alle presentatiedia's heen wordt gebruikt. Meestal wordt een watermerk gebruikt om aan te geven dat de presentatie een concept is (bijv. een "Concept" watermerk), dat deze vertrouwelijke informatie bevat (bijv. een "Vertrouwelijk" watermerk), om te specificeren van welk bedrijf het afkomstig is (bijv. een "Bedrijfsnaam" watermerk), om de auteur van de presentatie te identificeren, enz. Een watermerk helpt om auteursrechtschendingen te voorkomen door aan te geven dat de presentatie niet gekopieerd mag worden. Watermerken worden gebruikt in zowel PowerPoint- als OpenOffice-presentatieformaten. In Aspose.Slides kun je een watermerk toevoegen aan PowerPoint PPT, PPTX en OpenOffice ODP bestandsformaten.

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/java/), zijn er verschillende manieren waarop je watermerken kunt maken in PowerPoint- of OpenOffice-documenten en hun ontwerp en gedrag kunt aanpassen. Het gemeenschappelijke aspect is dat je voor het toevoegen van tekstwatermerken de [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) interface moet gebruiken, en voor het toevoegen van afbeeldingswatermerken de [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/) klasse of een watermerkvorm met een afbeelding moet vullen. `PictureFrame` implementeert de [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/) interface, waardoor je alle flexibele instellingen van het vormobject kunt gebruiken. Omdat `ITextFrame` geen vorm is en de instellingen beperkt zijn, wordt het ingepakt in een [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/) object.

Er zijn twee manieren om een watermerk toe te passen: op één dia of op alle presentatiedia's. De Slide Master wordt gebruikt om een watermerk op alle presentatiedia's toe te passen — het watermerk wordt toegevoegd aan de Slide Master, daar volledig vormgegeven, en op alle dia's toegepast zonder de mogelijkheid om het watermerk op individuele dia's te wijzigen te beïnvloeden.

Een watermerk wordt meestal beschouwd als niet bewerkbaar voor andere gebruikers. Om te voorkomen dat het watermerk (of eerder de bovenliggende vorm van het watermerk) wordt bewerkt, biedt Aspose.Slides vormvergrendelingsfunctionaliteit. Een specifieke vorm kan worden vergrendeld op een gewone dia of op een Slide Master. Wanneer de watermerkvorm op de Slide Master wordt vergrendeld, is deze op alle presentatiedia's vergrendeld.

Je kunt een naam voor het watermerk instellen zodat je het later, wanneer je het wilt verwijderen, kunt vinden in de vormen van de dia op basis van die naam.

Je kunt het watermerk op elke gewenste manier ontwerpen; er zijn echter meestal gemeenschappelijke kenmerken in watermerken, zoals centrering, rotatie, voorgrondpositie, enz. We zullen in de onderstaande voorbeelden bekijken hoe je deze kunt gebruiken.

## **Tekstwatermerk**

### **Een Tekstwatermerk aan een Dia Toevoegen**

Om een tekstwatermerk toe te voegen in PPT, PPTX of ODP, kun je eerst een vorm aan de dia toevoegen, vervolgens een tekstframe aan deze vorm. Het tekstframe wordt weergegeven door de [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) interface. Dit type erft niet van [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/), die een brede set eigenschappen heeft voor het flexibel positioneren van het watermerk. Daarom wordt het [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) object ingepakt in een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) object. Om watermerktekst aan de vorm toe te voegen, gebruik je de [addTextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) methode zoals hieronder getoond.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Zie ook" %}} 
- [Hoe de TextFrame-klasse te gebruiken](/slides/nl/java/text-formatting/)
{{% /alert %}}

### **Een Tekstwatermerk aan een Presentatie Toevoegen**

Als je een tekstwatermerk wilt toevoegen aan de volledige presentatie (dwz alle dia's tegelijk), voeg het dan toe aan de [MasterSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/masterslide/). De rest van de logica is dezelfde als bij het toevoegen van een watermerk aan één dia — maak een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) object aan en voeg vervolgens het watermerk toe met de [addTextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) methode.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Zie ook" %}} 
- [Hoe de Slide Master te gebruiken](/slides/nl/java/slide-master/)
{{% /alert %}}

### **Doorzichtigheid van Watermerkvorm Instellen**

Standaard is de rechthoekige vorm opgemaakt met vul- en lijnekleuren. De onderstaande code maakt de vorm transparant.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Lettertype voor een Tekstwatermerk Instellen**

Je kunt het lettertype van het tekstwatermerk wijzigen zoals hieronder weergegeven.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Kleur van het Watermerktekst Instellen**

Om de kleur van de watermerktekst in te stellen, gebruik je deze code:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```

### **Een Tekstwatermerk Centreren**

Het is mogelijk om het watermerk op een dia te centreren, en daarvoor kun je het volgende doen:

```java
Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

De afbeelding hieronder toont het uiteindelijke resultaat.

![Het tekstwatermerk](text_watermark.png)

## **Afbeeldingswatermerk**

### **Een Afbeeldingswatermerk aan een Presentatie Toevoegen**

Om een afbeeldingswatermerk aan een presentatiedia toe te voegen, kun je het volgende doen:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **Een Watermerk Vergrendelen tegen Bewerken**

Indien het nodig is om een watermerk tegen bewerking te beschermen, gebruik je de [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) methode op de vorm. Met deze eigenschap kun je de vorm beschermen tegen selecteren, formaat wijzigen, verplaatsen, groeperen met andere elementen, de tekst vergrendelen tegen bewerking, en meer:

```java
// Vergrendel de watermerkvorm tegen bewerken
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **Een Watermerk naar Voorgrond Brengen**

In Aspose.Slides kan de Z-volgorde van vormen worden ingesteld via de [IShapeCollection.reorder](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) methode. Om dit te doen, moet je deze methode aanroepen vanuit de lijst met presentatiedia's en de vormreferentie en het orde‑nummer doorgeven. Op deze manier kun je een vorm naar de voorgrond brengen of naar de achtergrond van de dia verplaatsen. Deze functie is vooral handig als je een watermerk voor de presentatie wilt plaatsen:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Rotatie van Watermerk Instellen**

Hier is een code‑voorbeeld van hoe je de rotatie van het watermerk kunt aanpassen zodat het diagonaal over de dia wordt geplaatst:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **Een Naam aan een Watermerk Toekennen**

Aspose.Slides stelt je in staat de naam van een vorm in te stellen. Door de vormnaam te gebruiken, kun je later toegang krijgen om deze te wijzigen of te verwijderen. Om de naam van de watermerkvorm in te stellen, wijs je deze toe via de [IAutoShape.setName](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#setName-java.lang.String-) methode:

```java
watermarkShape.setName("watermark");
```

### **Een Watermerk Verwijderen**

Om de watermerkvorm te verwijderen, gebruik je de [IAutoShape.getName](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getName--) methode om deze te vinden in de vormen van de dia. Vervolgens geef je de watermerkvorm door aan de [IShapeCollection.remove](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) methode:

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **FAQ**

**Wat is een watermerk en waarom zou ik het gebruiken?**

Een watermerk is een tekst‑ of afbeeldingsoverlay die op dia's wordt toegepast en helpt intellectueel eigendom te beschermen, de merkherkenning te versterken, of ongeoorloofd gebruik van presentaties te voorkomen.

**Kan ik een watermerk toevoegen aan alle dia's in een presentatie?**

Ja, Aspose.Slides stelt je in staat programmatically een watermerk toe te voegen aan elke dia in een presentatie. Je kunt door alle dia's itereren en de watermerkinstellingen afzonderlijk toepassen.

**Hoe kan ik de doorzichtigheid van het watermerk aanpassen?**

Je kunt de doorzichtigheid van het watermerk aanpassen door de vulinstellingen ([getFillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getFillFormat--)) van de vorm te wijzigen. Dit zorgt ervoor dat het watermerk subtiel is en niet afleidt van de inhoud van de dia.

**Welke afbeeldingsformaten worden ondersteund voor watermerken?**

Aspose.Slides ondersteunt diverse afbeeldingsformaten zoals PNG, JPEG, GIF, BMP, SVG en meer.

**Kan ik het lettertype en de stijl van een tekstwatermerk aanpassen?**

Ja, je kunt elk lettertype, grootte en stijl kiezen die passen bij het ontwerp van je presentatie en de merkconsistentie behouden.

**Hoe verander ik de positie of oriëntatie van een watermerk?**

Je kunt de positie en oriëntatie van het watermerk programmatically aanpassen door de coördinaten, grootte en rotatie‑eigenschappen van de vorm te wijzigen.