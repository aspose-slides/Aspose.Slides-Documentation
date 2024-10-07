---
title: Flash
type: docs
weight: 10
url: /java/flash/
description: Extrahieren von Flash-Objekten aus PowerPoint-Präsentationen mit Java
---

## **Flash-Objekte aus der Präsentation extrahieren**

Aspose.Slides für Java bietet eine Möglichkeit, Flash-Objekte aus einer Präsentation zu extrahieren. Sie können auf die Flash-Steuerung nach Name zugreifen und sie aus der Präsentation extrahieren sowie SWF-Objektdaten speichern.

```java
// Erstellen Sie eine Instanz der Presentation-Klasse, die das PPTX repräsentiert
Presentation pres = new Presentation();
try {
    IControlCollection controls = pres.getSlides().get_Item(0).getControls();
    Control flashControl = null;
    for (IControl control : controls)
    {
        if (control.getName() == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```