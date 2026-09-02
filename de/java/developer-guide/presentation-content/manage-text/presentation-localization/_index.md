---
title: Präsentationslokalisierung in Java automatisieren
linktitle: Präsentationslokalisierung
type: docs
weight: 100
url: /de/java/presentation-localization/
keywords:
- Sprache ändern
- Rechtschreibprüfung
- Rechtschreibprüfung unterdrücken
- Korrektursprache
- Sprach-ID
- mehrsprachiger Text
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Legen Sie Korrektursprachen für PowerPoint- und OpenDocument-Präsentationstexte in Java mit Aspose.Slides fest, einschließlich Vorgaben und mehrsprachiger Absätze."
---
## **Übersicht**

Aspose.Slides for Java ermöglicht es Ihnen, Korrekturdaten für einzelne Textabschnitte zu konfigurieren. Verwenden Sie [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) um die Korrektursprache zu bestimmen, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) um Rechtschreibprüfungen zu aktivieren oder zu unterdrücken, und [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) um den umfassenderen „nicht prüfen“-Zustand zu steuern. Da diese Einstellungen auf Portionsebene angewendet werden, kann ein Absatz mehrere Sprachen und unterschiedliche Korrekturregeln enthalten.

Dieser Artikel erklärt, wie Sie einer bestimmten Textstelle eine Sprache zuweisen, die Standardsprache für neuen Text mit [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) festlegen, mehrsprachige Absätze erstellen, zwischen `SpellCheck` und `ProofDisabled` wählen und die beabsichtigten Einstellungen beim Aufruf von [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) beibehalten. Diese Eigenschaften speichern Metadaten für Präsentationsanwendungen; sie übersetzen den Text nicht, führen keine wörterbuchbasierte Rechtschreibprüfung durch und geben keine falsch geschriebenen Wörter zurück.

## **Korrektursprache für Text festlegen**

Erstellen oder laden Sie eine [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/), greifen Sie über [IPortion.getPortionFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/iportion/#getPortionFormat--) auf die gewünschte Textportion zu und weisen Sie ihr den Sprachbezeichner zu. Das folgende Beispiel erstellt eine Form, legt Britisches Englisch als Korrektursprache fest und speichert das Ergebnis mit [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-):

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

## **Standard‑Sprache für neuen Text festlegen**

Verwenden Sie [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), um die Korrektursprache anzugeben, die Aspose.Slides neu erstelltem Text zuweist. Diese Einstellung ist nützlich, wenn der größte Teil oder der gesamte neue Text in einer Präsentation dieselbe Sprache verwendet. Sie ändert nicht die Sprachmetadaten von Text, der bereits eine explizite Sprache hat.

Das folgende Beispiel erstellt eine Präsentation, bei der neuer Text die deutschen Korrekturrechen verwendet:

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

Ein [IParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraph/) enthält eine Sammlung von Textportionen. Erstellen Sie für jede Sprache eine separate [Portion](https://reference.aspose.com/slides/de/java/com.aspose.slides/portion/) und setzen Sie deren `LanguageId` unabhängig voneinander.

Dieses Beispiel erstellt einen Absatz mit englischen und französischen Portionen:

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

## **Rechtschreibprüfung für einzelne Portionen aktivieren oder unterdrücken**

[IPortionFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/iportionformat/) erbt die allgemeinen Texteigenschaften, die von [IBasePortionFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseportionformat/) definiert werden. Greifen Sie über [IPortion.getPortionFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/iportion/#getPortionFormat--) auf das Format einer Portion zu und verwenden Sie [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-), um zu steuern, ob eine Präsentationsanwendung die Rechtschreibung für diese Portion prüfen darf. Der Standardwert ist `false`: `true` erlaubt die Rechtschreibprüfung, während `false` sie unterdrückt.

Die Einstellung gilt für einzelne Textportionen. Unterschiedliche Portionen im selben Absatz können daher unterschiedliche Werte verwenden. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) und `setSpellCheck` dienen komplementären Zwecken: `setLanguageId` bestimmt die Korrektursprache, während `setSpellCheck` festlegt, ob Rechtschreibprüfungen für die Portion zulässig sind.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) steuert ebenfalls die Korrektur, repräsentiert jedoch den umfassenderen „nicht prüfen“-Zustand als [NullableBool](https://reference.aspose.com/slides/de/java/com.aspose.slides/nullablebool/). Verwenden Sie `setSpellCheck`, wenn Sie einen direkten booleschen Schalter speziell für Rechtschreibprüfungen benötigen. Verwenden Sie `setProofDisabled`, wenn Sie die „keine Korrektur“-Metadaten der Präsentation, einschließlich ihres `NotDefined`‑Zustands, erhalten oder explizit steuern müssen. Wenn Sie beide Eigenschaften setzen, halten Sie ihre Werte konsistent; kombinieren Sie nicht `setSpellCheck(true)` mit `setProofDisabled(NullableBool.True)`.

Diese Eigenschaften konfigurieren Korrekturdaten, die von PowerPoint und anderen Präsentationsanwendungen verwendet werden. Aspose.Slides nutzt sie nicht, um wörterbuchbasierte Rechtschreibprüfungen auszuführen oder eine Liste falscher Wörter zurückzugeben.

Das folgende vollständige Beispiel erstellt eine Eingabepräsentation, lädt sie, weist zwei Portionen im selben Absatz unterschiedliche Rechtschreibprüfungseinstellungen und Korrektursprachen zu, speichert das Ergebnis, öffnet es erneut und prüft die gespeicherten Werte:

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

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) verbindet benachbarte Portionen, die dieselbe Formatierung besitzen. Ein Unterschied allein in `SpellCheck` reicht nicht aus, um solche Portionen getrennt zu halten; nach dem Zusammenführen behält die resultierende Portion den `SpellCheck`‑Wert der ersten Portion. Wenn Portionen unterschiedliche Rechtschreibprüfungseinstellungen benötigen, rufen Sie `joinPortionsWithSameFormatting` vor dem Setzen dieser Einstellungen auf oder prüfen Sie die resultierenden Portionsgrenzen und wenden die Einstellungen anschließend erneut an. Portionen mit unterschiedlichen `LanguageId`‑Werten bleiben getrennt, da ihre Korrektur‑Sprachformatierung unterschiedlich ist.

## **FAQ**

**Wandelt eine Sprach-ID den Text um?**

Nein. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) speichert Korrekturdaten für Rechtschreibung und Grammatik; es ändert nicht den Textinhalt. Übersetzen Sie den Text separat und setzen Sie anschließend den passenden Sprachbezeichner für jede übersetzte Portion.

**Steuert die Korrektursprache Schriftarten, Silbentrennung oder Zeilenumbruch?**

Nein. Der Sprachbezeichner dient ausschließlich der Korrektur. Die Textdarstellung und das Layout hängen hauptsächlich von den verfügbaren [fonts](/slides/de/java/powerpoint-fonts/), dem Schriftsystem und den Textebeneneinstellungen ab. Für eine zuverlässige Darstellung stellen Sie die erforderlichen Schriftarten bereit, konfigurieren Sie die [font substitution](/slides/de/java/font-substitution/), oder betten Sie Schriften mit [embed fonts](/slides/de/java/embedded-font/) in die Präsentation ein.

**Kann ein Absatz mehrere Korrektursprachen verwenden?**

Ja. Ordnen Sie jeder Sprache eine separate Portion zu, wie im Beispiel für mehrsprachige Absätze gezeigt.

**Soll ich `setDefaultTextLanguage` oder `setLanguageId` verwenden?**

Verwenden Sie [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), wenn Sie einen Standard für neu erstellten Text festlegen möchten. Verwenden Sie [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), wenn eine bestimmte Portion eine explizite Korrektursprache benötigt oder wenn ein Absatz mehrere Sprachen enthält.