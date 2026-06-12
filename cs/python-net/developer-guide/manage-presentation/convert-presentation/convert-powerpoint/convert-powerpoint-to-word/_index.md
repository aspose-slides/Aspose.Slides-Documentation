---
title: Převod prezentací PowerPoint do dokumentů Word v Pythonu
linktitle: PowerPoint do Word
type: docs
weight: 110
url: /cs/python-net/convert-powerpoint-to-word/
keywords:
- PowerPoint do DOCX
- OpenDocument do DOCX
- prezentace do DOCX
- snímek do DOCX
- PPT do DOCX
- PPTX do DOCX
- ODP do DOCX
- PowerPoint do DOC
- OpenDocument do DOC
- prezentace do DOC
- snímek do DOC
- PPT do DOC
- PPTX do DOC
- ODP do DOC
- PowerPoint do Word
- OpenDocument do Word
- prezentace do Word
- snímek do Word
- PPT do Word
- PPTX do Word
- ODP do Word
- převést PowerPoint
- převést OpenDocument
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- převést ODP
- Python
- Aspose.Slides
description: "Naučte se snadno převádět prezentace PowerPoint a OpenDocument do dokumentů Word pomocí Aspose.Slides for Python via .NET. Náš podrobný návod s ukázkovým kódem v Pythonu poskytuje řešení pro vývojáře, kteří chtějí zefektivnit své pracovní postupy s dokumenty."
---
## **Přehled**

Tento článek poskytuje vývojářům řešení pro převod prezentací PowerPoint a OpenDocument do dokumentů Word pomocí Aspose.Slides for Python via .NET a Aspose.Words for Python via .NET. Postupný průvodce vás provede každým krokem konverzního procesu.

## **Převod prezentace do dokumentu Word**

Postupujte podle níže uvedených pokynů pro převod prezentace PowerPoint nebo OpenDocument do dokumentu Word:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a načtěte soubor prezentace.
2. Vytvořte instanci tříd [Document](https://reference.aspose.com/words/python-net/aspose.words/document/) a [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) pro vytvoření dokumentu Word.
3. Nastavte velikost stránky dokumentu Word tak, aby odpovídala prezentaci, pomocí vlastnosti [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).
4. Nastavte okraje v dokumentu Word pomocí vlastnosti [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).
5. Projděte všechny snímky prezentace pomocí vlastnosti [Presentation.slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/slides/cs/).
    - Vygenerujte obrázek snímku pomocí metody `get_image` ze třídy [Slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/) a uložte jej do paměťového proudu.
    - Přidejte obrázek snímku do dokumentu Word pomocí metody `insert_image` ze třídy [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/).
6. Uložte dokument Word do souboru.

Řekněme, že máme prezentaci „sample.pptx“, která vypadá takto:

![Prezentace PowerPoint](PowerPoint.png)

Následující ukázka kódu v Pythonu demonstruje, jak převést prezentaci PowerPoint do dokumentu Word:

```py
import aspose.slides as slides
import aspose.words as words

# Načtěte soubor prezentace.
with slides.Presentation("sample.pptx") as presentation:

    # Vytvořte objekty Document a DocumentBuilder.
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # Nastavte velikost stránky v dokumentu Word.
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # Nastavte okraje v dokumentu Word.
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # Projděte všechny snímky prezentace.
    for slide in presentation.slides:

        # Vygenerujte obrázek snímku a uložte jej do paměťového proudu.
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # Přidejte obrázek snímku do dokumentu Word.
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # Uložte dokument Word do souboru.
    document.save("output.docx")
```

Výsledek:

![Dokument Word](Word.png)

{{% alert color="primary" %}} 
Vyzkoušejte náš [**Online PPT to Word Converter**](https://products.aspose.app/slides/cs/conversion/ppt-to-word), abyste viděli, co můžete získat převodem prezentací PowerPoint a OpenDocument do dokumentů Word. 
{{% /alert %}}

## **Často kladené otázky**

**Jaké komponenty je třeba nainstalovat pro převod prezentací PowerPoint a OpenDocument do dokumentů Word?**

Stačí přidat příslušné balíčky [Aspose.Slides for Python via .NET](https://pypi.org/project/Aspose.Slides/) a [Aspose.Words for Python .NET](https://pypi.org/project/aspose-words/) do svého projektu v Pythonu. Oba balíčky fungují jako samostatná API a není nutné mít nainstalovaný Microsoft Office.

**Jsou podporovány všechny formáty prezentací PowerPoint a OpenDocument?**

Aspose.Slides for Python .NET [supports all presentation formats](/slides/cs/python-net/supported-file-formats/), including PPT, PPTX, ODP, and other common file types. This ensures that you can work with presentations created in various versions of Microsoft PowerPoint.