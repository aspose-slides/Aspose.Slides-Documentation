---
title: Hạn chế chỉnh sửa bản trình chiếu bằng khóa hình dạng trong Node.js
linktitle: Hạn chế chỉnh sửa bản trình chiếu
type: docs
weight: 60
url: /vi/nodejs-java/applying-protection-to-presentation/
keywords:
- ngăn chặn chỉnh sửa
- bảo vệ khỏi chỉnh sửa
- khóa hình dạng
- khóa vị trí
- khóa lựa chọn
- khóa thay đổi kích thước
- khóa nhóm
- PowerPoint
- PPTX
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách khóa và mở khóa các hình dạng trong bản trình chiếu PPTX với Aspose.Slides cho Node.js qua Java để hạn chế việc lựa chọn, di chuyển, thay đổi kích thước và nhóm."
---
## **Tổng quan**

Một cách sử dụng phổ biến của Aspose.Slides for Node.js via Java là tạo, cập nhật và lưu các bản trình chiếu PowerPoint (PPTX) như một phần của quy trình tự động. Khi người dùng nhận các bản trình chiếu này, việc giới hạn các thay đổi đối với các hình dạng có thể giúp bảo tồn bố cục và nội dung dự định.

Bài viết này giải thích cách các hình dạng được tổ chức trên các slide và cách áp dụng cũng như xóa khóa hình dạng trong một bản trình chiếu PPTX. Các khóa này cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng riêng lẻ.

## **Thành phần của một Slide**

Một slide trong bản trình chiếu được tạo thành từ các thành phần như autoshapes, bảng, đối tượng OLE, các hình dạng nhóm, khung ảnh, khung video, connector và các yếu tố khác được dùng để xây dựng bản trình chiếu. Trong Aspose.Slides for Node.js via Java, mỗi yếu tố trên slide được biểu thị bằng một đối tượng kế thừa từ lớp [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/).

Các loại hình dạng khác nhau cung cấp các tùy chọn khóa khác nhau. Lớp [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) là lớp cơ sở cho các khóa hình dạng. Aspose.Slides for Node.js via Java cung cấp các lớp khóa sau:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) khóa các autoshape.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) khóa các connector.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) khóa các đối tượng đồ họa.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) khóa các nhóm hình dạng.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) khóa các khung ảnh.  

Để áp dụng khóa trên toàn bộ [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), lặp qua các slide của nó và đặt các khóa thích hợp trên mỗi hình dạng được hỗ trợ.

## **Áp dụng và Xóa Bảo vệ**

Các khóa hình dạng hạn chế các thao tác như chọn, di chuyển và thay đổi kích thước hình dạng. Chúng không làm cho toàn bộ bản trình chiếu không thể chỉnh sửa.

### **Áp dụng bảo vệ cho các hình dạng PPTX**

Aspose.Slides for Node.js via Java cung cấp lớp [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) để làm việc với các hình dạng trên một slide.

Ví dụ gọi các phương thức [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) và [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) với giá trị `true` cho autoshape, và các khóa tương đương cho hình dạng nhóm, connector và khung ảnh. Connectors sử dụng [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) để di chuyển; các nhóm cũng sử dụng [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) để hạn chế việc nhóm.

Ví dụ này tải một bản trình chiếu PPTX hiện có, kiểm tra các hình dạng trong bộ sưu tập hình dạng của mỗi slide và lưu một bản sao với các hạn chế này được áp dụng. Các hình dạng ngoài bốn loại đã xử lý sẽ được giữ nguyên. Vòng lặp không duyệt các hình dạng con bên trong một nhóm.

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

### **Xóa Bảo vệ**

Để xóa một khóa hình dạng, đặt giá trị của nó thành `false`. Ví dụ sau tải một bản trình chiếu có các khóa hình dạng và xoá các hạn chế lựa chọn, di chuyển và thay đổi kích thước qua [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) và [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). Nó cũng loại bỏ hạn chế nhóm bằng cách truyền `false` tới [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) và lưu một bản sao của bản trình chiếu. Các thiết lập khóa khác vẫn được giữ nguyên.

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

### **Kết luận**

Aspose.Slides for Node.js via Java cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng riêng lẻ hoặc áp dụng cùng một nhóm hạn chế trên nhiều slide. Chọn các khóa được hỗ trợ bởi từng loại hình dạng, và đặt giá trị của chúng thành `false` khi bạn cần xóa các hạn chế đó.

## **FAQ**

**Tôi có thể kết hợp khóa hình dạng và bảo vệ bằng mật khẩu trong cùng một bản trình chiếu không?**

Có. Các khóa hình dạng hạn chế các thao tác chỉnh sửa cụ thể, trong khi [password protection](/slides/vi/nodejs-java/password-protected-presentation/) có thể hạn chế việc mở hoặc sửa đổi bản trình chiếu. Bạn có thể sử dụng cả hai trong cùng một tệp.

**Tôi có thể hạn chế việc chỉnh sửa trên các slide cụ thể mà không ảnh hưởng đến các slide khác không?**

Có. Áp dụng khóa chỉ cho các hình dạng trên các slide đã chọn. Điều này sẽ không thay đổi cài đặt khóa trên các slide khác.

**Làm thế nào để áp dụng khóa cho các hình dạng riêng lẻ bên trong một nhóm?**

Lặp qua bộ sưu tập được trả về bởi phương thức [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) của nhóm và áp dụng các khóa phù hợp cho mỗi hình dạng con. Lặp lại quy trình này cho bất kỳ nhóm lồng nhau nào. Các ví dụ trên chỉ xử lý bộ sưu tập hình dạng của slide, do đó chúng không đặt khóa cho các thành viên riêng lẻ của nhóm.