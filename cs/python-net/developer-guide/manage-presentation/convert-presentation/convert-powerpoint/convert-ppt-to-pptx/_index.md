---
title: Převod PPT na PPTX v Pythonu
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
description: "Převod starých souborů PPT na PPTX v Pythonu pomocí Aspose.Slides. Obsahuje příklady pro převod jednotlivých souborů i dávkový převod, zpracování chyb a poznámky o věrnosti."
---
## **Přehled**

PPT je starší binární formát PowerPointu, zatímco PPTX je novější formát Open XML. Aspose.Slides for Python via .NET může načíst soubor PPT a uložit jej jako PPTX bez Microsoft PowerPoint. Tento článek ukazuje, jak převést jeden soubor nebo adresář souborů a vysvětluje, co ověřit po konverzi.

## **Převod souboru PPT na PPTX**

Načtěte zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a poté zavolejte [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/) s argumentem [SaveFormat.PPTX](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/saveformat/). Příkaz `with` uvolní prezentaci a její prostředky, když blok skončí.

```python
import aspose.slides as slides

# Načtěte starou PPT prezentaci.
with slides.Presentation("presentation.ppt") as presentation:
    # Uložte prezentaci ve formátu PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

Přípona souboru sama o sobě nevybírá výstupní formát; rozhoduje o tom argument [SaveFormat.PPTX](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/saveformat/). Pokud potřebujete zachovat původní PPT soubor, udržujte vstupní a výstupní cesty odlišné.

## **Převod více souborů PPT**

Následující příklad převádí každý soubor `.ppt` v jednom adresáři. Každý soubor je zpracován nezávisle, takže selhání jedné konverze neblokuje zbytek dávky.

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

Pro produkční úlohy zaznamenejte úplnou výjimku, rozhodněte, zda je možné přepsat existující výstupní soubor, a zapište názvy neúspěšných souborů do fronty pro opakování nebo revizi. Poškozené soubory, soubory chráněné heslem otevřené bez požadovaného hesla, nedostupné cesty a nepodporovaný obsah mohou způsobit selhání převodu. Viz [Password-Protected Presentations](/slides/cs/python-net/password-protected-presentation/) pro načítání šifrovaných souborů.

## **Věrnost a starší funkce**

Konverze obvykle zachovává snímky, hlavní motivy, rozvržení, text, tvary, obrázky, tabulky a grafy. Přesto PPT a PPTX nevyjadřují všechny funkce naprosto stejným způsobem. Starší funkce, pro kterou neexistuje ekvivalent v PPTX nebo kterou knihovna nepodporuje, může být normalizována, vynechána nebo zobrazena odlišně.

Zkontrolujte převedený soubor, pokud obsahuje animace, přechody, vložené nebo propojené OLE objekty, ActiveX ovládací prvky, vložená multimédia, neobvyklá písma nebo VBA makra. Soubor PPTX není formát umožňující makra, takže použijte vhodný pracovní postup s makry, pokud musí být VBA k dispozici. Také ověřte, že požadovaná písma a externí zdroje jsou přítomny v prostředí, kde bude převedená prezentace otevřena nebo vykreslena.

U důležitých dokumentů znovu načtěte vygenerovaný PPTX programově a zkontrolujte klíčové počty snímků a obsah, poté porovnejte vzhled a chování prezentace v zamýšleném prohlížeči. Nepovažujte úspěšné volání [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/) za důkaz, že každá starší funkce má přesnou PPTX reprezentaci.

## **Kdy použít PPTX**

Použijte PPTX, když bude prezentace upravována v aktuálních verzích PowerPointu, vyměňována se systémy pracujícími s balíčky Open XML nebo ukládána ve formátu, který je snazší prozkoumat a obnovit než starý binární PPT. Ponechte původní PPT jako archivní nebo záložní kopii, dokud převedená prezentace neprojde vašimi kontrolami věrnosti.

Pokud potřebujete místo toho PDF, HTML, obrázky, XPS nebo jiný výstupní typ, použijte specifické pokyny pro formáty v [Convert Presentations to Multiple Formats](/slides/cs/python-net/convert-presentation/) místo předpokladu, že všechny cíle zachovají editovatelné funkce PowerPointu.

## **Online převodník**

Pro občasný soubor nebo rychlé srovnání můžete použít [online PPT to PPTX converter](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx). Pro opakované konverze, dávkové zpracování nebo zpracování chyb na úrovni aplikace použijte Python API.

## **Související články**

- [PPT vs PPTX](/slides/cs/python-net/ppt-vs-pptx/)
- [Ukládání prezentací v Pythonu](/slides/cs/python-net/save-presentation/)
- [Podporované formáty souborů](/slides/cs/python-net/supported-file-formats/)
- [Otevírání prezentací v Pythonu](/slides/cs/python-net/open-presentation/)

## **FAQ**

**Mohu převést PPT na PPTX bez nainstalovaného Microsoft PowerPoint?**

Ano. Aspose.Slides for Python via .NET načítá a ukládá soubory prezentací bez požadavku na Microsoft PowerPoint.

**Zachová převod PPT na PPTX veškerý obsah přesně?**

Zachovává běžný obsah prezentace, ale přesná věrnost není zaručena pro každou starší nebo nepodporovanou funkci. Zkontrolujte vygenerovaný soubor, pokud obsahuje makra, OLE nebo ActiveX objekty, média, specializované animace nebo neobvyklá písma.

**Mohu převést soubor PPT chráněný heslem?**

Ano, pokud při načítání souboru zadáte správné heslo. Chybějící nebo nesprávné heslo způsobí selhání operace načtení.

**Mám po konverzi smazat soubor PPT?**

Ponechte původní soubor, dokud neověříte PPTX v prohlížečích a pracovních postupech, které pro vás jsou důležité. Poskytne to záložní kopii pro případ, že některá starší funkce bude převedena odlišně.