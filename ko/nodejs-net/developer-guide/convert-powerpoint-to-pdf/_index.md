---
title: Node.js를 통한 .NET에서 PowerPoint를 PDF로 변환
linktitle: PowerPoint를 PDF로
type: docs
weight: 30
url: /ko/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint를 PDF로
- PowerPoint를 PDF로 변환
- PPTX를 PDF로
- PPT를 PDF로
- ODP를 PDF로
- 프레젠테이션을 PDF로 저장
- PDF/A
- PdfOptions
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via .NET를 사용하여 JavaScript에서 PPTX, PPT 및 ODP 프레젠테이션을 PDF로 변환하고, PdfOptions를 사용해 보관용 PDF/A 파일을 생성합니다."
---
## **개요**

Aspose.Slides for Node.js via .NET은 Microsoft PowerPoint 없이 PowerPoint 및 OpenDocument 프레젠테이션을 PDF로 변환합니다. 각 보이는 슬라이드는 슬라이드와 동일한 크기의 PDF 페이지가 되며, 텍스트는 선택 가능하고 검색 가능합니다. 이 문서는 기본 변환과 [PdfOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/)를 사용한 PDF/A 변환을 보여줍니다.

예제는 [Installation](/slides/ko/nodejs-net/installation/)에서 설정한 프로젝트 폴더에 `sample.pptx`라는 프레젠테이션이 있음을 전제로 합니다. 모든 PowerPoint 프레젠테이션이 사용 가능합니다. 각 예제를 프로젝트 폴더에 `.js` 파일로 저장하고 해당 폴더에서 `node`로 실행하십시오.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET은 자체 API 참조가 없습니다. camelCase 이름을 사용하여 Aspose.Slides for .NET API를 그대로 반영하므로 이 문서의 API 링크는 [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/ko/net/)의 해당 클래스와 멤버로 연결됩니다.
{{% /alert %}}

## **프레젠테이션을 PDF로 변환**

프레젠테이션을 PDF로 변환하려면 다음 단계를 따르십시오:

1. 프레젠테이션 경로를 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/presentation/) 생성자에 전달하여 엽니다. 동일한 코드는 PPTX, PPT 및 ODP 파일에서 작동합니다.
2. [save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/) 메서드를 출력 경로와 `SaveFormat.Pdf`와 함께 호출합니다.
3. `finally` 블록에서 `dispose`를 호출하여 프레젠테이션을 지원하는 .NET 리소스를 해제합니다.

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

스크립트는 `sample.pdf`를 프로젝트 폴더에 씁니다. 변환은 기본 설정을 사용합니다: 숨겨지지 않은 모든 슬라이드가 슬라이드 순서대로 페이지가 됩니다. 라이선스가 없으면 각 페이지에 평가 워터마크가 표시됩니다; 자세한 내용은 [Licensing](/slides/ko/nodejs-net/licensing/)를 참조하십시오.

## **프레젠테이션을 PDF/A로 변환**

출력을 제어하려면 `save`의 세 번째 인수로 [PdfOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/) 객체를 전달합니다. 다음 예제는 [compliance](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/compliance/) 속성을 `PdfCompliance.PdfA2b`로 설정하여 PDF/A-2b 파일을 생성합니다. PDF/A는 장기 보관을 위한 ISO 표준이며, 다른 규칙 중 하나로 문서에서 사용하는 모든 글꼴을 파일에 포함시켜야 합니다.

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

스크립트는 기본 변환과 동일한 페이지를 가진 `sample-pdfa.pdf`를 씁니다. 파일이 표준을 충족하는지 확인하려면 [veraPDF](https://verapdf.org/)와 같은 PDF/A 검증기로 검사하십시오. 다른 [PdfCompliance](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfcompliance/) 값은 `PdfA1b`, `PdfA2a` 또는 접근성을 위한 `PdfUa`와 같은 다른 표준을 선택합니다.

## **FAQ**

**PDF에 숨겨진 슬라이드를 포함하려면 어떻게 해야 하나요?**

숨겨진 슬라이드는 기본적으로 제외됩니다. `PdfOptions`의 [showHiddenSlides](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/showhiddenslides/) 속성을 `true`로 설정하고 옵션을 `save`에 전달하십시오.

**PDF에 비밀번호를 설정하여 보호할 수 있나요?**

예. `save`를 호출하기 전에 `PdfOptions`의 [password](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/password/) 속성을 설정하십시오. 그러면 PDF 리더가 파일을 열기 전에 해당 비밀번호를 요구합니다.

**일부 슬라이드만 변환할 수 있나요?**

예. `save`의 네 번째 인수로 슬라이드 위치 배열을 전달합니다. 위치는 1부터 시작하며 옵션이 필요 없으면 세 번째 인수를 `null`로 지정할 수 있습니다: `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])`는 첫 번째와 세 번째 슬라이드만 포함한 PDF를 생성합니다.

**Linux에서 변환할 때 텍스트 모양이 왜 다르게 보이나요?**

Aspose.Slides는 변환을 수행하는 머신에 설치된 글꼴만 사용할 수 있습니다. 프레젠테이션에 Calibri와 같이 해당 머신에 없는 글꼴이 사용된 경우, Aspose.Slides는 설치된 다른 글꼴을 대신 사용하여 텍스트 모양과 줄 바꿈 위치가 달라질 수 있습니다. Windows와 동일한 결과를 얻으려면 프레젠테이션에서 사용하는 글꼴을 설치하십시오.

**파일 대신 Buffer 형태로 PDF를 받을 수 있나요?**

예. `presentation.saveToBuffer(SaveFormat.Pdf)`는 PDF를 Node.js `Buffer`로 반환합니다. 이는 HTTP 응답으로 결과를 전송할 때 편리합니다. 또한 두 번째 인수로 `PdfOptions`를 받아들입니다.