---
title: 密码保护的演示文稿
type: docs
weight: 20
url: /zh/java/password-protected-presentation/
keywords: "在Java中锁定PowerPoint演示文稿"
description: "锁定PowerPoint演示文稿。Java中的密码保护PowerPoint"
---

## **关于密码保护**
### **演示文稿的密码保护是如何工作的？**
当您密码保护演示文稿时，这意味着您正在设置一个密码，以实施对演示文稿的某些限制。要解除这些限制，必须输入密码。密码保护的演示文稿被认为是锁定的演示文稿。

通常，您可以设置密码以对演示文稿实施这些限制：

- **修改**

  如果您希望只有特定用户可以修改您的演示文稿，您可以设置修改限制。这里的限制防止人们修改、改变或复制您演示文稿中的内容（除非他们提供密码）。

  然而，在这种情况下，即使没有密码，用户也能够访问您的文档并打开它。在只读模式下，用户可以查看您的演示文稿中的内容或事物——超链接、动画、效果等——但他们无法复制项目或保存演示文稿。

- **打开**

  如果您希望只有特定用户可以打开您的演示文稿，您可以设置打开限制。这里的限制防止人们甚至查看您演示文稿的内容（除非他们提供密码）。

  从技术上讲，打开限制也阻止用户修改您的演示文稿：当人们无法打开演示文稿时，他们无法对其进行修改或更改。

  **注意**，当您为防止打开而密码保护演示文稿时，演示文稿文件会被加密。

## **如何在线密码保护演示文稿**

1. 访问我们的 [**Aspose.Slides锁定**](https://products.aspose.app/slides/lock) 页面。

   ![todo:image_alt_text](slides-lock.png)

2. 点击 **拖放或上传您的文件**。

3. 在您的计算机上选择您想要密码保护的文件。

4. 输入您希望用于编辑保护的密码； 输入您希望用于查看保护的密码。

5. 如果您希望用户看到您的演示文稿作为最终副本，请勾选 **标记为最终** 复选框。

6. 点击 **立即保护。**

7. 点击 **立即下载。**

## **Aspose.Slides中的演示文稿密码保护**
**支持的格式**

Aspose.Slides支持以下格式演示文稿的密码保护、加密和类似操作：

- PPTX 和 PPT - Microsoft PowerPoint 演示文稿
- ODP - OpenDocument 演示文稿
- OTP - OpenDocument 演示文稿模板

**支持的操作**

Aspose.Slides允许您在演示文稿上使用密码保护，以防止以下方式的修改：

- 加密演示文稿
- 对演示文稿设置写保护

**其他操作**

Aspose.Slides允许您以以下方式执行其他与密码保护和加密相关的任务：

- 解密演示文稿；打开加密的演示文稿
- 删除加密；禁用密码保护
- 从演示文稿中删除写保护
- 获取加密演示文稿的属性
- 检查演示文稿是否被加密
- 检查演示文稿是否被密码保护。

## **加密演示文稿**

您可以通过设置密码来加密演示文稿。然后，要修改锁定的演示文稿，用户必须提供密码。

要加密或密码保护演示文稿，您必须使用 encrypt 方法（来自 [IProtectionManager](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager)）为演示文稿设置密码。您将密码传递给 encrypt 方法，并使用 save 方法来保存现在已加密的演示文稿。

以下示例代码显示了如何加密演示文稿：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **为演示文稿设置写保护**

您可以在演示文稿中添加一个标记，表明“请勿修改”。这样，您就可以告诉用户您不希望他们对演示文稿进行更改。

**注意**，写保护过程不会加密演示文稿。因此，如果用户确实想要，他们可以修改演示文稿，但要保存更改，他们必须创建一个具有不同名称的演示文稿。

要设置写保护，您必须使用 [setWriteProtection](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) 方法。以下示例代码显示了如何为演示文稿设置写保护：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **解密演示文稿；打开加密演示文稿**

Aspose.Slides允许您通过传递其密码来加载加密的文件。要解密演示文稿，您必须调用 [removeEncryption](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#removeEncryption--) 方法，无需参数。然后，您必须输入正确的密码才能加载演示文稿。

以下示例代码显示了如何解密演示文稿：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // 与解密的演示文稿一起工作
} finally {
    if (presentation != null) presentation.dispose();
}
}
```

## **删除加密；禁用密码保护**

您可以删除演示文稿上的加密或密码保护。这样，用户就可以在没有限制的情况下访问或修改演示文稿。

要删除加密或密码保护，您必须调用 [removeEncryption](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#removeEncryption--) 方法。以下示例代码显示了如何从演示文稿中删除加密：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **从演示文稿中删除写保护**

您可以使用Aspose.Slides从演示文稿文件中删除写保护。这样，用户可以随意修改——而在执行此类任务时不会收到任何警告。

您可以通过使用 [removeWriteProtection](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) 方法来删除演示文稿的写保护。以下示例代码显示了如何从演示文稿中删除写保护：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **获取加密演示文稿的属性**

通常，用户在获取加密或密码保护演示文稿的文档属性时会遇到困难。然而，Aspose.Slides提供了一种机制，允许您在密码保护演示文稿的同时保留用户访问该演示文稿属性的手段。

**注意**，当Aspose.Slides加密演示文稿时，演示文稿的文档属性也默认会被密码保护。但是，如果您需要使演示文稿的属性可访问（即使在演示文稿被加密之后），Aspose.Slides允许您准确地做到这一点。

如果您希望用户保留访问您加密演示文稿属性的能力，您可以将 [encryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) 属性设置为 `true`。以下示例代码显示了如何加密演示文稿，同时提供用户访问其文档属性的手段：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **在加载之前检查演示文稿是否被密码保护**

在加载演示文稿之前，您可能希望检查并确认该演示文稿是否没有被密码保护。这样，您就可以避免在没有其密码的情况下加载密码保护演示文稿时出现的错误和类似问题。

以下Java代码显示如何检查演示文稿是否被密码保护（而不加载演示文稿本身）：

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("演示文稿受到密码保护：" + presentationInfo.isPasswordProtected());
```

## **检查演示文稿是否被加密**

Aspose.Slides允许您检查演示文稿是否被加密。要执行此任务，您可以使用 [isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#isEncrypted--) 属性，如果演示文稿被加密，则返回 `true`，如果演示文稿没有被加密，则返回 `false`。

以下示例代码显示如何检查演示文稿是否被加密：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **检查演示文稿是否受到写保护**

Aspose.Slides允许您检查演示文稿是否受到写保护。要执行此任务，您可以使用 [isWriteProtected](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#isWriteProtected--) 属性，如果演示文稿受到写保护，则返回 `true`，如果演示文稿没有受到保护，则返回 `false`。

以下示例代码显示如何检查演示文稿是否受到写保护：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **验证或确认特定密码是否用于保护演示文稿**

您可能希望检查并确认是否使用特定密码保护演示文稿文档。Aspose.Slides提供了验证密码的手段。

以下示例代码显示如何验证密码：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // 检查“pass”是否与之匹配
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

如果演示文稿使用指定的密码进行了加密，则返回 `true`。否则，返回 `false`。

{{% alert color="primary" title="另请参见" %}}
- [PowerPoint中的数字签名](/slides/zh/net/digital-signature-in-powerpoint/)
{{% /alert %}}