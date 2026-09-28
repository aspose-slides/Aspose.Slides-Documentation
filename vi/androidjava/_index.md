---
title: Aspose.Slides cho Android qua Java
second_title: Aspose.Slides cho Android
type: docs
weight: 40
url: /vi/androidjava/
keywords:
- tài liệu
- xử lý bản trình bày
- chuyển đổi bản trình bày
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Bắt đầu tại đây: thêm Aspose.Slides cho Android qua Java vào ứng dụng của bạn, tạo bản trình bày đầu tiên, và tìm các hướng dẫn cho các nhiệm vụ thông thường, tham chiếu API và hỗ trợ."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java là một thư viện lớp để tạo, đọc, chỉnh sửa và chuyển đổi các bản trình bày PowerPoint và OpenDocument trong các ứng dụng Android, mà không cần Microsoft PowerPoint.

Thư viện này tải và lưu các định dạng PPT, PPTX, PPS, POT và ODP, bao gồm các biến thể hỗ trợ macro và mẫu, và xuất ra PDF, XPS, HTML, SVG, TIFF, Markdown và hình ảnh.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Bắt đầu</b></p>
<hr>
<p>BẮT ĐẦU</p>
<ul>
<li><a href="/slides/vi/androidjava/install-aspose-slides-for-android-via-java/">Cài đặt</a></li>
<li><a href="/slides/vi/androidjava/create-presentation/">Tạo bản trình bày đầu tiên của bạn</a></li>
<li><a href="/slides/vi/androidjava/getting-started/">Hướng dẫn bắt đầu</a></li>
</ul>
<p>ĐÁNH GIÁ</p>
<ul>
<li><a href="/slides/vi/androidjava/supported-file-formats/">Định dạng tệp được hỗ trợ</a></li>
<li><a href="/slides/vi/androidjava/evaluate-aspose-slides/">Giới hạn bản dùng thử</a></li>
<li><a href="/slides/vi/androidjava/licensing/">Cấp phép</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Xây dựng với Slides</b></p>
<hr>
<p>CÁC NHIỆM VỤ THÔNG THƯỜNG</p>
<ul>
<li><a href="/slides/vi/androidjava/open-presentation/">Mở một bản trình bày</a></li>
<li><a href="/slides/vi/androidjava/save-presentation/">Lưu một bản trình bày</a></li>
<li><a href="/slides/vi/androidjava/convert-powerpoint-to-pdf/">Chuyển đổi sang PDF</a></li>
<li><a href="/slides/vi/androidjava/convert-slide/">Kết xuất các slide dưới dạng hình ảnh</a></li>
<li><a href="/slides/vi/androidjava/manage-text/">Chỉnh sửa văn bản và hình dạng</a></li>
</ul>
<p>QUY TRÌNH LÀM VIỆC VỚI SLIDES</p>
<ul>
<li><a href="/slides/vi/androidjava/powerpoint-charts/">Biểu đồ</a></li>
<li><a href="/slides/vi/androidjava/powerpoint-animation/">Hoạt ảnh</a></li>
<li><a href="/slides/vi/androidjava/manage-media-files/">Âm thanh và video</a></li>
<li><a href="/slides/vi/androidjava/presentation-design/">Thiết kế slide</a></li>
<li><a href="/slides/vi/androidjava/merge-presentation/">Kết hợp các bản trình bày</a></li>
</ul>
<p>VÍ DỤ</p>
<ul>
<li><a href="/slides/vi/androidjava/examples/">Ví dụ theo yếu tố slide</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Tài liệu tham khảo &amp; Hỗ trợ</b></p>
<hr>
<p>THAM KHẢO</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">Tham chiếu API</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">Ghi chú phát hành</a></li>
<li><a href="/slides/vi/androidjava/known-issues/">Các vấn đề đã biết</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">Tải xuống</a></li>
</ul>
<p>HỖ TRỢ</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Diễn đàn hỗ trợ miễn phí</a></li>
<li><a href="https://helpdesk.aspose.com/">Bộ phận hỗ trợ trả phí</a></li>
</ul>
</div>
</div>

------

## **Bản trình bày đầu tiên của bạn**

Thư viện này được lấy từ kho Maven của Aspose. Các dự án Android Studio mới đã có khối `dependencyResolutionManagement` trong *settings.gradle.kts*. Thêm dòng `maven` được hiển thị bên dưới vào khối `repositories` bên trong nó, thay vì dán một khối thứ hai:

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

[Installation](/slides/vi/androidjava/install-aspose-slides-for-android-via-java/) bao gồm các script build Groovy, tệp JAR thủ công và cách chọn phiên bản. Mã cho bản trình bày đầu tiên của bạn có trên [Create Presentations](/slides/vi/androidjava/create-presentation/): nó thêm một hộp văn bản vào slide và lưu bản trình bày vào bộ nhớ lưu trữ của ứng dụng. Mẫu đó đã được biên dịch và xây dựng thành APK; nó chưa được chạy trên thiết bị. Nếu không có giấy phép, các bản trình bày đã lưu sẽ có dấu mốc đánh giá — xem [Licensing](/slides/vi/androidjava/licensing/).