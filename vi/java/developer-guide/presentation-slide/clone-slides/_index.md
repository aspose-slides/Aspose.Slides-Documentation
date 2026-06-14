---
title: Sao chép slide trình chiếu bằng Java
linktitle: Sao chép Slide
type: docs
weight: 35
url: /vi/java/clone-slides/
keywords:
- sao chép slide
- chép slide
- lưu slide
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Nhanh chóng sao chép các slide PowerPoint bằng Aspose.Slides cho Java. Theo dõi các ví dụ mã rõ ràng của chúng tôi để tự động tạo PPT trong vài giây và loại bỏ công việc thủ công."
---
## **Giới thiệu**

Sao chép là quá trình tạo một bản sao chính xác hoặc bản sao của một vật gì đó. Aspose.Slides for Java cũng cho phép tạo một bản sao hoặc bản sao của bất kỳ slide nào và sau đó chèn slide đã sao chép đó vào presentation hiện tại hoặc bất kỳ presentation nào khác đang mở. Quá trình sao chép slide tạo ra một slide mới có thể được nhà phát triển sửa đổi mà không thay đổi slide gốc. Có một số cách để sao chép một slide:

- Sao chép ở cuối trong một Presentation.
- Sao chép ở vị trí khác trong Presentation.
- Sao chép ở cuối trong một Presentation khác.
- Sao chép ở vị trí khác trong một Presentation khác.
- Sao chép ở vị trí cụ thể trong một Presentation khác.

Trong Aspose.Slides for Java, (một tập hợp các đối tượng [ISlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlide) ) được công bố bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) cung cấp các phương thức [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) và [insertClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) để thực hiện các kiểu sao chép slide nêu trên

## **Sao chép một Slide ở cuối một Presentation**
Nếu bạn muốn sao chép một slide và sau đó sử dụng nó trong cùng một tệp presentation ở cuối các slide hiện có, hãy dùng phương thức [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
1. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--) bằng cách tham chiếu tới tập Slides được công bố bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
1. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) được công bố bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--) và truyền slide cần sao chép làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Ghi tệp presentation đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (nằm ở vị trí đầu tiên – chỉ mục 0 – của presentation) tới cuối presentation.

```java
// Khởi tạo lớp Presentation đại diện cho một tệp presentation
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Sao chép slide mong muốn tới cuối bộ sưu tập các slide trong cùng một presentation
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Ghi presentation đã sửa đổi vào đĩa
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Sao chép một Slide tới vị trí khác trong một Presentation**
Nếu bạn muốn sao chép một slide và sau đó sử dụng nó trong cùng một tệp presentation nhưng ở vị trí khác, hãy dùng phương thức [insertClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
1. Khởi tạo lớp bằng cách tham chiếu tới tập **Slides**([https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--)) được công bố bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
1. Gọi phương thức [insertClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) được công bố bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--) và truyền slide cần sao chép cùng với chỉ mục cho vị trí mới làm tham số cho phương thức [insertClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Ghi presentation đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (nằm ở chỉ mục 0 – vị trí 1 – của presentation) tới chỉ mục 1 – Vị trí 2 – của presentation.

```java
// Khởi tạo lớp Presentation đại diện cho một tệp presentation
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Sao chép slide mong muốn tới cuối bộ sưu tập các slide trong cùng một presentation
    ISlideCollection slds = pres.getSlides();

    // Sao chép slide mong muốn tới chỉ mục được chỉ định trong cùng một presentation
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Ghi presentation đã sửa đổi vào đĩa
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Sao chép một Slide ở cuối một Presentation khác**
Nếu bạn cần sao chép một slide từ một presentation và sử dụng nó trong một presentation khác, ở cuối các slide hiện có:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) chứa presentation mà slide sẽ được sao chép từ đó.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) chứa presentation đích mà slide sẽ được thêm vào.
1. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection) bằng cách tham chiếu tới tập **Slides**([https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--)) được công bố bởi đối tượng Presentation của presentation đích.
1. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) được công bố bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--) và truyền slide từ presentation nguồn làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Ghi tệp presentation đích đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (từ chỉ mục đầu tiên của presentation nguồn) tới cuối presentation đích.

```java
// Khởi tạo lớp Presentation để tải tệp presentation nguồn
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép)
    Presentation destPres = new Presentation();
    try {
        // Sao chép slide mong muốn từ presentation nguồn tới cuối bộ sưu tập các slide trong presentation đích
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Ghi presentation đích vào đĩa
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Sao chép một Slide tới vị trí khác trong một Presentation khác**
Nếu bạn cần sao chép một slide từ một presentation và sử dụng nó trong một presentation khác, ở một vị trí cụ thể:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) chứa presentation nguồn mà slide sẽ được sao chép từ đó.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) chứa presentation mà slide sẽ được thêm vào.
1. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--) bằng cách tham chiếu tới tập Slides được công bố bởi đối tượng Presentation của presentation đích.
1. Gọi phương thức [insertClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) được công bố bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--) và truyền slide từ presentation nguồn cùng với vị trí mong muốn làm tham số cho phương thức [insertClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Ghi tệp presentation đích đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (từ chỉ mục 0 của presentation nguồn) tới chỉ mục 1 (vị trí 2) của presentation đích.

```java
// Khởi tạo lớp Presentation để tải tệp presentation nguồn
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép)
    Presentation destPres = new Presentation();
    try {
        // Sao chép slide mong muốn từ presentation nguồn tới cuối bộ sưu tập các slide trong presentation đích
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Ghi presentation đích vào đĩa
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Sao chép một Slide ở vị trí cụ thể trong một Presentation khác**
Nếu bạn cần sao chép một slide có master slide từ một presentation và sử dụng nó trong một presentation khác, trước tiên bạn phải sao chép master slide mong muốn từ presentation nguồn sang presentation đích. Sau đó, bạn sử dụng master slide đó để sao chép slide có master. Phương thức [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) yêu cầu một master slide từ presentation đích chứ không phải từ presentation nguồn. Để sao chép slide có master, vui lòng làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) chứa presentation nguồn mà slide sẽ được sao chép từ đó.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) chứa presentation đích mà slide sẽ được sao chép tới.
1. Truy cập slide cần sao chép cùng với master slide.
1. Khởi tạo lớp [IMasterSlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IMasterSlideCollection) bằng cách tham chiếu tới tập Masters được công bố bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) của presentation đích.
1. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) được công bố bởi đối tượng [IMasterSlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IMasterSlideCollection) và truyền master từ PPTX nguồn cần sao chép làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--) bằng cách đặt tham chiếu tới tập Slides được công bố bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) của presentation đích.
1. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) được công bố bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--) và truyền slide từ presentation nguồn cần sao chép và master slide làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Ghi tệp presentation đích đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide có master (nằm ở chỉ mục 0 của presentation nguồn) tới cuối presentation đích bằng master từ slide nguồn.

```java
// Khởi tạo lớp Presentation để tải tệp presentation nguồn
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Khởi tạo lớp Presentation cho presentation đích (nơi slide sẽ được sao chép)
    Presentation destPres = new Presentation();
    try {
        // Khởi tạo ISlide từ bộ sưu tập các slide trong presentation nguồn cùng với
        // Slide master
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Sao chép slide master mong muốn từ presentation nguồn tới bộ sưu tập các master trong
        // presentation đích
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Sao chép slide master mong muốn từ presentation nguồn tới bộ sưu tập các master trong
        // presentation đích
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Sao chép slide mong muốn từ presentation nguồn với master mong muốn tới cuối của
        // bộ sưu tập các slide trong presentation đích
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Lưu presentation đích vào đĩa
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Sao chép một Slide ở cuối một Section được chỉ định**
Nếu bạn muốn sao chép một slide và sau đó sử dụng nó trong cùng một tệp presentation nhưng ở một section khác, thì sử dụng [**addClone**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) được công bố bởi giao diện [**ISlideCollection**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection). Aspose.Slides cho Java cho phép sao chép một slide từ section đầu tiên và sau đó chèn slide đã sao chép vào section thứ hai của cùng một presentation.

Đoạn mã sau cho thấy cách sao chép một slide và chèn slide đã sao chép vào một section được chỉ định.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Lưu presentation đích vào đĩa
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Ghi chú người thuyết trình và bình luận của người xem có được sao chép không?**

Có. Trang ghi chú và bình luận đánh giá đều được bao gồm trong bản sao. Nếu bạn không muốn chúng, [xóa chúng](/slides/vi/java/presentation-notes/) sau khi chèn.

**Biểu đồ và nguồn dữ liệu của chúng được xử lý như thế nào?**

Đối tượng biểu đồ, định dạng và dữ liệu nhúng đều được sao chép. Nếu biểu đồ được liên kết tới nguồn bên ngoài (ví dụ: một workbook OLE nhúng), liên kết đó được giữ lại dưới dạng [đối tượng OLE](/slides/vi/java/manage-ole/). Sau khi di chuyển giữa các tệp, hãy kiểm tra tính sẵn có của dữ liệu và hành vi làm mới.

**Tôi có thể kiểm soát vị trí chèn và các section cho bản sao không?**

Có. Bạn có thể chèn bản sao ở chỉ mục slide cụ thể và đặt nó vào một [phần](/slides/vi/java/slide-section/) đã chọn. Nếu section đích không tồn tại, hãy tạo nó trước và sau đó di chuyển slide vào đó.