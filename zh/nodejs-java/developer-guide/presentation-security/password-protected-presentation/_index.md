---
title: 使用 JavaScript 对演示文稿进行密码保护
linktitle: 密码保护
type: docs
weight: 20
url: /zh/nodejs-java/password-protected-presentation/
keywords:
- 锁定 PowerPoint
- 锁定 演示文稿
- 解锁 PowerPoint
- 解锁 演示文稿
- 保护 PowerPoint
- 保护 演示文稿
- 设置密码
- 添加密码
- 加密 PowerPoint
- 加密 演示文稿
- 解密 PowerPoint
- 解密 演示文稿
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
- Node.js
- JavaScript
- Aspose.Slides
description: "通过 Aspose.Slides for Node.js（使用 Java），轻松锁定和解锁受密码保护的 PowerPoint 和 OpenDocument 演示文稿。保护您的演示文稿。"
---
## **简介**

当您对演示文稿进行密码保护时，意味着您设置了一个密码来强制对演示文稿施加某些限制。要取消这些限制，需要输入密码。受密码保护的演示文稿被视为已锁定的演示文稿。

通常，您可以设置密码以在演示文稿上强制这些限制：

- **修改**

  如果您希望仅特定用户修改您的演示文稿，您可以设置修改限制。此限制阻止他人在未提供密码的情况下修改、变更或复制演示文稿中的内容。

  然而，在此情况下，即使没有密码，用户仍然能够访问您的文档并打开它。在只读模式下，用户可以查看演示文稿中的内容或元素——超链接、动画、效果等——但无法复制项目或保存演示文稿。

- **打开**

  如果您希望仅特定用户能够打开您的演示文稿，您可以设置打开限制。此限制阻止他人查看演示文稿的内容，除非提供密码。

  从技术上讲，打开限制同样阻止用户对演示文稿进行修改：当人们无法打开演示文稿时，也就无法对其进行修改或更改。

  **注意** 当您通过密码保护防止打开演示文稿时，演示文稿文件会被加密。

## **如何在线对演示文稿进行密码保护**

1. 访问我们的[**Aspose.Slides 锁定**](https://products.aspose.app/slides/zh/lock)页面。 

   ![todo:image_alt_text](slides-lock.png)

2. 单击**拖放或上传文件**。

3. 在计算机上选择您想要进行密码保护的文件。 

4. 输入您用于编辑保护的首选密码；输入您用于查看保护的首选密码。 

5. 如果您希望用户将演示文稿视为最终版本，请勾选**标记为最终**复选框。

6. 单击**立即保护**。 

7. 单击**立即下载**。

## **Aspose.Slides 中的演示文稿密码保护**
**支持的格式**

Aspose.Slides 支持在以下格式的演示文稿上进行密码保护、加密及类似操作：

- PPTX 和 PPT - Microsoft PowerPoint 演示文稿 
- ODP - OpenDocument 演示文稿 
- OTP - OpenDocument 演示文稿模板 

**支持的操作**

Aspose.Slides 允许您通过以下方式对演示文稿使用密码保护以防止修改：

- 加密演示文稿
- 为演示文稿设置写保护

**其他操作**

Aspose.Slides 允许您通过以下方式执行其他涉及密码保护和加密的任务：

- 解密演示文稿；打开已加密的演示文稿
- 移除加密；禁用密码保护
- 移除演示文稿的写保护
- 获取已加密演示文稿的属性
- 检查演示文稿是否已加密
- 检查演示文稿是否已设置密码保护。

## **加密演示文稿**

您可以通过设置密码来加密演示文稿。随后，若要修改已锁定的演示文稿，用户必须提供密码。

要加密或对演示文稿进行密码保护，您需要使用 encrypt 方法（来自[ProtectionManager](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ProtectionManager)）为演示文稿设置密码。将密码传递给 encrypt 方法，然后使用 save 方法保存已加密的演示文稿。

以下示例代码演示如何加密演示文稿：

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **为演示文稿设置写保护**

您可以在演示文稿上添加“请勿修改”的标记。这样，您可以告知用户不希望他们对演示文稿进行更改。  

**注意** 写保护过程并不会加密演示文稿。因此，用户（如果真的想）仍然可以修改演示文稿，但要保存更改，必须另存为不同名称的演示文稿。 

要设置写保护，您需要使用[setWriteProtection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-)方法。以下示例代码演示如何为演示文稿设置写保护：

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **解密演示文稿；打开已加密的演示文稿**

Aspose.Slides 允许您通过传递密码加载加密文件。要解密演示文稿，您需要调用[removeEncryption](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--)方法（不带参数）。随后需要输入正确的密码才能加载演示文稿。

以下示例代码演示如何解密演示文稿： 

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // 使用已解密的演示文稿进行操作
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **移除加密；禁用密码保护**

您可以移除演示文稿的加密或密码保护。这样，用户即可在无任何限制的情况下访问或修改演示文稿。 

要移除加密或密码保护，您需要调用[removeEncryption](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--)方法。以下示例代码演示如何从演示文稿中移除加密：

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **从演示文稿中移除写保护**

您可以使用 Aspose.Slides 移除演示文稿文件上的写保护。这样，用户可以随意修改，并且在执行此类操作时不会收到警告。

您可以通过使用[removeWriteProtection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--)方法来移除演示文稿的写保护。以下示例代码演示如何从演示文稿中移除写保护：

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **获取已加密演示文稿的属性**

通常，用户难以获取已加密或受密码保护的演示文稿的文档属性。然而，Aspose.Slides 提供了一种机制，使您在对演示文稿进行密码保护的同时，仍然能够让用户访问其属性。

**注意：** 默认情况下，Aspose.Slides 加密演示文稿时，其文档属性也会受到密码保护。如果您需要在加密后仍然能够访问文档属性，Aspose.Slides 可以实现此功能。

如果您希望用户仍能访问已加密演示文稿的属性，请在[ProtectionManager](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/protectionmanager/)上将 `setEncryptDocumentProperties` 设为 `false`。以下示例代码演示如何在加密演示文稿的同时仍让用户能够访问其文档属性：

```javascript
const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **仅加载已加密演示文稿的文档属性**

若要在不加载幻灯片或其他内容的情况下检查已加密演示文稿的元数据，请创建一个[LoadOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/)对象，并将 `setOnlyLoadDocumentProperties` 设为 `true`。在此模式下，Aspose.Slides 会忽略密码，仅加载公开可访问的文档属性。

以下代码示例通过[Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/)的 `getDocumentProperties` 读取内置和自定义文档属性：

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new aspose.slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();

    // 读取内置文档属性。
    console.log("Title: " + documentProperties.getTitle());
    console.log("Author: " + documentProperties.getAuthor());

    // 读取自定义文档属性。
    const customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (let propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        const propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

此工作流仅在演示文稿加密时文档属性保持未加密（公开）时有效。如果文档属性已加密，将 `true` 传递给 `LoadOptions.setOnlyLoadDocumentProperties` 会导致异常，因为该模式下密码被忽略。若要访问加密的文档属性或加载包括幻灯片及其他内容的完整演示文稿，请通过[LoadOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/)的 `setPassword` 提供正确的密码。

## **在加载演示文稿前检查是否已设置密码保护**

在加载演示文稿之前，您可能希望检查并确认该演示文稿未被密码保护。这样可以避免在未提供密码的情况下加载受密码保护的演示文稿时出现错误等问题。

以下 JavaScript 代码演示如何检查演示文稿是否受密码保护（无需实际加载演示文稿）：

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **检查演示文稿是否已加密**

Aspose.Slides 允许您检查演示文稿是否已加密。您可以使用[isEncrypted](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--)属性，如果演示文稿已加密则返回 `true`，否则返回 `false`。

以下示例代码演示如何检查演示文稿是否已加密：

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **检查演示文稿是否已写保护**

Aspose.Slides 允许您检查演示文稿是否已写保护。您可以使用[isWriteProtected](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--)属性，如果演示文稿已写保护则返回 `true`，否则返回 `false`。

以下示例代码演示如何检查演示文稿是否已写保护：

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **验证或确认已使用特定密码保护演示文稿**

您可能希望检查并确认已使用特定密码来保护演示文稿。Aspose.Slides 提供了验证密码的功能。 

以下示例代码演示如何验证密码：

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // 检查 "pass" 是否匹配
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

如果演示文稿已使用指定密码加密，则返回 `true`；否则返回 `false`。 

{{% alert color="primary" title="另请参见" %}} 
- [Digital Signature in PowerPoint](/slides/zh/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides 支持哪些加密方法？**

Aspose.Slides 支持包括基于 AES 的算法在内的现代加密方法，确保为您的演示文稿提供高水平的数据安全性。

**尝试打开演示文稿时输入错误密码会怎样？**

如果使用错误密码，系统会抛出异常，提示访问演示文稿被拒绝。这有助于防止未授权访问并保护演示文稿内容。

**在处理受密码保护的演示文稿时是否会有性能影响？**

加密和解密过程可能会在打开和保存操作时带来轻微的开销。在大多数情况下，这种性能影响很小，对演示文稿任务的整体处理时间影响不大。