---
title: Xác định Định dạng Bản trình chiếu Gốc trong Java
linktitle: Định dạng nguồn
type: docs
weight: 35
url: /vi/java/detect-presentation-source-format/
keywords:
- định dạng nguồn
- phát hiện định dạng bản trình chiếu
- PowerPoint
- OpenDocument
- bản trình chiếu
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Đọc định dạng gốc của bản trình chiếu đã tải trong Java với Aspose.Slides cho Java, so sánh các API phát hiện và xử lý tệp, luồng và các định dạng legacy."
---
## **Tổng quan**

Sau khi tải một bản trình chiếu, gọi phương thức [Presentation.getSourceFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getSourceFormat--) để xác định định dạng gốc của nó. Phương thức này cũng có sẵn thông qua [IPresentation.getSourceFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentation/#getSourceFormat--). Sử dụng nó khi xử lý tiếp theo phụ thuộc vào định dạng mà đối tượng hiện tại được tải.

Định dạng nguồn khác với [SaveFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveformat/) được chọn cho tệp đầu ra. Lưu sang định dạng khác không làm thay đổi định dạng nguồn của đối tượng hiện có.

## **Đọc Định dạng Nguồn của Tệp**

Ví dụ này yêu cầu một tệp `sample.pptx` hiện có. Nó tải tệp và chọn chính sách xử lý ứng dụng bằng cách sử dụng [Presentation.getSourceFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getSourceFormat--), thay vì dựa vào tên tệp. Thay đổi đường dẫn đầu vào để thử các định dạng khác. Ví dụ in ra chính sách đã chọn; thay thế các thông báo bằng logic ứng dụng của bạn.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Nhận dạng các Giá trị Hỗ trợ**

Lớp [SourceFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/sourceformat/) định nghĩa các hằng số nguyên để phân biệt các định dạng bản trình chiếu sau. Các phần mở rộng dưới đây là phần mở rộng thông thường, không phải là tái tạo lại tên tệp gốc.

| Giá trị SourceFormat | Phần mở rộng | Định dạng |
| --- | --- | --- |
| `Ppt` | `.ppt` | Bản trình chiếu PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Bản trình chiếu Office Open XML |
| `Pptm` | `.pptm` | Bản trình chiếu Office Open XML có macro |
| `Pps` | `.pps` | Trình chiếu PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Trình chiếu Office Open XML |
| `Ppsm` | `.ppsm` | Trình chiếu Office Open XML có macro |
| `Pot` | `.pot` | Mẫu PowerPoint 97–2003 |
| `Potx` | `.potx` | Mẫu Office Open XML |
| `Potm` | `.potm` | Mẫu Office Open XML có macro |
| `Odp` | `.odp` | Bản trình chiếu OpenDocument |
| `Otp` | `.otp` | Mẫu trình chiếu OpenDocument |
| `Fodp` | `.fodp` | Bản trình chiếu Flat XML ODF |
| `Xml` | `.xml` | Bản trình chiếu PowerPoint XML |

## **Đọc Định dạng Nguồn của Luồng**

Ví dụ này yêu cầu một tệp `sample.pps` hiện có. Đọc các byte của nó vào một luồng bộ nhớ mô phỏng đầu vào được nhận mà không có tên tệp, chẳng hạn như giá trị cơ sở dữ liệu hoặc mảng byte được tải lên. Hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) chỉ nhận luồng.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

try {
    byte[] bytes = Files.readAllBytes(Paths.get("sample.pps"));
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT, PPS và POT sử dụng cùng một định dạng nhị phân nền. Khi tải bằng đường dẫn tệp, phần mở rộng có thể giúp phân biệt một trình chiếu hoặc mẫu. Nếu không có tên tệp, nội dung PPS và POT legacy có thể được báo cáo là `SourceFormat.Ppt`; ví dụ PPS ở trên in ra giá trị nguyên của `SourceFormat.Ppt`.

Nếu ứng dụng của bạn phải giữ sự khác biệt này, hãy lưu lại tên tệp gốc hoặc siêu dữ liệu phụ loại riêng biệt. Phần mở rộng là một gợi ý hữu ích cho các phụ loại legacy này, nhưng không nên là cơ sở duy nhất để xác định nội dung bản trình chiếu bất kỳ.

## **So sánh Phát hiện Trước và Sau khi Tải**

Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) và [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) khi bạn cần kiểm tra tệp trước khi tải toàn bộ mô hình đối tượng bản trình chiếu. Sử dụng [Presentation.getSourceFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getSourceFormat--) khi đối tượng đã tồn tại.

Ví dụ này yêu cầu `sample.pptx` và in ra các giá trị nguyên của `LoadFormat.Pptx` và `SourceFormat.Pptx`, tương ứng. Trong môi trường thực tế, chọn API phù hợp với giai đoạn xử lý của bạn; một bản trình chiếu đã được tải không cần kiểm tra lại chỉ để lấy định dạng nguồn.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Kết quả sử dụng các hằng số từ các lớp khác nhau: [LoadFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadformat/) và [SourceFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/sourceformat/). Không so sánh các giá trị số của chúng và không giả định rằng mọi định dạng đều có kết quả phát hiện giống nhau. PowerPoint XML có thể được báo cáo là `LoadFormat.Unknown` trước khi tải và `SourceFormat.Xml` sau khi tải.

## **Giữ Định dạng Nguồn và Đầu ra Riêng biệt**

Ví dụ này yêu cầu `sample.pptx` và ghi `converted.odp`. Nó in ra giá trị nguyên của `SourceFormat.Pptx` cả trước và sau khi lưu đối tượng gốc. Chỉ đối tượng mới được tải từ tệp ODP đầu ra mới báo cáo `Odp`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Một bản trình chiếu được tạo mới bằng `new Presentation()` báo cáo `SourceFormat.Pptx`. Nó không có tệp đầu vào: đây là giá trị mặc định cho một đối tượng mới tạo, không phải là bằng chứng rằng một tệp PPTX đã được tải. Theo dõi xem ứng dụng của bạn đã tạo hay tải đối tượng một cách riêng biệt nếu sự khác biệt này quan trọng.

## **Ánh xạ Định dạng Nguồn sang Phần mở rộng**

Ví dụ sau yêu cầu `sample.pptx`. Nó ánh xạ mọi giá trị [SourceFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/sourceformat/) hiện được hỗ trợ sang một phần mở rộng thông thường, mà không phân tích tên tệp đầu vào. Cơ chế dự phòng tránh việc gán phần mở rộng một cách im lặng cho một giá trị không nhận dạng.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Ánh xạ này không chuyển đổi tệp hoặc khôi phục phụ loại PPS/POT legacy bị mất khi tải bằng luồng. Để lưu thực tế, chọn một [SaveFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveformat/) một cách rõ ràng, hoặc sử dụng chuyển đổi được mô tả trong [Save Presentations in Their Original Format](/slides/vi/java/save-presentation/#save-presentations-in-their-original-format).

## **Xác minh Định dạng bằng cách Lưu và Mở lại**

Ví dụ tự chứa này tạo một bản trình chiếu và ghi ba tệp vào thư mục làm việc, ghi đè các tệp cùng tên. Nó mở lại mỗi tệp đầu ra cả bằng đường dẫn và qua luồng bộ nhớ. Đối với PPTX và ODP, cả hai cách đều báo cáo định dạng đã lưu. Đối với PPS, tải bằng đường dẫn báo cáo `Pps`, trong khi tải cùng các byte mà không có tên tệp báo cáo `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes = Files.readAllBytes(Paths.get(path));
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

Bảng sau tóm tắt việc xác định định dạng nguồn cho các bản trình chiếu có phần mở rộng trùng khớp. Tên biểu thị các hằng số; các ví dụ Java in ra các giá trị nguyên của chúng:

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

Nội dung PPS/POT được xác định là `Ppt` cho các luồng không tên. Bảng mô tả việc xác định định dạng, không phải việc bảo lưu mọi tính năng của bản trình chiếu trong quá trình chuyển đổi.

## **FAQ**

**Việc lưu sang ODP có thay đổi định dạng nguồn của bản trình chiếu được tải từ PPTX không?**

Không. Đối tượng hiện có vẫn báo cáo `Pptx`. Đối tượng được tải từ tệp ODP đã lưu sẽ báo cáo `Odp`.

**Luồng có luôn phân biệt được bản trình chiếu legacy, trình chiếu và mẫu không?**

Không. PPT, PPS và POT chia sẻ cùng một định dạng nhị phân. Giữ lại tên tệp hoặc siêu dữ liệu phụ loại riêng biệt khi cần sự phân biệt này.

**Nên dùng API nào nếu bản trình chiếu đã được tải?**

Đọc [Presentation.getSourceFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getSourceFormat--). Dùng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) để kiểm tra trước khi tải.