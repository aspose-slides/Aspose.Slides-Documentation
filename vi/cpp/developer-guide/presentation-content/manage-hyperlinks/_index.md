---
title: Quản lý Siêu Liên Kết Bản Trình Chiếu trong C++
linktitle: Quản Lý Siêu Liên Kết
type: docs
weight: 20
url: /vi/cpp/manage-hyperlinks/
keywords:
- thêm URL
- thêm siêu liên kết
- tạo siêu liên kết
- định dạng siêu liên kết
- xóa siêu liên kết
- cập nhật siêu liên kết
- siêu liên kết văn bản
- siêu liên kết slide
- siêu liên kết hình dạng
- siêu liên kết hình ảnh
- siêu liên kết video
- siêu liên kết có thể thay đổi
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Thêm, định dạng, cập nhật và xóa siêu liên kết trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho C++, sử dụng các ví dụ C++."
---
## **Giới thiệu**

Một siêu liên kết kết nối nội dung bản trình chiếu với một trang web hoặc một vị trí trong bản trình chiếu. Trong PowerPoint, siêu liên kết thường phục vụ hai mục đích:

* Mở một trang web từ văn bản, hình dạng hoặc khung phương tiện.
* Điều hướng đến một slide khác, ví dụ, từ mục lục.

Aspose.Slides for C++ cho phép bạn thêm các liên kết này, kiểm soát giao diện và âm thanh của chúng, cập nhật cài đặt và xóa chúng. Các ví dụ dưới đây cho thấy cách làm việc với siêu liên kết trên các phần tử riêng lẻ và cách truy cập siêu liên kết ở cấp độ bản trình chiếu, slide hoặc khung văn bản.

{{% alert color="info" title="Note" %}}
Bạn cũng có thể chỉnh sửa bản trình chiếu với [trình chỉnh sửa PowerPoint trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/vi/editor).
{{% /alert %}} 

## **Thêm Siêu Liên Kết URL**

Bạn có thể gán một URL trang web cho văn bản, hình dạng hoặc khung phương tiện. Phần tử mà bạn gán siêu liên kết sẽ quyết định vùng có thể nhấp: một phần văn bản sẽ liên kết văn bản đã chọn, trong khi một hình dạng hoặc khung sẽ liên kết đối tượng slide.

### **Thêm Siêu Liên Kết URL vào Văn Bản**

Để liên kết văn bản với một trang web, tạo một [Hyperlink](https://reference.aspose.com/slides/vi/cpp/aspose.slides/hyperlink/) và gán nó bằng phương thức [set_HyperlinkClick](https://reference.aspose.com/slides/vi/cpp/aspose.slides/portionformat/set_hyperlinkclick/) của phần văn bản, như được minh họa bên dưới. Chỉ phần văn bản đó sẽ trở thành có thể nhấp.

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

### **Thêm Siêu Liên Kết URL vào Hình Dạng và Khung Phương Tiện**

Để làm cho một hình dạng hoặc khung có thể nhấp, sử dụng phương thức [set_HyperlinkClick](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/set_hyperlinkclick/) của nó. Siêu liên kết thuộc về đối tượng đó thay vì một phần văn bản bên trong.

Cùng một cách tiếp cận áp dụng cho khung ảnh, âm thanh và video: gán siêu liên kết cho khung và sử dụng [set_Tooltip](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlink/set_tooltip/) để thêm gợi ý nếu cần.

Ví dụ dưới đây làm cho một hình chữ nhật có thể nhấp:

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

## **Sử Dụng Siêu Liên Kết Để Tạo Mục Lục**

Siêu liên kết nội bộ cho phép người đọc nhảy từ mục lục đến một slide cụ thể. Ví dụ dưới đây sử dụng [SetInternalHyperlinkClick](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) để liên kết văn bản “Page 2” trên slide đầu tiên tới slide thứ hai.

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

## **Định Dạng Siêu Liên Kết**

### **Màu**

Phương thức [set_ColorSource](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlink/set_colorsource/) của [IHyperlink](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlink/) quyết định liệu siêu liên kết có sử dụng màu siêu liên kết của bản trình chiếu hay định dạng của phần văn bản. Để áp dụng màu văn bản tùy chỉnh, chọn [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/hyperlinkcolorsource/) và đặt màu nền cho phần. Tính năng này được giới thiệu trong PowerPoint 2019; các phiên bản cũ hơn không áp dụng cài đặt này.

Ví dụ dưới đây thêm hai siêu liên kết văn bản vào cùng một slide. Siêu liên kết đầu tiên sử dụng màu nền văn bản đỏ, trong khi siêu liên kết thứ hai giữ màu siêu liên kết mặc định.

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
### **Âm Thanh**

Một siêu liên kết có thể phát âm thanh khi được kích hoạt hoặc dừng âm thanh đang phát. Sử dụng các phương thức sau để cấu hình các hành vi này:

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlink/set_sound/) xác định âm thanh liên kết với siêu liên kết.
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) kiểm soát việc kích hoạt siêu liên kết có dừng âm thanh trước đó hay không.

#### **Thêm Âm Thanh Siêu Liên Kết**

Ví dụ dưới đây tải `sampleaudio.wav` và gán nó với một nút trên slide đầu tiên. Khi nhấp vào nút, âm thanh phát và chuyển đến slide tiếp theo. Một hình dạng thứ hai trên slide đó dừng âm thanh trước khi nhấp, mà không thực hiện hành động điều hướng nào.

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

#### **Trích Xuất Âm Thanh Siêu Liên Kết**

Ví dụ dưới đây mở bản trình chiếu đã được tạo ở trên và đọc âm thanh siêu liên kết của hình dạng đầu tiên vào bộ nhớ thông qua [get_Sound](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlink/get_sound/) và [get_BinaryData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iaudio/get_binarydata/).

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

### **Tooltip và Cài Đặt Tương Tác**

Bạn có thể cập nhật các cài đặt [IHyperlink] sau thông qua các phương thức này sau khi gán một siêu liên kết cho văn bản hoặc hình dạng:

- [set_Tooltip](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlink/set_tooltip/) đặt văn bản mà người xem có thể hiển thị như một gợi ý cho liên kết.
- [set_TargetFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlink/set_targetframe/) xác định khung mục tiêu trong một khung HTML cha, nếu có.
- [set_History](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlink/set_history/) kiểm soát việc kích hoạt liên kết có đưa đích của nó vào danh sách các siêu liên kết đã xem hay không.
- [set_HighlightClick](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlink/set_highlightclick/) kiểm soát việc siêu liên kết có được tô sáng khi nhấp hay không.

## **Xóa Siêu Liên Kết Khỏi Bản Trình Chiếu**

Sử dụng [GetAnyHyperlinks](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) để thu thập các container siêu liên kết, bao gồm các liên kết phần văn bản, trước khi thay đổi chúng. Ví dụ dưới đây xóa cả hai loại kích hoạt khỏi slide đầu tiên. Để xóa chỉ một loại, chỉ gọi [RemoveHyperlinkClick](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) hoặc [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); việc xóa hành động nhấp không xóa hành động di chuột.

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

Đối với việc xóa không điều kiện, [RemoveAllHyperlinks](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) xóa cả hai loại kích hoạt trong phạm vi đã chọn trong một lần gọi. Đối với việc dọn dẹp chọn lọc và bao phủ các master, layout và ghi chú, xem mục [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Xây Dựng Kiểm Kê Siêu Liên Kết Đầy Đủ**

Trước khi phát hành một bản trình chiếu, hãy kiểm kê các hành động tương tác cũng như các liên kết web của nó. [GetAnyHyperlinks](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) trả về các đối tượng [IHyperlinkContainer](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlinkcontainer/), không phải danh sách phẳng các chuỗi URL. Kiểm tra cả [get_HyperlinkClick](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) và [get_HyperlinkMouseOver](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) trên mỗi container. Chúng là độc lập: cùng một container có thể hiển thị cả hai hành động, vì vậy báo cáo đầy đủ có thể cần tới hai hàng cho mỗi container.

Quét chỉ các siêu liên kết ở mức hình dạng có thể bỏ lỡ các liên kết được đính kèm vào các phần văn bản. Thay vào đó, truy vấn phạm vi thích hợp và giữ lại các container trả về để bạn có thể cập nhật hoặc xóa các hành động của chúng sau này.

### **Truy Vấn Phạm Vi Bản Trình Chiếu, Slide và Khung Văn Bản**

Giao diện [IHyperlinkQueries](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlinkqueries/) có sẵn qua [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/), [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/), và [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/get_hyperlinkqueries/). Mỗi phạm vi hỗ trợ cùng các truy vấn:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) trả về các container có hành động nhấp.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) trả về các container có hành động di chuột.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) trả về các container có một trong hai hoặc cả hai hành động.

Ví dụ dưới đây tạo `hyperlink-audit-input.pptx` với một liên kết nhấp ngoài, một liên kết di chuột tệp, điều hướng slide nội bộ, một liên kết di chuột văn bản, và một hành động macro. Nó không thực thi bất kỳ hành động nào trong số này. Cả ba truy vấn đều hoạt động ở mọi phạm vi; các số đếm mô tả các container, không phải tổng số hành động. Phạm vi khung văn bản loại trừ các liên kết riêng của hình dạng bao quanh.

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

Đối với ví dụ này, các truy vấn bản trình chiếu và slide mỗi đều báo cáo ba container nhấp, hai container di chuột, và ba container có một trong hai hành động. Truy vấn khung văn bản báo cáo một container trong mỗi danh mục.

### **Phân Loại Hành Động và Đích Đến**

Sử dụng [IHyperlink::get_ActionType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlink/get_actiontype/) để giải thích một hành động trước khi giải thích đích đến của nó. Các giá trị [HyperlinkActionType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/hyperlinkactiontype/) bao gồm hơn chỉ việc điều hướng web:

| Giá Trị | Ý Nghĩa cho Kiểm Kê |
| --- | --- |
| `Hyperlink` | Siêu liên kết ngoại; kiểm tra URL và scheme của nó. |
| `JumpSpecificSlide` | Điều hướng nội bộ đến một slide cụ thể. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Điều hướng trình chiếu tích hợp, được giải quyết trong ngữ cảnh trình chiếu. |
| `JumpEndShow`, `StartCustomSlideShow` | Kết thúc trình chiếu hiện tại hoặc bắt đầu một trình chiếu tùy chỉnh. |
| `StartMacro` | Thực thi một macro. |
| `StartProgram` | Khởi chạy một chương trình. |
| `OpenFile`, `OpenPresentation` | Mở một tệp hoặc một bản trình chiếu khác; xem xét riêng so với URL web. |
| `StartStopMedia` | Bắt đầu hoặc dừng phát media. |
| `NoAction`, `Unknown` | Không có hành động điều hướng, hoặc một hành động không xác định cần xem xét. |

Đọc đích ngoại từ [get_ExternalUrl](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlink/get_externalurl/) và đích nội bộ cụ thể từ [get_TargetSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlink/get_targetslide/). Các hành động nội bộ và lệnh tích hợp có thể không có URL ngoại; URL rỗng không có nghĩa là container không có hành động. Bảo tồn [get_ExternalUrlOriginal](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) khi nó khác với URL đã chuẩn hoá, và bao gồm tooltip trả về bởi [get_Tooltip](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlink/get_tooltip/) khi có.

### **Báo Cáo, Làm Sạch và Xác Nhận Siêu Liên Kết**

Ví dụ C++ dưới đây đọc một bản trình chiếu hiện có (sử dụng tệp đã tạo ở trên), ghi `hyperlink-audit.json`, áp dụng chính sách, lưu `hyperlink-sanitized.pptx`, và mở lại để kiểm tra cả hai loại kích hoạt một lần nữa. Nó thu thập các container trước khi thay đổi và sử dụng định danh con trỏ để tránh xử lý cùng một container hai lần. Các truy vấn bản trình chiếu bao phủ các slide thường; để có một kiểm kê toàn gói, nó cũng truy vấn một cách rõ ràng các master, layout, notes và các master notes và handout khi có.

Báo cáo ghi lại chỉ mục slide bắt đầu từ 1 và [get_SlideId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseslide/get_slideid/) khi có. [ISlideComponent::get_Slide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecomponent/get_slide/) cung cấp slide sở hữu cho các container được hỗ trợ. Các master, layout và notes không có chỉ mục slide thường và được xác định bằng phạm vi của chúng. Các container hình dạng và container định dạng phần văn bản được gắn nhãn riêng; các loại container khác giữ tên kiểu thời gian chạy. Mỗi container nhận một ID cục bộ trong báo cáo để hai hành động của nó có thể được liên kết.

Chính sách ứng dụng có tính hạn chế này chỉ cho phép URL HTTPS tuyệt đối và các đích slide nội bộ hợp lệ. Nó loại bỏ macro, chương trình, hành động tệp, các hành động trình chiếu khác, hành động không xác định và các scheme URL khác. Những loại loại bỏ này là quyết định chính sách, không phải phán quyết an toàn của Aspose.Slides. HTTPS một mình không tạo niềm tin: hãy thêm danh sách cho phép host và các kiểm tra khác cho ứng dụng của bạn. Cả URL ngoại gốc và đã chuẩn hoá đều được kiểm tra. Ví dụ kiểm toán siêu dữ liệu mà không theo liên kết hay chạy hành động.

Để khắc phục, [get_HyperlinkManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) của container hỗ trợ [SetExternalHyperlinkClick](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) và [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Ở đây, các liên kết nhấp ngoại bị cấm được thay thế bằng một trang đích HTTPS cố định; các nhấp và hành động di chuột bị cấm khác được xóa độc lập. Đặt `replaceExternalClicks` thành `false` để xóa tất cả vi phạm chính sách. Chọn một trang thay thế do ứng dụng sở hữu trước khi triển khai.

Cờ xuất báo cáo sử dụng chính sách xem xét PDF bảo thủ: đánh dấu các hành động di chuột và bất kỳ gì không phải là liên kết ngoại hoặc chuyển đến slide cụ thể là có khả năng không được hỗ trợ. Đây là gợi ý xem xét, không phải kiểm tra khả năng hay bảo đảm các liên kết chưa được đánh dấu sẽ tồn tại khi xuất. Các xuất PDF và HTML được hỗ trợ có thể giữ lại siêu liên kết, tùy thuộc vào hành động, tùy chọn xuất và trình xem. Các ảnh raster và video không thể giữ lại siêu liên kết tương tác; hãy đánh dấu mọi hành động khi kiểm toán cho các đầu ra đó.

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

Với dữ liệu đầu vào đã tạo ở trên, báo cáo chứa năm hàng hành động. Liên kết di chuột tệp và macro nhấp bị xóa, trong khi các liên kết HTTPS và điều hướng slide nội bộ vẫn còn. Kiểm tra in ra không có hành động bị cấm. Một đầu vào chứa URL nhấp ngoại bị cấm cũng kích hoạt nhánh thay thế. Một container có nhấp được cho phép và di chuột bị cấm vẫn giữ hành động nhấp.

Sự dọn dẹp chọn lọc này khác với [RemoveAllHyperlinks](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), cái mà xóa cả hai loại kích hoạt trong phạm vi đã chọn bất kể chính sách. Kiểm tra ở đây chỉ xem xét các hành động siêu liên kết; nó không xóa các dự án VBA nhúng, đối tượng OLE hoặc nội dung hoạt động khác, và không xác thực tệp PDF hoặc HTML đã xuất.

## **Câu Hỏi Thường Gặp**

**Làm sao tôi có thể liên kết tới một phần hoặc slide đầu tiên của nó?**

Các phần trong PowerPoint nhóm các slide lại với nhau, nhưng một siêu liên kết nội bộ chỉ nhắm tới một slide riêng lẻ. Để tạo điều hướng tới một phần, hãy liên kết tới slide đầu tiên trong phần đó.

**Tôi có thể gắn siêu liên kết vào các yếu tố slide master để nó hoạt động trên tất cả các slide không?**

Có. Các yếu tố slide master và layout hỗ trợ siêu liên kết. Các liên kết trên những yếu tố này sẽ có sẵn trong chế độ trình chiếu trên các slide sử dụng master hoặc layout tương ứng.

**Liệu siêu liên kết có được giữ lại khi xuất ra PDF, HTML, hình ảnh hoặc video không?**

Các xuất PDF và HTML được hỗ trợ có thể giữ lại siêu liên kết; hình ảnh raster và video không thể. Xem các lưu ý xuất trong [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).