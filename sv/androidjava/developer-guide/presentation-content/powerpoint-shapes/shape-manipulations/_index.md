---
title: Hantera presentationsformer på Android
linktitle: Formhantering
type: docs
weight: 40
url: /sv/androidjava/shape-manipulations/
keywords:
- PowerPoint-form
- presentationsform
- form på bild
- hitta form
- klona form
- ta bort form
- dölj form
- ändra formordning
- hämta interop-form-ID
- alternativ text för form
- formens layoutformat
- form som SVG
- form till SVG
- justera form
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig skapa, redigera och optimera former i Aspose.Slides för Android via Java och leverera högpresterande PowerPoint-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med former i presentationer med Aspose.Slides. Den visar hur man hittar en form på en bild, klonar den, tar bort den, döljer den, ändrar dess ordning, hämtar dess Interop‑form‑ID och anger alternativ text för identifiering och vidare bearbetning.

Den behandlar också hur man får åtkomst till layoutformat för former, renderar en form som SVG, justerar former på en bild och använder vändningsegenskaper för horisontell och vertikal spegling. Dessutom innehåller artikeln en kort FAQ om kombination av former, stapelordning och låsning av former.

## **Hitta en form på en bild**

Detta ämne beskriver en enkel teknik för att göra det enklare för utvecklare att hitta en specifik form på en bild utan att använda dess interna ID. Det är viktigt att veta att PowerPoint‑presentationer saknar något sätt att identifiera former på en bild förutom ett internt unikt ID. Det kan vara svårt för utvecklare att hitta en form med dess interna unika ID. Alla former som läggs till på bilderna har någon alt‑text. Vi föreslår att utvecklare använder alternativ text för att hitta en specifik form. Du kan använda MS PowerPoint för att definiera den alternativa texten för objekt som du planerar att ändra i framtiden.

Efter att du har angett den alternativa texten för önskad form kan du öppna presentationen med Aspose.Slides för Android via Java och iterera genom alla former som lagts till på en bild. Vid varje iteration kan du kontrollera formens alternativa text och den form vars alternativa text matchar är den form du söker. För att demonstrera tekniken på ett bättre sätt har vi skapat en metod, [findShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) som gör det möjligt att hitta en specifik form på en bild och sedan helt enkelt returnerar den formen.

```java
// Instansiera en Presentation-klass som representerar presentationsfilen
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
    // Iterera genom alla former i bilden
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Om bildens alternativa text matchar den önskade så
        // Returnera formen
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **Klona en form**

För att klona en form till en bild med Aspose.Slides för Android via Java:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Hämta referensen till en bild genom att använda dess index.
3. Åtkomst till källbildens formsamling.
4. Lägg till en ny bild i presentationen.
5. Klona former från källbildens formsamling till den nya bilden.
6. Spara den modifierade presentationen som en PPTX‑fil.

Exemplet nedan lägger till en gruppform på en bild.

```java
// Instansiera Presentation-klass
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

Aspose.Slides för Android via Java låter utvecklare ta bort vilken form som helst. För att ta bort en form från en bild, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)‑klassen.
2. Åtkomst till den första bilden.
3. Hitta formen med specifik AlternativeText.
4. Ta bort formen.
5. Spara filen till disk.

```java
// Skapa Presentation-objekt
Presentation pres = new Presentation();
try {
    // Hämta den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Lägg till automatiskt form av rektangeltyp
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

Aspose.Slides för Android via Java låter utvecklare dölja vilken form som helst. För att dölja formen från en bild, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)‑klassen.
2. Åtkomst till den första bilden.
3. Hitta formen med specifik AlternativeText.
4. Dölj formen.
5. Spara filen till disk.

```java
// Instansiera Presentation-klass som representerar PPTX
Presentation pres = new Presentation();
try {
    // Hämta den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Lägg till automatiskt form av rektangeltyp
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

## **Ändra formordning**

Aspose.Slides för Android via Java låter utvecklare omordna formerna. Att omordna formen anger vilken form som är i framkant eller vilken som är baktill. För att omordna formen från en bild, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)‑klassen.
2. Åtkomst till den första bilden.
3. Lägg till en form.
4. Lägg till lite text i formens textruta.
5. Lägg till en annan form med samma koordinater.
6. Omordna formerna.
7. Spara filen till disk.

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

Aspose.Slides för Android via Java låter utvecklare hämta en unik formidentifierare på bildnivå i motsats till metoden [getUniqueId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShape#getUniqueId--) som ger ett unikt ID på presentationsnivå. Metoden [getOfficeInteropShapeId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) har lagts till i interface [IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShape) och klassen [Shape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Shape) respektive. Värdet som returneras av [getOfficeInteropShapeId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) motsvarar ID‑värdet för Microsoft.Office.Interop.PowerPoint.Shape‑objektet. Nedan ges ett exempel på kod.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Hämtar unik formidentifierare på bildnivå
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Ange alternativ text för en form**

Aspose.Slides för Android via Java låter utvecklare ange AlternateText för en form. Former i en presentation kan särskiljas med metoden [AlternativeText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) eller [Shape Name](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShape#setName-java.lang.String-) . Metoderna [setAlternativeText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) och [getAlternativeText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShape#getAlternativeText--) kan läsas eller sättas med Aspose.Slides såväl som Microsoft PowerPoint. Genom att använda denna metod kan du märka en form och utföra olika operationer såsom att ta bort en form, dölja en form eller omordna former på en bild. För att ange AlternateText för en form, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)‑klassen.
2. Åtkomst till den första bilden.
3. Lägg till någon form på bilden.
4. Utför någon operation med den nylagda formen.
5. Traversera formerna för att hitta en form.
6. Ange AlternativeText.
7. Spara filen till disk.

```java
// Instansiera Presentation-klass som representerar PPTX
Presentation pres = new Presentation();
try {
    // Hämta den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Lägg till automatiskt form av rektangeltyp
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

Aspose.Slides för Android via Java tillhandahåller ett enkelt API för att få åtkomst till layoutformat för en form. Denna artikel visar hur du kan få åtkomst till layoutformat.

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

Nu har Aspose.Slides för Android via Java stöd för att rendera en form som SVG. Metoden [writeAsSvg](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (och dess överlagring) har lagts till i klassen [Shape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Shape) och i interfacet [IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShape). Denna metod gör det möjligt att spara formens innehåll som en SVG‑fil. Kodsnutten nedan visar hur man exporterar en bilds form till en SVG‑fil.

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

Aspose.Slides låter dig justera former antingen i förhållande till bildens marginaler eller i förhållande till varandra. För detta ändamål har den överlagrade metoden [SlidesUtil.alignShape()](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) lagts till. Upplägget [ShapesAlignmentType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ShapesAlignmentType) definierar möjliga justeringsalternativ.

**Exempel 1**

Källkoden nedan justerar former med index 1,2 och 4 längs bildens överkant.

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

Exemplet nedan visar hur man justerar hela samlingen av former i förhållande till den form som ligger längst ner i samlingen.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vändningsegenskaper**

I Aspose.Slides tillhandahåller klassen [ShapeFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shapeframe/) kontroll över horisontell och vertikal spegling av former via dess `flipH`‑ och `flipV`‑egenskaper. Båda egenskaperna är av typen `byte` och kan ha värdet `1` för att ange en spegling, `0` för ingen spegling eller `-1` för att använda standardbeteendet. Dessa värden är åtkomliga via en forms [Frame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getFrame--). För att ändra vändningsinställningarna skapas en ny instans av [ShapeFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shapeframe/) med formens aktuella position och storlek, önskade värden för `flipH` och `flipV` samt rotationsvinkeln. Genom att tilldela denna instans till formens [Frame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getFrame--) och spara presentationen appliceras speglingstransformationerna och skrivs till utdatafilen.

Anta att vi har en sample.pptx‑fil där den första bilden innehåller en enda form med standardinställningar för vändning, som visas nedan.

![Formen som ska vändas](shape_to_be_flipped.png)

Följande kodexempel hämtar formens nuvarande vändningsegenskaper och vänder den både horisontellt och vertikalt.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // Hämta den horisontella vändningsegenskapen för formen.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // Hämta den vertikala vändningsegenskapen för formen.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // Vänd horisontellt.
    byte flipV = NullableBool.True; // Vänd horisontellt.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Den vända formen](flipped_shape.png)

## **FAQ**

**Kan jag kombinera former (union/intersect/subtract) på en bild som i en skrivbordsredigerare?**

Det finns inget inbyggt API för boolesk operation. Du kan approximera det genom att själv konstruera önskad kontur – t.ex. beräkna den resulterande geometrin (via [GeometryPath](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/geometrypath/)) och skapa en ny form med den konturen, eventuellt ta bort de ursprungliga.

**Hur kan jag kontrollera stapelordningen (z‑order) så att en form alltid förblir "överst"?**

Ändra infognings‑/flyttordningen i bildens [shapes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseslide/#getShapes--)‑samling. För förutsägbara resultat, slutför z‑order efter alla andra bildmodifieringar.

**Kan jag "låsa" en form för att förhindra att användare redigerar den i PowerPoint?**

Ja. Ange skyddsflaggor på formnivå (t.ex. lås val, flytt, storleksändring, textredigering). Vid behov spegla begränsningarna på master‑ eller layoutnivå. Observera att detta är skydd på UI‑nivå, inte en säkerhetsfunktion; för starkare skydd kombinera med fil‑nivå begränsningar som [read‑only‑rekommendationer eller lösenord](/slides/sv/androidjava/password-protected-presentation/).