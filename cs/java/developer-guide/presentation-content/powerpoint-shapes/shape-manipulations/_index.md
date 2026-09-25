---
title: Správa tvarů prezentace v Javě
linktitle: Manipulace s tvary
type: docs
weight: 40
url: /cs/java/shape-manipulations/
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
- Java
- Aspose.Slides
description: "Naučte se, jak identifikovat, upravit, klonovat, odstranit, skrýt, změnit pořadí, exportovat, zarovnat a převrátit tvary prezentace pomocí Aspose.Slides pro Javu."
---
## **Přehled**

Aspose.Slides for Java představuje tvary na snímku jako uspořádanou [IShapeCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/). Kolekce je zároveň místem, kde můžete tvary najít a upravit, a zdrojem jejich pořadí vrstvení: index `0` je nejzadnější tvar, zatímco poslední index je nejpřednější tvar.

Tento článek následuje tento model. Nejprve vysvětluje, jak spolehlivě identifikovat tvar a upravit přednastavené body úpravy tvaru, poté ukazuje, jak klonovat, odstraňovat, skrývat a měnit pořadí tvarů. Závěrečné sekce se věnují formátování na úrovni rozvržení, exportu do SVG, zarovnání a nastavení převrácení. Každý příklad je nezávislý, takže můžete použít jen operace, které váš workflow vyžaduje.

## **Identifikace a hledání tvarů**

Indexy v kolekci jsou praktické při zpracování známého souboru, ale nejsou stabilními identifikátory. Přidání, odebrání nebo změna pořadí tvaru může změnit jeho index. Zvolte identifikátor podle toho, jak je prezentace vytvořena a udržována:

- [Name](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getName--) je užitečný pro šablony řízené vývojáři a lze jej snadno zkontrolovat v panelu výběru PowerPointu. Názvy lze upravovat a nejsou garantovány jako jedinečné, takže pokud kód na nich závisí, stanovte pojmenovací konvenci.
- [AlternativeText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getAlternativeText--) je užitečný, když již popis přístupnosti nebo autorovo označení identifikuje tvar. Je viditelný pro uživatele, může být lokalizován nebo přepsán pro přístupnost a není garantován jako jedinečný. Neukládejte tiše smysluplný text přístupnosti jako klíč databáze.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) je pouze pro čtení a jedinečný v rámci snímku, odpovídá ID tvaru používanému interopem PowerPointu. Použijte jej při integraci s PowerPointem nebo když potřebujete jednoznačný odkaz během životnosti tvaru. Klonovaný nebo znovu vytvořený tvar je jiný tvar a získá své vlastní ID.

Související metoda [getUniqueId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getUniqueId--) vrací identifikátor s rozsahem prezentace, ale tento identifikátor je určen pro doplňky a může být přeřazen. Neměl by být považován za trvalý externí klíč. Pokud je dlouhodobá identita podstatná, uložte mapování v datech aplikace a ověřte, že očekávaný tvar stále existuje.

Pro praktický příklad čtení a aktualizace jak titulu alternativního textu, tak popisu, viz [Manage Alternative Text Titles and Descriptions](/slides/cs/java/presentation-accessibility/). Používejte alternativní text k vysvětlení významu vizuálu čtenářům a oddělte jej od názvů tvarů používaných kódem k vyhledávání tvarů.

Následující příklad hledá podle názvu s přesnou shodou a hlásí interopní ID v rámci snímku. Když šablona neobsahuje očekávaný tvar, kód vypíše tento výsledek místo pokračování s nesprávným objektem.

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

Když je operace specifická pro typ tvaru, zkontrolujte rozhraní před použitím členů specifických pro typ. Tento příklad aktualizuje text a alternativní text pouze pokud pojmenovaný objekt je [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/).

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

## **Identifikace a úprava přednastavených úprav tvaru**

Tvary s přednastavenou geometrií mohou mít body úpravy, které řídí např. velikost rohu, proporce šipky nebo úhly oblouku. Přistupujte k nim přes kolekci jen pro čtení [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/cs/java/com.aspose.slides/igeometryshape/#getAdjustments--). Kolekci poskytuje samotný tvar, ale každý [IAdjustValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iadjustvalue/) obsahuje hodnotu, kterou lze změnit.

 nespoléhejte se pouze na pevný index kolekce. Procházejte úpravy a kontrolujte jen pro čtení metodu [getType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iadjustvalue/#getType--), jejíž hodnota [ShapeAdjustmentType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shapeadjustmenttype/) popisuje, co úprava ovládá. Metoda jen pro čtení [getName](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iadjustvalue/#getName--) poskytuje další identifikační informace a je zvláště užitečná, když přednastavení obsahuje více úprav se stejným sémantickým typem.

Použijte metodu, která odpovídá významu úpravy:

| Typ úpravy | Účel | Hodnota k změně |
|---|---|---|
| `CornerSize` | Velikost zaoblených rohů | [setRawValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Tloušťka ocasu šipky | `setRawValue` |
| `ArrowheadLength` | Délka špičky šipky | `setRawValue` |
| `ArrowheadWidth` | Šířka špičky šipky | `setRawValue` |
| `StartAngle` | Počáteční úhel výseče nebo oblouku | [setAngleValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Konečný úhel výseče nebo oblouku | `setAngleValue` |

`getType` a `getName` vrací jen pro čtení informace. `getRawValue` a `setRawValue` pracují s celým číslem v nativních jednotkách geometrie přednastavení, zatímco `getAngleValue` a `setAngleValue` pracují s úhlem ve stupních. Počet, pořadí, význam a platný rozsah úprav závisí na přednastaveném [ShapeType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/igeometryshape/#getShapeType--). Hodnota platná pro jedno přednastavení může být neplatná nebo mít jiný efekt pro jiné.

Když `getType` vrátí `ShapeAdjustmentType.Custom`, API nepozná standardní sémantický význam. Prozkoumejte `getName`, typ přednastavení a existující hodnotu a ponechte úpravu beze změny, pokud neznáte očekávaný význam a rozsah. I pro rozpoznané typy zkontrolujte, zda se stejný typ nevyskytuje vícekrát, než vyberete hodnotu. Článek [Connector](/slides/cs/java/connector/) ukazuje tuto situaci u úprav ohýbání konektorů.

Následující kompletní příklad vytváří výchozí a modifikované verze tří přednastavených tvarů. Prochází každou úpravu, vypisuje její název a typ, mění hodnoty související s velikostí pomocí `setRawValue`, mění úhly pomocí `setAngleValue` a ukládá výsledek. Levý sloupec zachovává výchozí geometrii; pravý sloupec ukazuje upravený zaoblený obdélník, čtyřcestnou šipku a výseč.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidá záhlaví pro sloupce výchozího a upraveného tvaru.
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

Kontrola sémantického typu před změnou hodnoty činí kód explicitním ohledně záměru a zabraňuje předpokladu, že konkrétní index kolekce má stejný význam napříč různými přednastavenými tvary.

## **Úprava kolekce tvarů**

Metody pro přidání, klonování, odebrání a změnu pořadí operují na kolekci okamžitě. Pokud operace změní počet nebo pořadí tvarů, neustále se nespoléhejte na indexy zachycené před touto operací.

### **Klonování tvaru**

[addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) vytváří nezávislou kopii a připojuje ji k cílové kolekci. [insertClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) také vytváří kopii, ale umístí ji na zadaný index z‑orderu. Přetížení, která přijímají souřadnice, přesunou klon bez změny jeho velikosti; přetížení s šířkou a výškou jej mohou také změnit velikost.

Příklad vytváří cílový snímek, klonuje označený obdélník dopředu a vkládá druhý klon dozadu. Změny na kterémkoli klonu neovlivní výchozí tvar.

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

Klonování kopíruje obsah a formátování tvaru, včetně jeho názvu a alternativního textu. Přidělte novým klonům logické identifikátory, pokud musí být tyto hodnoty jedinečné. Prostředky použité složitými tvary spravuje prezentace, ale klon zůstává novou položkou kolekce s novou identitou tvaru.

### **Odebrání tvarů**

[remove](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) maže konkrétní objekt tvaru z jeho kolekce. Při odstraňování více shod během procházení indexovaného seznamu iterujte od konce, aby každý zbývající index zůstal platný.

Tento příklad odstraňuje každý tvar s určeným názvem. Čte tvar na aktuálním indexu, ne pevnou položku kolekce, a zbytečně jej nekonvertuje.

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

Po odebrání se počet tvarů a indexy následujících tvarů mění. Odkazy na nedotčené tvary zůstávají spolehlivější než uložené indexy. Rovněž zvažte konektory, animace a další prvky prezentace, které mohou odkazovat na odebraný objekt; odebrání viditelného tvaru může změnit více než jen vzhled snímku.

### **Skrytí tvaru**

Nastavení [Hidden](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#setHidden-boolean-) na `true` ponechá tvar v kolekci, ale zabrání jeho zobrazení v běžném režimu prezentace. Jeho index, formátování i obsah zůstávají k dispozici kódu, takže skrytí je vhodné pro volitelné prvky, které můžete později obnovit.

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

Skrytí není smazání ani zabezpečení. Objekt může stále být objeven a odskryt uživatelem nebo kódem a zůstává součástí souboru prezentace.

### **Změna Z‑orderu**

Překrývající se tvary jsou vykreslovány v pořadí kolekce. [reorder](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) přesouvá existující tvar na cílový index bez jeho klonování. Index `0` je zadní; `size() - 1` je přední.

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

Obdélník je vytvořen nejprve a zpočátku leží za elipsou. Přesunutí na poslední index jej postaví dopředu. Dokončete z‑order po přidání nebo klonování všech souvisejících tvarů, protože tyto operace přidávají nebo vkládají nové položky kolekce a mohou změnit zamýšlený zásobník.

## **Prohlížení tvarů na rozvrhových snímcích**

Obyčejné snímky, rozvrhové snímky a hlavní snímky mají oddělené kolekce tvarů. Tvar v kolekci rozvrhu není stejný objekt jako podobně umístěný tvar na obyčejném snímku. Prohlédněte si tvary rozvrhu, když potřebujete pochopit nebo změnit formátování poskytnuté rozvrhem.

Následující příklad čte [FillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getFillFormat--) a [LineFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getLineFormat--) každého tvaru rozvrhu, aniž by předpokládal, že každý tvar je `AutoShape`.

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

Úprava rozvrhu může ovlivnit více snímků, které jej používají. Před změnou tvaru rozvrhu zjistěte, zda obyčejný snímek dědí objekt nebo má lokální přepis, a otestujte každý snímek, který daný rozvrh používá.

## **Export tvaru do SVG**

[writeAsSvg](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) zapisuje vykreslený obsah jednoho tvaru do proudu. Výsledek obsahuje tvar, ne celou pozadí snímku ani sousední tvary.

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

Udržujte prezentaci otevřenou během renderování. Výstup závisí na formátování tvaru a na prostředcích, jako jsou písma a obrázky. Pokud potřebujete celou kompozici, exportujte snímek místo jednotlivého tvaru. Volající vlastní proud a musí jej uzavřít.

## **Zarovnání tvarů**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) má přetížení, která zarovnají buď všechny tvary, nebo vybrané indexy kolekce. [ShapesAlignmentType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shapesalignmenttype/) určuje hranu, středovou linii nebo režim rozdělení. Nastavte `alignToSlide` na `true`, chcete‑li použít hrany snímku; nastavte na `false`, chcete‑li zarovnat vybrané tvary vůči sobě navzájem.

Tento příklad zarovnává tři tvary k horní hraně snímku. Vrácené reference tvarů jsou před zarovnáním okamžitě převedeny na jejich aktuální indexy.

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

Zarovnání mění pozice, ne z‑order. Relativní zarovnání obvykle vyžaduje alespoň dva tvary, zatímco horizontální nebo vertikální rozdělení potřebuje dostatek tvarů k definování mezery. Pokud před voláním metody upravujete kolekci, přepočítejte indexy.

## **Převrácení tvaru**

Třída [ShapeFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shapeframe/) ukládá polohu, velikost, horizontální a vertikální nastavení převrácení a rotaci. Její hodnoty `getFlipH` a `getFlipV` používají [NullableBool](https://reference.aspose.com/slides/cs/java/com.aspose.slides/nullablebool/): `True` zapíná převrácení, `False` jej vypíná a `NotDefined` zachovává nevymezený/ výchozí stav.

Vstupní prezentace níže obsahuje jeden neotočený tvar.

![The shape before flipping](shape_to_be_flipped.png)

Příklad zachovává všechny ostatní hodnoty rámce a nahrazuje jen dvě nastavení převrácení. To je důležité, protože při přiřazení nového [Frame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) se nahradí celý rámec.

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

Uložený tvar je zrcadlen horizontálně i vertikálně, přičemž si zachovává svou polohu, velikost a rotaci.

![The shape after flipping](flipped_shape.png)

## **Často kladené otázky**

**Mám používat index kolekce jako identifikátor tvaru?**

Pouze pro krátkodobé zpracování, kdy se kolekce před použitím indexu již nezmění. Upřednostněte ověřenou konvenci `Name` nebo `AlternativeText` pro šablony, nebo `OfficeInteropShapeId` pro práci s interopem na úrovni snímku.

**Odstraňuje skrytí tvaru jeho z‑order?**

Ne. Skrytý tvar zůstává v kolekci na stejném indexu. Lze jej najít, změnit pořadí, upravit nebo opět zobrazit.

**Proč se klonovaný tvar objevil před jiným tvarem?**

`addClone` přidá klon na konec kolekce, což je přední část z‑orderu. Použijte `insertClone` pro výběr počátečního indexu nebo `reorder` po přidání všech tvarů.

**Mohu použít pevný index k identifikaci přednastavené úpravy tvaru?**

Pouze po ověření přesného přednastavení a rozvržení kolekce. Upřednostněte iteraci přes `IGeometryShape.getAdjustments` a kontrolu `IAdjustValue.getType`; použijte `IAdjustValue.getName` jako doplňující informaci, když se stejný sémantický typ vyskytuje vícekrát.