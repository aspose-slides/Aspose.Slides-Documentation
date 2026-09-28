---
title: Objektvorschau-Platzhalter beim Hinzufügen von OleObjectFrame
linktitle: OLE-Vorschau-Platzhalter
type: docs
weight: 10
url: /de/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- Vorschauproblem
- Vorschau-Platzhalter
- wie vorgesehen
- eingebettetes Objekt
- eingebettete Datei
- Objekt geändert
- Objektvorschau
- Präsentation
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Warum ein mit Aspose.Slides für .NET hinzugefügtes OLE-Objekt einen EMBEDDED OLE OBJECT-Platzhalter anzeigt, bis seine Vorschau aktualisiert ist, und wie Sie Ihr eigenes Vorschaubild festlegen."
---
## **Einleitung**

Wenn Sie Aspose.Slides für .NET verwenden und einer Folie ein [OleObjectFrame](https://reference.aspose.com/slides/de/net/aspose.slides/oleobjectframe/) hinzufügen, wird auf der ausgegebenen Folie die Meldung „EMBEDDED OLE OBJECT“ angezeigt. Diese Meldung ist beabsichtigt und KEIN Fehler.

Weitere Informationen zur Arbeit mit OLE‑Objekten finden Sie unter [OLE verwalten](/slides/de/net/manage-ole/).

## **Erklärung und Lösung**

Aspose.Slides zeigt die Meldung „EMBEDDED OLE OBJECT“ an, um Sie darauf hinzuweisen, dass das OLE‑Objekt geändert wurde und das Vorschaubild aktualisiert werden muss.

Wenn Sie beispielsweise ein Microsoft‑Excel‑Diagramm als [OleObjectFrame](https://reference.aspose.com/slides/de/net/aspose.slides/oleobjectframe/) zu einer Folie hinzufügen (weitere Details finden Sie im Artikel „OLE verwalten“) und dann die Präsentation in Microsoft PowerPoint öffnen, sehen Sie dieses Bild auf der Folie:

![OLE‑Objekt‑Meldung](OLE_object_message.png)

Wenn Sie überprüfen und bestätigen möchten, dass Ihr OLE‑Objekt zur Folie hinzugefügt wurde, müssen Sie doppelt auf die Meldung „EMBEDDED OLE OBJECT“ klicken oder mit der rechten Maustaste darauf klicken und den Menüpunkt **Objekt > Bearbeiten** wählen.

![OLE‑Objekt > Bearbeiten](OLE_object_edit.png)

PowerPoint öffnet dann das eingebettete OLE‑Objekt.

![OLE‑Objekt‑Daten](OLE_object_data.png)

Die Folie kann die Meldung „EMBEDDED OLE OBJECT“ weiterhin anzeigen. Sobald Sie auf das OLE‑Objekt klicken, wird die Folienvorschau aktualisiert und die Meldung „EMBEDDED OLE OBJECT“ durch das tatsächliche Bild des OLE‑Objekts ersetzt.

![OLE‑Objekt‑Vorschau](OLE_object_preview.png)

Jetzt möchten Sie möglicherweise Ihre Präsentation speichern, um sicherzustellen, dass das Bild des OLE‑Objekts korrekt aktualisiert wird. Auf diese Weise wird nach dem Speichern der Präsentation, wenn Sie sie erneut öffnen, die Meldung „EMBEDDED OLE OBJECT“ **nicht** mehr angezeigt.

## **Weitere Lösungen**

### **Lösung 1: Die Meldung „Embedded OLE Object“ durch ein Bild ersetzen**

Wenn Sie die Meldung „EMBEDDED OLE OBJECT“ nicht entfernen möchten, indem Sie die Präsentation in PowerPoint öffnen und dann speichern, können Sie die Meldung durch Ihr bevorzugtes Vorschaubild ersetzen. Die folgenden Codezeilen zeigen das Vorgehen:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Bild zu den Präsentationsressourcen hinzufügen.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Bild für die OLE-Objektvorschau festlegen.
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

Die Folie, die das `OleObjectFrame` enthält, wird dann wie folgt geändert:

![Neues OLE‑Objekt‑Bild](OLE_object_new_image.png)

### **Lösung 2: Add‑On für PowerPoint erstellen**

Sie können zudem ein Add‑On für Microsoft PowerPoint erstellen, das beim Öffnen von Präsentationen im Programm alle OLE‑Objekte aktualisiert.