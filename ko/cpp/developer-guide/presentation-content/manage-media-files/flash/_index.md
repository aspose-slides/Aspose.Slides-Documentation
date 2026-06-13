---
title: C++에서 프레젠테이션의 Flash 개체 추출
linktitle: Flash
type: docs
weight: 10
url: /ko/cpp/flash/
keywords:
- Flash 추출
- Flash 개체
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "C++용 Aspose.Slides를 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 Flash 개체를 추출하는 방법을 배우고, 완전한 코드 샘플과 모범 사례를 확인하세요."
---
## **Overview**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션에서 Flash 개체를 추출하는 방법을 설명합니다. 슬라이드의 컨트롤 컬렉션에서 이름으로 Flash 컨트롤을 찾고 임베드된 SWF 개체 데이터를 처리하는 방법을 보여줍니다.

## **Extract Flash Objects from Presentations**
C++용 Aspose.Slides는 프레젠테이션에서 Flash 개체를 추출하는 기능을 제공합니다. 이름으로 Flash 컨트롤에 액세스하고 프레젠테이션에서 해당 컨트롤을 추출하여 SWF 개체 데이터를 저장할 수 있습니다.

``` cpp
auto pres = System::MakeObject<Presentation>(u"withFlash.pptm");
auto controls = pres->get_Slides()->idx_get(0)->get_Controls();
System::SharedPtr<Control> flashControl;
for (const auto& control : controls)
{
    if (control->get_Name() == u"ShockwaveFlash1")
    {
        flashControl = System::ExplicitCast<Control>(control);
    }
}
```

## **FAQ**

**Flash 콘텐츠를 추출할 때 지원되는 프레젠테이션 형식은 무엇입니까?**

[Aspose.Slides supports](/slides/ko/cpp/supported-file-formats/) PPT와 PPTX와 같은 주요 PowerPoint 형식을 지원합니다. 이는 해당 컨테이너를 로드하고 컨트롤에 접근할 수 있기 때문이며, Flash 관련 ActiveX 요소도 포함됩니다.

**Flash가 포함된 프레젠테이션을 HTML5로 변환하면서 Flash 인터랙티브 기능을 유지할 수 있나요?**

아니오. Aspose.Slides는 SWF 콘텐츠를 실행하거나 인터랙티브 기능을 변환하지 않습니다. [HTML](/slides/ko/cpp/convert-powerpoint-to-html/)/[HTML5](/slides/ko/cpp/export-to-html5/) 로의 내보내기는 지원되지만, Flash는 지원 종료로 인해 최신 브라우저에서 재생되지 않습니다. 권장 방법은 내보내기 전에 Flash를 비디오 또는 HTML5 애니메이션과 같은 대체 요소로 교체하는 것입니다.

**보안 측면에서 Aspose.Slides가 프레젠테이션을 읽는 중에 SWF 파일을 실행합니까?**

아니오. Aspose.Slides는 Flash를 파일에 임베드된 바이너리 데이터로 처리하며, 처리 과정에서 SWF 콘텐츠를 실행하지 않습니다.

**OLE를 통해 임베드된 다른 파일과 함께 Flash가 포함된 프레젠테이션을 어떻게 처리해야 하나요?**

Aspose.Slides는 [extracting embedded OLE objects](/slides/ko/cpp/manage-ole/)를 지원하므로, Flash 컨트롤과 기타 OLE 임베드 문서를 함께 한 번에 처리하여 모든 관련 임베드 콘텐츠를 한 번에 처리할 수 있습니다.