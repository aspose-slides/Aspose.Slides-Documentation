---
title: Aspose.Slides for .NET 14.2.0 的公共 API 和不向后兼容的更改
type: docs
weight: 40
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
---

## **公共 API 和不向后兼容的更改**
{{% alert color="primary" %}} 

我们在 Aspose.Slides for .NET 14.2.0 API 中进行了些更改。一些属性和方法已被移除，另一些则已移动到其他命名空间。

{{% /alert %}} 
### **已移除的方法 Aspose.Slides.IPresentation.Write(…)**
这些方法仅将演示文稿对象写入 PPTX 格式文件。在新 API 中，Presentation 类用于处理所有格式。可以使用 Presentation.Save(…) 方法将演示文稿对象保存为所有支持的格式。
### **与主题样式相关的类已移至 Aspose.Slides.Theme 命名空间**
以下类已从 Aspose.Slides 命名空间移至 Aspose.Slides.Theme 命名空间。

- 类型 ColorScheme
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
### **Aspose.Slides for .NET 8.X.0 的更改**
Aspose.Slides for .NET 8.4 的功能已添加到 Aspose.Slides for .NET 14.2.0 中。