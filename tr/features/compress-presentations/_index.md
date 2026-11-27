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

Resimleri sıkıştırın, artık ihtiyaç duyulmadığında kırpılmış görüntü alanlarını kaldırın ve kaydetmeden önce sunum sıkıştırma ayarlarını seçin. Bu, büyük fotoğraflar veya tekrarlanan medya içeren sunumlar için yararlıdır. Kaydedilen miktar, içeriğe ve seçtiğiniz ayarlara bağlıdır.

## **Kullanım örneği**

Bu C# örneği `input.pptx` dosyasını yükler, sunumu sıkıştırır ve `compressed.pptx` olarak kaydeder.

Aspose.Slides for .NET 26.11 veya sonraki sürümünü kullanın. Kurulum için, [Aspose.Slides for .NET'i Kurun](/slides/tr/net/installation/) adresine bakın.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

<!-- visual-explanation:compress-presentations:start -->
[![Sıkıştırmadan önce ve sonra aynı ölçekli resim görüntüleri, ardından ölçülen PPTX dosya boyutu çubukları ve saklanan görüntü boyutları.](visual-compress-presentations-1adbf86268a5.svg)](visual-compress-presentations-1adbf86268a5.svg)

*Bir sentetik detay-ızgara düzeneği üzerinde ölçülmüştür: 584.030 → 128.323 bayt. Her iki render da aynı ölçeği ve 252 × 336 puan çerçeveyi kullanır. Sıkıştırma kırpılmış kenar boşluklarını kaldırır ve saklanan görüntüyü 525 × 700 piksele düşürür; boyut tasarrufu girdiye bağlıdır.* 
<!-- visual-explanation:compress-presentations:end -->

## **SSS**

### **Bu tek bir tam dosya optimizasyon anahtarı mı?**

Aspose.Slides for .NET 26.11, kullanılmayan düzen/master kaldırma, yerleşik yazı tipi alt kümeleme ve 150 DPI resim sıkıştırmasını birleştiren [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/) ekler. Kırpılmış resim alanlarını kalıcı olarak kaldırır. Yalnızca resim işleme için, [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) kullanın; daha ince kontrol için, [tek-resim sıkıştırma örneği](/slides/tr/net/examples/optimization-batch/compression/) görün. 26.11 sürümünden beri, aynı tam sunum çağrısı Java, Java üzerinden Node.js, .NET üzerinden Python ve C++ için de kullanılabilir. Örnek ve bu sayfadaki bağlantılar .NET içindir.

### **Resim sıkıştırması düzenlenebilir metin veya grafikleri değiştirir mi?**

Resim sıkıştırması, düzenlenebilir metin veya grafik verileri yerine yalnızca resim verilerini hedef alır. Yeniden boyutlandırma veya yeniden sıkıştırma, ayrıntıyı azaltabileceği için görüntüleri gözden geçirin.

### **Sunum görüntüleri için çözünürlüğü nasıl seçmeliyim?**

Görüntülenen resim boyutuna ve hedef ekran veya baskı kullanımına göre bir hedef seçin. Büyük ekranlar, baskı ve ayrıntılı diyagramlar için daha yüksek çözünürlük tutun ve orijinali silmeden önce oluşturulan çıktıyı karşılaştırın.

## **Kılavuzlar**

- [Tam Sunumu .NET'te Sıkıştır](/slides/tr/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [.NET'te Sunumlarda Görsel Yönetimi Optimize Et](/slides/tr/net/image/)

İlgili özellik: [Kullanılmayan master, düzen ve medyayı kaldır](/slides/tr/features/remove-unused-content/).

## Çalıştırılabilir .NET örnekleri

- [Sunum Boyutunu Azalt](/slides/tr/net/examples/optimization-batch/compression/)