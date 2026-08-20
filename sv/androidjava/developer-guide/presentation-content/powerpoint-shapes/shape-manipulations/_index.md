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
- formens alternativtext
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
description: "Lär dig hur du identifierar, klonar, tar bort, döljer, ändrar ordning, exporterar, justerar och vänder presentationsformer med Aspose.Slides för Android via Java."
---
## **Översikt**

Aspose.Slides för Android via Java representerar formerna på en bild som en ordnad [IShapeCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/). Samlingen är både platsen där du hittar och modifierar former samt källan till deras staplingsordning: index `0` är den bakre formen, medan det sista indexet är den främsta formen.

Denna artikel följer den modellen. Den förklarar först hur man på ett tillförlitligt sätt identifierar en form, sedan visar hur man klonar, tar bort, döljer och omordnar former. De sista avsnitten täcker layoutnivåformatering, SVG‑export, justering och vändningsinställningar. Varje exempel är oberoende, så du kan använda endast de operationer som ditt arbetsflöde kräver.

## **Identifiera och hitta former**

Samlingsindex är praktiska vid bearbetning av en känd fil, men de är inte stabila identifierare. Att lägga till, ta bort eller omordna en form kan ändra dess index. Välj en identifierare utifrån hur presentationen har skapats och underhålls:

- [Name](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getName--) är användbart för utvecklarkontrollerade mallar och är enkelt att inspektera i PowerPoints urvalspanel. Namn kan redigeras och garanteras inte att vara unika, så etablera en namngivningskonvention om kod beror på dem.
- [AlternativeText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getAlternativeText--) är användbart när en tillgänglighetsbeskrivning eller en författare‑tillhandahållen tagg redan identifierar formen. Den är synlig för användare, kan lokalanpassas eller skrivas om för tillgänglighet, och garanteras inte att vara unik. Återanvänd inte tyst meningsfull tillgänglighetstext som en databassnyckel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) är en skrivskyddad identifierare som är unik inom en bild och motsvarar den form‑ID som används av PowerPoint‑interop. Använd den när du integrerar med PowerPoint eller när du behöver en entydig referens under en formas livstid. En klonad eller återskapad form är en annan form och får sitt eget ID.

Den relaterade metoden [getUniqueId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getUniqueId--) returnerar en identifierare med presentationsomfattning, men den identifieraren är avsedd för tillägg och kan omfördelas. Den bör inte behandlas som en permanent extern nyckel. Om långsiktig identitet är avgörande, behåll mappningen i applikationsdata och validera att den förväntade formen fortfarande finns.

Följande exempel söker efter namn med en exakt jämförelse och rapporterar bild‑specifika interop‑ID. När mallen inte innehåller den förväntade formen rapporterar koden det resultatet istället för att fortsätta med fel objekt.

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

När en operation är specifik för en formtyp, kontrollera gränssnittet innan du använder typ‑specifika medlemmar. Detta exempel uppdaterar text och alternativtext endast om det namngivna objektet är en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/).

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

## **Modifiera formssamlingen**

Metoderna add, clone, remove och reorder arbetar på samlingen omedelbart. Om en operation ändrar antalet eller ordningen på former, fortsätt inte förlita dig på index som fångades innan den operationen.

### **Klona en form**

[addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) skapar en oberoende kopia och lägger till den i mål‑samlingen. [insertClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) skapar också en kopia men placerar den på ett angivet z‑order‑index. Överlagringarna som accepterar koordinater flyttar klonen utan att ändra dess storlek; överlagringarna med bredd och höjd kan dessutom ändra dess storlek.

Exemplet skapar en destinationsbild, klonar en märkt rektangel till framsidan och infogar en andra klon längst bak. Ändringar i någon av klonerna modifierar inte källformen.

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

Klona kopierar formens innehåll och formatering, inklusive dess namn och alternativtext. Tilldela nya logiska identifierare till klonen när dessa värden måste vara unika. Resurser som används av komplexa former hanteras av presentationen, men en klon förblir ett nytt samlingsobjekt med en ny form‑identitet.

### **Ta bort former**

[remove](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) raderar ett specifikt formobjekt från dess samling. När du tar bort flera matchningar under indexerad iteration, gå igenom från slutet så att varje kvarvarande index förblir giltigt.

Detta exempel tar bort varje form med ett angivet namn. Det läser formen vid det aktuella indexet, inte ett fast samlingsobjekt, och den kastar inte formen onödigt.

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

Efter borttagning ändras antalet former och indexen för senare former. Referenser till opåverkade former förblir mer pålitliga än sparade index. Tänk också på anslutningar, animationer och andra presentationsfunktioner som kan referera till det borttagna objektet; att ta bort en synlig form kan ändra mer än bildens utseende.

### **Dölj en form**

Att sätta [Hidden](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) till `true` behåller formen i samlingen men förhindrar att den visas i den normala bildspelet. Dess index, formatering och innehåll förblir tillgängliga för kod, så dölja är lämpligt för valfria element som kan återställas senare.

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

Dölja är inte borttagning eller säkerhet. Objektet kan fortfarande upptäckas och avdöljas av en användare eller av kod, och det förblir en del av presentationsfilen.

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

Rektangeln skapas först och sitter initialt bakom ellipsen. Att flytta den till det sista indexet placerar den framför. Slutför z‑ordning efter att ha lagt till eller klonat alla relaterade former, eftersom dessa operationer lägger till eller infogar nya samlingsobjekt och kan förändra den avsedda stapeln.

## **Inspektera former på layoutbilder**

Normala bilder, layoutbilder och masternbilder har separata formssamlingar. En form i en layout‑samling är inte samma objekt som en likadant placerad form på en normal bild. Inspektera layoutformer när du behöver förstå eller förändra formatering som levereras av en layout.

Följande exempel läser varje layoutforms [FillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getFillFormat--) och [LineFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getLineFormat--) utan att anta att varje form är en `AutoShape`.

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

Att redigera en layout kan påverka flera bilder som använder den. Innan du ändrar en layoutform, fastställ om en normal bild ärver objektet eller innehåller en lokal överskrivning, och testa varje bild som använder den layouten.

## **Exportera en form till SVG**

[writeAsSvg](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) skriver en enskild forms renderade innehåll till en ström. Resultatet innehåller formen, inte hela bildbakgrunden eller intilliggande former.

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

Behåll presentationen öppen under rendering. Utdata beror på formens formatering och på resurser som teckensnitt och bilder. Om du behöver hela sammansättningen, exportera bilden snarare än en enskild form. Anroparen äger strömmen och måste stänga den.

## **Justera former**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) overloads anpassar antingen alla former eller valda samlingsindex. [ShapesAlignmentType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shapesalignmenttype/) specificerar kanten, mittlinjen eller fördelningsläget. Sätt `alignToSlide` till `true` för att använda bildens kanter; sätt den till `false` för att justera de valda formerna relativt varandra.

Detta exempel justerar tre former till bildens överkant. De returnerade formreferenserna konverteras till sina aktuella index omedelbart före justering.

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

Justering förändrar positioner, inte z‑ordning. Relativ justering kräver normalt minst två former, medan horisontell eller vertikal fördelning behöver tillräckligt många former för att definiera avståndet. Räkna om index om du modifierar samlingen innan du anropar metoden.

## **Vänd en form**

[ShapeFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shapeframe/)‑klassen lagrar position, storlek, horisontella och vertikala vändningsinställningar samt rotation. Dess `getFlipH`‑ och `getFlipV`‑värden använder [NullableBool](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/nullablebool/): `True` aktiverar vändningen, `False` inaktiverar den, och `NotDefined` bevarar det ospecificerade/standardtillståndet.

Den ingående presentationen nedan innehåller en ovänd form.

![Formen före vändning](shape_to_be_flipped.png)

Exemplet bevarar alla andra ramvärden och ersätter endast de två vändningsinställningarna. Detta är viktigt eftersom tilldelning av en ny [Frame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) ersätter hela ramen.

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

Den sparade formen speglas horisontellt och vertikalt samtidigt som dess position, storlek och rotation behålls.

![Formen efter vändning](flipped_shape.png)

## **FAQ**

**Bör jag använda ett samlingsindex som formidentifierare?**

Endast för kortlivad bearbetning när samlingen inte kommer att förändras innan indexet används. Föredra en validerad `Name`‑ eller `AlternativeText`‑konvention för skapade mallar, eller `OfficeInteropShapeId` för bild‑specifikt interop‑arbete.

**Tar dölja en form bort den från z‑ordningen?**

Nej. En dold form förblir i samlingen på samma index. Den kan hittas, omordnas, redigeras eller göras synlig igen.

**Varför visades en klonad form framför en annan form?**

`addClone` lägger till klonen i slutet av samlingen, vilket är fronten av z‑ordningen. Använd `insertClone` för att välja ett initialt index eller `reorder` efter att alla former har lagts till.