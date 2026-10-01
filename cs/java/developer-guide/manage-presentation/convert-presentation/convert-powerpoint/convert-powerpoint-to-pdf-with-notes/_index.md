---
title: Převod prezentací PowerPoint do PDF s poznámkami v Javě
linktitle: PowerPoint do PDF s poznámkami
type: docs
weight: 50
url: /cs/java/convert-powerpoint-to-pdf-with-notes/
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
- Java
- Aspose.Slides
description: "Převod formátů PPT a PPTX do PDF s poznámkami pomocí Aspose.Slides pro Javu. Zachovejte rozvržení a poznámky přednášejícího pro profesionální prezentace."
---
## **Přehled**

V tomto článku se naučíte, jak pomocí Aspose.Slides převést prezentace PowerPoint do formátu PDF s poznámkami přednášejícího. Tento průvodce popíše potřebné kroky a poskytne ukázky kódu, které vám pomohou úkol efektivně splnit. Na konci článku budete schopni:

- Implementovat proces konverze, který převede snímky PowerPointu do PDF dokumentů a zachová poznámky přednášejícího.
- Přizpůsobit výstupní PDF tak, aby poznámky přednášejícího byly zahrnuty a formátovány podle vašich požadavků.

Pro nastavení rozměrů a orientace stránky s poznámkami před exportem viz [Velikost stránky s poznámkami](/slides/cs/java/notes-size/).

## **Převod PowerPointu do PDF s poznámkami**

Metodu `save` ve třídě [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) lze použít k převodu prezentace PPT nebo PPTX do PDF s poznámkami přednášejícího. S Aspose.Slides stačí načíst prezentaci, nastavit možnosti rozložení pomocí třídy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/notescommentslayoutingoptions/), aby byly zahrnuty poznámky přednášejícího, a poté soubor uložit jako PDF. Následující úryvek kódu ukazuje, jak převést ukázkovou prezentaci do PDF v zobrazení poznámkových snímků.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// Nakonfigurujte PDF možnosti pro vykreslení poznámek přednášejícího.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Vykreslit poznámky přednášejícího pod snímkem.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Uložit prezentaci do PDF s poznámkami přednášejícího.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
Možná budete chtít vyzkoušet online převodník Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/cs/conversion).
{{% /alert %}}