---
title: Xuất bản trình chiếu sang XAML trong C++
linktitle: Trình chiếu sang XAML
type: docs
weight: 30
url: /vi/cpp/export-to-xaml/
keywords:
- xuất PowerPoint
- xuất OpenDocument
- xuất bản trình chiếu
- chuyển đổi PowerPoint
- chuyển đổi OpenDocument
- chuyển đổi bản trình chiếu
- PowerPoint sang XAML
- OpenDocument sang XAML
- bản trình chiếu sang XAML
- PPT sang XAML
- PPTX sang XAML
- ODP sang XAML
- lưu PPT dưới dạng XAML
- lưu PPTX dưới dạng XAML
- lưu ODP dưới dạng XAML
- xuất PPT sang XAML
- xuất PPTX sang XAML
- xuất ODP sang XAML
- C++
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint và OpenDocument sang XAML trong C++ bằng Aspose.Slides—giải pháp nhanh, không cần Office, giữ nguyên bố cục của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách xuất bản trình chiếu PowerPoint sang XAML bằng Aspose.Slides. Nó bao gồm một phần giới thiệu ngắn gọn về XAML, cho thấy cách lưu một bản trình chiếu dưới dạng XAML với các thiết lập mặc định, và minh họa cách tùy chỉnh việc xuất thông qua [XamlOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export.xaml/xamloptions/), bao gồm việc xuất các slide ẩn. Bài viết cũng trả lời một số câu hỏi thường gặp liên quan tới phông chữ dự phòng, tính tương thích của ngăn XAML, và hành vi xuất slide ẩn.

## **Về XAML**

XAML là một ngôn ngữ đánh dấu dựa trên XML được dùng để mô tả giao diện người dùng trong các framework như WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) và Xamarin.Forms.

Bạn có thể làm việc với các tệp XAML trong một trình thiết kế trực quan hoặc viết và chỉnh sửa mã đánh dấu trực tiếp.

## **Xuất bản trình chiếu sang XAML với các tùy chọn mặc định**

Ví dụ C++ sau đây cho thấy cách xuất một bản trình chiếu sang XAML với các thiết lập mặc định:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

Mặc định, các slide đã xuất sẽ được lưu trong thư mục con `pres` của thư mục làm việc hiện tại của tiến trình, được trả về bởi [Directory::GetCurrentDirectory](https://reference.aspose.com/slides/vi/cpp/system.io/directory/getcurrentdirectory/). Thư mục này được tạo tự động, và bất kỳ hình ảnh nào cần thiết cũng sẽ được lưu ở đó.

Tên thư mục đầu ra được lấy từ tên tệp nguồn mà không có phần mở rộng. Đối với `pres.pptx`, các tệp đầu ra sẽ có tên `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, và cứ như vậy. Ngay cả khi bạn truyền đường dẫn tuyệt đối cho bản trình chiếu đầu vào, thư mục đầu ra vẫn được tạo tương đối với thư mục làm việc hiện tại, thay vì nằm bên cạnh tệp đầu vào.

## **Xuất bản trình chiếu sang XAML với các tùy chọn tùy chỉnh**

Sử dụng giao diện [IXamlOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export.xaml/ixamloptions/) để kiểm soát cách Aspose.Slides xuất một bản trình chiếu sang XAML.

Để lưu đầu ra vào một vị trí tùy chỉnh, triển khai [IXamlOutputSaver](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export.xaml/ixamloutputsaver/) và truyền một thể hiện của triển khai của bạn vào phương thức [set_OutputSaver](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) của [XamlOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export.xaml/xamloptions/).

Để bao gồm các slide ẩn trong đầu ra XAML, truyền `true` vào phương thức [set_ExportHiddenSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/), như trong ví dụ C++ sau:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);
presentation->Save(xamlOptions);
```

## **Bắt giữ tất cả các thành phần XAML được tạo**

Việc xuất XAML có thể tạo ra một tài liệu XAML cho mỗi slide đã xuất cộng với các hình ảnh và tài nguyên hỗ trợ riêng biệt. Truyền một [IXamlOutputSaver](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export.xaml/ixamloutputsaver/) tùy chỉnh vào `XamlOptions::set_OutputSaver` để nhận các thành phần này thay vì sử dụng bộ lưu mặc định của hệ thống tệp. Bắt đầu xuất bằng phương thức overload [Presentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/) đặc thù cho XAML mà chấp nhận các tùy chọn XAML.

### **Hiểu vòng đời Callback**

Trình xuất sẽ gọi [IXamlOutputSaver::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export.xaml/ixamloutputsaver/save/) riêng biệt cho mỗi thành phần được tạo:

- `path` xác định thành phần và có thể bao gồm các thư mục tương đối. Giữ lại thông tin này vì XAML có thể tham chiếu tài nguyên bằng các đường dẫn tương đối.
- `data` chứa các byte của thành phần. Hình ảnh và các tài nguyên nhị phân khác không được giải mã thành văn bản.
- Bộ lưu chịu trách nhiệm giữ hoặc lưu trữ dữ liệu trước khi trả về. Các ví dụ sao chép mỗi mảng byte vào bộ nhớ thuộc về ứng dụng.
- Cân nhắc việc xuất là thành công chỉ khi thao tác lưu bản trình chiếu trả về và mọi callback đã hoàn thành thành công. Không che giấu lỗi lưu trữ hoặc bắt đầu các ghi nền không được giám sát. Nếu việc lưu diễn ra sau đó, chỉ báo cáo thành công chung sau khi bước đó cũng thành công.

`XamlOptions::set_ExportHiddenSlides` cũng áp dụng cho bộ lưu tùy chỉnh. Cài đặt mặc định, `false`, sẽ loại bỏ các tài liệu XAML của slide ẩn. Đặt nó thành `true` sẽ bao gồm chúng và bất kỳ tài nguyên nào cần thiết cho việc xuất. Số lượng tài nguyên phụ thuộc vào bản trình chiếu; không giả định một callback cho mỗi slide hoặc một thứ tự callback cố định.

### **Xuất ra bộ nhớ và kiểm tra các thành phần**

Ví dụ hoàn chỉnh này tải `pres.pptx`, thu thập mọi thành phần vào một [Dictionary<String, ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/vi/cpp/system.collections.generic/dictionary/), và in ra tên, loại và số byte của chúng. Nó giữ nguyên các tên đã cung cấp. Các tên trùng lặp sẽ khiến việc thu thập thất bại thay vì ghi đè im lặng lên một thành phần.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/io/path.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Text;

class InMemoryXamlExample
{
    class MemoryXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<MemoryXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(true);
        presentation->Save(options);

        auto inspectXamlText = false;
        for (const auto& artifact : saver->Artifacts)
        {
            auto extension = Path::GetExtension(artifact.get_Key()).ToLowerInvariant();
            auto isXaml = extension == u".xaml";
            auto isImage = extension == u".png" || extension == u".jpg" || extension == u".jpeg" || extension == u".gif" || extension == u".bmp" || extension == u".tif" || extension == u".tiff" || extension == u".svg";
            String kind = isXaml ? u"slide XAML" : isImage ? u"image" : u"supporting resource";
            Console::WriteLine(u"{0}: {1} bytes ({2})", artifact.get_Key(), artifact.get_Value()->get_Length(), kind);

            // Giải mã chỉ XAML, và chỉ khi cần kiểm tra văn bản.
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

Gọi `InMemoryXamlExample::Run` từ ứng dụng của bạn. Kiểm tra phần mở rộng hữu ích cho việc kiểm tra; giữ lại tất cả các thành phần, bao gồm các loại tài nguyên không quen thuộc. Không thay đổi các byte khi lưu hoặc truyền chúng. Sử dụng [Encoding::GetString](https://reference.aspose.com/slides/vi/cpp/system.text/encoding/getstring/) với mã hóa UTF-8 chỉ cho XAML cần xử lý văn bản.

### **Đóng gói các thành phần đã thu thập vào tệp ZIP**

Ví dụ độc lập này thu thập quá trình xuất, xác thực các tên, và ghi các byte gốc vào một tệp ZIP. Tên archive duy nhất tách các công việc xuất đồng thời. Các mục ZIP sử dụng dấu gạch chéo xuôi và giữ lại các thư mục tương đối. Các tên không an toàn hoặc tên trùng nhau sau khi chuẩn hoá sẽ từ chối toàn bộ gói trước khi ghi.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/guid.h>
#include <system/io/file_access.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/path.h>
#include <zip/zip_file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace Aspose::Zip;

class ZipXamlExample
{
    class CollectedXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<CollectedXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(false);
        presentation->Save(options);

        auto entries = MakeObject<Dictionary<String, ArrayPtr<uint8_t>>>(StringComparer::get_OrdinalIgnoreCase());
        for (const auto& artifact : saver->Artifacts)
        {
            auto entryName = artifact.get_Key().Replace(u'\\', u'/');
            auto segments = entryName.Split(u'/');
            auto unsafeName = entryName.StartsWith(u"/", StringComparison::Ordinal) || entryName.Contains(u":");
            for (const auto& segment : segments)
            {
                unsafeName |= String::IsNullOrWhiteSpace(segment) || segment == u"." || segment == u"..";
            }

            if (unsafeName || entries->ContainsKey(entryName))
            {
                Console::WriteLine(u"Export rejected: unsafe or duplicate artifact name: {0}", artifact.get_Key());
                return;
            }
            entries->Add(entryName, artifact.get_Value());
        }

        auto jobId = Guid::NewGuid();
        auto archivePath = u"xaml-" + jobId.ToString(u"N") + u".zip";
        auto archive = MakeObject<ZipFile>();
        for (const auto& artifact : entries)
        {
            auto fileName = Path::GetFileName(artifact.get_Key());
            auto directoryName = Path::GetDirectoryName(artifact.get_Key()).Replace(u'\\', u'/');
            archive->AddEntry(fileName, directoryName, artifact.get_Value());
        }

        auto output = MakeObject<FileStream>(archivePath, FileMode::CreateNew, FileAccess::Write);
        archive->Save(output);
        output->Close();
        archive->Dispose();

        // Save hoàn thiện thư mục ZIP; đóng tệp trước khi báo cáo thành công.
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

Gọi `ZipXamlExample::Run` từ ứng dụng của bạn. Ví dụ sử dụng `Aspose::Zip::ZipFile` từ runtime C++ để ghi một archive cục bộ; trình xuất không ghi các tệp XAML hoặc hình ảnh rời. Đối với lưu trữ từ xa, thay thế giai đoạn ghi archive bằng việc tải lên các mảng byte đã thu thập. Sử dụng một định danh công việc xuất cộng với tên tài nguyên tương đối đầy đủ làm khóa blob, hoặc lưu định danh công việc, tên tương đối và dữ liệu nhị phân trong một dòng bảng dữ liệu. Phát hành công việc chỉ sau khi tất cả các tải lên hoàn tất hoặc giao dịch cơ sở dữ liệu được cam kết. Dọn dẹp phần xuất chưa hoàn chỉnh nếu việc lưu trữ thất bại.

Đối với các bản trình chiếu lớn, bộ lưu tùy chỉnh có thể lưu mỗi thành phần trực tiếp vào bộ nhớ lưu trữ của ứng dụng để tránh việc giữ một bản sao bổ sung của toàn bộ xuất trong bộ nhớ ứng dụng. Trình xuất vẫn thu thập tất cả các thành phần được tạo trong bộ nhớ trước khi gọi bộ lưu. Giữ mỗi callback đồng bộ từ quan điểm của trình xuất: trả về chỉ sau khi đích đã chấp nhận các byte, và cho phép lỗi tới người gọi.

### **Bảo tồn tên tài nguyên và xác minh tham chiếu**

- Chuẩn hoá ký tự phân tách đường dẫn khi đích yêu cầu, nhưng vẫn giữ các thư mục tương đối. Không chỉ dùng [Path::GetFileName](https://reference.aspose.com/slides/vi/cpp/system.io/path/getfilename/) trừ khi mọi tên được tạo đều biết là duy nhất và các tham chiếu tài nguyên vẫn hợp lệ.
- Áp dụng việc xác thực tên theo đích. Khi ghi các tệp rời, từ chối các đường dẫn gốc và các đoạn di chuyển, giải quyết đích bằng [Path::GetFullPath](https://reference.aspose.com/slides/vi/cpp/system.io/path/getfullpath/), và xác minh nó vẫn nằm dưới thư mục xuất dự định, bao gồm ký tự phân tách thư mục trong kiểm tra chứa. Sử dụng một thư mục do ứng dụng kiểm soát mà không có liên kết biểu tượng có thể chuyển hướng ghi.
- Sử dụng một bộ lưu và không gian lưu trữ riêng cho mỗi công việc xuất. Phát hiện các va chạm sau khi chuẩn hoá ký tự phân tách và theo quy tắc nhạy cảm chữ hoa/chữ thường của đích.
- Trước khi phát hành, phân tích mỗi tài liệu XAML dưới dạng XML và kiểm tra các tham chiếu tài nguyên dựa trên tệp của nó, chẳng hạn thuộc tính `Source` hoặc `ImageSource` của hình ảnh. Giải quyết mỗi URI tương đối so với thư mục chứa thành phần XAML, chuẩn hoá tên lưu trữ kết quả, và xác nhận rằng khóa từ điển, mục ZIP hoặc đối tượng đã lưu tương ứng tồn tại. Xử lý các URI bên ngoài và các biểu thức đánh dấu XAML riêng biệt so với tên tệp tương đối.

Ví dụ, nếu `pres/Slide_1.xaml` tham chiếu tới `images/image1.png`, tài nguyên đã lưu phải có sẵn dưới dạng `pres/images/image1.png`. Chỉ giữ `image1.png` sẽ phá vỡ mối quan hệ đó. Đối với lưu trữ đối tượng, bảo tồn cùng bố cục dưới tiền tố công việc và làm cho các URL tài nguyên đó có thể truy cập được cho người tiêu thụ XAML. Mở lại ZIP đã hoàn thành để xác minh tên mục và byte tài nguyên, và tải các slide mẫu trong môi trường XAML mục tiêu để xác nhận hình ảnh được giải quyết đúng.

## **Câu hỏi thường gặp**

**Làm sao để đảm bảo phông chữ dự đoán được nếu phông chữ gốc không có trên máy?**

Sử dụng [set_DefaultRegularFont](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) trong [XamlOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export.xaml/xamloptions/) — nó được dùng làm phông chữ dự phòng trong quá trình xuất khi phông chữ gốc thiếu. Điều này không bảo đảm rằng XAML được tạo sẽ tham chiếu đến phông chữ dự phòng hoặc rằng phông chữ đó có sẵn trên máy đích. Đảm bảo các phông chữ mà XAML tham chiếu có sẵn trong môi trường nơi nó được hiển thị.

**XAML được xuất chỉ dành cho WPF hay có thể dùng trong các ngăn XAML khác không?**

[Aspose.Slides](https://reference.aspose.com/slides/vi/cpp/) xuất XAML WPF thông qua API công cộng của nó. Tính tương thích với các ngăn XAML khác, như UWP và Xamarin.Forms, không được đảm bảo. Hãy kiểm tra mã đánh dấu đã tạo trong môi trường mục tiêu của bạn.

**Các slide ẩn có được hỗ trợ không, và làm thế nào để ngăn chúng được xuất theo mặc định?**

Mặc định, các slide ẩn không được bao gồm. Bạn có thể kiểm soát hành vi này qua [set_ExportHiddenSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) trong [XamlOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export.xaml/xamloptions/) — để nó bị tắt nếu bạn không cần xuất chúng.