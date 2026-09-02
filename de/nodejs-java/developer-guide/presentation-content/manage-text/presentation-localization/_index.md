---
title: Präsentationslokalisierung in JavaScript automatisieren
linktitle: Präsentationslokalisierung
type: docs
weight: 100
url: /de/nodejs-java/presentation-localization/
keywords:
- Sprache ändern
- Rechtschreibprüfung
- Rechtschreibprüfung unterdrücken
- Korrektursprache
- Sprach-ID
- mehrsprachiger Text
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Legen Sie Korrektursprachen für PowerPoint- und OpenDocument-Präsentationstexte in JavaScript mit Aspose.Slides fest, einschließlich Vorgaben und mehrsprachigen Absätzen."
---
## **Übersicht**

Aspose.Slides für Node.js über Java ermöglicht das Konfigurieren von Korrektur‑Metadaten für einzelne Textabschnitte. Verwenden Sie [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) um die Korrektursprache zu bestimmen, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) um Rechtschreibprüfungen zuzulassen oder zu unterdrücken und [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) um den umfassenderen „kein‑Proof“‑Zustand zu steuern. Da diese Einstellungen auf Abschnittsebene angewendet werden, kann ein Absatz mehrere Sprachen und unterschiedliche Korrekturregeln enthalten.

Dieser Artikel erklärt, wie man einer bestimmten Textstelle eine Sprache zuweist, die Standardsprache für neuen Text mit [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) festlegt, mehrsprachige Absätze erstellt, zwischen `SpellCheck` und `ProofDisabled` wählt und die beabsichtigten Einstellungen beibehält, wenn [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) verwendet wird. Diese Eigenschaften speichern Metadaten für Präsentationsanwendungen; sie übersetzen keinen Text, führen keine wörterbuchbasierte Rechtschreibprüfung durch und geben keine falsch geschriebenen Wörter zurück.

## **Korrektursprache für Text festlegen**

Erstellen oder laden Sie eine [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/), greifen Sie über [Portion.getPortionFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/#getPortionFormat--) auf den gewünschten Textabschnitt zu und weisen Sie dessen Sprachbezeichner zu. Das folgende Beispiel erstellt eine Form, legt Britisches Englisch als Korrektursprache fest und speichert das Ergebnis mit [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Standardsprache für neuen Text festlegen**

Verwenden Sie [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), um die Korrektursprache anzugeben, die Aspose.Slides neu erstelltem Text zuweist. Diese Einstellung ist nützlich, wenn die meisten oder alle neuen Texte in einer Präsentation dieselbe Sprache verwenden. Sie ändert nicht die Sprachmetadaten von Text, der bereits eine explizite Sprache hat.

Das folgende Beispiel erstellt eine Präsentation, bei der neuer Text deutsche Korrekturregeln verwendet:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mehrere Sprachen in einem Absatz verwenden**

Ein [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/) enthält eine Sammlung von Textabschnitten. Erstellen Sie für jede Sprache einen eigenen [Portion](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/) und setzen Sie dessen `LanguageId` unabhängig.

Dieses Beispiel erstellt einen Absatz mit englischen und französischen Abschnitten:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rechtschreibprüfung für einzelne Abschnitte aktivieren oder unterdrücken**

[PortionFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portionformat/) erbt die gemeinsamen Texteigenschaften, die von [BasePortionFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseportionformat/) definiert werden. Greifen Sie über [Portion.getPortionFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/#getPortionFormat--) auf das Format eines Abschnitts zu und verwenden Sie [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-), um zu steuern, ob eine Präsentationsanwendung die Rechtschreibung für diesen Abschnitt prüfen darf. Der Standardwert ist `false`: `true` erlaubt die Rechtschreibprüfung, während `false` sie unterdrückt.

Die Einstellung gilt für einzelne Textabschnitte. Unterschiedliche Abschnitte im selben Absatz können daher verschiedene Werte verwenden. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) und `setSpellCheck` erfüllen komplementäre Zwecke: `setLanguageId` identifiziert die Korrektursprache, während `setSpellCheck` bestimmt, ob Rechtschreibprüfungen für den Abschnitt erlaubt sind.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) steuert ebenfalls die Korrektur, repräsentiert jedoch den umfassenderen „nicht prüfen“‑Zustand als ein [NullableBool](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/nullablebool/). Verwenden Sie `setSpellCheck`, wenn Sie einen direkten booleschen Schalter speziell für Rechtschreibprüfungen benötigen. Verwenden Sie `setProofDisabled`, wenn Sie die No‑Proof‑Metadaten der Präsentation, einschließlich ihres `NotDefined`‑Zustands, erhalten oder explizit steuern möchten. Wenn Sie beide Eigenschaften setzen, halten Sie deren Werte konsistent; kombinieren Sie nicht `setSpellCheck(true)` mit `setProofDisabled(NullableBool.True)`.

Diese Eigenschaften konfigurieren Korrektur‑Metadaten, die von PowerPoint und anderen Präsentationsanwendungen verwendet werden. Aspose.Slides nutzt sie nicht, um wörterbuchbasierte Rechtschreibprüfungen durchzuführen oder eine Liste falsch geschriebener Wörter zurückzugeben.

Das folgende vollständige Beispiel erstellt eine Eingabe‑Präsentation, lädt sie, weist zwei Abschnitten im selben Absatz unterschiedliche Rechtschreib‑ und Korrektureinstellungen zu, speichert das Ergebnis, öffnet es erneut und überprüft die gespeicherten Werte:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) kombiniert benachbarte Abschnitte, die dieselbe Formatierung besitzen. Eine reine Unterschiedlichkeit im `SpellCheck` verhindert nicht das Zusammenführen; nach dem Zusammenführen behält der resultierende Abschnitt den `SpellCheck`‑Wert des ersten Abschnitts. Wenn Abschnitte unterschiedliche Rechtschreib‑Einstellungen benötigen, rufen Sie `joinPortionsWithSameFormatting` vor dem Setzen dieser Einstellungen auf oder prüfen Sie die resultierenden Abschnittsgrenzen und wenden die Einstellungen anschließend erneut an. Abschnitte mit unterschiedlichen `LanguageId`‑Werten bleiben getrennt, da ihre Korrektur‑Sprachformatierung verschieden ist.

## **FAQ**

**Wird durch eine Sprach‑ID der Text übersetzt?**

Nein. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) speichert Korrektur‑Metadaten für Rechtschreibung und Grammatik; sie ändert nicht den Textinhalt. Übersetzen Sie den Text separat und setzen Sie dann den entsprechenden Sprach‑Bezeichner für jeden übersetzten Abschnitt.

**Steuert die Korrektursprache Schriftarten, Silbentrennung oder Zeilenumbruch?**

Nein. Der Sprach‑Bezeichner dient nur der Korrektur. Die Textdarstellung und das Layout hängen primär von den verfügbaren [fonts](/slides/de/nodejs-java/powerpoint-fonts/), dem Schriftsystem und den Text‑Frame‑Einstellungen ab. Für eine zuverlässige Darstellung stellen Sie die benötigten Schriftarten bereit, konfigurieren Sie die [font substitution](/slides/de/nodejs-java/font-substitution/) oder betten Sie [fonts](/slides/de/nodejs-java/embedded-font/) in die Präsentation ein.

**Kann ein Absatz mehrere Korrektursprachen verwenden?**

Ja. Weisen Sie jeder Sprache einen separaten Abschnitt zu, wie im mehrsprachigen Absatz‑Beispiel gezeigt.

**Soll ich `setDefaultTextLanguage` oder `setLanguageId` verwenden?**

Verwenden Sie [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), wenn Sie einen Standard für neu erstellten Text festlegen möchten. Verwenden Sie [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-), wenn ein bestimmter Abschnitt eine explizite Korrektursprache benötigt oder ein Absatz mehrere Sprachen enthält.