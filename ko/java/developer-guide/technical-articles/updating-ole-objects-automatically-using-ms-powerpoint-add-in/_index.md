---
title: PowerPoint 추가 기능을 사용하여 OLE 개체 자동 업데이트
type: docs
weight: 10
url: /ko/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE 개체
- OLE 업데이트
- 자동으로
- 추가 기능
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "PowerPoint에서 추가 기능과 Aspose.Slides for Java를 사용하여 OLE 차트와 개체를 자동으로 업데이트하는 방법을 알아보고, 실용적인 코드와 최적화 팁을 제공합니다."
---
## **소개**

Aspose.Slides for Java 고객이 가장 자주 묻는 질문 중 하나는 프레젠테이션을 열 때 자동으로 업데이트되는 편집 가능한 차트(또는 기타 OLE 개체)를 어떻게 만들거나 수정할 수 있는가 하는 것입니다. 안타깝게도 PowerPoint는 Excel 및 Word와 같은 방식으로 자동 매크로를 지원하지 않습니다. 사용할 수 있는 매크로는 `Auto_Open`와 `Auto_Close`뿐이며, 이들은 추가 기능에서만 자동으로 실행됩니다. 이 짧은 기술 팁에서는 이를 구현하는 방법을 보여줍니다.

## **OLE 개체 자동 업데이트**

먼저, PowerPoint에 Auto_Open 매크로 기능을 추가하는 여러 무료 추가 기능이 있습니다. 예를 들어 [AutoEvents 추가 기능](http://skp.mvps.org/autoevents.htm)와 [이벤트 생성기](https://www.officeoneonline.com/eventgen/eventgen.html)가 있습니다.

이러한 추가 기능 중 하나를 설치한 후, 아래와 같이 템플릿 프레젠테이션에 `Auto_Open()` 매크로(또는 Event Generator를 사용하는 경우 `OnPresentationOpen()` 매크로)를 추가하면 됩니다:

```java
// 프레젠테이션의 각 슬라이드를 순회합니다.
for (var oSlide : ActivePresentation.Slides) {
    // 현재 슬라이드의 모든 도형을 순회합니다.
    for (var oShape : oSlide.Shapes) {
        // 도형이 OLE 개체인지 확인합니다.
        if ((oShape.Type == msoEmbeddedOLEObject)) {
            // OLE 개체를 찾았습니다. 객체 참조를 얻은 다음 업데이트합니다.
            oObject = oShape.OLEFormat.Object;
            oObject.Application.Update();
            // 이제 OLE 서버 프로그램을 종료합니다.
            // 이렇게 하면 메모리를 해제하고 문제를 방지합니다.
            // 또한 oObject를 Nothing으로 설정하여 객체를 해제합니다.
            oObject.Application.Quit();
            oObject = null;
        }
    }
}
```

Aspose.Slides for Java로 OLE 개체를 변경하면 PowerPoint가 프레젠테이션을 열 때 자동으로 업데이트됩니다. OLE 개체가 많이 있고 모두 업데이트하고 싶지 않은 경우, 처리해야 할 도형에 사용자 지정 태그를 추가하고 매크로에서 해당 태그를 확인하면 됩니다.