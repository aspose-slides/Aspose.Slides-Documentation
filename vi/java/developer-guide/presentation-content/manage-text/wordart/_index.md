---
title: Tạo và Áp dụng Hiệu ứng WordArt trong Java
linktitle: WordArt
type: docs
weight: 110
url: /vi/java/wordart/
keywords:
- WordArt
- tạo WordArt
- mẫu WordArt
- hiệu ứng WordArt
- hiệu ứng bóng
- hiệu ứng phản chiếu
- hiệu ứng phát sáng
- biến dạng WordArt
- hiệu ứng 3D
- hiệu ứng bóng ngoài
- hiệu ứng bóng trong
- Java
- Aspose.Slides
description: "Tạo và tùy chỉnh các hiệu ứng WordArt trong Aspose.Slides cho Java. Hướng dẫn từng bước này giúp các nhà phát triển nâng cao bản thuyết trình với văn bản chuyên nghiệp trong Java."
---
## **Tổng quan**

Hiệu ứng WordArt cho phép bạn định dạng văn bản với các loại đổ màu, viền, bóng, phản chiếu, phát sáng, biến dạng và định dạng 3D. Bài viết này giải thích cách tạo và tùy chỉnh các hiệu ứng này trong bản thuyết trình PowerPoint bằng Aspose.Slides for Java, mà không cần cài đặt Microsoft Office.

## **Tạo mẫu WordArt đơn giản và áp dụng vào văn bản**

Các ví dụ dưới đây tạo một kiểu WordArt đơn giản bằng cách đặt văn bản, phông chữ, mẫu đổ màu và viền.

Mỗi ví dụ tạo một bản thuyết trình mới và thêm một hình chữ nhật vào slide đầu tiên; không cần tệp đầu vào. Ví dụ đầu tiên đặt văn bản là "Aspose.Slides". Vị trí và kích thước của hình được đo bằng điểm:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

Đặt phông chữ thành Arial Black kích thước 36 điểm để định dạng nổi bật hơn:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

Áp dụng mẫu [SmallGrid](https://reference.aspose.com/slides/vi/java/com.aspose.slides/patternstyle/#SmallGrid) với màu nền trước cam đậm và nền trắng, sau đó thêm viền văn bản màu đen dày 1 điểm:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color darkOrange = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    presentation.dispose();
}
```

Văn bản kết quả:

![The simple WordArt template](WordArt_template.png)

## **Áp dụng các hiệu ứng WordArt khác**

Các ví dụ sau minh họa cách áp dụng bóng, phản chiếu, phát sáng, biến dạng và hiệu ứng 3D cho văn bản.

### **Áp dụng hiệu ứng bóng ngoài**

Bóng ngoài tạo độ sâu bằng cách đặt bóng phía sau văn bản. Bạn có thể tùy chỉnh màu, hướng, khoảng cách, bán kính làm mờ, tỷ lệ và độ nghiêng.

Ví dụ này gọi [enableOuterShadowEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/effectformat/#enableOuterShadowEffect--) và đặt bóng màu đen với bán kính làm mờ 4 điểm, hướng 230 độ và khoảng cách 30 điểm. Giá trị tỷ lệ 100 giữ nguyên kích thước bóng, trong khi độ nghiêng ngang nghiêng bóng 20 độ. Biến đổi alpha đặt độ trong suốt là 32%:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    presentation.dispose();
}
```

Văn bản kết quả:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}

- Khi bóng ngoài và bóng đã định trước được sử dụng cùng nhau, chỉ bóng ngoài được áp dụng.
- Nếu bóng ngoài và bóng trong được sử dụng đồng thời, hiệu ứng kết quả phụ thuộc vào phiên bản PowerPoint. Ví dụ, trong PowerPoint 2013, hiệu ứng được nhân đôi, trong khi trong PowerPoint 2007, chỉ bóng ngoài được áp dụng.

{{% /alert %}}

### **Áp dụng hiệu ứng phản chiếu**

Phản chiếu tạo một bản sao gương của văn bản. Điều chỉnh vị trí, tỷ lệ, độ mờ và độ trong suốt để kiểm soát ngoại hình.

Ví dụ này gọi [enableReflectionEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/effectformat/#enableReflectionEffect--) và lật phản chiếu theo chiều dọc với tỷ lệ -100%. Nó sử dụng bán kính làm mờ 0.5 điểm và khoảng cách 4.72 điểm. Độ trong suốt giảm từ 60% xuống 0.9% giữa các vị trí 0% và 60% dọc theo phản chiếu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

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
    presentation.dispose();
}
```

Văn bản kết quả:

![The Reflection effect](reflection_effect.png)

### **Áp dụng hiệu ứng phát sáng**

Phát sáng thêm một viền màu nhẹ quanh văn bản. Điều chỉnh màu, độ trong suốt và bán kính để kiểm soát hiệu ứng.

Ví dụ này gọi [enableGlowEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/effectformat/#enableGlowEffect--) và áp dụng phát sáng màu đỏ với độ trong suốt 54% và bán kính 7 điểm:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

Văn bản kết quả:

![The Glow effect](glow_effect.png)

### **Áp dụng biến dạng WordArt**

Biến dạng WordArt làm cong, kéo dài hoặc uốn một khối văn bản.

Đặt [setTransform](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textframeformat/#setTransform-int-) thành [ArchUpPour](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textshapetype/#ArchUpPour) để uốn khung văn bản lên phía trên:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    presentation.dispose();
}
```

Văn bản kết quả:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}

Aspose.Slides for Java cung cấp một tập hợp các [loại biến dạng](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textshapetype/) được định trước.

{{% /alert %}}

### **Áp dụng hiệu ứng 3D cho hình dạng và văn bản**

Bạn có thể áp dụng hiệu ứng 3D cho một hình dạng hoặc cho văn bản của nó. Các góc cạnh, đùn, ánh sáng và thiết lập máy ảnh kiểm soát ngoại hình cuối cùng.

Ví dụ dưới đây sử dụng [ThreeDFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/threedformat/) để thêm các góc cạnh tròn, đùn màu cam và đường viền đỏ đậm cho hình chữ nhật. Kích thước góc cạnh, chiều cao đùn, độ rộng viền và độ sâu đều đo bằng điểm. Vật liệu nhựa, ánh sáng cân bằng xoay 40 độ quanh trục Z và máy ảnh phối cảnh xác định ngoại hình:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    Color orange = new Color(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Hình dạng kết quả:

![The shape 3D effect](shape_3D_effect.png)

Ví dụ này áp dụng định dạng 3D tương tự cho văn bản thông qua [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textframeformat/#getThreeDFormat--). Các góc cạnh nhỏ hơn định hình cạnh chữ, trong khi đùn và ánh sáng tạo độ sâu cho văn bản:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    Color orange = new Color(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Văn bản kết quả:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}

Việc áp dụng hiệu ứng 3D cho văn bản hoặc hình dạng của chúng—và sự tương tác giữa các hiệu ứng này—được quy định bởi các quy tắc cụ thể. Xem xét một cảnh bao gồm cả văn bản và hình dạng chứa nó. Một hiệu ứng 3D bao gồm biểu diễn 3D của đối tượng và cảnh mà nó được đặt.

- Nếu một cảnh được đặt cho cả hình dạng và văn bản, cảnh của hình dạng sẽ được ưu tiên và cảnh của văn bản sẽ bị bỏ qua.
- Nếu hình dạng không có cảnh riêng nhưng có biểu diễn 3D, cảnh của văn bản sẽ được sử dụng.
- Nếu hình dạng không có bất kỳ hiệu ứng 3D nào, nó được xử lý như phẳng và hiệu ứng 3D chỉ được áp dụng cho văn bản.

Các hành vi này liên quan đến các phương thức [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/vi/java/com.aspose.slides/threedformat/#getLightRig--) và [ThreeDFormat.getCamera](https://reference.aspose.com/slides/vi/java/com.aspose.slides/threedformat/#getCamera--).

{{% /alert %}}

Để giữ văn bản phẳng và dễ đọc trong khi vẫn giữ định dạng 3D của hình dạng, xem [Keep Text Flat on a 3D Shape](/slides/vi/java/3d-presentation/) để so sánh cả hai cài đặt và một ví dụ Java đầy đủ.

## **Câu hỏi thường gặp**

**Tôi có thể sử dụng hiệu ứng WordArt với các phông chữ hoặc kịch bản khác nhau (ví dụ: Ả Rập, Trung Quốc) không?**

Có, Aspose.Slides for Java hỗ trợ Unicode và hoạt động với tất cả các phông chữ và kịch bản chính. Các hiệu ứng WordArt như bóng, đổ màu và viền có thể được áp dụng bất kể ngôn ngữ, mặc dù tính khả dụng và việc hiển thị phông chữ có thể phụ thuộc vào phông chữ hệ thống.

**Tôi có thể áp dụng hiệu ứng WordArt cho các yếu tố trong master slide không?**

Có, bạn có thể áp dụng hiệu ứng WordArt cho các hình dạng trên slide master, bao gồm các trình giữ chỗ tiêu đề, chân trang hoặc văn bản nền. Các thay đổi trên bố cục master sẽ được phản ánh trên tất cả các slide liên quan.

**Hiệu ứng WordArt có ảnh hưởng đến kích thước tập tin bản thuyết trình không?**

Có phần. Các hiệu ứng WordArt như bóng, phát sáng và đổ màu gradient có thể làm tăng nhẹ kích thước tập tin do thêm metadata định dạng, nhưng sự khác biệt thường không đáng kể.

**Tôi có thể xem trước kết quả của hiệu ứng WordArt mà không lưu bản thuyết trình không?**

Có, bạn có thể render các slide chứa WordArt thành hình ảnh (ví dụ: PNG, JPEG) bằng [ISlide.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/#getImage--), hoặc render các hình dạng riêng lẻ bằng [IShape.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getImage--). Điều này cho phép bạn xem trước kết quả trong bộ nhớ hoặc trên màn hình trước khi lưu hoặc xuất bản thuyết trình đầy đủ.