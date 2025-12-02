---
title: Problem mit Objektvorschau beim Hinzufügen von OleObjectFrame
linktitle: OLE-Objektproblem
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
description: "Erfahren Sie, warum beim Hinzufügen von OleObjectFrame in Aspose.Slides für Python die Meldung EMBEDDED OLE OBJECT erscheint und wie Sie Vorschauprobleme in PPT-, PPTX- und ODP-Präsentationen beheben können."
---

## **Einleitung**

Wenn Sie Aspose.Slides für Python via .NET verwenden und ein [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) zu einer Folie hinzufügen, wird auf der Ausgabefolie eine Meldung "EMBEDDED OLE OBJECT" angezeigt. Diese Meldung ist beabsichtigt und KEIN Fehler.

Weitere Informationen zur Arbeit mit OLE‑Objekten finden Sie unter [Manage OLE](/slides/de/python-net/manage-ole/). 

## **Erklärung und Lösung**

Aspose.Slides zeigt die Meldung "EMBEDDED OLE OBJECT" an, um Sie darauf hinzuweisen, dass das OLE‑Objekt geändert wurde und das Vorschaubild aktualisiert werden muss. 

Beispielsweise, wenn Sie ein Microsoft Excel‑Diagramm als [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) zu einer Folie hinzufügen (weitere Details finden Sie im Artikel "Manage OLE") und die Präsentation dann in Microsoft PowerPoint öffnen, sehen Sie dieses Bild auf der Folie:

![OLE object message](OLE_object_message.png)

Wenn Sie prüfen und bestätigen möchten, dass Ihr OLE‑Objekt zur Folie hinzugefügt wurde, müssen Sie die Meldung "EMBEDDED OLE OBJECT" doppelklicken oder mit der rechten Maustaste darauf klicken und die Option **Object > Edit** auswählen.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint öffnet dann das eingebettete OLE‑Objekt.

![OLE object data](OLE_object_data.png)

Die Folie kann die Meldung "EMBEDDED OLE OBJECT" beibehalten. Sobald Sie auf das OLE‑Objekt klicken, wird die Folienvorschau aktualisiert und die Meldung "EMBEDDED OLE OBJECT" durch das tatsächliche Bild des OLE‑Objekts ersetzt. 

![OLE object preview](OLE_object_preview.png)

Jetzt möchten Sie möglicherweise Ihre Präsentation speichern, um sicherzustellen, dass das Bild des OLE‑Objekts korrekt aktualisiert wird. Auf diese Weise sehen Sie nach dem Speichern und erneutem Öffnen der Präsentation die Meldung "EMBEDDED OLE OBJECT" NICHT. 

## **Weitere Lösungen**

### **Lösung 1: Die Meldung "Embedded OLE Object" durch ein Bild ersetzen**

Wenn Sie die Meldung "EMBEDDED OLE OBJECT" nicht durch Öffnen und Speichern der Präsentation in PowerPoint entfernen wollen, können Sie die Meldung durch Ihr bevorzugtes Vorschaubild ersetzen. Diese Codezeilen demonstrieren den Vorgang:
```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Füge ein Bild zu den Präsentationsressourcen hinzu.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # Setze einen Titel und das Bild für die OLE-Objektvorschau.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```


Die Folie, die das `OleObjectFrame` enthält, ändert sich dann zu folgendem:

![New OLE object image](OLE_object_new_image.png)

### **Lösung 2: Ein Add‑On für PowerPoint erstellen**

Sie können auch ein Add‑On für Microsoft PowerPoint erstellen, das beim Öffnen von Präsentationen im Programm alle OLE‑Objekte aktualisiert.