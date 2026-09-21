---
title: Převod prezentací PowerPoint do PDF s poznámkami v C++
linktitle: PowerPoint do PDF s poznámkami
type: docs
weight: 50
url: /cs/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint do PDF
- prezentace do PDF
- snímek do PDF
- PPT do PDF
- PPTX do PDF
- uložit prezentaci jako PDF
- uložit PPT jako PDF
- uložit PPTX jako PDF
- exportovat PPT do PDF
- exportovat PPTX do PDF
- poznámky přednášejícího
- PDF s poznámkami
- C++
- Aspose.Slides
description: "Převod formátů PPT a PPTX do PDF s poznámkami pomocí Aspose.Slides pro C++. Zachovejte rozvržení a poznámky přednášejícího pro profesionální prezentace."
---
## **Přehled**

V tomto článku se naučíte, jak převést prezentace PowerPoint do formátu PDF s poznámkami přednášejícího pomocí Aspose.Slides. Tento průvodce popisuje potřebné kroky a poskytuje ukázkové kódy, které vám pomohou tuto úlohu provést efektivně. Na konci článku budete schopni:

- Implementovat proces převodu, který promění snímky PowerPointu na PDF dokumenty a zachová poznámky přednášejícího.
- Přizpůsobit výstupní PDF tak, aby zahrnovalo poznámky přednášejícího a bylo formátováno podle vašich požadavků.

Pro nastavení rozměrů a orientace stránky poznámek před exportem si přečtěte [Velikost stránky poznámek](/slides/cs/cpp/notes-size/).

## **Převod PowerPointu do PDF s poznámkami**

Metodu `Save` ve třídě [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) lze použít k převodu prezentace PPT nebo PPTX do PDF s poznámkami přednášejícího. S Aspose.Slides stačí načíst prezentaci, nakonfigurovat možnosti rozložení pomocí třídy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/notescommentslayoutingoptions/), aby byly zahrnuty poznámky přednášejícího, a poté soubor uložit jako PDF. Následující úryvek kódu ukazuje, jak převést ukázkovou prezentaci do PDF v zobrazení poznámek k snímkům.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Configure PDF options for rendering speaker notes.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Vykreslit poznámky přednášejícího pod snímkem.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Možná budete chtít vyzkoušet Aspose [Online konvertor PowerPoint do PDF](https://products.aspose.app/slides/cs/conversion).
{{% /alert %}}