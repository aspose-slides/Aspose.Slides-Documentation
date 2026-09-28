---
title: Quản lý Slide Master của Bản thuyết trình trong JavaScript
linktitle: Slide Master
type: docs
weight: 70
url: /vi/nodejs-java/slide-master/
keywords:
- slide mẫu
- slide mẫu
- slide mẫu PPT
- nhiều slide mẫu
- so sánh slide mẫu
- nền
- trình giữ chỗ
- nhân bản slide mẫu
- sao chép slide mẫu
- tạo bản sao slide mẫu
- slide mẫu không sử dụng
- PowerPoint
- OpenDocument
- bản thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý slide mẫu trong Aspose.Slides cho Node.js via Java: truy cập, chỉnh sửa, nhân bản, so sánh và xóa các slide mẫu trong bản thuyết trình PowerPoint và OpenDocument."
---
## **Tổng quan**

Một **slide master** xác định các thiết lập thiết kế chung cho một nhóm các slide. Nó có thể chứa các hình dạng chung, logo, nền, kiểu chữ, thiết lập chủ đề và thiết lập chú thích chân trang. Trong PowerPoint, chỉnh sửa một slide master là cách thường dùng để giữ cho bản thuyết trình đồng nhất mà không phải lặp lại cùng một định dạng trên mỗi slide.

Aspose.Slides cho Node.js qua Java hỗ trợ cùng mô hình này. Một bản thuyết trình có thể chứa một hoặc nhiều slide master, và mỗi slide master có thể chứa một số slide bố cục (layout). Các slide bình thường thường không tham chiếu trực tiếp tới slide master. Thay vào đó, một slide bình thường sử dụng một layout, và layout đó thuộc về một slide master.

Cấu trúc:

1. **Slide master** – xác định thiết kế và chủ đề chung.  
1. **Layout slide** – xác định cách sắp xếp cụ thể của các placeholder và định dạng ở mức layout.  
1. **Normal slide** – chứa nội dung thực tế của bản thuyết trình và sử dụng một layout slide.

![Cấu trúc của slide master, layout slide và normal slide](slide-master_2.jpg)

Trong Aspose.Slides, một slide master được biểu diễn bằng lớp [MasterSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/). Tất cả các slide master trong một bản thuyết trình có thể truy cập qua tập hợp `Presentation.getMasters()`.

{{% alert color="info" title="Kế thừa" %}}

Khi cùng một thuộc tính được định nghĩa ở nhiều mức, mức cụ thể hơn sẽ thắng. Ví dụ, nếu một slide master và một layout slide đều định nghĩa nền, các slide dựa trên layout đó sẽ sử dụng nền của layout. Để biết thêm thông tin về layout slide, xem [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).

{{% /alert %}}

## **Truy cập Slide Masters**

Trong PowerPoint, bạn có thể mở chế độ xem Slide Master từ **View** > **Slide Master**.

![Lệnh Slide Master trên tab View của PowerPoint](slide-master_3.jpg)

Trong Aspose.Slides, sử dụng tập hợp `getMasters()` để truy cập các slide master:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Bạn cũng có thể lấy slide master được sử dụng bởi một slide bình thường thông qua layout của nó:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Nội dung của một Slide Master**

Một slide master là một đối tượng giống slide. Nó kế thừa hành vi chung của slide từ [BaseSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslide/), do đó nó cung cấp nhiều thuộc tính slide giống như slide bình thường và layout. Các thành viên đặc thù của master được liệt kê trên trang API [MasterSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/).

Các thành viên master thường dùng bao gồm:

| Thành viên | Mục đích |
| --- | --- |
| `getBackground()` | Đặt nền slide ở mức master. |
| `getShapes()` | Lưu trữ các hình dạng đặt trên master, chẳng hạn logo, khung ảnh và văn bản chung. |
| `getLayoutSlides()` | Lưu trữ các layout slide thuộc về master. |
| `getThemeManager()` | Cung cấp quyền truy cập vào các API chủ đề của master. |
| `getHeaderFooterManager()` | Điều khiển tiêu đề, chân trang, ngày tháng và số slide cho master và các layout con. |
| `getDependingSlides()` | Trả về các slide bình thường phụ thuộc vào master qua layout của chúng. |

## **Thêm hình ảnh vào Slide Master**

Khi bạn thêm hình ảnh vào một slide master, hình ảnh sẽ xuất hiện trên các slide sử dụng layout từ master đó. Điều này hữu ích cho logo, dấu nước, dải trang trí và các yếu tố hình ảnh lặp lại khác.

Ví dụ sau thêm một logo vào slide master đầu tiên:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để biết thêm thông tin về khung ảnh, xem [Picture Frame](/nodejs-java/picture-frame/).

## **Kiểm soát hiển thị đồ họa của Master**

Sử dụng [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslide/#setShowMasterShapes) để ẩn các đồ họa kế thừa từ master, chẳng hạn logo hoặc hình dạng trang trí, mà không xóa chúng khỏi master. Gửi `false` tới [Slide.setShowMasterShapes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#setShowMasterShapes) trên slide cần bỏ các đồ họa này và giữ `true` trên các slide cần hiển thị chúng.

Ví dụ tự chứa sau tạo một dải màu xanh trên master và hai slide dùng cùng layout trống. Dải này hiển thị trên slide đầu và ẩn trên slide thứ hai. Không cần bản thuyết trình hoặc ảnh đầu vào.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);
    layoutSlide.setShowMasterShapes(true);

    let slideHeight = presentation.getSlideSize().getSize().getHeight();
    let band = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 60, slideHeight);
    let bandColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let noFillType = java.newByte(aspose.slides.FillType.NoFill);
    band.getFillFormat().setFillType(solidFillType);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(noFillType);

    let visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    let hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ví dụ sử dụng layout **Blank** được cung cấp khi tạo bản thuyết trình mới và loại bỏ các placeholder mặc định của slide đầu tiên.

### **Chọn phạm vi cài đặt**

Một slide bình thường sử dụng master qua [Slide.getLayoutSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#getLayoutSlide) và [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/#getMasterSlide). Đặt thuộc tính trên một slide riêng chỉ ảnh hưởng đến slide đó. Gửi `false` tới [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/#setShowMasterShapes) sẽ ẩn đồ họa master cho tất cả các slide dùng layout chung đó, ngay cả khi cài đặt riêng của chúng là `true`. Để ẩn đồ họa chỉ trên một slide, thay đổi thuộc tính của slide và để layout chia sẻ không thay đổi.

Cài đặt này không được hỗ trợ như một điều khiển hiển thị trên chính slide master. Trên master, [getShowMasterShapes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/#getShowMasterShapes) luôn trả về `false`, và gửi `true` tới [setShowMasterShapes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/#setShowMasterShapes) sẽ gây ra ngoại lệ. Hãy áp dụng nó cho một slide bình thường hoặc một layout thay vì master.

### **Phân biệt đồ họa và nền**

| Thao tác | Hiệu quả |
| --- | --- |
| Ẩn đồ họa master | Kiểm soát việc hiển thị các shape kế thừa từ master mà không xóa chúng hoặc thay đổi shape của slide. |
| Thay đổi màu nền slide | Thay đổi màu, gradient hoặc ảnh nền. Đồ họa master là các shape riêng biệt và có thể vẫn hiển thị trên nền này. Xem [Presentation Background](/slides/vi/nodejs-java/presentation-background/). |
| Xóa một shape khỏi master | Loại bỏ shape nguồn chia sẻ, vì vậy không còn có sẵn cho bất kỳ slide nào sử dụng master đó. |

## **Làm việc với Placeholder**

Placeholder thường được định nghĩa trên layout slide. Slide master cung cấp style và chủ đề chung mà các layout kế thừa, trong khi mỗi layout quyết định placeholder nào khả dụng và vị trí chúng.

Trong PowerPoint, các lệnh placeholder có sẵn trong chế độ xem Slide Master.

![Lệnh Insert Placeholder trong chế độ xem Slide Master của PowerPoint](slide-master_5.png)

Để thêm placeholder mới với Aspose.Slides, làm việc với layout slide thuộc về master:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bạn cũng có thể định dạng các shape placeholder đã tồn tại trên slide master. Ví dụ sau tìm placeholder tiêu đề và áp dụng màu gradient tuyến tính:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Placeholder tiêu đề được định dạng kế thừa bởi các slide bình thường](slide-master_8.png)

Để biết thêm các tùy chọn định dạng placeholder và văn bản, xem [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) và [Text Formatting](/nodejs-java/text-formatting/).

## **Thay đổi nền Slide Master**

Nền master được kế thừa bởi các layout và slide nếu chúng không ghi đè. Ví dụ sau đặt màu nền đặc cho slide master đầu tiên:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đối với các chủ đề liên quan, xem [Presentation Background](/nodejs-java/presentation-background/) và [Presentation Theme](/nodejs-java/presentation-theme/).

## **Sao chép Slide Master sang bản thuyết trình khác**

Sử dụng `MasterSlideCollection.addClone` để sao chép một slide master vào bản thuyết trình khác. Master đã sao chép sau đó có thể được sử dụng bởi các layout và slide trong bản đích.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Nếu bạn cần sao chép cả các slide bình thường cùng với master của chúng, xem [Clone Slides](/nodejs-java/clone-slides/).

## **Thêm nhiều Slide Master**

Một bản thuyết trình có thể chứa nhiều slide master. Điều này hữu ích khi các phần khác nhau yêu cầu thương hiệu, cấu trúc trang hoặc cài đặt chủ đề khác nhau.

![Các lệnh PowerPoint để chèn và quản lý slide master](slide-master_9.jpg)

Ví dụ sau sao chép master mặc định, đặt nền khác cho bản sao, tạo một layout dưới master đã sao chép và thêm một slide mới dựa trên layout đó:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **So sánh Slide Master**

Slide master có thể được so sánh bằng phương thức `equals` kế thừa từ [BaseSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslide/). Phép so sánh kiểm tra cấu trúc và nội dung tĩnh như shape, văn bản, định dạng, hoạt ảnh và các thiết lập slide khác. Nó không so sánh các định danh duy nhất như ID slide, hoặc các giá trị placeholder động như ngày hiện tại.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Để biết thêm thông tin, xem [Compare Presentation Slides](/slides/vi/nodejs-java/compare-slides/).

## **Đặt Slide Master View làm chế độ xem mặc định**

Sử dụng phương thức `setLastView` trên [ViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewproperties/) để điều khiển chế độ xem mà PowerPoint mở đầu tiên. Ví dụ sau mở bản thuyết trình ở chế độ Slide Master view:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để biết thêm về các cài đặt chế độ xem, xem [Save Presentation](/slides/vi/nodejs-java/save-presentation/).

## **Xóa các Slide Master không sử dụng**

Đôi khi bản thuyết trình chứa các slide master mà không còn slide bình thường nào sử dụng. Xóa các master không dùng có thể giảm kích thước tệp và đơn giản hoá việc bảo trì mẫu.

Sử dụng `removeUnused` để xóa các master không dùng khỏi tập hợp `getMasters()`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bạn cũng có thể dùng phương thức low-code `Compress.removeUnusedMasterSlides`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Sự khác nhau giữa slide master và layout slide là gì?**

Slide master định nghĩa các thiết lập thiết kế chung như chủ đề, nền, các shape chung và kiểu chữ. Layout slide thuộc về một slide master và xác định cách sắp xếp cụ thể của các placeholder. Slide bình thường sử dụng một layout slide, do đó nó kế thừa cả từ layout và master.

**Một bản thuyết trình có thể chứa nhiều slide master không?**

Có. Một bản thuyết trình có thể chứa nhiều slide master. Hãy sử dụng nhiều master khi các phần khác nhau cần hệ thống trực quan hoặc thương hiệu riêng.

**Nên thêm placeholder vào slide master hay layout slide?**

Trong hầu hết các trường hợp, thêm placeholder vào layout slide. Đặt các yếu tố hình ảnh chung và định dạng chung trên slide master, sau đó đặt placeholder nội dung trên các layout mà slide bình thường sẽ sử dụng.

**Tôi có thể xóa một slide master vẫn đang được sử dụng không?**

Không. Slide master có slide phụ thuộc không thể bị xóa an toàn. Trước tiên di chuyển các slide đó sang layout thuộc master khác, hoặc sử dụng phương pháp dọn dẹp master không dùng để chỉ xóa các master không còn sử dụng.