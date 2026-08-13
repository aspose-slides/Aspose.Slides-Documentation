---
title: Tùy chỉnh phông chữ PowerPoint trong C++
linktitle: Phông chữ tùy chỉnh
type: docs
weight: 20
url: /vi/cpp/custom-font/
keywords:
- phông chữ
- phông chữ tùy chỉnh
- phông chữ bên ngoài
- tải phông chữ
- quản lý phông chữ
- thư mục phông chữ
- PowerPoint
- OpenDocument
- bản trình bày
- C++
- Aspose.Slides
description: "Tùy chỉnh phông chữ trong các slide PowerPoint với Aspose.Slides cho C++ để giữ cho bản trình bày của bạn sắc nét và nhất quán trên mọi thiết bị."
---
## **Tổng quan**

Aspose.Slides cho phép bạn sử dụng các phông chữ tùy chỉnh trong bản trình bày mà không cần cài đặt chúng trên hệ điều hành. Bạn có thể tải phông chữ từ các thư mục tùy chỉnh, cung cấp phông chữ cho một bản trình bày cụ thể thông qua các nguồn phông chữ ở mức tài liệu, hoặc tải phông chữ bên ngoài trực tiếp từ dữ liệu nhị phân.

Các phông chữ đã tải sẽ được sử dụng khi bản trình bày được render hoặc xuất ra, ví dụ sang PDF, hình ảnh và các định dạng hỗ trợ khác. Điều này giúp giữ độ nhất quán của đầu ra bản trình bày trên các môi trường khác nhau. Bài viết cũng giải thích cách kiểm tra các thư mục phông chữ mà Aspose.Slides sử dụng và cách xóa bộ nhớ cache phông chữ sau khi làm việc với phông chữ bên ngoài.

Việc đăng ký phông chữ tùy chỉnh để render là riêng biệt so với việc nhúng phông chữ vào tệp PPTX. Nếu một phông chữ phải được lưu trong chính bản trình bày, hãy sử dụng các tính năng nhúng phông chữ một cách rõ ràng.

{{% alert color="info" %}} 

Aspose Slides cho phép bạn tải các phông chữ này bằng cách sử dụng [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) và TrueType Collection (.ttc). Xem [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf). Xem [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Tải Phông Tùy Chỉnh**

Aspose.Slides cho phép bạn tải các phông chữ được sử dụng trong bản trình bày mà không cần cài đặt chúng trên hệ thống. Điều này ảnh hưởng đến đầu ra xuất khẩu—như PDF, hình ảnh và các định dạng hỗ trợ khác—để các tài liệu tạo ra trông nhất quán trên mọi môi trường. Phông chữ được tải từ các thư mục tùy chỉnh.

1. Xác định một hoặc nhiều thư mục chứa các tệp phông chữ.
2. Gọi phương thức tĩnh [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsloader/loadexternalfonts/) để tải phông chữ từ các thư mục đó.
3. Tải và render/​xuất bản trình bày.
4. Gọi [FontsLoader.clearCache](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsloader/clearcache/) để xóa bộ nhớ cache phông chữ.

Ví dụ mã sau minh họa quá trình tải phông chữ:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Định nghĩa các thư mục chứa tệp phông chữ tùy chỉnh.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Tải phông chữ tùy chỉnh từ các thư mục đã chỉ định.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Render/​xuất bản trình bày (ví dụ, sang PDF, hình ảnh hoặc các định dạng khác) bằng cách sử dụng các phông chữ đã tải.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Xóa bộ nhớ cache phông chữ sau khi công việc hoàn thành.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsloader/loadexternalfonts/) thêm các thư mục bổ sung vào các đường dẫn tìm kiếm phông chữ, nhưng không thay đổi thứ tự khởi tạo phông chữ.
Phông chữ được khởi tạo theo thứ tự sau:

1. Đường dẫn phông chữ mặc định của hệ điều hành.
1. Các đường dẫn được tải qua [FontsLoader](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Lấy Thư Mục Phông Tùy Chỉnh**
Aspose.Slides cung cấp [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsloader/getfontfolders/) để cho phép bạn tìm các thư mục phông chữ. Phương thức này trả về các thư mục được thêm thông qua phương thức `LoadExternalFonts` và các thư mục phông chữ hệ thống.

Đoạn mã C++ dưới đây cho bạn thấy cách sử dụng phương thức [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsloader/getfontfolders/):

```cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Dòng này xuất ra các thư mục được kiểm tra cho các tệp phông chữ.
// Đó là các thư mục được thêm thông qua phương thức LoadExternalFonts và các thư mục phông chữ hệ thống.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Chỉ Định Phông Tùy Chỉnh Được Sử Dụng Trong Bản Trình Bày**
Aspose.Slides cung cấp thuộc tính [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) để cho phép bạn chỉ định các phông chữ bên ngoài sẽ được sử dụng với bản trình bày.

Đoạn mã C++ sau cho bạn thấy cách sử dụng thuộc tính [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //làm việc với bản trình bày
    //CustomFont1, CustomFont2 cũng như các phông chữ từ assets\fonts & global\fonts và các thư mục con của chúng đều khả dụng cho bản trình bày
}
```

## **Quản Lý Phông Bên Ngoài**
Aspose.Slides cung cấp phương thức [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsloader/loadexternalfont/) để cho phép bạn tải phông chữ bên ngoài vào một mảng byte.

Đoạn mã C++ dưới đây trình bày quá trình tải phông chữ vào mảng byte:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

// Đường dẫn tới thư mục tài liệu
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **FAQ**

### Các phông chữ tùy chỉnh có ảnh hưởng đến việc xuất khẩu sang mọi định dạng (PDF, PNG, SVG, HTML) không?

Có. Các phông chữ đã kết nối được bộ dựng sử dụng trên mọi định dạng xuất khẩu.

### Các phông chữ tùy chỉnh có được nhúng tự động vào tệp PPTX kết quả không?

Không. Đăng ký một phông chữ để render không đồng nghĩa với việc nhúng nó vào PPTX. Nếu bạn cần phông chữ được mang bên trong tệp bản trình bày, phải sử dụng các [tính năng nhúng](/slides/vi/cpp/embedded-font/) một cách rõ ràng.

### Tôi có thể kiểm soát hành vi dự phòng khi một phông chữ tùy chỉnh thiếu một số glyph không?

Có. Cấu hình [font substitution](/slides/vi/cpp/font-substitution/), [replacement rules](/slides/vi/cpp/font-replacement/) và [fallback sets](/slides/vi/cpp/fallback-font/) để xác định chính xác phông chữ sẽ được dùng khi glyph yêu cầu không có.

### Tôi có thể sử dụng phông chữ trong các container Linux/Docker mà không cài đặt chúng vào hệ thống không?

Có. Chỉ đến các thư mục phông chữ của bạn hoặc tải phông chữ từ mảng byte. Điều này loại bỏ bất kỳ phụ thuộc nào vào các thư mục phông chữ hệ thống trong hình ảnh container.

### Về giấy phép—tôi có thể nhúng bất kỳ phông chữ tùy chỉnh nào mà không bị hạn chế không?

Bạn chịu trách nhiệm tuân thủ giấy phép của phông chữ. Các điều khoản khác nhau; một số giấy phép cấm nhúng hoặc sử dụng thương mại. Luôn xem lại EULA của phông chữ trước khi phân phối các đầu ra.