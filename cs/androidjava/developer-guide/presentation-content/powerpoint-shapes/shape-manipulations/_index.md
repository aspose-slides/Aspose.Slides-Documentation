---
title: Spravovat tvary prezentace na Androidu
linktitle: Manipulace s tvary
type: docs
weight: 40
url: /cs/androidjava/shape-manipulations/
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
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak identifikovat, upravovat, klonovat, odstraňovat, skrývat, měnit pořadí, exportovat, zarovnávat a převracet tvary prezentace pomocí Aspose.Slides pro Android prostřednictvím Javy."
---
## **Přehled**

Aspose.Slides pro Android prostřednictvím Java představuje tvary na snímku jako uspořádanou [IShapeCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/). Kolekce je zároveň místem, kde najdete a upravujete tvary, a zdrojem jejich pořadí překrývání: index `0` je nejzadnější tvar, zatímco poslední index je nejpřednější tvar.

Tento článek následuje tento model. Nejprve vysvětluje, jak spolehlivě identifikovat tvar a upravit přednastavené body úpravy tvaru, poté ukazuje, jak klonovat, odstraňovat, skrývat a měnit pořadí tvarů. Poslední sekce pokrývají formátování na úrovni rozvržení, export do SVG, zarovnání a nastavení převrácení. Každý příklad je nezávislý, takže můžete použít jen operace, které vaše pracovní postup vyžaduje.

## **Identifikace a vyhledávání tvarů**

Indexy v kolekci jsou pohodlné při zpracování známého souboru, ale nejsou stabilními identifikátory. Přidání, odstranění nebo změna pořadí tvaru může změnit jeho index. Zvolte identifikátor podle toho, jak je prezentace vytvořena a udržována:

- [Name](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getName--) je užitečný pro šablony řízené vývojářem a snadno se kontroluje v panelu výběru PowerPointu. Jména lze upravovat a nejsou garantována jako jedinečná, takže pokud kód na nich závisí, zaveďte pojmenovací konvenci.
- [AlternativeText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getAlternativeText--) je užitečný, když již popis přístupnosti nebo značka dodaná autorem identifikuje tvar. Je viditelný uživatelům, může být lokalizován nebo přepsán pro přístupnost a také není garantován jako jedinečný. Nepřevádějte tiše smysluplný text přístupnosti na klíč databáze.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) je jen pro čtení a je jedinečný v rámci snímku a odpovídá ID tvaru používanému v interop PowerPointu. Použijte jej při integraci s PowerPointem nebo když potřebujete jednoznačný odkaz během životnosti tvaru. Klonovaný nebo znovu vytvořený tvar je jiný tvar a získá své vlastní ID.

Související metoda [getUniqueId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getUniqueId--) vrací identifikátor s rozsahem prezentace, ale tento identifikátor je určen pro doplňky a může být přeřazen. Neměl by být považován za trvalý externí klíč. Pokud je dlouhodobá identita podstatná, uložte mapování v aplikačních datech a ověřte, že očekávaný tvar stále existuje.

Následující příklad vyhledává podle názvu s přesnou shodou a reportuje ID interopu v rámci snímku. Když šablona neobsahuje očekávaný tvar, kód vypíše tento výsledek místo toho, aby pokračoval se špatným objektem.

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

Když je operace specifická pro typ tvaru, zkontrolujte rozhraní před použitím typových členů. Tento příklad aktualizuje text a alternativní text pouze pokud je pojmenovaný objekt [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/).

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

Přednastavené geometrické tvary mohou mít body úpravy, které řídí např. velikost rohu, poměr šípů nebo úhly oblouku. Přistupujte k nim přes jen pro čtení [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) kolekci. Kolekce je poskytována tvarem, ale každý [IAdjustValue](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iadjustvalue/) obsahuje hodnotu, kterou lze změnit.

Nespoléhejte se jen na pevný index kolekce. Projděte úpravy a zkontrolujte jen pro čtení metodu [getType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iadjustvalue/#getType--) , jejíž hodnota [ShapeAdjustmentType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shapeadjustmenttype/) popisuje, co úprava ovládá. Metoda jen pro čtení [getName](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iadjustvalue/#getName--) poskytuje doplňující identifikační informace a je zvláště užitečná, když přednastavení obsahuje více úprav se stejným sémantickým typem.

Použijte metodu hodnoty, která odpovídá významu úpravy:

| Typ úpravy | Účel | Hodnota ke změně |
|---|---|---|
| `CornerSize` | Velikost zaoblených rohů | [setRawValue](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Tloušťka ocasu šípu | `setRawValue` |
| `ArrowheadLength` | Délka hrotu šípu | `setRawValue` |
| `ArrowheadWidth` | Šířka hrotu šípu | `setRawValue` |
| `StartAngle` | Počáteční úhel výseče nebo oblouku | [setAngleValue](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Konečný úhel výseče nebo oblouku | `setAngleValue` |

`getType` a `getName` vrací jen pro čtení informace. `getRawValue` a `setRawValue` pracují s celým číslem v nativních jednotkách geometrie přednastavení, zatímco `getAngleValue` a `setAngleValue` pracují s úhlem ve stupních. Počet, pořadí, význam a platný rozsah úprav závisí na přednastaveném [ShapeType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/igeometryshape/#getShapeType--). Hodnota platná pro jedno přednastavení může být neplatná nebo mít jiný efekt pro jiné.

Když `getType` vrátí `ShapeAdjustmentType.Custom`, API nerozpozná standardní sémantický význam. Prozkoumejte `getName`, typ přednastavení a existující hodnotu a nechte úpravu beze změny, pokud neznáte očekávaný význam a rozsah. I pro rozpoznané typy zkontrolujte, zda se stejný typ nevyskytuje vícekrát, než vyberete hodnotu. Článek [Connector](/slides/cs/androidjava/connector/) ukazuje tuto situaci u úprav ohýbání konektorů.

Následující kompletní příklad vytváří výchozí a upravené verze tří přednastavených tvarů. Prochází každou úpravu, vypisuje její název a typ, mění hodnoty související s velikostí pomocí `setRawValue`, mění úhly pomocí `setAngleValue` a ukládá výsledek. Levý sloupec zachovává výchozí geometrii; pravý sloupec ukazuje upravený zaoblený obdélník, čtyřcestný šíp a výseč.

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

Kontrola sémantického typu před změnou hodnoty dělá kód explicitním ohledně záměru a zabraňuje předpokladu, že konkrétní index kolekce má stejný význam napříč různými přednastavenými tvary.

## **Úprava kolekce tvarů**

Metody přidání, klonování, odstranění a změny pořadí fungují na kolekci okamžitě. Pokud operace změní počet nebo pořadí tvarů, nepokračujte v používání indexů zachycených před touto operací.

### **Klonování tvaru**

[addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) vytvoří nezávislou kopii a připojí ji k cílové kolekci. [insertClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) také vytvoří kopii, ale umístí ji na zadaný index z‑řádu. Přetížení, která přijímají souřadnice, přesunou klon bez změny velikosti; přetížení s šířkou a výškou jej mohou také změnit velikost.

Příklad vytváří cílový snímek, klonuje označený obdélník do popředí a vloží druhý klon do pozadí. Změny v kterémkoli klonu neovlivňují zdrojový tvar.

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

Klonování kopíruje obsah a formátování tvaru, včetně jeho názvu a alternativního textu. Při klonování přiřaďte nové logické identifikátory, pokud musí být tyto hodnoty jedinečné. Prostředky používané složitými tvary spravuje prezentace, ale klon zůstává novou položkou v kolekci s novou identitou tvaru.

### **Odstranění tvarů**

[remove](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) smaže konkrétní objekt tvaru z jeho kolekce. Při odstraňování více shod během indexované iterace procházejte od konce, aby každý zbývající index zůstal platný.

Tento příklad odstraňuje každý tvar s určeným názvem. Čte tvar na aktuálním indexu, ne pevnou položku kolekce, a nepřetypovává tvar zbytečně.

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

Po odstranění se počet tvarů a indexy dalších tvarů změní. Odkazy na nepodřízené tvary zůstávají spolehlivější než uložené indexy. Zvažte také konektory, animace a další prvky prezentace, které mohou odkazovat na odstraněný objekt; odstranění viditelného tvaru může změnit více než jen vzhled snímku.

### **Skrytí tvaru**

Nastavením [Hidden](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) na `true` ponecháte tvar v kolekci, ale zabráníte jeho zobrazování v normální prezentaci. Jeho index, formátování a obsah zůstávají k dispozici kódu, takže skrytí je vhodné pro volitelné prvky, které mohou být později obnoveny.

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

Skrytí není smazání ani zabezpečení. Objekt může stále být objeven a znovu odhalen uživatelem nebo kódem a zůstává součástí souboru prezentace.

### **Změna Z‑řádu**

Překrývající se tvary jsou kresleny v pořadí kolekce. [reorder](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) přesune existující tvar na cílový index bez jeho klonování. Index `0` je zadní; `size() - 1` je přední.

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

Obdélník je vytvořen nejprve a zpočátku leží za elipsou. Přesunutí na poslední index jej umístí do popředí. Dokončete nastavení Z‑řádu po přidání nebo klonování všech souvisejících tvarů, protože tyto operace přidávají nebo vkládají nové položky do kolekce a mohou změnit zamýšlený zásobník.

## **Prohlížení tvarů na rozvržení snímků**

Normální snímky, rozvržení snímků a hlavní snímky mají samostatné kolekce tvarů. Tvar v kolekci rozvržení není stejný objekt jako podobně umístěný tvar na normálním snímku. Prohlédněte si tvary rozvržení, když potřebujete pochopit nebo změnit formátování dodané rozvržením.

Následující příklad čte každé [FillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getFillFormat--) a [LineFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getLineFormat--) rozvržových tvarů, aniž by předpokládal, že každý tvar je `AutoShape`.

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

Úprava rozvržení může ovlivnit více snímků, které jej používají. Před změnou tvaru rozvržení zjistěte, zda normální snímek dědí objekt nebo obsahuje lokální přepsání, a otestujte každý snímek, který toto rozvržení používá.

## **Export tvaru do SVG**

[writeAsSvg](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) zapíše vykreslený obsah jednoho tvaru do proudu. Výsledek obsahuje jen tvar, ne celé pozadí snímku ani sousední tvary.

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

Udržujte prezentaci otevřenou během renderování. Výstup závisí na formátování tvaru a na prostředcích, jako jsou písma a obrázky. Pokud potřebujete celou kompozici, exportujte snímek místo jednotlivého tvaru. Volající vlastní proud a musí jej zavřít.

## **Zarovnání tvarů**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) má přetížení, která zarovnávají buď všechny tvary, nebo vybrané indexy v kolekci. [ShapesAlignmentType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shapesalignmenttype/) specifikuje hranu, středovou čáru nebo režim distribuce. Nastavte `alignToSlide` na `true`, chcete-li použít hrany snímku; nastavte na `false`, chcete-li zarovnat vybrané tvary vůči sobě navzájem.

Tento příklad zarovnává tři tvary k horní hraně snímku. Vrácené reference tvarů jsou okamžitě převedeny na jejich aktuální indexy před zarovnáním.

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

Zarovnání mění pozice, ne Z‑řád. Relativní zarovnání obvykle vyžaduje alespoň dva tvary, zatímco horizontální nebo vertikální distribuce potřebuje dostatek tvarů k definování rozestupů. Přepočítejte indexy, pokud před voláním metody upravujete kolekci.

## **Převrácení tvaru**

Třída [ShapeFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shapeframe/) ukládá pozici, velikost, nastavení horizontálního a vertikálního převrácení a rotaci. Její hodnoty `getFlipH` a `getFlipV` používají [NullableBool](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/nullablebool/): `True` zapíná převrácení, `False` jej vypíná a `NotDefined` zachovává neurčený/defaultní stav.

Vstupní prezentace níže obsahuje jeden neotočený tvar.

![Tvar před otočením](shape_to_be_flipped.png)

Příklad zachovává všechny ostatní hodnoty rámce a nahrazuje jen dvě nastavení převrácení. To je důležité, protože přiřazení nového [Frame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) nahrazuje celý rámec.

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

Uložený tvar je zrcadlen horizontálně i vertikálně při zachování své pozice, velikosti a rotace.

![Tvar po otočení](flipped_shape.png)

## **Často kladené dotazy**

**Mám používat index kolekce jako identifikátor tvaru?**

Jen pro krátkodobé zpracování, kdy se kolekce před použitím indexu nezmění. Upřednostněte ověřenou konvenci `Name` nebo `AlternativeText` pro šablony vytvářené autory, nebo `OfficeInteropShapeId` pro práci s interopem na úrovni snímku.

**Odstraňuje skrytí tvaru jeho z‑řád?**

Ne. Skrytý tvar zůstává v kolekci na stejném indexu. Lze jej najít, změnit pořadí, upravit nebo opět zobrazit.

**Proč se klonovaný tvar objevil před jiným tvarem?**

`addClone` přidá klon na konec kolekce, což je přední část z‑řádu. Použijte `insertClone` pro volbu počátečního indexu nebo `reorder` po přidání všech tvarů.

**Mohu použít pevný index pro identifikaci přednastavené úpravy tvaru?**

Jen po ověření přesného přednastavení a rozložení kolekce. Upřednostněte iteraci přes `IGeometryShape.getAdjustments` a kontrolu `IAdjustValue.getType`; použijte `IAdjustValue.getName` jako doplňující informaci, když se stejný sémantický typ objeví vícekrát.