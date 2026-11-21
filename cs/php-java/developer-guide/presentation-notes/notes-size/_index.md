---
title: Změna velikosti a orientace stránky poznámek v PHP
linktitle: Velikost stránky poznámek
type: docs
weight: 10
url: /cs/php-java/notes-size/
keywords:
- velikost stránky poznámek
- orientace poznámek
- poznámky na šířku
- poznámky na výšku
- velikost podkladů
- PowerPoint
- prezentace
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Čtěte a měňte rozměry stránky poznámek v Aspose.Slides pro PHP přes Java, přepínejte orientaci, ověřujte uložené velikosti a exportujte poznámky nebo podklady do PDF a obrázků."
---
## **Přehled**

Použijte [Presentation::getNotesSize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/getnotessize/) pro přístup k nastavením stránky poznámek prezentace. Vrací objekt [NotesSize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notessize/), jehož metoda [setSize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notessize/setsize/) nastavuje rozměry stránky. I když objekt nastavení nelze nahradit, můžete pomocí této metody přiřadit nové rozměry.

Šířka a výška jsou zadány v **bodech**, přičemž 72 bodů odpovídá jednomu palci. Například 900 × 600 bodů je 12,5 × 8⅓ palce. Tato nastavení se vztahují k celé prezentaci, nikoli k poznámkám jednotlivého snímku.

| Nastavení | Účel |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/getnotessize/) | Řídí rozměry stránky poznámek a rozměry stránky používané pro export podkladů. |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/getslidesize/) | Řídí rozměry běžných snímků prezentace prostřednictvím [SlideSize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidesize/). |

Změna jednoho nastavení automaticky neovlivní druhé. Změna orientace stránky poznámek také neotáčí běžné snímky. Viz [Slide Size](/slides/cs/php-java/slide-size/) pro změnu velikosti běžných snímků.

Níže uvedené příklady používají existující `sample.pptx`. Pro příklady exportu použijte prezentaci s alespoň jedním snímkem obsahujícím poznámky přednášejícího. Každý příklad lze spustit samostatně po načtení PHP/Java Bridge a obálky Aspose.Slides pro PHP. Číselné hodnoty vrácené z Javy jsou před porovnáním nebo výpočtem převedeny na PHP pomocí `java_values`.

## **Přečtení velikosti a orientace stránky poznámek**

Načtěte šířku a výšku a porovnejte je pro určení orientace: širší stránka je na šířku (landscape), vyšší stránka je na výšku (portrait) a stejné rozměry popisují čtvercovou stránku. Tento příklad vypisuje skutečné rozměry v bodech, aniž by předpokládal standardní velikost papíru.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Přepnutí na krajinu bez změny velikosti papíru**

Pro změnu pouze orientace vyměňte stávající šířku a výšku. Tím se zachová délka obou stran, včetně rozměrů vlastního papíru. Podmínka níže zabraňuje převrácení již krajinové stránky zpět na výšku a ponechává čtvercovou stránku beze změny.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pro orientaci na výšku použijte stejné přiřazení, když `java_values($size->getWidth()) > java_values($size->getHeight())`. Nezahrnujte rozměry A4 nebo Letter, pokud zároveň nechcete změnit velikost papíru.

## **Nastavení a ověření vlastní velikosti stránky poznámek**

Přiřaďte oba rozměry najednou a poté použijte [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/save/) pro zápis prezentace. Tento příklad nastaví krajinovou stránku 900 × 600 bodů, uloží ji jako PPTX a znovu otevře uložený soubor pro kontrolu uložených hodnot. Porovnání umožňuje toleranci 0,01 bodu pro hodnoty s plovoucí řádovou čárkou; není to záruka přesnosti pro každý formát souboru.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Očekávaný výsledek je `900 x 600 points` a `Size preserved: true`. Kontrola nově otevřené prezentace ověřuje uložený soubor, nikoli pouze nastavení v paměti.

## **Export poznámek a podkladů**

Rozměry stránky určují dostupnou oblast pro rozvržení poznámek nebo podkladů. Samy o sobě neaktivují tato rozvržení: je potřeba také nastavit možnosti exportu. Export běžných snímků nadále používá rozměry snímku.

### **Export poznámek do PDF a PNG**

Přiřaďte [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notescommentslayoutingoptions/) k [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) pro zahrnutí poznámek do PDF. Tento příklad také vykreslí první snímek s poznámkami do PNG pomocí [Slide::getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#getImage) a [RenderingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/renderingoptions/).

Režim [BottomTruncated](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notespositions/) ponechává poznámky na jedné stránce; poznámky, které se nevejdou, mohou být oříznuty. PDF používá stránky 900 × 600 bodů. Při měřítku obrazu 1 × 1 použitém níže má PNG rozměry 900 × 600 pixelů. Body popisují geometrii stránky; pixely popisují rastrový výstup, jehož rozměry také závisejí na měřítku vykreslení.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Pro PDF export s dlouhými poznámkami umožňuje [BottomFull](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notespositions/) přidání dalších stránek podle potřeby. Tento režim nepoužívejte s voláním obrázku jednosnímkového výše, které jej nepodporuje. Po změně velikosti zkontrolujte výstup na oříznuté poznámky a umístění existujících objektů master poznámek; samotná změna rozměrů stránky by neměla být považována za záruku, že veškerý obsah bude pasovat. Viz [Convert PowerPoint to PDF with Notes](/slides/cs/php-java/convert-powerpoint-to-pdf-with-notes/) pro více informací o exportu poznámek.

### **Export podkladů do PDF**

Použijte [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/handoutlayoutingoptions/) pro více miniatur snímků na jedné stránce. Následující příklad nastaví stránku 900 × 600 bodů a použije [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/cs/php-java/aspose.slides/handouttype/) k uspořádání až čtyř snímků na stránku. Vodorovná předvolba řídí pořadí snímků; orientace stránky vychází z její šířky a výšky.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Změna velikosti stránky mění oblast dostupnou pro mřížku podkladů, aniž by změnila rozměry zdrojových snímků. Pro obrázky podkladů použijte [Presentation::getImages](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/getimages/) s rozvržením podkladů, místo metody obrázku jednotlivého snímku. V Aspose.Slides se vykreslování podkladů na úrovni prezentace řídí rozměry stránky poznámek, zatímco volání obrázku jednotlivého snímku nevytváří stránku podkladu. Viz [Handout Mode](/slides/cs/php-java/convert-powerpoint-in-handout-mode/) pro možnosti rozvržení.

## **Velikost stránky v prohlížečích, exportu a tisku**

Uchovávejte odděleně uloženou velikost prezentace, exportovanou velikost stránky a tištěnou velikost papíru:

- **Prohlížeče prezentací:** Prohlížeč může zobrazovat nebo tisknout poznámky podle vlastních pravidel rozvržení. Pokud jiná aplikace soubor uloží, otevřete jej znovu a zkontrolujte rozměry; konverze formátu této aplikace je může normalizovat.
- **Exportní formáty:** Příklady PDF s poznámkami a podklady výše používají nakonfigurované rozměry stránky. Rastrové obrázky používají celočíselné rozměry v pixelech a měřítko vykreslení, takže zlomkové hodnoty v bodech mohou být v obrázku zaokrouhleny. Export běžných snímků nepoužívá velikost stránky poznámek.
- **Ovladače tiskáren:** Výběr papíru, automatické otáčení a nastavení „přizpůsobit stránce“ mohou změnit fyzický výstup bez změny rozměrů uložených v prezentaci nebo PDF. Pro konkrétní velikost papíru sladťe nastavení tiskárny a zkontrolujte náhled tisku.

## **Často kladené otázky**

**Mohu nastavit velikost poznámek jen pro jeden snímek?**

Velikost stránky poznámek je nastavením na úrovni celé prezentace. Individuální snímky mohou mít různý obsah poznámek, ale tato vlastnost neposkytuje samostatnou velikost stránky pro každý snímek.

**Proč změna orientace poznámek nezměnila mé snímky?**

Stránky poznámek a běžné snímky mají nezávislé rozměry. Pro změnu velikosti samotných snímků použijte nastavení velikosti snímku.

**Proč má výsledek uložený nebo vytištěný jinou velikost?**

Nejprve znovu otevřete uloženou prezentaci a porovnejte její rozměry poznámek. Pokud se změnily, zkontrolujte, zda uložení nebo konverze souboru v jiné aplikaci neprovedla změnu nastavení stránky. Pokud ne, prověřte rozvržení exportu, měřítko obrázku, nastavení prohlížeče a výběr papíru tiskárny.