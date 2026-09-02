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
description: "在 Python 中使用 Aspose.Slides 对受密码保护的 PowerPoint PPT 和 PPTX 演示文稿进行加密、检测、验证、打开和解密。"
---
## **概述**

打开密码会对演示文稿进行加密。必须提供正确的密码才能加载和查看演示文稿内容，因此此保护提供了机密性。

打开密码不同于写保护密码。写保护限制修改，但不对内容进行加密，也不阻止演示文稿的加载。要管理用于修改演示文稿的密码，请参阅[Write-Protect Presentations](/slides/zh/python-net/write-protected-presentation/)。

下面的工作流适用于 PPT 和 PPTX 演示文稿。示例在两种格式中都使用，当文件式和流式行为重要时。

## **使用打开密码加密演示文稿**

使用[ProtectionManager.encrypt](https://reference.aspose.com/slides/zh/python-net/aspose.slides/protectionmanager/encrypt/)分配打开密码。然后使用[Presentation.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/save/)持久化加密后的演示文稿。

以下示例加密 PPTX 演示文稿：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **加载加密的演示文稿**

将[LoadOptions.password](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/password/)设置为打开密码，并在加载文件时将该选项传递给[Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/)。如果需要打开密码但提供的密码缺失或不正确，加载将失败。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # 在解密的演示文稿上工作。
    pass
```

## **从演示文稿中移除加密**

使用打开密码加载演示文稿，调用[ProtectionManager.remove_encryption](https://reference.aspose.com/slides/zh/python-net/aspose.slides/protectionmanager/remove_encryption/)，然后保存结果。保存后的演示文稿即可在不提供密码的情况下加载。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **在加载之前验证打开密码**

使用[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationfactory/get_presentation_info/)获取[PresentationInfo](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/)，而无需创建完整的演示文稿实例。在请求或验证密码之前检查[PresentationInfo.is_password_protected](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/is_password_protected/)。当存在保护时，使用[PresentationInfo.check_password](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/check_password/)验证提供的值。

### **文件路径工作流**

以下示例验证 PPTX 文件的打开密码，将验证后的值传递给[LoadOptions.password](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/password/)，然后加载完整的演示文稿：

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

[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationfactory/get_presentation_info/)的流重载提供相同的工作流。在从该流加载完整演示文稿之前，重置可寻址流的位置。

以下示例使用 PPT 文件：

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

[PresentationInfo.check_password](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/check_password/)仅在演示文稿具有打开密码且提供的密码正确时返回 `True`。在以下情况均返回 `False`：

- 密码不正确。
- 演示文稿没有打开密码。
- 提供的密码为 `None` 或为空。

PPT 和 PPTX 演示文稿的行为相同。

## **检查已加载的演示文稿是否已加密**

使用正确的密码加载演示文稿后，检查[ProtectionManager.is_encrypted](https://reference.aspose.com/slides/zh/python-net/aspose.slides/protectionmanager/is_encrypted/)以确认源演示文稿已加密。要在加载之前检测打开密码保护，请如上所示使用 `PresentationInfo.is_password_protected`。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **安全建议**

{{% alert color="warning" title="Security" %}}
不要记录打开密码或在诊断信息中包含它们。避免不必要的重复验证尝试，仅在需要时将密码保存在内存中，并在立即加载演示文稿时复用成功的验证结果。
{{% /alert %}}

## **在线对演示文稿进行密码保护**

1. 打开[Aspose.Slides Lock](https://products.aspose.app/slides/zh/lock)应用程序。
1. 选择或上传演示文稿。
1. 输入用于查看保护的密码。
1. 可选地为编辑保护输入另一密码。
1. 应用保护并下载生成的文件。

{{% alert color="info" title="See also" %}}
- [写保护演示文稿](/slides/zh/python-net/write-protected-presentation/)
- [PowerPoint 中的数字签名](/slides/zh/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}