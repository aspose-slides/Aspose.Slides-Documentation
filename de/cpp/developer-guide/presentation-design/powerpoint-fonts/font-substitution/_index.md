---
title: Schriftart-Substitution in Präsentationen in C++
linktitle: Schriftart-Substitution
type: docs
weight: 70
url: /de/cpp/font-substitution/
keywords:
- Schriftart
- ersetzende Schriftart
- Schriftart-Substitution
- Schriftart ersetzen
- Schriftart-Ersetzung
- Substitutionsregel
- Ersetzungsregel
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Konfigurieren Sie Schriftart-Substitutionsregeln und prüfen Sie substituierte Schriftarten in Aspose.Slides für C++ beim Rendern oder Konvertieren von PowerPoint- und OpenDocument-Präsentationen."
---
## **Überblick**

Font substitution ermöglicht es Aspose.Slides, eine verfügbare Schriftart anstelle einer nicht zugänglichen Schriftart zu verwenden, wenn eine Präsentation gerendert oder konvertiert wird. Die Substitution wirkt sich auf die gerenderte Ausgabe aus; sie ändert nicht die der Präsentationsinhalte zugewiesene Schriftart.

Sie können die Schriftart festlegen, die verwendet werden soll, wenn eine bestimmte Schriftart nicht verfügbar ist, und Sie können die Substitutionen einsehen, die Aspose.Slides während des Renderns vornehmen wird. Dies hilft, die Ausgabe über Umgebungen mit unterschiedlichen installierten Schriftarten hinweg konsistent zu halten.

Wenn eine Schriftart verfügbar ist, aber keinen dedizierten Fettschriftstil besitzt, siehe [Handle Fonts Without a Dedicated Bold Typeface](/slides/de/cpp/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Dieser Abschnitt erklärt, wie der betroffene Text beim PDF‑Export gerastert wird und welche Folgen das für Textauswahl, Suche und Skalierung hat.

## **Schriftart-Substitutionen abrufen**

Verwenden Sie die [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/)‑Methode, um zu bestimmen, welche Schriftarten bei der Wiedergabe der Präsentation substituiert werden. Die Methode gibt [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/)‑Objekte zurück, die den ursprünglichen und den ersetzten Schriftartnamen angeben.

Das folgende C++‑Beispiel listet alle Schriftart‑Substitutionen für eine Präsentation auf:

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

## **Schriftart-Substitutionen für ausgewählte Folien abrufen**

Verwenden Sie die [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/)‑Überladung mit einem `System::ArrayPtr<int32_t> slides`‑Argument, um nur die Substitutionen zu inspizieren, die zum Rendern bestimmter Folien erforderlich sind. Dies ist nützlich, wenn Sie einen Teil einer Präsentation rendern oder exportieren, eine große Präsentation inkrementell prüfen, Folien finden, die von nicht verfügbaren Schriftarten abhängen, ein minimales Schriftartpaket für einen Server oder Container vorbereiten oder Rendering‑Unterschiede diagnostizieren möchten, ohne nicht betroffene Folien zu verarbeiten.

Das `slides`‑Array enthält ein‑basiert indizierte Folien: `1` identifiziert die erste Folie. Im Gegensatz dazu verwendet die [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/)‑Methode einen nullbasierten Index, sodass dieselbe Folie mit `presentation->get_Slide(0)` zugänglich ist. Beachten Sie diesen Unterschied beim Erstellen des Arrays, um Off‑by‑One‑Fehler zu vermeiden.

Rufen Sie die Überladung über die [Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/)‑Methode auf. Sie gibt nur die Substitutionen zurück, die beim Rendern der ausgewählten Folien bestimmt wurden. Jedes Ergebnis ist ein [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/)‑Objekt, das den ursprünglichen und den ersetzten Schriftartnamen enthält. Das Ergebnis spiegelt die aktuelle Schriftumgebung, konfigurierte Fallback‑Regeln, in einer [IFontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsubstrulecollection/) gespeicherte Substitutionsregeln und [extern geladene Schriftarten](/slides/de/cpp/custom-font/) wider.

Die gleiche Substitution kann von mehr als einer ausgewählten Folie benötigt werden. Deduplizieren Sie die Ergebnisse, wenn Sie ein Schriftinventar oder einen Preflight‑Report erstellen. Das folgende Beispiel gibt jede zurückgegebene Substitution aus und erstellt anschließend eine sortierte Liste eindeutiger Schriftzuordnungen:

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

Die [IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/)‑Schnittstelle bietet beide Überladungen. Wählen Sie je nach Umfang des Rendering‑Vorgangs:

| Überladung | Verwenden, wenn |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) ohne Argumente | Sie benötigen Substitutionen für die gesamte Präsentation. |
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) mit `System::ArrayPtr<int32_t> slides` | Sie benötigen Substitutionen für einen ausgewählten Bereich, inkrementelle Prüfung oder Teil‑Export. |

## **Schriftart-Substitutionsregeln festlegen**

Um die Schriftart anzugeben, die Aspose.Slides verwenden soll, wenn eine Quellschriftart nicht verfügbar ist:

1. Laden Sie die Präsentation.
2. Erstellen Sie Schriftart‑Definitionen für die Quell‑ und Ersatzschriftarten.
3. Erzeugen Sie ein [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) mit der [WhenInaccessible](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstcondition/)‑Bedingung.
4. Fügen Sie die Regel einer [FontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrulecollection/) hinzu.
5. Ordnen Sie die Sammlung über die [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/)‑Methode zu.
6. Rendern oder konvertieren Sie die Präsentation.

Das folgende C++‑Beispiel substituiert `Arial` für `SomeRareFont`, wenn `SomeRareFont` nicht verfügbar ist, und rendert anschließend die erste Folie, um das Ergebnis zu überprüfen. Die Ersatzschriftart muss für Aspose.Slides verfügbar sein.

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

{{% alert color="info" title="Note" %}}
Für eine bedingungslose Änderung der in einer gesamten Präsentation verwendeten Schriftarten siehe [Font Replacement](/slides/de/cpp/font-replacement/).
{{% /alert %}}

## **Einschränkungen für Mathegleichungs‑Schriftarten**

Schriftart‑Substitutionsregeln sind Teil des standardisierten Schriftartauswahlprozesses, der beim Rendern und Konvertieren verwendet wird. Sie funktionieren für regulären Text, wenn Aspose.Slides eine nicht zugängliche Schriftart durch die in einer Regel angegebene verfügbare Schriftart ersetzen kann.

Office‑Math‑Gleichungen haben eine zusätzliche Anforderung. Wenn eine Gleichung **Cambria Math** verwendet, muss Aspose.Slides genau diese Schriftart zum Berechnen und Rendern des Gleichungs‑Layouts besitzen. Eine Regel, die eine andere mathematische Schriftart wie **STIX Two Math** substituiert, kann **Cambria Math** für diesen Zweck nicht ersetzen, und das Rendering meldet möglicherweise weiterhin, dass **Cambria Math** erforderlich ist.

Um eine solche Präsentation zu rendern oder zu konvertieren, stellen Sie **Cambria Math** Aspose.Slides zur Verfügung. Installieren Sie sie im Betriebssystem oder laden Sie sie als [external font](/slides/de/cpp/custom-font/) ​laden.

Diese Einschränkung gilt für das Gleichungs‑Layout. Die oben beschriebenen Substitutionsregeln gelten weiterhin für regulären Präsentationstext.

## **FAQ**

**Was ist der Unterschied zwischen Font Replacement und Font Substitution?**

[Font replacement](/slides/de/cpp/font-replacement/) ändert bewusst eine Schriftart durch eine andere in der gesamten Präsentation. Font substitution wählt eine Schriftart für die gerenderte Ausgabe, wenn die konfigurierte Bedingung erfüllt ist, beispielsweise wenn die Originalschriftart nicht verfügbar ist.

**Wann werden Substitutionsregeln angewendet?**

Die Regeln nehmen am [font selection sequence](/slides/de/cpp/font-selection-sequence/)‑Prozess während Rendern und Konvertieren teil. Bei `WhenInaccessible` wird eine Regel nur verwendet, wenn Aspose.Slides nicht auf die Quellschriftart zugreifen kann.

**Was passiert, wenn eine Schriftart fehlt und keine Substitutionsregel konfiguriert ist?**

Aspose.Slides wählt die am besten geeignete verfügbare Schriftart gemäß seines Schriftartauswahlprozesses. Das Ergebnis hängt von den im Laufzeit‑Umfeld installierten Schriftarten ab.

**Kann ich externe Schriftarten laden, um Substitutionen zu vermeiden?**

Ja. Sie können [load external fonts](/slides/de/cpp/custom-font/) ​laden, damit Aspose.Slides sie beim Rendern und Konvertieren verwenden kann.

**Stellt Aspose Schriftarten mit der Bibliothek bereit?**

Nein. Sie sind dafür verantwortlich, Schriftarten bereitzustellen und deren Lizenzbedingungen einzuhalten.

**Können Substitutionsergebnisse zwischen Windows, Linux und macOS variieren?**

Ja. Installierte Schriftarten und Suchpfade für Schriftarten unterscheiden sich je nach Betriebssystem, sodass eine Schriftart, die auf einem Rechner verfügbar ist, auf einem anderen substituiert werden muss.

**Wie kann ich die Schriftartauswahl bei Stapelkonvertierungen konsistent halten?**

Verwenden Sie dieselben Schriftdateien und -versionen auf jedem Rechner oder Container, [load required external fonts](/slides/de/cpp/custom-font/), und [embed fonts](/slides/de/cpp/embedded-font/), sofern die Lizenz dies zulässt. Sie können außerdem vor dem Export [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) ​aufrufen, um unerwartete Substitutionen zu erkennen.