---
title: Prezentációs sablonok kezelése Java-ban
linktitle: Prezentációs sablon
type: docs
weight: 10
url: /hu/java/presentation-theme/
keywords:
- PowerPoint sablon
- prezentációs sablon
- dia sablon
- sablon beállítása
- sablon módosítása
- sablon kezelése
- sablon szín
- kiegészítő paletta
- sablon betűtípus
- sablon stílus
- sablon effektus
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Mester prezentációs sablonok az Aspose.Slides for Java-ban, amelyekkel PowerPoint fájlokat hozhatunk létre, testreszabhatunk és konvertálhatunk egységes márkázással."
---
## **Bevezetés**

A prezentációs sablon egy koordinált szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektus-készletet definiál. A sablon‑érzékeny objektumok ezekre a megosztott definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy sablonmódosítás egyszerre sok objektumot frissíthet.

Az Aspose.Slides‑ben a prezentáció szintű sablon a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) segítségével érhető el. A prezentáció alsó szinteken is tartalmazhat sablon felülírásokat. Egy master felülírhatja a prezentáció sablonját a [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/masterthememanager/) használatával, míg egy elrendezés vagy egyetlen dia felülírhatja a örökölt sablonját a [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseoverridethememanager/) segítségével. Gyakorlatban egy dia hatékony sablonja ezen öröklődési láncon keresztül kerül feloldásra: prezentációs sablon, master felülírás, elrendezés felülírás és dia felülírás.

![A sablon összetevői: színek, betűtípusok, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok bemutatják a leggyakoribb sablon munkafolyamatokat: sablon ellenőrzése, színek és betűtípusok módosítása, sablon másolása vagy alkalmazása, háttér‑ és effektus‑stílusok frissítése, valamint a hatékony értékek olvasása az öröklődés és a felülírások feloldása után.

## **Sablon ellenőrzése**

A [MasterTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mastertheme/) objektum a sablon színsémáját, betűtípus‑sémáját és formátumsémáját teszi elérhetővé a [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mastertheme/), és [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mastertheme/) segítségével. Ezeknek a gyűjteményeknek a vizsgálata a módosítások előtt különösen hasznos, ha a prezentáció egy külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

Az alábbi példa beolvassa a fő sablon tulajdonságait, és jelentést készít arról, hogy hány háttér-, kitöltés-, vonal- és effektus‑stílus van tárolva a sablonban:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Ha egy fájl több master‑t használ, ne feltételezzük, hogy minden diának ugyanaz a hatékony sablonja van. Ellenőrizzük a diához tartozó master‑t, és a cikk később bemutatott hatékony‑sablon munkafolyamatot használjuk, ha elrendezés vagy dia felülírások lehetnek.

## **Sablon színeinek módosítása**

A sablon‑érzékeny kitöltések, vonalak és szövegek hivatkozhatnak egy logikai színre a [SchemeColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/schemecolor/) felsorolásból. Ha módosítja a megfelelő bejegyzést az [IColorScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icolorscheme/)-ben, akkor minden objektum, amely továbbra is a sablon színére hivatkozik, az új értékre lesz feloldva. Azok az objektumok, amelyek közvetlen RGB‑színt használnak, nem változnak meg egy sablon‑szín frissítésekor.

Az alábbi végponttól‑végpontig tartó példa létrehoz egy alakzatot, amely az `Accent4` színt használja, megváltoztatja a sablon `Accent4` színét pirosra, elmenti a prezentációt, újra megnyitja, és kiírja a hatékony kitöltőszínt:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);
    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Mivel a téglalap továbbra is a `Accent4`‑hez van kapcsolva, a látható színe pirosra változik a sablon módosítása után. Ha a színsémát közvetlen színre cseréli az alakzaton, a későbbi `Accent4` változások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettáról**

A PowerPoint a sablon színéből világosabb és sötétebb változatokat színátalakítások alkalmazásával származtat. Az Aspose.Slides ezeket az átalakításokat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/colortransformoperation/) felsorolás segítségével teszi elérhetővé.

![A fő sablon színek és a kiegészítő palettáról generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – Fő sablon színek.  
**2** – Világosabb és sötétebb változatok, melyek a fő sablon színekből származnak.

Az alábbi példa hat téglalapot hoz létre az `Accent4` alapján, ötön luminancia‑átalakításokat alkalmaz, és elmenti az eredményt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ezek a változatok továbbra is a sablon színén alapulnak. Ha a `Accent4` később változik, a transzformált színek az új `Accent4` értékből kerülnek újraszámításra.

### **`SchemeColor` értékek leképezése az `IColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg az [IColorScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icolorscheme/) ugyanazokat a sablonhelyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi elérhetővé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon sablonhelyek alternatív nevei; nem dinamikusan konvertált értékek egyik formából a másikba.

## **Sablon betűtípusainak módosítása**

A sablon betűtípus‑sémája egy fő betűkészletet tartalmaz a címsorokhoz és egy mellék betűkészletet a törzsszöveghez. A [IFontScheme.getMajor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontscheme/) és [IFontScheme.getMinor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontscheme/) metódusok teszik ezeket a készleteket elérhetővé.

PowerPoint‑kompatibilis sablon betűtípus‑azonosítók használhatók a szövegformázásban:

* `+mn-lt` – Törzsszöveg Latin (Minor Latin Font)
* `+mj-lt` – Címsor Latin (Major Latin Font)
* `+mn-ea` – Törzsszöveg Kelet-Ázsiai (Minor East Asian Font)
* `+mj-ea` – Címsor Kelet-Ázsiai (Major East Asian Font)

Az alábbi példa egy címsort hoz létre, amely a fő Latin sablon betűtípust használja, és egy törzssorot, amely a mellék Latin sablon betűtípust használja. Ezután módosítja a sablon betűtípusait, és elmenti az eredményt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A címsor a fő betűtípust, a törzsszöveg a mellék betűtípust használja. Az a szöveg, amelynek explicit betűtípusneve van a sablonazonosító helyett, nem vált automatikusan, amikor a sablon betűtípus‑sémája változik.

A fő és mellék betűkészletek tartalmazhatnak betűtípus‑leképezéseket is egyedi írásrendszerekhez, például cirill, arab, japán, grúz és thaana. Ezeknek a leképezéseknek a vizsgálatához, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script-Specific Theme Fonts](/slides/hu/java/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tip" %}}
Hozzáférés a prezentációs betűtípusokhoz további információkért lásd a [PowerPoint Fonts](/slides/hu/java/powerpoint-fonts/) oldalt.
{{% /alert %}}

## **Sablon másolása vagy alkalmazása**

Két gyakori munkafolyamat létezik, amelyek különböző problémákat oldanak meg.

### **Forrás sablon megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretne áthelyezni, és meg akarja őrizni az eredeti dizájnját, klónozza a forrás master‑t a célprezentációba a [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslidecollection/) segítségével, majd klónozza a diát a [ISlideCollection.addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidecollection/) és a klónozott master segítségével. Ez együtt szállítja a master‑t, az elrendezéseit és a kapcsolódó sablont.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);
        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Ez a preferált munkafolyamat, ha a forrás dia megjelenésének azonosnak kell lennie a célban. Egyszerűen a tartalom klónozása egy nem kapcsolódó célmasterre megváltoztathatja a sablon által vezérelt színeket, betűtípusokat, háttereket és effektusokat.

### **Sablon értékek alkalmazása meglévő diára**

Ha a cél dia a jelenlegi master‑én és elrendezésén kell maradjon, inicializáljon egy dia‑szintű felülírást a forrás sablonból. Az [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/overridetheme/), és [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/overridetheme/) metódusok a három fő sablonkomponenst másolják a felülírásba.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Ez megváltoztatja a dia által használt sablont, anélkül, hogy a többi dia által örökölt sablont módosítaná. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívja a [OverrideTheme.clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/overridetheme/) metódust.

### **Sablon felülírás alkalmazása elrendezésre**

Egy elrendezés‑szintű felülírás azokat a diákra vonatkozik, amelyek ezt az elrendezést használják, kivéve ha egy adott diának saját felülírása van. Ugyanezen inicializáló metódusok használhatók a [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/layoutslidethememanager/) segítségével:

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Használjon master‑ vagy prezentáció‑szintű sablont, ha sok elrendezésnek és diáknak ugyanazt az alapsablont kell megosztania; egy elrendezés felülírást, ha egy elrendezéscsaládnak eltérő stílusra van szüksége; és csak dia felülírást alkalmazzon valódi kivételek esetén. A túlzott dia‑szintű felülírások megnehezítik a későbbi globális sablonváltozások előrejelzését.

## **Sablon háttérstílusainak frissítése**

A sablon háttérkitöltései a [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iformatscheme/) metódusban vannak tárolva. A PowerPoint a felhasználói felületén több háttérválasztást jeleníthet meg, mint a gyűjteményben fizikailag tárolt kitöltésdefiníciók száma, mivel a UI kombinálhatja a sablon kitöltéseket sablonszínekkel és egyéb stílushivatkozásokkal.

![PowerPoint háttérstílus galéria egy prezentációs sablonhoz](presentation-design_8.png)

Mielőtt háttérstílust használna, ellenőrizze a tárolt gyűjteményt és az aktuális [Background.getStyleIndex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/background/). A `0` style index azt jelenti, hogy nincs sablon‑kitöltés; a pozitív értékek a sablon háttér‑stílushivatkozásai. Ez eltér a Java gyűjtemény közvetlen indexelésétől, ahol a `get_Item(0)` az első tárolt elemet jelenti. Ne feltételezze, hogy minden prezentáció ugyanannyi háttérkitöltési stílussal rendelkezik.

Az alábbi példa jelentést készít a rendelkezésre álló háttérkitöltési számról, a első master‑nek sablon hátteret rendel, és elmenti a prezentációt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A látható eredmény a master által hivatkozott sablon bejegyzésétől és az elrendezés vagy dia szintjén lévő háttérfelülírásoktól függ. Ha egy dia saját hátteret használ, akkor csak a master hátterének módosítása nem biztos, hogy megváltoztatja azt a diát. Használja a [Background.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/background/) metódust, ha tudni szeretné a végleges hátteret az öröklődés alkalmazása után.

{{% alert color="warning" title="Warning" %}}
Ne kezelje a style indexet null‑alapú gyűjtemény‑indexként. Kerülje a stílus számának egy fájlból való hard‑kódolását és azt feltételezni, hogy ugyanúgy néz ki egy másik fájlban; a sablon stílusdefiníciók prezentációnként eltérőek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Közvetlen háttérformázás és háttéröröklődés esetén lásd a [Presentation Background](/slides/hu/java/presentation-background/) oldalt.
{{% /alert %}}

## **Sablon effektusainak frissítése**

Egy sablon formátumséma különálló kitöltés‑, vonal‑ és effektus‑stílus gyűjteményeket tartalmaz, amelyeket a [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iformatscheme/), és [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iformatscheme/) metódusok tesznek elérhetővé. A tipikus Office sablonok gyakran három fő stílusbejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell a rögzített szám feltételezése helyett.

![Finom, közepes és intenzív sablon effektusok egyforma alakzatra alkalmazva](presentation-design_10.png)

Java‑ban ezen gyűjtemények elérésekor a gyűjtemény indexe null‑alapú: a `get_Item(0)` az első tárolt stílus, a `get_Item(2)` a harmadik. Egy alakzat style‑referencia indexei egy külön fogalom, amelyet az [IShapeStyle](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapestyle/) tesz elérhetővé. Egy sablonstílus módosítása azok az alakzatok érintett, amelyek hivatkoznak arra a sablonstílusra; a közvetlen formázással rendelkező alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek, módosítja az első vonalstílust, a harmadik kitöltésstílust, engedélyezi a külső árnyékot a harmadik effektusstílusban, és elmenti az eredményt:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Azoknál az alakzatoknál, amelyek ezekre a helyekre hivatkoznak, az első sablon vonalstílus pirosra változik, a harmadik sablon kitöltésstílus szilárd erdőzöld lesz, és a harmadik effektusstílus 10 pont távolságú külső árnyékot kap. A pontos vizuális eredmény továbbra is attól függ, hogy mely stílushelyeket hivatkozza az egyes alakzat, és hogy a közvetlen formázás felülírja-e a sablont.

![Sablon effektusstílusok a vonal-, kitöltés- és árnyékbeállítások módosítása után](presentation-design_11.png)

## **Hatékony sablon értékek olvasása**

A nyers sablonobjektumok megmondják, hogy mi van meghatározva egy adott szinten. A hatékony értékek azt mutatják meg, hogy egy dia vagy alakzat valójában mit használ az öröklődés és a helyi felülírások feloldása után. Diára a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseoverridethememanager/) metódust hívja. Háttérhez a [Background.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/background/) metódust, kitöltéshez pedig a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/) metódust használja.

Az alábbi példa beolvassa a hatékony sablont, a hátteret és az első alakzat kitöltését egy diáról:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();
    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

A hatékony adatokat használja renderelési diagnosztikához, validáláshoz és összehasonlításokhoz. Ha csak a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/)‑t vizsgálja, előfordulhat, hogy egy master, elrendezés, dia vagy alakzat felülírását figyelmen kívül hagyja, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Alkalmazhatok sablont egyetlen diára anélkül, hogy megváltoztatnám a master‑t?**  
Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slidethememanager/) objektumát, és inicializálja annak felülírási sablonját. A változás csak az adott diára vonatkozik; a többi dia továbbra is a meglévő sablonjaikat örökli.

**Mi a legbiztonságosabb módja egy sablon egyik prezentációból a másikba történő átvitelének?**  
Ha egy diát áthelyez és meg akarja őrizni a forrás megjelenését, klónozza a forrás master‑t a célnak, majd a diát a klónozott masterrel a [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslidecollection/) és a [ISlideCollection.addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidecollection/) segítségével. Ez együtt tartja a master‑t, az elrendezéseket és a sablont.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és a felülírások után?**  
Használja a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseoverridethememanager/) metódust egy dia vagy elrendezés sablonhoz, és a formátumobjektumok megfelelő hatékony‑adat metódusait, például a [Background.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/background/) és a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/) hívásával. Ezek az API‑k a feloldott értékeket adják vissza az öröklődés és a felülírások alkalmazása után.