---
title: PPT vs PPTX
type: docs
weight: 10
url: /de/python-net/ppt-vs-pptx/
keywords: "PPT vs PPTX, PPT oder PPTX, PowerPoint-Präsentation, Format, Python"
description: "Über PowerPoint-Präsentationsformate. PPT vs PPTX. Unterschiede in Python"
---


## **Was ist PPT?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) ist ein binäres Dateiformat, d.h. der Inhalt kann ohne spezielle Werkzeuge nicht angezeigt werden. Die ersten PowerPoint-Versionen 97-2003 arbeiteten mit dem PPT-Dateiformat, allerdings ist dessen Erweiterbarkeit begrenzt. 
## **Was ist PPTX?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) ist ein neues Präsentationsdateiformat, das auf dem Standard Office Open XML (ISO 29500:2008-2016, ECMA-376) basiert. PPTX ist ein archiviertes Set aus XML- und Mediendateien. Das PPTX-Format ist leicht erweiterbar. Zum Beispiel ist es einfach, Unterstützung für einen neuen Diagrammtyp oder Formtyp hinzuzufügen, ohne das PPTX-Format in jeder neuen PowerPoint-Version zu ändern. Das PPTX-Format wird seit PowerPoint 2007 verwendet.

## **PPT vs PPTX**
Obwohl PPTX viel umfassendere Funktionalität bietet, bleibt PPT recht beliebt. Die Notwendigkeit, von PPT zu PPTX und vice versa zu konvertieren, ist sehr gefragt.

Die Konvertierung zwischen dem alten PPT- und dem neuen PPTX-Format ist jedoch die komplizierteste Herausforderung unter den anderen Microsoft Office-Formaten. Obwohl die Spezifikation des PPT-Formats offen ist, ist es schwierig, damit zu arbeiten. PowerPoint kann in PPT-Dateien spezielle Teile (MetroBlob) erstellen, um Informationen aus PPTX zu speichern, die vom PPT-Format nicht unterstützt werden und in alten PowerPoint-Versionen nicht angezeigt werden können. Diese Informationen können wiederhergestellt werden, wenn eine PPT-Datei in einer modernen PowerPoint-Version geladen oder in das PPTX-Format konvertiert wird.

Aspose.Slides bietet eine gemeinsame Schnittstelle, um mit allen Präsentationsformaten zu arbeiten. Es ermöglicht eine sehr einfache Konvertierung von PPT nach PPTX und von PPTX nach PPT. Aspose.Slides unterstützt die Konvertierung von PPT nach PPTX vollständig und unterstützt auch die Konvertierung von PPTX nach PPT mit einigen Einschränkungen. Wir empfehlen, das PPTX-Format wo immer möglich zu verwenden.

{{% alert color="primary" %}} 

Überprüfen Sie die Qualität der Konvertierungen von PPT zu PPTX und von PPTX zu PPT mit der Online- [**Aspose.Slides Conversion-App**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

```py
import aspose.slides as slides

# Instanziieren Sie ein Präsentationsobjekt, das eine PPTX-Datei darstellt
pres = slides.Presentation("PPTtoPPTX.ppt")

# Speichern der PPTX-Präsentation im PPTX-Format
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
Lesen Sie mehr [**Wie man Präsentationen von PPT nach PPTX konvertiert**.](/slides/de/python-net/convert-ppt-to-pptx/)
{{% /alert %}} 