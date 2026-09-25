---
title: Android에서 프레젠테이션 접근성 관리
linktitle: 프레젠테이션 접근성
type: docs
weight: 30
url: /ko/androidjava/presentation-accessibility/
keywords:
- 프레젠테이션 접근성
- 대체 텍스트
- 대체 텍스트 제목
- 대체 텍스트 설명
- 장식용으로 표시
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java가 PPT, PPTX 및 ODP 파일에서 프레젠테이션 접근성 검사를 자동화하는 방법을 확인하고, 스크린 리더 경험을 향상시키며 규정 준수를 높이세요."
---
## **소개**

대체 텍스트는 보조 기술을 사용하는 사람들이 이미지, 차트 및 기타 정보형 도형의 의미를 이해하도록 도와줍니다. 이 문서에서는 Aspose.Slides for Android via Java를 사용하여 대체 텍스트 제목 및 설명을 읽고 업데이트하는 방법, 코드에서 사용되는 도형 이름과 접근성 설명을 구분하는 방법, 도형이 장식용으로 표시되는지 확인하는 방법을 설명합니다.

이 기능들은 프레젠테이션 접근성을 지원하지만 보장을 의미하지는 않습니다. 읽기 순서, 색상 대비, 텍스트 가독성 및 기타 접근성 요구 사항도 검토해야 합니다.

## **대체 텍스트 제목 및 설명 관리**

대체 텍스트를 사용하여 이미지를 비롯한 차트 및 기타 정보형 도형의 의미를 시각적으로 볼 수 없는 사람들에게 설명합니다. 다음 메서드와 내용은 각각 다른 용도로 사용됩니다.

| 메서드 또는 내용 | 목적 |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getAlternativeTextTitle--) | 대체 설명의 짧은 제목 |
| [getAlternativeText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getAlternativeText--) | 슬라이드 컨텍스트에서 도형의 내용이나 목적을 의미 있게 설명 |
| [getName](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getName--) | 코드가 프레젠테이션에서 특정 도형을 찾는 데 사용할 수 있는 도형 이름 |
| 표시 텍스트 | 슬라이드에 표시되는 내용(예: 도형 텍스트, 차트 제목 및 레이블 등). 대체 텍스트를 업데이트해도 이 내용은 변경되지 않습니다. |

프레젠테이션을 템플릿으로 재사용할 때, 코드는 [getName](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getName--)이 반환하는 이름으로 도형을 찾아 업데이트할 수 있습니다. 이 이름은 시각적 내용이 독자에게 전달하는 의미를 설명하는 대체 텍스트와 다른 목적을 가집니다. 이름으로 검색하면 설명을 개선하거나 번역하면서도 코드가 도형을 찾는 방식을 변경하지 않을 수 있습니다. 이름은 편집 가능하고 고유성을 보장하지 않으므로, 해당 이름이 의도한 도형과 일치하는지 확인하십시오. 자세히 보려면 [Identify and Find Shapes](/slides/ko/androidjava/shape-manipulations/#identify-and-find-shapes)를 참조하세요.

다음 예제는 첫 번째 슬라이드 첫 번째 도형에 사무실 입구 이미지가 포함된 `input.pptx`를 필요로 합니다. 해당 이미지는 장식용으로 표시되지 않아야 합니다. 예제는 현재 대체 텍스트 제목 및 설명을 읽어 출력하고, 두 값을 업데이트한 뒤 프레젠테이션을 `output.pptx`로 저장합니다. 실제 이미지와 전달하는 정보를 반영하도록 문구를 조정하십시오.

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

대체 텍스트만 추가한다고 해서 프레젠테이션 접근성이나 접근성 표준 준수가 보장되는 것은 아닙니다. 설명의 정확성과 관련성을 검토하고, 읽기 순서, 색상 대비, 읽기 쉬운 텍스트 및 기타 접근성 요구 사항도 확인하십시오. 정보성 시각 자료는 장식용으로 표시되지 않아야 하며, 다음 섹션에서는 [isDecorative](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#isDecorative--)을 확인하는 방법을 보여줍니다.

## **장식용으로 표시**

장식용 플래그는 순수 장식용 시각 자료에 설정하여 스크린 리더가 이를 건너뛰게 함으로써 잡음을 줄이고 의미 있는 콘텐츠에 집중하도록 돕습니다. 배경, 장식 요소, 간격용 도형 등에 적용하고, 차트, 아이콘, 정보를 전달하는 이미지에는 절대 사용하지 마세요. Aspose.Slides는 이 플래그를 감지 및 검증할 수 있도록 제공하여 자동화된 접근성 검사와 정리를 가능하게 합니다.

![장식용으로 표시](mark_as_decorative.png)

다음 코드 샘플은 도형이 장식용으로 표시되었는지 확인하는 방법을 보여줍니다.

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

## **FAQ**

**대체 텍스트 제목과 설명에는 무엇을 넣어야 하나요?**

짧은 제목으로 주제를 식별하고, 설명에서는 시각 자료가 슬라이드 컨텍스트에서 전달하는 정보를 설명합니다. 차트의 경우 “차트”라고만 말하지 말고, 관련된 추세나 비교를 기술하십시오.

**템플릿에서 도형을 찾기 위해 대체 텍스트를 사용해야 할까요?**

[getName](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getName--)이 반환하는 이름으로 도형을 찾고, 해당 도형이 기대하는 도형인지 확인하는 것이 바람직합니다. 대체 텍스트는 편집·번역될 수 있어 정확히 일치하는 설명을 검색하는 코드를 깨뜨릴 수 있습니다. 자세히 보려면 [Identify and Find Shapes](/slides/ko/androidjava/shape-manipulations/)를 참고하세요.

**언제 도형을 장식용으로 표시해야 하나요?**

정보를 전달하지 않는 순수 장식용 시각 자료(예: 장식적인 플러리시)를 대상으로 플래그를 사용합니다. 의미를 전달하는 이미지와 차트에는 적절한 설명이 필요합니다.

**대체 텍스트를 추가하면 프레젠테이션이 완전히 접근 가능해지나요?**

아니요. 대체 텍스트는 접근성의 일부에만 해당합니다. 읽기 순서, 색상 대비, 텍스트 가독성 및 기타 적용 가능한 요구 사항도 검토해야 하며, 이 속성들만으로는 준수를 보장할 수 없습니다.