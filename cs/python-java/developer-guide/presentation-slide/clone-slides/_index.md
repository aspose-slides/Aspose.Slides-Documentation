---
title: Klonování snímků prezentace v Pythonu
linktitle: Klonovat snímky
type: docs
weight: 35
url: /cs/python-java/clone-slides/
keywords:
- klonovat snímek
- kopírovat snímek
- uložit snímek
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Rychle duplikujte snímky PowerPoint pomocí Aspose.Slides pro Python přes Java. Sledujte naše přehledné příklady kódu a automatizujte tvorbu PPT během několika sekund a odstraňte ruční práci."
---
## **Úvod**

Klónování je proces vytváření přesné kopie nebo repliky něčeho. Aspose.Slides pro Python přes Java také umožňuje vytvořit kopii nebo klon libovolného snímku a poté vložit tento klonovaný snímek do aktuální prezentace nebo jakékoli jiné otevřené prezentace. Proces klonování snímků vytváří nový snímek, který mohou vývojáři upravovat, aniž by změnili původní snímek. Existuje několik možných způsobů, jak klonovat snímek:

- Klonovat na konci v rámci prezentace.
- Klonovat na jiném místě v rámci prezentace.
- Klonovat na konci v jiné prezentaci.
- Klonovat na jiném místě v jiné prezentaci.
- Klonovat společně s jeho hlavním snímkem do jiné prezentace.

V Aspose.Slides pro Python přes Java poskytuje kolekce snímků (kolekce objektů [Slide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/) ) vystavená objektem [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) metody [addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addClone) a [insertClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#insertClone) pro provedení výše uvedených typů klonování snímků.

## **Klonovat snímek na konci prezentace**

Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace na konci existujících snímků, použijte metodu [addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addClone) podle kroků uvedených níže:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte objekt [SlideCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/) odkazováním na kolekci Slides vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
3. Vyvolejte metodu [addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addClone) vystavenou objektem [SlideCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/) a jako parametr předávejte snímek, který má být klonován, metodě [addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addClone).
4. Uložte upravený soubor prezentace.

V níže uvedeném příkladu jsme klonovali snímek (nacházející se na první pozici – index 0 – v prezentaci) na konec prezentace.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # Klonujte požadovaný snímek na konec kolekce snímků ve stejné prezentaci
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # Uložte upravenou prezentaci na disk
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Klonovat snímek na jiné místo v prezentaci**

Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace, ale na jiné pozici, použijte metodu [insertClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#insertClone):

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte odkaz na kolekci snímků vrácenou metodou [getSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSlides) na objektu [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
3. Vyvolejte metodu [insertClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#insertClone) vystavenou objektem [SlideCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/) a předáte snímek, který má být klonován, spolu s indexem pro novou pozici jako parametr metodě [insertClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#insertClone).
4. Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme klonovali snímek (nacházející se na indexu 1 – pozice 2 – v prezentaci) na index 2 – pozice 3 – v prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # Získejte kolekci snímků v prezentaci
    slides = presentation.getSlides()

    # Klonujte požadovaný snímek na zadaný index ve stejné prezentaci
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # Uložte upravenou prezentaci na disk
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Klonovat snímek na konci jiné prezentace**

Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné souboru prezentace, na konci existujících snímků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) která obsahuje prezentaci, ze které bude snímek klonován.
2. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) která obsahuje cílovou prezentaci, do které bude snímek přidán.
3. Získejte objekt [SlideCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/) odkazováním na kolekci snímků vrácenou metodou [getSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSlides) na objektu [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) cílové prezentace.
4. Vyvolejte metodu [addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addClone) vystavenou objektem [SlideCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/) a jako parametr předávejte snímek ze zdrojové prezentace metodě [addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addClone).
5. Uložte upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek (z indexu 0 zdrojové prezentace) na konec cílové prezentace.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Vytvořte instanci třídy Presentation pro cílový PPTX (kam bude snímek klonován)
    destination_presentation = Presentation()
    try:
        # Klonujte požadovaný snímek ze zdrojové prezentace na konec kolekce snímků v cílové prezentaci
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # Uložte cílovou prezentaci na disk
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Klonovat snímek na jiné místo v jiné prezentaci**

Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné souboru prezentace na konkrétní pozici:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) která obsahuje zdrojovou prezentaci, ze které bude snímek klonován.
2. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) která obsahuje prezentaci, do které bude snímek přidán.
3. Získejte objekt [SlideCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/) odkazováním na kolekci Slides vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) cílové prezentace.
4. Vyvolejte metodu [insertClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#insertClone) vystavenou objektem [SlideCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/) a předáte snímek ze zdrojové prezentace spolu s požadovanou pozicí jako parametr metodě [insertClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#insertClone).
5. Uložte upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek (z nulového indexu zdrojové prezentace) na index 1 (pozice 2) cílové prezentace.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Vytvořte instanci třídy Presentation pro cílový PPTX (kam bude snímek klonován)
    destination_presentation = Presentation()
    try:
        # Klonujte požadovaný snímek ze zdrojové prezentace na zadaný index v cílové prezentaci
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # Uložte cílovou prezentaci na disk
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Klonovat snímek s jeho hlavním snímkem do jiné prezentace**

Pokud potřebujete klonovat snímek s hlavním snímkem z jedné prezentace a použít jej v jiné prezentaci, musíte nejprve klonovat požadovaný hlavní snímek ze zdrojové prezentace do cílové prezentace. Poté použijte klonovaný hlavní snímek při klonování snímku. Metoda [addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addClone) očekává hlavní snímek z cílové prezentace, nikoli ze zdrojové. Pro klonování snímku s hlavním snímkem postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) která obsahuje zdrojovou prezentaci, ze které bude snímek klonován.
2. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) která obsahuje cílovou prezentaci, do které bude snímek klonován.
3. Získejte přístup ke snímku, který má být klonován, spolu s hlavním snímkem.
4. Získejte objekt [MasterSlideCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslidecollection/) odkazováním na kolekci Masters vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) cílové prezentace.
5. Vyvolejte metodu [addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslidecollection/#addClone) vystavenou objektem [MasterSlideCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslidecollection/) a jako parametr předávejte hlavní snímek ze zdrojového PPTX, který má být klonován, metodě [addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslidecollection/#addClone).
6. Získejte objekt [SlideCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/) odkazováním na kolekci Slides vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) cílové prezentace.
7. Vyvolejte metodu [addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addClone) vystavenou objektem [SlideCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/) a předáte snímek ze zdrojové prezentace, který má být klonován, a hlavní snímek jako parametr metodě [addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addClone).
8. Uložte upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek s hlavním snímkem (nacházející se na nulovém indexu zdrojové prezentace) na konec cílové prezentace pomocí hlavního snímku zdrojového snímku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # Vytvořte instanci třídy Presentation pro cílovou prezentaci (kam bude snímek klonován)
    destination_presentation = Presentation()
    try:
        # Vytvořte instanci snímku ze sbírky snímků ve zdrojové prezentaci spolu s
        # hlavním snímkem
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # Klonujte požadovaný hlavní snímek ze zdrojové prezentace do sbírky hlavních snímků v
        # cílové prezentaci
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # Klonujte požadovaný snímek ze zdrojové prezentace s požadovaným hlavním snímkem na konec
        # sbírky snímků v cílové prezentaci
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # Uložte cílovou prezentaci na disk
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Klonovat snímek na konci určené sekce**

Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace, ale v jiné sekci, použijte metodu [**addClone**](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addClone) vystavenou třídou [**SlideCollection**](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/). Aspose.Slides pro Python přes Java umožňuje klonovat snímek z první sekce a poté vložit tento klonovaný snímek do druhé sekce stejné prezentace.

Následující ukázka kódu vám ukazuje, jak klonovat snímek a vložit klonovaný snímek do určené sekce.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # Uložte cílovou prezentaci na disk
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zajistit shodu velikosti snímku**

Při klonování snímků do jiné prezentace se ujistěte, že cílová prezentace má stejnou velikost snímku jako zdrojová. Pokud se velikosti snímků liší, Aspose.Slides automaticky nepřepočítá velikost klonovaných tvarů – jejich původní souřadnice a rozměry jsou zachovány, což může způsobit, že obsah bude nesprávně zarovnán nebo přesáhne hranice snímku.

Můžete nastavit velikost snímku cílové prezentace tak, aby odpovídala zdrojové, ještě před klonováním hlavního snímku a snímku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

Udělejte to před klonováním hlavního snímku a snímku.

## **Často kladené otázky**

**Klonují se poznámky k přednášejícímu a komentáře recenzenta?**

Ano. Stránka poznámek a recenzní komentáře jsou zahrnuty do klonu. Pokud je nechcete, [odstraňte je](/slides/cs/python-java/presentation-notes/) po vložení.

**Jak jsou zpracovány grafy a jejich datové zdroje?**

Objekt grafu, jeho formátování a vložená data jsou zkopírovány. Pokud byl graf propojen s externím zdrojem (např. se sešitem vloženým jako OLE), toto propojení je zachováno jako [OLE objekt](/slides/cs/python-java/manage-ole/). Po přesunu mezi soubory ověřte dostupnost dat a chování obnovy.

**Mohu ovládat pozici vložení a sekce pro klon?**

Ano. Můžete vložit klon na konkrétní index snímku a umístit jej do vybrané [sekce](/slides/cs/python-java/slide-section/). Pokud cílová sekce neexistuje, nejprve ji vytvořte a pak do ní přesuňte snímek.