---
title: 使用 C++ 管理簡報中的投影片章節
linktitle: 投影片章節
type: docs
weight: 100
url: /zh-hant/cpp/slide-section/
keywords:
- 建立章節
- 新增章節
- 編輯章節
- 變更章節
- 章節名稱
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 精簡 PowerPoint 與 OpenDocument 的投影片章節——分割、重新命名與重新排序，以最佳化 PPTX 與 ODP 工作流程。"
---
## **簡介**

使用 Aspose.Slides for C++，您可以將 PowerPoint 簡報劃分為章節。您可以建立包含特定投影片的章節。

在以下情況下，您可能需要建立章節並使用它們來組織或劃分簡報中的投影片：

- 當您與其他人或團隊共同處理大型簡報，且需要將特定投影片指派給同事或團隊成員時。 
- 當您面對包含大量投影片的簡報，且難以一次管理或編輯其內容時。

理想的情況是建立一個容納相似投影片的章節——這些投影片在某些方面具有共同點，或可根據規則歸為一組——並為該章節命名，以描述其內部的投影片。

## **在簡報中建立章節**

若要在簡報中加入容納投影片的章節，Aspose.Slides for C++ 提供 AddSection 方法，允許您指定欲建立章節的名稱以及章節起始的投影片。

以下範例程式碼示範如何在 C++ 中於簡報建立章節：

``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
// section1 將在 newSlide2 結束，之後 section2 將開始   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Last empty section");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```

## **變更章節名稱**

在 PowerPoint 簡報中建立章節後，您可能會決定變更其名稱。

以下範例程式碼示範如何使用 Aspose.Slides 在 C++ 中變更簡報章節的名稱：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"My section");
```

## **常見問題**

**將簡報另存為 PPT（PowerPoint 97–2003）格式時，章節會被保留嗎？**

否。PPT 格式不支援章節中繼資料，因此儲存為 .ppt 時會失去章節分組。

**整個章節可以「隱藏」嗎？**

否。只能隱藏個別投影片。章節作為實體並沒有「隱藏」狀態。

**我能快速透過投影片找出其所屬章節，或找出章節的第一張投影片嗎？**

是。章節以其起始投影片唯一定義；給定投影片即可判斷其所屬章節，亦可取得章節的第一張投影片。