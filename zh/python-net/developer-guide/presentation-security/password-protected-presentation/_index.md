---
title: 使用 Python 对演示文稿进行密码保护
linktitle: 密码保护
type: docs
weight: 20
url: /zh/python-net/password-protected-presentation/
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
- PowerPoint 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 轻松锁定和解锁受密码保护的 PowerPoint 与 OpenDocument 演示文稿。通过我们的分步指南提升工作效率并确保演示文稿安全。"
---
## **简介**

当您对演示文稿进行密码保护时，这意味着您设置了一个密码，以对演示文稿实施某些限制。要取消这些限制，需要输入密码。受密码保护的演示文稿被视为锁定演示文稿。

通常，您可以设置密码来对演示文稿实施这些限制：

- **修改**

  如果您只希望特定用户修改您的演示文稿，可以设置修改限制。此限制阻止人们修改、更改或复制演示文稿中的内容（除非提供密码）。

  但是，在这种情况下，即使没有密码，用户仍然可以访问您的文档并打开它。在只读模式下，用户可以查看演示文稿中的内容或对象——超链接、动画、效果等——但不能复制项目或保存演示文稿。

- **打开**

  如果您只希望特定用户打开您的演示文稿，可以设置打开限制。此限制阻止人们查看演示文稿的内容（除非提供密码）。

  从技术上讲，打开限制也会阻止用户修改演示文稿：当人们无法打开演示文稿时，他们也无法对其进行修改或更改。

  **注意** 当您对演示文稿进行密码保护以防止打开时，演示文稿文件会被加密。

## 在线对演示文稿进行密码保护

1. 前往我们的[**Aspose.Slides 锁定**](https://products.aspose.app/slides/zh/lock)页面。

   ![todo:image_alt_text](slides-lock.png)

2. 点击**拖放或上传文件**。

3. 在电脑上选择您想要进行密码保护的文件。

4. 输入您用于编辑保护的首选密码；输入您用于查看保护的首选密码。

5. 如果您希望用户将演示文稿视为最终稿，请勾选**标记为最终**复选框。

6. 点击**立即保护**。

7. 点击**立即下载**。

## **Aspose.Slides 中的演示文稿密码保护**
**支持的格式**

Aspose.Slides 支持对以下格式的演示文稿进行密码保护、加密等操作：

- PPTX 和 PPT - Microsoft PowerPoint 演示文稿
- ODP - OpenDocument 演示文稿
- OTP - OpenDocument 演示文稿模板

**支持的操作**

Aspose.Slides 允许您通过以下方式对演示文稿使用密码保护，以防止修改：

- 加密演示文稿
- 设置演示文稿写保护

**其他操作**

Aspose.Slides 允许您以以下方式执行其他涉及密码保护和加密的任务：

- 解密演示文稿；打开已加密的演示文稿
- 移除加密；禁用密码保护
- 移除演示文稿的写保护
- 获取已加密演示文稿的属性
- 检查演示文稿是否已加密
- 检查演示文稿是否受密码保护。

## **加密演示文稿**

您可以通过设置密码来加密演示文稿。随后，要修改已锁定的演示文稿，用户必须提供密码。

要加密或对演示文稿进行密码保护，需使用 encrypt 方法（来自[ProtectionManager](https://reference.aspose.com/slides/zh/python-net/aspose.slides/protectionmanager/)）为演示文稿设置密码。将密码传递给 encrypt 方法，并使用 save 方法保存已加密的演示文稿。

此示例代码展示了如何加密演示文稿：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **为演示文稿设置写保护**

您可以在演示文稿上添加“请勿修改”的标记。这样，您可以告知用户不希望他们对演示文稿进行更改。

**注意** 写保护过程并不加密演示文稿。因此，用户——如果真的想——仍然可以修改演示文稿，但要保存更改，他们必须另存为不同的文件名。

要设置写保护，需要使用 setWriteProtection 方法。此示例代码展示了如何为演示文稿设置写保护：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **解密演示文稿；打开已加密的演示文稿**

Aspose.Slides 允许通过传递密码加载加密文件。要解密演示文稿，需要调用[remove_encryption](https://reference.aspose.com/slides/zh/python-net/aspose.slides/protectionmanager/)方法且不带参数。随后您需要输入正确的密码以加载演示文稿。

此示例代码展示了如何解密演示文稿：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **移除加密；禁用密码保护**

您可以移除演示文稿的加密或密码保护。这样，用户即可在没有任何限制的情况下访问或修改演示文稿。

要移除加密或密码保护，需要调用[remove_encryption](https://reference.aspose.com/slides/zh/python-net/aspose.slides/protectionmanager/)方法。此示例代码展示了如何从演示文稿中移除加密：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **从演示文稿中移除写保护**

您可以使用 Aspose.Slides 移除演示文稿文件上的写保护。这样，用户可以随意修改——且在执行此类操作时不会收到任何警告。

您可以通过使用[remove_write_protection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/protectionmanager/)方法来移除写保护。此示例代码展示了如何从演示文稿中移除写保护：

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **获取已加密演示文稿的属性**

通常，用户很难检索已加密或受密码保护的演示文稿的文档属性。然而，Aspose.Slides 提供了一种机制，允许您对演示文稿进行密码保护的同时，仍保留用户访问其属性的能力。

**注意:** 默认情况下，当 Aspose.Slides 加密演示文稿时，演示文稿的文档属性也会受密码保护。如果您需要在加密后仍可访问文档属性，Aspose.Slides 允许您这样做。

如果您希望用户在加密演示文稿后仍能访问其属性，请将[ProtectionManager](https://reference.aspose.com/slides/zh/python-net/aspose.slides/protectionmanager/)的 `encrypt_document_properties` 属性设为 `False`。此示例代码展示了如何在加密演示文稿的同时仍提供用户访问文档属性的能力：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("123123")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **仅从已加密演示文稿加载文档属性**

要在不加载幻灯片或其他内容的情况下检查已加密演示文稿的元数据，请创建一个[LoadOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/)对象并将[only_load_document_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/only_load_document_properties/)设为 `True`。在此模式下，Aspose.Slides 会忽略密码，仅加载公开可访问的文档属性。

以下代码示例通过[Presentation.document_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/document_properties/)读取内置文档属性并列出自定义文档属性：

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    document_properties = presentation.document_properties

    # 读取内置文档属性。
    print("Title: " + document_properties.title)
    print("Author: " + document_properties.author)

    # 列出自定义文档属性。
    custom_property_count = document_properties.count_of_custom_properties

    for property_index in range(custom_property_count):
        property_name = document_properties.get_custom_property_name(property_index)
        print(property_name)
```

此工作流仅在演示文稿加密时文档属性保持未加密（公开）时有效。如果文档属性被加密，将 `only_load_document_properties` 设为 `True` 会导致异常，因为此模式下密码被忽略。要访问加密的文档属性或加载完整的演示文稿（包括幻灯片和其他内容），请在[LoadOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/)中提供正确的 `password` 值。

## **在加载演示文稿之前检查其是否受密码保护**

在加载演示文稿之前，您可能想要检查并确认该演示文稿未被密码保护。这样可以避免在未提供密码的情况下加载受密码保护的演示文稿时出现错误和类似问题。

此 Python 代码展示了如何检查演示文稿是否受密码保护（不加载演示文稿本身）：

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **检查演示文稿是否已加密**

Aspose.Slides 允许您检查演示文稿是否已加密。要执行此操作，可以使用[is_encrypted](https://reference.aspose.com/slides/zh/python-net/aspose.slides/protectionmanager/)属性，如果演示文稿已加密则返回 `True`，否则返回 `False`。

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **检查演示文稿是否写保护**

Aspose.Slides 允许您检查演示文稿是否写保护。要执行此操作，可以使用[is_write_protected](https://reference.aspose.com/slides/zh/python-net/aspose.slides/protectionmanager/)属性，如果演示文稿已写保护则返回 `True`，否则返回 `False`。

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **验证或确认已使用特定密码保护演示文稿**

您可能想要检查并确认已使用特定密码保护演示文稿。Aspose.Slides 提供了验证密码的手段。

此示例代码展示了如何验证密码：

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # 检查 "pass" 是否匹配
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

如果使用指定密码加密了演示文稿，则返回 `True`；否则返回 `False`。

{{% alert color="primary" title="另请参阅" %}} 
- [PowerPoint 中的数字签名](/slides/zh/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**Aspose.Slides 支持哪些加密方法？**

Aspose.Slides 支持包括基于 AES 的算法在内的现代加密方法，确保演示文稿的数据安全性达到高水平。

**尝试打开演示文稿时输入错误密码会怎样？**

如果使用错误密码，系统会抛出异常，提示访问演示文稿被拒绝。这有助于防止未经授权的访问并保护演示文稿内容。

**在处理受密码保护的演示文稿时是否会有性能影响？**

加密和解密过程可能会在打开和保存操作期间引入轻微的开销。在大多数情况下，这种性能影响是最小的，不会显著影响演示文稿任务的整体处理时间。