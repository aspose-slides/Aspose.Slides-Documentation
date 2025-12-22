---
title: 在 Android 上管理演示文稿中的 VBA 项目
linktitle: 通过 VBA 的演示文稿
type: docs
weight: 250
url: /zh/androidjava/presentation-via-vba/
keywords:
- 宏
- VBA
- VBA 宏
- 添加宏
- 删除宏
- 提取宏
- 添加 VBA
- 删除 VBA
- 提取 VBA
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android（通过 Java）通过 VBA 生成和操作 PowerPoint 与 OpenDocument 演示文稿，以简化您的工作流程。"
---

{{% alert title="注意" color="warning" %}} 

当您将包含宏的演示文稿转换为其他文件格式（PDF、HTML 等）时，Aspose.Slides 会忽略所有宏（宏不会被写入生成的文件）。

当您向演示文稿添加宏或重新保存包含宏的演示文稿时，Aspose.Slides 仅写入宏的字节。

Aspose.Slides **永不**在演示文稿中运行宏。

{{% /alert %}}

## **添加 VBA 宏**

Aspose.Slides 提供 [VbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/vbaproject/) 类，以便您创建 VBA 项目（以及项目引用）并编辑现有模块。您可以使用 [IVbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivbaproject/) 接口来管理嵌入演示文稿的 VBA。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。  
1. 使用 [VbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/vbaproject/#VbaProject--) 构造函数添加新的 VBA 项目。  
1. 向 VbaProject 添加模块。  
1. 设置模块的源代码。  
1. 添加对 <stdole> 的引用。  
1. 添加对 **Microsoft Office** 的引用。  
1. 将引用关联到 VBA 项目。  
1. 保存演示文稿。  

此 Java 代码演示了如何从头向演示文稿添加 VBA 宏：
```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 创建一个新的 VBA 项目
    pres.setVbaProject(new VbaProject());
    
    // 向 VBA 项目添加一个空模块
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // 设置模块的源代码
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // 创建对 <stdole> 的引用
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // 创建对 Office 的引用
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // 向 VBA 项目添加引用
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // 保存演示文稿
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 

您可能想了解 **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros)，这是一款用于从 PowerPoint、Excel 和 Word 文档中删除宏的免费网络应用。 

{{% /alert %}} 

## **删除 VBA 宏**

使用位于 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类下的 [VbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getVbaProject--) 属性，您可以删除 VBA 宏。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例并加载包含宏的演示文稿。  
1. 访问宏模块并将其删除。  
1. 保存修改后的演示文稿。  

此 Java 代码演示了如何删除 VBA 宏：
```java
// 加载包含宏的演示文稿
Presentation pres = new Presentation("VBA.pptm");
try {
    // 访问 Vba 模块并将其移除 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // 保存演示文稿
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```


## **提取 VBA 宏**

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例并加载包含宏的演示文稿。  
2. 检查演示文稿是否包含 VBA 项目。  
3. 遍历 VBA 项目中所有模块以查看宏。  

此 Java 代码演示了如何从包含宏的演示文稿中提取 VBA 宏：
```java
// 加载包含宏的演示文稿
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // 检查演示文稿是否包含 VBA 项目
    {
        for (IVbaModule module : pres.getVbaProject().getModules())
        {
            System.out.println(module.getName());
            System.out.println(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **检查 VBA 项目是否受密码保护**

使用 [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--) 方法，您可以确定项目属性是否受密码保护。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例并加载包含宏的演示文稿。  
2. 检查演示文稿是否包含 [VBA 项目](https://reference.aspose.com/slides/androidjava/com.aspose.slides/vbaproject/)。  
3. 检查 VBA 项目是否受密码保护以查看其属性。  
```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // 检查演示文稿是否包含 VBA 项目。
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```


## **常见问题**

**如果我将演示文稿保存为 PPTX，会发生什么？**  

由于 PPTX 不支持 VBA，宏将被移除。若要保留宏，请选择 PPTM、PPSM 或 POTM。

**Aspose.Slides 能在演示文稿中运行宏，例如刷新数据吗？**  

不能。该库从不执行 VBA 代码；只有在 PowerPoint 中并且拥有相应的安全设置时才能执行。

**是否支持使用链接到 VBA 代码的 ActiveX 控件？**  

是的，您可以访问现有的 [ActiveX controls](/slides/zh/androidjava/activex/)，修改其属性并将其删除。这在宏与 ActiveX 交互时非常有用。