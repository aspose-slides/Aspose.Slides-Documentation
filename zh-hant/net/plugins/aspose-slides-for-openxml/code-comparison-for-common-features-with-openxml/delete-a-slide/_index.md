---
title: 刪除投影片
type: docs
weight: 80
url: /zh-hant/net/delete-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

// 取得簡報物件並傳遞給下一個 DeleteSlide 方法。

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // 以讀寫模式開啟來源文件。

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // 將來源文件與欲刪除投影片的索引傳遞給下一個 DeleteSlide 方法。

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// 從簡報中刪除指定的投影片。

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // 使用 CountSlides 範例取得簡報中的投影片數量。

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // 從簡報文件取得 presentation 部分。 

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 從 presentation 部分取得簡報本體。

    Presentation presentation = presentationPart.Presentation;

    // 取得簡報中投影片 ID 的清單。

    SlideIdList slideIdList = presentation.SlideIdList;

    // 取得指定投影片的 ID

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // 取得投影片的關聯 ID。

    string slideRelId = slideId.RelationshipId;

    // 從投影片清單中移除該投影片。

    slideIdList.RemoveChild(slideId);

    //

    // 從所有自訂投影片秀中移除對該投影片的參照。

    if (presentation.CustomShowList != null)

    {

        // 遍歷自訂投影片秀的清單。

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // 宣告投影片清單項目的連結串列。

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // 找出要從自訂投影片秀中移除的投影片參照。

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // 從自訂投影片秀中移除所有對該投影片的參照。

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // 儲存已修改的簡報。

    presentation.Save();

    // 取得指定投影片的投影片部分。

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // 移除該投影片部分。

    presentationPart.DeletePart(slidePart);

}

// 取得簡報物件並傳遞給下一個 CountSlides 方法。

public static int CountSlides(string presentationFile)

{

    // 以唯讀模式開啟簡報。

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // 將簡報傳遞給下一個 CountSlide 方法

        // 並回傳投影片總數。

        return CountSlides(presentationDocument);

    }

}

// 從簡報中計算投影片數量。

public static int CountSlides(PresentationDocument presentationDocument)

{

    // 檢查文件物件是否為 null。

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // 取得文件的 presentation 部分。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 從 SlideParts 取得投影片數量。

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // 回傳投影片數量給前一個方法。

    return slidesCount;

}   

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    //實例化一個代表 PPTX 檔案的 PresentationEx 物件

    using (Presentation pres = new Presentation(presentationFile))

    {

        //使用索引存取投影片集合中的投影片

        ISlide slide = pres.Slides[slideIndex];


        //使用其參照移除投影片

        pres.Slides.Remove(slide);


        //將簡報寫入為 PPTX 檔案

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **下載範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide/)