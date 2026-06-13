---
title: 라이선스
type: docs
weight: 80
url: /ko/python-net/licensing/
keywords:
- 라이선스
- 임시 라이선스
- 라이선스 설정
- 라이선스 사용
- 라이선스 검증
- 라이선스 파일
- 평가 버전
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET에서 라이선스를 적용, 관리 및 문제 해결하는 방법을 배우세요. 단계별 라이선스 가이드를 통해 전체 기능에 대한 중단 없는 접근을 보장합니다."
---
## **개요**

Aspose.Slides는 평가 모드나 유효한 라이선스로 사용할 수 있습니다. 평가 버전은 라이선스 버전과 동일한 기능을 제공하지만 프레젠테이션을 열거나 저장할 때 평가 워터마크가 추가되고 텍스트 추출이 한 슬라이드로 제한됩니다.

## **Aspose.Slides 평가**

귀하는 **Aspose.Slides for Python via .NET**의 평가 버전을 [download page](https://pypi.org/project/Aspose.Slides/)에서 다운로드할 수 있습니다. 평가 버전은 라이선스 제품과 동일한 기능을 제공합니다. 평가 패키지는 구매한 패키지와 동일하며, 라이선스를 적용하는 몇 줄의 코드를 추가하면 라이선스가 적용됩니다.

Aspose.Slides 평가에 만족하면 [라이선스 구매](https://purchase.aspose.com/buy) 페이지에서 라이선스를 구매할 수 있습니다. 이용 가능한 구독 옵션을 검토하시길 권장합니다. 질문이 있으면 Aspose 영업팀에 문의하십시오.

모든 Aspose 라이선스에는 1년 구독이 포함되어 있으며, 해당 기간 동안 새로운 버전 및 수정 사항에 대한 무료 업그레이드를 제공합니다. 라이선스 사용자와 평가 사용자 모두 무료 무제한 기술 지원을 받습니다.

**평가 버전의 제한 사항**

* Aspose.Slides 평가 버전(라이선스가 적용되지 않은 경우)은 전체 기능을 제공하지만 문서를 열거나 저장할 때 문서 상단에 평가 워터마크가 추가됩니다.
* 프레젠테이션에서 텍스트를 추출할 때는 한 슬라이드로 제한됩니다.

{{% alert color="primary" %}}
제한 없이 Aspose.Slides를 테스트하려면 **30일 임시 라이선스**를 요청할 수 있습니다. 자세한 내용은 [How to Get a Temporary License](https://purchase.aspose.com/temporary-license) 페이지를 참조하십시오.
{{% /alert %}}

## **Aspose.Slides 라이선스**

* 평가 버전은 라이선스를 구매하고 적용 코드를 몇 줄 추가하면 라이선스로 전환됩니다.
* 라이선스는 제품 이름, 적용 대상 개발자 수, 구독 만료 일자 등 상세 정보를 포함하는 평문 XML 파일입니다.
* 라이선스 파일은 디지털 서명되어 있으므로 수정해서는 안 됩니다. 한 줄이라도 추가하면 무효화됩니다.
* Aspose.Slides for Python via .NET은 일반적으로 다음 위치에서 라이선스를 찾습니다.
  * 명시적으로 지정한 경로
  * Aspose.Slides for Python via .NET을 호출하는 Python 스크립트가 위치한 폴더
* 평가 제한을 피하려면 Aspose.Slides를 사용하기 전에 라이선스를 설정하십시오. 애플리케이션이나 프로세스당 한 번만 설정하면 됩니다.

{{% alert color="primary" %}}
또한 [사용량 기반 라이선스](/slides/ko/python-net/metered-licensing/)를 검토하시기 바랍니다.
{{% /alert %}}

## **라이선스 적용**

라이선스는 **파일**, **스트림**, 또는 **임베디드 리소스**에서 로드할 수 있습니다.

{{% alert color="primary" %}}
Aspose.Slides는 라이선스 처리를 위해 [License 클래스](https://reference.aspose.com/slides/ko/python-net/aspose.slides/license/)를 제공합니다.
{{% /alert %}}

{{% alert color="warning" %}}
새 라이선스는 버전 21.4 이상에서만 Aspose.Slides를 활성화할 수 있습니다. 이전 버전은 다른 라이선스 시스템을 사용하므로 이러한 라이선스를 인식하지 못합니다.
{{% /alert %}}

### **파일**

라이선스를 설정하는 가장 쉬운 방법은 라이선스 파일을 구성 요소 DLL이 있는 동일한 폴더에 두고 파일 이름만 지정하는 것입니다(경로 제외).

다음 Python 코드는 라이선스 파일을 설정하는 방법을 보여줍니다:

```py
import aspose.slides as slides

# License 클래스를 인스턴스화합니다. 
license = slides.License()

# 라이선스 파일 경로를 설정합니다.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" %}}
라이선스 파일을 다른 디렉터리에 두는 경우 [License.set_license()](https://reference.aspose.com/slides/ko/python-net/aspose.slides/license/set_license/#str)를 호출할 때 명시적 경로의 끝에 있는 파일 이름이 라이선스 파일 이름과 일치해야 합니다.

예를 들어 라이선스 파일 이름을 *Aspose.Slides.lic.xml* 로 바꿀 수 있습니다. 그런 다음 코드에서 해당 파일의 전체 경로(Aspose.Slides.lic.xml 로 끝나는)를 [License.set_license()](https://reference.aspose.com/slides/ko/python-net/aspose.slides/license/set_license/#str) 메서드에 전달하십시오.
{{% /alert %}}

### **스트림**

스트림에서 라이선스를 로드할 수 있습니다. 다음 Python 예제는 스트림에서 라이선스를 적용하는 방법을 보여줍니다:

```py
import aspose.slides as slides

# License 클래스를 인스턴스화합니다.
license = slides.License()

# 스트림에서 라이선스를 설정합니다.
license.set_license(stream)
```

## **라이선스 검증**

라이선스가 올바르게 적용되었는지 확인하려면 검증할 수 있습니다. 다음 Python 코드는 라이선스를 검증하는 방법을 시연합니다:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **스레드 안전성**

{{% alert title="Note" color="warning" %}}
[License.set_license](https://reference.aspose.com/slides/ko/python-net/aspose.slides/license/) 메서드는 스레드 안전하지 않습니다. 여러 스레드에서 동시에 호출해야 하는 경우 동기화 프리미티브(예: `threading.Lock`)를 사용하여 문제를 방지하십시오.
{{% /alert %}}

## **FAQ**

**라이선스를 완전히 오프라인 환경(인터넷 연결 없음)에서 적용할 수 있나요?**

예. 라이선스 검증은 라이선스 파일을 사용하여 로컬에서 수행되므로 인터넷 연결이 필요하지 않습니다.

**1년 구독이 만료된 후에는 어떻게 되나요? 라이브러리가 작동을 중지합니까?**

아니요. 라이선스는 영구적이며 구독 종료일 이전에 릴리스된 버전은 계속 사용할 수 있습니다. 다만 구독을 갱신하지 않으면 최신 릴리스를 사용할 수 없습니다.