---
title: Shape-Effektive Eigenschaften aus Präsentationen in C++ abrufen
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/cpp/shape-effective-properties/
keywords:
- Shape-Eigenschaften
- Kameraeigenschaften
- Lichtanlage
- Fasenform
- Textfeld
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aspose.Slides für C++ verwenden, um lokale, geerbte und effektive Shape-Formatierungen in PowerPoint-Präsentationen zu unterscheiden."
---
## **Lokale, geerbte und effektive Eigenschaften verstehen**

PowerPoint-Formatierungen können aus mehreren Quellen stammen. Der direkt auf einem Objekt gespeicherte Wert ist sein **lokaler Wert**. Ist dieser Wert nicht gesetzt, prüft PowerPoint die übergeordneten Formatierungsquellen, wie z. B. die Absatz‑Standardwerte, einen Textstil, ein Layout‑ oder Master‑Folie, ein Design oder die Präsentations‑Standardeinstellungen. Diese Werte sind **geerbte Werte**. Der nach Auflösung der gesamten Hierarchie verbleibende Wert ist der **effektive Wert** — der zum Rendern des Objekts verwendete Wert.

Zum Beispiel definiert ein Textabschnitt möglicherweise nicht seine eigene [Schrifthöhe](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseportionformat/) . Sein lokaler Wert ist dann `std::numeric_limits<float>::quiet_NaN()`, was „hier nicht festgelegt“ bedeutet. Der Abschnitt kann eine Höhe von seinem Absatz, dem Standard‑Textstil der Präsentation oder einer anderen zutreffenden Quelle erben. Das Aufrufen von [GetEffective](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportionformat/) am Abschnittsformat liefert die letztlich aufgelöste Höhe.

Verwenden Sie die beiden Arten von Formatierungsdaten zu unterschiedlichen Zwecken:

- Lesen oder ändern Sie ein lokales Formatobjekt, z. B. [IPortionFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportionformat/), wenn Sie steuern müssen, wo ein Wert definiert wird.
- Lesen Sie ein effektives Datenelement, z. B. [IPortionFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportionformateffectivedata/), wenn Sie das endgültige, gerenderte Ergebnis benötigen. Effektive Daten sind schreibgeschützt.

## **Lokale, geerbte und effektive Werte vergleichen**

Das nachfolgende vollständige Beispiel erstellt eine Form und wendet Schriftgrößen auf Präsentations‑, Absatz‑ und Abschnittsebene an. Jeder Schritt gibt die auf diesen Ebenen definierten Werte sowie den resultierenden effektiven Wert für denselben Textabschnitt aus. Es zeigt außerdem, warum effektive Daten nach Formatierungsänderungen erneut ausgelesen werden müssen.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <cmath>
#include <limits>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 500.0f, 80.0f, false);
auto textFrame = shape->AddTextFrame(u"Effective formatting");
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

// Definieren Sie geerbte Werte auf zwei verschiedenen Ebenen.
presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(20.0f);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);

auto formatLocalValue = [](float value) -> System::String
{
    return std::isnan(value) ? System::String(u"<not set>") : System::ObjectExt::ToString(value);
};

auto printFontHeights = [&](System::String caption)
{
    auto presentationValue = presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->get_FontHeight();
    auto paragraphValue = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FontHeight();
    auto localValue = portion->get_PortionFormat()->get_FontHeight();

    // Effektive Daten nach den vorherigen Änderungen lesen.
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// Ein lokaler Wert im Abschnitt überschreibt beide geerbten Werte.
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// Das Ändern eines geerbten Werts überschreibt keinen vorhandenen lokalen Wert.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// Lokalen Wert zurücksetzen. Der Abschnitt erbt jetzt wieder vom Absatz.
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// Absatzwert zurücksetzen. Der Präsentationsstandard liefert jetzt das Ergebnis.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Die Priorität in diesem Beispiel liegt auf der lokalen Formatierung des Abschnitts, gefolgt von der Absatz‑Formatierung und schließlich dem Präsentations‑Standard. Andere Objekte können andere Vererbungsketten haben, aber das Prinzip ist dasselbe: ein spezifischerer expliziter Wert gewinnt, und [GetEffective](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportionformat/) gibt das Endergebnis zurück.

## **Effektive Texteigenschaften abrufen**

Textformatierung ist auf mehrere Objekte verteilt:

- [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformat/) löst Textfeld‑Eigenschaften wie Ränder, Verankerung, Autofit und vertikale Textausrichtung auf.
- [ITextStyle::GetEffective](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextstyle/) löst Absatzformatierung für jede Textstil‑Ebene auf.
- [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/) löst Absatz‑Eigenschaften wie Ausrichtung, Einrückung und Aufzählungszeichen auf.
- [IPortionFormat::GetEffective](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportionformat/) löst Zeichen‑Eigenschaften wie Schriftgröße, Schriftart, Farbe, Fett und Kursiv auf.

Für das nächste Beispiel muss `text-formatting.pptx` mindestens eine Folie und ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) mit einem nicht‑leeren Textfeld enthalten. Das IAutoShape kann an beliebiger Stelle in der Form‑Sammlung stehen; der Code sucht nach einem geeigneten Objekt und prüft es, bevor es verwendet wird.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"text-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<IAutoShape> shape;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (!System::ObjectExt::Is<IAutoShape>(candidate))
        continue;

    auto autoShape = System::ExplicitCast<IAutoShape>(candidate);
    auto candidateTextFrame = autoShape->get_TextFrame();

    if (candidateTextFrame == nullptr || candidateTextFrame->get_Paragraphs()->get_Count() == 0)
        continue;

    if (candidateTextFrame->get_Paragraph(0)->get_Portions()->get_Count() == 0)
        continue;

    shape = autoShape;
    break;
}

if (shape == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain an IAutoShape with non-empty text.");

auto textFrame = shape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

auto textFrameEffective = textFrame->get_TextFrameFormat()->GetEffective();
auto paragraphEffective = paragraph->get_ParagraphFormat()->GetEffective();
auto portionEffective = portion->get_PortionFormat()->GetEffective();

System::Console::WriteLine(u"Text frame margins:");
System::Console::WriteLine(System::String(u"  Left: ") + textFrameEffective->get_MarginLeft());
System::Console::WriteLine(System::String(u"  Top: ") + textFrameEffective->get_MarginTop());
System::Console::WriteLine(System::String(u"  Right: ") + textFrameEffective->get_MarginRight());
System::Console::WriteLine(System::String(u"  Bottom: ") + textFrameEffective->get_MarginBottom());
System::Console::WriteLine(System::String(u"Paragraph alignment: ") + System::ObjectExt::ToString(paragraphEffective->get_Alignment()));
System::Console::WriteLine(System::String(u"Font height: ") + portionEffective->get_FontHeight());
System::Console::WriteLine(System::String(u"Bold: ") + System::ObjectExt::ToString(portionEffective->get_FontBold()));

auto effectiveTextStyle = textFrame->get_TextFrameFormat()->get_TextStyle()->GetEffective();
for (int level = 0; level < 9; ++level)
{
    auto levelEffective = effectiveTextStyle->GetLevel(level);
    System::Console::WriteLine(System::String(u"Level ") + level + u" indent: " + levelEffective->get_Indent());
}

presentation->Dispose();
```

## **Effektive 3D‑Eigenschaften abrufen**

[IThreeDFormat::GetEffective](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/) gibt ein [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformateffectivedata/)‑Objekt zurück, das alle aufgelösten 3D‑Einstellungen zusammenfasst. Seine [camera](https://reference.aspose.com/slides/de/cpp/aspose.slides/icameraeffectivedata/), [light rig](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilightrigeffectivedata/), [top bevel](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapebeveleffectivedata/) und [bottom bevel](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapebeveleffectivedata/) Daten stellen die entsprechenden effektiven Einstellungen bereit. Das gleichzeitige Auslesen dieser zusammengehörigen Einstellungen erleichtert das Verständnis des finalen 3D‑Aussehens einer Form.

Für dieses Beispiel muss `shape-3d.pptx` mindestens eine Form auf der ersten Folie enthalten. Wenden Sie 3D‑Kamera-, Beleuchtungs‑ oder Abschrägungs‑Einstellungen auf diese Form an, wenn die Ausgabe Werte enthalten soll, die von den Standards abweichen.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"shape-3d.pptx");

if (presentation->get_Slides()->get_Count() == 0 || presentation->get_Slide(0)->get_Shapes()->get_Count() == 0)
    throw System::InvalidOperationException(u"The first slide must contain a shape.");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto threeDEffective = shape->get_ThreeDFormat()->GetEffective();

System::Console::WriteLine(u"Camera:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_Camera()->get_CameraType()));
System::Console::WriteLine(System::String(u"  Field of view: ") + threeDEffective->get_Camera()->get_FieldOfViewAngle());
System::Console::WriteLine(System::String(u"  Zoom: ") + threeDEffective->get_Camera()->get_Zoom());

System::Console::WriteLine(u"Light rig:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_LightType()));
System::Console::WriteLine(System::String(u"  Direction: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_Direction()));

System::Console::WriteLine(u"Top bevel:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_BevelTop()->get_BevelType()));
System::Console::WriteLine(System::String(u"  Width: ") + threeDEffective->get_BevelTop()->get_Width());
System::Console::WriteLine(System::String(u"  Height: ") + threeDEffective->get_BevelTop()->get_Height());

presentation->Dispose();
```

## **Effektive Tabellenformatierung abrufen**

Tabellenformatierung kann aus dem Tabellenstil und aus Formaten stammen, die auf die gesamte Tabelle, eine Spalte, eine Zeile oder eine einzelne Zelle angewendet werden. Bei Konflikten zwischen explizit definierten Füllungen ist die Priorität Zelle, Zeile, Spalte und dann gesamte Tabelle. Das effektive Format einer Zelle ist das endgültige Format, das zum Zeichnen dieser Zelle verwendet wird.

Für dieses Beispiel muss `table-formatting.pptx` mindestens eine Tabelle auf der ersten Folie enthalten. Die Tabelle muss mindestens eine Zeile und eine Spalte haben. Der Code sucht nach einem [ITable](https://reference.aspose.com/slides/de/cpp/aspose.slides/itable/), anstatt anzunehmen, dass die erste Form eine Tabelle ist.

```cpp
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"table-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (System::ObjectExt::Is<ITable>(candidate))
    {
        table = System::ExplicitCast<ITable>(candidate);
        break;
    }
}

if (table == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain a table.");

if (table->get_Rows()->get_Count() == 0 || table->get_Columns()->get_Count() == 0)
    throw System::InvalidOperationException(u"The table must contain at least one cell.");

auto tableEffective = table->get_TableFormat()->GetEffective();
auto rowEffective = table->get_Row(0)->get_RowFormat()->GetEffective();
auto columnEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective();
auto cellEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective();

System::Console::WriteLine(System::String(u"Table fill: ") + System::ObjectExt::ToString(tableEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Row fill: ") + System::ObjectExt::ToString(rowEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Column fill: ") + System::ObjectExt::ToString(columnEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Final cell fill: ") + System::ObjectExt::ToString(cellEffective->get_FillFormat()->get_FillType()));

presentation->Dispose();
```

Wenn Sie die Farbe benötigen und nicht nur den Fülltyp, prüfen Sie zuerst das effektive [FillType](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifillformateffectivedata/), und lesen dann die für diesen Typ passende Eigenschaft – zum Beispiel [SolidFillColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifillformateffectivedata/) für eine einfarbige Füllung.

## **Effektive Daten nach Änderungen erneut auslesen**

Effektive Daten beschreiben die Formatierungshierarchie zum Zeitpunkt ihrer Auflösung. Rufen Sie `GetEffective` erneut auf, nachdem Sie etwas geändert haben, das an dieser Hierarchie teilnehmen kann, einschließlich:

- der lokalen Formatierung des Objekts;
- der Absatz‑ oder Textfeld‑Standardeinstellungen;
- eines Tabellenstils, einer Tabelle, Spalte, Zeile oder Zellenformat;
- Layout‑ oder Master‑Folien‑Formatierung;
- Design‑Daten oder Präsentations‑Standardeinstellungen;
- das dem Folie zugewiesene Layout oder den Master.

Bewahren Sie kein effektives Datenobjekt als dauerhaften Schnappschuss auf. Aspose.Slides kann einige effektive Daten intern zwischenspeichern, und ein späterer Aufruf von `GetEffective` kann diese Daten aktualisieren. Wenn Sie Werte vor und nach einer Änderung vergleichen müssen, kopieren Sie die benötigten skalaren Werte – etwa Schriftgröße, Farbe, Ausrichtung oder Abschrägungsbreite – in eigene Variablen, bevor Sie die Änderung vornehmen.

Um einen Wert zu ändern, aktualisieren Sie das entsprechende lokale Formatobjekt und rufen anschließend `GetEffective` auf, um das Ergebnis zu prüfen. Effektive Datenobjekte selbst sind schreibgeschützt.

## **FAQ**

**Wie kann ich feststellen, welche Ebene einen effektiven Wert geliefert hat?**

Effektive Daten enthalten den endgültigen Wert, jedoch nicht dessen Quelle. Untersuchen Sie die jeweiligen lokalen Objekte von der spezifischsten Ebene nach außen. Für Text kann dies den Abschnitt, Absatz, das Textfeld, das Layout, den Master, das Design und die Präsentations‑Standards umfassen. Nicht definierte Werte wie `std::numeric_limits<float>::quiet_NaN()` oder `nullptr` zeigen an, dass die Suche zu einer anderen Ebene fortgesetzt wird.

**Was passiert, wenn keine Ebene eine Eigenschaft definiert?**

Aspose.Slides ermittelt den entsprechenden PowerPoint‑ oder Bibliotheks‑Standard. Dieser aufgelöste Wert erscheint in den effektiven Daten, obwohl kein lokales Objekt ihn explizit definiert.

**Warum entspricht ein effektiver Wert manchmal dem lokalen Wert?**

Der lokale Wert hat die Vererbungsberechnung gewonnen. Das ist zu erwarten, wenn die Eigenschaft explizit am Objekt gesetzt ist und keine spezifischere Regel sie überschreibt.

**Wann sollte ich lokale Daten anstelle von effektiven Daten verwenden?**

Verwenden Sie lokale Daten, um ein bestimmtes Formatierungsebene zu prüfen oder zu bearbeiten. Verwenden Sie effektive Daten, wenn Sie das endgültige Erscheinungsbild nach Vererbung, Design‑Regeln und angewendeten Stilen benötigen. Das [vollständiges Vergleichsbeispiel](#compare-local-inherited-and-effective-values) demonstriert beides im gleichen Arbeitsablauf.