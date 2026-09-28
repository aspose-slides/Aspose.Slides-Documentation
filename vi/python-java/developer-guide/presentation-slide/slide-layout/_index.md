---
title: Áp dụng hoặc Thay đổi Bố cục Slide trong Python qua Java
linktitle: Bố cục Slide
type: docs
weight: 60
url: /vi/python-java/slide-layout/
keywords:
- bố cục slide
- bố cục nội dung
- trình giữ chỗ
- thiết kế bài thuyết trình
- thiết kế slide
- bố cục không sử dụng
- hiển thị chân trang
- slide tiêu đề
- tiêu đề và nội dung
- tiêu đề phần
- hai nội dung
- so sánh
- chỉ tiêu đề
- bố cục trống
- nội dung có chú thích
- hình ảnh có chú thích
- tiêu đề và văn bản dọc
- tiêu đề dọc và văn bản
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Áp dụng, tạo và chỉnh sửa bố cục slide trong Aspose.Slides cho Python qua Java, thêm trình giữ chỗ, xóa các bố cục không sử dụng và kiểm soát hiển thị chân trang."
---
## **Tổng quan**

Bố cục slide xác định vị trí và định dạng của các trình giữ chỗ như tiêu đề, văn bản, hình ảnh, biểu đồ và bảng. Áp dụng một bố cục giúp các slide có cấu trúc nhất quán đồng thời cho phép mỗi slide chứa nội dung riêng của nó.

Các bố cục phổ biến nhất bao gồm:

- **Title Slide**: Chứa các trình giữ chỗ tiêu đề và phụ đề.
- **Title and Content**: Chứa một trình giữ chỗ tiêu đề và một trình giữ chỗ nội dung đa dụng.
- **Blank**: Không chứa bất kỳ trình giữ chỗ nội dung nào và hữu ích khi mọi hình dạng sẽ được đặt thủ công.

## **Hiểu về Kế thừa Bố cục**

Một bản trình chiếu có ba cấp độ liên quan:

1. A [slide chủ đề](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslide/) định nghĩa chủ đề, định dạng chung, nền và các đối tượng chung.
1. A [slide bố cục](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslide/) thuộc về một slide chủ đề và xác định một sắp xếp cụ thể của các trình giữ chỗ.
1. A [slide bình thường](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/) sử dụng một bố cục và lưu trữ nội dung được nhập cho slide đó.

Một slide bình thường kế thừa chủ đề và định dạng từ bố cục của nó, và bố cục kế thừa từ slide chủ đề. Giá trị được đặt trực tiếp trên một slide bình thường sẽ ghi đè giá trị kế thừa ở cấp độ đó. Khi một slide bình thường được tạo, các hình dạng trình giữ chỗ của nó được tạo ra từ bố cục đã chọn, trong khi nội dung nhập vào các trình giữ chỗ đó thuộc về slide bình thường.

Thêm các trình giữ chỗ cần thiết vào một bố cục trước khi tạo slide từ nó. Thêm một trình giữ chỗ khác vào một bố cục sau này không tự động thêm một hình dạng trình giữ chỗ tương ứng vào các slide bình thường đã tồn tại.

Mối quan hệ này có hai hậu quả quan trọng:

- Thay đổi định dạng kế thừa hoặc hình học của trình giữ chỗ hiện có trên một bố cục có thể cập nhật mọi slide phụ thuộc vào nó. Trước khi chỉnh sửa một bố cục đã được sử dụng, hãy kiểm tra các slide phụ thuộc và xem xét bản trình chiếu kết quả.
- Một bố cục vẫn đang được một slide sử dụng không thể bị xóa. Hãy chuyển các slide phụ thuộc của nó sang một bố cục khác trước, hoặc chỉ xóa các bố cục không được sử dụng.

Để biết thêm thông tin về cấp cao nhất của cây phân cấp này, xem [Slide Master](/slides/vi/python-java/slide-master/).

Để ẩn các logo hoặc hình dạng trang chủ được kế thừa trên một slide hoặc thông qua một bố cục chia sẻ, xem [Control the Visibility of Master Graphics](/slides/vi/python-java/slide-master/). Ví dụ so sánh hai slide sử dụng cùng một slide chủ đề.

## **Chọn và Áp dụng Bố cục Slide**

Sử dụng một loại bố cục khi bản trình chiếu tuân theo các định nghĩa bố cục tiêu chuẩn của PowerPoint. Tên bố cục có thể chỉnh sửa bởi người dùng và có thể được bản địa hóa, vì vậy việc chọn dựa trên tên ít đáng tin cậy trừ khi bạn kiểm soát mẫu nguồn.

Ví dụ sau tìm **Title and Content** trên slide chủ đề đầu tiên. Nếu bố cục đó không khả dụng, nó sẽ cố gắng quay lại **Blank**. Kiểm tra thứ hai đối với `None` là cần thiết vì một bản trình chiếu có thể chỉ chứa các bố cục tùy chỉnh. Bố cục đã chọn sau đó được áp dụng cho slide bình thường đầu tiên thông qua phương thức [Slide.setLayoutSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#setLayoutSlide).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Thay đổi bố cục của một slide không xóa các hình dạng thông thường được thêm trực tiếp vào slide. Tuy nhiên, vị trí trình giữ chỗ, định dạng kế thừa và sự tương quan giữa các trình giữ chỗ hiện có và bố cục mới có thể thay đổi, vì vậy hãy kiểm tra kết quả khi chuyển đổi giữa các bố cục khác nhau đáng kể.

## **Thêm một Slide Bố cục**

Lựa chọn và tạo là hai thao tác riêng biệt. Ví dụ trước đây chỉ chọn một bố cục hiện có; nó không tạo mới. Để tạo một bố cục, gọi phương thức [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterlayoutslidecollection/#add) trên bộ sưu tập bố cục của slide chủ đề mục tiêu.

Ví dụ sau luôn thêm một bố cục **Title and Content** mới có tên `Report Title and Content`, sau đó thêm một slide bình thường dựa trên nó. Tên bố cục phải là duy nhất trong bộ sưu tập.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Chỉ thêm bố cục khi mẫu thực sự cần một cấu trúc tái sử dụng khác. Nếu đã có một bố cục phù hợp, hãy chọn và tái sử dụng nó thay vì tạo bản sao dư thừa.

## **Thêm Trình giữ chỗ vào Slide Bố cục**

Phương thức [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslide/#getPlaceholderManager) cung cấp một [LayoutPlaceholderManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/) để thêm các hình dạng trình giữ chỗ vào một bố cục.

| Trình giữ chỗ PowerPoint | Phương thức [LayoutPlaceholderManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/) |
| ------------------------ | ------------------------------------------------------------------------------------------------------------------------------------ |
| ![Nội dung](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Nội dung (Chiều dọc)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Văn bản](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Văn bản (Chiều dọc)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Hình ảnh](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Biểu đồ](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Bảng](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Phương tiện](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Hình ảnh trực tuyến](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Ví dụ sau kiểm tra xem bố cục **Blank** có tồn tại không, thêm bốn trình giữ chỗ vào nó, và sau đó tạo một slide bình thường sử dụng bố cục đã chỉnh sửa. Thứ tự này có mục đích: các trình giữ chỗ được thêm trước khi slide bình thường được tạo, vì Aspose.Slides có thể tạo các hình dạng trình giữ chỗ tương ứng trên slide đó.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Các trình giữ chỗ trên slide bố cục](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Thay đổi định dạng kế thừa hoặc hình học của các trình giữ chỗ bố cục hiện có có thể ảnh hưởng đến các slide phụ thuộc. Một trình giữ chỗ bố cục mới được thêm vào sẽ không được tự động bổ sung vào các slide bình thường đã tồn tại. Hãy thử các thay đổi bố cục trên một bản sao của bản trình chiếu và kiểm tra mọi slide phụ thuộc.
{{% /alert %}}

## **Xóa các Slide Bố cục Không được Sử dụng**

Sử dụng phương thức [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) để xóa các bố cục mà không có slide bình thường nào tham chiếu. Phương thức sẽ để lại các bố cục vẫn đang được sử dụng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Để xóa một bố cục cụ thể, trước tiên sử dụng phương thức [hasDependingSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslide/#hasDependingSlides) hoặc [getDependingSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslide/#getDependingSlides). Chuyển các slide phụ thuộc sang bố cục khác trước khi gọi [LayoutSlide.remove](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslide/#remove). Cố gắng xóa một bố cục đang được sử dụng sẽ gây ra lỗi [PptxEditException](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pptxeditexception/).

## **Kiểm soát Hiển thị Chân trang trên một Slide Bố cục**

Một bố cục có các trình giữ chỗ chân trang, số slide và ngày‑giờ riêng. Sử dụng phương thức [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) để kiểm soát các trình giữ chỗ này cho một bố cục. Điều này hữu ích khi, ví dụ, các bố cục nội dung nên hiển thị chân trang nhưng các bố cục tiêu đề không nên.

Ví dụ sau chọn một bố cục một cách an toàn và làm cho các yếu tố chân trang của nó hiển thị:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kiểm soát Hiển thị Chân trang trên Slide Chủ đề và Các Bố cục Con của Nó**

Để áp dụng cài đặt chân trang nhất quán trên toàn bộ cây slide chủ đề, sử dụng phương thức [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslide/#getHeaderFooterManager). Các phương thức lan truyền của [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslideheaderfootermanager/) hoạt động trên slide chủ đề và các slide bố cục và slide bình thường phụ thuộc; chúng không chỉ nhắm tới một slide bình thường duy nhất.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Sự khác nhau giữa Slide Chủ đề và Slide Bố cục là gì?**

Slide chủ đề xác định chủ đề và định dạng chung của bản trình chiếu. Slide bố cục thuộc về một slide chủ đề và xác định một sắp xếp có thể tái sử dụng của các trình giữ chỗ. Các slide bình thường sử dụng các bố cục này và lưu trữ nội dung riêng cho từng slide.

**Tôi có thể sao chép một Slide Bố cục từ bản trình chiếu này sang bản trình chiếu khác không?**

Có. Thêm một bản sao vào bộ sưu tập đích bằng phương thức [addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/globallayoutslidecollection/#addClone). Khi sao chép giữa các bản trình chiếu, cũng hãy kiểm tra phông chữ, chủ đề, hình ảnh và các tài nguyên khác mà bố cục nguồn sử dụng.

**Điều gì xảy ra khi tôi chỉnh sửa một Bố cục đã được sử dụng?**

Các slide phụ thuộc sẽ kế thừa các thay đổi bố cục trừ khi chúng ghi đè định dạng hoặc đối tượng bị ảnh hưởng ở cấp địa phương. Hình học của trình giữ chỗ và kiểu kế thừa do đó có thể thay đổi trên nhiều slide cùng lúc. Sử dụng [getDependingSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslide/#getDependingSlides) để xác định các slide bị ảnh hưởng trước khi chỉnh sửa bố cục.

**Điều gì sẽ xảy ra nếu tôi xóa một Bố cục vẫn đang được sử dụng?**

Aspose.Slides sẽ ném ra một lỗi [PptxEditException](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pptxeditexception/). Hãy chuyển các slide phụ thuộc trước, hoặc sử dụng [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) để chỉ xóa các bố cục không được tham chiếu.