---
title: PDF dokumentumok szerkesztése PHP-ben
linktitle: PDF szerkesztése
type: docs
weight: 65
url: /hu/php-java/edit-pdf/
keywords:
- PDF szerkesztése
- PDF szöveg cseréje
- PDF PPTX-be
- PPTX PDF-be
- PHP
- Aspose.Slides
description: "PDF dokumentumok szerkesztése PHP-ben az Aspose.Slides-be történő importálással, a szöveg cseréjével, majd a módosított bemutató vissza PDF-be mentésével."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java lehetővé teszi a PDF tartalom szerkesztését az oldalak diaként történő importálásával, a bemutató módosításával, majd a visszaexportálással PDF-be. Ez a cikk egy egyszerű szövegcserét mutat be. A bemutató a memóriában marad, így egy köztes PPTX fájl mentése opcionális.

## **Szöveg cseréje PDF-ben**

Használja a [SlideCollection::addFromPdf](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/#addFromPdf) metódust az oldalak importálásához, a [Presentation::replaceText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#replaceText) metódust a szöveg frissítéséhez, és a [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#save) metódust az eredmény exportálásához.

A következő példa feltételezi, hogy az `input.pdf` tartalmazza a „Draft” szót szerkeszthető szövegként az importálás után. A szó helyét a „Final” cseréli, és a `edited.pdf` fájlt hozza létre. Az első dia törlése az importálás előtt megakadályozza a felesleges üres oldal megjelenését a kimenetben. A keresés teljes szavakat egyezik meg ugyanazzal a kis- és nagybetűvel; a `null` azt jelenti, hogy nincs szükség eredmény visszahívásra.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextSearchOptions;

$presentation = new Presentation();
try {
    $presentation->getSlides()->removeAt(0);

    $presentation->getSlides()->addFromPdf("input.pdf");

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);
    $presentation->replaceText("Draft", "Final", $searchOptions, null);

    $presentation->save("edited.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

További lehetőségekért tekintse meg a [Keresés és csere szövege](/slides/hu/php-java/search-and-replace-text/) és a [PowerPoint átalakítása PDF-be](/slides/hu/php-java/convert-powerpoint-to-pdf/) oldalakat.

{{% alert color="info" title="Note" %}}
A szövegcsere az importált szövegre vonatkozik, nem a beolvasott képekben lévő szövegre. A konverzió befolyásolhatja az elrendezést és a formázást, ezért ellenőrizze a kimenetet, különösen akkor, ha a helyettesítő szöveg hosszabb, mint az eredeti.
{{% /alert %}}

## **GYIK**

**Szükséges-e PPTX fájlt menteni a PDF exportálása előtt?**

Nem. Szerkesztheti és exportálhatja ugyanazt a bemutatót a memóriában. A PPTX másolatot csak akkor mentse, ha tovább szeretné szerkeszteni PowerPointban; lásd a [Prezentációk mentése](/slides/hu/php-java/save-presentation/) oldalt.

**Miért maradhat néhány szöveg változatlanul?**

A példa a teljes „Draft” szót pontos kis- és nagybetűkkel egyezik. Képként importált szöveg vagy különálló szövegkeretekre bontott szöveg nem feltétlenül egyezik a kereséssel. Ellenőrizze az importált tartalmat, és állítsa be a keresést a dokumentumához.