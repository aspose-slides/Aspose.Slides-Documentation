---
title: Správa zástupných prvků prezentace v Pythonu
linktitle: Spravovat zástupné prvky
type: docs
weight: 10
url: /cs/python-net/manage-placeholder/
keywords:
- zástupný prvek
- textový zástupný prvek
- obrázkový zástupný prvek
- grafový zástupný prvek
- obsahový zástupný prvek
- výzva
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak inspektovat a upravovat textové, obrázkové, grafické a obsahové zástupné prvky a pochopit dědičnost zástupných prvků s Aspose.Slides pro Python pomocí .NET."
---
## **Přehled**

Zástupný prvek je tvar, který vyhrazuje pozici pro určitý typ obsahu v šabloně prezentace. Běžnými příklady jsou zástupné prvky pro název, tělo, obrázek, graf a obecný obsah. Na rozdíl od běžného tvaru může zástupný prvek zdědit svou pozici, velikost, formátování a další nastavení z rozvržení snímku nebo hlavního snímku.

Aspose.Slides poskytuje informace o zástupných prvcích prostřednictvím vlastnosti [Shape.placeholder](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/placeholder/). Vlastnost vrací objekt [Placeholder](https://reference.aspose.com/slides/cs/python-net/aspose.slides/placeholder/) nebo `None` pro běžný tvar. Použijte [Placeholder.type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/placeholder/type/), abyste zjistili, co má zástupný prvek obsahovat.

Třída tvaru je i nadále důležitá, i když znáte typ zástupného prvku:

- Prázdný textový, obrázkový, grafický nebo obsahový zástupný prvek je běžně reprezentován pomocí [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/).
- Vyplněný obrázkový zástupný prvek může být reprezentován pomocí [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/).
- Vyplněný grafový zástupný prvek může být reprezentován pomocí [Chart](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/).
- Obsahový zástupný prvek může obsahovat několik typů obsahu. Zkontrolujte jak [Placeholder.type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/placeholder/type/) tak třídu tvaru za běhu, místo abyste předpokládali, že každý zástupný prvek je [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/placeholder/type/) popisuje roli zástupného prvku; nezaručuje třídu tvaru za běhu. Vždy použijte kontrolu typu před přístupem k textovým, obrázkovým, grafickým, tabulkovým nebo mediálním členům.
{{% /alert %}}

## **Porozumění dědičnosti zástupných prvků**

Zástupné prvky tvoří hierarchii:

1. Hlavní snímek definuje znovupoužitelné styly a v některých případech i zástupné prvky na úrovni hlavního snímku.
2. Rozvržení snímku určuje uspořádání používané jedním nebo více běžnými snímky a může dědit z hlavního snímku.
3. Běžný snímek obsahuje zástupné prvky pro tento snímek a může dědit ze svého rozvržení.

Voláním [Shape.get_base_placeholder](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/get_base_placeholder/) se posunete o jednu úroveň výše v této hierarchii. Zástupný prvek snímku obvykle vrací svůj zástupný prvek rozvržení; zástupný prvek rozvržení může vrátit svůj hlavní zástupný prvek. Metoda vrací `None`, pokud tvar nemá základní zástupný prvek.

Následující příklad vypisuje zástupné prvky na prvním snímku a uvádí jejich základní zástupné prvky:

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

Úprava zástupného prvku na běžném snímku vytvoří nebo změní lokální přepsání pro tento snímek. Úprava souvisejícího rozvržení nebo hlavního snímku může ovlivnit všechny snímky, které stále dědí toto nastavení. Lokální běžný tvar nemá základní zástupný prvek a nezačíná dědit jen proto, že zabírá stejné souřadnice.

## **Změna textu v zástupném prvku**

Zástupné prvky pro název, centrovaný název, podtitul, tělo a text obvykle podporují text. Zkontrolujte, zda jde o [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) před použitím jeho [text_frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/text_frame/).

Následující příklad aktualizuje první zástupný prvek názvu na prvním snímku a uloží výsledek:

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

Tento vzor zabraňuje zacházení s obrázkovými, grafickými, tabulkovými nebo mediálními zástupnými prvky jako s objekty [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/). Také identifikuje zástupný prvek podle účelu místo spoléhání se na křehký index tvaru.

## **Nastavení výzvy v rozvržení**

Výzva (prompt text) je návrhový pokyn zobrazený v prázdném zástupném prvku, například *Klikněte pro přidání názvu*. Nastavte vlastní výzvu na zástupném prvku rozvržení místo toho, abyste se snažili získat ji přes kolekci tvarů běžného snímku. Přístup k rozvržení získáte přes [Slide.layout_slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/layout_slide/) a iterujte přes [LayoutSlide.shapes](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslide/shapes/).

Následující příklad mění výzvy názvu a podtitulu v rozvržení použitým na první snímek:

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

Výzva není běžný obsah snímku. Je určena pro prázdné zástupné prvky v editačních aplikacích, jako je PowerPoint. Jakmile uživatel nebo program dodá skutečný obsah, výzva se již nezobrazuje. Změna výzvy také nenahrazuje existující text na snímcích, které rozvržení používají.

## **Aktualizace obrázkového zástupného prvku**

Existují dva případy, které je třeba řešit:

- Pokud je obrázkový zástupný prvek již vyplněn a reprezentován pomocí [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/), nahraďte obrázek pomocí [PictureFillFormat.picture](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/picture/) a [Picture.image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picture/image/).
- Pokud je stále prázdný zástupný prvek, přidejte obrázkový rám na souřadnice zástupného prvku pomocí [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_picture_frame/) a odstraňte prázdný zástupný prvek.

Následující příklad podporuje oba případy a ukládá prezentaci:

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

Náhrada vytvořená pro prázdný zástupný prvek je lokální obrázkový rám, nikoli nový zástupný prvek, protože [Shape.placeholder](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/placeholder/) je jen pro čtení. Uchovává vyhrazenou pozici, ale již nedědí chování specifické pro zástupné prvky. Pokud je zachování vztahu k zástupnému prvku podstatné, připravte a vyplňte zástupný prvek nejprve v PowerPointu, poté aktualizujte vzniklý [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/) pomocí Aspose.Slides.

Pro průhlednost obrázku, ořezávání a další efekty specifické pro obrázek viz [Manage Picture Frames](/slides/cs/python-net/picture-frame/). Tyto operace patří k obrázkovému rámci nebo výplni obrázku, nikoli k metadatům zástupného prvku.

## **Práce s grafovými a obsahovými zástupnými prvky**

Vyplněný grafový zástupný prvek může být reprezentován pomocí [Chart](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/). Tento příklad najde takový graf jak podle typu zástupného prvku, tak podle třídy tvaru za běhu, změní jeho název a uloží soubor:

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

Obecný obsahový zástupný prvek má obvykle [PlaceholderType.OBJECT](https://reference.aspose.com/slides/cs/python-net/aspose.slides/placeholdertype/). V PowerPointu funguje jako spouštěč pro několik typů obsahu, včetně grafů, tabulek, diagramů, obrázků a médií. Po jeho vyplnění zkontrolujte skutečnou třídu tvaru, abyste zjistili, co obsahuje. Specializovaná rozvržení mohou také vystavovat [PlaceholderType.CHART](https://reference.aspose.com/slides/cs/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/cs/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/cs/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/cs/python-net/aspose.slides/placeholdertype/), nebo [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/cs/python-net/aspose.slides/placeholdertype/).

Aspose.Slides nepřevádí prázdný [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) zástupný prvek na [Chart](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/) pouhým změněním [Placeholder.type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/placeholder/type/); typ je jen pro čtení. Pro programové vyplnění prázdné oblasti grafu nebo obsahu přidejte požadovaný objekt na souřadnice zástupného prvku a poté odstraňte prázdný zástupný prvek. Následující příklad to provádí pro graf:

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

Přidaný graf je běžný lokální graf. Zaujímá oblast zástupného prvku, ale nedědí z rozvržení zástupného prvku. Použijte vyhrazené [chart management articles](/slides/cs/python-net/powerpoint-charts/), když potřebujete nahradit jeho kategorie, řady nebo data sešitu.

## **Kompletní příklad: Aktualizace textového nebo obrazového obsahu**

Následující komplexní příklad otevře šablonu, prohledá první snímek na zástupný prvek názvu nebo obrázku, zkontroluje typy zástupného prvku a tvaru, aktualizuje příslušný obsah a uloží výstup. Příklad úmyslně nevyužívá předpoklad o indexu tvaru ani nepřistupuje ke každému zástupnému prvku jako ke stejné třídě tvaru.

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

## **FAQ**

**Co je základní zástupný prvek?**

Základní zástupný prvek je odpovídající tvar na rozvržení nebo hlavním snímku, ze kterého další zástupný prvek dědí. Použijte [Shape.get_base_placeholder](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/get_base_placeholder/) k jeho získání. Běžný lokální tvar vrací `None`, protože není součástí hierarchie zástupných prvků.

**Mohu změnit všechny názvy snímků úpravou zástupného prvku v rozvržení?**

Můžete změnit zděděné formátování nebo výzvu prostřednictvím rozvržení, ale existující obsah názvu je uložen na běžných snímcích. Pro nahrazení skutečného textu názvu v celé prezentaci iterujte přes snímky a aktualizujte každý zástupný prvek názvu.

**Jak spravovat zástupné prvky data, čísla snímku, záhlaví a zápatí?**

Použijte správce záhlaví a zápatí na odpovídajícím úrovni snímku, rozvržení, hlavního snímku, poznámek či výstřižků. Viz [Manage Presentation Header and Footer](/slides/cs/python-net/presentation-header-and-footer/) pro úplné příklady.