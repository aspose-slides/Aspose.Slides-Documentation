---
title: C++'ta Sunum Slaytlarını Görüntülere Dönüştür
linktitle: Slayttan Görüntüye
type: docs
weight: 41
url: /tr/cpp/convert-slide/
keywords:
- slaytı dönüştür
- slaytı dışa aktar
- slayttan görüntüye
- slaytı görüntü olarak kaydet
- slayt PNG'ye
- slayt JPEG'e
- slayt bitmap'e
- slayt TIFF'e
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides kullanarak C++'ta PPT, PPTX ve ODP slaytlarını görüntülere dönüştürün—hızlı, yüksek kaliteli renderlama ve net kod örnekleri."
---
## **Giriş**

Aspose.Slides for C++ PowerPoint ve OpenDocument sunum slaytlarını BMP, PNG, JPG (JPEG), GIF ve diğerleri dahil çeşitli görüntü formatlarına kolayca dönüştürmenizi sağlar.

Bir slaytı görüntüye dönüştürmek için aşağıdaki adımları izleyin:

1. İstediğiniz dönüşüm ayarlarını tanımlayın ve dışa aktarmak istediğiniz slaytları aşağıdakileri kullanarak seçin:
    - [ITiffOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/itiffoptions/) arayüzünü, ya da
    - [IRenderingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/irenderingoptions/) arayüzünü.
2. Slayt görüntüsünü, [GetImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/getimage/) yöntemini çağırarak oluşturun.

[Bitmap](https://reference.aspose.com/slides/tr/cpp/system.drawing/bitmap/) piksel verileriyle tanımlanan görüntülerle çalışmanızı sağlayan bir nesnedir. Bu sınıfın bir örneğini kullanarak görüntüleri geniş bir format yelpazesinde (BMP, JPG, PNG vb.) kaydedebilirsiniz.

## **Slaytları Bitmap'lere Dönüştür ve PNG Olarak Kaydet**

Bir slaytı bitmap nesnesine dönüştürüp doğrudan uygulamanızda kullanabilirsiniz. Alternatif olarak, slaytı bitmap'e dönüştürüp ardından görüntüyü JPEG ya da tercih ettiğiniz başka bir formatta kaydedebilirsiniz.

Bu C++ kodu, bir sunumun ilk slaytını bitmap nesnesine dönüştürüp ardından PNG formatında kaydetmeyi gösterir:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Convert the first slide in the presentation to a bitmap.
auto image = presentation->get_Slide(0)->GetImage();

// Save the image in the PNG format.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Özel Boyutlarda Slayt Görüntüleri Dönüştür**

Belirli bir boyutta bir görüntü almanız gerekebilir. [GetImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/getimage/) aşırı yüklemesini kullanarak, bir slaytı belirli boyutlarda (genişlik ve yükseklik) bir görüntüye dönüştürebilirsiniz. 

Bu örnek kod bunu nasıl yapacağınızı gösterir:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Sunumdaki ilk slaytı belirtilen boyutta bir bitmap'e dönüştür.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Görüntüyü JPEG formatında kaydet.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Notlar ve Yorumlar İçeren Slaytları Görüntülere Dönüştür**

Bazı slaytlar not ve yorumlar içerebilir.

Aspose.Slides, sunum slaytlarının görüntülere işlenmesini kontrol etmenizi sağlayan iki arayüz—[ITiffOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/itiffoptions/) ve [IRenderingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/irenderingoptions/)—sunar. Her iki arayüz de `set_SlidesLayoutOptions` metodunu içerir; bu metot, bir slaytı görüntüye dönüştürürken notların ve yorumların işlenmesini yapılandırmanıza izin verir.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/notescommentslayoutingoptions/) sınıfı ile, ortaya çıkan görüntüde notlar ve yorumlar için tercih ettiğiniz konumu belirtebilirsiniz.

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

// Renderleme seçeneklerini oluştur.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Sunumdaki ilk slaytı bir görüntüye dönüştür.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Görüntüyü GIF formatında kaydet.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Not" color="warning" %}} 

Herhangi bir slayt‑görüntü dönüşüm sürecinde, [set_NotesPosition](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) yöntemi `BottomFull` (notların konumunu belirtmek için) uygulanamaz, çünkü not metni çok büyük olabilir ve belirtilen görüntü boyutuna sığmayabilir.

{{% /alert %}} 

## **TIFF Seçeneklerini Kullanarak Slaytları Görüntülere Dönüştür**

[ITiffOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/itiffoptions/) arayüzü, boyut, çözünürlük, renk paleti gibi parametreleri belirlemenizi sağlayarak ortaya çıkan TIFF görüntüsü üzerinde daha fazla kontrol sunar.

Bu C++ kodu, TIFF seçeneklerinin 300 DPI çözünürlükte ve 2160 × 2800 boyutunda siyah‑beyaz bir görüntü üretmek için kullanıldığı bir dönüşüm sürecini gösterir:

```cpp 
// Bir sunum dosyası yükle.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Sunumdan ilk slaytı al.
auto slide = presentation->get_Slide(0);

// Çıktı TIFF görüntüsünün ayarlarını yapılandır.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // Görüntü boyutunu ayarla.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // Piksel formatını ayarla (siyah ve beyaz).
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

Aspose.Slides, bir sunumdaki tüm slaytları görüntülere dönüştürmenize olanak tanır, böylece tüm sunumu bir dizi görüntüye çevirebilirsiniz.

Bu örnek kod, bir sunumdaki tüm slaytları C++'ta görüntülere nasıl dönüştüreceğinizi gösterir:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Sunumu slayt slayt görsellere renderla.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // Gizli slaytları kontrol et (gizli slaytları renderlama).
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

## **Renkli Emoji İşleme**

{{% alert title="Not" color="warning" %}} 
Sunum slaytlarını görüntülere dönüştürürken renkli emojileri doğru işleyebilmek için, sunumda kullanılan emoji yazı tiplerinin dönüşümü yapan sistemde kurulu ve erişilebilir olması gerekir. Örneğin, sunum **Segoe UI Emoji** yazı tipini kullanıyorsa ve bu yazı tipi eksikse, emojiler çıktı görüntülerinde tek renkli (monokrom) görünebilir.
{{% /alert %}}

## **SSS**

**Aspose.Slides animasyonlu slaytların işlenmesini destekliyor mu?**  
Hayır, `GetImage` yöntemi sadece slaytın statik bir görüntüsünü kaydeder, animasyonlar eklenmez.

**Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**  
Evet, gizli slaytlar normal slaytlar gibi işlenebilir. İşlem döngüsünde yer aldıklarından emin olun.

**Görüntüler gölgeler ve efektlerle kaydedilebilir mi?**  
Evet, Aspose.Slides slaytları görüntü olarak kaydederken gölgeler, şeffaflık ve diğer grafik efektlerini işler.