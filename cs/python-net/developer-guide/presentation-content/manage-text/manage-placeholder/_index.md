---
title: Správa zástupných objektů prezentace v Pythonu
linktitle: Spravovat zástupné objekty
type: docs
weight: 10
url: /cs/python-net/manage-placeholder/
keywords:
- zástupný objekt
- textový zástupný objekt
- obrázkový zástupný objekt
- grafický zástupný objekt
- obsahový zástupný objekt
- výzva text
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak kontrolovat a upravovat textové, obrázkové, grafické a obsahové zástupné objekty a pochopit dědičnost zástupných objektů pomocí Aspose.Slides pro Python via .NET."
---
## **Přehled**

Zástupný objekt je tvar, který vyhrazuje pozici pro konkrétní typ obsahu v šabloně prezentace. Mezi běžné příklady patří zástupné objekty pro název, tělo, obrázek, graf a obecný obsah. Na rozdíl od běžného tvaru může zástupný objekt dědit svou pozici, velikost, formátování a další nastavení z rozložení snímku nebo hlavního snímku.

Aspose.Slides poskytuje informace o zástupných objektech prostřednictvím vlastnosti [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/). Vlastnost vrací objekt [Placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/) nebo `None` pro běžný tvar. Použijte [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) k určení, co má zástupný objekt obsahovat.

Třída tvaru má stále význam poté, co znáte typ zástupného objektu:

- Prázdný textový, obrázkový, grafový nebo obsahový zástupný objekt je běžně reprezentován pomocí [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
- Naplněný obrázkový zástupný objekt může být reprezentován pomocí [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).
- Naplněný grafový zástupný objekt může být reprezentován pomocí [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/).
- Obsahový zástupný objekt může obsahovat několik typů obsahu. Zkontrolujte jak [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/), tak třídu tvaru v době běhu, místo abyste předpokládali, že každý zástupný objekt je [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) popisuje roli zástupného objektu; negarantuje třídu tvaru v době běhu. Vždy použijte kontrolu typu před přístupem k textu, obrázku, grafu, tabulce nebo mediálním členům.
{{% /alert %}}

## **Pochopení dědičnosti zástupných objektů**

Zástupné objekty vytvářejí hierarchii:

1. Hlavní snímek definuje znovupoužitelné styly a v některých případech hlavní úrovňové zástupné objekty.
2. Rozvržení snímku určuje uspořádání používané jedním nebo více normálními snímky a může dědit z hlavního snímku.
3. Normální snímek obsahuje zástupné objekty pro daný snímek a může dědit ze svého rozvržení.

Vyvolejte [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) pro posun o jednu úroveň výš v této hierarchii. Zástupný objekt snímku obvykle vrací svůj zástupný objekt rozvržení; zástupný objekt rozvržení může vrátit svůj hlavní zástupný objekt. Metoda vrací `None`, když tvar nemá základní zástupný objekt.

Následující příklad vypíše zástupné objekty na prvním snímku a uvádí jejich základní zástupné objekty:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

Editace zástupného objektu na normálním snímku vytvoří nebo změní místní přepsání pro tento snímek. Úprava souvisejícího rozvržení nebo hlavního snímku může ovlivnit všechny snímky, které stále dědí dané nastavení. Místní běžný tvar nemá základní zástupný objekt a nezačne dědit jen proto, že obsazuje stejné souřadnice.

## **Odstranit stav zástupného objektu**

Při úpravě šablony použijte [Shape.remove_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/remove_placeholder/) pro zachování existujícího objektu jako běžného tvaru. Jeho vlastnost [placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) se stane `None`, ale tvar zůstane ve sbírce snímku. Naopak [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) odstraní tvar z této sbírky.

Následující příklad vyžaduje `template.pptx` s alespoň jedním snímkem a neprázdným textovým zástupným objektem na prvním snímku. Použijte zástupný objekt s formátováním děděným z jeho rozvržení nebo hlavního snímku, abyste viděli dopad odstranění tohoto vztahu. Příklad kontroluje, že stejný tvar zůstane, znovu zavolá metodu na nyní běžném tvaru a výsledek uloží.

{{% alert color="warning" title="Warning" %}}
Odstranění stavu zástupného objektu automaticky neuchovává děděné nastavení vzhledu. Níže uvedený příklad úmyslně ponechává tato nastavení nezměněna, takže výstup může vypadat odlišně. Tvar, jehož pozice a velikost jsou zcela děděny, může po volání mít nulové souřadnice a rozměry a stát se neviditelným, i když zůstane ve sbírce.
{{% /alert %}}

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    found = False

    for index in range(len(slide.shapes)):
        shape = slide.shapes[index]
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue
        if shape.text_frame is None or not shape.text_frame.text:
            continue

        shape_count = len(slide.shapes)
        shape.remove_placeholder()

        print(f"Placeholder removed: {shape.placeholder is None}")
        print(f"Same shape retained: {slide.shapes[index] == shape}")
        print(f"Shape count unchanged: {len(slide.shapes) == shape_count}")

        # Volání metody na běžném tvaru nemá žádný vliv.
        shape.remove_placeholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("No nonempty text placeholder was found on the first slide.")
```

Pro odpovídající zástupný objekt všechny tři kontroly vypíšou `True`. Text zůstane, ale děděná pozice, velikost, rotace, písmo, zarovnání odstavce, okraje textového rámce, svislé ukotvení, výplň a nastavení čáry se mohou po odstranění vztahu změnit. Například děděné formátování názvu může přejít na běžné formátování textu. Viz [Slide Layout](/slides/cs/python-net/slide-layout/) pro více informací o rozvrženích.

Pro zachování zamýšleného vzhledu zachyťte vyřešenou pozici, velikost a rotaci před voláním a zkopírujte požadované efektivní hodnoty formátování do samostatných proměnných. Získejte tyto hodnoty přes [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/), [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/), [TextFrameFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/get_effective/), [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/), a [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/). Nespoléhejte se pouze na objektu efektivního formátu, protože jejich hodnoty formátování textu se mohou po odstranění vztahu změnit. Výslovně aplikujte zachycené hodnoty na běžný tvar poté, včetně rodiny písma, velikosti, stylu, barvy, nastavení odstavce, nastavení textového rámce, výplně a čáry používané ve vaší šabloně.

Děděná geometrie tvaru může také vyžadovat explicitní přiřazení přes [GeometryShape.shape_type](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/shape_type/). Pro obdélníkový textový zástupný objekt to znamená přiřadit [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/); obnovení jen výplně a čáry nemusí obnovit viditelný obdélník. Šablony s dalšími efekty nebo složitějším formátováním vyžadují, aby byla tato nastavení také ošetřena.

## **Změnit text v zástupném objektu**

Název, centrovaný název, podtitul, tělo a textové zástupné objekty normálně podporují text. Před použitím vlastnosti [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) zkontrolujte, zda jde o [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).

Tento příklad aktualizuje první zástupný objekt názvu na prvním snímku a výsledek uloží:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Tento vzor zabraňuje zacházení s obrázkovými, grafovými, tabulkovými nebo mediálními zástupnými objekty jako s [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) objekty. Také identifikuje zástupný objekt podle účelu místo spoléhaní se na křehký index tvaru.

## **Nastavit výzvu textu v rozvržení**

Výzva textu je instrukce v čase návrhu zobrazovaná v prázdném zástupném objektu, například *Klikněte pro přidání názvu*. Nastavte vlastní výzvu textu na zástupný objekt rozvržení místo pokusu o dosažení přes sbírku tvarů normálního snímku. Přístup k rozvržení získáte přes [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) a iterujte přes [LayoutSlide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/).

Následující příklad mění výzvy názvu a podtitulku v rozvržení použitým na prvním snímku:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

Výzva textu není běžný obsah snímku. Je určena pro prázdné zástupné objekty v editačních aplikacích, jako je PowerPoint. Jakmile uživatel nebo program dodá skutečný obsah, výzva se již nezobrazuje. Změna výzvy také nenahrazuje existující text na snímcích, které rozvržení používají.

## **Aktualizovat obrázkový zástupný objekt**

Existují dva případy, které je třeba řešit:

- Pokud je obrázkový zástupný objekt již naplněn a reprezentován pomocí [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), nahraďte obrázek přes [PictureFillFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture/) a [Picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/).
- Pokud je stále prázdný zástupný objekt, přidejte rámeček obrázku na souřadnice zástupného objektu pomocí [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) a odstraňte prázdný zástupný objekt.

Další příklad podporuje oba případy a prezentaci uloží:

```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Náhrada vytvořená pro prázdný zástupný objekt je místní rámeček obrázku, ne nový zástupný objekt, protože [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) je jen pro čtení. Zachovává vyhrazenou pozici, ale již nedědí chování specifické pro zástupný objekt. Pokud je zachování vztahu zástupného objektu podstatné, připravte a naplňte zástupný objekt v PowerPointu nejprve, pak aktualizujte vzniklý [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) pomocí Aspose.Slides.

Pro průhlednost obrázku, ořezávání a další efekty specifické pro obrázek viz [Manage Picture Frames](/slides/cs/python-net/picture-frame/). Tyto operace patří ke rámečku obrázku nebo výplni obrázku, nikoli k metadatům zástupného objektu.

## **Práce s grafem a obsahovými zástupnými objekty**

Naplněný grafový zástupný objekt může být reprezentován pomocí [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/). Tento příklad najde takový graf jak podle typu zástupného objektu, tak podle runtime třídy, změní jeho název a soubor uloží:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Obecný obsahový zástupný objekt obvykle má [PlaceholderType.OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/). V PowerPointu funguje jako spouštěč pro několik typů obsahu, včetně grafů, tabulek, diagramů, obrázků a médií. Po naplnění zkontrolujte skutečnou třídu tvaru, abyste zjistili, co obsahuje. Speciální rozvržení může také vystavovat [PlaceholderType.CHART](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), nebo [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/).

Aspose.Slides nepřemění prázdný [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) zástupný objekt na [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) pouhým změněním [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/); typ je jen pro čtení. Pro naplnění prázdného grafu nebo obsahové oblasti programově přidejte požadovaný objekt na souřadnice zástupného objektu a poté odstraňte prázdný zástupný objekt. Následující příklad to provádí pro graf:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

Přidaný graf je běžný místní graf. Zabírá oblast zástupného objektu, ale nedědí z rozvržení zástupného objektu. Použijte věnované [chart management articles](/slides/cs/python-net/powerpoint-charts/) když potřebujete nahradit jeho kategorie, řady nebo data sešitu.

## **Úplný příklad: Aktualizovat text nebo obsah obrázku**

Následující end-to-end příklad otevře šablonu, vyhledá na prvním snímku buď zástupný objekt názvu nebo obrázku, zkontroluje typy zástupného objektu a tvaru, aktualizuje příslušný obsah a výstup uloží. Příklad úmyslně nevyužívá předpoklad indexu tvaru ani nepracuje se všemi zástupnými objekty jako se stejnou třídou tvaru.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Co je základní zástupný objekt?**

Základní zástupný objekt je odpovídající tvar v rozvržení nebo hlavě, ze kterého další zástupný objekt dědí. Použijte [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) pro jeho získání. Běžný místní tvar vrací `None`, protože není součástí hierarchie zástupných objektů.

**Mohu změnit všechny názvy snímků úpravou zástupného objektu v rozvržení?**

Můžete měnit děděné formátování nebo výzvu textu prostřednictvím rozvržení, ale existující název snímku je uložen na normálních snímcích. Pro nahrazení skutečného textu názvu v celé prezentaci iterujte přes snímky a aktualizujte každý zástupný objekt názvu.

**Jak spravovat zástupné objekty data, čísla snímků, záhlaví a zápatí?**

Použijte správce záhlaví a zápatí na úrovni odpovídajícího snímku, rozvržení, hlavního snímku, poznámek nebo výstřižku. Viz [Manage Presentation Header and Footer](/slides/cs/python-net/presentation-header-and-footer/) pro kompletní příklady.