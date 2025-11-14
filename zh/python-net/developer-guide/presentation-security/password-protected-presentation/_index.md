---
title: 使用 Python 为演示文稿设置密码保护
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
description: "了解如何使用 Aspose.Slides for Python via .NET 轻松锁定和解锁受密码保护的 PowerPoint 和 OpenDocument 演示文稿。通过我们的分步指南提升你的工作效率并保护你的演示文稿。"
---


## **关于密码保护**
### **演示文稿的密码保护是如何工作的？**
当你为演示文稿设置密码保护时，这意味着你正在设置一个密码，以强制对演示文稿施加某些限制。要移除这些限制，必须输入密码。密码保护的演示文稿被视为锁定的演示文稿。

通常，你可以设置密码来对演示文稿施加以下限制：

- **修改**

  如果你只想让特定用户修改你的演示文稿，你可以设置修改限制。此限制防止人们修改、更改或复制你演示文稿中的内容（除非他们提供密码）。

  然而，在这种情况下，即使没有密码，用户也能够访问你的文档并打开它。在这种只读模式下，用户可以查看演示文稿中的内容或内容——超链接、动画、效果等——但他们无法复制项目或保存演示文稿。

- **打开**

  如果你只想让特定用户打开你的演示文稿，则可以设置打开限制。此限制阻止人们甚至查看你演示文稿的内容（除非他们提供密码）。

  从技术上讲，打开限制也防止用户修改你的演示文稿：当人们无法打开演示文稿时，他们无法对其进行修改或更改。

  **注意** 当你为演示文稿设置密码保护以防止打开时，演示文稿文件会被加密。

## 如何在线为演示文稿设置密码保护

1. 前往我们的 [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) 页面。

   ![todo:image_alt_text](slides-lock.png)

2. 点击 **拖放或上传你的文件**。

3. 选择你想在计算机上设置密码保护的文件。

4. 输入你希望用于编辑保护的密码； 输入你希望用于查看保护的密码。

5. 如果你希望用户看到你演示文稿的最终版本，请勾选 **标记为最终** 复选框。

6. 点击 **现在保护。**

7. 点击 **立即下载。**

## **Aspose.Slides 的演示文稿密码保护**
**支持的格式**

Aspose.Slides 支持对以下格式的演示文稿进行密码保护、加密和类似操作：

- PPTX 和 PPT - Microsoft PowerPoint 演示文稿
- ODP - OpenDocument 演示文稿
- OTP - OpenDocument 演示文稿模板

**支持的操作**

Aspose.Slides 允许你对演示文稿使用密码保护，以防止以以下方式进行修改：

- 加密演示文稿
- 对演示文稿设置写保护

**其他操作**

Aspose.Slides 允许你以以下方式执行其他涉及密码保护和加密的任务：

- 解密演示文稿；打开加密演示文稿
- 移除加密；禁用密码保护
- 从演示文稿中移除写保护
- 获取加密演示文稿的属性
- 检查演示文稿是否加密
- 检查演示文稿是否受密码保护。

## **加密演示文稿**

你可以通过设置密码来加密演示文稿。然后，要修改锁定的演示文稿，用户必须提供密码。

要加密或设置密码保护演示文稿，你必须使用 encrypt 方法（来自 [ProtectionManager](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)）为演示文稿设置密码。你将密码传递给 encrypt 方法，并使用 save 方法保存现在已加密的演示文稿。

以下示例代码演示了如何加密演示文稿：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **为演示文稿设置写保护**

你可以在演示文稿中添加一条“请勿修改”的标记。通过这种方式，你可以告知用户你不希望他们对演示文稿进行更改。

**注意** 写保护过程并不会加密演示文稿。因此，用户——如果他们确实想要——可以修改演示文稿，但要保存更改，他们需要创建一个不同名称的演示文稿。

要设置写保护，你必须使用 setWriteProtection 方法。以下示例代码演示了如何对演示文稿设置写保护：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **解密演示文稿；打开加密演示文稿**

Aspose.Slides 允许你通过输入密码加载一个加密文件。要解密演示文稿，你必须调用 [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) 方法，不带参数。然后你必须输入正确的密码以加载演示文稿。

以下示例代码展示了如何解密演示文稿：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **移除加密；禁用密码保护**

你可以移除演示文稿上的加密或密码保护。通过这种方式，用户能够在没有限制的情况下访问或修改演示文稿。

要移除加密或密码保护，你必须调用 [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) 方法。以下示例代码展示了如何从演示文稿中移除加密：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **从演示文稿中移除写保护**

你可以使用 Aspose.Slides 从演示文稿文件中移除写保护。这样，用户可以随意修改——在执行这些操作时不会收到警告。

你可以使用 [remove_write_protection](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) 方法从演示文稿中移除写保护。以下示例代码演示了如何从演示文稿中移除写保护：

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **获取加密演示文稿的属性**

通常，用户很难获取加密或受密码保护的演示文稿的文档属性。然而，Aspose.Slides 提供了一种机制，使你在密码保护演示文稿的同时，允许用户访问该演示文稿的属性。

**注意** 当 Aspose.Slides 加密演示文稿时，演示文稿的文档属性默认也会被密码保护。但如果你需要使演示文稿的属性可访问（即使在演示文稿被加密后），Aspose.Slides 允许你做到这一点。

如果你希望用户保留访问已加密演示文稿属性的能力，你可以将 [EncryptDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) 属性设置为 `True`。以下示例代码演示了如何在加密演示文稿的同时，提供用户访问其文档属性的手段：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```

## **在加载演示文稿前检查其是否受密码保护**

在加载演示文稿之前，你可能想检查并确认演示文稿是否未受密码保护。通过这种方式，你可以避免错误和类似问题，这些问题会在未提供密码时加载受密码保护的演示文稿时出现。

以下 Python 代码展示了如何检查演示文稿是否受密码保护（无需加载演示文稿本身）：

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("演示文稿是否受密码保护: " + str(presentationInfo.is_password_protected))
```

## **检查演示文稿是否加密**

Aspose.Slides 允许你检查演示文稿是否加密。要执行此任务，你可以使用 [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) 属性，如果演示文稿已加密，则返回 `True`，如果演示文稿未加密，则返回 `False`。

以下示例代码演示了如何检查演示文稿是否加密：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **检查演示文稿是否写保护**

Aspose.Slides 允许你检查演示文稿是否写保护。要执行此任务，你可以使用 [is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) 属性，如果演示文稿已加密，则返回 `True`，如果演示文稿未加密，则返回 `False`。

以下示例代码演示了如何检查演示文稿是否写保护：

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **验证或确认某个特定密码是否用于保护演示文稿**

你可能想检查并确认某个特定密码是否用于保护演示文稿。Aspose.Slides 提供了验证密码的手段。

以下示例代码展示了如何验证一个密码：

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # 检查“pass”是否与其匹配
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

如果演示文稿已用指定密码加密，则返回 `True`。否则，返回 `False`。

{{% alert color="primary" title="另见" %}} 
- [PowerPoint 中的数字签名](/slides/zh/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}