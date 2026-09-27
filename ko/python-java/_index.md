---
title: Aspose.Slides for Python via Java
second_title: Aspose.Slides for Python
type: docs
weight: 47
url: /ko/python-java/
is_root: true
keywords:
- Aspose.Slides for Python via Java
- Python PowerPoint 라이브러리
- Python에서 PowerPoint 프레젠테이션 관리
- Python에서 PowerPoint 읽기 및 쓰기
- Python에서 PowerPoint 슬라이드 편집
- Python에서 PowerPoint를 PDF로 내보내기
- Python에서 PowerPoint를 SVG로 내보내기
- Python에서 슬라이드 미리보기
- Python에서 슬라이드에 오디오 및 비디오 추가
- Microsoft Office 없이 PowerPoint
- Python
- Java
- Aspose.Slides
description: "시작하기: Aspose.Slides for Python via Java를 설치하고 첫 프레젠테이션을 만든 다음, 일반 작업 가이드, API 참조 및 지원 정보를 찾으십시오."
---
<img src="aspose_slides-for-python-via-java.png" alt="Python을 위한 Aspose.Slides (Java 사용)" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java는 Microsoft PowerPoint 없이 Python 응용 프로그램에서 PowerPoint 및 OpenDocument 프레젠테이션을 만들고, 읽고, 편집하고 변환할 수 있는 라이브러리이며, JPype를 통해 Python 프로세스에서 Aspose.Slides Java 엔진을 실행합니다.

이 라이브러리는 매크로가 포함된 파일 및 템플릿 변형을 포함한 PPT, PPTX, PPS, POT, ODP를 로드하고 저장하며, PDF, XPS, HTML, SVG, TIFF, Markdown 및 이미지로 내보낼 수 있습니다.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>시작하기</b></p>
<hr>
<p>시작하기</p>
<ul>
<li><a href="/slides/ko/python-java/installation/">설치</a></li>
<li><a href="/slides/ko/python-java/create-presentation/">첫 번째 프레젠테이션 만들기</a></li>
<li><a href="/slides/ko/python-java/getting-started/">시작 가이드</a></li>
</ul>
<p>평가</p>
<ul>
<li><a href="/slides/ko/python-java/supported-file-formats/">지원 파일 형식</a></li>
<li><a href="/slides/ko/python-java/evaluate-aspose-slides/">체험 제한</a></li>
<li><a href="/slides/ko/python-java/licensing/">라이선스</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides로 빌드</b></p>
<hr>
<p>공통 작업</p>
<ul>
<li><a href="/slides/ko/python-java/open-presentation/">프레젠테이션 열기</a></li>
<li><a href="/slides/ko/python-java/save-presentation/">프레젠테이션 저장</a></li>
<li><a href="/slides/ko/python-java/convert-powerpoint-to-pdf/">PDF로 변환</a></li>
<li><a href="/slides/ko/python-java/convert-slide/">슬라이드를 이미지로 렌더링</a></li>
<li><a href="/slides/ko/python-java/manage-text/">텍스트 및 도형 편집</a></li>
</ul>
<p>Slides 워크플로</p>
<ul>
<li><a href="/slides/ko/python-java/powerpoint-charts/">차트</a></li>
<li><a href="/slides/ko/python-java/powerpoint-animation/">애니메이션</a></li>
<li><a href="/slides/ko/python-java/manage-media-files/">오디오 및 비디오</a></li>
<li><a href="/slides/ko/python-java/presentation-design/">슬라이드 디자인</a></li>
<li><a href="/slides/ko/python-java/merge-presentation/">프레젠테이션 병합</a></li>
</ul>
<p>예제</p>
<ul>
<li><a href="/slides/ko/python-java/examples/">슬라이드 요소별 예제</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>참조 및 지원</b></p>
<hr>
<p>참조</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">API 참조</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">릴리즈 노트</a></li>
<li><a href="/slides/ko/python-java/known-issues/">알려진 문제</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">다운로드</a></li>
</ul>
<p>지원</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">무료 지원 포럼</a></li>
<li><a href="https://helpdesk.aspose.com/">유료 지원 헬프데스크</a></li>
</ul>
</div>
</div>

------

## **첫 번째 프레젠테이션**

Python 및 JDK를 설치하고 `JAVA_HOME`을 설정한 뒤, [Installation](/slides/ko/python-java/installation/)에 설명된 대로 가상 환경을 만들고 활성화합니다. 그 다음 PyPI에서 JPype와 Aspose.Slides를 설치합니다:

```sh
python -m pip install JPype1 aspose-slides-java
```

이 코드를 *hello.py* 파일로 저장합니다. 이 코드는 Java 가상 머신을 시작하고, 새 프레젠테이션의 첫 슬라이드에 텍스트가 포함된 구름 모양을 추가한 뒤 프레젠테이션을 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# 한 개의 빈 슬라이드가 있는 프레젠테이션을 생성합니다.
presentation = Presentation()
try:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.getSlides().get_Item(0)

    # 구름 모양을 추가하고 텍스트를 설정합니다.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

동일한 가상 환경에서 실행합니다:

```sh
python hello.py
```

스크립트는 \"Hello, Aspose!\"라는 텍스트가 들어간 구름 모양을 포함한 슬라이드 하나를 가진 *new_presentation.pptx* 파일을 저장합니다. 라이선스가 없을 경우 저장된 파일에는 평가 워터마크가 포함됩니다 — 자세한 내용은 [Licensing](/slides/ko/python-java/licensing/)을 참고하세요. 프레젠테이션을 만들고 채우는 다른 방법에 대해서는 [Create Presentations](/slides/ko/python-java/create-presentation/)를 참고하십시오.