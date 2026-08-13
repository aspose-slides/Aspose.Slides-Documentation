---
title: Quản lý Nền Bài Thuyết Trình trong C++
linktitle: Nền Slide
type: docs
weight: 20
url: /vi/cpp/presentation-background/
keywords:
- nền bài thuyết trình
- nền slide
- màu đồng nhất
- màu gradient
- nền ảnh
- độ trong suốt nền
- thuộc tính nền
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tìm hiểu cách đặt nền động cho tệp PowerPoint và OpenDocument bằng Aspose.Slides cho C++, với các mẹo mã để nâng cao bài thuyết trình của bạn."
---
## **Giới thiệu**

Màu nền đồng nhất, gradient và hình ảnh thường được sử dụng cho nền của các slide. Bạn có thể đặt nền cho một **slide bình thường** (một slide duy nhất) hoặc một **slide chủ** (áp dụng cho nhiều slide cùng lúc).

![PowerPoint background](powerpoint-background.png)

## **Đặt nền màu đồng nhất cho Slide bình thường**

Aspose.Slides cho phép bạn đặt một màu đồng nhất làm nền cho một slide cụ thể trong bản thuyết trình—ngay cả khi bản thuyết trình sử dụng slide chủ. Thay đổi chỉ áp dụng cho slide đã chọn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) của nền slide thành `Solid`.
4. Sử dụng phương thức [get_SolidFillColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fillformat/get_solidfillcolor/) trên [FillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fillformat/) để chỉ định màu nền đồng nhất.
5. Lưu bản thuyết trình đã chỉnh sửa.

Ví dụ C++ sau cho thấy cách đặt màu xanh đậm đồng nhất làm nền cho một slide bình thường:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Tạo một thể hiện của lớp Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Đặt màu nền của slide thành màu xanh.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Lưu bản thuyết trình vào đĩa.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Đặt nền màu đồng nhất cho Slide chủ**

Aspose.Slides cho phép bạn đặt một màu đồng nhất làm nền cho slide chủ trong bản thuyết trình. Slide chủ đóng vai trò là mẫu kiểm soát định dạng cho tất cả các slide, vì vậy khi bạn chọn màu đồng nhất cho nền slide chủ, nó sẽ áp dụng cho mọi slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/backgroundtype/) của slide chủ (qua `get_Masters`) thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) của nền slide chủ thành `Solid`.
4. Sử dụng phương thức [get_SolidFillColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fillformat/get_solidfillcolor/) để chỉ định màu nền đồng nhất.
5. Lưu bản thuyết trình đã chỉnh sửa.

Ví dụ C++ sau cho thấy cách đặt màu đồng nhất (xanh rừng) làm nền cho một slide chủ:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Tạo một thể hiện của lớp Presentation.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Đặt màu nền cho slide Master thành màu xanh rừng.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Lưu bản thuyết trình vào đĩa.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Đặt nền Gradient cho Slide**

Gradient là hiệu ứng đồ họa được tạo ra bằng sự thay đổi dần dãi của màu sắc. Khi được sử dụng làm nền slide, gradient có thể làm cho bản thuyết trình trông nghệ thuật và chuyên nghiệp hơn. Aspose.Slides cho phép bạn đặt màu gradient làm nền cho các slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) của nền slide thành `Gradient`.
4. Sử dụng phương thức [get_GradientFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fillformat/get_gradientformat/) trên [FillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fillformat/) để cấu hình các thiết lập gradient mong muốn.
5. Lưu bản thuyết trình đã chỉnh sửa.

Ví dụ C++ sau cho thấy cách đặt màu gradient làm nền cho một slide:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Tạo một thể hiện của lớp Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Áp dụng hiệu ứng gradient cho nền.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Lưu bản thuyết trình vào đĩa.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Đặt hình ảnh làm Nền cho Slide**

Ngoài các màu nền đồng nhất và gradient, Aspose.Slides cho phép bạn sử dụng hình ảnh làm nền cho slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) của nền slide thành `Picture`.
4. Tải ảnh bạn muốn dùng làm nền cho slide.
5. Thêm ảnh vào bộ sưu tập ảnh của bản thuyết trình.
6. Sử dụng phương thức [get_PictureFillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fillformat/get_picturefillformat/) trên [FillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fillformat/) để gán ảnh làm nền.
7. Lưu bản thuyết trình đã chỉnh sửa.

Ví dụ C++ sau cho thấy cách đặt hình ảnh làm nền cho một slide:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Tạo một thể hiện của lớp Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Đặt các thuộc tính hình nền.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Tải hình ảnh.
auto image = Images::FromFile(u"Tulips.jpg");
// Thêm hình ảnh vào bộ sưu tập hình ảnh của bản thuyết trình.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// Lưu bản thuyết trình vào đĩa.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}}
Đọc thêm: [**Tile Picture As Texture**](/slides/vi/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Thay đổi Độ trong suốt của Hình nền**

Bạn có thể muốn điều chỉnh độ trong suốt của hình nền slide để nội dung slide nổi bật hơn. Mã C++ sau cho bạn biết cách thay đổi độ trong suốt cho hình nền của slide:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto transparencyValue = 30; // Ví dụ.

// Tạo một thể hiện của lớp Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Lấy tập hợp các thao tác biến đổi hình ảnh.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Tìm hiệu ứng trong suốt phần trăm cố định hiện có.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Đặt giá trị trong suốt mới.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}

// Lưu bản thuyết trình vào đĩa.
presentation->Save(u"TransparentBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Lấy giá trị Nền của Slide**

Aspose.Slides cung cấp giao diện [IBackgroundEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibackgroundeffectivedata/) để truy xuất các giá trị nền thực tế của slide. Giao diện này cung cấp [FillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) và [EffectFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) thực tế.

Bằng cách sử dụng phương thức `get_Background` của lớp [BaseSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/baseslide/), bạn có thể lấy nền thực tế của một slide.

Ví dụ C++ sau cho thấy cách lấy giá trị nền thực tế của một slide:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

// Tạo một thể hiện của lớp Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Lấy nền hiệu lực, tính đến master, layout và theme.
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```

## **FAQ**

### Tôi có thể đặt lại nền tùy chỉnh và khôi phục lại nền theme/bố cục không?

Có. Xóa phần tô màu tùy chỉnh của slide, và nền sẽ lại được kế thừa từ slide [layout](/slides/vi/cpp/slide-layout/)/[master](/slides/vi/cpp/slide-master/) tương ứng (tức là [theme background](/slides/vi/cpp/presentation-theme/)).

### Điều gì sẽ xảy ra với nền nếu tôi thay đổi theme của bản thuyết trình sau này?

Nếu một slide có phần tô màu riêng, nó sẽ không thay đổi. Nếu nền được kế thừa từ [layout](/slides/vi/cpp/slide-layout/)/[master](/slides/vi/cpp/slide-master/), nó sẽ cập nhật để phù hợp với [new theme](/slides/vi/cpp/presentation-theme/).