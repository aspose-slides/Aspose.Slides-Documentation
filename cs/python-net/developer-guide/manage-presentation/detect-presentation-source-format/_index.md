---
title: Zjištění původního formátu prezentace v Pythonu
linktitle: Zdrojový formát
type: docs
weight: 35
url: /cs/python-net/detect-presentation-source-format/
keywords:
- zdrojový formát
- detekce formátu prezentace
- PowerPoint
- OpenDocument
- prezentace
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Načtěte původní formát načtené prezentace v Pythonu pomocí Aspose.Slides pro Python přes .NET, porovnejte API pro detekci a pracujte se soubory, streamy a staršími formáty."
---
## **Přehled**

Po načtení prezentace si přečtěte jen‑pro‑čtení vlastnost [Presentation.source_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/source_format/), abyste určili její původní formát. Použijte ji, pokud další zpracování závisí na formátu, ze kterého byla aktuální instance načtena.

Zdrojový formát se liší od [SaveFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/saveformat/), který je vybrán pro výstupní soubor. Uložení do jiného formátu nemění zdrojový formát existující instance.

## **Načtení zdrojového formátu souboru**

Tento příklad vyžaduje existující soubor `sample.pptx`. Načte soubor a vybere politiku zpracování aplikace pomocí [Presentation.source_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/source_format/), namísto názvu souboru. Změňte vstupní cestu a vyzkoušejte jiné formáty. Příklad vypíše vybranou politiku; nahraďte zprávy vlastní logikou aplikace.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **Rozpoznání podporovaných hodnot**

Výčtová typová hodnota [SourceFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sourceformat/) rozlišuje následující formáty prezentací. Níže uvedené přípony jsou konvenční, nejedná se o rekonstrukci původního názvu souboru.

| Hodnota SourceFormat | Přípona | Formát |
| --- | --- | --- |
| `PPT` | `.ppt` | Prezentace PowerPoint 97–2003 |
| `PPTX` | `.pptx` | Prezentace Office Open XML |
| `PPTM` | `.pptm` | Makrem povolená prezentace Office Open XML |
| `PPS` | `.pps` | Promítání PowerPoint 97–2003 |
| `PPSX` | `.ppsx` | Promítání Office Open XML |
| `PPSM` | `.ppsm` | Makrem povolené promítání Office Open XML |
| `POT` | `.pot` | Šablona PowerPoint 97–2003 |
| `POTX` | `.potx` | Šablona Office Open XML |
| `POTM` | `.potm` | Makrem povolená šablona Office Open XML |
| `ODP` | `.odp` | Prezentace OpenDocument |
| `OTP` | `.otp` | Šablona OpenDocument |
| `FODP` | `.fodp` | Plochá XML ODF prezentace |
| `XML` | `.xml` | Prezentace PowerPoint XML |

## **Načtení zdrojového formátu ze streamu**

Tento příklad vyžaduje existující soubor `sample.pps`. Načtení jeho bajtů do paměťového streamu modeluje vstup bez názvu souboru, například hodnotu z databáze nebo nahraný pole bajtů. Konstruktor [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) přijímá pouze stream.

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

PPT, PPS a POT používají stejný binární formát. Při načítání podle cesty k souboru může přípona napomoci rozlišit promítání nebo šablonu. Bez názvu souboru může být starší obsah PPS a POT hlášen jako `SourceFormat.PPT`; výše uvedený příklad PPS hlásí `PPT`.

Pokud vaše aplikace musí zachovat toto rozlišení, uchovejte původní název souboru nebo podtypová metadata samostatně. Přípona je užitečná nápověda pro tyto starší podtypy, ale neměla by být jediným základem pro identifikaci libovolného obsahu prezentace.

## **Porovnání detekce před a po načtení**

Použijte [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationfactory/get_presentation_info/) a [PresentationInfo.load_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/load_format/), když potřebujete prověřit soubor před načtením kompletního objektového modelu prezentace. Použijte [Presentation.source_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/source_format/), když již instance existuje.

Tento příklad vyžaduje `sample.pptx` a vypíše `PPTX` pro oba kontroly. Ve výrobě zvolte API vhodné pro vaši fázi zpracování; již načtená prezentace nepotřebuje druhou kontrolu jen kvůli získání zdrojového formátu.

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

Výsledky mají různé typy výčtů: [LoadFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadformat/) a [SourceFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sourceformat/). Neporovnávejte je převodem na číselné hodnoty ani nepředpokládejte, že každý formát má identické výsledky detekce. V testu ulož‑a‑znovu popsaném níže byl PowerPoint XML před načtením hlášen jako `LoadFormat.UNKNOWN` a po načtení jako `SourceFormat.XML`.

## **Uchovávejte zdrojové a výstupní formáty odděleně**

Tento příklad vyžaduje `sample.pptx` a zapíše `converted.odp`. Vypíše `PPTX` jak před, tak po uložení původní instance. Pouze nová instance načtená z výstupu ODP hlásí `ODP`.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

Prezentace vytvořená od začátku pomocí `slides.Presentation()` hlásí `SourceFormat.PPTX`. Nemá vstupní soubor: to je výchozí hodnota pro nově vytvořenou instanci, ne důkaz, že byl načten soubor PPTX. Sledujte, zda vaše aplikace vytvořila nebo načetla instanci, pokud je toto rozlišení podstatné.

## **Mapování zdrojového formátu na příponu**

Následující příklad vyžaduje `sample.pptx`. Mapuje každou aktuálně podporovanou hodnotu [SourceFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sourceformat/) na konvenční příponu, aniž by analyzoval vstupní název souboru. Náhradní řešení zabraňuje tichému přiřazení přípony neznámé hodnotě.

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

Toto mapování neprovádí konverzi souboru ani neobnovuje starší podtyp PPS/POT ztracený během načítání ze streamu. Pro skutečné ukládání vyberte [SaveFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/saveformat/) explicitně, nebo použijte konverzi uvedenou v [Ukládání prezentací v jejich původním formátu](/slides/cs/python-net/save-presentation/#save-presentations-in-their-original-format).

## **Ověření formátů uložením a opětovným načtením**

Tento samostatný příklad vytvoří prezentaci a zapíše tři soubory do pracovního adresáře, přepisujíc soubory se stejnými názvy. Každý výstup znovu otevře jak podle cesty, tak přes paměťový stream. Pro PPTX a ODP oba způsoby hlásí uložený formát. Pro PPS načtení podle cesty hlásí `PPS`, zatímco načtení stejných bajtů bez názvu souboru hlásí `PPT`.

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

Stejná kontrola pro všechny výše uvedené formáty přinesla následující výsledky pro generované prezentace s odpovídajícími příponami:

| Uložený formát | SourceFormat z cesty k souboru | SourceFormat z bezejmenného streamu |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` příslušně | Stejně jako cesta k souboru |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` příslušně | Stejně jako cesta k souboru |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` příslušně | Stejně jako cesta k souboru |
| ODP, OTP | `ODP`, `OTP` příslušně | Stejně jako cesta k souboru |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

V těchto kontrolách byla jediná normalizace zdrojového formátu PPS/POT na `PPT` pro bezejmenné streamy. Tabulka popisuje identifikaci formátu, nikoli zachování všech funkcí prezentace během konverze.

## **FAQ**

**Mění uložení do ODP zdrojový formát prezentace načtené z PPTX?**

Ne. Existující instance stále hlásí `PPTX`. Instance načtená ze souboru ODP hlásí `ODP`.

**Dokáže stream vždy rozlišit starou prezentaci, promítání a šablonu?**

Ne. PPT, PPS a POT sdílejí binární formát. Uchovávejte název souboru nebo podtypová metadata samostatně, pokud je toto rozlišení potřeba.

**Které API použít, pokud je prezentace již načtena?**

Přečtěte [Presentation.source_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/source_format/). Použijte [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationfactory/get_presentation_info/) pro inspekci před načtením.