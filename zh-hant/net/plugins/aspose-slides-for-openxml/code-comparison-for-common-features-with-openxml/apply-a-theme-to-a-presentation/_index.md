---
title: 套用佈景主題至簡報
type: docs
weight: 30
url: /zh-hant/net/apply-a-theme-to-a-presentation/
---
## **OpenXML 簡報**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// 套用新佈景主題至簡報。

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// 套用新佈景主題至簡報。

public static void ApplyThemeToPresentation(PresentationDocument presentationDocument, PresentationDocument themeDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (themeDocument == null)

    {

        throw new ArgumentNullException("themeDocument");

    }

    // 取得簡報文件的簡報部件。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 取得現有的投影片母片部件。

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // 取得新的投影片母片部件。

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // 移除現有的佈景部件。

    presentationPart.DeletePart(presentationPart.ThemePart);

    // 移除舊的投影片母片部件。

    presentationPart.DeletePart(slideMasterPart);

    // 匯入新的投影片母片部件，並重新使用舊的關係 ID。

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // 切換為新的佈景部件。

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // 插入此範例的版面配置程式碼。

    string defaultLayoutType = "Title and Content";

    // 移除所有投影片的投影片版面關係。

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // 判斷每張投影片的版面配置類型。

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // 刪除舊的版面部件。

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // 套用新的版面部件。

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // 套用新的預設版面部件。

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// 取得投影片版面類型。

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // 備註：如果此程式碼用於正式環境，請檢查是否為 null 參考。

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
為了套用佈景主題，我們需要連同母片一起複製投影片，請按照以下步驟操作：

- 建立一個 Presentation 類別的實例，該實例包含將要從中複製投影片的來源簡報。
- 建立一個 Presentation 類別的實例，該實例包含將要複製投影片的目標簡報。
- 存取要複製的投影片以及其母片。
- 透過參考目標簡報的 Presentation 物件所公開的 Masters 集合，實例化 IMasterSlideCollection 類別。
- 呼叫 IMasterSlideCollection 物件所公開的 AddClone 方法，並將來源 PPTX 中要複製的母片作為參數傳入 AddClone 方法。
- 透過設定參考目標簡報的 Presentation 物件所公開的 Slides 集合，實例化 ISlideCollection 類別。
- 呼叫 ISlideCollection 物件所公開的 AddClone 方法，並將來源簡報中要複製的投影片以及母片作為參數傳入 AddClone 方法。
- 寫入已修改的目標簡報檔案。

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    // 實例化 Presentation 類別以載入來源簡報檔案
    Presentation srcPres = new Presentation(presentationFile);

    // 實例化 Presentation 類別以用於目標簡報（投影片將被複製的地方）
    Presentation destPres = new Presentation(outputFile);

    // 從來源簡報的投影片集合中實例化 ISlide，並附帶
    // 母片
    ISlide SourceSlide = srcPres.Slides[0];

    // 從來源簡報中複製所需的母片至主片集合中
    // 目標簡報
    IMasterSlideCollection masters = destPres.Masters;

    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

    // 從來源簡報中複製所需的母片至主片集合中
    // 目標簡報
    IMasterSlide iSlide = masters.AddClone(SourceMaster);

    // 從來源簡報中以所需的母片複製所需的投影片至目標簡報的投影片集合末端
    // 目標簡報的投影片集合
    ISlideCollection slds = destPres.Slides;

    slds.AddClone(SourceSlide, iSlide, true);

    // 從來源簡報中複製所需的母片至主片集合中 // 目標簡報
    // 將目標簡報儲存至磁碟
    destPres.Save(outputFile, SaveFormat.Pptx);

}
``` 
## **下載執行範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)