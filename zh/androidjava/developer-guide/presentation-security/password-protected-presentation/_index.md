---
title: 密码保护演示文稿
type: docs
weight: 20
url: /androidjava/password-protected-presentation/
keywords: "在 Java 中锁定 PowerPoint 演示文稿"
description: "锁定 PowerPoint 演示文稿。Java 中的密码保护 PowerPoint"
---

## **关于密码保护**
### **演示文稿的密码保护是如何工作的？**
当你给演示文稿设置密码保护时，这意味着你正在设置一个密码，以强制在演示文稿上施加某些限制。要解除这些限制，必须输入密码。一个密码保护的演示文稿被视为一个锁定的演示文稿。

通常，你可以设置一个密码来强制这些限制在演示文稿上：

- **修改**

  如果你只希望某些用户修改你的演示文稿，可以设置修改限制。此限制会防止人们修改、更改或复制你演示文稿中的内容（除非他们提供密码）。

  然而，在这种情况下，即使没有密码，用户也仍然能够访问你的文档并打开它。在只读模式下，用户可以查看演示文稿中的内容或事物——超链接、动画、效果等，但他们无法复制项目或保存演示文稿。

- **打开**

  如果你只希望某些用户打开你的演示文稿，可以设置打开限制。此限制会防止人们甚至查看你的演示文稿的内容（除非他们提供密码）。

  从技术上讲，打开限制也防止用户修改你的演示文稿：当人们无法打开演示文稿时，他们不能修改或更改它。
  
  **注意**，当你对演示文稿设置密码以防止打开时，演示文稿文件变得加密。

## **如何在线给演示文稿设置密码保护**

1. 转到我们的 [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) 页面。

   ![todo:image_alt_text](slides-lock.png)

2. 点击 **拖动或上传你的文件**。

3. 选择你要在计算机上设置密码保护的文件。

4. 输入你希望的编辑保护密码；输入你希望的查看保护密码。

5. 如果你希望用户将演示文稿视为最终副本，请勾选 **标记为最终** 复选框。

6. 点击 **立即保护**。

7. 点击 **立即下载**。

## **Aspose.Slides 中的演示文稿密码保护**
**支持的格式**

Aspose.Slides 支持这些格式的演示文稿的密码保护、加密和类似操作：

- PPTX 和 PPT - Microsoft PowerPoint 演示文稿
- ODP - OpenDocument 演示文稿
- OTP - OpenDocument 演示文稿模板

**支持的操作**

Aspose.Slides 允许你在演示文稿上使用密码保护来防止以下方式的修改：

- 加密演示文稿
- 设置演示文稿的写保护

**其他操作**

Aspose.Slides 允许你以以下方式执行其他与密码保护和加密相关的任务：

- 解密演示文稿；打开加密的演示文稿
- 移除加密；禁用密码保护
- 从演示文稿中移除写保护
- 获取加密演示文稿的属性
- 检查演示文稿是否加密
- 检查演示文稿是否受到密码保护。

## **加密演示文稿**

你可以通过设置密码来加密演示文稿。然后，用户必须提供密码才能修改锁定的演示文稿。

要加密或密码保护演示文稿，你必须使用 encrypt 方法（来自 [IProtectionManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager)）为演示文稿设置密码。你将密码传递给 encrypt 方法，并使用 save 方法保存现在已加密的演示文稿。

下面的示例代码演示了如何加密演示文稿：

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

你可以在演示文稿上添加一个标记，说明“禁止修改”。这样，你可以告诉用户，你不希望他们对演示文稿进行更改。

**注意**，写保护过程并不会加密演示文稿。因此，用户——如果他们真的想要——可以修改演示文稿，但要保存更改，他们必须创建一个不同名称的演示文稿。

要设置写保护，你必须使用 [setWriteProtection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) 方法。下面的示例代码演示了如何为演示文稿设置写保护：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **解密演示文稿；打开加密的演示文稿**

Aspose.Slides 允许你通过传递密码来加载加密的文件。要解密演示文稿，你必须调用 [removeEncryption](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) 方法，而不带参数。然后，你必须输入正确的密码才能加载演示文稿。

下面的示例代码演示了如何解密演示文稿：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // 对解密的演示文稿进行操作
} finally {
    if (presentation != null) presentation.dispose();
}
}
```

## **移除加密；禁用密码保护**

你可以移除演示文稿上的加密或密码保护。这样，用户就可以不受限制地访问或修改演示文稿。

要移除加密或密码保护，你必须调用 [removeEncryption](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) 方法。下面的示例代码演示了如何从演示文稿中移除加密：

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

## **从演示文稿中移除写保护**

你可以使用 Aspose.Slides 从演示文稿文件中移除写保护。这样，用户可以随意修改——并且在执行这些操作时不会收到任何警告。

你可以通过使用 [removeWriteProtection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) 方法从演示文稿中移除写保护。下面的示例代码演示了如何从演示文稿中移除写保护：

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

通常，用户在获取加密或密码保护的演示文稿的文档属性时会遇到困难。然而，Aspose.Slides 提供了一种机制，允许你在密码保护演示文稿的同时保留用户访问该演示文稿属性的方法。

**注意**，当 Aspose.Slides 加密演示文稿时，演示文稿的文档属性默认也会受到密码保护。但如果你需要使演示文稿的属性可访问（即使在演示文稿被加密后），Aspose.Slides 允许你做到这一点。

如果你希望用户保留访问你加密演示文稿属性的能力，你可以将 [encryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) 属性设置为 `true`。下面的示例代码演示了如何在提供用户访问其文档属性的方法的同时加密演示文稿：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **在加载演示文稿前检查它是否受到密码保护**

在加载演示文稿之前，你可能希望检查并确认该演示文稿未受到密码保护。这样，你可以避免错误和类似的问题，当尝试加载一个密码保护的演示文稿时没有提供其密码。

以下 Java 代码演示了如何检查演示文稿以查看其是否受到密码保护（而不加载演示文稿本身）：

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("演示文稿受密码保护：" + presentationInfo.isPasswordProtected());
```

## **检查演示文稿是否加密**

Aspose.Slides 允许你检查演示文稿是否加密。要执行此任务，你可以使用 [isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) 属性，该属性返回 `true` 如果演示文稿已加密，返回 `false` 如果演示文稿没有加密。

下面的示例代码显示了如何检查演示文稿是否被加密：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **检查演示文稿是否受写保护**

Aspose.Slides 允许你检查演示文稿是否受写保护。要执行此任务，你可以使用 [isWriteProtected](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) 属性，该属性返回 `true` 如果演示文稿受写保护，返回 `false` 如果演示文稿没有写保护。

下面的示例代码显示了如何检查演示文稿是否受到写保护：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isWriteProtected = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **验证或确认特定密码是否用于保护演示文稿**

你可能希望检查并确认是否已使用特定密码来保护演示文档。Aspose.Slides 提供了验证密码的方法。

下面的示例代码演示了如何验证密码：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // 检查 "pass" 是否匹配
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

如果演示文稿已使用指定的密码加密，则返回 `true`。否则，返回 `false`。

{{% alert color="primary" title="另见" %}} 
- [PowerPoint 中的数字签名](/slides/net/digital-signature-in-powerpoint/)
{{% /alert %}}