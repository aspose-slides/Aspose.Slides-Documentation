---
title: Převod PPT na PPTX v Pythonu
linktitle: PPT na PPTX
type: docs
weight: 20
url: /cs/python-java/convert-ppt-to-pptx/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- PPT na PPTX
- uložit PPT jako PPTX
- exportovat PPT do PPTX
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Převést starší soubory PPT na PPTX v Pythonu pomocí Aspose.Slides. Obsahuje příklady v Pythonu pro konverzi jedné souboru i dávkové konverze, zpracování chyb a poznámky o věrnosti."
---
## **Přehled**

PPT je starší binární formát PowerPointu, zatímco PPTX je novější formát Open XML. Aspose.Slides for Python via Java může načíst soubor PPT a uložit jej jako PPTX bez Microsoft PowerPoint. Tento článek ukazuje, jak převést jeden soubor nebo adresář souborů a vysvětluje, co zkontrolovat po konverzi.

Každý příklad spustí virtuální stroj Java, pokud je to potřeba, a po použití uvolní prezentaci. Nahraďte ukázkové cesty vlastními cestami k souborům nebo adresářům.

## **Převod souboru PPT na PPTX**

Nahrát zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) , poté zavolejte [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) s argumentem [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Pptx) . Blok `finally` uvolní prezentaci a její prostředky.

```python
import jpile
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Načtěte starou PPT prezentaci.
presentation = Presentation("presentation.ppt")
try:
    # Uložte prezentaci ve formátu PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Přípona souboru sama o sobě nevybírá výstupní formát; to dělá argument [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Pptx) . Pokud potřebujete zachovat původní soubor PPT, udržujte vstupní a výstupní cesty odlišné.

## **Převod více souborů PPT**

Následující příklad převádí každý soubor `.ppt` v jednom adresáři. Každý soubor je zpracován nezávisle, takže selhání jedné konverze neblokuje zbytek dávky.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

Pro produkční úlohy zaznamenejte kompletní výjimku, rozhodněte, zda může být existující výstupní soubor přepsán, a zapište názvy selhaných souborů do fronty pro opakování nebo revizi. Poškozené soubory, soubory chráněné heslem otevřené bez požadovaného hesla, nedostupné cesty a nepodporovaný obsah mohou všechny způsobit selhání konverze. Viz [Password-Protected Presentations](/slides/cs/python-java/password-protected-presentation/) pro načítání šifrovaných souborů.

## **Věrnost a starší funkce**

Konverze obvykle zachovává snímky, mastery, rozvržení, text, tvary, obrázky, tabulky a grafy. Nicméně PPT a PPTX nepředstavují každou funkci přesně stejným způsobem. Legacy funkce, která nemá ekvivalent v PPTX, nebo není knihovnou podporována, může být normalizována, vynechána nebo zobrazena jinak.

Zkontrolujte převedený soubor, pokud obsahuje animace, přechody, vložené nebo propojené OLE objekty, ActiveX ovládací prvky, vložená média, neobvyklá písma nebo VBA makra. Pouhý soubor PPTX není formát podporující makra, takže použijte vhodný workflow podporující makra, pokud musí být VBA k dispozici. Také ověřte, že požadovaná písma a externí zdroje jsou přítomny v prostředí, kde bude převedená prezentace otevřena nebo vykreslena.

U důležitých dokumentů znovu načtěte generovaný PPTX programově a zkontrolujte klíčové počty snímků a obsah, poté porovnejte jeho vzhled a chování prezentace ve zamýšleném prohlížeči. Nepovažujte úspěšné volání [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) za důkaz, že každá starší funkce má přesnou PPTX reprezentaci.

## **Kdy použít PPTX**

PPTX používejte, když bude prezentace upravována v aktuálních verzích PowerPointu, vyměňována se systémy pracujícími s Open XML balíčky, nebo uložena ve formátu, který je snadněji kontrolovatelný a obnovitelný než starší binární PPT. Uchovávejte originální PPT jako archivní nebo záložní kopii, dokud převedená prezentace neprojde vašimi kontroly věrnosti.

Pokud místo toho potřebujete PDF, HTML, obrázky, XPS nebo jiný výstupní typ, použijte specifické pokyny pro formát v [Convert Presentations to Multiple Formats](/slides/cs/python-java/convert-presentation/) místo předpokladu, že všechny cíle zachovávají editovatelné funkce PowerPointu.

## **Online převaděč**

Pro občasný soubor nebo rychlé srovnání můžete použít [online PPT to PPTX converter](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx) . Pro opakované konverze, hromadné zpracování nebo zpracování chyb na úrovni aplikace použijte API Python via Java.

## **Související články**

- [PPT vs PPTX](/slides/cs/python-java/ppt-vs-pptx/)
- [Save Presentations in Python](/slides/cs/python-java/save-presentation/)
- [Supported File Formats](/slides/cs/python-java/supported-file-formats/)
- [Open Presentations in Python](/slides/cs/python-java/open-presentation/)

## **Často kladené otázky**

**Mohu převést PPT na PPTX bez instalovaného Microsoft PowerPoint?**

Ano. Aspose.Slides for Python via Java načítá a ukládá soubory prezentací bez nutnosti Microsoft PowerPoint.

**Zachová konverze PPT na PPTX veškerý obsah přesně?**

Zachovává běžný obsah prezentací, ale přesná věrnost není zaručena pro každou starší nebo nepodporovanou funkci. Prohlédněte si vygenerovaný soubor, pokud obsahuje makra, OLE nebo ActiveX objekty, média, speciální animace nebo neobvyklá písma.

**Mohu převést soubor PPT chráněný heslem?**

Ano, pokud při načítání souboru zadáte správné heslo. Chybějící nebo nesprávné heslo způsobí selhání načítací operace.

**Mám po konverzi smazat soubor PPT?**

Uchovávejte originál, dokud neověříte PPTX ve prohlížečích a pracovních postupech, které jsou pro vás důležité. To poskytuje záložní kopii pro případ, že se starší funkce převede odlišně.