---
title: Quản lý Các Hiệu Ứng Biến Đổi Ảnh trong Bản Trình Bày với .NET
linktitle: Hiệu Ứng Biến Đổi Ảnh
type: docs
weight: 11
url: /vi/net/image-transform-effects/
keywords:
- image transform
- picture effect
- brightness
- contrast
- grayscale
- duotone
- tint
- HSL
- color replacement
- blur
- transparency
- alpha effect
- effect chain
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Áp dụng, nối chuỗi, kiểm tra, xóa và xác thực các hiệu ứng biến đổi ảnh cho khung hình ảnh với Aspose.Slides cho .NET."
---
## **Tổng quan**

Aspose.Slides biểu diễn các điều chỉnh hình ảnh dưới dạng một tập hợp có thứ tự của các phép biến đổi ảnh. Đối với một khung ảnh, bắt đầu với [ISlidesPicture](https://reference.aspose.com/slides/vi/net/aspose.slides/islidespicture/) của khung và truy cập [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/vi/net/aspose.slides/islidespicture/imagetransform/). [IImageTransformOperationCollection](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/) trả về cho phép bạn thêm, liệt kê, kiểm tra, xóa và xóa toàn bộ các hiệu ứng mà không cần ghi lại lại các byte ảnh gốc.

Bài viết này trình bày một quy trình làm việc đầy đủ cho độ sáng và độ tương phản, các biến đổi màu, làm mờ, độ trong suốt, chuỗi hiệu ứng có thứ tự, giá trị hiệu quả, việc xóa, và xác thực vòng tròn PPTX.

## **Hiểu về Quyền sở hữu Hiệu ứng và Tái sử dụng Ảnh**

Một tài nguyên ảnh và hình ảnh hiển thị nó là hai đối tượng khác nhau:

- [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) lưu trữ hoặc tham chiếu dữ liệu ảnh nguồn thuộc bản trình bày.
- [ISlidesPicture](https://reference.aspose.com/slides/vi/net/aspose.slides/islidespicture/) thuộc về phần điền ảnh và tham chiếu tới tài nguyên ảnh trong khi lưu trữ tập hợp biến đổi ảnh.
- [IPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe/) là hình dạng trên slide sở hữu phần điền ảnh liên quan, hình học, cài đặt cắt và các định dạng ở mức khung khác.

Do đó, các phép biến đổi ảnh không thay đổi các byte trong [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/). Khi cùng một `IPPImage` được truyền cho [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addpictureframe/) nhiều lần, mỗi khung ảnh mới nhận được `ISlidesPicture` và tập hợp biến đổi riêng của nó. Áp dụng hiệu ứng grayscale cho một khung không làm cho các khung khác cũng trở nên grayscale, mặc dù tất cả chúng đều tái sử dụng cùng một tài nguyên ảnh được nhúng.

Mô hình `ISlidesPicture.ImageTransform` cũng được sử dụng bởi các phần điền ảnh khác, chẳng hạn như hình dạng hoặc nền slide. Các ví dụ dưới đây tập trung vào khung ảnh.

## **Sử dụng Phạm vi Tham số và Đơn vị Hợp lệ**

Các phương pháp được minh họa sử dụng các phạm vi ngữ nghĩa và đơn vị sau. Giữ các giá trị trong các phạm vi này ngay cả khi một phiên bản thư viện cụ thể không từ chối ngay mọi giá trị ngoài phạm vi; định dạng bản trình bày đích có thể chuẩn hoá, bỏ qua hoặc từ chối dữ liệu không hợp lệ khi lưu hoặc khi PowerPoint mở tệp.

| Thao tác | Tham số | Phạm vi và đơn vị hợp lệ |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` tới `100`, phần trăm; `0` giữ nguyên thành phần. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Không có | Không có tham số số. Alpha không thay đổi. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Hai màu cho pixel tối và sáng. Kênh RGB và alpha trong `System.Drawing.Color` dùng giá trị từ `0` tới `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue từ `0` (bao gồm) tới `360` (không bao gồm), đơn vị độ; amount từ `-100` tới `100`, phần trăm. |
| [AddHSLEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue từ `0` (bao gồm) tới `360` (không bao gồm), độ; saturation và luminance từ `-100` tới `100`, phần trăm. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Màu thay thế sử dụng giá trị kênh từ `0` tới `255`. Giá trị alpha hiện có không thay đổi. |
| [AddBlurEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Bán kính không âm và đo bằng điểm; `grow` là Boolean điều khiển việc nội dung làm mờ có thể mở rộng ra ngoài giới hạn ban đầu hay không. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Phần trăm không âm. Dùng `0` tới `100` cho việc điều chỉnh độ trong suốt thông thường: `0` hoàn toàn trong suốt và `100` giữ nguyên alpha hiện có. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` tới `100`, phần trăm độ trong suốt. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` tới `100`, phần trăm ngưỡng alpha. Giá trị dưới ngưỡng trở nên trong suốt; giá trị bằng hoặc trên ngưỡng trở nên không trong suốt. |

Đối với việc điều chế alpha cố định, độ trong suốt và độ mờ là các khái niệm bổ trợ. Ví dụ, độ trong suốt 35% tương đương với mức điều chế alpha 65%.

## **Áp dụng Độ sáng và Độ tương phản**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) trả về một phép toán [IBrightnessContrast](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/ibrightnesscontrast/). Các thiết lập vô hướng của nó được cung cấp khi tạo phép toán. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/brightnesscontrast/geteffective/) trả về các giá trị chỉ đọc đã tính toán mà có thể được kiểm tra hoặc ghi lại.

Ví dụ sau tăng độ sáng lên 15% và độ tương phản lên 20%, sau đó tạo bản xem trước mà không thay đổi ảnh được nhúng:

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

[BrightnessContrast](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/brightnesscontrast/) là một phần mở rộng hiệu ứng ảnh Office 2010 và ít di động hơn so với hiệu ứng luminance chuẩn DrawingML. Khi độ sáng và độ tương phản phải vẫn có thể chỉnh sửa sau một vòng tròn PPTX, hãy sử dụng [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) và xác thực kết quả sau khi mở lại tệp. Phần giới hạn định dạng giải thích chi tiết hơn về sự khác biệt này.

## **Áp dụng Các Biến đổi Màu**

Các hiệu ứng màu có thể được áp dụng độc lập cho các khung ảnh khác nhau mà tái sử dụng cùng một tài nguyên ảnh. Ví dụ dưới đây tạo năm khung và áp dụng grayscale, duotone, tint, điều chỉnh HSL, và thay thế màu.

[IDuotone](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iduotone/) chứa hai tham số màu có thể chỉnh sửa độc lập: `Color1` ánh xạ các pixel tối, trong khi `Color2` ánh xạ các pixel sáng. Điều này khiến nó là một ví dụ hữu ích về hiệu ứng có cài đặt phức tạp hơn một giá trị vô hướng duy nhất.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) thay thế màu của mọi pixel bằng một màu cố định trong khi giữ nguyên alpha. Nó khác với [AddColorChangeEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), cái mà ánh xạ một màu nguồn sang màu đích và cho phép cả hai định dạng màu nguồn và đích.

## **Thêm Hiệu ứng Làm Mờ, Độ trong suốt và Alpha**

[AddBlurEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) ảnh hưởng tới tất cả các kênh màu, bao gồm alpha. Đặt `grow` thành `true` khi cạnh làm mờ có thể mở rộng ra ngoài giới hạn ảnh gốc.

Đối với độ trong suốt đồng nhất, sử dụng [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Nó nhân mỗi giá trị alpha hiện có, vì vậy các pixel bán trong suốt vẫn duy trì sự khác nhau tỷ lệ. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) thay vào đó gán một giá trị alpha cho tất cả các pixel. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) chuyển đổi alpha thành hai mức dựa trên một ngưỡng.

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

Các thao tác alpha không có tham số khác bao gồm [AddAlphaCeilingEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), làm cho mọi alpha khác 0 trở nên hoàn toàn không trong suốt; [AddAlphaFloorEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), làm cho mọi alpha dưới 100% trở nên hoàn toàn trong suốt; và [AddAlphaInverseEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), chuyển đổi alpha thành `100% - alpha`.

## **Xây dựng Chuỗi Hiệu ứng Có Thứ Tự**

Mỗi phương thức `Add...Effect` thêm một phép toán mới vào cuối tập hợp. Trình render sử dụng tập hợp như một pipeline có thứ tự: đầu ra của phép toán 0 trở thành đầu vào của phép toán 1, và tiếp tục như vậy. Do đó, cùng một tập hợp thao tác nhưng sắp xếp khác nhau có thể tạo ra ảnh khác nhau.

Ví dụ, grayscale rồi tint sẽ đầu tiên loại bỏ thông tin màu và sau đó nhuộm lại kết quả luminance. Tint rồi grayscale lại loại bỏ tint một lần nữa. Tương tự, việc thay thế alpha có thể ghi đè các giá trị alpha được tính bởi các phép toán trước, trong khi điều chế alpha giữ lại sự khác biệt tương đối của chúng.

Ví dụ dưới đây xây dựng một chuỗi bốn phép toán, lưu dưới dạng PPTX, mở lại bản trình bày, kiểm tra cả loại phép toán và thứ tự của chúng, và tạo bản xem lại kết quả đã mở lại:

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

Tập hợp không áp đặt một ma trận tương thích giới hạn các phép toán màu, alpha và blur vào các chuỗi riêng biệt. Chúng có thể được kết hợp, nhưng không phải lúc nào cũng hữu ích. Việc thay thế màu cố định loại bỏ biến thể RGB do các hiệu ứng màu trước đó tạo ra; grayscale sau duotone loại bỏ hai màu đã chọn; và các phép toán alpha ceiling, floor, replace hoặc bi‑level có thể bỏ qua chi tiết alpha được tạo ra trước đó. Hãy xây dựng chuỗi dựa trên trình tự xử lý pixel mong muốn thay vì xem các mục như các cờ định dạng không có thứ tự.

## **Kiểm tra Giá trị Có Thể Chỉnh sửa và Giá trị Hiệu quả**

Một phép toán có thể chỉnh sửa là đối tượng được lưu trong `ISlidesPicture.ImageTransform`. Tùy thuộc vào hiệu ứng, nó có thể cung cấp các thành viên có thể ghi trực tiếp. Ví dụ, [IBlur](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iblur/) cung cấp `Radius` và `Grow` có thể ghi, [IAlphaModulateFixed](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/ialphamodulatefixed/) cung cấp `Amount` có thể ghi, và [IAlphaBiLevel](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/ialphabilevel/) cung cấp `Threshold` có thể ghi. Các hiệu ứng màu như [IDuotone](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iduotone/) cung cấp các đối tượng [IColorFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/icolorformat/) có thể thay đổi.

Một số giao diện phép toán, bao gồm [IBrightnessContrast](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/itint/), và [IAlphaReplace](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/ialphareplace/), không cung cấp các tham số tạo dưới dạng thuộc tính có thể ghi. Để thay đổi các cài đặt này, hãy xóa phép toán và thêm một phép toán thay thế tại vị trí yêu cầu.

Dữ liệu hiệu quả được trả về bởi `GetEffective()` là dữ liệu đã tính toán và chỉ đọc. Nó hữu ích để giải quyết các màu phụ thuộc vào theme và đọc các giá trị chuẩn hoá mà trình render sử dụng, nhưng không phải là một bề mặt chỉnh sửa khác. Ví dụ dưới đây liệt kê chuỗi và kiểm tra các giá trị hiệu quả ở những API cung cấp chúng:

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

Các hiệu ứng không có tham số như grayscale, alpha ceiling và alpha inverse vẫn có một đối tượng dữ liệu hiệu quả, nhưng không có cài đặt vô hướng nào để in ra. Sự hiện diện và vị trí của chúng trong tập hợp là thông tin quan trọng.

## **Xóa hoặc Xóa toàn bộ Biến đổi Ảnh**

Sử dụng [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) để xóa một phép toán theo chỉ mục. Vì các chỉ mục sẽ dịch chuyển sau khi xóa, hãy tìm mục tiêu trước và xóa nó sau khi liệt kê. Sử dụng `Clear()` để xóa toàn bộ chuỗi.

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

Xóa hoặc xóa toàn bộ các biến đổi chỉ thay đổi định dạng của hình ảnh. Nó không xóa, nén lại hoặc thay đổi bất kỳ tài nguyên [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) được tái sử dụng nào.

## **Xem xét Định dạng Bản trình bày và Đích xuất**

Biến đổi ảnh xuất phát từ DrawingML, vì vậy PPTX là định dạng chỉnh sửa ưa thích cho các chuỗi hiệu ứng. Ngay cả với PPTX, không phải mọi phép toán đều có tính di động giống nhau:

- Các phép toán DrawingML tiêu chuẩn như luminance, grayscale, duotone, tint, HSL, blur và các phép toán alpha phổ biến có khả năng cao nhất để tồn tại qua vòng tròn PPTX. Luôn mở lại tệp đã tạo và kiểm tra tập hợp khi việc bảo tồn là yêu cầu.
- [BrightnessContrast](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/brightnesscontrast/) là một phần mở rộng Office 2010 chứ không phải phép toán luminance DrawingML tiêu chuẩn. Nó có thể dùng cho việc render trong bộ nhớ, nhưng không được đảm bảo vẫn còn là một [IBrightnessContrast](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/ibrightnesscontrast/) có thể chỉnh sửa sau khi lưu và mở lại PPTX. Ưu tiên [AddLuminanceEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) cho các điều chỉnh độ sáng và độ tương phản bền vững.
- Định dạng PPT nhị phân ra đời trước mô hình hiệu ứng DrawingML đầy đủ. Lưu sang PPT có thể bỏ qua các phép toán không được hỗ trợ, rút gọn chuỗi thành một tập con được hỗ trợ, hoặc xấp xỉ giao diện. Không nên dùng PPT làm định dạng xác thực cho một chuỗi chỉnh sửa phức tạp.
- Render ra PNG, JPEG, TIFF, PDF, SVG, HTML hoặc các đầu ra hình ảnh khác áp dụng chuỗi được hỗ trợ lên giao diện render. Các đầu ra này không chứa một `IImageTransformOperationCollection` có thể chỉnh sửa; các định dạng raster phẳng kết quả thành pixel, và các xuất khẩu tài liệu/đồ họa lưu trữ riêng đại diện render của chúng.
- Các hiệu ứng không làm cho một ảnh được liên kết tự chứa. Render một hình ảnh liên kết vẫn phụ thuộc vào việc tài nguyên liên kết có sẵn khi bản trình bày được tải.

Các trình tiêu thụ bản trình bày khác nhau có thể render các trường hợp biên khác nhau, đặc biệt khi nhiều phép toán alpha hoặc phân cấp màu được kết hợp. Đối với đầu ra quan trọng, hãy kiểm tra cả vòng tròn chỉnh sửa và định dạng xuất cuối cùng bằng cùng một phiên bản Aspose.Slides được sử dụng trong sản xuất.

## **Câu hỏi thường gặp**

**Các hiệu ứng biến đổi ảnh có sửa đổi dữ liệu ảnh được nhúng không?**

Không. Các phép toán thuộc về `ISlidesPicture` được sử dụng bởi phần điền ảnh. Các byte `IPPImage` nền tảng vẫn không thay đổi.

**Hai khung ảnh tái sử dụng cùng một ảnh sẽ chia sẻ các hiệu ứng không?**

Không. Tái sử dụng một `IPPImage` giúp tránh dữ liệu ảnh trùng lặp, nhưng mỗi khung ảnh thường có một `ISlidesPicture` và tập hợp biến đổi ảnh riêng.

**Có thể kết hợp các hiệu ứng màu, làm mờ và alpha không?**

Có. Tập hợp cho phép chúng trong một chuỗi có thứ tự. Hãy cân nhắc mỗi phép toán ảnh hưởng tới đầu ra của phép toán trước vì các phép toán thay thế và ngưỡng có thể loại bỏ chi tiết màu hoặc alpha đã tạo trước đó.

**Tại sao các giá trị hiệu quả lại chỉ đọc?**

Dữ liệu hiệu quả đại diện cho các giá trị đã tính toán dùng để render, bao gồm cả các màu đã được giải quyết. Chỉnh sửa phép toán được lưu trong tập hợp biến đổi nơi có thành viên có thể ghi; nếu không, hãy xóa và thêm một phép toán thay thế với các tham số tạo mới.

**Định dạng nào nên dùng để bảo tồn một chuỗi biến đổi?**

Sử dụng PPTX và xác thực tệp bằng cách mở lại. PPT cổ điển không thể biểu diễn toàn bộ mô hình hiệu ứng DrawingML, và các định dạng xuất cuối cùng chỉ giữ lại giao diện thay vì các phép toán biến đổi có thể chỉnh sửa.