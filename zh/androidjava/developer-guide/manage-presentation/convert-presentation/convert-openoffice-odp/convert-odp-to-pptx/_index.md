---
title: 将 ODP 转换为 PPTX
type: docs
weight: 10
url: /androidjava/convert-odp-to-pptx/
---

## **将 ODP 转换为 PPTX/PPT 演示文稿**
Aspose.Slides for Android via Java 提供了 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类，该类代表一个演示文稿文件。现在，[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类也可以通过 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-) 构造函数访问 ODP，当对象被实例化时。以下示例演示了如何将 ODP 演示文稿转换为 PPTX 演示文稿。

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
您可以访问 [**Aspose.Slides 转换**](https://products.aspose.app/slides/conversion/) 网络应用程序，该应用程序是使用 **Aspose.Slides API** 构建的。该应用程序演示了如何用 Aspose.Slides API 实现 ODP 到 PPTX 的转换。