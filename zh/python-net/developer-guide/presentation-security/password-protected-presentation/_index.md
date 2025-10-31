---
title: 使用 Python 通过密码保护演示文稿
linktitle: 密码保护
type: docs
weight: 20
url: /zh/python-net/password-protected-presentation/
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
- 演示文稿 安全
- 删除密码
- 删除保护
- 删除加密
- 禁用密码
- 禁用保护
- 删除写保护
- PowerPoint 演示文稿
- Python
- Aspose.Slides
description: 了解如何使用 Aspose.Slides for Python via .NET 轻松锁定和解锁受密码保护的 PowerPoint 和 OpenDocument 演示文稿。通过我们的分步指南提升工作效率并保护您的演示文稿。
---

## **关于密码保护**
### **演示文稿的密码保护如何工作？**
当您对演示文稿进行密码保护时，意味着您设置了一个密码来强制对演示文稿施加特定限制。要解除这些限制，需要输入密码。受密码保护的演示文稿被视为已锁定的演示文稿。

通常，您可以设置密码来对演示文稿强制以下限制：

- **修改**

  如果您希望只有特定用户能够修改您的演示文稿，您可以设置修改限制。此限制阻止人们在未提供密码的情况下修改、更改或复制演示文稿中的内容。

  然而，在这种情况下，即使没有密码，用户仍然可以访问并打开文档。以只读模式，用户可以查看内容或诸如超链接、动画、效果等，但无法复制项目或保存演示文稿。

- **打开**

  如果您希望只有特定用户可以打开您的演示文稿，您可以设置打开限制。此限制阻止人们查看演示文稿的内容（除非提供密码）。

  从技术上讲，打开限制同样阻止用户修改您的演示文稿：当人们无法打开演示文稿时，他们也无法对其进行修改或更改。

  **注意** 当您对演示文稿进行密码保护以阻止打开时，演示文稿文件会被加密。

## 如何在线为演示文稿添加密码保护

1. 前往我们的 [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) 页面。 

   ![todo:image_alt_text](slides-lock.png)

2. 点击 **拖放或上传文件**。

3. 在电脑上选择您想要进行密码保护的文件。 

4. 输入您用于编辑保护的首选密码；输入您用于查看保护的首选密码。 

5. 如果希望用户将演示文稿视为最终稿，请勾选 **标记为最终稿** 复选框。

6. 点击 **立即保护**。 

7. 点击 **立即下载**。

## **Aspose.Slides 中的演示文稿密码保护**
**支持的格式**

Aspose.Slides 支持对以下格式的演示文稿进行密码保护、加密及类似操作：

- PPTX 和 PPT - Microsoft PowerPoint 演示文稿 
- ODP - OpenDocument 演示文稿 
- OTP - OpenDocument 演示文稿模板 

**支持的操作**

Aspose.Slides 允许您通过以下方式对演示文稿使用密码保护以防止修改：

- 加密演示文稿
- 对演示文稿设置写保护

**其他操作**

Aspose.Slides 允许您以以下方式执行其他涉及密码保护和加密的任务：

- 解密演示文稿；打开加密的演示文稿
- 删除加密；禁用密码保护
- 从演示文稿中删除写保护
- 获取加密演示文稿的属性
- 检查演示文稿是否已加密
- 检查演示文稿是否受密码保护

## **加密演示文稿**

您可以通过设置密码来加密演示文稿。随后，要修改已锁定的演示文稿，用户必须提供密码。

要加密或对演示文稿进行密码保护，您必须使用 encrypt 方法（来自 [ProtectionManager](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)）为演示文稿设置密码。将密码传递给 encrypt 方法，并使用 save 方法保存已加密的演示文稿。

以下示例代码演示了如何加密演示文稿：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **对演示文稿设置写保护**

您可以添加“请勿修改”的标记到演示文稿。这样，您可以告诉用户您不希望他们对演示文稿进行更改。

**注意** 写保护过程并不会对演示文稿进行加密。因此，用户如果真的想修改演示文稿，仍然可以进行修改，但要保存更改，他们必须以不同的名称创建演示文稿。

要设置写保护，您必须使用 setWriteProtection 方法。以下示例代码演示了如何对演示文稿设置写保护：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **解密演示文稿；打开加密的演示文稿**

Aspose.Slides 允许您通过传递密码加载加密文件。要解密演示文稿，您必须调用 [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) 方法且不带参数。随后，您需要输入正确的密码以加载演示文稿。

以下示例代码演示了如何解密演示文稿： 

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **删除加密；禁用密码保护**

您可以删除演示文稿的加密或密码保护。这样，用户即可在没有限制的情况下访问或修改演示文稿。

要删除加密或密码保护，您必须调用 [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) 方法。以下示例代码演示了如何从演示文稿中删除加密：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **从演示文稿中删除写保护**

您可以使用 Aspose.Slides 删除演示文稿文件上的写保护。这样，用户可以随意修改，并且在执行此类操作时不会收到任何警告。

您可以通过使用 [remove_write_protection](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) 方法删除演示文稿的写保护。以下示例代码演示了如何从演示文稿中删除写保护：

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **获取加密演示文稿的属性**

通常，用户很难获取加密或受密码保护的演示文稿的文档属性。然而，Aspose.Slides 提供了一种机制，允许您在对演示文稿进行密码保护的同时，仍保留用户访问该演示文稿属性的方式。

**注意** 当 Aspose.Slides 加密演示文稿时，演示文稿的文档属性默认也会被密码保护。但如果您需要在演示文稿加密后仍能访问其属性，Aspose.Slides 允许您实现此目的。

如果您希望用户在您加密的演示文稿中仍能访问属性，可将 [EncryptDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) 属性设为 `True`。以下示例代码演示了在加密演示文稿的同时，提供用户访问文档属性的方式：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```

## **在加载演示文稿前检查是否受密码保护**

在加载演示文稿之前，您可能想检查并确认演示文稿未被密码保护。这样可以避免在未提供密码的情况下加载受密码保护的演示文稿时出现错误等问题。

以下 Python 代码演示了如何检查演示文稿是否受密码保护（无需加载演示文稿本身）：

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **检查演示文稿是否已加密**

Aspose.Slides 允许您检查演示文稿是否已加密。要执行此操作，您可以使用 [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) 属性，如果演示文稿已加密则返回 `True`，否则返回 `False`。

以下示例代码演示了如何检查演示文稿是否已加密：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **检查演示文稿是否写保护**

Aspose.Slides 允许您检查演示文稿是否写保护。要执行此操作，您可以使用 [is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) 属性，如果演示文稿已写保护则返回 `True`，否则返回 `False`。

以下示例代码演示了如何检查演示文稿是否写保护：

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **验证或确认已使用特定密码保护演示文稿**

您可能想检查并确认已使用特定密码保护演示文稿。Aspose.Slides 提供了验证密码的功能。

以下示例代码演示了如何验证密码：

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # 检查"pass"是否匹配
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

如果演示文稿使用指定密码加密，则返回 `True`。否则，返回 `False`。 

{{% alert color="primary" title="另请参阅" %}} 
- [PowerPoint 中的数字签名](/slides/zh/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**Aspose.Slides 支持哪些加密方法？**

Aspose.Slides 支持包括基于 AES 的算法在内的现代加密方法，为您的演示文稿提供高级别的数据安全性。

**在尝试打开演示文稿时输入错误密码会发生什么？**

如果使用了错误的密码，将抛出异常，提示您访问演示文稿被拒绝。这有助于防止未经授权的访问并保护演示文稿内容。

**在使用受密码保护的演示文稿时是否会有性能影响？**

加密和解密过程可能在打开和保存操作时带来轻微的开销。在大多数情况下，这种性能影响很小，不会显著影响演示文稿任务的整体处理时间。