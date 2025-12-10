---
title: 为演示文稿应用主题
type: docs
weight: 30
url: /zh/net/apply-a-theme-to-a-presentation/
---

## **OpenXML 演示文稿**
``` csharp
 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// 将新主题应用到演示文稿。

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// 将新主题应用到演示文稿。

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

    // 获取演示文稿文档的演示文稿部分。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 获取现有的幻灯片母版部分。

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // 获取新的幻灯片母版部分。

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // 删除现有的主题部分。

    presentationPart.DeletePart(presentationPart.ThemePart);

    // 删除旧的幻灯片母版部分。

    presentationPart.DeletePart(slideMasterPart);

    // 导入新的幻灯片母版部分，并复用旧的关系 ID。

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // 更换为新的主题部分。

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // 为本示例插入布局代码。

    string defaultLayoutType = "Title and Content";

    // 删除所有幻灯片上的幻灯片布局关系。

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // 确定每张幻灯片的布局类型。

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // 删除旧的布局部分。

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // 应用新的布局部分。

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // 应用新的默认布局部分。

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// 获取幻灯片布局类型。

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // 备注：如果在生产代码中使用，请检查空引用。

    return slideData.Name;

}   
``` 
## **Aspose.Slides**
为了应用主题，我们需要克隆包含母版的幻灯片，请按照以下步骤操作：

- 创建一个包含要克隆幻灯片的源演示文稿的 Presentation 类实例。
- 创建一个包含目标演示文稿的 Presentation 类实例，幻灯片将被克隆到此演示文稿中。
- 访问要克隆的幻灯片及其母版幻灯片。
- 通过引用目标演示文稿的 Presentation 对象公开的 Masters 集合，实例化 IMasterSlideCollection 类。
- 调用 IMasterSlideCollection 对象公开的 AddClone 方法，并将源 PPTX 中要克隆的母版作为参数传递给 AddClone 方法。
- 通过设置对目标演示文稿的 Presentation 对象公开的 Slides 集合的引用，实例化 ISlideCollection 类。
- 调用 ISlideCollection 对象公开的 AddClone 方法，并将源演示文稿中的幻灯片和母版幻灯片作为参数传递给 AddClone 方法。
- 将修改后的目标演示文稿文件写入磁盘。

``` csharp
 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    // 实例化 Presentation 类以加载源演示文稿文件

    Presentation srcPres = new Presentation(presentationFile);

    // 实例化 Presentation 类用于目标演示文稿（要克隆幻灯片的地方）

    Presentation destPres = new Presentation(outputFile);

    // 实例化 ISlide，从源演示文稿的幻灯片集合中获取幻灯片及其母版幻灯片

    ISlide SourceSlide = srcPres.Slides[0];

    // 将所需的母版幻灯片从源演示文稿克隆到目标演示文稿的母版集合中

    IMasterSlideCollection masters = destPres.Masters;

    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

    // 将所需的母版幻灯片从源演示文稿克隆到目标演示文稿的母版集合中

    IMasterSlide iSlide = masters.AddClone(SourceMaster);

    // 将所需的幻灯片从源演示文稿克隆到目标演示文稿的幻灯片集合末尾，并使用所克隆的母版

    ISlideCollection slds = destPres.Slides;

    slds.AddClone(SourceSlide, iSlide, true);

    // 将目标演示文稿保存到磁盘

    destPres.Save(outputFile, SaveFormat.Pptx);

}
``` 
## **下载运行代码示例**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **示例代码**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)