---
title: "Aspose.Slides for Python via .NET"
second_title: "Aspose.Slides for Python"
type: docs
weight: 35
url: /ko/python-net/
is_root: true
keywords:
- "Aspose.Slides for Python"
- "Python용 PowerPoint 자동화"
- "Python PPT 라이브러리"
- "Python에서 PowerPoint를 PDF로 내보내기"
- "Python에서 PowerPoint를 SVG로 내보내기"
- "Python에서 PowerPoint 편집"
- "Microsoft Office 없이 Python PowerPoint"
- "Python으로 PPTX 관리"
- "Python 슬라이드 미리보기"
- "Python으로 슬라이드에 오디오 추가"
- "PowerPoint"
- "OpenDocument"
- "Python"
- "Aspose.Slides"
description: "여기에서 시작하세요: Aspose.Slides for Python via .NET을 설치하고 첫 번째 프레젠테이션을 만든 다음 일반 작업 가이드, API 레퍼런스 및 지원 정보를 찾으세요."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides for Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET은 Microsoft PowerPoint 또는 Microsoft Office 없이 PowerPoint 및 OpenDocument 프레젠테이션을 생성, 읽기, 편집 및 변환할 수 있는 Python 라이브러리입니다.

PPT, PPTX, PPS, POT 및 ODP를 로드하고 저장하며, 매크로가 포함된 버전 및 템플릿 변형을 포함하고, PDF, XPS, HTML, SVG, TIFF, Markdown 및 이미지로 내보낼 수 있습니다.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>시작하기</b></p>
<hr>
<p>시작하기</p>
<ul>
<li><a href="/slides/ko/python-net/installation/">설치</a></li>
<li><a href="/slides/ko/python-net/create-presentation/">첫 번째 프레젠테이션 만들기</a></li>
<li><a href="/slides/ko/python-net/getting-started/">시작 안내서</a></li>
</ul>
<p>평가</p>
<ul>
<li><a href="/slides/ko/python-net/supported-file-formats/">지원되는 파일 형식</a></li>
<li><a href="/slides/ko/python-net/evaluate-aspose-slides/">체험 제한</a></li>
<li><a href="/slides/ko/python-net/licensing/">라이선스</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides로 빌드</b></p>
<hr>
<p>일반 작업</p>
<ul>
<li><a href="/slides/ko/python-net/open-presentation/">프레젠테이션 열기</a></li>
<li><a href="/slides/ko/python-net/save-presentation/">프레젠테이션 저장</a></li>
<li><a href="/slides/ko/python-net/convert-powerpoint-to-pdf/">PDF로 변환</a></li>
<li><a href="/slides/ko/python-net/convert-slide/">슬라이드를 이미지로 렌더링</a></li>
<li><a href="/slides/ko/python-net/manage-text/">텍스트 및 도형 편집</a></li>
</ul>
<p>Slides 워크플로</p>
<ul>
<li><a href="/slides/ko/python-net/powerpoint-charts/">차트</a></li>
<li><a href="/slides/ko/python-net/powerpoint-animation/">애니메이션</a></li>
<li><a href="/slides/ko/python-net/manage-media-files/">오디오 및 비디오</a></li>
<li><a href="/slides/ko/python-net/presentation-design/">슬라이드 디자인</a></li>
<li><a href="/slides/ko/python-net/merge-presentation/">프레젠테이션 병합</a></li>
</ul>
<p>예제</p>
<ul>
<li><a href="/slides/ko/python-net/examples/">슬라이드 요소별 예제</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">GitHub 예제</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>참조 및 지원</b></p>
<hr>
<p>참조</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-net/">API 참조</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/release-notes/">릴리스 노트</a></li>
<li><a href="https://products.aspose.com/slides/python-net/">제품 페이지</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/">다운로드</a></li>
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

PyPI에서 패키지를 설치합니다:

```bash
pip install aspose.slides
```

패키지에는 사용되는 .NET 런타임이 포함되어 있어 .NET을 별도로 설치할 필요가 없습니다. Linux에서는 libgdiplus와 ICU 라이브러리를 추가로 설치하고, Debian 또는 Ubuntu 시스템 Python을 사용할 경우 가상 환경에서 명령을 실행합니다. macOS에는 추가 전제 조건이 있으며, 해당 설치는 확인되지 않았습니다. 명령, macOS 전제 조건 및 지원되는 Python 버전에 대해서는 [설치](/slides/ko/python-net/installation/)을 확인하십시오.

다음 코드를 *hello.py* 파일로 저장하세요:

```py
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.slides[0]

    # CLOUD 유형의 자동 도형을 추가합니다.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

`python hello.py` 명령으로 실행합니다. 스크립트는 현재 폴더에 *new_presentation.pptx* 파일을 저장하며, 클라우드 모양의 슬라이드 하나에 "Hello, Aspose!" 텍스트가 포함됩니다. 라이선스가 없으면 저장된 파일에 평가용 워터마크가 표시됩니다 — [라이선스](/slides/ko/python-net/licensing/). 추가적인 프레젠테이션 생성 및 채우기 방법은 [프레젠테이션 만들기](/slides/ko/python-net/create-presentation/)를 확인하십시오.