---
title: Převod snímků PowerPoint do PNG v Pythonu
linktitle: Snímek do PNG
type: docs
weight: 30
url: /cs/python-net/convert-powerpoint-to-png/
keywords:
- převést PowerPoint do PNG
- převést prezentaci do PNG
- převést snímek do PNG
- převést PPT do PNG
- převést PPTX do PNG
- převést ODP do PNG
- PowerPoint do PNG
- prezentace do PNG
- snímek do PNG
- PPT do PNG
- PPTX do PNG
- ODP do PNG
- Python
- Aspose.Slides
description: "Převádějte prezentace PowerPoint a OpenDocument na vysoce kvalitní PNG obrázky rychle pomocí Aspose.Slides for Python via .NET, což zajišťuje přesné a automatizované výsledky."
---
## **Přehled**

Aspose.Slides for Python via .NET usnadňuje převod prezentací PowerPoint do PNG. Načtete prezentaci, projdete její snímky, vykreslíte každý na rastrový obrázek a výsledek uložíte jako soubory PNG. To je ideální pro vytváření náhledů snímků, vkládání snímků do webových stránek nebo tvorbu statických zdrojů pro další zpracování.

## **Převod snímků do PNG**

Tato sekce ukazuje nejjednodušší možný příklad převodu prezentace PowerPoint na obrázky PNG pomocí Aspose.Slides for Python via .NET.

Postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte snímek ze sbírky `Presentation.slides` (viz třída [Slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/)).
1. Použijte metodu `Slide.get_image` pro vytvoření miniatury snímku.
1. Použijte metodu `Presentation.save` pro uložení miniatury snímku ve formátu PNG.

Tento kód v Pythonu ukazuje, jak převést prezentaci PowerPoint do PNG:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Převod snímků do PNG se vlastními rozměry**

Pro export snímků do PNG v vlastní měřítku zavolejte `Slide.get_image` s horizontálními a vertikálními faktory měřítka. Tyto násobitele mění velikost výstupu relativně k původním rozměrům snímku – například `2.0` zdvojnásobí jak šířku, tak výšku. Použijte stejné hodnoty pro `scale_x` a `scale_y`, aby byl zachován poměr stran.

Tento kód v Pythonu demonstruje popsanou operaci:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Převod snímků do PNG s vlastním rozměrem**

Pokud chcete vytvořit soubory PNG s konkrétními rozměry, zadejte požadované hodnoty `width` a `height`. Níže uvedený kód ukazuje, jak převést PowerPoint do PNG při specifikaci velikosti obrázku:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert title="Tip" color="primary" %}}

Můžete zkusit bezplatné **převodníky PowerPoint na PNG** od Aspose —[PPTX to PNG](https://products.aspose.app/slides/cs/conversion/pptx-to-png) a [PPT to PNG](https://products.aspose.app/slides/cs/conversion/ppt-to-png). Poskytují živou implementaci procesu popsaného na této stránce.

{{% /alert %}}

## **Často kladené otázky**

**Jak mohu exportovat pouze konkrétní tvar (např. graf nebo obrázek) místo celého snímku?**

Aspose.Slides podporuje [generování miniatur pro jednotlivé tvary](/slides/cs/python-net/create-shape-thumbnails/); můžete vykreslit tvar do PNG obrázku.

**Je paralelní převod podporován na serveru?**

Ano, ale [nesdílejte](/slides/cs/python-net/multithreading/) jedinou instanci prezentace napříč vlákny. Použijte samostatnou instanci pro každé vlákno nebo proces.

**Jaká jsou omezení zkušební verze při exportu do PNG?**

Režim zkušební verze přidává vodoznak do výstupních obrázků a uplatňuje [další omezení](/slides/cs/python-net/licensing/), dokud není licence použita.