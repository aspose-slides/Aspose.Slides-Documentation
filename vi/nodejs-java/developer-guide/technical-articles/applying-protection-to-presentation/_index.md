---
title: Hạn chế việc chỉnh sửa bài thuyết trình bằng khóa hình dạng trong Node.js
linktitle: Hạn chế chỉnh sửa bài thuyết trình
type: docs
weight: 60
url: /vi/nodejs-java/applying-protection-to-presentation/
keywords:
- ngăn chặn chỉnh sửa
- bảo vệ khỏi việc chỉnh sửa
- khóa hình dạng
- khóa vị trí
- khóa lựa chọn
- khóa thay đổi kích thước
- khóa nhóm
- PowerPoint
- PPTX
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách khóa và mở khóa các hình dạng trong bài thuyết trình PPTX bằng Aspose.Slides cho Node.js thông qua Java để hạn chế việc lựa chọn, di chuyển, thay đổi kích thước và nhóm."
---
## **Tổng quan**

Một cách sử dụng phổ biến của Aspose.Slides cho Node.js thông qua Java là tạo, cập nhật và lưu các bài thuyết trình PowerPoint (PPTX) như một phần của quy trình làm việc tự động. Khi người dùng nhận các bài thuyết trình này, việc hạn chế thay đổi các hình dạng có thể giúp bảo tồn bố cục và nội dung dự định.

Bài viết này giải thích cách các hình dạng được tổ chức trên các slide và cách áp dụng cũng như loại bỏ khóa hình dạng trong một bài thuyết trình PPTX. Các khóa này cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng riêng lẻ.

## **Thành phần của một Slide**

Một slide trong bài thuyết trình được tạo thành từ các thành phần như autoshapes, bảng, đối tượng OLE, các hình dạng nhóm, khung ảnh, khung video, kết nối và các yếu tố khác được dùng để xây dựng một bài thuyết trình. Trong Aspose.Slides cho Node.js thông qua Java, mỗi yếu tố trên một slide được đại diện bằng một đối tượng kế thừa từ lớp [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) .

Các loại hình dạng khác nhau cung cấp các tùy chọn khóa khác nhau. Lớp [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) là lớp cơ sở cho các khóa hình dạng. Aspose.Slides cho Node.js thông qua Java cung cấp các lớp khóa sau:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) khóa autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) khóa các hình kết nối.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) khóa các đối tượng đồ họa.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) khóa các hình dạng nhóm.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) khóa các khung ảnh.  

Để áp dụng các khóa trên toàn bộ [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), hãy lặp qua các slide của nó và đặt các khóa phù hợp cho mỗi hình dạng được hỗ trợ.

## **Áp dụng và Xóa Bảo vệ**

Các trình soạn thảo bài thuyết trình tương thích sử dụng khóa hình dạng để hạn chế các thao tác chỉnh sửa cá nhân. Mã hóa tệp và bảo vệ ghi ở mức độ tài liệu là các [cài đặt bảo vệ bài thuyết trình](/slides/vi/nodejs-java/password-protected-presentation/) riêng biệt.

### **Áp dụng bảo vệ cho các hình dạng PPTX**

Aspose.Slides cho Node.js thông qua Java cung cấp lớp [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) để làm việc với các hình dạng trên một slide.

Ví dụ gọi [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked), và [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) với `true` cho autoshapes, với các khóa tương đương cho các hình dạng nhóm, kết nối và khung ảnh. Các kết nối sử dụng [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) để di chuyển; các nhóm cũng sử dụng [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) để hạn chế việc nhóm.

Ví dụ tải một bài thuyết trình PPTX hiện có, kiểm tra các hình dạng trong bộ sưu tập hình dạng của từng slide, và lưu một bản sao với các hạn chế này được áp dụng. Các hình dạng ngoài bốn loại được xử lý sẽ không bị thay đổi. Vòng lặp không duyệt các hình dạng con bên trong một nhóm.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Xóa bảo vệ**

Để xóa một khóa hình dạng, đặt giá trị của nó thành `false`. Ví dụ sau tải một bài thuyết trình có khóa hình dạng và xóa các hạn chế lựa chọn, di chuyển và thay đổi kích thước thông qua [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/), và [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). Nó cũng loại bỏ hạn chế nhóm bằng cách truyền `false` vào [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) và lưu một bản sao của bài thuyết trình. Các thiết lập khóa khác không thay đổi.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("ProtectedSample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Bảo tồn cắt ảnh**

Đặt một ảnh có tên `photo.jpg` trong thư mục làm việc. Ví dụ cắt 12 % từ trái và 8 % từ phải, sau đó gọi [setCropLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setCropLocked) trên khóa của khung ảnh. Truyền `true` sẽ hạn chế việc cắt thêm và bảo tồn phần đã cắt hiện có.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const photoStream = java.newInstanceSync("java.io.FileInputStream", "photo.jpg");
    let photo;
    try {
        photo = presentation.getImages().addImage(photoStream);
    } finally {
        photoStream.close();
    }

    const pictureFrame = shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);

    const pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` lưu khóa cắt dưới dạng `true`. Trong PowerPoint, lệnh **Crop** bị vô hiệu hoá khi ảnh được chọn.

### **Giữ một sơ đồ được nhóm**

Ví dụ nhóm một hình chữ nhật và một mũi tên, sau đó gọi [setUngroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setUngroupingLocked) trên khóa của nhóm để giữ các thành phần của sơ đồ lại với nhau. Các chỉnh sửa khác, chẳng hạn di chuyển nhóm hoặc thay đổi màu nền của thành phần, vẫn khả dụng.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    
    const groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` lưu khóa bỏ nhóm dưới dạng `true`. Trong PowerPoint, lệnh **Ungroup** bị vô hiệu hoá khi toàn bộ sơ đồ được chọn.

### **Báo cáo các khóa hình dạng hiện có**

Để xem lại một mẫu, mở nó và đọc đối tượng khóa của mỗi hình dạng. Phương thức [getNoLocks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/#getNoLocks) trả về `true` khi tất cả các cờ trên đối tượng đó đều tắt và `false` khi ít nhất một cờ được bật. Một nhóm và các thành phần con của nó có các đối tượng khóa riêng, vì vậy hãy kiểm tra các thành phần con ngay cả khi nhóm không có khóa.

Ví dụ này kiểm tra việc di chuyển cho autoshapes, khung ảnh và các nhóm. Nó cũng kiểm tra cắt ảnh cho picture và bỏ nhóm cho các nhóm. Báo cáo liệt kê các cờ đã bật mà nó nhận dạng và đánh dấu các loại hình dạng mà nó không kiểm tra.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function inspectShapes(shapes, slideNumber, prefix) {
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const path = prefix + shape.getName();
        const type = shape.getClass().getSimpleName();
        const label = `Slide ${slideNumber} | ${path} | ${type}`;
        const flags = [];
        const isGroup = java.instanceOf(shape, "com.aspose.slides.IGroupShape");
        let shapeLock;

        if (isGroup) {
            shapeLock = shape.getGroupShapeLock();
            if (shapeLock.getUngroupingLocked()) flags.push("UngroupingLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            shapeLock = shape.getPictureFrameLock();
            if (shapeLock.getCropLocked()) flags.push("CropLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shapeLock = shape.getAutoShapeLock();
        } else {
            console.log(`${label} | Uninspected`);
            continue;
        }

        if (!shapeLock.getNoLocks()) {
            if (shapeLock.getPositionLocked()) flags.push("PositionLocked");
            const restrictions = flags.length ? flags.join(", ") : "Active flag not identified";
            console.log(`${label} | ${restrictions}`);
        }

        if (isGroup) {
            inspectShapes(shape.getShapes(), slideNumber, path + "/");
        }
    }
}

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    const slides = presentation.getSlides();
    for (let i = 0; i < slides.size(); i++) {
        const slide = slides.get_Item(i);
        inspectShapes(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

Giả sử slide 1 của `Sample.pptx` chứa một nhóm có tên `Layout` với khóa bỏ nhóm, một ảnh có tên `Photo` bên trong với khóa cắt, và một hình chữ nhật không khóa có tên `Free`. Báo cáo bỏ qua `Free` và in ra hai dòng sau:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Báo cáo đọc các cờ chỉnh sửa ở mức hình dạng được lưu mà không thay đổi chúng hoặc lưu lại bài thuyết trình. Bảo vệ ghi ở mức tài liệu là một cài đặt riêng, và việc thực thi mỗi cờ phụ thuộc vào trình soạn thảo.

### **Kết luận**

Aspose.Slides cho Node.js thông qua Java cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng riêng lẻ hoặc áp dụng cùng một hạn chế trên nhiều slide. Chọn các khóa được hỗ trợ bởi mỗi loại hình dạng, và đặt giá trị của chúng thành `false` khi bạn cần xóa các hạn chế đó.

## **Câu hỏi thường gặp**

**Tôi có thể kết hợp khóa hình dạng và bảo vệ bằng mật khẩu trong cùng một bài thuyết trình không?**

Có. Các khóa hình dạng hạn chế các thao tác chỉnh sửa cụ thể, trong khi [bảo vệ bằng mật khẩu](/slides/vi/nodejs-java/password-protected-presentation/) có thể hạn chế việc mở hoặc sửa đổi bài thuyết trình. Bạn có thể sử dụng cả hai trong cùng một tệp.

**Tôi có thể hạn chế chỉnh sửa trên các slide cụ thể mà không ảnh hưởng đến các slide khác không?**

Có. Áp dụng khóa chỉ cho các hình dạng trên các slide đã chọn. Điều này không thay đổi cài đặt khóa trên các slide khác.

**Làm thế nào tôi có thể áp dụng khóa cho từng hình dạng riêng lẻ bên trong một nhóm?**

Duyệt qua bộ sưu tập trả về bởi phương thức [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) của nhóm và áp dụng các khóa phù hợp cho mỗi hình dạng con. Lặp lại thao tác này cho bất kỳ nhóm lồng nhau nào, theo cách duyệt trong ví dụ báo cáo.