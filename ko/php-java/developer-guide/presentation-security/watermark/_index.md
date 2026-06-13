---
title: PHP에서 프레젠테이션에 워터마크 추가
linktitle: 워터마크
type: docs
weight: 40
url: /ko/php-java/watermark/
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
- PHP
- Aspose.Slides
description: "PHP에서 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트와 이미지 워터마크를 관리하여 초안, 기밀 정보, 저작권 등을 표시합니다."
---
## **소개**

**워터마크**는 슬라이드 혹은 전체 프레젠테이션 슬라이드에 사용되는 텍스트 또는 이미지 스탬프입니다. 일반적으로 워터마크는 프레젠테이션이 초안임을 나타내는(예: "Draft" 워터마크), 기밀 정보를 포함하고 있음을 표시하는(예: "Confidential" 워터마크), 어느 회사에 속하는지를 지정하는(예: "Company Name" 워터마크), 프레젠테이션 저자를 식별하는 등의 용도로 사용됩니다. 워터마크는 프레젠테이션을 복사하면 안 된다는 표시를 함으로써 저작권 침해를 방지하는 데 도움이 됩니다. 워터마크는 PowerPoint와 OpenOffice 프레젠테이션 형식 모두에서 사용할 수 있으며, Aspose.Slides에서는 PowerPoint PPT, PPTX 및 OpenOffice ODP 파일 형식에 워터마크를 추가할 수 있습니다.

[**Aspose.Slides**](https://products.aspose.com/slides/ko/php-java/)에서는 PowerPoint 또는 OpenOffice 문서에 워터마크를 만들고 디자인 및 동작을 수정하는 다양한 방법을 제공합니다. 공통점은 텍스트 워터마크를 추가하려면 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/) 클래스를 사용하고, 이미지 워터마크를 추가하려면 [PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/) 클래스를 사용하거나 워터마크 도형을 이미지로 채우는 것입니다. `PictureFrame`은 [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/) 클래스를 구현하므로 도형 객체의 모든 유연한 설정을 사용할 수 있습니다. `ITextFrame`은 도형이 아니고 설정이 제한적이기 때문에 [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/) 객체에 래핑됩니다.

워터마크를 적용하는 방법은 두 가지가 있습니다: 단일 슬라이드에 적용하거나 전체 프레젠테이션 슬라이드에 적용합니다. 전체 슬라이드에 워터마크를 적용하려면 슬라이드 마스터를 사용합니다 — 워터마크를 슬라이드 마스터에 추가하고 완전히 디자인한 뒤 개별 슬라이드의 편집 권한에 영향을 주지 않고 모든 슬라이드에 적용됩니다.

워터마크는 일반적으로 다른 사용자가 편집할 수 없도록 설정됩니다. 워터마크(또는 워터마크의 상위 도형)가 편집되지 않도록 하려면 Aspose.Slides에서 도형 잠금 기능을 제공합니다. 특정 도형은 일반 슬라이드 또는 슬라이드 마스터에서 잠글 수 있습니다. 슬라이드 마스터에서 워터마크 도형을 잠그면 전체 프레젠테이션 슬라이드에서 잠긴 상태가 됩니다.

워터마크에 이름을 지정하면 나중에 삭제하고자 할 때 슬라이드의 도형 목록에서 이름으로 찾을 수 있습니다.

워터마크는 원하는 대로 디자인할 수 있지만, 일반적으로 가운데 정렬, 회전, 앞쪽 배치와 같은 공통 특징을 갖습니다. 아래 예제에서는 이러한 특징들을 어떻게 활용하는지 살펴보겠습니다.

## **텍스트 워터마크**

### **슬라이드에 텍스트 워터마크 추가**

PPT, PPTX 또는 ODP에 텍스트 워터마크를 추가하려면 먼저 슬라이드에 도형을 추가한 다음 해당 도형에 텍스트 프레임을 추가합니다. 텍스트 프레임은 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/) 클래스로 표현됩니다. 이 유형은 위치 지정과 같은 유연한 속성을 많이 제공하는 [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/)을 상속하지 않으므로, [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/) 객체에 래핑됩니다. 도형에 워터마크 텍스트를 추가하려면 아래와 같이 [addTextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/#addTextFrame) 메서드를 사용합니다.

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="참고" %}} 
- [텍스트 프레임 클래스 사용 방법](/slides/ko/php-java/text-formatting/)
{{% /alert %}}

### **프레젠테이션에 텍스트 워터마크 추가**

전체 프레젠테이션(즉, 모든 슬라이드)에 텍스트 워터마크를 추가하려면 [MasterSlide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterslide/)에 추가합니다. 나머지 로직은 단일 슬라이드에 워터마크를 추가할 때와 동일합니다 — [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/) 객체를 만든 뒤 [addTextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/#addTextFrame) 메서드로 워터마크를 추가합니다.

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="참고" %}} 
- [슬라이드 마스터 사용 방법](/slides/ko/php-java/slide-master/)
{{% /alert %}}

### **워터마크 도형 투명도 설정**

기본적으로 사각형 도형은 채우기 및 선 색으로 스타일이 지정됩니다. 다음 코드 줄은 도형을 투명하게 만듭니다.

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **텍스트 워터마크의 글꼴 설정**

아래와 같이 텍스트 워터마크의 글꼴을 변경할 수 있습니다.

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **워터마크 텍스트 색상 설정**

워터마크 텍스트의 색상을 설정하려면 다음 코드를 사용합니다.

```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```

### **텍스트 워터마크 중앙 정렬**

슬라이드 중앙에 워터마크를 배치하려면 다음과 같이 하면 됩니다.

```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```

아래 이미지는 최종 결과를 보여줍니다.

![텍스트 워터마크](text_watermark.png)

## **이미지 워터마크**

### **프레젠테이션에 이미지 워터마크 추가**

프레젠테이션 슬라이드에 이미지 워터마크를 추가하려면 다음과 같이 수행합니다.

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

### **워터마크 편집 잠금**

워터마크 편집을 방지해야 할 경우 도형에 대해 [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/#getAutoShapeLock) 메서드를 사용합니다. 이 속성을 통해 도형 선택, 크기 조정, 재배치, 다른 요소와 그룹화, 텍스트 편집 잠금 등 다양한 보호를 설정할 수 있습니다.

```php
// 워터마크 도형 수정 방지
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

### **워터마크를 앞쪽으로 가져오기**

Aspose.Slides에서는 [ShapeCollection.reorder](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/#reorder) 메서드를 통해 도형의 Z-순서를 설정할 수 있습니다. 프레젠테이션 슬라이드 목록에서 이 메서드를 호출하고 도형 참조와 순서 번호를 전달하면 도형을 앞쪽이나 뒤쪽으로 이동시킬 수 있습니다. 이 기능은 워터마크를 프레젠테이션 앞쪽에 배치해야 할 때 특히 유용합니다.

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

### **워터마크 회전 설정**

다음 코드 예제는 워터마크를 슬라이드 대각선에 배치하도록 회전시키는 방법을 보여줍니다.

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

### **워터마크 이름 지정**

Aspose.Slides에서는 도형 이름을 설정할 수 있습니다. 도형 이름을 사용하면 이후에 해당 워터마크를 수정하거나 삭제할 때 이름으로 접근할 수 있습니다. 워터마크 도형의 이름을 지정하려면 [AutoShape.setName](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#setName) 메서드에 할당합니다.

```php
$watermarkShape->setName("watermark");
```

### **워터마크 제거**

워터마크 도형을 제거하려면 [AutoShape.getName](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getName) 메서드로 슬라이드 도형 중 이름을 찾은 뒤, 해당 도형을 [ShapeCollection.remove](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/#remove) 메서드에 전달합니다.

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **FAQ**

**워터마크가 무엇이며 왜 사용해야 하나요?**

워터마크는 슬라이드에 적용되는 텍스트 또는 이미지 오버레이로, 지적 재산을 보호하고 브랜드 인지도를 높이며 프레젠테이션의 무단 사용을 방지하는 데 도움을 줍니다.

**프레젠테이션의 모든 슬라이드에 워터마크를 추가할 수 있나요?**

예, Aspose.Slides를 사용하면 프로그래밍으로 프레젠테이션의 모든 슬라이드에 워터마크를 추가할 수 있습니다. 모든 슬라이드를 순회하면서 개별적으로 워터마크 설정을 적용하면 됩니다.

**워터마크의 투명도를 어떻게 조정하나요?**

도형의 채우기 설정([getFillFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getfillformat/))을 변경하여 워터마크의 투명도를 조정할 수 있습니다. 이렇게 하면 워터마크가 은은하게 표시되어 슬라이드 내용에 방해가 되지 않게 할 수 있습니다.

**워터마크에 사용할 수 있는 이미지 포맷은 무엇인가요?**

Aspose.Slides는 PNG, JPEG, GIF, BMP, SVG 등 다양한 이미지 포맷을 지원합니다.

**텍스트 워터마크의 글꼴과 스타일을 맞춤 설정할 수 있나요?**

예, 프레젠테이션 디자인과 브랜드 일관성을 유지하도록 원하는 글꼴, 크기 및 스타일을 자유롭게 선택할 수 있습니다.

**워터마크의 위치나 방향을 어떻게 바꾸나요?**

도형의 좌표, 크기 및 회전 속성을 프로그래밍으로 수정하여 워터마크의 위치와 방향을 조정할 수 있습니다.