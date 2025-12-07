---
title: PowerPoint-Präsentationen nach XPS in C++ konvertieren
linktitle: PowerPoint nach XPS
type: docs
weight: 70
url: /de/cpp/convert-powerpoint-to-xps
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint nach XPS
- Präsentation nach XPS
- Folie nach XPS
- PPT nach XPS
- PPTX nach XPS
- PPT als XPS speichern
- PPTX als XPS speichern
- PPT nach XPS exportieren
- PPTX nach XPS exportieren
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "PowerPoint PPT/PPTX in hochwertigen, plattformunabhängigen XPS in C++ mit Aspose.Slides konvertieren. Erhalten Sie eine schrittweise Anleitung und Beispielcode."
---

## **Über XPS**
Microsoft entwickelte [XPS](https://docs.fileformat.com/page-description-language/xps/) als Alternative zu [PDF](https://docs.fileformat.com/pdf/). Es ermöglicht Ihnen, Inhalte zu drucken, indem Sie eine Datei ausgeben, die einer PDF sehr ähnlich ist. Das XPS-Format basiert auf XML. Das Layout oder die Struktur einer XPS-Datei bleibt auf allen Betriebssystemen und Druckern gleich. 

## **Wann das Microsoft XPS-Format verwenden**

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PPT‑ oder PPTX‑Präsentationen in das XPS‑Format konvertiert, können Sie sich die [kostenlose Online‑Konverter‑App](https://products.aspose.app/slides/conversion) anschauen. 

{{% /alert %}} 

Wenn Sie die Speicherkosten senken möchten, können Sie Ihre Microsoft PowerPoint‑Präsentation in das XPS‑Format konvertieren. Auf diese Weise wird es einfacher, Ihre Dokumente zu speichern, zu teilen und zu drucken. 

Microsoft erweitert weiterhin die umfassende Unterstützung für XPS in Windows (auch in Windows 10), sodass Sie in Erwägung ziehen sollten, Dateien in diesem Format zu speichern. Wenn Sie mit Windows 8.1, Windows 8, Windows 7 und Windows Vista arbeiten, könnte XPS tatsächlich Ihre beste Option für bestimmte Vorgänge sein. 

- **Windows 8** verwendet das OXPS (Open XPS)‑Format für XPS‑Dateien. OXPS ist eine standardisierte Version des ursprünglichen XPS‑Formats. Windows 8 bietet bessere Unterstützung für XPS‑Dateien als für PDF‑Dateien. 
  - **XPS:** Eingebauter XPS‑Betrachter/‑Reader und Druck‑zu‑XPS‑Funktion verfügbar. 
  - **PDF:** PDF‑Reader verfügbar, aber keine Druck‑zu‑PDF‑Funktion. 

- **Windows 7 und Windows Vista** verwenden das ursprüngliche XPS‑Format. Diese Betriebssysteme bieten ebenfalls bessere Unterstützung für XPS‑Dateien als für PDFs. 
  - **XPS:** Eingebauter XPS‑Betrachter und Druck‑zu‑XPS‑Funktion verfügbar. 
  - **PDF:** Kein PDF‑Reader. Keine Druck‑zu‑PDF‑Funktion. 

|<p>**Eingabe PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Ausgabe XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft hat schließlich die Unterstützung für Druckvorgänge in PDF durch die Funktion „Print to PDF“ in Windows 10 implementiert. Zuvor wurde von den Benutzern erwartet, Dokumente über das XPS‑Format zu drucken. 

## **XPS‑Konvertierung mit Aspose.Slides**

In [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) für C++ können Sie die [**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e)‑Methode verwenden, die von der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse bereitgestellt wird, um die gesamte Präsentation in ein XPS‑Dokument zu konvertieren. 

Beim Konvertieren einer Präsentation in XPS müssen Sie die Präsentation mit einer dieser Einstellungen speichern:

- Standard‑Einstellungen (ohne [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))
- Benutzerdefinierte Einstellungen (mit [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))

### **Präsentationen mit Standard‑Einstellungen in XPS konvertieren**

Dieser Beispielcode in C++ zeigt, wie Sie eine Präsentation mit den Standard‑Einstellungen in ein XPS‑Dokument konvertieren:
``` cpp
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Speichern der Präsentation als XPS-Dokument
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **Präsentationen mit benutzerdefinierten Einstellungen in XPS konvertieren**
Dieser Beispielcode zeigt, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in C++ in ein XPS‑Dokument konvertieren:
``` cpp
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Instanziieren Sie die TiffOptions-Klasse
auto options = System::MakeObject<XpsOptions>();

// Metadateien als PNG speichern
options->set_SaveMetafilesAsPng(true);

// Speichern der Präsentation als XPS-Dokument
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```


## **FAQ**

**Kann ich XPS in einen Stream statt in eine Datei speichern?**

Ja—Aspose.Slides ermöglicht den direkten Export in einen Stream, was ideal für Web‑APIs, serverseitige Pipelines oder jedes Szenario ist, in dem Sie das XPS senden möchten, ohne das Dateisystem zu berühren.

**Werden versteckte Folien in XPS übernommen und kann ich sie ausschließen?**

Standardmäßig werden nur reguläre (sichtbare) Folien gerendert. Sie können [versteckte Folien ein‑ oder ausschließen](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) über die [Export‑Einstellungen](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/) vor dem Speichern in XPS, sodass die Ausgabe exakt die Seiten enthält, die Sie beabsichtigen.