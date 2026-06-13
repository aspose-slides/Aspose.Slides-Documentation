---
title: 레이아웃 슬라이드
type: docs
weight: 20
url: /ko/java/examples/elements/layout-slide/
keywords:
- 코드 예제
- 레이아웃 슬라이드
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java의 마스터 레이아웃 슬라이드: PPT, PPTX 및 ODP 프레젠테이션을 위한 Java 예제로 슬라이드 레이아웃, 자리표시자 및 마스터를 선택, 적용 및 사용자 정의합니다."
---
이 문서에서는 Aspose.Slides for Java에서 **Layout Slides**를 사용하는 방법을 보여줍니다. 레이아웃 슬라이드는 일반 슬라이드가 상속받는 디자인과 서식을 정의합니다. 레이아웃 슬라이드를 추가, 액세스, 복제 및 제거할 수 있으며, 사용되지 않는 레이아웃을 정리하여 프레젠테이션 크기를 줄일 수 있습니다.

## **Add a Layout Slide**

재사용 가능한 서식을 정의하기 위해 사용자 지정 레이아웃 슬라이드를 만들 수 있습니다. 예를 들어, 이 레이아웃을 사용하는 모든 슬라이드에 표시되는 텍스트 상자를 추가할 수 있습니다.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // 빈 레이아웃 유형과 사용자 지정 이름으로 레이아웃 슬라이드를 생성합니다.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // 레이아웃 슬라이드에 텍스트 상자를 추가합니다.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // 이 레이아웃을 사용하여 두 개의 슬라이드를 추가합니다; 두 슬라이드 모두 레이아웃의 텍스트를 상속받습니다.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** 레이아웃 슬라이드는 개별 슬라이드의 템플릿 역할을 합니다. 공통 요소를 한 번 정의하면 여러 슬라이드에서 재사용할 수 있습니다.

> 💡 **Note 2:** 레이아웃 슬라이드에 도형이나 텍스트를 추가하면, 해당 레이아웃을 기반으로 하는 모든 슬라이드에 이 공유된 내용이 자동으로 표시됩니다.
> 아래 스크린샷은 동일한 레이아웃 슬라이드에서 텍스트 상자를 상속받은 두 개의 슬라이드를 보여줍니다.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Access a Layout Slide**

레이아웃 슬라이드는 인덱스나 레이아웃 유형(예: `Blank`, `Title`, `SectionHeader` 등)으로 액세스할 수 있습니다.

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // 인덱스로 레이아웃 슬라이드에 접근합니다.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // 유형으로 레이아웃 슬라이드에 접근합니다.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Layout Slide**

더 이상 필요하지 않은 경우 특정 레이아웃 슬라이드를 제거할 수 있습니다.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // 유형으로 레이아웃 슬라이드를 가져와서 제거합니다.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Remove Unused Layout Slides**

프레젠테이션 크기를 줄이기 위해, 일반 슬라이드에서 사용되지 않는 레이아웃 슬라이드를 제거할 수 있습니다.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // 자동으로 어떤 슬라이드에서도 참조되지 않은 모든 레이아웃 슬라이드를 제거합니다.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Clone a Layout Slide**

`addClone` 메서드를 사용하여 레이아웃 슬라이드를 복제할 수 있습니다.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // 유형으로 기존 레이아웃 슬라이드를 가져옵니다.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // 레이아웃 슬라이드 컬렉션 끝에 레이아웃 슬라이드를 복제합니다.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Summary:** 레이아웃 슬라이드는 슬라이드 전반에 걸쳐 일관된 서식을 관리하는 강력한 도구입니다. Aspose.Slides를 사용하면 레이아웃 슬라이드의 생성, 관리 및 최적화를 완벽하게 제어할 수 있습니다.