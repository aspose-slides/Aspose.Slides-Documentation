---
title: PowerPoint 애드인을 사용하여 OLE 객체 자동 업데이트
type: docs
weight: 10
url: /ko/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE 객체
- OLE 업데이트
- 자동으로
- 애드인
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "PowerPoint에서 애드인과 Aspose.Slides for .NET을 사용하여 OLE 차트와 객체를 자동 업데이트하는 방법을 알아보고, 실용적인 코드와 최적화 팁을 제공합니다."
---
## **소개**

Aspose.Slides for .NET 고객이 가장 자주 묻는 질문 중 하나는 프레젠테이션을 열 때 자동으로 업데이트되는 편집 가능한 차트(또는 기타 OLE 객체)를 어떻게 만들거나 수정할 수 있는가입니다. 안타깝게도 PowerPoint는 Excel 및 Word와 같은 방식으로 자동 매크로를 지원하지 않습니다. 사용할 수 있는 매크로는 `Auto_Open`과 `Auto_Close`뿐이며, 이들은 애드인에서만 자동으로 실행됩니다. 이 짧은 기술 팁에서는 이를 구현하는 방법을 보여줍니다.

## **OLE 객체 자동 업데이트**

먼저, PowerPoint에 Auto_Open 매크로 기능을 추가하는 무료 애드인 여러 개가 제공됩니다. 예를 들어 [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) 및 [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html)이 있습니다.

이러한 애드인 중 하나를 설치한 후, 아래와 같이 템플릿 프레젠테이션에 `Auto_Open()` 매크로(또는 Event Generator를 사용하는 경우 `OnPresentationOpen()`)를 추가하십시오:

```cs
public void Auto_Open()
{
    // 프레젠테이션의 각 슬라이드를 순회합니다.
    foreach (var oSlide in ActivePresentation.Slides)
    {
        // 현재 슬라이드의 모든 도형을 순회합니다.
        foreach (var oShape in oSlide.Shapes)
        {
            // 도형이 OLE 객체인지 확인합니다.
            if (oShape.Type == msoEmbeddedOLEObject)
            {
                // OLE 객체를 찾았습니다. 객체 참조를 얻고 업데이트합니다.
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // 이제 OLE 서버 프로그램을 종료합니다.
                // 메모리를 해제하고 문제를 방지합니다.
                // 또한 oObject를 Nothing으로 설정하여 객체를 해제합니다.
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```

Aspose.Slides for .NET로 만든 OLE 객체에 대한 모든 변경 사항은 PowerPoint가 프레젠테이션을 열 때 자동으로 업데이트됩니다. OLE 객체가 많이 있고 모두 업데이트하고 싶지 않은 경우, 처리해야 할 도형에 사용자 정의 태그를 추가하고 매크로에서 해당 태그를 확인하면 됩니다.