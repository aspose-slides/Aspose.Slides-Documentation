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
description: "Aspose.Slides for C++에서 라이선스를 적용, 관리 및 문제 해결합니다. 단계별 라이선스 가이드를 통해 전체 기능에 대한 중단 없는 접근을 보장합니다."
---
## **개요**

Aspose.Slides는 평가 모드 또는 유효한 라이선스로 사용할 수 있습니다. 평가 버전은 정식 라이선스 버전과 동일한 기능을 제공하지만 프레젠테이션을 열거나 저장할 때 평가 워터마크가 삽입되고 텍스트 추출이 한 슬라이드로 제한됩니다.

이 문서에서는 Aspose.Slides의 라이선스 작동 방식과 라이브러리를 사용하기 전에 라이선스를 적용하는 방법을 설명합니다. `License` 클래스를 사용하여 파일, 스트림 또는 임베디드 리소스에서 라이선스를 로드할 수 있습니다. 또한 라이선스가 올바르게 적용되었는지 검증하는 방법도 보여줍니다.

## **Aspose.Slides 평가**

{{% alert color="primary" %}} 

**Aspose.Slides for C++**의 평가 버전을 [NuGet 다운로드 페이지](https://www.nuget.org/packages/Aspose.Slides.CPP/)에서 다운로드할 수 있습니다. 평가 버전은 정식 제품과 동일한 기능을 제공합니다. 실제로 평가 패키지는 구매한 패키지와 동일하며, 라이선스를 적용하는 몇 줄의 코드를 추가하면 정식 라이선스로 전환됩니다.

평가가 만족스러우면 [라이선스를 구매](https://purchase.aspose.com/buy)할 수 있습니다. 사용 가능한 구독 유형을 검토하시기 바랍니다. 궁금한 점이 있으면 언제든지 Aspose 영업팀에 문의하세요.

모든 Aspose 라이선스에는 해당 기간 동안 출시되는 새 버전 및 버그 수정 등을 포함한 1년 무료 업그레이드 구독이 포함됩니다. 정식 라이선스든 평가 버전이든 관계없이 무료 무제한 기술 지원을 받을 수 있습니다.

{{% /alert %}} 

**평가 버전 제한 사항**

* Aspose.Slides 평가 버전(라이선스 미적용 시)은 전체 기능을 제공하지만 열기 및 저장 작업 중 문서 상단에 평가 워터마크를 삽입합니다.
* 평가 버전을 사용할 경우 텍스트 추출이 한 슬라이드로 제한됩니다.

{{% alert color="primary" %}} 

제한 없이 Aspose.Slides를 테스트하려면 **30일 임시 라이선스**를 요청할 수 있습니다. 자세한 내용은 [임시 라이선스 받는 방법](https://purchase.aspose.com/temporary-license) 페이지를 참조하세요.

{{% /alert %}}

## **Aspose.Slides 라이선스**

* 평가 버전은 라이선스를 구매하고 몇 줄의 코드를 추가해 적용하면 정식 라이선스로 전환됩니다.
* 라이선스는 제품 이름, 라이선스 대상 개발자 수, 구독 만료일 등 세부 정보를 포함하는 일반 텍스트 XML 파일입니다.
* 라이선스 파일은 디지털 서명되어 있으므로 수정해서는 안 됩니다. 줄 바꿈 같은 사소한 변경조차 파일을 무효화합니다.
* Aspose.Slides for C++는 일반적으로 다음 위치에서 라이선스 파일을 찾습니다:
  * 코드에서 명시적으로 지정한 경로
  * 구성 요소의 DLL이 포함된 폴더(Aspose.Slides에 포함됨)
  * 해당 구성 요소 DLL을 호출하는 어셈블리가 위치한 폴더
* 평가 버전의 제한을 피하려면 Aspose.Slides를 사용하기 전에 라이선스를 설정해야 합니다. 라이선스는 애플리케이션 또는 프로세스당 한 번만 설정하면 됩니다.

## **라이선스 적용**

라이선스는 **파일**, **스트림**, 또는 **임베디드 리소스**에서 로드할 수 있습니다.

{{% alert color="primary" %}}

Aspose.Slides는 라이선스 작업을 위해 [License](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.license/) 클래스를 제공합니다.

{{% /alert %}} 

{{% alert color="warning" %}}

새 라이선스는 버전 21.4 이상에서만 Aspose.Slides를 활성화할 수 있습니다. 이전 버전은 다른 라이선스 시스템을 사용하므로 이러한 라이선스를 인식하지 못합니다.

{{% /alert %}}

### **파일**

라이선스를 설정하는 가장 쉬운 방법은 라이선스 파일을 구성 요소 DLL이 포함된 폴더(Aspose.Slides에 포함)와 같은 폴더에 두고, 경로 없이 파일 이름만 지정하는 것입니다.

다음 C++ 코드에서는 라이선스 파일을 설정하는 방법을 보여줍니다:

```c++
#include <Util/License.h>

using namespace Aspose::Slides;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

{{% alert color="warning" %}} 

라이선스 파일을 다른 디렉터리에 두는 경우 [License::SetLicense](https://reference.aspose.com/slides/ko/cpp/aspose.slides/license/setlicense/) 메서드를 호출할 때 지정한 명시적 경로의 끝에 있는 파일 이름이 라이선스 파일 이름과 정확히 일치해야 합니다.

예를 들어 라이선스 파일 이름을 *Aspose.Slides.lic.xml*으로 변경한 경우 코드에서 [License::SetLicense](https://reference.aspose.com/slides/ko/cpp/aspose.slides/license/setlicense/) 메서드에 *Aspose.Slides.lic.xml*으로 끝나는 전체 경로를 전달해야 합니다.

{{% /alert %}}

### **스트림**

스트림에서 라이선스를 로드할 수 있습니다. 다음 C++ 코드에서는 스트림을 사용해 라이선스를 적용하는 방법을 보여줍니다:

```c++
auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **라이선스 검증**

라이선스가 올바르게 설정되었는지 확인하려면 검증할 수 있습니다. 다음 C++ 코드에서는 라이선스를 검증하는 방법을 보여줍니다:

```c++
auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **스레드 안전성**

{{% alert title="Note" color="warning" %}} 

[License::SetLicense](https://reference.aspose.com/slides/ko/cpp/aspose.slides/license/setlicense/) 메서드는 **스레드에 안전하지 않음**합니다. 여러 스레드에서 동시에 이 메서드를 호출해야 하는 경우 잠금과 같은 동기화 프리미티브를 사용해 잠재적 문제를 방지하는 것이 권장됩니다.

{{% /alert %}}

## **FAQ**

**완전히 오프라인 환경(인터넷 접속 없음)에서도 라이선스를 적용할 수 있나요?**

예. 라이선스 검증은 라이선스 파일을 사용해 로컬에서 수행되므로 인터넷 연결이 필요하지 않습니다.

**1년 구독이 만료되면 어떻게 되나요? 라이브러리가 작동을 멈추나요?**

아니요. 라이선스는 영구적이며, 구독 종료일 이전에 출시된 버전은 계속 사용할 수 있습니다. 다만 갱신하지 않는 한 최신 릴리스를 사용할 수 없게 됩니다.