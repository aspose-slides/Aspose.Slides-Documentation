---
title: Konfigurieren der Schriftart-Substitution in Präsentationen mit Java
linktitle: Schriftart-Substitution
type: docs
weight: 70
url: /de/java/font-substitution/
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
- Java
- Aspose.Slides
description: "Konfigurieren Sie Schriftart-Substitutionsregeln und prüfen Sie substituierte Schriftarten in Aspose.Slides für Java beim Rendern oder Konvertieren von PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Die Schriftart‑Substitution ermöglicht es Aspose.Slides, eine verfügbare Schriftart anstelle einer nicht zugänglichen Schriftart zu verwenden, wenn eine Präsentation gerendert oder konvertiert wird. Die Substitution wirkt sich auf die gerenderte Ausgabe aus; sie ändert nicht die der Präsentationsinhalte zugewiesene Schriftart.

Sie können die zu verwendende Schriftart definieren, wenn eine bestimmte Schriftart nicht verfügbar ist, und Sie können die Substitutionen einsehen, die Aspose.Slides beim Rendern vornimmt. Dies hilft, die Ausgabe über Umgebungen mit unterschiedlichen installierten Schriftarten hinweg konsistent zu halten.

## **Schriftart‑Substitutionen abrufen**

Verwenden Sie die [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#getSubstitutions--)‑Methode, um zu bestimmen, welche Schriftarten substituiert werden, wenn die Präsentation gerendert wird. Die Methode gibt [FontSubstitutionInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsubstitutioninfo/)‑Objekte zurück, die den ursprünglichen und den substituierten Schriftartnamen identifizieren.

Das folgende Java‑Beispiel listet alle Schriftart‑Substitutionen für eine Präsentation auf:

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

Verwenden Sie die [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---)‑Überladung mit einem `int[] slides`‑Parameter, um nur die Substitutionen zu prüfen, die zum Rendern bestimmter Folien erforderlich sind. Das ist nützlich, wenn Sie einen Teil einer Präsentation rendern oder exportieren, eine große Präsentation inkrementell prüfen, Folien finden möchten, die von nicht verfügbaren Schriftarten abhängen, ein minimales Schriftarten‑Paket für einen Server oder Container vorbereiten oder Rendering‑Unterschiede diagnostizieren wollen, ohne nicht relevante Folien zu verarbeiten.

Das `slides`‑Array enthält ein‑basiert indizierte Folienzahlen: `1` bezeichnet die erste Folie. Im Gegensatz dazu verwendet der Zugriff auf die Sammlung über [Presentation.getSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getSlides--) null‑basiertes Indexieren, sodass dieselbe Folie über `presentation.getSlides().get_Item(0)` angesprochen wird. Beachten Sie diesen Unterschied beim Erstellen des Arrays, um Off‑by‑One‑Fehler zu vermeiden.

Rufen Sie die Überladung über die [Presentation.getFontsManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getFontsManager--)‑Methode auf. Sie gibt nur die Substitutionen zurück, die beim Rendern der ausgewählten Folien ermittelt wurden. Jeder Eintrag ist ein [FontSubstitutionInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsubstitutioninfo/)‑Objekt, das den ursprünglichen und den substituierten Schriftartnamen enthält. Das Ergebnis spiegelt die aktuelle Schriftumgebung, konfigurierte Fallback‑Regeln und [extern geladene Schriftarten](/slides/de/java/custom-font/) wider. Substitutionsregeln, die in einer [IFontSubstRuleCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsubstrulecollection/) gespeichert sind, werden beim Rendern der Präsentation angewendet, jedoch wird das Ergebnis sie nicht auflisten; prüfen Sie stattdessen die Schriftarten in der Ausgabedatei.

Die gleiche Substitution kann von mehr als einer ausgewählten Folie benötigt werden. Entfernen Sie Duplikate, wenn Sie ein Schriftarten‑Inventar oder einen Preflight‑Bericht erstellen. Das folgende Beispiel gibt jede zurückgegebene Substitution aus und erstellt anschließend eine sortierte Liste eindeutiger Schriftarten‑Zuordnungen:

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

Das [IFontsManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/)‑Interface stellt beide Überladungen bereit. Wählen Sie die passende je nach Umfang des Rendering‑Vorgangs:

| Überladung | Verwendung |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) ohne Argumente | Sie benötigen Substitutionen für die gesamte Präsentation. |
| [getSubstitutions](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) mit `int[] slides` | Sie benötigen Substitutionen für einen ausgewählten Bereich, eine inkrementelle Prüfung oder einen Teil‑Export. |

## **Schriftart‑Substitutionsregeln festlegen**

Um anzugeben, welche Schriftart Aspose.Slides verwenden soll, wenn eine Quellschriftart nicht verfügbar ist:

1. Laden Sie die Präsentation.
2. Erstellen Sie Schriftartdefinitionen für die Quell‑ und Ersatzschriftart.
3. Erstellen Sie eine [FontSubstRule](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsubstrule/) mit der [WhenInaccessible](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsubstcondition/)‑Bedingung.
4. Fügen Sie die Regel einer [FontSubstRuleCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsubstrulecollection/) hinzu.
5. Weisen Sie die Sammlung über die [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-)‑Methode zu.
6. Rendern oder konvertieren Sie die Präsentation.

Das folgende Java‑Beispiel substituiert `Arial` für `SomeRareFont`, wenn `SomeRareFont` nicht verfügbar ist, und rendert anschließend die erste Folie, um das Ergebnis zu prüfen. Die Ersatzschriftart muss für Aspose.Slides verfügbar sein.

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
Für eine unverbindliche Änderung der in einer gesamten Präsentation verwendeten Schriftarten siehe [Font Replacement](/slides/de/java/font-replacement/).
{{% /alert %}}

## **Einschränkungen für Schriftarten in mathematischen Gleichungen**

Schriftart‑Substitutionsregeln sind Bestandteil des standardmäßigen Schriftartauswahl‑Prozesses, der beim Rendern und Konvertieren verwendet wird. Sie funktionieren für normalen Text, wenn Aspose.Slides eine nicht zugängliche Schriftart durch die in einer Regel angegebene verfügbare Schriftart ersetzen kann.

Office‑Math‑Gleichungen haben eine zusätzliche Anforderung. Verwendet eine Gleichung **Cambria Math**, muss Aspose.Slides genau diese Schriftart zur Berechnung und zum Rendering des Gleichungs‑Layouts zur Verfügung stehen. Eine Regel, die eine andere mathematische Schriftart wie **STIX Two Math** substituiert, kann **Cambria Math** hierfür nicht ersetzen, und das Rendering meldet möglicherweise weiterhin, dass **Cambria Math** erforderlich ist.

Um eine solche Präsentation zu rendern oder zu konvertieren, stellen Sie **Cambria Math** Aspose.Slides bereit. Installieren Sie sie im Betriebssystem oder laden Sie sie als [externe Schriftart](/slides/de/java/custom-font/) .

Diese Einschränkung gilt nur für das Gleichungs‑Layout. Die oben beschriebenen Substitutionsregeln gelten weiterhin für normalen Präsentationstext.

## **FAQ**

**Was ist der Unterschied zwischen Schriftart‑Ersetzung und Schriftart‑Substitution?**

[Font replacement](/slides/de/java/font-replacement/) ändert bewusst eine Schriftart durch eine andere in der gesamten Präsentation. Schriftart‑Substitution wählt eine Schriftart für die gerenderte Ausgabe, wenn die konfigurierte Bedingung erfüllt ist, beispielsweise wenn die Originalschriftart nicht verfügbar ist.

**Wann werden Substitutionsregeln angewendet?**

Die Regeln nehmen am [font selection sequence](/slides/de/java/font-selection-sequence/)‑Prozess während des Renderns und der Konvertierung teil. Bei `WhenInaccessible` wird eine Regel nur verwendet, wenn Aspose.Slides nicht auf die Quellschriftart zugreifen kann.

**Was passiert, wenn eine Schriftart fehlt und keine Substitutionsregel konfiguriert ist?**

Aspose.Slides wählt die am besten geeignete verfügbare Schriftart nach seinem Schriftartauswahl‑Verfahren. Das Ergebnis hängt von den in der Laufzeitumgebung verfügbaren Schriftarten ab.

**Kann ich externe Schriftarten laden, um Substitution zu vermeiden?**

Ja. Sie können [externe Schriftarten laden](/slides/de/java/custom-font/), damit Aspose.Slides sie beim Rendern und Konvertieren verwenden kann.

**Stellt Aspose Schriftarten zusammen mit der Bibliothek bereit?**

Nein. Sie sind dafür verantwortlich, Schriftarten bereitzustellen und deren Lizenzen einzuhalten.

**Können sich Substitutionsergebnisse zwischen Windows, Linux und macOS unterscheiden?**

Ja. Installierte Schriftarten und Suchpfade unterscheiden sich je nach Betriebssystem, sodass eine Schriftart auf einer Maschine verfügbar sein kann, auf einer anderen jedoch substituiert werden muss.

**Wie kann ich die Schriftartauswahl bei Batch‑Konvertierungen konsistent halten?**

Verwenden Sie dieselben Schriftartdateien und -versionen auf jeder Maschine oder in jedem Container, [laden Sie erforderliche externe Schriftarten](/slides/de/java/custom-font/) und [betten Sie Schriftarten ein](/slides/de/java/embedded-font/), sofern die Lizenz dies zulässt. Sie können außerdem vor dem Export [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) aufrufen, um unerwartete Substitutionen zu identifizieren.