---
title: 計算投影片的數量
type: docs
weight: 50
url: /zh-hant/net/count-the-number-of-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

// 取得簡報物件並將其傳遞給下一個 CountSlides 方法。

public static int CountSlides(string presentationFile)

{

    // 以唯讀模式開啟簡報。

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // 將簡報傳遞給下一個 CountSlide 方法

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

    // 將投影片數量回傳給前一個方法。

    return slidesCount;

} 

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

public static int CountSlides(string presentationFile)

{

  //實例化一個代表 PPTX 檔案的 PresentationEx 物件

  using (Presentation pres = new Presentation(presentationFile))

  {

     return pres.Slides.Count;

  }

}  

``` 
## **下載示範程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides/)