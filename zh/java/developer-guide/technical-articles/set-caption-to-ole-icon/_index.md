---
title: 设置OLE图标的标题
type: docs
weight: 130
url: /java/set-caption-to-ole-icon/
---

新方法**getSubstitutePictureTitle**和**setSubstitutePictureTitle**已添加到**IOleObjectFrame**接口和**OleObjectFrame**类中。它允许获取、设置或更改OLE图标的标题。下面的代码片段展示了如何创建Excel对象并设置其标题的示例。

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// 向幻灯片添加OLE对象
byte[] allBytes = Files.readAllBytes(Paths.get("oleSourceFile.xlsx"));
OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(allBytes, "xlsx");

IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);

// 向演示文稿的图像集合添加图像
IImage image = Images.fromFile("oleIconFile.ico");
IPPImage ppImage = presentation.getImages().addImage(image);
image.dispose();

// 将图像设置为OLE对象的图标
oleFrame.setObjectIcon(true);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(ppImage);

// 设置OLE图标的标题
oleFrame.setSubstitutePictureTitle("标题示例");
```