---
title: Správa záhlaví a zápatí prezentace v PHP
linktitle: Záhlaví a zápatí
type: docs
weight: 140
url: /cs/php-java/presentation-header-and-footer/
keywords:
- záhlaví
- text záhlaví
- zápatí
- text zápatí
- nastavit záhlaví
- nastavit zápatí
- podklad
- poznámky
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Zjistěte, jak spravovat zástupce zápatí, datum‑čas, číslo snímku a záhlaví na snímcích, stránkách poznámek a podkladech pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

PowerPoint používá různé zástupce záhlaví a zápatí v závislosti na typu stránky. Aspose.Slides pro PHP přes Java vám umožňuje řídit text a viditelnost těchto zástupců pomocí tříd správců záhlaví/zápatí.

Dostupní zástupci závisí na rozsahu:

| Rozsah | Záhlaví | Zápatí | Datum/čas | Číslo snímku/stránky |
|---|---|---|---|---|
| Běžný snímek | Ne | Ano | Ano | Ano |
| Mistr poznámek | Ano | Ano | Ano | Ano |
| Poznámkový snímek | Ano | Ano | Ano | Ano |
| Mistr podkladů | Ano | Ano | Ano | Ano |

Běžný snímek prezentace nemá zástupce záhlaví. Záhlaví jsou k dispozici na stránkách poznámek a podkladech. Pro běžné snímky použijte místo toho zástupce zápatí, datum/čas a číslo snímku.

Rozsah změny závisí na použitém správci. Třída [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideheaderfootermanager/) ovládá jeden běžný snímek. Třída [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notesslideheaderfootermanager/) ovládá jeden snímek poznámek. Správci mistra a rozvržení mohou také šířit nastavení na podřízené snímky, zatímco třída [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) ovládá mistr podkladů.

## **Nastavení zápatí, data/času a čísel snímků na běžných snímcích**

Pro běžné snímky je základní postup přistoupit ke správci záhlaví/zápatí každého snímku, nastavit text zápatí a data/času, povolit požadované zástupce a uložit prezentaci. Čísla snímků generuje prezentace, takže je potřeba řídit pouze jejich viditelnost.

Použijte [`setFooterText`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/) a [`setDateTimeText`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) pro nastavení textu a použijte [`setFooterVisibility`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`setDateTimeVisibility`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) a [`setSlideNumberVisibility`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) pro zobrazení odpovídajících zástupců.

Následující kompletní příklad použije stejný text zápatí, data/času a viditelnost čísla snímku na všechny běžné snímky:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pokud potřebujete aktualizovat pouze jeden snímek, přistupte k tomuto snímku přímo přes metodu [`getSlides`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/getslides/) místo iterace celého kolekce.

## **Nastavení záhlaví a zápatí na Mistru poznámek**

Mistr poznámek definuje společné formátování a chování zástupců pro stránky poznámek. Použijte třídu [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masternotesslideheaderfootermanager/) když chcete změnit jen samotný mistr poznámek.

Následující příklad nastaví záhlaví, zápatí a text data/času na mistru poznámek a učiní všechny podporované zástupce viditelnými na tomto mistru:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Metoda [`getMasterNotesSlide`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/) vrací `null`, pokud prezentace neobsahuje mistr poznámek.

## **Použití nastavení mistra poznámek na podřízené snímky poznámek**

Mistr poznámek může aplikovat nastavení záhlaví a zápatí na sebe i na všechny podřízené snímky poznámek. Použijte vyhrazené metody šíření na [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masternotesslideheaderfootermanager/), když mají být stejná nastavení použita napříč hierarchií poznámek.

Například metody [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) a [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) aktualizují záhlaví mistra poznámek a všech podřízených záhlaví. Ekvalentní metody jsou k dispozici pro zápatí, datum/čas a čísla snímků.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Metody šíření použité výše jsou [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) a [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Nastavení záhlaví a zápatí na jednotlivém snímku poznámek**

Snímek poznámek patří konkrétnímu běžnému snímku. Použijte jeho třídu [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notesslideheaderfootermanager/), když chcete přizpůsobit jen tuto stránku poznámek.

Metoda [`addNotesSlide`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notesslidemanager/addnotesslide/) vrací snímek poznámek pro aktuální snímek a vytvoří jej, pokud ještě neexistuje. Následující příklad konfiguruje stránku poznámek přidruženou k prvnímu snímku prezentace:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pokud nejprve propagujete nastavení z mistra poznámek a pak změníte jednotlivý snímek poznámek, pozdější nastavení konkrétního snímku vám umožní přizpůsobit tuto stránku poznámek nezávisle.

## **Nastavení záhlaví a zápatí na Mistru podkladů**

Stránky podkladů používají mistr podkladů pro své zástupce záhlaví, zápatí, datum/čas a číslo stránky. Na rozdíl od stránek poznámek jsou nastavení podkladů spravována skrze mistr podkladů, nikoli skrze jednotlivé snímky podkladů.

Použijte metodu [`getMasterHandoutSlide`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/) pro přístup k mistru podkladů. Pokud není přítomen, zavolejte [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) pro vytvoření výchozího mistra podkladů.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Porozumění rozsahu a dědičnosti**

Vyberte správce záhlaví/zápatí, který odpovídá rozsahu, který chcete změnit:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideheaderfootermanager/) mění nastavení zápatí, datum/čas a čísla snímku pro jeden běžný snímek.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslideheaderfootermanager/) ovládá snímek rozvržení a může šířit podporovaná nastavení na podřízené snímky.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslideheaderfootermanager/) ovládá běžný mistr snímků a může šířit podporovaná nastavení na podřízené snímky.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masternotesslideheaderfootermanager/) ovládá mistr poznámek a může šířit nastavení na všechny podřízené snímky poznámek.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notesslideheaderfootermanager/) mění jeden snímek poznámek a podporuje zástupce záhlaví kromě zápatí, datum/čas a čísla snímku.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) mění mistr podkladů a podporuje všechny čtyři typy zástupců.

Použijte šíření z mistra nebo rozvržení, když má stejné nastavení platit v celé hierarchii. Použijte individuální správce snímku nebo snímku poznámek, když potřebujete místní nastavení pro jednu stránku.

## **Často kladené otázky**

**Mohu přidat záhlaví na běžný snímek?**

Ne. PowerPoint nedefinuje zástupce záhlaví pro běžné snímky. Na běžných snímcích použijte zástupce zápatí, datum/čas a číslo snímku. Zástupci záhlaví jsou k dispozici na stránkách poznámek a podkladech.

**Co když zástupce zápatí, datum/čas nebo čísla snímku není viditelný?**

Použijte odpovídajícího správce záhlaví/zápatí k ověření jeho viditelnosti a povolení podle potřeby. Například metoda [`isFooterVisible`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) uvádí, zda je zástupce zápatí přítomen, a metoda [`setFooterVisibility`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) mění jeho viditelnost.

**Jak mohu začít číslovat snímky od hodnoty jiného než 1?**

Zavolejte metodu prezentace [`setFirstSlideNumber`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/setfirstslidenumber/). Zástupci čísla snímku pak použijí aktualizovanou číselnou sekvenci.

**Co se stane se záhlavími a zápatími při exportu do PDF, obrázků nebo HTML?**

Viditelné prvky záhlaví a zápatí jsou vykresleny spolu se zbytkem obsahu prezentace ve výstupním formátu. Jejich vzhled závisí na typu stránky, která je exportována, a na odpovídajících nastaveních viditelnosti zástupců.