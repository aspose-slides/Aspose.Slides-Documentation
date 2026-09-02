---
title: 使用 PHP 对演示文稿进行密码保护
linktitle: 密码保护
type: docs
weight: 20
url: /zh/php-java/password-protected-presentation/
keywords:
- 锁定 PowerPoint
- 锁定演示文稿
- 解锁 PowerPoint
- 解锁演示文稿
- 保护 PowerPoint
- 保护演示文稿
- 设置密码
- 添加密码
- 加密 PowerPoint
- 加密演示文稿
- 解密 PowerPoint
- 解密演示文稿
- 写保护
- PowerPoint 安全
- 演示文稿安全
- 移除密码
- 移除保护
- 移除加密
- 禁用密码
- 禁用保护
- 移除写保护
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP 轻松锁定和解锁受密码保护的 PowerPoint 和 OpenDocument 演示文稿，确保演示文稿的安全。"
---
## **介绍**

当您为演示文稿设置密码保护时，即为演示文稿设定一个密码，以强制执行某些限制。要解除这些限制，必须输入密码。受密码保护的演示文稿被视为已锁定的演示文稿。

通常，您可以设置密码以对演示文稿施加以下限制：

- **修改**

  如果您只希望特定用户修改您的演示文稿，可以设置修改限制。此限制阻止未经密码的人员对演示文稿进行修改、变更或复制。

  但是，即使没有密码，用户仍然可以访问并打开文档。在只读模式下，用户可以查看演示文稿中的内容或对象——超链接、动画、效果等——但无法复制项目或保存演示文稿。

- **打开**

  如果您只希望特定用户打开您的演示文稿，可以设置打开限制。此限制阻止未经密码的人员查看演示文稿的内容。

  从技术上讲，打开限制同样阻止用户修改演示文稿：当用户无法打开演示文稿时，就无法对其进行修改或更改。

  **注意** 当您为防止打开而对演示文稿设置密码保护时，演示文稿文件会被加密。

## **如何在线对演示文稿进行密码保护**

1. 访问我们的[**Aspose.Slides 锁定**](https://products.aspose.app/slides/zh/lock)页面。

   ![todo:image_alt_text](slides-lock.png)

2. 单击**拖放或上传您的文件**。

3. 在计算机上选择要进行密码保护的文件。

4. 输入用于编辑保护的首选密码；输入用于查看保护的首选密码。

5. 如果您希望用户将演示文稿视为最终版本，请选中**标记为最终**复选框。

6. 单击**立即保护**。

7. 单击**立即下载**。

## **Aspose.Slides 中的演示文稿密码保护**
**支持的格式**

Aspose.Slides 支持对以下格式的演示文稿进行密码保护、加密及类似操作：

- PPTX 和 PPT - Microsoft PowerPoint 演示文稿
- ODP - OpenDocument 演示文稿
- OTP - OpenDocument 演示文稿模板

**支持的操作**

Aspose.Slides 允许您通过以下方式对演示文稿使用密码保护，以防止修改：

- 加密演示文稿
- 为演示文稿设置写保护

**其他操作**

Aspose.Slides 还允许您以以下方式执行涉及密码保护和加密的其他任务：

- 解密演示文稿；打开加密的演示文稿
- 移除加密；禁用密码保护
- 移除演示文稿的写保护
- 获取加密演示文稿的属性
- 检查演示文稿是否已加密
- 检查演示文稿是否已设置密码保护

## **加密演示文稿**

您可以通过设置密码来加密演示文稿。随后，要修改已锁定的演示文稿，用户必须提供密码。

要加密或对演示文稿进行密码保护，需使用 [ProtectionManager](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/) 的 `encrypt` 方法为演示文稿设置密码。将密码传递给 `encrypt` 方法后，使用 `save` 方法保存已加密的演示文稿。

以下示例代码展示了如何加密演示文稿：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **为演示文稿设置写保护**

您可以向演示文稿添加“请勿修改”的标记。这样，您即可告知用户不希望他们对演示文稿进行更改。

**注意** 写保护过程并不对演示文稿进行加密。因此，用户—如果真的想—仍然可以修改演示文稿，但要保存更改，则必须另存为不同的文件名。

要设置写保护，需使用 [setWriteProtection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#setWriteProtection) 方法。以下示例代码展示了如何为演示文稿设置写保护：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setWriteProtection("123123");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **加载加密的演示文稿**

Aspose.Slides 允许您通过传递密码来加载加密文件。要解密演示文稿，需调用 [removeEncryption](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#removeEncryption) 方法且不传入参数。随后，您需要输入正确的密码才能加载演示文稿。

以下示例代码展示了如何解密演示文稿：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # 使用已解密的演示文稿
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **移除演示文稿的加密**

您可以移除演示文稿的加密或密码保护。这样，用户即可在没有任何限制的情况下访问或修改演示文稿。

要移除加密或密码保护，需调用 [removeEncryption](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#removeEncryption) 方法。以下示例代码展示了如何移除演示文稿的加密：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **移除演示文稿的写保护**

您可以使用 Aspose.Slides 移除演示文稿文件的写保护。这样，用户可以随意修改，并且在执行此类操作时不会看到任何警告。

您可以通过调用 [removeWriteProtection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#removeWriteProtection) 方法来移除演示文稿的写保护。以下示例代码展示了如何移除写保护：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **获取加密演示文稿的属性**

通常，用户在检索加密或受密码保护的演示文稿的文档属性时会遇到困难。不过，Aspose.Slides 提供了一种机制，允许您在对演示文稿进行密码保护的同时，仍然保留用户访问其属性的能力。

**注意：** 默认情况下，当 Aspose.Slides 加密演示文稿时，演示文稿的文档属性也会被密码保护。如果您需要在加密后仍然能够访问文档属性，Aspose.Slides 允许您实现此目的。

如果您希望用户在演示文稿加密后仍能访问其属性，请将 `false` 传递给 [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties)。以下示例代码展示了如何在加密演示文稿的同时，仍向用户提供文档属性访问权限：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **仅从加密演示文稿加载文档属性**

若要在不加载幻灯片或其他内容的情况下检查加密演示文稿的元数据，可创建一个 [LoadOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/) 对象，并将 `true` 传递给 [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties)。在此模式下，Aspose.Slides 会忽略密码，仅加载公开可访问的文档属性。

以下代码示例通过 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getDocumentProperties) 读取内置和自定义文档属性：

```php
$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();

    # 读取内置文档属性。
    echo("Title: " . $documentProperties->getTitle() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");

    # 读取自定义文档属性。
    $customPropertyCount = java_values($documentProperties->getCountOfCustomProperties());

    for ($propertyIndex = 0; $propertyIndex < $customPropertyCount; $propertyIndex++) {
        $propertyName = $documentProperties->getCustomPropertyName($propertyIndex);
        $propertyValue = java_values($documentProperties->get_Item($propertyName));

        echo($propertyName . ": " . $propertyValue . "\n");
    }
} finally {
    $presentation->dispose();
}
```

此工作流仅在演示文稿加密时文档属性未被加密（保持公开）时有效。如果文档属性已加密，将 `true` 传递给 [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 会导致异常，因为此模式下密码被忽略。若要访问加密的文档属性或加载包括幻灯片及其他内容的完整演示文稿，请通过 [LoadOptions::setPassword](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/#setPassword) 提供正确的密码。

## **检查演示文稿是否受密码保护**

在加载演示文稿之前，您可能需要检查并确认该演示文稿未被密码保护。这样可以避免在未提供密码的情况下加载受密码保护的演示文稿时出现错误等问题。

以下 PHP 代码展示了如何检查演示文稿是否受密码保护（而不实际加载演示文稿）：

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **检查演示文稿是否已加密**

Aspose.Slides 允许您检查演示文稿是否已加密。为执行此操作，您可以使用 [isEncrypted](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#isEncrypted) 方法，该方法在演示文稿已加密时返回 `true`，未加密时返回 `false`。

以下示例代码展示了如何检查演示文稿是否已加密：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **检查演示文稿是否受写保护**

Aspose.Slides 允许您检查演示文稿是否受写保护。为执行此操作，您可以使用 [isWriteProtected](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#isWriteProtected) 方法，该方法在演示文稿受写保护时返回 `true`，未受写保护时返回 `false`。

以下示例代码展示了如何检查演示文稿是否受写保护：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isWriteProtected();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **验证或确认已使用特定密码**

您可能希望检查并确认已使用特定密码来保护演示文稿。Aspose.Slides 提供了验证密码的方式。

以下示例代码展示了如何验证密码：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # 检查 "pass" 是否匹配
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

如果演示文稿使用指定密码加密，则返回 `true`；否则返回 `false`。

{{% alert color="primary" title="另请参阅" %}} 
- [PowerPoint 中的数字签名](/slides/zh/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**Aspose.Slides 支持哪些加密方法？**

Aspose.Slides 支持包括基于 AES 的现代加密算法，确保演示文稿数据拥有高水平的安全性。

**如果在尝试打开演示文稿时输入了错误的密码会怎样？**

如果使用了错误的密码，将抛出异常，提示访问演示文稿被拒绝。这有助于防止未经授权的访问并保护演示文稿内容。

**在处理受密码保护的演示文稿时是否会产生性能影响？**

加密和解密过程在打开和保存操作时可能会引入轻微的开销。在大多数情况下，这种性能影响很小，不会显著影响演示文稿任务的整体处理时间。