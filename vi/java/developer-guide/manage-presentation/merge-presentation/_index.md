---
title: Kết hợp các bản trình bày trong Java một cách hiệu quả
linktitle: Kết hợp các bản trình bày
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
description: "Tìm hiểu cách kết hợp các bản trình bày PowerPoint và OpenDocument trong Java bằng cách sao chép slide, kiểm soát master và layout, thay đổi kích thước nội dung slide, bảo tồn các section, và xử lý các tệp được bảo vệ hoặc có kích thước lớn."
---
## **Tổng quan**

Aspose.Slides for Java hợp nhất các bản trình bày bằng cách sao chép slide từ một [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) sang bản trình bày khác. Thao tác chính là [ISlideCollection.addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), cho phép bảo tồn định dạng của slide nguồn hoặc gắn slide đã sao chép vào một master hoặc layout trong bản trình bày đích.

Bài viết này bao gồm các quy trình hợp nhất phổ biến nhất:

- hợp nhất tất cả các slide đồng thời giữ nguyên định dạng nguồn;
- hợp nhất các slide đã chọn;
- áp dụng master từ bản trình bày đích;
- áp dụng layout cụ thể từ bản trình bày đích;
- chuẩn hoá kích thước slide khác nhau trước khi hợp nhất;
- thêm các slide đã sao chép vào một section;
- hợp nhất nhiều bản trình bày trong một quy trình đầu‑cuối;
- xử lý master, tài nguyên, ghi chú, bình luận, media, phông chữ, mật khẩu, tệp lớn và các vấn đề đa luồng.

## **Cách sao chép slide ảnh hưởng đến Master và Layout**

Một slide kế thừa phần lớn giao diện từ layout và master của nó. Vì vậy, phương thức sao chép mà bạn chọn sẽ quyết định cách slide được tích hợp vào bản trình bày đích.

Sử dụng [ISlideCollection.addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidecollection/) theo một trong các cách sau:

- `addClone(sourceSlide)` — bảo tồn layout và định dạng của slide nguồn. Khi cần, master nguồn sẽ tự động được sao chép vào bản trình bày đích. Aspose.Slides tự động theo dõi các master đã sao chép để các slide lặp lại sử dụng cùng một master nguồn không gây sao chép master nhiều lần.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — gắn slide đã sao chép vào một [IMasterSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslide/) đích cụ thể. Aspose.Slides tìm layout phù hợp dưới master đó bằng kiểu hoặc tên layout.
- `addClone(sourceSlide, destinationLayout)` — gắn slide đã sao chép trực tiếp vào một [ILayoutSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutslide/) đích cụ thể.

Master hoặc layout được truyền vào phương thức `addClone` phải thuộc về **bản trình bày đích**, không phải bản trình bày nguồn.

## **Hợp nhất toàn bộ bản trình bày và giữ nguyên định dạng nguồn**

Cách hợp nhất đơn giản nhất là sao chép mọi slide từ bản trình bày nguồn sang bản trình bày đích. Đây là lựa chọn phù hợp khi các slide được nhập cần giữ nguyên theme, master và quan hệ layout gốc.

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

Kết quả có thể chứa nhiều master khi nguồn và đích sử dụng các thiết kế khác nhau. Điều này là bình thường khi định dạng nguồn được cố ý bảo tồn.

## **Hợp nhất các slide đã chọn**

Bạn không cần sao chép mọi slide. Ví dụ dưới đây chỉ nhập các chỉ mục slide đã chọn từ bản trình bày nguồn.

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

Hãy kiểm tra chỉ mục slide trước khi sao chép khi chúng đến từ nhập liệu người dùng hoặc cấu hình bên ngoài.

## **Hợp nhất slide bằng Master đích**

Sử dụng overload [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) khi các slide nhập vào cần tuân theo một master đã tồn tại trong bản trình bày đích.

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

Aspose.Slides chọn một layout phù hợp dưới master đã chỉ định bằng cách khớp kiểu hoặc tên layout nguồn. Nếu không tìm thấy layout phù hợp và `allowCloneMissingLayout` là `true`, layout nguồn sẽ được sao chép để slide có thể được thêm. Nếu `false`, một [PptxEditException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptxeditexception/) sẽ được ném ra.

Sử dụng `false` khi bạn muốn quá trình hợp nhất thất bại thay vì tự động tạo một layout bổ sung trong master đích.

## **Hợp nhất slide bằng Layout đích cụ thể**

Sử dụng overload [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) khi bạn biết chính xác layout đích mà các slide nhập vào nên sử dụng.

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

Áp dụng layout đích thay đổi quan hệ layout được kế thừa; nó không thay đổi nội dung slide nguồn. Nếu layout nguồn và đích có cấu trúc placeholder khác nhau, hãy kiểm tra kết quả để xác nhận rằng định dạng kế thừa và hành vi placeholder là phù hợp.

## **Hợp nhất bản trình bày có kích thước slide khác nhau**

Các bản trình bày có kích thước slide khác nhau có thể được hợp nhất, nhưng sao chép slide vào một bản trình bày có kích thước slide khác sẽ không tự động thiết kế lại nội dung cho canvas mới. Do đó các hình dạng có thể bị dịch, thu phóng không mong muốn hoặc nằm ngoài vùng hiển thị của slide.

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

Thay đổi kích thước sẽ làm thay đổi đối tượng bản trình bày nguồn trong bộ nhớ. Nếu bạn cần giữ bản trình bày nguồn nguyên trạng cho các thao tác khác, hãy mở một thể hiện riêng cho quá trình hợp nhất.

## **Hợp nhất slide vào một Section của bản trình bày**

Vòng lặp sao chép slide cơ bản không tái tạo cấu trúc section của bản trình bày nguồn. Nếu section quan trọng trong đầu ra, hãy tạo hoặc chọn các section trong bản trình bày đích và sao chép slide vào chúng một cách rõ ràng bằng [addClone(ISlide, ISection)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

Các slide đã sao chép sẽ được nối vào section đích đã chỉ định. Để bảo tồn nhiều section nguồn, hãy tạo lại các section đó trong bản trình bày đích và ánh xạ mỗi slide nguồn tới section đích tương ứng.

## **Hợp nhất nhiều bản trình bày một cách an toàn**

Ví dụ đầu‑cuối dưới đây sử dụng bản trình bày đầu tiên làm đích, chuẩn hoá kích thước slide của mỗi nguồn bổ sung, mở mỗi nguồn chỉ trong thời gian sao chép và lưu tệp cuối cùng một lần.

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

Đây là một nền tảng hữu ích để bảo tồn định dạng nguồn của các slide được nhập. Nếu đầu ra của bạn phải sử dụng một theme đích duy nhất, hãy thay thế lời gọi đơn giản `addClone(slide)` bằng overload master hoặc layout đích thích hợp đã mô tả ở trên.

## **Lưu ý thực tiễn**

### **Master, Layout và Độ trung thực định dạng**

Việc sao chép slide mặc định có thể tự động đưa master nguồn cần thiết vào bản trình bày đích. Aspose.Slides duy trì một registry nội bộ cho các master được sao chép tự động nhằm tránh sao chép cùng một master nhiều lần. Các master được sao chép thủ công không được theo dõi trong registry, vì vậy tránh sao chép master trước nếu không cần kiểm soát cấu trúc master một cách rõ ràng.

Đừng cho rằng hai master hoặc layout cùng tên sẽ nhìn giống nhau. Nếu một mẫu công ty phải kiểm soát giao diện cuối cùng, hãy chọn master hoặc layout đích một cách rõ ràng và xác minh kết quả sau khi hợp nhất.

### **Ghi chú và bình luận**

Ghi chú người thuyết trình và bình luận slide được gắn với nội dung slide và sẽ được sao chép khi slide được sao chép. Aspose.Slides cũng cung cấp các API riêng cho [presentation notes](https://docs.aspose.com/slides/vi/java/presentation-notes/) và [presentation comments](https://docs.aspose.com/slides/vi/java/presentation-comments/).

Nếu định dạng trang ghi chú quan trọng, hãy kiểm tra bản trình bày đã hợp nhất vì master ghi chú là đối tượng cấp độ bản trình bày và có thể khác nhau giữa các tệp nguồn. Đối với quy trình đánh giá, hãy kiểm tra tác giả bình luận và các chuỗi bình luận sau khi kết hợp các tệp từ các tác giả hoặc mẫu khác nhau.

### **Hình ảnh, âm thanh, video, OLE và liên kết ngoài**

Slide có thể tham chiếu đến các tài nguyên cấp độ bản trình bày như hình ảnh, âm thanh nhúng, video nhúng và dữ liệu OLE. Hãy sao chép toàn bộ slide thay vì chỉ sao chép các hình dạng hiển thị để Aspose.Slides có thể duy trì mối quan hệ giữa slide và các tài nguyên của nó.

Tài nguyên liên kết và tài nguyên nhúng cần được xử lý khác nhau. Một audio, video, OLE hoặc hyperlink được liên kết vẫn phụ thuộc vào mục tiêu bên ngoài; sao chép slide không biến một liên kết ngoài thành nội dung nhúng. Hãy kiểm tra đường dẫn và URL của tài nguyên liên kết trong môi trường nơi bản trình bày hợp nhất sẽ được mở.

Aspose.Slides theo dõi các master được sao chép tự động, nhưng điều này không đồng nghĩa với việc tất cả các tài nguyên nhị phân giống nhau từ các bản trình bày nguồn không liên quan sẽ luôn được loại bỏ trùng lặp. Nếu kích thước tệp đầu ra quan trọng, hãy kiểm tra gói đã hợp nhất và đo kích thước thay vì dựa vào việc loại bỏ trùng lặp ngầm.

### **Phông chữ nhúng và khả năng sẵn có của phông chữ**

Phông chữ được quản lý ở mức độ bản trình bày. Nếu kiểu chữ phải giữ nhất quán trên các máy, đừng cho rằng chỉ sao chép slide sẽ đảm bảo mọi phông chữ cần thiết đã có sẵn trong môi trường đích. Bạn có thể kiểm tra phông chữ nhúng bằng [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) và quản lý việc nhúng một cách rõ ràng như mô tả trong [Embed Fonts in Presentations](https://docs.aspose.com/slides/vi/java/embedded-font/).

Cũng cần xác minh bạn được phép nhúng các phông chữ được sử dụng trong các tệp nguồn. Giấy phép phông chữ có thể hạn chế việc nhúng.

### **Bản trình bày có bảo vệ bằng mật khẩu**

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

### **Bản trình bày lớn và việc sử dụng bộ nhớ**

Các bản trình bày lớn chứa hình ảnh độ phân giải cao, âm thanh, video hoặc các đối tượng nhị phân lớn khác có thể tiêu tốn nhiều bộ nhớ. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) cung cấp các tùy chọn kiểm soát việc xử lý BLOB và sử dụng tệp tạm thời. Xem [Manage Presentation BLOBs](https://docs.aspose.com/slides/vi/java/manage-blob/) để biết chiến lược cho tệp lớn.

Đối với tệp lớn, ưu tiên tải từ đường dẫn tệp khi có thể, giải phóng mỗi bản trình bày nguồn ngay sau khi đã hợp nhất, và tránh lưu kết quả trung gian nhiều lần trừ khi quy trình yêu cầu checkpoint.

### **An toàn đa luồng**

Không tải, chỉnh sửa, lưu hoặc sao chép cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) đồng thời từ nhiều luồng. Giữ mỗi thể hiện bản trình bày trong một thao tác hợp nhất duy nhất. Nếu bạn thực hiện các công việc độc lập song song, hãy dùng các thể hiện bản trình bày độc lập và tuân theo hướng dẫn [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/vi/java/multithreading/).

## **Câu hỏi thường gặp**

**Làm sao giữ nguyên thiết kế gốc của mỗi bản trình bày nguồn?**

Sử dụng [`addClone(sourceSlide)`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) mà không cung cấp master hoặc layout đích. Aspose.Slides có thể tự động sao chép master nguồn khi slide nhập vào cần nó.

**Làm sao để các slide nhập vào sử dụng theme đích?**

Sử dụng overload chấp nhận master đích. Cung cấp một master từ bản trình bày đích, không phải từ nguồn. Aspose.Slides sẽ cố gắng ánh xạ mỗi slide nguồn tới một layout phù hợp dưới master đó.

**Khi nào nên dùng layout đích cụ thể thay vì master đích?**

Dùng layout cụ thể khi mọi slide nhập vào phải sử dụng một layout đã biết. Dùng master khi bạn muốn Aspose.Slides tự chọn layout trong master đó dựa trên kiểu hoặc tên layout nguồn.

**Có thể hợp nhất các bản trình bày có kích thước slide khác nhau không?**

Có, nhưng nội dung slide sẽ không tự động được thiết kế lại cho kích thước đích. Hãy thay đổi kích thước bản trình bày nguồn trước khi sao chép, ví dụ bằng [SlideSize.setSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidesize/#setSize-float-float-int-) và [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidesizescaletype/).

**Có thể hợp nhất các tệp PPT, PPTX và ODP thành một tệp không?**

Có. Tải mỗi bản trình bày nguồn, sao chép các slide cần thiết vào một bản trình bày đích, và lưu bản trình bày đích ở định dạng xuất ra hỗ trợ. Vì các định dạng bản trình bày không hỗ trợ đầy đủ cùng một bộ tính năng, hãy xác minh nội dung phức tạp sau khi hợp nhất đa định dạng. Xem [Supported File Formats](https://docs.aspose.com/slides/vi/java/supported-file-formats/).

**Các section nguồn có được bảo tồn tự động không?**

Không, đối với vòng lặp cơ bản chỉ sao chép slide. Hãy tạo lại các section cần thiết trong bản trình bày đích và sử dụng overload section của [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) khi cấu trúc section phải được duy trì.

**Ghi chú và bình luận có được bảo tồn không?**

Chúng được sao chép cùng với slide đã sao chép. Đối với quy trình phụ thuộc vào kiểu dáng master ghi chú, tác giả bình luận hoặc dữ liệu review dạng chuỗi, hãy xác minh kết quả hợp nhất vì các kịch bản này liên quan đến cấu trúc cấp độ bản trình bày cũng như nội dung slide.

**Điều gì xảy ra với audio, video, OLE và hyperlink?**

Nội dung nhúng sẽ được mang theo như một phần của các mối quan hệ tài nguyên của slide đã sao chép. Các liên kết ngoài vẫn ngoài, vì vậy các tệp hoặc URL mục tiêu phải vẫn khả dụng sau khi hợp nhất.

**Các phông chữ nhúng từ mọi nguồn có được đảm bảo có trong bản trình bày đã hợp nhất không?**

Đừng dựa vào việc sao chép slide để triển khai phông chữ. Kiểm tra các phông chữ nhúng trong bản trình bày đích và quản lý việc nhúng phông chữ hoặc tính sẵn có của phông chữ bên ngoài một cách rõ ràng khi typographic quan trọng.

**Làm sao hợp nhất một tệp được bảo vệ bằng mật khẩu?**

Mở tệp bằng [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), sau đó sao chép các slide như bình thường. Bảo vệ đầu ra được cấu hình riêng biệt.

**Làm sao xử lý các bản trình bày rất lớn?**

Sử dụng quản lý BLOB khi các đối tượng nhị phân lớn chiếm phần lớn bộ nhớ, ưu tiên tải từ đường dẫn tệp cho các tệp rất lớn, giải phóng nhanh các bản trình bày nguồn, và chỉ lưu kết quả cuối cùng khi cần.

**Có thể hợp nhất slide từ nhiều luồng không?**

Không dùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) đồng thời từ nhiều luồng. Giữ mỗi thao tác hợp nhất riêng biệt trong các thể hiện bản trình bày của riêng nó.