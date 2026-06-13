---
title: 설치
type: docs
weight: 70
url: /ko/python-java/installation/
keywords:
- Aspose.Slides 다운로드
- Aspose.Slides 설치
- Aspose.Slides 설치
- Windows
- macOS
- Linux
- Python
description: "Windows, Linux 또는 macOS에서 Java를 통해 Python용 Aspose.Slides를 설치합니다"
---
Aspose.Slides for Python via Java는 플랫폼에 독립적인 API이며 `Python`, `Java` 및 `jpype1` 브리지가 설치된 모든 플랫폼(Windows, Linux 및 MacOS)에서 사용할 수 있습니다.

## **프로그램 및 버전 요구 사항**

Aspose.Slides for Python via Java가 올바르게 작동하려면 다음 프로그램 및 패키지를 설치해야 합니다:

- JRE 버전 >=8 (JPype1은 Java 버전 1.8부터 11까지 테스트되었습니다).
- Python 버전 >=3.7, <=3.12.
- JPype1 패키지 버전: >=1.5.0.

## **pip에서 설치**

필요한 모든 프로그램(Java, Python)이 설치되어 있으면 [pip](https://pypi.org/)에서 Aspose.Slides for Python via Java를 쉽게 설치할 수 있습니다.

새 프로젝트 폴더를 만듭니다.

[JPype1 설치](https://jpype.readthedocs.io/en/latest/install.html) 를 다음 명령으로 수행합니다:
```
$ pip install JPype1
```

다음 명령을 사용하여 Aspose.Slides for Python via Java를 설치합니다:
```
$ pip install aspose-slides-java
```

## **ZIP 아카이브에서 설치**

ZIP 아카이브에서 Aspose.Slides for Python via Java를 설치하고 사용하려면 다음 지침을 따르세요:

### **Windows**

1. JDK8을 설치하고 `JAVA_HOME` 환경 변수를 구성합니다.
2. [Python 설치](https://www.python.org/downloads/) 버전 >=3.7을 설치하고 python.exe를 `PATH`에 추가합니다.
3. [Microsoft C++ 빌드 도구 설치](https://visualstudio.microsoft.com/visual-cpp-build-tools/).
4. [JPype1 설치](https://jpype.readthedocs.io/en/latest/install.html). Python 터미널에서 아래 명령을 실행할 수 있습니다:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Aspose.Slides for Python via Java 다운로드](https://releases.aspose.com/slides/ko/python-java/)하고 `aspose-slides-java` 폴더에 압축을 풉니다.
6. `aspose-slides-java` 폴더에 `example.py` 파일을 다음 샘플 코드를 사용하여 생성합니다:
```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
7. 이제 명령 프롬프트에서 `py example.py`를 실행합니다.

### **Linux**

1. Linux용 JDK8을 설치하고 `JAVA_HOME` 환경 변수를 구성합니다.
2. [Python 설치](https://www.python.org/downloads/) 버전 >=3.7
3. ``g++`` 및 ``python-dev``를 설치합니다.

- Debian/Ubuntu의 경우:
    ```
    sudo apt-get install g++ python3-dev
```
- RedHat 기반의 경우:
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. [JPype1 설치](https://jpype.readthedocs.io/en/latest/install.html). Python 터미널에서 아래 명령을 실행할 수 있습니다:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Aspose.Slides for Python via Java 다운로드](https://releases.aspose.com/slides/ko/python-java/)하고 `aspose-slides-java`에 압축을 풉니다.
6. `aspose-slides-java` 폴더에 이 샘플 코드를 사용하여 `example.py` 테스트 파일을 생성합니다:
```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
7. 이제 명령 프롬프트에서 `py example.py`를 실행합니다.

### **Mac**

1. Mac용 JDK8을 설치하고 `JAVA_HOME` 환경 변수를 구성합니다.
2. `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist`의 JVMCapabilities 섹션을 루트 권한으로 수정합니다. `jdk1.8.x_xxx.jdk`는 jdk 버전에 따라 다릅니다. 아래와 같이 설정합니다:
```xml
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```
3. [Python 설치](https://www.python.org/downloads/) 버전 >=3.7.
4. Python 버전 및 플랫폼에 따라 GCC 또는 Clang 컴파일러를 설치합니다.
5. [JPype1 설치](https://jpype.readthedocs.io/en/latest/install.html). Python 터미널에서 아래 명령을 실행할 수 있습니다:
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [Aspose.Slides for Python via Java 다운로드](https://releases.aspose.com/slides/ko/python-java/)하고 `aspose-slides-java`에 압축을 풉니다.
7. `aspose-slides-java` 폴더에 이 샘플 코드를 사용하여 `example.py` 테스트 파일을 생성합니다:
```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
9. 이제 명령 프롬프트에서 `python example.py`를 실행합니다.