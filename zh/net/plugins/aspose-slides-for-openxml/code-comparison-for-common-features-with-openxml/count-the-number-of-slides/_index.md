---
title: 统计幻灯片数量
type: docs
weight: 50
url: /zh/net/count-the-number-of-slides/
---

## **OpenXML SDK**
``` csharp
 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",
CountSlides(FileName));

Console.ReadKey();

// 获取演示文稿对象并将其传递给下一个 CountSlides 方法。
public static int CountSlides(string presentationFile)
{
    // 以只读方式打开演示文稿。
    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))
    {
        // 将演示文稿传递给下一个 CountSlide 方法
        // 并返回幻灯片计数。
        return CountSlides(presentationDocument);
    }
}

// 统计演示文稿中的幻灯片。
public static int CountSlides(PresentationDocument presentationDocument)
{
    // 检查文档对象是否为 null。
    if (presentationDocument == null)
    {
        throw new ArgumentNullException("presentationDocument");
    }

    int slidesCount = 0;
    // 获取文档的演示文稿部分。
    PresentationPart presentationPart = presentationDocument.PresentationPart;
    // 从 SlideParts 获取幻灯片计数。
    if (presentationPart != null)
    {
        slidesCount = presentationPart.SlideParts.Count();
    }
    // 将幻灯片计数返回给前一个方法。
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
  // 实例化一个表示 PPTX 文件的 PresentationEx 对象
  using (Presentation pres = new Presentation(presentationFile))
  {
     return pres.Slides.Count;
  }
}
``` 
## **下载示例代码**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides/)