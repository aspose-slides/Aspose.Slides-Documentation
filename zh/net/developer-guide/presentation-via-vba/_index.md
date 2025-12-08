---
title: 通过 VBA 的演示文稿
type: docs
weight: 250
url: /zh/net/presentation-via-vba/
keywords: "宏, 宏, VBA, VBA 宏, 添加宏, 删除宏, 添加 VBA, 删除 VBA, 提取宏, 提取 VBA, PowerPoint 宏, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中添加、删除和提取 PowerPoint 演示文稿中的 VBA 宏"
---

[Aspose.Slides.Vba](https://reference.aspose.com/slides/net/aspose.slides.vba/) 命名空间包含用于处理宏和 VBA 代码的类和接口。

{{% alert title="Note" color="warning" %}} 

当您将包含宏的演示文稿转换为其他文件格式（PDF、HTML 等）时，Aspose.Slides 会忽略所有宏（宏不会随生成的文件携带）。

当您向演示文稿添加宏或重新保存包含宏的演示文稿时，Aspose.Slides 仅写入宏的字节。

Aspose.Slides **永不** 在演示文稿中运行宏。

{{% /alert %}}

## **添加 VBA 宏**

Aspose.Slides 提供了 [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/) 类，让您可以创建 VBA 项目（及项目引用）并编辑现有模块。您可以使用 [IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/) 接口来管理嵌入演示文稿中的 VBA。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
2. 使用 [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) 构造函数添加新的 VBA 项目。
3. 向 VbaProject 添加模块。
4. 设置模块的源代码。
5. 添加对 <stdole> 的引用。
6. 添加对 **Microsoft Office** 的引用。
7. 将这些引用关联到 VBA 项目。
8. 保存演示文稿。

下面的 C# 代码演示了如何从头向演示文稿添加 VBA 宏：
```c#
    // 创建 Presentation 类的实例
using (Presentation presentation = new Presentation())
{
    // 创建一个新的 VBA 项目
    presentation.VbaProject = new VbaProject();

    // 向 VBA 项目添加一个空模块
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // 设置模块的源代码
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // 创建对 <stdole> 的引用
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // 创建对 Office 的引用
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // 向 VBA 项目添加引用
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // 保存演示文稿
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


{{% alert color="primary" %}} 

您可能想了解 **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros)，这是一款免费网页版应用，可用于从 PowerPoint、Excel 和 Word 文档中移除宏。 

{{% /alert %}} 

## **删除 VBA 宏**
通过 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类下的 [VbaProject](https://reference.aspose.com/slides/net/aspose.slides/presentation/vbaproject/) 属性，您可以移除 VBA 宏。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例并加载包含宏的演示文稿。
2. 访问宏模块并将其移除。
3. 保存修改后的演示文稿。

下面的 C# 代码演示了如何移除 VBA 宏：
```c#
    // 加载包含宏的演示文稿
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // 访问 Vba 模块并将其移除 
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // 保存演示文稿
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


## **提取 VBA 宏**
1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例并加载包含宏的演示文稿。
2. 检查演示文稿是否包含 VBA 项目。
3. 遍历 VBA 项目中包含的所有模块以查看宏。

下面的 C# 代码演示了如何从包含宏的演示文稿中提取 VBA 宏：
```c#
    // 加载包含宏的演示文稿
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // 检查演示文稿是否包含 VBA 项目
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```


## **检查 VBA 项目是否受密码保护**
使用 [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) 属性，您可以确定项目属性是否受密码保护。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例并加载包含宏的演示文稿。
2. 检查演示文稿是否包含 [VBA project](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/)。
3. 检查该 VBA 项目是否受密码保护以查看其属性。
```cs
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // 检查演示文稿是否包含 VBA 项目。
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```


## **常见问题**

**如果我将演示文稿保存为 PPTX，会发生什么情况？**

宏将被移除，因为 PPTX 不支持 VBA。若需保留宏，请选择 PPTM、PPSM 或 POTM。

**Aspose.Slides 能在演示文稿中运行宏，例如刷新数据吗？**

不能。该库永不执行 VBA 代码；只有在 PowerPoint 中且安全设置允许时才可能运行宏。

**是否支持使用链接到 VBA 代码的 ActiveX 控件？**

支持，您可以访问现有的 [ActiveX controls](/slides/zh/net/activex/)，修改其属性并将其移除。这在宏与 ActiveX 交互时非常有用。