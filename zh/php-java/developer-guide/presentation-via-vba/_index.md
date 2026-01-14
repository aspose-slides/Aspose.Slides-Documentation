---
title: 使用 PHP 在演示文稿中管理 VBA 项目
linktitle: 通过 VBA 的演示文稿
type: docs
weight: 250
url: /zh/php-java/presentation-via-vba/
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
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java，通过 VBA 生成和操纵 PowerPoint 以及 OpenDocument 演示文稿，以简化工作流程。"
---

{{% alert title="注意" color="warning" %}} 

当您将包含宏的演示文稿转换为其他文件格式（PDF、HTML 等）时，Aspose.Slides 会忽略所有宏（宏不会随生成的文件一起保存）。

当您向演示文稿添加宏或重新保存包含宏的演示文稿时，Aspose.Slides 只会写入宏的字节数据。

Aspose.Slides **永不**运行演示文稿中的宏。

{{% /alert %}}

## **添加 VBA 宏**

Aspose.Slides 提供了 [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/) 类，以便您创建 VBA 项目（及项目引用）并编辑现有模块。您可以使用 `VbaProject` 类管理嵌入演示文稿的 VBA。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
1. 使用 [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#VbaProject) 构造函数添加新 VBA 项目。
1. 向 VbaProject 添加模块。
1. 设置模块源代码。
1. 添加对 <stdole> 的引用。
1. 添加对 **Microsoft Office** 的引用。
1. 将引用关联到 VBA 项目。
1. 保存演示文稿。

以下 PHP 代码演示如何从头添加 VBA 宏到演示文稿：
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

您可能想了解 **Aspose** 的 [Macro Remover](https://products.aspose.app/slides/remove-macros)，这是一款免费网络应用，用于从 PowerPoint、Excel 和 Word 文档中移除宏。

{{% /alert %}} 

## **移除 VBA 宏**

通过在 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类下使用 [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject) 属性，您可以移除 VBA 宏。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例并加载包含宏的演示文稿。
1. 访问宏模块并将其删除。
1. 保存已修改的演示文稿。

以下 PHP 代码演示如何移除 VBA 宏：
```php
  # 加载包含宏的演示文稿
  $pres = new Presentation("VBA.pptm");
  try {
    # 访问 Vba 模块并将其删除
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


## **检查 VBA 项目是否受密码保护**

使用 [VbaProject::isPasswordProtected](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#isPasswordProtected) 方法，您可以确定项目属性是否受密码保护。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例并加载包含宏的演示文稿。
2. 检查演示文稿是否包含 [VBA project](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/)。
3. 检查 VBA 项目是否受密码保护以查看其属性。
```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // 检查演示文稿是否包含 VBA 项目。
        if ($presentation->getVbaProject()->isPasswordProtected()) {
            printf("The VBA Project '%s' is protected by password to view project properties.", 
                    $presentation->getVbaProject()->getName());
        }
    }
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**将演示文稿另存为 PPTX 时宏会怎样？**

宏将被移除，因为 PPTX 不支持 VBA。若要保留宏，请选择 PPTM、PPSM 或 POTM。

**Aspose.Slides 能在演示文稿中运行宏，例如刷新数据吗？**

不能。该库永不执行 VBA 代码；只有在 PowerPoint 中且安全设置允许时才可能执行。

**是否支持使用链接到 VBA 代码的 ActiveX 控件？**

是的，您可以访问现有的 [ActiveX controls](/slides/zh/php-java/activex/)，修改其属性并将其移除。当宏与 ActiveX 交互时，这非常有用。