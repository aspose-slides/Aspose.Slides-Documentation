---
title: 将ODP转换为PPTX
type: docs
weight: 10
url: /java/convert-odp-to-pptx/
---

## **将ODP转换为PPTX/PPT演示文稿**
Aspose.Slides for Java提供了[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类，该类表示演示文稿文件。[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类现在也可以通过[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#Presentation-java.lang.String-)构造函数访问ODP，当对象被实例化时。以下示例演示了如何将ODP演示文稿转换为PPTX演示文稿。

```java
// 打开ODP文件
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// 将ODP演示文稿保存为PPTX格式
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **实时示例**
您可以访问[**Aspose.Slides转换**](https://products.aspose.app/slides/conversion/) веб应用程序，该应用程序是基于**Aspose.Slides API**构建的。该应用演示了如何使用Aspose.Slides API实现ODP到PPTX的转换。