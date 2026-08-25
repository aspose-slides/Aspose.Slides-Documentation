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
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tùy chỉnh phông chữ trong các slide PowerPoint với Aspose.Slides cho C++ để giữ cho bài thuyết trình của bạn sắc nét và nhất quán trên mọi thiết bị."
---
## **Tổng quan**

Aspose.Slides cho phép bạn sử dụng phông chữ tùy chỉnh trong bài thuyết trình mà không cần cài đặt chúng trên hệ điều hành. Bạn có thể tải phông chữ từ các thư mục tùy chỉnh, cung cấp phông chữ cho một bài thuyết trình cụ thể thông qua các nguồn phông chữ ở mức tài liệu, hoặc tải phông chữ bên ngoài trực tiếp từ dữ liệu nhị phân.

Các phông chữ đã tải sẽ được sử dụng khi bài thuyết trình được render hoặc xuất, ví dụ sang PDF, hình ảnh và các định dạng hỗ trợ khác. Điều này giúp giữ cho đầu ra của bài thuyết trình nhất quán trên các môi trường khác nhau. Bài viết cũng giải thích cách kiểm tra các thư mục phông chữ được Aspose.Slides sử dụng và cách xóa bộ nhớ cache phông chữ sau khi làm việc với phông chữ bên ngoài.

Đăng ký phông chữ tùy chỉnh để render là một hành động riêng biệt so với việc nhúng phông chữ vào tệp PPTX. Nếu phông chữ phải được lưu bên trong bài thuyết trình, hãy sử dụng các tính năng nhúng phông chữ một cách rõ ràng.

Một chủ đề trình chiếu có thể tham chiếu tới các họ phông chữ khác nhau cho các hệ thống viết riêng lẻ. Những ánh xạ này lưu trữ tên phông chữ nhưng không cài đặt hoặc tải tệp phông chữ. Xem [Phông chữ chủ đề riêng theo kịch bản](/slides/vi/cpp/script-specific-font-mappings/) để quản lý các ánh xạ, và sử dụng các tùy chọn tải bên dưới để làm cho các phông chữ được tham chiếu sẵn sàng cho việc render nhất quán.

{{% alert color="info" title="Lưu ý" %}}

Aspose Slides cho phép bạn tải các phông chữ này bằng cách sử dụng [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* Phông chữ TrueType (.ttf) và TrueType Collection (.ttc). Xem [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Phông chữ OpenType (.otf). Xem [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Tải phông chữ tùy chỉnh**

Aspose.Slides cho phép bạn tải các phông chữ được sử dụng trong một bài thuyết trình mà không cần cài đặt chúng trên hệ thống. Điều này ảnh hưởng đến đầu ra xuất—như PDF, hình ảnh và các định dạng hỗ trợ khác—để các tài liệu kết quả trông nhất quán trên các môi trường. Phông chữ được tải từ các thư mục tùy chỉnh.

1. Xác định một hoặc nhiều thư mục chứa các tệp phông chữ.  
2. Gọi phương thức tĩnh [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsloader/loadexternalfonts/) để tải phông chữ từ các thư mục đó.  
3. Tải và render/​xuất bài thuyết trình.  
4. Gọi [FontsLoader.clearCache](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsloader/clearcache/) để xóa bộ nhớ cache phông chữ.

Đoạn mã ví dụ dưới đây minh họa quá trình tải phông chữ:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Xác định các thư mục chứa các tệp phông chữ tùy chỉnh.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Tải phông chữ tùy chỉnh từ các thư mục đã chỉ định.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Render/​xuất bài thuyết trình (ví dụ: sang PDF, hình ảnh hoặc các định dạng khác) bằng cách sử dụng các phông chữ đã tải.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Xóa bộ nhớ đệm phông chữ sau khi công việc hoàn tất.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Lưu ý" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsloader/loadexternalfonts/) thêm các thư mục bổ sung vào các đường dẫn tìm kiếm phông chữ, nhưng nó không thay đổi thứ tự khởi tạo phông chữ.  
Phông chữ được khởi tạo theo thứ tự sau:

1. Đường dẫn phông chữ mặc định của hệ điều hành.  
1. Các đường dẫn được tải qua [FontsLoader](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Lấy các thư mục phông chữ tùy chỉnh**

Aspose.Slides cung cấp [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsloader/getfontfolders/) để cho phép bạn tìm các thư mục phông chữ. Phương thức này trả về các thư mục đã được thêm thông qua phương thức `LoadExternalFonts` và các thư mục phông chữ hệ thống.

Đoạn mã C++ sau cho bạn thấy cách sử dụng phương thức [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Dòng này xuất ra các thư mục được kiểm tra cho tệp phông chữ.
// Đó là các thư mục được thêm thông qua phương thức LoadExternalFonts và các thư mục phông chữ hệ thống.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Chỉ định phông chữ tùy chỉnh được sử dụng với một bài thuyết trình**

Aspose.Slides cung cấp thuộc tính [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) để cho phép bạn chỉ định các phông chữ bên ngoài sẽ được sử dụng với bài thuyết trình.

Đoạn mã C++ sau cho bạn thấy cách sử dụng thuộc tính [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

``` cpp
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
    //làm việc với bài thuyết trình
    //CustomFont1, CustomFont2 cũng như các phông chữ từ các thư mục assets\fonts và global\fonts cùng các thư mục con của chúng đều có sẵn cho bài thuyết trình
}
```

## **Quản lý phông chữ một cách bên ngoài**

Aspose.Slides cung cấp phương thức [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsloader/loadexternalfont/) để cho phép bạn tải phông chữ bên ngoài vào một mảng byte.

Đoạn mã C++ dưới đây minh họa quá trình tải phông chữ vào mảng byte:

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

## **Câu hỏi thường gặp**

### Phông chữ tùy chỉnh có ảnh hưởng đến việc xuất sang mọi định dạng (PDF, PNG, SVG, HTML) không?

Có. Các phông chữ đã kết nối được bộ render sử dụng cho tất cả các định dạng xuất.

### Phông chữ tùy chỉnh có tự động được nhúng vào tệp PPTX kết quả không?

Không. Đăng ký một phông chữ để render không đồng nghĩa với việc nhúng nó vào PPTX. Nếu bạn cần phông chữ được mang bên trong tệp bài thuyết trình, phải sử dụng các [tính năng nhúng](/slides/vi/cpp/embedded-font/) một cách rõ ràng.

### Tôi có thể kiểm soát hành vi dự phòng khi một phông chữ tùy chỉnh thiếu một số glyph không?

Có. Cấu hình [thay thế phông chữ](/slides/vi/cpp/font-substitution/), [quy tắc thay thế](/slides/vi/cpp/font-replacement/) và [bộ phông chữ dự phòng](/slides/vi/cpp/fallback-font/) để xác định chính xác phông chữ nào sẽ được dùng khi glyph yêu cầu không có.

### Tôi có thể sử dụng phông chữ trong các container Linux/Docker mà không cài đặt chúng toàn bộ hệ thống không?

Có. Chỉ định các thư mục phông chữ của riêng bạn hoặc tải phông chữ từ các mảng byte. Điều này loại bỏ bất kỳ phụ thuộc nào vào các thư mục phông chữ hệ thống trong ảnh container.

### Về giấy phép—tôi có thể nhúng bất kỳ phông chữ tùy chỉnh nào mà không có hạn chế không?

Bạn chịu trách nhiệm tuân thủ giấy phép của phông chữ. Điều kiện khác nhau; một số giấy phép cấm việc nhúng hoặc sử dụng thương mại. Luôn kiểm tra EULA của phông chữ trước khi phân phối kết quả.