---
title: 通过VBA进行演示
type: docs
weight: 250
url: /zh/java/presentation-via-vba/
keywords: "宏, 宏, VBA, VBA宏, 添加宏, 删除宏, 添加VBA, 删除VBA, 提取宏, 提取VBA, PowerPoint宏, PowerPoint演示文稿, Java, Aspose.Slides for Java"
description: "在Java中添加、删除和提取PowerPoint演示文稿中的VBA宏"
---

{{% alert title="注意" color="warning" %}} 

当您将包含宏的演示文稿转换为不同的文件格式（PDF、HTML等）时，Aspose.Slides会忽略所有宏（宏不会被带入生成的文件中）。

当您向演示文稿添加宏或重新保存包含宏的演示文稿时，Aspose.Slides仅写入宏的字节。

Aspose.Slides **从不** 在演示文稿中运行宏。

{{% /alert %}}

## **添加VBA宏**

Aspose.Slides提供了[VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/)类，允许您创建VBA项目（和项目引用）并编辑现有模块。您可以使用[IVbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/ivbaproject/)接口来管理嵌入在演示文稿中的VBA。

1. 创建[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)类的实例。
1. 使用[VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/#VbaProject--)构造函数添加一个新的VBA项目。
1. 向VbaProject添加一个模块。
1. 设置模块源代码。
1. 添加对<stdole>的引用。
1. 添加对**Microsoft Office**的引用。
1. 将引用与VBA项目关联。
1. 保存演示文稿。

以下Java代码演示了如何从头开始向演示文稿添加VBA宏：

```java
// 创建演示文稿类的实例
Presentation pres = new Presentation();
try {
    // 创建一个新的VBA项目
    pres.setVbaProject(new VbaProject());
    
    // 向VBA项目添加一个空模块
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // 设置模块源代码
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // 创建对<stdole>的引用
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // 创建对Office的引用
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // 向VBA项目添加引用
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // 保存演示文稿
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

您可能想要查看**Aspose** [宏删除器](https://products.aspose.app/slides/remove-macros)，这是一个免费的网络应用程序，用于从PowerPoint、Excel和Word文档中删除宏。 

{{% /alert %}} 

## **删除VBA宏**

使用[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)类下的[VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getVbaProject--)属性，您可以删除VBA宏。

1. 创建[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)类的实例并加载包含宏的演示文稿。
1. 访问宏模块并将其删除。
1. 保存修改后的演示文稿。

以下Java代码演示了如何删除VBA宏：

```java
// 加载包含宏的演示文稿
Presentation pres = new Presentation("VBA.pptm");
try {
    // 访问Vba模块并将其删除 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // 保存演示文稿
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **提取VBA宏**

1. 创建[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)类的实例并加载包含宏的演示文稿。
2. 检查演示文稿是否包含VBA项目。
3. 遍历VBA项目中包含的所有模块以查看宏。

以下Java代码演示了如何从包含宏的演示文稿中提取VBA宏：

```java
// 加载包含宏的演示文稿
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // 检查演示文稿是否包含VBA项目
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