---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /vi/cpp/presentationml-pptx-xml/
---
## **Giới thiệu về PresentationML**
PresentationML là tên cho một họ các định dạng dựa trên XML cho tài liệu trình chiếu. Office OpenXML (OOXML) là định dạng dựa trên XML được giới thiệu trong các ứng dụng Microsoft Office 2007. Office OpenXML là một định dạng container cho một số ngôn ngữ đánh dấu dựa trên XML chuyên biệt. PresentationML là ngôn ngữ đánh dấu được Microsoft Office PowerPoint 2007 sử dụng để lưu trữ các tài liệu của nó. 
## **PresentationML trong Aspose.Slides cho C++**
Tài liệu OOXML PresentationML xuất hiện dưới dạng tập tin PPTX, là các gói XML nén zip tuân theo các đặc tả [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides cho C++ hỗ trợ rộng rãi việc tạo, đọc, thao tác và ghi tài liệu PresentationML. Thêm vào đó, Aspose.Slides cho C++ có khả năng xuất tài liệu PresentationML sang các định dạng tài liệu phổ biến khác nhau như PDF, TIFF và XPS. Điều này khả thi vì Aspose.Slides cho C++ được thiết kế với mục tiêu xử lý toàn diện các tài liệu trình chiếu và PresentationML cơ bản chứa phần trình bày nội bộ của tài liệu dưới dạng gói XML nén zip. 

## **PresentationML là Mở, Tại sao nên sử dụng Aspose.Slides cho C++**
Vì PresentationML dựa trên XML, hoàn toàn có thể xây dựng các ứng dụng để xử lý và tạo tài liệu PresentationML bằng cách sử dụng các lớp XML mà không cần dựa vào các thư viện lớp của bên thứ ba như Aspose.Slides cho C++. Tuy nhiên, có một số ưu điểm khi sử dụng Aspose.Slides cho C++ so với các lớp XML khi làm việc với tài liệu PresentationML. 

Đặc tả OOXML dài tới hàng ngàn trang. Điều này có nghĩa là, để xử lý đúng các tài liệu PresentationML, bạn phải bỏ ra rất nhiều thời gian và công sức để hiểu định dạng của chúng. Mặt khác, khi sử dụng Aspose.Slides cho C++, bạn chỉ cần dùng các lớp liên quan và các phương thức/thuộc tính tương ứng để thực hiện các thao tác mà nếu dùng lớp XML thì sẽ khá phức tạp. 

Dưới đây là một số tính năng thậm chí không khả dụng khi làm việc với tài liệu PresentationML bằng các lớp XML: 

- Xuất tài liệu PPT sang định dạng PDF, TIFF, XPS
- Xuất các slide trong tài liệu PPT sang định dạng SVG
- Kết xuất slide sang bất kỳ định dạng hình ảnh nào được Framework C++ hỗ trợ
- Tự động sao chép các master từ bản trình chiếu nguồn bằng tính năng nhân bản
- Áp dụng bảo vệ cho các hình dạng

Hãy lấy một ví dụ về tài liệu PresentationML có một slide duy nhất với một hộp văn bản chứa văn bản “Hello World”. Để đọc văn bản thông qua các lớp XML, bạn sẽ phải viết một chương trình có thể phân tích đoạn văn bản đơn giản này từ đoạn trích sau: 
## **Example**


``` cpp

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