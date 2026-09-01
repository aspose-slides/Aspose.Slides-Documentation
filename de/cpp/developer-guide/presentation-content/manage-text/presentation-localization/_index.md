---
title: Automatisiere die Lokalisierung von Präsentationen in C++
linktitle: Präsentationslokalisierung
type: docs
weight: 100
url: /de/cpp/presentation-localization/
keywords:
- Sprache ändern
- Rechtschreibprüfung
- Rechtschreibprüfung unterdrücken
- Korrektursprache
- Sprach-ID
- mehrsprachiger Text
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Legen Sie Korrektursprachen für PowerPoint- und OpenDocument-Präsentationstexte in C++ mit Aspose.Slides fest, einschließlich Vorgaben und mehrsprachiger Absätze."
---
## **Überblick**

Aspose.Slides für C++ ermöglicht das Konfigurieren von Korrekturdaten für einzelne Textabschnitte. Verwenden Sie [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseportionformat/set_languageid/), um die Korrektursprache zu bestimmen, [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/de/cpp/aspose.slides/baseportionformat/set_spellcheck/), um Rechtschreibprüfungen zuzulassen oder zu unterdrücken, und [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/de/cpp/aspose.slides/baseportionformat/set_proofdisabled/), um den weiter gefassten „Kein Korrektur“-Status zu steuern. Da diese Einstellungen auf Abschnittsebene angewendet werden, kann ein Absatz mehrere Sprachen und unterschiedliche Korrekturregeln enthalten.

Dieser Artikel erklärt, wie einer bestimmten Textstelle eine Sprache zugewiesen wird, wie die Standardsprache für neuen Text mit [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) festgelegt wird, wie mehrsprachige Absätze erstellt werden, wie zwischen `SpellCheck` und `ProofDisabled` gewählt wird und wie die gewünschten Einstellungen beim Einsatz von [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/joinportionswithsameformatting/) beibehalten werden. Diese Eigenschaften speichern Metadaten für Präsentationsprogramme; sie übersetzen keinen Text, führen keine wörterbuchbasierte Rechtschreibprüfung durch und geben keine falsch geschriebenen Wörter zurück.

## **Festlegen der Korrektursprache für Text**

Erzeugen oder laden Sie eine [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/), greifen Sie über [IPortion::get_PortionFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/get_portionformat/) auf den gewünschten Textabschnitt zu und weisen Sie ihm die Sprachkennung zu. Das folgende Beispiel erstellt eine Form, legt Britisches Englisch als Korrektursprache fest und speichert das Ergebnis mit [Presentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Set the proofing language for this text.");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LanguageId(u"en-GB");

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Festlegen der Standardsprache für neuen Text**

Verwenden Sie [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/), um die Korrektursprache anzugeben, die Aspose.Slides neu erstelltem Text zuweist. Diese Einstellung ist nützlich, wenn der größte Teil oder der gesamte neue Text einer Präsentation dieselbe Sprache verwendet. Sie ändert nicht die Sprachmetadaten von Text, der bereits eine explizite Sprache hat.

Das folgende Beispiel erstellt eine Präsentation, bei der neuer Text deutsche Korrekturregeln verwendet:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"de-DE");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Willkommen zur Präsentation");

presentation->Save(u"default_text_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Mehrere Sprachen in einem Absatz verwenden**

Ein [IParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/) enthält eine Sammlung von Textabschnitten. Erstellen Sie für jede Sprache einen separaten [Portion](https://reference.aspose.com/slides/de/cpp/aspose.slides/portion/) und setzen Sie dessen `LanguageId` unabhängig voneinander.

Dieses Beispiel erzeugt einen Absatz mit englischen und französischen Abschnitten:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto englishPortion = System::MakeObject<Portion>(u"Welcome");
englishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
paragraph->get_Portions()->Add(englishPortion);

auto frenchPortion = System::MakeObject<Portion>(u" — Bienvenue");
frenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
paragraph->get_Portions()->Add(frenchPortion);

presentation->Save(u"multilingual_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Rechtschreibprüfung für einzelne Abschnitte aktivieren oder unterdrücken**

[IPortionFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportionformat/) erbt die allgemeinen Texteigenschaften, die von [IBasePortionFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseportionformat/) definiert werden. Greifen Sie über [IPortion::get_PortionFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/get_portionformat/) auf das Format eines Abschnitts zu und rufen Sie [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/de/cpp/aspose.slides/baseportionformat/set_spellcheck/) auf, um zu steuern, ob eine Präsentationsanwendung die Rechtschreibung für diesen Abschnitt prüfen darf. Der Standardwert ist `false`: `true` erlaubt die Prüfung, `false` unterdrückt sie.

Die Einstellung gilt für einzelne Textabschnitte. Unterschiedliche Abschnitte im selben Absatz können daher verschiedene Werte verwenden. [BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/de/cpp/aspose.slides/baseportionformat/set_languageid/) und `SpellCheck` erfüllen komplementäre Aufgaben: `LanguageId` bestimmt die Korrektursprache, während `SpellCheck` festlegt, ob Rechtschreibprüfungen für den Abschnitt erlaubt sind.

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/de/cpp/aspose.slides/baseportionformat/set_proofdisabled/) steuert ebenfalls die Korrektur, repräsentiert jedoch den weiter gefassten „nicht korrigieren“-Zustand als [NullableBool](https://reference.aspose.com/slides/de/cpp/aspose.slides/nullablebool/). Verwenden Sie `SpellCheck`, wenn Sie einen direkten booleschen Schalter ausschließlich für Rechtschreibprüfungen benötigen. Verwenden Sie `ProofDisabled`, wenn Sie die „Kein Korrektur“-Metadaten der Präsentation erhalten oder explizit steuern wollen, einschließlich des Zustands `NullableBool::NotDefined`. Wenn Sie beide Eigenschaften setzen, halten Sie deren Werte konsistent; kombinieren Sie nicht `SpellCheck = true` mit `ProofDisabled = NullableBool::True`.

Diese Eigenschaften konfigurieren Korrekturdaten, die von PowerPoint und anderen Präsentationsprogrammen verwendet werden. Aspose.Slides nutzt sie nicht, um wörterbuchbasierte Rechtschreibprüfungen durchzuführen oder eine Liste falsch geschriebener Wörter zurückzugeben.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputFile = u"spell_check_input.pptx";
const System::String outputFile = u"spell_check_settings.pptx";

{
    auto sourcePresentation = System::MakeObject<Presentation>();
    auto sourceSlide = sourcePresentation->get_Slide(0);
    auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
    auto sourceParagraph = sourceShape->get_TextFrame()->get_Paragraph(0);
    sourceParagraph->get_Portions()->Clear();

    auto sourceEnglishPortion = System::MakeObject<Portion>(u"Check this text. ");
    sourceEnglishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    sourceParagraph->get_Portions()->Add(sourceEnglishPortion);

    auto sourceFrenchPortion = System::MakeObject<Portion>(u"Ignorer ce code : ZX-81.");
    sourceFrenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    sourceParagraph->get_Portions()->Add(sourceFrenchPortion);

    sourcePresentation->Save(inputFile, SaveFormat::Pptx);
    sourcePresentation->Dispose();
}

{
    auto presentation = System::MakeObject<Presentation>(inputFile);
    auto firstShape = presentation->get_Slide(0)->get_Shape(0);
    auto shape = System::ExplicitCast<IAutoShape>(firstShape);
    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

    auto checkedPortion = paragraph->get_Portion(0);
    checkedPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    checkedPortion->get_PortionFormat()->set_SpellCheck(true);

    auto suppressedPortion = paragraph->get_Portion(1);
    suppressedPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    suppressedPortion->get_PortionFormat()->set_SpellCheck(false);

    presentation->Save(outputFile, SaveFormat::Pptx);
    presentation->Dispose();
}

auto reopenedPresentation = System::MakeObject<Presentation>(outputFile);
auto reopenedFirstShape = reopenedPresentation->get_Slide(0)->get_Shape(0);
auto reopenedShape = System::ExplicitCast<IAutoShape>(reopenedFirstShape);
auto storedParagraph = reopenedShape->get_TextFrame()->get_Paragraph(0);

bool portionsStored = storedParagraph->get_Portions()->get_Count() == 2;
if (portionsStored)
{
    auto firstStoredPortion = storedParagraph->get_Portion(0);
    auto secondStoredPortion = storedParagraph->get_Portion(1);

    bool firstPortionStored = firstStoredPortion->get_PortionFormat()->get_LanguageId() == u"en-US" && 
        firstStoredPortion->get_PortionFormat()->get_SpellCheck();

    bool secondPortionStored = secondStoredPortion->get_PortionFormat()->get_LanguageId() == u"fr-FR" && 
        !secondStoredPortion->get_PortionFormat()->get_SpellCheck();

    if (firstPortionStored && secondPortionStored)
    {
        System::Console::WriteLine(u"The proofing settings were stored correctly.");
    }
    else
    {
        System::Console::WriteLine(u"The proofing settings could not be verified.");
    }
}
else
{
    System::Console::WriteLine(u"The proofing settings could not be verified.");
}

reopenedPresentation->Dispose();
```

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/joinportionswithsameformatting/) fügt benachbarte Abschnitte mit identischer Formatierung zusammen. Ein Unterschied allein im `SpellCheck` hält solche Abschnitte nicht getrennt; nach dem Zusammenführen behält der resultierende Abschnitt den `SpellCheck`‑Wert des ersten Abschnitts. Wenn Abschnitte unterschiedliche Rechtschreibprüfungseinstellungen benötigen, rufen Sie `JoinPortionsWithSameFormatting` auf, bevor Sie diese Einstellungen zuweisen, oder prüfen Sie die resultierenden Abschnittsgrenzen und wenden Sie die Einstellungen anschließend erneut an. Abschnitte mit unterschiedlichen `LanguageId`‑Werten bleiben separat, weil sich deren Korrektur‑Sprachformatierung unterscheidet.

## **FAQ**

**Wird durch eine Sprach-ID der Text übersetzt?**

Nein. [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseportionformat/set_languageid/) speichert Korrekturdaten für Rechtschreibung und Grammatik; sie ändert nicht den Textinhalt. Übersetzen Sie den Text separat und setzen Sie dann für jeden übersetzten Abschnitt die passende Sprachkennung.

**Steuert die Korrektursprache Schriftarten, Silbentrennung oder Zeilenumbruch?**

Nein. Die Sprachkennung dient ausschließlich der Korrektur. Textdarstellung und Layout hängen hauptsächlich von den verfügbaren [fonts](/slides/de/cpp/powerpoint-fonts/), dem Schriftsystem und den Einstellungen des Textrahmens ab. Für eine zuverlässige Darstellung stellen Sie die benötigten Schriften bereit, konfigurieren Sie die [font substitution](/slides/de/cpp/font-substitution/), oder betten Sie die Schriften mit [embed fonts](/slides/de/cpp/embedded-font/) in die Präsentation ein.

**Kann ein Absatz mehrere Korrektursprachen verwenden?**

Ja. Weisen Sie jeder Sprache einen separaten Abschnitt zu, wie im Beispiel für mehrsprachige Absätze gezeigt.

**Sollte ich `DefaultTextLanguage` oder `LanguageId` verwenden?**

Verwenden Sie [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/), wenn Sie einen Standard für neu erstellten Text festlegen möchten. Verwenden Sie [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseportionformat/set_languageid/), wenn ein bestimmter Abschnitt eine explizite Korrektursprache benötigt oder ein Absatz mehrere Sprachen enthält.