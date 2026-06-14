---
title: "Nâng cao Xử lý Hình ảnh với API Hiện đại"
linktitle: "API Hiện đại"
type: docs
weight: 280
url: /vi/cpp/modern-api/
keywords:
- System.Drawing
- API hiện đại
- đồ họa
- ảnh thu nhỏ slide
- slide thành hình ảnh
- ảnh thu nhỏ shape
- shape thành hình ảnh
- ảnh thu nhỏ bản trình chiếu
- bản trình chiếu thành hình ảnh
- thêm hình ảnh
- thêm ảnh
- C++
- Aspose.Slides
description: "Hiện đại hóa việc xử lý hình ảnh slide bằng cách thay thế các API ảnh đã lỗi thời bằng API C++ hiện đại để tự động hóa PowerPoint và OpenDocument một cách liền mạch."
---
## **Giới thiệu**

Hiện tại, thư viện Aspose.Slides for C++ có các phụ thuộc trong API công cộng của nó vào các lớp sau từ System::Drawing:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/vi/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/vi/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/vi/cpp/system.drawing/bitmap/)

Kể từ phiên bản 24.4, API công cộng này được khai báo là đã lỗi thời.

Để loại bỏ các phụ thuộc vào System::Drawing trong API công cộng, chúng tôi đã thêm cái gọi là "Modern API". Các phương thức với [System::Drawing::Image](https://reference.aspose.com/slides/vi/cpp/system.drawing/image/) và [System::Drawing::Bitmap](https://reference.aspose.com/slides/vi/cpp/system.drawing/bitmap/) được khai báo là đã lỗi thời và nên được thay thế bằng các phương thức tương ứng từ Modern API. Các phương thức với [System::Drawing::Graphics](https://reference.aspose.com/slides/vi/cpp/system.drawing/graphics/) được khai báo là đã lỗi thời và không có phương thức thay thế trực tiếp trong Modern API.

Trong các phiên bản hiện tại, hãy coi API công cộng phụ thuộc vào các kiểu System::Drawing là kế thừa/đã lỗi thời. Sử dụng Modern API cho mã mới và khi di chuyển các quy trình xử lý ảnh hiện có.

## **API Hiện đại**

Đã thêm các lớp và enum sau vào API công cộng:

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/) - đại diện cho ảnh raster hoặc vector.
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imageformat/) - đại diện cho định dạng tệp của ảnh.
- [Aspose::Slides::Images](https://reference.aspose.com/slides/vi/cpp/aspose.slides/images/) - các phương thức để tạo mẫu và làm việc với giao diện [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/).

Sử dụng `GetImage` để render một slide hoặc shape duy nhất. Sử dụng `GetImages` để render nhiều slide của bản trình chiếu. Sử dụng các phương thức của [Images](https://reference.aspose.com/slides/vi/cpp/aspose.slides/images/) để tải ảnh, `AddImage` với [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/) để thêm chúng vào bản trình chiếu, và `ReplaceImage` với [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/) để cập nhật ảnh đã tồn tại trong bản trình chiếu.

Một kịch bản điển hình khi sử dụng API mới có thể trông như sau:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// khởi tạo một thể hiện có thể hủy của IImage từ tệp trên đĩa.  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// tạo một hình ảnh PowerPoint bằng cách thêm một thể hiện của IImage vào các hình ảnh của bài thuyết trình.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// thêm một shape hình ảnh vào slide #1
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// lấy một thể hiện của IImage đại diện cho slide #1.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// lưu hình ảnh vào đĩa.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **Thay thế mã cũ bằng API Hiện đại**

Để việc chuyển đổi dễ dàng, giao diện của [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/) mới lặp lại các chữ ký riêng biệt của các lớp [System::Drawing::Image](https://reference.aspose.com/slides/vi/cpp/system.drawing/image/) và [System::Drawing::Bitmap](https://reference.aspose.com/slides/vi/cpp/system.drawing/bitmap/). Nói chung, bạn chỉ cần thay thế lời gọi tới phương thức cũ sử dụng System::Drawing bằng phương thức mới.

### **Lấy ảnh thu nhỏ của Slide**

API kế thừa/đã lỗi thời:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

API hiện đại:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **Lấy ảnh thu nhỏ của Shape**

API kế thừa/đã lỗi thời:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

API hiện đại:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **Lấy ảnh thu nhỏ của Presentation**

API kế thừa/đã lỗi thời:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```

API hiện đại:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto images = pres->GetImages(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < images->get_Length(); index++)
{
    System::SharedPtr<IImage> thumbnail = images[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), Aspose::Slides::ImageFormat::Png);
}
```

### **Thêm hình ảnh vào Presentation**

API kế thừa/đã lỗi thời:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

API hiện đại:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

## **Phương thức/Tính chất đã lỗi thời và Thay thế trong Modern API**

### **Lớp Presentation**
|Chữ ký phương thức|Chữ ký phương thức thay thế|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **Lớp Slide**
|Chữ ký phương thức|Chữ ký phương thức thay thế|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|No Modern API replacement|

### **Lớp Shape**
|Chữ ký phương thức|Chữ ký phương thức thay thế|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **Lớp ImageCollection**
|Chữ ký phương thức|Chữ ký phương thức thay thế|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **Lớp PPImage**
|Chữ ký phương thức|Chữ ký phương thức thay thế|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **Lớp PatternFormat**
|Chữ ký phương thức|Chữ ký phương thức thay thế|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **Lớp IPatternFormatEffectiveData**
|Chữ ký phương thức|Chữ ký phương thức thay thế|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **Hỗ trợ API cho System::Drawing::Graphics**

Các phương thức với [System::Drawing::Graphics](https://reference.aspose.com/slides/vi/cpp/system.drawing/graphics/) được khai báo là đã lỗi thời và không có phương thức thay thế trực tiếp trong Modern API.

Sử dụng các phương thức render ảnh của Modern API thay vì API render tới [System::Drawing::Graphics](https://reference.aspose.com/slides/vi/cpp/system.drawing/graphics/):
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **Câu hỏi thường gặp**

**Tại sao [System::Drawing::Graphics](https://reference.aspose.com/slides/vi/cpp/system.drawing/graphics/) bị loại bỏ?**

Hỗ trợ cho [System::Drawing::Graphics](https://reference.aspose.com/slides/vi/cpp/system.drawing/graphics/) đã bị lỗi thời trong API công cộng để thống nhất công việc render và ảnh, loại bỏ các phụ thuộc vào nền tảng cụ thể, và chuyển sang cách tiếp cận đa nền tảng với [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/). Sử dụng `GetImage` hoặc `GetImages` thay vì render tới [System::Drawing::Graphics](https://reference.aspose.com/slides/vi/cpp/system.drawing/graphics/).

**Lợi ích thực tế của [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/) so với [System::Drawing::Image](https://reference.aspose.com/slides/vi/cpp/system.drawing/image/)/[System::Drawing::Bitmap](https://reference.aspose.com/slides/vi/cpp/system.drawing/bitmap/) là gì?**

[IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/) thống nhất việc làm việc với cả ảnh raster và vector, đơn giản hoá việc lưu ở các định dạng khác nhau qua [ImageFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imageformat/), giảm phụ thuộc vào `System::Drawing`, và làm cho mã dễ chuyển đổi giữa các môi trường.

**Modern API có ảnh hưởng tới hiệu năng tạo ảnh thu nhỏ không?**

Việc chuyển từ `GetThumbnail` sang `GetImage` không làm giảm hiệu năng trong các kịch bản: các phương thức mới cung cấp cùng khả năng tạo ảnh với tùy chọn và kích thước, đồng thời vẫn hỗ trợ các tùy chọn render. Lợi nhuận hoặc giảm hiệu năng cụ thể phụ thuộc vào từng trường hợp, nhưng về chức năng các phương thức thay thế là tương đương.