---
title: Hantera SmartArt-formnoder i presentationer med Java
linktitle: SmartArt-formnod
type: docs
weight: 30
url: /sv/java/manage-smartart-shape-node/
keywords:
- SmartArt-nod
- barnnod
- lägg till nod
- nodposition
- åtkomstnod
- ta bort nod
- anpassad position
- assistentnod
- fyllningsformat
- rendera nod
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Hantera SmartArt-formnoder i PPT och PPTX med Aspose.Slides för Java. Få tydliga kodexempel och tips för att effektivisera dina presentationer."
---
## **Översikt**

SmartArt‑grafik i PowerPoint‑presentationer organiseras via noder som innehåller text och definierar diagrammets struktur. Aspose.Slides låter dig arbeta med dessa SmartArt‑noder programmässigt: lägga till nya noder och barnnoder, infoga barnnoder på en specifik position, komma åt befintliga noder och läsa deras text, nivå och position.

Denna artikel förklarar hur du hanterar SmartArt‑formnoder. Den visar hur du tar bort noder, arbetar med barnnoder efter index eller position, ändrar en assistentnod till en normal nod, justerar position, storlek och rotation för SmartArt‑nodformer, sätter noders fyllningsformat och genererar en miniatyrbild för en SmartArt‑barnnod.

## **Lägg till en SmartArt‑nod**
Aspose.Slides för Java har tillhandahållit det enklaste API‑et för att hantera SmartArt‑former på det enklaste sättet. Följande exempelprogramkod hjälper dig att lägga till en nod och en barnnod i en SmartArt‑form.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) och läs in presentationen med SmartArt‑form.
2. Hämta referensen till den första bilden genom att använda dess index.
3. Gå igenom varje form på den första bilden.
4. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArt) och typkonvertera den valda formen till [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArt) om den är SmartArt.
5. [Lägg till en ny nod](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) i SmartArt‑formen [**NodeCollection**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArt#getAllNodes--) och sätt texten i TextFrame.
6. Nu, [lägg till](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) en [**Child Node**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArtNode#getChildNodes--) i den nylagda [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArt)‑noden och sätt texten i TextFrame.
7. Spara presentationen.

```java
import com.aspose.slides.*;

// Läs in den önskade presentationen
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Gå igenom varje form i den första bilden
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Kontrollera om formen är av typen SmartArt
        if (shape instanceof SmartArt) 
        {
            // Typkonvertera formen till SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Lägger till en ny SmartArt-nod
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Lägger till text
            TemNode.getTextFrame().setText("Test");
    
            // Lägger till en ny barnnod i föräldranoden. Den kommer att läggas till i slutet av samlingen
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Lägger till text
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // Sparar presentationen
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lägg till en SmartArt‑nod på en specifik position**
I följande exempelprogramkod har vi förklarat hur du lägger till barnnoder som tillhör respektive noder i SmartArt‑formen på en viss position.

1. Skapa en instans av Presentation‑klassen.
2. Hämta referensen till den första bilden genom att använda dess index.
3. Lägg till en [**StackedList**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArtLayoutType#StackedList)‑typ av [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArt)‑form i den åtkomna bilden.
4. Åtkomst till den första noden i den tillagda SmartArt‑formen.
5. Nu, lägg till [**Child Node**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArtNode#getChildNodes--) för den valda [**Node**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArtNode) på position 2 och sätt dess text.
6. Spara presentationen.

```java
import com.aspose.slides.*;

// Skapar en presentationinstans
Presentation pres = new Presentation();
try {
    // Hämta presentationsbilden
    ISlide slide = pres.getSlides().get_Item(0);

    // Lägg till SmartArt IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Hämtar SmartArt-noden med index 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Lägger till en ny barnnod på position 2 i föräldranoden
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Lägg till text
    chNode.getTextFrame().setText("Sample Text Added");

    // Spara presentation
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Åtkomst till en SmartArt‑nod**
Följande exempelprogramkod hjälper dig att komma åt noder i en SmartArt‑form. Observera att du inte kan ändra LayoutType för SmartArt eftersom den är skrivskyddad och endast sätts när SmartArt‑formen läggs till.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation) och läs in presentationen med SmartArt‑form.
2. Hämta referensen till den första bilden genom att använda dess index.
3. Gå igenom varje form på den första bilden.
4. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArt) och typkonvertera den valda formen till [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArt) om den är SmartArt.
5. Gå igenom alla [**Nodes**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArt#getAllNodes--) i SmartArt‑formen.
6. Kom åt och visa information såsom SmartArt‑nodens position, nivå och text.

```java
import com.aspose.slides.*;

// Instansiera Presentation-klass
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Hämta första bilden
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Gå igenom varje form i den första bilden
    for (IShape shape : slide.getShapes()) 
    {
        // Kontrollera om formen är av typen SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Typkonvertera formen till SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Gå igenom alla noder i SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Kom åt SmartArt-nod på index i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // Skriver ut SmartArt-nodens parametrar
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Åtkomst till en SmartArt‑barnnod**
Följande exempelprogramkod hjälper dig att komma åt barnnoder som tillhör respektive noder i SmartArt‑formen.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation) och läs in presentationen med SmartArt‑form.
2. Hämta referensen till den första bilden genom att använda dess index.
3. Gå igenom varje form på den första bilden.
4. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArt) och typkonvertera den valda formen till [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArt) om den är SmartArt.
5. Gå igenom alla [**Nodes**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArt#getAllNodes--) i SmartArt‑formen.
6. För varje vald SmartArt‑form [**Node**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArtNode), gå igenom alla [**Child Nodes**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArtNode#getChildNodes--) i den specifika noden.
7. Kom åt och visa information såsom [**Child Node**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArtNode#getChildNodes--) position, nivå och text.

```java
import com.aspose.slides.*;

// Instansiera Presentation-klass
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Hämta första bilden
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Gå igenom varje form i den första bilden
    for (IShape shape : slide.getShapes()) 
    {
        // Kontrollera om formen är av typen SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Typkonvertera formen till SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Gå igenom alla noder i SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Kom åt SmartArt-nod på index i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Går igenom barnnoderna i SmartArt-nod på index i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Kom åt barnnoden i SmartArt-nod
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Skriver ut SmartArt-barnnodens parametrar
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Åtkomst till en SmartArt‑barnnod på en specifik position**
I det här exemplet kommer vi att lära oss att komma åt barnnoder på en viss position som tillhör respektive noder i SmartArt‑formen.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation) .
2. Hämta referensen till den första bilden genom att använda dess index.
3. Lägg till en [**StackedList**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArtLayoutType#StackedList)‑typ av SmartArt‑form.
4. Kom åt den tillagda SmartArt‑formen.
5. Kom åt noden med index 0 för den åtkomna SmartArt‑formen.
6. Nu, kom åt [**Child Node**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArtNode#getChildNodes--) på position 1 för den åtkomna SmartArt‑noden med hjälp av metoden **get_Item()**.
7. Kom åt och visa information såsom [**Child Node**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArtNode#getChildNodes--) position, nivå och text.

```java
import com.aspose.slides.*;

// Instansiera presentationen
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Lägger till SmartArt-formen i första bilden
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Kom åt SmartArt-noden på index 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Kom åt barnnoden på position 1 i föräldranoden
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Skriver ut SmartArt-barnnodens parametrar
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ta bort en SmartArt‑nod**
I det här exemplet kommer vi att lära oss att ta bort noder i SmartArt‑formen.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation) och läs in presentationen med SmartArt‑form.
2. Hämta referensen till den första bilden genom att använda dess index.
3. Gå igenom varje form på den första bilden.
4. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArt) och typkonvertera den valda formen till [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArt) om den är SmartArt.
5. Kontrollera om [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArt) har mer än 0 noder.
6. Välj den SmartArt‑nod som ska raderas.
7. Nu, ta bort den valda noden med metoden [**RemoveNode**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) .
8. Spara presentationen.

```java
import com.aspose.slides.*;

// Läs in den önskade presentationen
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Gå igenom varje form i den första bilden
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Kontrollera om formen är av typen SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Typkonvertera formen till SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Kom åt SmartArt-nod på index 0
                ISSmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Tar bort den valda noden
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // Spara presentationen
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ta bort en SmartArt‑nod från en specifik position**
I det här exemplet kommer vi att lära oss att ta bort noder i SmartArt‑formen på en viss position.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation) och läs in presentationen med SmartArt‑form.
2. Hämta referensen till den första bilden genom att använda dess index.
3. Gå igenom varje form på den första bilden.
4. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArt) och typkonvertera den valda formen till [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArt) om den är SmartArt.
5. Välj SmartArt‑formens nod med index 0.
6. Kontrollera nu om den valda SmartArt‑noden har fler än 2 barnnoder.
7. Ta nu bort noden på **Position 1** med metoden [**RemoveNode**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) .
8. Spara presentationen.

```java
import com.aspose.slides.*;

// Läs in den önskade presentationen
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Gå igenom varje form i den första bilden
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Kontrollera om formen är av typen SmartArt
        if (shape instanceof SmartArt) 
        {
            // Typkonvertera formen till SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Kom åt SmartArt-nod på index 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Tar bort barnnoden på position 1
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // Spara presentationen
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ange en anpassad position för en barnnod i ett SmartArt‑objekt**
Nu stöder Aspose.Slides för Java att ange [SmartArtShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArtShape)s [X](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShape#setX-float-)‑ och [Y](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShape#setY-float-)‑egenskaper. Kodsnutten nedan visar hur du anger en anpassad position, storlek och rotation för SmartArtShape. Observera också att tillägg av nya noder orsakar en omberäkning av alla noders positioner och storlekar. Med anpassade positionsinställningar kan användaren placera noderna enligt krav.

```java
import com.aspose.slides.*;

// Instansiera Presentation-klass
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Flytta SmartArt-formen till ny position
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Ändra SmartArt-formens bredd
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Ändra SmartArt-formens höjd
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Ändra SmartArt-formens rotation
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Kontrollera en assistentnod**
{{% alert color="info" %}} 

I den här artikeln kommer vi att undersöka ytterligare funktioner i SmartArt‑former som lagts till i presentationsbilder programmässigt med Aspose.Slides för Java.

{{% /alert %}} 

Vi kommer att använda följande käll‑SmartArt‑form för vår undersökning i olika avsnitt av den här artikeln.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figur: Käll‑SmartArt‑form i bild**|

I följande exempelprogramkod kommer vi att undersöka hur man identifierar **Assistant Nodes** i SmartArt‑nodsamlingen och ändrar dem.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation) och läs in presentationen med SmartArt‑form.
2. Hämta referensen till den andra bilden genom att använda dess index.
3. Gå igenom varje form i den första bilden.
4. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArt) och typkonvertera den valda formen till [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArt) om den är SmartArt.
5. Gå igenom alla noder i SmartArt‑formen och kontrollera om de är [**Assistant Nodes**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArtNode#isAssistant--) .
6. Ändra statusen för Assistant Node till en normal nod.
7. Spara presentationen.

```java
import com.aspose.slides.*;

// Skapar en presentationinstans
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Gå igenom varje form i den första bilden
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Kontrollera om formen är av typen SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Typkonvertera formen till SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Går igenom alla noder i SmartArt-formen
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Kontrollera om noden är en assistentnod
                if (node.isAssistant()) 
                {
                    // Sätter Assistant-nod till false och gör den till en normal nod
                    node.setAssistant(false);
                }
            }
        }
    }
    
    // Spara presentation
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figur: Assistentnoder ändrade i SmartArt‑form i bild**|

## **Ange en nods fyllningsformat**
Aspose.Slides för Java gör det möjligt att lägga till anpassade SmartArt‑former och ange deras fyllningsformat. Denna artikel förklarar hur du skapar och får åtkomst till SmartArt‑former samt anger deras fyllningsformat med Aspose.Slides för Java.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation) .
2. Hämta referensen till en bild med hjälp av dess index.
3. Lägg till en [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArt)‑form genom att ange dess [**LayoutType**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) .
4. Ange [**FillFormat**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShape#getFillFormat--) för SmartArt‑formens noder.
5. Skriv den ändrade presentationen som en PPTX‑fil.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instansiera presentationen
Presentation pres = new Presentation();
try {
    // Hämtar bilden
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Lägger till SmartArt-form och noder
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Sätter nodens fyllningsfärg
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // Spara presentationen
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Generera en miniatyr av en SmartArt‑barnnod**
Utvecklare kan generera en miniatyr av en barnnod i en SmartArt genom att följa stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation) .
2. [Lägg till SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) .
3. Hämta referensen till en nod genom att använda dess index.
4. Hämta miniatyrbilden.
5. Spara miniatyrbilden i önskat bildformat.

```java
import com.aspose.slides.*;

// Instansiera Presentation-klass som representerar PPTX-filen
Presentation pres = new Presentation();
try {
    // Lägg till SmartArt
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Hämta referensen till en nod genom att använda dess index
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Hämta miniatyr
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Spara miniatyr
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Stöds SmartArt‑animation?
Ja. SmartArt behandlas som en vanlig form, så du kan [applicera standardanimationer](/slides/sv/java/shape-animation/) (insläpp, utgång, betoning, rörelsebanor) och justera tidpunkter. Du kan även animera former i SmartArt‑noder vid behov.

### Hur kan jag på ett tillförlitligt sätt hitta en specifik SmartArt på en bild om dess interna ID är okänt?
Tilldela och sök efter [alternativ text](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getAlternativeText--) . Genom att sätta en tydlig AltText på SmartArt kan du hitta den programmässigt utan att förlita dig på interna identifierare.

### Kommer SmartArts utseende att bevaras vid konvertering av presentationen till PDF?
Ja. Aspose.Slides renderar SmartArt med hög visuell trohet vid [PDF‑export](/slides/sv/java/convert-powerpoint-to-pdf/), och bevarar layout, färger och effekter.

### Kan jag extrahera en bild av hela SmartArt (för förhandsgranskning eller rapporter)?
Ja. Du kan rendera en SmartArt‑form till [rasterformat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getImage-int-float-float-) eller till [SVG](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) för skalbar vektorutmatning, vilket gör den lämplig för miniatyrer, rapporter eller webbbruk.