---
title: PowerPoint-Präsentationen zu XPS in .NET konvertieren
linktitle: PowerPoint zu XPS
type: docs
weight: 70
url: /de/net/convert-powerpoint-to-xps/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu XPS
- Präsentation zu XPS
- Folie zu XPS
- PPT zu XPS
- PPTX zu XPS
- PPT als XPS speichern
- PPTX als XPS speichern
- PPT nach XPS exportieren
- PPTX nach XPS exportieren
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Konvertieren Sie PowerPoint PPT/PPTX in hochwertige, plattformunabhängige XPS-Dateien in .NET mit Aspose.Slides. Erhalten Sie eine Schritt‑für‑Schritt‑Anleitung und Beispiel‑C#‑Code."
---
## **Übersicht**

Aspose.Slides ermöglicht Ihnen, PowerPoint‑Präsentationen in XPS zu konvertieren, indem Sie eine PPT‑ oder PPTX‑Datei im XPS‑Format speichern. Dieser Artikel erklärt, wann das XPS‑Format nützlich sein kann, und zeigt, wie die Konvertierung mit Aspose.Slides entweder mit den Standardeinstellungen oder mit benutzerdefinierten [XpsOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/xpsoptions/) durchgeführt wird.

## **Über XPS**
Microsoft entwickelte [XPS](https://docs.fileformat.com/page-description-language/xps/) als Alternative zu [PDF](https://docs.fileformat.com/pdf/). Es ermöglicht das Drucken von Inhalten, indem eine Datei erzeugt wird, die einem PDF sehr ähnlich ist. Das XPS‑Format basiert auf XML. Das Layout oder die Struktur einer XPS‑Datei bleibt auf allen Betriebssystemen und Druckern gleich.

## **Wann das Microsoft‑XPS‑Format verwenden**

{{% alert color="info" %}} 

Um zu sehen, wie Aspose.Slides PPT‑ oder PPTX‑Präsentationen in das XPS‑Format konvertiert, können Sie die [kostenlose Online‑Konverter‑App](https://products.aspose.app/slides/de/conversion) ansehen. 

{{% /alert %}} 

Wenn Sie Speicher‑Kosten senken möchten, können Sie Ihre Microsoft‑PowerPoint‑Präsentation in das XPS‑Format konvertieren. So lassen sich die Dokumente einfacher speichern, teilen und drucken.

Microsoft unterstützt XPS nach wie vor stark unter Windows (auch unter Windows 10), sodass Sie das Speichern in diesem Format in Betracht ziehen sollten. Wenn Sie mit Windows 8.1, Windows 8, Windows 7 oder Windows Vista arbeiten, könnte XPS für bestimmte Vorgänge tatsächlich die beste Option sein.

- **Windows 8** verwendet das OXPS (Open XPS)‑Format für XPS‑Dateien. OXPS ist eine standardisierte Version des ursprünglichen XPS‑Formats. Windows 8 bietet besseren Support für XPS‑Dateien als für PDF‑Dateien. 
  - **XPS:** Integrierter XPS‑Viewer/Reader und Druck‑zu‑XPS‑Funktion verfügbar. 
  - **PDF:** PDF‑Reader verfügbar, jedoch keine Druck‑zu‑PDF‑Funktion. 

- **Windows 7 und Windows Vista** verwenden das ursprüngliche XPS‑Format. Diese Betriebssysteme bieten ebenfalls besseren Support für XPS‑Dateien als für PDFs. 
  - **XPS:** Integrierter XPS‑Viewer und Druck‑zu‑XPS‑Funktion verfügbar. 
  - **PDF:** Kein PDF‑Reader. Keine Druck‑zu‑PDF‑Funktion. 

|<p>**Eingabe PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Ausgabe XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft hat schließlich die Unterstützung für Druckvorgänge in PDF durch die „Print to PDF“-Funktion in Windows 10 implementiert. Zuvor erwarteten die Benutzer, Dokumente über das XPS‑Format zu drucken. 

## **XPS‑Konvertierung mit Aspose.Slides**

In [**Aspose.Slides**](https://products.aspose.com/slides/de/net/) für .NET können Sie die [**Save**](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/methods/save/index)‑Methode der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation)‑Klasse verwenden, um die gesamte Präsentation in ein XPS‑Dokument zu konvertieren.

Beim Konvertieren einer Präsentation zu XPS müssen Sie die Präsentation mit einer dieser Einstellungen speichern:

- Standardeinstellungen (ohne [**XPSOptions**](https://reference.aspose.com/slides/de/net/aspose.slides.export/xpsoptions))
- Benutzerdefinierte Einstellungen (mit [**XPSOptions**](https://reference.aspose.com/slides/de/net/aspose.slides.export/xpsoptions))

### **Präsentationen mit Standardeinstellungen in XPS konvertieren**

Dieser Beispielcode in C# zeigt, wie Sie eine Präsentation mit Standard‑Einstellungen in ein XPS‑Dokument konvertieren:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Erstellt ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Speichert die Präsentation als XPS-Dokument
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **Präsentationen mit benutzerdefinierten Einstellungen in XPS konvertieren**
Dieser Beispielcode zeigt, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in C# in ein XPS‑Dokument konvertieren:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Instanziiert die TiffOptions-Klasse
    XpsOptions options = new XpsOptions();

    // Speichert Metadateien als PNG
    options.SaveMetafilesAsPng = true;

    // Speichert die Präsentation als XPS-Dokument
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

## **FAQ**

### Kann ich XPS in einen Stream statt in eine Datei speichern?

Ja—Aspose.Slides ermöglicht den direkten Export in einen Stream, was ideal für Web‑APIs, serverseitige Pipelines oder jede Situation ist, in der Sie das XPS senden möchten, ohne das Dateisystem zu berühren.

### Werden ausgeblendete Folien in XPS übernommen und kann ich sie ausschließen?

Standardmäßig werden nur reguläre (sichtbare) Folien gerendert. Sie können [ausgeblendete Folien ein‑ oder ausschließen](https://reference.aspose.com/slides/de/net/aspose.slides.export/xpsoptions/showhiddenslides/) über die [Export‑Einstellungen](https://reference.aspose.com/slides/de/net/aspose.slides.export/xpsoptions/) vor dem Speichern in XPS, sodass die Ausgabe genau die Seiten enthält, die Sie wünschen.