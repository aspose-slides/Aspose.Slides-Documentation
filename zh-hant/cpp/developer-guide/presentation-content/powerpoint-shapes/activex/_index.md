---
title: 使用 C++ 管理簡報中的 ActiveX 控制項
linktitle: ActiveX
type: docs
weight: 80
url: /zh-hant/cpp/activex/
keywords:
- ActiveX
- ActiveX 控制項
- 管理 ActiveX
- 新增 ActiveX
- 修改 ActiveX
- 媒體播放器
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "編輯 ActiveX 文字方塊與按鈕、更新控制項預覽，並在 PowerPoint 簡報中使用 Aspose.Slides for C++ 重複使用 Windows Media Player 控制項。"
---
## **簡介**

ActiveX 控制項為 PowerPoint 投影片提供互動元素，例如文字方塊、指令按鈕與媒體播放器。Aspose.Slides for C++ 透過 [IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/) 讓您取得投影片的控制項。使用此集合可編輯控制項、在投影片上移動或移除它。

## **列出 ActiveX 控制項及其儲存屬性**

若要檢查不熟悉的範本，請以唯讀模式開啟並遍歷每張投影片上的控制項。範例會回報投影片編號、控制項名稱、[類別 ID](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/)，以及 [儲存屬性](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/) 中的每個鍵值對。它會在不啟動控制項、呼叫事件或巨集、變更值或儲存檔案的情況下讀取簡報。

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

從 `ActiveX.pptm` 中選取的輸出顯示了一個文字方塊和一個指令按鈕。

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

空的屬性集合會顯示為 `[]`。對於使用二進位儲存的控制項，`get_Properties` 可能會回傳 `nullptr`，顯示為 `Properties unavailable`。如果僅需要屬性名稱，請在確認集合存在後使用 [get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/)。報告列出簡報中可取得的屬性。控制項在執行時可能支援其他屬性。

## **修改 ActiveX 控制項**

此範例假設簡報為啟用巨集的檔案，且在第一張投影片上有名稱為 `TextBox1` 的文字方塊與名稱為 `CommandButton1` 的指令按鈕。它使用 [control properties collection](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) 變更文字方塊的值與按鈕的標題。每個控制項亦具有 PowerPoint 在啟動前可顯示的靜態預覽。請提供 PNG 圖檔顯示更新後的文字與外觀。範例透過 [IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/) 指定這些圖像。

範例會將第一張投影片上的所有控制項向下移動 100 點，方式是變更其[frame](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/)。它以 PPTM 格式儲存編輯後的簡報，然後使用 [IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/) 以儲存第二份已移除所有 ActiveX 控制項的副本。

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

## **新增 ActiveX 媒體播放器控制項**

若要重複使用已設定好的 Windows Media Player 控制項，請以第一張投影片包含名稱為 `WindowsMediaPlayer1` 的播放器之範本作為起點。[ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) 會將整張投影片複製到新簡報中。範例在其[properties collection](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) 中設定播放器的 `URL`，並將複製的投影片儲存為輸出的唯一投影片。影片保持外部連結，請選擇播放器在播放時能存取的路徑。

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

## **常見問題**

**Aspose.Slides 能在不執行 ActiveX 控制項的情況下保留它們嗎？**

是。Aspose.Slides 能在不啟動控制項的情況下讀取並儲存控制項，包括其屬性與位置。

**ActiveX 控制項與 OLE 物件有何不同？**

ActiveX 控制項讓使用者與投影片互動，例如輸入文字或點擊按鈕。 [OLE 物件](/slides/zh-hant/cpp/manage-ole/) 讓投影片包含或連結至其他應用程式管理的內容，例如 Excel 工作表。

**在使用 Aspose.Slides 儲存簡報後，ActiveX 事件仍會觸發 VBA 巨集嗎？**

請將簡報儲存為支援巨集的格式（如 PPTM）以保留 VBA 專案。當 Windows 版 PowerPoint 的安全性設定允許 ActiveX 控制項與巨集時，便會執行現有的事件處理常式。