---
title: Kết hợp Hiệu quả các Bản trình chiếu trong Python qua Java
linktitle: Kết Hợp Bản Trình Chiếu
type: docs
weight: 40
url: /vi/python-java/merge-presentation/
keywords:
- kết hợp PowerPoint
- kết hợp bản trình chiếu
- kết hợp slide
- kết hợp PPT
- kết hợp PPTX
- kết hợp ODP
- gộp PowerPoint
- gộp bản trình chiếu
- gộp slide
- gộp PPT
- gộp PPTX
- gộp ODP
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách kết hợp các bản trình chiếu PowerPoint và OpenDocument trong Python qua Java bằng cách sao chép slide, kiểm soát master và layout, thay đổi kích thước nội dung slide, giữ nguyên các section và xử lý các tệp được bảo mật hoặc kích thước lớn."
---
## **Tổng quan**

Aspose.Slides for Python via Java hợp nhất các bản trình chiếu bằng cách sao chép slide từ một [Bản trình chiếu](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) sang bản khác. Hoạt động chính là [SlideCollection.addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addClone), có thể giữ nguyên định dạng của slide nguồn hoặc gắn slide đã sao chép vào một master hoặc layout trong bản trình chiếu đích.

Bài viết này đề cập đến các quy trình hợp nhất thường gặp:

- hợp nhất tất cả các slide đồng thời giữ nguyên định dạng nguồn;
- hợp nhất các slide được chọn;
- áp dụng master từ bản trình chiếu đích;
- áp dụng layout cụ thể từ bản trình chiếu đích;
- chuẩn hoá các kích thước slide khác nhau trước khi hợp nhất;
- thêm các slide đã sao chép vào một section;
- hợp nhất nhiều bản trình chiếu trong một quy trình đầu cuối;
- xử lý master, tài nguyên, ghi chú, bình luận, phương tiện, phông chữ, mật khẩu, tệp lớn và các vấn đề đa luồng.

## **Cách sao chép slide ảnh hưởng đến Master và Layout**

Một slide kế thừa phần lớn giao diện của nó từ layout và master. Do đó, overload sao chép mà bạn chọn sẽ quyết định cách slide được hợp nhất được tích hợp vào bản trình chiếu đích.

Sử dụng [SlideCollection.addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addClone) theo một trong các cách sau:

- `addClone(source_slide)` — giữ nguyên layout và định dạng của slide nguồn. Khi cần, master nguồn có thể được sao chép vào bản trình chiếu đích một cách tự động. Aspose.Slides theo dõi các master được sao chép tự động để các slide lặp lại sử dụng cùng một master nguồn không bị sao chép lại nhiều lần.
- `addClone(source_slide, destination_master, allow_clone_missing_layout)` — gắn slide đã sao chép vào một [MasterSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslide/) đích cụ thể. Aspose.Slides tìm kiếm layout phù hợp dưới master đó theo kiểu layout hoặc tên.
- `addClone(source_slide, destination_layout)` — gắn slide đã sao chép trực tiếp vào một [LayoutSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslide/) đích cụ thể.

Master hoặc layout được truyền vào overload `addClone` phải thuộc về bản trình chiếu **đích**, không phải bản trình chiếu nguồn.

## **Hợp nhất toàn bộ bản trình chiếu và giữ nguyên định dạng nguồn**

Phương pháp hợp nhất đơn giản nhất sao chép mọi slide từ bản trình chiếu nguồn sang bản trình chiếu đích. Đây là lựa chọn phù hợp khi các slide được nhập cần giữ nguyên giao diện gốc, master và mối quan hệ layout.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Bản trình chiếu kết quả có thể chứa nhiều master khi bản nguồn và bản đích sử dụng các thiết kế khác nhau. Điều này là mong đợi khi định dạng nguồn được giữ nguyên cố ý.

## **Hợp nhất các slide đã chọn**

Bạn không cần sao chép mọi slide. Ví dụ dưới đây chỉ nhập các chỉ mục slide được chọn từ bản trình chiếu nguồn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        slide_indexes = [0, 2, 4]
        for index in slide_indexes:
            if 0 <= index < source.getSlides().size():
                destination.getSlides().addClone(source.getSlides().get_Item(index))
            else:
                print(f"Skipping invalid slide index: {index}")
    finally:
        source.dispose()

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Xác thực chỉ mục slide trước khi sao chép khi chúng đến từ đầu vào của người dùng hoặc cấu hình bên ngoài.

## **Hợp nhất slide bằng Master đích**

Sử dụng overload [SlideCollection.addClone] khi các slide được nhập cần tuân theo một master đã thuộc về bản trình chiếu đích.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_master = destination.getMasters().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_master, True)
    finally:
        source.dispose()

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Aspose.Slides chọn một layout phù hợp dưới master đã chỉ định bằng cách khớp kiểu hoặc tên của layout nguồn. Nếu không có layout thích hợp và `allow_clone_missing_layout` là `True`, layout nguồn sẽ được sao chép để slide có thể được thêm. Nếu là `False`, một [PptxEditException](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pptxeditexception/) sẽ được ném.

Sử dụng `False` khi bạn muốn quá trình hợp nhất thất bại thay vì thêm một layout mới vào master đích.

## **Hợp nhất slide bằng Layout đích cụ thể**

Sử dụng overload [SlideCollection.addClone] khi bạn biết chính xác layout đích mà các slide được nhập nên sử dụng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_layout = destination.getLayoutSlides().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_layout)
    finally:
        source.dispose()

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Áp dụng một layout đích thay đổi quan hệ layout được kế thừa; nó không thiết kế lại nội dung slide nguồn. Nếu layout nguồn và layout đích có cấu trúc placeholder khác nhau, hãy kiểm tra kết quả để xác nhận định dạng và hành vi placeholder được kế thừa là phù hợp.

## **Hợp nhất bản trình chiếu với các kích thước slide khác nhau**

Các bản trình chiếu có kích thước slide khác nhau có thể được hợp nhất, nhưng sao chép một slide vào bản trình chiếu có kích thước slide khác không tự động thiết kế lại nội dung cho khung mới. Do đó các hình dạng có thể bị dịch, thu phóng không mong muốn hoặc nằm ngoài vùng hiển thị của slide.

Cách thực tế là thay đổi kích thước bản trình chiếu nguồn trước khi sao chép. Phương thức [SlideSize.setSize] có thể co giãn nội dung hiện có đồng thời thay đổi kích thước slide. [SlideSizeScaleType.EnsureFit] co giãn nội dung để vừa với kích thước yêu cầu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        source_size = source.getSlideSize().getSize()
        destination_size = destination.getSlideSize().getSize()
        width = jpype.JFloat(destination_size.getWidth())
        height = jpype.JFloat(destination_size.getHeight())
        if source_size.getWidth() != width or source_size.getHeight() != height:
            source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Thay đổi kích thước sẽ thay đổi đối tượng bản trình chiếu nguồn trong bộ nhớ. Nếu bạn cần giữ nguyên bản trình chiếu nguồn cho các thao tác khác, hãy mở một thể hiện riêng cho quá trình hợp nhất.

## **Hợp nhất slide vào một Section của bản trình chiếu**

Vòng lặp sao chép slide cơ bản không tái tạo cấu trúc section của bản trình chiếu nguồn. Nếu section quan trọng trong kết quả, hãy tạo hoặc chọn các section trong bản trình chiếu đích và sao chép slide vào chúng một cách rõ ràng bằng [SlideCollection.addClone].

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        imported_section = destination.getSections().appendEmptySection("Imported slides")
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, imported_section)
    finally:
        source.dispose()

    destination.save("merged-with-section.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Các slide đã sao chép sẽ được nối vào section đích đã chỉ định. Để giữ lại nhiều section nguồn, liệt kê [Presentation.getSections], lấy danh sách slide hiện tại của mỗi section nguồn bằng [Section.getSlidesListOfSection], tạo lại các section trong bản đích, và sao chép từng slide vào section đích tương ứng. Xem [Quản lý Section Slide](/slides/vi/python-java/slide-section/) để có ví dụ đầy đủ về liệt kê section, bao gồm cả các section rỗng và thay đổi cấu trúc.

## **Hợp nhất nhiều bản trình chiếu một cách an toàn**

Ví dụ đầu‑cuối dưới đây sử dụng bản trình chiếu đầu tiên làm đích, chuẩn hoá kích thước slide của mỗi bản nguồn bổ sung, mở mỗi nguồn chỉ trong thời gian sao chép và lưu tệp cuối cùng một lần.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

merged = Presentation(input_files[0])
try:
    merged_size = merged.getSlideSize().getSize()
    width = jpype.JFloat(merged_size.getWidth())
    height = jpype.JFloat(merged_size.getHeight())

    for input_file in input_files[1:]:
        source = Presentation(input_file)
        try:
            source_size = source.getSlideSize().getSize()
            if source_size.getWidth() != width or source_size.getHeight() != height:
                source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

            for slide in source.getSlides():
                merged.getSlides().addClone(slide)
        finally:
            source.dispose()

    merged.save("merged.pptx", SaveFormat.Pptx)
finally:
    merged.dispose()
```

Đây là nền tảng hữu ích để giữ nguyên định dạng nguồn của các slide được nhập. Nếu đầu ra của bạn phải sử dụng một theme duy nhất, thay thế lời gọi đơn giản `addClone(slide)` bằng overload master hoặc layout đích phù hợp đã trình bày ở trên.

## **Cân nhắc thực tiễn**

### **Master, Layout và Độ chính xác Định dạng**

Sao chép slide mặc định có thể tự động đưa master nguồn cần thiết vào bản trình chiếu đích. Aspose.Slides duy trì một bảng đăng ký nội bộ cho các master được sao chép tự động nhằm tránh sao chép lại cùng một master. Các master được sao chép thủ công không được bảng đăng ký này theo dõi, vì vậy nên tránh sao chép trước các master trừ khi bạn cần kiểm soát cấu trúc master một cách rõ ràng.

Không giả định rằng hai master hoặc layout cùng tên sẽ hiển thị giống nhau. Nếu một mẫu công ty phải kiểm soát giao diện cuối cùng, hãy chọn một master hoặc layout đích một cách rõ ràng và kiểm tra kết quả sau khi hợp nhất.

### **Ghi chú và Bình luận**

Speaker notes và comment của slide được gắn với nội dung slide và được sao chép khi slide được sao chép. Aspose.Slides cũng cung cấp API riêng cho [presentation notes](/slides/vi/python-java/presentation-notes/) và [presentation comments](/slides/vi/python-java/presentation-comments/).

Nếu định dạng trang notes quan trọng, hãy kiểm tra bản trình chiếu đã hợp nhất vì notes master là đối tượng ở mức bản trình chiếu và có thể khác nhau giữa các tệp nguồn. Đối với quy trình xem xét, cũng nên kiểm tra tác giả comment và chuỗi comment sau khi kết hợp các tệp từ các tác giả hoặc mẫu khác nhau.

### **Hình ảnh, Âm thanh, Video, Đối tượng OLE và Liên kết Ngoài**

Slide có thể tham chiếu tới các tài nguyên ở mức bản trình chiếu như hình ảnh, âm thanh nhúng, video nhúng và dữ liệu OLE. Hãy sao chép toàn bộ slide thay vì chỉ sao chép các hình dạng nhìn thấy để Aspose.Slides có thể duy trì các mối quan hệ của slide với các tài nguyên.

Các tài nguyên nhúng và liên kết nên được xử lý khác nhau. Một audio, video, đối tượng OLE hoặc hyperlink được liên kết vẫn phụ thuộc vào mục tiêu bên ngoài; sao chép slide không biến một liên kết ngoài thành nội dung nhúng. Kiểm tra đường dẫn và URL của tài nguyên liên kết trong môi trường mà bản trình chiếu hợp nhất sẽ được mở.

Aspose.Slides theo dõi rõ ràng các master được sao chép tự động, nhưng không nên coi đây là tiêu chuẩn bảo đảm rằng các tài nguyên nhị phân giống nhau từ các bản nguồn không liên quan sẽ luôn được loại bỏ trùng lặp. Nếu kích thước tệp đầu ra quan trọng, hãy kiểm tra gói đã hợp nhất và đo kết quả thay vì dựa vào việc loại bỏ trùng lặp ngầm.

### **Phông chữ nhúng và Khả năng sẵn có của Phông chữ**

Phông chữ được quản lý ở mức bản trình chiếu. Nếu kiểu chữ phải đồng nhất trên các máy, không nên giả định rằng chỉ sao chép slide sẽ đảm bảo mọi phông chữ cần thiết có sẵn trong môi trường đích. Bạn có thể xem các phông chữ đã nhúng bằng [FontsManager.getEmbeddedFonts] và quản lý việc nhúng một cách rõ ràng như mô tả trong [Embed Fonts in Presentations](/slides/vi/python-java/embedded-font/).

Cũng hãy xác nhận rằng bạn được phép nhúng các phông chữ được sử dụng trong các tệp nguồn. Giấy phép phông chữ có thể hạn chế việc nhúng.

### **Bản trình chiếu được bảo vệ bằng mật khẩu**

Một bản nguồn được bảo vệ bằng mật khẩu phải được mở thành công trước khi các slide của nó có thể được sao chép. Cung cấp mật khẩu qua [LoadOptions.setPassword].

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setPassword("YOUR_PASSWORD")

source = Presentation("protected.pptx", load_options)
try:
    # Làm việc với bản trình chiếu đã giải mã.
    print(f"Loaded {source.getSlides().size()} slides.")
finally:
    source.dispose()
```

Mở một nguồn được mã hoá không tự động áp dụng cùng một bảo mật cho bản trình chiếu đích. Cấu hình bảo mật đầu ra riêng khi cần.

### **Bản trình chiếu lớn và Sử dụng bộ nhớ**

Các bản trình chiếu lớn chứa hình ảnh độ phân giải cao, âm thanh, video hoặc các đối tượng nhị phân lớn khác có thể tiêu tốn đáng kể bộ nhớ. [LoadOptions.getBlobManagementOptions] cung cấp các tùy chọn kiểm soát việc xử lý BLOB và sử dụng tệp tạm. Xem [Manage Presentation BLOBs](/slides/vi/python-java/manage-blob/) để có chiến lược cho tệp lớn.

Đối với tệp lớn, ưu tiên tải từ đường dẫn tệp khi có thể, giải phóng mỗi bản trình chiếu nguồn ngay sau khi đã hợp nhất, và tránh lưu lại các kết quả trung gian nhiều lần trừ khi quy trình yêu cầu checkpoint.

### **An toàn đa luồng**

Không tải, sửa đổi, lưu hoặc sao chép cùng một [Presentation] đồng thời từ nhiều luồng. Giữ mỗi thể hiện bản trình chiếu chỉ trong một thao tác hợp nhất. Nếu bạn thực hiện các công việc độc lập song song, hãy dùng các thể hiện bản trình chiếu độc lập và tuân theo [Aspose.Slides multithreading guidance](/slides/vi/python-java/multithreading/).

## **Câu hỏi thường gặp**

**Làm sao để giữ nguyên thiết kế gốc của mỗi bản trình chiếu nguồn?**

Sử dụng [addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addClone) mà không cung cấp master hoặc layout đích. Aspose.Slides có thể tự động sao chép master nguồn khi slide được nhập cần đến.

**Làm sao để các slide được nhập sử dụng theme của bản đích?**

Dùng overload chấp nhận một master đích. Cung cấp một master từ bản trình chiếu đích, không phải từ bản nguồn. Aspose.Slides sẽ cố gắng ánh xạ mỗi slide nguồn tới một layout phù hợp dưới master đó.

**Khi nào nên dùng layout đích cụ thể thay vì master đích?**

Dùng layout cụ thể khi mọi slide nhập cần sử dụng một layout đã biết. Dùng master khi bạn muốn Aspose.Slides tự chọn giữa các layout của master dựa trên kiểu hoặc tên của layout nguồn.

**Có thể hợp nhất các bản trình chiếu có kích thước slide khác nhau không?**

Có, nhưng nội dung slide không được thiết kế lại tự động cho kích thước đích. Hãy thay đổi kích thước bản nguồn trước khi cần vị trí dự đoán, ví dụ bằng [SlideSize.setSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesize/#setSize) và [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesizescaletype/).

**Có thể hợp nhất các tệp PPT, PPTX và ODP thành một file không?**

Có. Tải mỗi bản trình chiếu nguồn, sao chép các slide cần thiết vào một bản đích, và lưu bản đích ở định dạng hỗ trợ. Vì các định dạng bản trình chiếu không hỗ trợ cùng một tập hợp tính năng, hãy kiểm tra nội dung phức tạp sau khi hợp nhất đa định dạng. Xem [Supported File Formats](/slides/vi/python-java/supported-file-formats/).

**Các section nguồn có được giữ tự động không?**

Không, nếu chỉ dùng vòng lặp cơ bản sao chép slide. Hãy tạo lại các section cần thiết trong bản đích và sử dụng overload section của [addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addClone) khi cấu trúc section phải được bảo lưu.

**Ghi chú và bình luận có được giữ lại không?**

Chúng được sao chép cùng với slide đã sao chép. Đối với quy trình phụ thuộc vào styling của notes‑master, tác giả comment hoặc dữ liệu review dạng chuỗi, hãy kiểm tra kết quả hợp nhất vì những trường hợp này liên quan đến cấu trúc ở mức bản trình chiếu cũng như nội dung slide.

**Điều gì xảy ra với audio, video, đối tượng OLE và hyperlink?**

Nội dung nhúng sẽ được mang theo như một phần của các mối quan hệ tài nguyên của slide đã sao chép. Các liên kết ngoài vẫn ở ngoài, vì vậy các tệp hoặc URL mục tiêu phải vẫn khả dụng sau khi hợp nhất.

**Các phông chữ nhúng từ mọi nguồn có chắc chắn có trong bản trình chiếu đã hợp nhất không?**

Không nên dựa chỉ vào sao chép slide để triển khai phông chữ. Kiểm tra các phông chữ nhúng trong bản đích và quản lý việc nhúng phông chữ hoặc khả năng có sẵn phông chữ bên ngoài một cách rõ ràng khi typography quan trọng.

**Làm sao để hợp nhất một tệp được bảo vệ bằng mật khẩu?**

Mở tệp bằng [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setPassword) đúng, sau đó sao chép các slide bình thường. Bảo mật đầu ra được cấu hình riêng.

**Nên xử lý các bản trình chiếu rất lớn như thế nào?**

Sử dụng quản lý BLOB khi các đối tượng nhị phân lớn chi phối việc sử dụng bộ nhớ, ưu tiên tải từ đường dẫn tệp cho các tệp rất lớn, giải phóng nhanh các bản trình chiếu nguồn và chỉ lưu kết quả cuối cùng khi cần.

**Có thể hợp nhất slide từ nhiều luồng không?**

Không sử dụng cùng một thể hiện [Presentation] đồng thời từ nhiều luồng. Giữ mỗi thao tác hợp nhất riêng biệt trong các thể hiện bản trình chiếu của riêng nó.