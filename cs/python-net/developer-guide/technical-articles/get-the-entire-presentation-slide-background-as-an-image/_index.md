---
title: Získat celé pozadí snímku z prezentace jako obrázek
linktitle: Celé pozadí snímku
type: docs
weight: 95
url: /cs/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- snímek
- pozadí
- pozadí snímku
- konečné pozadí
- pozadí na obrázek
- PowerPoint
- OpenDocument
- prezentace
- PPT
- PPTX
- ODP
- Python
- Aspose.Slides
description: "Extrahujte úplná pozadí snímků jako obrázky z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes .NET, zjednodušující vizuální workflow."
---
## **Přehled**

V prezentacích PowerPoint může pozadí snímku být složeno z více prvků, včetně obrázku pozadí snímku, motivu prezentace, barevného schématu a objektů umístěných na hlavním snímku nebo rozvržení snímku.

Tento článek ukazuje, jak pomocí Aspose.Slides extrahovat celé pozadí snímku jako obrázek. Protože neexistuje jediná metoda pro tento úkol, postup zahrnuje klonování vybraného snímku do dočasné prezentace, odstranění tvarů snímku a následnou konverzi vzniklého pozadí snímku na obrázek.

## **Získání celého pozadí snímku**

Aspose.Slides pro Python neposkytuje jednoduchou metodu pro extrahování celého pozadí snímku prezentace jako obrázku, ale můžete postupovat podle níže uvedených kroků:
1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte velikost snímku z prezentace.
1. Vyberte snímek.
1. Vytvořte dočasnou prezentaci.
1. Nastavte stejnou velikost snímku v dočasné prezentaci.
1. Klonujte vybraný snímek do dočasné prezentace.
1. Odstraňte tvary z klonovaného snímku.
1. Převěšte klonovaný snímek na obrázek.

Následující ukázkový kód extrahuje celé pozadí snímku prezentace jako obrázek.
```py
slide_index = 0
image_scale = 1

with slides.Presentation("sample.pptx") as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[slide_index]

    with slides.Presentation() as temp_presentation:
        temp_presentation.slide_size.set_size(
            slide_size.width, slide_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)

        cloned_slide = temp_presentation.slides.add_clone(slide)
        cloned_slide.shapes.clear()

        with cloned_slide.get_image(image_scale, image_scale) as background:
            background.save("output.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Zůstanou složité přechody, textury nebo výplně obrázky z hlavního snímku zachovány v výsledném obrázku pozadí?**

Ano. Aspose.Slides vykresluje přechodové, obrázkové a texturové výplně definované na snímku, rozvržení nebo hlavním snímku. Pokud potřebujete oddělit vzhled od zděděných hlav, [nastavte vlastní pozadí](/slides/cs/python-net/presentation-background/) na aktuálním snímku před exportem.

**Mohu přidat vodoznak do výsledného obrázku pozadí před jeho uložením?**

Ano. Můžete [přidat vodoznak](/slides/cs/python-net/watermark/) jako tvar nebo obrázek na pracovní [kopii snímku](/slides/cs/python-net/clone-slides/) (umístěnou za ostatní obsah) a poté exportovat. To vám umožní vytvořit obrázek pozadí s vodoznakem zakomponovaným.

**Mohu získat pozadí pro konkrétní rozvržení nebo hlavní snímek bez přiřazení k existujícímu snímku?**

Ano. Přistupte k požadovanému hlavnímu snímku nebo rozvržení, aplikujte jej na [dočasný snímek](/slides/cs/python-net/clone-slides/) s požadovanou velikostí a exportujte tento snímek, abyste získali pozadí odvozené od tohoto rozvržení nebo hlavního snímku.

**Existují licenční omezení, která ovlivňují export obrázků?**

Funkce renderování jsou plně dostupné s [platnou licencí](/slides/cs/python-net/licensing/). V evaluačním režimu může výstup obsahovat omezení, například vodoznak. Aktivujte licenci jednou na proces před prováděním hromadných exportů.