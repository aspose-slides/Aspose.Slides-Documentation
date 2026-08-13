---
title: Beheer SmartArt-vormknooppunten in presentaties met Java
linktitle: SmartArt-vormknooppunt
type: docs
weight: 30
url: /nl/java/manage-smartart-shape-node/
keywords:
- SmartArt-knooppunt
- onderliggend knooppunt
- knooppunt toevoegen
- knooppositie
- knooppunt benaderen
- knooppunt verwijderen
- aangepaste positie
- assistent-knooppunt
- vullingsformaat
- knooppunt renderen
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Beheer SmartArt-vormknooppunten in PPT en PPTX met Aspose.Slides voor Java. Ontvang duidelijke codevoorbeelden en tips om uw presentaties te stroomlijnen."
---
## **Overzicht**

SmartArt‑grafieken in PowerPoint‑presentaties worden georganiseerd via knooppunten die tekst bevatten en de structuur van het diagram bepalen. Aspose.Slides stelt u in staat om programmatically met deze SmartArt‑knooppunten te werken: nieuwe knooppunten en onderliggende knooppunten toevoegen, onderliggende knooppunten op een specifieke positie invoegen, bestaande knooppunten benaderen en hun tekst, niveau en positie lezen.

Dit artikel legt uit hoe u SmartArt‑vormknooppunten beheert. Het toont hoe u knooppunten verwijdert, werkt met onderliggende knooppunten op index of positie, een assistent‑knooppunt verandert in een normaal knooppunt, de positie, grootte en rotatie van SmartArt‑knooppuntvormen aanpast, vullingsformaten instelt en een miniatuurafbeelding genereert voor een SmartArt‑onderliggend knooppunt.

## **Een SmartArt‑knooppunt toevoegen**
Aspose.Slides for Java biedt de eenvoudigste API om de SmartArt‑vormen op de gemakkelijkste manier te beheren. De volgende voorbeeldcode helpt bij het toevoegen van een knooppunt en onderliggend knooppunt binnen een SmartArt‑vorm.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) en laad de presentatie met een SmartArt‑vorm.  
2. Verkrijg de referentie van de eerste dia via de index.  
3. Loop door elke vorm op de eerste dia.  
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) indien het SmartArt betreft.  
5. [Add a new Node](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) in de SmartArt‑vorm **NodeCollection** (https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt#getAllNodes--) en stel de tekst in het TextFrame in.  
6. Voeg nu een **Child Node** (https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArtNode#getChildNodes--) toe aan het zojuist toegevoegde SmartArt‑knooppunt en stel de tekst in het TextFrame in.  
7. Sla de presentatie op.

```java
import com.aspose.slides.*;

// Laad de gewenste presentatie
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Doorloop elke vorm op de eerste dia
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape instanceof SmartArt) 
        {
            // Cast de vorm naar SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Een nieuw SmartArt‑knooppunt toevoegen
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Tekst toevoegen
            TemNode.getTextFrame().setText("Test");
    
            // Een nieuw onderliggend knooppunt toevoegen aan het bovenliggende knooppunt. Het wordt aan het einde van de collectie toegevoegd
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Tekst toevoegen
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // Presentatie opslaan
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een SmartArt‑knooppunt op een specifieke positie toevoegen**
In de onderstaande voorbeeldcode laten we zien hoe u onderliggende knooppunten van respectieve knooppunten van een SmartArt‑vorm op een bepaalde positie toevoegt.

1. Maak een instantie van de klasse Presentation.  
2. Verkrijg de referentie van de eerste dia via de index.  
3. Voeg een SmartArt‑vorm van het type [**StackedList**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArtLayoutType#StackedList) toe aan de geopende dia.  
4. Benader het eerste knooppunt in de toegevoegde SmartArt‑vorm.  
5. Voeg nu de **Child Node** (https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArtNode#getChildNodes--) toe voor het geselecteerde **Node** (https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArtNode) op positie 2 en stel de tekst in.  
6. Sla de presentatie op.

```java
import com.aspose.slides.*;

// Een presentatie‑instantie maken
Presentation pres = new Presentation();
try {
    // Toegang tot de presentatiedia
    ISlide slide = pres.getSlides().get_Item(0);

    // SmartArt‑IShape toevoegen
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Toegang tot het SmartArt‑knooppunt op index 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Nieuwe onderliggend knooppunt toevoegen op positie 2 in het bovenliggende knooppunt
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Tekst toevoegen
    chNode.getTextFrame().setText("Sample Text Added");

    // Presentatie opslaan
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een SmartArt‑knooppunt benaderen**
De volgende voorbeeldcode helpt bij het benaderen van knooppunten in een SmartArt‑vorm. Let op dat u het LayoutType van de SmartArt niet kunt wijzigen omdat deze alleen-lezen is en alleen wordt ingesteld wanneer de SmartArt‑vorm wordt toegevoegd.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) en laad de presentatie met een SmartArt‑vorm.  
2. Verkrijg de referentie van de eerste dia via de index.  
3. Loop door elke vorm op de eerste dia.  
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) indien het SmartArt betreft.  
5. Doorloop alle **Nodes** (https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArt#getAllNodes--) in de SmartArt‑vorm.  
6. Benader en toon informatie zoals de positie, het niveau en de tekst van het SmartArt‑knooppunt.

```java
import com.aspose.slides.*;

// Instantie van Presentation‑klasse maken
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Eerste dia ophalen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Doorloop elke vorm op de eerste dia
    for (IShape shape : slide.getShapes()) 
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape instanceof ISmartArt) 
        {
            // Cast de vorm naar SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Doorloop alle knooppunten binnen SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // SmartArt‑knooppunt op index i benaderen
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // De parameters van het SmartArt‑knooppunt afdrukken
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een onderliggend SmartArt‑knooppunt benaderen**
De onderstaande voorbeeldcode helpt bij het benaderen van de onderliggende knooppunten die behoren tot respectieve knooppunten van een SmartArt‑vorm.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) en laad de presentatie met een SmartArt‑vorm.  
2. Verkrijg de referentie van de eerste dia via de index.  
3. Loop door elke vorm op de eerste dia.  
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) indien het SmartArt betreft.  
5. Doorloop alle **Nodes** (https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArt#getAllNodes--) in de SmartArt‑vorm.  
6. Voor elk geselecteerd SmartArt‑knooppunt (**Node** (https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArtNode)), doorloop alle **Child Nodes** (https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArtNode#getChildNodes--) binnen dat specifieke knooppunt.  
7. Benader en toon informatie zoals de positie, het niveau en de tekst van de **Child Node** (https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
import com.aspose.slides.*;

// Instantie van Presentation‑klasse maken
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Eerste dia ophalen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Doorloop elke vorm op de eerste dia
    for (IShape shape : slide.getShapes()) 
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape instanceof ISmartArt) 
        {
            // Cast de vorm naar SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Doorloop alle knooppunten binnen SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // SmartArt‑knooppunt op index i benaderen
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Doorloop de onderliggende knooppunten in het SmartArt‑knooppunt op index i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Het onderliggende knooppunt in het SmartArt‑knooppunt benaderen
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // De parameters van het SmartArt‑onderliggende knooppunt afdrukken
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een onderliggend SmartArt‑knooppunt op een specifieke positie benaderen**
In dit voorbeeld leren we hoe we onderliggende knooppunten op een bepaalde positie, die behoren tot respectieve knooppunten van een SmartArt‑vorm, benaderen.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation).  
2. Verkrijg de referentie van de eerste dia via de index.  
3. Voeg een SmartArt‑vorm van het type [**StackedList**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArtLayoutType#StackedList) toe.  
4. Benader de toegevoegde SmartArt‑vorm.  
5. Benader het knooppunt op index 0 van de geopende SmartArt‑vorm.  
6. Benader nu de **Child Node** (https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArtNode#getChildNodes--) op positie 1 van het geselecteerde SmartArt‑knooppunt met de methode **get_Item()**.  
7. Benader en toon informatie zoals de positie, het niveau en de tekst van de **Child Node** (https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
import com.aspose.slides.*;

// Instantie van presentatie maken
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt‑vorm toevoegen op de eerste dia
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // SmartArt‑knooppunt op index 0 benaderen
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Onderliggend knooppunt op positie 1 in bovenliggend knooppunt benaderen
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // De parameters van het SmartArt‑onderliggende knooppunt afdrukken
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een SmartArt‑knooppunt verwijderen**
In dit voorbeeld leren we hoe we knooppunten binnen een SmartArt‑vorm verwijderen.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) en laad de presentatie met een SmartArt‑vorm.  
2. Verkrijg de referentie van de eerste dia via de index.  
3. Loop door elke vorm op de eerste dia.  
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) indien het SmartArt betreft.  
5. Controleer of de SmartArt meer dan 0 knooppunten bevat.  
6. Selecteer het SmartArt‑knooppunt dat verwijderd moet worden.  
7. Verwijder nu het geselecteerde knooppunt met de methode **RemoveNode** (https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).  
8. Sla de presentatie op.

```java
import com.aspose.slides.*;

// Laad de gewenste presentatie
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Doorloop elke vorm op de eerste dia
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape instanceof ISmartArt) 
        {
            // Cast de vorm naar SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // SmartArt‑knooppunt op index 0 benaderen
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Het geselecteerde knooppunt verwijderen
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // Presentatie opslaan
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een SmartArt‑knooppunt verwijderen vanaf een specifieke positie**
In dit voorbeeld leren we hoe we knooppunten binnen een SmartArt‑vorm op een bepaalde positie verwijderen.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) en laad de presentatie met een SmartArt‑vorm.  
2. Verkrijg de referentie van de eerste dia via de index.  
3. Loop door elke vorm op de eerste dia.  
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) indien het SmartArt betreft.  
5. Selecteer het SmartArt‑vormknooppunt op index 0.  
6. Controleer nu of het geselecteerde SmartArt‑knooppunt meer dan 2 onderliggende knooppunten heeft.  
7. Verwijder nu het knooppunt op **Positie 1** met de methode **RemoveNode** (https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).  
8. Sla de presentatie op.

```java
import com.aspose.slides.*;

// Laad de gewenste presentatie
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Doorloop elke vorm op de eerste dia
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape instanceof SmartArt) 
        {
            // Cast de vorm naar SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // SmartArt‑knooppunt op index 0 benaderen
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Het onderliggende knooppunt op positie 1 verwijderen
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // Presentatie opslaan
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een aangepaste positie voor een onderliggend knooppunt in een SmartArt‑object instellen**
Nu ondersteunt Aspose.Slides for Java het instellen van de [SmartArtShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArtShape) X (https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShape#setX-float-) en Y (https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShape#setY-float-) eigenschappen. Het code‑fragment hieronder toont hoe u een aangepaste positie, grootte en rotatie van een SmartArtShape instelt; let op dat het toevoegen van nieuwe knooppunten een herberekening van de posities en afmetingen van alle knooppunten veroorzaakt. Met aangepaste positie‑instellingen kan de gebruiker de knooppunten naar wens plaatsen.

```java
import com.aspose.slides.*;

// Instantie van Presentation‑klasse maken
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // SmartArt‑vorm naar nieuwe positie verplaatsen
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Breedtes van SmartArt‑vorm aanpassen
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Hoogte van SmartArt‑vorm aanpassen
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Rotatie van SmartArt‑vorm aanpassen
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Een assistent‑knooppunt controleren**
{{% alert color="info" %}} 

In dit artikel onderzoeken we verder de functionaliteiten van SmartArt‑vormen die via Aspose.Slides for Java programmatisch aan presentatiedia’s worden toegevoegd.

{{% /alert %}} 

We gebruiken de volgende bron‑SmartArt‑vorm voor onze onderzoeken in de verschillende secties van dit artikel.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figuur: Bron‑SmartArt‑vorm in dia**|

In de onderstaande voorbeeldcode onderzoeken we hoe we **Assistant Nodes** in de SmartArt‑knooppuntenverzameling identificeren en wijzigen.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) en laad de presentatie met een SmartArt‑vorm.  
2. Verkrijg de referentie van de tweede dia via de index.  
3. Loop door elke vorm op de eerste dia.  
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) indien het SmartArt betreft.  
5. Doorloop alle knooppunten in de SmartArt‑vorm en controleer of ze **Assistant Nodes** (https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArtNode#isAssistant--) zijn.  
6. Verander de status van het assistent‑knooppunt naar een normaal knooppunt.  
7. Sla de presentatie op.

```java
import com.aspose.slides.*;

// Een presentatie‑instantie maken
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Doorloop elke vorm op de eerste dia
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape instanceof ISmartArt) 
        {
            // Cast de vorm naar SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Doorloop alle knooppunten van de SmartArt‑vorm
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Controleer of het knooppunt een Assistant‑knooppunt is
                if (node.isAssistant()) 
                {
                    // Stel Assistant‑knooppunt in op false en maak er een normaal knooppunt van
                    node.setAssistant(false);
                }
            }
        }
    }
    
    // Presentatie opslaan
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figuur: Assistent‑knooppunten gewijzigd in SmartArt‑vorm in dia**|

## **Het vulformat van een knooppunt instellen**
Aspose.Slides for Java maakt het mogelijk om aangepaste SmartArt‑vormen toe te voegen en hun vulformat in te stellen. Dit artikel legt uit hoe u SmartArt‑vormen maakt, benadert en hun vulformat instelt met Aspose.Slides for Java.

Volg de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation).  
2. Verkrijg de referentie van een dia via de index.  
3. Voeg een [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) vorm toe door de **LayoutType** (https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) in te stellen.  
4. Stel de **FillFormat** (https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShape#getFillFormat--) in voor de SmartArt‑knooppuntvormen.  
5. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantie van presentatie maken
Presentation pres = new Presentation();
try {
    // Toegang tot de dia
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt‑vorm en knooppunten toevoegen
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Kleur van vulling voor knooppunt instellen
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // Presentatie opslaan
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een miniatuur van een onderliggend SmartArt‑knooppunt genereren**
Ontwikkelaars kunnen een miniatuur van een onderliggend knooppunt van een SmartArt genereren door de onderstaande stappen te volgen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation).  
2. [Add SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArtNodeCollection#addNode--).  
3. Verkrijg de referentie van een knooppunt via de index.  
4. Haal de miniatuurafbeelding op.  
5. Sla de miniatuurafbeelding op in elk gewenst afbeeldingsformaat.

```java
import com.aspose.slides.*;

// Instantiering van Presentation‑klasse die het PPTX‑bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // SmartArt toevoegen
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Verkrijg de referentie van een knooppunt via de index
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Miniatuur ophalen
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Miniatuur opslaan
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

### Wordt SmartArt‑animatie ondersteund?

Ja. SmartArt wordt behandeld als een gewone vorm, dus u kunt [standaardanimaties](/slides/nl/java/shape-animation/) (in- en uitgang, nadruk, bewegingspaden) toepassen en de timing aanpassen. U kunt ook vormen binnen SmartArt‑knooppunten animeren wanneer dat nodig is.

### Hoe kan ik een specifiek SmartArt‑object op een dia betrouwbaar vinden als de interne ID onbekend is?

Gebruik en zoek op [alternatieve tekst](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getAlternativeText--). Door een kenmerkende AltText op de SmartArt in te stellen, kunt u deze programmatisch vinden zonder op interne identifiers te vertrouwen.

### Wordt het uiterlijk van SmartArt behouden bij het converteren van de presentatie naar PDF?

Ja. Aspose.Slides rendert SmartArt met hoge visuele nauwkeurigheid tijdens de [PDF-export](/slides/nl/java/convert-powerpoint-to-pdf/), waardoor lay‑out, kleuren en effecten behouden blijven.

### Kan ik een afbeelding van de volledige SmartArt extraheren (voor voorbeeldweergaven of rapporten)?

Ja. U kunt een SmartArt‑vorm renderen naar [rasterformaten](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getImage-int-float-float-) of naar [SVG](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) voor schaalbare vectoruitvoer, waardoor het geschikt is voor miniaturen, rapporten of webgebruik.