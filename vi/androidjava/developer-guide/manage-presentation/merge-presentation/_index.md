---
title: Hiệu quả hợp nhất các bản trình chiếu trên Android
linktitle: Hợp nhất Trình chiếu
type: docs
weight: 40
url: /vi/androidjava/merge-presentation/
keywords:
- hợp nhất PowerPoint
- hợp nhất trình chiếu
- hợp nhất slide
- hợp nhất PPT
- hợp nhất PPTX
- hợp nhất ODP
- kết hợp PowerPoint
- kết hợp trình chiếu
- kết hợp slide
- kết hợp PPT
- kết hợp PPTX
- kết hợp ODP
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách hợp nhất các bản trình chiếu PowerPoint và OpenDocument trên Android bằng cách sao chép slide, kiểm soát master và layout, thay đổi kích thước nội dung slide, bảo tồn các phần, và xử lý các tệp được bảo vệ hoặc có kích thước lớn."
---
## **Tổng quan**

Aspose.Slides cho Android thông qua Java hợp nhất các bản trình chiếu bằng cách sao chép các slide từ một [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) sang bản khác. Hoạt động chính là [ISlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), có thể giữ nguyên định dạng của slide nguồn hoặc gắn slide đã sao chép vào một master hoặc layout trong bản trình chiếu đích.

Bài viết này bao gồm các quy trình hợp nhất phổ biến nhất:

- hợp nhất tất cả các slide trong khi giữ nguyên định dạng nguồn của chúng;
- hợp nhất các slide đã chọn;
- áp dụng một master từ bản trình chiếu đích;
- áp dụng một layout cụ thể từ bản trình chiếu đích;
- chuẩn hoá các kích thước slide khác nhau trước khi hợp nhất;
- thêm các slide đã sao chép vào một phần;
- hợp nhất nhiều bản trình chiếu trong một quy trình đầu‑cuối;
- xử lý master, tài nguyên, ghi chú, bình luận, phương tiện, phông chữ, mật khẩu, tệp lớn và các vấn đề đa luồng.

## **Cách sao chép Slide ảnh hưởng đến Master và Layout**

Slide kế thừa phần lớn giao diện từ layout và master của nó. Vì lý do này, overload sao chép bạn chọn sẽ quyết định cách slide được hợp nhất được tích hợp vào bản trình chiếu đích.

Sử dụng [ISlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/) theo một trong các cách sau:

- `addClone(sourceSlide)` — giữ nguyên layout và định dạng của slide nguồn. Khi cần, master nguồn có thể được sao chép tự động vào bản trình chiếu đích. Aspose.Slides theo dõi các master được sao chép tự động để các slide lặp lại sử dụng cùng một master nguồn không gây sao chép master đó nhiều lần.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — gắn slide đã sao chép vào một [IMasterSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslide/) đích cụ thể. Aspose.Slides sẽ tìm layout khớp dưới master đó theo loại hoặc tên.
- `addClone(sourceSlide, destinationLayout)` — gắn slide đã sao chép trực tiếp vào một [ILayoutSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/) đích cụ thể.

Master hoặc layout được truyền vào overload `addClone` phải thuộc về bản trình chiếu **đích**, không phải bản trình chiếu nguồn.

## **Hợp nhất Toàn bộ Bản Trình Chiếu và Giữ Định Dạng Nguồn**

Cách hợp nhất đơn giản nhất là sao chép mọi slide từ bản trình chiếu nguồn sang bản trình chiếu đích. Đây là lựa chọn phù hợp khi các slide được nhập cần giữ nguyên giao diện, master và quan hệ layout gốc.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Bản trình chiếu kết quả có thể chứa nhiều master khi nguồn và đích sử dụng các thiết kế khác nhau. Điều này là mong đợi khi định dạng nguồn được cố ý giữ nguyên.

## **Hợp nhất Các Slide Đã Chọn**

Bạn không nhất thiết phải sao chép mọi slide. Ví dụ sau chỉ nhập các chỉ mục slide đã chọn từ bản trình chiếu nguồn.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Xác thực chỉ mục slide trước khi sao chép khi chúng đến từ đầu vào của người dùng hoặc cấu hình bên ngoài.

## **Hợp Nhất Slide Sử Dụng Master Đích**

Sử dụng overload [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) khi các slide được nhập cần tuân theo một master đã thuộc về bản trình chiếu đích.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides sẽ chọn một layout thích hợp dưới master đã chỉ định bằng cách khớp loại hoặc tên layout nguồn. Nếu không tồn tại layout phù hợp và `allowCloneMissingLayout` là `true`, layout nguồn sẽ được sao chép để slide có thể được thêm. Nếu nó là `false`, một [PptxEditException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxeditexception/) sẽ được ném ra.

Sử dụng `false` khi bạn muốn quá trình hợp nhất thất bại thay vì tạo thêm một layout vào master đích.

## **Hợp Nhất Slide Sử Dụng Layout Đích Cụ Thể**

Sử dụng overload [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) khi bạn biết chính xác layout đích mà các slide nhập vào nên sử dụng.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Áp dụng một layout đích thay đổi quan hệ layout được kế thừa; nó không thay đổi thiết kế nội dung slide nguồn. Nếu layout nguồn và đích có cấu trúc placeholder khác nhau, hãy kiểm tra kết quả để xác nhận rằng định dạng kế thừa và hành vi placeholder là phù hợp.

## **Hợp Nhất Bản Trình Chiếu Có Kích Thước Slide Khác Nhau**

Các bản trình chiếu có kích thước slide khác nhau có thể được hợp nhất, nhưng sao chép một slide vào bản trình chiếu có kích thước slide khác sẽ không tự động thiết kế lại nội dung cho canvas mới. Các hình dạng có thể bị dịch, co giãn không mong đợi hoặc nằm ngoài vùng hiển thị của slide.

Một cách thực tế là thay đổi kích thước bản trình chiếu nguồn trước khi sao chép. Phương thức [SlideSize.setSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) có thể phóng đại nội dung hiện có đồng thời thay đổi kích thước slide. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidesizescaletype/) phóng đại nội dung để vừa với kích thước yêu cầu.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Thay đổi kích thước sẽ làm thay đổi đối tượng bản trình chiếu nguồn trong bộ nhớ. Nếu bạn cần giữ bản trình chiếu nguồn gốc không thay đổi cho các thao tác khác, mở một thể hiện riêng cho quá trình hợp nhất.

## **Hợp Nhất Slide Vào Phần Của Bản Trình Chiếu**

Vòng lặp sao chép slide cơ bản không tái tạo lại cấu trúc phần của bản trình chiếu nguồn. Nếu phần quan trọng trong kết quả, hãy tạo hoặc chọn các phần trong bản trình chiếu đích và sao chép slide vào chúng một cách rõ ràng bằng [addClone(ISlide, ISection)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Các slide đã sao chép sẽ được thêm vào phần đích đã chỉ định. Để giữ lại nhiều phần nguồn, hãy liệt kê [Presentation.getSections](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getSections--) , lấy danh sách slide hiện tại của mỗi phần nguồn bằng [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) , tạo lại các phần trong bản đích, và sao chép từng slide trả về vào phần đích tương ứng. Xem [Manage Slide Sections](/slides/vi/androidjava/slide-section/) để biết ví dụ hoàn chỉnh về liệt kê phần, bao gồm phần trống và thay đổi cấu trúc.

## **Hợp Nhất Nhiều Bản Trình Chiếu Một Cách An Toàn**

Ví dụ đầu‑cuối dưới đây sử dụng bản trình chiếu đầu tiên làm đích, chuẩn hoá kích thước slide của mỗi nguồn bổ sung, giữ mỗi nguồn mở chỉ trong thời gian sao chép, và lưu tệp cuối cùng sau khi hoàn tất.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Đây là một mô hình hữu ích để giữ định dạng nguồn của các slide được nhập. Nếu đầu ra của bạn phải sử dụng một chủ đề đích duy nhất, thay thế lời gọi `addClone(slide)` đơn giản bằng overload master hoặc layout đích thích hợp đã trình bày ở trên.

## **Lưu Ý Thực Tế**

### **Master, Layout và Độ Chính Xác Định Dạng**

Sao chép slide mặc định có thể tự động mang một master nguồn cần thiết vào bản trình chiếu đích. Aspose.Slides duy trì một bảng đăng ký nội bộ cho các master được sao chép tự động để tránh sao chép cùng một master nhiều lần. Các master được sao chép thủ công không được theo dõi bởi bảng đăng ký này, vì vậy tránh sao chép trước các master trừ khi bạn cần kiểm soát cấu trúc master một cách rõ ràng.

Không giả định rằng hai master hoặc layout cùng tên sẽ có hình ảnh tương đương. Nếu một mẫu công ty phải kiểm soát giao diện cuối cùng, hãy chọn một master hoặc layout đích một cách rõ ràng và xác minh kết quả sau khi hợp nhất.

### **Ghi Chú và Bình Luận**

Ghi chú cho người thuyết trình và bình luận slide được liên kết với nội dung slide và sẽ được sao chép khi slide được sao chép. Aspose.Slides cũng cung cấp các API riêng cho [presentation notes](/slides/vi/androidjava/presentation-notes/) và [presentation comments](/slides/vi/androidjava/presentation-comments/).

Nếu định dạng trang ghi chú quan trọng, hãy kiểm tra bản trình chiếu đã hợp nhất vì master ghi chú là đối tượng cấp độ bản trình chiếu và có thể khác nhau giữa các tệp nguồn. Đối với quy trình xét duyệt, cũng cần kiểm tra tác giả bình luận và các chuỗi bình luận sau khi kết hợp các tệp từ các tác giả hoặc mẫu khác nhau.

### **Hình Ảnh, Audio, Video, Đối Tượng OLE và Liên Kết Ngoài**

Slide có thể tham chiếu đến tài nguyên cấp độ bản trình chiếu như hình ảnh, audio nhúng, video nhúng và dữ liệu OLE. Hãy sao chép toàn bộ slide thay vì chỉ sao chép các hình dạng hiển thị để Aspose.Slides có thể duy trì các quan hệ tài nguyên của slide.

Tài nguyên được nhúng và tài nguyên được liên kết cần được xử lý khác nhau. Một audio, video, đối tượng OLE hoặc siêu liên kết được liên kết vẫn phụ thuộc vào mục tiêu bên ngoài; sao chép slide không biến liên kết ngoài thành nội dung nhúng. Hãy kiểm tra đường dẫn và URL của tài nguyên liên kết trong môi trường nơi bản trình chiếu hợp nhất sẽ được mở.

Aspose.Slides theo dõi các master được sao chép tự động, nhưng điều này không đồng nghĩa với việc mọi tài nguyên nhị phân giống nhau từ các bản trình chiếu không liên quan sẽ luôn được gộp lại. Nếu kích thước tệp đầu ra quan trọng, kiểm tra gói đã hợp nhất và đo kết quả thay vì dựa vào việc gộp ngầm.

### **Phông Chữ Nhúng và Khả Năng Sử Dụng Phông**

Phông chữ được quản lý ở mức độ bản trình chiếu. Nếu kiểu chữ phải đồng nhất trên các máy, không nên cho rằng sao chép slide đơn thuần sẽ đảm bảo mọi phông chữ cần thiết đã có sẵn trong môi trường đích. Bạn có thể kiểm tra phông chữ nhúng bằng [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) và quản lý việc nhúng một cách rõ ràng như mô tả trong [Embed Fonts in Presentations](/slides/vi/androidjava/embedded-font/).

Cũng cần xác minh rằng bạn có quyền nhúng các phông chữ được sử dụng trong các tệp nguồn. Giấy phép phông chữ có thể hạn chế việc nhúng.

### **Bản Trình Chiếu Được Bảo Mật Bằng Mật Khẩu**

Một nguồn được bảo mật phải được mở thành công trước khi các slide của nó có thể được sao chép. Cung cấp mật khẩu qua [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Làm việc với bản trình chiếu đã giải mã.
} finally {
    source.dispose();
}
```

Mở một nguồn đã mã hoá không tự động áp dụng cùng một bảo mật cho bản trình chiếu đích. Cấu hình bảo mật đầu ra riêng khi cần.

### **Bản Trình Chiếu Lớn và Tiêu Thụ Bộ Nhớ**

Các bản trình chiếu lớn chứa hình ảnh độ phân giải cao, audio, video hoặc các đối tượng nhị phân lớn khác có thể tiêu tốn đáng kể bộ nhớ. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) cung cấp các tùy chọn kiểm soát việc xử lý BLOB và sử dụng tệp tạm. Xem [Manage Presentation BLOBs](/slides/vi/androidjava/manage-blob/) để biết chiến lược cho tệp lớn.

Đối với tệp lớn, ưu tiên tải từ đường dẫn tệp khi có thể, giải phóng mỗi bản trình chiếu nguồn ngay sau khi đã hợp nhất, và tránh lưu lại các kết quả trung gian nhiều lần trừ khi quy trình yêu cầu checkpoint.

### **An Toàn Đa Luồng**

Không tải, sửa đổi, lưu hoặc sao chép cùng một [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) đồng thời từ nhiều luồng. Giữ mỗi thể hiện bản trình chiếu trong một thao tác hợp nhất duy nhất. Nếu bạn thực hiện các công việc độc lập song song, hãy dùng các thể hiện bản trình chiếu độc lập và tuân theo hướng dẫn [Aspose.Slides multithreading](/slides/vi/androidjava/multithreading/).

## **Câu Hỏi Thường Gặp**

**Làm sao để giữ nguyên thiết kế gốc của mỗi bản trình chiếu nguồn?**

Sử dụng [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) mà không cung cấp master hoặc layout đích. Aspose.Slides có thể tự động sao chép master nguồn khi slide nhập vào cần đến.

**Làm sao để các slide nhập vào sử dụng chủ đề đích?**

Sử dụng overload chấp nhận một master đích. Cung cấp một master từ bản trình chiếu đích, không phải từ bản nguồn. Aspose.Slides sẽ cố gắng ánh xạ mỗi slide nguồn tới một layout thích hợp dưới master đó.

**Khi nào nên dùng layout đích cụ thể thay vì master đích?**

Dùng layout cụ thể khi mọi slide nhập vào phải sử dụng một layout đã biết. Dùng master khi bạn muốn Aspose.Slides tự chọn layout trong master dựa trên loại hoặc tên layout nguồn.

**Có thể hợp nhất các bản trình chiếu có kích thước slide khác nhau không?**

Có, nhưng nội dung slide sẽ không tự động thiết kế lại cho kích thước đích. Hãy thay đổi kích thước bản trình chiếu nguồn trước khi sao chép, ví dụ bằng [SlideSize.setSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) và [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidesizescaletype/).

**Có thể hợp nhất PPT, PPTX và ODP vào một tệp không?**

Có. Tải mỗi bản trình chiếu nguồn, sao chép các slide cần thiết vào một bản đích, và lưu bản đích ở định dạng đầu ra được hỗ trợ. Vì các định dạng bản trình chiếu không hỗ trợ cùng một tập hợp tính năng, hãy kiểm tra nội dung phức tạp sau khi hợp nhất đa định dạng. Xem [Supported File Formats](/slides/vi/androidjava/supported-file-formats/).

**Các phần nguồn có được bảo tồn tự động không?**

Không, nếu chỉ dùng vòng lặp cơ bản sao chép slide. Hãy tạo lại các phần cần thiết trong bản đích và sử dụng overload phần của [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) khi cấu trúc phần phải được bảo tồn.

**Ghi chú và bình luận có được bảo lưu không?**

Chúng được sao chép cùng với slide đã sao chép. Đối với quy trình phụ thuộc vào kiểu dáng master ghi chú, tác giả bình luận hoặc dữ liệu đánh giá chuỗi, hãy xác minh kết quả hợp nhất vì những trường hợp này liên quan đến cấu trúc cấp độ bản trình chiếu cũng như nội dung slide.

**Audio, video, đối tượng OLE và siêu liên kết sẽ như thế nào?**

Nội dung nhúng sẽ được mang theo như một phần của các quan hệ tài nguyên của slide đã sao chép. Các liên kết ngoài vẫn giữ nguyên trạng thái ngoài, vì vậy các tệp hoặc URL mục tiêu phải vẫn tồn tại sau khi hợp nhất.

**Các phông chữ nhúng từ mọi nguồn có được đảm bảo có trong bản trình chiếu hợp nhất không?**

Không nên chỉ dựa vào việc sao chép slide để triển khai phông chữ. Kiểm tra phông chữ nhúng trong bản đích và quản lý việc nhúng hoặc cung cấp phông chữ bên ngoài một cách rõ ràng khi kiểu chữ quan trọng.

**Làm sao để hợp nhất tệp được bảo mật bằng mật khẩu?**

Mở nó bằng [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), sau đó sao chép các slide như bình thường. Bảo mật đầu ra được cấu hình riêng.

**Nên xử lý các bản trình chiếu rất lớn như thế nào?**

Sử dụng quản lý BLOB khi các đối tượng nhị phân lớn chiếm ưu thế trong việc sử dụng bộ nhớ, ưu tiên tải từ đường dẫn tệp cho các tệp rất lớn, giải phóng nhanh các bản trình chiếu nguồn sau khi đã hợp nhất, và chỉ lưu kết quả cuối cùng khi cần.

**Có thể sao chép slide từ nhiều luồng không?**

Không sử dụng cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) đồng thời từ nhiều luồng. Giữ mỗi thao tác hợp nhất riêng biệt trong các thể hiện bản trình chiếu độc lập.