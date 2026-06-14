---
title: 使用現代 API 強化影像處理
linktitle: 現代 API
type: docs
weight: 280
url: /zh-hant/cpp/modern-api/
keywords:
- System.Drawing
- 現代 API
- 繪圖
- 投影片縮圖
- 投影片轉影像
- 圖形縮圖
- 圖形轉影像
- 簡報縮圖
- 簡報轉影像
- 新增影像
- 新增圖片
- C++
- Aspose.Slides
description: "透過使用 C++ 現代 API 取代已棄用的影像 API，現代化投影片影像處理，實現 PowerPoint 與 OpenDocument 的無縫自動化。"
---
## **簡介**

目前，Aspose.Slides for C++ 函式庫在其公開 API 中依賴於 System::Drawing 的以下類別：
- [System::Drawing::Graphics](https://reference.aspose.com/slides/zh-hant/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/zh-hant/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/zh-hant/cpp/system.drawing/bitmap/)

自 24.4 版起，這些公共 API 已被標示為已棄用。

為了在公共 API 中去除對 System::Drawing 的依賴，我們加入了所謂的「現代 API」。使用 [System::Drawing::Image] 和 [System::Drawing::Bitmap] 的方法已被標示為已棄用，應改為使用現代 API 中對應的方法。使用 [System::Drawing::Graphics] 的方法已被標示為已棄用，且沒有直接的現代 API 取代方案。

在目前的版本中，請將依賴 System::Drawing 類型的公共 API 視為遺留/已棄用。對新程式碼以及遷移現有影像處理工作流程時，請使用現代 API。

## **現代 API**

在公共 API 中新增了以下類別和列舉：

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/) - 代表點陣或向量影像。
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imageformat/) - 代表影像的檔案格式。
- [Aspose::Slides::Images](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/images/) - 用於建立並操作 [IImage] 介面的相關方法。

使用 `GetImage` 來呈現單一投影片或圖形。使用 `GetImages` 來呈現多張投影片。使用 [Images] 方法載入影像，使用 `AddImage` 搭配 [IImage] 將影像加入簡報，並使用 `ReplaceImage` 搭配 [IImage] 更新簡報中已存在的影像。

以下是一個使用新 API 的典型情境範例：

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// 從磁碟上的檔案實例化一個可處置的 IImage 實例。  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// 透過將 IImage 實例加入簡報的影像集合，建立 PowerPoint 影像。
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// 在投影片 #1 上新增圖片圖形
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// 取得代表投影片 #1 的 IImage 實例。
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// 將影像儲存至磁碟。
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **使用現代 API 取代舊程式碼**

為了方便過渡，新的 [IImage] 介面重複了 [System::Drawing::Image] 與 [System::Drawing::Bitmap] 類別的各自簽章。一般而言，只需要將使用 System::Drawing 的舊方法呼叫替換為新的即可。

### **取得投影片縮圖**

Legacy/deprecated API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **取得圖形縮圖**

Legacy/deprecated API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **取得簡報縮圖**

Legacy/deprecated API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto images = pres->GetImages(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < images->get_Length(); index++)
{
    System::SharedPtr<IImage> thumbnail = images[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), Aspose::Slides::ImageFormat::Png);
}
```

### **將圖片加入簡報**

Legacy/deprecated API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

## **已棄用的方法/屬性及其在現代 API 中的取代方案**

### **Presentation 類別**
|方法簽章|取代方法簽章|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **Slide 類別**
|方法簽章|取代方法簽章|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|No Modern API replacement|

### **Shape 類別**
|方法簽章|取代方法簽章|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **ImageCollection 類別**
|方法簽章|取代方法簽章|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **PPImage 類別**
|方法簽章|取代方法簽章|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **PatternFormat 類別**
|方法簽章|取代方法簽章|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **IPatternFormatEffectiveData 類別**
|方法簽章|取代方法簽章|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **支援 System::Drawing::Graphics 的 API**

使用 [System::Drawing::Graphics](https://reference.aspose.com/slides/zh-hant/cpp/system.drawing/graphics/) 的方法已被標示為已棄用，且沒有直接的現代 API 取代方案。

請改用現代 API 的影像渲染方法，而非渲染至 [System::Drawing::Graphics](https://reference.aspose.com/slides/zh-hant/cpp/system.drawing/graphics/) 的 API：
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **常見問題**

**為何捨棄 [System::Drawing::Graphics]？**

支援 [System::Drawing::Graphics](https://reference.aspose.com/slides/zh-hant/cpp/system.drawing/graphics/) 已在公共 API 中被棄用，以統一渲染與影像的工作流程、消除對平台特定相依性，並以跨平台的 [IImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/) 取代。請改用 `GetImage` 或 `GetImages` 而非渲染至 [System::Drawing::Graphics](https://reference.aspose.com/slides/zh-hant/cpp/system.drawing/graphics/)。

**[IImage] 相較於 [System::Drawing::Image]/[System::Drawing::Bitmap] 有何實際好處？**

[IImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/) 統一了點陣與向量影像的操作，透過 [ImageFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imageformat/) 簡化多種格式的儲存，減少對 `System::Drawing` 的依賴，讓程式碼在不同環境間更具可移植性。

**現代 API 會影響產生縮圖的效能嗎？**

將 `GetThumbnail` 換成 `GetImage` 不會使情境變差：新方法在提供相同選項與尺寸產生影像的功能，同時保留渲染選項的支援。具體的效能提升或下降取決於使用情境，但功能上兩者是等價的。