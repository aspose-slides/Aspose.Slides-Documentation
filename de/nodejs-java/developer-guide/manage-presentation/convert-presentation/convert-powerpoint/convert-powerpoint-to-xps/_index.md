---
title: PowerPoint zu XPS konvertieren
type: docs
weight: 70
url: /de/nodejs-java/convert-powerpoint-to-xps/
keywords: "PPT, PPTX zu XPS"
description: "PowerPoint PPT(X) nach XPS in JavaScript konvertieren"
---

## **Über XPS**

Microsoft hat [XPS](https://docs.fileformat.com/page-description-language/xps/) als Alternative zu [PDF](https://docs.fileformat.com/pdf/) entwickelt. Es ermöglicht das Drucken von Inhalten, indem eine Datei erzeugt wird, die einer PDF sehr ähnlich ist. Das XPS‑Format basiert auf XML. Das Layout oder die Struktur einer XPS‑Datei bleibt auf allen Betriebssystemen und Druckern gleich. 

## **Wann das Microsoft XPS‑Format verwenden**

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PPT‑ oder PPTX‑Präsentationen in das XPS‑Format konvertiert, können Sie [diese kostenlose Online‑Konverter‑App](https://products.aspose.app/slides/conversion) prüfen. 

{{% /alert %}} 

Wenn Sie die Speicherkosten senken möchten, können Sie Ihre Microsoft PowerPoint‑Präsentation in das XPS‑Format konvertieren. So wird es Ihnen leichter fallen, Ihre Dokumente zu speichern, zu teilen und zu drucken. 

Microsoft erweitert nach wie vor die umfassende Unterstützung für XPS in Windows (auch in Windows 10), sodass Sie in Betracht ziehen können, Dateien in diesem Format zu speichern. Wenn Sie mit Windows 8.1, Windows 8, Windows 7 und Windows Vista arbeiten, könnte XPS tatsächlich Ihre beste Option für bestimmte Vorgänge sein. 

- **Windows 8** verwendet das OXPS (Open XPS)‑Format für XPS‑Dateien. OXPS ist eine standardisierte Version des ursprünglichen XPS‑Formats. Windows 8 bietet bessere Unterstützung für XPS‑Dateien als für PDF‑Dateien. 
  - **XPS:** Integrierter XPS‑Viewer/Reader und Druck‑zu‑XPS‑Funktion verfügbar. 
  - **PDF:** PDF‑Reader verfügbar, aber keine Druck‑zu‑PDF‑Funktion. 

- **Windows 7 und Windows Vista** verwenden das ursprüngliche XPS‑Format. Diese Betriebssysteme bieten ebenfalls bessere Unterstützung für XPS‑Dateien als für PDFs. 
  - **XPS:** Integrierter XPS‑Viewer und Druck‑zu‑XPS‑Funktion verfügbar. 
  - **PDF:** Kein PDF‑Reader. Keine Druck‑zu‑PDF‑Funktion. 

|<p>**Eingabe PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Ausgabe XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft hat schließlich die Unterstützung für Druckvorgänge in PDF über die Funktion „Print to PDF“ in Windows 10 implementiert. Zuvor wurden Benutzer aufgefordert, Dokumente über das XPS‑Format zu drucken. 

## **XPS‑Konvertierung mit Aspose.Slides**

In [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/) können Sie die [**save**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-)‑Methode der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)‑Klasse verwenden, um die gesamte Präsentation in ein XPS‑Dokument zu konvertieren.

Beim Konvertieren einer Präsentation zu XPS müssen Sie die Präsentation mit einer dieser Einstellungen speichern:

- Standard‑Einstellungen (ohne [**XPSOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions))
- Benutzerdefinierte Einstellungen (mit [**XPSOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions))

### **Präsentationen mit Standard‑Einstellungen in XPS konvertieren**

Dieses Beispiel in JavaScript zeigt, wie Sie eine Präsentation mit Standard‑Einstellungen in ein XPS‑Dokument konvertieren:
```javascript
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("Convert_XPS.pptx");
try {
    // Speichern der Präsentation in ein XPS-Dokument
    pres.save("XPS_Output_Without_XPSOption.xps", aspose.slides.SaveFormat.Xps);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Präsentationen mit benutzerdefinierten Einstellungen in XPS konvertieren**
Dieses Beispiel zeigt, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in JavaScript in ein XPS‑Dokument konvertieren:
```javascript
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("Convert_XPS_Options.pptx");
try {
    // Instanziieren Sie die TiffOptions-Klasse
    var options = new aspose.slides.XpsOptions();
    // Speichern Sie MetaFiles als PNG
    options.setSaveMetafilesAsPng(true);
    // Speichern Sie die Präsentation als XPS-Dokument
    pres.save("XPS_Output_With_Options.xps", aspose.slides.SaveFormat.Xps, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Kann ich XPS in einen Stream statt in eine Datei speichern?**

Ja – Aspose.Slides ermöglicht den direkten Export in einen Stream, was ideal für Web‑APIs, serverseitige Pipelines oder jedes Szenario ist, bei dem Sie das XPS senden möchten, ohne das Dateisystem zu berühren.

**Werden versteckte Folien in XPS übernommen, und kann ich sie ausschließen?**

Standardmäßig werden nur reguläre (sichtbare) Folien gerendert. Sie können [versteckte Folien ein‑ oder ausschließen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/setshowhiddenslides/) über die [Export‑Einstellungen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/) vor dem Speichern nach XPS festlegen, sodass die Ausgabe genau die Seiten enthält, die Sie beabsichtigen.