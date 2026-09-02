---
title: 在 C++ 中对演示文稿进行密码保护
linktitle: 密码保护
type: docs
weight: 20
url: /zh/cpp/password-protected-presentation/
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中加密、检测、验证、打开和解密受密码保护的 PowerPoint PPT 和 PPTX 演示文稿。"
---
## **概述**

打开密码会对演示文稿进行加密。必须提供正确的密码才能加载并查看演示文稿内容，因此此保护提供了机密性。

打开密码不同于写保护密码。写保护限制修改，但不加密内容，也不阻止加载演示文稿。要管理用于修改演示文稿的密码，请参阅[Write-Protect Presentations](/slides/zh/cpp/write-protected-presentation/)。

以下工作流适用于 PPT 和 PPTX 演示文稿。示例同时使用两种格式，以体现文件和流方式的行为差异。

## **使用打开密码加密演示文稿**

使用[IProtectionManager::Encrypt](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iprotectionmanager/encrypt/)为演示文稿分配打开密码。然后使用[IPresentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/save/)持久化加密后的演示文稿。

下面的示例对 PPTX 演示文稿进行加密：

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **加载加密的演示文稿**

将[LoadOptions::set_Password](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/set_password/)设置为打开密码，并在加载文件时将该选项传递给[Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/)。如果需要打开密码但未提供或提供的密码不正确，则加载会失败。

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// 使用已解密的演示文稿进行操作。
```

## **移除演示文稿的加密**

使用打开密码加载演示文稿，调用[IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iprotectionmanager/removeencryption/)，然后保存结果。保存后的演示文稿随后即可在不提供密码的情况下加载。

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **在加载前验证打开密码**

使用[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/)获取[IPresentationInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/)，无需创建完整的演示文稿实例。请求或验证密码前，请检查[IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/)。当存在保护时，使用[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/checkpassword/)验证提供的值。

### **文件路径工作流**

下面的示例验证 PPTX 文件的打开密码，将验证后的值传递给[LoadOptions::set_Password](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/set_password/)，随后加载完整的演示文稿：

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

String filePath = u"protected-presentation.pptx";
String password = u"open_password";
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(filePath, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **流工作流**

[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) 的流重载提供相同的工作流。在从该流加载完整演示文稿之前，请先重置可定位流的位置。

下面的示例使用 PPT 文件：

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

String password = u"open_password";
auto presentationStream = File::OpenRead(u"protected-presentation.ppt");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(presentationStream);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    presentationStream->set_Position(0);

    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(presentationStream, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **CheckPassword 返回值**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/checkpassword/)仅在演示文稿具有打开密码且提供的密码正确时返回`true`。在以下任一情况下返回`false`：

- 密码不正确。
- 演示文稿没有打开密码。
- 提供的密码为 null 或为空。

PPT 和 PPTX 演示文稿的行为相同。

## **检查已加载的演示文稿是否已加密**

使用正确的密码加载演示文稿后，检查[IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iprotectionmanager/get_isencrypted/)以确认源演示文稿已加密。若要在加载前检测打开密码保护，请如上使用`IPresentationInfo::get_IsPasswordProtected`。

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");
auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
Console::WriteLine(isEncrypted ? u"The presentation is encrypted." : u"The presentation is not encrypted.");
```

## **安全建议**

{{% alert color="warning" title="Security" %}}
不要记录打开密码或将其包含在诊断信息中。避免不必要的重复验证尝试，仅在需要时在内存中保留密码，并在立即加载演示文稿时复用成功的验证结果。
{{% /alert %}}

## **在线对演示文稿进行密码保护**

1. 打开[Aspose.Slides Lock](https://products.aspose.app/slides/zh/lock)应用。
1. 选择或上传演示文稿。
1. 输入用于查看保护的密码。
1. （可选）输入用于编辑保护的另一个密码。
1. 应用保护并下载生成的文件。

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/zh/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/zh/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题解答**

**打开密码与写保护密码有什么区别？**

打开密码会对演示文稿进行加密，并且在加载其内容时必须提供该密码。写保护密码仅限制修改，不会加密内容。

**是否可以在不加载所有幻灯片的情况下验证打开密码？**

可以。获取演示文稿信息，检查是否存在打开密码保护，然后在创建完整演示文稿实例之前验证密码。

**密码检查工作流是否同时支持 PPT 和 PPTX？**

是的。文件路径和基于流的密码检测与验证对 PPT 和 PPTX 演示文稿的行为相同。