---
title: 计算幻灯片数量
type: docs
weight: 50
url: /zh/net/count-the-number-of-slides/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "计算幻灯片数量.pptx";

Console.WriteLine("幻灯片数量 = {0}",

CountSlides(FileName));

Console.ReadKey();

// 获取演示文档对象并传递给下一个 CountSlides 方法。

public static int CountSlides(string presentationFile)

{

    // 以只读方式打开演示文档。

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // 将演示文档传递给下一个 CountSlide 方法

        // 并返回幻灯片数量。

        return CountSlides(presentationDocument);

    }

}

// 计算演示文档中的幻灯片。

public static int CountSlides(PresentationDocument presentationDocument)

{

    // 检查文档对象是否为 null。

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // 获取文档的演示部分。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 从 SlideParts 获取幻灯片数量。

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // 将幻灯片数量返回给上一个方法。

    return slidesCount;

} 

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "计算幻灯片数量.pptx";

Console.WriteLine("幻灯片数量 = {0}",

CountSlides(FileName));

Console.ReadKey();

public static int CountSlides(string presentationFile)

{

  // 实例化一个表示 PPTX 文件的 PresentationEx 对象

  using (Presentation pres = new Presentation(presentationFile))

  {

     return pres.Slides.Count;

  }

}  

``` 
## **下载示例代码**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Count%20the%20number%20of%20Slides%20\(Aspose.Slides\).zip)