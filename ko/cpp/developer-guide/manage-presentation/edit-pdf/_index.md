---
title: C++에서 PDF 문서 편집
linktitle: PDF 편집
type: docs
weight: 65
url: /ko/cpp/edit-pdf/
keywords:
- PDF 편집
- PDF 텍스트 교체
- PDF를 PPTX로
- PPTX를 PDF로
- C++
- Aspose.Slides
description: "Aspose.Slides에 가져와 텍스트를 교체하고 수정된 프레젠테이션을 PDF로 다시 저장하여 C++에서 PDF 문서를 편집합니다."
---
## **개요**

Aspose.Slides for C++은 PDF 페이지를 슬라이드로 가져와 프레젠테이션을 수정하고 다시 PDF로 내보낼 수 있게 해 줍니다. 이 문서에서는 간단한 텍스트 교체를 보여 줍니다. 프레젠테이션은 메모리 상에 유지되므로 중간 PPTX 파일을 저장하는 것은 선택 사항입니다.

## **PDF에서 텍스트 교체**

페이지를 가져오려면 [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slidecollection/addfrompdf/)를 사용하고, 텍스트를 업데이트하려면 [Presentation::ReplaceText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/replacetext/)를 사용하며, 결과를 내보내려면 [Presentation::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/)를 사용합니다.

다음 예제에서는 `input.pdf`에 가져온 후 편집 가능한 텍스트로 "Draft"라는 단어가 포함되어 있기를 기대합니다. 이 단어를 "Final"로 교체하고 `edited.pdf`를 씁니다. 가져오기 전에 초기 슬라이드를 비우면 출력에 빈 페이지가 추가되는 것을 방지합니다. 검색은 대소문자를 구분하여 전체 단어와 일치합니다; `nullptr`는 결과 콜백이 필요 없음을 의미합니다.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

presentation->get_Slides()->AddFromPdf(u"input.pdf");

auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);
presentation->ReplaceText(u"Draft", u"Final", searchOptions, nullptr);

presentation->Save(u"edited.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

추가 옵션은 [Search and Replace Text](/slides/ko/cpp/search-and-replace-text/)와 [Convert PowerPoint to PDF](/slides/ko/cpp/convert-powerpoint-to-pdf/)를 참조하십시오.

{{% alert color="info" title="Note" %}}
텍스트 교체는 가져온 텍스트에만 적용되며 스캔된 이미지 내부의 텍스트에는 적용되지 않습니다. 변환 과정에서 레이아웃과 서식이 영향을 받을 수 있으므로, 특히 교체된 텍스트가 원본보다 길 경우 출력물을 검토하십시오.
{{% /alert %}}

## **FAQ**

**PDF로 내보내기 전에 PPTX 파일을 저장해야 합니까?**

아니요. 메모리 내에서 동일한 프레젠테이션을 편집하고 바로 내보낼 수 있습니다. PowerPoint에서 계속 편집하려는 경우에만 PPTX 복사본을 저장하십시오; [Save Presentations](/slides/ko/cpp/save-presentation/)를 참조하십시오.

**왜 일부 텍스트가 변경되지 않을 수 있습니까?**

예제는 정확한 대소문자를 구분하여 전체 단어 "Draft"와 일치합니다. 이미지로 가져오거나 별개의 텍스트 프레임으로 분할된 텍스트는 검색과 일치하지 않을 수 있습니다. 가져온 내용을 확인하고 문서에 맞게 검색을 조정하십시오.