---
title: 在 Python 中对演示文稿进行密码保护
linktitle: 密码保护
type: docs
weight: 20
url: /zh/python-java/password-protected-presentation/
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
description: "使用 Aspose.Slides for Python via Java 对受密码保护的 PowerPoint PPT 和 PPTX 演示文稿进行加密、检测、验证、打开和解密。"
---
## **概述**

打开密码对演示文稿进行加密。加载并查看演示文稿内容时需要正确的密码，因此此保护提供了机密性。

打开密码不同于写保护密码。写保护限制修改但不加密内容，也不阻止演示文稿被加载。要管理用于修改演示文稿的密码，请参阅[写保护演示文稿](/slides/zh/python-java/write-protected-presentation/)。

以下工作流适用于 PPT 和 PPTX 演示文稿。示例在文件和流两种情况下均展示了行为差异。

## **使用打开密码加密演示文稿**

使用[ProtectionManager.encrypt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/protectionmanager/#encrypt)分配打开密码。然后使用[Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save)持久化加密后的演示文稿。

下面的示例对 PPTX 演示文稿进行加密：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **将文档属性设为公开**

默认情况下，Aspose.Slides 在演示文稿加密时会包含文档属性。[ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties)方法可独立控制此行为。若索引、分类、搜索或文档管理系统需要在不提供打开密码的情况下读取元数据，请在调用[ProtectionManager.encrypt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/protectionmanager/#encrypt)前传入`False`。

下面的示例创建一个加密的 PPTX 演示文稿，同时保持其内置文档属性公开：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    properties = presentation.getDocumentProperties()
    properties.setAuthor("Contoso Knowledge Management")
    properties.setTitle("Quarterly Product Roadmap")
    properties.setKeywords("roadmap, planning, internal")

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content")
    presentation.getProtectionManager().setEncryptDocumentProperties(False)
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

将`False`传递给[ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties)不会使幻灯片、母版、布局、形状、媒体或其他演示文稿内容公开。它仅影响文档属性。若在不加载加密内容的情况下读取这些属性，请参阅[管理演示文稿属性](/slides/zh/python-java/presentation-properties/)。

## **加载加密的演示文稿**

将[LoadOptions.setPassword](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#setPassword)设置为打开密码，并在加载文件时将该选项传递给[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/)。如果需要打开密码但未提供或提供的密码不正确，加载将失败。

```python
import jpade
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # 在已解密的演示文稿上进行操作。
    pass
finally:
    presentation.dispose()
```

## **移除演示文稿的加密**

使用打开密码加载演示文稿，调用[ProtectionManager.removeEncryption](https://reference.aspose.com/slides/zh/python-java/aspose.slides/protectionmanager/#removeEncryption)，然后保存结果。保存后的演示文稿即可在不提供密码的情况下加载。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    presentation.getProtectionManager().removeEncryption()
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在加载前验证打开密码**

使用[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationfactory/#getPresentationInfo)获取[PresentationInfo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/)，无需创建完整的演示文稿实例。加载或验证密码前，请检查[PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#isPasswordProtected)。如果存在保护，则使用[PresentationInfo.checkPassword](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#checkPassword)验证提供的密码。

### **文件路径工作流**

下面的示例验证 PPTX 文件的打开密码，将验证后的值传递给[LoadOptions.setPassword](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#setPassword)，然后加载完整的演示文稿：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)

if not presentation_info.isPasswordProtected():
    print("The presentation does not have an opening password.")
elif not presentation_info.checkPassword(password):
    print("The opening password is incorrect.")
else:
    load_options = LoadOptions()
    load_options.setPassword(password)

    presentation = Presentation(file_path, load_options)
    try:
        print("The presentation was validated and loaded successfully.")
    finally:
        presentation.dispose()
```

### **流工作流**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationfactory/#getPresentationInfo)的流重载提供相同的工作流。在从流中加载完整演示文稿之前，请重置可寻址流的位置。

下面的示例使用 PPT 文件：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

FileInputStream = jpype.JClass("java.io.FileInputStream")

password = "open_password"

presentation_stream = FileInputStream("protected-presentation.ppt")
try:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(presentation_stream)

    if not presentation_info.isPasswordProtected():
        print("The presentation does not have an opening password.")
    elif not presentation_info.checkPassword(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.getChannel().position(0)

        load_options = LoadOptions()
        load_options.setPassword(password)

        presentation = Presentation(presentation_stream, load_options)
        try:
            print("The presentation was validated and loaded successfully.")
        finally:
            presentation.dispose()
finally:
    presentation_stream.close()
```

### **checkPassword 返回值**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#checkPassword)仅在演示文稿具有打开密码且提供的密码正确时返回`True`。在以下情况下返回`False`：

- 密码不正确。
- 演示文稿没有打开密码。
- 提供的密码为`None`或为空。

PPT 和 PPTX 演示文稿的行为相同。

## **检查已加载的演示文稿是否已加密**

在使用正确密码加载演示文稿后，检查[ProtectionManager.isEncrypted](https://reference.aspose.com/slides/zh/python-java/aspose.slides/protectionmanager/#isEncrypted)以确认源演示文稿已加密。若想在加载前检测打开密码保护，请使用上文示例中的[PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#isPasswordProtected)。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    is_encrypted = presentation.getProtectionManager().isEncrypted()
    print(f"The presentation is encrypted: {is_encrypted}")
finally:
    presentation.dispose()
```

## **安全建议**

{{% alert color="warning" title="Security" %}}
不要记录打开密码或将其包含在诊断消息中。避免不必要的重复验证尝试，仅在需要时将密码保留在内存中，并在立即加载演示文稿时复用成功的验证结果。

公开的文档属性可能泄露作者姓名、标题、主题、关键字、公司信息、注释和自定义值，即使演示文稿内容已加密。请将敏感元数据与演示文稿一起加密。仅在系统必须在没有打开密码的情况下对文件进行索引、分类、搜索或管理时，才明确决定将属性设为公开。
{{% /alert %}}

## **在线为演示文稿设置密码保护**

1. 打开[Aspose.Slides Lock](https://products.aspose.app/slides/zh/lock)应用。
1. 选择或上传演示文稿。
1. 输入用于查看保护的密码。
1. （可选）输入用于编辑保护的另一个密码。
1. 应用保护并下载生成的文件。

{{% alert color="info" title="See also" %}}
- [写保护演示文稿](/slides/zh/python-java/write-protected-presentation/)
- [PowerPoint 中的数字签名](/slides/zh/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**打开密码与写保护密码有何区别？**

打开密码会加密演示文稿并在加载其内容时必需。写保护密码限制修改但不加密内容。

**是否可以在不加载所有幻灯片的情况下验证打开密码？**

可以。获取演示文稿信息，检查是否存在打开密码保护，然后在创建完整演示文稿实例前验证密码。

**应用程序能否在没有打开密码的情况下读取元数据？**

可以，但前提是演示文稿在加密时已禁用文档属性加密。此时应用程序需使用[管理演示文稿属性](/slides/zh/python-java/presentation-properties/)中描述的仅加载文档属性模式。

**密码检查工作流是否同时支持 PPT 和 PPTX？**

是的。基于文件路径和基于流的密码检测与验证在 PPT 和 PPTX 演示文稿中表现一致。