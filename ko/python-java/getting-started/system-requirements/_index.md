---
title: 시스템 요구 사항
type: docs
weight: 60
url: /ko/python-java/system-requirements/
keywords:
- 시스템 요구 사항
- Python
- Java
- JPype
- Windows
- Linux
- macOS
- Aspose.Slides
description: "Windows, Linux 및 macOS에서 Aspose.Slides for Python via Java를 실행하기 위한 운영 체제, Python, Java 및 JPype 요구 사항을 확인하십시오."
---
## **개요**

Aspose.Slides for Python via Java는 Microsoft PowerPoint를 설치하지 않고도 프레젠테이션을 생성, 수정, 변환 및 렌더링합니다. Java 라이브러리에 Python에서 접근하기 위해 JPype를 사용하므로 환경이 Python, Java 및 JPype를 모두 지원해야 합니다.

## **지원되는 운영 체제**

[Aspose.Slides 패키지](https://pypi.org/project/aspose-slides-java/)는 다음 운영 체제 계열을 지원합니다:

- Windows
- Linux
- macOS

선택한 Python, Java 및 JPype 릴리스가 지원하는 운영 체제 버전을 선택하십시오. Java만 사용할 수 있다고 해서 Python 패키지 및 해당 브리지와의 호환성이 보장되는 것은 아닙니다.

## **Python, Java 및 JPype 요구 사항**

| 구 성 요소 | 요구 사항 |
| --- | --- |
| Python | Aspose.Slides 패키지는 Python 3.7부터 3.14까지 지원한다고 선언합니다. 선택한 JPype 릴리스는 동일한 Python 버전을 지원해야 합니다; 예를 들어, [JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/)은 Python 3.8 이상이 필요합니다. |
| Java | 선택한 JPype 릴리스와 호환되는 Java 런타임 또는 JDK를 설치하십시오. 현재 [JPype 전제조건](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites)에서는 Java 11 이상을 지정합니다. Java 8은 JPype1 1.7.1을 실행할 수 없습니다. |
| JPype | Python 인터프리터, 운영 체제 및 CPU 아키텍처에 맞는 JPype1 패키지를 설치하십시오. |
| CPU 아키텍처 | Python과 Java 가상 머신(JVM)은 동일한 아키텍처를 사용해야 합니다. 예를 들어, 64비트 Python 인터프리터는 호환되는 64비트 JVM이 필요합니다. |

Apple Silicon에서는 Python과 Java가 모두 ARM64이거나 둘 다 x64를 사용해야 합니다. 독립적으로 실행되는 JVM이라도 아키텍처가 Python과 다르면 JPype를 통해 로드되지 않을 수 있습니다.

새 환경에서는 Python 3.12, JDK 17 및 JPype1 1.7.1이 적절한 시작점입니다. 이 조합은 Windows에서 Aspose.Slides for Python via Java 26.6.0으로 검증되었습니다. 다른 조합은 세 구성 요소 모두의 요구 사항을 충족해야 합니다.

환경 설정 및 작동 검증 예제는 [설치](/slides/ko/python-java/installation/)을 참조하십시오.

## **추가 종속성**

호환되는 사전 빌드 JPype wheel은 C++ 컴파일러가 필요하지 않습니다. JPype를 소스에서 빌드해야 하는 경우, 플랫폼에 맞는 C++ 컴파일러와 Python 개발 파일을 설치하십시오. 빌드 요구 사항 및 문제 해결 방법은 [JPype 설치 안내](https://jpype.readthedocs.io/en/latest/install.html)를 참조하십시오.

## **FAQ**

**Microsoft PowerPoint를 설치해야 합니까?**

아니요. Aspose.Slides는 PowerPoint와 별개로 프레젠테이션을 처리합니다. 여전히 Python, Java 및 JPype가 필요합니다.

**Python 3.7을 모든 JPype 릴리스와 함께 사용할 수 있나요?**

아니요. Aspose.Slides 패키지가 Python 3.7 지원을 선언하지만, JPype1 1.7.1은 Python 3.8 이상이 필요합니다. 요구 사항이 겹치는 버전을 선택하십시오.

**32비트 Python을 64비트 Java와 혼용할 수 있나요?**

아니요. JPype는 JVM을 Python 프로세스에 로드하므로 Python과 Java는 동일한 아키텍처여야 합니다. macOS에서 ARM64와 x64도 동일하게 적용됩니다.