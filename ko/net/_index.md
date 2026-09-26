---
title: "Aspose.Slides for .NET"
second_title: "Aspose.Slides for .NET"
type: docs
weight: 10
url: /ko/net/
keywords:
- 문서
- 프레젠테이션 처리
- 프레젠테이션 변환
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "여기서 시작하세요: Aspose.Slides for .NET을 설치하고 첫 프레젠테이션을 만든 다음 일반 작업 가이드, API 참조 및 지원 정보를 찾으세요."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET은 Microsoft PowerPoint 또는 Office 자동화 없이 .NET 애플리케이션에서 PowerPoint 및 OpenDocument 프레젠테이션을 만들고, 읽고, 편집하고, 변환할 수 있는 클래스 라이브러리입니다.

매크로 지원 및 템플릿 변형을 포함한 PPT, PPTX, PPS, POT, ODP 파일을 로드하고 저장하며, PDF, XPS, HTML, SVG, TIFF, Markdown 및 이미지로 내보낼 수 있습니다.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>시작하기</b></p>
<hr>
<p>시작하기</p>
<ul>
<li><a href="/slides/ko/net/installation/">설치</a></li>
<li><a href="/slides/ko/net/create-presentation/">첫 프레젠테이션 만들기</a></li>
<li><a href="/slides/ko/net/getting-started/">시작 가이드</a></li>
</ul>
<p>평가</p>
<ul>
<li><a href="/slides/ko/net/supported-file-formats/">지원되는 파일 형식</a></li>
<li><a href="/slides/ko/net/evaluate-aspose-slides/">평가판 제한 사항</a></li>
<li><a href="/slides/ko/net/licensing/">라이선스</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides로 빌드</b></p>
<hr>
<p>일반 작업</p>
<ul>
<li><a href="/slides/ko/net/open-presentation/">프레젠테이션 열기</a></li>
<li><a href="/slides/ko/net/save-presentation/">프레젠테이션 저장</a></li>
<li><a href="/slides/ko/net/convert-powerpoint-to-pdf/">PDF로 변환</a></li>
<li><a href="/slides/ko/net/convert-slide/">슬라이드를 이미지로 렌더링</a></li>
<li><a href="/slides/ko/net/manage-text/">텍스트 및 도형 편집</a></li>
</ul>
<p>Slides 워크플로</p>
<ul>
<li><a href="/slides/ko/net/powerpoint-charts/">차트</a></li>
<li><a href="/slides/ko/net/powerpoint-animation/">애니메이션</a></li>
<li><a href="/slides/ko/net/manage-media-files/">오디오 및 비디오</a></li>
<li><a href="/slides/ko/net/presentation-design/">슬라이드 디자인</a></li>
<li><a href="/slides/ko/net/merge-presentation/">프레젠테이션 병합</a></li>
</ul>
<p>예제</p>
<ul>
<li><a href="/slides/ko/net/examples/">슬라이드 요소별 예제</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">GitHub 예제</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>참조 및 지원</b></p>
<hr>
<p>참조</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">API 참조</a></li>
<li><a href="https://releases.aspose.com/slides/net/release-notes/">릴리스 노트</a></li>
<li><a href="/slides/ko/net/known-issues/">알려진 문제</a></li>
<li><a href="https://releases.aspose.com/slides/net/">다운로드</a></li>
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

.NET SDK 6 이상을 사용하여 콘솔 애플리케이션을 생성합니다:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

그런 다음 플랫폼에 맞는 패키지를 하나 추가합니다:

- Windows에서: `dotnet add package Aspose.Slides.NET`
- Linux 및 macOS에서: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — Linux 전제 조건 및 Aspose.Slides.NET이 필요한 시스템에 대한 자세한 내용은 [설치](/slides/ko/net/installation/)을 참조하십시오.

*Program.cs*의 내용을 이 코드로 교체하고 `dotnet run`을 실행합니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

이 프로그램은 텍스트 상자가 포함된 슬라이드 하나를 가진 *hello.pptx* 파일을 저장합니다. 라이선스가 없으면 저장된 파일에 평가 워터마크가 표시됩니다 — [라이선스](/slides/ko/net/licensing/)를 참조하십시오. 프레젠테이션을 만들고 채우는 다양한 방법은 [프레젠테이션 만들기](/slides/ko/net/create-presentation/)를 확인하세요.