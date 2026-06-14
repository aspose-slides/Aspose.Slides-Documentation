---
title: Tối ưu hóa Quản lý Hình ảnh trong Bài thuyết trình bằng .NET
linktitle: Quản lý Hình ảnh
type: docs
weight: 10
url: /vi/net/image/
keywords:
- thêm hình ảnh
- thêm ảnh
- thêm bitmap
- thay thế hình ảnh
- thay thế ảnh
- từ web
- nền
- thêm PNG
- thêm JPG
- thêm SVG
- thêm EMF
- thêm WMF
- thêm TIFF
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tối ưu hoá quản lý hình ảnh trong PowerPoint và OpenDocument với Aspose.Slides cho .NET, nâng cao hiệu suất và tự động hoá quy trình làm việc của bạn."
---
## **Giới thiệu**

Hình ảnh làm cho bài thuyết trình trở nên hấp dẫn và thú vị hơn. Trong Microsoft PowerPoint, bạn có thể chèn ảnh từ tệp, internet hoặc các vị trí khác vào các slide. Tương tự, Aspose.Slides cho phép bạn thêm hình ảnh vào các slide trong bài thuyết trình thông qua các quy trình khác nhau.

{{% alert  title="Tip" color="primary" %}} 

Aspose cung cấp các trình chuyển đổi miễn phí—[JPEG to PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG to PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—cho phép người dùng tạo bài thuyết trình nhanh chóng từ hình ảnh. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Nếu bạn muốn thêm một hình ảnh dưới dạng đối tượng khung—đặc biệt nếu bạn dự định sử dụng các tùy chọn định dạng chuẩn trên nó để thay đổi kích thước, thêm hiệu ứng, v.v.—xem [Picture Frame](https://docs.aspose.com/slides/vi/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Bạn có thể thao tác các hoạt động nhập/xuất liên quan đến hình ảnh và bài thuyết trình PowerPoint để chuyển đổi một hình ảnh từ định dạng này sang định dạng khác. Xem các trang sau: chuyển đổi [image to JPG](https://products.aspose.com/slides/vi/net/conversion/image-to-jpg/); chuyển đổi [JPG to image](https://products.aspose.com/slides/vi/net/conversion/jpg-to-image/); chuyển đổi [JPG to PNG](https://products.aspose.com/slides/vi/net/conversion/jpg-to-png/), chuyển đổi [PNG to JPG](https://products.aspose.com/slides/vi/net/conversion/png-to-jpg/); chuyển đổi [PNG to SVG](https://products.aspose.com/slides/vi/net/conversion/png-to-svg/), chuyển đổi [SVG to PNG](https://products.aspose.com/slides/vi/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides hỗ trợ các hoạt động với hình ảnh trong các định dạng phổ biến này: JPEG, PNG, BMP, GIF và các định dạng khác. 

## **Thêm hình ảnh lưu trữ cục bộ vào các slide**

Bạn có thể thêm một hoặc nhiều hình ảnh trên máy tính của mình vào một slide trong bài thuyết trình. Mã mẫu này bằng C# cho thấy cách thêm hình ảnh vào slide:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Thêm hình ảnh từ web vào các slide**

Nếu hình ảnh bạn muốn thêm vào slide không có trên máy tính, bạn có thể thêm hình ảnh trực tiếp từ web. 

Mã mẫu này cho thấy cách thêm hình ảnh từ web vào slide bằng C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Thêm hình ảnh vào Slide Master**

Slide master là slide trên cùng lưu trữ và kiểm soát thông tin (chủ đề, bố cục, v.v.) của tất cả các slide bên dưới nó. Vì vậy, khi bạn thêm hình ảnh vào slide master, hình ảnh đó sẽ xuất hiện trên mọi slide dưới slide master đó. 

Mã mẫu C# này cho thấy cách thêm hình ảnh vào slide master:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Thêm hình ảnh làm nền slide**

Bạn có thể quyết định sử dụng một bức ảnh làm nền cho một slide cụ thể hoặc nhiều slide. Trong trường hợp đó, bạn cần xem *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/vi/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Thêm SVG vào Bài thuyết trình**
Bạn có thể thêm hoặc chèn bất kỳ hình ảnh nào vào bài thuyết trình bằng cách sử dụng phương thức [AddPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/methods/addpictureframe) thuộc giao diện [IShapeCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection).

Để tạo một đối tượng hình ảnh dựa trên hình ảnh SVG, bạn có thể làm như sau:

1. Tạo đối tượng SvgImage để chèn vào ImageShapeCollection
2. Tạo đối tượng PPImage từ ISvgImage
3. Tạo đối tượng PictureFrame bằng giao diện IPPImage

Mã mẫu này cho thấy cách thực hiện các bước trên để thêm hình ảnh SVG vào bài thuyết trình:
``` csharp 
// Đường dẫn tới thư mục tài liệu
string dataDir = @"D:\Documents\";

// Tên tệp SVG nguồn
string svgFileName = dataDir + "sample.svg";

// Tên tệp bài thuyết trình đầu ra
string outPptxPath = dataDir + "presentation.pptx";

// Tạo bài thuyết trình mới
using (var p = new Presentation())
{
    // Đọc nội dung tệp SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Tạo đối tượng SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Tạo đối tượng PPImage
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // Tạo một PictureFrame mới 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // Lưu bài thuyết trình ở định dạng PPTX
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Chuyển đổi SVG thành một tập hợp các hình dạng**
Việc chuyển đổi SVG thành một tập hợp các hình dạng của Aspose.Slides tương tự như chức năng của PowerPoint được sử dụng để làm việc với hình ảnh SVG:

![PowerPoint Popup Menu](img_01_01.png)

Chức năng này được cung cấp bởi một trong những overload của phương thức [AddGroupShape](https://reference.aspose.com/slides/vi/net/aspose.slides.ishapecollection/addgroupshape/methods/1) của giao diện [IShapeCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection) có tham số đầu tiên là một đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/net/aspose.slides/isvgimage).

Mã mẫu này cho thấy cách sử dụng phương pháp đã mô tả để chuyển đổi tệp SVG thành một tập hợp các hình dạng:

``` csharp 
// Đường dẫn tới thư mục tài liệu
string dataDir = @"D:\Documents\";

// Tên tệp SVG nguồn
string svgFileName = dataDir + "sample.svg";

// Tên tệp bài thuyết trình đầu ra
string outPptxPath = dataDir + "presentation.pptx";

// Tạo bài thuyết trình mới
using (IPresentation presentation = new Presentation())
{
    // Đọc nội dung tệp SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Tạo đối tượng SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Lấy kích thước slide
    SizeF slideSize = presentation.SlideSize.Size;

    // Chuyển đổi hình ảnh SVG thành nhóm các hình dạng và co dãn chúng theo kích thước slide
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Lưu bài thuyết trình ở định dạng PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Thêm hình ảnh dưới dạng EMF vào các slide**
Aspose.Slides cho .NET cho phép bạn tạo hình ảnh EMF từ các bảng tính Excel và thêm các hình ảnh dưới dạng EMF vào các slide với Aspose.Cells. 

Mã mẫu này cho thấy cách thực hiện nhiệm vụ đã mô tả:

``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    // Lưu sổ làm việc vào luồng
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Thay thế hình ảnh trong Bộ sưu tập Hình ảnh**

Aspose.Slides cho phép bạn thay thế các hình ảnh được lưu trong bộ sưu tập hình ảnh của một bài thuyết trình (bao gồm cả những hình ảnh được các hình dạng slide sử dụng). Phần này trình bày một số cách tiếp cận để cập nhật hình ảnh trong bộ sưu tập. API cung cấp các phương thức đơn giản để thay thế một hình ảnh bằng dữ liệu byte thô, một thể hiện [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/), hoặc một hình ảnh khác đã tồn tại trong bộ sưu tập.

1. Tải tệp bài thuyết trình chứa hình ảnh bằng lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).
2. Tải một hình ảnh mới từ tệp vào một mảng byte.
3. Thay thế hình ảnh mục tiêu bằng hình ảnh mới bằng cách sử dụng mảng byte.
4. Trong cách tiếp cận thứ hai, tải hình ảnh vào một đối tượng [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) và thay thế hình ảnh mục tiêu bằng đối tượng đó.
5. Trong cách tiếp cận thứ ba, thay thế hình ảnh mục tiêu bằng một hình ảnh đã tồn tại trong bộ sưu tập hình ảnh của bài thuyết trình.
6. Ghi bài thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

```cs
// Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình.
using Presentation presentation = new Presentation("sample.pptx");

// Cách đầu tiên.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// Cách thứ hai.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// Cách thứ ba.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Lưu bài thuyết trình vào tệp.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}

Sử dụng trình chuyển đổi Aspose FREE [Text to GIF](https://products.aspose.app/slides/vi/text-to-gif), bạn có thể dễ dàng tạo hoạt ảnh cho văn bản, tạo GIF từ văn bản, v.v. 

{{% /alert %}}

## **Câu hỏi thường gặp**

**Độ phân giải gốc của hình ảnh có được giữ nguyên sau khi chèn không?**

Có. Các pixel gốc được bảo tồn, nhưng diện mạo cuối cùng phụ thuộc vào cách mà [picture](/slides/vi/net/picture-frame/) được thu phóng trên slide và bất kỳ việc nén nào được áp dụng khi lưu.

**Cách tốt nhất để thay thế cùng một logo trên hàng chục slide cùng một lúc là gì?**

Đặt logo trên slide master hoặc một layout và thay thế nó trong bộ sưu tập hình ảnh của bài thuyết trình—các cập nhật sẽ lan tới tất cả các yếu tố sử dụng tài nguyên đó.

**Có thể chuyển đổi SVG đã chèn thành các hình dạng có thể chỉnh sửa được không?**

Có. Bạn có thể chuyển đổi SVG thành một nhóm các hình dạng, sau đó các phần riêng lẻ sẽ trở nên có thể chỉnh sửa bằng các thuộc tính hình dạng tiêu chuẩn.

**Làm sao để đặt một bức ảnh làm nền cho nhiều slide cùng một lúc?**

[Assign the image as the background](/slides/vi/net/presentation-background/) trên slide master hoặc layout liên quan—bất kỳ slide nào dùng master/layout đó sẽ kế thừa nền.

**Làm sao để ngăn bài thuyết trình "phồng to" do quá nhiều hình ảnh?**

Tái sử dụng một nguồn hình ảnh duy nhất thay vì sao chép, chọn độ phân giải hợp lý, áp dụng nén khi lưu, và giữ các đồ họa lặp lại trên master khi thích hợp.