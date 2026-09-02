---
title: Diaelrendezések alkalmazása vagy módosítása Java-ban
linktitle: Diaelrendezés
type: docs
weight: 60
url: /hu/java/slide-layout/
keywords:
- diaelrendezés
- tartalomelrendezés
- helyőrző
- prezentáció tervezés
- dia tervezés
- nem használt elrendezés
- lábléc láthatóság
- címdia
- cím és tartalom
- szakaszcím
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
- prezentáció
- Java
- Aspose.Slides
description: "Diaelrendezések alkalmazása, létrehozása és módosítása az Aspose.Slides for Java-ban, helyőrzők hozzáadása, nem használt elrendezések eltávolítása és a lábléc láthatóságának vezérlése."
---
## **Áttekintés**

A diavetítés elrendezés meghatározza a helyőrzők, például címek, szöveg, képek, diagramok és táblázatok pozícióit és formázását. Egy elrendezés alkalmazása egységes szerkezetet biztosít a diák számára, miközben lehetővé teszi, hogy minden dia a saját tartalmát tartalmazza.

A leggyakoribb elrendezések a következők:

- **Címdia**: Címet és alcímet tartalmazó helyőrzőket tartalmaz.
- **Cím és Tartalom**: Címhelyőrzőt és általános célú tartalomhelyőrzőt tartalmaz.
- **Üres**: Nem tartalmaz tartalomhelyőrzőket, és hasznos, ha minden alakzatot manuálisan helyeznek el.

## **Az elrendezés öröklődésének megértése**

Egy prezentációnak három kapcsolódó szintje van:

1. A [master dia](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslide/) meghatározza a témát, a megosztott formázást, a hátteret és a közös objektumokat.
2. Egy [elrendezési dia](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslide/) egy masterhez tartozik, és egy adott helyőrző-elosztást definiál.
3. Egy [normál dia](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/) egy elrendezést használ, és tárolja az adott diára beírt tartalmat.

A normál dia az elrendezéstől örökli a témát és a formázást, az elrendezés pedig a mastertől örököl. A normál dián közvetlenül beállított érték felülírja az örökölt értéket azon a szinten. Amikor egy normál diát hoznak létre, a helyőrző alakzatok a kiválasztott elrendezésből generálódnak, míg a helyőrzőkbe beírt tartalom a normál dia része.

Adjon hozzá szükséges helyőrzőket egy elrendezéshez, mielőtt diákat hozna létre belőle. Egy újabb helyőrző későbbi hozzáadása egy elrendezéshez nem ad automatikusan megfelelő helyőrző alakzatot a meglévő normál diákhoz.

Ennek a kapcsolatnak két fontos következménye van:

- Az örökölt formázás vagy a meglévő helyőrző geometria módosítása egy elrendezésen frissítheti az összes tőle függő diát. Mielőtt egy már használt elrendezést szerkesztené, ellenőrizze a függő diákat, és tekintse át a keletkező prezentációt.
- Az olyan elrendezést, amelyet még diák használnak, nem lehet eltávolítani. Először rendelje át a függő diákat egy másik elrendezésre, vagy csak a nem használt elrendezéseket távolítsa el.

További információkért a hierarchia felső szintjével kapcsolatban lásd a [Dia mester](/slides/hu/java/slide-master/).

## **Elrendezés kiválasztása és alkalmazása**

Használjon elrendezéstípust, ha a prezentáció a PowerPoint szabványos elrendezésdefinícióit követi. Az elrendezésnevek felhasználó által szerkeszthetők és lokalizálhatók, ezért a név alapján történő kiválasztás kevésbé megbízható, hacsak nem ellenőrzi a forrás sablont.

A következő példában a **Cím és Tartalom** elrendezést keresi az első masteren. Ha ez az elrendezés nem érhető el, tudatosan a **Üres** elrendezésre tér vissza. A második null ellenőrzés szükséges, mert egy prezentáció csak egyedi elrendezéseket tartalmazhat. A kiválasztott elrendezést ezután az első normál diára alkalmazza a [ISlide.setLayoutSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) metóduson keresztül.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Egy dia elrendezésének megváltoztatása nem távolítja el a közvetlenül a diára hozzáadott alakzatokat. Azonban a helyőrzők pozíciói, az örökölt formázás és a meglévő helyőrzők és az új elrendezés közötti megfelelés megváltozhat, ezért ellenőrizze a kimenetet, ha lényegesen eltérő elrendezések között vált.

## **Elrendezési dia hozzáadása**

A kiválasztás és a létrehozás külön műveletek. Az előző példa egy meglévő elrendezést választ ki; nem hoz létre újat. Egy elrendezés létrehozásához hívja meg a [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) metódust a cél master elrendezésgyűjteményén.

A következő példa mindig egy új **Cím és Tartalom** elrendezést ad hozzá `Report Title and Content` néven, majd hozzáad egy normál diát, amely ezen alapul. Az elrendezésneveknek egyedieknek kell lenniük a gyűjteményen belül.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Csak akkor adjon hozzá elrendezést, ha a sablon valóban igényel egy újrahasználható struktúrát. Ha már létezik megfelelő elrendezés, válassza ki és használja újra azt a duplikátum létrehozása helyett.

## **Helyőrzők hozzáadása egy elrendezési diához**

Az [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) metódus egy [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/) objektumot biztosít a helyőrző alakzatok elrendezéshez történő hozzáadásához.

| PowerPoint helyőrző | `ILayoutPlaceholderManager` Method |
| -------------------- | ---------------------------------- |
| ![Tartalom](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Tartalom (Függőleges)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Szöveg](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Szöveg (Függőleges)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Kép](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Diagram](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Táblázat](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Média](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online kép](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

A következő példa ellenőrzi, hogy a **Üres** elrendezés létezik-e, négy helyőrzőt ad hozzá, majd létrehoz egy normál diát, amely a módosított elrendezést használja. A sorrend szándékos: a helyőrzőket a normál dia létrehozása előtt adják hozzá, így az Aspose.Slides a megfelelő helyőrző alakzatokat tudja generálni azon a dian.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A helyőrzők az elrendezési dián](add_placeholders.png)

{{% alert color="warning" title="Figyelmeztetés" %}}
Az örökölt formázás vagy a meglévő elrendezési helyőrzők geometriai módosítása befolyásolhatja a függő diát. Az újonnan hozzáadott elrendezési helyőrző nem kerül visszatöltésre a meglévő normál diákba. Tesztelje az elrendezés változtatásait a prezentáció egy másolatán, és ellenőrizze minden függő diát.
{{% /alert %}}

## **Nem használt elrendezési diák eltávolítása**

Használja a [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) metódust a olyan elrendezések eltávolításához, amelyeket egyetlen normál dia sem hivatkozik. A metódus érintetlenül hagyja a még használatban lévő elrendezéseket.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Egy konkrét elrendezés eltávolításához először használja a [hasDependingSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) vagy a [getDependingSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) metódust. Rendezze át a függő diákat, mielőtt meghívná a [ILayoutSlide.remove](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslide/#remove--) metódust. Egy használatban lévő elrendezés eltávolítása [PptxEditException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxeditexception/) kivételt dob.

## **Lábléc láthatóságának vezérlése egy elrendezési dián**

Egy elrendezés saját lábléc, dia-szám és dátum-idő helyőrzőkkel rendelkezik. Használja a [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) metódust ezeknek a helyőrzőknek a vezérléséhez egyetlen elrendezés esetén. Ez hasznos például, ha a tartalom elrendezéseknek láblécet kell megjeleníteniük, míg a cím elrendezéseknek nem.

A következő példa biztonságosan kiválaszt egy elrendezést, és láthatóvá teszi annak lábléc elemeit:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lábléc láthatóságának vezérlése egy masteren és annak alárendelt elrendezésein**

A master hierarchiában egységes lábléc beállítások alkalmazásához használja az [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--) metódust. Az [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslideheaderfootermanager/) terjesztési metódusai a masteren, annak függő elrendezési diáin és normál diáin dolgoznak; nem csak egyetlen normál diát céloznak.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Mi a különbség a master dia és az elrendezési dia között?**

A master dia meghatározza a prezentáció témáját és a megosztott formázást. Egy elrendezési dia egy masterhez tartozik, és egy újrahasználható helyőrző-elosztást definiál. A normál diák ezeket az elrendezéseket használják, és a diára jellemző tartalmat tárolják.

**Másolhatok elrendezési diát egyik prezentációból a másikba?**

Igen. A [addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) metódussal adjon hozzá egy másolatot a célgyűjteményhez. Prezentációk közötti másolásnál ellenőrizze a betűtípusokat, témákat, képeket és a forrás elrendezés által használt egyéb erőforrásokat is.

**Mi történik, ha módosítok egy már használatban lévő elrendezést?**

A függő diák öröklik az elrendezés módosításait, hacsak nem írják felül a helyi formázást vagy objektumokat. Ennek következtében a helyőrzők geometriai alakja és az örökölt stílus sok dián egyszerre megváltozhat. Használja a [getDependingSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) metódust a érintett diák azonosításához, mielőtt szerkesztené az elrendezést.

**Mi történik, ha eltávolítok egy még használatban lévő elrendezést?**

Az Aspose.Slides egy [PptxEditException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxeditexception/) kivételt dob. Először rendelje át a függő diákat, vagy használja a [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) metódust, hogy csak a nem hivatkozott elrendezéseket távolítsa el.