---
title: Quản lý các điều khiển ActiveX trong bản trình chiếu bằng PHP
linktitle: ActiveX
type: docs
weight: 80
url: /vi/php-java/activex/
keywords:
- ActiveX
- điều khiển ActiveX
- quản lý ActiveX
- thêm ActiveX
- sửa đổi ActiveX
- trình phát media
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách Aspose.Slides for PHP via Java sử dụng ActiveX để tự động hoá và nâng cao các bản trình chiếu PowerPoint, cung cấp cho nhà phát triển khả năng kiểm soát mạnh mẽ trên các slide."
---
## **Giới thiệu**

Các điều khiển ActiveX được sử dụng trong bản trình chiếu. Aspose.Slides for PHP via Java cho phép bạn thêm và quản lý các điều khiển ActiveX, nhưng chúng hơi khó quản lý hơn so với các hình dạng bình thường trong bản trình chiếu. Chúng tôi đã triển khai hỗ trợ thêm điều khiển Media Player Active trong Aspose.Slides. Lưu ý rằng các điều khiển ActiveX không phải là hình dạng; chúng không phải là một phần của bản trình chiếu's [ShapeCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/). Chúng là một phần của [ControlCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/controlcollection/) riêng biệt. Trong chủ đề này, chúng tôi sẽ chỉ cho bạn cách làm việc với chúng.

## **Thêm Điều Khiển ActiveX Media Player vào Slide**
Để thêm điều khiển ActiveX Media Player, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation) và tạo một bản trình chiếu trống.
1. Truy cập slide mục tiêu trong [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
1. Thêm điều khiển Media Player ActiveX bằng phương thức [addControl](https://reference.aspose.com/slides/vi/php-java/aspose.slides/controlcollection/addcontrol/) được cung cấp bởi [ControlCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/controlcollection/).
1. Truy cập điều khiển Media Player ActiveX và đặt đường dẫn video bằng cách sử dụng các thuộc tính của nó.
1. Lưu bản trình chiếu dưới dạng tệp PPTX.

Đoạn mã mẫu này, dựa trên các bước trên, cho thấy cách thêm Điều Khiển ActiveX Media Player vào một slide:

```php
  # Tạo thể hiện bản trình chiếu trống
  $pres = new Presentation();
  try {
    # Thêm điều khiển ActiveX Media Player
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # Truy cập điều khiển ActiveX Media Player và đặt đường dẫn video
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # Lưu bản trình chiếu
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Sửa đổi Điều Khiển ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 7.1.0 và các phiên bản mới hơn được trang bị các thành phần để quản lý các điều khiển ActiveX. Bạn có thể truy cập vào điều khiển ActiveX đã được thêm vào bản trình chiếu của mình và sửa đổi hoặc xóa nó thông qua các thuộc tính của nó.

{{% /alert %}} 

Để quản lý một điều khiển ActiveX đơn giản như hộp văn bản và nút lệnh đơn giản trên một slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation) và tải bản trình chiếu có chứa các điều khiển ActiveX.
1. Lấy tham chiếu slide bằng chỉ mục của nó.
1. Truy cập các điều khiển ActiveX trong slide bằng cách truy cập [ControlCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/controlcollection/).
1. Truy cập điều khiển ActiveX TextBox1 bằng đối tượng [Control](https://reference.aspose.com/slides/vi/php-java/aspose.slides/control/).
1. Thay đổi các thuộc tính của điều khiển ActiveX TextBox1 bao gồm văn bản, phông chữ, chiều cao phông và vị trí khung.
1. Truy cập điều khiển thứ hai có tên CommandButton1.
1. Thay đổi tiêu đề nút, phông chữ và vị trí.
1. Dịch chuyển vị trí của các khung điều khiển ActiveX.
1. Ghi bản trình chiếu đã sửa đổi vào tệp PPTX.

Đoạn mã mẫu này, dựa trên các bước trên, cho thấy cách quản lý một điều khiển ActiveX đơn giản: 

```php
  # Truy cập bản trình chiếu có các điều khiển ActiveX
  $pres = new Presentation("ActiveX.pptm");
  try {
    # Truy cập slide đầu tiên trong bản trình chiếu
    $slide = $pres->getSlides()->get_Item(0);
    # thay đổi văn bản của TextBox text
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # Thay đổi hình ảnh thay thế. PowerPoint sẽ thay thế hình ảnh này khi kích hoạt activeX,
      # vì vậy đôi khi có thể để nguyên hình ảnh.
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->window);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $graphics->drawString($newText, 10, 20);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # Thay đổi nhãn nút
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # Thay đổi hình ảnh thay thế
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->control);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $metrics = $graphics->getFontMetrics($font);
      $graphics->drawString($newCaption, $image->getWidth() - $metrics->stringWidth($newCaption) / 2, 20);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # Di chuyển xuống 100 điểm
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # xóa các điều khiển
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Aspose.Slides có giữ nguyên các điều khiển ActiveX khi đọc và lưu lại nếu chúng không thể thực thi trong môi trường Java runtime không?**

Có. Aspose.Slides coi chúng là một phần của bản trình chiếu và có thể đọc/điều chỉnh các thuộc tính và khung của chúng; không cần thực thi các điều khiển để giữ chúng lại.

**Các điều khiển ActiveX khác gì so với đối tượng OLE trong bản trình chiếu?**

Các điều khiển ActiveX là các điều khiển tương tác được quản lý (nút, hộp văn bản, trình phát media), trong khi [OLE](/slides/vi/php-java/manage-ole/) đề cập đến các đối tượng ứng dụng nhúng (ví dụ, một bảng tính Excel). Chúng được lưu trữ và xử lý khác nhau và có các mô hình thuộc tính khác nhau.

**Các sự kiện ActiveX và macro VBA có hoạt động nếu tệp đã được Aspose.Slides chỉnh sửa không?**

Aspose.Slides giữ nguyên mã đánh dấu và siêu dữ liệu hiện có; tuy nhiên, các sự kiện và macro chỉ chạy trong PowerPoint trên Windows khi bảo mật cho phép. Thư viện không thực thi VBA.