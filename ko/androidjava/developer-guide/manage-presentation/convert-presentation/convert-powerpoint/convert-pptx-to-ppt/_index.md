---
title: Android에서 PPTX를 PPT로 변환
linktitle: PPTX를 PPT로
type: docs
weight: 21
url: /ko/androidjava/convert-pptx-to-ppt/
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
- Android
- Java
- Aspose.Slides
description: "Java를 통해 Android용 Aspose.Slides로 PPTX를 PPT로 손쉽게 변환하여, PowerPoint 형식과의 원활한 호환성을 유지하고 프레젠테이션의 레이아웃과 품질을 보존합니다."
---
## **개요**

이 문서에서는 Java를 사용하여 PPTX 형식의 PowerPoint 프레젠테이션을 PPT 형식으로 변환하는 방법을 설명합니다. 다음 주제가 다루어집니다.

- Java에서 PPTX를 PPT로 변환

## **Android에서 PPTX를 PPT로 변환**

PPTX를 PPT로 변환하는 Java 샘플 코드는 아래 섹션인 [Convert PPTX to PPT](#convert-pptx-to-ppt)을 참고하십시오. 이 코드는 PPTX 파일을 로드하고 PPT 형식으로 저장합니다. 다른 저장 형식을 지정하면 PDF, XPS, ODP, HTML 등 다양한 형식으로 PPTX 파일을 저장할 수 있습니다. 이와 관련된 문서에서 자세히 설명합니다.

- [Android에서 PPTX를 PDF로 변환](/slides/ko/androidjava/convert-powerpoint-to-pdf/)
- [Android에서 PPTX를 XPS로 변환](/slides/ko/androidjava/convert-powerpoint-to-xps/)
- [Android에서 PPTX를 HTML로 변환](/slides/ko/androidjava/convert-powerpoint-to-html/)
- [Android에서 PPTX를 ODP로 변환](/slides/ko/androidjava/save-presentation/)
- [Android에서 PPTX를 PNG로 변환](/slides/ko/androidjava/convert-powerpoint-to-png/)

## **PPTX를 PPT로 변환**
PPTX를 PPT로 변환하려면 파일 이름과 저장 형식을 [**Presentation**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 **Save** 메서드에 전달하면 됩니다. 아래 Java 코드 샘플은 기본 옵션을 사용하여 Presentation을 PPTX에서 PPT로 변환합니다.

```java
// PPTX 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation presentation = new Presentation("template.pptx");

// 프레젠테이션을 PPT로 저장합니다
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **FAQ**

**PPTX의 모든 효과와 기능이 레거시 PPT(97–2003) 형식으로 저장할 때 그대로 유지되나요?**

항상 그런 것은 아닙니다. PPT 형식은 일부 최신 기능(예: 특정 효과, 개체 및 동작)을 지원하지 않으므로 변환 과정에서 기능이 단순화되거나 래스터화될 수 있습니다.

**전체 프레젠테이션이 아니라 선택한 슬라이드만 PPT로 변환할 수 있나요?**

직접 저장은 전체 프레젠테이션을 대상으로 합니다. 특정 슬라이드만 변환하려면 해당 슬라이드만 포함한 새로운 프레젠테이션을 만든 후 PPT로 저장하십시오. 또는 슬라이드별 변환 매개변수를 지원하는 서비스/API를 사용할 수 있습니다.

**암호로 보호된 프레젠테이션을 지원하나요?**

예. 파일이 보호되어 있는지 감지하고, 비밀번호로 열 수 있으며, 저장된 PPT에 대해 [보호/암호화 설정을 구성](/slides/ko/androidjava/password-protected-presentation/)할 수도 있습니다.