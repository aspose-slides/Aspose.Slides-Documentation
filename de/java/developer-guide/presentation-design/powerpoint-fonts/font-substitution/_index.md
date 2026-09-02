---
title: Schriftartsubstitution in Präsentationen mit Java konfigurieren
linktitle: Schriftartsubstitution
type: docs
weight: 70
url: /de/java/font-substitution/
keywords:
- Schriftart
- Ersatzschriftart
- Schriftartsubstitution
- Schriftart ersetzen
- Schriftart-Ersetzung
- Substitutionsregel
- Ersetzungsregel
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Schriftart-Substitutionsregeln konfigurieren und substituierte Schriftarten in Aspose.Slides für Java prüfen, wenn PowerPoint- und OpenDocument-Präsentationen gerendert oder konvertiert werden."
---
## **Übersicht**

Die Schriftartensubstitution ermöglicht es Aspose.Slides, eine verfügbare Schriftart anstelle einer nicht zugänglichen Schriftart zu verwenden, wenn eine Präsentation gerendert oder konvertiert wird. Die Substitution wirkt sich auf die gerenderte Ausgabe aus; sie ändert nicht die der Präsentationsinhalte zugewiesene Schriftart.

Sie können die zu verwendende Schriftart definieren, wenn eine bestimmte Schriftart nicht verfügbar ist, und die Substitutionen einsehen, die Aspose.Slides beim Rendern vornimmt. Das hilft, die Ausgabe über Umgebungen mit unterschiedlichen installierten Schriftarten hinweg konsistent zu halten.

## **Schriftart‑Substitutionen abrufen**

Verwenden Sie die Methode [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) , um zu bestimmen, welche Schriftarten beim Rendern der Präsentation substituiert werden. Die Methode gibt [FontSubstitutionInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsubstitutioninfo/) Objekte zurück, die den ursprünglichen und den ersetzten Schriftartnamen identifizieren.

Das folgende Java‑Beispiel listet alle Schriftartsubstitutionen für eine Präsentation auf:

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

## **Schriftart‑Substitutionen für ausgewählte Folien abrufen**

Verwenden Sie die Überladung von [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) mit einem `int[] slides`‑Argument, um nur die Substitutionen zu prüfen, die zum Rendern bestimmter Folien erforderlich sind. Dies ist nützlich, wenn Sie einen Teil einer Präsentation rendern oder exportieren, eine große Präsentation inkrementell überprüfen, Folien lokalisieren möchten, die von nicht verfügbaren Schriftarten abhängen, ein minimales Schriftarten‑Paket für einen Server oder Container vorbereiten oder Rendering‑Unterschiede diagnostizieren wollen, ohne nicht relevante Folien zu verarbeiten.

Das `slides`‑Array verwendet ein‑basierten Folien‑Index: `1` bezeichnet die erste Folie. Im Gegensatz dazu verwendet der Zugriff über [Presentation.getSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getSlides--) nullbasiertes Indexieren, sodass dieselbe Folie über `presentation.getSlides().get_Item(0)` adressiert wird. Beachten Sie diesen Unterschied beim Erstellen des Arrays, um Off‑by‑One‑Fehler zu vermeiden.

Rufen Sie die Überladung über die Methode [Presentation.getFontsManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getFontsManager--) auf. Sie liefert nur die Substitutionen, die beim Rendern der ausgewählten Folien ermittelt wurden. Jeder Eintrag ist ein [FontSubstitutionInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsubstitutioninfo/) Objekt, das den ursprünglichen und den ersetzten Schriftartnamen enthält. Das Ergebnis spiegelt die aktuelle Schriftumgebung, konfigurierte Fallback‑Regeln, in einer [IFontSubstRuleCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsubstrulecollection/) gespeicherte Substitutionsregeln und [extern geladene Schriften](/slides/de/java/custom-font/) wider.

Die gleiche Substitution kann von mehr als einer ausgewählten Folie benötigt werden. Deduplizieren Sie die Ergebnisse, wenn Sie ein Schriftarten‑Inventar oder einen Preflight‑Bericht erstellen. Das folgende Beispiel gibt jede zurückgegebene Substitution aus und erstellt anschließend eine sortierte Liste eindeutiger Schriftzuordnungen:

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

Das Interface [IFontsManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/) stellt beide Überladungen bereit. Wählen Sie die passende je nach Umfang des Rendering‑Vorgangs:

| Überladung | Verwenden, wenn |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) ohne Argumente | Sie benötigen Substitutionen für die gesamte Präsentation. |
| [getSubstitutions](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) mit `int[] slides` | Sie benötigen Substitutionen für einen ausgewählten Bereich, eine inkrementelle Prüfung oder einen teilweisen Export. |

## **Schriftart‑Substitutionsregeln festlegen**

Um die Schriftart anzugeben, die Aspose.Slides verwenden soll, wenn die Quellschriftart nicht verfügbar ist:

1. Laden Sie die Präsentation.
2. Erstellen Sie Schriftartdefinitionen für die Quell‑ und Ersatzschriftart.
3. Erstellen Sie ein [FontSubstRule](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsubstrule/) mit der Bedingung [WhenInaccessible](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsubstcondition/).
4. Fügen Sie die Regel zu einer [FontSubstRuleCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsubstrulecollection/) hinzu.
5. Ordnen Sie die Sammlung über die Methode [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) zu.
6. Rendern oder konvertieren Sie die Präsentation.

Das folgende Java‑Beispiel substituiert `Arial` für `SomeRareFont`, wenn `SomeRareFont` nicht verfügbar ist, und rendert anschließend die erste Folie, um das Ergebnis zu überprüfen. Die Ersatzschriftart muss für Aspose.Slides verfügbar sein.

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

{{% alert color="info" title="Note" %}}
Für eine bedingungslose Änderung der in einer gesamten Präsentation verwendeten Schriftarten siehe [Font Replacement](/slides/de/java/font-replacement/).
{{% /alert %}}

## **Einschränkungen für Schriftarten von mathematischen Gleichungen**

Schriftart‑Substitutionsregeln sind Teil des Standard‑Schriftartauswahlprozesses, der beim Rendern und Konvertieren verwendet wird. Sie funktionieren für normalen Text, wenn Aspose.Slides eine nicht zugängliche Schriftart durch die in einer Regel angegebene verfügbare Schriftart ersetzen kann.

Office‑Math‑Gleichungen haben eine zusätzliche Anforderung. Wenn eine Gleichung **Cambria Math** verwendet, muss Aspose.Slides exakt diese Schriftart zur Berechnung und zum Rendern des Gleichungs‑Layouts besitzen. Eine Regel, die eine andere Mathematik‑Schriftart wie **STIX Two Math** substituiert, kann **Cambria Math** in diesem Kontext nicht ersetzen, und das Rendering meldet weiterhin, dass **Cambria Math** erforderlich ist.

Um eine solche Präsentation zu rendern oder zu konvertieren, stellen Sie **Cambria Math** Aspose.Slides zur Verfügung. Installieren Sie sie im Betriebssystem oder laden Sie sie als [externen Font](/slides/de/java/custom-font/) hoch.

Diese Einschränkung gilt nur für das Gleichungs‑Layout. Die oben beschriebenen Substitutionsregeln bleiben für normalen Präsentationstext wirksam.

## **FAQ**

**Was ist der Unterschied zwischen Schriftart‑Ersetzung und Schriftart‑Substitution?**

[Font replacement](/slides/de/java/font-replacement/) ändert bewusst eine Schriftart durch eine andere in der gesamten Präsentation. Schriftart‑Substitution wählt für die gerenderte Ausgabe eine Schriftart, wenn die konfigurierte Bedingung erfüllt ist, beispielsweise wenn die Originalschriftart nicht verfügbar ist.

**Wann werden Substitutionsregeln angewendet?**

Die Regeln nehmen am [font selection sequence](/slides/de/java/font-selection-sequence/) während des Renderns und der Konvertierung teil. Bei `WhenInaccessible` wird eine Regel nur verwendet, wenn Aspose.Slides nicht auf die Quellschriftart zugreifen kann.

**Was passiert, wenn eine Schriftart fehlt und keine Substitutionsregel konfiguriert ist?**

Aspose.Slides wählt die am besten passende verfügbare Schriftart gemäß seinem Schriftartauswahlprozess. Das Ergebnis hängt von den in der Laufzeitumgebung verfügbaren Schriftarten ab.

**Kann ich externe Schriftarten laden, um Substitutionen zu vermeiden?**

Ja. Sie können [externe Schriftarten laden](/slides/de/java/custom-font/), sodass Aspose.Slides sie während des Renderns und der Konvertierung verwenden kann.

**Stellt Aspose die Schriftarten mit der Bibliothek bereit?**

Nein. Sie sind dafür verantwortlich, die Schriftarten bereitzustellen und deren Lizenzbedingungen einzuhalten.

**Können sich Substitutions‑Ergebnisse zwischen Windows, Linux und macOS unterscheiden?**

Ja. Installierte Schriftarten und Suchpfade für Schriftarten unterscheiden sich je nach Betriebssystem, sodass eine Schriftart, die auf einem Rechner verfügbar ist, auf einem anderen substituiert werden muss.

**Wie kann ich die Schriftartauswahl bei Stapelkonvertierungen konsistent halten?**

Verwenden Sie dieselben Schriftdateien und Versionen auf jeder Maschine oder jedem Container, [laden Sie erforderliche externe Schriftarten](/slides/de/java/custom-font/) und [betten Sie Schriftarten ein](/slides/de/java/embedded-font/), sofern die Lizenz dies erlaubt. Sie können zudem vor dem Export [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) aufrufen, um unerwartete Substitutionen zu identifizieren.