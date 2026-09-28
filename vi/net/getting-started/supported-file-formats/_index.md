---
title: Định dạng tệp được hỗ trợ
type: docs
weight: 96
url: /vi/net/supported-file-formats/
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
- .NET
- C#
- Aspose.Slides
description: "Xem các định dạng tệp mà Aspose.Slides for .NET có thể tải, nhập, lưu và kết xuất, và API nào đọc hoặc ghi mỗi định dạng."
---
## **Tổng quan**

Aspose.Slides for .NET mở và lưu các bản trình chiếu PowerPoint và OpenDocument. Nó cũng nhập nội dung PDF và HTML vào các slide, lưu bản trình chiếu sang các định dạng tài liệu, web và hình ảnh, và kết xuất các slide và hình dạng riêng lẻ thành hình ảnh. Bài viết này liệt kê từng định dạng được hỗ trợ và chỉ ra API đọc hoặc ghi chúng.

Cả hai gói NuGet, Aspose.Slides.NET và Aspose.Slides.NET6.CrossPlatform, hỗ trợ cùng các định dạng; xem [Cài đặt](/slides/vi/net/installation/) để lựa chọn. Đối với tổng quan các tính năng chỉnh sửa, xem [Tổng quan tính năng](/slides/vi/net/features-overview/).

## **Phiên bản Microsoft PowerPoint được hỗ trợ**

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
- PowerPoint for Microsoft 365 (trước đây là Office 365)

{{% alert color="info" title="Lưu ý" %}}

Các bản trình chiếu được lưu bởi PowerPoint 95 và các phiên bản trước đó không thể mở được. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) nhận diện tệp PowerPoint 95 và báo cáo `LoadFormat.Ppt95`, nhưng hàm khởi tạo [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) sẽ ném [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) cho tệp này.

{{% /alert %}}

## **Các định dạng tệp được hỗ trợ**

Bảng sử dụng bốn thao tác:

- **Load**: hàm khởi tạo [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) mở tệp dưới dạng bản trình chiếu có thể chỉnh sửa.
- **Import**: một phương thức của [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) tạo slide từ nội dung tệp và thêm chúng vào một bản trình chiếu hiện có. Hàm khởi tạo Presentation không tải các tệp này dưới dạng bản trình chiếu.
- **Save**: [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) ghi bản trình chiếu ra tệp hoặc luồng. Mỗi định dạng ngoại trừ XAML được chọn bằng giá trị [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/).
- **Render**: một phương thức kết xuất vẽ slide hoặc hình dạng dưới dạng hình ảnh. Các định dạng chỉ được kết xuất không phải là giá trị SaveFormat.

|**Định dạng**|**Mô tả**|**Tải / Nhập**|**Lưu / Render**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Bản trình chiếu PowerPoint 97-2003|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|Mẫu PowerPoint 97-2003|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|Trình chiếu PowerPoint 97-2003|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Bản trình chiếu PowerPoint|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|Mẫu PowerPoint|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Trình chiếu PowerPoint|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Bản trình chiếu PowerPoint có Macro|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Mẫu PowerPoint có Macro|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Trình chiếu PowerPoint có Macro|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|Bản trình chiếu OpenDocument|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Bản trình chiếu OpenDocument XML phẳng|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Mẫu bản trình chiếu OpenDocument|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|Bản trình chiếu PowerPoint XML|Load|Save|`SaveFormat.Xml`; các tệp tải lên báo cáo `SourceFormat.Xml` (không có giá trị `LoadFormat`)| 
|[PDF](https://docs.fileformat.com/pdf/)|Định dạng Tài liệu PDF|Import|Save|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Ngôn ngữ Đánh dấu Siêu văn bản|Import|Save|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Định dạng giấy XML (XPS)|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Định dạng Tệp Hình ảnh Đánh thẻ|—|Save, Render|`SaveFormat.Tiff`; `ImageFormat.Tiff` (một slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|Định dạng Đồ họa GIF|—|Save, Render|`SaveFormat.Gif` (có hoạt hình, tất cả slide); `ImageFormat.Gif` (một slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Định dạng Web Nhỏ (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Ngôn ngữ Đánh dấu Ứng dụng mở rộng|—|Save|`Presentation.Save(IXamlOptions)`, một tệp XAML cho mỗi slide; không phải giá trị `SaveFormat`|
|[PNG](https://docs.fileformat.com/image/png/)|Định dạng Hình ảnh PNG|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Hình ảnh JPEG|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Hình ảnh Bitmap|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Metafile nâng cao|—|Render|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Đồ họa Vector có thể mở rộng|—|Render|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **Tải và Nhập**

- **Load:** Truyền đường dẫn tệp hoặc luồng vào hàm khởi tạo [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Định dạng được phát hiện từ nội dung; [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) cung cấp các thiết lập như mật khẩu. Để kiểm tra tệp trước khi mở, gọi [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/), hàm này trả về một giá trị [LoadFormat](https://reference.aspose.com/slides/net/aspose.slides/loadformat/). Nó trả về `LoadFormat.Unknown` cho PowerPoint XML, nhưng hàm khởi tạo vẫn mở được tệp và [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) sau đó trả về `SourceFormat.Xml`. Xem [Mở bản trình chiếu](/slides/vi/net/open-presentation/) và [Xác định định dạng gốc của bản trình chiếu](/slides/vi/net/detect-presentation-source-format/).
- **Import:** [SlideCollection.AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfrompdf/) thêm một slide cho mỗi trang PDF vào cuối bản trình chiếu. [SlideCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/) thêm các slide được tạo từ HTML, và [SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertfromhtml/) chèn chúng vào vị trí chỉ định. Hàm khởi tạo Presentation không thực hiện nhập: nó ném [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) cho tệp PDF và không chuyển đổi HTML thành nội dung slide. Xem [Nhập bản trình chiếu từ PDF hoặc HTML](/slides/vi/net/import-presentation/).

## **Lưu và Render**

- **Save:** [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) ghi bản trình chiếu theo giá trị [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/). Các overload nhận đối tượng tùy chọn điều khiển đầu ra, ví dụ [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/), [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/), [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/), và [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions/). Các overload nhận một mảng vị trí slide, bắt đầu từ 1, chỉ ghi các slide được chỉ định; chúng hỗ trợ PDF, XPS, TIFF, HTML, HTML5, SWF, GIF và Markdown, nhưng không hỗ trợ các định dạng bản trình chiếu hoặc PowerPoint XML. XAML có overload riêng nhận [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/). Xem [Lưu bản trình chiếu](/slides/vi/net/save-presentation/), [Chuyển đổi bản trình chiếu](/slides/vi/net/convert-presentation/), và [Xuất bản trình chiếu sang XAML](/slides/vi/net/export-to-xaml/).
- **Render:** [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) và [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) trả về một [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/), và [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) ghi nó dưới dạng PNG, JPEG, BMP, GIF hoặc TIFF, được chọn bằng giá trị [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/). [Presentation.GetImages](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages/) kết xuất tất cả slide hoặc các slide đã chọn cùng lúc. [Slide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/slide/writeassvg/) và [Shape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) ghi SVG, và [Slide.WriteAsEmf](https://reference.aspose.com/slides/net/aspose.slides/slide/writeasemf/) ghi EMF. Xem [Chuyển đổi slide bản trình chiếu sang hình ảnh](/slides/vi/net/convert-slide/) và [Kết xuất slide dưới dạng ảnh SVG](/slides/vi/net/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Cảnh báo" %}}

ImageFormat cũng có các giá trị `Emf`, `Wmf`, `Icon`, `Exif` và `MemoryBmp`, nhưng IImage.Save không tạo ra các định dạng đó: tệp ghi ra chứa dữ liệu PNG. Để có ảnh EMF của một slide, sử dụng Slide.WriteAsEmf.

{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi bản trình chiếu PPT sang PPTX hoặc ODP không?**

Có. Mở tệp PPT bằng hàm khởi tạo Presentation và lưu nó với `SaveFormat.Pptx` hoặc `SaveFormat.Odp`. Xem [Chuyển đổi PPT sang PPTX](/slides/vi/net/convert-ppt-to-pptx/).

**Tôi có thể mở tệp PDF hoặc HTML dưới dạng bản trình chiếu không?**

Không. Tạo hoặc mở một bản trình chiếu, nhập các trang PDF hoặc nội dung HTML vào bằng các phương thức của SlideCollection đã mô tả ở trên, sau đó lưu nó ở bất kỳ định dạng nào được hỗ trợ.

**Tôi có thể tải một hình ảnh PNG hoặc SVG đã xuất ra làm bản trình chiếu có thể chỉnh sửa không?**

Không. Đầu ra hình ảnh chỉ ghi lại cách slide hiển thị, không chứa văn bản, hình dạng hay biểu đồ. Hãy giữ bản trình chiếu nguồn nếu bạn cần chỉnh sửa sau này.

**Tôi có thể lưu tài liệu PDF/A hoặc PDF/UA không?**

Có. Đặt [PdfOptions.Compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) thành một giá trị [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/): PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b hoặc PDF/UA.

**Tôi có thể kiểm tra một tệp có được bảo vệ bằng mật khẩu trước khi mở không?**

Có. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) kiểm tra tệp mà không tạo đối tượng Presentation, và thuộc tính [IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/ispasswordprotected/) của nó báo cáo liệu tệp có yêu cầu mật khẩu hay không. Xem [Bảo vệ mật khẩu cho bản trình chiếu](/slides/vi/net/password-protected-presentation/).

**Hai gói NuGet có hỗ trợ các định dạng khác nhau không?**

Không. Aspose.Slides.NET và Aspose.Slides.NET6.CrossPlatform có cùng các giá trị LoadFormat và SaveFormat cũng như các phương thức nhập và kết xuất. Chúng khác nhau ở nền tảng chạy và yêu cầu của các nền tảng đó; xem [Cài đặt](/slides/vi/net/installation/).