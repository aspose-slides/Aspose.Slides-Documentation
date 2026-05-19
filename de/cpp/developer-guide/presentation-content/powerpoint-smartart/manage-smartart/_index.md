---
title: SmartArt in PowerPoint-Präsentationen mit C++ verwalten
linktitle: SmartArt verwalten
type: docs
weight: 10
url: /de/cpp/manage-smartart/
keywords:
- SmartArt
- SmartArt-Text
- Layouttyp
- Ausgeblendete Eigenschaft
- Organisationsdiagramm
- Bild-Organisationsdiagramm
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑SmartArt mit Aspose.Slides für C++ erstellen und bearbeiten, mithilfe klarer Code‑Beispiele, die das Folien‑Design und die Automatisierung beschleunigen."
---
## **Übersicht**

SmartArt ist ein PowerPoint‑Diagramm, das aus Knoten, Knotenkformen und einem Layout besteht. Mit Aspose.Slides für C++ können Sie SmartArt erstellen, Text aus seinen Knoten auslesen, das Layout ändern, versteckte Knoten untersuchen, Organisationsdiagramm‑Layouts konfigurieren und Bild‑Organisationsdiagramme erstellen.

## **Text aus einem SmartArt‑Objekt abrufen**

Ein SmartArt‑Knoten kann ein oder mehrere Formen enthalten. Um den sichtbaren Text zu lesen, iterieren Sie über [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/de/cpp/aspose.slides.smartart/smartart/get_allnodes/), und lesen Sie dann das [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) , das von [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides.smartart/smartartshape/get_textframe/) zurückgegeben wird.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (System::ObjectExt::Is<ISmartArt>(shape))
{
    auto smartArt = System::ExplicitCast<ISmartArt>(shape);

    for (int nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
    {
        auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);

        for (int shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
        {
            auto nodeShape = node->get_Shape(shapeIndex);

            if (nodeShape->get_TextFrame() != nullptr)
            {
                System::Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
            }
        }
    }
}

presentation->Dispose();
```

## **Layouttyp eines SmartArt‑Objekts ändern**

Das SmartArt‑Layout bestimmt, wie Knoten angeordnet und verbunden sind. Das folgende Beispiel erstellt ein SmartArt‑Objekt mit dem [SmartArtLayoutType](https://reference.aspose.com/slides/de/cpp/aspose.slides.smartart/smartartlayouttype/)‑Wert `BasicBlockList`, ändert ihn in den Wert `BasicProcess` und speichert die Präsentation.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Überprüfen, ob ein SmartArt‑Knoten ausgeblendet ist**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/de/cpp/aspose.slides.smartart/smartartnode/get_ishidden/) gibt an, ob der Knoten im SmartArt‑Datenmodell ausgeblendet ist. Ausgeblendete Knoten können in der Struktur vorhanden sein, selbst wenn das ausgewählte Layout sie nicht als sichtbare Diagrammelemente anzeigt.

Das folgende Beispiel fügt einem SmartArt‑Objekt, das den [SmartArtLayoutType](https://reference.aspose.com/slides/de/cpp/aspose.slides.smartart/smartartlayouttype/)‑Wert `RadialCycle` verwendet, einen Knoten hinzu und prüft den ausgeblendeten Zustand des Knotens.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);

auto node = smartArt->get_AllNodes()->AddNode();
bool isHidden = node->get_IsHidden();

if (isHidden)
{
    System::Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Organisationsdiagramm‑Layout abrufen oder festlegen**

Für SmartArt‑Diagramme, die ein Organisationsdiagramm‑Layout verwenden, definieren [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/de/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) und [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/de/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/), wie Kindknoten unter einem Elternknoten angeordnet werden. Beispielsweise können Sie Kindknoten links, rechts oder an beiden Seiten hängen lassen, je nach ausgewähltem [OrganizationChartLayoutType](https://reference.aspose.com/slides/de/cpp/aspose.slides.smartart/organizationchartlayouttype/).

Das folgende Beispiel erstellt ein Organisationsdiagramm und setzt das Layout für den ersten Knoten auf den [OrganizationChartLayoutType](https://reference.aspose.com/slides/de/cpp/aspose.slides.smartart/organizationchartlayouttype/)‑Wert `LeftHanging`.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ein Bild‑Organisationsdiagramm erstellen**

Ein Bild‑Organisationsdiagramm ist ein SmartArt‑Layout, das für Hierarchiediagramme mit Bild‑Platzhaltern entwickelt wurde. Verwenden Sie den [SmartArtLayoutType](https://reference.aspose.com/slides/de/cpp/aspose.slides.smartart/smartartlayouttype/)‑Wert `PictureOrganizationChart`, wenn Sie das SmartArt‑Objekt zu einer Folie hinzufügen.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Unterstützt SmartArt Mirroring oder Umkehrung für RTL‑Sprachen?**

Ja. Die Methode [SmartArt::set_IsReversed](https://reference.aspose.com/slides/de/cpp/aspose.slides.smartart/smartart/set_isreversed/) wechselt die Diagrammrichtung von links‑nach‑rechts zu rechts‑nach‑links oder zurück, sofern das ausgewählte SmartArt‑Layout die Umkehr unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in eine andere Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die SmartArt‑Form mit [SmartArt-Form klonen](/slides/de/cpp/shape-manipulations/) [ShapeCollection::AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/shapecollection/addclone/) oder die gesamte Folie, die die SmartArt enthält, mit [gesamte Folie klonen](/slides/de/cpp/clone-slides/) [Clone](/slides/de/cpp/clone-slides/) klonen. Beide Verfahren behalten Größe, Position und Formatierung bei.

**Wie render ich SmartArt zu einem Raster‑Bild für die Vorschau oder den Web‑Export?**

[Folie rendern](/slides/de/cpp/convert-powerpoint-to-png/) oder die gesamte Präsentation zu PNG oder JPEG. SmartArt wird als Teil der Folie gerendert.

**Wie kann ich ein bestimmtes SmartArt‑Objekt auf einer Folie finden, wenn mehrere vorhanden sind?**

Legen Sie einen eindeutigen [Shape::set_AlternativeText](https://reference.aspose.com/slides/de/cpp/aspose.slides/shape/set_alternativetext/)‑ oder [Shape::set_Name](https://reference.aspose.com/slides/de/cpp/aspose.slides/shape/set_name/)‑Wert für die SmartArt‑Form fest, suchen Sie diesen Wert in [BaseSlide::get_Shapes](https://reference.aspose.com/slides/de/cpp/aspose.slides/baseslide/get_shapes/), und überprüfen Sie anschließend, ob das gefundene Formobjekt ein [ISmartArt](https://reference.aspose.com/slides/de/cpp/aspose.slides.smartart/ismartart/) ist.