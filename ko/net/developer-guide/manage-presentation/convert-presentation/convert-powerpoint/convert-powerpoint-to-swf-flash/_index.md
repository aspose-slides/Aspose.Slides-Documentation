---
title: PowerPoint 프레젠테이션을 .NET에서 SWF Flash로 변환
linktitle: PowerPoint를 SWF로
type: docs
weight: 80
url: /ko/net/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint에서 SWF로
- 프레젠테이션에서 SWF로
- 슬라이드에서 SWF로
- PPT에서 SWF로
- PPTX에서 SWF로
- PowerPoint에서 Flash로
- 프레젠테이션에서 Flash로
- 슬라이드에서 Flash로
- PPT에서 Flash로
- PPTX에서 Flash로
- PPT를 SWF로 저장
- PPTX를 SWF로 저장
- PPT를 SWF로 내보내기
- PPTX를 SWF로 내보내기
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides를 사용하여 .NET에서 PowerPoint (PPT/PPTX)를 SWF Flash로 변환합니다. 단계별 C# 코드 샘플, 빠른 고품질 출력, PowerPoint 자동화 없이."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 SWF로 변환하는 방법을 설명합니다. Presentation.Save 메서드를 사용하여 프레젠테이션을 SWF 파일로 저장하는 방법과 SwfOptions를 사용해 내보내기를 구성하는 방법을 보여주며, 여기에는 뷰어 설정 및 메모 또는 주석 레이아웃이 포함됩니다.

## **프레젠테이션을 Flash로 변환**

[Presentation] 클래스가 제공하는[Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/methods/save/index) 메서드를 사용하면 전체 프레젠테이션을 SWF 문서로 변환할 수 있습니다. 또한 [SWFOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/swfoptions) 클래스와 [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/inotescommentslayoutingoptions) 인터페이스를 사용하여 생성된 SWF에 주석을 포함시킬 수 있습니다. 다음 예제는 SWFOptions 클래스에서 제공하는 옵션을 사용하여 프레젠테이션을 SWF 문서로 변환하는 방법을 보여줍니다.

```c#
 // 프레젠테이션 파일을 나타내는 Presentation 객체를 생성합니다
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // 프레젠테이션 및 노트 페이지 저장
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```

## **FAQ**

**SWF에 숨겨진 슬라이드를 포함시킬 수 있나요?**

예. SwfOptions에서 [ShowHiddenSlides](https://reference.aspose.com/slides/ko/net/aspose.slides.export/swfoptions/showhiddenslides/) 옵션을 활성화하십시오. 기본적으로 숨겨진 슬라이드는 내보내지 않습니다.

**압축 및 최종 SWF 크기를 어떻게 제어할 수 있나요?**

[Compressed](https://reference.aspose.com/slides/ko/net/aspose.slides.export/swfoptions/compressed/) 플래그(기본적으로 활성화됨)를 사용하고 [JpegQuality](https://reference.aspose.com/slides/ko/net/aspose.slides.export/swfoptions/jpegquality/)를 조정하여 파일 크기와 이미지 품질 사이의 균형을 맞춥니다.

**'ViewerIncluded'는 무엇을 위한 것이며, 언제 비활성화해야 하나요?**

[ViewerIncluded](https://reference.aspose.com/slides/ko/net/aspose.slides.export/swfoptions/viewerincluded/)는 임베드된 플레이어 UI(네비게이션 컨트롤, 패널, 검색)를 추가합니다. 자체 플레이어를 사용하거나 UI 없이 순수한 SWF 프레임만 필요할 경우 이를 비활성화하십시오.

**내보내기 머신에 원본 글꼴이 없으면 어떻게 되나요?**

Aspose.Slides는 SwfOptions의 [DefaultRegularFont](https://reference.aspose.com/slides/ko/net/aspose.slides.export/saveoptions/defaultregularfont/)를 통해 지정한 글꼴을 대체하여 예상치 못한 대체가 발생하지 않도록 합니다.