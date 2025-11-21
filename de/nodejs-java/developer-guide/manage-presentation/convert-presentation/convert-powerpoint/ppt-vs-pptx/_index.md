---
title: PPT vs PPTX
type: docs
weight: 10
url: /de/nodejs-java/ppt-vs-pptx/
keywords: "PPT vs PPTX"
description: "Lesen Sie über die Unterschiede zwischen PPT und PPTX in Aspose.Slides."
---

## **Was ist PPT?**

[**PPT**](https://docs.fileformat.com/presentation/ppt/) ist ein binäres Dateiformat, d. h. es ist unmöglich, seinen Inhalt ohne spezielle Werkzeuge anzuzeigen. Die ersten PowerPoint‑Versionen 97‑2003 arbeiteten mit dem PPT‑Dateiformat, jedoch ist seine Erweiterbarkeit begrenzt.  

## **Was ist PPTX?**

[**PPTX**](https://docs.fileformat.com/presentation/pptx/) ist ein neues Präsentationsdateiformat, das auf dem Office Open XML (ISO 29500:2008-2016, ECMA-376) Standard basiert. PPTX ist ein archiviertes Set aus XML‑ und Mediendateien. Das PPTX‑Format ist leicht erweiterbar. Zum Beispiel ist es einfach, Unterstützung für einen neuen Diagrammtyp oder Formtyp hinzuzufügen, ohne das PPTX‑Format in jeder neuen PowerPoint‑Version zu ändern. Das PPTX‑Format wird seit PowerPoint 2007 verwendet.  

## **PPT vs PPTX**

Obwohl PPTX viel umfangreichere Funktionen bietet, bleibt PPT sehr beliebt. Die Notwendigkeit, von PPT nach PPTX und umgekehrt zu konvertieren, ist hoch gefragt.

Allerdings ist die Konvertierung zwischen dem alten PPT‑Format und dem neuen PPTX‑Format die komplexeste Herausforderung unter den anderen Microsoft‑Office‑Formaten. Obwohl die Spezifikation des PPT‑Formats offen ist, ist die Arbeit damit schwierig. PowerPoint kann spezielle Teile (MetroBlob) in PPT‑Dateien erstellen, um Informationen aus PPTX zu speichern, die vom PPT‑Format nicht unterstützt werden und in alten PowerPoint‑Versionen nicht angezeigt werden können. Diese Informationen können wiederhergestellt werden, wenn eine PPT‑Datei in einer modernen PowerPoint‑Version geladen oder in das PPTX‑Format konvertiert wird.

Aspose.Slides stellt eine gemeinsame Klasse bereit, um mit allen Präsentationsformaten zu arbeiten. Sie ermöglicht das Konvertieren von PPT nach PPTX und von PPTX nach PPT auf sehr einfache Weise. Aspose.Slides unterstützt die Konvertierung von PPT nach PPTX vollständig und unterstützt auch die Konvertierung von PPTX nach PPT mit einigen Einschränkungen. Wir empfehlen, nach Möglichkeit das PPTX‑Format zu verwenden.

{{% alert color="primary" %}} 

Überprüfen Sie die Qualität der Konvertierungen von PPT nach PPTX und von PPTX nach PPT mit der Online‑[**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 
```javascript
// Instanziiere ein Presentation-Objekt, das eine PPT-Datei darstellt
var pres = new aspose.slides.Presentation("PPTtoPPTX.ppt");
try {
    // Speichern der PPT-Präsentation im PPTX-Format
    pres.save("PPTtoPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
Mehr erfahren [**How to Convert Presentations PPT to PPTX**.](/slides/de/nodejs-java/convert-ppt-to-pptx/)
{{% /alert %}} 

## **FAQ**

**Gibt es einen Grund, alte Präsentationen im PPT‑Format zu behalten, wenn sie fehlerfrei geöffnet werden?**

Wenn eine Präsentation zuverlässig geöffnet wird und keine Zusammenarbeit oder neuere Funktionen benötigt, können Sie sie im PPT‑Format behalten. Für zukünftige Kompatibilität und Erweiterbarkeit ist es jedoch besser, zu [convert to PPTX](/slides/de/nodejs-java/convert-ppt-to-pptx/): Das Format basiert auf dem offenen OOXML‑Standard und wird von modernen Werkzeugen leichter unterstützt.

**Wie kann ich entscheiden, welche Dateien zuerst kritisch in PPTX zu konvertieren sind?**

Konvertieren Sie zuerst die Präsentationen, die: von mehreren Personen bearbeitet werden; komplexe [charts](/slides/de/nodejs-java/create-chart/)/[shapes](/slides/de/nodejs-java/shape-manipulations/) enthalten; in externen Kommunikationsmitteln verwendet werden; oder Warnungen auslösen, wenn sie [opened](/slides/de/nodejs-java/open-presentation/) werden.

**Wird der Passwortschutz beim Konvertieren von PPT nach PPTX und zurück beibehalten?**

Das Vorhandensein eines Passworts wird nur bei einer korrekten Konvertierung und Verschlüsselungsunterstützung im verwendeten Tool übernommen. Es ist zuverlässiger, zunächst den [remove protection](/slides/de/nodejs-java/password-protected-presentation/) zu entfernen, dann zu [convert](/slides/de/nodejs-java/convert-ppt-to-pptx/) und anschließend den Schutz gemäß Ihrer Sicherheitsrichtlinie wieder anzuwenden.

**Warum verschwinden einige Effekte oder werden vereinfacht, wenn PPTX zurück nach PPT konvertiert wird?**

Weil PPT einige neuere Objekte/Eigenschaften nicht unterstützt. PowerPoint und Werkzeuge können „Spuren“ dieser Informationen in speziellen Blöcken für spätere Wiederherstellung speichern, aber ältere PowerPoint‑Versionen können sie nicht rendern.