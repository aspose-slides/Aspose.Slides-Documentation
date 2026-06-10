---
title: Képfeldolgozás fejlesztése a Modern API-val
linktitle: Modern API
type: docs
weight: 280
url: /hu/cpp/modern-api/
keywords:
- System.Drawing
- modern API
- rajzolás
- dia bélyegkép
- dia képpé alakítása
- alakzat bélyegkép
- alakzat képpé alakítása
- prezentáció bélyegkép
- prezentáció képekké alakítása
- kép hozzáadása
- kép beszúrása
- C++
- Aspose.Slides
description: "Modernizálja a dia képfeldolgozást az elavult képalkotó API-k C++ Modern API-val történő helyettesítésével a zökkenőmentes PowerPoint és OpenDocument automatizálás érdekében."
---
## **Bevezetés**

Jelenleg az Aspose.Slides for C++ könyvtár nyilvános API-ja függ a System::Drawing alábbi osztályaitól:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/hu/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/hu/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/hu/cpp/system.drawing/bitmap/)

A 24.4-es verziótól ez a nyilvános API elavultnak lett nyilvánítva.

Az API-ban a System::Drawing függőségek megszüntetése érdekében bevezettük a úgynevezett „Modern API”-t. A [System::Drawing::Image](https://reference.aspose.com/slides/hu/cpp/system.drawing/image/) és a [System::Drawing::Bitmap](https://reference.aspose.com/slides/hu/cpp/system.drawing/bitmap/) használatával írt metódusok elavultnak vannak jelölve, és a Modern API megfelelő metódusaival kell helyettesíteni őket. A [System::Drawing::Graphics](https://reference.aspose.com/slides/hu/cpp/system.drawing/graphics/) használatával írt metódusok szintén elavultak, és nincs közvetlen Modern API helyettesítőjük.

A jelenlegi verziókban tekintse a System::Drawing típusokra támaszkodó nyilvános API-t régi/elhagyottnak. Új kódokhoz és a meglévő képfeldolgozó munkafolyamatok migrálásához használja a Modern API-t.

## **Modern API**

A nyilvános API-hoz a következő osztályok és enumok lettek hozzáadva:

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) – reprezentálja a raszteres vagy vektoriális képet.
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imageformat/) – reprezentálja a kép fájlformátumát.
- [Aspose::Slides::Images](https://reference.aspose.com/slides/hu/cpp/aspose.slides/images/) – metódusok az [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) interfész példányosításához és használatához.

Használja a `GetImage` metódust egyetlen dia vagy alakzat rendereléséhez. A `GetImages` metódus több prezentációs dia rendereléséhez szolgál. Használja a [Images](https://reference.aspose.com/slides/hu/cpp/aspose.slides/images/) metódusait képek betöltéséhez, a `AddImage`-et [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) segítségével a prezentációhoz való hozzáadáshoz, valamint a `ReplaceImage`-et [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) használatával egy meglévő prezentációs kép frissítéséhez.

Egy tipikus szituáció az új API használatára a következő lehet:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// példányosít egy eldobható IImage példányt a lemezen lévő fájlból.
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// létrehoz egy PowerPoint képet az IImage példány prezentáció képekhez való hozzáadásával.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// képkocka alakzat hozzáadása az 1. diára
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// lekéri az IImage példányt, amely az 1. diát képviseli.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// menti a képet a lemezre.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **A régi kód Modern API-val való helyettesítése**

Az átállás megkönnyítése érdekében az új [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) felülete megismétli a [System::Drawing::Image](https://reference.aspose.com/slides/hu/cpp/system.drawing/image/) és a [System::Drawing::Bitmap](https://reference.aspose.com/slides/hu/cpp/system.drawing/bitmap/) osztályok különálló aláírásait. Általában csak a System::Drawing használatával írt régi metódushívást kell az újval felcserélni.

### **Dia előnézetének lekérése**

Legacy/elavult API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **Alakzat előnézetének lekérése**

Legacy/elavult API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **Prezentáció előnézetének lekérése**

Legacy/elavult API:

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

### **Kép hozzáadása a prezentációhoz**

Legacy/elavult API:

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

## **Elavult metódusok/tulajdonságok és azok Modern API helyettesítői**

### **Presentation osztály**
|Metódus aláírás|Helyettesítő metódus aláírás|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **Slide osztály**
|Metódus aláírás|Helyettesítő metódus aláírás|
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

### **Shape osztály**
|Metódus aláírás|Helyettesítő metódus aláírás|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **ImageCollection osztály**
|Metódus aláírás|Helyettesítő metódus aláírás|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **PPImage osztály**
|Metódus aláírás|Helyettesítő metódus aláírás|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **PatternFormat osztály**
|Metódus aláírás|Helyettesítő metódus aláírás|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **IPatternFormatEffectiveData osztály**
|Metódus aláírás|Helyettesítő metódus aláírás|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **API támogatás a System::Drawing::Graphics számára**

A [System::Drawing::Graphics](https://reference.aspose.com/slides/hu/cpp/system.drawing/graphics/) használatával írt metódusok elavultak, és nincs közvetlen Modern API helyettesítőjük.

Használja a Modern API képrenderelő metódusait a [System::Drawing::Graphics](https://reference.aspose.com/slides/hu/cpp/system.drawing/graphics/) felé történő renderelés helyett:
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slide/rendertgraphics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **GYIK**

**Miért lett elhagyva a [System::Drawing::Graphics](https://reference.aspose.com/slides/hu/cpp/system.drawing/graphics/)?**

A [System::Drawing::Graphics](https://reference.aspose.com/slides/hu/cpp/system.drawing/graphics/) támogatása elavult a nyilvános API-ban, hogy egységesítsük a renderelést és a képek kezelését, megszüntessük a platform‑specifikus függőségeket, és egy cross‑platform megközelítést alkalmazzunk az [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) segítségével. Használja a `GetImage` vagy `GetImages` metódusokat a [System::Drawing::Graphics](https://reference.aspose.com/slides/hu/cpp/system.drawing/graphics/) felé történő renderelés helyett.

**Mi a gyakorlati előnye az [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) használatának a [System::Drawing::Image](https://reference.aspose.com/slides/hu/cpp/system.drawing/image/)/[System::Drawing::Bitmap](https://reference.aspose.com/slides/hu/cpp/system.drawing/bitmap/) helyett?**

Az [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) egységesíti a raszteres és vektoriális képek kezelését, egyszerűsíti a különböző formátumok mentését az [ImageFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imageformat/) segítségével, csökkenti a `System::Drawing` függőséget, és kódbázisát hordozhatóbbá teszi a különböző környezetek között.

**A Modern API befolyásolja a bélyegképek generálásának teljesítményét?**

A `GetThumbnail`‑ról `GetImage`‑re való átállás nem rontja a teljesítményt: az új metódusok ugyanazokat a lehetőségeket biztosítják a képek opciókkal és méretekkel történő előállításához, miközben megőrzik a renderelési opciók támogatását. A konkrét nyereség vagy veszteség a szituációtól függ, de funkcionálisan a helyettesítők ekvivalensek.