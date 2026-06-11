---
title: "Hantera SmartArt-formnoder i presentationer på Android"
linktitle: "SmartArt-formnod"
type: docs
weight: 30
url: /sv/androidjava/manage-smartart-shape-node/
keywords:
- "SmartArt-nod"
- "underordnad nod"
- "lägga till nod"
- "nodposition"
- "åtkomst till nod"
- "ta bort nod"
- "anpassad position"
- "assistentnod"
- "fyllningsformat"
- "rendera nod"
- "PowerPoint"
- "presentation"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Hantera SmartArt-formnoder i PPT och PPTX med Aspose.Slides för Android. Få tydliga Java-kodexempel och tips för att effektivisera dina presentationer."
---
## **Översikt**

SmartArt‑grafik i PowerPoint‑presentationer organiseras via noder som innehåller text och definierar diagrammets struktur. Aspose.Slides låter dig arbeta med dessa SmartArt‑noder programatiskt: lägga till nya noder och undernoder, infoga undernoder på en specifik position, komma åt befintliga noder och läsa deras text, nivå och position.

Denna artikel förklarar hur du hanterar SmartArt‑formnodernas noder. Den visar hur du tar bort noder, arbetar med undernoder per index eller position, ändrar en assistentnod till en normal nod, justerar position, storlek och rotation för SmartArt‑nodformar, anger fyllningsformat för noder och genererar en miniatyrbild för en SmartArt‑under‑nod.

## **Lägg till en SmartArt‑nod**
Aspose.Slides for Android via Java har tillhandahållit det enklaste API‑et för att hantera SmartArt‑former på ett enkelt sätt. Följande exempel kod hjälper dig att lägga till nod och undernod i en SmartArt‑form.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)‑klassen och läs in presentationen med SmartArt‑Shape.
1. Hämta referensen till den första bilden genom att använda dess index.
1. Gå igenom varje form i den första bilden.
1. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArt) och typkonvertera den valda formen till [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArt) om den är SmartArt.
1. [Lägg till en ny nod](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) i SmartArt‑formen [**NodeCollection**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) och ange texten i TextFrame.
1. Nu, [Lägg till](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) en [**Child Node**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) i den nylagda [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArt)‑noden och ange texten i TextFrame.
1. Spara presentationen.

```java
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
    
            // Lägger till en ny undernod i föräldranoden. Den kommer att läggas till i slutet av samlingen
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
I följande exempel kod har vi förklarat hur du lägger till undernoder som tillhör respektive noder i SmartArt‑formen på en viss position.

1. Skapa en instans av Presentation‑klassen.
1. Hämta referensen till den första bilden genom att använda dess index.
1. Lägg till en [**StackedList**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList)‑typ [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArt)‑form i den åtkomna bilden.
1. Kom åt den första noden i den tillagda SmartArt‑formen.
1. Nu, lägg till [**Child Node**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) för den valda [**Node**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArtNode) på position 2 och ange dess text.
1. Spara presentationen.

```java
// Skapar en presentationinstans
Presentation pres = new Presentation();
try {
    // Hämta presentationsbilden
    ISlide slide = pres.getSlides().get_Item(0);

    // Lägg till Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Kom åt SmartArt-noden med index 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Lägger till en ny undernod på position 2 i föräldranoden
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Lägg till text
    chNode.getTextFrame().setText("Sample Text Added");

    // Spara presentationen
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kom åt en SmartArt‑nod**
Följande exempel kod hjälper dig att komma åt noder i SmartArt‑formen. Observera att du inte kan ändra LayoutType för SmartArt eftersom den är skrivskyddad och endast sätts när SmartArt‑formen läggs till.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation)‑klassen och läs in presentationen med SmartArt‑Shape.
1. Hämta referensen till den första bilden genom att använda dess index.
1. Gå igenom varje form i den första bilden.
1. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArt) och typkonvertera den valda formen till [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArt) om den är SmartArt.
1. Gå igenom alla [**Nodes**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArt#getAllNodes--) i SmartArt‑formen.
1. Kom åt och visa information såsom SmartArt‑nodens position, nivå och text.

```java
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
                // Kom åt SmartArt-nod med index i
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

## **Kom åt en SmartArt‑under‑nod**
Följande exempel kod hjälper dig att komma åt undernoder som tillhör respektive noder i SmartArt‑formen.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation)‑klassen och läs in presentationen med SmartArt‑Shape.
1. Hämta referensen till den första bilden genom att använda dess index.
1. Gå igenom varje form i den första bilden.
1. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArt) och typkonvertera den valda formen till [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArt) om den är SmartArt.
1. Gå igenom alla [**Nodes**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArt#getAllNodes--) i SmartArt‑formen.
1. För varje vald SmartArt‑form [**Node**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArtNode) gå igenom alla [**Child Nodes**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) i den specifika noden.
1. Kom åt och visa information såsom [**Child Node**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--)s position, nivå och text.

```java
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
                // Kom åt SmartArt-nod med index i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Går igenom undernoderna i SmartArt-noden med index i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Kom åt undernoden i SmartArt-noden
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Skriver ut parametrarna för SmartArt-undernod
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kom åt en SmartArt‑under‑nod på en specifik position**
I detta exempel lär vi oss att komma åt undernoder på en viss position som tillhör respektive noder i SmartArt‑formen.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation)‑klassen.
1. Hämta referensen till den första bilden genom att använda dess index.
1. Lägg till en [**StackedList**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList)‑typ SmartArt‑form.
1. Kom åt den tillagda SmartArt‑formen.
1. Kom åt noden med index 0 för den åtkomna SmartArt‑formen.
1. Nu, kom åt [**Child Node**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) på position 1 för den åtkomna SmartArt‑noden med metoden **get_Item()**.
1. Kom åt och visa information såsom [**Child Node**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--)s position, nivå och text.

```java
// Instansiera presentationen
Presentation pres = new Presentation();
try {
    // Hämtar första bilden
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Lägger till SmartArt-formen i första bilden
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Kom åt SmartArt-nod med index 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Kom åt undernoden på position 1 i föräldranoden
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Skriver ut parametrarna för SmartArt-undernoden
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ta bort en SmartArt‑nod**
I detta exempel lär vi oss att ta bort noder i SmartArt‑formen.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation)‑klassen och läs in presentationen med SmartArt‑Shape.
1. Hämta referensen till den första bilden genom att använda dess index.
1. Gå igenom varje form i den första bilden.
1. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArt) och typkonvertera den valda formen till [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArt) om den är SmartArt.
1. Kontrollera om [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArt) har fler än 0 noder.
1. Välj den SmartArt‑nod som ska tas bort.
1. Nu, ta bort den valda noden med metoden [**RemoveNode**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) .
1. Spara presentationen.

```java
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
                // Kom åt SmartArt-nod med index 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
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
I detta exempel lär vi oss att ta bort noder i SmartArt‑formen på en viss position.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation)‑klassen och läs in presentationen med SmartArt‑Shape.
1. Hämta referensen till den första bilden genom att använda dess index.
1. Gå igenom varje form i den första bilden.
1. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArt) och typkonvertera den valda formen till [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArt) om den är SmartArt.
1. Välj SmartArt‑formens nod med index 0.
1. Nu, kontrollera om den valda SmartArt‑noden har fler än 2 undernoder.
1. Nu, ta bort noden på **Position 1** med metoden [**RemoveNode**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) .
1. Spara presentationen.

```java
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
                // Kom åt SmartArt-nod med index 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Tar bort undernoden på position 1
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

## **Ställ in en anpassad position för en under‑nod i ett SmartArt‑objekt**
Aspose.Slides for Android via Java stöder nu att ange [SmartArtShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArtShape)‑egenskaperna [X](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShape#setX-float-) och [Y](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShape#setY-float-). Kodsnutten nedan visar hur du anger en anpassad position, storlek och rotation för SmartArt‑Shape; observera att tillägg av nya noder orsakar en omräkning av alla noders positioner och storlekar. Med anpassade positionsinställningar kan användaren placera noderna enligt sina krav.

```java
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
{{% alert color="primary" %}} 

I den här artikeln undersöker vi ytterligare funktioner hos SmartArt‑former som lagts till i presentationsbilder programatiskt med Aspose.Slides for Android via Java.

{{% /alert %}} 

Vi använder följande käll‑SmartArt‑form för vår undersökning i de olika avsnitten av artikeln.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figur: Käll‑SmartArt‑figur i bilden**|

I följande exempel kod undersöker vi hur man identifierar **Assistant Nodes** i SmartArt‑nodsamlingen och ändrar dem.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation)‑klassen och läs in presentationen med SmartArt‑Shape.
1. Hämta referensen till den andra bilden genom att använda dess index.
1. Gå igenom varje form i den första bilden.
1. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArt) och typkonvertera den valda formen till [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArt) om den är SmartArt.
1. Gå igenom alla noder i SmartArt‑formen och kontrollera om de är [**Assistant Nodes**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArtNode#isAssistant--).
1. Ändra statusen för assistentnoden till en normal nod.
1. Spara presentationen.

```java
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
                    // Sätter assistentnod till falskt och gör den till en normal nod
                    node.isAssistant();
                }
            }
        }
    }
    
    // Spara presentationen
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figur: Assistentsnoder ändrade i SmartArt‑formen i bilden**|

## **Ställ in en nods fyllningsformat**
Aspose.Slides for Android via Java möjliggör att lägga till anpassade SmartArt‑former och ange deras fyllningsformat. Denna artikel förklarar hur du skapar och får åtkomst till SmartArt‑former samt anger deras fyllningsformat med Aspose.Slides for Android via Java.

Följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation)‑klassen.
1. Hämta referensen till en bild med dess index.
1. Lägg till en [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArt)‑form genom att ange dess [**LayoutType**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Ange [**FillFormat**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShape#getFillFormat--) för SmartArt‑formens noder.
1. Skriv den modifierade presentationen som en PPTX‑fil.

```java
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
    
    // Sparar presentationen
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Generera en miniatyr av en SmartArt‑under‑nod**
Utvecklare kan generera en miniatyr av en under‑nod i en SmartArt genom att följa stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation)‑klassen.
1. [Lägg till SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).
1. Hämta referensen till en nod med dess index.
1. Hämta miniatyrbilden.
1. Spara miniatyrbilden i önskat bildformat.

```java
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

**Stöds SmartArt‑animation?**

Ja. SmartArt behandlas som en vanlig form, så du kan [tillämpa standardanimationer](/slides/sv/androidjava/shape-animation/) (ingång, avslutning, betoning, rörelsebanor) och justera tidpunkten. Du kan även animera former innanför SmartArt‑noder vid behov.

**Hur kan jag på ett pålitligt sätt lokalisera en specifik SmartArt på en bild om dess interna ID är okänt?**

Tilldela och sök efter [alternativ text](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#getAlternativeText--). Genom att sätta en distinkt AltText på SmartArt kan du hitta den programatiskt utan att förlita dig på interna identifierare.

**Behåller SmartArt‑utseendet sin form när presentationen konverteras till PDF?**

Ja. Aspose.Slides renderar SmartArt med hög visuell trohet vid [PDF‑export](/slides/sv/androidjava/convert-powerpoint-to-pdf/), vilket bevarar layout, färger och effekter.

**Kan jag extrahera en bild av hela SmartArt (för förhandsvisningar eller rapporter)?**

Ja. Du kan rendera en SmartArt‑form till [rastformat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) eller till [SVG](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) för skalbar vektoroutput, vilket gör den lämplig för miniatyrer, rapporter eller webb.