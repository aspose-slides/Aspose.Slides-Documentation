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
description: "Jednoduše otevřete prezentace PowerPoint (.pptx, .ppt) a OpenDocument (.odp) pomocí Aspose.Slides pro Python přes .NET — rychlé, spolehlivé, plně vybavené."
---
## **Úvod**

Kromě vytváření prezentací PowerPoint od nuly vám Aspose.Slides také umožňuje otevírat existující prezentace. Po načtení prezentace můžete získat o ní informace, upravovat obsah snímků, přidávat nové snímky, odstraňovat existující a další.

## **Otevření prezentací**

Chcete-li otevřít existující prezentaci, vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a do jejího konstruktoru předávejte cestu k souboru.

Následující příklad v Pythonu ukazuje, jak otevřít prezentaci a získat počet snímků:

```python
import aspose.slides as slides

# Vytvořte instanci třídy Presentation a předávejte cestu k souboru do jejího konstruktoru.
with slides.Presentation("sample.pptx") as presentation:
    # Vytiskněte celkový počet snímků v prezentaci.
    print(presentation.slides.length)
```

## **Otevření prezentací chráněných heslem**

Když potřebujete otevřít prezentaci chráněnou heslem, předávejte heslo prostřednictvím vlastnosti [password](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/password/) třídy [LoadOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/) pro dešifrování a načtení. Následující kód v Pythonu ukazuje tuto operaci:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # Proveďte operace na dešifrované prezentaci.
```

## **Otevření velkých prezentací**

Aspose.Slides poskytuje možnosti – zejména vlastnost [blob_management_options](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/blob_management_options/) ve třídě [LoadOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/) – která vám pomůže načíst velké prezentace.

Tento kód v Pythonu ukazuje načtení velké prezentace (například 2 GB):

```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# Vyberte chování KeepLocked — soubor prezentace zůstane uzamčen po celou dobu životnosti 
# instance Presentation, ale není nutné jej načítat do paměti ani kopírovat do dočasného souboru.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # Velká prezentace byla načtena a může být použita, přičemž spotřeba paměti zůstává nízká.

    # Proveďte změny v prezentaci.
    presentation.slides[0].name = "Large presentation"

    # Uložte prezentaci do jiného souboru. Spotřeba paměti zůstává během této operace nízká.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # Nedělejte to! Dojde k vyhození výjimky I/O, protože soubor je uzamčen, dokud není objekt prezentace uvolněn.
    os.remove(file_path)

# Je v pořádku to provést zde. Zdrojový soubor již není uzamčen objektem prezentace.
os.remove(file_path)
```

{{% alert color="info" title="Info" %}}
Aby se obešly některé omezení při práci se streamy, Aspose.Slides může zkopírovat obsah streamu. Načtení velké prezentace ze streamu způsobí kopírování prezentace a může zpomalit načítání. Proto, když potřebujete načíst velkou prezentaci, důrazně doporučujeme používat cestu k souboru prezentace místo streamu.

Při vytváření prezentace, která obsahuje velké objekty (video, audio, vysoce rozlišení obrázky atd.), můžete použít [BLOB management](/slides/cs/python-net/manage-blob/) ke snížení spotřeby paměti.
{{%/alert %}}

## **Načtení prezentací bez vložených binárních objektů**

Prezentace PowerPoint může obsahovat následující typy vložených binárních objektů:

- Projekt VBA (přístupný přes [Presentation.vba_project](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/vba_project/));
- Data vloženého OLE objektu (přístupná přes [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- Binární data ovládacího prvku ActiveX (přístupná přes [Control.active_x_control_binary](https://reference.aspose.com/slides/cs/python-net/aspose.slides/control/active_x_control_binary/)).

Pomocí vlastnosti [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) můžete načíst prezentaci bez jakýchkoli vložených binárních objektů.

Tato vlastnost je užitečná pro odstraňování potenciálně škodlivého binárního obsahu. Následující kód v Pythonu ukazuje, jak načíst prezentaci bez jakéhokoli vloženého binárního obsahu:

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # Proveďte operace na prezentaci.
```

## **Často kladené otázky**

**Jak poznám, že je soubor poškozený a nelze jej otevřít?**

Během načítání získáte výjimku při parsování/validaci formátu. Takové chyby často uvádějí neplatnou strukturu ZIP nebo poškozené záznamy PowerPoint.

**Co se stane, když při otevírání chybí požadované fonty?**

Soubor se otevře, ale později může [rendering/export](/slides/cs/python-net/convert-presentation/) nahradit fonty. [Nastavit náhrady fontů](/slides/cs/python-net/font-substitution/) nebo [přidat požadované fonty](/slides/cs/python-net/custom-font/) do runtime prostředí.

**Co se stane s vloženými médii (video/audio) při otevírání?**

Stanou se dostupnými jako zdroje prezentace. Pokud jsou média odkazována externími cestami, zajistěte, aby byly tyto cesty ve vašem prostředí přístupné; jinak může [rendering/export](/slides/cs/python-net/convert-presentation/) média vynechat.