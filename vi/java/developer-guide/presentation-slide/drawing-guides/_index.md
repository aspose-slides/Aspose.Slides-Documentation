---
title: Quản lý Hướng Dẫn Vẽ trong Bản Trình Bày bằng Java
linktitle: Hướng Dẫn Vẽ
type: docs
weight: 85
url: /vi/java/drawing-guides/
keywords:
- hướng dẫn vẽ
- hướng dẫn ngang
- hướng dẫn dọc
- hướng dẫn căn chỉnh
- chế độ xem slide
- slide master
- slide bố cục
- master ghi chú
- master tờ rơi
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Thêm, truy cập và xóa các hướng dẫn vẽ ngang và dọc trong bản trình bày PowerPoint bằng Aspose.Slides cho Java."
---
## **Tổng quan**

Hướng dẫn vẽ là các đường ngang và dọc có thể điều chỉnh, giúp người dùng căn chỉnh các hình dạng một cách nhất quán khi chỉnh sửa bản trình bày trong PowerPoint. Chúng đặc biệt hữu ích khi một ứng dụng tạo ra bản trình bày sẽ được tinh chỉnh thủ công sau này: ứng dụng có thể lưu các công cụ căn chỉnh mà các tác giả nên tuân theo khi thêm hoặc di chuyển nội dung.

Hướng dẫn vẽ là công cụ hỗ trợ chỉnh sửa, không phải nội dung slide. Chúng không xuất hiện trong chế độ trình chiếu hoặc đầu ra được render. Aspose.Slides for Java cung cấp chúng thông qua giao diện [IDrawingGuidesCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idrawingguidescollection/). Một hướng dẫn được biểu diễn bằng [IDrawingGuide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idrawingguide/) và có hướng, vị trí và màu sắc.

Vị trí được đo bằng điểm (points) từ góc trên‑bên‑trái của slide hoặc master liên quan. Hướng dẫn dọc sử dụng tọa độ ngang, thường nằm trong khoảng từ 0 đến chiều rộng slide. Hướng dẫn ngang sử dụng tọa độ dọc, thường nằm trong khoảng từ 0 đến chiều cao slide.

## **Thêm Hướng Dẫn Vẽ vào Chế Độ Xem Slide**

Sử dụng [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) để quản lý các hướng dẫn hiển thị khi chỉnh sửa slide thường. Gọi [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idrawingguidescollection/#add-byte-float-) với giá trị [Orientation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/orientation/) và vị trí tính bằng điểm.

Ví dụ sau thêm một hướng dẫn dọc ở phía bên phải trung tâm slide và một hướng dẫn ngang ngay dưới nó:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 + 12.5));
    guides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 12.5));

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Truy Cập Hướng Dẫn Vẽ**

Các phương thức [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idrawingguidescollection/#getCount--) và [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idrawingguidescollection/#get_Item-int-) cung cấp quyền truy cập vào các hướng dẫn hiện có. Các phương thức [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idrawingguide/#getPosition--), và [IDrawingGuide.getColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idrawingguide/#getColor--) trả về các giá trị có thể thay đổi qua các phương thức setter tương ứng.

Ví dụ sau đọc các hướng dẫn chế độ xem slide từ bản trình bày đã tạo phía trên:

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

## **Thêm Hướng Dẫn vào Slide Master và Layout Slides**

Slide master và mỗi layout slide của nó có thể có bộ sưu tập hướng dẫn vẽ riêng. Sử dụng [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslide/#getDrawingGuides--) cho một slide master và [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutslide/#getDrawingGuides--) cho một layout slide.

Ví dụ sau thêm một hướng dẫn dọc vào slide master đầu tiên và một hướng dẫn ngang vào layout slide đầu tiên:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 - 20));
    layoutGuides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 20));

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm Hướng Dẫn vào Master Ghi chú và Master Tờ rơi**

Master ghi chú và master tờ rơi cũng hỗ trợ hướng dẫn vẽ. Sử dụng [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasternotesslide/#getDrawingGuides--) và [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) để truy cập bộ sưu tập của chúng. Nếu bản trình bày không chứa một trong các master này, [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) hoặc [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) sẽ tạo master mặc định và trả về nó.

Ví dụ sau thêm một hướng dẫn ngang vào master ghi chú và một hướng dẫn dọc vào master tờ rơi:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, (float) (notesSize.getHeight() / 2 + 50));
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, (float) (notesSize.getWidth() / 2 - 50));

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Xóa Hướng Dẫn Vẽ**

Gọi [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idrawingguidescollection/#clear--) để xóa mọi hướng dẫn khỏi một bộ sưu tập cụ thể. Xóa một bộ sưu tập không ảnh hưởng đến các hướng dẫn được lưu trong phạm vi khác.

Ví dụ sau xóa các hướng dẫn chế độ xem slide và tất cả các hướng dẫn trên slide master, layout slide, master ghi chú và master tờ rơi mà không tạo các master còn thiếu:

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

## **Câu hỏi thường gặp**

**Các hướng dẫn vẽ có xuất hiện trong trình chiếu hoặc ảnh xuất khẩu không?**

Không. Hướng dẫn vẽ là công cụ hỗ trợ căn chỉnh khi chỉnh sửa và không được render như nội dung bản trình bày.

**Có thể thêm một hướng dẫn vẽ trực tiếp vào một slide thường riêng lẻ không?**

Các hướng dẫn chỉnh sửa slide thường được lưu trong thuộc tính chế độ xem slide của bản trình bày. Các bộ sưu tập hướng dẫn riêng biệt có sẵn cho slide master, layout slide, master ghi chú và master tờ rơi.

**Đơn vị nào được sử dụng cho vị trí của hướng dẫn?**

Vị trí được chỉ định bằng điểm, trong đó 72 điểm bằng một inch. Vị trí dọc được đo từ cạnh trái, vị trí ngang được đo từ cạnh trên.

**Việc xóa các hướng dẫn vẽ có làm mất hình dạng hoặc thay đổi nội dung slide không?**

Không. Phương thức [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idrawingguidescollection/#clear--) chỉ xóa các hướng dẫn trong bộ sưu tập đã chọn. Các hình dạng và các nội dung slide khác vẫn giữ nguyên.