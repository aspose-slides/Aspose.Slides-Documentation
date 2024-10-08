---
title: Objekt geändert Problem beim Hinzufügen von OleObjectFrame
type: docs
weight: 10
url: /de/net/object-changed-issue-when-adding-oleobjectframe/
---

{{% alert color="primary" %}} 

Bei der Verwendung von Aspose.Slides für .NET, wenn Sie **[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)** zu einer Folie hinzufügen, wird eine **Objekt geändert**-Meldung auf der Ausgabefolie angezeigt (und NICHT auf dem OLE-Objekt). Der beschriebene Prozess ist eine bewusste Handlung und KEIN Fehler. 

Für weitere Informationen zur Arbeit mit OLE-Objekten siehe [OLE verwalten](/slides/de/net/manage-ole/). 

{{% /alert %}} 
## **Erklärung** und Lösung
Aspose.Slides zeigt die **Objekt geändert**-Meldung an, um Sie darauf hinzuweisen, dass das OLE-Objekt geändert wurde und das Vorschaubild aktualisiert werden muss. 

Wenn Sie beispielsweise ein Microsoft Excel-Diagramm als [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) zu einer Folie hinzufügen (für weitere Details siehe den Artikel OLE verwalten) und dann die Präsentation in der Microsoft PowerPoint-App öffnen, sehen Sie dieses Bild auf der Folie:

~~Ersetzen Sie alle Bilder durch neue Bilder~~

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

Wenn Sie überprüfen und bestätigen möchten, dass Ihr OLE-Objekt zur Folie hinzugefügt wurde, müssen Sie doppelt auf die **Objekt geändert**-Meldung klicken oder Sie können mit der rechten Maustaste darauf klicken und die Option **Arbeitsblattobjekt > Bearbeiten** auswählen.

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

PowerPoint öffnet dann das eingebettete OLE-Objekt

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)

Die Folie kann die **Objekt geändert**-Meldung beibehalten. Sobald Sie auf das OLE-Objekt klicken, wird die Vorschau der Folie aktualisiert und die **Objekt geändert**-Meldung durch das tatsächliche Bild für das OLE-Objekt ersetzt. 

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

Jetzt möchten Sie möglicherweise Ihre Präsentation speichern, um sicherzustellen, dass das Bild für das OLE-Objekt korrekt aktualisiert wird. Auf diese Weise werden Sie nach dem Speichern der Präsentation, wenn Sie die Präsentation erneut öffnen, NICHT die **Objekt geändert**-Meldung sehen. 

## **Weitere Lösungen**
### **Lösung 1: Ersetzen Sie die Objekt geändert-Meldung durch ein Bild**

Wenn Sie die **Objekt geändert**-Meldung nicht entfernen möchten, indem Sie die Präsentation in PowerPoint öffnen und dann speichern, können Sie die Meldung durch Ihr bevorzugtes Vorschaubild ersetzen. Diese Zeilen Code demonstrieren den Prozess:

``` csharp 
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
   ISlide slide = pres.Slides[0];
   IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];
    
   IPPImage oleImage = pres.Images.AddImage(File.ReadAllBytes("my_image.png"));
   oleObjectFrame.SubstitutePictureTitle = "Mein Titel";
   oleObjectFrame.SubstitutePictureFormat.Picture.Image = oleImage;
   oleObjectFrame.IsObjectIcon = false;
    
   pres.Save("embeddedOle-newImage.pptx", SaveFormat.Pptx);
}
```

Die Folie, die das `OleObjectFrame` enthält, ändert sich dann zu diesem:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

### **Lösung 2: Erstellen Sie ein Add-In für PowerPoint**
Sie können auch ein Add-In für Microsoft PowerPoint erstellen, das alle OLE-Objekte aktualisiert, wenn Sie Präsentationen im Programm öffnen.