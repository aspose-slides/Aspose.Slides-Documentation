---
title: 마스터 슬라이드
type: docs
weight: 30
url: /ko/java/examples/elements/master-slide/
keywords:
- 코드 예제
- 마스터 슬라이드
- 파워포인트
- 오픈도큐먼트
- 프레젠테이션
- 자바
- Aspose.Slides
description: "Aspose.Slides for Java 마스터 슬라이드 예제를 탐색하세요: PPT, PPTX 및 ODP에서 마스터, 플레이스홀더 및 테마를 생성, 편집 및 스타일링하는 명확한 Java 코드."
---
마스터 슬라이드는 PowerPoint의 슬라이드 상속 계층 구조에서 최상위 레벨을 형성합니다. **마스터 슬라이드**는 배경, 로고, 텍스트 서식과 같은 공통 디자인 요소를 정의합니다. **레이아웃 슬라이드**는 마스터 슬라이드에서 상속하고, **일반 슬라이드**는 레이아웃 슬라이드에서 상속합니다.

이 문서에서는 Aspose.Slides for Java를 사용하여 마스터 슬라이드를 생성, 수정 및 관리하는 방법을 보여줍니다.

## **마스터 슬라이드 추가**

이 예제는 기본 마스터 슬라이드를 복제하여 새 마스터 슬라이드를 만드는 방법을 보여줍니다. 그런 다음 레이아웃 상속을 통해 모든 슬라이드에 회사명 배너를 추가합니다.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // 기본 마스터 슬라이드를 복제합니다.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // 마스터 슬라이드 상단에 회사명 배너를 추가합니다.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // 새 마스터 슬라이드를 레이아웃 슬라이드에 할당합니다.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // 레이아웃 슬라이드를 프레젠테이션의 첫 번째 슬라이드에 할당합니다.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** 마스터 슬라이드는 모든 슬라이드에 일관된 브랜딩 또는 공유 디자인 요소를 적용할 수 있는 방법을 제공합니다. 마스터에 변경을 가하면 해당 레이아웃 및 일반 슬라이드에 자동으로 반영됩니다.
> 💡 **Note 2:** 마스터 슬라이드에 추가된 모든 도형이나 서식은 레이아웃 슬라이드에 상속되고, 그 레이아웃을 사용하는 모든 일반 슬라이드에도 상속됩니다.  
> 아래 이미지에서는 마스터 슬라이드에 추가된 텍스트 상자가 최종 슬라이드에 자동으로 렌더링되는 방식을 보여줍니다.

![마스터 상속 예시](master-slide-banner.png)

## **마스터 슬라이드 액세스**

프레젠테이션 마스터 컬렉션을 사용하여 마스터 슬라이드에 액세스할 수 있습니다. 다음은 마스터 슬라이드를 가져오고 작업하는 방법입니다.

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // 배경 유형을 변경합니다.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **마스터 슬라이드 제거**

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // 인덱스로 마스터 슬라이드를 제거합니다.
        presentation.getMasters().removeAt(0);

        // 참조로 마스터 슬라이드를 제거합니다.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **사용되지 않는 마스터 슬라이드 제거**

일부 프레젠테이션에는 사용되지 않는 마스터 슬라이드가 포함되어 있습니다. 이러한 슬라이드를 제거하면 파일 크기를 줄이는 데 도움이 됩니다.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // 사용되지 않는 모든 마스터 슬라이드를 제거합니다 (보존으로 표시된 슬라이드도 포함).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```