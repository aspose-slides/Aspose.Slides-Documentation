---
title: JavaScript에서 PDF 문서 편집
linktitle: PDF 편집
type: docs
weight: 65
url: /ko/nodejs-java/edit-pdf/
keywords:
- PDF 편집
- PDF 텍스트 교체
- PDF에서 PPTX로
- PPTX에서 PDF로
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides에 PDF를 가져와 텍스트를 교체하고 수정된 프레젠테이션을 다시 PDF로 저장하여 JavaScript에서 PDF 문서를 편집합니다."
---
## **개요**

Aspose.Slides for Node.js via Java은 페이지를 슬라이드로 가져와 프레젠테이션을 수정하고 다시 PDF로 내보내어 PDF 콘텐츠를 편집할 수 있게 합니다. 이 문서에서는 간단한 텍스트 교체를 보여줍니다. 프레젠테이션은 메모리 상에 유지되므로 중간 PPTX 파일을 저장하는 것은 선택 사항입니다.

## **PDF에서 텍스트 교체**

페이지를 가져오려면 [addFromPdf](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidecollection/#addFromPdf)를, 텍스트를 업데이트하려면 [replaceText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#replaceText)를, 결과를 내보내려면 [save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#save)를 사용합니다.

다음 예제는 `input.pdf`가 가져온 후 편집 가능한 텍스트로 단어 "Draft"를 포함하고 있다고 가정합니다. 이 단어를 "Final"로 교체하고 `edited.pdf`에 기록합니다. 가져오기 전에 초기 슬라이드를 비우면 출력에 빈 페이지가 추가되는 것을 방지할 수 있습니다. 검색은 대소문자를 구분하여 전체 단어와 일치합니다; `null`은 결과 콜백이 필요 없음을 의미합니다.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    const searchOptions = new slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

더 많은 옵션은 [Search and Replace Text](/slides/ko/nodejs-java/search-and-replace-text/) 및 [Convert PowerPoint to PDF](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/) 를 참조하십시오.

{{% alert color="info" title="Note" %}}
텍스트 교체는 가져온 텍스트에 대해서만 작동하며, 스캔된 이미지 내부의 텍스트에는 적용되지 않습니다. 변환은 레이아웃 및 서식에 영향을 줄 수 있으므로, 특히 교체 텍스트가 원본보다 길어질 경우 출력물을 검토하십시오.
{{% /alert %}}

## **FAQ**

**PDF로 내보내기 전에 PPTX 파일을 저장해야 합니까?**

아니요. 메모리 상에서 동일한 프레젠테이션을 편집하고 내보낼 수 있습니다. PowerPoint에서 계속 편집하려는 경우에만 PPTX 복사본을 저장하십시오; [Save Presentations](/slides/ko/nodejs-java/save-presentation/) 를 참조하십시오.

**왜 일부 텍스트가 변경되지 않을 수 있나요?**

예제는 정확히 일치하는 대소문자를 가진 전체 단어 "Draft"와 매치합니다. 이미지로 가져오거나 별도의 텍스트 프레임으로 분리된 텍스트는 검색과 일치하지 않을 수 있습니다. 가져온 콘텐츠를 확인하고 문서에 맞게 검색어를 조정하십시오.