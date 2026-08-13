---
title: SmartArt-vormknooppunten beheren in presentaties op Android
linktitle: SmartArt-vormknooppunt
type: docs
weight: 30
url: /nl/androidjava/manage-smartart-shape-node/
keywords:
- SmartArt knooppunt
- onderliggend knooppunt
- knooppunt toevoegen
- knooppuntpositie
- knooppunt benaderen
- knooppunt verwijderen
- aangepaste positie
- assistent knooppunt
- vulopmaak
- knooppunt renderen
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer SmartArt-vormknooppunten in PPT en PPTX met Aspose.Slides voor Android. Ontvang duidelijke Java-codevoorbeelden en tips om uw presentaties te stroomlijnen."
---
## **Overzicht**

SmartArt‑afbeeldingen in PowerPoint‑presentaties worden georganiseerd via knooppunten die tekst bevatten en de structuur van het diagram bepalen. Aspose.Slides stelt u in staat om programmatically met deze SmartArt‑knooppunten te werken: nieuwe knooppunten en onderliggende knooppunten toe te voegen, onderliggende knooppunten op een specifieke positie in te voegen, bestaande knooppunten te benaderen en hun tekst, niveau en positie uit te lezen.

Dit artikel legt uit hoe u SmartArt‑vormknooppunten kunt beheren. Het toont hoe u knooppunten kunt verwijderen, met onderliggende knooppunten op index of positie kunt werken, een assistent‑knooppunt naar een normaal knooppunt kunt omzetten, de positie, grootte en rotatie van SmartArt‑knooppunt‑vormen kunt aanpassen, vulopmaken voor knooppunten kunt instellen en een miniatuur‑afbeelding voor een SmartArt‑knooppunt kunt genereren.

## **Een SmartArt‑knooppunt toevoegen**
Aspose.Slides for Android via Java heeft de simpelste API geleverd om de SmartArt‑vormen op de makkelijkste manier te beheren. De volgende voorbeeldcode helpt u een knooppunt en onderliggend knooppunt toe te voegen binnen een SmartArt‑vorm.

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse en laad de presentatie met SmartArt‑vorm.
1. Verkrijg de referentie van de eerste dia via de Index.
1. Doorloop alle vormen in de eerste dia.
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) wanneer het SmartArt is.
1. [Voeg een nieuw knooppunt toe](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) in de SmartArt‑vorm **NodeCollection** en stel de tekst in de TextFrame in.
1. Nu, [voeg toe](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) een **onderliggend knooppunt** in het zojuist toegevoegde SmartArt‑knooppunt en stel de tekst in de TextFrame in.
1. Sla de presentatie op.

```java
import com.aspose.slides.*;

// Laad de gewenste presentatie
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Doorloop elke vorm in de eerste dia
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
    
            // Een nieuw onderliggend knooppunt toevoegen in het bovenliggende knooppunt. Het wordt aan het einde van de collectie toegevoegd
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
In de volgende voorbeeldcode leggen we uit hoe u onderliggende knooppunten van respectieve knooppunten van een SmartArt‑vorm op een bepaalde positie kunt toevoegen.

1. Maak een instantie van de Presentation‑klasse.
1. Verkrijg de referentie van de eerste dia via de Index.
1. Voeg een [**StackedList**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList)‑type [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArt)‑vorm toe op de geopende dia.
1. Benader het eerste knooppunt in de toegevoegde SmartArt‑vorm.
1. Voeg nu het **onderliggende knooppunt** toe voor het geselecteerde **knooppunt** op positie 2 en stel de tekst in.
1. Sla de presentatie op.

```java
import com.aspose.slides.*;

// Een presentatie‑instantie aanmaken
Presentation pres = new Presentation();
try {
    // De presentatiedia benaderen
    ISlide slide = pres.getSlides().get_Item(0);

    // SmartArt‑IShape toevoegen
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Het SmartArt‑knooppunt op index 0 benaderen
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Nieuw onderliggend knooppunt op positie 2 in het bovenliggende knooppunt toevoegen
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
De volgende voorbeeldcode helpt u knooppunten binnen een SmartArt‑vorm te benaderen. Let op dat het LayoutType van de SmartArt wordt gekozen wanneer de vorm wordt toegevoegd; later wijzigen met **setLayout** bouwt het hele diagram opnieuw, waardoor de knooppunt‑posities en -groottes die u mogelijk heeft ingesteld opnieuw worden berekend.

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse en laad de presentatie met SmartArt‑vorm.
1. Verkrijg de referentie van de eerste dia via de Index.
1. Doorloop alle vormen in de eerste dia.
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) wanneer het SmartArt is.
1. Doorloop alle **knooppunten** binnen de SmartArt‑vorm.
1. Benader en toon informatie zoals de positie, het niveau en de tekst van het SmartArt‑knooppunt.

```java
import com.aspose.slides.*;

// Presentatie‑klasse instantieren
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Eerste dia ophalen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Doorloop elke vorm in de eerste dia
    for (IShape shape : slide.getShapes()) 
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape instanceof ISmartArt) 
        {
            // Cast de vorm naar SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Doorloop alle knooppunten in SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Het SmartArt‑knooppunt op index i benaderen
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
De volgende voorbeeldcode helpt u de onderliggende knooppunten van respectieve knooppunten van een SmartArt‑vorm te benaderen.

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse en laad de presentatie met SmartArt‑vorm.
1. Verkrijg de referentie van de eerste dia via de Index.
1. Doorloop alle vormen in de eerste dia.
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) wanneer het SmartArt is.
1. Doorloop alle **knooppunten** binnen de SmartArt‑vorm.
1. Voor elk geselecteerd SmartArt‑vorm **knooppunt**, doorloop alle **onderliggende knooppunten** binnen dat specifieke knooppunt.
1. Benader en toon informatie zoals de positie, het niveau en de tekst van het **onderliggende knooppunt**.

```java
import com.aspose.slides.*;

// Presentatie‑klasse instantieren
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Eerste dia ophalen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Doorloop elke vorm in de eerste dia
    for (IShape shape : slide.getShapes()) 
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape instanceof ISmartArt) 
        {
            // Cast de vorm naar SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Doorloop alle knooppunten in SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Het SmartArt‑knooppunt op index i benaderen
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Doorloop de onderliggende knooppunten in het SmartArt‑knooppunt op index i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Het onderliggende knooppunt in SmartArt‑knooppunt benaderen
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
In dit voorbeeld leren we onderliggende knooppunten op een bepaalde positie te benaderen die bij respectieve knooppunten van een SmartArt‑vorm horen.

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse.
1. Verkrijg de referentie van de eerste dia via de Index.
1. Voeg een [**StackedList**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList)‑type SmartArt‑vorm toe.
1. Benader de toegevoegde SmartArt‑vorm.
1. Benader het knooppunt op index 0 voor de geopende SmartArt‑vorm.
1. Benader nu het **onderliggende knooppunt** op positie 1 voor het geopende SmartArt‑knooppunt met de **get_Item()**‑methode.
1. Benader en toon informatie zoals de positie, het niveau en de tekst van het **onderliggende knooppunt**.

```java
import com.aspose.slides.*;

// Presentatie instantieren
Presentation pres = new Presentation();
try {
    // De eerste dia benaderen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // De SmartArt‑vorm toevoegen in de eerste dia
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Het SmartArt‑knooppunt op index 0 benaderen
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Het onderliggende knooppunt op positie 1 in het bovenliggende knooppunt benaderen
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // De parameters van het SmartArt‑onderliggende knooppunt afdrukken
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een SmartArt‑knooppunt verwijderen**
In dit voorbeeld leren we hoe knooppunten binnen een SmartArt‑vorm te verwijderen.

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse en laad de presentatie met SmartArt‑vorm.
1. Verkrijg de referentie van de eerste dia via de Index.
1. Doorloop alle vormen in de eerste dia.
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) wanneer het SmartArt is.
1. Controleer of de [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) meer dan 0 knooppunten bevat.
1. Selecteer het SmartArt‑knooppunt dat verwijderd moet worden.
1. Verwijder nu het geselecteerde knooppunt met de **RemoveNode**‑methode.
1. Sla de presentatie op.

```java
import com.aspose.slides.*;

// Laad de gewenste presentatie
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Doorloop elke vorm in de eerste dia
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Controleer of de vorm van het SmartArt-type is
        if (shape instanceof ISmartArt) 
        {
            // Cast de vorm naar SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Het SmartArt-knooppunt op index 0 benaderen
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

## **Een SmartArt‑knooppunt op een specifieke positie verwijderen**
In dit voorbeeld leren we knooppunten binnen een SmartArt‑vorm op een bepaalde positie te verwijderen.

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse en laad de presentatie met SmartArt‑vorm.
1. Verkrijg de referentie van de eerste dia via de Index.
1. Doorloop alle vormen in de eerste dia.
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) wanneer het SmartArt is.
1. Selecteer het SmartArt‑vormknooppunt op index 0.
1. Controleer nu of het geselecteerde SmartArt‑knooppunt meer dan 2 onderliggende knooppunten bevat.
1. Verwijder nu het knooppunt op **Positie 1** met de **RemoveNode**‑methode.
1. Sla de presentatie op.

```java
import com.aspose.slides.*;

// Laad de gewenste presentatie
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Doorloop elke vorm in de eerste dia
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Controleer of de vorm van het SmartArt-type is
        if (shape instanceof SmartArt) 
        {
            // Cast de vorm naar SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Het SmartArt‑knooppunt op index 0 benaderen
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
Nu biedt Aspose.Slides for Android via Java ondersteuning voor het instellen van de X‑ en Y‑eigenschappen van een [SmartArtShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArtShape). Het onderstaande codefragment toont hoe u een aangepaste positie, grootte en rotatie van een SmartArt‑vorm kunt instellen; let op dat het toevoegen van nieuwe knooppunten leidt tot een herberekening van de posities en groottes van alle knooppunten. Met aangepaste positietoetsen kan de gebruiker de knooppunten naar wens positioneren.

```java
import com.aspose.slides.*;

// Presentatie‑klasse instantieren
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // SmartArt‑vorm naar nieuwe positie verplaatsen
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Breedtes van de SmartArt‑vorm wijzigen
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Hoogte van de SmartArt‑vorm wijzigen
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Rotatie van de SmartArt‑vorm wijzigen
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

In dit artikel onderzoeken we verder de functionaliteit van SmartArt‑vormen die via Aspose.Slides for Android via Java programmatisch aan presentatiedia’s worden toegevoegd.

{{% /alert %}} 

We gebruiken de volgende bron‑SmartArt‑vorm voor ons onderzoek in de verschillende secties van dit artikel.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figuur: Bron‑SmartArt‑vorm in dia**|

In de volgende voorbeeldcode onderzoeken we hoe we **assistent‑knooppunten** in de SmartArt‑knooppuntencollectie kunnen identificeren en wijzigen.

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse en laad de presentatie met SmartArt‑vorm.
1. Verkrijg de referentie van de eerste dia via de Index.
1. Doorloop alle vormen in de eerste dia.
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) wanneer het SmartArt is.
1. Doorloop alle knooppunten binnen de SmartArt‑vorm en controleer of ze **assistent‑knooppunten** zijn.
1. Verander de status van het assistent‑knooppunt naar een normaal knooppunt.
1. Sla de presentatie op.

```java
import com.aspose.slides.*;

// Een presentatie‑instantie aanmaken
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Doorloop elke vorm in de eerste dia
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Controleer of de vorm van het SmartArt‑type is
        if (shape instanceof ISmartArt) 
        {
            // Cast de vorm naar SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Doorloop alle knooppunten van de SmartArt‑vorm
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Controleer of het knooppunt een assistent‑knooppunt is
                if (node.isAssistant()) 
                {
                    // Het assistent‑knooppunt op false zetten en omzetten naar een normaal knooppunt
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
|**Figuur: Assistent‑knooppunten gewijzigd in SmartArt‑vorm binnen dia**|

## **Een knooppunt‑vulopmaak instellen**
Aspose.Slides for Android via Java maakt het mogelijk om aangepaste SmartArt‑vormen toe te voegen en hun vulopmaak in te stellen. Dit artikel legt uit hoe u SmartArt‑vormen maakt, benadert en hun vulopmaak instelt met Aspose.Slides for Android via Java.

Volg de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse.
1. Verkrijg de referentie van een dia via de index.
1. Voeg een [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt)‑vorm toe door het **LayoutType**‑type in te stellen.
1. Stel de **FillFormat**‑eigenschap in voor de SmartArt‑knooppunt‑vormen.
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentatie instantieren
Presentation pres = new Presentation();
try {
    // De dia benaderen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt‑vorm en knooppunten toevoegen
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Knoopvulkleur instellen
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

## **Een miniatuur van een SmartArt‑knooppunt genereren**
Ontwikkelaars kunnen een miniatuur van een knooppunt van een SmartArt genereren door de onderstaande stappen te volgen:

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse.
1. [Voeg SmartArt toe](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).
1. Verkrijg de referentie van een knooppunt via de Index.
1. Haal de miniatuur‑afbeelding op.
1. Sla de miniatuur‑afbeelding op in elk gewenst afbeeldingsformaat.

```java
import com.aspose.slides.*;

// Instantie van de Presentatie‑klasse die het PPTX‑bestand voorstelt
Presentation pres = new Presentation();
try {
    // SmartArt toevoegen
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Referentie van een knooppunt verkrijgen via de index
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

Ja. SmartArt wordt behandeld als een gewone vorm, zodat u [standaardanimaties](/slides/nl/androidjava/shape-animation/) (intreden, verlaten, nadruk, bewegingspaden) kunt toepassen en de timing kunt aanpassen. U kunt ook vormen binnen SmartArt‑knooppunten animeren wanneer dat nodig is.

### Hoe kan ik een specifiek SmartArt‑object op een dia betrouwbaar vinden als de interne ID onbekend is?

Zoek en selecteer op basis van [alternatieve tekst](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getAlternativeText--). Door een herkenbare AltText aan de SmartArt toe te wijzen, kunt u deze programmatisch vinden zonder afhankelijk te zijn van interne identifiers.

### Wordt het uiterlijk van SmartArt behouden bij het converteren van de presentatie naar PDF?

Ja. Aspose.Slides rendert SmartArt met hoge visuele nauwkeurigheid tijdens de [PDF‑export](/slides/nl/androidjava/convert-powerpoint-to-pdf/), waardoor lay‑out, kleuren en effecten behouden blijven.

### Kan ik een afbeelding van de volledige SmartArt extraheren (voor voorbeeldweergaven of rapporten)?

Ja. U kunt een SmartArt‑vorm renderen naar [rasterformaten](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) of naar [SVG](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) voor schaalbare vectoroutput, geschikt voor miniaturen, rapporten of webgebruik.