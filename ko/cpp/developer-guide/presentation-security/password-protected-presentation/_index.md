---
title: C++에서 프레젠테이션 암호 보호
linktitle: 암호 보호
type: docs
weight: 20
url: /ko/cpp/password-protected-presentation/
keywords:
- 암호 보호된 프레젠테이션
- 오프닝 비밀번호
- PowerPoint 암호화
- PowerPoint 복호화
- 프레젠테이션 비밀번호 검증
- 프레젠테이션 비밀번호 확인
- 암호화된 프레젠테이션 열기
- 암호화 제거
- PowerPoint
- PPT
- PPTX
- 프레젠테이션
- C++
- Aspose.Slides
description: "C++와 Aspose.Slides를 사용하여 암호 보호된 PowerPoint PPT 및 PPTX 프레젠테이션을 암호화, 감지, 검증, 열기 및 복호화합니다."
---
## **Overview**

오프닝 비밀번호는 프레젠테이션을 암호화합니다. 올바른 비밀번호가 있어야 프레젠테이션 내용을 로드하고 볼 수 있으므로 이 보호는 기밀성을 제공합니다.

오프닝 비밀번호는 쓰기 보호 비밀번호와 다릅니다. 쓰기 보호는 수정을 제한하지만 내용을 암호화하거나 프레젠테이션 로드를 방지하지 않습니다. 프레젠테이션 수정을 위한 비밀번호를 관리하려면 [프레젠테이션 쓰기 보호](/slides/ko/cpp/write-protected-presentation/)를 참조하십시오.

아래 워크플로는 PPT와 PPTX 프레젠테이션 모두에 적용됩니다. 예제는 파일 기반 및 스트림 기반 동작이 중요한 경우 두 형식을 모두 사용합니다.

## **Encrypt a Presentation with an Opening Password**

오프닝 비밀번호를 할당하려면 [IProtectionManager::Encrypt](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iprotectionmanager/encrypt/)를 사용합니다. 그런 다음 암호화된 프레젠테이션을 저장하려면 [IPresentation::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/save/)를 사용합니다.

다음 예제는 PPTX 프레젠테이션을 암호화합니다:

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

## **Load an Encrypted Presentation**

[LoadOptions::set_Password](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_password/)에 오프닝 비밀번호를 설정하고 파일을 로드할 때 해당 옵션을 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/)에 전달합니다. 오프닝 비밀번호가 필요하지만 제공된 비밀번호가 없거나 올바르지 않은 경우 로드에 실패합니다.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// 복호화된 프레젠테이션 작업.
```

## **Remove Encryption from a Presentation**

오프닝 비밀번호로 프레젠테이션을 로드하고, [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iprotectionmanager/removeencryption/)를 호출한 뒤 결과를 저장합니다. 저장된 프레젠테이션은 비밀번호 없이 로드할 수 있습니다.

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

## **Validate an Opening Password Before Loading**

[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/)를 사용하여 전체 프레젠테이션 인스턴스를 만들지 않고도 [IPresentationInfo](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationinfo/)를 얻습니다. 비밀번호가 필요한지 확인하려면 [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/)를 검사하십시오. 보호가 있는 경우 제공된 값을 [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationinfo/checkpassword/)로 검증합니다.

### **File-Path Workflow**

다음 예제는 PPTX 파일에 대한 오프닝 비밀번호를 검증하고, 검증된 값을 [LoadOptions::set_Password](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_password/)에 전달한 뒤 전체 프레젠테이션을 로드합니다:

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

### **Stream Workflow**

[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/)의 스트림 오버로드도 동일한 워크플로를 제공합니다. 스트림에서 전체 프레젠테이션을 로드하기 전에 검색 가능한 스트림의 위치를 재설정하십시오.

다음 예제는 PPT 파일을 사용합니다:

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

### **CheckPassword Return Values**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationinfo/checkpassword/)은 프레젠테이션에 오프닝 비밀번호가 존재하고 제공된 비밀번호가 올바른 경우에만 `true`를 반환합니다. 다음 경우에는 `false`를 반환합니다:

- 비밀번호가 올바르지 않은 경우.
- 프레젠테이션에 오프닝 비밀번호가 없는 경우.
- 제공된 비밀번호가 null이거나 비어 있는 경우.

동작은 PPT와 PPTX 프레젠테이션 모두에 동일합니다.

## **Check Whether a Loaded Presentation Is Encrypted**

올바른 비밀번호로 프레젠테이션을 로드한 후 [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iprotectionmanager/get_isencrypted/)를 검사하여 원본 프레젠테이션이 암호화되었는지 확인합니다. 로드하기 전에 오프닝 비밀번호 보호를 감지하려면 위에서 설명한 대로 `IPresentationInfo::get_IsPasswordProtected`를 사용하십시오.

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

## **Security Recommendations**

{{% alert color="warning" title="보안" %}}
오프닝 비밀번호를 로그에 기록하거나 진단 메시지에 포함하지 마십시오. 불필요한 반복 검증 시도를 피하고, 비밀번호는 필요한 기간 동안만 메모리에 유지하며, 프레젠테이션을 즉시 로드할 경우 성공적인 검증 결과를 재사용하십시오.
{{% /alert %}}

## **Password-Protect a Presentation Online**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ko/lock) 애플리케이션을 엽니다.
2. 프레젠테이션을 선택하거나 업로드합니다.
3. 보기 보호용 비밀번호를 입력합니다.
4. 필요에 따라 편집 보호용 별도 비밀번호를 입력합니다.
5. 보호를 적용하고 결과 파일을 다운로드합니다.

{{% alert color="info" title="추가 보기" %}}
- [프레젠테이션 쓰기 보호](/slides/ko/cpp/write-protected-presentation/)
- [PowerPoint 디지털 서명](/slides/ko/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**오프닝 비밀번호와 쓰기 보호 비밀번호의 차이점은 무엇인가요?**

오프닝 비밀번호는 프레젠테이션을 암호화하고 내용을 로드하려면 필요합니다. 쓰기 보호 비밀번호는 내용을 암호화하지 않고 수정만 제한합니다.

**전체 슬라이드를 로드하지 않고 오프닝 비밀번호를 검증할 수 있나요?**

예. 프레젠테이션 정보를 얻고, 오프닝 비밀번호 보호가 있는지 확인한 뒤 전체 프레젠테이션 인스턴스를 만들지 않고도 비밀번호를 검증할 수 있습니다.

**비밀번호 검증 워크플로는 PPT와 PPTX 모두를 지원하나요?**

예. 파일 경로 및 스트림 기반 비밀번호 감지와 검증은 PPT와 PPTX 프레젠테이션 모두에서 동일하게 동작합니다.