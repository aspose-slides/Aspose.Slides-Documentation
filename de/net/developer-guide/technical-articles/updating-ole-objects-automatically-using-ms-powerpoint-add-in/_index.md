---
title: OLE-Objekte automatisch aktualisieren mit einem PowerPoint-Add-In
type: docs
weight: 10
url: /de/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE-Objekt
- OLE aktualisieren
- automatisch
- Add-In
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie OLE-Diagramme und -Objekte in PowerPoint mit einem Add-In und Aspose.Slides für .NET automatisch aktualisieren, inklusive praktischer Code-Beispiele und Optimierungstipps."
---

## **OLE-Objekte automatisch aktualisieren**

Eine der häufigsten Fragen, die Kunden von Aspose.Slides für .NET stellen, ist, wie man editierbare Diagramme (oder andere OLE-Objekte) erstellt oder ändert, sodass sie beim Öffnen der Präsentation automatisch aktualisiert werden. Leider unterstützt PowerPoint automatische Makros nicht auf dieselbe Weise wie Excel und Word. Die einzigen verfügbaren Makros sind `Auto_Open` und `Auto_Close`, und diese werden nur automatisch aus einem Add-In ausgeführt. Dieser kurze technische Hinweis zeigt, wie das erreicht werden kann.

Zunächst stehen mehrere kostenlose Add-Ins zur Verfügung, die die Auto_Open-Makrofunktion zu PowerPoint hinzufügen, zum Beispiel [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) und [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Nach der Installation eines dieser Add-Ins fügen Sie einfach das Makro `Auto_Open()` (oder `OnPresentationOpen()`, wenn Sie den Event Generator verwenden) zu Ihrer Vorlage‑Präsentation hinzu, wie unten gezeigt:
```cs
public void Auto_Open()
{
    // Durchläuft jede Folie in der Präsentation.
    foreach (var oSlide in ActivePresentation.Slides)
    {
        // Durchläuft alle Formen auf der aktuellen Folie.
        foreach (var oShape in oSlide.Shapes)
        {
            // Prüft, ob die Form ein OLE-Objekt ist.
            if (oShape.Type == msoEmbeddedOLEObject)
            {
                // OLE-Objekt gefunden. Holt die Objektreferenz und aktualisiert sie.
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // Jetzt das OLE-Server-Programm beenden.
                // Dadurch wird Speicher freigegeben und Probleme vermieden.
                // Außerdem oObject auf Nothing setzen, um das Objekt freizugeben.
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```


Alle Änderungen an OLE-Objekten mit Aspose.Slides für .NET werden automatisch aktualisiert, wenn PowerPoint die Präsentation öffnet. Wenn Sie viele OLE-Objekte haben und nicht alle aktualisieren möchten, fügen Sie einfach ein benutzerdefiniertes Tag zu den Formen hinzu, die Sie verarbeiten müssen, und prüfen Sie dieses im Makro.