---
title: Android에서 프레젠테이션 슬라이드에 액세스
linktitle: 슬라이드 액세스
type: docs
weight: 20
url: /ko/androidjava/access-slide-in-presentation/
keywords:
- 슬라이드 액세스
- 슬라이드 인덱스
- 슬라이드 ID
- 슬라이드 위치
- 위치 변경
- 슬라이드 속성
- 슬라이드 번호
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 슬라이드에 액세스하고 관리하는 방법을 배웁니다. Java 코드 예제로 생산성을 향상시키세요."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션의 슬라이드에 액세스하고 관리하는 방법을 설명합니다. 슬라이드 컬렉션에서 0부터 시작하는 인덱스로 슬라이드를 검색하고 `getSlideById` 메서드를 사용하여 고유 ID로 슬라이드에 접근하는 방법을 보여줍니다.

또한 `setSlideNumber` 메서드를 사용해 슬라이드의 위치를 변경하고, `setFirstSlideNumber` 메서드로 프레젠테이션의 시작 슬라이드 번호를 정의하는 방법도 배울 수 있습니다. 예제에서는 프레젠테이션을 로드하고, 슬라이드 참조를 얻으며, 슬라이드 순서나 번호를 업데이트하고, 수정된 프레젠테이션을 저장하는 과정을 시연합니다.

## **인덱스로 슬라이드에 접근**

프레젠테이션의 모든 슬라이드는 슬라이드 위치를 기준으로 0부터 시작하는 숫자로 정렬됩니다. 첫 번째 슬라이드는 인덱스 0으로 접근하고, 두 번째 슬라이드는 인덱스 1으로 접근하는 식입니다.

프레젠테이션 파일을 나타내는 Presentation 클래스는 모든 슬라이드를 [ISlideCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islidecollection/) 컬렉션([ISlide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islide/) 객체의 컬렉션)으로 노출합니다. 다음 Java 코드는 인덱스를 통해 슬라이드에 접근하는 방법을 보여줍니다:

```java
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation("demo.pptx");
try {
    // 슬라이드 인덱스를 사용하여 슬라이드에 접근합니다
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **ID로 슬라이드에 접근**

프레젠테이션의 각 슬라이드에는 고유 ID가 할당됩니다. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스가 제공하는 [getSlideById](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getSlideById-long-) 메서드를 사용하여 해당 ID를 지정할 수 있습니다. 다음 Java 코드는 유효한 슬라이드 ID를 제공하고 [getSlideById](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getSlideById-long-) 메서드로 슬라이드에 접근하는 방법을 보여줍니다:

```java
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation("demo.pptx");
try {
    // 슬라이드 ID를 가져옵니다
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // ID를 통해 슬라이드에 접근합니다
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **슬라이드 위치 변경**

Aspose.Slides를 사용하면 슬라이드 위치를 변경할 수 있습니다. 예를 들어 첫 번째 슬라이드를 두 번째 슬라이드로 만들 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
1. 위치를 변경하려는 슬라이드의 인덱스를 통해 슬라이드 참조를 얻습니다.  
1. [setSlideNumber](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islide/#setSlideNumber-int-) 속성을 사용해 슬라이드의 새 위치를 지정합니다.  
1. 수정된 프레젠테이션을 저장합니다.

다음 Java 코드는 위치 1에 있던 슬라이드를 위치 2로 이동하는 작업을 시연합니다:

```java
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 위치가 변경될 슬라이드를 가져옵니다
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 슬라이드의 새 위치를 설정합니다
    sld.setSlideNumber(2);
    
    // 수정된 프레젠테이션을 저장합니다
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

첫 번째 슬라이드가 두 번째가 되었고, 두 번째 슬라이드가 첫 번째가 되었습니다. 슬라이드 위치를 변경하면 다른 슬라이드가 자동으로 조정됩니다.


## **슬라이드 번호 설정**

[Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스가 제공하는 [setFirstSlideNumber](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) 속성을 사용하면 프레젠테이션에서 첫 번째 슬라이드의 번호를 새 값으로 지정할 수 있습니다. 이 작업은 다른 슬라이드 번호를 다시 계산하게 합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
1. 슬라이드 번호를 가져옵니다.  
1. 슬라이드 번호를 설정합니다.  
1. 수정된 프레젠테이션을 저장합니다.

다음 Java 코드는 첫 번째 슬라이드 번호를 10으로 설정하는 작업을 보여줍니다:

```java
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // 슬라이드 번호를 가져옵니다
    int firstSlideNumber = pres.getFirstSlideNumber();

    // 슬라이드 번호를 설정합니다
    pres.setFirstSlideNumber(10);
	
    // 수정된 프레젠테이션을 저장합니다
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

첫 번째 슬라이드를 건너뛰고 두 번째 슬라이드부터 번호를 매기고 싶다면 (첫 번째 슬라이드의 번호는 숨김) 다음과 같이 할 수 있습니다:

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // 첫 번째 프레젠테이션 슬라이드의 번호를 설정합니다
    presentation.setFirstSlideNumber(0);

    // 모든 슬라이드에 슬라이드 번호를 표시합니다
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // 첫 번째 슬라이드의 슬라이드 번호를 숨깁니다
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // 수정된 프레젠테이션을 저장합니다
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**사용자가 보는 슬라이드 번호가 컬렉션의 0 기반 인덱스와 일치합니까?**

슬라이드에 표시되는 번호는 임의의 값(예: 10)부터 시작할 수 있으며 인덱스와 일치할 필요가 없습니다. 이 관계는 프레젠테이션의 [first slide number](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) 설정으로 제어됩니다.

**숨긴 슬라이드가 인덱싱에 영향을 줍니까?**

네. 숨긴 슬라이드도 컬렉션에 남아 있으며 인덱싱에 포함됩니다. "숨김"은 화면 표시 여부를 의미할 뿐, 컬렉션 내 위치에는 영향을 주지 않습니다.

**다른 슬라이드가 추가되거나 제거될 때 슬라이드 인덱스가 변합니까?**

네. 인덱스는 항상 현재 슬라이드 순서를 반영하며 삽입, 삭제, 이동 작업이 발생하면 다시 계산됩니다.