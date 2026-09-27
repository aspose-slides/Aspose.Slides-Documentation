---
title: 许可
description: "将许可证文件应用于 Aspose.Slides for Node.js via .NET，了解评估版的限制，并获取免费 30 天的临时许可证用于测试。"
type: docs
weight: 80
url: /zh/nodejs-net/licensing/
---
## **概述**

Aspose.Slides for Node.js via .NET 是一个用于评估和生产的 npm 包。未获取许可证时，它以评估模式运行。购买许可证或获取免费 30 天临时许可证后，只需几行代码即可应用，评估限制将不再生效。

{{% alert color="info" title="Note" %}}

关于如何评估、授权和购买 Aspose 产品的一般政策已收集在[Purchase Policies and FAQ](https://purchase.aspose.com/policies)。价格列在[Pricing Information](https://purchase.aspose.com/pricing/slides/zh/family)页面。

{{% /alert %}}

## **评估版限制**

评估版提供产品的全部功能，但有两项限制：

- **水印。** 您保存的每个演示文稿的每张幻灯片都会出现评估水印：幻灯片中部的锁定文本框，显示“Evaluation only”。相同的水印也会出现在 PDF、XPS 和 HTML 导出以及幻灯片图像上。
- **截断文本。** 从文本框、段落或片段读取的文本会被截断为前五个字符，后跟提示“… 文本因评估版限制而被截断”。Markdown 和 HTML5 导出也会以相同方式截断。您写入的文本会完整保存。

[评估 Aspose.Slides](/slides/zh/nodejs-net/evaluate-aspose-slides/) 详细描述了这两项限制，并提供了演示脚本。

{{% alert color="success" title="Tip" %}}

若想在不受评估限制的情况下测试 Aspose.Slides，可申请免费 **30 天临时许可证**。详情请参见[How to get a Temporary License?](https://purchase.aspose.com/temporary-license)。

{{% /alert %}}

## **关于许可证**

许可证是一个纯文本 XML 文件，包含产品名称、授权的开发者数量以及订阅到期日期等信息。文件已数字签名，请勿修改：即使误添加一行换行也会导致失效。

## **应用许可证**

使用 `License` 类的 `setLicense` 方法应用许可证。请在创建任何 `Presentation` 对象之前，于进程中调用一次。再次调用不会有害，但会重复已完成的工作。

下面的脚本演示了如何从名为 `Aspose.Slides.lic` 的文件中应用许可证。将文件名替换为您许可证文件的名称或完整路径；文件名可以任意。

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { License } = asposeSlides;

const license = new License();
try {
    license.setLicense("Aspose.Slides.lic");
    console.log("License applied.");
} catch (error) {
    console.log("License not applied:", error.message);
}
```

文件名或相对路径会相对于当前文件夹（即运行 `node` 的目录）解析。请将许可证文件放在项目文件夹中并在该目录下运行脚本，或使用完整路径。

如果找不到文件或文件不是有效的许可证，`setLicense` 会抛出错误，Aspose.Slides 将保持评估模式。脚本会捕获错误并打印其信息。对于缺失的文件，信息以 `License "Aspose.Slides.lic" doesn't exist or access is restricted.` 开头，并列出已搜索的所有位置。

在此包中，许可证仅能从文件加载。`License` 不接受流，且包未公开计量授权。有关该包封装的类，请参见 Aspose.Slides for .NET API 参考中的[License](https://reference.aspose.com/slides/zh/net/aspose.slides/license/)。