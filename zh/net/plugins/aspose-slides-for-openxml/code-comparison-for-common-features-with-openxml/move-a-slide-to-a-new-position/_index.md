---
title: 移动幻灯片到新位置
type: docs
weight: 140
url: /net/move-a-slide-to-a-new-position/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// 计算演示文稿中的幻灯片数量。

public static int CountSlides(string presentationFile)

{

    // 以只读方式打开演示文稿。

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // 将演示文稿传递给下一个 CountSlides 方法

        // 并返回幻灯片数量。

        return CountSlides(presentationDocument);

    }

}

// 计算演示文稿中的幻灯片。

public static int CountSlides(PresentationDocument presentationDocument)

{

    // 检查文档对象是否为空。

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // 获取文档的演示文稿部分。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 从 SlideParts 中获取幻灯片数量。

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // 返回幻灯片数量给上一个方法。

    return slidesCount;

}

// 将幻灯片移动到演示文稿中幻灯片顺序的不同位置。

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// 将幻灯片移动到演示文稿中幻灯片顺序的不同位置。

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // 调用 CountSlides 方法以获取演示文稿中的幻灯片数量。

    int slidesCount = CountSlides(presentationDocument);

    // 验证 from 和 to 位置均在范围内且不相同。

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // 从演示文稿文档中获取演示文稿部分。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 幻灯片数量不为零，因此演示文稿必须包含幻灯片。            	

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // 获取源幻灯片的幻灯片 ID。

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // 确定移动源幻灯片后目标幻灯片的位置。

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

    // 从当前 position 中移除源幻灯片。

    sourceSlide.Remove();

    // 在目标幻灯片之后插入源幻灯片到新位置。

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // 保存修改后的演示文稿。

    presentation.Save();

} 

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// 将幻灯片移动到演示文稿中幻灯片顺序的不同位置。

public static void MoveSlide(string presentationFile, int from, int to)

{

    //实例化 PresentationEx 类以加载源 PPTX 文件

    using (Presentation pres = new Presentation(presentationFile))

    {

        // 获取要更改位置的幻灯片

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        // 设置幻灯片的新位置

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        // 将 PPTX 写入磁盘

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **下载示例代码**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Move%20a%20slide%20to%20a%20new%20position%20\(Aspose.Slides\).zip)