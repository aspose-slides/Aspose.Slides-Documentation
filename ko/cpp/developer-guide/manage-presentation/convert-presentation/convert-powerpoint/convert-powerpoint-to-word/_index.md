---
title: C++에서 PowerPoint 프레젠테이션을 Word 문서로 변환
linktitle: PowerPoint를 Word로
type: docs
weight: 110
url: /ko/cpp/convert-powerpoint-to-word/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 Word로
- 프레젠테이션을 Word로
- 슬라이드를 Word로
- PPT를 Word로
- PPTX를 Word로
- PowerPoint를 DOCX로
- 프레젠테이션을 DOCX로
- 슬라이드를 DOCX로
- PPT를 DOCX로
- PPTX를 DOCX로
- PowerPoint를 DOC로
- 프레젠테이션을 DOC로
- 슬라이드를 DOC로
- PPT를 DOC로
- PPTX를 DOC로
- PPT를 DOCX로 저장
- PPTX를 DOCX로 저장
- PPT를 DOCX로 내보내기
- PPTX를 DOCX로 내보내기
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 PowerPoint PPT 및 PPTX 슬라이드를 편집 가능한 Word 문서로 변환하며 정확한 레이아웃, 이미지 및 서식이 유지됩니다."
---
## **소개**

프레젠테이션(PPT 또는 PPTX)의 텍스트 콘텐츠나 정보를 새로운 방식으로 사용하려는 경우, 프레젠테이션을 Word(DOC 또는 DOCX)로 변환하면 도움이 될 수 있습니다.

* Microsoft PowerPoint와 비교할 때, Microsoft Word 앱은 콘텐츠와 관련된 도구나 기능이 더 풍부합니다.
* Word의 편집 기능 외에도 향상된 협업, 인쇄 및 공유 기능을 활용할 수 있습니다.

{{% alert color="info" %}} 

슬라이드의 텍스트 콘텐츠를 활용했을 때 얻을 수 있는 이점을 확인하려면 저희의 [**Presentation to Word Online Converter**](https://products.aspose.app/slides/ko/conversion/ppt-to-word)를 사용해 보세요. 

{{% /alert %}} 

## **Aspose.Slides 및 Aspose.Words**

PowerPoint 파일(PPTX 또는 PPT)을 Word(DOCX 또는 DOC)로 변환하려면 [Aspose.Slides for C++](https://products.aspose.com/slides/ko/cpp/)와 [Aspose.Words for C++](https://products.aspose.com/words/cpp/) 두 가지가 모두 필요합니다.

독립형 API인 C++용 [Aspose.Slides](https://products.aspose.app/slides)는 프레젠테이션에서 텍스트를 추출할 수 있는 기능을 제공합니다.

[Aspose.Words](https://docs.aspose.com/words/cpp/)는 Microsoft Word를 사용하지 않고도 애플리케이션이 문서를 생성, 수정, 변환, 렌더링, 인쇄 및 기타 작업을 수행할 수 있는 고급 문서 처리 API입니다.

## **PowerPoint 프레젠테이션을 Word 문서로 변환**

PowerPoint를 Word로 변환하려면 아래 코드 스니펫을 사용하십시오:

```cpp
#include <Aspose.Words.Cpp/BreakType.h>
#include <Aspose.Words.Cpp/Document.h>
#include <Aspose.Words.Cpp/DocumentBuilder.h>
#include <DOM/AutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // 슬라이드 이미지를 바이트 배열 스트림으로 생성합니다
    auto image = slide->GetImage(1.0f, 1.0f);
    auto imageStream = MakeObject<System::IO::MemoryStream>();
    image->Save(imageStream, Aspose::Slides::ImageFormat::Png);
    image->Dispose();

    builder->InsertImage(imageStream->ToArray());

    // 슬라이드 텍스트를 삽입합니다
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}

doc->Save(u"output.docx");
presentation->Dispose();
```

## **FAQ**

### PowerPoint와 OpenDocument 프레젠테이션을 Word 문서로 변환하려면 어떤 구성 요소를 설치해야 하나요?

프로젝트에 [Aspose.Slides for C++](https://releases.aspose.com/slides/ko/cpp/)와 [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) 해당 패키지를 추가하기만 하면 됩니다. 두 라이브러리는 독립형 API로 동작하므로 Microsoft Office를 설치할 필요가 없습니다.

### 모든 PowerPoint 및 OpenDocument 프레젠테이션 형식을 지원하나요?

Aspose.Slides는 PPT, PPTX, ODP 및 기타 일반 파일 유형을 포함한 모든 프레젠테이션 형식([지원되는 파일 형식](/slides/ko/cpp/supported-file-formats/))을 지원합니다. 이를 통해 다양한 버전의 Microsoft PowerPoint로 만든 프레젠테이션을 작업할 수 있습니다.