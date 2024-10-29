---
title: 密码保护演示文稿
type: docs
weight: 20
url: /zh/php-java/password-protected-presentation/
keywords: "锁定PowerPoint演示文稿"
description: "锁定PowerPoint演示文稿。密码保护的PowerPoint"
---

## **关于密码保护**
### **演示文稿的密码保护是如何工作的？**
当您对演示文稿进行密码保护时，这意味着您正在设置一个强制性的密码，该密码对演示文稿施加某些限制。要取消这些限制，必须输入密码。一个密码保护的演示文稿被视为一个锁定的演示文稿。

通常，您可以设置密码以对演示文稿施加以下限制：

- **修改**

  如果您只希望某些用户修改您的演示文稿，可以设置修改限制。此限制防止人们修改、改变或复制您演示文稿中的内容（除非他们提供密码）。

  但是，在这种情况下，即使没有密码，用户也可以访问您的文档并打开它。在只读模式下，用户可以查看您演示文稿中的内容或事物——超链接、动画、效果等——但他们无法复制项目或保存演示文稿。

- **打开**

  如果您希望只有某些用户能够打开您的演示文稿，可以设置打开限制。此限制防止人们甚至查看您演示文稿的内容（除非他们提供密码）。

  从技术上讲，打开限制还防止用户修改您的演示文稿：当人们无法打开演示文稿时，他们无法对其进行修改或更改。

  **注意**，当您对演示文稿进行密码保护以防止打开时，演示文稿文件变得加密。

## **如何在线对演示文稿进行密码保护**

1. 转到我们的[**Aspose.Slides Lock**](https://products.aspose.app/slides/lock)页面。

   ![todo:image_alt_text](slides-lock.png)

2. 点击**拖放或上传您的文件**。

3. 在计算机上选择您希望进行密码保护的文件。

4. 输入您希望用于编辑保护的密码； 输入您希望用于查看保护的密码。

5. 如果您希望用户看到您的演示文稿作为最终副本，请勾选**标记为最终**复选框。

6. 点击**立即保护**。

7. 点击**立即下载**。

## **Aspose.Slides中的演示文稿密码保护**
**支持的格式**

Aspose.Slides支持以下格式的演示文稿的密码保护、加密和类似操作：

- PPTX 和 PPT - Microsoft PowerPoint 演示文稿
- ODP - OpenDocument 演示文稿
- OTP - OpenDocument 演示文稿模板

**支持的操作**

Aspose.Slides允许您在演示文稿上使用密码保护以防止以以下方式进行修改：

- 对演示文稿进行加密
- 对演示文稿设置写保护

**其他操作**

Aspose.Slides允许您以以下方式执行与密码保护和加密相关的其他任务：

- 解密演示文稿；打开加密演示文稿
- 移除加密；禁用密码保护
- 从演示文稿中移除写保护
- 获取加密演示文稿的属性
- 检查演示文稿是否加密
- 检查演示文稿是否受到密码保护。

## **加密演示文稿**

您可以通过设置密码来加密演示文稿。然后，要修改被锁定的演示文稿，用户必须提供密码。

要对演示文稿进行加密或密码保护，您必须使用加密方法（来自[IProtectionManager](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager)）为演示文稿设置密码。您将密码传递给加密方法，使用保存方法来保存现在已经加密的演示文稿。

以下示例代码向您展示如何加密演示文稿：

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

## **对演示文稿设置写保护**

您可以在演示文稿中添加一个标记，注明“请勿修改”。这样，您可以告诉用户您不希望他们对演示文稿进行更改。

**注意**，写保护过程并不加密演示文稿。因此，用户——如果他们确实想——可以修改演示文稿，但要保存更改，他们必须创建一个不同名称的演示文稿。

要设置写保护，您必须使用[setWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-)方法。以下示例代码向您展示如何对演示文稿设置写保护：

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

## **解密演示文稿；打开加密演示文稿**

Aspose.Slides允许您通过传递其密码来加载加密文件。要解密演示文稿，您必须调用[removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--)方法，不带参数。然后，您必须输入正确的密码才能加载演示文稿。

以下示例代码向您展示如何解密演示文稿：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # 使用解密的演示文稿
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **移除加密；禁用密码保护**

您可以移除演示文稿上的加密或密码保护。这样，用户可以在没有限制的情况下访问或修改演示文稿。

要移除加密或密码保护，您必须调用[removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--)方法。以下示例代码向您展示如何从演示文稿中移除加密：

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

您可以使用Aspose.Slides从演示文稿文件中移除写保护。这样，用户可以随意进行修改——并且在执行这些操作时不会收到任何警告。

您可以通过使用[removeWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeWriteProtection--)方法来从演示文稿中移除写保护。以下示例代码向您展示如何从演示文稿中移除写保护：

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

通常，用户在获取加密或密码保护演示文稿的文档属性时会遇到困难。然而，Aspose.Slides提供了一种机制，使您能够对演示文稿进行密码保护的同时保留用户访问该演示文稿属性的方式。

**注意**，当Aspose.Slides对演示文稿进行加密时，演示文稿的文档属性默认也会受到密码保护。但是，如果您需要使演示文稿的属性可访问（即使在演示文稿被加密后），Aspose.Slides确实允许您这样做。

如果您希望用户保留访问您加密的演示文稿属性的能力，可以将[encryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#getEncryptDocumentProperties--)属性设置为`true`。以下示例代码向您展示如何在提供用户访问其文档属性的方式的同时加密演示文稿：

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

## **在加载之前检查演示文稿是否受到密码保护**

在加载演示文稿之前，您可能希望检查并确认该演示文稿没有受到密码保护。这样，您可以避免在没有密码时加载密码保护演示文稿时出现的错误和类似问题。

以下PHP代码向您展示如何检查一个演示文稿以查看它是否受到密码保护（而无需加载演示文稿本身）：

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("演示文稿受密码保护： " . $presentationInfo->isPasswordProtected());

```

## **检查演示文稿是否加密**

Aspose.Slides允许您检查演示文稿是否加密。要执行此任务，您可以使用[isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isEncrypted--)属性，如果演示文稿加密则返回`true`，如果演示文稿未加密则返回`false`。

以下示例代码向您展示如何检查演示文稿是否加密：

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

## **检查演示文稿是否受到写保护**

Aspose.Slides允许您检查演示文稿是否受到写保护。要执行此任务，您可以使用[isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isWriteProtected--)属性，如果演示文稿加密则返回`true`，如果演示文稿未加密则返回`false`。

以下示例代码向您展示如何检查演示文稿是否受到写保护：

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

## **验证或确认是否使用特定密码保护演示文稿**

您可能希望检查并确认是否使用特定密码保护演示文档。Aspose.Slides提供了验证密码的手段。

以下示例代码向您展示如何验证密码：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # 检查“pass”是否与之匹配
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

如果演示文稿使用指定密码进行了加密，则返回`true`。否则返回`false`。

{{% alert color="primary" title="另见" %}} 
- [PowerPoint中的数字签名](/slides/zh/net/digital-signature-in-powerpoint/)
{{% /alert %}}