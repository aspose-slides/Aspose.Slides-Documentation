---
title: Quản lý Slide Master của Bài thuyết trình trên Android
linktitle: Slide Master
type: docs
weight: 70
url: /vi/androidjava/slide-master/
keywords:
- slide master
- slide master
- slide master PPT
- nhiều slide master
- so sánh slide master
- nền
- placeholder
- sao chép slide master
- sao chép slide master
- nhân bản slide master
- slide master không sử dụng
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Quản lý slide master trong Aspose.Slides cho Android via Java: truy cập, chỉnh sửa, sao chép, so sánh và xóa slide master trong các bài thuyết trình PowerPoint và OpenDocument."
---
## **Tổng quan**

Một **slide master** định nghĩa các thiết lập thiết kế chung cho một nhóm slide. Nó có thể chứa các hình dạng chung, logo, nền, kiểu chữ, thiết lập chủ đề và thiết lập chân trang. Trong PowerPoint, việc chỉnh sửa slide master là cách thông thường để duy trì tính nhất quán của bài thuyết trình mà không cần lặp lại cùng một định dạng trên mỗi slide.

Aspose.Slides for Android via Java hỗ trợ cùng mô hình này. Một bài thuyết trình có thể chứa một hoặc nhiều slide master, và mỗi slide master có thể chứa một số slide layout. Các slide bình thường thường không tham chiếu trực tiếp tới slide master. Thay vào đó, một slide bình thường sử dụng một layout slide, và layout slide đó thuộc về một slide master.

Cấu trúc phân cấp như sau:

1. **Slide master** – định nghĩa thiết kế và chủ đề chung.
1. **Layout slide** – định nghĩa một bố cục cụ thể của các placeholder và định dạng cấp layout.
1. **Normal slide** – chứa nội dung thực tế của bài thuyết trình và sử dụng một layout slide.

![Cấu trúc phân cấp của slide master, layout slide và normal slide](slide-master_2.jpg)

Trong Aspose.Slides, một slide master được đại diện bởi giao diện [IMasterSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslide/). Tất cả các slide master trong một bài thuyết trình có thể truy cập qua bộ sưu tập [Presentation.getMasters](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getMasters--) , bộ sưu tập này thực thi [IMasterSlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslidecollection/). Để xem toàn bộ API Android via Java, xem tham chiếu API [com.aspose.slides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/).

{{% alert color="info" title="Kế thừa" %}}
Khi cùng một thuộc tính được định nghĩa ở nhiều cấp độ, cấp độ cụ thể hơn sẽ thắng. Ví dụ, nếu một slide master và một layout slide đều định nghĩa nền, các slide dựa trên layout đó sẽ sử dụng nền của layout. Để biết thêm thông tin về layout slide, xem [Áp dụng hoặc Thay đổi Layout Slide](/slides/vi/androidjava/slide-layout/).
{{% /alert %}}

## **Truy cập Slide Master**

Trong PowerPoint, bạn có thể mở chế độ xem Slide Master từ **View** > **Slide Master**.

![Lệnh Slide Master trên tab View của PowerPoint](slide-master_3.jpg)

Trong Aspose.Slides, sử dụng bộ sưu tập `getMasters()` để truy cập các slide master:

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

Bạn cũng có thể lấy slide master được sử dụng bởi một slide bình thường thông qua layout của nó:

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

Slide master là một đối tượng dạng slide. Nó thực thi [IBaseSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibaseslide/), vì vậy nó cung cấp nhiều thuộc tính slide giống như slide bình thường và layout.

Các thành viên thường dùng của slide master bao gồm:

| Thành viên | Mục đích |
| --- | --- |
| `getBackground()` | Đặt nền slide ở mức master. |
| `getShapes()` | Lưu trữ các hình dạng trên master, chẳng hạn như logo, khung ảnh và văn bản chia sẻ. |
| `getLayoutSlides()` | Lưu trữ các layout slide thuộc master. |
| `getThemeManager()` | Cung cấp quyền truy cập vào các API chủ đề của master. |
| `getHeaderFooterManager()` | Kiểm soát header, footer, ngày tháng và số slide cho master và các layout con. |
| `getDependingSlides()` | Trả về các slide bình thường phụ thuộc vào master thông qua layout của chúng. |

## **Thêm hình ảnh vào Slide Master**

Khi bạn thêm hình ảnh vào một slide master, nó sẽ xuất hiện trên các slide sử dụng layout từ master đó. Điều này hữu ích cho logo, hình mờ, dải trang trí và các yếu tố hình ảnh lặp lại khác.

Ví dụ dưới đây thêm một logo vào slide master đầu tiên:

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

Để biết thêm thông tin về khung ảnh, xem [Khung hình](/slides/vi/androidjava/picture-frame/).

## **Làm việc với Placeholder**

Placeholder thường được định nghĩa trên layout slide. Slide master cung cấp kiểu dáng và chủ đề chung mà các layout này kế thừa, trong khi mỗi layout quyết định placeholder nào có sẵn và chúng được đặt ở đâu.

Trong PowerPoint, các lệnh placeholder có sẵn trong chế độ xem Slide Master.

![Lệnh Insert Placeholder trong chế độ Slide Master của PowerPoint](slide-master_5.png)

Để thêm placeholder mới với Aspose.Slides, làm việc với layout slide thuộc master:

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

Bạn cũng có thể định dạng các shape placeholder đã tồn tại trên slide master. Ví dụ dưới đây tìm placeholder tiêu đề và áp dụng một màu nền gradient tuyến tính:

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
        int redGradientColor = Color.valueOf(255, 0, 0).toArgb();
        int purpleGradientColor = Color.valueOf(128, 0, 128).toArgb();

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Placeholder tiêu đề đã định dạng kế thừa bởi các slide bình thường](slide-master_8.png)

Để biết thêm các tùy chọn định dạng placeholder và văn bản, xem [Đặt văn bản gợi ý trong Placeholder](/slides/vi/androidjava/manage-placeholder/) và [Định dạng văn bản](/slides/vi/androidjava/text-formatting/).

## **Thay đổi nền Slide Master**

Nền master được kế thừa bởi các layout và slide nếu không có override. Ví dụ dưới đây đặt màu nền đặc cho slide master đầu tiên:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    int masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đối với các chủ đề liên quan, xem [Nền Bài thuyết trình](/slides/vi/androidjava/presentation-background/) và [Chủ đề Bài thuyết trình](/slides/vi/androidjava/presentation-theme/).

## **Sao chép Slide Master sang Bài thuyết trình khác**

Sử dụng [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) để sao chép một slide master vào một bài thuyết trình khác. Slide master đã sao chép sau đó có thể được sử dụng bởi các layout và slide trong bài thuyết trình đích.

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

Nếu bạn cần sao chép các slide bình thường cùng với master của chúng, xem [Sao chép Slide](/slides/vi/androidjava/clone-slides/).

## **Thêm nhiều Slide Master**

Một bài thuyết trình có thể chứa nhiều slide master. Điều này hữu ích khi các phần khác nhau yêu cầu thương hiệu, cấu trúc trang hoặc thiết lập chủ đề riêng.

![Các lệnh PowerPoint để chèn và quản lý slide master](slide-master_9.jpg)

Ví dụ dưới đây sao chép master mặc định, đặt nền khác cho bản sao, tạo một layout dưới master đã sao chép, và thêm một slide mới dựa trên layout đó:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    int sectionMasterBackgroundColor = Color.GRAY;

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

## **So sánh Slide Master**

Slide master có thể được so sánh bằng phương thức `equals` được kế thừa từ [IBaseSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibaseslide/). So sánh kiểm tra cấu trúc và nội dung tĩnh, chẳng hạn như shape, văn bản, định dạng, hoạt ảnh và các thiết lập slide khác. Nó không so sánh các định danh duy nhất như ID slide, hay giá trị placeholder động như ngày hiện tại.

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

Để biết thêm thông tin, xem [So sánh Slide trong Bài thuyết trình](/slides/vi/androidjava/compare-slides/).

## **Đặt chế độ Slide Master làm chế độ xem mặc định**

Sử dụng phương thức `setLastView` trên [ViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/viewproperties/) để kiểm soát chế độ mà PowerPoint mở đầu tiên. Ví dụ dưới đây mở bài thuyết trình trong chế độ Slide Master:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để biết thêm các thiết lập chế độ xem, xem [Lưu Bài thuyết trình](/slides/vi/androidjava/save-presentation/).

## **Xóa các Slide Master không sử dụng**

Đôi khi một bài thuyết trình chứa các slide master không còn được bất kỳ slide bình thường nào sử dụng. Xóa các master không dùng có thể giảm kích thước file và đơn giản hóa việc bảo trì mẫu.

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

Bạn cũng có thể dùng phương thức low-code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Sự khác nhau giữa slide master và layout slide là gì?**  
Slide master định nghĩa các thiết lập thiết kế chung như chủ đề, nền, hình dạng chung và kiểu chữ. Layout slide thuộc về một slide master và định nghĩa một bố cục cụ thể của các placeholder. Slide bình thường sử dụng một layout slide, vì vậy nó kế thừa từ cả layout và master.

**Một bài thuyết trình có thể chứa nhiều slide master không?**  
Có. Một bài thuyết trình có thể chứa nhiều slide master. Sử dụng nhiều master khi các phần khác nhau cần hệ thống hình ảnh hoặc thương hiệu khác nhau.

**Nên thêm placeholder vào slide master hay layout slide?**  
Trong hầu hết các trường hợp, thêm placeholder vào layout slide. Đặt các yếu tố hình ảnh chung và định dạng chung trên slide master, sau đó đặt placeholder nội dung trên các layout mà slide bình thường sẽ dùng.

**Có thể xóa một slide master đang được sử dụng không?**  
Không. Slide master có các slide phụ thuộc không thể bị xóa trực tiếp một cách an toàn. Đầu tiên chuyển các slide đó sang layout dưới một master khác, hoặc sử dụng phương pháp dọn dẹp master không dùng để chỉ xóa các master không còn được sử dụng.