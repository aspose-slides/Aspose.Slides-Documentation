---
title: 在 C++ 中從簡報中移除投影片
linktitle: 移除投影片
type: docs
weight: 30
url: /zh-hant/cpp/remove-slide-from-presentation/
keywords:
- 移除投影片
- 刪除投影片
- 移除未使用的投影片
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++，輕鬆從 PowerPoint 與 OpenDocument 簡報中移除投影片。獲得清晰的程式碼範例並提升您的工作流程。"
---
## **簡介**

如果投影片（或其內容）變得多餘，您可以將其刪除。Aspose.Slides 提供了 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別，封裝了 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/)，該集合是演示文稿中所有投影片的儲存庫。使用已知的 [ISlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/) 物件的指標（參照或索引），即可指定要移除的投影片。 

## **依參照刪除投影片**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的執行個體。  
1. 透過投影片的 ID 或索引取得要移除的投影片參照。  
1. 從演示文稿中移除該參照的投影片。  
1. 儲存已修改的演示文稿。 

以下 C++ 程式碼示範如何依參照移除投影片： 

```c++
	// 文件目錄的路徑
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// 實例化一個代表簡報檔案的 Presentation 物件
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 透過投影片集合中的索引存取投影片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 透過參照移除投影片
	pres->get_Slides()->Remove(slide);

	// 儲存已修改的簡報
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **依索引刪除投影片**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的執行個體。  
1. 透過索引位置從演示文稿中移除投影片。  
1. 儲存已修改的演示文稿。 

以下 C++ 程式碼示範如何依索引移除投影片： 

```c++
	// 文件目錄的路徑
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// 實例化一個代表簡報檔案的 Presentation 物件
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 透過投影片索引移除投影片
	pres->get_Slides()->RemoveAt(0);

	// 儲存已修改的簡報
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **移除未使用的版面配置投影片**

Aspose.Slides 提供了 [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 方法（位於 [Compress](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/) 類別），讓您刪除不需要且未使用的版面配置投影片。以下 C++ 程式碼示範如何從 PowerPoint 演示文稿中移除版面配置投影片：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **移除未使用的母片投影片**

Aspose.Slides 提供了 [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) 方法（位於 [Compress](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/) 類別），讓您刪除不需要且未使用的母片投影片。以下 C++ 程式碼示範如何從 PowerPoint 演示文稿中移除母片投影片：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **常見問題**

**刪除投影片後，投影片索引會發生什麼變化？**

刪除後，集合會重新編排索引：之後的每張投影片都向左移動一個位置，因此先前的索引號碼會變得不正確。若需要穩定的參照，請使用每張投影片的永久 ID，而非其索引。

**投影片的 ID 是否不同於索引，且在相鄰投影片被刪除時會變更嗎？**

是。索引代表投影片的位置，會在新增或刪除投影片時改變。投影片 ID 為永久識別碼，刪除其他投影片時不會變更。

**刪除投影片會如何影響投影片分節？**

若該投影片屬於某個分節，該分節只會少一張投影片。分節結構保持不變；如果分節變成空的，您可以依需求[移除或重新排列分節](/slides/zh-hant/cpp/slide-section/)。

**當投影片被刪除時，附加於其上的備註與評論會發生什麼事？**

[備註](/slides/zh-hant/cpp/presentation-notes/)和[評論](/slides/zh-hant/cpp/presentation-comments/)與該投影片綁定，會在投影片被刪除時一併移除。其他投影片的內容不受影響。

**刪除投影片與清理未使用的版面配置/母片有何不同？**

刪除會將特定的普通投影片從簡報中移除。清理未使用的版面配置/母片則會刪除沒有任何投影片參照的版面配置或母片，減少檔案大小且不會改變其餘投影片的內容。這兩個動作是互補的：通常先刪除，再進行清理。