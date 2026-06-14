---
title: Hợp nhất các bản trình chiếu một cách hiệu quả trên Android
linktitle: Hợp nhất các bản trình chiếu
type: docs
weight: 40
url: /vi/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Dễ dàng hợp nhất các bản trình chiếu PowerPoint (PPT, PPTX) và OpenDocument (ODP) với Aspose.Slides cho Android qua Java, giúp tối ưu hoá quy trình làm việc của bạn."
---
## **Tổng quan**

Việc hợp nhất các bản trình chiếu PowerPoint và OpenDocument là một nhiệm vụ phổ biến trong nhiều ứng dụng Android, đặc biệt khi tạo báo cáo, tổng hợp slide từ các nguồn khác nhau, hoặc tự động hoá quy trình trình chiếu. Aspose.Slides cung cấp một API mạnh mẽ và dễ sử dụng để kết hợp nhiều tệp PPT, PPTX hoặc ODP thành một bản trình chiếu duy nhất mà không cần cài đặt Microsoft PowerPoint, LibreOffice hay OpenOffice.

Trong hướng dẫn này, bạn sẽ học cách hợp nhất các bản trình chiếu PowerPoint và OpenDocument chỉ với vài dòng mã. Chúng tôi sẽ cung cấp các ví dụ sẵn sàng sử dụng và chỉ ra cách bảo tồn định dạng slide, bố cục và các yếu tố trình chiếu khác trong quá trình hợp nhất.

Dù bạn đang xây dựng một ứng dụng doanh nghiệp hay một công cụ tự động đơn giản, Aspose.Slides giúp việc hợp nhất bản trình chiếu nhanh chóng, tin cậy và mở rộng được. Aspose.Slides cho phép bạn hợp nhất bản trình chiếu theo nhiều cách khác nhau. Bạn có thể kết hợp các bản trình chiếu với tất cả các hình dạng, kiểu dáng, văn bản, định dạng, chú thích, hoạt ảnh và hơn thế nữa—mà không lo mất chất lượng hay dữ liệu.

{{% alert color="primary" %}}
Xem thêm: [Sao chép Slide](https://docs.aspose.com/slides/vi/androidjava/clone-slides/)
{{% /alert %}}

### **Các yếu tố có thể hợp nhất**

Với Aspose.Slides, bạn có thể hợp nhất 

* toàn bộ bản trình chiếu. Tất cả các slide từ các bản trình chiếu sẽ được gộp vào một bản trình chiếu duy nhất
* các slide cụ thể. Các slide đã chọn sẽ được gộp vào một bản trình chiếu duy nhất
* các bản trình chiếu ở cùng một định dạng (PPT sang PPT, PPTX sang PPTX, v.v.) và ở các định dạng khác nhau (PPT sang PPTX, PPTX sang ODP, v.v.) vào nhau. 

### **Tùy chọn hợp nhất**

Bạn có thể áp dụng các tùy chọn xác định liệu

* mỗi slide trong bản trình chiếu kết quả có giữ phong cách độc đáo riêng
* một phong cách cụ thể được áp dụng cho tất cả các slide trong bản trình chiếu kết quả. 

Để hợp nhất các bản trình chiếu, Aspose.Slides cung cấp các phương thức [AddClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (từ giao diện [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection)). Có một số triển khai của các phương thức `AddClone` xác định các tham số quy trình hợp nhất bản trình chiếu. Mỗi đối tượng Presentation đều có một bộ sưu tập [Slides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) nên bạn có thể gọi phương thức `AddClone` từ bản trình chiếu mà bạn muốn hợp nhất slide vào.

Phương thức `AddClone` trả về một đối tượng `ISlide`, là bản sao của slide nguồn. Các slide trong bản trình chiếu đầu ra chỉ là bản sao của các slide từ nguồn. Do đó, bạn có thể thay đổi các slide kết quả (ví dụ: áp dụng phong cách, tùy chọn định dạng hoặc bố cục) mà không lo ảnh hưởng tới bản trình chiếu nguồn.

## **Hợp nhất Bản trình chiếu** 

Aspose.Slides cung cấp phương thức [**AddClone(ISlide)**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) cho phép bạn kết hợp các slide trong khi chúng giữ nguyên bố cục và phong cách (các tham số mặc định).

Mã Java này cho thấy cách hợp nhất các bản trình chiếu:

```java
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

## **Hợp nhất Bản trình chiếu với Master Slide** 

Aspose.Slides cung cấp phương thức [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) cho phép bạn kết hợp các slide đồng thời áp dụng mẫu master slide của bản trình chiếu. Nhờ đó, nếu cần, bạn có thể thay đổi phong cách cho các slide trong bản trình chiếu đầu ra.

Mã Java dưới đây minh hoạ thao tác đã mô tả:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
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
Bố cục slide cho master slide được xác định tự động. Khi không thể xác định được bố cục phù hợp, nếu tham số boolean `allowCloneMissingLayout` của phương thức `AddClone` được đặt thành true, sẽ sử dụng bố cục của slide nguồn. Ngược lại, sẽ ném ra ngoại lệ [PptxEditException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/PptxEditException).
{{% /alert %}}

Nếu bạn muốn các slide trong bản trình chiếu đầu ra có bố cục slide khác, hãy sử dụng phương thức [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) thay thế khi hợp nhất.

## **Hợp nhất Các Slide Cụ Thể Từ Nhiều Bản Trình Chiếu** 

Hợp nhất các slide cụ thể từ nhiều bản trình chiếu rất hữu ích cho việc tạo các bộ slide tùy chỉnh. Aspose.Slides for Android via Java cho phép bạn chọn và nhập chỉ những slide cần thiết. API bảo tồn định dạng, bố cục và thiết kế của các slide gốc.

Mã Java sau tạo một bản trình chiếu mới, thêm các slide tiêu đề từ hai bản trình chiếu khác, và lưu kết quả vào tệp:

```java
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
static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **Hợp nhất Bản Trình Chiếu với Bố Cục Slide** 

Mã Java này cho thấy cách kết hợp các slide từ các bản trình chiếu đồng thời áp dụng bố cục slide ưa thích của bạn để tạo một bản trình chiếu đầu ra:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **Hợp nhất Bản Trình Chiếu với Các Kích Thước Slide Khác Nhau** 

{{% alert title="Lưu ý" color="warning" %}} 
Bạn không thể hợp nhất các bản trình chiếu có kích thước slide khác nhau. 
{{% /alert %}}

Để hợp nhất 2 bản trình chiếu có kích thước slide khác nhau, bạn phải thay đổi kích thước của một bản trình chiếu sao cho khớp với kích thước của bản trình chiếu còn lại. 

Mã mẫu dưới đây minh hoạ thao tác đã mô tả:

```java
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

## **Hợp nhất Slide vào Một Phần Của Bản Trình Chiếu** 

Mã Java này cho thấy cách hợp nhất một slide cụ thể vào một phần (section) trong bản trình chiếu:

```java
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

Slide sẽ được thêm vào cuối phần.

{{% alert title="Mẹo" color="primary" %}}
Aspose cung cấp một [ứng dụng web Collage MIỄN PHÍ](https://products.aspose.app/slides/vi/collage). Sử dụng dịch vụ trực tuyến này, bạn có thể hợp nhất [JPG sang JPG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG sang PNG, tạo [lưới ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), và nhiều hơn nữa. 
{{% /alert %}}

## **Câu hỏi thường gặp** 

**Có giới hạn nào về số slide khi hợp nhất bản trình chiếu không?**  

Không có giới hạn nghiêm ngặt. Aspose.Slides có thể xử lý các tệp lớn, nhưng hiệu năng phụ thuộc vào kích thước và tài nguyên hệ thống. Đối với các bản trình chiếu rất lớn, nên sử dụng JVM 64‑bit và cấp phát đủ bộ nhớ heap.

**Tôi có thể hợp nhất các bản trình chiếu có video hoặc audio nhúng không?**  

Có, Aspose.Slides bảo tồn nội dung đa phương tiện nhúng trong slide, tuy nhiên bản trình chiếu cuối cùng có thể trở nên khá lớn.

**Phông chữ có được bảo tồn khi hợp nhất bản trình chiếu không?**  

Có. Các phông chữ được sử dụng trong bản trình chiếu nguồn sẽ được bảo tồn trong tệp đầu ra, với điều kiện chúng được cài đặt trên hệ thống hoặc [được nhúng](/slides/vi/androidjava/embedded-font/).