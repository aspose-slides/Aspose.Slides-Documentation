---
title: Automatisieren der Präsentationslokalisierung in .NET
linktitle: Präsentationslokalisierung
type: docs
weight: 100
url: /de/net/presentation-localization/
keywords:
- Sprache ändern
- Rechtschreibprüfung
- Rechtschreibprüfung unterdrücken
- Korrektursprache
- Sprach-ID
- mehrsprachiger Text
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Legen Sie Korrektursprachen für PowerPoint- und OpenDocument-Präsentationstexte in .NET mit Aspose.Slides fest, inklusive Standards und mehrsprachiger Absätze."
---
## **Übersicht**

Aspose.Slides for .NET ermöglicht das Konfigurieren von Korrektur‑Metadaten für einzelne Textabschnitte. Verwenden Sie [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseportionformat/languageid/) , um die Korrektursprache zu bestimmen, [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/de/net/aspose.slides/baseportionformat/spellcheck/) , um Rechtschreibprüfungen zuzulassen oder zu unterdrücken, und [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/de/net/aspose.slides/baseportionformat/proofdisabled/) , um den allgemeinen „nicht prüfen“‑Zustand zu steuern. Da diese Einstellungen auf Abschnittsebene angewendet werden, kann ein Absatz mehrere Sprachen und unterschiedliche Korrekturregeln enthalten.

Dieser Artikel erklärt, wie Sie einer bestimmten Textstelle eine Sprache zuweisen, die Standardsprache für neuen Text mit [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/defaulttextlanguage/) festlegen, mehrsprachige Absätze erstellen, zwischen `SpellCheck` und `ProofDisabled` wählen und die beabsichtigten Einstellungen beim Verwenden von [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/joinportionswithsameformatting/) beibehalten. Diese Eigenschaften speichern Metadaten für Präsentations‑Anwendungen; sie übersetzen keinen Text, führen keine wörterbuchbasierte Rechtschreibprüfung durch und geben keine falsch geschriebenen Wörter zurück.

## **Korrektursprache für Text festlegen**

Erstellen oder laden Sie eine [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/), greifen Sie über [IPortion.PortionFormat](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/portionformat/) auf den gewünschten Textabschnitt zu und weisen Sie dessen Sprachkennung zu. Das folgende Beispiel erstellt eine Form, legt Britisches Englisch als Korrektursprache fest und speichert das Ergebnis mit [Presentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/) :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Set the proofing language for this text.";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LanguageId = "en-GB";

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Standard‑Sprache für neuen Text festlegen**

Verwenden Sie [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/defaulttextlanguage/) , um die Korrektursprache anzugeben, die Aspose.Slides neu erstelltem Text zuweist. Diese Einstellung ist nützlich, wenn die meisten oder alle neuen Texte in einer Präsentation dieselbe Sprache verwenden. Sie ändert nicht die Sprach‑Metadaten von Texten, die bereits eine explizite Sprache besitzen.

Das folgende Beispiel erstellt eine Präsentation, deren neuer Text deutsche Korrekturrechenregeln verwendet:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DefaultTextLanguage = "de-DE"
};

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Willkommen zur Präsentation";

presentation.Save("default_text_language.pptx", SaveFormat.Pptx);
```

## **Mehrere Sprachen in einem Absatz verwenden**

Ein [IParagraph](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraph/) enthält eine Sammlung von Textabschnitten. Erstellen Sie für jede Sprache einen separaten [Portion](https://reference.aspose.com/slides/de/net/aspose.slides/portion/) und setzen Sie dessen `LanguageId` unabhängig.

Dieses Beispiel erstellt einen Absatz mit englischen und französischen Abschnitten:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var englishPortion = new Portion("Welcome");
englishPortion.PortionFormat.LanguageId = "en-US";
paragraph.Portions.Add(englishPortion);

var frenchPortion = new Portion(" — Bienvenue");
frenchPortion.PortionFormat.LanguageId = "fr-FR";
paragraph.Portions.Add(frenchPortion);

presentation.Save("multilingual_text.pptx", SaveFormat.Pptx);
```

## **Rechtschreibprüfung für einzelne Abschnitte aktivieren oder unterdrücken**

[IPortionFormat](https://reference.aspose.com/slides/de/net/aspose.slides/iportionformat/) erbt die gemeinsamen Texteigenschaften, die von [IBasePortionFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseportionformat/) definiert werden. Greifen Sie über [IPortion.PortionFormat](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/portionformat/) auf das Format eines Abschnitts zu und setzen Sie [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/de/net/aspose.slides/baseportionformat/spellcheck/) , um zu steuern, ob eine Präsentations‑Anwendung die Rechtschreibung für diesen Abschnitt prüfen darf. Der Standardwert ist `false`: `true` erlaubt die Rechtschreibprüfung, `false` unterdrückt sie.

Die Einstellung gilt für einzelne Textabschnitte. Unterschiedliche Abschnitte im selben Absatz können daher verschiedene Werte verwenden. [BasePortionFormat.LanguageId](https://reference.aspose.com/slides/de/net/aspose.slides/baseportionformat/languageid/) und `SpellCheck` erfüllen komplementäre Aufgaben: `LanguageId` identifiziert die Korrektursprache, während `SpellCheck` bestimmt, ob Rechtschreibprüfungen für den Abschnitt erlaubt sind.

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/de/net/aspose.slides/baseportionformat/proofdisabled/) steuert ebenfalls die Korrektur, repräsentiert jedoch den umfassenderen „nicht prüfen“‑Zustand als [NullableBool](https://reference.aspose.com/slides/de/net/aspose.slides/nullablebool/). Verwenden Sie `SpellCheck`, wenn Sie einen direkten booleschen Schalter speziell für Rechtschreibprüfungen benötigen. Verwenden Sie `ProofDisabled`, wenn Sie die „keine Korrektur“‑Metadaten der Präsentation, inklusive des `NotDefined`‑Zustands, erhalten oder explizit steuern müssen. Wenn Sie beide Eigenschaften setzen, halten Sie deren Werte konsistent; kombinieren Sie nicht `SpellCheck = true` mit `ProofDisabled = NullableBool.True`.

Diese Eigenschaften konfigurieren Korrektur‑Metadaten, die von PowerPoint und anderen Präsentations‑Anwendungen verwendet werden. Aspose.Slides nutzt sie nicht, um wörterbuchbasierte Rechtschreibprüfungen durchzuführen oder eine Liste falsch geschriebener Wörter zurückzugeben.

Das folgende vollständige Beispiel erstellt eine Eingabepäsentation, lädt sie, weist zwei Abschnitten im selben Absatz unterschiedliche Rechtschreib‑ und Korrektureinstellungen zu, speichert das Ergebnis, öffnet es erneut und prüft die gespeicherten Werte:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputFile = "spell_check_input.pptx";
const string outputFile = "spell_check_settings.pptx";

using (var sourcePresentation = new Presentation())
{
    var sourceSlide = sourcePresentation.Slides[0];
    var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    var sourceParagraph = sourceShape.TextFrame.Paragraphs[0];
    sourceParagraph.Portions.Clear();

    var sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.PortionFormat.LanguageId = "en-US";
    sourceParagraph.Portions.Add(sourceEnglishPortion);

    var sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.PortionFormat.LanguageId = "fr-FR";
    sourceParagraph.Portions.Add(sourceFrenchPortion);

    sourcePresentation.Save(inputFile, SaveFormat.Pptx);
}

using (var presentation = new Presentation(inputFile))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var portions = shape.TextFrame.Paragraphs[0].Portions;

    var checkedPortion = portions[0];
    checkedPortion.PortionFormat.LanguageId = "en-US";
    checkedPortion.PortionFormat.SpellCheck = true;

    var suppressedPortion = portions[1];
    suppressedPortion.PortionFormat.LanguageId = "fr-FR";
    suppressedPortion.PortionFormat.SpellCheck = false;

    presentation.Save(outputFile, SaveFormat.Pptx);
}

using var reopenedPresentation = new Presentation(outputFile);
var reopenedShape = (IAutoShape)reopenedPresentation.Slides[0].Shapes[0];
var storedPortions = reopenedShape.TextFrame.Paragraphs[0].Portions;

var firstPortionStored = storedPortions.Count == 2 &&
    storedPortions[0].PortionFormat.LanguageId == "en-US" &&
    storedPortions[0].PortionFormat.SpellCheck;

var secondPortionStored = storedPortions.Count == 2 &&
    storedPortions[1].PortionFormat.LanguageId == "fr-FR" &&
    !storedPortions[1].PortionFormat.SpellCheck;

if (firstPortionStored && secondPortionStored)
{
    Console.WriteLine("The proofing settings were stored correctly.");
}
else
{
    Console.WriteLine("The proofing settings could not be verified.");
}
```

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/joinportionswithsameformatting/) fasst benachbarte Abschnitte mit identischer Formatierung zusammen. Ein Unterschied allein in `SpellCheck` reicht nicht aus, um solche Abschnitte getrennt zu halten; nach dem Zusammenführen behält der resultierende Abschnitt den `SpellCheck`‑Wert des ersten Abschnitts. Wenn Abschnitte unterschiedliche Rechtschreib‑Einstellungen benötigen, rufen Sie `JoinPortionsWithSameFormatting` vor dem Setzen dieser Einstellungen auf oder prüfen Sie die resultierenden Abschnittsgrenzen und wenden Sie die Einstellungen danach erneut an. Abschnitte mit unterschiedlichen `LanguageId`‑Werten bleiben getrennt, da ihre Korrektursprache‑Formatierung abweicht.

## **FAQ**

**Wandelt eine Sprach‑ID den Text um?**

Nein. [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseportionformat/languageid/) speichert Korrektur‑Metadaten für Rechtschreibung und Grammatik; sie ändert den Textinhalt nicht. Übersetzen Sie den Text separat und setzen Sie anschließend für jeden übersetzten Abschnitt die passende Sprach‑ID.

**Steuert die Korrektursprache Schriften, Silbentrennung oder Zeilenumbruch?**

Nein. Die Sprach‑ID dient ausschließlich der Korrektur. Die Textdarstellung und das Layout hängen hauptsächlich von den verfügbaren [fonts](/slides/de/net/powerpoint-fonts/), dem Schriftsystem und den Text‑Frame‑Einstellungen ab. Für eine zuverlässige Darstellung stellen Sie die benötigten Schriften bereit, konfigurieren Sie [font substitution](/slides/de/net/font-substitution/) oder betten Sie Schriften mit [embed fonts](/slides/de/net/embedded-font/) in die Präsentation ein.

**Kann ein Absatz mehrere Korrektursprachen verwenden?**

Ja. Ordnen Sie jeder Sprache einen separaten Abschnitt zu, wie im mehrsprachigen Absatz‑Beispiel gezeigt.

**Soll ich `DefaultTextLanguage` oder `LanguageId` verwenden?**

Verwenden Sie [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/defaulttextlanguage/), wenn Sie einen Standard für neu erstellten Text festlegen möchten. Verwenden Sie [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseportionformat/languageid/), wenn ein bestimmter Abschnitt eine explizite Korrektursprache benötigt oder ein Absatz mehrere Sprachen enthält.