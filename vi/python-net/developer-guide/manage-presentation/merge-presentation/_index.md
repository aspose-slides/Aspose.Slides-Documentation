---
title: Hiệu quả hợp nhất các bản trình chiếu bằng Python
linktitle: Hợp nhất các bản trình chiếu
type: docs
weight: 40
url: /vi/python-net/merge-presentation/
keywords:
- hợp nhất PowerPoint
- hợp nhất bản trình chiếu
- hợp nhất slide
- hợp nhất PPT
- hợp nhất PPTX
- hợp nhất ODP
- kết hợp PowerPoint
- kết hợp bản trình chiếu
- kết hợp slide
- kết hợp PPT
- kết hợp PPTX
- kết hợp ODP
- Python
- Aspose.Slides
description: "Tìm hiểu cách hợp nhất các bản trình chiếu PowerPoint và OpenDocument trong Python bằng cách sao chép slide, kiểm soát master và layout, thay đổi kích thước nội dung slide, giữ nguyên các phần, và xử lý các tệp được bảo vệ hoặc lớn."
---
## **Tổng quan**

Aspose.Slides for Python via .NET hợp nhất các bản trình chiếu bằng cách sao chép các slide từ một [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) sang bản khác. Hoạt động chính là [SlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/), có thể giữ nguyên định dạng của slide nguồn hoặc gắn slide sao chép vào master hoặc layout trong bản trình chiếu đích.

Bài viết này bao phủ các quy trình hợp nhất phổ biến nhất:

- hợp nhất tất cả các slide đồng thời giữ nguyên định dạng nguồn;
- hợp nhất các slide đã chọn;
- đặt master từ bản trình chiếu đích;
- đặt một layout cụ thể từ bản trình chiếu đích;
- chuẩn hoá các kích thước slide khác nhau trước khi hợp nhất;
- thêm các slide sao chép vào một phần;
- hợp nhất nhiều bản trình chiếu trong một quy trình đầu cuối;
- xử lý master, tài nguyên, ghi chú, bình luận, phương tiện, font, mật khẩu, tệp lớn và các vấn đề đa luồng.

## **Cách sao chép Slide ảnh hưởng đến Master và Layout**

Một slide kế thừa phần lớn giao diện từ layout và master của nó. Vì vậy, overload sao chép mà bạn chọn quyết định cách slide hợp nhất được tích hợp vào bản trình chiếu đích.

Sử dụng [SlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/) theo một trong các cách sau:

- `add_clone(source_slide)` — giữ nguyên layout và định dạng của slide nguồn. Khi cần, master nguồn có thể được sao chép vào bản trình chiếu đích một cách tự động. Aspose.Slides tự động theo dõi các master đã sao chép để các slide lặp lại sử dụng cùng một master nguồn không bị sao chép lần nữa.
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — gắn slide sao chép vào một [IMasterSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imasterslide/) đích cụ thể. Aspose.Slides sẽ tìm layout phù hợp dưới master đó theo kiểu hoặc tên layout.
- `add_clone(source_slide, destination_layout)` — gắn slide sao chép trực tiếp vào một [ILayoutSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ilayoutslide/) đích cụ thể.

Master hoặc layout được truyền vào overload `add_clone` phải thuộc về bản trình chiếu **đích**, không phải bản trình chiếu nguồn.

## **Hợp nhất Toàn bộ Bản Trình Chiếu và Giữ Nguyên Định Dạng Nguồn**

Cách hợp nhất đơn giản nhất là sao chép mọi slide từ bản trình chiếu nguồn sang bản trình chiếu đích. Đây là lựa chọn thích hợp khi các slide nhập vào cần giữ nguyên theme, master và mối quan hệ layout ban đầu.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả có thể chứa nhiều master khi bản nguồn và bản đích sử dụng các thiết kế khác nhau. Điều này là bình thường khi định dạng nguồn được giữ cố ý.

## **Hợp nhất Các Slide Được Chọn**

Bạn không cần sao chép mọi slide. Ví dụ sau chỉ nhập các chỉ số slide đã chọn từ bản trình chiếu nguồn.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

Hãy xác thực chỉ số slide trước khi sao chép khi chúng đến từ đầu vào người dùng hoặc cấu hình bên ngoài.

## **Hợp nhất Slide Sử Dụng Master Đích**

Sử dụng overload [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/) khi các slide nhập vào cần tuân theo một master đã thuộc về bản trình chiếu đích.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides chọn layout phù hợp dưới master đã chỉ định bằng cách khớp kiểu hoặc tên layout nguồn. Nếu không có layout phù hợp và `allow_clone_missing_layout` là `True`, layout nguồn sẽ được sao chép để slide có thể được thêm. Nếu là `False`, một [PptxEditException](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pptxeditexception/) sẽ được ném ra.

Sử dụng `False` khi bạn muốn quá trình hợp nhất thất bại thay vì tạo thêm một layout vào master đích.

## **Hợp nhất Slide Sử Dụng Layout Đích Cụ Thể**

Sử dụng overload [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/) khi bạn biết chính xác layout đích mà các slide nhập vào phải sử dụng.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

Áp dụng layout đích chỉ thay đổi mối quan hệ layout kế thừa; nó không thiết kế lại nội dung slide nguồn. Nếu layout nguồn và layout đích có cấu trúc placeholder khác nhau, hãy kiểm tra kết quả để xác nhận định dạng kế thừa và hành vi placeholder là phù hợp.

## **Hợp nhất Bản Trình Chiếu Với Các Kích Thước Slide Khác Nhau**

Các bản trình chiếu có kích thước slide khác nhau có thể được hợp nhất, nhưng sao chép slide vào bản có kích thước slide khác không tự động thiết kế lại nội dung cho canvas mới. Vì vậy các hình có thể bị dịch, co giãn không mong muốn hoặc nằm ngoài vùng hiển thị.

Một cách thực tiễn là thay đổi kích thước bản trình chiếu nguồn trước khi sao chép. Phương thức [SlideSize.set_size](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidesize/set_size/) có thể thu phóng nội dung hiện có đồng thời thay đổi kích thước slide. [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidesizescaletype/) thu phóng nội dung để vừa với kích thước yêu cầu.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        if (
            source.slide_size.size.width != destination.slide_size.size.width
            or source.slide_size.size.height != destination.slide_size.size.height
        ):
            source.slide_size.set_size(
                destination.slide_size.size.width,
                destination.slide_size.size.height,
                slides.SlideSizeScaleType.ENSURE_FIT)

        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged-same-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

Thay đổi kích thước sẽ làm thay đổi đối tượng bản trình chiếu nguồn trong bộ nhớ. Nếu bạn cần giữ bản nguồn nguyên vẹn cho các thao tác khác, hãy mở một thể hiện riêng cho quá trình hợp nhất.

## **Hợp nhất Slide Vào Một Phần Của Bản Trình Chiếu**

Vòng lặp sao chép slide cơ bản không tái tạo cấu trúc phần (section) của bản nguồn. Nếu phần quan trọng trong kết quả, hãy tạo hoặc chọn các phần trong bản đích và sao chép slide vào chúng một cách rõ ràng bằng [SlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/).

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

Các slide đã sao chép sẽ được nối vào phần đích đã chỉ định. Để giữ lại nhiều phần nguồn, hãy tạo lại các phần đó trong bản đích bằng [SectionCollection.append_empty_section](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sectioncollection/append_empty_section/) và ánh xạ mỗi slide nguồn tới phần đích tương ứng.

## **Hợp Nhất Nhiều Bản Trình Chiếu Một Cách An Toàn**

Ví dụ đầu‑cuối dưới đây sử dụng bản trình chiếu đầu tiên làm đích, chuẩn hoá kích thước slide của mỗi nguồn bổ sung, giữ mỗi nguồn mở chỉ trong thời gian sao chép và lưu tệp cuối cùng một lần.

```python
import aspose.slides as slides

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

with slides.Presentation(input_files[0]) as merged:
    for file_index in range(1, len(input_files)):
        with slides.Presentation(input_files[file_index]) as source:
            if (
                source.slide_size.size.width != merged.slide_size.size.width
                or source.slide_size.size.height != merged.slide_size.size.height
            ):
                source.slide_size.set_size(
                    merged.slide_size.size.width,
                    merged.slide_size.size.height,
                    slides.SlideSizeScaleType.ENSURE_FIT)

            for slide in source.slides:
                merged.slides.add_clone(slide)

    merged.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

Đây là một nền tảng hữu ích để giữ định dạng nguồn của các slide nhập vào. Nếu đầu ra của bạn phải sử dụng một theme đích duy nhất, thay thế lời gọi `add_clone(slide)` đơn giản bằng overload master hoặc layout đích phù hợp đã trình bày ở trên.

## **Xem Xét Thực Tiễn**

### **Master, Layout và Độ Tin Cậy Định Dạng**

Sao chép slide mặc định có thể tự động đưa master nguồn cần thiết vào bản trình chiếu đích. Aspose.Slides duy trì một registry nội bộ cho các master được sao chép tự động nhằm tránh sao chép lại cùng một master nhiều lần. Các master được sao chép thủ công không được registry này theo dõi, vì vậy tránh sao chép trước các master trừ khi bạn cần kiểm soát chi tiết cấu trúc master.

Đừng cho rằng hai master hoặc layout có cùng tên sẽ hiển thị giống nhau. Nếu mẫu công ty phải kiểm soát giao diện cuối cùng, hãy chọn một master hoặc layout đích một cách rõ ràng và xác thực kết quả sau khi hợp nhất.

### **Ghi Chú và Bình Luận**

Ghi chú người thuyết trình và bình luận slide gắn liền với nội dung slide và sẽ được sao chép khi slide được sao chép. Aspose.Slides cũng cung cấp các API chuyên dụng cho [presentation notes](https://docs.aspose.com/slides/vi/python-net/presentation-notes/) và [presentation comments](https://docs.aspose.com/slides/vi/python-net/presentation-comments/).

Nếu định dạng trang ghi chú quan trọng, hãy kiểm tra bản trình chiếu đã hợp nhất vì master ghi chú là đối tượng cấp trình chiếu và có thể khác nhau giữa các tệp nguồn. Đối với quy trình duyệt, cũng nên xác thực tác giả bình luận và các chuỗi bình luận sau khi kết hợp các tệp từ các tác giả hoặc mẫu khác nhau.

### **Hình Ảnh, Âm Thanh, Video, Đối Tượng OLE và Liên Kết Ngoại Tuyến**

Slide có thể tham chiếu tới các tài nguyên cấp trình chiếu như hình ảnh, âm thanh nhúng, video nhúng và dữ liệu OLE. Hãy sao chép toàn bộ slide thay vì chỉ sao chép các hình dạng hiển thị để Aspose.Slides có thể duy trì mối quan hệ của slide với các tài nguyên đó.

Các tài nguyên nhúng và liên kết nên được xử lý khác nhau. Một âm thanh, video, đối tượng OLE hoặc hyperlink được liên kết sẽ vẫn phụ thuộc vào mục tiêu bên ngoài; sao chép slide không biến một liên kết ngoài thành nội dung nhúng. Hãy kiểm tra đường dẫn và URL của tài nguyên liên kết trong môi trường mà bản trình chiếu hợp nhất sẽ được mở.

Aspose.Slides theo dõi rõ ràng các master được sao chép tự động, nhưng điều này không có nghĩa là mọi tài nguyên nhị phân giống nhau từ các bản nguồn không liên quan sẽ luôn được loại bỏ trùng lặp. Nếu kích thước tệp đầu ra quan trọng, hãy kiểm tra gói đã hợp nhất và đo lường kết quả thay vì dựa vào việc loại bỏ trùng lặp ngầm.

### **Font Nhúng và Khả Năng Sử Dụng Font**

Font được quản lý ở cấp độ trình chiếu. Nếu kiểu chữ phải đồng nhất trên các máy, đừng cho rằng việc sao chép slide chỉ đảm bảo mọi font cần thiết đã có trong môi trường đích. Bạn có thể kiểm tra các font nhúng bằng [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) và quản lý việc nhúng một cách rõ ràng như mô tả trong [Embed Fonts in Presentations](https://docs.aspose.com/slides/vi/python-net/embedded-font/).

Cũng hãy xác thực rằng bạn được phép nhúng các font được sử dụng trong các tệp nguồn. Giấy phép font có thể giới hạn việc nhúng.

### **Bản Trình Chiếu Được Bảo Vệ Bằng Mật Khẩu**

Một bản nguồn được bảo vệ bằng mật khẩu phải được mở thành công trước khi các slide của nó có thể được sao chép. Cung cấp mật khẩu qua [LoadOptions.password](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/password/).

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

Mở một nguồn được mã hoá không tự động áp dụng cùng một bảo vệ cho bản trình chiếu đích. Cấu hình bảo vệ đầu ra riêng khi cần.

### **Bản Trình Chiếu Lớn và Sử Dụng Bộ Nhớ**

Các bản trình chiếu lớn chứa hình ảnh độ phân giải cao, âm thanh, video hoặc các đối tượng nhị phân lớn khác có thể tiêu tốn đáng kể bộ nhớ. [LoadOptions.blob_management_options](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/blob_management_options/) cung cấp các tùy chọn kiểm soát việc xử lý BLOB và sử dụng tệp tạm. Xem [Manage Presentation BLOBs](https://docs.aspose.com/slides/vi/python-net/manage-blob/) để biết chiến lược cho tệp lớn.

Đối với tệp lớn, ưu tiên tải từ đường dẫn tệp khi có thể, đóng mỗi bản nguồn ngay khi đã hợp nhất và tránh lưu liên tục các kết quả trung gian trừ khi quy trình yêu cầu điểm checkpoint. Sử dụng `with slides.Presentation(...)` sẽ giải phóng tài nguyên trình chiếu khi kết thúc ngữ cảnh.

### **An Toàn Khi Đa Luồng**

Không tải, lưu hoặc sao chép một [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) đồng thời từ nhiều luồng. Giữ mỗi thao tác hợp nhất ở chế độ đơn luồng. Nếu bạn song song hoá các công việc hợp nhất độc lập, hãy dùng các tiến trình đơn luồng riêng biệt và các thể hiện trình chiếu độc lập như mô tả trong [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/vi/python-net/multithreading/).

## **Câu hỏi thường gặp**

**Làm sao giữ nguyên thiết kế gốc của mỗi bản trình chiếu nguồn?**

Sử dụng [`add_clone(source_slide)`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/) mà không cung cấp master hoặc layout đích. Aspose.Slides có thể tự động sao chép master nguồn khi slide nhập vào cần nó.

**Làm sao để các slide nhập vào sử dụng theme của bản đích?**

Sử dụng overload chấp nhận master đích. Cung cấp một master từ bản trình chiếu đích, không phải từ bản nguồn. Aspose.Slides sẽ cố gắng ánh xạ mỗi slide nguồn tới một layout phù hợp dưới master đó.

**Khi nào nên dùng layout đích cụ thể thay vì master đích?**

Dùng layout cụ thể khi mọi slide nhập vào phải sử dụng một layout đã biết. Dùng master khi bạn muốn Aspose.Slides tự chọn layout trong master dựa trên kiểu hoặc tên layout nguồn.

**Có thể hợp nhất các bản trình chiếu có kích thước slide khác nhau không?**

Có, nhưng nội dung slide sẽ không tự động được thiết kế lại cho kích thước đích. Hãy thay đổi kích thước bản nguồn trước khi sao chép, ví dụ bằng [SlideSize.set_size](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidesize/set_size/) và [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidesizescaletype/).

**Có thể hợp nhất PPT, PPTX và ODP thành một tệp không?**

Có. Tải mỗi bản nguồn, sao chép các slide cần thiết vào một bản đích, và lưu bản đích ở định dạng đầu ra hỗ trợ. Vì các định dạng trình chiếu không hỗ trợ đầy đủ cùng một bộ tính năng, hãy xác thực nội dung phức tạp sau khi hợp nhất đa định dạng. Xem [Supported File Formats](https://docs.aspose.com/slides/vi/python-net/supported-file-formats/).

**Các phần (section) của nguồn có được giữ tự động không?**

Không, nếu chỉ dùng vòng lặp sao chép slide cơ bản. Hãy tạo lại các phần cần thiết trong bản đích và sử dụng overload section của [add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/) khi cấu trúc phần phải được giữ.

**Ghi chú và bình luận có được giữ lại không?**

Chúng được sao chép cùng với slide đã sao chép. Đối với quy trình phụ thuộc vào style master ghi chú, tác giả bình luận hoặc chuỗi bình luận, hãy xác thực kết quả hợp nhất vì những trường hợp này liên quan đến cấu trúc cấp trình chiếu cũng như nội dung slide.

**Audio, video, đối tượng OLE và hyperlink sẽ xảy ra gì?**

Nội dung nhúng sẽ được mang cùng với các mối quan hệ tài nguyên của slide đã sao chép. Các liên kết ngoài vẫn giữ trạng thái ngoài, vì vậy các tệp hoặc URL mục tiêu phải vẫn khả dụng sau khi hợp nhất.

**Các font nhúng từ mọi nguồn có được đảm bảo có trong bản trình chiếu hợp nhất không?**

Không nên chỉ dựa vào sao chép slide để triển khai font. Kiểm tra các font nhúng của bản đích và quản lý việc nhúng hoặc khả năng sử dụng font bên ngoài một cách rõ ràng khi kiểu chữ quan trọng.

**Làm sao hợp nhất tệp được bảo vệ bằng mật khẩu?**

Mở tệp bằng [LoadOptions.password](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/password/), sau đó sao chép các slide như bình thường. Bảo vệ đầu ra được cấu hình riêng.

**Nên xử lý các bản trình chiếu rất lớn như thế nào?**

Sử dụng quản lý BLOB khi các đối tượng nhị phân lớn chiếm ưu thế bộ nhớ, ưu tiên tải từ đường dẫn tệp, đóng nhanh các bản nguồn sau khi sao chép và chỉ lưu kết quả cuối cùng khi cần. `with slides.Presentation(...)` giúp giải phóng tài nguyên khi thoát ngữ cảnh.

**Có thể sao chép slide từ nhiều luồng không?**

Không tải, lưu hoặc sao chép [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) trong nhiều luồng đồng thời. Giữ mỗi thao tác hợp nhất ở chế độ đơn luồng; nếu cần chạy song song các công việc hợp nhất độc lập, hãy dùng các tiến trình đơn luồng riêng biệt và các thể hiện trình chiếu độc lập.