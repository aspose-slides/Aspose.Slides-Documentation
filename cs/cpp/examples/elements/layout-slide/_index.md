---
title: Layout snímek
type: docs
weight: 20
url: /cs/cpp/examples/elements/layout-slide/
keywords:
- příklad kódu
- layout snímek
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Ovládejte layout snímky v Aspose.Slides pro C++: vybírejte, aplikujte a přizpůsobujte rozvržení snímků, zástupné prvky a hlavní rozvržení pomocí příkladů v C++ pro prezentace PPT, PPTX a ODP."
---
Tento článek ukazuje, jak pracovat s **Layout Slides** v Aspose.Slides pro C++. Layout snímek určuje design a formátování, které dědí normální snímky. Můžete přidávat, přistupovat, klonovat a odstraňovat layout snímky, stejně jako čistit nepoužívané, abyste snížili velikost prezentace.

## **Přidat layout snímku**

Můžete vytvořit vlastní layout snímku, který definuje znovupoužitelné formátování. Například můžete přidat textové pole, které se zobrazí na všech snímcích používajících tento layout.

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // Vytvořte layout snímku s prázdným typem rozvržení a vlastním názvem.
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // Přidejte textové pole do layout snímku.
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // Přidejte dva snímky pomocí tohoto layoutu; oba zdědí text z layoutu.
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Note 1:** Layout snímky fungují jako šablony pro jednotlivé snímky. Společné prvky můžete definovat jednou a znovu je použít v mnoha snímcích.

> 💡 **Note 2:** Když přidáte tvary nebo text do layout snímku, všechny snímky založené na tomto layoutu automaticky zobrazí tento sdílený obsah.  
> Níže uvedený snímek ukazuje dva snímky, z nichž každý dědí textové pole ze stejného layout snímku.

![Snímky dědící obsah layoutu](layout-slide-result.png)

## **Přístup k layout snímku**

K layout snímkům lze přistupovat podle indexu nebo podle typu layoutu (např. `Blank`, `Title`, `SectionHeader` atd.).

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Přístup k layout snímku podle indexu.
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // Přístup k layout snímku podle typu.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **Odstranit layout snímku**

Můžete odstranit konkrétní layout snímku, pokud již není potřeba.

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Získejte layout snímku podle typu a odstraňte ji.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **Odstranit nepoužité layout snímky**

Aby se snížila velikost prezentace, můžete chtít odstranit layout snímky, které nejsou použity žádnými normálními snímky.

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Automaticky odstraňuje všechny layout snímky, které nejsou referencovány žádným snímkem.
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **Klonovat layout snímku**

Můžete duplikovat layout snímku pomocí metody `AddClone`.

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Získejte existující layout snímek podle typu.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // Klonujte layout snímek na konec kolekce layout snímků.
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅ **Summary:** Layout snímky jsou výkonným nástrojem pro správu konzistentního formátování napříč snímky. Aspose.Slides poskytuje plnou kontrolu nad vytvářením, správou a optimalizací layout snímků.