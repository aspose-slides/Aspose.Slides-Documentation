---
title: Problem mit der Objektvorschau beim Hinzufügen von OleObjectFrame
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
description: "Erfahren Sie, warum EMBEDDED OLE OBJECT angezeigt wird, wenn OleObjectFrame in Aspose.Slides für Python hinzugefügt wird, und wie Sie Vorschauprobleme in PPT-, PPTX- und ODP-Präsentationen beheben."
---

## **Einführung**

Beim Verwenden von Aspose.Slides für Python über .NET wird beim Hinzufügen von [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) zu einer Folie eine Meldung „EMBEDDED OLE OBJECT“ auf der ausgegebenen Folie angezeigt. Diese Meldung ist beabsichtigt und KEIN Fehler.

Weitere Informationen zur Arbeit mit OLE‑Objekten finden Sie unter [Manage OLE](/slides/de/python-net/manage-ole/). 

## **Erklärung und Lösung**

Aspose.Slides zeigt die Meldung „EMBEDDED OLE OBJECT“ an, um Sie darauf hinzuweisen, dass das OLE‑Objekt geändert wurde und das Vorschaubild aktualisiert werden muss. 

Beispielsweise, wenn Sie ein Microsoft Excel‑Diagramm als [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) zu einer Folie hinzufügen (weitere Details finden Sie im Artikel „Manage OLE“) und anschließend die Präsentation in Microsoft PowerPoint öffnen, wird in der Folie dieses Bild angezeigt:

![OLE-Objekt-Nachricht](OLE_object_message.png)

Wenn Sie prüfen und bestätigen möchten, dass Ihr OLE‑Objekt zur Folie hinzugefügt wurde, müssen Sie doppelt auf die Meldung „EMBEDDED OLE OBJECT“ klicken oder Sie klicken mit der rechten Maustaste darauf und wählen die Option **Objekt > Bearbeiten**.

![OLE‑Objekt > Bearbeiten](OLE_object_edit.png)

PowerPoint öffnet dann das eingebettete OLE‑Objekt.

![OLE‑Objektdaten](OLE_object_data.png)

Die Folie kann weiterhin die Meldung „EMBEDDED OLE OBJECT“ anzeigen. Sobald Sie auf das OLE‑Objekt klicken, wird die Folienvorschau aktualisiert und die Meldung „EMBEDDED OLE OBJECT“ durch das tatsächliche Bild des OLE‑Objekts ersetzt. 

![OLE‑Objekt‑Vorschau](OLE_object_preview.png)

Jetzt möchten Sie möglicherweise die Präsentation speichern, um sicherzustellen, dass das Bild des OLE‑Objekts korrekt aktualisiert wird. Auf diese Weise sehen Sie nach dem Speichern der Präsentation beim erneuten Öffnen die Meldung „EMBEDDED OLE OBJECT“ NICHT mehr. 

## **Weitere Lösungen**

### **Lösung 1: Ersetzen der „Embedded OLE Object“-Nachricht durch ein Bild**

Wenn Sie die Meldung „EMBEDDED OLE OBJECT“ nicht entfernen möchten, indem Sie die Präsentation in PowerPoint öffnen und anschließend speichern, können Sie die Meldung durch Ihr gewünschtes Vorschaubild ersetzen. Die folgenden Codezeilen zeigen den Vorgang:
```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Bild zu Präsentationsressourcen hinzufügen.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # Titel und Bild für die OLE-Objektvorschau setzen.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```


Die Folie, die das `OleObjectFrame` enthält, ändert sich dann zu folgendem:

![Neues OLE‑Objekt‑Bild](OLE_object_new_image.png)

### **Lösung 2: Add‑On für PowerPoint erstellen**

Sie können außerdem ein Add‑On für Microsoft PowerPoint erstellen, das beim Öffnen von Präsentationen im Programm alle OLE‑Objekte aktualisiert.