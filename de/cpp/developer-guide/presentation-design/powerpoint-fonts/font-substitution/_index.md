---
title: "Konfigurieren der Schriftart‑Ersetzung in Präsentationen in C++"
linktitle: "Schriftart‑Ersetzung"
type: docs
weight: 70
url: /de/cpp/font-substitution/
keywords:
- Schriftart
- Schriftart ersetzen
- Schriftart‑Ersetzung
- Schriftart ersetzen
- Schriftart‑Austausch
- Ersetzungsregel
- Austauschregel
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Konfigurieren Sie Schriftart‑Ersetzungsregeln und prüfen Sie ersetzte Schriftarten in Aspose.Slides für C++, wenn Sie PowerPoint‑ und OpenDocument‑Präsentationen rendern oder konvertieren."
---
## **Übersicht**

Die Schriftart-Ersetzung ermöglicht es Aspose.Slides, eine verfügbare Schriftart anstelle einer nicht zugänglichen Schriftart zu verwenden, wenn eine Präsentation gerendert oder konvertiert wird. Die Ersetzung wirkt sich nur auf die gerenderte Ausgabe aus; sie ändert nicht die der Präsentation zugewiesene Schriftart.

Sie können die zu verwendende Schriftart festlegen, wenn eine bestimmte Schriftart nicht verfügbar ist, und Sie können die Ersetzungen einsehen, die Aspose.Slides beim Rendern vornimmt. Das hilft, die Ausgabe in Umgebungen mit unterschiedlichen installierten Schriftarten konsistent zu halten.

## **Schriftart‑Ersetzungen abrufen**

Verwenden Sie die [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontsmanager/getsubstitutions/)‑Methode, um zu ermitteln, welche Schriftarten beim Rendern der Präsentation ersetzt werden. Die Methode liefert [FontSubstitutionInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsubstitutioninfo/)‑Objekte, die den Original‑ und den ersetzten Schriftartnamen enthalten.

Das folgende C++‑Beispiel listet alle Schriftart‑Ersetzungen für eine Präsentation auf:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

for (auto&& substitution : presentation->get_FontsManager()->GetSubstitutions())
{
    Console::WriteLine(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
}

presentation->Dispose();
```

## **Schriftart‑Ersetzungen für ausgewählte Folien abrufen**

Verwenden Sie die Überladung von [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontsmanager/getsubstitutions/) mit dem Argument `System::ArrayPtr<int32_t> slides`, um nur die Ersetzungen zu prüfen, die zum Rendern bestimmter Folien benötigt werden. Das ist nützlich, wenn Sie Teil einer Präsentation rendern oder exportieren, eine große Präsentation inkrementell prüfen, Folien finden möchten, die von nicht verfügbaren Schriftarten abhängen, ein minimales Schriftarten‑Paket für einen Server oder Container vorbereiten oder Rendering‑Unterschiede diagnostizieren wollen, ohne irrelevante Folien zu verarbeiten.

Das `slides`‑Array enthält ein‑basierte Folien‑Indizes: `1` bezeichnet die erste Folie. Im Gegensatz dazu verwendet die [Presentation::get_Slide](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_slide/)‑Methode einen nullbasierten Index, sodass dieselbe Folie über `presentation->get_Slide(0)` aufgerufen wird. Berücksichtigen Sie diesen Unterschied beim Aufbau des Arrays, um Off‑by‑One‑Fehler zu vermeiden.

Rufen Sie die Überladung über die [Presentation::get_FontsManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_fontsmanager/)‑Methode auf. Sie liefert nur die Ersetzungen, die beim Rendern der ausgewählten Folien ermittelt wurden. Jeder Rückgabewert ist ein [FontSubstitutionInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsubstitutioninfo/)‑Objekt, das den Original‑ und den ersetzten Schriftartnamen enthält. Das Ergebnis spiegelt die aktuelle Schriftumgebung, konfigurierte Fallback‑Regeln, Ersetzungsregeln, die in einer [IFontSubstRuleCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontsubstrulecollection/) gespeichert sind, sowie [extern geladene Schriftarten](/slides/de/cpp/custom-font/) wider.

Die gleiche Ersetzung kann von mehr als einer ausgewählten Folie benötigt werden. Deduplizieren Sie die Ergebnisse, wenn Sie ein Schriftarten‑Inventar oder einen Preflight‑Report erstellen. Das folgende Beispiel gibt jede zurückgegebene Ersetzung aus und erstellt anschließend eine sortierte Liste eindeutiger Schriftzuordnungen:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

auto selectedSlides = MakeArray<int32_t>({1, 3, 5});
auto substitutions = presentation->get_FontsManager()->GetSubstitutions(selectedSlides);
auto sortedPreflightEntries = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

Console::WriteLine(u"Substitutions for the selected slides:");
for (auto&& substitution : substitutions)
{
    auto entry = String::Format(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
    Console::WriteLine(entry);
    sortedPreflightEntries->Add(entry);
}

Console::WriteLine(u"Deduplicated font preflight report:");
for (auto&& entry : sortedPreflightEntries)
{
    Console::WriteLine(entry);
}

presentation->Dispose();
```

Die Schnittstelle [IFontsManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontsmanager/) bietet beide Überladungen. Wählen Sie diejenige, die dem Umfang des Rendering‑Vorgangs entspricht:

| Überladung | Verwenden, wenn |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontsmanager/getsubstitutions/) ohne Argumente | Sie Ersetzungen für die gesamte Präsentation benötigen. |
| [GetSubstitutions](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontsmanager/getsubstitutions/) mit `System::ArrayPtr<int32_t> slides` | Sie Ersetzungen für einen ausgewählten Bereich, eine inkrementelle Prüfung oder einen Teil‑Export benötigen. |

## **Schriftart‑Ersetzungsregeln festlegen**

Um anzugeben, welche Schriftart Aspose.Slides verwenden soll, wenn eine Quellschriftart nicht verfügbar ist:

1. Laden Sie die Präsentation.
2. Erzeugen Sie Schriftart‑Definitionen für die Quell‑ und Ersatzschriftart.
3. Erstellen Sie ein [FontSubstRule](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsubstrule/) mit der Bedingung [WhenInaccessible](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsubstcondition/).
4. Fügen Sie die Regel einer [FontSubstRuleCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsubstrulecollection/) hinzu.
5. Weisen Sie die Sammlung über die Methode [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/) zu.
6. Rendern oder konvertieren Sie die Präsentation.

Das folgende C++‑Beispiel ersetzt `Arial` durch `SomeRareFont`, wenn `SomeRareFont` nicht verfügbar ist, und rendert anschließend die erste Folie, um das Ergebnis zu prüfen. Die Ersatzschriftart muss für Aspose.Slides verfügbar sein.

```cpp
#include <DOM/FontSubstCondition.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/Fonts/FontSubstRule.h>
#include <DOM/Fonts/FontSubstRuleCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");

auto sourceFont = MakeObject<FontData>(u"SomeRareFont");
auto substituteFont = MakeObject<FontData>(u"Arial");
auto substitutionRule = MakeObject<FontSubstRule>(sourceFont, substituteFont, FontSubstCondition::WhenInaccessible);

auto substitutionRules = MakeObject<FontSubstRuleCollection>();
substitutionRules->Add(substitutionRule);
presentation->get_FontsManager()->set_FontSubstRuleList(substitutionRules);

auto image = presentation->get_Slide(0)->GetImage(1.0f, 1.0f);
image->Save(u"slide.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

{{% alert color="info" title="Hinweis" %}}
Für eine bedingungslose Änderung der in einer Präsentation verwendeten Schriftarten siehe [Font Replacement](/slides/de/cpp/font-replacement/).
{{% /alert %}}

## **Einschränkungen für mathematische Formelschriftarten**

Schriftart‑Ersetzungsregeln sind Teil des regulären Schriftart‑Auswahlprozesses, der beim Rendering und bei der Konvertierung verwendet wird. Sie funktionieren für normalen Text, wenn Aspose.Slides eine nicht zugängliche Schriftart durch die in einer Regel angegebene verfügbare Schriftart ersetzen kann.

Office‑Math‑Gleichungen haben eine zusätzliche Anforderung. Wenn eine Gleichung **Cambria Math** verwendet, muss Aspose.Slides exakt diese Schriftart zur Berechnung und zum Rendering des Gleichungs‑Layouts zur Verfügung stehen. Eine Regel, die eine andere mathematische Schriftart, wie **STIX Two Math**, ersetzt, kann **Cambria Math** dafür nicht ersetzen, und das Rendering meldet möglicherweise weiterhin, dass **Cambria Math** erforderlich ist.

Um eine solche Präsentation zu rendern oder zu konvertieren, stellen Sie **Cambria Math** Aspose.Slides bereit. Installieren Sie sie im Betriebssystem oder laden Sie sie als [externe Schriftart](/slides/de/cpp/custom-font/) geladen.

Diese Einschränkung gilt nur für das Gleichungs‑Layout. Die oben beschriebenen Ersetzungsregeln gelten weiterhin für normalen Präsentationstext.

## **FAQ**

**Worin besteht der Unterschied zwischen Font Replacement und Font Substitution?**

[Font replacement](/slides/de/cpp/font-replacement/) ändert bewusst eine Schriftart überall in der Präsentation zu einer anderen. Font substitution wählt eine Schriftart für die gerenderte Ausgabe, wenn die konfigurierte Bedingung erfüllt ist, z. B. wenn die Originalschriftart nicht verfügbar ist.

**Wann werden Ersetzungsregeln angewendet?**

Die Regeln nehmen am [font selection sequence](/slides/de/cpp/font-selection-sequence/) während Rendering und Konvertierung teil. Bei `WhenInaccessible` wird eine Regel nur verwendet, wenn Aspose.Slides nicht auf die Quellschriftart zugreifen kann.

**Was passiert, wenn eine Schriftart fehlt und keine Ersetzungsregel konfiguriert ist?**

Aspose.Slides wählt die am nächsten liegende verfügbare Schriftart gemäß seinem Schriftart‑Auswahlprozess. Das Ergebnis hängt von den im Laufzeit‑Umfeld verfügbaren Schriftarten ab.

**Kann ich externe Schriftarten laden, um Ersetzungen zu vermeiden?**

Ja. Sie können [externe Schriftarten laden](/slides/de/cpp/custom-font/), damit Aspose.Slides sie beim Rendering und bei der Konvertierung verwenden kann.

**Liefert Aspose die Schriftarten mit der Bibliothek aus?**

Nein. Sie sind dafür verantwortlich, die Schriftarten bereitzustellen und deren Lizenzbedingungen einzuhalten.

**Können sich Ersetzungsergebnisse zwischen Windows, Linux und macOS unterscheiden?**

Ja. Installierte Schriftarten und Suchpfade für Schriftarten unterscheiden sich je nach Betriebssystem, sodass eine Schriftart, die auf einem Rechner verfügbar ist, auf einem anderen ersetzt werden muss.

**Wie kann ich die Schriftartauswahl bei Stapelkonvertierungen konsistent halten?**

Verwenden Sie dieselben Schriftdateien und -versionen auf jedem Rechner oder Container, [laden Sie erforderliche externe Schriftarten](/slides/de/cpp/custom-font/) und [betten Sie Schriftarten ein](/slides/de/cpp/embedded-font/), sofern die Lizenz dies zulässt. Sie können außerdem vor dem Export [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontsmanager/getsubstitutions/) aufrufen, um unerwartete Ersetzungen zu erkennen.