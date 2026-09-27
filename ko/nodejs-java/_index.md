---
title: "Aspose.Slides for Node.js via Java"
second_title: "Aspose.Slides for Node.js"
type: docs
weight: 47
url: /ko/nodejs-java/
keywords:
  - 문서
  - 프레젠테이션 처리
  - 프레젠테이션 변환
  - PowerPoint
  - OpenDocument
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "시작하기: Aspose.Slides for Node.js via Java를 설치하고 첫 프레젠테이션을 만든 후 일반 작업, API 참조 및 지원을 위한 가이드를 확인하십시오."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides for Node.js via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via Java은 Microsoft PowerPoint 없이 Node.js 애플리케이션에서 PowerPoint 및 OpenDocument 프레젠테이션을 생성, 읽기, 편집 및 변환할 수 있는 라이브러리입니다.

매크로 사용 및 템플릿 변형을 포함한 PPT, PPTX, PPS, POT 및 ODP 파일을 로드하고 저장하며, PDF, XPS, HTML, SVG, TIFF, Markdown 및 이미지 형식으로 내보낼 수 있습니다.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>시작하기</b></p>
<hr>
<p>시작하기</p>
<ul>
<li><a href="/slides/ko/nodejs-java/installation/">설치</a></li>
<li><a href="/slides/ko/nodejs-java/create-presentation/">첫 프레젠테이션 만들기</a></li>
<li><a href="/slides/ko/nodejs-java/getting-started/">시작 가이드</a></li>
</ul>
<p>평가</p>
<ul>
<li><a href="/slides/ko/nodejs-java/supported-file-formats/">지원 파일 형식</a></li>
<li><a href="/slides/ko/nodejs-java/evaluate-aspose-slides/">평가판 제한사항</a></li>
<li><a href="/slides/ko/nodejs-java/licensing/">라이선스</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides로 빌드</b></p>
<hr>
<p>일반 작업</p>
<ul>
<li><a href="/slides/ko/nodejs-java/open-presentation/">프레젠테이션 열기</a></li>
<li><a href="/slides/ko/nodejs-java/save-presentation/">프레젠테이션 저장</a></li>
<li><a href="/slides/ko/nodejs-java/convert-powerpoint-to-pdf/">PDF로 변환</a></li>
<li><a href="/slides/ko/nodejs-java/convert-slide/">슬라이드를 이미지로 렌더링</a></li>
<li><a href="/slides/ko/nodejs-java/manage-text/">텍스트 및 도형 편집</a></li>
</ul>
<p>Slides 워크플로</p>
<ul>
<li><a href="/slides/ko/nodejs-java/powerpoint-charts/">차트</a></li>
<li><a href="/slides/ko/nodejs-java/powerpoint-animation/">애니메이션</a></li>
<li><a href="/slides/ko/nodejs-java/manage-media-files/">오디오 및 비디오</a></li>
<li><a href="/slides/ko/nodejs-java/presentation-design/">슬라이드 디자인</a></li>
<li><a href="/slides/ko/nodejs-java/merge-presentation/">프레젠테이션 병합</a></li>
</ul>
<p>예제</p>
<ul>
<li><a href="/slides/ko/nodejs-java/examples/">슬라이드 요소별 예제</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>참조 &amp; 지원</b></p>
<hr>
<p>참조</p>
<ul>
<li><a href="https://reference.aspose.com/slides/ko/nodejs-java/">API 참조</a></li>
<li><a href="https://releases.aspose.com/slides/ko/nodejs-java/release-notes/">릴리스 노트</a></li>
<li><a href="/slides/ko/nodejs-java/known-issues/">알려진 문제</a></li>
<li><a href="https://releases.aspose.com/slides/ko/nodejs-java/">다운로드</a></li>
</ul>
<p>지원</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/ko/11">무료 지원 포럼</a></li>
<li><a href="https://helpdesk.aspose.com/">유료 지원 헬프데스크</a></li>
</ul>
</div>
</div>

------

## **첫 번째 프레젠테이션**

Node.js 20 이상 외에 이 패키지는 Java Development Kit(JDK), Python 및 C++ 빌드 툴체인이 필요합니다. npm이 설치 중에 `java` 브리지를 컴파일하기 때문입니다. 각 운영 체제별 단계는 [Installation](/slides/ko/nodejs-java/installation/)을 참고하세요. 그런 다음 프로젝트를 생성하고 npm에서 패키지를 설치합니다:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

프로젝트 폴더에 이 코드를 *hello.js* 파일로 저장하십시오:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides는 Node.js를 계속 실행하도록 유지하는 Java 가상 머신에서 동작하므로 프로세스를 명시적으로 종료합니다.
process.exit(0);
```

`node hello.js`로 실행합니다. 스크립트는 텍스트 상자를 포함한 한 슬라이드를 갖는 *hello.pptx* 파일을 저장합니다. 라이선스가 없으면 저장된 파일에 평가용 워터마크가 표시됩니다 — [Licensing](/slides/ko/nodejs-java/licensing/)를 확인하세요. 프레젠테이션을 만들고 채우는 다른 방법에 대해서는 [Create Presentations](/slides/ko/nodejs-java/create-presentation/)를 참고하십시오.