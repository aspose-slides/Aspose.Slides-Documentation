---
title: Python에서 PowerPoint 프레젠테이션을 SWF Flash로 변환
linktitle: PowerPoint에서 SWF Flash로
type: docs
weight: 80
url: /ko/python-net/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PowerPoint에서 SWF로
- 프레젠테이션에서 SWF로
- 슬라이드에서 SWF로
- PPT에서 SWF로
- PPTX에서 SWF로
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 PowerPoint(PPT/PPTX)를 SWF Flash로 변환합니다. 단계별 코드 샘플, 빠른 고품질 출력, PowerPoint 자동화 없이."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 SWF로 변환하는 방법을 설명합니다. 프레젠테이션을 [Presentation.save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/save/) 메서드로 SWF 파일로 저장하고, [SwfOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/swfoptions/)를 사용하여 내보내기를 구성하는 방법을 보여줍니다. 여기에는 뷰어 설정 및 노트 또는 댓글 레이아웃이 포함됩니다.

## **프레젠테이션을 Flash로 변환**

[save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/save/) 메서드는 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스에서 제공되며 전체 프레젠테이션을 SWF 문서로 변환하는 데 사용할 수 있습니다. 또한 [SWFOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/swfoptions/) 클래스와 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/notescommentslayoutingoptions/) 클래스를 사용하여 생성된 SWF에 댓글을 포함시킬 수 있습니다. 다음 예제는 SWFOptions 클래스에서 제공하는 옵션을 사용하여 프레젠테이션을 SWF 문서로 변환하는 방법을 보여줍니다.

```py
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# 프레젠테이션 및 노트 페이지 저장
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```

## **FAQ**

**SWF에 숨겨진 슬라이드를 포함할 수 있나요?**

예. [SwfOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/swfoptions/)에서 [show_hidden_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) 옵션을 활성화하십시오. 기본적으로 숨겨진 슬라이드는 내보내지 않습니다.

**압축 및 최종 SWF 크기를 어떻게 제어할 수 있나요?**

기본적으로 활성화된 [compressed](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/swfoptions/compressed/) 플래그를 사용하고, 파일 크기와 이미지 품질의 균형을 맞추기 위해 [jpeg_quality](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/swfoptions/jpeg_quality/)를 조정하십시오.

**'viewer_included'는 무엇을 위한 것이며 언제 비활성화해야 합니까?**

[viewer_included](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/swfoptions/viewer_included/)는 임베디드 플레이어 UI(내비게이션 컨트롤, 패널, 검색)를 추가합니다. 자체 플레이어를 사용하거나 UI 없이 순수한 SWF 프레임이 필요할 경우 이를 비활성화하십시오.

**내보내기 머신에 원본 폰트가 없으면 어떻게 되나요?**

Aspose.Slides는 [SwfOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/swfoptions/)의 [default_regular_font](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/swfoptions/default_regular_font/)를 통해 지정한 폰트를 대체하여 의도치 않은 폰트 대체가 발생하지 않도록 합니다.