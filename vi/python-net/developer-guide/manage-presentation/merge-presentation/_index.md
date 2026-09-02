---
title: Hiệu quả hợp nhất các bản trình bày với Python
linktitle: Hợp nhất các bản trình bày
type: docs
weight: 40
url: /vi/python-net/merge-presentation/
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
- Python
- Aspose.Slides
description: "Tìm hiểu cách hợp nhất các bản trình bày PowerPoint và OpenDocument trong Python bằng cách sao chép slide, kiểm soát master và layout, thay đổi kích thước nội dung slide, bảo tồn các section, và xử lý các tệp được bảo vệ hoặc có kích thước lớn."
---
## **Tổng quan**

Aspose.Slides cho Python thông qua .NET hợp nhất các bản trình bày bằng cách sao chép các slide từ một [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) sang bản trình bày khác. Hoạt động chính là [SlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/), có thể giữ nguyên định dạng của slide nguồn hoặc gắn slide đã sao chép vào một master hoặc layout trong bản trình bày đích.

Bài viết này bao gồm các quy trình hợp nhất phổ biến nhất:

- hợp nhất tất cả các slide đồng thời giữ nguyên định dạng nguồn;
- hợp nhất các slide được chọn;
- áp dụng một master từ bản trình bày đích;
- áp dụng một layout cụ thể từ bản trình bày đích;
- chuẩn hoá kích thước slide khác nhau trước khi hợp nhất;
- thêm các slide đã sao chép vào một section;
- hợp nhất nhiều bản trình bày trong một quy trình đầu‑cuối;
- xử lý masters, resources, notes, comments, media, fonts, passwords, tệp lớn và các vấn đề đa luồng.

## **Cách sao chép Slide ảnh hưởng đến Masters và Layouts**

Một slide kế thừa phần lớn giao diện từ layout và master của nó. Vì lý do này, overload sao chép mà bạn chọn quyết định cách slide được tích hợp vào bản trình bày đích.

Sử dụng [SlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/) theo một trong các cách sau:

- `add_clone(source_slide)` — giữ nguyên layout và định dạng của slide nguồn. Khi cần, master nguồn có thể được sao chép tự động vào bản trình bày đích. Aspose.Slides tự động theo dõi các master được sao chép để các slide lặp lại sử dụng cùng một master không gây sao chép master nhiều lần.
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — gắn slide đã sao chép vào một [IMasterSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imasterslide/) đích cụ thể. Aspose.Slides tìm layout phù hợp dưới master đó dựa trên kiểu layout hoặc tên.
- `add_clone(source_slide, destination_layout)` — gắn slide đã sao chép trực tiếp vào một [ILayoutSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ilayoutslide/) đích cụ thể.

Master hoặc layout được truyền vào overload `add_clone` phải thuộc về **bản trình bày đích**, không phải bản trình bày nguồn.

## **Hợp nhất Toàn bộ Bản trình bày và Giữ Định dạng Nguồn**

Cách hợp nhất đơn giản nhất là sao chép mọi slide từ bản trình bày nguồn sang bản trình bày đích. Đây là lựa chọn phù hợp khi các slide nhập vào cần giữ nguyên theme, master và cấu trúc layout gốc.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

Bản trình bày kết quả có thể chứa nhiều master khi nguồn và đích sử dụng các thiết kế khác nhau. Điều này là bình thường khi định dạng nguồn được cố ý giữ nguyên.

## **Hợp nhất Các Slide Được Chọn**

Bạn không cần sao chép mọi slide. Ví dụ dưới đây chỉ nhập các chỉ mục slide được chọn từ bản trình bày nguồn.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

Hãy xác thực chỉ mục slide trước khi sao chép khi chúng đến từ đầu vào của người dùng hoặc cấu hình bên ngoài.

## **Hợp nhất Slides bằng Master Đích**

Sử dụng overload [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/) khi các slide nhập vào cần tuân theo một master đã tồn tại trong bản trình bày đích.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides chọn một layout phù hợp dưới master được chỉ định bằng cách khớp kiểu hoặc tên layout nguồn. Nếu không có layout thích hợp và `allow_clone_missing_layout` được đặt là `True`, layout nguồn sẽ được sao chép để slide có thể được thêm. Nếu nó là `False`, một [PptxEditException](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pptxeditexception/) sẽ được ném ra.

Sử dụng `False` khi bạn muốn quá trình hợp nhất thất bại thay vì tạo thêm một layout vào master đích.

## **Hợp nhất Slides bằng Layout Đích Cụ Thể**

Sử dụng overload [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/) khi bạn biết chính xác layout đích mà các slide nhập vào nên sử dụng.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

Áp dụng một layout đích thay đổi quan hệ layout kế thừa; nó không thay đổi nội dung slide nguồn. Nếu layout nguồn và đích có cấu trúc placeholder khác nhau, hãy kiểm tra kết quả để xác nhận định dạng kế thừa và hành vi placeholder là phù hợp.

## **Hợp nhất Bản trình bày có Kích thước Slide Khác nhau**

Các bản trình bày có kích thước slide khác nhau có thể được hợp nhất, nhưng sao chép một slide vào bản trình bày có kích thước slide khác không tự động thiết kế lại nội dung cho canvas mới. Do đó hình dạng có thể bị dịch chuyển, co giãn không mong muốn hoặc nằm ngoài vùng hiển thị.

Một cách tiếp cận thực tế là thay đổi kích thước bản trình bày nguồn trước khi sao chép. Phương thức [SlideSize.set_size](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidesize/set_size/) có thể thu phóng nội dung hiện có đồng thời thay đổi kích thước slide. [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidesizescaletype/) thu phóng nội dung để vừa với kích thước yêu cầu.

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

Thay đổi kích thước sẽ sửa đổi đối tượng bản trình bày nguồn trong bộ nhớ. Nếu bạn cần giữ nguyên bản trình bày nguồn cho các thao tác khác, hãy mở một thể hiện riêng cho quá trình hợp nhất.

## **Hợp nhất Slides vào Section của Bản trình bày**

Vòng lặp sao chép slide cơ bản không tái tạo cấu trúc section của bản trình bày nguồn. Nếu section quan trọng trong kết quả, hãy tạo hoặc chọn các section trong bản trình bày đích và sao chép slide vào chúng một cách rõ ràng bằng [SlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/).

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

Các slide đã sao chép sẽ được nối vào section đích đã chỉ định. Để giữ lại nhiều section nguồn, hãy duyệt [Presentation.sections](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/sections/), lấy danh sách slide hiện tại của mỗi section nguồn bằng [Section.get_slides_list_of_section](https://reference.aspose.com/slides/vi/python-net/aspose.slides/section/get_slides_list_of_section/), tạo lại các section trong đích, và sao chép từng slide trở lại section tương ứng. Xem [Manage Slide Sections](/slides/vi/python-net/slide-section/) để có ví dụ đầy đủ về việc duyệt section, bao gồm cả các section rỗng và thay đổi cấu trúc.

## **Hợp nhất Nhiều Bản trình bày Một cách An toàn**

Ví dụ end‑to‑end dưới đây sử dụng bản trình bày đầu tiên làm đích, chuẩn hoá kích thước slide của mỗi nguồn bổ sung, chỉ mở mỗi nguồn trong thời gian nó được sao chép, và lưu tệp cuối cùng một lần.

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

Đây là một nền tảng hữu ích để giữ định dạng nguồn của các slide nhập vào. Nếu đầu ra của bạn phải sử dụng một theme duy nhất, hãy thay thế lời gọi đơn giản `add_clone(slide)` bằng overload master hoặc layout đích thích hợp đã trình bày ở trên.

## **Xem xét Thực tiễn**

### **Masters, Layouts và Độ chính xác Định dạng**

Sao chép slide mặc định có thể tự động đưa master nguồn cần thiết vào bản trình bày đích. Aspose.Slides giữ một registry nội bộ cho các master được sao chép tự động nhằm tránh sao chép lại cùng một master nhiều lần. Các master được sao chép thủ công không được theo dõi bởi registry này, vì vậy tránh sao chép trước các master trừ khi bạn cần kiểm soát cấu trúc master một cách rõ ràng.

Đừng cho rằng hai master hoặc layout có cùng tên sẽ hiển thị giống nhau. Nếu một mẫu công ty phải kiểm soát giao diện cuối cùng, hãy chọn một master hoặc layout đích một cách rõ ràng và xác minh kết quả sau khi hợp nhất.

### **Notes và Comments**

Speaker notes và slide comments gắn liền với nội dung slide và được sao chép khi slide được sao chép. Aspose.Slides cũng cung cấp các API riêng cho [presentation notes](/slides/vi/python-net/presentation-notes/) và [presentation comments](/slides/vi/python-net/presentation-comments/).

Nếu định dạng trang notes quan trọng, hãy kiểm tra bản trình bày đã hợp nhất vì notes master là đối tượng ở mức độ presentation và có thể khác nhau giữa các tệp nguồn. Đối với quy trình xét duyệt, cũng hãy xác minh tác giả comment và comment có luồng sau khi kết hợp các tệp từ các tác giả hoặc mẫu khác nhau.

### **Hình ảnh, Audio, Video, OLE Objects và Liên kết Ngoài**

Slides có thể tham chiếu đến các resources ở mức presentation như hình ảnh, audio nhúng, video nhúng và dữ liệu OLE. Hãy sao chép toàn bộ slide thay vì chỉ sao chép các shape hiển thị để Aspose.Slides có thể duy trì các quan hệ của slide tới các resources.

Resources được nhúng và được liên kết nên được xử lý khác nhau. Một audio, video, OLE object hoặc hyperlink được liên kết vẫn phụ thuộc vào mục tiêu bên ngoài; sao chép slide không biến một liên kết ngoài thành nội dung nhúng. Hãy kiểm tra đường dẫn và URL của các resources liên kết trong môi trường nơi bản trình bày hợp nhất sẽ được mở.

Aspose.Slides theo dõi các master được sao chép tự động, nhưng điều này không nên được hiểu là bảo đảm chung rằng các binary resources giống nhau từ các bản trình bày không liên quan sẽ luôn được deduplicate. Nếu kích thước tệp đầu ra quan trọng, hãy kiểm tra gói sau khi hợp nhất và đo kích thước thay vì dựa vào deduplication ngầm.

### **Font Nhúng và Khả dụng Font**

Font được quản lý ở mức presentation. Nếu typography phải đồng nhất trên các máy, đừng cho rằng chỉ sao chép slide sẽ đảm bảo mọi font cần thiết đã có trong môi trường đích. Bạn có thể kiểm tra các font đã nhúng bằng [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) và quản lý việc nhúng một cách rõ ràng như mô tả trong [Embed Fonts in Presentations](/slides/vi/python-net/embedded-font/).

Cũng hãy xác minh rằng bạn được phép nhúng các font được sử dụng trong các tệp nguồn. Giấy phép font có thể hạn chế việc nhúng.

### **Bản trình bày Bảo vệ Bằng Mật khẩu**

Một nguồn được bảo vệ bằng mật khẩu phải được mở thành công trước khi các slide của nó có thể được sao chép. Cung cấp mật khẩu qua [LoadOptions.password](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/password/).

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

Mở một nguồn đã mã hoá không tự động áp dụng cùng một bảo vệ cho bản trình bày đích. Hãy cấu hình bảo vệ đầu ra riêng khi cần.

### **Bản trình bày Lớn và Sử dụng Bộ nhớ**

Các bản trình bày lớn chứa hình ảnh độ phân giải cao, audio, video hoặc các binary objects lớn có thể tiêu tốn đáng kể bộ nhớ. [LoadOptions.blob_management_options](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/blob_management_options/) cung cấp các tùy chọn kiểm soát việc quản lý BLOB và sử dụng tệp tạm thời. Xem [Manage Presentation BLOBs](/slides/vi/python-net/manage-blob/) để có các chiến lược cho tệp lớn.

Đối với tệp lớn, ưu tiên tải từ đường dẫn tệp khi có thể, đóng mỗi bản trình bày nguồn ngay sau khi đã hợp nhất, và tránh lưu kết quả trung gian lặp đi lặp lại trừ khi quy trình yêu cầu checkpoint. Sử dụng `with slides.Presentation(...)` sẽ đảm bảo các tài nguyên của bản trình bày được giải phóng khi ngữ cảnh kết thúc.

### **An toàn Đa luồng**

Không tải, lưu hoặc sao chép một [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) đồng thời từ nhiều luồng. Giữ mỗi thao tác hợp nhất ở chế độ đơn luồng. Nếu bạn muốn thực hiện các công việc hợp nhất độc lập song song, hãy sử dụng các tiến trình đơn luồng riêng biệt và các thể hiện presentation độc lập như mô tả trong [hướng dẫn đa luồng của Aspose.Slides](/slides/vi/python-net/multithreading/).

## **FAQ**

**Làm sao để giữ nguyên thiết kế gốc của mỗi bản trình bày nguồn?**

Sử dụng [add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/) mà không cung cấp master hoặc layout đích. Aspose.Slides có thể tự động sao chép master nguồn khi slide nhập vào yêu cầu.

**Làm sao để các slide nhập vào sử dụng theme của đích?**

Sử dụng overload chấp nhận một master đích. Đưa vào một master từ bản trình bày đích, không phải từ nguồn. Aspose.Slides sẽ cố gắng ánh xạ mỗi slide nguồn tới một layout phù hợp dưới master đó.

**Khi nào nên dùng layout đích cụ thể thay vì master đích?**

Dùng một layout cụ thể khi mọi slide nhập vào đều cần sử dụng một layout đã biết. Dùng master khi bạn muốn Aspose.Slides tự chọn trong các layout của master dựa trên kiểu hoặc tên layout nguồn.

**Có thể hợp nhất các bản trình bày có kích thước slide khác nhau không?**

Có, nhưng nội dung slide sẽ không được tự động thiết kế lại cho kích thước đích. Hãy thay đổi kích thước bản trình bày nguồn trước khi sao chép, ví dụ bằng [SlideSize.set_size](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidesize/set_size/) và [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidesizescaletype/).

**Có thể hợp nhất các tệp PPT, PPTX và ODP thành một tệp duy nhất không?**

Có. Tải mỗi bản trình bày nguồn, sao chép các slide cần thiết vào một bản trình bày đích, và lưu bản đích ở định dạng đầu ra hỗ trợ. Vì các định dạng presentation không hỗ trợ cùng một tập hợp tính năng, hãy kiểm tra nội dung phức tạp sau khi hợp nhất đa định dạng. Xem [Supported File Formats](/slides/vi/python-net/supported-file-formats/).

**Các section nguồn có được giữ tự động không?**

Không, nếu chỉ sử dụng vòng lặp cơ bản chỉ sao chép slide. Hãy tạo lại các section cần thiết trong bản trình bày đích và sử dụng overload section của [add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/) khi cấu trúc section phải được bảo tồn.

**Speaker notes và comments có được giữ không?**

Chúng được sao chép cùng với slide đã sao chép. Đối với các quy trình phụ thuộc vào style của notes‑master, tác giả comment hoặc dữ liệu review dạng luồng, hãy xác minh kết quả hợp nhất vì những tình huống này liên quan đến cấu trúc ở mức presentation cũng như nội dung slide.

**Audio, video, OLE objects và hyperlink sẽ xảy ra như thế nào?**

Nội dung nhúng sẽ được mang theo như một phần của quan hệ resources của slide đã sao chép. Các liên kết ngoài vẫn ở ngoài, vì vậy các tệp hoặc URL mục tiêu phải vẫn tồn tại sau khi hợp nhất.

**Các font nhúng từ mọi nguồn có được đảm bảo có sẵn trong bản trình bày hợp nhất không?**

Không nên dựa chỉ vào sao chép slide để triển khai font. Kiểm tra các font nhúng trong bản đích và quản lý việc nhúng hoặc khả năng truy cập font bên ngoài một cách rõ ràng khi typography quan trọng.

**Làm sao để hợp nhất một tệp được bảo vệ bằng mật khẩu?**

Mở tệp bằng [LoadOptions.password](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/password/) thích hợp, sau đó sao chép các slide như bình thường. Bảo vệ đầu ra được cấu hình riêng.

**Làm sao để xử lý các bản trình bày rất lớn?**

Sử dụng quản lý BLOB khi các binary objects chiếm ưu thế bộ nhớ, ưu tiên tải từ đường dẫn tệp cho các tệp rất lớn, đóng nhanh các bản trình bày nguồn sau khi đã hợp nhất, và chỉ lưu kết quả cuối cùng khi cần.  

**Có thể hợp nhất slide từ nhiều luồng không?**

Không tải, lưu hoặc sao chép các thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) trong nhiều luồng đồng thời. Giữ mỗi thao tác hợp nhất ở chế độ đơn luồng; sử dụng các tiến trình đơn luồng độc lập nếu cần thực hiện các công việc hợp nhất riêng biệt song song.