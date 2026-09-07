---
title: PowerPoint prezentációk konvertálása Markdown formátumba Pythonon keresztül Java-val
linktitle: PowerPoint Markdownra
type: docs
weight: 140
url: /hu/python-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint MD-re
- prezentáció MD-re
- dia MD-re
- PPT MD-re
- PPTX MD-re
- PowerPoint mentése Markdownként
- prezentáció mentése Markdownként
- dia mentése Markdownként
- PPT mentése MD-ként
- PPTX mentése MD-ként
- PPT exportálása MD-be
- PPTX exportálása MD-be
- Markdown képexport
- CDN kép hivatkozások
- PowerPoint
- prezentáció
- Markdown
- Python
- Java
- Aspose.Slides
description: "PPT és PPTX prezentációk konvertálása Markdown formátumba Pythonon keresztül Java-val, valamint a exportált bitmap, metafájl és SVG képek mentésének és hivatkozásának helyének szabályozása."
---
## **Áttekintés**

Aspose.Slides for Python via Java képes PPT és PPTX prezentációkat Markdown formátumba konvertálni dokumentációhoz, statikus weboldalakhoz, tartalom‑migrációhoz és verziókezelési folyamatokhoz. Kiválaszthatja a Markdown változatot, szabályozhatja, hogyan kerül renderelésre a diák tartalma, és megadhatja, hogy az exportált képek hol legyenek tárolva, valamint hogyan hivatkozzon rájuk a generált Markdown.

Alapértelmezés szerint a Markdown export szöveg‑csak kimenetet használ. A vizuális tartalom exportálásához állítsa be az export típust a [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/markdownsaveoptions/#setExportType) metódussal a [MarkdownExportType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/markdownexporttype/) felsorolt `Sequential` vagy `Visual` értékére. A `Sequential` a diák elemeit külön‑külön és sorrendben rendereli, míg a `Visual` a csoportos elemeket együttesen tartja, hogy megőrizze a vizuális kapcsolatot. A `TextOnly` érték nem generál kép‑erőforrásokat, ezért ebben a módban a kép‑mentési visszahívások nem lesznek meghívva.

## **Átalakítás Markdown formátumba**

Töltse be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztállyal, majd hívja meg a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust a [SaveFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/) felsorolt `Md` értékével.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

Minden példa a `presentation.pptx` fájlt a jelenlegi munkakönyvtárból olvassa. Telepítse az Aspose.Slides for Python via Java‑t és egy kompatibilis Java futtatókörnyezetet a példák futtatása előtt. Indítsa el a JVM‑et egyszer minden Python folyamatban.

## **Markdown változat kiválasztása**

A [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/markdownsaveoptions/#setFlavor) metódus szabályozza a kimenethez használt Markdown specifikációt. A [Flavor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/flavor/) felsorlat tartalmazza a CommonMark‑ot, a GitHub Flavored Markdown‑ot és más támogatott változatokat.

Az alábbi példa egy prezentációt CommonMark‑ként exportál:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **Képek exportálása az alapértelmezett helyi mentési viselkedéssel**

A [MarkdownSaveOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/markdownsaveoptions/) osztály két módszert biztosít a helyi mentésű képek konfigurálásához:

- [setBasePath](https://reference.aspose.com/slides/hu/python-java/aspose.slides/markdownsaveoptions/#setBasePath) adja meg a Markdown dokumentum és erőforrásai alapkönyvtárát.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/hu/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) adja meg a képek alkönyvtárát. Alapértelmezett értéke `Images`.

Az alábbi példa vizuális tartalmat renderel, a képeket az `output/assets` könyvtárba írja, és relatív kép hivatkozásokat hoz létre a Markdown dokumentumban:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Ez a viselkedés szolgál fallback‑ként is, amikor egy egyedi kép‑mentő kezelő `False`‑t ad vissza.

## **Képmentés és Markdown hivatkozások testreszabása**

Használja a [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/hu/python-java/aspose.slides/markdownsaveoptions/) metódust, hogy regisztráljon egy visszahívót a nem‑SVG bitmap és metafájl erőforrásokhoz, amelyek a Markdown export során keletkeznek. Ennek `MarkdownImageSavingHandler` visszahívása megkapja a kép objektumot, annak [ImageFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imageformat/) értékét, valamint a generált Markdown hivatkozást egyelemes `String[]` paraméterként. Mentse vagy töltsön fel a kapott formátummal, és cserélje le a `link[0]`‑t arra a hivatkozásra, amelynek a Markdown kimenetben meg kell jelennie.

Az SVG formátumban keletkező erőforrások külön kerülnek kezelésre. Regisztráljon egy visszahívót a [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/hu/python-java/aspose.slides/markdownsaveoptions/) metódussal. Ennek `MarkdownSvgImageSavingHandler` visszahívása megkap egy [SvgImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgimage/) objektumot és a egyelemes `String[] link` paramétert. Az SVG‑nek nincs `ImageFormat` argumentuma; írja vagy töltse fel az XML adatát a [SvgImage.getSvgData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgimage/#getSvgData) metódussal. Az export módjától és a vizuális csoportosítástól függően egy forrás‑prezentációban lévő SVG rasterizálható vagy más tartalommal egyesíthető; a keletkező nem‑SVG erőforrás akkor kerül átadásra a kép‑mentő visszahívónak. Regisztrálja mindkét visszahívót, ha minden exportált vizuális erőforrás egyedi feldolgozást igényel.

A visszahívó visszatérési értéke határozza meg, ki dolgozza fel a képet:

- `True` visszatérés után a visszahívó mentette, feltöltötte, átalakította vagy egyébként feldolgozta a képet, és érvényes értéket állított be a `link[0]`‑ban. Az Aspose.Slides ezt az értéket írja be a Markdown dokumentumba, és nem hajtja végre az alapértelmezett helyi mentést.
- `False` visszatérés esetén az Aspose.Slides helyben menti a képet, és a linket a [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/hu/python-java/aspose.slides/markdownsaveoptions/#setBasePath) és a [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/hu/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) beállításaival generálja.

{{% alert color="danger" title="Important" %}}
Egy `True`‑t visszaadó kezelő vállalja a kép felelősségét. Ha a kezelő `True`‑t ad vissza anélkül, hogy érvényes, nem üres linket állítana be, a export `InvalidOperationException`‑nel meghiúsul.
{{% /alert %}}

Pythonban regisztrálja ezeket a visszahívókat a `jpype.JProxy`‑val, amely a Java visszahívó interfészt az `invoke` metóduson keresztül valósítja meg. A `link` argumentum módosítható Java string tömb: konvertálja a `link[0]`‑t Python stringgé a feldolgozás előtt, majd az új URL‑t rendelje vissza a `link[0]`‑ba.

### **Képek mentése CDN eredeti könyvtárba és külső URL-ek használata**

Az alábbi példa a `cdn-origin/presentations/quarterly-report`‑et kezeli egy felcsatolt vagy szinkronizált CDN eredeti könyvtárként. Minden kezelő kinyeri a generált fájlnevet, a képet ebbe a saját könyvtárba menti, és a helyi hivatkozást egy nyilvános CDN URL‑re cseréli. A minta magában nem végez hálózati feltöltést: az URL csak akkor lesz érvényes, ha a könyvtár CDN eredetként fel van csatolva vagy fájljait a CDN‑re publikálják. Objektumtár esetén cserélje le a fájlrendszer írást a tárhely SDK feltöltési műveletére, és csak a feltöltés sikeres befejezése után állítsa be a `link[0]`‑t.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

A bitmap kezelő szándékosan `False`‑t ad vissza 128 × 128 pixelnél kisebb képek esetén, így az Aspose.Slides ezeket a képeket a `output/fallback-images` könyvtárba menti az alapértelmezett viselkedés szerint. Nagyobb bitmap és metafájl erőforrások, valamint az SVG erőforrások a saját kód által kerülnek kezelve. Például egy generált helyi hivatkozás, mint `fallback-images/image1.png`, `https://cdn.example.com/presentations/quarterly-report/image1.png`‑re alakul. A kezelők csak fájlrendszer‑útvonalakat használnak fájlok írásához; a Markdown‑ba írt hivatkozások perjelekkel és URL‑kódolt fájlnevekkel jelennek meg. Ugyanezt a szabályt alkalmazza relatív linkek építésénél: használjon `/`‑t, ne a platform‑specifikus könyvtárelválasztót.

## **GYIK**

**Kezelhet egyetlen visszahívó egyszerre raszteres és SVG képeket?**

Nem. Használja a [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/hu/python-java/aspose.slides/markdownsaveoptions/)‑t bitmap és metafájl erőforrásokhoz, valamint a [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/hu/python-java/aspose.slides/markdownsaveoptions/)‑t SVG‑ként exportált erőforrásokhoz. Az első visszahívó egy képobjektumot és egy [ImageFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imageformat/) értéket ad, a második egy [SvgImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgimage/) objektumot, amelynek SVG adatait a [SvgImage.getSvgData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgimage/#getSvgData)‑val olvashatja. Egy forrás‑SVG, amely exportálás során rasterizálódik, az image‑saving visszahívóval kerül feldolgozásra.

**Mi történik, ha egy képmentő visszahívó `False`‑t ad vissza?**

Az Aspose.Slides az alapértelmezett helyi mentési viselkedését használja. A kép helyét és a generált hivatkozást a [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/hu/python-java/aspose.slides/markdownsaveoptions/#setBasePath) és a [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/hu/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) beállításaival szabályozza.

**Megadhat egy visszahívó URL‑t anélkül, hogy a képet helyileg mentené?**

Igen. A visszahívó feltöltheti a képet objektumtárba vagy átadhatja egy másik szolgáltatásnak, a kapott URL‑t a `link[0]`‑ba állíthatja, és `True`‑t ad vissza. A visszahívónak magának kell elvégeznie a feldolgozást; a `True` visszatérés megakadályozza az alapértelmezett helyi mentést.

**Miért dob a Markdown export `InvalidOperationException` hibát egy visszahívótól?**

Ez a kivétel akkor fordul elő, ha a visszahívó `True`‑t ad vissza, de nem ad meg érvényes linket. A relatív útvonalat vagy külső URL‑t, amelyet a Markdown‑ba kell írni, a `True` visszatérés előtt állítsa be.

**Milyen útvonalelválasztót kell használni a kép hivatkozásoknál?**

A Markdown hivatkozásokban és URL‑ekben használjon perjeleket (`/`). A fájlrendszer‑útvonalakhoz csak a `pathlib.Path`‑t használja, majd a Markdown referencia építésekor vagy normalizálásakor alkalmazza a perjeleket.

**Megmaradnak a hiperhivatkozások a Markdown export során?**

Igen. A szöveg [hyperlinks](/slides/hu/python-java/manage-hyperlinks/) megmarad standard Markdown linkként. A diák [transitions](/slides/hu/python-java/slide-transition/) és [animations](/slides/hu/python-java/powerpoint-animation/) nem kerülnek konvertálásra.

**Alakíthatók a prezentációk párhuzamosan Markdown‑ba?**

Feldolgozhat különböző prezentációs fájlokat párhuzamosan, de ne ossza meg ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt szálak között. Kövesse a [multithreading guidelines](/slides/hu/python-java/multithreading/)‑t, és minden fájlhoz használjon külön példányt.