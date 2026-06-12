---
title: Převod prezentací PowerPoint do HTML v PHP
linktitle: PowerPoint do HTML
type: docs
weight: 30
url: /cs/php-java/convert-powerpoint-to-html/
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
- PHP
- Aspose.Slides
description: "Převod prezentací PowerPoint do HTML v PHP. Použijte Aspose.Slides k exportu souborů PPT a PPTX, vybraných snímků, poznámek, písem, obrázků, SVG a multimédií."
---
## **Přehled**

Aspose.Slides pro PHP přes Java může ukládat prezentace PowerPoint jako HTML bez Microsoft PowerPoint. Základní převod je načtení jedné [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a volání `save` s [SaveFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveformat/). Použijte [HtmlOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/htmloptions/), když potřebujete ovládat exportovaný rozvrh, písma, obrázky, poznámky, komentáře, výstup SVG nebo propojené zdroje.

Tento návod se zaměřuje na praktické scénáře exportu HTML:

- Exportovat celou prezentaci nebo vybrané snímky.
- Vytvořit HTML s pevnou rozlohou, responzivní nebo založené na SVG.
- Zahrnout poznámky přednášejícího a komentáře.
- Ovládat kvalitu obrázků a oříznutá data obrázků.
- Vložit písma nebo uložit soubory písem odděleně.
- Zvolit, jak jsou externí zdroje a mediální soubory zapisovány a odkazovány.

Ve výchozím nastavení export HTML vytváří samostatný HTML dokument, kde jsou většina zdrojů vloženy. To je pohodlné pro sdílení jednoho souboru, ale může zvýšit velikost výstupu. Pro publikování na webu zvažte externí zdroje, nižší DPI obrázků a vložení pouze těch písem, která nejsou spolehlivě dostupná v cílovém prostředí.

## **Převod prezentace do HTML**

Pro export prezentace do HTML ji načtěte pomocí [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a uložte pomocí [SaveFormat.Html](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveformat/).

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Tento příklad zapíše jeden HTML soubor. Objekt prezentace je uvolněn v bloku `finally`, který po exportu uvolní souborové handle a renderovací zdroje.

## **Použití HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/htmloptions/) je hlavní konfigurační třída pro export HTML. Běžná nastavení zahrnují:

- `SlidesLayoutOptions`: přidává poznámky, komentáře, podklady nebo jiné rozvrhové informace.
- `HtmlFormatter`: mění strukturu HTML dokumentu nebo deleguje formátování na kontroler.
- `SlideImageFormat`: mění způsob, jakým jsou snímky reprezentovány, například jako SVG.
- `PicturesCompression`: řídí DPI obrázků a velikost výstupu.
- `DeletePicturesCroppedAreas`: zachovává nebo odstraňuje oříznutá data obrázků.
- `SvgResponsiveLayout`: umožňuje exportovanému SVG obsahu přizpůsobit se kontejneru.
- `ShowHiddenSlides`: zahrnuje skryté snímky, pokud je to potřeba.

Následující sekce ukazují nejčastější možnosti samostatně, abyste mohli kombinovat jen ty, které váš pracovní postup potřebuje.

## **Převod vybraných snímků do HTML**

Přetížení `save`, které přijímá čísla snímků, používá číslování od 1. Smyčka níže ukládá každý snímek do samostatného HTML souboru.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slideNumber = $slideIndex + 1;
        $slideNumbers = array($slideNumber);
        $htmlFileName = "slide-" . $slideNumber . ".html";

        $presentation->save($htmlFileName, $slideNumbers, SaveFormat::Html);
    }
} finally {
    $presentation->dispose();
}
```

Použijte tento vzor, když webová stránka nebo aplikace potřebuje jednu HTML stránku na snímek. Pokud má mít každý snímek stejný rozvrh, vytvořte jednu instanci [HtmlOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/htmloptions/) a předávejte ji každému volání `save`.

## **Vytvoření responzivního HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/cs/php-java/aspose.slides/responsivehtmlcontroller/) poskytuje responzivní HTML výstup přes [HtmlFormatter](https://reference.aspose.com/slides/cs/php-java/aspose.slides/htmlformatter/). Použijte jej, když má exportovaná stránka lépe reagovat na šířku prohlížeče.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $controller = new ResponsiveHtmlController();
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Pro responzivní rozvrh založený na SVG nastavte `SvgResponsiveLayout` na [HtmlOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/htmloptions/). To je užitečné, když je obsah snímku exportován jako škálovatelný SVG kód.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSvgResponsiveLayout(true);

    $presentation->save("presentation-svg-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Zahrnutí poznámek přednášejícího a komentářů**

Použijte [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notescommentslayoutingoptions/) přes `HtmlOptions.SlidesLayoutOptions` pro zahrnutí poznámek přednášejícího nebo komentářů. Poznámky a komentáře jsou ve výchozím nastavení skryté, pokud si nevyberete jejich umístění.

Předpokládejme, že zdrojová prezentace obsahuje poznámky přednášejícího:

![Snímek s poznámkami přednášejícího v PowerPointu](slide_with_notes.png)

Následující kód exportuje obsah snímku s poznámkami pod snímkem.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $layoutOptions = new NotesCommentsLayoutingOptions();
    $layoutOptions->setNotesPosition(NotesPositions::BottomFull);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSlidesLayoutOptions($layoutOptions);

    $presentation->save("presentation-with-notes.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Výstupní HTML zahrnuje oblast poznámek:

![Výstup HTML se snímkem a poznámkami přednášejícího](HTML_with_notes.png)

Pro export komentářů nastavte `CommentsPosition`, například na `CommentsPositions.Right` nebo `CommentsPositions.Bottom`. Pokud potřebujete jen komentáře, vynechte `NotesPosition`. Pokud potřebujete jak poznámky, tak komentáře, nastavte obě vlastnosti.

## **Ovládání kvality obrázků a oříznutých oblastí**

Export HTML může komprimovat obrázky snímků, aby snížil velikost výstupu. Nastavte `PicturesCompression` na hodnotu z [PicturesCompression](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturescompression/), když potřebujete vyšší kvalitu obrázků.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setPicturesCompression(PicturesCompression::Dpi150);

    $presentation->save("presentation-dpi-150.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Ve výchozím nastavení mohou být oříznuté oblasti obrázků z výstupu odstraněny. Uchovávejte oříznutá data jen tehdy, když uživatelé musí být schopni je obnovit nebo prozkoumat. Zachování těchto dat může zvýšit velikost HTML.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setDeletePicturesCroppedAreas(false);

    $presentation->save("presentation-with-cropped-areas.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Přidání CSS**

Pro jednoduché stylování předejte řetězec CSS do [HtmlFormatter](https://reference.aspose.com/slides/cs/php-java/aspose.slides/htmlformatter/) pomocí `createDocumentFormatter`. Tím se změní obklopující HTML dokument, zatímco Aspose.Slides nadále vykresluje obsah snímku.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    $showSlideTitle = true;
    $formatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter($cssRules, $showSlideTitle);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-styled.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Pro vlastní záhlaví dokumentu, odkazovaný CSS soubor nebo vlastní značkování kolem snímků a tvarů použijte vlastní formátovací kontroler a předávejte jej do [HtmlFormatter](https://reference.aspose.com/slides/cs/php-java/aspose.slides/htmlformatter/) pomocí `createCustomFormatter`.

## **Vložení písem**

Pokud cílové prostředí nemusí mít písma prezentace nainstalována, vložte písma do HTML pomocí [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cs/php-java/aspose.slides/embedallfontshtmlcontroller/). Vložení zlepšuje vizuální věrnost, ale zvětšuje velikost výstupu.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $stringClass = new JavaClass("java.lang.String");

    $fontNamesToExclude = $arrayClass->newInstance($stringClass, 1);
    $arrayClass->set($fontNamesToExclude, 0, new Java("java.lang.String", "Calibri"));

    $fontController = new EmbedAllFontsHtmlController(java_values($fontNamesToExclude));
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($fontController);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-embedded-fonts.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Vylučujte písma jen tehdy, když jste si jisti, že cílové prohlížeče nebo systémy je již poskytují. Pro firemní nebo méně běžná písma je vložení obvykle bezpečnější.

## **Propojení souborů písem místo jejich vložení**

Aby se snížila velikost HTML souboru, můžete data písem zapsat do samostatných WOFF souborů a přidat pravidla `@font-face` do HTML. V PHP přes Java je tento scénář obvykle realizován malou pomocnou Java třídou, která rozšiřuje [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cs/php-java/aspose.slides/embedallfontshtmlcontroller/), zapisuje bajty písem do výstupního adresáře a vkládá pravidla `@font-face` do generovaného HTML. Zkompilujte tuto pomocnou třídu, přidejte ji do classpath PHP Java Bridge a pak ji z PHP vytvořte pomocí `new Java(...)`.

Při tvorbě takové pomoci zvolte dvě cesty úmyslně:

- Cesta výstupu v souborovém systému, kam se zapisují vygenerované soubory písem.
- Cesta URL, kterou prohlížeč používá z HTML dokumentu k načtení těchto souborů písem.

## **Ukládání zdrojů externě**

Samostatný HTML soubor se snadno přesouvá, ale vložené Base64 zdroje mohou soubor zvětšit. Pokud vaše aplikace potřebuje externí soubory obrázků, poskytněte vlastní kontroler pro odkazování/vkládání do konstruktoru [HtmlOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/htmloptions/).

Když externizujete zdroje, zvolte dvě cesty úmyslně:

- Cesta výstupu v souborovém systému, kam aplikace zapisuje vygenerované obrázky, písma, audio nebo video.
- Cesta URL, kterou prohlížeč používá z HTML dokumentu k načtení těchto souborů.

Uchovávejte tyto cesty konzistentní s rozvržením nasazení, aby vygenerované HTML mohlo načíst externí zdroje po přesunu na webový server nebo do jiného adresáře.

## **Export mediálních souborů**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoplayerhtmlcontroller/) exportuje video a audio soubory a zapisuje HTML, které je může přehrát v prohlížeči. Jeho konstruktor přijímá:

- `path`: výstupní adresář používaný vygenerovaným HTML a mediálními soubory.
- `fileName`: název generovaného HTML souboru.
- `baseUri`: absolutní URI prefix používaný v HTML odkazech na mediální soubory.

Pokud je HTML soubor `html-output/presentation.html`, `path` by měl ukazovat na `html-output` a `baseUri` by měl ukazovat na stejný adresář z pohledu prohlížeče. Pro lokální náhled můžete vytvořit `file:///` URI z výstupního adresáře. Pro nasazenou aplikaci použijte absolutní URL publikovaného výstupního adresáře.

```php
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "html-output";

if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$htmlFileName = "presentation.html";
$outputDirectoryPath = realpath($outputDirectory);
$outputDirectoryPath = str_replace("\\", "/", $outputDirectoryPath);
$outputBaseUri = "file:///" . ltrim($outputDirectoryPath, "/") . "/";

$presentation = new Presentation();
$videoStream = null;
try {
    $videoFilePath = getcwd() . DIRECTORY_SEPARATOR . "intro.mp4";
    $videoStream = new Java("java.io.FileInputStream", $videoFilePath);
    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addVideoFrame(20, 20, 480, 270, $video);

    $controller = new VideoPlayerHtmlController($outputDirectory, $htmlFileName, $outputBaseUri);
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);
    $svgOptions = new SVGOptions($controller);
    $slideImageFormat = SlideImageFormat::svg($svgOptions);

    $htmlOptions = new HtmlOptions($controller);
    $htmlOptions->setHtmlFormatter($formatter);
    $htmlOptions->setSlideImageFormat($slideImageFormat);

    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . $htmlFileName;
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }

    $presentation->dispose();
}
```

Používejte výstupní adresáře, které jsou jedinečné pro každou úlohu exportu, zejména v serverových aplikacích. Sdílené výstupní cesty mohou způsobit, že soubory z různých převodů přepíší navzájem.

## **Výkon a správa zdrojů**

Konverze HTML je renderovací operace, takže doba zpracování a spotřeba paměti závisí na počtu snímků, rozlišení obrázků, písmech, efektech, grafech a vložených médiích. Vyšší hodnoty `PicturesCompression` DPI, vložená písma, SVG výstup a zachování oříznutých oblastí obrázků mohou zlepšit věrnost, ale obvykle zvětší velikost výstupu.

Pro dávkovou konverzi:

- Okamžitě uvolněte každou instanci [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
- Používejte samostatné výstupní adresáře pro jednotlivé úlohy.
- Vyhněte se vkládání běžných písem, pokud to není nezbytné pro kvalitu.
- Snižte DPI obrázků, když je HTML určeno pro náhled nebo miniatury.
- Uchovávejte zdrojovou prezentaci, vygenerované HTML a externí zdroje pohromadě, dokud nebudou finální cesty nasazení.

## **Často kladené otázky**

**Zůstávají v HTML výstupu hypertextové odkazy?**

Ano. Hypertextové odkazy v prezentaci jsou exportovány do HTML a zůstávají klikatelné, pokud je cílová URL platná.

**Mohu převádět prezentace do HTML paralelně?**

Ano, ale nesdílejte jedinou instanci [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) napříč vlákny. Zpracovávejte různé soubory s oddělenými instancemi prezentace, oddělenými proudy a oddělenými výstupními adresáři.

**Je objekt Presentation vlákny bezpečný?**

Ne. Jedna instance [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) by měla být načtena, upravena, uložena a uvolněna v jednom vlákně. Pro paralelní práci vytvořte nezávislou instanci pro každé vlákno nebo proces.

**Proč je vygenerovaný HTML soubor velký?**

Výchozí export může vkládat zdroje přímo do HTML. Vložená písma, obrázky s vysokým DPI, média, SVG obsah a zachování oříznutých oblastí obrázků také zvětšují velikost. Použijte externí zdroje, vylučte běžná písma z vkládání a snižte `PicturesCompression`, pokud je menší výstup důležitější než maximální věrnost.

**Proč se velikost písma PowerPointu například 24 pt zobrazuje v HTML jako 17,999819 pt?**

K tomu může dojít, protože PowerPoint a HTML používají odlišné DPI modely. PowerPoint ukládá velikosti textu v typografických bodech na základě 72 DPI, zatímco rozvržení HTML je založeno na CSS pixelech v modelu 96 DPI. Když Aspose.Slides exportuje prezentaci do HTML, velikost písma se převádí mezi těmito systémy a konverze může zavést malé zaokrouhlovací rozdíly.

Tyto hodnoty neznamenají skutečnou vizuální změnu velikosti písma. Jedná se jen o matematický vedlejší efekt převodu textových metrik mezi PowerPointem a HTML.

**Jak bych měl zvolit baseUri pro export médií?**

Zvolte `baseUri` z pohledu prohlížeče a předávejte jej jako absolutní URI. Pro lokální náhled jej můžete odvodit z výstupního adresáře pomocí Java souborového URI. Pro nasazení použijte absolutní URL publikovaného mediálního adresáře. Souborový `path` a prohlížečový `baseUri` nemusí být stejný řetězec, ale musí popisovat stejnou polohu zdroje.

**Mohu zahrnout skryté snímky?**

Ano. Nastavte `ShowHiddenSlides` na `true` v [HtmlOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/htmloptions/), když musí být skryté snímky exportovány.