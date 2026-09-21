---
title: .NET에서 PDF 문서 편집
linktitle: PDF 편집
type: docs
weight: 65
url: /ko/net/edit-pdf/
keywords:
- PDF 편집
- PDF 텍스트 교체
- PDF를 PPTX로
- PPTX를 PDF로
- .NET
- C#
- Aspose.Slides
description: "C#에서 Aspose.Slides로 PDF 문서를 가져와 텍스트를 교체하고 수정된 프레젠테이션을 PDF로 다시 저장하여 PDF 문서를 편집합니다."
---
## **개요**

Aspose.Slides for .NET은 PDF 페이지를 슬라이드로 가져와 프레젠테이션을 수정한 뒤 다시 PDF로 내보낼 수 있도록 PDF 내용을 편집할 수 있게 합니다. 이 문서에서는 간단한 텍스트 교체 예제를 보여 줍니다. 프레젠테이션은 메모리 내에 유지되므로 중간 PPTX 파일을 저장하는 것은 선택 사항입니다.

## **PDF에서 텍스트 교체**

페이지를 가져오려면 [AddFromPdf](https://reference.aspose.com/slides/ko/net/aspose.slides/slidecollection/addfrompdf/)를 사용하고, 텍스트를 업데이트하려면 [ReplaceText](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/replacetext/)를 사용하며, 결과를 내보내려면 [Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/)를 사용합니다.

다음 예제는 `input.pdf`에 가져온 후 편집 가능한 텍스트로서 "Draft"라는 단어가 포함되어 있다고 가정합니다. 이 단어를 "Final"로 교체하고 `edited.pdf`를 작성합니다. 가져오기 전에 초기 슬라이드를 비우면 출력에 빈 페이지가 추가되는 것을 방지할 수 있습니다. 검색은 동일한 대소문자를 가진 전체 단어와 일치하며, `null`은 결과 콜백이 필요 없음을 의미합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

자세한 옵션은 [Search and Replace Text](/slides/ko/net/search-and-replace-text/)와 [Convert PowerPoint to PDF](/slides/ko/net/convert-powerpoint-to-pdf/)를 참조하십시오.

{{% alert color="info" title="Note" %}}
텍스트 교체는 가져온 텍스트에만 적용되며 스캔된 이미지 내부의 텍스트에는 적용되지 않습니다. 변환 과정에서 레이아웃 및 서식이 달라질 수 있으므로, 특히 교체할 텍스트가 원본보다 길어질 경우 출력 결과를 반드시 검토하십시오.
{{% /alert %}}

## **FAQ**

**PDF를 내보내기 전에 PPTX 파일을 저장해야 하나요?**

아니요. 메모리 내에서 동일한 프레젠테이션을 편집하고 바로 내보낼 수 있습니다. PowerPoint에서 계속 편집하려면 PPTX 사본을 저장하십시오. 자세한 내용은 [Save Presentations](/slides/ko/net/save-presentation/)를 참고하세요.

**일부 텍스트가 변경되지 않는 이유는 무엇인가요?**

예제는 정확한 대소문자를 가진 전체 단어 "Draft"와 일치합니다. 이미지로 가져온 텍스트이거나 별도의 텍스트 프레임으로 분할된 경우 검색에 일치하지 않을 수 있습니다. 가져온 내용을 확인하고 문서에 맞게 검색을 조정하십시오.