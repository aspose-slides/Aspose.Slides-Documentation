---
title: 在 Android 上写保护演示文稿
linktitle: 写保护
type: docs
weight: 25
url: /zh/androidjava/write-protected-presentation/
keywords:
- 写保护
- 写保护 PowerPoint
- 修改密码
- 限制演示文稿编辑
- 移除写保护
- 验证修改密码
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android（Java）在 PowerPoint PPT 和 PPTX 演示文稿中设置、检测、验证和移除写保护密码。"
---
## **介绍**

写保护密码限制对演示文稿的修改，但不加密其内容。用户可以在不输入密码的情况下加载并查看受写保护的演示文稿。根据具体应用，他们甚至可能编辑内容并另存为其他文件名，因此写保护不应被视为保密机制。

打开密码的作用不同：它会加密演示文稿，并在加载内容时需要提供。有关加密演示文稿或验证打开密码，请参阅[受密码保护的演示文稿](/slides/zh/androidjava/password-protected-presentation/)。

本文中的工作流适用于 PPT 和 PPTX 演示文稿。示例使用 PPTX 文件；保存为 PPT 时，请使用`.ppt`扩展名和对应的 PPT 保存格式。

## **为演示文稿设置写保护**

使用[IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-)为演示文稿分配修改密码。保存演示文稿时会保留该保护设置。

下面的示例为 PPTX 演示文稿设置写保护：

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **加载受写保护的演示文稿**

由于写保护不加密演示文稿内容，加载演示文稿时不需要密码。密码仅在验证修改受保护演示文稿的授权时才相关。

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

不要向[ILoadOptions.setPassword](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-)传递写保护密码。该方法接受用于加密内容的打开密码。如果演示文稿同时具有两种保护类型，请在加载时提供打开密码，并单独处理写保护密码。

## **从演示文稿中移除写保护**

使用[IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--)移除修改限制，然后保存演示文稿。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **检查演示文稿是否受写保护**

若要在不创建完整[Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/)实例的情况下检查文件，请调用[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-)并检查[IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--)。该方法使用[NullableBool](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/nullablebool/)并在检测到写保护时返回`NullableBool.True`。

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-)的流重载同样提供针对以流形式提供的演示文稿的相同信息。

## **验证写保护密码**

使用[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-)在不加载完整演示文稿的情况下验证修改密码。先检查[IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--)，确保仅在存在写保护时才请求或验证密码。

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-)仅验证写保护密码。它不验证打开密码，也不判断加密内容是否可以加载。相反，[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-)仅验证打开密码。如果已经加载了完整演示文稿，可通过[IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-)在其保护管理器中进行等效的写保护检查。

在生产环境中，请勿记录密码或在诊断信息中包含密码。避免不必要的重复验证，并仅在需要时将密码保留在内存中。

{{% alert color="info" title="另请参阅" %}}
- [受密码保护的演示文稿](/slides/zh/androidjava/password-protected-presentation/)
- [只读演示文稿](/slides/zh/androidjava/read-only-presentation/)
- [PowerPoint 中的数字签名](/slides/zh/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**写保护会加密演示文稿吗？**

不会。它限制修改，但仍然可以加载和查看演示文稿内容。

**打开演示文稿是否需要写保护密码？**

不需要。加载加密的演示文稿内容仅需要打开密码。

**演示文稿可以同时拥有打开密码和写保护密码吗？**

可以。通过加载选项提供打开密码以打开加密的演示文稿，并在需要修改授权时单独验证写保护密码。