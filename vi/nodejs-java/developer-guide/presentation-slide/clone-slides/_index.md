---
title: Sao chép slide trình chiếu trong JavaScript
linktitle: Sao chép slide
type: docs
weight: 35
url: /vi/nodejs-java/clone-slides/
keywords:
- sao chép slide
- sao chép slide
- lưu slide
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Nhanh chóng sao chép các slide PowerPoint với Aspose.Slides cho Node.js. Thực hiện các ví dụ mã của chúng tôi để tự động tạo PPT trong vài giây và loại bỏ công việc thủ công."
---
## **Giới thiệu**

Cloning là quá trình tạo một bản sao chính xác hoặc bản sao của một đối tượng. Aspose.Slides for Node.js qua Java cũng cho phép tạo một bản sao hoặc bản sao của bất kỳ slide nào và sau đó chèn slide đã sao chép vào bản trình bày hiện tại hoặc bất kỳ bản trình bày nào khác đã mở. Quá trình sao chép slide tạo ra một slide mới có thể được nhà phát triển chỉnh sửa mà không làm thay đổi slide gốc. Có một số cách để sao chép một slide:

- Sao chép ở cuối trong một bản trình bày.
- Sao chép ở vị trí khác trong bản trình bày.
- Sao chép ở cuối trong một bản trình bày khác.
- Sao chép ở vị trí khác trong một bản trình bày khác.
- Sao chép ở vị trí cụ thể trong một bản trình bày khác.

In Aspose.Slides for Node.js qua Java, (một tập hợp các đối tượng [Slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Slide) ) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) cung cấp các phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) và [insertClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) để thực hiện các kiểu sao chép slide ở trên

## **Sao chép ở cuối trong một bản trình bày**
Nếu bạn muốn sao chép một slide và sau đó sử dụng nó trong cùng một tệp bản trình bày ở cuối các slide hiện có, hãy sử dụng phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) theo các bước được liệt kê dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Khởi tạo lớp [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) bằng cách tham chiếu tới bộ sưu tập Slides được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) và truyền slide cần sao chép làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Ghi tệp bản trình bày đã chỉnh sửa.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (nằm ở vị trí đầu tiên – chỉ mục zero – của bản trình bày) tới cuối bản trình bày.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Sao chép slide mong muốn tới cuối bộ sưu tập slide trong cùng một bản trình bày
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Ghi bản trình bày đã chỉnh sửa vào đĩa
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Sao chép ở vị trí khác trong bản trình bày**
Nếu bạn muốn sao chép một slide và sau đó sử dụng nó trong cùng một tệp bản trình bày nhưng ở vị trí khác, hãy sử dụng phương thức [insertClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-):

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Khởi tạo lớp bằng cách tham chiếu tới bộ sưu tập **Slides** được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Gọi phương thức [insertClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) và truyền slide cần sao chép cùng với chỉ mục cho vị trí mới làm tham số cho phương thức [insertClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (nằm ở chỉ mục 1 – vị trí 2 – của bản trình bày) tới chỉ mục 2 – vị trí 3 – của bản trình bày.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Sao chép slide mong muốn tới cuối bộ sưu tập slide trong cùng một bản trình chiếu
    var slds = pres.getSlides();
    // Sao chép slide mong muốn tới chỉ mục đã chỉ định trong cùng một bản trình chiếu
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Ghi bản trình chiếu đã chỉnh sửa vào đĩa
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Sao chép ở cuối trong một bản trình bày khác**
Nếu bạn cần sao chép một slide từ một bản trình bày và sử dụng nó trong một tệp bản trình bày khác, ở cuối các slide hiện có:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) chứa bản trình bày mà slide sẽ được sao chép từ đó.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) chứa bản trình bày đích mà slide sẽ được thêm vào.
1. Khởi tạo lớp [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection) bằng cách tham chiếu tới bộ sưu tập **Slides** được cung cấp bởi đối tượng Presentation của bản trình bày đích.
1. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) và truyền slide từ bản trình bày nguồn làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Ghi tệp bản trình bày đích đã chỉnh sửa.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (từ chỉ mục đầu tiên của bản trình bày nguồn) tới cuối bản trình bày đích.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Khởi tạo lớp Presentation để tải tệp trình chiếu nguồn
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép)
    var destPres = new aspose.slides.Presentation();
    try {
        // Sao chép slide mong muốn từ trình chiếu nguồn tới cuối bộ sưu tập slide trong trình chiếu đích
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Ghi trình chiếu đích vào đĩa
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Sao chép ở vị trí khác trong một bản trình bày khác**
Nếu bạn cần sao chép một slide từ một bản trình bày và sử dụng nó trong một tệp bản trình bày khác, ở vị trí cụ thể:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) chứa bản trình bày nguồn mà slide sẽ được sao chép từ đó.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) chứa bản trình bày đích mà slide sẽ được thêm vào.
1. Khởi tạo lớp [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) bằng cách tham chiếu tới bộ sưu tập Slides được cung cấp bởi đối tượng Presentation của bản trình bày đích.
1. Gọi phương thức [insertClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) và truyền slide từ bản trình bày nguồn cùng với vị trí mong muốn làm tham số cho phương thức [insertClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. Ghi tệp bản trình bày đích đã chỉnh sửa.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (từ chỉ mục zero của bản trình bày nguồn) tới chỉ mục 1 (vị trí 2) của bản trình bày đích.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Khởi tạo lớp Presentation để tải tệp trình chiếu nguồn
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép)
    var destPres = new aspose.slides.Presentation();
    try {
        // Sao chép slide mong muốn từ trình chiếu nguồn tới cuối bộ sưu tập slide trong trình chiếu đích
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // Ghi trình chiếu đích vào đĩa
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Sao chép ở vị trí cụ thể trong một bản trình bày khác**
Nếu bạn cần sao chép một slide có master slide từ một bản trình bày và sử dụng nó trong một bản trình bày khác, bạn cần sao chép master slide mong muốn từ bản trình bày nguồn sang bản trình bày đích trước. Sau đó bạn phải sử dụng master slide đó để sao chép slide có master. Phương thức [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) yêu cầu một master slide từ bản trình bày đích thay vì từ bản trình bày nguồn. Để sao chép slide có master, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) chứa bản trình bày nguồn mà slide sẽ được sao chép từ đó.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) chứa bản trình bày đích mà slide sẽ được sao chép tới.
1. Truy cập slide cần sao chép cùng với master slide.
1. Khởi tạo lớp [MasterSlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/MasterSlideCollection) bằng cách tham chiếu tới bộ sưu tập Masters được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) của bản trình bày đích.
1. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) được cung cấp bởi đối tượng [MasterSlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/MasterSlideCollection) và truyền master từ file PPTX nguồn cần sao chép làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Khởi tạo lớp [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) bằng cách đặt tham chiếu tới bộ sưu tập Slides được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) của bản trình bày đích.
1. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) và truyền slide từ bản trình bày nguồn cần sao chép cùng với master slide làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Ghi tệp bản trình bày đích đã chỉnh sửa.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide có master (nằm ở chỉ mục zero của bản trình bày nguồn) tới cuối bản trình bày đích bằng cách sử dụng master từ slide nguồn.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Khởi tạo lớp Presentation để tải tệp trình chiếu nguồn
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Khởi tạo lớp Presentation cho trình chiếu đích (nơi slide sẽ được sao chép)
    var destPres = new aspose.slides.Presentation();
    try {
        // Khởi tạo ISlide từ bộ sưu tập slide trong trình chiếu nguồn cùng với
        // Slide master
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Sao chép slide master mong muốn từ trình chiếu nguồn tới bộ sưu tập master trong
        // trình chiếu đích
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // Sao chép slide mong muốn từ trình chiếu nguồn cùng với master mong muốn tới cuối
        // bộ sưu tập slide trong trình chiếu đích
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
        // Lưu trình chiếu đích vào đĩa
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Sao chép ở cuối trong phần được chỉ định**
Nếu bạn muốn sao chép một slide và sau đó sử dụng nó trong cùng một tệp bản trình bày nhưng ở một phần khác, hãy sử dụng phương thức [**addClone**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) được cung cấp bởi lớp [**SlideCollection**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection). Aspose.Slides for Node.js qua Java cho phép sao chép một slide từ phần đầu tiên và sau đó chèn slide đã sao chép vào phần thứ hai của cùng một bản trình bày.

Đoạn mã dưới đây cho bạn thấy cách sao chép một slide và chèn slide đã sao chép vào một phần được chỉ định.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Lưu trình chiếu đích vào đĩa
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Đảm bảo kích thước slide phù hợp**

Khi sao chép slide vào một bản trình bày khác, hãy đảm bảo bản trình bày đích có cùng kích thước slide với nguồn. Nếu kích thước slide khác nhau, Aspose.Slides sẽ không tự động thay đổi tỷ lệ các hình đã sao chép—tọa độ và kích thước gốc của chúng được giữ nguyên, có thể khiến nội dung bị lệch hoặc vượt ra ngoài giới hạn slide.

Bạn có thể đặt kích thước slide của bản trình bày đích để phù hợp với nguồn trước khi sao chép master và slide:

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

Thực hiện điều này trước khi sao chép master và slide.

## **Câu hỏi thường gặp**

**Ghi chú người thuyết trình và bình luận của người đánh giá có được sao chép không?**

Yes. Trang ghi chú và bình luận đánh giá được bao gồm trong bản sao. Nếu bạn không muốn chúng, [remove them](/slides/vi/nodejs-java/presentation-notes/) after insertion.

**Biểu đồ và nguồn dữ liệu của chúng được xử lý như thế nào?**

Đối tượng biểu đồ, định dạng và dữ liệu nhúng được sao chép. Nếu biểu đồ được liên kết với nguồn bên ngoài (ví dụ, một workbook nhúng OLE), liên kết đó được giữ lại dưới dạng một [OLE object](/slides/vi/nodejs-java/manage-ole/). Sau khi di chuyển giữa các tệp, hãy xác minh tính khả dụng của dữ liệu và hành vi làm mới.

**Tôi có thể kiểm soát vị trí chèn và phần cho bản sao không?**

Yes. Bạn có thể chèn bản sao tại một chỉ mục slide cụ thể và đặt nó vào một [section](/slides/vi/nodejs-java/slide-section/) đã chọn. Nếu phần đích không tồn tại, hãy tạo nó trước và sau đó di chuyển slide vào đó.