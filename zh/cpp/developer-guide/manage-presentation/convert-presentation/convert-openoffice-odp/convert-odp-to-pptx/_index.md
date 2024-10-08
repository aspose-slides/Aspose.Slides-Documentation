---
title: 转换 ODP 到 PPTX
type: docs
weight: 10
url: /zh/cpp/convert-odp-to-pptx/
---

Aspose.Slides for .NET 提供了 Presentation 类，表示一个演示文稿文件。[**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类现在也可以通过 Presentation 构造函数访问 ODP，当对象被实例化时。以下示例演示了如何将 ODP 演示文稿转换为 PPTX 演示文稿。

``` cpp
// 文档目录的路径。
String dataDir = GetDataPath();

// 打开 ODP 文件
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// 将 ODP 演示文稿保存为 PPTX 格式
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```



## **在线示例**
您可以访问 [**Aspose.Slides 转换**](https://products.aspose.app/slides/conversion/) 网络应用程序，该应用程序是使用 **Aspose.Slides API** 构建的。该应用程序演示了如何使用 Aspose.Slides API 实现 ODP 到 PPTX 的转换。