---
title: 라이선스
type: docs
weight: 120
url: /ko/cpp/licensing/
keywords:
- 라이선스
- 임시 라이선스
- 라이선스 설정
- 라이선스 사용
- 라이선스 검증
- 라이선스 파일
- 평가 버전
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 라이선스를 적용하고, 관리하며, 문제를 해결합니다. 단계별 라이선스 가이드를 통해 전체 기능에 지속적으로 접근할 수 있도록 보장합니다."
---
## **개요**

Aspose.Slides는 평가 모드 또는 유효한 라이선스로 사용할 수 있습니다. 평가 버전은 라이선스 버전과 동일한 기능을 제공하지만 저장하는 각 프레젠테이션의 모든 슬라이드에 평가 워터마크를 추가하고 코드가 프레젠테이션에서 읽는 텍스트를 잘라냅니다.

이 문서는 Aspose.Slides에서 라이선스가 어떻게 작동하는지와 라이브러리를 사용하기 전에 라이선스를 적용하는 방법을 설명합니다. 라이선스는 `License` 클래스를 사용하여 파일 또는 스트림에서 로드할 수 있습니다. 또한 라이선스가 올바르게 적용되었는지 확인하는 방법도 보여줍니다.

## **Aspose.Slides 평가**

{{% alert color="info" title="Note" %}}
평가 버전인 **Aspose.Slides for C++**를 [NuGet 다운로드 페이지](https://www.nuget.org/packages/Aspose.Slides.Cpp/)에서 또는 ZIP 패키지로 [다운로드 페이지](https://releases.aspose.com/slides/ko/cpp/)에서 다운로드할 수 있습니다. 평가 버전은 라이선스 제품과 동일한 기능을 제공합니다. 사실, 평가 패키지는 구매한 패키지와 동일하며, 라이선스를 적용하는 몇 줄의 코드를 추가하면 라이선스가 적용됩니다.

Aspose.Slides 평가에 만족하면 [라이선스를 구매](https://purchase.aspose.com/pricing/slides/ko/cpp/)할 수 있습니다. 사용 가능한 구독 유형을 검토하시기 바랍니다. 질문이 있으면 언제든지 Aspose 영업팀에 문의하세요.

모든 Aspose 라이선스에는 해당 기간 동안 출시되는 새로운 버전 및 버그 수정 등 무료 업그레이드를 위한 1년 구독이 포함됩니다. 라이선스 버전이든 평가 버전이든 무료이며 무제한의 기술 지원을 받을 수 있습니다.
{{% /alert %}} 

**Evaluation Version Limitations**

* 라이선스가 지정되지 않은 평가 버전은 전체 제품 기능을 제공하지만 저장하는 각 프레젠테이션의 모든 슬라이드에 평가 워터마크 텍스트 상자를 추가합니다.
* 코드가 프레젠테이션에서 읽는 텍스트는 처음 몇 문자만 남기고 평가 제한에 대한 안내가 붙어 잘라집니다. 코드가 쓰는 텍스트는 전체가 저장됩니다.

{{% alert color="info" title="Note" %}}
제한 없이 Aspose.Slides를 테스트하려면 **30일 임시 라이선스**를 요청할 수 있습니다. 자세한 내용은 [임시 라이선스 받는 방법](https://purchase.aspose.com/temporary-license) 페이지를 참조하세요.
{{% /alert %}}

## **Aspose.Slides의 라이선스**

* 평가 버전은 라이선스를 구매하고 몇 줄의 코드를 추가해 적용하면 라이선스가 부여됩니다.
* 라이선스는 제품 이름, 라이선스가 부여된 개발자 수, 구독 만료 날짜 등과 같은 세부 정보를 포함하는 일반 텍스트 XML 파일입니다.
* 라이선스 파일은 디지털 서명되어 있어 수정해서는 안 됩니다. 줄 바꿈을 추가하는 등 실수로 변경해도 파일이 무효화됩니다.
* 폴더 경로 없이 파일 이름만 전달하면 Aspose.Slides for C++는 현재 작업 디렉터리에서만 라이선스 파일을 찾습니다. 실행 파일이나 Aspose.Slides 라이브러리 폴더를 검색하지 않으므로 라이선스 파일이 다른 위치에 있을 경우 전체 경로를 전달하십시오.
* 평가 버전의 제한을 피하려면 Aspose.Slides를 사용하기 전에 라이선스를 설정해야 합니다. 라이선스는 애플리케이션 또는 프로세스당 한 번만 설정하면 됩니다.

## **라이선스 적용**

라이선스는 **파일** 또는 **스트림**에서 로드할 수 있습니다.

{{% alert color="info" title="Note" %}}
Aspose.Slides는 라이선스 작업을 위한 [License](https://reference.aspose.com/slides/ko/cpp/aspose.slides/license/) 클래스를 제공합니다.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
새 라이선스는 버전 21.4 이상에서만 Aspose.Slides를 활성화할 수 있습니다. 이전 버전은 다른 라이선스 시스템을 사용하므로 이러한 라이선스를 인식하지 못합니다.
{{% /alert %}}

### **파일**

라이선스를 설정하는 가장 쉬운 방법은 라이선스 파일을 프로그램의 작업 디렉터리에 두고 파일 이름만 지정하는 것입니다. 경로를 포함하지 않고 파일 이름만 지정하십시오. 그렇지 않으면 파일의 전체 경로를 지정하십시오.

다음 C++ 코드는 프로그램 작업 디렉터리의 *Aspose.Slides.lic* 파일을 적용합니다:

```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

라이선스가 유효하면 [License::SetLicense](https://reference.aspose.com/slides/ko/cpp/aspose.slides/license/setlicense/)가 반환되고 프로그램은 출력 없이 종료됩니다; 이후 Aspose.Slides는 평가 제한 없이 작동합니다. 파일이 작업 디렉터리에 없으면 메서드는 [FileNotFoundException](https://reference.aspose.com/slides/ko/cpp/system.io/filenotfoundexception/)을 발생시키며 메시지는 *License "Aspose.Slides.lic" doesn't exist or access is restricted* 입니다. 예제는 예외를 처리하지 않으므로 프로그램이 중단됩니다.

{{% alert color="warning" title="Warning" %}}
라이선스 파일을 다른 디렉터리에 두는 경우 [License::SetLicense](https://reference.aspose.com/slides/ko/cpp/aspose.slides/license/setlicense/) 메서드를 호출할 때 지정한 전체 경로의 파일 이름이 라이선스 파일 이름과 정확히 일치해야 합니다.

예를 들어, 라이선스 파일 이름을 *Aspose.Slides.lic.xml*으로 바꾸면 코드에서 [License::SetLicense](https://reference.aspose.com/slides/ko/cpp/aspose.slides/license/setlicense/) 메서드에 *Aspose.Slides.lic.xml* 로 끝나는 전체 경로를 전달해야 합니다.
{{% /alert %}}

### **스트림**

프로그램이 파일 형태로 라이선스를 보관하지 않을 때, 예를 들어 데이터베이스에서 라이선스를 읽는 경우 스트림에서 라이선스를 로드합니다. [License::SetLicense](https://reference.aspose.com/slides/ko/cpp/aspose.slides/license/setlicense/)는 라이선스를 포함하는 任意의 [Stream](https://reference.aspose.com/slides/ko/cpp/system.io/stream/)을 허용합니다. 예제를 간단히 하기 위해 다음 C++ 코드는 작업 디렉터리의 *Aspose.Slides.lic*를 [File::OpenRead](https://reference.aspose.com/slides/ko/cpp/system.io/file/openread/)로 열어 해당 스트림에서 라이선스를 적용합니다:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

유효한 라이선스는 파일 예제와 동일한 결과를 제공합니다. 파일이 존재하지 않으면 [File::OpenRead](https://reference.aspose.com/slides/ko/cpp/system.io/file/openread/)이 라이선스가 적용되기 전에 [FileNotFoundException](https://reference.aspose.com/slides/ko/cpp/system.io/filenotfoundexception/)을 발생시키고 프로그램이 중단됩니다.

## **라이선스 검증**

라이선스가 올바르게 설정되었는지 확인하려면 [License::IsLicensed](https://reference.aspose.com/slides/ko/cpp/aspose.slides/license/islicensed/)을 호출합니다. 유효한 라이선스가 적용된 경우에만 `true`를 반환하고, 그 이전에는 `false`를 반환합니다. 다음 C++ 코드는 작업 디렉터리의 라이선스 파일을 적용한 뒤 이를 확인합니다:

```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

유효한 라이선스가 있으면 프로그램은 *License is good!*을 출력합니다. 파일이 없거나 라이선스 파일이 아니면 [License::SetLicense](https://reference.aspose.com/slides/ko/cpp/aspose.slides/license/setlicense/)가 검사 전에 예외를 발생시켜 아무 출력도 없이 프로그램이 중단됩니다. 파일이 서명이 일치하지 않는 라이선스(예: 편집된 경우)라면 SetLicense는 오류 없이 반환되지만 `IsLicensed`는 `false`를 반환하므로 아무 것도 출력되지 않으며 Aspose.Slides는 평가 모드에 머무릅니다.

## **스레드 안전성**

{{% alert color="warning" title="Warning" %}}
[License::SetLicense](https://reference.aspose.com/slides/ko/cpp/aspose.slides/license/setlicense/) 메서드는 **스레드 안전하지** 않습니다. 여러 스레드에서 동시에 이 메서드를 호출해야 하는 경우 잠금과 같은 동기화 프리미티브를 사용하여 문제를 방지하는 것이 권장됩니다.
{{% /alert %}}

## **FAQ**

### 완전한 오프라인 환경(인터넷 연결 없음)에서도 라이선스를 적용할 수 있나요?

예. 라이선스 검증은 라이선스 파일을 사용하여 로컬에서 수행되며 인터넷 연결이 필요하지 않습니다.

### 1년 구독이 만료되면 어떻게 되나요? 라이브러리가 작동을 멈추나요?

아니오. 라이선스는 영구적이며, 구독 종료일 이전에 출시된 버전을 계속 사용할 수 있습니다. 다만, 갱신하지 않으면 최신 릴리스를 사용할 수 없습니다.