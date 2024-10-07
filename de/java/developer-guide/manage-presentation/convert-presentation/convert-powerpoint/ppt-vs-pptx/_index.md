---
title: PPT vs PPTX
type: docs
weight: 10
url: /java/ppt-vs-pptx/
keywords: "PPT vs PPTX"
description: "Erfahren Sie mehr über die Unterschiede zwischen PPT und PPTX in Aspose.Slides."
---

## **Was ist PPT?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) ist ein binäres Dateiformat, d.h. es ist unmöglich, den Inhalt ohne spezielle Werkzeuge anzuzeigen. Die ersten PowerPoint 97-2003 Versionen arbeiteten mit dem PPT-Dateiformat, jedoch ist seine Erweiterbarkeit begrenzt.
## **Was ist PPTX?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) ist ein neues Präsentationsdateiformat, das auf dem Standard Office Open XML (ISO 29500:2008-2016, ECMA-376) basiert. PPTX ist ein archivierter Satz von XML- und Mediendateien. Das PPTX-Format ist leicht erweiterbar. Zum Beispiel ist es einfach, Unterstützung für einen neuen Diagrammtyp oder Formtyp hinzuzufügen, ohne das PPTX-Format in jeder neuen PowerPoint-Version zu ändern. Das PPTX-Format wird seit PowerPoint 2007 verwendet.
## **PPT vs PPTX**
Obwohl PPTX viel breitere Funktionen bietet, bleibt PPT recht beliebt. Die Notwendigkeit, von PPT nach PPTX und umgekehrt zu konvertieren, ist stark gefragt.

Die Konversion zwischen dem alten PPT- und dem neuen PPTX-Format ist jedoch die komplizierteste Herausforderung unter den anderen Microsoft Office-Formaten. Obwohl die Spezifikation des PPT-Formats offen ist, ist es schwierig, damit zu arbeiten. PowerPoint kann spezielle Teile (MetroBlob) in PPT-Dateien erstellen, um Informationen aus PPTX zu speichern, die vom PPT-Format nicht unterstützt werden und in alten PowerPoint-Versionen nicht angezeigt werden können. Diese Informationen können wiederhergestellt werden, wenn eine PPT-Datei in einer modernen PowerPoint-Version geladen oder in das PPTX-Format konvertiert wird.

Aspose.Slides bietet eine gemeinsame Schnittstelle, um mit allen Präsentationsformaten zu arbeiten. Es ermöglicht die einfache Konvertierung von PPT nach PPTX und von PPTX nach PPT. Aspose.Slides unterstützt die vollständige Konvertierung von PPT nach PPTX und unterstützt auch die Konvertierung von PPTX nach PPT mit einigen Einschränkungen. Wir empfehlen, das PPTX-Format wo immer möglich zu verwenden.

{{% alert color="primary" %}} 

Überprüfen Sie die Qualität der PPT nach PPTX- und PPTX nach PPT-Konvertierungen mit der Online-[**Aspose.Slides Conversion-App**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

```java
// Instanziieren Sie ein Präsentationsobjekt, das eine PPT-Datei darstellt
Presentation pres = new Presentation("PPTtoPPTX.ppt");
try {
// Speichern der PPT-Präsentation im PPTX-Format
    pres.save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Erfahren Sie mehr über [**Wie man Präsentationen von PPT nach PPTX konvertiert**.](/slides/java/convert-ppt-to-pptx/)
{{% /alert %}} 