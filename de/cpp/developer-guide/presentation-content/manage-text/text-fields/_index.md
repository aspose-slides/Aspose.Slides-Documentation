---
title: Verwalten von Textfeldern in PowerPoint-Präsentationen in C++
linktitle: Textfelder
type: docs
weight: 52
url: /de/cpp/text-fields/
keywords:
- Textfeld
- automatischer Text
- Foliennummer
- Datum und Zeit
- Kopfzeile
- Fußzeile
- Textabschnitt
- PowerPoint
- PPT
- PPTX
- C++
- Aspose.Slides
description: Erstellen, untersuchen, ändern und entfernen von Textfeldern in PowerPoint-Präsentationen mit Aspose.Slides für C++. Formatierung beibehalten und gespeicherte PPTX- und PPT-Dateien prüfen.
---
## **Übersicht**

Ein Textabsatz besteht aus Abschnitten. Ein gewöhnlicher [IPortion](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/) enthält literalen Text; ein Feldabschnitt hat zusätzlich ein [IField](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifield/), dessen Typ einen automatisch aktualisierten Wert identifiziert, etwa eine Foliennummer oder ein Datum. Zwei Abschnitte können dieselben Zeichen anzeigen, während nur einer ein Feld enthält.

Verwenden Sie [IPortion::get_Field](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/get_field/), um sie zu unterscheiden: Sie gibt `nullptr` für gewöhnlichen Text zurück. [IPortion::AddField](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/addfield/) konvertiert einen vorhandenen Abschnitt in ein Feld. Bewahren Sie ein Label und dessen dynamischen Wert in getrennten Abschnitten auf, damit das Konvertieren des Werts nicht gleichzeitig das Label ersetzt.

Dieser Leitfaden behandelt Felder innerhalb von Text, deren Formatierung und das Speichern in PPTX und PPT. Für Textfelder und Absätze siehe [Manage Text](/slides/de/cpp/manage-text/).

## **Feld für Foliennummer erstellen**

Das folgende Beispiel erzeugt ein Textfeld, das ein wörtliches `Slide `‑Label gefolgt von einer automatisch aktualisierten Nummer enthält. Es legt die Größe, Gewichtung und Farbe der Nummer fest, bevor das Feld hinzugefügt wird, öffnet anschließend die gespeicherte Präsentation erneut und prüft Feldtyp, Text und Formatierung. Keine Eingabedatei ist erforderlich.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
shape->AddTextFrame(u"Slide ");
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

auto numberPortion = System::MakeObject<Portion>();
numberPortion->get_PortionFormat()->set_FontHeight(24);
numberPortion->get_PortionFormat()->set_FontBold(NullableBool::True);
numberPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
numberPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkBlue());
paragraph->get_Portions()->Add(numberPortion);
numberPortion->AddField(FieldType::get_SlideNumber());

presentation->Save(u"slide_number.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"slide_number.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedNumber = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(1);
auto field = savedNumber->get_Field();
auto hasNumberField = field != nullptr && field->get_Type()->get_InternalString() == FieldType::get_SlideNumber()->get_InternalString();
auto format = savedNumber->get_PortionFormat();
auto formattingPreserved = format->get_FontHeight() == 24 && format->get_FontBold() == NullableBool::True;
formattingPreserved &= format->get_FillFormat()->get_SolidFillColor()->get_Color().ToArgb() == System::Drawing::Color::get_DarkBlue().ToArgb();

System::Console::WriteLine(u"Text: {0}", savedShape->get_TextFrame()->get_Text());
System::Console::WriteLine(u"Slide number field: {0}", hasNumberField);
System::Console::WriteLine(u"Formatting preserved: {0}", formattingPreserved);
reopened->Dispose();
```

Die neue Präsentation beginnt mit Foliennummer 1, sodass der erwartete Text `Slide 1` lautet und beide Prüfungen `True` ausgeben sollten. Die Nummer bleibt nach dem erneuten Öffnen ein Feld; sie ist kein wörtlicher `1`. Der Cast und die Indizes in der Verifikation beziehen sich auf das Shape und die Abschnitte, die in diesem Beispiel erstellt wurden.

## **Feldtyp auswählen**

[FieldType](https://reference.aspose.com/slides/de/cpp/aspose.slides/fieldtype/) implementiert [IFieldType](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifieldtype/) und bietet die folgenden vordefinierten Werte. Übergeben Sie den passenden Wert an [AddField](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/addfield/).

| Zugriffsmethode | Zweck |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/de/cpp/aspose.slides/fieldtype/get_slidenumber/) | Die aktuelle Foliennummer. |
| [get_DateTime](https://reference.aspose.com/slides/de/cpp/aspose.slides/fieldtype/get_datetime/) | Datum/Uhrzeit im Standardformat der Rendering‑Anwendung. |
| [get_DateTime1](https://reference.aspose.com/slides/de/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/de/cpp/aspose.slides/fieldtype/get_datetime9/) | Vorgegebene Datums‑ bzw. kombinierte Datum/Uhrzeit‑Formate. |
| [get_DateTime10](https://reference.aspose.com/slides/de/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/de/cpp/aspose.slides/fieldtype/get_datetime13/) | Vorgegebene Zeitformate, mit Optionen für Sekunden und 12‑Stunden‑Uhr. |
| [get_Header](https://reference.aspose.com/slides/de/cpp/aspose.slides/fieldtype/get_header/) | Ein Header‑Feld; siehe die Platzhalter‑ und Formatbeschränkungen unten. |
| [get_Footer](https://reference.aspose.com/slides/de/cpp/aspose.slides/fieldtype/get_footer/) | Ein Footer‑Feld. |

Zum Beispiel liefert [get_DateTime3](https://reference.aspose.com/slides/de/cpp/aspose.slides/fieldtype/get_datetime3/) einen Tag, den vollen Monatsnamen und das Jahr auf Englisch. Dabei handelt es sich um vordefinierte Feldformate, nicht um beliebige Datumsformat‑Zeichenketten. Die Sprache des Abschnitts, gesetzt über [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseportionformat/set_languageid/), sowie die Anwendung, die die Präsentation verarbeitet, können das angezeigte Ergebnis beeinflussen.

## **Feld aus einer internen Zeichenkette erstellen**

Die Zeichenketten‑Überladung von [AddField](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/addfield/) akzeptiert einen internen Feld‑Identifier. Verwenden Sie sie, wenn Sie einen von einer anderen Anwendung bereitgestellten Identifier erhalten, für den es keinen vordefinierten Wert gibt. Sie können auch ein [FieldType](https://reference.aspose.com/slides/de/cpp/aspose.slides/fieldtype/fieldtype/) aus diesem Identifier konstruieren. [IFieldType::get_InternalString](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifieldtype/get_internalstring/) gibt diesen Identifier zur Inspektion frei.

Dieses Beispiel speichert ein anwendungsspezifisches Feld `custom-report-id` mit dem Fallback‑Text `Report-042`. Keine Eingabedatei ist erforderlich. Der Identifier registriert keine Berechnung: Aspose.Slides erzeugt keine Bericht‑IDs für einen unbekannten Typ. Die Anwendung, die diesen Identifier versteht, muss Bedeutung und Aktualisierung bereitstellen.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
shape->AddTextFrame(u"Report-042");
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->AddField(u"custom-report-id");
presentation->Save(u"custom_field.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"custom_field.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedPortion = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto field = savedPortion->get_Field();
auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
System::Console::WriteLine(u"Type: {0}", typeName);
System::Console::WriteLine(u"Text: {0}", savedPortion->get_Text());
reopened->Dispose();
```

Nach diesem PPTX‑Rundlauf ist der erwartete Typ `custom-report-id` und der erwartete Text `Report-042`. Das Übergeben einer Zeichenkette wie `yyyy-MM-dd` würde einen Feldtyp benennen; es würde kein benutzerdefiniertes Datumsformat konfigurieren. Für ein festes Datum in beliebigem Format verwenden Sie gewöhnlichen Text.

## **Datum/Uhrzeit‑Felder untersuchen, ändern und entfernen**

Lesen Sie einen bestehenden Feldtyp über [IField::get_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifield/get_type/) und ändern Sie ihn über [IField::set_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifield/set_type/). Prüfen Sie, ob das Feld existiert, bevor Sie seinen Typ auslesen. Um automatische Aktualisierungen zu stoppen, rufen Sie [IPortion::RemoveField](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/removefield/) auf. Das erhält den Abschnitt und dessen aktuellen Text, während die Feldzuordnung entfernt wird. Wenn Sie einen festen Wert benötigen, weisen Sie nach dem Entfernen des Feldes den gewünschten Text zu.

Für die API‑Einstellung, die die Verarbeitung von Datum/Uhrzeit‑Feldern betrifft, siehe [Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/set_currentdatetime/). Das nachstehende Beispiel verwendet ein konkretes Genehmigungsdatum, wenn ein Feld in gewöhnlichen Text umgewandelt wird.

Laden Sie [sample.pptx](sample.pptx) herunter und platzieren Sie es im Arbeitsverzeichnis. Es enthält zwei benannte Text‑Shapes, `UpdatedAt` und `ApprovedDate`, jeweils mit einem Datum/Uhrzeit‑Feld sowie gewöhnliche Text‑Labels. Das folgende Beispiel durchläuft die obersten Text‑Shapes auf regulären Folien. Es ändert Datum/Uhrzeit‑Felder in ein Langdatumsformat und macht sie kursiv, wobei die übrige Formatierung erhalten bleibt. Nur Felder in `ApprovedDate` werden zu festem Text.

Die Probe erkennt die eingebauten internen Identifier `datetime` sowie `datetime1` bis `datetime13`. Gruppen, Tabellen, Notizen, Layouts und Master‑Sheets erfordern die Durchsuchung ihrer eigenen Text‑Container und liegen außerhalb des Umfangs dieses Beispiels.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/globalization/culture_info.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto approvalDate = System::DateTime(2030, 4, 5);
auto culture = System::Globalization::CultureInfo::GetCultureInfo(u"en-US");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto textShape = System::DynamicCast<IAutoShape>(shape);
        if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : textShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto field = portion->get_Field();
                if (field == nullptr)
                    continue;

                auto typeName = field->get_Type()->get_InternalString();
                auto isDateTime = typeName == u"datetime";
                for (auto formatNumber = 1; formatNumber <= 13; ++formatNumber)
                {
                    auto identifier = System::String::Format(u"datetime{0}", formatNumber);
                    isDateTime |= typeName == identifier;
                }
                if (!isDateTime)
                    continue;

                field->set_Type(FieldType::get_DateTime3());
                portion->get_PortionFormat()->set_LanguageId(u"en-US");
                portion->get_PortionFormat()->set_FontItalic(NullableBool::True);

                if (textShape->get_Name() == u"ApprovedDate")
                {
                    portion->RemoveField();
                    auto fixedDate = approvalDate.ToString(u"dd MMMM yyyy", culture);
                    portion->set_Text(fixedDate);
                }
            }
        }
    }
}

presentation->Save(u"updated_dates.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"updated_dates.pptx");
for (auto shape : reopened->get_Slide(0)->get_Shapes())
{
    auto textShape = System::DynamicCast<IAutoShape>(shape);
    if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
        continue;
    if (textShape->get_Name() != u"UpdatedAt" && textShape->get_Name() != u"ApprovedDate")
        continue;

    auto portion = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
    auto field = portion->get_Field();
    auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
    System::Console::WriteLine(u"{0}: {1}; {2}", textShape->get_Name(), typeName, portion->get_Text());
    auto isItalic = portion->get_PortionFormat()->get_FontItalic() == NullableBool::True;
    System::Console::WriteLine(u"Italic: {0}", isItalic);
}
reopened->Dispose();
```

Nach dem erneuten Öffnen sollte `UpdatedAt` den Typ `datetime3` besitzen und dynamisch bleiben. `ApprovedDate` sollte kein Feld mehr enthalten und den Text `05 April 2030` zeigen. Beide Datums‑Abschnitte sind kursiv, und ihre ursprüngliche Schriftgröße, Fett‑Einstellung und Farbe bleiben unverändert. Die gewöhnlichen Text‑Labels bleiben unverändert. Die Verifikation liest den ersten Abschnitt der beiden bekannten Shapes aus der bereitgestellten Probe.

## **Textformatierung erhalten**

Arbeiten Sie mit dem vorhandenen Abschnitt, wenn Sie ein Feld hinzufügen, dessen Typ ändern oder es entfernen. Diese Vorgänge bewahren die Formatierung dieses Abschnitts. Verwenden Sie [IPortion::get_PortionFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/get_portionformat/), um nur die erforderlichen Eigenschaften zu ändern, wie die Beispiele für Farbe oder Kursivschrift zeigen.

Vermeiden Sie das Neuaufbauen eines gesamten Text‑Frames nur zum Aktualisieren eines Feldes: Das kann die ursprünglichen Abschnittsgrenzen und deren individuelle Formatierung verlieren. Unterscheiden Sie außerdem explizit gesetzte Formatierung von der Vererbung aus Absatz, Layout oder Theme. Siehe [Text Formatting](/slides/de/cpp/text-formatting/) für weiterführende Formatierungsoptionen.

## **Felder und Header/Footer‑Platzhalter**

Ein Feld ist Teil eines Textabschnitts. Ein Platzhalter ist ein Shape mit einer Präsentationsrolle, z. B. Footer oder Foliennummer. Das Hinzufügen eines Feldes zu einem gewöhnlichen Textfeld macht dieses Shape nicht zu einem Platzhalter.

Die Header/Footer‑Manager steuern den Platzhalter‑Text und die Sichtbarkeit auf Folien, Layouts und Master‑Sheets, einschließlich der Weitergabe an abhängige Folien. Ein Zahlen‑Feld in einem benutzerdefinierten Textfeld kann daher nützlich sein, selbst wenn Sie den Folien‑Nummern‑Platzhalter nicht verwenden. Umgekehrt entfernt das Ändern der Platzhalter‑Sichtbarkeit kein Feld aus einem nicht zugehörigen Textfeld.

Die vordefinierten Header‑ und Footer‑Typen erzeugen nicht die entsprechenden Platzhalter oder stellen deren Inhalt bereit. Insbesondere enthält eine reguläre PowerPoint‑Folien keine Header‑Platzhalter; Header gehören zu Notiz‑Seiten und Handouts. Gehen Sie nicht davon aus, dass ein Header‑ oder Footer‑Feld in einem beliebigen Shape automatisch den über einen Platzhalter‑Manager konfigurierten Text übernimmt. Für diesen Ablauf siehe [Presentation Headers and Footers](/slides/de/cpp/presentation-header-and-footer/).

## **PPTX‑ und PPT‑Einschränkungen**

Prüfen Sie sowohl den Feldtyp als auch den resultierenden Text nach dem Speichern und erneuten Öffnen. Das Beibehalten eines Identifiers beweist nicht, dass eine Anwendung dessen Wert berechnen oder anzeigen kann.

| Format | Verhalten und Einschränkungen des Feldes |
|---|---|
| PPTX | Speichert interne Feld‑Identifier zusammen mit dem Feld‑Text. Verwenden Sie die obigen Beispiele, um vordefinierte Typen und benutzerdefinierte Identifier nach dem Speichern und erneuten Öffnen zu prüfen. Ein unbekannter benutzerdefinierter Typ erhält keine automatische Berechnungslogik. Eine andere Anwendung kann nicht unterstützte Identifier unterschiedlich behandeln. |
| PPT | Nutzt veraltete Feld‑Darstellungen und hat begrenztere Kompatibilität. Folien‑Nummern‑ und vordefinierte Datum/Uhrzeit‑Felder haben Legacy‑Darstellungen. Nicht unterstützte benutzerdefinierte Felder oder Header‑Felder in einem gewöhnlichen Folientext können `*` als Text ergeben. Verlassen Sie sich nicht darauf, dass benutzerdefinierte Felder oder nicht unterstützte Feld‑Kontexte ihren sichtbaren Text behalten. |

Für portable, feste Ausgaben konvertieren Sie nicht unterstützte Felder in gewöhnlichen Text und weisen Sie vor dem Speichern explizit den gewünschten Wert zu. Das bewahrt den gewählten Text, stoppt jedoch automatisch Updates. Testen Sie auch die Zielanwendung, wenn deren eigene Feld‑Neuberechnung Teil Ihres Workflows ist.

## **FAQ**

**Wie kann ich erkennen, ob eine angezeigte Zahl oder ein Datum ein Feld ist?**

Untersuchen Sie [IPortion::get_Field](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/get_field/). Ein von `nullptr` abweichender Wert identifiziert ein Feld; der angezeigte Text allein sagt nichts darüber aus.

**Entfernt das Entfernen eines Feldes dessen Text oder Formatierung?**

Nein. [RemoveField](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/removefield/) wandelt den bestehenden Abschnitt in gewöhnlichen Text um. Weisen Sie anschließend bei Bedarf einen expliziten Wert zu, wenn Sie ein festes Datum oder einen Fallback‑Text benötigen.

**Kann eine interne Zeichenkette ein neues Datumsformat oder eine Formel definieren?**

Nein. Sie identifiziert lediglich einen Feldtyp. Ein unbekannter Identifier liefert keinen Evaluator oder ein Datumsformat‑Muster. Verwenden Sie einen unterstützten vordefinierten Typ oder formatieren Sie den Wert selbst als gewöhnlichen Text.

**Warum sollte man eine Präsentation nach dem Speichern erneut prüfen?**

Feld‑Identifier, berechneter Text und Formatierung sind separate Aspekte, die geprüft werden müssen. Eine Formatkonvertierung kann das sichtbare Ergebnis ändern, selbst wenn der Feld‑Identifier noch vorhanden ist.