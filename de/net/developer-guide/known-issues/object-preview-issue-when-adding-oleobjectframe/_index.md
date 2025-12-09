---
title: Problem mit der Objektvorschau beim Hinzufügen von OleObjectFrame
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
description: "Erfahren Sie, warum beim Hinzufügen von OleObjectFrame in Aspose.Slides für .NET die Meldung EMBEDDED OLE OBJECT angezeigt wird und wie Vorschauprobleme in PPT-, PPTX- und ODP-Präsentationen behoben werden können."
---

## **Einführung**

Verwenden Sie Aspose.Slides für .NET, wenn Sie ein [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) zu einer Folie hinzufügen, wird die Meldung „EMBEDDED OLE OBJECT“ auf der Ausgabefolie angezeigt. Diese Meldung ist beabsichtigt und KEIN Fehler.

Weitere Informationen zur Arbeit mit OLE-Objekten finden Sie unter [Manage OLE](/slides/de/net/manage-ole/). 

## **Erklärung und Lösung**

Aspose.Slides zeigt die Meldung „EMBEDDED OLE OBJECT“ an, um Sie darauf hinzuweisen, dass das OLE-Objekt geändert wurde und das Vorschaubild aktualisiert werden muss. 

Beispielsweise, wenn Sie ein Microsoft‑Excel‑Diagramm als [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) zu einer Folie hinzufügen (weitere Details siehe den Artikel „Manage OLE“) und anschließend die Präsentation in Microsoft PowerPoint öffnen, sehen Sie dieses Bild auf der Folie:

![OLE object message](OLE_object_message.png)

Wenn Sie prüfen und bestätigen möchten, dass Ihr OLE‑Objekt zur Folie hinzugefügt wurde, müssen Sie auf die Meldung „EMBEDDED OLE OBJECT“ doppelklicken oder mit der rechten Maustaste darauf klicken und die Option **Objekt > Bearbeiten** wählen.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint öffnet dann das eingebettete OLE‑Objekt.

![OLE object data](OLE_object_data.png)

Die Folie kann die Meldung „EMBEDDED OLE OBJECT“ weiterhin anzeigen. Sobald Sie auf das OLE‑Objekt klicken, wird die Folienvorschau aktualisiert und die Meldung „EMBEDDED OLE OBJECT“ durch das tatsächliche Bild des OLE‑Objekts ersetzt. 

![OLE object preview](OLE_object_preview.png)

Nun möchten Sie möglicherweise Ihre Präsentation speichern, um sicherzustellen, dass das Bild des OLE‑Objekts korrekt aktualisiert wird. Auf diese Weise sehen Sie nach dem erneuten Öffnen der Präsentation die Meldung „EMBEDDED OLE OBJECT“ nicht mehr. 

## **Weitere Lösungen**

### **Lösung 1: Die Meldung „Embedded OLE Object“ durch ein Bild ersetzen**

Wenn Sie die Meldung „EMBEDDED OLE OBJECT“ nicht entfernen möchten, indem Sie die Präsentation in PowerPoint öffnen und anschließend speichern, können Sie die Meldung durch ein bevorzugtes Vorschaubild ersetzen. Die folgenden Codezeilen demonstrieren den Vorgang:
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

Sie können außerdem ein Add‑On für Microsoft PowerPoint erstellen, das beim Öffnen von Präsentationen alle OLE‑Objekte aktualisiert.