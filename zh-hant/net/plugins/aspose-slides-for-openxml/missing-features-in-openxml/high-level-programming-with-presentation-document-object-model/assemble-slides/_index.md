---
title: 組合投影片
type: docs
weight: 10
url: /zh-hant/net/assemble-slides/
---
## **將投影片新增至簡報**
在討論如何將投影片新增至簡報檔案之前，先來了解一些關於投影片的事實。每個 PowerPoint 簡報檔案都包含母片/版面投影片以及其他普通投影片。這表示一個簡報檔案至少包含一張或多張投影片。重要的是要知道，不含投影片的簡報檔案不受 Aspose.Slides for .NET 支援。每張投影片都有唯一的 Id，所有普通投影片皆依照以零為基礎的索引順序排列。

Aspose.Slides for .NET 允許開發人員向簡報新增空白投影片。若要在簡報中新增空白投影片，請遵循以下步驟：

- 建立 **Presentation** 類別的實例
- 透過設定指向 Presentation 物件所公開的 Slides（內容 Slide 物件集合）屬性的參考，實例化 **SlideCollection** 類別
- 呼叫 **SlideCollection** 物件所公開的 **AddEmptySlide** 方法，將空白投影片新增至內容投影片集合的末端
- 對新加入的空白投影片執行一些操作
- 最後，使用 **Presentation** 物件寫入簡報檔案

``` csharp

 PresentationEx pres = new PresentationEx();

//實例化 SlideCollection 類別

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//將空白投影片新增至 Slides 集合

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//將 PPTX 檔案儲存至磁碟

pres.Write("EmptySlide.pptx");

``` 
## **存取簡報的投影片**
Aspose.Slides for .NET 提供了 Presentation 類別，可用於尋找並存取簡報中任何所需的投影片。

**使用 Slides 集合**

**Presentation** 類別代表簡報檔案，將其中的所有投影片以 **SlideCollection** 集合（即 **Slide** 物件的集合）公開。所有這些投影片皆可透過此 **Slides** 集合並以投影片索引存取。

``` csharp

 //實例化一個代表簡報檔案的 Presentation 物件
PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");
//使用投影片索引存取投影片
SlideEx slide = pres.Slides[0];

``` 
## **移除投影片**
我們知道 **Aspose.Slides for .NET** 中的 Presentation 類別代表簡報檔案。Presentation 類別封裝了一個 **SlideCollection**，作為所有屬於簡報之投影片的儲存庫。開發人員可以透過兩種方式從此 Slides 集合中移除投影片：

- 使用投影片參考
- 使用投影片索引

**使用投影片參考**

若要使用投影片參考移除投影片，請遵循以下步驟：

- 建立 Presentation 類別的實例
- 使用其 Id 或 Index 取得投影片的參考
- 從簡報中移除該參考的投影片
- 寫入已修改的簡報檔案

``` csharp

 //實例化一個代表簡報檔案的 Presentation 物件
PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");
//使用投影片集合中的索引存取投影片
SlideEx slide = pres.Slides[0];
//使用投影片參考移除投影片
pres.Slides.Remove(slide);
//寫入簡報檔案
pres.Write("modified.pptx");

``` 
## **變更投影片的位置**
變更簡報中投影片的位置非常簡單。只需遵循下列步驟：

- 建立 Presentation 類別的實例
- 使用其 Index 取得投影片的參考
- 變更該參考投影片的 SlideNumber
- 寫入已修改的簡報檔案

在下方示例中，我們將簡報中位於零索引位置 1 的投影片位置變更為索引 1（位置 2）。

``` csharp

 private static string MyDir = @"..\..\..\Sample Files\";

static void Main(string[] args)

{

AddingSlidetoPresentation();

AccessingSlidesOfPresentation();

RemovingSlides();

ChangingPositionOfSlide();

}

public static void AddingSlidetoPresentation()

{

Presentation pres = new Presentation();

//實例化 SlideCollection 類別

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //將空白投影片新增至 Slides 集合

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//將 PPTX 檔案儲存至磁碟

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//實例化一個代表簡報檔案的 Presentation 物件

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//使用投影片索引存取投影片

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//實例化一個代表簡報檔案的 Presentation 物件

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//使用投影片集合中的索引存取投影片

ISlide slide = pres.Slides[0];

//使用投影片參考移除投影片

pres.Slides.Remove(slide);

//寫入簡報檔案

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//實例化 Presentation 類別以載入來源簡報檔案

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //取得欲變更位置的投影片

    ISlide sld = pres.Slides[0];

    //設定投影片的新位置

    sld.SlideNumber = 2;

    //將簡報寫入磁碟

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **下載範例程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)