---
title: "Các ngoại lệ và lỗi liên quan tới phông chữ trên Linux"
type: docs
weight: 200
url: /vi/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Ngoại lệ phông chữ, Lỗi phông chữ, Linux, Java, Aspose.Slides cho Java"
description: "Các ngoại lệ và lỗi phông chữ trên Linux"
---
## **Tổng quan**

Khi sử dụng Aspose.Slides trên Linux, có thể gặp các vấn đề liên quan đến phông chữ nếu quá trình Java không thể truy cập các thư mục phông chữ cần thiết hoặc thư mục tạm, nếu không có phông chữ nào được cài đặt trên hệ thống, hoặc nếu các thư viện hệ thống cần thiết như fontconfig hoặc libfreetype bị thiếu.

Bài viết này mô tả các lỗi và ngoại lệ phổ biến liên quan đến phông chữ trên Linux và cung cấp các giải pháp để khắc phục. Nó giải thích cách kiểm tra quyền truy cập vào các thư mục phông chữ và TEMP, cài đặt các phông chữ và thư viện cần thiết, và sử dụng `FontsLoader` để tải phông chữ mà không cần cài đặt chúng cho toàn hệ thống.

## **Văn bản hoặc Hình ảnh Bị Thiếu (EMF hoặc WMF) Khi Mã Được Thực Thi Trên Linux**

Vấn đề này xảy ra trong các hệ thống có hạn chế trong các trường hợp sau:

1. Khi không có phông chữ nào được cài đặt hoặc khi thư mục phông chữ cho quá trình java không thể truy cập được
2. Khi không thể truy cập thư mục TEMP.

### **Giải pháp**

Kiểm tra và xác nhận rằng quyền truy cập vào thư mục TEMP và thư mục phông chữ đã được cấp. 

{{% alert color="warning" %}}

Trong một số trường hợp, bạn có thể không thể cấp quyền truy cập vào các thư mục do hạn chế từ môi trường hoặc chính sách bảo mật. Hãy thử các cách khắc phục sau: 

{{% /alert %}}

**Cách khắc phục**

Sử dụng [FontsLoader](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontsLoader) để tải các phông chữ cần thiết mà không cài đặt chúng:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Nếu không thể truy cập thư mục TEMP, sử dụng đoạn mã sau để chỉ định một thư mục khác làm TEMP cho Java:
```
String newTempFolder = "pathToTmpFolder";
String oldValue = System.getProperty("java.io.tmpdir");
java.io.File file = new java.io.File(newTempFolder);
if (!file.exists())
    file.mkdir();
System.setProperty("java.io.tmpdir", newTempFolder);
try {

    FontsLoader.loadExternalFonts(pathToFontsFolders);

    Presentation pres = ...
    // ....

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```

## **Ngoại lệ: InvalidOperationException: Không Thể Tìm Bất Kỳ Phông Chữ Nào Được Cài Đặt Trên Hệ Thống**

Ngoại lệ này xảy ra khi

1) quá trình Java không thể truy cập thư mục phông chữ
2) không có phông chữ nào được cài đặt.

### **Giải pháp**

1. Kiểm tra và xác nhận rằng quyền truy cập vào thư mục phông chữ cho quá trình Java đã được cấp.

2. Cài đặt một số phông chữ hoặc sử dụng [FontsLoader](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontsLoader).

3. Cài đặt phông chữ.

   * Ubuntu: 

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
     ```

   * CentOS: 

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
     ```

   * Sử dụng [FontsLoader](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Ngoại lệ: NoClassDefFoundError: Không Thể Khởi Tạo Lớp com.aspose.slides.internal.ey.this**

Ngoại lệ này xảy ra trên hệ thống Linux thiếu fontconfig và phông chữ. 

### **Giải pháp**

Cài đặt fontconfig:

* Ubuntu:

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
  ```

* CentOS:

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
  ```

Ngoài ra, một số phiên bản open-jdk (ví dụ, **alpine JDK**) cũng **yêu cầu cài đặt phông chữ**.

* Ubuntu:

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
  ```

* CentOS:

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
  ```

## **Ngoại lệ: UnsatisfiedLinkError: libfreetype.so.6: Không Thể Mở Tệp Đối Tượng Chia Sẻ: Không Tồn Tại Tệp Hoặc Thư Mục**

Ngoại lệ này xảy ra trên hệ thống Linux thiếu thư viện libfreetype. 

### **Giải pháp**

Cài đặt libfreetype và fontconfig:

* Ubuntu: 

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
  ```

* CentOS: 

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
  ```

{{% alert title="TIP" color="primary" %}} 

Đừng quên cài đặt phông chữ hoặc sử dụng FontsLoader.

{{% /alert %}}