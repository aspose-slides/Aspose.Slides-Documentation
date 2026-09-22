---
title: Xác định Định dạng Bản thuyết trình Gốc trong Node.js
linktitle: Định dạng Nguồn
type: docs
weight: 35
url: /vi/nodejs-java/detect-presentation-source-format/
keywords:
- định dạng nguồn
- phát hiện định dạng bản thuyết trình
- PowerPoint
- OpenDocument
- bản thuyết trình
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Đọc định dạng gốc của một bản thuyết trình đã tải trong Node.js bằng Aspose.Slides cho Node.js qua Java, so sánh các API phát hiện và xử lý tệp, luồng và các định dạng kế thừa."
---
## **Tổng quan**

Sau khi tải một bài thuyết trình, gọi phương thức [Presentation.getSourceFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getSourceFormat) để xác định định dạng gốc của nó. Sử dụng phương thức này khi quá trình xử lý tiếp theo phụ thuộc vào định dạng mà thể hiện hiện tại được tải lên.

Định dạng nguồn khác với [SaveFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveformat/) được chọn cho tệp đầu ra. Lưu sang định dạng khác không làm thay đổi định dạng nguồn của thể hiện hiện có.

## **Đọc Định dạng Nguồn của Tệp**

Ví dụ này yêu cầu một tệp `sample.pptx` hiện có. Nó tải tệp và chọn chính sách xử lý ứng dụng bằng cách sử dụng [Presentation.getSourceFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getSourceFormat), thay vì dựa vào tên tệp. Thay đổi đường dẫn đầu vào để thử các định dạng khác. Ví dụ in ra chính sách đã chọn; hãy thay thế các thông báo bằng logic ứng dụng của bạn.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Nhận dạng các Giá trị Hỗ trợ**

Lớp [SourceFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sourceformat/) định nghĩa các hằng số nguyên phân biệt các định dạng bài thuyết trình sau. Các phần mở rộng dưới đây là phần mở rộng thông thường, không phải là việc xây dựng lại tên tệp gốc.

| Giá trị SourceFormat | Phần mở rộng | Định dạng |
| --- | --- | --- |
| `Ppt` | `.ppt` | Bản thuyết trình PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Bản thuyết trình Office Open XML |
| `Pptm` | `.pptm` | Bản thuyết trình Office Open XML có macro |
| `Pps` | `.pps` | Trình chiếu PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Trình chiếu Office Open XML |
| `Ppsm` | `.ppsm` | Trình chiếu Office Open XML có macro |
| `Pot` | `.pot` | Mẫu PowerPoint 97–2003 |
| `Potx` | `.potx` | Mẫu Office Open XML |
| `Potm` | `.potm` | Mẫu Office Open XML có macro |
| `Odp` | `.odp` | Bản thuyết trình OpenDocument |
| `Otp` | `.otp` | Mẫu bản thuyết trình OpenDocument |
| `Fodp` | `.fodp` | Bản thuyết trình Flat XML ODF |
| `Xml` | `.xml` | Bản thuyết trình PowerPoint XML |

## **Đọc Định dạng Nguồn của Luồng**

Ví dụ này yêu cầu một tệp `sample.pps` hiện có. Đọc các byte của nó vào một luồng bộ nhớ mô phỏng đầu vào nhận được mà không có tên tệp, chẳng hạn như giá trị trong cơ sở dữ liệu hoặc một mảng byte được tải lên. Hàm tạo [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) chỉ nhận luồng.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

PPT, PPS và POT sử dụng cùng một định dạng nhị phân nền. Khi tải bằng đường dẫn tệp, phần mở rộng có thể giúp phân biệt giữa trình chiếu và mẫu. Khi không có tên tệp, nội dung PPS và POT cũ có thể được báo là `SourceFormat.Ppt`; ví dụ PPS ở trên in ra giá trị nguyên của `SourceFormat.Ppt`.

Nếu ứng dụng của bạn cần giữ sự khác biệt này, hãy lưu tên tệp gốc hoặc siêu dữ liệu phụ loại riêng biệt. Phần mở rộng là một gợi ý hữu ích cho các phụ loại cũ này, nhưng không nên là cơ sở duy nhất để xác định nội dung bài thuyết trình bất kỳ.

## **So sánh Phát hiện Trước và Sau Khi Tải**

Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) và [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat) khi bạn cần kiểm tra tệp trước khi tải mô hình đối tượng bài thuyết trình đầy đủ. Sử dụng [Presentation.getSourceFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getSourceFormat) khi thể hiện đã tồn tại.

Ví dụ này yêu cầu `sample.pptx` và in ra các giá trị nguyên của `LoadFormat.Pptx` và `SourceFormat.Pptx`, tương ứng. Trong môi trường thực tế, chọn API phù hợp với giai đoạn xử lý; một bài thuyết trình đã được tải không cần kiểm tra lại chỉ để lấy định dạng nguồn.

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Kết quả sử dụng các hằng số từ các lớp khác nhau: [LoadFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadformat/) và [SourceFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sourceformat/). Không so sánh giá trị số của chúng và không giả định mọi định dạng sẽ cho kết quả phát hiện giống nhau. PowerPoint XML có thể được báo là `LoadFormat.Unknown` trước khi tải và `SourceFormat.Xml` sau khi tải.

## **Giữ Định dạng Nguồn và Định dạng Đầu ra Riêng biệt**

Ví dụ này yêu cầu `sample.pptx` và ghi `converted.odp`. Nó in ra giá trị nguyên của `SourceFormat.Pptx` cả trước và sau khi lưu thể hiện gốc. Chỉ thể hiện mới được tải lại từ đầu ra ODP mới báo `Odp`.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Một bài thuyết trình được tạo từ đầu bằng `new Presentation()` báo `SourceFormat.Pptx`. Nó không có tệp đầu vào: đây là giá trị mặc định cho một thể hiện được tạo mới, không phải bằng chứng rằng một tệp PPTX đã được tải. Theo dõi xem ứng dụng của bạn tạo hay tải thể hiện riêng biệt nếu sự khác biệt này quan trọng.

## **Ánh xạ Định dạng Nguồn sang Phần mở rộng**

Ví dụ sau yêu cầu `sample.pptx`. Nó ánh xạ mỗi giá trị [SourceFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sourceformat/) hiện được hỗ trợ sang một phần mở rộng thông thường, mà không phân tích tên tệp đầu vào. Phương án dự phòng tránh việc gán phần mở rộng một cách im lặng cho một giá trị không nhận diện.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Ánh xạ này không chuyển đổi tệp hay phục hồi phụ loại PPS/POT cũ bị mất khi tải từ luồng. Đối với việc lưu thực tế, hãy chọn một [SaveFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveformat/) một cách rõ ràng, hoặc sử dụng chuyển đổi được mô tả trong [Save Presentations in Their Original Format](/slides/vi/nodejs-java/save-presentation/#save-presentations-in-their-original-format).

## **Xác minh Định dạng bằng cách Lưu và Mở lại**

Ví dụ tự chứa này tạo một bài thuyết trình và ghi ba tệp trong thư mục làm việc, ghi đè các tệp cùng tên. Nó mở lại mỗi đầu ra cả bằng đường dẫn và qua một luồng bộ nhớ. Đối với PPTX và ODP, cả hai cách đều báo định dạng đã lưu. Đối với PPS, tải bằng đường dẫn báo `Pps`, trong khi tải cùng các byte mà không có tên tệp báo `Ppt`.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Bảng sau tóm tắt việc xác định định dạng nguồn cho các bài thuyết trình có phần mở rộng tương ứng. Các tên biểu thị các hằng số; các ví dụ JavaScript in ra giá trị nguyên của chúng:

| Định dạng đã lưu | SourceFormat từ đường dẫn tệp | SourceFormat từ luồng không tên |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` tương ứng | Giống như đường dẫn tệp |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` tương ứng | Giống như đường dẫn tệp |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` tương ứng | Giống như đường dẫn tệp |
| ODP, OTP | `Odp`, `Otp` tương ứng | Giống như đường dẫn tệp |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Nội dung PPS/POT được xác định là `Ppt` cho các luồng không tên. Bảng mô tả việc xác định định dạng, không phải việc bảo lưu mọi tính năng của bài thuyết trình trong quá trình chuyển đổi.

## **Câu hỏi thường gặp**

**Lưu sang ODP có thay đổi định dạng nguồn của một bài thuyết trình được tải từ PPTX không?**

Không. Thể hiện hiện có vẫn báo `Pptx`. Một thể hiện được tải lại từ tệp ODP đã lưu sẽ báo `Odp`.

**Luồng có luôn phân biệt được bài thuyết trình, trình chiếu và mẫu kế thừa không?**

Không. PPT, PPS và POT chia sẻ cùng định dạng nhị phân. Hãy giữ tên tệp hoặc siêu dữ liệu phụ loại riêng khi cần sự phân biệt này.

**Nên dùng API nào nếu bài thuyết trình đã được tải?**

Đọc [Presentation.getSourceFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getSourceFormat). Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) để kiểm tra trước khi tải.