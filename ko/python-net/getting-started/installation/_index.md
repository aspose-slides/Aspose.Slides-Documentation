---
title: 설치
type: docs
weight: 70
url: /ko/python-net/installation/
keywords:
- Aspose.Slides 다운로드
- Aspose.Slides 설치
- Aspose.Slides 사용
- Aspose.Slides 설치 방법
- Windows
- macOS
- Python
description: "Aspose.Slides for Python via .NET를 빠르게 설치하는 방법을 알아보세요. 단계별 가이드, 시스템 요구 사항 및 코드 예제가 포함되어 있어 오늘 바로 PowerPoint 프레젠테이션 작업을 시작할 수 있습니다!"
---
## **개요**

Aspose.Slides for Python via .NET 패키지는 필수 .NET 라이브러리를 모두 포함하고 있으므로 .NET을 별도로 설치할 필요가 없습니다. 이는 설정 과정을 간소화하고 개발자가 바로 프레젠테이션 작업을 시작할 수 있게 합니다. 다만 운영 체제나 환경에 따라 .NET이 요구하는 일부 플랫폼 별 종속성을 설치해야 할 수도 있습니다. 또한 패키지를 완전히 호환하고 정상적으로 동작시키려면 특정 시스템 요구 사항을 충족해야 합니다.

## **Windows**

**시스템 요구 사항**

귀하의 컴퓨터 사양이 [시스템 요구 사항](/slides/ko/python-net/system-requirements/)을 충족하거나 초과하는지 확인하십시오.

### **Aspose.Slides 설치**

`pip`은 Windows에서 [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/)을 다운로드하고 설치하는 가장 쉬운 방법입니다.

Aspose.Slides를 설치하려면 다음 명령을 실행하십시오:

```sh
pip install aspose-slides
```

**Aspose.Slides 사용**

다음 코드를 실행하여 PowerPoint 프레젠테이션을 만들어 Aspose.Slides 설치를 테스트하십시오:

```python
# Aspose.Slides for Python via .NET 모듈을 가져옵니다.
import aspose.slides as slides

# Presentation 클래스를 인스턴스화합니다. 이 클래스는 프레젠테이션 파일을 나타냅니다.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**시스템 요구 사항**

귀하의 컴퓨터 사양이 [시스템 요구 사항](/slides/ko/python-net/system-requirements/)을 충족하거나 초과하는지 확인하십시오.

### **전제 조건**

**공유 라이브러리를 포함한 Python**

macOS에 Python을 설치하는 방법은 여러 가지가 있지만, 우리는 [pyenv 도구](https://github.com/pyenv/pyenv#homebrew-in-macos)를 강력히 권장합니다.

**pyenv**를 설치하고 구성한 후, 터미널 앱에서 다음 명령을 실행하여 공유 라이브러리가 포함된 Python을 설치하십시오:

1. Python 설치:

```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```

2. 전역 Python 버전으로 설정:

```sh
pyenv global 3.9.13
```

3. 셸 전용 Python 버전으로 설정:

```sh
pyenv shell 3.9.13
```

4. 시스템 라이브러리 디렉터리에 libpython 라이브러리용 심볼릭 링크를 생성:

```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```

참고: Python 3.5 이상이 필요합니다. 여기서는 예시로 버전 3.9.13을 사용했습니다.

**libgdiplus 라이브러리 설치**

**libgdiplus** 라이브러리는 macOS 및 Linux에서 .NET이 그래픽 기능을 위해 의존하는 Windows GDI+ 구현입니다. macOS에 이 라이브러리를 설치하려면 다음 명령을 실행하십시오:

```sh
brew install mono-libgdiplus
```

### **Aspose.Slides 설치**

`pip`은 macOS에서 [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/)을 다운로드하고 설치하는 가장 쉬운 방법입니다.

Aspose.Slides를 설치하려면 다음 명령을 실행하십시오:

```sh
pip install aspose-slides
```

**Aspose.Slides 사용**

다음 코드를 실행하여 PowerPoint 프레젠테이션을 만들어 Aspose.Slides 설치를 테스트하십시오:

```python
# Aspose.Slides for Python via .NET 모듈을 가져옵니다.
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**가상 환경에 Aspose.Slides를 설치할 수 있나요?**

예, `pip`을 사용하여 모든 Python 가상 환경에 설치할 수 있습니다. 다만 사용 중인 OS에 따라 필요한 네이티브 종속성에 접근할 수 있도록 해야 합니다.

**Docker 컨테이너에서 Aspose.Slides를 사용할 수 있나요?**

예, 하지만 Docker 이미지에 필요한 네이티브 라이브러리(**libgdiplus**, 폰트 패키지 등)와 올바른 Python 버전이 포함되어 있는지 확인해야 합니다.

**무료 버전이나 평가 제한이 있나요?**

예, 기본적으로 Aspose.Slides는 평가 모드로 실행되며, 워터마크가 표시되고 기타 제한이 있을 수 있습니다. 제한을 해제하려면 유효한 [라이선스](/slides/ko/python-net/licensing/)를 적용해야 합니다.