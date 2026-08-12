---
title: Uložit prezentace v Pythonu
linktitle: Uložit prezentace
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
- prezentace do streamu
- předdefinovaný typ zobrazení
- Strict Office Open XML formát
- režim Zip64
- obnova náhledu
- průběh ukládání
- Python
- Aspose.Slides
description: "Objevte, jak ukládat prezentace v Pythonu pomocí Aspose.Slides — export do PowerPointu nebo OpenDocumentu při zachování rozvržení, písem a efektů."
---
## **Přehled**

[Otevřít prezentaci v Pythonu](/slides/cs/python-net/open-presentation/) popisuje, jak použít třídu [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) k otevření prezentace. Tento článek vysvětluje, jak vytvářet a ukládat prezentace. Třída [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) obsahuje obsah prezentace. Ať už vytváříte prezentaci od nuly nebo upravujete existující, budete ji chtít po dokončení uložit. S Aspose.Slides for Python můžete ukládat do **souboru** nebo **stream**. Tento článek vysvětluje různé způsoby ukládání prezentace.

## **Uložit prezentace do souborů**

Uložte prezentaci do souboru voláním metody `save` třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/). Předávejte metodě název souboru a formát uložení. Následující příklad ukazuje, jak uložit prezentaci pomocí Aspose.Slides for Python.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:
    
    # Proveďte zde nějakou práci...

    # Uložte prezentaci do souboru.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Uložit prezentace do streamů**

Prezentaci můžete uložit do streamu předáním výstupního streamu metodě `save` třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/). Prezentaci lze zapsat do mnoha typů streamů. V níže uvedeném příkladu vytvoříme novou prezentaci a uložíme ji do souborového streamu.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Uložte prezentaci do streamu.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Uložit prezentace s předdefinovaným typem zobrazení**

Aspose.Slides for Python umožňuje nastavit počáteční zobrazení, které PowerPoint použije při otevření vygenerované prezentace, pomocí třídy [ViewProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/). Nastavte vlastnost `last_view` na hodnotu z výčtu [ViewType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Uložit prezentace ve formátu Strict Office Open XML**

Aspose.Slides umožňuje uložit prezentaci ve formátu Strict Office Open XML. Použijte třídu [PptxOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/pptxoptions/) a nastavte její vlastnost `conformance` při ukládání. Pokud nastavíte `Conformance.ISO_29500_2008_STRICT`, výstupní soubor se uloží ve formátu Strict Office Open XML.

Níže uvedený příklad vytvoří prezentaci a uloží ji ve formátu Strict Office Open XML.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:
    # Uložte prezentaci ve formátu Strict Office Open XML.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Uložit prezentace v Office Open XML formátu v režimu Zip64**

Soubor Office Open XML je ZIP archiv, který omezuje nekomprimovanou velikost libovolného souboru, komprimovanou velikost libovolného souboru i celkovou velikost archivu na 4 GB (2^32 bajtů) a také limituje archív na 65 535 (2^16‑1) souborů. Rozšíření formátu ZIP64 tato omezení zvyšují na 2^64.

Vlastnost [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) vám umožňuje zvolit, kdy použít rozšíření formátu ZIP64 při ukládání souboru Office Open XML.

Tato vlastnost poskytuje následující režimy:

- `IF_NECESSARY` používá rozšíření ZIP64 pouze pokud prezentace překročí výše uvedená omezení. Toto je výchozí režim.
- `NEVER` nikdy nepoužije rozšíření ZIP64.
- `ALWAYS` vždy použije rozšíření ZIP64.

Následující kód ukazuje, jak uložit prezentaci jako soubor PPTX s povolenými rozšířeními ZIP64:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
Když uložíte s `Zip64Mode.NEVER`, je vyvolána výjimka [PptxException](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pptxexception/) pokud nelze prezentaci uložit ve formátu ZIP32.
{{% /alert %}}

## **Uložit prezentace v Office Open XML formátu s úrovněmi komprese**

Při práci s velkými prezentacemi můžete upravit úroveň komprese, abyste vybalancovali velikost souboru a dobu zpracování. Podle vašich požadavků můžete upřednostnit rychlejší zpracování nebo menší výstupní soubory.

Aspose.Slides poskytuje vlastnost [PptxOptions.compression_level](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/pptxoptions/compression_level/), která umožňuje zadat úroveň komprese používanou při ukládání prezentace do formátu Office Open XML.

Dostupné úrovně komprese jsou:

- [**NONE**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/compressionlevel/): Žádná komprese. Soubory jsou uloženy beze změny.
- [**LEVEL1**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/compressionlevel/): Nejrychlejší komprese s nejnižším poměrem komprese.
- [**LEVEL2**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/compressionlevel/): Rychlejší komprese s mírně lepším poměrem než **LEVEL1**.
- [**LEVEL3**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/compressionlevel/): Poskytuje lepší kompresi než **LEVEL2** se středním dopadem na dobu zpracování.
- [**LEVEL4**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/compressionlevel/): Poskytuje lepší kompresi než **LEVEL3**.
- [**LEVEL5**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/compressionlevel/): Zlepšuje kompresi oproti **LEVEL4** s další dobou zpracování.
- [**LEVEL6**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/compressionlevel/): Standardní komprese, která nabízí dobrý poměr mezi rychlostí zpracování a velikostí souboru. Toto je *výchozí úroveň komprese*.
- [**LEVEL7**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/compressionlevel/): Poskytuje lepší kompresi než **LEVEL6** při pomalejším zpracování.
- [**LEVEL8**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/compressionlevel/): Poskytuje lepší kompresi než **LEVEL7**.
- [**LEVEL9**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/compressionlevel/): Maximální komprese. Produkuje nejmenší velikost souboru za cenu nejdelší doby zpracování.

Následující příklad demonstruje, jak uložit prezentaci jako soubor PPTX *bez komprese*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

Tento příklad ukazuje, jak uložit prezentaci jako soubor PPTX s *maximální kompresí*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **Uložit prezentace bez obnovy náhledu**

Vlastnost [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) ovládá generování náhledu při ukládání prezentace do PPTX:

- Pokud je nastavena na `True`, náhled se během ukládání obnoví. Toto je výchozí nastavení.
- Pokud je nastavena na `False`, aktuální náhled se zachová. Pokud prezentace nemá žádný náhled, žádný se nevytvoří.

V níže uvedeném kódu je prezentace uložena do PPTX bez obnovení náhledu.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
Tato volba pomáhá snížit dobu potřebnou k uložení prezentace ve formátu PPTX.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose vyvinulo [bezplatnou aplikaci PowerPoint Splitter](https://products.aspose.app/slides/cs/splitter) využívající vlastní API. Aplikace umožňuje rozdělit prezentaci do více souborů uložení vybraných snímků jako nové soubory PPTX nebo PPT.
{{% /alert %}}

## **Často kladené otázky**

**Je podporováno „rychlé ukládání“ (inkrementální ukládání), aby se zapisovaly jen změny?**

Ne. Při ukládání se pokaždé vytvoří celý cílový soubor; inkrementální „rychlé ukládání“ není podporováno.

**Je ukládání stejné instance Presentation z více vláken bezpečné?**

Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) není thread‑safe; ukládejte ji z jednoho vlákna.

**Co se stane s hypertextovými odkazy a externě propojenými soubory při ukládání?**

[Hypertextové odkazy](/slides/cs/python-net/manage-hyperlinks/) jsou zachovány. Externě propojené soubory (např. videa pomocí relativních cest) nejsou automaticky zkopírovány — zajistěte, aby odkazy na cesty zůstaly přístupné.

**Mohu nastavit/uložit metadata dokumentu (Autor, Název, Společnost, Datum)?**

Ano. Standardní [vlastnosti dokumentu](/slides/cs/python-net/presentation-properties/) jsou podporovány a budou při uložení zapsány do souboru.