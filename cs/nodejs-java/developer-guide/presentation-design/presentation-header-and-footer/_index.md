---
title: Spravovat záhlaví a zápatí prezentace v JavaScriptu
linktitle: Záhlaví a zápatí
type: docs
weight: 140
url: /cs/nodejs-java/presentation-header-and-footer/
keywords:
- záhlaví
- text záhlaví
- zápatí
- text zápatí
- nastavit záhlaví
- nastavit zápatí
- předklad
- poznámky
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak spravovat zástupné symboly zápatí, datum-čas, číslo snímku a záhlaví na snímcích, stránkách poznámek a předkladech pomocí Aspose.Slides pro Node.js prostřednictvím Javy."
---
## **Přehled**

PowerPoint používá různé zástupné symboly záhlaví a zápatí v závislosti na typu stránky. Aspose.Slides for Node.js via Java vám umožňuje řídit text a viditelnost těchto zástupných symbolů pomocí tříd správce záhlaví/zápatí.

Dostupné zástupné symboly závisí na rozsahu:

| Rozsah | Záhlaví | Zápatí | Datum/čas | Číslo snímku/stránky |
|---|---|---|---|---|
| Obyčejný snímek | Ne | Ano | Ano | Ano |
| Mistr poznámek | Ano | Ano | Ano | Ano |
| Snímek poznámek | Ano | Ano | Ano | Ano |
| Mistr předkladů | Ano | Ano | Ano | Ano |

Obyčejný snímek prezentace nemá zástupný symbol záhlaví. Záhlaví jsou k dispozici na stránkách poznámek a předkladů. Pro obyčejné snímky použijte místo záhlaví zástupné symboly zápatí, datum/čas a číslo snímku.

Rozsah změny závisí na správci, který používáte. Třída [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideheaderfootermanager/) řídí jeden obyčejný snímek. Třída [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notesslideheaderfootermanager/) řídí jeden snímek poznámek. Správci mistra a rozvržení mohou také propagovat nastavení na podřízené snímky, zatímco třída [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) řídí mistr předkladů.

## **Nastavení zápatí, data/času a číslování snímků na obyčejných snímcích**

U obyčejných snímků je základní postup přistupovat k správci záhlaví/zápatí každého snímku, nastavit text zápatí a data/času, povolit požadované zástupné symboly a uložit prezentaci. Čísla snímků generuje prezentace, takže je třeba řídit pouze jejich viditelnost.

Použijte [`setFooterText`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) a [`setDateTimeText`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) k nastavení textu a použijte [`setFooterVisibility`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [`setDateTimeVisibility`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) a [`setSlideNumberVisibility`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) k zobrazení příslušných zástupných symbolů.

Následující příklad kompletně aplikuje stejný text zápatí, data/času a viditelnost čísla snímku na všechny obyčejné snímky:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pokud potřebujete aktualizovat pouze jeden snímek, přistupte k němu přímo pomocí metody [`getSlides`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getslides/) místo iterace celého seznamu.

## **Nastavení záhlaví a zápatí na mistru poznámek**

Mistr poznámek určuje společné formátování a chování zástupných symbolů na stránkách poznámek. Použijte třídu [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) pokud chcete měnit pouze samotný mistr poznámek.

Následující příklad nastaví záhlaví, zápatí a text data/času na mistr poznámek a zobrazí všechny podporované zástupné symboly na tomto mistru:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metoda [`getMasterNotesSlide`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) vrací `null`, pokud prezentace neobsahuje mistr poznámek.

## **Aplikace nastavení mistra poznámek na podřízené snímky poznámek**

Mistr poznámek může aplikovat nastavení záhlaví a zápatí na sebe i na všechny podřízené snímky poznámek. Použijte vyhrazené metody propagace na [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) když mají být stejná nastavení použita napříč hierarchií poznámek.

Například metody [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) a [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) aktualizují záhlaví mistra poznámek a všech podřízených záhlaví. Ekvivalentní metody jsou k dispozici pro zápatí, datum/čas a čísla snímků.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metody propagace použité výše jsou [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) a [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Nastavení záhlaví a zápatí na jednotlivém snímku poznámek**

Snímek poznámek patří k určitému obyčejnému snímku. Použijte jeho třídu [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notesslideheaderfootermanager/) pokud chcete přizpůsobit pouze tuto stránku poznámek.

Metoda [`addNotesSlide`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) vrací snímek poznámek pro aktuální snímek a vytvoří jej, pokud ještě neexistuje. Následující příklad konfiguruje stránku poznámek spojenou s prvním snímkem prezentace:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const headerFooterManager = slide.getNotesSlideManager().addNotesSlide().getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pokud nejprve propagujete nastavení z mistra poznámek a následně změníte konkrétní snímek poznámek, pozdější nastavení na úrovni snímku vám umožní tuto stránku poznámek přizpůsobit nezávisle.

## **Nastavení záhlaví a zápatí na mistru předkladů**

Stránky předkladů používají mistr předkladů pro své zástupné symboly záhlaví, zápatí, datum/čas a číslo stránky. Na rozdíl od stránek poznámek jsou nastavení předkladů řízena přes mistr předkladů, nikoli přes jednotlivé snímky předkladů.

Použijte [`getMasterHandoutSlide`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide) k přístupu k mistru předkladů. Pokud není přítomen, zavolejte [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) pro vytvoření výchozího mistra předkladů.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    let masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide === null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide !== null) {
        const headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Porozumění rozsahu a dědičnosti**

Zvolte správce záhlaví/zápatí, který odpovídá rozsahu, který chcete změnit:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideheaderfootermanager/) mění nastavení zápatí, datum/čas a číslo snímku pro jeden obyčejný snímek.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) řídí snímek rozvržení a může propagovat podporovaná nastavení na podřízené snímky.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslideheaderfootermanager/) řídí běžný mistr snímků a může propagovat podporovaná nastavení na podřízené snímky.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) řídí mistr poznámek a může propagovat nastavení na všechny podřízené snímky poznámek.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notesslideheaderfootermanager/) mění jeden snímek poznámek a podporuje zástupný symbol záhlaví kromě zápatí, datum/čas a čísla snímku.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) mění mistr předkladů a podporuje všechny čtyři typy zástupných symbolů.

Používejte propagaci z mistra nebo rozvržení, když má být stejné nastavení použito v celé hierarchii. Používejte individuální správce snímku nebo poznámkového snímku, když potřebujete lokální nastavení pro jedinou stránku.

## **Často kladené otázky**

**Mohu přidat záhlaví k obyčejnému snímku?**

Ne. PowerPoint nedefinuje zástupný symbol záhlaví pro obyčejné snímky. Na obyčejných snímcích použijte zástupné symboly zápatí, datum/čas a číslo snímku. Zástupné symboly záhlaví jsou k dispozici na stránkách poznámek a předkladů.

**Co když není zástupný symbol zápatí, datum/čas nebo číslo snímku viditelný?**

Použijte odpovídající správce záhlaví/zápatí k ověření jeho viditelnosti a povolení podle potřeby. Například metoda [`isFooterVisible`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) udává, zda je zástupný symbol zápatí přítomen, a metoda [`setFooterVisibility`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) mění jeho viditelnost.

**Jak mohu začít číslovat snímky od hodnoty jiné než 1?**

Zavolejte metodu prezentace [`setFirstSlideNumber`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/setfirstslidenumber/). Zástupné symboly čísla snímku pak použijí aktualizovanou číselnou sekvenci.

**Co se stane se záhlavími a zápatími při exportu do PDF, obrázků nebo HTML?**

Viditelné prvky záhlaví a zápatí jsou vykresleny spolu se zbytkem obsahu prezentace ve výstupním formátu. Jejich vzhled závisí na typu stránky, která se exportuje, a na nastaveních viditelnosti příslušných zástupných symbolů.