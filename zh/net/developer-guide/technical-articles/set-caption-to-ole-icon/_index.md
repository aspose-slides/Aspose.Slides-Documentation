---
title: 设置OLE图标的标题
type: docs
weight: 160
url: /zh/net/set-caption-to-ole-icon/
---

新增了一个属性**SubstitutePictureTitle**到**IOleObjectFrame**接口和**OleObjectFrame**类。它允许获取、设置或更改OLE图标的标题。下面的代码片段展示了创建Excel对象并设置其标题的示例。

```csharp
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    // 添加OLE对象
    byte[] allbytes = File.ReadAllBytes("oleSourceFile.xlsx");
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(allbytes, "xlsx");

    IOleObjectFrame oof = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);
    oof.IsObjectIcon = true;

    // 添加图像对象
    byte[] imgBuf = File.ReadAllBytes("oleIconFile.ico");
    IPPImage image = pres.Images.AddImage(imgBuf);

    oof.SubstitutePictureFormat.Picture.Image = image;

    // 设置OLE图标的标题
    oof.SubstitutePictureTitle = "标题示例";
}
```