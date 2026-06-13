---
title: .NET에서 프레젠테이션에 워터마크 추가
linktitle: 워터마크
type: docs
weight: 40
url: /ko/net/watermark/
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
- 파워포인트
- 오픈문서
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: ".NET에서 PowerPoint와 OpenDocument 프레젠테이션의 텍스트 및 이미지 워터마크를 관리하여 초안, 기밀 정보, 저작권 등을 표시합니다."
---
## **소개**

**워터마크**는 슬라이드 또는 전체 프레젠테이션 슬라이드에 사용되는 텍스트 또는 이미지 스탬프입니다. 일반적으로 워터마크는 프레젠테이션이 초안임을 나타내기 위해(예: "Draft" 워터마크), 기밀 정보를 포함하고 있음을 나타내기 위해(예: "Confidential" 워터마크), 어느 회사에 속하는지를 지정하기 위해(예: "Company Name" 워터마크), 프레젠테이션 저자를 식별하기 위해 등으로 사용됩니다. 워터마크는 프레젠테이션을 복사해서는 안 된다는 표시를 통해 저작권 침해를 방지하는 데 도움이 됩니다. 워터마크는 PowerPoint와 OpenDocument 프레젠테이션 형식 모두에서 사용할 수 있습니다. Aspose.Slides에서는 PowerPoint PPT, PPTX 및 OpenDocument ODP 파일 형식에 워터마크를 추가할 수 있습니다.

[**Aspose.Slides**](https://products.aspose.com/slides/ko/net/)에서는 PowerPoint 또는 OpenDocument 문서에 워터마크를 만들고 디자인 및 동작을 수정할 수 있는 다양한 방법이 제공됩니다. 공통적인 점은 텍스트 워터마크를 추가하려면 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/) 인터페이스를 사용하고, 이미지 워터마크를 추가하려면 [PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe/) 클래스를 사용하거나 워터마크 모양을 이미지로 채운다는 것입니다. `PictureFrame`은 [IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape) 인터페이스를 구현하므로 모양 객체의 모든 유연한 설정을 사용할 수 있습니다. `ITextFrame`은 모양이 아니고 설정이 제한적이기 때문에 [IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape) 객체에 래핑됩니다.

워터마크를 적용하는 방법은 두 가지가 있습니다: 단일 슬라이드에 적용하거나 전체 프레젠테이션 슬라이드에 적용하는 것입니다. 전체 슬라이드에 워터마크를 적용하려면 슬라이드 마스터를 사용합니다 — 워터마크를 슬라이드 마스터에 추가하고 완전히 디자인한 뒤, 개별 슬라이드에서 워터마크를 수정할 수 있는 권한에 영향을 주지 않고 모든 슬라이드에 적용됩니다.

워터마크는 일반적으로 다른 사용자가 편집할 수 없도록 간주됩니다. 워터마크(또는 워터마크의 상위 모양)가 편집되지 않도록 하려면 Aspose.Slides에서 제공하는 모양 잠금 기능을 사용할 수 있습니다. 특정 모양은 일반 슬라이드 또는 슬라이드 마스터에서 잠글 수 있습니다. 슬라이드 마스터에서 워터마크 모양을 잠그면 모든 프레젠테이션 슬라이드에서 잠깁니다.

향후 워터마크를 삭제하려는 경우 슬라이드의 모양 목록에서 이름으로 찾을 수 있도록 워터마크에 이름을 지정할 수 있습니다.

워터마크는 원하는 방식으로 디자인할 수 있지만, 일반적으로 중앙 정렬, 회전, 앞쪽 배치와 같은 공통적인 특징이 있습니다. 아래 예제에서는 이러한 요소들을 어떻게 활용하는지 살펴보겠습니다.

## **텍스트 워터마크**

### **슬라이드에 텍스트 워터마크 추가**

PPT, PPTX 또는 ODP에 텍스트 워터마크를 추가하려면 먼저 슬라이드에 모양을 추가한 다음 해당 모양에 텍스트 프레임을 추가하면 됩니다. 텍스트 프레임은 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe) 인터페이스로 표현됩니다. 이 타입은 [IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/)에 상속되지 않으며, 워터마크 위치를 유연하게 지정할 수 있는 다양한 속성을 제공하지 않습니다. 따라서 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe) 객체는 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/) 객체에 래핑됩니다. 모양에 워터마크 텍스트를 추가하려면 아래와 같이 [AddTextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/methods/addtextframe) 메서드를 사용합니다.

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// 슬라이드에 워터마크를 추가합니다.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class?](/slides/ko/net/text-formatting/)
{{% /alert %}}

### **프레젠테이션에 텍스트 워터마크 추가**

전체 프레젠테이션(즉, 모든 슬라이드)에 텍스트 워터마크를 추가하려면 [MasterSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/masterslide/)에 추가합니다. 나머지 로직은 단일 슬라이드에 워터마크를 추가할 때와 동일합니다 — [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/) 객체를 만든 다음 [AddTextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/methods/addtextframe) 메서드로 워터마크를 추가합니다.

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// 마스터 슬라이드에 워터마크를 추가합니다.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master?](/slides/ko/net/slide-master/)
{{% /alert %}}

### **워터마크 모양 투명도 설정**

기본적으로 사각형 모양은 채우기 색과 테두리 색이 적용됩니다. 즉, 워터마크를 추가하면 배경이나 테두리가 실선으로 표시되어 슬라이드 내용에 방해가 될 수 있습니다. 워터마크가 은은하게 보이도록 하려면 모양을 완전히 투명하게 만들 수 있습니다.

다음 코드 라인은 채우기 색과 테두리 색을 모두 제거하여 모양을 투명하게 합니다.

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **텍스트 워터마크의 글꼴 설정**

슬라이드에 텍스트 워터마크를 적용하기 전에 전체 디자인과 조화를 이루도록 모양을 사용자 정의하는 것이 중요합니다. 글꼴 종류와 크기를 변경하여 워터마크가 가독성을 유지하면서도 미적으로 만족스럽게 만들 수 있습니다. 글꼴을 맞춤 설정하면 브랜드 아이덴티티를 강화하거나 프레젠테이션 스타일에 맞출 수 있습니다.

다음 코드 스니펫은 특정 라틴 글꼴을 선택하고 적절한 글꼴 높이를 설정하여 워터마크의 글꼴을 조정하는 방법을 보여줍니다.

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **워터마크 텍스트 색상 설정**

워터마크를 적용하기 전에 텍스트 색상이 슬라이드 내용과 잘 어우러지도록 적절히 설정해야 합니다. 빨강, 녹색, 파랑 구성 요소와 함께 색상의 투명도(alpha)를 조정하면 눈에 띄지만 방해가 되지 않는 은은한 반투명 워터마크를 만들 수 있습니다. 이 방법은 주요 프레젠테이션에 집중하면서도 콘텐츠를 보호하는 데 도움이 됩니다.

워터마크 텍스트 색상을 설정하려면 다음 코드를 사용합니다.

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **텍스트 워터마크 중앙 정렬**

텍스트 워터마크를 정확히 중앙에 배치하면 슬라이드 크기에 관계없이 대칭적으로 배치되어 프레젠테이션 전반의 미관을 크게 향상시킵니다. 이렇게 하면 슬라이드의 주요 콘텐츠를 방해하지 않으면서도 전문적인 느낌을 줍니다.

다음 코드 스니펫은 슬라이드의 중앙 위치를 계산하고 텍스트 워터마크를 해당 위치에 배치하는 방법을 보여줍니다.

```cs
SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

아래 이미지는 최종 결과를 보여줍니다.

![텍스트 워터마크](text_watermark.png)

## **이미지 워터마크**

### **프레젠테이션에 이미지 워터마크 추가**

많은 경우 이미지 워터마크는 고유한 브랜딩 요소를 제공하거나 텍스트 워터마크보다 시각적으로 더 매력적인 대안을 제시합니다. 워터마크를 추가하기 전에 이미지 파일이 준비돼 있는지 확인하십시오(예: 투명도를 위해 PNG 형식). 다음 예제는 파일 시스템에서 이미지를 로드하고 프레젠테이션에 추가한 뒤, 모양의 채우기 속성을 사용해 워터마크로 적용하는 방법을 보여줍니다.

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **워터마크 편집 방지**

워터마크를 편집되지 않도록 방지하려면 모양의 [IAutoShape.ShapeLock](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/properties/shapelock) 속성을 사용합니다. 이 속성을 통해 모양 선택, 크기 조정, 위치 변경, 다른 요소와 그룹화, 텍스트 편집 잠금 등 다양한 보호 기능을 적용할 수 있습니다.

```cs
// 워터마크 모양을 수정하지 못하도록 잠급니다.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **워터마크를 앞쪽으로 가져오기**

Aspose.Slides에서는 [IShapeCollection.Reorder](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/reorder/#reorder) 메서드를 통해 모양의 Z-순서를 설정할 수 있습니다. 프레젠테이션 슬라이드 목록에서 이 메서드를 호출하고 모양 참조와 순서 번호를 전달하면 됩니다. 이렇게 하면 모양을 앞쪽으로 가져오거나 뒤쪽으로 보낼 수 있습니다. 프레젠테이션 앞에 워터마크를 배치해야 할 때 특히 유용합니다.

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **워터마크 회전 설정**

워터마크의 회전을 조정하면 프레젠테이션의 시각적 효과와 은은함을 크게 향상시킬 수 있습니다. 예를 들어 대각선 워터마크는 덜 눈에 띄면서도 무단 사용에 대한 강력한 보호를 제공합니다. 아래 예제는 슬라이드 크기에 따라 적절한 각도를 계산하여 워터마크를 대각선으로 배치합니다. 이 동적 계산을 통해 슬라이드 크기가 달라져도 워터마크가 효과적으로 유지됩니다.

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **워터마크에 이름 지정**

Aspose.Slides에서는 모양의 이름을 설정할 수 있습니다. 모양 이름을 사용하면 향후 해당 워터마크를 찾아 수정하거나 삭제할 수 있습니다. 워터마크 모양의 이름을 설정하려면 [IAutoShape.Name](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/properties/name) 속성에 할당하십시오.

```cs
watermarkShape.Name = "watermark";
```

## **워터마크 제거**

워터마크 모양을 제거하려면 [IAutoShape.Name](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/properties/name) 속성을 사용해 슬라이드 모양 목록에서 찾은 다음, 해당 모양을 [IShapeCollection.Remove](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/remove/) 메서드에 전달합니다.

```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```

## **실시간 예제**

**Aspose.Slides 무료** [워터마크 추가](https://products.aspose.app/slides/ko/watermark) 및 [워터마크 제거](https://products.aspose.app/slides/ko/watermark/remove-watermark) 온라인 도구를 확인해 보세요.

![워터마크를 추가하고 제거하는 온라인 도구](online_tools.png)

## **FAQ**

**워터마크란 무엇이며 왜 사용해야 하나요?**

워터마크는 슬라이드에 적용되는 텍스트 또는 이미지 오버레이로, 지적 재산을 보호하고 브랜드 인지도를 높이며 프레젠테이션의 무단 사용을 방지합니다.

**프레젠테이션의 모든 슬라이드에 워터마크를 추가할 수 있나요?**

네, Aspose.Slides를 사용하면 프로그램matically 모든 슬라이드에 워터마크를 추가할 수 있습니다. 모든 슬라이드를 순회하면서 워터마크 설정을 개별적으로 적용하면 됩니다.

**워터마크의 투명도를 어떻게 조정하나요?**

모양의 채우기 설정([FillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/fillformat/))을 수정하여 워터마크의 투명도를 조정할 수 있습니다. 이를 통해 워터마크가 은은하게 표시되어 슬라이드 내용에 방해가 되지 않게 할 수 있습니다.

**워터마크에 지원되는 이미지 형식은 무엇인가요?**

Aspose.Slides는 PNG, JPEG, GIF, BMP, SVG 등 다양한 이미지 형식을 지원합니다.

**텍스트 워터마크의 글꼴과 스타일을 커스터마이즈할 수 있나요?**

네, 프레젠테이션 디자인과 브랜드 일관성을 유지하도록 원하는 글꼴, 크기, 스타일을 자유롭게 선택할 수 있습니다.

**워터마크의 위치나 방향을 어떻게 변경하나요?**

모양의 좌표, 크기 및 회전 속성을 프로그래밍 방식으로 수정하여 워터마크의 위치와 방향을 조정할 수 있습니다.