---
title: 使用 PHP 管理簡報中的 ActiveX 控制項
linktitle: ActiveX
type: docs
weight: 80
url: /zh-hant/php-java/activex/
keywords:
- ActiveX
- ActiveX 控制項
- 管理 ActiveX
- 新增 ActiveX
- 修改 ActiveX
- 媒體播放器
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解 Aspose.Slides for PHP via Java 如何利用 ActiveX 自動化並增強 PowerPoint 簡報，為開發人員提供對投影片的強大控制功能。"
---
## **簡介**

ActiveX 控制項在簡報中使用。Aspose.Slides for PHP via Java 允許您新增與管理 ActiveX 控制項，但相較於普通的簡報形狀，管理起來稍微複雜一些。我們已在 Aspose.Slides 中實作加入 Media Player Active 控制項的支援。請注意，ActiveX 控制項不是形狀；它們不屬於簡報的 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/)。它們屬於獨立的 [ControlCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/controlcollection/) 中。本章節將示範如何使用它們。

## **將 Media Player ActiveX 控制項新增至投影片**
要新增 ActiveX Media Player 控制項，請執行以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例，產生空白簡報。
1. 在 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 中存取目標投影片。
1. 使用由 [ControlCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/controlcollection/) 提供的 [addControl](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/controlcollection/addcontrol/) 方法加入 Media Player ActiveX 控制項。
1. 取得 Media Player ActiveX 控制項，並使用其屬性設定影片路徑。
1. 將簡報儲存為 PPTX 檔案。

以下範例程式碼依照上述步驟說明如何將 Media Player ActiveX 控制項新增至投影片：

```php
  # 建立空白簡報實例
  $pres = new Presentation();
  try {
    # 加入 Media Player ActiveX 控制項
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # 取得 Media Player ActiveX 控制項並設定影片路徑
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # 儲存簡報
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **修改 ActiveX 控制項**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 7.1.0 及更新版本已提供管理 ActiveX 控制項的元件。您可以存取簡報中已加入的 ActiveX 控制項，並透過其屬性進行修改或刪除。

{{% /alert %}} 

要在投影片上管理簡單的 ActiveX 控制項（如文字方塊和簡易指令按鈕），請執行以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例，並載入包含 ActiveX 控制項的簡報。
1. 依索引取得投影片參考。
1. 透過存取 [ControlCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/controlcollection/) 取得投影片中的 ActiveX 控制項。
1. 使用 [Control](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/control/) 物件取得 TextBox1 ActiveX 控制項。
1. 變更 TextBox1 ActiveX 控制項的屬性，包括文字、字型、字型高度與框架位置。
1. 取得第二個稱為 CommandButton1 的存取控制項。
1. 變更按鈕標題、字型與位置。
1. 調整 ActiveX 控制項框架的位置。
1. 將修改後的簡報寫入 PPTX 檔案。

以下範例程式碼依照上述步驟說明如何管理簡單的 ActiveX 控制項：

```php
  # 存取帶有 ActiveX 控制項的簡報
  $pres = new Presentation("ActiveX.pptm");
  try {
    # 存取簡報的第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 變更文字方塊文字
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # 變更替代影像。PowerPoint 會在 ActiveX 啟用期間取代此影像，
      # 因此有時保留影像不變也是可以的。
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
    # 變更按鈕標題
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # 變更替代影像
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
    # 向下移動 100 點
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # 移除控制項
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**Aspose.Slides 在讀取並重新儲存時，如果在 Java 執行階段無法執行 ActiveX 控制項，是否仍會保留它們？**

是。Aspose.Slides 會將它們視為簡報的一部份，並能讀取/修改其屬性與框架；不需要執行控制項本身即可保留。

**ActiveX 控制項與簡報中的 OLE 物件有何不同？**

ActiveX 控制項是互動式受管理的控制項（按鈕、文字方塊、媒體播放器），而 [OLE](/slides/zh-hant/php-java/manage-ole/) 指的是嵌入式的應用程式物件（例如 Excel 工作表）。它們的儲存與處理方式不同，且具有不同的屬性模型。

**如果檔案已由 Aspose.Slides 修改，ActiveX 事件與 VBA 巨集是否仍然有效？**

Aspose.Slides 會保留現有的標記與中繼資料；然而，事件與巨集僅在 Windows 上的 PowerPoint 中，且安全性允許時才會執行。此函式庫不會執行 VBA。