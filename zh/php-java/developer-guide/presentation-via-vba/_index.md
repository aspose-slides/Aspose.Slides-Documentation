---
title: 通过 VBA 演示文稿
type: docs
weight: 250
url: /zh/php-java/presentation-via-vba/
keywords: "宏, 宏, VBA, VBA 宏, 添加宏, 移除宏, 添加 VBA, 移除 VBA, 提取宏, 提取 VBA, PowerPoint 宏, PowerPoint 演示文稿, Java, Aspose.Slides for PHP via Java"
description: "在 PowerPoint 演示文稿中添加、移除和提取 VBA 宏"
---

{{% alert title="注意" color="warning" %}} 

当您将包含宏的演示文稿转换为其他文件格式（PDF、HTML 等）时，Aspose.Slides 会忽略所有宏（宏不会被带入生成的文件中）。

当您向演示文稿添加宏或重新保存包含宏的演示文稿时，Aspose.Slides 只是将宏的字节写入。

Aspose.Slides **从未** 运行演示文稿中的宏。

{{% /alert %}}

## **添加 VBA 宏**

Aspose.Slides 提供了 [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/) 类，允许您创建 VBA 项目（和项目引用）并编辑现有模块。您可以使用 [IVbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/ivbaproject/) 接口来管理嵌入在演示文稿中的 VBA。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
1. 使用 [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#VbaProject--) 构造函数添加新的 VBA 项目。
1. 向 VbaProject 添加一个模块。
1. 设置模块源代码。
1. 添加对 <stdole> 的引用。
1. 添加对 **Microsoft Office** 的引用。
1. 将引用与 VBA 项目关联。
1. 保存演示文稿。

以下 PHP 代码演示如何从头开始向演示文稿添加 VBA 宏：

```php
  # 创建演示文稿类的实例
  $pres = new Presentation();
  try {
    # 创建新的 VBA 项目
    $pres->setVbaProject(new VbaProject());
    # 向 VBA 项目添加一个空模块
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # 设置模块源代码
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # 创建对 <stdole> 的引用
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # 创建对 Office 的引用
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # 向 VBA 项目添加引用
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # 保存演示文稿
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

您可能想查看 **Aspose** [宏移除工具](https://products.aspose.app/slides/remove-macros)，这是一个用于从 PowerPoint、Excel 和 Word 文档中移除宏的免费 web 应用程序。

{{% /alert %}} 

## **移除 VBA 宏**

使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类下的 [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject--) 属性，您可以移除 VBA 宏。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例并加载包含宏的演示文稿。
1. 访问宏模块并将其移除。
1. 保存修改后的演示文稿。

以下 PHP 代码演示如何移除 VBA 宏：

```php
  # 加载包含宏的演示文稿
  $pres = new Presentation("VBA.pptm");
  try {
    # 访问 Vba 模块并移除它
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # 保存演示文稿
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **提取 VBA 宏**

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例并加载包含宏的演示文稿。
2. 检查演示文稿是否包含 VBA 项目。
3. 遍历 VBA 项目中包含的所有模块以查看宏。

以下 PHP 代码演示如何从包含宏的演示文稿中提取 VBA 宏：

```php
  # 加载包含宏的演示文稿
  $pres = new Presentation("VBA.pptm");
  try {
    # 检查演示文稿是否包含 VBA 项目
    if (!java_is_null($pres->getVbaProject())) {
      foreach($pres->getVbaProject()->getModules() as $module) {
        echo($module->getName());
        echo($module->getSourceCode());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```