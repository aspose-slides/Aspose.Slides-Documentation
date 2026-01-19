---
title: 删除幻灯片
type: docs
weight: 80
url: /zh/net/delete-a-slide/
---

## **OpenXML SDK**
``` csharp
 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

// Get the presentation object and pass it to the next DeleteSlide method.

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // 以读写模式打开源文档。

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // 将源文档和要删除的幻灯片索引传递给下一个 DeleteSlide 方法。

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// 从演示文稿中删除指定的幻灯片。

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

    // 从演示文稿文档获取 PresentationPart。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 从 PresentationPart 获取演示文稿对象。

    Presentation presentation = presentationPart.Presentation;

    // 获取演示文稿中幻灯片 ID 的列表。

    SlideIdList slideIdList = presentation.SlideIdList;

    // 获取指定幻灯片的 ID

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // 获取该幻灯片的关系 ID。

    string slideRelId = slideId.RelationshipId;

    // 从幻灯片列表中移除该幻灯片。

    slideIdList.RemoveChild(slideId);

    //

    // 从所有自定义放映中移除对该幻灯片的引用。

    if (presentation.CustomShowList != null)

    {

        // 遍历自定义放映列表。

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // 声明一个用于存放幻灯片列表项的链表。

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // 查找要从自定义放映中移除的幻灯片引用。

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // 从自定义放映中移除所有对该幻灯片的引用。

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // 保存修改后的演示文稿。

    presentation.Save();

    // 获取指定幻灯片的 SlidePart。

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // 删除该幻灯片的部件。

    presentationPart.DeletePart(slidePart);

}

// Get the presentation object and pass it to the next CountSlides method.

public static int CountSlides(string presentationFile)

{

    // 以只读模式打开演示文稿。

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // 将演示文稿传递给下一个 CountSlides 方法 // 并返回幻灯片计数。

        return CountSlides(presentationDocument);

    }

}

// 统计演示文稿中的幻灯片数量。

public static int CountSlides(PresentationDocument presentationDocument)

{

    // 检查文档对象是否为 null。

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // 获取文档的 PresentationPart。

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

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // 实例化表示 PPTX 文件的 PresentationEx 对象

    using (Presentation pres = new Presentation(presentationFile))

    {

        // 使用幻灯片集合中的索引访问幻灯片

        ISlide slide = pres.Slides[slideIndex];


        // 使用引用删除幻灯片

        pres.Slides.Remove(slide);


        // 将演示文稿写入为 PPTX 文件

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **下载示例代码**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide/)