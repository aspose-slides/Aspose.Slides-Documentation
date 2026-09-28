---
title: Diaelrendezések alkalmazása vagy módosítása Pythonban Java-val
linktitle: Diaelrendezés
type: docs
weight: 60
url: /hu/python-java/slide-layout/
keywords:
- diaelrendezés
- tartalomelrendezés
- helyfoglaló
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
- Python
- Java
- Aspose.Slides
description: "Alkalmazza, hozza létre és módosítsa a diák elrendezéseit az Aspose.Slides for Python via Java-ban, adjon hozzá helyfoglalókat, távolítson el nem használt elrendezéseket, és vezérelje a lábléc láthatóságát."
---
## **Áttekintés**

Egy diaelrendezés meghatározza a helyfoglalók, például címek, szöveg, képek, diagramok és táblázatok pozícióját és formázását. Az elrendezés alkalmazásával a diák egységes szerkezetet kapnak, miközben minden dia saját tartalmát tartalmazhatja.

A leggyakoribb elrendezések a következők:

- **Címdia**: Cím és alcím helyfoglalókat tartalmaz.
- **Cím és tartalom**: Cím helyfoglalót és egy általános célú tartalomhelyet tartalmaz.
- **Üres**: Nem tartalmaz tartalomhelyeket, és akkor hasznos, ha minden alakzatot manuálisan helyezünk el.

## **Ismerje meg az elrendezés öröklődését**

Egy prezentációnak három egymással összefüggő szintje van:

1. Egy [master dia](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslide/) határozza meg a témát, a közös formázást, a hátteret és a közös objektumokat.
2. Egy [elrendezésdia](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutslide/) egy mesterhez tartozik, és egy meghatározott helyfoglaló‑elrendezést definiál.
3. Egy [normál dia](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/) egy elrendezést használ, és a dia számára megadott tartalmat tárolja.

A normál dia az elrendezéstől örökli a témát és a formázást, az elrendezés pedig a mastertől. Egy normál dián közvetlenül beállított érték felülírja az örökölt értéket azon a szinten. Amikor egy normál diát létrehoznak, a helyfoglaló alakzatok a kiválasztott elrendezésből jönnek létre, míg a helyfoglalókba beírt tartalom a normál dia része.

Adjunk hozzá szükséges helyfoglalókat egy elrendezéshez, mielőtt diákat hoznánk létre belőle. Egy helyfoglaló későbbi hozzáadása egy elrendezéshez nem illeszti automatikusan be a megfelelő helyfoglaló alakzatot a már létező normál diákba.

Ennek a kapcsolatnak két fontos következménye van:

- Az örökölt formázás vagy a meglévő helyfoglaló geometria módosítása az elrendezésen minden attól függő diát frissíthet. Mielőtt egy már használatban lévő elrendezést szerkesztenénk, ellenőrizzük a függő diák listáját, és vizsgáljuk meg a kapott prezentációt.
- Egy még diát használó elrendezést nem lehet eltávolítani. Először rendeljük át a függő diákat egy másik elrendezéshez, vagy csak a nem használt elrendezéseket távolítsuk el.

A hierarchia felső szintjéről további információkért lásd a [Dia mester](/slides/hu/python-java/slide-master/) oldalt.

Az örökölt logók vagy dekoratív mesteralakzatok egy dián vagy egy megosztott elrendezésen keresztül történő elrejtéséhez lásd a [Mestergrafikák láthatóságának vezérlése](/slides/hu/python-java/slide-master/) oldalt. A példa két, ugyanazt a mestert használó diát hasonlít össze.

## **Elrendezés kiválasztása és alkalmazása**

Használjunk elrendezéstípust, ha a prezentáció a PowerPoint szabványos elrendezésdefinícióit követi. Az elrendezésneveket a felhasználó szerkesztheti és lokalizálhatja, ezért a néven alapuló kiválasztás kevésbé megbízható, ha nem saját forrássablont használunk.

Az alábbi példa az első masteron a **Cím és tartalom** elrendezést keresi. Ha ez az elrendezés nem érhető el, tudatosan visszatér a **Üres** elrendezésre. A `None` ellenőrzése azért szükséges, mert egy prezentáció csak egyéni elrendezéseket tartalmazhat. A kiválasztott elrendezést ezután a [Slide.setLayoutSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#setLayoutSlide) metódussal alkalmazzuk az első normál diára.

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

Egy dia elrendezésének módosítása nem távolítja el az közvetlenül a diára hozzáadott szokásos alakzatokat. Azonban a helyfoglalók pozíciója, az örökölt formázás és a meglévő helyfoglalók és az új elrendezés közötti megfelelés változhat, ezért ellenőrizzük a kimenetet, ha jelentősen eltérő elrendezések között váltunk.

## **Elrendezésdia hozzáadása**

A kiválasztás és a létrehozás külön műveletek. Az előző példa egy meglévő elrendezést választ ki; nem hoz létre újat. Egy elrendezés létrehozásához hívjuk a [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterlayoutslidecollection/#add) metódust a célmaster elrendezésgyűjteményén.

Az alábbi példa mindig hozzáad egy új **Cím és tartalom** elrendezést `Report Title and Content` néven, majd egy rá épülő normál diát hoz létre. Az elrendezésneveknek egyedieknek kell lenniük a gyűjteményen belül.

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

Csak akkor adjunk elrendezést, ha a sablon valóban igényel egy új újrahasználható struktúrát. Ha már létezik megfelelő elrendezés, válasszuk ki és használjuk azt a duplikálás helyett.

## **Helyfoglalók hozzáadása egy elrendezésdiához**

A [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutslide/#getPlaceholderManager) metódus egy [LayoutPlaceholderManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/) objektumot ad vissza a helyfoglaló alakzatok elrendezéshez történő hozzáadásához.

| PowerPoint helyfoglaló               | [LayoutPlaceholderManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/) metódus |
| ------------------------------------ | ---------------------------------------- |
| ![Tartalom](content.png)             | [addContentPlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Tartalom (függőleges)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Szöveg](text.png)                  | [addTextPlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Szöveg (függőleges)](textV.png)    | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Kép](picture.png)                  | [addPicturePlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Diagram](chart.png)                | [addChartPlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Táblázat](table.png)               | [addTablePlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)            | [addSmartArtPlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Média](media.png)                  | [addMediaPlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online kép](onlineImage.png)       | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Az alábbi példa ellenőrzi, hogy a **Üres** elrendezés létezik-e, négy helyfoglalót ad hozzá, majd egy módosított elrendezést használó normál diát hoz létre. A sorrend szándékos: a helyfoglalókat a normál dia létrehozása előtt adjuk hozzá, így az Aspose.Slides a megfelelő helyfoglaló alakzatokat generálja a dián.

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

![A helyfoglalók az elrendezésdián](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}

Az örökölt formázás vagy a meglévő elrendezéshelyfoglalók geometriai módosítása befolyásolhatja a függő diákot. Egy újonnan hozzáadott elrendezéshelyfoglaló nem töltődik be a már létező normál diákba. Teszteljük az elrendezésváltoztatásokat egy másolaton, és ellenőrizzük az összes függő diát.

{{% /alert %}}

## **Nem használt elrendezésdiákok eltávolítása**

Használjuk a [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) metódust a olyan elrendezések eltávolításához, amelyeket egyetlen normál dia sem hivatkozik. A metódus érintetlenül hagyja a még használatban lévő elrendezéseket.

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

Egy konkrét elrendezés eltávolításához először használjuk a [hasDependingSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutslide/#hasDependingSlides) vagy a [getDependingSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutslide/#getDependingSlides) metódust. Az esetleges függő diák átrendezése után hívjuk a [LayoutSlide.remove](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutslide/#remove) metódust. Egy használt elrendezés eltávolítása [PptxEditException](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxeditexception/) kivételt eredményez.

## **Lábléc láthatóságának vezérlése egy elrendezésdián**

Egy elrendezésnek saját lábléc‑, dia‑szám‑ és dátum‑idő‑helyfoglalója van. Használjuk a [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) metódust ezeknek a helyfoglalóknak a vezérléséhez egy elrendezésen belül. Ez akkor hasznos, ha például a tartalom‑elrendezéseknek láblécet kell mutatniuk, a címelrendezéseknek pedig nem.

Az alábbi példa biztonságosan kiválaszt egy elrendezést, és láthatóvá teszi a lábléc elemeit:

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

## **Lábléc láthatóságának vezérlése egy masteren és annak gyermekelrendezésein**

A konzisztens lábléc‑beállítások alkalmazásához a teljes mester‑hierarchián, használjuk a [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslide/#getHeaderFooterManager) metódust. A [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslideheaderfootermanager/) terjesztési módszerei a masteren, a hozzá tartozó elrendezés‑diákon és a normál diákon is működnek; nem csak egyetlen normál diát céloznak meg.

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

## **GYIK**

**Mi a különbség a master diának és az elrendezésdiának?**

A master dia határozza meg a prezentáció témáját és a közös formázást. Az elrendezésdia egy masterhez tartozik, és egy újrahasználható helyfoglaló‑elrendezést definiál. A normál diákok ezeket az elrendezéseket használják, és a dia‑specifikus tartalmat tárolják.

**Másolhatok elrendezésdiát egy prezentációból a másikba?**

Igen. A [addClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/globallayoutslidecollection/#addClone) metódussal egy másolatot adhatunk a célgyűjteményhez. Másoláskor ellenőrizzük a betűtípusokat, témákat, képeket és egyéb forrásokat, amelyeket a forrás‑elrendezés használ.

**Mi történik, ha módosítok egy már használatban lévő elrendezést?**

A függő diák öröklik az elrendezésváltozásokat, kivéve ha a formázást vagy az objektumokat lokálisan felülbírálják. A helyfoglaló geometria és az örökölt stílus így sok diába egyszerre változhat. A szerkesztés előtt használjuk a [getDependingSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutslide/#getDependingSlides) metódust a érintett diák azonosításához.

**Mi lesz, ha eltávolítok egy még használatban lévő elrendezést?**

Az Aspose.Slides [PptxEditException](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxeditexception/) kivételt dob. Először rendeljük át a függő diákot, vagy használjuk a [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) metódust, hogy csak a nem hivatkozott elrendezéseket távolítsuk el.