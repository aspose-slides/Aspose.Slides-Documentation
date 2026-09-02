---
title: Java-ban a prezentációs témák kezelése
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
- külső téma
- THMX
- téma szín
- kiegészítő paletta
- téma betűtípus
- téma stílus
- téma effekt
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Mester prezentációs témák az Aspose.Slides for Java-ban, a PowerPoint fájlok egységes márkajelzésével való létrehozásához, testreszabásához és konvertálásához."
---
## **Bevezetés**

A prezentációs téma egy összehangolt szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektus‑készletet határoz meg. A téma‑tudatos objektumok ezekre a megosztott definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékkel tárolnának, így a téma módosítása egyszerre sok objektumot frissíthet.

Az Aspose.Slides‑ben a prezentációszintű témához a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) biztosít hozzáférést. A prezentáció alacsonyabb szinteken is tartalmazhat téma‑felülírásokat. Egy master felülírhatja a prezentáció témáját a [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/masterthememanager/) segítségével, míg egy elrendezés vagy egy adott dia felülírhatja a neki örökölt témát a [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseoverridethememanager/) segítségével. Gyakorlatilag egy dia effektív témája az alábbi öröklődési lánc mentén határozódik meg: prezentációs téma → master‑felülírás → elrendezés‑felülírás → dia‑felülírás.

![Témaelemek: színek, betűtípusok, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma‑munkafolyamatokat mutatják be: téma ellenőrzése, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér‑ és effektus‑stílusok frissítése, valamint az öröklődés és felülírások feloldása után kapott értékek kiolvasása.

## **Téma ellenőrzése**

A [MasterTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mastertheme/) objektum a téma színsémáját, betűtípus‑sémáját és formátumsémáját a [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mastertheme/), a [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mastertheme/) és a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mastertheme/) segítségével teszi elérhetővé. Ezeknek a gyűjteményeknek a vizsgálata a módosítás előtt különösen hasznos, ha a prezentáció külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

Az alábbi példa beolvassa a fő téma‑tulajdonságokat és jelentést készít arról, hogy hány háttér‑, kitöltés‑, vonal‑ és effektus‑stílus tárolódik a témában:

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

Ha egy fájl több mestert (master‑t) használ, ne tételezzük fel, hogy minden dia ugyanazzal a hatékony témával rendelkezik. Ellenőrizzük a diához tartozó master‑t, és használjuk a később ebben a cikkben bemutatott hatékony‑téma munkafolyamatot, ha elrendezés‑ vagy dia‑felülírások létezhetnek.

## **Téma színeinek módosítása**

A téma‑tudatos kitöltések, vonalak és szövegek a [SchemeColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/schemecolor/) felsorolásbeli logikai színre hivatkozhatnak. Ha a megfelelő bejegyzést a [IColorScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icolorscheme/) gyűjteményében módosítjuk, minden olyan objektum, amely még mindig arra a témaszínre hivatkozik, az új értékkel lesz feloldva. Az RGB‑színnel közvetlenül megadott objektumok nem változnak a téma‑szín frissítésekor.

Az alábbi vég‑től‑végig példakód egy „Accent4” színű alakzatot hoz létre, megváltoztatja a téma „Accent4” színét pirosra, elmenti a prezentációt, újra megnyitja, és kiírja a hatékony kitöltőszínt:

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

Mivel a téglalap továbbra is a „Accent4” színre hivatkozik, látható színe piros lesz a téma módosítása után. Ha a téma‑színt közvetlen színre cseréljük az alakzaton, a későbbi „Accent4” változtatások már nem befolyásolják azt a kitöltést.

### **Kiegészítő palettáról színek használata**

A PowerPoint a téma‑színekből világosabb és sötétebb változatokat hoz létre színátalakítások alkalmazásával. Az Aspose.Slides ezeket az átalakításokat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/colortransformoperation/) felsorolással teszi elérhetővé.

![Fő téma‑színek és a kiegészítő palettából előállított világosabb és sötétebb színek](additional-palette-colors.png)

**1** – Fő téma‑színek.  
**2** – A fő téma‑színekből előállított világosabb és sötétebb változatok.

Az alábbi példa hat téglalapot hoz létre az „Accent4” szín alapján, ötön alkalmazva luminancia‑átalakítást, majd elmenti az eredményt:

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

Ezek a változatok továbbra is a téma‑színen alapulnak. Ha később az „Accent4” változik, az átalakított színek az új „Accent4” értékből lesznek újraszámolva.

### **A `SchemeColor` értékek leképezése az `IColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg az [IColorScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icolorscheme/) a témaboltokat `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi közzé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon téma‑helyek alternatív nevei; nem dinamikusan átalakított értékek.

## **Téma betűtípusainak módosítása**

A téma betűtípus‑sémája egy fő betűkészletet tartalmaz a címsorokhoz és egy mellékbetűkészletet a törzsszöveghez. A [IFontScheme.getMajor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontscheme/) és a [IFontScheme.getMinor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontscheme/) metódusok ezeket a készleteket exponálják.

PowerPoint‑kompatibilis téma‑betűtípus‑azonosítók használhatók a szövegformázásban:

* `+mn-lt` – Body Font Latin (kisebb latin betűkészlet)
* `+mj-lt` – Heading Font Latin (nagy latin betűkészlet)
* `+mn-ea` – Body Font East Asian (kisebb kelet‑ázsiai betűkészlet)
* `+mj-ea` – Heading Font East Asian (nagy kelet‑ázsiai betűkészlet)

Az alábbi példa egy címsort hoz létre, ami a fő latin téma‑betűtípust használ, és egy törzssort, ami a kisebb latin téma‑betűtípust használ. Ezután módosítja a téma betűtípusait és elmenti az eredményt:

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

A címsor a fő betűtípust, a törzsszöveg a kisebb betűtípust követi. Azon szöveg, amelynek explicit betűtípus‑neve van a téma‑azonosító helyett, nem vált automatikusan a téma‑betűtípus‑séma változásakor.

A fő és a kisebb betűkészlet tartalmazhat betűtérképét is egyes írásrendszerekhez, például cirill, arab, japán, grúz és thaana. Ezek vizsgálatához, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script‑Specific Theme Fonts](/slides/hu/java/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tippek" %}}
További információ a prezentáció‑betűtípusokról a [PowerPoint Fonts](/slides/hu/java/powerpoint-fonts/) oldalon található.
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Az alábbi munkafolyamatok különböző téma‑kapcsolatos problémákat oldanak meg.

### **Külső téma alkalmazása a master‑függő diákra**

Használd a [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslide/) metódust, ha van egy PowerPoint téma‑fájl (`.thmx`) és minden, egy adott master‑től függő diát újra kell stílusozni. Válaszd ki a master‑t a [Presentation.getMasters](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) gyűjteményből, amely az [IMasterSlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslidecollection/) interfészt implementálja, majd add át a téma‑fájl elérési útját a metódusnak.

A metódus a következő műveleteket hajtja végre:

1. Létrehozza az új master‑diát a kiválasztott master alapján.  
2. Alkalmazza a külső témát az új master‑re.  
3. Az új master‑t hozzárendeli minden diához, amely korábban a kiválasztott master‑től függött.  
4. Visszaadja az újonnan létrehozott [IMasterSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslide/)-t.

Az alábbi példa külső témát alkalmaz az első master‑től függő diákra, majd elmenti a prezentációt:

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

Érvénytelen, sérült vagy nem támogatott téma [PptxReadException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxreadexception/)-et válthat ki. Ellenőrizd a felhasználók által megadott útvonalakat, kezeld a fájlrendszer‑hozzáférési hibákat, és csak a téma sikeres alkalmazása után mentsd a prezentációt.

Csak a kiválasztott master‑től függő diák kerülnek átállításra. A többi master‑hez tartozó diák megtartja meglévő master‑ét és témáját. A téma‑tudatos színek, betűtípusok, kitöltések, vonalak, háttér‑ és effektus‑stílusok az új témához lesznek feloldva. A közvetlenül hozzárendelt színek, betűtípusok, kitöltések és egyéb explicit formázások változatlanok maradhatnak. Az elrendezés‑szintű és dia‑szintű felülírások szintén előnyt élvezhetnek az új master‑ből örökölt értékekkel szemben.

A téma olyan betűtípusokra is hivatkozhat, amelyek nincsenek telepítve a futtatási környezetben. A következetes megjelenítés és export érdekében telepítsd a szükséges betűtípusokat, vagy biztosítsd őket [egyéni betűtípus‑források](/slides/hu/java/custom-font/) segítségével, illetve konfiguráld a [betűtípus‑helyettesítést](/slides/hu/java/font-substitution/).

Ez egy közvetlen master‑szintű munkafolyamat: a metódus egy `.thmx` fájl elérési útját várja, és nem igényel manuális dia‑ vagy elrendezés‑szintű téma‑felülírások létrehozását.

### **Különböző külső témák alkalmazása több‑masteres prezentációban**

Ha a megfelelő master előre nem ismert, szerezd be egy reprezentatív dia alapján a [ISlide.getLayoutSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/) és a [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslide/) segítségével. A témák alkalmazása előtt tárold az eredeti master‑referenciákat, mivel minden hívás egy új master‑t hoz létre a prezentációban.

Az alábbi példa két szekcióból származó diák segítségével meghatározza a master‑eket, majd mindegyik csoportnak külön külső témát alkalmaz:

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

Az első hívás csak a `firstGroupMaster`‑től függő diákra hat, a második hívás csak a `secondGroupMaster`‑től függő diákra. A többi master‑hez tartozó diákok nem változnak.

### **Forrástéma megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretnél áthelyezni, és az eredeti megjelenést megőrizni, klónozd a forrás‑master‑t a cél‑prezentációba a [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslidecollection/) segítségével, majd klónozd a diát a [ISlideCollection.addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidecollection/) és a klónozott master segítségével. Így a master, az elrendezései és a hozzá tartozó téma együtt kerülnek átvitelre.

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

Ez a preferált megközelítés, amikor a forrás‑dia megjelenésének pontosan ugyanolyonnak kell lennie a cél‑prezentációban. Ha csak a tartalmat klónozod egy nem kapcsolódó cél‑master‑re, a téma‑alapú színek, betűtípusok, háttér‑ és effektus‑stílusok megváltozhatnak.

### **Témaértékek alkalmazása meglévő diára**

Ha a cél‑dia a saját master‑én és elrendezésén marad, inicializálj egy dia‑szintű felülírást a forrás‑téma alapján. Az [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/overridetheme/), az [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/overridetheme/) és az [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/overridetheme/) metódusok a három fő téma‑komponenst másolják az felülírásba.

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

Ez a dia által használt témát módosítja anélkül, hogy a többi dia által örökölt témát változtatná. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívd meg az [OverrideTheme.clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/overridetheme/) metódust.

### **Téma felülírás alkalmazása elrendezésre**

Az elrendezés‑szintű felülírás az adott elrendezést használó diákra vonatkozik, hacsak egy konkrét diának saját felülírása nincs. Ugyanezen inicializáló metódusok használhatók a [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/layoutslidethememanager/) segítségével:

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

Használj master‑ vagy prezentáció‑szintű témát, ha sok elrendezésnek és diáknak ugyanazt az alaptervet kell megosztania, elrendezés‑felülírást, ha egy elrendezés‑családnak más stílusra van szüksége, és dia‑felülírást csak valódi kivételek esetén. A túlzott dia‑szintű felülírások megnehezítik a későbbi globális téma‑változtatások előrejelzését.

## **Téma háttér‑stílusok frissítése**

A téma háttér‑kitöltései a [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iformatscheme/) gyűjteményben tárolódnak. A PowerPoint a felhasználói felületen több háttér‑választást is megjeleníthet, mint amennyi kitöltés‑definíció fizikailag tárolódik ebben a gyűjteményben, mivel a UI kombinálhat téma‑kitöltéseket téma‑színekkel és egyéb stílushivatkozásokkal.

![PowerPoint háttér‑stílus galéria egy prezentáció‑témához](presentation-design_8.png)

Mielőtt háttér‑stílust használnál, ellenőrizd a tárolt gyűjteményt és a jelenlegi [Background.getStyleIndex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/background/) értékét. A `0`‑beli index azt jelenti, hogy nincs téma‑kitöltés; a pozitív értékek téma háttér‑stílus‑referenciák. Ez eltér az indexeléstől a Java‑gyűjteményben, ahol a `get_Item(0)` az első tárolt elemet jelenti. Ne tételezd fel, hogy minden prezentáció ugyanannyi háttér‑kitöltés‑stílussal rendelkezik.

Az alábbi példa a rendelkezésre álló háttér‑kitöltések számát jelenti, a első master‑nek téma‑háttér‑referenciát ad, majd elmenti a prezentációt:

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

A látható eredmény a master‑által hivatkozott téma‑bejegyzéstől, valamint az elrendezés‑ vagy dia‑szintű háttér‑felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, a master‑háttér változtatása nem feltétlenül befolyásolja azt a diát. Használd a [Background.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/background/)‑t, ha a teljes háttérre kell tudnod a öröklődés után.

{{% alert color="warning" title="Figyelmeztetés" %}}
Ne kezeld az indexet null‑alapú gyűjtemény‑indexként. Kerüld a stílusszám hard‑kódolását egy fájlból, és annak feltételezését, hogy egy másik fájlban ugyanazt a megjelenést adja; a téma‑stílusdefiníciók prezentációnként eltérnek.
{{% /alert %}}

{{% alert color="info" title="Tippek" %}}
A közvetlen háttér‑formázás és a háttér‑öröklődés részletei a [Presentation Background](/slides/hu/java/presentation-background/) oldalon olvashatók.
{{% /alert %}}

## **Téma effektek frissítése**

A téma formátumsémája külön kitöltés‑, vonal‑ és effektus‑stílus‑gyűjteményeket tartalmaz, amelyeket a [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iformatscheme/), a [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iformatscheme/) és a [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iformatscheme/) metódusok tesznek elérhetővé. A tipikus Office‑témák gyakran három fő stílus‑bejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell, ahelyett, hogy rögzített számra támaszkodna.

![Finom, közepes és intenzív téma‑effektek ugyanarra az alakzatra alkalmazva](presentation-design_10.png)

Java‑ban ezeknek a gyűjteményeknek az indexelése null‑alapú: a `get_Item(0)` az első tárolt stílust, a `get_Item(2)` a harmadikat adja vissza. Az alakzatok stílus‑referenciájának indexei egy külön koncepció, amelyet az [IShapeStyle](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapestyle/) exponál. Egy téma‑stílus módosítása azokra az alakzatokra hat, amelyek arra a téma‑stílusra hivatkoznak; a közvetlen formázással rendelkező alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílus‑bejegyzések léteznek-e, megváltoztatja az első vonal‑stílust, a harmadik kitöltés‑stílust, a harmadik effektus‑stílusban engedélyezi a külső árnyékot, majd elmenti az eredményt:

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

A hivatkozott slotokat használó alakzatok esetén az első téma‑vonal‑stílus pirosra, a harmadik téma‑kitöltés‑stílus szilárd erdőzöldre, a harmadik effektus‑stílus pedig egy 10 pont távolságú külső árnyékra változik. A pontos vizuális eredmény továbbra is attól függ, hogy melyik slotra hivatkozik az adott alakzat, illetve hogy a közvetlen formázás felülírja-e a témát.

![Téma‑effektus‑stílusok a vonal, kitöltés és árnyék beállításainak módosítása után](presentation-design_11.png)

## **Annak meghatározása, hogy egy effektív szilárd kitöltés téma‑színt használ-e**

Egy kitöltés lehet közvetlenül egy objektumon tárolva vagy örökölve bekezdés‑, elrendezés‑, master‑, téma‑stílus‑ vagy más formázási szintből. Hívjuk a [IFillFormat.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifillformat/) metódust, hogy a hierarchiát egy változtathatatlan [IFillFormatEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifillformateffectivedata/) objektummá alakítsa. Először ellenőrizd a [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifillformateffectivedata/) értékét. Csak ha `FillType.Solid`, olvasd ki a szilárd‑kitöltés tulajdonságait.

Szilárd kitöltés esetén a [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifillformateffectivedata/) visszaadja a végső renderelt RGB‑értéket az öröklődés, téma‑keresés és színátalakítások után. A [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifillformateffectivedata/) a megfelelő logikai [SchemeColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/schemecolor/) slotot adja vissza, például `Text1` vagy `Accent6`. A `SchemeColor.NotDefined` érték azt jelenti, hogy a hatékony szilárd kitöltés nem egy séma‑színen alapul. Egy olyan munkafolyamatban, ahol a kitöltések vagy téma‑színek, vagy közvetlen RGB‑színek, ez az érték egy közvetlen RGB‑kitöltést jelez.

Ne csak a helyi [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icolorformat/) értéket használd a kitöltés besorolásához. Például egy szövegrésznek lehet helyileg nincs séma‑színe (`NotDefined`), míg a hatékony kitöltése örököl egy téma‑színt, amely `Text1` vagy `Accent6` lesz. Ezzel szemben a `getSolidFillSchemeColor` megmondja, melyik logikai téma‑slot hozta létre a hatékony színt, de nem jelzi, hogy ez a slot az objektumból, bekezdésből, elrendezésből, master‑ből vagy egy másik szintből származik.

Az alábbi példa betölti egy prezentációt, ellenőrzi a forma‑ és szövegrész‑kitöltéseket, kiírja minden végső RGB‑értéket és a hozzá tartozó séma‑színt, valamint megjelöli azokat a szilárd kitöltéseket, amelyek nem követik a téma‑szín változásait:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    Color rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, rgb.getRed(), rgb.getGreen(), rgb.getBlue());
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

A `NotDefined` ág egy audit‑listát biztosít a szilárd kitöltésekről, amelyek nem reagálnak a téma‑szín‑slotok változására. Ezeket az objektumokat ellenőrizd, ha egy prezentációnak új márkaszínpalettát kell követnie. A jelentett RGB‑érték továbbra is a jelenlegi megjelenést mutatja, míg a séma‑érték magyarázatot ad arra, hogy a megjelenés kapcsolatban áll‑e a témával.

Az effektív‑formátum objektumok pillanatfelvételek. A prezentáció témájának, egy téma‑felülírásnak vagy bármely öröklődő formázásnak a módosítása után hívd újra a `getEffective`‑et, és olvasd ki az új `IFillFormatEffectiveData` objektumot, mielőtt összehasonlítanád vagy jelentened a színeket.

## **Hatékony témaértékek kiolvasása**

A nyers témaobjektumok azt mutatják, hogy mi van egy adott szinten definiálva. A hatékony értékek azt mutatják, hogy egy dia vagy alakzat valójában mit használ az öröklődés és a helyi felülírások feloldása után. Egy dia esetén hívd a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseoverridethememanager/)‑t. Háttérhez használd a [Background.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/background/), kitöltéshez pedig a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/)-t.

Az alábbi példa kiolvassa a hatékony témát, a háttér‑stílust és az első forma‑kitöltést egy diához:

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

Használd a hatékony adatokat renderelés‑diagnosztikához, ellenőrzéshez és összehasonlításhoz. Ha csak a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/)‑t vizsgálod, lemaradhatsz egy master, elrendezés, dia vagy forma felülírásáról, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Befolyásolja-e egy külső téma alkalmazása az összes diát a prezentációban?**

Nem. Az [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslide/) csak azokat a diákot rendeli újra, amelyek a kiválasztott master‑től függnek. A más master‑t használó diák megtartják meglévő témájukat.

**Alkalmazhatok‑e témát egyetlen diára a master módosítása nélkül?**

Igen. Használd a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slidethememanager/)‑t, és inicializáld a felülírási témát. A módosítás csak arra a diára vonatkozik; a többi dia a meglévő témáit örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének egy prezentációból a másikba?**

Dia áthelyezésekor és a forrás‑megjelenés megőrzésekor klónozd a forrás‑master‑t a cél‑prezentációba, majd a diát is a [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslidecollection/) és a [ISlideCollection.addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidecollection/) segítségével. Így a master, az elrendezések és a téma együtt marad.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és felülírások után?**

Használd a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseoverridethememanager/)‑t egy dia vagy elrendezés téma esetén, valamint a megfelelő hatékony‑adat metódusokat formátumobjektumokhoz, például a [Background.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/background/) és a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/) hívásokat. Ezek az API‑k a öröklődés és felülírások után feloldott értékeket adják vissza.