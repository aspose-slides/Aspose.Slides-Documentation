---
title: Write-Protect Presentations in C++
linktitle: Write Protection
type: docs
weight: 25
url: /cpp/write-protected-presentation/
keywords:
- write protection
- write-protect PowerPoint
- password to modify
- restrict presentation editing
- remove write protection
- validate modification password
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Set, detect, validate, and remove write-protection passwords in PowerPoint PPT and PPTX presentations using Aspose.Slides for C++."
---

## **Introduction**

A write-protection password restricts modification of a presentation but does not encrypt its content. Users can load and view a write-protected presentation without the password. Depending on the application, they may also be able to edit the content and save it under a different name, so write protection should not be treated as a confidentiality mechanism.

An opening password serves a different purpose: it encrypts the presentation and is required to load its content. To encrypt a presentation or validate an opening password, see [Password-Protect Presentations](/slides/cpp/password-protected-presentation/).

The workflows in this article apply to both PPT and PPTX presentations. The examples use PPTX files; when saving to PPT, use the `.ppt` extension and the corresponding PPT save format.

## **Set Write Protection on a Presentation**

Use [IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/setwriteprotection/) to assign a password for modifying a presentation. Saving the presentation persists the protection setting.

The following example sets write protection on a PPTX presentation:

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

## **Load a Write-Protected Presentation**

Because write protection does not encrypt presentation content, no password is required to load the presentation. The password is relevant only when validating authorization to modify the protected presentation.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

Do not pass a write-protection password to [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/). That property accepts an opening password for encrypted content. If a presentation has both protection types, supply the opening password to load it and handle the write-protection password separately.

## **Remove Write Protection from a Presentation**

Use [IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/removewriteprotection/) to remove the modification restriction, then save the presentation.

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

## **Check Whether a Presentation Is Write Protected**

To inspect a file without creating a complete [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) instance, call [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) and inspect [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/). The property uses [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) and returns `NullableBool::True` when write protection is detected.

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

The stream overload of [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) provides the same information for a presentation supplied as a stream.

## **Validate a Write-Protection Password**

Use [IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) to validate a modification password without loading the complete presentation. Check [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) first so that the application requests or validates a password only when write protection is present.

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

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) validates only the write-protection password. It does not validate an opening password or determine whether encrypted content can be loaded. Conversely, [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/checkpassword/) validates only an opening password. If a complete presentation has already been loaded, [IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/) provides the equivalent write-protection check through its protection manager.

In production applications, do not log passwords or include them in diagnostic messages. Avoid unnecessary repeated validation attempts, and retain passwords in memory only as long as needed.

{{% alert color="info" title="See also" %}}
- [Password-Protect Presentations](/slides/cpp/password-protected-presentation/)
- [Read-Only Presentations](/slides/cpp/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Does write protection encrypt a presentation?**

No. It restricts modification but leaves the presentation content available for loading and viewing.

**Is the write-protection password required to open a presentation?**

No. Only an opening password is required to load encrypted presentation content.

**Can a presentation have both an opening password and a write-protection password?**

Yes. Supply the opening password through the load options to open the encrypted presentation, and validate the write-protection password separately when modification authorization is required.
