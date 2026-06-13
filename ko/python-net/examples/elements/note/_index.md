---
title: 노트
type: docs
weight: 240
url: /ko/python-net/examples/elements/note/
keywords:
- 노트
- 노트 슬라이드 추가
- 노트 슬라이드 접근
- 노트 슬라이드 제거
- 노트 텍스트 업데이트
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python에서 Aspose.Slides를 사용하여 발표자 노트를 추가, 읽기, 편집 및 내보냅니다: 텍스트 서식 지정, 슬라이드별 노트 관리, PowerPoint와 OpenDocument에서 가시성 제어."
---
Aspose.Slides for Python via .NET를 사용하여 노트 슬라이드를 추가, 읽기, 제거 및 업데이트하는 방법을 보여줍니다.

## **노트 슬라이드 추가**

노트 슬라이드를 생성하고 텍스트를 할당합니다.

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **노트 슬라이드 접근**

기존 노트 슬라이드에서 텍스트를 읽습니다.

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **노트 슬라이드 제거**

슬라이드와 연결된 노트 슬라이드를 제거합니다.

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # 노트 슬라이드를 제거합니다.
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **노트 텍스트 업데이트**

노트 슬라이드의 텍스트를 변경합니다.

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # 노트 텍스트를 업데이트합니다.
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```