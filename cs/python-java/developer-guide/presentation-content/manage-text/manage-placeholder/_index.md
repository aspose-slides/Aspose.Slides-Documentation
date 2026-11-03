---
title: Správa placeholderů v prezentaci v Pythonu
linktitle: Spravovat placeholdery
type: docs
weight: 10
url: /cs/python-java/manage-placeholder/
keywords:
- zástupný prvek
- textový placeholder
- obrázkový placeholder
- grafový placeholder
- obsahový placeholder
- výzva
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Naučte se, jak prohlížet a upravovat textové, obrázkové, grafové a obsahové placeholdery a pochopit dědičnost placeholderů pomocí Aspose.Slides pro Python prostřednictvím Java."
---
## **Přehled**

Placeholder je tvar, který rezervuje pozici pro konkrétní typ obsahu v šabloně prezentace. Běžnými příklady jsou titul, tělo, obrázek, graf a obecné placeholdery pro obsah. Na rozdíl od obyčejného tvaru může placeholder zdědit svou pozici, velikost, formátování a další nastavení z rozložení snímku nebo hlavního snímku.

Aspose.Slides zpřístupňuje informace o placeholderu pomocí metody [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder). Metoda vrací objekt [Placeholder](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/) nebo `None` pro normální tvar. Použijte [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) k určení, co má placeholder obsahovat.

Typ tvaru je i nadále důležitý, i když znáte typ placeholderu:

- Prázdný textový, obrázkový, grafový nebo obsahový placeholder je běžně reprezentován pomocí [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).
- Vyplněný obrázkový placeholder může být reprezentován pomocí [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/).
- Vyplněný grafový placeholder může být reprezentován pomocí [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/).
- Obsahový placeholder může obsahovat několik typů obsahu. Zkontrolujte jak [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType), tak runtime typ tvaru, místo abyste předpokládali, že každý placeholder je [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) popisuje roli placeholderu; nezaručuje runtime typ tvaru. Před přístupem k textovým, obrázkovým, grafovým, tabulkovým nebo mediálním členům vždy proveďte kontrolu typu.
{{% /alert %}}

## **Pochopení dědičnosti placeholderů**

Placeholdery tvoří hierarchii:

1. Hlavní snímek definuje znovupoužitelné styly a v některých případech placeholdery na úrovni hlavního snímku.
2. Rozložení snímku definuje uspořádání použité jedním nebo více běžnými snímky a může dědit z hlavního snímku.
3. Běžný snímek obsahuje placeholdery pro tento snímek a může dědit z jeho rozložení.

Zavolejte [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) pro posun o jednu úroveň výše v této hierarchii. Placeholder snímku obvykle vrací jeho placeholder rozložení; placeholder rozložení může vrátit jeho placeholder hlavního snímku. Metoda vrací `None`, pokud tvar nemá základní placeholder.

Následující příklad vypisuje placeholdery na první snímku a uvádí jejich základní placeholdery:

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

Úprava placeholderu na běžném snímku vytvoří nebo změní lokální přepsání pro tento snímek. Úprava souvisejícího rozložení nebo hlavního snímku může ovlivnit všechny snímky, které stále dědí toto nastavení. Lokální obyčejný tvar nemá základní placeholder a nezačíná dědit jen proto, že obsazuje stejné souřadnice.

## **Odstranění stavu placeholderu**

Při úpravě šablony použijte [Shape.removePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#removePlaceholder), aby existující objekt zůstal obyčejným tvarem. Jeho metoda [getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) vrací `None`, ale tvar zůstává v kolekci snímku. Oproti tomu [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) smaže tvar z této kolekce.

Následující příklad vyžaduje soubor `template.pptx` s alespoň jedním snímkem a neprázdným textovým placeholderem na prvním snímku. Použijte placeholder s formátováním zděděným z jeho rozložení nebo hlavního snímku, abyste viděli efekt odstranění tohoto vztahu. Příklad kontroluje, že stejný tvar zůstává, zavolá metodu znovu na nyní obyčejný tvar a výsledek uloží.

{{% alert color="warning" title="Warning" %}}
Odstranění stavu placeholderu automaticky neuchovává zděděná nastavení vzhledu. Níže uvedený příklad úmyslně nechává tato nastavení beze změny, takže výstup může vypadat odlišně. Tvar, jehož pozice a velikost jsou zcela zděděny, může po volání mít nulové souřadnice a rozměry a stát se neviditelným, i když zůstává v kolekci.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    found = False

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if not isinstance(shape, AutoShape):
            continue

        text_frame = shape.getTextFrame()
        if shape.getPlaceholder() is None or text_frame is None:
            continue
        text = text_frame.getText()
        if text is None or len(text) == 0:
            continue

        shape_count = slide.getShapes().size()
        shape.removePlaceholder()

        print(f"Placeholder removed: {shape.getPlaceholder() is None}")
        print(f"Same shape retained: {slide.getShapes().get_Item(index) == shape}")
        print(f"Shape count unchanged: {slide.getShapes().size() == shape_count}")

        # Volání metody na obyčejném tvaru nemá žádný efekt.
        shape.removePlaceholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx)
    else:
        print("No nonempty text placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

Pro odpovídající placeholder všechny tři kontroly vrátí `True`. Text zůstává, ale zděděná pozice, velikost, otáčení, písmo, zarovnání odstavců, okraje textového rámce, vertikální ukotvení, výplň a nastavení čáry se mohou změnit, když je vztah placeholderu odstraněn. Například zděděné formátování titulku může přejít na obyčejné formátování textu. Viz [Slide Layout](/slides/cs/python-java/slide-layout/) pro více informací o rozloženích.

Pro zachování zamýšleného vzhledu zachyťte vypočtenou pozici, velikost a otáčení před voláním a zkopírujte požadované hodnoty efektivního formátování do samostatných proměnných. Získejte tyto hodnoty pomocí [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) a [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective). Nespoléhejte se jen na objekty efektivního formátu, protože jejich hodnoty textového formátování se po odstranění vztahu mohou změnit. Výslovně aplikujte zachycené hodnoty na obyčejný tvar poté, včetně rodiny písma, velikosti, stylu, barvy, nastavení odstavců, nastavení textového rámce, výplně a čáry použité ve vaší šabloně.

Zděděná geometrie tvaru může také vyžadovat explicitní přiřazení přes [GeometryShape.setShapeType](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setShapeType). Pro obdélníkový textový placeholder to znamená přiřadit [ShapeType.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Rectangle); obnovení jen výplně a čáry nemusí obnovit viditelný obdélník. Šablony s doplňkovými efekty nebo složitějším formátováním vyžadují také ošetření těchto nastavení.

## **Změna textu v placeholderu**

Titulky, centrované titulky, podtitulky, těla a textové placeholdery obvykle podporují text. Před použitím metody [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame) zkontrolujte, že se jedná o [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).

Tento příklad aktualizuje první titulkový placeholder na prvním snímku a výsledek uloží:

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

Tento vzor zabraňuje zpracování obrázkových, grafových, tabulkových nebo mediálních placeholderů jako [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/). Také identifikuje placeholder podle účelu místo spoléhaní se na křehký index tvaru.

## **Nastavení výzvy v rozložení**

Výzva je návrhový text zobrazený v prázdném placeholderu, např. *Klikněte pro přidání titulku*. Nastavte vlastní výzvu na placeholderu rozložení místo toho, abyste se snažili získat jeho tvar z běžné kolekce snímku. Přístup k rozložení získáte pomocí [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) a iterujte přes kolekci vrácenou metodou [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes).

Následující příklad mění výzvy titulku a podtitulku v rozložení použitým na prvním snímku:

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

Výzva není běžným obsahem snímku. Je určena pro prázdné placeholdery v editačních aplikacích, jako je PowerPoint. Jakmile uživatel nebo program zadá skutečný obsah, výzva již není zobrazena. Změna výzvy také neodstraní existující text na snímcích, které rozložení používají.

## **Aktualizace obrázkového placeholderu**

Existují dva případy:

- Pokud je obrázkový placeholder již vyplněn a reprezentován pomocí [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), nahraďte obrázek pomocí [PictureFillFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#getPicture) a [Picture.setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage).
- Pokud je stále prázdný placeholder, přidejte obrázkový rámec na souřadnice placeholderu pomocí [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) a prázdný placeholder odstraňte.

Další příklad podporuje oba případy a prezentaci uloží:

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

Náhrada vytvořená pro prázdný placeholder je lokální obrázkový rámec, nikoli nový placeholder, protože [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) nemá setter. Zachovává rezervovanou pozici, ale již nezdědí chování specifické pro placeholder. Pokud je zachování vztahu placeholderu podstatné, připravte a naplňte placeholder v PowerPointu nejprve, pak aktualizujte vzniklý [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) pomocí Aspose.Slides.

Pro průhlednost obrázku, ořezání a další obrázkově specifické efekty viz [Manage Picture Frames](/slides/cs/python-java/picture-frame/). Tyto operace patří k obrázkovému rámci nebo výplni obrázku, nikoli k metadatům placeholderu.

## **Práce s grafovými a obsahovými placeholdery**

Vyplněný grafový placeholder může být reprezentován pomocí [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/). Tento příklad najde takový graf jak podle typu placeholderu, tak podle runtime typu, změní jeho titul a soubor uloží:

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

Obecný obsahový placeholder má obvykle [PlaceholderType.Object](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Object). V PowerPointu funguje jako spouštěč pro několik typů obsahu, včetně grafů, tabulek, diagramů, obrázků a médií. Po jeho vyplnění zkontrolujte skutečný typ tvaru, abyste zjistili, co obsahuje. Specializovaná rozložení mohou také vystavit [PlaceholderType.Chart](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Media) nebo [PlaceholderType.Diagram](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides nepřevádí prázdný [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) placeholder na [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) pouhým změněním [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType); typ nelze změnit pomocí API. Pro naplnění prázdného grafu nebo obsahové oblasti programově přidejte požadovaný objekt na souřadnice placeholderu a poté prázdný placeholder odstraňte. Následující příklad to provádí pro graf:

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

Přidaný graf je obyčejný lokální graf. Zabírá oblast placeholderu, ale nezdědí z placeholderu rozložení. Použijte specializované články o správě grafů [chart management articles](/slides/cs/python-java/powerpoint-charts/), když potřebujete nahradit jeho kategorie, řady nebo data sešitu.

## **Kompletní příklad: Aktualizace textu nebo obrázku**

Následující end‑to‑end příklad otevře šablonu, prohledá první snímek a najde buď titulkový, nebo obrázkový placeholder, zkontroluje typy placeholderu i tvaru, aktualizuje příslušný obsah a výsledek uloží. Příklad úmyslně nepředpokládá index tvaru ani nepracuje se všemi placeholdery jako se stejným typem.

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

## **Často kladené otázky**

**Co je základní placeholder?**

Základní placeholder je odpovídající tvar v rozložení nebo hlavním snímku, ze kterého jiný placeholder dědí. Použijte [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) k jeho získání. Obyčejný lokální tvar vrací `None`, protože není součástí hierarchie placeholderů.

**Mohu změnit všechny titulky snímků úpravou placeholderu v rozložení?**

Můžete změnit zděděné formátování nebo výzvu pomocí rozložení, ale existující text titulku je uložen na běžných snímcích. Pro nahrazení skutečného textu titulku v celé prezentaci iterujte přes snímky a aktualizujte každý titulkový placeholder.

**Jak spravuji placeholdery pro datum, číslo snímku, záhlaví a zápatí?**

Použijte správce záhlaví a zápatí na úrovni snímku, rozložení, hlavního snímku, poznámek nebo výstřižků. Viz [Manage Presentation Header and Footer](/slides/cs/python-java/presentation-header-and-footer/) pro kompletní příklady.