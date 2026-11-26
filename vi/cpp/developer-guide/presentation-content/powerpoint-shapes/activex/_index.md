---
title: "Quản lý các điều khiển ActiveX trong bài thuyết trình bằng C++"
linktitle: "ActiveX"
type: docs
weight: 80
url: /vi/cpp/activex/
keywords:
- ActiveX
- Điều khiển ActiveX
- Quản lý ActiveX
- Thêm ActiveX
- Sửa đổi ActiveX
- Trình phát đa phương tiện
- PowerPoint
- Bài thuyết trình
- C++
- Aspose.Slides
description: "Chỉnh sửa hộp văn bản và nút ActiveX, cập nhật bản xem trước điều khiển, và tái sử dụng điều khiển Windows Media Player trong các bài thuyết trình PowerPoint với Aspose.Slides for C++."
---
## **Giới thiệu**

Các điều khiển ActiveX cung cấp cho một slide PowerPoint các yếu tố tương tác như hộp văn bản, nút lệnh và trình phát phương tiện. Aspose.Slides for C++ exposes a slide's controls through [IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/). Use this collection to edit a control, move it on the slide, or remove it.

## **Liệt kê các điều khiển ActiveX và các thuộc tính đã lưu**

Để kiểm tra một mẫu không quen thuộc, mở nó để đọc và lặp lại các điều khiển trên mỗi slide. Ví dụ báo cáo số slide, tên điều khiển, [ID lớp](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/), và mỗi cặp khóa-giá trị trong [các thuộc tính đã lưu](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/). Nó đọc bản trình chiếu mà không kích hoạt các điều khiển, gọi sự kiện hoặc macro, thay đổi giá trị, hoặc lưu tệp.

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

Kết quả đã chọn từ `ActiveX.pptm` hiển thị một hộp văn bản và một nút lệnh.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Một bộ sưu tập thuộc tính rỗng xuất hiện dưới dạng `[]`. Đối với các điều khiển sử dụng lưu trữ nhị phân, `get_Properties` có thể trả về `nullptr`, được hiển thị là `Properties unavailable`. Nếu bạn chỉ cần tên, hãy sử dụng [get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/) sau khi kiểm tra xem bộ sưu tập có tồn tại hay không. Báo cáo liệt kê các thuộc tính có sẵn từ bản trình chiếu. Một điều khiển có thể hỗ trợ các thuộc tính bổ sung tại thời gian chạy.

## **Chỉnh sửa các điều khiển ActiveX**

Ví dụ yêu cầu một bản trình chiếu hỗ trợ macro có một hộp văn bản có tên `TextBox1` và một nút lệnh có tên `CommandButton1` trên slide đầu tiên. Nó sử dụng [bộ sưu tập thuộc tính điều khiển](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) để thay đổi giá trị hộp văn bản và chú thích của nút. Mỗi điều khiển cũng có một bản xem trước tĩnh mà PowerPoint có thể hiển thị trước khi kích hoạt. Cung cấp một tệp PNG cho mỗi điều khiển để hiển thị văn bản và giao diện đã cập nhật. Ví dụ gán các hình ảnh này thông qua [IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/).

Ví dụ di chuyển mọi điều khiển trên slide đầu tiên xuống 100 điểm bằng cách thay đổi [khung](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/). Nó lưu bản trình chiếu đã chỉnh sửa ở định dạng PPTM, sau đó sử dụng [IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/) để lưu một bản sao thứ hai với tất cả các điều khiển ActiveX đã bị xóa khỏi slide đó.

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

## **Thêm một điều khiển Media Player ActiveX**

Để tái sử dụng một điều khiển Windows Media Player đã cấu hình, bắt đầu với một mẫu mà slide đầu tiên chứa một trình phát có tên `WindowsMediaPlayer1`. [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) sao chép toàn bộ slide vào một bản trình chiếu mới. Ví dụ đặt `URL` của trình phát trong [bộ sưu tập thuộc tính](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) và lưu slide đã sao chép làm slide duy nhất trong kết quả. Video vẫn ở ngoài, vì vậy hãy chọn một đường dẫn mà trình phát có thể truy cập trong quá trình phát.

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

## **Câu hỏi thường gặp**

**Aspose.Slides có thể giữ nguyên các điều khiển ActiveX mà không chạy chúng không?**

Có. Aspose.Slides có thể đọc và lưu các điều khiển, bao gồm các thuộc tính và vị trí của chúng, mà không kích hoạt chúng.

**Các điều khiển ActiveX khác gì so với các đối tượng OLE?**

Các điều khiển ActiveX cho phép người dùng tương tác với một slide, ví dụ bằng cách nhập văn bản hoặc nhấn nút. Một [đối tượng OLE](/slides/vi/cpp/manage-ole/) cho phép một slide chứa hoặc liên kết tới nội dung được quản lý bởi một ứng dụng khác, chẳng hạn như một bảng tính Excel.

**Các sự kiện ActiveX sẽ vẫn kích hoạt macro VBA sau khi tôi lưu một bản trình chiếu bằng Aspose.Slides không?**

Lưu bản trình chiếu ở định dạng hỗ trợ macro như PPTM để giữ lại dự án VBA của nó. PowerPoint cho Windows có thể chạy các trình xử lý sự kiện hiện có khi cài đặt bảo mật cho phép cả điều khiển ActiveX và macro.