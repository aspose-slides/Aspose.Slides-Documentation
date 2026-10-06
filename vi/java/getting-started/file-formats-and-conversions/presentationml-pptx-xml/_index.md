---
title: PresentationML (PPTX, XML) (Lịch sử)
type: docs
weight: 20
url: /vi/java/presentationml-pptx-xml/
keywords:
- PresentationML
- PPTX
- Office Open XML
- lịch sử
- Java
- Aspose.Slides
description: "Lịch sử: một tổng quan cũ về định dạng PresentationML (PPTX) trong Aspose.Slides for Java, được giữ lại cho các liên kết hiện có. Danh sách các định dạng được hỗ trợ hiện tại nằm trong Các Định Dạng Tệp Được Hỗ Trợ."
---
{{% alert color="info" title="Note" %}}
Đây là trang lịch sử, được giữ lại để duy trì các liên kết hiện có. Nó không mô tả phiên bản hiện tại của Aspose.Slides for Java. Đối với các định dạng mà Aspose.Slides for Java tải, nhập, lưu và hiển thị, cùng với API cho từng định dạng, xem [Các Định Dạng Tệp Được Hỗ Trợ](/slides/vi/java/supported-file-formats/). Để so sánh PPTX với PPT, xem [Hiểu Sự Khác Biệt: PPT và PPTX](/slides/vi/java/ppt-vs-pptx/).
{{% /alert %}}

{{% alert color="info" title="Note" %}}
PresentationML là tên của một họ các định dạng dựa trên XML cho tài liệu trình chiếu. Office OpenXML (OOXML) là định dạng dựa trên XML được giới thiệu trong các ứng dụng Microsoft Office 2007. Office OpenXML là một định dạng container cho một số ngôn ngữ đánh dấu dựa trên XML chuyên biệt. PresentationML là ngôn ngữ đánh dấu được Microsoft Office PowerPoint 2007 sử dụng để lưu trữ tài liệu.
{{% /alert %}}

## **PresentationML trong Aspose.Slides for Java**
Các tài liệu OOXML PresentationML xuất hiện dưới dạng tệp PPTX, các gói XML nén zip tuân theo đặc tả [OOXML ECMA-376](https://ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides for Java hỗ trợ rộng rãi việc tạo, đọc, thao tác và ghi các tài liệu PresentationML. Ngoài ra, Aspose.Slides for Java còn có khả năng xuất các tài liệu PresentationML sang định dạng tài liệu phổ biến như PDF. Điều này khả thi vì Aspose.Slides for Java được thiết kế nhằm xử lý toàn diện các tài liệu trình chiếu và PresentationML chủ yếu lưu trữ nội dung trình chiếu dưới dạng gói XML zip.

**Một tài liệu PPTX được tạo bởi Aspose.Slides for Java và mở trong Microsoft PowerPoint**

![Một tài liệu PPTX được tạo bởi Aspose.Slides for Java và mở trong Microsoft PowerPoint](presentationml-pptx-xml_1.png)

**Xem cùng một tài liệu PPTX do Aspose.Slides for Java tạo dưới dạng ZIP**

![Tài liệu PPTX tương tự được xem dưới dạng gói ZIP](presentationml-pptx-xml_2.jpg)

## **PresentationML là Mở, Tại Sao Sử Dụng Aspose.Slides for Java?**
Vì PresentationML dựa trên XML, nên hoàn toàn có thể xây dựng các ứng dụng để xử lý và tạo tài liệu PresentationML bằng các lớp XML mà không cần đến thư viện lớp bên thứ ba như Aspose.Slides for Java. Tuy nhiên, có một số lợi thế khi sử dụng Aspose.Slides for Java so với các lớp XML khi làm việc với tài liệu PresentationML.

Đặc tả OOXML dài hàng ngàn trang, vì vậy để xử lý đúng các tài liệu PresentationML, bạn phải dành rất nhiều thời gian và công sức để hiểu định dạng. Ngược lại, với Aspose.Slides for Java, bạn chỉ cần sử dụng các lớp cùng với các phương thức và thuộc tính của chúng để thực hiện các thao tác mà nếu dùng lớp XML sẽ rất phức tạp.

Một số tính năng mà Aspose.Slides cung cấp mà không có khi làm việc với PresentationML qua các lớp XML:

- Xuất tài liệu PPT sang định dạng PDF.
- Kết xuất một slide ra bất kỳ định dạng ảnh nào được Java Framework hỗ trợ.
- Tự động sao chép master từ bản trình chiếu nguồn bằng tính năng nhân bản.
- Áp dụng bảo vệ cho các hình dạng.

Dưới đây là một ví dụ về tài liệu PresentationML với một slide duy nhất chứa một hộp văn bản có nội dung “Hello World”. Để đọc văn bản này bằng các lớp XML, bạn phải viết một chương trình phân tích đoạn văn bản đơn giản sau. Aspose.Slides làm điều đó cho bạn.

**XML**

``` xml
<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<p:sld xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:p="http://schemas.openxmlformats.org/presentationml/2006/main">
  <p:cSld>
    <p:spTree>
      <p:nvGrpSpPr>
        <p:cNvPr id="1" name=""/>
        <p:cNvGrpSpPr/>
        <p:nvPr/>
      </p:nvGrpSpPr>
      <p:grpSpPr>
        <a:xfrm>
          <a:off x="0" y="0"/>
          <a:ext cx="0" cy="0"/>
          <a:chOff x="0" y="0"/>
          <a:chExt cx="0" cy="0"/>
        </a:xfrm></p:grpSpPr><p:sp>
          <p:nvSpPr><p:cNvPr id="4" name="TextBox 3"/>
          <p:cNvSpPr txBox="1"/>
            <p:nvPr/>
          </p:nvSpPr>
          <p:spPr>
            <a:xfrm>
              <a:off x="2819400" y="2590800"/>
              <a:ext cx="1297086" cy="369332"/>
            </a:xfrm>
            <a:prstGeom prst="rect">
              <a:avLst/>
            </a:prstGeom>
            <a:noFill/>
          </p:spPr>
          <p:txBody>
            <a:bodyPr wrap="none" rtlCol="0">
              <a:spAutoFit/>
            </a:bodyPr>
            <a:lstStyle/>
            <a:p>
              <a:r>
                <a:rPr lang="en-US"/>
                <a:t>Hello World
                </a:t>
              </a:r>
              <a:endParaRPr lang="en-US"/>
            </a:p>
          </p:txBody>
        </p:sp>
    </p:spTree>
  </p:cSld>
  <p:clrMapOvr>
    <a:masterClrMapping/>
  </p:clrMapOvr>
</p:sld>
```