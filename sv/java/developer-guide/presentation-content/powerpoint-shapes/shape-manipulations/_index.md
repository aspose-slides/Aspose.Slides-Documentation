---
title: Hantera presentationsformer i Java
linktitle: Formmanipulering
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
- göm form
- ändra formordning
- hämta interop-form-ID
- formens alternativa text
- formens layoutformat
- form som SVG
- form till SVG
- justera form
- vända form
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du identifierar, klonar, tar bort, gömmer, ändrar ordning, exporterar, justerar och vänder presentationsformer med Aspose.Slides för Java."
---
## **Översikt**

Aspose.Slides för Java representerar formerna på en bild som en ordnad [IShapeCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/). Samlingen är både platsen där du hittar och ändrar former samt källan till deras staplingsordning: index `0` är den mest bakre formen, medan det sista indexet är den främsta formen.

Denna artikel följer den modellen. Den förklarar först hur man på ett tillförlitligt sätt identifierar en form, och visar sedan hur man klonar, tar bort, döljer och ändrar ordningen på former. De sista avsnitten täcker layout‑nivåformatering, SVG‑export, justering och flip‑inställningar. Varje exempel är fristående, så du kan använda bara de operationer ditt arbetsflöde kräver.

## **Identifiera och hitta former**

Samlingsindex är praktiska när man bearbetar en känd fil, men de är inte stabila identifierare. Att lägga till, ta bort eller ändra ordning på en form kan ändra dess index. Välj en identifierare utifrån hur presentationen skapas och underhålls:

- [Name](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getName--) är användbar för utvecklarkontrollerade mallar och är enkel att inspektera i PowerPoints urvals‑panel. Namn kan redigeras och garanteras inte vara unika, så etablera ett namngivningskonvention om kod beror på dem.
- [AlternativeText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getAlternativeText--) är användbar när en tillgänglighetsbeskrivning eller en författargiven tagg redan identifierar formen. Den är synlig för användare, kan lokalanpassas eller skrivas om för tillgänglighet, och garanteras inte vara unik. Återskapa inte tyst meningsfull tillgänglighetstext som en databassnyckel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) är en skrivskyddad identifierare som är unik inom en bild och motsvarar den shape‑ID som används av PowerPoint‑interop. Använd den när du integrerar med PowerPoint eller när du behöver en entydig referens under en forms livstid. En klonad eller återställd form är en annan form och får sin egen ID.

Den relaterade metoden [getUniqueId](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getUniqueId--) returnerar en identifierare med presentationsomfång, men den identifieraren är avsedd för tillägg och kan omfördelas. Den bör inte behandlas som en permanent extern nyckel. Om långsiktig identitet är avgörande, håll mappningen i applikationsdata och validera att den förväntade formen fortfarande finns.

Följande exempel söker efter namn med exakt jämförelse och rapporterar den bild‑specifika interop‑ID:n. När mallen inte innehåller den förväntade formen rapporterar koden det resultatet istället för att fortsätta med fel objekt.

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

När en operation är specifik för en formtyp, kontrollera gränssnittet innan du använder typ‑specifika medlemmar. Detta exempel uppdaterar text och alternativtext endast om det namngivna objektet är en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/).

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

## **Modifiera form‑samlingen**

Metoderna för att lägga till, klona, ta bort och ändra ordning påverkar samlingen omedelbart. Om en operation ändrar antalet eller ordningen på former, fortsätt inte att förlita dig på index som fångades före den operationen.

### **Klona en form**

[addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) skapar en oberoende kopia och lägger till den i målsamlingen. [insertClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) skapar också en kopia men placerar den på ett specifikt z‑order‑index. Överlagringarna som accepterar koordinater flyttar klonen utan att ändra dess storlek; överlagringar med bredd och höjd kan även ändra storlek.

Exemplet skapar en destinationsbild, klonar en märkt rektangel till framsidan och infogar en andra klon längst bak. Ändringar i någon av klonerna påverkar inte källformen.

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

[remove](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) tar bort ett specifikt form‑objekt från dess samling. När du tar bort flera matchningar under indexerad iteration, gå bakifrån så att varje återstående index förblir giltigt.

Detta exempel tar bort varje form med ett angivet namn. Det läser formen vid det aktuella indexet, inte ett fast samlingsobjekt, och kastar inte formen onödigt.

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

Efter borttagning förändras antalet former och indexen för senare former. Referenser till opåverkade former förblir mer tillförlitliga än sparade index. Tänk även på anslutningar, animationer och andra presentationsfunktioner som kan referera till det borttagna objektet; att ta bort en synlig form kan förändra mer än bara bildens utseende.

### **Dölja en form**

Att sätta [Hidden](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#setHidden-boolean-) till `true` behåller formen i samlingen men förhindrar att den visas i den normala bildspelsvisningen. Dess index, formatering och innehåll förblir tillgängliga för kod, så dölja är lämpligt för valfria element som kan återställas senare.

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

Att dölja är inte samma sak som att radera eller säkra. Objektet kan fortfarande upptäckas och göras synligt igen av en användare eller av kod, och det förblir en del av presentationsfilen.

### **Ändra Z‑order**

Överlappande former målas i samlingsordning. [reorder](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) flyttar en befintlig form till ett mål‑index utan att klona den. Index `0` är bakåt; `size() - 1` är framåt.

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

Rektangeln skapas först och sitter initialt bakom ellipsen. Att flytta den till det sista indexet placerar den framför. Slutför z‑order efter att ha lagt till eller klonat alla relaterade former, eftersom dessa operationer lägger till eller infogar nya samlingsobjekt och kan ändra den avsedda stapeln.

## **Inspektera former på layout‑bilder**

Normala bilder, layout‑bilder och huvudbilder har separata form‑samlingar. En form i en layout‑samling är inte samma objekt som en liknande placerad form på en normal bild. Inspektera layout‑former när du behöver förstå eller ändra formatering som levereras av en layout.

Följande exempel läser varje layout‑forms [FillFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getFillFormat--) och [LineFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getLineFormat--) utan att anta att varje form är en `AutoShape`.

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

Att redigera en layout kan påverka flera bilder som använder den. Innan du ändrar en layout‑form, avgör om en normal bild ärver objektet eller innehåller en lokal överskrivning, och testa varje bild som använder den layouten.

## **Exportera en form till SVG**

[writeAsSvg](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) skriver en forms renderade innehåll till en ström. Resultatet innehåller formen, inte hela bildbakgrunden eller närliggande former.

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

Håll presentationen öppen under rendering. Utdata beror på formens formatering samt resurser som teckensnitt och bilder. Om du behöver hela kompositionen, exportera bilden snarare än en enskild form. Anroparen äger strömmen och måste stänga den.

## **Justera former**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) har överlagringar som antingen justerar alla former eller valda samlingsindex. [ShapesAlignmentType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shapesalignmenttype/) specificerar kanten, mittlinjen eller fördelningsläget. Sätt `alignToSlide` till `true` för att använda bildens kanter; sätt den till `false` för att justera de markerade formerna relativt varandra.

Detta exempel justerar tre former till bildens överkant. De returnerade form‑referenserna konverteras till sina aktuella index omedelbart före justering.

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

Justering förändrar positioner, inte z‑order. Relativ justering kräver normalt minst två former, medan horisontell eller vertikal fördelning kräver tillräckligt många former för att definiera avstånd. Räkna om index om du ändrar samlingen innan du anropar metoden.

## **Vända en form**

[ShapeFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shapeframe/)‑klassen lagrar position, storlek, horisontella och vertikala vändinställningar samt rotation. Dess `getFlipH`‑ och `getFlipV`‑värden använder [NullableBool](https://reference.aspose.com/slides/sv/java/com.aspose.slides/nullablebool/): `True` aktiverar vändningen, `False` inaktiverar den, och `NotDefined` bevarar det ospecificerade/default‑tillståndet.

Den inmatade presentationen nedan innehåller en ovänd form.

![The shape before flipping](shape_to_be_flipped.png)

Exemplet bevarar alla andra ramvärden och ersätter endast de två vändinställningarna. Detta är viktigt eftersom en ny [Frame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) ersätter hela ramen.

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

![The shape after flipping](flipped_shape.png)

## **Vanliga frågor**

**Ska jag använda ett samlingsindex som form‑identifierare?**

Endast för kortlivad bearbetning när samlingen inte kommer att förändras innan indexet används. Föredra ett validerat `Name`‑ eller `AlternativeText`‑konvention för skapade mallar, eller `OfficeInteropShapeId` för bild‑specifikt interop‑arbete.

**Tar dölja en form bort den från z‑order?**

Nej. En dold form förblir i samlingen på samma index. Den kan hittas, omordnas, redigeras eller göras synlig igen.

**Varför dök en klonad form upp framför en annan form?**

`addClone` lägger till klonen i slutet av samlingen, vilket är framkanten i z‑order. Använd `insertClone` för att välja initialt index eller `reorder` efter att alla former har lagts till.