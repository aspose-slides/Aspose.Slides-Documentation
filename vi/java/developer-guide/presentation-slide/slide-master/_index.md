---
title: Quản lý Slide Master trong bản trình bày Java
linktitle: Slide Master
type: docs
weight: 70
url: /vi/java/slide-master/
keywords:
- slide master
- slide master
- slide master PPT
- nhiều slide master
- so sánh slide master
- nền
- trình giữ chỗ
- sao chép slide master
- sao chép slide master
- nhân bản slide master
- slide master không sử dụng
- PowerPoint
- OpenDocument
- bản trình bày
- Java
- Aspose.Slides
description: "Quản lý slide master trong Aspose.Slides cho Java: truy cập, chỉnh sửa, sao chép, so sánh và xóa slide master trong bản trình bày PowerPoint và OpenDocument."
---
## **Tổng quan**

Một **slide master** xác định các cài đặt thiết kế chung cho một nhóm các slide. Nó có thể chứa các hình dạng chung, logo, nền, kiểu văn bản, cài đặt chủ đề và cài đặt chân trang. Trong PowerPoint, chỉnh sửa một slide master là cách thường dùng để giữ cho bản trình bày nhất quán mà không phải lặp lại cùng một định dạng trên mỗi slide.

Aspose.Slides for Java hỗ trợ cùng mô hình. Một bản trình bày có thể chứa một hoặc nhiều master slide, và mỗi master slide có thể chứa một số layout slide. Các slide bình thường thường không tham chiếu trực tiếp tới một master slide. Thay vào đó, một slide bình thường sử dụng một layout slide, và layout slide đó thuộc về một master slide.

Cây phân cấp như sau:

1. **Slide master** - xác định thiết kế và chủ đề chung.
1. **Layout slide** - xác định cách sắp xếp cụ thể của các placeholder và định dạng cấp layout.
1. **Normal slide** - chứa nội dung thực của bản trình bày và sử dụng một layout slide.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

Trong Aspose.Slides, slide master được biểu diễn bằng giao diện [IMasterSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslide/). Tất cả các master slide trong một bản trình bày có sẵn qua bộ sưu tập [Presentation.getMasters](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getMasters--) , bộ sưu tập này thực thi [IMasterSlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Khi cùng một thuộc tính được định nghĩa ở nhiều mức, mức cụ thể hơn sẽ thắng. Ví dụ, nếu một master slide và một layout slide đều định nghĩa nền, các slide dựa trên layout đó sẽ sử dụng nền của layout. Để biết thêm thông tin về layout slide, xem [Áp dụng hoặc Thay đổi Bố cục Slide](/slides/vi/java/slide-layout/).
{{% /alert %}}

## **Truy cập Slide Masters**

Trong PowerPoint, bạn có thể mở chế độ xem Slide Master từ **View** > **Slide Master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

Trong Aspose.Slides, dùng bộ sưu tập `getMasters()` để truy cập các master slide:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Bạn cũng có thể lấy master slide được sử dụng bởi một slide bình thường thông qua layout của nó:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Nội dung của Slide Master**

Một master slide là một đối tượng dạng slide. Nó thực thi [IBaseSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseslide/), vì vậy nó cung cấp nhiều thuộc tính slide giống như slide bình thường và layout. Các thành viên riêng của master được liệt kê trên trang API [IMasterSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslide/).

Các thành viên master slide thường được sử dụng bao gồm:

| Thành viên | Mục đích |
| --- | --- |
| `getBackground()` | Đặt nền slide mức master. |
| `getShapes()` | Lưu trữ các hình dạng được đặt trên master, như logo, khung hình ảnh và văn bản chung. |
| `getLayoutSlides()` | Lưu trữ các layout slide thuộc về master. |
| `getThemeManager()` | Cung cấp quyền truy cập vào các API chủ đề master. |
| `getHeaderFooterManager()` | Điều khiển tiêu đề, chân trang, ngày tháng và số slide cho master và các layout con. |
| `getDependingSlides()` | Trả về các slide bình thường phụ thuộc vào master thông qua layout của chúng. |

## **Thêm Hình ảnh vào Slide Master**

Khi bạn thêm hình ảnh vào một master slide, hình ảnh sẽ xuất hiện trên các slide dùng layout từ master đó. Điều này hữu ích cho logo, dấu nước, dải trang trí và các yếu tố hình ảnh lặp lại khác.

Ví dụ sau thêm một logo vào master slide đầu tiên:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để biết thêm thông tin về khung hình ảnh, xem [Picture Frame](/slides/vi/java/picture-frame/).

## **Làm việc với Placeholder**

Placeholder thường được định nghĩa trên layout slide. Master slide cung cấp kiểu và chủ đề chung mà các layout kế thừa, trong khi mỗi layout quyết định placeholder nào có sẵn và vị trí của chúng.

Trong PowerPoint, các lệnh placeholder có sẵn trong chế độ xem Slide Master.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Để thêm placeholder mới với Aspose.Slides, làm việc với layout slide thuộc về master:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bạn cũng có thể định dạng các shape placeholder đã có trên master slide. Ví dụ sau tìm placeholder tiêu đề và áp dụng màu gradient tuyến tính:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

Để biết thêm các tùy chọn định dạng placeholder và văn bản, xem [Đặt Văn bản Gợi ý trong Placeholder](/slides/vi/java/manage-placeholder/) và [Định dạng Văn bản](/slides/vi/java/text-formatting/).

## **Thay đổi Nền Slide Master**

Nền master được kế thừa bởi các layout và slide không ghi đè nó. Ví dụ sau đặt màu nền đặc cho master slide đầu tiên:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đối với các chủ đề liên quan, xem [Presentation Background](/slides/vi/java/presentation-background/) và [Presentation Theme](/slides/vi/java/presentation-theme/).

## **Sao chép Slide Master sang Bản Trình Bày Khác**

Sử dụng [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) để sao chép một master slide vào bản trình bày khác. Master đã sao chép sau đó có thể được sử dụng bởi các layout và slide trong bản đích.

```java
Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Nếu bạn cần sao chép các slide bình thường cùng với master của chúng, xem [Clone Slides](/slides/vi/java/clone-slides/).

## **Thêm Nhiều Slide Master**

Một bản trình bày có thể chứa nhiều master slide. Điều này hữu ích khi các phần khác nhau yêu cầu thương hiệu, cấu trúc trang hoặc cài đặt chủ đề khác nhau.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

Ví dụ sau sao chép master mặc định, đặt nền khác cho bản sao, tạo một layout dưới master đã sao chép, và thêm một slide mới dựa trên layout đó:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **So sánh Slide Masters**

Các master slide có thể được so sánh bằng phương thức `equals` kế thừa từ [IBaseSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseslide/). So sánh kiểm tra cấu trúc và nội dung tĩnh, như shape, văn bản, định dạng, hoạt ảnh và các cài đặt slide khác. Nó không so sánh các định danh duy nhất, như ID slide, hay các giá trị placeholder động, như ngày hiện tại.

```java
Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Để biết thêm thông tin, xem [So sánh Các Slide trong Bản Trình Bày](/slides/vi/java/compare-slides/).

## **Đặt Slide Master View làm Chế độ Xem Mặc Định**

Sử dụng phương thức `setLastView` trên [ViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/viewproperties/) để kiểm soát chế độ xem PowerPoint mở đầu tiên. Ví dụ sau mở bản trình bày ở chế độ Slide Master:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đối với các cài đặt chế độ xem khác, xem [Save Presentation](/slides/vi/java/save-presentation/).

## **Xóa các Master Slide Không Được Sử Dụng**

Đôi khi bản trình bày chứa các master slide không còn được bất kỳ slide bình thường nào sử dụng. Xóa các master không dùng có thể giảm kích thước tệp và đơn giản hóa việc bảo trì mẫu.

Sử dụng `removeUnused` để xóa các master không dùng khỏi bộ sưu tập `getMasters()`:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bạn cũng có thể dùng phương thức low-code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Sự khác nhau giữa slide master và layout slide là gì?**

Slide master xác định các cài đặt thiết kế chung như chủ đề, nền, hình dạng chung và kiểu văn bản. Layout slide thuộc về một master slide và xác định cách sắp xếp cụ thể của các placeholder. Slide bình thường sử dụng một layout slide, vì vậy nó kế thừa từ cả layout và master.

**Một bản trình bày có thể chứa nhiều slide master không?**

Có. Một bản trình bày có thể chứa nhiều slide master. Sử dụng nhiều master khi các phần khác nhau cần hệ thống hình ảnh hoặc thương hiệu khác nhau.

**Nên thêm placeholder vào master slide hay layout slide?**

Trong hầu hết các trường hợp, thêm placeholder vào layout slide. Đặt các yếu tố hình ảnh chung và định dạng chung trên master slide, sau đó đặt placeholder nội dung trên các layout mà slide bình thường sẽ sử dụng.

**Có thể xóa một master slide vẫn đang được sử dụng không?**

Không. Master slide có các slide phụ thuộc không thể bị xóa một cách an toàn. Trước tiên hãy chuyển các slide đó sang layout dưới master khác, hoặc dùng phương pháp dọn dẹp master không dùng chỉ xóa các master không có slide phụ thuộc.