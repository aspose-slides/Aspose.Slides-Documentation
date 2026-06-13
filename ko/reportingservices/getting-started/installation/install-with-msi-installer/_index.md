---
title: MSI 설치 프로그램으로 설치
type: docs
weight: 20
url: /ko/reportingservices/install-with-msi-installer/
---
## **설치**
Aspose.Slides for Reporting Services를 MSI 설치 프로그램을 통해 설치할 수 있습니다.

{{% alert title="Note" color="warning" %}}

**Aspose.Slides for Reporting Services**는 호스트 머신에 **.NET Framework 3.5**가 설치되어 있어야 합니다.

{{% /alert %}}

***Aspose.Slides.ReportingServices.msi***를 실행하고 설치 프로그램이 제공하는 단계에 따라 진행하십시오.

설치 프로그램은 어셈블리와 기타 파일을 지정된 디렉터리로 복사하고 기본 Reporting Services 인스턴스에 제품을 설치합니다. 특별한 구성 매개변수를 추가하고 싶지 않은 한 파일을 수동으로 복사하거나 수정할 필요가 없습니다.

대부분의 경우 MSI 설치 프로그램을 이용한 설치가 최선의 옵션입니다. 그러나 특정 상황에서는 제품을 수동으로 설치하고 싶을 수 있습니다:

- 보안 문제 등으로 자동 설치가 실패하는 경우.
- 제품을 기본이 아닌 명명된 Reporting Services 인스턴스 또는 여러 인스턴스에 설치해야 하는 경우.
- 최신 버전으로 업그레이드한 후 MSI 설치 프로그램을 사용해 이전 버전을 제거하고 새 버전을 설치하지 않고 어셈블리만 교체하고자 할 때. **참고** 이 경우 다른 파일이 남을 수 있습니다.