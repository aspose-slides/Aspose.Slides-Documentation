---
title: Beheer SmartArt‑vormknooppunten in presentaties met Java
linktitle: SmartArt‑vormknooppunt
type: docs
weight: 30
url: /nl/java/manage-smartart-shape-node/
keywords:
- SmartArt‑knooppunt
- subknooppunt
- knooppunt toevoegen
- knooppuntpositie
- knooppunt benaderen
- knooppunt verwijderen
- aangepaste positie
- assistent‑knooppunt
- vulformaat
- knooppunt renderen
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Beheer SmartArt‑vormknooppunten in PPT en PPTX met Aspose.Slides voor Java. Ontvang duidelijke codevoorbeelden en tips om uw presentaties te stroomlijnen."
---
## **Overzicht**

SmartArt-afbeeldingen in PowerPoint‑presentaties zijn georganiseerd via knooppunten die tekst bevatten en de structuur van het diagram bepalen. Aspose.Slides stelt u in staat om programmatisch met deze SmartArt‑knooppunten te werken: nieuwe knooppunten en subknooppunten toevoegen, subknooppunten op een specifieke positie invoegen, bestaande knooppunten benaderen en hun tekst, niveau en positie lezen.

Dit artikel legt uit hoe u SmartArt‑vormknooppunten kunt beheren. Het laat zien hoe u knooppunten verwijdert, met subknooppunten werkt op basis van index of positie, een assistent‑knooppunt omzet naar een normaal knooppunt, de positie, grootte en draaiing van SmartArt‑knooppuntvormen aanpast, vulformaten voor knooppunten instelt en een miniatuurafbeelding voor een SmartArt‑subknooppunt genereert.

## **Een SmartArt‑knooppunt toevoegen**
Aspose.Slides for Java biedt de eenvoudigste API om SmartArt‑vormen op de gemakkelijkste manier te beheren. De volgende voorbeeldcode helpt bij het toevoegen van een knooppunt en subknooppunt binnen een SmartArt‑vorm.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)‑klasse aan en laad de presentatie met een SmartArt‑vorm.  
2. Verkrijg de referentie naar de eerste dia met behulp van de index.  
3. Doorloop alle vormen op de eerste dia.  
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) als het SmartArt is.  
5. Voeg een nieuw [Node](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) toe in de SmartArt‑vorm [**NodeCollection**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt#getAllNodes--) en stel de tekst in het TextFrame in.  
6. Voeg nu een [**Child Node**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArtNode#getChildNodes--) toe aan het zojuist toegevoegde SmartArt‑Node en stel de tekst in het TextFrame in.  
7. Sla de presentatie op.

```java
// Laad de gewenste presentatie
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Doorloop alle vormen op de eerste dia
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape instanceof SmartArt) 
        {
            // Cast de vorm naar SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Een nieuw SmartArt-knooppunt toevoegen
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Tekst toevoegen
            TemNode.getTextFrame().setText("Test");
    
            // Een nieuw subknooppunt toevoegen in het bovenliggende knooppunt. Het wordt aan het einde van de collectie toegevoegd
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
In de volgende voorbeeldcode laten we zien hoe u subknooppunten kunt toevoegen die behoren tot de respectieve knooppunten van een SmartArt‑vorm op een bepaalde positie.

1. Maak een instantie van de Presentation‑klasse.  
2. Verkrijg de referentie naar de eerste dia met behulp van de index.  
3. Voeg een [**StackedList**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArtLayoutType#StackedList)‑type [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArt)‑vorm toe op de geopende dia.  
4. Benader het eerste knooppunt in de toegevoegde SmartArt‑vorm.  
5. Voeg nu de [**Child Node**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArtNode#getChildNodes--) toe voor het geselecteerde [**Node**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArtNode) op positie 2 en stel de tekst in.  
6. Sla de presentatie op.

```java
// Een presentatie‑instantie maken
Presentation pres = new Presentation();
try {
    // De presentatiedia benaderen
    ISlide slide = pres.getSlides().get_Item(0);

    // SmartArt‑IShape toevoegen
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Het SmartArt‑knooppunt op index 0 benaderen
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Een nieuw subknooppunt toevoegen op positie 2 in het bovenliggende knooppunt
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
De volgende voorbeeldcode helpt u knooppunten binnen een SmartArt‑vorm te benaderen. Let op dat u het LayoutType van de SmartArt niet kunt wijzigen; dit is alleen-lezen en wordt vastgesteld op het moment dat de SmartArt‑vorm wordt toegevoegd.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation)‑klasse aan en laad de presentatie met een SmartArt‑vorm.  
2. Verkrijg de referentie naar de eerste dia met behulp van de index.  
3. Doorloop alle vormen op de eerste dia.  
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) als het SmartArt is.  
5. Doorloop alle [**Nodes**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArt#getAllNodes--) binnen de SmartArt‑vorm.  
6. Benader en toon informatie zoals de positie, het niveau en de tekst van het SmartArt‑knooppunt.

```java
// Presentatie‑klasse instantieren
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Eerste dia ophalen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Doorloop alle vormen op de eerste dia
    for (IShape shape : slide.getShapes()) 
    {
        // Controleren of de vorm van het type SmartArt is
        if (shape instanceof ISmartArt) 
        {
            // Vorm casten naar SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Doorloop alle knooppunten in SmartArt
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

## **Een SmartArt‑subknooppunt benaderen**
De volgende voorbeeldcode helpt u de subknooppunten te benaderen die behoren tot de respectieve knooppunten van een SmartArt‑vorm.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation)‑klasse aan en laad de presentatie met een SmartArt‑vorm.  
2. Verkrijg de referentie naar de eerste dia met behulp van de index.  
3. Doorloop alle vormen op de eerste dia.  
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) als het SmartArt is.  
5. Doorloop alle [**Nodes**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArt#getAllNodes--) binnen de SmartArt‑vorm.  
6. Voor elk geselecteerd SmartArt‑vorm [**Node**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArtNode) doorloop alle [**Child Nodes**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArtNode#getChildNodes--) binnen dat specifieke knooppunt.  
7. Benader en toon informatie zoals de positie, het niveau en de tekst van de [**Child Node**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
// Presentatie‑klasse instantieren
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Eerste dia ophalen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Doorloop alle vormen op de eerste dia
    for (IShape shape : slide.getShapes()) 
    {
        // Controleren of de vorm van het type SmartArt is
        if (shape instanceof ISmartArt) 
        {
            // Vorm casten naar SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Doorloop alle knooppunten in SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // SmartArt‑knooppunt op index i benaderen
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Doorlopen van de subknooppunten in SmartArt‑knooppunt op index i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Subknooppunt in SmartArt‑knooppunt benaderen
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // De parameters van het SmartArt‑subknooppunt afdrukken
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een SmartArt‑subknooppunt op een specifieke positie benaderen**
In dit voorbeeld leren we hoe we subknooppunten op een bepaalde positie kunnen benaderen die behoren tot de respectieve knooppunten van een SmartArt‑vorm.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation)‑klasse.  
2. Verkrijg de referentie naar de eerste dia met behulp van de index.  
3. Voeg een [**StackedList**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArtLayoutType#StackedList)‑type SmartArt‑vorm toe.  
4. Benader de toegevoegde SmartArt‑vorm.  
5. Benader het knooppunt op index 0 van de geopende SmartArt‑vorm.  
6. Benader nu de [**Child Node**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArtNode#getChildNodes--) op positie 1 voor het benaderde SmartArt‑knooppunt met de methode **get_Item()**.  
7. Benader en toon informatie zoals de positie, het niveau en de tekst van de [**Child Node**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
// Presentatie‑instantie maken
Presentation pres = new Presentation();
try {
    // Eerste dia benaderen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt‑vorm toevoegen op eerste dia
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // SmartArt‑knooppunt op index 0 benaderen
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Subknooppunt op positie 1 in bovenliggend knooppunt benaderen
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // De parameters van het SmartArt‑subknooppunt afdrukken
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een SmartArt‑knooppunt verwijderen**
In dit voorbeeld leren we hoe we knooppunten binnen een SmartArt‑vorm kunnen verwijderen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation)‑klasse en laad de presentatie met een SmartArt‑vorm.  
2. Verkrijg de referentie naar de eerste dia met behulp van de index.  
3. Doorloop alle vormen op de eerste dia.  
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) als het SmartArt is.  
5. Controleer of de [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) meer dan 0 knooppunten bevat.  
6. Selecteer het SmartArt‑knooppunt dat verwijderd moet worden.  
7. Verwijder nu het geselecteerde knooppunt met de methode [**RemoveNode**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).  
8. Sla de presentatie op.

```java
// Laad de gewenste presentatie
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Doorloop alle vormen op de eerste dia
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Controleren of de vorm van het type SmartArt is
        if (shape instanceof ISmartArt) 
        {
            // Vorm casten naar SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // SmartArt‑knooppunt op index 0 benaderen
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Geselecteerd knooppunt verwijderen
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
In dit voorbeeld leren we hoe we knooppunten binnen een SmartArt‑vorm op een bepaalde positie kunnen verwijderen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation)‑klasse en laad de presentatie met een SmartArt‑vorm.  
2. Verkrijg de referentie naar de eerste dia met behulp van de index.  
3. Doorloop alle vormen op de eerste dia.  
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISSmartArt) als het SmartArt is.  
5. Selecteer het SmartArt‑vormknooppunt op index 0.  
6. Controleer nu of het geselecteerde SmartArt‑knooppunt meer dan 2 subknooppunten heeft.  
7. Verwijder nu het knooppunt op **Positie 1** met de methode [**RemoveNode**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).  
8. Sla de presentatie op.

```java
// Laad de gewenste presentatie
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Doorloop alle vormen op de eerste dia
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Controleren of de vorm van het type SmartArt is
        if (shape instanceof SmartArt) 
        {
            // Vorm casten naar SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // SmartArt‑knooppunt op index 0 benaderen
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Subknooppunt op positie 1 verwijderen
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

## **Aangepaste positie instellen voor een subknooppunt in een SmartArt‑object**
Aspose.Slides for Java ondersteunt nu het instellen van de [SmartArtShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArtShape) eigenschappen [X](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShape#setX-float-) en [Y](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShape#setY-float-). De onderstaande code‑fragment toont hoe u een aangepaste positie, grootte en draaiing voor een SmartArtShape instelt; houd er rekening mee dat het toevoegen van nieuwe knooppunten een hersberekening van de posities en groottes van alle knooppunten veroorzaakt. Met aangepaste positiebepalingen kan de gebruiker de knooppunten naar wens positioneren.

```java
// Presentatie‑klasse instantieren
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // SmartArt‑vorm verplaatsen naar nieuwe positie
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // SmartArt‑vorm breedtes wijzigen
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // SmartArt‑vorm hoogte wijzigen
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // SmartArt‑vorm rotatie wijzigen
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Assistent‑knooppunt controleren**
{{% alert color="primary" %}} 
In dit artikel onderzoeken we verder de functionaliteit van SmartArt‑vormen die programmatisch aan presentatieslides worden toegevoegd met Aspose.Slides for Java. 
{{% /alert %}} 

We gebruiken de volgende bron‑SmartArt‑vorm voor ons onderzoek in de verschillende secties van dit artikel.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figuur: Bron‑SmartArt‑vorm in dia**|

In de onderstaande voorbeeldcode onderzoeken we hoe we **Assistent‑knooppunten** in de SmartArt‑knooppuntcollectie kunnen identificeren en wijzigen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation)‑klasse en laad de presentatie met een SmartArt‑vorm.  
2. Verkrijg de referentie naar de tweede dia met behulp van de index.  
3. Doorloop alle vormen op de eerste dia.  
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt) als het SmartArt is.  
5. Doorloop alle knooppunten binnen de SmartArt‑vorm en controleer of ze [**Assistant Nodes**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArtNode#isAssistant--) zijn.  
6. Verander de status van het assistent‑knooppunt naar een normaal knooppunt.  
7. Sla de presentatie op.

```java
// Een presentatie‑instantie maken
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Doorloop alle vormen op de eerste dia
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Controleren of de vorm van het type SmartArt is
        if (shape instanceof ISmartArt) 
        {
            // Vorm casten naar SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Doorloop alle knooppunten van de SmartArt‑vorm
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Controleren of het knooppunt een assistent‑knooppunt is
                if (node.isAssistant()) 
                {
                    // Assistents‑knooppunt op false zetten en het een normaal knooppunt maken
                    node.isAssistant();
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

## **Een knooppunt vulformaat instellen**
Aspose.Slides for Java maakt het mogelijk aangepaste SmartArt‑vormen toe te voegen en hun vulformaat in te stellen. Dit artikel legt uit hoe u SmartArt‑vormen maakt, benadert en het vulformaat instelt met Aspose.Slides for Java.

Volg de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation)‑klasse.  
2. Verkrijg de referentie van een dia met behulp van de index.  
3. Voeg een [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArt)‑vorm toe door het instellen van het [**LayoutType**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).  
4. Stel de [**FillFormat**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShape#getFillFormat--) in voor de SmartArt‑knooppuntvormen.  
5. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```java
// Presentatie instantieren
Presentation pres = new Presentation();
try {
    // Dia benaderen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt‑vorm en knooppunten toevoegen
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Knoop vulkleur instellen
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

## **Een miniatuur van een SmartArt‑subknooppunt genereren**
Ontwikkelaars kunnen een miniatuur van een subknooppunt van een SmartArt genereren door de onderstaande stappen te volgen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation)‑klasse.  
2. [SmartArt toevoegen](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArtNodeCollection#addNode--).  
3. Verkrijg de referentie van een knooppunt met behulp van de index.  
4. Haal de miniatuurafbeelding op.  
5. Sla de miniatuurafbeelding op in een gewenst afbeeldingsformaat.

```java
// Presentatie‑klasse instantieren die het PPTX‑bestand vertegenwoordigt
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

**Wordt SmartArt‑animatie ondersteund?**

Ja. SmartArt wordt behandeld als een gewone vorm, zodat u [standaardanimaties](/slides/nl/java/shape-animation/) (invoer, uitgang, nadruk, bewegingspaden) kunt toepassen en de timing kunt aanpassen. U kunt ook vormen binnen SmartArt‑knooppunten animeren indien nodig.

**Hoe kan ik een specifiek SmartArt‑object op een dia betrouwbaar vinden als de interne ID onbekend is?**

Zoek op en wijs een [alternatieve tekst](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getAlternativeText--) toe. Het instellen van een onderscheidende AltText op de SmartArt maakt het mogelijk het object programmatically te vinden zonder te vertrouwen op interne identifieres.

**Blijft de weergave van SmartArt behouden bij het converteren van de presentatie naar PDF?**

Ja. Aspose.Slides rendert SmartArt met hoge visuele nauwkeurigheid tijdens de [PDF‑export](/slides/nl/java/convert-powerpoint-to-pdf/), waardoor lay-out, kleuren en effecten behouden blijven.

**Kan ik een afbeelding van de volledige SmartArt extraheren (voor voorbeeldweergaven of rapporten)?**

Ja. U kunt een SmartArt‑vorm renderen naar [rasterformaten](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getImage-int-float-float-) of naar [SVG](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) voor schaalbare vectoruitvoer, geschikt voor miniaturen, rapporten of webgebruik.