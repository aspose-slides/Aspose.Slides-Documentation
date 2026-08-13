---
title: Tạo và áp dụng hiệu ứng WordArt trên Android
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
- hiệu ứng hiển thị
- hiệu ứng glow
- biến đổi WordArt
- hiệu ứng 3D
- hiệu ứng bóng đổ ngoài
- hiệu ứng bóng đổ nội
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tạo và tùy chỉnh hiệu ứng WordArt trong Aspose.Slides cho Android. Hướng dẫn từng bước này giúp các nhà phát triển nâng cao bản trình chiếu với văn bản chuyên nghiệp bằng Java."
---
## **Tổng quan**

Hiệu ứng WordArt cho phép bạn thêm văn bản có kiểu dáng hấp dẫn, được cách điệu vào các bản thuyết trình PowerPoint. Với Aspose.Slides, các nhà phát triển có thể tạo, tùy chỉnh và quản lý WordArt một cách lập trình, giống như trong Microsoft PowerPoint—không cần cài đặt Office. Bài viết này cung cấp tổng quan về cách làm việc với WordArt, bao gồm cách áp dụng các biến đổi văn bản, kiểu tô màu, đường viền, bóng đổ và các tùy chọn định dạng khác để làm cho nội dung bản thuyết trình của bạn trở nên sinh động và hấp dẫn hơn. WordArt cho phép bạn coi văn bản như một đối tượng đồ họa. Nó bao gồm các hiệu ứng hoặc các sửa đổi đặc biệt được áp dụng lên văn bản để làm cho nó hấp dẫn hoặc dễ chú ý hơn.

## **Tạo mẫu WordArt đơn giản và áp dụng nó vào văn bản**

**Sử dụng Aspose.Slides** 

Đầu tiên, chúng ta tạo một văn bản đơn giản bằng đoạn mã Java sau: 

``` java
import com.aspose.slides.*;

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
Bây giờ, chúng ta đặt độ cao phông chữ của văn bản lên giá trị lớn hơn để hiệu ứng trở nên rõ nét hơn thông qua đoạn mã này:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}

```

**Sử dụng Microsoft PowerPoint**

Đi tới menu hiệu ứng WordArt trong Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Từ menu bên phải, bạn có thể chọn một hiệu ứng WordArt được định sẵn. Từ menu bên trái, bạn có thể chỉ định các thiết lập cho một WordArt mới. 

Đây là một số tham số hoặc tùy chọn có sẵn:

![todo:image_alt_text](image-20200930114015-3.png)

**Sử dụng Aspose.Slides**

Ở đây, chúng ta áp dụng màu mẫu [SmallGrid](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/PatternStyle#SmallGrid) vào văn bản và thêm một đường viền văn bản màu đen dày 1 thông qua đoạn mã này:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    if (pres != null) pres.dispose();
}

```

Văn bản sau khi áp dụng:

![todo:image_alt_text](image-20200930114108-4.png)

## **Áp dụng các hiệu ứng WordArt khác**

**Sử dụng Microsoft PowerPoint**

Từ giao diện chương trình, bạn có thể áp dụng các hiệu ứng này cho văn bản, khối văn bản, hình dạng hoặc các thành phần tương tự:

![todo:image_alt_text](image-20200930114129-5.png)

Ví dụ, các hiệu ứng Bóng đổ, Phản chiếu và Glow có thể được áp dụng cho văn bản; các hiệu ứng Định dạng 3D và Xoay 3D có thể được áp dụng cho khối văn bản; thuộc tính Cạnh mềm có thể được áp dụng cho Đối tượng Hình (nó vẫn có hiệu ứng khi không đặt thuộc tính Định dạng 3D). 

### **Áp dụng hiệu ứng Bóng đổ**

Ở đây, chúng ta chỉ định các thuộc tính liên quan tới một đoạn văn bản. Chúng ta áp dụng hiệu ứng bóng đổ cho văn bản bằng đoạn mã Java sau:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

API Aspose.Slides hỗ trợ ba loại bóng đổ: OuterShadow, InnerShadow và PresetShadow. 

Với PresetShadow, bạn có thể áp dụng một bóng đổ cho văn bản (sử dụng các giá trị đã định sẵn). 

**Sử dụng Microsoft PowerPoint**

Trong PowerPoint, bạn chỉ có thể sử dụng một loại bóng đổ. Đây là một ví dụ:

![todo:image_alt_text](image-20200930114225-6.png)

**Sử dụng Aspose.Slides**

Aspose.Slides thực sự cho phép bạn áp dụng đồng thời hai loại bóng đổ: InnerShadow và PresetShadow.

**Lưu ý:**

- Khi OuterShadow và PresetShadow được sử dụng cùng nhau, chỉ hiệu ứng OuterShadow được áp dụng. 
- Nếu OuterShadow và InnerShadow được dùng đồng thời, hiệu ứng nhận được hoặc được áp dụng phụ thuộc vào phiên bản PowerPoint. Ví dụ, trong PowerPoint 2013, hiệu ứng sẽ được nhân đôi. Nhưng trong PowerPoint 2007, hiệu ứng OuterShadow sẽ được áp dụng. 

### **Áp dụng hiệu ứng Phản chiếu cho Văn bản**

Chúng ta thêm hiệu ứng phản chiếu vào văn bản bằng đoạn mã mẫu Java này:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

### **Áp dụng hiệu ứng Glow cho Văn bản**

Chúng ta áp dụng hiệu ứng glow cho văn bản để làm nó sáng hoặc nổi bật bằng đoạn mã này:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

Kết quả của thao tác:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 

Bạn có thể thay đổi các tham số cho bóng đổ, phản chiếu và glow. Các thuộc tính của hiệu ứng được thiết lập riêng cho từng phần của văn bản. 

{{% /alert %}} 

### **Sử dụng Biến đổi trong WordArt**

Chúng ta sử dụng thuộc tính Transform (áp dụng cho toàn bộ khối văn bản) qua đoạn mã này:
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    if (pres != null) pres.dispose();
}

```

Kết quả:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 

Cả Microsoft PowerPoint và Aspose.Slides cho Android qua Java đều cung cấp một số loại biến đổi được định sẵn.

{{% /alert %}} 

**Sử dụng PowerPoint**

Để truy cập các loại biến đổi được định sẵn, vào: **Format** -> **TextEffect** -> **Transform**

**Sử dụng Aspose.Slides**

Để chọn một loại biến đổi, hãy sử dụng enum TextShapeType. 

### **Áp dụng hiệu ứng 3D cho Văn bản và Hình dạng**

Chúng ta đặt hiệu ứng 3D cho một hình dạng văn bản bằng đoạn mã mẫu này:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

Văn bản và hình dạng sau khi áp dụng:

![todo:image_alt_text](image-20200930114816-9.png)

Chúng ta áp dụng hiệu ứng 3D cho văn bản bằng đoạn mã Java này:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

Kết quả của thao tác:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 

Việc áp dụng hiệu ứng 3D cho văn bản hoặc các hình dạng và sự tương tác giữa các hiệu ứng dựa trên một số quy tắc nhất định. 

Hãy xem xét một cảnh cho văn bản và hình dạng chứa văn bản đó. Hiệu ứng 3D bao gồm việc biểu diễn đối tượng 3D và cảnh mà đối tượng được đặt lên. 

- Khi cảnh được đặt cho cả hình và văn bản, cảnh của hình được ưu tiên cao hơn—cảnh của văn bản sẽ bị bỏ qua. 
- Khi hình không có cảnh riêng nhưng có biểu diễn 3D, cảnh của văn bản sẽ được sử dụng. 
- Ngược lại—khi hình ban đầu không có hiệu ứng 3D—hình sẽ phẳng và hiệu ứng 3D chỉ được áp dụng cho văn bản. 

Các mô tả này liên quan đến các phương thức ThreeDFormat.getLightRig() và ThreeDFormat.getCamera().

{{% /alert %}} 

## **Áp dụng hiệu ứng Bóng đổ Ngoài cho Văn bản**
Aspose.Slides cho Android qua Java cung cấp các lớp [**IOuterShadow**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ioutershadow/) và [**IInnerShadow**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iinnershadow/) cho phép bạn áp dụng hiệu ứng bóng đổ cho văn bản được chứa trong [TextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textframe/). Thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation). 
2. Lấy tham chiếu đến một slide bằng cách sử dụng chỉ mục của nó. 
3. Thêm một AutoShape loại Rectangle vào slide. 
4. Truy cập TextFrame được liên kết với AutoShape. 
5. Đặt FillType của AutoShape thành NoFill. 
6. Khởi tạo lớp OuterShadow 
7. Đặt BlurRadius cho bóng đổ. 
8. Đặt Direction cho bóng đổ 
9. Đặt Distance cho bóng đổ. 
10. Đặt RectangleAlign thành TopLeft. 
11. Đặt PresetColor của bóng đổ thành Black. 
12. Ghi bản trình chiếu dưới dạng tệp [PPTX](https://docs.fileformat.com/presentation/pptx/). 

Đoạn mã mẫu này bằng Java—một triển khai của các bước trên—cho bạn thấy cách áp dụng hiệu ứng bóng đổ ngoài cho văn bản:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Lấy tham chiếu của slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Thêm một AutoShape loại Hình chữ nhật
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Thêm TextFrame vào Hình chữ nhật
    ashp.addTextFrame("Aspose TextBox");

    // Vô hiệu hoá việc tô màu hình dạng trong trường hợp chúng ta muốn lấy bóng đổ của văn bản
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Thêm bóng đổ ngoài và thiết lập tất cả các tham số cần thiết
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // Ghi bản trình chiếu ra đĩa
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Áp dụng hiệu ứng Bóng đổ Nội cho Hình dạng**
Thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation). 
2. Lấy tham chiếu đến slide. 
3. Thêm một AutoShape loại Rectangle. 
4. Bật InnerShadowEffect. 
5. Đặt tất cả các tham số cần thiết. 
6. Đặt ColorType thành Scheme. 
7. Đặt Scheme Color. 
8. Ghi bản trình chiếu dưới dạng tệp [PPTX](https://docs.fileformat.com/presentation/pptx/). 

Đoạn mã mẫu (dựa trên các bước trên) cho bạn thấy cách áp dụng hiệu ứng bóng đổ nội cho văn bản trong Java:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Lấy tham chiếu của slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Thêm một AutoShape loại Hình chữ nhật
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Thêm TextFrame vào Hình chữ nhật
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Bật InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Thiết lập tất cả các tham số cần thiết
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Đặt ColorType thành Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Đặt màu Scheme
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Lưu bản trình chiếu
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

### Có thể sử dụng hiệu ứng WordArt với các phông chữ hoặc ký tự khác nhau (ví dụ: Arabic, Chinese) không?

Có, Aspose.Slides hỗ trợ Unicode và hoạt động với mọi phông chữ và ký tự chính. Các hiệu ứng WordArt như bóng đổ, tô đầy và đường viền có thể được áp dụng bất kể ngôn ngữ, mặc dù việc có sẵn và hiển thị phông chữ có thể phụ thuộc vào phông chữ hệ thống.

### Có thể áp dụng hiệu ứng WordArt cho các thành phần master slide không?

Có, bạn có thể áp dụng hiệu ứng WordArt cho các hình dạng trên master slide, bao gồm các trình giữ chỗ tiêu đề, chân trang hoặc văn bản nền. Các thay đổi trên bố cục master sẽ được phản ánh trên tất cả các slide liên quan.

### Các hiệu ứng WordArt có ảnh hưởng đến kích thước tệp trình chiếu không?

Hơi tăng. Các hiệu ứng WordArt như bóng đổ, glow và gradient fill có thể làm tăng nhẹ kích thước tệp do thêm siêu dữ liệu định dạng, nhưng chênh lệch thường không đáng kể.

### Có thể xem trước kết quả của các hiệu ứng WordArt mà không lưu bản trình chiếu không?

Có, bạn có thể render các slide có chứa WordArt thành ảnh (ví dụ: PNG, JPEG) bằng phương thức `getImage` từ các giao diện [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/) hoặc [ISlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/). Điều này cho phép bạn xem trước kết quả trong bộ nhớ hoặc trên màn hình trước khi lưu hoặc xuất toàn bộ bản trình chiếu.