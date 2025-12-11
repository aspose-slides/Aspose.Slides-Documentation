---
title: Flash-Objekte aus Präsentationen auf Android extrahieren
linktitle: Flash
type: docs
weight: 10
url: /de/androidjava/flash/
keywords:
- Flash extrahieren
- Flash-Objekt
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Flash-Objekte aus PowerPoint- und OpenDocument-Folien in Java mit Aspose.Slides für Android extrahieren, inklusive vollständiger Codebeispiele und bewährter Verfahren."
---

## **Flash-Objekte aus Präsentationen extrahieren**

Aspose.Slides für Android über Java bietet eine Möglichkeit, Flash-Objekte aus einer Präsentation zu extrahieren. Sie können die Flash-Steuerung nach Name abrufen und aus der Präsentation extrahieren sowie die SWF-Objektdaten speichern.
```java
// Instanziiere die Presentation-Klasse, die das PPTX repräsentiert
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


## **FAQ**

**Welche Präsentationsformate werden beim Extrahieren von Flash‑Inhalten unterstützt?**

[Aspose.Slides unterstützt](/slides/de/androidjava/supported-file-formats/) die gängigen PowerPoint‑Formate wie PPT und PPTX, da es diese Container laden und auf deren Steuerelemente zugreifen kann, einschließlich Flash‑bezogener ActiveX‑Elemente.

**Kann ich eine Präsentation mit Flash zu HTML5 konvertieren und die Flash‑Interaktivität beibehalten?**

Nein. Aspose.Slides führt keinen SWF‑Inhalt aus und konvertiert dessen Interaktivität nicht. Während der Export zu [HTML](/slides/de/androidjava/convert-powerpoint-to-html/)/[HTML5](/slides/de/androidjava/export-to-html5/) unterstützt wird, wird Flash in modernen Browsern aufgrund des Endes der Unterstützung nicht abgespielt. Der empfohlene Weg ist, Flash vor dem Export durch Alternativen wie Video oder HTML5‑Animationen zu ersetzen.

**Wird aus Sicherheitsperspektive SWF‑Dateien von Aspose.Slides beim Lesen einer Präsentation ausgeführt?**

Nein. Aspose.Slides behandelt Flash als binäre Daten, die in der Datei eingebettet sind, und führt keinen SWF‑Inhalt während der Verarbeitung aus.

**Wie sollte ich mit Präsentationen umgehen, die Flash zusammen mit anderen eingebetteten Dateien über OLE enthalten?**

Aspose.Slides unterstützt das [Extrahieren eingebetteter OLE‑Objekte](/slides/de/androidjava/manage-ole/), sodass Sie alle zugehörigen eingebetteten Inhalte in einem Durchlauf verarbeiten können, wobei Flash-Steuerelemente und andere OLE‑eingebettete Dokumente gemeinsam behandelt werden.