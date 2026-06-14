---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /vi/php-java/presentationml-pptx-xml/
---
{{% alert color="primary" %}} 

PresentationML là tên của một họ các định dạng dựa trên XML cho tài liệu trình chiếu. Office OpenXML (OOXML) là định dạng dựa trên XML được giới thiệu trong các ứng dụng Microsoft Office 2007. Office OpenXML là một định dạng container cho một số ngôn ngữ đánh dấu dựa trên XML chuyên biệt. PresentationML là ngôn ngữ đánh dấu được Microsoft Office PowerPoint 2007 sử dụng để lưu trữ tài liệu.

{{% /alert %}} 

## **PresentationML trong Aspose.Slides cho PHP qua Java**
Tài liệu OOXML PresentationML xuất hiện dưới dạng tệp PPTX, các gói XML nén ZIP tuân theo đặc tả [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) . Aspose.Slides cho PHP qua Java hỗ trợ mạnh mẽ việc tạo, đọc, thao tác và ghi tài liệu PresentationML. Thêm vào đó, Aspose.Slides cho PHP qua Java có khả năng xuất tài liệu PresentationML sang định dạng tài liệu phổ biến như PDF. Điều này khả thi vì Aspose.Slides cho PHP qua Java được thiết kế nhằm xử lý toàn diện các tài liệu trình chiếu và PresentationML về cơ bản lưu trữ phần trình bày nội bộ của tài liệu dưới dạng gói XML nén ZIP.

**Một tài liệu PPTX được tạo bởi Aspose.Slides cho PHP qua Java và mở trong Microsoft PowerPoint**

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Xem cùng một tài liệu PPTX được tạo bởi Aspose.Slides cho PHP qua Java trong một tệp ZIP**

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML là Mở, Tại Sao Nên Sử Dụng Aspose.Slides cho PHP qua Java?**
Vì PresentationML dựa trên XML, nên hoàn toàn có thể xây dựng các ứng dụng để xử lý và tạo tài liệu PresentationML bằng các lớp XML mà không cần dựa vào thư viện lớp của bên thứ ba như Aspose.Slides cho PHP qua Java. Tuy nhiên, có một số ưu điểm khi sử dụng Aspose.Slides cho PHP qua Java so với các lớp XML khi làm việc với tài liệu PresentationML.

Đặc tả OOXML dài hàng ngàn trang, vì vậy để xử lý đúng các tài liệu PresentationML, bạn phải tốn rất nhiều thời gian và công sức để hiểu định dạng. Ngược lại, với Aspose.Slides cho PHP qua Java, bạn chỉ cần sử dụng các lớp cùng các phương thức và thuộc tính của chúng để thực hiện các thao tác mà nếu dùng các lớp XML sẽ có vẻ phức tạp.

Một số tính năng mà Aspose.Slides cung cấp thậm chí không có khi bạn làm việc với tài liệu PresentationML thông qua các lớp XML:

- Xuất tài liệu PPT sang định dạng PDF.
- Kết xuất một slide sang bất kỳ định dạng hình ảnh nào được Java Framework hỗ trợ.
- Tự động sao chép các master từ bản trình chiếu nguồn bằng tính năng cloning.
- Áp dụng bảo vệ cho các hình dạng.

Dưới đây là một ví dụ về tài liệu PresentationML với một slide duy nhất chứa một hộp văn bản có nội dung “Hello World”. Để đọc văn bản này bằng các lớp XML, bạn phải viết một chương trình có thể phân tích đoạn văn bản đơn giản này từ đoạn mã sau. Aspose.Slides thực hiện điều đó cho bạn.

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
```php
