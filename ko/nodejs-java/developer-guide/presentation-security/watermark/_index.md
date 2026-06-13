---
title: JavaScript에서 프레젠테이션에 워터마크 추가
linktitle: 워터마크
type: docs
weight: 40
url: /ko/nodejs-java/watermark/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js에서 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트와 이미지 워터마크를 관리하여 초안, 기밀 정보, 저작권 등을 표시합니다."
---
## **소개**

**워터마크**는 프레젠테이션에서 슬라이드에 또는 모든 슬라이드에 사용되는 텍스트 또는 이미지 스탬프입니다. 일반적으로 워터마크는 프레젠테이션이 초안임을 표시하거나(예: “Draft” 워터마크), 기밀 정보를 포함함을 나타내거나(예: “Confidential” 워터마크), 소속 회사를 지정하거나(예: “Company Name” 워터마크), 발표자를 식별하는 데 사용됩니다. 워터마크는 프레젠테이션을 복사해서는 안 된다는 표시를 함으로써 저작권 침해를 방지하는 데 도움이 됩니다. 워터마크는 PowerPoint와 OpenOffice 프레젠테이션 형식 모두에서 사용할 수 있습니다. Aspose.Slides에서는 PowerPoint PPT, PPTX 및 OpenOffice ODP 파일 형식에 워터마크를 추가할 수 있습니다.

[**Aspose.Slides**](https://products.aspose.com/slides/ko/nodejs-java/)에서는 PowerPoint 또는 OpenOffice 문서에 워터마크를 만들고 디자인 및 동작을 수정할 수 있는 다양한 방법이 제공됩니다. 공통점은 텍스트 워터마크를 추가할 때는 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/) 타입을 사용하고, 이미지 워터마크를 추가할 때는 [PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/) 클래스를 사용하거나 워터마크 형태를 이미지로 채우는 것입니다. `PictureFrame`은 [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/) 타입을 구현하므로 형태 객체의 모든 유연한 설정을 사용할 수 있습니다. `TextFrame`은 형태가 아니며 설정이 제한적이기 때문에 [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/) 객체에 래핑됩니다.

워터마크를 적용하는 방법은 두 가지가 있습니다: 단일 슬라이드에 적용하거나 전체 프레젠테이션 슬라이드에 적용하는 것입니다. 전체 슬라이드에 워터마크를 적용하려면 Slide Master를 사용합니다 — 워터마크를 Slide Master에 추가하고 완전히 디자인한 후 모든 슬라이드에 적용되며 개별 슬라이드에서 워터마크를 수정할 권한에는 영향을 주지 않습니다.

워터마크는 일반적으로 다른 사용자가 편집할 수 없도록 간주됩니다. 워터마크(또는 워터마크의 상위 형태)의 편집을 방지하려면 Aspose.Slides에서 형태 잠금 기능을 제공합니다. 특정 형태는 일반 슬라이드 또는 Slide Master에서 잠글 수 있습니다. Slide Master에서 워터마크 형태를 잠그면 모든 프레젠테이션 슬라이드에서 잠긴 상태가 됩니다.

워터마크에 이름을 지정하면 향후 삭제하고자 할 때 슬라이드의 형태 목록에서 이름으로 찾아낼 수 있습니다.

워터마크는 어떤 방식으로든 디자인할 수 있지만 일반적으로 가운데 정렬, 회전, 앞쪽 배치 등의 공통 특징이 있습니다. 아래 예제에서 이러한 기능을 어떻게 사용할지 살펴보겠습니다.

## **텍스트 워터마크**

### **슬라이드에 텍스트 워터마크 추가**
PPT, PPTX 또는 ODP에 텍스트 워터마크를 추가하려면 먼저 슬라이드에 형태를 추가한 다음 해당 형태에 텍스트 프레임을 추가합니다. 텍스트 프레임은 [**TextFrame**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrame) 타입으로 표현됩니다. 이 타입은 [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape)에서 상속되지 않으며, 워터마크를 유연하게 배치할 수 있는 다양한 속성을 제공하지 않습니다. 따라서 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrame) 객체는 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AutoShape) 객체에 래핑됩니다. 형태에 워터마크 텍스트를 추가하려면 워터마크 텍스트를 인수로 전달하여 [**addTextFrame**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) 메서드를 사용합니다:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="추가 정보" %}} 
- 사용 방법 [TextFrame](/slides/ko/nodejs-java/text-formatting/).
{{% /alert %}}

### **프레젠테이션에 텍스트 워터마크 추가**

전체 프레젠테이션(즉, 모든 슬라이드) 에 텍스트 워터마크를 추가하려면 [**MasterSlide**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/MasterSlide)에 추가합니다. 나머지 로직은 단일 슬라이드에 워터마크를 추가할 때와 동일합니다 — [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AutoShape) 객체를 만든 다음 [**addTextFrame**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) 메서드로 워터마크를 추가합니다:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="추가 정보" %}} 
- [사용 방법](/slides/ko/nodejs-java/slide-master/)[Slide Master](/slides/ko/nodejs-java/slide-master/)
{{% /alert %}}

### **워터마크 형태 투명도 설정**

기본적으로 사각형 형태는 채우기 및 선 색상이 적용됩니다. 다음 코드 줄은 형태를 투명하게 만듭니다.

```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```

### **텍스트 워터마크의 글꼴 설정**

아래와 같이 텍스트 워터마크의 글꼴을 변경할 수 있습니다.

```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```

### **워터마크 텍스트 색상 설정**

워터마크 텍스트 색상을 지정하려면 다음 코드를 사용합니다:

```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```

### **텍스트 워터마크 가운데 정렬**
슬라이드에서 워터마크를 가운데 정렬하려면 다음과 같이 할 수 있습니다:



```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

아래 이미지는 최종 결과를 보여줍니다.

![텍스트 워터마크](text_watermark.png)

## **이미지 워터마크**

### **프레젠테이션에 이미지 워터마크 추가**

전체 프레젠테이션 슬라이드에 이미지 워터마크를 추가하려면 다음과 같이 진행합니다:

```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```

### **워터마크 편집 잠금**

워터마크를 편집할 수 없도록 하려면 형태에 대해 [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AutoShape#getShapeLock--) 메서드를 사용합니다. 이 속성을 사용하면 형태를 선택, 크기 조정, 위치 이동, 다른 요소와 그룹화, 텍스트 편집 잠금 등으로부터 보호할 수 있습니다:

```javascript
// 워터마크 형태를 수정할 수 없도록 잠금
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```

### **워터마크를 앞쪽으로 이동**

Aspose.Slides에서는 [**SlideCollection.reorder**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-) 메서드를 통해 형태의 Z‑order를 설정할 수 있습니다. 프레젠테이션 슬라이드 목록에서 이 메서드를 호출하고 형태 참조와 순서 번호를 전달하면 형태를 앞쪽이나 뒤쪽으로 이동시킬 수 있습니다. 이 기능은 워터마크를 프레젠테이션 앞쪽에 배치해야 할 때 특히 유용합니다:

```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **워터마크 회전 설정**

다음 코드는 워터마크를 슬라이드 대각선 방향으로 회전하도록 조정하는 예제입니다:

```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```

### **워터마크 이름 설정**

Aspose.Slides에서는 형태에 이름을 지정할 수 있습니다. 형태 이름을 사용하면 향후 해당 형태에 접근하여 수정하거나 삭제할 수 있습니다. 워터마크 형태의 이름을 설정하려면 [**AutoShape.getName**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape#getName--) 메서드에 이름을 할당합니다:

```javascript
watermarkShape.setName("watermark");
```

### **워터마크 제거**

워터마크 형태를 제거하려면 [AutoShape.getName](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape#getName--) 메서드로 슬라이드 형태 목록에서 찾아낸 뒤, 해당 형태를 [**ShapeCollection.remove**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-) 메서드에 전달합니다:

```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **자주 묻는 질문**

**워터마크란 무엇이며 왜 사용해야 하나요?**

워터마크는 슬라이드에 적용되는 텍스트 또는 이미지 오버레이로, 지적 재산을 보호하고 브랜드 인지도를 높이며 프레젠테이션의 무단 사용을 방지하는 데 도움이 됩니다.

**프레젠테이션의 모든 슬라이드에 워터마크를 추가할 수 있나요?**

예, Aspose.Slides를 사용하면 프레젠테이션의 모든 슬라이드에 워터마크를 추가할 수 있습니다. 모든 슬라이드를 순회하면서 개별적으로 워터마크 설정을 적용하면 됩니다.

**워터마크의 투명도를 어떻게 조정하나요?**

형태의 [fill settings](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/getfillformat/)을 수정하여 워터마크 투명도를 조절할 수 있습니다. 이를 통해 워터마크가 눈에 띄지 않으면서도 슬라이드 내용은 방해받지 않도록 할 수 있습니다.

**워터마크에 사용할 수 있는 이미지 포맷은 무엇인가요?**

Aspose.Slides는 PNG, JPEG, GIF, BMP, SVG 등 다양한 이미지 포맷을 지원합니다.

**텍스트 워터마크의 글꼴과 스타일을 커스터마이즈할 수 있나요?**

예, 프레젠테이션 디자인 및 브랜드 일관성을 유지하도록 원하는 글꼴, 크기 및 스타일을 선택할 수 있습니다.

**워터마크의 위치나 방향을 어떻게 변경하나요?**

형태의 좌표, 크기 및 회전 속성을 수정하여 워터마크의 위치와 방향을 조정할 수 있습니다.