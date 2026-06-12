---
title: Master snímek
type: docs
weight: 30
url: /cs/python-net/examples/elements/master-slide/
keywords:
- master snímek
- přidat master snímek
- přístup k master snímku
- odstranit master snímek
- nepoužívaný master snímek
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Spravujte master snímky v Pythonu pomocí Aspose.Slides: vytvářejte, upravujte, klonujte a formátujte motivy, pozadí a zástupce, aby byly snímky v PowerPointu a OpenDocumentu jednotné."
---
Master snímky tvoří nejvyšší úroveň hierarchie dědičnosti snímků v PowerPointu. **master snímek** definuje společné designové prvky, jako jsou pozadí, loga a formátování textu. **rozložení snímků** dědí z master snímků a **normální snímky** dědí z rozložení snímků.

Tento článek ukazuje, jak vytvářet, upravovat a spravovat master snímky pomocí Aspose.Slides pro Python přes .NET.

## **Přidat master snímek**

Tento příklad ukazuje, jak vytvořit nový master snímek klonováním výchozího.

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # Naklonujte výchozí master snímek.
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** Master snímky poskytují způsob, jak aplikovat konzistentní značku nebo sdílené designové prvky na všechny snímky. Jakékoli změny provedené v masteru se automaticky projeví v závislých rozložení a normálních snímcích.  
> 
> 💡 **Tip 2:** Jakékoli tvary nebo formátování přidané do master snímku jsou děděny rozloženími snímků a následně všemi normálními snímky používajícími tato rozložení. Obrázek níže ilustruje, jak je textové pole přidané do master snímku automaticky vykresleno na finálním snímku.  
> 
> ![Příklad dědičnosti masteru](master-slide-banner.png)

## **Přístup k master snímku**

Master snímky můžete získat pomocí kolekce `Presentation.masters`. Zde je návod, jak je načíst a s nimi pracovat:

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # Přístup k prvnímu master snímku.
        first_master_slide = presentation.masters[0]
```

## **Odstranit master snímek**

Master snímky lze odstranit buď podle indexu, nebo podle reference.

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Odstranit podle indexu.
        presentation.masters.remove_at(0)

        # Nebo odstranit podle reference.
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Odstranit nepoužívané master snímky**

Některé prezentace obsahují master snímky, které nejsou používány. Odstraněním těchto snímků můžete snížit velikost souboru.

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Odstranit všechny nepoužívané master snímky (i ty označené jako Preserve).
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **Tip:** Použijte `remove_unused(True)`, abyste vyčistili nepoužívané master snímky a minimalizovali velikost prezentace.