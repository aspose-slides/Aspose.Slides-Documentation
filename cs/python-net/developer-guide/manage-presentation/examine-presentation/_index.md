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
- zkoumat PPTX
- zkoumat PPT
- zkoumat ODP
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí Pythonu pro rychlejší poznatky a chytřejší audity obsahu."
---
## **Přehled**

Aspose.Slides může rozpoznat formát prezentace a načíst její metadata dokumentu, aniž by vytvořil kompletní model objektů prezentace. To je užitečné, když potřebujete soubory klasifikovat, vytvořit inventář nebo prověřit vlastnosti před tím, než se rozhodnete načíst a zpracovat obsah prezentace.

Tento článek ukazuje lehkou inspekci pomocí [PresentationFactory](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationfactory/) a [PresentationInfo](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/), stejně jako cílené aktualizace pomocí [DocumentProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/).

## **Zkontrolovat formát prezentace**

Použijte [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationfactory/get_presentation_info/) k prozkoumání souboru, aniž byste vytvořili instanci [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/). Vlastnost [PresentationInfo.load_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/load_format/) uvádí zjištěný formát, například PPTX, PPT nebo ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Vytvořit odlehčený inventář prezentací**

Když zpracováváte mnoho souborů prezentací, můžete potřebovat kompaktní inventář pro validaci, indexování nebo systém správy dokumentů. V tomto scénáři použijte [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationfactory/get_presentation_info/) k získání objektu [PresentationInfo](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/), a poté zavolejte [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/read_document_properties/) k načtení metadat dokumentu. Tento přístup nevytváří instanci [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) ani nevyžaduje procházet kompletní model objektů prezentace.

Rozšířené vlastnosti poskytované třídou [DocumentProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/) zahrnují následující hodnoty inventáře:

| Vlastnost | Hodnota inventáře |
| --- | --- |
| [slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/slides/cs/) | Celkový počet snímků. |
| [hidden_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/hidden_slides/) | Počet skrytých snímků. |
| [notes](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/notes/) | Počet snímků obsahujících poznámky. |
| [paragraphs](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/paragraphs/) | Celkový počet odstavců, pokud jsou k dispozici. |
| [words](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/words/) | Celkový počet slov. |
| [multimedia_clips](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/multimedia_clips/) | Celkový počet audio a video klipů. |

Následující příklad načte tyto hodnoty, aniž by vytvořil objekt [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/), a vytiskne kompaktní inventář. Kombinuje také [heading_pairs](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/heading_pairs/) s [titles_of_parts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/titles_of_parts/) k zobrazení skupin obsahu, jako jsou písma, motivy a názvy snímků.

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

Každý [HeadingPair](https://reference.aspose.com/slides/cs/python-net/aspose.slides/headingpair/) poskytuje název skupiny a počet položek v této skupině. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/titles_of_parts/) je plochá, uspořádaná kolekce, takže zpracujte počet po sobě jdoucích názvů určených každým párem záhlaví.

### **Uložená metadata a omezení formátu**

Vlastnosti inventáře vrácené metodou [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/read_document_properties/) odrážejí metadata dostupná ve zdrojovém dokumentu. Aspose.Slides nenačítá a neprochází model objektů prezentace k přepočítání těchto hodnot pro tento volání. Chybějící vlastnosti jsou reprezentovány výchozími hodnotami a uložené hodnoty mohou být zastaralé, pokud aplikace, která soubor naposledy uložila, neaktualizovala jeho dokumentové vlastnosti.

- **PPTX:** Formát poskytuje rozšířené vlastnosti dokumentu pro počty snímků, poznámek, skrytých snímků, odstavců, slov a multimédií, stejně jako páry záhlaví a názvy částí. Dostupnost závisí na tom, které vlastnosti byly zapsány producentem dokumentu.
- **PPT:** Binární formát může ukládat odpovídající vlastnosti souhrnu dokumentu. Pokud je vlastnost nepřítomna nebo nebyla producentem dokumentu aktualizována, Aspose.Slides vrátí její uloženou nebo výchozí hodnotu místo výpočtu z obsahu snímků.
- **ODP:** Metadata OpenDocument poskytují obecné statistiky dokumentu, jako jsou počty stránek, odstavců a slov, ale tyto hodnoty neodpovídají všem rozšířeným vlastnostem specifickým pro PowerPoint. Metadata pro skryté snímky, poznámkové snímky, multimédia, páry záhlaví a názvy částí mohou být nedostupná a vlastnosti inventáře mohou vracet výchozí hodnoty. Nerozlišujte nulovou hodnotu nebo prázdnou kolekci jako definitivní důkaz, že odpovídající obsah chybí.

Používejte lehký přístup k metadatům pro inventáře a předběžné kontroly. Načtěte prezentaci a prozkoumejte její živý model objektů, když výsledek musí odrážet změny v paměti nebo když potřebujete ověřit skutečný obsah prezentace.

## **Aktualizovat vlastnosti prezentace**

Vlastnosti vrácené metodou [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/read_document_properties/) lze také změnit, aniž byste vytvořili instanci [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/). Aplikujte změny pomocí [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/update_document_properties/) a poté zapište svázanou prezentaci pomocí [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/write_binded_presentation/).

Následující obrázek zobrazuje původní vlastnosti dokumentu.

![Původní vlastnosti dokumentu PowerPointové prezentace](input_properties.png)

Následující příklad mění název a čas posledního uložení a zapisuje výsledek do nového souboru:

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

Následující obrázek zobrazuje aktualizované vlastnosti dokumentu.

![Změněné vlastnosti dokumentu PowerPointové prezentace](output_properties.png)

## **Užitečné odkazy**

Pro související bezpečnostní kontroly a nastavení ochrany viz následující články:

- [Password-Protect Presentations](/slides/cs/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/cs/python-net/write-protected-presentation/)

## **Často kladené otázky**

**Jak mohu zkontrolovat, zda jsou písma vložena a která to jsou?**

Načtěte prezentaci a použijte [Presentation.fonts_manager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/fonts_manager/). Zavolejte [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) pro získání vložených písem a [FontsManager.get_fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_fonts/) pro získání písem použitých v prezentaci. Porovnejte oba výsledky a najděte písma, která jsou potřebná pro vykreslení, ale nejsou vložena.

**Jak rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Když jsou uložená metadata dokumentu dostačující, přečtěte [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/hidden_slides/) přes [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationfactory/get_presentation_info/) a [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/read_document_properties/). To je vhodné pro lehký inventář. Pokud byla prezentace v paměti upravena, uložená metadata mohou chybět nebo být zastaralá, nebo potřebujete ověřit živé hodnoty – iterujte přes [Presentation.slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/slides/cs/) a zkontrolujte vlastnost [Slide.hidden](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/hidden/) každého snímku.

**Mohu zjistit, zda je použita vlastní velikost snímku a orientace a zda se liší od výchozích?**

Ano. Načtěte prezentaci a přečtěte [Presentation.slide_size](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/slide_size/). Prozkoumejte [SlideSize.type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidesize/size/) a [SlideSize.orientation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidesize/orientation/) a porovnejte aktuální nastavení s očekávaným přednastavením a rozměry.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí zdroje dat?**

Ano. Najděte každý [Chart](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/) a prozkoumejte [ChartData.data_source_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/data_source_type/). Pro externí sešit přečtěte [ChartData.external_workbook_path](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Typ zdroje dat a cesta identifikují externí odkaz, ale ověření, zda je cíl dostupný, vyžaduje samostatnou kontrolu zdroje.

**Jak mohu posoudit „tíživé“ snímky, které mohou zpomalovat vykreslování nebo export do PDF?**

Neexistuje jediná vlastnost komplexnosti. Procházejte [Presentation.slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/slides/cs/) a kolekci [BaseSlide.shapes](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslide/shapes/) každého snímku. Používejte počty tvarů a přítomnost velkých obrázků, efektů, animací nebo multimédií jako signály ke skenování a změřte reprezentativní vykreslení nebo export, než označíte snímek jako potvrzený úzký hrdlo výkonu.