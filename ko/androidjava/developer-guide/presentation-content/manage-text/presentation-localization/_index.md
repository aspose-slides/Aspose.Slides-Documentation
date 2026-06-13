---
title: Android에서 프레젠테이션 현지화 자동화
linktitle: 프레젠테이션 현지화
type: docs
weight: 100
url: /ko/androidjava/presentation-localization/
keywords:
- 언어 변경
- 맞춤법 검사
- 언어 ID
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 사용하여 Java에서 PowerPoint 및 OpenDocument 슬라이드 현지화를 자동화하고, 실용적인 코드 샘플과 팁을 통해 빠른 글로벌 배포를 돕습니다."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션의 텍스트에 `LanguageId`를 설정하는 방법을 설명합니다. 프레젠테이션을 열고, 텍스트가 포함된 도형을 추가하고, 텍스트 부분에 언어 식별자를 할당한 다음 결과를 PPTX 파일로 저장하는 방법을 보여줍니다.

## **프레젠테이션 및 도형 텍스트의 언어 변경**
- [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
- 슬라이드에 [Rectangle](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ShapeType#Rectangle) 유형의 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IAutoShape)를 추가합니다.
- TextFrame에 텍스트를 추가합니다.
- [Setting Language Id](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) 를 텍스트에 설정합니다.
- 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계들의 구현은 아래 예제에서 시연됩니다.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**언어 ID가 자동 텍스트 번역을 트리거합니까?**

아니요. Aspose.Slides의 [Language ID](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) 는 맞춤법 검사와 문법 교정을 위한 언어를 저장하지만 텍스트 내용을 번역하거나 변경하지는 않습니다. 이는 PowerPoint이 교정을 위해 인식하는 메타데이터입니다.

**언어 ID가 렌더링 시 하이픈 삽입 및 줄 바꿈에 영향을 줍니까?**

Aspose.Slides에서 [language ID](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) 는 교정을 위한 것입니다. 하이픈 품질 및 줄 바꿈은 주로 [proper fonts](/slides/ko/androidjava/powerpoint-fonts/) 의 가용성과 쓰기 시스템에 대한 레이아웃/줄 바꿈 설정에 따라 달라집니다. 올바른 렌더링을 보장하려면 필요한 글꼴을 사용 가능하게 하고, [font substitution rules](/slides/ko/androidjava/font-substitution/) 를 구성하거나, 프레젠테이션에 [embed fonts](/slides/ko/androidjava/embedded-font/) 를 포함시키세요.

**단일 문단 내에 서로 다른 언어를 설정할 수 있습니까?**

예. [Language ID](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) 은 텍스트 부분 수준에 적용되므로 단일 문단에서도 여러 언어를 섞어 각각 다른 교정 설정을 사용할 수 있습니다.