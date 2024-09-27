---
title: Управление настройками автоматической подгонки
type: docs
weight: 30
url: /ru/php-java/manage-autofit-settings/
keywords: "Текстовое поле, Автоподгонка, Презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Настройка параметров автоматической подгонки для текстового поля в PowerPoint"
---

По умолчанию, когда вы добавляете текстовое поле, Microsoft PowerPoint использует настройку **Изменить размер фигуры, чтобы соответствовать тексту** для текстового поля — оно автоматически изменяет размер текстового поля, чтобы текст всегда помещался в него.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Когда текст в текстовом поле становится длиннее или больше, PowerPoint автоматически увеличивает текстовое поле — увеличивает его высоту — чтобы оно могло вместить больше текста.
* Когда текст в текстовом поле становится короче или меньше, PowerPoint автоматически уменьшает текстовое поле — уменьшает его высоту — чтобы освободить лишнее пространство.

В PowerPoint есть 4 важных параметра или опции, которые контролируют поведение автоматической подгонки для текстового поля:

* **Не подгонять**
* **Уменьшить текст при переполнении**
* **Изменить размер фигуры, чтобы соответствовать тексту**
* **Переносить текст в фигуре.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides для PHP через Java предоставляет аналогичные опции — некоторые свойства класса [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat), которые позволяют контролировать поведение автоматической подгонки для текстовых полей в презентациях.

## **Изменить размер фигуры, чтобы соответствовать тексту**

Если вы хотите, чтобы текст в поле всегда помещался в это поле после внесения изменений, вы должны использовать опцию **Изменить размер фигуры, чтобы соответствовать тексту**. Чтобы указать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) в значение `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Этот код на PHP показывает, как указать, что текст всегда должен помещаться в свое поле в презентации PowerPoint:

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

Если текст становится длиннее или больше, текстовое поле будет автоматически изменено (высота увеличена), чтобы гарантировать, что весь текст помещается в него. Если текст становится короче, происходит обратное.

## **Не подгонять**

Если вы хотите, чтобы текстовое поле или фигура сохраняли свои размеры независимо от изменений текста, содержащегося в них, вы должны использовать опцию **Не подгонять**. Чтобы указать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) в значение `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Этот код на PHP показывает, как указать, что текстовое поле всегда должно сохранять свои размеры в презентации PowerPoint:

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

Когда текст становится слишком длинным для своего поля, он вылезает за его пределы.

## **Уменьшить текст при переполнении**

Если текст становится слишком длинным для своего поля, с помощью опции **Уменьшить текст при переполнении** вы можете указать, что размер и расстояние текста должны быть уменьшены, чтобы он помещался в своем поле. Чтобы указать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) в значение `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Этот код на PHP показывает, как указать, что текст должен уменьшаться при переполнении в презентации PowerPoint:

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

{{% alert title="Информация" color="info" %}}

Когда используется опция **Уменьшить текст при переполнении**, настройка применяется только тогда, когда текст становится слишком длинным для своего поля.

{{% /alert %}}

## **Переносить текст**

Если вы хотите, чтобы текст в фигуре переносился внутри этой фигуры, когда текст выходит за пределы границы фигуры (только по ширине), вы должны использовать параметр **Переносить текст в фигуре**. Чтобы указать эту настройку, нужно установить свойство [WrapText](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getWrapText--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) в значение `true`.

Этот код на PHP показывает, как использовать настройку Переносить текст в презентации PowerPoint:

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

{{% alert title="Примечание" color="warning" %}} 

Если вы установите свойство `WrapText` в значение `False` для фигуры, то когда текст внутри фигуры станет длиннее ширины фигуры, текст будет продолжаться за границы фигуры по одной строке.

{{% /alert %}}