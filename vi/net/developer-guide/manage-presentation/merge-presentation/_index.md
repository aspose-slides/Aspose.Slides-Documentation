---
title: "Kết hợp các bản trình chiếu hiệu quả trong .NET"
linktitle: "Kết hợp các bản trình chiếu"
type: docs
weight: 40
url: /vi/net/merge-presentation/
keywords:
- "kết hợp PowerPoint"
- "kết hợp bản trình chiếu"
- "kết hợp slide"
- "kết hợp PPT"
- "kết hợp PPTX"
- "kết hợp ODP"
- "gộp PowerPoint"
- "gộp bản trình chiếu"
- "gộp slide"
- "gộp PPT"
- "gộp PPTX"
- "gộp ODP"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Tìm hiểu cách kết hợp các bản trình chiếu PowerPoint và OpenDocument trong .NET bằng cách sao chép slide, kiểm soát master và layout, thay đổi kích thước nội dung slide, giữ lại các section, và xử lý các tệp được bảo vệ hoặc lớn."
---
## **Tổng quan**

Aspose.Slides for .NET hợp nhất các bản trình chiếu bằng cách sao chép slide từ một [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) sang bản khác. Hoạt động chính là [ISlideCollection.AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/), có thể giữ nguyên định dạng của slide nguồn hoặc gắn slide đã sao chép vào một master hoặc layout trong bản trình chiếu đích.

Bài viết này bao gồm các quy trình hợp nhất phổ biến nhất:

- hợp nhất tất cả các slide đồng thời giữ định dạng nguồn;
- hợp nhất các slide đã chọn;
- áp dụng master từ bản trình chiếu đích;
- áp dụng layout cụ thể từ bản trình chiếu đích;
- chuẩn hoá kích thước slide khác nhau trước khi hợp nhất;
- thêm các slide đã sao chép vào một section;
- hợp nhất nhiều bản trình chiếu trong một quy trình đầu‑cuối;
- xử lý master, tài nguyên, ghi chú, bình luận, media, phông chữ, mật khẩu, tệp lớn và các vấn đề đa luồng.

## **Cách sao chép Slide ảnh hưởng đến Master và Layout**

Slide thừa hưởng phần lớn giao diện từ layout và master của nó. Vì vậy, overload sao chép bạn chọn sẽ quyết định cách slide đã hợp nhất được tích hợp vào bản trình chiếu đích.

Sử dụng [ISlideCollection.AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/) theo một trong các cách sau:

- `AddClone(sourceSlide)` — giữ nguyên layout và định dạng của slide nguồn. Khi cần, master nguồn có thể được sao chép tự động vào bản trình chiếu đích. Aspose.Slides tự động theo dõi các master đã sao chép để các slide lặp lại sử dụng cùng một master không gây sao chép lại master đó.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — gắn slide đã sao chép vào một [IMasterSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslide/) đích cụ thể. Aspose.Slides sẽ tìm layout phù hợp dưới master đó dựa trên loại hoặc tên layout.
- `AddClone(sourceSlide, destinationLayout)` — gắn slide đã sao chép trực tiếp vào một [ILayoutSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/) đích cụ thể.

Master hoặc layout được truyền vào overload `AddClone` phải thuộc về **bản trình chiếu đích**, không phải bản trình chiếu nguồn.

## **Hợp nhất Toàn bộ Bản Trình Chiếu và Giữ Định dạng Nguồn**

Cách hợp nhất đơn giản nhất là sao chép mọi slide từ bản trình chiếu nguồn sang bản trình chiếu đích. Đây là lựa chọn thích hợp khi các slide được nhập phải giữ nguyên giao diện, master và mối quan hệ layout gốc.

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

Kết quả có thể chứa nhiều master khi nguồn và đích sử dụng các thiết kế khác nhau. Điều này là bình thường khi định dạng nguồn được cố ý giữ lại.

## **Hợp nhất Các Slide Đã Chọn**

Bạn không cần sao chép mọi slide. Ví dụ dưới đây chỉ nhập các chỉ mục slide đã chọn từ bản trình chiếu nguồn.

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

Kiểm tra chỉ mục slide trước khi sao chép khi chúng được lấy từ đầu vào người dùng hoặc cấu hình bên ngoài.

## **Hợp nhất Slide bằng Master Đích**

Sử dụng overload [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/) khi các slide được nhập cần tuân theo một master đã thuộc về bản trình chiếu đích.

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

Aspose.Slides sẽ chọn một layout phù hợp dưới master đã chỉ định bằng cách khớp loại hoặc tên layout nguồn. Nếu không tìm thấy layout phù hợp và `allowCloneMissingLayout` là `true`, layout nguồn sẽ được sao chép để slide có thể được thêm. Nếu `false`, một [PptxEditException](https://reference.aspose.com/slides/vi/net/aspose.slides/pptxeditexception/) sẽ được ném ra.

Dùng `false` khi bạn muốn quá trình hợp nhất thất bại thay vì tạo thêm một layout vào master đích.

## **Hợp nhất Slide bằng Layout Đích Cụ Thể**

Sử dụng overload [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/) khi bạn biết chính xác layout đích mà các slide được nhập sẽ sử dụng.

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

Áp dụng layout đích thay đổi mối quan hệ layout kế thừa; nó không thay đổi nội dung slide nguồn. Nếu layout nguồn và đích có cấu trúc placeholder khác nhau, hãy kiểm tra kết quả để xác nhận định dạng kế thừa và hành vi placeholder là phù hợp.

## **Hợp nhất Bản Trình Chiếu có Kích Thước Slide Khác Nhau**

Các bản trình chiếu có kích thước slide khác nhau có thể được hợp nhất, nhưng sao chép một slide vào bản trình chiếu có kích thước khác không tự động điều chỉnh nội dung cho canvas mới. Các shape có thể bị dịch chuyển, co giãn không mong muốn hoặc nằm ngoài vùng hiển thị.

Một cách thực tế là thay đổi kích thước bản trình chiếu nguồn trước khi sao chép. Phương thức [SlideSize.SetSize](https://reference.aspose.com/slides/vi/net/aspose.slides/slidesize/setsize/) có thể co giãn nội dung hiện có trong khi thay đổi kích thước slide. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/vi/net/aspose.slides/slidesizescaletype/) co giãn nội dung để vừa với kích thước yêu cầu.

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

Việc thay đổi kích thước sẽ sửa đổi đối tượng bản trình chiếu nguồn trong bộ nhớ. Nếu bạn cần giữ bản trình chiếu nguồn nguyên trạng cho các thao tác khác, hãy mở một thể hiện riêng cho quá trình hợp nhất.

## **Hợp nhất Slide vào Section của Bản Trình Chiếu**

Vòng lặp sao chép slide cơ bản không tái tạo lại cấu trúc section của bản trình chiếu nguồn. Nếu section quan trọng trong kết quả, hãy tạo hoặc chọn các section trong bản trình chiếu đích và sao chép slide vào chúng một cách rõ ràng bằng [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/).

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

Các slide đã sao chép sẽ được đính vào section đích đã chỉ định. Để giữ lại nhiều section nguồn, hãy tái tạo các section đó trong bản trình chiếu đích và ánh xạ mỗi slide nguồn tới section đích tương ứng.

## **Hợp nhất Nhiều Bản Trình Chiếu Một Cách An Toàn**

Ví dụ cuối‑cuối dưới đây sử dụng bản trình chiếu đầu tiên làm đích, chuẩn hoá kích thước slide của từng nguồn bổ sung, giữ mỗi nguồn mở chỉ trong lúc sao chép và lưu file cuối cùng một lần duy nhất.

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

Đây là một nền tảng hữu ích để giữ định dạng nguồn của các slide được nhập. Nếu đầu ra của bạn phải sử dụng một theme duy nhất, hãy thay thế lời gọi đơn giản `AddClone(slide)` bằng overload master hoặc layout đích phù hợp đã trình bày ở trên.

## **Cân Nhắc Thực Tế**

### **Master, Layout và Độ Chính Xác Định Dạng**

Việc sao chép slide mặc định có thể tự động đưa master nguồn cần thiết vào bản trình chiếu đích. Aspose.Slides duy trì một registry nội bộ cho các master được sao chép tự động để tránh sao chép lại cùng một master. Các master được sao chép thủ công không được theo dõi bởi registry này, vì vậy tránh sao chép trước các master trừ khi bạn cần kiểm soát cấu trúc master một cách tường minh.

Đừng cho rằng hai master hoặc layout cùng tên sẽ hiển thị giống nhau. Nếu một mẫu công ty phải kiểm soát giao diện cuối cùng, hãy chọn master hoặc layout đích một cách rõ ràng và xác thực kết quả sau khi hợp nhất.

### **Ghi chú và Bình luận**

Speaker notes và comment của slide được liên kết với nội dung slide và sẽ được sao chép khi slide được sao chép. Aspose.Slides cũng cung cấp các API chuyên biệt cho [presentation notes](https://docs.aspose.com/slides/vi/net/presentation-notes/) và [presentation comments](https://docs.aspose.com/slides/vi/net/presentation-comments/).

Nếu định dạng trang notes quan trọng, hãy xác nhận bản trình chiếu đã hợp nhất vì notes master là đối tượng cấp trình chiếu và có thể khác nhau giữa các tệp nguồn. Đối với quy trình xem xét, cũng cần kiểm tra tác giả comment và các comment chuỗi sau khi kết hợp các tệp từ các tác giả hoặc mẫu khác nhau.

### **Hình ảnh, Âm thanh, Video, Đối tượng OLE và Liên kết Ngoài**

Slide có thể tham chiếu tới các tài nguyên cấp trình chiếu như hình ảnh, âm thanh nhúng, video nhúng và dữ liệu OLE. Hãy sao chép toàn bộ slide thay vì chỉ sao chép các shape hiển thị để Aspose.Slides có thể duy trì mối quan hệ của slide với các tài nguyên đó.

Tài nguyên được nhúng và tài nguyên được liên kết cần được xử lý khác nhau. Một audio, video, OLE object hoặc hyperlink được liên kết vẫn phụ thuộc vào mục tiêu bên ngoài; sao chép slide không biến một liên kết ngoài thành nội dung nhúng. Hãy kiểm tra đường dẫn và URL của tài nguyên liên kết trong môi trường nơi bản trình chiếu hợp nhất sẽ được mở.

Aspose.Slides theo dõi các master được sao chép tự động, nhưng điều này không đồng nghĩa với việc các tài nguyên nhị phân giống hệt từ các bản trình chiếu nguồn không liên quan sẽ luôn được loại bỏ trùng lặp. Nếu kích thước file đầu ra quan trọng, hãy kiểm tra gói đã hợp nhất và đo kích thước kết quả thay vì dựa vào việc loại bỏ trùng lặp ngầm.

### **Phông chữ Nhúng và Tính Sẵn Có của Phông chữ**

Phông chữ được quản lý ở mức trình chiếu. Nếu cần duy trì kiểu chữ nhất quán trên các máy, đừng cho rằng chỉ sao chép slide sẽ đảm bảo mọi phông chữ cần thiết đã có sẵn trong môi trường đích. Bạn có thể kiểm tra phông chữ nhúng bằng [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/getembeddedfonts/) và quản lý việc nhúng một cách rõ ràng như mô tả trong [Embed Fonts in Presentations](https://docs.aspose.com/slides/vi/net/embedded-font/).

Cũng cần xác nhận bạn được phép nhúng các phông chữ được sử dụng trong các tệp nguồn. Giấy phép phông chữ có thể hạn chế việc nhúng.

### **Bản Trình Chiếu Bảo Vệ Mật Khẩu**

Một nguồn được bảo vệ mật khẩu phải được mở thành công trước khi các slide của nó có thể được sao chép. Cung cấp mật khẩu qua [LoadOptions.Password](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/password/).

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

Mở một nguồn đã mã hoá không tự động áp dụng cùng một bảo vệ cho bản trình chiếu đích. Hãy cấu hình bảo vệ đầu ra riêng biệt khi cần.

### **Bản Trình Chiếu Lớn và Sử Dụng Bộ Nhớ**

Các bản trình chiếu lớn chứa hình ảnh độ phân giải cao, âm thanh, video hoặc các đối tượng nhị phân lớn khác có thể tiêu tốn đáng kể bộ nhớ. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/blobmanagementoptions/) cung cấp các tùy chọn kiểm soát việc xử lý BLOB và sử dụng tệp tạm. Xem [Manage Presentation BLOBs](https://docs.aspose.com/slides/vi/net/manage-blob/) để biết chiến lược cho tệp lớn.

Đối với tệp lớn, ưu tiên tải từ đường dẫn tệp khi có thể, giải phóng mỗi bản trình chiếu nguồn ngay sau khi đã hợp nhất, và tránh lưu kết quả trung gian liên tục trừ khi quy trình yêu cầu checkpoint.

### **An Toàn Đa Luồng**

Không tải, sửa đổi, lưu hoặc sao chép cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) đồng thời từ nhiều luồng. Giữ mỗi thể hiện bản trình chiếu trong một thao tác hợp nhất duy nhất. Nếu bạn thực hiện các công việc độc lập song song, hãy dùng các thể hiện bản trình chiếu độc lập và tuân theo [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/vi/net/multithreading/).

## **FAQ**

**Làm thế nào để giữ nguyên thiết kế gốc của mỗi bản trình chiếu nguồn?**

Sử dụng [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/) mà không cung cấp master hay layout đích. Aspose.Slides có thể tự động sao chép master nguồn khi slide nhập cần tới nó.

**Làm sao để các slide được nhập sử dụng theme của bản trình chiếu đích?**

Sử dụng overload chấp nhận master đích. Truyền vào một master từ bản trình chiếu đích, không phải từ nguồn. Aspose.Slides sẽ cố gắng ánh xạ mỗi slide nguồn tới một layout phù hợp dưới master đó.

**Khi nào nên dùng layout đích cụ thể thay vì master đích?**

Dùng layout cụ thể khi mọi slide nhập đều phải sử dụng một layout đã biết. Dùng master khi bạn muốn Aspose.Slides tự chọn layout trong master đó dựa trên loại hoặc tên layout nguồn.

**Có thể hợp nhất các bản trình chiếu có kích thước slide khác nhau không?**

Có, nhưng nội dung slide sẽ không được tự động thiết kế lại cho kích thước đích. Hãy thay đổi kích thước bản trình chiếu nguồn trước khi sao chép, ví dụ bằng [SlideSize.SetSize](https://reference.aspose.com/slides/vi/net/aspose.slides/slidesize/setsize/) và [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/vi/net/aspose.slides/slidesizescaletype/).

**Có thể hợp nhất các tệp PPT, PPTX và ODP thành một file không?**

Có. Tải mỗi bản trình chiếu nguồn, sao chép các slide cần thiết vào một bản đích, và lưu bản đích ở định dạng đầu ra được hỗ trợ. Vì các định dạng không hỗ trợ đầy đủ các tính năng giống nhau, hãy xác nhận nội dung phức tạp sau khi hợp nhất đa định dạng. Xem [Supported File Formats](https://docs.aspose.com/slides/vi/net/supported-file-formats/).

**Các section nguồn có được tự động giữ lại không?**

Không, nếu chỉ dùng vòng lặp cơ bản sao chép slide. Hãy tái tạo các section cần thiết trong bản trình chiếu đích và sử dụng overload section của [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/) khi cấu trúc section phải được bảo toàn.

**Ghi chú và bình luận có được giữ lại không?**

Chúng được sao chép cùng với slide đã sao chép. Đối với quy trình phụ thuộc vào kiểu dáng notes‑master, tác giả comment hoặc dữ liệu review chuỗi, hãy kiểm tra kết quả hợp nhất vì các trường hợp này liên quan đến cấu trúc cấp trình chiếu cũng như nội dung slide.

**Điều gì xảy ra với audio, video, OLE object và hyperlink?**

Nội dung được nhúng sẽ được đưa vào cùng với các mối quan hệ tài nguyên của slide đã sao chép. Các liên kết ngoài vẫn giữ nguyên tính bên ngoài, vì vậy các tệp hoặc URL mục tiêu vẫn phải tồn tại sau khi hợp nhất.

**Các phông chữ nhúng từ mỗi nguồn có được đảm bảo có trong bản trình chiếu hợp nhất không?**

Không nên chỉ dựa vào sao chép slide để triển khai phông chữ. Kiểm tra phông chữ nhúng trong bản đích và quản lý việc nhúng phông chữ hoặc tính sẵn có của phông chữ bên ngoài một cách rõ ràng khi kiểu chữ quan trọng.

**Làm sao hợp nhất một tệp được bảo vệ mật khẩu?**

Mở tệp với [LoadOptions.Password](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/password/) đúng, sau đó sao chép các slide như bình thường. Bảo vệ đầu ra được cấu hình riêng.

**Làm thế nào xử lý các bản trình chiếu rất lớn?**

Sử dụng quản lý BLOB khi các đối tượng nhị phân lớn chiếm phần lớn bộ nhớ, ưu tiên tải từ đường dẫn tệp cho các tệp rất lớn, giải phóng nhanh các bản trình chiếu nguồn và chỉ lưu kết quả cuối cùng khi cần.

**Có thể sao chép slide từ nhiều luồng không?**

Không sử dụng cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) đồng thời từ nhiều luồng. Giữ mỗi thao tác hợp nhất trong một thể hiện riêng.