---
title: Xác định Định dạng Bản trình chiếu Gốc trên Android
linktitle: Định dạng nguồn
type: docs
weight: 35
url: /vi/androidjava/detect-presentation-source-format/
keywords:
- định dạng nguồn
- phát hiện định dạng bản trình chiếu
- PowerPoint
- OpenDocument
- bản trình chiếu
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Đọc định dạng gốc của bản trình chiếu đã tải trên Android với Aspose.Slides cho Android bằng Java, so sánh các API phát hiện và xử lý tệp, luồng và các định dạng kế thừa."
---
## **Tổng quan**

Sau khi tải một bản trình bày, gọi phương thức [Presentation.getSourceFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getSourceFormat--) để xác định định dạng gốc của nó. Phương thức này cũng có sẵn qua [IPresentation.getSourceFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--). Sử dụng nó khi việc xử lý tiếp theo phụ thuộc vào định dạng mà thể hiện hiện tại đã được tải.

Định dạng nguồn khác với [SaveFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveformat/) được chọn cho tệp đầu ra. Lưu sang định dạng khác không làm thay đổi định dạng nguồn của thể hiện hiện tại.

Các ví dụ sử dụng Java và các đường dẫn tệp. Trên Android, hãy thay thế các đường dẫn mẫu bằng các đường dẫn trong bộ nhớ có thể truy cập bởi ứng dụng, chẳng hạn như thư mục tệp nội bộ của ứng dụng.

## **Đọc Định dạng Nguồn của Tập tin**

Ví dụ này yêu cầu một tệp `sample.pptx` hiện có. Nó tải tệp và chọn chính sách xử lý ứng dụng bằng cách sử dụng [Presentation.getSourceFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getSourceFormat--), thay vì dựa vào tên tệp. Thay đổi đường dẫn đầu vào để thử các định dạng khác. Ví dụ in ra chính sách đã chọn; thay thế các thông báo bằng logic ứng dụng của bạn.

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

Lớp [SourceFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/sourceformat/) định nghĩa các hằng số nguyên phân biệt các định dạng bản trình bày sau. Các phần mở rộng dưới đây là phần mở rộng thông thường, không phải là việc tái tạo tên tệp gốc.

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
| `Otp` | `.otp` | Mẫu bản trình chiếu OpenDocument |
| `Fodp` | `.fodp` | Bản trình chiếu OpenDocument XML phẳng |
| `Xml` | `.xml` | Bản trình chiếu PowerPoint XML |

## **Đọc Định dạng Nguồn từ Luồng**

Ví dụ này yêu cầu một tệp `sample.pps` hiện có. Đọc các byte của nó vào một luồng bộ nhớ mô phỏng đầu vào nhận được mà không có tên tệp, chẳng hạn như giá trị trong cơ sở dữ liệu hoặc một mảng byte đã tải lên. Constructor của [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) chỉ nhận luồng.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
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

PPT, PPS và POT sử dụng cùng một định dạng nhị phân nền tảng. Khi tải bằng đường dẫn tệp, phần mở rộng có thể giúp phân biệt trình chiếu hoặc mẫu. Khi không có tên tệp, nội dung PPS và POT kế thừa có thể được báo cáo là `SourceFormat.Ppt`; ví dụ PPS ở trên in ra giá trị nguyên của `SourceFormat.Ppt`.

Nếu ứng dụng của bạn cần giữ sự phân biệt này, hãy lưu tên tệp gốc hoặc siêu dữ liệu phụ loại riêng biệt. Phần mở rộng là một gợi ý hữu ích cho các phụ loại kế thừa này, nhưng không nên là cơ sở duy nhất để xác định nội dung bản trình bày tùy ý.

## **So sánh Phát hiện Trước và Sau Khi Tải**

Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) và [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) khi bạn cần kiểm tra tệp trước khi tải toàn bộ mô hình đối tượng bản trình bày. Sử dụng [Presentation.getSourceFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getSourceFormat--) khi thể hiện đã tồn tại.

Ví dụ này yêu cầu `sample.pptx` và in ra các giá trị nguyên của `LoadFormat.Pptx` và `SourceFormat.Pptx`, tương ứng. Trong môi trường sản xuất, chọn API thích hợp với giai đoạn xử lý của bạn; một bản trình bày đã được tải không cần kiểm tra lại chỉ để lấy định dạng nguồn.

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

Kết quả sử dụng các hằng số từ các lớp khác nhau: [LoadFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadformat/) và [SourceFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/sourceformat/). Đừng so sánh giá trị số của chúng hoặc cho rằng mỗi định dạng sẽ có kết quả phát hiện giống nhau. PowerPoint XML có thể được báo cáo là `LoadFormat.Unknown` trước khi tải và `SourceFormat.Xml` sau khi tải.

## **Giữ Định dạng Nguồn và Định dạng Đầu ra Riêng biệt**

Ví dụ này yêu cầu `sample.pptx` và ghi `converted.odp`. Nó in ra giá trị nguyên của `SourceFormat.Pptx` cả trước và sau khi lưu thể hiện gốc. Chỉ thể hiện mới được tải từ đầu ra ODP mới báo cáo `Odp`.

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

Một bản trình bày được tạo từ đầu bằng `new Presentation()` báo cáo `SourceFormat.Pptx`. Nó không có tệp đầu vào: đây là giá trị mặc định cho một thể hiện mới tạo, không phải là bằng chứng rằng một tệp PPTX đã được tải. Theo dõi xem ứng dụng của bạn tạo hay tải thể hiện riêng biệt nếu sự khác biệt này quan trọng.

## **Ánh xạ Định dạng Nguồn tới Phần mở rộng**

Ví dụ sau yêu cầu `sample.pptx`. Nó ánh xạ mọi giá trị [SourceFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/sourceformat/) hiện được hỗ trợ tới một phần mở rộng thông thường, mà không cần phân tích tên tệp đầu vào. Giải pháp dự phòng tránh việc gán phần mở rộng một cách im lặng cho giá trị không nhận diện được.

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

Ánh xạ này không chuyển đổi tệp hoặc khôi phục lại phụ loại PPS/POT kế thừa đã mất trong quá trình tải luồng. Đối với việc lưu thực tế, hãy chọn một [SaveFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveformat/) một cách rõ ràng, hoặc sử dụng cách chuyển đổi được mô tả trong [Save Presentations in Their Original Format](/slides/vi/androidjava/save-presentation/#save-presentations-in-their-original-format).

## **Xác minh Định dạng bằng cách Lưu và Mở lại**

Ví dụ tự chứa này tạo một bản trình bày và ghi ba tệp trong thư mục làm việc, ghi đè các tệp có cùng tên. Nó mở lại mỗi đầu ra cả bằng đường dẫn và qua một luồng bộ nhớ. Đối với PPTX và ODP, cả hai cách đều báo cáo định dạng đã lưu. Đối với PPS, tải bằng đường dẫn báo cáo `Pps`, trong khi tải cùng các byte mà không có tên tệp báo cáo `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
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

Bảng dưới đây tổng hợp việc xác định định dạng nguồn cho các bản trình bày có phần mở rộng khớp. Tên biểu thị các hằng số; các ví dụ Java in ra giá trị nguyên của chúng:

| Định dạng đã lưu | SourceFormat từ đường dẫn tệp | SourceFormat từ luồng không tên |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` tương ứng | Giống đường dẫn tệp |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` tương ứng | Giống đường dẫn tệp |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` tương ứng | Giống đường dẫn tệp |
| ODP, OTP | `Odp`, `Otp` tương ứng | Giống đường dẫn tệp |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Nội dung PPS/POT được xác định là `Ppt` cho các luồng không tên. Bảng mô tả việc xác định định dạng, không phải việc bảo toàn mọi tính năng của bản trình bày trong quá trình chuyển đổi.

## **Câu hỏi thường gặp**

**Lưu sang ODP có thay đổi định dạng nguồn của bản trình bày đã được tải từ PPTX không?**

Không. Thể hiện hiện tại vẫn báo cáo `Pptx`. Thể hiện được tải từ tệp ODP đã lưu sẽ báo cáo `Odp`.

**Luồng có luôn phân biệt được bản trình bày, trình chiếu và mẫu kế thừa không?**

Không. PPT, PPS và POT chia sẻ định dạng nhị phân. Hãy giữ tên tệp hoặc siêu dữ liệu phụ loại riêng biệt khi cần phân biệt.

**Nên sử dụng API nào nếu bản trình bày đã được tải?**

Đọc [Presentation.getSourceFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getSourceFormat--). Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) để kiểm tra trước khi tải.