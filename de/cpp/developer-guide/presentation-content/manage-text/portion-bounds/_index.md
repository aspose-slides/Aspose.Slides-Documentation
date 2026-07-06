---
title: Textportion-Grenzwerte aus Präsentationen in C++ abrufen
linktitle: Portion-Grenzwerte
type: docs
weight: 47
url: /de/cpp/portion-bounds/
keywords:
- Textportion-Grenzwerte
- Textportion
- Textteil
- Textkoordinaten
- Textposition
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Textportion-Grenzwerte in PowerPoint-Präsentationen mit Aspose.Slides für C++ abrufen."
---
## **Übersicht**

Ein Textabschnitt (Portion) stellt ein bestimmtes Fragment von Text innerhalb eines Absatzes dar und ermöglicht es Ihnen, mit diesem Fragment unabhängig vom umgebenden Inhalt zu arbeiten. In Aspose.Slides können Portionen verwendet werden, wenn Sie die Begrenzungsrahmen eines Textfragments ermitteln, die Formatierung nur auf einen Teil eines Absatzes anwenden oder das Textverhalten auf einer detaillierteren Ebene steuern müssen.

Dieser Artikel zeigt, wie man das Begrenzungsrechteck einer Portion mit [IPortion::GetRect](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/getrect/) abruft. Er zeigt außerdem, wie man die Koordinaten des Beginns einer Portion mit [IPortion::GetCoordinates](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/getcoordinates/) ermittelt. Darüber hinaus werden häufige szenarienbezogene Anwendungsfälle beschrieben, wie das Anwenden eines Hyperlinks auf ein einzelnes Textfragment, das Verständnis, wie die Formatierung über Portion, Absatz, Textfeld und Themenvererbung aufgelöst wird, und der Umgang mit Fällen, in denen eine angegebene Schriftart nicht verfügbar ist.

## **Grenzrechteck einer Textportion abrufen**

Verwenden Sie [IPortion::GetRect](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/getrect/), um das Begrenzungsrechteck einer Textportion abzurufen:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **Koordinaten einer Textportion abrufen**

Verwenden Sie [IPortion::GetCoordinates](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/getcoordinates/), um die Koordinaten des Beginns einer Textportion abzurufen:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **FAQ**

**Kann ich einen Hyperlink nur auf einen Teil des Textes innerhalb eines einzelnen Absatzes anwenden?**

Ja, Sie können [einen Hyperlink zuweisen](/slides/de/cpp/manage-hyperlinks/) zu einer einzelnen Portion; nur dieses Fragment wird anklickbar sein, nicht der gesamte Absatz.

**Wie funktioniert die Stilvererbung: Was überschreibt eine Portion und was wird aus einem Absatz oder Textfeld übernommen?**

Eigenschaften auf Portionsebene haben die höchste Priorität. Wenn eine Eigenschaft nicht auf dem [IPortion](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/) gesetzt ist, übernimmt Aspose.Slides sie vom [IParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/). Ist sie dort ebenfalls nicht gesetzt, verwendet Aspose.Slides den Stil des [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) oder des [theme](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/theme/).

**Was passiert, wenn die für eine Portion angegebene Schriftart auf dem Zielgerät oder Server fehlt?**

[Regeln für die Schriftarten‑Ersetzung](/slides/de/cpp/font-selection-sequence/) kommen zum Tragen. Der Text kann umfließen: Metriken, Silbentrennung und Breite können sich ändern, was bei präziser Positionierung wichtig ist.

**Kann ich die Transparenz oder einen Farbverlauf der Textfüllung einer Portion unabhängig vom Rest des Absatzes festlegen?**

Ja, Textfarbe, Füllung und Transparenz auf der Ebene des [IPortion](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/) können sich von benachbarten Fragmenten unterscheiden.