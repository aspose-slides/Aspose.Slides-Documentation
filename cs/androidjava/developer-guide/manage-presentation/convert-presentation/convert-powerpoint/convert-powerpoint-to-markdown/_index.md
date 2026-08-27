---
title: Převod prezentací PowerPoint do Markdownu na Androidu
linktitle: PowerPoint do Markdownu
type: docs
weight: 140
url: /cs/androidjava/convert-powerpoint-to-markdown/
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
- Android
- Java
- Aspose.Slides
description: "Převádějte prezentace PPT a PPTX do Markdownu na Androidu pomocí Javy a ovládejte, kam jsou exportované bitmapové, metafile a SVG obrázky uloženy a na ně odkazováno."
---
## **Přehled**

Aspose.Slides for Android via Java dokáže převádět prezentace PPT a PPTX do Markdownu pro dokumentaci, statické weby, migraci obsahu a workflow verzování. Můžete zvolit typ Markdownu, nastavit způsob vykreslení obsahu snímků a rozhodnout, kde budou exportované obrázky uloženy a jak bude vygenerovaný Markdown na ně odkazovat.

Ve výchozím nastavení export Markdownu používá pouze textový výstup. Chcete‑li exportovat vizuální obsah, nastavte typ exportu metodou [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/markdownsaveoptions/) na hodnotu `Sequential` nebo `Visual` z výčtu [MarkdownExportType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/markdownexporttype/). `Sequential` vykresluje položky snímku odděleně a v pořadí, zatímco `Visual` zachovává seskupené položky dohromady, aby si uchovaly vizuální vztah. Hodnota `TextOnly` nevypisuje obrázkové zdroje, takže se v tomto režimu nevolají zpětné volání pro ukládání obrázků.

## **Převod prezentace do Markdownu**

Načtěte vstupní soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) a poté zavolejte metodu [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) s hodnotou `Md` z výčtu [SaveFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveformat/).

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

## **Výběr typu Markdownu**

Metoda [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/markdownsaveoptions/) určuje specifikaci Markdownu použitého pro výstup. Výčet [Flavor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/flavor/) zahrnuje CommonMark, GitHub Flavored Markdown a další podporované varianty.

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

Třída [MarkdownSaveOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/markdownsaveoptions/) poskytuje dvě metody pro konfiguraci lokálně uložených obrázků:

- [setBasePath](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/markdownsaveoptions/) určuje základní adresář pro dokument Markdown a jeho zdroje.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/markdownsaveoptions/) určuje podadresář pro obrázky. Výchozí hodnota je `Images`.

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

Toto chování také slouží jako záloha, když vlastní obsluha ukládání obrázků vrátí `false`.

## **Přizpůsobení ukládání obrázků a odkazů v Markdownu**

Pomocí metody [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/markdownsaveoptions/) můžete zaregistrovat zpětné volání pro bitmapové a metafile zdroje, které nejsou ve formátu SVG, a jsou generovány během exportu do Markdownu. Jeho zpětné volání `MarkdownImageSavingHandler` přijímá objekt [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/), jeho hodnotu [ImageFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imageformat/) a vygenerovaný odkaz v Markdownu jako jednoprvkový parametr typu `String[]`. Uložte nebo nahrajte obrázek ve zvoleném formátu a nahraďte `link[0]` odkazem, který má být zapsán do výstupu Markdownu.

Zdrojové soubory ve formátu SVG jsou zpracovány odděleně. Zaregistrujte zpětné volání metodou [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/markdownsaveoptions/). Jeho zpětné volání `MarkdownSvgImageSavingHandler` přijímá objekt [ISvgImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgimage/) a jednoprvkový parametr `String[] link`. SVG nemá argument `ImageFormat`; místo toho zapíšete nebo nahrajete jeho XML data pomocí metody [ISvgImage.getSvgData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgimage/). V závislosti na režimu exportu a vizuálním seskupení může být SVG v původní prezentaci rasterizováno nebo sloučeno s dalším obsahem; výsledný ne‑SVG zdroj je následně předán zpětnému volání pro ukládání obrázků. Zaregistrujte obě zpětná volání, pokud každý exportovaný vizuální zdroj vyžaduje vlastní zpracování.

Návratová hodnota obslužné rutiny určuje, kdo obrázek zpracuje:

- Vraťte `true`, pokud obsluha obrázek uložila, nahrála, transformovala nebo jinak zpracovala a přiřadila platnou hodnotu do `link[0]`. Aspose.Slides zapíše tuto hodnotu do dokumentu Markdown a neprovedete výchozí lokální uložení.
- Vraťte `false`, aby Aspose.Slides obrázek uložil lokálně a vygeneroval odkaz podle hodnot nastavených pomocí [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/markdownsaveoptions/) a [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Obsluha, která vrátí `true`, přebírá odpovědnost za obrázek. Pokud vrátí `true` bez přiřazení platného, neprázdného odkazu, export selže s výjimkou `InvalidOperationException`.
{{% /alert %}}

### **Ukládání obrázků do adresáře CDN a používání externích URL**

Následující příklad zachází s `cdn-origin/presentations/quarterly-report` jako s připojeným nebo synchronizovaným adresářem CDN. Každá obsluha získá vygenerovaný název souboru, uloží obrázek do tohoto vlastního adresáře a nahradí lokální odkaz veřejnou URL CDN. Vzor samotný neprovádí žádné nahrávání přes síť: URL bude platná až po připojení adresáře jako CDN origin nebo po publikování jeho souborů na CDN. Pro objektové úložiště nahraďte zápis do souborového systému operací nahrávání SDK úložiště a přiřaďte `link[0]` až po úspěšném nahrání.

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

Bitmapová obsluha úmyslně vrací `false` pro obrázky menší než 128 × 128 pixelů, takže Aspose.Slides uloží tyto obrázky do `output/fallback-images` pomocí výchozího chování. Větší bitmapové a metafile zdroje i SVG jsou zpracovány vlastním kódem. Například lokální odkaz `fallback-images/image1.png` se změní na `https://cdn.example.com/presentations/quarterly-report/image1.png`. Obslužné rutiny používají cesty operačního systému pouze při zápisu souborů; odkazy v Markdownu používají lomítka a URL‑kódované názvy souborů. Používejte stejný postup i při tvorbě relativních odkazů: použijte `/`, ne platformově specifický oddělovač adresářů.

## **Často kladené otázky**

**Může jedna obsluha zpracovávat jak rastrové obrázky, tak SVG?**

Ne. Použijte [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/markdownsaveoptions/) pro bitmapové a metafile zdroje a [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/markdownsaveoptions/) pro zdroje ve formátu SVG. První poskytuje objekt [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/) a hodnotu [ImageFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imageformat/); druhý poskytuje objekt [ISvgImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgimage/) jehož SVG data lze číst pomocí [ISvgImage.getSvgData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgimage/). SVG zdroj, který je během exportu rasterizován, je zpracován obslužnou rutinou pro ukládání obrázků.

**Co se stane, když obsluha ukládání obrázků vrátí `false`?**

Aspose.Slides použije své výchozí lokální ukládání. Umístění obrázku a vygenerovaný odkaz jsou řízeny hodnotami nastavenými pomocí [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/markdownsaveoptions/) a [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/markdownsaveoptions/).

**Může obsluha poskytnout URL bez lokálního uložení obrázku?**

Ano. Obsluha může obrázek nahrát do objektového úložiště nebo předat jinému servisu, přiřadit vzniklou URL do `link[0]` a vrátit `true`. Obsluha musí zpracování dokončit sama; vrácení `true` zabrání výchozímu lokálnímu uložení.

**Proč export Markdownu vyvolá výjimku `InvalidOperationException` z obslužné rutiny?**

K této výjimce dochází, když obsluha vrátí `true`, ale neposkytne platný odkaz. Před návratem `true` přiřaďte relativní cestu nebo externí URL, která má být zapsána do Markdownu.

**Jaký oddělovač cesty by měly používat odkazy na obrázky?**

V odkazech Markdown a URL používejte lomítka (`/`). `Path.resolve` používejte jen pro cesty v souborovém systému a poté samostatně vytvořte nebo normalizujte odkaz v Markdownu.

**Zachovají se hypertextové odkazy během exportu do Markdownu?**

Ano. Textové [hyperlinks](/slides/cs/androidjava/manage-hyperlinks/) jsou zachovány jako standardní odkazy Markdown. Přechody snímků [transitions](/slides/cs/androidjava/slide-transition/) a [animations](/slides/cs/androidjava/powerpoint-animation/) nejsou konvertovány.

**Lze prezentace převádět do Markdownu paralelně?**

Ano, můžete zpracovávat různé soubory prezentací paralelně, ale nesdílejte stejnou instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) mezi vlákny. Dodržujte [multithreading guidelines](/slides/cs/androidjava/multithreading/) a použijte samostatnou instanci pro každý soubor.