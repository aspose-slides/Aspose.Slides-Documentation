---
title: Převod prezentací PowerPoint do HTML v Javě
linktitle: PowerPoint do HTML
type: docs
weight: 30
url: /cs/java/convert-powerpoint-to-html/
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
- Java
- Aspose.Slides
description: "Převod prezentací PowerPoint do HTML v Javě. Použijte Aspose.Slides k exportu souborů PPT a PPTX, vybraných snímků, poznámek, písem, obrázků, SVG a médií."
---
## **Přehled**

Aspose.Slides for Java může ukládat prezentace PowerPoint jako HTML bez Microsoft PowerPoint. Základní konverze spočívá v načtení jedné [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a volání `save` s [SaveFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/). Použijte [HtmlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/htmloptions/), pokud potřebujete řídit exportovaný rozvrh, písma, obrázky, poznámky, komentáře, výstup SVG nebo propojené zdroje.

Tento průvodce se zaměřuje na praktické scénáře exportu HTML:

- Exportovat celou prezentaci nebo vybrané snímky.
- Vytvořit HTML s pevně daným rozvržením, responzivní nebo založené na SVG.
- Zahrnout poznámky přednášejícího a komentáře.
- Řídit kvalitu obrázků a oříznutá data obrázků.
- Vložit písma nebo uložit soubory písem odděleně.
- Zvolit, jak jsou externí zdroje a mediální soubory zapisovány a odkazovány.

Ve výchozím nastavení export HTML vytváří samostatný HTML dokument, ve kterém jsou většina zdrojů vloženy. To je pohodlné pro sdílení jednoho souboru, ale může zvýšit velikost výstupu. Pro publikování na webu zvažte externí zdroje, nižší DPI obrázků a vkládání pouze písem, která nejsou spolehlivě dostupná v cílovém prostředí.

## **Převod prezentace do HTML**

Pro export prezentace do HTML ji načtěte pomocí [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a uložte pomocí [SaveFormat.Html](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Tento příklad zapíše jeden soubor HTML. Objekt prezentace je uvolněn v bloku `finally`, který po exportu uvolní souborové handly a renderovací zdroje.

## **Použití HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/htmloptions/) je hlavní konfigurační třída pro export HTML. Běžná nastavení zahrnují:

- `SlidesLayoutOptions`: přidává poznámky, komentáře, podklady nebo jiné informace o rozvržení.
- `HtmlFormatter`: mění strukturu HTML dokumentu nebo deleguje formátování na řadič.
- `SlideImageFormat`: mění způsob, jakým jsou snímky reprezentovány, například jako SVG.
- `PicturesCompression`: řídí DPI obrázků a velikost výstupu.
- `DeletePicturesCroppedAreas`: zachovává nebo odstraňuje oříznutá data obrázků.
- `SvgResponsiveLayout`: umožňuje exportovanému SVG obsahu přizpůsobit se svému kontejneru.
- `ShowHiddenSlides`: zahrnuje skryté snímky, když je to požadováno.

Následující sekce ukazují nejčastější možnosti samostatně, abyste mohli kombinovat jen ty, které váš pracovní postup potřebuje.

## **Převod vybraných snímků do HTML**

Přetížení `Presentation.save`, které přijímá čísla snímků, používá pozice snímků číslované od 1. Smyčka níže ukládá každý snímek do samostatného souboru HTML.

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

Použijte tento vzor, když webová stránka nebo aplikace potřebuje jednu HTML stránku na snímek. Pokud má mít každý snímek stejné rozvržení, vytvořte jednu instanci [HtmlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/htmloptions/) a předávejte ji každému volání `save`.

## **Vytvoření responzivního HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/cs/java/com.aspose.slides/responsivehtmlcontroller/) poskytuje responzivní výstup HTML přes [HtmlFormatter](https://reference.aspose.com/slides/cs/java/com.aspose.slides/htmlformatter/). Použijte jej, když má exportovaná stránka lépe reagovat na šířku prohlížeče.

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

Pro responzivní rozvržení založené na SVG nastavte `SvgResponsiveLayout` na [HtmlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/htmloptions/). To je užitečné, když je obsah snímku exportován jako škálovatelný SVG markup.

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

## **Zahrnutí poznámek přednášejícího a komentářů**

Použijte [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/notescommentslayoutingoptions/) prostřednictvím `HtmlOptions.setSlidesLayoutOptions` k zahrnutí poznámek přednášejícího nebo komentářů. Poznámky a komentáře jsou ve výchozím nastavení skryté, pokud si nevyberete jejich pozice.

Předpokládejme, že zdrojová prezentace obsahuje poznámky přednášejícího:

![Snímek s poznámkami přednášejícího v PowerPointu](slide_with_notes.png)

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

Výstup HTML se snímkem a poznámkami přednášejícího:

![Výstup HTML se snímkem a poznámkami přednášejícího](HTML_with_notes.png)

Pro export komentářů nastavte `CommentsPosition`, například na `CommentsPositions.Right` nebo `CommentsPositions.Bottom`. Pokud potřebujete jen komentáře, vynechejte `NotesPosition`. Pokud potřebujete jak poznámky, tak komentáře, nastavte obě vlastnosti.

## **Řízení kvality obrázků a oříznutých oblastí**

Export HTML může komprimovat obrázky snímků pro snížení velikosti výstupu. Nastavte `PicturesCompression` na hodnotu z [PicturesCompression](https://reference.aspose.com/slides/cs/java/com.aspose.slides/picturescompression/), pokud potřebujete vyšší kvalitu obrázku.

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

Ve výchozím nastavení mohou být oříznuté oblasti obrázků odstraněny z exportovaného výstupu. Zachovejte oříznutá data pouze tehdy, když uživatelé musí mít možnost obnovit nebo prozkoumat tyto skryté části obrázku. Zachování může zvýšit velikost HTML.

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

## **Přidání CSS**

Pro jednoduché stylování předávejte řetězec CSS do `HtmlFormatter.createDocumentFormatter`. Tím se změní okolní HTML dokument, zatímco Aspose.Slides nadále vykresluje obsah snímku.

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

Pro vlastní hlavičku dokumentu, propojený soubor CSS nebo vlastní markup okolo snímků a tvarů implementujte [IHtmlFormattingController](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihtmlformattingcontroller/) a předávejte jej do [HtmlFormatter](https://reference.aspose.com/slides/cs/java/com.aspose.slides/htmlformatter/) pomocí `createCustomFormatter`.

## **Vložení písem**

Pokud cílové prostředí nemusí mít nainstalovaná písma prezentace, vložte písma do HTML pomocí [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cs/java/com.aspose.slides/embedallfontshtmlcontroller/). Vkládání zlepšuje vizuální věrnost, ale zvyšuje velikost výstupu.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Vyjměte písma pouze tehdy, když jste si jisti, že cílové prohlížeče nebo systémy je již poskytují. Pro firemní písma nebo méně běžná písma je vkládání obvykle bezpečnější.

## **Propojit soubory písem místo jejich vkládání**

Pro snížení velikosti souboru HTML můžete zapisovat data písem do samostatných souborů WOFF a přidat pravidla `@font-face` do HTML. Následující pomocník rozšiřuje [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cs/java/com.aspose.slides/embedallfontshtmlcontroller/) a přepisuje `writeFont`.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final java.nio.file.Path fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            java.nio.file.Path fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";

        java.nio.file.Files.createDirectories(fontOutputDirectory);
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
            java.nio.file.Path fontFilePath = fontOutputDirectory.resolve(fontFileName);

            java.nio.file.Files.write(fontFilePath, fontData);

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

java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path fontsDirectory = outputDirectory.resolve("fonts");
java.nio.file.Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve("presentation.html");
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

V tomto příkladu jsou soubory písem uloženy do `html-output/fonts` a HTML na ně odkazuje pomocí URL, například `fonts/BrandFont-normal-400.woff`. Pokud jsou soubor HTML a písma nasazeny na jiné místo, vyberte `fontUrlPrefix`, aby odpovídal nasazené URL cestě.

## **Uložení zdrojů externě**

Samostatný HTML je snadno přenosný, ale vložené zdroje Base64 mohou zvětšit soubor. Pokud vaše aplikace potřebuje externí soubory obrázků, implementujte [ILinkEmbedController](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilinkembedcontroller/) a předávejte jej do konstruktoru [HtmlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/htmloptions/).

Když externalizujete zdroje, zvolte dva cesty úmyslně:

- Cestu výstupu v souborovém systému, kde vaše aplikace zapisuje vygenerované obrázky, písma, audio nebo video.
- Cestu URL, kterou prohlížeč používá z HTML dokumentu k načtení těchto souborů.

## **Export mediálních souborů**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/cs/java/com.aspose.slides/videoplayerhtmlcontroller/) exportuje video a audio soubory a zapisuje HTML, které je může přehrát v prohlížeči. Jeho konstruktor přijímá:

- `path`: adresář, kam budou zapisovány vygenerované mediální soubory.
- `fileName`: název generovaného HTML souboru.
- `baseUri`: absolutní URI prefix používaný v HTML odkazech na mediální soubory.

Pokud je HTML soubor `html-output/presentation.html` a mediální soubory jsou uloženy v `html-output/media`, `path` by měl ukazovat na mediální adresář na disku, zatímco `baseUri` by měl ukazovat na stejný adresář z pohledu prohlížeče. Pro místní náhled můžete vytvořit `file:///` URI z mediálního adresáře. Pro nasazenou aplikaci použijte absolutní URL publikovaného mediálního adresáře.

```java
java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path mediaDirectory = outputDirectory.resolve("media");
java.nio.file.Files.createDirectories(outputDirectory);
java.nio.file.Files.createDirectories(mediaDirectory);

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory.toUri().toString();

Presentation presentation = new Presentation();
try {
    java.nio.file.Path videoFilePath = java.nio.file.Paths.get("intro.mp4");
    byte[] videoData = java.nio.file.Files.readAllBytes(videoFilePath);

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory.toString();
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve(htmlFileName);
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Používejte výstupní adresáře, které jsou jedinečné pro každou úlohu exportu, zejména ve serverových aplikacích. Sdílené výstupní cesty mohou způsobit, že soubory z různých konverzí se přepíší.

## **Výkon a správa zdrojů**

Konverze HTML je renderovací operace, takže doba zpracování a použití paměti závisí na počtu snímků, rozlišení obrázků, písmech, efektech, grafech a vložených médiích. Vyšší hodnoty DPI `PicturesCompression`, vložená písma, výstup SVG a zachování oříznutých oblastí obrázků mohou zlepšit věrnost, ale obvykle zvětší velikost výstupu.

Pro dávkovou konverzi:

- Okamžitě uvolňujte každou instanci [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
- Používejte oddělené výstupní adresáře pro různé úlohy.
- Vyhněte se vkládání běžných písem, pokud to není vyžadována věrnost.
- Snižte DPI obrázků, když je HTML určeno pro náhled nebo miniatury.
- Udržujte zdrojovou prezentaci, vygenerované HTML a externí zdroje společně, dokud nejsou finální nasazovací cesty.

## **Často kladené otázky**

**Zachovají se hypertextové odkazy v HTML výstupu?**

Ano. Hypertextové odkazy v prezentaci jsou exportovány do HTML a zůstávají klikatelné, pokud je cílová URL platná.

**Mohu převádět prezentace do HTML paralelně?**

Ano, ale nesdílejte jednu instanci [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) napříč vlákny. Zpracovávejte různé soubory s oddělenými instancemi prezentace, oddělenými proudy a oddělenými výstupními adresáři. Podrobnosti najdete v [multithreading guidance](/slides/cs/java/multithreading/).

**Je objekt Presentation vlákny bezpečný?**

Ne. Jedna instance [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) by měla být načtena, upravena, uložena a uvolněna v jednom vlákně. Pro paralelní práci vytvořte samostatnou instanci pro každé vlákno nebo proces.

**Proč je vygenerovaný HTML soubor velký?**

Výchozí export může vložit zdroje přímo do HTML. Vložená písma, obrázky s vysokým DPI, média, SVG obsah a zachování oříznutých oblastí obrázků také zvětšují velikost. Použijte externí zdroje, vyjměte běžná písma z vkládání a snižte `PicturesCompression`, když je menší výstup důležitější než maximální věrnost.

**Proč se velikost písma v PowerPointu, např. 24 pt, zobrazuje v HTML jako 17.999819 pt?**

K tomu může dojít, protože PowerPoint a HTML používají odlišné DPI modely. PowerPoint ukládá velikosti textu v typografických bodech založených na 72 DPI, zatímco rozvržení HTML vychází z CSS pixelů v modelu 96 DPI. Když Aspose.Slides exportuje prezentaci do HTML, velikost písma je převedena mezi těmito systémy a převod může zavést malé zaokrouhlovací rozdíly.

Tyto hodnoty neznamenají skutečnou vizuální změnu velikosti písma. Jsou jen matematickým vedlejším efektem převodu textových metrik mezi PowerPoint a HTML.

**Jak si mám vybrat baseUri pro export médií?**

Vyberte `baseUri` z pohledu prohlížeče a předávejte jej jako absolutní URI. Pro místní náhled jej můžete odvodit z výstupního adresáře pomocí `mediaDirectory.toUri().toString()`. Pro nasazení použijte absolutní URL publikovaného mediálního adresáře. Souborový `path` a prohlížečový `baseUri` nemusí být stejný řetězec, ale musí popisovat stejnou lokaci zdroje.

**Mohu zahrnout skryté snímky?**

Ano. Nastavte `ShowHiddenSlides` na `true` na [HtmlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/htmloptions/), když je třeba exportovat skryté snímky.