---
title: Schriftart-Substitution in Präsentationen in .NET
linktitle: Schriftart-Substitution
type: docs
weight: 70
url: /de/net/font-substitution/
keywords:
- Schriftart
- auszutauschende Schriftart
- Schriftart-Substitution
- Schriftart ersetzen
- Schriftart-Austausch
- Substitutionsregel
- Austauschregel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Schriftart-Substitutionsregeln konfigurieren und substituierte Schriftarten in Aspose.Slides für .NET beim Rendern oder Konvertieren von PowerPoint- und OpenDocument-Präsentationen prüfen."
---
## **Übersicht**

Font substitution ermöglicht es Aspose.Slides, eine verfügbare Schriftart anstelle einer nicht zugänglichen Schriftart zu verwenden, wenn eine Präsentation gerendert oder konvertiert wird. Die Substitution wirkt sich auf die gerenderte Ausgabe aus; sie ändert nicht die der Präsentation zugewiesene Schriftart.

Sie können die zu verwendende Schriftart festlegen, wenn eine bestimmte Schriftart nicht verfügbar ist, und Sie können die Substitutionen einsehen, die Aspose.Slides beim Rendern durchführen wird. Dies hilft, die Ausgabe über Umgebungen mit unterschiedlichen installierten Schriftarten hinweg konsistent zu halten.

## **Font‑Substitutionen abrufen**

Verwenden Sie die [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) Methode, um zu bestimmen, welche Schriftarten bei der Wiedergabe der Präsentation substituiert werden. Die Methode gibt [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) Objekte zurück, die den ursprünglichen und den substituierten Schriftartnamen identifizieren.

Das folgende C#‑Beispiel listet alle Font‑Substitutionen für eine Präsentation auf:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Font‑Substitutionen für ausgewählte Folien abrufen**

Verwenden Sie die [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) Überladung mit einem `int[] slides`‑Argument, um nur die Substitutionen zu prüfen, die zum Rendern bestimmter Folien erforderlich sind. Dies ist nützlich, wenn Sie einen Teil einer Präsentation rendern oder exportieren, eine große Präsentation schrittweise prüfen, Folien ermitteln, die von nicht verfügbaren Schriftarten abhängen, ein minimales Schriftarten‑Paket für einen Server oder Container vorbereiten oder Rendering‑Unterschiede diagnostizieren, ohne nicht relevante Folien zu verarbeiten.

Das `slides`‑Array enthält ein‑basiert indizierte Folienzahlen: `1` bezeichnet die erste Folie. Im Gegensatz dazu ist der Indexer der [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) Sammlung nullbasiert, sodass dieselbe Folie als `presentation.Slides[0]` angesprochen wird. Beachten Sie diesen Unterschied beim Erstellen des Arrays, um Off‑by‑One‑Fehler zu vermeiden.

Rufen Sie die Überladung über die Eigenschaft [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) auf. Sie gibt nur die während des Renderns der ausgewählten Folien ermittelten Substitutionen zurück. Jeder Eintrag ist ein [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) Objekt, das die ursprünglichen und substituierten Schriftartnamen enthält. Das Ergebnis spiegelt die aktuelle Schriftumgebung und [extern geladene Schriftarten](/slides/de/net/custom-font/) wider. Substitutionsregeln, die in einer [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) gespeichert sind, ändern die gerenderte Ausgabe, werden jedoch nicht im Ergebnis berücksichtigt.

Die gleiche Substitution kann von mehr als einer ausgewählten Folie benötigt werden. Entfernen Sie Duplikate aus den Ergebnissen, wenn Sie ein Schriftarten‑Inventar oder einen Vorabprüf‑Bericht erstellen. Das folgende Beispiel gibt jede zurückgegebene Substitution aus und erstellt anschließend eine sortierte Liste eindeutiger Schriftzuordnungen:

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

Das [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) Interface bietet beide Überladungen. Wählen Sie die passende je nach Umfang der Render‑Operation:

| Überladung | Verwenden Sie sie, wenn |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | Sie benötigen Substitutionen für die gesamte Präsentation. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | Sie benötigen Substitutionen für einen ausgewählten Bereich, schrittweise Prüfung oder teilweisen Export. |

## **Font‑Substitutionsregeln festlegen**

Um die Schriftart festzulegen, die Aspose.Slides verwenden soll, wenn die Quellschriftart nicht verfügbar ist:

1. Laden Sie die Präsentation.
2. Erstellen Sie Schriftartdefinitionen für die Quell- und Ersatzschriftart.
3. Erstellen Sie eine [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) mit der [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/) Bedingung.
4. Fügen Sie die Regel einer [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/) hinzu.
5. Weisen Sie die Sammlung der Eigenschaft [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/) zu.
6. Rendern oder konvertieren Sie die Präsentation.

Das folgende C#‑Beispiel substituiert `Arial` für `SomeRareFont`, wenn `SomeRareFont` nicht verfügbar ist, und rendert anschließend die erste Folie, um das Ergebnis zu überprüfen. Die Ersatzschriftart muss für Aspose.Slides verfügbar sein.

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

{{% alert color="info" title="Note" %}}
Für eine bedingungslose Änderung der in einer gesamten Präsentation verwendeten Schriftarten siehe [Font Replacement](/slides/de/net/font-replacement/).
{{% /alert %}}

## **Einschränkungen für Schriftarten in mathematischen Gleichungen**

Font‑Substitutionsregeln sind Teil des standardmäßigen Schriftartauswahlprozesses, der beim Rendering und bei der Konvertierung verwendet wird. Sie funktionieren für normalen Text, wenn Aspose.Slides eine nicht zugängliche Schriftart durch die durch eine Regel angegebene verfügbare Schriftart ersetzen kann.

Office‑Math‑Gleichungen haben eine zusätzliche Anforderung. Verwendet eine Gleichung **Cambria Math**, kann Aspose.Slides diese genaue Schriftart benötigen, um das Layout der Gleichung zu berechnen und zu rendern. Eine Regel, die eine andere mathematische Schriftart, z. B. **STIX Two Math**, substituiert, kann **Cambria Math** für diesen Zweck nicht ersetzen, und das Rendering kann weiterhin melden, dass **Cambria Math** erforderlich ist.

Um eine solche Präsentation zu rendern oder zu konvertieren, stellen Sie **Cambria Math** Aspose.Slides zur Verfügung. Installieren Sie sie im Betriebssystem oder laden Sie sie als [external font](/slides/de/net/custom-font/).

Diese Einschränkung gilt für das Gleichungs‑Layout. Die oben beschriebenen Substitutionsregeln gelten weiterhin für normalen Präsentationstext.

## **FAQ**

**Was ist der Unterschied zwischen Font Replacement und Font Substitution?**

Die [Font replacement](/slides/de/net/font-replacement/) ändert bewusst eine Schriftart durch eine andere in der gesamten Präsentation. Font‑Substitution wählt eine Schriftart für die gerenderte Ausgabe, wenn die konfigurierte Bedingung erfüllt ist, z. B. wenn die Originalschriftart nicht verfügbar ist.

**When are substitution rules applied?**

Die Regeln nehmen am [font selection sequence](/slides/de/net/font-selection-sequence/) während des Renderns und der Konvertierung teil. Bei `WhenInaccessible` wird eine Regel nur verwendet, wenn Aspose.Slides nicht auf die Quellschriftart zugreifen kann.

**What happens when a font is missing and no substitution rule is configured?**

Aspose.Slides wählt die am nächsten passende verfügbare Schriftart gemäß seines Schriftartauswahlprozesses. Das Ergebnis hängt von den im Laufzeit‑Umfeld verfügbaren Schriftarten ab.

**Can I load external fonts to avoid substitution?**

Ja. Sie können [externen fonts laden](/slides/de/net/custom-font/), damit Aspose.Slides sie beim Rendern und Konvertieren verwenden kann.

**Does Aspose distribute fonts with the library?**

Nein. Sie sind dafür verantwortlich, Schriftarten bereitzustellen und deren Lizenzen einzuhalten.

**Can substitution results differ between Windows, Linux, and macOS?**

Ja. Installierte Schriftarten und Suchpfade unterscheiden sich je nach Betriebssystem, sodass eine Schriftart, die auf einem Rechner verfügbar ist, auf einem anderen substituiert werden muss.

**How can I make font selection consistent in batch conversions?**

Verwenden Sie dieselben Schriftdateien und -versionen auf jedem Rechner oder Container, [laden Sie erforderliche externe Schriftarten](/slides/de/net/custom-font/), und [betten Sie Schriftarten ein](/slides/de/net/embedded-font/), wenn die Lizenz dies zulässt. Sie können außerdem vor dem Export [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) aufrufen, um unerwartete Substitutionen zu identifizieren.