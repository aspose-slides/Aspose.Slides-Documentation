---
title: 字体替换 - PowerPoint Java API
linktitle: 字体替换
type: docs
weight: 60
url: /zh/php-java/font-replacement/
description: 了解如何使用 Java API 中的显式替换方法在 PowerPoint 中替换字体。
---

如果您改变了对某种字体的看法，可以用另一种字体替换该字体。所有旧字体的实例将被新字体替换。

Aspose.Slides 允许您以这种方式替换字体：

1. 加载相关的演示文稿。
2. 加载将被替换的字体。
3. 加载新字体。
4. 替换字体。
5. 将修改后的演示文稿写入 PPTX 文件。

以下 PHP 代码演示了字体替换：

```php
  # 加载演示文稿
  $pres = new Presentation("Fonts.pptx");
  try {
    # 加载将被替换的源字体
    $sourceFont = new FontData("Arial");
    # 加载新字体
    $destFont = new FontData("Times New Roman");
    # 替换字体
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # 保存演示文稿
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="注意" color="warning" %}} 

要设置规则以确定在某些情况下会发生什么（例如，无法访问字体时），请参阅 [**字体替换**](/slides/zh/php-java/font-substitution/)。

{{% /alert %}}