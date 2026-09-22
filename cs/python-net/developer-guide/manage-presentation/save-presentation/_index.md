---
title: Ukládání prezentací v Pythonu
linktitle: Uložit prezentaci
type: docs
weight: 80
url: /cs/python-net/save-presentation/
keywords:
- uložit PowerPoint
- uložit OpenDocument
- uložit prezentaci
- uložit snímek
- uložit PPT
- uložit PPTX
- uložit ODP
- prezentace do souboru
- prezentace do proudu
- předdefinovaný typ zobrazení
- Striktní formát Office Open XML
- režim Zip64
- obnovení náhledu
- průběh ukládání
- Python
- Aspose.Slides
description: "Uložte prezentace PowerPoint a OpenDocument do souborů nebo proudů v Pythonu s Aspose.Slides a nakonfigurujte možnosti výstupu PPTX."
---
## **Přehled**

Po vytvoření prezentace nebo [otevření existující](/slides/cs/python-net/open-presentation/), použijte metodu [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ipresentation/save/) k zápisu výsledku. Aspose.Slides pro Python via .NET může uložit prezentaci do souboru nebo proudu ve formátech PowerPoint, OpenDocument, PDF a dalších. Následující sekce popisují standardní operace ukládání a možnosti dostupné pro výstup PPTX.

## **Ukládání prezentací do souborů**

Pro uložení prezentace do souboru předáte metodě [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ipresentation/save/) cestu k výstupu a hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/saveformat/). Hodnota formátu určuje typ souboru, který Aspose.Slides vytvoří.

Následující příklad vytvoří prezentaci a uloží ji jako soubor PPTX:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Přidejte nebo upravte obsah prezentace zde.

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ukládání prezentací v jejich původním formátu**

Pro příklady detekce souborů a proudů, chování nově vytvořených prezentací a rozdíl mezi zdrojovým a výstupním formátem viz [Determine the Original Presentation Format](/slides/cs/python-net/detect-presentation-source-format/).

V aplikaci pro dávkové zpracování nemusí být vstupní formát znám předem. Po načtení souboru přečtěte jeho původní formát z vlastnosti [Presentation.source_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/source_format/). Předáte vzniklou hodnotu [SourceFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sourceformat/) metodě [SlideUtil.to_save_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides.util/slideutil/to_save_format/), abyste získali odpovídající hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/saveformat/), a poté použijte [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ipresentation/save/) k zápisu upravené prezentace.

Následující úplný příklad zpracuje každý soubor ve vstupním adresáři, aktualizuje jeho název a uloží jej do výstupního adresáře ve formátu, ze kterého byl načten:

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides.util/slideutil/to_save_format/) mapuje PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP a PowerPoint XML na jejich odpovídající formáty pro ukládání prezentací. Mapuje pouze zdrojové formáty prezentací; není určeno k výběru exportních formátů jako PDF, HTML, TIFF nebo obrázky. Předání nepodporované nebo neplatné hodnoty [SourceFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sourceformat/) vyvolá výjimku.

Legacy PPT, PPS a POT soubory používají stejný binární kontejner. Když je taková prezentace načtena z proudu bez přípony souboru, může být PPS nebo POT soubor identifikován jako PPT. Pokud je vyžadováno zachování těchto starších podtypů, uchovejte původní název souboru nebo metadata formátu odděleně a použijte je při volbě výstupního názvu souboru a formátu.

## **Ukládání prezentací do proudů**

Pro zápis prezentace bez použití konečné cesty k souboru předáte zapisovatelný proud [BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO) a hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/saveformat/) metodě [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ipresentation/save/). Tento přístup je užitečný, když výstup musí být vrácen z webové služby, uložen v databázi nebo zpracován v paměti.

Následující příklad uloží novou prezentaci do souborového proudu:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **Ukládání prezentací s předdefinovaným typem zobrazení**

Můžete určit zobrazení, ve kterém PowerPoint při otevření uložené prezentace nejprve zobrazí. Před uložením nastavte vlastnost [ViewProperties.last_view](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/last_view/) na hodnotu [ViewType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewtype/).

Následující příklad nastaví zobrazení Slide Master jako počáteční zobrazení:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **Ukládání prezentací ve striktním formátu Office Open XML**

Pro vytvoření souboru PPTX, který odpovídá striktnímu profilu Office Open XML, vytvořte instanci [PptxOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/pptxoptions/) a nastavte její vlastnost [conformance](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/pptxoptions/conformance/) na `Conformance.ISO_29500_2008_STRICT`. Poté předáte možnosti metodě [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ipresentation/save/).

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Ukládání prezentací v formátu Office Open XML v režimu Zip64**

Standardní archiv ZIP omezuje komprimovanou i dekomprimovanou velikost každé položky, celkovou velikost archivu a počet položek. Protože soubor PPTX je archiv ZIP, velmi velká prezentace může tato omezení překročit. Rozšíření ZIP64 zvyšují příslušná omezení velikosti a počtu položek.

Použijte vlastnost [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) k řízení, zda Aspose.Slides zapisuje rozšíření ZIP64:

- `IF_NECESSARY` používá ZIP64 pouze když prezentace překročí standardní omezení ZIP. Toto je výchozí režim.
- `NEVER` zakazuje rozšíření ZIP64.
- `ALWAYS` vždy zapisuje rozšíření ZIP64.

Následující příklad vždy povolí rozšíření ZIP64 pro výstupní prezentaci:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Warning" %}}
Pokud je použito `Zip64Mode.NEVER` a prezentace se nevejde do standardních omezení ZIP, operace uložení vyvolá výjimku [PptxException](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pptxexception/).
{{% /alert %}}

## **Ukládání prezentací v formátu Office Open XML s úrovněmi komprese**

Pro výstup PPTX můžete vyvážit rychlost ukládání a velikost souboru nastavením vlastnosti [PptxOptions.compression_level](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/pptxoptions/compression_level/). Výčtový typ [CompressionLevel](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/compressionlevel/) poskytuje následující hodnoty:

- `NONE` ukládá data bez komprese.
- `LEVEL1` poskytuje nejrychlejší kompresi a největší komprimovaný výstup.
- `LEVEL2` až `LEVEL5` postupně upřednostňují menší výstup před rychlostí ukládání.
- `LEVEL6` vyvažuje rychlost ukládání a velikost souboru. Toto je výchozí úroveň.
- `LEVEL7` a `LEVEL8` dále upřednostňují menší výstup před rychlostí ukládání.
- `LEVEL9` poskytuje nejsilnější kompresi a vyžaduje nejvíce výpočetního času.

Následující příklad uloží prezentaci bez komprese:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

Následující příklad používá maximální úroveň komprese:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Ukládání prezentací bez obnovení náhledu**

Když je prezentace uložena jako PPTX, vlastnost [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) řídí náhled dokumentu:

- `True` regeneruje náhled během operace uložení. Toto je výchozí hodnota.
- `False` zachovává existující náhled. Pokud prezentace nemá náhled, Aspose.Slides jej nevytvoří.

Následující příklad uloží prezentaci bez obnovení jejího náhledu:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Note" %}}
Vypnutí obnovení náhledu může zkrátit dobu potřebnou k uložení souboru PPTX.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Aspose poskytuje bezplatný [PowerPoint Splitter](https://products.aspose.app/slides/cs/splitter) postavený na API Aspose.Slides. Ukládá vybrané snímky z prezentace jako samostatné soubory PPT nebo PPTX.
{{% /alert %}}

## **Často kladené otázky**

**Podporuje Aspose.Slides inkrementální nebo „rychlé uložení“?**

Ne. Každá operace uložení zapisuje kompletní výstupní soubor místo aktualizace pouze změněných částí.

**Může více vláken uložit stejnou instanci Presentation?**

Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) není [thread-safe](/slides/cs/python-net/multithreading/). Přistupujte a ukládejte každou instanci pouze z jednoho vlákna najednou.

**Co se stane s hypertextovými odkazy a externě odkazovanými soubory při uložení prezentace?**

[Hyperlinks](/slides/cs/python-net/manage-hyperlinks/) zůstávají v prezentaci. Aspose.Slides nekopíruje externě odkazované soubory, takže uložená prezentace musí stále mít přístup k jejich umístěním.

**Mohu uložit metadata dokumentu, jako jsou autor, název, společnost a datum vytvoření?**

Ano. Před uložením nastavte příslušné [document properties](/slides/cs/python-net/presentation-properties/) a Aspose.Slides je zapíše do výstupního souboru.