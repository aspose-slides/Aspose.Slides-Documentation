---
title: Quản lý các hiệu ứng biến đổi ảnh trong bản trình chiếu với C++
linktitle: Các hiệu ứng biến đổi ảnh
type: docs
weight: 11
url: /vi/cpp/image-transform-effects/
keywords:
- biến đổi ảnh
- hiệu ứng hình ảnh
- độ sáng
- độ tương phản
- ảnh xám
- hai giọng màu
- tông màu
- HSL
- thay thế màu
- làm mờ
- độ trong suốt
- hiệu ứng alpha
- chuỗi hiệu ứng
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Áp dụng, tạo chuỗi, kiểm tra, xóa và xác minh các hiệu ứng biến đổi ảnh cho khung hình ảnh với Aspose.Slides cho C++."
---
## **Tổng quan**

Aspose.Slides biểu diễn các điều chỉnh ảnh dưới dạng một bộ sưu tập có thứ tự của các thao tác biến đổi ảnh. Đối với một khung ảnh, bắt đầu với [ISlidesPicture](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidespicture/) của khung và truy cập [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidespicture/get_imagetransform/). Bộ [IImageTransformOperationCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/) trả về cho phép bạn thêm, liệt kê, kiểm tra, xóa và xóa sạch các hiệu ứng mà không cần ghi lại lại các byte ảnh gốc.

Bài viết này trình bày một quy trình hoàn chỉnh cho độ sáng và độ tương phản, biến đổi màu, làm mờ, trong suốt, chuỗi hiệu ứng có thứ tự, giá trị thực tế, việc xóa và xác minh vòng tròn PPTX.

## **Hiểu Quyền Sở Hữu Hiệu Ứng và Việc Tái Sử Dụng Ảnh**

Một tài nguyên ảnh và hình ảnh hiển thị nó là các đối tượng khác nhau:

- [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) lưu trữ hoặc tham chiếu dữ liệu ảnh nguồn mà bản trình chiếu sở hữu.
- [ISlidesPicture](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidespicture/) thuộc về một fill ảnh và tham chiếu tới tài nguyên ảnh trong khi lưu trữ bộ sưu tập biến đổi ảnh.
- [IPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframe/) là hình dạng slide sở hữu fill ảnh liên quan, hình học, cài đặt cắt và các định dạng ở mức khung khác.

Do đó, các thao tác biến đổi ảnh không thay đổi các byte trong [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/). Khi cùng một `IPPImage` được truyền cho [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/addpictureframe/) hơn một lần, mỗi khung ảnh mới sẽ nhận được `ISlidesPicture` riêng và bộ sưu tập biến đổi riêng. Áp dụng biểu đồ xám cho một khung không làm cho các khung khác cũng trở thành biểu đồ xám, mặc dù tất cả chúng đều tái sử dụng cùng một tài nguyên ảnh được nhúng.

Mô hình `ISlidesPicture::get_ImageTransform` tương tự cũng được các fill ảnh khác sử dụng, chẳng hạn như shape hoặc nền slide. Các ví dụ dưới đây tập trung vào khung ảnh.

## **Sử Dụng Phạm Vi Tham Số và Đơn Vị Hợp Lệ**

Các phương pháp được trình bày sử dụng các phạm vi ngữ nghĩa và đơn vị sau. Giữ các giá trị trong các phạm vi này ngay cả khi phiên bản thư viện cụ thể không từ chối ngay mọi giá trị ngoài phạm vi; định dạng bản trình chiếu mục tiêu có thể chuẩn hoá, bỏ qua, hoặc từ chối dữ liệu không hợp lệ trong quá trình lưu hoặc khi PowerPoint mở tệp.

| Thao tác | Tham số | Phạm vi và đơn vị hợp lệ |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` đến `100`, phần trăm; `0` giữ nguyên thành phần. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Không có | Không có tham số số. Alpha không thay đổi. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Hai màu cho pixel tối và sáng. Các kênh RGB và alpha trong `System::Drawing::Color` dùng giá trị `0` đến `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue từ `0` (bao gồm) đến `360` (không bao gồm), tính bằng độ; amount từ `-100` đến `100`, phần trăm. |
| [AddHSLEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue từ `0` (bao gồm) đến `360` (không bao gồm), tính bằng độ; saturation và luminance từ `-100` đến `100`, phần trăm. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Màu thay thế sử dụng giá trị kênh từ `0` đến `255`. Giá trị alpha hiện có không thay đổi. |
| [AddBlurEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Bán kính không âm và đo bằng điểm; `grow` điều khiển việc nội dung mờ có thể mở rộng ra ngoài giới hạn gốc hay không. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Phần trăm không âm. Dùng `0` đến `100` cho việc điều chỉnh độ mờ thường: `0` là hoàn toàn trong suốt và `100` giữ nguyên alpha hiện có. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` đến `100`, phần trăm độ trong suốt. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` đến `100`, phần trăm ngưỡng alpha. Giá trị dưới ngưỡng trở thành trong suốt; giá trị bằng hoặc trên ngưỡng trở nên đặc. |

Đối với điều chế alpha cố định, trong suốt và độ mờ là các khái niệm bổ trợ. Ví dụ, độ trong suốt 35 % tương ứng với một mức điều chế alpha là 65 %.

## **Áp Dụng Độ Sáng và Độ Tương Phản**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) trả về một thao tác [IBrightnessContrast](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/ibrightnesscontrast/). Các thiết lập vô hướng của nó được cung cấp khi tạo thao tác. Phương thức `IBrightnessContrast::GetEffective` trả về các giá trị chỉ đọc đã tính toán mà có thể được kiểm tra hoặc ghi lại.

Ví dụ dưới đây tăng độ sáng lên 15 % và độ tương phản lên 20 %, sau đó hiển thị bản xem trước mà không thay đổi ảnh được nhúng:

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

[BrightnessContrast](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/brightnesscontrast/) là một phần mở rộng hiệu ứng ảnh Office 2010 và ít di động hơn so với hiệu ứng luminance chuẩn DrawingML. Khi độ sáng và độ tương phản cần phải vẫn có thể chỉnh sửa sau một vòng tròn PPTX, hãy dùng [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) và xác minh kết quả sau khi mở lại tệp. Phần giới hạn định dạng giải thích chi tiết hơn về sự khác biệt này.

## **Áp Dụng Biến Đổi Màu**

Các hiệu ứng màu có thể được áp dụng độc lập cho các khung ảnh khác nhau dùng chung một tài nguyên ảnh. Ví dụ dưới tạo năm khung và áp dụng biểu đồ xám, duotone, tint, điều chỉnh HSL và thay thế màu.

[IDuotone](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iduotone/) chứa hai tham số màu có thể chỉnh sửa độc lập: `get_Color1` ánh xạ pixel tối, còn `get_Color2` ánh xạ pixel sáng. Điều này làm nó trở thành một ví dụ hữu ích cho một hiệu ứng có cài đặt phức tạp hơn một giá trị vô hướng đơn.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) thay thế màu của mọi pixel bằng một màu cố định trong khi giữ lại alpha. Nó khác với [AddColorChangeEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), cái mà ánh xạ một màu nguồn sang màu đích và cho phép cả hai định dạng màu nguồn và đích.

## **Thêm Hiệu Ứng Làm Mờ, Trong Suốt và Alpha**

[AddBlurEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) ảnh hưởng đến tất cả các kênh màu, bao gồm cả alpha. Đặt `grow` thành `true` khi cạnh mờ có thể mở rộng ra ngoài giới hạn hình ảnh gốc.

Đối với trong suốt đồng nhất, dùng [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Nó nhân mỗi giá trị alpha hiện có, do đó các pixel bán trong suốt vẫn giữ tỷ lệ khác nhau. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) thay vào đó gán một giá trị alpha cho mọi pixel. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) chuyển đổi alpha thành hai mức dựa trên ngưỡng.

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

Các thao tác alpha không có tham số khác bao gồm [AddAlphaCeilingEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), làm mọi alpha khác không thành đặc; [AddAlphaFloorEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), làm mọi alpha dưới 100 % thành trong suốt hoàn toàn; và [AddAlphaInverseEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), chuyển đổi alpha thành `100% - alpha`.

## **Xây Dựng Chuỗi Hiệu Ứng Có Thứ Tự**

Mỗi phương pháp `Add...Effect` thêm một thao tác mới vào cuối bộ sưu tập. Trình vẽ sử dụng bộ sưu tập như một pipeline có thứ tự: đầu ra của thao tác 0 trở thành đầu vào của thao tác 1, và cứ thế. Do đó, cùng các thao tác nhưng thứ tự khác nhau có thể tạo ra ảnh khác nhau.

Ví dụ, biểu đồ xám rồi tint sẽ đầu tiên loại bỏ thông tin màu và sau đó tô lại kết quả luminance. Tint rồi biểu đồ xám sẽ lại loại bỏ tint. Tương tự, việc thay thế alpha có thể ghi đè các giá trị alpha được tính bởi các thao tác trước, trong khi điều chế alpha giữ lại sự chênh lệch tương đối của chúng.

Ví dụ dưới tạo một chuỗi bốn thao tác, lưu dưới dạng PPTX, mở lại bản trình chiếu, kiểm tra cả loại thao tác và thứ tự của chúng, và hiển thị kết quả đã mở lại:

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

Bộ sưu tập không áp đặt ma trận tương thích nào buộc các thao tác màu, alpha và làm mờ vào các chuỗi riêng biệt. Chúng có thể được kết hợp, nhưng không phải lúc nào cũng hữu ích. Thay thế màu cố định loại bỏ biến thể RGB được tạo bởi các hiệu ứng màu trước; biểu đồ xám sau duotone loại bỏ hai màu đã chọn; và các thao tác alpha ceiling, floor, replace hoặc bi‑level có thể bỏ qua chi tiết alpha đã tạo trước. Xây dựng chuỗi theo thứ tự xử lý pixel mong muốn thay vì coi các mục là các cờ định dạng không thứ tự.

## **Kiểm Tra Các Giá Trị Có Thể Chỉnh Sửa và Giá Trị Thực Tế**

Một thao tác có thể chỉnh sửa là đối tượng được lưu trong `ISlidesPicture::get_ImageTransform`. Tùy thuộc vào hiệu ứng, nó có thể phơi bày các thành viên có thể ghi trực tiếp. Ví dụ, [IBlur](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iblur/) phơi bày `set_Radius` và `set_Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/ialphamodulatefixed/) phơi bày `set_Amount`, và [IAlphaBiLevel](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/ialphabilevel/) phơi bày `set_Threshold`. Các hiệu ứng màu như [IDuotone](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iduotone/) phơi bày các đối tượng [IColorFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icolorformat/) có thể thay đổi.

Một số giao diện thao tác, bao gồm [IBrightnessContrast](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/itint/), và [IAlphaReplace](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/ialphareplace/), không phơi bày các vô hướng tạo ra dưới dạng thuộc tính có thể ghi. Để thay đổi các cài đặt đó, cần xóa thao tác và thêm một thao tác thay thế tại vị trí mong muốn.

Dữ liệu thực tế trả về bởi `GetEffective()` được tính toán và chỉ đọc. Nó hữu ích để giải quyết các màu phụ thuộc vào theme và đọc các giá trị chuẩn hoá mà trình vẽ sử dụng, nhưng không phải là một bề mặt chỉnh sửa khác. Ví dụ dưới liệt kê chuỗi và kiểm tra các giá trị thực tế cho một số thao tác thường gặp:

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

Các hiệu ứng không có tham số như biểu đồ xám, alpha ceiling và alpha inverse vẫn có đối tượng dữ liệu thực tế, nhưng không có cài đặt vô hướng để in ra. Sự hiện diện và vị trí của chúng trong bộ sưu tập là thông tin quan trọng.

## **Xóa Hoặc Xóa Sạch Các Biến Đổi Ảnh**

Sử dụng [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) để xóa một thao tác theo chỉ mục. Vì các chỉ mục thay đổi sau khi xóa, trước tiên tìm mục tiêu rồi mới xóa sau khi liệt kê. Dùng `Clear()` để xóa toàn bộ chuỗi.

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

Việc xóa hoặc xóa sạch các biến đổi chỉ thay đổi định dạng hình ảnh. Nó không xóa, nén lại, hoặc thay đổi tài nguyên [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) được tái sử dụng.

## **Xem Xét Các Định Dạng Bản Trình Chiếu và Đích Xuất**

Biến đổi ảnh bắt nguồn từ DrawingML, vì vậy PPTX là định dạng có thể chỉnh sửa ưu tiên cho chuỗi hiệu ứng. Ngay cả với PPTX, không phải mọi thao tác đều có cùng mức độ di động:

- Các thao tác DrawingML tiêu chuẩn như luminance, grayscale, duotone, tint, HSL, blur và các thao tác alpha thông thường có khả năng tồn tại tốt nhất qua một vòng tròn PPTX. Luôn mở lại tệp đã tạo và kiểm tra bộ sưu tập khi yêu cầu bảo tồn.
- [BrightnessContrast](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/brightnesscontrast/) là một phần mở rộng Office 2010 chứ không phải thao tác luminance DrawingML chuẩn. Nó có thể dùng cho việc vẽ trong bộ nhớ, nhưng không được đảm bảo còn tồn tại dưới dạng [IBrightnessContrast](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/ibrightnesscontrast/) có thể chỉnh sửa sau khi lưu và mở lại PPTX. Nên ưu tiên [AddLuminanceEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) cho việc điều chỉnh độ sáng và độ tương phản lâu dài.
- Định dạng PPT nhị phân xuất hiện trước mô hình hiệu ứng DrawingML đầy đủ. Lưu dưới dạng PPT có thể bỏ qua các thao tác không hỗ trợ, giảm chuỗi xuống một tập con được hỗ trợ, hoặc xấp xỉ ngoại hình. Không dùng PPT làm định dạng xác minh cho một chuỗi có thể chỉnh sửa phức tạp.
- Xuất ra PNG, JPEG, TIFF, PDF, SVG, HTML hoặc các đầu ra hình ảnh khác áp dụng chuỗi đã hỗ trợ lên hình ảnh được vẽ. Các đầu ra này không chứa một `IImageTransformOperationCollection` có thể chỉnh sửa; định dạng raster làm phẳng kết quả thành các pixel, và các xuất khẩu tài liệu hoặc vector lưu trữ đại diện vẽ riêng của chúng.
- Hiệu ứng không làm cho một ảnh liên kết tự chứa. Việc vẽ một hình ảnh liên kết vẫn phụ thuộc vào tài nguyên liên kết còn khả dụng khi tải bản trình chiếu.

Các người tiêu dùng bản trình chiếu khác nhau có thể vẽ các trường hợp biên khác nhau, đặc biệt khi kết hợp nhiều thao tác alpha hoặc lượng tử màu. Đối với đầu ra quan trọng, hãy kiểm tra cả vòng tròn chỉnh sửa và định dạng xuất cuối cùng bằng cùng một phiên bản Aspose.Slides đang dùng trong sản xuất.

## **Câu Hỏi Thường Gặp**

**Các hiệu ứng biến đổi ảnh có thay đổi dữ liệu ảnh được nhúng không?**

Không. Các thao tác thuộc về `ISlidesPicture` được sử dụng bởi fill ảnh. Các byte `IPPImage` nền tảng không bị thay đổi.

**Hai khung ảnh sử dụng cùng một ảnh có chia sẻ hiệu ứng không?**

Không. Tái sử dụng một `IPPImage` giúp tránh dữ liệu ảnh trùng lặp, nhưng mỗi khung ảnh thường có một `ISlidesPicture` và bộ sưu tập biến đổi ảnh riêng.

**Có thể kết hợp các hiệu ứng màu, làm mờ và alpha không?**

Có. Bộ sưu tập cho phép chúng trong một chuỗi có thứ tự. Hãy cân nhắc mỗi thao tác ảnh hưởng tới đầu ra của thao tác trước vì các thao tác thay thế và ngưỡng có thể bỏ qua chi tiết màu hoặc alpha đã tạo trước.

**Tại sao các giá trị thực tế lại chỉ đọc?**

Dữ liệu thực tế đại diện cho các giá trị đã tính toán dùng để vẽ, bao gồm màu đã giải quyết. Chỉnh sửa thao tác lưu trong bộ sưu tập biến đổi nơi có thành viên có thể ghi; nếu không, hãy xóa và thêm một thao tác thay thế với các tham số tạo mới.

**Định dạng nào nên dùng để bảo tồn chuỗi biến đổi?**

Dùng PPTX và xác minh tệp bằng cách mở lại. PPT cổ không thể biểu diễn toàn bộ mô hình hiệu ứng DrawingML, và các định dạng xuất ra hình ảnh chỉ giữ lại ngoại hình chứ không có các thao tác biến đổi có thể chỉnh sửa.