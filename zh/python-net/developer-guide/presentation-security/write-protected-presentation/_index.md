---
title: 在 Python 中写保护演示文稿
linktitle: 写保护
type: docs
weight: 25
url: /zh/python-net/write-protected-presentation/
keywords:
- 写保护
- 写保护 PowerPoint
- 修改密码
- 限制演示文稿编辑
- 移除写保护
- 验证修改密码
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 在 PowerPoint PPT 和 PPTX 演示文稿中设置、检测、验证和移除写保护密码。"
---
## **介绍**

写保护密码限制对演示文稿的修改，但不会加密其内容。用户可以在不提供密码的情况下加载和查看受写保护的演示文稿。根据应用程序的不同，用户可能还能够编辑内容并另存为其他名称，因此写保护不应被视为保密机制。

打开密码的作用不同：它会加密演示文稿，并且在加载内容时需要提供。要加密演示文稿或验证打开密码，请参阅[Password-Protect Presentations](/slides/zh/python-net/password-protected-presentation/)。

本文档中的工作流适用于 PPT 和 PPTX 演示文稿。示例使用 PPTX 文件；若保存为 PPT，请使用`.ppt`扩展名及相应的 PPT 保存格式。

## **在演示文稿上设置写保护**

使用[ProtectionManager.set_write_protection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/protectionmanager/set_write_protection/)为演示文稿指定修改密码。保存演示文稿后，保护设置将被保留。

下面的示例为 PPTX 演示文稿设置写保护：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **加载受写保护的演示文稿**

由于写保护并不加密演示文稿内容，加载演示文稿时不需要密码。密码仅在验证对受保护演示文稿的修改授权时才相关。

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

不要将写保护密码传递给[LoadOptions.password](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/password/)。该属性接受用于加密内容的打开密码。如果演示文稿同时具备两种保护，请提供打开密码以加载它，并单独处理写保护密码。

## **从演示文稿中移除写保护**

使用[ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/protectionmanager/remove_write_protection/)移除修改限制，然后保存演示文稿。

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **检查演示文稿是否受写保护**

要在不创建完整[Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/)实例的情况下检查文件，请调用[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationfactory/get_presentation_info/)并检查[PresentationInfo.is_write_protected](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/is_write_protected/)。该属性使用[NullableBool](https://reference.aspose.com/slides/zh/python-net/aspose.slides/nullablebool/)，在检测到写保护时返回`NullableBool.TRUE`。

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationfactory/get_presentation_info/)的流重载在演示文稿以流形式提供时也提供相同的信息。

## **验证写保护密码**

使用[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/check_write_protection/)在不加载完整演示文稿的情况下验证修改密码。请先检查[PresentationInfo.is_write_protected](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/is_write_protected/)，以便仅在存在写保护时才请求或验证密码。

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/check_write_protection/)仅验证写保护密码。它不验证打开密码，也不确定是否可以加载加密内容。相反，[PresentationInfo.check_password](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/check_password/)仅验证打开密码。如果已经加载了完整的演示文稿，[ProtectionManager.check_write_protection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/protectionmanager/check_write_protection/)通过其保护管理器提供等效的写保护检查。

在生产环境中，请勿记录密码或在诊断信息中包含密码。避免不必要的重复验证，并且仅在需要时在内存中保留密码。

{{% alert color="info" title="另见" %}}
- [Password-Protect Presentations](/slides/zh/python-net/password-protected-presentation/)
- [Read-Only Presentations](/slides/zh/python-net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/zh/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**写保护会加密演示文稿吗？**

不会。它限制修改，但仍然可以加载和查看演示文稿内容。

**打开演示文稿是否需要写保护密码？**

不会。仅需要打开密码才能加载加密的演示文稿内容。

**演示文稿可以同时具有打开密码和写保护密码吗？**

可以。通过加载选项提供打开密码以打开加密的演示文稿，并在需要修改授权时单独验证写保护密码。