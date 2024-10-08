---
title: 将 ODP 转换为 PPTX
type: docs
weight: 10
url: /python-net/convert-odp-to-pptx/
keywords: "转换 OpenOffice 演示文稿, ODP, ODP 转 PPTX, Python"
description: "在 Python 中将 OpenOffice ODP 转换为 PowerPoint 演示文稿 PPTX"
---

Aspose.Slides for Python via .NET 提供了表示演示文稿文件的 Presentation 类。[**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类现在还可以通过 Presentation 构造函数访问 ODP，实例化对象时可实现。以下示例演示如何将 ODP 演示文稿转换为 PPTX 演示文稿。

```py
# 导入 Aspose.Slides for Python via .NET 模块
import aspose.slides as slides

# 打开 ODP 文件
pres = slides.Presentation("AccessOpenDoc.odp")

# 将 ODP 演示文稿保存为 PPTX 格式
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```



## **在线示例**
您可以访问 [**Aspose.Slides 转换**](https://products.aspose.app/slides/conversion/) 网页应用程序，该应用程序是使用 **Aspose.Slides API** 构建的。该应用程序演示了如何使用 Aspose.Slides API 实现 ODP 转 PPTX 的转换。