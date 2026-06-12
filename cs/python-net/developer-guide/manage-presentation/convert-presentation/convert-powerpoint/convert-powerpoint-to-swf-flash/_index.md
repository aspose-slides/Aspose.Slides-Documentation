---
title: Převod prezentací PowerPoint do SWF Flash v Pythonu
linktitle: PowerPoint do SWF Flash
type: docs
weight: 80
url: /cs/python-net/convert-powerpoint-to-swf-flash/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- PowerPoint do SWF
- prezentace do SWF
- snímek do SWF
- PPT do SWF
- PPTX do SWF
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Převod PowerPoint (PPT/PPTX) do SWF Flash v Pythonu s Aspose.Slides. Krok za krokem ukázky kódu, rychlý výstup vysoké kvality, bez automatizace PowerPointu."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint do formátu SWF pomocí Aspose.Slides. Ukazuje, jak uložit prezentaci jako soubor SWF metodou [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/) a jak nakonfigurovat export pomocí [SwfOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/swfoptions/), včetně nastavení prohlížeče a rozložení poznámek nebo komentářů.

## **Převod prezentací do Flash**

Metoda [save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/) poskytovaná třídou [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) může být použita k převodu celé prezentace do dokumentu SWF. Také můžete zahrnout komentáře do vygenerovaného SWF pomocí třídy [SWFOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/swfoptions/) a třídy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/notescommentslayoutingoptions/). Následující příklad ukazuje, jak převést prezentaci do dokumentu SWF pomocí možností poskytovaných třídou SWFOptions.

```py
import aspose.slides as slides

# Vytvořte objekt Presentation, který představuje soubor prezentace
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Ukládání prezentace a stránek s poznámkami
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```

## **Často kladené otázky**

**Mohu zahrnout skryté snímky do SWF?**

Ano. Aktivujte možnost [show_hidden_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) v [SwfOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/swfoptions/). Ve výchozím nastavení nejsou skryté snímky exportovány.

**Jak mohu ovládat kompresi a konečnou velikost SWF?**

Použijte příznak [compressed](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/swfoptions/compressed/) (ve výchozím nastavení povolený) a upravte [jpeg_quality](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/swfoptions/jpeg_quality/) pro vyvážení velikosti souboru a kvality obrazu.

**K čemu slouží 'viewer_included' a kdy jej mám zakázat?**

[viewer_included](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/swfoptions/viewer_included/) přidává vestavěné uživatelské rozhraní přehrávače (ovládací prvky navigace, panely, vyhledávání). Zakázat jej, pokud plánujete použít vlastní přehrávač nebo potřebujete čistý rám SWF bez UI.

**Co se stane, pokud na exportovacím stroji chybí zdrojové písmo?**

Aspose.Slides nahradí písmo, které zadáte pomocí [default_regular_font](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/swfoptions/default_regular_font/) v [SwfOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/swfoptions/), aby se předešlo nechtěnému přepisu.