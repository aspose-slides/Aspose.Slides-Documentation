---
title: 在 PHP 中写保护演示文稿
linktitle: 写保护
type: docs
weight: 25
url: /zh/php-java/write-protected-presentation/
keywords:
- 写保护
- 写保护 PowerPoint
- 修改密码
- 限制演示文稿编辑
- 移除写保护
- 验证修改密码
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP 在 PowerPoint PPT 和 PPTX 演示文稿中设置、检测、验证和移除写保护密码。"
---
## **介绍**

写保护密码限制对演示文稿的修改，但不加密其内容。用户可以在不提供密码的情况下加载并查看受写保护的演示文稿。根据具体应用，他们甚至可能编辑内容并另存为其他名称，因此写保护不应被视为保密机制。

打开密码的作用不同：它会加密演示文稿，并且在加载内容时必须提供。要加密演示文稿或验证打开密码，请参阅[密码保护演示文稿](/slides/zh/php-java/password-protected-presentation/)。

本文档中的工作流适用于 PPT 和 PPTX 演示文稿。示例使用 PPTX 文件；保存为 PPT 时，请使用`.ppt`扩展名和对应的 PPT 保存格式。

## **在演示文稿上设置写保护**

使用[ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#setWriteProtection)为演示文稿分配修改密码。保存演示文稿后会持久化该保护设置。

下面的示例在 PPTX 演示文稿上设置写保护：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->setWriteProtection("modify_password");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **加载受写保护的演示文稿**

由于写保护不加密演示文稿内容，加载演示文稿时不需要密码。密码仅在验证对受保护演示文稿的修改授权时才相关。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

不要将写保护密码传递给[LoadOptions::setPassword](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/#setPassword)。该方法接受用于加密内容的打开密码。如果演示文稿同时具有两种保护类型，请在加载时提供打开密码，并单独处理写保护密码。

## **从演示文稿中移除写保护**

使用[ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#removeWriteProtection)移除修改限制，然后保存演示文稿。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **检查演示文稿是否受写保护**

要在不创建完整[Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/)实例的情况下检查文件，请调用[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationfactory/#getPresentationInfo)并检查[PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#isWriteProtected)。该方法使用[NullableBool](https://reference.aspose.com/slides/zh/php-java/aspose.slides/nullablebool/)，在检测到写保护时返回`NullableBool::True`。

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() == NullableBool::True) {
    echo("The presentation is write protected.\n");
} else {
    echo("Write protection was not detected.\n");
}
```

[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationfactory/#getPresentationInfo)的流重载同样提供以流形式提供的演示文稿的相同信息。

## **验证写保护密码**

使用[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#checkWriteProtection)在不加载完整演示文稿的情况下验证修改密码。请先检查[PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#isWriteProtected)，以便仅在存在写保护时请求或验证密码。

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() != NullableBool::True) {
    echo("The presentation is not write protected.\n");
} elseif ($presentationInfo->checkWriteProtection("modify_password")) {
    echo("The write-protection password is correct.\n");
} else {
    echo("The write-protection password is incorrect.\n");
}
```

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#checkWriteProtection)仅验证写保护密码。它不验证打开密码，也不判断是否可以加载加密内容。相反，[PresentationInfo::checkPassword](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#checkPassword)仅验证打开密码。如果已经加载了完整演示文稿，[ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#checkWriteProtection)通过其保护管理器提供等效的写保护检查。

在生产应用中，请勿记录密码或在诊断信息中包含密码。避免不必要的重复验证，并且仅在需要时在内存中保留密码。

{{% alert color="info" title="另见" %}}
- [密码保护演示文稿](/slides/zh/php-java/password-protected-presentation/)
- [只读演示文稿](/slides/zh/php-java/read-only-presentation/)
- [PowerPoint 中的数字签名](/slides/zh/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**写保护会加密演示文稿吗？**

否。它限制修改，但仍然可以加载并查看演示文稿内容。

**打开演示文稿是否需要写保护密码？**

否。仅需要打开密码来加载加密的演示文稿内容。

**演示文稿可以同时拥有打开密码和写保护密码吗？**

可以。通过加载选项提供打开密码以打开加密的演示文稿，并在需要修改授权时单独验证写保护密码。