---
title: Převést prezentace PowerPoint do Markdown v Java
linktitle: PowerPoint na Markdown
type: docs
weight: 140
url: /cs/java/convert-powerpoint-to-markdown/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint na MD
- prezentaci na MD
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
- PowerPoint
- prezentace
- Markdown
- Java
- Aspose.Slides
description: "Převést snímky PowerPoint — PPT, PPTX — do čistého Markdownu pomocí Aspose.Slides pro Java, automatizovat dokumentaci a zachovat formátování."
---
## **Úvod**

Aspose.Slides vám umožňuje převádět prezentace PowerPoint do formátu Markdown, což může být užitečné pro workflow dokumentace, generování statických stránek, migraci obsahu a publikování textu řízeného verzí. API podporuje přímý export z prezentací PPT a PPTX do souborů MD a poskytuje další možnosti, jak ovlivnit, jak bude obsah snímků reprezentován ve výsledném Markdown dokumentu.

Můžete exportovat prezentace jako prostý Markdown, vybrat si z několika variant Markdownu, jako jsou CommonMark a GitHub Flavored Markdown, a nastavit, jak budou obrázky během exportu zpracovány. U prezentací, které obsahují vizuální obsah, vám Aspose.Slides také umožní uložit obrázky do samostatné složky a odkazovat na ně v generovaném Markdown souboru.

{{% alert color="warning" %}}
Export PowerPoint do markdownu je ve výchozím nastavení **bez obrázků**. Pokud chcete exportovat dokument PowerPoint obsahující obrázky, musíte použít `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` a také použít `setBasePath`, kam budou uloženy obrázky odkazované v markdown dokumentu.
{{% /alert %}}

## **Převést PowerPoint do Markdownu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/), která představuje objekt prezentace.
2. Použijte metodu [Save ](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) k uložení objektu jako markdown soubor.

Tento Java kód vám ukazuje, jak převést PowerPoint do markdownu:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Převést PowerPoint do varianty Markdownu**

Aspose.Slides umožňuje převést PowerPoint do markdownu (obsahujícího základní syntaxi), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab a dalších 17 variant markdownu.

Tento Java kód vám ukazuje, jak převést PowerPoint do CommonMark:

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

23 podporovaných variant markdownu je [uvedeno v enumeraci Flavor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/flavor/) ze třídy [MarkdownSaveOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/markdownsaveoptions/).

## **Převést prezentaci obsahující obrázky do Markdownu**

Třída [MarkdownSaveOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/markdownsaveoptions/) poskytuje vlastnosti a výčty, které umožňují použít určitá nastavení pro výsledný markdown soubor. Výčet [MarkdownExportType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/markdownexporttype/) lze například nastavit na hodnoty určující, jak budou obrázky vykresleny nebo zpracovány: `Sequential`, `TextOnly`, `Visual`.

### **Převést obrázky sekvenčně**

Pokud chcete, aby se obrázky ve výsledném markdownu objevily jednotlivě jeden po druhém, musíte zvolit sekvenční možnost. Tento Java kód vám ukazuje, jak převést prezentaci obsahující obrázky do markdownu:

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

Pokud chcete, aby se obrázky ve výsledném markdownu objevily společně, musíte zvolit vizuální možnost. V tomto případě budou obrázky uloženy do aktuálního adresáře aplikace (a v markdown dokumentu bude pro ně vytvořena relativní cesta) nebo můžete zadat svůj vlastní cestu a název složky.

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

**Přežijí hypertextové odkazy export do Markdownu?**

Ano. Textové [hyperlinks](/slides/cs/java/manage-hyperlinks/) jsou zachovány jako standardní Markdown odkazy. [Přechody](/slides/cs/java/slide-transition/) a [animace](/slides/cs/java/powerpoint-animation/) snímků nejsou převedeny.

**Mohu zrychlit konverzi spuštěním v několika vláknech?**

Můžete paralelizovat napříč soubory, ale [nesdílejte](/slides/cs/java/multithreading/) stejnou instanci [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) mezi vlákny. Používejte samostatné instance/procesy pro každý soubor, abyste se vyhnuli konfliktům.

**Co se stane s obrázky – kde jsou uloženy a jsou cesty relativní?**

[Obrázky](/slides/cs/java/image/) jsou exportovány do samostatné složky a Markdown soubor je odkazuje pomocí relativních cest ve výchozím nastavení. Můžete nastavit základní výstupní cestu a název složky s prostředky, aby struktura repozitáře zůstala předvídatelná.