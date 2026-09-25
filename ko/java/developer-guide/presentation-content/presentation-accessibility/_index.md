---
title: Java에서 프레젠테이션 접근성 관리
linktitle: 프레젠테이션 접근성
type: docs
weight: 30
url: /ko/java/presentation-accessibility/
keywords:
- 프레젠테이션 접근성
- 대체 텍스트
- 대체 텍스트 제목
- 대체 텍스트 설명
- 장식으로 표시
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java가 PPT, PPTX 및 ODP 파일에서 프레젠테이션 접근성 검사를 자동화하는 방법을 알아보고, 스크린 리더 경험을 향상시키고 준수를 높이세요."
---
## **소개**

대체 텍스트는 보조 기술을 사용하는 사람이 이미지, 차트 및 기타 정보 제공 도형의 의미를 이해하도록 도와줍니다. 이 문서에서는 Aspose.Slides for Java를 사용하여 대체 텍스트 제목과 설명을 읽고 업데이트하는 방법, 코드에서 사용되는 도형 이름과 접근성 설명을 구분하는 방법, 그리고 도형이 장식으로 표시되는지를 확인하는 방법을 설명합니다.

이러한 기능은 프레젠테이션 접근성을 지원하지만 이를 보장하지는 않습니다. 읽기 순서, 색상 대비, 텍스트 가독성 및 기타 접근성 요구 사항도 검토해야 합니다.

## **대체 텍스트 제목 및 설명 관리**

대체 텍스트를 사용하여 이미지, 차트 및 기타 정보 제공 도형의 의미를 시각을 볼 수 없는 사람에게 설명합니다. 다음 메서드와 콘텐츠는 각각 다른 용도로 사용됩니다.

| 메서드 또는 콘텐츠 | 목적 |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getAlternativeTextTitle--) | 대체 설명에 대한 짧은 제목. |
| [getAlternativeText](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getAlternativeText--) | 슬라이드 컨텍스트에서 도형의 내용 또는 목적에 대한 의미 있는 설명. |
| [getName](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getName--) | 프레젠테이션에서 특정 도형을 찾기 위해 코드가 사용할 수 있는 도형 이름. |
| Visible text | 슬라이드에 표시되는 콘텐츠(예: 도형의 텍스트 또는 차트의 제목 및 레이블). 대체 텍스트를 업데이트해도 이 콘텐츠는 변경되지 않습니다. |

프레젠테이션을 템플릿으로 재사용할 때 코드는 [getName](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getName--)이 반환하는 이름으로 도형을 찾아 업데이트할 수 있습니다. 이 이름은 시각이 독자에게 전달하는 의미를 설명하는 대체 텍스트와는 다른 목적을 가집니다. 이름으로 검색하면 설명을 개선하거나 번역해도 코드가 도형을 찾는 방식에 영향을 주지 않습니다. 이름은 편집할 수 있고 고유성을 보장하지 않으므로 의도한 도형과 일치하는지 확인하세요. 자세한 내용은 [Identify and Find Shapes](/slides/ko/java/shape-manipulations/#identify-and-find-shapes)를 참조하십시오.

다음 예제는 첫 번째 슬라이드의 첫 번째 도형으로 사무실 입구 이미지가 있는 `input.pptx`가 필요합니다. 해당 이미지는 장식으로 표시되지 않아야 합니다. 예제는 현재 대체 텍스트 제목과 설명을 읽어 출력하고, 두 값을 업데이트한 후 프레젠테이션을 `output.pptx`로 저장합니다. 실제 이미지와 전달하는 정보를 기준으로 문구를 조정하십시오.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    System.out.println("Alternative text title: " + shape.getAlternativeTextTitle());
    System.out.println("Alternative text description: " + shape.getAlternativeText());

    shape.setAlternativeTextTitle("Office entrance");
    shape.setAlternativeText("The office entrance has a wheelchair ramp to the right of the steps.");

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

대체 텍스트만 추가한다고 해서 프레젠테이션 접근성이나 접근성 표준 준수가 보장되지 않습니다. 설명의 정확성과 관련성을 검토하고, 읽기 순서, 색상 대비, 가독성 텍스트 및 기타 접근성 요구 사항도 확인하십시오. 정보 전달 시각은 장식으로 표시해서는 안 되며, 다음 섹션에서는 [isDecorative](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#isDecorative--)를 확인하는 방법을 보여줍니다.

## **장식으로 표시**

장식으로 표시 플래그는 순전히 장식적인 시각 요소에 지정하여 화면 판독기가 이를 건너뛰게 하여 잡음을 줄이고 의미 있는 콘텐츠에 집중하도록 합니다. 배경, 장식 요소 및 간격용 도형에 적용하고, 차트, 아이콘 또는 정보를 전달하는 이미지에는 절대 적용하지 마십시오. Aspose.Slides는 이 플래그를 감지 및 검증할 수 있도록 제공하여 자동 접근성 검사와 정리를 가능하게 합니다.

![장식으로 표시](mark_as_decorative.png)

다음 코드 샘플은 도형이 장식으로 표시되었는지 확인하는 방법을 보여줍니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```

## **자주 묻는 질문**

**대체 텍스트 제목 및 설명에 무엇을 넣어야 하나요?**  
짧은 제목을 사용해 주제를 식별하고, 설명을 통해 슬라이드 컨텍스트에서 시각이 전달하는 정보를 설명하십시오. 차트의 경우 "차트"라고만 말하지 말고 관련 추세나 비교 내용을 기술하세요.

**템플릿에서 도형을 찾기 위해 대체 텍스트를 사용해야 하나요?**  
[getName](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getName--)이 반환하는 이름으로 도형을 찾고, 예상 도형인지 확인하는 것을 권장합니다. 대체 텍스트는 편집되거나 번역될 수 있어 정확한 설명을 검색하는 코드가 깨질 위험이 있습니다. 자세한 내용은 [Identify and Find Shapes](/slides/ko/java/shape-manipulations/)를 참고하십시오.

**도형을 언제 장식으로 표시해야 하나요?**  
정보를 전달하지 않는 순수 장식용 시각 요소(예: 장식적인 플러시)에는 장식 플래그를 사용하십시오. 의미를 전달하는 이미지와 차트에는 적절한 설명이 필요합니다.

**대체 텍스트를 추가하면 프레젠테이션이 완전히 접근 가능해지나요?**  
아니오. 대체 텍스트는 접근성의 일부만 다룹니다. 읽기 순서, 색상 대비, 텍스트 가독성 및 기타 적용 가능한 요구 사항도 검토해야 하며, 해당 속성만 설정한다고 해서 준수가 보장되지 않습니다.