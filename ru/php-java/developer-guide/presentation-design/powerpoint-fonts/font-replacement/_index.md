---
title: Замена шрифтов - PowerPoint Java API
linktitle: Замена шрифтов
type: docs
weight: 60
url: /php-java/font-replacement/
description: Узнайте, как заменить шрифты с помощью явного метода замены в PowerPoint с использованием Java API.
---

Если вы передумали использовать определённый шрифт, вы можете заменить его на другой. Все экземпляры старого шрифта будут заменены новым шрифтом.

Aspose.Slides позволяет заменять шрифты таким образом:

1. Загрузите соответствующую презентацию.
2. Загрузите шрифт, который будет заменен.
3. Загрузите новый шрифт.
4. Замените шрифт.
5. Сохраните изменённую презентацию в формате PPTX.

Этот код PHP демонстрирует замену шрифта:

```php
  # Загружает презентацию
  $pres = new Presentation("Fonts.pptx");
  try {
    # Загружает исходный шрифт, который будет заменен
    $sourceFont = new FontData("Arial");
    # Загружает новый шрифт
    $destFont = new FontData("Times New Roman");
    # Заменяет шрифты
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # Сохраняет презентацию
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Примечание" color="warning" %}} 

Чтобы установить правила, которые определяют, что происходит в определённых условиях (например, если шрифт не может быть доступен), смотрите [**Замена шрифтов**](/slides/php-java/font-substitution/).

{{% /alert %}}