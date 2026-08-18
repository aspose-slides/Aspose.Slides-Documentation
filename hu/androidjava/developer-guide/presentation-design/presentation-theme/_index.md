---
title: Prezentációs témák kezelése Androidon
linktitle: Prezentációs téma
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
- téma betűtípus
- téma stílus
- téma effektus
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Androidban a fő prezentációs témák kezelése Java‑val, hogy PowerPoint fájlokat hozzon létre, testre szabjon és konvertáljon egységes márkázással."
---
## **Bevezetés**

A prezentációs téma egy koordinált szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektuskészletet határoz meg. A témához igazított objektumok ezekre a megosztott definíciókra hivatkoznak, ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma módosítása egyszerre sok objektumot frissíthet.

Az Aspose.Slides‑ben a prezentáció szintű téma a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) segítségével érhető el. Egy prezentáció alacsonyabb szinteken is tartalmazhat téma‑felülbírálásokat. A mester felülbírálhatja a prezentáció témáját a [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/masterthememanager/), míg egy elrendezés vagy egyedi dia felülbírálhatja az örökölt témát a [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseoverridethememanager/). Gyakorlatban egy dia hatékony témája ezen öröklési lánc mentén kerül feloldásra: prezentációs téma, mester‑felülbírálás, elrendezés‑felülbírálás és dia‑felülbírálás.

![Témaelemek: színek, betűtípusok, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma‑munkafolyamatokat mutatják be: téma ellenőrzése, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér‑ és effektusstílusok frissítése, valamint az öröklés és felülbírálás után kapott hatékony értékek olvasása.

## **Téma ellenőrzése**

A [MasterTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mastertheme/) objektum a téma színsémáját, betűtípus‑sémáját és formátumsémáját a [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mastertheme/) és [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mastertheme/) segítségével teszi elérhetővé. Ezeknek a gyűjteményeknek a vizsgálata a módosítás előtt különösen hasznos, ha a prezentáció egy külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

Az alábbi példa beolvassa a fő téma‑tulajdonságokat, és jelentést készít arról, hány háttér‑, kitöltés‑, vonal‑ és effektus‑stílus van tárolva a témában:

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

Ha egy fájl több mestert használ, ne feltételezzük, hogy minden dia ugyanazzal a hatékony témával rendelkezik. Vizsgáljuk meg a diára vonatkozó mestert, és használjuk a cikk később bemutatott hatékony‑téma munkafolyamatot, ha elrendezés‑ vagy dia‑felülbírálások lehetségesek.

## **Téma színeinek módosítása**

A témához igazított kitöltések, vonalak és szövegek a [SchemeColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/schemecolor/) felsorolás logikai színére hivatkozhatnak. Amikor a megfelelő bejegyzést a [IColorScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icolorscheme/)‑ben módosítjuk, minden objektum, ami továbbra is erre a téma‑színre hivatkozik, az új érték szerint kerül feloldásra. Azok az objektumok, amelyek közvetlen RGB‑színt használnak, nem változnak a téma‑szín frissítésekor.

Az alábbi vég‑től‑végig példakód egy `Accent4`‑et használó alakzatot hoz létre, a téma `Accent4` színét pirosra állítja, elmenti a prezentációt, újra megnyitja, majd kiírja a hatékony kitöltőszínt:

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

Mivel a téglalap továbbra is a `Accent4`‑hez van linkelve, a látható színe a téma módosítása után piros lesz. Ha a téma‑színt közvetlen színre cseréljük az alakzaton, a későbbi `Accent4` módosítások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettáról**

A PowerPoint a téma‑színből világosabb és sötétebb változatokat származtat színtranszformációk alkalmazásával. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/colortransformoperation/) felsorolásban teszi elérhetővé.

![A fő téma színei és a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – Fő téma színek.  
**2** – A fő téma színeiből származó világosabb és sötétebb változatok.

Az alábbi példakód hat téglalapot hoz létre `Accent4` alapján, ötödikre luminancia‑transzformációt alkalmaz, majd elmenti az eredményt:

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

Ezek a variánsok a téma‑színen alapulnak továbbra is. Ha a `Accent4` később megváltozik, a transzformált színek az új `Accent4` értékből kerülnek újraszámításra.

### **`SchemeColor` értékek leképezése az `IColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg az [IColorScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icolorscheme/) ugyanazokat a téma‑helyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi elérhetővé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon téma‑helyek alternatív megnevezései; nem dinamikusan átalakított értékek egyik formából a másikba.

## **Téma betűtípusainak módosítása**

Egy téma‑betűtípus‑séma fő betűkészletet tartalmaz a címsoroknak és kisebb betűkészletet a törzsszövegnek. A [IFontScheme.getMajor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontscheme/) és a [IFontScheme.getMinor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontscheme/) metódusok ezeket a készleteket teszik láthatóvá.

PowerPoint‑kompatibilis téma‑betűtípus‑azonosítók használhatók a szövegformázásban:

* `+mn-lt` – Törzsszöveg betűtípusa Latin (Kisebb Latin betűtípus)
* `+mj-lt` – Címsor betűtípusa Latin (Fő Latin betűtípus)
* `+mn-ea` – Törzsszöveg betűtípusa Kelet‑ázsiai (Kisebb Kelet‑ázsiai betűtípus)
* `+mj-ea` – Címsor betűtípusa Kelet‑ázsiai (Fő Kelet‑ázsiai betűtípus)

Az alábbi példa létrehoz egy címsort, amely a fő Latin téma‑betűtípust használ, és egy törzsszövegsort, amely a kisebb Latin téma‑betűtípust használ. Ezután megváltoztatja a téma‑betűtípusokat és elmenti az eredményt:

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

A címsor a fő betűtípust, a törzsszöveg pedig a kisebb betűtípust követi. Azok a szövegek, amelyek explicit betűtárgy neveket tartalmaznak a téma‑azonosító helyett, nem váltanak automatikusan, ha a téma‑betűtípus‑séma változik.

{{% alert color="info" title="Tip" %}}
További információk a prezentációs betűtípusokról: lásd a [PowerPoint Fonts](/slides/hu/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Két gyakori munkafolyamat létezik, amelyek különböző problémákat oldanak meg.

### **Eredeti téma megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretne áthelyezni, és meg akarja őrizni az eredeti megjelenését, klónozza a forrás‑mestert a cél‑prezentációba az [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslidecollection/) segítségével, majd a diát a [ISlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/) és a klónozott mesterrel klónozza. Így a mester, az elrendezései és a hozzá kapcsolódó téma együtt kerül át.

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

Ez a preferált munkafolyamat, ha a forrásdia ugyanúgy kell, hogy kinézzen a célhelyen. A tartalom egyszerű klónozása egy nem kapcsolódó cél‑mesterre módosíthatja a téma‑alapú színeket, betűtípusokat, háttereket és effektusokat.

### **Témaértékek alkalmazása létező diára**

Ha a cél‑diának a jelenlegi mestere és elrendezése kell, hogy megmaradjon, inicializáljon egy dia‑szintű felülbírálást a forrás‑témból. Az [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/overridetheme/) és [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/overridetheme/) metódusok lemásolják a három fő téma‑komponenst a felülbírálásba.

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

Ez megváltoztatja a dia által használt témát anélkül, hogy a többi dia által örökölt témát módosítaná. A helyi felülbírálás eltávolításához és az örökölt értékek visszaállításához hívja meg az [OverrideTheme.clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/overridetheme/)‑t.

### **Téma felülbírálás alkalmazása elrendezésre**

Az elrendezés‑szintű felülbírálás azokra a diákra vonatkozik, amelyek az adott elrendezést használják, kivéve, ha egy konkrét dia saját felülbírálattal rendelkezik. Ugyanazokat az inicializáló metódusokat a [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/layoutslidethememanager/) is használhatja:

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

Használjon mestert vagy prezentáció‑szintű témát, ha sok elrendezésnek és diáknak ugyanazt az alaptervet kell megosztania, elrendezés‑felülbírálást, ha egy elrendezés‑családnak más stílusra van szüksége, és dia‑felülbírálást csak valódi kivételekhez. A túlzott dia‑szintű felülbírálások megnehezítik a későbbi globális téma‑változások előrejelzését.

## **Téma háttérstílusok frissítése**

A téma háttérkitöltései az [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iformatscheme/)‑ben tárolódnak. A PowerPoint a felhasználói felületén több háttérválasztási lehetőséget mutathat meg, mint a gyűjteményben fizikailag tárolt kitöltés‑definíciók száma, mivel a UI kombinálhatja a téma‑kitöltéseket a téma‑színekkel és egyéb stílushivatkozásokkal.

![PowerPoint háttérstílus galéria egy prezentációs témához](presentation-design_8.png)

Mielőtt háttérstílust alkalmazna, vizsgálja meg a tárolt gyűjteményt és az aktuális [Background.getStyleIndex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/background/)-et. A `0`‑ás stílusindex azt jelenti, hogy nincs témához kapcsolódó kitöltés; a pozitív értékek téma‑háttér‑stílus‑referenciák. Ez eltér a Java‑gyűjtemény közvetlen indexelésétől, ahol a `get_Item(0)` az első tárolt elemet jelenti. Ne feltételezze, hogy minden prezentáció ugyanannyi háttérkitöltés‑stílussal rendelkezik.

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

A látható eredmény a mester által hivatkozott téma‑bejegyzéstől és az elrendezés‑ vagy dia‑szintű háttér‑felülbírálásoktól függ. Ha egy dia saját hátteret használ, a mester hátterének módosítása nem feltétlenül változtatja meg azt a diát. Használja a [Background.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/background/)‑t, ha a végleges háttérre van szükség az öröklés alkalmazása után.

{{% alert color="warning" title="Warning" %}}
Ne kezelje a stílusindexet null‑alapú gyűjteményindexként. Emellett kerülje a stílus számának kézi kódolását egy fájlból, és annak feltételezését, hogy ugyanolyan megjelenést eredményez egy másik fájlban; a téma‑stílusdefiníciók prezentációnként változnak.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
A közvetlen háttérformázáshoz és a háttér‑örökléshez lásd a [Presentation Background](/slides/hu/androidjava/presentation-background/) oldalt.
{{% /alert %}}

## **Téma effektusok frissítése**

A téma formátumsémája különálló kitöltés‑, vonal‑ és effektus‑stílus‑gyűjteményeket tartalmaz, amelyeket az [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iformatscheme/) és [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iformatscheme/) exponálnak. A tipikus Office‑témák gyakran három fő stílusbejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell, ahelyett, hogy rögzített számra támaszkodna.

![Finom, közepes és intenzív téma effektusok ugyanazon alakzatra alkalmazva](presentation-design_10.png)

Java‑ban ezekhez a gyűjteményekhez a gyűjtemény‑index null‑alapú: a `get_Item(0)` az első tárolt stílus, a `get_Item(2)` a harmadik. Az alakzat‑stílus‑referencia indexek külön koncepciót alkotnak, amelyet az [IShapeStyle](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapestyle/) exponál. Egy téma‑stílus módosítása azokra az alakzatokra hat, amelyek hivatkoznak arra a téma‑stílusra; a közvetlen formázással rendelkező alakzatok változatlanok maradhatnak.

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

Az alábbi példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek-e, megváltoztatja az első vonal‑stílust, a harmadik kitöltő‑stílust, harmadik effektus‑stílusában egy külső árnyékot kapcsol be 10 pont távolsággal, majd elmenti az eredményt.

Az ezekre a helyekre hivatkozó alakzatok esetében az első téma‑vonal‑stílus pirosra, a harmadik téma‑kitöltő‑stílus szilárd erdőzöldre, a harmadik effektus‑stílus pedig külső árnyékot kap 10 pont távolsággal. A pontos vizuális eredmény továbbra is attól függ, hogy melyik stílushelyre hivatkozik az egyes alakzat, és hogy a közvetlen formázás felülírja-e a témát.

![Téma effektus stílusok a vonal, kitöltés és árnyék beállításainak módosítása után](presentation-design_11.png)

## **Alkalmazott témaértékek olvasása**

A nyers témaobjektumok megmutatják, mi van definiálva egy adott szinten. Az alkalmazott értékek pedig azt, amit egy dia vagy alakzat ténylegesen használ az öröklés és a helyi felülbírálások feloldása után. Egy diához a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseoverridethememanager/)‑t kell meghívni. Háttérhez a [Background.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/background/)-t, kitöltéshez pedig a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/)-t.

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

Használja az alkalmazott adatokat renderelési diagnosztikához, validációhoz és összehasonlításokhoz. Ha csak a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/)‑t vizsgálja, lemaradhat egy mester, elrendezés, dia vagy alakzat felülbírálásáról, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Alkalmazhatok-e egy témát egyetlen diára a mester módosítása nélkül?**

Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidethememanager/)-ét, és inicializálja a felülbírálási témáját. A módosítás csak arra a diára vonatkozik; a többi dia a meglévő témáit örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének az egyik prezentációból a másikba?**

Diák áthelyezésekor és a forrásmegjelenés megőrzésekor klónozza a forrás‑mestert a célba, majd a diát a [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslidecollection/) és a [ISlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/) segítségével. Így a mester, az elrendezések és a téma együtt marad.

**Hogyan tekinthetem meg az alkalmazott értékeket az öröklés és a felülbírálások után?**

Használja a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseoverridethememanager/)‑t egy dia vagy elrendezés téma esetén, valamint a megfelelő alkalmazott‑adat metódusokat formátumobjektumokhoz, például a [Background.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/background/) és a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/) esetén. Ezek az API‑k az öröklés és felülbírálások után feloldott értékeket adják vissza.