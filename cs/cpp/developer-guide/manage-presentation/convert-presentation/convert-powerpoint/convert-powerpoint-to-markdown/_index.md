---
title: Převod prezentací PowerPoint do Markdownu v C++
linktitle: PowerPoint do Markdownu
type: docs
weight: 140
url: /cs/cpp/convert-powerpoint-to-markdown/
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
- C++
- Aspose.Slides
description: "Převod snímků PowerPoint — PPT, PPTX—do čistého Markdownu pomocí Aspose.Slides pro C++, automatizujte dokumentaci a zachovejte formátování."
---
## **Úvod**

Aspose.Slides umožňuje převádět prezentace PowerPoint do formátu Markdown, což může být užitečné pro pracovní postupy dokumentace, generování statických webů, migraci obsahu a publikování textu pod kontrolou verzí. API podporuje přímý export z prezentací PPT a PPTX do souborů MD a poskytuje další možnosti, jak kontrolovat, jak je obsah snímků reprezentován ve výsledném dokumentu Markdown.

Můžete exportovat prezentace jako čistý Markdown, vybírat z několika variant Markdownu, jako jsou CommonMark a GitHub Flavored Markdown, a nastavit, jak jsou během exportu zpracovávány obrázky. Pro prezentace, které obsahují vizuální obsah, Aspose.Slides také umožňuje uložit obrázky do samostatné složky a odkazovat na ně v generovaném souboru Markdown.

{{% alert color="warning" %}} 
Export PowerPoint do markdownu je ve výchozím nastavení **bez obrázků**. Pokud chcete exportovat dokument PowerPoint obsahující obrázky, musíte nastavit `SaveOptions::MarkdownExportType::Visual)` a také nastavit `BasePath`, kam budou uloženy obrázky odkazované v markdown dokumentu.
{{% /alert %}} 

## **Převod PowerPointu do Markdownu**

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/), která představuje objekt prezentace.
2. Použijte [Uložit](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) metodu k uložení objektu do souboru markdown.

Tento C++ kód ukazuje, jak převést PowerPoint do markdownu:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## **Převod PowerPointu do varianty Markdown**

Aspose.Slides umožňuje převádět PowerPoint do markdownu (obsahujícího základní syntaxi), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab a dalších 17 variant markdownu.

Tento C++ kód ukazuje, jak převést PowerPoint do CommonMark: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

23 podporovaných variant markdownu je [uvedeno v enumeraci Flavor](https://reference.aspose.com/slides/cs/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) třídy [MarkdownSaveOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Převod prezentace obsahující obrázky do Markdownu**

Třída [MarkdownSaveOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) poskytuje vlastnosti a výčty, které umožňují použít určité možnosti nebo nastavení pro výsledný soubor markdown. Výčet [MarkdownExportType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) lze například nastavit na hodnoty určující, jak jsou obrázky vykresleny nebo zpracovány: `Sequential`, `TextOnly`, `Visual`.

### **Převod obrázků sekvenčně**

Pokud chcete, aby se obrázky v výsledném markdownu objevily jednotlivě jeden po druhém, musíte vybrat sekvenční možnost. Tento C++ kód ukazuje, jak převést prezentaci obsahující obrázky do markdownu:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<MarkdownSaveOptions> markdownSaveOptions = System::MakeObject<MarkdownSaveOptions>();

markdownSaveOptions->set_ShowHiddenSlides(true);
markdownSaveOptions->set_ShowSlideNumber(true);
markdownSaveOptions->set_Flavor(Flavor::Github);
markdownSaveOptions->set_ExportType(MarkdownExportType::Sequential);
markdownSaveOptions->set_NewLineType(NewLineType::Windows);

pres->Save(u"doc.md", System::MakeArray<int32_t>({1, 2, 3, 4, 5, 6, 7, 8, 9}), SaveFormat::Md, markdownSaveOptions);
```

### **Převod obrázků vizuálně**

Pokud chcete, aby se obrázky v výsledném markdownu objevily společně, musíte vybrat vizuální možnost. V tomto případě budou obrázky uloženy do aktuálního adresáře aplikace (a v markdown dokumentu bude vytvořena relativní cesta k nim), nebo můžete zadat vlastní cestu a název složky.

Tento C++ kód demonstruje operaci: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```

## **Často kladené otázky**

**Zachovají se hypertextové odkazy při exportu do Markdownu?**

Ano. Textové [hyperlinky](/slides/cs/cpp/manage-hyperlinks/) jsou zachovány jako standardní odkazy Markdown. [Přechody](/slides/cs/cpp/slide-transition/) a [animace](/slides/cs/cpp/powerpoint-animation/) snímků nejsou převedeny.

**Mohu urychlit převod spuštěním v několika vláknech?**

Můžete paralelizovat zpracování napříč soubory, ale [nesdílejte](/slides/cs/cpp/multithreading/) stejnou instanci [Prezentace](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) mezi vlákny. Použijte samostatné instance/procesy pro každý soubor, abyste předešli konfliktům.

**Co se stane s obrázky – kde jsou uloženy a jsou cesty relativní?**

[Obrázky](/slides/cs/cpp/image/) jsou exportovány do samostatné složky a soubor Markdown na ně odkazuje relativními cestami ve výchozím nastavení. Můžete nastavit základní výstupní cestu a název složky pro prostředky, aby struktura repozitáře byla předvídatelná.