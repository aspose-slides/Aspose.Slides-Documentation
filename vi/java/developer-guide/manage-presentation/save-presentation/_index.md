---
title: Lưu các bản thuyết trình trong Java
linktitle: Lưu bản thuyết trình
type: docs
weight: 80
url: /vi/java/save-presentation/
keywords:
- lưu PowerPoint
- lưu OpenDocument
- lưu bản thuyết trình
- lưu slide
- lưu PPT
- lưu PPTX
- lưu ODP
- bản thuyết trình thành tệp
- bản thuyết trình thành luồng
- kiểu xem định trước
- Định dạng Office Open XML chặt chẽ
- chế độ Zip64
- làm mới hình thu nhỏ
- tiến độ lưu
- Java
- Aspose.Slides
description: "Lưu các bản thuyết trình PowerPoint và OpenDocument thành tệp hoặc luồng trong Java với Aspose.Slides, và cấu hình đầu ra PPTX cũng như báo cáo tiến độ."
---
## **Tổng quan**

Sau khi bạn tạo một bản thuyết trình hoặc [mở một bản hiện có](/slides/vi/java/open-presentation/), hãy sử dụng phương thức [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) để ghi kết quả. Aspose.Slides cho Java có thể lưu một bản thuyết trình vào tệp hoặc luồng ở các định dạng PowerPoint, OpenDocument, PDF và các định dạng khác. Các phần sau đây đề cập đến các thao tác lưu chuẩn và các tùy chọn có sẵn cho đầu ra PPTX.

## **Lưu bản thuyết trình vào tệp**

Để lưu bản thuyết trình vào tệp, truyền đường dẫn đầu ra và một giá trị [SaveFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveformat/) vào phương thức [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Giá trị định dạng xác định loại tệp mà Aspose.Slides sẽ tạo.

Ví dụ sau tạo một bản thuyết trình và lưu nó dưới dạng tệp PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Thêm hoặc sửa nội dung bản thuyết trình tại đây.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lưu bản thuyết trình ở định dạng gốc**

Đối với các ví dụ phát hiện tệp và luồng, hành vi của các bản thuyết trình mới tạo, và sự khác biệt giữa định dạng nguồn và đầu ra, xem [Determine the Original Presentation Format](/slides/vi/java/detect-presentation-source-format/).

Trong một ứng dụng xử lý hàng loạt, định dạng đầu vào có thể không được biết trước. Sau khi tải tệp, đọc định dạng gốc của nó từ phương thức [IPresentation.getSourceFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentation/#getSourceFormat--) . Truyền giá trị [SourceFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/sourceformat/) thu được cho [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideutil/#toSaveFormat-int-) để lấy giá trị [SaveFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveformat/) tương ứng, sau đó sử dụng [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) để ghi bản thuyết trình đã sửa đổi.

Ví dụ hoàn chỉnh sau xử lý mọi tệp trong một thư mục đầu vào, cập nhật tiêu đề và lưu chúng vào thư mục đầu ra ở định dạng mà chúng đã được tải:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideutil/#toSaveFormat-int-) ánh xạ PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP và PowerPoint XML sang các định dạng lưu bản thuyết trình tương ứng. Nó chỉ ánh xạ các định dạng nguồn của bản thuyết trình; không nhằm chọn các định dạng xuất như PDF, HTML, TIFF hoặc hình ảnh. Truyền một giá trị [SourceFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/sourceformat/) không được hỗ trợ hoặc không hợp lệ sẽ gây ra một [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Các tệp PPT, PPS và POT legacy sử dụng cùng một container nhị phân. Khi một bản thuyết trình như vậy được tải từ luồng mà không có phần mở rộng tệp, một tệp PPS hoặc POT có thể do đó được nhận dạng là PPT. Nếu cần bảo toàn các kiểu phụ legacy này, hãy giữ nguyên tên tệp hoặc siêu dữ liệu định dạng gốc riêng biệt và sử dụng chúng khi chọn tên tệp và định dạng đầu ra.

## **Lưu bản thuyết trình vào luồng**

Để ghi một bản thuyết trình mà không phụ thuộc vào đường dẫn tệp cuối cùng, truyền một luồng có thể ghi và một giá trị [SaveFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveformat/) vào phương thức [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Cách tiếp cận này hữu ích khi đầu ra phải được trả về từ một dịch vụ web, lưu trong cơ sở dữ liệu hoặc xử lý trong bộ nhớ.

Ví dụ sau lưu một bản thuyết trình mới vào một luồng tệp:

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

## **Lưu bản thuyết trình với Kiểu xem được xác định trước**

Bạn có thể chỉ định kiểu xem mà PowerPoint sẽ mở bản thuyết trình đã lưu. Sử dụng phương thức [ViewProperties.setLastView](https://reference.aspose.com/slides/vi/java/com.aspose.slides/viewproperties/#setLastView-int-) với một giá trị [ViewType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/viewtype/) trước khi lưu.

Ví dụ sau cấu hình kiểu xem Slide Master làm kiểu xem ban đầu:

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

## **Lưu bản thuyết trình ở Định dạng Office Open XML Chặt chẽ**

Để tạo một tệp PPTX tuân theo hồ sơ Strict của Office Open XML, tạo một thể hiện [PptxOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptxoptions/) và sử dụng phương thức [setConformance](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptxoptions/#setConformance-int-) của nó với [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/vi/java/com.aspose.slides/conformance/#Iso29500-2008-Strict). Sau đó truyền các tùy chọn này vào phương thức [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-).

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

## **Lưu bản thuyết trình ở Định dạng Office Open XML ở Chế độ Zip64**

Một kho lưu trữ ZIP chuẩn giới hạn kích thước nén và không nén của mỗi mục, tổng kích thước kho và số mục. Vì một tệp PPTX là một kho ZIP, một bản thuyết trình rất lớn có thể vượt quá các giới hạn này. Các phần mở rộng ZIP64 nâng cao các giới hạn kích thước và số mục áp dụng.

Sử dụng phương thức [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptxoptions/#setZip64Mode-int-) để kiểm soát việc Aspose.Slides có ghi các phần mở rộng ZIP64 hay không:

- [IfNecessary](https://reference.aspose.com/slides/vi/java/com.aspose.slides/zip64mode/#IfNecessary) chỉ sử dụng ZIP64 khi bản thuyết trình vượt quá giới hạn ZIP tiêu chuẩn. Đây là chế độ mặc định.
- [Never](https://reference.aspose.com/slides/vi/java/com.aspose.slides/zip64mode/#Never) vô hiệu hoá các phần mở rộng ZIP64.
- [Always](https://reference.aspose.com/slides/vi/java/com.aspose.slides/zip64mode/#Always) luôn ghi các phần mở rộng ZIP64.

Ví dụ sau luôn bật các phần mở rộng ZIP64 cho bản thuyết trình đầu ra:

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
Nếu [Zip64Mode.Never](https://reference.aspose.com/slides/vi/java/com.aspose.slides/zip64mode/#Never) được sử dụng và bản thuyết trình không thể vừa trong giới hạn ZIP tiêu chuẩn, thao tác lưu sẽ ném ra một [PptxException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptxexception/).
{{% /alert %}}

## **Lưu bản thuyết trình ở Định dạng Office Open XML với Các mức nén**

Đối với đầu ra PPTX, bạn có thể cân bằng tốc độ lưu và kích thước tệp bằng cách sử dụng phương thức [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptxoptions/#setCompressionLevel-int-). Lớp [CompressionLevel](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compressionlevel/) cung cấp các giá trị sau:

- [None](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compressionlevel/#None) lưu dữ liệu mà không nén.
- [Level1](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compressionlevel/#Level1) cung cấp mức nén nhanh nhất và đầu ra nén lớn nhất.
- [Level2](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compressionlevel/#Level2) đến [Level5](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compressionlevel/#Level5) dần ưu tiên đầu ra nhỏ hơn hơn tốc độ lưu.
- [Level6](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compressionlevel/#Level6) cân bằng tốc độ lưu và kích thước tệp. Đây là mức mặc định.
- [Level7](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compressionlevel/#Level7) và [Level8](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compressionlevel/#Level8) tiếp tục ưu tiên đầu ra nhỏ hơn hơn tốc độ lưu.
- [Level9](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compressionlevel/#Level9) cung cấp mức nén mạnh nhất và yêu cầu thời gian xử lý lâu nhất.

Ví dụ sau lưu một bản thuyết trình mà không nén:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PpptxOptions options = new PptxOptions();
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

## **Lưu bản thuyết trình mà không làm mới hình thu nhỏ**

Khi một bản thuyết trình được lưu dưới dạng PPTX, phương thức [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) kiểm soát hình thu nhỏ tài liệu:

- `true` tạo lại hình thu nhỏ trong quá trình lưu. Đây là giá trị mặc định.
- `false` giữ nguyên hình thu nhỏ hiện có. Nếu bản thuyết trình không có hình thu nhỏ, Aspose.Slides sẽ không tạo hình mới.

Ví dụ sau lưu một bản thuyết trình mà không làm mới hình thu nhỏ:

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
Vô hiệu hoá việc làm mới hình thu nhỏ có thể giảm thời gian cần thiết để lưu một tệp PPTX.
{{% /alert %}}

## **Cập nhật Tiến trình Lưu theo Phần Trăm**

Để giám sát một thao tác lưu, triển khai giao diện [IProgressCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprogresscallback/) và truyền triển khai này vào phương thức [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-). Aspose.Slides sau đó sẽ gọi phương thức [IProgressCallback.reporting](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprogresscallback/#reporting-double-) với các giá trị tiến độ trong quá trình xuất.

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
Aspose cung cấp một công cụ [PowerPoint Splitter](https://products.aspose.app/slides/vi/splitter) miễn phí được xây dựng bằng API Aspose.Slides. Nó lưu các slide đã chọn từ một bản thuyết trình dưới dạng các tệp PPT hoặc PPTX riêng biệt.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ lưu tăng dần hoặc “fast save” không?**

Không. Mỗi thao tác lưu đều ghi một tệp đầu ra hoàn chỉnh thay vì chỉ cập nhật các phần đã thay đổi.

**Nhiều luồng có thể lưu cùng một đối tượng Presentation không?**

Không. Một đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) **không an toàn với đa luồng** (/slides/vi/java/multithreading/). Hãy truy cập và lưu mỗi đối tượng chỉ từ một luồng tại một thời điểm.

**Liên kết siêu văn bản và các tệp được liên kết bên ngoài sẽ như thế nào khi tôi lưu bản thuyết trình?**

[Hyperlinks](/slides/vi/java/manage-hyperlinks/) vẫn còn trong bản thuyết trình. Aspose.Slides không sao chép các tệp liên kết bên ngoài, vì vậy bản thuyết trình đã lưu vẫn phải có khả năng truy cập tới vị trí của chúng.

**Tôi có thể lưu siêu dữ liệu tài liệu như tác giả, tiêu đề, công ty và ngày tạo không?**

Có. Đặt các [document properties](/slides/vi/java/presentation-properties/) thích hợp trước khi lưu, và Aspose.Slides sẽ ghi chúng vào tệp đầu ra.