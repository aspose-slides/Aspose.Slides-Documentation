---
title: PowerPoint-Präsentationen in C++ in XPS konvertieren
linktitle: PowerPoint zu XPS
type: docs
weight: 70
url: /de/cpp/convert-powerpoint-to-xps
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
- C++
- Aspose.Slides
description: "PowerPoint PPT/PPTX in hochwertiges, plattformunabhängiges XPS in C++ mit Aspose.Slides konvertieren. Schritt-für-Schritt-Anleitung und Beispielcode erhalten."
---

## **Über XPS**
Microsoft entwickelte [XPS](https://docs.fileformat.com/page-description-language/xps/) als Alternative zu [PDF](https://docs.fileformat.com/pdf/). Es ermöglicht das Drucken von Inhalten, indem eine Datei erzeugt wird, die einer PDF sehr ähnlich ist. Das XPS‑Format basiert auf XML. Das Layout oder die Struktur einer XPS‑Datei bleibt auf allen Betriebssystemen und Druckern gleich. 

## **Wann das Microsoft XPS‑Format verwenden**

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PPT‑ oder PPTX‑Präsentationen in das XPS‑Format konvertiert, können Sie sich die [kostenlose Online‑Konverter‑App](https://products.aspose.app/slides/conversion) ansehen. 

{{% /alert %}} 

Wenn Sie die Speicherkosten senken möchten, können Sie Ihre Microsoft PowerPoint‑Präsentation in das XPS‑Format konvertieren. So wird es einfacher, Ihre Dokumente zu speichern, zu teilen und zu drucken. 

Microsoft unterstützt XPS weiterhin stark in Windows (auch in Windows 10), sodass Sie in Erwägung ziehen sollten, Dateien in diesem Format zu speichern. Wenn Sie Windows 8.1, Windows 8, Windows 7 und Windows Vista verwenden, könnte XPS tatsächlich Ihre beste Option für bestimmte Vorgänge sein. 

- **Windows 8** verwendet das OXPS (Open XPS)‑Format für XPS‑Dateien. OXPS ist eine standardisierte Version des ursprünglichen XPS‑Formats. Windows 8 bietet besseren Support für XPS‑Dateien als für PDF‑Dateien. 
  - **XPS:** Integrierter XPS‑Betrachter/Reader und Druck‑zu‑XPS‑Funktion verfügbar. 
  - **PDF:** PDF‑Reader verfügbar, aber keine Druck‑zu‑PDF‑Funktion. 

- **Windows 7 und Windows Vista** verwenden das ursprüngliche XPS‑Format. Diese Betriebssysteme bieten ebenfalls besseren Support für XPS‑Dateien als für PDFs. 
  - **XPS:** Integrierter XPS‑Betrachter und Druck‑zu‑XPS‑Funktion verfügbar. 
  - **PDF:** Kein PDF‑Reader. Keine Druck‑zu‑PDF‑Funktion. 

|<p>**Eingabe PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Ausgabe XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft hat schließlich die Unterstützung für Druckvorgänge in PDF über die Funktion “Print to PDF” in Windows 10 implementiert. Zuvor wurde von den Benutzern erwartet, Dokumente über das XPS‑Format zu drucken. 

## **XPS‑Konvertierung mit Aspose.Slides**

In [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) für C++ können Sie die [**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e)-Methode der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) verwenden, um die gesamte Präsentation in ein XPS‑Dokument zu konvertieren. 

Beim Konvertieren einer Präsentation zu XPS müssen Sie die Präsentation mit einer der folgenden Einstellungen speichern:

- Standardeinstellungen (ohne [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))
- Benutzerdefinierte Einstellungen (mit [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))

### **Präsentationen mit Standardeinstellungen in XPS konvertieren**

Dieser Beispielcode in C++ zeigt, wie Sie eine Präsentation mit den Standard­einstellungen in ein XPS‑Dokument konvertieren:
``` cpp
// Instanziiere ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Speichere die Präsentation als XPS-Dokument
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```



### **Präsentationen mit benutzerdefinierten Einstellungen in XPS konvertieren**
Dieser Beispielcode zeigt, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in C++ in ein XPS‑Dokument konvertieren:
``` cpp
// Instanziiere ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Instanziiere die TiffOptions-Klasse
auto options = System::MakeObject<XpsOptions>();

// Speichere MetaFiles als PNG
options->set_SaveMetafilesAsPng(true);

// Speichere die Präsentation als XPS-Dokument
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```


## **FAQ**

**Kann ich XPS in einen Stream statt in eine Datei speichern?**

Ja—Aspose.Slides ermöglicht den direkten Export in einen Stream, was ideal für Web‑APIs, serverseitige Pipelines oder jedes Szenario ist, in dem Sie das XPS senden möchten, ohne das Dateisystem zu berühren.

**Werden versteckte Folien in XPS übernommen und kann ich sie ausschließen?**

Standardmäßig werden nur reguläre (sichtbare) Folien gerendert. Sie können über [Export‑Einstellungen](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/) [versteckte Folien ein‑ oder ausschließen](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/), bevor Sie nach XPS speichern, sodass die Ausgabe genau die Seiten enthält, die Sie beabsichtigen.