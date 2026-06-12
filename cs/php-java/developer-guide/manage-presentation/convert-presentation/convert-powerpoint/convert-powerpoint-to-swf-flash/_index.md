---
title: Převod prezentací PowerPoint do SWF Flash v PHP
linktitle: PowerPoint do SWF
type: docs
weight: 80
url: /cs/php-java/convert-powerpoint-to-swf-flash/
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
- PHP
- Aspose.Slides
description: "Převod PowerPoint (PPT/PPTX) do SWF Flash v PHP pomocí Aspose.Slides. Krok za krokem ukázky kódu, rychlý výstup vysoké kvality, bez automatizace PowerPointu."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint do formátu SWF pomocí Aspose.Slides. Ukazuje, jak uložit prezentaci jako soubor SWF metodou [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/save/) a jak nakonfigurovat export pomocí [SwfOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/swfoptions/), včetně nastavení prohlížeče a rozložení poznámek nebo komentářů.

## **Převod prezentací do Flashu**

Metoda [save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/save/) vystavená třídou [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) může být použita k převodu celé prezentace do dokumentu **SWF**. Následující příklad ukazuje, jak převést prezentaci do dokumentu **SWF** pomocí možností poskytnutých třídou [SWFOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/swfoptions/). Můžete také zahrnout komentáře do vygenerovaného SWF pomocí třídy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notescommentslayoutingoptions/).

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Ukládání prezentace
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Mohu zahrnout skryté snímky do SWF?**

Ano. Povolit skryté snímky pomocí metody [setShowHiddenSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/swfoptions/setshowhiddenslides/) v [SwfOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/swfoptions/). Ve výchozím nastavení nejsou skryté snímky exportovány.

**Jak mohu kontrolovat kompresi a finální velikost SWF?**

Použijte metodu [setCompressed](https://reference.aspose.com/slides/cs/php-java/aspose.slides/swfoptions/setcompressed/) a upravte kvalitu JPEG pomocí [setJPEGQuality](https://reference.aspose.com/slides/cs/php-java/aspose.slides/swfoptions/setjpegquality/), abyste vybalancovali velikost souboru a věrnost obrazu.

**K čemu slouží 'setViewerIncluded' a kdy byste jej měli zakázat?**

[setViewerIncluded](https://reference.aspose.com/slides/cs/php-java/aspose.slides/swfoptions/setviewerincluded/) přidává vestavěné uživatelské rozhraní přehrávače (navigační ovládací prvky, panely, vyhledávání). Zakázat jej, pokud plánujete použít vlastní přehrávač nebo potřebujete čistý rám SWF bez UI.

**Co se stane, pokud chybí zdrojové písmo na exportovacím počítači?**

Aspose.Slides nahradí písmo, které určíte pomocí [setDefaultRegularFont](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) v [SwfOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/swfoptions/), aby se předešlo nechtěnému přepnutí na výchozí písmo.