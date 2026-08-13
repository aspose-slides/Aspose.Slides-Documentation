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
description: "Java에서 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트와 이미지 워터마크를 관리하여 초안, 기밀 정보, 저작권 등을 표시합니다."
---
## **소개**

**워터마크**는 프레젠테이션 슬라이드에 또는 모든 슬라이드에 사용되는 텍스트 또는 이미지 스탬프입니다. 일반적으로 워터마크는 프레젠테이션이 초안임을 나타내기 위해(예: "Draft" 워터마크), 기밀 정보를 포함함을 나타내기 위해(예: "Confidential" 워터마크), 어느 회사에 속하는지 지정하기 위해(예: "Company Name" 워터마크), 발표자를 식별하기 위해 등 사용됩니다. 워터마크는 프레젠테이션을 복사해서는 안 된다는 표시를 통해 저작권 침해를 방지하는 데 도움이 됩니다. 워터마크는 PowerPoint와 OpenOffice 프레젠테이션 형식 모두에서 사용됩니다. Aspose.Slides에서는 PowerPoint PPT, PPTX 및 OpenOffice ODP 파일 형식에 워터마크를 추가할 수 있습니다.

[**Aspose.Slides**](https://products.aspose.com/slides/ko/java/)에서는 PowerPoint 또는 OpenOffice 문서에 워터마크를 만들고 디자인 및 동작을 수정할 수 있는 다양한 방법이 제공됩니다. 공통적인 점은 텍스트 워터마크를 추가하려면 [ITextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/) 인터페이스를 사용하고, 이미지 워터마크를 추가하려면 [PictureFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pictureframe/) 클래스를 사용하거나 워터마크 모양을 이미지로 채워야 한다는 것입니다. `PictureFrame`은 [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/) 인터페이스를 구현하므로 모양 객체의 모든 유연한 설정을 사용할 수 있습니다. `ITextFrame`은 모양이 아니며 설정이 제한되어 있기 때문에 [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/) 객체에 래핑됩니다.

워터마크를 적용하는 방법은 두 가지가 있습니다: 단일 슬라이드에 적용하거나 모든 프레젠테이션 슬라이드에 적용하는 방법입니다. 모든 슬라이드에 워터마크를 적용하려면 슬라이드 마스터를 사용합니다—워터마크를 슬라이드 마스터에 추가하고 거기서 완전히 디자인한 다음, 개별 슬라이드에서 워터마크 수정 권한에 영향을 주지 않고 모든 슬라이드에 적용됩니다.

워터마크는 일반적으로 다른 사용자가 편집할 수 없도록 설정됩니다. 워터마크(또는 워터마크의 상위 모양)의 편집을 방지하기 위해 Aspose.Slides는 모양 잠금 기능을 제공합니다. 특정 모양은 일반 슬라이드 또는 슬라이드 마스터에서 잠글 수 있습니다. 슬라이드 마스터에서 워터마크 모양을 잠그면 모든 프레젠테이션 슬라이드에서 잠깁니다.

워터마크에 이름을 지정하면 향후 삭제하고자 할 때 슬라이드의 모양 컬렉션에서 이름으로 찾아낼 수 있습니다.

워터마크는 원하는 형태로 디자인할 수 있지만, 일반적으로 중앙 정렬, 회전, 앞쪽 위치 등 공통적인 특징을 갖습니다. 아래 예제에서는 이러한 기능을 어떻게 사용하는지 살펴보겠습니다.

## **텍스트 워터마크**

### **슬라이드에 텍스트 워터마크 추가**

PPT, PPTX 또는 ODP에 텍스트 워터마크를 추가하려면 먼저 슬라이드에 모양을 추가한 다음 해당 모양에 텍스트 프레임을 추가합니다. 텍스트 프레임은 [ITextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/) 인터페이스로 표현됩니다. 이 유형은 위치 지정과 같은 다양한 속성을 제공하는 [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/)을 상속하지 않으므로, [ITextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/) 객체는 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/) 객체에 래핑됩니다. 모양에 워터마크 텍스트를 추가하려면 아래와 같이 [addTextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 메서드를 사용합니다.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/ko/java/text-formatting/)
{{% /alert %}}

### **프레젠테이션에 텍스트 워터마크 추가**

전체 프레젠테이션(즉, 모든 슬라이드)에 텍스트 워터마크를 추가하려면 [MasterSlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/masterslide/)에 추가합니다. 나머지 로직은 단일 슬라이드에 워터마크를 추가할 때와 동일합니다—[IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/) 객체를 만든 다음 [addTextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 메서드로 워터마크를 추가합니다.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="See also" %}} 
- [How to Use the Slide Master](/slides/ko/java/slide-master/)
{{% /alert %}}

### **워터마크 모양 투명도 설정**

기본적으로 직사각형 모양은 채우기 및 선 색상이 적용됩니다. 다음 코드는 모양을 투명하게 만듭니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **텍스트 워터마크 폰트 설정**

아래와 같이 텍스트 워터마크의 폰트를 변경할 수 있습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);

presentation.dispose();
```

### **워터마크 텍스트 색상 설정**

워터마크 텍스트 색상을 설정하려면 다음 코드를 사용합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));

presentation.dispose();
```

### **텍스트 워터마크 중앙 정렬**

슬라이드에서 워터마크를 중앙에 배치하려면 다음과 같이 하면 됩니다.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

아래 이미지는 최종 결과를 보여줍니다.

![텍스트 워터마크](text_watermark.png)

## **이미지 워터마크**

### **프레젠테이션에 이미지 워터마크 추가**

프레젠테이션 슬라이드에 이미지 워터마크를 추가하려면 다음과 같이 진행합니다.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

presentation.dispose();
```

### **워터마크 편집 방지 잠금**

워터마크를 편집하지 못하도록 하려면 모양에 대해 [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) 메서드를 사용합니다. 이 속성을 사용하면 모양을 선택, 크기 조정, 위치 이동, 다른 요소와 그룹화, 텍스트 편집 잠금 등으로부터 보호할 수 있습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// 워터마크 모양을 수정하지 못하도록 잠금
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **워터마크를 앞쪽으로 가져오기**

Aspose.Slides에서는 [IShapeCollection.reorder](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) 메서드를 통해 모양의 Z 순서를 설정할 수 있습니다. 프레젠테이션 슬라이드 목록에서 이 메서드를 호출하고 모양 참조와 순번을 전달하면 모양을 앞쪽으로 가져오거나 뒤쪽으로 보낼 수 있습니다. 이 기능은 워터마크를 프레젠테이션 앞쪽에 배치해야 할 때 특히 유용합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **워터마크 회전 설정**

다음 코드는 워터마크를 슬라이드 대각선 방향으로 배치하도록 회전을 조정하는 예시입니다.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

Dimension2D slideSize = presentation.getSlideSize().getSize();

double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);

presentation.dispose();
```

### **워터마크 이름 지정**

Aspose.Slides에서는 모양의 이름을 설정할 수 있습니다. 모양 이름을 사용하면 향후 해당 워터마크 모양에 접근하여 수정하거나 삭제할 수 있습니다. 워터마크 모양의 이름을 지정하려면 [IAutoShape.setName](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#setName-java.lang.String-) 메서드에 할당합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **워터마크 제거**

워터마크 모양을 제거하려면 [IAutoShape.getName](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getName--) 메서드로 슬라이드 모양 컬렉션에서 찾아낸 뒤, 해당 모양을 [IShapeCollection.remove](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) 메서드에 전달합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(shape);
    }
}

presentation.dispose();
```

## **자주 묻는 질문**

### 워터마크란 무엇이며 왜 사용해야 하나요?

워터마크는 슬라이드에 적용되는 텍스트 또는 이미지 오버레이로, 지적 재산을 보호하고 브랜드 인지도를 높이며 프레젠테이션의 무단 사용을 방지하는 데 도움이 됩니다.

### 프레젠테이션의 모든 슬라이드에 워터마크를 추가할 수 있나요?

예, Aspose.Slides를 사용하면 프로그램matically 모든 슬라이드에 워터마크를 추가할 수 있습니다. 모든 슬라이드를 순회하면서 개별적으로 워터마크 설정을 적용하면 됩니다.

### 워터마크의 투명도를 어떻게 조정하나요?

워터마크가 눈에 거슬리지 않도록 하기 위해서는 모양의 채우기 설정([getFillFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#getFillFormat--))을 수정하여 투명도를 조정할 수 있습니다.

### 워터마크에 사용할 수 있는 이미지 형식은 무엇인가요?

Aspose.Slides는 PNG, JPEG, GIF, BMP, SVG 등 다양한 이미지 형식을 지원합니다.

### 텍스트 워터마크의 글꼴과 스타일을 커스터마이즈할 수 있나요?

예, 프레젠테이션 디자인과 브랜드 일관성을 유지하도록 원하는 글꼴, 크기 및 스타일을 자유롭게 선택할 수 있습니다.

### 워터마크의 위치나 방향을 어떻게 바꾸나요?

모양의 좌표, 크기 및 회전 속성을 프로그래밍 방식으로 수정하여 워터마크의 위치와 방향을 조정할 수 있습니다.