---
title: Hantera SmartArt-formnoder i presentationer med JavaScript
linktitle: SmartArt-formnod
type: docs
weight: 30
url: /sv/nodejs-java/manage-smartart-shape-node/
keywords:
- SmartArt-nod
- underordnad nod
- lägga till nod
- nodposition
- åtkomst till nod
- ta bort nod
- anpassad position
- assistentnod
- fyllningsformat
- rendera nod
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Hantera SmartArt-formnoder i PPT och PPTX med Aspose.Slides för Node.js. Få tydliga JavaScript-kodexempel och tips för att effektivisera dina presentationer."
---
## **Översikt**

SmartArt-grafik i PowerPoint-presentationer organiseras genom noder som innehåller text och definierar diagrammets struktur. Aspose.Slides låter dig arbeta med dessa SmartArt‑noder programatiskt: lägga till nya noder och underordnade noder, infoga underordnade noder på en specifik position, komma åt befintliga noder och läsa deras text, nivå och position.

Den här artikeln förklarar hur du hanterar SmartArt‑formnodern. Den visar hur du tar bort noder, arbetar med underordnade noder efter index eller position, ändrar en assistentnod till en normal nod, justerar position, storlek och rotation för SmartArt‑nodformer, anger nodens fyllningsformat och genererar en miniatyrbild för en SmartArt‑underordnad nod.

## **Lägg till SmartArt-nod i PowerPoint-presentation med JavaScript**
Aspose.Slides för Node.js via Java har tillhandahållit det enklaste API‑et för att hantera SmartArt‑former på det enklaste sättet. Följande exempelprogramkod hjälper dig att lägga till nod och underordnad nod i en SmartArt‑form.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) och läs in presentationen med SmartArt‑form.
2. Hämta referensen till den första bilden genom att använda dess index.
3. Iterera genom varje form på den första bilden.
4. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArt) och kasta den valda formen till [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArt) om den är SmartArt.
5. [Lägg till en ny nod](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) i SmartArt‑formen [**NodeCollection**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArt#getAllNodes--) och ange texten i TextFrame.
6. Nu, [lägg till](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) en [**underordnad nod**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) i den nyligen tillagda [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArt)‑noden och ange texten i TextFrame.
7. Spara presentationen.

```javascript
// Laddar den önskade presentationen
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Iterera genom varje form i den första bilden
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Kontrollera om formen är av typen SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Typkasta formen till SmartArt
            var smart = shape;
            // Lägger till en ny SmartArt-nod
            var TemNode = smart.getAllNodes().addNode();
            // Lägger till text
            TemNode.getTextFrame().setText("Test");
            // Lägger till en ny underordnad nod i föräldranoden. Den kommer att läggas till i slutet av samlingen
            var newNode = TemNode.getChildNodes().addNode();
            // Lägger till text
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // Sparar presentationen
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lägg till SmartArt-nod på specifik position**
I följande exempelprogramkod har vi förklarat hur man lägger till underordnade noder som tillhör respektive noder i SmartArt‑formen på en viss position.

1. Skapa en instans av klassen Presentation.
2. Hämta referensen till den första bilden genom att använda dess index.
3. Lägg till en [**StackedList**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) typ [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArt)‑form i den åtkomna bilden.
4. Åtkomst till den första noden i den tillagda SmartArt‑formen.
5. Nu, lägg till den [**underordnade noden**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) för den valda [**noden**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArtNode) på position 2 och ange dess text.
6. Spara presentationen.

```javascript
// Skapar en presentationsinstans
var pres = new aspose.slides.Presentation();
try {
    // Åtkomst till presentationsbilden
    var slide = pres.getSlides().get_Item(0);
    // Lägg till Smart Art IShape
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Åtkomst till SmartArt-noden på index 0
    var node = smart.getAllNodes().get_Item(0);
    // Lägger till ny underordnad nod på position 2 i föräldranoden
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // Lägg till text
    chNode.getTextFrame().setText("Sample Text Added");
    // Spara presentationen
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Åtkomst till SmartArt-nod i PowerPoint-presentation med JavaScript**
Följande exempelprogramkod hjälper dig att komma åt noder i SmartArt‑formen. Observera att du inte kan ändra LayoutType för SmartArt eftersom den är skrivskyddad och endast sätts när SmartArt‑formen läggs till.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation) och läs in presentationen med SmartArt‑form.
2. Hämta referensen till den första bilden genom att använda dess index.
3. Iterera genom varje form på den första bilden.
4. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArt) och kasta den valda formen till [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArt) om den är SmartArt.
5. Iterera genom alla [**noder**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArt#getAllNodes--) i SmartArt‑formen.
6. Kom åt och visa information såsom SmartArt‑nodens position, nivå och text.

```javascript
// Instansiera presentationsklassen
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // Hämta första bilden
    var slide = pres.getSlides().get_Item(0);
    // Gå igenom varje form i den första bilden
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Kontrollera om formen är av typen SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Typkasta formen till SmartArt
            var smart = shape;
            // Gå igenom alla noder i SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // Tillgång till SmartArt-nod på index i
                var node = smart.getAllNodes().get_Item(j);
                // Skriver ut SmartArt-nodens parametrar
                console.log(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Åtkomst till SmartArt underordnad nod**
Följande exempelprogramkod hjälper dig att komma åt de underordnade noder som tillhör respektive noder i SmartArt‑formen.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation) och läs in presentationen med SmartArt‑form.
2. Hämta referensen till den första bilden genom att använda dess index.
3. Iterera genom varje form på den första bilden.
4. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArt) och kasta den valda formen till [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArt) om den är SmartArt.
5. Iterera genom alla [**noder**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArt#getAllNodes--) i SmartArt‑formen.
6. För varje vald SmartArt‑form [**nod**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArtNode), iterera genom alla [**underordnade noder**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) i den specifika noden.
7. Kom åt och visa information såsom [**underordnad nod**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) position, nivå och text.

```javascript
// Instansiera presentationsklass
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // Hämta första bilden
    var slide = pres.getSlides().get_Item(0);
    // Gå igenom varje form i den första bilden
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // Kontrollera om formen är av typen SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Typkasta formen till SmartArt
            var smart = shape;
            // Gå igenom alla noder i SmartArt
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // Åtkomst till SmartArt-nod på index i
                var node0 = smart.getAllNodes().get_Item(i);
                // Gå igenom de underordnade noderna i SmartArt-nod på index i
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // Åtkomst till underordnad nod i SmartArt-nod
                    var node = node0.getChildNodes().get_Item(j);
                    // Skriver ut SmartArt underordnad nods parametrar
                    console.log("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Åtkomst till SmartArt underordnad nod på specifik position**
I detta exempel kommer vi att lära oss att komma åt de underordnade noderna på en viss position som tillhör respektive noder i SmartArt‑formen.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
2. Hämta referensen till den första bilden genom att använda dess index.
3. Lägg till en [**StackedList**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) typ SmartArt‑form.
4. Åtkomst till den tillagda SmartArt‑formen.
5. Kom åt noden på index 0 för den åtkomna SmartArt‑formen.
6. Nu, kom åt den [**underordnade noden**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) på position 1 för den åtkomna SmartArt‑noden med metoden **get_Item()**.
7. Kom åt och Visa information såsom [**underordnad nod**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) position, nivå och text.

```javascript
// Instansiera presentationen
var pres = new aspose.slides.Presentation();
try {
    // Åtkomst till den första bilden
    var slide = pres.getSlides().get_Item(0);
    // Lägger till SmartArt-formen i första bilden
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Åtkomst till SmartArt-noden på index 0
    var node = smart.getAllNodes().get_Item(0);
    // Åtkomst till den underordnade noden på position 1 i föräldranoden
    var position = 1;
    var chNode = node.getChildNodes().get_Item(position);
    // Skriver ut SmartArt underordnad nods parametrar
    console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ta bort SmartArt-nod i PowerPoint-presentation med JavaScript**
I detta exempel kommer vi att lära oss att ta bort noderna i SmartArt‑formen.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation) och läs in presentationen med SmartArt‑form.
2. Hämta referensen till den första bilden genom att använda dess index.
3. Iterera genom varje form på den första bilden.
4. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArt) och kasta den valda formen till [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArt) om den är SmartArt.
5. Kontrollera om [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArt) har fler än 0 noder.
6. Välj den SmartArt‑nod som ska tas bort.
7. Nu, ta bort den valda noden med metoden [**RemoveNode**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-).
8. Spara presentationen.

```javascript
// Ladda den önskade presentationen
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Iterera genom varje form i den första bilden
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Kontrollera om formen är av typen SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Typkasta formen till SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Åtkomst till SmartArt-nod på index 0
                var node = smart.getAllNodes().get_Item(0);
                // Tar bort den valda noden
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // Spara presentationen
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ta bort SmartArt-nod på specifik position**
I detta exempel kommer vi att lära oss att ta bort noderna i SmartArt‑formen på en viss position.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation) och läs in presentationen med SmartArt‑form.
2. Hämta referensen till den första bilden genom att använda dess index.
3. Iterera genom varje form på den första bilden.
4. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArt) och kasta den valda formen till [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArt) om den är SmartArt.
5. Välj SmartArt‑formens nod på index 0.
6. Nu, kontrollera om den valda SmartArt‑noden har fler än 2 underordnade noder.
7. Nu, ta bort noden på **position 1** med metoden [**RemoveNode**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-).
8. Spara presentationen.

```javascript
// Ladda den önskade presentationen
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Iterera genom varje form i den första bilden
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Kontrollera om formen är av typen SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Typkasta formen till SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Åtkomst till SmartArt-nod på index 0
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // Tar bort den underordnade noden på position 1
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // Spara presentationen
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ange anpassad position för underordnad nod i SmartArt**
Nu stöder Aspose.Slides för Node.js via Java att ange [SmartArtShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArtShape) egenskaperna [X](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#setX-float-) och [Y](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#setY-float-). Kodsnutten nedan visar hur man anger anpassad position, storlek och rotation för SmartArtShape; observera också att tillägg av nya noder orsakar en omräkning av positioner och storlekar för alla noder. Med anpassade positionsinställningar kan användaren också sätta noderna enligt krav.

```javascript
// Instansiera presentationsklass
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // Flytta SmartArt-formen till ny position
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // Ändra SmartArt-formens bredd
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // Ändra SmartArt-formens höjd
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // Ändra SmartArt-formens rotation
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Kontrollera assistentnod**
{{% alert color="primary" %}} 
I den här artikeln kommer vi att vidare undersöka funktioner i SmartArt‑former som lagts till i presentationsbilder programatiskt med Aspose.Slides för Node.js via Java.
{{% /alert %}} 

Vi kommer att använda följande käll‑SmartArt‑form för vår undersökning i olika avsnitt av denna artikel.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figur: Käll‑SmartArt‑form i bilden**|

I följande exempelprogramkod kommer vi att undersöka hur man identifierar **assistentnoder** i SmartArt‑nodsamlingen och ändrar dem.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation) och läs in presentationen med SmartArt‑form.
2. Hämta referensen till den andra bilden genom att använda dess index.
3. Iterera genom varje form på den första bilden.
4. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArt) och kasta den valda formen till [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArt) om den är SmartArt.
5. Iterera genom alla noder i SmartArt‑formen och kontrollera om de är [**assistentnoder**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArtNode#isAssistant--) .
6. Ändra statusen för assistentnod till en normal nod.
7. Spara presentationen.

```javascript
// Skapar en presentationsinstans
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // Traversera genom varje form i den första bilden
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Kontrollera om formen är av typen SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Typkasta formen till SmartArt
            var smart = shape;
            // Traversera genom alla noder i SmartArt-formen
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // Kontrollera om noden är en assistentnod
                if (node.isAssistant()) {
                    // Sätter assistentnod till false och gör den till en normal nod
                    node.isAssistant();
                }
            }
        }
    }
    // Spara presentationen
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figur: Assistentnoder ändrade i SmartArt‑form i bilden**|

## **Ange nodens fyllningsformat**
Aspose.Slides för Node.js via Java gör det möjligt att lägga till anpassade SmartArt‑former och ange deras fyllningsformat. Denna artikel förklarar hur man skapar och får åtkomst till SmartArt‑former samt anger deras fyllningsformat med Aspose.Slides för Node.js via Java.

Vänligen följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
2. Hämta referensen till en bild med dess index.
3. Lägg till en [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArt)‑form genom att ange dess [**LayoutType**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
4. Ange [**FillFormat**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#getFillFormat--) för SmartArt‑formens noder.
5. Skriv den modifierade presentationen som en PPTX‑fil.

```javascript
// Instansiera presentationen
var pres = new aspose.slides.Presentation();
try {
    // Åtkomst till bilden
    var slide = pres.getSlides().get_Item(0);
    // Lägger till SmartArt-form och noder
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // Anger nodens fyllningsfärg
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // Spara presentationen
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Generera miniatyrbild av SmartArt underordnad nod**
Utvecklare kan generera en miniatyrbild av en underordnad nod i en SmartArt genom att följa stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
2. [Lägg till SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--).
3. Hämta referensen till en nod genom att använda dess index.
4. Hämta miniatyrbilden.
5. Spara miniatyrbilden i önskat bildformat.

```javascript
// Instansiera Presentation-klass som representerar PPTX-filen
var pres = new aspose.slides.Presentation();
try {
    // Lägg till SmartArt
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // Hämta referensen till en nod genom att använda dess index
    var node = smart.getNodes().get_Item(1);
    // Hämta miniatyrbild
    var slideImage = node.getShapes().get_Item(0).getImage();
    // Spara miniatyrbild
    try {
        slideImage.save("SmartArt_ChildNote_Thumbnail.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Stöds SmartArt‑animation?**

Ja. SmartArt behandlas som en vanlig form, så du kan [tillämpa standardanimationer](/slides/sv/nodejs-java/shape-animation/) (ingång, utgång, betoning, rörelsespår) och justera tidpunkter. Du kan också animera former inuti SmartArt‑noder när det behövs.

**Hur kan jag på ett pålitligt sätt lokalisera en specifik SmartArt på en bild om dess interna ID är okänt?**

Tilldela och sök efter [alternativ text](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/getalternativetext/). Genom att sätta en tydlig AltText på SmartArt kan du hitta den utan att förlita dig på interna identifierare.

**Kommer SmartArt‑utseendet att bevaras vid konvertering av presentationen till PDF?**

Ja. Aspose.Slides renderar SmartArt med hög visuell noggrannhet under [PDF‑export](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/), vilket bevarar layout, färger och effekter.

**Kan jag extrahera en bild av hela SmartArt (för förhandsvisningar eller rapporter)?**

Ja. Du kan rendera en SmartArt‑form till [rasterformat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#getImage) eller till [SVG](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/writeassvg/) för skalbar vektorutmatning, vilket gör den lämplig för miniatyrbilder, rapporter eller webbbruk.