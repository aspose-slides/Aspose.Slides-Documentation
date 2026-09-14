---
title: 在 Python 中对演示文稿进行写保护
linktitle: 写保护
type: docs
weight: 25
url: /zh/python-java/write-protected-presentation/
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
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint PPT 和 PPTX 演示文稿中设置、检测、验证和移除写保护密码。"
---
## **介绍**

写保护密码限制对演示文稿的修改，但不加密其内容。用户可以在没有密码的情况下加载并查看受写保护的演示文稿。根据具体应用，他们甚至可能编辑内容并另存为不同的文件名，因此写保护不应被视为保密机制。

打开密码的作用不同：它会加密演示文稿，加载内容时必须提供。有关加密演示文稿或验证打开密码，请参阅[Password-Protect Presentations](/slides/zh/python-java/password-protected-presentation/)。

本文档中的工作流适用于 PPT 和 PPTX 演示文稿。示例使用 PPTX 文件；保存为 PPT 时，请使用 `.ppt` 扩展名和相应的 PPT 保存格式。

## **在演示文稿上设置写保护**

使用[ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/protectionmanager/#setWriteProtection)为演示文稿分配修改密码。保存演示文稿后，保护设置会被持久化。

下面的示例在 PPTX 演示文稿上设置写保护：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **加载受写保护的演示文稿**

由于写保护不加密演示文稿内容，加载演示文稿时不需要密码。密码仅在验证对受保护演示文稿的修改授权时才相关。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

不要将写保护密码传递给[LoadOptions.setPassword](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#setPassword)。该方法接受用于加密内容的打开密码。如果演示文稿同时具有两种保护类型，请在加载时提供打开密码，并单独处理写保护密码。

## **从演示文稿中移除写保护**

使用[ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/protectionmanager/#removeWriteProtection)移除修改限制，然后保存演示文稿。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **检查演示文稿是否受写保护**

若要在不创建完整[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/)实例的情况下检查文件，请调用[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationfactory/#getPresentationInfo)并检查[PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#isWriteProtected)。该方法使用[NullableBool](https://reference.aspose.com/slides/zh/python-java/aspose.slides/nullablebool/)并在检测到写保护时返回`NullableBool.True_`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 的流重载同样提供针对以流形式提供的演示文稿的相同信息。

## **验证写保护密码**

使用[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#checkWriteProtection)在不加载完整演示文稿的情况下验证修改密码。首先检查[PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#isWriteProtected)，仅在存在写保护时才请求或验证密码。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#checkWriteProtection)仅验证写保护密码。它不验证打开密码，也不判断是否可以加载加密内容。相反，[PresentationInfo.checkPassword](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#checkPassword)仅验证打开密码。如果已经加载完整演示文稿，[ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/protectionmanager/#checkWriteProtection)提供等效的写保护检查。

在生产环境中，请勿记录密码或将其包含在诊断信息中。避免不必要的重复验证，并仅在需要时将密码保留在内存中。

{{% alert color="info" title="另请参阅" %}}
- [Password-Protect Presentations](/slides/zh/python-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/zh/python-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/zh/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**写保护会加密演示文稿吗？**

不会。它限制修改，但仍然可以加载和查看演示文稿内容。

**打开演示文稿是否需要写保护密码？**

不需要。仅需要打开密码来加载加密的演示文稿内容。

**演示文稿可以同时拥有打开密码和写保护密码吗？**

可以。通过加载选项提供打开密码以打开加密的演示文稿，并在需要修改授权时单独验证写保护密码。