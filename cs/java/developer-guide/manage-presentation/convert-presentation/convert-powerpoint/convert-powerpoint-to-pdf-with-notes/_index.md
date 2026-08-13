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
description: "Převod formátů PPT a PPTX do PDF s poznámkami pomocí Aspose.Slides pro Java. Zachování rozvržení a poznámek přednášejícího pro profesionální prezentace."
---
## **Přehled**

V tomto článku se naučíte, jak převést prezentace PowerPoint do formátu PDF s poznámkami přednášejícího pomocí Aspose.Slides. Tento průvodce pokryje potřebné kroky a poskytne ukázkové kódy, které vám pomohou úkol efektivně splnit. Na konci článku budete schopni:

- Implementovat proces převodu, který transformuje snímky PowerPointu do PDF dokumentů při zachování poznámek přednášejícího.
- Přizpůsobit výstupní PDF tak, aby zahrnovalo poznámky přednášejícího a formátovalo je podle vašich požadavků.

## **Převod PowerPointu do PDF s poznámkami**

Metoda `save` ve třídě [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) lze použít k převodu prezentace PPT nebo PPTX do PDF s poznámkami přednášejícího. S Aspose.Slides stačí načíst prezentaci, nakonfigurovat možnosti rozvržení pomocí třídy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/notescommentslayoutingoptions/), aby byly zahrnuty poznámky, a poté soubor uložit jako PDF. Následující úryvek kódu ukazuje, jak převést ukázkovou prezentaci do PDF v režimu Poznámky ke snímkům.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// Nakonfigurujte možnosti PDF pro vykreslení poznámek přednášejícího.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Vykreslit poznámky přednášejícího pod snímkem.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Uložit prezentaci do PDF s poznámkami přednášejícího.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" %}} 
Možná budete chtít vyzkoušet online převodník PowerPoint do PDF od Aspose [Online převodník PowerPoint do PDF](https://products.aspose.app/slides/cs/conversion). 
{{% /alert %}}