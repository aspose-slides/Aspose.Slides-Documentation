---
title: Verwalten von SmartArt-Form-Knoten
type: docs
weight: 30
url: /de/cpp/manage-smartart-shape-node/
keywords:
- SmartArt
- SmartArt-Knoten
- SmartArt-Kindknoten
- PowerPoint
- Präsentation
- C++
- Aspose.Slides für C++
description: "Verwalten von SmartArt-Knoten und Kindknoten in PowerPoint-Präsentationen in C++"
---



## **SmartArt-Knoten hinzufügen**
Aspose.Slides für C++ bietet die einfachste API, um die SmartArt-Formen auf einfachste Weise zu verwalten. Der folgende Beispielcode hilft dabei, Knoten und Kindknoten innerhalb der SmartArt-Form hinzuzufügen.

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse und laden Sie die Präsentation mit der SmartArt-Form.
- Erhalten Sie die Referenz der ersten Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form in der ersten Folie.
- Überprüfen Sie, ob die Form vom SmartArt-Typ ist, und typisieren Sie die ausgewählte Form in SmartArt, wenn es sich um SmartArt handelt.
- Fügen Sie einen neuen Knoten in die NodeCollection der SmartArt-Form hinzu und setzen Sie den Text im TextFrame.
- Fügen Sie jetzt einen Kindknoten im neu hinzugefügten SmartArt-Knoten hinzu und setzen Sie den Text im TextFrame.
- Speichern Sie die Präsentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **SmartArt-Knoten an einer bestimmten Position hinzufügen**
Im folgenden Beispielcode wird erläutert, wie man die zugehörigen Kindknoten der SmartArt-Form an einer bestimmten Position hinzufügt.

- Erstellen Sie eine Instanz der `Presentation` Klasse.
- Erhalten Sie die Referenz der ersten Folie, indem Sie ihren Index verwenden.
- Fügen Sie in der aufgerufenen Folie eine SmartArt-Form vom Typ StackedList hinzu.
- Greifen Sie auf den ersten Knoten in der hinzugefügten SmartArt-Form zu.
- Fügen Sie jetzt den Kindknoten für den ausgewählten Knoten an Position 2 hinzu und setzen Sie dessen Text.
- Speichern Sie die Präsentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}


## **SmartArt-Knoten zugreifen**
Der folgende Beispielcode hilft dabei, auf Knoten innerhalb der SmartArt-Form zuzugreifen. Bitte beachten Sie, dass Sie den LayoutTyp der SmartArt nicht ändern können, da dieser schreibgeschützt ist und nur beim Hinzufügen der SmartArt-Form festgelegt wird.

- Erstellen Sie eine Instanz der `Presentation` Klasse und laden Sie die Präsentation mit der SmartArt-Form.
- Erhalten Sie die Referenz der ersten Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form in der ersten Folie.
- Überprüfen Sie, ob die Form vom SmartArt-Typ ist, und typisieren Sie die ausgewählte Form in SmartArt, wenn es sich um SmartArt handelt.
- Durchlaufen Sie alle Knoten innerhalb der SmartArt-Form.
- Greifen Sie auf Informationen wie die Position, die Ebene und den Text des SmartArt-Knotens zu und zeigen Sie sie an.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **SmartArt-Kindknoten zugreifen**
Der folgende Beispielcode hilft dabei, auf die Kindknoten zuzugreifen, die zu den jeweiligen Knoten der SmartArt-Form gehören.

- Erstellen Sie eine Instanz der PresentationEx-Klasse und laden Sie die Präsentation mit der SmartArt-Form.
- Erhalten Sie die Referenz der ersten Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form in der ersten Folie.
- Überprüfen Sie, ob die Form vom SmartArt-Typ ist, und typisieren Sie die ausgewählte Form in SmartArtEx, wenn es sich um SmartArt handelt.
- Durchlaufen Sie alle Knoten innerhalb der SmartArt-Form.
- Für jeden ausgewählten SmartArt-Formknoten durchlaufen Sie alle Kindknoten im jeweiligen Knoten.
- Greifen Sie auf Informationen wie die Position, die Ebene und den Text des Kindknotens zu und zeigen Sie sie an.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **SmartArt-Kindknoten an einer bestimmten Position zugreifen**
In diesem Beispiel lernen wir, wie man auf die Kindknoten an einer bestimmten Position zugreift, die zu den jeweiligen Knoten der SmartArt-Form gehören.

- Erstellen Sie eine Instanz der `Presentation` Klasse.
- Erhalten Sie die Referenz der ersten Folie, indem Sie ihren Index verwenden.
- Fügen Sie eine SmartArt-Form vom Typ StackedList hinzu.
- Greifen Sie auf die hinzugefügte SmartArt-Form zu.
- Greifen Sie auf den Knoten an Index 0 für die aufgerufene SmartArt-Form zu.
- Greifen Sie jetzt mit der GetNodeByPosition()-Methode auf den Kindknoten an Position 1 für den aufgerufenen SmartArt-Knoten zu.
- Greifen Sie auf Informationen wie die Position, die Ebene und den Text des Kindknotens zu und zeigen Sie sie an.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **SmartArt-Knoten entfernen**
In diesem Beispiel lernen wir, wie man die Knoten innerhalb der SmartArt-Form entfernt.

- Erstellen Sie eine Instanz der `Presentation` Klasse und laden Sie die Präsentation mit der SmartArt-Form.
- Erhalten Sie die Referenz der ersten Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form in der ersten Folie.
- Überprüfen Sie, ob die Form vom SmartArt-Typ ist, und typisieren Sie die ausgewählte Form in SmartArt, wenn es sich um SmartArt handelt.
- Überprüfen Sie, ob die SmartArt mehr als 0 Knoten hat.
- Wählen Sie den zu löschenden SmartArt-Knoten aus.
- Entfernen Sie jetzt den ausgewählten Knoten mit der RemoveNode()-Methode* Speichern Sie die Präsentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **SmartArt-Knoten an einer bestimmten Position entfernen**
In diesem Beispiel lernen wir, wie man die Knoten innerhalb der SmartArt-Form an einer bestimmten Position entfernt.

- Erstellen Sie eine Instanz der `Presentation` Klasse und laden Sie die Präsentation mit der SmartArt-Form.
- Erhalten Sie die Referenz der ersten Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form in der ersten Folie.
- Überprüfen Sie, ob die Form vom SmartArt-Typ ist, und typisieren Sie die ausgewählte Form in SmartArt, wenn es sich um SmartArt handelt.
- Wählen Sie den SmartArt-Formknoten an Index 0 aus.
- Überprüfen Sie jetzt, ob der ausgewählte SmartArt-Knoten mehr als 2 Kindknoten hat.
- Entfernen Sie nun den Knoten an Position 1 mit der RemoveNodeByPosition()-Methode.
- Speichern Sie die Präsentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}


## **Benutzerdefinierte Position für SmartArt-Kindknoten festlegen**
Nun unterstützt Aspose.Slides für .NET die Einstellung der X- und Y-Eigenschaften von SmartArtShape. Der folgende Codeausschnitt zeigt, wie man die benutzerdefinierte Position, Größe und Drehung von SmartArtShape festlegt; bitte beachten Sie, dass das Hinzufügen neuer Knoten eine Neuberechnung der Positionen und Größen aller Knoten verursacht.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}


## **Assistentenknoten überprüfen**
Im folgenden Beispielcode werden wir untersuchen, wie man Assistenzknoten in der Sammlung von SmartArt-Knoten identifiziert und ändert.

- Erstellen Sie eine Instanz der PresentationEx-Klasse und laden Sie die Präsentation mit der SmartArt-Form.
- Erhalten Sie die Referenz der zweiten Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form in der ersten Folie.
- Überprüfen Sie, ob die Form vom SmartArt-Typ ist, und typisieren Sie die ausgewählte Form in SmartArtEx, wenn es sich um SmartArt handelt.
- Durchlaufen Sie alle Knoten innerhalb der SmartArt-Form und überprüfen Sie, ob es sich um Assistenzknoten handelt.
- Ändern Sie den Status des Assistenzknotens in einen normalen Knoten.
- Speichern Sie die Präsentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **Füllformat des Knotens festlegen**
Aspose.Slides für C++ ermöglicht es, benutzerdefinierte SmartArt-Formen hinzuzufügen und deren Füllformate festzulegen. Dieser Artikel erklärt, wie man SmartArt-Formen erstellt und darauf zugreift und deren Füllformat mit Aspose.Slides für C++ festlegt.

Bitte folgen Sie den folgenden Schritten:

- Erstellen Sie eine Instanz der `Presentation` Klasse.
- Erhalten Sie die Referenz einer Folie mit ihrem Index.
- Fügen Sie eine SmartArt-Form hinzu, indem Sie ihren LayoutTyp festlegen.
- Setzen Sie das Füllformat für die Knoten der SmartArt-Form.
- Schreiben Sie die bearbeitete Präsentation als PPTX-Datei.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}


## **Miniaturansicht des SmartArt-Kindknotens generieren**
Entwickler können eine Miniaturansicht des Kindknotens einer SmartArt erstellen, indem sie die folgenden Schritte befolgen:

1. Instanziieren Sie die `Presentation` Klasse, die die PPTX-Datei darstellt.
1. Fügen Sie SmartArt hinzu.
1. Erhalten Sie die Referenz eines Knotens, indem Sie seinen Index verwenden.
1. Holen Sie sich das Miniaturbild.
1. Speichern Sie das Miniaturbild in jedem gewünschten Bildformat.

Im folgenden Beispiel wird eine Miniaturansicht des SmartArt-Kindknotens generiert

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
auto node = smartArt->get_Node(1);

auto image = node->get_Shape(0)->GetImage();
image->Save(u"SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```