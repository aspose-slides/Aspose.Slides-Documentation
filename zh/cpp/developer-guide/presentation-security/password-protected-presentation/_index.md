---
title: 在 C++ 中使用密码保护演示文稿
linktitle: 密码保护
type: docs
weight: 20
url: /zh/cpp/password-protected-presentation/
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
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 轻松锁定和解锁受密码保护的 PowerPoint 和 OpenDocument 演示文稿。确保您的演示文稿安全。"
---
## **简介**

当您为演示文稿设置密码保护时，意味着您设置了一个密码来对演示文稿实施特定限制。要取消这些限制，必须输入密码。受密码保护的演示文稿被视为已锁定的演示文稿。

通常，您可以设置密码来对演示文稿实施这些限制：

- **修改**

  如果您只希望特定用户修改您的演示文稿，可以设置修改限制。此限制阻止人们修改、变更或复制演示文稿中的内容（除非提供密码）。

  但是，在这种情况下，即使没有密码，用户仍然可以访问并打开文档。在只读模式下，用户可以查看演示文稿中的内容或项目——超链接、动画、效果等——但无法复制项目或保存演示文稿。

- **打开**

  如果您只希望特定用户打开您的演示文稿，可以设置打开限制。此限制阻止人们查看演示文稿的内容（除非提供密码）。

  技术上，打开限制也会阻止用户修改演示文稿：当人们无法打开演示文稿时，就无法对其进行修改或更改。

  **注意** 当您对演示文稿设置密码以防止打开时，演示文稿文件会被加密。

## **如何在线对演示文稿进行密码保护**

1. 前往我们的[**Aspose.Slides Lock**](https://products.aspose.app/slides/zh/lock)页面。

   ![todo:image_alt_text](slides-lock.png)

2. 单击 **Drop or upload your files**。

3. 选择计算机上要进行密码保护的文件。

4. 输入用于编辑保护的首选密码；输入用于查看保护的首选密码。

5. 如果希望用户将演示文稿视为最终稿，请勾选 **Mark as final** 复选框。

6. 单击 **PROTECT NOW.**  

7. 单击 **DOWNLOAD NOW.**

## **Aspose.Slides 中的演示文稿密码保护**
**支持的格式**

Aspose.Slides 支持对以下格式的演示文稿进行密码保护、加密等操作：

- PPTX 和 PPT - Microsoft PowerPoint 演示文稿
- ODP - OpenDocument 演示文稿
- OTP - OpenDocument 演示文稿模板

**支持的操作**

Aspose.Slides 允许您通过以下方式使用密码保护来防止演示文稿被修改：

- 对演示文稿加密
- 为演示文稿设置写保护

**其他操作**

Aspose.Slides 还允许您以以下方式执行其他涉及密码保护和加密的任务：

- 解密演示文稿；打开加密的演示文稿
- 移除加密；禁用密码保护
- 移除演示文稿的写保护
- 获取加密演示文稿的属性
- 检查演示文稿是否已加密
- 检查演示文稿是否受密码保护。

## **加密演示文稿**

您可以通过设置密码来对演示文稿加密。随后，要修改已锁定的演示文稿，用户必须提供密码。

要加密或对演示文稿进行密码保护，您需要使用 [ProtectionManager](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.protection_manager) 的 encrypt 方法为演示文稿设置密码。将密码传递给 encrypt 方法，并使用 save 方法保存已加密的演示文稿。

以下示例代码展示了如何加密演示文稿：

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **为演示文稿设置写保护**

您可以在演示文稿中添加“请勿修改”的标记。这样，您可以告知用户不希望他们对演示文稿进行更改。

**注意** 写保护过程不会加密演示文稿。因此，用户——如果真的想——仍可以修改演示文稿，但若要保存更改，则必须另存为不同的文件名。

要设置写保护，您需要使用 setWriteProtection 方法。以下示例代码展示了如何为演示文稿设置写保护：

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **加载加密的演示文稿**

Aspose.Slides 允许您通过传递密码来加载加密文件。要解密演示文稿，您必须调用 [RemoveEncryption](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) 方法（无参数），随后输入正确的密码以加载演示文稿。

以下示例代码展示了如何解密演示文稿：

``` cpp
#include <DOM/LoadOptions.h>
using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// 使用已解密的演示文稿
```

## **从演示文稿中移除加密**

您可以移除演示文稿的加密或密码保护。这样，用户即可在不受限制的情况下访问或修改演示文稿。

要移除加密或密码保护，您需要调用 [RemoveEncryption](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) 方法。以下示例代码展示了如何从演示文稿中移除加密：

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **从演示文稿中移除写保护**

您可以使用 Aspose.Slides 移除演示文稿文件上的写保护。这样，用户可以自由修改，并且在执行此类操作时不会收到任何警告。

您可以通过调用 [RemoveWriteProtection](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50) 方法来移除写保护。以下示例代码展示了如何从演示文稿中移除写保护：

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **获取加密演示文稿的属性**

通常，用户在检索加密或受密码保护的演示文稿的文档属性时会遇到困难。不过，Aspose.Slides 提供了一种机制，允许您对演示文稿进行密码保护的同时仍能访问其文档属性。

**注意：** 默认情况下，当 Aspose.Slides 对演示文稿加密时，演示文稿的文档属性也会受到密码保护。如果您希望在加密后仍能访问文档属性，Aspose.Slides 允许您实现此功能。

如果您希望用户在加密演示文稿后仍能访问其属性，请向 [IProtectionManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iprotectionmanager/) 的 `set_EncryptDocumentProperties` 方法传递 `false`。以下示例代码展示了如何在仍提供文档属性访问权限的情况下加密演示文稿：

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **仅从加密演示文稿加载文档属性**

若想在不加载幻灯片或其他内容的情况下检查加密演示文稿的元数据，请创建一个 [LoadOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/) 对象并将 `set_OnlyLoadDocumentProperties` 设置为 `true`。在此模式下，Aspose.Slides 会忽略密码，仅加载公开可访问的文档属性。

下面的代码示例通过 [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/get_documentproperties/) 读取内置和自定义文档属性：

``` cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);
auto documentProperties = presentation->get_DocumentProperties();

// Read built-in document properties.
auto title = documentProperties->get_Title();
auto author = documentProperties->get_Author();
Console::WriteLine(String(u"Title: ") + title);
Console::WriteLine(String(u"Author: ") + author);

// Read custom document properties.
int customPropertyCount = documentProperties->get_CountOfCustomProperties();

for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(propertyIndex);
    auto propertyValue = documentProperties->idx_get(propertyName);
    auto propertyValueText = ObjectExt::ToString(propertyValue);

    Console::WriteLine(propertyName + u": " + propertyValueText);
}

presentation->Dispose();
```

此工作流仅在演示文稿加密时文档属性保持未加密（公开）时有效。如果文档属性已加密，将 `LoadOptions::set_OnlyLoadDocumentProperties` 设置为 `true` 会导致异常，因为在此模式下密码被忽略。若要访问加密的文档属性或加载包括幻灯片在内的完整演示文稿，请在 [LoadOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/) 中使用 `LoadOptions::set_Password` 提供正确的密码。

## **检查演示文稿是否受密码保护**

在加载演示文稿之前，您可能需要检查并确认该演示文稿未被密码保护。这样可以避免在未提供密码的情况下加载受密码保护的演示文稿时出现错误等问题。

以下 C++ 代码展示了如何在不加载演示文稿本身的情况下检查其是否受密码保护：

```c++
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **检查演示文稿是否已加密**

Aspose.Slides 允许您检查演示文稿是否已加密。为执行此操作，您可以使用 [get_IsEncrypted()](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) 方法，该方法在演示文稿已加密时返回 `true`，未加密时返回 `false`。

以下示例代码展示了如何检查演示文稿是否已加密：

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **检查演示文稿是否写保护**

Aspose.Slides 允许您检查演示文稿是否写保护。为执行此操作，您可以使用 [get_IsWriteProtected()](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) 方法，该方法在演示文稿写保护时返回 `true`，未写保护时返回 `false`。

以下示例代码展示了如何检查演示文稿是否写保护：

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **验证演示文稿密码使用情况**

您可能想要检查并确认已使用特定密码对演示文稿进行保护。Aspose.Slides 提供了验证密码的手段。

以下示例代码展示了如何验证密码：

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// 检查 "pass" 是否匹配
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

如果演示文稿使用指定密码加密，则返回 `true`；否则返回 `false`。

{{% alert color="info" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/zh/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**Aspose.Slides 支持哪些加密方法？**

Aspose.Slides 支持现代加密方法，包括基于 AES 的算法，确保演示文稿数据的高度安全性。

**尝试打开演示文稿时输入错误密码会怎样？**

如果使用错误的密码，系统会抛出异常，提示访问演示文稿被拒绝。这有助于防止未授权访问并保护演示文稿内容。

**在处理受密码保护的演示文稿时是否会有性能影响？**

加密和解密过程可能在打开和保存操作期间带来轻微开销。大多数情况下，这种性能影响很小，对整体处理时间的影响不显著。