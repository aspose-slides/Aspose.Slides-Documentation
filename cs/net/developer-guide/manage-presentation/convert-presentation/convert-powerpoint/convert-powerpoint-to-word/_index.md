---
title: Převod prezentací PowerPoint do dokumentů Word v .NET
linktitle: PowerPoint do Wordu
type: docs
weight: 110
url: /cs/net/convert-powerpoint-to-word/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint do Wordu
- prezentace do Wordu
- snímek do Wordu
- PPT do Wordu
- PPTX do Wordu
- PowerPoint do DOCX
- prezentace do DOCX
- snímek do DOCX
- PPT do DOCX
- PPTX do DOCX
- PowerPoint do DOC
- prezentace do DOC
- snímek do DOC
- PPT do DOC
- PPTX do DOC
- uložit PPT jako DOCX
- uložit PPTX jako DOCX
- exportovat PPT do DOCX
- exportovat PPTX do DOCX
- .NET
- C#
- Aspose.Slides
description: "Převod snímků PowerPoint PPT a PPTX do editovatelných dokumentů Word v C# pomocí Aspose.Slides pro .NET se zachováním přesného rozvržení, obrázků a formátování."
---
## **Přehled**

Tento článek poskytuje vývojářům řešení pro převod prezentací PowerPoint a OpenDocument do dokumentů Word pomocí Aspose.Slides pro .NET a Aspose.Words pro .NET. Podrobný návod vás provede každým krokem procesu převodu.

## **Převod prezentace do dokumentu Word**

Postupujte podle níže uvedených pokynů pro převod prezentace PowerPoint nebo OpenDocument do dokumentu Word:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a načtěte soubor prezentace.
2. Vytvořte instance tříd [Document](https://reference.aspose.com/words/net/aspose.words/document/) a [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) pro vytvoření dokumentu Word.
3. Nastavte velikost stránky dokumentu Word tak, aby odpovídala velikosti prezentace, pomocí vlastnosti [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
4. Nastavte okraje v dokumentu Word pomocí vlastnosti [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
5. Projděte všechny snímky prezentace pomocí vlastnosti [Presentation.Slides](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/slides/cs/).
    - Vygenerujte obrázek snímku pomocí metody `GetImage` z rozhraní [ISlide](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/) a uložte jej do paměťového proudu.
    - Přidejte obrázek snímku do dokumentu Word pomocí metody `InsertImage` ze třídy [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/).
6. Uložte dokument Word do souboru.

Řekněme, že máme prezentaci "sample.pptx", která vypadá takto:

![Prezentace PowerPoint](PowerPoint.png)

Následující příklad kódu v C# ukazuje, jak převést prezentaci PowerPoint do dokumentu Word:

```cs
// Načtení souboru prezentace.
using var presentation = new Presentation("sample.pptx");

// Vytvoření objektů Document a DocumentBuilder.
var document = new Document();
var builder = new DocumentBuilder(document);

// Nastavení velikosti stránky v dokumentu Word.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Nastavení okrajů v dokumentu Word.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// Procházení všech snímků prezentace.
foreach (var slide in presentation.Slides)
{
    // Vygenerování obrázku snímku a uložení do paměťového proudu.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // Přidání obrázku snímku do dokumentu Word.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Uložení dokumentu Word do souboru.
document.Save("output.docx");
```

Výsledek:

![Dokument Word](Word.png)

{{% alert color="primary" %}} 
Vyzkoušejte náš [**Online PPT to Word Converter**](https://products.aspose.app/slides/cs/conversion/ppt-to-word) a zjistěte, co můžete získat převodem prezentací PowerPoint a OpenDocument do dokumentů Word. 
{{% /alert %}}

## **Často kladené otázky**

**Jaké komponenty je potřeba nainstalovat pro převod prezentací PowerPoint a OpenDocument do dokumentů Word?**

Stačí přidat odpovídající balíčky NuGet pro [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) a [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) do vašeho C# projektu. Obě knihovny fungují jako samostatná API a není nutné mít nainstalovaný Microsoft Office.

**Jsou podporovány všechny formáty prezentací PowerPoint a OpenDocument?**

Aspose.Slides for .NET [supports all presentation formats](/slides/cs/net/supported-file-formats/), včetně PPT, PPTX, ODP a dalších běžných typů souborů. To zajišťuje, že můžete pracovat s prezentacemi vytvořenými v různých verzích Microsoft PowerPoint.