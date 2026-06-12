---
title: Beheer SmartArt-vormknooppunten in presentaties op Android
linktitle: SmartArt-vormknooppunt
type: docs
weight: 30
url: /nl/androidjava/manage-smartart-shape-node/
keywords:
- SmartArt-knooppunt
- subknooppunt
- knooppunt toevoegen
- knooppuntpositie
- knooppunt benaderen
- knooppunt verwijderen
- aangepaste positie
- assistentknooppunt
- opvulopmaak
- knooppunt renderen
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer SmartArt-vormknooppunten in PPT en PPTX met Aspose.Slides voor Android. Krijg duidelijke Java-codevoorbeelden en tips om uw presentaties te stroomlijnen."
---
## **Overzicht**

SmartArt‑graphics in PowerPoint‑presentaties worden georganiseerd via knooppunten die tekst bevatten en de structuur van het diagram definiëren. Aspose.Slides stelt u in staat om programmatic te werken met deze SmartArt‑knooppunten: nieuwe knooppunten en subknooppunten toe te voegen, subknooppunten op een specifieke positie in te voegen, bestaande knooppunten te benaderen, en hun tekst, niveau en positie te lezen.

Dit artikel legt uit hoe u SmartArt‑vormknooppunten beheert. Het toont hoe u knooppunten verwijdert, werkt met subknooppunten op index of positie, een assistentknooppunt verandert in een normaal knooppunt, de positie, grootte en rotatie van SmartArt‑knooppuntvormen aanpast, vulopmaak voor knooppunten instelt en een miniatuurafbeelding genereert voor een SmartArt‑subknooppunt.

## **Een SmartArt‑knooppunt toevoegen**
Aspose.Slides for Android via Java heeft de eenvoudigste API geleverd om de SmartArt‑vormen op de gemakkelijkste manier te beheren. De volgende voorbeeldcode helpt bij het toevoegen van een knooppunt en subknooppunt binnen een SmartArt‑vorm.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) en laad de presentatie met een SmartArt‑vorm.  
2. Verkrijg de referentie naar de eerste dia met behulp van de Index.  
3. Loop door elke vorm in de eerste dia.  
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) als het SmartArt is.  
5. [Voeg een nieuw knooppunt toe](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) in de SmartArt‑vorm [**NodeCollection**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) en stel de tekst in het TextFrame in.  
6. Nu, [voeg](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) een [**Child Node**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) toe in het nieuw toegevoegde [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt)‑knooppunt en stel de tekst in het TextFrame in.  
7. Sla de presentatie op.

```java
// Laad de gewenste presentatie
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Doorloop elke vorm in de eerste dia
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Controleer of de vorm van SmartArt-type is
        if (shape instanceof SmartArt) 
        {
            // Cast de vorm naar SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Een nieuw SmartArt-knooppunt toevoegen
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Tekst toevoegen
            TemNode.getTextFrame().setText("Test");
    
            // Een nieuw subknooppunt toevoegen in het bovenliggende knooppunt. Het wordt toegevoegd aan het einde van de verzameling
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

## **Een SmartArt‑knooppunt toevoegen op een specifieke positie**
In de volgende voorbeeldcode wordt uitgelegd hoe u de subknooppunten van respectieve knooppunten van een SmartArt‑vorm op een bepaalde positie toevoegt.

1. Maak een instantie van de klasse Presentation.  
2. Verkrijg de referentie naar de eerste dia met behulp van de Index.  
3. Voeg een [**StackedList**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList)‑type [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArt)‑vorm toe in de benaderde dia.  
4. Benader het eerste knooppunt in de toegevoegde SmartArt‑vorm.  
5. Nu, voeg de [**Child Node**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) toe voor het geselecteerde [**Node**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArtNode) op positie 2 en stel de tekst in.  
6. Sla de presentatie op.

```java
// Een presentatie‑instantie maken
Presentation pres = new Presentation();
try {
    // De presentatiedia benaderen
    ISlide slide = pres.getSlides().get_Item(0);

    // Smart Art IShape toevoegen
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Het SmartArt‑knooppunt benaderen op index 0
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
De volgende voorbeeldcode helpt bij het benaderen van knooppunten binnen een SmartArt‑vorm. Merk op dat u het LayoutType van de SmartArt niet kunt wijzigen omdat het alleen-lezen is en alleen wordt ingesteld wanneer de SmartArt‑vorm wordt toegevoegd.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) en laad de presentatie met een SmartArt‑vorm.  
2. Verkrijg de referentie naar de eerste dia met behulp van de Index.  
3. Loop door elke vorm in de eerste dia.  
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) als het SmartArt is.  
5. Loop door alle [**Nodes**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArt#getAllNodes--) binnen de SmartArt‑vorm.  
6. Benader en toon informatie zoals de positie, het niveau en de tekst van het SmartArt‑knooppunt.

```java
// Instantieer Presentation‑klasse
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Eerste dia ophalen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Doorloop elke vorm in de eerste dia
    for (IShape shape : slide.getShapes()) 
    {
        // Controleer of de vorm van SmartArt‑type is
        if (shape instanceof ISmartArt) 
        {
            // Cast vorm naar SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Doorloop alle knooppunten binnen SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // SmartArt‑knooppunt benaderen op index i
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
De volgende voorbeeldcode helpt bij het benaderen van de subknooppunten die behoren tot respectieve knooppunten van een SmartArt‑vorm.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) en laad de presentatie met een SmartArt‑vorm.  
2. Verkrijg de referentie naar de eerste dia met behulp van de Index.  
3. Loop door elke vorm in de eerste dia.  
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) als het SmartArt is.  
5. Loop door alle [**Nodes**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArt#getAllNodes--) binnen de SmartArt‑vorm.  
6. Voor elk geselecteerd SmartArt‑vorm [**Node**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArtNode), loop door alle [**Child Nodes**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) binnen het betreffende knooppunt.  
7. Benader en toon informatie zoals de positie, het niveau en de tekst van de [**Child Node**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
// Instantieer Presentation‑klasse
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Eerste dia ophalen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Doorloop elke vorm in de eerste dia
    for (IShape shape : slide.getShapes()) 
    {
        // Controleer of de vorm van SmartArt‑type is
        if (shape instanceof ISmartArt) 
        {
            // Cast vorm naar SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Doorloop alle knooppunten binnen SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // SmartArt‑knooppunt benaderen op index i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Doorloop de subknooppunten in het SmartArt‑knooppunt op index i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Het subknooppunt in het SmartArt‑knooppunt benaderen
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

## **Een SmartArt‑subknooppunt benaderen op een specifieke positie**
In dit voorbeeld leren we de subknooppunten op een bepaalde positie te benaderen die behoren tot respectieve knooppunten van een SmartArt‑vorm.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation).  
2. Verkrijg de referentie naar de eerste dia met behulp van de Index.  
3. Voeg een [**StackedList**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList)‑type SmartArt‑vorm toe.  
4. Benader de toegevoegde SmartArt‑vorm.  
5. Benader het knooppunt op index 0 voor de benaderde SmartArt‑vorm.  
6. Nu, benader de [**Child Node**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) op positie 1 voor het benaderde SmartArt‑knooppunt met behulp van **get_Item()**‑methode.  
7. Benader en toon informatie zoals de positie, het niveau en de tekst van de [**Child Node**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
// Instantieer de presentatie
Presentation pres = new Presentation();
try {
    // De eerste dia benaderen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // De SmartArt‑vorm toevoegen in de eerste dia
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Het SmartArt‑knooppunt benaderen op index 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Het subknooppunt benaderen op positie 1 in het bovenliggende knooppunt
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

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) en laad de presentatie met een SmartArt‑vorm.  
2. Verkrijg de referentie naar de eerste dia met behulp van de Index.  
3. Loop door elke vorm in de eerste dia.  
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISSmartArt) als het SmartArt is.  
5. Controleer of de [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) meer dan 0 knooppunten bevat.  
6. Selecteer het SmartArt‑knooppunt dat moet worden verwijderd.  
7. Verwijder nu het geselecteerde knooppunt met de [**RemoveNode**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-)‑methode.  
8. Sla de presentatie op.

```java
// Laad de gewenste presentatie
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Doorloop elke vorm in de eerste dia
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Controleer of de vorm van SmartArt‑type is
        if (shape instanceof ISmartArt) 
        {
            // Cast vorm naar SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // SmartArt‑knooppunt benaderen op index 0
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
In dit voorbeeld leren we hoe we knooppunten binnen een SmartArt‑vorm kunnen verwijderen op een bepaalde positie.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) en laad de presentatie met een SmartArt‑vorm.  
2. Verkrijg de referentie naar de eerste dia met behulp van de Index.  
3. Loop door elke vorm in de eerste dia.  
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISSmartArt) als het SmartArt is.  
5. Selecteer het SmartArt‑vormknooppunt op index 0.  
6. Controleer nu of het geselecteerde SmartArt‑knooppunt meer dan 2 subknooppunten bevat.  
7. Verwijder nu het knooppunt op **Positie 1** met de [**RemoveNode**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-)‑methode.  
8. Sla de presentatie op.

```java
// Laad de gewenste presentatie
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Doorloop elke vorm in de eerste dia
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Controleer of de vorm van SmartArt‑type is
        if (shape instanceof SmartArt) 
        {
            // Cast vorm naar SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // SmartArt‑knooppunt benaderen op index 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Het subknooppunt verwijderen op positie 1
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

## **Een aangepaste positie instellen voor een subknooppunt in een SmartArt‑object**
Nu ondersteunt Aspose.Slides for Android via Java het instellen van de [SmartArtShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape#setX-float-) en [Y](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape#setY-float-)‑eigenschappen. Het onderstaande code‑fragment toont hoe u een aangepaste positie, grootte en rotatie van een SmartArtShape instelt; let tevens op dat het toevoegen van nieuwe knooppunten een herberekening van de posities en afmetingen van alle knooppunten veroorzaakt. Met aangepaste positiebepalingen kan de gebruiker de knooppunten naar wens positioneren.

```java
// Instantieer Presentation‑klasse
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Verplaats SmartArt‑vorm naar nieuwe positie
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Verander de breedtes van de SmartArt‑vorm
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Verander de hoogte van de SmartArt‑vorm
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Verander de rotatie van de SmartArt‑vorm
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Een assistentknooppunt controleren**
{{% alert color="primary" %}} 

In dit artikel onderzoeken we verder de mogelijkheden van SmartArt‑vormen die programmatisch aan presentatiedia’s worden toegevoegd met Aspose.Slides for Android via Java.

{{% /alert %}} 

We zullen de volgende bron‑SmartArt‑vorm gebruiken voor ons onderzoek in verschillende secties van dit artikel.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figuur: Bron‑SmartArt‑vorm op dia**|

In de volgende voorbeeldcode onderzoeken we hoe **Assistent‑knooppunten** in de SmartArt‑knooppuntencollectie kunnen worden geïdentificeerd en gewijzigd.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) en laad de presentatie met een SmartArt‑vorm.  
2. Verkrijg de referentie naar de tweede dia met behulp van de Index.  
3. Loop door elke vorm in de eerste dia.  
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt) als het SmartArt is.  
5. Loop door alle knooppunten binnen de SmartArt‑vorm en controleer of ze [**Assistant Nodes**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArtNode#isAssistant--) zijn.  
6. Verander de status van het assistentknooppunt naar een normaal knooppunt.  
7. Sla de presentatie op.

```java
// Een presentatie‑instantie maken
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Doorloop elke vorm in de eerste dia
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Controleer of de vorm van SmartArt‑type is
        if (shape instanceof ISmartArt) 
        {
            // Cast vorm naar SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Doorloop alle knooppunten van de SmartArt‑vorm
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Controleer of het knooppunt een assistentknooppunt is
                if (node.isAssistant()) 
                {
                    // Assistant‑knooppunt op false zetten en een normaal knooppunt maken
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
|**Figuur: Assistent‑knooppunten gewijzigd in SmartArt‑vorm op dia**|

## **De opvulopmaak van een knooppunt instellen**
Aspose.Slides for Android via Java maakt het mogelijk om aangepaste SmartArt‑vormen toe te voegen en hun opvulopmaak in te stellen. Dit artikel legt uit hoe u SmartArt‑vormen maakt, benadert en hun opvulopmaak instelt met Aspose.Slides for Android via Java.

Volg de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation).  
2. Verkrijg de referentie van een dia met behulp van de index.  
3. Voeg een [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArt)‑vorm toe door het [**LayoutType**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) in te stellen.  
4. Stel de [**FillFormat**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape#getFillFormat--) in voor de knooppunten van de SmartArt‑vorm.  
5. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```java
// Instantieer de presentatie
Presentation pres = new Presentation();
try {
    // De dia benaderen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt‑vorm en knooppunten toevoegen
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Vulkleur van het knooppunt instellen
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

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation).  
2. [Voeg SmartArt toe](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).  
3. Verkrijg de referentie van een knooppunt met behulp van de Index.  
4. Haal de miniatuurafbeelding op.  
5. Sla de miniatuurafbeelding op in een gewenst afbeeldingsformaat.

```java
// Instantieer Presentation‑klasse die het PPTX‑bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // SmartArt toevoegen
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Verkrijg de referentie van een knooppunt met behulp van de index
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

**Worden SmartArt‑animaties ondersteund?**

Ja. SmartArt wordt behandeld als een gewone vorm, dus u kunt [standaardanimaties toepassen](/slides/nl/androidjava/shape-animation/) (ingang, uitgang, nadruk, bewegingspaden) en de timing aanpassen. Indien nodig kunt u ook vormen binnen SmartArt‑knooppunten animeren.

**Hoe kan ik een specifiek SmartArt‑object op een dia betrouwbaar lokaliseren als de interne ID onbekend is?**

Ken een [alternatieve tekst](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getAlternativeText--) toe en zoek daarna. Het instellen van een onderscheidende AltText op de SmartArt maakt het mogelijk om deze programmatisch te vinden zonder te vertrouwen op interne identifiers.

**Wordt het uiterlijk van SmartArt behouden bij het converteren van de presentatie naar PDF?**

Ja. Aspose.Slides rendert SmartArt met hoge visuele nauwkeurigheid tijdens de [PDF‑export](/slides/nl/androidjava/convert-powerpoint-to-pdf/), waarbij lay‑out, kleuren en effecten behouden blijven.

**Kan ik een afbeelding van de volledige SmartArt extraheren (voor voorbeeldweergaven of rapporten)?**

Ja. U kunt een SmartArt‑vorm renderen naar [rasterformaten](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) of naar [SVG](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) voor schaalbare vectoroutput, wat geschikt is voor miniaturen, rapporten of webgebruik.