---
title: Mở Trình Chiếu trong C++
linktitle: Mở Trình Chiếu
type: docs
weight: 20
url: /vi/cpp/open-presentation/
keywords:
- mở PowerPoint
- mở OpenDocument
- mở trình chiếu
- mở PPTX
- mở PPT
- mở ODP
- tải trình chiếu
- tải PPTX
- tải PPT
- tải ODP
- trình chiếu được bảo vệ
- trình chiếu lớn
- tài nguyên bên ngoài
- đối tượng nhị phân
- C++
- Aspose.Slides
description: "Tìm hiểu cách mở các trình chiếu PowerPoint và OpenDocument trong C++, cung cấp mật khẩu mở, kiểm soát việc tải tài nguyên, và giảm việc sử dụng bộ nhớ với Aspose.Slides cho C++."
---
## **Giới thiệu**

[Aspose.Slides for C++](https://products.aspose.com/slides/vi/cpp/) có thể tải các bản trình chiếu PowerPoint và OpenDocument từ tệp và luồng. Sau khi một bản trình chiếu được tải, bạn có thể kiểm tra cấu trúc của nó, chỉnh sửa các slide, quản lý tài nguyên và lưu nó ở định dạng gốc hoặc định dạng hỗ trợ khác.

Hành vi tải có thể được tùy chỉnh thông qua lớp [LoadOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/). Ví dụ, bạn có thể cung cấp mật khẩu mở, giữ các đối tượng nhị phân lớn ngoài bộ nhớ, kiểm soát tài nguyên bên ngoài, hoặc bỏ qua dữ liệu nhị phân nhúng.

## **Mở trình chiếu**

Sau khi tải một tệp hoặc luồng, bạn có thể [xác định định dạng trình chiếu gốc](/slides/vi/cpp/detect-presentation-source-format/) để lựa chọn cách ứng dụng của bạn xử lý nó.

Để mở một trình chiếu hiện có, truyền đường dẫn tệp của nó vào hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/). Giải phóng (dispose) đối tượng trình chiếu sau khi sử dụng để các handle tệp, dữ liệu tạm thời và các tài nguyên khác được giải phóng kịp thời.

Ví dụ C++ sau đây cho thấy cách mở một trình chiếu và lấy số lượng slide của nó:

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

## **Mở trình chiếu được bảo vệ bằng mật khẩu**

Mật khẩu mở mã hoá nội dung của trình chiếu. Để tải toàn bộ trình chiếu, truyền mật khẩu đúng vào [LoadOptions::set_Password](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_password/) và truyền các tùy chọn vào hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/). Việc tải sẽ thất bại nếu mật khẩu bị thiếu hoặc không đúng.

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

Để biết thêm về việc phát hiện mật khẩu, xác thực và quy trình mã hoá, xem [Password-Protect Presentations](/slides/vi/cpp/password-protected-presentation/). Nếu một trình chiếu được mã hoá cố ý lưu với các thuộc tính tài liệu công khai, các thuộc tính đó có thể được đọc mà không cần mật khẩu; xem [Manage Presentation Properties](/slides/vi/cpp/presentation-properties/).

## **Mở trình chiếu lớn**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) kiểm soát cách Aspose.Slides xử lý các đối tượng nhị phân lớn (BLOB) như hình ảnh, âm thanh và video. Bạn có thể giữ tệp nguồn bị khóa, cho phép tệp tạm thời, và giới hạn lượng dữ liệu BLOB được giữ trong bộ nhớ.

Mã C++ sau đây minh họa việc tải một trình chiếu lớn (ví dụ, 2 GB):

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

{{% alert color="info" title="Note" %}}
Với `PresentationLockingBehavior::KeepLocked`, tệp nguồn sẽ vẫn bị khóa cho đến khi đối tượng `Presentation` được giải phóng. Không di chuyển, ghi đè hoặc xóa tệp nguồn khi đối tượng này còn tồn tại.

Aspose.Slides có thể sao chép nội dung của một luồng đầu vào trong quá trình tải. Đối với những trình chiếu lớn, đường dẫn tệp thường hiệu quả hơn so với việc dùng luồng. Xem [Manage BLOBs](/slides/vi/cpp/manage-blob/) để biết thêm các tùy chọn lưu trữ và quản lý bộ nhớ.
{{% /alert %}}

## **Kiểm soát tài nguyên bên ngoài**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) chấp nhận một triển khai của [IResourceLoadingCallback](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iresourceloadingcallback/). Callback có thể cung cấp dữ liệu thay thế, chuyển hướng một tài nguyên, sử dụng bộ tải mặc định, hoặc bỏ qua tài nguyên đó. Điều này hữu ích khi các trình chiếu chứa hình ảnh bên ngoài cần được giải quyết theo các quy tắc bảo mật hoặc lưu trữ riêng của ứng dụng.

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

## **Tải trình chiếu mà không có đối tượng nhị phân nhúng**

Một trình chiếu có thể chứa dữ liệu nhị phân nhúng mà một ứng dụng không cần hoặc không muốn giữ lại. Những ví dụ bao gồm:

- Dự án VBA, có sẵn thông qua [IPresentation::get_VbaProject](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/get_vbaproject/);
- dữ liệu OLE nhúng, có sẵn thông qua [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/);
- dữ liệu điều khiển ActiveX, có sẵn thông qua [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icontrol/get_activexcontrolbinary/).

Truyền `true` vào [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) để loại bỏ dữ liệu nhị phân này trong quá trình tải. Lưu trình chiếu đã tải để duy trì kết quả đã được làm sạch.

Tùy chọn này giảm thiểu khả năng tiếp xúc với các payload nhúng không mong muốn, nhưng không phải là hệ thống phát hiện phần mềm độc hại hay làm sạch nội dung hoàn chỉnh.

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

## **Câu hỏi thường gặp**

**Làm sao tôi biết một tệp bị hỏng và không thể mở?**

Aspose.Slides ném ra một ngoại lệ khi phân tích hoặc định dạng trong quá trình tải. Xử lý lỗi này riêng biệt so với lỗi mật khẩu không đúng để ứng dụng có thể báo cáo nguyên nhân một cách chính xác.

**Điều gì xảy ra nếu các phông chữ bắt buộc bị thiếu?**

Trình chiếu vẫn có thể được tải, nhưng việc render và xuất có thể thay thế phông chữ. Bạn có thể [configure font substitution](/slides/vi/cpp/font-substitution/) hoặc [provide custom fonts](/slides/vi/cpp/custom-font/) để làm cho đầu ra dự đoán được hơn.

**Việc tải một trình chiếu có đồng thời tải các phương tiện nhúng không?**

Âm thanh và video nhúng sẽ khả dụng thông qua mô hình đối tượng của trình chiếu. Các tài nguyên bên ngoài được giải quyết dựa trên hành vi tải tài nguyên đã cấu hình và có thể không có sẵn nếu không thể truy cập vị trí của chúng.