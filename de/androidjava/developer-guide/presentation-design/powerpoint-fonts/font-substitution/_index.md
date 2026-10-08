---
title: Schriftart-Substitution in Präsentationen auf Android konfigurieren
linktitle: Schriftart-Substitution
type: docs
weight: 70
url: /de/androidjava/font-substitution/
keywords:
- Schriftart
- Schriftart ersetzen
- Schriftart-Substitution
- Schriftart ersetzen
- Schriftart-Ersetzung
- Substitutionsregel
- Ersetzungsregel
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Konfigurieren Sie Schriftart-Substitutionsregeln und prüfen Sie ersetzte Schriftarten in Aspose.Slides für Android über Java beim Rendern oder Konvertieren von Präsentationen."
---
## **Übersicht**

Die Font-Substitution ermöglicht Aspose.Slides, eine verfügbare Schriftart anstelle einer Schriftart zu verwenden, die beim Rendern oder Konvertieren einer Präsentation nicht zugänglich ist. Die Substitution wirkt sich auf die gerenderte Ausgabe aus; sie ändert nicht die der Präsentationsinhalte zugewiesene Schriftart.

Sie können die zu verwendende Schriftart definieren, wenn eine bestimmte Schriftart nicht verfügbar ist, und Sie können die Substitutionen untersuchen, die Aspose.Slides beim Rendern vornimmt. Dies hilft, die Ausgabe über Android‑Geräte und Umgebungen mit unterschiedlichen verfügbaren Schriftarten hinweg konsistent zu halten.

Wenn eine Schriftart verfügbar ist, aber keinen dedizierten fetten Schriftschnitt hat, siehe [Schriftarten ohne dedizierten fetten Schriftschnitt behandeln](/slides/de/androidjava/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Dieser Abschnitt erklärt, wie der betroffene Text beim PDF‑Export gerastert wird und welche Konsequenzen dies für Textauswahl, Suche und Skalierung hat.

## **Schriftart-Substitutionen abrufen**

Verwenden Sie die [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) Methode, um zu bestimmen, welche Schriftarten ersetzt werden, wenn die Präsentation gerendert wird. Die Methode gibt [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) Objekte zurück, die den ursprünglichen und den ersetzten Schriftartnamen identifizieren.

Das folgende Java‑Beispiel listet alle Schriftart-Substitutionen für eine Präsentation auf:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Schriftart-Substitutionen für ausgewählte Folien abrufen**

Verwenden Sie die Überladung [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) mit einem `int[] slides`‑Argument, um nur die Substitutionen zu untersuchen, die zum Rendern bestimmter Folien erforderlich sind. Dies ist nützlich, wenn Sie einen Teil einer Präsentation rendern oder exportieren, eine große Präsentation inkrementell prüfen, Folien finden, die von nicht verfügbaren Schriftarten abhängen, ein minimales Schriftart‑Paket für eine Android‑App vorbereiten oder Rendering‑Unterschiede diagnostizieren möchten, ohne nicht relevante Folien zu verarbeiten.

Das `slides`‑Array enthält einsbasierte Folienindizes: `1` identifiziert die erste Folie. Im Gegensatz dazu verwendet der [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) Sammlungszugriff nullbasierte Indizierung, sodass dieselbe Folie über `presentation.getSlides().get_Item(0)` zugegriffen wird. Berücksichtigen Sie diesen Unterschied beim Erstellen des Arrays, um Off‑by‑One‑Fehler zu vermeiden.

Rufen Sie die Überladung über die [Presentation.getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getFontsManager--) Methode auf. Sie gibt nur die Substitutionen zurück, die beim Rendern der ausgewählten Folien ermittelt wurden. Jeder Ergebnis ist ein [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) Objekt, das den ursprünglichen und den ersetzten Schriftartnamen enthält. Das Ergebnis spiegelt die aktuelle Schriftumgebung, konfigurierte Fallback‑Regeln, in einer [IFontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsubstrulecollection/) gespeicherte Substitutionsregeln und [extern geladene Schriftarten](/slides/de/androidjava/custom-font/) wider.

Die gleiche Substitution kann von mehr als einer ausgewählten Folie benötigt werden. Deduplizieren Sie die Ergebnisse, wenn Sie ein Schriftarten‑Inventar oder einen Preflight‑Report erstellen. Das folgende Beispiel gibt jede zurückgegebene Substitution aus und erstellt anschließend eine sortierte Liste eindeutiger Schriftartzuordnungen:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

Das [IFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/) Interface bietet beide Überladungen. Wählen Sie diejenige aus, die dem Umfang des Rendering‑Vorgangs entspricht:

| Überladung | Verwenden Sie sie, wenn |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) ohne Argumente | Sie benötigen Substitutionen für die gesamte Präsentation. |
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) mit `int[] slides` | Sie benötigen Substitutionen für einen ausgewählten Bereich, eine inkrementelle Prüfung oder einen Teil‑Export. |

## **Schriftart-Substitutionsregeln festlegen**

Um die Schriftart festzulegen, die Aspose.Slides verwenden soll, wenn eine Quellschriftart nicht verfügbar ist:

1. Laden Sie die Präsentation.
2. Erstellen Sie Schriftartdefinitionen für die Quell‑ und Ersatzschriftarten.
3. Erstellen Sie eine [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/) mit der [WhenInaccessible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstcondition/) Bedingung.
4. Fügen Sie die Regel zu einer [FontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrulecollection/) hinzu.
5. Weisen Sie die Sammlung zu, indem Sie die [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) Methode verwenden.
6. Rendern oder konvertieren Sie die Präsentation.

Das folgende Java‑Beispiel ersetzt `Arial` durch `SomeRareFont`, wenn `SomeRareFont` nicht verfügbar ist, und rendert anschließend die erste Folie, um das Ergebnis zu überprüfen. Die Ersatzschriftart muss für Aspose.Slides verfügbar sein.

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Hinweis" %}}
Für eine bedingungslose Änderung der in einer gesamten Präsentation verwendeten Schriftarten siehe [Schriftart-Ersetzung](/slides/de/androidjava/font-replacement/).
{{% /alert %}}

## **Einschränkungen für Schriftarten in mathematischen Gleichungen**

Schriftart-Substitutionsregeln sind Teil des standardmäßigen Schriftartauswahlprozesses, der beim Rendern und Konvertieren verwendet wird. Sie funktionieren für normalen Text, wenn Aspose.Slides eine nicht zugängliche Schriftart durch die in einer Regel angegebene verfügbare Schriftart ersetzen kann.

Office‑Math‑Gleichungen haben eine zusätzliche Anforderung. Wenn eine Gleichung **Cambria Math** verwendet, muss Aspose.Slides diese exakte Schriftart zum Berechnen und Rendern des Gleichungs‑Layouts haben. Eine Regel, die eine andere mathematische Schriftart, wie **STIX Two Math**, substituiert, kann **Cambria Math** für diesen Zweck nicht ersetzen, und das Rendering kann weiterhin melden, dass **Cambria Math** erforderlich ist.

Um eine solche Präsentation zu rendern oder zu konvertieren, stellen Sie **Cambria Math** Aspose.Slides zur Verfügung. Laden Sie sie als [external font](/slides/de/androidjava/custom-font/) hoch, damit die Anwendung sie beim Rendern und Konvertieren nutzen kann.

Diese Einschränkung gilt für das Gleichungs‑Layout. Die oben beschriebenen Substitutionsregeln gelten weiterhin für normalen Präsentationstext.

## **FAQ**

**Was ist der Unterschied zwischen Schriftart‑Ersetzung und Schriftart‑Substitution?**

[Font replacement](/slides/de/androidjava/font-replacement/) ändert absichtlich eine Schriftart im gesamten Dokument zu einer anderen. Schriftart‑Substitution wählt eine Schriftart für die gerenderte Ausgabe, wenn die konfigurierte Bedingung erfüllt ist, z. B. wenn die Originalschriftart nicht verfügbar ist.

**Wann werden Substitutionsregeln angewendet?**

Die Regeln nehmen an der [font selection sequence](/slides/de/androidjava/font-selection-sequence/) während des Renderns und Konvertierens teil. Mit `WhenInaccessible` wird eine Regel nur verwendet, wenn Aspose.Slides nicht auf die Quellschriftart zugreifen kann.

**Was passiert, wenn eine Schriftart fehlt und keine Substitutionsregel konfiguriert ist?**

Aspose.Slides wählt die am nächsten verfügbare Schriftart gemäß seinem Schriftartauswahlprozess aus. Das Ergebnis hängt von den im Laufzeitumfeld verfügbaren Schriftarten ab.

**Kann ich externe Schriftarten laden, um Substitution zu vermeiden?**

Ja. Sie können [externen Schriftarten laden](/slides/de/androidjava/custom-font/), damit Aspose.Slides sie beim Rendern und Konvertieren nutzen kann.

**Verteilt Aspose Schriftarten mit der Bibliothek?**

Nein. Sie sind dafür verantwortlich, Schriftarten bereitzustellen und deren Lizenzbedingungen einzuhalten.

**Können Substitutionsresultate zwischen Android-Geräten variieren?**

Ja. Verfügbare Systemschriftarten können zwischen Android‑Versionen, Geräten und Herstellern variieren, sodass eine Schriftart, die in einer Umgebung verfügbar ist, in einer anderen ersetzt werden muss.

**Wie kann ich die Schriftartauswahl über Android-Geräte hinweg konsistent halten?**

Packen Sie dieselben erforderlichen Schriftdateien mit der Anwendung, [laden Sie sie als externe Schriftarten](/slides/de/androidjava/custom-font/) und [betten Sie Schriftarten ein](/slides/de/androidjava/embedded-font/), sofern die Lizenz dies zulässt. Sie können auch vor dem Export [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) aufrufen, um unerwartete Substitutionen zu identifizieren.