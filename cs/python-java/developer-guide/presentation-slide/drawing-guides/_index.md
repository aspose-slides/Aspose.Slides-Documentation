---
title: Správa kreslicích vodítek v prezentacích v Pythonu
linktitle: Kreslicí vodítka
type: docs
weight: 85
url: /cs/python-java/drawing-guides/
keywords:
- kreslicí vodítko
- vodorovné vodítko
- svislé vodítko
- zarovnávací vodítko
- zobrazení snímku
- master snímek
- rozložení snímku
- master poznámek
- master handout
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Přidejte, přistupujte k a odstraňte vodorovná a svislá kreslicí vodítka v PowerPoint prezentacích pomocí Aspose.Slides pro Python prostřednictvím Javy."
---
## **Přehled**

Kreslicí vodítka jsou nastavitelná vodorovná a svislá čáry, které uživatelům pomáhají konzistentně zarovnávat tvary při úpravě prezentace v aplikaci PowerPoint. Jsou zvláště užitečná, když aplikace generuje prezentaci, která bude později manuálně upravována: aplikace může uložit stejné zarovnávací pomůcky, které by autoři měli následovat při přidávání nebo přesouvání obsahu.

Kreslicí vodítka jsou pomůcky pro úpravy, nikoli obsah snímku. Neobjevují se v prezentaci ani ve vykresleném výstupu. Aspose.Slides for Python via Java je vystavuje prostřednictvím třídy [DrawingGuidesCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/drawingguidescollection/) . Vodítko je reprezentováno třídou [DrawingGuide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/drawingguide/) a má orientaci, pozici a barvu.

Pozice se měří v bodech od levého horního rohu příslušného snímku nebo masteru. Svislé vodítko používá horizontální souřadnici, obvykle mezi nulou a šířkou snímku. Vodorovné vodítko používá vertikální souřadnici, obvykle mezi nulou a výškou snímku.

## **Přidat vodítka do zobrazení snímku**

Použijte [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) k řízení vodítek zobrazovaných při úpravě běžných snímků. Zavolejte [DrawingGuidesCollection.add](https://reference.aspose.com/slides/cs/python-java/aspose.slides/drawingguidescollection/#add) s hodnotou [Orientation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/orientation/) a pozicí v bodech.

Následující příklad přidá jedno svislé vodítko napravo od středu snímku a jedno vodorovné vodítko pod ním:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Přístup ke kreslicím vodítkům**

Metody [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/cs/python-java/aspose.slides/drawingguidescollection/#getCount) a [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/cs/python-java/aspose.slides/drawingguidescollection/#get_Item) poskytují přístup k existujícím vodítkům. Metody [DrawingGuide.getOrientation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/cs/python-java/aspose.slides/drawingguide/#getPosition) a [DrawingGuide.getColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/drawingguide/#getColor) vrací hodnoty, které lze také změnit pomocí odpovídajících metod pro nastavení.

Následující příklad načte vodítka zobrazení snímku z výše vytvořené prezentace:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **Přidat vodítka do masteru a rozložení snímků**

Master snímku a každý jeho rozložení snímku může mít vlastní kolekce kreslicích vodítek. Použijte [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/#getDrawingGuides) pro master snímek a [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslide/#getDrawingGuides) pro snímek rozložení.

Následující příklad přidá svislé vodítko k prvnímu masteru snímku a vodorovné vodítko k prvnímu rozložení snímku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Přidat vodítka do masterů poznámek a handoutů**

Mastery poznámek a handoutů také podporují kreslicí vodítka. Použijte [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masternotesslide/#getDrawingGuides) a [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides) pro přístup k jejich kolekcím. Pokud prezentace neobsahuje některý z těchto masterů, `MasterNotesSlideManager.setDefaultMasterNotesSlide` nebo `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` vytvoří výchozí master a vrátí jej.

Následující příklad přidá vodorovné vodítko do masteru poznámek a svislé vodítko do handout masteru:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Odstranit kreslicí vodítka**

Zavolejte [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/cs/python-java/aspose.slides/drawingguidescollection/#clear), aby se odstranilo každé vodítko z konkrétní kolekce. Vymazání jedné kolekce neovlivní vodítka uložená v jiné oblasti.

Následující příklad vymaže vodítka zobrazení snímku a všechna vodítka na masterech snímků, rozložení snímků, masteru poznámek a handout masteru bez vytváření chybějících masterů:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Objevují se kreslicí vodítka v prezentaci nebo exportovaných obrázcích?**

Ne. Kreslicí vodítka jsou pomůcky pro zarovnání při úpravách a nejsou vykreslená jako obsah prezentace.

**Lze kreslicí vodítko přidat přímo k jednotlivému normálnímu snímku?**

Vodítka pro úpravu normálních snímků jsou uložena ve vlastnostech zobrazení snímku prezentace. Samostatné kolekce vodítek jsou k dispozici pro master snímky, rozložení snímků, mastery poznámek a handoutů.

**Jaké jednotky se používají pro pozice vodítek?**

Pozice jsou specifikovány v bodech, kde 72 bodů odpovídá jednomu palci. Vertikální pozice jsou měřeny od levého okraje a horizontální pozice od horního okraje.

**Odstranění kreslicích vodítek odstraňuje tvary nebo mění obsah snímku?**

Ne. Metoda [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/cs/python-java/aspose.slides/drawingguidescollection/#clear) odstraňuje pouze vodítka ve vybrané kolekci. Tvary a další obsah snímku zůstávají beze změny.