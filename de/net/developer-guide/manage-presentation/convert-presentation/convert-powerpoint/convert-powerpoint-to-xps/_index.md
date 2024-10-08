---
title: PowerPoint in XPS konvertieren
type: docs
weight: 70
url: /de/net/convert-powerpoint-to-xps
keywords: "PowerPoint-Präsentation konvertieren, PowerPoint in XPS, PPT in XPS, PPTX in XPS, Konvertierung, C#, Csharp, .NET, Aspose.Slides"
description: "Konvertieren Sie PowerPoint-Präsentationen in XPS mit C# oder .NET."
---

## **Über XPS**
Microsoft entwickelte [XPS](https://docs.fileformat.com/page-description-language/xps/) als Alternative zu [PDF](https://docs.fileformat.com/pdf/). Es ermöglicht das Drucken von Inhalten durch das Ausgeben einer Datei, die PDF sehr ähnlich ist. Das XPS-Format basiert auf XML. Das Layout oder die Struktur einer XPS-Datei bleibt auf allen Betriebssystemen und Druckern gleich.

## Wann man das Microsoft XPS-Format verwenden sollte

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PPT oder PPTX-Präsentationen in das XPS-Format konvertiert, können Sie [diese kostenlose Online-Konverter-App](https://products.aspose.app/slides/conversion) ausprobieren. 

{{% /alert %}} 

Wenn Sie die Speicherkosten senken möchten, können Sie Ihre Microsoft PowerPoint-Präsentation in das XPS-Format konvertieren. Auf diese Weise wird es einfacher, Ihre Dokumente zu speichern, zu teilen und zu drucken.

Microsoft setzt weiterhin auf eine starke Unterstützung von XPS in Windows (sogar in Windows 10), daher sollten Sie in Erwägung ziehen, Dateien in diesem Format zu speichern. Wenn Sie mit Windows 8.1, Windows 8, Windows 7 und Windows Vista arbeiten, könnte XPS tatsächlich die beste Option für bestimmte Operationen sein.

- **Windows 8** verwendet das OXPS (Open XPS)-Format für XPS-Dateien. OXPS ist eine standardisierte Version des ursprünglichen XPS-Formats. Windows 8 bietet eine bessere Unterstützung für XPS-Dateien als für PDF-Dateien.
  - **XPS:** Eingebauter XPS-Viewer/Reader und Druckfunktion für XPS verfügbar.
  - **PDF**: PDF-Reader vorhanden, jedoch keine Druckfunktion für PDF. 

-  **Windows 7 und Windows Vista** verwenden das ursprüngliche XPS-Format. Diese Betriebssysteme bieten ebenfalls eine bessere Unterstützung für XPS-Dateien als für PDFs.
  - **XPS**: Eingebauter XPS-Viewer und Druckfunktion für XPS verfügbar.
  - **PDF**: Kein PDF-Reader. Keine Druckfunktion für PDF.

|<p>**Eingabe PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Ausgabe XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |


Microsoft hat schließlich die Unterstützung für Druckoperationen in PDF über die Druckfunktion in PDF in Windows 10 implementiert. Zuvor wurde erwartet, dass Benutzer Dokumente im XPS-Format drucken.

## XPS-Konvertierung mit Aspose.Slides

In [**Aspose.Slides**](https://products.aspose.com/slides/net/) für .NET können Sie die von der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse bereitgestellte [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) Methode verwenden, um die gesamte Präsentation in ein XPS-Dokument zu konvertieren.

Beim Konvertieren einer Präsentation in XPS müssen Sie die Präsentation mit einer dieser Einstellungen speichern:

- Standardeinstellungen (ohne [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))
- Anpassbare Einstellungen (mit [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))

### **Konvertieren von Präsentationen in XPS mit Standardeinstellungen**

Dieser Beispielcode in C# zeigt Ihnen, wie Sie eine Präsentation mit Standard Einstellungen in ein XPS-Dokument konvertieren:

```c#
// Erstellen Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Speichern der Präsentation als XPS-Dokument
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **Konvertieren von Präsentationen in XPS mit benutzerdefinierten Einstellungen**
Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in ein XPS-Dokument in C# konvertieren:

```c#
// Erstellen Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Erstellen Sie die Klasse XpsOptions
    XpsOptions options = new XpsOptions();

    // Metadateien als PNG speichern
    options.SaveMetafilesAsPng = true;

    // Speichern der Präsentation als XPS-Dokument
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```