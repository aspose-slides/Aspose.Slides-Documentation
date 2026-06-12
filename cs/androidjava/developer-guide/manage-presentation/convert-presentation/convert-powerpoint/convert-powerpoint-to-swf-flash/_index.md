---
title: Převod prezentací PowerPoint na SWF Flash na Androidu
linktitle: PowerPoint na SWF
type: docs
weight: 80
url: /cs/androidjava/convert-powerpoint-to-swf-flash/
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
- Android
- Java
- Aspose.Slides
description: "Převod PowerPoint (PPT/PPTX) na SWF Flash v Javě s Aspose.Slides pro Android. Krok za krokem ukázky kódu, rychlý výstup vysoké kvality, bez automatizace PowerPointu."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint do formátu SWF pomocí Aspose.Slides. Ukazuje, jak uložit prezentaci jako soubor SWF pomocí metody [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) a jak nakonfigurovat export pomocí [SwfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/swfoptions/), včetně nastavení prohlížeče a rozvržení poznámek nebo komentářů.

## **Převod PPT(X) na SWF**
Metoda [Save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) vystavená třídou [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) může být použita k převodu celé prezentace do dokumentu **SWF**. Následující příklad ukazuje, jak převést prezentaci do dokumentu **SWF** pomocí možností poskytovaných třídou [**SWFOptions**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SwfOptions). Můžete také zahrnout komentáře do vygenerovaného SWF pomocí [**ISWFOptions**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISwfOptions) třídy a [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions) rozhraní.

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

Ano. Skryté snímky lze povolit pomocí metody [setShowHiddenSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) v [SwfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/swfoptions/). Ve výchozím nastavení nejsou skryté snímky exportovány.

**Jak mohu řídit kompresi a konečnou velikost SWF?**

Použijte metodu [setCompressed](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) a upravte kvalitu JPEG pomocí [setJpegQuality](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-), abyste vyvážili velikost souboru a věrnost obrazu.

**K čemu slouží 'setViewerIncluded' a kdy jej mám vypnout?**

Metoda [setViewerIncluded](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) přidává vestavěné uživatelské rozhraní přehrávače (ovládací prvky navigace, panely, vyhledávání). Vypněte ji, pokud plánujete použít vlastní přehrávač nebo potřebujete čistý rám SWF bez UI.

**Co se stane, když na exportovacím počítači chybí výchozí font?**

Aspose.Slides nahradí chybějící font fontem, který zadáte pomocí metody [setDefaultRegularFont](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) v [SwfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/swfoptions/), aby se zabránilo neúmyslnému přepnutí.