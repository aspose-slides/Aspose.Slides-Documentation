---
title: Optimalizace správy obrázků v prezentacích pomocí Pythonu
linktitle: Správa obrázků
type: docs
weight: 10
url: /cs/python-java/image/
keywords:
  - přidat obrázek
  - přidat obrázek
  - nahradit obrázek
  - kolekce obrázků
  - rámec obrázku
  - odkazovaný obrázek
  - pozadí
  - přidat PNG
  - přidat JPG
  - přidat SVG
  - SVG na tvary
  - externí zdroje SVG
  - PowerPoint
  - OpenDocument
  - prezentace
  - Python
  - Java
  - Aspose.Slides
description: "Naučte se, jak přidávat, znovu používat, odkazovat, nahrazovat a spravovat rastrové a SVG obrázky v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python prostřednictvím Java."
---
## **Úvod**

Aspose.Slides for Python via Java poskytuje několik způsobů práce s obrázky a každý slouží jinému účelu. Můžete uložit obrázek v prezentaci, zobrazit jej v rámci obrázku, použít jej jako pozadí snímku, odkázat na externí obrázek, nahradit sdílený obrázkový zdroj nebo převést obsah SVG na editovatelné tvary.

Tento článek se zaměřuje na obrázkové zdroje a jejich použití v celé prezentaci. Pro oříznutí, průhlednost, efekty, roztahování a další formátování aplikované na jednotlivý rámec obrázku viz [Picture Frame](/slides/cs/python-java/picture-frame/).

## **Pochopení modelu obrázku**

- The [kolekce obrázků prezentace](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagecollection/) stores image resources used by the presentation. Use [ImageCollection.addImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagecollection/#addImage) to add image data and obtain a [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/) resource.
- [Rámec obrázku](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/) je tvar, který zobrazuje obrázek na snímku, rozložení nebo předloze. Použijte [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addPictureFrame) k umístění obrázkového zdroje na snímek.
- Pozadí snímku používá obrázek jako součást výplně snímku, nikoli jako tvar. Proto se nechová jako rámec obrázku.
- [PPImage.replaceImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/#replaceImage) nahrazuje obrázkový zdroj. Pokud několik prvků prezentace používá tento zdroj, všichni používají nahrazení.
- Převod SVG na tvary vytváří editovatelné tvary snímku. Po převodu není obsah nadále spravován jako jeden obrázkový zdroj.

Typický postup tedy je: přidat data obrázku do kolekce obrázků, získat [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/), a poté použít tento zdroj v jednom nebo více rámech obrázků nebo výplních.

## **Přidání vloženého obrázku**

Chcete‑li vložit lokální obrázek, načtěte soubor, přidejte jej do kolekce obrázků a vytvořte rámec obrázku, který používá vrácený [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Obrázek přidaný tímto způsobem je vložen v prezentaci, takže výsledný soubor není závislý na tom, zda je původní soubor obrázku nadále k dispozici.

### **Přidání obrázku z webu**

Když je obrázek dostupný přes HTTP nebo HTTPS, stáhněte jeho bajty, přidejte je do kolekce obrázků prezentace a použijte vrácený obrázkový zdroj stejným způsobem jako lokální obrázek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from urllib.request import urlopen
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    with urlopen("https://example.com/image.png", timeout=10) as response:
        image_data = response.read()

    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

V dlouho běžících aplikacích opakovaně používejte HTTP klienta nebo strategii správy připojení vhodnou pro aplikaci místo opakovaného vytváření zbytečné síťové infrastruktury. Také ověřujte vzdálené URL, velikosti odpovědí a typy obsahu, pokud zdroj není důvěryhodný.

## **Opětovné použití obrázků napříč snímky**

Pokud je stejný obrázek potřeba vícekrát, přidejte jej do prezentace jednou a použijte vrácený [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/) při vytváření dalších rámců obrázků. Tím se vyhnete opakovanému načítání stejných zdrojových dat a vztah mezi sdíleným obrázkovým zdrojem a jeho použitím je explicitní.

Pro grafiku, která by se měla automaticky objevovat na mnoha snímcích, jako je firemní logo, zvažte umístění rámce obrázku na [slide master](/slides/cs/python-java/slide-master/) nebo rozložení místo přidávání ekvivalentního tvaru na každý snímek.

## **Použití obrázku jako pozadí snímku**

Obrázek pozadí je přiřazen k výplni snímku; není přidán jako tvar rámce obrázku. To je užitečné, když má obrázek pokrýt pozadí snímku a neměl by být manipulován jako běžný objekt snímku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("background.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image)

    presentation.save("background-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Další možnosti pozadí, včetně pozadí předlohy a rozložení, najdete v [Presentation Background](/slides/cs/python-java/presentation-background/).

## **Vložené a odkazované obrázky**

Vložené a odkazované obrázky mají různé kompromisy v přenositelnosti a velikosti souboru:
- **Vložený obrázek:** data obrázku jsou uložena uvnitř prezentace. Prezentace je samostatná, ale velikost souboru zahrnuje data obrázku.
- **Odkazovaný obrázek:** prezentace ukládá cestu nebo URL k externímu obrázku. To může snížit velikost prezentace, ale externí zdroj musí zůstat přístupný, když je prezentace otevřena nebo renderována.

Odkazovaný obrázek lze vytvořit přiřazením externí cesty nebo URL pomocí [Picture.setLinkPathLong](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picture/#setLinkPathLong) namísto vložení dat obrázku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, None)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png")

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Používejte odkazované obrázky jen tehdy, když nasazovací prostředí může spolehlivě přistupovat k externímu zdroji. Pro prezentace, které musí fungovat offline nebo být přesouvány mezi systémy, jsou vložené obrázky obvykle bezpečnější.

## **Práce s obrázky SVG**

SVG je vektorový formát, takže může být užitečný pro ikony, diagramy a další grafiku, která by měla být škálovatelná bez stejné ztráty detailů jako rastrové obrázky. Aspose.Slides podporuje SVG jak jako obrázkový zdroj, tak jako zdroj pro editovatelné tvary snímku.

### **Přidání SVG jako obrázku**

Vytvořte [SvgImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgimage/), přidejte jej do kolekce obrázků a umístěte vzniklý obrázkový zdroj do rámce obrázku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage

presentation = Presentation()
try:
    svg_content = Path("icon.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    image = presentation.getImages().addImage(svg_image)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **SVG soubory s externími zdroji**

SVG může odkazovat na externí obrázky, styly nebo fonty. Pro tyto případy [SvgImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgimage/) poskytuje konstruktory, které přijímají [ExternalResourceResolver](https://reference.aspose.com/slides/cs/python-java/aspose.slides/externalresourceresolver/) a základní URI. Resolver může mapovat relativní URI na povolené absolutní URI a vrátit stream požadovaného zdroje.

Resolver zpřístupňuje externí zdroje během zpracování SVG v Aspose.Slides, ale nepřepíše SVG na samostatný dokument. Pokud musí SVG zůstat přenosný, vložte jeho požadované zdroje přímo do SVG, například použitím `data:` URI pro odkazované obrázky.

Když SVG soubory pocházejí z nedůvěryhodných zdrojů, omezte schémata, umístění souborů a hosty, ke kterým může resolver přistupovat. Síťové resolvery by také měly aplikovat časová omezení, limity velikosti odpovědi a validaci obsahu.

### **Převod SVG na editovatelné tvary**

Aspose.Slides může převést SVG do skupiny editovatelných tvarů snímku, podobně jako odpovídající příkaz v PowerPointu.

![PowerPoint Popup Menu](img_01_01.png)

Použijte přetížení [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addGroupShape), které přijímá [SvgImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgimage/), k provedení převodu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, SvgImage

presentation = Presentation()
try:
    svg_content = Path("diagram.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addGroupShape(svg_image, 0, 0, slide_width, slide_height)

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Použijte převod SVG na tvary, když je potřeba jednotlivé vektorové prvky upravovat jako tvary PowerPointu. Pokud je SVG potřeba jen zobrazit, je jednodušší ponechat jej jako obrázek a vyhnout se vytváření mnoha samostatných tvarů.

## **Nahrazení existujícího obrázkového zdroje**

Použijte [PPImage.replaceImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/#replaceImage), pokud chcete nahradit existující obrázkový zdroj. To je zvláště užitečné pro sdílenou grafiku, jako jsou loga.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    image_to_replace = presentation.getImages().get_Item(0)

    replacement_image = Images.fromFile("new-logo.png")
    try:
        image_to_replace.replaceImage(replacement_image)
    finally:
        replacement_image.dispose()

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pokud více rámců obrázků, pozadí, předloh nebo rozložení používá stejný obrázkový zdroj, jeho nahrazení aktualizuje všechny tyto použité instance. Pokud se má změnit jen jeden rámec obrázku, přiřaďte tomuto rámci jiný obrázek místo nahrazení sdíleného zdroje.

[PPImage.replaceImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/#replaceImage) také poskytuje přetížení, která přijímají pole bajtů nebo jiný [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/).

## **Praktické rady pro správu obrázků**

### **Kontrola velikosti prezentace**

Velké rastrové obrázky mohou způsobit zbytečně velkou prezentaci. Používejte zdrojové obrázky s rozměry vhodnými pro zamýšlenou velikost zobrazení, opakovaně využívejte sdílené obrázkové zdroje, kde je to možné, a vyhýbejte se vkládání opakovaných kopií stejné grafiky v plném rozlišení.

Pro rastrové obrázky, které již byly umístěny v rámech obrázků, může [PictureFillFormat.compressImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/#compressImage) snížit data obrázku podle vybrané rozlišení a nastavení oříznutí. Jedná se o zpracování rámce obrázku, nikoli o správu kolekce obrázků, takže viz [Picture Frame](/slides/cs/python-java/picture-frame/) pro související formátovací operace.

### **Volba mezi vloženým a odkazovaným obsahem**

Vkládání činí prezentaci přenosnou, protože veškerá požadovaná data obrázků jsou součástí souboru. Odkazování může zmenšit velikost souboru, ale zavádí externí závislost. Používejte odkazy jen tehdy, když je tato závislost přijatelná a stabilní.

### **Opětovné použití sdílené značky**

Pro opakovaně používaná loga, vodoznaky nebo dekorativní grafiku použijte jeden obrázkový zdroj a opakovaně jej využívejte. Pokud grafika patří k návrhu prezentace spíše než k obsahu snímku, umístěte ji na předlohu nebo rozložení, aby ji zdědily příslušné snímky.

### **Udržujte SVG zdroje přenosné**

Samostatné SVG je snadněji přenést a renderovat konzistentně než SVG, který závisí na externích souborech nebo síťových zdrojích. Kdy je to možné, vložte požadované zdroje před importem SVG. Převádějte SVG na tvary jen tehdy, když je potřeba jednotlivé vektorové prvky upravovat.

### **Použití moderního multiplatformního Image API**

Pro nový kód Python via Java používejte multiplatformní objekty obrázků Aspose.Slides a API [Images](https://reference.aspose.com/slides/cs/python-java/aspose.slides/images/) namísto zastaralého veřejného API založeného na `java.awt.image.BufferedImage`. Viz [Modern API](/slides/cs/python-java/modern-api/) pro pokyny k migraci.

Formáty WMF a EMF vyžadují zvláštní úvahu. Když jsou tyto formáty předány přes multiplatformní objekt obrázku, [ImageCollection.addImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagecollection/#addImage) převádí metsoubor na rastrovou reprezentaci PNG před vložením. Pokud je zachování dat metsouboru důležité, použijte přetížení [ImageCollection.addImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagecollection/#addImage) založené na streamu. Generování EMF obsahu z tabulek nebo jiných produktů je samostatný integrační workflow a leží mimo rozsah tohoto článku.

## **Často kladené otázky**

**Jaký je rozdíl mezi kolekcí obrázků a rámcem obrázku?**

Kolekce obrázků ukládá znovupoužitelné obrázkové zdroje. Rámec obrázku je tvar snímku, který zobrazuje jeden z těchto zdrojů a poskytuje specifické formátování obrázku, jako je oříznutí a efekty.

**Jaký je nejlepší způsob, jak nahradit stejné logo všude?**

Pokud je logo již sdíleno jako jeden obrázkový zdroj, nahraďte tento zdroj pomocí [PPImage.replaceImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/#replaceImage). Pro značku v celé prezentaci může umístění loga na předlohu nebo rozložení také snížit duplicitní obsah snímků.

**Proč odkazovaný obrázek zmizí na jiném počítači?**

Odkazovaný obrázek závisí na externím souboru nebo URL. Pokud k tomuto zdroji nelze z jiného počítače přistoupit, odkazovaný obrázek může být nedostupný. Vložte obrázek, pokud musí být prezentace samostatná.

**Lze vložené SVG upravit jako tvary PowerPointu?**

Ano. Převod SVG pomocí [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addGroupShape); vzniklá skupina obsahuje editovatelné tvary snímku místo jednoho SVG obrázku.

**Jak mohu udržet prezentace s mnoha obrázky menší?**

Opakovaně využívejte sdílené obrázkové zdroje, vyhýbejte se zbytečně velkým rastrovým zdrojům, komprimujte vhodné rastrové obrázky, pokud je to vhodné, držte opakovanou značku na předlohách nebo rozloženích a používejte odkazované obrázky jen tehdy, když je externí závislost přijatelná.