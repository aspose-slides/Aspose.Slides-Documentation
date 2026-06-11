---
title: Hiperłącze
type: docs
weight: 130
url: /pl/cpp/examples/elements/hyperlink/
keywords:
- przykład kodu
- hiperłącze
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dodawaj i zarządzaj hiperłączami w Aspose.Slides for C++: łącz tekst, kształty i obrazy, ustaw cele i akcje dla PPT, PPTX i ODP przy użyciu przykładów w C++."
---
Ten artykuł demonstruje dodawanie, odczytywanie, usuwanie i aktualizację hiperłączy na kształtach przy użyciu **Aspose.Slides for C++**.

## **Dodaj hiperłącze**

Utwórz prostokątny kształt z hiperłączem prowadzącym do zewnętrznej witryny.

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

## **Uzyskaj dostęp do hiperłącza**

Odczytaj informacje o hiperłączu z części tekstowej kształtu.

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

## **Usuń hiperłącze**

Wyczyść hiperłącze z tekstu kształtu.

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

## **Zaktualizuj hiperłącze**

Zmień docelowy adres istniejącego hiperłącza. Użyj `HyperlinkManager`, aby zmodyfikować tekst, który już zawiera hiperłącze, co naśladuje sposób, w jaki PowerPoint bezpiecznie aktualizuje hiperłącza.

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

    // Zmiana hiperłącza w istniejącym tekście powinna być wykonana przy użyciu
    // HyperlinkManager zamiast bezpośredniego ustawiania właściwości.
    // To naśladuje sposób, w jaki PowerPoint bezpiecznie aktualizuje hiperłącza.
    textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://new.example.com");

    presentation->Dispose();
}
```