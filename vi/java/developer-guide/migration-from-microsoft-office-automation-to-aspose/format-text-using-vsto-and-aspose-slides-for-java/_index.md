---
title: Định dạng văn bản bằng VSTO và Aspose.Slides cho Java
linktitle: Định dạng Văn bản
type: docs
weight: 30
url: /vi/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- định dạng văn bản
- di chuyển
- VSTO
- tự động hóa Office
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Di chuyển từ tự động hóa Microsoft Office sang Aspose.Slides cho Java và định dạng văn bản trong các bản trình chiếu PowerPoint (PPT, PPTX) với kiểm soát chính xác."
---
{{% alert color="primary" %}} 

Đôi khi, bạn cần định dạng văn bản trên các slide một cách lập trình. Bài viết này hướng dẫn cách đọc một bản trình chiếu mẫu có một số văn bản trên slide đầu tiên bằng cách sử dụng [VSTO](/slides/vi/java/format-text-using-vsto-and-aspose-slides-for-java/) và [Aspose.Slides for Java](/slides/vi/java/format-text-using-vsto-and-aspose-slides-for-java/). Mã sẽ định dạng văn bản trong hộp văn bản thứ ba trên slide để giống với văn bản trong hộp văn bản cuối cùng.

{{% /alert %}} 
## **Định dạng Văn bản**
Cả hai phương pháp VSTO và Aspose.Slides thực hiện các bước sau:

1. Mở bản trình chiếu nguồn.
1. Truy cập slide đầu tiên.
1. Truy cập hộp văn bản thứ ba.
1. Thay đổi định dạng của văn bản trong hộp văn bản thứ ba.
1. Lưu bản trình chiếu vào đĩa.

Các ảnh chụp màn hình dưới đây hiển thị slide mẫu trước và sau khi thực thi mã VSTO và Aspose.Slides cho Java.

**Bản trình chiếu đầu vào** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **Ví dụ mã VSTO**
Mã dưới đây cho thấy cách định dạng lại văn bản trên một slide bằng VSTO.

**Văn bản đã được định dạng lại bằng VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Ví dụ Aspose.Slides cho Java**
Để định dạng văn bản bằng Aspose.Slides, hãy thêm phông chữ trước khi định dạng văn bản.

**Bản trình chiếu đầu ra được tạo bằng Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}