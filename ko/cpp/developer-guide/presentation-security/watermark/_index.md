---
title: C++ 프레젠테이션에 워터마크 추가
linktitle: 워터마크
type: docs
weight: 40
url: /ko/cpp/watermark/
keywords:
- 워터마크
- 텍스트 워터마크
- 이미지 워터마크
- 워터마크 추가
- 워터마크 변경
- 워터마크 제거
- 워터마크 삭제
- PPT에 워터마크 추가
- PPTX에 워터마크 추가
- ODP에 워터마크 추가
- PPT에서 워터마크 제거
- PPTX에서 워터마크 제거
- ODP에서 워터마크 제거
- PPT에서 워터마크 삭제
- PPTX에서 워터마크 삭제
- ODP에서 워터마크 삭제
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "C++에서 PowerPoint 및 OpenDocument 프레젠테이션에 텍스트와 이미지 워터마크를 관리하여 초안, 기밀 정보, 저작권 등을 표시합니다."
---
## **소개**

**워터마크**는 프레젠테이션에서 슬라이드에 또는 모든 슬라이드에 사용되는 텍스트 또는 이미지 스탬프입니다. 일반적으로 워터마크는 프레젠테이션이 초안임을 표시하기 위해(예: "Draft" 워터마크), 기밀 정보를 포함하고 있음을 표시하기 위해(예: "Confidential" 워터마크), 어느 회사에 속하는지 지정하기 위해(예: "Company Name" 워터마크), 프레젠테이션 작성자를 식별하기 위해 등 사용됩니다. 워터마크는 프레젠테이션을 복사해서는 안 된다는 표시를 통해 저작권 침해를 방지하는 데 도움이 됩니다. 워터마크는 PowerPoint와 OpenOffice 프레젠테이션 형식 모두에서 사용됩니다. Aspose.Slides에서는 PowerPoint PPT, PPTX 및 OpenOffice ODP 파일 형식에 워터마크를 추가할 수 있습니다.

[**Aspose.Slides**](https://products.aspose.com/slides/ko/cpp/)에서는 PowerPoint 또는 OpenOffice 문서에서 워터마크를 생성하고 디자인 및 동작을 수정하는 다양한 방법이 있습니다. 공통적인 점은 텍스트 워터마크를 추가하려면 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/) 인터페이스를 사용하고, 이미지 워터마크를 추가하려면 [PictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/pictureframe/) 클래스를 사용하거나 워터마크 도형을 이미지로 채워야 한다는 것입니다. `PictureFrame`은 [IShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/) 인터페이스를 구현하므로 도형 객체의 모든 유연한 설정을 사용할 수 있습니다. `ITextFrame`은 도형이 아니며 설정이 제한적이기 때문에 [IShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/) 객체에 래핑됩니다.

워터마크를 적용하는 방법은 두 가지가 있습니다: 단일 슬라이드에 적용하거나 전체 프레젠테이션 슬라이드에 적용하는 것입니다. Slide Master를 사용하면 모든 프레젠테이션 슬라이드에 워터마크를 적용할 수 있습니다 — 워터마크가 Slide Master에 추가되고 그곳에서 완전히 디자인된 후 개별 슬라이드의 워터마크 수정 권한에 영향을 주지 않고 모든 슬라이드에 적용됩니다.

워터마크는 일반적으로 다른 사용자가 편집할 수 없다고 간주됩니다. 워터마크(또는 워터마크의 상위 도형)가 편집되지 않도록 방지하려면 Aspose.Slides에서 도형 잠금 기능을 제공합니다. 특정 도형은 일반 슬라이드 또는 Slide Master에서 잠글 수 있습니다. 워터마크 도형이 Slide Master에서 잠기면 모든 프레젠테이션 슬라이드에서도 잠깁니다.

워터마크에 이름을 지정하면 향후 삭제하고 싶을 때 슬라이드의 도형 중에서 이름으로 해당 워터마크를 찾을 수 있습니다.

워터마크는 원하는 방식으로 디자인할 수 있지만, 일반적으로 중앙 정렬, 회전, 앞쪽 위치 등 공통적인 특징을 가집니다. 아래 예제에서는 이러한 기능을 어떻게 사용하는지 살펴보겠습니다.

## **텍스트 워터마크**

### **슬라이드에 텍스트 워터마크 추가**

PPT, PPTX 또는 ODP에서 텍스트 워터마크를 추가하려면 먼저 슬라이드에 도형을 추가하고 해당 도형에 텍스트 프레임을 추가하면 됩니다. 텍스트 프레임은 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/) 인터페이스로 표현됩니다. 이 타입은 워터마크를 유연하게 배치하기 위한 광범위한 속성을 가진 [IShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/)에서 상속되지 않았습니다. 따라서 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/) 객체는 [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/) 객체에 래핑됩니다. 도형에 워터마크 텍스트를 추가하려면 아래와 같이 [AddTextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/addtextframe/) 메서드를 사용합니다.

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="참고" %}} 
- [TextFrame 클래스 사용 방법](/slides/ko/cpp/text-formatting/)
{{% /alert %}}

### **프레젠테이션에 텍스트 워터마크 추가**

전체 프레젠테이션(즉, 모든 슬라이드에 동시에) 에 텍스트 워터마크를 추가하려면 [MasterSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/masterslide/)에 추가하면 됩니다. 나머지 로직은 단일 슬라이드에 워터마크를 추가할 때와 동일합니다 — [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/) 객체를 생성하고 [AddTextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/addtextframe/) 메서드를 사용해 워터마크를 추가합니다.

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="참고" %}} 
- [Slide Master 사용 방법](/slides/ko/cpp/slide-master/)
{{% /alert %}}

### **워터마크 도형 투명도 설정**

기본적으로 사각형 도형은 채우기 및 선 색상으로 스타일이 지정됩니다. 다음 코드 줄은 도형을 투명하게 만듭니다.

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **텍스트 워터마크의 글꼴 설정**

아래와 같이 텍스트 워터마크의 글꼴을 변경할 수 있습니다.

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **워터마크 텍스트 색상 설정**

워터마크 텍스트의 색상을 설정하려면 다음 코드를 사용합니다:

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **텍스트 워터마크 중앙 정렬**

슬라이드에서 워터마크를 중앙에 배치할 수 있으며, 이를 위해 다음과 같이 수행합니다:

```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

아래 이미지가 최종 결과를 보여줍니다.

![텍스트 워터마크](text_watermark.png)

## **이미지 워터마크**

### **프레젠테이션에 이미지 워터마크 추가**

프레젠테이션 슬라이드에 이미지 워터마크를 추가하려면 다음과 같이 하면 됩니다:

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **워터마크 편집 방지 잠금**

워터마크가 편집되지 않도록 방지하려면 도형에 대해 [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/get_autoshapelock/) 메서드를 사용합니다. 이 속성을 사용하면 도형이 선택, 크기 조정, 위치 변경, 다른 요소와 그룹화되는 것을 방지하고, 텍스트 편집을 잠그는 등 다양한 보호를 할 수 있습니다:

```cpp
// 워터마크 도형을 수정하지 못하도록 잠금
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **워터마크 앞쪽으로 가져오기**

Aspose.Slides에서는 [IShapeCollection::Reorder](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/reorder/) 메서드를 통해 도형의 Z-순서를 설정할 수 있습니다. 이를 위해 프레젠테이션 슬라이드 목록에서 해당 메서드를 호출하고 도형 참조와 순서 번호를 전달하면 됩니다. 이렇게 하면 도형을 앞쪽으로 가져오거나 뒤쪽으로 보낼 수 있습니다. 이 기능은 워터마크를 프레젠테이션 앞쪽에 배치해야 할 때 특히 유용합니다:

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **워터마크 회전 설정**

다음은 워터마크를 슬라이드 대각선에 배치하도록 회전을 조정하는 코드 예시입니다:

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **워터마크 이름 설정**

Aspose.Slides에서는 도형의 이름을 지정할 수 있습니다. 도형 이름을 사용하면 향후 해당 도형에 접근하여 수정하거나 삭제할 수 있습니다. 워터마크 도형의 이름을 설정하려면 [IAutoShape::set_Name](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/set_name/) 메서드에 할당합니다:

```cpp
watermarkShape->set_Name(u"watermark");
```

## **워터마크 제거**

워터마크 도형을 제거하려면 [IAutoShape::get_Name](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_name/) 메서드를 사용해 슬라이드 도형 중에서 찾습니다. 그런 다음 해당 워터마크 도형을 [IShapeCollection::Remove](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/remove/) 메서드에 전달합니다:

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **실시간 예제**

**Aspose.Slides 무료** [워터마크 추가](https://products.aspose.app/slides/ko/watermark) 및 [워터마크 제거](https://products.aspose.app/slides/ko/watermark/remove-watermark) 온라인 도구를 확인해 보세요.

![워터마크 추가 및 제거 온라인 도구](online_tools.png)

## **자주 묻는 질문**

**워터마크란 무엇이며 왜 사용해야 하나요?**

워터마크는 슬라이드에 적용되는 텍스트 또는 이미지 오버레이로, 지적 재산을 보호하고 브랜드 인지도를 높이며 프레젠테이션의 무단 사용을 방지하는 데 도움이 됩니다.

**프레젠테이션의 모든 슬라이드에 워터마크를 추가할 수 있나요?**

예, Aspose.Slides를 사용하면 프로그래밍 방식으로 프레젠테이션의 모든 슬라이드에 워터마크를 추가할 수 있습니다. 모든 슬라이드를 순회하면서 워터마크 설정을 각각 적용하면 됩니다.

**워터마크의 투명도를 어떻게 조정할 수 있나요?**

워터마크의 투명도는 도형의 채우기 설정([FillFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/get_fillformat/))을 수정하여 조정할 수 있습니다. 이렇게 하면 워터마크가 은은하게 표시되어 슬라이드 내용에 방해가 되지 않습니다.

**워터마크에 지원되는 이미지 형식은 무엇인가요?**

Aspose.Slides는 PNG, JPEG, GIF, BMP, SVG 등 다양한 이미지 형식을 지원합니다.

**텍스트 워터마크의 글꼴과 스타일을 사용자 지정할 수 있나요?**

예, 프레젠테이션 디자인에 맞게 원하는 글꼴, 크기 및 스타일을 선택하여 브랜드 일관성을 유지할 수 있습니다.

**워터마크의 위치나 방향을 어떻게 변경하나요?**

워터마크의 위치와 방향은 도형의 좌표, 크기 및 회전 속성을 프로그래밍 방식으로 수정하여 조정할 수 있습니다.