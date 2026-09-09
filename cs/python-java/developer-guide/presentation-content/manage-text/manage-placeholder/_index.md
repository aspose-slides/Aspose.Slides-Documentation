---
title: Správa placeholderů prezentace v Pythonu
linktitle: Správa placeholderů
type: docs
weight: 10
url: /cs/python-java/manage-placeholder/
keywords:
- placeholder
- textový placeholder
- obrázkový placeholder
- placeholder grafu
- obsahový placeholder
- výzva
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Naučte se, jak prozkoumat a upravit textové, obrázkové, grafické a obsahové placeholdery a pochopit dědičnost placeholderů pomocí Aspose.Slides pro Python přes Java."
---
## **Přehled**

Placeholder je tvar, který vyhrazuje pozici pro konkrétní typ obsahu v šabloně prezentace. Časté příklady jsou placeholdery pro název, tělo, obrázek, graf a obecný obsah. Na rozdíl od běžného tvaru může placeholder zdědit svou pozici, velikost, formátování a další nastavení z rozložení snímku nebo hlavního snímku.

Aspose.Slides zpřístupňuje informace o placeholderu prostřednictvím metody [Shape.getPlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getPlaceholder). Tato metoda vrací objekt [Placeholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/placeholder/) nebo `None` pro běžný tvar. Použijte [Placeholder.getType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/placeholder/#getType), abyste určili, co má placeholder obsahovat.

Typ tvaru je i nadále důležitý, i když znáte typ placeholderu:

- Prázdný textový, obrázkový, grafický nebo obsahový placeholder je běžně reprezentován pomocí [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/).
- Naplněný obrázkový placeholder může být reprezentován pomocí [PictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/).
- Naplněný grafický placeholder může být reprezentován pomocí [Chart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/).
- Obsahový placeholder může obsahovat několik druhů obsahu. Zkontrolujte jak [Placeholder.getType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/placeholder/#getType), tak i typ tvaru za běhu, místo toho, abyste předpokládali, že každý placeholder je [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/placeholder/#getType) popisuje roli placeholderu; nezaručuje typ tvaru za běhu. Vždy použijte kontrolu typu před přístupem k textovým, obrázkovým, grafickým, tabulkovým nebo mediálním členům.
{{% /alert %}}

## **Pochopit dědičnost placeholderů**

Placeholdery tvoří hierarchii:

1. Hlavní snímek definuje opakovaně použitelné styly a v některých případech placeholdery úrovně master.
2. Rozložení snímku definuje uspořádání použité na jednom nebo více normálních snímcích a může dědit z hlavního snímku.
3. Normální snímek obsahuje placeholdery pro daný snímek a může dědit ze svého rozložení.

Vyvolejte [Shape.getBasePlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getBasePlaceholder), abyste se posunuli o úroveň výš v této hierarchii. Placeholder snímku obvykle vrací svůj placeholder rozložení; placeholder rozložení může vrátit svůj master placeholder. Metoda vrátí `None`, pokud tvar nemá základní placeholder.

Následující příklad uvádí placeholdery na první snímku a vykazuje jejich základní placeholdery:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

Úprava placeholderu na normálním snímku vytvoří nebo změní místní přepis pro tento snímek. Úprava souvisejícího rozložení nebo masteru může ovlivnit všechny snímky, které stále dědí toto nastavení. Místní běžný tvar nemá základní placeholder a nezačne dědit jen proto, že zaujímá stejné souřadnice.

## **Změna textu v placeholderu**

Placeholdery pro název, centrovaný název, podtitul, tělo a text obvykle podporují text. Ověřte, že jde o [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) před použitím jeho [getTextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/#getTextFrame) metody.

Tento příklad aktualizuje první placeholder názvu na první snímku a uloží výsledek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Tento vzor zabraňuje zacházení s obrázkovými, grafickými, tabulkovými nebo mediálními placeholdery jako s [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/). Také identifikuje placeholder podle účelu místo spoléhaní se na křehký index tvaru.

## **Nastavení textu výzvy v rozložení**

Text výzvy je instrukce při návrhu zobrazovaná v prázdném placeholderu, např. *Click to add title*. Nastavte vlastní text výzvy na placeholderu rozložení místo toho, abyste se snažili dosáhnout na něj přes kolekci tvarů normálního snímku. Přístup k rozložení získáte pomocí [Slide.getLayoutSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getLayoutSlide) a projděte kolekci vrácenou metodou [BaseSlide.getShapes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/#getShapes).

Následující příklad mění výzvy pro název a podtitul v rozložení použitém na první snímku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Text výzvy není běžný obsah snímku. Je určen pro prázdné placeholdery v editačních aplikacích, jako je PowerPoint. Jakmile uživatel nebo program dodá skutečný obsah, výzva se již nezobrazuje. Změna výzvy také nenahrazuje existující text na snímcích, které používají dané rozložení.

## **Aktualizace obrázkového placeholderu**

Existují dva případy, které je třeba řešit:

- Pokud je obrázkový placeholder již naplněn a reprezentován pomocí [PictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/), nahraďte obrázek pomocí [PictureFillFormat.getPicture](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/#getPicture) a [Picture.setImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picture/#setImage).
- Pokud je stále prázdný placeholder, přidejte picture frame na souřadnice placeholderu pomocí [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addPictureFrame) a odstraňte prázdný placeholder.

Následující příklad podporuje oba případy a uloží prezentaci:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Náhrada vytvořená pro prázdný placeholder je místní picture frame, nikoli nový placeholder, protože [Shape.getPlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getPlaceholder) nenabízí setter. Zachová vyhrazenou pozici, ale již nedědí chování specifické pro placeholder. Pokud je zachování vztahu k placeholderu podstatné, připravte a naplňte placeholder v PowerPointu nejprve, poté aktualizujte vzniklý [PictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/) pomocí Aspose.Slides.

Pro průhlednost obrázku, ořezávání a další efekty specifické pro obrázek, viz [Manage Picture Frames](/slides/cs/python-java/picture-frame/). Tyto operace patří k picture frame nebo picture fill, nikoli k metadatům placeholderu.

## **Práce s grafickými a obsahovými placeholdery**

Naplněný grafický placeholder může být reprezentován pomocí [Chart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/). Tento příklad najde takový graf podle typu placeholderu i typu tvaru za běhu, změní jeho název a uloží soubor:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Obecný obsahový placeholder obvykle má typ [PlaceholderType.Object](https://reference.aspose.com/slides/cs/python-java/aspose.slides/placeholdertype/#Object). V PowerPointu funguje jako spouštěč pro několik typů obsahu, včetně grafů, tabulek, diagramů, obrázků a médií. Po naplnění zkontrolujte skutečný typ tvaru, abyste zjistili, co obsahuje. Specializovaná rozložení mohou také vystavit typy [PlaceholderType.Chart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/cs/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/cs/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/cs/python-java/aspose.slides/placeholdertype/#Media) nebo [PlaceholderType.Diagram](https://reference.aspose.com/slides/cs/python-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides nepřevádí prázdný [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) placeholder na [Chart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/) pouhým změněním [Placeholder.getType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/placeholder/#getType); typ nelze změnit přes API. Pro programové naplnění prázdného grafu nebo obsahové oblasti přidejte požadovaný objekt na souřadnice placeholderu a poté odstraňte prázdný placeholder. Následující příklad to provádí pro graf:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Přidaný graf je běžný místní graf. Zabírá oblast placeholderu, ale nedědí z placeholderu rozložení. Použijte specializované články o správě grafů [chart management articles](/slides/cs/python-java/powerpoint-charts/), když potřebujete nahradit jeho kategorie, řady nebo data sešitu.

## **Kompletní příklad: Aktualizace textového nebo obrazového obsahu**

Následující end-to-end příklad otevře šablonu, prohledá první snímek a najde buď placeholder názvu, nebo obrázku, zkontroluje typy placeholderu i tvaru, aktualizuje příslušný obsah a uloží výstup. Příklad úmyslně nevyužívá index tvaru ani nepřistupuje k placeholderům jako ke stejnému typu.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **FAQ**

**Co je základní placeholder?**

Základní placeholder je odpovídající tvar na rozložení nebo hlavním snímku, ze kterého jiný placeholder dědí. Použijte [Shape.getBasePlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getBasePlaceholder) pro jeho získání. Běžný místní tvar vrátí `None`, protože není součástí hierarchie placeholderů.

**Mohu změnit všechny názvy snímků úpravou placeholderu v rozložení?**

Můžete změnit děděné formátování nebo text výzvy prostřednictvím rozložení, ale existující text názvu je uložen na normálních snímcích. Pro nahrazení skutečného textu názvu napříč prezentací musíte projít všechny snímky a aktualizovat každý placeholder názvu.

**Jak spravovat placeholdery data, čísla snímku, hlavičky a paty?**

Použijte správce hlaviček a pat pomocí příslušného rozsahu – snímku, rozložení, masteru, poznámek nebo výstřižků. Viz [Manage Presentation Header and Footer](/slides/cs/python-java/presentation-header-and-footer/) pro kompletní ukázky.