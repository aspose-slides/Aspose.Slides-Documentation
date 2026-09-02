---
title: Správa tvarů prezentace na Androidu
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
description: "Naučte se, jak identifikovat, klonovat, odstraňovat, skrývat, měnit pořadí, exportovat, zarovnávat a převracet tvary prezentace pomocí Aspose.Slides pro Android přes Java."
---
## **Přehled**

Aspose.Slides for Android via Java představuje tvary na snímku jako uspořádanou [IShapeCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/). Kolekce je jak místem, kde najdete a upravujete tvary, tak i zdrojem jejich pořadí vrstvení: index `0` je nejzadnější tvar, zatímco poslední index je nejpopřednější tvar.

Tento článek následuje tento model. Nejprve vysvětluje, jak spolehlivě identifikovat tvar, pak ukazuje, jak klonovat, odstranit, skrýt a změnit pořadí tvarů. Závěrečné sekce se zabývají formátováním na úrovni rozvržení, exportem do SVG, zarovnáním a nastavením převrácení. Každý příklad je samostatný, takže můžete použít jen operace, které vaše workflow vyžaduje.

## **Identifikace a vyhledání tvarů**

Indexy v kolekci jsou praktické při zpracování známého souboru, ale nejsou stabilními identifikátory. Přidání, odebrání nebo změna pořadí tvaru může změnit jeho index. Zvolte identifikátor podle toho, jak je prezentace vytvářena a udržována:

- [Name](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getName--) je užitečný pro šablony řízené vývojáři a je snadno kontrolovatelný v panelu výběru PowerPointu. Názvy lze upravovat a nejsou zaručeně jedinečné, proto si stanovte konvenci pojmenování, pokud na nich kód závisí.
- [AlternativeText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getAlternativeText--) je užitečný, když popis přístupnosti nebo autorův štítek již tvar identifikuje. Je viditelný pro uživatele, může být lokalizován nebo přepsán pro přístupnost a není zaručeně jedinečný. Nepřevádějte tiše smysluplný text přístupnosti na klíč databáze.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) je jen pro čtení a je jedinečný v rámci snímku, odpovídá ID tvaru používanému v PowerPoint interopu. Použijte jej při integraci s PowerPointem nebo když potřebujete jednoznačný odkaz během životnosti tvaru. Klonovaný nebo znovu vytvořený tvar je jiný tvar a získá své vlastní ID.

Související metoda [getUniqueId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getUniqueId--) vrací identifikátor s rozsahem celé prezentace, ale tento identifikátor je určen pro add‑iny a může být přeřazen. Neměl by být považován za trvalý externí klíč. Pokud je dlouhodobá identita zásadní, uchovejte mapování v aplikačních datech a ověřte, že očekávaný tvar stále existuje.

Následující příklad hledá podle názvu s přesnou shodou a uvádí interop ID v rozsahu snímku. Když šablona neobsahuje očekávaný tvar, kód nahlásí tento výsledek místo pokračování s nesprávným objektem.

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

Když je operace specifická pro typ tvaru, zkontrolujte rozhraní před použitím typově specifických členů. Tento příklad aktualizuje text a alternativní text pouze pokud je pojmenovaný objekt [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/).

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

## **Úprava kolekce tvarů**

Metody přidání, klonování, odebrání a změny pořadí operují přímo na kolekci. Pokud operace změní počet nebo pořadí tvarů, nedále se spoléhejte na indexy zachycené před touto operací.

### **Klonování tvaru**

[addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) vytvoří nezávislou kopii a přidá ji na konec cílové kolekce. [insertClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) také vytvoří kopii, ale umístí ji na určený index z‑orderu. Přetížení, která přijímají souřadnice, posunou klon bez změny velikosti; přetížení s šířkou a výškou jej mohou také změnit velikost.

Příklad vytvoří cílový snímek, klonuje označený obdélník dopředu a vloží druhý klon dozadu. Změny v libovolném klonu neovlivní zdrojový tvar.

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

Klonování kopíruje obsah a formátování tvaru, včetně jeho názvu a alternativního textu. Pokud musí být tyto hodnoty jedinečné, přiřaďte klonu nové logické identifikátory. Prostředky používané složitými tvary spravuje prezentace, ale klon zůstává novou položkou kolekce s novou identitou tvaru.

### **Odstranění tvarů**

[remove](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) smaže konkrétní objekt tvaru z jeho kolekce. Při odstraňování více shod během iterace s indexy procházejte od konce, aby každý zbývající index zůstal platný.

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

Po odstranění se počet tvarů a indexy pozdějších tvarů mění. Odkazy na neovlivněné tvary zůstávají spolehlivější než uložené indexy. Věnujte také pozornost konektorům, animacím a dalším funkcím prezentace, které mohou odkazovat na odstraněný objekt; odebrání viditelného tvaru může změnit více než jen vzhled snímku.

### **Skrytí tvaru**

Nastavením [Hidden](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) na `true` zůstane tvar v kolekci, ale nebude se zobrazovat v normálním průběhu prezentace. Jeho index, formátování a obsah zůstávají dostupné kódu, takže skrytí je vhodné pro volitelné prvky, které mohou být později obnoveny.

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

Skrytí není smazání ani zabezpečení. Objekt může být stále objeven a odskryt uživatelem nebo kódem a zůstává součástí souboru prezentace.

### **Změna Z‑Orderu**

Překrývající se tvary se vykreslují v pořadí kolekce. [reorder](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) přesune existující tvar na cílový index bez klonování. Index `0` je zadní; `size() - 1` je přední.

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

Obdélník je vytvořený jako první a zpočátku leží za elipsou. Přesunutí na poslední index jej postaví dopředu. Dokončete nastavení Z‑Orderu po přidání nebo klonování všech souvisejících tvarů, protože tyto operace přidávají nebo vkládají nové položky kolekce a mohou změnit zamýšlený zásobník.

## **Prohlížení tvarů na rozvržení snímků**

Normální snímky, snímky rozvržení a hlavní snímky mají samostatné kolekce tvarů. Tvar v kolekci rozvržení není stejný objekt jako podobně umístěný tvar na normálním snímku. Prohlédněte tvar v rozvržení, když potřebujete pochopit nebo změnit formátování poskytnuté rozvržením.

Následující příklad čte pro každý tvar rozvržení jeho [FillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getFillFormat--) a [LineFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getLineFormat--) aniž by předpokládal, že každý tvar je `AutoShape`.

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

Úprava rozvržení může ovlivnit více snímků, které jej používají. Před změnou tvaru v rozvržení zjistěte, zda normální snímek dědí objekt nebo obsahuje místní přepsání, a otestujte každý snímek, který rozvržení používá.

## **Export tvaru do SVG**

[writeAsSvg](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) zapíše vykreslený obsah jednoho tvaru do proudu. Výsledek obsahuje tvar, nikoli celé pozadí snímku nebo sousední tvary.

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

[SlideUtil.alignShapes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) má přetížení, která zarovnávají buď všechny tvary, nebo vybrané indexy kolekce. [ShapesAlignmentType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shapesalignmenttype/) určuje okraj, středovou čáru nebo režim distribuce. Nastavte `alignToSlide` na `true`, chcete-li použít okraje snímku; nastavte na `false`, chcete-li zarovnat vybrané tvary vůči sobě navzájem.

Tento příklad zarovnává tři tvary k hornímu okraji snímku. Návratové odkazy na tvary jsou převedeny na jejich aktuální indexy těsně před zarovnáním.

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

Zarovnání mění pozice, nikoli Z‑Order. Relativní zarovnání obvykle vyžaduje alespoň dva tvary, zatímco horizontální nebo vertikální distribuce potřebuje dostatek tvarů k definování mezery. Přepočítejte indexy, pokud před voláním metody upravujete kolekci.

## **Převrácení tvaru**

Třída [ShapeFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shapeframe/) ukládá pozici, velikost, horizontální a vertikální nastavení převrácení a rotaci. Její hodnoty `getFlipH` a `getFlipV` používají [NullableBool](https://reference.aspos
e.com/slides/cs/androidjava/com.aspose.slides/nullablebool/): `True` zapíná převrácení, `False` jej vypíná a `NotDefined` zachovává nedefinovaný/defaultní stav.

Vstupní prezentace níže obsahuje jeden netransformovaný tvar.

![The shape before flipping](shape_to_be_flipped.png)

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

Uložený tvar je zrcadlen horizontálně i vertikálně při zachování pozice, velikosti a rotace.

![The shape after flipping](flipped_shape.png)

## **Často kladené otázky**

**Mám používat index kolekce jako identifikátor tvaru?**

Pouze pro krátkodobé zpracování, kdy se kolekce před použitím indexu již nezmění. Upřednostněte ověřený konvenci `Name` nebo `AlternativeText` pro vytvořené šablony, nebo `OfficeInteropShapeId` pro práci s interopem v rozsahu snímku.

**Odstraňuje skrytí tvaru jeho pozici ve Z‑Orderu?**

Ne. Skrytý tvar zůstává v kolekci na stejném indexu. Lze jej najít, změnit pořadí, upravit nebo znovu zobrazit.

**Proč se klonovaný tvar objevil před jiným tvarem?**

`addClone` přidá klon na konec kolekce, což je přední část Z‑Orderu. Použijte `insertClone` pro výběr počátečního indexu nebo `reorder` po přidání všech tvarů.