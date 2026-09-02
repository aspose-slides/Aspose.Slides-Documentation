---
title: Alkalmazzon vagy módosítson diaelrendezéseket JavaScript-ben
linktitle: Diaelrendezés
type: docs
weight: 60
url: /hu/nodejs-java/slide-layout/
keywords:
- diaelrendezés
- tartalomelrendezés
- helykitöltő
- bemutatótervezés
- dia tervezés
- nem használt elrendezés
- lábléc láthatóság
- cím dia
- cím és tartalom
- szakaszfejléc
- két tartalom
- összehasonlítás
- csak cím
- üres elrendezés
- tartalom felirattal
- kép felirattal
- cím és függőleges szöveg
- függőleges cím és szöveg
- PowerPoint
- OpenDocument
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Alkalmazzon, hozzon létre és módosítson diaelrendezéseket az Aspose.Slides for Node.js segítségével JavaScript-ben, adjon hozzá helykitöltőket, távolítson el nem használt elrendezéseket, és szabályozza a lábléc láthatóságát."
---
## **Áttekintés**

A diavetítés elrendezése meghatározza a helykitöltők, például címek, szöveg, képek, diagramok és táblázatok pozícióját és formázását. Egy elrendezés alkalmazásával a diák egységes szerkezetet kapnak, miközben minden dia saját tartalmát tartalmazhatja.

A leggyakoribb elrendezések a következők:

- **Cím Dia**: Cím és alcím helykitöltőket tartalmaz.
- **Cím és Tartalom**: Cím helykitöltőt és egy általános célú tartalomhelykitöltőt tartalmaz.
- **Üres**: Nem tartalmaz tartalomhelykitöltőket, és akkor hasznos, ha minden alakzatot kézzel helyeznek el.

## **Az Elrendezés Öröklődésének Megértése**

Egy bemutató három összefüggő szinttel rendelkezik:

1. A [master dia](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/) meghatározza a témát, a megosztott formázást, a háttereket és a közös objektumokat.
1. A [layout dia](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/) egy masterhez tartozik, és meghatároz egy adott helykitöltő elrendezést.
1. A [normál dia](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/) egy elrendezést használ, és tárolja az adott dia számára beírt tartalmat.

A normál dia örökli a témát és a formázást az elrendezéséből, az elrendezés pedig a masterből örököl. A normál dián közvetlenül beállított érték felülírja az örökölt értéket ezen a szinten. Amikor egy normál diát létrehoznak, a helykitöltő alakzatok a kiválasztott elrendezésből generálódnak, míg a helykitöltőkbe beírt tartalom a normál diához tartozik.

Adjunk hozzá szükséges helykitöltőket egy elrendezéshez, mielőtt diák létrehozására használnánk. Ha később egy másik helykitöltőt adunk egy elrendezéshez, az nem adja hozzá automatikusan a megfelelő helykitöltő alakzatot a már létező normál diákhoz.

Ennek a kapcsolatnak két fontos következménye van:

- Az örökölt formázás vagy a meglévő helykitöltő geometria módosítása egy elrendezésen minden, attól függő diát frissíthet. Mielőtt egy már használt elrendezést szerkesztenénk, nézzük át a függő diákat, és ellenőrizzük a keletkezett bemutatót.
- Egy elrendezést, amelyet még diák használnak, nem lehet eltávolítani. Először rendeljük át a függő diákat egy másik elrendezésre, vagy csak a nem használt elrendezéseket távolítsuk el.

További információkért a hierarchia legfelső szintjéről lásd a [Dia Mester](/slides/hu/nodejs-java/slide-master/) oldalt.

## **Elrendezés Kiválasztása és Alkalmazása**

Használjon egy [SlideLayoutType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidelayouttype/) értéket, amikor a bemutató a standard PowerPoint elrendezésdefiníciókat követi. Az elrendezés nevei felhasználó által szerkeszthetők és lokalizálhatók, ezért a névre alapozott kiválasztás kevésbé megbízható, hacsak nem irányítja a forrás sablont.

A következő példa a **Cím és Tartalom** elrendezést keresi az első masterben. Ha ez az elrendezés nem érhető el, szándékosan az **Üres** elrendezésre tér vissza. A második null ellenőrzés szükséges, mert egy bemutató csak egyedi elrendezéseket tartalmazhat. A kiválasztott elrendezést ezután a [Slide.setLayoutSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#setLayoutSlide) metódussal alkalmazzák az első normál diára.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Egy dia elrendezésének módosítása nem távolítja el a diára közvetlenül hozzáadott szokásos alakzatokat. Azonban a helykitöltő pozíciók, az örökölt formázás és a meglévő helykitöltők és az új elrendezés közti megfelelés változhat, ezért ellenőrizze a kimenetet, ha jelentősen eltérő elrendezések között vált.

## **Elrendezés Dia Hozzáadása**

A kiválasztás és a létrehozás külön műveletek. Az előző példa egy meglévő elrendezést választ ki; nem hoz létre újat. Egy elrendezés létrehozásához hívja meg a [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) metódust a cél master elrendezésgyűjteményén.

A következő példa mindig hozzáad egy új **Cím és Tartalom** elrendezést `Report Title and Content` névvel, majd hozzáad egy normál diát, amely azt használja. Az elrendezésneveknek egyedieknek kell lenniük a gyűjteményen belül.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Csak akkor adjon hozzá egy elrendezést, ha a sablon valóban igényel egy további újrahasználható struktúrát. Ha már létezik megfelelő elrendezés, válassza ki és használja újra a duplikálás helyett.

## **Helykitöltők Hozzáadása egy Elrendezés Diához**

A [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) metódus egy [LayoutPlaceholderManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/) objektumot biztosít a helykitöltő alakzatok elrendezéshez történő hozzáadásához.

| PowerPoint Helykitöltő | `LayoutPlaceholderManager` Metódus |
| ----------------------- | ---------------------------------- |
| ![Tartalom](content.png) | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Tartalom (Függőleges)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Szöveg](text.png) | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Szöveg (Függőleges)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Kép](picture.png) | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Diagram](chart.png) | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Táblázat](table.png) | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Média](media.png) | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Kép](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

A következő példa ellenőrzi, hogy a **Üres** elrendezés létezik, négy helykitöltőt ad hozzá, majd létrehoz egy normál diát, amely a módosított elrendezést használja. A sorrend szándékos: a helykitöltőket a normál dia létrehozása előtt adják hozzá, így az Aspose.Slides a megfelelő helykitöltő alakzatokat generálja azon a dián.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A helykitöltők az elrendezés dián](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Az örökölt formázás vagy a meglévő elrendezés helykitöltőinek geometriai módosítása befolyásolhatja a függő diákat. Az újonnan hozzáadott elrendezéshelykitöltő nem töltődik be a már létező normál diákba. Tesztelje az elrendezés változásait a bemutató egy másolatán, és ellenőrizze minden függő diát.
{{% /alert %}}

## **Használatonkívüli Elrendezés Diák Eltávolítása**

Használja a [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) metódust a olyan elrendezések eltávolításához, amelyeket egy normál dia sem hivatkozik. A metódus érintetlenül hagyja azokat az elrendezéseket, amelyek még használatban vannak.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Egy adott elrendezés eltávolításához először használja a [hasDependingSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) vagy a [getDependingSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) metódust. A [LayoutSlide.remove](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/#remove) meghívása előtt rendelje át a függő diákat. Egy használt elrendezés eltávolításának kísérlete [PptxEditException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxeditexception/) kivételt eredményez.

## **Lábléc Láthatóságának Szabályozása egy Elrendezés Dián**

Egy elrendezésnek saját lábléca, diaszáma és dátum-idő helykitöltői vannak. Használja a [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) metódust ezeknek a helykitöltőknek a szabályozására egy adott elrendezésnél. Ez akkor hasznos, ha például a tartalom elrendezéseknek láblécet kell mutatniuk, míg a címelrendezéseknek nem.

A következő példa biztonságosan kiválaszt egy elrendezést, és láthatóvá teszi annak lábléc elemeit:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lábléc Láthatóságának Szabályozása a Masteren és Gyermek Elrendezésein**

Az egységes lábléc beállítások alkalmazásához egy master hierarchián belül használja a [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager) metódust. A [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslideheaderfootermanager/) terjesztési metódusai a masteren, annak függő elrendezés diáikon és normál diákon működnek; nem egyetlen normál diára céloznak.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Mi a különbség a Master dia és az Elrendezés dia között?**

A master dia meghatározza a bemutató témáját és a megosztott formázást. Egy elrendezés dia a masterhez tartozik, és egy újrahasználható helykitöltő elrendezést definiál. A normál diák ezeket az elrendezéseket használják, és tárolják a diához specifikus tartalmat.

**Másolhatok egy Elrendezés Diát egyik bemutatóból a másikba?**

Igen. Egy másolatot adjon hozzá a célgyűjteményhez a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone) metódussal. Bemutatók közti másoláskor ellenőrizze a betűtípusokat, témákat, képeket és egyéb a forrás elrendezés által használt erőforrásokat.

**Mi történik, ha módosítok egy már használatban lévő elrendezést?**

A függő diák öröklik az elrendezés változásait, hacsak lokálisan felül nem írták az érintett formázást vagy objektumokat. Így a helykitöltő geometria és az örökölt stílus egyszerre sok dián változhat. Használja a [getDependingSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) metódust a érintett diák azonosításához, mielőtt az elrendezést szerkesztené.

**Mi történik, ha egy még használatban lévő elrendezést eltávolítok?**

Az Aspose.Slides egy [PptxEditException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxeditexception/) kivételt dob. Először rendelje át a függő diákat, vagy használja a [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) metódust, hogy csak a nem hivatkozott elrendezéseket távolítsa el.