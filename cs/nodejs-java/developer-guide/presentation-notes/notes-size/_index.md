---
title: Změna velikosti a orientace stránky poznámek v JavaScriptu
linktitle: Velikost stránky poznámek
type: docs
weight: 10
url: /cs/nodejs-java/notes-size/
keywords:
- velikost stránky poznámek
- orientace poznámek
- poznámky na šířku
- poznámky na výšku
- velikost podkladu
- PowerPoint
- prezentace
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Přečtěte a změňte rozměry stránky poznámek v Aspose.Slides pro Node.js pomocí Java, přepněte orientaci, ověřte uložené rozměry a exportujte poznámky nebo podklady do PDF a obrázků."
---
## **Přehled**

Použijte [Presentation.getNotesSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getnotessize/) k získání nastavení stránky poznámek prezentace. Vrací objekt [NotesSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notessize/) , jehož metoda [setSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notessize/setsize/) nastavuje rozměry stránky. I když samotný objekt nastavení nelze nahradit, můžete pomocí této metody přiřadit nové rozměry.

Šířka a výška jsou uvedeny v **bodech**, přičemž 72 bodů odpovídá jednomu palci. Například 900 × 600 bodů je 12,5 × 8 ⅓ palce. Toto nastavení platí pro celou prezentaci, nikoli pro poznámky jednotlivých snímků.

| Nastavení | Účel |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getnotessize/) | Řídí rozměry stránky poznámek a rozměry stránky používané při exportu podkladů. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getslidesize/) | Řídí rozměry běžných snímků prezentace pomocí [SlideSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesize/). |

Změna jednoho nastavení automaticky nemění druhé. Změna orientace stránky poznámek také neotáčí běžné snímky. Viz [Slide Size](/slides/cs/nodejs-java/slide-size/) pro změnu velikosti běžných snímků.

Níže uvedené příklady používají existující soubor `sample.pptx`. Pro příklady exportu použijte prezentaci s alespoň jedním snímkem obsahujícím poznámky řečníka. Každý příklad lze spustit samostatně.

## **Přečtení velikosti a orientace stránky poznámek**

Přečtěte šířku a výšku a porovnejte je, abyste určili orientaci: širší stránka je na šířku (landscape), vyšší stránka je na výšku (portrait) a stejné rozměry popisují čtvercovou stránku. Tento příklad vypíše skutečné rozměry v bodech, aniž by předpokládal standardní velikost papíru.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();
    let orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    console.log("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    console.log("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Přepnutí na šířkový formát bez změny velikosti papíru**

Pro změnu pouze orientace prohoďte existující šířku a výšku. Tím se zachová délka obou stran, včetně těch u vlastního formátu papíru. Níže uvedená podmínka zabraňuje převrácení již šířkové stránky zpět na výšku a ponechává čtvercovou stránku nezměněnou.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        let width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro orientaci na výšku použijte stejné přiřazení, když `size.getWidth() > size.getHeight()`. Nepoužívejte rozměry A4 nebo Letter, pokud zároveň nechcete změnit velikost papíru.

## **Nastavení a ověření vlastní velikosti stránky poznámek**

Přiřaďte oba rozměry najednou a poté použijte [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/save/) k uložení prezentace. Tento příklad nastaví šířkovou stránku 900 × 600 bodů, uloží ji jako PPTX a znovu otevře uložený soubor pro ověření uložených hodnot. Porovnání povoluje toleranci 0,01 bodu pro hodnoty s plovoucí desetinnou čárkou; není to záruka přesnosti pro každý formát souboru.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let expectedSize = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", slides.SaveFormat.Pptx);

    let reopened = new slides.Presentation("custom-notes.pptx");
    try {
        let actualSize = reopened.getNotesSize().getSize();
        let widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        let heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        let preserved = widthMatches && heightMatches;

        console.log("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        console.log("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Očekávaný výsledek je `900 x 600 points` a `Size preserved: true`. Kontrola nově otevřené prezentace ověří uložený soubor, nikoli jen nastavení v paměti.

## **Export poznámek a podkladů**

Rozměry stránky definují dostupnou oblast pro rozvržení poznámek nebo podkladů. Samy o sobě tyto rozvržení neaktivují: je třeba také nastavit možnosti exportu. Export běžných snímků nadále používá rozměry snímku.

### **Export poznámek do PDF a PNG**

Přiřaďte [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notescommentslayoutingoptions/) k [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions), aby se poznámky zahrnuly do PDF. Tento příklad také vykresluje první snímek s poznámkami do PNG pomocí [Slide.getImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#getImage) a [RenderingOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/renderingoptions/).

Režim [BottomTruncated](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notespositions/) udržuje poznámky na jedné stránce; poznámky, které se nevejdou, mohou být zkráceny. PDF používá stránky o rozměrech 900 × 600 bodů. Při měřítku obrazu 1 × 1 použitém níže má PNG rozměry 900 × 600 pixelů. Body popisují geometrii stránky; pixely popisují rastrový výstup, jehož rozměry také závisí na měřítku vykreslování.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.NotesCommentsLayoutingOptions();
    layout.setNotesPosition(slides.NotesPositions.BottomTruncated);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", slides.SaveFormat.Pdf, pdfOptions);

    let renderingOptions = new slides.RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    let image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Pro export PDF s dlouhými poznámkami umožňuje [BottomFull](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notespositions/) přidávat další stránky podle potřeby. Tento režim nepoužívejte s výše uvedeným voláním pro obrázek jednoho snímku, který jej nepodporuje. Po změně velikosti zkontrolujte výstup na oříznuté poznámky a umístění existujících objektů notes-master; změna rozměrů stránky samotná by neměla být považována za záruku, že veškerý obsah se vejde. Více o exportu poznámek najdete v [Convert PowerPoint to PDF with Notes](/slides/cs/nodejs-java/convert-powerpoint-to-pdf-with-notes/).

### **Export podkladů do PDF**

Použijte [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/handoutlayoutingoptions/) pro zobrazení několika miniatur snímků na jedné stránce. Následující příklad nastaví stránku o rozměrech 900 × 600 bodů a použije [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/handouttype/) , aby uspořádal až čtyři snímky na stránku. Horizontální předvolba řídí pořadí snímků; orientace stránky vychází z její šířky a výšky.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.HandoutLayoutingOptions();
    layout.setHandout(slides.HandoutType.Handouts4Horizontal);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Změna velikosti stránky mění oblast dostupnou pro mřížku podkladů, aniž by změnila rozměry zdrojových snímků. Pro obrázky podkladů použijte [Presentation.getImages](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getimages/) s rozvržením podkladů, nikoli metodu obrázku jednotlivého snímku. V Aspose.Slides se vykreslování podkladů na úrovni prezentace řídí rozměry stránky poznámek, zatímco volání metody pro obrázek jednotlivého snímku nevytváří stránku podkladu. Viz [Handout Mode](/slides/cs/nodejs-java/convert-powerpoint-in-handout-mode/) pro možnosti rozvržení.

## **Velikost stránky v prohlížečích, exportu a tisku**

Udržujte oddělené velikost uložené prezentace, velikost exportované stránky a velikost tištěného papíru:

- **Prohlížeče prezentací:** Prohlížeč může zobrazovat nebo tisknout poznámky pomocí vlastních pravidel rozvržení. Pokud jiná aplikace soubor uloží, otevřete jej znovu a zkontrolujte rozměry; konverze formátu v té aplikaci je může normalizovat.
- **Formáty exportu:** Výše uvedené příklady PDF pro poznámky a podklady používají nastavené rozměry stránky. Rastrové obrázky používají celočíselné rozměry pixelů a měřítko vykreslování, takže desetinné hodnoty bodů mohou být zaokrouhleny ve výstupu obrázku. Export běžných snímků neaplikuje velikost stránky poznámek.
- **Tiskové ovladače:** Výběr papíru, automatické otáčení a nastavení přizpůsobení stránky mohou změnit fyzický výstup aniž by změnily rozměry uložené v prezentaci nebo PDF. Pro konkrétní velikost papíru nastavte tiskárnu odpovídajícím způsobem a prohlédněte si náhled tisku.

## **Často kladené otázky**

**Mohu nastavit velikost poznámek jen pro jeden snímek?**

Velikost stránky poznámek je nastavení na úrovni celé prezentace. Jednotlivé snímky mohou mít odlišný obsah poznámek, ale tato vlastnost nenabízí samostatnou velikost stránky pro každý snímek.

**Proč změna orientace poznámek neovlivnila moje snímky?**

Stránky poznámek a běžné snímky mají nezávislé rozměry. Použijte nastavení velikosti běžných snímků, pokud chcete změnit velikost samotných snímků.

**Proč má výsledek po uložení nebo tisku jinou velikost?**

Nejprve znovu otevřete uloženou prezentaci a porovnejte její rozměry poznámek. Pokud se změnily, ověřte, zda uložení nebo konverze souboru v jiné aplikaci neprovedla změnu nastavení stránky. Pokud ne, zkontrolujte rozvržení exportu, měřítko obrazu, nastavení prohlížeče a výběr papíru tiskárny.