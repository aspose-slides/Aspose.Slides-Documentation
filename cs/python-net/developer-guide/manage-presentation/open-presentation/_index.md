---
title: Otevření prezentací v Pythonu
linktitle: Otevřít prezentace
type: docs
weight: 20
url: /cs/python-net/open-presentation/
keywords:
- otevřít PowerPoint
- otevřít prezentaci
- otevřít PPTX
- otevřít PPT
- otevřít ODP
- načíst prezentaci
- načíst PPTX
- načíst PPT
- načíst ODP
- chráněná prezentace
- velká prezentace
- externí zdroj
- binární objekt
- Python
- Aspose.Slides
description: "Naučte se, jak v Pythonu otevírat prezentace PowerPoint a OpenDocument, zadávat otevírací hesla a snižovat spotřebu paměti pomocí Aspose.Slides pro Python via .NET."
---
## **Úvod**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/cs/python-net/) může načíst prezentace PowerPoint a OpenDocument ze souborů a proudů. Po načtení prezentace můžete prozkoumat její strukturu, upravovat snímky, spravovat zdroje a uložit ji v původním nebo jiném podporovaném formátu.

Chování načítání lze přizpůsobit pomocí třídy [LoadOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/). Například můžete zadat otevírací heslo, udržovat velké binární objekty mimo paměť nebo vynechat vložená binární data.

## **Otevření prezentací**

Pro otevření existující prezentace předáte její cestu k souboru konstruktoru [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/). Použijte `with` blok, aby byly souborové handlery, dočasná data a další zdroje rychle uvolněny.

Následující příklad v Pythonu ukazuje, jak otevřít prezentaci a zjistit počet snímků:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Otevírání prezentací chráněných heslem**

Otevírací heslo šifruje obsah prezentace. Pro načtení celé prezentace přiřaďte správné heslo k [LoadOptions.password](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/password/) a předávejte možnosti konstruktoru [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/). Načtení selže, pokud heslo chybí nebo je nesprávné.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Pro detekci hesla, jeho validaci a šifrovací pracovní toky viz [Password-Protect Presentations](/slides/cs/python-net/password-protected-presentation/). Pokud byla šifrovaná prezentace úmyslně uložena s veřejnými vlastnostmi dokumentu, lze tyto vlastnosti číst bez hesla; viz [Manage Presentation Properties](/slides/cs/python-net/presentation-properties/).

## **Otevírání velkých prezentací**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/blob_management_options/) řídí, jak Aspose.Slides zachází s velkými binárními objekty, jako jsou obrázky, audio a video. Můžete udržet zdrojový soubor uzamčený, povolit dočasné soubory a omezit množství BLOB dat uchovávaných v paměti.

Tento kód v Pythonu demonstruje načtení velké prezentace (například 2 GB):

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Poznámka" %}}
S `PresentationLockingBehavior.KEEP_LOCKED` zůstává zdrojový soubor uzamčený, dokud není uvolněn objekt `Presentation`. Nepřesouvejte, nepřepisujte ani neodstraňujte zdrojový soubor, dokud je tento objekt aktivní.

Aspose.Slides může při načítání kopírovat obsah vstupního proudu. U velkých prezentací je proto cesta k souboru obecně efektivnější než proud. Viz [Manage BLOBs](/slides/cs/python-net/manage-blob/) pro další možnosti úložiště a správy paměti.
{{% /alert %}}

## **Načtení prezentací bez vložených binárních objektů**

Prezentace může obsahovat vložená binární data, která aplikace nepotřebuje nebo nechce zachovat. Příklady zahrnují:
- VBA projekty, dostupné přes [Presentation.vba_project](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/vba_project/);
- vložená data OLE, dostupná přes [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- data ovládacích prvků ActiveX, dostupná přes [Control.active_x_control_binary](https://reference.aspose.com/slides/cs/python-net/aspose.slides/control/active_x_control_binary/).

Nastavte [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) na `True`, aby se při načítání odstranila tato binární data. Uložte načtenou prezentaci, aby se výsledek sanitizoval.

Tato možnost snižuje riziko nechtěných vložených nákladů, ale nejde o kompletní systém pro detekci malwaru nebo sanitaci obsahu.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Jak zjistím, že je soubor poškozený a nelze jej otevřít?**

Aspose.Slides během načítání vyvolá výjimku při parsování nebo formátu. Tento selhání ošetřete odděleně od chyby nesprávného hesla, aby aplikace mohla přesně zpravit příčinu.

**Co se stane, pokud chybí požadovaná písma?**

Prezentace se stále může načíst, ale při vykreslování a exportu mohou být písma nahrazena. Můžete [konfigurovat substituci písem](/slides/cs/python-net/font-substitution/) nebo [poskytnout vlastní písma](/slides/cs/python-net/custom-font/) pro predikovatelnější výstup.

**Načítá načtení prezentace také její vložená média?**

Vložený audio a video jsou dostupné prostřednictvím objektového modelu prezentace. Externí zdroje jsou řešeny podle výchozího chování načítání zdrojů a mohou být nedostupné, pokud nelze získat přístup k jejich umístěním.