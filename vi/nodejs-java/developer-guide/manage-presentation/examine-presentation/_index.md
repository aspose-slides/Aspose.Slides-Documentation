---
title: Truy xuất và Cập nhật Thông tin Bản trình chiếu trong JavaScript
linktitle: Thông tin Bản trình chiếu
type: docs
weight: 30
url: /vi/nodejs-java/examine-presentation/
keywords:
- định dạng bản trình chiếu
- thuộc tính bản trình chiếu
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
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá các slide, cấu trúc và siêu dữ liệu trong các bản trình chiếu PowerPoint và OpenDocument bằng JavaScript để có cái nhìn nhanh hơn và kiểm tra nội dung thông minh hơn."
---
## **Tổng quan**

Aspose.Slides có thể xác định định dạng của một bản trình chiếu và đọc siêu dữ liệu tài liệu mà không cần tạo mô hình đối tượng bản trình chiếu hoàn chỉnh. Điều này hữu ích khi bạn cần phân loại tệp, xây dựng một danh mục, hoặc kiểm tra các thuộc tính trước khi quyết định có tải và xử lý nội dung bản trình chiếu hay không.

Bài viết này trình bày cách kiểm tra nhẹ nhàng thông qua [PresentationFactory](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationfactory/) và [PresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/), cũng như các cập nhật có mục tiêu thông qua [DocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/).

## **Kiểm tra định dạng bản trình chiếu**

Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) để kiểm tra một tệp mà không cần tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/). Phương thức [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/getloadformat/) trả về định dạng được phát hiện, ví dụ như PPTX, PPT hoặc ODP.

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

## **Xây dựng danh mục bản trình chiếu nhẹ**

Khi bạn xử lý nhiều tệp bản trình chiếu, bạn có thể cần một danh mục gọn nhẹ để xác thực, lập chỉ mục, hoặc cho hệ thống quản lý tài liệu. Trong trường hợp này, sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) để lấy một đối tượng [PresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/), sau đó gọi [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) để đọc siêu dữ liệu tài liệu. Cách tiếp cận này không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) và không yêu cầu bạn phải duyệt toàn bộ mô hình đối tượng bản trình chiếu.

Các thuộc tính mở rộng được [DocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/) cung cấp các giá trị danh mục sau:

| Phương thức | Giá trị danh mục |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getSlides) | Tổng số slide. |
| [getHiddenSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | Số slide ẩn. |
| [getNotes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getNotes) | Số slide có ghi chú. |
| [getParagraphs](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | Tổng số đoạn văn, nếu có. |
| [getWords](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getWords) | Tổng số từ. |
| [getMultimediaClips](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | Tổng số clip âm thanh và video. |

Ví dụ sau đọc các giá trị này mà không tạo đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) và in ra một danh mục gọn nhẹ. Nó cũng kết hợp [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) với [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) để hiển thị các nhóm nội dung như phông chữ, giao diện và tiêu đề slide.

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

Mỗi [HeadingPair](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/headingpair/) cung cấp một tên nhóm thông qua [HeadingPair.getName](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/headingpair/#getName) và số lượng mục trong nhóm đó qua [HeadingPair.getCount](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/headingpair/#getCount). [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) trả về một mảng phẳng, có thứ tự, vì vậy hãy tiêu thụ số lượng tiêu đề liên tiếp được chỉ định bởi mỗi cặp tiêu đề.

### **Siêu dữ liệu đã lưu và giới hạn định dạng**

Các thuộc tính danh mục được [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) trả về phản ánh siêu dữ liệu có trong tài liệu nguồn. Aspose.Slides không tải và duyệt mô hình đối tượng bản trình chiếu để tính lại các giá trị này cho lời gọi này. Các thuộc tính thiếu được biểu thị bằng các giá trị mặc định, và các giá trị đã lưu có thể đã lỗi thời nếu ứng dụng lưu tệp lần cuối không cập nhật các thuộc tính tài liệu.

- **PPTX:** Định dạng cung cấp các thuộc tính tài liệu mở rộng cho số lượng slide, ghi chú, slide ẩn, đoạn văn, từ và đa phương tiện, cũng như các cặp tiêu đề và tiêu đề phần. Tính khả dụng phụ thuộc vào các thuộc tính mà nhà sản xuất tài liệu đã ghi.
- **PPT:** Định dạng nhị phân có thể lưu các thuộc tính tóm tắt tài liệu tương ứng. Nếu một thuộc tính không có hoặc không được nhà sản xuất tài liệu làm mới, Aspose.Slides sẽ trả về giá trị đã lưu hoặc mặc định thay vì tính toán từ các slide.
- **ODP:** Siêu dữ liệu OpenDocument cung cấp các thống kê tài liệu chung, như số trang, đoạn văn và từ, nhưng các giá trị này không tương ứng với mọi thuộc tính mở rộng riêng của PowerPoint. Siêu dữ liệu slide ẩn, slide ghi chú, đa phương tiện, cặp tiêu đề và tiêu đề phần có thể không khả dụng, và các thuộc tính danh mục có thể trả về giá trị mặc định. Không coi giá trị không hoặc mảng rỗng là bằng chứng chắc chắn rằng nội dung tương ứng không tồn tại.

Sử dụng cách tiếp cận siêu dữ liệu nhẹ cho việc tạo danh mục và kiểm tra sơ bộ. Tải bản trình chiếu và kiểm tra mô hình đối tượng động của nó khi kết quả cần phản ánh các thay đổi trong bộ nhớ hoặc khi bạn cần xác minh nội dung thực tế của bản trình chiếu.

## **Cập nhật thuộc tính bản trình chiếu**

Các thuộc tính được [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) trả về cũng có thể được thay đổi mà không cần tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/). Áp dụng các thay đổi bằng [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/), sau đó ghi bản trình chiếu đã ràng buộc bằng [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/).

Hình ảnh sau hiển thị các thuộc tính tài liệu gốc của bản trình chiếu PowerPoint:

![Các thuộc tính tài liệu gốc của bản trình chiếu PowerPoint](input_properties.png)

Ví dụ sau thay đổi tiêu đề và thời gian lưu lần cuối và ghi kết quả vào một tệp mới:

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

Hình ảnh sau hiển thị các thuộc tính tài liệu đã cập nhật của bản trình chiếu PowerPoint:

![Các thuộc tính tài liệu đã cập nhật của bản trình chiếu PowerPoint](output_properties.png)

## **Liên kết hữu ích**

Đối với các kiểm tra bảo mật và cài đặt bảo vệ liên quan, xem các bài viết sau:

- [Bảo mật bằng mật khẩu cho bản trình chiếu](/slides/vi/nodejs-java/password-protected-presentation/)
- [Bảo vệ bằng ghi cho bản trình chiếu](/slides/vi/nodejs-java/write-protected-presentation/)

## **Câu hỏi thường gặp**

**Làm cách nào để kiểm tra xem phông chữ có được nhúng hay không và chúng là những phông chữ nào?**

Tải bản trình chiếu và sử dụng [Presentation.getFontsManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getfontsmanager/). Gọi [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) để lấy các phông chữ đã nhúng và [FontsManager.getFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/getfonts/) để lấy các phông chữ được sử dụng trong bản trình chiếu. So sánh hai kết quả để tìm các phông chữ cần thiết cho việc hiển thị nhưng chưa được nhúng.

**Làm sao nhanh chóng xác định tệp có slide ẩn hay không và bao nhiêu?**

Khi siêu dữ liệu tài liệu đã lưu đủ, đọc [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) thông qua [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) và [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/). Cách này phù hợp cho một danh mục nhẹ. Nếu bản trình chiếu đã được sửa đổi trong bộ nhớ, siêu dữ liệu đã lưu có thể thiếu hoặc lỗi thời, hoặc bạn cần xác minh các giá trị động, hãy duyệt qua [Presentation.getSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getslides/) và kiểm tra phương thức [Slide.getHidden](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/gethidden/) của mỗi slide.

**Tôi có thể phát hiện xem kích thước và hướng slide tùy chỉnh có được sử dụng không, và chúng có khác so với mặc định không?**

Có. Tải bản trình chiếu và gọi [Presentation.getSlideSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getslidesize/). Sử dụng [SlideSize.getType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesize/getsize/), và [SlideSize.getOrientation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesize/getorientation/) để so sánh các cài đặt hiện tại với các cấu hình và kích thước dự kiến.

**Có cách nhanh để kiểm tra biểu đồ có tham chiếu nguồn dữ liệu bên ngoài không?**

Có. Tìm mỗi [Chart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/) và gọi [ChartData.getDataSourceType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/getdatasourcetype/). Đối với một workbook bên ngoài, gọi [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Loại nguồn dữ liệu và đường dẫn xác định tham chiếu bên ngoài, nhưng việc kiểm tra xem mục tiêu có tồn tại hay không cần một kiểm tra tài nguyên riêng.

**Làm sao tôi có thể đánh giá các slide 'nặng' có thể làm chậm việc render hoặc xuất PDF?**

Không có một thuộc tính độ phức tạp duy nhất. Duyệt [Presentation.getSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getslides/) và bộ sưu tập [BaseSlide.getShapes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslide/#getShapes) của mỗi slide. Sử dụng số lượng hình dạng và sự hiện diện của hình ảnh lớn, hiệu ứng, hoạt ảnh hoặc đa phương tiện như các tín hiệu sàng lọc, và đo một lần render hoặc export đại diện trước khi coi một slide là nút thắt hiệu năng đã xác nhận.