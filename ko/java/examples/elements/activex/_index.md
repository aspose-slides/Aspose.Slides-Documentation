---
title: ActiveX
type: docs
weight: 200
url: /ko/java/examples/elements/activex/
keywords:
- 코드 예제
- ActiveX
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ActiveX 예제를 확인하십시오: PPT 및 PPTX 프레젠테이션에서 명확한 Java 코드로 ActiveX 객체를 삽입, 구성 및 제어합니다."
---
이 문서에서는 **Aspose.Slides for Java**를 사용하여 프레젠테이션에서 ActiveX 컨트롤을 추가, 액세스, 제거 및 구성하는 방법을 보여줍니다.

## **ActiveX 컨트롤 추가**

새 ActiveX 컨트롤을 삽입하고 선택적으로 해당 속성을 설정합니다.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 새 ActiveX 컨트롤을 추가합니다.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // 선택적으로 일부 속성을 설정합니다.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX 컨트롤 액세스**

슬라이드에 있는 첫 번째 ActiveX 컨트롤의 정보를 읽습니다.

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // 첫 번째 ActiveX 컨트롤에 접근합니다.
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX 컨트롤 제거**

슬라이드에서 기존 ActiveX 컨트롤을 삭제합니다.

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // 첫 번째 ActiveX 컨트롤을 제거합니다.
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX 속성 설정**

컨트롤을 추가하고 여러 ActiveX 속성을 구성합니다.

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Windows Media Player 컨트롤을 추가하고 속성을 구성합니다.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```