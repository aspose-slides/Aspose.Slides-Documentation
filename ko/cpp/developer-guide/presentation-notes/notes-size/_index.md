---
title: C++에서 노트 페이지 크기 및 방향 변경
linktitle: 노트 페이지 크기
type: docs
weight: 10
url: /ko/cpp/notes-size/
keywords:
- 노트 페이지 크기
- 노트 방향
- 가로형 노트
- 세로형 노트
- 핸드아웃 크기
- PowerPoint
- 프레젠테이션
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 노트 페이지 크기를 읽고 변경하며, 방향을 전환하고, 저장된 크기를 확인하고, 노트 또는 핸드아웃을 PDF와 이미지로 내보냅니다."
---
## **개요**

[Presentation::get_NotesSize](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_notessize/)를 사용하여 프레젠테이션의 노트 페이지 설정에 액세스합니다. 이 메서드는 [INotesSize](https://reference.aspose.com/slides/ko/cpp/aspose.slides/inotessize/) 객체를 반환하며, 해당 객체의 [set_Size](https://reference.aspose.com/slides/ko/cpp/aspose.slides/inotessize/set_size/) 메서드로 크기를 설정할 수 있습니다. 노트 설정 객체 자체는 교체할 수 없지만 크기는 변경할 수 있습니다.

너비와 높이는 **포인트** 단위이며, 1인치당 72포인트입니다. 예를 들어 900 × 600 포인트는 12.5 × 8⅓ 인치에 해당합니다. 이러한 설정은 개별 슬라이드의 노트가 아니라 프레젠테이션 전체에 적용됩니다.

| Setting | Purpose |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_notessize/) | 노트 페이지 차원 및 핸드아웃 내보내기에 사용되는 페이지 차원을 제어합니다. |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_slidesize/) | [ISlideSize](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidesize/)를 통해 일반 프레젠테이션 슬라이드 차원을 제어합니다. |

두 설정 중 하나를 변경해도 다른 설정은 자동으로 변경되지 않습니다. 노트 페이지 방향을 변경해도 일반 슬라이드가 회전하지 않습니다. 일반 슬라이드 크기 조정은 [Slide Size](/slides/ko/cpp/slide-size/)를 참조하십시오.

아래 예제에서는 기존 `sample.pptx` 파일을 사용합니다. 내보내기 예제에서는 스피커 노트가 포함된 슬라이드가 최소 하나 이상 있는 프레젠테이션을 사용하십시오. 각 예제는 독립적으로 실행할 수 있습니다.

## **노트 페이지 크기 및 방향 읽기**

너비와 높이를 읽어 비교하여 방향을 판단합니다: 가로가 더 넓으면 가로형, 세로가 더 길면 세로형, 동일하면 정사각형 페이지입니다. 이 예제는 표준 용지 크기를 가정하지 않고 포인트 단위의 실제 차원을 출력합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();
auto orientation = String(u"Square");

if (size.get_Width() > size.get_Height())
    orientation = u"Landscape";
else if (size.get_Width() < size.get_Height())
    orientation = u"Portrait";

Console::WriteLine(u"Notes page: {0} x {1} points", size.get_Width(), size.get_Height());
Console::WriteLine(u"Orientation: {0}", orientation);
```

## **용지 크기 변경 없이 가로형으로 전환**

방향만 변경하려면 기존 너비와 높이를 서로 교환합니다. 이렇게 하면 맞춤 용지 크기의 양쪽 길이가 그대로 유지됩니다. 아래 조건은 이미 가로형인 페이지가 세로형으로 바뀌는 것을 방지하고 정사각형 페이지는 그대로 둡니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();

if (size.get_Width() < size.get_Height())
    presentation->get_NotesSize()->set_Size(SizeF(size.get_Height(), size.get_Width()));

presentation->Save(u"landscape-notes.pptx", SaveFormat::Pptx);
```

세로형으로 전환하려면 `size.get_Width() > size.get_Height()`인 경우에 동일한 할당을 사용합니다. 용지 크기도 같이 변경하고 싶지 않다면 A4나 Letter 크기를 대체하지 마십시오.

## **맞춤 노트 페이지 크기 설정 및 확인**

두 차원을 동시에 할당한 후 [Presentation::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/)를 사용해 프레젠테이션을 저장합니다. 이 예제는 900 × 600 포인트 가로형 페이지를 설정하고 PPTX로 저장한 뒤, 저장된 파일을 다시 열어 지속된 값을 확인합니다. 비교 시 부동소수점 값에 대해 0.01 포인트 허용오차를 두며, 모든 파일 형식에 대해 정확성을 보장하지는 않습니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <cmath>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto expectedSize = SizeF(900, 600);
presentation->get_NotesSize()->set_Size(expectedSize);
presentation->Save(u"custom-notes.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"custom-notes.pptx");
auto actualSize = reopened->get_NotesSize()->get_Size();
auto widthMatches = std::abs(actualSize.get_Width() - expectedSize.get_Width()) < 0.01f;
auto heightMatches = std::abs(actualSize.get_Height() - expectedSize.get_Height()) < 0.01f;
auto preserved = widthMatches && heightMatches;

Console::WriteLine(u"Stored notes page: {0} x {1} points", actualSize.get_Width(), actualSize.get_Height());
Console::WriteLine(u"Size preserved: {0}", preserved);
```

예상 결과는 `900 x 600 points`와 `Size preserved: True`입니다. 새로 연 프레젠테이션을 확인하면 메모리 상 설정이 아닌 저장된 파일을 검증합니다.

## **노트 및 핸드아웃 내보내기**

페이지 차원은 노트나 핸드아웃 레이아웃에 사용할 수 있는 영역을 정의합니다. 레이아웃 자체를 활성화하려면 내보내기 옵션도 설정해야 합니다. 일반 슬라이드 내보내기는 슬라이드 차원을 계속 사용합니다.

### **노트를 PDF 및 PNG로 내보내기**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/notescommentslayoutingoptions/)을 [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/)에 할당하면 PDF에 노트를 포함할 수 있습니다. 이 예제는 또한 [Slide::GetImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slide/getimage/)와 [RenderingOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/renderingoptions/)을 사용해 노트가 있는 첫 번째 슬라이드를 PNG로 렌더링합니다.

[BottomTruncated](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/notespositions/) 모드는 노트를 한 페이지에 유지하고, 맞지 않는 노트는 잘라냅니다. PDF는 900 × 600 포인트 페이지를 사용합니다. 아래에서 사용한 1 × 1 이미지 스케일에서는 PNG가 900 × 600 픽셀이 됩니다. 포인트는 페이지 기하학을, 픽셀은 렌더링 스케일에 따라 결정되는 래스터 출력을 나타냅니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <DOM/ISlide.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<NotesCommentsLayoutingOptions>();
layout->set_NotesPosition(NotesPositions::BottomTruncated);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"notes.pdf", SaveFormat::Pdf, pdfOptions);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layout);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions, 1.0f, 1.0f);
image->Save(u"first-slide-notes.png", ImageFormat::Png);
image->Dispose();
```

긴 노트가 있는 PDF 내보내기에서는 [BottomFull](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/notespositions/)을 사용해 필요에 따라 추가 페이지를 생성합니다. 위의 단일 슬라이드 이미지 호출은 해당 모드를 지원하지 않으니 사용하지 마십시오. 크기를 조정한 뒤 출력에서 잘린 노트와 기존 노트‑마스터 객체의 배치를 확인하십시오; 페이지 차원만 변경한다고 모든 내용이 맞게 들어간다는 보장은 없습니다. 노트 내보내기 자세한 내용은 [Convert PowerPoint to PDF with Notes](/slides/ko/cpp/convert-powerpoint-to-pdf-with-notes/)를 참고하십시오.

### **핸드아웃을 PDF로 내보내기**

여러 슬라이드 썸네일을 한 페이지에 배치하려면 [HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/handoutlayoutingoptions/)를 사용합니다. 다음 예제는 900 × 600 포인트 페이지를 설정하고 [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/handouttype/)을 사용해 페이지당 최대 네 슬라이드를 가로형으로 배열합니다. 가로형 프리셋은 슬라이드 순서를 제어하고, 페이지 방향은 너비와 높이에서 결정됩니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<HandoutLayoutingOptions>();
layout->set_Handout(HandoutType::Handouts4Horizontal);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"handouts.pdf", SaveFormat::Pdf, pdfOptions);
```

페이지 크기를 변경하면 핸드아웃 격자에 사용할 수 있는 영역이 바뀌지만, 원본 슬라이드 자체의 차원은 변하지 않습니다. 핸드아웃 이미지를 얻으려면 개별 슬라이드 이미지 메서드 대신 핸드아웃 레이아웃을 지정해 [Presentation::GetImages](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/getimages/)를 사용하십시오. Aspose.Slides에서 프레젠테이션 수준 핸드아웃 렌더링은 노트 페이지 차원을 사용하지만, 개별 슬라이드 이미지 호출은 핸드아웃 페이지를 생성하지 않습니다. 레이아웃 옵션은 [Handout Mode](/slides/ko/cpp/convert-powerpoint-in-handout-mode/)를 참고하십시오.

## **뷰어, 내보내기 및 인쇄 시 페이지 크기**

저장된 프레젠테이션 크기, 내보낸 페이지 크기, 인쇄된 용지 크기를 구분해서 관리하십시오:

- **프레젠테이션 뷰어:** 뷰어는 자체 레이아웃 규칙에 따라 노트를 표시하거나 인쇄할 수 있습니다. 다른 애플리케이션이 파일을 저장한 경우 파일을 다시 열어 차원을 확인하십시오. 해당 애플리케이션의 형식 변환이 차원을 표준화할 수 있습니다.
- **내보내기 형식:** 위의 노트와 핸드아웃 PDF 예제는 구성된 페이지 차원을 사용합니다. 래스터 이미지의 경우 정수 픽셀 차원과 렌더링 스케일을 사용하므로 소수점 포인트 값이 이미지 출력에서 반올림될 수 있습니다. 일반 슬라이드 내보내기에는 노트 페이지 크기가 적용되지 않습니다.
- **프린터 드라이버:** 용지 선택, 자동 회전 및 페이지 맞춤 설정은 물리적 출력에 영향을 주지만 프레젠테이션이나 PDF에 저장된 차원을 변경하지는 않습니다. 특정 용지 크기를 사용하려면 프린터 설정을 일치시키고 인쇄 미리보기를 확인하십시오.

## **FAQ**

**한 슬라이드에만 노트 크기를 설정할 수 있나요?**

노트 페이지 크기는 프레젠테이션 수준 설정입니다. 개별 슬라이드마다 다른 노트 내용은 가질 수 있지만, 이 속성은 슬라이드마다 별도의 페이지 크기를 제공하지 않습니다.

**노트 방향을 변경했는데 슬라이드가 바뀌지 않은 이유는?**

노트 페이지와 일반 슬라이드는 독립적인 차원을 갖습니다. 슬라이드 자체의 크기를 변경하려면 일반 슬라이드 크기 설정을 사용하십시오.

**저장되거나 인쇄된 결과가 다른 크기를 가지는 이유는?**

먼저 저장된 프레젠테이션을 다시 열어 노트 차원을 비교하십시오. 차이가 있다면 다른 애플리케이션에서 파일을 저장하거나 변환하면서 페이지 설정이 변경되었을 수 있습니다. 그렇지 않다면 내보내기 레이아웃, 이미지 스케일, 뷰어 설정 및 프린터 용지 선택을 확인하십시오.