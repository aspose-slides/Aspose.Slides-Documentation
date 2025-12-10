---
title: SmartArt-Grafiken in Präsentationen mit C++ verwalten
linktitle: SmartArt-Grafiken
type: docs
weight: 20
url: /de/cpp/manage-smartart-shape/
keywords:
- SmartArt-Objekt
- SmartArt-Grafik
- SmartArt-Stil
- SmartArt-Farbe
- SmartArt erstellen
- SmartArt hinzufügen
- SmartArt bearbeiten
- SmartArt ändern
- SmartArt zugreifen
- SmartArt-Layout-Typ
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Automatisieren Sie die Erstellung, Bearbeitung und Gestaltung von PowerPoint-SmartArt in C++ mithilfe von Aspose.Slides, mit prägnanten Code-Beispielen und leistungsorientierten Anleitungen."
---

## **SmartArt-Form erstellen**
Aspose.Slides for C++ ermöglicht jetzt das Hinzufügen benutzerdefinierter SmartArt‑Formen zu Folien von Grund auf. Aspose.Slides for C++ stellt die einfachste API bereit, um SmartArt‑Formen auf leichteste Weise zu erstellen. Um eine SmartArt‑Form in einer Folie zu erstellen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Holen Sie die Referenz einer Folie anhand ihres Index.
- Fügen Sie eine SmartArt‑Form hinzu, indem Sie deren LayoutType festlegen.
- Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}

## **Zugriff auf eine SmartArt-Form auf einer Folie**
Der folgende Code wird verwendet, um die in der Präsentationsfolie hinzugefügten SmartArt‑Formen zuzugreifen. Im Beispielcode durchlaufen wir jede Form in der Folie und prüfen, ob es sich um eine SmartArt‑Form handelt. Ist die Form vom Typ SmartArt, casten wir sie in eine SmartArt‑Instanz um.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **Zugriff auf eine SmartArt-Form mit einem bestimmten Layouttyp**
Der folgende Beispielcode hilft, die SmartArt‑Form mit einem bestimmten LayoutType zu erreichen. Bitte beachten Sie, dass Sie den LayoutType der SmartArt nicht ändern können, da er schreibgeschützt ist und nur beim Hinzufügen der SmartArt‑Form festgelegt wird.

- Erstellen Sie eine Instanz der `Presentation`‑Klasse und laden Sie die Präsentation mit SmartArt‑Form.
- Holen Sie die Referenz der ersten Folie anhand ihres Index.
- Durchlaufen Sie jede Form in der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form bei Bedarf zu SmartArt.
- Prüfen Sie die SmartArt‑Form mit dem gewünschten LayoutType und führen Sie anschließend die notwendigen Aktionen aus.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}

## **Stil einer SmartArt-Form ändern**
Der folgende Beispielcode hilft, die SmartArt‑Form mit einem bestimmten LayoutType zu erreichen.

- Erstellen Sie eine Instanz der `Presentation`‑Klasse und laden Sie die Präsentation mit SmartArt‑Form.
- Holen Sie die Referenz der ersten Folie anhand ihres Index.
- Durchlaufen Sie jede Form in der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form bei Bedarf zu SmartArt.
- Finden Sie die SmartArt‑Form mit dem gewünschten Stil.
- Setzen Sie den neuen Stil für die SmartArt‑Form.
- Speichern Sie die Präsentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}

## **Farbstil einer SmartArt-Form ändern**
In diesem Beispiel lernen wir, den Farbstil einer beliebigen SmartArt‑Form zu ändern. Der folgende Beispielcode greift auf die SmartArt‑Form mit einem bestimmten Farbstil zu und ändert diesen Stil.

- Erstellen Sie eine Instanz der `Presentation`‑Klasse und laden Sie die Präsentation mit SmartArt‑Form.
- Holen Sie die Referenz der ersten Folie anhand ihres Index.
- Durchlaufen Sie jede Form in der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form bei Bedarf zu SmartArt.
- Finden Sie die SmartArt‑Form mit dem gewünschten Farbstil.
- Setzen Sie den neuen Farbstil für die SmartArt‑Form.
- Speichern Sie die Präsentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **FAQ**

**Kann ich SmartArt als einzelnes Objekt animieren?**

Ja. SmartArt ist eine Form, sodass Sie über die Animations‑API [standard animations](/slides/de/cpp/powerpoint-animation/) (Eingang, Ausgang, Betonung, Bewegungspfade) wie bei anderen Formen anwenden können.

**Wie finde ich ein bestimmtes SmartArt auf einer Folie, wenn ich seine interne ID nicht kenne?**

Legen Sie den Alternativtext (AltText) fest und suchen Sie die Form nach diesem Wert – das ist ein empfohlener Weg, die Ziel‑Form zu lokalisieren.

**Kann ich SmartArt mit anderen Formen gruppieren?**

Ja. Sie können SmartArt mit anderen Formen (Bilder, Tabellen usw.) gruppieren und dann die Gruppe [manipulieren](/slides/de/cpp/group/).

**Wie erhalte ich ein Bild eines bestimmten SmartArt (z. B. für eine Vorschau oder einen Bericht)?**

Exportieren Sie ein Miniatur‑/Bild der Form; die Bibliothek kann einzelne Formen [rendern](/slides/de/cpp/create-shape-thumbnails/) zu Rasterdateien (PNG/JPG/TIFF).

**Wird das Aussehen von SmartArt beim Konvertieren der gesamten Präsentation in PDF erhalten bleiben?**

Ja. Die Rendering‑Engine zielt auf hohe Treue beim [PDF‑Export](/slides/de/cpp/convert-powerpoint-to-pdf/) ab, mit einer Reihe von Qualitäts‑ und Kompatibilitätsoptionen.