---
title: Aspose.Slides for C++
second_title: Aspose.Slides for C++
type: docs
weight: 30
url: /ko/cpp/
keywords:
- 문서
- 프레젠테이션 처리
- 프레젠테이션 변환
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "여기에서 시작하십시오: Aspose.Slides for C++를 설치하고 첫 번째 프레젠테이션을 만든 다음 일반 작업, API 참조 및 지원에 대한 가이드를 찾으십시오."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++은 Microsoft PowerPoint 또는 Office Automation 없이 PowerPoint 및 OpenDocument 프레젠테이션을 만들고, 읽고, 편집하고 변환할 수 있는 네이티브 C++ 라이브러리입니다.

매크로 사용 및 템플릿 변형을 포함한 PPT, PPTX, PPS, POT 및 ODP를 로드하고 저장하며, PDF, XPS, HTML, SVG, TIFF, Markdown 및 이미지로 내보낼 수 있습니다.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>시작하기</b></p>
<hr>
<p>시작하기</p>
<ul>
<li><a href="/slides/ko/cpp/installation/">설치</a></li>
<li><a href="/slides/ko/cpp/create-presentation/">첫 프레젠테이션 만들기</a></li>
<li><a href="/slides/ko/cpp/getting-started/">시작 가이드</a></li>
</ul>
<p>평가</p>
<ul>
<li><a href="/slides/ko/cpp/supported-file-formats/">지원되는 파일 형식</a></li>
<li><a href="/slides/ko/cpp/evaluate-aspose-slides/">체험판 제한 사항</a></li>
<li><a href="/slides/ko/cpp/licensing/">라이선스</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides 로 빌드</b></p>
<hr>
<p>일반 작업</p>
<ul>
<li><a href="/slides/ko/cpp/open-presentation/">프레젠테이션 열기</a></li>
<li><a href="/slides/ko/cpp/save-presentation/">프레젠테이션 저장</a></li>
<li><a href="/slides/ko/cpp/convert-powerpoint-to-pdf/">PDF로 변환</a></li>
<li><a href="/slides/ko/cpp/convert-slide/">슬라이드를 이미지로 렌더링</a></li>
<li><a href="/slides/ko/cpp/manage-text/">텍스트 및 도형 편집</a></li>
</ul>
<p>Slides 워크플로우</p>
<ul>
<li><a href="/slides/ko/cpp/powerpoint-charts/">차트</a></li>
<li><a href="/slides/ko/cpp/powerpoint-animation/">애니메이션</a></li>
<li><a href="/slides/ko/cpp/manage-media-files/">오디오 및 비디오</a></li>
<li><a href="/slides/ko/cpp/presentation-design/">슬라이드 디자인</a></li>
<li><a href="/slides/ko/cpp/merge-presentation/">프레젠테이션 병합</a></li>
</ul>
<p>예제</p>
<ul>
<li><a href="/slides/ko/cpp/examples/">슬라이드 요소별 예제</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">GitHub 예제</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>참조 및 지원</b></p>
<hr>
<p>참조</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cpp/">API 레퍼런스</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/release-notes/">릴리스 노트</a></li>
<li><a href="/slides/ko/cpp/known-issues/">알려진 문제</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/">다운로드</a></li>
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

Windows에서 Visual Studio로 C++ **Console App** 프로젝트를 만든 다음 패키지 관리자 콘솔(**Tools** > **NuGet Package Manager** > **Package Manager Console**)에서 NuGet 패키지를 설치합니다:

```powershell
Install-Package Aspose.Slides.Cpp
```

Linux에서는 Linux ZIP 패키지를 다운로드하고 [Installation](/slides/ko/cpp/installation/#linux)에서 설명하는 CMake 프로젝트를 설정합니다.

그런 다음 이 코드를 프로그램의 메인 소스 파일로 사용합니다. 하나의 텍스트 상자가 있는 프레젠테이션을 생성하고 저장합니다:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

Windows에서 실행하려면 도구 모음에서 **x64** 플랫폼을 선택하고 **Ctrl+F5**를 누릅니다. Linux에서는 프로젝트 폴더에 *main.cpp* 로 저장한 뒤 빌드하고 실행합니다:

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

프로그램은 텍스트 상자를 포함한 하나의 슬라이드를 가진 *hello.pptx* 파일을 저장합니다. 라이선스가 없으면 저장된 파일에 평가용 워터마크가 표시됩니다 — [Licensing](/slides/ko/cpp/licensing/)을 확인하십시오. 프레젠테이션을 만들고 채우는 다른 방법은 [Create Presentations](/slides/ko/cpp/create-presentation/)를 참조하세요.