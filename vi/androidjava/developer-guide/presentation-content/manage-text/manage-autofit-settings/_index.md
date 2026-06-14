---
title: Nâng cao bài thuyết trình của bạn với AutoFit trên Android
linktitle: Cài đặt Autofit
type: docs
weight: 30
url: /vi/androidjava/manage-autofit-settings/
keywords:
- hộp văn bản
- tự điều chỉnh kích thước
- không tự điều chỉnh kích thước
- vừa văn bản
- thu nhỏ văn bản
- bọc văn bản
- thay đổi kích thước hình
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Quản lý cài đặt AutoFit trong Aspose.Slides cho Android qua Java để tối ưu hiển thị văn bản trong các bài thuyết trình PowerPoint và OpenDocument và cải thiện khả năng đọc nội dung."
---
## **Giới thiệu**

Mặc định, khi bạn thêm một hộp văn bản, Microsoft PowerPoint sử dụng cài đặt **Resize shape to fix text** cho hộp văn bản — nó tự động thay đổi kích thước hộp văn bản để đảm bảo văn bản luôn vừa vào trong.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Khi văn bản trong hộp văn bản trở nên dài hơn hoặc lớn hơn, PowerPoint tự động phóng to hộp văn bản — tăng chiều cao — để chứa thêm văn bản.
* Khi văn bản trong hộp văn bản ngắn hơn hoặc nhỏ hơn, PowerPoint tự động thu nhỏ hộp văn bản — giảm chiều cao — để xóa bỏ không gian dư thừa.

Trong PowerPoint, có 4 tham số hoặc tùy chọn quan trọng kiểm soát hành vi tự điều chỉnh kích thước (autofit) cho hộp văn bản:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Android via Java cung cấp các tùy chọn tương tự — một số thuộc tính trong lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/TextFrameFormat) — cho phép bạn kiểm soát hành vi autofit cho các hộp văn bản trong bản trình bày.

## **Thay đổi kích thước hình để vừa với văn bản**

Nếu bạn muốn văn bản trong một hộp luôn vừa vào hộp sau khi thay đổi nội dung, bạn phải sử dụng tùy chọn **Resize shape to fix text**. Để chỉ định cài đặt này, đặt thuộc tính [AutofitType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/TextFrameFormat)) thành `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Đoạn mã Java sau cho thấy cách chỉ định rằng văn bản luôn phải vừa vào hộp trong một bản trình bày PowerPoint:

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

Nếu văn bản trở nên dài hơn hoặc lớn hơn, hộp văn bản sẽ tự động được thay đổi kích thước (tăng chiều cao) để đảm bảo toàn bộ văn bản vừa vào. Nếu văn bản ngắn hơn, quá trình ngược lại sẽ xảy ra.

## **Không tự điều chỉnh kích thước (Do Not Autofit)**

Nếu bạn muốn một hộp văn bản hoặc hình giữ nguyên kích thước bất kể có thay đổi gì trong văn bản bên trong, bạn phải sử dụng tùy chọn **Do not Autofit**. Để chỉ định cài đặt này, đặt thuộc tính [AutofitType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/TextFrameFormat)) thành `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Đoạn mã Java sau cho thấy cách chỉ định rằng một hộp văn bản luôn giữ nguyên kích thước trong một bản trình bày PowerPoint:

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

## **Thu nhỏ văn bản khi tràn (Shrink Text on Overflow)**

Nếu văn bản trở nên quá dài so với hộp, bằng tùy chọn **Shrink text on overflow**, bạn có thể chỉ định rằng kích thước và khoảng cách của văn bản phải được giảm để vừa vào hộp. Để chỉ định cài đặt này, đặt thuộc tính [AutofitType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/TextFrameFormat)) thành `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Đoạn mã Java sau cho thấy cách chỉ định rằng văn bản phải được thu nhỏ khi tràn trong một bản trình bày PowerPoint:

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
Khi sử dụng tùy chọn **Shrink text on overflow**, cài đặt chỉ được áp dụng khi văn bản thực sự quá dài so với hộp.
{{% /alert %}}

## **Bọc văn bản (Wrap Text)**

Nếu bạn muốn văn bản trong một hình được bọc bên trong hình khi văn bản vượt quá biên của hình (chỉ về chiều rộng), bạn phải sử dụng tham số **Wrap text in shape**. Để chỉ định cài đặt này, hãy đặt thuộc tính [WrapText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) (từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/TextFrameFormat)) thành `true`.

Đoạn mã Java sau cho thấy cách sử dụng cài đặt Wrap Text trong một bản trình bày PowerPoint:

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
Nếu bạn đặt thuộc tính `WrapText` thành `False` cho một hình, khi văn bản bên trong hình dài hơn chiều rộng của hình, văn bản sẽ kéo dài ra ngoài biên của hình trên một dòng duy nhất. 
{{% /alert %}}

## **Câu hỏi thường gặp**

**Các lề nội bộ của khung văn bản có ảnh hưởng đến AutoFit không?**

Có. Padding (các lề nội bộ) giảm diện tích sử dụng cho văn bản, do đó AutoFit sẽ được kích hoạt sớm hơn — thu nhỏ phông chữ hoặc thay đổi kích thước hình sớm hơn. Kiểm tra và điều chỉnh lề trước khi tinh chỉnh AutoFit.

**AutoFit tương tác như thế nào với các ký tự ngắt dòng thủ công và ngắt dòng mềm?**

Các ký tự ngắt buộc vẫn giữ nguyên vị trí, và AutoFit sẽ điều chỉnh kích thước phông và khoảng cách xung quanh chúng. Loại bỏ các ngắt không cần thiết thường giúp giảm mức độ thu nhỏ mạnh mẽ của AutoFit.

**Thay đổi phông chữ chủ đề hoặc kích hoạt việc thay thế phông chữ có ảnh hưởng đến kết quả AutoFit không?**

Có. Khi thay thế bằng phông chữ có các chỉ số glyph khác nhau, chiều rộng/độ cao của văn bản sẽ thay đổi, điều này có thể làm thay đổi kích thước phông cuối cùng và cách bọc dòng. Sau bất kỳ thay đổi hoặc thay thế phông chữ nào, hãy kiểm tra lại các slide.