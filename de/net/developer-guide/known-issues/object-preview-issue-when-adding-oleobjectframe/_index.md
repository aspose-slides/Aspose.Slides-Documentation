---
title: Problem mit Objektvorschau beim Hinzufügen von OleObjectFrame
linktitle: OLE-Objekt-Problem
type: docs
weight: 10
url: /de/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- Vorschauproblem
- eingebettetes Objekt
- eingebettete Datei
- Objekt geändert
- Objektvorschau
- Präsentation
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, warum EMBEDDED OLE OBJECT erscheint, wenn Sie OleObjectFrame in Aspose.Slides für .NET hinzufügen und wie Sie Vorschauprobleme in PPT-, PPTX- und ODP-Präsentationen beheben."
---

## **Einführung**

Wenn Sie Aspose.Slides für .NET verwenden und ein [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) zu einer Folie hinzufügen, wird auf der Ausgabefolie die Meldung "EMBEDDED OLE OBJECT" angezeigt. Diese Meldung ist beabsichtigt und NICHT ein Fehler.

Weitere Informationen zur Arbeit mit OLE‑Objekten finden Sie unter [Manage OLE](/slides/de/net/manage-ole/). 

## **Erklärung und Lösung**

Aspose.Slides zeigt die Meldung "EMBEDDED OLE OBJECT" an, um Sie darauf hinzuweisen, dass das OLE‑Objekt geändert wurde und das Vorschaubild aktualisiert werden muss. 

Beispielsweise, wenn Sie ein Microsoft‑Excel‑Diagramm als [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) zu einer Folie hinzufügen (weitere Details finden Sie im Artikel „Manage OLE“) und die Präsentation anschließend in Microsoft PowerPoint öffnen, sehen Sie dieses Bild auf der Folie:

![OLE‑Objekt‑Nachricht](OLE_object_message.png)

Um zu überprüfen und zu bestätigen, dass Ihr OLE‑Objekt zur Folie hinzugefügt wurde, müssen Sie doppelt auf die Meldung "EMBEDDED OLE OBJECT" klicken oder Sie können mit der rechten Maustaste darauf klicken und die Option **Objekt > Bearbeiten** wählen.

![OLE‑Objekt > Bearbeiten](OLE_object_edit.png)

PowerPoint öffnet dann das eingebettete OLE‑Objekt.

![OLE‑Objekt‑Daten](OLE_object_data.png)

Die Folie kann die Meldung "EMBEDDED OLE OBJECT" beibehalten. Sobald Sie auf das OLE‑Objekt klicken, wird die Folienvorschau aktualisiert und die Meldung "EMBEDDED OLE OBJECT" durch das eigentliche Bild des OLE‑Objekts ersetzt. 

![OLE‑Objekt‑Vorschau](OLE_object_preview.png)

Jetzt möchten Sie eventuell Ihre Präsentation speichern, um sicherzustellen, dass das Bild des OLE‑Objekts korrekt aktualisiert wird. Auf diese Weise sehen Sie nach dem Speichern der Präsentation beim erneuten Öffnen die Meldung "EMBEDDED OLE OBJECT" NICHT mehr. 

## **Weitere Lösungen**

### **Lösung 1: Ersetzen der "Embedded OLE Object"-Nachricht durch ein Bild**

Wenn Sie die Meldung "EMBEDDED OLE OBJECT" nicht durch Öffnen der Präsentation in PowerPoint und anschließendem Speichern entfernen möchten, können Sie die Meldung durch Ihr bevorzugtes Vorschaubild ersetzen. Diese Codezeilen zeigen den Vorgang:
```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set a title and the image for the OLE object preview.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```


Die Folie, die das `OleObjectFrame` enthält, wird dann wie folgt geändert:

![Neues OLE‑Objekt‑Bild](OLE_object_new_image.png)

### **Lösung 2: Add‑On für PowerPoint erstellen**

Sie können außerdem ein Add‑On für Microsoft PowerPoint erstellen, das alle OLE‑Objekte aktualisiert, wenn Sie Präsentationen im Programm öffnen.