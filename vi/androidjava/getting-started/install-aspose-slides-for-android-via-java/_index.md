---
title: Cài đặt Aspose.Slides cho Android qua Java
type: docs
weight: 90
url: /vi/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- cài đặt Aspose.Slides
- tải xuống Aspose.Slides
- sử dụng Aspose.Slides
- cài đặt Aspose.Slides
- Gradle
- kho Maven
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Thêm Aspose.Slides cho Android qua Java vào dự án Android Studio bằng Gradle từ kho Maven của Aspose, hoặc thêm tệp JAR một cách thủ công."
---
## **Tổng quan**

Bài viết này giải thích cách thêm Aspose.Slides for Android via Java vào dự án Android. Cách được khuyến nghị là để Gradle tải thư viện từ kho Maven của Aspose. Bạn cũng có thể tải tệp JAR và thêm nó vào dự án của mình theo cách thủ công.

Thư viện không được công bố trên Maven Central hay kho Maven của Google. Nó có sẵn từ kho riêng của Aspose, dưới dạng artifact `aspose-slides` với classifier `android.via.java`.

## **Cài đặt từ kho Maven của Aspose**

### **Bước 1: Thêm kho**

Các dự án Android Studio mới khai báo các kho trong khối `dependencyResolutionManagement` của *settings.gradle.kts*, và Gradle sẽ từ chối các kho mà tệp xây dựng của mô-đun thêm vào. Thêm dòng `maven` được hiển thị dưới đây vào khối `repositories` bên trong khối hiện có, thay vì dán một khối `dependencyResolutionManagement` thứ hai:

```kotlin
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = uri("https://releases.aspose.com/java/repo/") }
    }
}
```

### **Bước 2: Thêm phụ thuộc**

Thêm thư viện vào khối `dependencies` của tệp xây dựng mô-đun app, *app/build.gradle.kts*:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

Phần cuối của tọa độ, `android.via.java`, là classifier chọn bản dựng Android của thư viện. Nếu thiếu, Gradle sẽ không thể tìm thấy artifact.

Sau đó đồng bộ dự án với các tệp Gradle, để Gradle tải thư viện về.

### **Chọn phiên bản**

Aspose.Slides for Android via Java không được xây dựng cho mọi phiên bản trong kho. Các bản dựng của nó chỉ được công bố cho một số phiên bản Aspose.Slides for Java, và một phiên bản không có bản dựng Android sẽ không giải quyết được. Chọn một phiên bản được liệt kê trên [trang tải xuống Aspose.Slides for Android via Java](https://releases.aspose.com/slides/androidjava/).

### **Kịch bản xây dựng Groovy**

Nếu dự án của bạn sử dụng kịch bản xây dựng Groovy, thêm dòng `maven` vào khối `repositories` bên trong khối `dependencyResolutionManagement` hiện có của *settings.gradle*:

```groovy
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = 'https://releases.aspose.com/java/repo/' }
    }
}
```

Và thêm phụ thuộc vào *app/build.gradle*:

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **Thêm tệp JAR theo cách thủ công**

Nếu bạn không thể sử dụng kho Maven, hãy thêm tệp JAR vào dự án của mình:

1. Tải tệp JAR từ thư mục phiên bản trong [kho Maven của Aspose](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Đối với phiên bản 26.9, tệp là *aspose-slides-26.9-android.via.java.jar* trong thư mục *26.9*.
2. Sao chép tệp vào thư mục *app/libs* của dự án. Tạo thư mục nếu nó không tồn tại.
3. Thêm tệp vào khối `dependencies` của *app/build.gradle.kts*, sau đó đồng bộ dự án:

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **Tạo Bài thuyết trình Đầu tiên của Bạn**

Sau khi dự án được đồng bộ, tiếp tục với [Create Presentations](/slides/vi/androidjava/create-presentation/). Ví dụ đầu tiên của nó thêm một hộp văn bản vào slide và lưu bài thuyết trình vào bộ nhớ riêng tư của ứng dụng, không cần quyền truy cập bộ nhớ. Nếu không có giấy phép, Aspose.Slides sẽ thêm dấu watermark đánh giá vào mỗi slide được lưu; xem [Licensing](/slides/vi/androidjava/licensing/).

## **Quản lý Phiên bản**

Kể từ năm 2018, việc quản lý phiên bản của Aspose.Slides for Android via Java đã tuân thủ với Aspose.Slides for Java. Các bản dựng Android không được công bố cho mọi phiên bản Java; xem [Choose a Version](#choose-a-version).

## **FAQ**

### Làm thế nào để tôi xác nhận rằng Aspose.Slides đã được tích hợp đúng?

Xây dựng dự án của bạn, tạo một đối tượng [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) trống và lưu nó với một tên mới. Nếu tệp được tạo mà không ném ngoại lệ, thư viện đã được tích hợp thành công.

### Làm thế nào để giới hạn tiêu thụ bộ nhớ khi xử lý các bài thuyết trình lớn?

Gọi phương thức [dispose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#dispose--) của mỗi đối tượng [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) trong khối `finally` để giải phóng tài nguyên kịp thời, và xử lý một bài thuyết trình lớn mỗi lần. Điều này giúp ngăn lỗi hết bộ nhớ và giữ cho việc sử dụng bộ nhớ tổng thể dự đoán được trong các thao tác batch.

### Tôi có thể loại bỏ các định dạng xuất không mong muốn để giảm kích thước JAR cuối cùng không?

Các bản phát hành Aspose.Slides hiện tại được cung cấp dưới dạng một thư viện đơn độc, vì vậy bạn không thể tắt các bộ xuất cụ thể như PDF hoặc SVG trong quá trình build.