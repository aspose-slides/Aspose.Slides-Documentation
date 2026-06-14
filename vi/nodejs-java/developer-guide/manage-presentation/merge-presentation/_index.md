---
title: Hiệu quả hợp nhất các bản trình chiếu trong JavaScript
linktitle: Hợp nhất các bản trình chiếu
type: docs
weight: 40
url: /vi/nodejs-java/merge-presentation/
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
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Dễ dàng hợp nhất các bản trình chiếu PowerPoint (PPT, PPTX) và OpenDocument (ODP) trong JavaScript bằng Aspose.Slides cho Node.js, giúp tối ưu hoá quy trình làm việc của bạn."
---
## **Tổng quan**

Aspose.Slides cho phép bạn hợp nhất các bản trình chiếu bằng cách sao chép các slide từ một bản trình chiếu sang bản khác. Bài viết này giải thích cách hợp nhất toàn bộ bản trình chiếu hoặc các slide đã chọn, sử dụng slide master hoặc bố cục cụ thể trong quá trình hợp nhất, xử lý các bản trình chiếu có kích thước slide khác nhau, và thêm các slide đã hợp nhất vào một phần của bản trình chiếu. Nó cũng đề cập đến các lưu ý thực tế liên quan đến nội dung đã hợp nhất, bao gồm ghi chú người thuyết trình, bình luận, tệp nguồn được bảo mật bằng mật khẩu, và việc sử dụng đa luồng.

## **Hợp nhất bản trình chiếu**

Khi bạn hợp nhất một bản trình chiếu vào bản khác, bạn thực chất đang kết hợp các slide của chúng trong một bản trình chiếu duy nhất để có được một tệp.

{{% alert title="Info" color="info" %}}

Hầu hết các chương trình trình chiếu (PowerPoint hoặc OpenOffice) thiếu chức năng cho phép người dùng kết hợp các bản trình chiếu theo cách này.

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/vi/nodejs-java/), tuy nhiên, cho phép bạn hợp nhất các bản trình chiếu theo nhiều cách khác nhau. Bạn có thể hợp nhất các bản trình chiếu với tất cả các hình dạng, kiểu dáng, văn bản, định dạng, bình luận, hoạt ảnh, v.v. mà không phải lo lắng về mất chất lượng hoặc dữ liệu.

**Xem thêm**

[Clone Slides](https://docs.aspose.com/slides/vi/nodejs-java/clone-slides/).

{{% /alert %}}

### **Những gì có thể được hợp nhất**

Với Aspose.Slides, bạn có thể hợp nhất

* toàn bộ bản trình chiếu. Tất cả các slide từ các bản trình chiếu sẽ nằm trong một bản trình chiếu
* các slide cụ thể. Các slide đã chọn sẽ nằm trong một bản trình chiếu
* các bản trình chiếu ở cùng một định dạng (PPT sang PPT, PPTX sang PPTX, v.v.) và ở các định dạng khác nhau (PPT sang PPTX, PPTX sang ODP, v.v.) với nhau.

### **Các tùy chọn hợp nhất**

Bạn có thể áp dụng các tùy chọn xác định liệu

* mỗi slide trong bản trình chiếu đầu ra có giữ lại kiểu riêng biệt
* một kiểu cụ thể được sử dụng cho tất cả các slide trong bản trình chiếu đầu ra.

Để hợp nhất các bản trình chiếu, Aspose.Slides cung cấp các phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) (từ lớp [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection)). Có một số triển khai của các phương thức `addClone` xác định các tham số quá trình hợp nhất bản trình chiếu. Mỗi đối tượng Presentation có một bộ sưu tập [Slides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) nên bạn có thể gọi phương thức `addClone` từ bản trình chiếu mà bạn muốn hợp nhất các slide vào.

Phương thức `addClone` trả về một đối tượng `Slide`, là bản sao của slide nguồn. Các slide trong bản trình chiếu đầu ra chỉ là bản sao của các slide từ nguồn. Do đó, bạn có thể thay đổi các slide kết quả (ví dụ: áp dụng kiểu hoặc tùy chọn định dạng hoặc bố cục) mà không lo ảnh hưởng đến các bản trình chiếu nguồn.

## **Hợp nhất các bản trình chiếu**

Aspose.Slides cung cấp phương thức [**AddClone(ISlide)**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) cho phép bạn kết hợp các slide trong khi các slide giữ nguyên bố cục và kiểu dáng (tham số mặc định).

Đoạn mã JavaScript sau cho thấy cách hợp nhất các bản trình chiếu:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Hợp nhất các bản trình chiếu với Slide Master**

Aspose.Slides cung cấp phương thức [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) cho phép bạn kết hợp các slide đồng thời áp dụng mẫu slide master. Nhờ đó, nếu cần, bạn có thể thay đổi kiểu cho các slide trong bản trình chiếu đầu ra.

Đoạn mã JavaScript dưới đây minh họa hoạt động đã mô tả:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 

Bố cục slide cho slide master được xác định tự động. Khi không thể xác định được bố cục phù hợp, nếu tham số boolean `allowCloneMissingLayout` của phương thức `addClone` được đặt thành true, bố cục của slide nguồn sẽ được sử dụng. Ngược lại, sẽ ném ra ngoại lệ [PptxEditException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PptxEditException).

{{% /alert %}}

Nếu bạn muốn các slide trong bản trình chiếu đầu ra có một bố cục slide khác, hãy sử dụng phương thức [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) thay thế khi hợp nhất.

## **Hợp nhất các slide cụ thể từ các bản trình chiếu**

Hợp nhất các slide cụ thể từ nhiều bản trình chiếu rất hữu ích để tạo ra các bộ slide tùy chỉnh. Aspose.Slides for Node.js via Java cho phép bạn chọn và nhập chỉ những slide bạn cần. API giữ nguyên định dạng, bố cục và thiết kế của các slide gốc.

Đoạn mã JavaScript sau tạo một bản trình chiếu mới, thêm các slide tiêu đề từ hai bản trình chiếu khác, và lưu kết quả vào một tệp:

```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```
```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

## **Hợp nhất các bản trình chiếu với Slide Layout**

Đoạn mã JavaScript này cho thấy cách kết hợp các slide từ các bản trình chiếu trong khi áp dụng bố cục slide ưa thích của bạn để tạo ra một bản trình chiếu đầu ra:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Hợp nhất các bản trình chiếu với kích thước slide khác nhau**

{{% alert title="Note" color="warning" %}} 

Bạn không thể hợp nhất các bản trình chiếu có kích thước slide khác nhau.

{{% /alert %}}

Để hợp nhất 2 bản trình chiếu có kích thước slide khác nhau, bạn phải thay đổi kích thước của một bản trình chiếu sao cho khớp với kích thước của bản trình chiếu còn lại.

Đoạn mã mẫu dưới đây minh họa thao tác đã mô tả:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Hợp nhất các slide vào phần của bản trình chiếu**

Đoạn mã JavaScript này cho thấy cách hợp nhất một slide cụ thể vào một phần trong bản trình chiếu:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

Slide được thêm vào cuối phần.

## **Câu hỏi thường gặp**

**Ghi chú người thuyết trình có được giữ lại khi hợp nhất không?**

Có. Khi sao chép slide, Aspose.Slides chuyển sang tất cả các yếu tố của slide, bao gồm ghi chú, định dạng và hoạt ảnh.

**Bình luận và tác giả của chúng có được chuyển không?**

Bình luận, như một phần nội dung slide, được sao chép cùng slide. Nhãn tác giả bình luận được giữ lại dưới dạng đối tượng bình luận trong bản trình chiếu kết quả.

**Nếu bản trình chiếu nguồn được bảo mật bằng mật khẩu thì sao?**

Phải [mở bằng mật khẩu](/slides/vi/nodejs-java/password-protected-presentation/) thông qua [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/setpassword/); sau khi tải, các slide đó có thể được sao chép an toàn vào tệp đích không bảo mật (hoặc cũng có thể bảo mật).

**Hoạt động hợp nhất có an toàn đa luồng không?**

Không sử dụng cùng một đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) từ [nhiều luồng](/slides/vi/nodejs-java/multithreading/). Quy tắc được khuyến nghị là "một tài liệu — một luồng"; các tệp khác nhau có thể được xử lý đồng thời trong các luồng riêng biệt.

## **Xem thêm**

Aspose cung cấp một [FREE Online Collage Maker](https://products.aspose.app/slides/vi/collage). Sử dụng dịch vụ trực tuyến này, bạn có thể hợp nhất [JPG sang JPG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG sang PNG, tạo [lưới ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), và nhiều hơn nữa.

Hãy thử [Aspose FREE Online Merger](https://products.aspose.app/slides/vi/merger). Nó cho phép bạn hợp nhất các bản trình chiếu PowerPoint ở cùng định dạng (ví dụ: PPT sang PPT, PPTX sang PPTX) hoặc giữa các định dạng khác nhau (ví dụ: PPT sang PPTX, PPTX sang ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/vi/merger)