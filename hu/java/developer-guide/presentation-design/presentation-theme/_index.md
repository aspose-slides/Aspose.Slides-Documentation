---
title: Prezentációs témák kezelése Java-ban
linktitle: Prezentációs téma
type: docs
weight: 10
url: /hu/java/presentation-theme/
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
- Java
- Aspose.Slides
description: "Mester prezentációs témák az Aspose.Slides for Java-ban a PowerPoint fájlok létrehozásához, testreszabásához és konvertálásához egységes márkázással."
---
## **Bevezetés**

Egy prezentáció témája egy koordinált szín-, betű-, háttérstílus-, kitöltés-, vonal- és effektuskészletet határoz meg. A témához igazított objektumok ezekre a közös definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma módosítása egyszerre sok objektumot frissíthet.

Az Aspose.Slides‑ben a prezentáció szintű témát a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) biztosítja. A prezentáció alacsonyabb szinteken is tartalmazhat téma‑felülírásokat. Egy mester felülírhatja a prezentáció témáját a [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/masterthememanager/) segítségével, míg egy elrendezés vagy egyedi diák felülírhatják a örökölt témát a [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseoverridethememanager/) segítségével. Gyakorlatban egy dia hatékony témája ezen öröklődési lánc mentén oldódik fel: prezentációtémá, mester‑felülírás, elrendezés‑felülírás és dia‑felülírás.

![A téma összetevői: színek, betűk, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma‑munkafolyamatokat mutatják be: téma ellenőrzése, színek és betűk módosítása, téma másolása vagy alkalmazása, háttér‑ és effektusstílusok frissítése, valamint az öröklődés és felülírások feloldása után a hatékony értékek kiolvasása.

## **Téma vizsgálata**

A [MasterTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mastertheme/) objektum a téma színsémáját, betűsémáját és formátumsémáját teszi elérhetővé a [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mastertheme/), a [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mastertheme/) és a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mastertheme/) metódusokon keresztül. Ezeknek a gyűjteményeknek a vizsgálata a módosítás előtt különösen hasznos, ha a prezentáció külső forrásból származik, mert a stílusbejegyzések száma és tartalma változhat.

Az alábbi példa beolvassa a fő téma tulajdonságait, és jelentést készít arról, hány háttér‑, kitöltés‑, vonal‑ és effektusstílus van a témában:

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

Ha egy fájl több mestert használ, ne feltételezzük, hogy minden dia ugyanazzal a hatékony témával rendelkezik. Vizsgálja meg a diához tartozó mestert, és használja a később bemutatott hatékony‑téma munkafolyamatot, amikor elrendezés‑ vagy dia‑felülírások lehetnek jelen.

## **Téma színeinek módosítása**

A témához igazított kitöltések, vonalak és szöveg hivatkozhat egy logikai színre a [SchemeColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/schemecolor/) felsorolásból. Ha megváltoztatja a megfelelő bejegyzést az [IColorScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icolorscheme/) objektumban, minden olyan objektum, amely még mindig erre a témaszínre hivatkozik, az új értékkel lesz feloldva. Azok az objektumok, amelyek közvetlen RGB‑színt használnak, nem változnak meg egy téma‑szín frissítésekor.

Az alábbi végponttól‑végpontig tartó példa egy `Accent4`‑et használó alakzatot hoz létre, a téma `Accent4` színét pirosra változtatja, menti a prezentációt, újra megnyitja, és kiírja a hatékony kitöltőszínt:

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

Mivel a téglalap továbbra is az `Accent4`‑hez van kapcsolva, látható színe piros lesz a téma módosítása után. Ha a séma színt közvetlenül a alakzatra helyettesíti, a későbbi `Accent4` változások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettáról**

A PowerPoint könnyebb és sötétebb változatokat állít elő egy témaszínből színtranszformációk alkalmazásával. Az Aspose.Slides ezekkel a transzformációkkal a [ColorTransformOperation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/colortransformoperation/) felsoroláson keresztül érhető el.

![Fő témaszínek és a kiegészítő palettáról generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – Fő témaszínek.  
**2** – A fő témaszínekből létrehozott világosabb és sötétebb változatok.

Az alábbi példa hat téglalapot hoz létre `Accent4`‑ből kiindulva, ötön alkalmaz lumineszcencia‑transzformációkat, majd elmenti az eredményt:

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

Ezek a változatok a témaszínhez maradnak kötve. Ha később `Accent4` megváltozik, a transzformált színek újra lesznek számítva az új `Accent4` értékből.

### **A `SchemeColor` értékek leképezése az `IColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg az [IColorScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icolorscheme/) ugyanazokat a témahelyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi elérhetővé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon témahelyek alternatív elnevezései; nem dinamikusan konvertált értékek.

## **Téma betűtípusainak módosítása**

A téma betűsémája egy fő betűkészletet tartalmaz a címsorokhoz és egy mellékbetűkészletet a törzsszöveghez. A [IFontScheme.getMajor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontscheme/) és a [IFontScheme.getMinor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontscheme/) metódusok teszik ezeket a készleteket elérhetővé.

A PowerPoint‑kompatibilis téma‑betűtípus-azonosítók a szövegformázásban használhatók:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Az alábbi példa egy címsort hoz létre, amely a fő Latin téma‑betűtípust használ, valamint egy törzssort, amely a mellék Latin téma‑betűtípust használ. Ezután módosítja a téma betűtípusait, és elmenti az eredményt:

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

A cím a fő betűtípust, a törzsszöveg pedig a mellék betűtípust követi. Az explicit betűtárgyú szöveg nem vált automatikusan, ha a téma‑betűséma megváltozik.

{{% alert color="info" title="Tipp" %}}
További információért a prezentáció betűtípusairól lásd a [PowerPoint betűtípusok](/slides/hu/java/powerpoint-fonts/).
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Két gyakori munkafolyamat létezik, amelyek különböző problémákat oldanak meg.

### **Forrás téma megőrzése a diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretne áthelyezni, és meg akarja őrizni annak eredeti megjelenését, klónozza a forrás mestert a célprezentációba az [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslidecollection/) segítségével, majd a diát a [ISlideCollection.addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidecollection/) és a klónozott mesterrel. Így a mester, elrendezései és a hozzá tartozó téma együtt kerülnek át.

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

Ez a preferált munkafolyamat, ha a forrás dia megjelenésének változatlanságát akarja a célhelyen is. A tartalom egyszerű klónozása egy nem kapcsolódó célmesterre megváltoztathatja a téma‑alapú színeket, betűket, hátteret és effektusokat.

### **Témaértékek alkalmazása létező diára**

Ha a cél dia maradjon a jelenlegi mesterén és elrendezésén, inicializáljon egy dia‑szintű felülírást a forrás témából. A [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/overridetheme/), a [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/overridetheme/) és a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/overridetheme/) metódusok másolják a három fő téma‑komponenst a felülírásba.

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

Ez megváltoztatja a dia által használt témát anélkül, hogy a többi dia örökölt témáját módosítaná. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívja a [OverrideTheme.clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/overridetheme/) metódust.

### **Téma felülírás alkalmazása elrendezésre**

Az elrendezés‑szintű felülírás az arra épülő diákra vonatkozik, kivéve, ha egy adott dia saját felülírással rendelkezik. Ugyanezen inicializáló metódusok használhatók a [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/layoutslidethememanager/) segítségével:

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

Használjon prezentáció‑ vagy mester‑szintű témát, ha sok elrendezésnek és diáknak közös alaptervezést kell megosztania; egy elrendezés‑felülírást, ha egy elrendezéscsaládnak eltérő stílusra van szüksége; és csak dia‑szintű felülírást valódi kivételekhez. A túlzott dia‑szintű felülírások megnehezítik a későbbi globális téma‑változtatások előrejelzését.

## **Téma háttérstílusainak frissítése**

A téma háttér‑kitöltései az [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iformatscheme/) segítségével vannak tárolva. A PowerPoint a felhasználói felületén több háttérválasztási lehetőséget mutathat, mint amennyi kitöltés‑definíció fizikailag tárolva van ebben a gyűjteményben, mivel a UI a téma‑kitöltéseket kombinálhatja a téma‑színekkel és egyéb stílus‑hivatkozásokkal.

![PowerPoint háttérstílus galéria egy prezentációtémához](presentation-design_8.png)

Mielőtt egy háttérstílust használná, ellenőrizze a tárolt gyűjteményt és az aktuális [Background.getStyleIndex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/background/) értéket. A `0`‑ás index azt jelenti, hogy nincs témához tartozó kitöltés; a pozitív értékek téma‑háttér‑stílus‑hivatkozások. Ez eltér a Java‑gyűjtemény közvetlen indexelésétől, ahol a `get_Item(0)` az első tárolt elemet jelenti. Ne feltételezze, hogy minden prezentáció ugyanolyan számú háttér‑kitöltés‑stílussal rendelkezik.

Az alábbi példa jelentést ad a rendelkezésre álló háttér‑kitöltésszámról, a témára hivatkozó háttérhivatkozást rendeli az első mesterhez, és elmenti a prezentációt:

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

Az látható eredmény a mester által hivatkozott téma‑bejegyzéstől, valamint az elrendezés‑ vagy dia‑szintű háttér‑felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, a mester háttér módosítása nem feltétlenül változtatja meg azt a diát. Használja a [Background.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/background/) metódust, amikor a végleges, öröklődés után alkalmazott háttérre van szükség.

{{% alert color="warning" title="Figyelmeztetés" %}}
Ne tekintse a stílus‑indexet nulla‑alapú gyűjtemény‑indexnek. Kerülje a stílus‑számok egy fájlból való egyértelmű kódolását és feltételezését, hogy ugyanúgy jelenik meg egy másik fájlban; a téma‑stílus‑definíciók prezentációnként eltérőek.
{{% /alert %}}

{{% alert color="info" title="Tipp" %}}
Közvetlen háttérformázásért és háttér‑öröklődésért lásd a [Prezentáció háttér](/slides/hu/java/presentation-background/) cikket.
{{% /alert %}}

## **Téma effektusainak frissítése**

A téma formátumsémája különálló kitöltés‑, vonal‑ és effektus‑stílus‑gyűjteményeket tartalmaz, amelyeket a [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iformatscheme/), a [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iformatscheme/) és a [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iformatscheme/) metódusok exponálnak. A tipikus Office‑témák gyakran három fő stílusbejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak mindig a gyűjteményeket kell ellenőriznie, ahelyett, hogy rögzített számra építene.

![Finom, közepes és intenzív téma‑effektusok ugyanazon alakzaton](presentation-design_10.png)

Java‑ban ezeknek a gyűjteményeknek a indexelése nulla‑alapú: a `get_Item(0)` az első tárolt stílust, a `get_Item(2)` a harmadikat adja vissza. Egy alakzat stílushivatkozási indexei egy külön fogalom, a [IShapeStyle](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapestyle/) által exponálva. Egy téma‑stílus módosítása azokra az alakzatokra hat, amelyek arra hivatkoznak; a közvetlen formázású alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek, módosítja az első vonal‑stílust, a harmadik kitöltés‑stílust, engedélyezi a külső árnyékot a harmadik effektus‑stílusban, és elmenti az eredményt:

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

Az ezekre a helyekre hivatkozó alakzatok esetén az első téma‑vonal‑stílus piros lesz, a harmadik téma‑kitöltés‑stílus szilárd erdőzöld, a harmadik effektus‑stílus pedig egy 10 pont távolságú külső árnyékot kap. A pontos vizuális eredmény továbbra is attól függ, hogy melyik stílushelyet hivatkozza az egyes alakzat, illetve a közvetlen formázás felülírja‑e a témát.

![Téma‑effektus‑stílusok módosítás után: vonal, kitöltés és árnyék beállítások](presentation-design_11.png)

## **Hatékony témaértékek olvasása**

A nyers témaobjektumok megmutatják, mi van definiálva egy adott szinten. A hatékony értékek azt mutatják, mit használ egy dia vagy alakzat a tényleges öröklődés és helyi felülírások feloldása után. Diához a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseoverridethememanager/) metódust hívja. Háttérhez a [Background.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/background/) és kitöltéshez a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/) metódust.

Az alábbi példa beolvassa a hatékony témát, háttér‑ és az első alakzat kitöltését egy diáról:

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

Használja a hatékony adatokat a megjelenítési diagnosztikához, validáláshoz és összehasonlításokhoz. Ha csak a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) objektumot vizsgálja, előfordulhat, hogy egy mester, elrendezés, dia vagy alakzat felülírását kihagyja, amely a végső megjelenést módosítja.

## **GYIK**

**Alkalmazhatok témát egyetlen diára a mester megváltoztatása nélkül?**

Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slidethememanager/) objektumát, és inicializálja annak felülírt témáját. A változtatás csak arra a diára vonatkozik; a többi dia a meglévő témáit örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének egy prezentációból a másikba?**

Amikor egy diát áthelyez és meg akarja őrizni a forrás megjelenését, klónozza a forrás mestert a célba, majd a diát a [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslidecollection/) és a [ISlideCollection.addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidecollection/) segítségével. Így a mester, az elrendezések és a téma együtt maradnak.

**Hogyan láthatom a hatékony értékeket az öröklődés és felülírások után?**

Használja a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseoverridethememanager/) metódust egy dia vagy elrendezés téma esetén, valamint a megfelelő hatékony‑adat metódusokat a formátumobjektumokhoz, például a [Background.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/background/) és a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/) metódusokat. Ezek az API‑k a feloldott értékeket adják vissza az öröklődés és felülírások alkalmazása után.