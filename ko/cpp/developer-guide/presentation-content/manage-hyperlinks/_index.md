---
title: C++에서 프레젠테이션 하이퍼링크 관리
linktitle: 하이퍼링크 관리
type: docs
weight: 20
url: /ko/cpp/manage-hyperlinks/
keywords:
- URL 추가
- 하이퍼링크 추가
- 하이퍼링크 만들기
- 하이퍼링크 서식 지정
- 하이퍼링크 제거
- 하이퍼링크 업데이트
- 텍스트 하이퍼링크
- 슬라이드 하이퍼링크
- 도형 하이퍼링크
- 이미지 하이퍼링크
- 비디오 하이퍼링크
- 가변 하이퍼링크
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 하이퍼링크를 추가, 서식 지정, 업데이트 및 제거합니다. C++ 예제를 사용합니다."
---
## **소개**

하이퍼링크는 프레젠테이션 콘텐츠를 웹사이트나 프레젠테이션 내의 위치에 연결합니다. PowerPoint에서 하이퍼링크는 일반적으로 두 가지 용도로 사용됩니다:
* 텍스트, 도형 또는 미디어 프레임에서 웹사이트를 엽니다.
* 예를 들어 목차에서 다른 슬라이드로 이동합니다.

Aspose.Slides for C++를 사용하면 이러한 링크를 추가하고, 모양과 소리를 제어하며, 설정을 업데이트하고, 제거할 수 있습니다. 아래 예제에서는 개별 요소에서 하이퍼링크를 작업하는 방법과 프레젠테이션, 슬라이드 또는 텍스트 프레임 수준에서 하이퍼링크에 접근하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}
무료 온라인 Aspose PowerPoint 편집기로도 프레젠테이션을 편집할 수 있습니다.
{{% /alert %}}

## **URL 하이퍼링크 추가**

웹사이트 URL을 텍스트, 도형 또는 미디어 프레임에 할당할 수 있습니다. 하이퍼링크를 할당하는 요소에 따라 클릭 가능한 영역이 결정됩니다. 텍스트 부분은 선택된 텍스트에만 링크가 적용되고, 도형이나 프레임은 슬라이드 객체 전체에 링크가 적용됩니다.

### **텍스트에 URL 하이퍼링크 추가**

텍스트를 웹사이트에 연결하려면 [Hyperlink](https://reference.aspose.com/slides/ko/cpp/aspose.slides/hyperlink/)을 만들고 텍스트 부분의 [set_HyperlinkClick](https://reference.aspose.com/slides/ko/cpp/aspose.slides/portionformat/set_hyperlinkclick/) 메서드에 할당합니다(아래 예제 참조). 해당 텍스트 부분만 클릭 가능하게 됩니다.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto textShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
textShape->AddTextFrame(u"Aspose: File Format APIs");
auto portionFormat = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");
portionFormat->set_FontHeight(32);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **도형 및 미디어 프레임에 URL 하이퍼링크 추가**

도형이나 프레임을 클릭 가능하게 만들려면 해당 객체의 [set_HyperlinkClick](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/set_hyperlinkclick/) 메서드를 사용합니다. 하이퍼링크는 객체 자체에 속하며 내부 텍스트 부분에 속하지 않습니다.

같은 방법이 그림, 오디오 및 비디오 프레임에도 적용됩니다. 프레임에 하이퍼링크를 할당하고 필요하면 [set_Tooltip](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlink/set_tooltip/)을 사용해 힌트를 추가합니다.

다음 예제는 사각형을 클릭 가능하게 만듭니다:

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **목차 생성에 하이퍼링크 사용**

내부 하이퍼링크를 사용하면 독자가 목차에서 특정 슬라이드로 이동할 수 있습니다. 다음 예제는 [SetInternalHyperlinkClick](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/)을 사용해 첫 번째 슬라이드의 “Page 2” 텍스트를 두 번째 슬라이드에 연결합니다.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto tableOfContents = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
tableOfContents->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
tableOfContents->get_TextFrame()->get_Paragraphs()->Add(paragraph);

presentation->Save(u"link_to_slide.pptx", SaveFormat::Pptx);
```

## **하이퍼링크 서식 지정**

### **색상**

[IHyperlink](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlink/)의 [set_ColorSource](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlink/set_colorsource/) 메서드는 하이퍼링크가 프레젠테이션의 하이퍼링크 색상을 사용할지 텍스트 부분의 서식을 사용할지를 결정합니다. 사용자 지정 텍스트 색상을 적용하려면 [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/hyperlinkcolorsource/)을 선택하고 부분의 채우기 색상을 설정합니다. 이 기능은 PowerPoint 2019에서 도입되었으며 이전 버전에서는 적용되지 않습니다.

다음 예제는 동일한 슬라이드에 두 개의 텍스트 하이퍼링크를 추가합니다. 첫 번째는 빨간색 텍스트 채우기를 사용하고, 두 번째는 기본 하이퍼링크 색상을 유지합니다.

```cpp
#include <DOM/FillType.h>
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkColorSource.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto coloredShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
coloredShape->AddTextFrame(u"This hyperlink uses a custom color.");
auto coloredPortionFormat = coloredShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
coloredPortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
coloredPortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
coloredPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
coloredPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

auto defaultShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
defaultShape->AddTextFrame(u"This hyperlink uses the default color.");
defaultShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```

### **소리**

하이퍼링크는 활성화될 때 소리를 재생하거나 이미 재생 중인 소리를 중지할 수 있습니다. 다음 메서드를 사용해 이러한 동작을 구성합니다:
- [IHyperlink::set_Sound](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlink/set_sound/)은 하이퍼링크와 연결된 오디오를 지정합니다.
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/)은 하이퍼링크를 클릭할 때 이전 소리를 중지할지 여부를 제어합니다.

#### **하이퍼링크 사운드 추가**

다음 예제는 `sampleaudio.wav`를 로드하고 첫 번째 슬라이드의 버튼에 연결합니다. 버튼을 클릭하면 소리가 재생되고 다음 슬라이드로 이동합니다. 동일 슬라이드의 두 번째 도형은 클릭 시 이전 소리를 중지하지만 이동 동작은 수행하지 않습니다.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto audioData = System::IO::File::ReadAllBytes(u"sampleaudio.wav");
auto hyperlinkSound = presentation->get_Audios()->AddAudio(audioData);

auto firstSlide = presentation->get_Slide(0);

auto playButton = firstSlide->get_Shapes()->AddAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
playButton->set_HyperlinkClick(Hyperlink::get_NextSlide());

if (!playButton->get_HyperlinkClick()->get_StopSoundOnClick() && playButton->get_HyperlinkClick()->get_Sound() == nullptr)
{
    playButton->get_HyperlinkClick()->set_Sound(hyperlinkSound);
}

auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto stopButton = secondSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
stopButton->set_HyperlinkClick(Hyperlink::get_NoAction());

stopButton->get_HyperlinkClick()->set_StopSoundOnClick(true);

presentation->Save(u"hyperlink-sound.pptx", SaveFormat::Pptx);
```

#### **하이퍼링크 사운드 추출**

다음 예제는 위에서 만든 프레젠테이션을 열고 첫 번째 도형의 하이퍼링크 오디오를 [get_Sound](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlink/get_sound/) 및 [get_BinaryData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iaudio/get_binarydata/)을 통해 메모리로 읽어들입니다.

```cpp
#include <DOM/IAudio.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"hyperlink-sound.pptx");

if (presentation->get_Slides()->get_Count() > 0 && presentation->get_Slide(0)->get_Shapes()->get_Count() > 0)
{
    auto hyperlink = presentation->get_Slide(0)->get_Shape(0)->get_HyperlinkClick();
    auto sound = hyperlink != nullptr ? hyperlink->get_Sound() : nullptr;
    if (sound != nullptr)
    {
        auto audioData = sound->get_BinaryData();
        System::Console::WriteLine(u"Extracted {0} bytes of hyperlink audio.", audioData->get_Length());
    }
    else
    {
        System::Console::WriteLine(u"The first shape has no hyperlink sound.");
    }
}
else
{
    System::Console::WriteLine(u"The presentation has no first slide or shape to inspect.");
}
```

### **툴팁 및 인터랙션 설정**

텍스트나 도형에 하이퍼링크를 할당한 후 다음 [IHyperlink](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlink/) 메서드로 설정을 업데이트할 수 있습니다:
- [set_Tooltip](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlink/set_tooltip/)은 사용자가 링크에 대한 힌트로 표시할 텍스트를 설정합니다.
- [set_TargetFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlink/set_targetframe/)은 해당되는 경우 상위 HTML 프레임셋 내의 대상 프레임을 지정합니다.
- [set_History](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlink/set_history/)은 링크를 활성화할 때 해당 대상이 본 하이퍼링크 목록에 추가될지 여부를 제어합니다.
- [set_HighlightClick](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlink/set_highlightclick/)은 클릭 시 하이퍼링크가 강조 표시될지 여부를 제어합니다.

## **프레젠테이션에서 하이퍼링크 제거**

[GetAnyHyperlinks](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)을 사용해 텍스트 부분 링크를 포함한 하이퍼링크 컨테이너를 수집한 뒤 변경합니다. 다음 예제는 첫 번째 슬라이드에서 두 가지 활성화 유형을 모두 제거합니다. 하나만 제거하려면 [RemoveHyperlinkClick](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) 또는 [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)만 호출하면 됩니다; 클릭 동작을 제거해도 마우스오버 동작은 남습니다.

```cpp
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

if (presentation->get_Slides()->get_Count() > 0)
{
    auto containers = presentation->get_Slide(0)->get_HyperlinkQueries()->GetAnyHyperlinks();
    for (const auto& container : containers)
    {
        container->get_HyperlinkManager()->RemoveHyperlinkClick();
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
    presentation->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
}
else
{
    System::Console::WriteLine(u"The presentation has no slides to process.");
}
```

조건 없이 모두 제거하려면 [RemoveAllHyperlinks](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)를 호출해 선택된 범위에서 두 활성화 유형을 한 번에 제거합니다. 마스터, 레이아웃 및 노트에 대한 선택적 정리와 포함 범위는 [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)를 참고하세요.

## **전체 하이퍼링크 인벤토리 구축**

프레젠테이션을 배포하기 전에 인터랙티브 동작과 웹 링크를 모두 인벤토리합니다. [GetAnyHyperlinks](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)은 URL 문자열의 평면 목록이 아니라 [IHyperlinkContainer](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlinkcontainer/) 객체를 반환합니다. 각 컨테이너에서 [get_HyperlinkClick](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/)와 [get_HyperlinkMouseOver](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/)를 모두 검사합니다. 두 메서드는 독립적이며, 같은 컨테이너가 두 동작을 모두 노출할 수 있으므로 완전한 보고서에는 컨테이너당 최대 두 행이 필요합니다.

도형 수준 하이퍼링크만 스캔하면 텍스트 부분에 연결된 링크를 놓칠 수 있습니다. 대신 적절한 범위를 쿼리하고 반환된 컨테이너를 보관해 나중에 동작을 업데이트하거나 제거할 수 있도록 합니다.

### **프레젠테이션, 슬라이드 및 텍스트 프레임 범위 쿼리**

[IHyperlinkQueries](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlinkqueries/) 인터페이스는 [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/), [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/), 그리고 [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/get_hyperlinkqueries/)를 통해 사용할 수 있습니다. 각 범위는 동일한 쿼리를 지원합니다:
- [GetHyperlinkClicks](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/)은 클릭 동작이 있는 컨테이너를 반환합니다.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/)은 마우스오버 동작이 있는 컨테이너를 반환합니다.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)은 클릭이든 마우스오버든 상관없이 동작이 있는 컨테이너를 반환합니다.

다음 예제는 외부 클릭 링크, 파일 마우스오버 링크, 내부 슬라이드 네비게이션, 텍스트 마우스오버 링크 및 매크로 동작을 포함하는 `hyperlink-audit-input.pptx`를 생성합니다. 이 예제는 어떤 동작도 실행하지 않습니다. 동일한 세 쿼리는 모든 범위에서 작동하며, 카운트는 컨테이너 수를 나타낼 뿐 동작 총합은 아닙니다. 텍스트 프레임 범위는 포함하는 도형 자체의 링크를 제외합니다.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto printCounts = [](System::String scope, System::SharedPtr<IHyperlinkQueries> queries)
{
    auto clickContainers = queries->GetHyperlinkClicks();
    auto mouseOverContainers = queries->GetHyperlinkMouseOvers();
    auto allContainers = queries->GetAnyHyperlinks();
    System::Console::WriteLine(u"{0}: click={1}, mouse-over={2}, any={3}", scope, clickContainers->get_Count(), mouseOverContainers->get_Count(), allContainers->get_Count());
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddEmptySlide(slide->get_LayoutSlide());
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
shape->get_TextFrame()->set_Text(u"Click the text to go to slide 2");
shape->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://example.com/");
shape->get_HyperlinkClick()->set_Tooltip(u"Public website");
shape->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"file:///C:/private/report.xlsx");

auto portionFormat = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->get_HyperlinkManager()->SetInternalHyperlinkClick(destination);
portionFormat->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"https://example.com/help");
auto macroButton = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
macroButton->get_HyperlinkManager()->SetMacroHyperlinkClick(u"ReviewPresentation");

printCounts(u"Presentation", presentation->get_HyperlinkQueries());
printCounts(u"Slide 1", slide->get_HyperlinkQueries());
printCounts(u"Text frame", shape->get_TextFrame()->get_HyperlinkQueries());
presentation->Save(u"hyperlink-audit-input.pptx", SaveFormat::Pptx);
```

이 예제에서 프레젠테이션 및 슬라이드 쿼리는 각각 클릭 컨테이너 3개, 마우스오버 컨테이너 2개, 어느 동작이든 포함하는 컨테이너 3개를 보고합니다. 텍스트 프레임 쿼리는 각 카테고리에서 컨테이너 1개씩 보고합니다.

### **동작 및 대상 분류**

[IHyperlink::get_ActionType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlink/get_actiontype/)을 사용해 동작을 해석하고, 그 다음 대상을 해석합니다. [HyperlinkActionType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/hyperlinkactiontype/) 값은 웹 네비게이션을 넘어서는 범위를 포함합니다:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | 외부 하이퍼링크; URL 및 스킴을 검토합니다. |
| `JumpSpecificSlide` | 특정 슬라이드로 내부 이동. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 내장 슬라이드쇼 네비게이션, 슬라이드쇼 컨텍스트에서 해결됩니다. |
| `JumpEndShow`, `StartCustomSlideShow` | 현재 쇼를 종료하거나 사용자 정의 쇼를 시작합니다. |
| `StartMacro` | 매크로 실행. |
| `StartProgram` | 프로그램 실행. |
| `OpenFile`, `OpenPresentation` | 파일 또는 다른 프레젠테이션을 엽니다; 웹 URL과 별도로 검토합니다. |
| `StartStopMedia` | 미디어 재생을 시작하거나 중지합니다. |
| `NoAction`, `Unknown` | 네비게이션 동작이 없거나 인식되지 않은 동작으로 검토가 필요합니다. |

외부 대상은 [get_ExternalUrl](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlink/get_externalurl/)을 통해, 특정 내부 대상은 [get_TargetSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlink/get_targetslide/)을 통해 읽어냅니다. 내부 동작과 내장 명령은 외부 URL이 없을 수 있으며, 빈 URL이 컨테이너에 동작이 없다는 의미는 아닙니다. 정규화된 URL과 다를 경우 [get_ExternalUrlOriginal](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlink/get_externalurloriginal/)을 보존하고, 사용 가능한 경우 [get_Tooltip](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlink/get_tooltip/)이 반환하는 툴팁도 포함합니다.

### **보고서 작성, 정리 및 하이퍼링크 검증**

다음 C++ 예제는 기존 프레젠테이션을 읽고(`위에서 만든 파일 사용`), `hyperlink-audit.json`을 쓰고, 정책을 적용한 뒤 `hyperlink-sanitized.pptx`를 저장하고 다시 열어 두 활성화 유형을 다시 확인합니다. 변경 전에 컨테이너를 수집하고 포인터 동일성을 사용해 동일 컨테이너를 두 번 처리하지 않도록 합니다. 프레젠테이션 쿼리는 일반 슬라이드를 포함하고, 전체 패키지 인벤토리를 위해 마스터, 레이아웃, 노트 및 노트/핸드아웃 마스터도 명시적으로 쿼리합니다.

보고서는 가능한 경우 1부터 시작하는 슬라이드 인덱스와 [get_SlideId](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseslide/get_slideid/)를 기록합니다. [ISlideComponent::get_Slide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecomponent/get_slide/)은 지원되는 컨테이너의 소유 슬라이드를 제공합니다. 마스터, 레이아웃 및 노트는 일반 슬라이드 인덱스가 없으며 범위로 식별됩니다. 도형 컨테이너와 텍스트 부분 서식 컨테이너는 별도로 표시하고, 다른 컨테이너 유형은 런타임 타입 이름을 유지합니다. 각 컨테이너는 보고서 로컬 ID를 받아 두 동작을 연관시킬 수 있습니다.

이 제한적인 애플리케이션 정책은 절대 HTTPS URL과 유효한 내부 슬라이드 대상만 허용합니다. 매크로, 프로그램, 파일 동작, 기타 슬라이드쇼 동작, 알 수 없는 동작 및 기타 URL 스킴은 거부합니다. 이러한 거부는 정책 결정이며 Aspose.Slides 안전 판정이 아닙니다. HTTPS만으로는 신뢰를 보장하지 않으므로 호스트 허용 목록 및 기타 검사를 추가하세요. 원본 및 정규화된 외부 URL 모두를 검사합니다. 예제는 링크를 따라가거나 동작을 실행하지 않고 메타데이터만 감사합니다.

수정하려면 컨테이너의 [get_HyperlinkManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/)가 [SetExternalHyperlinkClick](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/), [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)를 지원합니다. 여기서는 금지된 외부 클릭 링크를 고정된 HTTPS 랜딩 페이지로 교체하고, 다른 금지된 클릭 및 금지된 마우스오버 동작은 독립적으로 제거합니다. `replaceExternalClicks`를 `false`로 설정하면 모든 정책 위반을 제거합니다. 배포 전에 애플리케이션이 소유한 교체 페이지를 선택하세요.

보고서의 내보내기 플래그는 보수적인 PDF 검토 정책을 사용합니다: 마우스오버 동작 및 외부 링크나 특정 슬라이드 점프가 아닌 모든 항목을 잠재적으로 지원되지 않을 수 있다고 표시합니다. 이는 검토 힌트이며 기능 테스트나 표시되지 않은 링크가 내보내기 후에도 살아남는다는 보장은 아닙니다. 지원되는 [PDF](/slides/ko/cpp/convert-powerpoint-to-pdf/) 및 [HTML](/slides/ko/cpp/convert-powerpoint-to-html/) 내보내기는 동작, 내보내기 옵션 및 뷰어에 따라 하이퍼링크를 보존할 수 있습니다. 래스터 [images](/slides/ko/cpp/convert-powerpoint-to-png/)와 [video](/slides/ko/cpp/convert-powerpoint-to-video/)는 인터랙티브 하이퍼링크를 보존할 수 없으며, 해당 출력에 대한 감사를 수행할 때 모든 동작을 표시해야 합니다.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkActionType.h>
#include <DOM/IBaseSlide.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPresentation.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideComponent.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/uri.h>
#include <system/environment.h>
#include <fstream>
#include <sstream>
#include <iomanip>
#include <vector>
#include <unordered_set>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const auto replaceExternalClicks = true;
const System::String replacementUrl = u"https://example.com/blocked-link";
auto presentation = System::MakeObject<Presentation>(u"hyperlink-audit-input.pptx");

auto collectContainers = [](System::SharedPtr<IPresentation> source)
{
    std::vector<System::SharedPtr<IHyperlinkContainer>> found;
    std::unordered_set<IHyperlinkContainer*> seen;
    auto addQueries = [&](System::SharedPtr<IHyperlinkQueries> queries)
    {
        auto containers = queries->GetAnyHyperlinks();
        for (const auto& container : containers)
        {
            if (seen.insert(container.get()).second) found.push_back(container);
        }
    };
    auto addScope = [&](System::SharedPtr<IBaseSlide> slide)
    {
        if (slide != nullptr) addQueries(slide->get_HyperlinkQueries());
    };
    addQueries(source->get_HyperlinkQueries());
    for (const auto& master : source->get_Masters()) addScope(master);
    for (const auto& layout : source->get_LayoutSlides()) addScope(layout);
    for (const auto& slide : source->get_Slides()) addScope(slide->get_NotesSlideManager()->get_NotesSlide());
    addScope(source->get_MasterNotesSlideManager()->get_MasterNotesSlide());
    addScope(source->get_MasterHandoutSlideManager()->get_MasterHandoutSlide());
    return found;
};

auto isHttps = [](System::String value)
{
    System::SharedPtr<System::Uri> uri;
    return System::Uri::TryCreate(value, System::UriKind::Absolute, uri) && uri->get_Scheme() == System::Uri::UriSchemeHttps;
};
auto policyViolation = [&](System::SharedPtr<IHyperlink> link) -> System::String
{
    if (link == nullptr) return u"";
    if (link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide)
    {
        return link->get_TargetSlide() == nullptr ? u"Missing target slide" : u"";
    }
    if (link->get_ActionType() != HyperlinkActionType::Hyperlink) return u"Action is not allowed";
    if (!isHttps(link->get_ExternalUrl())) return u"Normalized URL is not absolute HTTPS";
    auto original = link->get_ExternalUrlOriginal();
    if (!original.IsNullOrEmpty() && !isHttps(original)) return u"Original URL is not absolute HTTPS";
    return u"";
};
auto slideIndex = [&](System::SharedPtr<IBaseSlide> slide)
{
    for (auto index = 0; index < presentation->get_Slides()->get_Count(); index++)
    {
        if (presentation->get_Slide(index) == slide) return index + 1;
    }
    return 0;
};
auto jsonString = [](System::String value)
{
    std::ostringstream escaped;
    escaped << '"';
    for (unsigned char character : value.ToUtf8String())
    {
        if (character == '"' || character == '\\') escaped << '\\' << character;
        else if (character < 0x20) escaped << "\\u" << std::hex << std::setw(4) << std::setfill('0') << static_cast<int>(character);
        else escaped << character;
    }
    escaped << '"';
    return escaped.str();
};
auto containers = collectContainers(presentation);
std::ofstream report("hyperlink-audit.json", std::ios::binary);
if (!report)
{
    System::Console::WriteLine(u"Cannot open the audit report for writing.");
    System::Environment::set_ExitCode(1);
    return;
}
auto rowCount = 0;
report << "[\n";
auto addRow = [&](System::SharedPtr<IHyperlink> link, System::String activation, System::SharedPtr<IHyperlinkContainer> container, size_t containerId)
{
    if (link == nullptr) return;
    auto component = System::AsCast<ISlideComponent>(container);
    auto ownerSlide = component != nullptr ? component->get_Slide() : nullptr;
    auto targetSlide = link->get_TargetSlide();
    auto violation = policyViolation(link);
    auto shape = System::AsCast<IShape>(container);
    auto portionFormat = System::AsCast<IPortionFormat>(container);
    auto ownerType = shape != nullptr ? System::String(u"Shape") : portionFormat != nullptr ? System::String(u"Text portion") : container->GetType().get_Name();
    auto ordinaryAction = link->get_ActionType() == HyperlinkActionType::Hyperlink || link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide;
    auto ownerIndex = slideIndex(ownerSlide);
    auto targetIndex = slideIndex(targetSlide);
    if (rowCount++ != 0) report << ",\n";
    report << "  {\"ContainerId\":" << containerId;
    report << ",\"SlideIndex\":" << (ownerIndex != 0 ? std::to_string(ownerIndex) : "null");
    report << ",\"SlideId\":" << (ownerSlide != nullptr ? std::to_string(ownerSlide->get_SlideId()) : "null");
    report << ",\"Scope\":" << (ownerSlide != nullptr ? jsonString(ownerSlide->GetType().get_Name()) : "null");
    report << ",\"OwnerType\":" << jsonString(ownerType);
    report << ",\"Activation\":" << jsonString(activation);
    report << ",\"ActionType\":" << jsonString(System::ObjectExt::ToString(link->get_ActionType()));
    report << ",\"ExternalUrl\":" << jsonString(link->get_ExternalUrl());
    report << ",\"TargetSlideIndex\":" << (targetIndex != 0 ? std::to_string(targetIndex) : "null");
    report << ",\"TargetSlideId\":" << (targetSlide != nullptr ? std::to_string(targetSlide->get_SlideId()) : "null");
    report << ",\"Tooltip\":" << jsonString(link->get_Tooltip());
    report << ",\"OriginalExternalUrl\":" << (link->get_ExternalUrlOriginal() != link->get_ExternalUrl() ? jsonString(link->get_ExternalUrlOriginal()) : "null");
    report << ",\"PotentiallyUnsafe\":" << (!violation.IsNullOrEmpty() ? "true" : "false");
    report << ",\"PolicyViolation\":" << (!violation.IsNullOrEmpty() ? jsonString(violation) : "null");
    report << ",\"TargetExport\":\"PDF\",\"PotentiallyUnsupportedByExport\":" << (activation == u"mouse-over" || !ordinaryAction ? "true" : "false") << "}";
};
for (auto index = size_t{0}; index < containers.size(); index++)
{
    auto container = containers[index];
    addRow(container->get_HyperlinkClick(), u"click", container, index + 1);
    addRow(container->get_HyperlinkMouseOver(), u"mouse-over", container, index + 1);
}
report << "\n]\n";
report.close();
if (!report)
{
    System::Console::WriteLine(u"The audit report could not be written completely.");
    System::Environment::set_ExitCode(1);
    return;
}

for (const auto& container : containers)
{
    auto click = container->get_HyperlinkClick();
    if (!policyViolation(click).IsNullOrEmpty())
    {
        if (replaceExternalClicks && click->get_ActionType() == HyperlinkActionType::Hyperlink)
        {
            container->get_HyperlinkManager()->SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container->get_HyperlinkManager()->RemoveHyperlinkClick();
        }
    }
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty())
    {
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
}
presentation->Save(u"hyperlink-sanitized.pptx", SaveFormat::Pptx);
auto reopened = System::MakeObject<Presentation>(u"hyperlink-sanitized.pptx");
auto remainingContainers = collectContainers(reopened);
auto violations = 0;
for (const auto& container : remainingContainers)
{
    if (!policyViolation(container->get_HyperlinkClick()).IsNullOrEmpty()) violations++;
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty()) violations++;
}
System::Console::WriteLine(u"Audit rows: {0}; prohibited actions after reopening: {1}", rowCount, violations);
if (violations != 0)
{
    System::Console::WriteLine(u"Verification failed: do not distribute the saved presentation.");
    System::Environment::set_ExitCode(1);
}
```

위에서 만든 입력으로 보고서는 다섯 개의 동작 행을 포함합니다. 파일 마우스오버 링크와 매크로 클릭은 제거되고, HTTPS 링크와 내부 슬라이드 네비게이션은 유지됩니다. 검증 결과 금지된 동작이 0개임을 출력합니다. 금지된 외부 클릭 URL이 포함된 입력은 교체 분기를 실행합니다. 허용된 클릭과 금지된 마우스오버를 가진 컨테이너는 클릭 동작을 유지합니다.

이 선택적 정리는 [RemoveAllHyperlinks](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)와 다릅니다. 전자는 정책과 무관하게 선택된 범위 전체에서 두 활성화 유형을 모두 제거합니다. 여기서 검증은 하이퍼링크 동작만 확인하며, 임베드된 VBA 프로젝트, OLE 객체 또는 기타 활성 콘텐츠를 제거하지 않으며, 내보낸 PDF나 HTML 파일을 검증하지도 않습니다.

## **FAQ**

**섹션 또는 해당 섹션의 첫 번째 슬라이드에 어떻게 연결할 수 있나요?**

PowerPoint에서 섹션은 슬라이드를 그룹화하지만 내부 하이퍼링크는 개별 슬라이드를 대상으로 합니다. 섹션으로 이동하려면 해당 섹션의 첫 번째 슬라이드에 링크를 연결하면 됩니다.

**마스터 슬라이드 요소에 하이퍼링크를 연결하면 모든 슬라이드에서 동작하게 할 수 있나요?**

예. 마스터 슬라이드와 레이아웃 요소는 하이퍼링크를 지원합니다. 이러한 요소에 있는 링크는 해당 마스터 또는 레이아웃을 사용하는 슬라이드 쇼 중에도 사용할 수 있습니다.

**PDF, HTML, 이미지 또는 비디오로 내보낼 때 하이퍼링크가 보존됩니까?**

지원되는 PDF 및 HTML 내보내기는 하이퍼링크를 보존할 수 있지만, 래스터 이미지와 비디오는 보존할 수 없습니다. 자세한 내용은 [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) 를 참조하세요.