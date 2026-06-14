---
title: Cài đặt Aspose.Slides cho Android via Java
type: docs
weight: 90
url: /vi/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- cài đặt Aspose.Slides
- tải xuống Aspose.Slides
- sử dụng Aspose.Slides
- cài đặt Aspose.Slides
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Cài đặt nhanh Aspose.Slides cho Android. Hướng dẫn từng bước, yêu cầu hệ thống và mẫu mã Java — bắt đầu làm việc với các bài thuyết trình PowerPoint ngay hôm nay!"
---
## **Tổng quan**

Bài viết này giải thích cách cài đặt Aspose.Slides for Android via Java và thêm nó vào một dự án Android. Nó mô tả hai tùy chọn cài đặt: thêm tệp JAR của Aspose.Slides vào dự án một cách thủ công và cài đặt thư viện từ kho Maven.

Bài viết cũng cung cấp một ví dụ từng bước cho thấy cách tạo một ứng dụng Android mới trong Android Studio, tham chiếu thư viện Aspose.Slides, tạo một bài thuyết trình PowerPoint bằng chương trình, và lưu nó ở định dạng PPTX. Ngoài ra còn có các ghi chú về phiên bản và trả lời các câu hỏi thường gặp về việc xác minh tích hợp, quản lý sử dụng bộ nhớ, và giảm kích thước JAR cuối cùng.

## **Cài đặt**
Trước đây, Aspose.Slides for Android via Java được phân phối dưới dạng một tệp ZIP duy nhất chứa tệp JAR, các bản demo và tài liệu sản phẩm. 

1. Nếu bạn muốn sử dụng phiên bản cũ hơn Aspose.Words for Android via Java 18.9, cần giải nén tệp Aspose.Slides.Android.zip tương ứng vào thư mục bạn muốn. 
1. Thêm tệp Jar đã giải nén vào ứng dụng bằng cách cấu hình Build Path. 
### **Thêm Tham chiếu đến Aspose.Slides for Android via Java Jar**
1. Tải xuống phiên bản mới nhất của[Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/vi/androidjava)
1. Sao chép aspose‑slides‑18.9‑android.via.java.jar vào thư mục *libs/* của dự án

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)
### **Cài đặt Aspose.Slides for Android via Java từ Kho Maven**
1. Thêm kho Maven vào file build.gradle. 
1. Thêm[Aspose.Slides for Android via Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) JAR làm phụ thuộc.

``` java

 // 1. Thêm kho maven vào file build.gradle 

repositories {

    mavenCentral()

    maven { url "https://releases.aspose.com/java/repo/" }

}

// 2. Thêm JAR 'Aspose.Slides for Android via Java' làm phụ thuộc

dependencies {

    ...

    ...

    compile (group: 'com.aspose', name: 'aspose-slides', version: 'XX.XX', classifier: 'android.via.java')

}
```
## **Ứng dụng Đầu tiên của Bạn Sử dụng Aspose.Slides for Android via Java**
Trong phần này, bạn sẽ học cách bắt đầu với Aspose.Slides for Android via Java. Chúng tôi sẽ hướng dẫn cách thiết lập một dự án Android mới từ đầu, thêm tham chiếu tới tệp JAR của Aspose.Slides, và tạo một bài thuyết trình PowerPoint mới được lưu vào đĩa dưới định dạng PPTX. Ví dụ này sử dụng[Android Studio](https://developer.android.com/studio/index.html) cho việc phát triển và ứng dụng được chạy trên Android Emulator. Để bắt đầu với Aspose.Slides for Android via Java, hãy làm theo hướng dẫn từng bước sau để tạo một ứng dụng sử dụng Aspose.Slides for Android via Java:

1. Tải xuống và cài đặt [Android Studio](https://developer.android.com/studio/index.html) ở bất kỳ vị trí nào. 
1. Chạy Android Studio. 
1. Tạo một Dự án Ứng dụng Android mới.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_3.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_4.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_5.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_6.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_7.png)

1. Sao chép aspose‑slides‑XX.XX‑android.via.java.jar vào thư mục libs/ của dự án

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)

1. Chọn mục Project (từ menu File) và nhấp vào thẻ Dependencies.  
   1. Nhấn nút “+”. Chọn tùy chọn file dependency.  
   1. Chọn thư viện Aspose.Slides từ thư mục libs và nhấn OK.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_10.png)

1. Đồng bộ dự án với các tệp gradle nếu cần. 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_11.png)

1. Để truy cập thẻ SDcard, cần thêm các quyền đặc biệt. Mở file AndroidManifest.xml và chọn chế độ xem XML. Thêm dòng sau vào file `<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />`

![todo:image_alt_text](install-aspose-slides-for-android-via-java_12.png)

1. Quay lại phần mã của ứng dụng và thêm các import sau:  

``` java

 import java.io.File;

import com.aspose.slides.IAutoShape;

import com.aspose.slides.IParagraph;

import com.aspose.slides.IPortion;

import com.aspose.slides.ISlide;

import com.aspose.slides.ITextFrame;

import com.aspose.slides.Presentation;

import com.aspose.slides.SaveFormat;

import com.aspose.slides.ShapeType;

import android.os.Environment; 
```

Bây giờ, chèn đoạn mã này vào thân phương thức onCreate để tạo một Presentation mới từ đầu bằng Aspose.Slides và lưu nó vào SDCard ở định dạng PPTX.

``` java

 try

{

    // Khởi tạo lớp Presentation đại diện cho PPTX

    Presentation pres = new Presentation();



    // Truy cập slide đầu tiên

    ISlide sld = pres.getSlides().get_Item(0);



    // Thêm AutoShape loại Hình chữ nhật

    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);



    // Thêm TextFrame vào Hình chữ nhật

    ashp.addTextFrame(" ");



    // Truy cập khung văn bản

    ITextFrame txtFrame = ashp.getTextFrame();



    // Tạo đối tượng Paragraph cho khung văn bản

    IParagraph para = txtFrame.getParagraphs().get_Item(0);



    // Tạo đối tượng Portion cho đoạn văn

    IPortion portion = para.getPortions().get_Item(0);



    // Đặt văn bản

    portion.setText("Aspose TextBox");



    // Lưu PPTX vào thẻ nhớ

    String sdCardPath = Environment.getExternalStorageDirectory().getPath() + File.separator;

    pres.save(sdCardPath + "Textbox.pptx",SaveFormat.Pptx);

}

catch (Exception e)

{

   e.printStackTrace();

}

```

Mã hoàn chỉnh sẽ trông như sau:

![todo:image_alt_text](install-aspose-slides-for-android-via-java_13.png)

1. Chạy lại ứng dụng. Lần này, mã Aspose.Slides sẽ chạy ngầm và tạo tài liệu được lưu vào SDcard.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_14.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_15.jpg)

1. Để xem tài liệu đã tạo, mở menu Tools. Chọn Android và sau đó chọn Android Device Monitor

![todo:image_alt_text](install-aspose-slides-for-android-via-java_16.jpg)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_17.jpg)
## **Phiên bản**
Kể từ năm 2018, việc đặt phiên bản cho Aspose.Slides for Android via Java tuân thủ theo Aspose.Slides for Java.  

## **Câu hỏi thường gặp**

**Làm sao tôi có thể xác minh rằng Aspose.Slides đã được tích hợp đúng?**

Xây dựng dự án, khởi tạo một đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) trống và lưu nó với một tên mới. Nếu tệp được tạo mà không ném ra ngoại lệ, thư viện đã được tích hợp thành công.

**Làm sao tôi có thể giới hạn việc tiêu thụ bộ nhớ khi xử lý các bài thuyết trình lớn?**

Tăng giới hạn bộ nhớ JVM chỉ đến mức cần thiết và đóng mỗi đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) trong khối `finally` để giải phóng bộ nhớ cache kịp thời. Điều này ngăn lỗi hết bộ nhớ và giữ cho việc sử dụng bộ nhớ tổng thể dự đoán được trong các thao tác batch.

**Tôi có thể loại bỏ các định dạng xuất không cần thiết để giảm kích thước JAR cuối cùng không?**

Các bản phát hành hiện tại của Aspose.Slides được đóng gói dưới dạng một thư viện monolithic duy nhất, vì vậy bạn không thể tắt các exporter cụ thể như PDF hoặc SVG tại thời điểm biên dịch.