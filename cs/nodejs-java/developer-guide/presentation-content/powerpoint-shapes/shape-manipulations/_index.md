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
description: "Zjistěte, jak identifikovat, klonovat, odstraňovat, skrývat, měnit pořadí, exportovat, zarovnávat a převracet tvary prezentace pomocí Aspose.Slides pro Node.js přes Java."
---
## **Přehled**

Aspose.Slides for Node.js via Java představuje tvary na snímku jako uspořádanou [ShapeCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/). Tato kolekce je zároveň místem, kde najdete a upravujete tvary, a zdrojem jejich pořadí vrstvení: index `0` je nejzadnější tvar, zatímco poslední index je nejpřednější tvar.

Tento článek následuje tento model. Nejprve vysvětluje, jak spolehlivě identifikovat tvar, poté ukazuje, jak klonovat, odstraňovat, skrývat a měnit pořadí tvarů. Poslední sekce pokrývají formátování na úrovni rozvržení, export do SVG, zarovnání a nastavení převrácení. Každý příklad je nezávislý, takže můžete použít jen operace, které vaše pracovní postupy vyžadují.

## **Identifikace a vyhledávání tvarů**

Indexy v kolekci jsou pohodlné při zpracování známého souboru, ale nejsou stabilními identifikátory. Přidání, odebrání nebo změna pořadí tvaru může změnit jeho index. Zvolte identifikátor podle toho, jak je prezentace vytvořena a udržována:

- [Name](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getname/) je užitečný pro šablony řízené vývojářem a snadno se kontroluje v panelu výběru v PowerPointu. Jména lze upravovat a nejsou zaručeně jedinečná, proto si stanovte pojmenovací konvenci, pokud na nich kód závisí.
- [AlternativeText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getalternativetext/) je užitečný, když už popis přístupnosti nebo autorově štítek tvar identifikuje. Je viditelný pro uživatele, může být lokalizován nebo přepsán pro přístupnost a není zaručeno, že bude jedinečný. Nepřepisujte tiše smysluplný text přístupnosti jako klíč databáze.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) je jen pro čtení a je jedinečný v rámci snímku a odpovídá ID tvaru používanému interopem PowerPointu. Použijte jej při integraci s PowerPointem nebo když potřebujete jednoznačný odkaz po celou dobu existence tvaru. Klonovaný nebo znovu vytvořený tvar je jiný tvar a získá své vlastní ID.

Související metoda [getUniqueId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getuniqueid/) vrací identifikátor s rozsahem prezentace, ale tento identifikátor je určen pro doplňky a může být přidělen znovu. Neměl by být považován za trvalý externí klíč. Pokud je dlouhodobá identita zásadní, uložte mapování v aplikačních datech a ověřte, že očekávaný tvar stále existuje.

Následující příklad vyhledává podle jména s přesnou shodou a oznamuje interop ID v rozsahu snímku. Když šablona neobsahuje očekávaný tvar, kód oznamuje tento výsledek místo toho, aby pokračoval se špatným objektem.

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

Když je operace specifická pro typ tvaru, zkontrolujte časovou třídu před použitím členů specifických pro typ. Tento příklad aktualizuje text a alternativní text pouze pokud je pojmenovaný objekt [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/).

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

## **Úprava kolekce tvarů**

Metody přidání, klonování, odstranění a změny pořadí působí na kolekci okamžitě. Pokud operace mění počet nebo pořadí tvarů, nespoléhejte se na indexy zachycené před touto operací.

### **Klonování tvaru**

[addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/addclone/) vytvoří nezávislou kopii a připojí ji k cílové kolekci. [insertClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/insertclone/) také vytvoří kopii, ale umístí ji na zadaný index ve vrstvení. Přetížení, která přijímají souřadnice, přesunou klon bez změny jeho velikosti; přetížení s šířkou a výškou jej mohou také změnit velikost.

Příklad vytvoří cílový snímek, klonuje označený obdélník dopředu a vloží druhý klon dozadu. Změny v libovolném klonu neovlivní zdrojový tvar.

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

Klonování kopíruje obsah a formátování tvaru, včetně jeho jména a alternativního textu. Při klonování přiřaďte nové logické identifikátory, pokud musí být tyto hodnoty jedinečné. Zdroje používané složitými tvary spravuje prezentace, ale klon zůstává novou položkou v kolekci s novou identitou tvaru.

### **Odstraňování tvarů**

[remove](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/remove/) smaže konkrétní objekt tvaru z jeho kolekce. Při odstraňování více shod během indexované iterace procházejte od konce, aby každý zbývající index zůstal platný.

Tento příklad odstraňuje každý tvar s určeným jménem. Načte tvar na aktuálním indexu a nepředpokládá konkrétní typ tvaru.

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

Po odstranění se počet tvarů a indexy pozdějších tvarů změní. Odkazy na nedotčené tvary zůstávají spolehlivější než uložené indexy. Také zvažte konektory, animace a další funkce prezentace, které mohou odkazovat na odebraný objekt; odstranění viditelného tvaru může změnit víc než jen vzhled snímku.

### **Skrytí tvaru**

Nastavení [Hidden](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/sethidden/) na `true` ponechá tvar v kolekci, ale zabrání mu se objevit v normálním režimu prezentace. Jeho index, formátování i obsah zůstávají k dispozici kódu, takže skrytí je vhodné pro volitelné prvky, které mohou být později obnoveny.

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

Skrytí není smazání ani zabezpečení. Objekt může být stále objeven a opět zobrazen uživatelem nebo kódem a zůstává součástí souboru prezentace.

### **Změna Z-objednávky**

Překrývající se tvary se kreslí v pořadí kolekce. [reorder](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/reorder/) přesune existující tvar na cílový index bez jeho klonování. Index `0` je zadní; `size() - 1` je přední.

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

Obdélník je vytvořen jako první a zpočátku leží za elipsou. Přesunutí na poslední index jej umístí dopředu. Dokončete z-objednávku po přidání nebo klonování všech souvisejících tvarů, protože tyto operace přidávají nebo vkládají nové položky do kolekce a mohou změnit zamýšlený zásobník.

## **Prohlížení tvarů na snímcích rozvržení**

Normální snímky, snímky rozvržení a hlavní snímky mají samostatné kolekce tvarů. Tvar v kolekci rozvržení není stejný objekt jako podobně umístěný tvar na normálním snímku. Prohlédněte tvary rozvržení, když potřebujete pochopit nebo změnit formátování poskytnuté rozvržením.

Následující příklad načte [FillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getfillformat/) a [LineFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getlineformat/) každého tvaru rozvržení bez předpokladu, že každý tvar je `AutoShape`.

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

Úprava rozvržení může ovlivnit více snímků, které ho používají. Před změnou tvaru v rozvržení zjistěte, zda normální snímek zdědí objekt nebo obsahuje lokální přepsání, a otestujte každý snímek, který toto rozvržení používá.

## **Export tvaru do SVG**

[writeAsSvg](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/writeassvg/) zapíše vykreslený obsah jednoho tvaru do proudu. Výsledek obsahuje pouze tvar, nikoli celé pozadí snímku nebo sousední tvary.

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

Udržujte prezentaci otevřenou během vykreslování. Výstup závisí na formátování tvaru a na zdrojích, jako jsou písma a obrázky. Pokud potřebujete celý sestava, exportujte snímek místo jednotlivého tvaru. Volající vlastní proud a musí jej uzavřít.

## **Zarovnání tvarů**

Přetížení [SlideUtil.alignShapes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideutil/alignshapes/) zarovnává buď všechny tvary, nebo vybrané indexy v kolekci. [ShapesAlignmentType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapesalignmenttype/) určuje okraj, středovou čáru nebo režim rozdělení. Nastavte `alignToSlide` na `true`, chcete-li použít okraje snímku; nastavte na `false`, chcete-li zarovnat vybrané tvary vůči sobě navzájem.

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

Zarovnání mění pozice, ne z-objednávku. Relativní zarovnání obvykle vyžaduje alespoň dva tvary, zatímco vodorovné nebo svislé rozdělení vyžaduje dostatek tvarů pro definování rozestupů. Přepočítejte indexy, pokud před voláním metody upravujete kolekci.

## **Převrácení tvaru**

Třída [ShapeFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapeframe/) ukládá pozici, velikost, horizontální a vertikální nastavení převrácení a rotaci. Její hodnoty `getFlipH` a `getFlipV` používají [NullableBool](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/nullablebool/): `True` povolí převrácení, `False` jej zakáže a `NotDefined` zachová nedefinovaný/výchozí stav.

Vstupní prezentace níže obsahuje jeden netransformovaný tvar.

![The shape before flipping](shape_to_be_flipped.png)

Příklad zachovává všechny ostatní hodnoty rámce a nahrazuje jen dvě nastavení převrácení. To je důležité, protože při přiřazení nového [Frame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/setframe/) se nahradí celý rámec.

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

Uložený tvar je horizontálně i vertikálně zrcadlený, přičemž zachovává svou pozici, velikost a rotaci.

![The shape after flipping](flipped_shape.png)

## **Často kladené otázky**

**Mám používat index kolekce jako identifikátor tvaru?**

Pouze pro krátkodobé zpracování, kdy se kolekce před použitím indexu nezmění. Upřednostněte ověřenou konvenci `Name` nebo `AlternativeText` pro vytvořené šablony, nebo `OfficeInteropShapeId` pro práci s interopem ve snímku.

**Odstraňuje skrytí tvaru jeho z-objednávku?**

Ne. Skrytý tvar zůstává v kolekci na stejném indexu. Lze jej najít, změnit jeho pořadí, upravit nebo znovu zobrazit.

**Proč se klonovaný tvar objevil před jiným tvarem?**

`addClone` připojí klon na konec kolekce, což je přední část z-objednávky. Použijte `insertClone` pro volbu počátečního indexu nebo `reorder` po přidání všech tvarů.