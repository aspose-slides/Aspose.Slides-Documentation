---
title: Formen auf Präsentationsfolien skalieren
type: docs
weight: 100
url: /de/cpp/re-sizing-shapes-on-slide/
keywords:
- Form skalieren
- Formgröße ändern
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Skalieren Sie Formen auf PowerPoint- und OpenDocument-Folien einfach mit Aspose.Slides für C++ — automatisieren Sie die Anpassung des Folienlayouts und steigern Sie die Produktivität."
---

## **Übersicht**

Eine der häufigsten Fragen von Aspose.Slides für C++‑Kunden ist, wie man Formen so skaliert, dass bei einer Änderung der Foliengröße die Inhalte nicht abgeschnitten werden. Dieser kurze technische Artikel zeigt, wie das funktioniert.

## **Formen skalieren**

Damit Formen bei einer Änderung der Foliengröße nicht verschoben werden, aktualisieren Sie für jede Form Position und Abmessungen, sodass sie dem neuen Folienlayout entsprechen.
```cpp
// Präsentationsdatei laden.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Get the original slide size.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Change the slide size without scaling existing shapes.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Get the new slide size.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Resize and reposition shapes on every slide.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Größe der Form skalieren.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Position der Form skalieren.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


{{% alert color="primary" %}} 
Wenn eine Folie eine Tabelle enthält, funktioniert der obige Code nicht korrekt. In diesem Fall muss jede Zelle der Tabelle skaliert werden.
{{% /alert %}} 

Verwenden Sie den folgenden Code, um Folien mit Tabellen zu skalieren. Für Tabellen ist das Festlegen von Breite oder Höhe ein Sonderfall: Sie müssen die Höhen einzelner Zeilen und die Breiten einzelner Spalten anpassen, um die Gesamtabmessungen der Tabelle zu ändern.
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Originale Foliengröße abrufen.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Foliengröße ändern, ohne vorhandene Formen zu skalieren.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Neue Foliengröße abrufen.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Formgröße skalieren.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Formposition skalieren.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Formgröße skalieren.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Formposition skalieren.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Formgröße skalieren.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Formposition skalieren.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **FAQ**

**Warum werden Formen nach dem Skalieren einer Folie verzerrt oder abgeschnitten?**

Beim Skalieren einer Folie behalten Formen ihre ursprüngliche Position und Größe bei, sofern die Skalierung nicht explizit geändert wird. Das kann dazu führen, dass Inhalte beschnitten oder Formen missaligned sind.

**Funktioniert der bereitgestellte Code für alle Formtypen?**

Das Basisbeispiel funktioniert für die meisten Formtypen (Textfelder, Bilder, Diagramme usw.). Für Tabellen müssen jedoch Zeilen und Spalten separat behandelt werden, da Höhe und Breite einer Tabelle durch die Abmessungen der einzelnen Zellen bestimmt werden.

**Wie skalieren ich Tabellen, wenn ich eine Folie skaliere?**

Sie müssen durch alle Zeilen und Spalten der Tabelle iterieren und deren Höhe bzw. Breite proportional anpassen, wie im zweiten Codebeispiel gezeigt.

**Funktioniert diese Skalierung auch für Master‑Folien und Layout‑Folien?**

Ja, Sie sollten außerdem durch [Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) und [Layout slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) iterieren und dieselbe Skalierungslogik auf deren Formen anwenden, um Konsistenz in der gesamten Präsentation zu gewährleisten.

**Kann ich die Ausrichtung einer Folie (Porträt/Landschaft) zusammen mit der Skalierung ändern?**

Ja. Sie können [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/islidesize/set_orientation/) verwenden, um die Ausrichtung zu ändern. Stellen Sie sicher, dass Sie die Skalierungslogik entsprechend anpassen, um das Layout beizubehalten.

**Gibt es eine Obergrenze für die Foliengröße, die ich festlegen kann?**

Aspose.Slides unterstützt benutzerdefinierte Größen, aber sehr große Abmessungen können die Leistung beeinflussen oder die Kompatibilität mit einigen PowerPoint‑Versionen beeinträchtigen.

**Wie kann ich verhindern, dass Formen mit festem Seitenverhältnis verzerrt werden?**

Sie können die Methode `get_AspectRatioLocked` der Form prüfen, bevor Sie skalieren. Ist sie gesperrt, passen Sie Breite oder Höhe proportional an, anstatt sie einzeln zu skalieren.