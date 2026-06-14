---
title: PHP 中的群組簡報形狀
linktitle: 形狀群組
type: docs
weight: 40
url: /zh-hant/php-java/group/
keywords:
- 群組形狀
- 形狀群組
- 新增群組
- 替代文字
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 簡報中群組與解除群組形狀 — 快速、逐步指南，提供免費程式碼。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用群組形狀。它展示了如何將群組形狀加入投影片、在群組內放置形狀，並儲存更新後的簡報。它還示範了如何存取群組內的形狀並讀取其 `AlternativeText` 值。此外，本文簡要介紹了相關的群組形狀功能，如巢狀群組、Z‑Order 以及鎖定選項。

## **新增群組形狀**
Aspose.Slides 支援在投影片上操作群組形狀。此功能協助開發人員建立更豐富的簡報。Aspose.Slides for PHP via Java 支援新增或存取群組形狀。您可以將形狀加入已新增的群組形狀以填充內容，或存取群組形狀的任何屬性。使用 Aspose.Slides for PHP via Java 將群組形狀加入投影片的步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
1. 依據 Index 取得投影片的參照。
1. 在投影片上新增群組形狀。
1. 將形狀加入已新增的群組形狀。
1. 將修改後的簡報保存為 PPTX 檔案。

下面的範例將群組形狀新增到投影片。

```php
  # 實例化 Presentation 類別
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 存取投影片的形狀集合
    $slideShapes = $sld->getShapes();
    # 在投影片上新增群組形狀
    $groupShape = $slideShapes->addGroupShape();
    # 在已新增的群組形狀內新增形狀
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # 新增群組形狀框架
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # 將 PPTX 檔案寫入磁碟
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **存取 AltText 屬性**
本主題提供簡易步驟與程式碼範例，說明如何新增群組形狀並存取投影片上群組形狀的 AltText 屬性。使用 Aspose.Slides for PHP via Java 在投影片中存取群組形狀的 AltText：

1. 實例化代表 PPTX 檔案的 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別。
1. 依據 Index 取得投影片的參照。
1. 存取投影片的形狀集合。
1. 取得群組形狀。
1. 存取 [Alternative Text](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getAlternativeText) 屬性。

下面的範例存取群組形狀的替代文字。

```php
  # 實例化代表 PPTX 檔案的 Presentation 類別
  $pres = new Presentation("AltText.pptx");
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # 存取投影片的形狀集合
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # 存取群組形狀。
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # 存取 AltText 屬性
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**是否支援巢狀分組（群組內的群組）？**

是的。 [GroupShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/groupshape/) 具備 [getParentGroup](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getparentgroup/) 方法，直接顯示支援層級結構（群組可以是另一個群組的子群組）。

**如何控制群組相對於投影片上其他物件的 Z‑Order？**

使用 [GroupShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/groupshape/) 的 [getZOrderPosition](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getzorderposition/) 方法檢查其在顯示堆疊中的位置。

**能否防止移動、編輯或解除群組？**

可以。群組的鎖定區段透過 [GroupShapeLock](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/groupshape/getgroupshapelock/) 暴露，讓您限制對該物件的操作。