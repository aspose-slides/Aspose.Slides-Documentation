---
title: ".NET에서 프레젠테이션에 워터마크 추가"
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
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: ".NET에서 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트와 이미지 워터마크를 관리하여 초안, 기밀 정보, 저작권 등 다양한 목적을 표시합니다."
---
## **Introduction**

**워터마크**는 프레젠테이션 슬라이드 또는 전체 슬라이드에 사용되는 텍스트 또는 이미지 스탬프입니다. 일반적으로 워터마크는 프레젠테이션이 초안임을 표시하거나(예: “Draft” 워터마크), 기밀 정보를 포함하고 있음을 표시하거나(예: “Confidential” 워터마크), 어느 회사에 속하는지 지정하거나(예: “Company Name” 워터마크), 발표자를 식별하는 등 다양한 용도로 사용됩니다. 워터마크는 프레젠테이션이 복사되지 않아야 함을 나타내어 저작권 침해를 방지하는 데 도움을 줍니다. 워터마크는 PowerPoint와 OpenDocument 프레젠테이션 형식 모두에서 사용할 수 있습니다. Aspose.Slides에서는 PowerPoint PPT, PPTX 및 OpenDocument ODP 파일 형식에 워터마크를 추가할 수 있습니다.

[**Aspose.Slides**](https://products.aspose.com/slides/ko/net/)에서는 PowerPoint 또는 OpenDocument 문서에 워터마크를 만들고 디자인과 동작을 수정할 수 있는 다양한 방법이 제공됩니다. 공통점은 텍스트 워터마크를 추가할 때는 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/) 인터페이스를 사용하고, 이미지 워터마크를 추가할 때는 [PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/pictureframe/) 클래스를 사용하거나 워터마크 도형을 이미지로 채우는 것입니다. `PictureFrame`은 [IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape) 인터페이스를 구현하므로 도형 객체의 모든 유연한 설정을 사용할 수 있습니다. `ITextFrame`은 도형이 아니며 설정이 제한적이므로 [IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape) 객체로 래핑됩니다.

워터마크를 적용하는 방법은 두 가지가 있습니다: 단일 슬라이드에 적용하거나 전체 프레젠테이션 슬라이드에 적용합니다. 전체 슬라이드에 워터마크를 적용하려면 슬라이드 마스터를 사용합니다 — 워터마크는 슬라이드 마스터에 추가되어 완전히 디자인된 후 모든 슬라이드에 적용되며 개별 슬라이드에서 워터마크를 수정할 수 있는 권한에 영향을 주지 않습니다.

워터마크는 일반적으로 다른 사용자가 편집할 수 없도록 간주됩니다. 워터마크(또는 워터마크의 상위 도형)가 편집되지 않도록 하려면 Aspose.Slides에서 제공하는 도형 잠금 기능을 사용합니다. 특정 도형은 일반 슬라이드 또는 슬라이드 마스터에서 잠글 수 있습니다. 슬라이드 마스터에서 워터마크 도형을 잠그면 모든 프레젠테이션 슬라이드에서 해당 도형이 잠깁니다.

워터마크에 이름을 지정하면 향후 삭제하고자 할 때 슬라이드의 도형 목록에서 이름으로 찾을 수 있습니다.

워터마크는 원하는 방식으로 디자인할 수 있지만 일반적으로 중앙 정렬, 회전, 앞쪽 배치와 같은 공통 특징을 가집니다. 아래 예제에서는 이러한 요소들을 어떻게 사용하는지 살펴보겠습니다.

## **Text Watermark**

### **슬라이드에 텍스트 워터마크 추가**

PPT, PPTX 또는 ODP에 텍스트 워터마크를 추가하려면 먼저 슬라이드에 도형을 추가한 다음 해당 도형에 텍스트 프레임을 추가합니다. 텍스트 프레임은 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe) 인터페이스로 표현됩니다. 이 타입은 [IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/)을 상속하지 않으며, 워터마크 위치를 유연하게 지정할 수 있는 다양한 속성을 제공하지 않습니다. 따라서 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe) 객체는 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/) 객체에 래핑됩니다. 도형에 워터마크 텍스트를 추가하려면 아래와 같이 [AddTextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/methods/addtextframe) 메서드를 사용합니다.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// 슬라이드에 워터마크를 추가합니다.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="또 보기" %}} 
- [TextFrame 클래스 사용 방법](/slides/ko/net/text-formatting/)
{{% /alert %}}

### **프레젠테이션에 텍스트 워터마크 추가**

전체 프레젠테이션(즉, 모든 슬라이드)에 텍스트 워터마크를 추가하려면 [MasterSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/masterslide/)에 추가합니다. 나머지 로직은 단일 슬라이드에 워터마크를 추가할 때와 동일합니다 — [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/) 객체를 생성한 다음 [AddTextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/methods/addtextframe) 메서드로 워터마크를 추가합니다.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// 마스터 슬라이드에 워터마크를 추가합니다.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="또 보기" %}} 
- [슬라이드 마스터 사용 방법](/slides/ko/net/slide-master/)
{{% /alert %}}

### **워터마크 도형 투명도 설정**

기본적으로 사각형 도형은 채우기 색과 선 색이 적용됩니다. 따라서 워터마크를 추가하면 배경이나 테두리가 실색으로 나타나 슬라이드 내용에 방해가 될 수 있습니다. 워터마크가 미묘하게 보이고 프레젠테이션의 시각 디자인을 방해하지 않도록 도형을 완전히 투명하게 만들 수 있습니다.

다음 코드 라인은 채우기 색과 테두리 색을 모두 제거하여 도형을 투명하게 만듭니다.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **텍스트 워터마크의 글꼴 설정**

텍스트 워터마크를 슬라이드에 적용하기 전에 전반적인 디자인과 조화를 이루도록 외관을 맞추는 것이 중요합니다. 글꼴 종류와 크기를 변경하여 워터마크가 읽기 쉽고 미관을 해치지 않도록 할 수 있습니다. 글꼴을 커스터마이즈하면 브랜드 아이덴티티를 강화하거나 프레젠테이션 스타일에 맞출 수 있습니다.

아래 코드 스니펫은 특정 라틴 글꼴을 선택하고 적절한 글꼴 높이를 설정하여 워터마크의 글꼴을 조정하는 방법을 보여줍니다.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **워터마크 텍스트 색상 설정**

워터마크를 적용하기 전에 텍스트 색상이 슬라이드 내용과 잘 어우러지면서도 과하지 않도록 설정해야 합니다. 색상 투명도(알파)와 빨강, 초록, 파랑 구성 요소를 조정하면 미묘하면서도 반투명한 워터마크를 만들 수 있습니다. 이렇게 하면 주요 프레젠테이션에 집중하면서도 콘텐츠를 보호할 수 있습니다.

워터마크 텍스트 색상을 설정하려면 다음 코드를 사용합니다.

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **텍스트 워터마크 중앙 정렬**

텍스트 워터마크를 정확히 중앙에 배치하면 슬라이드 크기에 관계없이 워터마크가 대칭적으로 위치해 전체 미관을 크게 향상시킬 수 있습니다. 이 방법은 슬라이드에 전문적인 느낌을 주고 워터마크가 주요 콘텐츠와 겹치지 않도록 합니다.

아래 코드 스니펫은 슬라이드 중심 위치를 계산하고 텍스트 워터마크를 해당 위치에 배치하는 방법을 보여줍니다.

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

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

## **Image Watermark**

### **프레젠테이션에 이미지 워터마크 추가**

많은 경우 이미지 워터마크는 고유한 브랜딩 요소를 제공하거나 텍스트 워터마크보다 시각적으로 더 매력적인 대안을 제공합니다. 워터마크를 추가하기 전에 이미지 파일이 준비되어 있는지 확인하세요(예: 투명도를 지원하는 PNG). 다음 예제는 파일 시스템에서 이미지를 로드하고 프레젠테이션에 추가한 뒤 도형의 채우기 속성을 사용해 워터마크로 적용하는 과정을 보여줍니다.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **워터마크 편집 방지**

워터마크를 편집하지 못하도록 하려면 도형의 [IAutoShape.ShapeLock](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/properties/shapelock) 속성을 사용합니다. 이 속성을 통해 도형 선택, 크기 조정, 위치 변경, 다른 요소와 그룹화, 텍스트 편집 잠금 등 다양한 동작을 방지할 수 있습니다.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// 워터마크 도형을 수정하지 못하도록 잠급니다.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **워터마크를 앞쪽으로 이동**

Aspose.Slides에서는 [IShapeCollection.Reorder](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/reorder/#reorder) 메서드를 통해 도형의 Z-순서를 설정할 수 있습니다. 프레젠테이션 슬라이드 목록에서 이 메서드를 호출하고 도형 참조와 순서 번호를 전달하면 도형을 앞쪽으로 올리거나 뒤쪽으로 보낼 수 있습니다. 이 기능은 워터마크를 프레젠테이션 앞쪽에 배치해야 할 때 특히 유용합니다.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **워터마크 회전 설정**

워터마크 회전을 조정하면 프레젠테이션의 시각적 임팩트와 은근함을 크게 향상시킬 수 있습니다. 예를 들어 대각선 워터마크는 덜 눈에 띄면서도 무단 사용으로부터 강력한 보호를 제공합니다. 다음 예제는 슬라이드 크기에 따라 적절한 각도를 계산해 워터마크를 대각선으로 배치하는 방법을 보여줍니다. 이 동적 계산을 통해 슬라이드 크기가 달라져도 워터마크가 효과적으로 유지됩니다.

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **워터마크 이름 지정**

Aspose.Slides에서는 도형의 이름을 설정할 수 있습니다. 도형 이름을 사용하면 향후 해당 워터마크 도형을 찾아 수정하거나 삭제할 수 있습니다. 워터마크 도형의 이름을 지정하려면 [IAutoShape.Name](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/properties/name) 속성에 값을 할당합니다.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **워터마크 제거**

워터마크 도형을 제거하려면 [IAutoShape.Name](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/properties/name) 속성을 사용해 슬라이드 도형 목록에서 찾은 다음, 해당 도형을 [IShapeCollection.Remove](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/remove/) 메서드에 전달합니다.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **실시간 예제**

무료 Aspose.Slides 온라인 도구인 **Add Watermark** 및 **Remove Watermark** 를 확인해 보세요.

![워터마크 추가 및 제거 온라인 도구](online_tools.png)

## **FAQ**

### 워터마크란 무엇이며 왜 사용해야 하나요?

워터마크는 슬라이드에 적용되는 텍스트 또는 이미지 오버레이로, 지적 재산을 보호하고 브랜드 인지도를 높이며 프레젠테이션의 무단 사용을 방지합니다.

### 프레젠테이션의 모든 슬라이드에 워터마크를 추가할 수 있나요?

예, Aspose.Slides를 사용하면 프로그래밍 방식으로 프레젠테이션의 모든 슬라이드에 워터마크를 추가할 수 있습니다. 모든 슬라이드를 순회하면서 개별적으로 워터마크 설정을 적용하면 됩니다.

### 워터마크의 투명도를 어떻게 조정하나요?

도형의 채우기 설정([FillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/fillformat/))을 수정하여 워터마크의 투명도를 조정할 수 있습니다. 이를 통해 워터마크가 미묘하게 표시되어 슬라이드 내용에 방해되지 않도록 할 수 있습니다.

### 워터마크에 사용할 수 있는 이미지 형식은 무엇인가요?

Aspose.Slides는 PNG, JPEG, GIF, BMP, SVG 등 다양한 이미지 형식을 지원합니다.

### 텍스트 워터마크의 글꼴과 스타일을 커스터마이즈할 수 있나요?

예, 프레젠테이션 디자인과 브랜드 일관성을 유지하도록 원하는 글꼴, 크기 및 스타일을 선택할 수 있습니다.

### 워터마크의 위치나 방향을 어떻게 변경하나요?

도형의 좌표, 크기 및 회전 속성을 프로그래밍 방식으로 수정하여 워터마크의 위치와 방향을 조정할 수 있습니다.