---
title: 通过VBA进行演示
type: docs
weight: 250
url: /cpp/presentation-via-vba/
keywords: "宏, 宏, VBA, VBA宏, 添加宏, 删除宏, 添加VBA, 删除VBA, 提取宏, 提取VBA, PowerPoint宏, PowerPoint演示文稿, C++, CPP, Aspose.Slides for C++"
description: "在C++中添加、删除和提取PowerPoint演示文稿中的VBA宏"
---

[Aspose.Slides.Vba](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.vba/)命名空间包含用于处理宏和VBA代码的类和接口。

{{% alert title="注意" color="warning" %}} 

当您将包含宏的演示文稿转换为其他文件格式（PDF、HTML等）时，Aspose.Slides会忽略所有宏（宏不会被带入结果文件中）。

当您向演示文稿添加宏或重新保存包含宏的演示文稿时，Aspose.Slides只会写入宏的字节。

Aspose.Slides **从不** 执行演示文稿中的宏。

{{% /alert %}}

## **添加VBA宏**

Aspose.Slides提供了[VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project)类，允许您创建VBA项目（和项目引用）并编辑现有模块。您可以使用[IVbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.i_vba_project/)接口来管理嵌入在演示文稿中的VBA。

1. 创建一个[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)类的实例。
2. 使用[VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b)构造函数添加一个新的VBA项目。
3. 向VbaProject添加一个模块。
4. 设置模块源代码。
5. 添加对<stdole>的引用。
6. 添加对**Microsoft Office**的引用。
7. 将引用与VBA项目关联。
8. 保存演示文稿。

以下C++代码演示如何从头开始向演示文稿添加VBA宏： 

```c++

// 文档目录的路径。
const String outPath = u"../out/AddVBAMacros_out.pptm";

// 创建演示文稿类的实例
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// 创建一个新的VBA项目
presentation->set_VbaProject(MakeObject<VbaProject>());

// 向VBA项目添加一个空模块
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// 设置模块源代码
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// 创建对<stdole>的引用
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// 创建对Office的引用
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// 向VBA项目添加引用
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// 保存演示文稿
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);

```

{{% alert color="primary" %}} 

您可能想查看**Aspose**的[宏删除器](https://products.aspose.app/slides/remove-macros)，这是一款用于从PowerPoint、Excel和Word文档中删除宏的免费网络应用。

{{% /alert %}} 

## **删除VBA宏**

使用[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)类下的[VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4)属性，您可以删除VBA宏。

1. 创建一个[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)类的实例并加载包含宏的演示文稿。
2. 访问宏模块并将其删除。
3. 保存修改后的演示文稿。

以下C++代码演示如何删除VBA宏： 

```c++

// 文档目录的路径。
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// 加载包含宏的演示文稿
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// 访问Vba模块并将其删除 
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// 保存演示文稿
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);

```

## **提取VBA宏**

1. 创建一个[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)类的实例并加载包含宏的演示文稿。
2. 检查演示文稿是否包含VBA项目。
3. 遍历VBA项目中包含的所有模块以查看宏。

以下C++代码演示如何从包含宏的演示文稿中提取VBA宏： 

```c++

	// 文档目录的路径。
	const String templatePath = u"../templates/VBA.pptm";

	// 加载包含宏的演示文稿
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // 检查演示文稿是否包含VBA项目
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