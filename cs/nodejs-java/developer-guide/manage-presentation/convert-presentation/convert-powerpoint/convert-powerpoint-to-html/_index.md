---
title: Převod prezentací PowerPoint do HTML v Node.js
linktitle: PowerPoint do HTML
type: docs
weight: 30
url: /cs/nodejs-java/convert-powerpoint-to-html/
keywords:
- převod PowerPoint
- převod prezentace
- převod snímku
- převod PPT
- převod PPTX
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
- export PPT do HTML
- export PPTX do HTML
- Node.js
- JavaScript
- Aspose.Slides
description: "Převádějte prezentace PowerPoint do HTML v Node.js. Použijte Aspose.Slides pro Node.js přes Java k exportu souborů PPT a PPTX, vybraných snímků, poznámek, písem, obrázků, SVG a médií."
---
## **Přehled**

Aspose.Slides pro Node.js přes Java může ukládat prezentace PowerPoint jako HTML bez Microsoft PowerPoint. Základní konverze spočívá v načtení jedné [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) a volání `save` s [SaveFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveformat/). Použijte [HtmlOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/htmloptions/), pokud potřebujete řídit exportované rozvržení, písma, obrázky, poznámky, komentáře, výstup SVG nebo propojené zdroje.

Tento návod se zaměřuje na praktické scénáře exportu HTML:

- Exportovat celou prezentaci nebo vybrané snímky.  
- Vytvořit HTML s pevné rozložení, responzivní nebo na SVG založené.  
- Zahrnout poznámky přednášejícího a komentáře.  
- Řídit kvalitu obrázků a data o oříznutých obrázcích.  
- Vkládat písma nebo ukládat soubory písem samostatně.  
- Zvolit, jak jsou externí zdroje a mediální soubory zapisovány a odkazovány.

Ve výchozím nastavení export HTML vytváří samostatný HTML dokument, kde jsou většina zdrojů vloženy. To je pohodlné pro sdílení jednoho souboru, ale může to zvýšit velikost výstupu. Pro publikování na webu zvažte externí zdroje, nižší DPI obrázků a vkládání jen těch písem, která nejsou spolehlivě dostupná v cílovém prostředí.

## **Převést prezentaci do HTML**

Pro export prezentace do HTML ji načtěte pomocí [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) a uložte s [SaveFormat.Html](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveformat/).

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Tento příklad zapíše jeden HTML soubor. Objekt prezentace je uvolněn v bloku `finally`, což po exportu uvolní souborové handly a zdroje renderování.

## **Použít HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/htmloptions/) je hlavní konfigurační třída pro export HTML. Běžná nastavení zahrnují:

- `SlidesLayoutOptions`: přidává poznámky, komentáře, podklady nebo jiné informace o rozvržení.  
- `HtmlFormatter`: mění strukturu HTML dokumentu nebo deleguje formátování na kontroler.  
- `SlideImageFormat`: mění způsob, jakým jsou snímky reprezentovány, například jako SVG.  
- `PicturesCompression`: řídí DPI obrázků a velikost výstupu.  
- `DeletePicturesCroppedAreas`: zachovává nebo odstraňuje data o oříznutých obrázcích.  
- `SvgResponsiveLayout`: umožňuje exportovanému SVG obsahu přizpůsobit se kontejneru.  
- `ShowHiddenSlides`: zahrnuje skryté snímky, pokud je to potřeba.

Níže jsou ukázány nejčastější možnosti odděleně, abyste je mohli kombinovat jen podle potřeb vašeho postupu.

## **Převést vybrané snímky do HTML**

Přetížení `Presentation.save`, které přijímá čísla snímků, používá 1‑založené pozice snímků. Smyčka níže uloží každý snímek do samostatného HTML souboru.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Použijte tento vzor, pokud webová stránka nebo aplikace potřebuje jednu HTML stránku na snímek. Pokud mají všechny snímky mít stejné rozvržení, vytvořte jednu instanci [HtmlOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/htmloptions/) a předávejte ji každému volání `save`.

## **Vytvořit responzivní HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/responsivehtmlcontroller/) poskytuje responzivní HTML výstup prostřednictvím [HtmlFormatter](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/htmlformatter/). Použijte jej, když má exportovaná stránka lépe reagovat na šířku prohlížeče.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Pro responzivní rozvržení založené na SVG nastavte `SvgResponsiveLayout` na [HtmlOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/htmloptions/). To je užitečné, když je obsah snímku exportován jako škálovatelný SVG markup.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Zahrnout poznámky přednášejícího a komentáře**

Použijte [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notescommentslayoutingoptions/) skrze `HtmlOptions.setSlidesLayoutOptions` pro zahrnutí poznámek přednášejícího nebo komentářů. Poznámky a komentáře jsou ve výchozím nastavení skryté, pokud nevyberete jejich pozice.

Předpokládejme, že zdrojová prezentace obsahuje poznámky přednášejícího:

![Snímek s poznámkami přednášejícího v PowerPointu](slide_with_notes.png)

Následující kód exportuje obsah snímku s poznámkami pod snímkem.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Exportované HTML zahrnuje oblast s poznámkami:

![Výstup HTML se snímkem a poznámkami přednášejícího](HTML_with_notes.png)

Pro export komentářů nastavte `CommentsPosition`, například na `CommentsPositions.Right` nebo `CommentsPositions.Bottom`. Pokud potřebujete jen komentáře, vynechejte `NotesPosition`. Pokud potřebujete jak poznámky, tak komentáře, nastavte obě vlastnosti.

## **Řídit kvalitu obrázků a oříznuté oblasti**

Export HTML může komprimovat obrázky snímků pro snížení velikosti výstupu. Nastavte `PicturesCompression` na hodnotu z [PicturesCompression](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturescompression/), když potřebujete vyšší kvalitu obrázků.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Ve výchozím nastavení mohou být oříznuté oblasti obrázků odebrány z exportovaného výstupu. Uchovávejte oříznutá data jen tehdy, když uživatelé musí mít možnost je obnovit nebo prohlédnout. Uchování může zvýšit velikost HTML.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Přidat CSS**

Pro jednoduché stylování předávejte řetězec CSS do `HtmlFormatter.createDocumentFormatter`. To mění okolní HTML dokument, zatímco Aspose.Slides nadále vykresluje obsah snímků.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Pro vlastní záhlaví dokumentu, propojený CSS soubor nebo vlastní markup kolem snímků a tvarů použijte [HtmlFormatter](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/htmlformatter/) s formátovacím kontrolerem.

## **Vkládat písma**

Pokud cílové prostředí nemusí mít písma prezentace nainstalována, vložte písma do HTML pomocí [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/embedallfontshtmlcontroller/). Vkládání zvyšuje vizuální věrnost, ale také velikost výstupu.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Vylučujte písma jen tehdy, když jste si jisti, že cílové prohlížeče nebo systémy je již poskytují. Pro firemní nebo méně běžná písma je vkládání obvykle bezpečnější.

## **Odkázat soubory písem místo jejich vkládání**

Pro snížení velikosti HTML souboru můžete data písem zapisovat do samostatných souborů WOFF a přidat pravidla `@font-face` do HTML. V Node.js přes Java je tento scénář obvykle realizován malou pomocnou Java třídou, která rozšiřuje [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/embedallfontshtmlcontroller/), zapisuje bajty písem do výstupního adresáře a vkládá pravidla `@font-face` do vygenerovaného HTML. Zkompilujte tuto pomocnou třídu, přidejte ji do classpath Node.js modulu a potom ji vytvořte z JavaScriptu pomocí `java.newInstanceSync`.

Při tvorbě takové pomoci zvolte dva cesty úmyslně:

- Cesta výstupu v souborovém systému, kam jsou zapisovány vygenerované soubory písem.  
- Cesta URL, kterou prohlížeč používá z HTML dokumentu k načtení těchto souborů písem.

## **Uložit zdroje externě**

Samostatné HTML je snadno přenositelné, ale vložené Base64 zdroje mohou soubor zvětšit. Pokud vaše aplikace potřebuje externí soubory obrázků, písem, audia nebo videa, použijte exportní kontroler, který zapisuje zdroje do zvoleného adresáře a vytváří prohlížečem viditelné URL. Udržujte cestu souborového systému a URL synchronizované s vaším nasazovacím uspořádáním.

## **Exportovat mediální soubory**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) exportuje video a audio soubory a zapisuje HTML, které je může přehrát v prohlížeči. Jeho konstruktor přijímá:

- `path`: adresář, kam budou zapisovány vygenerované mediální soubory.  
- `fileName`: název generovaného HTML souboru.  
- `baseUri`: absolutní URI předpona používaná v HTML odkazech na mediální soubory.

Pokud je HTML soubor `html-output/presentation.html` a mediální soubory jsou uloženy v `html-output/media`, `path` by měl ukazovat na mediální adresář na disku, zatímco `baseUri` by měl ukazovat na stejný adresář z pohledu prohlížeče. Pro lokální náhled můžete vytvořit `file:///` URI z mediálního adresáře. Pro nasazenou aplikaci použijte absolutní URL publikovaného mediálního adresáře.

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Používejte výstupní adresáře, které jsou jedinečné pro každou úlohu exportu, zejména na serverových aplikacích. Sdílené výstupní cesty mohou způsobit, že soubory z různých konverzí se přepíší.

## **Výkon a správa zdrojů**

Konverze do HTML je renderovací operace, takže doba zpracování a využití paměti závisí na počtu snímků, rozlišení obrázků, písmech, efektech, grafech a vložených médiích. Vyšší hodnoty DPI v `PicturesCompression`, vložená písma, SVG výstup a zachování oříznutých oblastí obrázků mohou zlepšit věrnost, ale obvykle zvětší velikost výstupu.

Pro dávkovou konverzi:

- Okamžitě uvolňujte každou instanci [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).  
- Používejte samostatné výstupní adresáře pro jednotlivé úlohy.  
- Vyhněte se vkládání běžných písem, pokud to není nutné pro věrnost.  
- Snižte DPI obrázků, pokud je HTML určeno pro náhled nebo miniatury.  
- Uchovávejte zdrojovou prezentaci, vygenerované HTML a externí zdroje společně, dokud nejsou finální nasazovací cesty.

## **Často kladené otázky**

**Zůstávají hypertextové odkazy v HTML výstupu zachovány?**

Ano. Hypertextové odkazy v prezentaci jsou exportovány do HTML a zůstávají klikatelné, pokud je cílová URL platná.

**Mohu konvertovat prezentace do HTML paralelně?**

Ano, ale nesdílejte jednu instanci [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) mezi pracovníky. Zpracovávejte různé soubory s oddělenými instancemi prezentace, oddělenými proudy a oddělenými výstupními adresáři. Viz [multithreading guidance](/slides/cs/nodejs-java/multithreading/) pro podrobnosti.

**Je objekt Presentation vláknově bezpečný?**

Ne. Jedna instance [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) by měla být načtena, změněna, uložena a uvolněna v jednom vlákně. Pro paralelní práci vytvořte nezávislou instanci pro každý vláknový nebo procesní úkol.

**Proč je vygenerovaný HTML soubor velký?**

Výchozí export může vkládat zdroje přímo do HTML. Vložená písma, obrázky s vysokým DPI, média, SVG obsah a zachování oříznutých oblastí obrázků také velikost zvyšují. Používejte externí zdroje, vylučujte běžná písma z vkládání a snižujte `PicturesCompression`, když je menší výstup důležitější než maximální věrnost.

**Proč se velikost písma v PowerPointu 24 pt objeví v HTML jako 17.999819 pt?**

K tomu může dojít, protože PowerPoint a HTML používají odlišné DPI modely. PowerPoint ukládá velikosti textu v typografických bodech založených na 72 DPI, zatímco rozvržení HTML vychází z CSS pixelů v modelu 96 DPI. Při exportu prezentace do HTML Aspose.Slides převádí velikost písma mezi těmito systémy a konverze může zavést malé zaokrouhlovací rozdíly.

Tyto hodnoty neznamenají skutečnou vizuální změnu velikosti písma. Jsou to jen matematické vedlejší efekty převodu metrik textu mezi PowerPoint a HTML.

**Jak si mám zvolit baseUri pro export médií?**

Zvolte `baseUri` z pohledu prohlížeče a předávejte jej jako absolutní URI. Pro lokální náhled můžete odvodit `baseUri` z výstupního adresáře pomocí `file:///` URI. Pro nasazení použijte absolutní URL publikovaného mediálního adresáře. Souborová cesta `path` a prohlížečová `baseUri` nemusí být stejný řetězec, ale musí popisovat stejnou lokaci zdroje.

**Mohu zahrnout skryté snímky?**

Ano. Nastavte `ShowHiddenSlides` na `true` na [HtmlOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/htmloptions/), když musí být skryté snímky exportovány.