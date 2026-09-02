---
title: Hantera presentationsformer på Android
linktitle: Formmanipulation
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
- formens alternativa text
- formjusteringspunkt
- förinställd formjustering
- formgeometri
- formlayoutformat
- form som SVG
- form till SVG
- justera form
- vänd form
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du identifierar, justerar, klonar, tar bort, döljer, ändrar ordning, exporterar, justerar och vänder presentationsformer med Aspose.Slides för Android via Java."
---
## **Översikt**

Aspose.Slides för Android via Java representerar formerna på en bild som en ordnad [IShapeCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/). Samlingen är både platsen där du hittar och ändrar former samt källan till deras staplingsordning: index `0` är den längst bakvarande formen, medan det sista indexet är den främst placerade formen.

Den här artikeln följer den modellen. Den förklarar först hur man på ett tillförlitligt sätt identifierar en form och ändrar förinställda justeringspunkter, och visar sedan hur man klonar, tar bort, döljer och ändrar ordningen på former. De sista sektionerna täcker layoutnivåformatering, SVG‑export, justering och vändningsinställningar. Varje exempel är självständigt, så du kan använda bara de operationer ditt arbetsflöde kräver.

## **Identifiera och hitta former**

Samlingens index är praktiska när man behandlar en känd fil, men de är inte stabila identifierare. Att lägga till, ta bort eller ändra ordningen på en form kan ändra dess index. Välj en identifierare utifrån hur presentationen skapas och underhålls:

- [Name](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getName--) är användbart för mallar som styrs av utvecklare och är lätt att inspektera i PowerPoints urvalspanel. Namn kan redigeras och är inte garanterade att vara unika, så etablera en namngivningskonvention om kod beror på dem.
- [AlternativeText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getAlternativeText--) är användbart när en tillgänglighetsbeskrivning eller en författarskissad tagg redan identifierar formen. Den är synlig för användare, kan lokalanpassas eller skrivas om för tillgänglighet, och är inte garanterad att vara unik. Översätt inte tyst meningsfull tillgänglighetstext till en databass nyckel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) är en skrivskyddad identifierare som är unik inom en bild och motsvarar den form‑ID som används av PowerPoint‑interop. Använd den när du integrerar med PowerPoint eller när du behöver en entydig referens under en forms livstid. En klonad eller återställd form är en annan form och får ett eget ID.

Den relaterade metoden [getUniqueId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getUniqueId--) returnerar en identifierare med presentationsomfång, men den identifieraren är avsedd för tillägg och kan återtilldelas. Den bör inte behandlas som en permanent extern nyckel. Om långsiktig identitet är viktig, håll mappningen i programdata och validera att den förväntade formen fortfarande finns.

Följande exempel söker efter namn med en exakt jämförelse och rapporterar den bild‑omspännande interop‑ID:n. När mallen inte innehåller den förväntade formen rapporterar koden det resultatet i stället för att fortsätta med fel objekt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

När en operation är specifik för en formtyp, kontrollera gränssnittet innan du använder typ‑specifika medlemmar. Detta exempel uppdaterar text och alternativ text endast om det namngivna objektet är en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Identifiera och ändra förinställda formjusteringar**

Formgeometrier med förinställning kan exponera justeringspunkter som styr funktioner som hörn‑storlek, pil‑proportioner eller båg‑vinklar. Åtkomst sker via den skrivskyddade samlingen [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) . Samlingen levereras av formen, men varje [IAdjustValue](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iadjustvalue/) innehåller ett värde som kan ändras.

Lita inte enbart på ett fast samlings‑index. Iterera genom justeringarna och inspektera den skrivskyddade metoden [getType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iadjustvalue/#getType--) , vars [ShapeAdjustmentType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shapeadjustmenttype/)‑värde beskriver vad justeringen styr. Den skrivskyddade metoden [getName](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iadjustvalue/#getName--) ger ytterligare identifieringsinformation och är särskilt användbar när en förinställning innehåller mer än en justering med samma semantiska typ.

Använd den värdemetod som matchar justeringens innebörd:

| Justeringstyp | Syfte | Värde att ändra |
|---|---|---|
| `CornerSize` | Storlek på avrundade hörn | [setRawValue](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Tjocklek på en pilspets | `setRawValue` |
| `ArrowheadLength` | Längd på en pilspets | `setRawValue` |
| `ArrowheadWidth` | Bredd på en pilspets | `setRawValue` |
| `StartAngle` | Startvinkel för en paj eller båge | [setAngleValue](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Slutvinkel för en paj eller båge | `setAngleValue` |

`getType` och `getName` returnerar skrivskyddad information. `getRawValue` och `setRawValue` arbetar med ett heltal i förinställningens inhemska geometrienheter, medan `getAngleValue` och `setAngleValue` arbetar med en vinkel i grader. Antalet, ordningen, innebörden och giltigt intervall för justeringar beror på den förinställda [ShapeType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/igeometryshape/#getShapeType--) . Ett värde som är giltigt för en förinställning kan vara ogiltigt eller ha en annan effekt för en annan.

När `getType` returnerar `ShapeAdjustmentType.Custom` känner API:n inte igen en standard semantisk betydelse. Inspektera `getName`, förinställningstypen och det befintliga värdet, och låt justeringen vara oförändrad såvida inte den förväntade betydelsen och intervallet är känt. Även för igenkända typer, kontrollera om samma typ förekommer flera gånger innan du väljer ett värde. Artikeln [Connector](/slides/sv/androidjava/connector/) visar detta scenario med böjningsjusteringar för anslutare.

Följande kompletta exempel skapar standard‑ och modifierade versioner av tre förinställda former. Det itererar genom varje justering, rapporterar dess namn och typ, ändrar storleksrelaterade värden via `setRawValue`, ändrar vinklar via `setAngleValue` och sparar resultatet. Den vänstra kolumnen behåller standardgeometrin; den högra visar den justerade avrundade rektangeln, fyrvägs‑pilen och pajen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägger till rubriker för de standard- och justerade formkolumnerna.
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Att kontrollera den semantiska typen innan ett värde ändras gör koden explicit om sitt syfte och undviker antagandet att ett särskilt samlings‑index har samma betydelse över olika förinställda former.

## **Ändra form‑samlingen**

Metoderna för att lägga till, klona, ta bort och ändra ordning verkar omedelbart på samlingen. Om en operation förändrar antalet eller ordningen på former, fortsätt inte att förlita dig på index som fångats innan den operationen.

### **Klona en form**

[addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) skapar en oberoende kopia och lägger till den i mål‑samlingen. [insertClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) skapar också en kopia men placerar den på ett specificerat z‑order‑index. Överlagringarna som accepterar koordinater flyttar klonen utan att ändra dess storlek; överlagringar med bredd och höjd kan även ändra storlek.

Exemplet skapar en målbild, klonar en märkt rektangel till framsidan och infogar en andra klon längst bak. Ändringar i någon av klonerna påverkar inte källformen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Klonning kopierar formens innehåll och formatering, inklusive namn och alternativ text. Tilldela nya logiska identifierare till klonen när dessa värden måste vara unika. Resurser som används av komplexa former hanteras av presentationen, men en klon förblir ett nytt samlingsobjekt med en ny formidentitet.

### **Ta bort former**

[remove](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) tar bort ett specifikt form‑objekt från dess samling. När du tar bort flera matchningar under indexerad iteration, gå igenom från slutet så att varje kvarvarande index förblir giltigt.

Detta exempel tar bort varje form med ett bestämt namn. Det läser formen vid det aktuella indexet, inte ett fast samlingsobjekt, och kastar inte formen onödigt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Efter borttagning förändras antalet former och indexen för senare former. Referenser till opåverkade former förblir mer pålitliga än sparade index. Tänk också på anslutare, animationer och andra presentationsfunktioner som kan referera till det borttagna objektet; att ta bort en synlig form kan ändra mer än bara bildens utseende.

### **Dölja en form**

Att sätta [Hidden](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) till `true` behåller formen i samlingen men förhindrar att den visas i den normala bildvisningen. Dess index, formatering och innehåll förblir tillgängliga för kod, så dold är lämplig för valfria element som senare kan återställas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Att dölja är ingen borttagning eller säkerhet. Objektet kan fortfarande upptäckas och göras synligt igen av en användare eller av kod, och det förblir en del av presentationsfilen.

### **Ändra Z‑ordning**

Överlappande former målas i samlingsordning. [reorder](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) flyttar en befintlig form till ett mål‑index utan att klona den. Index `0` är längst bak; `size() - 1` är längst fram.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rektangeln skapas först och ligger initialt bakom ellipsen. Att flytta den till sista indexet placerar den längst fram. Slutför z‑ordning efter att alla relaterade former har lagts till eller klonats, eftersom dessa operationer lägger till eller infogar nya samlingsobjekt och kan ändra den avsedda stapeln.

## **Inspektera former på layout‑bilder**

Normala bilder, layout‑bilder och huvudbilder har separata form‑samlingar. En form i en layout‑samling är inte samma objekt som en liknande placerad form på en normal bild. Inspektera layout‑former när du behöver förstå eller ändra formatering som levereras av en layout.

Följande exempel läser varje layout‑forms [FillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getFillFormat--) och [LineFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getLineFormat--) utan att anta att varje form är en `AutoShape`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Att redigera en layout kan påverka flera bilder som använder den. Innan du ändrar en layout‑form, avgör om en normal bild ärver objektet eller har ett lokalt överskugg, och testa varje bild som använder den layouten.

## **Exportera en form till SVG**

[writeAsSvg](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) skriver en enskild forms renderade innehåll till en stream. Resultatet innehåller bara formen, inte hela bildbakgrunden eller grannformer.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

Behåll presentationen öppen under rendering. Utdata beror på formens formatering och på resurser som fonter och bilder. Om du behöver hela kompositionen, exportera bilden i stället för en enskild form. Anroparen äger streamen och måste stänga den.

## **Justera former**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) har överlagringar som antingen justerar alla former eller valda samlings‑index. [ShapesAlignmentType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shapesalignmenttype/) specificerar kant, mittlinje eller fördelningsläge. Sätt `alignToSlide` till `true` för att använda bildkanten; sätt den till `false` för att justera de valda formerna relativt varandra.

Detta exempel justerar tre former till bildens överkant. De returnerade formreferenserna omvandlas till sina aktuella index omedelbart före justering.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Justering ändrar positioner, inte z‑ordning. Relativ justering kräver normalt minst två former, medan horisontell eller vertikal fördelning kräver tillräckligt många former för att definiera avståndet. Räkna om index om du ändrar samlingen innan du anropar metoden.

## **Vända en form**

Klassen [ShapeFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shapeframe/) lagrar position, storlek, horisontell och vertikal vändningsinställning samt rotation. Dess `getFlipH`‑ och `getFlipV`‑värden använder [NullableBool](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/nullablebool/) : `True` aktiverar vändningen, `False` inaktiverar den, och `NotDefined` bevarar det odefinierade/default‑tillståndet.

Den inmatade presentationen nedan innehåller en icke‑vänd form.

![The shape before flipping](shape_to_be_flipped.png)

Exemplet bevarar alla andra ram‑värden och ersätter bara de två vändningsinställningarna. Detta är viktigt eftersom en ny [Frame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) ersätter hela ramen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Den sparade formen är speglad horisontellt och vertikalt samtidigt som position, storlek och rotation behålls.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Ska jag använda ett samlings‑index som form‑identifierare?**

Endast för kortlivad bearbetning när samlingen inte kommer att förändras innan indexet används. Föredra en validerad `Name`‑ eller `AlternativeText`‑konvention för skapade mallar, eller `OfficeInteropShapeId` för interop‑arbete med bildomfång.

**Tar dölja en form bort den från z‑ordningen?**

Nej. En dold form förblir i samlingen på samma index. Den kan hittas, omordnas, redigeras eller göras synlig igen.

**Varför hamnade en klonad form framför en annan form?**

`addClone` lägger till klonen i slutet av samlingen, vilket är framfronten i z‑ordningen. Använd `insertClone` för att välja ett initialt index eller `reorder` efter att alla former har lagts till.

**Kan jag använda ett fast index för att identifiera en förinställd formjustering?**

Endast efter att du har validerat den exakta förinställningen och samlingslayouten. Föredra att iterera genom `IGeometryShape.getAdjustments` och kontrollera `IAdjustValue.getType`; använd `IAdjustValue.getName` som extra information när samma semantiska typ förekommer mer än en gång.