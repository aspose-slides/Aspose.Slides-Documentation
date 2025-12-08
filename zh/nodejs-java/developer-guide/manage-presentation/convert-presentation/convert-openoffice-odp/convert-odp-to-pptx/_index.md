---
title: 将 ODP 转换为 PPTX
type: docs
weight: 10
url: /zh/nodejs-java/convert-odp-to-pptx/
---

## **将 ODP 转换为 PPTX/PPT 演示文稿**
Aspose.Slides for Node.js via Java 提供了表示演示文稿文件的 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类。现在，当实例化对象时，[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类也可以通过 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#Presentation-java.lang.String-) 构造函数访问 ODP。以下示例展示了如何将 ODP 演示文稿转换为 PPTX 演示文稿。
```javascript
// 打开 ODP 文件
var pres = new aspose.slides.Presentation("AccessOpenDoc.odp");
// 将 ODP 演示文稿保存为 PPTX 格式
pres.save("AccessOpenDoc_out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **实时示例**
您可以访问[**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/)网页应用，该应用基于**Aspose.Slides API**构建。该应用演示了如何使用 Aspose.Slides API 实现 ODP 到 PPTX 的转换。

## **常见问题**

**我需要安装 Microsoft PowerPoint 或 LibreOffice 才能将 ODP 转换为 PPTX 吗？**

不需要。Aspose.Slides 可独立运行，无需第三方应用程序即可读取或写入 ODP/PPTX。

**在转换过程中，母版幻灯片、布局和主题会被保留吗？**

会的。该库使用完整的演示文稿对象模型并保留结构，包括母版幻灯片和布局，因而转换后设计保持正确。

**我可以转换受密码保护的 ODP 文件吗？**

可以。Aspose.Slides 支持检测保护，打开并处理[受保护的演示文稿](/slides/zh/nodejs-java/password-protected-presentation/)（包括 ODP），只需提供密码，同时支持配置加密和访问文档属性。

**Aspose.Slides 适用于云或基于 REST 的转换服务吗？**

可以。您可以在自己的后端使用本地库，或使用[Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/)（REST API）；这两种方式都支持 ODP → PPTX 转换。