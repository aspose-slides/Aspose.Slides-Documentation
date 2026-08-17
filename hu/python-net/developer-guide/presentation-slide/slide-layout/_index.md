---
title: Diaelrendezések alkalmazása vagy módosítása Pythonban
linktitle: Diaelrendezés
type: docs
weight: 60
url: /hu/python-net/slide-layout/
keywords:
- diaelrendezés
- tartalomelrendezés
- helyőrző
- prezentáció tervezés
- diatervezés
- nem használt elrendezés
- lábléc láthatóság
- címlap
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
- prezentáció
- Python
- Aspose.Slides
description: "Alkalmazza, hozza létre és módosítsa a diaelrendezéseket az Aspose.Slides for Python .NET-en keresztül, adjon hozzá helyőrzőket, távolítson el nem használt elrendezéseket, és vezérelje a lábléc láthatóságát."
---
## **Áttekintés**

A diaelrendezés meghatározza a helyőrzők, például címek, szövegek, képek, diagramok és táblák pozícióját és formázását. Egy elrendezés alkalmazása következetes szerkezetet ad a diákhoz, miközben minden dia saját tartalmát tartalmazhatja.

A leggyakoribb elrendezések:

- **Címlap**: Cím és alcím helyőrzőket tartalmaz.
- **Cím és tartalom**: Cím helyőrzőt és általános célú tartalom helyőrzőt tartalmaz.
- **Üres**: Nem tartalmaz tartalomhelyőrzőket, és akkor hasznos, ha minden alakzatot manuálisan helyezünk el.

## **A layout öröklődésének megértése**

Egy prezentációnak három kapcsolódó szintje van:

1. A [master slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslide/) meghatározza a témát, a megosztott formázást, a hátteret és a közös objektumokat.
1. A [layout slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/) egy mesterhez tartozik, és egy adott helyőrző-eloszlást definiál.
1. A [normal slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/) egy elrendezést használ, és tárolja a diához megadott tartalmat.

Egy normál dia a témát és a formázást örökli az elrendezéséből, az elrendezés pedig a mesterből. Egy normál dián közvetlenül beállított érték felülírja az örökölt értéket az adott szinten. Amikor egy normál diát hozunk létre, a helyőrző‑alakzatok a kiválasztott elrendezésből generálódnak, míg a helyőrzőkbe beírt tartalom a normál dia része.

Adjunk szükséges helyőrzőket egy elrendezéshez, mielőtt diákat hoznánk létre belőle. Egy helyőrző későbbi hozzáadása egy elrendezéshez nem ad automatikusan hozzá megfelelő helyőrző‑alakzatot a meglévő normál diákhoz.

Ennek a kapcsolatnak két fontos következménye van:

- Az örökölt formázás vagy egy már létező helyőrző geometria módosítása minden attól függő diát frissíthet. Mielőtt egy már használatban lévő elrendezést szerkesztenénk, ellenőrizzük a függő diák listáját, és tekintsük át a kapott prezentációt.
- Egy elrendezést, amelyet még használ egy dia, nem lehet eltávolítani. Először rendeljük át a függő diákat egy másik elrendezéshez, vagy csak a nem használt elrendezéseket távolítsuk el.

A hierarchia legfelső szintjéről további információ a [Slide Master](/slides/hu/python-net/slide-master/) oldalon található.

## **Diaelrendezés kiválasztása és alkalmazása**

Használjunk elrendezéstípusokat, ha a prezentáció a szabványos PowerPoint elrendezésdefiníciókat követi. Az elrendezésneveket a felhasználó szerkesztheti és lokalizálhatja, ezért a név alapú kiválasztás kevésbé megbízható, hacsak nem kontrolláljuk a forrás‑sablont.

Az alábbi példa a **Cím és tartalom** elrendezést keresi az első mesterben. Ha ez az elrendezés nem érhető el, szándékosan a **Üres** elrendezésre tér vissza. A második null‑ellenőrzés szükséges, mert egy prezentáció csak egyedi elrendezéseket tartalmazhat. A kiválasztott elrendezést ezután a [Slide.layout_slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/layout_slide/) tulajdonságon keresztül alkalmazzuk az első normál diára.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

Egy dia elrendezésének módosítása nem távolítja el az a diára közvetlenül hozzáadott szokásos alakzatokat. Ugyanakkor a helyőrző pozíciók, az örökölt formázás és a meglévő helyőrzők megfelelősége az új elrendezéshez változhat, ezért ellenőrizzük a kimenetet, ha jelentősen eltérő elrendezések között váltunk.

## **Elrendezésdia hozzáadása**

A kiválasztás és a létrehozás külön műveletek. Az előző példa egy meglévő elrendezést választ ki; nem hoz létre újat. Elrendezés létrehozásához hívjuk a [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterlayoutslidecollection/add/) metódust a cél‑mester elrendezésgyűjteményén.

Az alábbi példa mindig hozzáad egy új **Cím és tartalom** elrendezést `Report Title and Content` néven, majd ennek alapján egy normál diát hoz létre. Az elrendezésneveknek egyedieknek kell lenniük a gyűjteményen belül.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Csak akkor adjunk elrendezést, ha a sablon valóban igényel egy új újrahasználható struktúrát. Ha már létezik megfelelő elrendezés, válasszuk ki és használjuk újra, a duplikálás helyett.

## **Helyőrzők hozzáadása egy elrendezésdhióhoz**

A [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/placeholder_manager/) tulajdonság egy [LayoutPlaceholderManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/) objektumot biztosít a helyőrző‑alakzatok elrendezéshez való hozzáadásához.

| PowerPoint helyőrzó                | `LayoutPlaceholderManager` metódus |
| ----------------------------------- | ----------------------------------- |
| ![Tartalom](content.png)            | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Tartalom (függőleges)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Szöveg](text.png)                 | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Szöveg (függőleges)](textV.png)   | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Kép](picture.png)                 | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Diagram](chart.png)               | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Táblázat](table.png)              | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png)           | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Média](media.png)                 | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Online kép](onlineImage.png)      | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

Az alábbi példa ellenőrzi, hogy a **Üres** elrendezés létezik-e, négy helyőrzőt ad hozzá, majd egy normál diát hoz létre, amely a módosított elrendezést használja. A sorrend szándékos: a helyőrzőket a normál dia létrehozása előtt adjuk hozzá, így az Aspose.Slides a megfelelő helyőrző‑alakzatokat tudja generálni azon a dián.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A helyőrzők az elrendezésdién](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Az örökölt formázás vagy a meglévő elrendezéshelyőrzők geometriai módosítása befolyásolhatja a függő diákot. Egy újonnan hozzáadott elrendezéshelyőrző nem töltődik be a már létező normál diákba. Tesztelje az elrendezésváltoztatásokat a prezentáció egy másolatán, és ellenőrizze minden függő diát.
{{% /alert %}}

## **Nem használt elrendezésdiák eltávolítása**

Használja a [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) metódust a olyan elrendezések eltávolításához, amelyre egyetlen normál dia sem hivatkozik. A metódus érintetlenül hagyja azon elrendezéseket, amelyek még használatban vannak.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Egy konkrét elrendezés eltávolításához először ellenőrizze annak [has_depending_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/has_depending_slides/) tulajdonságát vagy [get_depending_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/get_depending_slides/) metódusát. A [LayoutSlide.remove](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/remove/) hívása előtt rendelje át a függő diákat. Egy használt elrendezés eltávolítása [PptxEditException](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pptxeditexception/) kivételt eredményez.

## **Lábléc láthatóságának vezérlése egy elrendezésdián**

Egy elrendezésnek saját lábléce, dia‑száma és dátum‑idő helyőrzői vannak. Használja a [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/header_footer_manager/) tulajdonságot ezeknek a helyőrzőknek a vezérléséhez egy adott elrendezés esetén. Ez akkor hasznos, ha például a tartalom‑elrendezéseknek láblécük van, a címlapoknak pedig nincs.

Az alábbi példa biztonságosan kiválaszt egy elrendezést, és láthatóvá teszi annak lábléc‑elemeit:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Lábléc láthatóságának vezérlése egy mesteren és annak gyermek‑elrendezésein**

A konzisztens lábléc‑beállítások alkalmazásához a mesterhierarchiában használja a [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslide/header_footer_manager/) tulajdonságot. A [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslideheaderfootermanager/) terjesztési metódusai a mesterre, annak függő elrendezésdiákra és a normál diákra hatnak; nem csak egyetlen normál diára céloznak.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Mi a különbség a Master Slide és a Layout Slide között?**

A master slide meghatározza a prezentáció témáját és a megosztott formázást. A layout slide egy mesterhez tartozik, és egy újrahasználható helyőrző‑elrendezést definiál. A normál diákok ezeket az elrendezéseket használják, és a diához specifikus tartalmat tárolják.

**Másolhatok Layout Slide‑t egy prezentációból egy másikba?**

Igen. Használja a [add_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/globallayoutslidecollection/add_clone/) metódust a célgyűjteményhez való másoláshoz. Másoláskor ellenőrizze a forrás‑elrendezés által használt betűtípusokat, témákat, képeket és egyéb erőforrásokat is.

**Mi történik, ha egy már használatban lévő elrendezést módosítok?**

A függő diák öröklik az elrendezésváltozásokat, hacsak nem írják felül a érintett formázást vagy objektumokat helyben. A helyőrzők geometriai jellege és az örökölt stílus ezért sok dián egyszerre megváltozhat. Használja a [get_depending_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/get_depending_slides/) metódust, hogy szerkesztés előtt azonosítsa az érintett diák listáját.

**Mi történik, ha eltávolítok egy még használatban lévő elrendezést?**

Az Aspose.Slides [PptxEditException](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pptxeditexception/) kivételt dob. Először rendelje át a függő diákat, vagy használja a [remove_unused_layout_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) metódust, hogy csak a nem hivatkozott elrendezéseket távolítsa el.