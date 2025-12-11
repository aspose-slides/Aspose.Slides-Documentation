---
title: 使用 C++ 在演示文稿中管理 VBA 项目
linktitle: 通过 VBA 的演示文稿
type: docs
weight: 250
url: /zh/cpp/presentation-via-vba/
keywords:
- 宏
- VBA
- VBA宏
- 添加宏
- 删除宏
- 提取宏
- 添加 VBA
- 删除 VBA
- 提取 VBA
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 通过 VBA 生成和操作 PowerPoint 与 OpenDocument 演示文稿，以简化工作流程。"
---

[Aspose.Slides.Vba](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.vba/) 命名空间包含用于处理宏和 VBA 代码的类和接口。

{{% alert title="Note" color="warning" %}} 

当您将包含宏的演示文稿转换为其他文件格式（PDF、HTML 等）时，Aspose.Slides 会忽略所有宏（宏不会被转入生成的文件）。

当您向演示文稿添加宏或重新保存包含宏的演示文稿时，Aspose.Slides 只会写入宏的字节数据。

Aspose.Slides **永不** 在演示文稿中运行宏。

{{% /alert %}}

## **Add VBA Macros**

Aspose.Slides 提供了 [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project) 类，以便您创建 VBA 项目（及项目引用）并编辑现有模块。您可以使用 [IVbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.i_vba_project/) 接口来管理嵌入演示文稿的 VBA。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 使用 [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) 构造函数添加新的 VBA 项目。
1. 向 VbaProject 添加模块。
1. 设置模块的源代码。
1. 添加对 <stdole> 的引用。
1. 添加对 **Microsoft Office** 的引用。
1. 将这些引用关联到 VBA 项目。
1. 保存演示文稿。

此 C++ 代码演示了如何从头向演示文稿添加 VBA 宏： 
```c++
// 文档目录的路径。
const String outPath = u"../out/AddVBAMacros_out.pptm";

// 创建 Presentation 类的实例
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// 创建一个新的 VBA 项目
presentation->set_VbaProject(MakeObject<VbaProject>());

// 向 VBA 项目添加一个空模块
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// 设置模块源代码
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// 创建对 <stdole> 的引用
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// 创建对 Office 的引用
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// 向 VBA 项目添加引用
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// 保存演示文稿
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```


{{% alert color="primary" %}} 

您可能想了解 **Aspose** 的 [Macro Remover](https://products.aspose.app/slides/remove-macros)，这是一款免费网页应用，可用于从 PowerPoint、Excel 和 Word 文档中删除宏。 

{{% /alert %}} 

## **Remove VBA Macros**

使用位于 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类下的 [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) 属性，您可以删除 VBA 宏。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例并加载包含宏的演示文稿。
1. 访问宏模块并将其删除。
1. 保存修改后的演示文稿。

此 C++ 代码演示了如何删除 VBA 宏： 
```c++
// 文档目录的路径。
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// 加载包含宏的演示文稿
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// 访问 Vba 模块并将其移除 
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// 保存演示文稿
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```


## **Extract VBA Macros**

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例并加载包含宏的演示文稿。
2. 检查演示文稿是否包含 VBA 项目。
3. 遍历 VBA 项目中所有模块以查看宏。

此 C++ 代码演示了如何从包含宏的演示文稿中提取 VBA 宏： 
```c++
	// 文档目录的路径。
	const String templatePath = u"../templates/VBA.pptm";

	// 加载包含宏的演示文稿
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // 检查演示文稿是否包含 VBA 项目
	{
		
		//for (SharedPtr<IVbaModule> module : pres->get_VbaProject()->get_Modules())
		for (int i = 0; i < pres->get_VbaProject()->get_Modules()->get_Count(); i++)
		{
			SharedPtr<IVbaModule> module = pres->get_VbaProject()->get_Modules()->idx_get(i);

			System::Console::WriteLine(module->get_Name());
			System::Console::WriteLine(module->get_SourceCode());
		}
	}
```


## **Check Whether a VBA Project Is Password-Protected**

使用 [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) 属性，您可以判断项目属性是否受密码保护。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例并加载包含宏的演示文稿。
2. 检查演示文稿是否包含 [VBA project](https://reference.aspose.com/slides/cpp/aspose.slides.vba/vbaproject/)。
3. 检查 VBA 项目是否受密码保护以查看其属性。
```cpp
auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // 检查演示文稿是否包含 VBA 项目。
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```


## **FAQ**

**如果将演示文稿另存为 PPTX，会发生什么？**

宏会被删除，因为 PPTX 不支持 VBA。若需保留宏，请选择 PPTM、PPSM 或 POTM。

**Aspose.Slides 能在演示文稿中运行宏，例如刷新数据吗？**

不能。库永不执行 VBA 代码；只有在 PowerPoint 中且安全设置允许时才可能运行。

**是否支持使用与 VBA 代码关联的 ActiveX 控件？**

是的，您可以访问现有的 [ActiveX controls](/slides/zh/cpp/activex/)，修改其属性并将其删除。这在宏与 ActiveX 交互时非常有用。