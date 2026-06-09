---
title: Sunum Slaytlarını C++ ile Görüntülere Dönüştür
linktitle: Slayttan Görüntüye
type: docs
weight: 41
url: /tr/cpp/convert-slide/
keywords:
- slaytı dönüştür
- slaytı dışa aktar
- slayttan görüntüye
- slaytı görüntü olarak kaydet
- slayttan PNG'ye
- slayttan JPEG'e
- slayttan bitmap'e
- slayttan TIFF'e
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides kullanarak PPT, PPTX ve ODP slaytlarını C++ ile görüntülere dönüştürün—hızlı, yüksek kalite render etme ve net kod örnekleri."
---
## **Giriş**

Aspose.Slides for C++ size PowerPoint ve OpenDocument sunum slaytlarını BMP, PNG, JPG (JPEG), GIF ve diğerlerini içeren çeşitli görüntü formatlarına kolayca dönüştürmenizi sağlar.

Bir slaytı görüntüye dönüştürmek için şu adımları izleyin:

1. İstediğiniz dönüştürme ayarlarını tanımlayın ve dışa aktarmak istediğiniz slaytları aşağıdakileri kullanarak seçin:
    - [ITiffOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/itiffoptions/) arayüzü, ya da
    - [IRenderingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/irenderingoptions/) arayüzü.
2. Slayt görüntüsünü, [GetImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/getimage/) metodunu çağırarak oluşturun.

[Bitmap](https://reference.aspose.com/slides/tr/cpp/system.drawing/bitmap/) bir nesnedir ve piksel verileriyle tanımlanan görüntülerle çalışmanızı sağlar. Bu sınıfın örneğini kullanarak görüntüleri geniş bir format yelpazesinde (BMP, JPG, PNG, vb.) kaydedebilirsiniz.

## **Slaytları Bitmape Dönüştür ve Görüntüleri PNG Olarak Kaydet**

Bir slaytı bitmap nesnesine dönüştürüp doğrudan uygulamanızda kullanabilirsiniz. Alternatif olarak, slaytı bitmap olarak dönüştürüp ardından görüntüyü JPEG ya da tercih ettiğiniz başka bir formatta kaydedebilirsiniz.

Bu C++ kodu, bir sunumun ilk slaytını bitmap nesnesine dönüştürüp ardından görüntüyü PNG formatında nasıl kaydedeceğinizi gösterir:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Sunumdaki ilk slaytı bitmap'e dönüştür.
auto image = presentation->get_Slide(0)->GetImage();

// Görüntüyü PNG formatında kaydet.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Slaytları Özel Boyutlarda Görüntülere Dönüştür**

Belirli bir boyutta görüntü almanız gerekebilir. [GetImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/getimage/) üzerindeki bir aşırı yükleme kullanarak, bir slaytı belirli boyutlarda (genişlik ve yükseklik) bir görüntüye dönüştürebilirsiniz. 

Bu örnek kod, bunu nasıl yapacağınızı gösterir:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Sunumdaki ilk slaytı belirtilen boyutta bitmap'e dönüştür.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Görüntüyü JPEG formatında kaydet.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Not ve Yorum İçeren Slaytları Görüntülere Dönüştür**

Bazı slaytlar not ve yorum içerebilir.

Aspose.Slides, sunum slaytlarının görüntülere render edilmesini kontrol etmenizi sağlayan iki arayüz—[ITiffOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/itiffoptions/) ve [IRenderingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/irenderingoptions/)—sunar. Her iki arayüz de `set_SlidesLayoutOptions` metodunu içerir; bu metod, slaytı bir görüntüye dönüştürürken not ve yorumların render edilmesini yapılandırmanıza olanak tanır.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/notescommentslayoutingoptions/) sınıfı sayesinde, sonuç görüntüde not ve yorumların tercih ettiğiniz konumunu belirtebilirsiniz.

Bu C++ kodu, not ve yorum içeren bir slaytı nasıl dönüştüreceğinizi gösterir:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Bir sunum dosyası yükle.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // Notların konumunu ayarla.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // Yorumların konumunu ayarla.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // Yorum alanının genişliğini ayarla.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // Yorum alanının rengini ayarla.

// Render seçeneklerini oluştur.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Sunumun ilk slaytını bir görüntüye dönüştür.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Görüntüyü GIF formatında kaydet.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 

Herhangi bir slayt‑görüntü dönüştürme sürecinde, [set_NotesPosition](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) metodu notların konumunu belirlemek için `BottomFull` değerini uygulayamaz; çünkü not metni çok büyük olabilir ve belirtilen görüntü boyutuna sığmayabilir.

{{% /alert %}} 

## **TIFF Seçeneklerini Kullanarak Slaytları Görüntülere Dönüştür**

[ITiffOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/itiffoptions/) arayüzü, boyut, çözünürlük, renk paleti ve daha fazlası gibi parametreleri belirlemenizi sağlayarak ortaya çıkan TIFF görüntüsü üzerinde daha fazla kontrol sunar.

Bu C++ kodu, TIFF seçeneklerinin 100 DPI çözünürlük ve 2160 × 2800 boyutlu bir siyah‑beyaz görüntü üretmek için kullanıldığı bir dönüştürme sürecini gösterir:

```cpp 
// Bir sunum dosyası yükle.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Sunumdan ilk slaytı al.
auto slide = presentation->get_Slide(0);

// Çıktı TIFF görüntüsü ayarlarını yapılandır.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // Görüntü boyutunu ayarla.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // Piksel formatını ayarla (siyah beyaz).
tiffOptions->set_DpiX(300);                                         // Yatay çözünürlüğü ayarla.
tiffOptions->set_DpiY(300);                                         // Dikey çözünürlüğü ayarla.

// Slaytı belirtilen seçeneklerle bir görüntüye dönüştür.
auto image = slide->GetImage(tiffOptions);

// Görüntüyü TIFF formatında kaydet.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Tüm Slaytları Görüntülere Dönüştür**

Aspose.Slides, bir sunumdaki tüm slaytları görüntülere dönüştürmenize olanak tanır; böylece tüm sunumu bir dizi görüntüye çevirmiş olursunuz.

Bu örnek kod, bir sunumdaki tüm slaytları C++'ta görüntülere nasıl dönüştüreceğinizi gösterir:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Sunumu slayt slayt görüntülere render et.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // Gizli slaytları kontrol et (gizli slaytları render etme).
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Slaytı bir görüntüye dönüştür.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // Görüntüyü JPEG formatında kaydet.
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **SSS**

**Aspose.Slides animasyonlu slaytların render edilmesini destekliyor mu?**

Hayır, `GetImage` metodu yalnızca slaytın statik bir görüntüsünü kaydeder, animasyonları içermez.

**Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**

Evet, gizli slaytlar normal slaytlar gibi işlenebilir. Yalnızca işleme döngüsünde yer aldıklarından emin olun.

**Görüntüler gölgeler ve efektlerle kaydedilebilir mi?**

Evet, Aspose.Slides, slaytları görüntü olarak kaydederken gölgeler, şeffaflık ve diğer grafik efektlerinin render edilmesini destekler.