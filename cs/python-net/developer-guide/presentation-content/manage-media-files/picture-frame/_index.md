---
title: Spravovat rámečky obrázků v prezentacích pomocí Pythonu
linktitle: Rámeček obrázku
type: docs
weight: 10
url: /cs/python-net/picture-frame/
keywords:
- rámeček obrázku
- přidat rámeček obrázku
- vytvořit rámeček obrázku
- vložený obrázek
- propojený obrázek
- extrahovat obrázek
- rastrový obrázek
- SVG obrázek
- oříznout obrázek
- smazat ořezané oblasti
- komprimovat obrázek
- StretchOffset
- formátování rámečku obrázku
- relativní měřítko
- efekt obrázku
- poměr stran
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Vytvářejte, formátujte, propojujte, ořezávejte, extrahujte a komprimujte rámečky obrázků v prezentacích pomocí Aspose.Slides pro Python na platformě .NET."
---
## **Přehled**

Rámeček obrázku je tvar slidu, který zobrazuje obrázek. V Aspose.Slides jsou zdroj obrázku a tvar, který jej zobrazuje, samostatné objekty: prezentace [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) vlastní vložené zdroje obrázků prostřednictvím své [ImageCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imagecollection/), zatímco [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/) řídí pozici obrázku, velikost, formátování čáry, otáčení, ořez, efekty obrázku a další nastavení na úrovni rámečku.

Toto oddělení je užitečné, když se stejný obrázek zobrazí vícekrát. Přidejte obrázek do prezentace jednou, uložte vrácený [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/), a použijte tento zdroj obrázku při vytváření rámečků obrázků.

Rámečky obrázků mohou obsahovat rastrové obrázky, jako jsou PNG nebo JPEG, a vektorové SVG obrázky. Mohou také odkazovat na propojené obrázky místo ukládání bajtů obrázku v prezentaci. Volba ovlivňuje přenositelnost, velikost souboru, extrakci a chování při exportu, takže je užitečné rozhodnout, jak má být obrázek uložen, ještě před aplikací formátování nebo optimalizace.

## **Přidání a formátování vloženého obrázku**

Pro vložený obrázek přidejte data obrázku do prezentace a vytvořte rámeček obrázku pomocí [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_picture_frame/). Obrázek se stane součástí balíčku prezentace, takže prezentace zůstane samostatná při přesunu na jiný počítač.

Následující příklad přidá JPEG obrázek, vytvoří rámeček v původních rozměrech obrázku a použije formátování čáry a otočení:
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

Rámeček obrázku řídí zobrazovanou geometriku; změna velikosti rámečku nemění původní rozměry pixelů uložených ve vloženém zdroji obrázku. Tento rozdíl se později stává důležitým při ořezávání nebo kompresi obrázku.

## **Použití relativního měřítka**

[Třída [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/) poskytuje [relative_scale_width](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/relative_scale_width/) a [relative_scale_height](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/relative_scale_height/) pro rámeček. Hodnota `1.0` odpovídá 100 % původní velikosti obrázku. Relativní měřítko je užitečné, když workflow potřebuje zachovat vztah k velikosti zdrojového obrázku místo manuálního výpočtu konečných rozměrů.
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

Relativní měřítko mění nastavení měřítka rámečku; neprovádí přeškálování ani kompresi vloženého obrázku.

## **Vložené a propojené obrázky**

Vložený obrázek ukládá data obrázku uvnitř prezentace a je proto nejbezpečnější volbou pro přenositelnost a předvídatelné vykreslování. Propojený obrázek ukládá externí umístění pomocí cesty odkazu [Picture](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picture/) místo vložení dat obrázku stejným způsobem.

Propojené obrázky mohou snížit množství dat obrázku uložených v PPTX, ale zavádějí externí závislost. Propojený soubor musí zůstat přístupný aplikaci, která otevírá nebo vykresluje prezentaci. Pokud se cesta změní, soubor se přesune nebo zdroj není k dispozici, propojený obrázek se nemusí zobrazit podle očekávání. Pro prezentace, které musí být posílány e-mailem, archivovány nebo vykreslovány v izolovaných prostředích, jsou vložené obrázky obvykle spolehlivější.

### **Přidání propojeného obrázku**

Následující příklad vytvoří rámeček obrázku a nasměruje jej na lokální soubor obrázku. Zabývá se pouze propojením obrázku; propojení videa je samostatný mediální workflow a je úmyslně v tomto příkladu nezahrnuto.
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

Používejte odkazy, když je řízení externích souborů záměrem. Nepoužívejte je jen jako náhradu za kompresi: malý PPTX s poškozenými závislostmi obrázků je obvykle méně užitečný než větší samostatná prezentace.

## **Extrahování obrázků z rámečků obrázků**

Před extrahováním obrázku z existující prezentace zkontrolujte, že tvar je skutečně [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/) a že obsahuje vložený obrázek. Propojené rámečky obrázků nemusí obsahovat bajty obrázku, které lze extrahovat stejným způsobem.

### **Extrahovat rastrový obrázek**

Moderní obrazové API používá přímo [IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/). Následující příklad najde první vložený rastrový obrázek na snímku a uloží jej jako PNG:
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

Ukládáním přes [IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/) se extrahovaný obrázek převede do požadovaného výstupního formátu. Pokud potřebujete kódované bajty uložené v prezentaci místo převedeného rastrového souboru, použijte místo toho vlastnost [PPImage.binary_data](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/binary_data/).

### **Extrahovat SVG obrázek**

U SVG obrázku [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) poskytuje objekt [SvgImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/svgimage/). To vám umožní získat data SVG přímo, místo aby byl obrázek nejprve rasterizován.
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

Uchovávání SVG obsahu jako SVG zachovává vektorový zdroj uvnitř prezentace. Rasterové exporty, jako PNG nebo JPEG, nutně převádějí tento vektorový obsah na pixely. Export snímků do PDF nebo SVG je také operací vykreslování, takže exportovaná grafika by neměla být považována za bitovou kopii původního vloženého SVG; použijte vložené [SvgImage.svg_data](https://reference.aspose.com/slides/cs/python-net/aspose.slides/svgimage/svg_data/), když je vyžadován samotný původní vektorový zdroj.

## **Ořez obrázku**

Ořez mění, která část obrázku je viditelná uvnitř rámečku. Hodnoty ořezu na [PictureFillFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/) jsou procenta rozměrů zdrojového obrázku. Ořez neodstraňuje skryté pixely z vloženého obrázku, pouze mění viditelnou oblast.

Následující příklad bezpečně najde rámeček obrázku a použije hodnoty ořezu:
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

Protože jsou skrytá data obrázku stále přítomna, lze ořez později změnit bez ztráty původních pixelů. Pokud je velikost souboru důležitější než reverzibilita, mohou být ořezané oblasti fyzicky odstraněny, jak je popsáno v následující sekci.

## **Odstranění ořezaných dat obrázku**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) odstraňuje data obrázku mimo aktuální ořezový obdélník a vrací vzniklý zdroj obrázku. To může snížit velikost souboru, ale jedná se o destruktivní optimalizaci: po uložení prezentace nejsou odstraněné pixely k dispozici pro pozdější operaci obnovení ořezu.
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

Metoda může do prezentace přidat nový zdroj obrázku. Pokud je původní obrázek také používán dalšími rámečky, tyto rámečky stále potřebují svůj existující zdroj, takže smazání ořezaných oblastí nutně nesníží celkový počet obrázků. Ořez obsahu WMF nebo EMF pomocí této metody rasterizuje ořezaný výsledek do PNG.

## **Komprese rastrových obrázků**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/compress_image/) snižuje rozlišení rastrového obrázku vzhledem k velikosti, při níž je obrázek zobrazován. Může také odstranit ořezané oblasti v rámci stejné operace. Metoda vrací `True`, když byl obrázek změněn velikostně nebo oříznut, a `False`, pokud nebyla nutná žádná změna.

Použijte předdefinovanou hodnotu [PicturesCompression](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/picturescompression/) když je dostačující standardní cílové rozlišení:
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

Místo výčtové hodnoty lze předat vlastní kladnou hodnotu DPI, pokud je požadován konkrétní cíl.

Kompresní proces je určen pro rastrové obrázky. SVG a obsah metafile nejsou tímto rastrovým kompresním workflow zmenšeny. Také si pamatujte, že nižší rozlišení a smazané ořezané oblasti nelze z optimalizované prezentace obnovit. Zvolte cílové rozlišení podle největší velikosti, při které bude obrázek skutečně zobrazen nebo exportován, místo aplikování nejnižšího DPI globálně.

## **Prohlédnout efekty obrázku**

Efekty obrázku jsou uloženy na obrázku použitém rámečkem. Kolekce transformací obrázku může obsahovat efekty jako fixní alfa modulace pro průhlednost a luminanci pro jas a kontrast. Níže uvedený příklad bezpečně načte oba typy efektů z prvního rámečku obrázku na snímku:
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
        for effect in picture_frame.picture_format.picture.image_transform:
            if isinstance(effect, slides.effects.AlphaModulateFixed):
                transparency = 100 - effect.amount
                print("Transparency: " + str(transparency))

            if isinstance(effect, slides.effects.Luminance):
                luminance = effect.get_effective()
                print("Brightness: " + str(luminance.brightness))
                print("Contrast: " + str(luminance.contrast))
```

[AlphaModulateFixed](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/alphamodulatefixed/) a [Luminance](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/luminance/) mění způsob, jakým je obrázek vykreslen v rámečku; nepřepisují původní bajty vloženého obrázku.

## **Uzamknutí geometrie rámečku obrázku**

Nastavení [PictureFrameLock](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframelock/) řídí, které operace úprav jsou pro rámeček obrázku zakázány. Například vlastnost [aspect_ratio_locked](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) zachovává proporce tvaru při změně velikosti.
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

Uzamčení se vztahuje na tvar rámečku obrázku. Neznamená to, že by zdrojový obrázek byl přeškálován nebo trvale změněn na stejný poměr stran.

## **Úprava hodnot StretchOffset**

Když je režim výplně obrázku nastaven na stretch, hodnoty stretch-offset na [PictureFillFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/) definují výplňový obdélník relativně k ohraničujícímu rámečku rámečku obrázku. Kladná procenta vytvoří vnitřní odsazení od okraje, zatímco záporná procenta vytvoří vnější odsazení.

Toto se liší od ořezu. Hodnoty ořezu vybírají, která část zdrojového obrázku je viditelná; stretch offsety mění obdélník, do kterého je viditelná výplň obrázku roztahována.
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

## **Úvahy o úložišti, velikosti souboru a exportu**

Hlavní kompromisy jsou snazší spravovat, když je úložiště obrázků a formátování rámečků obrázků řešeno odděleně:

- **Vložené obrázky** činí prezentaci samostatnou a jsou nejspolehlivější pro sdílení a serverové vykreslování, ale velké rastrové obrázky zvyšují velikost PPTX a využití paměti.
- **Propojené obrázky** mohou udržet balíček menší, ale prezentace závisí na tom, že externí soubory zůstanou dostupné na uložených cestách nebo místech.
- **Ořez** je zpočátku nedestruktivní. Skryté pixely zůstávají vloženy, dokud ořezané oblasti nejsou výslovně smazány nebo odstraněny během komprese.
- **Kompresí** lze podstatně snížit velikost souboru u přebytkových rastrových obrázků, ale obětuje se tím původní rozlišení. Měla by být použita po určení zamýšlené velikosti na snímku.
- **SVG obrázky** by měly zůstat jako SVG, když je důležitá zachování vektoru. Extrahujte vložené SVG přímo, když potřebujete samotný vektorový zdroj. Rasterové exporty snímků vždy převádějí vykreslený snímek na pixely.
- **Opakované obrázky** by měly opakovaně používat existující zdroj [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) pokud je to možné, místo opakovaného načítání stejného souboru do workflow prezentace.

U velkých prezentací je optimalizace obrázků obvykle nejúčinnější, když je prováděna selektivně: uchovávejte loga a diagramy jako vektorový obsah, komprimujte fotografie podle jejich skutečné zobrazovací velikosti, odstraňujte ořezané pixely pouze tehdy, když není následná úprava vyžadována, a vyhýbejte se externím odkazům, pokud není řízení závislostí součástí návrhu nasazení.

## **Často kladené otázky**

**Jaký je rozdíl mezi rámečkem obrázku a zdrojem obrázku?**

[PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) představuje zdroj obrázku spojený s prezentací. [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/) je tvar na snímku, který zobrazuje obrázek a ukládá geometrické a formátovací informace na úrovni rámečku, jako jsou velikost, otáčení, hodnoty ořezu, efekty a zámky.

**Mám obrázky vkládat nebo propojovat?**

Vkládejte obrázky, když musí být prezentace přenosná, archivovaná nebo vykreslovaná bez přístupu k externím zdrojům. Propojujte obrázky pouze tehdy, když je úmyslné udržovat soubory obrázků mimo PPTX a externí umístění lze spolehlivě spravovat.

**Snižuje ořez velikost souboru PPTX?**

Není. Normální nastavení ořezu skryje části zdrojového obrázku, ale zachovává podkladové pixely. Použijte [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) nebo kompresi obrázku s odstraněním ořezaných oblastí, pokud mohou být tyto pixely trvale odstraněny.

**Mohu obnovit kvalitu obrázku po kompresi?**

Ne. Komprese může snížit uložené rastrové rozlišení a odstranění ořezaných oblastí vymaže data obrázku. Uchovávejte původní zdrojový obrázek mimo prezentaci, pokud může být později potřeba úprava ve vysokém rozlišení.

**Jak zacházet s SVG obrázky?**

Uchovávejte SVG obsah jako SVG, když je důležitá věrnost vektoru. Vložený [SvgImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/svgimage/) lze extrahovat přímo. Vykreslení snímku do rastrového formátu, jako je PNG nebo JPEG, rasterizuje SVG jako součást obrázku snímku.

**Jak se vyhnout nebezpečným přetypováním při čtení existujících snímků?**

Zkontrolujte typ tvaru před použitím členů specifických pro rámeček obrázku. Použití `isinstance(shape, slides.PictureFrame)` zabraňuje neplatným přetypováním a umožňuje kódu zpracovat snímky, které neobsahují rámečky obrázků.