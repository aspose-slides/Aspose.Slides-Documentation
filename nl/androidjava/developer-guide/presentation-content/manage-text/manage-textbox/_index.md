---
title: Tekstvakken beheren in presentaties op Android
linktitle: Tekstvak beheren
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
description: "Aspose.Slides for Android via Java maakt het eenvoudig om tekstvakken te maken, bewerken en klonen in PowerPoint- en OpenDocument-bestanden, waardoor je presentatie-automatisering wordt verbeterd."
---
## **Inleiding**

Teksten op dia's bestaan doorgaans in tekstvakken of vormen. Daarom moet je, om tekst aan een dia toe te voegen, eerst een tekstvak toevoegen en vervolgens wat tekst in het tekstvak plaatsen. Aspose.Slides voor Android via Java biedt de [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAutoShape)‑interface waarmee je een vorm met tekst kunt toevoegen.

{{% alert title="Info" color="info" %}}
Aspose.Slides biedt ook de [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape)‑interface waarmee je vormen aan dia's kunt toevoegen. Niet alle vormen die via de `IShape`‑interface worden toegevoegd, kunnen echter tekst bevatten. Vormen die via de [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAutoShape)‑interface worden toegevoegd, kunnen wel tekst bevatten.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Wanneer je een vorm wilt gebruiken waaraan je tekst wilt toevoegen, moet je controleren of deze is gecast naar de `IAutoShape`‑interface. Alleen dan kun je werken met [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/TextFrame), een eigenschap van `IAutoShape`. Zie de sectie [Update Text](https://docs.aspose.com/slides/nl/androidjava/manage-textbox/#update-text) op deze pagina.
{{% /alert %}}

## **Maak een tekstvak op een dia**

Om een tekstvak op een dia te maken, volg je deze stappen:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
2. Verkrijg een referentie naar de eerste dia in de nieuw aangemaakte presentatie. 
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAutoShape)‑object toe met [ShapeType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) ingesteld op `Rectangle` op een opgegeven positie op de dia en verkrijg de referentie naar het nieuw toegevoegde `IAutoShape`‑object.
4. Voeg de eigenschap `TextFrame` toe aan het `IAutoShape`‑object om tekst te bevatten. In het onderstaande voorbeeld hebben we deze tekst toegevoegd: *Aspose TextBox*
5. Schrijf uiteindelijk het PPTX‑bestand via het `Presentation`‑object. 

Deze Java‑code – een implementatie van de bovenstaande stappen – laat zien hoe je tekst aan een dia toevoegt:

```java
import com.aspose.slides.*;

// Maakt een Presentation aan
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia op in de presentatie
    ISlide sld = pres.getSlides().get_Item(0);

    // Voegt een AutoShape toe met type Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Voegt een TextFrame toe aan de rechthoek
    ashp.addTextFrame(" ");

    // Toegang tot het tekstframe
    ITextFrame txtFrame = ashp.getTextFrame();

    // Creëert het Paragraph‑object voor het tekstframe
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Creëert een Portion‑object voor de alinea
    IPortion portion = para.getPortions().get_Item(0);

    // Stelt de tekst in
    portion.setText("Aspose TextBox");

    // Slaat de presentatie op naar schijf
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Controleren op een tekstvak‑vorm**

Aspose.Slides biedt de [isTextBox](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/#isTextBox--)‑methode van de [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/)‑interface, waarmee je vormen kunt onderzoeken en tekstvakken kunt identificeren.

![Tekstvak en vorm](istextbox.png)

Deze Java‑code toont hoe je kunt controleren of een vorm als tekstvak is aangemaakt: 

```java
import com.aspose.slides.*;

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

Merk op dat als je simpelweg een auto‑shape toevoegt met de `addAutoShape`‑methode van de [IShapeCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/)‑interface, de `isTextBox`‑methode van de auto‑shape `false` retourneert. Nadat je echter tekst aan de auto‑shape hebt toegevoegd met de `addTextFrame`‑methode of de `setText`‑methode, geeft de eigenschap `isTextBox` `true` terug.

```java
import com.aspose.slides.*;

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

## **Vind de vorm die een tekstframe bezit**

In generieke tekstverwerkingscode kun je een [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) ontvangen zonder te weten welke presentatiedeel het bevat. Gebruik de [ITextFrame.getParentShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#getParentShape--)‑methode om terug te navigeren naar de eigende [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/).

Voor een tekstframe dat behoort tot een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) of een andere vorm die tekst bevat, retourneert [ITextFrame.getParentShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#getParentShape--) de eigenaar en retourneert [ITextFrame.getParentCell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#getParentCell--) `null`. Beide methoden bieden alleen‑lezen navigatie; het aanroepen ervan verandert de eigendom niet. Controleer altijd of de geretourneerde waarde `null` is voordat je de vorm benadert.

Voor een volledig voorbeeld dat vorm‑ en tabelcel‑eigenaars identificeert, inclusief vormen die bij SmartArt‑knooppunten horen, zie [Search and Replace Text](/slides/nl/androidjava/search-and-replace-text/).

## **Kolommen toevoegen aan een tekstvak**

Aspose.Slides biedt de eigenschappen [ColumnCount](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) en [ColumnSpacing](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (van de [ITextFrameFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITextFrameFormat)‑interface en de [TextFrameFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/TextFrameFormat)‑klasse) waarmee je kolommen aan tekstvakken kunt toevoegen. Je kunt het aantal kolommen in een tekstvak opgeven en de tussenruimte in punten tussen de kolommen instellen.

Deze Java‑code demonstreert de beschreven bewerking: 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Haalt de eerste dia op in de presentatie
    ISlide slide = pres.getSlides().get_Item(0);

    // Voeg een AutoShape toe met als type Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Voeg een TextFrame toe aan de rechthoek
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Haalt het tekstopmaak op van het TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Specificeert het aantal kolommen in het TextFrame
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
Aspose.Slides voor Android via Java biedt de eigenschap [ColumnCount](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (van de [ITextFrameFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITextFrameFormat)‑interface) waarmee je kolommen in tekstframes kunt toevoegen. Via deze eigenschap kun je het gewenste aantal kolommen in een tekstframe opgeven.

Deze Java‑code laat zien hoe je een kolom toevoegt aan een tekstframe:

```java
import com.aspose.slides.*;

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
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) // Controleert of de vorm een tekstframe ondersteunt (IAutoShape). 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) // Itereert door alinea's in het tekstframe
                {
                    for (IPortion portion : paragraph.getPortions()) // Itereert door elk gedeelte in de alinea
                    {
                        portion.setText(portion.getText().replace("years", "months")); // Wijzigt de tekst
                        portion.getPortionFormat().setFontBold(NullableBool.True); // Wijzigt de opmaak
                    }
                }
            }
        }
    }

    // Slaat de gewijzigde presentatie op
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een tekstvak met een hyperlink toevoegen** 

Je kunt een koppeling invoegen in een tekstvak. Wanneer het tekstvak wordt aangeklikt, worden gebruikers naar de koppeling geleid. 

Om een tekstvak met een koppeling toe te voegen, volg je deze stappen:

1. Maak een instantie van de `Presentation`‑klasse. 
2. Verkrijg een referentie naar de eerste dia in de nieuw aangemaakte presentatie. 
3. Voeg een `AutoShape`‑object toe met `ShapeType` ingesteld op `Rectangle` op een opgegeven positie op de dia en verkrijg een referentie naar het nieuw toegevoegde AutoShape‑object.
4. Voeg een `TextFrame` toe aan het `AutoShape`‑object en stel de tekst van het eerste gedeelte in. In het onderstaande voorbeeld gebruikten we deze tekst: *Aspose.Slides*
5. Verkrijg het [IHyperlinkManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlinkmanager/)‑object van de `PortionFormat` van het gewenste gedeelte van het `TextFrame`.
6. Roep [setExternalHyperlinkClick](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) aan op dat object om de koppeling in te stellen die wordt geopend wanneer op de tekst wordt geklikt.
7. Schrijf uiteindelijk het PPTX‑bestand via het `Presentation`‑object. 

Deze Java‑code – een implementatie van de bovenstaande stappen – laat zien hoe je een tekstvak met een hyperlink aan een dia toevoegt:

```java
import com.aspose.slides.*;

// Instantieert een Presentation-klasse die een PPTX vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia op in de presentatie
    ISlide slide = pres.getSlides().get_Item(0);

    // Voegt een AutoShape object toe met type Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Cast de vorm naar AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Benadert de ITextFrame eigenschap die bij de AutoShape hoort
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Voegt wat tekst toe aan het frame
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Stelt de hyperlink in voor de tekst van het gedeelte
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Slaat de PPTX presentatie op
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Wat is het verschil tussen een tekstvak en een tekst‑placeholder bij het werken met masterslides?**

Een [placeholder](/slides/nl/androidjava/manage-placeholder/) erft stijl/positie van de [master](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/masterslide/) en kan op [layouts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/layoutslide/) worden overschreven, terwijl een regulier tekstvak een onafhankelijk object is op een specifieke dia en niet verandert wanneer je van layout wisselt.

**Hoe kan ik een bulk‑tekstvervanging uitvoeren in de hele presentatie zonder tekst in grafieken, tabellen en SmartArt aan te raken?**

Beperk je iteratie tot auto‑shapes die tekstframes bevatten en sluit ingesloten objecten uit ([charts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/smartart/)) door hun collecties afzonderlijk te doorlopen of die objecttypen over te slaan.