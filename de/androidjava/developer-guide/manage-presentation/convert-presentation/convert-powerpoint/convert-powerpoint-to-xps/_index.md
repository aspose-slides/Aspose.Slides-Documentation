---
title: PowerPoint-Präsentationen nach XPS auf Android konvertieren
linktitle: PowerPoint zu XPS
type: docs
weight: 70
url: /de/androidjava/convert-powerpoint-to-xps/
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
- Android
- Java
- Aspose.Slides
description: "PowerPoint PPT/PPTX in hochwertiges, plattformunabhängiges XPS in Java mit Aspose.Slides für Android konvertieren. Erhalten Sie eine Schritt-für-Schritt-Anleitung und Beispielcode."
---

## **Über XPS**
Microsoft hat [XPS](https://docs.fileformat.com/page-description-language/xps/) als Alternative zu [PDF](https://docs.fileformat.com/pdf/) entwickelt. Es ermöglicht das Drucken von Inhalten, indem eine Datei erstellt wird, die einer PDF sehr ähnlich ist. Das XPS-Format basiert auf XML. Das Layout oder die Struktur einer XPS-Datei bleibt auf allen Betriebssystemen und Druckern gleich.

## **Wann Microsoft XPS-Format verwenden**

{{% alert color="primary" %}} 
Um zu sehen, wie Aspose.Slides PPT- oder PPTX-Präsentationen in das XPS-Format konvertiert, können Sie sich die [diese kostenlose Online-Konverter-App](https://products.aspose.app/slides/conversion) ansehen. 
{{% /alert %}} 

Wenn Sie Speicher-kosten senken möchten, können Sie Ihre Microsoft PowerPoint-Präsentation in das XPS-Format konvertieren. Auf diese Weise wird es einfacher, Ihre Dokumente zu speichern, zu teilen und zu drucken.

Microsoft setzt die starke Unterstützung für XPS in Windows (auch in Windows 10) fort, sodass Sie in Betracht ziehen könnten, Dateien in diesem Format zu speichern.

Wenn Sie mit Windows 8.1, Windows 8, Windows 7 und Windows Vista arbeiten, könnte XPS tatsächlich Ihre beste Option für bestimmte Vorgänge sein.

- **Windows 8** verwendet das OXPS-(Open XPS)-Format für XPS-Dateien. OXPS ist eine standardisierte Version des ursprünglichen XPS-Formats. Windows 8 bietet besseren Support für XPS-Dateien als für PDF-Dateien. 
  - **XPS:** Integrierter XPS-Viewer/Reader und Druck-zu-XPS-Funktion verfügbar. 
  - **PDF:** PDF-Reader verfügbar, aber keine Druck-zu-PDF-Funktion. 

- **Windows 7 und Windows Vista** verwenden das ursprüngliche XPS-Format. Diese Betriebssysteme bieten ebenfalls besseren Support für XPS-Dateien als für PDFs. 
  - **XPS:** Integrierter XPS-Viewer und Druck-zu-XPS-Funktion verfügbar. 
  - **PDF:** Kein PDF-Reader. Keine Druck-zu-PDF-Funktion. 

|<p>**Eingabe PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Ausgabe XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft hat schließlich die Unterstützung für Druckvorgänge in PDF über die Funktion "Print to PDF" in Windows 10 implementiert. Zuvor wurden die Benutzer aufgefordert, Dokumente über das XPS-Format zu drucken.

## **XPS-Konvertierung mit Aspose.Slides**

In [**Aspose.Slides**](https://products.aspose.com/slides/androidjava/) für Java können Sie die [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)‑Methode der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse verwenden, um die gesamte Präsentation in ein XPS-Dokument zu konvertieren.

Beim Konvertieren einer Präsentation zu XPS müssen Sie die Präsentation mit einer dieser Einstellungen speichern:

- Standardeinstellungen (ohne [**XPSOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions))
- Benutzerdefinierte Einstellungen (mit [**XPSOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions))

### **Präsentationen mit Standardeinstellungen zu XPS konvertieren**

Dieser Beispielcode in Java zeigt, wie Sie eine Präsentation mit den Standard-einstellungen in ein XPS-Dokument konvertieren:
```java
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Speichern der Präsentation als XPS-Dokument
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Präsentationen mit benutzerdefinierten Einstellungen zu XPS konvertieren**
Dieser Beispielcode zeigt, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in Java in ein XPS-Dokument konvertieren:
```java
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Instanziieren Sie die TiffOptions-Klasse
    XpsOptions options = new XpsOptions();

    // Metadateien als PNG speichern
    options.setSaveMetafilesAsPng(true);

    // Die Präsentation als XPS-Dokument speichern
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich XPS in einen Stream statt in eine Datei speichern?**

Ja—Aspose.Slides ermöglicht den direkten Export in einen Stream, was ideal für Web-APIs, serverseitige Pipelines oder jedes Szenario ist, in dem Sie das XPS senden möchten, ohne das Dateisystem zu berühren.

**Werden versteckte Folien in XPS übernommen und kann ich sie ausschließen?**

Standardmäßig werden nur reguläre (sichtbare) Folien gerendert. Sie können über die [Export-Einstellungen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions/) [versteckte Folien ein- oder ausschließen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-), bevor Sie in XPS speichern, wodurch sichergestellt wird, dass die Ausgabe genau die Seiten enthält, die Sie beabsichtigen.