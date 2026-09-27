---
title: Aspose.Slides for Node.js via .NET
second_title: Aspose.Slides for Node.js
type: docs
weight: 47
url: /ko/nodejs-net/
keywords:
- 문서
- 프레젠테이션 처리
- 프레젠테이션 변환
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "여기에서 시작하십시오: Aspose.Slides for Node.js via .NET을 설치하고 첫 번째 프레젠테이션을 만든 뒤, 일반 작업, 라이선스, API 참조 및 지원에 대한 가이드를 찾으세요."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides for Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET은 Microsoft PowerPoint 또는 Office Automation 없이 Node.js 애플리케이션에서 PowerPoint 및 OpenDocument 프레젠테이션을 만들고, 읽고, 편집하고 변환할 수 있는 라이브러리입니다. 이 라이브러리는 edge-js 브리지를 통해 Aspose.Slides for .NET을 실행하므로 JavaScript API가 .NET API를 그대로 반영하며, 멤버 이름은 camelCase 형식입니다.

PPT, PPTX, PPS, POT 및 ODP 파일을 매크로 사용 가능 및 템플릿 변형을 포함해 로드하고 저장할 수 있으며, PDF, XPS, HTML, TIFF, Markdown 및 이미지 형식으로 내보낼 수 있습니다.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>시작하기</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/ko/nodejs-net/installation/">설치</a></li>
<li><a href="/slides/ko/nodejs-net/create-presentation/">첫 프레젠테이션 만들기</a></li>
<li><a href="/slides/ko/nodejs-net/developer-guide/">개발자 가이드</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/ko/nodejs-net/evaluate-aspose-slides/">시험 제한 사항</a></li>
<li><a href="/slides/ko/nodejs-net/licensing/">라이선스</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides로 빌드</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/ko/nodejs-net/open-presentation/">프레젠테이션 열기 및 저장</a></li>
<li><a href="/slides/ko/nodejs-net/convert-powerpoint-to-pdf/">PDF로 변환</a></li>
<li><a href="/slides/ko/nodejs-net/convert-slide/">슬라이드를 이미지로 렌더링</a></li>
<li><a href="/slides/ko/nodejs-net/manage-text/">텍스트 편집</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>참조 및 지원</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">.NET API 참조</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">릴리스 노트</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">다운로드</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">무료 지원 포럼</a></li>
<li><a href="https://helpdesk.aspose.com/">유료 지원 헬프데스크</a></li>
</ul>
</div>
</div>

------

## **첫 번째 프레젠테이션**

Node.js 22 또는 24와 .NET SDK 8 이상이 필요합니다; Linux에서는 몇 가지 시스템 패키지도 필요합니다. [Installation](/slides/ko/nodejs-net/installation/) 페이지에 필요한 항목과 테스트된 플랫폼이 나열되어 있습니다. 프로젝트를 만들고 npm에 설치할 edge-js 릴리스를 지정하는 오버라이드를 추가한 다음 패키지를 설치합니다:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

머신당 한 번씩 라이브러리가 의존하는 .NET 패키지를 복원합니다. 프로젝트 폴더 안에 `deps` 폴더를 만들고, [Restore the .NET Dependencies](/slides/ko/nodejs-net/installation/#restore-the-net-dependencies)에서 `deps.csproj` 파일을 저장한 뒤 실행합니다:

```sh
dotnet restore deps/deps.csproj
```

이 코드를 프로젝트 폴더에 *hello.js* 라는 이름으로 저장합니다:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// 새 프레젠테이션에는 빈 슬라이드가 하나 포함됩니다.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // 위치와 크기는 포인트(1/72 인치) 단위입니다: x, y, 너비, 높이.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // 프레젠테이션을 지원하는 .NET 객체를 해제합니다.
    presentation.dispose();
}
```

프로젝트 폴더에서 실행합니다:

```sh
node hello.js
```

스크립트는 `Saved hello.pptx`를 출력하고, 텍스트가 들어 있는 사각형이 하나 있는 슬라이드가 포함된 *hello.pptx* 파일을 저장합니다. 라이선스가 없을 경우 저장된 파일에 평가용 워터마크가 표시됩니다 — 자세한 내용은 [Licensing](/slides/ko/nodejs-net/licensing/)를 참고하십시오. 프레젠테이션을 만들고 채우는 다른 방법은 [Create a Presentation](/slides/ko/nodejs-net/create-presentation/)를 확인하세요.