---
title: Prezentációs témák kezelése Androidon
linktitle: Prezentációs Téma
type: docs
weight: 10
url: /hu/androidjava/presentation-theme/
keywords:
- PowerPoint téma
- prezentációs téma
- dia téma
- téma beállítása
- téma módosítása
- téma kezelése
- téma szín
- kiegészítő paletta
- téma betűtípusa
- téma stílusa
- téma effektus
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Mester prezentációs témák az Aspose.Slides for Androidban Java segítségével a PowerPoint fájlok létrehozásához, testreszabásához és konvertálásához egységes márkázás mellett."
---
## **Bevezetés**

Egy prezentációs téma meghatároz egy koordinált szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektuskészletet. A témához igazított objektumok ezekre a közös definíciókra hivatkoznak, ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma módosítása egyszerre sok objektumot frissíthet.

Az Aspose.Slides esetén a prezentáció szintű téma a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) segítségével érhető el. Egy prezentáció alacsonyabb szinteken is tartalmazhat téma felülírásokat. Egy master felülírhatja a prezentáció témát a [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/masterthememanager/) segítségével, míg egy elrendezés vagy egyedi dia felülírhatja az örökölt témát a [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseoverridethememanager/) használatával. Gyakorlatban egy dia effektív témája ezen öröklődési láncon keresztül kerül feloldásra: prezentáció téma, master felülírás, elrendezés felülírás és dia felülírás.

![Téma elemei: színek, betűtípusok, háttérstílusok és effektek](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma munkafolyamatokat mutatják be: téma vizsgálata, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér- és effektusstílusok frissítése, valamint az öröklődés és felülírások feloldása után kapott effektív értékek olvasása.

## **Téma vizsgálata**

A [MasterTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mastertheme/) objektum a téma színsémáját, betűtípus-sémáját és formátumsémáját teszi elérhetővé a [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mastertheme/), és [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mastertheme/) segítségével. Ezeknek a gyűjteményeknek a vizsgálata módosítás előtt különösen hasznos, ha a prezentáció külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

A következő példa beolvassa a fő téma tulajdonságait, és jelentést készít arról, hány háttér-, kitöltés-, vonal- és effektus-stílus van tárolva a témában:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
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

Ha egy fájl több masterrel dolgozik, ne feltételezd, hogy minden dia ugyanazzal az effektív témával rendelkezik. Vizsgáld meg a diához tartozó mastert, és használd a később ebben a cikkben bemutatott effektív téma munkafolyamatot, ha elrendezés vagy dia felülírás lehet jelen.

## **Téma színeinek módosítása**

A témához igazított kitöltések, vonalak és szöveg hivatkozhat egy logikai színre a [SchemeColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/schemecolor/) felsorolásból. Amikor a megfelelő bejegyzést módosítod az [IColorScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icolorscheme/) segítségével, az összes olyan objektum, amely továbbra is a témaszínre hivatkozik, az új értékkel kerül feloldásra. Azok az objektumok, amelyek közvetlen RGB színt használnak, nem változnak a téma-szín frissítésével.

A következő teljes körű példa létrehoz egy alakzatot, amely a `Accent4` színt használja, megváltoztatja a téma `Accent4` színét pirosra, elmenti a prezentációt, újra megnyitja, és kiírja az effektív kitöltőszínt:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

Mivel a téglalap továbbra is a `Accent4` színhez van kapcsolva, a látható színe a téma módosítása után piros lesz. Ha a séma színt közvetlen színre cseréled az alakzaton, a későbbi `Accent4` változtatások már nem befolyásolják azt a kitöltést.

### **További palettáról színek használata**

A PowerPoint könnyebb és sötétebb változatokat származtat a téma színéből színtranszformációk alkalmazásával. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/colortransformoperation/) felsorolás segítségével teszi elérhetővé.

![Fő téma színek és a további palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** - Fő téma színek.  
**2** - A fő téma színekből előállított világosabb és sötétebb változatok.

A következő példa hat `Accent4`-re épülő téglalapot hoz létre, ötön luminancia-transzformációkat alkalmaz, és elmenti az eredményt:

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

Ezek a változatok a téma színén maradnak. Ha a `Accent4` később megváltozik, a transzformált színek újraszámolódnak az új `Accent4` értékből.

### **A `SchemeColor` értékek leképezése az `IColorScheme` slotokra**

A [SchemeColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg az [IColorScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icolorscheme/) ugyanazokat a téma slotokat `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi elérhetővé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon téma slotok alternatív nevei; nem dinamikusan konvertált értékek.

## **Téma betűtípusainak módosítása**

Egy téma betűtípus-séma tartalmaz egy fő betűkészletet a címsorokhoz és egy másodlagos betűkészletet a törzsszöveghez. Az [IFontScheme.getMajor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontscheme/) és [IFontScheme.getMinor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontscheme/) metódusok teszik ezeket a készleteket elérhetővé.

PowerPoint-kompatibilis téma betűtípus-azonosítók használhatók a szövegformázásban:

* `+mn-lt` – Törzsszöveg betűtípusa Latin (Minor Latin Font)
* `+mj-lt` – Címsor betűtípusa Latin (Major Latin Font)
* `+mn-ea` – Törzsszöveg betűtípusa Kelet-Ázsiai (Minor East Asian Font)
* `+mj-ea` – Címsor betűtípusa Kelet-Ázsiai (Major East Asian Font)

A következő példa létrehoz egy címsort, amely a fő Latin téma betűtípust használja, és egy törzssort, amely a kisebb Latin téma betűtípust használja. Ezután módosítja a téma betűtípusait és elmenti az eredményt:

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

A címsor a fő betűtípust, a törzsszöveg a kisebb betűtípust követi. A szöveg, amely explicit betűtípusnevet tartalmaz a témaazonosító helyett, nem vált automatikusan, amikor a téma betűtípus-séma módosul.

A fő és a kisebb betűkészletek tartalmazhatnak betűtípus-leképezéseket egyedi írásrendszerekhez, például cirill, arab, japán, grúz és thaana nyelvhez. Ezeknek a leképezéseknek a vizsgálatához, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script-Specific Theme Fonts](/slides/hu/androidjava/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tip" %}}
További információk a prezentáció betűtípusaival kapcsolatban itt találhatók: [PowerPoint Fonts](/slides/hu/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Két gyakori munkafolyamat létezik, amelyek különböző problémákat oldanak meg.

### **Forrás téma megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretnél áthelyezni, miközben megőrzöd az eredeti megjelenését, klónozd a forrás mastert a célprezentációba az [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslidecollection/) segítségével, majd klónozd a diát az [ISlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/) és a klónozott masterrel. Ez együttesen viszi a mastert, az elrendezéseket és a kapcsolódó témát.

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

Ez a preferált munkafolyamat, amikor a forrás dia ugyanúgy kell, hogy kinézzen a célban. Az egyszerű klónozás egy nem kapcsolódó célmasterre megváltoztathatja a téma által vezérelt színeket, betűtípusokat, háttér- és effektus beállításokat.

### **Témaértékek alkalmazása meglévő diára**

Ha a cél dia a jelenlegi masterén és elrendezésén kell maradjon, inicializálj egy diához kapcsolódó felülírást a forrás témából. Az [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/overridetheme/), és [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/overridetheme/) metódusok másolják a három fő téma komponenst a felülírásba.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

Ez megváltoztatja a dián használt témát anélkül, hogy a többi dia által örökölt témát módosítaná. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívd a [OverrideTheme.clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/overridetheme/) metódust.

### **Téma felülírás alkalmazása egy elrendezésre**

Egy elrendezés szintű felülírás azokat a diákra vonatkozik, amelyek ezt az elrendezést használják, hacsak egy adott dia saját felülírással nem rendelkezik. Ugyanazok a inicializációs metódusok használhatók a [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/layoutslidethememanager/) segítségével:

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

Használj master vagy prezentáció szintű témát, ha sok elrendezésnek és diáknak ugyanazt az alapdesign-t kell megosztania, egy elrendezés felülírást, ha egy elrendezéscsaládnak eltérő stílusra van szüksége, és egy dia felülírást csak valódi kivételekhez. A túlzott diához kapcsolódó felülírások megnehezítik a későbbi globális téma változtatások előrejelzését.

## **Téma háttérstílusok frissítése**

A téma háttérkitöltései a [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iformatscheme/) gyűjteményben vannak tárolva. A PowerPoint a felhasználói felületén több háttérválasztási lehetőséget jeleníthet meg, mint amennyi kitöltésdefiníció fizikailag tárolva van ebben a gyűjteményben, mivel a UI kombinálhatja a téma kitöltéseket téma színekkel és egyéb stílusreferenciákkal.

![PowerPoint háttérstílus galéria egy prezentáció témához](presentation-design_8.png)

Mielőtt háttérstílust használnál, vizsgáld meg a tárolt gyűjteményt és a jelenlegi [Background.getStyleIndex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/background/) értéket. A `0` stílusindex azt jelenti, hogy nincs témához tartozó kitöltés; a pozitív értékek téma háttérstílus-referenciai. Ez eltér a Java gyűjtemény közvetlen indexelésétől, ahol a `get_Item(0)` az első tárolt elemet jelenti. Ne feltételezd, hogy minden prezentáció ugyanannyi háttérkitöltési stílussal rendelkezik.

A következő példa jelentést készít az elérhető háttérkitöltési számról, témához tartozó háttérreferenciát ad az első masternek, és elmenti a prezentációt:

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

A látható eredmény a master által hivatkozott téma bejegyzéstől és az elrendezés vagy dia szintű háttér felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, a master háttér módosítása önmagában nem változtatja meg azt a diát. Használd a [Background.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/background/) metódust, ha a végső háttérre van szükséged az öröklődés után.

{{% alert color="warning" title="Warning" %}}
Ne kezeld a stílusindexet nullától induló gyűjteményindexnek. Kerüld a stílus számok kódba írását egy fájlból, és annak feltételezését, hogy ugyanúgy néz ki egy másik fájlban; a téma stílusdefiníciók prezentációnként eltérőek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Közvetlen háttérformázás és háttér öröklődés tekintetében lásd a [Presentation Background](/slides/hu/androidjava/presentation-background/) oldalt.
{{% /alert %}}

## **Téma effektusok frissítése**

Egy téma formátumséma különálló kitöltés-, vonal- és effektus-stílusgyűjteményeket tartalmaz, amelyeket a [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iformatscheme/), és [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iformatscheme/) tesz elérhetővé. A tipikus Office témák gyakran három fő stílusbejegyzést tartalmaznak, amelyek vizuálisan a finom, mérsékelt és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell a fix darabszám feltételezése helyett.

![Finom, mérsékelt és intenzív témaeffektek ugyanarra az alakzatra alkalmazva](presentation-design_10.png)

Java-ban ezekhez a gyűjteményekhez való hozzáféréskor a gyűjtemény indexelése nullától indul: a `get_Item(0)` az első tárolt stílus, a `get_Item(2)` a harmadik. Egy alakzat stílus-referencia indexei egy külön koncepció, amely a [IShapeStyle](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapestyle/) segítségével érhető el. Egy téma stílus módosítása azok az alakzatok módosulnak, amelyek hivatkoznak arra a téma stílusra; a közvetlen formázású alakzatok változatlanok maradhatnak.

A következő példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek, módosítja az első vonalstílust, a harmadik kitöltésstílust, engedélyezi a külső árnyékot a harmadik effektusstílusban, és elmenti az eredményt:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A slotokra hivatkozó alakzatoknál az első téma vonalstílus pirosra változik, a harmadik téma kitöltésstílus szilárd erdőzöld lesz, a harmadik effektusstílus egy 10 pont távolságú külső árnyékot kap. A pontos vizuális eredmény továbbra is attól függ, hogy melyik stílus slotokra hivatkozik az egyes alakzat, és hogy a közvetlen formázás felülírja-e a témát.

![Téma effektus stílusok a vonal, kitöltés és árnyék beállítások módosítása után](presentation-design_11.png)

## **Effektív téma értékek olvasása**

A nyers témaobjektumok azt mutatják, hogy mi van meghatározva egy adott szinten. Az effektív értékek azt mutatják, hogy egy dia vagy alakzat valójában mit használ az öröklődés és a helyi felülírások feloldása után. Egy dia esetén hívd a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseoverridethememanager/) metódust. Háttérhez használd a [Background.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/background/), kitöltéshez pedig a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/) metódust.

A következő példa beolvassa egy dia effektív témáját, háttérét és az első alakzat kitöltését:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

Használd az effektív adatokat a megjelenítési diagnosztikához, ellenőrzéshez és összehasonlításhoz. Ha csak a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) metódust vizsgálod, elkerülheted a master, elrendezés, dia vagy alakzat felülírását, amely megváltoztathatja a végső megjelenést.

## **GYIK**

**Alkalmazhatok témát egyetlen diára anélkül, hogy a mastert módosítanám?**

Igen. Használd a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidethememanager/) objektumát, és inicializáld a felülírási témát. A változtatás csak arra a diára vonatkozik; a többi dia továbbra a meglévő témáikat örökli.

**Mi a legbiztonságosabb módja a téma egyik prezentációból a másikba való átvitelnek?**

A legbiztonságosabb módja a téma egyik prezentációból a másikba való átvitelnek, ha egy dia áthelyezésekor megőrzöd a forrás megjelenését, akkor klónozd a forrás mastert a célnál, majd klónozd a diát a masterrel együtt az [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslidecollection/) és [ISlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/) használatával. Ez együttesen tartja a mastert, az elrendezéseket és a témát.

**Hogyan tekinthetem meg az effektív értékeket az öröklődés és a felülírások után?**

Használd a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseoverridethememanager/) metódust egy dia vagy elrendezés téma esetén, valamint a megfelelő effektív-adat metódusokat formátum objektumokhoz, mint például a [Background.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/background/) és a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/). Ezek az API-k a öröklődés és a felülírások alkalmazása után feloldott értékeket adják vissza.