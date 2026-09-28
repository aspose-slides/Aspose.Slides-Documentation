---
title: "Diaelrendezések alkalmazása vagy módosítása JavaScriptben"
linktitle: "Diaelrendezés"
type: docs
weight: 60
url: /hu/nodejs-java/slide-layout/
keywords:
- diaelrendezés
- tartalomelrendezés
- helyőrző
- bemutató tervezés
- dia tervezés
- használaton kívüli elrendezés
- lábléc láthatóság
- címdia
- cím és tartalom
- szekciófejléc
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
description: "Alkalmazza, hozza létre és módosítsa a diaelrendezéseket az Aspose.Slides for Node.js Java-es változatában, adjon hozzá helyőrzőket, távolítson el használaton kívüli elrendezéseket, és vezérelje a lábléc láthatóságát."
---
## **Áttekintés**

A diaelrendezés meghatározza a helyőrzők (például címek, szöveg, képek, diagramok és táblázatok) helyét és formázását. Egy elrendezés alkalmazása konzisztens felépítést ad a diáknak, miközben minden dia saját tartalmát tartalmazhatja.

A leggyakoribb elrendezések a következők:

- **Címdia**: Cím és alcím helyőrzőket tartalmaz.
- **Cím és Tartalom**: Egy címhelyőrzőt és egy általános célú tartalomhelyőrzőt tartalmaz.
- **Üres**: Nem tartalmaz tartalomhelyőrzőket, és hasznos, ha minden alakzatot kézzel pozicionálunk.

## **Az elrendezés öröklődésének megértése**

Egy bemutatónak három kapcsolódó szintje van:

1. A [mester dia](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/) meghatározza a témát, a megosztott formázást, a hátteret és a közös elemeket.
1. A [elrendezés dia](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/) egy mesterhez tartozik, és meghatároz egy adott helyőrző-elosztást.
1. A [normál dia](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/) egy elrendezést használ, és tárolja a dia számára megadott tartalmat.

Egy normál dia az elrendezésétől örökli a témát és a formázást, az elrendezés pedig a mesterétől örököl. Egy normál dián közvetlenül beállított érték felülírja az örökölt értéket azon a szinten. Amikor egy normál diát létrehoznak, a helyőrző alakzatok a kiválasztott elrendezésből generálódnak, míg a helyőrzőkbe megadott tartalom a normál dia része.

Adj hozzá szükséges helyőrzőket egy elrendezéshez, mielőtt diák létrehozására használnád. Egy elrendezéshez később hozzáadott további helyőrző nem ad hozzá automatikusan megfelelő helyőrző alakzatot a már létező normál diákhoz.

Ennek a kapcsolatnak két fontos következménye van:

- Az örökölt formázás vagy a meglévő helyőrző geometria módosítása egy elrendezésen minden attól függő diát frissíthet. Mielőtt egy már használt elrendezést szerkesztenél, ellenőrizd annak függő diáit, és tekintsd át az eredményül kapott bemutatót.
- Egy elrendezést, amelyet még diák használnak, nem lehet eltávolítani. Először rendeld át a függő diát egy másik elrendezéshez, vagy csak a nem használt elrendezéseket távolítsd el.

További információért a hierarchia legfelső szintjéről, lásd a [Dia Mester](/slides/hu/nodejs-java/slide-master/).

Az örökölt logók vagy díszítő mesterformák elrejtéséhez egy dián vagy közös elrendezésen keresztül, lásd a [Mestergrafikák láthatóságának vezérlése](/slides/hu/nodejs-java/slide-master/). A példa két, ugyanazt a mestert használó diát hasonlít össze.

## **Diaelrendezés kiválasztása és alkalmazása**

Használj egy [SlideLayoutType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidelayouttype/) értéket, amikor a bemutató a szabványos PowerPoint elrendezésdefiníciókat követi. Az elrendezésneveket a felhasználó szerkesztheti, és lokalizálhatók, így a név alapú kiválasztás kevésbé megbízható, hacsak nem te irányítod a forrássablont.

A következő példa a **Cím és Tartalom** elrendezést keresi az első mesternél. Ha ez az elrendezés nem érhető el, szándékosan az **Üres** elrendezésre tér vissza. A második null ellenőrzés szükséges, mert egy bemutató csak saját elrendezéseket tartalmazhat. A kiválasztott elrendezést ezután a [Slide.setLayoutSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#setLayoutSlide) metódussal alkalmazzák az első normál diára.

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

Egy dia elrendezésének módosítása nem távolítja el a közvetlenül a diára hozzáadott egyszerű alakzatokat. Azonban a helyőrző pozíciók, az örökölt formázás és a meglévő helyőrzők és az új elrendezés közötti megfelelés változhat, ezért ellenőrizd a kimenetet, amikor lényegesen eltérő elrendezések között váltasz.

## **Elrendezés dia hozzáadása**

A kiválasztás és a létrehozás külön műveletek. Az előző példa egy meglévő elrendezést választ ki; nem hoz létre újat. Egy elrendezés létrehozásához hívd meg a [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) metódust a cél mester elrendezésgyűjteményén.

A következő példa mindig hozzáad egy új **Cím és Tartalom** elrendezést `Report Title and Content` néven, majd ennek alapján egy normál diát ad hozzá. Az elrendezésneveknek egyedieknek kell lenniük a gyűjteményen belül.

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

Csak akkor adj hozzá elrendezést, ha a sablon valóban egy új újrahasználható struktúrát igényel. Ha már létezik megfelelő elrendezés, válaszd ki és használd újra a duplikálás helyett.

## **Helyőrzők hozzáadása egy elrendezés diához**

A [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) metódus egy [LayoutPlaceholderManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/) példányt ad a helyőrző alakzatok elrendezéshez való hozzáadásához.

| PowerPoint helyőrző              | `LayoutPlaceholderManager` metódus |
| --------------------------------- | ----------------------------------- |
| ![Tartalom](content.png)          | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Tartalom (Függőleges)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Szöveg](text.png)               | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Szöveg (Függőleges)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Kép](picture.png)               | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Diagram](chart.png)             | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Táblázat](table.png)            | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)         | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Média](media.png)               | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online kép](onlineImage.png)    | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

A következő példa ellenőrzi, hogy az **Üres** elrendezés létezik-e, négy helyőrzőt ad hozzá, majd egy módosított elrendezést használó normál diát hoz létre. A sorrend szándékos: a helyőrzőket a normál dia létrehozása előtt adják hozzá, így az Aspose.Slides képes a megfelelő helyőrző alakzatok generálására azon a dián.

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

![A helyőrzők az elrendezés dián](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Az örökölt formázás vagy a meglévő elrendezéshelyőrzők geometriájának módosítása befolyásolhatja a függő diákat. Az újonnan hozzáadott elrendezéshelyőrző nem kerül visszatöltésre a meglévő normál diákba. Az elrendezésváltoztatásokat egy bemutató másolatán teszteld, és ellenőrizd minden függő diát.
{{% /alert %}}

## **Használaton kívüli elrendezés diák eltávolítása**

Használd a [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) metódust a olyan elrendezések eltávolításához, amelyekre egyetlen normál dia sem hivatkozik. A metódus érintetlenül hagyja a még használt elrendezéseket.

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

Egy adott elrendezés eltávolításához először használd annak [hasDependingSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) vagy [getDependingSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) metódusát. A [LayoutSlide.remove](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/#remove) hívása előtt rendeld át a függő diát. Egy használatban lévő elrendezés eltávolításának kísérlete [PptxEditException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxeditexception/) kivételt vált ki.

## **Lábléc láthatóságának vezérlése egy elrendezés dián**

Egy elrendezésnek saját lábléc, diaszám és dátum-idő helyőrzői vannak. Használd a [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) metódust ezeknek a helyőrzőknek a vezérléséhez egy elrendezésen belül. Ez hasznos például, ha a tartalom elrendezéseknek láblécet kell mutatniuk, de a címelrendezéseknek nem.

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

## **Lábléc láthatóságának vezérlése egy mesteren és annak gyermekelrendezésein**

Az egységes lábléc beállítások egy mesterhierarchián való alkalmazásához használd a [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager) metódust. A [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslideheaderfootermanager/) terjesztési metódusai a mesteren, annak függő elrendezés diákon és normál diákon működnek; nem csak egyetlen normál diát céloznak.

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

## **FAQ**

**Mi a különbség egy mester dia és egy elrendezés dia között?**

A mester dia meghatározza a bemutató témáját és a megosztott formázást. Egy elrendezés dia egy mesterhez tartozik, és egy újrahasználható helyőrző-elosztást definiál. A normál diák ezeket az elrendezéseket használják, és a diára jellemző tartalmat tárolják.

**Másolhatok egy elrendezés diát egyik bemutatóból a másikba?**

Igen. Egy másolatot a célgyűjteményhez adhatod az [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone) metódussal. Bemutatók közti másoláskor ellenőrizd a forrás elrendezés által használt betűtípusokat, témákat, képeket és egyéb erőforrásokat is.

**Mi történik, ha módosítok egy már használt elrendezést?**

A függő diák öröklik az elrendezés változásait, hacsak helyileg nem írják felül az érintett formázást vagy objektumokat. Ennek következtében a helyőrző geometria és az örökölt stílus sok dián egyszerre megváltozhat. Használd a [getDependingSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) metódust a érintett diák azonosításához az elrendezés szerkesztése előtt.

**Mi történik, ha eltávolítok egy még használt elrendezést?**

Az Aspose.Slides [PptxEditException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxeditexception/) kivételt dob. Először rendeld át a függő diákot, vagy használd a [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) metódust, hogy csak a nem hivatkozott elrendezéseket távolítsd el.