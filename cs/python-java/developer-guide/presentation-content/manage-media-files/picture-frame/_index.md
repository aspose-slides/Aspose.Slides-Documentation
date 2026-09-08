---
title: Správa rámců obrázků v prezentacích pomocí Pythonu
linktitle: Rámec obrázku
type: docs
weight: 10
url: /cs/python-java/picture-frame/
keywords:
- rámec obrázku
- přidat rámec obrázku
- vytvořit rámec obrázku
- vložený obrázek
- odkazovaný obrázek
- extrahovat obrázek
- rastrový obrázek
- SVG obrázek
- oříznout obrázek
- smazat ořezané oblasti
- komprimovat obrázek
- StretchOffset
- formátování rámce obrázku
- relativní měřítko
- efekt obrázku
- poměr stran
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Vytvořte, formátujte, odkažte, ořízněte, extrahujte a komprimujte rámce obrázků v prezentacích pomocí Aspose.Slides pro Python přes Java."
---
## **Přehled**

Rámec obrázku je tvar snímku, který zobrazuje obrázek. V Aspose.Slides jsou zdroj obrázku a tvar, který jej zobrazuje, samostatné objekty: [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) vlastní vložené zdroje obrázků prostřednictvím své [ImageCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagecollection/), zatímco [PictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/) řídí pozici obrázku, velikost, formátování čar, otáčení, ořez, efekty obrázku a další nastavení na úrovni rámce.

Toto oddělení je užitečné, když je stejný obrázek zobrazen vícekrát. Přidejte obrázek do prezentace jednou, uchovejte vrácený [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/), a použijte tento zdroj obrázku při vytváření rámců obrázků.

Rámce obrázků mohou obsahovat rastrové obrázky jako PNG nebo JPEG a vektorové SVG obrázky. Mohou také odkazovat na propojené obrázky místo ukládání bajtů obrázku do prezentace. Volba ovlivňuje přenositelnost, velikost souboru, extrakci a chování exportu, takže je užitečné rozhodnout, jak má být obrázek uložen, ještě před aplikací formátování nebo optimalizace.

## **Přidání a formátování vloženého obrázku**

Pro vložený obrázek přidejte data obrázku do prezentace a vytvořte rámec obrázku pomocí [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addPictureFrame). Obrázek se stane součástí balíčku prezentace, takže prezentace zůstane samostatná při přesunu na jiný počítač.

Následující příklad přidá JPEG obrázek, vytvoří rámec s původními rozměry obrázku a aplikuje formátování čáry a otáčení:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Rámec obrázku ovládá zobrazovanou geometrii; změna velikosti rámce nemění původní rozměry pixelů uložených ve vloženém zdroji obrázku. Tento rozdíl je důležitý při pozdějším ořezávání nebo kompresi obrázku.

## **Použití relativního měřítka**

[PictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/) poskytuje relativní škálování šířky a výšky rámce pomocí [setRelativeScaleWidth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) a [setRelativeScaleHeight](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight). Hodnota `1.0` odpovídá 100 % původní velikosti obrázku. Relativní měřítko je užitečné, když workflow potřebuje zachovat vztah k velikosti zdrojového obrázku místo ručního výpočtu konečných rozměrů.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Relativní měřítko mění nastavení měřítka rámce; neprovádí přeškálování ani kompresi vloženého obrázku.

## **Vložené a odkazované obrázky**

Vložený obrázek ukládá data obrázku uvnitř prezentace a je tak nejbezpečnější volbou pro přenositelnost a předvídatelné vykreslování. Odkazovaný obrázek ukládá externí umístění pomocí metody [Picture.setLinkPathLong](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picture/#setLinkPathLong) místo vkládání dat obrázku stejným způsobem.

Odkazované obrázky mohou snížit množství dat obrázku uložených v PPTX, ale zavádějí externí závislost. Odkazovaný soubor musí zůstat přístupný aplikaci, která prezentaci otevírá nebo vykresluje. Pokud se cesta změní, soubor je přesunut nebo zdroj není dostupný, může se odkazovaný obrázek nezobrazit podle očekávání. Pro prezentace, které je třeba e‑mailem posílat, archivovat nebo vykreslovat v izolovaných prostředích, jsou vložené obrázky obvykle spolehlivější.

### **Přidání odkazovaného obrázku**

Následující příklad vytvoří rámec obrázku a nasměruje jej na lokální soubor obrázku. Zabývá se pouze odkazováním na obrázek; odkazování na video je samostatný mediální workflow a záměrně není v tomto příkladu smícháno.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Používejte odkazy, když je externí správa souborů úmyslná. Nepoužívejte je jen jako náhradu za kompresi: malý PPTX s poškozenými závislostmi obrázků je obvykle méně užitečný než větší samostatná prezentace.

## **Extrahování obrázků z rámců obrázků**

Před extrahováním obrázku z existující prezentace zkontrolujte, že tvar je skutečně [PictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/) a že obsahuje vložený obrázek. Odkazované rámce obrázků nemusí obsahovat bajty obrázku, které lze extrahovat stejným způsobem.

### **Extrahování rastrového obrázku**

Moderní API obrázku pracuje přímo s rastrovými obrázky a nevyžaduje starší Java wrapper. Následující příklad najde první vložený rastrový obrázek na snímku a uloží jej jako PNG:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

Ukládání rastrového obrázku převádí extrahovaný obrázek do požadovaného výstupního formátu. Pokud potřebujete zakódované bajty uložené v prezentaci místo převedeného rastrového souboru, použijte binární data zdroje obrázku.

### **Extrahování SVG obrázku**

Pro SVG obrázek [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/) poskytuje objekt [SvgImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgimage/). To vám umožní získat SVG data přímo místo rasterizace obrázku nejprve.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

Uchování SVG obsahu jako SVG zachovává vektorový zdroj uvnitř prezentace. Rasterové exporty jako PNG nebo JPEG nutně renderují tento vektorový obsah do pixelů. Export slidu do PDF nebo SVG je také operace renderování, takže exportovaná grafika by neměla být považována za bit‑po‑bitu kopii původního vloženého SVG; použijte data [SvgImage.getSvgData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgimage/#getSvgData), když je požadován samotný vektorový zdroj.

## **Ořez obrázku**

Ořez mění, která část obrázku je viditelná uvnitř rámce. Hodnoty ořezu na [PictureFillFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/) jsou procenta rozměrů zdrojového obrázku. Ořez neodstraňuje skryté pixely z vloženého obrázku; pouze mění viditelný region.

Následující příklad bezpečně najde rámec obrázku a použije hodnoty ořezu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Protože jsou skrytá data obrázku stále přítomna, lze ořez později změnit bez ztráty původních pixelů. Pokud je velikost souboru důležitější než možnost reverze, lze ořezané oblasti fyzicky odstranit, jak je popsáno v následující sekci.

## **Odstranění ořezaných dat obrázku**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) odstraňuje data obrázku mimo aktuální ořezový obdélník a vrací výsledný zdroj obrázku. To může snížit velikost souboru, ale jde o destruktivní optimalizaci: po uložení prezentace nejsou odstraněné pixely nadále k dispozici pro případný zpětný ořez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Metoda může do prezentace přidat nový zdroj obrázku. Pokud je původní obrázek také používán jinými rámci, tyto rámce stále potřebují svůj existující zdroj, takže smazání ořezaných oblastí nutně nesníží celkový počet obrázků. Ořez WMF nebo EMF pomocí této metody rasterizuje ořezaný výsledek do PNG.

## **Komprese rastrových obrázků**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/#compressImage) snižuje rozlišení rastrového obrázku vzhledem k velikosti, ve které je obrázek zobrazován. Může také v rámci stejné operace odstranit ořezané oblasti. Metoda vrací `True`, když byl obrázek změněn velikostí nebo oříznut, a `False`, když nebyla nutná žádná změna.

Použijte předdefinovanou hodnotu [PicturesCompression](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturescompression/), když je dostačující standardní cílové rozlišení:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Místo předdefinované hodnoty lze předat vlastní kladnou hodnotu DPI, pokud je požadováno konkrétní cílové rozlišení.

Komprese je určena pro rastrové obrázky. SVG a metafile obsah není tímto rasterovým kompresním workflow zmenšován. Také nezapomeňte, že nižší rozlišení a odstraněné ořezané oblasti nelze z optimalizované prezentace obnovit. Zvolte cílové rozlišení podle největší velikosti, při které bude obrázek skutečně zobrazován nebo exportován, místo aby se globálně aplikovalo nejnižší DPI.

## **Správa efektů transformace obrázku**

Pro kompletní workflow zahrnující jas, kontrast, barevné transformace, rozostření, alfa efekty, řetězce operací, inspekci, odstraňování a ověření round‑trip viz [Image Transform Effects](/slides/cs/python-java/image-transform-effects/).

## **Zamknutí geometrie rámce obrázku**

Nastavení [PictureFrameLock](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframelock/) řídí, které editační operace jsou pro rámec obrázku zakázány. Například [setAspectRatioLocked](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) zachovává proporce tvaru při změně jeho velikosti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Zámek se vztahuje na tvar rámce obrázku. Nevyžaduje, aby byl zdrojový obrázek přeškálován nebo trvale změněn na stejný poměr stran.

## **Úprava hodnot StretchOffset**

Když je režim vyplnění obrázku nastaven na stretch, hodnoty stretch‑offset na [PictureFillFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/) definují výplňový obdélník vzhledem k ohraničujícímu rámečku rámce obrázku. Kladná procenta vytvářejí odsazení od okraje, záporná procenta pak vystupování.

To se liší od ořezu. Hodnoty ořezu určují, která část zdrojového obrázku je viditelná; stretch‑offsety mění obdélník, do kterého je viditelná výplň obrázku roztahována.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Používejte stretch‑offsety pro umístění výplně. Používejte vlastnosti ořezu, když je cílem skrýt okraje zdrojového obrázku.

## **Úvahy o úložišti, velikosti souboru a exportu**

Hlavní kompromisy je snazší spravovat, když jsou úložiště obrázků a formátování rámců zpracovávány odděleně:

- **Vložené obrázky** činí prezentaci samostatnou a jsou nejspolehlivější pro sdílení a server‑side vykreslování, ale velké rastrové obrázky zvětšují velikost PPTX a paměťovou náročnost.
- **Odkazované obrázky** mohou udržet balíček menší, ale prezentace závisí na externích souborech, které musí zůstat dostupné na uložených cestách nebo místech.
- **Ořez** je zpočátku nedestruktivní. Skryté pixely zůstávají vloženy, dokud nejsou ořezané oblasti výslovně smazány nebo odebrány během komprese.
- **Komprese** může značně zmenšit velikost souboru u příliš velkých rastrových obrázků, ale snižuje zdrojové rozlišení. Měla by být použita až po určení zamýšlené velikosti na snímku.
- **SVG obrázky** by měly zůstat jako SVG, když je důležitá zachování vektoru. Extrahujte vložené SVG přímo, když potřebujete samotný vektorový zdroj. Rasterové exporty slidu vždy převádějí vykreslený snímek do pixelů.
- **Opakované obrázky** by měly opakovaně používat existující zdroj [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/), pokud je to možné, místo opakovaného načítání stejného souboru do workflow prezentace.

U velkých prezentací je optimalizace obrázků obvykle nejúčinnější, když se provádí selektivně: loga a diagramy ponechte jako vektorový obsah, komprimujte fotografie podle jejich skutečné zobrazovací velikosti, odstraňujte ořezané pixely jen když další úpravy nejsou vyžadovány, a vyhýbejte se externím odkazům, pokud správa závislostí není součástí návrhu nasazení.

## **Často kladené otázky**

**Jaký je rozdíl mezi rámcem obrázku a zdrojem obrázku?**

[PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/) představuje zdroj obrázku spojený s prezentací. [PictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/) je tvar na snímku, který obrázek zobrazuje a ukládá geometrii a formátování na úrovni rámce, jako jsou velikost, otočení, hodnoty ořezu, efekty a zámky.

**Mám vkládat nebo odkazovat obrázky?**

Vkládejte obrázky, když musí být prezentace přenosná, archivovaná nebo vykreslená bez přístupu k externím zdrojům. Odkazujte obrázky jen když je úmyslné mít soubory obrázků mimo PPTX a externí umístění lze spolehlivě udržovat.

**Snižuje ořez velikost souboru PPTX?**

Ne, samostatně. Normální nastavení ořezu skrývá části zdrojového obrázku, ale zachovává podkladové pixely. Použijte [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) nebo kompresi obrázku s odstraněním ořezaných oblastí, když lze tyto pixely trvale odstranit.

**Mohu obnovit kvalitu obrázku po kompresi?**

Ne. Komprese může snížit uložené rastrové rozlišení a odstranění ořezaných oblastí zahazuje data obrázku. Uchovejte původní zdrojový obrázek mimo prezentaci, pokud může být později vyžadována úprava v vysokém rozlišení.

**Jak zacházet se SVG obrázky?**

Uchovejte SVG obsah jako SVG, když je důležitá vektorová přesnost. Vložený [SvgImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgimage/) lze extrahovat přímo. Vykreslení slidu do rastrového formátu jako PNG nebo JPEG rasterizuje SVG jako součást obrazu snímku.

**Jak se vyhnout nebezpečným přetypováním při čtení existujících snímků?**

Před použitím členů specifických pro rámec obrázku zkontrolujte typ tvaru. Kontrola `isinstance` proti [PictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/) zabraňuje neplatnému přetypování a umožňuje kódu správně zacházet se snímky, které neobsahují rámce obrázků.