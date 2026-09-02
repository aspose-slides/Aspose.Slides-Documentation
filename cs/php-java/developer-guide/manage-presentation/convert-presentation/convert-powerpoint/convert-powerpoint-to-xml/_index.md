---
title: Převést prezentace PowerPoint do XML v PHP
linktitle: PowerPoint do XML
type: docs
weight: 145
url: /cs/php-java/convert-powerpoint-to-xml/
keywords:
- převést PowerPoint do XML
- převést prezentaci do XML
- PPT do XML
- PPTX do XML
- ODP do XML
- PowerPoint XML prezentace
- SaveFormat.Xml
- uložit prezentaci jako XML
- exportovat prezentaci do XML
- XML proud
- PHP
- Aspose.Slides
description: "Převést prezentace PowerPoint a OpenDocument do souborů nebo proudů PowerPoint XML v PHP pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Aspose.Slides pro PHP přes Java může převádět prezentace PowerPoint do formátu PowerPoint XML Presentation. Výstup XML je užitečný, když potřebujete textovou reprezentaci pro kontrolu struktury prezentace, odstraňování problémů s vygenerovanými dokumenty, porovnávání výstupu v automatizovaných testech nebo integraci s pracovním tokem, který spotřebovává XML místo balíčku s prezentací.

Použijte metodu [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) s hodnotou `Xml` z výčtu [SaveFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveformat/). Výsledek můžete zapsat přímo do souboru nebo do proudu.

{{% alert color="info" title="Poznámka" %}}
`SaveFormat::Xml` vytváří PowerPoint XML Presentation. Neextrahuje jednotlivé části Office Open XML uložené uvnitř balíčku PPTX. Pokud potřebujete přesné části balíčku PPTX, jako je `ppt/presentation.xml` nebo jednotlivé XML soubory snímků, prozkoumejte samotný balíček PPTX.
{{% /alert %}}

## **Převést prezentaci do XML souboru**

Načtěte zdrojovou prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a poté předávejte výstupní cestu a `SaveFormat::Xml` metodě [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/). Zdroj může být jakýkoli formát prezentace podporovaný pro načítání, například PPT, PPTX nebo ODP.

Následující příklad převádí PPTX prezentaci do XML souboru:

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

## **Zapsat výstup XML do proudu**

Použijte přetížení proudu metody [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/), když XML musí zůstat v paměti nebo být předáno dalšímu komponentu, například webové službě, poskytovateli úložiště nebo XML zpracovatelskému potrubí. Následující příklad zapisuje výsledek do [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) a získává vygenerované XML jako pole bytů:

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

        // Předat $xmlBytes dalšímu komponentu v pracovním toku.
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

`ByteArrayOutputStream` ukládá všechna vygenerovaná data v paměti, takže před voláním `toByteArray` není vyžadováno resetování pozice.

## **Porovnat XML s formáty prezentace a exportu**

Zvolte výstupní formát podle toho, jak bude výsledek použit:

| Formát | Výstup | Typické použití |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | Kontrola struktury, odstraňování problémů, porovnávání vygenerovaného výstupu a integrace založené na XML |
| PPT (`.ppt`) | Starší binární soubor prezentace | Kompatibilita se staršími pracovními postupy PowerPoint |
| PPTX (`.pptx`) | Balíček Office Open XML obsahující více částí | Běžná úprava PowerPoint a výměna prezentací |
| PDF nebo TIFF | Stránky s pevnou rozvržením nebo více‑stránkový obrázek | Prohlížení, tisk a archivace |
| PNG, JPEG nebo SVG | Vykreslená reprezentace jednotlivého snímku | Náhledy, miniatury a grafické soubory |
| HTML nebo HTML5 | Webově orientovaný výstup prezentace | Prohlížení v prohlížeči a publikování na webu |

Na rozdíl od PPT a PPTX je výstup XML primárně určen pro inspekci a datově orientované pracovní toky. Na rozdíl od PDF, TIFF, HTML a formátů obrázků snímků představuje data prezentace místo vykreslení snímků jako stránek nebo vizuálních aktiv. Tabulka [podporované formáty souborů](/slides/cs/php-java/supported-file-formats/) uvádí PowerPoint XML Presentation jako formát pouze pro ukládání, takže jej nepoužívejte, pokud pracovní tok musí načíst exportovaný soubor zpět do Aspose.Slides pro další úpravy.

## **Často kladené otázky**

**Je `SaveFormat::Xml` stejné jako uložení souboru PPTX?**

Ne. PPTX je balíček obsahující více částí Office Open XML, zatímco `SaveFormat::Xml` vytváří soubor PowerPoint XML Presentation.

**Mohu uložit výstup XML bez vytvoření souboru na disku?**

Ano. Předávejte zapisovatelný proud metodě [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/). Například použijte [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) pro zpracování v paměti.

**Může Aspose.Slides načíst exportovaný XML soubor znovu?**

Ne. PowerPoint XML Presentation je v současnosti podporováno pouze pro ukládání, ne pro načítání. Použijte PPTX nebo jiný podporovaný formát prezentace, pokud je vyžadována obousměrná úprava.

**Převádí XML konverze každý snímek jako stránku nebo obrázek?**

Ne. XML konverze zapisuje strukturovaná data prezentace. Pro výstup zaměřený na stránky použijte PDF nebo TIFF, nebo pro jednotlivé snímky PNG, JPEG a SVG.