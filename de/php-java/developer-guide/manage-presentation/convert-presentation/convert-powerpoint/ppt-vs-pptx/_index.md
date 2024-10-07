---
title: PPT vs PPTX
type: docs
weight: 10
url: /php-java/ppt-vs-pptx/
keywords: "PPT vs PPTX"
description: "Lesen Sie über die Unterschiede zwischen PPT und PPTX in Aspose.Slides."
---


## **Was ist PPT?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) ist ein binäres Dateiformat, d.h. es ist unmöglich, seinen Inhalt ohne spezielle Werkzeuge anzusehen. Die ersten PowerPoint-Versionen 97-2003 arbeiteten mit dem PPT-Dateiformat, wobei die Erweiterbarkeit jedoch begrenzt ist. 
## **Was ist PPTX?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) ist ein neues Präsentationsdateiformat, das auf dem Office Open XML (ISO 29500:2008-2016, ECMA-376) Standard basiert. PPTX ist ein archiviertes Set von XML- und Mediendateien. Das PPTX-Format ist leicht erweiterbar. Zum Beispiel ist es einfach, Unterstützung für einen neuen Diagrammtyp oder Formtyp hinzuzufügen, ohne das PPTX-Format in jeder neuen PowerPoint-Version zu ändern. Das PPTX-Format wird ab PowerPoint 2007 verwendet.
## **PPT vs PPTX**
Obwohl PPTX eine viel breitere Funktionalität bietet, bleibt PPT ziemlich beliebt. Die Notwendigkeit, von PPT nach PPTX und umgekehrt zu konvertieren, ist hochgradig gefragt.

Die Konvertierung zwischen alten PPT- und neuen PPTX-Formaten ist jedoch die komplizierteste Herausforderung unter den anderen Microsoft Office-Formaten. Obwohl die Spezifikation des PPT-Formats offen ist, ist es schwierig, damit zu arbeiten. PowerPoint kann spezielle Teile (MetroBlob) in PPT-Dateien erstellen, um Informationen aus PPTX zu speichern, die vom PPT-Format nicht unterstützt werden und in alten PowerPoint-Versionen nicht angezeigt werden können. Diese Informationen können wiederhergestellt werden, wenn eine PPT-Datei in einer modernen PowerPoint-Version geladen oder in das PPTX-Format konvertiert wird.

Aspose.Slides bietet eine gemeinsame Schnittstelle zur Arbeit mit allen Präsentationsformaten. Es ermöglicht die Konvertierung von PPT nach PPTX und von PPTX nach PPT in sehr einfacher Weise. Aspose.Slides unterstützt die Konvertierung von PPT nach PPTX vollständig und unterstützt auch die Konvertierung von PPTX nach PPT mit einigen Einschränkungen. Wir empfehlen die Verwendung des PPTX-Formats, wo immer möglich.

{{% alert color="primary" %}} 

Überprüfen Sie die Qualität der Konvertierungen von PPT nach PPTX und von PPTX nach PPT mit der Online- [**Aspose.Slides Konvertierungs-App**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

```php
  # Erstellen Sie ein Präsentationsobjekt, das eine PPT-Datei darstellt
  $pres = new Presentation("PPTtoPPTX.ppt");
  try {
    # Speichern der PPT-Präsentation im PPTX-Format
    $pres->save("PPTtoPPTX_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
Erfahren Sie mehr über [**Wie man Präsentationen von PPT nach PPTX konvertiert**.](/slides/php-java/convert-ppt-to-pptx/)
{{% /alert %}} 