---
title: Hợp nhất Hiệu quả Các Bản Trình Bày trong JavaScript
linktitle: Hợp Nhất Bản Trình Bày
type: docs
weight: 40
url: /vi/nodejs-java/merge-presentation/
keywords:
- hợp nhất PowerPoint
- hợp nhất bản trình bày
- hợp nhất slide
- hợp nhất PPT
- hợp nhập PPTX
- hợp nhập ODP
- kết hợp PowerPoint
- kết hợp bản trình bày
- kết hợp slide
- kết hợp PPT
- kết hợp PPTX
- kết hợp ODP
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách hợp nhất các bản trình bày PowerPoint và OpenDocument trong JavaScript bằng cách sao chép slide, kiểm soát master và layout, thay đổi kích thước nội dung slide, bảo toàn các section, và xử lý các tệp được bảo vệ hoặc lớn."
---
## **Tổng quan**

Aspose.Slides for Node.js via Java hợp nhất các bản trình bày bằng cách sao chép các slide từ một [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) sang bản khác. Hoạt động chính là [SlideCollection.addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), cho phép giữ nguyên định dạng của slide nguồn hoặc gắn slide đã sao chép vào một master hoặc layout trong bản trình bày đích.

Bài viết này bao gồm các quy trình hợp nhất thường gặp nhất:

- hợp nhất tất cả các slide đồng thời giữ định dạng nguồn;
- hợp nhất các slide đã chọn;
- áp dụng master từ bản trình bày đích;
- áp dụng một layout cụ thể từ bản trình bày đích;
- chuẩn hoá các kích thước slide khác nhau trước khi hợp nhất;
- thêm các slide đã sao chép vào một section;
- hợp nhất nhiều bản trình bày trong một quy trình đầu‑cuối;
- xử lý master, tài nguyên, ghi chú, bình luận, media, phông chữ, mật khẩu, tệp lớn và các vấn đề đa luồng.

## **Cách sao chép Slide ảnh hưởng đến Master và Layout**

Một slide kế thừa phần lớn ngoại hình từ layout và master của nó. Vì vậy, overload sao chép bạn chọn sẽ quyết định cách slide đã hợp nhất được tích hợp vào bản trình bày đích.

Sử dụng [SlideCollection.addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/) theo một trong các cách sau:

- `addClone(sourceSlide)` — giữ nguyên layout và định dạng của slide nguồn. Khi cần, master nguồn có thể tự động được sao chép vào bản trình bày đích. Aspose.Slides tự động theo dõi các master đã sao chép để các slide lặp lại sử dụng cùng một master nguồn không gây sao chép lại master đó nhiều lần.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — gắn slide đã sao chép vào một [MasterSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/) đích cụ thể. Aspose.Slides sẽ tìm layout khớp dưới master đó theo kiểu layout hoặc tên.
- `addClone(sourceSlide, destinationLayout)` — gắn slide đã sao chép trực tiếp vào một [LayoutSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/) đích cụ thể.

Master hoặc layout được truyền vào overload `addClone` phải thuộc về **bản trình bày đích**, không phải bản trình bày nguồn.

## **Hợp nhất toàn bộ Bản trình bày và Giữ Định dạng Nguồn**

Cách hợp nhất đơn giản nhất là sao chép mọi slide từ bản trình bày nguồn sang bản trình bày đích. Đây là lựa chọn phù hợp khi các slide nhập vào cần giữ nguyên chủ đề, master và quan hệ layout ban đầu.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Kết quả có thể chứa nhiều master khi nguồn và đích sử dụng các thiết kế khác nhau. Điều này là mong đợi khi định dạng nguồn được cố ý giữ lại.

## **Hợp nhất các Slide Đã Chọn**

Bạn không cần sao chép mọi slide. Ví dụ dưới đây chỉ nhập các chỉ mục slide đã chọn từ bản trình bày nguồn.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Hãy xác thực các chỉ mục slide trước khi sao chép khi chúng đến từ đầu vào của người dùng hoặc cấu hình bên ngoài.

## **Hợp nhất Slide bằng Master Đích**

Sử dụng overload [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) khi các slide nhập vào cần tuân theo một master đã thuộc về bản trình bày đích.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides sẽ chọn một layout phù hợp dưới master được chỉ định bằng cách khớp kiểu hoặc tên của layout nguồn. Nếu không có layout thích hợp và `allowCloneMissingLayout` là `true`, layout nguồn sẽ được sao chép để slide có thể được thêm. Nếu `false`, một [PptxEditException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxeditexception/) sẽ được ném ra.

Sử dụng `false` khi bạn muốn quá trình hợp nhất thất bại thay vì tạo thêm một layout vào master đích.

## **Hợp nhất Slide bằng Layout Đích Cụ Thể**

Sử dụng overload [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) khi bạn biết chính xác layout đích mà các slide nhập vào nên sử dụng.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Áp dụng một layout đích thay đổi quan hệ layout được kế thừa; nó không thay đổi thiết kế nội dung slide nguồn. Nếu layout nguồn và đích có cấu trúc placeholder khác nhau, hãy kiểm tra kết quả để xác nhận rằng định dạng và hành vi placeholder kế thừa là phù hợp.

## **Hợp nhất Bản trình bày có Kích thước Slide Khác nhau**

Các bản trình bày có kích thước slide khác nhau có thể được hợp nhất, nhưng sao chép một slide vào bản trình bày có kích thước slide khác sẽ không tự động thiết kế lại nội dung cho canvas mới. Vì vậy các shape có thể bị dịch chuyển, thu phóng không mong muốn, hoặc nằm ngoài khu vực hiển thị của slide.

Một cách thực tế là thay đổi kích thước bản trình bày nguồn trước khi sao chép. Phương pháp [SlideSize.setSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) có thể phóng to/thu nhỏ nội dung hiện có đồng thời thay đổi kích thước slide. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesizescaletype/) sẽ co giãn nội dung để vừa với kích thước yêu cầu.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Thay đổi kích thước sẽ sửa đổi đối tượng bản trình bày nguồn trong bộ nhớ. Nếu bạn cần giữ bản trình bày nguồn gốc không thay đổi cho các thao tác khác, hãy mở một thể hiện riêng cho quá trình hợp nhất.

## **Hợp nhất Slide vào Section của Bản trình bày**

Vòng lặp sao chép slide cơ bản không tái tạo cấu trúc section của bản trình bày nguồn. Nếu section quan trọng trong đầu ra, hãy tạo hoặc chọn các section trong bản trình bày đích và sao chép slide vào chúng một cách rõ ràng bằng [addClone(Slide, Section)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Các slide đã sao chép sẽ được nối vào section đích đã chỉ định. Để giữ lại nhiều section nguồn, hãy tạo lại các section đó trong bản đích và ánh xạ mỗi slide nguồn tới section đích tương ứng.

## **Hợp nhất Nhiều Bản trình bày một cách An toàn**

Ví dụ toàn diện dưới đây sử dụng bản trình bày đầu tiên làm đích, chuẩn hoá kích thước slide của mỗi nguồn bổ sung, giữ mỗi nguồn mở chỉ trong thời gian sao chép và lưu tệp cuối cùng một lần.

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Đây là một nền tảng hữu ích để giữ định dạng nguồn của các slide nhập vào. Nếu đầu ra của bạn phải sử dụng một chủ đề đích duy nhất, hãy thay thế lời gọi đơn giản `addClone(sourceSlide)` bằng overload master hoặc layout đích đã trình bày ở trên.

## **Các lưu ý thực tế**

### **Master, Layout và Độ chính xác Định dạng**

Sao chép slide mặc định có thể tự động đưa master nguồn cần thiết vào bản trình bày đích. Aspose.Slides duy trì một danh sách nội bộ cho các master được sao chép tự động nhằm tránh sao chép lại cùng một master nhiều lần. Các master được sao chép thủ công không được theo dõi trong danh sách này, vì vậy tránh sao chép trước các master trừ khi bạn cần kiểm soát cấu trúc master một cách rõ ràng.

Đừng cho rằng hai master hoặc layout cùng tên sẽ hiển thị giống nhau. Nếu một mẫu công ty phải kiểm soát ngoại hình cuối cùng, hãy chọn một master hoặc layout đích một cách rõ ràng và xác minh kết quả sau khi hợp nhất.

### **Ghi chú và Bình luận**

Ghi chú người thuyết trình và bình luận slide được liên kết với nội dung slide và sẽ được sao chép khi slide được sao chép. Aspose.Slides cũng cung cấp các API riêng cho [presentation notes](https://docs.aspose.com/slides/vi/nodejs-java/presentation-notes/) và [presentation comments](https://docs.aspose.com/slides/vi/nodejs-java/presentation-comments/).

Nếu định dạng trang ghi chú quan trọng, hãy kiểm tra bản trình bày hợp nhất vì master ghi chú là đối tượng cấp độ bản trình bày và có thể khác nhau giữa các tệp nguồn. Đối với quy trình đánh giá, cũng cần xác minh tác giả bình luận và chuỗi bình luận sau khi hợp nhất các tệp từ các tác giả hoặc mẫu khác nhau.

### **Hình ảnh, Âm thanh, Video, Đối tượng OLE và Liên kết Ngoài**

Slide có thể tham chiếu tới các tài nguyên cấp độ bản trình bày như hình ảnh, âm thanh nhúng, video nhúng và dữ liệu OLE. Hãy sao chép toàn bộ slide thay vì chỉ sao chép các shape hiển thị để Aspose.Slides có thể duy trì các quan hệ của slide tới tài nguyên của nó.

Các tài nguyên nhúng và liên kết cần được xử lý khác nhau. Một âm thanh, video, đối tượng OLE hoặc siêu liên kết được liên kết vẫn phụ thuộc vào mục tiêu bên ngoài; sao chép slide không biến một liên kết ngoài thành nội dung nhúng. Hãy kiểm tra đường dẫn và URL của tài nguyên liên kết trong môi trường nơi bản trình bày hợp nhất sẽ được mở.

Aspose.Slides theo dõi các master được sao chép tự động, nhưng điều này không đồng nghĩa với việc bất kỳ tài nguyên nhị phân giống nhau nào từ các bản trình bày nguồn không liên quan sẽ luôn được loại bỏ trùng lặp. Nếu kích thước tệp đầu ra quan trọng, hãy kiểm tra gói hợp nhất và đo kích thước kết quả thay vì dựa vào việc loại bỏ trùng lặp ngầm.

### **Phông chữ Nhúng và Tính khả dụng của Phông chữ**

Phông chữ được quản lý ở cấp độ bản trình bày. Nếu kiểu chữ phải đồng nhất trên các máy, đừng cho rằng sao chép slide một mình sẽ đảm bảo mọi phông chữ cần thiết đã có trong môi trường đích. Bạn có thể kiểm tra phông chữ nhúng bằng [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) và quản lý việc nhúng một cách rõ ràng như mô tả trong [Embed Fonts in Presentations](https://docs.aspose.com/slides/vi/nodejs-java/embedded-font/).

Cũng cần xác minh rằng bạn được phép nhúng các phông chữ được sử dụng trong các tệp nguồn. Giấy phép phông chữ có thể hạn chế việc nhúng.

### **Bản trình bày được Bảo vệ bằng Mật khẩu**

Một nguồn được bảo vệ bằng mật khẩu phải được mở thành công trước khi các slide của nó có thể được sao chép. Cung cấp mật khẩu qua [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // Làm việc với bản trình bày đã được giải mã.
} finally {
    source.dispose();
}
```

Mở một nguồn được mã hoá không tự động áp dụng cùng một bảo vệ cho bản trình bày đích. Hãy cấu hình bảo vệ đầu ra riêng biệt khi cần.

### **Bản trình bày Lớn và Sử dụng Bộ nhớ**

Các bản trình bày lớn chứa hình ảnh độ phân giải cao, âm thanh, video hoặc các đối tượng nhị phân lớn khác có thể tiêu tốn đáng kể bộ nhớ. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) cung cấp các tùy chọn kiểm soát việc xử lý BLOB và sử dụng tệp tạm. Xem [Manage Presentation BLOBs](https://docs.aspose.com/slides/vi/nodejs-java/manage-blob/) để biết chiến lược cho tệp lớn.

Đối với tệp lớn, ưu tiên tải từ đường dẫn tệp khi có thể, giải phóng mỗi bản trình bày nguồn ngay sau khi đã hợp nhất, và tránh lưu lại các kết quả trung gian trừ khi quy trình yêu cầu điểm checkpoint.

### **An toàn Đa luồng**

Không tải, lưu hoặc sao chép một thể hiện [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) trong nhiều luồng đồng thời. Những thao tác này không được hỗ trợ cho đa luồng. Nếu bạn cần thực hiện các công việc hợp nhất độc lập song song, hãy dùng nhiều quá trình đơn luồng, mỗi quá trình có các thể hiện bản trình bày riêng, và tuân thủ [hướng dẫn đa luồng của Aspose.Slides](https://docs.aspose.com/slides/vi/nodejs-java/multithreading/).

## **FAQ**

**Làm sao để giữ nguyên thiết kế gốc của mỗi bản trình bày nguồn?**

Sử dụng [`addClone(sourceSlide)`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) mà không cung cấp master hoặc layout đích. Aspose.Slides có thể tự động sao chép master nguồn khi slide nhập vào cần nó.

**Làm sao để các slide nhập vào sử dụng chủ đề đích?**

Sử dụng overload chấp nhận master đích. Cung cấp một master từ bản trình bày đích, không phải từ nguồn. Aspose.Slides sẽ cố gắng ánh xạ mỗi slide nguồn tới một layout phù hợp dưới master đó.

**Khi nào nên dùng layout đích cụ thể thay vì master đích?**

Dùng layout cụ thể khi mọi slide nhập vào phải sử dụng một layout đã biết. Dùng master khi muốn Aspose.Slides tự chọn layout trong master đó dựa trên kiểu hoặc tên của layout nguồn.

**Có thể hợp nhất các bản trình bày có kích thước slide khác nhau không?**

Có, nhưng nội dung slide sẽ không tự động được thiết kế lại cho kích thước đích. Hãy thay đổi kích thước bản trình bày nguồn trước khi sao chép, ví dụ bằng [SlideSize.setSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) và [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesizescaletype/).

**Có thể hợp nhất các tệp PPT, PPTX và ODP thành một file không?**

Có. Tải mỗi bản trình bày nguồn, sao chép các slide cần thiết vào một bản đích, và lưu bản đích ở định dạng hỗ trợ. Vì các định dạng bản trình bày không hỗ trợ đầy đủ cùng một bộ tính năng, hãy xác minh nội dung phức tạp sau khi hợp nhất đa định dạng. Xem [Supported File Formats](https://docs.aspose.com/slides/vi/nodejs-java/supported-file-formats/).

**Các section nguồn có được giữ tự động không?**

Không, nếu chỉ dùng vòng lặp cơ bản sao chép slide. Hãy tạo lại các section cần thiết trong bản đích và sử dụng overload section của [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) khi cấu trúc section phải được bảo lưu.

**Ghi chú và bình luận có được giữ lại không?**

Chúng được sao chép cùng với slide đã sao chép. Đối với quy trình phụ thuộc vào kiểu dáng master ghi chú, tác giả bình luận hoặc dữ liệu đánh giá chuỗi, hãy xác minh kết quả hợp nhất vì các trường hợp này liên quan đến cấu trúc cấp độ bản trình bày cũng như nội dung cấp độ slide.

**Điều gì xảy ra với âm thanh, video, đối tượng OLE và siêu liên kết?**

Nội dung nhúng sẽ được mang theo như một phần của các quan hệ tài nguyên của slide đã sao chép. Các liên kết ngoài vẫn ở ngoài, vì vậy các tệp hoặc URL mục tiêu phải vẫn khả dụng sau khi hợp nhất.

**Các phông chữ nhúng từ mọi nguồn có được đảm bảo có trong bản trình bày hợp nhất không?**

Không nên chỉ dựa vào sao chép slide để triển khai phông chữ. Kiểm tra phông chữ nhúng của bản đích và quản lý việc nhúng phông chữ hoặc khả năng truy cập phông chữ bên ngoài một cách rõ ràng khi kiểu chữ quan trọng.

**Làm sao để hợp nhất một tệp được bảo vệ bằng mật khẩu?**

Mở tệp bằng [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setPassword-String-), sau đó sao chép các slide như bình thường. Bảo vệ đầu ra được cấu hình riêng.

**Cần xử lý các bản trình bày rất lớn như thế nào?**

Sử dụng quản lý BLOB khi các đối tượng nhị phân lớn chiếm phần lớn bộ nhớ, ưu tiên tải từ đường dẫn tệp cho các tệp cực lớn, giải phóng nhanh các bản trình bày nguồn, và lưu kết quả cuối cùng chỉ khi cần.

**Có thể hợp nhất slide từ nhiều luồng không?**

Không tải, lưu hoặc sao chép các thể hiện bản trình bày trong nhiều luồng đồng thời. Đối với các công việc hợp nhất song song, hãy dùng các tiến trình đơn luồng riêng biệt và các thể hiện bản trình bày độc lập.