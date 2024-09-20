---
title: Презентационная тема
type: docs
weight: 10
url: /php-java/presentation-theme/
keywords: "Тема, тема PowerPoint, презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Тема презентации PowerPoint"
---

Темы презентации определяют свойства элементов дизайна. Выбирая тему презентации, вы фактически выбираете определенный набор визуальных элементов и их свойства.

В PowerPoint тема включает в себя цвета, [шрифты](/slides/php-java/powerpoint-fonts/), [стили фона](/slides/php-java/presentation-background/) и эффекты.

![theme-constituents](theme-constituents.png)

## **Изменить цвет темы**

Тема PowerPoint использует определенный набор цветов для различных элементов на слайде. Если вам не нравятся цвета, вы можете изменить их, применив новые цвета для темы. Чтобы позволить вам выбрать новый цвет темы, Aspose.Slides предоставляет значения в перечислении [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/SchemeColor).

Этот код PHP показывает, как изменить акцентный цвет для темы:

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

Вы можете определить результирующее значение цвета следующим образом:

```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Цвет [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));
```

Чтобы более наглядно продемонстрировать операцию изменения цвета, мы создаем другой элемент и присваиваем ему акцентный цвет (из начальной операции). Затем мы изменяем цвет в теме:

```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
```

Новый цвет автоматически применяется ко всем элементам.

### **Установить цвет темы из дополнительной палитры**

Когда вы применяете преобразования яркости к основному цвету темы (1), формируются цвета из дополнительной палитры (2). Затем вы можете установить и получить эти цвета темы.

![additional-palette-colors](additional-palette-colors.png)

**1** - Основные цвета темы

**2** - Цвета из дополнительной палитры.

Этот код PHP демонстрирует операцию, в которой цвета из дополнительной палитры получают из основного цвета темы, а затем используются в фигурах:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Акцент 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # Акцент 4, светлее на 80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # Акцент 4, светлее на 60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # Акцент 4, светлее на 40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # Акцент 4, темнее на 25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # Акцент 4, темнее на 50%
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

## **Изменить шрифт темы**

Чтобы позволить вам выбирать шрифты для тем и других целей, Aspose.Slides использует специальные идентификаторы (аналогичные тем, которые используются в PowerPoint):

* **+mn-lt** - Шрифт тела Латиница (второстепенный латиница)
* **+mj-lt** - Заголовочный шрифт Латиница (основной латиница)
* **+mn-ea** - Шрифт тела Восточная Азия (второстепенный восточная Азия)
* **+mj-ea** - Заголовочный шрифт Восточная Азия (основной восточная Азия)

Этот код PHP показывает, как присвоить латинский шрифт элементу темы:

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Формат текста темы");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));
```

Этот код PHP показывает, как изменить шрифт темы презентации:

```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
```

Шрифт во всех текстовых полях будет обновлен.

{{% alert color="primary" title="СОВЕТ" %}} 

Вы можете ознакомиться с [шрифтами PowerPoint](/slides/php-java/powerpoint-fonts/).

{{% /alert %}}

## **Изменить стиль фона темы**

По умолчанию приложение PowerPoint предоставляет 12 предустановленных фонов, но только 3 из этих 12 фонов сохраняются в типичной презентации.

![todo:image_alt_text](presentation-design_8.png)

Например, после того как вы сохраните презентацию в приложении PowerPoint, вы можете выполнить этот код PHP, чтобы выяснить количество предустановленных фонов в презентации:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Количество стилей заполнения фона для темы составляет " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

Используя свойство [BackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) класса [FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme), вы можете добавить или получить стиль фона в теме PowerPoint.

{{% /alert %}} 

Этот код PHP показывает, как установить фон для презентации:

```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```

**Справочник по индексам**: 0 используется для отсутствия заполнения. Индекс начинается с 1.

{{% alert color="primary" title="СОВЕТ" %}} 

Вы можете ознакомиться с [фоном PowerPoint](/slides/php-java/presentation-background/).

{{% /alert %}}

## **Изменить эффект темы**

Тема PowerPoint обычно содержит 3 значения для каждого массива стилей. Эти массивы комбинируются в 3 эффекта: тонкий, умеренный и интенсивный. Например, это результат применения эффектов к конкретной фигуре:

![todo:image_alt_text](presentation-design_10.png)

Используя 3 свойства ([FillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getEffectStyles--)) из класса [FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme), вы можете изменять элементы в теме (даже более гибко, чем варианты в PowerPoint).

Этот код PHP показывает, как изменить эффект темы, изменяя части элементов:

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

Результирующие изменения в цвете заливки, типе заливки, эффекте тени и т.д.:

![todo:image_alt_text](presentation-design_11.png)