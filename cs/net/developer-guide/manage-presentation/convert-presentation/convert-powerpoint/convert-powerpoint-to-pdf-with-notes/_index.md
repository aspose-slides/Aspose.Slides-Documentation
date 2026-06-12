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
- poznámky k řečníkům
- PDF s poznámkami
- .NET
- C#
- Aspose.Slides
description: "Převod formátů PPT a PPTX do PDF s poznámkami pomocí Aspose.Slides pro .NET. Zachovejte rozvržení a poznámky k řečníkům pro profesionální prezentace."
---
## **Přehled**

V tomto článku se naučíte, jak převést prezentace PowerPoint do formátu PDF s poznámkami k řečníkům pomocí Aspose.Slides. Tento průvodce pokryje nezbytné kroky a poskytne ukázky kódu, které vám pomohou úkol efektivně splnit. Na konci tohoto článku budete schopni:

- Implementovat proces konverze, který převádí snímky PowerPointu do PDF dokumentů při zachování poznámek k řečníkům.
- Přizpůsobit výstupní PDF tak, aby poznámky k řečníkům byly zahrnuty a naformátovány podle vašich požadavků.

## **Převod PowerPointu do PDF s poznámkami**

`Save` metoda ve třídě [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) lze použít k převodu prezentace PPT nebo PPTX do PDF s poznámkami k řečníkům. S Aspose.Slides stačí načíst prezentaci, nakonfigurovat možnosti rozvržení pomocí třídy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/notescommentslayoutingoptions/) tak, aby zahrnovala poznámky k řečníkům, a následně soubor uložit jako PDF. Následující úryvek kódu ukazuje, jak převést ukázkovou prezentaci do PDF v zobrazení Poznámky ke snímkům.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Nastavte možnosti PDF pro vykreslení poznámek k řečníkům.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Vykreslete poznámky k řečníkům pod snímek.
        }
    };

    // Uložte prezentaci do PDF s poznámkami k řečníkům.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="primary" %}} 
Možná budete chtít vyzkoušet online převodník Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/cs/conversion). 
{{% /alert %}}