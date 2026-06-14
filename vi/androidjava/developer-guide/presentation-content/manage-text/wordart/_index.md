---
title: Tạo và Áp dụng hiệu ứng WordArt trên Android
linktitle: WordArt
type: docs
weight: 110
url: /vi/androidjava/wordart/
keywords:
- WordArt
- tạo WordArt
- mẫu WordArt
- hiệu ứng WordArt
- hiệu ứng bóng đổ
- hiệu ứng phản chiếu
- hiệu ứng phát sáng
- biến đổi WordArt
- hiệu ứng 3D
- hiệu ứng bóng đổ ngoài
- hiệu ứng bóng đổ trong
- PowerPoint
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Tạo và tùy chỉnh các hiệu ứng WordArt trong Aspose.Slides cho Android. Hướng dẫn từng bước này giúp các nhà phát triển nâng cao bản trình bày với văn bản chuyên nghiệp trong Java."
---
## **Tổng quan**

Hiệu ứng WordArt cho phép bạn thêm văn bản có kiểu dáng bắt mắt, được chỉnh sửa thành hình ảnh vào các bản trình bày PowerPoint. Với Aspose.Slides, các nhà phát triển có thể tạo, tùy chỉnh và quản lý WordArt một cách lập trình, giống như trong Microsoft PowerPoint—không cần cài đặt Office. Bài viết này cung cấp cái nhìn tổng quan về cách làm việc với WordArt, bao gồm cách áp dụng biến đổi văn bản, kiểu tô màu, viền, bóng đổ và các tùy chọn định dạng khác để làm cho nội dung bản trình bày trở nên sinh động và hấp dẫn hơn. WordArt cho phép bạn xử lý văn bản như một đối tượng đồ họa. Nó bao gồm các hiệu ứng hoặc chỉnh sửa đặc biệt được áp dụng lên văn bản để làm cho nó thu hút hoặc nổi bật hơn.

## **Tạo mẫu WordArt đơn giản và áp dụng cho văn bản**

**Sử dụng Aspose.Slides** 

Đầu tiên, chúng ta tạo một đoạn văn bản đơn giản bằng đoạn mã Java sau: 

``` java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) pres.dispose();
}
```
Tiếp theo, chúng ta đặt chiều cao phông chữ của văn bản lên giá trị lớn hơn để làm cho hiệu ứng dễ nhận thấy hơn bằng đoạn mã này:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Sử dụng Microsoft PowerPoint**

Mở menu hiệu ứng WordArt trong Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Từ menu bên phải, bạn có thể chọn một hiệu ứng WordArt đã định sẵn. Từ menu bên trái, bạn có thể chỉ định các cài đặt cho một WordArt mới. 

Đây là một số tham số hoặc tùy chọn có sẵn:

![todo:image_alt_text](image-20200930114015-3.png)

**Sử dụng Aspose.Slides**

Ở đây, chúng ta áp dụng màu mẫu [SmallGrid](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/PatternStyle#SmallGrid) cho văn bản và thêm một viền văn bản đen độ rộng 1 bằng đoạn mã sau:

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

Văn bản kết quả:

![todo:image_alt_text](image-20200930114108-4.png)

## **Áp dụng các hiệu ứng WordArt khác**

**Sử dụng Microsoft PowerPoint**

Từ giao diện chương trình, bạn có thể áp dụng những hiệu ứng này cho văn bản, khối văn bản, hình dạng hoặc các thành phần tương tự:

![todo:image_alt_text](image-20200930114129-5.png)

Ví dụ, các hiệu ứng Shadow, Reflection và Glow có thể được áp dụng cho văn bản; các hiệu ứng 3D Format và 3D Rotation có thể được áp dụng cho một khối văn bản; thuộc tính Soft Edges có thể được áp dụng cho một Shape Object (nó vẫn có hiệu ứng khi không thiết lập thuộc tính 3D Format). 

### **Áp dụng hiệu ứng bóng đổ (Shadow)**

Ở đây, chúng ta chỉ định các thuộc tính liên quan đến một đoạn văn bản. Chúng ta áp dụng hiệu ứng bóng đổ cho văn bản bằng đoạn mã Java sau:

``` java
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
```

API Aspose.Slides hỗ trợ ba loại bóng đổ: OuterShadow, InnerShadow và PresetShadow. 

Với PresetShadow, bạn có thể áp dụng bóng đổ cho văn bản (bằng các giá trị đã định sẵn). 

**Sử dụng Microsoft PowerPoint**

Trong PowerPoint, bạn chỉ có thể sử dụng một loại bóng đổ. Đây là một ví dụ:

![todo:image_alt_text](image-20200930114225-6.png)

**Sử dụng Aspose.Slides**

Aspose.Slides thực tế cho phép bạn áp dụng đồng thời hai loại bóng đổ: InnerShadow và PresetShadow.

**Lưu ý:**

- Khi OuterShadow và PresetShadow được dùng cùng nhau, chỉ hiệu ứng OuterShadow được áp dụng. 
- Nếu OuterShadow và InnerShadow được sử dụng đồng thời, hiệu ứng được áp dụng phụ thuộc vào phiên bản PowerPoint. Ví dụ, trong PowerPoint 2013, hiệu ứng sẽ được nhân đôi. Nhưng trong PowerPoint 2007, hiệu ứng OuterShadow sẽ được áp dụng. 

### **Áp dụng hiệu ứng phản chiếu (Reflection) cho Văn bản**

Chúng ta thêm hiệu ứng phản chiếu cho văn bản bằng đoạn mã Java sau:

``` java
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);   
```

### **Áp dụng hiệu ứng phát sáng (Glow) cho Văn bản**

Chúng ta áp dụng hiệu ứng glow cho văn bản để nó tỏa sáng hoặc nổi bật bằng đoạn mã sau:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Kết quả thực hiện:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Bạn có thể thay đổi các tham số cho bóng đổ, phản chiếu và glow. Thuộc tính của các hiệu ứng được đặt riêng cho từng phần của văn bản. 

{{% /alert %}} 

### **Sử dụng biến đổi (Transformations) trong WordArt**

Chúng ta sử dụng thuộc tính Transform (áp dụng cho toàn bộ khối văn bản) bằng đoạn mã này:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

Kết quả:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Cả Microsoft PowerPoint và Aspose.Slides cho Android qua Java đều cung cấp một số loại biến đổi đã được định sẵn.

{{% /alert %}} 

**Sử dụng PowerPoint**

Để truy cập các loại biến đổi đã định sẵn, thực hiện: **Format** → **TextEffect** → **Transform**

**Sử dụng Aspose.Slides**

Để chọn một loại biến đổi, sử dụng enum TextShapeType. 

### **Áp dụng hiệu ứng 3D cho Văn bản và Hình dạng**

Chúng ta đặt một hiệu ứng 3D cho một hình dạng văn bản bằng đoạn mã mẫu sau:

``` java
autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);

autoShape.getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
autoShape.getThreeDFormat().setExtrusionHeight(6);

autoShape.getThreeDFormat().getContourColor().setColor(Color.RED);
autoShape.getThreeDFormat().setContourWidth(1.5);

autoShape.getThreeDFormat().setDepth(3);

autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

Văn bản và hình dạng kết quả:

![todo:image_alt_text](image-20200930114816-9.png)

Chúng ta áp dụng hiệu ứng 3D cho văn bản bằng đoạn mã Java sau:

``` java
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(Color.RED);
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

Kết quả thực hiện:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Việc áp dụng các hiệu ứng 3D cho văn bản hoặc hình dạng và tương tác giữa các hiệu ứng dựa trên một số quy tắc. 

Xem xét một cảnh cho văn bản và hình dạng chứa văn bản đó. Hiệu ứng 3D bao gồm biểu diễn đối tượng 3D và cảnh mà đối tượng được đặt lên. 

- Khi cảnh được đặt cho cả hình và văn bản, cảnh của hình sẽ có độ ưu tiên cao hơn—cảnh của văn bản sẽ bị bỏ qua. 
- Khi hình không có cảnh riêng nhưng có biểu diễn 3D, cảnh của văn bản sẽ được sử dụng. 
- Ngược lại—khi hình ban đầu không có hiệu ứng 3D—hình sẽ phẳng và hiệu ứng 3D chỉ được áp dụng cho văn bản. 

Các mô tả này liên quan đến các phương thức ThreeDFormat.getLightRig() và ThreeDFormat.getCamera().

{{% /alert %}} 

## **Áp dụng hiệu ứng Outer Shadow cho Văn bản**
Aspose.Slides cho Android qua Java cung cấp các lớp [**IOuterShadow**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ioutershadow/) và [**IInnerShadow**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iinnershadow/) cho phép bạn áp dụng hiệu ứng bóng đổ cho văn bản được chứa trong [TextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textframe/). Thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).  
2. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.  
3. Thêm một AutoShape kiểu Rectangle vào slide.  
4. Truy cập TextFrame liên quan đến AutoShape.  
5. Đặt FillType của AutoShape thành NoFill.  
6. Khởi tạo lớp OuterShadow.  
7. Đặt BlurRadius cho bóng đổ.  
8. Đặt Direction cho bóng đổ.  
9. Đặt Distance cho bóng đổ.  
10. Đặt RectanglelAlign thành TopLeft.  
11. Đặt PresetColor của bóng đổ thành Black.  
12. Ghi bản trình bày dưới dạng tệp [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Đoạn mã mẫu Java—thực hiện các bước trên—cho bạn thấy cách áp dụng hiệu ứng Outer Shadow cho văn bản:

```java
Presentation pres = new Presentation();
try {
    // Lấy tham chiếu của slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Thêm một AutoShape kiểu Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Thêm TextFrame vào hình chữ nhật
    ashp.addTextFrame("Aspose TextBox");

    // Vô hiệu hoá việc tô màu hình dạng trong trường hợp chúng ta muốn tạo bóng cho văn bản
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Thêm bóng đổ ngoài và đặt tất cả các tham số cần thiết
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //Ghi bản trình bày ra đĩa
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Áp dụng hiệu ứng Inner Shadow cho Hình dạng**
Thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).  
2. Lấy tham chiếu của slide.  
3. Thêm một AutoShape kiểu Rectangle.  
4. Bật InnerShadowEffect.  
5. Đặt tất cả các tham số cần thiết.  
6. Đặt ColorType thành Scheme.  
7. Đặt Scheme Color.  
8. Ghi bản trình bày dưới dạng tệp [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Đoạn mã mẫu (dựa trên các bước trên) cho bạn thấy cách thêm một connector giữa hai hình dạng trong Java:

```java
Presentation pres = new Presentation();
try {
    // Lấy tham chiếu của slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Thêm một AutoShape kiểu Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Thêm TextFrame vào hình chữ nhật
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Bật InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Đặt tất cả các tham số cần thiết
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Đặt ColorType là Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Đặt Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Lưu bản trình bày
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể sử dụng hiệu ứng WordArt với các phông chữ hoặc script khác nhau (ví dụ: Arabic, Chinese) không?**

Có, Aspose.Slides hỗ trợ Unicode và hoạt động với tất cả các phông chữ và script chính. Các hiệu ứng WordArt như bóng đổ, tô màu và viền có thể được áp dụng bất kể ngôn ngữ, mặc dù việc có sẵn và hiển thị phông chữ có thể phụ thuộc vào phông chữ hệ thống.

**Tôi có thể áp dụng hiệu ứng WordArt cho các yếu tố của slide master không?**

Có, bạn có thể áp dụng hiệu ứng WordArt cho các hình dạng trên master slide, bao gồm các placeholder tiêu đề, chân trang hoặc văn bản nền. Các thay đổi trên bố cục master sẽ được phản ánh trên tất cả các slide liên quan.

**Hiệu ứng WordArt có ảnh hưởng đến kích thước tệp bản trình bày không?**

Có chút ảnh hưởng. Các hiệu ứng WordArt như bóng đổ, glow và gradient fill có thể làm tăng nhẹ kích thước tệp do thêm siêu dữ liệu định dạng, nhưng sự chênh lệch thường không đáng kể.

**Tôi có thể xem trước kết quả của hiệu ứng WordArt mà không lưu bản trình bày không?**

Có, bạn có thể render các slide chứa WordArt thành hình ảnh (ví dụ: PNG, JPEG) bằng phương thức `getImage` từ các giao diện [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/) hoặc [ISlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/). Điều này cho phép bạn xem trước kết quả trong bộ nhớ hoặc trên màn hình trước khi lưu hoặc xuất bản trình bày đầy đủ.