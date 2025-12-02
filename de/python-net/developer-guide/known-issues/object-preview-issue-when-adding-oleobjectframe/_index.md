---
title: Objektvorschau-Problem beim Hinzufügen von OleObjectFrame
linktitle: OLE-Objekt-Problem
type: docs
weight: 10
url: /de/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- Vorschauproblem
- eingebettetes Objekt
- eingebettete Datei
- Objekt geändert
- Objektvorschau
- Präsentation
- PowerPoint
- Python
- Aspose.Slides
description: "Erfahren Sie, warum EMBEDDED OLE OBJECT erscheint, wenn OleObjectFrame in Aspose.Slides für Python hinzugefügt wird, und wie Sie Vorschauprobleme in PPT-, PPTX- und ODP-Präsentationen beheben."
---

## **Einführung**

Wenn Sie Aspose.Slides für Python über .NET verwenden und ein [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) zu einer Folie hinzufügen, wird auf der Ausgabefolie die Meldung „EMBEDDED OLE OBJECT“ angezeigt. Diese Meldung ist beabsichtigt und KEIN Fehler.

Weitere Informationen zur Arbeit mit OLE‑Objekten finden Sie unter [OLE verwalten](/slides/de/python-net/manage-ole/). 

## **Erläuterung und Lösung**

Aspose.Slides zeigt die Meldung „EMBEDDED OLE OBJECT“ an, um Sie darauf hinzuweisen, dass das OLE‑Objekt geändert wurde und das Vorschaubild aktualisiert werden muss. 

Beispielsweise, wenn Sie ein Microsoft Excel‑Diagramm als [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) zu einer Folie hinzufügen (für weitere Details siehe den Artikel „Manage OLE“) und dann die Präsentation in Microsoft PowerPoint öffnen, sehen Sie dieses Bild auf der Folie:

![OLE‑Objekt‑Meldung](OLE_object_message.png)

Wenn Sie überprüfen und bestätigen möchten, dass Ihr OLE‑Objekt zur Folie hinzugefügt wurde, müssen Sie doppelt auf die Meldung „EMBEDDED OLE OBJECT“ klicken oder mit der rechten Maustaste darauf klicken und die Option **Object > Edit** wählen.

![OLE‑Objekt > Bearbeiten](OLE_object_edit.png)

PowerPoint öffnet dann das eingebettete OLE‑Objekt.

![OLE‑Objekt‑Daten](OLE_object_data.png)

Die Folie kann die Meldung „EMBEDDED OLE OBJECT“ behalten. Sobald Sie auf das OLE‑Objekt klicken, wird die Folienvorschau aktualisiert und die Meldung „EMBEDDED OLE OBJECT“ durch das tatsächliche Bild des OLE‑Objekts ersetzt. 

![OLE‑Objekt‑Vorschau](OLE_object_preview.png)

Jetzt möchten Sie Ihre Präsentation möglicherweise speichern, um sicherzustellen, dass das Bild des OLE‑Objekts korrekt aktualisiert wird. Auf diese Weise wird nach dem Speichern der Präsentation beim erneuten Öffnen die Meldung „EMBEDDED OLE OBJECT“ NICHT mehr angezeigt. 

## **Weitere Lösungen**

### **Lösung 1: Ersetzen Sie die Meldung „EMBEDDED OLE OBJECT“ durch ein Bild**

Wenn Sie die Meldung „EMBEDDED OLE OBJECT“ nicht entfernen möchten, indem Sie die Präsentation in PowerPoint öffnen und dann speichern, können Sie die Meldung durch Ihr bevorzugtes Vorschaubild ersetzen. Diese Codezeilen demonstrieren den Vorgang:
```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Bild zu Präsentationsressourcen hinzufügen.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # Titel und Bild für die OLE-Objektvorschau festlegen.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```


Die Folie, die das `OleObjectFrame` enthält, ändert sich dann zu folgendem:

![Neues OLE‑Objekt‑Bild](OLE_object_new_image.png)

### **Lösung 2: Erstellen Sie ein Add‑On für PowerPoint**

Sie können auch ein Add‑On für Microsoft PowerPoint erstellen, das beim Öffnen von Präsentationen im Programm alle OLE‑Objekte aktualisiert.