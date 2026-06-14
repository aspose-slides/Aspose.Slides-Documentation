---
title: Quản lý nền bản trình chiếu trong C++
linktitle: Nền Slide
type: docs
weight: 20
url: /vi/cpp/presentation-background/
keywords:
- nền bản trình chiếu
- nền slide
- màu đồng nhất
- màu gradient
- nền hình ảnh
- độ trong suốt nền
- thuộc tính nền
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách thiết lập nền động trong các tệp PowerPoint và OpenDocument bằng Aspose.Slides cho C++, kèm các mẹo mã để nâng cao bản trình chiếu của bạn."
---
## **Giới thiệu**

Màu nền đồng nhất, chuyển màu và hình ảnh thường được sử dụng làm nền cho các slide. Bạn có thể đặt nền cho một **slide bình thường** (một slide duy nhất) hoặc một **slide chủ đề** (áp dụng cho nhiều slide cùng một lúc).

![PowerPoint background](powerpoint-background.png)

## **Đặt nền màu đồng nhất cho slide bình thường**

Aspose.Slides cho phép bạn đặt một màu đồng nhất làm nền cho một slide cụ thể trong bản trình chiếu—ngay cả khi bản trình chiếu sử dụng slide chủ đề. Thay đổi chỉ áp dụng cho slide đã chọn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) của nền slide thành `Solid`.
4. Sử dụng phương thức [get_SolidFillColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fillformat/get_solidfillcolor/) trên [FillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fillformat/) để chỉ định màu nền đồng nhất.
5. Lưu bản trình chiếu đã sửa đổi.

Ví dụ C++ sau cho thấy cách đặt màu xanh lam đồng nhất làm nền cho một slide bình thường:

```cpp
// Tạo một thể hiện của lớp Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Đặt màu nền của slide thành màu xanh.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Lưu bản trình chiếu vào đĩa.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Đặt nền màu đồng nhất cho slide chủ đề**

Aspose.Slides cho phép bạn đặt một màu đồng nhất làm nền cho slide chủ đề trong bản trình chiếu. Slide chủ đề hoạt động như một mẫu điều khiển định dạng cho tất cả các slide, vì vậy khi bạn chọn một màu đồng nhất cho nền của slide chủ đề, nó sẽ áp dụng cho mọi slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/backgroundtype/) của slide chủ đề (qua `get_Masters`) thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) của nền slide chủ đề thành `Solid`.
4. Sử dụng phương thức [get_SolidFillColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fillformat/get_solidfillcolor/) để chỉ định màu nền đồng nhất.
5. Lưu bản trình chiếu đã sửa đổi.

Ví dụ C++ sau cho thấy cách đặt màu xanh rừng đồng nhất làm nền cho một slide chủ đề:

```cpp
// Tạo một thể hiện của lớp Presentation.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Đặt màu nền cho slide Master thành màu Xanh Rừng.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Lưu bản trình chiếu vào đĩa.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Đặt nền gradient cho slide**

Gradient là một hiệu ứng đồ họa được tạo ra bằng cách thay đổi màu một cách dần dần. Khi được sử dụng làm nền slide, gradient có thể làm cho bản trình chiếu trông nghệ thuật và chuyên nghiệp hơn. Aspose.Slides cho phép bạn đặt màu gradient làm nền cho các slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) của nền slide thành `Gradient`.
4. Sử dụng phương thức [get_GradientFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fillformat/get_gradientformat/) trên [FillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fillformat/) để cấu hình các thiết lập gradient mong muốn.
5. Lưu bản trình chiếu đã sửa đổi.

Ví dụ C++ sau cho thấy cách đặt màu gradient làm nền cho một slide:

```cpp
// Tạo một thể hiện của lớp Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Áp dụng hiệu ứng gradient cho nền.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Lưu bản trình chiếu vào đĩa.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Đặt hình ảnh làm nền slide**

Ngoài các loại tô đồng nhất và gradient, Aspose.Slides cho phép bạn sử dụng hình ảnh làm nền cho slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) của nền slide thành `Picture`.
4. Tải hình ảnh bạn muốn dùng làm nền slide.
5. Thêm hình ảnh vào bộ sưu tập hình ảnh của bản trình chiếu.
6. Sử dụng phương thức [get_PictureFillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fillformat/get_picturefillformat/) trên [FillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fillformat/) để gán hình ảnh làm nền.
7. Lưu bản trình chiếu đã sửa đổi.

Ví dụ C++ sau cho thấy cách đặt một hình ảnh làm nền cho một slide:

```cpp
// Tạo một thể hiện của lớp Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Đặt các thuộc tính hình ảnh nền.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Tải hình ảnh.
auto image = Images::FromFile(u"Tulips.jpg");
// Thêm hình ảnh vào bộ sưu tập hình ảnh của bản trình chiếu.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// Lưu bản trình chiếu vào đĩa.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

```cpp
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

{{% alert color="primary" %}}
Đọc thêm: [**Tile Picture As Texture**](/slides/vi/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Thay đổi độ trong suốt của ảnh nền**

Bạn có thể muốn điều chỉnh độ trong suốt của ảnh nền slide để làm cho nội dung slide nổi bật hơn. Đoạn mã C++ sau cho thấy cách thay đổi độ trong suốt cho ảnh nền slide:

```cpp
auto transparencyValue = 30; // Ví dụ.

// Lấy bộ sưu tập các thao tác biến đổi hình ảnh.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Tìm hiệu ứng trong suốt tỉ lệ phần trăm cố định hiện có.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```

## **Lấy giá trị nền của slide**

Aspose.Slides cung cấp giao diện [IBackgroundEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibackgroundeffectivedata/) để truy xuất các giá trị nền thực tế của một slide. Giao diện này cung cấp [FillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) và [EffectFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) thực tế.

Sử dụng phương thức `get_Background` của lớp [BaseSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/baseslide/), bạn có thể lấy nền thực tế của một slide.

Ví dụ C++ sau cho thấy cách lấy giá trị nền thực tế của một slide:

```cpp
// Tạo một thể hiện của lớp Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Lấy nền thực tế, tính đến master, layout và theme.
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

**Tôi có thể đặt lại nền tùy chỉnh và khôi phục lại nền của theme/bố cục không?**

Có. Loại bỏ việc tô màu tùy chỉnh của slide, và nền sẽ được kế thừa lại từ slide [layout](/slides/vi/cpp/slide-layout/)/[master](/slides/vi/cpp/slide-master/) tương ứng (tức là [nền theme](/slides/vi/cpp/presentation-theme/)).

**Điều gì sẽ xảy ra với nền nếu tôi thay đổi theme của bản trình chiếu sau này?**

Nếu một slide có màu nền riêng, nó sẽ không thay đổi. Nếu nền được kế thừa từ [layout](/slides/vi/cpp/slide-layout/)/[master](/slides/vi/cpp/slide-master/), nó sẽ được cập nhật để phù hợp với [theme mới](/slides/vi/cpp/presentation-theme/).