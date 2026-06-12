---
title: Ukládání prezentací v Pythonu
linktitle: Ukládání prezentací
type: docs
weight: 80
url: /cs/python-net/save-presentation/
keywords:
- uložit PowerPoint
- uložit OpenDocument
- uložit prezentaci
- uložit snímek
- uložit PPT
- uložit PPTX
- uložit ODP
- prezentace do souboru
- prezentace do proudu
- předdefinovaný typ zobrazení
- striktní formát Office Open XML
- režim Zip64
- obnovování náhledu
- postup ukládání
- Python
- Aspose.Slides
description: "Objevte, jak ukládat prezentace v Pythonu pomocí Aspose.Slides — exportovat do PowerPointu nebo OpenDocumentu při zachování rozvržení, písem a efektů."
---
## **Přehled**

[Otevřít prezentaci v Pythonu](/slides/cs/python-net/open-presentation/) popisuje, jak použít třídu [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) k otevření prezentace. Tento článek vysvětluje, jak vytvářet a ukládat prezentace. Třída [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) obsahuje obsah prezentace. Ať už vytváříte prezentaci od začátku nebo upravujete existující, budete ji chtít uložit po dokončení. S Aspose.Slides pro Python můžete uložit do **souboru** nebo **proudu**. Tento článek popisuje různé způsoby uložení prezentace.

## **Uložení prezentací do souborů**

Uložte prezentaci do souboru voláním metody `save` třídy [Presentation]. Předáte název souboru a formát uložení metodě. Následující příklad ukazuje, jak uložit prezentaci pomocí Aspose.Slides pro Python.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:
    
    # Proveďte zde nějakou práci...

    # Uložte prezentaci do souboru.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Uložení prezentací do proudů**

Můžete uložit prezentaci do proudu předáním výstupního proudu metodě `save` třídy [Presentation]. Prezentaci lze zapisovat do mnoha typů proudů. V níže uvedeném příkladu vytvoříme novou prezentaci, přidáme text do tvaru a uložíme ji do proudu.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Uložte prezentaci do proudu.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Uložení prezentací s předdefinovaným typem zobrazení**

Aspose.Slides pro Python umožňuje nastavit počáteční zobrazení, které PowerPoint použije při otevření vygenerované prezentace, pomocí třídy [ViewProperties]. Nastavte vlastnost `last_view` na hodnotu z výčtu [ViewType].

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Uložení prezentací ve striktním formátu Office Open XML**

Aspose.Slides vám umožňuje uložit prezentaci ve striktním formátu Office Open XML. Použijte třídu [PptxOptions] a při ukládání nastavte její vlastnost conformance. Pokud nastavíte `Conformance.ISO_29500_2008_STRICT`, výstupní soubor se uloží ve striktním formátu Office Open XML.

Níže uvedený příklad vytvoří prezentaci a uloží ji ve striktním formátu Office Open XML.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:
    # Uložte prezentaci ve striktním formátu Office Open XML.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Uložení prezentací ve formátu Office Open XML v režimu Zip64**

Soubor Office Open XML je archiv ZIP, který uvalí limity 4 GB (2^32 bajtů) na nekomprimovanou velikost jakéhokoli souboru, komprimovanou velikost jakéhokoli souboru a celkovou velikost archivu, a také omezuje archiv na 65 535 (2^16‑1) souborů. Rozšíření formátu ZIP64 tuto omezení zvyšují na 2^64.

Vlastnost [PptxOptions.zip_64_mode] vám umožňuje zvolit, kdy použít rozšíření formátu ZIP64 při ukládání souboru Office Open XML.

Tato vlastnost poskytuje následující režimy:

- `IF_NECESSARY` používá rozšíření formátu ZIP64 pouze pokud prezentace překročí výše uvedená omezení. Toto je výchozí režim.
- `NEVER` nikdy nepoužívá rozšíření formátu ZIP64.
- `ALWAYS` vždy používá rozšíření formátu ZIP64.

Následující kód ukazuje, jak uložit prezentaci jako PPTX s povolenými rozšířeními formátu ZIP64:

```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
Když ukládáte s `Zip64Mode.NEVER`, je vyvolána výjimka [PptxException], pokud prezentaci nelze uložit ve formátu ZIP32.
{{% /alert %}}

## **Uložení prezentací bez obnovování náhledu**

Vlastnost [PptxOptions.refresh_thumbnail] řídí generování náhledu při ukládání prezentace do PPTX:

- Pokud je nastavena na `True`, náhled se při ukládání obnoví. Toto je výchozí nastavení.
- Pokud je nastavena na `False`, aktuální náhled se zachová. Pokud prezentace nemá náhled, žádný se nevygeneruje.

V níže uvedeném kódu je prezentace uložena do PPTX bez obnovení jejího náhledu.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
Tato možnost pomáhá snížit čas potřebný k uložení prezentace ve formátu PPTX.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose vyvinulo [bezplatnou aplikaci PowerPoint Splitter](https://products.aspose.app/slides/cs/splitter) pomocí svého vlastního API. Aplikace vám umožňuje rozdělit prezentaci do více souborů tím, že uloží vybrané snímky jako nové soubory PPTX nebo PPT.
{{% /alert %}}

## **Často kladené otázky**

**Je podporováno “rychlé ukládání” (inkrementální ukládání), takže se zapisují jen změny?**

Ne. Ukládání pokaždé vytvoří celý cílový soubor; inkrementální „rychlé ukládání“ není podporováno.

**Je bezpečné z více vláken ukládat stejnou instanci Presentation?**

Ne. Instance [Presentation] [není thread-safe](/slides/cs/python-net/multithreading/); ukládejte ji z jednoho vlákna.

**Co se stane s hypertextovými odkazy a externě propojenými soubory při ukládání?**

[Hyperlinks](/slides/cs/python-net/manage-hyperlinks/) jsou zachovány. Externě propojené soubory (např. videa pomocí relativních cest) nejsou automaticky zkopírovány — ujistěte se, že odkazované cesty zůstávají přístupné.

**Mohu nastavit/uložit metadata dokumentu (Author, Title, Company, Date)?**

Ano. Standardní [document properties](/slides/cs/python-net/presentation-properties/) jsou podporovány a budou při ukládání zapsány do souboru.