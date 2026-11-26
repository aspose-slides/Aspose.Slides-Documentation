---
title: C++을 사용하여 프레젠테이션에서 ActiveX 컨트롤 관리
linktitle: ActiveX
type: docs
weight: 80
url: /ko/cpp/activex/
keywords:
- ActiveX
- ActiveX 컨트롤
- ActiveX 관리
- ActiveX 추가
- ActiveX 수정
- 미디어 플레이어
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션에서 ActiveX 텍스트 상자와 버튼을 편집하고, 컨트롤 미리보기를 업데이트하며, Windows Media Player 컨트롤을 재사용합니다."
---
## **소개**

ActiveX 컨트롤은 PowerPoint 슬라이드에 텍스트 상자, 명령 단추, 미디어 플레이어와 같은 대화형 요소를 제공합니다. Aspose.Slides for C++는 [IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/)를 통해 슬라이드의 컨트롤을 노출합니다. 이 컬렉션을 사용하여 컨트롤을 편집하거나, 슬라이드 상에서 이동시키거나, 제거할 수 있습니다.

## **ActiveX 컨트롤 및 저장된 속성 목록**

익숙하지 않은 템플릿을 검사하려면 읽기 모드로 열고 각 슬라이드의 컨트롤을 순회합니다. 예제는 슬라이드 번호, 컨트롤 이름, [class ID](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/), 및 [stored properties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/)의 각 키‑값 쌍을 보고합니다. 컨트롤을 활성화하거나 이벤트·매크로를 호출하거나 값을 변경하거나 파일을 저장하지 않고 프레젠테이션을 읽습니다.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");

for (auto i = 0; i < presentation->get_Slides()->get_Count(); ++i)
{
    auto controls = presentation->get_Slide(i)->get_Controls();
    for (auto j = 0; j < controls->get_Count(); ++j)
    {
        auto control = controls->idx_get(j);
        Console::WriteLine(u"Slide {0} | {1} | {2}", i + 1, control->get_Name(), control->get_ClassId().ToString());
        auto properties = control->get_Properties();
        if (!properties)
        {
            Console::WriteLine(u"  Properties unavailable");
            continue;
        }

        if (properties->get_Count() == 0)
            Console::WriteLine(u"  []");

        auto entries = properties->GetEnumerator();
        while (entries->MoveNext())
        {
            auto property = entries->get_Current();
            Console::WriteLine(u"  {0} = {1}", property.get_Key(), property.get_Value());
        }
    }
}
```

`ActiveX.pptm`의 선택된 출력은 텍스트 상자와 명령 단추를 보여줍니다.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

빈 속성 컬렉션은 `[]`로 표시됩니다. 이진 저장을 사용하는 컨트롤의 경우 `get_Properties`가 `nullptr`를 반환할 수 있으며 이는 `Properties unavailable`로 표시됩니다. 이름만 필요한 경우 컬렉션이 존재하는지 확인한 후 [get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/)를 사용하십시오. 보고서는 프레젠테이션에서 사용할 수 있는 속성을 나열합니다. 컨트롤은 런타임에 추가 속성을 지원할 수 있습니다.

## **ActiveX 컨트롤 수정**

예제는 첫 번째 슬라이드에 `TextBox1`이라는 텍스트 상자와 `CommandButton1`이라는 명령 단추가 포함된 매크로 사용 가능 프레젠테이션을 기대합니다. [컨트롤 속성 컬렉션](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/)을 사용하여 텍스트 상자 값과 단추 캡션을 변경합니다. 각 컨트롤에는 활성화 전에 PowerPoint이 표시할 수 있는 정적 미리보기가 있습니다. 업데이트된 텍스트와 외형을 보여주는 PNG를 각 컨트롤에 제공하십시오. 예제는 이러한 이미지를 [IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/)을 통해 할당합니다.

예제는 첫 번째 슬라이드의 모든 컨트롤을 [frame](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/)을 변경하여 100포인트 아래로 이동시킵니다. 편집된 프레젠테이션을 PPTM 형식으로 저장한 다음 [IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/)을 사용하여 해당 슬라이드에서 모든 ActiveX 컨트롤이 제거된 두 번째 사본을 저장합니다.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");
auto controls = presentation->get_Slide(0)->get_Controls();
SharedPtr<IControl> textBox;
SharedPtr<IControl> button;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"TextBox1")
        textBox = control;
    else if (control->get_Name() == u"CommandButton1")
        button = control;
}

if (!textBox || !button || !textBox->get_Properties() || !button->get_Properties())
{
    Console::WriteLine(u"The first slide must contain both named controls with editable properties.");
    return;
}

if (!File::Exists(u"text-box-preview.png") || !File::Exists(u"button-preview.png"))
{
    Console::WriteLine(u"Supply both preview images before updating the controls.");
    return;
}

textBox->get_Properties()->idx_set(u"Value", u"Changed text");
button->get_Properties()->idx_set(u"Caption", u"Show message");

auto textBoxBytes = File::ReadAllBytes(u"text-box-preview.png");
auto buttonBytes = File::ReadAllBytes(u"button-preview.png");
auto textBoxPreview = presentation->get_Images()->AddImage(textBoxBytes);
auto buttonPreview = presentation->get_Images()->AddImage(buttonBytes);
textBox->get_SubstitutePictureFormat()->get_Picture()->set_Image(textBoxPreview);
button->get_SubstitutePictureFormat()->get_Picture()->set_Image(buttonPreview);

for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    auto frame = control->get_Frame();
    auto movedFrame = MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation());
    control->set_Frame(movedFrame);
}

presentation->Save(u"edited-controls.pptm", SaveFormat::Pptm);

controls->Clear();
presentation->Save(u"removed-controls.pptm", SaveFormat::Pptm);
```

## **ActiveX 미디어 플레이어 컨트롤 추가**

구성된 Windows Media Player 컨트롤을 재사용하려면 첫 번째 슬라이드에 `WindowsMediaPlayer1`이라는 플레이어가 포함된 템플릿을 시작합니다. [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/)은 전체 슬라이드를 새로운 프레젠테이션으로 복사합니다. 예제는 플레이어의 `URL`을 [properties collection](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/)에 설정하고 복제된 슬라이드를 출력의 유일한 슬라이드로 저장합니다. 비디오는 외부에 남아 있으므로 재생 중에 플레이어가 접근할 수 있는 경로를 선택하십시오.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto source = MakeObject<Presentation>(u"template.pptx");
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slides()->AddClone(source->get_Slide(0));
auto controls = slide->get_Controls();

SharedPtr<IControl> player;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"WindowsMediaPlayer1")
    {
        player = control;
        break;
    }
}

if (!player || !player->get_Properties())
{
    Console::WriteLine(u"The template slide must contain a named media player with editable properties.");
    return;
}

player->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

presentation->get_Slides()->RemoveAt(0);
presentation->Save(u"linked-video.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Aspose.Slides가 ActiveX 컨트롤을 실행하지 않고 보존할 수 있나요?**

예. Aspose.Slides는 컨트롤을 활성화하지 않고도 해당 속성과 위치를 포함하여 읽고 저장할 수 있습니다.

**ActiveX 컨트롤은 OLE 객체와 어떻게 다릅니까?**

ActiveX 컨트롤은 사용자가 슬라이드와 상호 작용하도록 허용합니다(예: 텍스트 입력 또는 버튼 클릭). [OLE 객체](/slides/ko/cpp/manage-ole/)는 슬라이드가 다른 애플리케이션이 관리하는 콘텐츠(예: Excel 워크시트)를 포함하거나 링크하도록 합니다.

**Aspose.Slides로 프레젠테이션을 저장한 후에도 ActiveX 이벤트가 VBA 매크로를 트리거합니까?**

VBA 프로젝트를 유지하려면 PPTM과 같은 매크로 사용 가능 형식으로 프레젠테이션을 저장하십시오. Windows용 PowerPoint는 보안 설정에서 ActiveX 컨트롤과 매크로가 모두 허용될 때 기존 이벤트 처리기를 실행할 수 있습니다.