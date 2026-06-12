---
title: Převod prezentací PowerPoint do SWF Flash v .NET
linktitle: PowerPoint na SWF
type: docs
weight: 80
url: /cs/net/convert-powerpoint-to-swf-flash/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint na SWF
- prezentace na SWF
- snímek na SWF
- PPT na SWF
- PPTX na SWF
- PowerPoint na Flash
- prezentace na Flash
- snímek na Flash
- PPT na Flash
- PPTX na Flash
- uložit PPT jako SWF
- uložit PPTX jako SWF
- exportovat PPT do SWF
- exportovat PPTX do SWF
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Převod PowerPoint (PPT/PPTX) do SWF Flash v .NET pomocí Aspose.Slides. Krok za krokem ukázky kódu v C#, rychlý výstup vysoké kvality, bez automatizace PowerPointu."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides převést prezentace PowerPoint do formátu SWF. Ukazuje, jak uložit prezentaci jako soubor SWF pomocí metody [Presentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/) a jak nastavit export pomocí [SwfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/swfoptions/), včetně nastavení prohlížeče a rozvržení poznámek nebo komentářů.

## **Převod prezentací do Flashu**

Metoda [Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/methods/save/index) zpřístupněná třídou [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) lze použít k převodu celé prezentace do dokumentu SWF.  Můžete také zahrnout komentáře do vytvořeného SWF pomocí třídy [SWFOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/swfoptions) a rozhraní [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/inotescommentslayoutingoptions). Následující příklad ukazuje, jak převést prezentaci do dokumentu SWF pomocí možností poskytnutých třídou SWFOptions.

```c#
// Vytvořte objekt Presentation, který představuje soubor prezentace
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // Ukládání prezentace a stránek s poznámkami
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```

## **Často kladené otázky**

**Mohu zahrnout skryté snímky do SWF?**

Ano. Aktivujte možnost [ShowHiddenSlides](https://reference.aspose.com/slides/cs/net/aspose.slides.export/swfoptions/showhiddenslides/) v [SwfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/swfoptions/). Ve výchozím nastavení nejsou skryté snímky exportovány.

**Jak mohu kontrolovat kompresi a konečnou velikost SWF?**

Použijte příznak [Compressed](https://reference.aspose.com/slides/cs/net/aspose.slides.export/swfoptions/compressed/) (ve výchozím nastavení povolen) a upravte [JpegQuality](https://reference.aspose.com/slides/cs/net/aspose.slides.export/swfoptions/jpegquality/) pro vyvážení velikosti souboru a kvality obrazu.

**K čemu slouží „ViewerIncluded“ a kdy by měl být vypnut?**

[ViewerIncluded](https://reference.aspose.com/slides/cs/net/aspose.slides.export/swfoptions/viewerincluded/) přidává vložené uživatelské rozhraní přehrávače (navigační ovládací prvky, panely, vyhledávání). Vypněte jej, pokud plánujete použít vlastní přehrávač nebo potřebujete čistý rámec SWF bez UI.

**Co se stane, pokud na exportovacím počítači chybí výchozí písmo?**

Aspose.Slides nahradí písmo, které zadáte pomocí [DefaultRegularFont](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveoptions/defaultregularfont/) v [SwfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveoptions/), aby se předešlo nechtěnému náhradnímu písmu.