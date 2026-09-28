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
- prezentációtervezés
- diatervezés
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
- prezentáció
- Python
- Aspose.Slides
description: "Diaelrendezések alkalmazása, létrehozása és módosítása az Aspose.Slides for Python segítségével .NET-en keresztül, helyőrzők hozzáadása, nem használt elrendezések eltávolítása, és a lábléc láthatóságának szabályozása."
---
## **Áttekintés**

A diaelrendezés meghatározza a helyőrzők, például címek, szövegek, képek, diagramok és táblázatok pozícióit és formázását. Egy elrendezés alkalmazása egységes szerkezetet kölcsönöz a diáknak, miközben lehetővé teszi, hogy minden dia saját tartalmát tartalmazza.

A leggyakoribb elrendezések a következők:

- **Cím dia**: Cím és alcím helyőrzőket tartalmaz.
- **Cím és tartalom**: Címhelyőrzőt és egy általános célú tartalomhelyőrzőt tartalmaz.
- **Üres**: Nem tartalmaz tartalomhelyőrzőket, és akkor hasznos, ha minden alakzatot manuálisan helyezünk el.

## **Az elrendezés öröklődésének megértése**

Egy prezentációnak három kapcsolódó szintje van:

1. A [fő dia](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslide/) meghatározza a témát, a megosztott formázást, a háttérképeket és a közös objektumokat.
1. Az [elrendezési dia](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/) egy fő diahez tartozik, és meghatároz egy adott helyőrző-elosztást.
1. A [normál dia](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/) egy elrendezést használ, és tárolja a dia számára beírt tartalmat.

Egy normál dia a témát és a formázást az elrendezéséből örökli, az elrendezés pedig a fő diától. A normál diához közvetlenül beállított érték felülírja az örökölt értéket azon a szinten. Amikor egy normál diát létrehoznak, a helyőrző alakzatok a kiválasztott elrendezésből generálódnak, míg a helyőrzőkbe beírt tartalom a normál diához tartozik.

A szükséges helyőrzőket előbb adjuk hozzá egy elrendezéshez, mielőtt diát hoznánk létre belőle. Később egy további helyőrző hozzáadása az elrendezéshez nem ad hozzá automatikusan egy megfelelő helyőrző alakzatot a meglévő normál diákhoz.

Ez a kapcsolat két fontos következménnyel jár:

- Az örökölt formázás vagy a meglévő helyőrző geometria módosítása egy elrendezésen frissítheti az összes attól függő diát. Mielőtt egy már használatban lévő elrendezést szerkesztenénk, ellenőrizzük a függő diákat, és tekintsük át a kapott prezentációt.
- Egy elrendezést, amelyet még egy dia is használ, nem lehet eltávolítani. Először rendeljük át a függő diákat egy másik elrendezésre, vagy csak a nem használt elrendezéseket távolítsuk el.

További információért a hierarchia legfelső szintjéről lásd a [Dia mester](/slides/hu/python-net/slide-master/) oldalt.

Az örökölt logók vagy dekoratív fő alakzatok egy dián vagy egy megosztott elrendezésen keresztül történő elrejtéséhez lásd a [A mestergrafika láthatóságának vezérlése](/slides/hu/python-net/slide-master/) oldalt. A példa két diát hasonlít össze, amelyek ugyanazt a mestert használják.

## **Diaelrendezés kiválasztása és alkalmazása**

Használjon elrendezéstípust, ha a prezentáció a szabványos PowerPoint elrendezésdefiníciókat követi. Az elrendezésneveket a felhasználó szerkesztheti és lokalizálhatja, ezért a névre alapozott kiválasztás kevésbé megbízható, hacsak nem ellenőrzi a forrás‑sablont.

Az alábbi példa az első fő dia **Cím és tartalom** elrendezését keresi. Ha ez az elrendezés nem érhető el, szándékosan **Üres** elrendezésre vált. A második null ellenőrzés szükséges, mert egy prezentáció csak egyedi elrendezéseket tartalmazhat. A kiválasztott elrendezést ezután az első normál diára alkalmazza a [Slide.layout_slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/layout_slide/) tulajdonságon keresztül.

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

Az elrendezés módosítása nem távolítja el a diára közvetlenül hozzáadott normál alakzatokat. Azonban a helyőrző pozíciók, az örökölt formázás és a meglévő helyőrzők és az új elrendezés közötti megfelelés megváltozhat, ezért ellenőrizze a kimenetet, ha jelentősen eltérő elrendezések között vált.

## **Elrendezési dia hozzáadása**

A kiválasztás és a létrehozás külön műveletek. Az előző példa egy meglévő elrendezést választ ki; nem hoz létre újat. Egy elrendezés létrehozásához hívja meg a [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterlayoutslidecollection/add/) metódust a cél fő dia elrendezésgyűjtményén.

Az alábbi példa mindig egy új **Cím és tartalom** elrendezést ad hozzá `Report Title and Content` néven, majd ennek alapján egy normál diát hoz létre. Az elrendezésneveknek egyedieknek kell lenniük a gyűjteményen belül.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Csak akkor adjunk hozzá elrendezést, ha a sablon valóban igényel egy újrahasználható struktúrát. Ha már létezik megfelelő elrendezés, válassza ki és használja újra a duplikálás helyett.

## **Helyőrzők hozzáadása egy elrendezési diához**

A [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/placeholder_manager/) tulajdonság egy [LayoutPlaceholderManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/) példányt biztosít a helyőrző alakzatok elrendezéshez való hozzáadásához.

| PowerPoint helyőrző               | `LayoutPlaceholderManager` Method |
| ----------------------------------- | --------------------------------- |
| ![Tartalom](content.png)            | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Tartalom (függőleges)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Szöveg](text.png)                  | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Szöveg (függőleges)](textV.png)    | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Kép](picture.png)                  | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Diagram](chart.png)                | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Táblázat](table.png)                | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png)            | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Média](media.png)                  | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Online kép](onlineImage.png)       | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

Az alábbi példa ellenőrzi, hogy a **Üres** elrendezés létezik-e, négy helyőrzőt ad hozzá, majd létrehoz egy normál diát, amely a módosított elrendezést használja. A sorrend szándékos: a helyőrzők felvételre kerülnek, mielőtt a normál dia létrejön, így az Aspose.Slides generálja a megfelelő helyőrző alakzatokat azon a dián.

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

![A helyőrzők az elrendezési dián](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Az örökölt formázás vagy a meglévő elrendezési helyőrzők geometriai módosítása befolyásolhatja a függő diákat. Egy újonnan hozzáadott elrendezési helyőrző nem kerül visszapótlásra a már létező normál diákba. Tesztelje az elrendezés módosításait a prezentáció egy másolatán, és ellenőrizze minden függő diát.
{{% /alert %}}

## **Nem használt elrendezési diák eltávolítása**

Használja a [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) metódust a olyan elrendezések eltávolításához, amelyeket egyetlen normál dia sem hivatkozik. A metódus érintetlenül hagyja a még használatban lévő elrendezéseket.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Egy konkrét elrendezés eltávolításához először használja annak a [has_depending_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/has_depending_slides/) tulajdonságát vagy [get_depending_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/get_depending_slides/) metódusát. Az eltávolítás előtt rendelje át a függő diákat, majd hívja meg a [LayoutSlide.remove](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/remove/) metódust. Egy használatban lévő elrendezés eltávolítására tett kísérlet [PptxEditException](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pptxeditexception/) hibát eredményez.

## **Lábléc láthatóságának vezérlése egy elrendezési dián**

Egy elrendezés saját lábléc, dia‑szám és dátum‑idő helyőrzőkkel rendelkezik. Ezeknek a helyőrzőknek a vezérléséhez használja a [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/header_footer_manager/) tulajdonságot egy elrendezésen belül. Ez akkor hasznos, ha például a tartalomelrendezéseknek lábléceket kell mutatniuk, míg a címelrendezéseknek nem.

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

## **Lábléc láthatóságának vezérlése egy fő dián és annak gyermekelrendezésein**

Az egységes lábléc‑beállítások alkalmazásához egy fő dia hierarchián belül használja a [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslide/header_footer_manager/) tulajdonságot. A [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslideheaderfootermanager/) terjesztési módszerei a fő dion és annak függő elrendezési diákon és normál diákon működnek; nem csak egyetlen normál diára irányulnak.

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

A fő dia meghatározza a prezentáció témáját és a megosztott formázást. Egy elrendezési dia egy fő dia részét képezi, és egy újrafelhasználható helyőrző‑elrendezést definiál. A normál diák ezeket az elrendezéseket használják, és a dia‑specifikus tartalmat tárolják.

**Másolhatok‑e Layout Slide‑ot az egyik prezentációból a másikba?**

Igen. Adj egy másolatot a célgyűjteményhez a [add_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/globallayoutslidecollection/add_clone/) metódussal. Másoláskor ellenőrizze a forrás elrendezés által használt betűtípusokat, témákat, képeket és egyéb erőforrásokat is.

**Mi történik, ha módosítok egy már használt elrendezést?**

A függő diák öröklik az elrendezés változásait, kivéve ha a formázást vagy az objektumokat helyileg felülírják. Ezért a helyőrző geometria és az örökölt stílus sok dián egyszerre megváltozhat. Használja a [get_depending_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/get_depending_slides/) metódust a hatással lévő diák azonosításához, mielőtt szerkesztené az elrendezést.

**Mi történik, ha eltávolítok egy még használatban lévő elrendezést?**

Az Aspose.Slides [PptxEditException](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pptxeditexception/) hibát dob. Először rendelje át a függő diákat, vagy használja a [remove_unused_layout_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) metódust, hogy csak a nem hivatkozott elrendezéseket távolítsa el.