---
title: Převod prezentací PowerPoint do SWF Flash v JavaScriptu
linktitle: PowerPoint na SWF
type: docs
weight: 80
url: /cs/nodejs-java/convert-powerpoint-to-swf-flash/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Převést PowerPoint (PPT/PPTX) do SWF Flash pomocí Aspose.Slides pro Node.js. Krok za krokem ukázky kódu, rychlý výstup vysoké kvality, bez automatizace PowerPointu."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint do formátu SWF pomocí Aspose.Slides. Ukazuje, jak uložit prezentaci jako soubor SWF pomocí metody [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save) a jak konfigurovat export pomocí [SwfOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/swfoptions/), včetně nastavení prohlížeče a rozvržení poznámek nebo komentářů.

## **Převod PPT(X) do SWF**
Metoda [save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) zpřístupněná třídou [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation) může být použita k převodu celé prezentace do dokumentu **SWF**. Následující příklad ukazuje, jak převést prezentaci do dokumentu **SWF** pomocí možností poskytnutých třídou [**SWFOptions**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SwfOptions). Také můžete zahrnout komentáře do generovaného SWF pomocí třídy [**SWFOptions**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SwfOptions) a třídy [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions).

```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Ukládání prezentace
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Mohu zahrnout skryté snímky do SWF?**

Ano. Použijte metodu [setShowHiddenSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) v [SwfOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/swfoptions/). Ve výchozím nastavení nejsou skryté snímky exportovány.

**Jak mohu řídit kompresi a konečnou velikost SWF?**

Použijte metodu [setCompressed](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/swfoptions/setcompressed/) a [setJpegQuality](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/swfoptions/setjpegquality/) k vyvážení velikosti souboru a kvality obrázků.

**K čemu slouží 'setViewerIncluded' a kdy bych jej měl použít?**

[setViewerIncluded](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) přidá vestavěné uživatelské rozhraní přehrávače (ovládací prvky navigace, panely, vyhledávání). Použijte jej, pokud plánujete použít vlastní přehrávač nebo potřebujete čistý rám SWF bez UI.

**Co se stane, pokud na počítači, kde probíhá export, chybí zdrojové písmo?**

Aspose.Slides nahradí písmo, které zadáte pomocí [setDefaultRegularFont](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) v [SwfOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/swfoptions/), aby se předešlo nechtěnému náhradnímu písmu.