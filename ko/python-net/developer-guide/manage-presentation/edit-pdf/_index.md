---
title: Python에서 PDF 문서 편집
linktitle: PDF 편집
type: docs
weight: 65
url: /ko/python-net/edit-pdf/
keywords:
- PDF 편집
- PDF 텍스트 교체
- PDF를 PPTX로
- PPTX를 PDF로
- Python
- Aspose.Slides
description: "Python에서 Aspose.Slides에 PDF 문서를 가져와 텍스트를 교체하고, 수정된 프레젠테이션을 PDF로 다시 저장하여 PDF 문서를 편집합니다."
---
## **개요**

Aspose.Slides for Python via .NET를 사용하면 PDF 페이지를 슬라이드로 가져와 프레젠테이션을 수정하고 다시 PDF로 내보낼 수 있습니다. 이 기사에서는 간단한 텍스트 교체 예제를 보여줍니다. 프레젠테이션은 메모리에 유지되므로 중간 PPTX 파일을 저장하는 것은 선택 사항입니다.

## **PDF에서 텍스트 교체**

페이지를 가져오려면 [add_from_pdf](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_from_pdf/)를 사용하고, 텍스트를 업데이트하려면 [replace_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/replace_text/)를 사용하며, 결과를 내보내려면 [save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/save/)를 사용합니다.

다음 예제는 가져온 후 `input.pdf`에 편집 가능한 텍스트로 "Draft"라는 단어가 포함되어 있기를 기대합니다. 이 단어를 "Final"로 바꾸고 `edited.pdf`를 기록합니다. 가져오기 전에 초기 슬라이드를 비우면 출력에 빈 페이지가 추가되는 것을 방지할 수 있습니다. 검색은 동일한 대소문자를 가진 전체 단어와 일치합니다; `None`은 결과 콜백이 필요 없음을 의미합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

더 많은 옵션은 [Search and Replace Text](/slides/ko/python-net/search-and-replace-text/) 및 [Convert PowerPoint to PDF](/slides/ko/python-net/convert-powerpoint-to-pdf/)를 참조하십시오.

{{% alert color="info" title="Note" %}}

텍스트 교체는 스캔된 이미지 내부의 텍스트가 아니라 가져온 텍스트에 적용됩니다. 변환 과정에서 레이아웃 및 서식이 변경될 수 있으므로, 특히 교체할 텍스트가 원본보다 길 경우 출력 결과를 검토하십시오.

{{% /alert %}}

## **FAQ**

**PDF를 내보내기 전에 PPTX 파일을 저장해야 하나요?**

아니요. 메모리 내에서 동일한 프레젠테이션을 편집하고 내보낼 수 있습니다. PowerPoint에서 계속 편집하려면 PPTX 사본을 저장하면 됩니다; 자세한 내용은 [Save Presentations](/slides/ko/python-net/save-presentation/)를 참고하세요.

**일부 텍스트가 변경되지 않는 이유는 무엇인가요?**

예제는 정확한 대소문자를 가진 전체 단어 "Draft"와 일치하도록 설계되었습니다. 이미지로 가져오거나 별도의 텍스트 프레임으로 분리된 텍스트는 검색과 일치하지 않을 수 있습니다. 가져온 내용을 확인하고 문서에 맞게 검색을 조정하십시오.