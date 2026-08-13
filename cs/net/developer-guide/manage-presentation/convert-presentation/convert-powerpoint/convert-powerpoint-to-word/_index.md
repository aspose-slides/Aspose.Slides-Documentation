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
description: "Převod snímků PowerPoint PPT a PPTX do editovatelných dokumentů Word v C# pomocí Aspose.Slides pro .NET s přesným rozložením, obrázky a zachovaným formátováním."
---
## **Přehled**

Tento článek poskytuje vývojářům řešení pro převod prezentací PowerPoint a OpenDocument do dokumentů Word pomocí Aspose.Slides pro .NET a Aspose.Words pro .NET. Průvodce krok za krokem vás provede každou fází převodního procesu.

## **Převod prezentace do dokumentu Word**

Postupujte podle níže uvedených instrukcí pro převod prezentace PowerPoint nebo OpenDocument do dokumentu Word:

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
using Aspose.Slides;
using Aspose.Words;

// Načíst soubor prezentace.
using var presentation = new Presentation("sample.pptx");

// Vytvořit objekty Document a DocumentBuilder.
var document = new Document();
var builder = new DocumentBuilder(document);

// Nastavit velikost stránky v dokumentu Word.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Nastavit okraje v dokumentu Word.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// Projít všechny snímky prezentace.
foreach (var slide in presentation.Slides)
{
    // Vygenerovat obrázek snímku a uložit jej do paměťového proudu.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // Přidat obrázek snímku do dokumentu Word.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Uložit dokument Word do souboru.
document.Save("output.docx");
```

Výsledek:

![Dokument Word](Word.png)

{{% alert color="info" %}} 
Vyzkoušejte náš [**Online PPT do Word převodník**](https://products.aspose.app/slides/cs/conversion/ppt-to-word), abyste zjistili, co můžete získat převodem prezentací PowerPoint a OpenDocument do dokumentů Word. 
{{% /alert %}}

## **Často kladené otázky**

### Jaké komponenty je potřeba nainstalovat pro převod prezentací PowerPoint a OpenDocument do dokumentů Word?

Stačí přidat příslušné balíčky NuGet pro [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) a [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) do vašeho projektu C#. Obě knihovny fungují jako samostatná API a není nutné mít nainstalovaný Microsoft Office.

### Jsou podporovány všechny formáty prezentací PowerPoint a OpenDocument?

Aspose.Slides for .NET [podporuje všechny formáty prezentací](/slides/cs/net/supported-file-formats/), včetně PPT, PPTX, ODP a dalších běžných typů souborů. To zajišťuje, že můžete pracovat s prezentacemi vytvořenými v různých verzích Microsoft PowerPoint.