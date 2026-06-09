---
title: Android'de Sunumlarda Yazı Tipi Değişimini Kolaylaştırın
linktitle: Yazı Tipi Değişimi
type: docs
weight: 60
url: /tr/androidjava/font-replacement/
keywords:
- yazı tipi
- yazı tipi değiştirme
- yazı tipi değişimi
- yazı tipi değiştir
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'de Java aracılığıyla yazı tiplerini sorunsuz bir şekilde değiştirerek PowerPoint ve OpenDocument sunumlarında tutarlı tipografi sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunum boyunca bir yazı tipini diğer bir yazı tipiyle değiştirmenize olanak tanır. Bir yazı tipi değiştirildiğinde, orijinal yazı tipinin tüm örnekleri yeni yazı tipiyle değiştirilir.

Yazı tipi değişimini gerçekleştirmek için sunumu yükleyin, kaynak yazı tipini ve değiştirme yazı tipini tanımlayın, yazı tipi değişim metodunu çağırın ve değiştirilmiş sunumu PPTX dosyası olarak kaydedin. Bu yöntem, sunum boyunca bir yazı tipi ailesinden diğerine kasıtlı olarak geçmek istediğinizde kullanışlıdır.

## **Yazı Tiplerini Değiştir**

Bir yazı tipini kullanma kararınızı değiştirirseniz, o yazı tipini başka bir yazı tipiyle değiştirebilirsiniz. Eski yazı tipinin tüm örnekleri yeni yazı tipiyle değiştirilecektir.

Aspose.Slides bu şekilde bir yazı tipi değişimi yapmanıza izin verir:

1. İlgili sunumu yükleyin. 
2. Değiştirilecek yazı tipini yükleyin.
3. Yeni yazı tipini yükleyin. 
4. Yazı tipini değiştirin. 
5. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Bu Java kodu yazı tipi değişimini gösterir:

```java
// Bir sunumu yükler
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Değiştirilecek kaynak yazı tipini yükler
    IFontData sourceFont = new FontData("Arial");
    
    // Yeni yazı tipini yükler
    IFontData destFont = new FontData("Times New Roman");
    
    // Yazı tiplerini değiştirir
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // Sunumu kaydeder
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Belirli koşullarda (örneğin bir yazı tipine erişilemezse) ne olacağını belirleyen kuralları ayarlamak için [**Yazı Tipi Yerine Koyma**](/slides/tr/androidjava/font-substitution/) bölümüne bakın.

{{% /alert %}}

## **SSS**

**"Yazı tipi değişimi", "yazı tipi yerine koyma" ve "geri dönüş yazı tipleri" arasındaki fark nedir?**

Değişim, bütün belge boyunca bir aileden diğerine kasıtlı bir geçiştir. [Yerine koyma](/slides/tr/androidjava/font-substitution/) “yazı tipi mevcut değilse X kullan” gibi bir kuraldır. [Geri dönüş](/slides/tr/androidjava/fallback-font/) temel yazı tipi kurulu olsa da gerekli karakterleri içermediğinde bireysel eksik glifler için cerrahi olarak uygulanır.

**Değişim ana slaytlar, yerleşimler, notlar ve yorumlar için geçerli midir?**

Evet. Değişim, orijinal yazı tipini kullanan tüm sunum nesnelerini etkiler; ana slaytlar ve notlar dahil; yorumlar da belgenin bir parçasıdır ve yazı tipi motoru tarafından dikkate alınır.

**Gömülü OLE nesneleri (örneğin Excel) içindeki yazı tipi değişecek mi?**

Hayır. [OLE içeriği](/slides/tr/androidjava/manage-ole/) kendi uygulaması tarafından kontrol edilir. Sunumdaki değişim, OLE verisinin içini yeniden biçimlendirmez; OLE içeriği bir resim olarak veya dışarıdan düzenlenebilir içerik olarak gösterilebilir.

**Yazı tipini sadece sunumun bir kısmında (slaytlar veya bölgeler bazında) değiştirebilir miyim?**

Hedeflenmiş değişim, tüm belgeye küresel bir değişiklik uygulamak yerine gerekli nesne/aralık seviyesinde yazı tipini değiştirerek mümkündür. Render sırasında kullanılan genel yazı tipi seçimi mantığı aynı kalır.

**Sunumun kullandığı tüm yazı tiplerini önceden nasıl öğrenebilirim?**

Sunumun [font manager] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsmanager/) kullanın: bu, kullanılan [ailelerin] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsmanager/#getFonts--) bir listesini ve [yerine koyma/“bilinmeyen” yazı tipleri] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsmanager/#getSubstitutions--) hakkındaki bilgileri sağlar; böylece değişim planlaması yapılabilir.

**Yazı tipi değişimi PDF/görsellere dönüştürürken çalışır mı?**

Evet. Dışa aktarım sırasında Aspose.Slides aynı [yazı tipi seçimi/yerine koyma sırasını](/slides/tr/androidjava/font-selection-sequence/) uygular; önceden yapılan bir değişim dönüşüm sırasında da uygulanır.

**Hedef yazı tipini sisteme kurmam gerekiyor mu, yoksa bir font klasörü ekleyebilir miyim?**

Kurulum gerekmiyor: kütüphane, [harici yazı tiplerini](/slides/tr/androidjava/custom-font/) kullanıcı klasörlerinden yükleyerek [render ve dışa aktarma](/slides/tr/androidjava/convert-powerpoint/) sırasında kullanılmasına izin verir.

**Değişim, karakterler yerine “tofu” (kareler) sorununun çözülmesini sağlar mı?**

Sadece hedef yazı tipi gerçekten gerekli glifleri içeriyorsa. İçermiyorsa, eksik karakterleri kapsamak için [geri dönüş yapılandırın](/slides/tr/androidjava/fallback-font/).