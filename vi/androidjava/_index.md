---
title: Aspose.Slides cho Android qua Java
second_title: Aspose.Slides cho Android
type: docs
weight: 40
url: /vi/androidjava/
keywords:
- tài liệu
- xử lý bản thuyết trình
- chuyển đổi bản thuyết trình
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Bắt đầu ở đây: thêm Aspose.Slides cho Android qua Java vào ứng dụng của bạn, tạo một bản thuyết trình đầu tiên, và tìm các hướng dẫn cho các tác vụ thông thường, tham chiếu API và hỗ trợ."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java là một thư viện lớp để tạo, đọc, chỉnh sửa và chuyển đổi các bản thuyết trình PowerPoint và OpenDocument trong các ứng dụng Android, mà không cần Microsoft PowerPoint.

Thư viện này tải và lưu các định dạng PPT, PPTX, PPS, POT và ODP, bao gồm các biến thể có macro và mẫu, và xuất ra PDF, XPS, HTML, SVG, TIFF, Markdown và hình ảnh.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Bắt đầu</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/vi/androidjava/install-aspose-slides-for-android-via-java/">Cài đặt</a></li>
<li><a href="/slides/vi/androidjava/create-presentation/">Tạo bản thuyết trình đầu tiên của bạn</a></li>
<li><a href="/slides/vi/androidjava/getting-started/">Hướng dẫn bắt đầu</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/vi/androidjava/supported-file-formats/">Định dạng tệp được hỗ trợ</a></li>
<li><a href="/slides/vi/androidjava/evaluate-aspose-slides/">Giới hạn bản thử nghiệm</a></li>
<li><a href="/slides/vi/androidjava/licensing/">Cấp phép</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Xây dựng với Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/vi/androidjava/open-presentation/">Mở một bản thuyết trình</a></li>
<li><a href="/slides/vi/androidjava/save-presentation/">Lưu một bản thuyết trình</a></li>
<li><a href="/slides/vi/androidjava/convert-powerpoint-to-pdf/">Chuyển đổi sang PDF</a></li>
<li><a href="/slides/vi/androidjava/convert-slide/">Kết xuất slide thành hình ảnh</a></li>
<li><a href="/slides/vi/androidjava/manage-text/">Chỉnh sửa văn bản và hình dạng</a></li>
</ul>
<p>SLIDES WORKFLOWS</p>
<ul>
<li><a href="/slides/vi/androidjava/powerpoint-charts/">Biểu đồ</a></li>
<li><a href="/slides/vi/androidjava/powerpoint-animation/">Hoạt ảnh</a></li>
<li><a href="/slides/vi/androidjava/manage-media-files/">Âm thanh và video</a></li>
<li><a href="/slides/vi/androidjava/presentation-design/">Thiết kế slide</a></li>
<li><a href="/slides/vi/androidjava/merge-presentation/">Hợp nhất bản thuyết trình</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/vi/androidjava/examples/">Ví dụ theo thành phần slide</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Tham khảo &amp; Hỗ trợ</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">Tham chiếu API</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">Ghi chú phát hành</a></li>
<li><a href="/slides/vi/androidjava/known-issues/">Vấn đề đã biết</a></li>
<li><a href="https://products.aspose.com/slides/android-java/">Trang sản phẩm</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">Tải xuống</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Diễn đàn hỗ trợ miễn phí</a></li>
<li><a href="https://helpdesk.aspose.com/">Trợ giúp hỗ trợ trả phí</a></li>
</ul>
</div>
</div>

------

## **Bản thuyết trình đầu tiên của bạn**

Thư viện được lấy từ kho Maven của Aspose. Các dự án Android Studio mới đã có một khối `dependencyResolutionManagement` trong *settings.gradle.kts*. Thêm dòng `maven` được hiển thị bên dưới vào khối `repositories` bên trong nó, thay vì dán một khối thứ hai:

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

Sau đó thêm thư viện vào *app/build.gradle.kts* và đồng bộ dự án:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[Cài đặt](/slides/vi/androidjava/install-aspose-slides-for-android-via-java/) bao gồm các script build Groovy, tệp JAR thủ công và cách chọn phiên bản. Mã cho bản thuyết trình đầu tiên của bạn có trên [Tạo bản thuyết trình](/slides/vi/androidjava/create-presentation/): nó thêm một hộp văn bản vào một slide và lưu bản thuyết trình vào bộ nhớ lưu trữ của ứng dụng. Mẫu đó đã được biên dịch và đóng gói thành APK; nó chưa được chạy trên thiết bị. Khi không có giấy phép, các bản thuyết trình đã lưu sẽ có dấu nước đánh giá — xem [Cấp phép](/slides/vi/androidjava/licensing/).