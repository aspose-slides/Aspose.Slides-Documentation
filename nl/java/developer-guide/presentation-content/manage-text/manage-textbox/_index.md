---
title: Beheer tekstvakken in presentaties met Java
linktitle: Beheer tekstvak
type: docs
weight: 20
url: /nl/java/manage-textbox/
keywords:
- tekstvak
- tekstframe
- tekst toevoegen
- tekst bijwerken
- tekstvak maken
- tekstvak controleren
- kolom toevoegen
- hyperlink toevoegen
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Aspose.Slides for Java maakt het eenvoudig om tekstvakken te maken, bewerken en klonen in PowerPoint- en OpenDocument-bestanden, waardoor uw presentatie-automatisering verbetert."
---
## **Introductie**

Teksten op dia’s staan doorgaans in tekstvakken of vormen. Daarom moet je, om tekst aan een dia toe te voegen, eerst een tekstvak toevoegen en daarna tekst in dat tekstvak plaatsen. Aspose.Slides for Java biedt de [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAutoShape) interface waarmee je een vorm met tekst kunt toevoegen.

{{% alert title="Info" color="info" %}}

Aspose.Slides biedt ook de [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShape) interface waarmee je vormen aan dia’s kunt toevoegen. Niet alle vormen die via de `IShape` interface worden toegevoegd, kunnen echter tekst bevatten. Vormen die via de [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAutoShape) interface worden toegevoegd, kunnen wel tekst bevatten. 

{{% /alert %}}

{{% alert title="Opmerking" color="warning" %}} 

Wanneer je met een vorm werkt waaraan je tekst wilt toevoegen, moet je controleren of deze via de `IAutoShape` interface is gecast. Alleen dan kun je werken met [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/TextFrame), een eigenschap van `IAutoShape`. Zie de sectie [Update Text](https://docs.aspose.com/slides/nl/java/manage-textbox/#update-text) op deze pagina. 

{{% /alert %}}

## **Maak een tekstvak op een dia**

Om een tekstvak op een dia te maken, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse. 
2. Verkrijg een referentie naar de eerste dia in de nieuw aangemaakte presentatie. 
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAutoShape) object toe met `ShapeType` ingesteld op `Rectangle` op een opgegeven positie op de dia en verkrijg de referentie naar het nieuw toegevoegde `IAutoShape` object. 
4. Voeg de eigenschap `TextFrame` toe aan het `IAutoShape` object zodat het tekst bevat. In het voorbeeld hieronder voegen we deze tekst toe: *Aspose TextBox* 
5. Schrijf ten slotte het PPTX‑bestand via het `Presentation` object. 

Deze Java‑code—een implementatie van de bovenstaande stappen—laat zien hoe je tekst aan een dia toevoegt:

```java
// Instantieert Presentation
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia in de presentatie op
    ISlide sld = pres.getSlides().get_Item(0);

    // Voegt een AutoShape toe met type ingesteld op Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Voegt een TextFrame toe aan de Rectangle
    ashp.addTextFrame(" ");

    // Benadert het tekstframe
    ITextFrame txtFrame = ashp.getTextFrame();

    // Creëert het Paragraph-object voor het tekstframe
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Creëert een Portion-object voor de alinea
    IPortion portion = para.getPortions().get_Item(0);

    // Stelt tekst in
    portion.setText("Aspose TextBox");

    // Slaat de presentatie op naar schijf
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Controleren op een tekstvakvorm**

Aspose.Slides biedt de [isTextBox](https://reference.aspose.com/slides/nl/java/com.aspose.slides/autoshape/#isTextBox--) methode van de [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) interface, waarmee je vormen kunt onderzoeken en tekstvakken kunt identificeren.

![Text box and shape](istextbox.png)

Deze Java‑code toont hoe je controleert of een vorm als tekstvak is aangemaakt: 

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

Merk op dat als je simpelweg een autoshape toevoegt met de `addAutoShape` methode van de [IShapeCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/) interface, de `isTextBox` methode van de autoshape `false` retourneert. Nadat je echter tekst aan de autoshape hebt toegevoegd met de `addTextFrame` methode of de `setText` methode, geeft de `isTextBox` eigenschap `true` terug.

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() geeft false terug
shape1.addTextFrame("shape 1");
// shape1.isTextBox() geeft true terug

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() geeft false terug
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() geeft true terug

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() geeft false terug
shape3.addTextFrame("");
// shape3.isTextBox() geeft false terug

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() geeft false terug
shape4.getTextFrame().setText("");
// shape4.isTextBox() geeft false terug
```

## **Kolommen toevoegen aan een tekstvak**

Aspose.Slides biedt de [ColumnCount](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) en [ColumnSpacing](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) eigenschappen (van de [ITextFrameFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITextFrameFormat) interface en de [TextFrameFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/TextFrameFormat) klasse) waarmee je kolommen aan tekstvakken kunt toevoegen. Je kunt het aantal kolommen in een tekstvak opgeven en de tussenruimte in punten tussen de kolommen instellen. 

Deze Java‑code demonstreert de beschreven handeling: 

```java
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia in de presentatie op
    ISlide slide = pres.getSlides().get_Item(0);

    // Voeg een AutoShape toe met type ingesteld op Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Voeg een TextFrame toe aan de Rectangle
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Haalt het tekstformaat van het TextFrame op
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Bepaalt het aantal kolommen in het TextFrame
    format.setColumnCount(3);

    // Bepaalt de tussenruimte tussen kolommen
    format.setColumnSpacing(10);

    // Slaat de presentatie op
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kolommen toevoegen aan een tekstframe**

Aspose.Slides for Java biedt de [ColumnCount](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) eigenschap (van de [ITextFrameFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITextFrameFormat) interface) waarmee je kolommen in tekstframes kunt toevoegen. Via deze eigenschap kun je het gewenste aantal kolommen in een tekstframe opgeven. 

Deze Java‑code laat zien hoe je een kolom aan een tekstframe toevoegt:

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
                    for (IPortion portion : paragraph.getPortions()) //Itereert door elke portion in de alinea
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Wijzigt de tekst
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Wijzigt de opmaak
                    }
                }
            }
        }
    }

    //Slaat de aangepaste presentatie op
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een tekstvak met een hyperlink toevoegen** 

Je kunt een koppeling in een tekstvak invoegen. Wanneer het tekstvak wordt aangeklikt, wordt de gebruiker naar de koppeling geleid. 

Om een tekstvak met een koppeling toe te voegen, volg je deze stappen:

1. Maak een instantie van de `Presentation` klasse. 
2. Verkrijg een referentie naar de eerste dia in de nieuw aangemaakte presentatie. 
3. Voeg een `AutoShape` object toe met `ShapeType` ingesteld op `Rectangle` op een opgegeven positie op de dia en verkrijg een referentie naar het nieuw toegevoegde AutoShape object. 
4. Voeg een `TextFrame` toe aan het `AutoShape` object dat *Aspose TextBox* als standaardtekst bevat. 
5. Instantieer de `IHyperlinkManager` klasse. 
6. Koppel het `IHyperlinkManager` object aan de [HyperlinkClick](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Shape#getHyperlinkClick--) eigenschap die bij het gewenste gedeelte van het `TextFrame` hoort. 
7. Schrijf ten slotte het PPTX‑bestand via het `Presentation` object. 

Deze Java‑code—een implementatie van de bovenstaande stappen—laat zien hoe je een tekstvak met een hyperlink aan een dia toevoegt:

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

    // Voegt wat tekst toe aan het frame
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

Een [placeholder](/slides/nl/java/manage-placeholder/) erft stijl/positie van de [master](https://reference.aspose.com/slides/nl/java/com.aspose.slides/masterslide/) en kan worden overschreven op [layouts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/layoutslide/), terwijl een regulier tekstvak een onafhankelijk object is op een specifieke dia en niet verandert wanneer je van layout wisselt.

**Hoe kan ik een bulk‑tekstvervanging uitvoeren in de hele presentatie zonder tekst in grafieken, tabellen en SmartArt aan te raken?**

Beperk je iteratie tot auto‑shapes die tekstframes hebben en sluit ingebedde objecten ([charts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/nl/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/smartart/)) uit door hun collecties afzonderlijk te doorlopen of die objecttypen over te slaan.