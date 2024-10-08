---
title: 设置OLE图标的标题
type: docs
weight: 110
url: /cpp/set-caption-to-ole-icon/
---

新增了 **get_SubstitutePictureTitle()** 和 **set_SubstitutePictureTitle()** 方法到 **IOleObjectFrame** 和 **OleObjectFrame** 类。它允许获取、设置或更改OLE图标的标题。下面的代码片段展示了创建Excel对象并设置其标题的示例。

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// 在幻灯片中添加OLE对象
auto allBytes = System::IO::File::ReadAllBytes(u"oleSourceFile.xlsx");
auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(allBytes, "xlsx");

auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);
    
// 将图像添加到演示文稿的图像集合中
auto image = Images::FromFile(u"oleIconFile.ico");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// 将图像设置为OLE对象的图标
oleFrame->set_IsObjectIcon(true);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(ppImage);

// 设置OLE图标的标题
oleFrame->set_SubstitutePictureTitle(u"标题示例");
```