---
title: Hiệu quả hợp nhất các bản trình bày trong C++
linktitle: Hợp nhất các bản trình bày
type: docs
weight: 40
url: /vi/cpp/merge-presentation/
keywords:
- hợp nhất PowerPoint
- hợp nhất bản trình bày
- hợp nhất slide
- hợp nhất PPT
- hợp nhất PPTX
- hợp nhất ODP
- kết hợp PowerPoint
- kết hợp bản trình bày
- kết hợp slide
- kết hợp PPT
- kết hợp PPTX
- kết hợp ODP
- C++
- Aspose.Slides
description: "Tìm hiểu cách hợp nhất các bản trình bày PowerPoint và OpenDocument trong C++ bằng cách sao chép slide, kiểm soát master và layout, thay đổi kích thước nội dung slide, bảo tồn các phần, và xử lý các tệp được bảo mật hoặc có kích thước lớn."
---
## **Tổng quan**

Aspose.Slides cho C++ hợp nhất các bản trình bày bằng cách sao chép các slide từ một [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) sang bản khác. Thao tác chính là [ISlideCollection::AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/), có thể giữ nguyên định dạng của slide nguồn hoặc gắn slide đã sao chép vào một master hoặc layout trong bản trình bày đích.

Bài viết này đề cập đến các quy trình hợp nhất phổ biến nhất:

- hợp nhất tất cả các slide trong khi giữ nguyên định dạng nguồn;
- hợp nhất các slide được chọn;
- áp dụng một master từ bản trình bày đích;
- áp dụng một layout cụ thể từ bản trình bày đích;
- chuẩn hoá các kích thước slide khác nhau trước khi hợp nhất;
- thêm các slide đã sao chép vào một phần;
- hợp nhất nhiều bản trình bày trong một quy trình đầu‑cuối;
- xử lý master, tài nguyên, ghi chú, bình luận, phương tiện, phông chữ, mật khẩu, tệp lớn và các vấn đề đa luồng.

## **Cách sao chép Slide ảnh hưởng đến Masters và Layouts**

Một slide kế thừa phần lớn giao diện của nó từ layout và master. Vì lý do này, overload sao chép mà bạn chọn quyết định cách slide được hợp nhất sẽ được tích hợp vào bản trình bày đích.

Sử dụng [ISlideCollection::AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) theo một trong các cách sau:

- `AddClone(sourceSlide)` — giữ nguyên layout và định dạng của slide nguồn. Khi cần, master nguồn có thể được sao chép tự động vào bản trình bày đích. Aspose.Slides theo dõi các master được sao chép tự động nên các slide lặp lại sử dụng cùng một master nguồn sẽ không gây sao chép master đó nhiều lần.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — gắn slide đã sao chép vào một [IMasterSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslide/) đích cụ thể. Aspose.Slides tìm kiếm một layout phù hợp dưới master đó theo loại layout hoặc tên.
- `AddClone(sourceSlide, destinationLayout)` — gắn slide đã sao chép trực tiếp vào một [ILayoutSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslide/) đích cụ thể.

Master hoặc layout được truyền vào overload `AddClone` phải thuộc về **bản trình bày đích**, không phải bản trình bày nguồn.

## **Hợp nhất Toàn bộ Bản trình bày và Giữ Định dạng Nguồn**

Cách hợp nhất đơn giản nhất sao chép mọi slide từ bản trình bày nguồn sang bản trình bày đích. Đây là lựa chọn phù hợp khi các slide nhập vào cần giữ nguyên giao diện, master và mối quan hệ layout gốc.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged.pptx", SaveFormat::Pptx);
```

Bản trình bày kết quả có thể chứa nhiều master khi nguồn và đích sử dụng các thiết kế khác nhau. Điều này là mong đợi khi định dạng nguồn được cố ý giữ lại.

## **Hợp nhất Các Slide Được Chọn**

Bạn không cần sao chép mọi slide. Ví dụ sau chỉ nhập các chỉ mục slide được chọn từ bản trình bày nguồn.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

int32_t slideIndexes[] = {0, 2, 4};

for (auto index : slideIndexes)
{
    destination->get_Slides()->AddClone(source->get_Slide(index));
}

destination->Save(u"merged-selected-slides.pptx", SaveFormat::Pptx);
```

Xác thực các chỉ mục slide trước khi sao chép khi chúng đến từ đầu vào của người dùng hoặc cấu hình bên ngoài.

## **Hợp nhất Slide bằng Master Đích**

Sử dụng overload [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) khi các slide nhập vào nên tuân theo một master đã thuộc về bản trình bày đích.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationMaster = destination->get_Master(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationMaster, true);
}

destination->Save(u"merged-with-destination-master.pptx", SaveFormat::Pptx);
```

Aspose.Slides chọn một layout phù hợp dưới master đã chỉ định bằng cách khớp loại hoặc tên layout nguồn. Nếu không tồn tại layout phù hợp và `allowCloneMissingLayout` là `true`, layout nguồn sẽ được sao chép để slide có thể được thêm. Nếu là `false`, một [PptxEditException](https://reference.aspose.com/slides/vi/cpp/aspose.slides/details_pptxeditexception/) sẽ được ném ra.

Sử dụng `false` khi bạn muốn quá trình hợp nhất thất bại thay vì thêm một layout bổ sung vào master đích.

## **Hợp nhất Slide bằng Layout Đích Cụ Thể**

Sử dụng overload [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) khi bạn biết chính xác layout đích mà các slide nhập vào phải sử dụng.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationLayout = destination->get_LayoutSlide(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationLayout);
}

destination->Save(u"merged-with-destination-layout.pptx", SaveFormat::Pptx);
```

Áp dụng một layout đích thay đổi mối quan hệ layout được kế thừa; nó không thay đổi thiết kế nội dung slide nguồn. Nếu layout nguồn và đích có cấu trúc placeholder khác nhau, hãy kiểm tra kết quả để xác nhận rằng định dạng và hành vi placeholder được kế thừa là phù hợp.

## **Hợp nhất Bản trình bày với Kích thước Slide Khác Nhau**

Các bản trình bày có kích thước slide khác nhau có thể được hợp nhất, nhưng sao chép một slide vào một bản trình bày có kích thước slide khác không tự động thiết kế lại nội dung cho khung vẽ mới. Vì vậy các hình dạng có thể xuất hiện lệch, tỷ lệ không mong muốn hoặc nằm ngoài khu vực slide có thể nhìn thấy.

Một cách thực tế là thay đổi kích thước bản trình bày nguồn trước khi sao chép. Phương thức [SlideSize::SetSize](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slidesize/setsize/) có thể thu phóng nội dung hiện có đồng thời thay đổi kích thước slide. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slidesizescaletype/) thu phóng nội dung để vừa với kích thước yêu cầu.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationSize = destination->get_SlideSize()->get_Size();
auto sourceSize = source->get_SlideSize()->get_Size();

if (sourceSize.get_Width() != destinationSize.get_Width() || 
    sourceSize.get_Height() != destinationSize.get_Height())
{
    source->get_SlideSize()->SetSize(
        destinationSize.get_Width(), 
        destinationSize.get_Height(), 
        SlideSizeScaleType::EnsureFit);
}

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged-same-slide-size.pptx", SaveFormat::Pptx);
```

Thay đổi kích thước làm thay đổi đối tượng bản trình bày nguồn trong bộ nhớ. Nếu bạn cần giữ nguyên bản trình bày nguồn cho các hoạt động khác, hãy mở một thể hiện riêng cho quá trình hợp nhất.

## **Hợp nhất Slide vào Phần của Bản Trình Bày**

Vòng lặp sao chép slide cơ bản không tái tạo cấu trúc phân đoạn (section) của bản trình bày nguồn. Nếu các phần quan trọng trong kết quả, hãy tạo hoặc chọn các phần trong bản trình bày đích và sao chép slide vào chúng một cách rõ ràng bằng [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/).

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto importedSection = destination->get_Sections()->AppendEmptySection(u"Imported slides");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, importedSection);
}

destination->Save(u"merged-with-section.pptx", SaveFormat::Pptx);
```

Các slide đã sao chép sẽ được nối vào phần đích đã chỉ định. Để giữ lại nhiều phần nguồn, hãy tái tạo các phần đó trong đích và ánh xạ mỗi slide nguồn tới phần đích tương ứng.

## **Hợp nhất Nhiều Bản Trình Bày Một cách An Toàn**

Ví dụ đầu‑cuối sau sử dụng bản trình bày đầu tiên làm đích, chuẩn hoá kích thước slide của mỗi nguồn bổ sung, giữ mỗi nguồn mở chỉ trong thời gian sao chép và lưu tệp cuối cùng một lần.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String inputFiles[] = {u"part1.pptx", u"part2.pptx", u"part3.pptx"};
const int32_t inputFileCount = 3;

auto merged = System::MakeObject<Presentation>(inputFiles[0]);
auto mergedSize = merged->get_SlideSize()->get_Size();

for (int32_t fileIndex = 1; fileIndex < inputFileCount; fileIndex++)
{
    auto source = System::MakeObject<Presentation>(inputFiles[fileIndex]);
    auto sourceSize = source->get_SlideSize()->get_Size();

    if (sourceSize.get_Width() != mergedSize.get_Width() || 
        sourceSize.get_Height() != mergedSize.get_Height())
    {
        source->get_SlideSize()->SetSize(
            mergedSize.get_Width(), 
            mergedSize.get_Height(), 
            SlideSizeScaleType::EnsureFit);
    }

    for (const auto& slide : source->get_Slides())
    {
        merged->get_Slides()->AddClone(slide);
    }
}

merged->Save(u"merged.pptx", SaveFormat::Pptx);
```

Đây là một nền tảng hữu ích để giữ định dạng nguồn của các slide được nhập. Nếu đầu ra của bạn phải sử dụng một chủ đề đích duy nhất, hãy thay thế lời gọi đơn giản `AddClone(slide)` bằng overload master hoặc layout đích phù hợp đã trình bày ở trên.

## **Cân nhắc Thực tiễn**

### **Masters, Layouts và Độ chính xác Định dạng**

Sao chép slide mặc định có thể tự động đưa master nguồn cần thiết vào bản trình bày đích. Aspose.Slides giữ một bản ghi nội bộ cho các master được sao chép tự động nhằm tránh sao chép cùng một master nhiều lần. Các master được sao chép thủ công không được bản ghi này theo dõi, vì vậy tránh sao chép trước các master trừ khi bạn cần kiểm soát rõ ràng cấu trúc master.

Đừng cho rằng hai master hoặc layout có cùng tên sẽ hiển thị giống nhau. Nếu mẫu công ty phải kiểm soát diện mạo cuối cùng, hãy chọn rõ ràng một master hoặc layout đích và xác minh kết quả sau khi hợp nhất.

### **Ghi chú và Bình luận**

Ghi chú người thuyết trình và bình luận slide được gắn với nội dung slide và sẽ được sao chép khi một slide được sao chép. Aspose.Slides cũng cung cấp các API riêng cho [presentation notes](https://docs.aspose.com/slides/vi/cpp/presentation-notes/) và [presentation comments](https://docs.aspose.com/slides/vi/cpp/presentation-comments/).

Nếu định dạng trang ghi chú quan trọng, hãy kiểm tra bản trình bày đã hợp nhất vì notes master là đối tượng cấp trình bày và có thể khác nhau giữa các tệp nguồn. Đối với quy trình xem xét, cũng hãy kiểm tra tác giả bình luận và các chuỗi bình luận sau khi ghép các tệp từ các tác giả hoặc mẫu khác nhau.

### **Hình ảnh, Âm thanh, Video, Đối tượng OLE và Liên kết Ngoài**

Slide có thể tham chiếu tới các tài nguyên cấp trình bày như hình ảnh, âm thanh nhúng, video nhúng và dữ liệu OLE. Hãy sao chép toàn bộ slide thay vì chỉ sao chép các hình dạng hiển thị để Aspose.Slides có thể duy trì các mối quan hệ của slide với các tài nguyên của nó.

Các tài nguyên nhúng và liên kết nên được xử lý khác nhau. Một âm thanh, video, đối tượng OLE hoặc siêu liên kết được liên kết vẫn phụ thuộc vào mục tiêu bên ngoài; sao chép một slide không biến một liên kết ngoài thành nội dung nhúng. Hãy kiểm tra đường dẫn và URL của tài nguyên liên kết trong môi trường mà bản trình bày hợp nhất sẽ được mở.

Aspose.Slides theo dõi rõ ràng các master được sao chép tự động, nhưng không nên coi đây là cam kết chung rằng các tài nguyên nhị phân giống hệt từ các bản trình bày nguồn không liên quan sẽ luôn được loại bỏ trùng lặp. Nếu kích thước tệp đầu ra quan trọng, hãy kiểm tra gói đã hợp nhất và đo kết quả thay vì dựa vào việc loại bỏ trùng lặp ngầm.

### **Phông chữ Nhúng và Tính khả dụng của Phông chữ**

Phông chữ được quản lý ở cấp độ trình bày. Nếu kiểu chữ phải đồng nhất trên các máy, đừng cho rằng việc sao chép slide đơn độc đảm bảo mọi phông chữ cần thiết đều có sẵn trong môi trường đích. Bạn có thể kiểm tra phông chữ nhúng bằng [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsmanager/getembeddedfonts/) và quản lý việc nhúng một cách rõ ràng như mô tả trong [Embed Fonts in Presentations](https://docs.aspose.com/slides/vi/cpp/embedded-font/).

Cũng hãy xác minh rằng bạn được phép nhúng các phông chữ được sử dụng trong các tệp nguồn. Giấy phép phông chữ có thể hạn chế việc nhúng.

### **Bản Trình Bày Được Bảo Vệ Bằng Mật Khẩu**

Nguồn được bảo vệ bằng mật khẩu phải được mở thành công trước khi các slide của nó có thể được sao chép. Cung cấp mật khẩu qua [LoadOptions::set_Password](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_password/).

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

Mở một nguồn được mã hoá không tự động áp dụng cùng một bảo vệ cho bản trình bày đích. Cấu hình bảo vệ đầu ra riêng biệt khi cần.

### **Bản Trình Bày Lớn và Sử Dụng Bộ Nhớ**

Các bản trình bày lớn chứa hình ảnh độ phân giải cao, âm thanh, video hoặc các đối tượng nhị phân lớn khác có thể tiêu tốn đáng kể bộ nhớ. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) cung cấp các điều khiển cho việc xử lý BLOB và sử dụng tệp tạm. Xem [Manage Presentation BLOBs](https://docs.aspose.com/slides/vi/cpp/manage-blob/) để biết chiến lược với tệp lớn.

Đối với các tệp lớn, ưu tiên tải từ đường dẫn tệp khi có thể, giải phóng mỗi bản trình bày nguồn ngay sau khi đã được hợp nhất, và tránh lưu liên tục các kết quả trung gian trừ khi quy trình yêu cầu các điểm kiểm tra.

### **An toàn đa luồng**

Đừng tải, sửa đổi, lưu hoặc sao chép cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) đồng thời từ nhiều luồng. Giữ mỗi thể hiện bản trình bày trong một thao tác hợp nhất duy nhất. Nếu bạn chạy song song các công việc độc lập, hãy sử dụng các thể hiện bản trình bày độc lập và tuân theo [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/vi/cpp/multithreading/).

## **Câu hỏi thường gặp**

**Làm thế nào để giữ nguyên thiết kế gốc của mỗi bản trình bày nguồn?**

Sử dụng [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) mà không cung cấp master hoặc layout đích. Aspose.Slides có thể tự động sao chép master nguồn khi slide nhập vào cần đến nó.

**Làm thế nào để các slide nhập vào sử dụng chủ đề đích?**

Sử dụng overload chấp nhận một master đích. Cung cấp một master từ bản trình bày đích, không phải từ nguồn. Aspose.Slides sẽ cố gắng ánh xạ mỗi slide nguồn tới một layout phù hợp dưới master đó.

**Khi nào nên sử dụng một layout đích cụ thể thay vì một master đích?**

Sử dụng một layout cụ thể khi mọi slide nhập vào phải dùng một layout đã biết. Sử dụng master khi bạn muốn Aspose.Slides tự chọn giữa các layout của master dựa trên loại hoặc tên layout nguồn.

**Có thể hợp nhất các bản trình bày có kích thước slide khác nhau không?**

Có, nhưng nội dung slide sẽ không tự động được thiết kế lại cho kích thước đích. Hãy thay đổi kích thước bản trình bày nguồn trước khi cần vị trí dự đoán, ví dụ bằng [SlideSize::SetSize](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slidesize/setsize/) và [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slidesizescaletype/).

**Có thể hợp nhất PPT, PPTX và ODP thành một tệp không?**

Có. Tải mỗi bản trình bày nguồn, sao chép các slide cần thiết vào một đích và lưu đích ở định dạng đầu ra được hỗ trợ. Vì các định dạng trình bày không hỗ trợ đầy đủ các tính năng giống nhau, hãy kiểm tra nội dung phức tạp sau khi hợp nhất đa định dạng. Xem [Supported File Formats](https://docs.aspose.com/slides/vi/cpp/supported-file-formats/).

**Các phần nguồn có được bảo tồn tự động không?**

Không, nếu chỉ dùng một vòng lặp cơ bản sao chép slide. Hãy tái tạo các phần cần thiết trong đích và sử dụng overload phần của [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) khi cấu trúc phần phải được giữ.

**Ghi chú và bình luận có được bảo lưu không?**

Chúng được sao chép cùng với slide đã sao chép. Đối với quy trình phụ thuộc vào định dạng notes‑master, tác giả bình luận hoặc dữ liệu đánh giá chuỗi, hãy xác minh kết quả hợp nhất vì các kịch bản này liên quan đến cấu trúc cấp trình bày cũng như nội dung cấp slide.

**Điều gì xảy ra với âm thanh, video, đối tượng OLE và siêu liên kết?**

Nội dung nhúng được mang theo như một phần của các mối quan hệ tài nguyên của slide đã sao chép. Các liên kết ngoài vẫn ở ngoài, vì vậy các tệp hoặc URL mục tiêu phải vẫn khả dụng sau khi hợp nhất.

**Phông chữ nhúng từ mọi nguồn có được đảm bảo có trong bản trình bày hợp nhất không?**

Đừng chỉ dựa vào việc sao chép slide để triển khai phông chữ. Kiểm tra phông chữ nhúng của đích và quản lý việc nhúng phông chữ hoặc tính khả dụng phông chữ bên ngoài một cách rõ ràng khi kiểu chữ quan trọng.

**Làm thế nào để hợp nhất một tệp được bảo vệ bằng mật khẩu?**

Mở nó bằng [LoadOptions::set_Password](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_password/) đúng, sau đó sao chép các slide bình thường. Bảo vệ đầu ra được cấu hình riêng.

**Nên xử lý các bản trình bày rất lớn như thế nào?**

Sử dụng quản lý BLOB khi các đối tượng nhị phân lớn chiếm ưu thế trong việc sử dụng bộ nhớ, ưu tiên tải từ đường dẫn tệp cho các tệp rất lớn, giải phóng nhanh các bản trình bày nguồn và lưu kết quả cuối cùng chỉ khi cần.

**Có thể hợp nhất slide từ nhiều luồng không?**

Đừng sử dụng cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) đồng thời từ nhiều luồng. Giữ mỗi thao tác hợp nhất riêng biệt cho các thể hiện bản trình bày riêng biệt.