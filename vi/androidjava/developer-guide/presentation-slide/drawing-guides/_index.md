---
title: Quản lý Guidelines Vẽ trong Bản trình bày trên Android
linktitle: Guidelines Vẽ
type: docs
weight: 85
url: /vi/androidjava/drawing-guides/
keywords:
- guideline vẽ
- guideline ngang
- guideline dọc
- guideline căn chỉnh
- chế độ xem slide
- slide master
- slide bố cục
- master ghi chú
- master tài liệu phát tay
- PowerPoint
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Thêm, truy cập và xóa các guideline ngang và dọc trong bản trình bày PowerPoint bằng Aspose.Slides cho Android qua Java."
---
## **Tổng quan**

Guidelines vẽ là các đường ngang và dọc có thể điều chỉnh giúp người dùng căn chỉnh các hình dạng một cách nhất quán khi chỉnh sửa bản trình bày trong PowerPoint. Chúng đặc biệt hữu ích khi một ứng dụng tạo ra bản trình bày sẽ được tinh chỉnh thủ công sau này: ứng dụng có thể lưu các công cụ hỗ trợ căn chỉnh mà tác giả nên tuân theo khi thêm hoặc di chuyển nội dung.

Guidelines vẽ là công cụ hỗ trợ chỉnh sửa, không phải nội dung slide. Chúng không xuất hiện trong buổi chiếu slide hoặc đầu ra được render. Aspose.Slides for Android via Java cung cấp chúng thông qua giao diện [IDrawingGuidesCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idrawingguidescollection/) . Một guideline được biểu diễn bằng [IDrawingGuide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idrawingguide/) và có hướng, vị trí và màu sắc.

Vị trí được đo bằng điểm tính từ góc trên‑trái của slide hoặc master tương ứng. Một guideline dọc sử dụng tọa độ ngang, thường nằm trong khoảng từ 0 đến chiều rộng slide. Một guideline ngang sử dụng tọa độ dọc, thường nằm trong khoảng từ 0 đến chiều cao slide.

## **Thêm Guidelines vào Chế độ Xem Slide**

Sử dụng [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) để quản lý các guideline hiển thị khi chỉnh sửa slide thường. Gọi [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idrawingguidescollection/#add-byte-float-) với giá trị [Orientation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/orientation/) và vị trí tính bằng điểm.

Ví dụ dưới đây thêm một guideline dọc vào phía bên phải của trung tâm slide và một guideline ngang bên dưới nó:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, slideSize.getWidth() / 2 + 12.5f);
    guides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5f);

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Truy cập Guidelines Vẽ**

Các phương thức [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idrawingguidescollection/#getCount--) và [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idrawingguidescollection/#get_Item-int-) cung cấp quyền truy cập vào các guideline hiện có. Các phương thức [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idrawingguide/#getPosition--), và [IDrawingGuide.getColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idrawingguide/#getColor--) trả về giá trị có thể được thay đổi thông qua các phương thức setter tương ứng.

Ví dụ dưới đây đọc các guideline trong chế độ xem slide từ bản trình bày đã tạo ở trên:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("drawing-guides.pptx");
try {
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (int index = 0; index < guides.getCount(); index++) {
        IDrawingGuide guide = guides.get_Item(index);
        System.out.println("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Thêm Guidelines vào Master và Layout Slides**

Một master slide và mỗi layout slide của nó có thể có bộ sưu tập guideline riêng. Sử dụng [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslide/#getDrawingGuides--) cho master slide và [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/#getDrawingGuides--) cho layout slide.

Ví dụ dưới đây thêm một guideline dọc vào master slide đầu tiên và một guideline ngang vào layout slide đầu tiên:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm Guidelines vào Notes và Handout Masters**

Notes master và handout master cũng hỗ trợ guidelines. Sử dụng [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasternotesslide/#getDrawingGuides--) và [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) để truy cập bộ sưu tập của chúng. Nếu bản trình bày không chứa một trong các master này, [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) hoặc [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) sẽ tạo master mặc định và trả về nó.

Ví dụ dưới đây thêm một guideline ngang vào notes master và một guideline dọc vào handout master:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Xóa Guidelines Vẽ**

Gọi [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) để xóa mọi guideline khỏi một bộ sưu tập nhất định. Việc xóa một bộ sưu tập không ảnh hưởng đến các guideline được lưu trong phạm vi khác.

Ví dụ dưới đây xóa các guideline trong chế độ xem slide và tất cả các guideline trên master slide, layout slide, notes master và handout master mà không tạo các master còn thiếu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (IMasterSlide masterSlide : presentation.getMasters()) {
        masterSlide.getDrawingGuides().clear();
    }

    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        layoutSlide.getDrawingGuides().clear();
    }

    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        notesMaster.getDrawingGuides().clear();
    }

    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster != null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Guidelines vẽ có xuất hiện trong buổi chiếu slide hoặc hình ảnh xuất khẩu không?**

Không. Guidelines vẽ là công cụ hỗ trợ căn chỉnh khi chỉnh sửa và không được render như nội dung bản trình bày.

**Có thể thêm một guideline vẽ trực tiếp vào một slide bình thường đơn lẻ không?**

Guideline chỉnh sửa cho slide bình thường được lưu trong thuộc tính chế độ xem slide của bản trình bày. Các bộ sưu tập guideline riêng biệt cũng có sẵn cho master slide, layout slide, notes master và handout master.

**Đơn vị nào được sử dụng cho vị trí của guideline?**

Vị trí được chỉ định bằng điểm, trong đó 72 điểm bằng một inch. Vị trí dọc được đo từ cạnh trái, và vị trí ngang được đo từ cạnh trên.

**Việc xóa guidelines vẽ có làm mất shape hoặc thay đổi nội dung slide không?**

Không. Phương thức [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) chỉ xóa các guideline trong bộ sưu tập đã chọn. Các shape và nội dung slide khác vẫn giữ nguyên.