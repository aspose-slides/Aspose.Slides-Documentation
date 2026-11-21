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
- poznámky řečníka
- PDF s poznámkami
- Android
- Java
- Aspose.Slides
description: "Převod formátů PPT a PPTX do PDF s poznámkami pomocí Aspose.Slides pro Android v jazyce Java. Zachování rozvržení a poznámek řečníka pro profesionální prezentace."
---
## **Přehled**

V tomto článku se naučíte, jak převést prezentace PowerPoint do formátu PDF s poznámkami řečníka pomocí Aspose.Slides. Tento průvodce pokryje potřebné kroky a poskytne ukázky kódu, které vám pomohou úkol efektivně dokončit. Na konci tohoto článku budete schopni:

- Implementovat proces konverze, který přemění snímky PowerPointu na PDF dokumenty a zachová poznámky řečníka.
- Přizpůsobit výstupní PDF tak, aby zahrnovalo poznámky řečníka a bylo formátováno podle vašich požadavků.

Pro nastavení rozměrů a orientace stránky s poznámkami před exportem viz [Velikost stránky s poznámkami](/slides/cs/androidjava/notes-size/).

## **Převod PowerPointu do PDF s poznámkami**

`save` metoda ve třídě [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) může být použita k převodu prezentace PPT nebo PPTX do PDF s poznámkami řečníka. S Aspose.Slides stačí načíst prezentaci, nakonfigurovat možnosti rozvržení pomocí třídy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/notescommentslayoutingoptions/) tak, aby zahrnovala poznámky řečníka, a poté soubor uložit jako PDF. Následující úryvek kódu demonstruje, jak převést ukázkovou prezentaci do PDF v zobrazení Poznámky ke snímku.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// Nastavte možnosti PDF pro vykreslení poznámek řečníka.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Vykreslí poznámky řečníka pod snímek.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Uložte prezentaci do PDF s poznámkami řečníka.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" title="Poznámka" %}}
Možná budete chtít vyzkoušet Aspose [Online konvertor PowerPoint do PDF](https://products.aspose.app/slides/cs/conversion).
{{% /alert %}}