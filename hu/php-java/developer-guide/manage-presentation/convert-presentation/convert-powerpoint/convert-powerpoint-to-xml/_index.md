---
title: PowerPoint prezentációk konvertálása XML-be PHP-ben
linktitle: PowerPoint XML-re
type: docs
weight: 145
url: /hu/php-java/convert-powerpoint-to-xml/
keywords:
- PowerPoint konvertálása XML-re
- prezentáció konvertálása XML-re
- PPT XML-re
- PPTX XML-re
- ODP XML-re
- PowerPoint XML prezentáció
- SaveFormat.Xml
- prezentáció mentése XML-ként
- prezentáció exportálása XML-be
- XML adatfolyam
- PHP
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk konvertálása PowerPoint XML fájlokká vagy adatfolyamokká PHP-ben az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java képes PowerPoint-prezentációkat PowerPoint XML Presentation formátumba konvertálni. Az XML kimenet akkor hasznos, ha szöveges ábrázolásra van szükség a prezentáció struktúrájának vizsgálatához, a generált dokumentumok hibakereséséhez, a kimenet automatizált tesztekben történő összehasonlításához, vagy egy olyan munkafolyamatba való integrálásához, amely XML-t fogyaszt a prezentációcsomag helyett.

Használja a [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) metódust a [SaveFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveformat/) felsorolás `Xml` értékével. Az eredményt közvetlenül fájlba vagy egy adatfolyamba (stream) is írhatja.

{{% alert color="info" title="Megjegyzés" %}}
`SaveFormat::Xml` PowerPoint XML Presentation-t hoz létre. Nem bontja ki az egyes Office Open XML részeket, amelyek egy PPTX csomagban tárolódnak. Ha a pontos PPTX csomagrészekre van szüksége, például `ppt/presentation.xml` vagy egyes dia XML fájlokra, vizsgálja meg magát a PPTX csomagot.
{{% /alert %}}

## **Prezentáció konvertálása XML-fájlba**

Töltse be a forrás prezentációt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztállyal, majd adja át a kimeneti útvonalat és a `SaveFormat::Xml` értéket a [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) metódusnak. A forrás bármely, betöltésre támogatott prezentációformátum lehet, például PPT, PPTX vagy ODP.

A következő példa egy PPTX prezentációt XML-fájllá konvertál:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.xml";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Xml);
} finally {
    $presentation->dispose();
}
```

## **XML kimenet írása adatfolyamba**

Használja a [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) adatfolyam túlterhelését, amikor az XML-nek memóriában kell maradnia, vagy egy másik komponensnek kell átadni, például webszolgáltatásnak, tárolási szolgáltatónak vagy XML-feldolgozó csővezetéknek. A következő példa az eredményt egy [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html)-ba írja, és a generált XML-t bájttömbként kapja meg:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$presentation = new Presentation($inputPath);
try {
    $xmlStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $presentation->save($xmlStream, SaveFormat::Xml);
        $xmlBytes = $xmlStream->toByteArray();

        // Adja át a $xmlBytes változót a munkafolyamat következő komponensének.
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

A `ByteArrayOutputStream` az összes generált adatot memóriában tárolja, így a `toByteArray` hívása előtt nincs szükség a pozíció visszaállítására.

## **XML összehasonlítása prezentációval és exportformátumokkal**

Válassza ki a kimeneti formátumot attól függően, hogy hogyan fogják használni az eredményt:

| Formátum | Kimenet | Tipikus használat |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML prezentáció | A struktúra vizsgálata, hibaelhárítás, generált kimenet összehasonlítása és XML-alapú integráció |
| PPT (`.ppt`) | Legacy bináris prezentációfájl | Kompatibilitás a régebbi PowerPoint munkafolyamatokkal |
| PPTX (`.pptx`) | Office Open XML csomag, amely több részt tartalmaz | Rendszeres PowerPoint szerkesztés és prezentációcserék |
| PDF or TIFF | Rögzített elrendezésű oldalak vagy többoldalas kép | Megtekintés, nyomtatás és archiválás |
| PNG, JPEG, or SVG | Egy egyedi dia renderelt ábrázolása | Bélyegképek, előnézetek és képanyagok |
| HTML or HTML5 | Web-orientált prezentáció kimenet | Böngészőben való megtekintés és webes közzététel |

A PPT és PPTX formátumtól eltérően az XML kimenet elsősorban ellenőrzésre és adatközpontú munkafolyamatokra szolgál. A PDF, TIFF, HTML és dia képformátumoktól eltérően a prezentáció adatát ábrázolja, nem pedig a diákat oldalakon vagy vizuális eszközökön jeleníti meg. A [supported file formats](/slides/hu/php-java/supported-file-formats/) táblázat a PowerPoint XML Presentation-t csak mentésre alkalmas formátumként sorolja fel, ezért ne használja, ha a munkafolyamatnak vissza kell töltenie az exportált fájlt az Aspose.Slides-be a folytatólagos szerkesztéshez.

## **GYIK**

**A `SaveFormat::Xml` ugyanaz, mint egy PPTX fájl mentése?**

Nem. A PPTX egy csomag, amely több Office Open XML részt tartalmaz, míg a `SaveFormat::Xml` egy PowerPoint XML Presentation fájlt hoz létre.

**Menthetem az XML kimenetet anélkül, hogy fájlt hoznék létre a lemezen?**

Igen. Adjon át egy írható adatfolyamot a [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) metódusnak. Például használjon [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html)-t a memória-alapú feldolgozáshoz.

**Betöltheti az Aspose.Slides a exportált XML-fájlt újra?**

Nem. A PowerPoint XML Presentation jelenleg csak mentésre támogatott, betöltésre nem. Használjon PPTX-et vagy más támogatott prezentációformátumot, ha körkörös szerkesztésre van szükség.

**Az XML konverzió minden diát oldalra vagy képre renderel?**

Nem. Az XML konverzió strukturált prezentációs adatot ír. Használjon PDF-et vagy TIFF-et oldal-orientált kimenethez, vagy PNG-t, JPEG-et és SVG-t egyedi dia képekhez.