---
title: Xuất bản thuyết trình sang XAML trên Android
linktitle: Bản thuyết trình sang XAML
type: docs
weight: 30
url: /vi/androidjava/export-to-xaml/
keywords:
- xuất PowerPoint
- xuất OpenDocument
- xuất bản thuyết trình
- chuyển đổi PowerPoint
- chuyển đổi OpenDocument
- chuyển đổi bản thuyết trình
- PowerPoint sang XAML
- OpenDocument sang XAML
- bản thuyết trình sang XAML
- PPT sang XAML
- PPTX sang XAML
- ODP sang XAML
- lưu PPT dưới dạng XAML
- lưu PPTX dưới dạng XAML
- lưu ODP dưới dạng XAML
- xuất PPT sang XAML
- xuất PPTX sang XAML
- xuất ODP sang XAML
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint và OpenDocument sang XAML trong Java bằng Aspose.Slides cho Android—giải pháp nhanh, không cần Office, giữ nguyên bố cục của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách xuất các bản thuyết trình PowerPoint sang XAML bằng Aspose.Slides cho Android thông qua Java. Nó bao gồm một phần giới thiệu ngắn về XAML, trình bày cách lưu một bản thuyết trình dưới dạng XAML với cài đặt mặc định, và chỉ ra cách tùy chỉnh việc xuất thông qua [XamlOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/xamloptions/), bao gồm cả việc xuất các slide ẩn. Bài viết cũng trả lời một vài câu hỏi thường gặp liên quan đến phông chữ dự phòng, khả năng tương thích ngăn xếp XAML, và hành vi xuất slide ẩn.

## **Về XAML**

XAML là một ngôn ngữ đánh dấu dựa trên XML được sử dụng để mô tả giao diện người dùng trong các framework như WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) và Xamarin.Forms.

Bạn có thể làm việc với các tệp XAML trong một công cụ thiết kế trực quan hoặc viết và chỉnh sửa markup trực tiếp.

## **Xuất bản thuyết trình sang XAML với tùy chọn mặc định**

Ví dụ Java sau cho thấy cách xuất một bản thuyết trình sang XAML với cài đặt mặc định:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

Theo mặc định, các slide đã xuất sẽ được lưu trong thư mục con `pres` của thư mục làm việc hiện tại của quá trình. Thư mục này được tạo tự động, và bất kỳ hình ảnh nào cần thiết cũng được lưu ở đó.

Tên thư mục đầu ra được lấy từ tên tệp nguồn mà không có phần mở rộng. Đối với `pres.pptx`, các tệp đầu ra sẽ có tên `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, v.v. Ngay cả khi bạn truyền một đường dẫn tuyệt đối cho bản thuyết trình đầu vào, thư mục đầu ra vẫn được tạo tương đối với thư mục làm việc hiện tại, chứ không phải bên cạnh tệp đầu vào.

Trên Android, sử dụng tệp đầu vào có thể truy cập được bởi ứng dụng của bạn. Thư mục làm việc hiện tại có thể không ghi được; hãy sử dụng một bộ lưu đầu ra tùy chỉnh để giữ xuất trong bộ nhớ hoặc ghi nó vào bộ nhớ lưu trữ của ứng dụng, như được minh họa dưới đây. XAML WPF được tạo ra nhằm mục đích cho một consumer tương thích và không phải là tài nguyên bố cục Android.

## **Xuất bản thuyết trình sang XAML với tùy chọn tùy chỉnh**

Sử dụng giao diện [IXamlOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ixamloptions/) để kiểm soát cách Aspose.Slides xuất một bản thuyết trình sang XAML.

Để lưu đầu ra vào một vị trí tùy chỉnh, triển khai [IXamlOutputSaver](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ixamloutputsaver/) và truyền một thể hiện của triển khai của bạn vào phương thức [setOutputSaver](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) của [XamlOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/xamloptions/).

Để bao gồm các slide ẩn trong đầu ra XAML, gọi [setExportHiddenSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) với `true`, như trong ví dụ Java sau:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Ghi lại tất cả các tài liệu XAML được tạo**

Một lần xuất XAML có thể tạo ra một tài liệu XAML cho mỗi slide đã xuất cộng với các hình ảnh và tài nguyên hỗ trợ riêng biệt. Gán một bộ [IXamlOutputSaver](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ixamloutputsaver/) tùy chỉnh cho [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) để nhận các tài liệu này thay vì sử dụng bộ lưu mặc định trên hệ thống tệp. Bắt đầu xuất bằng phương thức overload [Presentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) đặc thù cho XAML, nhận các tùy chọn XAML.

### **Hiểu vòng đời Callback**

Bộ xuất sẽ gọi [IXamlOutputSaver.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) riêng biệt cho mỗi tài liệu được tạo:

- `path` xác định tài liệu và có thể bao gồm các thư mục tương đối. Giữ lại thông tin này vì XAML có thể tham chiếu tài nguyên bằng các đường dẫn tương đối.
- `data` chứa dữ liệu byte của tài liệu. Hình ảnh và các tài nguyên nhị phân khác không được giải mã thành văn bản.
- Bộ lưu chịu trách nhiệm giữ hoặc lưu trữ dữ liệu trước khi trả về. Các ví dụ sao chép mỗi mảng byte vào bộ nhớ thuộc sở hữu của ứng dụng.
- Xem việc xuất là thành công chỉ khi thao tác lưu bản thuyết trình trả về và mọi callback đã hoàn thành thành công. Không bỏ qua lỗi lưu trữ hoặc bắt đầu các ghi nền không được giám sát. Nếu việc lưu diễn ra sau đó, chỉ báo thành công tổng thể sau khi bước đó cũng thành công.

[ XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) cũng áp dụng cho bộ lưu tùy chỉnh. Cài đặt mặc định, `false`, loại trừ các tài liệu XAML của slide ẩn. Truyền `true` sẽ bao gồm chúng và bất kỳ tài nguyên nào cần cho việc xuất. Số lượng tài nguyên phụ thuộc vào bản thuyết trình; không giả định một callback cho mỗi slide hoặc một thứ tự callback cố định.

### **Xuất ra bộ nhớ và kiểm tra các tài liệu**

Ví dụ đầy đủ này tải `pres.pptx`, thu thập mọi tài liệu trong một [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html), và in ra tên, loại và số byte. Nó giữ nguyên các tên được cung cấp. Các tên trùng lặp sẽ làm cho bộ sưu tập không hợp lệ thay vì ghi đè tài liệu một cách âm thầm. Ví dụ kiểm tra điều này trước khi sử dụng kết quả.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.nio.charset.StandardCharsets;
import java.util.Locale;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

boolean inspectXamlText = false;
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String name = artifact.getKey().toLowerCase(Locale.ROOT);
    boolean isXaml = name.endsWith(".xaml");
    boolean isImage = name.matches(".*\\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$");
    String kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
    System.out.println(artifact.getKey() + ": " + artifact.getValue().length + " bytes (" + kind + ")");

    // Giải mã chỉ XAML, và chỉ khi cần kiểm tra văn bản.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

Kiểm tra phần mở rộng là hữu ích cho việc kiểm tra; giữ lại tất cả các tài liệu, bao gồm cả các loại tài nguyên không quen thuộc. Không thay đổi byte khi lưu hoặc truyền chúng. Chỉ sử dụng [String constructor](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) với UTF-8 cho XAML cần xử lý văn bản.

### **Đóng gói các tài liệu đã thu thập vào một tệp ZIP**

Ví dụ độc lập này thu thập kết quả xuất, xác thực các tên, và ghi các byte gốc vào một tệp ZIP. Thay thế `/path/to/app/files` bằng đường dẫn được trả về bởi phương thức [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) của context Android của bạn. Một tên tệp ZIP duy nhất sẽ tách các công việc xuất đồng thời. Các mục ZIP sử dụng dấu gạch chéo xuôi và giữ các thư mục tương đối. Các tên không an toàn hoặc các tên trùng sau chuẩn hoá sẽ bị từ chối toàn bộ gói trước khi ghi.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;
import java.util.Set;
import java.util.TreeSet;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

Map<String, byte[]> entries = new LinkedHashMap<>();
Set<String> entryNames = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String entryName = artifact.getKey().replace('\\', '/');
    String[] segments = entryName.split("/", -1);
    boolean unsafeName = entryName.startsWith("/") || entryName.contains(":");
    for (String segment : segments) {
        unsafeName |= segment.trim().isEmpty() || segment.equals(".") || segment.equals("..");
    }

    if (unsafeName || !entryNames.add(entryName)) {
        System.err.println("Export rejected: unsafe or duplicate artifact name: " + artifact.getKey());
        return;
    }
    entries.put(entryName, artifact.getValue());
}

File exportDirectory = new File("/path/to/app/files");
try {
    File archiveFile = File.createTempFile("xaml-", ".zip", exportDirectory);
    try (FileOutputStream archiveOutput = new FileOutputStream(archiveFile); ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // Thư mục ZIP đã được hoàn thiện bằng cách đóng trước khi báo cáo thành công.
    System.out.println("Saved " + entries.size() + " artifacts to " + archiveFile);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

Ví dụ sử dụng [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) để ghi một kho lưu trữ cục bộ; bộ xuất không ghi các tệp XAML hoặc hình ảnh rời. Đối với lưu trữ từ xa, thay thế giai đoạn ghi kho lưu trữ bằng việc tải lên các mảng byte đã thu thập. Sử dụng một định danh công việc xuất cộng với tên tài liệu tương đối đầy đủ làm khóa blob, hoặc lưu định danh công việc, tên tương đối và dữ liệu nhị phân trong một bản ghi cơ sở dữ liệu. Công bố công việc chỉ sau khi tất cả tải lên hoàn tất hoặc giao dịch cơ sở dữ liệu được cam kết. Dọn dẹp đầu ra một phần nếu việc lưu trữ thất bại.

Đối với các bản thuyết trình lớn, bộ lưu tùy chỉnh có thể lưu mỗi tài liệu trực tiếp vào bộ nhớ lưu trữ của ứng dụng để tránh giữ một bản sao bổ sung của toàn bộ xuất trong bộ nhớ ứng dụng. Giữ mỗi callback đồng bộ từ quan điểm của bộ xuất: chỉ trả về sau khi đích đã chấp nhận các byte, và cho phép lỗi truyền tới người gọi.

### **Bảo toàn tên tài nguyên và xác minh các tham chiếu**

- Chuẩn hoá dấu phân cách đường dẫn khi đích yêu cầu, nhưng vẫn giữ các thư mục tương đối. Không chỉ sử dụng [File.getName](https://developer.android.com/reference/java/io/File#getName()) trừ khi mọi tên được tạo ra đã biết là duy nhất và các tham chiếu tài nguyên vẫn hợp lệ.
- Áp dụng kiểm tra tên đặc thù cho đích. Khi ghi các tệp rời, từ chối các đường dẫn gốc và các đoạn di chuyển, giải quyết đích bằng [File.getCanonicalPath](https://developer.android.com/reference/java/io/File#getCanonicalPath()), và xác nhận nó vẫn nằm dưới thư mục xuất dự định, bao gồm dấu phân cách thư mục trong kiểm tra bao hàm. Sử dụng một thư mục do ứng dụng kiểm soát mà không có liên kết tượng trưng có thể làm chuyển hướng ghi.
- Sử dụng một bộ lưu và không gian tên lưu trữ riêng cho mỗi công việc xuất. Phát hiện va chạm sau khi chuẩn hoá dấu phân cách và theo quy tắc phân biệt chữ hoa/thường của đích.
- Trước khi công bố, phân tích mỗi tài liệu XAML dưới dạng XML và kiểm tra các tham chiếu tài nguyên dựa trên tệp, chẳng hạn như thuộc tính `Source` hoặc `ImageSource` của hình ảnh. Giải quyết mỗi URI tương đối đối với thư mục chứa tài liệu XAML, chuẩn hoá tên lưu trữ kết quả, và xác nhận rằng khóa bản đồ, mục ZIP, hoặc đối tượng đã lưu tồn tại. Xử lý các URI bên ngoài và các biểu thức markup XAML riêng biệt so với các tên tệp tương đối.

Ví dụ, nếu `pres/Slide_1.xaml` tham chiếu `images/image1.png`, tài nguyên đã lưu phải có sẵn dưới `pres/images/image1.png`. Chỉ giữ `image1.png` sẽ phá vỡ mối quan hệ đó. Đối với lưu trữ đối tượng, giữ nguyên cấu trúc thư mục dưới tiền tố công việc và làm cho các URL tài nguyên đó có thể truy cập được bởi consumer XAML. Mở lại tệp ZIP đã hoàn thành để xác minh tên mục và byte tài nguyên, và tải các slide đại diện trong môi trường XAML đích để xác nhận hình ảnh được giải quyết đúng.

## **Câu hỏi thường gặp**

**Làm sao tôi có thể đảm bảo phông chữ dự đoán được nếu phông chữ gốc không có trên máy?**

Gọi [setDefaultRegularFont](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) trong [XamlOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/xamloptions/) — nó được sử dụng làm phông chữ dự phòng trong quá trình xuất khi phông chữ gốc thiếu. Điều này không đảm bảo rằng XAML tạo ra sẽ tham chiếu đến phông chữ dự phòng hoặc phông chữ đó có sẵn trên máy đích. Đảm bảo các phông chữ được XAML tham chiếu đã có trong môi trường nơi nó được hiển thị.

**XAML được xuất có dành riêng cho WPF không, hay có thể dùng trong các ngăn xếp XAML khác không?**

Aspose.Slides xuất XAML WPF thông qua API công khai của nó. Khả năng tương thích với các ngăn xếp XAML khác, như UWP và Xamarin.Forms, không được đảm bảo. Hãy kiểm tra markup được tạo trong môi trường mục tiêu của bạn.

**Các slide ẩn có được hỗ trợ không, và làm sao tôi ngăn chúng được xuất theo mặc định?**

Theo mặc định, các slide ẩn không được bao gồm. Bạn có thể kiểm soát hành vi này qua [setExportHiddenSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) trong [XamlOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/xamloptions/) — để nó tắt nếu bạn không cần xuất chúng.