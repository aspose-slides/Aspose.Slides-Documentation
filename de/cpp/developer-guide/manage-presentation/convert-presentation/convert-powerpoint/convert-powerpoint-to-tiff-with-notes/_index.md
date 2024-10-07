---
title: PowerPoint in TIFF mit Notizen konvertieren
type: docs
weight: 100
url: /cpp/convert-powerpoint-to-tiff-with-notes/
keywords: "PowerPoint in TIFF mit Notizen konvertieren"
description: "PowerPoint in TIFF mit Notizen in Aspose.Slides konvertieren."
---

TIFF ist eines von mehreren weit verbreiteten Bildformaten, die Aspose.Slides für C++ zur Konvertierung von PowerPoint PPT und PPTX-Präsentationen mit Notizen in Bilder unterstützt. Sie können auch Folienvorschauen in der Notizenfolienansicht generieren. Die [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) Methode, die von der Presentation-Klasse bereitgestellt wird, kann verwendet werden, um die gesamte Präsentation in der Notizenfolienansicht in TIFF zu konvertieren. Das Speichern einer Microsoft PowerPoint-Präsentation in TIFF-Notizen mit Aspose.Slides für C++ ist ein zweizeiliger Prozess. Sie öffnen einfach die Präsentation und speichern sie als TIFF-Notizen. Sie können auch eine Folienvorschau in der Notizenfolienansicht für einzelne Folien erstellen. Die folgenden Codebeispiele aktualisieren die Beispielpräsentation in TIFF-Bilder in der Notizenfolienansicht, wie unten gezeigt:

``` cpp
// Der Pfad zum Dokumentenverzeichnis.
System::String dataDir = GetDataPath();

// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
auto presentation = System::MakeObject<Presentation>(dataDir + u"NotesFile.pptx");

// Die Präsentation in TIFF-Notizen speichern
presentation->Save(dataDir + u"Notes_In_Tiff_out.tiff", SaveFormat::Tiff);
```

{{% alert title="Tipp" color="primary" %}}

Sie möchten vielleicht den Aspose [KOSTENLOSEN PowerPoint zu Poster-Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) ausprobieren.

{{% /alert %}}