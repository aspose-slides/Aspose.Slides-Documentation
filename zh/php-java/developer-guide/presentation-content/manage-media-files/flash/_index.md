---
title: Flash
type: docs
weight: 10
url: /zh/php-java/flash/
description: 使用PHP从PowerPoint演示文稿中提取Flash对象
---

## **从演示文稿中提取Flash对象**

Aspose.Slides for PHP via Java提供了一种从演示文稿中提取Flash对象的功能。您可以通过名称访问Flash控件，并将其从演示文稿中提取，并存储SWF对象数据。

```php
  # 实例化表示PPTX的Presentation类
  $pres = new Presentation();
  try {
    $controls = $pres->getSlides()->get_Item(0)->getControls();
    $flashControl = null;
    foreach($controls as $control) {
      if (java_values($control->getName()) == "ShockwaveFlash1") {
        $flashControl = $control;
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```