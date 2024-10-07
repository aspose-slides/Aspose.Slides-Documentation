---
title: Automatisches Aktualisieren von OLE-Objekten mit MS PowerPoint Add-In
type: docs
weight: 10
url: /net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
---

## **Über das automatische Aktualisieren von OLE-Objekten**
Eine der häufigsten Fragen, die von den Kunden von Aspose.Slides für .NET gestellt wird, ist, wie man bearbeitbare Diagramme oder andere OLE-Objekte erstellt oder ändert und diese beim Öffnen der Präsentation automatisch aktualisiert. Leider unterstützt PowerPoint keine automatischen Makros, die in Excel und Word verfügbar sind. Die einzigen verfügbaren sind die Makros Auto_Open und Auto_Close. Diese werden jedoch nur automatisch aus einem Add-in ausgeführt. Dieser kurze technische Hinweis zeigt, wie man das erreichen kann.

Zuerst stehen mehrere Freeware-Add-ins zur Verfügung, die die Auto_Open-Makrofunktion zu PowerPoint hinzufügen, beispielsweise [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) und [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Nach der Installation eines solchen Add-ins fügen Sie einfach das Auto_Open() Makro (OnPresentationOpen() im Fall des "Event Generator") Ihrer Vorlage-Präsentation hinzu, wie unten gezeigt:

```c#
public void Auto_Open()
{
    Shape oShape;
    Slide oSlide;
    object oGraph;

    // Durchlaufen Sie jede Folie in der Präsentation.
    foreach (var oSlide in ActivePresentation.Slides)
    {

        // Durchlaufen Sie alle Formen auf der aktuellen Folie.
        foreach (var oShape in oSlide.Shapes)
        {

            // Überprüfen Sie, ob die Form ein OLE-Objekt ist.
            if (oShape.Type == msoEmbeddedOLEObject)
            {

                // OLE-Objekt gefunden; Objektreferenz abrufen und dann aktualisieren.
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // Beenden Sie nun das OLE-Serverprogramm. Dies gibt
                // Speicher frei und verhindert Probleme. Setzen Sie auch oObject gleich
                // auf Nothing, um das Objekt freizugeben.
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```

{{% alert color="primary" %}} 

Änderungen an OLE-Objekten mit Aspose.Slides für .NET werden automatisch aktualisiert, wenn PowerPoint die Präsentation öffnet. Wenn Sie viele OLE-Objekte in einer Präsentation haben und nicht alle aktualisieren möchten, fügen Sie einfach ein benutzerdefiniertes Tag zu den Formen hinzu, die Sie verarbeiten möchten, und überprüfen Sie es im Makro. 

{{% /alert %}}