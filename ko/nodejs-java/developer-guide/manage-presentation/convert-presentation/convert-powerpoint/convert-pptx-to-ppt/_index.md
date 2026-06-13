---
title: JavaScript에서 PPTX를 PPT로 변환
linktitle: PPTX를 PPT로
type: docs
weight: 21
url: /ko/nodejs-java/convert-pptx-to-ppt/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPTX 변환
- PPTX를 PPT로
- PPTX를 PPT로 저장
- PPTX를 PPT로 내보내기
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PPTX를 PPT로 쉽게 변환합니다—PowerPoint 형식과의 원활한 호환성을 보장하고 프레젠테이션의 레이아웃과 품질을 유지합니다."
---
## **개요**

이 문서에서는 JavaScript를 사용하여 PPTX 형식의 PowerPoint 프레젠테이션을 PPT 형식으로 변환하는 방법을 설명합니다. 다음 주제가 다루어집니다.

- JavaScript에서 PPTX를 PPT로 변환

## **Java PPTX를 PPT로 변환**

PPTX를 PPT로 변환하는 JavaScript 샘플 코드는 아래 섹션, 즉 [PPTX를 PPT로 변환](#convert-pptx-to-ppt)에서 확인하십시오. 이 코드는 PPTX 파일을 로드하고 PPT 형식으로 저장합니다. 다른 저장 형식을 지정하면 PDF, XPS, ODP, HTML 등 다양한 형식으로 PPTX 파일을 저장할 수도 있습니다. 자세한 내용은 해당 문서를 참조하십시오.

- [JavaScript에서 PPTX를 PDF로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/)
- [JavaScript에서 PPTX를 XPS로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-xps/)
- [JavaScript에서 PPTX를 HTML로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-html/)
- [JavaScript에서 PPTX를 ODP로 변환](/slides/ko/nodejs-java/save-presentation/)
- [JavaScript에서 PPTX를 PNG로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-png/)

## **PPTX를 PPT로 변환**

PPTX를 PPT로 변환하려면 파일 이름과 저장 형식을 [**Presentation**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 **Save** 메서드에 전달하면 됩니다. 아래 JavaScript 코드 예제는 기본 옵션을 사용하여 PPTX를 PPT로 변환합니다.

```javascript
// PPTX 파일을 나타내는 Presentation 객체를 인스턴스화합니다
var presentation = new aspose.slides.Presentation("template.pptx");
// 프레젠테이션을 PPT로 저장합니다
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```

## **FAQ**

**PPTX의 모든 효과와 기능이 레거시 PPT(97–2003) 형식으로 저장할 때 그대로 유지됩니까?**

항상 그런 것은 아닙니다. PPT 형식은 일부 최신 기능(예: 특정 효과, 개체 및 동작)을 지원하지 않으므로 변환 과정에서 기능이 간소화되거나 래스터화될 수 있습니다.

**전체 프레젠테이션이 아니라 선택한 슬라이드만 PPT로 변환할 수 있나요?**

직접 저장은 전체 프레젠테이션을 대상으로 합니다. 특정 슬라이드만 변환하려면 해당 슬라이드만 포함한 새 프레젠테이션을 만든 후 PPT로 저장하십시오. 또는 슬라이드별 변환 매개변수를 지원하는 서비스/API를 사용할 수 있습니다.

**비밀번호로 보호된 프레젠테이션을 지원합니까?**

예. 파일이 보호되어 있는지 감지하고 비밀번호로 열 수 있으며, 저장된 PPT에 대해 [보호/암호화 설정 구성](/slides/ko/nodejs-java/password-protected-presentation/)도 할 수 있습니다.