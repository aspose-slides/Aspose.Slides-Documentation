---
title: PowerPoint in XPS konvertieren
type: docs
weight: 70
url: /de/net/convert-powerpoint-to-xps
keywords: "PowerPoint-Präsentation konvertieren, PowerPoint zu XPS, PPT zu XPS, PPTX zu XPS, Konvertierung, C#, Csharp, .NET, Aspose.Slides"
description: "PowerPoint-Präsentation in XPS in C# oder .NET konvertieren."
---

## **Über XPS**
Microsoft hat [XPS](https://docs.fileformat.com/page-description-language/xps/) als Alternative zu [PDF](https://docs.fileformat.com/pdf/) entwickelt. Es ermöglicht das Drucken von Inhalten, indem eine Datei erzeugt wird, die einer PDF sehr ähnlich ist. Das XPS‑Format basiert auf XML. Das Layout bzw. die Struktur einer XPS‑Datei bleibt auf allen Betriebssystemen und Druckern gleich.

## **Wann das Microsoft XPS‑Format verwenden**

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PPT‑ oder PPTX‑Präsentationen in das XPS‑Format konvertiert, können Sie die [kostenlose Online‑Konverter‑App](https://products.aspose.app/slides/conversion) ausprobieren. 

{{% /alert %}} 

Wenn Sie Speicher‑Kosten senken möchten, können Sie Ihre Microsoft PowerPoint‑Präsentation in das XPS‑Format konvertieren. So lässt sich das Dokument leichter speichern, teilen und drucken.

Microsoft setzt die starke Unterstützung für XPS in Windows (auch in Windows 10) fort, sodass Sie das Speichern im XPS‑Format in Betracht ziehen sollten. Wenn Sie Windows 8.1, Windows 8, Windows 7 oder Windows Vista verwenden, könnte XPS für bestimmte Vorgänge tatsächlich Ihre beste Option sein.

- **Windows 8** verwendet das OXPS‑(Open XPS) Format für XPS‑Dateien. OXPS ist eine standardisierte Version des ursprünglichen XPS‑Formats. Windows 8 bietet besseren Support für XPS‑Dateien als für PDF‑Dateien.  
  - **XPS:** Integrierter XPS‑Viewer/Reader und Druck‑zu‑XPS‑Funktion verfügbar.  
  - **PDF:** PDF‑Reader verfügbar, aber keine Druck‑zu‑PDF‑Funktion.  

- **Windows 7 und Windows Vista** verwenden das ursprüngliche XPS‑Format. Diese Betriebssysteme bieten ebenfalls besseren Support für XPS‑Dateien als für PDFs.  
  - **XPS:** Integrierter XPS‑Viewer und Druck‑zu‑XPS‑Funktion verfügbar.  
  - **PDF:** Kein PDF‑Reader. Keine Druck‑zu‑PDF‑Funktion.  

|<p>**Eingabe PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Ausgabe XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft hat schließlich die Unterstützung für Druckvorgänge in PDF über die Funktion „Drucken nach PDF“ in Windows 10 implementiert. Zuvor mussten Benutzer Dokumente über das XPS‑Format drucken.

## **XPS‑Konvertierung mit Aspose.Slides**

In [**Aspose.Slides**](https://products.aspose.com/slides/net/) für .NET können Sie die [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index)‑Methode der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse verwenden, um die gesamte Präsentation in ein XPS‑Dokument zu konvertieren.

Beim Konvertieren einer Präsentation in XPS müssen Sie die Präsentation mit einer dieser Einstellungen speichern:

- Standard‑Einstellungen (ohne [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))
- Benutzerdefinierte Einstellungen (mit [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))

### **Präsentationen mit Standard‑Einstellungen nach XPS konvertieren**

Dieser C#‑Beispielcode zeigt, wie Sie eine Präsentation mit den Standard‑Einstellungen in ein XPS‑Dokument konvertieren:
```c#
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Speichern der Präsentation als XPS-Dokument
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```



### **Präsentationen mit benutzerdefinierten Einstellungen nach XPS konvertieren**
Dieser Beispielcode zeigt, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in C# in ein XPS‑Dokument konvertieren:
```c#
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Instanziieren Sie die TiffOptions-Klasse
    XpsOptions options = new XpsOptions();

    // Speichern Sie MetaFiles als PNG
    options.SaveMetafilesAsPng = true;

    // Speichern Sie die Präsentation als XPS-Dokument
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```


## **FAQ**

**Kann ich in einen Stream statt in eine Datei speichern?**

Ja – Aspose.Slides ermöglicht das direkte Exportieren in einen Stream, was ideal für Web‑APIs, serverseitige Pipelines oder jede Situation ist, in der Sie das XPS ausgeben wollen, ohne das Dateisystem zu berühren.

**Werden versteckte Folien ins XPS übernommen und kann ich sie ausschließen?**

Standardmäßig werden nur reguläre (sichtbare) Folien gerendert. Sie können über die [Export‑Einstellungen](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/) [verdeckte Folien ein‑ oder ausschließen](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/showhiddenslides/), bevor Sie nach XPS speichern, sodass die Ausgabe genau die Seiten enthält, die Sie benötigen.