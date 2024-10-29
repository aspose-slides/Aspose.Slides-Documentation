---
title: PowerPoint in XPS konvertieren
type: docs
weight: 70
url: /de/cpp/convert-powerpoint-to-xps
keywords: "Konvertieren, PowerPoint in XPS, Konversion, PPT in XPS, PPTX in XPS"
description: "Konvertieren Sie PowerPoint PPT, PPTX in ein XPS-Dokument mit der Aspose.Slides API."
---

## **Über XPS**
Microsoft entwickelte [XPS](https://docs.fileformat.com/page-description-language/xps/) als Alternative zu [PDF](https://docs.fileformat.com/pdf/). Es ermöglicht Ihnen, Inhalte zu drucken, indem es eine Datei ausgibt, die sehr ähnlich wie ein PDF ist. Das XPS-Format basiert auf XML. Das Layout oder die Struktur einer XPS-Datei bleibt auf allen Betriebssystemen und Druckern gleich.

## Wann das Microsoft XPS-Format verwenden

{{% alert color="primary" %}}

Um zu sehen, wie Aspose.Slides eine PPT- oder PPTX-Präsentation in das XPS-Format konvertiert, können Sie [diese kostenlose Online-Konverter-App](https://products.aspose.app/slides/conversion) ausprobieren.

{{% /alert %}}

Wenn Sie die Speicherkosten senken möchten, können Sie Ihre Microsoft PowerPoint-Präsentation in das XPS-Format konvertieren. Auf diese Weise wird es einfacher, Ihre Dokumente zu speichern, zu teilen und zu drucken.

Microsoft implementiert weiterhin umfangreiche Unterstützung für XPS in Windows (sogar in Windows 10), sodass Sie in Betracht ziehen sollten, Dateien in diesem Format zu speichern. Wenn Sie mit Windows 8.1, Windows 8, Windows 7 und Windows Vista arbeiten, könnte XPS tatsächlich Ihre beste Option für bestimmte Vorgänge sein.

- **Windows 8** verwendet das OXPS (Open XPS)-Format für XPS-Dateien. OXPS ist eine standardisierte Version des originalen XPS-Formats. Windows 8 bietet eine bessere Unterstützung für XPS-Dateien als für PDF-Dateien.
  - **XPS:** Eingebauter XPS-Viewer / -Leser und Druckfunktion für XPS verfügbar.
  - **PDF**: PDF-Reader verfügbar, aber keine Druckfunktion für PDF.

- **Windows 7 und Windows Vista** verwenden das ursprüngliche XPS-Format. Diese Betriebssysteme bieten ebenfalls eine bessere Unterstützung für XPS-Dateien als für PDFs.
  - **XPS**: Eingebauter XPS-Viewer und Druckfunktion für XPS verfügbar.
  - **PDF**: Kein PDF-Reader. Keine Druckfunktion für PDF.

|<p>**Eingabe PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Ausgabe XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft implementierte schließlich Unterstützung für Druckvorgänge in PDF über die Druckfunktion in PDF in Windows 10. Zuvor wurde von den Benutzern erwartet, dass sie Dokumente über das XPS-Format drucken.

## XPS-Konvertierung mit Aspose.Slides

In [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) für C++ können Sie die [**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) Methode der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse verwenden, um die gesamte Präsentation in ein XPS-Dokument zu konvertieren.

Beim Konvertieren einer Präsentation in XPS müssen Sie die Präsentation entweder mit diesen Einstellungen speichern:

- Standard-Einstellungen (ohne [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))
- Benutzerdefinierte Einstellungen (mit [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))

### **Konvertieren von Präsentationen in XPS mit Standard-Einstellungen**

Dieser Beispielcode in C++ zeigt Ihnen, wie Sie eine Präsentation mit Standardeinstellungen in ein XPS-Dokument konvertieren:

``` cpp
// Erstellen Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Speichern der Präsentation als XPS-Dokument
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **Konvertieren von Präsentationen in XPS mit benutzerdefinierten Einstellungen**

Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in ein XPS-Dokument konvertieren:

``` cpp
// Erstellen Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Erstellen Sie die XpsOptions-Klasse
auto options = System::MakeObject<XpsOptions>();

// Speichern von Metadateien als PNG
options->set_SaveMetafilesAsPng(true);

// Speichern der Präsentation als XPS-Dokument
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```