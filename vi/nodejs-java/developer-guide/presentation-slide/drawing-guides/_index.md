---
title: Quản lý các Guideline Vẽ trong Bản Trình Chiếu bằng JavaScript
linktitle: Guideline Vẽ
type: docs
weight: 85
url: /vi/nodejs-java/drawing-guides/
keywords:
- đường dẫn vẽ
- đường dẫn ngang
- đường dẫn dọc
- đường dẫn căn chỉnh
- chế độ xem slide
- slide master
- slide layout
- master ghi chú
- master tài liệu phát tay
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Thêm, truy cập và xóa các guideline vẽ ngang và dọc trong bản trình chiếu PowerPoint bằng Aspose.Slides cho Node.js qua Java."
---
## **Tổng quan**

Guidelines vẽ là các đường ngang và dọc có thể điều chỉnh giúp người dùng căn chỉnh các hình một cách nhất quán khi chỉnh sửa bản trình chiếu trong PowerPoint. Chúng đặc biệt hữu ích khi một ứng dụng tạo ra bản trình chiếu sẽ được tinh chỉnh thủ công sau này: ứng dụng có thể lưu các công cụ căn chỉnh mà tác giả nên tuân theo khi thêm hoặc di chuyển nội dung.

Guidelines vẽ là công cụ hỗ trợ chỉnh sửa, không phải nội dung slide. Chúng không xuất hiện trong buổi chiếu slide hoặc đầu ra được render. Aspose.Slides cho Node.js qua Java cung cấp chúng thông qua lớp [DrawingGuidesCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/drawingguidescollection/). Một guideline được biểu diễn bằng [DrawingGuide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/drawingguide/) và có hướng, vị trí và màu.

Vị trí được đo bằng điểm từ góc trái trên của slide hoặc master liên quan. Một guide dọc sử dụng tọa độ ngang, thường nằm trong khoảng từ 0 đến chiều rộng slide. Một guide ngang sử dụng tọa độ dọc, thường nằm trong khoảng từ 0 đến chiều cao slide.

## **Thêm Guideline vào chế độ xem Slide**

Sử dụng [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) để quản lý các guideline hiển thị khi chỉnh sửa các slide bình thường. Gọi [DrawingGuidesCollection.add](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/drawingguidescollection/#add) với một giá trị [Orientation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/orientation/) và một vị trí tính bằng điểm.

Ví dụ sau thêm một guideline dọc ở phía bên phải của trung tâm slide và một guideline ngang phía dưới nó:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Truy cập Guideline**

Các phương thức [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/drawingguidescollection/#getCount) và [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) cung cấp quyền truy cập vào các guideline hiện có. Các phương thức [DrawingGuide.getOrientation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/drawingguide/#getPosition) và [DrawingGuide.getColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/drawingguide/#getColor) trả về các giá trị có thể được thay đổi thông qua các phương thức setter tương ứng.

Ví dụ sau đọc các guideline của chế độ xem slide từ bản trình chiếu đã tạo ở trên:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Thêm Guideline vào Master và Layout Slides**

Một slide master và mỗi slide layout của nó có thể có bộ sưu tập guideline riêng. Sử dụng [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/#getDrawingGuides) cho một master slide và [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides) cho một layout slide.

Ví dụ sau thêm một guideline dọc vào master slide đầu tiên và một guideline ngang vào layout slide đầu tiên:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm Guideline vào Notes và Handout Masters**

Các notes master và handout master cũng hỗ trợ guideline. Sử dụng [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) và [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides) để truy cập bộ sưu tập của chúng. Nếu một bản trình chiếu không chứa một trong các master này, `MasterNotesSlideManager.setDefaultMasterNotesSlide` hoặc `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` sẽ tạo master mặc định và trả về nó.

Ví dụ sau thêm một guideline ngang vào notes master và một guideline dọc vào handout master:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Xóa Guideline**

Gọi [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/drawingguidescollection/#clear) để xóa mọi guideline khỏi một bộ sưu tập cụ thể. Xóa một bộ sưu tập không ảnh hưởng đến các guideline được lưu trong phạm vi khác.

Ví dụ sau xóa các guideline trong chế độ xem slide và tất cả các guideline trên slide master, layout slide, notes master và handout master mà không tạo các master còn thiếu:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Guideline có xuất hiện trong buổi chiếu slide hay hình ảnh xuất ra không?**

Không. Guideline là công cụ hỗ trợ căn chỉnh khi chỉnh sửa và không được render như nội dung bản trình chiếu.

**Có thể thêm một guideline trực tiếp vào một slide bình thường riêng lẻ không?**

Các guideline chỉnh sửa cho slide bình thường được lưu trong thuộc tính slide-view của bản trình chiếu. Các bộ sưu tập guideline riêng biệt có sẵn cho slide master, layout slide, notes master và handout master.

**Đơn vị nào được dùng cho vị trí của guideline?**

Vị trí được chỉ định bằng điểm, trong đó 72 điểm bằng một inch. Vị trí dọc được đo từ cạnh trái, và vị trí ngang được đo từ cạnh trên.

**Việc xóa guideline có làm mất các hình dạng hoặc thay đổi nội dung slide không?**

Không. Phương thức [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/drawingguidescollection/#clear) chỉ xóa các guideline trong bộ sưu tập đã chọn. Các hình dạng và nội dung slide khác vẫn không thay đổi.