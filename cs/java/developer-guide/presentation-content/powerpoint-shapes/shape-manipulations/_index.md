---
title: Spravovat tvary prezentace v Javě
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
description: "Naučte se, jak identifikovat, upravovat, klonovat, odstraňovat, skrývat, měnit pořadí, exportovat, zarovnávat a převracet tvary v prezentaci pomocí Aspose.Slides for Java."
---
## **Přehled**

Aspose.Slides for Java představuje tvary na snímku jako uspořádanou [IShapeCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/). Kolekce je jak místem, kde najdete a upravujete tvary, tak i zdrojem jejich pořadí vrstvení: index `0` je nejzazadnější tvar, poslední index je nejpřednější tvar.

Tento článek následuje tento model. Nejprve vysvětluje, jak spolehlivě identifikovat tvar a upravit přednastavené body úpravy tvaru, poté ukazuje, jak klonovat, odstranit, skrýt a změnit pořadí tvarů. Závěrečné sekce se věnují formátování na úrovni rozvržení, exportu do SVG, zarovnání a nastavení převrácení. Každý příklad je samostatný, takže můžete použít jen operace, které váš pracovní postup vyžaduje.

## **Identifikace a vyhledání tvarů**

Indexy kolekce jsou praktické při zpracování známého souboru, ale nejsou stabilními identifikátory. Přidání, odebrání nebo změna pořadí tvaru může změnit jeho index. Zvolte identifikátor podle toho, jak je prezentace vytvářena a udržována:

- [Name](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getName--) je užitečný pro šablony řízené vývojářem a snadno se kontroluje v panelu výběru PowerPointu. Jména lze upravovat a nejsou zaručena jako jedinečná, takže pokud kód na nich závisí, zaveďte pojmenovací konvenci.
- [AlternativeText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getAlternativeText--) je užitečný, když popis přístupnosti nebo autorovo štítek již tvar identifikuje. Je viditelný pro uživatele, může být lokalizován nebo přepsán pro přístupnost a také není zaručeně jedinečný. Nepřevádějte tichá smysluplná texty přístupnosti na klíč databáze.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) je jen pro čtení a je jedinečný v rámci snímku a odpovídá ID tvaru používanému v PowerPoint interopu. Použijte jej při integraci s PowerPointem nebo když během životnosti tvaru potřebujete jednoznačný odkaz. Klonovaný nebo znovu vytvořený tvar je jiný tvar a získá své vlastní ID.

Související metoda [getUniqueId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getUniqueId--) vrací identifikátor v rámci prezentace, ale tento identifikátor je určen pro doplňky a může být přeřazen. Neměl by být považován za trvalý externí klíč. Pokud je dlouhodobá identita podstatná, uchovávejte mapování v aplikačních datech a ověřte, že očekávaný tvar stále existuje.

Následující příklad hledá podle jména s přesným porovnáním a vypisuje interop ID v rozsahu snímku. Když šablona neobsahuje očekávaný tvar, kód vypíše tento výsledek místo pokračování se špatným objektem.

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

Když je operace specifická pro typ tvaru, před použitím typových členů zkontrolujte rozhraní. Tento příklad aktualizuje text a alternativní text pouze pokud je pojmenovaný objekt [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/).

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

## **Identifikace a úprava přednastavených úprav tvarů**

Tvary s přednastavenou geometrií mohou mít body úpravy, které řídí např. velikost rohu, proporce šipek nebo úhly oblouku. Přistupujte k nim přes jen pro čtení [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/cs/java/com.aspose.slides/igeometryshape/#getAdjustments--) kolekci. Kolekce samotná je poskytována tvarem, ale každý [IAdjustValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iadjustvalue/) obsahuje hodnotu, kterou lze změnit.

Nespoléhejte se jen na pevný index kolekce. Projděte úpravy a prozkoumejte jen pro čtení metodu [getType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iadjustvalue/#getType--) , jejíž hodnota [ShapeAdjustmentType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shapeadjustmenttype/) popisuje, co úprava ovládá. Jen pro čtení metoda [getName](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iadjustvalue/#getName--) poskytuje doplňující identifikační informace a je zvláště užitečná, když přednastavení obsahuje více úprav se stejným sémantickým typem.

Použijte metodu, která odpovídá významu úpravy:

| Typ úpravy | Účel | Hodnota k změně |
|---|---|---|
| `CornerSize` | Velikost zaoblených rohů | [setRawValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Tloušťka ocasu šipky | `setRawValue` |
| `ArrowheadLength` | Délka hlavice šipky | `setRawValue` |
| `ArrowheadWidth` | Šířka hlavice šipky | `setRawValue` |
| `StartAngle` | Počáteční úhel koláče nebo oblouku | [setAngleValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Konečný úhel koláče nebo oblouku | `setAngleValue` |

`getType` a `getName` vrací jen pro čtení informace. `getRawValue` a `setRawValue` pracují s celým číslem v nativních jednotkách geometrie přednastavení, zatímco `getAngleValue` a `setAngleValue` pracují s úhlem ve stupních. Počet, pořadí, význam a platný rozsah úprav závisí na přednastaveném [ShapeType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/igeometryshape/#getShapeType--). Hodnota platná pro jedno přednastavení může být neplatná nebo mít jiný efekt pro jiné.

Když `getType` vrátí `ShapeAdjustmentType.Custom`, API nerozpozná standardní sémantický význam. Prozkoumejte `getName`, typ přednastavení a existující hodnotu a nechte úpravu beze změny, pokud neznáte očekávaný význam a rozsah. I pro rozpoznané typy zkontrolujte, zda se stejný typ vyskytuje vícekrát, než vyberete hodnotu. Článek [Connector](/slides/cs/java/connector/) ukazuje tuto situaci u úprav ohybu spojek.

Následující kompletní příklad vytváří výchozí a upravené verze tří přednastavených tvarů. Prochází každou úpravu, vypisuje její název a typ, mění hodnoty související s velikostí pomocí `setRawValue`, mění úhly pomocí `setAngleValue` a ukládá výsledek. Levý sloupec zachovává výchozí geometrii; pravý sloupec ukazuje upravený zaoblený obdélník, čtyřcestnou šipku a koláč.

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

Kontrola sémantického typu před změnou hodnoty dělá kód explicitním ohledně jeho záměru a zabraňuje předpokladu, že určitý index kolekce má stejný význam u různých přednastavených tvarů.

## **Úprava kolekce tvarů**

Metody přidání, klonování, odebrání a změny pořadí působí na kolekci okamžitě. Pokud operace změní počet nebo pořadí tvarů, nepokračujte v používání indexů zachycených před touto operací.

### **Klonovat tvar**

[addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) vytvoří nezávislou kopii a připojí ji k cílové kolekci. [insertClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) také vytvoří kopii, ale umístí ji na zadaný index Z‑orderu. Přetížení, která přijímají souřadnice, přesunou klon bez změny velikosti; přetížení s šířkou a výškou jej mohou také změnit.

Příklad vytváří cílový snímek, klonuje označený obdélník dopředu a vloží druhý klon dozadu. Změny v kterémkoli klonu neovlivní zdrojový tvar.

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

Klonování kopíruje obsah a formátování tvaru, včetně jeho jména a alternativního textu. Při potřebě jedinečných hodnot přiřaďte klonu nové logické identifikátory. Zdroje použité komplikovanými tvary zpracovává prezentace, ale klon zůstává novou položkou v kolekci s novou identitou tvaru.

### **Odebrat tvary**

[remove](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) odstraní konkrétní objekt tvaru ze své kolekce. Při odstraňování více shod během indexované iterace procházejte od konce, aby každý zbývající index zůstal platný.

Tento příklad odstraňuje každý tvar s určeným jménem. Načítá tvar na aktuálním indexu, ne pevnou položku kolekce, a nepotřebně nedefinuje typ.

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

Po odebrání se počet tvarů a indexy pozdějších tvarů mění. Odkazy na nedotčené tvary zůstávají spolehlivější než uložené indexy. Zvažte také spojky, animace a další funkce prezentace, které mohou odkazovat na odebraný objekt; odebrání viditelného tvaru může změnit více než jen vzhled snímku.

### **Skrýt tvar**

Nastavením [Hidden](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#setHidden-boolean-) na `true` zůstane tvar v kolekci, ale neobjeví se v běžné prezentaci. Jeho index, formátování a obsah zůstávají k dispozici kódu, takže skrytí je vhodné pro volitelné prvky, které mohou být později obnoveny.

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

Skrytí není smazání ani zabezpečení. Objekt lze stále najít a odskryt jak uživatelem, tak kódem, a zůstává součástí souboru prezentace.

### **Změnit Z‑order**

Překrývající se tvary jsou vykresleny v pořadí kolekce. [reorder](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) přesune existující tvar na cílový index bez jeho klonování. Index `0` je zadní; `size() - 1` je přední.

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

Obdélník je vytvořen jako první a zpočátku leží za elipsou. Přesunutím na poslední index se dostane dopředu. Zfinalizujte Z‑order po přidání nebo klonování všech souvisejících tvarů, protože tyto operace přidávají nebo vkládají nové položky do kolekce a mohou změnit zamýšlený zásobník.

## **Prohlédnout tvary na rozložení snímků**

Normální snímky, rozložení a hlavní snímky mají oddělené kolekce tvarů. Tvar v kolekci rozložení není stejný objekt jako podobně umístěný tvar na normálním snímku. Prohlédněte tvary rozložení, když potřebujete pochopit nebo změnit formátování dodávané rozložením.

Následující příklad načítá [FillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getFillFormat--) a [LineFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getLineFormat--) každého tvaru rozložení, aniž by předpokládal, že každý tvar je `AutoShape`.

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

Úprava rozložení může ovlivnit více snímků, které jej používají. Před změnou tvaru rozložení zjistěte, zda normální snímek dědí objekt nebo obsahuje lokální přepsání, a otestujte každý snímek používající toto rozložení.

## **Export tvaru do SVG**

[writeAsSvg](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) zapíše vykreslený obsah jednoho tvaru do proudu. Výsledek obsahuje jen tvar, ne celé pozadí snímku ani sousední tvary.

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

Udržujte prezentaci otevřenou během renderování. Výstup závisí na formátování tvaru a na zdrojích, jako jsou písma a obrázky. Pokud potřebujete celou kompozici, exportujte snímek místo jednotlivého tvaru. Volající vlastní proud a musí jej uzavřít.

## **Zarovnat tvary**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) má přetížení, která zarovnají buď všechny tvary, nebo vybrané indexy kolekce. [ShapesAlignmentType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shapesalignmenttype/) určuje okraj, středovou čáru nebo režim rozdělení. Nastavte `alignToSlide` na `true`, chcete-li použít okraje snímku; nastavte na `false`, chcete-li zarovnat vybrané tvary relativně k sobě navzájem.

Tento příklad zarovnává tři tvary k hornímu okraji snímku. Vracející se odkazy na tvary jsou před zarovnáním okamžitě převedeny na jejich aktuální indexy.

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

Zarovnání mění pozice, ne Z‑order. Relativní zarovnání obvykle vyžaduje alespoň dva tvary, zatímco vodorovné nebo svislé rozdělení potřebuje dostatek tvarů pro definování mezery. Přepočítejte indexy, pokud před voláním metody upravujete kolekci.

## **Převrátit tvar**

Třída [ShapeFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shapeframe/) ukládá pozici, velikost, nastavení horizontálního a vertikálního převrácení a rotaci. Její hodnoty `getFlipH` a `getFlipV` používají [NullableBool](https://reference.aspose.com/slides/cs/java/com.aspose.slides/nullablebool/): `True` zapíná převrácení, `False` ho vypíná a `NotDefined` zachovává nespecifikovaný / výchozí stav.

Vstupní prezentace níže obsahuje jeden nepřevrácený tvar.

![The shape before flipping](shape_to_be_flipped.png)

Příklad zachovává všechny ostatní hodnoty rámce a mění jen dvě nastavení převrácení. To je důležité, protože při přiřazení nového [Frame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) se nahradí celý rámec.

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

Uložený tvar je horizontálně i vertikálně zrcadlený, přičemž zůstává na své pozici, velikosti a rotaci.

![The shape after flipping](flipped_shape.png)

## **Často kladené otázky**

**Mám používat index kolekce jako identifikátor tvaru?**

Pouze pro krátkodobé zpracování, kdy se kolekce před použitím indexu nezmění. Upřednostněte ověřený konvence `Name` nebo `AlternativeText` pro vytvořené šablony, nebo `OfficeInteropShapeId` pro práci s interopem na úrovni snímku.

**Odstraní skrytí tvaru jeho pozici v Z‑orderu?**

Ne. Skrytý tvar zůstává v kolekci na stejném indexu. Lze jej najít, změnit pořadí, upravit nebo znovu zobrazit.

**Proč se klonovaný tvar objevil před jiným tvarem?**

`addClone` přidá klon na konec kolekce, což je přední část Z‑orderu. Použijte `insertClone` pro výběr počátečního indexu nebo `reorder` po přidání všech tvarů.

**Mohu použít pevný index k identifikaci přednastavené úpravy tvaru?**

Pouze po ověření konkrétního přednastavení a rozložení kolekce. Upřednostněte iteraci přes `IGeometryShape.getAdjustments` a kontrolu `IAdjustValue.getType`; použijte `IAdjustValue.getName` jako doplňující informaci, když se stejný sémantický typ vyskytuje vícekrát.