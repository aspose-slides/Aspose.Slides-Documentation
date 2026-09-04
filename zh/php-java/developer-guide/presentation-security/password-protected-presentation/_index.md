---
title: 在 PHP 中对演示文稿进行密码保护
linktitle: 密码保护
type: docs
weight: 20
url: /zh/php-java/password-protected-presentation/
keywords:
- 受密码保护的演示文稿
- 打开密码
- 加密 PowerPoint
- 解密 PowerPoint
- 验证演示文稿密码
- 检查演示文稿密码
- 打开加密的演示文稿
- 移除加密
- PowerPoint
- PPT
- PPTX
- 演示文稿
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 加密、检测、验证、打开和解密受密码保护的 PowerPoint PPT 和 PPTX 演示文稿。"
---
## **概述**

打开密码会对演示文稿进行加密。必须提供正确的密码才能加载和查看演示文稿内容，因此此保护提供了保密性。

打开密码不同于写保护密码。写保护限制修改，但不加密内容，也不阻止演示文稿的加载。要管理修改演示文稿的密码，请参阅[写保护演示文稿](/slides/zh/php-java/write-protected-presentation/)。

下面的工作流适用于 PPT 和 PPTX 演示文稿。示例在两种格式中均有使用，因为它们的基于文件和基于流的行为很重要。

## **使用打开密码加密演示文稿**

使用[ProtectionManager::encrypt](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#encrypt)分配打开密码。然后使用[Presentation::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#save)保存加密后的演示文稿。

下面的示例加密了一个 PPTX 演示文稿：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **保持文档属性公开**

默认情况下，Aspose.Slides 会在演示文稿加密时包含文档属性。[ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 方法可独立于幻灯片内容加密来控制此行为。如果索引、分类、搜索或文档管理系统必须在不提供打开密码的情况下读取元数据，请在调用[ProtectionManager::encrypt](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#encrypt)前传入`false`。

下面的示例在创建加密的 PPTX 演示文稿的同时，使其内置文档属性保持公开：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $properties = $presentation->getDocumentProperties();
    $properties->setAuthor("Contoso Knowledge Management");
    $properties->setTitle("Quarterly Product Roadmap");
    $properties->setKeywords("roadmap, planning, internal");

    $presentation->getSlides()->get_Item(0)->setName("Encrypted presentation content");
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("public-properties-encrypted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

将`false`传递给[ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties)并不会使幻灯片、母版、布局、形状、媒体或其他演示文稿内容公开。它仅影响文档属性。若要在不加载加密内容的情况下读取这些属性，请参阅[管理演示文稿属性](/slides/zh/php-java/presentation-properties/)。

## **加载加密的演示文稿**

在加载文件时，将[LoadOptions::setPassword](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/#setPassword)设置为打开密码，并将该选项传递给[Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/)。如果需要打开密码但提供的密码缺失或不正确，加载将失败。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # 使用已解密的演示文稿进行操作。
} finally {
    $presentation->dispose();
}
```

## **从演示文稿中移除加密**

使用打开密码加载演示文稿，调用[ProtectionManager::removeEncryption](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#removeEncryption)并保存结果。保存后的演示文稿随后可以在不提供密码的情况下加载。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **在加载前验证打开密码**

使用[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationfactory/#getPresentationInfo)获取[PresentationInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/)，无需创建完整的演示文稿实例。在请求或验证密码之前，检查[PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#isPasswordProtected)。如果存在保护，请使用[PresentationInfo::checkPassword](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#checkPassword)验证提供的值。

### **文件路径工作流**

下面的示例验证 PPTX 文件的打开密码，将验证后的值传递给[LoadOptions::setPassword](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/#setPassword)，然后加载完整的演示文稿：

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$filePath = "protected-presentation.pptx";
$password = "open_password";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);

if (!$presentationInfo->isPasswordProtected()) {
    echo("The presentation does not have an opening password.\n");
} elseif (!$presentationInfo->checkPassword($password)) {
    echo("The opening password is incorrect.\n");
} else {
    $loadOptions = new LoadOptions();
    $loadOptions->setPassword($password);

    $presentation = new Presentation($filePath, $loadOptions);
    try {
        echo("The presentation was validated and loaded successfully.\n");
    } finally {
        $presentation->dispose();
    }
}
```

### **流工作流**

[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationfactory/#getPresentationInfo)的流重载提供相同的工作流。在从该流加载完整演示文稿之前，重置可查找流的位置。

下面的示例使用 PPT 文件：

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$password = "open_password";

$presentationStream = new Java("java.io.FileInputStream", "protected-presentation.ppt");
try {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($presentationStream);

    if (!$presentationInfo->isPasswordProtected()) {
        echo("The presentation does not have an opening password.\n");
    } elseif (!$presentationInfo->checkPassword($password)) {
        echo("The opening password is incorrect.\n");
    } else {
        $presentationStream->getChannel()->position(0);

        $loadOptions = new LoadOptions();
        $loadOptions->setPassword($password);

        $presentation = new Presentation($presentationStream, $loadOptions);
        try {
            echo("The presentation was validated and loaded successfully.\n");
        } finally {
            $presentation->dispose();
        }
    }
} finally {
    $presentationStream->close();
}
```

### **checkPassword 返回值**

仅当演示文稿具有打开密码且提供的密码正确时，[PresentationInfo::checkPassword](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#checkPassword)返回`true`。在以下任意情况下返回`false`：

- 密码不正确。
- 演示文稿没有打开密码。
- 提供的密码为`null`或为空。

对于 PPT 和 PPTX 演示文稿，行为相同。

## **检查已加载的演示文稿是否已加密**

使用正确密码加载演示文稿后，检查[ProtectionManager::isEncrypted](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#isEncrypted)以确认源演示文稿已加密。若要在加载前检测打开密码保护，请使用上述的[PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#isPasswordProtected)。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
    echo("The presentation is encrypted: " . ($isEncrypted ? "true" : "false") . "\n");
} finally {
    $presentation->dispose();
}
```

## **安全建议**

{{% alert color="warning" title="Security" %}}
不要记录打开密码或将其包含在诊断信息中。避免不必要的重复验证尝试，仅在需要时在内存中保留密码，并在立即加载演示文稿时复用成功的验证结果。

即使演示文稿内容已加密，公开的文档属性仍可能泄露作者姓名、标题、主题、关键字、公司信息、评论以及自定义值。请将敏感的元数据与演示文稿一起加密。仅在系统必须在没有打开密码的情况下对文件进行索引、分类、搜索或管理时，才应明确决定将属性保持公开。
{{% /alert %}}

## **在在线对演示文稿进行密码保护**

1. 打开[Aspose.Slides Lock](https://products.aspose.app/slides/zh/lock)应用程序。
2. 选择或上传演示文稿。
3. 输入用于查看保护的密码。
4. 可选地输入用于编辑保护的单独密码。
5. 应用保护并下载生成的文件。

{{% alert color="info" title="See also" %}}
- [写保护演示文稿](/slides/zh/php-java/write-protected-presentation/)
- [PowerPoint 中的数字签名](/slides/zh/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**打开密码和写保护密码有什么区别？**

打开密码会加密演示文稿，并且在加载其内容时是必需的。写保护密码限制修改，但不加密内容。

**我可以在不加载所有幻灯片的情况下验证打开密码吗？**

可以。获取演示文稿信息，检查是否存在打开密码保护，并在创建完整演示文稿实例之前验证密码。

**应用程序可以在没有打开密码的情况下读取元数据吗？**

可以，但仅当演示文稿在加密时禁用了文档属性加密。此时应用程序必须使用在[管理演示文稿属性](/slides/zh/php-java/presentation-properties/)中描述的仅加载文档属性的模式。

**密码检查工作流是否同时支持 PPT 和 PPTX？**

是的。基于文件路径和基于流的密码检测与验证对 PPT 和 PPTX 演示文稿的行为相同。