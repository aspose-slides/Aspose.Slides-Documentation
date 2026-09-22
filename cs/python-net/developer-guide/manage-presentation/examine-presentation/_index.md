---
title: Načíst a aktualizovat informace o prezentaci v Pythonu
linktitle: Informace o prezentaci
type: docs
weight: 30
url: /cs/python-net/examine-presentation/
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
- Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí Pythonu pro rychlejší poznatky a chytřejší audity obsahu."
---
## **Přehled**

Aspose.Slides může rozpoznat formát prezentace a přečíst metadata dokumentu, aniž by vytvářela úplný objektový model prezentace. To je užitečné, když potřebujete soubory klasifikovat, vytvořit inventuru nebo prozkoumat vlastnosti před tím, než se rozhodnete načíst a zpracovat obsah prezentace.

Tento článek ukazuje lehkou kontrolu pomocí [PresentationFactory](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationfactory/) a [PresentationInfo](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/), a také cílené aktualizace pomocí [DocumentProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/).

## **Zkontrolujte formát prezentace**

Pokud již máte načtenou prezentaci, podívejte se na [Determine the Original Presentation Format](/slides/cs/python-net/detect-presentation-source-format/) pro detekci po načtení a omezení starších PPT, PPS a POT streamů.

Použijte [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationfactory/get_presentation_info/) k prozkoumání souboru, aniž byste vytvořili instanci [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/). Vlastnost [PresentationInfo.load_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/load_format/) hlásí detekovaný formát, např. PPTX, PPT nebo ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Vytvořte lehkou inventuru prezentací**

Při zpracování mnoha souborů prezentací můžete potřebovat kompaktní inventuru pro validaci, indexaci nebo systém správy dokumentů. V tomto scénáři použijte [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationfactory/get_presentation_info/) k získání objektu [PresentationInfo](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/) a poté zavolejte [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/read_document_properties/) k přečtení metadat dokumentu. Tento přístup nevytváří instanci [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) ani nevyžaduje procházení úplným objektovým modelem prezentace.

Rozšířené vlastnosti vystavené [DocumentProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/) poskytují následující hodnoty inventáře:

| Vlastnost | Hodnota inventáře |
| --- | --- |
| [slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/slides/cs/) | Celkový počet snímků. |
| [hidden_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/hidden_slides/) | Počet skrytých snímků. |
| [notes](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/notes/) | Počet snímků obsahujících poznámky. |
| [paragraphs](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/paragraphs/) | Celkový počet odstavců, pokud jsou k dispozici. |
| [words](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/words/) | Celkový počet slov. |
| [multimedia_clips](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/multimedia_clips/) | Celkový počet audio a video klipů. |

Následující příklad načte tyto hodnoty, aniž by vytvořil objekt [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a vytiskne kompaktní inventuru. Kombinuje také [heading_pairs](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/heading_pairs/) s [titles_of_parts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/titles_of_parts/) pro zobrazení skupin obsahu, jako jsou písma, motivy a názvy snímků.

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
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

Každý [HeadingPair](https://reference.aspose.com/slides/cs/python-net/aspose.slides/headingpair/) poskytuje název skupiny a počet položek v této skupině. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/titles_of_parts/) je plochá, uspořádaná kolekce, takže spotřebujte počet po sobě jdoucích názvů určených každým heading pair.

### **Uložená metadata a omezení formátu**

Vlastnosti inventáře vrácené metodou [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/read_document_properties/) odrážejí metadata dostupná ve zdrojovém dokumentu. Aspose.Slides nenačítá a neprochází objektový model prezentace pro přepočet těchto hodnot při tomto volání. Chybějící vlastnosti jsou reprezentovány výchozími hodnotami a uložené hodnoty mohou být neaktuální, pokud aplikace, která naposledy soubor uložila, neaktualizovala jeho dokumentové vlastnosti.

- **PPTX:** Formát poskytuje rozšířené dokumentové vlastnosti pro počet snímků, poznámek, skrytých snímků, odstavců, slov a multimediálních klipů, stejně jako heading pairs a tituly částí. Dostupnost závisí na tom, které vlastnosti byly zapsány výrobcem dokumentu.
- **PPT:** Binární formát může uložit odpovídající souhrnné dokumentové vlastnosti. Pokud vlastnost chybí nebo nebyla výrobcem dokumentu obnovena, Aspose.Slides vrátí její uloženou nebo výchozí hodnotu místo výpočtu ze snímků.
- **ODP:** Metadata OpenDocument poskytují obecné statistiky dokumentu, jako jsou počty stránek, odstavců a slov, ale tyto hodnoty neodpovídají všem rozšířeným vlastnostem specifickým pro PowerPoint. Metadata pro skryté snímky, poznámkové snímky, multimédia, heading‑pair a part‑title mohou být nedostupná a vlastnosti inventáře mohou vracet výchozí hodnoty. Nezpracovávejte nulu nebo prázdnou kolekci jako definitní důkaz, že odpovídající obsah chybí.

Používejte lehký přístup k metadatům pro inventury a předběžné kontroly. Načtěte prezentaci a prozkoumejte její živý objektový model, pokud výsledek musí odrážet změny v paměti nebo pokud potřebujete ověřit skutečný obsah prezentace.

## **Aktualizujte vlastnosti prezentace**

Vlastnosti vrácené metodou [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/read_document_properties/) lze také měnit, aniž by se vytvořil objekt [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/). Proveďte změny pomocí [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/update_document_properties/) a poté zapište svázanou prezentaci pomocí [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/write_binded_presentation/).

Následující obrázek ukazuje původní vlastnosti dokumentu PowerPoint prezentace.

![Původní vlastnosti dokumentu PowerPoint prezentace](input_properties.png)

Následující příklad změní název a čas posledního uložení a zapíše výsledek do nového souboru:

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

Následující obrázek ukazuje aktualizované vlastnosti dokumentu.

![Změněné vlastnosti dokumentu PowerPoint prezentace](output_properties.png)

## **Užitečné odkazy**

Pro související bezpečnostní kontroly a nastavení ochrany si prohlédněte následující články:

- [Password-Protect Presentations](/slides/cs/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/cs/python-net/write-protected-presentation/)

## **Často kladené otázky**

**Jak mohu zkontrolovat, zda jsou písma vložena a která to jsou?**

Načtěte prezentaci a použijte [Presentation.fonts_manager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/fonts_manager/). Zavolejte [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) pro získání vložených fontů a [FontsManager.get_fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_fonts/) pro získání fontů použitých v prezentaci. Porovnejte oba výsledky a najděte písma, která jsou potřebná pro vykreslení, ale nejsou vložena.

**Jak rychle zjistím, zda soubor obsahuje skryté snímky a kolik jich je?**

Pokud jsou uložená metadata dokumentu dostačující, přečtěte [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/hidden_slides/) pomocí [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationfactory/get_presentation_info/) a [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/read_document_properties/). Toto je vhodné pro lehkou inventuru. Pokud byla prezentace v paměti upravena, mohou uložená metadata chybět nebo být zastaralá, nebo pokud potřebujete ověřit aktuální hodnoty, projděte [Presentation.slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/slides/cs/) a zkontrolujte vlastnost [Slide.hidden](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/hidden/) každého snímku.

**Mohu zjistit, zda jsou použity vlastní rozměry a orientace snímku, a zda se liší od výchozích?**

Ano. Načtěte prezentaci a přečtěte [Presentation.slide_size](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/slide_size/). Zkontrolujte [SlideSize.type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidesize/size/) a [SlideSize.orientation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidesize/orientation/) a porovnejte aktuální nastavení s očekávaným přednastavením a rozměry.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí datové zdroje?**

Ano. Najděte každý [Chart](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/) a zkontrolujte [ChartData.data_source_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/data_source_type/). Pro externí sešit přečtěte [ChartData.external_workbook_path](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Typ datového zdroje a cesta identifikují externí odkaz, ale ověření, zda je cíl dostupný, vyžaduje samostatnou kontrolu zdroje.

**Jak mohu posoudit “těžké” snímky, které mohou zpomalovat renderování nebo export do PDF?**

Neexistuje jediná vlastnost složitosti. Procházejte [Presentation.slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/slides/cs/) a kolekci [BaseSlide.shapes](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslide/shapes/) každého snímku. Použijte počet tvarů a přítomnost velkých obrázků, efektů, animací nebo multimédií jako signály, a změřte reprezentativní render nebo export předtím, než považujete snímek za potvrzenou úzkou hranu výkonu.