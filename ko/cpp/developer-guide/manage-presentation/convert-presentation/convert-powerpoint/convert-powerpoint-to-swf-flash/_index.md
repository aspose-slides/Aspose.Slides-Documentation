---
title: C++에서 PowerPoint 프레젠테이션을 SWF Flash로 변환
linktitle: PowerPoint를 SWF로
type: docs
weight: 80
url: /ko/cpp/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 SWF로
- 프레젠테이션을 SWF로
- 슬라이드를 SWF로
- PPT를 SWF로
- PPTX를 SWF로
- PowerPoint를 Flash로
- 프레젠테이션을 Flash로
- 슬라이드를 Flash로
- PPT를 Flash로
- PPTX를 Flash로
- PPT를 SWF로 저장
- PPTX를 SWF로 저장
- PPT를 SWF로 내보내기
- PPTX를 SWF로 내보내기
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 PowerPoint (PPT/PPTX)를 SWF Flash로 변환합니다. 단계별 코드 샘플, 빠른 고품질 출력, PowerPoint 자동화 없음."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 SWF로 변환하는 방법을 설명합니다. [Presentation::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/) 메서드로 프레젠테이션을 SWF 파일로 저장하는 방법과 [SwfOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/swfoptions/)를 사용하여 내보내기를 구성하는 방법(뷰어 설정 및 메모 또는 댓글 레이아웃 포함)을 보여줍니다.

## **프레젠테이션을 Flash로 변환**

[Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스에서 노출되는 [Save](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) 메서드를 사용하면 전체 프레젠테이션을 SWF 문서로 변환할 수 있습니다. 또한 [SWFOptions](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.swf_options) 클래스와 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/notescommentslayoutingoptions/) 클래스를 사용하여 생성된 SWF에 댓글을 포함시킬 수 있습니다. 다음 예제는 SWFOptions 클래스에서 제공하는 옵션을 사용하여 프레젠테이션을 SWF 문서로 변환하는 방법을 보여줍니다.

``` cpp
// 문서 디렉터리 경로.
    System::String dataDir = GetDataPath();

    // 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // 프레젠테이션 및 노트 페이지 저장
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```

## **FAQ**

**SWF에 숨겨진 슬라이드를 포함할 수 있나요?**

예. [SwfOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/swfoptions/)의 [set_ShowHiddenSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) 메서드를 사용하세요. 기본값으로 숨겨진 슬라이드는 내보내지 않습니다.

**압축과 최종 SWF 파일 크기를 어떻게 제어할 수 있나요?**

[set_Compressed](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/swfoptions/set_compressed/) 메서드를 사용하고 [JPEG quality](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/swfoptions/set_jpegquality/)를 조정하여 파일 크기와 이미지 품질의 균형을 맞추세요.

**'set_ViewerIncluded'는 무엇이며 언제 사용해야 하나요?**

[set_ViewerIncluded](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/swfoptions/set_viewerincluded/)는 임베디드 플레이어 UI(네비게이션 컨트롤, 패널, 검색)를 추가합니다. 자체 플레이어를 사용하거나 UI 없이 순수한 SWF 프레임이 필요하면 이 옵션을 비활성화하세요.

**내보내기 머신에 원본 폰트가 없으면 어떻게 되나요?**

Aspose.Slides는 [SwfOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/swfoptions/)의 [set_DefaultRegularFont](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/)으로 지정한 폰트를 사용해 의도치 않은 폰트 대체를 방지합니다.