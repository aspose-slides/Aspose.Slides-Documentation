---
title: "Vylepšete zpracování obrázků pomocí Moderního API"
linktitle: "Moderní API"
type: docs
weight: 280
url: /cs/cpp/modern-api/
keywords:
- System.Drawing
- moderní API
- kreslení
- miniatura snímku
- snímek na obrázek
- miniatura tvaru
- tvar na obrázek
- miniatura prezentace
- prezentace na obrázky
- přidat obrázek
- přidat obrázek
- C++
- Aspose.Slides
description: "Modernizujte zpracování obrázků snímků nahrazením zastaralých API pro obrazy Moderním C++ API pro plynulou automatizaci PowerPointu a OpenDocument."
---
## **Úvod**

V současné době má knihovna Aspose.Slides pro C++ závislosti ve svém veřejném rozhraní na následující třídy ze System::Drawing:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/cs/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/cs/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/cs/cpp/system.drawing/bitmap/)

Od verze 24.4 je toto veřejné rozhraní označeno jako zastaralé.

Abychom se zbavili závislostí na System::Drawing ve veřejném rozhraní, přidali jsme takzvané „Moderní API“. Metody s [System::Drawing::Image](https://reference.aspose.com/slides/cs/cpp/system.drawing/image/) a [System::Drawing::Bitmap](https://reference.aspose.com/slides/cs/cpp/system.drawing/bitmap/) jsou označeny jako zastaralé a měly by být nahrazeny odpovídajícími metodami z Moderního API. Metody s [System::Drawing::Graphics](https://reference.aspose.com/slides/cs/cpp/system.drawing/graphics/) jsou označeny jako zastaralé a nemají přímou náhradu v Moderním API.

V aktuálních verzích považujte veřejné rozhraní, které závisí na typech System::Drawing, za legacy/zastaralé. Pro nový kód a při migraci existujících workflow pro zpracování obrázků používejte Moderní API.

## **Moderní API**

Do veřejného rozhraní byly přidány následující třídy a výčty:

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/) – představuje rastrový nebo vektorový obrázek.
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imageformat/) – představuje formát souboru obrázku.
- [Aspose::Slides::Images](https://reference.aspose.com/slides/cs/cpp/aspose.slides/images/) – metody pro vytvoření a práci s rozhraním [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/).

Použijte `GetImage` pro vykreslení jednoho snímku nebo tvaru. Použijte `GetImages` pro vykreslení několika snímků prezentace. Použijte metody [Images](https://reference.aspose.com/slides/cs/cpp/aspose.slides/images/) k načtení obrázků, `AddImage` s [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/) pro jejich přidání do prezentace a `ReplaceImage` s [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/) pro aktualizaci existujícího obrázku v prezentaci.

Typický scénář použití nového API může vypadat následovně:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// vytvořit odpadatelnou instanci IImage ze souboru na disku.
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// vytvořit PowerPoint obrázek přidáním instance IImage do obrázků prezentace.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// přidat obrázkový tvar na snímek #1
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// získat instanci IImage představující snímek #1.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// uložit obrázek na disk.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **Nahrazení starého kódu Moderním API**

Pro usnadnění přechodu rozhraní nového [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/) opakuje samostatné podpisy tříd [System::Drawing::Image](https://reference.aspose.com/slides/cs/cpp/system.drawing/image/) a [System::Drawing::Bitmap](https://reference.aspose.com/slides/cs/cpp/system.drawing/bitmap/). V zásadě stačí nahradit volání staré metody používající System::Drawing novou metodou.

### **Získání miniatury snímku**

Zastaralé/deprekované API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

Moderní API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **Získání miniatury tvaru**

Zastaralé/deprekované API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

Moderní API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **Získání miniatury prezentace**

Zastaralé/deprekované API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```

Moderní API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto images = pres->GetImages(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < images->get_Length(); index++)
{
    System::SharedPtr<IImage> thumbnail = images[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), Aspose::Slides::ImageFormat::Png);
}
```

### **Přidání obrázku do prezentace**

Zastaralé/deprekované API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

Moderní API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

## **Zastaralé metody/vlastnosti a jejich náhrady v Moderním API**

### **Třída Presentation**
|Podpis metody|Podpis náhradní metody|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **Třída Slide**
|Podpis metody|Podpis náhradní metody|
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

### **Třída Shape**
|Podpis metody|Podpis náhradní metody|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **Třída ImageCollection**
|Podpis metody|Podpis náhradní metody|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **Třída PPImage**
|Podpis metody|Podpis náhradní metody|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **Třída PatternFormat**
|Podpis metody|Podpis náhradní metody|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **Třída IPatternFormatEffectiveData**
|Podpis metody|Podpis náhradní metody|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **Podpora API pro System::Drawing::Graphics**

Metody s [System::Drawing::Graphics](https://reference.aspose.com/slides/cs/cpp/system.drawing/graphics/) jsou označeny jako zastaralé a nemají přímou náhradu v Moderním API.

Použijte moderní metody pro vykreslování obrázků místo API, které vykresluje do [System::Drawing::Graphics](https://reference.aspose.com/slides/cs/cpp/system.drawing/graphics/):
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **Často kladené otázky**

**Proč byl [System::Drawing::Graphics](https://reference.aspose.com/slides/cs/cpp/system.drawing/graphics/) odstraněn?**

Podpora pro [System::Drawing::Graphics](https://reference.aspose.com/slides/cs/cpp/system.drawing/graphics/) je v veřejném rozhraní zastaralá, aby se sjednotila práce s vykreslováním a obrázky, odstranily se vazby na platformově specifické závislosti a přešlo se na multiplatformní přístup s [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/). Používejte `GetImage` nebo `GetImages` místo vykreslování do [System::Drawing::Graphics](https://reference.aspose.com/slides/cs/cpp/system.drawing/graphics/).

**Jaký je praktický přínos [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/) oproti [System::Drawing::Image](https://reference.aspose.com/slides/cs/cpp/system.drawing/image/)/[System::Drawing::Bitmap](https://reference.aspose.com/slides/cs/cpp/system.drawing/bitmap/)?**

[IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/) sjednocuje práci s rastrovými i vektorovými obrázky, zjednodušuje ukládání do různých formátů pomocí [ImageFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imageformat/), snižuje závislost na `System::Drawing` a činí kód přenosnějším napříč prostředími.

**Ovlivní Moderní API výkon generování miniatur?**

Přechod z `GetThumbnail` na `GetImage` nesnižuje výkon: nové metody poskytují stejné možnosti pro vytváření obrázků s volbami a velikostmi a nadále podporují možnosti vykreslování. Konkrétní zisk či ztráta závisí na scénáři, ale funkčně jsou náhrady ekvivalentní.