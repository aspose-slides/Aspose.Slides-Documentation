---
title: PHP에서 AutoFit으로 프레젠테이션을 향상시키세요
linktitle: AutoFit 설정
type: docs
weight: 30
url: /ko/php-java/manage-autofit-settings/
keywords:
- 텍스트 상자
- AutoFit
- 자동 맞춤 안 함
- 텍스트 맞춤
- 텍스트 축소
- 텍스트 자동 줄바꿈
- 도형 크기 조정
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP에서 AutoFit 설정을 관리하여 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트 표시를 최적화하고 콘텐츠 가독성을 향상시킵니다."
---
## **소개**

기본적으로 텍스트 상자를 추가하면 Microsoft PowerPoint는 텍스트 상자에 대해 **Resize shape to fix text** 설정을 사용합니다—텍스트가 항상 상자에 맞도록 자동으로 텍스트 상자의 크기를 조정합니다. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* 텍스트 상자의 텍스트가 길어지거나 커지면 PowerPoint는 텍스트 상자를 자동으로 확대하여—높이를 늘려—더 많은 텍스트를 담을 수 있게 합니다. 
* 텍스트 상자의 텍스트가 짧아지거나 작아지면 PowerPoint는 텍스트 상자를 자동으로 축소하여—높이를 감소시켜—불필요한 공간을 없앱니다. 

PowerPoint에서는 텍스트 상자의 자동 맞춤 동작을 제어하는 4가지 중요한 매개변수 또는 옵션이 있습니다: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for PHP via Java는 유사한 옵션을 제공하며—[TextFrameFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/TextFrameFormat) 클래스의 일부 속성을 통해 프레젠테이션의 텍스트 상자에 대한 자동 맞춤 동작을 제어할 수 있습니다.

## **텍스트에 맞게 도형 크기 조정**

텍스트가 변경된 후에도 항상 상자에 맞도록 하려면 **Resize shape to fix text** 옵션을 사용해야 합니다. 이 설정을 지정하려면 [AutofitType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/TextFrameFormat#getAutofitType--) 속성을 `Shape` 로 설정합니다.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

다음 PHP 코드는 PowerPoint 프레젠테이션에서 텍스트가 항상 상자에 맞도록 지정하는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Shape);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

텍스트가 길어지거나 커지면 텍스트 상자가 자동으로 크기가 조정되어(높이가 증가) 모든 텍스트가 들어가도록 합니다. 텍스트가 짧아지면 그 반대가 발생합니다.

## **자동 맞춤 사용 안 함**

텍스트가 변경되더라도 텍스트 상자나 도형이 크기를 유지하도록 하려면 **Do not Autofit** 옵션을 사용해야 합니다. 이 설정을 지정하려면 [AutofitType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/TextFrameFormat#getAutofitType--) 속성을 `None` 으로 설정합니다.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

다음 PHP 코드는 PowerPoint 프레젠테이션에서 텍스트 상자가 항상 원래 크기를 유지하도록 지정하는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::None);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

텍스트가 상자에 비해 너무 길어지면 텍스트가 밖으로 넘칩니다.

## **오버플로 시 텍스트 축소**

텍스트가 상자에 비해 너무 길어지면 **Shrink text on overflow** 옵션을 사용하여 텍스트의 크기와 간격을 줄여 상자에 맞추도록 지정할 수 있습니다. 이 설정을 지정하려면 [AutofitType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/TextFrameFormat#getAutofitType--) 속성을 `Normal` 로 설정합니다.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

다음 PHP 코드는 PowerPoint 프레젠테이션에서 텍스트가 오버플로 시 축소되도록 지정하는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Normal);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}
**Shrink text on overflow** 옵션을 사용하면 텍스트가 상자에 비해 너무 길어질 때만 설정이 적용됩니다. 
{{% /alert %}}

## **텍스트 자동 줄바꿈**

텍스트가 도형의 경계(너비) 너머로 넘어갈 경우 도형 내부에서 줄바꿈되도록 하려면 **Wrap text in shape** 매개변수를 사용해야 합니다. 이 설정을 지정하려면 [WrapText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/TextFrameFormat#getWrapText--) 속성을 `true` 로 설정합니다.

다음 PHP 코드는 PowerPoint 프레젠테이션에서 텍스트 자동 줄바꿈 설정을 사용하는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setWrapText(NullableBool::True);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
`WrapText` 속성을 `False` 로 설정하면, 도형 내부의 텍스트가 도형 너비보다 길어질 때 텍스트가 한 줄로 도형 경계 밖으로 확장됩니다. 
{{% /alert %}}

## **FAQ**

**텍스트 프레임의 내부 여백이 AutoFit에 영향을 줍니까?**

예. 패딩(내부 여백)은 텍스트가 사용할 수 있는 영역을 감소시키므로 AutoFit이 더 일찍 작동합니다—글꼴을 축소하거나 도형 크기를 더 빨리 조정합니다. AutoFit을 조정하기 전에 여백을 확인하고 조정하십시오.

**AutoFit은 수동 및 소프트 라인 브레이크와 어떻게 상호 작용합니까?**

강제 줄 바꿈은 그대로 유지되며, AutoFit은 그 주변의 글꼴 크기와 간격을 조정합니다. 불필요한 줄 바꿈을 제거하면 AutoFit이 텍스트를 축소해야 하는 정도를 줄일 수 있습니다.

**테마 글꼴을 변경하거나 글꼴 대체를 트리거하면 AutoFit 결과에 영향을 줍니까?**

예. 서로 다른 글리프 메트릭을 가진 글꼴로 대체하면 텍스트의 너비/높이가 변하고, 최종 글꼴 크기와 줄 바꿈이 달라질 수 있습니다. 글꼴을 변경하거나 대체한 후에는 슬라이드를 다시 확인하십시오.