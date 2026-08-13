---
title: Android에서 PPT를 PPTX로 변환
linktitle: PPT를 PPTX로
type: docs
weight: 20
url: /ko/androidjava/convert-ppt-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android을 사용하여 Java에서 레거시 PPT 프레젠테이션을 최신 PPTX로 빠르게 변환합니다 — 명확한 튜토리얼, 무료 코드 샘플 제공, Microsoft Office 의존 없음."
---
## **개요**

이 문서는 Java와 온라인 PPT → PPTX 변환 앱을 사용하여 PPT 형식의 PowerPoint 프레젠테이션을 PPTX 형식으로 변환하는 방법을 설명합니다. 다음 주제를 다룹니다.

- Java에서 PPT를 PPTX로 변환

## **Android에서 PPT를 PPTX로 변환**

Java 샘플 코드를 보려면 아래 섹션, 즉 [Convert PPT to PPTX](#convert-ppt-to-pptx) 를 참고하십시오. 이 코드는 PPT 파일을 로드하고 PPTX 형식으로 저장합니다. 저장 형식을 변경하면 PDF, XPS, ODP, HTML 등 다양한 형식으로도 저장할 수 있습니다. 자세한 내용은 아래 기사들을 참고하세요.

- [Convert PPT to PDF on Android](/slides/ko/androidjava/convert-powerpoint-to-pdf/)
- [Convert PPT to XPS on Android](/slides/ko/androidjava/convert-powerpoint-to-xps/)
- [Convert PPT to HTML on Android](/slides/ko/androidjava/convert-powerpoint-to-html/)
- [Convert PPT to ODP on Android](/slides/ko/androidjava/save-presentation/)
- [Convert PPT to PNG on Android](/slides/ko/androidjava/convert-powerpoint-to-png/)

## **PPT → PPTX 변환에 대해**
Aspose.Slides API를 사용하여 오래된 PPT 형식을 PPTX로 변환합니다. 수천 개의 PPT 프레젠테이션을 PPTX 형식으로 변환해야 하는 경우 프로그래밍 방식으로 처리하는 것이 최선의 솔루션입니다. Aspose.Slides API만 있으면 몇 줄의 코드로 가능합니다. API는 PPT 프레젠테이션을 PPTX로 변환하기 위한 완전한 호환성을 제공하며 다음과 같은 작업이 가능합니다.

- 마스터, 레이아웃 및 슬라이드의 복잡한 구조 변환
- 차트가 포함된 프레젠테이션 변환
- 그룹 도형, 자동 도형(사각형 및 타원 등), 사용자 정의 기하학 도형 변환
- 자동 도형에 텍스처 및 이미지 채우기 스타일이 적용된 프레젠테이션 변환
- 플레이스홀더, 텍스트 프레임 및 텍스트 보유자가 포함된 프레젠테이션 변환

{{% alert color="info" %}} 

다음 [**Aspose.Slides PPT to PPTX 변환**](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx) 앱을 확인하십시오:

[](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx)

이 앱은 [**Aspose.Slides API**](https://products.aspose.com/slides/ko/androidjava/)를 기반으로 구축되었으며, 기본 PPT → PPTX 변환 기능을 실시간 예제로 확인할 수 있습니다. Aspose.Slides Conversion은 PPT 형식의 프레젠테이션 파일을 드롭하고 PPTX로 변환하여 다운로드할 수 있는 웹 앱입니다.

다른 실시간 [**Aspose.Slides Conversion**](https://products.aspose.app/slides/ko/conversion/) 예제를 찾아보세요.
{{% /alert %}} 

## **PPT를 PPTX로 변환**
Java를 통한 Android용 Aspose.Slides는 이제 개발자가 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) 클래스 인스턴스를 사용해 PPT에 접근하고 이를 해당 [PPTX](https://docs.fileformat.com/presentation/pptx/) 형식으로 변환할 수 있도록 지원합니다. 현재는 [PPT](https://docs.fileformat.com/presentation/ppt/)를 PPTX로 부분 변환하는 기능을 지원합니다.

Java를 통한 Android용 Aspose.Slides는 **PPTX** 프레젠테이션 파일을 나타내는 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) 클래스를 제공합니다. 객체를 인스턴스화할 때 Presentation을 통해 **PPT**에도 접근할 수 있습니다. 아래 예제는 PPT 프레젠테이션을 PPTX 프레젠테이션으로 변환하는 방법을 보여줍니다.

```java
import com.aspose.slides.*;

// PPT 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation("Aspose.ppt");
try {
// PPT 프레젠테이션을 PPTX 형식으로 저장합니다
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**그림 : 원본 PPT 프레젠테이션**|

위 코드 스니펫은 변환 후 다음과 같은 PPTX 프레젠테이션을 생성합니다.

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**그림: 변환 후 생성된 PPTX 프레젠테이션**|

## **FAQ**

### PPT와 PPTX 형식의 차이점은 무엇인가요?

PPT는 Microsoft PowerPoint에서 사용하던 오래된 이진 파일 형식이며, PPTX는 Microsoft Office 2007부터 도입된 XML 기반 최신 형식입니다. PPTX 파일은 성능이 우수하고 파일 크기가 작으며 데이터 복구가 개선되었습니다.

### Aspose.Slides가 여러 PPT 파일을 PPTX로 일괄 변환하는 것을 지원하나요?

예, Aspose.Slides를 루프와 함께 사용하면 여러 PPT 파일을 프로그래밍 방식으로 PPTX로 일괄 변환할 수 있어 배치 변환 시나리오에 적합합니다.

### 변환 후 내용과 형식이 유지되나요?

Aspose.Slides는 프레젠테이션 변환 시 높은 충실도를 유지합니다. 슬라이드 레이아웃, 애니메이션, 도형, 차트 및 기타 디자인 요소가 PPT → PPTX 변환 과정에서 그대로 보존됩니다.

### PPT 파일을 PDF나 HTML 같은 다른 형식으로 변환할 수 있나요?

예, Aspose.Slides는 PDF, XPS, HTML, ODP 및 PNG, JPEG과 같은 이미지 형식을 포함한 [다양한 형식](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/saveformat/)으로 PPT 파일을 변환하는 것을 지원합니다.

### Microsoft PowerPoint를 설치하지 않아도 PPT를 PPTX로 변환할 수 있나요?

예, Aspose.Slides는 독립형 API이며 Microsoft PowerPoint나 타사 소프트웨어 없이도 변환을 수행할 수 있습니다.

### PPT를 PPTX로 변환할 수 있는 온라인 도구가 있나요?

예, 코드를 작성하지 않고도 브라우저에서 직접 변환할 수 있는 무료 [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx) 웹 애플리케이션을 사용할 수 있습니다.