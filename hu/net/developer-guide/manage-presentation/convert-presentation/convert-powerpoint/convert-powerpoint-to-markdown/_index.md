---
title: PowerPoint prezentációk konvertálása Markdown formátumba .NET-ben
linktitle: PowerPoint Markdownba
type: docs
weight: 140
url: /hu/net/convert-powerpoint-to-markdown/
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
- Markdown kép exportálás
- CDN képhivatkozások
- PowerPoint
- prezentáció
- Markdown
- .NET
- C#
- Aspose.Slides
description: PPT és PPTX prezentációk konvertálása Markdown formátumba .NET-ben, valamint a exportált bitmap, metafájl és SVG képek mentési helyének és hivatkozásának szabályozása.
---
## **Áttekintés**

Az Aspose.Slides for .NET képes PPT és PPTX prezentációkat Markdown formátumba konvertálni dokumentációs, statikus weboldal, tartalom-migrációs és verziókezelési munkafolyamatokhoz. Kiválaszthat egy Markdown változatot, szabályozhatja, hogyan jelenik meg a diák tartalma, és eldöntheti, hol tárolódjanak az exportált képek, valamint hogy a generált Markdown hogyan hivatkozik rájuk.

Alapértelmezés szerint a Markdown export csak szöveges kimenetet használ. A vizuális tartalom exportálásához állítsa be a [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/hu/net/aspose.slides.export/markdownsaveoptions/exporttype/) tulajdonságot a [MarkdownExportType](https://reference.aspose.com/slides/hu/net/aspose.slides.export/markdownexporttype/) felsorolás `Sequential` vagy `Visual` értékére. A `Sequential` külön és sorban jeleníti meg a diák elemeit, míg a `Visual` csoportos elemeket együttesen tartja, hogy megőrizze a vizuális kapcsolatot. A `TextOnly` érték nem bocsát ki képernyöforrásokat, ezért ebben a módban a képek mentésére vonatkozó események nem hívódnak meg.

## **Prezentáció konvertálása Markdown formátumba**

Töltse be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztállyal, majd hívja meg a [Presentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) metódust a [SaveFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/) felsorolás `Md` értékével.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **Markdown változat kiválasztása**

A [MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/hu/net/aspose.slides.export/markdownsaveoptions/flavor/) tulajdonság szabályozza a kimenethez használt Markdown specifikációt. A [Flavor](https://reference.aspose.com/slides/hu/net/aspose.slides.export/flavor/) felsorolás tartalmazza a CommonMark, a GitHub Flavored Markdown és más támogatott változatokat.

A következő példa egy prezentációt CommonMark formátumba exportál:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.CommonMark
};

presentation.Save("presentation.md", SaveFormat.Md, options);
```

## **Képek exportálása az alapértelmezett helyi mentési viselkedéssel**

A [MarkdownSaveOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/markdownsaveoptions/) osztály két tulajdonságot biztosít a helyben mentett képekhez:

- [BasePath](https://reference.aspose.com/slides/hu/net/aspose.slides.export/markdownsaveoptions/basepath/) adja meg a Markdown dokumentum és erőforrásai alapkönyvtárát.
- [ImagesSaveFolderName](https://reference.aspose.com/slides/hu/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) adja meg a képek alkönyvtárát. Alapértelmezett értéke `Images`.

A következő példa vizuális tartalmat jelenít meg, a képeket a `output/assets` könyvtárba írja, és relatív kép hivatkozásokat hoz létre a Markdown dokumentumban:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "assets"
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Ez a viselkedés ugyanúgy szolgál visszaesésként, amikor egy egyéni képmentő kezelő `false` értéket ad vissza.

## **Képmentés és Markdown hivatkozások testreszabása**

Használja a [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/hu/net/aspose.slides.export/markdownsaveoptions/imagesaving/) eseményt a Markdown export során keletkező nem SVG bitmap és metafájl erőforrásokhoz. Ennek a [MarkdownImageSavingHandler](https://reference.aspose.com/slides/hu/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) delegátumnak megkapja az [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) objektumot, annak [ImageFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/imageformat/) típusát, valamint a generált Markdown hivatkozást `ref string` paraméterként. Mentse vagy töltse fel a képet a megadott formátummal, és cserélje le a `link` értéket arra a hivatkozásra, amelynek meg kell jelennie a Markdown kimenetben.

Az SVG formátumban kiadott erőforrások külön kerülnek kezelve. Iratkozzon fel a [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/hu/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) eseményre, amelynek a [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/hu/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) delegátuma kap egy [ISvgImage](https://reference.aspose.com/slides/hu/net/aspose.slides/isvgimage/) objektumot és a `ref string link` paramétert. Az SVG-nek nincs `ImageFormat` argumentuma; írja vagy töltse fel XML adatát az [ISvgImage.SvgData](https://reference.aspose.com/slides/hu/net/aspose.slides/isvgimage/svgdata/) tulajdonságból. Az export módjától és a vizuális csoportosítástól függően a forrás prezentációban lévő SVG rasterizálható vagy más tartalommal kombinálható; a keletkező nem SVG erőforrás ezután átadásra kerül az `ImageSaving`-nek. Iratkozzon fel mindkét eseményre, amikor minden exportált vizuális erőforráshoz egyedi feldolgozás szükséges.

A kezelő visszatérési értéke határozza meg, ki dolgozza fel a képet:

- `true` értéket adjon vissza, miután a kezelő elmentette, feltöltötte, átalakította vagy más módon feldolgozta a képet és érvényes értéket rendelt a `link`-hez. Az Aspose.Slides ezt az értéket a Markdown dokumentumba írja, és nem hajtja végre az alapértelmezett helyi mentést.
- `false` értéket adjon vissza, hogy az Aspose.Slides helyileg mentse a képet és a linket a [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/hu/net/aspose.slides.export/markdownsaveoptions/basepath/) és a [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/hu/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) alapján generálja.

{{% alert color="warning" title="Important" %}}
Egy `true` értéket visszaadó kezelő vállalja a kép felelősségét. Ha a kezelő `true` értéket ad vissza anélkül, hogy érvényes, nem üres linket rendelt volna, az export `InvalidOperationException` hibával sikertelen.
{{% /alert %}}

### **Képek mentése egy CDN eredeti könyvtárba és külső URL-ek használata**

A következő példa a `cdn-origin/presentations/quarterly-report` könyvtárat egy felcsatolt vagy szinkronizált CDN eredeti könyvtárként kezeli. Minden kezelő kinyeri a generált fájlnevet, a képet ebbe az egyedi könyvtárba menti, és a generált helyi hivatkozást egy nyilvános CDN URL-re cseréli. A minta önmagában nem végez hálózati feltöltést: az URL csak akkor lesz érvényes, amikor a könyvtár fel van csatolva CDN eredetként vagy fájljai közzétéve a CDN-en. Objektumtárolás esetén cserélje le a fájlrendszer írását a tároló SDK feltöltési műveletére, és csak a feltöltés sikerét követően rendelje hozzá a `link`-et.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
const string publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
var storageDirectory = Path.Combine("cdn-origin", "presentations", "quarterly-report");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(storageDirectory);

static string GetFileNameFromLink(string generatedLink)
{
    var urlCompatibleLink = generatedLink.Replace('\\', '/');
    return urlCompatibleLink[(urlCompatibleLink.LastIndexOf('/') + 1)..];
}

static string BuildPublicUrl(string baseUrl, string fileName)
{
    return $"{baseUrl}/{Uri.EscapeDataString(fileName)}";
}

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "fallback-images"
};

options.ImageSaving += (IImage image, ImageFormat format, ref string link) =>
{
    if (image.Width < 128 || image.Height < 128)
    {
        return false;
    }

    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    image.Save(storagePath, format);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

options.SvgImageSaving += (ISvgImage svgImage, ref string link) =>
{
    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    File.WriteAllBytes(storagePath, svgImage.SvgData);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

A bitmap kezelő szándékosan `false` értéket ad vissza 128 × 128 pixelnél kisebb képek esetén, így az Aspose.Slides ezek a képek a `output/fallback-images` könyvtárba menti az alapértelmezett viselkedés szerint. Nagyobb bitmap és metafájl erőforrásokat, valamint SVG erőforrásokat az egyedi kód kezeli. Például egy generált helyi hivatkozás, mint a `fallback-images/image1.png`, `https://cdn.example.com/presentations/quarterly-report/image1.png` lesz. A kezelők csak fájlok írásakor használnak operációs rendszer útvonalakat; a Markdown-ba írt hivatkozások előrehaladó perjeleket és URL-kódolt fájlneveket használnak. Ugyanezt a szabályt alkalmazza relatív hivatkozások építésénél: használjon `/` karaktert, nem platformfüggő könyvtárelválasztót.

## **GYIK**

**Feldolgozhat egy kezelő egyszerre raszteres képeket és SVG képeket?**

Nem. Használja a [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/hu/net/aspose.slides.export/markdownsaveoptions/imagesaving/) eseményt a bitmap és metafájl erőforrásokhoz, és a [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/hu/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) eseményt az SVGként kiadott erőforrásokhoz. Az első egy [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) objektumot és egy [ImageFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/imageformat/) értéket ad, míg a második egy [ISvgImage](https://reference.aspose.com/slides/hu/net/aspose.slides/isvgimage/) objektumot, amelynek az SVG adata a [ISvgImage.SvgData](https://reference.aspose.com/slides/hu/net/aspose.slides/isvgimage/svgdata/) segítségével olvasható. A forrás SVG, amely exportálás során rasterizálódik, a `ImageSaving` által kerül feldolgozásra.

**Mi történik, ha egy képmentő kezelő `false` értéket ad vissza?**

Az Aspose.Slides az alapértelmezett helyi mentési viselkedést használja. A kép helyét és a generált hivatkozást a [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/hu/net/aspose.slides.export/markdownsaveoptions/basepath/) és a [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/hu/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) szabályozza.

**Képes egy kezelő URL-t biztosítani anélkül, hogy a képet helyben mentené?**

Igen. A kezelő feltöltheti a képet objektumtárolóba vagy átadhatja egy másik szolgáltatásnak, hozzárendelheti a kapott URL-t a `link`-hez, és `true` értékkel térhet vissza. A kezelőnek maga kell befejeznie a feldolgozást; a `true` visszatérés megakadályozza az alapértelmezett helyi mentést.

**Miért dob `InvalidOperationException`-t a Markdown export egy kezelőtől?**

Ez a kivétel akkor fordul elő, amikor a kezelő `true` értéket ad vissza, de nem ad meg érvényes hivatkozást. A `true` visszatérés előtt rendelje hozzá a relatív útvonalat vagy külső URL-t, amelyet a Markdownba kell írni.

**Milyen útvonalelválasztót kell használni a kép hivatkozásokban?**

A Markdown hivatkozások és URL-ek esetén használjon perjeleket (`/`). A `Path.Combine`-t csak fájlrendszer útvonalakhoz alkalmazza, a Markdown hivatkozást ezután külön építse vagy normalizálja.

**Megmaradnak a hiperhivatkozások a Markdown export során?**

Igen. A szöveg [hyperlinks](/slides/hu/net/manage-hyperlinks/) megmarad szabványos Markdown hivatkozásként. A diák [transitions](/slides/hu/net/slide-transition/) és [animations](/slides/hu/net/powerpoint-animation/) nem kerülnek konvertálásra.

**Konvertálhatók a prezentációk párhuzamosan Markdownba?**

Különböző prezentációs fájlokat párhuzamosan feldolgozhat, de ne ossza meg ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt szálak között. Kövesse a [multithreading guidelines](/slides/hu/net/multithreading/) útmutatót, és minden fájlhoz használjon külön példányt.