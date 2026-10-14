---
title: Chuyển đổi các slide PowerPoint sang PNG trong Java
linktitle: PowerPoint sang PNG
type: docs
weight: 30
url: /vi/java/convert-powerpoint-to-png/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PNG
- bản trình chiếu sang PNG
- slide sang PNG
- PPT sang PNG
- PPTX sang PNG
- lưu PPT dưới dạng PNG
- lưu PPTX dưới dạng PNG
- xuất PPT sang PNG
- xuất PPTX sang PNG
- Java
- Aspose.Slides
description: "Chuyển đổi các bản trình chiếu PowerPoint sang hình ảnh PNG chất lượng cao một cách nhanh chóng với Aspose.Slides cho Java, đảm bảo kết quả chính xác và tự động."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi các slide bài thuyết trình thành hình ảnh PNG bằng Aspose.Slides cho Java. Bạn có thể tải các bản trình chiếu ở các định dạng như PPT, PPTX và ODP, render mỗi slide và lưu chúng dưới dạng các tệp PNG riêng biệt.

Các ví dụ bên dưới minh họa việc render ở tỉ lệ mặc định, tăng tỉ lệ, chỉ định kích thước đầu ra bằng pixel và chọn kiểu render gradient.

## **Chuyển đổi PowerPoint sang PNG**

Tải một bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) và truy cập các slide của nó thông qua bộ sưu tập [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) . Ví dụ này render mỗi slide bằng [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) không có tham số để tạo thumbnail. Sau đó gọi [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) với [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/#Png) để lưu mỗi slide đã render dưới dạng hình ảnh PNG.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Phiên bản overload không có tham số của [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) render ở tỉ lệ 0.2. Ví dụ, một slide có kích thước 720 × 540 point sẽ tạo ra thumbnail 144 × 108 pixel. Để kiểm soát kích thước đầu ra, hãy sử dụng các overload với hệ số tỉ lệ hoặc kích thước hình ảnh rõ ràng như dưới đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Truyền các hệ số tỉ lệ ngang và dọc vào [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-float-float-) để kiểm soát kích thước render. Trong ví dụ này, cả hai hệ số đều bằng 2, vì vậy một slide có kích thước 720 × 540 point sẽ tạo ra hình ảnh 1440 × 1080 pixel. Các hệ số tỉ lệ bằng nhau giữ tỷ lệ khung hình của slide. Mỗi hình ảnh được lưu ở định dạng PNG bằng [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    float scaleX = 2f;
    float scaleY = scaleX;

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tuỳ chỉnh**

Để chỉ định kích thước đầu ra tính bằng pixel, truyền một kích thước vào [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) thay vì các hệ số tỉ lệ. Ví dụ này render mỗi slide ở kích thước 960 × 720 pixel và lưu kết quả bằng [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-). Hãy chọn kích thước phù hợp với tỷ lệ khung hình của slide để tránh kéo giãn hình ảnh.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Dimension imageSize = new Dimension(960, 720);

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Chọn Kiểu Render Gradient**

Giả sử một slide chứa các vùng tô gradient, nhưng các chuyển đổi trong PNG xuất ra trông sáng hơn hoặc khác so với khi bạn xem trong PowerPoint. Bạn có thể sử dụng phương thức [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setGradientStyle-int-) được kế thừa bởi [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/) để chọn cách render gradient.

Tải xuống [gradient-styles.pptx](gradient-styles.pptx) và đặt nó vào thư mục làm việc của ứng dụng. Slide đầu tiên của nó chứa hai gradient tuyến tính: từ cyan sang cam ở trên và từ xanh sang vàng ở dưới. Mỗi gradient có hai điểm dừng, ở 0% và 100%.

Ví dụ sau tải bản trình chiếu này và render slide đầu tiên trong cả hai chế độ bằng [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("gradient-styles.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] gradientStyles = { GradientStyle.Default, GradientStyle.PowerPointUI };
    for (int style : gradientStyles) {
        RenderingOptions options = new RenderingOptions();
        options.setGradientStyle(style);

        String styleName = style == GradientStyle.Default ? "Default" : "PowerPointUI";
        IImage image = slide.getImage(options, 1f, 1f);
        try {
            image.save("gradient-" + styleName + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Các hình ảnh dưới đây hiển thị kết quả từ cùng một slide, với cả hai gradient trong mỗi hình:

| Default | PowerPointUI |
| --- | --- |
| ![Gradient từ cyan sang cam và từ xanh sang vàng được render bằng Default](gradient-Default.png) | ![Các gradient tương tự được render bằng PowerPointUI](gradient-PowerPointUI.png) |

Trong ví dụ này, `Default` tạo ra các màu trung gian sáng hơn, trong khi `PowerPointUI` tạo ra các màu trung gian tối hơn. Sự khác biệt phụ thuộc vào màu sắc và các điểm dừng trong gradient.

Chọn `Default` khi đầu ra tiêu chuẩn của Aspose.Slides đáp ứng nhu cầu của bạn. Thử `PowerPointUI` khi ưu tiên của bạn là khớp với giao diện trong PowerPoint. So sánh cả hai kết quả với mục tiêu của bạn; không chế độ nào là tốt nhất cho mọi trường hợp.

## **Câu hỏi thường gặp**

**Làm thế nào để xuất một hình dạng cụ thể, chẳng hạn biểu đồ hoặc hình ảnh, thay vì toàn bộ slide?**

Aspose.Slides hỗ trợ [tạo thumbnail cho các hình dạng riêng lẻ](/slides/vi/java/create-shape-thumbnails/), cho phép bạn render một hình dạng dưới dạng hình ảnh PNG.

**Việc chuyển đổi song song có được hỗ trợ trên máy chủ không?**

Có. Sử dụng một thể hiện presentation riêng cho mỗi luồng hoặc tiến trình; [không chia sẻ một thể hiện duy nhất giữa các luồng](/slides/vi/java/multithreading/).

**Các hạn chế của bản đánh giá khi xuất sang PNG là gì?**

Chế độ đánh giá sẽ thêm watermark vào hình ảnh đầu ra và áp dụng [các hạn chế khác](/slides/vi/java/licensing/) cho đến khi có giấy phép.