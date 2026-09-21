---
title: PHP에서 PDF 문서 편집
linktitle: PDF 편집
type: docs
weight: 65
url: /ko/php-java/edit-pdf/
keywords:
- PDF 편집
- PDF 텍스트 교체
- PDF를 PPTX로
- PPTX를 PDF로
- PHP
- Aspose.Slides
description: "PDF 문서를 PHP에서 Aspose.Slides에 가져와 텍스트를 교체하고, 수정된 프레젠테이션을 다시 PDF로 저장하여 편집합니다."
---
## **개요**

Aspose.Slides for PHP via Java는 PDF 페이지를 슬라이드로 가져와 편집하고 프레젠테이션을 수정한 다음 다시 PDF로 내보낼 수 있게 해줍니다. 이 문서에서는 간단한 텍스트 교체 예제를 보여줍니다. 프레젠테이션은 메모리 내에 보관되므로 중간 PPTX 파일을 저장하는 것은 선택 사항입니다.

## **PDF에서 텍스트 교체**

페이지를 가져오려면 [SlideCollection::addFromPdf](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/#addFromPdf)를 사용하고, 텍스트를 업데이트하려면 [Presentation::replaceText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#replaceText)를 사용하며, 결과를 내보내려면 [Presentation::save](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#save)를 사용합니다.

다음 예제는 `input.pdf`에 가져온 후 편집 가능한 텍스트로 "Draft"라는 단어가 포함되어 있다고 가정합니다. 이 단어를 "Final"로 교체하고 `edited.pdf`에 저장합니다. 가져오기 전에 초기 슬라이드를 비우면 출력에 빈 페이지가 추가되는 것을 방지할 수 있습니다. 검색은 대소문자를 구분하여 전체 단어와 일치합니다; `null`은 결과 콜백이 필요 없음을 의미합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextSearchOptions;

$presentation = new Presentation();
try {
    $presentation->getSlides()->removeAt(0);

    $presentation->getSlides()->addFromPdf("input.pdf");

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);
    $presentation->replaceText("Draft", "Final", $searchOptions, null);

    $presentation->save("edited.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

추가 옵션은 [텍스트 검색 및 교체](/slides/ko/php-java/search-and-replace-text/)와 [PowerPoint를 PDF로 변환](/slides/ko/php-java/convert-powerpoint-to-pdf/)를 참조하세요.

{{% alert color="info" title="Note" %}}
텍스트 교체는 가져온 텍스트에만 적용되며, 스캔된 이미지 내부의 텍스트에는 적용되지 않습니다. 변환 과정에서 레이아웃 및 서식이 달라질 수 있으므로, 특히 교체 텍스트가 원본보다 길어질 경우 출력물을 반드시 검토하십시오.
{{% /alert %}}

## **FAQ**

**PDF로 내보내기 전에 PPTX 파일을 저장해야 하나요?**

아니요. 메모리 내에서 동일한 프레젠테이션을 편집하고 바로 내보낼 수 있습니다. PowerPoint에서 계속 편집하려면 PPTX 사본을 저장하십시오; [Save Presentations](/slides/ko/php-java/save-presentation/)를 참고하세요.

**왜 일부 텍스트가 그대로 남을 수 있나요?**

예제는 정확한 대소문자를 포함한 전체 단어 "Draft"와 일치합니다. 이미지로 가져오거나 별도의 텍스트 프레임으로 분할된 텍스트는 검색과 일치하지 않을 수 있습니다. 가져온 내용을 확인하고 문서에 맞게 검색 조건을 조정하세요.