---
title: 在 C++ 中存取簡報投影片
linktitle: 存取投影片
type: docs
weight: 20
url: /zh-hant/cpp/access-slide-in-presentation/
keywords:
- 存取投影片
- 投影片索引
- 投影片 ID
- 投影片位置
- 變更位置
- 投影片屬性
- 投影片編號
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 存取與管理 PowerPoint 與 OpenDocument 簡報中的投影片。透過程式碼範例提升生產力。"
---
## **概述**

本文說明如何使用 Aspose.Slides 存取與管理簡報中的投影片。它展示了如何從投影片集合中以零基索引取得投影片，以及如何使用 `GetSlideById` 方法依唯一 ID 存取投影片。

您還將學習如何使用 `set_SlideNumber` 方法變更投影片的位置，以及如何使用 `set_FirstSlideNumber` 方法為簡報定義起始投影片編號。範例示範了載入簡報、取得投影片參考、更新投影片順序或編號，並儲存已修改的簡報。

## **依索引存取投影片**

簡報中的所有投影片皆依投影片位置以數字方式排序，起始索引為 0。第一張投影片可透過索引 0 存取；第二張投影片可透過索引 1 存取；依此類推。

Presentation 類別代表簡報檔案，會將所有投影片以 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/)（[ISlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/) 物件的集合）形式公開。以下 C++ 程式碼示範如何透過索引存取投影片：

```c++
	// 文件目錄的路徑。
	const String templatePath = u"../templates/AddSlides.pptx";

	// 實例化 Presentation 類別
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 透過索引取得投影片的參照
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **依 ID 存取投影片**

簡報中的每張投影片都有唯一的 ID。您可以使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別公開的 [GetSlideById()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/getslidebyid/) 方法來針對該 ID。以下 C++ 程式碼示範如何提供有效的投影片 ID，並透過 [GetSlideById()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/getslidebyid/) 方法存取該投影片：

```c++
	// 文件目錄的路徑。
	const String templatePath = u"../templates/AddSlides.pptx";

	// 實例化 Presentation 類別
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 取得投影片 ID
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// 透過 ID 存取投影片
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **變更投影片位置**

Aspose.Slides 允許您變更投影片位置。例如，您可以指定將第一張投影片變成第二張投影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的執行個體。  
1. 透過索引取得要變更位置的投影片參考  
1. 透過 [set_SlideNumber()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/set_slidenumber/) 屬性設定投影片的新位置。  
1. 儲存已修改的簡報。

以下 C++ 程式碼示範將位置 1 的投影片移至位置 2 的操作：

```c++
	// 文件目錄的路徑。
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// 實例化 Presentation 類別
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 取得將變更位置的投影片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 設定投影片的新位置
	slide->set_SlideNumber(2);

	// 儲存已修改的簡報
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

第一張投影片變成了第二張；第二張投影片變成了第一張。變更投影片位置時，其他投影片會自動調整。

## **設定投影片編號**

使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別公開的 [set_FirstSlideNumber()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/set_firstslidenumber/) 屬性，您可以為簡報的第一張投影片指定新的編號。此操作會導致其他投影片編號重新計算。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的執行個體。  
1. 取得投影片編號。  
1. 設定投影片編號。  
1. 儲存已修改的簡報。

以下 C++ 程式碼示範將第一張投影片的編號設定為 10 的操作：

```c++
	// 文件目錄的路徑。
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//實例化 Presentation 類別
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 取得投影片編號
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// 設定投影片編號
	pres->set_FirstSlideNumber(2);
	
	// 儲存已修改的簡報
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

如果您想略過第一張投影片，亦可從第二張投影片開始編號（並隱藏第一張投影片的編號）：

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Sets the number for the first presentation slide
presentation->set_FirstSlideNumber(0);

// Shows slide numbers for all slides
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Hides the slide number for the first slide
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Saves the modified presentation
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **常見問答**

**使用者看到的投影片編號是否與集合的零基索引相同？**

投影片上顯示的編號可以從任意數值（例如 10）開始，並不必與索引相符；此關係由簡報的 [first slide number](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/set_firstslidenumber/) 設定控制。

**隱藏的投影片會影響索引嗎？**

會。隱藏的投影片仍保留於集合中，並計入索引；「隱藏」只指顯示狀態，未改變其在集合中的位置。

**當新增或移除其他投影片時，投影片的索引會改變嗎？**

會。索引永遠反映目前的投影片順序，並於插入、刪除或移動操作後重新計算。