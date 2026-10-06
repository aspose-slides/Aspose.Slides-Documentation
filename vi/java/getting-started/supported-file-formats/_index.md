---
title: Định dạng tệp được hỗ trợ
type: docs
weight: 106
url: /vi/java/supported-file-formats/
keywords:
- định dạng tệp được hỗ trợ
- tải bản trình chiếu
- nhập PDF
- nhập HTML
- lưu bản trình chiếu
- kết xuất slide
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- XPS
- SVG
- XAML
- Java
- Aspose.Slides
description: "Xem các định dạng tệp nào Aspose.Slides cho Java có thể tải, nhập, lưu và kết xuất, và API nào đọc hoặc ghi mỗi định dạng."
---
## **Tổng quan**

Aspose.Slides for Java mở và lưu các bản trình chiếu PowerPoint và OpenDocument. Nó cũng nhập nội dung PDF và HTML vào các slide, lưu bản trình chiếu sang các định dạng tài liệu, web và hình ảnh, và kết xuất các slide và shape riêng lẻ thành hình ảnh. Bài viết này liệt kê từng định dạng được hỗ trợ và chỉ ra API đọc hoặc ghi chúng.

Để xem tổng quan về các tính năng chỉnh sửa, xem [Tổng quan tính năng](/slides/vi/java/features-overview/).

## **Các phiên bản Microsoft PowerPoint được hỗ trợ**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for Mac
- PowerPoint cho Microsoft 365 (trước đây là Office 365)

{{% alert color="info" title="Note" %}}

Các bản trình chiếu được lưu bởi PowerPoint 95 và các phiên bản trước không thể mở được. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) nhận dạng tệp PowerPoint 95 và báo cáo `LoadFormat.Ppt95`, nhưng trình tạo [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) ném ra [PptUnsupportedFormatException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptunsupportedformatexception/) cho tệp đó.

{{% /alert %}}

## **Các định dạng tệp được hỗ trợ**

Bảng sử dụng bốn thao tác:

- **Tải**: hàm tạo [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) mở tệp dưới dạng bản trình chiếu có thể chỉnh sửa.
- **Nhập**: một phương thức của [SlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidecollection/) tạo các slide từ nội dung tệp và thêm chúng vào một bản trình chiếu hiện có. Hàm tạo Presentation không chuyển đổi các tệp này thành slide.
- **Lưu**: [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ghi bản trình chiếu ra tệp hoặc luồng. Mọi định dạng ngoại trừ XAML được chọn bằng giá trị [SaveFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveformat/).
- **Kết xuất**: một phương thức kết xuất vẽ slide hoặc shape dưới dạng hình ảnh. Các định dạng chỉ được kết xuất không phải là giá trị SaveFormat.

|**Định dạng**|**Mô tả**|**Tải / Nhập**|**Lưu / Kết xuất**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Bản trình chiếu PowerPoint 97-2003|Tải|Lưu|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|Mẫu PowerPoint 97-2003|Tải|Lưu|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|Trình chiếu PowerPoint 97-2003|Tải|Lưu|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Bản trình chiếu PowerPoint|Tải|Lưu|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|Mẫu PowerPoint|Tải|Lưu|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Trình chiếu PowerPoint|Tải|Lưu|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Bản trình chiếu PowerPoint có Macro|Tải|Lưu|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Mẫu PowerPoint có Macro|Tải|Lưu|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Trình chiếu PowerPoint có Macro|Tải|Lưu|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|Bản trình chiếu OpenDocument|Tải|Lưu|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Bản trình chiếu OpenDocument XML phẳng|Tải|Lưu|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Mẫu Bản trình chiếu OpenDocument|Tải|Lưu|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|Bản trình chiếu PowerPoint XML|Tải|Lưu|`SaveFormat.Xml`; loaded files report `SourceFormat.Xml` (there is no `LoadFormat` value)|
|[PDF](https://docs.fileformat.com/pdf/)|Định dạng Tài liệu PDF|Nhập|Lưu|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Ngôn ngữ Đánh dấu Siêu văn bản|Nhập|Lưu|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Đặc tả giấy XML|—|Lưu|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Định dạng Tệp Ảnh Đánh thẻ|—|Lưu, Kết xuất|`SaveFormat.Tiff` (one page per slide); `ImageFormat.Tiff` (one slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|Định dạng Đồ họa Trao đổi|—|Lưu, Kết xuất|`SaveFormat.Gif` (animated, all slides); `ImageFormat.Gif` (one slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Định dạng Web Nhỏ (Flash)|—|Lưu|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Lưu|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Ngôn ngữ Đánh dấu Ứng dụng Mở rộng|—|Lưu|`Presentation.save(IXamlOptions)`, one XAML file per slide; not a `SaveFormat` value|
|[PNG](https://docs.fileformat.com/image/png/)|Đồ họa Mạng Cỡ Nhỏ|—|Kết xuất|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Ảnh JPEG|—|Kết xuất|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Ảnh Bitmap|—|Kết xuất|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Siêu Định dạng Meta|—|Kết xuất|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Đồ họa Véc-tơ có thể mở rộng|—|Kết xuất|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **Tải và Nhập**

- **Tải:** Truyền đường dẫn tệp hoặc luồng vào hàm tạo [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#Presentation-java.lang.String-). Định dạng được phát hiện từ nội dung; [LoadOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/) cung cấp các thiết lập như mật khẩu. Để kiểm tra tệp trước khi mở, gọi [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-), hàm này báo cáo một giá trị [LoadFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadformat/). Nó báo cáo `LoadFormat.Unknown` cho PowerPoint XML, nhưng hàm tạo mở tệp đó, và [Presentation.getSourceFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getSourceFormat--) sau đó trả về `SourceFormat.Xml`. Xem [Mở bản trình chiếu](/slides/vi/java/open-presentation/) và [Xác định Định dạng Gốc của Bản trình chiếu](/slides/vi/java/detect-presentation-source-format/).
- **Nhập:** [SlideCollection.addFromPdf](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) thêm một slide cho mỗi trang PDF vào cuối bản trình chiếu. [SlideCollection.addFromHtml](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) thêm các slide được tạo từ HTML, và [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-) chèn chúng vào vị trí cho trước. Hàm tạo Presentation không thực hiện nhập: nó ném [PptUnsupportedFormatException] cho tệp PDF và không chuyển đổi HTML thành nội dung slide. Xem [Nhập bản trình chiếu từ PDF hoặc HTML](/slides/vi/java/import-presentation/).

## **Lưu và Kết xuất**

- **Lưu:** [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ghi bản trình chiếu theo định dạng của một giá trị [SaveFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveformat/). Các overload nhận thêm một đối tượng tùy chọn điều khiển đầu ra, ví dụ [PdfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/htmloptions/), [Html5Options](https://reference.aspose.com/slides/vi/java/com.aspose.slides/html5options/), [TiffOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tiffoptions/), và [GifOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/gifoptions/). Các overload nhận một mảng vị trí slide, bắt đầu từ 1, chỉ ghi các slide đó; chúng chấp nhận PDF, XPS, TIFF, HTML, HTML5, SWF, GIF và Markdown, nhưng không hỗ trợ các định dạng bản trình chiếu hoặc PowerPoint XML. XAML có overload riêng, [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-), nhận [IXamlOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ixamloptions/). Xem [Lưu bản trình chiếu](/slides/vi/java/save-presentation/), [Chuyển đổi bản trình chiếu](/slides/vi/java/convert-presentation/), và [Xuất bản trình chiếu sang XAML](/slides/vi/java/export-to-xaml/).
- **Kết xuất:** [Slide.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slide/#getImage-float-float-) và [Shape.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getImage--) trả về một [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/), và [IImage.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/#save-java.lang.String-int-) ghi nó dưới dạng PNG, JPEG, BMP, GIF hoặc TIFF, được chọn bằng một giá trị [ImageFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imageformat/). [Presentation.getImages](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) kết xuất tất cả các slide hoặc các slide đã chọn một lúc. [Slide.writeAsSvg](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-) và [Shape.writeAsSvg](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-) ghi SVG, và [Slide.writeAsEmf](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-) ghi EMF. Xem [Chuyển đổi slide bản trình chiếu sang hình ảnh](/slides/vi/java/convert-slide/) và [Kết xuất slide bản trình chiếu dưới dạng ảnh SVG](/slides/vi/java/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}

ImageFormat cũng có các giá trị `Emf`, `Wmf`, `Icon`, `Exif`, và `MemoryBmp`, nhưng IImage.save không tạo ra các định dạng đó: tệp được ghi chứa dữ liệu PNG. Để có ảnh EMF của một slide, sử dụng Slide.writeAsEmf.

{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi bản trình chiếu PPT sang PPTX hoặc ODP không?**

Có. Mở tệp PPT bằng hàm tạo Presentation và lưu nó bằng `SaveFormat.Pptx` hoặc `SaveFormat.Odp`. Xem [Chuyển đổi PPT sang PPTX](/slides/vi/java/convert-ppt-to-pptx/).

**Tôi có thể mở tệp PDF hoặc HTML như một bản trình chiếu không?**

Không. Hàm tạo Presentation ném PptUnsupportedFormatException cho tệp PDF và không chuyển đổi HTML thành các slide. Tạo hoặc mở một bản trình chiếu, nhập các trang PDF hoặc nội dung HTML vào nó bằng các phương thức của SlideCollection mô tả ở trên, sau đó lưu nó ở bất kỳ định dạng hỗ trợ nào.

**Tôi có thể tải ảnh PNG hoặc SVG đã xuất dưới dạng một bản trình chiếu có thể chỉnh sửa không?**

Không. Đầu ra hình ảnh chỉ ghi lại cách một slide trông như thế nào, không phải văn bản, shape hoặc biểu đồ của nó. Giữ bản trình chiếu gốc nếu bạn cần chỉnh sửa sau này.

**Tôi có thể lưu tài liệu PDF/A hoặc PDF/UA không?**

Có. Truyền một giá trị [PdfCompliance](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfcompliance/) vào [PdfOptions.setCompliance](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/#setCompliance-int-): PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, hoặc PDF/UA.

**Tôi có thể kiểm tra xem tệp có được bảo vệ bằng mật khẩu trước khi mở không?**

Có. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) kiểm tra tệp mà không tạo đối tượng Presentation, và [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) báo cáo liệu có cần mật khẩu hay không. Xem [Bảo mật bản trình chiếu bằng mật khẩu](/slides/vi/java/password-protected-presentation/).