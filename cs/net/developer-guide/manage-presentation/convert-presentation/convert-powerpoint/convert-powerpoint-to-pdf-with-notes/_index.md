---
title: Převod prezentací PowerPoint do PDF s poznámkami v .NET
linktitle: PowerPoint do PDF s poznámkami
type: docs
weight: 50
url: /cs/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint do PDF
- prezentace do PDF
- snímek do PDF
- PPT do PDF
- PPTX do PDF
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
description: "Převod formátů PPT a PPTX do PDF s poznámkami pomocí Aspose.Slides pro .NET. Zachování rozvržení a poznámek přednášejícího pro profesionální prezentace."
---
## **Přehled**

V tomto článku se naučíte, jak pomocí Aspose.Slides převést prezentace PowerPoint do formátu PDF s poznámkami přednášejícího. Tento průvodce popíše potřebné kroky a poskytne ukázky kódu, aby vám pomohl úkol provést efektivně. Na konci tohoto článku budete schopni:

- Implementovat proces převodu, který transformuje snímky PowerPointu do PDF dokumentů a zachová poznámky přednášejícího.
- Přizpůsobit výstupní PDF tak, aby zahrnoval poznámky přednášejícího a byl formátován podle vašich požadavků.

## **Převod PowerPointu do PDF s poznámkami**

Metoda `Save` ve třídě [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) lze použít k převodu prezentace PPT nebo PPTX do PDF s poznámkami přednášejícího. S Aspose.Slides jednoduše načtete prezentaci, nakonfigurujete možnosti rozvržení pomocí třídy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/notescommentslayoutingoptions/) tak, aby zahrnovala poznámky přednášejícího, a poté soubor uložíte jako PDF. Následující úryvek kódu ukazuje, jak převést ukázkovou prezentaci do PDF v zobrazení snímku s poznámkami.

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
            NotesPosition = NotesPositions.BottomFull // Vykreslí poznámky přednášejícího pod snímek.
        }
    };

    // Uložte prezentaci do PDF s poznámkami přednášejícího.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="info" %}} 
Možná budete chtít vyzkoušet online převaděč Aspose [Online převaděč PowerPoint do PDF](https://products.aspose.app/slides/cs/conversion). 
{{% /alert %}}