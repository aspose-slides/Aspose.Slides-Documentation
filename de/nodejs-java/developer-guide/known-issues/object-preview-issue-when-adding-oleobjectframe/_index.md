---
title: Problem mit der Objektvorschau beim Hinzufügen von OleObjectFrame
linktitle: OLE-Objekt-Problem
type: docs
weight: 10
url: /de/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
aliases:
  - /nodejs-java/object-changed-issue-when-adding-oleobjectframe/
keywords:
- OLE
- Vorschauproblem
- eingebettetes Objekt
- eingebettete Datei
- Objekt geändert
- Objektvorschau
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, warum beim Hinzufügen von OleObjectFrame in Aspose.Slides für Node.js das EMBEDDED OLE OBJECT erscheint und wie Sie Vorschauprobleme in PPT-, PPTX- und ODP-Präsentationen beheben."
---
## **Einführung**

Wenn Sie Aspose.Slides für Java verwenden und ein [OleObjectFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/oleobjectframe/) zu einer Folie hinzufügen, wird auf der Ausgabefolie die Meldung „EMBEDDED OLE OBJECT“ angezeigt. Diese Meldung ist beabsichtigt und KEIN Fehler.

Weitere Informationen zur Arbeit mit OLE-Objekten finden Sie unter [Manage OLE](/slides/de/nodejs-java/manage-ole/).

## **Erklärung und Lösung**

Aspose.Slides zeigt die Meldung „EMBEDDED OLE OBJECT“ an, um Sie darauf hinzuweisen, dass das OLE-Objekt geändert wurde und das Vorschaubild aktualisiert werden muss. 

Zum Beispiel, wenn Sie ein Microsoft Excel-Diagramm als [OleObjectFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/oleobjectframe/) zu einer Folie hinzufügen (weitere Details siehe den Artikel „Manage OLE“) und dann die Präsentation in Microsoft PowerPoint öffnen, sehen Sie dieses Bild auf der Folie:

![OLE-Objekt-Meldung](OLE_object_message.png)

Wenn Sie überprüfen und bestätigen möchten, dass Ihr OLE-Objekt zur Folie hinzugefügt wurde, müssen Sie auf die Meldung „EMBEDDED OLE OBJECT“ doppelklicken oder Sie können mit der rechten Maustaste darauf klicken und die Option **Object > Edit** wählen.

![OLE-Objekt > Bearbeiten](OLE_object_edit.png)

PowerPoint öffnet dann das eingebettete OLE-Objekt.

![OLE-Objektdaten](OLE_object_data.png)

Die Folie kann die Meldung „EMBEDDED OLE OBJECT“ behalten. Sobald Sie auf das OLE-Objekt klicken, wird die Folienvorschau aktualisiert und die Meldung „EMBEDDED OLE OBJECT“ durch das tatsächliche Bild des OLE-Objekts ersetzt. 

![OLE-Objekt-Vorschau](OLE_object_preview.png)

Jetzt möchten Sie möglicherweise Ihre Präsentation speichern, um sicherzustellen, dass das Bild des OLE-Objekts korrekt aktualisiert wird. Auf diese Weise sehen Sie nach dem Speichern der Präsentation beim erneuten Öffnen die Meldung „EMBEDDED OLE OBJECT“ NICHT.

## **Weitere Lösungen**

### **Lösung 1: Ersetzen der Meldung „Embedded OLE Object“ durch ein Bild**

Wenn Sie die Meldung „EMBEDDED OLE OBJECT“ nicht entfernen möchten, indem Sie die Präsentation in PowerPoint öffnen und dann speichern, können Sie die Meldung durch Ihr bevorzugtes Vorschaubild ersetzen. Die folgenden Codezeilen zeigen den Vorgang:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // Fügen Sie ein Bild zu den Präsentationsressourcen hinzu.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // Setzen Sie einen Titel und das Bild für die OLE-Objektvorschau.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Die Folie, die das `OleObjectFrame` enthält, ändert sich dann zu folgendem:

![Neues OLE-Objekt-Bild](OLE_object_new_image.png)

### **Lösung 2: Erstellen eines Add-Ons für PowerPoint**

Sie können auch ein Add-On für Microsoft PowerPoint erstellen, das alle OLE-Objekte aktualisiert, wenn Sie Präsentationen im Programm öffnen.