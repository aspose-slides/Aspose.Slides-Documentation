---
title: PowerPoint mit Notizen in TIFF konvertieren
type: docs
weight: 100
url: /net/convert-powerpoint-to-tiff-with-notes/
keywords: "PowerPoint mit Notizen in TIFF konvertieren"
description: "PowerPoint mit Notizen in TIFF in Aspose.Slides konvertieren."
---

{{% alert title="Tipp" color="primary" %}}

Sie sollten den Aspose [KOSTENLOSEN PowerPoint zu Poster Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) ausprobieren.

{{% /alert %}}

TIFF ist eines der mehrere weit verbreiteten Bildformate, die Aspose.Slides für .NET unterstützt, um PowerPoint PPT- und PPTX-Präsentationen mit Notizen in Bilder zu konvertieren. Sie können auch Folienminiaturansichten im Notizen-Folienansicht generieren. Die [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index)-Methode der Präsentationsklasse kann verwendet werden, um die gesamte Präsentation in der Ansicht Notizen-Folie in TIFF zu konvertieren. Das Speichern einer Microsoft PowerPoint-Präsentation als TIFF-Notizen mit Aspose.Slides für .NET ist ein zweizeiliger Prozess. Sie öffnen einfach die Präsentation und speichern sie als TIFF-Notizen. Sie können auch eine Folienminiaturansicht in der Ansicht Notizen-Folie für einzelne Folien generieren. Die folgenden Codebeispiele aktualisieren die Beispielpräsentation in TIFF-Bilder in der Notizen-Folienansicht, wie unten gezeigt:

```c#
// Instanziieren Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
using (Presentation presentation = new Presentation("NotesFile.pptx"))
{
    // Speichern der Präsentation als TIFF-Notizen
    presentation.Save("Notes_In_Tiff_out.tiff", SaveFormat.Tiff);
}
```