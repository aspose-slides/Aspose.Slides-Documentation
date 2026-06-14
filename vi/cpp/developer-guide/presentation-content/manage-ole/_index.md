---
title: Quản lý OLE trong Bản trình chiếu bằng C++
linktitle: Quản lý OLE
type: docs
weight: 40
url: /vi/cpp/manage-ole/
keywords:
- đối tượng OLE
- Liên kết & Nhúng Đối tượng
- thêm OLE
- nhúng OLE
- thêm đối tượng
- nhúng đối tượng
- thêm tệp
- nhúng tệp
- đối tượng liên kết
- tệp liên kết
- thay đổi OLE
- biểu tượng OLE
- tiêu đề OLE
- trích xuất OLE
- trích xuất đối tượng
- trích xuất tệp
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tối ưu hóa việc quản lý đối tượng OLE trong PowerPoint và các tệp OpenDocument với Aspose.Slides cho C++. Nhúng, cập nhật và xuất nội dung OLE một cách liền mạch."
---
## **Giới thiệu**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) là công nghệ của Microsoft cho phép dữ liệu và đối tượng được tạo trong một ứng dụng được đặt vào một ứng dụng khác thông qua việc liên kết hoặc nhúng.

{{% /alert %}}

Xem xét một biểu đồ được tạo trong MS Excel. Biểu đồ này sau đó được đặt vào một slide PowerPoint. Biểu đồ Excel đó được coi là một đối tượng OLE.

- Một đối tượng OLE có thể xuất hiện dưới dạng biểu tượng. Trong trường hợp này, khi bạn nhấp đúp biểu tượng, biểu đồ sẽ mở trong ứng dụng liên quan (Excel), hoặc bạn sẽ được yêu cầu chọn một ứng dụng để mở hoặc chỉnh sửa đối tượng.
- Một đối tượng OLE có thể hiển thị nội dung thực tế của nó, chẳng hạn như nội dung của một biểu đồ. Khi đó, biểu đồ được kích hoạt trong PowerPoint, giao diện biểu đồ tải lên và bạn có thể chỉnh sửa dữ liệu biểu đồ ngay trong PowerPoint.

[Aspose.Slides for C++](https://products.aspose.com/slides/vi/cpp/) cho phép bạn chèn các Đối Tượng OLE vào slide dưới dạng khung đối tượng OLE ([OleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/oleobjectframe/)).

## **Thêm Khung Đối Tượng OLE vào Slide**

Giả sử bạn đã tạo một biểu đồ trong Microsoft Excel và muốn nhúng nó vào một slide dưới dạng khung đối tượng OLE bằng Aspose.Slides for C++, bạn có thể thực hiện như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy tham chiếu tới slide thông qua chỉ số của nó.
3. Đọc tệp Excel dưới dạng mảng byte.
4. Thêm [OleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/oleobjectframe/) vào slide, truyền vào mảng byte và các thông tin khác về đối tượng OLE.
5. Ghi bản trình chiếu đã sửa đổi thành tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một biểu đồ từ tệp Excel vào slide dưới dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/oleobjectframe/) bằng Aspose.Slides for C++.
**Lưu ý** rằng constructor của [OleEmbeddedDataInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) nhận phần mở rộng của đối tượng có thể nhúng làm tham số thứ hai. Phần mở rộng này cho phép PowerPoint hiểu đúng loại tệp và chọn ứng dụng phù hợp để mở đối tượng OLE này.

``` cpp
auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Prepare data for the OLE object.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Thêm Khung Đối Tượng OLE Liên Kết**

Aspose.Slides for C++ cho phép bạn thêm một [OleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/oleobjectframe/) mà không nhúng dữ liệu mà chỉ có liên kết tới tệp.

Đoạn mã C++ này cho bạn thấy cách thêm một [OleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/oleobjectframe/) với tệp Excel được liên kết vào một slide:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Thêm khung đối tượng OLE với tệp Excel được liên kết.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Truy cập Khung Đối Tượng OLE**

Nếu một đối tượng OLE đã được nhúng trong một slide, bạn có thể dễ dàng tìm hoặc truy cập nó như sau:

1. Tải một bản trình chiếu có đối tượng OLE đã nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy tham chiếu của slide bằng cách sử dụng chỉ số của nó.
3. Truy cập hình dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/oleobjectframe/). Trong ví dụ của chúng tôi, chúng tôi đã sử dụng PPTX đã tạo trước có chỉ một hình dạng trên slide đầu tiên. Sau đó chúng tôi *cast* đối tượng đó thành [IOleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ioleobjectframe/). Đây là khung OLE mong muốn để truy cập.
4. Khi khung đối tượng OLE đã được truy cập, bạn có thể thực hiện bất kỳ thao tác nào trên nó.

Trong ví dụ dưới đây, một khung đối tượng OLE (đối tượng biểu đồ Excel được nhúng trong slide) và dữ liệu tệp của nó được truy cập.

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Lấy dữ liệu tệp được nhúng.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // Lấy phần mở rộng của tệp được nhúng.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **Truy cập Thuộc tính Khung Đối Tượng OLE Liên Kết**

Aspose.Slides cho phép bạn truy cập các thuộc tính của khung đối tượng OLE đã liên kết.

Đoạn mã C++ này cho bạn thấy cách kiểm tra xem một đối tượng OLE có được liên kết hay không và sau đó lấy đường dẫn tới tệp đã liên kết:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Kiểm tra xem đối tượng OLE có được liên kết hay không.
    if (oleFrame->get_IsObjectLink())
    {
        // In ra đường dẫn đầy đủ tới tệp được liên kết.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // In ra đường dẫn tương đối tới tệp được liên kết nếu có.
        // Chỉ các bản trình chiếu PPT mới có thể chứa đường dẫn tương đối.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **Thay đổi Dữ liệu Đối Tượng OLE**

{{% alert color="primary" %}} 

Trong phần này, ví dụ mã dưới đây sử dụng [Aspose.Cells for C++](/cells/cpp/).

{{% /alert %}}

Nếu một đối tượng OLE đã được nhúng trong một slide, bạn có thể dễ dàng truy cập đối tượng đó và sửa đổi dữ liệu của nó như sau:

1. Tải một bản trình chiếu có đối tượng OLE đã nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy tham chiếu của slide thông qua chỉ số của nó. 
3. Truy cập hình dạng [OLEObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/oleobjectframe/). Trong ví dụ của chúng tôi, chúng tôi đã sử dụng PPTX đã tạo trước có một hình dạng trên slide đầu tiên. Sau đó chúng tôi *cast* đối tượng đó thành [IOleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ioleobjectframe/). Đây là khung OLE mong muốn để truy cập.
4. Khi khung đối tượng OLE đã được truy cập, bạn có thể thực hiện bất kỳ thao tác nào trên nó.
5. Tạo một đối tượng `Workbook` và truy cập dữ liệu OLE.
6. Truy cập `Worksheet` mong muốn và chỉnh sửa dữ liệu.
7. Lưu `Workbook` đã cập nhật vào một luồng.
8. Thay đổi dữ liệu đối tượng OLE từ luồng.

Trong ví dụ dưới đây, một khung đối tượng OLE (đối tượng biểu đồ Excel được nhúng trong slide) được truy cập và dữ liệu tệp của nó được sửa đổi để cập nhật dữ liệu biểu đồ.

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Lấy hình dạng đầu tiên dưới dạng khung đối tượng OLE.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Đọc dữ liệu đối tượng OLE dưới dạng đối tượng Workbook.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Sửa đổi dữ liệu workbook.
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // Thay đổi dữ liệu đối tượng khung OLE.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Nhúng Các Loại Tệp Khác vào Slide**

Ngoài biểu đồ Excel, Aspose.Slides for C++ cho phép bạn nhúng các loại tệp khác vào slide. Ví dụ, bạn có thể chèn HTML, PDF và ZIP dưới dạng đối tượng. Khi người dùng nhấp đúp vào đối tượng đã chèn, nó sẽ tự động mở trong chương trình liên quan, hoặc người dùng sẽ được nhắc chọn một chương trình phù hợp để mở.

Đoạn mã C++ này cho bạn thấy cách nhúng HTML và ZIP vào một slide:

``` cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Đặt Kiểu Tệp cho Đối Tượng Được Nhúng**

Khi làm việc với bản trình chiếu, bạn có thể cần thay thế các đối tượng OLE cũ bằng đối tượng mới hoặc thay thế một đối tượng OLE không được hỗ trợ bằng một đối tượng được hỗ trợ. Aspose.Slides for C++ cho phép bạn đặt kiểu tệp cho một đối tượng đã nhúng, cho phép cập nhật dữ liệu khung OLE hoặc phần mở rộng của nó.

Đoạn mã C++ này cho bạn thấy cách đặt kiểu tệp cho một đối tượng OLE đã nhúng thành `zip`:

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// Thay đổi loại tệp thành ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Đặt Ảnh Biểu Tượng và Tiêu Đề cho Đối Tượng Được Nhúng**

Sau khi nhúng một đối tượng OLE, một bản xem trước gồm ảnh biểu tượng được thêm tự động. Bản xem trước này là những gì người dùng thấy trước khi truy cập hoặc mở đối tượng OLE. Nếu bạn muốn sử dụng một hình ảnh và văn bản cụ thể làm thành phần trong bản xem trước, bạn có thể đặt ảnh biểu tượng và tiêu đề bằng Aspose.Slides for C++.

Đoạn mã C++ này cho bạn thấy cách đặt ảnh biểu tượng và tiêu đề cho một đối tượng đã nhúng:

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Thêm hình ảnh vào tài nguyên bản trình chiếu.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Đặt tiêu đề và hình ảnh cho bản xem trước OLE.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ngăn Khung Đối Tượng OLE Bị Thay Đổi Kích Thước và Vị Trí**

Sau khi bạn thêm một đối tượng OLE liên kết vào một slide bản trình chiếu, khi mở bản trình chiếu trong PowerPoint, bạn có thể thấy một thông báo yêu cầu cập nhật các liên kết. Nhấp nút “Update Links” có thể thay đổi kích thước và vị trí của khung đối tượng OLE vì PowerPoint cập nhật dữ liệu từ đối tượng OLE đã liên kết và làm mới bản xem trước của đối tượng. Để ngăn PowerPoint hiển thị lời nhắc cập nhật dữ liệu của đối tượng, hãy đặt phương thức `set_UpdateAutomatic` của giao diện [IOleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ioleobjectframe/) thành `false`:

```cpp
oleFrame->set_UpdateAutomatic(false);
```

## **Trích xuất Các Tệp Đã Nhúng**

Aspose.Slides for C++ cho phép bạn trích xuất các tệp đã nhúng trong slide dưới dạng đối tượng OLE như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation) chứa các đối tượng OLE bạn muốn trích xuất.
2. Lặp qua tất cả các hình dạng trong bản trình chiếu và truy cập các hình dạng [OLEObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/oleobjectframe/).
3. Truy cập dữ liệu của các tệp đã nhúng từ khung đối tượng OLE và ghi chúng ra đĩa.

Đoạn mã C++ này cho bạn thấy cách trích xuất các tệp đã nhúng trong một slide dưới dạng đối tượng OLE:

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```

## **Câu hỏi thường gặp**

**Nội dung OLE có được hiển thị khi xuất slide sang PDF/hình ảnh không?**

Những gì hiển thị trên slide sẽ được render — biểu tượng/hình ảnh thay thế (bản xem trước). Nội dung OLE “sống” không được thực thi trong quá trình render. Nếu cần, hãy đặt ảnh xem trước riêng của bạn để đảm bảo hiển thị như mong muốn trong PDF đã xuất.

**Làm thế nào để khóa một đối tượng OLE trên slide sao cho người dùng không thể di chuyển/chỉnh sửa nó trong PowerPoint?**

Khóa hình dạng: Aspose.Slides cung cấp [các khóa ở mức hình dạng](/slides/vi/cpp/applying-protection-to-presentation/). Đây không phải là mã hóa, nhưng nó thực sự ngăn các chỉnh sửa và di chuyển vô tình.

**Tại sao một đối tượng Excel được liên kết “nhảy” hoặc thay đổi kích thước khi tôi mở bản trình chiếu?**

PowerPoint có thể làm mới bản xem trước của OLE liên kết. Để duy trì giao diện ổn định, hãy làm theo các thực hành của [Giải pháp Làm việc cho Việc Thay đổi Kích thước Worksheet](/slides/vi/cpp/working-solution-for-worksheet-resizing/) — hoặc vừa khung với phạm vi, hoặc thu phóng phạm vi vào khung cố định và đặt một ảnh thay thế phù hợp.

**Các đường dẫn tương đối cho các đối tượng OLE đã liên kết có được giữ lại trong định dạng PPTX không?**

Trong PPTX, thông tin “đường dẫn tương đối” không có — chỉ có đường dẫn đầy đủ. Các đường dẫn tương đối chỉ tồn tại trong định dạng PPT cũ. Để di động, nên sử dụng đường dẫn tuyệt đối đáng tin cậy/URI có thể truy cập hoặc nhúng.