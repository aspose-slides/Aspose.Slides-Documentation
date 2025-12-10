---
title: Textabschnitte in Präsentationen mit C++ verwalten
linktitle: Textabschnitt
type: docs
weight: 70
url: /de/cpp/portion/
keywords:
- Textabschnitt
- Textteil
- Textkoordinaten
- Textposition
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Textabschnitte in PowerPoint-Präsentationen mit Aspose.Slides für C++ verwalten, um Leistung und Anpassungsmöglichkeiten zu steigern."
---

## **Koordinaten eines Textabschnitts abrufen**
**GetCoordinates()**-Methode wurde zur IPortion- und Portion-Klasse hinzugefügt, mit der die Koordinaten des Beginns des Abschnitts abgerufen werden können:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```


## **FAQ**

**Kann ich einen Hyperlink nur auf einen Teil des Textes innerhalb eines einzelnen Absatzes anwenden?**

Ja, Sie können [einen Hyperlink zuweisen](/slides/de/cpp/manage-hyperlinks/) einem einzelnen Abschnitt zuweisen; nur dieses Fragment ist anklickbar, nicht der gesamte Absatz.

**Wie funktioniert die Stilvererbung: Was überschreibt ein Portion und was wird von Paragraph/TextFrame übernommen?**

Eigenschaften auf Portion‑Ebene haben die höchste Priorität. Ist eine Eigenschaft nicht im [Portion](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) festgelegt, übernimmt die Engine sie vom [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/); ist sie dort ebenfalls nicht gesetzt, wird sie vom [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/) oder vom Stil des [theme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/theme/) übernommen.

**Was passiert, wenn die für einen Portion angegebene Schriftart auf dem Ziel‑Computer/Server fehlt?**

[Regeln zur Schriftart‑Ersetzung](/slides/de/cpp/font-selection-sequence/) gelten. Der Text kann umfließen: Metriken, Silbentrennung und Breite können sich ändern, was für präzise Positionierung wichtig ist.

**Kann ich für einen Portion spezifische Textfüll‑Transparenz oder einen Verlauf festlegen, unabhängig vom Rest des Absatzes?**

Ja, Textfarbe, Füllung und Transparenz auf dem [Portion](https://reference.aspose.com/slides/cpp/aspose.slides/portion/)-Level können von benachbarten Fragmenten abweichen.