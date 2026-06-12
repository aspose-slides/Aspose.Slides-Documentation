---
title: Beheer tekstvakken in presentaties op Android
linktitle: Beheer tekstvak
type: docs
weight: 20
url: /nl/androidjava/manage-textbox/
keywords:
- tekstvak
- tekstframe
- tekst toevoegen
- tekst bijwerken
- tekstvak maken
- tekstvak controleren
- tekstkolom toevoegen
- hyperlink toevoegen
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Met Aspose.Slides for Android via Java kunt u eenvoudig tekstvakken maken, bewerken en dupliceren in PowerPoint- en OpenDocument-bestanden, waardoor uw presentatiesautomatisering wordt verbeterd."
---
## **Inleiding**

Teksten op dia's staan doorgaans in tekstvakken of vormen. Daarom moet je, om tekst aan een dia toe te voegen, een tekstvak toevoegen en vervolgens tekst in dat tekstvak plaatsen. Aspose.Slides for Android via Java biedt de [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAutoShape) interface die je in staat stelt een vorm toe te voegen die tekst bevat.

{{% alert title="Info" color="info" %}}
Aspose.Slides biedt ook de [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape) interface die je in staat stelt vormen aan dia’s toe te voegen. Niet alle vormen die via de `IShape` interface worden toegevoegd, kunnen tekst bevatten. Echter, vormen die via de [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAutoShape) interface worden toegevoegd, kunnen wel tekst bevatten.
{{% /alert %}}

{{% alert title="Opmerking" color="warning" %}} 
Daarom, wanneer je met een vorm werkt waaraan je tekst wilt toevoegen, wil je controleren en bevestigen dat deze is gecast naar de `IAutoShape` interface. Alleen dan kun je werken met [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/TextFrame), een eigenschap onder `IAutoShape`. Zie de sectie [Update Text](https://docs.aspose.com/slides/nl/androidjava/manage-textbox/#update-text) op deze pagina.
{{% /alert %}}

## **Maak een tekstvak op een dia**

Om een tekstvak op een dia te maken, doorloop je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
2. Verkrijg een referentie naar de eerste dia in de nieuw aangemaakte presentatie.  
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAutoShape) object toe met [ShapeType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) ingesteld op `Rectangle` op een opgegeven positie op de dia en verkrijg de referentie voor het nieuw toegevoegde `IAutoShape` object.  
4. Voeg een `TextFrame` eigenschap toe aan het `IAutoShape` object die tekst zal bevatten. In het onderstaande voorbeeld hebben we deze tekst toegevoegd: *Aspose TextBox*  
5. Schrijf tenslotte het PPTX‑bestand weg via het `Presentation` object.  

Deze Java‑code – een implementatie van de bovenstaande stappen – toont hoe je tekst aan een dia kunt toevoegen:

```java
// Instantieert Presentation
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia in de presentatie op
    ISlide sld = pres.getSlides().get_Item(0);

    // Voegt een AutoShape toe met type ingesteld op Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Voegt TextFrame toe aan de Rectangle
    ashp.addTextFrame(" ");

    // Benadert het TextFrame
    ITextFrame txtFrame = ashp.getTextFrame();

    // Maakt het Paragraph-object voor het TextFrame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Maakt een Portion-object voor het Paragraph
    IPortion portion = para.getPortions().get_Item(0);

    // Stelt tekst in
    portion.setText("Aspose TextBox");

    // Slaat de presentatie op op de schijf
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Controleer op een tekstvakvorm**

Aspose.Slides levert de [isTextBox](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/#isTextBox--) methode van de [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) interface, waarmee je vormen kunt onderzoeken en tekstvakken kunt identificeren.

![Tekstvak en vorm](istextbox.png)

Deze Java‑code laat zien hoe je kunt controleren of een vorm als tekstvak is aangemaakt: 

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ForEach.shape(presentation, (shape, slide, index) -> {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            System.out.println(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Let op dat als je eenvoudig een autoshape toevoegt met de `addAutoShape` methode van de [IShapeCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/) interface, de `isTextBox` methode van de autoshape `false` zal teruggeven. Nadat je echter tekst aan de autoshape toevoegt met de `addTextFrame` methode of de `setText` methode, geeft de `isTextBox` eigenschap `true` terug.

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() retourneert false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() retourneert true

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() retourneert false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() retourneert true

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() retourneert false
shape3.addTextFrame("");
// shape3.isTextBox() retourneert false

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() retourneert false
shape4.getTextFrame().setText("");
// shape4.isTextBox() retourneert false
```

## **Kolommen toevoegen aan een tekstvak**

Aspose.Slides biedt de eigenschappen [ColumnCount](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) en [ColumnSpacing](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (van de [ITextFrameFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITextFrameFormat) interface en de [TextFrameFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/TextFrameFormat) klasse) die je in staat stellen kolommen toe te voegen aan tekstvakken. Je kunt het aantal kolommen in een tekstvak specificeren en de afstand in punten tussen de kolommen instellen.

Deze Java‑code demonstreert de beschreven bewerking: 

```java
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia in de presentatie op
    ISlide slide = pres.getSlides().get_Item(0);

    // Voeg een AutoShape toe met type ingesteld op Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Voeg TextFrame toe aan de Rectangle
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Haalt het tekstformaat van TextFrame op
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Specificeert het aantal kolommen in TextFrame
    format.setColumnCount(3);

    // Specificeert de afstand tussen kolommen
    format.setColumnSpacing(10);

    // Slaat de presentatie op
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kolommen toevoegen aan een tekstframe**

Aspose.Slides for Android via Java biedt de eigenschap [ColumnCount](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (van de [ITextFrameFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITextFrameFormat) interface) die je in staat stelt kolommen toe te voegen in tekstframes. Met deze eigenschap kun je het gewenste aantal kolommen in een tekstframe opgeven.

Deze Java‑code laat zien hoe je een kolom toevoegt binnen een tekstframe:

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tekst bijwerken**

Aspose.Slides stelt je in staat de tekst in een tekstvak of alle teksten in een presentatie te wijzigen of bij te werken. 

Deze Java‑code demonstreert een bewerking waarbij alle teksten in een presentatie worden bijgewerkt of gewijzigd:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Controleert of de vorm een tekstframe ondersteunt (IAutoShape). 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Itereert door alinea's in het tekstframe
                {
                    for (IPortion portion : paragraph.getPortions()) //Itereert door elk deel in de alinea
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Wijzigt de tekst
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Wijzigt opmaak
                    }
                }
            }
        }
    }

    //Slaat de gewijzigde presentatie op
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tekstvak met hyperlink toevoegen**

Je kunt een koppeling in een tekstvak invoegen. Wanneer op het tekstvak wordt geklikt, wordt de gebruiker naar de link geleid. 

Om een tekstvak met een koppeling toe te voegen, doorloop je de volgende stappen:

1. Maak een instantie van de `Presentation` klasse.  
2. Verkrijg een referentie naar de eerste dia in de nieuw aangemaakte presentatie.  
3. Voeg een `AutoShape` object toe met `ShapeType` ingesteld op `Rectangle` op een opgegeven positie op de dia en verkrijg een referentie naar het nieuw toegevoegde AutoShape object.  
4. Voeg een `TextFrame` toe aan het `AutoShape` object dat *Aspose TextBox* als standaardtekst bevat.  
5. Instantieer de `IHyperlinkManager` klasse.  
6. Wijs het `IHyperlinkManager` object toe aan de [HyperlinkClick](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) eigenschap die gekoppeld is aan het gewenste gedeelte van het `TextFrame`.  
7. Schrijf tenslotte het PPTX‑bestand weg via het `Presentation` object. 

Deze Java‑code – een implementatie van de bovenstaande stappen – toont hoe je een tekstvak met een hyperlink aan een dia kunt toevoegen:

```java
// Instantieert een Presentation-klasse die een PPTX vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia in de presentatie op
    ISlide slide = pres.getSlides().get_Item(0);

    // Voegt een AutoShape-object toe met type ingesteld op Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Cast de vorm naar AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Benadert de ITextFrame-eigenschap die bij de AutoShape hoort
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Voeg wat tekst toe aan het frame
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Stelt de hyperlink in voor de portion-tekst
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Slaat de PPTX-presentatie op
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Wat is het verschil tussen een tekstvak en een tekst‑placeholder bij het werken met masterslides?**

Een [placeholder](/slides/nl/androidjava/manage-placeholder/) erft stijl/positie van de [master](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/masterslide/) en kan worden overschreven op [layouts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/layoutslide/), terwijl een regulier tekstvak een zelfstandig object op een specifieke dia is en niet verandert wanneer je van layout wisselt.

**Hoe kan ik een bulk‑tekstvervanging uitvoeren over de hele presentatie zonder tekst in grafieken, tabellen en SmartArt aan te passen?**

Beperk je iteratie tot auto‑shapes die tekstframes hebben en sluit ingesloten objecten ([charts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/smartart/)) uit door hun collecties afzonderlijk te doorlopen of die objecttypen over te slaan.