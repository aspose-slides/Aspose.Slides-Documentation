---
title: Kết hợp bài thuyết trình một cách hiệu quả trong C++
linktitle: Kết hợp bài thuyết trình
type: docs
weight: 40
url: /vi/cpp/merge-presentation/
keywords:
- kết hợp PowerPoint
- kết hợp bài thuyết trình
- kết hợp slide
- kết hợp PPT
- kết hợp PPTX
- kết hợp ODP
- gộp PowerPoint
- gộp bài thuyết trình
- gộp slide
- gộp PPT
- gộp PPTX
- gộp ODP
- C++
- Aspose.Slides
description: "Tìm hiểu cách kết hợp các bài thuyết trình PowerPoint và OpenDocument trong C++ bằng cách sao chép slide, kiểm soát master và layout, thay đổi kích thước nội dung slide, bảo tồn các phần, và xử lý các tệp được bảo mật hoặc lớn."
---
## **Tổng quan**

Aspose.Slides for C++ hợp nhất các bài thuyết trình bằng cách sao chép các slide từ một [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) sang một bài thuyết trình khác. Hoạt động chính là [ISlideCollection::AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/), có thể giữ nguyên định dạng của slide nguồn hoặc đính kèm slide đã sao chép vào một master hoặc layout trong bài thuyết trình đích.

Bài viết này bao gồm các quy trình hợp nhất phổ biến nhất:

- hợp nhất tất cả các slide đồng thời giữ định dạng nguồn;
- hợp nhất các slide đã chọn;
- áp dụng master từ bài thuyết trình đích;
- áp dụng một layout cụ thể từ bài thuyết trình đích;
- chuẩn hoá các kích thước slide khác nhau trước khi hợp nhất;
- thêm các slide đã sao chép vào một phần (section);
- hợp nhất nhiều bài thuyết trình trong một quy trình đầu cuối;
- xử lý master, tài nguyên, ghi chú, bình luận, phương tiện, phông chữ, mật khẩu, tệp lớn và các vấn đề đa luồng.

## **Cách sao chép slide ảnh hưởng đến Master và Layout**

Một slide kế thừa phần lớn giao diện của layout và master. Vì vậy, phương thức overload mà bạn chọn sẽ quyết định cách slide đã hợp nhất được tích hợp vào bài thuyết trình đích.

Sử dụng [ISlideCollection::AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) theo một trong các cách sau:

- `AddClone(sourceSlide)` — giữ nguyên layout và định dạng của slide nguồn. Khi cần, master nguồn có thể được sao chép tự động vào bài thuyết trình đích. Aspose.Slides tự động theo dõi các master đã sao chép để các slide lặp lại sử dụng cùng một master nguồn không gây sao chép lại master đó.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — gắn slide đã sao chép vào một [IMasterSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslide/) đích cụ thể. Aspose.Slides sẽ tìm layout phù hợp dưới master đó dựa trên loại hoặc tên layout.
- `AddClone(sourceSlide, destinationLayout)` — gắn slide đã sao chép trực tiếp vào một [ILayoutSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslide/) đích cụ thể.

Master hoặc layout được truyền vào overload `AddClone` phải thuộc về **bài thuyết trình đích**, không phải bài thuyết trình nguồn.

## **Hợp nhất toàn bộ bài thuyết trình và giữ định dạng nguồn**

Cách hợp nhất đơn giản nhất là sao chép mọi slide từ bài thuyết trình nguồn sang bài thuyết trình đích. Đây là lựa chọn phù hợp khi các slide được nhập phải giữ nguyên giao diện, master và mối quan hệ layout gốc.

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

Kết quả có thể chứa nhiều master khi nguồn và đích sử dụng các thiết kế khác nhau. Điều này là mong đợi khi định dạng nguồn được cố ý giữ lại.

## **Hợp nhất các slide đã chọn**

Bạn không cần sao chép mọi slide. Ví dụ dưới đây chỉ nhập các chỉ số slide đã chọn từ bài thuyết trình nguồn.

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

Kiểm tra chỉ số slide trước khi sao chép khi chúng đến từ đầu vào của người dùng hoặc cấu hình bên ngoài.

## **Hợp nhất slide bằng Master đích**

Sử dụng overload [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) khi các slide được nhập cần tuân theo một master đã thuộc về bài thuyết trình đích.

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

Aspose.Slides sẽ chọn một layout phù hợp dưới master đã chỉ định bằng cách khớp loại hoặc tên layout nguồn. Nếu không tồn tại layout thích hợp và `allowCloneMissingLayout` là `true`, layout nguồn sẽ được sao chép để slide có thể được thêm. Nếu `false`, một [PptxEditException](https://reference.aspose.com/slides/vi/cpp/aspose.slides/details_pptxeditexception/) sẽ được ném ra.

Sử dụng `false` khi bạn muốn quá trình hợp nhất thất bại thay vì tạo thêm một layout mới vào master đích.

## **Hợp nhất slide bằng Layout đích cụ thể**

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

Áp dụng layout đích thay đổi mối quan hệ layout kế thừa; nó không thay đổi nội dung slide nguồn. Nếu layout nguồn và đích có cấu trúc placeholder khác nhau, hãy kiểm tra kết quả để xác nhận định dạng kế thừa và hành vi placeholder là phù hợp.

## **Hợp nhất các bài thuyết trình có kích thước slide khác nhau**

Các bài thuyết trình có kích thước slide khác nhau có thể được hợp nhất, nhưng sao chép một slide vào bài thuyết trình có kích thước khác sẽ không tự động thiết kế lại nội dung cho canvas mới. Do đó các hình dạng có thể bị lệch, thu phóng không mong muốn hoặc nằm ngoài vùng hiển thị của slide.

Một cách thực tiễn là thay đổi kích thước bài thuyết trình nguồn trước khi sao chép. Phương thức [SlideSize::SetSize](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slidesize/setsize/) có thể thu phóng nội dung hiện có đồng thời thay đổi kích thước slide. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slidesizescaletype/) thu phóng nội dung để vừa với kích thước yêu cầu.

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

Thay đổi kích thước sẽ sửa đổi đối tượng bài thuyết trình nguồn trong bộ nhớ. Nếu bạn cần giữ nguyên bản gốc cho các thao tác khác, hãy mở một thể hiện riêng cho việc hợp nhất.

## **Hợp nhất slide vào một Section của bài thuyết trình**

Vòng lặp sao chép slide cơ bản không tái tạo cấu trúc section của bài thuyết trình nguồn. Nếu section quan trọng trong kết quả, hãy tạo hoặc chọn các section trong bài thuyết trình đích và sao chép slide vào chúng một cách rõ ràng bằng [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/).

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

Các slide đã sao chép sẽ được thêm vào section đích đã chỉ định. Để giữ lại nhiều section nguồn, liệt kê [Presentation::get_Sections](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_sections/), lấy danh sách slide hiện tại của mỗi section nguồn bằng [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isection/getslideslistofsection/), tạo lại các section trong bài thuyết trình đích, và sao chép từng slide vào section đích tương ứng. Xem [Manage Slide Sections](/slides/vi/cpp/slide-section/) để có ví dụ đầy đủ về liệt kê section, bao gồm các section rỗng và thay đổi cấu trúc.

## **Hợp nhất nhiều bài thuyết trình một cách an toàn**

Ví dụ đầu cuối dưới đây sử dụng bài thuyết trình đầu tiên làm đích, chuẩn hoá kích thước slide của mỗi nguồn bổ sung, giữ mỗi nguồn mở chỉ trong thời gian sao chép, và lưu tệp cuối cùng một lần.

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

Đây là một nền tảng hữu ích để giữ định dạng nguồn của các slide được nhập. Nếu đầu ra của bạn phải sử dụng một chủ đề đích duy nhất, hãy thay thế cuộc gọi `AddClone(slide)` đơn giản bằng overload master hoặc layout đích thích hợp đã trình bày ở trên.

## **Các cân nhắc thực tiễn**

### **Master, Layout và độ trung thực định dạng**

Sao chép slide mặc định có thể tự động đưa master nguồn cần thiết vào bài thuyết trình đích. Aspose.Slides duy trì một đăng ký nội bộ cho các master được sao chép tự động nhằm tránh việc sao chép cùng một master nhiều lần. Các master được sao chép thủ công không được đăng ký, vì vậy tránh sao chép trước các master trừ khi bạn cần kiểm soát cấu trúc master một cách rõ ràng.

Đừng cho rằng hai master hoặc layout có cùng tên sẽ hiển thị giống nhau. Nếu mẫu công ty phải kiểm soát giao diện cuối cùng, hãy chọn một master hoặc layout đích một cách rõ ràng và kiểm tra kết quả sau khi hợp nhất.

### **Ghi chú và bình luận**

Ghi chú người thuyết trình và bình luận slide được gắn với nội dung slide và sẽ được sao chép khi slide được sao chép. Aspose.Slides cũng cung cấp các API riêng cho [presentation notes](/slides/vi/cpp/presentation-notes/) và [presentation comments](/slides/vi/cpp/presentation-comments/).

Nếu định dạng trang ghi chú quan trọng, hãy kiểm tra bài thuyết trình đã hợp nhất vì master ghi chú là đối tượng ở mức presentation và có thể khác nhau giữa các tệp nguồn. Đối với quy trình xem xét, cũng hãy xác minh tác giả bình luận và các chuỗi bình luận sau khi kết hợp các tệp từ các tác giả hoặc mẫu khác nhau.

### **Hình ảnh, âm thanh, video, đối tượng OLE và liên kết ngoài**

Các slide có thể tham chiếu tới tài nguyên ở mức presentation như hình ảnh, âm thanh nhúng, video nhúng và dữ liệu OLE. Hãy sao chép toàn bộ slide thay vì chỉ sao chép các hình dạng hiển thị để Aspose.Slides có thể duy trì các quan hệ của slide với tài nguyên của nó.

Tài nguyên nhúng và liên kết nên được xử lý khác nhau. Một audio, video, đối tượng OLE hoặc siêu liên kết được liên kết vẫn phụ thuộc vào mục tiêu bên ngoài; sao chép slide không biến một liên kết ngoài thành nội dung nhúng. Kiểm tra đường dẫn và URL của tài nguyên liên kết trong môi trường nơi bài thuyết trình hợp nhất sẽ được mở.

Aspose.Slides theo dõi các master được sao chép tự động, nhưng điều này không đồng nghĩa với việc mọi tài nguyên nhị phân giống nhau từ các nguồn không liên quan sẽ luôn được loại bỏ trùng lặp. Nếu kích thước tệp đầu ra là quan trọng, hãy kiểm tra gói đã hợp nhất và đo kết quả thay vì dựa vào việc loại bỏ trùng lặp ngầm.

### **Phông chữ nhúng và tính khả dụng của phông chữ**

Phông chữ được quản lý ở mức presentation. Nếu kiểu chữ phải nhất quán trên các máy, đừng cho rằng việc sao chép slide đơn thuần sẽ đảm bảo mọi phông chữ cần thiết đã có sẵn trong môi trường đích. Bạn có thể kiểm tra phông chữ nhúng bằng [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsmanager/getembeddedfonts/) và quản lý việc nhúng một cách rõ ràng như mô tả trong [Embed Fonts in Presentations](/slides/vi/cpp/embedded-font/).

Cũng hãy xác minh rằng bạn có quyền nhúng các phông chữ được sử dụng trong các tệp nguồn. Giấy phép phông chữ có thể hạn chế việc nhúng.

### **Bài thuyết trình được bảo vệ bằng mật khẩu**

Một nguồn được bảo vệ bằng mật khẩu phải được mở thành công trước khi có thể sao chép các slide của nó. Cung cấp mật khẩu qua [LoadOptions::set_Password](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_password/).

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

Mở một nguồn đã mã hoá không tự động áp dụng cùng một bảo vệ cho bài thuyết trình đích. Cấu hình bảo vệ đầu ra riêng khi cần.

### **Bài thuyết trình lớn và việc sử dụng bộ nhớ**

Các bài thuyết trình lớn chứa hình ảnh độ phân giải cao, âm thanh, video hoặc các đối tượng nhị phân lớn khác có thể tiêu tốn nhiều bộ nhớ. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) cung cấp các tùy chọn để quản lý BLOB và việc sử dụng tệp tạm. Xem [Manage Presentation BLOBs](/slides/vi/cpp/manage-blob/) để có các chiến lược cho tệp lớn.

Đối với tệp lớn, ưu tiên tải từ đường dẫn tệp khi có thể, giải phóng mỗi bài thuyết trình nguồn ngay sau khi đã hợp nhất, và tránh lưu kết quả trung gian liên tục trừ khi quy trình yêu cầu checkpoint.

### **An toàn đa luồng**

Không tải, sửa đổi, lưu hoặc sao chép cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) đồng thời từ nhiều luồng. Giữ mỗi thể hiện presentation chỉ dùng cho một thao tác hợp nhất. Nếu bạn thực hiện các công việc độc lập song song, hãy dùng các thể hiện presentation riêng biệt và tuân thủ [hướng dẫn đa luồng của Aspose.Slides](/slides/vi/cpp/multithreading/).

## **Câu hỏi thường gặp**

**Làm thế nào để giữ nguyên thiết kế gốc của mỗi bài thuyết trình nguồn?**

Sử dụng [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) mà không cung cấp master hoặc layout đích. Aspose.Slides có thể tự động sao chép master nguồn khi slide nhập cần đến.

**Làm sao để các slide nhập vào sử dụng chủ đề của đích?**

Sử dụng overload chấp nhận một master đích. Cung cấp một master từ bài thuyết trình đích, không phải từ nguồn. Aspose.Slides sẽ cố gắng ánh xạ mỗi slide nguồn tới một layout phù hợp dưới master đó.

**Khi nào nên dùng layout đích cụ thể thay vì master đích?**

Dùng layout cụ thể khi mọi slide nhập vào phải sử dụng cùng một layout đã biết. Dùng master khi bạn muốn Aspose.Slides tự chọn giữa các layout của master đó dựa trên loại hoặc tên layout nguồn.

**Có thể hợp nhất các bài thuyết trình có kích thước slide khác nhau không?**

Có, nhưng nội dung slide sẽ không tự động được thiết kế lại cho kích thước đích. Hãy thay đổi kích thước bài thuyết trình nguồn trước khi sao chép, ví dụ bằng [SlideSize::SetSize](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slidesize/setsize/) và [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slidesizescaletype/).

**Có thể hợp nhất các tệp PPT, PPTX và ODP thành một file không?**

Có. Tải mỗi bài thuyết trình nguồn, sao chép các slide cần thiết vào một đích, và lưu đích ở định dạng đầu ra được hỗ trợ. Vì các định dạng presentation không hỗ trợ đầy đủ cùng một tập hợp tính năng, hãy kiểm tra nội dung phức tạp sau khi hợp nhất đa định dạng. Xem [Supported File Formats](/slides/vi/cpp/supported-file-formats/).

**Các section nguồn có được giữ tự động không?**

Không, nếu chỉ dùng vòng lặp cơ bản sao chép slide. Hãy tạo lại các section cần thiết trong đích và sử dụng overload section của [AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) khi cấu trúc section phải được bảo lưu.

**Ghi chú và bình luận có được giữ lại không?**

Chúng được sao chép cùng với slide đã sao chép. Đối với quy trình phụ thuộc vào kiểu dáng master ghi chú, tác giả bình luận hoặc dữ liệu đánh giá chuỗi, hãy kiểm tra kết quả đã hợp nhất vì những trường hợp này liên quan tới cấu trúc ở mức presentation cũng như nội dung slide.

**Điều gì xảy ra với audio, video, đối tượng OLE và siêu liên kết?**

Nội dung nhúng sẽ được mang theo như một phần của các quan hệ tài nguyên của slide đã sao chép. Các liên kết ngoài vẫn giữ nguyên trạng thái ngoài, do đó các tệp hoặc URL mục tiêu vẫn phải tồn tại sau khi hợp nhất.

**Các phông chữ nhúng từ mọi nguồn có được đảm bảo có trong bài thuyết trình hợp nhất không?**

Đừng dựa vào việc sao chép slide để triển khai phông chữ. Kiểm tra phông chữ nhúng của đích và quản lý việc nhúng phông chữ hoặc khả năng truy cập phông chữ bên ngoài một cách rõ ràng khi kiểu chữ quan trọng.

**Làm sao để hợp nhất tệp được bảo vệ bằng mật khẩu?**

Mở tệp bằng [LoadOptions::set_Password](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_password/), sau đó sao chép các slide như bình thường. Bảo vệ đầu ra được cấu hình riêng.

**Nên xử lý các bài thuyết trình rất lớn như thế nào?**

Sử dụng quản lý BLOB khi các đối tượng nhị phân lớn chiếm ưu thế trong việc sử dụng bộ nhớ, ưu tiên tải từ đường dẫn tệp cho các tệp rất lớn, giải phóng nhanh các presentation nguồn và chỉ lưu kết quả cuối cùng khi cần.

**Có thể hợp nhất slide từ nhiều luồng không?**

Không sử dụng cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) đồng thời từ nhiều luồng. Giữ mỗi thao tác hợp nhất độc lập với các thể hiện presentation riêng biệt.