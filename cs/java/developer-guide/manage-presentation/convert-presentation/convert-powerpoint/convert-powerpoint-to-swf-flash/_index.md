---
title: Převod prezentací PowerPoint do SWF Flash v jazyce Java
linktitle: PowerPoint na SWF
type: docs
weight: 80
url: /cs/java/convert-powerpoint-to-swf-flash/
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
- Java
- Aspose.Slides
description: "Převod PowerPoint (PPT/PPTX) do SWF Flash v jazyce Java pomocí Aspose.Slides. Krok za krokem ukázky kódu, rychlý výstup vysoké kvality, bez automatizace PowerPointu."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides převést prezentace PowerPoint do formátu SWF. Ukazuje, jak uložit prezentaci jako soubor SWF pomocí metody [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) a jak nastavit export pomocí [SwfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/swfoptions/), včetně nastavení prohlížeče a rozložení poznámek nebo komentářů.

## **Převod prezentací do Flashu**

Metoda [save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) vystavovaná třídou [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) lze použít pro převod celé prezentace do dokumentu **SWF**. Následující příklad ukazuje, jak pomocí možností poskytnutých třídou [**SWFOptions**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SwfOptions) převést prezentaci do dokumentu **SWF**. Také můžete zahrnout komentáře do vygenerovaného SWF pomocí [**ISWFOptions**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISwfOptions) třídy a rozhraní [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INotesCommentsLayoutingOptions).

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // Ukládání prezentace
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Mohu zahrnout skryté snímky do SWF?**

Ano. Povolit skryté snímky můžete pomocí metody [setShowHiddenSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) ve třídě [SwfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/swfoptions/). Ve výchozím nastavení nejsou skryté snímky exportovány.

**Jak mohu ovládat kompresi a konečnou velikost SWF?**

Použijte metodu [setCompressed](https://reference.aspose.com/slides/cs/java/com.aspose.slides/swfoptions/#setCompressed-boolean-) a [upravit kvalitu JPEG](https://reference.aspose.com/slides/cs/java/com.aspose.slides/swfoptions/#setJpegQuality-int-), abyste vyvážili velikost souboru a kvalitu obrazu.

**K čemu slouží 'setViewerIncluded' a kdy bych ho měl vypnout?**

[setViewerIncluded](https://reference.aspose.com/slides/cs/java/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) přidává vestavěné uživatelské rozhraní přehrávače (ovládací prvky navigace, panely, vyhledávání). Vypněte jej, pokud plánujete použít vlastní přehrávač nebo potřebujete čistý rám SWF bez UI.

**Co se stane, pokud chybí zdrojové písmo na počítači, na kterém probíhá export?**

Aspose.Slides nahradí písmo, které specifikujete pomocí [setDefaultRegularFont](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) v [SwfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/swfoptions/), aby se zabránilo nechtěnému přepnutí na jiné písmo.