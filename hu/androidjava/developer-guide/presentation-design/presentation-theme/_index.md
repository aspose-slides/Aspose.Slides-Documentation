---
title: Androidon a prezentációs témák kezelése
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
- külső téma
- THMX
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
description: "Az Aspose.Slides for Android mester prezentációs témákat Java-val használva a PowerPoint fájlok egységes márkázással történő létrehozása, testreszabása és konvertálása."
---
## **Bevezetés**

A prezentációs téma egy koordinált szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektuskészletet határoz meg. A témaérzékeny objektumok ezekre a megosztott definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma módosítása egyszerre frissítheti a sok objektumot.

Az Aspose.Slides-ben a prezentáció-szintű témát a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) biztosítja. A prezentáció alacsonyabb szinteken is tartalmazhat téma‑felülírásokat. Egy master felülírhatja a prezentáció témáját a [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/masterthememanager/) segítségével, míg egy elrendezés vagy egy egyedi dia felülírhatja a örökölt témát a [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseoverridethememanager/) segítségével. Gyakorlatban a dia tényleges témája ezen öröklődési láncon keresztül kerül feloldásra: prezentációs téma, master‑felülírás, elrendezés‑felülírás és dia‑felülírás.

![Témaelemek: színek, betűtípusok, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok bemutatják a leggyakoribb téma‑munkafolyamatokat: téma ellenőrzése, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér‑ és effektusstílusok frissítése, valamint a öröklődés és felülírások feloldása után kapott tényleges értékek kiolvasása.

## **Téma ellenőrzése**

A [MasterTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mastertheme/) objektum a téma színsémáját, betűtípus‑sémáját és formátumsémáját teszi elérhetővé a [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mastertheme/), a [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mastertheme/) és a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mastertheme/) metódusokon keresztül. Ezeknek a gyűjteményeknek az ellenőrzése különösen hasznos, ha a prezentáció külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

Az alábbi példa beolvassa a fő téma tulajdonságait, és jelentést készít arról, hogy hány háttér-, kitöltés-, vonal‑ és effektusstílus tárolódik a témában:

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

Ha egy fájl több master‑t használ, ne feltételezzük, hogy minden dia ugyanazzal a tényleges témával rendelkezik. Ellenőrizzük a diával társított master‑t, és a később bemutatott effektív‑téma munkafolyamatot használjuk, ha elrendezés‑ vagy dia‑felülírások lehetnek jelen.

## **Téma színeinek módosítása**

A téma‑érzékeny kitöltések, vonalak és szöveg egy logikai színre hivatkozhat a [SchemeColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/schemecolor/) felsorolásban. Ha a megfelelő bejegyzést módosítjuk az [IColorScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icolorscheme/) gyűjteményben, minden objektum, amely még a témaszínre hivatkozik, az új értékhez lesz rendelve. Az RGB‑színnel közvetlenül megadott objektumok nem változnak a téma‑szín frissítésekor.

Az alábbi vég‑ig‑terjedő példa egy `Accent4`‑et használó alakzatot hoz létre, megváltoztatja a téma `Accent4` színét vörösre, elmenti a prezentációt, újra megnyitja, és kiírja a tényleges kitöltési színt:

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

Mivel a téglalap továbbra is az `Accent4`‑hez van kapcsolva, látható színe piros lesz a téma módosítása után. Ha a sémaszínt közvetlen színre cseréljük az alakzaton, a későbbi `Accent4` módosítások már nem érintik azt a kitöltést.

### **Színek használata a kiegészítő palettáról**

A PowerPoint a téma színéből világosabb és sötétebb variánsokat hoz létre színtranszformációk alkalmazásával. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/colortransformoperation/) felsoroláson keresztül teszi elérhetővé.

![Fő téma színek és a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – Fő téma színek.  
**2** – A fő téma színekből előállított világosabb és sötétebb variánsok.

Az alábbi példa hat téglalapot hoz létre `Accent4`‑ből kiindulva, ötötön luminancia‑transzformációt alkalmaz, majd elmenti az eredményt:

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

Ezek a variánsok továbbra is a téma színére épülnek. Ha később `Accent4` változik, a transzformált színek újra ki lesznek számolva az új `Accent4` értékből.

### **A `SchemeColor` értékek leképezése az `IColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg az [IColorScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icolorscheme/) a témapozíciókat `Dark1`, `Light1`, `Dark2` és `Light2` néven exponálja. A leképezés állandó:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon témapozíciók alternatív nevei; nem dinamikusan konvertált értékek.

## **Téma betűtípusainak módosítása**

A téma betűtípus‑sémája egy főbetűtípus‑készletet tartalmaz a címsorokhoz és egy kisebb betűtípus‑készletet a törzsszöveghez. A [IFontScheme.getMajor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontscheme/) és a [IFontScheme.getMinor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontscheme/) metódusok ezeket a készleteket exponálják.

A PowerPoint‑kompatibilis téma‑betűtípus azonosítók a szövegformázásban használhatók:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Az alábbi példa egy címsort hoz létre, amely a fő Latin betűtípust használja, valamint egy törzssort, amely a kisebb Latin betűtípust használja. Ezután módosítja a téma betűtípusait és elmenti az eredményt:

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

A címsor a fő betűtípust, a törzsszöveg a kisebb betűtípust követi. A kifejezetten betűtárnevet megadott szöveg nem vált automatikusan a téma‑betűtípus változásakor.

A fő és kisebb betűtípus‑gyűjtemények tartalmazhatnak betűtár‑leképezéseket egyedi írásrendszerekhez, például cirill, arab, japán, grúz és thaana. Ezeknek a leképezéseknek az ellenőrzéséhez, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script‑Specific Theme Fonts](/slides/hu/androidjava/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tipp" %}}
További információk a prezentációs betűtípusokról: [PowerPoint Fonts](/slides/hu/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Az alábbi munkafolyamatok különböző téma‑kapcsolódó problémákat oldanak meg.

### **Külső téma alkalmazása a master‑tól függő diákra**

Használd a [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslide/) metódust, ha van egy PowerPoint témafájlod (`.thmx`), és minden, egy adott master‑től függő diát újra szeretnél formázni. Válaszd ki a master‑t a [Presentation.getMasters](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) gyűjteményből, amely implementálja az [IMasterSlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslidecollection/) interfészt, majd add át a témafájl útvonalát a metódusnak.

A metódus a következő műveleteket hajtja végre:

1. Létrehoz egy új master‑diát a kiválasztott master alapján.
2. Alkalmazza a külső témát az új master‑ra.
3. Az új master‑t a korábban a kiválasztott master‑re hivatkozó összes diára hozzárendeli.
4. Visszaadja a frissen létrehozott [IMasterSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslide/) objektumot.

Az alábbi példa egy külső témát alkalmaz az első master‑től függő diákra, majd elmenti a prezentációt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Érvénytelen, sérült vagy nem támogatott téma esetén [PptxReadException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxreadexception/) keletkezhet. Érvényesítsd a felhasználók által megadott útvonalakat, kezeld a fájlrendszer‑hozzáférési hibákat, és csak akkor mentsd el a prezentációt, ha a téma sikeresen alkalmazva lett.

Csak a kiválasztott master‑től függő diák lesznek átállítva. Más master‑hez tartozó diák megőrzik meglévő master‑eiket és témáikat. A téma‑érzékeny színek, betűtípusok, kitöltések, vonalak, háttér és effektusok az új külső témához lesznek igazítva. A közvetlenül hozzárendelt színek, betűtípusok, kitöltések és egyéb explicit formázások változatlanok maradhatnak. Az elrendezés‑szintű és dia‑szintű felülírások felülbírálhatják az új master‑től örökölt értékeket.

A téma hivatkozhat olyan betűtípusokra, amelyek nem érhetők el a futtatási környezetben. A konzisztens renderelés és export érdekében telepítsd a szükséges betűtípusokat, szolgáltasd őket a [custom font sources](/slides/hu/androidjava/custom-font/) segítségével, vagy állíts be [font substitution](/slides/hu/androidjava/font-substitution/).

Ez egy közvetlen master‑szintű munkafolyamat: a metódus egy `.thmx` fájl elérési útvonalat vár, és nem igényel manuális dia‑ vagy elrendezés‑szintű téma‑felülírások létrehozását.

### **Különböző külső témák alkalmazása több‑masteres prezentációban**

Ha a megfelelő master előre nem ismert, szerezd meg egy reprezentatív dia segítségével a [ISlide.getLayoutSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/) és a [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/) metódusokkal. Tárold el az eredeti master‑hivatkozásokat a témák alkalmazása előtt, mivel minden hívás egy új master‑t hoz létre a prezentációban.

Az alábbi példa két szekció diáit használja a master‑ek megtalálásához, és különböző külső témát alkalmaz mindkét csoportra:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Az első hívás csak azoknak a diáknak a megjelenését változtatja, amelyek a `firstGroupMaster`‑re hivatkoznak, a második hívás csak a `secondGroupMaster`‑re hivatkozó diákra hat. Más master‑hez tartozó diákok nem lesznek újraformázva.

### **Forrástéma megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretnél áthelyezni, miközben az eredeti tervezést meg akarod őrizni, klónozd a forrás‑master‑t a cél‑prezentációba a [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslidecollection/) segítségével, majd az átmásolt master‑rel klónozd a diát a [ISlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/) metódussal. Ezzel a master, annak elrendezései és a hozzá tartozó téma is átkerül.

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

Ez a preferált munkafolyamat, ha a forrás‑diát ugyanúgy kell megjeleníteni a cél‑prezentációban. Ha csak a tartalmat klónozod egy nem kapcsolódó cél‑master‑re, akkor a téma‑alapú színek, betűtípusok, háttér és effektusok megváltozhatnak.

### **Témaértékek alkalmazása meglévő diára**

Ha a cél‑dia a jelenlegi master‑en és elrendezésen marad, inicializálj egy dia‑szintű felülírást a forrás‑témából. A [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/overridetheme/), a [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/overridetheme/) és a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/overridetheme/) metódusok a három fő témakomponenst másolják a felülírásba.

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

Ez a dia által használt témát módosítja anélkül, hogy a többi diára ható, örökölt témát megváltoztatná. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívd a [OverrideTheme.clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/overridetheme/) metódust.

### **Téma felülírás alkalmazása egy elrendezésre**

Az elrendezés‑szintű felülírás az arra épülő diákra vonatkozik, hacsak egy adott dia nem rendelkezik saját felülírással. Ugyanezeket a inicializáló metódusokat a [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/layoutslidethememanager/) segítségével is használhatod:

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

Használj master‑ vagy prezentáció‑szintű témát, ha sok elrendezésnek és diáknak kell ugyanazt az alaptervet megosztania, egy elrendezés‑felülírást, ha egy elrendezés‑családnak más stílusra van szüksége, és csak dia‑felülírást igénylő kivételes esetekben. A túlzott dia‑szintű felülírások megnehezítik a későbbi globális téma‑módosítások előrejelzését.

## **Téma háttérstílusok frissítése**

A téma háttérkitöltései a [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iformatscheme/) metódusban tárolódnak. A PowerPoint a felhasználói felületén több háttérválasztást mutathat, mint ahány kitöltés‑definíció ténylegesen szerepel a gyűjteményben, mivel a UI kombinálhat téma‑kitöltéseket téma‑színekkel és egyéb stílus‑hivatkozásokkal.

![PowerPoint háttérstílus galéria egy prezentációs témához](presentation-design_8.png)

Mielőtt háttérstílust használnál, ellenőrizd a tárolt gyűjmentet és a jelenlegi [Background.getStyleIndex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/background/) értéket. A `0`‑s index azt jelenti, hogy nincs téma‑kitöltés; a pozitív értékek téma‑háttér‑stílus‑hivatkozások. Ez eltér attól, amikor a Java‑gyűjteményt közvetlenül indexeljük, ahol a `get_Item(0)` az első tárolt elemet jelenti. Ne feltételezd, hogy minden prezentáció ugyanannyi háttérkitöltési stílussal rendelkezik.

Az alábbi példa kiírja a rendelkezésre álló háttérkitöltések számát, egy téma‑háttér‑hivatkozást ad az első master‑nek, majd elmenti a prezentációt:

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

A látható eredmény a master‑által hivatkozott téma‑bejegyzéstől és az elrendezés‑ vagy dia‑szintű háttér‑felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, a csak a master‑háttér módosítása nem feltétlenül változtatja meg azt a diát. Használd a [Background.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/background/) metódust, ha a végső, öröklődés után kapott háttérre van szükséged.

{{% alert color="warning" title="Figyelmeztetés" %}}
Ne kezeld a stílus‑indexet null‑alapú gyűjtemény‑indexnek. Kerüld el azt is, hogy egy fájlból kimásolt stílus‑számot egy másik fájlban ugyanolyanként feltételezz; a téma‑stílusdefiníciók prezentációnként eltérnek.
{{% /alert %}}

{{% alert color="info" title="Tipp" %}}
A közvetlen háttér‑formázáshoz és a háttér‑öröklődéshez lásd a [Presentation Background](/slides/hu/androidjava/presentation-background/) oldalt.
{{% /alert %}}

## **Téma effektusok frissítése**

A téma formátumsémája különálló kitöltés‑, vonal‑ és effektusstílus‑gyűjteményeket tartalmaz, amelyeket a [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iformatscheme/), a [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iformatscheme/) és a [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iformatscheme/) metódusok tesznek elérhetővé. A tipikus Office‑témák gyakran három fő stílusból állnak, amelyek vizuálisan a finom, közepes és intenzív formázást képviselik, de a kódnak minden gyűjteményt ellenőriznie kell, ahelyett, hogy egy fix számot feltételezne.

![Finom, közepes és intenzív téma‑effektusok ugyanazon alakzatra alkalmazva](presentation-design_10.png)

Java‑ban ezeknek a gyűjteményeknek az indexelése null‑alapú: a `get_Item(0)` az első tárolt stílust, a `get_Item(2)` a harmadikat adja. A shape‑ok stílus‑referencia‑indexei egy külön fogalom, amelyet az [IShapeStyle](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapestyle/) exponál. Egy téma‑stílus módosítása azokra a shape‑okra hat, amelyek arra a téma‑stílusra hivatkoznak; a közvetlen formázással rendelkező shape‑ok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek, módosítja az első vonal‑stílust, a harmadik kitöltés‑stílust, valamint a harmadik effektus‑stílusban engedélyezi a külső árnyékot, majd elmenti az eredményt:

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

Az ezen slotokra hivatkozó shape‑ok esetében az első téma‑vonal‑stílus pirosra, a harmadik téma‑kitöltés‑stílus szilárd erdőzöldre, a harmadik effektus‑stílus pedig egy 10 pont távolságú külső árnyékra változik. A pontos vizuális eredmény továbbra is attól függ, hogy melyik slotra hivatkozik egy shape, és hogy a közvetlen formázás felülírja‑e a témát.

![Téma‑effektus‑stílusok módosítás után: vonal, kitöltés és árnyék](presentation-design_11.png)

## **Téma tényleges értékeinek kiolvasása**

A nyers témaobjektumok azt mutatják, hogy mi van definiálva egy adott szinten. A tényleges (effective) értékek azt mutatják, hogy egy dia vagy shape valójában mit használ az öröklődés és a helyi felülírások feloldása után. Diai esetén hívd a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseoverridethememanager/) metódust. Háttérhez használd a [Background.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/background/), kitöltéshez pedig a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/) metódust.

Az alábbi példa kiolvassa a dia tényleges témáját, háttérét és az első shape kitöltését:

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

Használd a tényleges adatokat renderelési diagnosztikához, validációhoz és összehasonlításokhoz. Ha csak a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/)‑et ellenőrzöd, előfordulhat, hogy egy master, elrendezés, dia vagy shape felülírása elkerüli a figyelmedet, és megváltoztatja a végső megjelenést.

## **GYIK**

**Az külső téma alkalmazása minden diára kihat?**

Nem. A [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslide/) csak azokat a diákat rendeli újra, amelyek a kiválasztott master‑től függenek. A másik master‑t használó diák megtartják meglévő témájukat.

**Alkalmazhatok‑e témát egyetlen diára anélkül, hogy a master‑t módosítanám?**

Igen. Használd a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidethememanager/)‑ét, és inicializáld a felülírási témát. A változtatás csak azon a dián marad helyi; a többi dia a meglévő témáját örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének egy prezentációból a másikba?**

Ha egy diákat áthelyezel és meg akarod őrizni a forrási megjelenést, klónozd a forrás‑master‑t a cél‑prezentációba, majd a diát a klónozott master‑rel a [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslidecollection/) és a [ISlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/) segítségével. Így a master, az elrendezések és a téma együtt marad.

**Hogyan tekinthetem meg a tényleges értékeket az öröklődés és felülírások után?**

Használd a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseoverridethememanager/)‑t egy dia vagy elrendezés témához, valamint a megfelelő effektív‑adat metódusokat a formátumobjektumokhoz, például a [Background.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/background/) és a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/) esetén. Ezek az API‑k a öröklődés és a felülírások után feloldott értékeket adják vissza.