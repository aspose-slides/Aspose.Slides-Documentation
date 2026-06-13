---
title: PHP에서 프레젠테이션 테마 관리
linktitle: 프레젠테이션 테마
type: docs
weight: 10
url: /ko/php-java/presentation-theme/
keywords:
  - PowerPoint 테마
  - 프레젠테이션 테마
  - 슬라이드 테마
  - 테마 설정
  - 테마 변경
  - 테마 관리
  - 테마 색상
  - 추가 팔레트
  - 테마 글꼴
  - 테마 스타일
  - 테마 효과
  - PowerPoint
  - OpenDocument
  - 프레젠테이션
  - PHP
  - Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 일관된 브랜딩으로 PowerPoint 파일을 만들고, 맞춤 설정하며, 변환할 수 있도록 마스터 프레젠테이션 테마를 관리합니다."
---
## **소개**

프레젠테이션 테마는 디자인 요소의 속성을 정의합니다. 테마를 선택하면 본질적으로 특정 시각적 요소와 그 속성들의 집합을 선택하는 것입니다.

PowerPoint에서 테마는 색상, [fonts](/slides/ko/php-java/powerpoint-fonts/), [background styles](/slides/ko/php-java/presentation-background/), 그리고 효과로 구성됩니다.

![테마 구성 요소](theme-constituents.png)

## **테마 색상 변경**

PowerPoint 테마는 슬라이드의 다양한 요소에 대해 특정 색상 집합을 사용합니다. 색상이 마음에 들지 않으면 새로운 색상을 적용하여 테마 색상을 변경할 수 있습니다. 새로운 테마 색상을 선택하려면 Aspose.Slides에서 [SchemeColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SchemeColor) 열거형에 정의된 값을 제공합니다.

다음 PHP 코드는 테마의 강조 색상을 변경하는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

이렇게 하면 결과 색상의 실제 값을 확인할 수 있습니다:

```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));
```

색상 변경 작업을 더 명확히 보여주기 위해 다른 요소를 만들고 초기 작업에서 얻은 강조 색상을 할당합니다. 그런 다음 테마의 색상을 다시 변경합니다:

```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
```

새로운 색상이 두 요소 모두에 자동으로 적용됩니다.

### **추가 팔레트에서 테마 색상 설정**

주 테마 색상(1)에 밝기 변환을 적용하면 추가 팔레트(2)의 색상이 형성됩니다. 그런 뒤 해당 테마 색상을 설정하고 가져올 수 있습니다.

![추가 팔레트 색상](additional-palette-colors.png)

**1** - 주 테마 색상  

**2** - 추가 팔레트의 색상.

다음 PHP 코드는 주 테마 색상에서 추가 팔레트 색상을 얻어 도형에 적용하는 예시를 보여줍니다:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 강조 색 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # 강조 색 4, 밝게 80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # 강조 색 4, 밝게 60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # 강조 색 4, 밝게 40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # 강조 색 4, 어둡게 25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # 강조 색 4, 어둡게 50%
    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.5);
    $presentation->save($path . "example_accent4.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **`SchemeColor`를 `ColorScheme` 색상에 매핑**

[SchemeColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/schemecolor/)를 사용할 때 다음과 같은 테마 색상 값이 포함된 것을 볼 수 있습니다:

`Background1`, `Background2`, `Text1`, `Text2`.

반면 `Presentation::getMasterTheme()::getColorScheme()`은 [ColorScheme](https://reference.aspose.com/slides/ko/php-java/aspose.slides/colorscheme/)을 반환하며, 해당 색상을 다음과 같이 노출합니다:

`Dark1`, `Dark2`, `Light1`, `Light2`.

이 차이는 명명법에만 해당됩니다. 이 값들은 동일한 테마 색상 슬롯을 가리키며 매핑은 고정되어 있습니다:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background`와 `Dark`/`Light` 사이에 동적인 변환은 없습니다. 동일한 테마 색상의 서로 다른 이름일 뿐입니다.

이 명명 차이는 Microsoft Office 용어에서 비롯되었습니다. 구 버전 Office에서는 `Dark 1`, `Light 1`, `Dark 2`, `Light 2`를 사용했으며, 최신 UI에서는 동일한 슬롯을 `Text 1`, `Background 1`, `Text 2`, `Background 2`로 표시합니다.

## **테마 글꼴 변경**

테마 및 기타 목적에 사용할 글꼴을 선택하도록 Aspose.Slides는 PowerPoint에서 사용하는 특수 식별자를 제공합니다(다음과 유사):

* **+mn-lt** - 본문 글꼴 라틴어 (Minor Latin Font)
* **+mj-lt** - 제목 글꼴 라틴어 (Major Latin Font)
* **+mn-ea** - 본문 글꼴 동아시아어 (Minor East Asian Font)
* **+mj-ea** - 본문 글꼴 동아시아어 (Major East Asian Font)

다음 PHP 코드는 라틴어 글꼴을 테마 요소에 할당하는 방법을 보여줍니다:

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));
```

다음 PHP 코드는 프레젠테이션 테마 글꼴을 변경하는 방법을 보여줍니다:

```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
```

모든 텍스트 상자의 글꼴이 업데이트됩니다.

{{% alert color="primary" title="TIP" %}} 

[PowerPoint fonts](/slides/ko/php-java/powerpoint-fonts/)를 참고하세요.

{{% /alert %}}

## **테마 배경 스타일 변경**

기본적으로 PowerPoint 앱은 미리 정의된 배경 12개를 제공하지만, 일반적인 프레젠테이션에서는 그 중 3개만 저장됩니다.

![todo:image_alt_text](presentation-design_8.png)

예를 들어, PowerPoint 앱에서 프레젠테이션을 저장한 후 다음 PHP 코드를 실행하면 프레젠테이션에 포함된 미리 정의된 배경 수를 확인할 수 있습니다:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Number of background fill styles for theme is " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

[FormatScheme](https://reference.aspose.com/slides/ko/php-java/aspose.slides/FormatScheme) 클래스의 [BackgroundFillStyles](https://reference.aspose.com/slides/ko/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) 속성을 사용하면 PowerPoint 테마에서 배경 스타일을 추가하거나 접근할 수 있습니다.

{{% /alert %}} 

다음 PHP 코드는 프레젠테이션 배경을 설정하는 방법을 보여줍니다:

```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```

**인덱스 안내**: 0은 채우기 없음에 해당합니다. 인덱스는 1부터 시작합니다.

{{% alert color="primary" title="TIP" %}} 

[PowerPoint Background](/slides/ko/php-java/presentation-background/)를 확인해 보세요.

{{% /alert %}}

## **테마 효과 변경**

PowerPoint 테마는 일반적으로 각 스타일 배열에 대해 3개의 값을 포함합니다. 이러한 배열은 미묘한, 보통, 강렬이라는 3가지 효과로 결합됩니다. 예를 들어, 특정 도형에 효과를 적용했을 때의 결과는 다음과 같습니다:

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/ko/php-java/aspose.slides/FormatScheme) 클래스의 3가지 속성([FillStyles](https://reference.aspose.com/slides/ko/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/ko/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/ko/php-java/aspose.slides/FormatScheme#getEffectStyles--))을 사용하면 PowerPoint 옵션보다 더 유연하게 테마 요소를 변경할 수 있습니다.

다음 PHP 코드는 테마 효과를 요소의 일부를 변경하면서 적용하는 방법을 보여줍니다:

```php
  $pres = new Presentation("Subtle_Moderate_Intense.pptx");
  try {
    $pres->getMasterTheme()->getFormatScheme()->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->getMasterTheme()->getFormatScheme()->getEffectStyles()->get_Item(2)->getEffectFormat()->getOuterShadowEffect()->setDistance(10.0);
    $pres->save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

변경된 채우기 색상, 채우기 유형, 그림자 효과 등은 다음과 같습니다:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**단일 슬라이드에 마스터를 변경하지 않고 테마를 적용할 수 있나요?**

예. Aspose.Slides는 슬라이드 수준 테마 재정의를 지원하므로 [SlideThemeManager](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidethememanager/)를 통해 마스터 테마는 유지하면서 해당 슬라이드에 로컬 테마를 적용할 수 있습니다.

**프레젠테이션 간에 테마를 가장 안전하게 이동하는 방법은 무엇인가요?**

[Clone slides](/slides/ko/php-java/clone-slides/)를 사용하여 마스터와 함께 대상 프레젠테이션으로 복사하면 원본 마스터, 레이아웃 및 연관된 테마가 보존되어 외관이 일관됩니다.

**모든 상속 및 재정의를 적용한 후 “effective” 값을 어떻게 확인하나요?**

테마/색상/글꼴/효과에 대한 API의 ["effective" views](/slides/ko/php-java/shape-effective-properties/)를 사용하면 마스터와 로컬 재정을 모두 적용한 후 최종적으로 해결된 속성을 반환합니다.