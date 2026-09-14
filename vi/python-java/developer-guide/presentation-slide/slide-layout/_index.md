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
- thiết kế bản trình bày
- thiết kế slide
- bố cục không sử dụng
- hiển thị footer
- slide tiêu đề
- tiêu đề và nội dung
- đầu mục phần
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
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Áp dụng, tạo và chỉnh sửa bố cục slide trong Aspose.Slides cho Python qua Java, thêm trình giữ chỗ, xóa các bố cục không sử dụng và kiểm soát hiển thị footer."
---
## **Tổng quan**

Bố cục slide xác định vị trí và định dạng của các trình giữ chỗ như tiêu đề, văn bản, hình ảnh, biểu đồ và bảng. Áp dụng một bố cục giúp các slide có cấu trúc nhất quán trong khi vẫn cho phép mỗi slide chứa nội dung riêng.

Các bố cục phổ biến nhất bao gồm:

- **Title Slide**: Chứa các trình giữ chỗ tiêu đề và phụ đề.
- **Title and Content**: Chứa một trình giữ chỗ tiêu đề và một trình giữ chỗ nội dung đa mục đích.
- **Blank**: Không chứa trình giữ chỗ nội dung nào và hữu ích khi mỗi hình dạng sẽ được đặt vị trí thủ công.

## **Hiểu về kế thừa bố cục**

Một bản trình bày có ba cấp độ liên quan:

1. Một [master slide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslide/) xác định chủ đề, định dạng chung, nền và các đối tượng chung.
1. Một [layout slide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslide/) thuộc về một master và xác định một cách sắp xếp cụ thể của các trình giữ chỗ.
1. Một [normal slide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/) sử dụng một bố cục và lưu trữ nội dung được nhập cho slide đó.

Một normal slide kế thừa chủ đề và định dạng từ layout của nó, và layout kế thừa từ master của nó. Giá trị được đặt trực tiếp trên normal slide sẽ ghi đè giá trị kế thừa ở cấp độ đó. Khi một normal slide được tạo, các hình dạng trình giữ chỗ của nó được tạo ra từ layout đã chọn, trong khi nội dung nhập vào các trình giữ chỗ đó thuộc về normal slide.

Thêm các trình giữ chỗ cần thiết vào một layout trước khi tạo slide từ nó. Thêm một trình giữ chỗ khác vào layout sau này không tự động thêm một hình dạng trình giữ chỗ tương ứng vào các normal slide hiện có.

Mối quan hệ này có hai hậu quả quan trọng:

- Thay đổi định dạng kế thừa hoặc hình học của các trình giữ chỗ hiện có trên một layout có thể cập nhật mọi slide phụ thuộc vào nó. Trước khi chỉnh sửa một layout đã được sử dụng, hãy kiểm tra các slide phụ thuộc và xem lại bản trình bày kết quả.
- Một layout vẫn đang được một slide sử dụng không thể bị xóa. Hãy chuyển các slide phụ thuộc sang layout khác trước, hoặc chỉ xóa các layout không được sử dụng.

Để biết thêm thông tin về cấp cao nhất của cấu trúc này, xem [Slide Master](/slides/vi/python-java/slide-master/).

## **Chọn và Áp dụng Bố cục Slide**

Sử dụng kiểu layout khi bản trình bày tuân theo các định nghĩa bố cục chuẩn của PowerPoint. Tên layout có thể chỉnh sửa bởi người dùng và có thể được bản địa hoá, vì vậy việc chọn dựa trên tên ít đáng tin cậy trừ khi bạn kiểm soát mẫu nguồn.

Ví dụ sau tìm **Title and Content** trên master đầu tiên. Nếu layout đó không khả dụng, nó cố ý quay lại **Blank**. Kiểm tra thứ hai cho `None` là cần thiết vì một bản trình bày có thể chỉ chứa các layout tùy chỉnh. Layout được chọn sau đó được áp dụng cho normal slide đầu tiên thông qua phương thức [Slide.setLayoutSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#setLayoutSlide).

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

Thay đổi layout của một slide không loại bỏ các hình dạng thường được thêm trực tiếp vào slide. Tuy nhiên, vị trí trình giữ chỗ, định dạng kế thừa và sự tương ứng giữa các trình giữ chỗ hiện có và layout mới có thể thay đổi, vì vậy hãy kiểm tra kết quả khi chuyển đổi giữa các layout khác nhau đáng kể.

## **Thêm một Layout Slide**

Lựa chọn và tạo mới là hai thao tác riêng biệt. Ví dụ trước chọn một layout hiện có; nó không tạo mới. Để tạo một layout, gọi phương thức [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterlayoutslidecollection/#add) trên bộ sưu tập layout của master mục tiêu.

Ví dụ sau luôn thêm một layout **Title and Content** mới có tên `Report Title and Content`, sau đó thêm một normal slide dựa trên nó. Tên layout phải là duy nhất trong bộ sưu tập.

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

Chỉ thêm layout khi mẫu thực sự cần một cấu trúc tái sử dụng khác. Nếu đã tồn tại một layout phù hợp, hãy chọn và tái sử dụng nó thay vì tạo một bản sao.

## **Thêm Trình giữ chỗ vào Layout Slide**

Phương thức [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslide/#getPlaceholderManager) cung cấp một [LayoutPlaceholderManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/) để thêm các hình dạng trình giữ chỗ vào layout.

| Trình giữ chỗ PowerPoint              | Phương thức [LayoutPlaceholderManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/) |
| ----------------------------------- | ---------------------------------- |
| ![Nội dung](content.png)             | [addContentPlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Nội dung (Dọc)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Văn bản](text.png)                   | [addTextPlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Văn bản (Dọc)](textV.png)       | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Hình ảnh](picture.png)             | [addPicturePlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Biểu đồ](chart.png)                 | [addChartPlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Bảng](table.png)                 | [addTablePlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [addSmartArtPlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Phương tiện](media.png)                 | [addMediaPlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Hình ảnh trực tuyến](onlineImage.png)    | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Ví dụ sau kiểm tra xem layout **Blank** có tồn tại không, thêm bốn trình giữ chỗ vào nó, và sau đó tạo một normal slide sử dụng layout đã được chỉnh sửa. Thứ tự này có ý định: các trình giữ chỗ được thêm trước khi normal slide được tạo, vì vậy Aspose.Slides có thể tạo các hình dạng trình giữ chỗ tương ứng trên slide đó.

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

![Các trình giữ chỗ trên layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Thay đổi định dạng kế thừa hoặc hình học của các trình giữ chỗ layout hiện có có thể ảnh hưởng đến các slide phụ thuộc. Một trình giữ chỗ layout mới được thêm vào không được tự động điền vào các normal slide hiện có. Hãy thử các thay đổi layout trên một bản sao của bản trình bày và kiểm tra mọi slide phụ thuộc.
{{% /alert %}}

## **Xóa các Layout Slide không sử dụng**

Sử dụng phương thức [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) để xóa các layout mà không có normal slide nào tham chiếu. Phương thức sẽ giữ lại các layout vẫn đang được sử dụng.

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

Để xóa một layout cụ thể, trước tiên sử dụng phương thức [hasDependingSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslide/#hasDependingSlides) hoặc [getDependingSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslide/#getDependingSlides). Chuyển các slide phụ thuộc sang layout khác trước khi gọi [LayoutSlide.remove](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslide/#remove). Cố gắng xóa một layout đang được sử dụng sẽ gây ra một [PptxEditException](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pptxeditexception/).

## **Kiểm soát hiển thị Footer trên Layout Slide**

Một layout có các trình giữ chỗ footer, slide-number và date-time riêng. Sử dụng phương thức [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) để kiểm soát các trình giữ chỗ này cho một layout. Điều này hữu ích khi, ví dụ, các layout nội dung nên hiển thị footer nhưng các layout tiêu đề không.

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

## **Kiểm soát hiển thị Footer trên Master và các Layout con**

Để áp dụng cài đặt footer nhất quán trên toàn bộ cây master, sử dụng phương thức [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslide/#getHeaderFooterManager). Các phương thức lan truyền của [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslideheaderfootermanager/) hoạt động trên master và các layout slide và normal slide phụ thuộc; chúng không chỉ áp dụng cho một normal slide duy nhất.

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

**Sự khác nhau giữa Master Slide và Layout Slide là gì?**

Master Slide xác định chủ đề và định dạng chung của bản trình bày. Layout Slide thuộc về một master và xác định một cách sắp xếp trình giữ chỗ có thể tái sử dụng. Normal slide sử dụng các layout này và lưu trữ nội dung riêng cho từng slide.

**Tôi có thể sao chép Layout Slide từ một bản trình bày sang bản khác không?**

Có. Thêm một bản sao vào bộ sưu tập đích bằng phương thức [addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/globallayoutslidecollection/#addClone). Khi sao chép giữa các bản trình bày, cũng cần kiểm tra phông chữ, chủ đề, hình ảnh và các tài nguyên khác được layout nguồn sử dụng.

**Điều gì xảy ra khi tôi chỉnh sửa một Layout đã được sử dụng?**

Các slide phụ thuộc sẽ kế thừa các thay đổi layout trừ khi chúng ghi đè định dạng hoặc đối tượng bị ảnh hưởng ở mức cục bộ. Hình học của trình giữ chỗ và kiểu kế thừa có thể thay đổi trên nhiều slide cùng lúc. Sử dụng [getDependingSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslide/#getDependingSlides) để xác định các slide bị ảnh hưởng trước khi chỉnh sửa layout.

**Điều gì sẽ xảy ra nếu tôi xóa một Layout vẫn đang được sử dụng?**

Aspose.Slides sẽ ném ra một [PptxEditException](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pptxeditexception/). Hãy chuyển các slide phụ thuộc sang layout khác trước, hoặc sử dụng [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) để chỉ xóa các layout không được tham chiếu.