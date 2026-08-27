---
title: Převod prezentací PowerPoint na Markdown v .NET
linktitle: PowerPoint na Markdown
type: docs
weight: 140
url: /cs/net/convert-powerpoint-to-markdown/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint na MD
- prezentace na MD
- snímek na MD
- PPT na MD
- PPTX na MD
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
- .NET
- C#
- Aspose.Slides
description: "Převod prezentací PPT a PPTX do Markdownu v .NET a řízení, kde jsou exportované bitmapové, metafile a SVG obrázky uloženy a na které odkazy jsou v dokumentu."
---
## **Přehled**

Aspose.Slides pro .NET může převádět prezentace PPT a PPTX do Markdownu pro dokumentaci, statické weby, migraci obsahu a pracovní postupy s řízením verzí. Můžete si vybrat variantu Markdownu, řídit, jak je vykreslen obsah snímků, a rozhodnout, kde jsou exportované obrázky uloženy a jak je generovaný Markdown na ně odkazuje.

Ve výchozím nastavení export do Markdownu používá výstup pouze s textem. Pro export vizuálního obsahu nastavte vlastnost [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/cs/net/aspose.slides.export/markdownsaveoptions/exporttype/) na hodnotu `Sequential` nebo `Visual` z výčtu [MarkdownExportType](https://reference.aspose.com/slides/cs/net/aspose.slides.export/markdownexporttype/). `Sequential` vykresluje položky snímků odděleně a v pořadí, zatímco `Visual` zachovává seskupené položky pohromadě, aby se zachoval jejich vizuální vztah. Hodnota `TextOnly` nevyužívá zdroje obrázků, takže události ukládání obrázků nejsou v tomto režimu vyvolány.

## **Převod prezentace do Markdownu**

Nahrajte zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a pak zavolejte metodu [Presentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/) s hodnotou `Md` z výčtu [SaveFormat](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveformat/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **Vyberte variantu Markdownu**

Vlastnost [MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/cs/net/aspose.slides.export/markdownsaveoptions/flavor/) řídí specifikaci Markdownu použitou pro výstup. Výčet [Flavor](https://reference.aspose.com/slides/cs/net/aspose.slides.export/flavor/) zahrnuje CommonMark, GitHub Flavored Markdown a další podporované varianty.

Následující příklad exportuje prezentaci ve formátu CommonMark:

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

## **Export obrázků pomocí výchozího lokálního ukládání**

Třída [MarkdownSaveOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/markdownsaveoptions/) poskytuje dvě vlastnosti pro lokálně uložené obrázky:

- [BasePath](https://reference.aspose.com/slides/cs/net/aspose.slides.export/markdownsaveoptions/basepath/) určuje základní adresář pro dokument Markdown a jeho zdroje.
- [ImagesSaveFolderName](https://reference.aspose.com/slides/cs/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) určuje podsložku pro obrázky. Výchozí hodnota je `Images`.

Následující příklad vykresluje vizuální obsah, zapíše obrázky do `output/assets` a vytvoří relativní odkazy na obrázky v dokumentu Markdown:

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

Toto chování slouží také jako záložní řešení, když vlastní obsluha ukládání obrázků vrátí `false`.

## **Přizpůsobení ukládání obrázků a odkazů v Markdownu**

Použijte událost [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/cs/net/aspose.slides.export/markdownsaveoptions/imagesaving/) která se vztahuje na bitmapové a metafile zdroje, které nejsou ve formátu SVG, a jsou vytvářeny během exportu do Markdownu. Její delegát [MarkdownImageSavingHandler](https://reference.aspose.com/slides/cs/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) přijímá objekt [IImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/), jeho [ImageFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/imageformat/), a vygenerovaný odkaz Markdownu jako parametr `ref string`. Uložte nebo nahrajte obrázek ve zvoleném formátu a nahraďte `link` odkazem, který má být v Markdown výstupu.

Zdroje exportované ve formátu SVG jsou zpracovávány odděleně. Přihlaste se k události [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/cs/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) jejíž delegát [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/cs/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) přijímá objekt [ISvgImage](https://reference.aspose.com/slides/cs/net/aspose.slides/isvgimage/) a parametr `ref string link`. SVG nemá argument `ImageFormat`; místo toho zapíšte nebo nahrajte jeho XML data z vlastnosti [ISvgImage.SvgData](https://reference.aspose.com/slides/cs/net/aspose.slides/isvgimage/svgdata/). V závislosti na režimu exportu a vizuálním seskupení může být SVG ve zdrojové prezentaci rasterizováno nebo sloučeno s jiným obsahem; výsledný ne‑SVG zdroj je pak předán do `ImageSaving`. Přihlaste se k oběma událostem, pokud každý exportovaný vizuální zdroj vyžaduje vlastní zpracování.

Návratová hodnota obslužné rutiny určuje, kdo zpracuje obrázek:

- Vraťte `true`, pokud obsluha obrázek uložila, nahrála, transformovala nebo jinak zpracovala a přiřadila platnou hodnotu do `link`. Aspose.Slides zapíše tuto hodnotu do dokumentu Markdown a neprovedе výchozí lokální uložení.
- Vraťte `false`, aby Aspose.Slides obrázek uložil lokálně a vygenerovalo odkaz podle [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/cs/net/aspose.slides.export/markdownsaveoptions/basepath/) a [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/cs/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
Obsluha, která vrátí `true`, přebírá odpovědnost za obrázek. Pokud vrátí `true` bez přiřazení platného, ne‑prázdného odkazu, export selže s výjimkou `InvalidOperationException`.
{{% /alert %}}

### **Uložení obrázků do adresáře CDN origin a použití externích URL**

Následující příklad zachází s `cdn-origin/presentations/quarterly-report` jako s připojeným nebo synchronizovaným adresářem CDN origin. Každá obsluha získá vygenerovaný název souboru, uloží obrázek do tohoto vlastního adresáře a nahradí vygenerovaný lokální odkaz veřejnou CDN URL. Vzorek sám neprovádí žádné nahrávání přes síť: URL bude platná až po připojení adresáře jako CDN origin nebo po zveřejnění jeho souborů na CDN. Pro objektové úložiště nahraďte zápis do souborového systému operací nahrávání SDK úložiště a přiřaďte `link` až po úspěšném nahrání.

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

Obsluha bitmap úmyslně vrací `false` pro obrázky menší než 128 × 128 pixelů, takže Aspose.Slides ukládá tyto obrázky do `output/fallback-images` pomocí výchozího chování. Větší bitmapové a metafile zdroje, stejně jako SVG zdroje, jsou zpracovány vlastním kódem. Například vygenerovaný lokální odkaz jako `fallback-images/image1.png` se změní na `https://cdn.example.com/presentations/quarterly-report/image1.png`. Obslužné rutiny používají cestu systému OS pouze při zápisu souborů; odkazy zapisované do Markdownu používají lomítka dopředu a URL‑kódované názvy souborů. Použijte stejné pravidlo při vytváření relativních odkazů: používejte `/`, nikoli platformně specifický oddělovač adresářů.

## **Často kladené otázky**

**Může jedna obsluha zpracovávat jak rastrové obrázky, tak SVG obrázky?**

Ne. Použijte [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/cs/net/aspose.slides.export/markdownsaveoptions/imagesaving/) který slouží k bitmapovým a metafile zdrojům, a [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/cs/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) který slouží k zdrojům exportovaným jako SVG. První poskytuje objekt [IImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/) a [ImageFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/imageformat/); druhý poskytuje objekt [ISvgImage](https://reference.aspose.com/slides/cs/net/aspose.slides/isvgimage/) jehož SVG data lze číst z [ISvgImage.SvgData](https://reference.aspose.com/slides/cs/net/aspose.slides/isvgimage/svgdata/). SVG zdroj, který je během exportu rasterizován, je zpracován pomocí `ImageSaving`.

**Co se stane, když obsluha ukládání obrázku vrátí `false`?**

Aspose.Slides použije výchozí chování lokálního ukládání. Umístění obrázku a vygenerovaný odkaz jsou řízeny pomocí [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/cs/net/aspose.slides.export/markdownsaveoptions/basepath/) a [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/cs/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

**Může obsluha poskytnout URL, aniž by obrázek ukládala lokálně?**

Ano. Obsluha může obrázek nahrát do objektového úložiště nebo jej předat jiné službě, přiřadit vzniklou URL do `link` a vrátit `true`. Obsluha musí zpracování dokončit sama; vrácení `true` zabrání výchozímu lokálnímu uložení.

**Proč export do Markdownu vyvolá `InvalidOperationException` z obsluhy?**

Tato výjimka nastane, když obsluha vrátí `true`, ale neposkytne platný odkaz. Přiřaďte relativní cestu nebo externí URL, která má být zapsána do Markdownu, před vrácením `true`.

**Jaký oddělovač cest by měly odkazy na obrázky používat?**

V odkazech Markdown a URL používejte dopředná lomítka. `Path.Combine` použijte jen pro souborové cesty, poté vytvořte nebo normalizujte odkaz v Markdownu odděleně.

**Zůstávají hypertextové odkazy při exportu do Markdownu zachovány?**

Ano. Textové [hyperlinky](/slides/cs/net/manage-hyperlinks/) jsou zachovány jako standardní odkazy Markdown. Přechody [snímků](/slides/cs/net/slide-transition/) a [animace](/slides/cs/net/powerpoint-animation/) nejsou konvertovány.

**Lze prezentace převádět do Markdownu paralelně?**

Můžete zpracovávat různé soubory prezentací paralelně, ale nesdílejte stejnou instanci [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) mezi vlákny. Dodržujte [pravidla multithreadingu](/slides/cs/net/multithreading/) a použijte samostatnou instanci pro každý soubor.