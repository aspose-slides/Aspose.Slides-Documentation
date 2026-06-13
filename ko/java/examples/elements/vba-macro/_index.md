---
title: VBA 매크로
type: docs
weight: 150
url: /ko/java/examples/elements/vba-macro/
keywords:
- 코드 예제
- VBA
- 매크로
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 프레젠테이션을 자동화합니다: 명확한 Java 예제를 통해 PPT, PPTX 및 ODP에서 VBA 매크로를 생성, 실행, 가져오기 및 보호합니다."
---
이 문서는 **Aspose.Slides for Java**를 사용하여 VBA 매크로를 추가, 액세스 및 제거하는 방법을 보여줍니다.

## **VBA 매크로 추가**

VBA 프로젝트와 간단한 매크로 모듈을 포함한 프레젠테이션을 만듭니다.

```java
static void addVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");
    } finally {
        presentation.dispose();
    }
}
```

## **VBA 매크로 액세스**

VBA 프로젝트에서 첫 번째 모듈을 가져옵니다.

```java
static void accessVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        IVbaModule firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **VBA 매크로 제거**

VBA 프로젝트에서 모듈을 삭제합니다.

```java
static void removeVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.getVbaProject().getModules().remove(module);
    } finally {
        presentation.dispose();
    }
}
```