---
title: 在 C++ 中将 ODP 转换为 PPTX
linktitle: ODP 转 PPTX
type: docs
weight: 10
url: /zh/cpp/convert-odp-to-pptx/
keywords:
- 转换 OpenDocument
- 转换 演示文稿
- 转换 幻灯片
- 转换 ODP
- OpenDocument 转 PPTX
- ODP 转 PPTX
- 将 ODP 保存为 PPTX
- 导出 ODP 为 PPTX
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 将 ODP 转换为 PPTX。干净的代码示例、批量技巧以及高质量结果——无需 PowerPoint。"
---

## **ODP 转 PPTX 转换**

Aspose.Slides for .NET 提供表示演示文件的 Presentation 类。[**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类现在还可以通过实例化时的 Presentation 构造函数访问 ODP。以下示例演示如何将 ODP 演示文稿转换为 PPTX 演示文稿。
``` cpp
// 文档目录的路径。
String dataDir = GetDataPath();

// 打开 ODP 文件
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// 将 ODP 演示文稿保存为 PPTX 格式
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **实时示例**

您可以访问[**Aspose.Slides 转换**](https://products.aspose.app/slides/conversion/) Web 应用，该应用基于**Aspose.Slides API**构建。该应用演示了如何使用 Aspose.Slides API 实现 ODP 到 PPTX 的转换。

## **常见问答**

**是否需要安装 Microsoft PowerPoint 或 LibreOffice 才能将 ODP 转换为 PPTX？**

不需要。Aspose.Slides 可独立工作，无需第三方应用程序即可读取或写入 ODP/PPTX。

**在转换过程中是否会保留母版幻灯片、布局和主题？**

会。库使用完整的演示文稿对象模型并保留结构，包括母版幻灯片和布局，从而在转换后保持设计正确。

**我可以转换受密码保护的 ODP 文件吗？**

可以。Aspose.Slides 支持检测保护，打开并处理[受保护的演示文稿](/slides/zh/cpp/password-protected-presentation/)（包括 ODP），只需提供密码，还支持配置加密和访问文档属性。

**Aspose.Slides 适用于云或基于 REST 的转换服务吗？**

可以。您可以在自己的后端使用本地库，或使用[Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/)（REST API）；两种方式均支持 ODP → PPTX 转换。