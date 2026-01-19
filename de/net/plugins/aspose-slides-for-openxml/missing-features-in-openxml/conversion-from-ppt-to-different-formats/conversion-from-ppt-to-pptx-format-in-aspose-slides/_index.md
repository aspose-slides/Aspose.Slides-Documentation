---
title: Konvertierung vom PPT- zum PPTX-Format in Aspose.Slides
type: docs
weight: 10
url: /de/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---

**Aspose.Slides** für .NET ermöglicht Entwicklern jetzt, über eine Instanz der Presentation-Klasse auf die PPT zuzugreifen und diese in das entsprechende PPTX-Format zu konvertieren. Derzeit unterstützt es die teilweise Konvertierung von PPT zu PPTX. Für weitere Details darüber, welche Funktionen bei der PPT-zu-PPTX-Konvertierung unterstützt bzw. nicht unterstützt werden, gehen Sie bitte zu diesem Dokumentationslink.

**Aspose.Slides** für .NET bietet die Presentation-Klasse, die eine PPTX-Präsentationsdatei repräsentiert. Die Presentation-Klasse kann nun ebenfalls über Presentation auf PPT zugreifen, wenn das Objekt instanziiert wird.

``` csharp

 //Instantiate a Presentation object that represents a PPTX file

PresentationEx pres = new PresentationEx("Conversion.ppt");

//Saving the PPTX presentation to PPTX format

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **Beispielcode herunterladen**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)