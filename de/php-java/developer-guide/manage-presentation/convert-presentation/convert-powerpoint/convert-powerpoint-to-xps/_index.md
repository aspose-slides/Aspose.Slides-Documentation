---
title: PowerPoint in XPS konvertieren
type: docs
weight: 70
url: /de/php-java/convert-powerpoint-to-xps/
keywords: "PPT, PPTX zu XPS"
description: "Konvertieren Sie PowerPoint PPT(X) in XPS"
---

## **Über XPS**
Microsoft entwickelte [XPS](https://docs.fileformat.com/page-description-language/xps/) als Alternative zu [PDF](https://docs.fileformat.com/pdf/). Es ermöglicht Ihnen, Inhalte durch das Ausgeben einer Datei, die einer PDF sehr ähnlich ist, zu drucken. Das XPS-Format basiert auf XML. Das Layout oder die Struktur einer XPS-Datei bleibt auf allen Betriebssystemen und Druckern gleich.

## Wann das Microsoft XPS-Format verwenden

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PPT- oder PPTX-Präsentationen in das XPS-Format konvertiert, können Sie [diesen kostenlosen Online-Konverter](https://products.aspose.app/slides/conversion) ausprobieren. 

{{% /alert %}} 

Wenn Sie die Speicherkosten senken möchten, können Sie Ihre Microsoft PowerPoint-Präsentation in das XPS-Format konvertieren. So wird es einfacher, Ihre Dokumente zu speichern, zu teilen und zu drucken.

Microsoft implementiert weiterhin umfassende Unterstützung für XPS in Windows (sogar in Windows 10), sodass Sie in Betracht ziehen sollten, Dateien in diesem Format zu speichern. Wenn Sie mit Windows 8.1, Windows 8, Windows 7 und Windows Vista arbeiten, könnte XPS tatsächlich die beste Option für bestimmte Operationen sein.

- **Windows 8** verwendet das OXPS (Open XPS)-Format für XPS-Dateien. OXPS ist eine standardisierte Version des ursprünglichen XPS-Formats. Windows 8 bietet eine bessere Unterstützung für XPS-Dateien als für PDF-Dateien.
  - **XPS:** Eingebauter XPS-Viewer/Reader und Druckfunktion für XPS verfügbar. 
  - **PDF**: PDF-Reader verfügbar, aber keine Druckfunktion für PDF.

- **Windows 7 und Windows Vista** verwenden das ursprüngliche XPS-Format. Diese Betriebssysteme bieten ebenfalls eine bessere Unterstützung für XPS-Dateien als für PDFs.
  - **XPS**: Eingebauter XPS-Viewer und Druckfunktion für XPS verfügbar. 
  - **PDF**: Kein PDF-Reader. Keine Druckfunktion für PDF.

|<p>**Eingabe PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Ausgabe XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft hat schließlich Unterstützung für Druckvorgänge in PDF über die Druckfunktion in PDF in Windows 10 implementiert. Zuvor wurde von den Nutzern erwartet, dass sie Dokumente im XPS-Format drucken.

## XPS-Konvertierung mit Aspose.Slides

In [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) für Java können Sie die von der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse bereitgestellte Methode [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) verwenden, um die gesamte Präsentation in ein XPS-Dokument zu konvertieren.

Beim Konvertieren einer Präsentation in XPS müssen Sie die Präsentation mit einer dieser Einstellungen speichern:

- Standardeinstellungen (ohne [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions))
- Kundenspezifische Einstellungen (mit [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions))

### **Konvertieren von Präsentationen in XPS unter Verwendung von Standardeinstellungen**

Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation in ein XPS-Dokument mit Standard-Einstellungen konvertieren:

```php
# Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
$pres = new Presentation("Convert_XPS.pptx");
try {
  # Speichern der Präsentation als XPS-Dokument
  $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
} finally {
  if (!java_is_null($pres)) {
    $pres->dispose();
  }
}
```


### **Konvertieren von Präsentationen in XPS unter Verwendung von kundenspezifischen Einstellungen**
Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation in ein XPS-Dokument mit benutzerdefinierten Einstellungen konvertieren:

```php
# Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
$pres = new Presentation("Convert_XPS_Options.pptx");
try {
  # Instanziieren Sie die TiffOptions-Klasse
  $options = new XpsOptions();
  # Speichern von Metadateien als PNG
  $options->setSaveMetafilesAsPng(true);
  # Speichern der Präsentation als XPS-Dokument
  $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
} finally {
  if (!java_is_null($pres)) {
    $pres->dispose();
  }
}
```