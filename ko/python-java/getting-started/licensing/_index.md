---
title: 라이선스
type: docs
weight: 80
url: /ko/python-java/licensing/
keywords:
- Aspose.Slides
- 파이썬
- 자바
- 라이선스 파일
- 임시 라이선스
- 사용량 기반 라이선스
- 평가 제한 사항
description: "Aspose.Slides for Python via Java에서 파일 기반, 바이트 기반 또는 사용량 기반 라이선스를 적용하고 응용 프로그램의 평가 제한을 제거합니다."
---
## **개요**

Aspose.Slides for Python via Java은 평가 모드 또는 라이선스 모드로 실행될 수 있습니다. 이 문서에서는 파일 또는 바이트에서 라이선스를 적용하는 방법과 Metered 라이선스를 구성하는 방법을 설명합니다.

구매 옵션은 [Pricing Information](https://purchase.aspose.com/pricing/slides/ko/family) 를 참조하십시오. 일반 라이선스 및 구매 관련 질문은 [Purchase Policies and FAQ](https://purchase.aspose.com/policies) 를 확인하십시오.

평가 제한 및 임시 라이선스 요청 방법은 [Evaluate Aspose.Slides](/slides/ko/python-java/evaluate-aspose-slides/) 를 참조하십시오. 임시 라이선스는 구매한 라이선스 파일과 동일한 방식으로 적용합니다.

## **라이선스 정보**

라이선스 파일에는 제품 이름, 라이선스 사용자 수, 구독 만료일 등의 정보가 포함됩니다. 파일은 디지털 서명된 XML 형식입니다.

{{% alert color="warning" title="경고" %}}
라이선스 파일을 수정하지 마십시오. 한 줄의 공백이라도 디지털 서명을 무효화할 수 있습니다.
{{% /alert %}}

프레젠테이션을 만들거나 Aspose.Slides 작업을 수행하기 전에 애플리케이션 또는 프로세스당 한 번 라이선스를 적용하십시오. 파일 기반 라이선스는 [License](https://reference.aspose.com/slides/ko/python-java/aspose.slides/license/) 클래스를 사용합니다. Metered 라이선스는 파일 대신 공개 키와 개인 키 쌍을 사용합니다.

## **라이선스 적용**

다음 예제는 Aspose.Slides for Python via Java와 해당 전제 조건이 설치되어 있다고 가정합니다. 각 예제는 JVM을 시작하고 API를 가져온 다음 라이선스를 적용하는 독립 실행형 스크립트입니다. 애플리케이션에서는 라이선스를 적용한 후에 프레젠테이션 작업을 수행하고, 모든 Aspose.Slides 작업이 끝난 뒤에 JVM을 종료하십시오.

### **파일에서 라이선스 적용**

[License.setLicense](https://reference.aspose.com/slides/ko/python-java/aspose.slides/license/#setLicense) 에 라이선스 파일 경로를 전달합니다. `Aspose.Slides.lic` 을 실제 라이선스 파일 경로로 바꾸십시오.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # 프레젠테이션 작업을 여기서 수행하고, JVM을 종료하기 전에 실행합니다.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

확장자를 포함한 정확한 파일 이름을 사용하십시오. 예를 들어 파일 이름이 `Aspose.Slides.lic.xml` 인 경우 경로에 `.xml` 을 포함해야 합니다. 절대 경로를 사용하면 애플리케이션 작업 디렉터리와 관련된 모호성을 피할 수 있습니다.

예제에서는 [License.isLicensed](https://reference.aspose.com/slides/ko/python-java/aspose.slides/license/#isLicensed) 를 사용해 라이선스가 적용되었는지 확인합니다.

### **바이트에서 라이선스 적용**

라이선스가 Python 바이트 형태로 제공되는 경우 [License.setLicenseFromBytes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/license/#setLicenseFromBytes) 를 사용하십시오. 다음 예제는 파일을 바이너리 모드로 읽고 닫은 후 라이선스를 적용합니다.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # 프레젠테이션 작업을 여기서 수행하고, JVM을 종료하기 전에 실행합니다.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

원본 바이트를 변경하지 말고 그대로 유지하십시오. 라이선스 내용을 디코딩하거나 재포맷하거나 다른 방식으로 수정하지 마십시오.

## **Metered 라이선스 적용**

Metered 라이선스는 API 사용량에 따라 과금됩니다. Metered 라이선스를 받은 후에는 [Metered.setMeteredKey](https://reference.aspose.com/slides/ko/python-java/aspose.slides/metered/#setMeteredKey) 로 공개 키와 개인 키를 적용하십시오. 애플리케이션 시작 시 한 번 [Metered](https://reference.aspose.com/slides/ko/python-java/aspose.slides/metered/) 객체를 초기화하고 키를 적용합니다.

다음 예제는 `ASPOSE_METERED_PUBLIC_KEY` 와 `ASPOSE_METERED_PRIVATE_KEY` 환경 변수에서 키를 읽습니다. 스크립트를 실행하기 전에 두 변수를 설정하십시오.

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # 프레젠테이션 작업을 여기서 수행하고, JVM을 종료하기 전에 실행합니다.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="참고" %}}
Metered 라이선스는 키 검증 및 사용량 보고를 위해 인터넷 연결이 필요합니다. 개인 키는 소스 코드와 로그에 포함되지 않도록 하십시오. 연결 및 청구 세부 정보는 [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) 를 참고하십시오.
{{% /alert %}}

## **FAQ**

**라이선스를 구매한 후에 다른 패키지를 설치해야 하나요?**

아니요. 평가에 사용한 동일한 패키지에 라이선스를 적용하면 됩니다.

**각 프레젠테이션마다 라이선스를 적용해야 하나요?**

아니요. 애플리케이션 시작 시 한 번, 프레젠테이션을 만들거나 로드하기 전에 적용하십시오.

**라이선스 파일 이름을 변경할 수 있나요?**

예. 코드에서 정확한 새 파일 이름을 사용하고 파일 내용은 그대로 유지하십시오.

**바이트 기반 예제에서 임시 라이선스를 사용할 수 있나요?**

예. 임시 라이선스 파일을 바이트 형태로 읽어 구매한 라이선스와 동일한 방법으로 적용하면 됩니다.