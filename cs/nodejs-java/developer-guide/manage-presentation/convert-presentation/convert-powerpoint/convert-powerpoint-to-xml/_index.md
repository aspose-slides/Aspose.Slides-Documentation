---
title: Převod prezentací PowerPoint do XML v JavaScriptu
linktitle: PowerPoint do XML
type: docs
weight: 145
url: /cs/nodejs-java/convert-powerpoint-to-xml/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Převádějte prezentace PowerPoint a OpenDocument do souborů nebo proudů PowerPoint XML v JavaScriptu pomocí Aspose.Slides pro Node.js přes Java."
---
## **Přehled**

Aspose.Slides pro Node.js přes Java dokáže převádět prezentace PowerPoint do formátu PowerPoint XML Presentation. Výstup XML je užitečný, když potřebujete textovou reprezentaci pro kontrolu struktury prezentace, odstraňování problémů v generovaných dokumentech, porovnávání výstupu v automatizovaných testech nebo integraci s workflow, který spotřebovává XML místo balíčku prezentace.

Použijte metodu [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save) s hodnotou `Xml` z výčtu [SaveFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveformat/). Výsledek můžete zapsat přímo do souboru nebo do proudu.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` vytváří PowerPoint XML Presentation. Neextrahuje jednotlivé části Office Open XML uložené uvnitř balíčku PPTX. Pokud potřebujete přesné části balíčku PPTX, jako je `ppt/presentation.xml` nebo jednotlivé XML soubory snímků, prohlédněte si samotný balíček PPTX.
{{% /alert %}}

## **Převod prezentace do XML souboru**

Načtěte zdrojovou prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) a poté předávejte cestu k výstupu a `SaveFormat.Xml` metodě [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save). Zdroj může být jakýkoli formát prezentace podporovaný pro načítání, například PPT, PPTX nebo ODP.

Následující příklad převádí PPTX prezentaci do XML souboru:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Zapsání XML výstupu do proudu**

Použijte přetížení proudu metody [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save), když musí XML zůstat v paměti nebo být předáno jiné komponentě, jako je webová služba, úložiště nebo XML zpracovatelská pipeline. Následující příklad zapíše výsledek do Java `ByteArrayOutputStream` a zkopíruje vygenerovaná data do Node.js `Buffer`:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // Předat xmlBuffer dalšímu komponentu ve workflow.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Porovnání XML s formáty prezentace a exportu**

Zvolte výstupní formát podle toho, jak bude výsledek použit:

| Formát | Výstup | Typické použití |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML prezentace | Kontrola struktury, odstraňování problémů, porovnávání generovaného výstupu a integrace založené na XML |
| PPT (`.ppt`) | Starý binární soubor prezentace | Kompatibilita se staršími pracovními postupy PowerPoint |
| PPTX (`.pptx`) | Balíček Office Open XML obsahující více částí | Běžná úprava PowerPoint a výměna prezentací |
| PDF nebo TIFF | Stránky s pevnou velikostí nebo vícestránkový obrázek | Prohlížení, tisk a archivace |
| PNG, JPEG nebo SVG | Vykreslená reprezentace jednotlivého snímku | Náhledy, miniatury a obrazové zdroje |
| HTML nebo HTML5 | Webově orientovaný výstup prezentace | Prohlížení v prohlížeči a webové publikování |

Na rozdíl od PPT a PPTX je výstup XML primárně určen pro kontrolu a datově orientované pracovní postupy. Na rozdíl od PDF, TIFF, HTML a formátů obrázků snímků představuje data prezentace místo vykreslování snímků jako stránek nebo vizuálních aktiv. Tabulka [supported file formats](/slides/cs/nodejs-java/supported-file-formats/) uvádí PowerPoint XML Presentation jako formát jen pro ukládání, takže jej nepoužívejte, když workflow musí načíst exportovaný soubor zpět do Aspose.Slides pro další úpravy.

## **Časté dotazy**

**Je `SaveFormat.Xml` to samé jako ukládání souboru PPTX?**

Ne. PPTX je balíček obsahující více částí Office Open XML, zatímco `SaveFormat.Xml` vytváří soubor PowerPoint XML Presentation.

**Mohu uložit XML výstup bez vytvoření souboru na disku?**

Ano. Předávejte zapisovatelný proud metodě [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save). Například použijte Java `ByteArrayOutputStream` a zkopírujte jeho data do Node.js `Buffer` pro zpracování v paměti.

**Umí Aspose.Slides načíst exportovaný XML soubor znovu?**

Ne. PowerPoint XML Presentation je momentálně podporována pouze pro ukládání, ne pro načítání. Pro zpětnou editaci použijte PPTX nebo jiný podporovaný formát prezentace.

**Převádí konverze XML každý snímek na stránku nebo obrázek?**

Ne. Konverze XML zapisuje strukturovaná data prezentace. Pro výstup orientovaný na stránky použijte PDF nebo TIFF, pro obrázky jednotlivých snímků PNG, JPEG nebo SVG.