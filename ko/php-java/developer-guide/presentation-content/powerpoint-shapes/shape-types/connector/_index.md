---
title: PHP를 사용한 프레젠테이션에서 연결선 관리
linktitle: 연결선
type: docs
weight: 10
url: /ko/php-java/connector/
keywords:
- 연결선
- 연결선 유형
- 연결선 포인트
- 연결선 라인
- 연결선 각도
- 도형 연결
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "PHP 애플리케이션이 PowerPoint 슬라이드에서 선을 그리며 연결하고 자동 라우팅하도록 지원하여 직선, 팔꿈치형 및 곡선 연결선을 완벽하게 제어할 수 있습니다."
---
## **소개**

PowerPoint 연결선은 두 도형을 연결하거나 연결하는 특수한 선이며, 슬라이드 상에서 도형이 이동되거나 재배치될 때에도 도형에 부착된 상태로 유지됩니다.  

연결선은 일반적으로 *연결점*(녹색 점)에 연결되며, 연결점은 모든 도형에 기본적으로 존재합니다. 커서가 연결점에 가까이 다가가면 연결점이 표시됩니다.

*조정점*(주황색 점)은 특정 연결선에만 존재하며, 연결선의 위치와 형태를 수정하는 데 사용됩니다.

## **연결선 종류**

PowerPoint에서는 직선, 팔꿈치(각진) 및 곡선 연결선을 사용할 수 있습니다.  

Aspose.Slides는 다음과 같은 연결선을 제공합니다:

| 연결선 | 이미지 | 조정점 수 |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType::BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType::BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType::BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType::BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType::CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType::CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType::CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType::CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **연결선을 사용해 도형 연결하기**

1. [Presentation](https://apireference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
1. 인덱스를 통해 슬라이드에 대한 참조를 가져옵니다.  
1. `Shapes` 객체가 제공하는 `addAutoShape` 메서드를 사용하여 슬라이드에 두 개의 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/AutoShape) 를 추가합니다.  
1. 연결선 유형을 정의하여 `Shapes` 객체가 제공하는 `addConnector` 메서드로 연결선을 추가합니다.  
1. 연결선을 사용해 도형을 연결합니다.  
1. 가장 짧은 연결 경로를 적용하기 위해 `reroute` 메서드를 호출합니다.  
1. 프레젠테이션을 저장합니다.  

다음 PHP 코드는 두 도형(타원과 사각형) 사이에 구부러진 연결선(bent connector)을 추가하는 방법을 보여줍니다:

```php
// PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 특정 슬라이드에 대한 도형 컬렉션에 접근합니다
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # 타원 자동 도형을 추가합니다
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # 사각형 자동 도형을 추가합니다
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # 슬라이드 도형 컬렉션에 연결선 도형을 추가합니다
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # 연결선을 사용해 도형들을 연결합니다
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # 도형 사이의 자동 최단 경로를 설정하는 reroute를 호출합니다
    $connector->reroute();
    # 프레젠테이션을 저장합니다
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
`Connector.reroute` 메서드는 연결선을 다시 라우팅하여 도형 간에 가능한 가장 짧은 경로를 취하도록 강제합니다. 이 목적을 달성하기 위해 메서드는 `setStartShapeConnectionSiteIndex` 와 `setEndShapeConnectionSiteIndex` 포인트를 변경할 수 있습니다. 
{{% /alert %}} 

## **연결점 지정**

연결선이 도형의 특정 점을 사용해 두 도형을 연결하도록 하려면 다음과 같이 원하는 연결점을 지정해야 합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
1. 인덱스를 통해 슬라이드에 대한 참조를 가져옵니다.  
1. `Shapes` 객체가 제공하는 `addAutoShape` 메서드를 사용하여 슬라이드에 두 개의 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/AutoShape) 를 추가합니다.  
1. 연결선 유형을 정의하여 `Shapes` 객체가 제공하는 `addConnector` 메서드로 연결선을 추가합니다.  
1. 연결선을 사용해 도형을 연결합니다.  
1. 도형에 원하는 연결점을 설정합니다.  
1. 프레젠테이션을 저장합니다.  

다음 PHP 코드는 원하는 연결점을 지정하는 작업을 보여줍니다:

```php
  # PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 특정 슬라이드에 대한 도형 컬렉션에 접근합니다
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # 타원 자동 도형을 추가합니다
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # 사각형 자동 도형을 추가합니다
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # 슬라이드의 도형 컬렉션에 연결선 도형을 추가합니다
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # 연결선을 사용해 도형들을 연결합니다
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # 타원 도형에 원하는 연결점 인덱스를 설정합니다
    $wantedIndex = 6;
    # 원하는 인덱스가 최대 사이트 인덱스 개수보다 작은지 확인합니다
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # 타원 자동 도형에 원하는 연결점을 설정합니다
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # 프레젠테이션을 저장합니다
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **연결선 포인트 조정**

조정점을 통해 기존 연결선을 조정할 수 있습니다. 조정점이 있는 연결선만 이 방법으로 변경할 수 있습니다. 자세한 내용은 **[연결선 종류](/slides/ko/php-java/connector/#types-of-connectors)** 표를 참조하세요.

### **단순 사례**

두 도형(A와 B) 사이의 연결선이 세 번째 도형(C)을 통과하는 경우를 고려해 보겠습니다:

![connector-obstruction](connector-obstruction.png)

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setStartShapeConnectionSiteIndex(2);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

세 번째 도형을 피하거나 우회하려면 연결선의 수직선을 왼쪽으로 이동시켜 다음과 같이 조정할 수 있습니다:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);

```

### **복합 사례** 

복잡한 조정을 수행하려면 다음 사항을 고려해야 합니다:

* 연결선의 조정 가능한 포인트는 위치를 계산·결정하는 공식과 강하게 연결되어 있습니다. 따라서 포인트 위치를 변경하면 연결선 형태도 바뀔 수 있습니다.  
* 연결선의 조정점은 배열에 엄격한 순서로 정의됩니다. 조정점은 연결선 시작점에서 끝점까지 순서대로 번호가 매겨집니다.  
* 조정점 값은 연결선 형태의 너비/높이에 대한 백분율을 나타냅니다.  
  * 형태는 시작점과 끝점을 1000배한 값으로 제한됩니다.  
  * 첫 번째, 두 번째, 세 번째 포인트는 각각 너비 백분율, 높이 백분율, 다시 너비 백분율을 정의합니다.  
* 연결선 조정점 좌표를 계산할 때는 연결선의 회전과 반사를 고려해야 합니다. **주의**: **[연결선 종류](/slides/ko/php-java/connector/#types-of-connectors)** 에 표시된 모든 연결선의 회전 각도는 0입니다.

#### **사례 1**

두 텍스트 프레임 개체가 연결선을 통해 서로 연결된 경우를 살펴보겠습니다:

![connector-shape-complex](connector-shape-complex.png)

```php
  # PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 프레젠테이션에서 첫 번째 슬라이드를 가져옵니다
    $sld = $pres->getSlides()->get_Item(0);
    # 연결선을 통해 함께 연결될 도형들을 추가합니다
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("From");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("To");
    # 연결선을 추가합니다
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # 연결선의 방향을 지정합니다
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # 연결선의 색상을 지정합니다
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # 연결선 선의 두께를 지정합니다
    $connector->getLineFormat()->setWidth(3);
    # 연결선을 사용해 도형들을 연결합니다
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # 연결선의 조정점을 가져옵니다
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**조정**

연결선의 조정점 값을 각각 너비와 높이 백분율을 20%와 200% 증가시켜 변경할 수 있습니다:

```php
  # 조정점의 값을 변경합니다
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);

```

결과:

![connector-adjusted-1](connector-adjusted-1.png)

개별 부분의 좌표와 형태를 결정할 수 있는 모델을 정의하기 위해, 연결선의 `connector.getAdjustments().get_Item(0)` 포인트에 해당하는 수평 구성 요소에 맞는 도형을 생성합니다:

```php
  # 연결선의 수직 구성 요소를 그립니다
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```

결과:

![connector-adjusted-2](connector-adjusted-2.png)

#### **사례 2**

**사례 1**에서는 기본 원리를 사용해 간단한 연결선 조정 작업을 보여주었습니다. 일반 상황에서는 `connector.getRotation()`, `connector.getFrame().getFlipH()`, `connector.getFrame().getFlipV()` 로 설정된 연결선 회전 및 표시를 고려해야 합니다. 이제 그 과정을 시연합니다.

먼저 슬라이드에 새로운 텍스트 프레임 개체(**To 1**)를 추가하고(연결을 위해) 기존 개체와 연결되는 새로운(녹색) 연결선을 추가합니다:

```php
  # 새 바인딩 객체를 생성합니다
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("To 1");
  # 새 연결선을 생성합니다
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # 새로 만든 연결선을 사용해 객체들을 연결합니다
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # 연결선 조정점을 가져옵니다
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # 조정점의 값을 변경합니다
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

결과:

![connector-adjusted-3](connector-adjusted-3.png)

다음으로, 새로운 연결선의 조정점 `connector.getAdjustments().get_Item(0)` 을 통과하는 수평 구성 요소에 해당하는 도형을 생성합니다. 회전 각도 `alpha` 를 기준으로 좌표 변환 공식을 적용합니다:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

우리의 경우 객체 회전 각도는 90도이며, 연결선은 수직으로 표시되므로 해당 코드는 다음과 같습니다:

```php
  # 연결선 좌표를 저장합니다
  $x = $connector->getX();
  $y = $connector->getY();
  # 연결선이 뒤집힌 경우 좌표를 보정합니다
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # 조정점 값을 좌표에 반영합니다
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # Sin(90)=1, Cos(90)=0이므로 좌표를 변환합니다
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # 두 번째 조정점 값을 사용해 수평 구성 요소의 너비를 결정합니다
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```

결과:

![connector-adjusted-4](connector-adjusted-4.png)

우리는 단순 조정과 회전 각도가 포함된 복잡한 조정점 계산을 모두 시연했습니다. 습득한 지식을 활용해 `GraphicsPath` 객체를 얻거나 특정 슬라이드 좌표에 기반해 연결선 조정점 값을 설정하는 모델(또는 코드를) 직접 개발할 수 있습니다.

## **연결선 각도 찾기**

1. 클래스의 인스턴스를 생성합니다.  
1. 인덱스를 통해 슬라이드에 대한 참조를 가져옵니다.  
1. 연결선 모양에 접근합니다.  
1. 선의 너비·높이와 형태 프레임의 높이·너비를 사용해 각도를 계산합니다.  

다음 PHP 코드는 연결선 모양의 각도를 계산하는 작업을 보여줍니다:

```php
  $pres = new Presentation("ConnectorLineAngle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($slide->getShapes()->size()) ; $i++) {
      $dir = 0.0;
      $shape = $slide->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $ashp = $shape;
        if ($ashp->getShapeType() == ShapeType::Line) {
          $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, $ashp->getFrame()->getFlipV() > 0);
        }
      } else if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
        $ashp = $shape;
        $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, java_values($ashp->getFrame()->getFlipV()) > 0);
      }
      echo($dir);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**특정 도형에 연결선을 “붙일 수” 있는지 어떻게 확인합니까?**  

도형이 [연결 사이트](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getconnectionsitecount/) 를 노출하는지 확인하십시오. 연결 사이트가 없거나 개수가 0이면 붙이기 기능이 제공되지 않으며, 이 경우 자유 끝점을 사용해 수동으로 위치시켜야 합니다. 연결 전 사이트 개수를 확인하는 것이 바람직합니다.

**연결된 도형 중 하나를 삭제하면 연결선은 어떻게 됩니까?**  

양쪽 끝이 분리됩니다; 연결선은 자유 시작/끝을 가진 일반 선으로 슬라이드에 남습니다. 이를 삭제하거나 연결을 재지정하고 필요에 따라 [reroute](https://reference.aspose.com/slides/ko/php-java/aspose.slides/connector/reroute/) 할 수 있습니다.

**슬라이드를 다른 프레젠테이션에 복사할 때 연결선 바인딩이 유지됩니까?**  

일반적으로 대상 도형도 함께 복사되면 유지됩니다. 연결된 도형 없이 슬라이드만 다른 파일에 삽입하면 양쪽 끝이 자유롭게 변하고 다시 연결해야 합니다.