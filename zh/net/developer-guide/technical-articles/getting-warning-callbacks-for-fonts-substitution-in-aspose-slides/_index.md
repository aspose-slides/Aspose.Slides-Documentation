---
title: 获取 Aspose.Slides 中字体替换的警告回调
type: docs
weight: 120
url: /zh/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides for .NET 允许在渲染过程中字体不可用时获取字体替换的警告回调。警告回调对于调试在渲染过程中缺失或无法访问字体的问题非常有帮助。

{{% /alert %}} 
## **获取字体替换的警告回调**
Aspose.Slides for .NET 提供了简单的 API 方法以在渲染过程中获取警告回调。您只需按照下面的步骤在您的端配置警告回调：

1. 创建一个自定义回调类以接收回调。
2. 使用 LoadOptions 类设置警告回调。
3. 加载一个使用了在目标机器上不可用字体的演示文稿文件。
4. 生成幻灯片缩略图以查看效果。

```c#
//设置警告回调
LoadOptions lo = new LoadOptions();
lo.WarningCallback = new HandleFontsWarnings();

//实例化演示文稿
Presentation presentation = new Presentation("1.ppt", lo);

//生成幻灯片缩略图
foreach (ISlide slide in presentation.Slides)
{
    IImage image = slide.GetImage();
}
```

```c#
class HandleFontsWarnings : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        Console.WriteLine(warning.WarningType); // 1 - WarningType.DataLoss
        Console.WriteLine(warning.Description); // "字体将从 X 替换为 Y"
        return ReturnAction.Continue;
    }
}
```

