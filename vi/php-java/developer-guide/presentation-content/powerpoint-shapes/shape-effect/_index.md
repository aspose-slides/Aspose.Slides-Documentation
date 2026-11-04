---
title: Áp dụng hiệu ứng hình dạng trong bản trình chiếu bằng PHP
linktitle: Hiệu ứng hình dạng
type: docs
weight: 30
url: /vi/php-java/shape-effect/
keywords:
- hiệu ứng hình dạng
- hiệu ứng bóng
- hiệu ứng phản chiếu
- hiệu ứng hào quang
- hiệu ứng cạnh mềm
- định dạng hiệu ứng
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Chuyển đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng nâng cao bằng Aspose.Slides cho PHP qua Java—tạo các slide chuyên nghiệp, ấn tượng trong vài giây."
---
## **Giới thiệu**

Trong khi các hiệu ứng trong PowerPoint có thể được dùng để làm nổi bật một hình dạng, chúng khác với [đổ màu](/slides/vi/php-java/shape-formatting/#gradient-fill) hoặc đường viền. Bằng cách sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan tỏa ánh sáng hào quang của hình dạng, v.v.

![Hiệu ứng hình](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Một số kết hợp hiệu ứng trông đẹp hơn các kết hợp khác. Vì lý do này, PowerPoint cung cấp các tùy chọn dưới **Preset**. Các tùy chọn Preset là các kết hợp của hai hoặc nhiều hiệu ứng đã được biết là trông đẹp. Bằng cách này, khi chọn một preset, bạn sẽ không phải lãng phí thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm một sự kết hợp phù hợp.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) cho phép bạn áp dụng các hiệu ứng tương tự cho các hình dạng trong bản trình chiếu PowerPoint.

## **Áp dụng hiệu ứng bóng**

Aspose.Slides cho PHP qua Java hỗ trợ bóng ngoài và bóng trong cho các hình dạng. Bạn có thể tùy chỉnh màu sắc, hướng, khoảng cách và bán kính làm mờ của chúng để phù hợp với thiết kế bản trình chiếu của bạn.

### **Áp dụng bóng ngoài**

Sử dụng bóng ngoài để làm cho một thẻ hoặc bảng nổi bật so với nền slide. Bóng mở rộng ra ngoài các cạnh của hình dạng, tạo ấn tượng rằng hình dạng được nâng lên trên slide. Điều chỉnh màu sắc, hướng, khoảng cách và bán kính làm mờ để phù hợp với ánh sáng và kiểu dáng của mẫu của bạn.

Đoạn mã PHP này cho thấy cách áp dụng [hiệu ứng bóng ngoài](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) cho một hình chữ nhật:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Hiệu ứng bóng](shadow_effect.png)

### **Áp dụng bóng trong**

Khi tái tạo kiểu dáng trực quan của mẫu, sử dụng bóng trong để tạo cho thẻ hoặc bảng một vẻ ngoài lõm vào. Bóng ngoài mở rộng ra bên ngoài hình dạng và làm cho nó trông như được nâng lên, trong khi bóng trong tạo bóng cho bên trong các cạnh của nó.

Gọi [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect), sau đó cấu hình bóng trả về bởi [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). Giá trị bán kính làm mờ lớn hơn tạo ra các cạnh mềm mại hơn.

Ví dụ PHP này tạo một thẻ màu xanh nhạt với bóng trong màu xám đậm và lưu nó dưới dạng tệp PPTX. Hướng bóng là 225 độ, khoảng cách là 7 điểm, và bán kính làm mờ là 6 điểm:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Hình chữ nhật màu xanh nhạt với bóng trong](inner_shadow_effect.png)

Để loại bỏ bóng trong, gọi [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) trên định dạng hiệu ứng của hình dạng.

## **Áp dụng hiệu ứng phản chiếu**

Để áp dụng một hiệu ứng phản chiếu trong Aspose.Slides cho PHP qua Java, bạn có thể thêm một phản chiếu giống gương vào các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao tính thẩm mỹ của bản trình chiếu bằng cách tạo cho các hình dạng một vẻ ngoài tinh tế và chuyên nghiệp hơn. Nó dễ triển khai với mã đơn giản, cho phép áp dụng nhanh chóng trên nhiều phần tử để đạt thiết kế nhất quán.

Đoạn mã PHP này cho thấy cách áp dụng [hiệu ứng phản chiếu](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) cho một hình dạng:

```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Hiệu ứng phản chiếu](reflection_effect.png)

## **Áp dụng hiệu ứng hào quang**

Để áp dụng một hiệu ứng hào quang cho một hình dạng trong Aspose.Slides cho PHP qua Java, bạn có thể thêm một hào quang mềm mại xung quanh các hình dạng, điều chỉnh các thuộc tính như màu sắc và kích thước. Hiệu ứng này giúp làm nổi bật các hình dạng và thêm một yếu tố hình ảnh thu hút vào bản trình chiếu của bạn. Nó dễ thực hiện với ít mã, cải thiện tổng thể giao diện của các slide.

Đoạn mã PHP này cho thấy cách áp dụng [hiệu ứng hào quang](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) cho một hình dạng:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Hiệu ứng hào quang](glow_effect.png)

## **Áp dụng hiệu ứng cạnh mềm**

Để áp dụng một hiệu ứng cạnh mềm trong Aspose.Slides cho PHP qua Java, bạn có thể tạo một chuyển tiếp mượt mà, mờ ở quanh các cạnh của một hình dạng. Hiệu ứng này mang lại vẻ ngoài tinh tế và nhẹ nhàng hơn, phù hợp cho các thiết kế cần sự mềm mại. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt được hiệu ứng mong muốn trên nhiều hình dạng trong bản trình chiếu.

Đoạn mã PHP này cho thấy cách áp dụng [hiệu ứng cạnh mềm](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) cho một hình dạng:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Hiệu ứng cạnh mềm](soft_edges_effect.png)

## **Áp dụng hiệu ứng làm mờ**

Sử dụng làm mờ hình dạng để làm mềm màu nền và đường viền của hình dạng trong khi vẫn giữ cho hình dạng có thể chỉnh sửa được. Gọi [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) trên định dạng hiệu ứng của hình dạng. Bán kính được đo bằng điểm (1/72 inch): dùng giá trị không âm, giá trị lớn hơn tạo độ mờ mạnh hơn. Bán kính bằng 0 giữ nguyên ngoại hình.

Cài đặt [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) kiểm soát giới hạn hiển thị của hiệu ứng. Khi `false`, độ mờ bị cắt lại trong giới hạn đã vẽ ban đầu, bao gồm cả đường viền. Khi `true`, độ mờ có thể mở rộng ra ngoài các giới hạn đó. Cả hai cài đặt đều không thay đổi vị trí hay kích thước của hình dạng.

So sánh dưới đây sử dụng cùng một màu nền, đường viền và kích thước hình dạng xuyên suốt. Hàng trên dùng `grow = false`; hàng dưới dùng `grow = true`.

![Hình chữ nhật gốc so sánh với bán kính làm mờ 5 và 15 điểm, với grow bị tắt và bật](shape_blur_comparison.png)

Ví dụ PHP này tạo một hình chữ nhật màu cam với đường viền màu xanh đậm, áp dụng độ mờ 5 điểm, rồi cập nhật lên độ mờ 15 điểm bằng cách gọi lại [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect). Nó lưu cả hai trạng thái đã làm mờ, sau đó gọi [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) và lưu hình dạng mà không có độ mờ.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Làm mờ hình dạng ảnh hưởng đến cả màu nền và đường viền cùng lúc. Hiệu ứng cạnh mềm làm mờ dần các cạnh của hình dạng, trong khi làm mờ bóng chỉ làm mềm bóng. Các hiệu ứng biến đổi hình ảnh hoạt động trên nội dung ảnh; ví dụ này áp dụng độ mờ trực tiếp lên định dạng hiệu ứng của hình dạng mà không chuyển hình dạng thành ảnh.

## **FAQ**

**Có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn như bóng, phản chiếu và hào quang, trên một hình dạng duy nhất để tạo ra một vẻ ngoài năng động hơn.

**Tôi có thể áp dụng hiệu ứng cho những hình dạng nào?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm các hình tự động, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE và các loại khác.

**Có thể áp dụng hiệu ứng cho các nhóm hình dạng không?**

Có, bạn có thể áp dụng hiệu ứng cho các nhóm hình dạng. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.