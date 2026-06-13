---
title: C++ 프레젠테이션에서 도형 유효 속성 가져오기
linktitle: 유효 속성
type: docs
weight: 50
url: /ko/cpp/shape-effective-properties/
keywords:
- 도형 속성
- 카메라 속성
- 조명 리그
- 베벨 도형
- 텍스트 프레임
- 텍스트 스타일
- 글꼴 높이
- 채우기 서식
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++가 정확한 PowerPoint 렌더링을 위해 도형의 유효 속성을 계산하고 적용하는 방법을 알아보세요."
---
## **개요**

이 항목에서는 **로컬** 및 **유효** 속성의 차이점을 설명합니다. 로컬 값은 특정 서식 수준에 직접 설정된 값이며, 예를 들어:

1. 슬라이드의 구간(Portion) 속성.
1. 구간의 텍스트 프레임 모양에 텍스트 스타일이 있는 경우, 레이아웃 또는 마스터 슬라이드의 프로토타입 도형 텍스트 스타일.
1. 프레젠테이션의 전역 텍스트 설정.

로컬 값은 어느 수준에서도 정의하거나 생략할 수 있습니다. Aspose.Slides가 최종 "렌더링된" 서식이 필요할 때는 상속 체인을 해결하여 **유효** 값을 반환합니다. 로컬 서식 객체에서 `GetEffective` 메서드를 호출하면 해당 값을 얻을 수 있습니다.

다음 예제는 유효 값을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형이 텍스트 프레임과 하나 이상의 구간을 가진 [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)이라고 가정합니다.

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
유효 서식 데이터는 상속이 적용된 후 현재 계산된 서식을 나타냅니다. 현재 구현에서는 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportionformateffectivedata/)와 같은 일부 유효 데이터 객체가 내부에 캐시될 수 있습니다. 부모나 상속된 서식을 변경한 후 `GetEffective`을 다시 호출하면 캐시된 데이터를 새로 고칠 수 있으며, 이전에 얻은 객체는 더 이상 이전 상태를 나타내지 않을 수 있습니다. 나중에 재사용하기 위해 유효 값을 보존해야 하는 경우, 글꼴 높이, 채우기 색, 글꼴 스타일 또는 정렬과 같은 필요한 속성을 자체 데이터 객체에 복사하십시오.
{{% /alert %}}

## **카메라의 유효 속성 가져오기**

Aspose.Slides를 사용하면 카메라의 유효 속성을 가져올 수 있습니다. [ICameraEffectiveData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icameraeffectivedata/) 인터페이스는 카메라의 유효 속성을 포함하는 불변 객체를 나타냅니다. [ICameraEffectiveData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icameraeffectivedata/) 인스턴스는 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformateffectivedata/)를 통해 노출되며, 이는 [IThreeDFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/)에 대한 유효 값을 제공합니다.

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

## **조명 리그의 유효 속성 가져오기**

Aspose.Slides를 사용하면 조명 리그의 유효 속성을 가져올 수 있습니다. [ILightRigEffectiveData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilightrigeffectivedata/) 인터페이스는 조명 리그의 유효 속성을 포함하는 불변 객체를 나타냅니다. [ILightRigEffectiveData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilightrigeffectivedata/) 인스턴스는 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformateffectivedata/)를 통해 노출되며, 이는 [IThreeDFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/)에 대한 유효 값을 제공합니다.

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

## **베벨 형태의 유효 속성 가져오기**

Aspose.Slides를 사용하면 베벨 형태의 유효 속성을 가져올 수 있습니다. [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapebeveleffectivedata/) 인터페이스는 도형의 유효 면조절 속성을 포함하는 불변 객체를 나타냅니다. [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapebeveleffectivedata/) 인스턴스는 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformateffectivedata/)를 통해 노출되며, 이는 [IThreeDFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/)에 대한 유효 값을 제공합니다.

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

## **텍스트 프레임의 유효 속성 가져오기**

Aspose.Slides를 사용하면 텍스트 프레임의 유효 속성을 가져올 수 있습니다. [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframeformateffectivedata/) 인터페이스는 텍스트 프레임 서식의 유효 속성을 포함합니다.

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

## **텍스트 스타일의 유효 속성 가져오기**

Aspose.Slides를 사용하면 텍스트 스타일의 유효 속성을 가져올 수 있습니다. [ITextStyleEffectiveData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextstyleeffectivedata/) 인터페이스는 텍스트 스타일의 유효 속성을 포함합니다.

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

## **유효 글꼴 높이 값 가져오기**

Aspose.Slides를 사용하면 유효 글꼴 높이를 가져올 수 있습니다. 다음 코드는 프레젠테이션 구조의 서로 다른 수준에서 로컬 글꼴 높이 값을 설정한 후 구간의 유효 글꼴 높이가 어떻게 변하는지를 보여줍니다.

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

## **테이블에 대한 유효 채우기 서식 가져오기**

Aspose.Slides를 사용하면 테이블의 다양한 부분에 대한 유효 채우기 서식을 가져올 수 있습니다. [IFillFormatEffectiveData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifillformateffectivedata/) 인터페이스는 유효 채우기 서식 속성을 포함합니다. 셀 서식은 행 서식보다, 행 서식은 열 서식보다, 열 서식은 전체 테이블 서식보다 우선순위가 높습니다.

그 결과, [ICellFormatEffectiveData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icellformateffectivedata/) 속성이 테이블 셀을 그리는 데 사용됩니다. 다음 코드는 테이블의 다양한 부분에 대한 유효 채우기 서식을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형이 [ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/)이라고 가정합니다.

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

**`GetEffective` 메서드는 스냅샷을 반환합니까?**

항상 그렇지는 않습니다. 유효 데이터는 상속이 적용된 후 계산된 서식을 나타내지만, 일부 유효 데이터 객체는 내부에 캐시될 수 있습니다. 이후에 `GetEffective`을 호출하면 서식이 다시 계산되고 캐시된 데이터가 갱신될 수 있으므로, 이전에 얻은 객체를 지속적인 스냅샷으로 간주해서는 안 됩니다.

**언제 유효 속성을 다시 읽어야 합니까?**

로컬 서식, 부모 스타일, 레이아웃 서식, 마스터 서식 또는 프레젠테이션 수준 기본값을 변경한 후 `GetEffective`을 다시 호출하십시오. 다음 호출은 서식 계층을 다시 평가하고 현재 유효 결과를 반환합니다.

**레이아웃/마스터 슬라이드를 변경하거나 제거하면 이미 가져온 유효 속성에 영향을 줍니까?**

예, 변경 사항은 다음 `GetEffective` 호출 시 반영됩니다. 부모 서식 소스가 변경되거나 제거되면 이전에 얻은 유효 데이터는 오래될 수 있습니다. `GetEffective`을 다시 호출하면 Aspose.Slides가 서식 트리를 재평가하고 결과적인 글꼴, 색상, 크기 또는 기타 값이 변경될 수 있습니다.

**유효 데이터 객체를 통해 값을 수정할 수 있습니까?**

아니오. 유효 데이터 객체는 계산된 값을 노출합니다. 로컬 서식 객체에서 변경을 수행한 후 다시 유효 값을 가져와야 합니다.

**도형 수준, 레이아웃/마스터, 전역 설정 중 어느 곳에도 속성이 설정되지 않은 경우 어떻게 됩니까?**

유효 값은 PowerPoint와 Aspose.Slides의 기본값을 포함하는 기본 메커니즘에 의해 결정됩니다. 해결된 값이 현재 유효 데이터의 일부가 됩니다.

**유효 글꼴 값만으로 어느 수준에서 크기나 글꼴이 제공되었는지 알 수 있습니까?**

직접적으로는 알 수 없습니다. 유효 데이터는 최종 값을 반환합니다. 원본을 찾으려면 구간, 단락, 텍스트 프레임 및 레이아웃, 마스터, 프레젠테이션 수준의 텍스트 스타일에서 로컬 값을 확인하여 가장 먼저 명시된 정의가 있는 위치를 찾아야 합니다.

**왜 유효 값이 로컬 값과 동일하게 보일 때가 있습니까?**

로컬 값이 최종 값이 되었기 때문입니다(상위 수준의 상속이 필요하지 않았습니다). 이 경우 유효 값은 로컬 값과 동일합니다.

**언제 유효 속성을 사용하고, 언제 로컬 속성만 사용해야 합니까?**

모든 상속이 적용된 후의 "렌더링된" 결과가 필요할 때는 유효 데이터를 사용하십시오(예: 색상, 들여쓰기, 크기 맞춤). 이러한 값을 나중에 서식이 변경되어도 보존하려면 필요한 속성을 자체 객체에 복사하십시오. 특정 수준에서 서식을 변경하고 싶은 경우 로컬 속성을 수정하고, 필요에 따라 유효 데이터를 다시 읽어 결과를 확인하십시오.