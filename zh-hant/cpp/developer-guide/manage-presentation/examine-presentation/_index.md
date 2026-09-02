---
title: 在 C++ 中檢索與更新簡報資訊
linktitle: 簡報資訊
type: docs
weight: 30
url: /zh-hant/cpp/examine-presentation/
keywords:
- 簡報格式
- 簡報屬性
- 文件屬性
- 取得屬性
- 讀取屬性
- 變更屬性
- 修改屬性
- 更新屬性
- 檢查 PPTX
- 檢查 PPT
- 檢查 ODP
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 C++ 探索 PowerPoint 與 OpenDocument 簡報的投影片、結構與中繼資料，以更快速的洞察與更智慧的內容稽核。"
---
## **概述**

本文說明如何在 Aspose.Slides 中檢查簡報資訊。它闡述如何在不載入完整檔案的情況下判斷簡報的目前格式、讀取其文件屬性，並在需要時更新這些屬性。

這些範例基於 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentationinfo/) 與 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/documentproperties/) API，示範處理簡報中繼資料的典型操作。

## **檢查簡報格式**

在處理簡報之前，您可能想先了解目前簡報所使用的格式（PPT、PPTX、ODP 等）。

您可以在不載入簡報的情況下檢查其格式。請參考以下 C++ 程式碼：

``` cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **取得簡報屬性**

下面的 C++ 程式碼示範如何取得簡報屬性（簡報的相關資訊）：

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// 略 
```

## **更新簡報屬性**

Aspose.Slides 提供 [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) 方法，可讓您修改簡報屬性。

假設我們有一個 PowerPoint 簡報，其文件屬性如下所示。

![PowerPoint 簡報的原始文件屬性](input_properties.png)

下面的程式碼示範如何編輯部分簡報屬性：

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
using namespace Aspose::Slides;
using namespace System;

auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

變更文件屬性的結果如下所示。

![PowerPoint 簡報的變更文件屬性](output_properties.png)

## **相關連結**

若要取得關於簡報及其安全屬性的更多資訊，您可能會發現以下連結很有幫助：

- [受密碼保護的簡報](/slides/zh-hant/cpp/password-protected-presentation/)
- [受寫入保護的簡報](/slides/zh-hant/cpp/write-protected-presentation/)

## **常見問答**

**如何檢查是否已嵌入字型以及是哪一些字型？**  
在簡報層級查找 [embedded-font information](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/getembeddedfonts/)，然後將這些條目與 [fonts actually used across content](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/getfonts/) 的集合比較，即可辨識哪些字型對呈現至關重要。

**如何快速判斷檔案是否包含隱藏投影片以及有多少張？**  
迭代 [slide collection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slidecollection/) 並檢查每張投影片的 [visibility flag](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slide/get_hidden/) 即可。

**我能否偵測是否使用自訂投影片尺寸與方向，且是否與預設值不同？**  
可以。將目前的 [slide size and orientation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_slidesize/) 與標準預設值作比較；這有助於預測列印和匯出的行為。

**有沒有快速方法查看圖表是否參考外部資料來源？**  
可以。遍歷所有 [charts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chart/)，檢查其 [data source](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chartdata/get_datasourcetype/)，並註明資料是內部的還是基於連結的，包含任何失效的連結。

**如何評估可能導致渲染或 PDF 匯出變慢的「大型」投影片？**  
針對每張投影片，統計物件數量並尋找大型影像、透明度、陰影、動畫與多媒體等；再給予大致的複雜度分數，以標示可能的效能瓶頸。