---
title: Python으로 프레젠테이션 효율적으로 병합
linktitle: 프레젠테이션 병합
type: docs
weight: 40
url: /ko/python-net/merge-presentation/
keywords:
- PowerPoint 병합
- 프레젠테이션 병합
- 슬라이드 병합
- PPT 병합
- PPTX 병합
- ODP 병합
- PowerPoint 결합
- 프레젠테이션 결합
- 슬라이드 결합
- PPT 결합
- PPTX 결합
- ODP 결합
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 통해 .NET에서 PowerPoint(PPT, PPTX) 및 OpenDocument(ODP) 프레젠테이션을 손쉽게 병합하여 작업 흐름을 간소화합니다."
---
## **Overview**

Aspose.Slides는 한 프레젠테이션의 슬라이드를 복제하여 다른 프레젠테이션에 병합할 수 있습니다. 이 문서에서는 전체 프레젠테이션 또는 선택된 슬라이드를 병합하는 방법, 병합 중에 슬라이드 마스터 또는 특정 레이아웃을 사용하는 방법, 서로 다른 슬라이드 크기를 가진 프레젠테이션을 처리하는 방법, 병합된 슬라이드를 프레젠테이션 섹션에 추가하는 방법을 설명합니다. 또한 병합된 내용과 관련된 실용적인 참고 사항(예: 발표자 노트, 댓글, 비밀번호로 보호된 소스 파일, 스레드 사용)도 다룹니다.

## **Optimize Your Presentation Merging**

[Aspose.Slides for Python](https://products.aspose.com/slides/ko/python-net/)을 사용하면 스타일, 레이아웃 및 모든 요소를 보존하면서 PowerPoint 프레젠테이션을 원활하게 결합할 수 있습니다. 다른 도구와 달리 Aspose.Slides는 품질이나 데이터를 손실하지 않고 프레젠테이션을 병합합니다. 전체 프레젠테이션, 특정 슬라이드 또는 서로 다른 파일 형식(PPT에서 PPTX 등)도 병합할 수 있습니다.

### **Merging Features**

- **Full Presentation Merge:** 모든 슬라이드를 하나의 파일로 조합합니다.
- **Specific Slide Merge:** 선택한 슬라이드를 선택하여 결합합니다.
- **Cross-Format Merge:** 다양한 형식의 프레젠테이션을 통합하면서 무결성을 유지합니다.

## **Presentation Merging**

한 프레젠테이션을 다른 프레젠테이션에 병합하면 슬라이드를 하나의 프레젠테이션으로 결합하여 하나의 파일을 만들게 됩니다. 대부분의 프레젠테이션 프로그램(예: PowerPoint 또는 OpenOffice)에서는 이러한 방식으로 프레젠테이션을 병합하는 기능을 제공하지 않습니다.

하지만 [Aspose.Slides for Python](https://products.aspose.com/slides/ko/python-net/)을 사용하면 여러 방법으로 프레젠테이션을 병합할 수 있습니다. 도형, 스타일, 텍스트, 서식, 댓글 및 애니메이션을 모두 포함한 프레젠테이션을 손실 없이 병합할 수 있습니다.

**See also**

[Clone PowerPoint Slides in Python](/slides/ko/python-net/clone-slides/)

### **What Can Be Merged**

Aspose.Slides를 사용하면 다음을 병합할 수 있습니다.

- 전체 프레젠테이션: 소스 덱의 모든 슬라이드를 하나의 프레젠테이션으로 결합합니다.
- 특정 슬라이드: 선택한 슬라이드만 하나의 프레젠테이션으로 결합합니다.
- 동일한 형식의 프레젠테이션(e.g., PPT→PPT, PPTX→PPTX) 또는 서로 다른 형식 간(e.g., PPT→PPTX, PPTX→ODP) 병합.

### **Merging Options**

다음 중 하나를 선택하여 제어할 수 있습니다.
- 출력 프레젠테이션의 각 슬라이드가 원래 스타일을 유지하도록 할지, 혹은
- 모든 슬라이드에 동일한 스타일을 적용할지.

프레젠테이션을 병합하려면 Aspose.Slides가 제공하는 [add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_clone/) 메서드를 [SlideCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/) 클래스에서 사용할 수 있습니다. 이러한 메서드 오버로드는 병합 방식을 정의합니다. 모든 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 객체는 [slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/slides/ko/) 컬렉션을 노출하므로 대상 프레젠테이션의 슬라이드 컬렉션에서 `add_clone`을 호출합니다.

`add_clone` 메서드는 `Slide`—소스 슬라이드의 복제본을 반환합니다. 출력 프레젠테이션의 슬라이드는 원본의 복사본이므로, 결과 슬라이드를(예: 스타일, 서식 또는 레이아웃 적용) 수정해도 소스 프레젠테이션에 영향을 주지 않습니다.

## **Merge Presentations** 

Aspose.Slides는 [add_clone(ISlide)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide) 메서드를 제공하여 레이아웃과 스타일을 보존하면서 슬라이드를 결합할 수 있습니다(기본 매개변수 사용).

다음 Python 예제는 프레젠테이션을 병합하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Merge Presentations with a Slide Master**

Aspose.Slides는 [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) 메서드를 제공하여 템플릿의 슬라이드 마스터를 적용하면서 슬라이드를 병합할 수 있습니다. 이를 통해 필요시 출력 프레젠테이션의 슬라이드를 다시 스타일링할 수 있습니다.

다음 Python 예제는 이 작업을 시연합니다:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="Note" color="warning" %}}
지정된 슬라이드 마스터 아래에 적절한 레이아웃이 자동으로 결정됩니다. 적합한 레이아웃을 찾을 수 없고 `add_clone` 메서드의 `allow_clone_missing_layout` Boolean 매개변수가 `True`로 설정된 경우, 소스 슬라이드의 레이아웃이 대신 사용됩니다. 그렇지 않으면 [PptxEditException](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pptxeditexception/)이 발생합니다.
{{% /alert %}}

출력 프레젠테이션의 슬라이드에 다른 슬라이드 레이아웃을 적용하려면 병합 시 [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) 메서드를 사용하십시오.

## **Merge Specific Slides From Presentations**

여러 프레젠테이션에서 특정 슬라이드를 병합하면 맞춤형 슬라이드 덱을 만들 때 유용합니다. Aspose.Slides를 사용하면 원하는 슬라이드만 선택·가져와 원본 슬라이드의 서식, 레이아웃 및 디자인을 그대로 유지할 수 있습니다.

다음 Python 예제는 새 프레젠테이션을 만들고 두 개의 다른 프레젠테이션에서 제목 슬라이드를 추가한 뒤 결과를 파일로 저장합니다:

```py
def get_title_slide(pres):
    for slide in pres.slides:
        if slide.layout_slide.layout_type == slides.SlideLayoutType.TITLE:
            return slide
    return None


with slides.Presentation() as presentation, \
        slides.Presentation("presentation1.pptx") as presentation1, \
        slides.Presentation("presentation2.pptx") as presentation2:
    presentation.slides.remove_at(0)

    slide1 = get_title_slide(presentation1)
    if slide1 is not None:
        presentation.slides.add_clone(slide1)

    slide2 = get_title_slide(presentation2)
    if slide2 is not None:
        presentation.slides.add_clone(slide2)

    presentation.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Merge Presentations with a Slide Layout**

다음 Python 예제는 여러 프레젠테이션의 슬라이드를 특정 슬라이드 레이아웃을 적용하면서 병합하여 단일 출력 프레젠테이션을 만드는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **Merge Presentations with Different Slide Sizes**

{{% alert title="Note" color="warning" %}}
슬라이드 크기가 다른 프레젠테이션은 직접 병합할 수 없습니다.
{{% /alert %}}

다른 슬라이드 크기를 가진 두 프레젠테이션을 병합하려면 먼저 한 프레젠테이션의 슬라이드 크기를 다른 프레젠테이션에 맞게 조정합니다.

다음 샘플 코드는 이 과정을 시연합니다:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    slide_size = presentation1.slide_size.size
    with slides.Presentation("presentation2.pptx") as presentation2:
        presentation2.slide_size.set_size(slide_size.width, slide_size.height, slides.SlideSizeScaleType.ENSURE_FIT)
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined_size.pptx", slides.export.SaveFormat.PPTX) 
```

## **Merge Slides into a Presentation Section**

다음 Python 예제는 특정 슬라이드를 프레젠테이션 섹션에 병합하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.sections[0])
        presentation1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

슬라이드는 섹션의 끝에 추가됩니다. 

{{% alert title="Tip" color="primary" %}}
빠르고 **무료 온라인 도구**로 **PowerPoint 프레젠테이션을 병합**하고 싶으신가요? [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/ko/merger)를 사용해 보세요.

- **PowerPoint 파일을 쉽게 병합**: 여러 **PPT, PPTX, ODP** 프레젠테이션을 하나의 파일로 결합합니다.  
- **다양한 형식 지원**: **PPT를 PPTX**로, **PPTX를 ODP**로 등 다양한 형식 병합이 가능합니다.  
- **설치 필요 없음**: 브라우저에서 직접 실행되며 빠르고 안전합니다.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/ko/merger)  

오늘 바로 **Aspose 무료 온라인 도구**로 PowerPoint 파일을 병합해 보세요!  
{{% /alert %}}

{{% alert title="Tip" color="primary" %}}
Aspose는 [무료 Collage 웹 앱](https://products.aspose.app/slides/ko/collage)을 제공합니다. 이 온라인 서비스를 사용하면 [JPG를 JPG](https://products.aspose.app/slides/ko/collage/jpg) 또는 PNG를 PNG 이미지로 병합하고, [사진 그리드](https://products.aspose.app/slides/ko/collage/photo-grid)를 만들 수 있습니다. 
{{% /alert %}}

## **FAQ**

**Are speaker notes preserved during merge?**

예. 슬라이드를 복제할 때 Aspose.Slides는 노트, 서식 및 애니메이션을 포함한 모든 슬라이드 요소를 그대로 전달합니다.

**Are comments and their authors transferred?**

댓글은 슬라이드 내용의 일부로 복사되며, 댓글 작성자 라벨도 결과 프레젠테이션의 댓글 객체에 보존됩니다.

**What if the source presentation is password-protected?**

[source presentation](/slides/ko/python-net/password-protected-presentation/)를 [LoadOptions.password](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/password/)를 사용해 열어야 합니다. 로드 후 해당 슬라이드를 보호되지 않은 대상 파일(또는 보호된 파일)로 안전하게 복제할 수 있습니다.

**How thread-safe is the merge operation?**

같은 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스를 [여러 스레드](/slides/ko/python-net/multithreading/)에서 사용하지 마세요. 권장 규칙은 "하나의 문서 — 하나의 스레드"이며, 서로 다른 파일은 별도의 스레드에서 병렬 처리할 수 있습니다.