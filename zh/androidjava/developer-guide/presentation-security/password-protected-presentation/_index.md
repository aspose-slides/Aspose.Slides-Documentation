---
title: 在 Android 上使用密码保护演示文稿
linktitle: 密码保护
type: docs
weight: 20
url: /zh/androidjava/password-protected-presentation/
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
- Android
- Java
- Aspose.Slides
description: "通过 Java 使用 Aspose.Slides for Android，轻松锁定和解锁受密码保护的 PowerPoint 和 OpenDocument 演示文稿。确保您的演示文稿安全。"
---
## **简介**

当您为演示文稿设置密码保护时，意味着您正在为演示文稿设置一个密码，以强制执行某些限制。要解除这些限制，必须输入密码。受密码保护的演示文稿被视为已锁定的演示文稿。

通常，您可以设置密码来对演示文稿施加以下限制：

- **修改**

  如果您只希望特定用户修改演示文稿，可以设置修改限制。此限制阻止他人在未提供密码的情况下修改、改变或复制演示文稿中的内容。

  但是，在这种情况下，即使没有密码，用户仍然可以访问并打开文档。在只读模式下，用户可以查看内容——包括超链接、动画、效果等——但不能复制项目或保存演示文稿。

- **打开**

  如果您只希望特定用户打开演示文稿，可以设置打开限制。此限制阻止他人在未提供密码的情况下查看演示文稿的内容。

  从技术上讲，打开限制同样会阻止用户修改演示文稿：当用户无法打开演示文稿时，他们也就无法对其进行修改或更改。

  **注意** 当您通过密码保护来阻止打开时，演示文稿文件会被加密。

## **Aspose.Slides 中的演示文稿密码保护**
**支持的格式**

Aspose.Slides 支持对以下格式的演示文稿进行密码保护、加密等操作：

- PPTX 和 PPT - Microsoft PowerPoint 演示文稿
- ODP - OpenDocument 演示文稿
- OTP - OpenDocument 演示文稿模板

**支持的操作**

Aspose.Slides 允许您通过以下方式对演示文稿使用密码保护以防止修改：

- 加密演示文稿
- 为演示文稿设置写保护

**其他操作**

Aspose.Slides 还允许您以以下方式执行其他与密码保护和加密相关的任务：

- 解密演示文稿；打开加密的演示文稿
- 移除加密；禁用密码保护
- 移除演示文稿的写保护
- 获取加密演示文稿的属性
- 检查演示文稿是否被加密
- 检查演示文稿是否受到密码保护

## **加密演示文稿**

您可以通过设置密码来加密演示文稿。随后，要修改已锁定的演示文稿，用户必须提供密码。

要加密或对演示文稿设置密码保护，必须使用加密方法（来自[IProtectionManager](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IProtectionManager)）为演示文稿设置密码。将密码传递给 encrypt 方法，并使用 save 方法保存已加密的演示文稿。

以下示例代码演示了如何加密演示文稿：

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

您可以在演示文稿上添加 “禁止修改” 标记，从而告知用户不要对演示文稿进行更改。

**注意** 写保护过程并不会对演示文稿进行加密。因此，用户如果真的想修改演示文稿，仍然可以，只是保存更改时必须另存为不同的文件名。

要设置写保护，必须使用[setWriteProtection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-)方法。以下示例代码演示了如何为演示文稿设置写保护：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **加载加密的演示文稿**

Aspose.Slides 允许您通过传入密码来加载加密文件。要解密演示文稿，需要调用[removeEncryption](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--)方法（不带参数）。随后，您必须输入正确的密码才能加载演示文稿。

以下示例代码演示了如何解密演示文稿：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // 处理已解密的演示文稿
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **移除演示文稿的加密**

您可以移除演示文稿的加密或密码保护，从而使用户可以在没有限制的情况下访问或修改演示文稿。

要移除加密或密码保护，需要调用[removeEncryption](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--)方法。以下示例代码演示了如何从演示文稿中移除加密：

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

## **移除演示文稿的写保护**

您可以使用 Aspose.Slides 移除演示文稿文件上的写保护。这样，用户可以随意修改，并且在执行此类操作时不会收到任何警告。

可以通过调用[removeWriteProtection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--)方法来移除写保护。以下示例代码演示了如何从演示文稿中移除写保护：

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

通常，用户很难检索加密或受密码保护的演示文稿的文档属性。不过，Aspose.Slides 提供了一种机制，允许您在对演示文稿进行密码保护的同时，仍然让用户访问其属性。

**注意：** 默认情况下，Aspose.Slides 加密演示文稿时，演示文稿的文档属性也会受到密码保护。如果您希望即使在加密后仍能访问文档属性，Aspose.Slides 允许您实现此需求。

如果希望用户在加密后仍可访问演示文稿的属性，请向[IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-)传递 `false`。以下示例代码演示了在加密演示文稿的同时仍提供文档属性访问的做法：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **仅从加密演示文稿加载文档属性**

若要在不加载幻灯片或其他内容的情况下检查加密演示文稿的元数据，可创建一个[LoadOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/loadoptions/)对象，并将 `true` 传递给[setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-)。在此模式下，Aspose.Slides 会忽略密码，仅加载公开可访问的文档属性。

以下代码示例通过[IPresentation.getDocumentProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--)读取内置和自定义文档属性：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // 读取内置文档属性。
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // 读取自定义文档属性。
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

此工作流仅在文档属性在演示文稿加密时保持未加密（公开）时才有效。如果文档属性已加密，将 `true` 传递给 `loadOptions.setOnlyLoadDocumentProperties` 会导致异常，因为在此模式下密码被忽略。若要访问加密的文档属性或加载包括幻灯片在内的完整演示文稿，请通过[ILoadOptions.setPassword](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-)提供正确的密码。

## **检查演示文稿是否受密码保护**

在加载演示文稿之前，您可能希望先检查并确认该演示文稿是否已设置密码保护。这样可以避免在未提供密码的情况下加载受密码保护的演示文稿时出现错误等问题。

以下 Java 代码演示了如何在不实际加载演示文稿的情况下检查其是否受密码保护：

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **检查演示文稿是否加密**

Aspose.Slides 允许您检查演示文稿是否已加密。要执行此操作，可使用[isEncrypted](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--)属性；如果演示文稿已加密，则返回 `true`，否则返回 `false`。

以下示例代码演示了如何检查演示文稿是否加密：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **检查演示文稿是否受写保护**

Aspose.Slides 允许您检查演示文稿是否受写保护。要执行此操作，可使用[isWriteProtected](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--)属性；如果演示文稿受写保护，则返回 `true`，否则返回 `false`。

以下示例代码演示了如何检查演示文稿是否受写保护：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **验证或确认已使用特定密码**

您可能需要检查并确认已使用特定密码对演示文稿进行保护。Aspose.Slides 提供了验证密码的功能。

以下示例代码演示了如何验证密码：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // 检查 "pass" 是否匹配
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

如果演示文稿已使用指定密码加密，则返回 `true`；否则返回 `false`。

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/zh/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**Aspose.Slides 支持哪些加密方法？**

Aspose.Slides 支持现代加密方法，包括基于 AES 的算法，确保演示文稿数据的高安全性。

**如果在打开演示文稿时输入了错误的密码会怎样？**

系统会抛出异常，提示访问被拒绝。这有助于防止未授权访问并保护演示文稿内容。

**在处理受密码保护的演示文稿时会有性能影响吗？**

加密和解密过程可能在打开和保存操作时带来轻微的开销。大多数情况下，这种性能影响很小，不会显著影响演示文稿任务的整体处理时间。