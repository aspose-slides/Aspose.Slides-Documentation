---
title: Kết hợp hiệu quả các bản trình bày trong Java
linktitle: Kết hợp bản trình bày
type: docs
weight: 40
url: /vi/java/merge-presentation/
keywords:
- kết hợp PowerPoint
- kết hợp bản trình bày
- kết hợp slide
- kết hợp PPT
- kết hợp PPTX
- kết hợp ODP
- kết hợp PowerPoint
- kết hợp bản trình bày
- kết hợp slide
- kết hợp PPT
- kết hợp PPTX
- kết hợp ODP
- Java
- Aspose.Slides
description: "Tìm hiểu cách kết hợp các bản trình bày PowerPoint và OpenDocument trong Java bằng cách sao chép slide, kiểm soát master và layout, thay đổi kích thước nội dung slide, giữ nguyên các section, và xử lý các tệp được bảo vệ hoặc có kích thước lớn."
---
## **Tổng quan**

Aspose.Slides for Java hợp nhất các bản trình bày bằng cách sao chép các slide từ một [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) sang một bản khác. Hoạt động chính là [ISlideCollection.addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), có thể giữ nguyên định dạng của slide nguồn hoặc gắn slide đã sao chép vào một master hoặc layout trong bản trình bày đích.

Bài viết này bao gồm các quy trình hợp nhất phổ biến nhất:

- hợp nhất tất cả các slide trong khi giữ nguyên định dạng nguồn;
- hợp nhất các slide được chọn;
- áp dụng master từ bản trình bày đích;
- áp dụng một layout cụ thể từ bản trình bày đích;
- chuẩn hoá các kích thước slide khác nhau trước khi hợp nhất;
- thêm các slide đã sao chép vào một section;
- hợp nhất nhiều bản trình bày trong một quy trình đầu cuối;
- xử lý master, tài nguyên, ghi chú, bình luận, media, phông chữ, mật khẩu, tệp lớn và các vấn đề đa luồng.

## **Cách sao chép slide ảnh hưởng đến Masters và Layouts**

Một slide kế thừa phần lớn ngoại hình từ layout và master của nó. Vì vậy, overload sao chép mà bạn chọn sẽ xác định cách slide hợp nhất được tích hợp vào bản trình bày đích.

Sử dụng [ISlideCollection.addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidecollection/) theo một trong các cách sau:

- `addClone(sourceSlide)` — giữ nguyên layout và định dạng của slide nguồn. Khi cần, master nguồn có thể tự động được sao chép vào bản trình bày đích. Aspose.Slides theo dõi các master được sao chép tự động để các slide lặp lại sử dụng cùng một master nguồn không gây sao chép master đó nhiều lần.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — gắn slide đã sao chép vào một [IMasterSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslide/) đích cụ thể. Aspose.Slides tìm kiếm một layout phù hợp dưới master đó theo loại hoặc tên layout.
- `addClone(sourceSlide, destinationLayout)` — gắn slide đã sao chép trực tiếp vào một [ILayoutSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutslide/) đích cụ thể.

Master hoặc layout được truyền vào overload `addClone` phải thuộc **bản trình bày đích**, không phải bản trình bày nguồn.

## **Hợp nhất Toàn bộ Bản Trình Bày và Giữ Nguyên Định Dạng Nguồn**

Cách hợp nhất đơn giản nhất là sao chép mọi slide từ bản trình bày nguồn sang bản trình bày đích. Đây là lựa chọn thích hợp khi các slide được nhập cần giữ nguyên theme, master và quan hệ layout gốc.

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

Bản trình bày kết quả có thể chứa nhiều master khi nguồn và đích sử dụng các thiết kế khác nhau. Điều này là mong đợi khi định dạng nguồn được cố ý giữ lại.

## **Hợp nhất Các Slide Được Chọn**

Bạn không cần sao chép mọi slide. Ví dụ dưới đây chỉ nhập các chỉ mục slide được chọn từ bản trình bày nguồn.

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

Kiểm tra chỉ mục slide trước khi sao chép khi chúng đến từ đầu vào của người dùng hoặc cấu hình bên ngoài.

## **Hợp nhất Slide bằng Master Đích**

Sử dụng overload [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) khi các slide nhập vào phải tuân theo một master đã thuộc về bản trình bày đích.

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

Aspose.Slides chọn một layout phù hợp dưới master chỉ định bằng cách khớp loại hoặc tên layout nguồn. Nếu không tồn tại layout thích hợp và `allowCloneMissingLayout` là `true`, layout nguồn sẽ được sao chép để slide có thể được thêm. Nếu `false`, một [PptxEditException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptxeditexception/) sẽ được ném ra.

Sử dụng `false` khi bạn muốn quá trình hợp nhất thất bại thay vì tạo thêm một layout vào master đích.

## **Hợp nhất Slide bằng Layout Đích Cụ Thể**

Sử dụng overload [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) khi bạn biết chính xác layout đích mà các slide nhập vào cần sử dụng.

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

Áp dụng một layout đích thay đổi quan hệ layout được kế thừa; nó không thiết kế lại nội dung slide nguồn. Nếu layout nguồn và đích có cấu trúc placeholder khác nhau, hãy kiểm tra kết quả để xác nhận rằng định dạng kế thừa và hành vi placeholder là phù hợp.

## **Hợp nhất Bản Trình Bày có Kích Thước Slide Khác Nhau**

Các bản trình bày có kích thước slide khác nhau có thể được hợp nhất, nhưng việc sao chép một slide vào bản trình bày có kích thước slide khác sẽ không tự động thiết kế lại nội dung cho canvas mới. Do đó các hình dạng có thể xuất hiện bị dịch, tỷ lệ không mong muốn hoặc nằm ngoài khu vực hiển thị của slide.

Một cách thực tế là thay đổi kích thước bản trình bày nguồn trước khi sao chép. Phương thức [SlideSize.setSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidesize/#setSize-float-float-int-) có thể thu phóng nội dung hiện có đồng thời thay đổi kích thước slide. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidesizescaletype/) thu phóng nội dung để vừa với kích thước yêu cầu.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    Dimension2D sourceSize = source.getSlideSize().getSize();
    Dimension2D destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            (float) destinationSize.getWidth(), 
            (float) destinationSize.getHeight(), 
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

Thay đổi kích thước sẽ sửa đổi đối tượng bản trình bày nguồn trong bộ nhớ. Nếu bạn cần giữ nguyên bản trình bày nguồn cho các thao tác khác, hãy mở một thể hiện riêng cho quá trình hợp nhất.

## **Hợp nhất Slide vào Section của Bản Trình Bày**

Vòng lặp sao chép slide cơ bản sẽ không tái tạo lại cấu trúc section của bản trình bày nguồn. Nếu section quan trọng trong đầu ra, hãy tạo hoặc chọn các section trong bản trình bày đích và sao chép slide vào chúng một cách rõ ràng bằng [addClone(ISlide, ISection)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

Các slide đã sao chép sẽ được nối vào section đích được chỉ định. Để giữ lại nhiều section nguồn, duyệt [Presentation.getSections](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getSections--), lấy danh sách slide hiện tại của mỗi section nguồn bằng [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isection/#getSlidesListOfSection--), tạo lại các section trong đích, và sao chép từng slide trả về vào section đích tương ứng. Xem [Manage Slide Sections](/slides/vi/java/slide-section/) để biết ví dụ đầy đủ về duyệt section, bao gồm cả các section trống và thay đổi cấu trúc.

## **Hợp nhất Nhiều Bản Trình Bày Một Cách An Toàn**

Ví dụ đầu cuối dưới đây dùng bản trình bày đầu tiên làm đích, chuẩn hoá kích thước slide của mỗi nguồn bổ sung, giữ mỗi nguồn mở chỉ trong thời gian sao chép, và lưu tệp cuối cùng một lần duy nhất.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    Dimension2D mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            Dimension2D sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    (float) mergedSize.getWidth(), 
                    (float) mergedSize.getHeight(), 
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

Đây là một cơ sở hữu ích để giữ nguyên định dạng nguồn của các slide được nhập. Nếu đầu ra của bạn phải sử dụng một theme duy nhất, thay thế lời gọi đơn giản `addClone(slide)` bằng overload master hoặc layout đích thích hợp đã trình bày ở trên.

## **Các Xem Xét Thực Tiễn**

### **Masters, Layouts và Độ Chính Xác Định Dạng**

Sao chép slide mặc định có thể tự động đưa master nguồn cần thiết vào bản trình bày đích. Aspose.Slides duy trì một registry nội bộ cho các master được sao chép tự động để tránh sao chép cùng một master nhiều lần. Các master được sao chép thủ công không được registry này theo dõi, vì vậy tránh sao chép master trước nếu không cần kiểm soát rõ ràng cấu trúc master.

Không nên giả định rằng hai master hoặc layout có cùng tên sẽ hiển thị giống nhau. Nếu một mẫu công ty phải kiểm soát giao diện cuối cùng, hãy chọn một master hoặc layout đích một cách rõ ràng và xác nhận kết quả sau khi hợp nhất.

### **Ghi chú và Bình luận**

Ghi chú diễn giả và bình luận slide được gắn với nội dung slide và sẽ được sao chép khi slide được sao chép. Aspose.Slides cũng cung cấp API riêng cho [presentation notes](/slides/vi/java/presentation-notes/) và [presentation comments](/slides/vi/java/presentation-comments/).

Nếu định dạng trang ghi chú quan trọng, hãy kiểm tra bản trình bày đã hợp nhất vì master ghi chú là đối tượng cấp trình bày và có thể khác nhau giữa các tệp nguồn. Đối với quy trình xem xét, cũng hãy xác thực tác giả bình luận và các chuỗi bình luận sau khi kết hợp các tệp từ các tác giả hoặc mẫu khác nhau.

### **Hình ảnh, Âm thanh, Video, Đối tượng OLE và Liên kết Ngoài**

Slide có thể tham chiếu tới các tài nguyên cấp trình bày như hình ảnh, âm thanh nhúng, video nhúng và dữ liệu OLE. Hãy sao chép toàn bộ slide thay vì chỉ sao chép các hình dạng hiển thị để Aspose.Slides có thể duy trì các mối quan hệ của slide với tài nguyên của nó.

Các tài nguyên nhúng và liên kết nên được xử lý khác nhau. Một audio, video, đối tượng OLE hoặc hyperlink được liên kết vẫn phụ thuộc vào mục tiêu bên ngoài; sao chép slide không biến một liên kết ngoài thành nội dung nhúng. Kiểm tra đường dẫn và URL của tài nguyên liên kết trong môi trường mà bản trình bày hợp nhất sẽ được mở.

Aspose.Slides theo dõi các master được sao chép tự động, nhưng điều này không đồng nghĩa với việc các tài nguyên nhị phân giống hệt từ các bản trình bày nguồn không liên quan sẽ luôn được loại bỏ trùng lặp. Nếu kích thước tệp đầu ra quan trọng, hãy kiểm tra gói đã hợp nhất và đo kích thước kết quả thay vì dựa vào việc loại bỏ trùng lặp ngầm.

### **Phông chữ Nhúng và Tính Sẵn Có của Phông chữ**

Phông chữ được quản lý ở cấp trình bày. Nếu kiểu chữ phải nhất quán trên các máy, không nên giả định rằng việc sao chép slide đơn thuần sẽ bảo đảm mọi phông chữ cần thiết đã có trong môi trường đích. Bạn có thể kiểm tra phông chữ nhúng bằng [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) và quản lý việc nhúng một cách rõ ràng như mô tả trong [Embed Fonts in Presentations](/slides/vi/java/embedded-font/).

Cũng hãy xác nhận rằng bạn được phép nhúng các phông chữ được sử dụng trong các tệp nguồn. Giấy phép phông chữ có thể hạn chế việc nhúng.

### **Bản Trình Bày Được Bảo Vệ Bằng Mật Khẩu**

Một nguồn được bảo vệ bằng mật khẩu phải được mở thành công trước khi các slide của nó có thể được sao chép. Cung cấp mật khẩu qua [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Làm việc với bản trình bày đã giải mã.
} finally {
    source.dispose();
}
```

Mở một nguồn được mã hoá không tự động áp dụng cùng một bảo vệ cho bản trình bày đích. Cấu hình bảo vệ đầu ra riêng biệt khi cần.

### **Bản Trình Bày Lớn và Sử Dụng Bộ Nhớ**

Các bản trình bày lớn chứa hình ảnh độ phân giải cao, âm thanh, video hoặc các đối tượng nhị phân lớn khác có thể tiêu tốn đáng kể bộ nhớ. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) cung cấp các điều chỉnh cho việc xử lý BLOB và sử dụng tệp tạm. Xem [Manage Presentation BLOBs](/slides/vi/java/manage-blob/) để biết chiến lược cho tệp lớn.

Đối với tệp lớn, ưu tiên tải từ đường dẫn tệp khi có thể, giải phóng mỗi bản trình bày nguồn ngay sau khi đã hợp nhất, và tránh lưu kết quả trung gian liên tục trừ khi quy trình yêu cầu các checkpoint.

### **An Toàn Khi Đa Luồng**

Không tải, sửa đổi, lưu hoặc sao chép cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) đồng thời từ nhiều luồng. Giữ mỗi thể hiện bản trình bày trong một thao tác hợp nhất duy nhất. Nếu bạn thực hiện các công việc độc lập song song, hãy sử dụng các thể hiện bản trình bày độc lập và tuân thủ [hướng dẫn đa luồng của Aspose.Slides](/slides/vi/java/multithreading/).

## **Câu Hỏi Thường Gặp**

**Làm sao tôi giữ nguyên thiết kế gốc của mỗi bản trình bày nguồn?**

Sử dụng [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) mà không cung cấp master hoặc layout đích. Aspose.Slides có thể tự động sao chép master nguồn khi slide được nhập cần nó.

**Làm sao để các slide nhập vào sử dụng theme của đích?**

Sử dụng overload nhận master đích. Cung cấp một master từ bản trình bày đích, không phải từ nguồn. Aspose.Slides sẽ cố gắng ánh xạ mỗi slide nguồn tới một layout phù hợp dưới master đó.

**Khi nào nên dùng layout đích cụ thể thay vì master đích?**

Dùng layout cụ thể khi mọi slide nhập vào phải sử dụng một layout đã biết. Dùng master khi bạn muốn Aspose.Slides tự chọn giữa các layout của master đó dựa trên loại hoặc tên layout nguồn.

**Có thể hợp nhất các bản trình bày có kích thước slide khác nhau không?**

Có, nhưng nội dung slide sẽ không tự động được thiết kế lại cho kích thước đích. Hãy thay đổi kích thước bản trình bày nguồn trước khi sao chép, ví dụ bằng [SlideSize.setSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidesize/#setSize-float-float-int-) và [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidesizescaletype/).

**Tôi có thể hợp nhất các tệp PPT, PPTX và ODP thành một tệp không?**

Có. Tải mỗi bản trình bày nguồn, sao chép các slide cần thiết vào một bản đích, và lưu bản đích ở định dạng đầu ra được hỗ trợ. Vì các định dạng trình bày không hỗ trợ đầy đủ các tính năng giống nhau, hãy kiểm tra nội dung phức tạp sau khi hợp nhất đa định dạng. Xem [Supported File Formats](/slides/vi/java/supported-file-formats/).

**Các section nguồn có được giữ tự động không?**

Không, nếu chỉ dùng vòng lặp cơ bản sao chép slide. Hãy tạo lại các section cần thiết trong bản đích và sử dụng overload section của [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) khi cấu trúc section phải được bảo lưu.

**Ghi chú và bình luận có được giữ không?**

Chúng được sao chép cùng với slide đã sao chép. Đối với quy trình phụ thuộc vào kiểu dáng master ghi chú, tác giả bình luận hoặc dữ liệu duyệt có chuỗi, hãy kiểm tra kết quả hợp nhất vì những kịch bản này liên quan đến cấu trúc cấp trình bày cũng như nội dung slide.

**Âm thanh, video, đối tượng OLE và liên kết siêu văn bản sẽ như thế nào?**

Nội dung nhúng sẽ được mang theo như một phần của các quan hệ tài nguyên của slide đã sao chép. Liên kết bên ngoài vẫn vẫn là liên kết bên ngoài, vì vậy các tệp hoặc URL mục tiêu vẫn phải tồn tại sau khi hợp nhất.

**Các phông chữ nhúng từ mọi nguồn có được đảm bảo có trong bản trình bày hợp nhất không?**

Không nên dựa vào việc sao chép slide duy nhất để triển khai phông chữ. Hãy kiểm tra phông chữ nhúng của bản đích và quản lý việc nhúng phông chữ hoặc tính sẵn có của phông chữ bên ngoài một cách rõ ràng khi kiểu chữ quan trọng.

**Làm sao tôi hợp nhất một tệp được bảo vệ bằng mật khẩu?**

Mở nó với [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) đúng, sau đó sao chép các slide như bình thường. Bảo vệ đầu ra được cấu hình riêng.

**Tôi nên xử lý các bản trình bày rất lớn như thế nào?**

Sử dụng quản lý BLOB khi các đối tượng nhị phân lớn chiếm ưu thế trong việc sử dụng bộ nhớ, ưu tiên tải từ đường dẫn tệp cho các tệp rất lớn, giải phóng nhanh các bản trình bày nguồn, và lưu kết quả cuối cùng chỉ khi cần.

**Tôi có thể hợp nhất slide từ nhiều luồng không?**

Không sử dụng cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) đồng thời từ nhiều luồng. Giữ mỗi thao tác hợp nhất biệt lập trong các thể hiện bản trình bày riêng biệt.