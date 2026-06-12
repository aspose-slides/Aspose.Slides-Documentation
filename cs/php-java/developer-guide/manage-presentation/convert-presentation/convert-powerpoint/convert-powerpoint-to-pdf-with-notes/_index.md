---
title: Převod prezentací PowerPoint do PDF s poznámkami v PHP
linktitle: PowerPoint do PDF s poznámkami
type: docs
weight: 50
url: /cs/php-java/convert-powerpoint-to-pdf-with-notes/
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
- PHP
- Aspose.Slides
description: "Převést formáty PPT a PPTX do PDF s poznámkami pomocí Aspose.Slides pro PHP přes Java. Zachovat rozvržení a poznámky přednášejícího pro profesionální prezentace."
---
## **Přehled**

V tomto článku se naučíte, jak převést prezentace PowerPoint do formátu PDF s poznámkami přednášejícího pomocí Aspose.Slides. Tento průvodce pokryje potřebné kroky a poskytne ukázky kódu, které vám pomohou úkol provést efektivně. Na konci článku budete schopni:

- Implementovat proces převodu, který změní snímky PowerPointu na PDF dokumenty a zachová poznámky přednášejícího.
- Přizpůsobit výstupní PDF tak, aby obsahovalo a formátovalo poznámky podle vašich požadavků.

## **Převod PowerPointu na PDF s poznámkami**

Metoda `save` ve třídě [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) může být použita k převodu prezentace PPT nebo PPTX na PDF s poznámkami přednášejícího. S Aspose.Slides stačí načíst prezentaci, nakonfigurovat možnosti rozvržení pomocí třídy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notescommentslayoutingoptions/) tak, aby zahrnovala poznámky, a poté soubor uložit jako PDF. Následující úryvek kódu ukazuje, jak převést ukázkovou prezentaci na PDF v zobrazení poznámek ke snímkům.

```php
$presentation = new Presentation("sample.pptx");

// Nastavit možnosti PDF pro vykreslení poznámek přednášejícího.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Vykreslit poznámky přednášejícího pod snímkem.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Uložit prezentaci do PDF s poznámkami přednášejícího.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="primary" %}} 
Možná budete chtít vyzkoušet Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/cs/conversion). 
{{% /alert %}}