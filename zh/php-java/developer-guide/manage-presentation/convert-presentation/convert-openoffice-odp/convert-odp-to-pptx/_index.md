---
title: ODP 转换为 PPTX
type: docs
weight: 10
url: /zh/php-java/convert-odp-to-pptx/
---

## **将 ODP 转换为 PPTX/PPT 演示文稿**
Aspose.Slides for PHP via Java 提供了 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类，该类表示演示文稿文件。现在， [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类也可以通过 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#Presentation-java.lang.String-) 构造函数访问 ODP，当对象被实例化时。以下示例演示了如何将 ODP 演示文稿转换为 PPTX 演示文稿。

```php
// 打开 ODP 文件
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # 将 ODP 演示文稿保存为 PPTX 格式
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **实时示例**
您可以访问 [**Aspose.Slides 转换**](https://products.aspose.app/slides/conversion/) web 应用，该应用基于 **Aspose.Slides API** 构建。该应用演示了如何使用 Aspose.Slides API 实现 ODP 到 PPTX 的转换。