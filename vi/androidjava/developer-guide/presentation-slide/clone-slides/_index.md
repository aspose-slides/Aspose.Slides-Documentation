---
title: Sao chép các slide bài thuyết trình trên Android
linktitle: Sao chép Slides
type: docs
weight: 35
url: /vi/androidjava/clone-slides/
keywords:
- sao chép slide
- sao chép slide
- lưu slide
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Nhân đôi các slide PowerPoint bằng Aspose.Slides cho Android. Thực hiện các ví dụ mã Java rõ ràng của chúng tôi để tự động tạo PPT trong vài giây và loại bỏ công việc thủ công."
---
## **Giới thiệu**

Sao chép (cloning) là quá trình tạo một bản sao chính xác hoặc bản sao của một đối tượng. Aspose.Slides for Android qua Java cũng cho phép tạo một bản sao hoặc sao chép của bất kỳ slide nào và sau đó chèn slide đã sao chép vào bản trình bày hiện tại hoặc bất kỳ bản trình bày nào khác đã mở. Quá trình sao chép slide tạo ra một slide mới mà các nhà phát triển có thể chỉnh sửa mà không làm thay đổi slide gốc. Có một số cách để sao chép một slide:

- Sao chép ở cuối trong cùng một bản trình bày.
- Sao chép ở vị trí khác trong cùng một bản trình bày.
- Sao chép ở cuối trong một bản trình bày khác.
- Sao chép ở vị trí khác trong một bản trình bày khác.
- Sao chép ở vị trí cụ thể trong một bản trình bày khác.

Trong Aspose.Slides for Android qua Java, (một bộ sưu tập các đối tượng [ISlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlide) ) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) cung cấp các phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) và [insertClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) để thực hiện các kiểu sao chép slide nêu trên.

## **Sao chép một slide ở cuối bản trình bày**
Nếu bạn muốn sao chép một slide và sau đó sử dụng nó trong cùng một tệp bản trình bày ở cuối các slide hiện có, hãy sử dụng phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) bằng cách tham chiếu tới bộ sưu tập Slides được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) và truyền slide cần sao chép làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Ghi tệp bản trình bày đã chỉnh sửa.

Trong ví dụ dưới đây, chúng ta đã sao chép một slide (nằm ở vị trí đầu tiên – chỉ mục 0 – của bản trình bày) tới cuối bản trình bày.

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Sao chép slide mong muốn tới cuối bộ sưu tập các slide trong cùng một bài thuyết trình
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Ghi bản thuyết trình đã chỉnh sửa ra đĩa
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Sao chép một slide tới vị trí khác trong cùng một bản trình bày**
Nếu bạn muốn sao chép một slide và sau đó sử dụng nó trong cùng một tệp bản trình bày nhưng ở vị trí khác, hãy sử dụng phương thức [insertClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Khởi tạo lớp bằng cách tham chiếu tới bộ sưu tập [**Slides**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Gọi phương thức [insertClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) và truyền slide cần sao chép cùng với chỉ mục cho vị trí mới làm tham số cho phương thức [insertClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng ta đã sao chép một slide (nằm ở chỉ mục 1 – vị trí 2 – của bản trình bày) tới chỉ mục 2 – vị trí 3 – của bản trình bày.

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Lấy bộ sưu tập các slide trong cùng một bài thuyết trình
    ISlideCollection slds = pres.getSlides();

    // Sao chép slide mong muốn tới chỉ mục đã chỉ định trong cùng một bài thuyết trình
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Ghi bản thuyết trình đã chỉnh sửa ra đĩa
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Sao chép một slide ở cuối một bản trình bày khác**
Nếu bạn cần sao chép một slide từ một bản trình bày và sử dụng nó trong một bản trình bày khác, ở cuối các slide hiện có:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) chứa bản trình bày mà slide sẽ được sao chép.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) chứa bản trình bày đích mà slide sẽ được thêm vào.
1. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection) bằng cách tham chiếu tới bộ sưu tập [**Slides**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) được cung cấp bởi đối tượng Presentation của bản trình bày đích.
1. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) và truyền slide từ bản trình bày nguồn làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Ghi tệp bản trình bày đích đã chỉnh sửa.

Trong ví dụ dưới đây, chúng ta đã sao chép một slide (từ chỉ mục đầu tiên của bản trình bày nguồn) tới cuối bản trình bày đích.

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation để tải tệp bài thuyết trình nguồn
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép)
    Presentation destPres = new Presentation();
    try {
        // Sao chép slide mong muốn từ bài thuyết trình nguồn tới cuối bộ sưu tập các slide trong bài thuyết trình đích
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Ghi bài thuyết trình đích ra đĩa
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Sao chép một slide tới vị trí khác trong một bản trình bày khác**
Nếu bạn cần sao chép một slide từ một bản trình bày và sử dụng nó trong một bản trình bày khác, ở một vị trí cụ thể:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) chứa bản trình bày nguồn mà slide sẽ được sao chép.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) chứa bản trình bày mà slide sẽ được thêm vào.
1. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) bằng cách tham chiếu tới bộ sưu tập Slides được cung cấp bởi đối tượng Presentation của bản trình bày đích.
1. Gọi phương thức [insertClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) và truyền slide từ bản trình bày nguồn cùng với vị trí mong muốn làm tham số cho phương thức [insertClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Ghi tệp bản trình bày đích đã chỉnh sửa.

Trong ví dụ dưới đây, chúng ta đã sao chép một slide (từ chỉ mục 0 của bản trình bày nguồn) tới chỉ mục 1 (vị trí 2) của bản trình bày đích.

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation để tải tệp bài thuyết trình nguồn
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép)
    Presentation destPres = new Presentation();
    try {
        // Sao chép slide mong muốn từ bài thuyết trình nguồn tới chỉ mục được chỉ định trong bài thuyết trình đích
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // Ghi bài thuyết trình đích ra đĩa
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Sao chép một slide ở vị trí cụ thể trong một bản trình bày khác**
Nếu bạn cần sao chép một slide có master slide từ một bản trình bày và sử dụng nó trong một bản trình bày khác, trước tiên bạn cần sao chép master slide mong muốn từ bản trình bày nguồn sang bản trình bày đích. Sau đó bạn sử dụng master slide đó để sao chép slide có master. Phương thức [**addClone(ISlide,IMasterSlide,boolean)**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) yêu cầu một master slide từ bản trình bày đích chứ không phải từ bản trình bày nguồn. Để sao chép slide có master, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) chứa bản trình bày nguồn mà slide sẽ được sao chép.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) chứa bản trình bày đích mà slide sẽ được sao chép tới.
1. Truy cập slide cần sao chép cùng với master slide.
1. Khởi tạo lớp [IMasterSlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IMasterSlideCollection) bằng cách tham chiếu tới bộ sưu tập Masters được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) của bản trình bày đích.
1. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) được cung cấp bởi đối tượng [IMasterSlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IMasterSlideCollection) và truyền master từ PPTX nguồn cần sao chép làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) bằng cách đặt tham chiếu tới bộ sưu tập Slides được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) của bản trình bày đích.
1. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) và truyền slide từ bản trình bày nguồn cần sao chép và master slide làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. Ghi tệp bản trình bày đích đã chỉnh sửa.

Trong ví dụ dưới đây, chúng ta đã sao chép một slide có master (nằm ở chỉ mục 0 của bản trình bày nguồn) tới cuối bản trình bày đích bằng master từ slide nguồn.

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation để tải tệp bài thuyết trình nguồn
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Khởi tạo lớp Presentation cho bài thuyết trình đích (nơi slide sẽ được sao chép)
    Presentation destPres = new Presentation();
    try {
        // Khởi tạo ISlide từ bộ sưu tập các slide trong bài thuyết trình nguồn cùng với
        // slide Master
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Sao chép slide master mong muốn từ bài thuyết trình nguồn vào bộ sưu tập các master trong
        // bài thuyết trình đích
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Sao chép slide mong muốn từ bài thuyết trình nguồn với master đã chọn tới cuối
        // bộ sưu tập các slide trong bài thuyết trình đích
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Lưu bài thuyết trình đích ra đĩa
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Sao chép một slide ở cuối một phần (section) xác định**
Nếu bạn muốn sao chép một slide và sau đó sử dụng nó trong cùng một tệp bản trình bày nhưng ở một phần khác, hãy sử dụng phương thức [**addClone**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-) được cung cấp bởi giao diện [**ISlideCollection**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection). Aspose.Slides for Android qua Java cho phép sao chép một slide từ phần đầu tiên và sau đó chèn slide đã sao chép vào phần thứ hai của cùng một bản trình bày.

Đoạn mã sau cho thấy cách sao chép một slide và chèn slide đã sao chép vào một phần xác định.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Lưu bản thuyết trình đích ra đĩa
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Đảm bảo khớp kích thước slide**

Khi sao chép slide vào một bản trình bày khác, hãy đảm bảo bản trình bày đích có cùng kích thước slide với bản nguồn. Nếu kích thước slide khác nhau, Aspose.Slides sẽ không tự động thay đổi tỷ lệ các hình dạng đã sao chép — tọa độ và kích thước gốc được giữ nguyên, điều này có thể khiến nội dung bị lệch hoặc vượt ra ngoài giới hạn slide.

Bạn có thể đặt kích thước slide của bản trình bày đích sao cho khớp với bản nguồn trước khi sao chép master và slide:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Thực hiện bước này trước khi sao chép master và slide.

## **Câu hỏi thường gặp**

**Ghi chú người thuyết trình và bình luận của người đánh giá có được sao chép không?**

Có. Trang ghi chú và các bình luận đánh giá đều được bao gồm trong bản sao. Nếu bạn không muốn chúng, hãy [xóa chúng](/slides/vi/androidjava/presentation-notes/) sau khi chèn.

**Biểu đồ và nguồn dữ liệu của chúng được xử lý như thế nào?**

Đối tượng biểu đồ, định dạng và dữ liệu nhúng đều được sao chép. Nếu biểu đồ được liên kết tới nguồn ngoài (ví dụ: một workbook được nhúng OLE), liên kết đó vẫn được giữ dưới dạng [đối tượng OLE](/slides/vi/androidjava/manage-ole/). Sau khi di chuyển giữa các tệp, hãy kiểm tra tính sẵn sàng của dữ liệu và hành vi làm mới.

**Tôi có thể kiểm soát vị trí chèn và phần (section) cho bản sao không?**

Có. Bạn có thể chèn bản sao tại một chỉ mục slide cụ thể và đặt nó vào một [phần](/slides/vi/androidjava/slide-section/) đã chọn. Nếu phần đích chưa tồn tại, hãy tạo nó trước rồi di chuyển slide vào.