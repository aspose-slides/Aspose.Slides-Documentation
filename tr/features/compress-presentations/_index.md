---
title: Sunumları sıkıştır
description: Görselleri sıkıştırarak ve kullanılmayan içeriği kaldırarak sunum boyutunu azaltın.
type: docs
url: /tr/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Genel Bakış**

Resimleri sıkıştırın, artık ihtiyaç duyulmadığında kırpılmış görüntü alanlarını kaldırın ve kaydetmeden önce sunum sıkıştırma ayarlarını seçin. Bu, büyük fotoğraflar veya yinelenen medya içeren slayt desteleri için yararlıdır. Tasarruf miktarı, içeriğe ve seçtiğiniz ayarlara bağlıdır.

## **Kullanım örneği**

Bu C# örneği `input.pptx` dosyasını yükler, sunumu sıkıştırır ve `compressed.pptx` olarak kaydeder.

Aspose.Slides for .NET 26.11 veya sonraki sürümünü kullanın. Kurulum için [Aspose.Slides for .NET'i Kurun](/slides/tr/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **SSS**

### **Bu tek bir bütün‑dosya optimizasyon anahtarı mı?**

Aspose.Slides for .NET 26.11, kullanılmayan yerleşim/ana şablon kaldırma, gömülü font alt kümeleme ve 150 DPI resim sıkıştırmasını birleştiren [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/) ekler. Kırpılmış resim alanlarını kalıcı olarak kaldırır. Yalnızca resim işleme için [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) kullanın; daha ince kontrol için [tek‑resim sıkıştırma örneği](/slides/tr/net/examples/optimization-batch/compression/) görün. Bu yeni yardımcılar belirtilen .NET sürümüne özeldir; diğer SDK'lar için ilgili rehbere bakın.

### **Resim sıkıştırması düzenlenebilir metinleri veya grafikleri değiştirir mi?**

Resim sıkıştırması, düzenlenebilir metin veya grafik verileri yerine sadece resim verilerini hedef alır. Yeniden boyutlandırma veya yeniden sıkıştırma detay kaybına yol açabileceğinden, görüntüleri gözden geçirin.

### **Sunum resimleri için çözünürlüğü nasıl seçmeliyim?**

Hedefi, görüntülenen resim boyutu ve planlanan ekran veya baskı kullanımına göre seçin. Büyük ekranlar, baskı ve ayrıntılı diyagramlar için daha yüksek çözünürlük tutun ve orijinali silmeden önce oluşturulan çıktıyı karşılaştırın.

## **Kılavuzlar**

- [Tüm Sunumu .NET'te Sıkıştır](/slides/tr/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [.NET’te Sunumlarda Görüntü Yönetimini Optimize Et](/slides/tr/net/image/)

İlgili özellik: [Kullanılmayan ana şablonları, yerleşimleri ve medyayı kaldır](/slides/tr/features/remove-unused-content/).

## Çalıştırılabilir .NET örnekleri

- [Sunum Boyutunu Azalt](/slides/tr/net/examples/optimization-batch/compression/)