---
title: 헤더와 푸터
type: docs
weight: 220
url: /ko/androidjava/examples/elements/header-footer/
keywords:
- 코드 예제
- 헤더
- 푸터
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 사용하여 슬라이드 헤더와 푸터를 제어합니다: PPT, PPTX 및 ODP에서 날짜, 슬라이드 번호 및 사용자 지정 텍스트를 Java 예제로 추가합니다."
---
이 문서에서는 **Aspose.Slides for Android via Java**를 사용하여 바닥글을 추가하고 날짜 및 시간 자리표시자를 업데이트하는 방법을 보여줍니다.

## **바닥글 추가**

슬라이드의 바닥글 영역에 텍스트를 추가하고 표시되도록 합니다.

```java
static void addHeaderFooter() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```

## **날짜 및 시간 업데이트**

슬라이드의 날짜 및 시간 자리표시자를 수정합니다.

```java
static void updateDateTime() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```