---
title: "Dia elrendezések alkalmazása vagy módosítása Pythonban Java-n keresztül"
linktitle: "Dia elrendezés"
type: docs
weight: 60
url: /hu/python-java/slide-layout/
keywords:
- diaelrendezés
- tartalomelrendezés
- helyőrző
- bemutató tervezés
- dia tervezés
- használaton kívüli elrendezés
- lábléc láthatóság
- cím dia
- cím és tartalom
- szakasz fejléc
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
- Python
- Java
- Aspose.Slides
description: "Diaelrendezéseket alkalmazni, létrehozni és módosítani az Aspose.Slides-ben Pythonhoz Java-n keresztül, helyőrzőket hozzáadni, használaton kívüli elrendezéseket eltávolítani és a lábléc láthatóságát szabályozni."
---
## **Áttekintés**

A dia elrendezése meghatározza a helyőrzők, például a címek, szöveg, képek, diagramok és táblázatok pozícióit és formázását. Egy elrendezés alkalmazása következetes szerkezetet biztosít a diák számára, miközben minden dia saját tartalmát tartalmazhatja.

A leggyakoribb elrendezések a következők:

- **Title Slide**: Cím és alcím helyőrzőket tartalmaz.
- **Title and Content**: Cím helyőrzőt és egy általános célú tartalomhelyőrzőt tartalmaz.
- **Blank**: Nem tartalmaz tartalomhelyőrzőket, és akkor hasznos, ha minden alakzatot kézzel helyezünk el.

## **Az elrendezés öröklődésének megértése**

Egy bemutatónak három összefüggő szintje van:

1. A [master slide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslide/) meghatározza a témát, a közös formázást, a háttérképeket és a közös objektumokat.
1. A [layout slide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutslide/) egy masterhez tartozik, és egy adott helyőrző elrendezést határoz meg.
1. A [normal slide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/) egy elrendezést használ, és a diára beírt tartalmat tárolja.

Egy normal slide a témát és a formázást a saját elrendezésétől örökli, az elrendezés pedig a masterétől. A normal slide-on közvetlenül beállított érték felülírja az örökölt értéket azon a szinten. Amikor egy normal slide létrejön, a helyőrző alakzatok a kiválasztott elrendezésből generálódnak, míg a helyőrzőkbe beírt tartalom a normal slide-hoz tartozik.

Adjon hozzá a szükséges helyőrzőket az elrendezéshez, mielőtt diák létrehozására használná. Az elrendezéshez később hozzáadott további helyőrző nem ad hozzá automatikusan megfelelő helyőrző alakzatot a már létező normal slide-okra.

Ennek a kapcsolatnak két fontos következménye van:

- A layouton végzett örökölt formázás vagy meglévő helyőrző geometria módosítása frissítheti az összes attól függő diát. Mielőtt szerkesztenénk egy már használatban lévő elrendezést, ellenőrizzük a függő diákot, és tekintsük át az eredményes bemutatót.
- Olyan elrendezést, amelyet még használ egy dia, nem lehet eltávolítani. Először rendelje át a függő diákat egy másik elrendezéshez, vagy csak a nem használt elrendezéseket távolítsa el.

További információkért a hierarchia felső szintjéről lásd a [Slide Master](/slides/hu/python-java/slide-master/) oldalt.

## **Diaelrendezés kiválasztása és alkalmazása**

Használjon elrendezéstípust, ha a bemutató a szabványos PowerPoint elrendezésdefiníciókat követi. Az elrendezés nevei felhasználó által szerkeszthetők és lokalizálhatók, így a név alapján történő kiválasztás kevésbé megbízható, hacsak nem szabályozza a forrás sablont.

A következő példa az első masteren a **Title and Content** elrendezést keresi. Ha az elrendezés nem elérhető, szándékosan a **Blank** elrendezésre tér vissza. A második `None` ellenőrzés szükséges, mert egy bemutató csak egyéni elrendezéseket tartalmazhat. A kiválasztott elrendezést ezután a [Slide.setLayoutSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#setLayoutSlide) metódussal alkalmazzák az első normal slide-ra.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Egy dia elrendezésének módosítása nem távolítja el a közvetlenül a diára hozzáadott szokásos alakzatokat. Azonban a helyőrzők pozíciói, az örökölt formázás és a meglévő helyőrzők és az új elrendezés közötti megfelelés megváltozhat, ezért ellenőrizze a kimenetet, amikor jelentősen eltérő elrendezések között vált.

## **Elrendezésdia hozzáadása**

A kiválasztás és a létrehozás külön műveletek. Az előző példa egy meglévő elrendezést választ ki; nem hoz létre újat. Egy elrendezés létrehozásához hívja meg a [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterlayoutslidecollection/#add) metódust a cél master elrendezésgyűjteményén.

A következő példa mindig egy új **Title and Content** elrendezést ad hozzá `Report Title and Content` néven, majd egy normal slide-ot hoz létre ezen alapulva. Az elrendezésneveknek egyedieknek kell lenniük a gyűjteményen belül.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Csak akkor adjon hozzá elrendezést, ha a sablon ténylegesen egy másik újrahasználható struktúrát igényel. Ha már létezik megfelelő elrendezés, válassza ki és használja újra a duplikálás helyett.

## **Helyőrzők hozzáadása egy elrendezésdiához**

A [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutslide/#getPlaceholderManager) metódus egy [LayoutPlaceholderManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/) objektumot biztosít a helyőrző alakzatok elrendezéshez való hozzáadásához.

| PowerPoint helyőrző                | [LayoutPlaceholderManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/) metódus |
| ----------------------------------- | ---------------------------------- |
| ![Tartalom](content.png)            | [addContentPlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Tartalom (függőleges)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Szöveg](text.png)                 | [addTextPlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Szöveg (függőleges)](textV.png)   | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Kép](picture.png)                 | [addPicturePlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Diagram](chart.png)               | [addChartPlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Táblázat](table.png)              | [addTablePlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [addSmartArtPlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Média](media.png)                 | [addMediaPlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online kép](onlineImage.png)      | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

A következő példa ellenőrzi, hogy a **Blank** elrendezés létezik, négy helyőrzőt ad hozzá, majd egy módosított elrendezést használó normal slide-ot hoz létre. A sorrend szándékos: a helyőrzőket a normal slide létrehozása előtt adják hozzá, így az Aspose.Slides a megfelelő helyőrző alakzatokat generálja azon a dián.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A helyőrzők az elrendezésdián](add_placeholders.png)

{{% alert color="warning" title="Figyelmeztetés" %}}
Az örökölt formázás vagy a meglévő elrendezéshelyőrzők geometriai módosítása befolyásolhatja a függő diákat. Az újból hozzáadott elrendezéshelyőrző nem lesz visszatöltve a már létező normal slide-okra. Tesztelje az elrendezés módosításait a bemutató egy másolatán, és ellenőrizze minden függő diát.
{{% /alert %}}

## **Használaton kívüli elrendezésdiák eltávolítása**

Használja a [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) metódust a olyan elrendezések eltávolításához, amelyeket egyetlen normal slide sem hivatkozik. A metódus érintetlenül hagyja a még használatban lévő elrendezéseket.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Egy adott elrendezés eltávolításához először használja a [hasDependingSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutslide/#hasDependingSlides) vagy a [getDependingSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutslide/#getDependingSlides) metódust. A [LayoutSlide.remove](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutslide/#remove) hívása előtt rendelje át a függő diákat. Egy használatban lévő elrendezés eltávolításának kísérlete [PptxEditException](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxeditexception/) kivételt dob.

## **Lábléc láthatóságának szabályozása egy elrendezésdián**

Egy elrendezésnek saját lábléc, dia-szám és dátum-idő helyőrzői vannak. Használja a [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) metódust ezeknek a helyőrzőknek a szabályozásához egy adott elrendezésen. Ez hasznos például, ha a tartalomelrendezéseknek láblécet kell megjeleníteni, a címelrendezéseknek pedig nem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lábléc láthatóságának szabályozása a masteren és annak gyermekelrendezésein**

Az egységes lábléc beállítások mesterhierarchiában történő alkalmazásához használja a [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslide/#getHeaderFooterManager) metódust. A [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslideheaderfootermanager/) terjesztési metódusai a masteren, annak függő elrendezésdiáin és normal slide-okon működnek; nem egyetlen normal slide-ra irányulnak.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Mi a különbség a master slide és a layout slide között?**

Egy master slide meghatározza a bemutató témáját és a közös formázást. Egy layout slide a masterhez tartozik, és egy újrahasználható helyőrzőelrendezést definiál. A normal slide-ok ezeket az elrendezéseket használják, és a diához specifikus tartalmat tárolják.

**Másolhatok-e egy layout slide-ot egy bemutatóból egy másikba?**

Igen. A [addClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/globallayoutslidecollection/#addClone) metódussal adjon hozzá egy másolatot a célgyűjteményhez. Bemutatók közti másolásnál ellenőrizze a betűtípusokat, témákat, képeket és egyéb forrásokat, amelyeket a forrás elrendezés használ.

**Mi történik, ha módosítok egy már használt elrendezést?**

A függő diák öröklik az elrendezés módosításait, hacsak helyileg felül nem írják az érintett formázást vagy objektumokat. A helyőrző geometria és az örökölt stílus ezért egyszerre sok dián változhat. Használja a [getDependingSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutslide/#getDependingSlides) metódust a érintett diák azonosításához az elrendezés szerkesztése előtt.

**Mi történik, ha egy még használatban lévő elrendezést eltávolítok?**

Az Aspose.Slides egy [PptxEditException](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxeditexception/) kivételt dob. Először rendelje át a függő diákat, vagy használja a [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) metódust, hogy csak a nem hivatkozott elrendezéseket távolítsa el.