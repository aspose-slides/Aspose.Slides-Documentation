---
title: C++ 中的演示文稿密码保护
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
description: "在 C++ 中使用 Aspose.Slides 加密、检测、验证、打开和解密受密码保护的 PowerPoint PPT 和 PPTX 演示文稿。"
---
## **概述**

打开密码会加密演示文稿。必须提供正确的密码才能加载并查看演示文稿内容，因此此保护提供机密性。

打开密码不同于写保护密码。写保护限制修改，但不加密内容或阻止演示文稿加载。要管理修改演示文稿的密码，请参阅[写保护演示文稿](/slides/zh/cpp/write-protected-presentation/)。

以下工作流适用于 PPT 和 PPTX 演示文稿。示例在文件方式和流方式行为重要的情况下使用两种格式。

## **使用打开密码加密演示文稿**

使用[IProtectionManager::Encrypt](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iprotectionmanager/encrypt/)分配打开密码。然后使用[IPresentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/save/)持久化加密后的演示文稿。

下面的示例加密一个 PPTX 演示文稿：

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

## **保持文档属性公开**

默认情况下，Aspose.Slides 会在演示文稿加密中包含文档属性。[IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/)独立于幻灯片内容加密控制此行为。在需要索引、分类、搜索或文档管理系统在没有打开密码的情况下读取元数据时，在调用[IProtectionManager::Encrypt](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iprotectionmanager/encrypt/)前将此方法的参数设为`false`。

下面的示例创建一个加密的 PPTX 演示文稿，同时保持其内置文档属性公开：

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto properties = presentation->get_DocumentProperties();
properties->set_Author(u"Contoso Knowledge Management");
properties->set_Title(u"Quarterly Product Roadmap");
properties->set_Keywords(u"roadmap, planning, internal");

presentation->get_Slide(0)->set_Name(u"Encrypted presentation content");
presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"public-properties-encrypted.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

将`false`传递给`set_EncryptDocumentProperties`不会使幻灯片、母版、布局、形状、媒体或其他演示文稿内容公开。它仅影响文档属性。要在不加载加密内容的情况下读取这些属性，请参阅[管理演示文稿属性](/slides/zh/cpp/presentation-properties/)。

## **加载加密的演示文稿**

将[LoadOptions::set_Password](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/set_password/)设为打开密码，并在加载文件时将该选项传递给[Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/)。当需要打开密码但提供的密码缺失或不正确时，加载将失败。

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// 使用已解密的演示文稿进行操作。
```

## **从演示文稿中移除加密**

使用打开密码加载演示文稿，调用[IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iprotectionmanager/removeencryption/)，并保存结果。随后保存的演示文稿即可在不提供密码的情况下加载。

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

使用[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/)获取[IPresentationInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/)而无需创建完整的演示文稿实例。在请求或验证密码之前检查[IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/)。当存在保护时，使用[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/checkpassword/)验证提供的值。

### **文件路径工作流**

下面的示例验证 PPTX 文件的打开密码，将验证后的值传递给[LoadOptions::set_Password](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/set_password/)，然后加载完整的演示文稿：

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

[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/)的流重载提供相同的工作流。在从该流加载完整演示文稿之前，重置可寻址流的位置。

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

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/checkpassword/)仅在演示文稿具有打开密码且提供的密码正确时返回`true`。在以下每种情况中返回`false`：

- 密码不正确。
- 演示文稿没有打开密码。
- 提供的密码为 null 或为空。

对于 PPT 和 PPTX 演示文稿，行为相同。

## **检查已加载的演示文稿是否已加密**

使用正确密码加载演示文稿后，检查[IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iprotectionmanager/get_isencrypted/)以确认源演示文稿已加密。要在加载前检测打开密码保护，请使用`IPresentationInfo::get_IsPasswordProtected`，如上所示。

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

{{% alert color="warning" title="安全" %}}
不要记录打开密码或将其包含在诊断信息中。避免不必要的重复验证尝试，密码仅在需要时保留在内存中，并在立即加载演示文稿时复用成功的验证结果。

即使演示文稿内容已加密，公开的文档属性仍可能泄露作者姓名、标题、主题、关键字、公司信息、备注以及自定义值。请将敏感的元数据与演示文稿一起加密。仅在系统必须在没有打开密码的情况下对文件进行索引、分类、搜索或管理时，才应明确决定将属性保持公开。
{{% /alert %}}

## **在线对演示文稿进行密码保护**

1. 打开[Aspose.Slides Lock](https://products.aspose.app/slides/zh/lock)应用程序。
2. 选择或上传演示文稿。
3. 输入用于查看保护的密码。
4. （可选）输入用于编辑保护的单独密码。
5. 应用保护并下载生成的文件。

{{% alert color="info" title="另见" %}}
- [写保护演示文稿](/slides/zh/cpp/write-protected-presentation/)
- [PowerPoint 中的数字签名](/slides/zh/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**打开密码和写保护密码有什么区别？**

打开密码会加密演示文稿，并在加载其内容时需要提供。写保护密码限制修改但不加密内容。

**我能在不加载所有幻灯片的情况下验证打开密码吗？**

可以。获取演示文稿信息，检查是否存在打开密码保护，然后在创建完整演示文稿实例之前验证密码。

**应用程序能在没有打开密码的情况下读取元数据吗？**

可以，但仅在演示文稿使用`set_EncryptDocumentProperties(false)`加密时。此时应用程序必须使用[管理演示文稿属性](/slides/zh/cpp/presentation-properties/)中描述的仅加载文档属性的模式。

**密码检查工作流是否同时支持 PPT 和 PPTX？**

支持。文件路径和基于流的密码检测与验证对 PPT 和 PPTX 演示文稿的行为相同。