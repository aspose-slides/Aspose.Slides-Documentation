---
title: 使用 PHP 管理簡報中的投影片章節
linktitle: 投影片章節
type: docs
weight: 90
url: /zh-hant/php-java/slide-section/
keywords:
- 建立章節
- 新增章節
- 編輯章節
- 變更章節
- 章節名稱
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 簡化 PowerPoint 與 OpenDocument 中的投影片章節 — 分割、重新命名與重新排序，以優化 PPTX 與 ODP 工作流程。"
---
## **介紹**

使用 Aspose.Slides for PHP via Java，您可以將 PowerPoint 簡報組織為章節。您可以建立包含特定投影片的章節。

在以下情況下，您可能想要建立章節並使用它們來組織或劃分簡報中的投影片為邏輯部分：

- 當您與其他人或團隊共同處理大型簡報，且需要將特定投影片指派給同事或團隊成員時。 
- 當您面對包含大量投影片的簡報，且難以一次管理或編輯其內容時。

理想情況下，您應該建立包含相似投影片的章節——這些投影片具有共同點或可根據規則歸為一組——並為章節命名，以描述其內部的投影片。 

## **在簡報中建立章節**

若要在簡報中加入用於容納投影片的章節，Aspose.Slides for PHP via Java 提供了 [addSection()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sectioncollection/#addSection) 方法，您可以指定要建立的章節名稱以及章節開始的投影片。

以下範例程式碼示範如何在簡報中建立章節：

```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3);// section1 將在 newSlide2 結束，之後 section2 將開始

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("Last empty section");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **變更章節名稱**

在 PowerPoint 簡報中建立章節後，您可能會決定變更其名稱。 

以下範例程式碼示範如何使用 Aspose.Slides 變更簡報中章節的名稱：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("My section");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**將簡報儲存為 PPT（PowerPoint 97–2003）格式時，章節會被保留嗎？**

不會。PPT 格式不支援章節的中繼資料，儲存為 .ppt 時會失去章節分組。

**整個章節可以被「隱藏」嗎？**

不會。只能隱藏單一投影片。章節本身沒有「隱藏」狀態。

**我可以透過投影片快速找到所屬章節，或反向取得章節的第一張投影片嗎？**

可以。章節以其起始投影片唯一界定；給定一張投影片即可判斷其屬於哪個章節，對於章節也可取得其第一張投影片。