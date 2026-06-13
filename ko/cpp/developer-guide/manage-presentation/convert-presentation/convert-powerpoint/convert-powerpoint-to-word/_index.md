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
description: "Aspose.Slides를 사용하여 C++에서 PowerPoint PPT 및 PPTX 슬라이드를 편집 가능한 Word 문서로 변환하며 정확한 레이아웃, 이미지 및 서식을 보존합니다."
---
## **소개**

프레젠테이션(PPT 또는 PPTX)에서 텍스트 콘텐츠나 정보를 새로운 방식으로 활용하려는 경우, 프레젠테이션을 Word(DOC 또는 DOCX)로 변환하면 도움이 될 수 있습니다.

* Microsoft PowerPoint와 비교했을 때, Microsoft Word 앱은 콘텐츠를 위한 도구와 기능이 더 잘 갖추어져 있습니다.
* Word의 편집 기능 외에도 향상된 협업, 인쇄 및 공유 기능의 혜택을 누릴 수 있습니다.

{{% alert color="primary" %}} 
슬라이드의 텍스트 콘텐츠를 활용하여 얻을 수 있는 이점을 확인하려면 [**Presentation to Word Online Converter**](https://products.aspose.app/slides/ko/conversion/ppt-to-word)를 사용해 보세요. 
{{% /alert %}} 

## **Aspose.Slides 및 Aspose.Words**

PowerPoint 파일(PPTX 또는 PPT)을 Word(DOC 또는 DOCX)로 변환하려면 [Aspose.Slides for C++](https://products.aspose.com/slides/ko/cpp/)와 [Aspose.Words for C++](https://products.aspose.com/words/cpp/)가 모두 필요합니다.

독립형 API인 [Aspose.Slides](https://products.aspose.app/slides) for C++는 프레젠테이션에서 텍스트를 추출할 수 있는 기능을 제공합니다.

[Aspose.Words](https://docs.aspose.com/words/cpp/)는 Microsoft Word를 사용하지 않고도 응용 프로그램이 문서를 생성, 수정, 변환, 렌더링, 인쇄 및 기타 작업을 수행할 수 있게 하는 고급 문서 처리 API입니다.

## **PowerPoint 프레젠테이션을 Word 문서로 변환**

다음 코드 스니펫을 사용하여 PowerPoint를 Word로 변환합니다:

```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // 슬라이드 이미지를 생성하고 삽입합니다
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

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
```

## **FAQ**

**PowerPoint 및 OpenDocument 프레젠테이션을 Word 문서로 변환하려면 어떤 구성 요소를 설치해야 합니까?**

프로젝트에 [Aspose.Slides for C++](https://releases.aspose.com/slides/ko/cpp/)와 [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) 패키지를 추가하기만 하면 됩니다. 두 라이브러리 모두 독립형 API로 동작하므로 Microsoft Office를 설치할 필요가 없습니다.

**모든 PowerPoint 및 OpenDocument 프레젠테이션 형식을 지원합니까?**

Aspose.Slides는 PPT, PPTX, ODP 등 일반적인 파일 형식을 포함한 [모든 프레젠테이션 형식을 지원](/slides/ko/cpp/supported-file-formats/)합니다. 이를 통해 다양한 버전의 Microsoft PowerPoint로 만든 프레젠테이션을 작업할 수 있습니다.