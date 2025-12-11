---
title: "Verstehen des Unterschieds: PPT vs PPTX"
linktitle: PPT vs PPTX
type: docs
weight: 10
url: /de/androidjava/ppt-vs-pptx/
keywords:
- PPT vs PPTX
- PPT oder PPTX
- veraltetes Format
- modernes Format
- binäres Format
- moderner Standard
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Vergleichen Sie PPT mit PPTX für PowerPoint mit Aspose.Slides für Android über Java, untersuchen Sie Formatunterschiede, Vorteile, Kompatibilität und Konvertierungstipps."
---

## **Was ist PPT?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) ist ein binäres Dateiformat, d. h. es ist unmöglich, seinen Inhalt ohne spezielle Werkzeuge zu sehen. Die ersten PowerPoint‑Versionen 97‑2003 arbeiteten mit dem PPT‑Dateiformat, jedoch ist seine Erweiterbarkeit begrenzt. 

## **Was ist PPTX?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) ist ein neues Präsentationsdateiformat, das auf dem Office Open XML (ISO 29500:2008-2016, ECMA-376) Standard basiert. PPTX ist ein archiviertes Set aus XML‑ und Mediendateien. Das PPTX‑Format ist leicht erweiterbar. Zum Beispiel ist es einfach, Unterstützung für einen neuen Diagrammtyp oder eine neue Form hinzuzufügen, ohne das PPTX‑Format in jeder neuen PowerPoint‑Version zu ändern. Das PPTX‑Format wird seit PowerPoint 2007 verwendet. 

## **PPT vs PPTX**
Obwohl PPTX viel umfassendere Funktionalität bietet, bleibt PPT recht beliebt. Die Notwendigkeit, von PPT nach PPTX und umgekehrt zu konvertieren, ist stark gefragt.

Die Konvertierung zwischen dem alten PPT‑ und dem neuen PPTX‑Format ist jedoch die komplexeste Herausforderung unter den anderen Microsoft‑Office‑Formaten. Obwohl die Spezifikation des PPT‑Formats offen ist, ist die Arbeit damit schwierig. PowerPoint kann spezielle Teile (MetroBlob) in PPT‑Dateien erstellen, um Informationen aus PPTX zu speichern, die vom PPT‑Format nicht unterstützt werden und in alten PowerPoint‑Versionen nicht angezeigt werden können. Diese Informationen können wiederhergestellt werden, wenn eine PPT‑Datei in einer modernen PowerPoint‑Version geladen oder in das PPTX‑Format konvertiert wird.

Aspose.Slides bietet eine einheitliche Schnittstelle zur Arbeit mit allen Präsentationsformaten. Sie ermöglicht die Konvertierung von PPT nach PPTX und von PPTX nach PPT auf sehr einfache Weise. Aspose.Slides unterstützt die Konvertierung von PPT nach PPTX vollständig und unterstützt auch die Konvertierung von PPTX nach PPT mit einigen Einschränkungen. Wir empfehlen, wo immer möglich das PPTX‑Format zu verwenden.

{{% alert color="primary" %}} 
Überprüfen Sie die Qualität der Konvertierungen von PPT nach PPTX und von PPTX nach PPT mit der Online‑[**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 
```java
// Instanziieren Sie ein Presentation-Objekt, das eine PPT-Datei darstellt
Presentation pres = new Presentation("PPTtoPPTX.ppt");
try {
// Speichern der PPT-Präsentation im PPTX-Format
    pres.save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
Lesen Sie mehr [**Wie man Präsentationen von PPT nach PPTX konvertiert**](/slides/de/androidjava/convert-ppt-to-pptx/)
{{% /alert %}} 

## **FAQ**

**Gibt es einen Grund, alte Präsentationen im PPT‑Format zu behalten, wenn sie fehlerfrei geöffnet werden?**

Wenn eine Präsentation zuverlässig geöffnet wird und keine Zusammenarbeit oder neueren Funktionen benötigt, können Sie sie im PPT‑Format belassen. Für zukünftige Kompatibilität und Erweiterbarkeit ist es jedoch besser, sie zu [zu PPTX konvertieren](/slides/de/androidjava/convert-ppt-to-pptx/): Das Format basiert auf dem offenen OOXML‑Standard und wird von modernen Tools leichter unterstützt.

**Wie kann ich entscheiden, welche Dateien zuerst kritisch in PPTX zu konvertieren sind?**

Konvertieren Sie zuerst die Präsentationen, die: von mehreren Personen bearbeitet werden; komplexe [Diagramme](/slides/de/androidjava/create-chart/)/[Formen](/slides/de/androidjava/shape-manipulations/) enthalten; in externen Kommunikationen verwendet werden; oder Warnungen auslösen, wenn sie [geöffnet](/slides/de/androidjava/open-presentation/) werden.

**Wird der Passwortschutz bei der Konvertierung von PPT nach PPTX und zurück beibehalten?**

Das Vorhandensein eines Passwortes wird nur bei einer korrekten Konvertierung und wenn das von Ihnen verwendete Tool die Verschlüsselung unterstützt, übernommen. Es ist zuverlässiger, den [Schutz zu entfernen](/slides/de/androidjava/password-protected-presentation/), zu [konvertieren](/slides/de/androidjava/convert-ppt-to-pptx/), und dann den Schutz gemäß Ihrer Sicherheitsrichtlinie wieder anzuwenden.

**Warum verschwinden bei der Konvertierung von PPTX zurück zu PPT einige Effekte oder werden vereinfacht?**

Weil PPT einige neuere Objekte/Eigenschaften nicht unterstützt. PowerPoint und Werkzeuge können „Spuren“ dieser Information in speziellen Blöcken für eine spätere Wiederherstellung speichern, doch ältere PowerPoint‑Versionen rendern sie nicht.