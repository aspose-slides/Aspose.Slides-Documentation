---
title: Truy xuất và Cập nhật Thông tin Bản trình chiếu trên Android
linktitle: Thông tin bản trình chiếu
type: docs
weight: 30
url: /vi/androidjava/examine-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Khám phá các slide, cấu trúc và siêu dữ liệu trong các bản trình chiếu PowerPoint và OpenDocument bằng Java để có cái nhìn nhanh hơn và đánh giá nội dung thông minh hơn."
---
## **Tổng quan**

Aspose.Slides có thể xác định định dạng của một bản trình chiếu và đọc siêu dữ liệu tài liệu mà không cần tạo một mô hình đối tượng bản trình chiếu đầy đủ. Điều này hữu ích khi bạn cần phân loại tệp, xây dựng danh mục, hoặc kiểm tra các thuộc tính trước khi quyết định tải và xử lý nội dung bản trình chiếu.

Bài viết này minh họa việc kiểm tra nhẹ bằng [PresentationFactory](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationfactory/) và [IPresentationInfo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationinfo/), cũng như cập nhật có mục tiêu qua [IDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idocumentproperties/).

## **Kiểm tra định dạng bản trình chiếu**

Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) để kiểm tra một tệp mà không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/). Phương thức [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) báo cáo định dạng được phát hiện, chẳng hạn PPTX, PPT hoặc ODP.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **Xây dựng danh mục bài thuyết trình nhẹ**

Khi bạn xử lý nhiều tệp bản trình chiếu, có thể bạn cần một danh mục gọn để xác thực, lập chỉ mục hoặc cho hệ thống quản lý tài liệu. Trong trường hợp này, sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) để lấy một đối tượng [IPresentationInfo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationinfo/), sau đó gọi [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) để đọc siêu dữ liệu tài liệu. Cách tiếp cận này không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) và không yêu cầu bạn duyệt qua toàn bộ mô hình đối tượng bản trình chiếu.

Các thuộc tính mở rộng được cung cấp bởi [IDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idocumentproperties/) cung cấp các giá trị danh mục sau:

| Phương thức | Giá trị tồn kho |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | Tổng số slide. |
| [getHiddenSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Số slide ẩn. |
| [getNotes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | Số slide có ghi chú. |
| [getParagraphs](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | Tổng số đoạn văn, nếu có. |
| [getWords](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | Tổng số từ. |
| [getMultimediaClips](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Tổng số clip âm thanh và video. |

Ví dụ sau đọc các giá trị này mà không tạo một đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) và in ra một danh mục gọn. Nó cũng kết hợp [getHeadingPairs](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) với [getTitlesOfParts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) để hiển thị các nhóm nội dung như phông chữ, giao diện và tiêu đề slide.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

Mỗi [IHeadingPair](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iheadingpair/) cung cấp một tên nhóm và số lượng mục trong nhóm đó. Phương thức [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) trả về một mảng phẳng, có thứ tự, vì vậy hãy tiêu thụ số tiêu đề liên tiếp được chỉ định bởi mỗi heading pair.

### **Siêu dữ liệu được lưu và giới hạn định dạng**

Các thuộc tính danh mục được trả về bởi [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) phản ánh siêu dữ liệu có sẵn trong tài liệu nguồn. Aspose.Slides không tải và duyệt mô hình đối tượng bản trình chiếu để tính lại các giá trị này cho lời gọi này. Các thuộc tính thiếu được biểu thị bằng giá trị mặc định, và các giá trị đã lưu có thể lỗi thời nếu ứng dụng lưu tệp lần cuối không cập nhật thuộc tính tài liệu.

- **PPTX:** Định dạng này cung cấp các thuộc tính tài liệu mở rộng cho số slide, ghi chú, slide ẩn, đoạn văn, từ và clip đa phương tiện, cùng với các heading pair và tiêu đề phần. Tính khả dụng phụ thuộc vào các thuộc tính mà nhà sản xuất tài liệu đã ghi.
- **PPT:** Định dạng nhị phân có thể lưu các thuộc tính tóm tắt tài liệu tương ứng. Nếu một thuộc tính không tồn tại hoặc không được nhà sản xuất tài liệu làm mới, Aspose.Slides trả về giá trị đã lưu hoặc giá trị mặc định thay vì tính toán từ các slide.
- **ODP:** Siêu dữ liệu OpenDocument cung cấp thống kê chung của tài liệu, chẳng hạn số trang, đoạn văn và từ, nhưng các giá trị này không ánh xạ tới mọi thuộc tính mở rộng đặc thù của PowerPoint. Siêu dữ liệu slide ẩn, ghi chú, đa phương tiện, heading‑pair và tiêu đề phần có thể không khả dụng, và các thuộc tính danh mục có thể trả về giá trị mặc định. Đừng coi giá trị zero hoặc mảng rỗng là bằng chứng chắc chắn rằng nội dung tương ứng không tồn tại.

Sử dụng cách tiếp cận siêu dữ liệu nhẹ cho danh mục và kiểm tra sơ bộ. Tải bản trình chiếu và kiểm tra mô hình đối tượng sống khi kết quả phải phản ánh các thay đổi trong bộ nhớ hoặc khi bạn cần xác minh nội dung thực tế của bản trình chiếu.

## **Cập nhật thuộc tính bản trình chiếu**

Các thuộc tính trả về bởi [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) cũng có thể được thay đổi mà không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) nào. Áp dụng các thay đổi bằng [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), sau đó ghi bản trình chiếu đã ràng buộc bằng [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

Hình ảnh sau hiển thị các thuộc tính tài liệu gốc.

![Original document properties of the PowerPoint presentation](input_properties.png)

Ví dụ sau thay đổi tiêu đề và thời gian lưu cuối cùng và ghi kết quả vào một tệp mới:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

Hình ảnh sau hiển thị các thuộc tính tài liệu đã được cập nhật.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Liên kết hữu ích**

Đối với các kiểm tra bảo mật và cài đặt bảo vệ liên quan, xem các bài viết sau:

- [Password-Protect Presentations](/slides/vi/androidjava/password-protected-presentation/)
- [Write-Protect Presentations](/slides/vi/androidjava/write-protected-presentation/)

## **Câu hỏi thường gặp**

**Làm thế nào để kiểm tra xem phông chữ có được nhúng và chúng là gì?**

Tải bản trình chiếu và sử dụng [Presentation.getFontsManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getFontsManager--). Gọi [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) để lấy các phông chữ đã nhúng và [IFontsManager.getFonts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) để lấy các phông chữ được sử dụng trong bản trình chiếu. So sánh hai kết quả để tìm các phông chữ cần thiết cho việc render nhưng chưa được nhúng.

**Làm sao để nhanh chóng biết tệp có slide ẩn và có bao nhiêu?**

Khi siêu dữ liệu tài liệu lưu trữ đủ, đọc [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) thông qua [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) và [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). Cách này phù hợp cho một danh mục nhẹ. Nếu bản trình chiếu đã được sửa đổi trong bộ nhớ, siêu dữ liệu lưu có thể thiếu hoặc lỗi thời, hoặc bạn cần xác minh giá trị thực, hãy duyệt qua [Presentation.getSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getSlides--) và kiểm tra phương thức [ISlide.getHidden](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/#getHidden--) của từng slide.

**Tôi có thể phát hiện xem kích thước và hướng slide tùy chỉnh có được sử dụng và có khác với mặc định không?**

Có. Tải bản trình chiếu và gọi [Presentation.getSlideSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getSlideSize--). Sử dụng [ISlideSize.getType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidesize/#getSize--) và [ISlideSize.getOrientation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidesize/#getOrientation--) để so sánh cài đặt hiện tại với cấu hình và kích thước mặc định.

**Có cách nhanh để xem biểu đồ có tham chiếu nguồn dữ liệu bên ngoài không?**

Có. Xác định mỗi [Chart](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chart/) và gọi [IChartData.getDataSourceType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--). Đối với một workbook bên ngoài, gọi [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--). Kiểu nguồn dữ liệu và đường dẫn cho biết có tham chiếu bên ngoài, nhưng việc xác minh nguồn có sẵn cần kiểm tra tài nguyên riêng.

**Làm sao tôi có thể đánh giá các slide 'nặng' có thể làm chậm việc render hoặc xuất PDF?**

Không có thuộc tính phức tạp duy nhất. Duyệt [Presentation.getSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getSlides--) và bộ sưu tập [IBaseSlide.getShapes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibaseslide/#getShapes--) của mỗi slide. Dùng số lượng hình dạng và sự hiện diện của hình ảnh lớn, hiệu ứng, hoạt ảnh hoặc đa phương tiện như tín hiệu sàng lọc, và đo một lần render hoặc export mẫu trước khi coi một slide là điểm thắt hiệu năng đã được xác nhận.