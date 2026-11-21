---
title: Převod prezentací PowerPoint do PDF s poznámkami v PHP
linktitle: PowerPoint do PDF s poznámkami
type: docs
weight: 50
url: /cs/php-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- převod PowerPoint
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
- PHP
- Aspose.Slides
description: "Převod formátů PPT a PPTX do PDF s poznámkami pomocí Aspose.Slides pro PHP přes Java. Zachování rozvržení a poznámek přednášejícího pro profesionální prezentace."
---
## **Přehled**

V tomto článku se naučíte, jak převést prezentace PowerPoint do formátu PDF s poznámkami přednášejícího pomocí Aspose.Slides. Tento průvodce pokryje potřebné kroky a poskytne ukázky kódu, které vám pomohou úkol efektivně zvládnout. Na konci tohoto článku budete schopni:

- Implementovat proces konverze, který převede snímky PowerPointu do PDF dokumentů a zároveň zachová poznámky přednášejícího.
- Přizpůsobit výstupní PDF tak, aby byly poznámky přednášejícího zahrnuty a formátovány podle vašich požadavků.

Pro nastavení rozměrů a orientace stránky s poznámkami před exportem, viz [Velikost stránky s poznámkami](/slides/cs/php-java/notes-size/).

## **Převod PowerPointu do PDF s poznámkami**

Metoda `save` ve třídě [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) lze použít k převodu prezentace PPT nebo PPTX do PDF s poznámkami přednášejícího. S Aspose.Slides jednoduše načtete prezentaci, nakonfigurujete možnosti rozvržení pomocí třídy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notescommentslayoutingoptions/) tak, aby zahrnovala poznámky přednášejícího, a poté soubor uložíte jako PDF. Následující úryvek kódu ukazuje, jak převést ukázkovou prezentaci do PDF v zobrazení poznámek ke snímkům.

```php
$presentation = new Presentation("sample.pptx");

// Nastavte možnosti PDF pro vykreslení poznámek přednášejícího.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Vykreslí poznámky přednášejícího pod snímek.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Uložte prezentaci do PDF s poznámkami přednášejícího.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="info" title="Note" %}}
Možná budete chtít vyzkoušet online konvertor Aspose [Online konvertor PowerPoint do PDF](https://products.aspose.app/slides/cs/conversion).
{{% /alert %}}