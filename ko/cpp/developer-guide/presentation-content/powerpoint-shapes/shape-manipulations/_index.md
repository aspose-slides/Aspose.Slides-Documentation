---
title: C++에서 프레젠테이션 도형 관리
linktitle: 도형 조작
type: docs
weight: 40
url: /ko/cpp/shape-manipulations/
keywords:
- PowerPoint 도형
- 프레젠테이션 도형
- 슬라이드의 도형
- 도형 찾기
- 도형 복제
- 도형 제거
- 도형 숨기기
- 도형 순서 변경
- Interop 도형 ID 가져오기
- 도형 대체 텍스트
- 도형 레이아웃 형식
- SVG 형식 도형
- 도형을 SVG로
- 도형 정렬
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 도형을 생성, 편집 및 최적화하는 방법을 배우고 고성능 PowerPoint 프레젠테이션을 제공하세요."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션에서 도형을 처리하는 방법을 설명합니다. 슬라이드에서 도형을 찾고, 복제하고, 제거하고, 숨기고, 순서를 변경하고, Interop 도형 ID를 가져오며, 식별 및 추가 처리를 위해 대체 텍스트를 설정하는 방법을 보여줍니다.

또한 도형의 레이아웃 형식에 접근하고, 도형을 SVG로 렌더링하고, 슬라이드에서 도형을 정렬하며, 수평 및 수직 미러링을 위한 플립 속성을 사용하는 방법도 다룹니다. 이와 더불어 도형 결합, 쌓기 순서, 도형 잠금에 대한 간단한 FAQ도 포함되어 있습니다.

## **슬라이드에서 도형 찾기**
이 항목에서는 개발자가 내부 Id를 사용하지 않고 특정 슬라이드에서 도형을 쉽게 찾을 수 있는 간단한 기술을 설명합니다. PowerPoint 프레젠테이션 파일은 내부 고유 Id 외에 슬라이드의 도형을 식별하는 방법이 없습니다. 내부 고유 Id를 사용해 도형을 찾는 것은 개발자에게 어려울 수 있습니다. 모든 슬라이드에 추가된 도형에는 일부 대체 텍스트가 있습니다. 우리는 개발자에게 특정 도형을 찾기 위해 대체 텍스트를 사용할 것을 권장합니다. 향후 변경하려는 개체에 대한 대체 텍스트는 MS PowerPoint에서 정의할 수 있습니다.

원하는 도형의 대체 텍스트를 설정한 후, Aspose.Slides for C++를 사용해 해당 프레젠테이션을 열고 슬라이드에 추가된 모든 도형을 반복합니다. 각 반복에서 도형의 대체 텍스트를 확인하고, 일치하는 대체 텍스트를 가진 도형이 바로 원하는 도형이 됩니다. 이 기술을 더 잘 보여주기 위해, 우리는 슬라이드에서 특정 도형을 찾아 반환하는 메서드 [FindShape](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) 을 만들었습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}

## **도형 복제**
Aspose.Slides for C++를 사용하여 슬라이드에 도형을 복제하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용해 슬라이드의 참조를 얻습니다.
1. 원본 슬라이드의 도형 컬렉션에 접근합니다.
1. 프레젠테이션에 새 슬라이드를 추가합니다.
1. 원본 슬라이드 도형 컬렉션에서 새 슬라이드로 도형을 복제합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제는 슬라이드에 그룹 도형을 추가합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}

## **도형 제거**
Aspose.Slides for C++는 개발자가 모든 도형을 제거할 수 있게 합니다. 슬라이드에서 도형을 제거하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 특정 AlternativeText를 가진 도형을 찾습니다.
1. 도형을 제거합니다.
1. 파일을 디스크에 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}

## **도형 숨기기**
Aspose.Slides for C++는 개발자가 모든 도형을 숨길 수 있게 합니다. 슬라이드에서 도형을 숨기려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 특정 AlternativeText를 가진 도형을 찾습니다.
1. 도형을 숨깁니다.
1. 파일을 디스크에 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}

## **도형 순서 변경**
Aspose.Slides for C++는 개발자가 도형의 순서를 재배열할 수 있게 합니다. 도형 순서를 재배열하면 어떤 도형이 앞에, 어떤 도형이 뒤에 있는지를 지정할 수 있습니다. 슬라이드에서 도형 순서를 변경하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 도형을 추가합니다.
1. 도형의 텍스트 프레임에 텍스트를 입력합니다.
1. 동일한 좌표에 또 다른 도형을 추가합니다.
1. 도형들의 순서를 재배열합니다.
1. 파일을 디스크에 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}

## **Interop 도형 ID 가져오기**
Aspose.Slides for C++는 개발자가 UniqueId 속성과 달리 슬라이드 범위에서 고유한 도형 식별자를 얻을 수 있도록 OfficeInteropShapeId 속성을 IShape 인터페이스와 Shape 클래스에 추가했습니다. OfficeInteropShapeId 속성으로 반환되는 값은 Microsoft.Office.Interop.PowerPoint.Shape 개체의 Id 값에 해당합니다. 아래에 샘플 코드가 제공됩니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}

## **AlternativeText 속성 설정**
Aspose.Slides for C++는 개발자가 도형의 AlternateText를 설정할 수 있게 합니다. 도형의 AlternateText를 설정하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 슬라이드에 원하는 도형을 추가합니다.
1. 새로 추가된 도형으로 작업을 수행합니다.
1. 도형을 순회하여 원하는 도형을 찾습니다.
1. AlternativeText를 설정합니다.
1. 파일을 디스크에 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}

## **도형의 레이아웃 형식 액세스**
Aspose.Slides for C++는 개발자가 도형의 레이아웃 형식에 접근할 수 있게 합니다. 이 문서에서는 도형에 대한 **FillFormat** 및 **LineFormat** 속성에 어떻게 접근하는지 보여줍니다.

아래에 샘플 코드가 제공됩니다.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **도형을 SVG로 렌더링**
이제 Aspose.Slides for C++가 도형을 SVG로 렌더링하는 기능을 지원합니다. Shape 클래스와 IShape 인터페이스에 WriteAsSvg 메서드(및 오버로드)가 추가되었습니다. 이 메서드를 사용하면 도형의 내용을 SVG 파일로 저장할 수 있습니다. 아래 코드 스니펫은 슬라이드의 도형을 SVG 파일로 내보내는 방법을 보여줍니다.

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **도형 정렬**
Aspose.Slides는 도형을 슬라이드 여백을 기준으로 또는 서로를 기준으로 정렬할 수 있게 합니다. 이를 위해 오버로드된 [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab) 메서드가 추가되었습니다. [ShapesAlignmentType](https://reference.aspose.com/slides/ko/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) 열거형은 가능한 정렬 옵션을 정의합니다.

**예제 1**

아래 소스 코드는 인덱스 1, 2, 4인 도형을 슬라이드 상단 경계에 맞춰 정렬합니다.

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```

**예제 2**

아래 예제는 컬렉션에 있는 모든 도형을 컬렉션에서 가장 아래에 있는 도형을 기준으로 정렬하는 방법을 보여줍니다.

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```

## **플립 속성**

Aspose.Slides에서 [ShapeFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shapeframe/) 클래스는 `flipH`와 `flipV` 속성을 통해 도형의 수평 및 수직 미러링을 제어합니다. 두 속성 모두 [NullableBool](https://reference.aspose.com/slides/ko/cpp/aspose.slides/nullablebool/) 유형이며, `True`는 플립, `False`는 플립 없음, `NotDefined`는 기본 동작을 사용함을 나타냅니다. 이러한 값은 도형의 [Frame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_frame/)에서 접근할 수 있습니다.

플립 설정을 수정하려면, 도형의 현재 위치와 크기, 원하는 `flipH`와 `flipV` 값, 회전 각도를 사용해 새로운 [ShapeFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shapeframe/) 인스턴스를 생성합니다. 이 인스턴스를 도형의 [Frame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_frame/)에 할당하고 프레젠테이션을 저장하면 미러 변환이 적용되어 출력 파일에 반영됩니다.

예를 들어, 첫 번째 슬라이드에 기본 플립 설정을 가진 단일 도형이 포함된 sample.pptx 파일이 있다고 가정합니다.

![플립될 도형](shape_to_be_flipped.png)

다음 코드 예제는 도형의 현재 플립 속성을 가져와 수평 및 수직으로 모두 플립합니다.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// 도형의 수평 플립 속성을 가져옵니다.
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// 도형의 수직 플립 속성을 가져옵니다.
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // 수평으로 플립합니다.
auto flipV = NullableBool::True; // 수평으로 플립합니다.
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![플립된 도형](flipped_shape.png)

## **FAQ**

**슬라이드에서 데스크톱 편집기처럼 도형을 결합(합집합/교집합/차집합)할 수 있나요?**

내장된 Boolean 연산 API는 제공되지 않습니다. 원하는 윤곽을 직접 구성하여 근사화할 수 있습니다—예를 들어 [GeometryPath](https://reference.aspose.com/slides/ko/cpp/aspose.slides/geometrypath/)를 통해 결과 기하형을 계산하고 해당 윤곽을 가진 새 도형을 만든 뒤 원본을 선택적으로 제거합니다.

**도형이 항상 “맨 위”에 있도록 z‑order(쌓기 순서)를 제어하려면 어떻게 해야 하나요?**

슬라이드의 [shapes](https://reference.aspose.com/slides/ko/cpp/aspose.slides/baseslide/get_shapes/) 컬렉션 내 삽입/이동 순서를 변경합니다. 예측 가능한 결과를 위해 다른 슬라이드 수정 작업이 모두 끝난 후에 z‑order를 최종 결정하십시오.

**PowerPoint에서 사용자가 도형을 편집하지 못하도록 “잠그”는 방법이 있나요?**

예. [shape-level protection flags](/slides/ko/cpp/applying-protection-to-presentation/)를 설정하면 선택, 이동, 크기 조정, 텍스트 편집 등을 잠글 수 있습니다. 필요에 따라 마스터 또는 레이아웃에 제한을 미러링할 수도 있습니다. 이는 UI 수준 보호이며 보안 기능이 아니므로, 강력한 보호가 필요하면 [읽기 전용 권고 또는 암호](/slides/ko/cpp/password-protected-presentation/)와 같은 파일 수준 제한과 결합하십시오.