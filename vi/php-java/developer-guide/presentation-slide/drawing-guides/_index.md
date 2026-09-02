---
title: Quản lý Hướng Dẫn Vẽ trong Bản Trình Bày bằng PHP
linktitle: Hướng Dẫn Vẽ
type: docs
weight: 85
url: /vi/php-java/drawing-guides/
keywords:
- hướng dẫn vẽ
- hướng dẫn ngang
- hướng dẫn dọc
- hướng dẫn căn chỉnh
- chế độ xem slide
- slide master
- slide bố cục
- master ghi chú
- master handout
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Thêm, truy cập và xóa các hướng dẫn vẽ ngang và dọc trong bản trình bày PowerPoint bằng Aspose.Slides cho PHP qua Java."
---
## **Tổng quan**

Hướng dẫn vẽ là các đường ngang và dọc có thể điều chỉnh giúp người dùng căn chỉnh các hình dạng một cách đồng nhất khi chỉnh sửa bản trình bày trong PowerPoint. Chúng đặc biệt hữu ích khi một ứng dụng tạo ra bản trình bày mà sau này sẽ được tinh chỉnh thủ công: ứng dụng có thể lưu các công cụ căn chỉnh giống nhau mà tác giả nên tuân theo khi thêm hoặc di chuyển nội dung.

Hướng dẫn vẽ là công cụ hỗ trợ chỉnh sửa, không phải nội dung slide. Chúng không xuất hiện trong chế độ trình chiếu hoặc đầu ra được render. Aspose.Slides cho PHP qua Java cung cấp chúng qua lớp [DrawingGuidesCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/drawingguidescollection/). Một hướng dẫn được biểu diễn bằng [DrawingGuide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/drawingguide/) và có hướng, vị trí và màu sắc.

Vị trí được đo bằng điểm từ góc trên‑trái của slide hoặc master liên quan. Hướng dẫn dọc sử dụng tọa độ ngang, thường nằm trong khoảng từ zero tới độ rộng slide. Hướng dẫn ngang sử dụng tọa độ dọc, thường nằm trong khoảng từ zero tới độ cao slide.

## **Thêm Hướng Dẫn Vẽ vào Chế Độ Xem Slide**

Sử dụng [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) để quản lý các hướng dẫn được hiển thị khi chỉnh sửa các slide bình thường. Gọi [DrawingGuidesCollection::add](https://reference.aspose.com/slides/vi/php-java/aspose.slides/drawingguidescollection/#add) với một giá trị [Orientation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/orientation/) và một vị trí tính bằng điểm.

Ví dụ sau thêm một hướng dẫn dọc ở phía bên phải trung tâm slide và một hướng dẫn ngang ngay bên dưới nó:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();

    $guides->add(Orientation::Vertical, $slideWidth / 2 + 12.5);
    $guides->add(Orientation::Horizontal, $slideHeight / 2 + 12.5);

    $presentation->save("drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Truy cập Hướng Dẫn Vẽ**

Các phương thức [DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/vi/php-java/aspose.slides/drawingguidescollection/#getCount) và [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/vi/php-java/aspose.slides/drawingguidescollection/#get_Item) cung cấp quyền truy cập vào các hướng dẫn hiện có. Các phương thức [DrawingGuide::getOrientation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide::getPosition](https://reference.aspose.com/slides/vi/php-java/aspose.slides/drawingguide/#getPosition) và [DrawingGuide::getColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/drawingguide/#getColor) trả về các giá trị có thể cũng được thay đổi qua các phương thức setter tương ứng.

Ví dụ sau đọc các hướng dẫn trong chế độ xem slide từ bản trình bày đã tạo ở trên:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("drawing-guides.pptx");
try {
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();
    $guideCount = java_values($guides->getCount());

    for ($index = 0; $index < $guideCount; $index++) {
        $guide = $guides->get_Item($index);
        $orientation = java_values($guide->getOrientation());
        $position = java_values($guide->getPosition());
        $color = java_values($guide->getColor()->toString());
        echo sprintf("Guide %d: orientation = %d, position = %.2f, color = %s", $index, $orientation, $position, $color) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Thêm Hướng Dẫn Vẽ vào Master và Slide Bố Cục**

Một master slide và mỗi slide bố cục của nó có thể có bộ sưu tập hướng dẫn vẽ riêng. Sử dụng [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslide/#getDrawingGuides) cho master slide và [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/#getDrawingGuides) cho slide bố cục.

Ví dụ sau thêm một hướng dẫn dọc vào master slide đầu tiên và một hướng dẫn ngang vào slide bố cục đầu tiên:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $masterGuides = $presentation->getMasters()->get_Item(0)->getDrawingGuides();
    $layoutGuides = $presentation->getLayoutSlides()->get_Item(0)->getDrawingGuides();

    $masterGuides->add(Orientation::Vertical, $slideWidth / 2 - 20);
    $layoutGuides->add(Orientation::Horizontal, $slideHeight / 2 + 20);

    $presentation->save("master-layout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Thêm Hướng Dẫn Vẽ vào Master Ghi chú và Handout**

Master ghi chú và master handout cũng hỗ trợ hướng dẫn vẽ. Sử dụng [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masternotesslide/#getDrawingGuides) và [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) để truy cập bộ sưu tập của chúng. Nếu một bản trình bày không chứa một trong các master này, hãy lấy trình quản lý tương ứng bằng [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) hoặc [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager), sau đó tạo master mặc định bằng `setDefaultMasterNotesSlide` hoặc `setDefaultMasterHandoutSlide`.

Ví dụ sau thêm một hướng dẫn ngang vào master ghi chú và một hướng dẫn dọc vào master handout:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $notesSize = $presentation->getNotesSize()->getSize();
    $notesWidth = java_values($notesSize->getWidth());
    $notesHeight = java_values($notesSize->getHeight());
    $notesMaster = $presentation->getMasterNotesSlideManager()->setDefaultMasterNotesSlide();
    $handoutMaster = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();

    $notesMaster->getDrawingGuides()->add(Orientation::Horizontal, $notesHeight / 2 + 50);
    $handoutMaster->getDrawingGuides()->add(Orientation::Vertical, $notesWidth / 2 - 50);

    $presentation->save("notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Xóa Hướng Dẫn Vẽ**

Gọi [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/vi/php-java/aspose.slides/drawingguidescollection/#clear) để xóa mọi hướng dẫn khỏi một bộ sưu tập cụ thể. Xóa một bộ sưu tập không ảnh hưởng đến các hướng dẫn được lưu trong phạm vi khác.

Ví dụ sau xóa các hướng dẫn trong chế độ xem slide và tất cả các hướng dẫn trên master slide, slide bố cục, master ghi chú và master handout mà không tạo các master còn thiếu:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation-with-guides.pptx");
try {
    $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides()->clear();

    $masterCount = java_values($presentation->getMasters()->size());
    for ($index = 0; $index < $masterCount; $index++) {
        $presentation->getMasters()->get_Item($index)->getDrawingGuides()->clear();
    }

    $layoutCount = java_values($presentation->getLayoutSlides()->size());
    for ($index = 0; $index < $layoutCount; $index++) {
        $presentation->getLayoutSlides()->get_Item($index)->getDrawingGuides()->clear();
    }

    $notesMaster = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
        $notesMaster->getDrawingGuides()->clear();
    }

    $handoutMaster = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();
    if (!java_is_null($handoutMaster)) {
        $handoutMaster->getDrawingGuides()->clear();
    }

    $presentation->save("presentation-without-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Câu hỏi thường gặp**

**Do drawing guides appear in a slide show or exported images?**

Không. Hướng dẫn vẽ là công cụ căn chỉnh khi chỉnh sửa và không được render như nội dung bản trình bày.

**Can a drawing guide be added directly to an individual normal slide?**

Các hướng dẫn chỉnh sửa slide bình thường được lưu trong thuộc tính chế độ xem slide của bản trình bày. Các bộ sưu tập hướng dẫn riêng biệt có sẵn cho master slide, slide bố cục, master ghi chú và master handout.

**Which units are used for guide positions?**

Vị trí được chỉ định bằng điểm, trong đó 72 điểm bằng một inch. Vị trí dọc được đo từ cạnh trái, và vị trí ngang được đo từ cạnh trên.

**Does clearing drawing guides remove shapes or change slide content?**

Không. Phương thức [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/vi/php-java/aspose.slides/drawingguidescollection/#clear) chỉ xóa các hướng dẫn trong bộ sưu tập đã chọn. Các hình dạng và các nội dung slide khác vẫn giữ nguyên.