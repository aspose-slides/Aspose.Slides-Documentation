---
title: OLE-Objekte automatisch aktualisieren mit einem PowerPoint-Add-In
type: docs
weight: 10
url: /de/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE-Objekt
- OLE aktualisieren
- automatisch
- Add-In
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie OLE-Diagramme und -Objekte in PowerPoint mit einem Add-In und Aspose.Slides für Java automatisch aktualisieren, inklusive praktischer Code- und Optimierungstipps."
---

## **OLE-Objekte automatisch aktualisieren**

Eine der häufigsten Fragen von Aspose.Slides for Java‑Kunden lautet, wie man editierbare Diagramme (oder andere OLE‑Objekte) erstellt oder ändert, sodass sie beim Öffnen der Präsentation automatisch aktualisiert werden. Leider unterstützt PowerPoint automatische Makros nicht auf dieselbe Weise wie Excel und Word. Die einzigen verfügbaren Makros sind `Auto_Open` und `Auto_Close`, und diese werden nur automatisch aus einem Add‑In ausgeführt. Dieser kurze technische Hinweis zeigt, wie das erreicht werden kann.

Zunächst stehen mehrere kostenlose Add‑Ins zur Verfügung, die die Auto_Open‑Makrofunktion zu PowerPoint hinzufügen, zum Beispiel [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) und [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Nach der Installation eines dieser Add‑Ins fügen Sie einfach das Makro `Auto_Open()` (oder `OnPresentationOpen()`, wenn Sie Event Generator verwenden) zu Ihrer Vorlagenpräsentation hinzu, wie unten gezeigt:
```java
// Durchlaufen jeder Folie in der Präsentation.
for (var oSlide : ActivePresentation.Slides) {
    // Durchlaufen aller Formen auf der aktuellen Folie.
    for (var oShape : oSlide.Shapes) {
        // Prüfen, ob die Form ein OLE‑Objekt ist.
        if ((oShape.Type == msoEmbeddedOLEObject)) {
            // OLE‑Objekt gefunden. Objektverweis abrufen und dann aktualisieren.
            oObject = oShape.OLEFormat.Object;
            oObject.Application.Update();
            // Jetzt das OLE‑Serverprogramm beenden.
            // Dadurch wird Speicher freigegeben und Probleme vermieden.
            // Außerdem oObject auf Nothing setzen, um das Objekt freizugeben.
            oObject.Application.Quit();
            oObject = null;
        }
    }
}
```


Alle Änderungen an OLE‑Objekten mit Aspose.Slides for Java werden automatisch aktualisiert, wenn PowerPoint die Präsentation öffnet. Wenn Sie viele OLE‑Objekte haben und nicht alle aktualisieren möchten, fügen Sie einfach ein benutzerdefiniertes Tag zu den Formen hinzu, die Sie verarbeiten möchten, und prüfen Sie dieses im Makro.