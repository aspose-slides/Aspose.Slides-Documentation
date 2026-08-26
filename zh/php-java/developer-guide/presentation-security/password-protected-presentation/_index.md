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
description: "在 PHP 中使用 Aspose.Slides 对受密码保护的 PowerPoint PPT 和 PPTX 演示文稿进行加密、检测、验证、打开和解密。"
---
## **概述**

打开密码会对演示文稿进行加密。必须提供正确的密码才能加载和查看演示文稿内容，因此此保护提供了机密性。

打开密码不同于写保护密码。写保护限制修改，但不加密内容，也不阻止加载演示文稿。要管理用于修改演示文稿的密码，请参阅[Write-Protect Presentations](/slides/zh/php-java/write-protected-presentation/)。

以下工作流适用于 PPT 和 PPTX 演示文稿。示例在两种格式下展示了文件方式和流方式行为的重要性。

## **使用打开密码加密演示文稿**

使用[ProtectionManager::encrypt](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#encrypt)分配打开密码。然后使用[Presentation::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#save)保存加密后的演示文稿。

以下示例对 PPTX 演示文稿进行加密：

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

## **加载加密的演示文稿**

将[LoadOptions::setPassword](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/#setPassword)设置为打开密码，并在加载文件时将该选项传递给[Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/)。如果需要打开密码但提供的密码缺失或不正确，加载将失败。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # 对已解密的演示文稿进行操作。
} finally {
    $presentation->dispose();
}
```

## **从演示文稿中移除加密**

使用打开密码加载演示文稿，调用[ProtectionManager::removeEncryption](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#removeEncryption)，并保存结果。保存后的演示文稿即可在无需密码的情况下加载。

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

使用[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationfactory/#getPresentationInfo)获取[PresentationInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/)，而无需创建完整的演示文稿实例。在请求或验证密码之前，检查[PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#isPasswordProtected)。如果存在保护，则使用[PresentationInfo::checkPassword](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#checkPassword)验证提供的值。

### **文件路径工作流**

以下示例验证 PPTX 文件的打开密码，将验证后的值传递给[LoadOptions::setPassword](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/#setPassword)，然后加载完整的演示文稿：

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

以下示例使用 PPT 文件：

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

仅当演示文稿具有打开密码且提供的密码正确时，[PresentationInfo::checkPassword](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#checkPassword)才返回 `true`。在以下情况下它返回 `false`：

- 密码不正确。
- 演示文稿没有打开密码。
- 提供的密码为 `null` 或为空。

对于 PPT 和 PPTX 演示文稿，行为相同。

## **检查已加载的演示文稿是否已加密**

使用正确密码加载演示文稿后，检查[ProtectionManager::isEncrypted](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#isEncrypted)以确认源演示文稿已加密。要在加载前检测打开密码保护，请使用如上所示的[PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#isPasswordProtected)。

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
不要记录打开密码或将其包含在诊断信息中。避免不必要的重复验证尝试，仅在需要时在内存中保留密码，并在立即加载演示文稿时重用成功的验证结果。
{{% /alert %}}

## **在线对演示文稿进行密码保护**

1. 打开[Aspose.Slides Lock](https://products.aspose.app/slides/zh/lock)应用程序。
2. 选择或上传演示文稿。
3. 输入用于查看保护的密码。
4. 可选地输入用于编辑保护的另一个密码。
5. 应用保护并下载生成的文件。

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/zh/php-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/zh/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**打开密码和写保护密码有什么区别？**

打开密码会加密演示文稿，并且必须提供才能加载其内容。写保护密码限制修改，但不加密内容。

**我可以在不加载所有幻灯片的情况下验证打开密码吗？**

可以。获取演示文稿信息，检查是否存在打开密码保护，然后在创建完整演示文稿实例之前验证密码。

**密码检查工作流是否同时支持 PPT 和 PPTX？**

支持。文件路径和基于流的密码检测与验证在 PPT 和 PPTX 演示文稿中行为相同。