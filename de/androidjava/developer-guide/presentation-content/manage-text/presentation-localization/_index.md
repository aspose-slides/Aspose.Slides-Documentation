---
title: Automatisieren der Präsentationslokalisierung auf Android
linktitle: Präsentationslokalisierung
type: docs
weight: 100
url: /de/androidjava/presentation-localization/
keywords:
- Sprache ändern
- Rechtschreibprüfung
- Rechtschreibprüfung unterdrücken
- Korrektursprache
- Sprach-ID
- mehrsprachiger Text
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Legt Korrektursprachen für PowerPoint- und OpenDocument-Präsentationstexte auf Android mit Aspose.Slides für Android via Java fest, einschließlich Vorgaben und mehrsprachiger Absätze."
---
## **Übersicht**

Aspose.Slides for Android via Java ermöglicht das Konfigurieren von Korrektur‑Metadaten für einzelne Textabschnitte. Verwenden Sie [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) um die Korrektursprache zu bestimmen, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) um Rechtschreibprüfungen zuzulassen oder zu unterdrücken und [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) um den übergeordneten „Kein‑Korrektur‑“‑Zustand zu steuern. Da diese Einstellungen auf Abschnittsebene angewendet werden, kann ein Absatz mehrere Sprachen und unterschiedliche Korrekturrichtlinien enthalten.

Dieser Artikel erklärt, wie Sie einer bestimmten Textstelle eine Sprache zuweisen, die Standardsprache für neuen Text mit [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) festlegen, mehrsprachige Absätze erstellen, zwischen `SpellCheck` und `ProofDisabled` wählen und die gewünschten Einstellungen beim Verwenden von [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) beibehalten. Diese Eigenschaften speichern Metadaten für Präsentationsanwendungen; sie übersetzen den Text nicht, führen keine wörterbuchbasierte Rechtschreibprüfung durch und geben keine falschen Wörter zurück.

## **Proofsprache für Text festlegen**

Erstellen oder laden Sie eine [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/), greifen Sie über [IPortion.getPortionFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportion/#getPortionFormat--) auf den gewünschten Textabschnitt zu und weisen Sie dessen Sprachkennzeichen zu. Das folgende Beispiel erstellt eine Form, legt Britisches Englisch als Korrektursprache fest und speichert das Ergebnis mit [Presentation.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-):

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IPortion;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Standardsprache für neuen Text festlegen**

Verwenden Sie [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), um die Korrektursprache anzugeben, die Aspose.Slides neu erstelltem Text zuweist. Diese Einstellung ist nützlich, wenn die meisten oder alle neuen Texte in einer Präsentation dieselbe Sprache verwenden. Sie ändert nicht die Sprachmetadaten von Text, der bereits eine explizite Sprache hat.

Das folgende Beispiel erstellt eine Präsentation, deren neuer Text deutsche Korrekturregeln verwendet:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mehrere Sprachen in einem Absatz verwenden**

Ein [IParagraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraph/) enthält eine Sammlung von Textabschnitten. Erstellen Sie für jede Sprache einen separaten [Portion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/portion/) und setzen Sie dessen `LanguageId` unabhängig.

Dieses Beispiel erstellt einen Absatz mit englischen und französischen Abschnitten:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion englishPortion = new Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    Portion frenchPortion = new Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rechtschreibprüfung für einzelne Abschnitte aktivieren oder unterdrücken**

[IPortionFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportionformat/) erbt die allgemeinen Texteigenschaften von [IBasePortionFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseportionformat/). Greifen Sie über [IPortion.getPortionFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportion/#getPortionFormat--) auf das Format eines Abschnitts zu und verwenden Sie [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-), um zu steuern, ob eine Präsentationsanwendung die Rechtschreibung für diesen Abschnitt prüfen darf. Der Standardwert ist `false`: `true` erlaubt die Rechtschreibprüfung, während `false` sie unterdrückt.

Die Einstellung gilt für einzelne Textabschnitte. Unterschiedliche Abschnitte im selben Absatz können daher unterschiedliche Werte haben. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) und `setSpellCheck` erfüllen komplementäre Aufgaben: `setLanguageId` identifiziert die Korrektursprache, während `setSpellCheck` bestimmt, ob Rechtschreibprüfungen für den Abschnitt erlaubt sind.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) steuert ebenfalls die Korrektur, repräsentiert jedoch den umfassenderen „nicht korrigieren“‑Zustand als [NullableBool](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/nullablebool/). Verwenden Sie `setSpellCheck`, wenn Sie einen direkten booleschen Schalter ausschließlich für Rechtschreibprüfungen benötigen. Verwenden Sie `setProofDisabled`, wenn Sie die „Kein‑Korrektur“‑Metadaten der Präsentation erhalten oder explizit steuern wollen, einschließlich des `NotDefined`‑Zustands. Wenn Sie beide Eigenschaften setzen, halten Sie deren Werte konsistent; kombinieren Sie nicht `setSpellCheck(true)` mit `setProofDisabled(NullableBool.True)`.

Diese Eigenschaften konfigurieren Korrektur‑Metadaten, die von PowerPoint und anderen Präsentationsanwendungen genutzt werden. Aspose.Slides verwendet sie nicht, um wörterbuchbasierte Rechtschreibprüfungen durchzuführen oder eine Liste falscher Wörter zurückzugeben.

Das folgende vollständige Beispiel erstellt eine Eingabepräsentation, lädt sie, weist zwei Abschnitten im selben Absatz unterschiedliche Rechtschreibprüfungs‑ und Korrekturspracheinstellungen zu, speichert das Ergebnis, öffnet es erneut und prüft die gespeicherten Werte:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.IPortion;
import com.aspose.slides.IPortionCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

String inputFile = "spell_check_input.pptx";
String outputFile = "spell_check_settings.pptx";

Presentation sourcePresentation = new Presentation();
try {
    ISlide sourceSlide = sourcePresentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    Portion sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    Portion sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

Presentation presentation = new Presentation(inputFile);
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    IPortion checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    IPortion suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    IAutoShape reopenedShape = (IAutoShape) reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    boolean firstPortionStored = storedPortions.getCount() == 2 &&
            "en-US".equals(storedPortions.get_Item(0).getPortionFormat().getLanguageId()) &&
            storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    boolean secondPortionStored = storedPortions.getCount() == 2 &&
            "fr-FR".equals(storedPortions.get_Item(1).getPortionFormat().getLanguageId()) &&
            !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        System.out.println("The proofing settings were stored correctly.");
    } else {
        System.out.println("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) kombiniert benachbarte Abschnitte, die dieselbe Formatierung besitzen. Ein Unterschied nur im `SpellCheck` reicht nicht aus, um solche Abschnitte getrennt zu halten; nach dem Zusammenführen behält der resultierende Abschnitt den `SpellCheck`‑Wert des ersten Abschnitts. Wenn Abschnitte unterschiedliche Rechtschreib‑Einstellungen benötigen, rufen Sie `joinPortionsWithSameFormatting` auf, bevor Sie diese Einstellungen zuweisen, oder prüfen Sie die resultierenden Abschnittsgrenzen und setzen die Einstellungen danach erneut. Abschnitte mit unterschiedlichen `LanguageId`‑Werten bleiben getrennt, weil ihre Korrektur‑Sprachformatierung verschieden ist.

## **FAQ**

**Wird durch eine Sprach‑ID der Text übersetzt?**

Nein. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) speichert Korrektur‑Metadaten für Rechtschreibung und Grammatik; sie ändert nicht den Textinhalt. Übersetzen Sie den Text separat und setzen Sie anschließend das passende Sprach‑Kennzeichen für jeden übersetzten Abschnitt.

**Steuert die Korrektursprache Schriftarten, Silbentrennung oder Zeilenumbruch?**

Nein. Die Sprach‑ID dient ausschließlich der Korrektur. Textdarstellung und Layout hängen hauptsächlich von den verfügbaren [fonts](/slides/de/androidjava/powerpoint-fonts/), dem Schriftsystem und den Einstellungen des Text‑Frames ab. Für zuverlässige Darstellung stellen Sie die erforderlichen Schriftarten bereit, konfigurieren Sie die [font substitution](/slides/de/androidjava/font-substitution/) oder betten Sie [fonts](/slides/de/androidjava/embedded-font/) in die Präsentation ein.

**Kann ein Absatz mehrere Korrektursprachen verwenden?**

Ja. Weisen Sie jeder Sprache einen separaten Abschnitt zu, wie im mehrsprachigen Absatz‑Beispiel gezeigt.

**Soll ich `setDefaultTextLanguage` oder `setLanguageId` verwenden?**

Verwenden Sie [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), wenn Sie eine Vorgabe für neu erstellten Text benötigen. Verwenden Sie [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), wenn ein bestimmter Abschnitt eine explizite Korrektursprache benötigt oder ein Absatz mehrere Sprachen enthält.