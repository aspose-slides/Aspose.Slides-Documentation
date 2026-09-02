---
title: JavaScript에서 PowerPoint 프레젠테이션을 XML로 변환
linktitle: PowerPoint를 XML로
type: docs
weight: 145
url: /ko/nodejs-java/convert-powerpoint-to-xml/
keywords:
- PowerPoint를 XML로 변환
- 프레젠테이션을 XML로 변환
- PPT를 XML로
- PPTX를 XML로
- ODP를 XML로
- PowerPoint XML 프레젠테이션
- SaveFormat.Xml
- 프레젠테이션을 XML로 저장
- 프레젠테이션을 XML로 내보내기
- XML 스트림
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 JavaScript에서 PowerPoint 및 OpenDocument 프레젠테이션을 PowerPoint XML 파일 또는 스트림으로 변환합니다."
---
## **개요**

Aspose.Slides for Node.js via Java은 PowerPoint 프레젠테이션을 PowerPoint XML Presentation 형식으로 변환할 수 있습니다. XML 출력은 프레젠테이션 구조를 텍스트 기반으로 검사하거나, 생성된 문서를 문제 해결하고, 자동화된 테스트에서 출력을 비교하거나, 프레젠테이션 패키지가 아닌 XML을 사용하는 워크플로와 통합해야 할 때 유용합니다.

[Presentation.save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#save) 메서드에 [SaveFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/saveformat/) 열거형의 `Xml` 값을 사용하십시오. 결과를 파일에 직접 쓰거나 스트림에 쓸 수 있습니다.

{{% alert color="info" title="참고" %}}

`SaveFormat.Xml`은 PowerPoint XML Presentation을 생성합니다. PPTX 패키지 내부에 저장된 개별 Office Open XML 파트를 추출하지는 않습니다. `ppt/presentation.xml`와 같은 정확한 PPTX 패키지 파트나 개별 슬라이드 XML 파일이 필요하면 PPTX 패키지를 직접 검사하십시오.

{{% /alert %}}

## **프레젠테이션을 XML 파일로 변환**

[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스로 소스 프레젠테이션을 로드한 다음 출력 경로와 `SaveFormat.Xml`을 [Presentation.save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#save) 메서드에 전달합니다. 소스는 PPT, PPTX, ODP와 같이 로드가 지원되는 모든 프레젠테이션 형식일 수 있습니다.

다음 예제는 PPTX 프레젠테이션을 XML 파일로 변환합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **XML 출력물을 스트림에 기록**

XML을 메모리에 유지하거나 웹 서비스, 스토리지 제공자, XML 처리 파이프라인 등 다른 구성 요소에 전달해야 할 때는 [Presentation.save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#save) 의 스트림 오버로드를 사용하십시오. 다음 예제는 결과를 Java `ByteArrayOutputStream`에 기록하고 생성된 데이터를 Node.js `Buffer`로 복사합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // 워크플로의 다음 구성 요소에 xmlBuffer를 전달합니다.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **XML과 프레젠테이션 및 내보내기 형식 비교**

결과 사용 방식에 따라 출력 형식을 선택하십시오:

| 형식 | 출력 | 일반적인 사용 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | 구조 검사, 문제 해결, 생성된 출력 비교, XML 기반 통합 |
| PPT (`.ppt`) | 레거시 바이너리 프레젠테이션 파일 | 이전 PowerPoint 워크플로와의 호환성 |
| PPTX (`.pptx`) | 여러 파트를 포함하는 Office Open XML 패키지 | 일반 PowerPoint 편집 및 프레젠테이션 교환 |
| PDF 또는 TIFF | 고정 레이아웃 페이지 또는 다중 페이지 이미지 | 보기, 인쇄, 보관 |
| PNG, JPEG 또는 SVG | 개별 슬라이드의 렌더링된 표현 | 썸네일, 미리보기, 이미지 자산 |
| HTML 또는 HTML5 | 웹 지향 프레젠테이션 출력 | 브라우저 보기 및 웹 게시 |

PPT 및 PPTX와 달리 XML 출력은 주로 검사와 데이터 중심 워크플로를 위해 설계되었습니다. PDF, TIFF, HTML 및 슬라이드 이미지 형식과 달리 슬라이드를 페이지나 시각적 자산으로 렌더링하는 것이 아니라 프레젠테이션 데이터를 나타냅니다. [지원되는 파일 형식](/slides/ko/nodejs-java/supported-file-formats/) 표는 PowerPoint XML Presentation을 저장 전용 형식으로 나열하므로, 워크플로가 내보낸 파일을 다시 Aspose.Slides에 로드하여 계속 편집해야 하는 경우에는 사용하지 마십시오.

## **FAQ**

**`SaveFormat.Xml`은 PPTX 파일을 저장하는 것과 동일합니까?**

아니요. PPTX는 여러 Office Open XML 파트를 포함하는 패키지이며, `SaveFormat.Xml`은 PowerPoint XML Presentation 파일을 생성합니다.

**파일을 디스크에 만들지 않고 XML 출력을 저장할 수 있나요?**

예. writable 스트림을 [Presentation.save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#save) 에 전달하십시오. 예를 들어 Java `ByteArrayOutputStream`을 사용하고 해당 데이터를 Node.js `Buffer`에 복사하여 메모리 내에서 처리할 수 있습니다.

**Aspose.Slides가 내보낸 XML 파일을 다시 로드할 수 있나요?**

아니요. PowerPoint XML Presentation은 현재 저장만 지원되며 로드는 지원되지 않습니다. 라운드트립 편집이 필요하면 PPTX 또는 다른 지원되는 프레젠테이션 형식을 사용하십시오.

**XML 변환이 각 슬라이드를 페이지나 이미지로 렌더링합니까?**

아니요. XML 변환은 구조화된 프레젠테이션 데이터를 기록합니다. 페이지 지향 출력이 필요하면 PDF 또는 TIFF를, 개별 슬라이드 이미지가 필요하면 PNG, JPEG, SVG를 사용하십시오.