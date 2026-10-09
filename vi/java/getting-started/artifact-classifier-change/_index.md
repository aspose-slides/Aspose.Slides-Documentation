---
title: Khai báo
type: docs
weight: 60
url: /vi/java/artifact-classifier-change/
keywords:
- bộ phân loại Aspose.Slides
- bộ phân loại artifact
- sử dụng Aspose.Slides
- cài đặt Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Aspose.Slides cho Java hiện đang sử dụng bộ phân loại jdk8 thay vì jdk16. Tìm hiểu lý do và cách cập nhật các phụ thuộc của bạn."
---
## Thay đổi bộ phân loại Artifact từ `jdk16` sang `jdk8`

Bắt đầu từ phiên bản **26.10**, chúng tôi đã thay đổi bộ phân loại được sử dụng trong các artifact đã công bố của mình từ **`jdk16`** (Java 6) sang **`jdk8`** (Java 8).

### Những thay đổi

| | Trước | Sau |
|---|---|---|
| Bộ phân loại | `jdk16` | `jdk8` |
| Phiên bản Java tối thiểu | Java 1.6 | Java 8 |

**Trước:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**Sau:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### Lý do chúng tôi thực hiện thay đổi này

Sau khi đánh giá nội bộ, chúng tôi quyết định **ngừng hỗ trợ các phiên bản Java cũ** mà không còn mang lại giá trị và đang gây cản trở việc bảo trì. Java 8 đã được chọn làm nền tảng an toàn mới cho tất cả người dùng.

Như một phần của thay đổi này, bộ phân loại đã được cập nhật để phản ánh phiên bản tối thiểu thực tế được hỗ trợ. Chúng tôi cũng đã đồng nhất với quy ước đặt tên hiện tại của Oracle, trong đó sản phẩm được gọi chính thức là **JDK 8** (thay vì định dạng legacy `1.8`).

### Những việc bạn cần thực hiện

1. **Cập nhật bộ phân loại** trong khai báo phụ thuộc của bạn từ `jdk16` sang `jdk8`.

   **Maven:**
   ```xml
   <dependency>
     <groupId>com.aspose</groupId>
     <artifactId>aspose-slides</artifactId>
     <version>26.10</version>
     <classifier>jdk8</classifier>
   </dependency>
   ```

   **Gradle:**
   ```groovy
   implementation 'com.aspose:aspose-slides:26.10:jdk8'
   ```

2. **Xác minh môi trường chạy** của bạn là Java 8 hoặc cao hơn.

3. **Làm mới bất kỳ tệp khóa** hoặc bộ nhớ cache phụ thuộc nào đang cố định bộ phân loại cũ.

### Ghi chú Di chuyển: jdk16 và jdk8

Bắt đầu từ phiên bản 26.10, cả hai bộ phân loại jdk16 và jdk8 sẽ cung cấp các JAR tương thích Java 8 (được xây dựng với độ tương thích source/target được đặt thành Java 8).

- `jdk16` → tiếp tục được công bố để duy trì tính tương thích ngược (các tích hợp hiện có).
- `jdk8` → được giới thiệu như bộ phân loại ưu tiên mới cho môi trường Java 8.

⚠️ Lưu ý: Giai đoạn phát hành song song này dự kiến sẽ kết thúc vào ngày 31 tháng 3, 2027. Sau ngày này, bộ phân loại jdk16 sẽ bị ngừng, và chỉ jdk8 sẽ được hỗ trợ.

### Ghi chú tương thích

- Bộ phân loại `jdk16` **không còn được công bố** sau **31 tháng 3, 2027**.
- Nếu bạn vẫn cần hỗ trợ Java 1.6, vui lòng duy trì trên dòng phiên bản chính trước đó cho đến khi bạn có thể di chuyển.

### Cần trợ giúp?

Nếu bạn gặp vấn đề khi di chuyển, vui lòng liên hệ [hỗ trợ Aspose](https://forum.aspose.com/) để được hỗ trợ thêm.