---
title: Android에서 프레젠테이션의 위첨자와 아래첨자 관리
linktitle: 위첨자와 아래첨자
type: docs
weight: 80
url: /ko/androidjava/superscript-and-subscript/
keywords:
- 위첨자
- 아래첨자
- 위첨자 추가
- 아래첨자 추가
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Android용 Aspose.Slides에서 Java를 통해 위첨자와 아래첨자를 마스터하고 전문적인 텍스트 서식으로 프레젠테이션을 최고 수준으로 향상시키세요."
---
## **개요**

Aspose.Slides는 PowerPoint(PPT, PPTX) 및 OpenDocument(ODP) 프레젠테이션에 위첨자와 아래첨자 텍스트를 통합하는 기능을 제공합니다. 화학식, 수학 방정식을 강조하거나 각주로 내용을 주석 처리해야 할 때, 이러한 특수 서식 옵션은 명확성과 정확성을 유지하는 데 도움이 됩니다. 이 문서에서는 위첨자와 아래첨자 스타일을 원활하게 적용하고 모든 슬라이드에서 전문가 수준의 결과를 얻는 방법을 배웁니다.

## **위첨자 및 아래첨자 텍스트 관리**
모든 단락 부분에 위첨자와 아래첨자 텍스트를 추가할 수 있습니다. Aspose.Slides 텍스트 프레임에 위첨자 또는 아래첨자 텍스트를 추가하려면 [**setEscapement**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) 메서드와 [PortionFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/PortionFormat) 클래스를 사용해야 합니다.

이 속성은 위첨자 또는 아래첨자 텍스트를 반환하거나 설정합니다(값 범위는 -100%​(아래첨자)부터 100%​(위첨자)까지). 예를 들어:

- [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
- 슬라이드에 [Rectangle](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ShapeType#Rectangle) 유형의 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IAutoShape)를 추가합니다.
- [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IAutoShape)와 연결된 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ITextFrame)에 액세스합니다.
- 기존 Paragraphs를 정리합니다.
- 위첨자 텍스트를 보관할 새 paragraph 객체를 생성하고 이를 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ITextFrame)의 [IParagraphs collection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ITextFrame#getParagraphs--)에 추가합니다.
- 새 portion 객체를 생성합니다.
- 위첨자를 추가하기 위해 portion의 Escapement 속성을 0~100 사이로 설정합니다(0은 위첨자 없음).
- [Portion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Portion)에 텍스트를 설정한 뒤 해당 portion을 paragraph의 컬렉션에 추가합니다.
- 아래첨자 텍스트를 보관할 새 paragraph 객체를 생성하고 이를 ITextFrame의 IParagraphs 컬렉션에 추가합니다.
- 새 portion 객체를 생성합니다.
- 아래첨자를 추가하기 위해 portion의 Escapement 속성을 0에서 -100 사이로 설정합니다(0은 아래첨자 없음).
- [Portion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Portion)에 텍스트를 설정한 뒤 해당 portion을 paragraph의 컬렉션에 추가합니다.
- 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계들의 구현 예는 아래에 나와 있습니다.

```java
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 슬라이드 가져오기
    ISlide slide = pres.getSlides().get_Item(0);

    // 텍스트 상자 생성
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // 위첨자 텍스트용 단락 생성
    IParagraph superPar = new Paragraph();

    // 일반 텍스트가 포함된 부분 생성
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // 위첨자 텍스트가 포함된 부분 생성
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // 아래첨자 텍스트용 단락 생성
    IParagraph paragraph2 = new Paragraph();

    // 일반 텍스트가 포함된 부분 생성
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // 아래첨자 텍스트가 포함된 부분 생성
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // 텍스트 상자에 단락 추가
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**PDF 또는 다른 형식으로 내보낼 때 위첨자와 아래첨자가 보존되나요?**

예, Aspose.Slides는 프레젠테이션을 PDF, PPT/PPTX, 이미지 및 기타 지원 형식으로 내보낼 때 위첨자와 아래첨자 서식을 올바르게 유지합니다. 특수 서식은 모든 출력 파일에서 그대로 유지됩니다.

**위첨자와 아래첨자를 굵게 또는 기울임꼴과 같은 다른 서식 스타일과 함께 사용할 수 있나요?**

예, Aspose.Slides를 사용하면 단일 텍스트 portion 내에서 다양한 텍스트 스타일을 혼합할 수 있습니다. 굵게, 기울임꼴, 밑줄을 활성화하고 동시에 해당 속성을 [PortionFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/portionformat/)에서 설정하여 위첨자 또는 아래첨자를 적용할 수 있습니다.

**표, 차트 또는 SmartArt 내부 텍스트에도 위첨자와 아래첨자 서식이 적용되나요?**

예, Aspose.Slides는 표와 차트 요소를 포함한 대부분의 객체 내에서 서식을 지원합니다. SmartArt를 사용할 때는 해당 요소(예: [SmartArtNode](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/smartartnode/))와 텍스트 컨테이너에 접근한 뒤, [PortionFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/portionformat/) 속성을 동일한 방식으로 설정하면 됩니다.