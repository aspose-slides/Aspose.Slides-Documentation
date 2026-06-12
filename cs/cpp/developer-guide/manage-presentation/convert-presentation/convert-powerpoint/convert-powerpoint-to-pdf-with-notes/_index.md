---
title: Převést prezentace PowerPoint do PDF s poznámkami v C++
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
description: "Převést formáty PPT a PPTX do PDF s poznámkami pomocí Aspose.Slides pro C++. Zachovat rozložení a poznámky přednášejícího pro profesionální prezentace."
---
## **Přehled**

V tomto článku se naučíte, jak pomocí Aspose.Slides převést prezentace PowerPoint do formátu PDF s poznámkami přednášejícího. Tento průvodce pokryje nezbytné kroky a poskytne příklady kódu, které vám pomohou úkol provést efektivně. Na konci tohoto článku budete schopni:

- Implementovat proces konverze, který převede snímky PowerPointu do PDF dokumentů a zachová poznámky přednášejícího.
- Přizpůsobit výstupní PDF tak, aby byly poznámky přednášejícího zahrnuty a formátovány podle vašich požadavků.

## **Převést PowerPoint na PDF s poznámkami**

Metoda `Save` ve třídě [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) může být použita k převodu prezentace PPT nebo PPTX do PDF s poznámkami přednášejícího. S Aspose.Slides stačí načíst prezentaci, nakonfigurovat možnosti rozvržení pomocí třídy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/notescommentslayoutingoptions/) tak, aby zahrnovaly poznámky přednášejícího, a potom soubor uložit jako PDF. Následující úryvek kódu ukazuje, jak převést ukázkovou prezentaci do PDF v zobrazení poznámek ke snímkům.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Nastavte možnosti PDF pro vykreslení poznámek přednášejícího.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Vykreslete poznámky přednášejícího pod snímek.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Uložte prezentaci do PDF s poznámkami přednášejícího.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="primary" %}} 
Možná budete chtít vyzkoušet online převodník Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/cs/conversion). 
{{% /alert %}}