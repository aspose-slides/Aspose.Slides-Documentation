---
title: PowerPoint-Präsentationen in XPS konvertieren in C++
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
description: "PowerPoint PPT/PPTX in hochwertiges, plattformunabhängiges XPS in C++ mit Aspose.Slides konvertieren. Erhalten Sie eine Schritt-für-Schritt-Anleitung und Beispielcode."
---
## **Übersicht**

Aspose.Slides ermöglicht das Konvertieren von PowerPoint‑Präsentationen in XPS, indem Sie eine PPT‑ oder PPTX‑Datei im XPS‑Format speichern. Dieser Artikel erklärt, wann das XPS‑Format nützlich sein kann, und zeigt, wie die Konvertierung mit Aspose.Slides mithilfe der Standard‑Einstellungen oder benutzerdefinierter [XpsOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/xpsoptions/) Einstellungen durchgeführt wird.

## **Über XPS**
Microsoft hat [XPS](https://docs.fileformat.com/page-description-language/xps/) als Alternative zu [PDF](https://docs.fileformat.com/pdf/) entwickelt. Es ermöglicht das Drucken von Inhalten, indem eine Datei ausgegeben wird, die einer PDF sehr ähnlich ist. Das XPS‑Format basiert auf XML. Das Layout oder die Struktur einer XPS‑Datei bleibt auf allen Betriebssystemen und Druckern gleich. 

## **Wann das Microsoft XPS‑Format verwenden**

{{% alert color="info" %}} 

Um zu sehen, wie Aspose.Slides PPT‑ oder PPTX‑Präsentationen in das XPS‑Format konvertiert, können Sie [diese kostenlose Online‑Konverter‑App](https://products.aspose.app/slides/de/conversion) ausprobieren. 

{{% /alert %}} 

Wenn Sie die Speicherkosten senken möchten, können Sie Ihre Microsoft PowerPoint‑Präsentation in das XPS‑Format konvertieren. Auf diese Weise wird das Speichern, Teilen und Drucken Ihrer Dokumente einfacher. 

Microsoft erweitert weiterhin die starke Unterstützung für XPS in Windows (auch in Windows 10), sodass Sie in Erwägung ziehen sollten, Dateien in diesem Format zu speichern. Wenn Sie mit Windows 8.1, Windows 8, Windows 7 und Windows Vista arbeiten, könnte XPS tatsächlich Ihre beste Option für bestimmte Vorgänge sein. 

- **Windows 8** verwendet das OXPS (Open XPS)‑Format für XPS‑Dateien. OXPS ist eine standardisierte Version des ursprünglichen XPS‑Formats. Windows 8 bietet bessere Unterstützung für XPS‑Dateien als für PDF‑Dateien. 
  - **XPS:** Integrierter XPS‑Betrachter/Reader und Druck‑nach‑XPS‑Funktion verfügbar. 
  - **PDF:** PDF‑Reader verfügbar, aber keine Druck‑nach‑PDF‑Funktion. 

- **Windows 7 und Windows Vista** verwenden das ursprüngliche XPS‑Format. Diese Betriebssysteme bieten ebenfalls bessere Unterstützung für XPS‑Dateien als für PDFs. 
  - **XPS:** Integrierter XPS‑Betrachter und Druck‑nach‑XPS‑Funktion verfügbar. 
  - **PDF:** Kein PDF‑Reader. Keine Druck‑nach‑PDF‑Funktion. 

|<p>**Eingabe PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Ausgabe XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft hat schließlich die Unterstützung für Druckvorgänge in PDF über die Funktion „Print to PDF“ in Windows 10 implementiert. Zuvor wurden Benutzer aufgefordert, Dokumente über das XPS‑Format zu drucken. 

## **XPS-Konvertierung mit Aspose.Slides**

In [**Aspose.Slides**](https://products.aspose.com/slides/de/cpp/) für C++ können Sie die [**Save**](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e)‑Methode der [Presentation](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation)‑Klasse verwenden, um die gesamte Präsentation in ein XPS‑Dokument zu konvertieren. 

Beim Konvertieren einer Präsentation in XPS müssen Sie die Präsentation mit einer der folgenden Einstellungen speichern:

- Standard‑Einstellungen (ohne [**XPSOptions**](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.export.xps_options))
- Benutzerdefinierte Einstellungen (mit [**XPSOptions**](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.export.xps_options))

### **Präsentationen mit Standardeinstellungen in XPS konvertieren**

Dieser Beispielcode in C++ zeigt, wie Sie eine Präsentation mit den Standard‑Einstellungen in ein XPS‑Dokument konvertieren:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Instantiate a Presentation object that represents a presentation file
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Saving the presentation to XPS document
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **Präsentationen mit benutzerdefinierten Einstellungen in XPS konvertieren**
Dieser Beispielcode zeigt, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in C++ in ein XPS‑Dokument konvertieren:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Export/XpsOptions.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Instanziiere ein Presentation-Objekt, das eine Präsentationsdatei darstellt
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Instanziiere die TiffOptions-Klasse
auto options = System::MakeObject<XpsOptions>();

// MetaFiles als PNG speichern
options->set_SaveMetafilesAsPng(true);

// Die Präsentation als XPS-Dokument speichern
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **FAQ**

### Kann ich XPS in einen Stream anstelle einer Datei speichern?

Ja—Aspose.Slides lässt Sie direkt in einen Stream exportieren, was ideal für Web‑APIs, serverseitige Pipelines oder jedes Szenario ist, in dem Sie das XPS senden möchten, ohne das Dateisystem zu berühren.

### Werden versteckte Folien in XPS übernommen, und kann ich sie ausschließen?

Standardmäßig werden nur reguläre (sichtbare) Folien gerendert. Sie können [versteckte Folien ein‑ oder ausschließen](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) über die [Export‑Einstellungen](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/xpsoptions/) vor dem Speichern nach XPS festlegen, sodass die Ausgabe genau die Seiten enthält, die Sie beabsichtigen.