---
title: "Quản lý Siêu liên kết trong Bản trình chiếu bằng C++"
linktitle: "Quản lý Siêu liên kết"
type: docs
weight: 20
url: /vi/cpp/manage-hyperlinks/
keywords:
- "thêm URL"
- "thêm siêu liên kết"
- "tạo siêu liên kết"
- "định dạng siêu liên kết"
- "xóa siêu liên kết"
- "cập nhật siêu liên kết"
- "siêu liên kết văn bản"
- "siêu liên kết slide"
- "siêu liên kết hình dạng"
- "siêu liên kết hình ảnh"
- "siêu liên kết video"
- "siêu liên kết có thể thay đổi"
- "PowerPoint"
- "OpenDocument"
- "bản trình chiếu"
- "C++"
- "Aspose.Slides"
description: "Quản lý siêu liên kết trong các bản trình chiếu PowerPoint và OpenDocument một cách dễ dàng với Aspose.Slides cho C++ - tăng cường tính tương tác và quy trình làm việc trong vài phút."
---
## **Giới thiệu**

Siêu liên kết là một tham chiếu tới một đối tượng hoặc dữ liệu hoặc một vị trí trong một tài liệu. Đây là các siêu liên kết phổ biến trong các bản trình chiếu PowerPoint:

* Liên kết tới các trang web trong văn bản, hình dạng hoặc phương tiện
* Liên kết tới các slide

Aspose.Slides cho C++ cho phép bạn thực hiện nhiều tác vụ liên quan đến siêu liên kết trong bài thuyết trình.

{{% alert color="primary" %}} 
Bạn có thể muốn kiểm tra Aspose đơn giản, [trình chỉnh sửa PowerPoint trực tuyến miễn phí.](https://products.aspose.app/slides/vi/editor)
{{% /alert %}} 

## **Thêm Siêu liên kết URL**

### **Thêm Siêu liên kết URL vào Văn bản**

Mã C++ này cho bạn thấy cách thêm một siêu liên kết trang web vào văn bản:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);
shape->AddTextFrame(u"Aspose: File Format APIs");

auto portionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
portionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **Thêm Siêu liên kết URL vào Hình dạng hoặc Khung**

Mã mẫu này bằng C++ cho bạn thấy cách thêm một siêu liên kết trang web vào một hình dạng:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

### **Thêm Siêu liên kết URL vào Phương tiện**

Aspose.Slides cho phép bạn thêm siêu liên kết vào hình ảnh, tệp âm thanh và video.

Mã mẫu này cho bạn thấy cách thêm một siêu liên kết vào **hình ảnh**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// Thêm hình ảnh vào bản trình chiếu
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
// Creates picture frame on slide 1 based on previously added image
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

Mã mẫu này cho bạn thấy cách thêm một siêu liên kết vào **tệp âm thanh**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

Mã mẫu này cho bạn thấy cách thêm một siêu liên kết vào **video**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto video = pres->get_Videos()->AddVideo(File::ReadAllBytes(u"video.avi"));
auto videoFrame = shapes->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

videoFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
videoFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

{{%  alert  title="Tip"  color="primary"  %}} 
Bạn có thể muốn xem *[Quản lý OLE](https://docs.aspose.com/slides/vi/cpp/manage-ole/)*.
{{% /alert %}}



## **Sử dụng Siêu liên kết để Tạo Mục Lục**

Vì siêu liên kết cho phép bạn thêm tham chiếu tới các đối tượng hoặc vị trí, bạn có thể sử dụng chúng để tạo một mục lục.

Mã mẫu này cho bạn thấy cách tạo một mục lục với các siêu liên kết:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto firstSlide = presentation->get_Slides()->idx_get(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto contentTable = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 300.0f, 100.0f);
contentTable->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
auto paragraphFillFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
paragraphFillFormat->set_FillType(FillType::Solid);
paragraphFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
contentTable->get_TextFrame()->get_Paragraphs()->Add(paragraph);
```


## **Định dạng Siêu liên kết**

### **Màu**

Với các phương thức [set_ColorSource()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac) và [get_ColorSource()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494) trong giao diện [IHyperlink](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_hyperlink), bạn có thể đặt màu cho siêu liên kết và cũng có thể lấy thông tin màu từ siêu liên kết. Tính năng này được giới thiệu lần đầu trong PowerPoint 2019, vì vậy các thay đổi liên quan đến thuộc tính này không áp dụng cho các phiên bản PowerPoint cũ hơn.

Mã mẫu này minh họa một thao tác trong đó các siêu liên kết có màu sắc khác nhau được thêm vào cùng một slide:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 450.0f, 50.0f, false);
shape1->AddTextFrame(u"This is a sample of colored hyperlink.");
auto shape1PortionFormat = shape1->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape1PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape1PortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
shape1PortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
shape1PortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 450.0f, 50.0f, false);
shape2->AddTextFrame(u"This is a sample of usual hyperlink.");
auto shape2PortionFormat = shape2->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape2PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```


## **Xóa Siêu liên kết khỏi Bài thuyết trình**

### **Xóa Siêu liên kết khỏi Văn bản**

Mã C++ này cho bạn thấy cách xóa siêu liên kết khỏi một văn bản trong slide bài thuyết trình:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);
    if (autoShape != nullptr)
    {
        for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
        {
            for (const auto& portion : paragraph->get_Portions())
            {
                auto hyperlinkManager = portion->get_PortionFormat()->get_HyperlinkManager();
                hyperlinkManager->RemoveHyperlinkClick();
            }
        }
    }
}

pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```

### **Xóa Siêu liên kết khỏi Hình dạng hoặc Khung**

Mã C++ này cho bạn thấy cách xóa siêu liên kết khỏi một hình dạng trong slide bài thuyết trình: 

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    shape->get_HyperlinkManager()->RemoveHyperlinkClick();
}
pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```



## **Siêu liên kết có thể thay đổi**

Lớp [Hyperlink](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.hyperlink) có thể thay đổi. Với lớp này, bạn có thể thay đổi giá trị cho các phương thức sau:

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

Đoạn mã này cho bạn thấy cách thêm một siêu liên kết vào slide và chỉnh sửa chú giải (tooltip) của nó sau này:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);

shape->AddTextFrame(u"Aspose: File Format APIs");

auto shapePortionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shapePortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shapePortionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
shapePortionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```




## **Các phương thức được hỗ trợ trong IHyperlinkQueries**

Bạn có thể truy cập IHyperlinkQueries từ một bài thuyết trình, slide hoặc văn bản mà siêu liên kết được định nghĩa. 

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

Lớp IHyperlinkQueries hỗ trợ các phương thức sau: 

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể tạo điều hướng nội bộ không chỉ tới một slide, mà còn tới một “phần” hoặc slide đầu tiên của một phần?**

Các phần trong PowerPoint là các nhóm slide; điều hướng về mặt kỹ thuật nhắm tới một slide cụ thể. Để “điều hướng tới một phần”, bạn thường liên kết tới slide đầu tiên của phần đó.

**Tôi có thể gắn siêu liên kết vào các thành phần của slide chủ để nó hoạt động trên tất cả các slide không?**

Có. Các thành phần của slide chủ và bố cục hỗ trợ siêu liên kết. Những liên kết này xuất hiện trên các slide con và có thể nhấp được trong chế độ trình chiếu.

**Liệu các siêu liên kết có được giữ lại khi xuất sang PDF, HTML, hình ảnh hoặc video không?**

Trong [PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/) và [HTML](/slides/vi/cpp/convert-powerpoint-to-html/), có—liên kết thường được giữ lại. Khi xuất sang [hình ảnh](/slides/vi/cpp/convert-powerpoint-to-png/) và [video](/slides/vi/cpp/convert-powerpoint-to-video/), khả năng nhấp sẽ không được chuyển tiếp do bản chất của các định dạng đó (khung raster/video không hỗ trợ siêu liên kết).