---
title: VBA 매크로
type: docs
weight: 150
url: /ko/cpp/examples/elements/vba-macro/
keywords:
- 코드 예제
- VBA
- 매크로
- PowerPoint
- OpenDocument
- 프리젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 프리젠테이션을 자동화합니다: 명확한 C++ 예제를 통해 PPT, PPTX 및 ODP에서 VBA 매크로를 생성, 실행, 가져오고 보호합니다."
---
이 문서는 **Aspose.Slides for C++**를 사용하여 VBA 매크로를 추가, 액세스 및 제거하는 방법을 보여줍니다.

## **VBA 매크로 추가**

VBA 프로젝트와 간단한 매크로 모듈이 포함된 프레젠테이션을 만듭니다.

```cpp
static void AddVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    presentation->Dispose();
}
```

## **VBA 매크로 액세스**

VBA 프로젝트에서 첫 번째 모듈을 가져옵니다.

```cpp
static void AccessVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    auto firstModule = presentation->get_VbaProject()->get_Module(0);

    presentation->Dispose();
}
```

## **VBA 매크로 제거**

VBA 프로젝트에서 모듈을 삭제합니다.

```cpp
static void RemoveVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    presentation->get_VbaProject()->get_Modules()->Remove(module);

    presentation->Dispose();
}
```