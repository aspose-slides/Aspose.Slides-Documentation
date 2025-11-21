---
title: Aspose.Slides for .NET 14.2.0 中的公共 API 和向后不兼容的更改
linktitle: Aspose.Slides for .NET 14.2.0
type: docs
weight: 40
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- 迁移
- 旧代码
- 现代代码
- 旧方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审查 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示解决方案。"
---

## **公共 API 和向后不兼容的更改**
{{% alert color="primary" %}} 

我们在 Aspose.Slides for .NET 14.2.0 API 中做了一些更改。某些属性和方法已被删除，另一些已移至其他命名空间。

{{% /alert %}} 
### **已移除 Aspose.Slides.IPresentation.Write(…) 方法**
这些方法仅将 Presentation 对象写入 PPTX 格式文件。在新 API 中，Presentation 类用于处理所有格式。可以使用 Presentation.Save(…) 方法将 Presentation 对象保存为所有受支持的格式。
### **与主题样式相关的类已移动到 Aspose.Slides.Theme 命名空间**
以下类已从 Aspose.Slides 命名空间移动到 Aspose.Slides.Theme 命名空间。

- Types ColorScheme
- EffectStyle
- EffectStyleCollection
- EffectStyleCollectionEffectiveData
- ExtraColorSchemeCollection
- ExtraColorSchemeCollection
- ExtraColorScheme
- FillFormatCollection
- FillFormatCollectionEffectiveData
- FontScheme
- FontSchemeEffectiveData
- FormatScheme
- IColorScheme
- IEffectStyle
- IEffectStyleCollection
- IEffectStyleCollectionEffectiveData
- IEffectStyleEffectiveData
- IExtraColorScheme
- IExtraColorSchemeCollection
- IFillFormatCollection
- IFillFormatCollectionEffectiveData
- IFontScheme
- IFontSchemeEffectiveData
- IFormatScheme
- ILineFormatCollection
- ILineFormatCollectionEffectiveData
### **自 Aspose.Slides for .NET 8.X.0 起的更改**
Aspose.Slides for .NET 8.4 的功能已添加到 Aspose.Slides for .NET 14.2.0 中。