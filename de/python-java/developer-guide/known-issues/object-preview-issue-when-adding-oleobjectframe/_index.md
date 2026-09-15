---
title: Problem mit Objektvorschau beim Hinzufügen von OleObjectFrame
linktitle: OLE-Objekt-Problem
type: docs
weight: 10
url: /de/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- Vorschauproblem
- eingebettetes Objekt
- eingebettete Datei
- Objekt geändert
- Objektvorschau
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, warum EMBEDDED OLE OBJECT angezeigt wird, wenn Sie OleObjectFrame in Aspose.Slides für Python über Java hinzufügen, und wie Sie Vorschauprobleme in PPT-, PPTX- und ODP-Präsentationen beheben."
---
## **Einleitung**

Wenn Sie Aspose.Slides für Python über Java verwenden, um ein [OleObjectFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/oleobjectframe/) zu einer Folie hinzuzufügen, wird auf der Ausgabefolie eine Meldung „EMBEDDED OLE OBJECT“ angezeigt. Diese Meldung ist beabsichtigt und kein Fehler.

Für weitere Informationen zur Arbeit mit OLE‑Objekten siehe [OLE verwalten](/slides/de/python-java/manage-ole/).

## **Erklärung und Lösung**

Aspose.Slides zeigt die Meldung „EMBEDDED OLE OBJECT“ an, um Sie darauf hinzuweisen, dass das OLE‑Objekt geändert wurde und das Vorschaubild aktualisiert werden muss.

Zum Beispiel, wenn Sie ein Microsoft‑Excel‑Diagramm als [OleObjectFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/oleobjectframe/) zu einer Folie hinzufügen (für weitere Details siehe den Artikel „OLE verwalten“) und dann die Präsentation in Microsoft PowerPoint öffnen, sehen Sie dieses Bild auf der Folie:

![OLE object message](OLE_object_message.png)

Um zu bestätigen, dass Ihr OLE‑Objekt zur Folie hinzugefügt wurde, doppelklicken Sie auf die Meldung „EMBEDDED OLE OBJECT“ oder klicken Sie mit der rechten Maustaste darauf und wählen **Objekt > Bearbeiten**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint öffnet dann das eingebettete OLE‑Objekt.

![OLE object data](OLE_object_data.png)

Die Folie kann die Meldung „EMBEDDED OLE OBJECT“ beibehalten. Sobald Sie das OLE‑Objekt anklicken, wird die Folienvorschau aktualisiert und die Meldung „EMBEDDED OLE OBJECT“ durch das tatsächliche Bild des OLE‑Objekts ersetzt.

![OLE object preview](OLE_object_preview.png)

Speichern Sie Ihre Präsentation, um das aktualisierte Vorschaubild des OLE‑Objekts zu erhalten. Wenn Sie die Präsentation erneut öffnen, wird die Meldung „EMBEDDED OLE OBJECT“ nicht mehr angezeigt.

## **Andere Lösung**

Wenn Sie die Meldung „EMBEDDED OLE OBJECT“ nicht entfernen möchten, indem Sie die Präsentation in PowerPoint öffnen und dann speichern, können Sie die Meldung durch ein bevorzugtes Vorschaubild ersetzen. Der folgende Code demonstriert den Vorgang:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Füge ein Bild zu den Präsentationsressourcen hinzu.
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Setze einen Titel und das Bild für die OLE-Objektvorschau.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die Folie, die das [OleObjectFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/oleobjectframe/) enthält, ändert sich dann zu folgendem:

![New OLE object image](OLE_object_new_image.png)

## **FAQ**

**Warum wird die Meldung „EMBEDDED OLE OBJECT“ angezeigt?**

Die Meldung weist darauf hin, dass das OLE‑Objekt geändert wurde und sein Vorschaubild aktualisiert werden muss. Dieses Verhalten ist beabsichtigt.

**Wie kann ich die Vorschau in PowerPoint aktualisieren?**

Doppelklicken Sie die Meldung oder wählen Sie **Objekt > Bearbeiten**, um das eingebettete OLE‑Objekt zu öffnen. Klicken Sie auf das OLE‑Objekt, um die Vorschau zu aktualisieren, und speichern Sie anschließend die Präsentation.

**Kann ich die Meldung ersetzen, ohne die Präsentation in PowerPoint zu öffnen?**

Ja. Sie können dem OLE‑Objekt ein bevorzugtes Vorschaubild zuweisen, wie im obigen Codebeispiel gezeigt.