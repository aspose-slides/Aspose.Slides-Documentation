---
title: Замена шрифтов - Java API PowerPoint
linktitle: Замена шрифтов
type: docs
weight: 70
url: /php-java/font-substitution/
keywords: "Шрифт, заменяющий шрифт, презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Замена шрифта в PowerPoint"
---

Aspose.Slides позволяет устанавливать правила для шрифтов, которые определяют, что должно быть сделано в определенных условиях (например, когда шрифт недоступен) следующим образом:

1. Загрузите соответствующую презентацию.
2. Загрузите шрифт, который будет заменен.
3. Загрузите новый шрифт.
4. Добавьте правило для замены.
5. Добавьте правило в коллекцию правил замены шрифтов презентации.
6. Сгенерируйте изображение слайда, чтобы наблюдать эффект.

Этот код PHP демонстрирует процесс замены шрифтов:

```php
  # Загружает презентацию
  $pres = new Presentation("Fonts.pptx");
  try {
    # Загружает исходный шрифт, который будет заменен
    $sourceFont = new FontData("SomeRareFont");
    # Загружает новый шрифт
    $destFont = new FontData("Arial");
    # Добавляет правило шрифта для замены шрифта
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # Добавляет правило в коллекцию правил замены шрифтов
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # Добавляет коллекцию правил шрифтов в список правил
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # Шрифт Arial будет использоваться вместо SomeRareFont, когда последний будет недоступен
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Сохраняет изображение на диске в формате JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert title="ПРИМЕЧАНИЕ"  color="warning"   %}} 

Вы можете захотеть увидеть [**Замена шрифтов**](/slides/php-java/font-replacement/).

{{% /alert %}}