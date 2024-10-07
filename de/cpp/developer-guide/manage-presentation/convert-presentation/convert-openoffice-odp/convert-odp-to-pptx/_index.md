---
title: ODP in PPTX konvertieren
type: docs
weight: 10
url: /cpp/convert-odp-to-pptx/
---

Aspose.Slides für .NET bietet die Klasse Presentation, die eine Präsentationsdatei darstellt. Die [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse kann jetzt auch über den Präsentationskonstruktor auf ODP zugreifen, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie man eine ODP-Präsentation in eine PPTX-Präsentation konvertiert.

``` cpp
// Der Pfad zum Dokumentenverzeichnis.
String dataDir = GetDataPath();

// ODP-Datei öffnen
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// Speichern der ODP-Präsentation im PPTX-Format
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```



## **Live Beispiel**
Sie können die [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) Webanwendung besuchen, die mit der **Aspose.Slides API** erstellt wurde. Die App demonstriert, wie die ODP zu PPTX-Konvertierung mit der Aspose.Slides API implementiert werden kann.