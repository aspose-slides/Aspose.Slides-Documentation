---
title: C++에서 프레젠테이션 쓰기 보호
linktitle: 쓰기 보호
type: docs
weight: 25
url: /ko/cpp/write-protected-presentation/
keywords:
- 쓰기 보호
- PowerPoint 쓰기 보호
- 수정용 암호
- 프레젠테이션 편집 제한
- 쓰기 보호 제거
- 수정 암호 검증
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint PPT 및 PPTX 프레젠테이션에서 쓰기 보호 암호를 설정, 감지, 검증 및 제거합니다."
---
## **소개**

쓰기 보호 암호는 프레젠테이션의 수정은 제한하지만 내용 자체를 암호화하지는 않습니다. 사용자는 쓰기 보호된 프레젠테이션을 암호 없이 로드하고 볼 수 있습니다. 애플리케이션에 따라 내용 편집 및 다른 이름으로 저장이 가능할 수 있으므로 쓰기 보호를 기밀성 메커니즘으로 취급해서는 안 됩니다.

열기 암호는 다른 목적을 가집니다: 프레젠테이션을 암호화하며 내용 로드 시 필요합니다. 프레젠테이션을 암호화하거나 열기 암호를 확인하려면 [Password-Protect Presentations](/slides/ko/cpp/password-protected-presentation/)을 참고하세요.

이 문서의 워크플로는 PPT와 PPTX 프레젠테이션 모두에 적용됩니다. 예제는 PPTX 파일을 사용합니다; PPT로 저장할 경우 `.ppt` 확장자와 해당 PPT 저장 형식을 사용하세요.

## **프레젠테이션에 쓰기 보호 설정**

[IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iprotectionmanager/setwriteprotection/)을 사용하여 프레젠테이션 수정용 암호를 지정합니다. 프레젠테이션을 저장하면 보호 설정이 유지됩니다.

다음 예제는 PPTX 프레젠테이션에 쓰기 보호를 설정합니다:

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

## **쓰기 보호된 프레젠테이션 로드**

쓰기 보호는 프레젠테이션 내용을 암호화하지 않기 때문에 로드할 때 암호가 필요하지 않습니다. 암호는 보호된 프레젠테이션을 수정할 권한을 확인할 때만 관련됩니다.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

[LoadOptions::set_Password](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_password/)에 쓰기 보호 암호를 전달하지 마세요. 이 속성은 암호화된 내용에 대한 열기 암호만 받습니다. 프레젠테이션에 두 종류의 보호가 모두 적용된 경우, 열기 암호를 제공해 로드하고 쓰기 보호 암호는 별도로 처리하세요.

## **프레젠테이션에서 쓰기 보호 제거**

[IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iprotectionmanager/removewriteprotection/)을 사용하여 수정 제한을 해제한 뒤 프레젠테이션을 저장합니다.

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

## **프레젠테이션이 쓰기 보호됐는지 확인**

전체 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 인스턴스를 만들지 않고 파일을 검사하려면 [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/)를 호출하고 [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/)를 확인합니다. 이 속성은 [NullableBool](https://reference.aspose.com/slides/ko/cpp/aspose.slides/nullablebool/)을 사용하며 쓰기 보호가 감지되면 `NullableBool::True`를 반환합니다.

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

스트림 오버로드 형태의 [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/)도 스트림으로 제공된 프레젠테이션에 대해 동일한 정보를 제공합니다.

## **쓰기 보호 암호 검증**

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/)을 사용하면 전체 프레젠테이션을 로드하지 않고도 수정 암호를 검증할 수 있습니다. 먼저 [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/)를 확인하여 쓰기 보호가 존재할 때만 암호를 요청하거나 검증하도록 하세요.

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

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/)은 쓰기 보호 암호만 검증합니다. 열기 암호를 검증하거나 암호화된 내용을 로드할 수 있는지는 확인하지 않습니다. 반대로 [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationinfo/checkpassword/)은 열기 암호만 검증합니다. 이미 전체 프레젠테이션이 로드된 경우, [IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/)가 보호 관리자를 통해 동일한 쓰기 보호 검증을 제공합니다.

운영 환경에서는 암호를 로그에 기록하거나 진단 메시지에 포함하지 마세요. 불필요한 중복 검증을 피하고, 암호는 필요한 기간 동안만 메모리에 보관하세요.

{{% alert color="info" title="관련 항목" %}}
- [Password-Protect Presentations](/slides/ko/cpp/password-protected-presentation/)
- [Read-Only Presentations](/slides/ko/cpp/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/ko/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**쓰기 보호가 프레젠테이션을 암호화합니까?**

아니요. 수정은 제한하지만 프레젠테이션 내용은 로드 및 보기 위해 사용할 수 있습니다.

**프레젠테이션을 열 때 쓰기 보호 암호가 필요합니까?**

아니요. 암호화된 프레젠테이션 내용을 로드하려면 열기 암호만 필요합니다.

**프레젠테이션에 열기 암호와 쓰기 보호 암호를 동시에 설정할 수 있나요?**

예. 로드 옵션을 통해 열기 암호를 제공해 암호화된 프레젠테이션을 열고, 수정 권한이 필요할 때 쓰기 보호 암호를 별도로 검증하세요.