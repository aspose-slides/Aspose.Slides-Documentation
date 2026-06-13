---
title: 섹션
type: docs
weight: 90
url: /ko/java/examples/elements/section/
keywords:
- 코드 예제
- 섹션
- 파워포인트
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 슬라이드 섹션 관리: PPT, PPTX 및 ODP용 Java 예제를 사용하여 슬라이드를 생성, 이름 변경, 순서 변경 및 그룹화합니다."
---
프레젠테이션 섹션을 프로그래밍 방식으로 관리하는 예시—추가, 액세스, 제거 및 이름 바꾸기, **Aspose.Slides for Java** 사용.

## **섹션 추가**

특정 슬라이드에서 시작되는 섹션을 생성합니다.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 섹션의 시작을 표시하는 슬라이드를 지정합니다.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **섹션 접근**

프레젠테이션에서 섹션 정보를 읽어옵니다.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // 인덱스로 섹션에 접근합니다.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **섹션 제거**

이전에 추가된 섹션을 삭제합니다.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // 첫 번째 섹션을 제거합니다.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **섹션 이름 바꾸기**

기존 섹션의 이름을 변경합니다.

```java
static void renameSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("Old Name", slide);

        ISection section = presentation.getSections().get_Item(0);
        section.setName("New Name");
    } finally {
        presentation.dispose();
    }
}
```