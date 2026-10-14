---
title: Chuyển đổi slide PowerPoint sang PNG trên Android
linktitle: PowerPoint sang PNG
type: docs
weight: 30
url: /vi/androidjava/convert-powerpoint-to-png/
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
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi các bản trình chiếu PowerPoint thành hình ảnh PNG chất lượng cao một cách nhanh chóng với Aspose.Slides cho Android qua Java, đảm bảo kết quả chính xác và tự động."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển các slide trình chiếu thành hình ảnh PNG bằng Aspose.Slides cho Android thông qua Java. Bạn có thể tải các bản trình chiếu ở các định dạng như PPT, PPTX và ODP, render mỗi slide và lưu nó dưới dạng một hình ảnh PNG riêng biệt.

Các ví dụ bên dưới minh họa việc render với tỷ lệ mặc định, tăng tỷ lệ, chỉ định kích thước đầu ra bằng pixel và lựa chọn kiểu render gradient.

## **Chuyển đổi PowerPoint sang PNG**

Tải một bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) và truy cập các slide của nó thông qua bộ sưu tập [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) . Ví dụ này render mọi slide bằng [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) không có tham số để tạo thumbnail. Sau đó nó gọi [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) với [ImageFormat.Png](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/#Png) để lưu mỗi slide đã render dưới dạng hình ảnh PNG.

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
Phiên bản không có tham số của [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) trả về với tỷ lệ 0.2. Ví dụ, một slide có kích thước 720 × 540 point sẽ tạo ra một thumbnail 144 × 108 pixel. Để kiểm soát kích thước đầu ra, hãy sử dụng các overload với hệ số tỷ lệ hoặc kích thước ảnh rõ ràng như dưới đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Truyền hệ số tỷ lệ chiều ngang và chiều dọc vào [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) để kiểm soát kích thước render. Trong ví dụ này, cả hai hệ số đều là 2, vì vậy một slide có kích thước 720 × 540 point sẽ tạo ra hình ảnh 1440 × 1080 pixel. Các hệ số tỷ lệ bằng nhau giữ nguyên tỷ lệ khung hình của slide. Mỗi hình ảnh được lưu ở định dạng PNG bằng [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-).

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

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Để chỉ định kích thước đầu ra bằng pixel, truyền một đối tượng kích thước vào [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) thay vì các hệ số tỷ lệ. Ví dụ này render mọi slide ở kích thước 960 × 720 pixel và lưu kết quả bằng [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Chọn kích thước phù hợp với tỷ lệ khung hình của slide để tránh kéo dài hình ảnh.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Size imageSize = new Size(960, 720);

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

Giả sử một slide chứa các vùng màu gradient, nhưng các chuyển đổi trong PNG xuất ra trông nhẹ hơn hoặc khác so với những gì bạn thấy trong PowerPoint. Bạn có thể dùng phương thức [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setGradientStyle-int-) được kế thừa bởi [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/) để lựa chọn cách render gradient.

Tải xuống [gradient-styles.pptx](gradient-styles.pptx) và đặt nó vào thư mục làm việc của ứng dụng. Slide đầu tiên của nó chứa hai gradient tuyến tính: cyan sang orange ở trên và blue sang yellow ở dưới. Mỗi gradient có hai điểm dừng, ở 0% và 100%.

Ví dụ dưới đây tải bản trình chiếu này và render slide đầu tiên trong cả hai chế độ bằng [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-).

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

| Mặc định | PowerPointUI |
| --- | --- |
| ![Các gradient cyan-to-orange và blue-to-yellow được render với Default](gradient-Default.png) | ![Các gradient tương tự được render với PowerPointUI](gradient-PowerPointUI.png) |

Trong ví dụ này, `Default` tạo ra các màu trung gian nhẹ hơn, trong khi `PowerPointUI` tạo ra các màu trung gian tối hơn. Sự khác nhau phụ thuộc vào màu sắc và các điểm dừng trong gradient.

Chọn `Default` khi đầu ra tiêu chuẩn của Aspose.Slides đáp ứng nhu cầu của bạn. Thử `PowerPointUI` khi ưu tiên của bạn là khớp với giao diện trong PowerPoint. So sánh cả hai đầu ra với kết quả mong muốn; không có chế độ nào là tốt hơn cho mọi trường hợp.

## **Câu hỏi thường gặp**

**Làm sao tôi có thể xuất một hình dạng cụ thể, chẳng hạn biểu đồ hoặc hình ảnh, thay vì toàn bộ slide?**

Aspose.Slides hỗ trợ [tạo thumbnail cho các hình dạng riêng lẻ](/slides/vi/androidjava/create-shape-thumbnails/), cho phép bạn render một hình dạng dưới dạng hình ảnh PNG.

**Có hỗ trợ chuyển đổi song song trên máy chủ không?**

Có. Sử dụng một thể hiện presentation riêng biệt cho mỗi luồng hoặc tiến trình; [không chia sẻ một thể hiện duy nhất giữa các luồng](/slides/vi/androidjava/multithreading/).

**Các hạn chế của chế độ dùng thử khi xuất ra PNG là gì?**

Chế độ dùng thử sẽ thêm watermark vào các hình ảnh đầu ra và áp dụng [các hạn chế khác](/slides/vi/androidjava/licensing/) cho đến khi có giấy phép.