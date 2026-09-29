---
title: Objekt-Vorschau-Platzhalter beim Hinzufügen von OleObjectFrame
linktitle: OLE-Vorschau-Platzhalter
type: docs
weight: 10
url: /de/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- Vorschauproblem
- Vorschauplatzhalter
- nach Design
- eingebettetes Objekt
- eingebettete Datei
- Objekt geändert
- Objektvorschau
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Warum ein mit Aspose.Slides für Java hinzugefügtes OLE‑Objekt bis zur Aktualisierung seiner Vorschau einen EMBEDDED OLE OBJECT‑Platzhalter anzeigt und wie Sie Ihr eigenes Vorschau‑Bild festlegen."
---
## **Einleitung**

Wenn Sie Aspose.Slides für Java verwenden und ein [OleObjectFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/oleobjectframe/) zu einer Folie hinzufügen, wird auf der Ausgabefolie die Meldung „EMBEDDED OLE OBJECT“ angezeigt. Diese Meldung ist beabsichtigt und **KEIN** Fehler.

Weitere Informationen zur Arbeit mit OLE‑Objekten finden Sie unter [OLE verwalten](/slides/de/java/manage-ole/).

## **Erklärung und Lösung**

Aspose.Slides zeigt die Meldung „EMBEDDED OLE OBJECT“ an, um Sie darauf hinzuweisen, dass das OLE‑Objekt geändert wurde und das Vorschaubild aktualisiert werden muss.

Beispielsweise, wenn Sie ein Microsoft‑Excel‑Diagramm als [OleObjectFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/oleobjectframe/) zu einer Folie hinzufügen (für weitere Details siehe den Artikel „OLE verwalten“) und dann die Präsentation in Microsoft PowerPoint öffnen, sehen Sie dieses Bild auf der Folie:

![OLE‑Objekt‑Meldung](OLE_object_message.png)

Wenn Sie überprüfen und bestätigen möchten, dass Ihr OLE‑Objekt zur Folie hinzugefügt wurde, müssen Sie doppelklicken auf die Meldung „EMBEDDED OLE OBJECT“ oder mit der rechten Maustaste darauf klicken und die Option **Object > Edit** auswählen.

![OLE‑Objekt > Bearbeiten](OLE_object_edit.png)

PowerPoint öffnet dann das eingebettete OLE‑Objekt.

![OLE‑Objekt‑Daten](OLE_object_data.png)

Die Folie kann die Meldung „EMBEDDED OLE OBJECT“ beibehalten. Sobald Sie auf das OLE‑Objekt klicken, wird die Folienvorschau aktualisiert und die Meldung „EMBEDDED OLE OBJECT“ durch das tatsächliche Bild des OLE‑Objekts ersetzt.

![OLE‑Objekt‑Vorschau](OLE_object_preview.png)

Jetzt möchten Sie möglicherweise die Präsentation speichern, um sicherzustellen, dass das Bild des OLE‑Objekts korrekt aktualisiert wird. Auf diese Weise sehen Sie nach dem Speichern der Präsentation beim erneuten Öffnen der Präsentation die Meldung „EMBEDDED OLE OBJECT“ **NICHT**.

## **Weitere Lösung**

Wenn Sie die Meldung „EMBEDDED OLE OBJECT“ nicht entfernen möchten, indem Sie die Präsentation in PowerPoint öffnen und anschließend speichern, können Sie die Meldung durch Ihr bevorzugtes Vorschaubild ersetzen. Dieser Code demonstriert den Vorgang. Dabei wird angenommen, dass die erste Form auf der ersten Folie von *embeddedOLE.pptx* das OLE‑Objekt‑Frame ist und dass *myImage.png* das anzuzeigende Bild enthält; das Ergebnis wird als *embeddedOLE‑newImage.pptx* gespeichert:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Bild zu den Präsentationsressourcen hinzufügen.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);
    image.dispose();

    // Bild für die OLE-Objekt-Vorschau festlegen.
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Folie, die das `OleObjectFrame` enthält, wird dann wie folgt geändert:

![Neues OLE‑Objekt‑Bild](OLE_object_new_image.png)