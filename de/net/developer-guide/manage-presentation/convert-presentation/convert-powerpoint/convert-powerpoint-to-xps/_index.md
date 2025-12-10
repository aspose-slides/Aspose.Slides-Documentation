---
title: PowerPoint-Präsentationen in XPS in .NET konvertieren
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
description: "Konvertieren Sie PowerPoint PPT/PPTX in hochwertige, plattformunabhängige XPS-Dateien in .NET mit Aspose.Slides. Erhalten Sie eine Schritt-für-Schritt-Anleitung und Beispiel-C#-Code."
---

## **Über XPS**
Microsoft hat [XPS](https://docs.fileformat.com/page-description-language/xps/) als Alternative zu [PDF](https://docs.fileformat.com/pdf/) entwickelt. Es ermöglicht das Drucken von Inhalten, indem eine Datei erzeugt wird, die einem PDF sehr ähnlich ist. Das XPS‑Format basiert auf XML. Das Layout oder die Struktur einer XPS‑Datei bleibt auf allen Betriebssystemen und Druckern gleich. 

## **Wann das Microsoft XPS‑Format verwenden**

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PPT‑ oder PPTX‑Präsentationen in das XPS‑Format konvertiert, können Sie die [kostenlose Online‑Konverter‑App](https://products.aspose.app/slides/conversion) ausprobieren. 

{{% /alert %}} 

Wenn Sie Speicher­kosten senken möchten, können Sie Ihre Microsoft PowerPoint‑Präsentation in das XPS‑Format konvertieren. So lässt sich das Dokument einfacher speichern, teilen und drucken. 

Microsoft bietet weiterhin umfangreiche Unterstützung für XPS in Windows (auch in Windows 10), sodass Sie das Speichern in diesem Format in Betracht ziehen sollten. Wenn Sie Windows 8.1, Windows 8, Windows 7 oder Windows Vista verwenden, könnte XPS tatsächlich Ihre beste Wahl für bestimmte Vorgänge sein. 

- **Windows 8** verwendet das OXPS‑(Open XPS) Format für XPS‑Dateien. OXPS ist eine standardisierte Version des ursprünglichen XPS‑Formats. Windows 8 bietet bessere Unterstützung für XPS‑Dateien als für PDF‑Dateien. 
  - **XPS:** Integrierter XPS‑Viewer/Reader und Druck‑zu‑XPS‑Funktion verfügbar. 
  - **PDF:** PDF‑Reader vorhanden, aber keine Druck‑zu‑PDF‑Funktion. 

- **Windows 7 und Windows Vista** verwenden das originale XPS‑Format. Diese Betriebssysteme bieten ebenfalls bessere Unterstützung für XPS‑Dateien als für PDFs. 
  - **XPS:** Integrierter XPS‑Viewer und Druck‑zu‑XPS‑Funktion verfügbar. 
  - **PDF:** Kein PDF‑Reader. Keine Druck‑zu‑PDF‑Funktion. 

|<p>**Eingabe PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Ausgabe XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft hat später die Druck‑zu‑PDF‑Funktion in Windows 10 eingeführt. Zuvor mussten Benutzer Dokumente über das XPS‑Format drucken. 

## **XPS‑Konvertierung mit Aspose.Slides**

In [**Aspose.Slides**](https://products.aspose.com/slides/net/) für .NET können Sie die [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index)‑Methode der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse verwenden, um die gesamte Präsentation in ein XPS‑Dokument zu konvertieren. 

Beim Konvertieren einer Präsentation nach XPS müssen Sie die Präsentation mit einer der folgenden Einstellungen speichern:

- Standardeinstellungen (ohne [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))
- Benutzerdefinierte Einstellungen (mit [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))

### **Präsentationen mit Standardeinstellungen in XPS konvertieren**

Dieses C#‑Beispiel zeigt, wie Sie eine Präsentation mit den Standard‑Einstellungen in ein XPS‑Dokument konvertieren:
```c#
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Speichern der Präsentation als XPS-Dokument
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```



### **Präsentationen mit benutzerdefinierten Einstellungen in XPS konvertieren**
Dieses Beispiel zeigt, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in C# in ein XPS‑Dokument konvertieren:
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

Ja — Aspose.Slides ermöglicht das direkte Exportieren in einen Stream, was ideal für Web‑APIs, serverseitige Pipelines oder jedes Szenario ist, in dem Sie das XPS senden möchten, ohne das Dateisystem zu verwenden.

**Werden versteckte Folien in XPS übernommen und kann ich sie ausschließen?**

Standardmäßig werden nur reguläre (sichtbare) Folien gerendert. Sie können über die [Export‑Einstellungen](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/) festlegen, ob [versteckte Folien ein‑ oder ausgeschlossen werden sollen](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/showhiddenslides/), bevor Sie nach XPS speichern, sodass die Ausgabe exakt die Seiten enthält, die Sie benötigen.