---
title: Konfigurieren von Schriftart-Substitutionen in Präsentationen in .NET
linktitle: Schriftart-Substitution
type: docs
weight: 70
url: /de/net/font-substitution/
keywords:
- Schriftart
- Ersatzschriftart
- Schriftart-Substitution
- Schriftart ersetzen
- Schriftart-Ersetzung
- Substitutionsregel
- Ersetzungsregel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Konfigurieren Sie Schriftart-Substitutionsregeln und prüfen Sie substituierte Schriftarten in Aspose.Slides für .NET beim Rendern oder Konvertieren von PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Die Schriftart-Substitution ermöglicht Aspose.Slides, eine verfügbare Schriftart anstelle einer Schriftart zu verwenden, die beim Rendern oder Konvertieren einer Präsentation nicht zugänglich ist. Die Substitution wirkt sich auf die gerenderte Ausgabe aus; sie ändert nicht die der Präsentationsinhalte zugewiesene Schriftart.

Sie können die zu verwendende Schriftart festlegen, wenn eine bestimmte Schriftart nicht verfügbar ist, und Sie können die Substitutionen prüfen, die Aspose.Slides beim Rendern vornimmt. Dies hilft, die Ausgabe über Umgebungen mit unterschiedlichen installierten Schriftarten hinweg konsistent zu halten.

Wenn eine Schriftart verfügbar ist, aber keine eigene fette Variante hat, siehe [Schriftarten ohne eigene fette Variante behandeln](/slides/de/net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Dieser Abschnitt erklärt, wie der betroffene Text beim PDF‑Export gerastert wird und welche Folgen das für Textauswahl, Suche und Skalierung hat.

## **Schriftart‑Substitutionen abrufen**

Verwenden Sie die [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/)‑Methode, um zu bestimmen, welche Schriftarten beim Rendern der Präsentation substituiert werden. Die Methode gibt [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/)‑Objekte zurück, die den ursprünglichen und den substituierten Schriftartnamen identifizieren.

Das folgende C#‑Beispiel listet alle Schriftart‑Substitutionen für eine Präsentation auf:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Schriftart‑Substitutionen für ausgewählte Folien abrufen**

Verwenden Sie die Überladung von [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) mit einem `int[] slides`‑Argument, um nur die für das Rendern bestimmter Folien erforderlichen Substitutionen zu prüfen. Dies ist nützlich, wenn Sie einen Teil einer Präsentation rendern oder exportieren, eine große Präsentation schrittweise prüfen, Folien finden, die von nicht verfügbaren Schriftarten abhängen, ein minimales Schriftart‑Paket für einen Server oder Container vorbereiten oder Rendering‑Unterschiede diagnostizieren, ohne nicht relevante Folien zu verarbeiten.

Das `slides`‑Array enthält eins‑basierte Folienindizes: `1` bezeichnet die erste Folie. Im Gegensatz dazu ist der Indexer der [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/)‑Sammlung null‑basiert, sodass dieselbe Folie über `presentation.Slides[0]` aufgerufen wird. Berücksichtigen Sie diesen Unterschied beim Erstellen des Arrays, um Off‑by‑One‑Fehler zu vermeiden.

Rufen Sie die Überladung über die Eigenschaft [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) auf. Sie gibt nur die Substitutionen zurück, die beim Rendern der ausgewählten Folien ermittelt wurden. Jeder Rückgabewert ist ein [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/)‑Objekt, das den ursprünglichen und den substituierten Schriftartnamen enthält. Das Ergebnis spiegelt die aktuelle Schriftumgebung und [extern geladene Schriftarten](/slides/de/net/custom-font/) wider. In einer [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) gespeicherte Substitutionsregeln ändern die gerenderte Ausgabe, werden jedoch im Ergebnis nicht wiedergegeben.

Die gleiche Substitution kann von mehr als einer ausgewählten Folie benötigt werden. Deduplizieren Sie die Ergebnisse, wenn Sie ein Schriftart‑Inventar oder einen Preflight‑Bericht erstellen. Das folgende Beispiel gibt jede zurückgegebene Substitution aus und erstellt anschließend eine sortierte Liste eindeutiger Schriftartenzuordnungen:

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

Die [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/)‑Schnittstelle bietet beide Überladungen. Wählen Sie die passende gemäß dem Umfang des Rendering‑Vorgangs:

| Überladung | Verwenden, wenn |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) ohne Argumente | Sie benötigen Substitutionen für die gesamte Präsentation. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) mit `int[] slides` | Sie benötigen Substitutionen für einen ausgewählten Bereich, eine schrittweise Prüfung oder einen Teil‑Export. |

## **Schriftart‑Substitutionsregeln festlegen**

Um die Schriftart anzugeben, die Aspose.Slides verwenden soll, wenn eine Quellschriftart nicht verfügbar ist:

1. Laden Sie die Präsentation.
2. Erstellen Sie Schriftartdefinitionen für die Quell‑ und Ersatzschriftarten.
3. Erzeugen Sie ein [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) mit der [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/)‑Bedingung.
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
Für eine bedingungslose Änderung der in einer Präsentation verwendeten Schriftarten siehe [Schriftart‑Ersetzung](/slides/de/net/font-replacement/).
{{% /alert %}}

## **Einschränkungen für Schriftarten in mathematischen Gleichungen**

Schriftart‑Substitutionsregeln sind Teil des standardmäßigen Schriftartauswahlprozesses, der beim Rendern und Konvertieren verwendet wird. Sie funktionieren für normalen Text, wenn Aspose.Slides eine nicht zugängliche Schriftart durch die in einer Regel angegebene verfügbare Schriftart ersetzen kann.

Mathematische Office‑Math‑Gleichungen haben eine zusätzliche Anforderung. Verwendet eine Gleichung **Cambria Math**, muss Aspose.Slides genau diese Schriftart besitzen, um das Layout der Gleichung zu berechnen und zu rendern. Eine Regel, die eine andere Math‑Schriftart wie **STIX Two Math** substituiert, kann **Cambria Math** für diesen Zweck nicht ersetzen, und das Rendern meldet weiterhin, dass **Cambria Math** erforderlich ist.

Um eine solche Präsentation zu rendern oder zu konvertieren, stellen Sie **Cambria Math** Aspose.Slides zur Verfügung. Installieren Sie sie im Betriebssystem oder laden Sie sie als [external font](/slides/de/net/custom-font/) ​laden.

Diese Einschränkung gilt für das Gleichungs‑Layout. Die oben beschriebenen Substitutionsregeln gelten weiterhin für normalen Präsentationstext.

## **FAQ**

**Was ist der Unterschied zwischen Schriftart‑Ersetzung und Schriftart‑Substitution?**

[Font replacement](/slides/de/net/font-replacement/) ändert absichtlich eine Schriftart im gesamten Dokument in eine andere. Schriftart‑Substitution wählt eine Schriftart für die gerenderte Ausgabe, wenn die konfigurierte Bedingung erfüllt ist, beispielsweise wenn die ursprüngliche Schriftart nicht verfügbar ist.

**Wann werden Substitutionsregeln angewendet?**

Die Regeln nehmen am [font selection sequence](/slides/de/net/font-selection-sequence/)‑Prozess während Rendern und Konvertieren teil. Bei `WhenInaccessible` wird eine Regel nur verwendet, wenn Aspose.Slides nicht auf die Quellschriftart zugreifen kann.

**Was passiert, wenn eine Schriftart fehlt und keine Substitutionsregel konfiguriert ist?**

Aspose.Slides wählt die am besten passende verfügbare Schriftart gemäß seines Auswahlprozesses. Das Ergebnis hängt von den in der Laufzeitumgebung installierten Schriftarten ab.

**Kann ich externe Schriftarten laden, um Substitutionen zu vermeiden?**

Ja. Sie können [load external fonts](/slides/de/net/custom-font/) ​laden, damit Aspose.Slides sie beim Rendern und Konvertieren verwenden kann.

**Stellt Aspose Schriftarten mit der Bibliothek bereit?**

Nein. Sie sind verantwortlich für die Bereitstellung der Schriftarten und die Einhaltung ihrer Lizenzen.

**Können sich Substitutionsresultate zwischen Windows, Linux und macOS unterscheiden?**

Ja. Installierte Schriftarten und Suchpfade variieren je nach Betriebssystem, sodass eine Schriftart, die auf einem Rechner verfügbar ist, auf einem anderen substituiert werden muss.

**Wie kann ich die Schriftartauswahl bei Stapelkonvertierungen konsistent halten?**

Verwenden Sie auf allen Maschinen oder Containern dieselben Schriftdateien und -versionen, [load required external fonts](/slides/de/net/custom-font/), und [embed fonts](/slides/de/net/embedded-font/) ​wenn die Lizenz dies zulässt. Sie können außerdem vor dem Export [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) ​aufrufen, um unerwartete Substitutionen zu identifizieren.