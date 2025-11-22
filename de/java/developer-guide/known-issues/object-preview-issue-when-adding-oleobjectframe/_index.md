---
title: "Problem mit der Objektvorschau beim Hinzufügen von OleObjectFrame"
linktitle: "OLE-Objekt-Problem"
type: docs
weight: 10
url: /de/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- Vorschauproblem
- eingebettetes Objekt
- eingebettete Datei
- Objekt geändert
- Objektvorschau
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, warum EMBEDDED OLE OBJECT beim Hinzufügen von OleObjectFrame in Aspose.Slides für Java erscheint und wie Sie Vorschauprobleme in PPT-, PPTX- und ODP-Präsentationen beheben."
---

## **Einführung**

Wenn Sie Aspose.Slides für Java verwenden und ein [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe/) zu einer Folie hinzufügen, wird auf der Ausgabefolie die Meldung „EMBEDDED OLE OBJECT“ angezeigt. Diese Meldung ist beabsichtigt und KEIN Fehler.

Weitere Informationen zur Arbeit mit OLE‑Objekten finden Sie unter [Manage OLE](/slides/de/java/manage-ole/). 

## **Erklärung und Lösung**

Aspose.Slides zeigt die Meldung „EMBEDDED OLE OBJECT“ an, um Sie darauf hinzuweisen, dass das OLE‑Objekt geändert wurde und das Vorschaubild aktualisiert werden muss. 

Beispielsweise, wenn Sie ein Microsoft‑Excel‑Diagramm als [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe/) zu einer Folie hinzufügen (weitere Details finden Sie im Artikel „Manage OLE“) und dann die Präsentation in Microsoft PowerPoint öffnen, sehen Sie dieses Bild auf der Folie:

![OLE‑Objekt‑Meldung](OLE_object_message.png)

Wenn Sie überprüfen und bestätigen möchten, dass Ihr OLE‑Objekt zur Folie hinzugefügt wurde, doppelklicken Sie auf die Meldung „EMBEDDED OLE OBJECT“ oder klicken Sie mit der rechten Maustaste darauf und wählen Sie **Object > Edit**.

![OLE‑Objekt‑Daten](OLE_object_data.png)

PowerPoint öffnet dann das eingebettete OLE‑Objekt.

Die Folie kann die Meldung „EMBEDDED OLE OBJECT“ beibehalten. Sobald Sie das OLE‑Objekt anklicken, wird die Folienvorschau aktualisiert und die Meldung „EMBEDDED OLE OBJECT“ durch das tatsächliche Bild des OLE‑Objekts ersetzt. 

![OLE‑Objekt‑Vorschau](OLE_object_preview.png)

Jetzt möchten Sie möglicherweise die Präsentation speichern, um sicherzustellen, dass das Bild des OLE‑Objekts korrekt aktualisiert wird. Auf diese Weise sehen Sie nach dem erneuten Öffnen der Präsentation die Meldung „EMBEDDED OLE OBJECT“ NICHT mehr. 

## **Weitere Lösungen**

### **Lösung 1: Ersetzen der Meldung „Embedded OLE Object“ durch ein Bild**

Wenn Sie die Meldung „EMBEDDED OLE OBJECT“ nicht entfernen möchten, indem Sie die Präsentation in PowerPoint öffnen und dann speichern, können Sie die Meldung durch Ihr bevorzugtes Vorschaubild ersetzen. Diese Codezeilen demonstrieren den Vorgang:
```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Bild zu Präsentationsressourcen hinzufügen.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // Titel und Bild für die OLE Objekt Vorschau festlegen.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```


Die Folie, die den `OleObjectFrame` enthält, ändert sich dann zu folgendem:

![Neues OLE‑Objekt‑Bild](OLE_object_new_image.png)

### **Lösung 2: Erstellen eines Add‑Ons für PowerPoint**

Sie können auch ein Add‑On für Microsoft PowerPoint erstellen, das alle OLE‑Objekte aktualisiert, wenn Sie Präsentationen im Programm öffnen.