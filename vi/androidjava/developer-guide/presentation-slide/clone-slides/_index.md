---
title: "Sao chép Slide Bản trình chiếu trên Android"
linktitle: "Sao chép Slide"
type: docs
weight: 35
url: /vi/androidjava/clone-slides/
keywords:
- sao chép slide
- chép slide
- lưu slide
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Sao chép các slide PowerPoint với Aspose.Slides cho Android. Theo dõi các ví dụ mã Java rõ ràng của chúng tôi để tự động tạo PPT trong vài giây và loại bỏ công việc thủ công."
---
## **Giới thiệu**

Sao chép (cloning) là quá trình tạo một bản sao hoặc bản sao chính xác của một đối tượng. Aspose.Slides cho Android thông qua Java cũng cho phép tạo một bản sao hoặc clone của bất kỳ slide nào và sau đó chèn slide đã clone vào bản trình chiếu hiện tại hoặc bất kỳ bản trình chiếu đã mở nào khác. Quá trình clone slide tạo ra một slide mới có thể được nhà phát triển chỉnh sửa mà không làm thay đổi slide gốc. Có một số cách có thể thực hiện việc clone slide:

- Clone ở cuối trong một bản trình chiếu.
- Clone ở vị trí khác trong bản trình chiếu.
- Clone ở cuối trong một bản trình chiếu khác.
- Clone ở vị trí khác trong một bản trình chiếu khác.
- Clone ở vị trí cụ thể trong một bản trình chiếu khác.

Trong Aspose.Slides cho Android thông qua Java, (một tập hợp các đối tượng [ISlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlide)) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) cung cấp các phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) và [insertClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) để thực hiện các loại clone slide nêu trên

## **Clone một slide ở cuối bản trình chiếu**
Nếu bạn muốn clone một slide và sau đó sử dụng nó trong cùng một tệp bản trình chiếu ở cuối các slide hiện có, hãy sử dụng phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) bằng cách tham chiếu tới tập hợp Slides được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) và truyền slide cần clone làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Ghi file bản trình chiếu đã chỉnh sửa.

Trong ví dụ dưới đây, chúng ta đã clone một slide (nằm ở vị trí đầu tiên – chỉ mục 0 – của bản trình chiếu) tới cuối bản trình chiếu.

```java
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Clone slide mong muốn tới cuối bộ sưu tập slide trong cùng một bản trình chiếu
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Ghi bản trình chiếu đã chỉnh sửa vào đĩa
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clone một slide tới vị trí khác trong cùng một bản trình chiếu**
Nếu bạn muốn clone một slide và sau đó sử dụng nó trong cùng một tệp bản trình chiếu nhưng ở vị trí khác, hãy sử dụng phương thức [insertClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Khởi tạo lớp bằng cách tham chiếu tới tập hợp [**Slides**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Gọi phương thức [insertClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) và truyền slide cần clone cùng với chỉ mục cho vị trí mới làm tham số cho phương thức [insertClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng ta đã clone một slide (nằm ở chỉ mục 0 – vị trí 1 – của bản trình chiếu) tới chỉ mục 1 – Vị trí 2 – của bản trình chiếu.

```java
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Clone slide mong muốn tới cuối bộ sưu tập slide trong cùng một bản trình chiếu
    ISlideCollection slds = pres.getSlides();

    // Clone slide mong muốn tới chỉ mục xác định trong cùng một bản trình chiếu
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Ghi bản trình chiếu đã chỉnh sửa vào đĩa
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clone một slide ở cuối một bản trình chiếu khác**
Nếu bạn cần clone một slide từ một bản trình chiếu và sử dụng nó trong một bản trình chiếu khác, ở cuối các slide hiện có:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) chứa bản trình chiếu nguồn mà slide sẽ được clone từ đó.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) chứa bản trình chiếu đích mà slide sẽ được thêm vào.
1. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection) bằng cách tham chiếu tới tập hợp [**Slides**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) được cung cấp bởi đối tượng Presentation của bản trình chiếu đích.
1. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) và truyền slide từ bản trình chiếu nguồn làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Ghi file bản trình chiếu đích đã chỉnh sửa.

Trong ví dụ dưới đây, chúng ta đã clone một slide (từ chỉ mục đầu tiên của bản trình chiếu nguồn) tới cuối bản trình chiếu đích.

```java
// Khởi tạo lớp Presentation để tải tệp bản trình chiếu nguồn
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được clone)
    Presentation destPres = new Presentation();
    try {
        // Clone slide mong muốn từ bản trình chiếu nguồn tới cuối bộ sưu tập slide trong bản trình chiếu đích
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Ghi bản trình chiếu đích vào đĩa
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clone một slide tới vị trí khác trong một bản trình chiếu khác**
Nếu bạn cần clone một slide từ một bản trình chiếu và sử dụng nó trong một bản trình chiếu khác, ở một vị trí cụ thể:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) chứa bản trình chiếu nguồn mà slide sẽ được clone từ đó.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) chứa bản trình chiếu mà slide sẽ được thêm vào.
1. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) bằng cách tham chiếu tới tập hợp Slides được cung cấp bởi đối tượng Presentation của bản trình chiếu đích.
1. Gọi phương thức [insertClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) và truyền slide từ bản trình chiếu nguồn cùng với vị trí mong muốn làm tham số cho phương thức [insertClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Ghi file bản trình chiếu đích đã chỉnh sửa.

Trong ví dụ dưới đây, chúng ta đã clone một slide (từ chỉ mục 0 của bản trình chiếu nguồn) tới chỉ mục 1 (vị trí 2) của bản trình chiếu đích.

```java
// Khởi tạo lớp Presentation để tải tệp bản trình chiếu nguồn
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được clone)
    Presentation destPres = new Presentation();
    try {
        // Clone slide mong muốn từ bản trình chiếu nguồn tới cuối bộ sưu tập slide trong bản trình chiếu đích
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Ghi bản trình chiếu đích vào đĩa
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clone một slide ở vị trí cụ thể trong một bản trình chiếu khác**
Nếu bạn cần clone một slide có master slide từ một bản trình chiếu và sử dụng nó trong một bản trình chiếu khác, bạn phải clone master slide mong muốn từ bản trình chiếu nguồn sang bản trình chiếu đích trước. Sau đó bạn cần sử dụng master slide đó để clone slide có master slide. Phương thức [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) yêu cầu một master slide từ bản trình chiếu đích chứ không phải từ bản trình chiếu nguồn. Để clone slide có master, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) chứa bản trình chiếu nguồn mà slide sẽ được clone từ đó.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) chứa bản trình chiếu đích mà slide sẽ được clone tới.
1. Truy cập slide cần clone cùng với master slide.
1. Khởi tạo lớp [IMasterSlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IMasterSlideCollection) bằng cách tham chiếu tới tập hợp Masters được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) của bản trình chiếu đích.
1. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) được cung cấp bởi đối tượng [IMasterSlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IMasterSlideCollection) và truyền master từ PPTX nguồn cần clone làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) bằng cách thiết lập tham chiếu tới tập hợp Slides được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) của bản trình chiếu đích.
1. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) và truyền slide từ bản trình chiếu nguồn cần clone cùng với master slide làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Ghi file bản trình chiếu đích đã chỉnh sửa.

Trong ví dụ dưới đây, chúng ta đã clone một slide có master (nằm ở chỉ mục 0 của bản trình chiếu nguồn) tới cuối bản trình chiếu đích bằng master từ slide nguồn.

```java
// Khởi tạo lớp Presentation để tải tệp bản trình chiếu nguồn
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Khởi tạo lớp Presentation cho bản trình chiếu đích (nơi slide sẽ được clone)
    Presentation destPres = new Presentation();
    try {
        // Khởi tạo ISlide từ bộ sưu tập slide trong bản trình chiếu nguồn cùng với
        // Slide Master
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Clone master slide mong muốn từ bản trình chiếu nguồn tới bộ sưu tập master trong
        // Bản trình chiếu đích
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Clone master slide mong muốn từ bản trình chiếu nguồn tới bộ sưu tập master trong
        // Bản trình chiếu đích
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Clone slide mong muốn từ bản trình chiếu nguồn với master mong muốn tới cuối
        // Bộ sưu tập slide trong bản trình chiếu đích
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Lưu bản trình chiếu đích vào đĩa
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clone một slide ở cuối một phần được chỉ định**
Nếu bạn muốn clone một slide và sau đó sử dụng nó trong cùng một tệp bản trình chiếu nhưng ở một phần khác, hãy sử dụng phương thức [**addClone**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) được cung cấp bởi giao diện [**ISlideCollection**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection). Aspose.Slides cho Android thông qua Java cho phép clone một slide từ phần đầu tiên và sau đó chèn slide đã clone vào phần thứ hai của cùng một bản trình chiếu.

Đoạn mã dưới đây cho thấy cách clone một slide và chèn slide đã clone vào một phần được chỉ định.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Lưu bản trình chiếu đích vào đĩa
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Các ghi chú diễn giả và bình luận của người xem có được clone không?**

Có. Trang ghi chú và bình luận đánh giá đều được bao gồm trong bản clone. Nếu bạn không muốn chúng, [remove them](/slides/vi/androidjava/presentation-notes/) sau khi chèn.

**Biểu đồ và nguồn dữ liệu của chúng được xử lý như thế nào?**

Đối tượng biểu đồ, định dạng và dữ liệu nhúng đều được sao chép. Nếu biểu đồ được liên kết với nguồn ngoài (ví dụ: sổ làm việc OLE được nhúng), liên kết đó được giữ nguyên như một [OLE object](/slides/vi/androidjava/manage-ole/). Sau khi di chuyển giữa các tệp, hãy kiểm tra tính sẵn có của dữ liệu và hành vi làm mới.

**Tôi có thể kiểm soát vị trí chèn và các phần cho bản clone không?**

Có. Bạn có thể chèn bản clone vào chỉ mục slide cụ thể và đặt nó vào một [section](/slides/vi/androidjava/slide-section/) đã chọn. Nếu phần đích không tồn tại, hãy tạo nó trước rồi sau đó di chuyển slide vào đó.