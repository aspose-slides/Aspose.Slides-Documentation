---
title: Převod prezentací PowerPoint do PDF s poznámkami v JavaScriptu
linktitle: PowerPoint do PDF s poznámkami
type: docs
weight: 50
url: /cs/nodejs-java/convert-powerpoint-to-pdf-with-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Převeďte formáty PPT a PPTX do PDF s poznámkami v JavaScriptu pomocí Aspose.Slides pro Node.js. Zachovejte rozvržení a poznámky přednášejícího pro profesionální prezentace."
---
## **Přehled**

V tomto článku se naučíte, jak převést prezentace PowerPoint do formátu PDF s poznámkami přednášejícího pomocí Aspose.Slides. Tento průvodce pokryje potřebné kroky a poskytne ukázky kódu, které vám pomohou tuto úlohu efektivně zvládnout. Na konci tohoto článku budete schopni:

- Implementovat proces konverze, který převádí snímky PowerPointu do PDF dokumentů při zachování poznámek přednášejícího.
- Přizpůsobit výstupní PDF tak, aby poznámky přednášejícího byly zahrnuty a formátovány podle vašich požadavků.

## **Převod PowerPointu do PDF s poznámkami**

Metoda `save` ve třídě [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) lze použít k převodu prezentace PPT nebo PPTX do PDF s poznámkami přednášejícího. S Aspose.Slides stačí načíst prezentaci, nakonfigurovat možnosti rozvržení pomocí třídy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notescommentslayoutingoptions/) tak, aby zahrnovala poznámky přednášejícího, a potom soubor uložit jako PDF. Následující úryvek kódu ukazuje, jak převést ukázkovou prezentaci do PDF v zobrazení snímku s poznámkami.

```js
let presentation = new asposeSlides.Presentation("sample.pptx");

// Nakonfigurujte možnosti PDF pro vykreslování poznámek přednášejícího.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Vykreslit poznámky přednášejícího pod snímkem.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Uložit prezentaci do PDF s poznámkami přednášejícího.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 
Možná budete chtít vyzkoušet Aspose [Online konvertor PowerPoint do PDF](https://products.aspose.app/slides/cs/conversion). 
{{% /alert %}}