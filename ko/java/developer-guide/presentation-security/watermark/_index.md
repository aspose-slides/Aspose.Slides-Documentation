---
title: Java에서 프레젠테이션에 워터마크 추가
linktitle: 워터마크
type: docs
weight: 40
url: /ko/java/watermark/
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
- Java
- Aspose.Slides
description: "Java에서 PowerPoint 및 OpenDocument 프레젠테이션에 텍스트와 이미지 워터마크를 관리하여 초안, 기밀 정보, 저작권 등을 표시합니다."
---
## **소개**

**워터마크**는 슬라이드나 전체 프레젠테이션 슬라이드에 사용되는 텍스트 또는 이미지 스탬프입니다. 일반적으로 워터마크는 프레젠테이션이 초안임을 표시(예: “Draft” 워터마크), 기밀 정보를 포함하고 있음을 알림(예: “Confidential” 워터마크), 소속 회사를 지정(예: “Company Name” 워터마크), 프레젠테이션 작성자를 식별 등과 같은 용도로 사용됩니다. 워터마크는 프레젠테이션을 복사하면 안 된다는 표시를 통해 저작권 침해를 방지하는 데 도움을 줍니다. 워터마크는 PowerPoint와 OpenOffice 프레젠테이션 형식 모두에서 사용할 수 있습니다. Aspose.Slides에서는 PowerPoint PPT, PPTX 및 OpenOffice ODP 파일 형식에 워터마크를 추가할 수 있습니다.

In [**Aspose.Slides**](https://products.aspose.com/slides/ko/java/), there are various ways you can create watermarks in PowerPoint or OpenOffice documents and modify their design and behavior. The common aspect is that to add text watermarks, you should use the [ITextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/) interface, and to add image watermarks, use the [PictureFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pictureframe/) class or fill a watermark shape with an image. `PictureFrame` implements the [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/) interface, allowing you to use all the flexible settings of the shape object. Since `ITextFrame` is not a shape and its settings are limited, it is wrapped into an [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/) object.

워터마크를 적용하는 방법은 두 가지입니다: 단일 슬라이드에 적용하거나 전체 프레젠테이션 슬라이드에 적용합니다. Slide Master를 사용하면 전체 프레젠테이션 슬라이드에 워터마크를 적용할 수 있습니다—워터마크는 Slide Master에 추가되고 그곳에서 완전하게 디자인된 후 개별 슬라이드의 편집 권한에 영향을 주지 않고 모든 슬라이드에 적용됩니다.

워터마크는 일반적으로 다른 사용자가 편집할 수 없도록 간주됩니다. 워터마크(또는 워터마크의 상위 도형)의 편집을 방지하기 위해 Aspose.Slides는 도형 잠금 기능을 제공합니다. 특정 도형은 일반 슬라이드 또는 Slide Master에서 잠글 수 있습니다. 워터마크 도형이 Slide Master에 잠기면 모든 프레젠테이션 슬라이드에서 잠깁니다.

워터마크에 이름을 지정하면 나중에 삭제하려 할 때 슬라이드의 도형 목록에서 이름으로 쉽게 찾을 수 있습니다.

워터마크는 원하는 방식으로 디자인할 수 있지만, 일반적으로 중앙 정렬, 회전, 전면 배치와 같은 공통 특징이 있습니다. 아래 예제에서는 이러한 기능을 어떻게 사용하는지 살펴보겠습니다.

## **텍스트 워터마크**

### **슬라이드에 텍스트 워터마크 추가**

PPT, PPTX 또는 ODP에 텍스트 워터마크를 추가하려면 먼저 슬라이드에 도형을 추가한 다음 해당 도형에 텍스트 프레임을 추가합니다. 텍스트 프레임은 [ITextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/) 인터페이스로 제공됩니다. 이 타입은 [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/)을 상속받지 않아 워터마크 위치를 유연하게 지정하는 다양한 속성을 갖고 있지 않습니다. 따라서 [ITextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/) 객체는 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/) 객체에 래핑됩니다. 도형에 워터마크 텍스트를 추가하려면 아래와 같이 [addTextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 메서드를 사용합니다.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/ko/java/text-formatting/)
{{% /alert %}}

### **프레젠테이션 전체에 텍스트 워터마크 추가**

전체 프레젠테이션(즉, 모든 슬라이드)에 텍스트 워터마크를 추가하려면 [MasterSlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/masterslide/)에 추가합니다. 나머지 로직은 단일 슬라이드에 워터마크를 추가할 때와 동일합니다—[IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/) 객체를 만든 후 [addTextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 메서드로 워터마크를 추가합니다.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master](/slides/ko/java/slide-master/)
{{% /alert %}}

### **워터마크 도형 투명도 설정**

기본적으로 사각형 도형은 채우기 및 선 색상이 지정되어 있습니다. 다음 코드 줄은 도형을 투명하게 만듭니다.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **텍스트 워터마크 폰트 설정**

아래와 같이 텍스트 워터마크의 폰트를 변경할 수 있습니다.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **워터마크 텍스트 색상 설정**

워터마크 텍스트의 색상을 설정하려면 다음 코드를 사용합니다.

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```

### **텍스트 워터마크 중앙 정렬**

워터마크를 슬라이드 중앙에 배치하려면 다음과 같이 하면 됩니다.

```java
Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

아래 이미지는 최종 결과를 보여줍니다.

![텍스트 워터마크](text_watermark.png)

## **이미지 워터마크**

### **프레젠테이션에 이미지 워터마크 추가**

프레젠테이션 슬라이드에 이미지 워터마크를 추가하려면 다음과 같이 합니다.

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **워터마크 편집 방지 잠금**

워터마크 편집을 방지해야 할 경우, 도형에 대해 [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) 메서드를 사용합니다. 이 속성을 통해 도형 선택, 크기 조정, 위치 이동, 다른 요소와 그룹화, 텍스트 편집 잠금 등 다양한 보호를 할 수 있습니다.

```java
// 워터마크 도형을 수정할 수 없게 잠금
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **워터마크 전면 배치**

Aspose.Slides에서는 [IShapeCollection.reorder](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) 메서드를 통해 도형의 Z-순서를 설정할 수 있습니다. 프레젠테이션 슬라이드 목록에서 이 메서드를 호출하고 도형 참조와 순서 번호를 전달하면 도형을 전면이나 후면으로 이동시킬 수 있습니다. 이 기능은 워터마크를 프레젠테이션 앞에 배치해야 할 때 특히 유용합니다.

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **워터마크 회전 설정**

다음 코드는 워터마크를 슬라이드 대각선 방향으로 회전시키는 예제입니다.

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **워터마크 이름 지정**

Aspose.Slides에서는 도형에 이름을 지정할 수 있습니다. 도형 이름을 사용하면 향후 해당 도형을 찾아 수정하거나 삭제할 수 있습니다. 워터마크 도형의 이름을 지정하려면 [IAutoShape.setName](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#setName-java.lang.String-) 메서드에 전달합니다.

```java
watermarkShape.setName("watermark");
```

### **워터마크 삭제**

워터마크 도형을 삭제하려면 [IAutoShape.getName](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getName--) 메서드로 슬라이드 도형 목록에서 찾은 다음, 해당 도형을 [IShapeCollection.remove](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) 메서드에 전달합니다.

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **FAQ**

**워터마크란 무엇이며 왜 사용해야 하나요?**

워터마크는 슬라이드에 적용되는 텍스트 또는 이미지 오버레이로, 지적 재산을 보호하고 브랜드 인지도를 높이며 프레젠테이션의 무단 사용을 방지하는 데 도움을 줍니다.

**프레젠테이션의 모든 슬라이드에 워터마크를 추가할 수 있나요?**

예, Aspose.Slides를 사용하면 프로그래밍 방식으로 프레젠테이션의 모든 슬라이드에 워터마크를 추가할 수 있습니다. 모든 슬라이드를 순회하면서 개별적으로 워터마크 설정을 적용하면 됩니다.

**워터마크 투명도를 어떻게 조절하나요?**

워터마크 도형의 채우기 설정([getFillFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#getFillFormat--))을 수정하여 투명도를 조절할 수 있습니다. 이를 통해 워터마크가 눈에 띄지 않으면서도 슬라이드 내용에 방해되지 않도록 할 수 있습니다.

**워터마크에 사용할 수 있는 이미지 형식은 무엇인가요?**

Aspose.Slides는 PNG, JPEG, GIF, BMP, SVG 등 다양한 이미지 형식을 지원합니다.

**텍스트 워터마크의 글꼴과 스타일을 사용자 정의할 수 있나요?**

예, 프레젠테이션 디자인과 브랜드 일관성을 유지하도록 원하는 글꼴, 크기, 스타일을 선택할 수 있습니다.

**워터마크의 위치나 방향을 어떻게 변경하나요?**

도형의 좌표, 크기 및 회전 속성을 프로그래밍 방식으로 수정하여 워터마크의 위치와 방향을 조정할 수 있습니다.