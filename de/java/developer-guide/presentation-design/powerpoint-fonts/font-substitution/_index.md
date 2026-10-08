---
title: Schriftart-Substitution in Präsentationen mit Java konfigurieren
linktitle: Schriftart-Substitution
type: docs
weight: 70
url: /de/java/font-substitution/
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
- Java
- Aspose.Slides
description: "Konfigurieren Sie Schriftart-Substitutionsregeln und untersuchen Sie substituierte Schriftarten in Aspose.Slides für Java beim Rendern oder Konvertieren von PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Die Schriftart-Substitution ermöglicht Aspose.Slides, eine verfügbare Schriftart anstelle einer nicht zugänglichen Schriftart zu verwenden, wenn eine Präsentation gerendert oder konvertiert wird. Die Substitution wirkt sich auf die gerenderte Ausgabe aus; sie ändert nicht die der Präsentationsinhalte zugewiesene Schriftart.

Sie können die zu verwendende Schriftart festlegen, wenn eine bestimmte Schriftart nicht verfügbar ist, und Sie können die Substitutionen prüfen, die Aspose.Slides beim Rendering vornimmt. Dies hilft, die Ausgabe über verschiedene Umgebungen mit unterschiedlichen installierten Schriftarten hinweg konsistent zu halten.

If a font is available but has no dedicated bold typeface, see [Schriftarten ohne dedizierten Fettdruck behandeln](/slides/de/java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Dieser Abschnitt erklärt, wie der betroffene Text während des PDF-Exports gerastert wird und welche Folgen dies für die Textauswahl, Suche und Skalierung hat.

## **Schriftart-Substitutionen abrufen**

Verwenden Sie die Methode [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) , um zu bestimmen, welche Schriftarten bei der Wiedergabe der Präsentation substituiert werden. Die Methode gibt Objekte vom Typ [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) zurück, die den ursprünglichen und den substituierten Schriftnamen angeben.

Das folgende Java-Beispiel listet alle Schriftart-Substitutionen für eine Präsentation auf:

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

Verwenden Sie die Überladung von [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) mit einem `int[] slides`‑Argument, um nur die Substitutionen zu prüfen, die zum Rendern bestimmter Folien erforderlich sind. Dies ist nützlich, wenn Sie einen Teil einer Präsentation rendern oder exportieren, eine große Präsentation inkrementell prüfen, Folien finden, die von nicht verfügbaren Schriftarten abhängen, ein minimal‑es Schriftpaket für einen Server oder Container vorbereiten oder Rendering‑Unterschiede diagnostizieren, ohne nicht‑relevante Folien zu verarbeiten.

Das Array `slides` enthält ein‑basierten Folienindizes: `1` bezeichnet die erste Folie. Im Gegensatz dazu verwendet der Sammlungs‑Accessor [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) null‑basiertes Indexieren, sodass dieselbe Folie über `presentation.getSlides().get_Item(0)` zugegriffen wird. Beachten Sie diesen Unterschied beim Erstellen des Arrays, um Off‑by‑One‑Fehler zu vermeiden.

Rufen Sie die Überladung über die Methode [Presentation.getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getFontsManager--) auf. Sie gibt nur die Substitutionen zurück, die beim Rendern der ausgewählten Folien ermittelt wurden. Jeder Ergebnis ist ein Objekt vom Typ [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) , das den ursprünglichen und den substituierten Schriftnamen enthält. Das Ergebnis spiegelt die aktuelle Schriftumgebung, konfigurierte Ausweichregeln und [extern geladene Schriftarten](/slides/de/java/custom-font/) wider. Substitutionsregeln, die in einer [IFontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsubstrulecollection/) gespeichert sind, werden beim Rendern der Präsentation angewendet, jedoch werden sie im Ergebnis nicht aufgelistet; prüfen Sie stattdessen die Schriftarten in der Ausgabedatei.

Die gleiche Substitution kann von mehr als einer ausgewählten Folie benötigt werden. Entfernen Sie Duplikate aus den Ergebnissen, wenn Sie ein Schriftinventar oder einen Preflight‑Bericht erstellen. Das folgende Beispiel gibt jede zurückgegebene Substitution aus und erstellt anschließend eine sortierte Liste eindeutiger Schriftzuordnungen:

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

Das Interface [IFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/) stellt beide Überladungen bereit. Wählen Sie die passende je nach Umfang der Rendering‑Operation:

| Überladung | Verwenden, wenn |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) mit keinen Argumenten | Sie benötigen Substitutionen für die gesamte Präsentation. |
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) mit `int[] slides` | Sie benötigen Substitutionen für einen ausgewählten Bereich, inkrementelle Prüfung oder Teil‑Export. |

## **Schriftart-Substitutionsregeln festlegen**

Um die Schriftart festzulegen, die Aspose.Slides verwenden soll, wenn eine Quellschriftart nicht verfügbar ist:

1. Laden Sie die Präsentation.
2. Erstellen Sie Schriftartdefinitionen für die Quell‑ und Ersatzschriftarten.
3. Erstellen Sie eine [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/) mit der Bedingung [WhenInaccessible](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstcondition/).
4. Fügen Sie die Regel zu einer [FontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrulecollection/) hinzu.
5. Weisen Sie die Sammlung über die Methode [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) zu.
6. Rendern oder konvertieren Sie die Präsentation.

Das folgende Java-Beispiel ersetzt `Arial` durch `SomeRareFont`, wenn `SomeRareFont` nicht verfügbar ist, und rendert anschließend die erste Folie, um das Ergebnis zu überprüfen. Die Ersatzschriftart muss für Aspose.Slides verfügbar sein.

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

## **Einschränkungen für mathematische Gleichungs-Schriftarten**

Schriftart-Substitutionsregeln sind Teil des standardmäßigen Schriftartauswahlprozesses, der beim Rendering und der Konvertierung verwendet wird. Sie funktionieren für normalen Text, wenn Aspose.Slides eine nicht zugängliche Schriftart durch die durch eine Regel angegebene verfügbare Schriftart ersetzen kann.

Office‑Math‑Gleichungen haben eine zusätzliche Anforderung. Wenn eine Gleichung **Cambria Math** verwendet, kann Aspose.Slides genau diese Schriftart benötigen, um das Layout der Gleichung zu berechnen und zu rendern. Eine Regel, die eine andere mathematische Schriftart, z. B. **STIX Two Math**, substituiert, kann **Cambria Math** hierfür nicht ersetzen, und das Rendering kann weiterhin melden, dass **Cambria Math** erforderlich ist.

Um eine solche Präsentation zu rendern oder zu konvertieren, stellen Sie **Cambria Math** für Aspose.Slides bereit. Installieren Sie sie im Betriebssystem oder laden Sie sie als [external font](/slides/de/java/custom-font/) .

Diese Einschränkung gilt für das Gleichungs‑Layout. Die oben beschriebenen Substitutionsregeln gelten weiterhin für normalen Präsentationstext.

## **FAQ**

**Was ist der Unterschied zwischen Schriftart‑Ersetzung und Schriftart‑Substitution?**  
[Font replacement](/slides/de/java/font-replacement/) ändert bewusst eine Schriftart im gesamten Dokument zu einer anderen. Schriftart‑Substitution wählt eine Schriftart für die gerenderte Ausgabe, wenn die konfigurierte Bedingung erfüllt ist, z. B. wenn die Originalschriftart nicht verfügbar ist.

**Wann werden Substitutionsregeln angewendet?**  
Die Regeln nehmen am [font selection sequence](/slides/de/java/font-selection-sequence/) während des Renderings und der Konvertierung teil. Bei `WhenInaccessible` wird eine Regel nur verwendet, wenn Aspose.Slides nicht auf die Quellschriftart zugreifen kann.

**Was passiert, wenn eine Schriftart fehlt und keine Substitutionsregel konfiguriert ist?**  
Aspose.Slides wählt die am nächsten passende verfügbare Schriftart gemäß seines Schriftartauswahlprozesses aus. Das Ergebnis hängt von den im Laufzeitumfeld verfügbaren Schriftarten ab.

**Kann ich externe Schriftarten laden, um Substitutionen zu vermeiden?**  
Ja. Sie können [load external fonts](/slides/de/java/custom-font/) laden, sodass Aspose.Slides sie beim Rendering und der Konvertierung verwenden kann.

**Liefert Aspose Schriftarten mit der Bibliothek aus?**  
Nein. Sie sind dafür verantwortlich, Schriftarten bereitzustellen und deren Lizenzen einzuhalten.

**Können sich die Substitutionsresultate zwischen Windows, Linux und macOS unterscheiden?**  
Ja. Installierte Schriftarten und Suchpfade für Schriftarten unterscheiden sich je nach Betriebssystem, sodass eine auf einem Rechner verfügbare Schriftart auf einem anderen substituiert werden kann.

**Wie kann ich die Schriftartauswahl bei Stapelkonvertierungen konsistent halten?**  
Verwenden Sie dieselben Schriftdateien und -versionen auf jeder Maschine oder in jedem Container, [load required external fonts](/slides/de/java/custom-font/) und [embed fonts](/slides/de/java/embedded-font/), wenn die Lizenz dies erlaubt. Sie können außerdem vor dem Export [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) aufrufen, um unerwartete Substitutionen zu identifizieren.