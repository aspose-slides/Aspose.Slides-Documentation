---
title: Hiệu quả Hợp Nhất Bài Thuyết Trình trên Android
linktitle: Hợp Nhất Bài Thuyết Trình
type: docs
weight: 40
url: /vi/androidjava/merge-presentation/
keywords:
- hợp nhất PowerPoint
- hợp nhất bài thuyết trình
- hợp nhất slide
- hợp nhất PPT
- hợp nhất PPTX
- hợp nhất ODP
- kết hợp PowerPoint
- kết hợp bài thuyết trình
- kết hợp slide
- kết hợp PPT
- kết hợp PPTX
- kết hợp ODP
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách hợp nhất các bài thuyết trình PowerPoint và OpenDocument trên Android bằng cách sao chép slide, kiểm soát master và layout, thay đổi kích thước nội dung slide, giữ lại các phần, và xử lý các tệp được bảo vệ hoặc có kích thước lớn."
---
## **Tổng quan**

Aspose.Slides for Android via Java hợp nhất các bài thuyết trình bằng cách sao chép các slide từ một [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) sang bài thuyết trình khác. Hoạt động chính là [ISlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), cho phép giữ nguyên định dạng của slide nguồn hoặc gắn slide đã sao chép vào một master hoặc layout trong bài thuyết trình đích.

Bài viết này bao gồm các quy trình hợp nhất phổ biến nhất:

- hợp nhất tất cả các slide trong khi giữ nguyên định dạng nguồn;
- hợp nhất các slide đã chọn;
- áp dụng một master từ bài thuyết trình đích;
- áp dụng một layout cụ thể từ bài thuyết trình đích;
- chuẩn hoá các kích thước slide khác nhau trước khi hợp nhất;
- thêm các slide đã sao chép vào một phần;
- hợp nhất nhiều bài thuyết trình trong một quy trình đầu‑cuối;
- xử lý master, tài nguyên, ghi chú, bình luận, media, phông chữ, mật khẩu, tệp lớn và các vấn đề đa luồng.

## **Cách sao chép slide ảnh hưởng đến Masters và Layouts**

Một slide kế thừa phần lớn giao diện từ layout và master của nó. Vì vậy, overload sao chép bạn chọn sẽ quyết định cách slide đã hợp nhất được tích hợp vào bài thuyết trình đích.

Sử dụng [ISlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/) theo một trong các cách sau:

- `addClone(sourceSlide)` — giữ nguyên layout và định dạng của slide nguồn. Khi cần, master nguồn có thể được sao chép tự động vào bài thuyết trình đích. Aspose.Slides theo dõi các master được sao chép tự động để các slide lặp lại sử dụng cùng master không gây sao chép master nhiều lần.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — gắn slide sao chép vào một [IMasterSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslide/) đích cụ thể. Aspose.Slides sẽ tìm layout phù hợp dưới master đó theo loại hoặc tên.
- `addClone(sourceSlide, destinationLayout)` — gắn slide sao chép trực tiếp vào một [ILayoutSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/) đích cụ thể.

Master hoặc layout được truyền vào overload `addClone` phải thuộc về **bài thuyết trình đích**, không phải bài thuyết trình nguồn.

## **Hợp nhất toàn bộ bài thuyết trình và giữ nguyên định dạng nguồn**

Cách hợp nhất đơn giản nhất sao chép mọi slide từ bài thuyết trình nguồn sang bài thuyết trình đích. Đây là lựa chọn phù hợp khi các slide nhập vào cần giữ nguyên chủ đề, master và quan hệ layout gốc.

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

Kết quả có thể chứa nhiều master khi nguồn và đích sử dụng các thiết kế khác nhau. Điều này là bình thường khi định dạng nguồn được cố ý giữ nguyên.

## **Hợp nhất các slide đã chọn**

Bạn không cần sao chép mọi slide. Ví dụ sau chỉ nhập các chỉ mục slide đã chọn từ bài thuyết trình nguồn.

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

Xác thực các chỉ mục slide trước khi sao chép khi chúng đến từ đầu vào người dùng hoặc cấu hình bên ngoài.

## **Hợp nhất slide bằng Master đích**

Sử dụng overload [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) khi các slide nhập vào nên tuân theo một master đã thuộc về bài thuyết trình đích.

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

Aspose.Slides chọn một layout phù hợp dưới master đã chỉ định bằng cách khớp loại hoặc tên của layout nguồn. Nếu không có layout thích hợp và `allowCloneMissingLayout` là `true`, layout nguồn sẽ được sao chép để slide có thể được thêm. Nếu là `false`, một [PptxEditException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxeditexception/) sẽ được ném ra.

Sử dụng `false` khi bạn muốn quá trình hợp nhất thất bại thay vì tạo thêm một layout vào master đích.

## **Hợp nhất slide bằng Layout đích cụ thể**

Sử dụng overload [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) khi bạn biết chắc layout đích nào mà các slide nhập vào nên sử dụng.

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

Áp dụng một layout đích thay đổi quan hệ layout kế thừa; nó không thiết kế lại nội dung slide nguồn. Nếu layout nguồn và đích có cấu trúc placeholder khác nhau, hãy kiểm tra kết quả để xác nhận định dạng và hành vi placeholder kế thừa là phù hợp.

## **Hợp nhất các bài thuyết trình có kích thước slide khác nhau**

Các bài thuyết trình có kích thước slide khác nhau có thể hợp nhất, nhưng sao chép một slide vào bài thuyết trình có kích thước slide khác không tự động thiết kế lại nội dung cho canvas mới. Do đó các hình dạng có thể bị dịch, co không mong muốn hoặc nằm ngoài vùng hiển thị.

Cách thực tiễn là thay đổi kích thước bài thuyết trình nguồn trước khi sao chép. Phương thức [SlideSize.setSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) có thể tỷ lệ nội dung hiện có đồng thời thay đổi kích thước slide. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidesizescaletype/) tỷ lệ nội dung để vừa với kích thước yêu cầu.

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

Thay đổi kích thước sẽ làm thay đổi đối tượng bài thuyết trình nguồn trong bộ nhớ. Nếu bạn cần giữ nguyên bản gốc cho các thao tác khác, hãy mở một thể hiện riêng cho quá trình hợp nhất.

## **Hợp nhất slide vào một phần của bài thuyết trình**

Vòng lặp sao chép slide cơ bản không tái tạo cấu trúc phần của bài thuyết trình nguồn. Nếu phần quan trọng trong kết quả, hãy tạo hoặc chọn các phần trong bài thuyết trình đích và sao chép slide vào chúng một cách rõ ràng bằng [addClone(ISlide, ISection)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

Các slide sao chép sẽ được nối vào phần đích đã chỉ định. Để giữ lại nhiều phần nguồn, hãy tái tạo các phần đó ở đích và ánh xạ mỗi slide nguồn tới phần đích tương ứng.

## **Hợp nhất nhiều bài thuyết trình một cách an toàn**

Ví dụ đầu‑cuối sau sử dụng bài thuyết trình đầu tiên làm đích, chuẩn hoá kích thước slide của mỗi nguồn bổ sung, mở mỗi nguồn chỉ trong thời gian sao chép và lưu tệp cuối cùng một lần duy nhất.

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

Đây là nền tảng hữu ích để giữ nguyên định dạng nguồn của các slide nhập vào. Nếu đầu ra của bạn phải sử dụng một chủ đề đích duy nhất, hãy thay thế lời gọi đơn giản `addClone(slide)` bằng overload master hoặc layout đích phù hợp đã trình bày ở trên.

## **Xem xét thực tiễn**

### **Masters, Layouts và Độ chính xác Định dạng**

Sao chép slide mặc định có thể tự động đưa một master nguồn cần thiết vào bài thuyết trình đích. Aspose.Slides giữ một registry nội bộ cho các master được sao chép tự động để tránh sao chép cùng một master nhiều lần. Các master được sao chép thủ công không được registry này theo dõi, vì vậy tránh sao chép trước các master trừ khi bạn cần kiểm soát rõ ràng cấu trúc master.

Không giả định rằng hai master hoặc layout có cùng tên sẽ hiển thị giống nhau. Nếu một mẫu công ty phải kiểm soát giao diện cuối cùng, hãy chọn một master hoặc layout đích một cách rõ ràng và xác minh kết quả sau khi hợp nhất.

### **Ghi chú và Bình luận**

Ghi chú người thuyết trình và bình luận slide được gắn với nội dung slide và sẽ được sao chép khi slide được sao chép. Aspose.Slides cũng cung cấp các API chuyên dụng cho [presentation notes](https://docs.aspose.com/slides/vi/androidjava/presentation-notes/) và [presentation comments](https://docs.aspose.com/slides/vi/androidjava/presentation-comments/).

Nếu định dạng trang ghi chú quan trọng, hãy kiểm tra bài thuyết trình đã hợp nhất vì master ghi chú là đối tượng cấp bài thuyết trình và có thể khác nhau giữa các tệp nguồn. Đối với quy trình xem xét, cũng hãy kiểm tra tác giả bình luận và các chuỗi bình luận sau khi ghép các tệp từ các tác giả hoặc mẫu khác nhau.

### **Hình ảnh, Audio, Video, Đối tượng OLE và Liên kết bên ngoài**

Slide có thể tham chiếu đến các tài nguyên cấp bài thuyết trình như hình ảnh, audio nhúng, video nhúng và dữ liệu OLE. Hãy sao chép toàn bộ slide thay vì chỉ sao chép các hình dạng nhìn thấy để Aspose.Slides duy trì các mối quan hệ của slide với tài nguyên.

Các tài nguyên nhúng và liên kết cần được xử lý khác nhau. Một audio, video, đối tượng OLE hoặc hyperlink liên kết vẫn phụ thuộc vào mục tiêu bên ngoài; sao chép slide không biến một liên kết bên ngoài thành nội dung nhúng. Hãy kiểm tra đường dẫn và URL của tài nguyên liên kết trong môi trường nơi bài thuyết trình hợp nhất sẽ được mở.

Aspose.Slides theo dõi rõ ràng các master được sao chép tự động, nhưng điều này không đồng nghĩa với việc bất kỳ tài nguyên nhị phân giống hệt nào từ các bài thuyết trình nguồn không liên quan luôn được loại bỏ trùng lặp. Nếu kích thước tệp đầu ra quan trọng, hãy kiểm tra gói đã hợp nhất và đo kết quả thay vì dựa vào việc loại bỏ trùng lặp ngầm.

### **Phông chữ nhúng và Khả năng sẵn có của Phông chữ**

Phông chữ được quản lý ở cấp bài thuyết trình. Nếu kiểu chữ phải đồng nhất trên các máy, không nên giả định rằng sao chép slide chỉ đảm bảo mọi phông chữ cần thiết đã có ở môi trường đích. Bạn có thể kiểm tra phông chữ nhúng bằng [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) và quản lý việc nhúng một cách rõ ràng như mô tả trong [Embed Fonts in Presentations](https://docs.aspose.com/slides/vi/androidjava/embedded-font/).

Cũng hãy xác minh rằng bạn được phép nhúng các phông chữ được sử dụng trong các tệp nguồn. Giấy phép phông chữ có thể hạn chế việc nhúng.

### **Bài thuyết trình được bảo vệ bằng mật khẩu**

Một nguồn được bảo vệ bằng mật khẩu phải được mở thành công trước khi các slide của nó có thể được sao chép. Cung cấp mật khẩu qua [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

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

Mở một nguồn đã mã hoá không tự động áp dụng cùng một bảo vệ cho bài thuyết trình đích. Cấu hình bảo vệ đầu ra riêng khi cần.

### **Bài thuyết trình lớn và Sử dụng bộ nhớ**

Các bài thuyết trình lớn chứa hình ảnh độ phân giải cao, audio, video hoặc các đối tượng nhị phân lớn khác có thể tiêu tốn bộ nhớ đáng kể. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) cung cấp các tùy chọn kiểm soát việc xử lý BLOB và sử dụng tệp tạm. Xem [Manage Presentation BLOBs](https://docs.aspose.com/slides/vi/androidjava/manage-blob/) để biết chiến lược cho tệp lớn.

Đối với tệp lớn, ưu tiên tải từ đường dẫn tệp khi có thể, giải phóng mỗi bài thuyết trình nguồn ngay khi đã được hợp nhất, và tránh lưu kết quả trung gian liên tục trừ khi quy trình yêu cầu checkpoint.

### **An toàn đa luồng**

Không tải, sửa đổi, lưu hoặc sao chép cùng một [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) đồng thời từ nhiều luồng. Giữ mỗi thể hiện bài thuyết trình trong một thao tác hợp nhất duy nhất. Nếu bạn thực hiện các công việc độc lập song song, hãy dùng các thể hiện bài thuyết trình độc lập và tuân thủ [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/vi/androidjava/multithreading/).

## **FAQ**

**Làm sao để giữ nguyên thiết kế gốc của mỗi bài thuyết trình nguồn?**

Sử dụng [`addClone(sourceSlide)`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) mà không cung cấp master hoặc layout đích. Aspose.Slides có thể tự động sao chép master nguồn khi slide nhập vào cần tới.

**Làm sao để các slide nhập vào sử dụng chủ đề của đích?**

Sử dụng overload chấp nhận một master đích. Truyền một master từ bài thuyết trình đích, không phải từ nguồn. Aspose.Slides sẽ cố gắng ánh xạ mỗi slide nguồn tới một layout phù hợp dưới master đó.

**Khi nào nên dùng layout đích cụ thể thay vì master đích?**

Dùng layout cụ thể khi mọi slide nhập vào phải sử dụng một layout đã biết. Dùng master khi bạn muốn Aspose.Slides tự chọn layout trong master đó dựa trên loại hoặc tên của layout nguồn.

**Có thể hợp nhất các bài thuyết trình có kích thước slide khác nhau không?**

Có, nhưng nội dung slide sẽ không tự động được thiết kế lại cho kích thước đích. Hãy thay đổi kích thước bài thuyết trình nguồn trước khi sao chép, ví dụ bằng [SlideSize.setSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) và [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidesizescaletype/).

**Có thể hợp nhất các tệp PPT, PPTX và ODP thành một file không?**

Có. Tải mỗi bài thuyết trình nguồn, sao chép các slide cần thiết vào một bài thuyết trình đích và lưu đích ở định dạng xuất khẩu hỗ trợ. Vì các định dạng không hỗ trợ đầy đủ tính năng giống nhau, hãy kiểm tra nội dung phức tạp sau khi hợp nhất qua định dạng khác nhau. Xem [Supported File Formats](https://docs.aspose.com/slides/vi/androidjava/supported-file-formats/).

**Các phần nguồn có được giữ lại tự động không?**

Không, nếu chỉ dùng vòng lặp cơ bản sao chép slide. Hãy tái tạo các phần cần thiết ở đích và sử dụng overload phần của [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) khi cấu trúc phần phải được bảo toàn.

**Ghi chú và bình luận có được giữ lại không?**

Chúng được sao chép cùng với slide đã sao chép. Đối với quy trình phụ thuộc vào kiểu dáng master ghi chú, tác giả bình luận hoặc dữ liệu review dạng chuỗi, hãy xác minh kết quả hợp nhất vì những trường hợp này liên quan đến cấu trúc cấp bài thuyết trình cũng như nội dung slide.

**Audio, video, đối tượng OLE và hyperlink sẽ như thế nào?**

Nội dung nhúng sẽ được mang theo như một phần của các mối quan hệ tài nguyên của slide đã sao chép. Các liên kết bên ngoài vẫn còn là liên kết ngoài, vì vậy các tệp hoặc URL mục tiêu phải vẫn tồn tại sau khi hợp nhất.

**Phông chữ nhúng từ mọi nguồn có được đảm bảo có trong bài thuyết trình đã hợp nhất không?**

Không nên dựa chỉ vào sao chép slide để triển khai phông chữ. Kiểm tra phông chữ nhúng ở đích và quản lý việc nhúng hoặc khả năng sẵn có của phông chữ một cách rõ ràng khi kiểu chữ quan trọng.

**Làm sao hợp nhất một tệp được bảo vệ bằng mật khẩu?**

Mở tệp bằng [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) đúng mật khẩu, sau đó sao chép các slide như bình thường. Bảo vệ đầu ra được cấu hình riêng khi cần.

**Cần xử lý như thế nào với các bài thuyết trình rất lớn?**

Sử dụng quản lý BLOB khi các đối tượng nhị phân lớn chiếm phần lớn bộ nhớ, ưu tiên tải từ đường dẫn tệp cho các tệp rất lớn, giải phóng các bài thuyết trình nguồn ngay sau khi đã hợp nhất và lưu kết quả cuối cùng chỉ khi cần.

**Có thể hợp nhất slide từ nhiều luồng không?**

Không sử dụng cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) đồng thời từ nhiều luồng. Giữ mỗi thao tác hợp nhất độc lập trên các thể hiện bài thuyết trình riêng.