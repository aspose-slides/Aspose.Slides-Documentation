---
title: Problem mit der Objektvorschau beim Hinzufügen von OleObjectFrame
linktitle: OLE-Objekt-Problem
type: docs
weight: 10
url: /de/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- Vorschau-Problem
- eingebettetes Objekt
- eingebettete Datei
- Objekt geändert
- Objektvorschau
- Präsentation
- PowerPoint
- Python
- Aspose.Slides
description: "Erfahren Sie, warum die Meldung EMBEDDED OLE OBJECT beim Hinzufügen von OleObjectFrame in Aspose.Slides für Python angezeigt wird und wie Vorschauprobleme in PPT-, PPTX- und ODP-Präsentationen behoben werden."
---

## **Einleitung**

Wenn Sie Aspose.Slides für Python über .NET verwenden und einer Folie ein [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) hinzufügen, wird auf der Ausgabefolie die Meldung „EMBEDDED OLE OBJECT“ angezeigt. Diese Meldung ist beabsichtigt und KEIN Fehler.

Für weitere Informationen zur Arbeit mit OLE‑Objekten siehe [Manage OLE](/slides/de/python-net/manage-ole/).

## **Erklärung und Lösung**

Aspose.Slides zeigt die Meldung „EMBEDDED OLE OBJECT“ an, um Sie darauf hinzuweisen, dass das OLE‑Objekt geändert wurde und das Vorschaubild aktualisiert werden muss.

Zum Beispiel, wenn Sie ein Microsoft‑Excel‑Diagramm als [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) zu einer Folie hinzufügen (weitere Details finden Sie im Artikel „Manage OLE“) und die Präsentation anschließend in Microsoft PowerPoint öffnen, sehen Sie dieses Bild auf der Folie:

![OLE-Objektmeldung](OLE_object_message.png)

Wenn Sie überprüfen und bestätigen möchten, dass Ihr OLE‑Objekt zur Folie hinzugefügt wurde, müssen Sie doppelt auf die Meldung „EMBEDDED OLE OBJECT“ klicken oder mit der rechten Maustaste darauf klicken und über die Option **Object > Edit** gehen.

![OLE-Objekt > Bearbeiten](OLE_object_edit.png)

PowerPoint öffnet dann das eingebettete OLE‑Objekt.

![OLE-Objektdaten](OLE_object_data.png)

Die Folie kann die Meldung „EMBEDDED OLE OBJECT“ beibehalten. Sobald Sie auf das OLE‑Objekt klicken, wird die Folienvorschau aktualisiert und die Meldung „EMBEDDED OLE OBJECT“ durch das eigentliche Bild des OLE‑Objekts ersetzt.

![OLE-Objektvorschau](OLE_object_preview.png)

Jetzt möchten Sie vielleicht Ihre Präsentation speichern, um sicherzustellen, dass das Bild für das OLE‑Objekt korrekt aktualisiert wird. Auf diese Weise sehen Sie nach dem erneuten Öffnen der Präsentation die Meldung „EMBEDDED OLE OBJECT“ nicht mehr.

## **Weitere Lösungen**

### **Lösung 1: Die Meldung „Embedded OLE Object“ durch ein Bild ersetzen**

Wenn Sie die Meldung „EMBEDDED OLE OBJECT“ nicht entfernen möchten, indem Sie die Präsentation in PowerPoint öffnen und anschließend speichern, können Sie die Meldung durch Ihr gewünschtes Vorschaubild ersetzen. Diese Codezeilen demonstrieren den Vorgang:
```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Fügen Sie ein Bild zu den Präsentationsressourcen hinzu.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # Legen Sie einen Titel und das Bild für die OLE-Objektvorschau fest.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```


Die Folie, die das `OleObjectFrame` enthält, ändert sich dann zu folgendem:

![Neues OLE-Objektbild](OLE_object_new_image.png)

### **Lösung 2: Add‑On für PowerPoint erstellen**

Sie können zudem ein Add‑On für Microsoft PowerPoint erstellen, das beim Öffnen von Präsentationen alle OLE‑Objekte aktualisiert.