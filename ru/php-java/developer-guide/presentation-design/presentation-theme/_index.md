---
title: Управление темами презентаций в PHP
linktitle: Тема презентации
type: docs
weight: 10
url: /ru/php-java/presentation-theme/
keywords:
  - Тема PowerPoint
  - Тема презентации
  - Тема слайда
  - Установить тему
  - Изменить тему
  - Управлять темой
  - Цвет темы
  - Дополнительная палитра
  - Шрифт темы
  - Стиль темы
  - Эффект темы
  - PowerPoint
  - OpenDocument
  - презентация
  - PHP
  - Aspose.Slides
description: "Освойте темы презентаций в Aspose.Slides для PHP через Java, чтобы создавать, настраивать и конвертировать файлы PowerPoint с единым брендингом."
---

Тема презентации определяет свойства элементов дизайна. Когда вы выбираете тему презентации, вы фактически выбираете конкретный набор визуальных элементов и их свойства.

В PowerPoint тема состоит из цветов, [fonts](/slides/ru/php-java/powerpoint-fonts/), [background styles](/slides/ru/php-java/presentation-background/) и эффектов.

![theme-constituents](theme-constituents.png)

## **Change Theme Color**

Тема PowerPoint использует определённый набор цветов для различных элементов слайда. Если вам не нравятся эти цвета, вы можете изменить их, задав новые цвета для темы. Чтобы позволить вам выбрать новый цвет темы, Aspose.Slides предоставляет значения из перечисления [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/SchemeColor).

Этот PHP‑код показывает, как изменить цвет акцента для темы:
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


Вы можете определить эффективное значение получившегося цвета следующим образом:
```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```


Чтобы дополнительно продемонстрировать операцию изменения цвета, мы создаём другой элемент и фиксируем цвет акцента (из первоначальной операции) в нём. Затем меняем цвет в теме:
```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
```


Новый цвет применяется автоматически к обоим элементам.

### **Set Theme Color from an Additional Palette**

При применении преобразований яркости к основному цвету темы(1) формируются цвета из дополнительной палитры(2). Затем вы можете задавать и получать эти цвета темы.

![additional-palette-colors](additional-palette-colors.png)

**1** – Основные цвета темы  

**2** – Цвета из дополнительной палитры.

Этот PHP‑код демонстрирует операцию, при которой цвета дополнительной палитры получаются из основного цвета темы и затем используются в фигурах:
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Акцент 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # Акцент 4, светлее 80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # Акцент 4, светлее 60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # Акцент 4, светлее 40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # Акцент 4, темнее 25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # Акцент 4, темнее 50%
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


## **Change Theme Font**

Чтобы позволить вам выбирать шрифты для тем и других целей, Aspose.Slides использует специальные идентификаторы (аналогичные тем, что применяются в PowerPoint):

* **+mn‑lt** – Body Font Latin (Minor Latin Font)  
* **+mj‑lt** – Heading Font Latin (Major Latin Font)  
* **+mn‑ea** – Body Font East Asian (Minor East Asian Font)  
* **+mj‑ea** – Body Font East Asian (Major East Asian Font)

Этот PHP‑код показывает, как назначить латинский шрифт элементу темы:
```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));
```


Этот PHP‑код показывает, как изменить шрифт темы презентации:
```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
```


Шрифт во всех текстовых полях будет обновлён.

{{% alert color="primary" title="TIP" %}} 
Возможно, вам будет интересно посмотреть [PowerPoint fonts](/slides/ru/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Change Theme Background Style**

По умолчанию приложение PowerPoint предоставляет 12 предустановленных фонов, но только 3 из этих 12 сохраняются в типичной презентации.

![todo:image_alt_text](presentation-design_8.png)

Например, после сохранения презентации в приложении PowerPoint вы можете выполнить этот PHP‑код, чтобы узнать количество предустановленных фонов в презентации:
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
С помощью свойства [BackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) из класса [FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme) можно добавить или получить доступ к стилю фона в теме PowerPoint.
{{% /alert %}} 

Этот PHP‑код показывает, как задать фон для презентации:
```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```


**Руководство по индексам**: 0 — отсутствие заливки. Индексы начинаются с 1.

{{% alert color="primary" title="TIP" %}} 
Возможно, вам будет интересно посмотреть [PowerPoint Background](/slides/ru/php-java/presentation-background/).
{{% /alert %}}

## **Change Theme Effect**

Тема PowerPoint обычно содержит 3 значения для каждого массива стилей. Эти массивы объединяются в три эффекта: subtle, moderate и intense. Например, так выглядит результат применения эффектов к определённой фигуре:

![todo:image_alt_text](presentation-design_10.png)

Используя 3 свойства ([FillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getEffectStyles--)) из класса [FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme) вы можете изменять элементы темы (даже гибче, чем параметры в PowerPoint).

Этот PHP‑код показывает, как изменить эффект темы, изменяя части элементов:
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


Получившиеся изменения в цвете заливки, типе заливки, эффекте тени и т.д.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Можно ли применить тему только к отдельному слайду, не меняя мастер?**

Да. Aspose.Slides поддерживает переопределения темы на уровне слайда, поэтому вы можете применить локальную тему только к этому слайду, оставив мастер‑тему нетронутой (через [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/)).

**Какой способ является самым надёжным для переноса темы из одной презентации в другую?**

[Clone slides](/slides/ru/php-java/clone-slides/) вместе с их мастером в целевую презентацию. Это сохраняет оригинальный мастер, макеты и связанную тему, так что внешний вид остаётся согласованным.

**Как увидеть «эффективные» значения после всех наследований и переопределений?**

Используйте «эффективные» представления API [/shape-effective-properties/](/slides/ru/php-java/shape-effective-properties/) для темы/цвета/шрифта/эффекта. Они возвращают окончательные разрешённые свойства после применения мастера и всех локальных переопределений.