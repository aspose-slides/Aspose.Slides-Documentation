---
title: SmartArt‑Formknoten in Präsentationen mit C++ verwalten
linktitle: SmartArt‑Formknoten
type: docs
weight: 30
url: /de/cpp/manage-smartart-shape-node/
keywords:
- SmartArt‑Knoten
- untergeordneter Knoten
- Knoten hinzufügen
- Knotenposition
- Knotenzugriff
- Knoten entfernen
- benutzerdefinierte Position
- Assistentenknoten
- Füllformat
- Knoten rendern
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Verwalten Sie SmartArt‑Formknoten in PPT und PPTX mit Aspose.Slides für C++. Erhalten Sie klare Code‑Beispiele und Tipps, um Ihre Präsentationen zu optimieren."
---

## **SmartArt-Knoten hinzufügen**
Aspose.Slides für C++ stellt die einfachste API zur Verwaltung von SmartArt‑Formen auf einfachste Weise bereit. Der folgende Beispielcode zeigt, wie ein Knoten und ein untergeordneter Knoten innerhalb einer SmartArt‑Form hinzugefügt werden.

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie sich die Referenz der ersten Folie über ihren Index.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
- Fügen Sie einen neuen Knoten zur NodeCollection der SmartArt‑Form hinzu und setzen Sie den Text im TextFrame.
- Fügen Sie nun einen untergeordneten Knoten zum neu hinzugefügten SmartArt‑Knoten hinzu und setzen Sie den Text im TextFrame.
- Speichern Sie die Präsentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **SmartArt-Knoten an einer bestimmten Position hinzufügen**
In dem folgenden Beispielcode wird erklärt, wie die untergeordneten Knoten der jeweiligen Knoten einer SmartArt‑Form an einer bestimmten Position hinzugefügt werden.

- Erstellen Sie eine Instanz der Klasse `Presentation`.
- Holen Sie sich die Referenz der ersten Folie über ihren Index.
- Fügen Sie der angesprochenen Folie eine SmartArt‑Form vom Typ StackedList hinzu.
- Greifen Sie auf den ersten Knoten der hinzugefügten SmartArt‑Form zu.
- Fügen Sie nun den untergeordneten Knoten für den ausgewählten Knoten an Position 2 hinzu und setzen Sie dessen Text.
- Speichern Sie die Präsentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}

## **Zugriff auf einen SmartArt-Knoten**
Der folgende Beispielcode zeigt, wie Sie Knoten innerhalb einer SmartArt‑Form zugreifen können. Bitte beachten Sie, dass Sie den LayoutType von SmartArt nicht ändern können, da er schreibgeschützt ist und nur beim Hinzufügen der SmartArt‑Form festgelegt wird.

- Erstellen Sie eine Instanz der Klasse `Presentation` und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie sich die Referenz der ersten Folie über ihren Index.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
- Durchlaufen Sie alle Knoten innerhalb der SmartArt‑Form.
- Greifen Sie auf Informationen wie die Position, Ebene und den Text des SmartArt‑Knotens zu und zeigen Sie sie an.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **Zugriff auf ein SmartArt-untergeordnetes Element**
Der folgende Beispielcode zeigt, wie Sie die untergeordneten Knoten der jeweiligen Knoten einer SmartArt‑Form zugreifen können.

- Erstellen Sie eine Instanz der Klasse PresentationEx und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie sich die Referenz der ersten Folie über ihren Index.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArtEx, falls sie SmartArt ist.
- Durchlaufen Sie alle Knoten innerhalb der SmartArt‑Form.
- Für jeden ausgewählten SmartArt‑Form‑Knoten durchlaufen Sie alle untergeordneten Knoten innerhalb dieses Knotens.
- Greifen Sie auf Informationen wie die Position, Ebene und den Text des untergeordneten Knotens zu und zeigen Sie sie an.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **Zugriff auf ein SmartArt-untergeordnetes Element an einer bestimmten Position**
In diesem Beispiel lernen wir, wie man die untergeordneten Knoten an einer bestimmten Position der jeweiligen Knoten einer SmartArt‑Form zugreift.

- Erstellen Sie eine Instanz der Klasse `Presentation`.
- Holen Sie sich die Referenz der ersten Folie über ihren Index.
- Fügen Sie eine SmartArt‑Form vom Typ StackedList hinzu.
- Greifen Sie auf die hinzugefügte SmartArt‑Form zu.
- Greifen Sie auf den Knoten mit Index 0 der angesprochenen SmartArt‑Form zu.
- Greifen Sie nun mit der Methode GetNodeByPosition() auf das untergeordnete Element an Position 1 des angesprochenen SmartArt‑Knotens zu.
- Greifen Sie auf Informationen wie die Position, Ebene und den Text des untergeordneten Knotens zu und zeigen Sie sie an.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **Entfernen eines SmartArt-Knotens**
In diesem Beispiel lernen wir, wie man Knoten innerhalb einer SmartArt‑Form entfernt.

- Erstellen Sie eine Instanz der Klasse `Presentation` und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie sich die Referenz der ersten Folie über ihren Index.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
- Prüfen Sie, ob die SmartArt mehr als 0 Knoten enthält.
- Wählen Sie den zu löschenden SmartArt‑Knoten aus.
- Entfernen Sie nun den ausgewählten Knoten mit der Methode RemoveNode() und speichern Sie die Präsentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **Entfernen eines SmartArt-Knotens an einer bestimmten Position**
In diesem Beispiel lernen wir, wie man Knoten innerhalb einer SmartArt‑Form an einer bestimmten Position entfernt.

- Erstellen Sie eine Instanz der Klasse `Presentation` und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie sich die Referenz der ersten Folie über ihren Index.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
- Wählen Sie den SmartArt‑Form‑Knoten mit Index 0 aus.
- Prüfen Sie nun, ob der ausgewählte SmartArt‑Knoten mehr als 2 untergeordnete Knoten hat.
- Entfernen Sie nun den Knoten an Position 1 mit der Methode RemoveNodeByPosition().
- Speichern Sie die Präsentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}

## **Benutzerdefinierte Position für ein SmartArt-untergeordnetes Element festlegen**
Aspose.Slides unterstützt nun das Festlegen der X‑ und Y‑Eigenschaften von SmartArtShape. Das folgende Code‑Snippet zeigt, wie benutzerdefinierte Position, Größe und Drehung von SmartArtShape festgelegt werden. Bitte beachten Sie, dass das Hinzufügen neuer Knoten eine Neuberechnung der Positionen und Größen aller Knoten verursacht.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}

## **Überprüfen eines Assistenten-Knotens**
Im folgenden Beispielcode untersuchen wir, wie Assistenten‑Knoten in der SmartArt‑Knotensammlung identifiziert und geändert werden können.

- Erstellen Sie eine Instanz der Klasse PresentationEx und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie sich die Referenz der zweiten Folie über ihren Index.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArtEx, falls sie SmartArt ist.
- Durchlaufen Sie alle Knoten innerhalb der SmartArt‑Form und prüfen Sie, ob sie Assistenten‑Knoten sind.
- Ändern Sie den Status des Assistenten‑Knotens in einen normalen Knoten.
- Speichern Sie die Präsentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **Füllformat eines Knotens festlegen**
Aspose.Slides für C++ ermöglicht das Hinzufügen benutzerdefinierter SmartArt‑Formen und das Festlegen ihrer Füllformate. Dieser Artikel erklärt, wie SmartArt‑Formen erstellt und zugegriffen sowie deren Füllformat mit Aspose.Slides für C++ festgelegt wird.

Bitte folgen Sie den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse `Presentation`.
- Holen Sie sich die Referenz einer Folie über ihren Index.
- Fügen Sie eine SmartArt‑Form hinzu, indem Sie deren LayoutType festlegen.
- Legen Sie das FillFormat für die Knoten der SmartArt‑Form fest.
- Speichern Sie die geänderte Präsentation als PPTX-Datei.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}

## **Erzeugen eines Vorschaubilds eines SmartArt-untergeordneten Elements**
Entwickler können ein Vorschaubild des untergeordneten Knotens einer SmartArt erzeugen, indem sie die folgenden Schritte ausführen:

1. Instanziieren Sie die Klasse `Presentation`, die die PPTX‑Datei darstellt.
2. Fügen Sie SmartArt hinzu.
3. Holen Sie sich die Referenz eines Knotens über dessen Index.
4. Erzeugen Sie das Vorschaubild.
5. Speichern Sie das Vorschaubild in einem gewünschten Bildformat.

Das nachstehende Beispiel erzeugt ein Vorschaubild eines SmartArt‑untergeordneten Knotens
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


## **FAQ**

**Unterstützt SmartArt Animationen?**

Ja. SmartArt wird wie eine normale Form behandelt, sodass Sie [standardmäßige Animationen](/slides/de/cpp/shape-animation/) (Eintritt, Austritt, Hervorhebung, Bewegungspfade) anwenden und das Timing anpassen können. Bei Bedarf können Sie auch Formen innerhalb von SmartArt‑Knoten animieren.

**Wie kann ich ein bestimmtes SmartArt auf einer Folie zuverlässig finden, wenn seine interne ID unbekannt ist?**

Weisen Sie ihm einen [alternativen Text](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) zu und suchen Sie danach. Das Festlegen eines eindeutigen AltTextes für die SmartArt ermöglicht das programmgesteuerte Auffinden, ohne sich auf interne Kennungen zu verlassen.

**Wird das Aussehen von SmartArt beim Konvertieren in PDF erhalten bleiben?**

Ja. Aspose.Slides rendert SmartArt mit hoher visueller Treue während des [PDF-Exports](/slides/de/cpp/convert-powerpoint-to-pdf/), wobei Layout, Farben und Effekte erhalten bleiben.

**Kann ich ein Bild der gesamten SmartArt extrahieren (für Vorschaubilder oder Berichte)?**

Ja. Sie können eine SmartArt‑Form zu [Rasterformaten](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) oder zu [SVG](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/) rendern, um skalierbare Vektorausgaben zu erhalten, wodurch sie sich für Vorschaubilder, Berichte oder Web‑Verwendung eignet.