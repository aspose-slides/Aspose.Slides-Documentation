---
title: Správa kreslicích vodítek v prezentacích v Pythonu
linktitle: Kreslicí vodítka
type: docs
weight: 85
url: /cs/python-net/drawing-guides/
keywords:
- kreslicí vodítko
- horizontální vodítko
- vertikální vodítko
- zarovnávací vodítko
- zobrazení snímku
- master snímek
- rozvrhový snímek
- master poznámek
- master podkladů
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Přidávejte, přistupujte a odstraňujte horizontální a vertikální kreslicí vodítka v prezentacích PowerPoint pomocí Aspose.Slides pro Python přes .NET."
---
## **Přehled**

Vodítka jsou nastavitelnými horizontálními a vertikálními čarami, které pomáhají uživatelům konzistentně zarovnávat tvary během úprav prezentace v PowerPointu. Jsou obzvláště užitečná, když aplikace generuje prezentaci, která bude později ručně doladěna: aplikace může uložit stejná zarovnávací vodítka, která by autoři měli dodržovat při přidávání nebo přesouvání obsahu.

Vodítka jsou pomocníky při úpravách, nikoli obsahem snímků. Neobjevují se v prezentaci ani ve vykresleném výstupu. Aspose.Slides pro Python přes .NET je zpřístupňuje prostřednictvím rozhraní [IDrawingGuidesCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/idrawingguidescollection/) . Vodítko je reprezentováno pomocí [IDrawingGuide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/idrawingguide/) a má orientaci, pozici a barvu.

Pozice se měří v bodech od levého horního rohu příslušného snímku nebo masteru. Vertikální vodítko používá horizontální souřadnici, obvykle mezi nulou a šířkou snímku. Horizontální vodítko používá vertikální souřadnici, obvykle mezi nulou a výškou snímku.

## **Přidání vodítek do zobrazení snímku**

Použijte [ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) pro správu vodítek zobrazovaných při úpravách běžných snímků. Zavolejte [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/cs/python-net/aspose.slides/idrawingguidescollection/add/) s hodnotou [Orientation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/orientation/) a pozicí v bodech.

Následující příklad přidá jedno vertikální vodítko napravo od středu snímku a jedno horizontální vodítko pod ním:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Přístup k vodítkům**

Vlastnost a indexer [IDrawingGuidesCollection.count](https://reference.aspose.com/slides/cs/python-net/aspose.slides/idrawingguidescollection/count/) poskytují přístup k existujícím vodítkům. Vlastnosti [IDrawingGuide.orientation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.position](https://reference.aspose.com/slides/cs/python-net/aspose.slides/idrawingguide/position/) a [IDrawingGuide.color](https://reference.aspose.com/slides/cs/python-net/aspose.slides/idrawingguide/color/) lze číst nebo měnit.

Následující příklad načte vodítka zobrazení snímku z výše vytvořené prezentace:

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **Přidání vodítek do masteru a rozvrhových snímků**

Master snímek a každý jeho rozvrhový snímek mohou mít své vlastní kolekce vodítek. Použijte [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imasterslide/drawing_guides/) pro master snímek a [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ilayoutslide/drawing_guides/) pro rozvrhový snímek.

Následující příklad přidá vertikální vodítko na první master snímek a horizontální vodítko na první rozvrhový snímek:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Přidání vodítek do masterů poznámek a podkladů**

Mastery poznámek a podkladů také podporují vodítka. Použijte [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imasternotesslide/drawing_guides/) a [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imasterhandoutslide/drawing_guides/) pro přístup k jejich kolekcím. Pokud prezentace neobsahuje některý z těchto masterů, [IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) nebo [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) vytvoří výchozí master a vrátí jej.

Následující příklad přidá horizontální vodítko do masteru poznámek a vertikální vodítko do masteru podkladů:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Odstranění vodítek**

Zavolejte [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/cs/python-net/aspose.slides/idrawingguidescollection/clear/) pro odstranění všech vodítek z konkrétní kolekce. Vyprázdnění jedné kolekce neovlivní vodítka uložená v jiné oblasti.

Následující příklad vyprázdní vodítka zobrazení snímku a všechna vodítka na master snímcích, rozvrhových snímcích, masteru poznámek a masteru podkladů, aniž by vytvořil chybějící mastery:

```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Objevují se vodítka v prezentaci nebo exportovaných obrázcích?**

Ne. Vodítka jsou pomocníky pro zarovnání při úpravách a nejsou vykreslena jako obsah prezentace.

**Lze vodítko přidat přímo k jednotlivému běžnému snímku?**

Vodítka pro úpravy běžných snímků jsou uložena v vlastnostech zobrazení snímku prezentace. Samostatné kolekce vodítek jsou dostupné pro master snímky, rozvrhové snímky, mastery poznámek a mastery podkladů.

**Jaké jednotky se používají pro pozice vodítek?**

Pozice jsou uváděny v bodech, kde 72 bodů odpovídá jednomu palci. Vertikální pozice se měří od levého okraje a horizontální pozice od horního okraje.

**Odstranění vodítek odstraní tvary nebo změní obsah snímku?**

Ne. Metoda `clear` odstraňuje pouze vodítka ve vybrané kolekci. Tvary a další obsah snímku zůstávají beze změny.