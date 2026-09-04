---
title: 在 Python 中对演示文稿进行密码保护
linktitle: 密码保护
type: docs
weight: 20
url: /zh/python-net/password-protected-presentation/
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
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 加密、检测、验证、打开并解密受密码保护的 PowerPoint PPT 和 PPTX 演示文稿。"
---
## **概述**

打开密码对演示文稿进行加密。必须提供正确的密码才能加载和查看演示文稿内容，因此此保护提供了机密性。

打开密码不同于写保护密码。写保护限制修改，但不加密内容，也不阻止加载演示文稿。要管理用于修改演示文稿的密码，请参阅[Write-Protect Presentations](/slides/zh/python-net/write-protected-presentation/)。

以下工作流适用于 PPT 和 PPTX 演示文稿。当文件方式和流方式的行为重要时，示例同时使用两种格式。

## **使用打开密码加密演示文稿**

使用[ProtectionManager.encrypt](https://reference.aspose.com/slides/zh/python-net/aspose.slides/protectionmanager/encrypt/)分配打开密码。然后使用[Presentation.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/save/)保存加密后的演示文稿。

下面的示例加密了一个 PPTX 演示文稿：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **将文档属性设为公开**

默认情况下，Aspose.Slides 会在演示文稿加密中包含文档属性。[ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) 属性可独立于幻灯片内容加密控制此行为。在需要索引、分类、搜索或文档管理系统在没有打开密码的情况下读取元数据时，请在调用[ProtectionManager.encrypt](https://reference.aspose.com/slides/zh/python-net/aspose.slides/protectionmanager/encrypt/)之前将其设为`False`。

下面的示例在创建加密的 PPTX 演示文稿时保持其内置文档属性公开：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    properties = presentation.document_properties
    properties.author = "Contoso Knowledge Management"
    properties.title = "Quarterly Product Roadmap"
    properties.keywords = "roadmap, planning, internal"

    presentation.slides[0].name = "Encrypted presentation content"
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", slides.export.SaveFormat.PPTX)
```

将`encrypt_document_properties`设为`False`并不将幻灯片、母版、布局、形状、媒体或其他演示文稿内容设为公开。它仅影响文档属性。若要在不加载加密内容的情况下读取这些属性，请参阅[Manage Presentation Properties](/slides/zh/python-net/presentation-properties/)。

## **加载加密的演示文稿**

将[LoadOptions.password](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/password/)设置为打开密码，并在加载文件时将该选项传递给[Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/)。如果需要打开密码但未提供或提供的密码不正确，加载将失败。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # 使用已解密的演示文稿。
    pass
```

## **移除演示文稿的加密**

使用打开密码加载演示文稿，调用[ProtectionManager.remove_encryption](https://reference.aspose.com/slides/zh/python-net/aspose.slides/protectionmanager/remove_encryption/)，然后保存结果。保存后的演示文稿即可在无密码的情况下加载。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **在加载前验证打开密码**

使用[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationfactory/get_presentation_info/)获取[PresentationInfo](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/)，而无需创建完整的演示文稿实例。在请求或验证密码之前检查[PresentationInfo.is_password_protected](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/is_password_protected/)。如果存在保护，请使用[PresentationInfo.check_password](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/check_password/)验证提供的值。

### **文件路径工作流**

下面的示例验证 PPTX 文件的打开密码，将验证后的值传递给[LoadOptions.password](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/password/)，然后加载完整的演示文稿：

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **流工作流**

[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationfactory/get_presentation_info/) 的流重载提供相同的工作流。在从该流加载完整演示文稿之前，请重置可定位流的位置。

下面的示例使用 PPT 文件：

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **CheckPassword 返回值**

[PresentationInfo.check_password](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/check_password/)仅在演示文稿具有打开密码且提供的密码正确时返回`True`。在以下情况中返回`False`：

- 密码不正确。
- 演示文稿没有打开密码。
- 提供的密码为`None`或为空。

PPT 和 PPTX 演示文稿的行为相同。

## **检查已加载的演示文稿是否被加密**

在使用正确密码加载演示文稿后，检查[ProtectionManager.is_encrypted](https://reference.aspose.com/slides/zh/python-net/aspose.slides/protectionmanager/is_encrypted/)以确认源演示文稿已加密。如需在加载前检测打开密码保护，请使用上文示例中的`PresentationInfo.is_password_protected`。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **安全性建议**

{{% alert color="warning" title="Security" %}}
不要记录打开密码或将其包含在诊断消息中。避免不必要的重复验证尝试，仅在需要时将密码保留在内存中，并在立即加载演示文稿时复用成功的验证结果。

即使演示文稿内容已加密，公开的文档属性仍可能泄露作者姓名、标题、主题、关键字、公司信息、注释和自定义值。请将敏感的元数据与演示文稿一起加密。仅在系统必须在没有打开密码的情况下对文件进行索引、分类、搜索或管理时，才应明确决定公开属性。
{{% /alert %}}

## **在线对演示文稿进行密码保护**

1. 打开[Aspose.Slides Lock](https://products.aspose.app/slides/zh/lock)应用程序。  
2. 选择或上传演示文稿。  
3. 输入用于查看保护的密码。  
4. （可选）输入用于编辑保护的单独密码。  
5. 应用保护并下载生成的文件。

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/zh/python-net/write-protected-presentation/)  
- [Digital Signature in PowerPoint](/slides/zh/python-net/digital-signature-in-powerpoint/)  
{{% /alert %}}

## **常见问题**

**打开密码和写保护密码有什么区别？**

打开密码会加密演示文稿，且必须在加载内容时提供。写保护密码限制修改，但不加密内容。

**可以在不加载所有幻灯片的情况下验证打开密码吗？**

可以。获取演示文稿信息，检查是否存在打开密码保护，然后在创建完整演示文稿实例之前验证密码。

**应用程序能在没有打开密码的情况下读取元数据吗？**

可以，但仅在演示文稿使用`encrypt_document_properties`设为`False`加密时。此时应用程序应使用[Manage Presentation Properties](/slides/zh/python-net/presentation-properties/)中描述的仅加载文档属性模式。

**密码检查工作流是否支持 PPT 和 PPTX？**

支持。基于文件路径和基于流的密码检测与验证在 PPT 和 PPTX 演示文稿中行为相同。