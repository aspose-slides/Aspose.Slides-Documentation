---
title: Operace prezentace s nízkým kódem v JavaScriptu
linktitle: API s nízkým kódem
type: docs
weight: 50
url: /cs/nodejs-java/low-code-presentation-operations/
keywords:
- API prezentace s nízkým kódem
- převod prezentace
- sloučení prezentací
- iterace snímků
- iterace tvarů
- iterace textu
- sběr tvarů
- komprese prezentace
- odstranění nepoužitých master snímků
- odstranění nepoužitých layout snímků
- komprese vložených fontů
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Použijte nízkokódové API Aspose.Slides v JavaScriptu k převodu a sloučení prezentací, iteraci obsahu, sběru tvarů a zmenšení velikosti prezentace."
---
## **Přehled**

Namespace `aspose.slides` poskytuje statické pomocné třídy pro běžné operace s prezentacemi. Tyto pomocníky zapouzdřují často používané pracovní postupy objektového modelu do cílených metod, takže můžete převádět nebo slučovat soubory, zpracovávat prvky prezentace, sbírat tvary a odstraňovat nepoužitý obsah s méně kódem.

Pomocníky s nízkým kódem jsou nejužitečnější, když se operace vztahuje na celý soubor nebo prezentaci a výchozí pracovní postup vyhovuje vašim požadavkům. Použijte úplný [Aspose.Slides object model](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/), pokud potřebujete detailní kontrolu nad jednotlivými snímky, mastery, rozvrženími, tvary, nastaveními exportu nebo vztahy mezi prvky prezentace.

Následující tabulka shrnuje dostupné pomocníky:

| Pomocník | K čemu |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/convert/) | Převádění prezentace do jiného formátu pomocí přímého volání soubor na soubor. |
| [Merger](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/merger/) | Kombinování kompletních souborů prezentací ve stejném formátu. |
| [ForEach](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/) | Spouštění akce pro každý snímek, tvar, odstavec nebo část textu. |
| [Collect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/collect/) | Načtení tvarů z celé prezentace pro opakované zpracování nebo analýzu. |
| [Compress](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/) | Odstranění nepoužitých masterů a rozvržení a snížení vložených dat fontů. |

## **Převod prezentace**

Použijte [Convert.autoByExtension](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/convert/#autoByExtension), když je přípona výstupního souboru dostačující pro výběr formátu exportu. Metoda otevře zdrojovou prezentaci, určí požadovaný formát z výstupní cesty a zapíše výsledek.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

Třída [Convert](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/convert/) také poskytuje dedikované metody pro výstup do PDF, SVG, JPEG, PNG a TIFF. Použijte úplný objektový model, pokud potřebujete před exportem prozkoumat nebo upravit prezentaci nebo nakonfigurovat volbu exportu, která není vybraným pomocníkem zpřístupněna. Viz [Convert Presentation](/slides/cs/nodejs-java/convert-presentation/) pro pracovní postupy a možnosti specifické pro formát.

## **Sloučení prezentací**

Použijte [Merger.process](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/merger/#process) pro kombinaci kompletních souborů prezentací jedním voláním. Vstupní prezentace musí mít stejný formát souboru.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

Tento pomocník je vhodný, když mají být všechny snímky připojeny do jednoho výsledku bez individuálního výběru nebo přemapování. Použijte úplný objektový model, pokud potřebujete sloučit vybrané snímky, použít cílový master nebo rozvržení, explicitně zachovat sekce nebo sladit různé velikosti snímků. Viz [Merge Presentations](/slides/cs/nodejs-java/merge-presentation/) pro tyto scénáře.

## **Iterace přes prvky prezentace**

Třída [ForEach](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/) volá zpětnou funkci pro každý požadovaný typ prvku prezentace. Vyhýbá se vnořeným smyčkám kolekcí a je vhodná pro prohlížení nebo změny formátování v celé prezentaci. V Node.js vytvořte implementace rozhraní zpětné funkce pomocí `java.newProxy`.

Následující příklad používá [ForEach.slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/#paragraph) a [ForEach.portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/#portion) k prozkoumání odpovídajících prvků:

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

Ve výchozím nastavení procházení tvarů a textu v celé prezentaci zahrnuje normální, master a layout snímky. Přetížení s parametrem `includeNotes` mohou také zpracovávat snímky s poznámkami. Použijte přímé smyčky kolekcí, když je důležitý pořadí procházení, předčasný výstup, filtrování před voláním zpětné funkce nebo podrobná kontrola nad rodičovským a potomkovým vztahem.

## **Sbírání tvarů**

Použijte [Collect.shapes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/collect/#shapes), pokud potřebujete kolekci všech tvarů v prezentaci místo zpětné funkce pro každý tvar. To je užitečné, když bude stejná množina filtrována, počítána nebo zpracovávána vícekrát.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

Použijte místo toho [ForEach.shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/#shape), když může být každý tvar zpracován okamžitě a není potřeba uchovávat získaný výsledek.

## **Komprese obsahu prezentace**

Třída [Compress](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/) může odstranit nepoužité strukturační prvky a snížit vložená data fontů:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) odstraňuje layout snímky, na které neodkazuje žádný normální snímek.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) odstraňuje master snímky, které již nejsou použity.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) odstraňuje nepoužité znaky z vložených fontů.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Odstraňte nepoužité rozvržení před nepoužitými mastery, aby master, který se po úklidu rozvržení stane nepoužívaným, mohl být také odstraněn. Uložte optimalizovanou prezentaci do nového souboru, pokud později budete potřebovat původní mastery, rozvržení nebo kompletní vložená data fontů. Pro podrobnější informace viz [Slide Master](/slides/cs/nodejs-java/slide-master/) a [Embedded Font](/slides/cs/nodejs-java/embedded-font/).

## **FAQ**

**Kdy bych měl použít API s nízkým kódem místo úplného objektového modelu?**

Používejte pomocníky s nízkým kódem, když se standardní operace vztahuje na celý soubor nebo prezentaci a nevyžaduje detailní kontrolu nad jednotlivými prvky. Použijte úplný objektový model, pokud potřebujete vybrat konkrétní snímky, řídit vztahy mezi mastery a rozvržením, prozkoumat mezistav nebo nakonfigurovat chování, které pomocník neumožňuje.

**Může Merger kombinovat prezentace v různých formátech souborů?**

Ne. [Merger.process](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/merger/#process) vyžaduje vstupní prezentace ve stejném formátu. Nejprve převěďte vstupní soubory do společného formátu, například pomocí [Convert.autoByExtension](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/convert/#autoByExtension), a poté sloučte převedené soubory.

**Zpracovává ForEach master, layout a poznámkové snímky?**

[ForEach.slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/#slide) prochází normální snímky prezentace. Operace [ForEach.shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/#paragraph) a [ForEach.portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/#portion) na úrovni celé prezentace zahrnují normální, master a layout snímky ve výchozím nastavení. Použijte jejich přetížení s `includeNotes` nastaveným na `true`, abyste zahrnuli poznámkové snímky.

**Jaký je rozdíl mezi ForEach.shape a Collect.shapes?**

Použijte [ForEach.shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/#shape) k okamžitému zpracování každého tvaru pomocí zpětné funkce. Použijte [Collect.shapes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/collect/#shapes), když potřebujete iterovatelný výsledek, který lze uchovat, filtrovat, počítat nebo procházet vícekrát.

**Zmenšuje Compress vždy soubor prezentace?**

Ne nutně. Výsledek závisí na tom, zda prezentace obsahuje nepoužité rozvržení, nepoužité mastery nebo vložené fonty s nepoužitými znaky. Pokud žádné z nich nejsou přítomny, odpovídající operace [Compress](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/) nemusí zmenšit velikost souboru.

**Ukládají se změny provedené pomocí ForEach nebo Compress automaticky?**

Ne. Tito pomocníci pracují s načteným objektem [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) v paměti. Po změně prvků v zpětné funkci [ForEach](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/) nebo po spuštění [Compress](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/) zavolejte [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save), aby se výsledek zapsal.

## **Související články**

- [Převod prezentace](/slides/cs/nodejs-java/convert-presentation/)
- [Sloučení prezentací](/slides/cs/nodejs-java/merge-presentation/)
- [Slide Master](/slides/cs/nodejs-java/slide-master/)
- [Správa textového pole](/slides/cs/nodejs-java/manage-textbox/)
- [Embedded Font](/slides/cs/nodejs-java/embedded-font/)