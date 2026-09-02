---
title: Automatisieren der Präsentationslokalisierung in PHP
linktitle: Präsentationslokalisierung
type: docs
weight: 100
url: /de/php-java/presentation-localization/
keywords:
- Sprache ändern
- Rechtschreibprüfung
- Rechtschreibprüfung unterdrücken
- Korrektursprache
- Sprach-ID
- mehrsprachiger Text
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Legen Sie Korrektursprachen für PowerPoint- und OpenDocument-Präsentationstexte in PHP mit Aspose.Slides fest, inklusive Standardwerte und mehrsprachiger Absätze."
---
## **Übersicht**

Aspose.Slides for PHP via Java ermöglicht das Konfigurieren von Korrektureinstellungen für einzelne Textanteile. Verwenden Sie [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseportionformat/#setLanguageId), um die Korrektursprache zu bestimmen, [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseportionformat/#setSpellCheck), um Rechtschreibprüfungen zuzulassen oder zu unterdrücken, und [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseportionformat/#setProofDisabled), um den allgemeineren „nicht prüfen“-Zustand zu steuern. Da diese Einstellungen auf Portionsebene angewendet werden, kann ein Absatz mehrere Sprachen und unterschiedliche Korrekturregeln enthalten.

Dieser Artikel erklärt, wie man einer bestimmten Textportion eine Sprache zuweist, die Standardsprache für neuen Text mit [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) festlegt, mehrsprachige Absätze erstellt, zwischen `SpellCheck` und `ProofDisabled` wählt und die beabsichtigten Einstellungen beibehält, wenn [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) verwendet wird. Diese Eigenschaften speichern Metadaten für Präsentationsanwendungen; sie übersetzen keinen Text, führen keine wortschatzbasierte Rechtschreibprüfung durch und geben keine falsch geschriebenen Wörter zurück.

## **Festlegen der Korrektursprache für Text**

Erstellen oder laden Sie eine [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/), greifen Sie über [Portion::getPortionFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/portion/#getPortionFormat) auf den gewünschten Textanteil zu und weisen Sie dessen Sprachkennzeichen zu. Das folgende Beispiel erstellt eine Form, setzt Britisches Englisch als Korrektursprache und speichert das Ergebnis mit [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#save):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Set the proofing language for this text.");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLanguageId("en-GB");

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Festlegen der Standardsprache für neuen Text**

Verwenden Sie [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), um die Korrektursprache festzulegen, die Aspose.Slides neu erstelltem Text zuweist. Diese Einstellung ist nützlich, wenn der Großteil oder der gesamte neue Text in einer Präsentation dieselbe Sprache verwendet. Sie ändert nicht die Sprachmetadaten von Text, der bereits eine explizite Sprache hat.

Das folgende Beispiel erstellt eine Präsentation, deren neuer Text deutsche Korrekturregeln verwendet:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("de-DE");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Willkommen zur Präsentation");

    $presentation->save("default_text_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Mehrere Sprachen in einem Absatz verwenden**

Ein [Paragraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraph/) enthält eine Sammlung von Textanteilen. Erstellen Sie für jede Sprache einen separaten [Portion](https://reference.aspose.com/slides/de/php-java/aspose.slides/portion/) und setzen Sie dessen `LanguageId` unabhängig.

Dieses Beispiel erstellt einen Absatz mit englischen und französischen Anteilen:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $englishPortion = new Portion("Welcome");
    $englishPortion->getPortionFormat()->setLanguageId("en-US");
    $paragraph->getPortions()->add($englishPortion);

    $frenchPortion = new Portion(" — Bienvenue");
    $frenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $paragraph->getPortions()->add($frenchPortion);

    $presentation->save("multilingual_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Rechtschreibprüfung für einzelne Portionen aktivieren oder unterdrücken**

[PortionFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/portionformat/) erbt die gemeinsamen Texteigenschaften, die von [BasePortionFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseportionformat/) definiert werden. Greifen Sie über [Portion::getPortionFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/portion/#getPortionFormat) auf das Format einer Portion zu und verwenden Sie [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseportionformat/#setSpellCheck), um zu steuern, ob eine Präsentationsanwendung die Rechtschreibung für diese Portion prüft. Der Standardwert ist `false`: `true` erlaubt die Rechtschreibprüfung, während `false` sie unterdrückt.

Die Einstellung gilt für einzelne Textanteile. Unterschiedliche Portionen im selben Absatz können daher unterschiedliche Werte besitzen. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseportionformat/#setLanguageId) und `setSpellCheck` erfüllen komplementäre Zwecke: `setLanguageId` legt die Korrektursprache fest, `setSpellCheck` bestimmt, ob Rechtschreibprüfungen für die Portion zulässig sind.

[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseportionformat/#setProofDisabled) steuert ebenfalls das Korrekturen, stellt jedoch den umfassenderen „nicht prüfen“-Zustand als [NullableBool](https://reference.aspose.com/slides/de/php-java/aspose.slides/nullablebool/) dar. Verwenden Sie `setSpellCheck`, wenn Sie einen direkten booleschen Schalter ausschließlich für die Rechtschreibprüfung benötigen. Verwenden Sie `setProofDisabled`, wenn Sie die „keine Korrektur“-Metadaten der Präsentation, einschließlich ihres `NotDefined`‑Zustands, erhalten oder explizit steuern wollen. Wenn Sie beide Eigenschaften setzen, halten Sie deren Werte konsistent; kombinieren Sie nicht `setSpellCheck(true)` mit `setProofDisabled(NullableBool::True)`.

Diese Eigenschaften konfigurieren Korrekture‑Metadaten, die von PowerPoint und anderen Präsentationsanwendungen verwendet werden. Aspose.Slides nutzt sie nicht zur Ausführung einer wortschatzbasierten Rechtschreibprüfung oder zur Rückgabe einer Liste falsch geschriebener Wörter.

Das folgende vollständige Beispiel erstellt eine Eingabepäsentation, lädt sie, weist zwei Portionen im selben Absatz unterschiedliche Rechtschreib‑ und Korrektureinstellungen zu, speichert das Ergebnis, öffnet es erneut und überprüft die gespeicherten Werte:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$inputFile = "spell_check_input.pptx";
$outputFile = "spell_check_settings.pptx";

$sourcePresentation = new Presentation();
try {
    $sourceSlide = $sourcePresentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $sourceParagraph = $sourceShape->getTextFrame()->getParagraphs()->get_Item(0);
    $sourceParagraph->getPortions()->clear();

    $sourceEnglishPortion = new Portion("Check this text. ");
    $sourceEnglishPortion->getPortionFormat()->setLanguageId("en-US");
    $sourceParagraph->getPortions()->add($sourceEnglishPortion);

    $sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    $sourceFrenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $sourceParagraph->getPortions()->add($sourceFrenchPortion);

    $sourcePresentation->save($inputFile, SaveFormat::Pptx);
} finally {
    $sourcePresentation->dispose();
}

$presentation = new Presentation($inputFile);
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portions = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $checkedPortion = $portions->get_Item(0);
    $checkedPortion->getPortionFormat()->setLanguageId("en-US");
    $checkedPortion->getPortionFormat()->setSpellCheck(true);

    $suppressedPortion = $portions->get_Item(1);
    $suppressedPortion->getPortionFormat()->setLanguageId("fr-FR");
    $suppressedPortion->getPortionFormat()->setSpellCheck(false);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $storedPortions = $reopenedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $storedPortionCount = java_values($storedPortions->getCount());
    $firstStoredFormat = $storedPortions->get_Item(0)->getPortionFormat();
    $secondStoredFormat = $storedPortions->get_Item(1)->getPortionFormat();

    $firstPortionStored = $storedPortionCount === 2 && 
        java_values($firstStoredFormat->getLanguageId()) === "en-US" && 
        java_values($firstStoredFormat->getSpellCheck());

    $secondPortionStored = $storedPortionCount === 2 && 
        java_values($secondStoredFormat->getLanguageId()) === "fr-FR" && 
        !java_values($secondStoredFormat->getSpellCheck());

    if ($firstPortionStored && $secondPortionStored) {
        echo "The proofing settings were stored correctly.";
    } else {
        echo "The proofing settings could not be verified.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) kombiniert benachbarte Portionen, die dieselbe Formatierung besitzen. Ein Unterschied allein im `SpellCheck` reicht nicht aus, um solche Portionen getrennt zu halten; nach dem Zusammenführen behält die resultierende Portion den `SpellCheck`‑Wert der ersten Portion. Wenn Portionen unterschiedliche Rechtschreib‑Einstellungen benötigen, rufen Sie `joinPortionsWithSameFormatting` vor dem Setzen dieser Einstellungen auf oder prüfen Sie die resultierenden Portionengrenzen und setzen die Einstellungen anschließend erneut. Portionen mit unterschiedlichen `LanguageId`‑Werten bleiben getrennt, da ihre Korrektursprache‑Formatierung abweicht.

## **FAQ**

**Wird durch eine Sprach‑ID der Text übersetzt?**

Nein. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseportionformat/#setLanguageId) speichert Korrekture‑Metadaten für Rechtschreibung und Grammatik; sie ändert nicht den Textinhalt. Übersetzen Sie den Text separat und setzen Sie anschließend für jede übersetzte Portion das passende Sprachkennzeichen.

**Steuert die Korrektursprache Schriftarten, Silbentrennung oder Zeilenumbruch?**

Nein. Die Sprach‑ID dient nur der Korrektur. Textdarstellung und Layout hängen primär von den verfügbaren [fonts](/slides/de/php-java/powerpoint-fonts/), dem Schriftsystem und den Einstellungen des Textfeldes ab. Stellen Sie für ein zuverlässiges Rendering die erforderlichen Schriftarten bereit, konfigurieren Sie [font substitution](/slides/de/php-java/font-substitution/) oder [embed fonts](/slides/de/php-java/embedded-font/) in der Präsentation.

**Kann ein Absatz mehrere Korrektursprachen verwenden?**

Ja. Weisen Sie jeder Sprache eine separate Portion zu, wie im mehrsprachigen Absatz‑Beispiel gezeigt.

**Sollte ich `setDefaultTextLanguage` oder `setLanguageId` verwenden?**

Verwenden Sie [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), wenn Sie einen Standard für neu erstellten Text wünschen. Verwenden Sie [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseportionformat/#setLanguageId), wenn eine bestimmte Portion eine explizite Korrektursprache benötigt oder ein Absatz mehrere Sprachen enthält.