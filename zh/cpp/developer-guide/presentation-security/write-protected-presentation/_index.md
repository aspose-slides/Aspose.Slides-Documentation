---
title: C++ 中的演示文稿写保护
linktitle: 写保护
type: docs
weight: 25
url: /zh/cpp/write-protected-presentation/
keywords:
- 写保护
- PowerPoint 写保护
- 修改密码
- 限制演示文稿编辑
- 移除写保护
- 验证修改密码
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint PPT 和 PPTX 演示文稿中设置、检测、验证和移除写保护密码。"
---
## **简介**

写保护密码限制对演示文稿的修改，但不加密其内容。用户可以在不提供密码的情况下加载和查看受写保护的演示文稿。根据应用程序的不同，他们甚至可能编辑内容并另存为其他名称，因此写保护不应被视为机密性机制。

打开密码的用途不同：它加密演示文稿，并且在加载其内容时是必需的。要加密演示文稿或验证打开密码，请参阅[受密码保护的演示文稿](/slides/zh/cpp/password-protected-presentation/)。

本文中的工作流适用于 PPT 和 PPTX 演示文稿。示例使用 PPTX 文件；保存为 PPT 时，请使用 `.ppt` 扩展名和相应的 PPT 保存格式。

## **在演示文稿上设置写保护**

使用[IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iprotectionmanager/setwriteprotection/)为修改演示文稿分配密码。保存演示文稿会保留保护设置。

以下示例在 PPTX 演示文稿上设置写保护：

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"modify_password");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **加载受写保护的演示文稿**

由于写保护不加密演示文稿内容，加载演示文稿时不需要密码。密码仅在验证对受保护演示文稿的修改授权时才相关。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

不要将写保护密码传递给[LoadOptions::set_Password](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/set_password/)。该属性接受用于加密内容的打开密码。如果演示文稿同时具有两种保护类型，请提供打开密码以加载它，并单独处理写保护密码。

## **从演示文稿中移除写保护**

使用[IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iprotectionmanager/removewriteprotection/)移除修改限制，然后保存演示文稿。

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"write-protected-pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **检查演示文稿是否已写保护**

要在不创建完整[Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/)实例的情况下检查文件，请调用[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/)并检查[IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/)。该属性使用[NullableBool](https://reference.aspose.com/slides/zh/cpp/aspose.slides/nullablebool/)并在检测到写保护时返回`NullableBool::True`。

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() == NullableBool::True)
{
    Console::WriteLine(u"The presentation is write protected.");
}
else
{
    Console::WriteLine(u"Write protection was not detected.");
}
```

[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) 的流重载为以流形式提供的演示文稿提供相同的信息。

## **验证写保护密码**

使用[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/)在不加载完整演示文稿的情况下验证修改密码。首先检查[IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/)，以便仅在存在写保护时请求或验证密码。

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() != NullableBool::True)
{
    Console::WriteLine(u"The presentation is not write protected.");
}
else if (presentationInfo->CheckWriteProtection(u"modify_password"))
{
    Console::WriteLine(u"The write-protection password is correct.");
}
else
{
    Console::WriteLine(u"The write-protection password is incorrect.");
}
```

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/)仅验证写保护密码。它不验证打开密码，也不确定是否可以加载加密内容。相反，[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/checkpassword/)仅验证打开密码。如果已经加载了完整的演示文稿，[IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/)通过其保护管理器提供等效的写保护检查。

在生产环境中，请勿记录密码或将其包含在诊断消息中。避免不必要的重复验证尝试，并仅在需要时在内存中保留密码。

{{% alert color="info" title="另请参阅" %}}
- [受密码保护的演示文稿](/slides/zh/cpp/password-protected-presentation/)
- [只读演示文稿](/slides/zh/cpp/read-only-presentation/)
- [PowerPoint 中的数字签名](/slides/zh/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**写保护会加密演示文稿吗？**

不会。它限制修改，但仍可加载和查看演示文稿内容。

**打开演示文稿是否需要写保护密码？**

不需要。仅需要打开密码来加载加密的演示文稿内容。

**演示文稿可以同时具有打开密码和写保护密码吗？**

可以。通过加载选项提供打开密码以打开加密的演示文稿，在需要修改授权时单独验证写保护密码。