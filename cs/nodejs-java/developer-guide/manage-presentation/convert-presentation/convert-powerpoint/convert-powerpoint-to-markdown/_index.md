---
title: Převést prezentace PowerPoint do Markdownu v JavaScriptu
linktitle: PowerPoint do Markdownu
type: docs
weight: 140
url: /cs/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint do MD
- prezentace do MD
- snímek do MD
- PPT do MD
- PPTX do MD
- uložit PowerPoint jako Markdown
- uložit prezentaci jako Markdown
- uložit snímek jako Markdown
- uložit PPT jako MD
- uložit PPTX jako MD
- exportovat PPT do MD
- exportovat PPTX do MD
- export obrázků do Markdownu
- CDN odkazy na obrázky
- PowerPoint
- prezentace
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "Převést PPT a PPTX prezentace do Markdownu v JavaScriptu a ovládat, kde jsou exportované bitmapové, metafile a SVG obrázky uloženy a na které odkazy odkazují."
---
## **Přehled**

Aspose.Slides pro Node.js přes Java může převádět prezentace PPT a PPTX do Markdownu pro dokumentaci, statické weby, migraci obsahu a pracovní postupy správy verzí. Můžete si vybrat variantu Markdownu, řídit, jak je obsah snímků vykreslen, a rozhodnout, kde jsou exportované obrázky uloženy a jak na ně vygenerovaný Markdown odkazuje.

Ve výchozím nastavení export do Markdownu používá pouze textový výstup. Pro export vizuálního obsahu nastavte typ exportu metodou [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/markdownsaveoptions/) na hodnotu `Sequential` nebo `Visual` z výčtu [MarkdownExportType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/markdownexporttype/). `Sequential` vykresluje položky snímků samostatně a v pořadí, zatímco `Visual` zachovává seskupené položky dohromady, aby se udržel jejich vizuální vztah. Hodnota `TextOnly` nevydává zdroje obrázků, takže se v tomto režimu nevolají callbacky pro ukládání obrázků.

## **Převést prezentaci do Markdownu**

Dekódujte zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) a poté zavolejte metodu [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) s hodnotou `Md` z výčtu [SaveFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveformat/).

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

## **Vyberte variantu Markdownu**

Metoda [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/markdownsaveoptions/) určuje specifikaci Markdownu použitou pro výstup. Výčet [Flavor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/flavor/) zahrnuje CommonMark, GitHub Flavored Markdown a další podporované varianty.

Následující příklad exportuje prezentaci jako CommonMark:

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

## **Exportovat obrázky pomocí výchozího lokálního ukládání**

Třída [MarkdownSaveOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/markdownsaveoptions/) poskytuje dvě metody pro konfiguraci lokálně ukládaných obrázků:

- [setBasePath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/markdownsaveoptions/) určuje základní adresář pro Markdown dokument a jeho prostředky.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/markdownsaveoptions/) určuje podadresář pro obrázky. Výchozí hodnota je `Images`.

Následující příklad vykreslí vizuální obsah, zapíše obrázky do `output/assets` a vytvoří relativní odkazy na obrázky v Markdown dokumentu:

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

Toto chování také slouží jako záložní řešení, když vlastní handler pro ukládání obrázků vrátí `false`.

## **Přizpůsobit ukládání obrázků a odkazy v Markdownu**

Použijte metodu [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/markdownsaveoptions/) k registraci callbacku pro bitmapové a metafile zdroje, které nejsou SVG, vydávané během exportu do Markdownu. Jeho callback `MarkdownImageSavingHandler` přijímá objekt [IImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/), jeho hodnotu [ImageFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imageformat/) a vygenerovaný odkaz v Markdownu jako jednoprvkové pole řetězců. Uložte nebo nahrajte obrázek v daném formátu a nahraďte `link[0]` odkazem, který má být v Markdown výstupu.

Zdroje vydávané ve formátu SVG jsou zpracovány zvlášť. Zaregistrujte callback metodou [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/markdownsaveoptions/). Jeho callback `MarkdownSvgImageSavingHandler` přijímá objekt `ISvgImage` a jednoprvkové pole `link`. SVG nemá argument `ImageFormat`; místo toho zapište nebo nahrajte jeho XML data pomocí metody `ISvgImage.getSvgData`. V závislosti na režimu exportu a vizuálním seskupení může být SVG ve zdrojové prezentaci rasterizováno nebo kombinováno s jiným obsahem; vzniklý ne‑SVG zdroj je pak předán callbacku pro ukládání obrázků. Registrujte oba callbacky, když každý exportovaný vizuální zdroj vyžaduje vlastní zpracování.

V Node.js vytvořte implementace těchto rozhraní callbacků pomocí `java.newProxy`.

Hodnota vrácená handlerem určuje, kdo obrázek zpracuje:

- Vraťte `true`, poté co handler obrázek uloží, nahraje, transformuje nebo jinak zpracuje a přiřadí platnou hodnotu do `link[0]`. Aspose.Slides zapíše tuto hodnotu do Markdown dokumentu a neproveďte výchozí lokální uložení.
- Vraťte `false`, aby Aspose.Slides uložil obrázek lokálně a vygeneroval odkaz podle hodnot nastavených metodami [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/markdownsaveoptions/) a [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Handler, který vrátí `true`, přebírá odpovědnost za obrázek. Pokud vrátí `true` bez přiřazení platného, neprázdného odkazu, export selže s `InvalidOperationException`.
{{% /alert %}}

### **Uložit obrázky do CDN origin adresáře a použít externí URL**

Následující příklad považuje `cdn-origin/presentations/quarterly-report` za připojený či synchronizovaný CDN origin adresář. Každý handler získá vygenerovaný název souboru, uloží obrázek do tohoto vlastního adresáře a nahradí vygenerovaný lokální odkaz veřejnou CDN URL. Vzorek sám neprovádí žádné nahrávání do sítě: URL bude platná až po připojení adresáře jako CDN originu nebo po publikování jeho souborů do CDN. Pro objektové úložiště nahraďte zápis do souborového systému operací nahrání pomocí SDK úložiště a přiřaďte `link[0]` až po úspěšném nahrání.

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

Bitmap handler úmyslně vrací `false` pro obrázky menší než 128 × 128 pixelů, takže Aspose.Slides uloží tyto obrázky do `output/fallback-images` s výchozím chováním. Větší bitmapové a metafile zdroje, stejně jako SVG zdroje, jsou zpracovány vlastním kódem. Například vygenerovaný lokální odkaz jako `fallback-images/image1.png` se změní na `https://cdn.example.com/presentations/quarterly-report/image1.png`. Handlery používají cesty systému souborů jen při zápisu souborů; odkazy zapisované do Markdownu používají lomítka `/` a URL‑kódující názvy souborů. Použijte stejný pravidlo při tvorbě relativních odkazů: používejte `/`, nikoli platformně specifický oddělovač adresářů.

## **Často kladené otázky**

**Může jeden handler zpracovávat jak rastrové, tak SVG obrázky?**

Ne. Použijte [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/markdownsaveoptions/) pro bitmapové a metafile zdroje a [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/markdownsaveoptions/) pro zdroje vydávané jako SVG. První poskytuje objekt [IImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/) a hodnotu [ImageFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imageformat/); druhý poskytuje objekt `ISvgImage`, jehož SVG data lze číst pomocí `ISvgImage.getSvgData`. SVG ze zdroje, které je během exportu rasterizováno, je zpracován callbackem pro ukládání obrázků.

**Co se stane, když handler pro ukládání obrázků vrátí `false`?**

Aspose.Slides použije výchozí chování lokálního ukládání. Umístění obrázku a vygenerovaný odkaz jsou řízeny hodnotami nastavenými pomocí [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/markdownsaveoptions/) a [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/markdownsaveoptions/).

**Může handler poskytnout URL bez lokálního uložení obrázku?**

Ano. Handler může obrázek nahrát do objektového úložiště nebo předat jinému službě, přiřadit vzniklou URL do `link[0]` a vrátit `true`. Handler musí zpracování dokončit sám; vrácení `true` zabrání výchozímu lokálnímu uložení.

**Proč export do Markdownu vyvolá `InvalidOperationException` z handleru?**

Tato výjimka nastane, když handler vrátí `true`, ale neposkytne platný odkaz. Přiřaďte relativní cestu nebo externí URL, která má být zapsána do Markdownu, před návratem `true`.

**Který oddělovač cesty by měly odkazy na obrázky používat?**

Používejte lomítka (`/`) v odkazech Markdown a URL. `path.join` používejte jen pro cesty v souborovém systému, pak vytvořte nebo normalizujte odkaz v Markdownu samostatně.

**Zůstávají hypertextové odkazy při exportu do Markdownu zachovány?**

Ano. Textové [hyperlinky](/slides/cs/nodejs-java/manage-hyperlinks/) jsou zachovány jako standardní Markdown odkazy. [Přechody](/slides/cs/nodejs-java/slide-transition/) a [animace](/slides/cs/nodejs-java/powerpoint-animation/) snímků nejsou převáděny.

**Lze prezentace převádět do Markdownu paralelně?**

Můžete zpracovávat různé soubory prezentací paralelně, ale nesdílejte stejnou instanci [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) mezi vlákny. Řiďte se [pokyny pro multithreading](/slides/cs/nodejs-java/multithreading/) a použijte samostatnou instanci pro každý soubor.