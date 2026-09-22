---
title: Truy xuất và Cập nhật Thông tin Bản trình bày trong JavaScript
linktitle: Thông tin Bản trình bày
type: docs
weight: 30
url: /vi/nodejs-java/examine-presentation/
keywords:
- định dạng bản trình bày
- thuộc tính bản trình bày
- thuộc tính tài liệu
- lấy thuộc tính
- đọc thuộc tính
- thay đổi thuộc tính
- sửa đổi thuộc tính
- cập nhật thuộc tính
- kiểm tra PPTX
- kiểm tra PPT
- kiểm tra ODP
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá các slide, cấu trúc và siêu dữ liệu trong các bản trình bày PowerPoint và OpenDocument bằng JavaScript để có cái nhìn nhanh hơn và kiểm toán nội dung thông minh hơn."
---
## **Tổng quan**

Aspose.Slides có thể xác định định dạng của một bản trình bày và đọc siêu dữ liệu tài liệu mà không cần tạo mô hình đối tượng bản trình bày đầy đủ. Điều này hữu ích khi bạn cần phân loại tệp, xây dựng một danh mục, hoặc kiểm tra các thuộc tính trước khi quyết định có tải và xử lý nội dung bản trình bày hay không.

Bài viết này trình bày cách kiểm tra nhẹ nhàng thông qua [PresentationFactory](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationfactory/) và [PresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/), cũng như cập nhật có mục tiêu thông qua [DocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/).

## **Kiểm tra định dạng bản trình bày**

Nếu bạn đã có một bản trình bày đã tải, hãy xem [Determine the Original Presentation Format](/slides/vi/nodejs-java/detect-presentation-source-format/) để phát hiện sau khi tải và các hạn chế của các luồng PPT, PPS và POT cổ điển.

Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) để kiểm tra tệp mà không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) . Phương thức [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/getloadformat/) báo cáo định dạng được phát hiện, chẳng hạn PPTX, PPT hoặc ODP.

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **Xây dựng danh mục bản trình bày nhẹ**

Khi bạn xử lý nhiều tệp bản trình bày, bạn có thể cần một danh mục gọn nhẹ để xác thực, lập chỉ mục hoặc cho hệ thống quản lý tài liệu. Trong trường hợp này, sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) để lấy một đối tượng [PresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/), sau đó gọi [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) để đọc siêu dữ liệu tài liệu. Cách tiếp cận này không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) và không yêu cầu bạn duyệt toàn bộ mô hình đối tượng bản trình bày.

Các thuộc tính mở rộng được cung cấp bởi [DocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/) cung cấp các giá trị danh mục sau:

| Phương thức | Giá trị danh mục |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getSlides) | Tổng số slide. |
| [getHiddenSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | Số slide ẩn. |
| [getNotes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getNotes) | Số slide có ghi chú. |
| [getParagraphs](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | Tổng số đoạn, nếu có. |
| [getWords](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getWords) | Tổng số từ. |
| [getMultimediaClips](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | Tổng số đoạn âm thanh và video. |

Ví dụ dưới đây đọc các giá trị này mà không tạo một đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) và in ra một danh mục gọn nhẹ. Nó cũng kết hợp [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) với [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) để hiển thị các nhóm nội dung như phông chữ, chủ đề và tiêu đề slide.

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

Mỗi [HeadingPair](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/headingpair/) cung cấp tên nhóm thông qua [HeadingPair.getName](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/headingpair/#getName) và số lượng mục trong nhóm qua [HeadingPair.getCount](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/headingpair/#getCount). [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) trả về một mảng phẳng, có thứ tự, vì vậy hãy tiêu thụ số tiêu đề liên tiếp được chỉ định bởi mỗi heading pair.

### **Siêu dữ liệu đã lưu và các hạn chế định dạng**

Các thuộc tính danh mục được trả về bởi [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) phản ánh siêu dữ liệu có sẵn trong tài liệu nguồn. Aspose.Slides không tải và duyệt mô hình đối tượng bản trình bày để tính lại các giá trị này cho lần gọi này. Các thuộc tính thiếu được biểu diễn bằng các giá trị mặc định, và các giá trị đã lưu có thể lỗi thời nếu ứng dụng lưu tệp lần cuối không cập nhật các thuộc tính tài liệu.

- **PPTX:** Định dạng cung cấp các thuộc tính tài liệu mở rộng cho số slide, ghi chú, slide ẩn, đoạn, từ và đa phương tiện, cũng như các heading pair và tiêu đề phần. Tính khả dụng phụ thuộc vào các thuộc tính mà nhà sản xuất tài liệu đã ghi.
- **PPT:** Định dạng nhị phân có thể lưu các thuộc tính tóm tắt tài liệu tương ứng. Nếu một thuộc tính vắng mặt hoặc không được nhà sản xuất tài liệu làm mới, Aspose.Slides sẽ trả về giá trị đã lưu hoặc mặc định thay vì tính toán từ các slide.
- **ODP:** Siêu dữ liệu OpenDocument cung cấp các thống kê chung của tài liệu, chẳng hạn số trang, đoạn và từ, nhưng các giá trị này không khớp với mọi thuộc tính mở rộng đặc thù của PowerPoint. Siêu dữ liệu slide ẩn, slide ghi chú, đa phương tiện, heading‑pair và tiêu đề phần có thể không có, và các thuộc tính danh mục có thể trả về giá trị mặc định. Đừng coi một giá trị zero hoặc một mảng rỗng là bằng chứng chắc chắn rằng nội dung tương ứng không tồn tại.

Sử dụng cách tiếp cận siêu dữ liệu nhẹ cho các danh mục và kiểm tra sơ bộ. Tải bản trình bày và kiểm tra mô hình đối tượng trực tiếp khi kết quả phải phản ánh các thay đổi trong bộ nhớ hoặc khi bạn cần xác minh nội dung thực tế của bản trình bày.

## **Cập nhật thuộc tính bản trình bày**

Các thuộc tính được trả về bởi [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) cũng có thể được thay đổi mà không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) . Áp dụng các thay đổi bằng [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/), sau đó ghi bản trình bày đã ràng buộc bằng [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/).

Hình ảnh dưới đây hiển thị các thuộc tính tài liệu gốc của bản trình bày PowerPoint:

![Thuộc tính tài liệu gốc của bản trình bày PowerPoint](input_properties.png)

Ví dụ dưới đây thay đổi tiêu đề và thời gian lưu lần cuối và ghi kết quả vào một tệp mới:

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

Hình ảnh dưới đây hiển thị các thuộc tính tài liệu đã cập nhật của bản trình bày PowerPoint:

![Thuộc tính tài liệu đã thay đổi của bản trình bày PowerPoint](output_properties.png)

## **Liên kết hữu ích**

Đối với các kiểm tra bảo mật liên quan và cài đặt bảo vệ, xem các bài viết sau:

- [Bảo vệ bản trình bày bằng mật khẩu](/slides/vi/nodejs-java/password-protected-presentation/)
- [Bảo vệ bản trình bày khi ghi](/slides/vi/nodejs-java/write-protected-presentation/)

## **Câu hỏi thường gặp**

**Làm thế nào để kiểm tra xem phông chữ đã được nhúng hay chưa và chúng là những phông nào?**

Tải bản trình bày và sử dụng [Presentation.getFontsManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getfontsmanager/). Gọi [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) để lấy các phông chữ đã nhúng và [FontsManager.getFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/getfonts/) để lấy các phông chữ được bản trình bày sử dụng. So sánh hai kết quả để tìm các phông chữ cần thiết cho việc render nhưng chưa được nhúng.

**Làm thế nào để nhanh chóng xác định tệp có slide ẩn không và có bao nhiêu?**

Khi siêu dữ liệu tài liệu lưu trữ đủ, đọc [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) thông qua [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) và [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/). Điều này phù hợp cho một danh mục nhẹ. Nếu bản trình bày đã được sửa đổi trong bộ nhớ, siêu dữ liệu lưu trữ có thể thiếu hoặc lỗi thời, hoặc bạn cần xác minh giá trị thực tế, hãy duyệt qua [Presentation.getSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getslides/) và kiểm tra phương thức [Slide.getHidden](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/gethidden/) của mỗi slide.

**Tôi có thể phát hiện kích thước và hướng slide tùy chỉnh có được sử dụng không, và chúng có khác so với mặc định không?**

Có. Tải bản trình bày và gọi [Presentation.getSlideSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getslidesize/). Sử dụng [SlideSize.getType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesize/getsize/) và [SlideSize.getOrientation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesize/getorientation/) để so sánh cài đặt hiện tại với preset và kích thước dự kiến.

**Có cách nhanh để xem biểu đồ có tham chiếu nguồn dữ liệu bên ngoài không?**

Có. Xác định mỗi [Chart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/) và gọi [ChartData.getDataSourceType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/getdatasourcetype/). Đối với workbook bên ngoài, gọi [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Kiểu nguồn dữ liệu và đường dẫn xác định một tham chiếu bên ngoài, nhưng việc xác minh liệu mục tiêu có sẵn hay không cần một kiểm tra tài nguyên riêng.

**Làm thế nào để đánh giá các slide 'nặng' có thể làm chậm quá trình render hoặc xuất PDF?**

Không có thuộc tính phức tạp duy nhất. Duyệt [Presentation.getSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getslides/) và bộ sưu tập [BaseSlide.getShapes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslide/#getShapes) của mỗi slide. Sử dụng số lượng hình dạng và sự hiện diện của hình ảnh lớn, hiệu ứng, hoạt ảnh hoặc đa phương tiện làm tín hiệu sàng lọc, và đo một lần render hoặc export đại diện trước khi xác định một slide là nút thắt hiệu năng thực sự.