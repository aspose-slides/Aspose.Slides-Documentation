---
title: Mở các bài thuyết trình trong C++
linktitle: Mở bài thuyết trình
type: docs
weight: 20
url: /vi/cpp/open-presentation/
keywords:
- mở PowerPoint
- mở OpenDocument
- mở bài thuyết trình
- mở PPTX
- mở PPT
- mở ODP
- tải bài thuyết trình
- tải PPTX
- tải PPT
- tải ODP
- bài thuyết trình được bảo vệ
- bài thuyết trình lớn
- tài nguyên bên ngoài
- đối tượng nhị phân
- C++
- Aspose.Slides
description: "Tìm hiểu cách mở các bài thuyết trình PowerPoint và OpenDocument trong C++, cung cấp mật khẩu mở, kiểm soát việc tải tài nguyên và giảm việc sử dụng bộ nhớ với Aspose.Slides cho C++."
---
## **Giới thiệu**

[Aspose.Slides for C++](https://products.aspose.com/slides/vi/cpp/) có thể tải các bài thuyết trình PowerPoint và OpenDocument từ tệp và luồng. Sau khi một bài thuyết trình được tải, bạn có thể kiểm tra cấu trúc, chỉnh sửa các slide, quản lý tài nguyên và lưu nó ở định dạng gốc hoặc định dạng hỗ trợ khác.

Hành vi tải có thể được tùy chỉnh thông qua lớp [LoadOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/). Ví dụ, bạn có thể cung cấp mật khẩu mở, giữ các đối tượng nhị phân lớn ngoài bộ nhớ, kiểm soát tài nguyên bên ngoài, hoặc bỏ qua dữ liệu nhị phân nhúng.

## **Mở Bài Thuyết Trình**

Để mở một bài thuyết trình đã tồn tại, truyền đường dẫn tệp vào hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/). Hãy giải phóng tài nguyên của bài thuyết trình sau khi sử dụng để các tay cầm tệp, dữ liệu tạm thời và các tài nguyên khác được giải phóng kịp thời.

Đoạn mã C++ dưới đây minh họa cách mở một bài thuyết trình và lấy số lượng slide:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Mở Bài Thuyết Trình Được Bảo Vệ Bằng Mật Khẩu**

Mật khẩu mở mã hoá nội dung bài thuyết trình. Để tải toàn bộ bài thuyết trình, truyền mật khẩu đúng vào [LoadOptions::set_Password](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_password/) và truyền các tùy chọn vào hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/). Việc tải sẽ thất bại nếu mật khẩu bị thiếu hoặc không đúng.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = MakeObject<Presentation>(u"encrypted-presentation.pptx", loadOptions);

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

Đối với việc phát hiện mật khẩu, xác thực và quy trình mã hoá, xem [Password-Protect Presentations](/slides/vi/cpp/password-protected-presentation/). Nếu một bài thuyết trình đã được mã hoá nhưng được lưu có thuộc tính tài liệu công khai, các thuộc tính đó có thể được đọc mà không cần mật khẩu; xem [Manage Presentation Properties](/slides/vi/cpp/presentation-properties/).

## **Mở Bài Thuyết Trình Lớn**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) kiểm soát cách Aspose.Slides xử lý các đối tượng nhị phân lớn như hình ảnh, âm thanh và video. Bạn có thể giữ tệp nguồn bị khóa, cho phép tạo tệp tạm và giới hạn lượng dữ liệu BLOB được giữ trong bộ nhớ.

Đoạn mã C++ dưới đây minh họa việc tải một bài thuyết trình lớn (ví dụ, 2 GB):

```cpp
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IBlobManagementOptions.h>
#include <PresentationLockingBehavior.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String filePath = u"large-presentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
auto blobOptions = loadOptions->get_BlobManagementOptions();
blobOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobOptions->set_IsTemporaryFilesAllowed(true);
blobOptions->set_MaxBlobsBytesInMemory(10 * 1024 * 1024);

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

presentation->get_Slide(0)->set_Name(u"Large presentation");
presentation->Save(u"large-presentation-copy.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

{{% alert color="info" title="Lưu ý" %}}

Với `PresentationLockingBehavior::KeepLocked`, tệp nguồn sẽ vẫn bị khóa cho đến khi đối tượng `Presentation` được giải phóng. Không di chuyển, ghi đè hoặc xóa tệp nguồn trong khi đối tượng đó còn tồn tại.

Aspose.Slides có thể sao chép nội dung của một luồng đầu vào trong quá trình tải. Đối với các bài thuyết trình lớn, sử dụng đường dẫn tệp thường hiệu quả hơn luồng. Xem [Manage BLOBs](/slides/vi/cpp/manage-blob/) để biết thêm các tùy chọn lưu trữ và quản lý bộ nhớ.

{{% /alert %}}

## **Kiểm Soát Tài Nguyên Ngoại Tuyến**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) nhận một triển khai của [IResourceLoadingCallback](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iresourceloadingcallback/). Hàm gọi lại có thể cung cấp dữ liệu thay thế, chuyển hướng tài nguyên, sử dụng bộ tải mặc định hoặc bỏ qua tài nguyên. Điều này hữu ích khi các bài thuyết trình chứa hình ảnh ngoại vi phải được giải quyết theo các quy tắc bảo mật hoặc lưu trữ đặc thù của ứng dụng.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IResourceLoadingArgs.h>
#include <IResourceLoadingCallback.h>
#include <ResourceLoadingAction.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        auto isJpeg = args->get_OriginalUri().EndsWith(u".jpg", StringComparison::OrdinalIgnoreCase);
        if (!isJpeg || !File::Exists(u"approved-image.jpg"))
        {
            return ResourceLoadingAction::Skip;
        }

        auto imageData = File::ReadAllBytes(u"approved-image.jpg");
        args->SetData(imageData);
        return ResourceLoadingAction::UserProvided;
    }
};

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"presentation-with-external-images.pptx", loadOptions);
Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Tải Bài Thuyết Trình mà Không Có Đối Tượng Nhị Phân Nhúng**

Một bài thuyết trình có thể chứa dữ liệu nhị phân nhúng mà ứng dụng không cần hoặc không muốn giữ lại. Các ví dụ bao gồm:

- Dự án VBA, có sẵn thông qua [IPresentation::get_VbaProject](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/get_vbaproject/);
- Dữ liệu OLE nhúng, có sẵn thông qua [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/);
- Dữ liệu điều khiển ActiveX, có sẵn thông qua [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icontrol/get_activexcontrolbinary/).

Truyền `true` vào [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) để loại bỏ dữ liệu nhị phân này trong quá trình tải. Lưu bài thuyết trình đã tải để duy trì kết quả đã được làm sạch.

Tùy chọn này giảm nguy cơ tiếp xúc với các payload nhúng không mong muốn, nhưng không phải là một hệ thống phát hiện phần mềm độc hại hay làm sạch nội dung hoàn chỉnh.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"presentation-with-embedded-data.pptx", loadOptions);

presentation->Save(u"presentation-without-embedded-data.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Câu Hỏi Thường Gặp**

**Làm thế nào để biết một tệp bị hỏng và không thể mở được?**

Aspose.Slides sẽ ném ra ngoại lệ phân tích hoặc định dạng trong quá trình tải. Hãy xử lý lỗi này riêng biệt với lỗi mật khẩu không đúng để ứng dụng có thể báo cáo nguyên nhân một cách chính xác.

**Điều gì sẽ xảy ra nếu thiếu các phông chữ bắt buộc?**

Bài thuyết trình vẫn có thể tải, nhưng quá trình hiển thị và xuất có thể thay thế phông chữ. Bạn có thể [configure font substitution](/slides/vi/cpp/font-substitution/) hoặc [provide custom fonts](/slides/vi/cpp/custom-font/) để làm cho đầu ra dự đoán được hơn.

**Việc tải một bài thuyết trình có đồng thời tải các phương tiện nhúng không?**

Âm thanh và video nhúng sẽ khả dụng thông qua mô hình đối tượng của bài thuyết trình. Các tài nguyên ngoại vi được giải quyết theo hành vi tải tài nguyên đã cấu hình và có thể không khả dụng nếu không thể truy cập tới vị trí của chúng.