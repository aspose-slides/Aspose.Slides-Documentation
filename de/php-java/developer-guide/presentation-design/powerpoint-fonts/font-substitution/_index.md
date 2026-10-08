---
title: Schriftart-Ersetzung in Präsentationen mit PHP konfigurieren
linktitle: Schriftart-Ersetzung
type: docs
weight: 70
url: /de/php-java/font-substitution/
keywords:
- Schriftart
- Schriftart ersetzen
- Schriftart-Ersetzung
- Schriftart ersetzen
- Schriftart-Austausch
- Ersetzungsregel
- Austauschregel
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Konfigurieren Sie Schriftart-Ersetzungsregeln und prüfen Sie ersetzte Schriftarten in Aspose.Slides für PHP über Java beim Rendern oder Konvertieren von PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Die Schriftartenersetzung ermöglicht es Aspose.Slides, eine verfügbare Schriftart anstelle einer nicht zugänglichen Schriftart zu verwenden, wenn eine Präsentation gerendert oder konvertiert wird. Die Ersetzung wirkt sich auf die gerenderte Ausgabe aus; sie ändert nicht die der Präsentationsinhalte zugewiesene Schriftart.

Sie können die zu verwendende Schriftart definieren, wenn eine bestimmte Schriftart nicht verfügbar ist, und Sie können die Ersetzungen, die Aspose.Slides beim Rendern vornimmt, überprüfen. Dies trägt dazu bei, die Ausgabe in unterschiedlichen Umgebungen mit verschiedenen installierten Schriftarten konsistent zu halten.

Wenn eine Schriftart verfügbar ist, aber keine dedizierte fette Schriftart besitzt, siehe [Umgang mit Schriftarten ohne dedizierte fette Schriftart](/slides/de/php-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Dieser Abschnitt erklärt, wie der betroffene Text beim PDF‑Export gerastert wird und welche Konsequenzen dies für Textauswahl, Suche und Skalierung hat.

## **Schriftart-Ersetzungen abrufen**

Verwenden Sie die Methode [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/), um zu bestimmen, welche Schriftarten ersetzt werden, wenn die Präsentation gerendert wird. Die Methode gibt [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/)-Objekte zurück, die die ursprünglichen und ersetzten Schriftartnamen identifizieren.

Das folgende PHP-Beispiel listet alle Schriftart‑Ersetzungen für eine Präsentation auf:

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

## **Schriftart‑Ersetzungen für ausgewählte Folien abrufen**

Verwenden Sie die Überladung von [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) mit einem `int[] slides`-Argument, um nur die Ersetzungen zu prüfen, die zum Rendern bestimmter Folien erforderlich sind. Dies ist nützlich, wenn Sie einen Teil einer Präsentation rendern oder exportieren, eine große Präsentation schrittweise prüfen, Folien auffinden, die von nicht verfügbaren Schriftarten abhängen, ein minimales Schriftartenpaket für einen Server oder Container vorbereiten oder Rendering‑Unterschiede diagnostizieren, ohne nicht relevante Folien zu verarbeiten.

Das Array `slides` enthält einbasiert nummerierte Folienindizes: `1` bezeichnet die erste Folie. Im Gegensatz dazu verwendet der Zugriff [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) auf die Sammlung nullbasierte Indizierung, sodass dieselbe Folie über `$presentation->getSlides()->get_Item(0)` aufgerufen wird. Berücksichtigen Sie diesen Unterschied beim Erstellen des Arrays, um Off‑by‑One‑Fehler zu vermeiden.

Rufen Sie die Überladung über die Methode [Presentation::getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getfontsmanager/) auf. Sie gibt nur die beim Rendern der ausgewählten Folien ermittelten Ersetzungen zurück. Jeder Eintrag ist ein [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/)-Objekt, das die ursprünglichen und ersetzten Schriftartnamen enthält. Das Ergebnis spiegelt die aktuelle Schriftumgebung, konfigurierte Fallback‑Regeln, in einer [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/) gespeicherte Ersetzungsregeln sowie [extern geladene Schriftarten](/slides/de/php-java/custom-font/) wider.

Die gleiche Ersetzung kann von mehr als einer ausgewählten Folie benötigt werden. Entfernen Sie Duplikate aus den Ergebnissen, wenn Sie ein Schriftarteninventar oder einen Preflight‑Bericht erstellen. Das folgende Beispiel gibt jede zurückgegebene Ersetzung aus und erstellt anschließend eine sortierte Liste eindeutiger Schriftartenzuordnungen:

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

Die Klasse [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/) stellt beide Überladungen bereit. Wählen Sie eine entsprechend dem Umfang des Rendering‑Vorgangs aus:

| Überladung | Verwenden, wenn |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) mit keinen Argumenten | Sie benötigen Ersetzungen für die gesamte Präsentation. |
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) mit `int[] slides` | Sie benötigen Ersetzungen für einen ausgewählten Bereich, eine inkrementelle Prüfung oder einen Teil‑Export. |

## **Schriftart‑Ersetzungsregeln festlegen**

Um die Schriftart anzugeben, die Aspose.Slides verwenden soll, wenn eine Quellschriftart nicht verfügbar ist:

1. Laden Sie die Präsentation.
2. Erstellen Sie Schriftartdefinitionen für die Quell- und Ersatzschriftarten.
3. Erstellen Sie eine [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/) mit der Bedingung [WhenInaccessible](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstcondition/).
4. Fügen Sie die Regel zu einer [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/) hinzu.
5. Weisen Sie die Sammlung mithilfe der Methode [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/) zu.
6. Rendern oder konvertieren Sie die Präsentation.

Das folgende PHP-Beispiel ersetzt `Arial` durch `SomeRareFont`, wenn `SomeRareFont` nicht verfügbar ist, und rendert anschließend die erste Folie, um das Ergebnis zu überprüfen. Die Ersatzschriftart muss für Aspose.Slides verfügbar sein.

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

{{% alert color="info" title="Note" %}}
Für eine bedingungslose Änderung der in einer gesamten Präsentation verwendeten Schriftarten siehe [Schriftart‑Ersetzung](/slides/de/php-java/font-replacement/).
{{% /alert %}}

## **Einschränkungen für mathematische Gleichungs‑Schriftarten**

Schriftart‑Ersetzungsregeln sind Teil des standardmäßigen Schriftartauswahlprozesses, der beim Rendern und Konvertieren verwendet wird. Sie funktionieren für normalen Text, wenn Aspose.Slides eine nicht zugängliche Schriftart durch die in einer Regel angegebene verfügbare Schriftart ersetzen kann.

Office‑Math‑Gleichungen haben eine zusätzliche Anforderung. Verwendet eine Gleichung **Cambria Math**, kann Aspose.Slides diese genaue Schriftart benötigen, um das Layout der Gleichung zu berechnen und zu rendern. Eine Regel, die eine andere mathematische Schriftart, z. B. **STIX Two Math**, ersetzt, kann **Cambria Math** zu diesem Zweck nicht ersetzen, und das Rendering kann weiterhin melden, dass **Cambria Math** erforderlich ist.

Um eine solche Präsentation zu rendern oder zu konvertieren, stellen Sie **Cambria Math** Aspose.Slides zur Verfügung. Installieren Sie sie im Betriebssystem oder laden Sie sie als [externe Schriftart](/slides/de/php-java/custom-font/).

Diese Einschränkung gilt für das Gleichungs‑Layout. Die oben beschriebenen Ersetzungsregeln gelten weiterhin für normalen Präsentationstext.

## **FAQ**

**Was ist der Unterschied zwischen Schriftart‑Austausch und Schriftart‑Ersetzung?**

[Schriftart‑Austausch](/slides/de/php-java/font-replacement/) ändert absichtlich eine Schriftart im gesamten Dokument in eine andere. Schriftart‑Ersetzung wählt eine Schriftart für die gerenderte Ausgabe aus, wenn die konfigurierte Bedingung erfüllt ist, z. B. wenn die Originalschriftart nicht verfügbar ist.

**Wann werden Ersetzungsregeln angewendet?**

Die Regeln nehmen an der [Schriftartauswahlsequenz](/slides/de/php-java/font-selection-sequence/) während des Renderns und der Konvertierung teil. Bei `WhenInaccessible` wird eine Regel nur verwendet, wenn Aspose.Slides nicht auf die Quellschriftart zugreifen kann.

**Was passiert, wenn eine Schriftart fehlt und keine Ersetzungsregel konfiguriert ist?**

Aspose.Slides wählt die am nächsten liegende verfügbare Schriftart gemäß seinem Schriftartauswahlprozess aus. Das Ergebnis hängt von den im Laufzeitumfeld verfügbaren Schriftarten ab.

**Kann ich externe Schriftarten laden, um Ersetzungen zu vermeiden?**

Ja. Sie können [externe Schriftarten laden](/slides/de/php-java/custom-font/), damit Aspose.Slides sie beim Rendern und Konvertieren verwenden kann.

**Verteilt Aspose Schriftarten mit der Bibliothek?**

Nein. Sie sind dafür verantwortlich, Schriftarten bereitzustellen und deren Lizenzen einzuhalten.

**Können sich Ersetzungsergebnisse zwischen Windows, Linux und macOS unterscheiden?**

Ja. Installierte Schriftarten und Suchpfade für Schriftarten unterscheiden sich je nach Betriebssystem, sodass eine auf einem Rechner verfügbare Schriftart auf einem anderen möglicherweise ersetzt werden muss.

**Wie kann ich die Schriftartauswahl bei Batch‑Konvertierungen konsistent halten?**

Verwenden Sie dieselben Schriftdateien und -versionen auf jedem Rechner oder Container, [laden Sie erforderliche externe Schriftarten](/slides/de/php-java/custom-font/) und [betten Sie Schriftarten ein](/slides/de/php-java/embedded-font/), wenn die Lizenz dies erlaubt. Sie können außerdem vor dem Export [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) aufrufen, um unerwartete Ersetzungen zu identifizieren.