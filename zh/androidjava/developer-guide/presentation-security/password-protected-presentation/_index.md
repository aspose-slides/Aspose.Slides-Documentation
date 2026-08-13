---
title: 在 Android 上使用密码保护演示文稿
linktitle: 密码保护
type: docs
weight: 20
url: /zh/androidjava/password-protected-presentation/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android（通过 Java）轻松锁定和解锁受密码保护的 PowerPoint 与 OpenDocument 演示文稿。确保您的演示文稿安全。"
---
## **简介**

当您对演示文稿设置密码保护时，意味着您正在设置一个密码来对演示文稿实施特定限制。要解除这些限制，必须输入密码。受密码保护的演示文稿被视为已锁定的演示文稿。

通常，您可以设置密码来对演示文稿强制这些限制：

- **修改**

  如果您希望只有特定用户可以修改您的演示文稿，您可以设置修改限制。此限制可防止他人在未提供密码的情况下对演示文稿进行修改、变更或复制。

  但是，在这种情况下，即使没有密码，用户仍然可以访问并打开文档。在只读模式下，用户可以查看演示文稿中的内容或项——超链接、动画、效果等——但无法复制项目或保存演示文稿。

- **打开**

  如果您希望只有特定用户可以打开您的演示文稿，您可以设置打开限制。此限制可阻止他人查看演示文稿的内容（除非提供密码）。

  从技术上讲，打开限制同样阻止用户修改演示文稿：当人们无法打开演示文稿时，他们就无法对其进行修改或更改。

  **注意**，当您通过密码保护演示文稿以防止打开时，演示文稿文件将被加密。

## **Aspose.Slides 中的演示文稿密码保护**
**支持的格式**

Aspose.Slides 支持密码保护、加密和类似操作，适用于以下格式的演示文稿：

- PPTX 和 PPT - Microsoft PowerPoint 演示文稿
- ODP - OpenDocument 演示文稿
- OTP - OpenDocument 演示文稿模板

**支持的操作**

Aspose.Slides 允许您通过以下方式使用密码保护来防止演示文稿被修改：

- 对演示文稿进行加密
- 为演示文稿设置写保护

**其他操作**

Aspose.Slides 允许您通过以下方式执行其他涉及密码保护和加密的任务：

- 解密演示文稿；打开已加密的演示文稿
- 移除加密；禁用密码保护
- 移除演示文稿的写保护
- 获取已加密演示文稿的属性
- 检查演示文稿是否已加密
- 检查演示文稿是否受密码保护。

## **加密演示文稿**

您可以通过设置密码来加密演示文稿。然后，要修改已锁定的演示文稿，用户必须提供密码。

要加密或对演示文稿进行密码保护，必须使用 encrypt 方法（来自 [IProtectionManager](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IProtectionManager)）为演示文稿设置密码。将密码传递给 encrypt 方法，然后使用 save 方法保存已加密的演示文稿。

以下示例代码展示了如何加密演示文稿：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **为演示文稿设置写保护**

您可以在演示文稿中添加“请勿修改”的标记。通过这种方式，您可以告知用户您不希望他们更改演示文稿。

**注意**，写保护过程并不会加密演示文稿。因此，用户——如果他们真的想——仍然可以修改演示文稿，但要保存更改，则必须以不同的名称创建演示文稿。

要设置写保护，必须使用 [setWriteProtection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) 方法。以下示例代码展示了如何为演示文稿设置写保护：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **加载已加密的演示文稿**

Aspose.Slides 允许您通过使用正确的密码并通过 [LoadOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/loadoptions/) 加载已加密的演示文稿。

以下示例代码展示了如何打开已加密的演示文稿：

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // 与已解密的演示文稿一起工作
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **移除演示文稿的加密**

您可以移除演示文稿的加密或密码保护。这样，用户即可在没有限制的情况下访问或修改演示文稿。

要移除加密或密码保护，需要调用 [removeEncryption](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) 方法。以下示例代码展示了如何从演示文稿中移除加密：

```java
import com.aspose.slides.*;

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

您可以使用 Aspose.Slides 移除演示文稿文件上的写保护。这样，用户可以随意修改——且在执行此类操作时不会收到警告。

您可以通过使用 [removeWriteProtection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) 方法来移除演示文稿的写保护。以下示例代码展示了如何从演示文稿中移除写保护：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **获取已加密演示文稿的属性**

通常，用户很难检索已加密或受密码保护的演示文稿的文档属性。然而，Aspose.Slides 提供了一种机制，允许您对演示文稿进行密码保护的同时，仍保留用户访问其属性的能力。

**注意:** 默认情况下，Aspose.Slides 加密演示文稿时，演示文稿的文档属性也会被密码保护。如果您需要在加密后仍然能够访问文档属性，Aspose.Slides 完全支持此操作。

如果您希望用户仍然能够访问已加密演示文稿的属性，请向 [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) 传入 `false`。以下示例代码展示了如何在加密演示文稿的同时仍为用户提供访问其文档属性的权限：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **仅加载已加密演示文稿的文档属性**

若要在不加载幻灯片或其他内容的情况下检查已加密演示文稿的元数据，请创建一个 [LoadOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/loadoptions/) 对象，并向 [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-) 传入 `true`。在此模式下，Aspose.Slides 将忽略密码，仅加载公开可访问的文档属性。

以下代码示例通过 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) 读取内置和自定义文档属性：

```java
import com.aspose.slides.*;

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

此工作流仅在演示文稿加密时文档属性保持未加密（公开）时有效。如果文档属性已加密，向 `loadOptions.setOnlyLoadDocumentProperties` 传入 `true` 将导致异常，因为在此模式下密码被忽略。若要访问加密的文档属性或加载包括幻灯片及其他内容的完整演示文稿，请通过 [ILoadOptions.setPassword](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) 提供正确的密码。

## **检查演示文稿是否受密码保护**

在加载演示文稿之前，您可能需要检查并确认该演示文稿是否未被密码保护。这样可以避免在未提供密码而加载受密码保护的演示文稿时出现错误及类似问题。

以下 Java 代码展示了如何检查演示文稿是否受密码保护（无需实际加载演示文稿）：

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **检查演示文稿是否已加密**

Aspose.Slides 允许您检查演示文稿是否已加密。要执行此操作，可使用 [isEncrypted](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) 属性，该属性若演示文稿已加密则返回 `true`，否则返回 `false`。

以下示例代码展示了如何检查演示文稿是否已加密：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **检查演示文稿是否已写保护**

Aspose.Slides 允许您检查演示文稿是否已写保护。要执行此操作，可使用 [isWriteProtected](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) 属性，该属性若演示文稿已写保护则返回 `true`，否则返回 `false`。

以下示例代码展示了如何检查演示文稿是否已写保护：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **验证或确认已使用特定密码**

您可能想要检查并确认已使用特定密码来保护演示文稿。Aspose.Slides 提供了验证密码的方式。

以下示例代码展示了如何验证密码：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // 检查 "pass" 是否匹配
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

若演示文稿已使用指定密码进行写保护，则返回 `true`；否则返回 `false`。

{{% alert color="info" title="另请参见" %}} 
- [PowerPoint 中的数字签名](/slides/zh/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**Aspose.Slides 支持哪些加密方法？**

Aspose.Slides 支持包括基于 AES 的现代加密算法，为您的演示文稿提供高水平的数据安全。

**尝试打开演示文稿时输入错误密码会发生什么？**

如果使用了错误的密码，将抛出异常，提示您访问演示文稿被拒绝。这有助于防止未经授权的访问并保护演示文稿内容。

**在处理受密码保护的演示文稿时是否会有性能影响？**

加密和解密过程可能在打开和保存操作时带来轻微的开销。在大多数情况下，这种性能影响很小，并不会显著影响演示文稿任务的整体处理时间。