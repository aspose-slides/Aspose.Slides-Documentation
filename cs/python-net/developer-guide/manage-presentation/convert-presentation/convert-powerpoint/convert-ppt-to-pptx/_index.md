---
title: Převod PPT do PPTX v Pythonu
linktitle: PPT na PPTX
type: docs
weight: 20
url: /cs/python-net/convert-ppt-to-pptx/
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
- Aspose.Slides
description: "Převést starší soubory PPT na PPTX v Pythonu pomocí Aspose.Slides. Obsahuje příklady pro převod jediného souboru i dávkový převod, zpracování chyb a poznámky o věrnosti."
---
## **Přehled**

PPT je starší binární formát PowerPoint, zatímco PPTX je novější formát Open XML. Aspose.Slides for Python via .NET může načíst soubor PPT a uložit jej jako PPTX bez Microsoft PowerPoint. Tento článek ukazuje, jak převést jeden soubor nebo složku souborů a vysvětluje, co po konverzi ověřit.

## **Převod souboru PPT do PPTX**

Načtěte zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/), poté zavolejte [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/) s [SaveFormat.PPTX](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/saveformat/). Příkaz `with` uvolní prezentaci a její prostředky po skončení bloku.

```python
import aspose.slides as slides

# Načíst starou PPT prezentaci.
with slides.Presentation("presentation.ppt") as presentation:
    # Uložit prezentaci ve formátu PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

Přípona souboru sama o sobě nevybírá výstupní formát; to určuje argument [SaveFormat.PPTX](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/saveformat/). Pokud potřebujete zachovat původní soubor PPT, udržujte vstupní a výstupní cesty odlišné.

## **Převod více souborů PPT**

Následující příklad převádí každý soubor `.ppt` v jednom adresáři. Každý soubor je zpracován nezávisle, takže selhání jedné konverze nezastaví zbytek dávky.

```python
from pathlib import Path

import aspose.slides as slides

input_directory = Path("input")
output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

for input_path in input_directory.glob("*.ppt"):
    output_path = output_directory / f"{input_path.stem}.pptx"

    try:
        with slides.Presentation(str(input_path)) as presentation:
            presentation.save(str(output_path), slides.export.SaveFormat.PPTX)
        print(f"Converted: {input_path}")
    except Exception as exception:
        print(f"Failed: {input_path} ({exception})")
```

Pro produkční úlohy zaznamenejte úplnou výjimku, rozhodněte, zda lze přepsat existující výstupní soubor, a zapište názvy neúspěšných souborů do fronty pro opakování nebo revizi. Poškozené soubory, soubory chráněné heslem otevřené bez požadovaného hesla, nepřístupné cesty a nepodporovaný obsah mohou způsobit selhání konverze. Viz [Password-Protected Presentations](/python-net/password-protected-presentation/) pro načítání šifrovaných souborů.

## **Věrnost a starší funkce**

Konverze obvykle zachovává snímky, mastery, rozvržení, text, tvary, obrázky, tabulky a grafy. Nicméně PPT a PPTX nevyjadřují každou funkci přesně stejným způsobem. Starší funkce, která nemá ekvivalent v PPTX nebo není knihovnou podporována, může být normalizována, vynechána nebo zobrazena odlišně.

Zkontrolujte převedený soubor, pokud obsahuje animace, přechody, vložené nebo propojené OLE objekty, ovládací prvky ActiveX, vložená média, neobvyklá písma nebo VBA makra. Běžný soubor PPTX není formát s povolenými makry, proto použijte vhodný workflow s povolenými makry, pokud musí být VBA k dispozici. Také ověřte, že požadovaná písma a externí zdroje jsou přítomny v prostředí, kde bude převedená prezentace otevřena nebo vykreslena.

U důležitých dokumentů programově znovu otevřete vygenerovaný PPTX a zkontrolujte klíčové počty snímků a obsah, poté porovnejte jeho vzhled a chování prezentace v zamýšleném prohlížeči. Nepovažujte úspěšné volání [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/) za důkaz, že každá starší funkce má přesnou PPTX reprezentaci.

## **Kdy použít PPTX**

Používejte PPTX, když bude prezentace upravována v aktuálních verzích PowerPointu, vyměňována se systémy, které pracují s balíčky Open XML, nebo ukládána ve formátu, který je snazší prohlížet a obnovovat než starší binární PPT. Uchovávejte originální PPT jako archivní nebo záložní kopii, dokud převedená prezentace neprojde vašimi testy věrnosti.

Pokud místo toho potřebujete PDF, HTML, obrázky, XPS nebo jiný výstupní typ, použijte specifické pokyny pro formát v [Convert Presentations to Multiple Formats](/python-net/convert-presentation/) místo předpokladu, že všechny cíle zachovají editovatelné funkce PowerPointu.

## **Online převodník**

Pro občasný soubor nebo rychlé srovnání můžete použít [online PPT to PPTX converter](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx). Pro opakovatelné konverze, dávkové zpracování nebo zpracování chyb na úrovni aplikace použijte Python API.

## **Související články**

- [PPT vs PPTX](/python-net/ppt-vs-pptx/)
- [Save Presentations in Python](/python-net/save-presentation/)
- [Supported File Formats](/python-net/supported-file-formats/)
- [Open Presentations in Python](/python-net/open-presentation/)

## **Často kladené otázky**

**Mohu převést PPT na PPTX bez nainstalovaného Microsoft PowerPoint?**

Ano. Aspose.Slides for Python via .NET načítá a ukládá soubory prezentací, aniž by vyžadoval Microsoft PowerPoint.

**Zachová konverze PPT na PPTX veškerý obsah přesně?**

Zachovává běžný obsah prezentace, ale přesná věrnost není garantována pro každou starší nebo nepodporovanou funkci. Prohlédněte vygenerovaný soubor, pokud obsahuje makra, OLE nebo ActiveX objekty, média, specializované animace nebo neobvyklá písma.

**Mohu převést soubor PPT chráněný heslem?**

Ano, pokud při načítání souboru zadáte správné heslo. Chybějící nebo nesprávné heslo způsobí selhání načítací operace.

**Mám po konverzi smazat soubor PPT?**

Uchovávejte originál, dokud neověříte PPTX v prohlížečích a pracovních postupech, které jsou pro vás důležité. To poskytuje záložní kopii pro případ, že se starší funkce převede odlišně.