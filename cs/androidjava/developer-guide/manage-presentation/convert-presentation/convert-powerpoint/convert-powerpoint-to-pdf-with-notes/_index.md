---
title: Převod prezentací PowerPoint do PDF s poznámkami na Androidu
linktitle: PowerPoint do PDF s poznámkami
type: docs
weight: 50
url: /cs/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "Převod formátů PPT a PPTX do PDF s poznámkami pomocí Aspose.Slides pro Android prostřednictvím Javy. Zachovejte rozvržení a poznámky přednášejícího pro profesionální prezentace."
---
## **Přehled**

V tomto článku se dozvíte, jak pomocí Aspose.Slides převést prezentace PowerPoint do formátu PDF s poznámkami přednášejícího. Tento průvodce popíše potřebné kroky a poskytne ukázkové kódy, které vám pomohou tuto úlohu provést efektivně. Na konci článku budete schopni:

- Implementovat proces konverze, který převádí snímky PowerPointu do PDF dokumentů a zachovává poznámky přednášejícího.
- Přizpůsobit výstupní PDF tak, aby obsahovalo poznámky přednášejícího a bylo formátováno podle vašich požadavků.

## **Převod PowerPointu do PDF s poznámkami**

Metoda `save` ve třídě [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) lze použít k převodu prezentace PPT nebo PPTX do PDF s poznámkami přednášejícího. S Aspose.Slides jednoduše načtete prezentaci, nastavíte možnosti rozvržení pomocí třídy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/notescommentslayoutingoptions/), aby byly zahrnuty poznámky přednášejícího, a poté soubor uložíte jako PDF. Následující úryvek kódu ukazuje, jak převést ukázkovou prezentaci do PDF v zobrazení poznámek ke snímkům.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// Nastavte možnosti PDF pro vykreslení poznámek přednášejícího.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Vykreslete poznámky přednášejícího pod snímkem.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Uložte prezentaci do PDF s poznámkami přednášejícího.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" %}} 
Možná budete chtít vyzkoušet Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/cs/conversion). 
{{% /alert %}}