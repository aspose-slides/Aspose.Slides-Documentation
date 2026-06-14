---
title: Quản lý các điều khiển ActiveX trong bài thuyết trình bằng C++
linktitle: ActiveX
type: docs
weight: 80
url: /vi/cpp/activex/
keywords:
- ActiveX
- điều khiển ActiveX
- quản lý ActiveX
- thêm ActiveX
- sửa đổi ActiveX
- trình phát đa phương tiện
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tìm hiểu cách Aspose.Slides for C++ sử dụng ActiveX để tự động hoá và nâng cao các bài thuyết trình PowerPoint, cung cấp cho nhà phát triển khả năng kiểm soát mạnh mẽ các slide."
---
## **Introduction**

Các điều khiển ActiveX được sử dụng trong bài thuyết trình. Aspose.Slides for C++ cho phép bạn quản lý các điều khiển ActiveX, nhưng việc quản lý chúng hơi phức tạp hơn và khác so với các hình dạng thông thường trong bài thuyết trình. Từ Aspose.Slides for C++ 18.1, thành phần này hỗ trợ quản lý các điều khiển ActiveX. Hiện tại, bạn có thể truy cập các điều khiển ActiveX đã được thêm vào trong bài thuyết trình và sửa đổi hoặc xóa chúng bằng cách sử dụng các thuộc tính khác nhau. Lưu ý, các điều khiển ActiveX không phải là hình dạng và không thuộc IShapeCollection của bài thuyết trình mà là IControlCollection riêng biệt. Bài viết này trình bày cách làm việc với chúng.

## **Modify an ActiveX Control**
Để quản lý một điều khiển ActiveX đơn giản như hộp văn bản và nút lệnh đơn giản trên một slide:

1. Tạo một thể hiện của lớp Presentation và tải bài thuyết trình có chứa các điều khiển ActiveX.  
2. Lấy tham chiếu đến slide theo chỉ mục của nó.  
3. Truy cập các điều khiển ActiveX trong slide bằng cách truy cập IControlCollection.  
4. Truy cập điều khiển ActiveX TextBox1 bằng đối tượng ControlEx.  
5. Thay đổi các thuộc tính khác nhau của điều khiển ActiveX TextBox1 bao gồm văn bản, phông chữ, chiều cao phông và vị trí khung.  
6. Truy cập điều khiển truy cập thứ hai có tên CommandButton1.  
7. Thay đổi chú thích nút, phông chữ và vị trí.  
8. Di chuyển vị trí của các khung điều khiển ActiveX.  
9. Ghi bài thuyết trình đã sửa đổi vào tệp PPTX.

Đoạn mã mẫu dưới đây cập nhật các điều khiển ActiveX trên các slide của bài thuyết trình như được hiển thị bên dưới.

``` cpp
// Truy cập bài thuyết trình có các điều khiển ActiveX
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// Truy cập slide đầu tiên trong bài thuyết trình
auto slide = presentation->get_Slides()->idx_get(0);

// thay đổi văn bản TextBox
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // thay đổi ảnh thay thế. Powerpoint sẽ thay thế ảnh này khi kích hoạt ActiveX, vì vậy đôi khi có thể để nguyên ảnh.
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Window));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    graphics->DrawString(newText, font, brush, 10.0f, 4.0f);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);

    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// thay đổi nhãn nút
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // thay đổi ảnh thay thế
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Control));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    SizeF textSize = graphics->MeasureString(newCaption, font, std::numeric_limits<int32_t>::max());
    graphics->DrawString(newCaption, font, brush, (image->get_Width() - textSize.get_Width()) / 2, (image->get_Height() - textSize.get_Height()) / 2);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// Di chuyển khung ActiveX xuống dưới 100 điểm
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// Lưu bài thuyết trình với các điều khiển ActiveX đã chỉnh sửa
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// Bây giờ đang xóa các điều khiển
slide->get_Controls()->Clear();

// Lưu bài thuyết trình với các điều khiển ActiveX đã xóa
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **Add an Media Player ActiveX Control**
Các điều khiển ActiveX được sử dụng trong bài thuyết trình. Aspose.Slides for C++ cho phép bạn thêm và quản lý các điều khiển ActiveX, nhưng việc quản lý chúng hơi phức tạp hơn và khác so với các hình dạng thông thường trong bài thuyết trình. Từ Aspose.Slides for C++ 18.1, hỗ trợ thêm điều khiển Media Player ActiveX đã được thêm vào Aspose.Slides. Lưu ý, các điều khiển ActiveX không phải là hình dạng và không thuộc IShapeCollection của bài thuyết trình mà là IControlExCollection riêng biệt. Bài viết này trình bày cách làm việc với chúng. Để quản lý một điều khiển Media Player ActiveX, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp Presentation và tải mẫu bài thuyết trình có chứa các điều khiển Media Player ActiveX.  
2. Tạo một thể hiện của lớp Presentation đích và tạo một bài thuyết trình trống.  
3. Sao chép slide chứa điều khiển Media Player ActiveX trong mẫu bài thuyết trình sang Presentation đích.  
4. Truy cập slide đã sao chép trong Presentation đích.  
5. Truy cập các điều khiển ActiveX trong slide bằng cách truy cập IControlCollection.  
6. Truy cập điều khiển Media Player ActiveX và đặt đường dẫn video bằng cách sử dụng các thuộc tính của nó.  
7. Lưu bài thuyết trình vào tệp PPTX.

``` cpp
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// Tạo một thể hiện bài thuyết trình trống
auto newPresentation = System::MakeObject<Presentation>();

// Xóa slide mặc định
newPresentation->get_Slides()->RemoveAt(0);

// Sao chép slide có điều khiển Media Player ActiveX
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// Truy cập điều khiển Media Player ActiveX và đặt đường dẫn video
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// Lưu bài thuyết trình
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Aspose.Slides có giữ lại các điều khiển ActiveX khi đọc và lưu lại nếu chúng không thể thực thi trong môi trường C++ không?**  
Có. Aspose.Slides coi chúng là một phần của bài thuyết trình và có thể đọc/điều chỉnh các thuộc tính và khung của chúng; không cần thực thi các điều khiển để giữ chúng lại.

**Các điều khiển ActiveX khác gì so với đối tượng OLE trong một bài thuyết trình?**  
Các điều khiển ActiveX là các điều khiển tương tác được quản lý (nút, hộp văn bản, trình phát media), trong khi [OLE](/slides/vi/cpp/manage-ole/) đề cập đến các đối tượng ứng dụng nhúng (ví dụ, một bảng tính Excel). Chúng được lưu trữ và xử lý khác nhau và có mô hình thuộc tính khác nhau.

**Các sự kiện ActiveX và macro VBA có hoạt động nếu tệp đã được Aspose.Slides sửa đổi không?**  
Aspose.Slides giữ lại phần đánh dấu và siêu dữ liệu hiện có; tuy nhiên, các sự kiện và macro chỉ chạy trong PowerPoint trên Windows khi bảo mật cho phép. Thư viện không thực thi VBA.