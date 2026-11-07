---
title: Sunumları Sıkıştır
description: Görüntü sıkıştırması ve ayar kaydetme ile sunum boyutunu azalt.
type: docs
url: /tr/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: işlemler
translationKey: slaytlar-ozellik-sikistir-sunumlar
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **Genel Bakış**

Resimleri sıkıştırın, artık ihtiyaç duyulmadığında kırpılmış görüntü alanlarını kaldırın ve kaydetmeden önce sunum sıkıştırma ayarlarını seçin. Bu, büyük fotoğraflar veya yinelenen medya içeren sunular için faydalıdır. Tasarruf miktarı, içeriğe ve seçtiğiniz ayarlara bağlıdır.

## **Kullanım örneği**

Bu C# örneği Aspose.Slides for .NET'i kullanır. Görsel olarak 1600 × 900 piksel boyutunda bir gradyan PNG oluşturur, bunu küçük bir resim çerçevesine ekler ve *before.pptx* olarak kaydeder. Ardından resmi hedef çözünürlük 96 DPI olacak şekilde sıkıştırır ve *compressed.pptx* olarak kaydeder. Her iki dosya boyutunu ve ön izlemeleri karşılaştırın: tasarruf, giriş resmine ve görüntülenen boyuta bağlıdır.

Kurulum için, bakınız [Aspose.Slides for .NET'i Kur](/slides/tr/net/installation/).

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **SSS**

### **Bu tek bir bütün dosya optimizasyon anahtarı mı?**

Aspose.Slides for .NET 26.11, [Compress.CompressPresentation](/slides/tr/net/low-code-presentation-operations/#compress-the-whole-presentation) özelliğini ekler; bu özellik kullanılmayan yerleşim/master kaldırma, gömülü font alt kümeleme ve 150 DPI resim sıkıştırmasını birleştirir. Kırpılmış resim alanlarını kalıcı olarak kaldırır. Yalnızca resim işleme için Compress.CompressImages'i kullanın; daha ince kontrol için yukarıdaki resim bazlı iş akışını koruyun. Bu yeni yardımcılar belirtilen .NET sürümüne özeldir; diğer SDK'lar için ilgili kılavuzu kontrol edin.

### **Resim sıkıştırması düzenlenebilir metin veya grafikleri değiştirir mi?**

Resim sıkıştırması, düzenlenebilir metin veya grafik verileri yerine yalnızca resim verilerini hedef alır. Yeniden boyutlandırma veya yeniden sıkıştırma, detay kaybına yol açabileceği için görüntüleri gözden geçirin.

### **Sunum resimleri için çözünürlüğü nasıl seçmeliyim?**

Hedefi, görüntülenen resim boyutu ve amaçlanan ekran veya baskı kullanımına göre seçin. Büyük ekranlar, baskı ve detaylı diyagramlar için daha yüksek çözünürlük tutun ve orijinali silmeden önce oluşturulan çıktıyı karşılaştırın.

## **Kılavuzlar**

- [.NET'te Sunumlardaki Görüntü Yönetimini Optimize Et](/slides/tr/net/image/)

İlgili özellik: [Kullanılmayan masterları, düzenleri ve medyayı kaldır](/slides/tr/features/remove-unused-content/).

## Çalıştırılabilir .NET örnekleri

- [Sunum Boyutunu Azalt](/slides/tr/net/examples/optimization-batch/compression/)