---
title: Správa obrázkových rámců v prezentacích pomocí Pythonu
linktitle: Obrázkový rámec
type: docs
weight: 10
url: /cs/python-java/picture-frame/
keywords:
- obrázkový rámec
- přidat obrázkový rámec
- vytvořit obrázkový rámec
- vložený obrázek
- propojený obrázek
- extrahovat obrázek
- rastrový obrázek
- SVG obrázek
- oříznout obrázek
- smazat ořezané oblasti
- komprimovat obrázek
- StretchOffset
- formátování obrázkového rámce
- relativní měřítko
- efekt obrázku
- poměr stran
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Vytvářejte, formátujte, propojujte, ořezávejte, extrahujte a komprimujte obrázkové rámečky v prezentacích pomocí Aspose.Slides pro Python přes Java."
---
## **Přehled**

Obrázkový rámec je tvar snímku, který zobrazuje obrázek. V Aspose.Slides jsou zdroj obrázku a tvar, který jej zobrazuje, oddělené objekty: [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) vlastní vložené zdroje obrázků prostřednictvím své [ImageCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagecollection/), zatímco [PictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/) řídí pozici obrázku, velikost, formátování čáry, otáčení, ořezávání, efekty obrázku a další nastavení na úrovni rámce.

Takové oddělení je užitečné, když je stejný obrázek zobrazen více než jednou. Přidejte obrázek do prezentace jednou, uchovejte vrácený [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/), a použijte tento zdroj obrázku při vytváření obrázkových rámců.

Obrázkové rámy mohou obsahovat rastrové obrázky jako PNG nebo JPEG a vektorové obrázky SVG. Mohou také odkazovat na propojené obrázky místo ukládání bajtů obrázku v prezentaci. Volba ovlivňuje přenositelnost, velikost souboru, extrakci a chování při exportu, takže je užitečné rozhodnout, jak má být obrázek uložen, ještě před aplikací formátování nebo optimalizace.

## **Přidání a formátování vloženého obrázku**

U vloženého obrázku přidejte data obrázku do prezentace a vytvořte obrázkový rámec pomocí [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addPictureFrame). Obrázek se stane součástí balíčku prezentace, takže prezentace zůstává samostatná při přesunu na jiný počítač.

Následující příklad přidá JPEG obrázek, vytvoří rámec v původních rozměrech obrázku a použije formátování čáry a otočení:

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

Obrázkový rámec řídí zobrazenou geometrii; změna velikosti rámce nemění původní rozměry v pixelech uložené ve vloženém zdroji obrázku. Tento rozdíl je důležitý při pozdějším ořezávání nebo kompresi obrázku.

## **Použití relativní měřítka**

[PictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/) umožňuje relativní změnu šířky a výšky rámce pomocí [setRelativeScaleWidth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) a [setRelativeScaleHeight](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight). Hodnota `1.0` odpovídá 100 % původní velikosti obrázku. Relativní měřítko je užitečné, když pracovní postup potřebuje zachovat vztah k velikosti zdrojového obrázku místo ručního výpočtu konečných rozměrů.

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

## **Vložené a propojené obrázky**

Vložený obrázek ukládá data obrázku uvnitř prezentace a je proto nejbezpečnější volbou pro přenositelnost a předvídatelné vykreslování. Propojený obrázek ukládá externí umístění pomocí metody [Picture.setLinkPathLong](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picture/#setLinkPathLong) místo vložení dat obrázku stejným způsobem.

Propojené obrázky mohou snížit množství dat obrázku uložených v PPTX, ale zavádějí externí závislost. Propojený soubor musí zůstat přístupný aplikaci, která prezentaci otevírá nebo vykresluje. Pokud se cesta změní, soubor se přesune nebo zdroj není dostupný, může být propojený obrázek zobrazen neočekávaně. Pro prezentace, které musí být posílány e-mailem, archivovány nebo vykreslovány v izolovaných prostředích, jsou vložené obrázky obvykle spolehlivější.

### **Přidání propojeného obrázku**

Následující příklad vytvoří obrázkový rámec a nasměruje jej na lokální soubor obrázku. Zabývá se pouze propojováním obrázků; propojování videí je samostatný multimediální pracovní postup a je úmyslně v tomto příkladu nepoužito.

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

Používejte odkazy, když je správa externích souborů záměrná. Nepoužívejte je jen jako náhradu za kompresi: malý PPTX s poškozenými závislostmi obrázků je obvykle méně užitečný než větší samostatná prezentace.

## **Extrahování obrázků z obrázkových rámců**

Před extrahováním obrázku z existující prezentace ověřte, že tvar je skutečně [PictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/) a že obsahuje vložený obrázek. Propojené obrázkové rámy nemusí obsahovat bajty obrázku, které lze extrahovat stejným způsobem.

### **Extrahování rastrového obrázku**

Moderní API obrázků pracuje přímo s rastrovými obrázky a nevyžaduje starší Java wrapper obrázku. Následující příklad najde první vložený rastrový obrázek na snímku a uloží jej jako PNG:

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

Uložení rastrového obrázku převede extrahovaný obrázek do požadovaného výstupního formátu. Pokud potřebujete zakódované bajty uložené v prezentaci místo konvertovaného rastrového souboru, použijte binární data zdroje obrázku.

### **Extrahování SVG obrázku**

U SVG obrázku [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/) poskytuje objekt [SvgImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgimage/). To vám umožní získat SVG data přímo místo rasterizace obrázku.

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

Uchování SVG obsahu jako SVG zachovává vektorový zdroj uvnitř prezentace. Rasterové exporty jako PNG nebo JPEG nutně převádějí tento vektorový obsah na pixely. Export snímku do PDF nebo SVG je také operací vykreslování, takže exportovaná grafika by neměla být považována za bit‑po‑bit kopii původního vloženého SVG; použijte vložená data [SvgImage.getSvgData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgimage/#getSvgData), pokud je požadován samotný vektorový zdroj.

## **Oříznutí obrázku**

Ořezávání mění, která část obrázku je viditelná uvnitř rámce. Hodnoty ořezu v [PictureFillFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/) jsou procenta rozměrů zdrojového obrázku. Ořezávání zpočátku neodstraňuje skryté pixely z vloženého obrázku; pouze mění viditelnou oblast.

Následující příklad bezpečně najde obrázkový rámec a aplikuje hodnoty ořezu:

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

Protože jsou skrytá data obrázku stále přítomna, lze ořez později změnit bez ztráty původních pixelů. Pokud je důležitější velikost souboru než možnost vrácení, mohou být ořezané oblasti fyzicky odstraněny, jak je popsáno v následující sekci.

## **Odstranění ořezaných dat obrázku**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) odstraňuje data obrázku mimo aktuální obdélník ořezu a vrací vzniklý zdroj obrázku. To může zmenšit velikost souboru, ale jedná se o destruktivní optimalizaci: po uložení prezentace nejsou odstraněné pixely již k dispozici pro pozdější operaci odořezání.

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

Metoda může do prezentace přidat nový zdroj obrázku. Pokud je původní obrázek používán i v jiných obrázkových rámech, tyto rámy stále potřebují svůj existující zdroj, takže smazání ořezaných oblastí nemusí nutně snížit celkový počet obrázků. Ořezávání obsahu WMF nebo EMF touto metodou rasterizuje ořezaný výsledek do PNG.

## **Komprese rastrových obrázků**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/#compressImage) snižuje rozlišení rastrového obrázku vzhledem k velikosti, při které je obrázek zobrazen. Může také odstranit ořezané oblasti ve stejné operaci. Metoda vrátí `True`, pokud byl obrázek změněn velikost nebo oříznut, a `False`, pokud žádná změna nebyla potřebná.

Použijte předdefinovanou hodnotu [PicturesCompression](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturescompression/) , když stačí standardní cílové rozlišení:

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

Vlastní kladná hodnota DPI může být předána místo předdefinované hodnoty, pokud je požadován konkrétní cíl.

Komprese je určena pro rastrové obrázky. SVG a obsah metafile nejsou tímto workflow komprese rastrových obrázků zmenšeny. Také pamatujte, že nižší rozlišení a smazané ořezané oblasti nelze z optimalizované prezentace obnovit. Zvolte cílové rozlišení na základě největší velikosti, při které bude obrázek skutečně zobrazen nebo exportován, místo aby se použilo nejnižší DPI celosvětově.

## **Správa efektů transformace obrázku**

Pro kompletní pracovní postup zahrnující jas, kontrast, barevné transformace, rozostření, alfa efekty, řazené řetězce, kontrolu, odstranění a ověření round‑trip viz [Image Transform Effects](/slides/cs/python-java/image-transform-effects/).

## **Uzamčení geometrie obrázkového rámce**

Nastavení [PictureFrameLock](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframelock/) řídí, které operace úprav jsou pro obrázkový rámec zakázány. Například [setAspectRatioLocked](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) zachovává proporce tvaru během změny velikosti.

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

Uzamčení se vztahuje na tvar obrázkového rámce. Nevyžaduje, aby zdrojový obrázek byl přeškálován nebo trvale změněn na stejné proporce.

## **Úprava hodnot StretchOffset**

Když je režim výplně obrázku nastaven na stretch, hodnoty stretch‑offsetu v [PictureFillFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/) definují výplňový obdélník relativně k ohraničujícímu rámečku obrázkového rámce. Kladná procenta vytvoří vnitřní odsazení od okraje, zatímco záporná procenta vytvoří vnější odsazení.

Toto se liší od ořezu. Hodnoty ořezu vybírají, která část zdrojového obrázku je viditelná; stretch‑offsety mění obdélník, do kterého je viditelná výplň obrázku roztažena.

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

Použijte stretch‑offsety pro umístění výplně. Použijte vlastnosti ořezu, když je cílem skrýt okraje zdrojového obrázku.

## **Úvahy o úložišti, velikosti souboru a exportu**

Hlavní kompromisy jsou snazší spravovat, když jsou ukládání obrázků a formátování obrázkových rámců řešeny odděleně:

- **Vložené obrázky** dělají prezentaci samostatnou a jsou nejspolehlivější pro sdílení a serverové vykreslování, ale velké rastrové obrázky zvyšují velikost PPTX a spotřebu paměti.
- **Propojené obrázky** mohou držet balíček menší, ale prezentace závisí na tom, že externí soubory zůstávají dostupné na uložených cestách nebo umístěních.
- **Ořezávání** je zpočátku nedestruktivní. Skryté pixely zůstávají vloženy, dokud nejsou ořezané oblasti výslovně smazány nebo odstraněny během komprese.
- **Kompresie** může podstatně snížit velikost souboru u příliš velkých rastrových obrázků, ale na úkor zdrojového rozlišení. Měla by být aplikována po určení zamýšlené velikosti na snímku.
- **SVG obrázky** by měly zůstat jako SVG, pokud je důležitá zachování vektoru. Extrahujte vložené SVG přímo, když potřebujete samotný vektorový zdroj. Rasterové exporty snímků vždy převádějí vykreslený snímek na pixely.
- **Opakované obrázky** by měly při možnosti znovu použít existující [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/) zdroj místo opakovaného načítání stejného souboru do pracovního postupu prezentace.

U velkých prezentací je optimalizace obrázků obvykle nejúčinnější při selektivním provedení: uchovávejte loga a diagramy jako vektorový obsah, komprimujte fotografie podle jejich skutečné zobrazovací velikosti, odstraňujte ořezané pixely jen když není potřeba pozdější úpravy, a vyhýbejte se externím odkazům, pokud správa závislostí není součástí návrhu nasazení.

## **Často kladené otázky**

**Jaký je rozdíl mezi obrázkovým rámcem a zdrojem obrázku?**

[PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/) představuje zdroj obrázku spojený s prezentací. [PictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/) je tvar na snímku, který zobrazí obrázek a ukládá geometrie a formátování na úrovni rámce, jako je velikost, otáčení, hodnoty ořezu, efekty a zámky.

**Mám obrázky vkládat nebo propojovat?**

Vkládejte obrázky, když musí být prezentace přenosná, archivovaná nebo vykreslena bez přístupu k externím zdrojům. Propojujte obrázky jen v případě, že je úmyslné mít soubory obrázků mimo PPTX a externí umístění lze spolehlivě udržovat.

**Snižuje ořezávání velikost souboru PPTX?**

Není to samo o sobě. Normální nastavení ořezu skryje části zdrojového obrázku, ale zachovává podkladové pixely. Použijte [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) nebo kompresi obrázku s odstraňováním ořezaných oblastí, když mohou být tyto pixely trvale odstraněny.

**Mohu po kompresi obnovit kvalitu obrázku?**

Ne. Komprese může snížit uložené rastrové rozlišení a odstraňování ořezaných oblastí zahazuje data obrázku. Uchovejte původní zdrojový obrázek mimo prezentaci, pokud může být později potřeba úprava ve vysokém rozlišení.

**Jak by se měly zacházet s SVG obrázky?**

Uchovávejte SVG obsah jako SVG, když je důležitá věrnost vektoru. Vložený [SvgImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgimage/) lze extrahovat přímo. Vykreslení snímku do rastrového formátu, jako je PNG nebo JPEG, rasterizuje SVG jako součást obrázku snímku.

**Jak se mohu vyhnout nebezpečným přetypováním při čtení existujících snímků?**

Zkontrolujte typ tvaru před použitím členů specifických pro obrázkový rámec. Kontrola `isinstance` proti [PictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/) zabraňuje neplatným přetypováním a umožňuje kódu zpracovat snímky, které neobsahují obrázkové rámy.