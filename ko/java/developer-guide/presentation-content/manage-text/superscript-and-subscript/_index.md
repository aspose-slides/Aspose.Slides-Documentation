---
title: Java를 사용한 프레젠테이션에서 상위 첨자 및 하위 첨자 관리
linktitle: 상위 첨자 및 하위 첨자
type: docs
weight: 80
url: /ko/java/superscript-and-subscript/
keywords:
- 상위 첨자
- 하위 첨자
- 상위 첨자 추가
- 하위 첨자 추가
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Java용 Aspose.Slides에서 상위 첨자와 하위 첨자를 마스터하고, 전문적인 텍스트 서식으로 프레젠테이션을 향상시켜 최대 효과를 얻으세요."
---
## **개요**

Aspose.Slides는 PowerPoint(PPT, PPTX) 및 OpenDocument(ODP) 프레젠테이션에 상위 첨자와 하위 첨자 텍스트를 삽입하는 기능을 제공합니다. 화학식, 수학 방정식을 강조하거나 각주로 내용을 주석 처리할 때, 이러한 특수 서식 옵션을 사용하면 명확성과 정확성을 유지할 수 있습니다. 이 문서에서는 상위 첨자와 하위 첨자 스타일을 슬라이드에 손쉽게 적용하고 전문적인 결과를 얻는 방법을 배웁니다.

## **상위 첨자 및 하위 첨자 텍스트 관리**

어떤 단락 부분에서도 상위 첨자와 하위 첨자 텍스트를 추가할 수 있습니다. Aspose.Slides 텍스트 프레임에서 상위 첨자 또는 하위 첨자 텍스트를 추가하려면 [PortionFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/PortionFormat) 클래스의 [**setEscapement**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) 메서드를 사용해야 합니다.

이 속성은 상위 첨자 또는 하위 첨자 텍스트를 반환하거나 설정합니다(값 범위는 -100%(하위 첨자)에서 100%(상위 첨자)까지). 예시:

- [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드 참조를 얻습니다.
- 슬라이드에 [Rectangle](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ShapeType#Rectangle) 유형의 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IAutoShape)를 추가합니다.
- 해당 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IAutoShape)에 연결된 [ITextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ITextFrame)를 엑세스합니다.
- 기존 단락을 모두 삭제합니다.
- 상위 첨자 텍스트를 보관할 새 단락 객체를 생성하고 이를 [ITextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ITextFrame)의 IParagraphs 컬렉션에 추가합니다.
- 새 Portion 객체를 생성합니다.
- 상위 첨자를 추가하려면 Portion의 Escapement 속성을 0~100 사이로 설정합니다(0은 상위 첨자 없음).
- [Portion](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Portion)에 텍스트를 설정하고 해당 단락의 Portion 컬렉션에 추가합니다.
- 하위 첨자 텍스트를 보관할 새 단락 객체를 생성하고 이를 IParagraphs 컬렉션에 추가합니다.
- 새 Portion 객체를 생성합니다.
- 하위 첨자를 추가하려면 Portion의 Escapement 속성을 0~-100 사이로 설정합니다(0은 하위 첨자 없음).
- [Portion](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Portion)에 텍스트를 설정하고 해당 단락의 Portion 컬렉션에 추가합니다.
- 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계들의 구현 예시는 다음과 같습니다.

```java
// PPTX를 나타내는 Presentation 클래스 인스턴스화
Presentation pres = new Presentation();
try {
    // 슬라이드 가져오기
    ISlide slide = pres.getSlides().get_Item(0);

    // 텍스트 상자 생성
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // 상위 첨자 텍스트용 단락 생성
    IParagraph superPar = new Paragraph();

    // 일반 텍스트가 있는 Portion 생성
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // 상위 첨자 텍스트가 있는 Portion 생성
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // 하위 첨자 텍스트용 단락 생성
    IParagraph paragraph2 = new Paragraph();

    // 일반 텍스트가 있는 Portion 생성
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // 하위 첨자 텍스트가 있는 Portion 생성
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

## **자주 묻는 질문**

**PDF 또는 기타 형식으로 내보낼 때 상위 첨자와 하위 첨자가 유지되나요?**

예, Aspose.Slides는 프레젠테이션을 PDF, PPT/PPTX, 이미지 및 기타 지원 형식으로 내보낼 때 상위 첨자와 하위 첨자 서식을 올바르게 유지합니다. 특수 서식이 모든 출력 파일에 그대로 적용됩니다.

**상위 첨자와 하위 첨자를 굵게 또는 기울임꼴과 같은 다른 서식 스타일과 함께 사용할 수 있나요?**

예, Aspose.Slides는 단일 Portion 내에서 다양한 텍스트 스타일을 혼합할 수 있습니다. 굵게, 기울임꼴, 밑줄을 적용하면서 동시에 [PortionFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/portionformat/)의 해당 속성을 설정하여 상위 첨자 또는 하위 첨자를 적용할 수 있습니다.

**테이블, 차트 또는 SmartArt 내부의 텍스트에도 상위 첨자와 하위 첨자 서식이 적용되나요?**

예, Aspose.Slides는 대부분의 객체, 포함 테이블 및 차트 요소 내에서도 서식을 지원합니다. SmartArt를 다룰 때는 적절한 요소(예: [SmartArtNode](https://reference.aspose.com/slides/ko/java/com.aspose.slides/smartartnode/))와 해당 텍스트 컨테이너에 접근한 뒤, 동일한 방식으로 [PortionFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/portionformat/) 속성을 구성하면 됩니다.