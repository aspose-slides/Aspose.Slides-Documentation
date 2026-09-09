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
description: "Převod starých souborů PPT na PPTX v Pythonu pomocí Aspose.Slides. Obsahuje příklady v Pythonu pro konverzi jednotlivých souborů i dávkovou, zpracování chyb a poznámky o věrnosti."
---
## **Overview**

PPT je starší binární formát PowerPointu, zatímco PPTX je novější formát Open XML. Aspose.Slides pro Python přes Java dokáže načíst soubor PPT a uložit jej jako PPTX bez Microsoft PowerPoint. Tento článek ukazuje, jak převést jeden soubor nebo adresář souborů a vysvětluje, co ověřit po konverzi.

Každý příklad spustí virtuální stroj Java, pokud je to potřeba, a po použití uvolní prezentaci. Nahraďte ukázkové cesty vlastními cestami k souborům nebo adresářům.

## **Převod souboru PPT na PPTX**

Načtěte zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/), poté zavolejte [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Pptx). Blok `finally` uvolní prezentaci a její prostředky.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Načtěte starší prezentaci PPT.
presentation = Presentation("presentation.ppt")
try:
    # Uložte prezentaci ve formátu PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Přípona souboru sama o sobě nevybírá výstupní formát; to určuje argument [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Pptx). Uchovávejte vstupní a výstupní cesty odlišné, pokud potřebujete zachovat původní soubor PPT.

## **Převod více souborů PPT**

Následující příklad převádí každý soubor `.ppt` v jednom adresáři. Každý soubor je zpracován nezávisle, takže selhání jedné konverze neukončí zbytek dávky.

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

Pro produkční úlohy zaznamenávejte úplnou výjimku, rozhodněte, zda lze přepsat existující výstupní soubor, a zapište názvy neúspěšných souborů do fronty pro opakování nebo revizi. Poškozené soubory, soubory chráněné heslem otevřené bez požadovaného hesla, nedostupné cesty a nepodporovaný obsah mohou způsobit selhání konverze. Viz [Password-Protected Presentations](/slides/cs/python-java/password-protected-presentation/) pro načítání šifrovaných souborů.

## **Věrnost a starší funkce**

Konverze obvykle zachovává snímky, předlohy, rozvržení, text, tvary, obrázky, tabulky a grafy. Přesto PPT a PPTX neznázorňují každou funkci přesně stejným způsobem. Starší funkce, která nemá ekvivalent v PPTX, nebo není knihovnou podporována, může být normalizována, vynechána nebo zobrazena odlišně.

Zkontrolujte převzatý soubor, pokud obsahuje animace, přechody, vložené nebo odkazované objekty OLE, ovládací prvky ActiveX, vložená média, neobvyklá písma nebo makra VBA. Pouhý soubor PPTX není formát s podporou maker, takže při nutnosti zachovat VBA použijte odpovídající workflow s povolenými makry. Také ověřte, že požadovaná písma a externí zdroje jsou k dispozici v prostředí, kde bude převzatá prezentace otevřena nebo vykreslena.

U důležitých dokumentů znovu otevřete vygenerovaný PPTX programově a zkontrolujte počet snímků a obsah, poté porovnejte jeho vzhled a chování prezentace v zamýšleném prohlížeči. Nepovažujte úspěšné volání [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) za důkaz, že každá starší funkce má přesnou reprezentaci v PPTX.

## **Kdy použít PPTX**

Používejte PPTX, když bude prezentace upravována v aktuálních verzích PowerPointu, vyměňována se systémy pracujícími s balíčky Open XML, nebo ukládána ve formátu, který je snazší prozkoumat a obnovit než starší binární PPT. Ponechte původní PPT jako archivní nebo záložní kopii, dokud převzatá prezentace neprojde vašimi kontrolami věrnosti.

Pokud místo toho potřebujete PDF, HTML, obrázky, XPS nebo jiný výstupní typ, použijte specifické pokyny pro formát v [Convert Presentations to Multiple Formats](/slides/cs/python-java/convert-presentation/) místo předpokladu, že všechny cíle zachovají editovatelné funkce PowerPointu.

## **Online převodník**

Pro občasný soubor nebo rychlé srovnání můžete použít [online PPT to PPTX converter](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx). Pro opakované konverze, dávkové zpracování nebo zpracování chyb na úrovni aplikace použijte API Python přes Java.

## **Související články**

- [PPT vs PPTX](/slides/cs/python-java/ppt-vs-pptx/)
- [Save Presentations in Python](/slides/cs/python-java/save-presentation/)
- [Supported File Formats](/slides/cs/python-java/supported-file-formats/)
- [Open Presentations in Python](/slides/cs/python-java/open-presentation/)

## **Často kladené otázky**

**Mohu převést PPT na PPTX bez nainstalovaného Microsoft PowerPoint?**

Ano. Aspose.Slides pro Python přes Java načítá a ukládá soubory prezentací, aniž by vyžadoval Microsoft PowerPoint.

**Zachová konverze PPT na PPTX veškerý obsah přesně?**

Zachovává běžný obsah prezentace, ale přesná věrnost není zaručena pro každou starší nebo nepodporovanou funkci. Prohlédněte vygenerovaný soubor, pokud obsahuje makra, objekty OLE či ActiveX, média, specializované animace nebo neobvyklá písma.

**Mohu převést soubor PPT chráněný heslem?**

Ano, pokud při načítání souboru zadáte správné heslo. Chybějící nebo nesprávné heslo způsobí selhání operace načítání.

**Mám po konverzi smazat soubor PPT?**

Ponechte originál, dokud neověříte PPTX ve prohlížečích a pracovních postupech, které jsou pro vás důležité. To poskytne záložní kopii pro případ, že se starší funkce převádí odlišně.