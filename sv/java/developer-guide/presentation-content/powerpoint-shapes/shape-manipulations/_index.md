---
title: Hantera presentationsformer i Java
linktitle: Formhantering
type: docs
weight: 40
url: /sv/java/shape-manipulations/
keywords:
- PowerPoint-form
- presentationsform
- form på bild
- hitta form
- klona form
- ta bort form
- dölj form
- ändra formordning
- hämta Interop-form-ID
- alternativ text för form
- form-layoutformat
- form som SVG
- form till SVG
- justera form
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig skapa, redigera och optimera former i Aspose.Slides för Java och leverera högpresterande PowerPoint-presentationer."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med former i presentationer med Aspose.Slides. Den visar hur man hittar en form på en bild, klonar den, tar bort den, döljer den, ändrar dess ordning, hämtar dess Interop‑form‑ID och anger alternativ text för identifiering och vidare bearbetning.

Den täcker också hur man får åtkomst till layoutformat för former, renderar en form som SVG, justerar former på en bild och använder flip‑egenskaper för horisontell och vertikal spegling. Dessutom innehåller artikeln en kort FAQ om kombination av former, staplingsordning och låsning av former.

## **Hitta en form på en bild**
Detta avsnitt beskriver en enkel teknik för att underlätta för utvecklare att hitta en specifik form på en bild utan att använda dess interna Id. Det är viktigt att veta att PowerPoint‑presentationsfiler inte har något sätt att identifiera former på en bild förutom ett internt unikt Id. Det kan vara svårt för utvecklare att hitta en form med dess interna unika Id. Alla former som läggs till i bilderna har någon alt‑text. Vi föreslår att utvecklare använder alternativ text för att hitta en specifik form. Du kan använda MS PowerPoint för att definiera den alternativa texten för objekt som du planerar att ändra i framtiden.

Efter att du har angett den alternativa texten för någon önskad form kan du öppna presentationen med Aspose.Slides för Java och iterera genom alla former som lagts till på en bild. Under varje iteration kan du kontrollera formens alternativa text och den form vars alternativa text matchar är den du söker. För att demonstrera denna teknik på ett bättre sätt har vi skapat en metod, [findShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) som gör det möjligt att hitta en specifik form på en bild och sedan helt enkelt returnerar den formen.

```java
// Skapa en Presentation-klass som representerar presentationsfilen
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // Alternativ text för formen som ska hittas
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
// Metodimplementation för att hitta en form i en bild med dess alternativa text
public static IShape findShape(ISlide slide, String alttext)
{
    // Itererar genom alla former i bilden
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Om bildens alternativa text matchar den önskade
        // Returnera formen
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **Klona en form**
För att klona en form till en bild med Aspose.Slides för Java:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Hämta referensen till en bild genom att använda dess index.
1. Få åtkomst till källbildens form‑samling.
1. Lägg till en ny bild i presentationen.
1. Klona former från källbildens form‑samling till den nya bilden.
1. Spara den ändrade presentationen som en PPTX‑fil.

Exemplet nedan lägger till en gruppform på en bild.

```java
// Instansiera Presentation-klassen
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // Skriv PPTX-filen till disk
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ta bort en form**
Aspose.Slides för Java låter utvecklare ta bort vilken form som helst. Följ stegen nedan för att ta bort formen från en bild:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Få åtkomst till den första bilden.
1. Hitta formen med specifik AlternativeText.
1. Ta bort formen.
1. Spara filen till disk.

```java
// Skapa Presentation-objekt
Presentation pres = new Presentation();
try {
    // Hämta första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Lägg till autoshape av rektangulär typ
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

    // Spara presentation till disk
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dölj en form**
Aspose.Slides för Java låter utvecklare dölja vilken form som helst. Följ stegen nedan för att dölja formen på en bild:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Få åtkomst till den första bilden.
1. Hitta formen med specifik AlternativeText.
1. Dölj formen.
1. Spara filen till disk.

```java
// Instansiera Presentation-klass som representerar PPTX
Presentation pres = new Presentation();
try {
    // Hämta den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Lägg till autoshape av rektangeltyp
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

    // Spara presentation till disk
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ändra formens ordning**
Aspose.Slides för Java låter utvecklare ändra ordningen på formerna. Att ändra ordning på en form anger vilken form som ligger framför och vilken som ligger längst bak. Följ stegen nedan för att ändra ordningen på en form på en bild:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Få åtkomst till den första bilden.
1. Lägg till en form.
1. Lägg till lite text i formens textruta.
1. Lägg till en annan form med samma koordinater.
1. Ändra ordningen på formerna.
1. Spara filen till disk.

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

## **Hämta Interop‑form‑ID**
Aspose.Slides för Java låter utvecklare hämta en unik formidentifierare på bildnivå, i motsats till metoden [getUniqueId](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShape#getUniqueId--) som ger ett unikt identifierare på presentationsnivå. Metoden [getOfficeInteropShapeId](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) har lagts till i gränssnittet [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShape) och klassen [Shape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Shape). Värdet som returneras av metoden [getOfficeInteropShapeId](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) motsvarar Id‑värdet för Microsoft.Office.Interop.PowerPoint.Shape‑objektet. Nedan visas ett exempel på kod.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Hämtar unik formidentifierare i bildomfång
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Ange alternativ text för en form**
Aspose.Slides för Java låter utvecklare ange AlternateText för vilken form som helst.
Former i en presentation kan särskiljas med metoden [AlternativeText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) eller [Shape Name](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShape#setName-java.lang.String-).
Metoderna [setAlternativeText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) och [getAlternativeText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShape#getAlternativeText--) kan läsas eller sättas med Aspose.Slides såväl som Microsoft PowerPoint.
Genom att använda denna metod kan du märka en form och utföra olika operationer som att ta bort en form,
dölja en form eller ändra ordning på former på en bild.
För att ange AlternateText för en form, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Få åtkomst till den första bilden.
1. Lägg till någon form på bilden.
1. Utför någon åtgärd med den nyligen tillagda formen.
1. Gå igenom formerna för att hitta en form.
1. Ange AlternativeText.
1. Spara filen till disk.

```java
// Instansiera Presentation-klass som representerar PPTX
Presentation pres = new Presentation();
try {
    // Hämta den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Lägg till autoshape av rektangulär typ
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

    // Spara presentation till disk
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Få åtkomst till layoutformat för en form**
Aspose.Slides för Java tillhandahåller ett enkelt API för att få åtkomst till layoutformat för en form. Denna artikel visar hur du kan komma åt layoutformat.

Nedan visas ett exempel på kod.

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

## **Rendera en form som SVG**
Nu har Aspose.Slides för Java stöd för att rendera en form som SVG. Metoden [writeAsSvg](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (och dess överlagring) har lagts till i klassen [Shape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Shape) och gränssnittet [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShape). Denna metod möjliggör att spara formens innehåll som en SVG‑fil. Kodsnutten nedan visar hur du exporterar en bilds form till en SVG‑fil.

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

## **Justera en form**
Aspose.Slides låter dig justera former antingen i förhållande till bildens marginaler eller i förhållande till varandra. För detta ändamål har den överlagrade metoden [SlidesUtil.alignShape()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) lagts till. Enum‑typen [ShapesAlignmentType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ShapesAlignmentType) definierar möjliga justeringsalternativ.

**Exempel 1**

Källkoden nedan justerar former med index 1, 2 och 4 längs bildens överkant.

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

**Exempel 2**

Exemplet nedan visar hur du justerar hela samlingen av former i förhållande till den nedersta formen i samlingen.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **Flip‑egenskaper**

I Aspose.Slides ger klassen [ShapeFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shapeframe/) kontroll över horisontell och vertikal spegling av former via dess egenskaper `flipH` och `flipV`. Båda egenskaperna är av typen `byte` och kan ha värdena `1` för att indikera en spegling, `0` för ingen spegling eller `-1` för att använda standardbeteendet. Dessa värden är åtkomliga via en forms [Frame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getFrame--).

För att ändra flip‑inställningarna konstrueras en ny [ShapeFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shapeframe/)-instans med formens aktuella position och storlek, önskade värden för `flipH` och `flipV` samt rotationsvinkeln. Genom att tilldela denna instans till formens [Frame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getFrame--) och spara presentationen appliceras speglingstransformationerna och de sparas i utskriftsfilen.

Låt oss säga att vi har en fil sample.pptx där den första bilden innehåller en enda form med standardinställningarna för flip, som visas nedan.

![Formen som ska speglas](shape_to_be_flipped.png)

Följande kodexempel hämtar formens aktuella flip‑egenskaper och speglar den både horisontellt och vertikalt.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // Hämta den horisontella flip-egenskapen för formen.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // Hämta den vertikala flip-egenskapen för formen.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // Flip horizontally.
    byte flipV = NullableBool.True; // Flip horizontally.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Den speglade formen](flipped_shape.png)

## **FAQ**

**Kan jag kombinera former (union/intersect/subtract) på en bild som i en skrivbordsredigerare?**

Det finns ingen inbyggd API för Boolean‑operationer. Du kan approximera det genom att själv konstruera den önskade konturen – t.ex. beräkna den resulterande geometrin (via [GeometryPath](https://reference.aspose.com/slides/sv/java/com.aspose.slides/geometrypath/)) och skapa en ny form med den konturen, eventuellt ta bort de ursprungliga.

**Hur kan jag kontrollera staplingsordningen (z‑order) så att en form alltid förblir "överst"?**

Ändra insättnings‑/flyttordningen i bildens [shapes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/baseslide/#getShapes--)‑samling. För förutsägbara resultat, slutför z‑ordningen efter alla andra bildändringar.

**Kan jag "låsa" en form för att förhindra att användare redigerar den i PowerPoint?**

Ja. Ställ in [formnivåens skyddsflaggor](/slides/sv/java/applying-protection-to-presentation/) (t.ex. lås markering, flytt, storleksändring, textredigering). Vid behov spegla restriktionerna på mallen eller layouten. Observera att detta är skydd på UI‑nivå, inte en säkerhetsfunktion; för starkare skydd kombinera med filnivårestriktioner såsom [rekommendationer för skrivskydd eller lösenord](/slides/sv/java/password-protected-presentation/).