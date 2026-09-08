---
title: Načíst a aktualizovat informace o prezentaci v Pythonu přes Java
linktitle: Informace o prezentaci
type: docs
weight: 30
url: /cs/python-java/examine-presentation/
keywords:
  - formát prezentace
  - vlastnosti prezentace
  - vlastnosti dokumentu
  - získat vlastnosti
  - číst vlastnosti
  - změnit vlastnosti
  - upravit vlastnosti
  - aktualizovat vlastnosti
  - prozkoumat PPTX
  - prozkoumat PPT
  - prozkoumat ODP
  - PowerPoint
  - OpenDocument
  - prezentace
  - Python
  - Java
  - Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí Pythonu přes Java pro rychlejší poznatky a chytřejší audity obsahu."
---
## **Přehled**

Aspose.Slides dokáže rozpoznat formát prezentace a přečíst její metadata dokumentu, aniž by vytvořil kompletní objektový model prezentace. To je užitečné, když potřebujete soubory klasifikovat, vytvořit inventář nebo zkontrolovat vlastnosti před rozhodnutím, zda načíst a zpracovat obsah prezentace.

Příklady vyžadují Aspose.Slides pro Python via Java a kompatibilní Java runtime. Každý příklad spustí JVM, pokud již neběží. Poskytněte existující soubory prezentací na cestách použitých v příkladech.

Tento článek ukazuje lehkou inspekci pomocí [PresentationFactory](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationfactory/) a [PresentationInfo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/), a také cílené aktualizace pomocí [DocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/).

## **Zkontrolovat formát prezentace**

Použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationfactory/#getPresentationInfo) k inspekci souboru, aniž byste vytvořili instanci [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/). Metoda [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#getLoadFormat) vrací zjištěný formát, například PPTX, PPT nebo ODP.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **Vytvořit lehký inventář prezentací**

Když zpracováváte mnoho souborů prezentací, můžete potřebovat kompaktní inventář pro validaci, indexaci nebo systém správy dokumentů. V tomto scénáři použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationfactory/#getPresentationInfo), abyste získali objekt [PresentationInfo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/), a poté zavolejte [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#readDocumentProperties), abyste přečetli metadata dokumentu. Tento přístup nevytváří instanci [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) ani nevyžaduje procházení kompletním objektovým modelem prezentace.

Rozšířené vlastnosti poskytované [DocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/) poskytují následující hodnoty inventáře:

| Metoda | Hodnota inventáře |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/#getSlides) | Celkový počet snímků. |
| [getHiddenSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/#getHiddenSlides) | Počet skrytých snímků. |
| [getNotes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/#getNotes) | Počet snímků obsahujících poznámky. |
| [getParagraphs](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/#getParagraphs) | Celkový počet odstavců, pokud je k dispozici. |
| [getWords](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/#getWords) | Celkový počet slov. |
| [getMultimediaClips](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/#getMultimediaClips) | Celkový počet audio a video klipů. |

Následující příklad načte tyto hodnoty, aniž by vytvořil objekt [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a vytiskne kompaktní inventář. Také kombinuje [getHeadingPairs](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/#getHeadingPairs) s [getTitlesOfParts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/#getTitlesOfParts), aby zobrazil skupiny obsahu, jako jsou písma, motivy a názvy snímků.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
            if part_index >= len(titles_of_parts):
                break
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

Každý [HeadingPair](https://reference.aspose.com/slides/cs/python-java/aspose.slides/headingpair/) poskytuje název skupiny a počet položek v této skupině. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/#getTitlesOfParts) vrací ploché, uspořádané pole, takže spotřebujte počet po sobě jdoucích názvů určených každým heading pair.

### **Uložená metadata a omezení formátů**

Vlastnosti inventáře vrácené metodou [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#readDocumentProperties) odrážejí metadata dostupná ve zdrojovém dokumentu. Aspose.Slides nenačítá ani neprochází objektový model prezentace za účelem přepočtu těchto hodnot při tomto volání. Chybějící vlastnosti jsou reprezentovány výchozími hodnotami a uložené hodnoty mohou být zastaralé, pokud aplikace, která naposledy soubor uložila, neaktualizovala jeho vlastnosti dokumentu.

- **PPTX:** Formát poskytuje rozšířené vlastnosti dokumentu pro počet snímků, poznámek, skrytých snímků, odstavců, slov a multimediálních klipů, stejně jako heading pairs a názvy částí. Dostupnost závisí na tom, které vlastnosti byly zapsány výrobcem dokumentu.
- **PPT:** Binární formát může uložit odpovídající vlastnosti souhrnu dokumentu. Pokud je vlastnost absentní nebo nebyla výrobcem dokumentu aktualizována, Aspose.Slides vrátí její uloženou nebo výchozí hodnotu místo vypočítání ze snímků.
- **ODP:** Metadata OpenDocument poskytují obecné statistiky dokumentu, jako jsou počty stránek, odstavců a slov, ale tyto hodnoty neodpovídají všem rozšířeným vlastnostem specifickým pro PowerPoint. Metadata pro skryté snímky, poznámky, multimédia, heading-pair a názvy částí mohou být nedostupná a vlastnosti inventáře mohou vracet výchozí hodnoty. Nepovažujte nulovou hodnotu nebo prázdné pole za definitivní důkaz, že odpovídající obsah chybí.

Použijte lehký přístup k metadatům pro inventáře a předběžné kontroly. Načtěte prezentaci a zkontrolujte její živý objektový model, když výsledek musí odrážet změny v paměti nebo když potřebujete ověřit skutečný obsah prezentace.

## **Aktualizovat vlastnosti prezentace**

Vlastnosti vrácené metodou [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#readDocumentProperties) lze také změnit, aniž byste vytvořili instanci [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/). Aplikujte změny pomocí [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#updateDocumentProperties), a poté zapište svázanou prezentaci pomocí [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#writeBindedPresentation).

Následující obrázek zobrazuje původní vlastnosti dokumentu PowerPoint prezentace.

![Původní vlastnosti dokumentu PowerPoint prezentace](input_properties.png)

Následující příklad změní název a čas posledního uložení a výsledek zapíše do nového souboru:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

Následující obrázek zobrazuje aktualizované vlastnosti dokumentu.

![Změněné vlastnosti dokumentu PowerPoint prezentace](output_properties.png)

## **Užitečné odkazy**

Pro související bezpečnostní kontroly a nastavení ochrany si přečtěte následující články:

- [Zabezpečit prezentace heslem](/slides/cs/python-java/password-protected-presentation/)
- [Ochrana před zápisem prezentací](/slides/cs/python-java/write-protected-presentation/)

## **Často kladené otázky**

**Jak mohu zkontrolovat, zda jsou písma vložena a která to jsou?**

Načtěte prezentaci a použijte [Presentation.getFontsManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getFontsManager). Zavolejte [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts), abyste získali vložená písma, a [FontsManager.getFonts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#getFonts), abyste získali písma použité v prezentaci. Porovnejte oba výsledky a najděte písma, která jsou potřebná pro vykreslení, ale nejsou vložena.

**Jak mohu rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Pokud jsou uložená metadata dokumentu dostatečná, přečtěte [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/#getHiddenSlides) přes [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationfactory/#getPresentationInfo) a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#readDocumentProperties). To je vhodné pro lehký inventář. Pokud byla prezentace v paměti upravena, uložená metadata mohou chybět nebo být zastaralá, nebo pokud potřebujete ověřit aktuální hodnoty, projděte [Presentation.getSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSlides) a zkontrolujte u každého snímku metodu [Slide.getHidden](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getHidden).

**Mohu zjistit, zda je použita vlastní velikost a orientace snímků, a zda se liší od výchozích?**

Ano. Načtěte prezentaci a zavolejte [Presentation.getSlideSize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSlideSize). Použijte [SlideSize.getType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidesize/#getSize), a [SlideSize.getOrientation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidesize/#getOrientation), abyste porovnali aktuální nastavení s očekávaným přednastavením a rozměry.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí datové zdroje?**

Ano. Najděte každý [Chart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/) a zavolejte [ChartData.getDataSourceType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdata/#getDataSourceType). Pro externí sešit zavolejte [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Typ zdroje dat a cesta identifikují externí odkaz, ale ověření, zda je cíl dostupný, vyžaduje samostatnou kontrolu zdroje.

**Jak mohu posoudit 'těžké' snímky, které mohou zpomalit vykreslování nebo export do PDF?**

Neexistuje jedna vlastnost komplexnosti. Projděte [Presentation.getSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSlides) a kolekci [BaseSlide.getShapes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/#getShapes) každého snímku. Použijte počet tvarů a přítomnost velkých obrázků, efektů, animací nebo multimédií jako signály, a změřte reprezentativní vykreslení nebo export, než považujete snímek za potvrzený úzký profil výkonu.