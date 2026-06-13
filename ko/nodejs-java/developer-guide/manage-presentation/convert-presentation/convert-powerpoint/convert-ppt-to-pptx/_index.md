---
title: JavaScript에서 PPT를 PPTX로 변환
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
description: "Aspose.Slides for Node.js를 사용하여 레거시 PPT 프레젠테이션을 최신 PPTX로 빠르게 변환 — 명확한 튜토리얼, 무료 코드 샘플, Microsoft Office 의존성 없음."
---
## **개요**

이 문서는 JavaScript와 온라인 PPT에서 PPTX 변환 앱을 사용하여 PPT 형식의 PowerPoint 프레젠테이션을 PPTX 형식으로 변환하는 방법을 설명합니다. 다음 주제가 다루어집니다.

- JavaScript에서 PPT를 PPTX로 변환

## **JavaScript PPT를 PPTX로 변환**

PPT를 PPTX로 변환하는 JavaScript 샘플 코드는 아래 섹션인 [Convert PPT to PPTX](#convert-ppt-to-pptx)를 참조하십시오. 이 코드는 PPT 파일을 로드하고 PPTX 형식으로 저장합니다. 다른 저장 형식을 지정하면 PDF, XPS, ODP, HTML 등 다양한 형식으로 PPT 파일을 저장할 수 있습니다. 자세한 내용은 다음 기사에서 다루고 있습니다.

- [JavaScript에서 PPT를 PDF로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/)
- [JavaScript에서 PPT를 XPS로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-xps/)
- [JavaScript에서 PPT를 HTML로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-html/)
- [JavaScript에서 PPT를 ODP로 변환](/slides/ko/nodejs-java/save-presentation/)
- [JavaScript에서 PPT를 PNG로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-png/)

## **PPT를 PPTX로 변환에 대하여**

Aspose.Slides API를 사용하여 오래된 PPT 형식을 PPTX로 변환합니다. 수천 개의 PPT 프레젠테이션을 PPTX 형식으로 변환해야 하는 경우, 가장 좋은 솔루션은 프로그래밍 방식으로 수행하는 것입니다. Aspose.Slides API를 사용하면 몇 줄의 코드만으로 가능합니다. 이 API는 PPT 프레젠테이션을 PPTX로 변환하는 전체 호환성을 지원하며 다음과 같은 작업이 가능합니다:

- 마스터, 레이아웃 및 슬라이드의 복잡한 구조를 변환합니다.
- 차트가 포함된 프레젠테이션을 변환합니다.
- 그룹 도형, 자동 도형(예: 사각형 및 타원), 사용자 정의 기하학 도형이 포함된 프레젠테이션을 변환합니다.
- 텍스처 및 이미지 채우기 스타일을 가진 자동 도형이 포함된 프레젠테이션을 변환합니다.
- 플레이스홀더, 텍스트 프레임 및 텍스트 보관자를 포함한 프레젠테이션을 변환합니다.

{{% alert color="primary" %}} 

다음 [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx) 앱을 살펴보세요:

[](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx)

이 앱은 [**Aspose.Slides API**](https://products.aspose.com/slides/ko/nodejs-java/)를 기반으로 구축되었으며, 기본 PPT를 PPTX로 변환하는 기능의 실제 예시를 확인할 수 있습니다. Aspose.Slides Conversion은 웹 앱으로, PPT 형식의 프레젠테이션 파일을 드래그 앤 드롭하면 PPTX로 변환된 파일을 다운로드할 수 있습니다.

다른 실시간 [**Aspose.Slides Conversion**](https://products.aspose.app/slides/ko/conversion/) 예제를 찾아보세요.
{{% /alert %}} 

## **PPT를 PPTX로 변환**

Aspose.Slides for Node.js via Java는 이제 개발자가 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 클래스 인스턴스를 사용하여 PPT에 접근하고 이를 해당 [PPTX](https://docs.fileformat.com/presentation/pptx/) 형식으로 변환할 수 있도록 지원합니다. 현재는 [PPT ](https://docs.fileformat.com/presentation/ppt/)를 PPTX로 부분 변환하는 것을 지원합니다.

Aspose.Slides for Node.js via Java는 **PPTX** 프레젠테이션 파일을 나타내는 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 클래스를 제공합니다. 이제 Presentation 클래스는 객체를 인스턴스화할 때 **PPT**에도 접근할 수 있습니다. 다음 예제는 PPT 프레젠테이션을 PPTX 프레젠테이션으로 변환하는 방법을 보여줍니다.

```javascript
// PPTX 파일을 나타내는 Presentation 객체를 인스턴스화합니다
var pres = new aspose.slides.Presentation("Aspose.ppt");
try {
    // PPTX 프레젠테이션을 PPTX 형식으로 저장합니다
    pres.save("ConvertedAspose.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**그림 : 원본 PPT 프레젠테이션**|

위 코드 조각은 변환 후 다음과 같은 PPTX 프레젠테이션을 생성합니다.

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**그림: 변환 후 생성된 PPTX 프레젠테이션**|

## **FAQ**

**PPT와 PPTX 형식의 차이점은 무엇인가요?**

PPT는 Microsoft PowerPoint에서 사용하던 오래된 바이너리 파일 형식이며, PPTX는 Microsoft Office 2007부터 도입된 최신 XML 기반 형식입니다. PPTX 파일은 향상된 성능, 파일 크기 감소, 그리고 데이터 복구 개선을 제공합니다.

**Aspose.Slides가 여러 PPT 파일을 PPTX로 일괄 변환하는 것을 지원하나요?**

예, Aspose.Slides를 루프에서 사용하여 여러 PPT 파일을 프로그래밍 방식으로 PPTX로 변환할 수 있으므로 일괄 변환 시나리오에 적합합니다.

**변환 후 내용과 서식이 유지되나요?**

Aspose.Slides는 프레젠테이션 변환 시 높은 정확성을 유지합니다. 슬라이드 레이아웃, 애니메이션, 도형, 차트 및 기타 디자인 요소가 PPT를 PPTX로 변환하는 동안 그대로 유지됩니다.

**PPT 파일을 PDF나 HTML과 같은 다른 형식으로 변환할 수 있나요?**

예, Aspose.Slides는 PPT 파일을 PDF, XPS, HTML, ODP 및 PNG, JPEG와 같은 이미지 형식을 포함한 다양한 형식으로 변환하는 것을 지원합니다.

**Microsoft PowerPoint가 설치되지 않은 상태에서 PPT를 PPTX로 변환할 수 있나요?**

예, Aspose.Slides는 독립형 API이며 변환을 수행하기 위해 Microsoft PowerPoint나 타사 소프트웨어가 필요하지 않습니다.

**PPT를 PPTX로 변환할 수 있는 온라인 도구가 있나요?**

예, 무료 [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx) 웹 애플리케이션을 사용하면 코드를 작성하지 않고도 브라우저에서 직접 변환을 수행할 수 있습니다.