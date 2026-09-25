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
- hämta interop-form-ID
- formens alternativa text
- justeringspunkt för form
- förinställd formjustering
- formgeometri
- formlayoutformat
- form som SVG
- form till SVG
- justera form
- spegelvänd form
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du identifierar, justerar, klonar, tar bort, döljer, omordnar, exporterar, justerar och spegelvänder presentationsformer med Aspose.Slides för Java."
---
## **Översikt**

Aspose.Slides for Java representerar formerna på en bild som en ordnad [IShapeCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/). Samlingen är både platsen där du hittar och modifierar former samt källan till deras staplingsordning: index `0` är den bakre formen, medan sista indexet är den främsta formen.

Den här artikeln följer den modellen. Den förklarar först hur man på ett tillförlitligt sätt identifierar en form och ändrar förinställda justeringspunkter, och visar sedan hur man klonar, tar bort, döljer och omordnar former. De sista avsnitten behandlar layout‑nivåens formatering, SVG‑export, justering och spegelvändning. Varje exempel är fristående, så du kan använda endast de operationer som ditt arbetsflöde kräver.

## **Identifiera och hitta former**

Samlingsindex är praktiska när man bearbetar en känd fil, men de är inte stabila identifierare. Att lägga till, ta bort eller omordna en form kan ändra dess index. Välj en identifierare utifrån hur presentationen skapas och underhålls:

- [Name](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getName--) är användbart för utvecklarkontrollerade mallar och är lätt att inspektera i PowerPoints urvalspanel. Namn kan redigeras och är inte garanterat unika, så etablera en namngivningskonvention om koden är beroende av dem.
- [AlternativeText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getAlternativeText--) är användbart när en tillgänglighetsbeskrivning eller en författarspecificerad tagg redan identifierar formen. Den är synlig för användare, kan lokaliseras eller skrivas om för tillgänglighet och är inte garanterat unik. Använd inte tyst meningsfull tillgänglighetstext som en databassöknyckel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) är en skrivskyddad identifierare som är unik inom en bild och motsvarar det shape‑ID som PowerPoint‑interop använder. Använd den när du integrerar med PowerPoint eller när du behöver en entydig referens under en forms livstid. En klonad eller återskapad form är en annan form och får ett eget ID.

Den relaterade metoden [getUniqueId](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getUniqueId--) returnerar en identifierare med presentationsomfattning, men den är avsedd för tillägg och kan omfördelas. Den bör inte behandlas som en permanent extern nyckel. Om långsiktig identitet är viktig, håll mappningen i applikationsdata och validera att den förväntade formen fortfarande finns.

För ett praktiskt exempel på att läsa och uppdatera både alternativtextens titel och beskrivning, se [Manage Alternative Text Titles and Descriptions](/slides/sv/java/presentation-accessibility/). Använd alternativtext för att förklara den visuella meningen för läsare, och håll den separerad från formnamn som kod använder för att hitta former.

Följande exempel söker efter namn med exakt jämförelse och rapporterar bildens interop‑ID. När mallen inte innehåller den förväntade formen, rapporterar koden det resultatet istället för att fortsätta med fel objekt.

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

När en operation är specifik för en formtyp, kontrollera gränssnittet innan du använder typ‑specifika medlemmar. Det här exemplet uppdaterar text och alternativtext endast om det namngivna objektet är en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/).

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

## **Identifiera och modifiera förinställda formjusteringar**

Förinställda geometriformer kan exponera justeringspunkter som styr egenskaper som hörnstorlek, pilproportioner eller båg‑vinklar. Åtkomst sker via den skrivskyddade samlingen [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/sv/java/com.aspose.slides/igeometryshape/#getAdjustments--) . Själva samlingen levereras av formen, men varje [IAdjustValue](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iadjustvalue/) innehåller ett värde som kan förändras.

Förlita dig inte enbart på ett fast samlingsindex. Iterera genom justeringarna och inspektera den skrivskyddade metoden [getType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iadjustvalue/#getType--) vars [ShapeAdjustmentType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shapeadjustmenttype/)‑värde beskriver vad justeringen styr. Den skrivskyddade metoden [getName](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iadjustvalue/#getName--) ger ytterligare identifieringsinformation och är särskilt användbar när en förinställning innehåller mer än en justering med samma semantiska typ.

Använd den värdemetod som matchar justeringens innebörd:

| Justeringstyp | Syfte | Värde att ändra |
|---|---|---|
| `CornerSize` | Storlek på avrundade hörn | [setRawValue](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Tjocklek på en pilsvans | `setRawValue` |
| `ArrowheadLength` | Längd på en pilspets | `setRawValue` |
| `ArrowheadWidth` | Bredd på en pilspets | `setRawValue` |
| `StartAngle` | Startvinkel för en paj eller båge | [setAngleValue](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Slutvinkel för en paj eller båge | `setAngleValue` |

`getType` och `getName` returnerar skrivskyddad information. `getRawValue` och `setRawValue` arbetar med ett heltal i förinställningens inhemska geometrienheter, medan `getAngleValue` och `setAngleValue` arbetar med en vinkel i grader. Antalet, ordningen, innebörden och det giltiga intervallet för justeringar beror på den förinställda [ShapeType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/igeometryshape/#getShapeType--). Ett värde som är giltigt för en förinställning kan vara ogiltigt eller ha en annan effekt för en annan.

När `getType` returnerar `ShapeAdjustmentType.Custom` känner API‑et inte igen någon standard semantisk betydelse. Inspektera `getName`, förinställningstypen och det befintliga värdet, och låt justeringen vara oförändrad om den förväntade betydelsen och intervallet inte är känt. Även för igenkända typer, kontrollera om samma typ förekommer flera gånger innan du väljer ett värde. Artikeln om [Connector](/slides/sv/java/connector/) visar detta scenario med böjjusteringar för anslutare.

Följande kompletta exempel skapar standard‑ och modifierade versioner av tre förinställda former. Det itererar genom varje justering, rapporterar dess namn och typ, ändrar storleks‑relaterade värden via `setRawValue`, ändrar vinklar via `setAngleValue` och sparar resultatet. Den vänstra kolumnen behåller standardgeometrin; den högra kolumnen visar den justerade avrundade rektangeln, fyrvägs‑pilen och pajen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägger till rubriker för standard- och justerade formkolumner.
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

Att kontrollera den semantiska typen innan ett värde ändras gör koden tydlig i sitt syfte och undviker antagandet att ett visst samlingsindex har samma innebörd för olika förinställda former.

## **Modifiera formsamlingen**

Metoderna för att lägga till, klona, ta bort och omordna verkar på samlingen omedelbart. Om en operation förändrar antalet eller ordningen på former, fortsätt inte att förlita dig på index som fångats innan den operationen.

### **Klona en form**

[addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) skapar en oberoende kopia och lägger till den i mål‑samlingen. [insertClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) skapar också en kopia men placerar den på ett angivet z‑order‑index. Överlagringarna som accepterar koordinater flyttar klonen utan att ändra storlek; överlagringar med bredd och höjd kan även ändra storlek.

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

Klonning kopierar formens innehåll och formatering, inklusive namn och alternativtext. Tilldela nya logiska identifierare till klonen när dessa värden måste vara unika. Resurser som används av komplexa former hanteras av presentationen, men en klon förblir ett nytt samlingsobjekt med en ny formidentitet.

### **Ta bort former**

[remove](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) tar bort ett specifikt formobjekt från dess samling. När du tar bort flera matchningar under en index‑iteration, gå bakifrån så att varje kvarvarande index förblir giltigt.

Detta exempel tar bort varje form med ett angivet namn. Det läser formen vid det aktuella indexet, inte ett fast samlingsobjekt, och det castar inte formen i onödan.

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

Efter borttagning ändras antalet former och indexen för efterföljande former. Referenser till opåverkade former förblir mer pålitliga än sparade index. Tänk också på anslutare, animationer och andra presentationsfunktioner som kan referera till det borttagna objektet; att ta bort en synlig form kan förändra mer än bara bildens utseende.

### **Dölj en form**

Att sätta [Hidden](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#setHidden-boolean-) till `true` behåller formen i samlingen men förhindrar att den visas i den normala bildspelen. Dess index, formatering och innehåll förblir tillgängliga för kod, så dölja är lämpligt för valfria element som kan återställas senare.

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

Döljning är ingen borttagning eller säkerhetsåtgärd. Objektet kan fortfarande upptäckas och återaktiveras av en användare eller av kod, och det förblir en del av presentationsfilen.

### **Ändra Z‑ordning**

Överlappande former målas i samlingsordning. [reorder](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) flyttar en befintlig form till ett mål‑index utan att klona den. Index `0` är längst bak; `size() - 1` är längst fram.

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
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rektangeln skapas först och ligger initialt bakom ellipsen. Att flytta den till sista indexet placerar den framför. Slutför z‑ordning efter att alla relaterade former har lagts till eller klonats, eftersom dessa operationer lägger till eller infogar nya samlingsobjekt och kan förändra den avsedda staplingen.

## **Inspektera former på layoutbilder**

Normala bilder, layoutbilder och masternbilder har separata form‑samlingar. En form i en layout‑samling är inte samma objekt som en liknande placerad form på en normal bild. Inspektera layout‑former när du behöver förstå eller ändra formatering som levereras av en layout.

Följande exempel läser varje layoutforms [FillFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getFillFormat--) och [LineFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getLineFormat--) utan att anta att varje form är en `AutoShape`.

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

Att redigera en layout kan påverka flera bilder som använder den. Innan du ändrar en layoutform, avgör om en normal bild ärver objektet eller har en lokal överskuggning, och testa varje bild som använder den layouten.

## **Exportera en form till SVG**

[writeAsSvg](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) skriver en forms renderade innehåll till en ström. Resultatet innehåller bara formen, inte hela bildens bakgrund eller grannformer.

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

Behåll presentationen öppen medan du renderar. Utdata beror på formens formatering samt resurser som teckensnitt och bilder. Om du behöver hela kompositionen, exportera bilden istället för en enskild form. Anroparen äger strömmen och måste stänga den.

## **Justera former**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) har överlagringar som antingen justerar alla former eller valda samlingsindex. [ShapesAlignmentType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shapesalignmenttype/) specificerar kant, mittlinje eller fördelningsläge. Sätt `alignToSlide` till `true` för att använda bildens kanter; sätt den till `false` för att justera de valda formerna relativt varandra.

Detta exempel justerar tre former till bildens överkant. De returnerade formreferenserna omvandlas till sina aktuella index omedelbart innan justeringen utförs.

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

Justering ändrar positioner, inte z‑ordning. Relativ justering kräver normalt minst två former, medan horisontell eller vertikal fördelning kräver tillräckligt många former för att definiera avstånd. Räkna om index om du ändrar samlingen innan du anropar metoden.

## **Spegelvänd en form**

[ShapeFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shapeframe/)‑klassen lagrar position, storlek, horisontella och vertikala spegelvändningsinställningar samt rotation. Dess `getFlipH`‑ och `getFlipV`‑värden använder [NullableBool](https://reference.aspose.com/slides/sv/java/com.aspose.slides/nullablebool/): `True` aktiverar spegelvändning, `False` inaktiverar den, och `NotDefined` bevarar det odefinierade/default‑tillståndet.

Den input‑presentation som visas nedan innehåller en icke‑spegelvänd form.

![Formen före spegelvändning](shape_to_be_flipped.png)

Exemplet behåller alla andra ramvärden och ersätter endast de två spegelinställningarna. Detta är viktigt eftersom en ny [Frame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) ersätter hela ramen.

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

Den sparade formen speglas horisontellt och vertikalt samtidigt som position, storlek och rotation behålls.

![Formen efter spegelvändning](flipped_shape.png)

## **FAQ**

**Ska jag använda ett samlingsindex som formidentifierare?**

Endast för kortlivad behandling när samlingen inte kommer att förändras innan indexet används. Föredra en validerad `Name`‑ eller `AlternativeText`‑konvention för författade mallar, eller `OfficeInteropShapeId` för interop‑arbete på bildnivå.

**Tar dölja en form bort den från z‑ordningen?**

Nej. En dold form förblir i samlingen på samma index. Den kan hittas, omordnas, redigeras eller göras synlig igen.

**Varför hamnade en klonad form framför en annan form?**

`addClone` lägger till klonen i slutet av samlingen, vilket är fronten i z‑ordningen. Använd `insertClone` för att välja initialt index eller `reorder` efter att alla former har lagts till.

**Kan jag använda ett fast index för att identifiera en förinställd formjustering?**

Endast efter att du har validerat den exakta förinställningen och samlingslayouten. Föredra att iterera genom `IGeometryShape.getAdjustments` och kontrollera `IAdjustValue.getType`; använd `IAdjustValue.getName` som extra information när samma semantiska typ förekommer flera gånger.