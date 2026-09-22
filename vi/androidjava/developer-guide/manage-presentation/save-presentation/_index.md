---
title: Lưu bản trình chiếu trên Android
linktitle: Lưu bản trình chiếu
type: docs
weight: 80
url: /vi/androidjava/save-presentation/
keywords:
- lưu PowerPoint
- lưu OpenDocument
- lưu bản trình chiếu
- lưu slide
- lưu PPT
- lưu PPTX
- lưu ODP
- bản trình chiếu thành tệp
- bản trình chiếu thành luồng
- loại xem được xác định trước
- Định dạng Office Open XML Strict
- chế độ Zip64
- làm mới ảnh thu nhỏ
- tiến trình lưu
- Android
- Java
- Aspose.Slides
description: "Lưu các bản trình chiếu PowerPoint và OpenDocument vào tệp hoặc luồng trên Android với Aspose.Slides, và cấu hình đầu ra PPTX cùng báo cáo tiến độ."
---
## **Tổng quan**

Sau khi bạn tạo một bản trình chiếu hoặc [mở một bản hiện có](/slides/vi/androidjava/open-presentation/), sử dụng phương thức [Presentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) để ghi kết quả. Aspose.Slides for Android qua Java có thể lưu một bản trình chiếu vào tệp hoặc luồng dưới dạng PowerPoint, OpenDocument, PDF và các định dạng khác. Các phần sau đây đề cập đến các thao tác lưu tiêu chuẩn và các tùy chọn có sẵn cho đầu ra PPTX.

## **Lưu bản trình chiếu vào tệp**

Để lưu một bản trình chiếu vào tệp, truyền đường dẫn đầu ra và một giá trị [SaveFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveformat/) vào phương thức [Presentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Giá trị định dạng xác định loại tệp mà Aspose.Slides tạo.

Ví dụ sau tạo một bản trình chiếu và lưu nó dưới dạng tệp PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Thêm hoặc chỉnh sửa nội dung bản trình chiếu tại đây.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lưu bản trình chiếu ở định dạng gốc**

Đối với các ví dụ về phát hiện tệp và luồng, hành vi của các bản trình chiếu mới tạo, và sự phân biệt giữa định dạng nguồn và đầu ra, xem [Determine the Original Presentation Format](/slides/vi/androidjava/detect-presentation-source-format/).

Trong một ứng dụng xử lý hàng loạt, định dạng đầu vào có thể không được biết trước. Sau khi tải một tệp, đọc định dạng gốc của nó bằng phương thức [IPresentation.getSourceFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--). Truyền giá trị [SourceFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/sourceformat/) thu được vào [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) để lấy giá trị [SaveFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveformat/) tương ứng, sau đó sử dụng [Presentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) để ghi bản trình chiếu đã chỉnh sửa.

Ví dụ hoàn chỉnh sau xử lý mọi tệp trong thư mục đầu vào, cập nhật tiêu đề của chúng và lưu vào thư mục đầu ra ở định dạng mà chúng đã được tải:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) ánh xạ PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP và PowerPoint XML sang các định dạng lưu bản trình chiếu tương ứng. Nó chỉ ánh xạ các định dạng nguồn của bản trình chiếu; không được dùng để chọn các định dạng xuất như PDF, HTML, TIFF hoặc hình ảnh. Truyền một giá trị [SourceFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/sourceformat/) không được hỗ trợ hoặc không hợp lệ sẽ gây ra một [IllegalArgumentException](https://developer.android.com/reference/java/lang/IllegalArgumentException).

Các tệp PPT, PPS và POT cổ điển sử dụng cùng một container nhị phân. Khi một bản trình chiếu như vậy được tải từ luồng mà không có phần mở rộng tệp, một tệp PPS hoặc POT có thể bị nhận dạng là PPT. Nếu cần giữ nguyên các kiểu phụ cổ này, hãy giữ lại tên tệp gốc hoặc siêu dữ liệu định dạng riêng và sử dụng chúng khi chọn tên tệp và định dạng đầu ra.

## **Lưu bản trình chiếu vào luồng**

Để ghi một bản trình chiếu mà không dựa vào đường dẫn tệp cuối cùng, truyền một luồng có thể ghi và một giá trị [SaveFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveformat/) vào phương thức [Presentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Cách này hữu ích khi đầu ra cần được trả về từ dịch vụ web, lưu vào cơ sở dữ liệu hoặc xử lý trong bộ nhớ.

Ví dụ sau lưu một bản trình chiếu mới vào luồng tệp:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Lưu bản trình chiếu với Kiểu hiển thị đã xác định trước**

Bạn có thể chỉ định chế độ xem mà PowerPoint sẽ mở bản trình chiếu đã lưu ban đầu. Sử dụng phương thức [ViewProperties.setLastView](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) với một giá trị [ViewType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/viewtype/) trước khi lưu.

Ví dụ sau cấu hình chế độ xem Slide Master làm chế độ xem ban đầu:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lưu bản trình chiếu ở định dạng Office Open XML Strict**

Để tạo một tệp PPTX tuân thủ hồ sơ Strict của Office Open XML, tạo một thể hiện [PptxOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxoptions/) và sử dụng phương thức [setConformance](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxoptions/#setConformance-int-) của nó với [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict). Sau đó truyền các tùy chọn này vào phương thức [Presentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-).

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Lưu bản trình chiếu ở định dạng Office Open XML ở chế độ Zip64**

Một tệp ZIP tiêu chuẩn giới hạn kích thước nén và chưa nén của từng mục, tổng kích thước kho lưu trữ và số lượng mục. Vì tệp PPTX là một tệp ZIP, một bản trình chiếu rất lớn có thể vượt quá các giới hạn này. Các phần mở rộng ZIP64 nâng cao các giới hạn kích thước và số lượng mục áp dụng.

Sử dụng phương thức [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxoptions/#setZip64Mode-int-) để kiểm soát việc Aspose.Slides ghi các phần mở rộng ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/zip64mode/#IfNecessary) chỉ sử dụng ZIP64 khi bản trình chiếu vượt quá giới hạn ZIP tiêu chuẩn. Đây là chế độ mặc định.
- [Never](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/zip64mode/#Never) vô hiệu hoá các phần mở rộng ZIP64.
- [Always](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/zip64mode/#Always) luôn ghi các phần mở rộng ZIP64.

Ví dụ sau luôn bật các phần mở rộng ZIP64 cho bản trình chiếu đầu ra:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Nếu sử dụng [Zip64Mode.Never](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/zip64mode/#Never) và bản trình chiếu không thể nằm trong giới hạn ZIP tiêu chuẩn, thao tác lưu sẽ ném ra một [PptxException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxexception/).
{{% /alert %}}

## **Lưu bản trình chiếu ở định dạng Office Open XML với mức nén**

Đối với đầu ra PPTX, bạn có thể cân bằng tốc độ lưu và kích thước tệp bằng cách sử dụng phương thức [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxoptions/#setCompressionLevel-int-). Lớp [CompressionLevel](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compressionlevel/) cung cấp các giá trị sau:

- [None](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compressionlevel/#None) lưu dữ liệu không nén.
- [Level1](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compressionlevel/#Level1) cung cấp nén nhanh nhất và đầu ra nén lớn nhất.
- [Level2](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compressionlevel/#Level2) đến [Level5](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compressionlevel/#Level5) dần ưu tiên đầu ra nhỏ hơn hơn tốc độ lưu.
- [Level6](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compressionlevel/#Level6) cân bằng tốc độ lưu và kích thước tệp. Đây là mức mặc định.
- [Level7](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compressionlevel/#Level7) và [Level8](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compressionlevel/#Level8) tiếp tục ưu tiên đầu ra nhỏ hơn hơn tốc độ lưu.
- [Level9](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compressionlevel/#Level9) cung cấp mức nén mạnh nhất và yêu cầu thời gian xử lý lâu nhất.

Ví dụ sau lưu một bản trình chiếu mà không nén:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

Ví dụ sau sử dụng mức nén tối đa:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Lưu bản trình chiếu mà không làm mới ảnh thu nhỏ**

Khi một bản trình chiếu được lưu dưới dạng PPTX, phương thức [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) kiểm soát ảnh thu nhỏ của tài liệu:

- `true` tạo lại ảnh thu nhỏ trong quá trình lưu. Đây là giá trị mặc định.
- `false` giữ nguyên ảnh thu nhỏ hiện có. Nếu bản trình chiếu không có ảnh thu nhỏ, Aspose.Slides sẽ không tạo.

Ví dụ sau lưu một bản trình chiếu mà không làm mới ảnh thu nhỏ của nó:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Vô hiệu hoá việc làm mới ảnh thu nhỏ có thể giảm thời gian cần thiết để lưu tệp PPTX.
{{% /alert %}}

## **Cập nhật tiến độ lưu theo phần trăm**

Để giám sát một thao tác lưu, triển khai giao diện [IProgressCallback](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iprogresscallback/) và truyền triển khai này vào phương thức [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-). Aspose.Slides sau đó sẽ gọi phương thức [IProgressCallback.reporting](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iprogresscallback/#reporting-double-) với các giá trị tiến độ trong quá trình xuất.

Ví dụ sau báo cáo tiến độ xuất PDF lên console:

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose cung cấp một công cụ [PowerPoint Splitter](https://products.aspose.app/slides/vi/splitter) miễn phí được xây dựng bằng API Aspose.Slides. Nó lưu các slide đã chọn từ một bản trình chiếu dưới dạng các tệp PPT hoặc PPTX riêng biệt.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ lưu tăng dần hoặc “lưu nhanh” không?**

Không. Mỗi thao tác lưu ghi một tệp đầu ra hoàn chỉnh thay vì chỉ cập nhật các phần đã thay đổi.

**Nhiều luồng có thể lưu cùng một thể hiện Presentation không?**

Không. Một thể hiện [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) [không an toàn với đa luồng](/slides/vi/androidjava/multithreading/). Truy cập và lưu mỗi thể hiện chỉ từ một luồng tại một thời điểm.

**Điều gì xảy ra với siêu liên kết và các tệp được liên kết bên ngoài khi tôi lưu một bản trình chiếu?**

[Hyperlinks](/slides/vi/androidjava/manage-hyperlinks/) vẫn còn trong bản trình chiếu. Aspose.Slides không sao chép các tệp được liên kết bên ngoài, vì vậy bản trình chiếu đã lưu vẫn phải có khả năng truy cập tới vị trí của chúng.

**Tôi có thể lưu siêu dữ liệu tài liệu như tác giả, tiêu đề, công ty và ngày tạo không?**

Có. Đặt các [thuộc tính tài liệu](/slides/vi/androidjava/presentation-properties/) phù hợp trước khi lưu, và Aspose.Slides sẽ ghi chúng vào tệp đầu ra.