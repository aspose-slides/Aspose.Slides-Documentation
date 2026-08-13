---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /vi/java/presentationml-pptx-xml/
---
{{% alert color="info" %}} 
PresentationML là tên gọi cho một họ các định dạng dựa trên XML cho tài liệu trình chiếu. Office OpenXML (OOXML) là định dạng dựa trên XML được giới thiệu trong các ứng dụng Microsoft Office 2007. Office OpenXML là một định dạng container cho một số ngôn ngữ đánh dấu chuyên dụng dựa trên XML. PresentationML là ngôn ngữ đánh dấu được Microsoft Office PowerPoint 2007 sử dụng để lưu trữ tài liệu.
{{% /alert %}} 

## **PresentationML trong Aspose.Slides for Java**
Tài liệu PresentationML OOXML đến dưới dạng tệp PPTX, các gói XML nén zip tuân theo đặc tả [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) . Aspose.Slides for Java hỗ trợ rộng rãi việc tạo, đọc, thao tác và ghi tài liệu PresentationML. Ngoài ra, Aspose.Slides for Java có khả năng xuất tài liệu PresentationML sang định dạng tài liệu được sử dụng rộng rãi như PDF. Điều này khả thi vì Aspose.Slides for Java được thiết kế với mục tiêu xử lý toàn diện các tài liệu trình chiếu và PresentationML cơ bản lưu trữ phần trình bày nội bộ của tài liệu dưới dạng một gói XML nén zip.

**Tài liệu PPTX được tạo bởi Aspose.Slides for Java và mở trong Microsoft PowerPoint** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Xem cùng một tài liệu PPTX được tạo bởi Aspose.Slides for Java trong một tệp ZIP** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML là mở, tại sao nên dùng Aspose.Slides for Java?**
Vì PresentationML dựa trên XML, hoàn toàn có thể xây dựng các ứng dụng để xử lý và tạo tài liệu PresentationML bằng cách sử dụng các lớp XML mà không cần dựa vào thư viện lớp của bên thứ ba như Aspose.Slides for Java. Tuy nhiên, có một số lợi thế khi sử dụng Aspose.Slides for Java so với các lớp XML khi làm việc với tài liệu PresentationML.

Đặc tả OOXML dài hàng vài ngàn trang, vì vậy để xử lý đúng các tài liệu PresentationML, bạn phải tốn rất nhiều thời gian và công sức để hiểu định dạng này. Mặt khác, với Aspose.Slides for Java, bạn chỉ cần sử dụng các lớp cùng với các phương thức và thuộc tính của chúng để thực hiện các thao tác mà nếu làm bằng các lớp XML sẽ có vẻ phức tạp.

Một số tính năng mà Aspose.Slides cung cấp thậm chí không có sẵn khi bạn làm việc với tài liệu PresentationML thông qua các lớp XML:

- Xuất tài liệu PPT sang định dạng PDF.
- Kết xuất một slide sang bất kỳ định dạng hình ảnh nào được Java Framework hỗ trợ.
- Tự động sao chép master từ bản trình chiếu nguồn bằng tính năng nhân bản.
- Áp dụng bảo vệ cho các hình dạng.

Dưới đây là một ví dụ về tài liệu PresentationML với một slide duy nhất chứa một hộp văn bản có nội dung “Hello World”. Để đọc văn bản bằng các lớp XML, bạn phải viết một chương trình có thể phân tích đoạn văn bản đơn giản này từ đoạn mã sau. Aspose.Slides làm điều đó cho bạn.

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