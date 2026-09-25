---
title: Verwalten der Präsentationszugänglichkeit in C++
linktitle: Präsentationszugänglichkeit
type: docs
weight: 30
url: /de/cpp/presentation-accessibility/
keywords:
- Präsentationszugänglichkeit
- Alternativtext
- Alternativtext-Titel
- Alternativtext-Beschreibung
- Als dekorativ markieren
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Automatisieren Sie Prüfungen zur Barrierefreiheit von Präsentationen in PPT-, PPTX- und ODP-Dateien mit Aspose.Slides für C++ – verbessern Sie das Erlebnis für Screenreader und erhöhen Sie die Konformität."
---
## **Einleitung**

Alternativtext hilft Personen, die unterstützende Technologien verwenden, die Bedeutung von Bildern, Diagrammen und anderen informativen Formen zu verstehen. Dieser Artikel erklärt, wie man mit Aspose.Slides für C++ Alternativtext‑Titel und -Beschreibungen liest und aktualisiert, Zugänglichkeitsbeschreibungen von Formnamen im Code unterscheidet und prüft, ob eine Form als dekorativ markiert ist.

Diese Funktionen unterstützen die Barrierefreiheit von Präsentationen, garantieren sie jedoch nicht. Reihenfolge des Lesens, Farbkontrast, Lesbarkeit von Text und weitere Barrierefreiheitsanforderungen müssen ebenfalls überprüft werden.

## **Verwalten von Alternativtext‑Titeln und -Beschreibungen**

Verwenden Sie Alternativtext, um die Bedeutung von Bildern, Diagrammen und anderen informativen Formen Personen zu erklären, die sie nicht sehen können. Die folgenden Eigenschaften dienen unterschiedlichen Zwecken:

| Eigenschaft oder Inhalt | Zweck |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_alternativetexttitle/) | Ein kurzer Titel für die alternative Beschreibung. |
| [AlternativeText](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_alternativetext/) | Eine sinnvolle Beschreibung des Inhalts oder Zwecks der Form im Kontext der Folie. |
| [Name](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_name/) | Der Name der Form, den Code verwenden kann, um eine bestimmte Form in der Präsentation zu finden. |
| Sichtbarer Text | Auf der Folie angezeigter Inhalt, z. B. Text einer Form oder Titel und Beschriftungen eines Diagramms. Das Aktualisieren des Alternativtexts ändert diesen Inhalt nicht. |

Wenn eine Präsentation als Vorlage wiederverwendet wird, kann Code eine Form über ihren [Name](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_name/) finden, bevor sie aktualisiert wird. Dieser Name dient einem anderen Zweck als Alternativtext, der erklärt, was das Visuelle dem Leser vermittelt. Die Suche nach dem Namen ermöglicht es Autoren, Beschreibungen zu verbessern oder zu übersetzen, ohne die Art und Weise zu ändern, wie Code die Form findet. Namen können bearbeitet werden und sind nicht garantiert eindeutig, prüfen Sie also, ob der Name zur beabsichtigten Form passt; siehe [Identify and Find Shapes](/slides/de/cpp/shape-manipulations/#identify-and-find-shapes).

Das folgende Beispiel erfordert `input.pptx` mit einem Bild eines Büroeingangs als erste Form auf der ersten Folie. Das Bild sollte nicht als dekorativ markiert sein. Das Beispiel liest und gibt den aktuellen Alternativtext‑Titel und die Beschreibung aus, aktualisiert beide Werte und speichert die Präsentation als `output.pptx`. Passen Sie den Wortlaut an das tatsächliche Bild und die darin enthaltenen Informationen an.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

Console::WriteLine(u"Alternative text title: {0}", shape->get_AlternativeTextTitle());
Console::WriteLine(u"Alternative text description: {0}", shape->get_AlternativeText());

shape->set_AlternativeTextTitle(u"Office entrance");
shape->set_AlternativeText(u"The office entrance has a wheelchair ramp to the right of the steps.");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Allein das Hinzufügen von Alternativtext garantiert keine Barrierefreiheit der Präsentation oder die Einhaltung von Barrierefreiheitsstandards. Überprüfen Sie die Beschreibungen auf Genauigkeit und Relevanz und prüfen Sie zudem Reihenfolge des Lesens, Farbkontrast, lesbaren Text und weitere Barrierefreiheitsanforderungen. Informationsreiche Visualisierungen sollten nicht als dekorativ markiert werden; der nächste Abschnitt zeigt, wie man [IsDecorative](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_isdecorative/) ausliest.

## **Als dekorativ markieren**

Die Kennzeichnung als dekorativ weist rein ornamentale Visualisierungen so aus, dass Screenreader sie überspringen, wodurch Geräusche reduziert und der Fokus auf sinnvollen Inhalt gelegt wird. Wenden Sie sie auf Hintergründe, Verzierungen und Abstandshalter an – niemals auf Diagramme, Symbole oder Bilder, die Informationen vermitteln. Aspose.Slides stellt diese Kennzeichnung zur Erkennung und Validierung bereit, was automatisierte Barrierefreiheitsprüfungen und Bereinigungen ermöglicht.

![Als dekorativ markieren](mark_as_decorative.png)

Der folgende Code‑Beispiel zeigt, wie man ermittelt, ob eine Form als dekorativ markiert ist.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```

## **FAQ**

**Was soll ich in den Alternativtext‑Titel und die Beschreibung eintragen?**

Verwenden Sie einen kurzen Titel, um das Thema zu identifizieren, und eine Beschreibung, um die Informationen zu erklären, die das Visuelle im Kontext der Folie vermittelt. Beschreiben Sie bei einem Diagramm den relevanten Trend oder Vergleich, anstatt nur „Diagramm“ zu schreiben.

**Soll ich Alternativtext verwenden, um Formen in einer Vorlage zu finden?**

Bevorzugen Sie das Finden der Form über ihren [Name](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_name/) und prüfen Sie, ob es die erwartete Form ist. Alternativtext kann bearbeitet oder übersetzt werden, was Code, der nach einer genauen Beschreibung sucht, brechen kann; siehe [Identify and Find Shapes](/slides/de/cpp/shape-manipulations/).

**Wann sollte eine Form als dekorativ markiert werden?**

Verwenden Sie die dekorative Kennzeichnung für Visualisierungen, die keine Informationen hinzufügen, beispielsweise ornamentale Verzierungen. Bilder und Diagramme, die Bedeutungen vermitteln, benötigen stattdessen eine passende Beschreibung.

**Macht das Hinzufügen von Alternativtext eine Präsentation vollständig barrierefrei?**

Nein. Alternativtext adressiert nur einen Teil der Barrierefreiheit. Außerdem müssen Reihenfolge des Lesens, Farbkontrast, Lesbarkeit von Text und weitere anwendbare Anforderungen überprüft werden; das Setzen dieser Eigenschaften allein stellt keine Konformität sicher.