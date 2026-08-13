---
title: "Quản lý OLE trong bản trình bày bằng C++"
linktitle: "Quản lý OLE"
type: docs
weight: 40
url: /vi/cpp/manage-ole/
keywords:
- "đối tượng OLE"
- "Liên kết & Nhúng Đối tượng"
- "thêm OLE"
- "nhúng OLE"
- "thêm đối tượng"
- "nhúng đối tượng"
- "thêm tệp"
- "nhúng tệp"
- "đối tượng liên kết"
- "tệp liên kết"
- "thay đổi OLE"
- "biểu tượng OLE"
- "tiêu đề OLE"
- "trích xuất OLE"
- "trích xuất đối tượng"
- "trích xuất tệp"
- "PowerPoint"
- "bản trình bày"
- "C++"
- "Aspose.Slides"
description: "Tối ưu hóa quản lý đối tượng OLE trong PowerPoint và tệp OpenDocument với Aspose.Slides cho C++. Nhúng, cập nhật và xuất nội dung OLE một cách liền mạch."
---
## **Giới thiệu**

{{% alert title="Info" color="info" %}}
OLE (Object Linking & Embedding) là công nghệ của Microsoft cho phép dữ liệu và đối tượng được tạo trong một ứng dụng được đặt trong một ứng dụng khác thông qua liên kết hoặc nhúng.
{{% /alert %}} 

Xem xét một biểu đồ được tạo trong MS Excel. Biểu đồ sau đó được đặt trong một slide PowerPoint. Biểu đồ Excel đó được coi là một đối tượng OLE. 

- Một đối tượng OLE có thể xuất hiện dưới dạng biểu tượng. Trong trường hợp này, khi bạn nhấp đúp vào biểu tượng, biểu đồ sẽ được mở trong ứng dụng liên kết (Excel), hoặc bạn sẽ được yêu cầu chọn một ứng dụng để mở hoặc chỉnh sửa đối tượng. 
- Một đối tượng OLE có thể hiển thị nội dung thực tế của nó, chẳng hạn như nội dung của một biểu đồ. Trong trường hợp này, biểu đồ được kích hoạt trong PowerPoint, giao diện biểu đồ tải lên, và bạn có thể chỉnh sửa dữ liệu của biểu đồ trong PowerPoint.

[Aspose.Slides for C++](https://products.aspose.com/slides/vi/cpp/) allows you to insert OLE Objects into slides as OLE object frames ([OleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/oleobjectframe/)).

## **Thêm Khung Đối Tượng OLE vào Slide**

Giả sử bạn đã tạo một biểu đồ trong Microsoft Excel và muốn nhúng nó vào một slide dưới dạng khung đối tượng OLE bằng cách sử dụng Aspose.Slides for C++, bạn có thể thực hiện như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Đọc tệp Excel dưới dạng mảng byte.
4. Thêm [OleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/oleobjectframe/) vào slide, bao gồm mảng byte và các thông tin khác về đối tượng OLE.
5. Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một biểu đồ từ tệp Excel vào một slide dưới dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/oleobjectframe/) bằng cách sử dụng Aspose.Slides for C++. **Lưu ý** rằng hàm tạo [OleEmbeddedDataInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) nhận một phần mở rộng đối tượng có thể nhúng làm tham số thứ hai. Phần mở rộng này cho phép PowerPoint giải thích đúng loại tệp và chọn ứng dụng phù hợp để mở đối tượng OLE này.

``` cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/size_f.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

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

Aspose.Slides for C++ cho phép bạn thêm một [OleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/oleobjectframe/) mà không nhúng dữ liệu mà chỉ với một liên kết tới tệp.

Mã C++ dưới đây cho bạn thấy cách thêm một [OleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/oleobjectframe/) có liên kết tới tệp Excel vào một slide:

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Thêm một khung đối tượng OLE với tệp Excel được liên kết.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Truy cập Khung Đối Tượng OLE**

Nếu một đối tượng OLE đã được nhúng trong một slide, bạn có thể dễ dàng tìm hoặc truy cập nó theo cách sau:

1. Tải một bản trình bày có đối tượng OLE đã nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy tham chiếu của slide bằng cách sử dụng chỉ mục của nó.
3. Truy cập hình dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/oleobjectframe/). Trong ví dụ của chúng tôi, chúng tôi sử dụng PPTX đã tạo trước đó chỉ có một hình dạng trên slide đầu tiên. Sau đó chúng tôi *cast* (ép kiểu) đối tượng đó thành [IOleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ioleobjectframe/). Đây là khung đối tượng OLE mong muốn để truy cập.
4. Khi đã truy cập khung đối tượng OLE, bạn có thể thực hiện bất kỳ thao tác nào trên nó.

Trong ví dụ dưới đây, một khung đối tượng OLE (đối tượng biểu đồ Excel đã nhúng trong một slide) và dữ liệu tệp của nó được truy cập.

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

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

Aspose.Slides cho phép bạn truy cập các thuộc tính của khung đối tượng OLE liên kết.

Mã C++ dưới đây cho bạn cách kiểm tra xem một đối tượng OLE có được liên kết hay không và sau đó lấy đường dẫn tới tệp được liên kết:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

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
        // Chỉ các bản trình bày PPT mới có thể chứa đường dẫn tương đối.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **Thay đổi Dữ liệu Đối Tượng OLE**

{{% alert color="info" %}} 
Trong phần này, ví dụ mã dưới đây sử dụng [Aspose.Cells for C++](/cells/cpp/).
{{% /alert %}}

Nếu một đối tượng OLE đã được nhúng trong một slide, bạn có thể dễ dàng truy cập đối tượng đó và sửa đổi dữ liệu của nó theo cách sau:

1. Tải một bản trình bày có đối tượng OLE đã nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Truy cập hình dạng [OLEObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/oleobjectframe/). Trong ví dụ của chúng tôi, chúng tôi sử dụng PPTX đã tạo trước đó chỉ có một hình dạng trên slide đầu tiên. Sau đó chúng tôi *cast* (ép kiểu) đối tượng đó thành [IOleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ioleobjectframe/). Đây là khung đối tượng OLE mong muốn để truy cập.
4. Khi đã truy cập khung đối tượng OLE, bạn có thể thực hiện bất kỳ thao tác nào trên nó.
5. Tạo một đối tượng `Workbook` và truy cập dữ liệu OLE.
6. Truy cập `Worksheet` mong muốn và chỉnh sửa dữ liệu.
7. Lưu `Workbook` đã cập nhật vào một stream.
8. Thay đổi dữ liệu đối tượng OLE từ stream.

Trong ví dụ dưới đây, một khung đối tượng OLE (đối tượng biểu đồ Excel đã nhúng trong một slide) được truy cập, và dữ liệu tệp của nó được sửa đổi để cập nhật dữ liệu biểu đồ.

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/OoxmlSaveOptions.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Aspose.Cells cho C++ phải được khởi động trước khi sử dụng bất kỳ kiểu nào của nó.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Get the first shape as an OLE object frame.
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

Aspose::Cells::Cleanup();
```

## **Nhúng Các Loại Tệp Khác vào Slide**

Ngoài biểu đồ Excel, Aspose.Slides for C++ cho phép bạn nhúng các loại tệp khác vào slide. Ví dụ, bạn có thể chèn các tệp HTML, PDF và ZIP dưới dạng đối tượng. Khi người dùng nhấp đúp vào đối tượng đã chèn, nó sẽ tự động mở trong chương trình liên quan, hoặc người dùng sẽ được nhắc chọn một chương trình phù hợp để mở.

Mã C++ dưới đây cho bạn thấy cách nhúng HTML và ZIP vào một slide:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

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

## **Đặt Loại Tệp cho Các Đối Tượng Đã Nhúng**

Khi làm việc với bản trình bày, bạn có thể cần thay thế các đối tượng OLE cũ bằng các đối tượng mới hoặc thay thế một đối tượng OLE không được hỗ trợ bằng một đối tượng được hỗ trợ. Aspose.Slides for C++ cho phép bạn đặt loại tệp cho một đối tượng đã nhúng, cho phép cập nhật dữ liệu khung OLE hoặc phần mở rộng của nó.

Mã C++ dưới đây cho bạn cách đặt loại tệp cho một đối tượng OLE đã nhúng thành `zip`:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

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

## **Thiết lập Hình Ảnh Biểu Tượng và Tiêu Đề cho Các Đối Tượng Đã Nhúng**

Sau khi nhúng một đối tượng OLE, một bản xem trước gồm hình ảnh biểu tượng được thêm tự động. Bản xem trước này là những gì người dùng thấy trước khi truy cập hoặc mở đối tượng OLE. Nếu bạn muốn sử dụng một hình ảnh và văn bản cụ thể làm các yếu tố trong bản xem trước, bạn có thể thiết lập hình ảnh biểu tượng và tiêu đề bằng Aspose.Slides for C++.

Mã C++ dưới đây cho bạn cách thiết lập hình ảnh biểu tượng và tiêu đề cho một đối tượng đã nhúng: 

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

    // Thêm một hình ảnh vào tài nguyên của bản trình bày.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ngăn Không Để Khung Đối Tượng OLE Bị Thay Đổi Kích Thước và Vị Trí**

Sau khi bạn thêm một đối tượng OLE liên kết vào một slide bản trình bày, khi mở bản trình bày trong PowerPoint, bạn có thể thấy một thông báo yêu cầu cập nhật các liên kết. Nhấn nút “Update Links” có thể thay đổi kích thước và vị trí của khung đối tượng OLE vì PowerPoint cập nhật dữ liệu từ đối tượng OLE liên kết và làm mới bản xem trước của đối tượng. Để ngăn PowerPoint nhắc cập nhật dữ liệu của đối tượng, đặt phương thức `set_UpdateAutomatic` của giao diện [IOleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ioleobjectframe/) thành `false`:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

oleFrame->set_UpdateAutomatic(false);
```

## **Trích xuất Các Tệp Đã Nhúng**

Aspose.Slides for C++ cho phép bạn trích xuất các tệp đã nhúng trong slide dưới dạng các đối tượng OLE theo cách sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation) chứa các đối tượng OLE mà bạn dự định trích xuất.
2. Duyệt qua tất cả các hình dạng trong bản trình bày và truy cập các hình dạng [OLEObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/oleobjectframe/).
3. Truy cập dữ liệu của các tệp đã nhúng từ khung đối tượng OLE và ghi chúng vào đĩa.

Mã C++ dưới đây cho bạn cách trích xuất các tệp đã nhúng trong một slide dưới dạng các đối tượng OLE:

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

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

### Will the OLE content be rendered when exporting slides to PDF/images?

Những gì hiển thị trên slide sẽ được render — biểu tượng/hình ảnh thay thế (bản xem trước). Nội dung OLE “sống” không được thực thi trong quá trình render. Nếu cần, hãy đặt hình ảnh preview riêng để đảm bảo hiển thị như mong muốn trong PDF xuất.

### How can I lock an OLE object on a slide so users cannot move/edit it in PowerPoint?

Khóa hình dạng: Aspose.Slides cung cấp [shape-level locks](/slides/vi/cpp/applying-protection-to-presentation/). Đây không phải là mã hoá, nhưng nó thực sự ngăn ngừa việc chỉnh sửa hoặc di chuyển nhầm.

### Why does a linked Excel object "jump" or change size when I open the presentation?

PowerPoint có thể làm mới preview của OLE liên kết. Để có giao diện ổn định, hãy tuân theo các thực hành của [Working Solution for Worksheet Resizing](/slides/vi/cpp/working-solution-for-worksheet-resizing/) — hoặc điều chỉnh khung cho phù hợp với phạm vi, hoặc co giãn phạm vi vào một khung cố định và đặt hình ảnh thay thế phù hợp.

### Will relative paths for linked OLE objects be preserved in the PPTX format?

Trong PPTX, thông tin “đường dẫn tương đối” không tồn tại — chỉ có đường dẫn đầy đủ. Đường dẫn tương đối chỉ có trong định dạng PPT cũ. Để tăng tính di động, nên sử dụng đường dẫn tuyệt đối đáng tin cậy/URI có thể truy cập hoặc nhúng.