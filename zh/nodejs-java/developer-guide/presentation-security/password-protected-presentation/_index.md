---
title: 受密码保护的演示文稿
type: docs
weight: 20
url: /zh/nodejs-java/password-protected-presentation/
keywords: "在 JavaScript 中锁定 PowerPoint 演示文稿"
description: "锁定 PowerPoint 演示文稿。JavaScript 中的受密码保护的 PowerPoint"
---

## **关于密码保护**
### **演示文稿的密码保护是如何工作的？**
当您对演示文稿进行密码保护时，即是设置一个密码来强制对演示文稿施加某些限制。要移除这些限制，需要输入密码。受密码保护的演示文稿被视为已锁定的演示文稿。

通常，您可以设置密码来对演示文稿实施以下限制：

- **修改**

  如果您只希望特定用户修改您的演示文稿，可以设置修改限制。此限制阻止人们在未提供密码的情况下修改、变更或复制演示文稿中的内容。

  但是，即使没有密码，用户仍然能够访问并打开文档。在只读模式下，用户可以查看演示文稿中的内容或元素——超链接、动画、效果等——但无法复制项目或保存演示文稿。

- **打开**

  如果您只希望特定用户打开您的演示文稿，可以设置打开限制。此限制阻止人们在未提供密码的情况下查看演示文稿的内容。

  从技术上讲，打开限制也会阻止用户修改演示文稿：当人们无法打开演示文稿时，他们也就无法对其进行修改或更改。

  **注意** 当您对演示文稿进行密码保护以阻止打开时，演示文稿文件会被加密。

## **如何在线为演示文稿设置密码保护**
1. 前往我们的[**Aspose.Slides Lock**](https://products.aspose.app/slides/lock)页面。

   ![todo:image_alt_text](slides-lock.png)

2. 点击 **拖放或上传您的文件**。

3. 在计算机上选择您想要进行密码保护的文件。

4. 输入您用于编辑保护的首选密码；输入您用于查看保护的首选密码。

5. 如果您希望用户将演示文稿视为最终稿，请勾选 **标记为最终版** 复选框。

6. 点击 **立即保护**。

7. 点击 **立即下载**。

## **Aspose.Slides 中的演示文稿密码保护**
**支持的格式**

Aspose.Slides 支持对以下格式的演示文稿进行密码保护、加密及类似操作：

- PPTX 和 PPT - Microsoft PowerPoint 演示文稿
- ODP - OpenDocument 演示文稿
- OTP - OpenDocument 演示文稿模板

**支持的操作**

Aspose.Slides 允许您通过以下方式使用密码保护来防止演示文稿被修改：

- 加密演示文稿
- 为演示文稿设置写保护

**其他操作**

Aspose.Slides 还允许您以以下方式执行其他涉及密码保护和加密的任务：

- 解密演示文稿；打开加密的演示文稿
- 移除加密；禁用密码保护
- 从演示文稿中移除写保护
- 获取加密演示文稿的属性
- 检查演示文稿是否已加密
- 检查演示文稿是否受密码保护

## **加密演示文稿**

您可以通过设置密码来加密演示文稿。随后，要修改已锁定的演示文稿，用户必须提供密码。

要加密或密码保护演示文稿，您需要使用 [ProtectionManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager) 中的 encrypt 方法为演示文稿设置密码。将密码传递给 encrypt 方法后，使用 save 方法保存已加密的演示文稿。

以下示例代码演示了如何加密演示文稿：
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

您可以在演示文稿中添加 “请勿修改” 标记，以告知用户您不希望其对演示文稿进行更改。

**注意** 写保护过程并不加密演示文稿。因此，用户——如果真的想——仍然可以修改演示文稿，但若要保存更改，必须另存为不同的文件名。

要设置写保护，您需要使用 [setWriteProtection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-) 方法。以下示例代码演示了如何为演示文稿设置写保护：
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


## **解密演示文稿；打开加密的演示文稿**

Aspose.Slides 允许您在加载加密文件时传入密码。要解密演示文稿，需调用 [removeEncryption](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) 方法（无参数），随后输入正确的密码以加载演示文稿。

以下示例代码演示了如何解密演示文稿：
```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // 对已解密的演示文稿进行操作
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **移除加密；禁用密码保护**

您可以移除演示文稿的加密或密码保护，从而使用户能够在没有任何限制的情况下访问或修改演示文稿。

要移除加密或密码保护，需调用 [removeEncryption](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) 方法。以下示例代码演示了如何从演示文稿中移除加密：
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

您可以使用 Aspose.Slides 移除演示文稿文件上的写保护。这样，用户即可随意修改且不会收到任何警告。

要移除写保护，请使用 [removeWriteProtection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--) 方法。以下示例代码演示了如何从演示文稿中移除写保护：
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


## **获取加密演示文稿的属性**

通常，用户在获取加密或受密码保护的演示文稿的文档属性时会遇到困难。Aspose.Slides 提供了一种机制，允许您在对演示文稿进行密码保护的同时，仍然让用户访问该演示文稿的属性。

**注意** 当 Aspose.Slides 加密演示文稿时，演示文稿的文档属性默认也会被密码保护。不过，如果您需要在演示文稿加密后仍能访问其属性，Aspose.Slides 允许您实现此需求。

如果您希望用户在您加密的演示文稿中仍能访问属性，可将 [encryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#getEncryptDocumentProperties--) 属性设置为 `true`。以下示例代码演示了如何在加密演示文稿的同时提供访问文档属性的方式：
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **在加载演示文稿之前检查其是否受密码保护**

在加载演示文稿之前，您可能需要检查并确认该演示文稿未被密码保护。这样可以避免在未提供密码的情况下加载受密码保护的演示文稿时出现错误等问题。

以下 JavaScript 代码演示了如何在不加载演示文稿本身的情况下检查其是否受密码保护：
```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```


## **检查演示文稿是否已加密**

Aspose.Slides 允许您检查演示文稿是否已加密。为此，您可以使用 [isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) 属性；如果演示文稿已加密则返回 `true`，否则返回 `false`。

以下示例代码演示了如何检查演示文稿是否已加密：
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


## **检查演示文稿是否受写保护**

Aspose.Slides 允许您检查演示文稿是否受写保护。为此，您可以使用 [isWriteProtected](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) 属性；如果演示文稿受写保护则返回 `true`，否则返回 `false`。

以下示例代码演示了如何检查演示文稿是否受写保护：
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

您可能需要检查并确认已使用特定密码对演示文稿进行保护。Aspose.Slides 提供了验证密码的功能。

以下示例代码演示了如何验证密码：
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


如果演示文稿已使用指定密码加密，则返回 `true`。否则返回 `false`。

{{% alert color="primary" title="另请参阅" %}} 
- [PowerPoint 中的数字签名](/slides/zh/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**Aspose.Slides 支持哪些加密方法？**

Aspose.Slides 支持现代加密方法，包括基于 AES 的算法，能够为您的演示文稿提供高水平的数据安全性。

**尝试打开演示文稿时输入错误密码会怎样？**

如果使用了错误的密码，系统会抛出异常，提示访问演示文稿被拒绝。这有助于防止未授权访问并保护演示文稿内容。

**在使用受密码保护的演示文稿时会有性能影响吗？**

加密和解密过程可能在打开和保存操作时带来轻微的开销。在大多数情况下，这种性能影响很小，不会显著影响演示文稿任务的整体处理时间。