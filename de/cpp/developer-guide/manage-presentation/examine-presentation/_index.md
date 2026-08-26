---
title: Präsentationsinformationen abrufen und aktualisieren in C++
linktitle: Präsentationsinformationen
type: docs
weight: 30
url: /de/cpp/examine-presentation/
keywords:
- Präsentationsformat
- Präsentationseigenschaften
- Dokumenteigenschaften
- Eigenschaften abrufen
- Eigenschaften lesen
- Eigenschaften ändern
- Eigenschaften modifizieren
- Eigenschaften aktualisieren
- PPTX untersuchen
- PPT untersuchen
- ODP untersuchen
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Untersuchen Sie Folien, Struktur und Metadaten in PowerPoint- und OpenDocument-Präsentationen mit C++ für schnellere Einblicke und intelligentere Inhaltsprüfungen."
---
## **Übersicht**

Dieser Artikel zeigt, wie man Präsentationsinformationen in Aspose.Slides inspiziert. Er erklärt, wie man das aktuelle Format einer Präsentation ermittelt, ohne die gesamte Datei zu laden, ihre Dokumenteigenschaften liest und diese bei Bedarf aktualisiert.

Die Beispiele basieren auf den APIs [PresentationInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentationinfo/) und [DocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/documentproperties/) und demonstrieren typische Vorgänge zum Arbeiten mit Präsentationsmetadaten.

## **Prüfen des Präsentationsformats**

Bevor Sie an einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP usw.) die Präsentation derzeit vorliegt.

Sie können das Format einer Präsentation prüfen, ohne die Präsentation zu laden. Siehe diesen C++‑Code:

``` cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **Abrufen von Präsentationseigenschaften**

Dieser C++‑Code zeigt, wie man Präsentationseigenschaften (Informationen über die Präsentation) abruft:

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```

## **Aktualisieren von Präsentationseigenschaften**

Aspose.Slides stellt die Methode [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) bereit, mit der Sie Änderungen an Präsentationseigenschaften vornehmen können.

Angenommen, wir haben eine PowerPoint‑Präsentation mit den unten gezeigten Dokumenteigenschaften.

![Ursprüngliche Dokumenteigenschaften der PowerPoint‑Präsentation](input_properties.png)

Dieses Codebeispiel zeigt, wie man einige Präsentationseigenschaften bearbeitet:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
using namespace Aspose::Slides;
using namespace System;

auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

Die Ergebnisse der Änderung der Dokumenteigenschaften werden unten angezeigt.

![Geänderte Dokumenteigenschaften der PowerPoint‑Präsentation](output_properties.png)

## **Nützliche Links**

Um weitere Informationen zu einer Präsentation und ihren Sicherheitsattributen zu erhalten, können diese Links nützlich sein:

- [Passwortgeschützte Präsentationen](/slides/de/cpp/password-protected-presentation/)
- [Schreibgeschützte Präsentationen](/slides/de/cpp/write-protected-presentation/)

## **FAQ**

**Wie kann ich prüfen, ob Schriftarten eingebettet sind und welche das sind?**

Suchen Sie nach [Informationen zu eingebetteten Schriftarten](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsmanager/getembeddedfonts/) auf Präsentationsebene und vergleichen Sie diese Einträge mit der Menge der [tatsächlich im Inhalt verwendeten Schriftarten](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsmanager/getfonts/), um zu ermitteln, welche Schriftarten für die Darstellung kritisch sind.

**Wie kann ich schnell erkennen, ob die Datei versteckte Folien enthält und wie viele?**

Durchlaufen Sie die [Folien‑Sammlung](https://reference.aspose.com/slides/de/cpp/aspose.slides/slidecollection/) und prüfen Sie das [Sichtbarkeits‑Flag jeder Folie](https://reference.aspose.com/slides/de/cpp/aspose.slides/slide/get_hidden/).

**Kann ich feststellen, ob benutzerdefinierte Foliengröße und -ausrichtung verwendet werden und ob sie von den Vorgaben abweichen?**

Ja. Vergleichen Sie die aktuelle [Foliengröße und -ausrichtung](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_slidesize/) mit den Standard‑Presets; das hilft, das Verhalten beim Drucken und Exportieren vorherzusehen.

**Gibt es eine schnelle Möglichkeit zu sehen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Durchlaufen Sie alle [Diagramme](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/chart/), prüfen Sie deren [Datenquelle](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) und stellen Sie fest, ob die Daten intern oder verlinkt sind, einschließlich eventueller defekter Links.

**Wie kann ich „schwere“ Folien beurteilen, die das Rendern oder den PDF‑Export verlangsamen könnten?**

Zählen Sie für jede Folie die Objektanzahl und achten Sie auf große Bilder, Transparenzen, Schatten, Animationen und Multimedia; vergeben Sie eine grobe Komplexitätsbewertung, um potenzielle Leistungsengpässe zu kennzeichnen.