---
title: Quản lý các hiệu ứng biến đổi ảnh trong bài thuyết trình với .NET
linktitle: Hiệu ứng biến đổi ảnh
type: docs
weight: 11
url: /vi/net/image-transform-effects/
keywords:
- biến đổi ảnh
- hiệu ứng hình ảnh
- độ sáng
- độ tương phản
- xám
- đôi màu
- tông màu
- HSL
- thay thế màu
- làm mờ
- độ trong suốt
- hiệu ứng alpha
- chuỗi hiệu ứng
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Áp dụng, xâu chuỗi, kiểm tra, xóa và xác minh các hiệu ứng biến đổi ảnh cho khung hình với Aspose.Slides cho .NET."
---
## **Tổng quan**

Aspose.Slides đại diện cho việc điều chỉnh hình ảnh dưới dạng một bộ sưu tập có thứ tự của các thao tác biến đổi ảnh. Đối với một khung hình, bắt đầu với [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) của khung và truy cập [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/imagetransform/). Bộ [IImageTransformOperationCollection](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/) trả về cho phép bạn thêm, liệt kê, kiểm tra, xóa và xóa sạch các hiệu ứng mà không cần ghi lại byte ảnh gốc.

Bài viết này trình bày quy trình hoàn chỉnh cho độ sáng và độ tương phản, các biến đổi màu, làm mờ, độ trong suốt, chuỗi hiệu ứng có thứ tự, giá trị thực tế, việc xóa và xác minh vòng vòng PPTX.

## **Hiểu về sở hữu hiệu ứng và việc tái sử dụng ảnh**

Một tài nguyên ảnh và hình ảnh hiển thị nó là hai đối tượng khác nhau:

- [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) lưu trữ hoặc tham chiếu dữ liệu ảnh nguồn mà bản trình bày sở hữu.
- [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) thuộc về phần nền ảnh và tham chiếu tài nguyên ảnh đồng thời lưu trữ bộ sưu tập biến đổi ảnh.
- [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) là đối tượng hình dạng trên slide sở hữu phần nền ảnh, hình học, cài đặt cắt và các định dạng cấp khung khác.

Do đó, các thao tác biến đổi ảnh không thay đổi byte trong [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/). Khi cùng một `IPPImage` được truyền cho [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) nhiều hơn một lần, mỗi khung ảnh mới nhận được `ISlidesPicture` và bộ sưu tập biến đổi riêng. Áp dụng hiệu ứng tô màu xám cho một khung không làm cho các khung khác cũng trở thành tô màu xám, dù chúng đều tái sử dụng cùng một tài nguyên ảnh nhúng.

Mô hình `ISlidesPicture.ImageTransform` cũng được sử dụng bởi các phần nền ảnh khác, chẳng hạn như hình dạng hoặc nền slide. Các ví dụ dưới đây tập trung vào khung ảnh.

## **Sử dụng phạm vi và đơn vị tham số hợp lệ**

Các phương pháp được minh họa sử dụng các phạm vi ngữ nghĩa và đơn vị sau. Giữ các giá trị trong phạm vi này ngay cả khi một phiên bản thư viện cụ thể không từ chối ngay lập tức mọi giá trị ngoài phạm vi; định dạng bản trình bày đích có thể chuẩn hoá, bỏ qua hoặc từ chối dữ liệu không hợp lệ khi lưu hoặc khi PowerPoint mở tệp.

| Thao tác | Tham số | Phạm vi và đơn vị hợp lệ |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` đến `100`, phần trăm; `0` để giữ nguyên thành phần. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Không có | Không có tham số số. Alpha được giữ nguyên. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Hai màu cho pixel tối và sáng. Kênh RGB và alpha trong `System.Drawing.Color` dùng giá trị từ `0` đến `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue từ `0` (bao gồm) đến `360` (không bao gồm), đơn vị độ; amount từ `-100` đến `100`, phần trăm. |
| [AddHSLEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue từ `0` (bao gồm) đến `360` (không bao gồm), độ; saturation và luminance từ `-100` đến `100`, phần trăm. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Màu thay thế sử dụng các giá trị kênh từ `0` đến `255`. Giá trị alpha hiện tại không thay đổi. |
| [AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Bán kính không âm, đo bằng point; `grow` là Boolean quyết định nội dung mờ có thể mở rộng ra ngoài giới hạn ban đầu hay không. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Phần trăm không âm. Dùng `0` đến `100` cho việc thu phóng độ trong suốt thông thường: `0` hoàn toàn trong suốt và `100` bảo tồn alpha hiện có. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` đến `100`, phần trăm độ trong suốt. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` đến `100`, phần trăm ngưỡng alpha. Giá trị dưới ngưỡng sẽ trở nên trong suốt; giá trị bằng hoặc trên ngưỡng sẽ trở nên không trong suốt. |

Đối với điều chế alpha cố định, độ trong suốt và độ mờ là các khái niệm bổ trợ. Ví dụ, độ trong suốt 35% tương ứng với mức điều chế alpha 65%.

## **Áp dụng độ sáng và độ tương phản**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) trả về một thao tác [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/). Các thiết lập vô hướng được cung cấp khi tạo thao tác. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/geteffective/) trả về các giá trị chỉ đọc đã tính toán có thể kiểm tra hoặc ghi log.

Ví dụ sau tăng độ sáng 15 % và độ tương phản 20 %, sau đó tạo bản xem trước mà không thay đổi ảnh nhúng:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
IBrightnessContrast brightnessContrast = imageTransform.AddBrightnessContrastEffect(15f, 20f);

var effectiveValues = brightnessContrast.GetEffective();
Console.WriteLine("Brightness: " + effectiveValues.Brightness + "%");
Console.WriteLine("Contrast: " + effectiveValues.Contrast + "%");

using var preview = slide.GetImage();
preview.Save("brightness-contrast-preview.png", ImageFormat.Png);
```

[BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) là một phần mở rộng hiệu ứng ảnh Office 2010 và ít di động hơn hiệu ứng luminance chuẩn của DrawingML. Khi cần giữ khả năng chỉnh sửa độ sáng và độ tương phản sau một vòng quay PPTX, hãy dùng [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) và xác minh kết quả sau khi mở lại tệp. Phần giới hạn định dạng giải thích chi tiết sự khác biệt này.

## **Áp dụng các biến đổi màu**

Các hiệu ứng màu có thể được áp dụng độc lập cho các khung ảnh khác nhau mà tái sử dụng cùng một tài nguyên ảnh. Ví dụ dưới đây tạo năm khung và áp dụng các hiệu ứng: tô màu xám, duotone, tint, điều chỉnh HSL và thay thế màu.

[IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) chứa hai tham số màu có thể chỉnh sửa độc lập: `Color1` ánh xạ cho pixel tối, còn `Color2` ánh xạ cho pixel sáng. Điều này làm cho nó trở thành một ví dụ hữu ích của hiệu ứng có cấu hình phức tạp hơn một giá trị vô hướng đơn.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var grayFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
grayFrame.PictureFormat.Picture.ImageTransform.AddGrayScaleEffect();

var duotoneFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
var duotone = duotoneFrame.PictureFormat.Picture.ImageTransform.AddDuotoneEffect();
duotone.Color1.Color = Color.Navy;
duotone.Color2.Color = Color.Gold;

var tintFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
tintFrame.PictureFormat.Picture.ImageTransform.AddTintEffect(210f, 35f);

var hslFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
hslFrame.PictureFormat.Picture.ImageTransform.AddHSLEffect(30f, 20f, -10f);

var replacementFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
var colorReplacement = replacementFrame.PictureFormat.Picture.ImageTransform.AddColorReplaceEffect();
colorReplacement.Color.Color = Color.CornflowerBlue;

presentation.Save("color-transformations.pptx", SaveFormat.Pptx);
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) thay thế màu của mọi pixel bằng một màu cố định trong khi bảo tồn alpha. Nó khác với [AddColorChangeEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), hiệu ứng này ánh xạ một màu nguồn sang màu đích và hiển thị cả định dạng màu nguồn và đích.

### **Áp dụng ngưỡng luminance**

Ngưỡng luminance có thể làm cho các dấu mờ trên trang quét dễ phân biệt hơn so với nền. [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) giữ lại các sắc thái xám trung gian. [AddBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) ánh xạ luminance thành đen hoặc trắng, trong khi [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) áp dụng ngưỡng cho độ trong suốt.

Ngưỡng luminance dao động từ 0 % đến 100 %, bao gồm cả hai đầu. Pixel dưới ngưỡng trở thành đen. Pixel bằng hoặc trên ngưỡng trở thành trắng. Tăng ngưỡng sẽ làm nhiều sắc thái chuyển sang đen vì chúng rơi dưới mức cắt.

Tải xuống [grayscale-swatches.png](grayscale-swatches.png) vào thư mục làm việc. Mỗi nhãn cho biết mức xám nguyên gốc trên thang từ 0 đến 255. Ví dụ đặt bản gốc bên cạnh hai bản sao và lưu ngưỡng của mỗi bản sao trong bản trình bày.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 150, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var imageData = File.ReadAllBytes("grayscale-swatches.png");
var image = presentation.Images.AddImage(imageData);

IPictureFrame AddFrame(float x, string caption)
{
    shapes.AddAutoShape(ShapeType.Rectangle, x, 12, 216, 36).TextFrame.Text = caption;
    return shapes.AddPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
}

AddFrame(12, "Original");

var lowThreshold = AddFrame(252, "Threshold 20%");
lowThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(20f);

var highThreshold = AddFrame(492, "Threshold 60%");
highThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(60f);

presentation.Save("luminance-threshold.pptx", SaveFormat.Pptx);
```

Mở bản trình bày đã xuất ra trong PowerPoint để so sánh ba khung. Bảng màu có nhãn 96 có khoảng 38 % luminance (96 trên 255). Nó chuyển sang trắng ở ngưỡng 20 % và sang đen ở ngưỡng 60 %.

![Các mẫu grayscale gốc bên cạnh kết quả đen‑trắng ở ngưỡng luminance 20 % và 60 %](luminance-threshold.png)

## **Thêm hiệu ứng làm mờ, độ trong suốt và alpha**

[AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) ảnh hưởng tới tất cả các kênh màu, bao gồm alpha. Đặt `grow` thành `true` khi cạnh mờ có thể mở rộng ra ngoài giới hạn ảnh gốc.

Đối với độ trong suốt đồng nhất, hãy dùng [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Nó nhân mỗi giá trị alpha hiện có, vì vậy các pixel bán trong suốt vẫn giữ tỉ lệ khác nhau. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) thay vào đó gán một giá trị alpha duy nhất cho mọi pixel. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) chuyển đổi alpha thành hai mức dựa trên ngưỡng.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var blurredFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
var blur = blurredFrame.PictureFormat.Picture.ImageTransform.AddBlurEffect(4.5, true);
blur.Radius = 5;

var transparentFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
var alphaModulate = transparentFrame.PictureFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(65f);
alphaModulate.Amount = 60f;

var uniformAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
uniformAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaReplaceEffect(55f);

var binaryAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
var alphaBiLevel = binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaBiLevelEffect(50f);
alphaBiLevel.Threshold = 45f;
binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaInverseEffect();

presentation.Save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
```

Các thao tác alpha không có tham số khác bao gồm [AddAlphaCeilingEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), khiến mọi alpha khác 0 trở nên hoàn toàn mờ; [AddAlphaFloorEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), khiến mọi alpha dưới 100 % trở nên hoàn toàn trong suốt; và [AddAlphaInverseEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), thay đổi alpha thành `100% - alpha`.

## **Xây dựng chuỗi hiệu ứng có thứ tự**

Mỗi phương pháp `Add...Effect` thêm một thao tác mới vào cuối bộ sưu tập. Trình kết xuất sử dụng bộ sưu tập như một pipeline có thứ tự: đầu ra của thao tác 0 trở thành đầu vào của thao tác 1, và cứ tiếp tục như vậy. Do đó, cùng một tập các thao tác nhưng sắp xếp khác nhau có thể tạo ra ảnh khác nhau.

Ví dụ, grayscale rồi tint sẽ đầu tiên loại bỏ thông tin màu và sau đó tô lại kết quả luminance. Tint rồi grayscale lại loại bỏ tint. Tương tự, thay thế alpha có thể ghi đè giá trị alpha được tính bởi các thao tác trước, trong khi điều chế alpha giữ lại sự chênh lệch tương đối của chúng.

Ví dụ dưới đây xây dựng một chuỗi bốn thao tác, lưu dưới dạng PPTX, mở lại bản trình bày, kiểm tra cả kiểu thao tác và thứ tự, và tạo bản xem trước của kết quả đã mở lại:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
imageTransform.AddGrayScaleEffect();
imageTransform.AddTintEffect(220f, 25f);
imageTransform.AddBlurEffect(2.5, false);
imageTransform.AddAlphaModulateFixedEffect(80f);

presentation.Save("image-transform-chain.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("image-transform-chain.pptx");
var reopenedShape = reopenedPresentation.Slides[0].Shapes[0];

if (reopenedShape is IPictureFrame reopenedFrame)
{
    var reopenedTransform = reopenedFrame.PictureFormat.Picture.ImageTransform;
    var orderIsPreserved = reopenedTransform.Count == 4 && 
            reopenedTransform[0] is IGrayScale && 
            reopenedTransform[1] is ITint && 
            reopenedTransform[2] is IBlur && 
            reopenedTransform[3] is IAlphaModulateFixed;
    Console.WriteLine(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

    using var renderedSlide = reopenedPresentation.Slides[0].GetImage();
    renderedSlide.Save("reopened-effect-chain.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The reopened shape is not a picture frame.");
}
```

Bộ sưu tập không áp đặt ma trận tương thích giới hạn các thao tác màu, alpha và làm mờ thành các chuỗi riêng biệt. Chúng có thể được kết hợp, nhưng không phải mọi tổ hợp đều hữu ích. Thay thế màu cố định loại bỏ biến thể RGB do các hiệu ứng màu trước đó tạo ra; grayscale sau duotone loại bỏ hai màu đã chọn; và các thao tác alpha ceiling, floor, replace hoặc bi‑level có thể xóa chi tiết alpha được tạo ra trước. Hãy xây dựng chuỗi dựa trên trình tự xử lý pixel mong muốn thay vì xem các mục như những cờ định dạng không thứ tự.

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Trong minh họa Aspose.Slides for .NET 26.11 này, một tint 220° ở 25 % không làm thay đổi ảnh grayscale. Áp dụng cùng một tint trước khi chuyển sang grayscale sẽ tạo ra các tông màu khác nhau.*
<!-- visual-explanation:image-transform-effects:end -->

## **Kiểm tra giá trị có thể chỉnh sửa và giá trị thực tế**

Một thao tác có thể chỉnh sửa là đối tượng được lưu trong `ISlidesPicture.ImageTransform`. Tùy thuộc vào hiệu ứng, nó có thể cung cấp các thành viên có thể ghi trực tiếp. Ví dụ, [IBlur](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/) cung cấp `Radius` và `Grow` có thể ghi, [IAlphaModulateFixed](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphamodulatefixed/) cung cấp `Amount` có thể ghi, và [IAlphaBiLevel](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphabilevel/) cung cấp `Threshold` có thể ghi. Các hiệu ứng màu như [IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) cung cấp các đối tượng [IColorFormat](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/) có thể thay đổi.

Một số giao diện thao tác, bao gồm [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/net/aspose.slides.effects/itint/), và [IAlphaReplace](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphareplace/), không lộ các tham số tạo ra dưới dạng thuộc tính có thể ghi. Để thay đổi các cài đặt này, hãy xóa thao tác và thêm một thao tác thay thế ở vị trí yêu cầu.

Dữ liệu thực tế trả về bởi `GetEffective()` được tính toán và chỉ đọc. Nó hữu ích để giải quyết các màu phụ thuộc vào theme và đọc các giá trị đã chuẩn hoá mà trình kết xuất sử dụng, nhưng không phải là một bề mặt chỉnh sửa khác. Ví dụ sau liệt kê chuỗi và kiểm tra các giá trị thực tế nơi API tương ứng cung cấp chúng:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        var operation = imageTransform[index];
        Console.WriteLine(index + ": " + operation.GetType().Name);

        switch (operation)
        {
            case IBrightnessContrast brightnessContrast:
                var brightnessContrastData = brightnessContrast.GetEffective();
                Console.WriteLine("  Brightness: " + brightnessContrastData.Brightness);
                Console.WriteLine("  Contrast: " + brightnessContrastData.Contrast);
                break;
            case ILuminance luminance:
                var luminanceData = luminance.GetEffective();
                Console.WriteLine("  Brightness: " + luminanceData.Brightness);
                Console.WriteLine("  Contrast: " + luminanceData.Contrast);
                break;
            case IDuotone duotone:
                var duotoneData = duotone.GetEffective();
                Console.WriteLine("  Dark color: " + duotoneData.Color1);
                Console.WriteLine("  Light color: " + duotoneData.Color2);
                break;
            case IColorReplace colorReplace:
                var colorReplaceData = colorReplace.GetEffective();
                Console.WriteLine("  Replacement color: " + colorReplaceData.Color);
                break;
            case IHSL hsl:
                var hslData = hsl.GetEffective();
                Console.WriteLine("  HSL: " + hslData.Hue + ", " + hslData.Saturation + ", " + hslData.Luminance);
                break;
            case ITint tint:
                var tintData = tint.GetEffective();
                Console.WriteLine("  Tint: " + tintData.Hue + ", " + tintData.Amount);
                break;
            case IBlur blur:
                var blurData = blur.GetEffective();
                Console.WriteLine("  Blur radius: " + blurData.Radius + " pt");
                break;
            case IAlphaModulateFixed alphaModulate:
                var alphaData = alphaModulate.GetEffective();
                Console.WriteLine("  Alpha amount: " + alphaData.Amount + "%");
                break;
            case IAlphaReplace alphaReplace:
                var alphaReplaceData = alphaReplace.GetEffective();
                Console.WriteLine("  Replacement alpha: " + alphaReplaceData.Alpha + "%");
                break;
            case IAlphaBiLevel alphaBiLevel:
                var alphaBiLevelData = alphaBiLevel.GetEffective();
                Console.WriteLine("  Alpha threshold: " + alphaBiLevelData.Threshold + "%");
                break;
        }
    }
}
```

Các hiệu ứng không có tham số như grayscale, alpha ceiling và alpha inverse vẫn có đối tượng dữ liệu thực tế, nhưng không có cài đặt vô hướng để in ra. Sự hiện diện và vị trí của chúng trong bộ sưu tập là thông tin quan trọng.

## **Xóa hoặc xóa sạch các biến đổi ảnh**

Sử dụng [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) để xóa một thao tác theo chỉ mục. Vì các chỉ mục dịch chuyển sau khi xóa, hãy tìm mục tiêu trước và xóa nó sau khi đã liệt kê. Dùng `Clear()` để xóa toàn bộ chuỗi.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    var blurIndex = -1;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        if (imageTransform[index] is IBlur)
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform.RemoveAt(blurIndex);
        Console.WriteLine("The blur operation was removed.");
    }

    imageTransform.Clear();
    Console.WriteLine("Remaining operations: " + imageTransform.Count);
    presentation.Save("image-transforms-cleared.pptx", SaveFormat.Pptx);
}
```

Xóa hoặc xóa sạch các biến đổi chỉ thay đổi định dạng hình ảnh. Nó không xóa, nén lại hoặc thay đổi tài nguyên [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) đã được tái sử dụng.

## **Xem xét định dạng bản trình bày và mục tiêu xuất**

Các biến đổi ảnh bắt nguồn từ DrawingML, vì vậy PPTX là định dạng chỉnh sửa ưu tiên cho chuỗi hiệu ứng. Ngay cả với PPTX, không phải mọi thao tác đều có tính di động giống nhau:

- Các thao tác DrawingML chuẩn như luminance, grayscale, duotone, tint, HSL, blur và các thao tác alpha phổ biến có khả năng tồn tại tốt nhất sau một vòng quay PPTX. Luôn mở lại tệp đã tạo và kiểm tra bộ sưu tập khi việc bảo tồn là yêu cầu.
- [BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) là một phần mở rộng Office 2010 chứ không phải thao tác luminance chuẩn của DrawingML. Nó có thể dùng cho việc kết xuất trong bộ nhớ, nhưng không được đảm bảo sẽ còn lại dưới dạng [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) có thể chỉnh sửa sau khi lưu và mở lại PPTX. Ưu tiên [AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) cho các điều chỉnh độ sáng và độ tương phản bền vững.
- Định dạng PPT nhị phân có thời gian trước mô hình hiệu ứng DrawingML đầy đủ. Lưu sang PPT có thể bỏ qua các thao tác không được hỗ trợ, giảm chuỗi thành một tập hợp con được hỗ trợ, hoặc xấp xỉ hiển thị. Không sử dụng PPT làm định dạng xác minh cho một chuỗi chỉnh sửa phức tạp.
- Kết xuất sang PNG, JPEG, TIFF, PDF, SVG, HTML hoặc các đầu ra hình ảnh khác áp dụng chuỗi đã hỗ trợ lên hình ảnh kết xuất. Các đầu ra này không chứa một `IImageTransformOperationCollection` có thể chỉnh sửa; định dạng raster làm phẳng kết quả thành pixel, và các xuất khẩu tài liệu/vector lưu trữ đại diện kết xuất riêng của chúng.
- Các hiệu ứng không làm cho một hình ảnh được liên kết trở nên tự chứa. Kết xuất một hình ảnh liên kết vẫn phụ thuộc vào tài nguyên liên kết còn sẵn sàng khi bản trình bày được tải.

Các trình duyệt bản trình bày khác nhau có thể kết xuất các trường hợp biên giới khác nhau, đặc biệt khi nhiều thao tác alpha hoặc lượng giác màu được kết hợp. Đối với đầu ra quan trọng, hãy kiểm tra cả vòng quay chỉnh sửa và định dạng xuất cuối cùng bằng cùng một phiên bản Aspose.Slides được sử dụng trong sản xuất.

## **Câu hỏi thường gặp**

**Các hiệu ứng biến đổi ảnh có thay đổi dữ liệu ảnh nhúng không?**

Không. Các thao tác thuộc về `ISlidesPicture` được sử dụng bởi phần nền ảnh. Các byte `IPPImage` nền tảng vẫn không thay đổi.

**Hai khung ảnh tái sử dụng cùng một ảnh sẽ chia sẻ hiệu ứng không?**

Không. Tái sử dụng một `IPPImage` giúp tránh trùng lặp dữ liệu ảnh, nhưng mỗi khung ảnh thường có một `ISlidesPicture` và bộ sưu tập biến đổi riêng.

**Có thể kết hợp các hiệu ứng màu, làm mờ và alpha không?**

Có. Bộ sưu tập chấp nhận chúng trong một chuỗi có thứ tự. Hãy cân nhắc mỗi thao tác sẽ ảnh hưởng như thế nào tới đầu ra của thao tác trước vì các thao tác thay thế và ngưỡng có thể loại bỏ chi tiết màu hoặc alpha đã có.

**Tại sao các giá trị thực tế chỉ đọc?**

Dữ liệu thực tế đại diện cho các giá trị đã tính toán dùng để kết xuất, bao gồm các màu đã được giải quyết. Hãy chỉnh sửa thao tác được lưu trong bộ sưu tập biến đổi ở nơi có thành viên có thể ghi; nếu không, hãy xóa nó và thêm một thao tác thay thế với các tham số tạo mới.

**Định dạng nào nên dùng để bảo toàn một chuỗi biến đổi?**

Sử dụng PPTX và xác minh tệp bằng cách mở lại. PPT cổ điển không thể biểu diễn toàn bộ mô hình hiệu ứng DrawingML, và các định dạng xuất kết quả chỉ giữ lại hình ảnh chứ không giữ lại các thao tác biến đổi có thể chỉnh sửa.