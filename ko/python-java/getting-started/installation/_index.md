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
description: "Windows, Linux 또는 macOS에서 Java를 통해 Python용 Aspose.Slides를 설치하고, Java와 JPype를 구성한 후, 작동 예제로 설정을 확인합니다."
---
Aspose.Slides for Python via Java은 Windows, Linux 및 macOS에서 실행됩니다. JPype를 사용하여 Python에서 Java 라이브러리에 접근합니다. Microsoft PowerPoint는 필요하지 않습니다.

## **전제 조건**

Before installing the Python packages, install Python and a JDK that meet the [System Requirements](/slides/ko/python-java/system-requirements/). That page lists compatible versions, architecture requirements, and any dependencies needed to build JPype from source.

Set `JAVA_HOME`를 JDK 설치 디렉터리(그 안의 `bin` 하위 디렉터리가 아니라)로 설정하고, JDK의 `bin` 디렉터리를 `PATH`에 추가하십시오. 환경 변수를 변경한 후 새 터미널을 열십시오.

## **PyPI에서 설치**

Run the following commands in a terminal, not at the Python interactive prompt. Create a project directory and a virtual environment to keep the packages isolated from other projects.

### **Windows**

With your chosen Python interpreter available as `python` on `PATH`, run the following commands in Command Prompt:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux 및 macOS**

With your chosen Python version available as `python3`, run the following commands in Bash or zsh:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

On Debian 또는 Ubuntu에서 `ensurepip`을 사용할 수 없어 환경 생성에 실패하면, `sudo apt-get install python3-venv` 명령으로 `python3-venv` 패키지를 설치한 다음 환경 생성 명령을 다시 실행하십시오. 별도로 설치된 Python 버전은 해당 버전에 맞는 `venv` 패키지가 필요할 수 있습니다.

### **패키지 설치**

With the virtual environment active, install JPype and Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

Using `python -m pip`를 사용하면 애플리케이션을 실행하는 인터프리터에 패키지가 설치됩니다.

To update an existing Aspose.Slides installation, run `python -m pip install --upgrade aspose-slides-java` in the same environment.

## **ZIP 아카이브에서 설치**

다음 [Aspose.Slides 다운로드 페이지](https://releases.aspose.com/slides/python-java/)에서 라이브러리를 사용할 수도 있습니다:

1. 전제 조건([Prerequisites](#prerequisites)에서 설명한 대로)에서 Python과 Java를 설치하십시오.
2. 위 지침을 사용하여 가상 환경을 생성하고 활성화하십시오.
3. `python -m pip install JPype1` 명령으로 JPype를 설치하십시오.
4. Aspose.Slides for Python via Java ZIP 아카이브를 다운로드하고 압축을 푸십시오.
5. 압축을 푼 `asposeslides` 패키지 디렉터리를 찾으십시오. `lib` 디렉터리와 JAR 파일을 포함한 모든 내용을 함께 유지하십시오.
6. `example.py` 파일을 다음 섹션에서 `asposeslides` 디렉터리와 같은 위치에 배치하여 Python이 패키지를 가져올 수 있도록 하십시오. 아카이브에는 이미 `asposeslides` 옆에 자체 `example.py`가 포함되어 있으니, 아래의 파일로 교체하십시오.

## **설치 확인**

다음 코드를 `example.py` 파일로 저장하십시오. 이 코드는 텍스트 상자가 포함된 프레젠테이션을 만들고 현재 작업 디렉터리에 `out.pptx`로 저장합니다.

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

With the virtual environment active, run the example from the directory containing `example.py`:

```sh
python example.py
```

`asposeslides` 임포트는 JVM이 시작되기 전에 번들된 Java 라이브러리를 등록합니다. JVM을 시작한 후에 `asposeslides.api`를 임포트하고, 종료하기 전에 프레젠테이션 리소스를 해제하십시오.

{{% alert color="info" title="Note" %}}
라이선스가 없으면 출력에 평가 워터마크가 포함됩니다. 평가 제한 및 임시 라이선스 정보는 [Evaluate Aspose.Slides](/slides/ko/python-java/evaluate-aspose-slides/)를 참고하십시오.
{{% /alert %}}

## **FAQ**

**Python이 JVM을 찾을 수 없거나 로드할 수 없다고 보고하는 이유는 무엇인가요?**

`JAVA_HOME`가 Python 및 JPype 설치와 호환되는 JDK를 가리키는지 확인하십시오( [System Requirements](/slides/ko/python-java/system-requirements/)에 설명되어 있습니다). 추가 확인 사항은 [JPype 설치 문제 해결 가이드](https://jpype.readthedocs.io/en/latest/install.html)를 참조하십시오.

**설치 후 Python이 `asposeslides`가 없다고 보고하는 이유는 무엇인가요?**

패키지가 다른 Python 인터프리터에 설치되었을 수 있습니다. 설치에 사용한 가상 환경을 활성화하고 `python -m pip show aspose-slides-java`를 실행하십시오. ZIP 설치의 경우, `asposeslides` 디렉터리가 스크립트와 같은 위치에 있거나 Python 모듈 검색 경로에 포함되어 있는지 확인하십시오.

**노트북에서 예제를 반복해서 실행할 수 있나요?**

이 예제는 독립 실행형 Python 프로세스를 위해 설계되었습니다. 노트북에서 반복 실행하도록 수정하기 전에, JVM 라이프사이클 및 노트북 관련 안내는 [Limitations and API Differences](/slides/ko/python-java/limitations-and-api-differences/#import-the-library)를 참고하십시오.

**pip이 `CERTIFICATE_VERIFY_FAILED` 오류로 실패하는 이유는 무엇인가요?**

네트워크에서 HTTPS 검사 프록시를 사용하는 경우, pip이 해당 인증 기관을 신뢰하도록 해야 합니다. pip의 `--cert` 옵션 또는 `PIP_CERT` 환경 변수를 사용하여 신뢰할 수 있는 CA 번들을 구성하십시오. 자세한 내용은 [pip HTTPS 인증서 지침](https://pip.pypa.io/en/stable/topics/https-certificates/)을 참고하십시오. 필요한 구성은 네트워크 및 pip 버전에 따라 다릅니다.