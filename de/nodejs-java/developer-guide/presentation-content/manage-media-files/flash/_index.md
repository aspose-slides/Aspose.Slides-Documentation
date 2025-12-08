---
title: Flash
type: docs
weight: 10
url: /de/nodejs-java/flash/
description: Extrahieren von Flash-Objekten aus PowerPoint-Präsentationen mit JavaScript
---

## **Flash-Objekte aus Präsentation extrahieren**

Aspose.Slides für Node.js über Java bietet eine Möglichkeit, Flash-Objekte aus einer Präsentation zu extrahieren. Sie können die Flash-Steuerung per Name zugreifen und sie aus der Präsentation extrahieren sowie die SWF-Objektdaten speichern.
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var controls = pres.getSlides().get_Item(0).getControls();
    var flashControl = null;
    for (var i = 0; i < controls.size(); i++) {
        var control = controls.get_Item(i);
        console.log(control.getName() === "ShockwaveFlash1");
        if (control.getName() === "ShockwaveFlash1") {
            flashControl = control;
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Welche Präsentationsformate werden beim Extrahieren von Flash-Inhalten unterstützt?**

[Aspose.Slides supports](/slides/de/nodejs-java/supported-file-formats/) die wichtigsten PowerPoint-Formate wie PPT und PPTX, da es diese Container laden und auf deren Steuerelemente zugreifen kann, einschließlich Flash-bezogener ActiveX-Elemente.

**Kann ich eine Präsentation mit Flash nach HTML5 konvertieren und die Flash-Interaktivität beibehalten?**

Nein. Aspose.Slides führt keinen SWF-Inhalt aus und konvertiert die Interaktivität nicht. Zwar wird der Export zu [HTML](/slides/de/nodejs-java/convert-powerpoint-to-html/)/[HTML5](/slides/de/nodejs-java/export-to-html5/) unterstützt, Flash wird jedoch in modernen Browsern aufgrund des Endes der Unterstützung nicht abgespielt. Der empfohlene Ansatz ist, Flash vor dem Export durch Alternativen wie Video oder HTML5-Animationen zu ersetzen.

**Führt Aspose.Slides aus Sicherheitsgründen SWF-Dateien beim Einlesen einer Präsentation aus?**

Nein. Aspose.Slides behandelt Flash als binäre Daten, die in die Datei eingebettet sind, und führt während der Verarbeitung keinen SWF-Inhalt aus.

**Wie sollte ich mit Präsentationen umgehen, die Flash zusammen mit anderen eingebetteten Dateien über OLE enthalten?**

Aspose.Slides unterstützt das [extracting embedded OLE objects](/slides/de/nodejs-java/manage-ole/), sodass Sie alle zugehörigen eingebetteten Inhalte in einem Durchgang verarbeiten können, indem Sie Flash-Steuerelemente und andere OLE-eingebettete Dokumente gemeinsam handhaben.