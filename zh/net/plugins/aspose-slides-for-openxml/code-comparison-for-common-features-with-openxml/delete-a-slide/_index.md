---
title: 删除幻灯片
type: docs
weight: 80
url: /net/delete-a-slide/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "删除幻灯片.pptx";

DeleteSlide(FileName, 1);

// 获取演示文稿对象并将其传递给下一个 DeleteSlide 方法。

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // 打开源文档以进行读/写。

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // 将源文档和要删除的幻灯片的索引传递给下一个 DeleteSlide 方法。

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// 从演示文稿中删除指定幻灯片。

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // 使用 CountSlides 示例获取演示文稿中的幻灯片数量。

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // 从演示文稿文档中获取演示文稿部分。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 从演示文稿部分获取演示文稿。

    Presentation presentation = presentationPart.Presentation;

    // 获取演示文稿中幻灯片 ID 的列表。

    SlideIdList slideIdList = presentation.SlideIdList;

    // 获取指定幻灯片的幻灯片 ID

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // 获取幻灯片的关系 ID。

    string slideRelId = slideId.RelationshipId;

    // 从幻灯片列表中移除幻灯片。

    slideIdList.RemoveChild(slideId);

    //

    // 从所有自定义放映中移除对幻灯片的引用。

    if (presentation.CustomShowList != null)

    {

        // 遍历自定义放映列表。

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // 声明一个幻灯片列表条目的链接列表。

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // 查找要从自定义放映中移除的幻灯片引用。

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // 从自定义放映中移除所有对幻灯片的引用。

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // 保存修改后的演示文稿。

    presentation.Save();

    // 获取指定幻灯片的幻灯片部分。

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // 移除幻灯片部分。

    presentationPart.DeletePart(slidePart);

}

// 获取演示文稿对象并将其传递给下一个 CountSlides 方法。

public static int CountSlides(string presentationFile)

{

    // 以只读模式打开演示文稿。

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // 将演示文稿传递给下一个 CountSlide 方法

        // 并返回幻灯片数量。

        return CountSlides(presentationDocument);

    }

}

// 计算演示文稿中的幻灯片。

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

string FileName = FilePath + "删除幻灯片.pptx";

DeleteSlide(FileName, 1);

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    //实例化一个表示 PPTX 文件的 PresentationEx 对象

    using (Presentation pres = new Presentation(presentationFile))

    {

        //通过索引访问幻灯片

        ISlide slide = pres.Slides[slideIndex];


        //通过引用移除幻灯片

        pres.Slides.Remove(slide);


        //将演示文稿写入 PPTX 文件

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **下载示例代码**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/删除幻灯片%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/删除幻灯片%20\(Aspose.Slides\).zip)
