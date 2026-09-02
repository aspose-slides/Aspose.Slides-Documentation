---
title: 在 JavaScript 中写保护演示文稿
linktitle: 写保护
type: docs
weight: 25
url: /zh/nodejs-java/write-protected-presentation/
keywords:
- 写保护
- PowerPoint 写保护
- 用于修改的密码
- 限制演示文稿编辑
- 移除写保护
- 验证修改密码
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js（通过 Java）在 PowerPoint PPT 和 PPTX 演示文稿中设置、检测、验证和移除写保护密码。"
---
## **介绍**

写保护密码限制对演示文稿的修改，但不会加密其内容。用户可以在没有密码的情况下加载并查看受写保护的演示文稿。根据具体应用，他们甚至可能编辑内容并另存为其他名称，因此写保护不应被视为保密机制。

打开密码的作用不同：它会加密演示文稿，加载内容时需要提供该密码。要加密演示文稿或验证打开密码，请参阅[密码保护演示文稿](/slides/zh/nodejs-java/password-protected-presentation/)。

本文中的工作流适用于 PPT 和 PPTX 演示文稿。示例使用 PPTX 文件；保存为 PPT 时，请使用 `.ppt` 扩展名和相应的 PPT 保存格式。

## **为演示文稿设置写保护**

使用[ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection)为演示文稿分配修改密码。保存演示文稿后会保留该保护设置。

下面的示例在 PPTX 演示文稿上设置写保护：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **加载受写保护的演示文稿**

由于写保护不加密演示文稿内容，加载演示文稿时不需要密码。密码仅在验证对受保护演示文稿的修改授权时才相关。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

不要将写保护密码传递给[LoadOptions.setPassword](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/#setPassword)。该方法接受用于加密内容的打开密码。如果演示文稿同时具备两种保护类型，请提供打开密码以加载演示文稿，并单独处理写保护密码。

## **移除演示文稿的写保护**

使用[ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection)移除修改限制，然后保存演示文稿。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **检查演示文稿是否受写保护**

若要在不创建完整[Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/)实例的情况下检查文件，请调用[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo)并检查[PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected)。该方法返回[NullableBool](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/nullablebool/)，当检测到写保护时返回`NullableBool.True`。

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

基于流的[PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream)方法可为以 Node.js 可读流提供的演示文稿返回相同信息。

## **验证写保护密码**

使用[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection)在不加载完整演示文稿的情况下验证修改密码。首先检查[PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected)，仅在存在写保护时才请求或验证密码。

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection)仅验证写保护密码。它不验证打开密码，也不判断是否可以加载加密内容。相反，[PresentationInfo.checkPassword](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/#checkPassword)仅验证打开密码。如果已经加载了完整的演示文稿，使用[ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/protectionmanager/#checkWriteProtection)可通过其保护管理器执行等效的写保护检查。

在生产环境中，请勿记录密码或将其包含在诊断信息中。避免不必要的重复验证，只在需要时将密码保存在内存中。

{{% alert color="info" title="另见" %}}
- [密码保护演示文稿](/slides/zh/nodejs-java/password-protected-presentation/)
- [只读演示文稿](/slides/zh/nodejs-java/read-only-presentation/)
- [PowerPoint 中的数字签名](/slides/zh/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**写保护会加密演示文稿吗？**

不会。它限制修改，但仍然可以加载和查看演示文稿内容。

**打开演示文稿是否需要写保护密码？**

不需要。只有打开密码是加载加密演示文稿内容所必需的。

**演示文稿可以同时拥有打开密码和写保护密码吗？**

可以。通过加载选项提供打开密码以打开加密的演示文稿，在需要修改授权时单独验证写保护密码。