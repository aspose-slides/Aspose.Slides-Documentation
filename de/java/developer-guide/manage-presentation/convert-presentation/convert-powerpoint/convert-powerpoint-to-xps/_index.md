---
title: PowerPoint in XPS umwandeln
type: docs
weight: 70
url: /java/convert-powerpoint-to-xps/
keywords: "PPT, PPTX in XPS"
description: "PowerPoint PPT(X) in XPS in Java umwandeln"
---

## **Über XPS**
Microsoft entwickelte [XPS](https://docs.fileformat.com/page-description-language/xps/) als Alternative zu [PDF](https://docs.fileformat.com/pdf/). Es ermöglicht Ihnen, Inhalte zu drucken, indem eine Datei ähnlich wie eine PDF ausgegeben wird. Das XPS-Format basiert auf XML. Das Layout oder die Struktur einer XPS-Datei bleibt auf allen Betriebssystemen und Druckern gleich.

## Wann das Microsoft XPS-Format verwenden

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides eine PPT- oder PPTX-Präsentation in das XPS-Format umwandelt, können Sie [diesen kostenlosen Online-Konverter](https://products.aspose.app/slides/conversion) ausprobieren.

{{% /alert %}} 

Wenn Sie die Speicherkosten senken möchten, können Sie Ihre Microsoft PowerPoint-Präsentation in das XPS-Format umwandeln. Somit wird es einfacher sein, Ihre Dokumente zu speichern, zu teilen und zu drucken.

Microsoft implementiert weiterhin umfassende Unterstützung für XPS in Windows (sogar in Windows 10), daher sollten Sie in Betracht ziehen, Dateien in diesem Format zu speichern. Wenn Sie mit Windows 8.1, Windows 8, Windows 7 und Windows Vista arbeiten, könnte XPS tatsächlich Ihre beste Option für bestimmte Vorgänge sein.

- **Windows 8** verwendet das OXPS (Open XPS)-Format für XPS-Dateien. OXPS ist eine standardisierte Version des ursprünglichen XPS-Formats. Windows 8 bietet eine bessere Unterstützung für XPS-Dateien als für PDF-Dateien.
  - **XPS:** Eingebauter XPS-Viewer/-leser und Druckfunktion für XPS verfügbar.
  - **PDF**: PDF-Reader verfügbar, aber keine Druckfunktion für PDF.

- **Windows 7 und Windows Vista** verwenden das ursprüngliche XPS-Format. Diese Betriebssysteme bieten ebenfalls eine bessere Unterstützung für XPS-Dateien als für PDFs.
  - **XPS**: Eingebauter XPS-Viewer und Druckfunktion für XPS verfügbar.
  - **PDF**: Kein PDF-Reader. Keine Druckfunktion für PDF.

|<p>**Eingang PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Ausgang XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft implementierte schließlich die Unterstützung für Druckvorgänge in PDF über die Druckfunktion für PDF in Windows 10. Zuvor wurde erwartet, dass Benutzer Dokumente über das XPS-Format drucken.

## XPS-Konvertierung mit Aspose.Slides

In [**Aspose.Slides**](https://products.aspose.com/slides/java/) für Java können Sie die Methode [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) verwenden, um die gesamte Präsentation in ein XPS-Dokument umzuwandeln.

Bei der Konvertierung einer Präsentation in XPS müssen Sie die Präsentation mit einer dieser Einstellungen speichern:

- Standard-Einstellungen (ohne [**XPSOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions))
- Benutzerdefinierte Einstellungen (mit [**XPSOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions))

### **Präsentationen in XPS mit Standard-Einstellungen konvertieren**

Dieser Beispielcode in Java zeigt Ihnen, wie Sie eine Präsentation unter Verwendung der Standard-Einstellungen in ein XPS-Dokument umwandeln:

```java
// Erstellen Sie ein Präsentationsobjekt, das eine Präsentationsdatei repräsentiert
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Speichern der Präsentation als XPS-Dokument
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Präsentationen in XPS mit benutzerdefinierten Einstellungen konvertieren**
Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation unter Verwendung benutzerdefinierter Einstellungen in ein XPS-Dokument umwandeln:

```java
// Erstellen Sie ein Präsentationsobjekt, das eine Präsentationsdatei repräsentiert
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Erstellen Sie eine Instanz der Klasse TiffOptions
    XpsOptions options = new XpsOptions();

    // Metafiles als PNG speichern
    options.setSaveMetafilesAsPng(true);

    // Speichern der Präsentation als XPS-Dokument
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```