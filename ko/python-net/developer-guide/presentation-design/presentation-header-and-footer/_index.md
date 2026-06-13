---
title: Python으로 프레젠테이션 헤더 및 바닥글 관리
linktitle: 헤더 및 바닥글
type: docs
weight: 140
url: /ko/python-net/presentation-header-and-footer/
keywords:
- 헤더
- 헤더 텍스트
- 바닥글
- 바닥글 텍스트
- 헤더 설정
- 바닥글 설정
- 유인물
- 노트
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 헤더와 바닥글을 추가하고 사용자 지정하여 전문적인 모양을 구현합니다."
---
## **개요**

Aspose.Slides for Python을 사용하면 프레젠테이션 전체에 걸쳐 헤더와 바닥글 자리 표시자를 정확한 범위로 제어할 수 있습니다. 바닥글 텍스트, 날짜/시간 및 슬라이드 번호는 마스터 수준에서 관리되며 전체에 적용하거나 슬라이드별로 조정할 수 있습니다. 헤더는 노트와 유인물에서 지원되며, 마스터 노트 슬라이드 또는 개별 노트 슬라이드의 전용 헤더 & 바닥글 관리자를 통해 가시성을 전환하고 헤더, 바닥글, 날짜/시간, 페이지 번호 텍스트를 설정할 수 있습니다. 이 문서에서는 이러한 자리 표시자를 업데이트하고 데크 전체에 일관되게 변경 사항을 전파하는 주요 패턴을 설명합니다.

## **헤더 및 바닥글 텍스트 관리**

이 섹션에서는 프레젠테이션에서 헤더와 바닥글 콘텐츠를 관리하는 방법—바닥글, 날짜 및 시간, 슬라이드 번호를 활성화하거나 수정하는 방법—을 배웁니다. 설정을 적용할 범위(프레젠테이션 전체, 개별 슬라이드, 노트/유인물 보기)를 간략히 설명하고 Aspose.Slides API를 사용해 이를 빠르고 일관되게 업데이트하는 방법을 보여줍니다.

아래 코드 예제는 프레젠테이션을 열고 바닥글 텍스트를 활성화 및 설정하고, 마스터 노트 슬라이드에서 헤더 텍스트를 업데이트한 다음 파일을 저장합니다.

```py
import aspose.slides as slides

# 헤더 텍스트를 설정하는 함수.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# 프레젠테이션을 로드합니다.
with slides.Presentation("sample.pptx") as presentation:
    # 바닥글을 설정합니다.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # 헤더에 접근하여 업데이트합니다.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # 프레젠테이션을 저장합니다.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **노트 슬라이드에서 헤더 및 바닥글 관리**

이 섹션에서는 Aspose.Slides에서 노트 슬라이드 전용 헤더와 바닥글을 관리하는 방법을 배웁니다. 관련 자리 표시자를 활성화하고, 바닥글, 날짜/시간 및 페이지 번호 텍스트를 설정하며, 이러한 변경 사항을 노트 마스터와 개별 노트 페이지에 일관되게 적용하는 방법을 다룹니다.

아래 단계를 따르세요:

1. 프레젠테이션 파일을 로드합니다.
2. 마스터 노트 슬라이드와 해당 [헤더 및 바닥글 관리자](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masternotesslideheaderfootermanager/)를 가져옵니다.
3. 마스터 노트 슬라이드에서 헤더, 바닥글, 슬라이드 번호 및 날짜‑시간의 가시성을 마스터와 모든 하위 노트 슬라이드에 대해 활성화합니다.
4. 마스터 노트 슬라이드에서 헤더, 바닥글 및 날짜‑시간 텍스트를 마스터와 모든 하위 노트 슬라이드에 대해 설정합니다.
5. 첫 번째 프레젠테이션 슬라이드에 대한 노트 슬라이드와 해당 [헤더 및 바닥글 관리자](https://reference.aspose.com/slides/ko/python-net/aspose.slides/notesslideheaderfootermanager/)를 가져옵니다.
6. 이 첫 번째 노트 슬라이드에 대해서만 헤더, 바닥글, 슬라이드 번호 및 날짜‑시간이 표시되도록 합니다(비활성인 경우 켭니다).
7. 이 첫 번째 노트 슬라이드에 대해서만 헤더, 바닥글 및 날짜‑시간 텍스트를 설정합니다.
8. 프레젠테이션을 PPTX 형식으로 저장합니다.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # 마스터 노트 슬라이드와 모든 자식 헤더, 바닥글, 슬라이드 번호, 날짜/시간 자리 표시자를 표시합니다.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # 마스터 노트 슬라이드와 모든 자식 헤더, 바닥글, 날짜/시간 자리 표시자에 텍스트를 설정합니다.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # 첫 번째 노트 슬라이드에만 헤더, 바닥글, 슬라이드 번호 및 날짜/시간 설정을 변경합니다.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # 헤더, 바닥글, 슬라이드 번호 및 날짜/시간 자리 표시자가 표시되도록 합니다.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # 노트 슬라이드 헤더, 바닥글 및 날짜/시간 자리 표시자에 텍스트를 설정합니다.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # 프레젠테이션을 저장합니다.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**일반 슬라이드에 “헤더”를 추가할 수 있나요?**

PowerPoint에서는 “헤더”가 노트와 유인물에만 존재합니다; 일반 슬라이드에서는 바닥글, 날짜/시간, 슬라이드 번호만 지원됩니다. Aspose.Slides도 동일한 제한을 따르며, 헤더는 노트/유인물에만 적용되고 슬라이드에서는 바닥글/날짜‑시간/슬라이드 번호만 사용할 수 있습니다.

**레이아웃에 바닥글 영역이 없는데 가시성을 “켜” 수 있나요?**

예. 헤더/바닥글 관리자를 통해 가시성을 확인하고 필요하면 활성화하십시오. 이러한 API 지시자와 메서드는 자리 표시자가 없거나 숨겨져 있는 경우에 대비하도록 설계되었습니다.

**슬라이드 번호를 1이 아닌 다른 값부터 시작하려면 어떻게 하나요?**

프레젠테이션의 [첫 슬라이드 번호](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/first_slide_number/)를 설정하면 됩니다; 이후 모든 번호 매김이 재계산됩니다. 예를 들어 0이나 10부터 시작하고 제목 슬라이드에서는 번호를 숨길 수 있습니다.

**PDF/이미지/HTML로 내보낼 때 헤더/바닥글은 어떻게 되나요?**

헤더와 바닥글은 프레젠테이션의 일반 텍스트 요소로 렌더링됩니다. 즉, 슬라이드나 노트 페이지에 해당 요소가 표시되어 있으면 출력 형식에서도 나머지 콘텐츠와 함께 나타납니다.