---
title: PowerPoint-Präsentationen in XPS konvertieren mit PHP
linktitle: PowerPoint zu XPS
type: docs
weight: 70
url: /de/php-java/convert-powerpoint-to-xps/
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
- PHP
- Aspose.Slides
description: "Konvertieren Sie PowerPoint PPT/PPTX mit Aspose.Slides für PHP über Java in hochwertige, plattformunabhängige XPS. Erhalten Sie eine schrittweise Anleitung und Beispielcode."
---

## **Über XPS**
Microsoft entwickelte [XPS](https://docs.fileformat.com/page-description-language/xps/) als Alternative zu [PDF](https://docs.fileformat.com/pdf/). Es ermöglicht das Drucken von Inhalten, indem eine Datei ausgegeben wird, die einem PDF sehr ähnlich ist. Das XPS‑Format basiert auf XML. Das Layout oder die Struktur einer XPS‑Datei bleibt auf allen Betriebssystemen und Druckern gleich. 

## **Wann das Microsoft XPS‑Format zu verwenden ist**

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PPT‑ oder PPTX‑Präsentationen in das XPS‑Format konvertiert, können Sie sich die [kostenlose Online‑Konverter‑App](https://products.aspose.app/slides/conversion) anschauen. 

{{% /alert %}} 

Wenn Sie Speicherkosten senken möchten, können Sie Ihre Microsoft PowerPoint‑Präsentation in das XPS‑Format konvertieren. Auf diese Weise wird es einfacher, Ihre Dokumente zu speichern, zu teilen und zu drucken. 

Microsoft implementiert weiterhin starken Support für XPS in Windows (auch in Windows 10), sodass Sie erwägen sollten, Dateien in diesem Format zu speichern. Wenn Sie mit Windows 8.1, Windows 8, Windows 7 und Windows Vista arbeiten, könnte XPS tatsächlich Ihre beste Option für bestimmte Vorgänge sein. 

- **Windows 8** verwendet das OXPS (Open XPS)-Format für XPS‑Dateien. OXPS ist eine standardisierte Version des ursprünglichen XPS‑Formats. Windows 8 bietet besseren Support für XPS‑Dateien als für PDF‑Dateien. 
  - **XPS:** Eingebauter XPS‑Viewer/Reader und Druck‑zu‑XPS‑Funktion verfügbar. 
  - **PDF:** PDF‑Reader verfügbar, jedoch keine Druck‑zu‑PDF‑Funktion. 

- **Windows 7 und Windows Vista** verwenden das ursprüngliche XPS‑Format. Diese Betriebssysteme bieten ebenfalls besseren Support für XPS‑Dateien als für PDFs. 
  - **XPS:** Eingebauter XPS‑Viewer und Druck‑zu‑XPS‑Funktion verfügbar. 
  - **PDF:** Kein PDF‑Reader. Keine Druck‑zu‑PDF‑Funktion. 

|<p>**Eingabe PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Ausgabe XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft implementierte schließlich die Unterstützung von Druckvorgängen in PDF über die Funktion „Drucken nach PDF“ in Windows 10. Zuvor wurde von den Benutzern erwartet, Dokumente über das XPS‑Format zu drucken. 

## **XPS‑Konvertierung mit Aspose.Slides**

In [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) für Java können Sie die Methode [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) verwenden, die von der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) bereitgestellt wird, um die gesamte Präsentation in ein XPS‑Dokument zu konvertieren.

Beim Konvertieren einer Präsentation nach XPS müssen Sie die Präsentation mit einer dieser Einstellungen speichern:

- Standardeinstellungen (ohne [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions))
- Benutzerdefinierte Einstellungen (mit [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions))

### **Präsentationen mit Standardeinstellungen in XPS konvertieren**

Dieses Beispiel zeigt, wie Sie eine Präsentation mit den Standardoptionen in ein XPS‑Dokument konvertieren:
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


### **Präsentationen mit benutzerdefinierten Einstellungen in XPS konvertieren**
Dieses Beispiel zeigt, wie Sie eine Präsentation mit benutzerdefinierten Optionen in ein XPS‑Dokument konvertieren:
```php
  # Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # Instanziieren Sie die TiffOptions-Klasse
    $options = new XpsOptions();
    # Meta-Dateien als PNG speichern
    $options->setSaveMetafilesAsPng(true);
    # Präsentation als XPS-Dokument speichern
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Kann ich XPS in einen Stream statt in eine Datei speichern?**

Ja—Aspose.Slides ermöglicht das direkte Exportieren in einen Stream, was ideal für Web‑APIs, serverseitige Pipelines oder jedes Szenario ist, in dem Sie das XPS senden möchten, ohne das Dateisystem zu berühren.

**Werden versteckte Folien in XPS übernommen und kann ich sie ausschließen?**

Standardmäßig werden nur reguläre (sichtbare) Folien gerendert. Sie können [versteckte Folien ein‑ oder ausschließen](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions/setshowhiddenslides/) über die [Export‑Einstellungen](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions/) vor dem Speichern in XPS verwenden, sodass die Ausgabe genau die Seiten enthält, die Sie beabsichtigen.