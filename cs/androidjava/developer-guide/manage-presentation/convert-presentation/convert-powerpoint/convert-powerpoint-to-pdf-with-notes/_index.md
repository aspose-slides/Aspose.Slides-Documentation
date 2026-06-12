---
title: Převod prezentací PowerPoint do PDF s poznámkami na Androidu
linktitle: PowerPoint do PDF s poznámkami
type: docs
weight: 50
url: /cs/androidjava/convert-powerpoint-to-pdf-with-notes/
keywords:
- převod PowerPointu
- převod prezentace
- převod snímku
- převod PPT
- převod PPTX
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
- Android
- Java
- Aspose.Slides
description: "Převod formátů PPT a PPTX do PDF s poznámkami pomocí Aspose.Slides pro Android v jazyce Java. Zachování rozvržení a poznámek přednášejícího pro profesionální prezentace."
---
## **Přehled**

V tomto článku se naučíte, jak pomocí Aspose.Slides převést prezentace PowerPoint do formátu PDF s poznámkami přednášejícího. Tento průvodce pokryje potřebné kroky a poskytne ukázky kódu, které vám pomohou úkol efektivně splnit. Na konci tohoto článku budete schopni:

- Implementovat proces konverze, který převede snímky PowerPointu do PDF dokumentů a zachová poznámky přednášejícího.
- Přizpůsobit výstupní PDF tak, aby byly poznámky přednášejícího zahrnuty a formátovány podle vašich požadavků.

## **Převod PowerPointu do PDF s poznámkami**

`save` metoda ve třídě [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) může být použita k převodu prezentace PPT nebo PPTX do PDF s poznámkami přednášejícího. S Aspose.Slides jednoduše načtete prezentaci, nastavíte možnosti rozvržení pomocí třídy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/notescommentslayoutingoptions/), aby zahrnovala poznámky přednášejícího, a poté soubor uložíte jako PDF. Následující úryvek kódu ukazuje, jak převést ukázkovou prezentaci do PDF v zobrazení Poznámky ke snímku.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
	// Nastavte možnosti PDF pro vykreslení poznámek přednášejícího.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Vykreslit poznámky přednášejícího pod snímkem.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Uložit prezentaci do PDF s poznámkami přednášejícího.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="primary" %}} 
Možná budete chtít vyzkoušet Aspose [Online převodník PowerPoint do PDF](https://products.aspose.app/slides/cs/conversion). 
{{% /alert %}}