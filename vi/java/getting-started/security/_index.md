---
title: Bảo mật
type: docs
weight: 160
url: /vi/java/security/
keywords:
- bảo mật
- phụ thuộc
- các thành phần của bên thứ ba
- Maven
- chữ ký JAR
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Xem xét cách Aspose.Slides for Java xử lý các bản trình chiếu, những gì nó thêm vào các phụ thuộc của dự án của bạn, cách xác minh tệp JAR và các thành phần của bên thứ ba mà nó bao gồm."
---
## **Introduction**

Bài viết này tổng hợp các thông tin mà việc đánh giá bảo mật của một ứng dụng sử dụng Aspose.Slides for Java thường cần: cách thư viện xử lý các bản trình chiếu, những gì nó thêm vào các phụ thuộc của dự án của bạn, cách kiểm tra xem tệp JAR có đến từ Aspose hay không, và các thành phần của bên thứ ba mà tệp JAR chứa.

## **Security in Aspose.Slides**

* Aspose.Slides for Java được sử dụng để tạo, chỉnh sửa và chuyển đổi các bản trình chiếu. Nó không chạy các script trong bản trình chiếu. Aspose.Slides phân tích cấu trúc bản trình chiếu và cho phép mã của bạn làm việc với mô hình đối tượng.  
* Aspose.Slides hoạt động như một thư viện phân tích và diễn giải tài liệu mà không thực thi mã từ xa. Tất cả các sản phẩm của Aspose chạy trên máy của bạn. Chúng không truyền dữ liệu nào tới Aspose. Ngoại lệ duy nhất là [metered licensing](/slides/vi/java/metered-licensing/): nếu bạn sử dụng, chỉ thông tin việc sử dụng API của bạn được xử lý.  
* Các thành phần Aspose chạy trong cùng ngữ cảnh người dùng như các ứng dụng thông thường. Do đó, các thành phần Aspose không gây rủi ro cho các tài nguyên hệ thống quan trọng. Hơn nữa, khi một thành phần Aspose mở một tài liệu, macro không được chạy tự động.

## **Maven Dependencies**

Artifact Maven của Aspose.Slides for Java, `com.aspose:aspose-slides`, không khai báo bất kỳ phụ thuộc nào: tệp POM của nó chỉ chứa tọa độ của chính artifact. Khi bạn thêm nó vào dự án, Maven chỉ thêm tệp JAR này và không có gì khác. Để liệt kê mọi artifact mà dự án của bạn giải quyết, bao gồm các phụ thuộc truyền thống, chạy lệnh sau trong thư mục dự án:

```bash
mvn dependency:tree
```

Trong dự án từ [Installation](/slides/vi/java/installation/), đầu ra liệt kê Aspose.Slides là phụ thuộc duy nhất:

```text
[INFO] com.example:hello-slides:jar:1.0
[INFO] \- com.aspose:aspose-slides:jar:jdk16:26.9:compile
```

## **Verify the JAR File**

Aspose ký tệp JAR. Để kiểm tra chữ ký, chạy công cụ `jarsigner` từ JDK trong thư mục chứa tệp JAR:

```bash
jarsigner -verify aspose-slides-26.9-jdk16.jar
```

Lệnh sẽ in `jar verified.` khi chữ ký hợp lệ và không có mục nào thay đổi kể từ khi tệp được ký. Thông báo này không chỉ tên người ký. Để xác nhận rằng Aspose đã ký tệp, thêm các tùy chọn `-verbose` và `-certs` và kiểm tra chứng chỉ của người ký được phát hành cho `CN=ASPOSE PTY LTD`. Khi Maven tải tệp JAR, nó cũng kiểm tra tổng kiểm tra SHA-1 mà kho lưu trữ công bố bên cạnh tệp.

## **Third-Party Components**

Aspose.Slides for Java bao gồm mã và dữ liệu từ các thành phần bên thứ ba. Chúng là một phần của tệp JAR, không phải là các artifact Maven riêng biệt, vì vậy `mvn dependency:tree` và các công cụ khác đọc phụ thuộc Maven không liệt kê chúng. Tệp JAR chứa thông báo *META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf*, trong đó liệt kê các thành phần và giấy phép của chúng:

| Component | License stated in the notice |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| Bouncy Castle | Giấy phép dạng MIT |
| Mono | Giấy phép MIT; một số phần thuộc các giấy phép khác mà thông báo liệt kê |
| RSWOP.ICM color profile | Các điều khoản giấy phép của Microsoft |
| sRGB_v4_ICC_preference.icc color profile | Quyền ICC để sử dụng, sao chép và phân phối tệp không thay đổi |
| Apache | Apache License 2.0 |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |

Để trích xuất thông báo từ tệp JAR, chạy công cụ `jar` từ JDK trong thư mục chứa tệp JAR:

```bash
jar xf aspose-slides-26.9-jdk16.jar "META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf"
```

## **FAQ**

**Aspose.Slides for Java có sử dụng các gói bên ngoài không?**

Nó không có phụ thuộc Maven, như [Maven Dependencies](#maven-dependencies) cho thấy, nhưng nó bao gồm các thành phần bên thứ ba được liệt kê trong [Third-Party Components](#third-party-components). Bao gồm cả tệp JAR và các thành phần này trong đánh giá bảo mật của bạn.

**Aspose.Slides for Java có cần truy cập mạng không?**

Không. Tạo, lưu và render các bản trình chiếu hoạt động trên hệ thống không có kết nối mạng. Tính năng duy nhất gửi dữ liệu tới Aspose là [metered licensing](/slides/vi/java/metered-licensing/), chức năng báo cáo việc sử dụng API.

**Aspose.Slides for Java có chứa mã gốc không?**

Không. Tệp JAR chỉ chứa các lớp và tài nguyên Java, vì vậy nó không thêm thư viện gốc nào vào ứng dụng của bạn. Trên Linux, hỗ trợ phông chữ của Java runtime cần thư viện fontconfig và các phông chữ từ hệ điều hành; xem [System Requirements](/slides/vi/java/system-requirements/#linux).