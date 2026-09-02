---
title: Správa obrázkových rámců v prezentacích s Pythonem
linktitle: Obrázkový rám
type: docs
weight: 10
url: /cs/python-net/picture-frame/
keywords:
- obrázkový rám
- přidat obrázkový rám
- vytvořit obrázkový rám
- vložený obrázek
- propojený obrázek
- extrahovat obrázek
- rastrový obrázek
- SVG obrázek
- ořezat obrázek
- smazat ořezané oblasti
- komprimovat obrázek
- StretchOffset
- formátování obrázkového rámu
- relativní měřítko
- efekt obrázku
- poměr stran
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Vytvářejte, formátujte, odkazujte, ořezávejte, extrahujte a komprimujte obrázkové rámy v prezentacích pomocí Aspose.Slides pro Python přes .NET."
---
## **Přehled**

Obrázkový rám je tvar snímku, který zobrazuje obrázek. V Aspose.Slides jsou zdrojový obrázek a tvar, který jej zobrazuje, oddělené objekty: [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) vlastní vložené obrázkové zdroje prostřednictvím své [ImageCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imagecollection/), zatímco [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/) řídí pozici obrázku, velikost, formátování čáry, otočení, ořez, efekty obrázku a další nastavení na úrovni rámu.

Toto oddělení je užitečné, když je stejný obrázek zobrazen vícekrát. Přidejte obrázek do prezentace jednou, uchovejte vrácený [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/), a použijte tento zdroj obrázku při vytváření obrázkových rámů.

Obrázkové rámce mohou obsahovat rastrové obrázky jako PNG nebo JPEG a vektorové SVG obrázky. Mohou také odkazovat na propojené obrázky místo uložení bajtů obrázku v prezentaci. Volba ovlivňuje přenositelnost, velikost souboru, extrakci a chování při exportu, takže je užitečné rozhodnout, jak má být obrázek uložen, ještě před aplikací formátování nebo optimalizace.

## **Přidání a formátování vloženého obrázku**

U vloženého obrázku přidejte data obrázku do prezentace a vytvořte obrázkový rám pomocí [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_picture_frame/). Obrázek se stane součástí balíčku prezentace, takže prezentace zůstane samostatná při přesunu na jiný počítač.

Následující příklad přidává JPEG obrázek, vytváří rám v původních rozměrech obrázku a aplikuje formátování čáry a otočení:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Obrázkový rám řídí zobrazovanou geometrii; změna velikosti rámu nemění původní rozměry pixelů uložených ve vloženém zdroji obrázku. Toto rozlišení je důležité při pozdějším ořezávání nebo kompresi obrázku.

## **Použití relativní měřítka**

[PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/) poskytuje [relative_scale_width](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/relative_scale_width/) a [relative_scale_height](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/relative_scale_height/) pro rám. Hodnota `1.0` odpovídá 100 % původní velikosti obrázku. Relativní měřítko je užitečné, když workflow potřebuje zachovat vztah k velikosti zdrojového obrázku místo ručního výpočtu konečných rozměrů.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

Relativní měřítko mění nastavení měřítka rámu; nepřevzorkuje ani nekonprimuje vložený obrázek.

## **Vložené a propojené obrázky**

Vložený obrázek ukládá data obrázku uvnitř prezentace a je proto nejbezpečnější volbou pro přenositelnost a předvídatelné vykreslování. Propojený obrázek ukládá externí umístění pomocí cesty [Picture](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picture/) místo vložení dat obrázku stejným způsobem.

Propojené obrázky mohou snížit množství dat uložených v PPTX, ale zavádějí externí závislost. Propojený soubor musí zůstat přístupný aplikaci, která prezentaci otevírá nebo vykresluje. Pokud se cesta změní, soubor se přesune nebo zdroj není dostupný, může se propojený obrázek nezobrazit podle očekávání. Pro prezentace, které mají být zasílány e‑mailem, archivovány nebo vykreslovány v izolovaných prostředích, jsou vložené obrázky obvykle spolehlivější.

### **Přidání propojeného obrázku**

Následující příklad vytváří obrázkový rám a odkazuje na lokální soubor obrázku. Zabývá se pouze odkazováním na obrázek; odkazování na video je samostatný mediální workflow a záměrně není v tomto příkladu smícháno.

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Používejte odkazy, když je externí správa souborů záměrem. Nepoužívejte je jen jako náhradu komprese: malý PPTX s nefunkčními závislostmi na obrázcích je obvykle méně užitečný než větší samostatná prezentace.

## **Extrahování obrázků z obrázkových rámů**

Před extrahováním obrázku z existující prezentace ověřte, že tvar je skutečně [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/) a že obsahuje vložený obrázek. Propojené obrázkové rámce nemusí obsahovat bajty obrázku, které lze extrahovat stejným způsobem.

### **Extrahování rastrového obrázku**

Moderní API obrázku používá přímo [IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/). Následující příklad najde první vložený rastrový obrázek na snímku a uloží jej jako PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

Ukládání přes [IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/) převádí extrahovaný obrázek do požadovaného výstupního formátu. Pokud potřebujete kódované bajty uložené v prezentaci místo konvertovaného rastrového souboru, použijte vlastnost [PPImage.binary_data](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/binary_data/).

### **Extrahování SVG obrázku**

Pro SVG obrázek poskytuje [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) objekt [SvgImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/svgimage/). To vám umožní získat SVG data přímo místo rasterizace obrázku nejprve.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

Uchování SVG obsahu jako SVG zachovává vektorový zdroj uvnitř prezentace. Rasterové exporty jako PNG nebo JPEG nutně renderují tento vektorový obsah do pixelů. Export snímku do PDF nebo SVG je také renderovací operací, takže exportovaná grafika by neměla být považována za bit‑po‑bitu kopii původního vloženého SVG; použijte vložený [SvgImage.svg_data](https://reference.aspose.com/slides/cs/python-net/aspose.slides/svgimage/svg_data/), pokud je požadován původní vektorový zdroj.

## **Ořez obrázku**

Ořez mění, která část obrázku je viditelná uvnitř rámu. Hodnoty ořezu na [PictureFillFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/) jsou procenta rozměrů zdrojového obrázku. Ořez neodstraňuje skryté pixely z vloženého obrázku; pouze mění viditelnou oblast.

Následující příklad bezpečně najde obrázkový rám a aplikuje hodnoty ořezu:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

Protože skrytá data obrázku jsou stále přítomna, lze ořez později změnit bez ztráty původních pixelů. Pokud je velikost souboru důležitější než reverzibilita, lze ořezané oblasti fyzicky odstranit, jak je popsáno v následující sekci.

## **Odstranění ořezaných dat obrázku**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) odstraňuje data obrázku mimo aktuální ořezový obdélník a vrací výsledný zdroj obrázku. To může snížit velikost souboru, ale jedná se o destruktivní optimalizaci: po uložení prezentace jsou odstraněné pixely již nedostupné pro pozdější operaci "uncrop".

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

Metoda může přidat nový zdroj obrázku do prezentace. Pokud je původní obrázek také používán jinými obrázkovými rámci, tyto rámce stále potřebují svůj existující zdroj, takže mazání ořezaných oblastí nutně nesnižuje celkový počet obrázků. Ořez WMF nebo EMF pomocí této metody rasterizuje ořezaný výsledek do PNG.

## **Kompresní rastrových obrázků**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/compress_image/) snižuje rozlišení rastrového obrázku relativně k velikosti, v jaké je obrázek zobrazován. Může také odstranit ořezané oblasti ve stejném kroku. Metoda vrací `True`, když byl obrázek změněn velikostí nebo oříznut, a `False`, když změna nebyla potřebná.

Použijte předdefinovanou hodnotu [PicturesCompression](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/picturescompression/), když stačí standardní cílové rozlišení:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

Místo hodnoty výčtu lze předat vlastní kladnou hodnotu DPI, pokud je požadován konkrétní cíl.

Komprese je určena pro rastrové obrázky. SVG a metafile obsah není tímto rastrovým kompresním workflow zmenšován. Také si pamatujte, že nižší rozlišení a smazané ořezané oblasti nelze z optimalizované prezentace obnovit. Vyberte cílové rozlišení na základě největší velikosti, při které bude obrázek skutečně zobrazován nebo exportován, místo aby se globálně používalo nejnižší DPI.

## **Správa transformačních efektů obrázku**

Pro kompletní workflow zahrnující jas, kontrast, barevné transformace, rozostření, alfa efekty, řetězce, inspekci, odstranění a ověření round‑trip viz [Image Transform Effects](/slides/cs/python-net/image-transform-effects/).

## **Uzamčení geometrie obrázkového rámu**

Nastavení [PictureFrameLock](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframelock/) řídí, které úpravy jsou pro obrázkový rám zakázány. Například vlastnost [aspect_ratio_locked](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) zachovává proporce tvaru při změně velikosti.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Uzamčení se vztahuje na tvar obrázkového rámu. Nepřinutí zdrojový obrázek, aby byl převeden nebo trvale změněn na stejný poměr stran.

## **Úprava hodnot StretchOffset**

Když je režim výplně obrázku nastaven na stretch, hodnoty stretch‑offset na [PictureFillFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/) určují výplňový obdélník relativně k ohraničujícímu rámečku obrázkového rámu. Kladná procenta vytvářejí vnitřní odsazení od okraje, záporná procenta vytvářejí vnější odsazení.

To se liší od ořezu. Hodnoty ořezu vybírají, která část zdrojového obrázku je viditelná; stretch offset mění obdélník, do kterého je viditelná výplň obrázku roztáhnuta.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

Používejte stretch offset pro umístění výplně. Používejte ořezové vlastnosti, když je cílem skrýt okraje zdrojového obrázku.

## **Úložiště, velikost souboru a úvahy o exportu**

Hlavní kompromisy jsou snadněji říditelné, když jsou uložení obrázků a formátování obrázkových rámů řešeny odděleně:

- **Vložené obrázky** dělají prezentaci samostatnou a jsou nejspolehlivější pro sdílení a server‑side rendering, ale velké rastrové obrázky zvyšují velikost PPTX a spotřebu paměti.
- **Propojené obrázky** mohou udržet balíček menší, ale prezentace závisí na dostupnosti externích souborů na uložených cestách nebo umístěních.
- **Ořez** je zpočátku nedestruktivní. Skryté pixely zůstávají vloženy, dokud nejsou ořezané oblasti výslovně smazány nebo odstraněny během komprese.
- **Komprese** může výrazně snížit velikost souboru u příliš velkých rastrových obrázků, ale snižuje rozlišení zdroje. Měla by být aplikována po určení zamýšlené velikosti na snímku.
- **SVG obrázky** by měly zůstat jako SVG, když je důležitá zachování vektoru. Extrahujte vložené SVG přímo, když potřebujete samotný vektorový zdroj. Rasterové exporty snímků vždy převádějí vykreslený snímek na pixely.
- **Opakované obrázky** by měly opakovaně používat existující zdroj [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/), pokud je to možné, místo opakovaného načítání stejného souboru do workflow prezentace.

U velkých prezentací je optimalizace obrázků obvykle nejúčinnější, když je prováděna selektivně: loga a diagramy ponechte jako vektorový obsah, komprimujte fotografie podle jejich skutečné velikosti zobrazení, odstraňujte ořezané pixely jen tehdy, když není potřeba další úpravy, a vyhněte se externím odkazům, pokud není řízení závislostí součástí nasazovacího designu.

## **Často kladené otázky**

**Jaký je rozdíl mezi obrázkovým rámem a zdrojem obrázku?**

[PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) představuje zdroj obrázku spojený s prezentací. [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/) je tvar na snímku, který zobrazuje obrázek a ukládá geometrické a formátovací informace na úrovni rámu, jako jsou velikost, otočení, hodnoty ořezu, efekty a zamčení.

**Mám obrázky vkládat nebo propojovat?**

Vkládejte obrázky, když musí být prezentace přenosná, archivovaná nebo vykreslovaná bez přístupu k externím zdrojům. Propojujte obrázky jen tehdy, když je úmyslné mít soubory obrázků mimo PPTX a externí umístění lze spolehlivě udržovat.

**Snižuje ořez velikost souboru PPTX?**

Samotný ořez ne. Normální nastavení ořezu skryje části zdrojového obrázku, ale uchovává podkladové pixely. Použijte [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) nebo kompresi obrázku s odstraněním ořezaných oblastí, když lze tyto pixely trvale zahodit.

**Mohu po kompresi obnovit kvalitu obrázku?**

Ne. Komprese může snížit uložené rastrové rozlišení a odstranění ořezaných oblastí ztrácí data obrázku. Uchovávejte původní zdrojový obrázek mimo prezentaci, pokud může být později potřeba úprava ve vysokém rozlišení.

**Jak by měly být zacházeno se SVG obrázky?**

Uchovávejte SVG obsah jako SVG, když je důležitá věrnost vektoru. Vložený [SvgImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/svgimage/) lze extrahovat přímo. Rendering snímku do rastrového formátu, jako je PNG nebo JPEG, rasterizuje SVG jako součást obrázku snímku.

**Jak mohu předejít nebezpečným přetypováním při čtení existujících snímků?**

Zkontrolujte typ tvaru před použitím členů specifických pro obrázkový rám. Použití `isinstance(shape, slides.PictureFrame)` zabraňuje neplatným přetypováním a umožňuje kódu správně zacházet se snímky, které neobsahují obrázkové rámce.