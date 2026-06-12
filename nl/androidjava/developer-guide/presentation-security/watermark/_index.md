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
- watermerk verwijderen uit PPT
- watermerk verwijderen uit PPTX
- watermerk verwijderen uit ODP
- watermerk wissen uit PPT
- watermerk wissen uit PPTX
- watermerk wissen uit ODP
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer tekst- en afbeeldingwatermerken in PowerPoint- en OpenDocument-presentaties op Android in Java om een concept, vertrouwelijke informatie en meer aan te geven."
---
## **Inleiding**

**Een watermerk** in een presentatie is een tekst- of afbeeldingstempel die op een dia of op alle presentatiedia’s wordt toegepast. Meestal wordt een watermerk gebruikt om aan te geven dat de presentatie een concept is (bijv. een “Concept”-watermerk), dat deze vertrouwelijke informatie bevat (bijv. een “Vertrouwelijk”-watermerk), om te vermelden bij welk bedrijf deze hoort (bijv. een “Bedrijfsnaam”-watermerk), om de auteur van de presentatie te identificeren, enz. Een watermerk helpt auteursrechtinbreuken te voorkomen door aan te geven dat de presentatie niet gekopieerd mag worden. Watermerken worden zowel in PowerPoint‑ als OpenOffice‑presentatieformaten gebruikt. In Aspose.Slides kun je een watermerk toevoegen aan PowerPoint‑PPT, PPTX en OpenOffice‑ODP‑bestandsformaten.

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/android-java/), zijn er verschillende manieren om watermerken in PowerPoint‑ of OpenOffice‑documenten te maken en hun ontwerp en gedrag aan te passen. Het gemeenschappelijke punt is dat je voor tekstwatermerken de [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/)-interface moet gebruiken, en voor afbeeldingwatermerken de [PictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pictureframe/)-klasse of een watermerkvorm kunt vullen met een afbeelding. `PictureFrame` implementeert de [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/)-interface, waardoor je alle flexibele instellingen van het vormobject kunt benutten. Omdat `ITextFrame` geen vorm is en de instellingen beperkt zijn, wordt deze gewrapped in een [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/)-object.

Er zijn twee manieren waarop een watermerk kan worden toegepast: op één enkele dia of op alle presentatiedia’s. De Slide Master wordt gebruikt om een watermerk op alle presentatiedia’s toe te passen — het watermerk wordt aan de Slide Master toegevoegd, daar volledig ontworpen, en vervolgens op alle dia’s toegepast zonder de mogelijkheid om het watermerk op individuele dia’s te wijzigen.

Een watermerk wordt doorgaans beschouwd als niet bewerkbaar voor andere gebruikers. Om te voorkomen dat het watermerk (of eerder de bovenliggende vorm van het watermerk) wordt bewerkt, biedt Aspose.Slides vergrendelingsfunctionaliteit voor vormen. Een specifieke vorm kan worden vergrendeld op een normale dia of op een Slide Master. Wanneer de watermerkvorm op de Slide Master wordt vergrendeld, wordt deze vergrendeld op alle presentatiedia’s.

Je kunt een naam aan het watermerk geven zodat je het later, als je het wilt verwijderen, kunt vinden in de vormen van de dia op naam.

Je kunt het watermerk op elke gewenste manier ontwerpen; er zijn echter meestal gemeenschappelijke kenmerken in watermerken, zoals centrale uitlijning, rotatie, voorgrondpositie, enz. Hieronder bekijken we hoe je deze kunt toepassen in de voorbeelden.

## **Tekstwatermerk**

### **Een tekstwatermerk aan een dia toevoegen**

Om een tekstwatermerk toe te voegen in PPT, PPTX of ODP, kun je eerst een vorm aan de dia toevoegen en vervolgens een tekstframe aan die vorm. Het tekstframe wordt vertegenwoordigd door de [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/)-interface. Dit type is niet afgeleid van [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/), die een breed scala aan eigenschappen biedt voor het flexibel positioneren van het watermerk. Daarom wordt het [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/)-object gewrapped in een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/)-object. Om tekst aan de vorm toe te voegen, gebruik je de [addTextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)‑methode zoals hieronder getoond.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Zie ook" %}} 
- [Hoe de TextFrame‑klasse te gebruiken](/slides/nl/androidjava/text-formatting/)
{{% /alert %}}

### **Een tekstwatermerk aan een presentatie toevoegen**

Als je een tekstwatermerk wilt toevoegen aan de volledige presentatie (dus aan alle dia’s tegelijk), voeg je het toe aan de [MasterSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/masterslide/). De rest van de logica is dezelfde als bij het toevoegen van een watermerk aan één dia — maak een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/)-object en voeg vervolgens het watermerk toe met de [addTextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)‑methode.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Zie ook" %}} 
- [Hoe de Slide Master te gebruiken](/slides/nl/androidjava/slide-master/)
{{% /alert %}}

### **Transparantie van de watermerkvorm instellen**

Standaard wordt de rechthoekvorm gestileerd met vul‑ en lijnkleur. De volgende code maakt de vorm transparant.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Lettertype voor een tekstwatermerk instellen**

Je kunt het lettertype van het tekstwatermerk wijzigen zoals hieronder weergegeven.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Kleur van de watermerktekst instellen**

Om de kleur van de watermerktekst in te stellen, gebruik je deze code:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```

### **Een tekstwatermerk centreren**

Het is mogelijk om het watermerk op een dia te centreren; doe dat als volgt:

```java
SizeF slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

De afbeelding hieronder toont het uiteindelijke resultaat.

![The text watermark](text_watermark.png)

## **Afbeeldingswatermerk**

### **Een afbeeldingwatermerk aan een presentatie toevoegen**

Om een afbeeldingwatermerk aan een presentatiedia toe te voegen, kun je het volgende doen:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **Een watermerk vergrendelen tegen bewerken**

Als je moet voorkomen dat een watermerk wordt bewerkt, gebruik je de [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--)‑methode op de vorm. Met deze eigenschap kun je de vorm beschermen tegen selectie, grootte‑aanpassing, verplaatsing, groeperen met andere elementen, het vergrendelen van de tekst voor bewerking, en meer:

```java
// Vergrendel de watermerkvorm tegen wijzigen
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **Een watermerk naar de voorgrond brengen**

In Aspose.Slides kan de Z‑volgorde van vormen worden ingesteld via de [IShapeCollection.reorder](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-)‑methode. Hiervoor roep je deze methode aan vanuit de lijst met presentatiedia’s en geef je de vormreferentie en het volgnummer door. Zo kun je een vorm naar de voorgrond brengen of naar de achtergrond van de dia verplaatsen. Deze functie is vooral handig wanneer je een watermerk voor de rest van de presentatie wilt plaatsen:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Rotatie van het watermerk instellen**

Hieronder vind je een codevoorbeeld om de rotatie van het watermerk zó aan te passen dat het diagonaal over de dia wordt geplaatst:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **Een naam aan een watermerk geven**

Aspose.Slides maakt het mogelijk om de naam van een vorm in te stellen. Door de vormnaam te gebruiken, kun je later de vorm benaderen om deze te wijzigen of te verwijderen. Om de naam van de watermerkvorm in te stellen, ken je deze toe via de [IAutoShape.setName](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-)‑methode:

```java
watermarkShape.setName("watermark");
```

### **Een watermerk verwijderen**

Om de watermerkvorm te verwijderen, gebruik je de [IAutoShape.getName](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getName--)‑methode om deze in de dia‑vormen te vinden. Vervolgens geef je de watermerkvorm door aan de [IShapeCollection.remove](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)‑methode:

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

Een watermerk is een tekst‑ of afbeeldingsoverdracht die op dia’s wordt toegepast om intellectueel eigendom te beschermen, merkherkenning te verbeteren of ongeoorloofd gebruik van presentaties te voorkomen.

**Kan ik een watermerk aan alle dia’s in een presentatie toevoegen?**

Ja, Aspose.Slides stelt je in staat om programmatically een watermerk toe te voegen aan elke dia in een presentatie. Je kunt door alle dia’s itereren en de watermerkinstellingen afzonderlijk toepassen.

**Hoe kan ik de transparantie van het watermerk aanpassen?**

Je kunt de transparantie van het watermerk aanpassen door de vulinstellingen ([getFillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getFillFormat--)) van de vorm te wijzigen. Zo blijft het watermerk subtiel en storend niet de inhoud van de dia.

**Welke afbeeldingsformaten worden ondersteund voor watermerken?**

Aspose.Slides ondersteunt verschillende afbeeldingsformaten zoals PNG, JPEG, GIF, BMP, SVG en meer.

**Kan ik het lettertype en de stijl van een tekstwatermerk aanpassen?**

Ja, je kunt elk lettertype, grootte en stijl kiezen om aan het ontwerp van je presentatie te voldoen en merkconsistentie te behouden.

**Hoe wijzig ik de positie of oriëntatie van een watermerk?**

Je kunt de positie en oriëntatie van het watermerk programmatically aanpassen door de coördinaten, grootte en rotatie‑eigenschappen van de vorm te wijzigen.