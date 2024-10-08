---
title: 通过 VBA 进行演示
type: docs
weight: 250
url: /net/presentation-via-vba/
keywords: "宏, 宏, VBA, VBA 宏, 添加宏, 移除宏, 添加 VBA, 移除 VBA, 提取宏, 提取 VBA, PowerPoint 宏, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中添加、移除和提取 PowerPoint 演示文稿中的 VBA 宏"
---

[Aspose.Slides.Vba](https://reference.aspose.com/slides/net/aspose.slides.vba/) 命名空间包含用于处理宏和 VBA 代码的类和接口。

{{% alert title="注意" color="warning" %}}

当您将包含宏的演示文稿转换为不同的文件格式（PDF、HTML 等）时，Aspose.Slides 会忽略所有宏（宏不会被带入生成的文件中）。

当您向演示文稿添加宏或重新保存包含宏的演示文稿时，Aspose.Slides 只是简单地写入宏的字节。

Aspose.Slides **绝不会** 运行演示文稿中的宏。

{{% /alert %}}

## **添加 VBA 宏**

Aspose.Slides 提供了 [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/) 类，允许您创建 VBA 项目（及项目引用）并编辑现有模块。您可以使用 [IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/) 接口来管理嵌入在演示文稿中的 VBA。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
1. 使用 [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) 构造函数添加一个新的 VBA 项目。
1. 向 VbaProject 添加一个模块。
1. 设置模块源代码。
1. 添加对 <stdole> 的引用。
1. 添加对 **Microsoft Office** 的引用。
1. 将引用与 VBA 项目关联。
1. 保存演示文稿。

以下 C# 代码演示如何从头开始向演示文稿添加一个 VBA 宏：

```c#
    // 创建演示文稿类的实例
using (Presentation presentation = new Presentation())
{
    // 创建一个新的 VBA 项目
    presentation.VbaProject = new VbaProject();

    // 向 VBA 项目添加一个空模块
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // 设置模块源代码
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

您可能想查看 **Aspose** [宏移除器](https://products.aspose.app/slides/remove-macros)，这是一个用于从 PowerPoint、Excel 和 Word 文档中移除宏的免费网页应用程序。

{{% /alert %}}

## **移除 VBA 宏**
使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类下的 [VbaProject](https://reference.aspose.com/slides/net/aspose.slides/presentation/vbaproject/) 属性，您可以移除一个 VBA 宏。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例并加载包含宏的演示文稿。
1. 访问宏模块并将其移除。
1. 保存修改后的演示文稿。

以下 C# 代码演示如何移除一个 VBA 宏：

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
1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例并加载包含宏的演示文稿。
2. 检查演示文稿是否包含 VBA 项目。
3. 循环遍历 VBA 项目中包含的所有模块以查看宏。

以下 C# 代码演示如何从包含宏的演示文稿中提取 VBA 宏：

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

## **检查 VBA 项目是否受到密码保护**

使用 [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) 属性，您可以检查项目属性是否受到密码保护。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例并加载包含宏的演示文稿。
2. 检查演示文稿是否包含 [VBA 项目](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/)。
3. 检查 VBA 项目是否受到密码保护，以查看项目属性。

以下 C# 代码演示该操作：

```c#
using (Presentation pres = new Presentation("VBA.pptm"))
{
    if (pres.VbaProject == null) // 检查演示文稿是否包含 VBA 项目
        return;

    if (pres.VbaProject.IsPasswordProtected)
    {
        Console.WriteLine("VBA 项目 '" + pres.VbaProject.Name +
                            "' 受到密码保护以查看项目属性。");
    }
}
```