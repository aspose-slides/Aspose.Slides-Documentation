---
title: 将 ODP 转换为 PPTX（Java）
linktitle: ODP 转 PPTX
type: docs
weight: 10
url: /zh/java/convert-odp-to-pptx/
keywords:
- 转换 OpenDocument
- 转换 演示文稿
- 转换 幻灯片
- 转换 ODP
- OpenDocument 转 PPTX
- ODP 转 PPTX
- 将 ODP 保存为 PPTX
- 将 ODP 导出为 PPTX
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 将 ODP 转换为 PPTX。提供简洁的 Java 示例代码、批量技巧和高质量结果——无需 PowerPoint。"
---

## **将 ODP 转换为 PPTX/PPT 演示文稿**
Aspose.Slides for Java 提供了表示演示文件的 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类。现在，[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类在实例化对象时也可以通过 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#Presentation-java.lang.String-) 构造函数访问 ODP。下面的示例展示了如何将 ODP 演示文稿转换为 PPTX 演示文稿。
```java
// 打开 ODP 文件
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// 将 ODP 演示文稿保存为 PPTX 格式
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **实时示例**
您可以访问基于 **Aspose.Slides API** 构建的 [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) 网络应用。该应用演示了如何使用 Aspose.Slides API 实现 ODP 到 PPTX 的转换。