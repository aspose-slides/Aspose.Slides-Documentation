---
title: Sao chép các slide trình chiếu trong Java
linktitle: Sao chép Slides
type: docs
weight: 35
url: /vi/java/clone-slides/
keywords:
- sao chép slide
- sao chép slide
- lưu slide
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Nhanh chóng nhân bản các slide PowerPoint với Aspose.Slides cho Java. Thực hiện theo các ví dụ mã rõ ràng của chúng tôi để tự động tạo PPT trong vài giây và loại bỏ công việc thủ công."
---
## **Giới thiệu**

Cloning là quá trình tạo một bản sao chính xác hoặc bản sao của một thứ gì đó. Aspose.Slides for Java cũng cho phép tạo bản sao hoặc clone của bất kỳ slide nào và sau đó chèn slide đã clone vào bản trình chiếu hiện tại hoặc bất kỳ bản trình chiếu nào khác đã mở. Quá trình clone slide tạo ra một slide mới có thể được các nhà phát triển chỉnh sửa mà không làm thay đổi slide gốc. Có một vài cách để clone một slide:

- Clone ở vị trí cuối trong một bản trình chiếu.
- Clone ở vị trí khác trong bản trình chiếu.
- Clone ở vị trí cuối trong một bản trình chiếu khác.
- Clone ở vị trí khác trong một bản trình chiếu khác.
- Clone cùng với master slide của nó vào một bản trình chiếu khác.

Trong Aspose.Slides for Java, (một bộ sưu tập các đối tượng [ISlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlide)) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) cung cấp các phương thức [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) và [insertClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) để thực hiện các kiểu clone slide nêu trên

## **Clone một slide ở cuối bản trình chiếu**
Nếu bạn muốn clone một slide và sau đó sử dụng nó trong cùng một tệp bản trình chiếu ở cuối các slide hiện có, hãy sử dụng phương thức [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
2. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--) bằng cách tham chiếu đến bộ sưu tập Slides được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
3. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--) và truyền slide cần được clone làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
4. Ghi tệp bản trình chiếu đã chỉnh sửa.

Trong ví dụ dưới đây, chúng tôi đã clone một slide (nằm ở vị trí đầu tiên – chỉ số 0 – của bản trình chiếu) tới cuối bản trình chiếu.

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Clone slide mong muốn tới cuối bộ sưu tập các slide trong cùng một bản trình chiếu
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Ghi bản trình chiếu đã chỉnh sửa vào đĩa
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clone một slide tới vị trí khác trong cùng một bản trình chiếu**
Nếu bạn muốn clone một slide và sau đó sử dụng nó trong cùng một tệp bản trình chiếu nhưng ở vị trí khác, hãy sử dụng phương thức [insertClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
2. Khởi tạo lớp bằng cách tham chiếu đến bộ sưu tập **Slides**([https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--)) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
3. Gọi phương thức [insertClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--) và truyền slide cần clone cùng với chỉ số vị trí mới làm tham số cho phương thức [insertClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
4. Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã clone một slide (nằm ở chỉ số 1 – vị trí 2 – của bản trình chiếu) tới chỉ số 2 – vị trí 3 – của bản trình chiếu.

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Lấy bộ sưu tập các slide trong bản trình chiếu
    ISlideCollection slds = pres.getSlides();

    // Clone slide mong muốn tới chỉ mục đã chỉ định trong cùng một bản trình chiếu
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Ghi bản trình chiếu đã chỉnh sửa vào đĩa
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clone một slide ở cuối một bản trình chiếu khác**
Nếu bạn cần clone một slide từ một bản trình chiếu và sử dụng nó trong một bản trình chiếu khác, ở cuối các slide hiện có:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) chứa bản trình chiếu nguồn mà slide sẽ được clone từ đó.
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) chứa bản trình chiếu đích mà slide sẽ được thêm vào.
3. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection) bằng cách tham chiếu đến bộ sưu tập **Slides**([https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--)) được cung cấp bởi đối tượng Presentation của bản trình chiếu đích.
4. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--) và truyền slide từ bản trình chiếu nguồn làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
5. Ghi tệp bản trình chiếu đích đã chỉnh sửa.

Trong ví dụ dưới đây, chúng tôi đã clone một slide (từ chỉ số đầu tiên của bản trình chiếu nguồn) tới cuối bản trình chiếu đích.

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation để tải tệp trình chiếu nguồn
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được clone)
    Presentation destPres = new Presentation();
    try {
        // Clone slide mong muốn từ bản trình chiếu nguồn tới cuối bộ sưu tập các slide trong bản trình chiếu đích
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
Nếu bạn cần clone một slide từ một bản trình chiếu và sử dụng nó trong một bản trình chiếu khác, ở vị trí cụ thể:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) chứa bản trình chiếu nguồn mà slide sẽ được clone từ đó.
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) chứa bản trình chiếu đích mà slide sẽ được thêm vào.
3. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--) bằng cách tham chiếu đến bộ sưu tập Slides được cung cấp bởi đối tượng Presentation của bản trình chiếu đích.
4. Gọi phương thức [insertClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--) và truyền slide từ bản trình chiếu nguồn cùng với vị trí mong muốn làm tham số cho phương thức [insertClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
5. Ghi tệp bản trình chiếu đích đã chỉnh sửa.

Trong ví dụ dưới đây, chúng tôi đã clone một slide (từ chỉ số 0 của bản trình chiếu nguồn) tới chỉ số 1 (vị trí 2) của bản trình chiếu đích.

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation để tải tệp trình chiếu nguồn
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được clone)
    Presentation destPres = new Presentation();
    try {
        // Clone slide mong muốn từ bản trình chiếu nguồn tới chỉ mục đã chỉ định trong bản trình chiếu đích
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // Ghi bản trình chiếu đích vào đĩa
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clone một slide cùng master slide của nó tới một bản trình chiếu khác**
Nếu bạn cần clone một slide cùng master slide từ một bản trình chiếu và sử dụng nó trong một bản trình chiếu khác, trước tiên bạn phải clone master slide mong muốn từ bản trình chiếu nguồn sang bản trình chiếu đích. Sau đó bạn cần sử dụng master slide đó để clone slide cùng master. Phương thức [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) yêu cầu một master slide từ bản trình chiếu đích thay vì từ bản trình chiếu nguồn. Để clone slide cùng master, vui lòng làm theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) chứa bản trình chiếu nguồn mà slide sẽ được clone từ đó.
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) chứa bản trình chiếu đích mà slide sẽ được clone tới.
3. Truy cập slide cần clone cùng với master slide.
4. Khởi tạo lớp [IMasterSlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IMasterSlideCollection) bằng cách tham chiếu đến bộ sưu tập Masters được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) của bản trình chiếu đích.
5. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) được cung cấp bởi đối tượng [IMasterSlideCollection] và truyền master từ PPTX nguồn cần clone làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
6. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--) bằng cách thiết lập tham chiếu tới bộ sưu tập Slides được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) của bản trình chiếu đích.
7. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--) và truyền slide từ bản trình chiếu nguồn cần clone cùng với master slide làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
8. Ghi tệp bản trình chiếu đích đã chỉnh sửa.

Trong ví dụ dưới đây, chúng tôi đã clone một slide cùng master (nằm ở chỉ số 0 của bản trình chiếu nguồn) tới cuối bản trình chiếu đích bằng cách sử dụng master từ slide nguồn.

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation để tải tệp trình chiếu nguồn
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Khởi tạo lớp Presentation cho bản trình chiếu đích (nơi slide sẽ được clone)
    Presentation destPres = new Presentation();
    try {
        // Khởi tạo ISlide từ bộ sưu tập các slide trong bản trình chiếu nguồn cùng với
        // slide master
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Clone slide master mong muốn từ bản trình chiếu nguồn tới bộ sưu tập các master trong
        // bản trình chiếu đích
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = masters.addClone(SourceMaster);

        // Clone slide mong muốn từ bản trình chiếu nguồn với master mong muốn tới cuối
        // bộ sưu tập các slide trong bản trình chiếu đích
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);

        // Lưu bản trình chiếu đích vào đĩa
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clone một slide ở cuối một phần (section) xác định**
Nếu bạn muốn clone một slide và sau đó sử dụng nó trong cùng một tệp bản trình chiếu nhưng ở một phần (section) khác, hãy sử dụng [**addClone**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) được cung cấp bởi giao diện [**ISlideCollection**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection). Aspose.Slides for Java cho phép clone một slide từ phần đầu tiên và sau đó chèn slide đã clone vào phần thứ hai của cùng một bản trình chiếu.

Đoạn mã sau cho thấy cách clone một slide và chèn slide đã clone vào một phần xác định.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);

    // Lưu bản trình chiếu đích vào đĩa
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Đảm bảo kích thước slide khớp nhau**

Khi clone slide vào một bản trình chiếu khác, hãy chắc chắn rằng bản trình chiếu đích có cùng kích thước slide với bản nguồn. Nếu kích thước slide khác nhau, Aspose.Slides sẽ không tự động thay đổi tỷ lệ các hình dạng đã clone—tọa độ và kích thước gốc của chúng sẽ được giữ nguyên, có thể khiến nội dung bị lệch hoặc vượt ra ngoài ranh giới slide.

Bạn có thể đặt kích thước slide của bản trình chiếu đích sao cho khớp với bản nguồn trước khi clone master và slide:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Thực hiện bước này trước khi clone master và slide.

## **Câu hỏi thường gặp**

**Các ghi chú người thuyết trình và bình luận đánh giá có được clone không?**

Có. Trang ghi chú và các bình luận đánh giá đều được bao gồm trong bản clone. Nếu bạn không muốn chúng, hãy [xóa chúng](/slides/vi/java/presentation-notes/) sau khi chèn.

**Biểu đồ và nguồn dữ liệu của chúng được xử lý như thế nào?**

Đối tượng biểu đồ, định dạng và dữ liệu nhúng được sao chép. Nếu biểu đồ được liên kết tới nguồn bên ngoài (ví dụ: một workbook nhúng OLE), liên kết đó sẽ được giữ lại dưới dạng [đối tượng OLE](/slides/vi/java/manage-ole/). Sau khi di chuyển giữa các tệp, hãy kiểm tra tính khả dụng của dữ liệu và hành vi làm mới.

**Tôi có thể kiểm soát vị trí chèn và phần cho bản clone không?**

Có. Bạn có thể chèn bản clone tại một chỉ số slide cụ thể và đặt nó vào một [section](/slides/vi/java/slide-section/) đã chọn. Nếu phần đích chưa tồn tại, hãy tạo nó trước và sau đó di chuyển slide vào đó.