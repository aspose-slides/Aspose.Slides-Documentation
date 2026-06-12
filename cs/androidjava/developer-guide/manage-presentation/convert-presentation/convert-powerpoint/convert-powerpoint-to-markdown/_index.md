---
title: Převod prezentací PowerPoint do formátu Markdown na Androidu
linktitle: PowerPoint do Markdown
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
- PowerPoint
- prezentace
- Markdown
- Android
- Java
- Aspose.Slides
description: "Převod snímků PowerPoint - PPT, PPTX - do čistého Markdownu pomocí Aspose.Slides pro Android v Javě, automatizujte dokumentaci a zachovejte formátování."
---
## **Introduction**

Aspose.Slides vám umožňuje převádět prezentace PowerPoint do formátu Markdown, což může být užitečné pro pracovní postupy dokumentace, generování statických webů, migraci obsahu a publikaci textu pod verzovacím řízením. API podporuje přímý export z prezentací PPT a PPTX do souborů MD a poskytuje další možnosti, jak ovládat, jak bude obsah snímků vygenerován v výsledném dokumentu Markdown.

Můžete exportovat prezentace jako prostý Markdown, vybírat z několika variant Markdownu, jako jsou CommonMark a GitHub Flavored Markdown, a nastavit, jak budou během exportu zpracovány obrázky. Pro prezentace, které obsahují vizuální obsah, vám Aspose.Slides také umožní uložit obrázky do samostatné složky a odkazovat na ně z vygenerovaného souboru Markdown.

Aspose.Slides podporuje konverzi prezentací do formátu Markdown.

{{% alert color="warning" %}} 
Export PowerPoint do markdown je ve výchozím nastavení **bez obrázků**. Pokud chcete exportovat dokument PowerPoint obsahující obrázky, musíte nastavit `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` a také nastavit `BasePath`, kam budou uloženy obrázky odkazované v markdown dokumentu.
{{% /alert %}} 

## **Convert PowerPoint to Markdown**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) k reprezentaci objektu prezentace.
2. Použijte metodu [Uložit](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) k uložení objektu jako souboru markdown.

Tento Java kód ukazuje, jak převést PowerPoint do markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Převést PowerPoint do formátu Markdown**

Aspose.Slides vám umožňuje převést PowerPoint do markdown (obsahující základní syntaxi), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab a dalších 17 variant markdownu.

Tento Java kód ukazuje, jak převést PowerPoint do CommonMark:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

23 podporovaných variant markdownu je [uvedeno v enumeraci Flavor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/flavor/) třídy [MarkdownSaveOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/markdownsaveoptions/).

## **Převést prezentaci obsahující obrázky do Markdown**

Třída [MarkdownSaveOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/markdownsaveoptions/) poskytuje vlastnosti a výčty, které vám umožní použít určité možnosti nebo nastavení pro výsledný markdown soubor. Výčet [MarkdownExportType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/markdownexporttype/) lze například nastavit na hodnoty určující, jak jsou obrázky vykreslovány nebo zpracovávány: `Sequential`, `TextOnly`, `Visual`.

### **Převést obrázky sekvenčně**

Pokud chcete, aby se obrázky vygenerovaly zvlášť jeden po druhém ve výsledném markdownu, musíte zvolit sekvenční možnost. Tento Java kód ukazuje, jak převést prezentaci obsahující obrázky do markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Převést obrázky vizuálně**

Pokud chcete, aby se obrázky objevily společně ve výsledném markdownu, musíte zvolit vizuální možnost. V tomto případě budou obrázky uloženy do aktuálního adresáře aplikace (a v markdown dokumentu bude vytvořena relativní cesta k nim) nebo můžete zadat preferovanou cestu a název složky.

Tento Java kód demonstruje operaci:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Zůstávají hypertextové odkazy po exportu do Markdown?**

Ano. Textové [hyperlinky](/slides/cs/androidjava/manage-hyperlinks/) jsou zachovány jako standardní odkazy Markdown. [Přechody](/slides/cs/androidjava/slide-transition/) a [animace](/slides/cs/androidjava/powerpoint-animation/) snímků nejsou konvertovány.

**Mohu urychlit konverzi spuštěním ve více vláknech?**

Můžete paralelizovat podle souborů, ale [nesdílejte](/slides/cs/androidjava/multithreading/) stejný [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) objekt napříč vlákny. Používejte samostatné instance/procesy pro každý soubor, aby nedocházelo ke konfliktům.

**Co se stane s obrázky – kde jsou uloženy a jsou cesty relativní?**

[Obrázky](/slides/cs/androidjava/image/) jsou exportovány do vyhrazené složky a Markdown soubor na ně odkazuje relativními cestami ve výchozím nastavení. Můžete nastavit základní výstupní cestu a název složky pro prostředky, aby byla struktura repozitáře předvídatelná.