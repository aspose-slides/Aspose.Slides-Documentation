---
title: Kết hợp các bản trình chiếu hiệu quả trong .NET
linktitle: Kết hợp bản trình chiếu
type: docs
weight: 40
url: /vi/net/merge-presentation/
keywords:
  - kết hợp PowerPoint
  - kết hợp bản trình chiếu
  - kết hợp slide
  - kết hợp PPT
  - kết hợp PPTX
  - kết hợp ODP
  - kết hợp PowerPoint
  - kết hợp bản trình chiếu
  - kết hợp slide
  - kết hợp PPT
  - kết hợp PPTX
  - kết hợp ODP
  - .NET
  - C#
  - Aspose.Slides
description: "Tìm hiểu cách kết hợp các bản trình chiếu PowerPoint và OpenDocument trong .NET bằng cách sao chép slide, kiểm soát master và layout, thay đổi kích thước nội dung slide, bảo tồn các section và xử lý các tệp được bảo vệ hoặc có kích thước lớn."
---
## **Tổng quan**

Aspose.Slides for .NET hợp nhất các bản trình chiếu bằng cách sao chép slide từ một [Bản trình chiếu](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) sang bản khác. thao tác chính là [ISlideCollection.AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/), có thể giữ nguyên định dạng của slide nguồn hoặc gắn slide đã sao chép vào một master hoặc layout trong bản trình chiếu đích.

Bài viết này bao gồm các quy trình hợp nhất phổ biến nhất:

- hợp nhất tất cả các slide trong khi giữ nguyên định dạng nguồn;
- hợp nhất các slide đã chọn;
- áp dụng master từ bản trình chiếu đích;
- áp dụng một layout cụ thể từ bản trình chiếu đích;
- chuẩn hoá các kích thước slide khác nhau trước khi hợp nhất;
- thêm các slide đã sao chép vào một phần (section);
- hợp nhất nhiều bản trình chiếu trong một quy trình đầu‑cuối;
- xử lý master, tài nguyên, ghi chú, bình luận, media, phông chữ, mật khẩu, tệp lớn và các vấn đề đa luồng.

## **Cách sao chép slide ảnh hưởng đến Master và Layout**

Một slide kế thừa phần lớn giao diện từ layout và master của nó. Vì lý do này, overload sao chép bạn chọn sẽ quyết định cách slide đã hợp nhất được tích hợp vào bản trình chiếu đích.

Sử dụng [ISlideCollection.AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/) theo một trong các cách sau:

- `AddClone(sourceSlide)` — giữ nguyên layout và định dạng của slide nguồn. Khi cần, master nguồn có thể được sao chép tự động vào bản trình chiếu đích. Aspose.Slides tự động theo dõi các master đã sao chép để các slide lặp lại sử dụng cùng master không gây sao chép lại master đó.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — gắn slide đã sao chép vào một [IMasterSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslide/) đích cụ thể. Aspose.Slides sẽ tìm layout phù hợp dưới master đó theo kiểu hoặc tên layout.
- `AddClone(sourceSlide, destinationLayout)` — gắn slide đã sao chép trực tiếp vào một [ILayoutSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/) đích cụ thể.

Master hoặc layout được truyền vào overload `AddClone` phải thuộc về **bản trình chiếu đích**, không phải bản trình chiếu nguồn.

## **Hợp nhất toàn bộ bản trình chiếu và giữ nguyên định dạng nguồn**

Cách hợp nhất đơn giản nhất là sao chép mọi slide từ bản trình chiếu nguồn sang bản trình chiếu đích. Đây là lựa chọn phù hợp khi các slide được nhập cần giữ nguyên giao diện, master và quan hệ layout gốc.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

Bản trình chiếu kết quả có thể chứa nhiều master khi nguồn và đích sử dụng các thiết kế khác nhau. Điều này là bình thường khi định dạng nguồn được cố ý giữ lại.

## **Hợp nhất các slide đã chọn**

Bạn không cần sao chép mọi slide. Ví dụ dưới đây chỉ nhập các chỉ số slide được chọn từ bản trình chiếu nguồn.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

Hãy kiểm tra chỉ số slide trước khi sao chép khi chúng đến từ đầu vào của người dùng hoặc cấu hình bên ngoài.

## **Hợp nhất slide bằng Master đích**

Sử dụng overload [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/) khi các slide nhập vào cần tuân theo một master đã thuộc về bản trình chiếu đích.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

Aspose.Slides sẽ chọn một layout phù hợp dưới master đã chỉ định bằng cách khớp kiểu hoặc tên layout nguồn. Nếu không có layout thích hợp và `allowCloneMissingLayout` là `true`, layout nguồn sẽ được sao chép để slide có thể được thêm. Nếu là `false`, một [PptxEditException](https://reference.aspose.com/slides/vi/net/aspose.slides/pptxeditexception/) sẽ được ném ra.

Sử dụng `false` khi bạn muốn việc hợp nhất thất bại thay vì tạo thêm một layout mới vào master đích.

## **Hợp nhất slide bằng Layout đích cụ thể**

Sử dụng overload [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/) khi bạn biết chính xác layout đích nào mà các slide nhập vào cần sử dụng.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

Áp dụng một layout đích sẽ thay đổi mối quan hệ layout được kế thừa; nó không thay đổi nội dung slide nguồn. Nếu layout nguồn và đích có cấu trúc placeholder khác nhau, hãy kiểm tra kết quả để xác nhận định dạng và hành vi placeholder phù hợp.

## **Hợp nhất bản trình chiếu với các kích thước slide khác nhau**

Các bản trình chiếu có kích thước slide khác nhau có thể được hợp nhất, nhưng sao chép một slide vào bản trình chiếu có kích thước slide khác sẽ không tự động thiết kế lại nội dung cho canvas mới. Do đó các shape có thể bị dịch, co giãn không mong muốn hoặc nằm ngoài vùng hiển thị.

Một cách thực tế là thay đổi kích thước bản trình chiếu nguồn trước khi sao chép. Phương thức [SlideSize.SetSize](https://reference.aspose.com/slides/vi/net/aspose.slides/slidesize/setsize/) có thể co giãn nội dung hiện có đồng thời thay đổi kích thước slide. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/vi/net/aspose.slides/slidesizescaletype/) co giãn nội dung sao cho vừa trong kích thước yêu cầu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

Thay đổi kích thước sẽ làm thay đổi đối tượng bản trình chiếu nguồn trong bộ nhớ. Nếu bạn cần giữ nguyên bản trình chiếu nguồn cho các thao tác khác, hãy mở một thể hiện riêng cho việc hợp nhất.

## **Hợp nhất slide vào một Section của bản trình chiếu**

Vòng lặp sao chép slide cơ bản không tái tạo cấu trúc section của bản trình chiếu nguồn. Nếu section quan trọng trong đầu ra, hãy tạo hoặc chọn các section trong bản trình chiếu đích và sao chép slide vào chúng một cách rõ ràng bằng [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

Các slide đã sao chép sẽ được thêm vào section đích đã chỉ định. Để giữ lại nhiều section nguồn, duyệt [Presentation.Sections](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/sections/), lấy danh sách slide hiện tại của mỗi section nguồn bằng [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/vi/net/aspose.slides/isection/getslideslistofsection/), tạo lại các section trong bản đích và sao chép từng slide vào section tương ứng. Xem [Quản lý Section Slide](/slides/vi/net/slide-section/) để có ví dụ đầy đủ về duyệt section, bao gồm các section trống và thay đổi cấu trúc.

## **Hợp nhất nhiều bản trình chiếu một cách an toàn**

Ví dụ đầu‑cuối dưới đây dùng bản trình chiếu đầu tiên làm đích, chuẩn hoá kích thước slide của mỗi nguồn bổ sung, giữ mỗi nguồn mở chỉ trong thời gian sao chép và lưu tệp cuối cùng một lần.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

Đây là một nền tảng hữu ích để giữ định dạng nguồn của các slide được nhập. Nếu đầu ra của bạn phải sử dụng một theme duy nhất, hãy thay thế lời gọi đơn giản `AddClone(slide)` bằng overload master hoặc layout đích thích hợp đã trình bày ở trên.

## **Cân nhắc thực tiễn**

### **Master, Layout và độ trung thực định dạng**

Việc sao chép slide mặc định có thể tự động đưa master nguồn cần thiết vào bản trình chiếu đích. Aspose.Slides duy trì một bộ đăng ký nội bộ cho các master được sao chép tự động nhằm tránh việc sao chép lại cùng một master nhiều lần. Các master được sao chép thủ công không được theo dõi bởi bộ đăng ký này, vì vậy tránh sao chép trước các master trừ khi bạn cần kiểm soát cấu trúc master một cách rõ ràng.

Đừng cho rằng hai master hoặc layout có cùng tên sẽ trực quan giống nhau. Nếu một mẫu công ty phải kiểm soát giao diện cuối cùng, hãy chọn một master hoặc layout đích một cách rõ ràng và xác nhận kết quả sau khi hợp nhất.

### **Ghi chú và bình luận**

Ghi chú người thuyết trình và bình luận slide được gắn với nội dung slide và sẽ được sao chép khi một slide được sao chép. Aspose.Slides cũng cung cấp API riêng cho [ghi chú bản trình chiếu](/slides/vi/net/presentation-notes/) và [bình luận bản trình chiếu](/slides/vi/net/presentation-comments/).

Nếu định dạng trang ghi chú quan trọng, hãy kiểm tra bản trình chiếu đã hợp nhất vì master ghi chú là đối tượng ở cấp độ bản trình chiếu và có thể khác nhau giữa các tệp nguồn. Đối với quy trình đánh giá, cũng hãy xác thực tác giả bình luận và các chuỗi bình luận sau khi kết hợp các tệp từ các tác giả hoặc mẫu khác nhau.

### **Hình ảnh, âm thanh, video, đối tượng OLE và liên kết ngoài**

Slide có thể tham chiếu đến các tài nguyên ở cấp độ bản trình chiếu như hình ảnh, âm thanh nhúng, video nhúng và dữ liệu OLE. Hãy sao chép toàn bộ slide thay vì chỉ sao chép các shape hiển thị để Aspose.Slides giữ được các mối quan hệ của slide với tài nguyên.

Các tài nguyên nhúng và liên kết cần được xử lý khác nhau. Một audio, video, đối tượng OLE hoặc hyperlink được liên kết vẫn phụ thuộc vào mục tiêu bên ngoài; sao chép slide không biến một liên kết ngoài thành nội dung nhúng. Hãy kiểm tra đường dẫn và URL của tài nguyên liên kết trong môi trường nơi bản trình chiếu hợp nhất sẽ được mở.

Aspose.Slides theo dõi các master được sao chép tự động, nhưng điều này không đồng nghĩa với việc các tài nguyên nhị phân giống nhau từ các bản trình chiếu không liên quan sẽ luôn được loại bỏ trùng lặp. Nếu kích thước tệp đầu ra quan trọng, hãy kiểm tra gói đã hợp nhất và đo kích thước kết quả thay vì dựa vào việc loại bỏ trùng lặp ngầm.

### **Phông chữ nhúng và khả dụng phông chữ**

Phông chữ được quản lý ở cấp độ bản trình chiếu. Nếu kiểu chữ phải đồng nhất trên các máy, đừng cho rằng việc sao chép slide đơn độc sẽ đảm bảo mọi phông chữ cần thiết có sẵn trong môi trường đích. Bạn có thể kiểm tra phông chữ nhúng bằng [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/getembeddedfonts/) và quản lý việc nhúng một cách rõ ràng như mô tả trong [Nhúng phông chữ trong bản trình chiếu](/slides/vi/net/embedded-font/).

Cũng hãy xác nhận rằng bạn được phép nhúng các phông chữ được sử dụng trong các tệp nguồn. Giấy phép phông chữ có thể hạn chế việc nhúng.

### **Bản trình chiếu được bảo vệ bằng mật khẩu**

Một nguồn được bảo vệ bằng mật khẩu phải được mở thành công trước khi các slide của nó có thể được sao chép. Cung cấp mật khẩu qua [LoadOptions.Password](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/password/).

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

Mở một nguồn đã mã hoá không tự động áp dụng cùng một bảo vệ cho bản trình chiếu đích. Hãy cấu hình bảo vệ đầu ra riêng khi cần.

### **Bản trình chiếu lớn và sử dụng bộ nhớ**

Các bản trình chiếu lớn chứa hình ảnh độ phân giải cao, âm thanh, video hoặc các đối tượng nhị phân lớn khác có thể tiêu tốn đáng kể bộ nhớ. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/blobmanagementoptions/) cung cấp các tùy chọn kiểm soát việc xử lý BLOB và sử dụng tệp tạm thời. Xem [Quản lý BLOB bản trình chiếu](/slides/vi/net/manage-blob/) để biết chiến lược cho tệp lớn.

Đối với tệp lớn, ưu tiên tải từ đường dẫn tệp khi có thể, giải phóng mỗi bản trình chiếu nguồn ngay khi đã được hợp nhất, và tránh lưu kết quả trung gian liên tục trừ khi quy trình yêu cầu checkpoint.

### **An toàn đa luồng**

Không tải, sửa đổi, lưu hoặc sao chép cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) đồng thời từ nhiều luồng. Giữ mỗi thể hiện bản trình chiếu trong một thao tác hợp nhất duy nhất. Nếu bạn song song hoá các công việc độc lập, hãy sử dụng các thể hiện bản trình chiếu độc lập và tuân thủ [hướng dẫn đa luồng của Aspose.Slides](/slides/vi/net/multithreading/).

## **Câu hỏi thường gặp**

**Làm sao để giữ nguyên thiết kế gốc của mỗi bản trình chiếu nguồn?**

Sử dụng [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/) mà không cung cấp master hoặc layout đích. Aspose.Slides có thể tự động sao chép master nguồn khi slide nhập vào cần đến.

**Làm sao để các slide nhập vào sử dụng theme của đích?**

Sử dụng overload chấp nhận một master đích. Cung cấp một master từ bản trình chiếu đích, không phải từ nguồn. Aspose.Slides sẽ cố gắng ánh xạ mỗi slide nguồn tới một layout thích hợp dưới master đó.

**Khi nào nên sử dụng layout đích cụ thể thay vì master đích?**

Sử dụng layout cụ thể khi mọi slide nhập vào phải dùng cùng một layout đã biết. Sử dụng master khi bạn muốn Aspose.Slides lựa chọn parmi các layout của master dựa trên kiểu hoặc tên layout nguồn.

**Có thể hợp nhất các bản trình chiếu có kích thước slide khác nhau không?**

Có, nhưng nội dung slide không được tự động thiết kế lại cho kích thước đích. Hãy thay đổi kích thước bản trình chiếu nguồn trước khi cần vị trí dự đoán, ví dụ bằng [SlideSize.SetSize](https://reference.aspose.com/slides/vi/net/aspose.slides/slidesize/setsize/) và [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/vi/net/aspose.slides/slidesizescaletype/).

**Có thể hợp nhất PPT, PPTX và ODP trong một tệp không?**

Có. Tải mỗi bản trình chiếu nguồn, sao chép các slide cần thiết vào một bản đích, và lưu bản đích ở định dạng đầu ra hỗ trợ. Vì các định dạng không hỗ trợ cùng một tập hợp tính năng, hãy kiểm tra nội dung phức tạp sau khi hợp nhất đa định dạng. Xem [Các định dạng tệp được hỗ trợ](/slides/vi/net/supported-file-formats/).

**Các section nguồn có được tự động bảo tồn không?**

Không, nếu chỉ dùng vòng lặp sao chép slide cơ bản. Hãy tái tạo các section cần thiết trong bản đích và sử dụng overload section của [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/) khi cấu trúc section phải được bảo lưu.

**Ghi chú và bình luận có được bảo lưu không?**

Chúng được sao chép cùng với slide đã sao chép. Đối với quy trình phụ thuộc vào kiểu master ghi chú, tác giả bình luận hoặc dữ liệu xem xét chuỗi, hãy xác thực kết quả đã hợp nhất vì những trường hợp này liên quan đến cấu trúc cấp độ bản trình chiếu cũng như nội dung slide.

**Điều gì xảy ra với âm thanh, video, đối tượng OLE và hyperlink?**

Nội dung nhúng sẽ được mang theo như một phần của các mối quan hệ tài nguyên của slide đã sao chép. Các liên kết ngoài vẫn ở ngoài, vì vậy các tệp hoặc URL mục tiêu vẫn phải khả dụng sau khi hợp nhất.

**Các phông chữ nhúng từ mọi nguồn có được đảm bảo có trong bản trình chiếu đã hợp nhất không?**

Đừng dựa vào việc sao chép slide một mình để triển khai phông chữ. Kiểm tra phông chữ nhúng của bản đích và quản lý việc nhúng phông chữ hoặc khả năng truy cập phông chữ bên ngoài một cách rõ ràng khi kiểu chữ quan trọng.

**Làm sao để hợp nhất tệp được bảo vệ bằng mật khẩu?**

Mở nó bằng [LoadOptions.Password](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/password/) thích hợp, sau đó sao chép các slide như bình thường. Bảo vệ đầu ra được cấu hình riêng.

**Làm sao để xử lý các bản trình chiếu rất lớn?**

Sử dụng quản lý BLOB khi các đối tượng nhị phân lớn chiếm phần lớn bộ nhớ, ưu tiên tải từ đường dẫn tệp cho các tệp rất lớn, giải phóng các bản trình chiếu nguồn kịp thời và chỉ lưu kết quả cuối cùng khi cần.

**Có thể hợp nhất slide từ nhiều luồng không?**

Không sử dụng cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) đồng thời từ nhiều luồng. Giữ mỗi thao tác hợp nhất độc lập trong các thể hiện riêng.