---
title: Chuyển Đổi Các Slide Bài Trình Chiếu Thành Hình Ảnh trong Node.js qua .NET
linktitle: Slide sang Ảnh
type: docs
weight: 40
url: /vi/nodejs-net/convert-slide/
keywords:
- chuyển đổi slide
- slide thành hình ảnh
- slide thành PNG
- lưu slide dưới dạng hình ảnh
- kết xuất slide
- hình thu nhỏ slide
- PowerPoint
- OpenDocument
- bài trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Kết xuất các slide từ bài trình chiếu PPTX, PPT và ODP thành ảnh PNG trong JavaScript bằng Aspose.Slides cho Node.js qua .NET, với hệ số tỉ lệ hoặc kích thước chính xác tính bằng pixel."
---
## **Tổng quan**

Aspose.Slides for Node.js via .NET renders slides from PowerPoint and OpenDocument presentations as images, for example to show slide previews on a web page. This article shows two ways to choose the image size: a scale factor relative to the slide size, and an exact size in pixels. Both examples save PNG files.

The examples expect a presentation named `sample.pptx` in the project folder that you set up in [Cài đặt](/slides/vi/nodejs-net/installation/). Any PowerPoint presentation will do. Save each example as a `.js` file in the project folder and run it from that folder with `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET không có tài liệu tham khảo API riêng. Nó phản chiếu API Aspose.Slides cho .NET với các tên camelCase, vì vậy các liên kết API trong bài viết này dẫn tới các lớp và thành viên tương ứng trong [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

To convert a slide to an image, follow these steps:

1. Open the presentation with the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) constructor.
1. Get a slide from the [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) collection with `get(index)`. Indexes start at 0.
1. Render the slide with `getImageWithScale` or `getImageWithImageSize`. In the .NET API reference, both are overloads of [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/). They return an image object that corresponds to [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/).
1. Save the image with its [save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) method and an [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) value, and then call its `dispose` method.

## **Chuyển Đổi Mỗi Slide Thành Ảnh PNG**

`getImageWithScale` takes a horizontal and a vertical scale factor. At a scale of 1, one point of the slide becomes one pixel of the image. The following example renders every slide at a scale of 2:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// Một hệ số tỉ lệ 1 sẽ render một pixel cho mỗi point; 2 sẽ gấp đôi chiều rộng và chiều cao.
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

The script writes one file per slide, `slide_1.png`, `slide_2.png`, and so on, numbered from 1. For a 16:9 presentation with slides of 960 × 540 points, each image is 1920 × 1080 pixels. Hidden slides are rendered too; to skip them, check the slide's [hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) property. Each image is disposed in its own `finally` block, which releases it before the next slide is rendered. Without a license, the images also show an evaluation watermark; see [Licensing](/slides/vi/nodejs-net/licensing/).

## **Chuyển Đổi Slide Thành Ảnh Có Kích Thước Xác Định**

`getImageWithImageSize` takes an object with `width` and `height` in pixels. The following example renders the first slide 1280 pixels wide and calculates the height from the slide size, so that the image keeps the slide's aspect ratio:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

The [slideSize.size](https://reference.aspose.com/slides/net/aspose.slides/slidesize/size/) property returns the slide width and height in points. For a 16:9 presentation, the script prints `Saved a 1280 x 720 image` and writes `slide_1_1280px.png`; for a 4:3 presentation, the image is 1280 × 960 pixels.

## **Câu Hỏi Thường Gặp**

**Tại sao ảnh từ `getImage` không có đối số lại quá nhỏ?**

Without arguments, `getImage` renders the slide at 20% of its size in points, so a 960 × 540 point slide becomes a 192 × 108 pixel image. Use `getImageWithScale` or `getImageWithImageSize` to choose the size.

**Làm thế nào để lưu JPEG hoặc các định dạng ảnh khác?**

Pass another `ImageFormat` value to the image's `save` method, for example `image.save("slide_1.jpg", ImageFormat.Jpeg)`. The format comes from the `ImageFormat` value, not from the file extension, so keep the two consistent.

**Tại sao văn bản trong ảnh lại hiện khác trên Linux?**

Aspose.Slides can only use fonts that are installed on the machine that renders the slides. When a presentation uses a font that is missing, such as Calibri on a typical Linux server, Aspose.Slides uses an installed font in its place, which can change the look of the text and where lines break. Install the fonts that your presentations use to get the same images as on Windows.

**Tại sao `getThumbnailWithImageSize` lại gây ra TypeError?**

The package README uses `getThumbnailWithImageSize`, but the package has no `getThumbnail` methods. Use `getImageWithImageSize` instead; it takes the same `{ width, height }` argument.