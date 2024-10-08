---
title: PowerPoint in XPS konvertieren
type: docs
weight: 70
url: /de/androidjava/convert-powerpoint-to-xps/
keywords: "PPT, PPTX in XPS"
description: "Konvertieren Sie PowerPoint PPT(X) in XPS in Java"
---

## **Über XPS**
Microsoft entwickelte [XPS](https://docs.fileformat.com/page-description-language/xps/) als Alternative zu [PDF](https://docs.fileformat.com/pdf/). Es ermöglicht Ihnen, Inhalte auszudrucken, indem eine Datei ausgegeben wird, die der PDF sehr ähnlich ist. Das XPS-Format ist auf XML basierend. Das Layout oder die Struktur einer XPS-Datei bleibt auf allen Betriebssystemen und Druckern gleich.

## Wann das Microsoft XPS-Format verwenden

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PPT- oder PPTX-Präsentationen in das XPS-Format konvertiert, können Sie [diese kostenlose Online-Konverter-App](https://products.aspose.app/slides/conversion) ausprobieren. 

{{% /alert %}} 

Wenn Sie die Speicherkosten senken möchten, können Sie Ihre Microsoft PowerPoint-Präsentation in das XPS-Format konvertieren. Auf diese Weise wird es einfacher, Ihre Dokumente zu speichern, zu teilen und zu drucken.

Microsoft setzt weiterhin stark auf die Unterstützung von XPS in Windows (sogar in Windows 10), daher sollten Sie in Betracht ziehen, Dateien in diesem Format zu speichern. Wenn Sie mit Windows 8.1, Windows 8, Windows 7 und Windows Vista arbeiten, könnte XPS tatsächlich Ihre beste Option für bestimmte Vorgänge sein.

- **Windows 8** verwendet das OXPS (Open XPS) Format für XPS-Dateien. OXPS ist eine standardisierte Version des ursprünglichen XPS-Formats. Windows 8 bietet eine bessere Unterstützung für XPS-Dateien als für PDF-Dateien. 
  - **XPS:** Eingebaute XPS-Viewer/Reader und Druckfunktion für XPS verfügbar. 
  - **PDF**: PDF-Reader verfügbar, jedoch keine Druckfunktion für PDF. 

- **Windows 7 und Windows Vista** verwenden das ursprüngliche XPS-Format. Diese Betriebssysteme bieten ebenfalls eine bessere Unterstützung für XPS-Dateien als für PDFs. 
  - **XPS**: Eingebauter XPS-Viewer und Druckfunktion für XPS verfügbar. 
  - **PDF**: Kein PDF-Reader. Keine Druckfunktion für PDF. 

|<p>**Eingabe PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Ausgabe XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft hat schließlich Unterstützung für Druckvorgänge im PDF über die Druckfunktion zu PDF in Windows 10 implementiert. Zuvor wurde von den Benutzern erwartet, dass sie Dokumente über das XPS-Format drucken.

## XPS-Konvertierung mit Aspose.Slides

In [**Aspose.Slides**](https://products.aspose.com/slides/androidjava/) für Java können Sie die [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) Methode, die von der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse bereitgestellt wird, verwenden, um die gesamte Präsentation in ein XPS-Dokument zu konvertieren.

Bei der Konvertierung einer Präsentation in XPS müssen Sie die Präsentation mit einer dieser Einstellungen speichern:

- Standardoptionen (ohne [**XPSOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions))
- Benutzerdefinierte Optionen (mit [**XPSOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions))

### **Präsentationen in XPS mit Standardoptionen konvertieren**

Dieser Beispielcode in Java zeigt Ihnen, wie Sie eine Präsentation mit den Standardoptionen in ein XPS-Dokument konvertieren:

```java
// Instanziieren Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Speichern der Präsentation als XPS-Dokument
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Präsentationen in XPS mit benutzerdefinierten Optionen konvertieren**
Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation mit benutzerdefinierten Optionen in ein XPS-Dokument konvertieren:

```java
// Instanziieren Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Instanziieren Sie die Klasse TiffOptions
    XpsOptions options = new XpsOptions();

    // Metadateien als PNG speichern
    options.setSaveMetafilesAsPng(true);

    // Speichern der Präsentation als XPS-Dokument
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```