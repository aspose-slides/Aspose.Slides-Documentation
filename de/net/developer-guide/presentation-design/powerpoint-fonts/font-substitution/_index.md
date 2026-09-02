---
title: Schriftartenersetzung in Präsentationen in .NET konfigurieren
linktitle: Schriftartenersetzung
type: docs
weight: 70
url: /de/net/font-substitution/
keywords:
- Schriftart
- Schriftart ersetzen
- Schriftartenersetzung
- Schriftart ersetzen
- Schriftartenaustausch
- Ersetzungsregel
- Austauschregel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Konfigurieren Sie Schriftartenersetzungsregeln und prüfen Sie ersetzte Schriftarten in Aspose.Slides für .NET beim Rendern oder Konvertieren von PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Schriftartersetzung ermöglicht Aspose.Slides, eine verfügbare Schriftart anstelle einer nicht zugänglichen Schriftart zu verwenden, wenn eine Präsentation gerendert oder konvertiert wird. Die Ersetzung wirkt sich auf die gerenderte Ausgabe aus; sie ändert nicht die der Präsentationsinhalte zugewiesene Schriftart.

Sie können die Schriftart definieren, die verwendet werden soll, wenn eine bestimmte Schriftart nicht verfügbar ist, und Sie können die Ersetzungen untersuchen, die Aspose.Slides während des Renderns vornimmt. Das hilft, die Ausgabe in Umgebungen mit unterschiedlichen installierten Schriftarten konsistent zu halten.

## **Schriftartersetzungen abrufen**

Verwenden Sie die [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/de/net/aspose.slides/ifontsmanager/getsubstitutions/)‑Methode, um zu bestimmen, welche Schriftarten beim Rendern der Präsentation ersetzt werden. Die Methode gibt [FontSubstitutionInfo](https://reference.aspose.com/slides/de/net/aspose.slides/fontsubstitutioninfo/)‑Objekte zurück, die den ursprünglichen und den ersetzten Schriftartnamen identifizieren.

Das folgende C#‑Beispiel listet alle Schriftartersetzungen für eine Präsentation auf:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Schriftartersetzungen für ausgewählte Folien abrufen**

Verwenden Sie die Überladung von [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/de/net/aspose.slides/ifontsmanager/getsubstitutions/) mit einem `int[] slides`‑Argument, um nur die Ersetzungen zu untersuchen, die zum Rendern bestimmter Folien erforderlich sind. Dies ist nützlich, wenn Sie einen Teil einer Präsentation rendern oder exportieren, eine große Präsentation inkrementell prüfen, Folien finden, die von nicht verfügbaren Schriftarten abhängen, ein minimales Schriftpaket für einen Server oder Container vorbereiten oder Rendering‑Unterschiede diagnostizieren möchten, ohne nicht verwandte Folien zu verarbeiten.

Das `slides`‑Array enthält ein‑basiert indizierte Foliennummern: `1` bezeichnet die erste Folie. Im Gegensatz dazu ist der Indexer der [Presentation.Slides](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/slides/de/)‑Sammlung nullbasiert, sodass dieselbe Folie über `presentation.Slides[0]` angesprochen wird. Berücksichtigen Sie diesen Unterschied beim Erstellen des Arrays, um Off‑by‑One‑Fehler zu vermeiden.

Rufen Sie die Überladung über die [Presentation.FontsManager](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/fontsmanager/)‑Eigenschaft auf. Sie liefert nur die Ersetzungen, die beim Rendern der ausgewählten Folien ermittelt wurden. Jeder Treffer ist ein [FontSubstitutionInfo](https://reference.aspose.com/slides/de/net/aspose.slides/fontsubstitutioninfo/)‑Objekt, das den ursprünglichen und den ersetzten Schriftartnamen enthält. Das Ergebnis spiegelt die aktuelle Schriftumgebung, konfigurierte Fallback‑Regeln, in einer [IFontSubstRuleCollection](https://reference.aspose.com/slides/de/net/aspose.slides/ifontsubstrulecollection/) gespeicherte Ersetzungsregeln und [extern geladene Schriftarten](/slides/de/net/custom-font/) wider.

Die gleiche Ersetzung kann von mehr als einer ausgewählten Folie benötigt werden. Entfernen Sie Duplikate, wenn Sie ein Schriftinventar oder einen Preflight‑Report erstellen. Das folgende Beispiel gibt jede zurückgegebene Ersetzung aus und erstellt anschließend eine sortierte Liste eindeutiger Schriftzuordnungen:

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

Das [IFontsManager](https://reference.aspose.com/slides/de/net/aspose.slides/ifontsmanager/)‑Interface stellt beide Überladungen bereit. Wählen Sie je nach Umfang des Rendering‑Vorgangs:

| Überladung | Verwenden, wenn |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/de/net/aspose.slides/ifontsmanager/getsubstitutions/) ohne Argumente | Sie benötigen Ersetzungen für die gesamte Präsentation. |
| [GetSubstitutions](https://reference.aspose.com/slides/de/net/aspose.slides/ifontsmanager/getsubstitutions/) mit `int[] slides` | Sie benötigen Ersetzungen für einen ausgewählten Bereich, inkrementelle Prüfung oder Teil‑Export. |

## **Regeln für Schriftartersetzung festlegen**

Um die Schriftart anzugeben, die Aspose.Slides verwenden soll, wenn eine Quellschriftart nicht verfügbar ist:

1. Laden Sie die Präsentation.
2. Erstellen Sie Schriftartdefinitionen für die Quell‑ und Ersatzschriftarten.
3. Erstellen Sie eine [FontSubstRule](https://reference.aspose.com/slides/de/net/aspose.slides/fontsubstrule/) mit der Bedingung [WhenInaccessible](https://reference.aspose.com/slides/de/net/aspose.slides/fontsubstcondition/).
4. Fügen Sie die Regel einer [FontSubstRuleCollection](https://reference.aspose.com/slides/de/net/aspose.slides/fontsubstrulecollection/) hinzu.
5. Weisen Sie die Sammlung der Eigenschaft [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/de/net/aspose.slides/fontsmanager/fontsubstrulelist/) zu.
6. Rendern oder konvertieren Sie die Präsentation.

Das folgende C#‑Beispiel ersetzt `Arial` durch `SomeRareFont`, wenn `SomeRareFont` nicht verfügbar ist, und rendert anschließend die erste Folie, um das Ergebnis zu prüfen. Die Ersatzschriftart muss für Aspose.Slides verfügbar sein.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Hinweis" %}}
Für eine bedingungslose Änderung der in einer gesamten Präsentation verwendeten Schriftarten siehe [Font Replacement](/slides/de/net/font-replacement/).
{{% /alert %}}

## **Einschränkungen für Schriftarten von mathematischen Gleichungen**

Schriftartersetzungsregeln sind Teil des standardmäßigen Schriftartauswahlprozesses, der beim Rendern und Konvertieren verwendet wird. Sie funktionieren für normalen Text, wenn Aspose.Slides eine nicht zugängliche Schriftart durch die in einer Regel angegebene verfügbare Schriftart ersetzen kann.

Office‑Math‑Gleichungen haben eine zusätzliche Anforderung. Wenn eine Gleichung **Cambria Math** verwendet, muss Aspose.Slides genau diese Schriftart besitzen, um das Layout der Gleichung zu berechnen und zu rendern. Eine Regel, die eine andere mathematische Schriftart wie **STIX Two Math** ersetzt, kann **Cambria Math** für diesen Zweck nicht ersetzen, und das Rendering kann weiterhin melden, dass **Cambria Math** erforderlich ist.

Um eine solche Präsentation zu rendern oder zu konvertieren, stellen Sie **Cambria Math** Aspose.Slides zur Verfügung. Installieren Sie sie im Betriebssystem oder laden Sie sie als [external font](/slides/de/net/custom-font/) ​geladen.

Diese Einschränkung gilt nur für das Gleichungs‑Layout. Die oben beschriebenen Ersetzungsregeln gelten weiterhin für normalen Präsentationstext.

## **FAQ**

**Was ist der Unterschied zwischen Schriftartenersetzung und Schriftartenaustausch?**

[Font replacement](/slides/de/net/font-replacement/) ändert bewusst eine Schriftart durch eine andere in der gesamten Präsentation. Schriftartersetzung wählt eine Schriftart für die gerenderte Ausgabe, wenn die konfigurierte Bedingung erfüllt ist, beispielsweise wenn die Originalschriftart nicht verfügbar ist.

**Wann werden Ersetzungsregeln angewendet?**

Die Regeln nehmen am [font selection sequence](/slides/de/net/font-selection-sequence/)‑Prozess während des Renderns und der Konvertierung teil. Mit `WhenInaccessible` wird eine Regel nur verwendet, wenn Aspose.Slides nicht auf die Quellschriftart zugreifen kann.

**Was passiert, wenn eine Schriftart fehlt und keine Ersetzungsregel konfiguriert ist?**

Aspose.Slides wählt die am besten passende verfügbare Schriftart gemäß seinem Schriftartauswahlprozess. Das Ergebnis hängt von den im Laufzeit‑Umfeld verfügbaren Schriftarten ab.

**Kann ich externe Schriftarten laden, um Ersetzungen zu vermeiden?**

Ja. Sie können [external fonts](/slides/de/net/custom-font/) ​laden, sodass Aspose.Slides sie beim Rendern und Konvertieren verwenden kann.

**Stellt Aspose Schriftarten mit der Bibliothek bereit?**

Nein. Sie sind dafür verantwortlich, Schriftarten bereitzustellen und deren Lizenzbedingungen zu beachten.

**Können sich Ersetzungsergebnisse zwischen Windows, Linux und macOS unterscheiden?**

Ja. Installierte Schriftarten und Suchorte für Schriftarten unterscheiden sich je nach Betriebssystem, sodass eine Schriftart, die auf einem Rechner verfügbar ist, auf einem anderen substituiert werden muss.

**Wie kann ich die Schriftartauswahl bei Stapelkonvertierungen konsistent machen?**

Verwenden Sie dieselben Schriftdateien und -versionen auf jedem Rechner oder Container, [laden Sie erforderliche externe Schriftarten](/slides/de/net/custom-font/) und [betten Sie Schriftarten ein](/slides/de/net/embedded-font/), sofern die Lizenz dies zulässt. Sie können außerdem vor dem Export [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/de/net/aspose.slides/ifontsmanager/getsubstitutions/) ​aufrufen, um unerwartete Ersetzungen zu identifizieren.