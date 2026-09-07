---
title: Python에서 PPTX를 PPT로 변환
linktitle: PPTX를 PPT로
type: docs
weight: 21
url: /ko/python-java/convert-pptx-to-ppt/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPTX 변환
- PPTX를 PPT로
- PPTX를 PPT로 저장
- PPTX를 PPT로 내보내기
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Python에서 Aspose.Slides for Python via Java를 사용하여 PPTX를 레거시 PPT 형식으로 변환합니다. 코드 예제와 호환성 및 보호된 파일에 대한 주석이 포함되어 있습니다."
---
## **개요**

Aspose.Slides for Python via Java를 사용하면 Microsoft PowerPoint를 설치하지 않아도 PowerPoint 97–2003에서 사용되는 레거시 PPT 형식으로 PPTX 프레젠테이션을 변환할 수 있습니다. 아래와 같이 PPTX 파일을 로드하고 PPT 출력 형식으로 저장합니다.

## **PPTX를 PPT로 변환**

[Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스로 소스 파일을 로드한 다음, 출력 경로와 [SaveFormat.Ppt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/#Ppt)를 지정하여 [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save)를 호출합니다.

다음 예제는 필요할 경우 Java 가상 머신을 시작하고 `template.pptx`를 `output.ppt`로 기본 옵션을 사용하여 변환합니다. 경로를 자신의 파일 이름으로 바꾸세요. `finally` 블록은 저장에 실패하더라도 프레젠테이션 리소스를 해제합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# PPTX 프레젠테이션을 로드합니다.
presentation = Presentation("template.pptx")
try:
    # 프레젠테이션을 PPT 형식으로 저장합니다.
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

[SaveFormat.Ppt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/#Ppt) 매개변수는 출력 형식을 선택합니다; 파일 확장자만 변경해도 프레젠테이션이 변환되지 않습니다. 새로운 기능에 PPT에 해당하는 것이 없을 경우를 대비해 원본 PPTX 파일을 보관하세요.

## **PPTX를 다른 형식으로 변환**

Aspose.Slides는 다른 출력 형식도 지원합니다. 형식별 옵션 및 예제는 해당 문서를 참고하세요:

- [Convert PowerPoint to PDF in Python](/slides/ko/python-java/convert-powerpoint-to-pdf/)
- [Convert PowerPoint to XPS in Python](/slides/ko/python-java/convert-powerpoint-to-xps/)
- [Convert PowerPoint to HTML in Python](/slides/ko/python-java/convert-powerpoint-to-html/)
- [Save Presentations as ODP in Python](/slides/ko/python-java/save-presentation/)
- [Convert PowerPoint to PNG in Python](/slides/ko/python-java/convert-powerpoint-to-png/)

## **FAQ**

**모든 PPTX 효과와 기능이 PPT로 변환될 때 유지되나요?**

항상 그런 것은 아닙니다. 레거시 PPT 형식은 PPTX에서 제공되는 모든 기능을 지원하지 않습니다. 일부 효과, 개체 또는 동작은 단순화되거나 다르게 표시될 수 있습니다. 특히 최신 PowerPoint 기능이 포함된 경우 변환된 프레젠테이션을 의도된 뷰어에서 검토하세요.

**선택한 슬라이드만 PPT로 변환할 수 있나요?**

PPT로 저장하면 전체 프레젠테이션이 저장됩니다. 선택한 슬라이드만 변환하려면 새 프레젠테이션을 만들고 초기 빈 슬라이드를 제거한 뒤, 필요한 슬라이드를 복제하여 추가하고 PPT로 저장합니다. 자세한 내용은 [Clone Slides in Python](/slides/ko/python-java/clone-slides/)를 참조하세요.

**비밀번호로 보호된 PPTX 파일을 변환할 수 있나요?**

예, 소스 프레젠테이션을 로드할 때 올바른 비밀번호를 제공하면 가능합니다. 출력 파일에 대한 보호도 설정할 수 있습니다. 자세한 내용은 [Password-Protected Presentations](/slides/ko/python-java/password-protected-presentation/)를 참고하세요.