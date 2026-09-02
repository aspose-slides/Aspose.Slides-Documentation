---
title: Node.js에서 PPT를 PPTX로 변환
linktitle: PPT를 PPTX로
type: docs
weight: 20
url: /ko/nodejs-java/convert-ppt-to-pptx/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPT를 PPTX로
- PPT를 PPTX로 저장
- PPT를 PPTX로 내보내기
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Node.js에서 레거시 PPT 파일을 PPTX로 변환합니다. 단일 파일 및 배치 변환, 오류 처리, 정밀도 주석에 대한 JavaScript 예제가 포함되어 있습니다."
---
## **개요**

PPT는 레거시 이진 PowerPoint 형식이고 PPTX는 최신 Open XML 형식입니다. Aspose.Slides for Node.js via Java는 Microsoft PowerPoint 없이 PPT 파일을 로드하고 PPTX로 저장할 수 있습니다. 이 문서에서는 파일 하나 또는 파일 디렉터리를 변환하는 방법을 보여주고 변환 후 확인해야 할 사항을 설명합니다.

## **PPT 파일을 PPTX로 변환**

[프레젠테이션]((https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/)) 클래스와 함께 원본 파일을 로드한 다음, [Presentation.save]((https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#save))에 [SaveFormat.Pptx]((https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/saveformat/))를 전달합니다. `finally` 블록은 프레젠테이션을 해제하고 리소스를 해제합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 레거시 PPT 프레젠테이션을 로드합니다.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // 프레젠테이션을 PPTX 형식으로 저장합니다.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

파일 확장자는 자체적으로 출력 형식을 선택하지 않으며, [SaveFormat.Pptx]((https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/saveformat/)) 인수가 이를 결정합니다. 원본 PPT 파일을 유지해야 하는 경우 입력 경로와 출력 경로를 다르게 지정하십시오.

## **여러 PPT 파일 변환**

다음 예제는 하나의 디렉터리에서 모든 `.ppt` 파일을 변환합니다. 각 파일은 독립적으로 처리되므로 하나의 변환 실패가 배치 전체를 중단하지 않습니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

프로덕션 환경에서는 전체 오류를 기록하고, 기존 출력 파일을 덮어쓸지 여부를 결정하며, 실패한 파일 이름을 재시도 또는 검토 큐에 기록하십시오. 손상된 파일, 암호가 필요한 파일을 올바른 암호 없이 열려는 경우, 접근할 수 없는 경로, 지원되지 않는 콘텐츠 등은 변환 실패의 원인이 될 수 있습니다. 암호화된 파일 로드에 대해서는 [Password-Protected Presentations](/nodejs-java/password-protected-presentation/) 를 참고하십시오.

## **정밀도 및 레거시 기능**

변환은 일반적으로 슬라이드, 마스터, 레이아웃, 텍스트, 도형, 이미지, 표 및 차트를 보존합니다. 그러나 PPT와 PPTX는 모든 기능을 정확히 동일한 방식으로 표현하지 않습니다. PPTX에 해당하는 것이 없거나 라이브러리에서 지원되지 않는 레거시 기능은 정규화되거나 생략되거나 다르게 표시될 수 있습니다.

애니메이션, 전환, 내장 또는 연결된 OLE 객체, ActiveX 컨트롤, 내장 미디어, 특수 폰트 또는 VBA 매크로가 포함된 경우 변환된 파일을 반드시 확인하십시오. 일반 PPTX 파일은 매크로가 포함된 형식이 아니므로 VBA가 필요할 때는 매크로 지원 워크플로를 사용하십시오. 또한 변환된 프레젠테이션을 열거나 렌더링할 환경에 필요한 폰트와 외부 리소스가 존재하는지도 확인하십시오.

중요 문서의 경우, 생성된 PPTX를 프로그래밍 방식으로 다시 열어 핵심 슬라이드 수와 내용을 검사하고, 의도한 뷰어에서 외관 및 슬라이드쇼 동작을 비교하십시오. 성공적인 [Presentation.save]((https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#save)) 호출만으로 모든 레거시 기능이 정확히 PPTX로 변환되었다고 판단하지 마십시오.

## **PPTX 사용 시기**

프레젠테이션을 최신 PowerPoint 버전에서 편집하거나 Open XML 패키지를 사용하는 시스템과 교환하거나, 레거시 이진 PPT보다 검사 및 복구가 쉬운 형식으로 저장하려는 경우 PPTX를 사용하십시오. 변환된 프레젠테이션이 정밀도 검사를 통과할 때까지 원본 PPT를 보관하거나 롤백 사본으로 유지하십시오.

PDF, HTML, 이미지, XPS 또는 다른 출력 형식이 필요하면 [Convert Presentations to Multiple Formats](/nodejs-java/convert-presentation/) 에서 형식별 가이드를 참고하고, 모든 대상이 편집 가능한 PowerPoint 기능을 보존한다고 가정하지 마십시오.

## **온라인 변환기**

가끔 파일을 변환하거나 빠르게 비교하려면 [online PPT to PPTX converter]((https://products.aspose.app/slides/ko/conversion/ppt-to-pptx)) 를 사용할 수 있습니다. 반복적인 변환, 배치 처리 또는 애플리케이션 수준 오류 처리가 필요하면 Node.js via Java API를 사용하십시오.

## **관련 문서**

- [PPT vs PPTX](/nodejs-java/ppt-vs-pptx/)
- [Save Presentations in Node.js](/nodejs-java/save-presentation/)
- [Supported File Formats](/nodejs-java/supported-file-formats/)
- [Open Presentations in Node.js](/nodejs-java/open-presentation/)

## **FAQ**

**Microsoft PowerPoint 없이 PPT를 PPTX로 변환할 수 있나요?**

예. Aspose.Slides for Node.js via Java는 Microsoft PowerPoint 없이 프레젠테이션 파일을 로드하고 저장합니다.

**PPT를 PPTX로 변환하면 모든 콘텐츠가 정확히 보존되나요?**

일반적인 프레젠테이션 콘텐츠는 보존되지만, 모든 레거시 또는 지원되지 않는 기능이 정확히 동일하게 변환된다고 보장할 수 없습니다. 매크로, OLE 또는 ActiveX 객체, 미디어, 특수 애니메이션 또는 특수 폰트가 포함된 경우 생성된 파일을 검토하십시오.

**암호가 보호된 PPT 파일을 변환할 수 있나요?**

예, 파일을 로드할 때 올바른 암호를 제공하면 가능합니다. 암호가 없거나 잘못된 경우 로드 작업이 실패합니다.

**변환 후 PPT 파일을 삭제해야 하나요?**

원본 PPT를 검증된 PPTX와 사용 중인 뷰어 및 워크플로에서 확인할 때까지 보관하십시오. 레거시 기능이 다르게 변환될 경우 롤백 사본으로 활용할 수 있습니다.