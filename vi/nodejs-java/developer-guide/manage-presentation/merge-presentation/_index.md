---
title: Hiệu quả hợp nhất các bản trình bày trong JavaScript
linktitle: Hợp nhất các bản trình bày
type: docs
weight: 40
url: /vi/nodejs-java/merge-presentation/
keywords:
- hợp nhất PowerPoint
- hợp nhất các bản trình bày
- hợp nhất slide
- hợp nhất PPT
- hợp nhất PPTX
- hợp nhất ODP
- kết hợp PowerPoint
- kết hợp các bản trình bày
- kết hợp slide
- kết hợp PPT
- kết hợp PPTX
- kết hợp ODP
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách hợp nhất các bản trình bày PowerPoint và OpenDocument trong JavaScript bằng cách sao chép slide, điều khiển master và layout, thay đổi kích thước nội dung slide, bảo tồn các section, và xử lý các tệp được bảo vệ hoặc lớn."
---
## **Overview**

Aspose.Slides for Node.js via Java hợp nhất các bản trình bày bằng cách sao chép các slide từ một [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) sang bản khác. Hoạt động chính là [SlideCollection.addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), có thể giữ nguyên định dạng của slide nguồn hoặc gắn slide đã sao chép vào một master hoặc layout trong bản trình bày đích.

Bài viết này bao gồm các quy trình hợp nhất phổ biến nhất:

- hợp nhất tất cả các slide đồng thời giữ nguyên định dạng nguồn;
- hợp nhất các slide đã chọn;
- áp dụng một master từ bản trình bày đích;
- áp dụng một layout cụ thể từ bản trình bày đích;
- chuẩn hoá các kích thước slide khác nhau trước khi hợp nhất;
- thêm các slide đã sao chép vào một section;
- hợp nhất nhiều bản trình bày trong một quy trình đầu‑cuối;
- xử lý master, tài nguyên, ghi chú, bình luận, media, phông chữ, mật khẩu, tệp lớn và các vấn đề đa luồng.

## **How Slide Cloning Affects Masters and Layouts**

Một slide kế thừa rất nhiều về giao diện từ layout và master của nó. Vì lý do đó, phương thức sao chép (overload) bạn chọn sẽ quyết định cách slide đã hợp nhất được tích hợp vào bản trình bày đích.

Sử dụng [SlideCollection.addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/) theo một trong các cách sau:

- `addClone(sourceSlide)` — giữ nguyên layout và định dạng của slide nguồn. Khi cần, master nguồn có thể được sao chép tự động vào bản trình bày đích. Aspose.Slides tự động theo dõi các master đã sao chép để các slide lặp lại sử dụng cùng một master không gây sao chép lại master đó.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — gán slide đã sao chép vào một [MasterSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/) đích cụ thể. Aspose.Slides sẽ tìm layout phù hợp dưới master đó theo kiểu hoặc tên layout.
- `addClone(sourceSlide, destinationLayout)` — gán slide đã sao chép trực tiếp vào một [LayoutSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/) đích cụ thể.

Master hoặc layout được truyền vào overload `addClone` phải thuộc **bản trình bày đích**, không phải bản trình bày nguồn.

## **Merge Entire Presentations and Preserve Source Formatting**

Cách hợp nhất đơn giản nhất là sao chép mỗi slide từ bản trình bày nguồn sang bản trình bày đích. Đây là lựa chọn phù hợp khi các slide được nhập khẩu cần giữ nguyên theme, master và quan hệ layout gốc.

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

## **Merge Selected Slides**

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

Hãy kiểm tra chỉ mục slide trước khi sao chép khi chúng đến từ đầu vào người dùng hoặc cấu hình bên ngoài.

## **Merge Slides Using a Destination Master**

Sử dụng overload [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) khi các slide được nhập khẩu cần tuân theo một master đã thuộc về bản trình bày đích.

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

Aspose.Slides sẽ chọn một layout phù hợp dưới master chỉ định bằng cách khớp kiểu hoặc tên layout nguồn. Nếu không tồn tại layout thích hợp và `allowCloneMissingLayout` là `true`, layout nguồn sẽ được sao chép để slide có thể được thêm. Nếu `false`, một [PptxEditException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxeditexception/) sẽ được ném ra.

Sử dụng `false` khi bạn muốn quá trình hợp nhất thất bại thay vì đưa một layout bổ sung vào master đích.

## **Merge Slides Using a Specific Destination Layout**

Sử dụng overload [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) khi bạn biết chính xác layout đích nào mà các slide nhập khẩu nên sử dụng.

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

Áp dụng một layout đích thay đổi mối quan hệ layout kế thừa; nó không làm lại thiết kế nội dung slide nguồn. Nếu layout nguồn và đích có cấu trúc placeholder khác nhau, hãy kiểm tra kết quả để xác nhận định dạng và hành vi placeholder được duy trì hợp lý.

## **Merge Presentations with Different Slide Sizes**

Các bản trình bày có kích thước slide khác nhau có thể được hợp nhất, nhưng sao chép một slide vào bản trình bày có kích thước slide khác không tự động thiết kế lại nội dung cho canvas mới. Do đó các shape có thể bị dịch chuyển, thu phóng bất ngờ hoặc nằm ngoài vùng hiển thị.

Một cách thực tiễn là thay đổi kích thước bản trình bày nguồn trước khi sao chép. Phương thức [SlideSize.setSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) có thể thu phóng nội dung hiện có đồng thời thay đổi kích thước slide. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesizescaletype/) thu phóng nội dung để vừa với kích thước yêu cầu.

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

Việc thay đổi kích thước thay đổi đối tượng bản trình bày nguồn trong bộ nhớ. Nếu bạn cần giữ bản trình bày nguồn nguyên trạng cho các thao tác khác, hãy mở một thể hiện riêng cho quá trình hợp nhất.

## **Merge Slides into a Presentation Section**

Vòng lặp sao chép slide cơ bản không tái tạo cấu trúc section của bản trình bày nguồn. Nếu section quan trọng trong kết quả, hãy tạo hoặc chọn các section trong bản trình bày đích và sao chép slide vào chúng một cách rõ ràng bằng [addClone(Slide, Section)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

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

Các slide đã sao chép sẽ được nối vào section đích đã chỉ định. Để bảo tồn nhiều section nguồn, hãy duyệt [Presentation.getSections](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getSections), lấy danh sách slide hiện tại của mỗi section nguồn bằng [Section.getSlidesListOfSection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/section/#getSlidesListOfSection), tạo lại các section trong bản đích và sao chép từng slide vào section đích tương ứng. Xem [Manage Slide Sections](/slides/vi/nodejs-java/slide-section/) để biết ví dụ đầy đủ về việc liệt kê section, bao gồm các section trống và thay đổi cấu trúc.

## **Merge Multiple Presentations Safely**

Ví dụ cuối‑cùng dưới đây sử dụng bản trình bày đầu tiên làm đích, chuẩn hoá kích thước slide của mỗi nguồn bổ sung, chỉ mở mỗi nguồn khi đang sao chép và lưu tệp cuối cùng một lần.

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

Đây là nền tảng hữu ích để giữ nguyên định dạng nguồn của các slide được nhập. Nếu đầu ra của bạn phải dùng một theme duy nhất, hãy thay thế lời gọi `addClone(sourceSlide)` đơn giản bằng overload master hoặc layout đích đã trình bày ở trên.

## **Practical Considerations**

### **Masters, Layouts, and Formatting Fidelity**

Sao chép slide mặc định có thể tự động mang một master nguồn cần thiết vào bản trình bày đích. Aspose.Slides duy trì một bảng đăng ký nội bộ cho các master được sao chép tự động để tránh sao chép cùng một master nhiều lần. Các master được sao chép thủ công không được theo dõi bởi bảng đăng ký này, do đó hãy tránh sao chép trước các master trừ khi bạn cần kiểm soát rõ ràng cấu trúc master.

Đừng cho rằng hai master hoặc layout có cùng tên sẽ hiển thị giống nhau. Nếu mẫu công ty phải kiểm soát giao diện cuối cùng, hãy chọn một master hoặc layout đích một cách rõ ràng và xác minh kết quả sau khi hợp nhất.

### **Notes and Comments**

Ghi chú trình bày và bình luận slide được gắn với nội dung slide và sẽ được sao chép khi một slide được sao chép. Aspose.Slides cũng cung cấp các API chuyên dụng cho [presentation notes](/slides/vi/nodejs-java/presentation-notes/) và [presentation comments](/slides/vi/nodejs-java/presentation-comments/).

Nếu định dạng trang ghi chú quan trọng, hãy kiểm tra bản trình bày đã hợp nhất vì notes master là đối tượng cấp bản trình bày và có thể khác nhau giữa các tệp nguồn. Đối với quy trình duyệt, cũng hãy kiểm tra tác giả bình luận và các chuỗi bình luận sau khi ghép các tệp từ các tác giả hoặc mẫu khác nhau.

### **Images, Audio, Video, OLE Objects, and External Links**

Slide có thể tham chiếu tới các tài nguyên cấp bản trình bày như hình ảnh, âm thanh nhúng, video nhúng và dữ liệu OLE. Hãy sao chép toàn bộ slide thay vì chỉ sao chép các shape hiển thị để Aspose.Slides có thể duy trì các quan hệ của slide tới tài nguyên.

Tài nguyên nhúng và tài nguyên liên kết cần được xử lý khác nhau. Một audio, video, OLE object hoặc hyperlink liên kết sẽ vẫn phụ thuộc vào mục tiêu bên ngoài; sao chép slide không biến một liên kết bên ngoài thành nội dung nhúng. Kiểm tra đường dẫn và URL của tài nguyên liên kết trong môi trường mà bản trình bày hợp nhất sẽ được mở.

Aspose.Slides theo dõi các master được sao chép tự động, nhưng điều này không đồng nghĩa với việc mọi tài nguyên nhị phân giống nhau từ các nguồn không liên quan sẽ luôn được gộp lại. Nếu kích thước tệp đầu ra quan trọng, hãy kiểm tra gói đã hợp nhất và đo kết quả thay vì dựa vào việc gộp ngầm.

### **Embedded Fonts and Font Availability**

Phông chữ được quản lý ở cấp bản trình bày. Nếu kiểu chữ phải nhất quán trên các máy, đừng cho rằng chỉ sao chép slide sẽ đảm bảo mọi phông cần thiết đã có trong môi trường đích. Bạn có thể kiểm tra phông nhúng bằng [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) và quản lý việc nhúng một cách rõ ràng như mô tả trong [Embed Fonts in Presentations](/slides/vi/nodejs-java/embedded-font/).

Cũng hãy xác minh rằng bạn được phép nhúng các phông chữ được sử dụng bởi các tệp nguồn. Giấy phép phông chữ có thể hạn chế việc nhúng.

### **Password-Protected Presentations**

Một nguồn được bảo mật bằng mật khẩu phải được mở thành công trước khi các slide của nó có thể được sao chép. Cung cấp mật khẩu qua [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // Làm việc với bản trình bày đã giải mã.
} finally {
    source.dispose();
}
```

Mở một nguồn đã mã hoá không tự động áp dụng cùng một bảo mật cho bản trình bày đích. Hãy cấu hình bảo mật đầu ra riêng khi cần.

### **Large Presentations and Memory Use**

Các bản trình bày lớn chứa hình ảnh độ phân giải cao, âm thanh, video hoặc các đối tượng nhị phân lớn khác có thể tiêu tốn đáng kể bộ nhớ. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) cung cấp các tùy chọn kiểm soát BLOB và việc sử dụng tệp tạm. Xem [Manage Presentation BLOBs](/slides/vi/nodejs-java/manage-blob/) để biết chiến lược cho tệp lớn.

Đối với tệp lớn, ưu tiên tải từ đường dẫn tệp khi có thể, giải phóng mỗi bản trình bày nguồn ngay sau khi đã hợp nhất và tránh lưu kết quả trung gian lặp lại trừ khi quy trình yêu cầu checkpoint.

### **Thread Safety**

Không tải, lưu hoặc sao chép một [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) trong nhiều luồng đồng thời. Các thao tác này không được hỗ trợ cho môi trường đa luồng. Nếu bạn cần thực hiện các công việc hợp nhất độc lập song song, hãy sử dụng nhiều tiến trình đơn luồng, mỗi tiến trình có các thể hiện Presentation riêng, và tuân thủ [hướng dẫn đa luồng của Aspose.Slides](/slides/vi/nodejs-java/multithreading/).

## **FAQ**

**How do I keep each source presentation's original design?**

Sử dụng [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) mà không cung cấp master hoặc layout đích. Aspose.Slides có thể tự động sao chép master nguồn khi slide nhập khẩu cần nó.

**How do I make imported slides use the destination theme?**

Sử dụng overload chấp nhận master đích. Cung cấp một master từ bản trình bày đích, không phải từ nguồn. Aspose.Slides sẽ cố gắng ánh xạ mỗi slide nguồn tới một layout phù hợp dưới master này.

**When should I use a specific destination layout instead of a destination master?**

Sử dụng layout cụ thể khi mọi slide nhập khẩu phải dùng một layout đã biết. Sử dụng master khi bạn muốn Aspose.Slides tự chọn layout trong master đó dựa trên kiểu hoặc tên layout nguồn.

**Can presentations with different slide sizes be merged?**

Có, nhưng nội dung slide không được thiết kế lại tự động cho kích thước đích. Hãy thay đổi kích thước bản trình bày nguồn trước khi sao chép, ví dụ bằng [SlideSize.setSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) và [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesizescaletype/).

**Can I merge PPT, PPTX, and ODP presentations into one file?**

Có. Tải mỗi bản trình bày nguồn, sao chép các slide cần thiết vào một bản đích và lưu bản đích ở định dạng đầu ra được hỗ trợ. Vì các định dạng bản trình bày không hỗ trợ đầy đủ các tính năng giống nhau, hãy kiểm tra nội dung phức tạp sau khi hợp nhất đa định dạng. Xem [Supported File Formats](/slides/vi/nodejs-java/supported-file-formats/).

**Are source sections preserved automatically?**

Không, khi chỉ dùng vòng lặp cơ bản sao chép slide. Hãy tạo lại các section cần thiết trong bản đích và sử dụng overload section của [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) khi cấu trúc section phải được bảo tồn.

**Are speaker notes and comments preserved?**

Chúng được sao chép cùng với slide đã sao chép. Đối với quy trình phụ thuộc vào styling của notes‑master, tác giả bình luận hoặc dữ liệu duyệt có chuỗi, hãy xác minh kết quả vì các trường hợp này liên quan đến cấu trúc cấp bản trình bày cũng như nội dung cấp slide.

**What happens to audio, video, OLE objects, and hyperlinks?**

Nội dung nhúng sẽ được mang theo như một phần của các quan hệ tài nguyên của slide đã sao chép. Các liên kết bên ngoài vẫn sẽ là liên kết bên ngoài, vì vậy tệp hoặc URL mục tiêu phải còn khả dụng sau khi hợp nhất.

**Are embedded fonts from every source guaranteed to be available in the merged presentation?**

Đừng dựa vào việc sao chép slide đơn thuần để triển khai phông chữ. Hãy kiểm tra phông nhúng của bản đích và quản lý việc nhúng phông hoặc khả năng truy cập phông bên ngoài một cách rõ ràng khi kiểu chữ quan trọng.

**How do I merge a password-protected file?**

Mở nó bằng [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setPassword-String-), sau đó sao chép các slide như bình thường. Bảo mật đầu ra được cấu hình riêng.

**How should I handle very large presentations?**

Sử dụng quản lý BLOB khi các đối tượng nhị phân lớn chiếm phần lớn bộ nhớ, ưu tiên tải từ đường dẫn tệp cho các tệp rất lớn, giải phóng bản trình bày nguồn kịp thời và lưu kết quả cuối cùng chỉ khi cần.

**Can I merge slides from multiple threads?**

Không tải, lưu hoặc sao chép các thể hiện Presentation trong nhiều luồng đồng thời. Đối với các công việc hợp nhất song song, hãy dùng các tiến trình đơn luồng riêng biệt và các thể hiện Presentation độc lập.