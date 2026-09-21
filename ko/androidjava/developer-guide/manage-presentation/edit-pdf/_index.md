---
title: "Android에서 PDF 문서 편집"
linktitle: "PDF 편집"
type: docs
weight: 65
url: /ko/androidjava/edit-pdf/
keywords:
- "PDF 편집"
- "PDF 텍스트 교체"
- "PDF를 PPTX로"
- "PPTX를 PDF로"
- Android
- Java
- Aspose.Slides
description: "Android에서 Java를 사용하여 Aspose.Slides에 PDF를 가져와 텍스트를 교체하고 수정된 프레젠테이션을 다시 PDF로 저장하여 PDF 문서를 편집합니다."
---
## **Overview**

Aspose.Slides for Android via Java은 PDF 페이지를 슬라이드로 가져와 프레젠테이션을 수정하고 다시 PDF로 내보내어 PDF 콘텐츠를 편집할 수 있게 합니다. 이 문서에서는 간단한 텍스트 교체 방법을 보여줍니다. 프레젠테이션은 메모리 상에 유지되므로 중간 PPTX 파일을 저장하는 것은 선택 사항입니다.

## **Replace Text in a PDF**

페이지를 가져오려면 [addFromPdf](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-)을 사용하고, 텍스트를 업데이트하려면 [replaceText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)을 사용하며, 결과를 내보내려면 [save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)을 사용합니다.

다음 예제는 `input.pdf`에 가져온 후 편집 가능한 텍스트로 "Draft"라는 단어가 포함되어 있기를 기대합니다. 이 단어를 "Final"로 교체하고 `edited.pdf`에 저장합니다. 가져오기 전에 초기 슬라이드를 비우면 출력에 빈 슬라이드가 추가되는 것을 방지할 수 있습니다. 검색은 동일한 대소문자를 가진 전체 단어와 일치하며, `null`은 결과 콜백이 필요하지 않음을 의미합니다.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

자세한 옵션은 [Search and Replace Text](/slides/ko/androidjava/search-and-replace-text/) 및 [Convert PowerPoint to PDF](/slides/ko/androidjava/convert-powerpoint-to-pdf/)를 참조하십시오.

{{% alert color="info" title="Note" %}}
텍스트 교체는 가져온 텍스트에만 적용되며, 스캔된 이미지 내부의 텍스트에는 적용되지 않습니다. 변환 과정에서 레이아웃 및 서식이 변경될 수 있으므로, 특히 교체된 텍스트가 원본보다 길어질 경우 출력 결과를 검토하십시오.
{{% /alert %}}

## **FAQ**

**PDF를 내보내기 전에 PPTX 파일을 저장해야 합니까?**

아니요. 메모리 상에서 동일한 프레젠테이션을 편집하고 바로 내보낼 수 있습니다. PowerPoint에서 계속 편집하려는 경우에만 PPTX 복사본을 저장하면 됩니다; 자세한 내용은 [Save Presentations](/slides/ko/androidjava/save-presentation/)를 참조하십시오.

**왜 일부 텍스트가 변경되지 않을 수 있나요?**

예제는 정확한 대소문자를 가진 전체 단어 "Draft"와 일치하도록 되어 있습니다. 이미지로 가져온 텍스트이거나 별도의 텍스트 프레임으로 분할된 경우 검색에 일치하지 않을 수 있습니다. 가져온 내용을 확인하고 문서에 맞게 검색을 조정하십시오.