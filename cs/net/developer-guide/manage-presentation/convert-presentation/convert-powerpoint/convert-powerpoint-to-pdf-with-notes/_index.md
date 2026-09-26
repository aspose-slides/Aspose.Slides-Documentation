---
title: Převod prezentací PowerPoint na PDF s poznámkami v .NET
linktitle: PowerPoint na PDF s poznámkami
type: docs
weight: 50
url: /cs/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint na PDF
- prezentace na PDF
- snímek na PDF
- PPT na PDF
- PPTX na PDF
- uložit prezentaci jako PDF
- uložit PPT jako PDF
- uložit PPTX jako PDF
- exportovat PPT do PDF
- exportovat PPTX do PDF
- poznámky přednášejícího
- PDF s poznámkami
- .NET
- C#
- Aspose.Slides
description: "Převod formátů PPT a PPTX na PDF s poznámkami pomocí Aspose.Slides pro .NET. Zachovejte rozvržení a poznámky přednášejícího pro profesionální prezentace."
---
## **Přehled**

V tomto článku se dozvíte, jak převést prezentace PowerPoint na formát PDF s poznámkami přednášejícího pomocí Aspose.Slides. Tento průvodce popisuje potřebné kroky a poskytuje ukázky kódu, které vám pomohou úkol provést efektivně. Na konci článku budete schopni:

- Implementovat proces konverze, který promění snímky PowerPointu na PDF dokumenty a zachová poznámky přednášejícího.
- Přizpůsobit výstupní PDF tak, aby obsahovalo poznámky přednášejícího a bylo naformátováno podle vašich požadavků.

Pro nastavení rozměrů a orientace stránky poznámek před exportem viz [Velikost stránky poznámek](/slides/cs/net/notes-size/).

## **Převod PowerPointu na PDF s poznámkami**

Metoda `Save` ve třídě [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) lze použít k převodu PPT nebo PPTX prezentace na PDF s poznámkami přednášejícího. S Aspose.Slides stačí načíst prezentaci, nakonfigurovat možnosti rozvržení pomocí třídy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/notescommentslayoutingoptions/) a následně soubor uložit jako PDF. Následující úryvek kódu ukazuje, jak převést ukázkovou prezentaci na PDF v zobrazení snímku s poznámkami.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Nakonfigurujte možnosti PDF pro vykreslení poznámek přednášejícího.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Vykreslit poznámky přednášejícího pod snímkem.
        }
    };

    // Uložit prezentaci do PDF s poznámkami přednášejícího.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="info" %}} 

Možná budete chtít vyzkoušet Aspose [Online konvertor PowerPoint na PDF](https://products.aspose.app/slides/cs/conversion). 

{{% /alert %}}