---
title: PowerPoint prezentációk konvertálása Markdown formátumba JavaScript-ben
linktitle: PowerPoint Markdown-hoz
type: docs
weight: 140
url: /hu/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint átalakítása
- prezentáció átalakítása
- dia átalakítása
- PPT átalakítása
- PPTX átalakítása
- PowerPoint Markdown-ba
- prezentáció Markdown-ba
- dia Markdown-ba
- PPT Markdown-ba
- PPTX Markdown-ba
- PowerPoint mentése Markdown formátumba
- prezentáció mentése Markdown formátumba
- dia mentése Markdown formátumba
- PPT mentése Markdown-ba
- PPTX mentése Markdown-ba
- PPT exportálása Markdown-ba
- PPTX exportálása Markdown-ba
- Markdown képexport
- CDN kép hivatkozások
- PowerPoint
- prezentáció
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertálja a PPT és PPTX prezentációkat Markdown formátumba JavaScript-ben, és szabályozza, hogy az exportált bitmap, metafájl és SVG képek hol legyenek mentve és hivatkozva."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java képes PPT és PPTX prezentációkat Markdown formátumba konvertálni dokumentációs, statikus oldal, tartalom‑migrációs és verziókezelési munkafolyamatokhoz. Kiválaszthat egy Markdown változatot, szabályozhatja, hogyan jelenik meg a diák tartalma, és eldöntheti, hová kerülnek az exportált képek, valamint hogyan hivatkozik rájuk a generált Markdown.

Alapértelmezés szerint a Markdown export csak szöveges kimenetet használ. A vizuális tartalom exportálásához állítsa be az export típust a [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/markdownsaveoptions/) metódussal a [MarkdownExportType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/markdownexporttype/) felsorolás `Sequential` vagy `Visual` értékére. A `Sequential` külön‑külön és sorrendben jeleníti meg a diák elemeit, míg a `Visual` együttesen tartja a csoportosított elemeket, hogy megőrizze a vizuális kapcsolatot. A `TextOnly` érték nem bocsát ki képernyőforrásokat, ezért ebben a módban a képmentési visszahívások nem kerülnek meghívásra.

## **Prezentáció konvertálása Markdown formátumba**

Töltse be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztállyal, majd hívja meg a [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) metódust a [SaveFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveformat/) felsorolás `Md` értékével.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", aspose.slides.SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Válasszon egy Markdown változatot**

A [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/markdownsaveoptions/) metódus szabályozza a kimenetben használt Markdown specifikációt. A [Flavor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/flavor/) felsorolás tartalmazza a CommonMark, a GitHub Flavored Markdown és egyéb támogatott változatokat.

A következő példa a prezentációt CommonMark formátumban exportálja:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setFlavor(aspose.slides.Flavor.CommonMark);

    presentation.save("presentation.md", aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Képek exportálása az alapértelmezett helyi mentési viselkedéssel**

A [MarkdownSaveOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/markdownsaveoptions/) osztály két metódust biztosít a helyileg mentett képek konfigurálásához:

- [setBasePath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/markdownsaveoptions/) meghatározza a Markdown dokumentum és erőforrásai alapkönyvtárát.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/markdownsaveoptions/) megadja a képek alkönyvtárát. Alapértelmezett értéke `Images`.

A következő példa vizuális tartalmat renderel, a képeket a `output/assets` könyvtárba írja, és relatív kép hivatkozásokat hoz létre a Markdown dokumentumban:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("assets");

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Ez a viselkedés akkor is visszaesésként szolgál, amikor egy egyéni képmentő kezelő `false` értéket ad vissza.

## **Képmentés és Markdown hivatkozások testreszabása**

Használja a [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/markdownsaveoptions/) metódust, hogy regisztráljon egy visszahívást a Markdown export során keletkező nem SVG bitmap és metafájl erőforrásokhoz. A `MarkdownImageSavingHandler` visszahívás megkapja az [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) objektumot, annak [ImageFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imageformat/) értékét, valamint a generált Markdown hivatkozást egy elemű string tömbként. Mentse vagy töltse fel a képet a megadott formátummal, és cserélje le a `link[0]`‑t arra a hivatkozásra, amelynek meg kell jelennie a Markdown kimenetben.

Az SVG formátumban kelt erőforrások külön kerülnek kezelve. Regisztráljon egy visszahívást a [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/markdownsaveoptions/) metódussal. A `MarkdownSvgImageSavingHandler` visszahívás megkap egy `ISvgImage` objektumot és a egy elemű `link` tömböt. Az SVG‑nek nincs `ImageFormat` argumentuma; írja vagy töltse fel XML adatait a `ISvgImage.getSvgData` metódussal. Az export módjától és a vizuális csoportosítástól függően a forrásprezentációban lévő SVG rasterizálható vagy más tartalommal kombinálható; a keletkező nem SVG erőforrás ezután átadásra kerül a képmentő visszahívásnak. Regisztrálja mindkét visszahívást, ha minden exportált vizuális erőforrás egyéni feldolgozást igényel.

Node.js‑ben a `java.newProxy` segítségével hozhat létre megvalósításokat ezekhez a visszahívás interfészekhez.

A kezelő visszatérési értéke határozza meg, ki dolgozza fel a képet:

- Adjon vissza `true` értéket, miután a kezelő elmentette, feltöltötte, átalakította vagy más módon feldolgozta a képet, és érvényes értéket rendelt a `link[0]`‑hez. Az Aspose.Slides ezt az értéket a Markdown dokumentumba írja, és nem hajtja végre az alapértelmezett helyi mentést.
- Adjon vissza `false` értéket, hogy az Aspose.Slides helyi mentse a képet, és a linket a [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/markdownsaveoptions/) és a [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/markdownsaveoptions/) által beállított értékek alapján generálja.

{{% alert color="warning" title="Fontos" %}}
A `true` értéket visszaadó kezelő vállalja a kép felelősségét. Ha `true` értéket ad vissza anélkül, hogy érvényes, nem üres linket rendelt volna, az export `InvalidOperationException` hibával meghiúsul.
{{% /alert %}}

### **Képek mentése CDN forráskönyvtárba és külső URL-ek használata**

A következő példa a `cdn-origin/presentations/quarterly-report` könyvtárat CDN forráskönyvtárként kezeli, amely fel van szerelve vagy szinkronizálva. Minden kezelő kinyeri a generált fájlnevet, a képet ebbe az egyéni könyvtárba menti, és a generált helyi hivatkozást egy nyilvános CDN URL‑re cseréli. A példa önmagában nem végez hálózati feltöltést: az URL csak akkor lesz érvényes, amikor a könyvtár a CDN forrásként fel van szerelve vagy fájljait közzéteszik a CDN‑ben. Objektumtárolás esetén cserélje le a fájlrendszer írását a tároló SDK feltöltési műveletére, és csak a feltöltés sikeres befejezése után rendelje hozzá a `link[0]`‑t.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
const publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
const storageDirectory = path.join("cdn-origin", "presentations", "quarterly-report");
fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(storageDirectory, { recursive: true });

const getFileNameFromLink = generatedLink => {
    const urlCompatibleLink = String(generatedLink).replace(/\\/g, "/");
    return path.posix.basename(urlCompatibleLink);
};
const buildPublicUrl = fileName => publicBaseUrl + "/" + encodeURIComponent(fileName);

const imageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", {
    invoke: function(image, format, link) {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        image.save(storagePath, format);
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

const svgImageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", {
    invoke: function(svgImage, link) {
        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        fs.writeFileSync(storagePath, svgImage.getSvgData());
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("fallback-images");
    options.setImageSaving(imageSavingHandler);
    options.setSvgImageSaving(svgImageSavingHandler);

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

A bitmap kezelő szándékosan `false` értéket ad vissza 128 × 128 pixelnél kisebb képek esetén, ezért az Aspose.Slides ezeket a képeket a `output/fallback-images` könyvtárba menti az alapértelmezett viselkedéssel. Nagyobb bitmap és metafájl erőforrásokat, valamint SVG erőforrásokat a saját kód kezeli. Például egy generált helyi hivatkozás, mint a `fallback-images/image1.png`, átalakul a `https://cdn.example.com/presentations/quarterly-report/image1.png` URL‑re. A kezelők csak a fájlok írásakor használnak operációs rendszer útvonalakat; a Markdown‑ba írt hivatkozások perjel (/) és URL‑kódolt fájlneveket használnak. Ugyanezt a szabályt alkalmazza relatív hivatkozások építésekor: használjon `/`‑t, ne a platform‑specifikus könyvtárelválasztót.

## **GYIK**

**Feldolgozhat egy kezelő egyszerre raszteres és SVG képeket?**

Nem. Használja a [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/markdownsaveoptions/) metódust a bitmap és metafájl erőforrásokhoz, és a [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/markdownsaveoptions/) metódust az SVG‑ként kiadott erőforrásokhoz. Az előbbi egy [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) objektumot és egy [ImageFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imageformat/) értéket szolgáltat; az utóbbi egy `ISvgImage` objektumot, amelynek SVG adatait a `ISvgImage.getSvgData` metódussal lehet olvasni. A forrás SVG, amely exportálás során rasterizálódik, a képmentő visszahívással kerül feldolgozásra.

**Mi történik, ha egy képmentő kezelő `false` értéket ad vissza?**

Az Aspose.Slides a saját alapértelmezett helyi mentési viselkedését használja. A kép helyét és a generált hivatkozást a [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/markdownsaveoptions/) és a [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/markdownsaveoptions/) által beállított értékek szabályozzák.

**Képes egy kezelő URL-t biztosítani anélkül, hogy a képet helyben mentené?**

Igen. A kezelő feltöltheti a képet objektumtárolóba vagy átadhatja egy másik szolgáltatásnak, a kapott URL‑t rendelje a `link[0]`‑hez, és térjen vissza `true`‑val. A kezelőnek saját maga kell befejezni a feldolgozást; a `true` visszatérés megakadályozza az alapértelmezett helyi mentést.

**Miért dob `InvalidOperationException` kivételt a Markdown export egy kezelőtől?**

Ez a kivétel akkor fordul elő, amikor a kezelő `true`‑t ad vissza, de nem biztosít érvényes linket. A `true` visszatérés előtt rendelje hozzá a relatív elérési útvonalat vagy a külső URL‑t, amelyet a Markdown‑ba kell írni.

**Milyen útvonalelválasztót kell a kép hivatkozásoknak használniuk?**

Használjon perjeleket (/) a Markdown hivatkozásokban és URL‑ekben. A `path.join`‑t csak a fájlrendszer‑útvonalakhoz alkalmazza, majd a Markdown‑referenciát külön építse vagy normalizálja.

**Megmaradnak a hiperhivatkozások a Markdown export során?**

Igen. Szöveges [hiperhivatkozások](/slides/hu/nodejs-java/manage-hyperlinks/) megmaradnak szabványos Markdown hivatkozásként. Diák [átmenetek](/slides/hu/nodejs-java/slide-transition/) és [animációk](/slides/hu/nodejs-java/powerpoint-animation/) nem konvertálódnak.

**Konvertálhatók a prezentációk párhuzamosan Markdown formátumba?**

Különböző prezentációs fájlokat párhuzamosan dolgozhat fel, de ne ossza meg ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt szálak között. Kövesse a [multithreading guidelines](/slides/hu/nodejs-java/multithreading/) útmutatót, és minden fájlhoz használjon külön példányt.