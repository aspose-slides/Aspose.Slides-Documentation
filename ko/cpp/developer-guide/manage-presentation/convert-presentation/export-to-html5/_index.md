---
title: C++에서 프레젠테이션을 HTML5로 변환
linktitle: 프레젠테이션을 HTML5로
type: docs
weight: 40
url: /ko/cpp/export-to-html5/
keywords:
- PowerPoint를 HTML5로
- OpenDocument를 HTML5로
- 프레젠테이션을 HTML5로
- 슬라이드를 HTML5로
- PPT를 HTML5로
- PPTX를 HTML5로
- ODP를 HTML5로
- PPT를 HTML5로 저장
- PPTX를 HTML5로 저장
- ODP를 HTML5로 저장
- PPT를 HTML5로 내보내기
- PPTX를 HTML5로 내보내기
- ODP를 HTML5로 내보내기
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 반응형 HTML5로 내보냅니다. 서식, 애니메이션 및 인터랙티브 기능을 보존합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션을 HTML5로 변환하는 방법을 설명합니다. 기본 내보내기, 도형 애니메이션 및 슬라이드 전환 제어, 댓글 레이아웃을 다룹니다. 또한 HTML5 출력과 표준 HTML 내보내기의 SVG 기반 출력을 비교합니다.

## **PowerPoint를 HTML5로 내보내기**

다음 예제는 작업 디렉터리에서 프레젠테이션을 로드하고 HTML5 형식으로 저장합니다. 기본 내보내기 설정을 사용합니다; 다음 예제에서는 애니메이션 재생을 명시적으로 제어하는 방법을 보여줍니다. 입력 경로를 프레젠테이션 경로로 바꾸십시오.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html5);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
HTML 문서 외에도 내보내기는 슬라이드 스타일링, 애니메이션, 효과 및 탐색을 위한 지원 CSS 및 JavaScript 파일을 작성합니다. 출력물을 이동하거나 게시할 때 이 파일들을 HTML 문서와 함께 유지하십시오. 생성된 페이지는 또한 공개 CDN에서 jQuery 및 Anime.js를 로드합니다; 이들 없이는 슬라이드 탐색 및 애니메이션이 작동하지 않습니다.
{{% /alert %}}

도형 애니메이션이나 슬라이드 전환을 재생하지 않고 내보내려면 `false`를 [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) 및 [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/)에 전달하십시오. 이는 [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/)에서 설정합니다. 이러한 설정은 독립적이므로 하나는 활성화하고 다른 하나는 비활성화할 수 있습니다. 예제는 생성된 페이지에서 두 종류의 애니메이션을 모두 비활성화한 채 프레젠테이션을 내보냅니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(false);
html5Options->set_AnimateTransitions(false);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **PowerPoint를 HTML로 내보내기**

표준 HTML 내보내기는 다른 렌더링 방식을 사용합니다: 슬라이드 콘텐츠가 HTML 페이지 내부의 SVG로 표현됩니다. 다음 예제는 이 렌더링 방식을 사용하여 프레젠테이션을 HTML 문서로 변환합니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html);
presentation->Dispose();
```

아래의 간소화된 마크업은 생성된 페이지의 구조를 보여줍니다. SVG 요소는 렌더링된 슬라이드 콘텐츠를 포함하고; 자리 표시자 텍스트는 해당 콘텐츠를 나타내며 실제 내보내기 출력은 아닙니다.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
SVG 기반 내보내기는 PowerPoint 도형을 개별 HTML 요소로 노출하지 않습니다. 이 문서에서 설명한 도형 애니메이션 및 슬라이드 전환 옵션이 필요할 경우 HTML5 내보내기를 사용하십시오.
{{% /alert %}}

## **PowerPoint를 HTML5 슬라이드 뷰로 내보내기**

HTML5 내보내기는 브라우저에서 프레젠테이션 슬라이드를 보기 및 탐색할 수 있는 페이지를 생성합니다. 이 예제는 [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) 및 [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/)에 `true`를 전달하여 내보낸 슬라이드 뷰가 원본 프레젠테이션의 효과를 재생하도록 합니다.

이미 도형 애니메이션과 슬라이드 전환이 포함된 프레젠테이션을 사용하여 이러한 설정의 효과를 확인하십시오. 이를 활성화해도 효과가 없는 슬라이드에 새로운 효과가 추가되지는 않습니다. 내보낸 후, 지원 파일이 모두 있는 상태에서 브라우저에서 생성된 HTML5 문서를 엽니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **프레젠테이션을 댓글이 포함된 HTML5 문서로 변환하기**

기존 슬라이드 댓글을 HTML5 출력에 포함시켜 독자가 슬라이드 콘텐츠와 함께 피드백을 볼 수 있게 할 수 있습니다. 이 섹션의 예제는 아래와 같이 원본 프레젠테이션에 댓글이 포함되어 있기를 기대합니다. 해당 댓글을 내보내며, 새로운 댓글을 만들지는 않습니다.

![프레젠테이션 슬라이드의 두 개 댓글](two_comments_pptx.png)

프레젠테이션 슬라이드에 댓글을 오른쪽에 배치하려면 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) 객체를 [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/)의 [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) 메서드에 전달하십시오. 그런 다음 [CommentsPositions](https://reference.aspose.com/slides/cpp/aspose.slides.export/commentspositions/) 열거형의 `CommentsPositions::Right`를 사용하여 [set_CommentsPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_commentsposition/)를 호출합니다.

다음 예제는 이 댓글 레이아웃을 적용하여 프레젠테이션을 HTML5로 내보냅니다. 댓글이 없는 프레젠테이션은 표시할 댓글 텍스트가 없습니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/CommentsPositions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutOptions);

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

![출력된 HTML5 문서의 댓글](two_comments_html5.png)

## **내보내기 중 JavaScript 하이퍼링크 제외**

`hyperlinks.pptx`에 `javascript:alert('Hello')` 대상과 일반 `https://example.com/` 링크가 포함된 텍스트가 있다고 가정합니다. 내보내기 중 JavaScript 하이퍼링크를 제외하려면 [SaveOptions::set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/)에 `true`를 전달하십시오. 기본값은 `false`이며, 옵션을 활성화하지 않는 한 이러한 링크는 필터링되지 않습니다.

다음 예제는 작업 디렉터리에서 프레젠테이션을 로드하고 [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/)를 사용하여 내보냅니다:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SkipJavaScriptLinks(true);

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");
presentation->Save(u"filtered-html5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

내보낸 파일은 JavaScript 하이퍼링크를 제외하고 텍스트와 일반 HTTPS 링크는 그대로 유지합니다. 원본 프레젠테이션은 변경되지 않습니다.

이 옵션은 JavaScript 하이퍼링크만 필터링하며, 모든 스크립트나 기타 활성 콘텐츠를 제거하지 않으며, CSP 준수를 보장하지도 않습니다. 예를 들어, HTML5 출력에는 여전히 슬라이드 탐색 및 애니메이션을 위한 스크립트가 포함됩니다.

## **FAQ**

**HTML5에서 객체 애니메이션 및 슬라이드 전환이 재생되는지를 제어할 수 있습니까?**

예, HTML5 내보내기는 [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) 및 [slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/)을 개별적으로 활성화하거나 비활성화할 수 있는 옵션을 제공합니다.

**댓글이 지원되며, 슬라이드에 대해 어느 위치에 배치할 수 있습니까?**

예, 기존 댓글을 HTML5 출력에 포함시킬 수 있으며, (예를 들어 슬라이드 오른쪽에) [layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/)을 통해 배치할 수 있습니다.

**보안 또는 CSP 이유로 JavaScript를 호출하는 링크를 건너뛸 수 있습니까?**

예, [set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) 메서드를 사용하면 저장 시 JavaScript 호출이 포함된 하이퍼링크를 건너뛸 수 있습니다. 기본값은 `false`입니다. HTML5 내보내기 예제와 필터 범위에 대해서는 [내보내기 중 JavaScript 하이퍼링크 제외](/slides/ko/cpp/export-to-html5/#exclude-javascript-hyperlinks-during-export)를 참조하십시오. 이 설정은 탐색 및 애니메이션을 위한 HTML5 뷰어에서 사용되는 JavaScript를 제거하지 않습니다.