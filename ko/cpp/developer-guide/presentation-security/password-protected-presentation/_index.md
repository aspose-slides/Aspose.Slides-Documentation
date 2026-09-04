---
title: C++에서 프레젠테이션 암호 보호
linktitle: 암호 보호
type: docs
weight: 20
url: /ko/cpp/password-protected-presentation/
keywords:
- 암호 보호된 프레젠테이션
- 오프닝 암호
- PowerPoint 암호화
- PowerPoint 복호화
- 프레젠테이션 암호 검증
- 프레젠테이션 암호 확인
- 암호화된 프레젠테이션 열기
- 암호 제거
- PowerPoint
- PPT
- PPTX
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 암호 보호된 PowerPoint PPT 및 PPTX 프레젠테이션을 암호화하고, 감지하며, 검증하고, 열고, 복호화합니다."
---
## **개요**

오프닝 암호는 프레젠테이션을 암호화합니다. 올바른 암호가 있어야 프레젠테이션 내용을 로드하고 볼 수 있으므로 이 보호는 기밀성을 제공합니다.

오프닝 암호는 쓰기 보호 암호와 다릅니다. 쓰기 보호는 수정은 제한하지만 내용을 암호화하거나 프레젠테이션이 로드되는 것을 방지하지 않습니다. 프레젠테이션 수정용 암호를 관리하려면 [Write-Protect Presentations](/slides/ko/cpp/write-protected-presentation/)를 참조하십시오.

아래 워크플로는 PPT와 PPTX 프레젠테이션 모두에 적용됩니다. 예제에서는 파일 기반 및 스트림 기반 동작이 중요한 경우 두 형식을 모두 사용합니다.

## **오프닝 암호로 프레젠테이션 암호화**

오프닝 암호를 지정하려면 [IProtectionManager::Encrypt](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iprotectionmanager/encrypt/)을 사용하십시오. 그런 다음 [IPresentation::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/save/)을 사용하여 암호화된 프레젠테이션을 저장합니다.

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

## **문서 속성을 공개 유지**

기본적으로 Aspose.Slides는 프레젠테이션 암호화에 문서 속성을 포함합니다. [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/)는 슬라이드 내용 암호화와 별개로 이 동작을 제어합니다. 인덱싱, 분류, 검색 또는 문서 관리 시스템이 오프닝 암호 없이 메타데이터를 읽어야 할 경우, [IProtectionManager::Encrypt](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iprotectionmanager/encrypt/)를 호출하기 전에 이 메서드에 `false`를 전달하십시오.

다음 예제는 내장 문서 속성을 공개 상태로 유지하면서 암호화된 PPTX 프레젠테이션을 생성합니다:
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

`set_EncryptDocumentProperties`에 `false`를 전달한다고 해서 슬라이드, 마스터, 레이아웃, 도형, 미디어 또는 기타 프레젠테이션 콘텐츠가 공개되는 것은 아닙니다. 이는 문서 속성에만 영향을 줍니다. 암호화된 콘텐츠를 로드하지 않고 해당 속성을 읽으려면 [Manage Presentation Properties](/slides/ko/cpp/presentation-properties/)를 참조하십시오.

## **암호화된 프레젠테이션 로드**

[LoadOptions::set_Password](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_password/)를 오프닝 암호로 설정하고 파일을 로드할 때 해당 옵션을 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/)에 전달하십시오. 오프닝 암호가 필요하지만 제공된 암호가 없거나 올바르지 않으면 로드가 실패합니다.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// 복호화된 프레젠테이션으로 작업합니다.
```

## **프레젠테이션 암호 해제**

오프닝 암호를 사용하여 프레젠테이션을 로드하고 [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iprotectionmanager/removeencryption/)을 호출한 뒤 저장하십시오. 저장된 프레젠테이션은 이후 암호 없이 로드할 수 있습니다.

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

## **로드 전에 오프닝 암호 검증**

전체 프레젠테이션 인스턴스를 생성하지 않고 [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/)를 사용하여 [IPresentationInfo](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationinfo/)를 얻습니다. 암호를 요청하거나 검증하기 전에 [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/)를 확인하십시오. 보호가 존재하면 제공된 값을 [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationinfo/checkpassword/)으로 검증합니다.

### **파일 경로 워크플로**

다음 예제는 PPTX 파일에 대한 오프닝 암호를 검증하고, 검증된 값을 [LoadOptions::set_Password](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_password/)에 전달한 뒤 전체 프레젠테이션을 로드합니다:
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

### **스트림 워크플로**

[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/)의 스트림 오버로드는 동일한 워크플로를 제공합니다. 해당 스트림에서 전체 프레젠테이션을 로드하기 전에 탐색 가능한 스트림의 위치를 재설정하십시오.

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

### **CheckPassword 반환 값**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationinfo/checkpassword/)은 프레젠테이션에 오프닝 암호가 있고 제공된 암호가 올바른 경우에만 `true`를 반환합니다. 다음 경우에는 `false`를 반환합니다:
- 암호가 올바르지 않음.
- 프레젠테이션에 오프닝 암호가 없음.
- 제공된 암호가 null이거나 비어 있음.

동작은 PPT와 PPTX 프레젠테이션 모두 동일합니다.

## **로드된 프레젠테이션이 암호화되었는지 확인**

올바른 암호로 프레젠테이션을 로드한 후, [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iprotectionmanager/get_isencrypted/)을 확인하여 원본 프레젠테이션이 암호화되었는지 확인하십시오. 로드하기 전에 오프닝 암호 보호를 감지하려면 위에서 설명한대로 `IPresentationInfo::get_IsPasswordProtected`를 사용하십시오.

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

## **보안 권고 사항**

{{% alert color="warning" title="Security" %}}
오프닝 암호를 로그에 기록하거나 진단 메시지에 포함하지 마십시오. 불필요한 반복 검증을 피하고, 암호는 필요한 기간 동안만 메모리에 유지하며, 프레젠테이션을 즉시 로드할 때 성공적인 검증 결과를 재사용하십시오.

프레젠테이션 내용이 암호화되어 있어도 공개 문서 속성에는 작성자 이름, 제목, 주제, 키워드, 회사 정보, 주석 및 사용자 지정 값이 노출될 수 있습니다. 민감한 메타데이터는 프레젠테이션과 함께 암호화하십시오. 속성을 공개 상태로 유지하는 것은 파일을 오프닝 암호 없이 인덱싱, 분류, 검색 또는 관리해야 할 경우에만 명시적인 결정으로 해야 합니다.
{{% /alert %}}

## **온라인으로 프레젠테이션에 암호 보호**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ko/lock) 애플리케이션을 엽니다.
1. 프레젠테이션을 선택하거나 업로드합니다.
1. 보기 보호용 암호를 입력합니다.
1. 선택적으로 편집 보호용 별도 암호를 입력합니다.
1. 보호를 적용하고 결과 파일을 다운로드합니다.

{{% alert color="info" title="See also" %}}
- [프레젠테이션 쓰기 보호](/slides/ko/cpp/write-protected-presentation/)
- [PowerPoint 디지털 서명](/slides/ko/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**오프닝 암호와 쓰기 보호 암호의 차이점은 무엇인가요?**

오프닝 암호는 프레젠테이션을 암호화하고 내용을 로드하는 데 필요합니다. 쓰기 보호 암호는 내용을 암호화하지 않고 수정만 제한합니다.

**모든 슬라이드를 로드하지 않고 오프닝 암호를 검증할 수 있나요?**

예. 프레젠테이션 정보를 얻고, 오프닝 암호 보호가 존재하는지 확인한 뒤 전체 프레젠테이션 인스턴스를 만들기 전에 암호를 검증하십시오.

**응용 프로그램이 오프닝 암호 없이 메타데이터를 읽을 수 있나요?**

예, 단지 프레젠테이션이 `set_EncryptDocumentProperties(false)`로 암호화된 경우에만 가능합니다. 그런 경우 응용 프로그램은 [프레젠테이션 속성 관리](/slides/ko/cpp/presentation-properties/)에 설명된 문서 속성 전용 로드 모드를 사용해야 합니다.

**암호 검증 워크플로가 PPT와 PPTX 모두를 지원하나요?**

예. 파일 경로와 스트림 기반 암호 감지 및 검증은 PPT와 PPTX 프레젠테이션 모두에서 동일하게 동작합니다.