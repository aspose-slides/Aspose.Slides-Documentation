---
title: Hiệu quả hợp nhất các bài thuyết trình trên Android
linktitle: Hợp nhất các bài thuyết trình
type: docs
weight: 40
url: /vi/androidjava/merge-presentation/
keywords:
- hợp nhất PowerPoint
- hợp nhất các bài thuyết trình
- hợp nhất các slide
- hợp nhất PPT
- hợp nhất PPTX
- hợp nhất ODP
- kết hợp PowerPoint
- kết hợp các bài thuyết trình
- kết hợp các slide
- kết hợp PPT
- kết hợp PPTX
- kết hợp ODP
- Android
- Java
- Aspose.Slides
description: "Dễ dàng hợp nhất các bài thuyết trình PowerPoint (PPT, PPTX) và OpenDocument (ODP) với Aspose.Slides cho Android qua Java, giúp tối ưu hoá quy trình làm việc của bạn."
---
## **Tổng quan**

Việc hợp nhất các bài thuyết trình PowerPoint và OpenDocument là một nhiệm vụ phổ biến trong nhiều ứng dụng Android, đặc biệt khi tạo báo cáo, tổng hợp các slide từ các nguồn khác nhau, hoặc tự động hoá quy trình trình chiếu. Aspose.Slides cung cấp một API mạnh mẽ và dễ sử dụng để kết hợp nhiều tệp PPT, PPTX hoặc ODP thành một bài thuyết trình duy nhất mà không cần cài đặt Microsoft PowerPoint, LibreOffice hay OpenOffice.

Trong hướng dẫn này, bạn sẽ học cách hợp nhất các bài thuyết trình PowerPoint và OpenDocument chỉ bằng vài dòng mã. Chúng tôi sẽ cung cấp các ví dụ sẵn sàng sử dụng, và chỉ ra cách bảo tồn định dạng slide, bố cục và các yếu tố khác của bài thuyết trình trong quá trình hợp nhất.

Dù bạn đang xây dựng một ứng dụng doanh nghiệp hay một công cụ tự động đơn giản, Aspose.Slides giúp việc hợp nhất các bài thuyết trình trở nên nhanh chóng, đáng tin cậy và mở rộng được. Aspose.Slides cho phép bạn hợp nhất các bài thuyết trình theo nhiều cách khác nhau. Bạn có thể kết hợp các bài thuyết trình với mọi hình dạng, kiểu dáng, văn bản, định dạng, bình luận, hoạt ảnh và hơn thế nữa—mà không lo mất chất lượng hay dữ liệu.

{{% alert color="info" %}}
Xem thêm: [Sao chép Trang chiếu](https://docs.aspose.com/slides/vi/androidjava/clone-slides/)
{{% /alert %}}

### **Những gì có thể được hợp nhất**

Với Aspose.Slides, bạn có thể hợp nhất 

* toàn bộ bài thuyết trình. Tất cả các slide từ các bài thuyết trình sẽ được đưa vào một bài thuyết trình duy nhất
* các slide cụ thể. Các slide đã chọn sẽ được đưa vào một bài thuyết trình duy nhất
* các bài thuyết trình ở một định dạng (PPT sang PPT, PPTX sang PPTX, v.v.) và ở các định dạng khác nhau (PPT sang PPTX, PPTX sang ODP, v.v.) với nhau. 

### **Các tùy chọn hợp nhất**

Bạn có thể áp dụng các tùy chọn xác định liệu

* mỗi slide trong bài thuyết trình đầu ra có giữ lại một phong cách riêng biệt
* một phong cách cụ thể được sử dụng cho tất cả các slide trong bài thuyết trình đầu ra. 

Để hợp nhất các bài thuyết trình, Aspose.Slides cung cấp các phương thức [AddClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (từ giao diện [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection)). Có một số triển khai của các phương thức `AddClone` xác định các tham số quá trình hợp nhất bài thuyết trình. Mỗi đối tượng Presentation đều có một bộ sưu tập [Slides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) nên bạn có thể gọi phương thức `AddClone` từ bài thuyết trình mà bạn muốn hợp nhất slide vào.

Phương thức `AddClone` trả về một đối tượng `ISlide`, là bản sao của slide nguồn. Các slide trong bài thuyết trình đầu ra chỉ là bản sao của các slide từ nguồn. Do đó, bạn có thể thay đổi các slide kết quả (ví dụ, áp dụng phong cách hoặc tùy chọn định dạng hoặc bố cục) mà không lo các bài thuyết trình nguồn bị ảnh hưởng. 

## **Hợp nhất các bài thuyết trình** 

Aspose.Slides cung cấp phương thức [**AddClone(ISlide)**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) cho phép bạn kết hợp các slide trong khi các slide vẫn giữ nguyên bố cục và phong cách (các tham số mặc định).

Đoạn mã Java này cho bạn thấy cách hợp nhất các bài thuyết trình:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Hợp nhất các bài thuyết trình với Slide Master**

Aspose.Slides cung cấp phương thức [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) cho phép bạn kết hợp các slide trong khi áp dụng mẫu Slide Master cho bài thuyết trình. Bằng cách này, nếu cần, bạn có thể thay đổi phong cách cho các slide trong bài thuyết trình đầu ra.

Đoạn mã Java sau minh họa hoạt động đã mô tả:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

{{% alert title="Lưu ý" color="warning" %}} 
Bố cục slide cho Slide Master được xác định tự động. Khi không thể xác định được bố cục phù hợp, nếu tham số boolean `allowCloneMissingLayout` của phương thức `AddClone` được đặt thành true, sẽ sử dụng bố cục của slide nguồn. Ngược lại, sẽ ném ra ngoại lệ [PptxEditException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/PptxEditException).
{{% /alert %}}

Nếu bạn muốn các slide trong bài thuyết trình đầu ra có một bố cục slide khác, hãy sử dụng phương thức [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) thay thế khi hợp nhất.

## **Hợp nhất các slide cụ thể từ các bài thuyết trình**

Hợp nhất các slide cụ thể từ nhiều bài thuyết trình rất hữu ích khi tạo bộ slide tùy chỉnh. Aspose.Slides for Android via Java cho phép bạn chọn và nhập chỉ các slide bạn cần. API bảo tồn định dạng, bố cục và thiết kế của các slide gốc.

Đoạn mã Java sau tạo một bài thuyết trình mới, thêm các slide tiêu đề từ hai bài thuyết trình khác, và lưu kết quả vào tệp:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);

    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```
```java
import com.aspose.slides.*;

static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **Hợp nhất các bài thuyết trình với Slide Layout**

Đoạn mã Java này cho bạn thấy cách kết hợp các slide từ các bài thuyết trình trong khi áp dụng bố cục slide ưa thích của bạn để tạo ra một bài thuyết trình đầu ra duy nhất:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **Hợp nhất các bài thuyết trình với kích thước slide khác nhau**

{{% alert title="Lưu ý" color="warning" %}} 
Bạn không thể hợp nhất các bài thuyết trình có kích thước slide khác nhau. 
{{% /alert %}}

Để hợp nhất 2 bài thuyết trình có kích thước slide khác nhau, bạn phải thay đổi kích thước của một trong các bài thuyết trình sao cho khớp với kích thước của bài thuyết trình còn lại. 

Đoạn mã mẫu dưới đây minh họa hoạt động đã mô tả:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Hợp nhất các slide vào một Section của bài thuyết trình**

Đoạn mã Java này cho bạn thấy cách hợp nhất một slide cụ thể vào một section trong bài thuyết trình:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

Slide sẽ được thêm vào cuối của section. 

{{% alert title="Mẹo" color="info" %}}
Aspose cung cấp một ứng dụng web [MIỄN PHÍ Collage](https://products.aspose.app/slides/vi/collage). Sử dụng dịch vụ trực tuyến này, bạn có thể hợp nhất [JPG sang JPG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG sang PNG, tạo [lưới ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), và nhiều hơn nữa. 
{{% /alert %}}

## **Câu hỏi thường gặp**

### Có giới hạn nào về số lượng slide khi hợp nhất các bài thuyết trình không?

Không có giới hạn nghiêm ngặt. Aspose.Slides có thể xử lý các tệp lớn, nhưng hiệu năng phụ thuộc vào kích thước và tài nguyên hệ thống. Đối với các bài thuyết trình rất lớn, nên sử dụng JVM 64-bit và cấp phát đủ bộ nhớ heap.

### Tôi có thể hợp nhất các bài thuyết trình có video hoặc âm thanh nhúng không?

Có, Aspose.Slides bảo tồn nội dung đa phương tiện nhúng trong các slide, nhưng bài thuyết trình cuối cùng có thể trở nên lớn đáng kể.

### Phông chữ có được bảo tồn khi hợp nhất các bài thuyết trình không?

Có. Các phông chữ được sử dụng trong các bài thuyết trình nguồn sẽ được bảo tồn trong tệp đầu ra, với điều kiện chúng đã được cài đặt trên hệ thống hoặc [được nhúng](/slides/vi/androidjava/embedded-font/).