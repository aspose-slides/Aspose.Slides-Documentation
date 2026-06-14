---
title: Tạo Trình Xem Bản Trình Chiếu trên Android
linktitle: Trình Xem Bản Trình Chiếu
type: docs
weight: 50
url: /vi/androidjava/presentation-viewer/
keywords:
- xem bản trình chiếu
- trình xem bản trình chiếu
- tạo trình xem bản trình chiếu
- xem PPT
- xem PPTX
- xem ODP
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tạo một trình xem bản trình chiếu tùy chỉnh trong Java bằng Aspose.Slides cho Android. Dễ dàng hiển thị các tệp PowerPoint và OpenDocument mà không cần Microsoft PowerPoint."
---
## **Introduction**

Aspose.Slides cho Android thông qua Java được sử dụng để tạo các tệp trình chiếu với các slide. Các slide này có thể được xem bằng cách mở trình chiếu trong Microsoft PowerPoint, ví dụ. Tuy nhiên, đôi khi các nhà phát triển có thể cần xem slide dưới dạng hình ảnh trong trình xem ảnh ưa thích của họ hoặc tạo trình xem trình chiếu riêng. Trong những trường hợp đó, Aspose.Slides cho phép bạn xuất một slide riêng lẻ dưới dạng hình ảnh. Bài viết này mô tả cách thực hiện.

## **Generate an SVG Image from a Slide**

Để tạo một ảnh SVG từ slide trình chiếu bằng Aspose.Slides, vui lòng làm theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
2. Lấy tham chiếu slide theo chỉ mục của nó.
3. Mở một luồng tệp.
4. Lưu slide dưới dạng ảnh SVG vào luồng tệp.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Generate an SVG with a Custom Shape ID**

Aspose.Slides có thể được sử dụng để tạo một [SVG](https://docs.fileformat.com/page-description-language/svg/) từ một slide với ID hình dạng tùy chỉnh. Để thực hiện điều này, sử dụng phương thức `setId` từ [ISvgShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgshape/). `CustomSvgShapeFormattingController` có thể được dùng để đặt ID cho hình dạng.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Create a Slide Thumbnail Image**

Aspose.Slides giúp bạn tạo các hình thu nhỏ của slide. Để tạo hình thu nhỏ của một slide bằng Aspose.Slides, vui lòng làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
2. Lấy tham chiếu slide theo chỉ mục của nó.
3. Lấy hình ảnh thu nhỏ của slide đã tham chiếu với tỷ lệ đã định nghĩa.
4. Lưu hình ảnh thu nhỏ dưới bất kỳ định dạng ảnh nào mong muốn.

```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Create a Slide Thumbnail with User Defined Dimensions**

Để tạo hình thu nhỏ của slide với kích thước do người dùng định nghĩa, vui lòng làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
2. Lấy tham chiếu slide theo chỉ mục của nó.
3. Lấy hình ảnh thu nhỏ của slide đã tham chiếu với các kích thước được định nghĩa.
4. Lưu hình ảnh thu nhỏ dưới bất kỳ định dạng ảnh nào mong muốn.

```java
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Create a Slide Thumbnail with Speaker Notes**

Để tạo hình thu nhỏ của một slide kèm ghi chú người thuyết trình bằng Aspose.Slides, vui lòng làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [RenderingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/renderingoptions/).
2. Sử dụng phương thức `RenderingOptions.setSlidesLayoutOptions` để đặt vị trí của ghi chú người thuyết trình.
3. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
4. Lấy tham chiếu slide theo chỉ mục của nó.
5. Lấy hình ảnh thu nhỏ của slide đã tham chiếu với các tùy chọn render.
6. Lưu hình ảnh thu nhỏ dưới bất kỳ định dạng ảnh nào mong muốn.

```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **Live Example**

Bạn có thể thử ứng dụng miễn phí [**Aspose.Slides Viewer**](https://products.aspose.app/slides/vi/viewer/) để xem những gì bạn có thể thực hiện với API của Aspose.Slides:

![Trình xem PowerPoint trực tuyến](online-PowerPoint-viewer.png)

## **FAQ**

**Tôi có thể nhúng trình xem trình chiếu vào một ứng dụng web không?**

Có. Bạn có thể sử dụng Aspose.Slides ở phía máy chủ để hiển thị slide dưới dạng hình ảnh hoặc HTML và hiển thị chúng trong trình duyệt. Các tính năng điều hướng và thu phóng có thể được triển khai bằng JavaScript để tạo trải nghiệm tương tác.

**Cách tốt nhất để hiển thị slide trong một trình xem tùy chỉnh là gì?**

Cách được khuyến nghị là render mỗi slide dưới dạng hình ảnh (ví dụ: PNG hoặc SVG) hoặc chuyển đổi nó sang HTML bằng Aspose.Slides, sau đó hiển thị kết quả trong một hộp ảnh (đối với desktop) hoặc trong một container HTML (đối với web).

**Làm sao tôi xử lý các bản trình chiếu lớn với nhiều slide?**

Đối với các bộ slide lớn, hãy cân nhắc tải lười hoặc render slide theo yêu cầu. Điều này có nghĩa là tạo nội dung của slide chỉ khi người dùng chuyển tới, giúp giảm bộ nhớ và thời gian tải.