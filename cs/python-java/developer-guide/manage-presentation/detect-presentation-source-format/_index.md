---
title: Určení původního formátu prezentace v Pythonu přes Java
linktitle: Zdrojový formát
type: docs
weight: 35
url: /cs/python-java/detect-presentation-source-format/
keywords:
- zdrojový formát
- detekce formátu prezentace
- PowerPoint
- OpenDocument
- prezentace
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Přečtěte původní formát načtené prezentace v Pythonu přes Java s Aspose.Slides pro Python přes Java, porovnejte API pro detekci a pracujte se soubory, streamy a staršími formáty."
---
## **Přehled**

Po načtení prezentace zavolejte metodu [Presentation.getSourceFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSourceFormat) k určení jejího původního formátu. Použijte ji, když další zpracování závisí na formátu, ze kterého byla aktuální instance načtena.

Zdrojový formát se liší od [SaveFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/) , který je vybrán pro výstupní soubor. Uložení do jiného formátu nemění zdrojový formát existující instance.

Příklady vyžadují Aspose.Slides pro Python přes Java a kompatibilní Java runtime. Každý příklad spustí JVM, pokud již neběží.

## **Načtení zdrojového formátu souboru**

Tento příklad vyžaduje existující soubor `sample.pptx`. Načte soubor a pomocí [Presentation.getSourceFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSourceFormat) vybere politiku zpracování aplikace, místo názvu souboru. Změňte vstupní cestu, abyste vyzkoušeli jiné formáty. Příklad vypíše vybranou politiku; nahraďte zprávy logikou vaší aplikace.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **Rozpoznání podporovaných hodnot**

Třída [SourceFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sourceformat/) definuje celočíselné konstanty, které rozlišují následující formáty prezentací. Níže uvedená přípony jsou konvenční, ne rekonstrukce původního názvu souboru.

| Hodnota SourceFormat | Přípona | Formát |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint prezentace 97–2003 |
| `Pptx` | `.pptx` | Office Open XML prezentace |
| `Pptm` | `.pptm` | Office Open XML prezentace s makry |
| `Pps` | `.pps` | PowerPoint prezentace 97–2003 – slideshow |
| `Ppsx` | `.ppsx` | Office Open XML slideshow |
| `Ppsm` | `.ppsm` | Office Open XML slideshow s makry |
| `Pot` | `.pot` | PowerPoint šablona 97–2003 |
| `Potx` | `.potx` | Office Open XML šablona |
| `Potm` | `.potm` | Office Open XML šablona s makry |
| `Odp` | `.odp` | OpenDocument prezentace |
| `Otp` | `.otp` | OpenDocument šablona prezentace |
| `Fodp` | `.fodp` | Flat XML ODF prezentace |
| `Xml` | `.xml` | PowerPoint XML prezentace |

## **Načtení zdrojového formátu ze streamu**

Tento příklad vyžaduje existující soubor `sample.pps`. Načtení jeho bajtů do paměťového streamu simuluje vstup bez názvu souboru, například hodnotu z databáze nebo nahraný bajtový pole. Konstruktor [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) přijímá pouze stream. Python načte bajty souboru a JPype je převede na Java bajtové pole pro Java paměťový stream.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

PPT, PPS a POT používají stejný binární formát. Při načítání podle cesty může přípona pomoci rozlišit slideshow nebo šablonu. Bez názvu souboru může být starší obsah PPS a POT hlášen jako `SourceFormat.Ppt`; výše uvedený příklad PPS vypíše celočíselnou hodnotu `SourceFormat.Ppt`.

Pokud vaše aplikace musí zachovat toto rozlišení, uložte původní název souboru nebo metadata podtypu samostatně. Přípona je užitečná nápověda pro tyto starší podtypy, ale neměla by být jediným základem pro identifikaci libovolného obsahu prezentace.

## **Porovnání detekce před a po načtení**

Použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationfactory/#getPresentationInfo) a [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#getLoadFormat), když potřebujete soubor zkontrolovat před načtením jeho úplného objektového modelu. Použijte [Presentation.getSourceFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSourceFormat), když instance již existuje.

Tento příklad vyžaduje `sample.pptx` a vypíše celočíselné hodnoty `LoadFormat.Pptx` a `SourceFormat.Pptx`. Ve výrobním prostředí zvolte API odpovídající vašemu stupni zpracování; již načtená prezentace nepotřebuje druhou kontrolu jen pro získání svého zdrojového formátu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

Výsledky používají konstanty z různých tříd: [LoadFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadformat/) a [SourceFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sourceformat/). Nekombinujte jejich číselné hodnoty ani nepředpokládejte, že každý formát má stejné výsledky detekce. PowerPoint XML může být před načtením hlášen jako `LoadFormat.Unknown` a po načtení jako `SourceFormat.Xml`.

## **Udržujte zdrojové a výstupní formáty oddělené**

Tento příklad vyžaduje `sample.pptx` a zapisuje `converted.odp`. Vypíše celočíselnou hodnotu `SourceFormat.Pptx` před i po uložení původní instance. Pouze nová instance načtená z výstupu ODP hlásí `Odp`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Prezentace vytvořená od nuly pomocí `Presentation()` hlásí `SourceFormat.Pptx`. Nemá vstupní soubor: to je výchozí hodnota pro nově vytvořenou instanci, nikoli důkaz, že byl načten soubor PPTX. Sledujte, zda vaše aplikace vytvořila nebo načetla instanci, pokud je toto rozlišení důležité.

## **Mapování zdrojového formátu na příponu**

Následující příklad vyžaduje `sample.pptx`. Mapuje každou aktuálně podporovanou hodnotu [SourceFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sourceformat/) na konvenční příponu, aniž by analyzoval vstupní název souboru. Náhradní řešení zabraňuje tišému přiřazení přípony neznámé hodnotě.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

Toto mapování nepřevádí soubor ani neobnovuje starší podtyp PPS/POT ztracený při načítání ze streamu. Pro skutečné uložení vyberte explicitně [SaveFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/), nebo použijte konverzi uvedenou v [Save Presentations in Their Original Format](/slides/cs/python-java/save-presentation/#save-presentations-in-their-original-format).

## **Ověření formátů uložením a opětovným načtením**

Tento samostatný příklad vytvoří prezentaci a zapíše tři soubory do pracovního adresáře, přepisujíc soubory se stejnými názvy. Každý výstup znovu otevře jak podle cesty, tak přes paměťový stream. Pro PPTX a ODP oba způsoby hlásí uložený formát. Pro PPS načtení podle cesty hlásí `Pps`, zatímco načtení stejných bajtů bez názvu souboru hlásí `Ppt`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

Následující tabulka shrnuje identifikaci zdrojového formátu pro prezentace s odpovídajícími příponami. Jména označují konstanty; Python příklady vypisují jejich celočíselné hodnoty:

| Uložený formát | SourceFormat z cesty k souboru | SourceFormat z bezejmenného streamu |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Stejně jako cesta k souboru |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Stejně jako cesta k souboru |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Stejně jako cesta k souboru |
| ODP, OTP | `Odp`, `Otp` respectively | Stejně jako cesta k souboru |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Obsah PPS/POT je pro bezejmenné streamy identifikován jako `Ppt`. Tabulka popisuje identifikaci formátu, nikoli zachování všech funkcí prezentace během konverze.

## **Často kladené otázky**

**Změní uložení do ODP zdrojový formát prezentace načtené z PPTX?**

Ne. Existující instance stále hlásí `Pptx`. Instance načtená ze souboru ODP, který byl uložen, hlásí `Odp`.

**Může stream vždy rozlišit starší prezentaci, ukázku a šablonu?**

Ne. PPT, PPS a POT sdílejí binární formát. Uchovávejte název souboru nebo metadata podtypu samostatně, pokud je toto rozlišení vyžadováno.

**Které API mám použít, pokud je prezentace již načtena?**

Použijte [Presentation.getSourceFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSourceFormat). Pro kontrolu před načtením použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationfactory/#getPresentationInfo).