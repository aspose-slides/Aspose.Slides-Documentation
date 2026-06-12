---
title: Beheer presentatievormen op Android
linktitle: Vormmanipulatie
type: docs
weight: 40
url: /nl/androidjava/shape-manipulations/
keywords:
- PowerPoint-vorm
- presentatie-vorm
- vorm op dia
- vorm vinden
- vorm klonen
- vorm verwijderen
- vorm verbergen
- vormvolgorde wijzigen
- interop-vorm-ID ophalen
- alternatieve tekst van vorm
- vorm lay-outformaten
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u vormen maakt, bewerkt en optimaliseert in Aspose.Slides for Android via Java en high-performance PowerPoint-presentaties levert."
---
## **Overzicht**

Dit artikel legt uit hoe u met vormen in presentaties kunt werken met Aspose.Slides. Het laat zien hoe u een vorm op een dia kunt vinden, klonen, verwijderen, verbergen, de volgorde kunt wijzigen, de Interop‑vorm‑ID kunt ophalen en alternatieve tekst kunt instellen voor identificatie en verdere verwerking.

Het behandelt ook hoe u lay-outformaten voor vormen kunt benaderen, een vorm als SVG kunt renderen, vormen op een dia kunt uitlijnen en spiegelings‑eigenschappen voor horizontaal en verticaal gebruik kunt toepassen. Daarnaast bevat het een korte FAQ over het combineren van vormen, stapelvolgorde en vergrendelen van vormen.

## **Een Vorm op een Dia Vinden**
Dit onderwerp beschrijft een eenvoudige techniek om het voor ontwikkelaars gemakkelijker te maken een specifieke vorm op een dia te vinden zonder de interne Id te gebruiken. Het is belangrijk te weten dat PowerPoint‑presentatiebestanden geen andere manier hebben om vormen op een dia te identificeren behalve een interne unieke Id. Het blijkt moeilijk voor ontwikkelaars om een vorm te vinden met de interne unieke Id. Alle vormen die aan de dia’s worden toegevoegd hebben enige alternatieve tekst. We bevelen ontwikkelaars aan om alternatieve tekst te gebruiken om een specifieke vorm te vinden. U kunt MS PowerPoint gebruiken om de alternatieve tekst voor objecten te definiëren die u in de toekomst wilt wijzigen.

Nadat u de alternatieve tekst van een gewenste vorm heeft ingesteld, kunt u die presentatie openen met Aspose.Slides for Android via Java en alle vormen op een dia doorlopen. Tijdens elke iteratie kunt u de alternatieve tekst van de vorm controleren; de vorm met de overeenkomende alternatieve tekst is de gewenste vorm. Om deze techniek beter te demonstreren, hebben we een methode, [findShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) gemaakt die de truc uitvoert om een specifieke vorm in een dia te vinden en vervolgens die vorm retourneert.

```java
// Instantieer een Presentation‑klasse die het presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // Alternatieve tekst van de te vinden vorm
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Methode-implementatie om een vorm in een dia te vinden met behulp van de alternatieve tekst
public static IShape findShape(ISlide slide, String alttext)
{
    // Itereren door alle vormen in de dia
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Als de alternatieve tekst van de vorm overeenkomt met de vereiste, dan
        // Retourneer de vorm
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **Een Vorm Kluwen**
Om een vorm naar een dia te klonen met Aspose.Slides for Android via Java:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
1. Verkrijg de referentie van een dia via de index.
1. Benader de vormcollectie van de bron‑dia.
1. Voeg een nieuwe dia toe aan de presentatie.
1. Kloon vormen uit de bron‑dia‑vormcollectie naar de nieuwe dia.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Het voorbeeld hieronder voegt een groepsvorm toe aan een dia.

```java
// Instantieer Presentation klasse
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // Schrijf het PPTX bestand naar schijf
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een Vorm Verwijderen**
Aspose.Slides for Android via Java stelt ontwikkelaars in staat om elke vorm te verwijderen. Volg de onderstaande stappen om de vorm van een dia te verwijderen:

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
1. Benader de eerste dia.
1. Zoek de vorm met specifieke AlternativeText.
1. Verwijder de vorm.
1. Sla het bestand op naar schijf.

```java
// Maak Presentation object aan
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);

    // Voeg een autoshape van rechthoektype toe
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // Sla presentatie op op schijf
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een Vorm Verbergen**
Aspose.Slides for Android via Java stelt ontwikkelaars in staat om elke vorm te verbergen. Volg de onderstaande stappen om de vorm op een dia te verbergen:

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
1. Benader de eerste dia.
1. Zoek de vorm met specifieke AlternativeText.
1. Verberg de vorm.
1. Sla het bestand op naar schijf.

```java
// Instantieer de Presentation‑klasse die de PPTX vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);

    // Voeg een autoshape van rechthoektype toe
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // Sla de presentatie op op schijf
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vormvolgorde Wijzigen**
Aspose.Slides for Android via Java stelt ontwikkelaars in staat om de volgorde van vormen te wijzigen. Het wijzigen van de volgorde bepaalt welke vorm vooraan en welke achteraan staat. Volg de onderstaande stappen om de volgorde van de vormen op een dia te wijzigen:

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
1. Benader de eerste dia.
1. Voeg een vorm toe.
1. Voeg tekst toe aan het tekstkader van de vorm.
1. Voeg een andere vorm toe met dezelfde coördinaten.
1. Wijzig de volgorde van de vormen.
1. Sla het bestand op naar schijf.

```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **De Interop‑Vorm‑ID Ophalen**
Aspose.Slides for Android via Java stelt ontwikkelaars in staat om een uniek vorm‑identificatie‑nummer binnen de dia‑scope te verkrijgen, in tegenstelling tot de [getUniqueId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape#getUniqueId--)‑methode, die een uniek identificatie‑nummer binnen de presentatie‑scope oplevert. De methode [getOfficeInteropShapeId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) is toegevoegd aan de [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape)‑interfaces en de [Shape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Shape)‑klasse. De waarde die wordt geretourneerd door [getOfficeInteropShapeId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) komt overeen met de Id‑waarde van het Microsoft.Office.Interop.PowerPoint.Shape‑object. Hieronder staat een voorbeeldcode.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Unieke vormidentificatie ophalen in dia‑scope
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Alternatieve Tekst voor een Vorm Instellen**
Aspose.Slides for Android via Java stelt ontwikkelaars in staat om de AlternateText van elke vorm in te stellen. Vormen in een presentatie kunnen worden onderscheiden via de [AlternativeText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) of [Shape Name](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape#setName-java.lang.String-)‑methode. De methoden [setAlternativeText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) en [getAlternativeText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape#getAlternativeText--) kunnen worden gelezen of ingesteld met zowel Aspose.Slides als Microsoft PowerPoint. Met deze methode kunt u een vorm taggen en verschillende bewerkingen uitvoeren, zoals een vorm verwijderen, verbergen of de volgorde van vormen op een dia wijzigen. Volg de onderstaande stappen om de AlternateText van een vorm in te stellen:

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
1. Benader de eerste dia.
1. Voeg een willekeurige vorm toe aan de dia.
1. Voer enige bewerking uit met de nieuw toegevoegde vorm.
1. Doorloop de vormen om een vorm te vinden.
1. Stel de AlternativeText in.
1. Sla het bestand op naar schijf.

```java
// Instantieer Presentation‑klasse die de PPTX vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);

    // Voeg een autoshape van rechthoektype toe
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // Sla presentatie op op schijf
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lay‑outformaten voor een Vorm Benaderen**
Aspose.Slides for Android via Java biedt een eenvoudige API om lay‑outformaten voor een vorm te benaderen. Dit artikel demonstreert hoe u lay‑outformaten kunt benaderen.

Hieronder staat voorbeeldcode.

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een Vorm als SVG Renderen**
Nu ondersteunt Aspose.Slides for Android via Java het renderen van een vorm als SVG. De methode [writeAsSvg](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (en een overload) is toegevoegd aan de [Shape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Shape)‑klasse en de [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape)‑interface. Deze methode maakt het mogelijk de inhoud van de vorm op te slaan als een SVG‑bestand. De onderstaande code‑fragment toont hoe u de vorm van een dia naar een SVG‑bestand exporteert.

```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een Vorm Uitlijnen**
Aspose.Slides maakt het mogelijk vormen uit te lijnen ten opzichte van de dia‑marges of ten opzichte van elkaar. Hiervoor is de overladen methode [SlidesUtil.alignShape()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) toegevoegd. De enumeratie [ShapesAlignmentType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ShapesAlignmentType) definieert de mogelijke uitlijningsopties.

**Voorbeeld 1**

De onderstaande broncode lijnt vormen met index 1, 2 en 4 uit langs de bovenrand van de dia uit.

```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```

**Voorbeeld 2**

Het voorbeeld hieronder toont hoe u de volledige collectie vormen uitlijnt ten opzichte van de onderste vorm in de collectie.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **Spiegelings‑Eigenschappen**

In Aspose.Slides biedt de [ShapeFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shapeframe/)‑klasse controle over horizontale en verticale spiegeling van vormen via de eigenschappen `flipH` en `flipV`. Beide eigenschappen zijn van het type `byte` en kunnen de waarden `1` (spiegel), `0` (geen spiegel) of `-1` (standaardgedrag) aannemen. Deze waarden zijn toegankelijk via het [Frame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getFrame--) van een vorm.

Om de spiegelinstellingen te wijzigen, wordt een nieuwe [ShapeFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shapeframe/)‑instantie gecreëerd met de huidige positie en grootte van de vorm, de gewenste waarden voor `flipH` en `flipV`, en de rotatiehoek. Deze instantie wordt aan het [Frame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getFrame--) van de vorm toegewezen en het opslaan van de presentatie past de spiegeltransformaties toe en schrijft ze naar het uitvoerbestand.

Stel dat we een bestand sample.pptx hebben waarin de eerste dia één enkele vorm bevat met de standaard spiegelinstellingen, zoals hieronder weergegeven.

![The shape to be flipped](shape_to_be_flipped.png)

De volgende code‑voorbeeld haalt de huidige spiegel‑eigenschappen van de vorm op en spiegelt deze zowel horizontaal als verticaal.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // Haalt de horizontale flip‑eigenschap van de vorm op.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // Haalt de verticale flip‑eigenschap van de vorm op.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // Flip horizontaal.
    byte flipV = NullableBool.True; // Flip horizontaal.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Kan ik vormen combineren (union/intersect/subtract) op een dia zoals in een desktop‑editor?**

Er is geen ingebouwde Boolean‑operatie‑API. U kunt dit benaderen door zelf de gewenste omtrek te construeren — bijv. de resulterende geometrie berekenen (via [GeometryPath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/geometrypath/)) en een nieuwe vorm met die contour maken, eventueel de origineel verwijderen.

**Hoe kan ik de stapelvolgorde (z‑order) regelen zodat een vorm altijd “bovenop” blijft?**

Wijzig de invoeg‑/verplaatsvolgorde binnen de [shapes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseslide/#getShapes--)‑collectie van de dia. Voor voorspelbare resultaten dient de z‑order pas na alle andere dia‑wijzigingen definitief te worden gesteld.

**Kan ik een vorm “vergrendelen” zodat gebruikers deze niet kunnen bewerken in PowerPoint?**

Ja. Stel vorm‑specifieke beschermingsvlaggen in (bijv. selectie, verplaatsing, grootte wijzigen, tekstbewerking). Indien nodig, spiegel de beperkingen op de master‑ of lay‑out‑dia. Let op: dit is een UI‑bescherming, geen veiligheidsfunctie; voor sterkere bescherming combineert u dit met bestands‑niveau restricties zoals [read‑only‑aanbevelingen of wachtwoorden](/slides/nl/androidjava/password-protected-presentation/).