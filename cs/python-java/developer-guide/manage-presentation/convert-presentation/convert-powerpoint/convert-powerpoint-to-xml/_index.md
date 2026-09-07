---
title: Převod prezentací PowerPoint do XML v Pythonu přes Java
linktitle: PowerPoint do XML
type: docs
weight: 145
url: /cs/python-java/convert-powerpoint-to-xml/
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
- Python
- Java
- Aspose.Slides
description: "Převádějte prezentace PowerPoint a OpenDocument na soubory nebo proudy PowerPoint XML v Pythonu přes Java pomocí Aspose.Slides pro Python přes Java."
---
## **Přehled**

Aspose.Slides pro Python přes Java dokáže převádět prezentace PowerPoint do formátu PowerPoint XML Presentation. Výstup XML je užitečný, když potřebujete textovou reprezentaci pro kontrolu struktury prezentace, řešení problémů s vygenerovanými dokumenty, porovnávání výstupu v automatizovaných testech nebo integraci s pracovním tokem, který spotřebovává XML místo balíčku s prezentací.

Použijte metodu [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) s hodnotou [Xml](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Xml) ze třídy [SaveFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/) . Výsledek můžete zapsat přímo do souboru nebo do proudu.

{{% alert color="info" title="Note" %}}

[SaveFormat.Xml](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Xml) vytváří PowerPoint XML Presentation. Neextrahuje jednotlivé části Office Open XML uložené uvnitř balíčku PPTX. Pokud potřebujete přesné části balíčku PPTX, jako je `ppt/presentation.xml` nebo jednotlivé XML soubory snímků, prohlédněte si samotný balíček PPTX.

{{% /alert %}}

## **Převést prezentaci na soubor XML**

Načtěte zdrojovou prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a poté předávejte cestu k výstupu a [SaveFormat.Xml](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Xml) metodě [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save). Zdroj může být jakýkoli formát prezentace podporovaný při načítání, například PPT, PPTX nebo ODP.

Následující příklad převádí prezentaci PPTX na soubor XML:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **Zapsat výstup XML do proudu**

Použijte přetížení pro proud u [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save), když musí XML zůstat v paměti nebo být předáno jinému komponentu, například webové službě, poskytovateli úložiště nebo zpracovatelskému řetězci XML. Následující příklad zapisuje výsledek do [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) a získá výsledné XML jako objekt Python bytes:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # Předejte xml_data dalšímu komponentu v pracovním postupu.
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **Porovnat XML s formáty prezentací a exportu**

Vyberte výstupní formát podle toho, jak bude výsledek používán:

| Formát | Výstup | Typické použití |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML prezentace | Kontrola struktury, řešení problémů, porovnání vygenerovaného výstupu a integrace založená na XML |
| PPT (`.ppt`) | Starý binární soubor prezentace | Kompatibilita se staršími pracovními postupy PowerPoint |
| PPTX (`.pptx`) | Balíček Office Open XML obsahující více částí | Běžná úprava PowerPointu a výměna prezentací |
| PDF nebo TIFF | Stránky s pevnou rozlohou nebo vícestrážný obrázek | Prohlížení, tisk a archivace |
| PNG, JPEG nebo SVG | Vykreslená reprezentace jednotlivého snímku | Náhledy, miniatury a obrázkové zdroje |
| HTML nebo HTML5 | Webově orientovaný výstup prezentace | Prohlížení v prohlížeči a publikování na webu |

Na rozdíl od PPT a PPTX je výstup XML primárně určen pro inspekci a datově orientované pracovní postupy. Na rozdíl od PDF, TIFF, HTML a formátů obrázků snímků představuje data prezentace místo vykreslování snímků jako stránek nebo vizuálních aktiv. Tabulka [podporované formáty souborů](/slides/cs/python-java/supported-file-formats/) uvádí PowerPoint XML Presentation jako formát pouze pro ukládání, takže jej nepoužívejte, pokud pracovní postup vyžaduje načtení exportovaného souboru zpět do Aspose.Slides pro další úpravy.

## **Často kladené otázky**

**Je export XML stejný jako uložení souboru PPTX?**

Ne. PPTX je balíček obsahující více částí Office Open XML, zatímco [SaveFormat.Xml](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Xml) vytváří soubor PowerPoint XML Presentation.

**Mohu uložit výstup XML bez vytvoření souboru na disku?**

Ano. Předávejte zapisovatelný Java výstupní proud metodě [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save). Například použijte [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) pro zpracování v paměti.

**Může Aspose.Slides načíst exportovaný soubor XML znovu?**

Ne. PowerPoint XML Presentation je v současnosti podporována pouze pro ukládání, nikoli pro načítání. Použijte PPTX nebo jiný podporovaný formát prezentace, pokud je vyžadována zpětná úprava.

**Vykresluje konverze XML každý snímek jako stránku nebo obrázek?**

Ne. Konverze XML zapisuje strukturovaná data prezentace. Pro výstup orientovaný na stránky použijte PDF nebo TIFF, nebo pro jednotlivé snímky PNG, JPEG a SVG.