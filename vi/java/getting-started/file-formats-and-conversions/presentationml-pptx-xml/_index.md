---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /vi/java/presentationml-pptx-xml/
---
{{% alert color="primary" %}}

PresentationML là một tên cho họ các định dạng dựa trên XML dành cho tài liệu trình chiếu. Office OpenXML (OOXML) là định dạng dựa trên XML được giới thiệu trong các ứng dụng Microsoft Office 2007. Office OpenXML là một định dạng container cho một số ngôn ngữ đánh dấu XML chuyên biệt. PresentationML là ngôn ngữ đánh dấu mà Microsoft Office PowerPoint 2007 sử dụng để lưu trữ tài liệu.

{{% /alert %}}

## **PresentationML trong Aspose.Slides for Java**
Tài liệu OOXML PresentationML xuất hiện dưới dạng file PPTX, các gói XML nén zip tuân theo đặc tả [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides for Java hỗ trợ mạnh mẽ việc tạo, đọc, thao tác và ghi tài liệu PresentationML. Ngoài ra, Aspose.Slides for Java còn có khả năng xuất tài liệu PresentationML sang định dạng tài liệu phổ biến như PDF. Điều này khả thi vì Aspose.Slides for Java được thiết kế nhằm xử lý toàn diện các tài liệu trình chiếu và PresentationML về cơ bản chứa phần trình bày nội bộ của tài liệu dưới dạng gói XML nén zip.

**Một tài liệu PPTX được tạo bằng Aspose.Slides for Java và mở trong Microsoft PowerPoint**

![todo:image_alt_text](presentationml-pptx-xml_1.png)

**Xem cùng một tài liệu PPTX được tạo bằng Aspose.Slides for Java dưới dạng ZIP**

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)

## **PresentationML là mã nguồn mở, tại sao lại dùng Aspose.Slides cho Java?**
Vì PresentationML dựa trên XML, nên hoàn toàn có thể xây dựng các ứng dụng để xử lý và tạo tài liệu PresentationML bằng các lớp XML mà không cần dựa vào thư viện lớp bên thứ ba như Aspose.Slides for Java. Tuy nhiên, có một số lợi thế khi sử dụng Aspose.Slides for Java so với các lớp XML khi làm việc với tài liệu PresentationML.

Đặc tả OOXML có độ dài hàng ngàn trang, vì vậy để xử lý đúng tài liệu PresentationML, bạn phải bỏ ra rất nhiều thời gian và công sức để hiểu định dạng này. Ngược lại, với Aspose.Slides for Java, bạn chỉ cần sử dụng các lớp, phương thức và thuộc tính để thực hiện các thao tác vốn có thể phức tạp nếu thực hiện qua các lớp XML.

Một số tính năng mà Aspose.Slides cung cấp thậm chí không có khi bạn làm việc với tài liệu PresentationML bằng các lớp XML:

- Xuất tài liệu PPT sang định dạng PDF.
- Kết xuất một slide sang bất kỳ định dạng hình ảnh nào được Java Framework hỗ trợ.
- Tự động sao chép master từ bản trình chiếu nguồn bằng tính năng sao chép.
- Áp dụng bảo vệ cho các shape.

Dưới đây là một ví dụ về tài liệu PresentationML có một slide duy nhất chứa một hộp văn bản với văn bản “Hello World”. Để đọc văn bản này bằng các lớp XML, bạn phải viết một chương trình có thể phân tích văn bản đơn giản này từ đoạn fragment sau. Aspose.Slides làm công việc đó cho bạn.

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