---
title: 在 Java 中对演示文稿进行密码保护
linktitle: 密码保护
type: docs
weight: 20
url: /zh/java/password-protected-presentation/
keywords:
- 带密码保护的演示文稿
- 打开密码
- 加密 PowerPoint
- 解密 PowerPoint
- 验证演示文稿密码
- 检查演示文稿密码
- 打开加密的演示文稿
- 移除加密
- PowerPoint
- PPT
- PPTX
- 演示文稿
- Java
- Aspose.Slides
description: "在 Java 中使用 Aspose.Slides 对受密码保护的 PowerPoint PPT 和 PPTX 演示文稿进行加密、检测、验证、打开和解密。"
---
## **概述**

打开密码会对演示文稿进行加密。必须提供正确的密码才能加载和查看演示文稿内容，因此此保护提供了机密性。

打开密码不同于写保护密码。写保护限制修改，但不加密内容，也不阻止加载演示文稿。要管理用于修改演示文稿的密码，请参阅 [Write‑Protect Presentations](/slides/zh/java/write-protected-presentation/)。

下面的工作流适用于 PPT 和 PPTX 演示文稿。示例在文件和流两种方式下均有展示，因为它们的行为有所不同。

## **使用打开密码加密演示文稿**

使用 [IProtectionManager.encrypt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) 为演示文稿分配打开密码。随后使用 [IPresentation.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) 保存加密后的演示文稿。

以下示例对 PPTX 演示文稿进行加密：

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **加载加密的演示文稿**

将 [ILoadOptions.setPassword](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) 设置为打开密码，并在加载文件时将该选项传递给 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/)。如果需要打开密码但未提供或提供的密码不正确，加载将失败。

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // 对解密后的演示文稿进行操作。
} finally {
    presentation.dispose();
}
```

## **移除演示文稿的加密**

使用打开密码加载演示文稿，调用 [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iprotectionmanager/#removeEncryption--)，然后保存结果。保存后的演示文稿即可在不提供密码的情况下加载。

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在加载前验证打开密码**

使用 [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) 获取 [IPresentationInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationinfo/)，无需创建完整的演示文稿实例。请求或验证密码前，请检查 [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--)。如果存在保护，使用 [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) 验证提供的密码。

### **文件路径工作流**

以下示例验证 PPTX 文件的打开密码，将验证后的值传递给 [ILoadOptions.setPassword](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-)，然后加载完整的演示文稿：

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **流工作流**

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) 的流重载提供相同的工作流。在从该流加载完整演示文稿之前，请先重置可定位流的位置。

以下示例使用 PPT 文件：

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **checkPassword 返回值**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) 仅在演示文稿具备打开密码且提供的密码正确时返回 `true`。在以下任意情况下返回 `false`：

- 密码不正确。
- 演示文稿没有打开密码。
- 提供的密码为 `null` 或空字符串。

PPT 和 PPTX 演示文稿的行为相同。

## **检查已加载的演示文稿是否已加密**

使用正确密码加载演示文稿后，检查 [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) 以确认源演示文稿已加密。若需在加载前检测打开密码保护，请使用上文示例中的 `IPresentationInfo.isPasswordProtected`。

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **安全建议**

{{% alert color="warning" title="安全" %}}
不要记录打开密码或在诊断信息中包含密码。避免不必要的重复验证尝试，仅在需要时将密码保留在内存中，并在立即加载演示文稿时复用已成功的验证结果。
{{% /alert %}}

## **在线对演示文稿设置密码保护**

1. 打开 [Aspose.Slides Lock](https://products.aspose.app/slides/zh/lock) 应用。
2. 选择或上传演示文稿。
3. 输入用于查看保护的密码。
4. （可选）输入用于编辑保护的另一密码。
5. 应用保护并下载生成的文件。

{{% alert color="info" title="另请参见" %}}
- [Write‑Protect Presentations](/slides/zh/java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/zh/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**打开密码和写保护密码有什么区别？**

打开密码会加密演示文稿，必须提供才能加载其内容。写保护密码仅限制修改，不加密内容。

**是否可以在不加载所有幻灯片的情况下验证打开密码？**

可以。获取演示文稿信息，检查是否存在打开密码保护，然后在创建完整演示文稿实例之前验证密码。

**密码检查工作流是否同时支持 PPT 和 PPTX？**

支持。基于文件路径和基于流的密码检测与验证在 PPT 和 PPTX 演示文稿中表现一致。