---
title: Quản lý các hiệu ứng biến đổi ảnh trong bản trình bày bằng C++
linktitle: Hiệu ứng biến đổi ảnh
type: docs
weight: 11
url: /vi/cpp/image-transform-effects/
keywords:
- biến đổi ảnh
- hiệu ứng hình ảnh
- độ sáng
- độ tương phản
- xám
- đôi màu
- tô màu
- HSL
- thay thế màu
- làm mờ
- độ trong suốt
- hiệu ứng alpha
- chuỗi hiệu ứng
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Áp dụng, tạo chuỗi, kiểm tra, xóa và xác minh các hiệu ứng biến đổi ảnh cho khung hình với Aspose.Slides cho C++."
---
## **Tổng quan**

Aspose.Slides biểu diễn các điều chỉnh hình ảnh dưới dạng một bộ sưu tập có thứ tự của các hoạt động biến đổi ảnh. Đối với một khung hình, bắt đầu với khung của [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) và truy cập [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/get_imagetransform/). Bộ [IImageTransformOperationCollection](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/) trả về cho phép bạn thêm, liệt kê, kiểm tra, xóa và xóa sạch các hiệu ứng mà không phải ghi lại lại các byte ảnh gốc.

Bài viết này trình bày quy trình hoàn chỉnh cho độ sáng và độ tương phản, các biến đổi màu, làm mờ, trong suốt, chuỗi hiệu ứng có thứ tự, giá trị hiệu quả, việc xóa và xác minh vòng quay PPTX.

## **Hiểu Quyền Sở Hữu Hiệu Ứng và Việc Tái Sử Dụng Hình Ảnh**

Một tài nguyên ảnh và hình ảnh hiển thị nó là các đối tượng khác nhau:

- [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) lưu trữ hoặc tham chiếu dữ liệu ảnh nguồn thuộc sở hữu của bản trình bày.
- [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) thuộc về một lớp nền ảnh và tham chiếu tới tài nguyên ảnh trong khi lưu trữ bộ sưu tập biến đổi ảnh.
- [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) là hình dạng trên slide sở hữu lớp nền ảnh liên quan, hình học, cài đặt cắt và các định dạng cấp khung khác.

Do đó, các hoạt động biến đổi ảnh không sửa đổi các byte trong [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/). Khi cùng một `IPPImage` được truyền cho [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) hơn một lần, mỗi khung hình mới nhận được `ISlidesPicture` và bộ sưu tập biến đổi riêng. Áp dụng chuyển đổi xám cho một khung không làm các khung khác chuyển sang xám, mặc dù tất cả chúng đều sử dụng cùng một tài nguyên ảnh được nhúng.

Mô hình `ISlidesPicture::get_ImageTransform` cũng được sử dụng cho các lớp nền ảnh khác, chẳng hạn như hình dạng hoặc nền slide. Các ví dụ dưới đây tập trung vào khung hình.

## **Sử Dụng Phạm Vi và Đơn Vị Tham Số Hợp Lệ**

Các phương pháp được trình bày sử dụng các phạm vi và đơn vị ngữ nghĩa sau. Giữ các giá trị trong các phạm vi này ngay cả khi một phiên bản thư viện cụ thể không từ chối mọi giá trị ngoài phạm vi ngay lập tức; định dạng bản trình bày mục tiêu có thể chuẩn hoá, loại bỏ hoặc từ chối dữ liệu không hợp lệ khi lưu hoặc khi PowerPoint mở tệp.

| Hoạt động | Tham số | Phạm vi và đơn vị hợp lệ |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` đến `100`, phần trăm; `0` giữ nguyên thành phần. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Không có | Không có tham số số. Alpha không thay đổi. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Hai màu cho các pixel tối và sáng. Các kênh RGB và alpha trong `System::Drawing::Color` dùng `0` đến `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue là `0` bao gồm đến `360` không bao gồm, tính bằng độ; amount là `-100` đến `100`, phần trăm. |
| [AddHSLEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue là `0` bao gồm đến `360` không bao gồm, tính bằng độ; saturation và luminance là `-100` đến `100`, phần trăm. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Màu thay thế sử dụng giá trị kênh từ `0` đến `255`. Giá trị alpha hiện có không thay đổi. |
| [AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Bán kính không âm và đo bằng điểm; `grow` điều khiển việc nội dung mờ có thể mở rộng ra ngoài giới hạn gốc. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Phần trăm không âm. Dùng `0` đến `100` cho việc điều chỉnh độ mờ thông thường: `0` là hoàn toàn trong suốt và `100` giữ nguyên alpha hiện có. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` đến `100`, phần trăm độ mờ. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` đến `100`, phần trăm ngưỡng alpha. Các giá trị dưới ngưỡng trở thành trong suốt; các giá trị bằng hoặc trên ngưỡng trở thành không trong suốt. |

Đối với điều chế alpha cố định, độ trong suốt và độ mờ là bổ trợ nhau. Ví dụ, độ trong suốt 35% tương ứng với một mức điều chế alpha là 65%.

## **Áp Dụng Độ Sáng và Độ Tương Phản**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) trả về một hoạt động [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/). Các cài đặt vô hướng của nó được cung cấp khi tạo hoạt động. Phương thức `IBrightnessContrast::GetEffective` trả về các giá trị chỉ-đọc được tính toán có thể kiểm tra hoặc ghi log.

Ví dụ sau tăng độ sáng lên 15% và độ tương phản lên 20%, sau đó hiển thị bản preview mà không sửa đổi ảnh nhúng:

```cpp
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto brightnessContrast = imageTransform->AddBrightnessContrastEffect(15.0f, 20.0f);

auto effectiveValues = brightnessContrast->GetEffective();
Console::WriteLine(u"Brightness: {0}%", effectiveValues->get_Brightness());
Console::WriteLine(u"Contrast: {0}%", effectiveValues->get_Contrast());

auto preview = slide->GetImage();
preview->Save(u"brightness-contrast-preview.png", ImageFormat::Png);

presentation->Dispose();
```

[BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) là một phần mở rộng hiệu ứng ảnh Office 2010 và ít di động hơn hiệu ứng luminance chuẩn DrawingML. Khi độ sáng và độ tương phản phải vẫn có thể chỉnh sửa sau một vòng quay PPTX, hãy sử dụng [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) và xác minh kết quả sau khi mở lại tệp. Phần giới hạn định dạng giải thích chi tiết sự khác biệt này.

## **Áp Dụng Các Biến Đổi Màu**

Các hiệu ứng màu có thể được áp dụng độc lập cho các khung hình khác nhau sử dụng cùng một tài nguyên ảnh. Ví dụ dưới tạo năm khung và áp dụng xám, duotone, tint, điều chỉnh HSL và thay thế màu.

[IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) chứa hai tham số màu có thể chỉnh sửa độc lập: `get_Color1` ánh xạ các pixel tối, trong khi `get_Color2` ánh xạ các pixel sáng. Điều này làm cho nó trở thành một ví dụ hữu ích về một hiệu ứng có cài đặt phức tạp hơn một giá trị vô hướng duy nhất.

```cpp
#include <DOM/Effects/IColorReplace.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto grayFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 120.0f, image);
grayFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddGrayScaleEffect();

auto duotoneFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 180.0f, 120.0f, image);
auto duotone = duotoneFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddDuotoneEffect();
duotone->get_Color1()->set_Color(Color::get_Navy());
duotone->get_Color2()->set_Color(Color::get_Gold());

auto tintFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 420.0f, 20.0f, 180.0f, 120.0f, image);
tintFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddTintEffect(210.0f, 35.0f);

auto hslFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 120.0f, 170.0f, 180.0f, 120.0f, image);
hslFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddHSLEffect(30.0f, 20.0f, -10.0f);

auto replacementFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 320.0f, 170.0f, 180.0f, 120.0f, image);
auto colorReplacement = replacementFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddColorReplaceEffect();
colorReplacement->get_Color()->set_Color(Color::get_CornflowerBlue());

presentation->Save(u"color-transformations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) thay thế màu của mỗi pixel bằng một màu cố định trong khi giữ nguyên alpha. Nó khác với [AddColorChangeEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), cái mà ánh xạ một màu nguồn sang màu đích và cho phép cả định dạng màu nguồn và đích.

### **Áp Dụng Ngưỡng Độ Sáng**

Ngưỡng độ sáng có thể làm cho các dấu vết mờ trên trang scan dễ phân biệt hơn so với nền. [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) giữ lại các sắc độ xám trung gian. [AddBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) ánh xạ độ sáng thành đen hoặc trắng, trong khi [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) áp dụng một ngưỡng cho độ trong suốt.

Ngưỡng độ sáng dao động từ 0% tới 100%, bao gồm. Các pixel dưới ngưỡng sẽ trở thành đen. Các pixel bằng hoặc trên ngưỡng sẽ trở thành trắng. Tăng ngưỡng sẽ làm nhiều sắc độ hơn chuyển sang đen vì chúng rơi xuống dưới mức cắt.

Tải xuống [grayscale-swatches.png](grayscale-swatches.png) vào thư mục làm việc. Mỗi nhãn cho biết mức độ xám gốc trên thang từ 0 tới 255. Ví dụ đặt bản gốc bên cạnh hai bản sao và lưu ngưỡng của mỗi bản sao trong bản trình bày.

```cpp
#include <DOM/Effects/IBiLevel.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 150, SlideSizeScaleType::DoNotScale);
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto imageData = File::ReadAllBytes(u"grayscale-swatches.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto addFrame = [&](float x, const String& caption)
{
    auto label = shapes->AddAutoShape(ShapeType::Rectangle, x, 12, 216, 36);
    label->get_TextFrame()->set_Text(caption);
    return shapes->AddPictureFrame(ShapeType::Rectangle, x, 60, 216, 72, image);
};

addFrame(12, u"Original");

auto lowThreshold = addFrame(252, u"Threshold 20%");
lowThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(20.0f);

auto highThreshold = addFrame(492, u"Threshold 60%");
highThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(60.0f);

presentation->Save(u"luminance-threshold.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Mở bản trình bày đầu ra trong PowerPoint để so sánh ba khung. Mẫu được gắn nhãn 96 có khoảng 38% độ sáng (96 trên 255). Nó chuyển sang trắng ở ngưỡng 20% và sang đen ở ngưỡng 60%.

![Các mẫu ảnh xám gốc bên cạnh kết quả đen-trắng tại ngưỡng độ sáng 20% và 60%](luminance-threshold.png)

## **Thêm Hiệu Ứng Làm Mờ, Trong Suốt và Alpha**

[AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) ảnh hưởng tới tất cả các kênh màu, bao gồm alpha. Đặt `grow` thành `true` khi cạnh mờ có thể mở rộng ra ngoài giới hạn hình ảnh gốc.

Đối với trong suốt đồng đều, sử dụng [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Nó nhân mỗi giá trị alpha hiện có, vì vậy các pixel bán trong suốt vẫn giữ tỷ lệ khác nhau. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) thay vào đó gán một giá trị alpha cho mọi pixel. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) chuyển đổi alpha thành hai mức dựa trên một ngưỡng.

```cpp
#include <DOM/Effects/IAlphaBiLevel.h>
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto blurredFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 140.0f, image);
auto blur = blurredFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBlurEffect(4.5, true);
blur->set_Radius(5.0);

auto transparentFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 20.0f, 200.0f, 140.0f, image);
auto alphaModulate = transparentFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(65.0f);
alphaModulate->set_Amount(60.0f);

auto uniformAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 180.0f, 200.0f, 140.0f, image);
uniformAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaReplaceEffect(55.0f);

auto binaryAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 180.0f, 200.0f, 140.0f, image);
auto binaryAlphaTransform = binaryAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto alphaBiLevel = binaryAlphaTransform->AddAlphaBiLevelEffect(50.0f);
alphaBiLevel->set_Threshold(45.0f);
binaryAlphaTransform->AddAlphaInverseEffect();

presentation->Save(u"blur-and-alpha-effects.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Các thao tác alpha không có tham số khác bao gồm [AddAlphaCeilingEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), khiến mọi alpha khác không bằng 0 trở nên hoàn toàn không trong suốt; [AddAlphaFloorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), khiến mọi alpha dưới 100% trở nên hoàn toàn trong suốt; và [AddAlphaInverseEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), chuyển đổi alpha thành `100% - alpha`.

## **Xây Dựng Chuỗi Hiệu Ứng Có Thứ Tự**

Mỗi phương thức `Add...Effect` thêm một hoạt động mới vào cuối bộ sưu tập. Bộ vẽ sử dụng bộ sưu tập như một pipeline có thứ tự: đầu ra của hoạt động 0 trở thành đầu vào của hoạt động 1, và cứ tiếp tục. Do đó, cùng các hoạt động theo một thứ tự khác có thể tạo ra hình ảnh khác.

Ví dụ, xám rồi tint đầu tiên loại bỏ thông tin màu sắc và sau đó tô lại độ sáng kết quả. Tint rồi xám lại loại bỏ tint. Tương tự, thay thế alpha có thể ghi đè giá trị alpha tính bởi các hoạt động trước, trong khi điều chế alpha giữ lại sự chênh lệch tương đối của chúng.

Ví dụ dưới xây dựng một chuỗi bốn hoạt động, lưu dưới dạng PPTX, mở lại bản trình bày, kiểm tra cả loại hoạt động và thứ tự của chúng, và vẽ lại kết quả đã mở lại:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IGrayScale.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ITint.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
imageTransform->AddGrayScaleEffect();
imageTransform->AddTintEffect(220.0f, 25.0f);
imageTransform->AddBlurEffect(2.5, false);
imageTransform->AddAlphaModulateFixedEffect(80.0f);

presentation->Save(u"image-transform-chain.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto reopenedShape = reopenedPresentation->get_Slide(0)->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(reopenedShape))
{
    auto reopenedFrame = ExplicitCast<IPictureFrame>(reopenedShape);
    auto reopenedTransform = reopenedFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto orderIsPreserved = reopenedTransform->get_Count() == 4 && 
            ObjectExt::Is<IGrayScale>(reopenedTransform->idx_get(0)) && 
            ObjectExt::Is<ITint>(reopenedTransform->idx_get(1)) && 
            ObjectExt::Is<IBlur>(reopenedTransform->idx_get(2)) && 
            ObjectExt::Is<IAlphaModulateFixed>(reopenedTransform->idx_get(3));
    Console::WriteLine(orderIsPreserved ? u"The effect chain was preserved." : u"The effect chain changed during the round trip.");

    auto renderedSlide = reopenedPresentation->get_Slide(0)->GetImage();
    renderedSlide->Save(u"reopened-effect-chain.png", ImageFormat::Png);
}
else
{
    Console::WriteLine(u"The reopened shape is not a picture frame.");
}

reopenedPresentation->Dispose();
```

Bộ sưu tập không áp đặt một ma trận tương thích giới hạn các thao tác màu, alpha và làm mờ vào các chuỗi riêng biệt. Chúng có thể được kết hợp, nhưng không phải lúc nào cũng hữu ích. Thay thế màu cố định loại bỏ biến thể RGB do các hiệu ứng màu trước tạo ra; xám sau duotone loại bỏ hai màu đã chọn; và các thao tác alpha ceiling, floor, replacement hoặc bi-level có thể xóa chi tiết alpha được tạo ra trước. Xây dựng chuỗi dựa trên trình tự xử lý pixel mong muốn thay vì xem các mục như các cờ định dạng không thứ tự.


<!-- visual-explanation:image-transform-effects:start -->
[![Cùng một hình ảnh đi qua hiệu ứng xám rồi màu, và màu rồi xám. Hai hình ảnh xám cuối cùng có tông màu khác nhau.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Trong bản render Aspose.Slides for .NET 26.11 này, một tint 220° ở mức 25% để nguyên hình ảnh xám. Áp dụng cùng một tint trước khi xám tạo ra các tông màu khác nhau.*
<!-- visual-explanation:image-transform-effects:end -->

## **Kiểm Tra Giá Trị Có Thể Chỉnh Sửa và Hiệu Quả**

Một hoạt động có thể chỉnh sửa là đối tượng được lưu trong `ISlidesPicture::get_ImageTransform`. Tùy thuộc vào hiệu ứng, nó có thể phô bày các thành viên có thể ghi trực tiếp. Ví dụ, [IBlur](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/) phô bày `set_Radius` và `set_Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphamodulatefixed/) phô bày `set_Amount`, và [IAlphaBiLevel](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphabilevel/) phô bày `set_Threshold`. Các hiệu ứng màu như [IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) phô bày các đối tượng [IColorFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/) có thể thay đổi.

Một số giao diện hoạt động, bao gồm [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/cpp/aspose.slides.effects/itint/), và [IAlphaReplace](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphareplace/), không phô bày các vô hướng tạo ra dưới dạng thuộc tính có thể ghi. Để thay đổi các cài đặt đó, hãy xóa hoạt động và thêm một thay thế tại vị trí cần thiết.

Dữ liệu hiệu quả trả về bởi `GetEffective()` được tính toán và chỉ-đọc. Nó hữu ích để giải quyết các màu phụ thuộc chủ đề và đọc các giá trị chuẩn hoá mà bộ vẽ sử dụng, nhưng không phải là một bề mặt chỉnh sửa khác. Ví dụ dưới liệt kê chuỗi và kiểm tra các giá trị hiệu quả cho một số hoạt động phổ biến:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IAlphaModulateFixedEffectiveData.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IBlurEffectiveData.h>
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IDuotoneEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& operation : imageTransform)
    {
        if (ObjectExt::Is<IBrightnessContrast>(operation))
        {
            auto brightnessContrast = ExplicitCast<IBrightnessContrast>(operation);
            auto data = brightnessContrast->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<ILuminance>(operation))
        {
            auto luminance = ExplicitCast<ILuminance>(operation);
            auto data = luminance->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<IDuotone>(operation))
        {
            auto duotone = ExplicitCast<IDuotone>(operation);
            auto data = duotone->GetEffective();
            Console::WriteLine(u"Dark color: {0}; light color: {1}", data->get_Color1(), data->get_Color2());
        }
        else if (ObjectExt::Is<IBlur>(operation))
        {
            auto blur = ExplicitCast<IBlur>(operation);
            auto data = blur->GetEffective();
            Console::WriteLine(u"Blur radius: {0} pt", data->get_Radius());
        }
        else if (ObjectExt::Is<IAlphaModulateFixed>(operation))
        {
            auto alphaModulate = ExplicitCast<IAlphaModulateFixed>(operation);
            auto data = alphaModulate->GetEffective();
            Console::WriteLine(u"Alpha amount: {0}%", data->get_Amount());
        }
    }
}

presentation->Dispose();
```

Các hiệu ứng không có tham số như xám, alpha ceiling và alpha inverse vẫn có đối tượng dữ liệu hiệu quả, nhưng không có cài đặt vô hướng để in. Sự hiện diện và vị trí của chúng trong bộ sưu tập là thông tin quan trọng.

## **Xóa Hoặc Xóa Sạch Các Biến Đổi Ảnh**

Sử dụng [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) để xóa một hoạt động theo chỉ mục. Vì các chỉ mục dịch chuyển sau khi xóa, hãy tìm mục tiêu trước và xóa nó sau khi liệt kê. Dùng `Clear()` để xóa toàn bộ chuỗi.

```cpp
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto blurIndex = -1;

    for (auto index = 0; index < imageTransform->get_Count(); ++index)
    {
        if (ObjectExt::Is<IBlur>(imageTransform->idx_get(index)))
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform->RemoveAt(blurIndex);
        Console::WriteLine(u"The blur operation was removed.");
    }

    imageTransform->Clear();
    Console::WriteLine(u"Remaining operations: {0}", imageTransform->get_Count());
    presentation->Save(u"image-transforms-cleared.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Xóa hoặc xóa sạch các biến đổi chỉ thay đổi định dạng hình ảnh. Nó không xóa, nén lại hoặc thay đổi tài nguyên [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) được tái sử dụng.

## **Xem Xét Các Định Dạng Bản Trình Bày và Đích Xuất**

Các biến đổi ảnh xuất phát từ DrawingML, vì vậy PPTX là định dạng chỉnh sửa ưa thích cho các chuỗi hiệu ứng. Ngay cả với PPTX, không phải mọi hoạt động đều có độ di động giống nhau:

- Các hoạt động DrawingML chuẩn như luminance, grayscale, duotone, tint, HSL, blur và các thao tác alpha thông thường có khả năng tồn tại tốt nhất sau một vòng quay PPTX. Luôn mở lại tệp đã tạo và kiểm tra bộ sưu tập khi việc bảo tồn là yêu cầu.
- [BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) là một phần mở rộng Office 2010 chứ không phải thao tác luminance DrawingML chuẩn. Nó có thể được sử dụng cho việc render trong bộ nhớ, nhưng không được đảm bảo vẫn còn là một [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/) chỉnh sửa được sau khi lưu và mở lại PPTX. Ưu tiên [AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) cho các điều chỉnh độ sáng và độ tương phản bền vững.
- Định dạng PPT nhị phân xuất hiện trước mô hình hiệu ứng DrawingML đầy đủ. Lưu dưới dạng PPT có thể bỏ qua các hoạt động không hỗ trợ, giảm chuỗi thành một tập con hỗ trợ, hoặc ước tính ngoại hình. Không sử dụng PPT làm định dạng xác minh cho một chuỗi chỉnh sửa phức tạp.
- Render ra PNG, JPEG, TIFF, PDF, SVG, HTML hoặc các đầu ra hình ảnh khác áp dụng chuỗi hỗ trợ lên ngoại hình được render. Các đầu ra này không chứa một `IImageTransformOperationCollection` có thể chỉnh sửa; các định dạng raster làm phẳng kết quả thành pixel, và các xuất tài liệu hoặc vector lưu trữ cách biểu diễn render riêng của chúng.
- Các hiệu ứng không làm cho một hình ảnh liên kết tự chứa. Render một hình ảnh liên kết vẫn phụ thuộc vào việc tài nguyên liên kết có sẵn khi bản trình bày được tải.

Các người tiêu dùng bản trình bày khác nhau có thể render các trường hợp biên khác nhau, đặc biệt khi một số thao tác alpha hoặc màu được kết hợp. Đối với đầu ra quan trọng, hãy kiểm tra cả vòng quay chỉnh sửa và định dạng xuất cuối cùng bằng cùng một phiên bản Aspose.Slides được sử dụng trong môi trường sản xuất.

## **Câu Hỏi Thường Gặp**

**Các hiệu ứng biến đổi ảnh có sửa đổi dữ liệu ảnh nhúng không?**

Không. Các hoạt động thuộc về `ISlidesPicture` được sử dụng bởi lớp nền ảnh. Các byte `IPPImage` nền vẫn không thay đổi.

**Hai khung hình sử dụng cùng một ảnh sẽ chia sẻ các hiệu ứng không?**

Không. Việc tái sử dụng một `IPPImage` tránh dữ liệu ảnh trùng lặp, nhưng mỗi khung hình thường có một `ISlidesPicture` và bộ sưu tập biến đổi ảnh riêng.

**Có thể kết hợp các hiệu ứng màu, làm mờ và alpha không?**

Có. Bộ sưu tập cho phép chúng trong một chuỗi có thứ tự. Hãy cân nhắc mỗi hoạt động ảnh hưởng như thế nào tới đầu ra của hoạt động trước vì các thao tác thay thế và ngưỡng có thể loại bỏ chi tiết màu hoặc alpha đã có.

**Tại sao các giá trị hiệu quả lại chỉ-đọc?**

Dữ liệu hiệu quả đại diện cho các giá trị đã tính toán được dùng để render, bao gồm các màu đã giải quyết. Chỉnh sửa hoạt động lưu trong bộ sưu tập biến đổi nơi có thành viên có thể ghi; nếu không, hãy xóa nó và thêm một thay thế với các tham số tạo mới.

**Định dạng nào nên dùng để bảo tồn một chuỗi biến đổi?**

Sử dụng PPTX và xác minh tệp bằng cách mở lại. PPT cổ không thể biểu diễn toàn bộ mô hình hiệu ứng DrawingML, và các định dạng xuất render chỉ bảo tồn ngoại hình chứ không phải các hoạt động biến đổi có thể chỉnh sửa.