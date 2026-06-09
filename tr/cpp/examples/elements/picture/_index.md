---
title: Resim
type: docs
weight: 50
url: /tr/cpp/examples/elements/picture/
keywords:
- kod örneği
- resim
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ içinde resimlerle çalışın: ekleme, kırpma, sıkıştırma, yeniden renklendirme ve C++ örnekleriyle PPT, PPTX ve ODP sunumları için görüntüleri dışa aktarma."
---
Bu makale, **Aspose.Slides for C++** kullanarak bellek içi görüntülerden resim ekleme ve erişme yöntemlerini gösterir. Aşağıdaki örnekler bir görüntüyü bellekte oluşturur, slayta yerleştirir ve ardından alır.

## **Resim Ekle**

Bu kod küçük bir bitmap oluşturur, onu bir akışa dönüştürür ve ilk slaytta bir resim çerçevesi olarak ekler.

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Basit bir bellek içi görüntü oluştur.
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // Bitmap'i bayt dizisine dönüştür.
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // Görüntüyü sunuma ekle.
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // İlk slaytta görüntüyü gösteren bir resim çerçevesi ekle.
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **Resme Erişim**

Bu örnek bir slaytın bir resim çerçevesi içerdiğini doğrular ve ardından bulduğu ilk çerçeveye erişir.

```cpp
static void AccessPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto bitmap = MakeObject<Bitmap>(40, 40, PixelFormat::Format32bppArgb);
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0, 0, 40, 40, image);

    auto pictureFrame = SharedPtr<IPictureFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            pictureFrame = ExplicitCast<IPictureFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```