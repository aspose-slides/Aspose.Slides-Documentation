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
- poznámky řečníka
- PDF s poznámkami
- Node.js
- JavaScript
- Aspose.Slides
description: "Převod formátů PPT a PPTX do PDF s poznámkami v JavaScriptu pomocí Aspose.Slides pro Node.js. Zachovejte rozvržení a poznámky řečníka pro profesionální prezentace."
---
## **Přehled**

V tomto článku se naučíte, jak převést prezentace PowerPoint do formátu PDF s poznámkami řečníka pomocí Aspose.Slides. Tento průvodce pokryje potřebné kroky a poskytne ukázky kódu, které vám pomohou úkol provést efektivně. Na konci článku budete schopni:

- Implementovat proces převodu, který transformuje snímky PowerPointu do PDF dokumentů a zachová poznámky řečníka.
- Přizpůsobit výstupní PDF tak, aby poznámky řečníka byly zahrnuty a formátovány podle vašich požadavků.

Pro nastavení rozměrů a orientace stránky poznámek před exportem viz [Velikost stránky poznámek](/slides/cs/nodejs-java/notes-size/).

## **Převod PowerPointu do PDF s poznámkami**

Metodu `save` ve třídě [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) lze použít k převodu prezentace PPT nebo PPTX do PDF s poznámkami řečníka. S Aspose.Slides stačí načíst prezentaci, nakonfigurovat možnosti rozvržení pomocí třídy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notescommentslayoutingoptions/) tak, aby zahrnovala poznámky řečníka, a poté soubor uložit jako PDF. Následující úryvek kódu ukazuje, jak převést ukázkovou prezentaci do PDF v režimu Poznámkový snímek.

```js
const asposeSlides = require("aspose.slides.via.java");

let presentation = new asposeSlides.Presentation("sample.pptx");

// Nastavte možnosti PDF pro vykreslení poznámek řečníka.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Vykreslení poznámek řečníka pod snímkem.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Poznámka" %}}

Možná budete chtít vyzkoušet online převodník Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/cs/conversion).

{{% /alert %}}