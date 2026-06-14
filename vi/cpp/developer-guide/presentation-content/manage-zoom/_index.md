---
title: Quản lý Zoom trong bản trình bày bằng C++
linktitle: Quản lý Zoom
type: docs
weight: 60
url: /vi/cpp/manage-zoom/
keywords:
- thu phóng
- khung thu phóng
- thu phóng slide
- thu phóng phần
- thu phóng tổng hợp
- thêm thu phóng
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Tạo và tùy chỉnh Zoom với Aspose.Slides cho C++ — chuyển đổi giữa các phần, thêm ảnh thu nhỏ và chuyển động trong các bản trình bày PPT, PPTX và ODP."
---
## **Giới thiệu**

Zoom trong PowerPoint cho phép bạn chuyển đến và rời các slide, phần, và đoạn cụ thể của một bản trình bày. Khi bạn đang thuyết trình, khả năng điều hướng nhanh chóng qua nội dung này có thể rất hữu ích. 

![overview_image](Overview.png)

* Để tóm tắt toàn bộ bản trình bày trên một slide duy nhất, hãy sử dụng [Summary Zoom](#Summary-Zoom).
* Để chỉ hiển thị các slide đã chọn, hãy sử dụng [Slide Zoom](#Slide-Zoom).
* Để chỉ hiển thị một phần duy nhất, hãy sử dụng [Section Zoom](#Section-Zoom).

## **Slide Zoom**
Slide Zoom có thể làm cho bản trình bày của bạn trở nên năng động hơn, cho phép bạn điều hướng tự do giữa các slide theo bất kỳ thứ tự nào bạn muốn mà không làm gián đoạn luồng trình bày. Slide Zoom rất phù hợp cho các bản trình bày ngắn gọn mà không có nhiều phần, nhưng bạn vẫn có thể sử dụng chúng trong các kịch bản trình bày khác nhau.

Slide Zoom giúp bạn khám phá nhiều thông tin khác nhau trong khi vẫn cảm giác như đang trên một canvas duy nhất. 

![overview_image](slidezoomsel.png)

Đối với các đối tượng slide zoom, Aspose.Slides cung cấp enumeration [ZoomImageType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/zoomimagetype/), interface [IZoomFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/izoomframe/) và một số phương thức dưới interface [IShapeCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/).

### **Tạo Khung Zoom**

Bạn có thể thêm một khung zoom vào slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2.	Tạo các slide mới mà bạn dự định liên kết các khung zoom. 
3.	Thêm văn bản nhận dạng và nền vào các slide đã tạo.
4.	Thêm các khung zoom (chứa các tham chiếu đến các slide đã tạo) vào slide đầu tiên.
5.	Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

``` cpp 
void SetSlideBackground(SharedPtr<ISlide> slide, Color color)
{
    slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
    slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(color);
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
}
```

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Thêm các slide mới vào bản trình bày
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Tạo nền cho slide thứ hai
SetSlideBackground(slide2, Color::get_Cyan());

// Tạo hộp văn bản cho slide thứ hai
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Tạo nền cho slide thứ ba
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Tạo hộp văn bản cho slide thứ ba
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Thêm các đối tượng ZoomFrame objects
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Lưu bản trình bày
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Tạo Khung Zoom với Hình Ảnh Tùy Chỉnh**
Với Aspose.Slides for C++, bạn có thể tạo một khung zoom với hình ảnh xem trước slide khác nhau theo cách sau: 
1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2.	Tạo một slide mới mà bạn dự định liên kết khung zoom. 
3.	Thêm văn bản nhận dạng và nền vào slide.
4.	Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) bằng cách thêm một hình ảnh vào bộ sưu tập Images liên kết với đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) sẽ được dùng để lấp đầy khung.
5.	Thêm các khung zoom (chứa tham chiếu tới slide đã tạo) vào slide đầu tiên.
6.	Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Thêm một slide mới vào bản trình bày
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Tạo nền cho slide thứ hai
SetSlideBackground(slide, Color::get_Cyan());

// Tạo hộp văn bản cho slide thứ ba
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Tạo một hình ảnh mới cho đối tượng zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//Thêm đối tượng ZoomFrame object
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// Lưu bản trình bày
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Định Dạng Khung Zoom**
Trong các phần trước, chúng tôi đã hướng dẫn bạn cách tạo các khung zoom đơn giản. Để tạo các khung zoom phức tạp hơn, bạn phải thay đổi định dạng của một khung đơn giản. Có một số tùy chọn định dạng bạn có thể áp dụng cho khung zoom. 

Bạn có thể kiểm soát định dạng của khung zoom trên slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2.	Tạo các slide mới để liên kết mà bạn dự định liên kết khung zoom. 
3.	Thêm một số văn bản nhận dạng và nền vào các slide đã tạo.
4.	Thêm các khung zoom (chứa các tham chiếu đến các slide đã tạo) vào slide đầu tiên.
5.	Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) bằng cách thêm một hình ảnh vào bộ sưu tập Images liên kết với đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) sẽ được dùng để lấp đầy khung.
6.	Đặt hình ảnh tùy chỉnh cho đối tượng khung zoom đầu tiên.
7.	Thay đổi định dạng đường viền cho đối tượng khung zoom thứ hai.
8.	Loại bỏ nền khỏi hình ảnh của đối tượng khung zoom thứ hai.
5.	Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//Thêm các slide mới vào bản trình bày
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// Tạo nền cho slide thứ hai
SetSlideBackground(slide2, Color::get_Cyan());

// Tạo hộp văn bản cho slide thứ hai
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Tạo nền cho slide thứ ba
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Tạo hộp văn bản cho slide thứ ba
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Thêm các đối tượng ZoomFrame
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Tạo một hình ảnh mới cho đối tượng zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// Đặt hình ảnh tùy chỉnh cho đối tượng zoomFrame1
zoomFrame1->set_Image(image);

// Đặt định dạng khung zoom cho đối tượng zoomFrame2
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// Cài đặt không hiển thị nền cho đối tượng zoomFrame2
zoomFrame2->set_ShowBackground(false);

// Lưu bản trình bày
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Section Zoom**

Section Zoom là một liên kết tới một phần trong bản trình bày của bạn. Bạn có thể sử dụng Section Zoom để quay lại các phần mà bạn muốn nhấn mạnh thực sự. Hoặc bạn có thể dùng chúng để làm nổi bật cách các phần của bản trình bày kết nối với nhau. 

![overview_image](seczoomsel.png)

Đối với các đối tượng section zoom, Aspose.Slides cung cấp interface [ISectionZoomFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isectionzoomframe/) và một số phương thức dưới interface [IShapeCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/).

### **Tạo Khung Section Zoom**

Bạn có thể thêm một khung section zoom vào slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2.	Tạo một slide mới. 
3.	Thêm nền nhận dạng vào slide đã tạo.
4.	Tạo một phần mới mà bạn dự định liên kết khung zoom. 
5.	Thêm một khung section zoom (chứa các tham chiếu đến phần đã tạo) vào slide đầu tiên.
6.	Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Thêm một slide mới vào bản trình bày
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Thêm một Section mới vào bản trình bày
pres->get_Sections()->AddSection(u"Section 1", slide);

// Thêm một đối tượng SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Lưu bản trình bày
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```
### **Tạo Khung Section Zoom với Hình Ảnh Tùy Chỉnh**

Sử dụng Aspose.Slides for C++, bạn có thể tạo một khung section zoom với hình ảnh xem trước slide khác nhau theo cách sau: 

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2.	Tạo một slide mới.
3.	Thêm nền nhận dạng vào slide đã tạo.
4.	Tạo một phần mới mà bạn dự định liên kết khung zoom. 
5.	Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) bằng cách thêm một hình ảnh vào bộ sưu tập Images liên kết với đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) sẽ được dùng để lấp đầy khung.
5.	Thêm một khung section zoom (chứa một tham chiếu đến phần đã tạo) vào slide đầu tiên.
6.	Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Thêm slide mới vào bản trình bày
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Thêm một Section mới vào bản trình bày
pres->get_Sections()->AddSection(u"Section 1", slide);

// Tạo một hình ảnh mới cho đối tượng zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Thêm đối tượng SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// Lưu bản trình bày
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Định Dạng Khung Section Zoom**

Để tạo các khung section zoom phức tạp hơn, bạn phải thay đổi định dạng của một khung đơn giản. Có một số tùy chọn định dạng bạn có thể áp dụng cho khung section zoom. 

Bạn có thể kiểm soát định dạng của khung section zoom trên slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2.	Tạo một slide mới.
3.	Thêm nền nhận dạng vào slide đã tạo.
4.	Tạo một phần mới mà bạn dự định liên kết khung zoom. 
5.	Thêm một khung section zoom (chứa các tham chiếu đến phần đã tạo) vào slide đầu tiên.
6.	Thay đổi kích thước và vị trí cho đối tượng section zoom đã tạo.
7.	Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) bằng cách thêm một hình ảnh vào bộ sưu tập Images liên kết với đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) sẽ được dùng để lấp đầy khung.
8.	Đặt hình ảnh tùy chỉnh cho đối tượng khung section zoom đã tạo.
9.	Đặt *khả năng quay lại slide gốc từ phần đã liên kết*.
10.	Loại bỏ nền khỏi hình ảnh của đối tượng khung section zoom.
11.	Thay đổi định dạng đường viền cho đối tượng khung zoom thứ hai.
12.	Thay đổi thời gian chuyển đổi.
13.	Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Thêm slide mới vào bản trình bày
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Thêm một Section mới vào bản trình bày
pres->get_Sections()->AddSection(u"Section 1", slide);

// Thêm đối tượng SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Định dạng cho SectionZoomFrame
sectionZoomFrame->set_X(100.0f);
sectionZoomFrame->set_Y(300.0f);
sectionZoomFrame->set_Width(100.0f);
sectionZoomFrame->set_Height(75.0f);

auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
sectionZoomFrame->set_Image(image);

sectionZoomFrame->set_ReturnToParent(true);
sectionZoomFrame->set_ShowBackground(false);

auto sectionZoomLineFormat = sectionZoomFrame->get_LineFormat();
sectionZoomLineFormat->get_FillFormat()->set_FillType(FillType::Solid);
sectionZoomLineFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
sectionZoomLineFormat->set_DashStyle(LineDashStyle::DashDot);
sectionZoomLineFormat->set_Width(2.5f);

sectionZoomFrame->set_TransitionDuration(1.5f);

// Lưu bản trình bày
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Summary Zoom**

Summary Zoom giống như một trang đích nơi tất cả các phần của bản trình bày được hiển thị cùng một lúc. Khi bạn đang thuyết trình, bạn có thể sử dụng zoom để chuyển từ một vị trí trong bản trình bày sang vị trí khác theo bất kỳ thứ tự nào bạn muốn. Bạn có thể sáng tạo, bỏ qua hoặc quay lại các phần của slide show mà không làm gián đoạn luồng trình bày.

![overview_image](sumzoomsel.png)

Đối với các đối tượng summary zoom, Aspose.Slides cung cấp các interface [ISummaryZoomFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isummaryzoomframe/), [ISummaryZoomSection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isummaryzoomsection/), và [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isummaryzoomsectioncollection/) và một số phương thức dưới interface [IShapeCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/).

### **Tạo Summary Zoom**

Bạn có thể thêm một khung summary zoom vào slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2.	Tạo các slide mới với nền nhận dạng và các phần mới cho các slide đã tạo.
3.	Thêm khung summary zoom vào slide đầu tiên.
4.	Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// Thêm slide mới vào bản trình bày
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Thêm một Section mới vào bản trình bày
pres->get_Sections()->AddSection(u"Section 1", slide);

// Thêm slide mới vào bản trình bày
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Thêm một Section mới vào bản trình bày
pres->get_Sections()->AddSection(u"Section 2", slide);

// Thêm slide mới vào bản trình bày
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Thêm một Section mới vào bản trình bày
pres->get_Sections()->AddSection(u"Section 3", slide);

// Thêm slide mới vào bản trình bày
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// Thêm một Section mới vào bản trình bày
pres->get_Sections()->AddSection(u"Section 4", slide);

// Thêm một đối tượng SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Lưu bản trình bày
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Thêm và Xóa một Section Summary Zoom**

Tất cả các phần trong một khung summary zoom được biểu diễn bằng các đối tượng [ISummaryZoomSection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isummaryzoomsection/), được lưu trong đối tượng [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isummaryzoomsectioncollection/). Bạn có thể thêm hoặc xóa một đối tượng section summary zoom thông qua interface [ISummaryZoomSectionCollection] theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2.	Tạo các slide mới với nền nhận dạng và các phần mới cho các slide đã tạo.
3.	Thêm một khung summary zoom vào slide đầu tiên.
4.	Thêm một slide và một phần mới vào bản trình bày.
5.	Thêm phần đã tạo vào khung summary zoom.
6.	Xóa phần đầu tiên khỏi khung summary zoom.
7.	Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Thêm slide mới vào bản trình bày
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Thêm một Section mới vào bản trình bày
pres->get_Sections()->AddSection(u"Section 1", slide);

//Thêm slide mới vào bản trình bày
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Thêm một Section mới vào bản trình bày
pres->get_Sections()->AddSection(u"Section 2", slide);

// Thêm đối tượng SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Thêm slide mới vào bản trình bày
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Thêm một Section mới vào bản trình bày
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// Thêm một Section vào Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Xóa Section khỏi Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// Lưu bản trình bày
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Định Dạng Các Section Summary Zoom**

Để tạo các đối tượng summary zoom section phức tạp hơn, bạn phải thay đổi định dạng của một khung đơn giản. Có một số tùy chọn định dạng bạn có thể áp dụng cho một đối tượng summary zoom section. 

Bạn có thể kiểm soát định dạng cho một đối tượng summary zoom section trong một khung summary zoom theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2.	Tạo các slide mới với nền nhận dạng và các phần mới cho các slide đã tạo.
3.	Thêm một khung summary zoom vào slide đầu tiên.
4.	Lấy một đối tượng summary zoom section cho đối tượng đầu tiên từ `ISummaryZoomSectionCollection`.
7.	Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) bằng cách thêm một hình ảnh vào bộ sưu tập images liên kết với đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) sẽ được dùng để lấp đầy khung.
8.	Đặt hình ảnh tùy chỉnh cho đối tượng khung section zoom đã tạo.
9.	Đặt *khả năng quay lại slide gốc từ phần đã liên kết*.
11.	Thay đổi định dạng đường viền cho đối tượng khung zoom thứ hai.
12.	Thay đổi thời gian chuyển đổi.
13.	Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Thêm slide mới vào bản trình bày
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Thêm một Section mới vào bản trình bày
pres->get_Sections()->AddSection(u"Section 1", slide);

//Thêm slide mới vào bản trình bày
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Thêm một Section mới vào bản trình bày
pres->get_Sections()->AddSection(u"Section 2", slide);

// Thêm đối tượng SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Lấy đối tượng SummaryZoomSection đầu tiên
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// Định dạng cho đối tượng SummaryZoomSection
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// Lưu bản trình bày
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Tôi có thể kiểm soát việc quay lại slide 'cha' sau khi hiển thị mục tiêu không?**

Có. [Zoom frame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/zoomframe/) hoặc [section](https://reference.aspose.com/slides/vi/cpp/aspose.slides/sectionzoomframe/) có phương thức `set_ReturnToParent` giúp đưa người xem trở lại slide gốc sau khi họ truy cập nội dung mục tiêu.

**Tôi có thể điều chỉnh 'tốc độ' hoặc thời lượng của chuyển đổi Zoom không?**

Có. Zoom hỗ trợ thiết lập thời lượng chuyển đổi để bạn có thể kiểm soát thời gian của hiệu ứng nhảy.

**Có giới hạn về số lượng đối tượng Zoom mà một bản trình bày có thể chứa không?**

Không có giới hạn API cứng được ghi chép. Các giới hạn thực tế phụ thuộc vào độ phức tạp tổng thể của bản trình bày và hiệu năng của thiết bị xem. Bạn có thể thêm nhiều khung Zoom, nhưng nên cân nhắc kích thước tệp và thời gian render.