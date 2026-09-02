---
title: Schriftart-Substitution in Präsentationen unter Android konfigurieren
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
description: "Konfigurieren Sie Schriftart-Substitutionsregeln und prüfen Sie substituierte Schriftarten in Aspose.Slides für Android über Java beim Rendern oder Konvertieren von Präsentationen."
---
## **Übersicht**

Die Font-Substitution ermöglicht es Aspose.Slides, eine verfügbare Schriftart anstelle einer nicht zugänglichen Schriftart zu verwenden, wenn eine Präsentation gerendert oder konvertiert wird. Die Substitution wirkt sich auf die gerenderte Ausgabe aus; sie ändert nicht die der Präsentationsinhalt zugewiesene Schriftart.

Sie können die zu verwendende Schriftart definieren, wenn eine bestimmte Schriftart nicht verfügbar ist, und Sie können die Substitutionen prüfen, die Aspose.Slides beim Rendern vornimmt. Dies hilft, die Ausgabe über Android-Geräte und Umgebungen mit unterschiedlichen verfügbaren Schriftarten hinweg konsistent zu halten.

## **Schriftart‑Substitutionen abrufen**

Verwenden Sie die Methode [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) , um zu bestimmen, welche Schriftarten beim Rendern der Präsentation substituiert werden. Die Methode gibt [FontSubstitutionInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontsubstitutioninfo/)-Objekte zurück, die den ursprünglichen und den substituierten Schriftnamen identifizieren.

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

Verwenden Sie die Überladung [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) mit einem `int[] slides`‑Argument, um nur die Substitutionen zu prüfen, die zum Rendern bestimmter Folien erforderlich sind. Dies ist nützlich, wenn Sie einen Teil einer Präsentation rendern oder exportieren, eine große Präsentation inkrementell prüfen, Folien finden, die von nicht verfügbaren Schriftarten abhängen, ein minimales Schriftart‑Paket für eine Android‑App vorbereiten oder Render‑Unterschiede diagnostizieren möchten, ohne nicht relevante Folien zu verarbeiten.

Das Array `slides` enthält einbasierten Folienindizes: `1` bezeichnet die erste Folie. Im Gegensatz dazu verwendet der Zugriff [Presentation.getSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getSlides--) auf die Sammlung nullbasierte Indizierung, sodass dieselbe Folie über `presentation.getSlides().get_Item(0)` adressiert wird. Beachten Sie diesen Unterschied beim Erstellen des Arrays, um Off‑by‑One‑Fehler zu vermeiden.

Rufen Sie die Überladung über die Methode [Presentation.getFontsManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getFontsManager--) auf. Sie gibt nur die während des Renderns der ausgewählten Folien ermittelten Substitutionen zurück. Jeder Eintrag ist ein [FontSubstitutionInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontsubstitutioninfo/)-Objekt, das den ursprünglichen und den substituierten Schriftnamen enthält. Das Ergebnis spiegelt die aktuelle Schriftumgebung, konfigurierte Fallback‑Regeln, in einer [IFontSubstRuleCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontsubstrulecollection/) gespeicherte Substitutionsregeln sowie [extern geladene Schriftarten](/slides/de/androidjava/custom-font/) wider.

Die gleiche Substitution kann von mehr als einer ausgewählten Folie benötigt werden. Entfernen Sie Duplikate aus den Ergebnissen, wenn Sie ein Schriftarten‑Inventar oder einen Preflight‑Bericht erstellen. Das folgende Beispiel gibt jede zurückgegebene Substitution aus und erstellt anschließend eine sortierte Liste eindeutiger Schriftarten‑Zuordnungen:

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

Das Interface [IFontsManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontsmanager/) stellt beide Überladungen bereit. Wählen Sie die passende abhängig vom Umfang des Render‑Vorgangs:

| Überladung | Verwenden, wenn |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) ohne Argumente | Sie benötigen Substitutionen für die gesamte Präsentation. |
| [getSubstitutions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) mit `int[] slides` | Sie benötigen Substitutionen für einen ausgewählten Bereich, eine inkrementelle Prüfung oder einen Teil‑Export. |

## **Schriftart‑Substitutionsregeln festlegen**

Um die Schriftart festzulegen, die Aspose.Slides verwenden soll, wenn die Quellschriftart nicht verfügbar ist:

1. Laden Sie die Präsentation.
2. Erstellen Sie Schriftartdefinitionen für die Quell‑ und die Ersatzschriftart.
3. Erstellen Sie eine [FontSubstRule](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontsubstrule/) mit der Bedingung [WhenInaccessible](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontsubstcondition/).
4. Fügen Sie die Regel zu einer [FontSubstRuleCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontsubstrulecollection/) hinzu.
5. Weisen Sie die Sammlung über die Methode [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) zu.
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
Für eine bedingungslose Änderung der in einer Präsentation verwendeten Schriftarten siehe [Schriftart-Ersetzung](/slides/de/androidjava/font-replacement/).
{{% /alert %}}

## **Einschränkungen für mathematische Gleichungs­schriftarten**

Schriftart‑Substitutionsregeln sind Teil des standardmäßigen Schriftartauswahlprozesses, der beim Rendern und Konvertieren verwendet wird. Sie funktionieren für normalen Text, wenn Aspose.Slides eine nicht zugängliche Schriftart durch die durch eine Regel angegebene verfügbare Schriftart ersetzen kann.

Office‑Math‑Gleichungen haben eine zusätzliche Anforderung. Wenn eine Gleichung **Cambria Math** verwendet, kann Aspose.Slides genau diese Schriftart benötigen, um das Layout der Gleichung zu berechnen und zu rendern. Eine Regel, die eine andere mathematische Schriftart, wie zum Beispiel **STIX Two Math**, substituiert, kann **Cambria Math** für diesen Zweck nicht ersetzen, und das Rendering kann weiterhin melden, dass **Cambria Math** erforderlich ist.

Um eine solche Präsentation zu rendern oder zu konvertieren, stellen Sie **Cambria Math** Aspose.Slides zur Verfügung. Laden Sie sie als [externe Schriftart](/slides/de/androidjava/custom-font/) hoch, damit die Anwendung sie beim Rendern und Konvertieren verwenden kann.

Diese Einschränkung gilt für das Gleichungs‑Layout. Die oben beschriebenen Substitutionsregeln gelten weiterhin für normalen Präsentationstext.

## **FAQ**

**Was ist der Unterschied zwischen Schriftart‑Ersetzung und Schriftart‑Substitution?**

[Schriftart‑Ersetzung](/slides/de/androidjava/font-replacement/) ändert bewusst eine Schriftart im gesamten Dokument zu einer anderen. Schriftart‑Substitution wählt eine Schriftart für die gerenderte Ausgabe aus, wenn die konfigurierte Bedingung erfüllt ist, beispielsweise wenn die Originalschriftart nicht verfügbar ist.

**Wann werden Substitutionsregeln angewendet?**

Die Regeln nehmen an der [Schriftartauswahl‑Sequenz](/slides/de/androidjava/font-selection-sequence/) während des Renderns und der Konvertierung teil. Bei `WhenInaccessible` wird eine Regel nur angewendet, wenn Aspose.Slides nicht auf die Quellschriftart zugreifen kann.

**Was passiert, wenn eine Schriftart fehlt und keine Substitutionsregel konfiguriert ist?**

Aspose.Slides wählt die am nächsten liegende verfügbare Schriftart gemäß seines Auswahlprozesses aus. Das Ergebnis hängt von den im Laufzeitumfeld verfügbaren Schriftarten ab.

**Kann ich externe Schriftarten laden, um Substitution zu vermeiden?**

Ja. Sie können [externe Schriftarten laden](/slides/de/androidjava/custom-font/), damit Aspose.Slides sie beim Rendern und Konvertieren verwenden kann.

**Stellt Aspose Schriftarten mit der Bibliothek bereit?**

Nein. Sie sind selbst dafür verantwortlich, Schriftarten bereitzustellen und deren Lizenzen einzuhalten.

**Können Substitutionsresultate zwischen Android‑Geräten variieren?**

Ja. Verfügbare Systemschriftarten können zwischen Android‑Versionen, Geräten und Herstellern variieren, sodass eine in einer Umgebung verfügbare Schriftart in einer anderen Umgebung eine Substitution erfordern kann.

**Wie kann ich die Schriftartauswahl über Android‑Geräte hinweg konsistent machen?**

Packen Sie die gleichen erforderlichen Schriftdateien mit der Anwendung, [laden Sie sie als externe Schriftarten](/slides/de/androidjava/custom-font/) und [betten Sie Schriftarten ein](/slides/de/androidjava/embedded-font/), sofern die Lizenz dies zulässt. Sie können außerdem vor dem Export [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) aufrufen, um unerwartete Substitutionen zu ermitteln.