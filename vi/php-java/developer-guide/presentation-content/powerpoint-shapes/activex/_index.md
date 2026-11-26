---
title: "Quản lý Điều khiển ActiveX trong Bản Trình chiếu bằng PHP"
linktitle: "ActiveX"
type: docs
weight: 80
url: /vi/php-java/activex/
keywords:
- "ActiveX"
- "Điều khiển ActiveX"
- "quản lý ActiveX"
- "thêm ActiveX"
- "sửa đổi ActiveX"
- "trình phát media"
- "PowerPoint"
- "bản trình chiếu"
- "PHP"
- "Aspose.Slides"
description: "Chỉnh sửa ô văn bản và nút ActiveX, cập nhật bản xem trước điều khiển, và tái sử dụng một điều khiển Windows Media Player trong các bản trình chiếu PowerPoint với Aspose.Slides cho PHP qua Java."
---
## **Giới thiệu**

Các điều khiển ActiveX cung cấp cho một slide PowerPoint các yếu tố tương tác như ô văn bản, nút lệnh và trình phát media. Aspose.Slides cho PHP qua Java cung cấp các điều khiển của slide thông qua [BaseSlide::getControls](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getControls). Sử dụng tập hợp này để chỉnh sửa một điều khiển, di chuyển nó trên slide hoặc xóa nó.

## **Liệt kê các điều khiển ActiveX và các thuộc tính đã lưu của chúng**

Để kiểm tra một mẫu chưa quen, mở nó để đọc và lặp qua các điều khiển trên mỗi slide. Ví dụ báo cáo số slide, tên điều khiển, [getClassId](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getClassId) và mỗi cặp khóa-giá trị trong [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties). Nó đọc bản trình chiếu mà không kích hoạt các điều khiển, không gọi sự kiện hay macro, không thay đổi giá trị và không lưu tệp.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ActiveX.pptm");
try {
    $slides = $presentation->getSlides();
    for ($i = 0; $i < java_values($slides->size()); $i++) {
        $controls = $slides->get_Item($i)->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            printf("Slide %d | %s | %s\n", $i + 1, $control->getName(), $control->getClassId());
            $properties = $control->getProperties();
            if (java_is_null($properties)) {
                echo "  Properties unavailable\n";
                continue;
            }
            if (java_values($properties->getCount()) === 0) {
                echo "  []\n";
                continue;
            }
            $names = $properties->getNamesOfProperties()->iterator();
            while (java_values($names->hasNext())) {
                $name = $names->next();
                printf("  %s = %s\n", $name, $properties->get_Item($name));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Kết quả được chọn từ `ActiveX.pptm` hiển thị một ô văn bản và một nút lệnh.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Một bộ sưu tập thuộc tính trống xuất hiện dưới dạng `[]`. Đối với các điều khiển sử dụng lưu trữ nhị phân, [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) có thể trả về `null`, được hiển thị là `Properties unavailable`. Nếu bạn chỉ cần tên, hãy sử dụng [getNamesOfProperties](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) sau khi kiểm tra null. Báo cáo liệt kê các thuộc tính có sẵn từ bản trình chiếu. Một điều khiển có thể hỗ trợ các thuộc tính bổ sung tại thời gian chạy.

## **Chỉnh sửa các điều khiển ActiveX**

Ví dụ yêu cầu một bản trình chiếu có macro với một ô văn bản tên `TextBox1` và một nút lệnh tên `CommandButton1` trên slide đầu tiên. Nó sử dụng [tập hợp thuộc tính điều khiển](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) để thay đổi giá trị ô văn bản và chú thích nút. Mỗi điều khiển cũng có một bản xem trước tĩnh mà PowerPoint có thể hiển thị trước khi kích hoạt. Cung cấp tệp PNG cho mỗi điều khiển để hiển thị văn bản và giao diện đã cập nhật. Ví dụ gán các hình ảnh này thông qua [Control::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getSubstitutePictureFormat).

Ví dụ di chuyển mọi điều khiển trên slide đầu tiên xuống 100 điểm bằng cách đặt khung của chúng với [Control::setFrame](https://reference.aspose.com/slides/php-java/aspose.slides/control/#setFrame). Nó lưu bản trình chiếu đã chỉnh sửa ở định dạng PPTM, sau đó sử dụng [ControlCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/#clear) để lưu một bản sao thứ hai với tất cả các điều khiển ActiveX bị loại bỏ khỏi slide đó.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("ActiveX.pptm");
try {
    $controls = $presentation->getSlides()->get_Item(0)->getControls();
    $textBox = null;
    $button = null;
    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $name = (string) $control->getName();
        if ($name === "TextBox1") {
            $textBox = $control;
        } elseif ($name === "CommandButton1") {
            $button = $control;
        }
    }
    if ($textBox === null || $button === null || java_is_null($textBox->getProperties()) || java_is_null($button->getProperties())) {
        echo "The first slide must contain both named controls with editable properties.\n";
        return;
    }

    foreach ([[$textBox, "text-box-preview.png"], [$button, "button-preview.png"]] as [$control, $path]) {
        $image = Images::fromFile($path);
        try {
            $preview = $presentation->getImages()->addImage($image);
            $control->getSubstitutePictureFormat()->getPicture()->setImage($preview);
        } finally {
            $image->dispose();
        }
    }
    $textBox->getProperties()->set_Item("Value", "Changed text");
    $button->getProperties()->set_Item("Caption", "Show message");

    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $frame = $control->getFrame();
        $newY = java_values($frame->getY()) + 100;
        $moved = new ShapeFrame($frame->getX(), $newY, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation());
        $control->setFrame($moved);
    }
    $presentation->save("edited-controls.pptm", SaveFormat::Pptm);

    $controls->clear();
    $presentation->save("removed-controls.pptm", SaveFormat::Pptm);
} finally {
    $presentation->dispose();
}
```

## **Thêm một điều khiển Trình phát Media ActiveX**

Để tái sử dụng một điều khiển Windows Media Player đã cấu hình, bắt đầu với một mẫu mà slide đầu tiên chứa một trình phát tên `WindowsMediaPlayer1`. [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) sao chép toàn bộ slide vào một bản trình chiếu mới. Ví dụ đặt `URL` của trình phát trong [bộ sưu tập thuộc tính](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) và lưu slide sao chép làm slide duy nhất trong kết quả. Video vẫn ở bên ngoài, vì vậy hãy chọn một đường dẫn mà trình phát có thể truy cập trong quá trình phát.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$template = new Presentation("template.pptx");
try {
    $presentation = new Presentation();
    try {
        $slides = $presentation->getSlides();
        $sourceSlide = $template->getSlides()->get_Item(0);
        $slide = $slides->addClone($sourceSlide);
        $player = null;
        $controls = $slide->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            if ((string) $control->getName() === "WindowsMediaPlayer1") {
                $player = $control;
                break;
            }
        }
        if ($player === null || java_is_null($player->getProperties())) {
            echo "The template slide must contain a named media player with editable properties.\n";
            return;
        }
        $player->getProperties()->set_Item("URL", "Wildlife.mp4");
        $slides->removeAt(0);
        $presentation->save("linked-video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $template->dispose();
}
```

## **FAQ**

**Có thể Aspose.Slides bảo tồn các điều khiển ActiveX mà không chạy chúng không?**

Có. Aspose.Slides có thể đọc và lưu các điều khiển, bao gồm thuộc tính và vị trí của chúng, mà không kích hoạt chúng.

**Các điều khiển ActiveX khác gì so với đối tượng OLE?**

Các điều khiển ActiveX cho phép người dùng tương tác với slide, ví dụ nhập văn bản hoặc nhấn nút. Một [OLE object](/slides/vi/php-java/manage-ole/) cho phép slide chứa hoặc liên kết tới nội dung được quản lý bởi một ứng dụng khác, chẳng hạn như bảng tính Excel.

**Các sự kiện ActiveX có vẫn kích hoạt macro VBA sau khi tôi lưu bản trình chiếu bằng Aspose.Slides không?**

Lưu bản trình chiếu ở định dạng hỗ trợ macro như PPTM để giữ lại dự án VBA. PowerPoint cho Windows có thể chạy các trình xử lý sự kiện hiện có khi cài đặt bảo mật cho phép cả điều khiển ActiveX và macro.