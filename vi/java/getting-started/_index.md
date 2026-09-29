---
title: Bắt đầu
type: docs
weight: 10
url: /vi/java/getting-started/
keywords:
- bắt đầu
- các yêu cầu hệ thống
- cài đặt
- bản trình chiếu đầu tiên
- Maven
- xử lý PPT
- xử lý PPTX
- xử lý ODP
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Quá trình từ một dự án Java mới tới bản trình chiếu đầu tiên được lưu bằng Aspose.Slides: kiểm tra các yêu cầu, thêm thư viện từ kho Maven của Aspose, chạy chương trình đầu tiên, và tiếp tục với các tác vụ thường dùng."
---
## **Tổng quan**

Thực hiện bốn bước dưới đây theo thứ tự. Mỗi bước nêu các hành động cần làm và liên kết đến bài viết chi tiết. Đánh giá, cấp phép và hỗ trợ được đề cập sau các bước.

## **Bước 1: Kiểm tra yêu cầu hệ thống**

Aspose.Slides for Java là một tệp JAR duy nhất không có mã gốc, vì vậy nó chạy trên bất kỳ hệ điều hành nào có môi trường chạy Java được hỗ trợ. [System Requirements](/slides/vi/java/system-requirements/) liệt kê các hệ điều hành và phiên bản Java được hỗ trợ. Dự án và các lệnh trong các bước tiếp theo yêu cầu JDK 11 trở lên và, đối với lộ trình Maven, [Apache Maven](https://maven.apache.org/install.html).

## **Bước 2: Thêm thư viện vào dự án của bạn**

Aspose.Slides for Java được xuất bản trong kho Maven riêng của Aspose, không có trong Maven Central. Chọn một trong các cách sau:

- Với Maven: khai báo kho `https://releases.aspose.com/java/repo/` trong *pom.xml* của bạn và thêm phụ thuộc `com.aspose:aspose-slides` với bộ phân loại `jdk16`.
- Không dùng Maven: tải về tệp JAR có tên kết thúc bằng *-jdk16.jar* từ kho và đặt nó vào class path.

Trên Linux, cũng cần cài đặt thư viện fontconfig và ít nhất một phông chữ. Nếu không có chúng, việc lưu bản trình chiếu sẽ thất bại với lỗi "Fontconfig head is null, check your fonts or fonts configuration".

[Installation](/slides/vi/java/installation/) cung cấp các mục nhập *pom.xml*, tệp JAR để tải và lệnh Linux.

## **Bước 3: Tạo bản trình chiếu đầu tiên của bạn**

Bản [quick start trên trang chủ Aspose.Slides for Java](/slides/vi/java/#your-first-presentation) là một dự án Maven hoàn chỉnh: một tệp *pom.xml* và một chương trình thêm một hình đám mây có văn bản vào một slide và lưu bản trình chiếu dưới dạng tệp PPTX. Bạn chạy nó bằng `mvn compile exec:java`. [Create Presentations](/slides/vi/java/create-presentation/) giải thích chương trình này từng bước. Để mở một bản trình chiếu đã tồn tại và lưu nó ở định dạng khác, xem [Open Presentations](/slides/vi/java/open-presentation/) và [Save Presentations](/slides/vi/java/save-presentation/).

## **Bước 4: Tiếp tục với các tác vụ phổ biến**

- [Mở một bản trình chiếu](/slides/vi/java/open-presentation/)
- [Lưu một bản trình chiếu](/slides/vi/java/save-presentation/)
- [Chuyển đổi bản trình chiếu sang PDF](/slides/vi/java/convert-powerpoint-to-pdf/)
- [Kết xuất slide dưới dạng hình ảnh](/slides/vi/java/convert-slide/)
- [Chỉnh sửa văn bản bản trình chiếu](/slides/vi/java/manage-text/)
- [Ví dụ theo phần tử slide](/slides/vi/java/examples/)

## **Đánh giá và Cấp phép**

Nếu không có giấy phép, Aspose.Slides chạy ở chế độ đánh giá: nó thêm một dấu watermark vào mỗi slide được lưu và cắt ngắn văn bản mà mã của bạn đọc từ các bản trình chiếu.

- [Evaluate Aspose.Slides](/slides/vi/java/evaluate-aspose-slides/) mô tả các hạn chế của chế độ đánh giá và cách yêu cầu giấy phép tạm thời.
- [Licensing](/slides/vi/java/licensing/) chỉ ra cách áp dụng giấy phép từ tệp hoặc luồng.
- [Metered Licensing](/slides/vi/java/metered-licensing/) đề cập đến việc cấp phép dựa trên mức sử dụng.
- [Supported File Formats](/slides/vi/java/supported-file-formats/) liệt kê các định dạng mà Aspose.Slides có thể tải và lưu.

## **Nhận trợ giúp**

[Technical Support](/slides/vi/java/technical-support/) giải thích cách đặt câu hỏi trên [diễn đàn hỗ trợ miễn phí](https://forum.aspose.com/c/slides/vi/11) và những gì cần bao gồm khi bạn báo cáo một vấn đề.

## **Câu hỏi thường gặp**

**Tôi có cần cài đặt Microsoft PowerPoint không?**

Không. Aspose.Slides tự đọc và ghi các tệp bản trình chiếu và không sử dụng PowerPoint, do đó nó cũng có thể chạy trên máy chủ và trên Linux.

**Tại sao Maven không tìm thấy Aspose.Slides for Java?**

Thư viện không có trong Maven Central. Khai báo kho của Aspose trong *pom.xml* của bạn, như được trình bày trong [Installation](/slides/vi/java/installation/), và Maven sẽ tải thư viện từ đó.

**Bộ phân loại `jdk16` có nghĩa là thư viện cần Java 16 không?**

Không. Bộ phân loại này chọn bản dựng Java SE của thư viện; bản dựng khác dành cho Android. Bản dựng này chạy trên các JDK hiện tại, chẳng hạn JDK 21.