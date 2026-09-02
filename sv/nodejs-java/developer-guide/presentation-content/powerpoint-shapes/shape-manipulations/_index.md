---
title: Hantera presentationsformer i JavaScript
linktitle: Formmanipulation
type: docs
weight: 40
url: /sv/nodejs-java/shape-manipulations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du identifierar, justerar, klonar, tar bort, döljer, omordnar, exporterar, justerar och vänder presentationsformer med Aspose.Slides för Node.js via Java."
---
## **Översikt**

Aspose.Slides för Node.js via Java representerar formerna på en bild som en ordnad [ShapeCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/). Samlingen är både platsen där du hittar och ändrar former samt källan för deras staplingsordning: index `0` är den längst bak, medan det sista indexet är den längst fram.

Den här artikeln följer den modellen. Den förklarar först hur man på ett pålitligt sätt identifierar en form och ändrar förinställda justeringspunkter, och visar sedan hur man klonar, tar bort, döljer och omordnar former. De sista avsnitten täcker layout‑nivåformatering, SVG‑export, justering och flip‑inställningar. Varje exempel är fristående, så du kan använda endast de operationer ditt arbetsflöde kräver.

## **Identifiera och hitta former**

Samlingens index är praktiska när du bearbetar en känd fil, men de är inte stabila identifierare. Att lägga till, ta bort eller omordna en form kan ändra dess index. Välj en identifierare utifrån hur presentationen skapas och underhålls:

- [Name](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/getname/) är användbart för mallar som kontrolleras av utvecklare och är lätt att inspektera i PowerPoints urvalspanel. Namn kan redigeras och är inte garanterade att vara unika, så etablera en namnkonvention om kod beror på dem.
- [AlternativeText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/getalternativetext/) är användbart när en tillgänglighetsbeskrivning eller en författargiven tagg redan identifierar formen. Den är synlig för användare, kan lokaliseras eller skrivas om för tillgänglighet, och är inte garanterad att vara unik. Återanvänd inte tyst meningsfull tillgänglighetstext som en databassökväg.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) är en skrivskyddad identifierare som är unik inom en bild och motsvarar den form‑ID som används av PowerPoint‑interop. Använd den när du integrerar med PowerPoint eller när du behöver en entydig referens under en forms livstid. En klonad eller återställd form är en annan form och får sitt eget ID.

Den relaterade metoden [getUniqueId](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/getuniqueid/) returnerar en identifierare med presentationsomfång, men den identifieraren är avsedd för tillägg och kan återtilldelas. Den bör inte behandlas som en permanent extern nyckel. Om långsiktig identitet är avgörande, håll mappningen i applikationsdata och validera att den förväntade formen fortfarande finns.

Följande exempel söker efter namn med exakt jämförelse och rapporterar den bild‑specifika interop‑ID:n. När mallen inte innehåller den förväntade formen rapporterar koden det resultatet istället för att fortsätta med fel objekt.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

När en operation är specifik för en formtyp, kontrollera runtime‑klassen innan du använder typ‑specifika medlemmar. Detta exempel uppdaterar text och alternativ text endast om det namngivna objektet är en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/).

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Identifiera och ändra förinställda formjusteringar**

Förinställda geometriformer kan exponera justeringspunkter som styr egenskaper såsom hörnstorlek, pilproportioner eller bågavstånd. Kom åt dem via den skrivskyddade samlingen [GeometryShape.getAdjustments](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/geometryshape/). Själva samlingen tillhandahålls av formen, men varje [AdjustValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/adjustvalue/) innehåller ett värde som kan ändras.

Lita inte enbart på ett fast samlingsindex. Iterera genom justeringarna och inspektera den skrivskyddade metoden [getType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/adjustvalue/), vars värde av [ShapeAdjustmentType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapeadjustmenttype/) beskriver vad justeringen styr. Den skrivskyddade metoden [getName](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/adjustvalue/getname/) ger ytterligare identifieringsinformation och är särskilt användbar när en förinställning innehåller mer än en justering med samma semantiska typ.

Använd den värdemetod som matchar justeringens betydelse:

| Justeringstyp | Syfte | Värde att ändra |
|---|---|---|
| `CornerSize` | Storlek på rundade hörn | [setRawValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Tjocklek på pilspets | `setRawValue` |
| `ArrowheadLength` | Längd på pilspets | `setRawValue` |
| `ArrowheadWidth` | Bredd på pilspets | `setRawValue` |
| `StartAngle` | Startvinkel för en sektions‑ eller bågform | [setAngleValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Slutvinkel för en sektions‑ eller bågform | `setAngleValue` |

`getType` och `getName` returnerar skrivskyddad information. `getRawValue` och `setRawValue` arbetar med ett heltal i förinställningens egna geometrienheter, medan `getAngleValue` och `setAngleValue` arbetar med en vinkel i grader. Antalet, ordningen, betydelsen och det giltiga intervallet för justeringar beror på den förinställda [GeometryShape.getShapeType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/geometryshape/). Ett värde som är giltigt för en förinställning kan vara ogiltigt eller ha en annan effekt för en annan.

När `getType` returnerar `ShapeAdjustmentType.Custom` känner API‑et inte igen en standard semantisk betydelse. Inspektera `getName`, förinställningstypen och det befintliga värdet, och låt justeringen förbli oförändrad såvida inte den förväntade betydelsen och intervallet är känt. Även för erkända typer, kontrollera om samma typ förekommer mer än en gång innan du väljer ett värde. Artikeln [Connector](/slides/sv/nodejs-java/connector/) visar detta scenario med böjjusteringar för anslutningar.

Följande kompletta exempel skapar standard‑ och modifierade versioner av tre förinställda former. Det itererar genom varje justering, rapporterar dess namn och typ, ändrar storleksrelaterade värden via `setRawValue`, ändrar vinklar via `setAngleValue` och sparar resultatet. Den vänstra kolumnen behåller standardgeometrin; den högra kolumnen visar den justerade rundade rektangeln, fyrvägs‑pilen och sektionsformen.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // Lägger till rubriker för standard- och justerade formkolumner.
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Att kontrollera den semantiska typen innan ett värde ändras gör koden explicit om avsikten och undviker antagandet att ett specifikt samlingsindex har samma betydelse över olika förinställda former.

## **Ändra form‑samlingen**

Metoderna för att lägga till, klona, ta bort och omordna verkar omedelbart på samlingen. Om en operation förändrar antalet eller ordningen av former, fortsätt inte att förlita dig på index som fångats före den operationen.

### **Klona en form**

[addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/addclone/) skapar en oberoende kopia och lägger till den i mål‑samlingen. [insertClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/insertclone/) skapar också en kopia men placerar den på ett specificerat z‑order‑index. Överlagringarna som accepterar koordinater flyttar klonen utan att ändra dess storlek; överlagringar med bredd och höjd kan även ändra storlek.

Exemplet skapar en målbilder, klonar en märkt rektangel till framsidan och sätter in en andra klon bakifrån. Ändringar i någon av klonerna modifierar inte ursprungsformen.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kloning kopierar formens innehåll och formatering, inklusive namn och alternativ text. Tilldela nya logiska identifierare till klonen när dessa värden måste vara unika. Resurser som används av komplexa former hanteras av presentationen, men en klon förblir ett nytt samlingsobjekt med en ny form‑identitet.

### **Ta bort former**

[remove](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/remove/) raderar ett specifikt formobjekt från dess samling. När flera matchningar tas bort under indexerad iteration, gå bakifrån så att varje kvarstående index förblir giltigt.

Detta exempel tar bort varje form med ett angivet namn. Det läser formen på det aktuella indexet och antar inte en specifik formtyp.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Efter borttagning förändras antalet former och indexen för senare former. Referenser till opåverkade former förblir mer pålitliga än sparade index. Tänk också på anslutningar, animationer och andra presentationsfunktioner som kan referera till det borttagna objektet; att ta bort en synlig form kan förändra mer än bara bildens utseende.

### **Dölja en form**

Att sätta [Hidden](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/sethidden/) till `true` behåller formen i samlingen men hindrar den från att visas i den normala bildvisningen. Dess index, formatering och innehåll förblir tillgängliga för kod, så dölja är lämpligt för valfria element som kan återställas senare.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Döljning är ingen borttagning eller säkerhet. Objektet kan fortfarande upptäckas och göras synligt igen av en användare eller av kod, och det förblir en del av presentationsfilen.

### **Ändra Z‑ordning**

Överlappande former målas i samlingsordning. [reorder](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/reorder/) flyttar en befintlig form till ett mål‑index utan att klona den. Index `0` är bakre; `size() - 1` är främre.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rektangeln skapas först och sitter initialt bakom ellipsen. Att flytta den till sista indexet placerar den framför. Slutför z‑ordning efter att alla relaterade former lagts till eller klonats, eftersom de operationerna lägger till eller sätter in nya samlingsobjekt och kan ändra den avsedda stapeln.

## **Inspektera former på layout‑bilder**

Normala bilder, layout‑bilder och master‑bilder har separata form‑samlingar. En form i en layout‑samling är inte samma objekt som en likadant placerad form på en normal bild. Inspektera layout‑former när du behöver förstå eller ändra formatering som levereras av en layout.

Följande exempel läser varje layout‑forms [FillFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/getfillformat/) och [LineFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/getlineformat/) utan att anta att varje form är en `AutoShape`.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Att redigera en layout kan påverka flera bilder som använder den. Innan du ändrar en layout‑form, avgör om en normal bild ärver objektet eller innehåller en lokal överskrivning, och testa varje bild som använder den layouten.

## **Exportera en form till SVG**

[writeAsSvg](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/writeassvg/) skriver en enskild forms renderade innehåll till en ström. Resultatet innehåller formen, inte hela bildbakgrunden eller angränsande former.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Håll presentationen öppen under rendering. Utdata beror på formens formatering samt resurser som teckensnitt och bilder. Om du behöver hela sammansättningen, exportera bilden snarare än en enskild form. Anroparen äger strömmen och måste stänga den.

## **Justera former**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideutil/alignshapes/)‑överladdningarna justerar antingen alla former eller valda samlingsindex. [ShapesAlignmentType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapesalignmenttype/) specificerar kant, mittlinje eller fördelningsläge. Sätt `alignToSlide` till `true` för att använda bildens kanter; sätt den till `false` för att justera de valda formerna relativt varandra.

Detta exempel justerar tre former till bildens överkant. De returnerade formreferenserna konverteras till sina aktuella index omedelbart före justeringen.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Justering ändrar positioner, inte z‑ordning. Relativ justering kräver normalt minst två former, medan horisontell eller vertikal fördelning behöver tillräckligt många former för att definiera avståndet. Räkna om index om du modifierar samlingen innan du anropar metoden.

## **Flippa en form**

[ShapeFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapeframe/)‑klassen lagrar position, storlek, horisontella och vertikala flip‑inställningar samt rotation. Dess `getFlipH`‑ och `getFlipV`‑värden använder [NullableBool](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/nullablebool/): `True` aktiverar flip‑en, `False` inaktiverar den, och `NotDefined` bevarar det ospecificerade / standardtillståndet.

Den inmatade presentationen nedan innehåller en icke‑flippad form.

![Formen före flip](shape_to_be_flipped.png)

Exemplet bevarar varje annat ram‑värde och ersätter endast de två flip‑inställningarna. Detta är viktigt eftersom tilldelning av en ny [Frame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/setframe/) ersätter hela ramen.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Den sparade formen är speglad horisontellt och vertikalt samtidigt som position, storlek och rotation behålls.

![Formen efter flip](flipped_shape.png)

## **FAQ**

**Bör jag använda ett samlingsindex som formidentifierare?**

Endast för kortlivad bearbetning när samlingen inte kommer att förändras innan indexet används. Föredra en validerad `Name`‑ eller `AlternativeText`‑konvention för skapade mallar, eller `OfficeInteropShapeId` för bild‑specifik interop‑arbete.

**Tar dölja en form bort den från z‑ordningen?**

Nej. En dold form förblir i samlingen på samma index. Den kan hittas, omordnas, redigeras eller göras synlig igen.

**Varför dök en klonad form upp framför en annan form?**

`addClone` lägger till klonen i slutet av samlingen, vilket är fronten i z‑ordningen. Använd `insertClone` för att välja det initiala indexet eller `reorder` efter att alla former har lagts till.

**Kan jag använda ett fast index för att identifiera en förinställd formjustering?**

Endast efter att ha validerat den exakta förinställningen och samlingslayouten. Föredra att iterera genom `GeometryShape.getAdjustments` och kontrollera `AdjustValue.getType`; använd `AdjustValue.getName` som ytterligare information när samma semantiska typ förekommer mer än en gång.