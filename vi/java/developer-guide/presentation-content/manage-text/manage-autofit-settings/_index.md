---
title: Nâng cao các bản trình chiếu của bạn với AutoFit trong Java
linktitle: Cài đặt Autofit
type: docs
weight: 30
url: /vi/java/manage-autofit-settings/
keywords:
- hộp văn bản
- tự động điều chỉnh
- không tự động điều chỉnh
- vừa văn bản
- thu nhỏ văn bản
- bọc văn bản
- thay đổi kích thước hình dạng
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý cài đặt AutoFit trong Aspose.Slides cho Java để tối ưu hiển thị văn bản trong các bản trình chiếu PowerPoint và OpenDocument của bạn và cải thiện khả năng đọc nội dung."
---
## **Giới thiệu**

Theo mặc định, khi bạn thêm một hộp văn bản, Microsoft PowerPoint sẽ sử dụng cài đặt **Resize shape to fix text** cho hộp văn bản — nó tự động thay đổi kích thước hộp văn bản để đảm bảo văn bản luôn vừa trong hộp.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Khi văn bản trong hộp văn bản dài hơn hoặc lớn hơn, PowerPoint sẽ tự động mở rộng hộp văn bản — tăng chiều cao — để chứa thêm văn bản.
* Khi văn bản trong hộp văn bản ngắn hơn hoặc nhỏ hơn, PowerPoint sẽ tự động giảm hộp văn bản — giảm chiều cao — để loại bỏ không gian dư thừa.

Trong PowerPoint, có 4 tham số hoặc tùy chọn quan trọng điều khiển hành vi autofit cho một hộp văn bản:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Java cung cấp các tùy chọn tương tự — một số thuộc tính trong lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/TextFrameFormat) — cho phép bạn điều khiển hành vi autofit cho các hộp văn bản trong bản trình chiếu.

## **Resize a Shape to Fit Text**

Nếu bạn muốn văn bản trong một hộp luôn vừa vào hộp sau khi thay đổi nội dung, bạn phải sử dụng tùy chọn **Resize shape to fix text**. Để chỉ định cài đặt này, đặt thuộc tính [AutofitType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/TextFrameFormat)) thành `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Mã Java dưới đây cho thấy cách chỉ định rằng văn bản phải luôn vừa vào hộp trong một bản trình chiếu PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Shape);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Nếu văn bản dài hơn hoặc lớn hơn, hộp văn bản sẽ tự động được thay đổi kích thước (tăng chiều cao) để đảm bảo toàn bộ văn bản vừa vào. Nếu văn bản ngắn hơn, quá trình ngược lại sẽ xảy ra.

## **Do Not Autofit**

Nếu bạn muốn một hộp văn bản hoặc hình dạng giữ nguyên kích thước bất kể thay đổi nào trong văn bản bên trong, bạn phải sử dụng tùy chọn **Do not Autofit**. Để chỉ định cài đặt này, đặt thuộc tính [AutofitType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/TextFrameFormat)) thành `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Mã Java dưới đây cho thấy cách chỉ định rằng một hộp văn bản phải luôn giữ nguyên kích thước trong một bản trình chiếu PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.None);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Khi văn bản trở nên quá dài so với hộp, nó sẽ tràn ra ngoài.

## **Shrink Text on Overflow**

Nếu văn bản trở nên quá dài so với hộp, thông qua tùy chọn **Shrink text on overflow**, bạn có thể chỉ định rằng kích thước và khoảng cách của văn bản phải được giảm để vừa vào hộp. Để chỉ định cài đặt này, đặt thuộc tính [AutofitType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/TextFrameFormat)) thành `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Mã Java dưới đây cho thấy cách chỉ định rằng văn bản phải được thu nhỏ khi tràn trong một bản trình chiếu PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Normal);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
Khi sử dụng tùy chọn **Shrink text on overflow**, cài đặt chỉ được áp dụng khi văn bản trở nên quá dài so với hộp.
{{% /alert %}}

## **Wrap Text**

Nếu bạn muốn văn bản trong một hình dạng được ngắt dòng bên trong hình dạng khi văn bản vượt quá biên của hình dạng (chỉ chiều rộng), bạn phải sử dụng tham số **Wrap text in shape**. Để chỉ định cài đặt này, bạn phải đặt thuộc tính [WrapText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/TextFrameFormat#getWrapText--) (từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/TextFrameFormat)) thành `true`.

Mã Java dưới đây cho thấy cách sử dụng cài đặt Wrap Text trong một bản trình chiếu PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(NullableBool.True);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Nếu bạn đặt thuộc tính `WrapText` thành `False` cho một hình dạng, khi văn bản bên trong hình dạng dài hơn chiều rộng của hình dạng, văn bản sẽ mở rộng ra ngoài biên của hình dạng trên một dòng duy nhất.
{{% /alert %}}

## **FAQ**

**Các lề nội bộ của khung văn bản có ảnh hưởng đến AutoFit không?**

Có. Padding (lề nội bộ) làm giảm diện tích sử dụng cho văn bản, vì vậy AutoFit sẽ kích hoạt sớm hơn — làm thu nhỏ phông chữ hoặc thay đổi kích thước hình dạng sớm hơn. Kiểm tra và điều chỉnh lề trước khi tinh chỉnh AutoFit.

**AutoFit tương tác như thế nào với các ngắt dòng thủ công và ngắt dòng mềm?**

Các ngắt dòng buộc vẫn giữ nguyên, và AutoFit điều chỉnh kích thước phông chữ và khoảng cách quanh chúng. Loại bỏ các ngắt không cần thiết thường giảm mức độ AutoFit phải thu nhỏ văn bản.

**Thay đổi phông chữ chủ đề hoặc kích hoạt thay thế phông chữ có ảnh hưởng đến kết quả AutoFit không?**

Có. Thay thế bằng phông chữ có các chỉ số glyph khác nhau sẽ thay đổi độ rộng/chiều cao của văn bản, có thể làm thay đổi kích thước phông chữ cuối cùng và cách ngắt dòng. Sau bất kỳ thay đổi hoặc thay thế phông chữ nào, hãy kiểm tra lại các slide.