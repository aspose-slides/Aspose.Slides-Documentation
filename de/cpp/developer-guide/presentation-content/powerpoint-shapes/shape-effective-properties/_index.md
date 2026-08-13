---
title: Ermitteln von effektiven Formeigenschaften aus Präsentationen in C++
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/cpp/shape-effective-properties/
keywords:
- Formeigenschaften
- Kameraeigenschaften
- Lichtrig
- Abgeschrägte Form
- Textfeld
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für C++ effektive Formeigenschaften berechnet und anwendet, um eine präzise PowerPoint-Darstellung zu gewährleisten."
---
## **Übersicht**

Dieses Thema erklärt den Unterschied zwischen **lokalen** und **effektiven** Eigenschaften. Lokale Werte sind Werte, die direkt auf einer bestimmten Formatierungsebene festgelegt werden, beispielsweise:

1. Abschnittseigenschaften auf einer Folie.
1. Textstile von Prototypformen in einem Layout‑ oder Master‑Folien, wenn die Textfeld‑Form des Abschnitts einen hat.
1. Globale Texteinstellungen in einer Präsentation.

Lokale Werte können auf jeder Ebene definiert oder weggelassen werden. Wenn Aspose.Slides die endgültige „wie gerenderte“ Formatierung benötigt, löst es die Vererbungskette auf und gibt **effektive** Werte zurück. Sie können diese erhalten, indem Sie die Methode `GetEffective` des lokalen Formatobjekts aufrufen.

Das folgende Beispiel zeigt, wie man effektive Werte erhält. Es wird angenommen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) mit einem Textfeld und mindestens einem Abschnitt ist.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="info" %}}
Effektive Formatierungsdaten stellen die aktuell berechnete Formatierung dar, nachdem die Vererbung angewendet wurde. In der aktuellen Implementierung können einige effektive Datenobjekte, wie z. B. [IPortionFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportionformateffectivedata/), intern zwischengespeichert werden. Ein erneuter Aufruf von `GetEffective` nach dem Ändern von Eltern‑ oder geerbter Formatierung kann die zwischengespeicherten Daten aktualisieren, und ein zuvor erhaltenes Objekt stellt möglicherweise nicht mehr den früheren Zustand dar. Wenn Sie effektive Werte für spätere Wiederverwendung behalten müssen, kopieren Sie die benötigten Eigenschaften, wie Schrifthöhe, Füllfarbe, Schriftstil oder Ausrichtung, in Ihr eigenes Datenobjekt.
{{% /alert %}}

## **Effektive Eigenschaften einer Kamera erhalten**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Kamera. Das Interface [ICameraEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/icameraeffectivedata/) repräsentiert ein unveränderliches Objekt, das effektive Kameraeigenschaften enthält. Eine Instanz von [ICameraEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/icameraeffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformateffectivedata/) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/) liefert.

Das folgende Codebeispiel zeigt, wie man effektive Kameraeigenschaften abruft. Es wird angenommen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto camera = threeDEffectiveData->get_Camera();

System::Console::WriteLine(u"= Effective camera properties =");
auto cameraType = System::ObjectExt::ToString(camera->get_CameraType());
System::Console::WriteLine(System::String(u"Type: ") + cameraType);

auto fieldOfViewAngle = camera->get_FieldOfViewAngle();
System::Console::WriteLine(System::String(u"Field of view: ") + fieldOfViewAngle);

auto cameraZoom = camera->get_Zoom();
System::Console::WriteLine(System::String(u"Zoom: ") + cameraZoom);

presentation->Dispose();
```

## **Effektive Eigenschaften einer Lichtrig erhalten**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Lichtrig. Das Interface [ILightRigEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilightrigeffectivedata/) repräsentiert ein unveränderliches Objekt, das effektive Eigenschaften der Lichtrig enthält. Eine Instanz von [ILightRigEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilightrigeffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformateffectivedata/) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/) liefert.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften der Lichtrig abruft. Es wird angenommen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

```cpp
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto lightRig = threeDEffectiveData->get_LightRig();

System::Console::WriteLine(u"= Effective light rig properties =");
auto lightType = System::ObjectExt::ToString(lightRig->get_LightType());
System::Console::WriteLine(System::String(u"Type: ") + lightType);

auto lightDirection = System::ObjectExt::ToString(lightRig->get_Direction());
System::Console::WriteLine(System::String(u"Direction: ") + lightDirection);

presentation->Dispose();
```

## **Effektive Eigenschaften einer abgeschrägten Form erhalten**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Formabschrägung. Das Interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapebeveleffectivedata/) repräsentiert ein unveränderliches Objekt, das effektive Reliefeigenschaften einer Form enthält. Eine Instanz von [IShapeBevelEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapebeveleffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformateffectivedata/) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/) liefert.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften der oberen Abschrägung einer Form abruft. Es wird angenommen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto bevelTop = threeDEffectiveData->get_BevelTop();

System::Console::WriteLine(u"= Effective shape's top face relief properties =");
auto bevelType = System::ObjectExt::ToString(bevelTop->get_BevelType());
System::Console::WriteLine(System::String(u"Type: ") + bevelType);

auto bevelWidth = bevelTop->get_Width();
System::Console::WriteLine(System::String(u"Width: ") + bevelWidth);

auto bevelHeight = bevelTop->get_Height();
System::Console::WriteLine(System::String(u"Height: ") + bevelHeight);

presentation->Dispose();
```

## **Effektive Eigenschaften eines Textfelds erhalten**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textfelds abrufen. Das Interface [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformateffectivedata/) enthält effektive Formatierungseigenschaften für Textfelder.

Das folgende Codebeispiel zeigt, wie man effektive Textfeldformatierungseigenschaften abruft. Es wird angenommen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) mit einem Textfeld ist.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextFrameFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto effectiveTextFrameFormat = shape->get_TextFrame()->get_TextFrameFormat()->GetEffective();

auto anchoringType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AnchoringType());
System::Console::WriteLine(System::String(u"Anchoring type: ") + anchoringType);

auto autofitType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AutofitType());
System::Console::WriteLine(System::String(u"Autofit type: ") + autofitType);

auto textVerticalType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_TextVerticalType());
System::Console::WriteLine(System::String(u"Text vertical type: ") + textVerticalType);

System::Console::WriteLine(u"Margins");
auto marginLeft = effectiveTextFrameFormat->get_MarginLeft();
System::Console::WriteLine(System::String(u"   Left: ") + marginLeft);

auto marginTop = effectiveTextFrameFormat->get_MarginTop();
System::Console::WriteLine(System::String(u"   Top: ") + marginTop);

auto marginRight = effectiveTextFrameFormat->get_MarginRight();
System::Console::WriteLine(System::String(u"   Right: ") + marginRight);

auto marginBottom = effectiveTextFrameFormat->get_MarginBottom();
System::Console::WriteLine(System::String(u"   Bottom: ") + marginBottom);

presentation->Dispose();
```

## **Effektive Eigenschaften eines Textstils erhalten**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textstils abrufen. Das Interface [ITextStyleEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextstyleeffectivedata/) enthält effektive Textstileigenschaften.

Das folgende Codebeispiel zeigt, wie man effektive Textstileigenschaften abruft. Es wird angenommen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) mit einem Textfeld ist.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/ITextStyleEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto effectiveTextStyle = shape->get_TextFrame()->get_TextFrameFormat()->get_TextStyle()->GetEffective();
int levelCount = 9;

for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    auto effectiveStyleLevel = effectiveTextStyle->GetLevel(levelIndex);

    auto depth = effectiveStyleLevel->get_Depth();
    auto indent = effectiveStyleLevel->get_Indent();
    auto alignment = System::ObjectExt::ToString(effectiveStyleLevel->get_Alignment());
    auto fontAlignment = System::ObjectExt::ToString(effectiveStyleLevel->get_FontAlignment());

    System::Console::WriteLine(System::String(u"= Effective paragraph formatting for style level #") + levelIndex + u" =");
    System::Console::WriteLine(System::String(u"Depth: ") + depth);
    System::Console::WriteLine(System::String(u"Indent: ") + indent);
    System::Console::WriteLine(System::String(u"Alignment: ") + alignment);
    System::Console::WriteLine(System::String(u"Font alignment: ") + fontAlignment);
}

presentation->Dispose();
```

## **Den effektiven Schriftgrößenwert erhalten**

Mit Aspose.Slides können Sie die effektive Schriftgröße ermitteln. Der folgende Code demonstriert, wie sich die effektive Schriftgröße eines Abschnitts ändert, nachdem lokale Schriftgrößenwerte auf verschiedenen Ebenen der Präsentationsstruktur gesetzt wurden.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 400.0f, 75.0f, false);
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portions = paragraph->get_Portions();
portions->Clear();

auto firstPortion = System::MakeObject<Portion>(u"Sample text with first portion");
auto secondPortion = System::MakeObject<Portion>(u" and second portion.");

portions->Add(firstPortion);
portions->Add(secondPortion);

System::Console::WriteLine(u"Effective font height just after creation:");
auto firstPortionFormat = firstPortion->get_PortionFormat();
auto secondPortionFormat = secondPortion->get_PortionFormat();

auto printEffectiveFontHeights = [&]()
{
    auto firstPortionFontHeight = firstPortionFormat->GetEffective()->get_FontHeight();
    auto secondPortionFontHeight = secondPortionFormat->GetEffective()->get_FontHeight();

    System::Console::WriteLine(System::String(u"Portion #0: ") + firstPortionFontHeight);
    System::Console::WriteLine(System::String(u"Portion #1: ") + secondPortionFontHeight);
};

printEffectiveFontHeights();

presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(24.0f);

System::Console::WriteLine(u"Effective font height after setting the presentation default font height:");
printEffectiveFontHeights();

paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(40.0f);

System::Console::WriteLine(u"Effective font height after setting paragraph default font height:");
printEffectiveFontHeights();

firstPortionFormat->set_FontHeight(55.0f);

System::Console::WriteLine(u"Effective font height after setting portion #0 font height:");
printEffectiveFontHeights();

secondPortionFormat->set_FontHeight(18.0f);

System::Console::WriteLine(u"Effective font height after setting portion #1 font height:");
printEffectiveFontHeights();

presentation->Save(u"SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Effektives Füllformat für eine Tabelle erhalten**

Mit Aspose.Slides können Sie effektive Füllformatierungen für verschiedene Tabellenteile erhalten. Das Interface [IFillFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifillformateffectivedata/) enthält effektive Füllformatierungseigenschaften. Die Zellformatierung hat höhere Priorität als die Zeilenformatierung, die Zeilenformatierung hat höhere Priorität als die Spaltenformatierung, und die Spaltenformatierung hat höhere Priorität als die Formatierung der gesamten Tabelle.

Infolgedessen werden die Eigenschaften von [ICellFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/icellformateffectivedata/) verwendet, um die Tabellenzelle zu zeichnen. Das folgende Codebeispiel zeigt, wie man effektive Füllformatierung für verschiedene Tabellenteile abruft. Es wird angenommen, dass die erste Form auf der ersten Folie ein [ITable](https://reference.aspose.com/slides/de/cpp/aspose.slides/itable/) ist.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/ICellFormatEffectiveData.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IColumnFormatEffectiveData.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/IRowFormatEffectiveData.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <DOM/Table/ITableFormatEffectiveData.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto tableFillFormatEffective = table->get_TableFormat()->GetEffective()->get_FillFormat();
auto rowFillFormatEffective = table->get_Row(0)->get_RowFormat()->GetEffective()->get_FillFormat();
auto columnFillFormatEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective()->get_FillFormat();
auto cellFillFormatEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective()->get_FillFormat();

presentation->Dispose();
```

## **FAQ**

### Gibt `GetEffective` einen Schnappschuss zurück?

Nicht immer. Effektive Daten stellen die berechnete Formatierung nach Anwendung der Vererbung dar, aber einige effektive Datenobjekte können intern zwischengespeichert werden. Ein nachfolgender Aufruf von `GetEffective` kann die Formatierung neu berechnen und die zwischengespeicherten Daten aktualisieren, sodass ein zuvor erhaltenes Objekt nicht als dauerhafter Schnappschuss behandelt werden sollte.

### Wann sollte ich effektive Eigenschaften erneut auslesen?

Rufen Sie `GetEffective` erneut auf, nachdem Sie lokale Formatierung, übergeordnete Stile, Layout‑Formatierung, Master‑Formatierung oder Präsentations‑Standardwerte geändert haben. Der nächste Aufruf bewertet die Formatierungshierarchie neu und gibt das aktuelle effektive Ergebnis zurück.

### Wirkt sich das Ändern oder Entfernen einer Layout‑/Master‑Folien auf bereits abgerufene effektive Eigenschaften aus?

Ja, die Änderung wird beim nächsten Aufruf von `GetEffective` berücksichtigt. Wenn eine übergeordnete Formatierungsquelle geändert oder entfernt wird, können zuvor erhaltene effektive Daten veraltet sein. Sobald `GetEffective` erneut aufgerufen wird, wertet Aspose.Slides den Formatierungsbaum neu aus und die resultierenden Schriftarten, Farben, Größen oder anderen Werte können sich ändern.

### Kann ich Werte über effektive Datenobjekte ändern?

Nein. Effektive Datenobjekte geben nur berechnete Werte zurück. Änderungen müssen in den lokalen Formatierungsobjekten vorgenommen werden, und anschließend müssen die effektiven Werte erneut abgerufen werden.

### Was geschieht, wenn eine Eigenschaft weder auf Form‑, Layout‑/Master‑ noch auf globaler Ebene gesetzt ist?

Der effektive Wert wird durch den Standardmechanismus bestimmt, der die Vorgaben von PowerPoint und Aspose.Slides umfasst. Dieser aufgelöste Wert wird Bestandteil der aktuellen effektiven Daten.

### Kann ich anhand eines effektiven Schriftwertes erkennen, welche Ebene die Größe oder den Schriftschnitt bereitgestellt hat?

Nicht direkt. Effektive Daten geben nur den endgültigen Wert zurück. Um die Quelle zu ermitteln, prüfen Sie die lokalen Werte auf Abschnitt‑, Absatz‑, Textfeld‑ und Textstilebene im Layout, Master und in der Präsentation, um zu sehen, wo die erste explizite Definition vorkommt.

### Warum sehen effektive Werte manchmal identisch zu den lokalen aus?

Weil der lokale Wert schließlich endgültig war (keine höherstufige Vererbung war erforderlich). In solchen Fällen stimmt der effektive Wert mit dem lokalen überein.

### Wann sollte ich effektive Eigenschaften verwenden und wann nur lokale?

Verwenden Sie effektive Daten, wenn Sie das „wie gerenderte“ Ergebnis nach Anwendung aller Vererbungen benötigen, etwa zum Angleichen von Farben, Einzügen oder Größen. Wenn Sie diese Werte unabhängig von späteren Formatierungsänderungen bewahren wollen, kopieren Sie die benötigten Eigenschaften in Ihr eigenes Objekt. Wenn Sie die Formatierung auf einer bestimmten Ebene ändern möchten, passen Sie die lokalen Eigenschaften an und lesen Sie bei Bedarf die effektiven Daten erneut, um das Ergebnis zu prüfen.