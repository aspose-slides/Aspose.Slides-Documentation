---
title: PyInstaller 및 cx_Freeze와의 호환성
linktitle: PyInstaller와의 호환성
type: docs
weight: 122
url: /ko/python-net/compatibility-with-pyinstaller/
keywords:
- 호환성
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 PyInstaller로 패키징합니다. 이 가이드를 따라 애플리케이션을 번들하고, 구성하며, 독립 실행 파일로 문제를 해결하세요."
---
## **소개**

Aspose.Slides for Python via .NET 확장은 표준 Python C 확장이므로 PyInstaller 및 cx_Freeze(또는 유사한 도구)와 같은 도구를 사용해 프로그램 의존성으로 고정할 수 있습니다. 이를 통해 Python 스크립트에서 실행 파일을 만들 수 있습니다. 이러한 도구는 코드를 비롯한 모든 종속성을 하나의 배포 파일로 묶어 다른 컴퓨터에서 Python 설치나 추가 라이브러리 없이 실행할 수 있기 때문에 “프리저(freezer)”라고 불립니다. 이 방법은 Python 애플리케이션 배포를 단순화합니다.

아래는 Aspose.Slides를 사용하는 간단한 프로그램을 예시로 Aspose.Slides for Python via .NET 확장을 의존성으로 고정하는 방법을 보여줍니다.

## **PyInstaller**

일반적으로 Aspose.Slides for Python via .NET 확장에 의존하는 프로그램을 패키징할 때 별도의 특수 작업이 필요하지 않습니다. 프로그램이 PyInstaller가 감지할 수 있는 방식으로 확장을 임포트하면 해당 확장이 프로그램과 함께 번들됩니다. Aspose.Slides for Python via .NET은 PyInstaller 훅을 포함하고 있어 의존성을 자동으로 감지하고 번들에 복사합니다.

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

```bash
$ pyinstaller slide_app.py
```

하지만 PyInstaller는 때때로 숨겨진 임포트(코드에서 동적으로 또는 간접적으로 임포트되는 모듈)를 놓칠 수 있습니다. 숨겨진 임포트를 포함하려면 PyInstaller 옵션을 사용하십시오. 확장의 의존성은 Aspose.Slides for Python via .NET과 함께 제공되는 PyInstaller 훅에 명시되어 있습니다.

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```bash
$ pyinstaller slide_app.spec
```

## **cx_Freeze**

cx_Freeze를 사용해 프로그램을 고정하려면 사용 중인 Aspose.Slides for Python via .NET 확장의 루트 패키지를 포함하도록 설정하십시오. 이렇게 하면 확장과 모든 종속 모듈이 애플리케이션과 함께 빌드에 복사됩니다.

### **Using the cxfreeze Script**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

### **Using the Setup Script**

setup.py:
```
executables = [Executable('slide_app.py')]

options = {
    'build_exe': {
        'packages': ['aspose'],
    }
}

setup(...
    options=options,
    executables=executables)
```

```bash
$ python setup.py build_exe
```

## **FAQ**

**사용자의 머신에 Microsoft PowerPoint 또는 .NET이 설치되어 있어야 하나요?**

아니요, PowerPoint는 필요하지 않습니다. Aspose.Slides는 독립형 엔진이며, Python 패키지는 CPython용 확장으로 필요한 모든 것을 포함합니다. 사용자는 .NET을 별도로 설치할 필요가 없습니다.

**프리징된 애플리케이션에 라이선스를 올바르게 연결하려면 어떻게 해야 하나요?**

라이선스 XML 파일을 실행 파일 옆에 저장하거나 리소스로 포함한 뒤 첫 번째 API 호출 전에 접근 가능한 경로에서 로드하면 됩니다. 중요: XML 내용(줄 바꿈 포함)을 절대로 수정하지 마십시오.

**빌드 후 폰트가 개발 환경과 다르게 렌더링되는 경우 어떻게 해야 하나요?**

사용 중인 폰트가 대상 환경(번들에 포함되었거나 시스템에 설치된)에서 사용 가능한지 확인하고, 런타임에 경로가 올바르게 매핑되는지 점검하십시오. 특히 Linux에서는 폰트 동작이 매우 민감합니다.