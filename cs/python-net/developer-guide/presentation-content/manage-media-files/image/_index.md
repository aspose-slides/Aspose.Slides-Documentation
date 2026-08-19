---
title: Optimalizace správy obrázků v prezentacích s Pythonem
linktitle: Správa obrázků
type: docs
weight: 10
url: /cs/python-net/image/
keywords:
- přidat obrázek
- přidat obrázek
- nahradit obrázek
- kolekce obrázků
- rámeček obrázku
- odkazovaný obrázek
- pozadí
- přidat PNG
- přidat JPG
- přidat SVG
- SVG na tvary
- externí SVG zdroje
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak přidávat, opakovaně používat, odkazovat, nahrazovat a spravovat rastrové a SVG obrázky v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python via .NET."
---
## **Úvod**

Aspose.Slides for Python via .NET poskytuje několik způsobů, jak pracovat s obrázky, a každý z nich slouží jinému účelu. Můžete uložit obrázek do prezentace, zobrazit jej v rámečku obrázku, použít jej jako pozadí snímku, odkazovat na externí obrázek, nahradit sdílený obrázkový zdroj nebo převést obsah SVG na editovatelné tvary.

Tento článek se zaměřuje na obrázkové zdroje a jejich použití v celé prezentaci. Informace o ořezu, průhlednosti, efektech, roztahování a dalších formátováních aplikovaných na jednotlivý rámeček obrázku najdete v [rámečku obrázku](/slides/cs/python-net/picture-frame/).

## **Pochopení modelu obrázku**

Následující koncepty API jsou úzce související, ale nejsou zaměnitelné:

- [kolekce obrázků prezentace](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imagecollection/) ukládá obrázkové zdroje používané v prezentaci. Použijte [ImageCollection.add_image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imagecollection/add_image/) k přidání dat obrázku a získání zdroje [IPPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ippimage/).
- [rámeček obrázku](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ipictureframe/) je tvar, který zobrazuje obrázek na snímku, rozvržení nebo hlavě. Použijte [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_picture_frame/) k umístění obrázkového zdroje na snímek.
- Pozadí snímku používá obrázek jako součást výplně snímku, nikoli jako tvar. Proto se nechová jako rámeček obrázku.
- [IPPImage.replace_image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ippimage/replace_image/) nahrazuje obrázkový zdroj. Pokud jej používá více prvků prezentace, všichni použijí náhradu.
- Převod SVG na tvary vytváří editovatelné tvary snímku. Po převodu obsah již není spravován jako jeden obrázkový zdroj.

Typický tok práce tedy vypadá takto: přidejte data obrázku do kolekce obrázků, získejte [IPPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ippimage/) a poté použijte tento zdroj v jednom nebo více rámečcích obrázku či výplních.

## **Přidání vloženého obrázku**

Pro vložení místního obrázku přečtěte soubor, přidejte jeho data do kolekce obrázků a vytvořte rámeček obrázku, který použije vrácený `IPPImage`.

```python
import aspose.slides as slides

with open("photo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

Obrázek přidaný tímto způsobem je vložen do prezentace, takže výsledný soubor nevyžaduje, aby byl původní soubor obrázku nadále dostupný.

### **Přidání obrázku z webu**

Když je obrázek dostupný přes HTTP nebo HTTPS, stáhněte jeho bajty, přidejte je do kolekce obrázků prezentace a použijte vrácený obrázkový zdroj stejným způsobem jako místní obrázek.

```python
from urllib.request import urlopen

import aspose.slides as slides

image_url = "https://example.com/image.png"
with urlopen(image_url) as response:
    image_data = response.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", slides.export.SaveFormat.PPTX)
```

V dlouhodobých aplikacích opakovaně používejte HTTP klienta nebo pool spojení, kde je to vhodné, místo vytváření nového spojení pro každý požadavek. Také ověřujte vzdálené URL, velikosti odpovědí a typy obsahu, pokud není zdroj důvěryhodný.

## **Opětovné použití obrázků napříč snímky**

Pokud je stejný obrázek potřeba vícekrát, přidejte jej do prezentace jednou a při vytváření dalších rámečků obrázku použijte vrácený [IPPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ippimage/). Tím se zabrání opakovanému načítání stejných zdrojových dat a vztah mezi sdíleným obrázkovým zdrojem a jeho použitím bude explicitní.

Pro grafiku, která má automaticky vystupovat na mnoha snímcích, např. firemní logo, zvažte umístění rámečku obrázku na [hlavu snímku](/slides/cs/python-net/slide-master/) nebo rozvržení místo přidávání ekvivalentního tvaru na každý snímek.

## **Použití obrázku jako pozadí snímku**

Obrázek pozadí se přiřazuje výplni snímku; nepřidává se jako tvar rámečku obrázku. To je užitečné, když má obrázek pokrýt celé pozadí snímku a nemá být manipulován jako běžný objekt snímku.

```python
import aspose.slides as slides

with open("background.jpg", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image = presentation.images.add_image(image_data)
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    slide.background.fill_format.picture_fill_format.picture.image = image

    presentation.save("background-image.pptx", slides.export.SaveFormat.PPTX)
```

Další možnosti pozadí, včetně pozadí hlav a rozvržení, najdete v [Pozadí prezentace](/slides/cs/python-net/presentation-background/).

## **Vložené obrázky a odkazy na obrázky**

Vložené a odkazované obrázky mají odlišné kompromisy v přenositelnosti a velikosti souboru:

- **Vložený obrázek:** data obrázku jsou uložena uvnitř prezentace. Prezentace je samostatná, ale velikost souboru zahrnuje data obrázku.
- **Odkazovaný obrázek:** prezentace ukládá cestu nebo URL k externímu obrázku. To může snížit velikost prezentace, ale externí zdroj musí být při otevření nebo vykreslení prezentace dostupný.

Odkazovaný obrázek lze vytvořit přiřazením externí cesty nebo URL pomocí [ISlidesPicture.link_path_long](https://reference.aspose.com/slides/cs/python-net/aspose.slides/islidespicture/link_path_long/) místo vložení dat obrázku.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, None)
    picture_frame.picture_format.picture.link_path_long = "https://example.com/image.png"

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Používejte odkazované obrázky jen tehdy, když prostředí nasazení může spolehlivě přistupovat k externímu zdroji. Pro prezentace, které musí fungovat offline nebo být přesouvány mezi systémy, jsou vložené obrázky obvykle bezpečnější.

## **Práce s SVG obrázky**

SVG je vektorový formát, takže může být užitečný pro ikony, diagramy a další grafiku, která by měla být škálovatelná bez ztráty detailu jako rastrové obrázky. Aspose.Slides podporuje SVG jak jako obrázkový zdroj, tak jako zdroj pro editovatelné tvary snímku.

### **Přidání SVG jako obrázku**

Vytvořte [SvgImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/svgimage/), přidejte jej do kolekce obrázků a umístěte vzniklý obrázkový zdroj do rámečku obrázku.

```python
import aspose.slides as slides

with open("icon.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    image = presentation.images.add_image(svg_image)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", slides.export.SaveFormat.PPTX)
```

### **Převod SVG na editovatelné tvary**

Aspose.Slides může převést SVG na skupinu editovatelných tvarů snímku, podobně jako odpovídající příkaz PowerPointu.

![PowerPoint Popup Menu](img_01_01.png)

Použijte přetížení [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_group_shape/), které přijímá [ISvgImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/isvgimage/), k provedení převodu.

```python
import aspose.slides as slides

with open("diagram.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]
    slide.shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

    presentation.save("editable-svg-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Použijte převod SVG na tvary, když je nutné individuální vektorové prvky upravovat jako tvary PowerPointu. Pokud má být SVG pouze zobrazen, je jednodušší ponechat jej jako obrázek a vyhnout se vytváření mnoha samostatných tvarů.

## **Nahrazení existujícího obrázkového zdroje**

Použijte [IPPImage.replace_image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ippimage/replace_image/), když chcete nahradit existující obrázkový zdroj. To je zvláště užitečné pro sdílenou grafiku, jako jsou loga.

```python
import aspose.slides as slides

with open("new-logo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation("input.pptx") as presentation:
    image_to_replace = presentation.images[0]
    image_to_replace.replace_image(image_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Pokud více rámečků obrázku, pozadí, hlav nebo rozvržení používá stejný obrázkový zdroj, nahrazení tohoto zdroje aktualizuje všechny tyto použití. Pokud má změnit jen jeden rámeček obrázku, přiřaďte tomuto rámečku jiný obrázek místo nahrazení sdíleného zdroje.

`replace_image` také poskytuje přetížení, která přijímají [IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/) nebo jiný [IPPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ippimage/).

## **Praktické pokyny pro správu obrázků**

### **Kontrola velikosti prezentace**

Velké rastrové obrázky mohou prezentaci zbytečně nafouknout. Používejte zdrojové obrázky s rozměry vhodnými pro zamýšlenou velikost zobrazení, opakovaně používejte sdílené obrázkové zdroje, kde je to možné, a vyhněte se vkládání opakovaných kopií stejné grafiky v plné kvalitě.

Pro rastrové obrázky, které již byly umístěny v rámečcích obrázku, může [PictureFillFormat.compress_image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/compress_image/) snížit data obrázku podle zvolené rozlišovací schopnosti a nastavení ořezu. Jedná se o zpracování rámečku obrázku, nikoli o správu kolekce obrázků, takže viz [rámeček obrázku](/slides/cs/python-net/picture-frame/) pro související formátovací operace.

### **Výběr mezi vloženým a odkazovaným obsahem**

Vkládání činí prezentaci přenosnou, protože všechna potřebná data obrázku jsou součástí souboru. Odkazování může snížit velikost souboru, ale zavádí externí závislost. Odkazy používejte jen tehdy, když je tato závislost přijatelná a stabilní.

### **Opětovné použití sdíleného brandingu**

Pro opakovaná loga, vodoznaky nebo dekorativní grafiku používejte jeden obrázkový zdroj a opakujte jeho použití. Pokud grafika patří do návrhu prezentace spíše než do obsahu snímků, umístěte ji na hlavu nebo rozvržení, aby ji zdědily příslušné snímky.

### **Udržování SVG zdrojů přenosných**

Samostatný SVG je snazší přesunout a vykreslit konzistentně než SVG, který závisí na externích souborech nebo síťových zdrojích. Kdykoli je to možné, vložte potřebné zdroje před importem SVG. Převádějte SVG na tvary jen tehdy, když je nutné individuální vektorové prvky upravovat.

### **Použití moderního multiplatformního API obrázků**

Pro nový kód Python via .NET používejte API Aspose.Slides [IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/) a [Images](https://reference.aspose.com/slides/cs/python-net/aspose.slides/images/) místo zastaralých `aspose.pydrawing.Image` nebo `aspose.pydrawing.Bitmap`. Viz [Moderní API](/slides/cs/python-net/modern-api/) pro pokyny k migraci.

WMF a EMF vyžadují zvláštní úvahu. Když jsou tyto formáty předány přes [IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/), [ImageCollection.add_image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imagecollection/add_image/) převádí metafile na rastrovou PNG reprezentaci před vložením. Pokud je zachování dat metafile důležité, použijte přetížení založené na proudu [ImageCollection.add_image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imagecollection/add_image/). Generování EMF obsahu ze sešitů nebo jiných produktů je samostatný integrační tok a leží mimo rozsah tohoto článku.

## **Často kladené otázky**

**Jaký je rozdíl mezi kolekcí obrázků a rámečkem obrázku?**

Kolekce obrázků ukládá znovu použitelné obrázkové zdroje. Rámeček obrázku je tvar na snímku, který zobrazuje jeden z těchto zdrojů a poskytuje specifické formátování obrázku, jako je ořez a efekty.

**Jak nejlépe nahradit stejné logo všude?**

Pokud je logo již sdíleno jako jeden obrázkový zdroj, nahraďte tento zdroj pomocí [IPPImage.replace_image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ippimage/replace_image/). Pro branding napříč celou prezentací může také umístění loga na hlavu nebo rozvržení snížit duplicitní obsah snímků.

**Proč odkazovaný obrázek zmizí na jiném počítači?**

Odkazovaný obrázek závisí na externím souboru nebo URL. Pokud tento zdroj není z jiného počítače dosažitelný, může být odkazovaný obrázek nedostupný. Vložte obrázek, když musí být prezentace samostatná.

**Lze vložené SVG upravovat jako tvary PowerPointu?**

Ano. Převodem SVG pomocí [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_group_shape/) získáte skupinu editovatelných tvarů snímku místo jednoho obrázku SVG.

**Jak udržet prezentace s mnoha obrázky menší?**

Opakovaně používejte sdílené obrázkové zdroje, vyhýbejte se zbytečně velkým rastrovým zdrojům, při vhodných podmínkách komprimujte rastrové obrázky, umisťujte opakovaný branding na hlavy nebo rozvržení a odkazované obrázky používejte jen tehdy, když je externí závislost přijatelná.