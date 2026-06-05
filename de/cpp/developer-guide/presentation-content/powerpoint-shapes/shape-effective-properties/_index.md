---
title: Ermitteln von effektiven Formeigenschaften aus Präsentationen in C++
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/cpp/shape-effective-properties/
keywords:
- Formeigenschaften
- Kameraeigenschaften
- Licht-Rig
- Formabschrägung
- Textfeld
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für C++ effektive Formeigenschaften berechnet und anwendet, um eine präzise PowerPoint-Darstellung zu gewährleisten."
---
## **Übersicht**

Dieses Thema erklärt den Unterschied zwischen **lokalen** und **effektiven** Eigenschaften. Lokale Werte sind Werte, die direkt auf einer bestimmten Formatierungsebene festgelegt werden, zum Beispiel:

1. Portionseigenschaften auf einer Folie.
1. Textstile von Prototypformen auf einem Layout‑ oder Master‑Slide, wenn die Portion ein Textfeld‑Shape besitzt.
1. Globale Texteinstellungen in einer Präsentation.

Lokale Werte können auf jeder Ebene definiert oder weggelassen werden. Wenn Aspose.Slides die endgültige „wie dargestellt“ Formatierung benötigt, löst es die Vererbungskette auf und gibt **effektive** Werte zurück. Sie können diese erhalten, indem Sie die Methode `GetEffective` des lokalen Formatobjekts aufrufen.

Das folgende Beispiel zeigt, wie man effektive Werte erhält. Es wird angenommen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) mit einem Textfeld und mindestens einer Portion ist.

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
Effektive Formatierungsdaten repräsentieren die aktuell berechnete Formatierung nach Anwendung der Vererbung. In der aktuellen Implementierung können einige effektive Datenobjekte, wie z. B. [IPortionFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportionformateffectivedata/), intern zwischengespeichert werden. Ein erneuter Aufruf von `GetEffective` nach Änderung der übergeordneten oder geerbten Formatierung kann die zwischengespeicherten Daten aktualisieren, und ein zuvor erhaltenes Objekt kann die frühere Situation nicht mehr widerspiegeln. Wenn Sie effektive Werte für eine spätere Wiederverwendung bewahren müssen, kopieren Sie die benötigten Eigenschaften, wie Schriftgröße, Füllfarbe, Schriftstil oder Ausrichtung, in Ihr eigenes Datenobjekt.
{{% /alert %}}

## **Effektive Eigenschaften einer Kamera**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Kamera. Das Interface [ICameraEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/icameraeffectivedata/) stellt ein unveränderliches Objekt dar, das effektive Kameraeigenschaften enthält. Eine [ICameraEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/icameraeffectivedata/)-Instanz wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformateffectivedata/) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/) liefert.

Das folgende Code‑Beispiel zeigt, wie man effektive Eigenschaften für die Kamera erhält. Es wird angenommen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

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

## **Effektive Eigenschaften eines Licht‑Rig**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften eines Licht‑Rig. Das Interface [ILightRigEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilightrigeffectivedata/) stellt ein unveränderliches Objekt dar, das effektive Licht‑Rig‑Eigenschaften enthält. Eine [ILightRigEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilightrigeffectivedata/)-Instanz wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformateffectivedata/) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/) liefert.

Das folgende Code‑Beispiel zeigt, wie man effektive Eigenschaften für das Licht‑Rig erhält. Es wird angenommen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

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

## **Effektive Eigenschaften einer Abschrägung einer Form**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Formabschrägung. Das Interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapebeveleffectivedata/) stellt ein unveränderliches Objekt dar, das effektive Gesichts‑Relief‑Eigenschaften für eine Form enthält. Eine [IShapeBevelEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapebeveleffectivedata/)-Instanz wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformateffectivedata/) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/) liefert.

Das folgende Code‑Beispiel zeigt, wie man effektive Eigenschaften für die obere Abschrägung einer Form erhält. Es wird angenommen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

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

## **Effektive Eigenschaften eines Textfelds**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textfelds erhalten. Das Interface [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformateffectivedata/) enthält effektive Formatierungseigenschaften des Textfelds.

Das folgende Code‑Beispiel zeigt, wie man effektive Textfeld‑Formatierungseigenschaften erhält. Es wird angenommen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) mit einem Textfeld ist.

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

## **Effektive Eigenschaften eines Textstils**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textstils erhalten. Das Interface [ITextStyleEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextstyleeffectivedata/) enthält effektive Textstileigenschaften.

Das folgende Code‑Beispiel zeigt, wie man effektive Textstileigenschaften erhält. Es wird angenommen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) mit einem Textfeld ist.

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

## **Den effektiven Schriftgrößenwert erhalten**

Mit Aspose.Slides können Sie die effektive Schriftgröße erhalten. Der folgende Code demonstriert, wie sich die effektive Schriftgröße einer Portion ändert, nachdem lokale Schriftgrößenwerte auf verschiedenen Ebenen der Präsentationsstruktur gesetzt wurden.

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

## **Effektives Füllformat einer Tabelle erhalten**

Mit Aspose.Slides können Sie effektive Füllformatierung für unterschiedliche Tabellenteile erhalten. Das Interface [IFillFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifillformateffectivedata/) enthält effektive Füllformatierungseigenschaften. Zellenformatierung hat höhere Priorität als Zeilenformatierung, Zeilenformatierung hat höhere Priorität als Spaltenformatierung und Spaltenformatierung hat höhere Priorität als die Formatierung der gesamten Tabelle.

Infolgedessen werden die Eigenschaften von [ICellFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/icellformateffectivedata/) verwendet, um die Tabellenzelle zu zeichnen. Das folgende Code‑Beispiel zeigt, wie man effektive Füllformatierung für unterschiedliche Tabellenteile erhält. Es wird angenommen, dass die erste Form auf der ersten Folie ein [ITable](https://reference.aspose.com/slides/de/cpp/aspose.slides/itable/) ist.

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

Nicht immer. Effektive Daten repräsentieren die berechnete Formatierung nach Anwendung der Vererbung, aber einige effektive Datenobjekte können intern zwischengespeichert werden. Ein nachfolgender Aufruf von `GetEffective` kann die Formatierung neu berechnen und die zwischengespeicherten Daten aktualisieren, sodass ein zuvor erhaltenes Objekt nicht als dauerhafter Schnappschuss behandelt werden sollte.

**Wann sollte ich effektive Eigenschaften erneut auslesen?**

Rufen Sie `GetEffective` erneut auf, nachdem Sie lokale Formatierung, übergeordnete Stile, Layout‑Formatierung, Master‑Formatierung oder Präsentations‑Standardwerte geändert haben. Der nächste Aufruf wertet die Formatierungshierarchie neu aus und liefert das aktuelle effektive Ergebnis.

**Wirkt sich das Ändern oder Entfernen einer Layout‑/Master‑Folie auf bereits abgerufene effektive Eigenschaften aus?**

Ja, die Änderung wird beim nächsten Aufruf von `GetEffective` berücksichtigt. Wenn eine übergeordnete Formatierungsquelle geändert oder entfernt wird, können zuvor erhaltene effektive Daten veraltet sein. Sobald `GetEffective` erneut aufgerufen wird, bewertet Aspose.Slides den Formatierungsbaum neu und die resultierenden Schriftarten, Farben, Größen oder anderen Werte können sich ändern.

**Kann ich Werte über effektive Datenobjekte ändern?**

Nein. Effektive Datenobjekte geben nur berechnete Werte wieder. Änderungen müssen an den lokalen Formatierungsobjekten vorgenommen werden, und anschließend müssen die effektiven Werte erneut abgerufen werden.

**Was passiert, wenn eine Eigenschaft weder auf der Form‑Ebene, noch im Layout/Master, noch in den globalen Einstellungen gesetzt ist?**

Der effektive Wert wird durch den Standard‑Mechanismus bestimmt, der die Vorgaben von PowerPoint und Aspose.Slides umfasst. Dieser aufgelöste Wert wird Teil der aktuellen effektiven Daten.

**Kann ich anhand eines effektiven Schriftwerts erkennen, welche Ebene die Größe oder Schriftart bereitgestellt hat?**

Nicht direkt. Effektive Daten geben nur den endgültigen Wert zurück. Um die Quelle zu ermitteln, prüfen Sie die lokalen Werte auf Portion‑, Absatz‑, Textfeld‑ und Textstil‑Ebene in Layout, Master und Präsentation, um zu sehen, wo die erste explizite Definition vorkommt.

**Warum sehen effektive Werte manchmal identisch zu den lokalen aus?**

Weil der lokale Wert letztlich final war (keine höhere Vererbung nötig war). In solchen Fällen stimmt der effektive Wert mit dem lokalen überein.

**Wann sollte ich effektive Eigenschaften verwenden und wann nur mit lokalen arbeiten?**

Verwenden Sie effektive Daten, wenn Sie das „wie dargestellt“-Ergebnis nach vollständiger Vererbung benötigen, etwa zur Abstimmung von Farben, Einrückungen oder Größen. Wenn Sie diese Werte unverändert behalten möchten, kopieren Sie die benötigten Eigenschaften in Ihr eigenes Objekt. Wenn Sie die Formatierung auf einer bestimmten Ebene ändern wollen, passen Sie die lokalen Eigenschaften an und lesen Sie ggf. die effektiven Daten erneut, um das Ergebnis zu prüfen.