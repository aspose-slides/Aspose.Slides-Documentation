---
title: Ermitteln von effektiven Formeigenschaften aus Präsentationen in C++
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/cpp/shape-effective-properties/
keywords:
- Formeigenschaften
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
description: "Erfahren Sie, wie Aspose.Slides für C++ effektive Formeigenschaften berechnet und anwendet, um eine präzise PowerPoint-Wiedergabe zu gewährleisten."
---
## **Übersicht**

Dieses Thema erklärt den Unterschied zwischen **lokalen** und **effektiven** Eigenschaften. Lokale Werte sind Werte, die direkt auf einer bestimmten Formatierungsebene festgelegt werden, zum Beispiel:

1. Abschnittseigenschaften auf einer Folie.  
1. Textstile der Prototypform auf einem Layout‑ oder Master‑Folie, wenn die Form des Textfelds des Abschnitts einen hat.  
1. Globale Texteinstellungen in einer Präsentation.

Lokale Werte können auf jeder Ebene definiert oder weggelassen werden. Wenn Aspose.Slides die endgültige „wie gerenderte“ Formatierung benötigt, löst es die Vererbungskette auf und gibt **effektive** Werte zurück. Sie können sie erhalten, indem Sie die Methode `GetEffective` auf dem lokalen Formatobjekt aufrufen.

Das folgende Beispiel zeigt, wie man effektive Werte erhält. Es wird angenommen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) mit einem Textfeld und mindestens einem Abschnitt ist.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="primary" %}}
Effektive Formatierungsdaten repräsentieren die aktuell berechnete Formatierung nach Anwendung der Vererbung. In der aktuellen Implementierung können einige effektive Datenobjekte, wie beispielsweise [IPortionFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportionformateffectivedata/), intern zwischengespeichert werden. Ein erneuter Aufruf von `GetEffective` nach Änderung der übergeordneten oder vererbten Formatierung kann die zwischengespeicherten Daten aktualisieren, und ein zuvor erhaltenes Objekt stellt möglicherweise nicht mehr den früheren Zustand dar. Wenn Sie effektive Werte für eine spätere Wiederverwendung aufbewahren müssen, kopieren Sie die erforderlichen Eigenschaften, wie Schriftgröße, Füllfarbe, Schriftstil oder Ausrichtung, in Ihr eigenes Datenobjekt.
{{% /alert %}}

## **Effektive Eigenschaften einer Kamera abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Kamera. Das Interface [ICameraEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/icameraeffectivedata/) stellt ein unveränderliches Objekt dar, das effektive Kameraeigenschaften enthält. Eine Instanz von [ICameraEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/icameraeffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformateffectivedata/) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/) liefert.

Das folgende Codebeispiel zeigt, wie man effektive Kameraeigenschaften abruft. Es wird angenommen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

```cpp
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

## **Effektive Eigenschaften einer Lichtanlage abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Lichtanlage. Das Interface [ILightRigEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilightrigeffectivedata/) stellt ein unveränderliches Objekt dar, das effektive Lichteigenschaften enthält. Eine Instanz von [ILightRigEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilightrigeffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformateffectivedata/) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/) liefert.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften der Lichtanlage abruft. Es wird angenommen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

```cpp
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

## **Effektive Eigenschaften einer Fasenform abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Fasenform. Das Interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapebeveleffectivedata/) stellt ein unveränderliches Objekt dar, das effektive Flächenrelief‑Eigenschaften für eine Form enthält. Eine Instanz von [IShapeBevelEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapebeveleffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformateffectivedata/) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/) liefert.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften der oberen Fase einer Form abruft. Es wird angenommen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

```cpp
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

## **Effektive Eigenschaften eines Textfelds abrufen**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textfelds abrufen. Das Interface [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformateffectivedata/) enthält effektive Formatierungseigenschaften für Textfelder.

Das folgende Codebeispiel zeigt, wie man effektive Textfeldformatierungseigenschaften erhält. Es wird angenommen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) mit einem Textfeld ist.

```cpp
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

## **Effektive Eigenschaften eines Textstils abrufen**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textstils abrufen. Das Interface [ITextStyleEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextstyleeffectivedata/) enthält effektive Eigenschaften für Textstile.

Das folgende Codebeispiel zeigt, wie man effektive Textstileigenschaften erhält. Es wird angenommen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) mit einem Textfeld ist.

```cpp
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

## **Den effektiven Schriftgrößenwert abrufen**

Mit Aspose.Slides können Sie die effektive Schriftgröße ermitteln. Der folgende Code demonstriert, wie sich die effektive Schriftgröße eines Abschnitts ändert, nachdem lokale Schriftgrößenwerte auf verschiedenen Ebenen der Präsentationsstruktur gesetzt wurden.

```cpp
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

## **Effektives Füllformat für eine Tabelle abrufen**

Mit Aspose.Slides können Sie effektive Füllformatierungen für verschiedene Tabellenteile erhalten. Das Interface [IFillFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifillformateffectivedata/) enthält effektive Füllformatierungs‑Eigenschaften. Die Zellformatierung hat höhere Priorität als die Zeilenformatierung, die Zeilenformatierung hat höhere Priorität als die Spaltenformatierung, und die Spaltenformatierung hat höhere Priorität als die formatierung der gesamten Tabelle.

Daher werden die Eigenschaften von [ICellFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/icellformateffectivedata/) zum Zeichnen der Tabellenzelle verwendet. Das folgende Codebeispiel zeigt, wie man effektive Füllformatierung für verschiedene Tabellenteile abruft. Es wird angenommen, dass die erste Form auf der ersten Folie ein [ITable](https://reference.aspose.com/slides/de/cpp/aspose.slides/itable/) ist.

```cpp
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

**Gibt `GetEffective` einen Schnappschuss zurück?**

Nicht immer. Effektive Daten repräsentieren die berechnete Formatierung nach Anwendung der Vererbung, aber einige effektive Datenobjekte können intern zwischengespeichert werden. Ein nachfolgender Aufruf von `GetEffective` kann die Formatierung neu berechnen und die zwischengespeicherten Daten aktualisieren, sodass ein zuvor erhaltenes Objekt nicht als dauerhafter Schnappschuss betrachtet werden sollte.

**Wann sollte ich effektive Eigenschaften erneut auslesen?**

Rufen Sie `GetEffective` erneut auf, nachdem Sie lokale Formatierung, übergeordnete Stile, Layout‑Formatierung, Master‑Formatierung oder Präsentations‑Standardeinstellungen geändert haben. Der nächste Aufruf bewertet die Formatierungshierarchie neu und liefert das aktuelle effektive Ergebnis.

**Wirkt sich das Ändern oder Entfernen eines Layout‑/Master‑Folien‑Elements auf bereits abgerufene effektive Eigenschaften aus?**

Ja, die Änderung wird beim nächsten Aufruf von `GetEffective` berücksichtigt. Wenn eine übergeordnete Formatierungsquelle geändert oder entfernt wird, können zuvor erhaltene effektive Daten veraltet sein. Sobald `GetEffective` erneut aufgerufen wird, bewertet Aspose.Slides den Formatierungsbaum neu und die resultierenden Schriftarten, Farben, Größen oder anderen Werte können sich ändern.

**Kann ich Werte über effektive Datenobjekte ändern?**

Nein. Effektive Datenobjekte geben nur berechnete Werte wieder. Nehmen Sie Änderungen in den lokalen Formatierungsobjekten vor und rufen Sie anschließend die effektiven Werte erneut ab.

**Was geschieht, wenn eine Eigenschaft weder auf der Form‑Ebene, noch im Layout/Master, noch in den globalen Einstellungen gesetzt ist?**

Der effektive Wert wird durch den Standardmechanismus ermittelt, der die Vorgaben von PowerPoint und Aspose.Slides umfasst. Dieser aufgelöste Wert wird Teil der aktuellen effektiven Daten.

**Kann ich aus einem effektiven Schriftwert erkennen, welche Ebene die Größe oder den Schriftschnitt bereitgestellt hat?**

Nicht direkt. Effektive Daten liefern nur den Endwert. Um die Quelle zu finden, prüfen Sie die lokalen Werte auf Abschnitt‑, Absatz‑, Textfeld‑ und Textstil‑Ebenen im Layout, Master und Präsentations‑Level, um zu sehen, wo die erste explizite Definition vorkommt.

**Warum sehen effektive Werte manchmal identisch zu den lokalen aus?**

Weil der lokale Wert letztlich endgültig war (keine höhere Vererbung nötig war). In solchen Fällen stimmt der effektive Wert mit dem lokalen überein.

**Wann sollte ich effektive Eigenschaften verwenden und wann nur mit lokalen arbeiten?**

Verwenden Sie effektive Daten, wenn Sie das „wie gerenderte“ Ergebnis nach Anwendung aller Vererbungen benötigen, etwa zum Angleichen von Farben, Einzügen oder Größen. Wenn Sie diese Werte unabhängig von späteren Formatierungsänderungen behalten müssen, kopieren Sie die benötigten Eigenschaften in Ihr eigenes Objekt. Wenn Sie die Formatierung gezielt auf einer bestimmten Ebene ändern möchten, passen Sie die lokalen Eigenschaften an und lesen Sie bei Bedarf die effektiven Daten erneut, um das Ergebnis zu überprüfen.