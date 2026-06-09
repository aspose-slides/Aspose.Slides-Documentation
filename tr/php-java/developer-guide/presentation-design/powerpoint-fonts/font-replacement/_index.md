---
title: PHP Kullanarak Sunumlarda Yazı Tipi Değişimini Kolaylaştırma
linktitle: Yazı Tipi Değiştirme
type: docs
weight: 60
url: /tr/php-java/font-replacement/
keywords:
- yazı tipi
- yazı tipi değiştir
- yazı tipi değiştirme
- yazı tipi değiştir
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Java üzerinden PHP için Aspose.Slides'te yazı tiplerini sorunsuz bir şekilde değiştirerek PowerPoint ve OpenDocument sunumlarında tutarlı tipografi sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunum boyunca bir yazı tipini diğeriyle değiştirmenizi sağlar. Bir yazı tipi değiştirildiğinde, orijinal yazı tipinin tüm örnekleri yeni yazı tipine dönüştürülür.

Yazı tipi değişimini gerçekleştirmek için sunumu yükleyin, kaynak yazı tipini ve değiştirme yazı tipini tanımlayın, yazı tipi değiştirme metodunu çağırın ve değiştirilmiş sunumu PPTX dosyası olarak kaydedin. Bu yaklaşım, sunum boyunca bir yazı tipi ailesinden diğerine kasıtlı olarak geçiş yapmak istediğinizde yararlıdır.

## **Yazı Tiplerini Değiştir**

Bir yazı tipini kullanma kararınızı değiştirirseniz, o yazı tipini başka bir yazı tipiyle değiştirebilirsiniz. Eski yazı tipinin tüm örnekleri yeni yazı tipiyle değiştirilecektir. 

Aspose.Slides bu şekilde bir yazı tipini değiştirmenizi sağlar:

1. İlgili sunumu yükleyin. 
2. Değiştirilecek yazı tipini yükleyin.
3. Yeni yazı tipini yükleyin. 
4. Yazı tipini değiştirin. 
5. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Bu PHP kodu, yazı tipi değişimini göstermektedir:

```php
  # Bir sunumu yükler
  $pres = new Presentation("Fonts.pptx");
  try {
    # Değiştirilecek kaynak yazı tipini yükler
    $sourceFont = new FontData("Arial");
    # Yeni yazı tipini yükler
    $destFont = new FontData("Times New Roman");
    # Yazı tiplerini değiştirir
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # Sunumu kaydeder
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
Belirli koşullarda (örneğin bir yazı tipine erişilemediğinde) ne olacağını belirleyen kuralları ayarlamak için [**Yazı Tipi Yerine Koyma**](/slides/tr/php-java/font-substitution/).
{{% /alert %}}

## **SSS**

**"Yazı tipi değiştirme", "yazı tipi yerine koyma" ve "yedekleme yazı tipleri" arasındaki fark nedir?**

Değiştirme, tüm belge boyunca bir aileden diğerine kasıtlı bir geçiştir. [Yerine koyma](/slides/tr/php-java/font-substitution/) "yazı tipi mevcut değilse, X kullan" gibi bir kuraldır. [Yedekleme](/slides/tr/php-java/fallback-font/) temel yazı tipi yüklü olduğunda ancak gereken karakterleri içermediğinde, eksik glifler için bireysel olarak uygulanır.

**Değiştirme, master slaytlar, düzenler, notlar ve yorumlara da uygulanır mı?**

Evet. Değiştirme, orijinal yazı tipini kullanan tüm sunum nesnelerini etkiler; master slaytlar ve notlar da dahildir. Yorumlar da belgenin bir parçasıdır ve yazı tipi motoru tarafından dikkate alınır.

**Gömülü OLE nesneleri (örneğin Excel) içinde yazı tipi değişecek mi?**

Hayır. [OLE içeriği](/slides/tr/php-java/manage-ole/) kendi uygulaması tarafından kontrol edilir. Sunumdaki değişiklik, iç OLE verilerini yeniden biçimlendirmez; OLE nesnesi bir resim olarak ya da dışarıdan düzenlenebilir içerik olarak gösterilebilir.

**Yazı tipini sadece sunumun bir kısmında (slaytlar veya bölgeler bazında) değiştirebilir miyim?**

Hedef odaklı bir değiştirme, tüm belgeye global bir değiştirme uygulamak yerine, gerektiği nesne/alan seviyesinde yazı tipini değiştirirseniz mümkündür. İşleme sırasında genel yazı tipi seçim mantığı aynı kalır.

**Sunumun hangi yazı tiplerini kullandığını önceden nasıl belirleyebilirim?**

Sunumun [font yöneticisini](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/) kullanın: bu, kullanılan [yazı tipi ailelerinin](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/getfonts/) bir listesini ve [yerine koyma/"bilinmeyen" yazı tipleri](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/getsubstitutions/) hakkında bilgi sağlar; bu da değişikliği planlamanıza yardımcı olur.

**Yazı tipi değiştirme, PDF/görsellere dönüştürürken çalışır mı?**

Evet. Dışa aktarım sırasında Aspose.Slides aynı [yazı tipi seçim/yerine koyma sırasını](/slides/tr/php-java/font-selection-sequence/) uygular; bu nedenle önceden yapılan bir değiştirme, dönüştürme sırasında uygulanır.

**Hedef yazı tipini sisteme kurmam gerekir mi, yoksa bir font klasörü ekleyebilir miyim?**

Kurulum gerekli değildir: kütüphane, kullanıcı klasörlerinden [harici font yüklemeye](/slides/tr/php-java/custom-font/) izin verir; bu, [işleme ve dışa aktarma](/slides/tr/php-java/convert-powerpoint/) sırasında kullanılabilir.

**Değiştirme, karakter yerine "tofu" (kareler) sorununu çözer mi?**

Sadece hedef yazı tipi gerçekten gereken glifleri içeriyorsa olur. Aksi takdirde, eksik karakterleri kapsaması için [yedekleme yapılandırın](/slides/tr/php-java/fallback-font/).