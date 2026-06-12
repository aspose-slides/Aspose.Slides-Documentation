---
title: Rozložení snímku
type: docs
weight: 20
url: /cs/python-net/examples/elements/layout-slide/
keywords:
- rozložení snímku
- přidat rozložení snímku
- přístup k rozložení snímku
- odstranit rozložení snímku
- nepoužívané rozložení snímku
- klonovat rozložení snímku
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Použijte Python k správě rozložení snímků pomocí Aspose.Slides: vytvářejte, aplikujte, klonujte, přejmenovávejte a přizpůsobujte zástupce a motivy v prezentacích pro PPT, PPTX a ODP."
---
Tento článek ukazuje, jak pracovat s **Layout Slides** v Aspose.Slides pro Python prostřednictvím .NET. Rozložení snímku definuje design a formátování, které dědí běžné snímky. Můžete přidávat, přistupovat, klonovat a odstraňovat rozložení snímků a také čistit nepoužívaná, aby se snížila velikost prezentace.

## **Přidat rozložení snímku**

Můžete vytvořit vlastní rozložení snímku pro definování opakovaně použitelného formátování.

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # Vytvořte rozložení snímku se zadaným typem a názvem.
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** Rozložení snímků fungují jako šablony pro jednotlivé snímky. Můžete definovat společné prvky jednou a znovu je použít v mnoha snímcích.
> 
> 💡 **Tip 2:** Když přidáte tvary nebo text do rozložení snímku, všechny snímky založené na tomto rozložení automaticky zobrazí tento sdílený obsah.  
> Níže uvedený snímek ukazuje dva snímky, z nichž každý dědí textové pole ze stejného rozložení snímku.

![Snímky dědící obsah rozložení](layout-slide-result.png)

## **Přístup k rozložení snímku**

K rozložení snímků lze přistupovat podle indexu nebo podle typu rozložení (např. `Blank`, `Title`, `SectionHeader` atd.).

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Přístup podle indexu.
        first_layout_slide = presentation.layout_slides[0]

        # Přístup podle typu rozložení.
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **Odstranit rozložení snímku**

Můžete odstranit konkrétní rozložení snímku, pokud již není potřeba.

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Získat rozložení snímku podle typu a odstranit jej.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Odstranit nepoužívaná rozložení snímků**

Pro snížení velikosti prezentace můžete chtít odstranit rozložení snímků, která nejsou používána žádnými běžnými snímky.

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Automaticky odstraní všechna rozložení snímků, na která není žádný snímek odkaz.
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonovat rozložení snímku**

Můžete duplikovat rozložení snímku pomocí metody `AddClone`.

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Získat existující rozložení snímku podle typu.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Klonovat rozložení snímku na konec kolekce rozložení snímků.
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **Shrnutí:** Rozložení snímků jsou výkonné nástroje pro správu konzistentního formátování napříč snímky. Aspose.Slides umožňuje plnou kontrolu nad vytvářením, správou a optimalizací rozložení snímků.