---
title: 在 JavaScript 中对演示文稿进行密码保护
linktitle: 密码保护
type: docs
weight: 20
url: /zh/nodejs-java/password-protected-presentation/
keywords:
- 受密码保护的演示文稿
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides 在 JavaScript 中加密、检测、验证、打开和解密受密码保护的 PowerPoint PPT 和 PPTX 演示文稿。"
---
## **概览**

打开密码会加密演示文稿。必须提供正确的密码才能加载和查看演示文稿内容，因此此保护提供机密性。

打开密码不同于写保护密码。写保护限制修改，但不加密内容或阻止加载演示文稿。要管理用于修改演示文稿的密码，请参阅[Write-Protect Presentations](/slides/zh/nodejs-java/write-protected-presentation/).

以下工作流适用于 PPT 和 PPTX 演示文稿。示例在两种格式中使用，以便在文件式和流式行为重要的情况下进行说明。

## **使用打开密码加密演示文稿**

使用[ProtectionManager.encrypt](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/protectionmanager/#encrypt)分配打开密码。然后使用[Presentation.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#save)持久化加密后的演示文稿。

以下示例加密 PPTX 演示文稿：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **保持文档属性公开**

默认情况下，Aspose.Slides 在演示文稿加密时会包含文档属性。[ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 方法可独立于幻灯片内容加密控制此行为。当索引、分类、搜索或文档管理系统必须在没有打开密码的情况下读取元数据时，请在调用[ProtectionManager.encrypt](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/protectionmanager/#encrypt)之前传入 `false`。

以下示例加密 PPTX 演示文稿，同时保持其内置文档属性公开：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

向[ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties)传入 `false` 并不会使幻灯片、母版、布局、形状、媒体或其他演示文稿内容公开。它仅影响文档属性。要在不加载加密内容的情况下读取这些属性，请参阅[Manage Presentation Properties](/slides/zh/nodejs-java/presentation-properties/).

## **加载加密的演示文稿**

在加载文件时，将[LoadOptions.setPassword](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/#setPassword)设置为打开密码，并将该选项传递给[Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/)。如果需要打开密码但提供的密码缺失或不正确，加载将失败。

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // 在解密的演示文稿上进行操作。
} finally {
    presentation.dispose();
}
```

## **从演示文稿中移除加密**

使用打开密码加载演示文稿，调用[ProtectionManager.removeEncryption](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/protectionmanager/#removeEncryption)，并保存结果。保存后的演示文稿即可无需密码加载。

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在加载前验证打开密码**

使用[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo)获取[PresentationInfo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/)，而无需创建完整的演示文稿实例。在请求或验证密码之前，检查[PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected)。如果存在保护，请使用[PresentationInfo.checkPassword](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/#checkPassword)验证提供的值。

### **文件路径工作流**

以下示例验证 PPTX 文件的打开密码，将验证后的值传递给[LoadOptions.setPassword](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/#setPassword)，然后加载完整的演示文稿：

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **流工作流**

使用[PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream)检查 Node.js 可读流。检查流被消耗后，创建新流再使用[Presentation.createPresentationFromStream](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#createPresentationFromStream)加载完整的演示文稿。

以下示例使用 PPT 文件：

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **checkPassword 返回值**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/#checkPassword) 仅在演示文稿具有打开密码且提供的密码正确时返回 `true`。在以下情况均返回 `false`：

- 密码不正确。
- 演示文稿没有打开密码。
- 提供的密码为 `null` 或为空。

PPT 和 PPTX 演示文稿的行为相同。

## **检查已加载的演示文稿是否加密**

加载演示文稿并使用正确密码后，检查[ProtectionManager.isEncrypted](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/protectionmanager/#isEncrypted)以确认源演示文稿已加密。要在加载前检测打开密码保护，请使用上文所示的[PresentationInfo.isPasswordProtected]。

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **安全建议**

{{% alert color="warning" title="Security" %}}
不要记录打开密码或将其包含在诊断信息中。避免不必要的重复验证尝试，仅在需要时将密码保留在内存中，并在立即加载演示文稿时复用成功的验证结果。

即使演示文稿内容已加密，公开的文档属性仍可能泄露作者姓名、标题、主题、关键字、公司信息、备注和自定义值。请将敏感的元数据与演示文稿一起加密。仅当系统必须在没有打开密码的情况下索引、分类、搜索或管理文件时，才应明确决定公开属性。
{{% /alert %}}

## **在线为演示文稿设置密码保护**

1. 打开[Aspose.Slides Lock](https://products.aspose.app/slides/zh/lock)应用程序。
2. 选择或上传演示文稿。
3. 输入用于查看保护的密码。
4. 可选地输入用于编辑保护的另一个密码。
5. 应用保护并下载生成的文件。

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/zh/nodejs-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/zh/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**打开密码与写保护密码有什么区别？**

打开密码会加密演示文稿，必须提供该密码才能加载其内容。写保护密码仅限制修改，且不加密内容。

**是否可以在不加载所有幻灯片的情况下验证打开密码？**

可以。获取演示文稿信息，检查是否存在打开密码保护，然后在创建完整演示文稿实例之前验证密码。

**应用程序能否在没有打开密码的情况下读取元数据？**

可以，但前提是演示文稿在加密时已禁用文档属性加密。此时应用程序需使用[Manage Presentation Properties](/slides/zh/nodejs-java/presentation-properties/)中描述的仅文档属性加载模式。

**密码检查工作流是否同时支持 PPT 和 PPTX？**

支持。文件路径和流式的密码检测与验证在 PPT 和 PPTX 演示文稿中表现一致。