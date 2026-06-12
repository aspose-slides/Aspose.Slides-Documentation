---
title: Hypertextový odkaz
type: docs
weight: 130
url: /cs/cpp/examples/elements/hyperlink/
keywords:
- "ukázka kódu"
- "hypertextový odkaz"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- "C++"
- "Aspose.Slides"
description: "Přidávejte a spravujte hypertextové odkazy v Aspose.Slides for C++: textové odkazy, tvary a obrázky, nastavujte cíle a akce pro PPT, PPTX a ODP pomocí C++ příkladů."
---
Tento článek ukazuje přidávání, načítání, odstraňování a aktualizaci hypertextových odkazů u tvarů pomocí **Aspose.Slides for C++**.

## **Přidání hypertextového odkazu**

Vytvořte obdélníkový tvar s hypertextovým odkazem směřujícím na externí webovou stránku.

```cpp
static void AddHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    presentation->Dispose();
}
```

## **Přístup k hypertextovému odkazu**

Přečtěte informace o hypertextovém odkazu z textové části tvaru.

```cpp
static void AccessHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    auto hyperlink = textPortion->get_PortionFormat()->get_HyperlinkClick();

    presentation->Dispose();
}
```

## **Odstranění hypertextového odkazu**

Odstraňte hypertextový odkaz z textu tvaru.

```cpp
static void RemoveHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    textPortion->get_PortionFormat()->set_HyperlinkClick(nullptr);

    presentation->Dispose();
}
```

## **Aktualizace hypertextového odkazu**

Změňte cíl existujícího hypertextového odkazu. Použijte `HyperlinkManager` k úpravě textu, který již obsahuje hypertextový odkaz, což napodobuje způsob, jakým PowerPoint bezpečně aktualizuje hypertextové odkazy.

```cpp
static void UpdateHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://old.example.com"));

    // Změna hypertextového odkazu v existujícím textu by měla být provedena pomocí
    // HyperlinkManager místo přímého nastavení vlastnosti.
    // Toto napodobuje, jak PowerPoint bezpečně aktualizuje hypertextové odkazy.
    textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://new.example.com");

    presentation->Dispose();
}
```