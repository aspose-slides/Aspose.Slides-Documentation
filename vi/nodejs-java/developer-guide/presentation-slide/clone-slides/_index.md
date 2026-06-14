---
title: Sao chép các slide bản trình chiếu trong JavaScript
linktitle: Sao chép Slides
type: docs
weight: 35
url: /vi/nodejs-java/clone-slides/
keywords:
- sao chép slide
- sao chép slide
- lưu slide
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Nhanh chóng sao chép các slide PowerPoint với Aspose.Slides cho Node.js. Thực hiện các ví dụ mã của chúng tôi để tự động tạo PPT trong vài giây và loại bỏ công việc thủ công."
---
## **Giới thiệu**

Sao chép (cloning) là quá trình tạo một bản sao chính xác hoặc bản sao của một đối tượng. Aspose.Slides for Node.js via Java cũng cho phép tạo một bản sao hoặc clone của bất kỳ slide nào và sau đó chèn slide đã clone vào bản trình chiếu hiện tại hoặc bất kỳ bản trình chiếu nào khác đã mở. Quá trình clone slide tạo một slide mới mà các nhà phát triển có thể chỉnh sửa mà không làm thay đổi slide gốc. Có một số cách để clone một slide:

- Sao chép ở cuối trong một bản trình chiếu.
- Sao chép ở vị trí khác trong bản trình chiếu.
- Sao chép ở cuối trong một bản trình chiếu khác.
- Sao chép ở vị trí khác trong một bản trình chiếu khác.
- Sao chép ở vị trí cụ thể trong một bản trình chiếu khác.

Trong Aspose.Slides for Node.js via Java, (một tập hợp các đối tượng [Slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Slide)) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) cung cấp các phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) và [insertClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) để thực hiện các loại sao chép slide ở trên

## **Sao chép ở cuối trong một bản trình chiếu**
Nếu bạn muốn clone một slide và sau đó sử dụng nó trong cùng một tệp bản trình chiếu ở cuối các slide hiện có, hãy sử dụng phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) theo các bước liệt kê dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Khởi tạo lớp [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) bằng cách tham chiếu tới bộ sưu tập Slides được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
3. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) và truyền slide cần clone làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
4. Ghi tệp bản trình chiếu đã được chỉnh sửa.

Trong ví dụ dưới đây, chúng tôi đã clone một slide (nằm ở vị trí đầu tiên – chỉ mục zero – của bản trình chiếu) tới cuối bản trình chiếu.

```javascript
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Sao chép slide mong muốn tới cuối bộ sưu tập các slide trong cùng một bản trình chiếu
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Ghi bản trình chiếu đã chỉnh sửa ra đĩa
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Sao chép ở vị trí khác trong bản trình chiếu**
Nếu bạn muốn clone một slide và sau đó sử dụng nó trong cùng một tệp bản trình chiếu nhưng ở vị trí khác, hãy sử dụng phương thức [insertClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-):

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Khởi tạo lớp bằng cách tham chiếu tới bộ sưu tập [**Slides**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
3. Gọi phương thức [insertClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) và truyền slide cần clone cùng với chỉ mục vị trí mới làm tham số cho phương thức [insertClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
4. Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã clone một slide (nằm ở chỉ mục zero – vị trí 1 – của bản trình chiếu) tới chỉ mục 1 – Vị trí 2 – của bản trình chiếu.

```javascript
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Sao chép slide mong muốn tới cuối bộ sưu tập các slide trong cùng một bản trình chiếu
    var slds = pres.getSlides();
    // Sao chép slide mong muốn tới vị trí chỉ mục đã chỉ định trong cùng một bản trình chiếu
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Ghi bản trình chiếu đã chỉnh sửa ra đĩa
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Sao chép ở cuối trong một bản trình chiếu khác**
Nếu bạn cần clone một slide từ một bản trình chiếu và sử dụng nó trong một bản trình chiếu khác, ở cuối các slide hiện có:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) chứa bản trình chiếu mà slide sẽ được clone từ đó.
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) chứa bản trình chiếu đích mà slide sẽ được thêm vào.
3. Khởi tạo lớp [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection) bằng cách tham chiếu tới bộ sưu tập [**Slides**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) được cung cấp bởi đối tượng Presentation của bản trình chiếu đích.
4. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) và truyền slide từ bản trình chiếu nguồn làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
5. Ghi tệp bản trình chiếu đích đã chỉnh sửa.

Trong ví dụ dưới đây, chúng tôi đã clone một slide (từ chỉ mục đầu tiên của bản trình chiếu nguồn) tới cuối bản trình chiếu đích.

```javascript
// Khởi tạo lớp Presentation để tải tệp bản trình chiếu nguồn
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép)
    var destPres = new aspose.slides.Presentation();
    try {
        // Sao chép slide mong muốn từ bản trình chiếu nguồn tới cuối bộ sưu tập các slide trong bản trình chiếu đích
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Ghi bản trình chiếu đích ra đĩa
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Sao chép ở vị trí khác trong một bản trình chiếu khác**
Nếu bạn cần clone một slide từ một bản trình chiếu và sử dụng nó trong một bản trình chiếu khác, ở một vị trí cụ thể:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) chứa bản trình chiếu nguồn mà slide sẽ được clone từ đó.
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) chứa bản trình chiếu mà slide sẽ được thêm vào.
3. Khởi tạo lớp [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) bằng cách tham chiếu tới bộ sưu tập Slides được cung cấp bởi đối tượng Presentation của bản trình chiếu đích.
4. Gọi phương thức [insertClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) và truyền slide từ bản trình chiếu nguồn cùng với vị trí mong muốn làm tham số cho phương thức [insertClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
5. Ghi tệp bản trình chiếu đích đã chỉnh sửa.

Trong ví dụ dưới đây, chúng tôi đã clone một slide (từ chỉ mục zero của bản trình chiếu nguồn) tới chỉ mục 1 (vị trí 2) của bản trình chiếu đích.

```javascript
// Khởi tạo lớp Presentation để tải tệp bản trình chiếu nguồn
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép)
    var destPres = new aspose.slides.Presentation();
    try {
        // Sao chép slide mong muốn từ bản trình chiếu nguồn tới cuối bộ sưu tập các slide trong bản trình chiếu đích
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // Ghi bản trình chiếu đích ra đĩa
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Sao chép ở vị trí cụ thể trong một bản trình chiếu khác**
Nếu bạn cần clone một slide cùng với master slide từ một bản trình chiếu và sử dụng nó trong một bản trình chiếu khác, trước tiên bạn phải clone master slide mong muốn từ bản trình chiếu nguồn sang bản trình chiếu đích. Sau đó sử dụng master slide đó để clone slide có master slide. Phương thức [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) yêu cầu một master slide từ bản trình chiếu đích chứ không phải từ bản trình chiếu nguồn. Để clone slide có master, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) chứa bản trình chiếu nguồn mà slide sẽ được clone từ đó.
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) chứa bản trình chiếu đích mà slide sẽ được clone tới.
3. Truy cập slide cần clone cùng với master slide.
4. Khởi tạo lớp [MasterSlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/MasterSlideCollection) bằng cách tham chiếu tới bộ sưu tập Masters được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) của bản trình chiếu đích.
5. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) được cung cấp bởi đối tượng [MasterSlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/MasterSlideCollection) và truyền master từ PPTX nguồn cần clone làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
6. Khởi tạo lớp [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) bằng cách đặt tham chiếu tới bộ sưu tập Slides được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) của bản trình chiếu đích.
7. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) và truyền slide từ bản trình chiếu nguồn cần clone và master slide làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
8. Ghi tệp bản trình chiếu đích đã chỉnh sửa.

Trong ví dụ dưới đây, chúng tôi đã clone một slide có master (nằm ở chỉ mục zero của bản trình chiếu nguồn) tới cuối bản trình chiếu đích bằng cách sử dụng master từ slide nguồn.

```javascript
// Khởi tạo lớp Presentation để tải tệp bản trình chiếu nguồn
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Khởi tạo lớp Presentation cho bản trình chiếu đích (nơi slide sẽ được sao chép)
    var destPres = new aspose.slides.Presentation();
    try {
        // Khởi tạo ISlide từ bộ sưu tập slide trong bản trình chiếu nguồn cùng với
        // Slide master
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Sao chép slide master mong muốn từ bản trình chiếu nguồn tới bộ sưu tập các master trong
        // Bản trình chiếu đích
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Sao chép slide master mong muốn từ bản trình chiếu nguồn tới bộ sưu tập các master trong
        // Bản trình chiếu đích
        var iSlide = masters.addClone(SourceMaster);
        // Sao chép slide mong muốn từ bản trình chiếu nguồn với master mong muốn tới cuối
        // Bộ sưu tập các slide trong bản trình chiếu đích
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // Lưu bản trình chiếu đích ra đĩa
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Sao chép ở cuối trong phần đã chỉ định**
Nếu bạn muốn clone một slide và sau đó sử dụng nó trong cùng một tệp bản trình chiếu nhưng ở một phần khác, hãy sử dụng phương thức [**addClone**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) được cung cấp bởi lớp [**SlideCollection**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection). Aspose.Slides for Node.js via Java cho phép clone một slide từ phần đầu tiên và sau đó chèn slide đã clone vào phần thứ hai của cùng một bản trình chiếu.

Đoạn mã sau cho thấy cách clone một slide và chèn slide đã clone vào một phần đã chỉ định.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Lưu bản trình chiếu đích ra đĩa
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Ghi chú người nói và nhận xét của người xem có được sao chép không?**

Có. Trang ghi chú và các nhận xét đánh giá được bao gồm trong bản sao. Nếu bạn không muốn chúng, hãy [remove them](/slides/vi/nodejs-java/presentation-notes/) sau khi chèn.

**Dữ liệu và nguồn dữ liệu của biểu đồ được xử lý như thế nào?**

Đối tượng biểu đồ, định dạng và dữ liệu nhúng đều được sao chép. Nếu biểu đồ được liên kết tới một nguồn bên ngoài (ví dụ: một workbook được nhúng OLE), liên kết đó được giữ nguyên dưới dạng một [OLE object](/slides/vi/nodejs-java/manage-ole/). Sau khi di chuyển giữa các tệp, hãy xác minh tính khả dụng của dữ liệu và hành vi làm mới.

**Tôi có thể kiểm soát vị trí chèn và phần cho bản sao không?**

Có. Bạn có thể chèn bản sao ở chỉ mục slide cụ thể và đặt nó vào một [section](/slides/vi/nodejs-java/slide-section/) đã chọn. Nếu phần đích không tồn tại, hãy tạo nó trước và sau đó di chuyển slide vào đó.