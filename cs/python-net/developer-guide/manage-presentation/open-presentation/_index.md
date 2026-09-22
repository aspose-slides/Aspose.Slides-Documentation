---
title: Otevření prezentací v Pythonu
linktitle: Otevření prezentací
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
description: "Naučte se, jak v Pythonu otevřít prezentace PowerPoint a OpenDocument, zadat otevírací hesla a snížit využití paměti pomocí Aspose.Slides pro Python via .NET."
---
## **Úvod**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/cs/python-net/) může načítat prezentace PowerPoint a OpenDocument ze souborů a proudů. Po načtení prezentace můžete prozkoumat její strukturu, upravovat snímky, spravovat zdroje a uložit ji v původním nebo jiném podporovaném formátu.

Chování načítání lze upravit pomocí třídy [LoadOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/). Například můžete zadat otevírací heslo, uchovávat velké binární objekty mimo paměť nebo vynechat vložená binární data.

## **Otevření prezentací**

Po načtení souboru nebo proudu můžete určit jeho původní formát prezentace a rozhodnout, jak jej vaše aplikace zpracuje.

Pro otevření existující prezentace předáte její cestu k souboru konstruktoru [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/). Použijte příkaz `with`, aby souborové handle, dočasná data a další zdroje byly okamžitě uvolněny.

Následující příklad v Pythonu ukazuje, jak otevřít prezentaci a získat počet snímků:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Otevření prezentací chráněných heslem**

Otevírací heslo šifruje obsah prezentace. Pro načtení celé prezentace přiřaďte správné heslo k [LoadOptions.password](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/password/) a předáte možnosti konstruktoru [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/). Načtení selže, pokud heslo chybí nebo je nesprávné.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Pro detekci hesla, ověřování a šifrovací pracovní postupy viz [Password-Protect Presentations](/slides/cs/python-net/password-protected-presentation/). Pokud byla šifrovaná prezentace úmyslně uložena s veřejnými vlastnostmi dokumentu, lze tyto vlastnosti přečíst bez hesla; viz [Manage Presentation Properties](/slides/cs/python-net/presentation-properties/).

## **Otevření velkých prezentací**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/blob_management_options/) řídí, jak Aspose.Slides zachází s binárními velkými objekty, jako jsou obrázky, audio a video. Můžete nechat zdrojový soubor zamčený, povolit dočasné soubory a omezit množství BLOB dat uchovávaných v paměti.

Tento Python kód demonstruje načítání velké prezentace (například 2 GB):

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

{{% alert color="info" title="Note" %}}
S `PresentationLockingBehavior.KEEP_LOCKED` zůstává zdrojový soubor zamčený, dokud není objekt `Presentation` uvolněn. Nepřesouvejte, nepřepisujte ani neodstraňujte zdrojový soubor, dokud je tento objekt aktivní.

Aspose.Slides může při načítání zkopírovat obsah vstupního proudu. U velkých prezentací je proto cesta k souboru obecně efektivnější než proud. Viz [Manage BLOBs](/slides/cs/python-net/manage-blob/) pro další možnosti úložiště a správy paměti.
{{% /alert %}}

## **Načtení prezentací bez vložených binárních objektů**

Prezentace může obsahovat vložená binární data, která aplikace nepotřebuje nebo nechce uchovávat. Příklady zahrnují:

- projekty VBA, dostupné prostřednictvím [Presentation.vba_project](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/vba_project/);
- vložená data OLE, dostupná prostřednictvím [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- data ovládacích prvků ActiveX, dostupná prostřednictvím [Control.active_x_control_binary](https://reference.aspose.com/slides/cs/python-net/aspose.slides/control/active_x_control_binary/).

Nastavte [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) na `True`, aby se tato binární data během načítání odstranila. Uložte načtenou prezentaci, aby se zachoval sanitovaný výsledek.

Tato možnost snižuje riziko nechtěných vložených nákladů, ale není kompletním systémem pro detekci malwaru ani sanitaci obsahu.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Jak zjistím, že soubor je poškozený a nelze jej otevřít?**

Aspose.Slides vyvolá během načítání výjimku parsování nebo formátu. Tuto chybu ošetřete odděleně od chyby nesprávného hesla, aby aplikace mohla přesně oznámit příčinu.

**Co se stane, pokud chybí požadovaná písma?**

Prezentace se stále může načíst, ale při vykreslování a exportu může dojít k nahrazení písem. Můžete [konfigurovat náhradu písem](/slides/cs/python-net/font-substitution/) nebo [poskytnout vlastní písma](/slides/cs/python-net/custom-font/), aby byl výstup předvídatelnější.

**Načítá se při načítání prezentace také její vložená média?**

Vložený audio a video jsou dostupné prostřednictvím objektového modelu prezentace. Externí zdroje jsou řešeny podle výchozího chování načítání zdrojů a mohou být nedostupné, pokud není možné přistupovat k jejich umístěním.