---
title: Master snímek
type: docs
weight: 30
url: /cs/cpp/examples/elements/master-slide/
keywords:
- ukázka kódu
- master snímek
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Prozkoumejte příklady master snímků v Aspose.Slides pro C++: vytvářejte, upravujte a stylizujte master snímky, zástupce a motivy v PPT, PPTX a ODP s přehledným C++ kódem."
---
Master snímky tvoří nejvyšší úroveň hierarchie dědičnosti snímků v PowerPointu. **Master snímek** definuje společné designové prvky, jako jsou pozadí, loga a formátování textu. **Rozvržení snímků** dědí z master snímků a **normální snímky** dědí z rozvržení snímků.

Tento článek ukazuje, jak pomocí Aspose.Slides pro C++ vytvářet, upravovat a spravovat master snímky.

## **Přidat master snímek**

Tento příklad ukazuje, jak vytvořit nový master snímek klonováním výchozího. Poté přidá banner s názvem společnosti ke všem snímkům prostřednictvím dědičnosti rozvržení.

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Klonovat výchozí master snímek.
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // Přidat banner s názvem společnosti na vrchol master snímku.
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // Přiřadit nový master snímek k rozvržení snímku.
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // Přiřadit rozvržení snímku k prvnímu snímku v prezentaci.
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Poznámka 1:** Master snímky poskytují způsob, jak aplikovat jednotné brandování nebo sdílené designové prvky na všechny snímky. Jakékoli změny provedené v masteru se automaticky projeví v závislých rozvrženích a normálních snímcích.  
> 💡 **Poznámka 2:** Jakékoli tvary nebo formátování přidané do master snímku jsou děděny rozvržením snímků a následně všemi normálními snímky používajícími tato rozvržení.  
> Obrázek níže ilustruje, jak je textové pole přidané do master snímku automaticky vykresleno na finálním snímku.

![Ukázka dědičnosti master snímku](master-slide-banner.png)

## **Přístup k master snímku**

K master snímkům můžete přistupovat pomocí kolekce master snímků v prezentaci. Zde je návod, jak je načíst a pracovat s nimi:

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // Změnit typ pozadí.
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **Odstranit master snímek**

Master snímky lze odstranit buď podle indexu, nebo podle reference.

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Odstranit master snímek podle indexu.
    presentation->get_Masters()->RemoveAt(0);

    // Odstranit master snímek podle reference.
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **Odstranit nepoužívané master snímky**

Některé prezentace obsahují master snímky, které nejsou využívány. Odstranění těchto snímků může pomoci snížit velikost souboru.

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Odstranit všechny nepoužívané master snímky (i ty označené jako Preserve).
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```