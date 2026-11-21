---
title: Převod prezentací do PDF s poznámkami v Pythonu
linktitle: Prezentace do PDF s poznámkami
type: docs
weight: 50
url: /cs/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- převod PowerPointu
- převod OpenDocument
- převod prezentace
- převod PPT
- převod PPTX
- převod ODP
- PowerPoint do PDF
- OpenDocument do PDF
- prezentace do PDF
- PPT do PDF
- PPTX do PDF
- ODP do PDF
- poznámky přednášejícího
- PDF s poznámkami
- Python
- Aspose.Slides
description: "Převod formátů PPT, PPTX a ODP do PDF s poznámkami pomocí Aspose.Slides pro Python. Zachovejte rozložení a poznámky přednášejícího pro profesionální prezentace."
---
## **Přehled**

V tomto článku se naučíte, jak převést prezentace PowerPoint do formátu PDF s poznámkami přednášejícího pomocí Aspose.Slides. Tento průvodce pokryje potřebné kroky a poskytne příklady kódu, které vám pomohou úkol efektivně splnit. Na konci tohoto článku budete schopni:

- Implementovat proces převodu, který transformuje snímky PowerPointu do PDF dokumentů a zachová poznámky přednášejícího.
- Přizpůsobit výstupní PDF tak, aby byly poznámky přednášejícího zahrnuty a formátovány podle vašich požadavků.

Pro nastavení rozměrů a orientace stránky poznámek před exportem viz [Velikost stránky poznámek](/slides/cs/python-net/notes-size/).

## **Převést PowerPoint do PDF s poznámkami**

`save` metoda ve třídě [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) lze použít k převodu PPT nebo PPTX prezentace do PDF s poznámkami přednášejícího. S Aspose.Slides stačí načíst prezentaci, nakonfigurovat možnosti rozvržení pomocí třídy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/notescommentslayoutingoptions/) tak, aby zahrnovala poznámky přednášejícího, a poté soubor uložit jako PDF. Následující úryvek kódu ukazuje, jak převést ukázkovou prezentaci do PDF v zobrazení poznámkového snímku.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    # Nakonfigurujte možnosti PDF pro vykreslení poznámek přednášejícího.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # Uložte prezentaci do PDF s poznámkami přednášejícího.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="info" title="Note" %}}
Možná budete chtít vyzkoušet online konvertor Aspose [Online konvertor PowerPoint do PDF](https://products.aspose.app/slides/cs/conversion).
{{% /alert %}}