---
title: PowerPoint-Präsentationen in XPS konvertieren in .NET
linktitle: PowerPoint zu XPS
type: docs
weight: 70
url: /de/net/convert-powerpoint-to-xps/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folien konvertieren
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
description: "Konvertieren Sie PowerPoint PPT/PPTX in hochwertige, plattformunabhängige XPS in .NET mit Aspose.Slides. Erhalten Sie eine schrittweise Anleitung und Beispielcode in C#."
---

## **Über XPS**
Microsoft hat [XPS](https://docs.fileformat.com/page-description-language/xps/) als Alternative zu [PDF](https://docs.fileformat.com/pdf/) entwickelt. Es ermöglicht das Drucken von Inhalten, indem eine Datei erzeugt wird, die einer PDF sehr ähnlich ist. Das XPS‑Format basiert auf XML. Das Layout bzw. die Struktur einer XPS‑Datei bleibt auf allen Betriebssystemen und Druckern gleich. 

## **Wann das Microsoft XPS‑Format zu verwenden ist**

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PPT‑ oder PPTX‑Präsentationen in das XPS‑Format konvertiert, können Sie sich die [kostenlose Online‑Konverter‑App](https://products.aspose.app/slides/conversion) ansehen. 

{{% /alert %}} 

Wenn Sie Speicher‑Kosten senken möchten, können Sie Ihre Microsoft PowerPoint‑Präsentation in das XPS‑Format konvertieren. So lässt sich das Dokument leichter speichern, teilen und drucken. 

Microsoft unterstützt XPS weiterhin stark in Windows (auch in Windows 10), sodass Sie das Speichern von Dateien in diesem Format in Betracht ziehen sollten. Wenn Sie mit Windows 8.1, Windows 8, Windows 7 oder Windows Vista arbeiten, könnte XPS für bestimmte Vorgänge Ihre beste Option sein. 

- **Windows 8** verwendet das OXPS (Open XPS)‑Format für XPS‑Dateien. OXPS ist eine standardisierte Version des ursprünglichen XPS‑Formats. Windows 8 bietet besseren Support für XPS‑Dateien als für PDF‑Dateien. 
  - **XPS:** Integrierter XPS‑Betrachter/Reader und Druck‑zu‑XPS‑Funktion verfügbar. 
  - **PDF:** PDF‑Reader verfügbar, aber keine Druck‑zu‑PDF‑Funktion. 

- **Windows 7 und Windows Vista** verwenden das ursprüngliche XPS‑Format. Diese Betriebssysteme bieten ebenfalls besseren Support für XPS‑Dateien als für PDFs. 
  - **XPS:** Integrierter XPS‑Betrachter und Druck‑zu‑XPS‑Funktion verfügbar. 
  - **PDF:** Kein PDF‑Reader. Keine Druck‑zu‑PDF‑Funktion. 

|<p>**Eingabe PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Ausgabe XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft hat schließlich die Unterstützung für Druckvorgänge in PDF über die Funktion „Print to PDF“ in Windows 10 implementiert. Zuvor erwarteten die Nutzer das Drucken von Dokumenten über das XPS‑Format. 

## **XPS‑Konvertierung mit Aspose.Slides**

In [**Aspose.Slides**](https://products.aspose.com/slides/net/) für .NET können Sie die [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index)‑Methode der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse verwenden, um die gesamte Präsentation in ein XPS‑Dokument zu konvertieren. 

Beim Konvertieren einer Präsentation nach XPS müssen Sie die Präsentation mit einer der folgenden Einstellungen speichern:

- Standardeinstellungen (ohne [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))
- Benutzerdefinierte Einstellungen (mit [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))

### **Präsentationen mit Standard‑Einstellungen in XPS konvertieren**

Dieser Beispielcode in C# zeigt, wie Sie eine Präsentation mit den Standard‑Einstellungen in ein XPS‑Dokument konvertieren:
```c#
 // Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
 using (Presentation pres = new Presentation("Convert_XPS.pptx"))
 {
     // Speichern der Präsentation als XPS-Dokument
     pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
 }
```


### **Präsentationen mit benutzerdefinierten Einstellungen in XPS konvertieren**
Dieser Beispielcode zeigt, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in C# in ein XPS‑Dokument konvertieren:
```c#
 // Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
 using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
 {
     // Instanziieren Sie die TiffOptions-Klasse
     XpsOptions options = new XpsOptions();

     // Metadateien als PNG speichern
     options.SaveMetafilesAsPng = true;

     // Präsentation als XPS-Dokument speichern
     pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
 }
```


## **FAQ**

**Kann ich XPS in einen Stream statt in eine Datei speichern?**

Ja—Aspose.Slides ermöglicht das direkte Exportieren in einen Stream, was ideal für Web‑APIs, serverseitige Pipelines oder jedes Szenario ist, bei dem Sie das XPS senden möchten, ohne das Dateisystem zu berühren.

**Werden versteckte Folien in XPS übernommen und kann ich sie ausschließen?**

Standardmäßig werden nur reguläre (sichtbare) Folien gerendert. Sie können [versteckte Folien ein‑ oder ausschließen](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/showhiddenslides/) über die [Export‑Einstellungen](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/) vor dem Speichern in XPS, sodass die Ausgabe genau die Seiten enthält, die Sie benötigen.