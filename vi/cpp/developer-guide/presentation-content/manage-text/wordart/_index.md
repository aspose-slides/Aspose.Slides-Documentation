---
title: "Tạo và Áp dụng Hiệu ứng WordArt trong C++"
linktitle: "WordArt"
type: docs
weight: 110
url: /vi/cpp/wordart/
keywords:
- WordArt
- tạo WordArt
- mẫu WordArt
- hiệu ứng WordArt
- hiệu ứng bóng đổ
- hiệu ứng hiển thị
- hiệu ứng phát sáng
- biến đổi WordArt
- hiệu ứng 3D
- hiệu ứng bóng ngoài
- hiệu ứng bóng trong
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tạo và tùy chỉnh các hiệu ứng WordArt trong Aspose.Slides cho C++. Hướng dẫn từng bước này giúp các nhà phát triển nâng cao bản trình chiếu với văn bản chuyên nghiệp trong C++."
---
## **Tổng quan**

WordArt cho phép bạn thêm văn bản mang phong cách, hấp dẫn trực quan vào các bản trình bày PowerPoint. Với Aspose.Slides, các nhà phát triển có thể tạo, tùy chỉnh và quản lý WordArt một cách lập trình, giống như trong Microsoft PowerPoint—không cần cài đặt Office. Bài viết này cung cấp tổng quan về cách làm việc với WordArt, bao gồm cách áp dụng các biến đổi văn bản, kiểu nền, viền, bóng đổ và các tùy chọn định dạng khác để làm cho nội dung bài thuyết trình trở nên biểu cảm và thu hút hơn. WordArt cho phép bạn coi văn bản như một đối tượng đồ họa. Nó bao gồm các hiệu ứng hoặc sửa đổi đặc biệt được áp dụng cho văn bản để làm cho nó hấp dẫn hoặc nổi bật hơn.

## **Tạo mẫu WordArt đơn giản và áp dụng nó cho văn bản**

**Using Aspose.Slides** 

Đầu tiên, chúng ta tạo một đoạn văn bản đơn giản bằng đoạn mã C++ này: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

Bây giờ, chúng ta đặt độ cao phông chữ của văn bản thành giá trị lớn hơn để làm cho hiệu ứng rõ hơn bằng đoạn mã này:

``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**Using Microsoft PowerPoint**

Đi tới menu hiệu ứng WordArt trong Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Từ menu bên phải, bạn có thể chọn một hiệu ứng WordArt có sẵn. Từ menu bên trái, bạn có thể chỉ định các thiết lập cho một WordArt mới. 

Đây là một số tham số hoặc tùy chọn có sẵn:

![todo:image_alt_text](image-20200930114015-3.png)

**Using Aspose.Slides**

Ở đây, chúng ta áp dụng màu mẫu SmallGrid cho văn bản và thêm viền văn bản đen độ rộng 1 bằng đoạn mã này:

``` cpp 
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

Văn bản kết quả:

![todo:image_alt_text](image-20200930114108-4.png)

## **Áp dụng các hiệu ứng WordArt khác**

**Using Microsoft PowerPoint**

Từ giao diện của chương trình, bạn có thể áp dụng các hiệu ứng này cho văn bản, khối văn bản, hình dạng hoặc phần tử tương tự:

![todo:image_alt_text](image-20200930114129-5.png)

Ví dụ, các hiệu ứng Shadow, Reflection và Glow có thể được áp dụng cho văn bản; các hiệu ứng 3D Format và 3D Rotation có thể được áp dụng cho khối văn bản; thuộc tính Soft Edges có thể được áp dụng cho một Shape Object (nó vẫn có hiệu ứng khi không đặt thuộc tính 3D Format). 

### **Áp dụng hiệu ứng bóng đổ cho văn bản**

Ở đây, chúng ta muốn thiết lập các thuộc tính chỉ liên quan đến văn bản. Chúng ta áp dụng hiệu ứng bóng đổ cho văn bản bằng đoạn mã C++ này:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(65);
outerShadowEffect->set_BlurRadius(4.73);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(2);
outerShadowEffect->set_SkewHorizontal(30);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

Aspose.Slides API hỗ trợ ba loại bóng: OuterShadow, InnerShadow và PresetShadow. 

Với PresetShadow, bạn có thể áp dụng bóng cho văn bản (sử dụng các giá trị có sẵn). 

**Using Microsoft PowerPoint**

Trong PowerPoint, bạn chỉ có thể sử dụng một loại bóng. Dưới đây là một ví dụ:

![todo:image_alt_text](image-20200930114225-6.png)

**Using Aspose.Slides**

Aspose.Slides thực tế cho phép bạn áp dụng đồng thời hai loại bóng: InnerShadow và PresetShadow.

**Notes:**

- Khi OuterShadow và PresetShadow được sử dụng cùng nhau, chỉ hiệu ứng OuterShadow được áp dụng. 
- Nếu OuterShadow và InnerShadow được sử dụng đồng thời, hiệu ứng áp dụng phụ thuộc vào phiên bản PowerPoint. Ví dụ, trong PowerPoint 2013, hiệu ứng sẽ được nhân đôi. Nhưng trong PowerPoint 2007, hiệu ứng OuterShadow sẽ được áp dụng. 

### **Áp dụng hiệu ứng phản chiếu**

Chúng tôi thêm một phản chiếu vào văn bản bằng ví dụ mã C++ này:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableReflectionEffect();

auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_BlurRadius(0.5);
reflectionEffect->set_Distance(4.72);
reflectionEffect->set_StartPosAlpha(0.f);
reflectionEffect->set_EndPosAlpha(60.f);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_ScaleHorizontal(100);
reflectionEffect->set_ScaleVertical(-100);
reflectionEffect->set_StartReflectionOpacity(60.f);
reflectionEffect->set_EndReflectionOpacity(0.9f);
reflectionEffect->set_RectangleAlign(RectangleAlignment::BottomLeft);
```

### **Áp dụng hiệu ứng phát sáng**

Chúng tôi áp dụng hiệu ứng glow cho văn bản để làm cho nó tỏa sáng hoặc nổi bật bằng đoạn mã này:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

Kết quả của thao tác:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Bạn có thể thay đổi các tham số cho bóng, hiển thị và glow. Các thuộc tính của hiệu ứng được đặt riêng cho từng phần của văn bản. 

{{% /alert %}} 

### **Sử dụng biến đổi trong WordArt**

Chúng tôi sử dụng phương thức set_Transform (áp dụng cho toàn bộ khối văn bản) qua đoạn mã này:

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

Kết quả:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Cả Microsoft PowerPoint và Aspose.Slides cho C++ đều cung cấp một số loại biến đổi có sẵn. 

{{% /alert %}} 

**Using PowerPoint**

Để truy cập các loại biến đổi có sẵn, hãy vào: **Format**->**TextEffect**->**Transform**

**Using Aspose.Slides**

Để chọn một loại biến đổi, sử dụng enum TextShapeType. 

### **Áp dụng hiệu ứng 3D cho văn bản và hình dạng**

Chúng tôi đặt một hiệu ứng 3D cho một hình dạng văn bản bằng đoạn mã mẫu này:

``` cpp 
auto threeDFormat = autoShape->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(10.5);
threeDFormat->get_BevelBottom()->set_Width(10.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(12.5);
threeDFormat->get_BevelTop()->set_Width(11);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

Văn bản và hình dạng kết quả:

![todo:image_alt_text](image-20200930114816-9.png)

Chúng tôi áp dụng một hiệu ứng 3D cho văn bản bằng đoạn mã C++ này:

``` cpp 
auto threeDFormat = textFrame->get_TextFrameFormat()->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(3.5);
threeDFormat->get_BevelBottom()->set_Width(3.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(4);
threeDFormat->get_BevelTop()->set_Width(4);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

Kết quả của thao tác:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Việc áp dụng các hiệu ứng 3D cho văn bản hoặc hình dạng của chúng và tương tác giữa các hiệu ứng dựa trên một số quy tắc. 

Xem xét một cảnh cho văn bản và hình dạng chứa văn bản đó. Hiệu ứng 3D bao gồm biểu diễn đối tượng 3D và cảnh mà đối tượng được đặt lên. 

- Khi cảnh được thiết lập cho cả hình và văn bản, cảnh của hình có ưu tiên cao hơn—cảnh của văn bản sẽ bị bỏ qua. 
- Khi hình không có cảnh riêng nhưng có biểu diễn 3D, sẽ sử dụng cảnh của văn bản. 
- Ngược lại—khi hình ban đầu không có hiệu ứng 3D—hình sẽ phẳng và hiệu ứng 3D chỉ được áp dụng cho văn bản. 

Các mô tả này liên quan đến các phương thức ThreeDFormat.getLightRig() và ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Áp dụng hiệu ứng bóng ngoài cho hình dạng**
Aspose.Slides cho C++ cung cấp các lớp [**IOuterShadow**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.effects.i_outer_shadow) và [**IInnerShadow**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.effects.i_inner_shadow) cho phép bạn áp dụng hiệu ứng bóng cho văn bản được chứa trong TextFrame. Thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation). 
2. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó. 
3. Thêm một AutoShape loại Rectangle vào slide. 
4. Truy cập TextFrame liên kết với AutoShape. 
5. Đặt FillType của AutoShape thành NoFill. 
6. Tạo thể hiện OuterShadow 
7. Đặt BlurRadius của bóng. 
8. Đặt Direction của bóng 
9. Đặt Distance của bóng. 
10. Đặt RectanglelAlign thành TopLeft. 
11. Đặt PresetColor của bóng thành Black. 
12. Ghi bài thuyết trình thành tệp PPTX. 

Mã mẫu này trong C++—một triển khai các bước trên—cho bạn thấy cách áp dụng hiệu ứng bóng ngoài cho văn bản:

``` cpp
auto pres = System::MakeObject<Presentation>();
// Lấy tham chiếu của slide
auto sld = pres->get_Slides()->idx_get(0);

// Thêm một AutoShape loại Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Thêm TextFrame vào Rectangle
ashp->AddTextFrame(u"Aspose TextBox");

// Vô hiệu hoá việc tô màu hình dạng nếu muốn tạo bóng cho văn bản
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Thêm bóng ngoài và đặt tất cả các tham số cần thiết
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// Ghi bản trình chiếu ra đĩa
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```

## **Áp dụng hiệu ứng bóng trong cho hình dạng**
Thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation). 
2. Lấy tham chiếu của slide. 
3. Thêm một AutoShape loại Rectangle. 
4. Bật InnerShadowEffect. 
5. Đặt tất cả các tham số cần thiết. 
6. Đặt ColorType là Scheme. 
7. Đặt Scheme Color. 
8. Ghi bài thuyết trình thành tệp [PPTX](https://docs.fileformat.com/presentation/pptx/). 

Mã mẫu này (dựa trên các bước trên) cho bạn thấy cách thêm một connector giữa hai hình dạng trong C++:

``` cpp
auto presentation = System::MakeObject<Presentation>();
// Lấy tham chiếu của một slide
auto slide = presentation->get_Slides()->idx_get(0);

// Thêm một AutoShape loại Rectangle
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Thêm TextFrame vào Rectangle
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// Kích hoạt InnerShadowEffect
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// Đặt tất cả các tham số cần thiết
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// Đặt ColorType thành Scheme
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Đặt Scheme Color
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// Lưu bản trình chiếu
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Có thể sử dụng hiệu ứng WordArt với các phông chữ hoặc script khác nhau (ví dụ: Ả Rập, Trung Quốc) không?**

Có, Aspose.Slides hỗ trợ Unicode và hoạt động với mọi phông chữ và script chính. Các hiệu ứng WordArt như bóng, nền và viền có thể được áp dụng bất kể ngôn ngữ, mặc dù việc có sẵn phông và khả năng hiển thị có thể phụ thuộc vào phông hệ thống.

**Có thể áp dụng hiệu ứng WordArt cho các yếu tố trong slide master không?**

Có, bạn có thể áp dụng hiệu ứng WordArt cho các hình dạng trên slide master, bao gồm các placeholder tiêu đề, chân trang hoặc văn bản nền. Các thay đổi trên bố cục master sẽ được phản ánh trên tất cả các slide liên quan.

**Hiệu ứng WordArt có ảnh hưởng đến kích thước tệp trình chiếu không?**

Một chút. Các hiệu ứng WordArt như bóng, glow và gradient có thể làm tăng nhẹ kích thước tệp do thêm siêu dữ liệu định dạng, nhưng sự khác biệt thường không đáng kể.

**Có thể xem trước kết quả của hiệu ứng WordArt mà không lưu bài thuyết trình không?**

Có, bạn có thể render các slide chứa WordArt thành hình ảnh (ví dụ: PNG, JPEG) bằng phương thức `GetImage` từ giao diện [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/) hoặc [ISlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/). Điều này cho phép bạn xem trước kết quả trong bộ nhớ hoặc trên màn hình trước khi lưu hoặc xuất bản thuyết trình đầy đủ.