---
title: 將投影片移至新位置
type: docs
weight: 140
url: /zh-hant/net/move-a-slide-to-a-new-position/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// 計算簡報中的投影片數量。

public static int CountSlides(string presentationFile)

{

    // 以唯讀方式開啟簡報。

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // 將簡報傳遞給下一個 CountSlides 方法

        // 並回傳投影片數量。

        return CountSlides(presentationDocument);

    }

}

// 計算簡報中的投影片數量。

public static int CountSlides(PresentationDocument presentationDocument)

{

    // 檢查文件物件是否為 null。

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // 取得文件的簡報部分。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 從 SlideParts 取得投影片數量。

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // 將投影片數量回傳給先前的方法。

    return slidesCount;

}

// 將投影片移動至簡報中投影片順序的不同位置。

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// 將投影片移動至簡報中投影片順序的不同位置。

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // 呼叫 CountSlides 方法以取得簡報中的投影片數量。

    int slidesCount = CountSlides(presentationDocument);

    // 驗證 from 與 to 位置皆在範圍內且彼此不同。

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // 從簡報文件取得簡報部分。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 投影片數量不是零，因此簡報必須包含投影片。            

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // 取得來源投影片的 ID。

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // 確定目標投影片的位置，於其之後移動來源投影片。

    if (to == 0)

    {

        targetSlide = null;

    }

    if (from < to)

    {

        targetSlide = slideIdList.ChildElements[to] as SlideId;

    }

    else

    {

        targetSlide = slideIdList.ChildElements[to - 1] as SlideId;

    }

    // 從目前位置移除來源投影片。

    sourceSlide.Remove();

    // 將來源投影片插入於目標投影片之後的新位置。

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // 儲存已修改的簡報。

    presentation.Save();

} 
``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// 將投影片移動至簡報中投影片順序的不同位置。

public static void MoveSlide(string presentationFile, int from, int to)

{

    // 實例化 PresentationEx 類別以載入來源 PPTX 檔案

    using (Presentation pres = new Presentation(presentationFile))

    {

        // 取得要變更位置的投影片

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        // 為投影片設定新位置

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        // 將 PPTX 寫入磁碟

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}
``` 
## **下載範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position/)