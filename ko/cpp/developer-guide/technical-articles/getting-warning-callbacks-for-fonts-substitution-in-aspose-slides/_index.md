---
title: 폰트 대체에 대한 경고 콜백 가져오기
type: docs
weight: 70
url: /ko/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 경고 콜백
- 폰트 대체
- 렌더링 프로세스
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: Aspose.Slides for C++에서 폰트 대체에 대한 경고 콜백을 가져오는 방법을 배우고 PowerPoint 및 OpenDocument 프레젠테이션을 정확하게 표시합니다.
---
## **소개**

Aspose.Slides for C++는 렌더링 중에 필요한 폰트가 머신에 없을 때 폰트 대체에 대한 경고 콜백을 받을 수 있게 합니다. 이러한 콜백은 누락되거나 접근할 수 없는 폰트 문제를 진단하는 데 도움이 됩니다.

## **경고 콜백 활성화**

Aspose.Slides for C++는 프레젠테이션 슬라이드를 렌더링할 때 경고 콜백을 받을 수 있는 간단한 API를 제공합니다. 다음 단계에 따라 경고 콜백을 구성하십시오:

1. 경고를 처리하기 위해 [IWarningCallback](https://reference.aspose.com/slides/ko/cpp/aspose.slides.warnings/iwarningcallback/) 인터페이스를 구현하는 사용자 정의 콜백 클래스를 생성합니다.
2. [RenderingOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/htmloptions/) 등과 같은 옵션 클래스를 사용하여 경고 콜백을 설정합니다.
3. 대상 머신에 없는 폰트를 사용하는 프레젠테이션을 로드합니다.
4. 슬라이드 썸네일을 생성하거나 프레젠테이션을 내보내어 효과를 확인합니다.

**사용자 정의 경고 콜백 클래스:**

```cpp
#include <Warnings/IWarningCallback.h>

class FontWarningHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontWarningHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss)
    {
        Console::WriteLine(warning->get_Description());
    }

    return ReturnAction::Continue;
}

// 예제 출력:
//
// Font will be substituted from XYZ to {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**슬라이드 썸네일 생성:**

```cpp
// 슬라이드 렌더링 중 폰트 관련 경고를 처리하기 위해 경고 콜백을 설정합니다.
auto options = MakeObject<RenderingOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// 지정된 파일 경로에서 프레젠테이션을 로드합니다.
auto presentation = MakeObject<Presentation>(u"sample.pptx");
    
// 프레젠테이션의 각 슬라이드에 대한 썸네일 이미지를 생성합니다.
for(auto&& slide : presentation->get_Slides())
{
    // 지정된 렌더링 옵션을 사용하여 슬라이드 썸네일 이미지를 가져옵니다.
    auto image = slide->GetImage(options);
    // ...

    image->Dispose();
}

presentation->Dispose();
```

**PDF 형식으로 내보내기:**

```cpp
// PDF 내보내기 중 폰트 관련 경고를 처리하기 위해 경고 콜백을 설정합니다.
auto options = MakeObject<PdfOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// 지정된 파일 경로에서 프레젠테이션을 로드합니다.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 프레젠테이션을 PDF로 내보냅니다.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Pdf, options);
// ...

stream->Dispose();
presentation->Dispose();
```

**HTML 형식으로 내보내기:**

```cpp
// HTML 내보내기 중 폰트 관련 경고를 처리하기 위해 경고 콜백을 설정합니다.
auto options = MakeObject<HtmlOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// 지정된 파일 경로에서 프레젠테이션을 로드합니다.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 프레젠테이션을 HTML 형식으로 내보냅니다.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Html, options);
// ...

stream->Dispose();
presentation->Dispose();
```