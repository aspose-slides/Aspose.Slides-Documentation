---
title: Převod prezentací PowerPoint do SWF Flash v C++
linktitle: PowerPoint do SWF
type: docs
weight: 80
url: /cs/cpp/convert-powerpoint-to-swf-flash/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint do SWF
- prezentace do SWF
- snímek do SWF
- PPT do SWF
- PPTX do SWF
- PowerPoint do Flash
- prezentace do Flash
- snímek do Flash
- PPT do Flash
- PPTX do Flash
- uložit PPT jako SWF
- uložit PPTX jako SWF
- exportovat PPT do SWF
- exportovat PPTX do SWF
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Převést PowerPoint (PPT/PPTX) do SWF Flash v C++ s Aspose.Slides. Ukázky kódu krok za krokem, rychlý výstup vysoké kvality, bez automatizace PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint do formátu SWF pomocí Aspose.Slides. Ukazuje, jak uložit prezentaci jako soubor SWF pomocí metody [Presentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/) a jak nastavit export pomocí [SwfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/swfoptions/), včetně nastavení prohlížeče a rozložení poznámek nebo komentářů.

## **Převod prezentací do Flashu**

Metoda [Save](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) zpřístupněná třídou [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) lze použít k převodu celé prezentace do dokumentu SWF.  Můžete také zahrnout komentáře do generovaného SWF pomocí třídy [SWFOptions](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.export.swf_options) a třídy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/notescommentslayoutingoptions/). Následující příklad ukazuje, jak převést prezentaci do dokumentu SWF pomocí možností poskytnutých třídou SWFOptions.

``` cpp
// Cesta k adresáři dokumentů.
    System::String dataDir = GetDataPath();

    // Vytvořte objekt Presentation, který představuje soubor prezentace
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // Ukládání prezentace a stránek s poznámkami
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```

## **Často kladené otázky**

**Mohu zahrnout skryté snímky do SWF?**

Ano. Použijte metodu [set_ShowHiddenSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) ve třídě [SwfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/swfoptions/). Ve výchozím nastavení nejsou skryté snímky exportovány.

**Jak mohu kontrolovat kompresi a konečnou velikost SWF?**

Použijte metodu [set_Compressed](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/swfoptions/set_compressed/) a upravte [JPEG quality](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/swfoptions/set_jpegquality/) pro vyvážení velikosti souboru a kvality obrazu.

**K čemu slouží 'set_ViewerIncluded' a kdy jej mám použít?**

[set_ViewerIncluded](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) přidá vestavěné uživatelské rozhraní přehrávače (ovládací prvky navigace, panely, vyhledávání). Zakázat jej, pokud plánujete použít vlastní přehrávač nebo potřebujete čistý rámec SWF bez UI.

**Co se stane, pokud na exportním počítači chybí zdrojové písmo?**

Aspose.Slides nahradí písmo, které zadáte pomocí [set_DefaultRegularFont](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) v [SwfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/swfoptions/), aby se předešlo neúmyslnému přepnutí na jiné písmo.