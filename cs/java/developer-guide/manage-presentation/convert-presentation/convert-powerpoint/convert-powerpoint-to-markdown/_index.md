---
title: Převod prezentací PowerPoint do Markdownu v Javě
linktitle: PowerPoint do Markdownu
type: docs
weight: 140
url: /cs/java/convert-powerpoint-to-markdown/
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
- Java
- Aspose.Slides
description: "Převod PPT a PPTX prezentací do Markdownu v Javě a řízení, kde jsou exportované bitmapové, metafile a SVG obrázky uloženy a na ně odkazováno."
---
## **Přehled**

Aspose.Slides pro Java dokáže převádět prezentace PPT a PPTX do formátu Markdown pro dokumentaci, statické weby, migraci obsahu a pracovní postupy s verzovacím systémem. Můžete si vybrat variantu Markdown, řídit, jak je obsah snímků vykreslen, a rozhodnout, kde jsou exportované obrázky uloženy a jak na ně vygenerovaný Markdown odkazuje.

Ve výchozím nastavení export do Markdownu používá výstup pouze s textem. Pro export vizuálního obsahu nastavte typ exportu metodou [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/markdownsaveoptions/) na hodnotu `Sequential` nebo `Visual` z výčtu [MarkdownExportType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/markdownexporttype/). `Sequential` vykresluje položky snímku odděleně a v pořadí, zatímco `Visual` udržuje skupinové položky pohromadě, aby zachoval jejich vizuální vztah. Hodnota `TextOnly` nevytváří obrazové zdroje, takže v tomto režimu nejsou volány callbacky pro ukládání obrázků.

## **Převod prezentace do Markdownu**

Načtěte zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a poté zavolejte metodu [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) s hodnotou `Md` z výčtu [SaveFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/).

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Výběr varianty Markdownu**

Metoda [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/markdownsaveoptions/) určuje specifikaci Markdownu použité pro výstup. Výčet [Flavor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/flavor/) zahrnuje CommonMark, GitHub Flavored Markdown a další podporované varianty.

Následující příklad exportuje prezentaci jako CommonMark:

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Export obrázků pomocí výchozího lokálního ukládání**

Třída [MarkdownSaveOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/markdownsaveoptions/) poskytuje dvě metody pro konfiguraci lokálně ukládaných obrázků:

- [setBasePath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/markdownsaveoptions/) určuje základní adresář pro dokument Markdown a jeho zdroje.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/cs/java/com.aspose.slides/markdownsaveoptions/) určuje podsložku pro obrázky. Výchozí hodnota je `Images`.

Následující příklad vykresluje vizuální obsah, zapisuje obrázky do `output/assets` a vytváří relativní odkazy na obrázky v dokumentu Markdown:

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Toto chování slouží také jako náhradní řešení, když vlastní handler pro ukládání obrázků vrátí `false`.

## **Přizpůsobení ukládání obrázků a odkazů v Markdownu**

Použijte metodu [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/cs/java/com.aspose.slides/markdownsaveoptions/) k registraci callbacku pro bitmapové a metafile zdroje, které nejsou ve formátu SVG, generované během exportu do Markdownu. Jeho callback `MarkdownImageSavingHandler` přijímá objekt [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/), jeho hodnotu [ImageFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imageformat/) a vygenerovaný odkaz v Markdownu jako jednoprvkový parametr typu `String[]`. Uložte nebo nahrajte obrázek s poskytnutým formátem a nahraďte `link[0]` odkazem, který se má objevit ve výstupním Markdownu.

Zdroje vydané ve formátu SVG jsou zpracovávány odděleně. Registrujte callback metodou [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/cs/java/com.aspose.slides/markdownsaveoptions/). Jeho callback `MarkdownSvgImageSavingHandler` přijímá objekt [ISvgImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isvgimage/) a jednoprvkový parametr `String[] link`. SVG nemá argument `ImageFormat`; místo toho zapište nebo nahrajte jeho XML data pomocí metody [ISvgImage.getSvgData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isvgimage/). V závislosti na režimu exportu a vizuálním seskupení může být SVG v původní prezentaci rasterizováno nebo sloučeno s dalším obsahem; výsledný ne‑SVG zdroj je pak předán callbacku pro ukládání obrázku. Registrujte oba callbacky, pokud každý exportovaný vizuální zdroj vyžaduje vlastní zpracování.

Hodnota návratu handleru určuje, kdo obrázek zpracuje:

- Vraťte `true`, pokud handler obrázek uložil, nahrál, transformoval nebo jinak zpracoval a přiřadil platnou hodnotu do `link[0]`. Aspose.Slides zapíše tuto hodnotu do dokumentu Markdown a neprovede výchozí lokální uložení.
- Vraťte `false`, aby Aspose.Slides obrázek uložil lokálně a vygeneroval odkaz podle hodnot nastavených pomocí [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/markdownsaveoptions/) a [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/cs/java/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Handler, který vrátí `true`, přebírá odpovědnost za obrázek. Pokud vrátí `true` bez přiřazení platného, neprázdného odkazu, export selže s výjimkou `InvalidOperationException`.
{{% /alert %}}

### **Ukládání obrázků do adresáře CDN a použití externích URL**

Následující příklad považuje `cdn-origin/presentations/quarterly-report` za připojený nebo synchronizovaný adresář CDN. Každý handler získá vygenerovaný název souboru, uloží obrázek do tohoto vlastního adresáře a nahradí vygenerovaný lokální odkaz veřejnou URL CDN. Vzorek sám neprovádí žádné nahrávání do sítě: URL se stane platnou až po připojení adresáře jako CDN origin nebo po zveřejnění jeho souborů v CDN. Pro objektové úložiště nahraďte zápis do souborového systému operací nahrání SDK úložiště a přiřaďte `link[0]` až po úspěšném nahrání.

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Bitmapový handler úmyslně vrací `false` pro obrázky menší než 128 × 128 pixelů, takže Aspose.Slides ukládá tyto obrázky do `output/fallback-images` pomocí výchozího chování. Větší bitmapové a metafile zdroje, stejně jako SVG zdroje, jsou zpracovány vlastním kódem. Například vygenerovaný lokální odkaz jako `fallback-images/image1.png` se změní na `https://cdn.example.com/presentations/quarterly-report/image1.png`. Handlery používají cesty operačního systému pouze při zápisu souborů; odkazy zapisované do Markdownu používají lomítka a URL‑kódované názvy souborů. Používejte stejný postup při tvorbě relativních odkazů: používejte `/`, ne platformově specifický oddělovač adresářů.

## **Často kladené otázky**

**Může jeden handler zpracovávat jak rastrové obrázky, tak SVG obrázky?**

Ne. Použijte [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/cs/java/com.aspose.slides/markdownsaveoptions/) pro bitmapové a metafile zdroje a [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/cs/java/com.aspose.slides/markdownsaveoptions/) pro zdroje vydávané jako SVG. První metoda poskytuje objekt [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/) a hodnotu [ImageFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imageformat/); druhá poskytuje objekt [ISvgImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isvgimage/), jehož SVG data lze číst pomocí [ISvgImage.getSvgData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isvgimage/). SVG zdroj, který je během exportu rasterizován, je místo toho zpracován callbackem pro ukládání obrázku.

**Co se stane, když handler pro ukládání obrázku vrátí `false`?**

Aspose.Slides použije své výchozí chování pro lokální ukládání. Umístění obrázku a vygenerovaný odkaz jsou řízeny hodnotami nastavenými pomocí [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/markdownsaveoptions/) a [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/cs/java/com.aspose.slides/markdownsaveoptions/).

**Může handler poskytnout URL bez lokálního uložení obrázku?**

Ano. Handler může nahrát obrázek do objektového úložiště nebo jej předat jiné službě, přiřadit vzniklou URL k `link[0]` a vrátit `true`. Handler musí zpracování dokončit sám; vrácení `true` zabraňuje výchozímu lokálnímu uložení.

**Proč export do Markdownu vyhodí `InvalidOperationException` z handleru?**

Tato výjimka nastane, když handler vrátí `true`, ale neposkytne platný odkaz. Před vrácením `true` přiřaďte relativní cestu nebo externí URL, která se má zapsat do Markdownu.

**Jaký oddělovač cest by měly odkazy na obrázky používat?**

V odkazech a URL v Markdownu používejte lomítka (`/`). `Path.resolve` používejte jen pro cesty v souborovém systému a poté samostatně vytvořte nebo normalizujte odkaz v Markdownu.

**Zachovávají se hypertextové odkazy při exportu do Markdownu?**

Ano. Textové [hyperlinky](/slides/cs/java/manage-hyperlinks/) jsou zachovány jako standardní odkazy v Markdownu. Přechody [slide](/slides/cs/java/slide-transition/) a [animace](/slides/cs/java/powerpoint-animation/) nejsou převedeny.

**Lze prezentace převádět do Markdownu paralelně?**

Můžete zpracovávat různé soubory prezentací paralelně, ale nesdílejte stejnou instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) mezi vlákny. Řiďte se [pokyny pro multithreading](/slides/cs/java/multithreading/) a použijte samostatnou instanci pro každý soubor.