---
title: Převést prezentace PowerPoint do HTML na Androidu
linktitle: PowerPoint do HTML
type: docs
weight: 30
url: /cs/androidjava/convert-powerpoint-to-html/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint do HTML
- prezentace do HTML
- snímek do HTML
- PPT do HTML
- PPTX do HTML
- uložit PowerPoint jako HTML
- uložit prezentaci jako HTML
- uložit snímek jako HTML
- uložit PPT jako HTML
- uložit PPTX jako HTML
- exportovat PPT do HTML
- exportovat PPTX do HTML
- Android
- Java
- Aspose.Slides
description: "Převést prezentace PowerPoint do HTML na Androidu. Použijte Aspose.Slides pro Android přes Java k exportu souborů PPT a PPTX, vybraných snímků, poznámek, písem, obrázků, SVG a médií."
---
## **Přehled**

Aspose.Slides for Android via Java může ukládat prezentace PowerPoint do HTML bez Microsoft PowerPoint. Základní konverze spočívá v načtení jedné [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) a volání `save` s [SaveFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveformat/). Použijte [HtmlOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/htmloptions/), když potřebujete řídit exportovaný rozvrh, písma, obrázky, poznámky, komentáře, výstup SVG nebo propojené zdroje.

Tento průvodce se zaměřuje na praktické scénáře exportu HTML:

- Exportovat celou prezentaci nebo vybrané snímky.
- Vytvořit HTML s pevnou layout, responzivní nebo založené na SVG.
- Zahrnout poznámky přednášejícího a komentáře.
- Ovládat kvalitu obrázků a data o oříznutých oblastech obrázků.
- Vkládat písma nebo ukládat soubory písem odděleně.
- Zvolit, jak jsou externí zdroje a mediální soubory zapisovány a odkazovány.

Ve výchozím nastavení export HTML vytváří samostatný HTML dokument, kde jsou většina zdrojů vloženy. To je pohodlné pro sdílení jednoho souboru, ale může zvětšit velikost výstupu. Pro publikaci na webu zvažte externí zdroje, nižší DPI obrázků a vkládání pouze písem, která nejsou spolehlivě dostupná v cílovém prostředí.

## **Převést prezentaci do HTML**

Pro export prezentace do HTML ji načtěte pomocí [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) a uložte pomocí [SaveFormat.Html](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Tento příklad zapíše jeden HTML soubor. Objekt prezentace je uvolněn v bloku `finally`, který po exportu uvolní souborové handle a zdroje pro renderování.

## **Použít HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/htmloptions/) je hlavní konfigurační třída pro export do HTML. Běžná nastavení zahrnují:

- `SlidesLayoutOptions`: přidává poznámky, komentáře, podklady nebo další informace o rozvrhu.
- `HtmlFormatter`: mění strukturu HTML dokumentu nebo deleguje formátování na řadič.
- `SlideImageFormat`: mění způsob, jakým jsou snímky reprezentovány, například jako SVG.
- `PicturesCompression`: řídí DPI obrázků a velikost výstupu.
- `DeletePicturesCroppedAreas`: zachovává nebo odstraňuje data o oříznutých obrázcích.
- `SvgResponsiveLayout`: umožňuje exportovanému SVG obsahu přizpůsobit se svému kontejneru.
- `ShowHiddenSlides`: zahrnuje skryté snímky, pokud je to požadováno.

Následující sekce ukazují nejčastější možnosti odděleně, abyste mohli kombinovat pouze ty, které potřebujete ve svém pracovním postupu.

## **Převést vybrané snímky do HTML**

Přetížení `Presentation.save`, které přijímá čísla snímků, používá číslování snímků od jedné. Smyčka níže ukládá každý snímek do samostatného HTML souboru.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();

    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        int slideNumber = slideIndex + 1;
        int[] slideNumbers = { slideNumber };
        String htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Použijte tento vzor, když webová stránka nebo aplikace vyžaduje jednu HTML stránku na snímek. Pokud má každý snímek mít stejný rozvrh, vytvořte jednu instanci [HtmlOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/htmloptions/) a předávejte ji každému volání `save`.

## **Vytvořit responzivní HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/responsivehtmlcontroller/) poskytuje responzivní výstup HTML pomocí [HtmlFormatter](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/htmlformatter/). Použijte jej, když má exportovaná stránka lépe přizpůsobovat šířce prohlížeče.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Pro responzivní rozvrh založený na SVG nastavte `SvgResponsiveLayout` na [HtmlOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/htmloptions/). To je užitečné, když je obsah snímku exportován jako škálovatelný SVG markup.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Zahrnout poznámky přednášejícího a komentáře**

Použijte [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/notescommentslayoutingoptions/) prostřednictvím `HtmlOptions.SlidesLayoutOptions` pro zahrnutí poznámek přednášejícího nebo komentářů. Poznámky a komentáře jsou ve výchozím nastavení skryté, pokud si nevyberete jejich umístění.

Předpokládejme, že zdrojová prezentace obsahuje poznámky přednášejícího:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Následující kód exportuje obsah snímku s poznámkami přednášejícího pod snímkem.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(NotesPositions.BottomFull);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Exportovaný HTML zahrnuje oblast poznámek:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Pro export komentářů nastavte `CommentsPosition`, například na `CommentsPositions.Right` nebo `CommentsPositions.Bottom`. Pokud potřebujete jen komentáře, vynechte `NotesPosition`. Pokud potřebujete jak poznámky, tak komentáře, nastavte obě vlastnosti.

## **Ovládání kvality obrázků a oříznutých oblastí**

Export HTML může komprimovat obrázky snímků, aby snížil velikost výstupu. Nastavte `PicturesCompression` na hodnotu z [PicturesCompression](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/picturescompression/), když potřebujete vyšší kvalitu obrázků.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setPicturesCompression(PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Ve výchozím nastavení mohou být oříznuté oblasti obrázků z exportovaného výstupu odstraněny. Uchovávejte oříznutá data jen když uživatelé potřebují tyto skryté části obrázku obnovit nebo zkontrolovat. Uchování může zvýšit velikost HTML.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Přidat CSS**

Pro jednoduché stylování předávejte řetězec CSS do `HtmlFormatter.createDocumentFormatter`. To mění okolní HTML dokument, zatímco Aspose.Slides pokračuje v renderování obsahu snímku.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    HtmlFormatter formatter = HtmlFormatter.createDocumentFormatter(cssRules, true);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Pro vlastní záhlaví dokumentu, propojený CSS soubor nebo vlastní markup kolem snímků a tvarů implementujte [IHtmlFormattingController](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihtmlformattingcontroller/) a předávejte jej do [HtmlFormatter](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/htmlformatter/) pomocí `createCustomFormatter`.

## **Vkládat písma**

Pokud cílové prostředí nemusí mít nainstalována písma prezentace, vložte písma do HTML pomocí [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/embedallfontshtmlcontroller/). Vkládání zlepšuje vizuální věrnost, ale zvětšuje velikost výstupu.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial", "Calibri" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Vylučujte písma pouze když jste si jisti, že cílové prohlížeče nebo systémy je již poskytují. Pro firemní písma nebo méně běžná písma je vkládání obvykle bezpečnější.

## **Propojit soubory písem místo jejich vkládání**

Aby se snížila velikost HTML souboru, můžete data písem zapsat do samostatných WOFF souborů a přidat pravidla `@font-face` do HTML. Následující pomocník rozšiřuje [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) a přepisuje `writeFont`.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final String fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            String fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";
        
        File dirs = new File(fontOutputDirectory);
        dirs.mkdirs();
    }

    @Override
    public void writeFont(
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData) {
        try {
            IFontData font = substitutedFont == null ? originalFont : substitutedFont;
            String safeFontName = makeSafeFileName(font.getFontName());
            String safeFontStyle = fontStyle == null || fontStyle.trim().isEmpty() ? "normal" : fontStyle;
            String safeFontWeight = fontWeight == null || fontWeight.trim().isEmpty() ? "normal" : fontWeight;
            String fontFileName = safeFontName + "-" + safeFontStyle + "-" + safeFontWeight + ".woff";
            String fontFilePath = fontOutputDirectory + "/" + fontFileName;

            FileOutputStream fos = new FileOutputStream(fontFilePath);
            fos.write(fontData);
            fos.close();

            String encodedFontFileName = java.net.URLEncoder.encode(fontFileName, "UTF-8");
            String fontUrl = fontUrlPrefix + encodedFontFileName.replace("+", "%20");
            String escapedBackslashes = font.getFontName().replace("\\", "\\\\");
            String fontFamily = escapedBackslashes.replace("'", "\\'");

            generator.addHtml("<style>");
            generator.addHtml("@font-face {");
            generator.addHtml("font-family: '" + fontFamily + "';");
            generator.addHtml("font-style: " + safeFontStyle + ";");
            generator.addHtml("font-weight: " + safeFontWeight + ";");
            generator.addHtml("src: url('" + fontUrl + "') format('woff');");
            generator.addHtml("}");
            generator.addHtml("</style>");
        } catch (java.io.IOException exception) {
            throw new RuntimeException("Unable to write an exported font.", exception);
        }
    }

    private String makeSafeFileName(String fileName) {
        String invalidCharacters = "\\/:*?\"<>|";
        char[] safeCharacters = fileName.toCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters.length; characterIndex++) {
            if (invalidCharacters.indexOf(safeCharacters[characterIndex]) >= 0) {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new String(safeCharacters);
    }
}

String outputDirectory = System.getProperty("user.dir") + "/html-output";
String fontsDirectory = outputDirectory + "/fonts";
File dir = new File("path/to/folder");
dir.mkdir();

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    String htmlFilePath = outputDirectory + "/presentation.html";
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

V tomto příkladu jsou soubory písem uloženy do `html-output/fonts` a HTML na ně odkazuje pomocí URL jako `fonts/BrandFont-normal-400.woff`. Pokud jsou HTML soubor a písma nasazeny na jiné místo, zvolte `fontUrlPrefix` tak, aby odpovídal nasazené URL cestě.

## **Uložit zdroje externě**

Samostatný HTML je snadno přenositelný, ale vložené Base64 zdroje mohou učinit soubor velkým. Pokud vaše aplikace potřebuje externí soubory obrázků, implementujte [ILinkEmbedController](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilinkembedcontroller/) a předávejte jej konstruktoru [HtmlOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/htmloptions/).

Při externalizaci zdrojů zvolte dvě cesty úmyslně:

- Cesta výstupu souborového systému, kam vaše aplikace zapisuje vygenerované obrázky, písma, audio nebo video.
- Cesta URL, která je používána prohlížečem z HTML dokumentu k načtení těchto souborů.

## **Exportovat mediální soubory**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/videoplayerhtmlcontroller/) exportuje video a audio soubory a zapisuje HTML, které je může přehrát v prohlížeči. Jeho konstruktor přijímá:

- `path`: adresář, do kterého budou zapsány vygenerované mediální soubory.
- `fileName`: název generovaného HTML souboru.
- `baseUri`: absolutní URI prefix používáný v HTML odkazech na mediální soubory.

Pokud je HTML soubor `html-output/presentation.html` a mediální soubory jsou uloženy v `html-output/media`, `path` by měl ukazovat na mediální adresář na disku, zatímco `baseUri` by měl ukazovat na stejný adresář z pohledu prohlížeče. Pro lokální náhled můžete vytvořit `file:///` URI z mediálního adresáře. Pro nasazenou aplikaci použijte absolutní URL publikovaného mediálního adresáře.

```java
String outputDirectory = System.getProperty("user.dir") + "/html-output";
String mediaDirectory = outputDirectory + "/media";
File outDir = new File(outputDirectory);
outDir.mkdir();
File mediaDir = new File(mediaDirectory);
mediaDir.mkdir();

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory;

Presentation presentation = new Presentation();
try {
    byte[] videoData = ...;// intro.mp4

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory;
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    String htmlFilePath = outputDirectory + "/" + htmlFileName;
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Používejte výstupní adresáře, které jsou jedinečné pro každý export, zejména v serverových aplikacích. Sdílené výstupní cesty mohou způsobit přepsání souborů z různých konverzí.

## **Výkon a správa zdrojů**

Konverze HTML je operace renderování, takže doba zpracování a spotřeba paměti závisí na počtu snímků, rozlišení obrázků, písmech, efektech, grafech a vložených médiích. Vyšší hodnoty DPI `PicturesCompression`, vložená písma, výstup SVG a zachování oříznutých oblastí obrázků mohou zlepšit věrnost, ale obvykle zvětší velikost výstupu.

Pro dávkovou konverzi:

- Okamžitě uvolňujte každou instanci [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
- Používejte samostatné výstupní adresáře pro jednotlivé úlohy.
- Vyhněte se vkládání běžných písem, pokud to není nutné pro věrnost.
- Snižte DPI obrázků, pokud je HTML určen pro náhled nebo miniatury.
- Uchovávejte zdrojovou prezentaci, vygenerované HTML a externí zdroje společně, dokud nejsou finální cesty nasazení.

## **Často kladené dotazy**

**Jsou hypertextové odkazy zachovány v HTML výstupu?**

Ano. Hypertextové odkazy z prezentace jsou exportovány do HTML a zůstávají klikatelné, pokud je cílová URL platná.

**Mohu konvertovat prezentace do HTML paralelně?**

Ano, ale nesdílejte jednu [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) instanci mezi vlákny. Zpracovávejte různé soubory s oddělenými instancemi prezentace, oddělenými proudy a oddělenými výstupními adresáři. Viz [multithreading guidance](/slides/cs/androidjava/multithreading/) pro podrobnosti.

**Je objekt Presentation vlákny bezpečný?**

Ne. Jedna [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) instanci by měla být načtena, upravena, uložena a uvolněna v jednom vlákně. Pro paralelní práci vytvořte nezávislou instanci na každé vlákno nebo proces.

**Proč je vygenerovaný HTML soubor velký?**

Výchozí export může vložit zdroje přímo do HTML. Vložená písma, obrázky s vysokým DPI, média, SVG obsah a zachování oříznutých oblastí obrázku také zvětšují velikost. Použijte externí zdroje, vyloučte běžná písma z vkládání a snižte `PicturesCompression`, pokud je menší výstup důležitější než maximální věrnost.

**Proč se velikost písma v PowerPointu 24 pt zobrazí v HTML jako 17.999819 pt?**

K tomu může dojít, protože PowerPoint a HTML používají odlišné DPI modely. PowerPoint ukládá velikosti textu v typografických bodech založených na 72 DPI, zatímco rozvržení HTML je založeno na CSS pixelech v modelu 96 DPI. Při exportu prezentace do HTML Aspose.Slides převádí velikost písma mezi těmito systémy a převod může zavést malé zaokrouhlovací rozdíly.

Tyto hodnoty neindikují skutečnou vizuální změnu velikosti písma. Jedná se pouze o matematický vedlejší efekt převodu textových metrik mezi PowerPointem a HTML.

**Jak si vybrat baseUri pro export médií?**

Zvolte `baseUri` z pohledu prohlížeče a předávejte jej jako absolutní URI. Pro lokální náhled můžete odvodit `baseUri` z výstupního adresáře pomocí `mediaDirectory.toUri().toString()`. Pro nasazení použijte absolutní URL publikovaného mediálního adresáře. Souborový systém `path` a prohlížeč `baseUri` nemusí být stejný řetězec, ale musí popisovat stejnou lokaci zdroje.

**Mohu zahrnout skryté snímky?**

Ano. Nastavte `ShowHiddenSlides` na `true` na [HtmlOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/htmloptions/), když musí být skryté snímky exportovány.