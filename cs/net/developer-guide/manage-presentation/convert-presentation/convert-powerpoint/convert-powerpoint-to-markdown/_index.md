---
title: Převod prezentací PowerPoint do Markdown v .NET
linktitle: PowerPoint do Markdown
type: docs
weight: 140
url: /cs/net/convert-powerpoint-to-markdown/
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
- .NET
- C#
- Aspose.Slides
description: "Převést snímky PowerPoint — PPT, PPTX — na čistý Markdown pomocí Aspose.Slides pro .NET, automatizovat dokumentaci a zachovat formátování."
---
## **Úvod**

Aspose.Slides vám umožňuje převádět prezentace PowerPoint do Markdown, což může být užitečné pro dokumentační workflow, generování statických webů, migraci obsahu a publikování textu pod verzovacím řízením. API podporuje přímý export z prezentací PPT a PPTX do souborů MD a poskytuje další možnosti, jak ovládat způsob, jakým je obsah snímků reprezentován ve výsledném Markdown dokumentu.

Můžete exportovat prezentace jako čistý Markdown, vybrat z několika variant Markdownu, jako jsou CommonMark a GitHub Flavored Markdown, a nakonfigurovat, jak jsou během exportu zpracovávány obrázky. Pro prezentace, které obsahují vizuální obsah, Aspose.Slides vám také umožní uložit obrázky do samostatné složky a odkazovat na ně v generovaném Markdown souboru.

{{% alert color="warning" %}}
Export z PowerPoint do Markdown je ve výchozím nastavení **bez obrázků**. Pokud chcete exportovat dokument PowerPoint obsahující obrázky, musíte nastavit `ExportType = MarkdownExportType.Visual` a zadat `BasePath`, kam budou obrázky odkazované v Markdown dokumentu uloženy.
{{% /alert %}}

## **Převod PowerPointu do Markdown**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation), která bude představovat objekt prezentace.
2. Použijte metodu [Save ](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/methods/save) k uložení objektu jako markdown souboru.

Tento C# kód ukazuje, jak převést PowerPoint do markdown:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## **Převod PowerPointu do varianty Markdown**

Aspose.Slides vám umožňuje převádět PowerPoint do markdown (s základní syntaxí), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab a dalších 17 variant markdownu.

Tento C# kód ukazuje, jak převést PowerPoint do CommonMark:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

23 podporovaných variant markdownu je [uvedeno v enumeraci Flavor](https://reference.aspose.com/slides/cs/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) třídy [MarkdownSaveOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Převod prezentace s obrázky do Markdown**

Třída [MarkdownSaveOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) poskytuje vlastnosti a enumerace, které umožňují použít určité možnosti nebo nastavení pro výsledný markdown soubor. Enumerace [MarkdownExportType](https://reference.aspose.com/slides/cs/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) může být například nastavena na hodnoty, které určují, jak jsou obrázky vykresleny nebo zpracovány: `Sequential`, `TextOnly`, `Visual`.

### **Sekvenční převod obrázků**

Pokud chcete, aby se obrázky ve výsledném markdownu objevily jednotlivě za sebou, musíte zvolit sekvenční možnost. Tento C# kód ukazuje, jak převést prezentaci s obrázky do markdown:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions
    {
        ShowHiddenSlides = true,
        ShowSlideNumber = true,
        Flavor = Flavor.Github,
        ExportType = MarkdownExportType.Sequential,
        NewLineType = NewLineType.Windows
    };
    
    pres.Save("doc.md", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
}
```

### **Vizuální převod obrázků**

Pokud chcete, aby se obrázky ve výsledném markdownu objevily společně, musíte zvolit vizuální možnost. V tomto případě budou obrázky uloženy do aktuálního adresáře aplikace (a v markdown dokumentu bude vytvořena relativní cesta), nebo můžete zadat vlastní cestu a název složky.

Tento C# kód demonstruje operaci:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    const string outPath = "c:\\documents";
    pres.Save(Path.Combine(outPath, "pres.md"), SaveFormat.Md, new MarkdownSaveOptions
    { 
        ExportType = MarkdownExportType.Visual,
        ImagesSaveFolderName = "md-images",
        BasePath = outPath
    });
}
```

## **Často kladené otázky**

**Zůstávají hypertextové odkazy zachovány po exportu do Markdownu?**

Ano. Textové [hyperlinky](/slides/cs/net/manage-hyperlinks/) jsou zachovány jako standardní Markdown odkazy. Přechody [slide](/slides/cs/net/slide-transition/) a [animace](/slides/cs/net/powerpoint-animation/) nejsou převedeny.

**Mohu urychlit konverzi spuštěním v několika vláknech?**

Můžete paralelizovat napříč soubory, ale [nedílejte](/slides/cs/net/multithreading/) stejnou [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) instanci mezi vlákny. Používejte samostatné instance/procesy pro každý soubor, abyste předešli konfliktům.

**Co se stane s obrázky—kde jsou uloženy a jsou cesty relativní?**

[Obrázky](/slides/cs/net/image/) jsou exportovány do dedikovaného složky a Markdown soubor je odkazuje relativními cestami ve výchozím nastavení. Můžete nastavit základní výstupní cestu a název složky s prostředky pro udržení předvídatelné struktury repozitáře.