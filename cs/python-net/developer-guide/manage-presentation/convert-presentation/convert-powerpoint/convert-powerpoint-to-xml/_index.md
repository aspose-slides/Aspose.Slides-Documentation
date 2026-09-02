---
title: Převést prezentace PowerPoint do XML v Pythonu
linktitle: PowerPoint do XML
type: docs
weight: 145
url: /cs/python-net/convert-powerpoint-to-xml/
keywords:
- převést PowerPoint do XML
- převést prezentaci do XML
- PPT do XML
- PPTX do XML
- ODP do XML
- PowerPoint XML Presentation
- SaveFormat.XML
- uložit prezentaci jako XML
- exportovat prezentaci do XML
- XML proud
- Python
- Aspose.Slides
description: "Převést prezentace PowerPoint a OpenDocument do souborů nebo proudů PowerPoint XML v Pythonu s Aspose.Slides."
---
## **Přehled**

Aspose.Slides for Python via .NET může převádět prezentace PowerPoint do formátu PowerPoint XML Presentation. Výstup XML je užitečný, když potřebujete textovou reprezentaci pro kontrolu struktury prezentace, řešení problémů s generovanými dokumenty, porovnání výstupu v automatizovaných testech nebo integraci s pracovním tokem, který spotřebovává XML místo balíčku prezentace.

Použijte metodu [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/) s hodnotou `XML` z výčtu [SaveFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/saveformat/). Výsledek můžete zapsat přímo do souboru nebo do proudu.

{{% alert color="info" title="Poznámka" %}}

`SaveFormat.XML` vytváří PowerPoint XML Presentation. Neextrahuje jednotlivé části Office Open XML uložené v balíčku PPTX. Pokud potřebujete přesné části balíčku PPTX, například `ppt/presentation.xml` nebo jednotlivé XML soubory snímků, prohlédněte si samotný balíček PPTX.

{{% /alert %}}

## **Převést prezentaci do XML souboru**

Načtěte zdrojovou prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a poté předávejte cestu k výstupu a `SaveFormat.XML` metodě [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/). Zdroj může být libovolný formát prezentace podporovaný pro načítání, například PPT, PPTX nebo ODP.

Následující příklad převádí prezentaci PPTX do XML souboru:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **Zapsat XML výstup do proudu**

Použijte přetížení proudu metody [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/) když má XML zůstat v paměti nebo být předáno dalšímu komponentu, například webové službě, poskytovateli úložiště nebo zpracovatelskému řetězci XML. Následující příklad zapisuje výsledek do proudu [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) a nastaví jej zpět na začátek pro následné čtení:

```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # Předávejte xml_stream dalšímu komponentu v pracovním postupu.
```

## **Porovnat XML s formáty prezentace a exportu**

Zvolte výstupní formát podle toho, jak bude výsledek použit:

| Formát | Výstup | Typické použití |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | Kontrola struktury, řešení problémů, porovnání generovaného výstupu a integrace založené na XML |
| PPT (`.ppt`) | Starší binární soubor prezentace | Kompatibilita s tradičními pracovními postupy PowerPoint |
| PPTX (`.pptx`) | Balíček Office Open XML obsahující více částí | Běžná úprava PowerPoint a výměna prezentací |
| PDF nebo TIFF | Stránky s pevnou rozložením nebo více stránkový obrázek | Prohlížení, tisk a archivace |
| PNG, JPEG nebo SVG | Vykreslená reprezentace jednotlivého snímku | Náhledy, miniatury a obrazové zdroje |
| HTML nebo HTML5 | Webově orientovaný výstup prezentace | Prohlížení v prohlížeči a publikování na webu |

Na rozdíl od PPT a PPTX je výstup XML primárně určen pro kontrolu a datově orientované pracovní postupy. Na rozdíl od PDF, TIFF, HTML a formátů obrázků snímků představuje XML data prezentace, nikoli vykreslené snímky jako stránky nebo vizuální aktiva. Tabulka [podporované formáty souborů](/slides/cs/python-net/supported-file-formats/) uvádí PowerPoint XML Presentation jako formát pouze pro uložení, takže jej nepoužívejte, pokud pracovní postup musí načíst exportovaný soubor zpět do Aspose.Slides pro další úpravy.

## **Často kladené otázky**

**Je `SaveFormat.XML` totéž jako uložení souboru PPTX?**

Ne. PPTX je balíček obsahující více částí Office Open XML, zatímco `SaveFormat.XML` vytváří soubor PowerPoint XML Presentation.

**Mohu uložit XML výstup bez vytvoření souboru na disku?**

Ano. Předávejte zapisovatelný proud metodě [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/). Například použijte proud [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) pro zpracování v paměti.

**Dokáže Aspose.Slides načíst exportovaný XML soubor znovu?**

Ne. PowerPoint XML Presentation je v současnosti podporováno pouze pro ukládání, nikoli pro načítání. Použijte PPTX nebo jiný podporovaný formát prezentace, když je požadována obousměrná úprava.

**Převádí XML konverze každý snímek na stránku nebo obrázek?**

Ne. XML konverze zapisuje strukturovaná data prezentace. Pro výstup orientovaný na stránky použijte PDF nebo TIFF, pro obrázky jednotlivých snímků PNG, JPEG a SVG.