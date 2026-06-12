---
title: Převod prezentací na PDF s poznámkami v Pythonu
linktitle: Prezentace na PDF s poznámkami
type: docs
weight: 50
url: /cs/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- převést PowerPoint
- převést OpenDocument
- převést prezentaci
- převést PPT
- převést PPTX
- převést ODP
- PowerPoint na PDF
- OpenDocument na PDF
- prezentace na PDF
- PPT na PDF
- PPTX na PDF
- ODP na PDF
- poznámky přednášejícího
- PDF s poznámkami
- Python
- Aspose.Slides
description: "Převod formátů PPT, PPTX a ODP na PDF s poznámkami pomocí Aspose.Slides pro Python. Zachování rozvržení a poznámek přednášejícího pro profesionální prezentace."
---
## **Přehled**

V tomto článku se naučíte, jak převést prezentace PowerPoint do formátu PDF s poznámkami přednášejícího pomocí Aspose.Slides. Tento průvodce pokryje potřebné kroky a poskytne ukázky kódu, které vám pomohou tuto úlohu efektivně splnit. Na konci tohoto článku budete schopni:

- Implementovat proces konverze, který přemění snímky PowerPointu na PDF dokumenty při zachování poznámek přednášejícího.
- Přizpůsobit výstupní PDF tak, aby byly poznámky přednášejícího zahrnuty a naformátovány podle vašich požadavků.

## **Převod PowerPointu na PDF s poznámkami**

Metoda `save` ve třídě [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) lze použít k převodu prezentace PPT nebo PPTX na PDF s poznámkami přednášejícího. S Aspose.Slides stačí načíst prezentaci, nakonfigurovat možnosti rozložení pomocí třídy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/notescommentslayoutingoptions/) tak, aby zahrnovala poznámky přednášejícího, a poté soubor uložit jako PDF. Následující úryvek kódu demonstruje, jak převést ukázkovou prezentaci na PDF v zobrazení Poznámky ke snímkům.

```py
with slides.Presentation("sample.pptx") as presentation:

    # Nakonfigurujte možnosti PDF pro vykreslení poznámek přednášejícího.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # Uložte prezentaci do PDF s poznámkami přednášejícího.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="primary" %}} 

Možná budete chtít vyzkoušet online převodník Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/cs/conversion). 

{{% /alert %}}