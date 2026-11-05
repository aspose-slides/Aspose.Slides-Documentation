---
title: Python에서 노트 페이지 크기 및 방향 변경
linktitle: 노트 페이지 크기
type: docs
weight: 10
url: /ko/python-net/notes-size/
keywords:
- 노트 페이지 크기
- 노트 방향
- 가로 방향 노트
- 세로 방향 노트
- 핸드아웃 크기
- PowerPoint
- 프레젠테이션
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Aspose.Slides for Python(.NET)를 사용하여 노트 페이지 크기를 읽고 변경하며, 방향을 전환하고, 저장된 크기를 확인하고, 노트 또는 핸드아웃을 PDF와 이미지로 내보냅니다."
---
## **개요**

Use [Presentation.notes_size](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/notes_size/) to access the presentation's notes page settings. It returns a [NotesSize](https://reference.aspose.com/slides/ko/python-net/aspose.slides/notessize/) object whose [size](https://reference.aspose.com/slides/ko/python-net/aspose.slides/notessize/size/) property is writable. Although the settings object itself is read-only, you can assign new dimensions to its size property.

Width and height are specified in **포인트**, with 72 points per inch. For example, 900 × 600 points is 12.5 × 8⅓ inches. These settings apply to the presentation, rather than to an individual slide's notes.

| Setting | Purpose |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/notes_size/) | 노트 페이지 치수와 핸드아웃 내보내기에 사용되는 페이지 치수를 제어합니다. |
| [Presentation.slide_size](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/slide_size/) | 일반 프레젠테이션 슬라이드 치수를 [SlideSize](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidesize/)를 통해 제어합니다. |

Changing either setting does not automatically change the other. Changing the notes page orientation also does not rotate the regular slides. See [Slide Size](/slides/ko/python-net/slide-size/) to resize regular slides.

The examples below use an existing `sample.pptx`. For the export examples, use a presentation with at least one slide containing speaker notes. Each example can be run independently.

## **노트 페이지 크기 및 방향 읽기**

Read the width and height and compare them to determine the orientation: a wider page is landscape, a taller page is portrait, and equal dimensions describe a square page. This example prints the actual dimensions in points, without assuming a standard paper size.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **용지 크기를 변경하지 않고 가로 방향으로 전환**

To change only the orientation, swap the existing width and height. This preserves the lengths of both sides, including those of a custom paper size. The condition below prevents an already-landscape page from being switched back to portrait and leaves a square page unchanged.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

For portrait orientation, use the same assignment when `size.width > size.height`. Do not substitute A4 or Letter dimensions unless you also want to change the paper size.

## **맞춤 노트 페이지 크기 설정 및 확인**

Assign both dimensions together, then use [Presentation.save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/save/) to write the presentation. This example sets a 900 × 600-point landscape page, saves it as PPTX, and opens the saved file again to check the persisted values. The comparison allows a 0.01-point tolerance for floating-point values; it is not a guarantee of precision for every file format.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

The expected result is `900 x 600 points` and `Size preserved: True`. Checking a newly opened presentation verifies the saved file, rather than only the in-memory settings.

## **노트 및 핸드아웃 내보내기**

The page dimensions define the available area for notes or handout layouts. They do not enable those layouts by themselves: configure the export options as well. Regular slide export continues to use the slide dimensions.

### **노트를 PDF 및 PNG로 내보내기**

Assign [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/notescommentslayoutingoptions/) to [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/pdfoptions/slides_layout_options/) to include notes in the PDF. This example also renders the first slide with notes to PNG using [Slide.get_image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/get_image/) and [RenderingOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/renderingoptions/).

The [BOTTOM_TRUNCATED](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/notespositions/) mode keeps the notes on one page; notes that do not fit can be truncated. The PDF uses 900 × 600-point pages. At the image scale of 1 × 1 used below, the PNG is 900 × 600 pixels. Points describe the page geometry; pixels describe the raster output, whose dimensions also depend on the rendering scale.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

For PDF export with long notes, [BOTTOM_FULL](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/notespositions/) allows additional pages as needed. Do not use that mode with the single-slide image call above, which does not support it. After resizing, inspect the output for clipped notes and the placement of existing notes-master objects; changing page dimensions alone should not be treated as a guarantee that all content will fit. See [Convert PowerPoint to PDF with Notes](/slides/ko/python-net/convert-powerpoint-to-pdf-with-notes/) for more about notes export.

### **핸드아웃을 PDF로 내보내기**

Use [HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/handoutlayoutingoptions/) for multiple slide thumbnails on one page. The following example sets a 900 × 600-point page and uses [HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/handouttype/) to arrange up to four slides per page. The horizontal preset controls slide ordering; the page orientation comes from its width and height.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Changing the page size changes the area available for the handout grid without changing the source slides' dimensions. For handout images, use [Presentation.get_images](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/get_images/) with the handout layout, rather than an individual slide's image method. In Aspose.Slides, presentation-level handout rendering uses the notes page dimensions, while the individual slide image call does not produce the handout page. See [Handout Mode](/slides/ko/python-net/convert-powerpoint-in-handout-mode/) for layout options.

## **뷰어, 내보내기 및 인쇄 시 페이지 크기**

Keep the stored presentation size, the exported page size, and the printed paper size distinct:

- **Presentation viewers:** 뷰어는 자체 레이아웃 규칙을 사용해 노트를 표시하거나 인쇄할 수 있습니다. 다른 애플리케이션이 파일을 저장한 경우, 파일을 다시 열어 치수를 확인하세요; 해당 애플리케이션의 형식 변환이 치수를 표준화할 수 있습니다.
- **Export formats:** 위의 노트 및 핸드아웃 PDF 예제는 설정된 페이지 치수를 사용합니다. 래스터 이미지는 정수 픽셀 치수와 렌더링 스케일을 사용하므로, 소수점 포인트 값이 이미지 출력 시 반올림될 수 있습니다. 일반 슬라이드 내보내기는 노트 페이지 크기를 적용하지 않습니다.
- **Printer drivers:** 용지 선택, 자동 회전 및 페이지 맞춤 설정은 프레젠테이션이나 PDF에 저장된 치수를 변경하지 않고 실제 출력물을 바꿀 수 있습니다. 특정 용지 크기를 사용하려면 프린터 설정을 일치시키고 인쇄 미리보기를 확인하세요.

## **FAQ**

**한 슬라이드에만 노트 크기를 설정할 수 있나요?**

The notes page size is a presentation-level setting. Individual slides can have different notes content, but this property does not provide a separate page size for each slide.

**노트 방향을 변경했는데 슬라이드가 변하지 않는 이유는?**

Notes pages and regular slides have independent dimensions. Use the regular slide size settings when you want to resize the slides themselves.

**저장하거나 인쇄한 결과가 다른 크기를 갖는 이유는?**

First reopen the saved presentation and compare its notes dimensions. If those changed, check whether saving or converting the file in another application changed the page settings. If they did not, check the export layout, image scale, viewer settings, and printer paper selection.