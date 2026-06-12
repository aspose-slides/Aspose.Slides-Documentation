---
title: Převod prezentací PowerPoint do Markdown v JavaScriptu
linktitle: PowerPoint do Markdown
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
- exportPPTX do MD
- PowerPoint
- prezentace
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "Převést snímky PowerPoint v JavaScriptu—PPT, PPTX—na čistý Markdown pomocí Aspose.Slides pro Node.js přes Java, automatizovat dokumentaci a zachovat formátování."
---
## **Úvod**

Aspose.Slides vám umožňuje převádět prezentace PowerPoint do formátu Markdown, což může být užitečné pro dokumentační workflow, generování statických stránek, migraci obsahu a publikování textu pod verzovacím řízením. API podporuje přímý export z prezentací PPT a PPTX do souborů MD a poskytuje další možnosti, jak řídit, jak je obsah snímků představován ve výsledném dokumentu Markdown.

Můžete exportovat prezentace jako čistý Markdown, vybrat si z několika variant Markdownu, jako jsou CommonMark a GitHub Flavored Markdown, a nastavit, jak se během exportu zachází s obrázky. Pro prezentace, které obsahují vizuální obsah, vám Aspose.Slides také umožňuje uložit obrázky do samostatné složky a odkazovat na ně z vygenerovaného souboru Markdown.

{{% alert color="warning" %}} 
Export PowerPoint do markdown je ve výchozím nastavení **without images**. Pokud chcete exportovat dokument PowerPoint obsahující obrázky, musíte zavolat `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` a také nastavit `BasePath`, kam budou uloženy obrázky odkazované v markdown dokumentu.
{{% /alert %}} 

## **Převod PowerPoint do Markdownu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) představující objekt prezentace.
2. Použijte metodu [save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) k uložení objektu jako souboru markdown.

Tento JavaScriptový kód ukazuje, jak převést PowerPoint do markdownu:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Převod PowerPoint do variant Markdownu**

Aspose.Slides vám umožňuje převádět PowerPoint do markdownu (obsahujícího základní syntaxi), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab a dalších 17 variant markdownu.

Tento JavaScriptový kód ukazuje, jak převést PowerPoint do CommonMark:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

23 podporovaných variant markdownu je [uvedeno v enumeraci Flavor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/flavor/) třídy [MarkdownSaveOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/markdownsaveoptions/).

## **Převod prezentace obsahující obrázky do Markdownu**

Třída [MarkdownSaveOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/markdownsaveoptions/) poskytuje vlastnosti a enumerace, které umožňují nastavit určité možnosti nebo nastavení pro výsledný soubor markdown. Enum [MarkdownExportType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/markdownexporttype/) lze například nastavit na hodnoty určující, jak jsou obrázky vykreslovány nebo zpracovávány: `Sequential`, `TextOnly`, `Visual`.

### **Sekvenční převod obrázků**

Pokud chcete, aby se obrázky ve výsledném markdownu objevily jednotlivě, jeden za druhým, musíte zvolit sekvenční možnost. Tento JavaScriptový kód ukazuje, jak převést prezentaci obsahující obrázky do markdownu:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Vizuální převod obrázků**

Pokud chcete, aby se obrázky ve výsledném markdownu objevily společně, musíte zvolit vizuální možnost. V tomto případě budou obrázky uloženy do aktuálního adresáře aplikace (a v markdown dokumentu bude vytvořena relativní cesta k nim), nebo můžete zadat vlastní cestu a název složky.

Tento JavaScriptový kód demonstruje operaci:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Přežijí hypertextové odkazy při exportu do Markdownu?**

Ano. Textové [hyperlinks](/slides/cs/nodejs-java/manage-hyperlinks/) jsou zachovány jako standardní odkazy Markdown. Přechody snímků [transitions](/slides/cs/nodejs-java/slide-transition/) a [animations](/slides/cs/nodejs-java/powerpoint-animation/) nejsou převedeny.

**Mohu zrychlit konverzi spuštěním v několika vláknech?**

Můžete paralelizovat napříč soubory, ale [nedílejte](/slides/cs/nodejs-java/multithreading/) stejnou instanci [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) mezi vlákny. Používejte samostatné instance/procesy pro každý soubor, abyste se vyhnuli soutěži.

**Co se stane s obrázky—kde jsou uloženy a jsou cesty relativní?**

[Images](/slides/cs/nodejs-java/image/) jsou exportovány do vyhrazené složky a soubor Markdown je ve výchozím nastavení odkazuje pomocí relativních cest. Můžete nastavit základní výstupní cestu a název složky pro prostředky, aby struktura repozitáře byla předvídatelná.