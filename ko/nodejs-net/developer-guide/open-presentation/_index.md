---
title: .NET을 통한 Node.js에서 프레젠테이션 열기
linktitle: 프레젠테이션 열기
type: docs
weight: 20
url: /ko/nodejs-net/open-presentation/
keywords:
- 프레젠테이션 열기
- PowerPoint 열기
- PPTX 열기
- PPT 열기
- ODP 열기
- 프레젠테이션 로드
- 버퍼에서 프레젠테이션
- 슬라이드 수
- 프레젠테이션 변환
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: ".NET을 통한 Node.js용 Aspose.Slides로 JavaScript에서 PPTX, PPT 및 ODP 프레젠테이션을 엽니다: 파일 경로나 Buffer에서 로드하고, 슬라이드 수를 읽으며, 다른 형식으로 저장합니다."
---
## **개요**

Aspose.Slides for Node.js via .NET는 파일 경로나 Node.js `Buffer`에서 PPTX, PPT 및 ODP와 같은 PowerPoint 및 OpenDocument 프레젠테이션을 엽니다. 이 문서에서는 두 가지 방법을 모두 보여주며, 슬라이드 수를 읽고 열려 있는 프레젠테이션을 다른 형식으로 저장합니다.

예제에서는 [Installation](/slides/ko/nodejs-net/installation/)에서 설정한 프로젝트 폴더에 `sample.pptx`라는 프레젠테이션이 있다고 가정합니다. 어떤 PowerPoint 프레젠테이션이라도 사용할 수 있습니다. 각 예제를 프로젝트 폴더에 `.js` 파일로 저장하고 해당 폴더에서 `node`로 실행하세요.

{{% alert color="info" title="참고" %}}
Aspose.Slides for Node.js via .NET에는 자체 API 참조가 없습니다. camelCase 이름을 사용하는 Aspose.Slides for .NET API를 그대로 반영하므로, 이 문서의 API 링크는 [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/ko/net/)에 있는 해당 클래스와 멤버로 연결됩니다.
{{% /alert %}}

## **파일에서 프레젠테이션 열기**

프레젠테이션을 열려면 해당 경로를 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/presentation/) 생성자에 전달합니다. Aspose.Slides는 확장자가 아니라 파일 내용으로 형식을 감지하므로, 동일한 코드로 PPTX, PPT, ODP 파일을 모두 열 수 있습니다. 상대 경로는 현재 작업 디렉터리를 기준으로 해석되며, 스크립트를 해당 폴더에서 실행할 경우 프로젝트 폴더가 작업 디렉터리가 됩니다.

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

스크립트는 예를 들어 `Slide count: 9`와 같이 `sample.pptx`의 슬라이드 수를 출력합니다. [slides](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/slides/ko/) 컬렉션의 `count` 속성에는 숨겨진 슬라이드도 포함됩니다. 아래와 같이 `finally` 블록에서 `dispose`를 호출하면 코드가 실패하더라도 프레젠테이션 뒤에 있는 .NET 리소스가 해제됩니다.

## **버퍼에서 프레젠테이션 열기**

프레젠테이션이 데이터베이스, HTTP 업로드 또는 파일 경로가 아닌 바이트 스트림 형태로 제공될 경우, 첫 번째 인수에 `null`을, 두 번째 인수에 Node.js `Buffer`를 전달합니다. 다음 예제는 `sample.pptx`를 버퍼에 읽어 이러한 소스를 흉내냅니다.

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

스크립트는 앞 예제와 동일한 슬라이드 수를 출력합니다. 두 번째 인수는 반드시 `Buffer`여야 합니다. `Uint8Array`와 같은 다른 유형을 전달하면 오류가 발생하지 않고 빈 슬라이드 하나가 포함된 새로운 프레젠테이션이 생성됩니다. 다른 바이너리 유형은 먼저 `Buffer.from`으로 변환하세요.

## **다른 형식으로 프레젠테이션 저장**

프레젠테이션을 다른 형식으로 변환하려면 열고 다른 [SaveFormat](https://reference.aspose.com/slides/ko/net/aspose.slides.export/saveformat/) 값을 지정해 저장합니다. 아래 예제는 Aspose.Slides가 감지한 형식을 출력하고, `sourceFormat` 속성이 반환하는 값을 표시한 뒤, 프레젠테이션을 OpenDocument 형식으로 저장합니다.

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

스크립트는 `Source format: Pptx`를 출력하고 `sample.odp`를 작성합니다. `sourceFormat`은 `Ppt`, `Pptx` 또는 `Odp`를 반환합니다. PDF나 이미지로 저장하려면 [Convert PowerPoint to PDF](/slides/ko/nodejs-net/convert-powerpoint-to-pdf/)와 [Convert Slides to Images](/slides/ko/nodejs-net/convert-slide/)를 참조하세요.

## **FAQ**

**비밀번호로 보호된 프레젠테이션을 어떻게 열 수 있나요?**

[LoadOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/) 객체를 만든 뒤, 그 object's [password](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/password/) 속성을 설정하고, 이를 세 번째 생성자 인수로 전달합니다: `new Presentation("protected.pptx", null, loadOptions)`. 올바른 비밀번호가 없으면 생성자가 오류를 발생시킵니다.

**생성자가 빈 메시지와 함께 `Error`를 발생시키는 이유는 무엇인가요?**

.NET에서 `Presentation` 생성자가 실패하면(예: 파일이 없거나 프레젠테이션이 아니거나 다른 비밀번호가 필요할 때) JavaScript에서는 메시지가 비어 있는 `Error`가 전달됩니다. 파일을 열기 전에 `fs.existsSync` 등으로 작업 디렉터리 기준에 파일이 존재하는지 확인하십시오.

**열 수 있는 형식은 무엇인가요?**

PPT, PPTX, PPS, POT, POTX, PPTM, ODP, OTP, FODP 등 PowerPoint 및 OpenDocument 프레젠테이션 형식을 지원합니다.