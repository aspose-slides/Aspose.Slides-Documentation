---
title: Problem mit der Objektvorschau beim Hinzufügen von OleObjectFrame
linktitle: OLE-Objektproblem
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
description: "Erfahren Sie, warum beim Hinzufügen von OleObjectFrame in Aspose.Slides für .NET die Meldung EMBEDDED OLE OBJECT angezeigt wird und wie Sie Vorschauprobleme in PPT-, PPTX- und ODP-Präsentationen beheben."
---

## **Einleitung**

Mit Aspose.Slides für .NET wird beim Hinzufügen von [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) zu einer Folie die Meldung „EMBEDDED OLE OBJECT“ auf der Ausgabefolie angezeigt. Diese Meldung ist beabsichtigt und KEIN Fehler.

Weitere Informationen zur Arbeit mit OLE‑Objekten finden Sie unter [Manage OLE](/slides/de/net/manage-ole/). 

## **Erklärung und Lösung**

Aspose.Slides zeigt die Meldung „EMBEDDED OLE OBJECT“ an, um Sie darauf hinzuweisen, dass das OLE‑Objekt geändert wurde und das Vorschaubild aktualisiert werden muss. 

Beispielsweise, wenn Sie ein Microsoft‑Excel‑Diagramm als [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) zu einer Folie hinzufügen (weitere Details siehe den Artikel „Manage OLE“) und anschließend die Präsentation in Microsoft PowerPoint öffnen, wird dieses Bild auf der Folie angezeigt:

![OLE object message](OLE_object_message.png)

Wenn Sie überprüfen und bestätigen möchten, dass Ihr OLE‑Objekt zur Folie hinzugefügt wurde, müssen Sie doppelklicken auf die Meldung „EMBEDDED OLE OBJECT“ oder Sie können mit der rechten Maustaste darauf klicken und über die Option **Object > Edit** gehen.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint öffnet dann das eingebettete OLE‑Objekt.

![OLE object data](OLE_object_data.png)

Die Folie kann die Meldung „EMBEDDED OLE OBJECT“ beibehalten. Sobald Sie auf das OLE‑Objekt klicken, wird die Folienvorschau aktualisiert und die Meldung „EMBEDDED OLE OBJECT“ durch das tatsächliche Bild des OLE‑Objekts ersetzt. 

![OLE object preview](OLE_object_preview.png)

Jetzt möchten Sie möglicherweise die Präsentation speichern, um sicherzustellen, dass das Bild für das OLE‑Objekt korrekt aktualisiert wird. Auf diese Weise sehen Sie nach dem Speichern der Präsentation beim erneuten Öffnen die Meldung „EMBEDDED OLE OBJECT“ NICHT mehr. 

## **Weitere Lösungen**

### **Lösung 1: Die Meldung „Embedded OLE Object“ durch ein Bild ersetzen**

Wenn Sie die Meldung „EMBEDDED OLE OBJECT“ nicht entfernen möchten, indem Sie die Präsentation in PowerPoint öffnen und dann speichern, können Sie die Meldung durch Ihr bevorzugtes Vorschaubild ersetzen. Diese Codezeilen demonstrieren den Vorgang:
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


Die Folie, die das `OleObjectFrame` enthält, ändert sich dann zu folgendem:

![New OLE object image](OLE_object_new_image.png)

### **Lösung 2: Ein Add‑On für PowerPoint erstellen**

Sie können auch ein Add‑On für Microsoft PowerPoint erstellen, das alle OLE‑Objekte aktualisiert, wenn Sie Präsentationen im Programm öffnen.