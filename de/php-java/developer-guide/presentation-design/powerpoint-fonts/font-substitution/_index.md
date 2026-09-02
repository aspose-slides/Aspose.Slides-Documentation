---
title: Schriftart-Substitution in Präsentationen mit PHP konfigurieren
linktitle: Schriftart-Substitution
type: docs
weight: 70
url: /de/php-java/font-substitution/
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
- PHP
- Aspose.Slides
description: "Konfigurieren Sie Schriftart-Substitutionsregeln und prüfen Sie substituierte Schriftarten in Aspose.Slides für PHP via Java beim Rendern oder Konvertieren von PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Die Schriftart-Substitution ermöglicht es Aspose.Slides, eine verfügbare Schriftart anstelle einer nicht zugänglichen Schriftart zu verwenden, wenn eine Präsentation gerendert oder konvertiert wird. Die Substitution wirkt sich nur auf die gerenderte Ausgabe aus; sie ändert nicht die der Präsentationsinhalte zugewiesene Schriftart.

Sie können die zu verwendende Schriftart festlegen, wenn eine bestimmte Schriftart nicht verfügbar ist, und Sie können die Substitutionen einsehen, die Aspose.Slides während des Renderns vornimmt. Das hilft, die Ausgabe über Umgebungen mit unterschiedlichen installierten Schriftarten hinweg konsistent zu halten.

## **Schriftart-Substitutionen abrufen**

Verwenden Sie die Methode [FontsManager::getSubstitutions](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/getsubstitutions/), um zu bestimmen, welche Schriftarten beim Rendern der Präsentation substituiert werden. Die Methode gibt [FontSubstitutionInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsubstitutioninfo/)-Objekte zurück, die die ursprünglichen und substituierten Schriftartnamen identifizieren.

Das folgende PHP‑Beispiel listet alle Schriftart‑Substitutionen für eine Präsentation auf:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Schriftart-Substitutionen für ausgewählte Folien abrufen**

Verwenden Sie die Überladung von [FontsManager::getSubstitutions](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/getsubstitutions/) mit einem `int[] slides`‑Argument, um nur die Substitutionen zu prüfen, die zum Rendern bestimmter Folien erforderlich sind. Dies ist nützlich, wenn Sie einen Teil einer Präsentation rendern oder exportieren, eine große Präsentation schrittweise überprüfen, Folien lokalisieren, die von nicht verfügbaren Schriftarten abhängen, ein minimales Schriftartenpaket für einen Server oder Container vorbereiten oder Rendering‑Unterschiede diagnostizieren, ohne nicht relevante Folien zu verarbeiten.

`slides`‑Array enthält ein‑basiert indizierte Folienzahlen: `1` bezeichnet die erste Folie. Im Gegensatz dazu verwendet der Zugriff auf die Sammlung über [Presentation::getSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getSlides) nullbasierte Indizierung, sodass dieselbe Folie über `$presentation->getSlides()->get_Item(0)` angesprochen wird. Beachten Sie diesen Unterschied beim Erstellen des Arrays, um Off‑by‑One‑Fehler zu vermeiden.

Rufen Sie die Überladung über die Methode [Presentation::getFontsManager](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getFontsManager) auf. Sie gibt nur die Substitutionen zurück, die beim Rendern der ausgewählten Folien ermittelt wurden. Jeder Treffer ist ein [FontSubstitutionInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsubstitutioninfo/)-Objekt, das den ursprünglichen und den substituierten Schriftartnamen enthält. Das Ergebnis spiegelt die aktuelle Schriftumgebung, konfigurierte Fallback‑Regeln, in einer [FontSubstRuleCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsubstrulecollection/) gespeicherte Substitutionsregeln sowie [extern geladene Schriftarten](/slides/de/php-java/custom-font/) wider.

Die gleiche Substitution kann von mehr als einer ausgewählten Folie benötigt werden. Entfernen Sie Duplikate aus den Ergebnissen, wenn Sie ein Schriftarten‑Inventar oder einen Preflight‑Bericht erstellen. Das folgende Beispiel gibt jede zurückgegebene Substitution aus und erstellt anschließend eine sortierte Liste eindeutiger Schriftartenzuordnungen:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Die Klasse [FontsManager](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/) stellt beide Überladungen bereit. Wählen Sie die passende je nach Umfang des Rendering‑Vorgangs:

| Überladung | Verwenden Sie sie, wenn |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | Sie benötigen Substitutionen für die gesamte Präsentation. |
| [getSubstitutions](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/getsubstitutions/) with `int[] slides` | Sie benötigen Substitutionen für einen ausgewählten Bereich, schrittweise Prüfung oder Teil‑Export. |

## **Schriftart-Substitutionsregeln festlegen**

Um die Schriftart anzugeben, die Aspose.Slides verwenden soll, wenn eine Quellschriftart nicht verfügbar ist:

1. Laden Sie die Präsentation.
2. Erstellen Sie Schriftartdefinitionen für die Quell‑ und die Ersatzschriftart.
3. Erstellen Sie ein [FontSubstRule](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsubstrule/) mit der Bedingung [WhenInaccessible](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsubstcondition/).
4. Fügen Sie die Regel einer [FontSubstRuleCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsubstrulecollection/) hinzu.
5. Weisen Sie die Sammlung über die Methode [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/) zu.
6. Rendern oder konvertieren Sie die Präsentation.

Das folgende PHP‑Beispiel ersetzt `Arial` durch `SomeRareFont`, wenn `SomeRareFont` nicht verfügbar ist, und rendert anschließend die erste Folie, um das Ergebnis zu überprüfen. Die Ersatzschriftart muss für Aspose.Slides verfügbar sein.

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Hinweis" %}}
Für eine bedingungslose Änderung der in einer Präsentation verwendeten Schriftarten siehe [Font Replacement](/slides/de/php-java/font-replacement/).
{{% /alert %}}

## **Einschränkungen für Schriftarten in mathematischen Gleichungen**

Schriftart‑Substitutionsregeln sind Teil des standardmäßigen Schriftartauswahlprozesses, der beim Rendern und Konvertieren verwendet wird. Sie funktionieren für normalen Text, wenn Aspose.Slides eine nicht zugängliche Schriftart durch die in einer Regel angegebene verfügbare Schriftart ersetzen kann.

Office‑Math‑Gleichungen haben eine zusätzliche Anforderung. Wenn eine Gleichung **Cambria Math** verwendet, kann Aspose.Slides genau diese Schriftart benötigen, um das Layout der Gleichung zu berechnen und zu rendern. Eine Regel, die eine andere mathematische Schriftart, etwa **STIX Two Math**, substituiert, kann **Cambria Math** hierfür nicht ersetzen, und das Rendering kann weiterhin melden, dass **Cambria Math** erforderlich ist.

Um eine solche Präsentation zu rendern oder zu konvertieren, stellen Sie **Cambria Math** Aspose.Slides zur Verfügung. Installieren Sie sie im Betriebssystem oder laden Sie sie als [externen Font](/slides/de/php-java/custom-font/) hoch.

Diese Einschränkung gilt für das Gleichungs‑Layout. Die oben beschriebenen Substitutionsregeln gelten weiterhin für normalen Präsentationstext.

## **FAQ**

**Was ist der Unterschied zwischen Schriftart­ersetzung und Schriftart‑Substitution?**

[Font replacement](/slides/de/php-java/font-replacement/) ändert bewusst eine Schriftart im gesamten Dokument in eine andere. Schriftart‑Substitution wählt eine Schriftart für die gerenderte Ausgabe, wenn die konfigurierte Bedingung erfüllt ist, beispielsweise wenn die ursprüngliche Schriftart nicht verfügbar ist.

**Wann werden Substitutionsregeln angewendet?**

Die Regeln nehmen während des Renderns und Konvertierens an der [Schriftartauswahl‑Sequenz](/slides/de/php-java/font-selection-sequence/) teil. Bei `WhenInaccessible` wird eine Regel nur verwendet, wenn Aspose.Slides nicht auf die Quellschriftart zugreifen kann.

**Was passiert, wenn eine Schriftart fehlt und keine Substitutionsregel konfiguriert ist?**

Aspose.Slides wählt die am besten passende verfügbare Schriftart gemäß seinem Auswahlverfahren aus. Das Ergebnis hängt von den im Laufzeitumfeld verfügbaren Schriftarten ab.

**Kann ich externe Schriftarten laden, um Substitutionen zu vermeiden?**

Ja. Sie können [externe Schriftarten laden](/slides/de/php-java/custom-font/), damit Aspose.Slides sie beim Rendern und Konvertieren verwenden kann.

**Stellt Aspose Schriftarten zusammen mit der Bibliothek bereit?**

Nein. Sie sind dafür verantwortlich, Schriftarten bereitzustellen und die jeweiligen Lizenzbedingungen einzuhalten.

**Können Substitutionsresultate zwischen Windows, Linux und macOS variieren?**

Ja. Installierte Schriftarten und Suchpfade für Schriftarten unterscheiden sich je nach Betriebssystem, sodass eine auf einem Rechner verfügbare Schriftart auf einem anderen eine Substitution erfordern kann.

**Wie kann ich die Schriftartauswahl bei Batch‑Konvertierungen konsistent halten?**

Verwenden Sie dieselben Schriftdateien und -versionen auf jedem Rechner oder Container, [laden Sie erforderliche externe Schriftarten](/slides/de/php-java/custom-font/) und [betten Sie Schriftarten ein](/slides/de/php-java/embedded-font/), sofern die Lizenz dies zulässt. Sie können außerdem vor dem Export [FontsManager::getSubstitutions](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/getsubstitutions/) aufrufen, um unerwartete Substitutionen zu erkennen.