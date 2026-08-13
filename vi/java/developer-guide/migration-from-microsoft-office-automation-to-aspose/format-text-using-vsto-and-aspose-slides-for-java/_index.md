---
title: Định dạng Văn bản bằng VSTO và Aspose.Slides cho Java
linktitle: Định dạng Văn bản
type: docs
weight: 30
url: /vi/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- định dạng văn bản
- di cư
- VSTO
- tự động hoá Office
- PowerPoint
- bản thuyết trình
- Java
- Aspose.Slides
description: "Di chuyển từ tự động hoá Microsoft Office sang Aspose.Slides cho Java và định dạng văn bản trong các bản thuyết trình PowerPoint (PPT, PPTX) với kiểm soát chính xác."
---
{{% alert color="info" %}} 

Đôi khi, bạn cần định dạng văn bản trên các slide một cách lập trình. Bài viết này trình bày cách đọc một bản thuyết trình mẫu có một số văn bản trên slide đầu tiên bằng cách sử dụng [VSTO](/slides/vi/java/format-text-using-vsto-and-aspose-slides-for-java/) và [Aspose.Slides for Java](/slides/vi/java/format-text-using-vsto-and-aspose-slides-for-java/). Mã sẽ định dạng văn bản trong ô văn bản thứ ba trên slide sao cho trông giống như văn bản trong ô cuối cùng.

{{% /alert %}} 
## **Định dạng văn bản**
Cả hai phương pháp VSTO và Aspose.Slides thực hiện các bước sau:

1. Mở bản thuyết trình nguồn.
1. Truy cập slide đầu tiên.
1. Truy cập ô văn bản thứ ba.
1. Thay đổi định dạng của văn bản trong ô văn bản thứ ba.
1. Lưu bản thuyết trình vào đĩa.

Các ảnh chụp màn hình bên dưới hiển thị slide mẫu trước và sau khi thực thi mã VSTO và Aspose.Slides for Java.

**Bản thuyết trình đầu vào** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **Ví dụ mã VSTO**
Mã dưới đây cho thấy cách định dạng lại văn bản trên một slide bằng VSTO.

**Văn bản đã được định dạng lại bằng VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Ví dụ Aspose.Slides for Java**
Để định dạng văn bản với Aspose.Slides, hãy thêm phông chữ trước khi định dạng văn bản.

**Bản thuyết trình output được tạo bởi Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}