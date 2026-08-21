---
title: Operace prezentací s nízkým kódem v JavaScriptu
linktitle: API s nízkým kódem
type: docs
weight: 50
url: /cs/nodejs-java/low-code-presentation-operations/
keywords:
- API pro prezentace s nízkým kódem
- převod prezentace
- sloučení prezentací
- iterace snímků
- iterace tvarů
- iterace textu
- shromažďování tvarů
- komprese prezentace
- odstranění nevyužitých hlavních snímků
- odstranění nevyužitých rozvržených snímků
- komprese vložených fontů
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Použijte low-code API Aspose.Slides v JavaScriptu k převodu a sloučení prezentací, iteraci obsahu, shromažďování tvarů a snížení velikosti prezentace."
---
## **Přehled**

Namespace `aspose.slides` poskytuje statické pomocné třídy pro běžné operace s prezentacemi. Tyto pomocníky zapouzdřují často používané workflow objektového modelu do zaměřených metod, takže můžete převádět nebo slučovat soubory, zpracovávat prvky prezentace, shromažďovat tvary a odstraňovat nevyužitý obsah s menším množstvím kódu.

Pomocníky s nízkým kódem jsou nejužitečnější, když se operace vztahuje na celý soubor nebo prezentaci a výchozí workflow vyhovuje vašim požadavkům. Použijte plný [Aspose.Slides object model](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/), když potřebujete detailní kontrolu nad jednotlivými snímky, hlavními snímky, rozvržením, tvary, nastavením exportu nebo vztahy mezi prvky prezentace.

Následující tabulka shrnuje dostupné pomocníky:

| Nástroj | Použít pro |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/convert/) | Převod prezentace do jiného formátu pomocí přímého volání soubor‑na‑soubor. |
| [Merger](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/merger/) | Kombinování kompletních souborů prezentací stejného formátu. |
| [ForEach](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/) | Spuštění akce pro každý snímek, tvar, odstavec nebo část textu. |
| [Collect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/collect/) | Získání tvarů z celé prezentace pro opakované zpracování nebo analýzu. |
| [Compress](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/) | Odstranění nevyužitých hlavních snímků a rozvržení a snížení vložených fontových dat. |

## **Převod prezentace**

Použijte [Convert.autoByExtension](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/convert/#autoByExtension), když je přípona výstupního souboru dostačující pro výběr formátu exportu. Metoda otevře zdrojovou prezentaci, určí požadovaný formát z výstupní cesty a zapíše výsledek.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

Třída [Convert](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/convert/) také poskytuje dedikované metody pro výstup do PDF, SVG, JPEG, PNG a TIFF. Použijte plný objektový model, když potřebujete před exportem kontrolovat nebo upravovat prezentaci či nakonfigurovat volbu exportu, která není ve vybraném pomocníkovi dostupná. Viz [Convert Presentation](/nodejs-java/convert-presentation/) pro workflow a možnosti specifické pro formát.

## **Sloučení prezentací**

Použijte [Merger.process](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/merger/#process) pro kombinaci kompletních souborů prezentací jedním voláním. Vstupní prezentace musí mít stejný formát souboru.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

Tento pomocník je vhodný, když mají být všechny snímky připojeny do jednoho výsledku bez individuálního výběru nebo přemapování. Použijte plný objektový model, když potřebujete sloučit vybrané snímky, použít cílový hlavní snímek nebo rozvržení, explicitně zachovat sekce nebo sladit různé velikosti snímků. Viz [Merge Presentations](/nodejs-java/merge-presentation/) pro tyto scénáře.

## **Iterace přes prvky prezentace**

Třída [ForEach](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/) volá zpětný volání (callback) pro každý požadovaný typ prvku prezentace. Vyhýbá se vnořeným smyčkám kolekcí a je vhodná pro kontrolu nebo úpravy formátování na úrovni celé prezentace. V Node.js vytvořte implementace rozhraní zpětných volání pomocí `java.newProxy`.

Následující příklad používá [ForEach.slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/#paragraph) a [ForEach.portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/#portion) pro kontrolu odpovídajících prvků:

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

Ve výchozím nastavení zahrnuje průchod tvary a textem v celé prezentaci normální, hlavní a rozvržené snímky. Přetížení s parametrem `includeNotes` mohou také zpracovávat snímky s poznámkami. Použijte přímé smyčky kolekcí, když je důležitý pořadí průchodu, předčasné ukončení, filtrování před voláním zpětného volání nebo podrobná kontrola nad rodičovskými a podřízenými vztahy.

## **Shromažďování tvarů**

Použijte [Collect.shapes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/collect/#shapes), když potřebujete kolekci všech tvarů v prezentaci místo zpětného volání pro každý tvar. To je užitečné, když bude stejná sada filtrována, počítána nebo zpracovávána vícekrát.

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

Použijte místo toho [ForEach.shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/#shape), když může být každý tvar zpracován okamžitě a není potřeba uchovávat shromážděný výsledek.

## **Komprese obsahu prezentace**

Třída [Compress](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/) může odstranit nevyužité strukturové prvky a snížit data vložených fontů:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) odstraňuje rozvržené snímky, na které neodkazuje žádný normální snímek.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) odstraňuje hlavní snímky, které již nejsou používány.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) odstraňuje nevyužité znaky z vložených fontů.

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

Odstraňte nevyužité rozvržení před nevyužitými hlavními snímky, aby hlavní snímek, který se po vyčištění rozvržení stane neodkazovaným, mohl být také odstraněn. Uložte optimalizovanou prezentaci do nového souboru, pokud budete později potřebovat původní hlavní snímky, rozvržení nebo kompletní data vložených fontů. Pro podrobnější informace viz [Slide Master](/nodejs-java/slide-master/) a [Embedded Font](/nodejs-java/embedded-font/).

## **Často kladené otázky**

**Kdy bych měl použít low-code API místo plného objektového modelu?**

Používejte low-code pomocníky, když standardní operace platí pro celý soubor nebo prezentaci a nevyžaduje detailní kontrolu nad jednotlivými prvky. Použijte plný objektový model, když potřebujete vybrat konkrétní snímky, řídit vztahy hlavních snímků a rozvržení, kontrolovat mezičlánek stav nebo nakonfigurovat chování, které pomocník neexponuje.

**Může Merger kombinovat prezentace v různých formátech souborů?**

Ne. [Merger.process](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/merger/#process) vyžaduje, aby vstupní prezentace byly ve stejném formátu. Nejprve převěďte vstupní soubory do společného formátu, například pomocí [Convert.autoByExtension](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/convert/#autoByExtension), a poté sloučte převedené soubory.

**Zpracovává ForEach hlavní, rozvržené a poznámkové snímky?**

[ForEach.slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/#slide) prochází normální snímky prezentace. Operace [ForEach.shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/#paragraph) a [ForEach.portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/#portion) v celé prezentaci zahrnují normální, hlavní a rozvržené snímky ve výchozím nastavení. Použijte jejich přetížení s `includeNotes` nastaveným na `true`, abyste zahrnuli poznámkové snímky.

**Jaký je rozdíl mezi ForEach.shape a Collect.shapes?**

Použijte [ForEach.shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/#shape) k okamžitému zpracování každého tvaru prostřednictvím zpětného volání. Použijte [Collect.shapes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/collect/#shapes), když potřebujete iterovatelný výsledek, který lze uchovat, filtrovat, počítat nebo procházet vícekrát.

**Zmenšuje Compress vždy velikost souboru prezentace?**

Ne nutně. Výsledek závisí na tom, zda prezentace obsahuje nevyužité rozvržení, nevyužité hlavní snímky nebo vložené fonty s nevyužitými znaky. Pokud žádné z nich nejsou přítomny, odpovídající operace [Compress](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/) nemusí zmenšit velikost souboru.

**Ukládají se změny provedené pomocí ForEach nebo Compress automaticky?**

Ne. Tyto pomocníky pracují s načteným objektem [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) v paměti. Po změně prvků ve zpětném volání [ForEach](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/foreach/) nebo po spuštění [Compress](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/) zavolejte [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save) pro zapsání výsledku.

## **Související články**

- [Convert Presentation](/nodejs-java/convert-presentation/)
- [Merge Presentations](/nodejs-java/merge-presentation/)
- [Slide Master](/nodejs-java/slide-master/)
- [Manage Text Box](/nodejs-java/manage-textbox/)
- [Embedded Font](/nodejs-java/embedded-font/)