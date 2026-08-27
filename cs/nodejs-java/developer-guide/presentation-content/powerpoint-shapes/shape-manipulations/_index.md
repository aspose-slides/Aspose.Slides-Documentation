---
title: Správa tvarů prezentace v JavaScriptu
linktitle: Manipulace s tvary
type: docs
weight: 40
url: /cs/nodejs-java/shape-manipulations/
keywords:
- tvar PowerPoint
- tvar prezentace
- tvar na snímku
- najít tvar
- klonovat tvar
- odstranit tvar
- skrýt tvar
- změnit pořadí tvaru
- získat interop ID tvaru
- alternativní text tvaru
- bod úpravy tvaru
- přednastavená úprava tvaru
- geometrie tvaru
- formáty rozvržení tvaru
- tvar jako SVG
- tvar do SVG
- zarovnat tvar
- převrátit tvar
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak identifikovat, upravovat, klonovat, odstraňovat, skrývat, měnit pořadí, exportovat, zarovnávat a převracet tvary prezentace pomocí Aspose.Slides pro Node.js přes Java."
---
## **Přehled**

Aspose.Slides pro Node.js přes Java představuje tvary na snímku jako uspořádanou [ShapeCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/). Kolekce je zároveň místem, kde najdete a upravujete tvary, a zdrojem jejich pořadí překrývání: index `0` je nejzadnější tvar, zatímco poslední index je nejpopřednější tvar.

Tento článek následuje tento model. Nejprve vysvětluje, jak spolehlivě identifikovat tvar a upravit přednastavené úpravné body tvaru, poté ukazuje, jak klonovat, odstraňovat, skrývat a měnit pořadí tvarů. Závěrečné sekce pokrývají formátování na úrovni rozvržení, export do SVG, zarovnání a nastavení převrácení. Každý příklad je nezávislý, takže můžete použít pouze operace, které váš workflow vyžaduje.

## **Identifikace a vyhledávání tvarů**

Indexy v kolekci jsou praktické při zpracování známého souboru, ale nejsou stabilními identifikátory. Přidání, odebrání nebo změna pořadí tvaru může změnit jeho index. Vyberte identifikátor podle toho, jak je prezentace vytvářena a udržována:

- [Name](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getname/) je užitečný pro šablony řízené vývojáři a snadno jej lze zkontrolovat v panelu výběru PowerPointu. Jména lze upravovat a nejsou zaručena jako jedinečná, takže si stanovte pojmenovací konvenci, pokud na nich kód závisí.
- [AlternativeText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getalternativetext/) je užitečný, když již popis přístupnosti nebo autorovo označení identifikuje tvar. Je viditelný uživatelům, může být lokalizován nebo přepsán pro přístupnost a také není zaručeně jedinečný. Nepoužívejte tichý významný text přístupnosti jako klíč databáze.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) je jen pro čtení a je jedinečný v rámci snímku a odpovídá ID tvaru používanému v interop PowerPointu. Použijte jej při integraci s PowerPointem nebo když potřebujete jednoznačný odkaz během životnosti tvaru. Klonovaný nebo znovu vytvořený tvar je jiný tvar a získá vlastní ID.

Související metoda [getUniqueId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getuniqueid/) vrací identifikátor s rozsahem prezentace, ale tento identifikátor je určen pro doplňky a může být přeřazen. Neměl by být považován za trvalý externí klíč. Pokud je dlouhodobá identita zásadní, uložte mapování v aplikačních datech a ověřte, že očekávaný tvar stále existuje.

Následující příklad hledá podle jména s přesnou porovnáním a hlásí interop ID v rozsahu snímku. Když šablona neobsahuje očekávaný tvar, kód nahlásí tento výsledek místo pokračování s nesprávným objektem.

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

Když je operace specifická pro typ tvaru, zkontrolujte runtime třídu před použitím typově specifických členů. Tento příklad aktualizuje text a alternativní text pouze pokud pojmenovaný objekt je [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/).

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

## **Identifikace a úprava přednastavených úprav tvaru**

Tvary s přednastavenou geometrií mohou odhalovat úpravné body, které řídí vlastnosti jako velikost rohu, proporce šipky nebo úhly oblouku. Přistupujte k nim přes jen pro čtení kolekci [GeometryShape.getAdjustments](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/geometryshape/). Kolekce je poskytována tvarem, ale každý [AdjustValue](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/adjustvalue/) obsahuje hodnotu, kterou lze změnit.

Nespoléhejte se jen na pevný index kolekce. Procházejte úpravy a kontrolujte jen pro čtení metodu [getType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/adjustvalue/), jejíž hodnota [ShapeAdjustmentType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapeadjustmenttype/) popisuje, co úprava ovládá. Jen pro čtení metoda [getName](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/adjustvalue/getname/) poskytuje další identifikační informace a je zvláště užitečná, když přednastavení obsahuje více úprav se stejným sémantickým typem.

Použijte metodu hodnoty, která odpovídá významu úpravy:

| Typ úpravy | Účel | Hodnota ke změně |
|---|---|---|
| `CornerSize` | Velikost zaoblených rohů | [setRawValue](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Tloušťka ocasu šipky | `setRawValue` |
| `ArrowheadLength` | Délka špičky šipky | `setRawValue` |
| `ArrowheadWidth` | Šířka špičky šipky | `setRawValue` |
| `StartAngle` | Počáteční úhel výseče nebo oblouku | [setAngleValue](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Koncový úhel výseče nebo oblouku | `setAngleValue` |

`getType` a `getName` vrací jen pro čtení informace. `getRawValue` a `setRawValue` pracují s celým číslem v nativních jednotkách geometrie přednastavení, zatímco `getAngleValue` a `setAngleValue` pracují s úhlem ve stupních. Počet, pořadí, význam a platný rozsah úprav závisí na typu přednastavení [GeometryShape.getShapeType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/geometryshape/). Hodnota platná pro jedno přednastavení může být neplatná nebo mít jiný efekt pro jiné.

Když `getType` vrátí `ShapeAdjustmentType.Custom`, API nepozná standardní sémantický význam. Prozkoumejte `getName`, typ přednastavení a existující hodnotu a nechte úpravu nezměněnou, pokud není znám očekávaný význam a rozsah. I pro rozpoznané typy zkontrolujte, zda se stejný typ neobjevuje vícekrát, než vyberete hodnotu. Článek [Connector](/slides/cs/nodejs-java/connector/) ukazuje tuto situaci s úpravami zakřivení konektoru.

Následující kompletní příklad vytváří výchozí a upravené verze tří přednastavených tvarů. Prochází každou úpravu, hlásí její název a typ, mění hodnoty související s velikostí pomocí `setRawValue`, mění úhly pomocí `setAngleValue` a ukládá výsledek. Levý sloupec zachovává výchozí geometrii; pravý sloupec ukazuje upravený zaoblený obdélník, čtyřcestnou šipku a koláč.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // Přidá záhlaví pro výchozí a upravené sloupce tvarů.
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

Kontrola sémantického typu před změnou hodnoty činí kód explicitním ohledně jeho záměru a zabraňuje předpokladu, že konkrétní index kolekce má stejný význam u různých přednastavených tvarů.

## **Úprava kolekce tvarů**

Metody přidání, klonování, odebrání a změny pořadí působí na kolekci okamžitě. Pokud operace změní počet nebo pořadí tvarů, nepokračujte v používání indexů zachycených před touto operací.

### **Klonovat tvar**

[addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/addclone/) vytváří nezávislou kopii a přidává ji na konec cílové kolekce. [insertClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/insertclone/) také vytváří kopii, ale umístí ji na zadaný index z‑order. Přetížení, která přijímají souřadnice, přesunou klon bez změny velikosti; přetížení s šířkou a výškou jej mohou také změnit.

Příklad vytváří cílový snímek, klonuje označený obdélník dopředu a vloží druhý klon dozadu. Změny v kterémkoli klonu neovlivní zdrojový tvar.

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

Klonování kopíruje obsah a formátování tvaru, včetně jeho jména a alternativního textu. Při klonování přiřaďte nové logické identifikátory, pokud musí být tyto hodnoty jedinečné. Zdroje používané složitými tvary jsou spravovány prezentací, ale klon zůstává novou položkou kolekce s novou identitou tvaru.

### **Odstranit tvary**

[remove](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/remove/) smaže konkrétní objekt tvaru z jeho kolekce. Při odstraňování více shod během iterace s indexy procházejte od konce, aby každý zbývající index zůstal platný.

Tento příklad odstraňuje každý tvar s určeným jménem. Čte tvar na aktuálním indexu a nepředpokládá konkrétní typ tvaru.

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

Po odstranění se mění počet tvarů a indexy následujících tvarů. Odkazy na neovlivněné tvary zůstávají spolehlivější než uložené indexy. Také zvažte konektory, animace a další funkce prezentace, které mohou odkazovat na odstraněný objekt; odstranění viditelného tvaru může změnit více než jen vzhled snímku.

### **Skrýt tvar**

Nastavení [Hidden](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/sethidden/) na `true` ponechá tvar v kolekci, ale zabrání jeho zobrazení v normálním režimu prezentace. Jeho index, formátování i obsah zůstávají k dispozici kódu, takže skrytí je vhodné pro volitelné prvky, které mohou být později obnoveny.

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

Skrývání není smazání ani zabezpečení. Objekt může být stále objeven a odhalen uživatelem nebo kódem a zůstává součástí souboru prezentace.

### **Změnit Z‑order**

Překrývající se tvary se vykreslují podle pořadí v kolekci. [reorder](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/reorder/) přesune existující tvar na cílový index bez jeho klonování. Index `0` je zadní; `size() - 1` je přední.

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

Obdélník je vytvořen jako první a zpočátku leží za elipsou. Přesunutím na konečný index se dostane dopředu. Finalizujte Z‑order po přidání nebo klonování všech souvisejících tvarů, protože tyto operace přidávají nebo vkládají nové položky do kolekce a mohou změnit zamýšlený zásobník.

## **Prohlédnout tvary na rozvržných snímcích**

Normální snímky, rozvržné snímky a master snímky mají samostatné kolekce tvarů. Tvar v kolekci rozvržení není stejný objekt jako podobně umístěný tvar na normálním snímku. Prohlédněte rozvržné tvary, když potřebujete pochopit nebo změnit formátování dodávané rozvržením.

Následující příklad čte pro každý rozvržný tvar jeho [FillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getfillformat/) a [LineFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getlineformat/) bez předpokladu, že každý tvar je `AutoShape`.

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

Úprava rozvržení může ovlivnit více snímků, které jej používají. Před změnou rozvržného tvaru zjistěte, zda normální snímek objekt zdědí nebo obsahuje lokální přepsání, a otestujte každý snímek, který toto rozvržení používá.

## **Exportovat tvar do SVG**

[writeAsSvg](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/writeassvg/) zapíše vykreslený obsah jednoho tvaru do proudu. Výsledek obsahuje jen tvar, ne celé pozadí snímku ani sousední tvary.

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

Udržujte prezentaci otevřenou během vykreslování. Výstup závisí na formátování tvaru a na zdrojích, jako jsou fonty a obrázky. Pokud potřebujete celou kompozici, exportujte snímek místo jednotlivého tvaru. Volající vlastní proud a musí jej uzavřít.

## **Zarovnat tvary**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideutil/alignshapes/) má přetížení, která zarovnají buď všechny tvary, nebo vybrané indexy kolekce. [ShapesAlignmentType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapesalignmenttype/) určuje okraj, středovou čáru nebo režim rozdělení. Nastavte `alignToSlide` na `true`, chcete-li použít okraje snímku; nastavte na `false`, chcete-li zarovnat vybrané tvary vůči sobě navzájem.

Tento příklad zarovnává tři tvary k hornímu okraji snímku. Vrácené odkazy na tvary jsou převedeny na jejich aktuální indexy těsně před zarovnáním.

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

Zarovnání mění pozice, ne Z‑order. Relativní zarovnání obvykle vyžaduje alespoň dva tvary, zatímco horizontální nebo vertikální rozdělení potřebuje dostatek tvarů pro definování mezery. Pokud před voláním metody upravujete kolekci, přepočítejte indexy.

## **Převrátit tvar**

Třída [ShapeFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapeframe/) ukládá pozici, velikost, nastavení horizontálního a vertikálního převrácení a rotaci. Její hodnoty `getFlipH` a `getFlipV` používají [NullableBool](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/nullablebool/): `True` povolí převrácení, `False` jej zakáže a `NotDefined` zachová nedefinovaný/výchozí stav.

Vstupní prezentace níže obsahuje jeden nepřevrácený tvar.

![The shape before flipping](shape_to_be_flipped.png)

Příklad zachovává všechny ostatní hodnoty rámce a nahrazuje pouze dvě nastavení převrácení. To je důležité, protože při přiřazení nového [Frame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/setframe/) se nahradí celý rámec.

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

Uložený tvar je horizontálně i vertikálně zrcadlený při zachování pozice, velikosti a rotace.

![The shape after flipping](flipped_shape.png)

## **Často kladené otázky**

**Mám používat index kolekce jako identifikátor tvaru?**

Pouze pro krátkodobé zpracování, kdy se kolekce před použitím indexu nezmění. Upřednostněte ověřenou konvenci `Name` nebo `AlternativeText` pro vytvořené šablony, nebo `OfficeInteropShapeId` pro práci s interopem na úrovni snímku.

**Odstraňuje skrytí tvaru jeho pozici v Z‑order?**

Ne. Skrytý tvar zůstává v kolekci na stejném indexu. Lze jej najít, změnit pořadí, upravit nebo opět zobrazit.

**Proč se klonovaný tvar objevil před jiným tvarem?**

`addClone` přidá klon na konec kolekce, což je přední část Z‑orderu. Použijte `insertClone` pro volbu počátečního indexu nebo `reorder` po přidání všech tvarů.

**Mohu použít pevný index k identifikaci úpravy přednastaveného tvaru?**

Pouze po ověření přesného přednastavení a rozložení kolekce. Upřednostněte iteraci přes `GeometryShape.getAdjustments` a kontrolu `AdjustValue.getType`; použijte `AdjustValue.getName` jako doplňující informaci, když se stejný sémantický typ vyskytuje vícekrát.