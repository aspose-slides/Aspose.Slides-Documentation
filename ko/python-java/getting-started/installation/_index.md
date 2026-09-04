---
title: 설치
type: docs
weight: 70
url: /ko/python-java/installation/
keywords:
- Aspose.Slides 다운로드
- Aspose.Slides 설치
- Aspose.Slides 설치
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "Windows, Linux 또는 macOS에서 Java를 통해 Python용 Aspose.Slides를 설치하고, Java와 JPype를 구성하며, 작동 예제로 설정을 확인합니다."
---
Aspose.Slides for Python via Java는 Windows, Linux 및 macOS에서 실행됩니다. JPype를 사용하여 Python에서 Java 라이브러리에 접근합니다. Microsoft PowerPoint는 필요하지 않습니다.

## **필수 조건**

Python 패키지를 설치하기 전에, [시스템 요구 사항](/slides/ko/python-java/system-requirements/)를 충족하는 Python과 JDK를 설치하십시오. 해당 페이지에서는 호환되는 버전, 아키텍처 요구 사항 및 JPype를 소스에서 빌드하는 데 필요한 모든 종속성을 나열합니다.

`JAVA_HOME`를 JDK 설치 디렉터리( `bin` 하위 디렉터리가 아님)로 설정하고, JDK의 `bin` 디렉터리를 `PATH`에 추가하십시오. 환경 변수를 변경한 후 새 터미널을 열십시오.

## **PyPI에서 설치**

다음 명령을 터미널에서 실행하십시오. Python 인터랙티브 프롬프트에서 실행하지 마십시오. 프로젝트 디렉터리와 가상 환경을 생성하여 패키지를 다른 프로젝트와 격리하십시오.

### **Windows**

`PATH`에 `python`으로 사용 가능한 선택한 Python 인터프리터가 있는 경우, 명령 프롬프트에서 다음 명령을 실행하십시오:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux 및 macOS**

`python3`으로 사용 가능한 선택한 Python 버전이 있는 경우, Bash 또는 zsh에서 다음 명령을 실행하십시오:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

Debian 또는 Ubuntu에서 `ensurepip`을 사용할 수 없어 환경 생성에 실패하면, `sudo apt-get install python3-venv` 명령으로 `python3-venv` 패키지를 설치한 후 환경 생성 명령을 다시 실행하십시오. 별도로 설치된 Python 버전은 해당 버전에 맞는 `venv` 패키지가 필요할 수 있습니다.

### **패키지 설치**

가상 환경이 활성화된 상태에서 JPype와 Aspose.Slides를 설치하십시오:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

`python -m pip`를 사용하면 애플리케이션을 실행하는 인터프리터에 패키지가 설치됩니다.

기존 Aspose.Slides 설치를 업데이트하려면, 동일한 환경에서 `python -m pip install --upgrade aspose-slides-java`를 실행하십시오.

## **ZIP 아카이브에서 설치**

다음 [Aspose.Slides 다운로드 페이지](https://releases.aspose.com/slides/ko/python-java/)에서 라이브러리를 사용할 수도 있습니다:

1. [전제 조건](#prerequisites)에서 설명한 대로 Python 및 Java를 설치하십시오.
2. 위 지침을 사용하여 가상 환경을 만들고 활성화하십시오.
3. `python -m pip install JPype1` 명령으로 JPype를 설치하십시오.
4. Aspose.Slides for Python via Java ZIP 아카이브를 다운로드하고 압축을 풉니다.
5. 추출된 `asposeslides` 패키지 디렉터리를 찾으십시오. `lib` 디렉터리 및 JAR 파일을 포함한 모든 내용을 함께 보관하십시오.
6. 다음 섹션의 `example.py` 파일을 `asposeslides` 디렉터리와 같은 위치에 두어 Python이 패키지를 import할 수 있도록 하십시오.

## **설치 확인**

다음 코드를 `example.py` 파일로 저장하십시오. 이 코드는 텍스트 상자가 포함된 프레젠테이션을 생성하고 현재 작업 디렉터리에 `out.pptx`로 저장합니다.

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

가상 환경이 활성화된 상태에서 `example.py`가 들어 있는 디렉터리에서 예제를 실행하십시오:

```sh
python example.py
```

`asposeslides` import는 JVM이 시작되기 전에 번들된 Java 라이브러리를 등록합니다. JVM을 시작한 후 `asposeslides.api`를 import하고, JVM을 종료하기 전에 프레젠테이션 리소스를 해제하십시오.

{{% alert color="info" title="참고" %}}
라이선스가 없으면 출력에 평가용 워터마크가 포함됩니다. 평가 제한 및 임시 라이선스 정보는 [Aspose.Slides 평가](/slides/ko/python-java/evaluate-aspose-slides/)를 참조하십시오.
{{% /alert %}}

## **자주 묻는 질문**

**Python이 JVM을 찾을 수 없거나 로드할 수 없다고 보고하는 이유는 무엇입니까?**

`JAVA_HOME`가 Python 및 JPype 설치와 호환되는 JDK를 가리키는지 확인하십시오( [시스템 요구 사항](/slides/ko/python-java/system-requirements/)에 설명됨). 추가 확인을 위해 [JPype 설치 문제 해결 가이드](https://jpype.readthedocs.io/en/latest/install.html)를 참고하십시오.

**설치 후 Python이 `asposeslides`가 없다고 보고하는 이유는 무엇입니까?**

패키지가 다른 Python 인터프리터에 설치되었을 수 있습니다. 설치에 사용한 가상 환경을 활성화하고 `python -m pip show aspose-slides-java`를 실행하십시오. ZIP 설치의 경우 `asposeslides` 디렉터리가 스크립트와 같은 위치에 있거나 Python 모듈 검색 경로에 포함되어 있는지 확인하십시오.

**노트북에서 예제를 반복해서 실행할 수 있습니까?**

이 예제는 독립형 Python 프로세스를 위해 설계되었습니다. 노트북에서 반복 실행하도록 조정하기 전에 JVM 수명 주기 및 노트북 가이드에 대해서는 [제한 사항 및 API 차이점](/slides/ko/python-java/limitations-and-api-differences/#import-the-library)을 참조하십시오.

**`CERTIFICATE_VERIFY_FAILED` 오류로 pip가 실패하는 이유는 무엇입니까?**

네트워크가 HTTPS 검사 프록시를 사용하는 경우, pip가 해당 인증서 기관을 신뢰하도록 해야 합니다. pip의 `--cert` 옵션 또는 `PIP_CERT` 환경 변수를 사용하여 신뢰할 수 있는 CA 번들을 구성하십시오. 자세한 내용은 [pip HTTPS 인증서 지침](https://pip.pypa.io/en/stable/topics/https-certificates/)을 참고하십시오. 필요한 구성은 네트워크와 pip 버전에 따라 다릅니다.