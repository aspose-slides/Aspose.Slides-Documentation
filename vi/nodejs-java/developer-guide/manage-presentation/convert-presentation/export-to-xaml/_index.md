---
title: "Xuất bản trình chiếu sang XAML trong JavaScript"
linktitle: "Trình chiếu sang XAML"
type: docs
weight: 30
url: /vi/nodejs-java/export-to-xaml/
keywords:
- "xuất PowerPoint"
- "xuất OpenDocument"
- "xuất bản trình chiếu"
- "chuyển đổi PowerPoint"
- "chuyển đổi OpenDocument"
- "chuyển đổi bản trình chiếu"
- "PowerPoint sang XAML"
- "OpenDocument sang XAML"
- "bản trình chiếu sang XAML"
- "PPT sang XAML"
- "PPTX sang XAML"
- "ODP sang XAML"
- "lưu PPT dưới dạng XAML"
- "lưu PPTX dưới dạng XAML"
- "lưu ODP dưới dạng XAML"
- "xuất PPT sang XAML"
- "xuất PPTX sang XAML"
- "xuất ODP sang XAML"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Chuyển đổi các slide PowerPoint và OpenDocument sang XAML trong JavaScript bằng Aspose.Slides—giải pháp nhanh, không cần Office, giữ nguyên bố cục của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách xuất bản trình chiếu PowerPoint sang XAML bằng Aspose.Slides. Nó bao gồm phần giới thiệu ngắn gọn về XAML, cho thấy cách lưu một bản trình chiếu sang XAML với cài đặt mặc định, và trình bày cách tùy chỉnh việc xuất qua [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/), bao gồm việc xuất các slide ẩn. Bài viết cũng trả lời một vài câu hỏi thường gặp liên quan đến phông chữ dự phòng, khả năng tương thích ngăn xếp XAML, và hành vi xuất slide ẩn.

## **Giới thiệu về XAML**

XAML là một ngôn ngữ đánh dấu dựa trên XML được sử dụng để mô tả giao diện người dùng trong các khung như WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), và Xamarin.Forms.

Bạn có thể làm việc với các tệp XAML trong một công cụ thiết kế trực quan hoặc viết và chỉnh sửa mã đánh dấu trực tiếp.

## **Xuất bản trình chiếu sang XAML với tùy chọn mặc định**

Ví dụ JavaScript sau đây cho thấy cách xuất một bản trình chiếu sang XAML với cài đặt mặc định:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

Mặc định, các slide đã xuất được lưu trong một thư mục con `input` của thư mục làm việc hiện tại của tiến trình. Thư mục này được tạo tự động, và bất kỳ hình ảnh nào cần thiết cũng được lưu ở đó.

Tên thư mục đầu ra được lấy từ tên tệp nguồn mà không có phần mở rộng. Trong Aspose.Slides cho Node.js qua Java 26.8, việc xuất `input.pptx` tạo ra một đường dẫn lồng nhau như `input/input/Slide_1.xaml`. Hãy giữ nguyên các đường dẫn đã tạo khi xử lý đầu ra. Đầu ra mặc định là tương đối với thư mục làm việc hiện tại, chứ không nhất thiết nằm cạnh tệp đầu vào.

## **Xuất bản trình chiếu sang XAML với tùy chọn tùy chỉnh**

Sử dụng giao diện [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloptions/) để kiểm soát cách Aspose.Slides xuất một bản trình chiếu sang XAML.

Để lưu đầu ra vào vị trí tùy chỉnh, triển khai [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) và truyền một thể hiện của triển khai của bạn tới phương thức [setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) của [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/).

Để bao gồm các slide ẩn trong đầu ra XAML, gọi [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) với `true`, như minh họa trong ví dụ JavaScript sau:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Thu thập tất cả các tài liệu XAML được tạo**

Một lần xuất XAML có thể tạo ra một tài liệu XAML cho mỗi slide đã xuất cùng với các hình ảnh và tài nguyên hỗ trợ riêng biệt. Gán một [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) tùy chỉnh vào [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) để nhận các tài liệu này thay vì sử dụng bộ lưu mặc định của hệ thống tệp. Bắt đầu xuất bằng phương thức overload của [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) dành riêng cho XAML, chấp nhận các tùy chọn XAML.

Trong Node.js, triển khai giao diện Java bằng `java.newProxy` từ gói `java` được Aspose.Slides sử dụng. Giữ proxy khả dụng cho đến khi việc xuất hoàn tất.

### **Hiểu vòng đời Callback**

Exporter gọi [IXamlOutputSaver.save](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) riêng biệt cho mỗi tài liệu được tạo:

- `path` xác định tài liệu và có thể bao gồm các thư mục tương đối. Giữ lại thông tin này vì XAML có thể tham chiếu tài nguyên bằng các đường dẫn tương đối.
- `data` chứa byte của tài liệu. Hình ảnh và các tài nguyên nhị phân khác không được giải mã thành văn bản.
- Bộ lưu chịu trách nhiệm giữ lại hoặc lưu trữ dữ liệu trước khi trả về. Các ví dụ sao chép mỗi mảng byte Java vào một bộ đệm Node.js thuộc về ứng dụng.
- Xem việc xuất là thành công chỉ khi thao tác lưu bản trình chiếu trả về và mọi callback đã hoàn thành thành công. Không bỏ qua lỗi lưu trữ hoặc bắt đầu ghi nền không được giám sát. Nếu việc lưu trữ diễn ra sau đó, báo cáo thành công tổng thể chỉ sau khi bước đó cũng thành công.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) cũng áp dụng cho bộ lưu tùy chỉnh. Cài đặt mặc định, `false`, loại bỏ các tài liệu XAML của slide ẩn. Truyền `true` sẽ bao gồm chúng và bất kỳ tài nguyên nào cần thiết cho việc xuất. Số lượng tài nguyên phụ thuộc vào bản trình chiếu; không giả định một callback cho mỗi slide hoặc thứ tự callback cố định.

### **Xuất ra bộ nhớ và kiểm tra tài liệu**

Ví dụ đầy đủ này tải `input.pptx`, thu thập mọi tài liệu trong một bản đồ JavaScript từ tên tới bộ đệm, và in ra tên, kiểu và số byte của nó. Nó giữ nguyên các tên đã cung cấp. Các tên trùng lặp đánh dấu bộ sưu tập là không hợp lệ thay vì ghi đè tài liệu một cách âm thầm. Ví dụ kiểm tra tình huống này trước khi sử dụng kết quả.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // Chỉ giải mã XAML và chỉ khi cần kiểm tra văn bản.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

Kiểm tra phần mở rộng hữu ích cho việc kiểm tra; giữ lại mọi tài liệu, bao gồm các loại tài nguyên không quen thuộc. Để byte nguyên giá khi lưu hoặc truyền chúng. Chỉ sử dụng giải mã UTF-8 cho XAML cần xử lý văn bản.

### **Đóng gói các tài liệu đã thu thập vào một kho ZIP**

Ví dụ độc lập này thu thập kết quả xuất, xác thực các tên, và ghi các byte gốc vào một kho ZIP bằng cầu nối Java. ZIP được lắp ráp trong bộ nhớ trước khi được ghi ra đĩa. Một tên kho duy nhất tách các công việc xuất đồng thời. Các mục ZIP dùng dấu gạch chéo xuôi và giữ lại các thư mục tương đối. Các tên không an toàn hoặc tên trùng sau chuẩn hoá sẽ từ chối toàn bộ gói trước khi ghi.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const bytes = java.newArray("byte", Array.from(data));
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // Đóng cuối cùng sẽ hoàn thiện thư mục ZIP trước khi lưu trữ được ghi lại.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

Ví dụ sử dụng [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) để ghi một kho cục bộ; bộ xuất không ghi các tệp XAML hoặc hình ảnh riêng lẻ. Đối với lưu trữ từ xa, thay thế giai đoạn ghi kho bằng việc tải lên các mảng byte đã thu thập. Sử dụng định danh công việc xuất cộng với tên tài liệu tương đối đầy đủ làm khóa blob, hoặc lưu định danh công việc, tên tương đối và dữ liệu nhị phân vào một hàng trong cơ sở dữ liệu. Công bố công việc chỉ sau khi mọi tải lên hoàn tất hoặc giao dịch cơ sở dữ liệu được cam kết. Dọn dẹp đầu ra một phần nếu việc lưu trữ thất bại.

Đối với các bản trình chiếu lớn, một bộ lưu tùy chỉnh có thể lưu mỗi tài liệu trực tiếp vào bộ nhớ lưu trữ của ứng dụng để tránh việc giữ một bản sao bổ sung của toàn bộ xuất trong bộ nhớ ứng dụng. Giữ mỗi callback đồng bộ từ góc độ của bộ xuất: trả về chỉ sau khi đích đã chấp nhận các byte, và cho phép lỗi truyền tới người gọi.

#### **Bảo quản tên tài nguyên và xác minh tham chiếu**

- Chuẩn hoá dấu phân cách đường dẫn khi đích yêu cầu, nhưng vẫn giữ các thư mục tương đối. Không chỉ dùng tên cơ bản trừ khi mọi tên được tạo ra đều độc nhất và các tham chiếu tài nguyên vẫn hợp lệ.
- Áp dụng kiểm tra tên tùy theo đích. Khi ghi các tệp rời, từ chối các đường dẫn gốc và các đoạn truy cập ngược, giải quyết đích tới một đường dẫn tuyệt đối, và xác minh nó nằm dưới thư mục xuất dự kiến, bao gồm dấu phân cách thư mục trong kiểm tra chứa. Sử dụng thư mục do ứng dụng kiểm soát, không có liên kết biểu tượng có thể khiến ghi lệch hướng.
- Sử dụng một bộ lưu và không gian tên lưu trữ riêng cho mỗi công việc xuất. Phát hiện va chạm sau khi chuẩn hoá dấu phân cách và theo quy tắc phân biệt chữ hoa/thường của đích.
- Trước khi công bố, phân tích mỗi tài liệu XAML dưới dạng XML và kiểm tra các tham chiếu tài nguyên dựa trên tệp, chẳng hạn thuộc tính `Source` hoặc `ImageSource` của hình ảnh. Giải quyết mỗi URI tương đối so với thư mục chứa tài liệu XAML, chuẩn hoá tên lưu trữ thu được, và xác nhận khóa bản đồ, mục ZIP hoặc đối tượng đã lưu tồn tại. Xử lý riêng các URI bên ngoài và các biểu thức markup XAML so với các tên tệp tương đối.

Ví dụ, nếu `input/Slide_1.xaml` tham chiếu tới `images/image1.png`, tài nguyên đã lưu phải có sẵn dưới `input/images/image1.png`. Chỉ lưu `image1.png` sẽ phá vỡ mối quan hệ này. Đối với lưu trữ đối tượng, giữ cùng bố cục dưới tiền tố công việc và làm cho các URL tài nguyên này có thể truy cập được cho người tiêu dùng XAML. Mở lại ZIP đã hoàn thành để xác minh tên mục và byte tài nguyên, và tải các slide tiêu biểu trong môi trường XAML đích để xác nhận hình ảnh được giải quyết đúng.

## **Câu hỏi thường gặp**

**Làm thế nào để đảm bảo phông chữ dự đoán được nếu phông chữ gốc không có trên máy?**

Gọi [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) trong [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — nó được sử dụng làm phông chữ dự phòng khi xuất nếu phông chữ gốc thiếu. Điều này không đảm bảo rằng XAML được tạo sẽ tham chiếu đến phông chữ dự phòng hoặc rằng phông chữ đó có sẵn trên máy đích. Đảm bảo các phông chữ mà XAML tham chiếu đều có sẵn trong môi trường nơi nó được hiển thị.

**XAML được xuất chỉ dành cho WPF, hay có thể dùng trong các ngăn xếp XAML khác không?**

Aspose.Slides xuất XAML WPF thông qua API công khai của mình. Tương thích với các ngăn xếp XAML khác, chẳng hạn UWP và Xamarin.Forms, không được đảm bảo. Hãy kiểm tra markup đã tạo trong môi trường mục tiêu của bạn.

**Các slide ẩn có được hỗ trợ không, và làm sao ngăn chúng bị xuất mặc định?**

Mặc định, các slide ẩn không được bao gồm. Bạn có thể kiểm soát hành vi này qua [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) trong [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — giữ nó tắt nếu không cần xuất chúng.