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
description: "Aspose.Slides for Python via .NET에서 라이선스를 적용, 관리 및 문제 해결하는 방법을 알아보세요. 단계별 라이선스 가이드를 통해 전체 기능을 중단 없이 이용할 수 있습니다."
---
## **개요**

Aspose.Slides는 평가 모드 또는 유효한 라이선스로 사용할 수 있습니다. 평가 버전은 라이선스가 적용된 버전과 동일한 기능을 제공하지만, 저장하는 각 프레젠테이션의 모든 슬라이드에 평가 워터마크를 추가하고 코드가 프레젠테이션에서 읽어들이는 텍스트를 잘라냅니다.

## **Aspose.Slides 평가**

**Aspose.Slides for Python via .NET**의 평가 버전을 [download page](https://pypi.org/project/Aspose.Slides/)에서 다운로드할 수 있습니다. 평가 버전은 라이선스 제품과 동일한 기능을 제공하며, 구매한 패키지와 동일하고 라이선스를 적용하는 몇 줄의 코드를 추가하면 라이선스가 적용됩니다.

평가가 만족스러우면 **Aspose.Slides**를 [purchase a license](https://purchase.aspose.com/pricing/slides/python-net/)할 수 있습니다. 사용 가능한 구독 옵션을 검토하시기 바랍니다. 질문이 있으면 Aspose 영업팀에 문의하십시오.

모든 Aspose 라이선스에는 1년 구독이 포함되며, 해당 기간 동안 새 버전 및 버그 수정에 대한 무료 업그레이드가 제공됩니다. 라이선스 사용자와 평가 사용자 모두 무료 무제한 기술 지원을 받습니다.

**평가 버전의 제한사항**

* 라이선스가 적용되지 않은 평가 버전은 전체 기능을 제공하지만, 저장하는 각 프레젠테이션의 모든 슬라이드에 평가 워터마크 텍스트 박스를 추가합니다.
* 프레젠테이션에서 코드가 읽어오는 텍스트는 앞 몇 글자로 잘리고 평가 제한에 대한 알림이 추가됩니다. 코드가 쓰는 텍스트는 전체가 저장됩니다.

{{% alert color="info" title="Note" %}}
제한 없이 Aspose.Slides를 테스트하려면 **30일 임시 라이선스**를 요청할 수 있습니다. 자세한 내용은 [How to Get a Temporary License](https://purchase.aspose.com/temporary-license) 페이지를 참조하십시오.
{{% /alert %}}

## **Aspose.Slides 라이선스**

* 평가 버전은 라이선스를 구매하고 몇 줄의 코드를 추가하면 라이선스가 적용됩니다.
* 라이선스는 제품 이름, 해당 개발자 수, 구독 만료일 등 세부 정보를 포함하는 텍스트 기반 XML 파일입니다.
* 라이선스 파일은 디지털 서명되어 있으므로 수정하면 안 됩니다. 한 줄이라도 추가하면 무효화됩니다.
* Aspose.Slides for Python via .NET은 지정한 경로에서 라이선스를 찾습니다. 상대 경로나 경로가 없는 파일 이름은 현재 작업 디렉터리를 기준으로 해석되며, 이는 반드시 Python 스크립트가 있는 폴더와 일치하지 않을 수 있습니다.
* 평가 제한을 피하려면 Aspose.Slides를 사용하기 전에 라이선스를 설정하십시오. 애플리케이션 또는 프로세스당 한 번만 설정하면 됩니다.

{{% alert color="info" title="Note" %}}
[Metered Licensing](/slides/ko/python-net/metered-licensing/)도 확인해 보십시오.
{{% /alert %}}

## **라이선스 적용**

라이선스는 **파일** 또는 **스트림**에서 로드할 수 있습니다.

{{% alert color="info" title="Note" %}}
Aspose.Slides는 라이선스 관리를 위해 [License](https://reference.aspose.com/slides/python-net/aspose.slides/license/) 클래스를 제공합니다.
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
새 라이선스는 버전 21.4 이상에서만 Aspose.Slides를 활성화할 수 있습니다. 이전 버전은 다른 라이선스 시스템을 사용하며 이러한 라이선스를 인식하지 못합니다.
{{% /alert %}}

### **파일**

라이선스를 설정하는 가장 간단한 방법은 라이선스 파일 경로를 [set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/) 메서드에 전달하는 것입니다. 아래 예시처럼 파일 이름만 전달하면 Aspose.Slides는 현재 작업 디렉터리에서 파일을 찾습니다.

다음 Python 코드는 라이선스 파일을 설정하는 방법을 보여줍니다:

```py
import aspose.slides as slides

# License 클래스를 인스턴스화합니다. 
license = slides.License()

# 라이선스 파일 경로를 설정합니다.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" title="Warning" %}}
라이선스 파일을 다른 디렉터리에 두는 경우, [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str) 메서드를 호출할 때 명시적인 경로의 마지막 파일 이름은 라이선스 파일 이름과 정확히 일치해야 합니다.

예를 들어 라이선스 파일 이름을 *Aspose.Slides.lic.xml*로 바꿀 수 있습니다. 그런 다음 코드에서 해당 파일의 전체 경로(Aspose.Slides.lic.xml로 끝나는)를 [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str) 메서드에 전달하십시오.
{{% /alert %}}

### **스트림**

스트림에서 라이선스를 로드할 수 있습니다. 다음 Python 예시는 스트림에서 라이선스를 적용하는 방법을 보여줍니다:

```py
import aspose.slides as slides

# License 클래스를 인스턴스화합니다.
license = slides.License()

# 스트림에서 라이선스를 설정합니다.
with open("Aspose.Slides.lic", "rb") as stream:
    license.set_license(stream)
```

## **라이선스 검증**

라이선스가 올바르게 적용되었는지 확인하려면 검증할 수 있습니다. 다음 Python 코드는 라이선스를 검증하는 방법을 보여줍니다:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **스레드 안전성**

{{% alert color="warning" title="Warning" %}}
[License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/) 메서드는 스레드 안전하지 않습니다. 여러 스레드에서 동시에 호출해야 하는 경우 `threading.Lock`과 같은 동기화 프리미티브를 사용하십시오.
{{% /alert %}}

## **FAQ**

### 라이선스를 완전히 오프라인 환경(인터넷 연결 없음)에서 적용할 수 있나요?

예. 라이선스 검증은 라이선스 파일을 사용해 로컬에서 수행되므로 인터넷 연결이 필요하지 않습니다.

### 1년 구독이 만료되면 어떻게 되나요? 라이브러리가 작동을 멈추나요?

아니요. 라이선스는 영구적이며 구독 종료일까지 릴리스된 버전을 계속 사용할 수 있습니다. 다만 구독을 갱신하지 않으면 최신 릴리스를 사용할 수 없습니다.