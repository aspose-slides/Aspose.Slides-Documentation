---
title: Watermerken toevoegen aan presentaties in JavaScript
linktitle: Watermerk
type: docs
weight: 40
url: /nl/nodejs-java/watermark/
keywords:
- watermerk
- tekstwatermerk
- afbeeldingswatermerk
- watermerk toevoegen
- watermerk wijzigen
- watermerk verwijderen
- watermerk wissen
- watermerk toevoegen aan PPT
- watermerk toevoegen aan PPTX
- watermerk toevoegen aan ODP
- watermerk verwijderen van PPT
- watermerk verwijderen van PPTX
- watermerk verwijderen van ODP
- watermerk wissen van PPT
- watermerk wissen van PPTX
- watermerk wissen van ODP
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer tekst- en afbeeldingswatermerken in PowerPoint- en OpenDocument-presentaties in Node.js om een concept, vertrouwelijke informatie, auteursrechten en meer aan te geven."
---
## **Inleiding**

**Een watermerk** in een presentatie is een tekst- of afbeeldingstempel die op een dia of door alle presentatiedia's heen wordt gebruikt. Gewoonlijk wordt een watermerk gebruikt om aan te geven dat de presentatie een concept is (bijv. een "Concept"-watermerk), dat het vertrouwelijke informatie bevat (bijv. een "Vertrouwelijk"-watermerk), om aan te geven van welk bedrijf het afkomstig is (bijv. een "Bedrijfsnaam"-watermerk), om de auteur van de presentatie te identificeren, enzovoort. Een watermerk helpt auteursrechtschendingen te voorkomen door aan te geven dat de presentatie niet gekopieerd mag worden. Watermerken worden gebruikt in zowel PowerPoint‑ als OpenOffice‑presentatieformaten. In Aspose.Slides kun je een watermerk toevoegen aan PowerPoint‑PPT, PPTX en OpenOffice ODP bestandsformaten.

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/nodejs-java/) zijn er verschillende manieren om watermerken te maken in PowerPoint‑ of OpenOffice‑documenten en hun ontwerp en gedrag aan te passen. Het gemeenschappelijke aspect is dat je voor het toevoegen van tekstwatermerken het type [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) moet gebruiken, en voor het toevoegen van afbeeldingwatermerken de klasse [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) of een watermerk‑vorm met een afbeelding moet vullen. `PictureFrame` implementeert het type [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/), waardoor je alle flexibele instellingen van het vormobject kunt gebruiken. Aangezien `TextFrame` geen vorm is en de instellingen beperkt zijn, wordt het ingebed in een [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/) object.

Er zijn twee manieren om een watermerk toe te passen: op één enkele dia of op alle presentatiedia's. De Slide Master wordt gebruikt om een watermerk toe te passen op alle presentatiedia's — het watermerk wordt toegevoegd aan de Slide Master, daar volledig vormgegeven, en toegepast op alle dia's zonder dat dit de mogelijkheid beïnvloedt om het watermerk op individuele dia's te wijzigen.

Een watermerk wordt doorgaans beschouwd als niet bewerkbaar door andere gebruikers. Om te voorkomen dat het watermerk (of beter gezegd de bovenliggende vorm van het watermerk) wordt bewerkt, biedt Aspose.Slides functionaliteit voor het vergrendelen van vormen. Een specifieke vorm kan worden vergrendeld op een normale dia of op een Slide Master. Wanneer de watermerk‑vorm op de Slide Master is vergrendeld, is deze vergrendeld op alle presentatiedia's.

Je kunt een naam aan het watermerk toekennen zodat je in de toekomst, als je het wilt verwijderen, het kunt vinden in de vormen van de dia op naam.

Je kunt het watermerk op elke gewenste manier ontwerpen; er zijn echter meestal gemeenschappelijke kenmerken in watermerken, zoals centrering, rotatie, positie op de voorgrond, enz. We zullen in de onderstaande voorbeelden laten zien hoe je deze kunt gebruiken.

## **Tekstwatermerk**

### **Tekstwatermerk toevoegen aan dia**
Om een tekstwatermerk toe te voegen in PPT, PPTX of ODP, kun je eerst een vorm aan de dia toevoegen, vervolgens een tekstframe aan die vorm. Het tekstframe wordt vertegenwoordigd door het type [**TextFrame**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrame). Dit type is niet afgeleid van [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape), dat een ruime reeks eigenschappen biedt voor het flexibel positioneren van het watermerk. Daarom wordt het [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrame)-object ingepakt in een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape)-object. Om watermerktekst aan de vorm toe te voegen, gebruik je de methode [**addTextFrame**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) met de watermerktekst als argument:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Zie ook" %}} 
- Hoe gebruik je [TextFrame](/slides/nl/nodejs-java/text-formatting/)
{{% /alert %}}

### **Tekstwatermerk toevoegen aan presentatie**
Als je een tekstwatermerk wilt toevoegen aan de volledige presentatie (dwz alle dia's tegelijk), voeg je het toe aan de [**MasterSlide**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/MasterSlide). De rest van de logica is dezelfde als bij het toevoegen van een watermerk aan één dia — maak een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape)-object aan en voeg vervolgens het watermerk toe met de methode [**addTextFrame**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-):

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Zie ook" %}} 
- [Hoe gebruik je ](/slides/nl/nodejs-java/slide-master/)[Slide Master](/slides/nl/nodejs-java/slide-master/)
{{% /alert %}}

### **Transparantie van watermerk‑vorm instellen**
Standaard heeft de rechthoekige vorm vul- en lijneigenschappen. De onderstaande code maakt de vorm transparant.

```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```

### **Lettertype voor een tekstwatermerk instellen**
Je kunt het lettertype van het tekstwatermerk wijzigen zoals hieronder weergegeven.

```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Kleur van watermerktekst instellen**
Om de kleur van de watermerktekst in te stellen, gebruik je de volgende code:

```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```

### **Tekstwatermerk centreren**
Het is mogelijk om een watermerk in het midden van een dia te plaatsen; daarvoor kun je het volgende doen:

```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

De onderstaande afbeelding toont het eindresultaat.

![Het tekstwatermerk](text_watermark.png)

## **Afbeeldingswatermerk**

### **Afbeeldingswatermerk toevoegen aan een presentatie**
Om een afbeeldingwatermerk toe te voegen aan alle presentatiedia's, kun je het volgende doen:

```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```

### **Watermerk vergrendelen tegen bewerking**
Als het nodig is om te voorkomen dat een watermerk wordt bewerkt, gebruik dan de methode [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape#getShapeLock--) op de vorm. Met deze eigenschap kun je de vorm beschermen tegen selecteren, vergroten/verkleinen, verplaatsen, groeperen met andere elementen, de tekst vergrendelen tegen bewerking, en nog veel meer:

```javascript
// Vergrendel de watermerkvorm tegen bewerken
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```

### **Watermerk naar voren brengen**
In Aspose.Slides kan de Z‑volgorde van vormen worden ingesteld via de methode [**SlideCollection.reorder**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-). Hiervoor roep je deze methode aan vanuit de lijst met presentatiedia's en geef je de vormreferentie en het volgnummer door. Op deze manier kun je een vorm naar voren brengen of naar de achtergrond sturen. Deze functie is vooral handig wanneer je een watermerk voor de presentatie wilt plaatsen:

```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Rotatie van watermerk instellen**
Hier is een codevoorbeeld om de rotatie van het watermerk aan te passen zodat het diagonaal over de dia wordt geplaatst:

```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```

### **Een naam aan een watermerk toekennen**
Aspose.Slides maakt het mogelijk om de naam van een vorm in te stellen. Door de vormnaam te gebruiken, kun je later de vorm benaderen om deze te wijzigen of te verwijderen. Om de naam van de watermerk‑vorm in te stellen, wijs je deze toe via de methode [**AutoShape.getName**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#getName--) :

```javascript
watermarkShape.setName("watermark");
```

### **Watermerk verwijderen**
Om de watermerk‑vorm te verwijderen, gebruik je de methode [AutoShape.getName](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#getName--) om deze te vinden in de dia‑vormen. Vervolgens geef je de watermerk‑vorm door aan de methode [**ShapeCollection.remove**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-) :

```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **FAQ**

**Wat is een watermerk en waarom zou ik het gebruiken?**  
Een watermerk is een tekst‑ of afbeeldingsoverlay die op dia's wordt aangebracht en helpt intellectueel eigendom te beschermen, de merkherkenning te vergroten of ongeoorloofd gebruik van presentaties te voorkomen.

**Kan ik een watermerk aan alle dia's van een presentatie toevoegen?**  
Ja, Aspose.Slides stelt je in staat een watermerk toe te voegen aan elke dia van een presentatie. Je kunt door alle dia's itereren en de watermerk‑instellingen afzonderlijk toepassen.

**Hoe kan ik de transparantie van het watermerk aanpassen?**  
Je kunt de transparantie van het watermerk aanpassen door de [vulinstellingen](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/getfillformat/) van de vorm te wijzigen. Zo blijft het watermerk subtiel en stoort het de inhoud van de dia niet.

**Welke afbeeldingsformaten worden ondersteund voor watermerken?**  
Aspose.Slides ondersteunt verschillende afbeeldingsformaten, zoals PNG, JPEG, GIF, BMP, SVG en meer.

**Kan ik het lettertype en de stijl van een tekstwatermerk aanpassen?**  
Ja, je kunt elk lettertype, grootte en stijl kiezen die passen bij het ontwerp van je presentatie en de merkrichtlijnen behouden.

**Hoe wijzig ik de positie of oriëntatie van een watermerk?**  
Je kunt de positie en oriëntatie van het watermerk aanpassen door de coördinaten, grootte en rotatie‑eigenschappen van de vorm te wijzigen.