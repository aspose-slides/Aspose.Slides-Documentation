---
title: 在 PHP 中使用密码保护安全演示文稿
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
description: "了解如何使用 Aspose.Slides for PHP 轻松锁定和解锁受密码保护的 PowerPoint 和 OpenDocument 演示文稿。保护您的演示文稿。"
---

## **关于密码保护**
### **演示文稿的密码保护是如何工作的？**
当您对演示文稿进行密码保护时，表示您正在设置一个密码，以对演示文稿实施特定的限制。要取消这些限制，必须输入密码。受密码保护的演示文稿被视为已锁定的演示文稿。

通常，您可以设置密码来对演示文稿强制执行这些限制：

- **修改**

  如果您只希望特定用户修改您的演示文稿，您可以设置修改限制。此限制阻止人们修改、更改或复制演示文稿中的内容（除非提供密码）。

  然而，在这种情况下，即使没有密码，用户仍然可以访问并打开文档。在只读模式下，用户可以查看演示文稿中的内容或元素——超链接、动画、效果等——但不能复制项目或保存演示文稿。

- **打开**

  如果您只希望特定用户打开您的演示文稿，您可以设置打开限制。此限制阻止人们甚至查看演示文稿的内容（除非提供密码）。

  从技术上讲，打开限制也会阻止用户修改演示文稿：当人们无法打开演示文稿时，他们就无法对其进行修改或更改。

  **注意**当您对演示文稿进行密码保护以防止打开时，演示文稿文件会被加密。

## **如何在线对演示文稿进行密码保护**
1. 前往我们的[**Aspose.Slides Lock**](https://products.aspose.app/slides/lock)页面。

   ![todo:image_alt_text](slides-lock.png)

2. 点击**拖放或上传文件**。

3. 在计算机上选择您想要进行密码保护的文件。

4. 输入您用于编辑保护的首选密码；输入您用于查看保护的首选密码。

5. 如果您希望用户将演示文稿视为最终版本，请勾选**标记为最终**复选框。

6. 点击**立即保护**。

7. 点击**立即下载**。

## **Aspose.Slides 中的演示文稿密码保护**
**支持的格式**

Aspose.Slides 支持对以下格式的演示文稿进行密码保护、加密及类似操作：

- PPTX and PPT - Microsoft PowerPoint 演示文稿
- ODP - OpenDocument 演示文稿
- OTP - OpenDocument 演示文稿模板

**支持的操作**

Aspose.Slides 允许您通过以下方式在演示文稿上使用密码保护以防止修改：

- 加密演示文稿
- 设置演示文稿的写保护

**其他操作**

Aspose.Slides 允许您通过以下方式执行其他涉及密码保护和加密的任务：

- 解密演示文稿；打开加密演示文稿
- 移除加密；禁用密码保护
- 从演示文稿中移除写保护
- 获取加密演示文稿的属性
- 检查演示文稿是否已加密
- 检查演示文稿是否受密码保护。

## **加密演示文稿**
您可以通过设置密码来加密演示文稿。随后，若要修改已锁定的演示文稿，用户必须提供密码。

要加密或对演示文稿进行密码保护，您必须使用 encrypt 方法（来自[ProtectionManager](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/)）为演示文稿设置密码。您将密码传递给 encrypt 方法，并使用 save 方法保存已加密的演示文稿。

以下示例代码演示如何加密演示文稿：
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
您可以在演示文稿中添加“请勿修改”标记。这样，您可以告诉用户不希望他们对演示文稿进行更改。

**注意**写保护过程并不会加密演示文稿。因此，用户——如果他们真的想——可以修改演示文稿，但要保存更改，他们必须另存为不同的文件名。

要设置写保护，您必须使用[setWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setWriteProtection)方法。以下示例代码演示如何为演示文稿设置写保护：
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
Aspose.Slides 允许您通过提供密码来加载加密文件。要解密演示文稿，您必须调用[removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#removeEncryption)方法且不带参数。随后，您需要输入正确的密码才能加载演示文稿。

以下示例代码演示如何解密演示文稿：
```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # 使用解密的演示文稿进行工作
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **从演示文稿中移除加密**
您可以移除演示文稿的加密或密码保护。这样，用户即可在没有限制的情况下访问或修改演示文稿。

要移除加密或密码保护，您必须调用[removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#removeEncryption)方法。以下示例代码演示如何从演示文稿中移除加密：
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


## **从演示文稿中移除写保护**
您可以使用 Aspose.Slides 移除演示文稿文件上的写保护。这样，用户可以随意修改——且在执行此类操作时不会收到警告。

您可以通过使用[removeWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#removeWriteProtection)方法来移除演示文稿的写保护。以下示例代码演示如何从演示文稿中移除写保护：
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
通常，用户难以获取加密或受密码保护的演示文稿的文档属性。然而，Aspose.Slides 提供了一种机制，使您能够对演示文稿进行密码保护的同时，仍保留用户访问该演示文稿属性的方式。

**注意**当 Aspose.Slides 对演示文稿进行加密时，演示文稿的文档属性默认也会被密码保护。但如果您需要在演示文稿加密后仍可访问其属性，Aspose.Slides 允许您实现此目的。

如果您希望用户仍能访问您加密的演示文稿的属性，可使用带有 `true` 值的[encryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#getEncryptDocumentProperties)方法。以下示例代码演示如何在加密演示文稿的同时提供用户访问其文档属性的方式：
```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(true);
    $presentation->getProtectionManager()->encrypt("123123");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **检查演示文稿是否受密码保护**
在加载演示文稿之前，您可能希望检查并确认该演示文稿未被密码保护。这样可以避免在未提供密码的情况下加载受密码保护的演示文稿时出现错误及类似问题。

以下 PHP 代码演示如何检查演示文稿是否受密码保护（无需实际加载演示文稿）：
```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```


## **检查演示文稿是否已加密**
Aspose.Slides 允许您检查演示文稿是否已加密。要执行此操作，您可以使用[isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isEncrypted)方法，该方法在演示文稿已加密时返回 `true`，未加密时返回 `false`。

以下示例代码演示如何检查演示文稿是否已加密：
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
Aspose.Slides 允许您检查演示文稿是否受写保护。要执行此操作，您可以使用[isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isWriteProtected)方法，该方法在演示文稿受写保护时返回 `true`，未受写保护时返回 `false`。

以下示例代码演示如何检查演示文稿是否受写保护：
```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isWriteProtected();
  finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **验证或确认已使用特定密码**
您可能希望检查并确认已使用特定密码来保护演示文稿。Aspose.Slides 提供了验证密码的方式。

以下示例代码演示如何验证密码：
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


如果演示文稿已使用指定密码加密，则返回 `true`；否则返回 `false`。

{{% alert color="primary" title="另请参阅" %}} 
- [PowerPoint 中的数字签名](/slides/zh/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**Aspose.Slides 支持哪些加密方法？**
Aspose.Slides 支持包括基于 AES 的算法在内的现代加密方法，确保对您的演示文稿提供高度的数据安全性。

**在尝试打开演示文稿时输入错误密码会怎样？**
如果使用了错误的密码，将抛出异常，提示您已被拒绝访问演示文稿。这有助于防止未授权访问并保护演示文稿内容。

**在使用受密码保护的演示文稿时是否会有性能影响？**
加密和解密过程可能在打开和保存操作时带来轻微的开销。在大多数情况下，这种性能影响很小，不会显著影响演示文稿任务的整体处理时间。