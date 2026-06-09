---
title: Java Kullanarak Sunumlarda Yazı Tipi Değişimini Kolaylaştırın
linktitle: Yazı Tipi Değişimi
type: docs
weight: 60
url: /tr/java/font-replacement/
keywords:
- yazı tipi
- yazı tipi değiştir
- yazı tipi değişimi
- yazı tipi değiştirme
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarında tutarlı tipografi sağlamak için Aspose.Slides for Java'da yazı tiplerini sorunsuz bir şekilde değiştirin."
---
## **Genel Bakış**

Aspose.Slides, bir sunum boyunca bir yazı tipini başka bir yazı tipiyle değiştirmenize olanak tanır. Bir yazı tipi değiştirildiğinde, orijinal yazı tipinin tüm örnekleri yeni yazı tipine dönüştürülür.

Yazı tipi değişimini gerçekleştirmek için sunumu yükleyin, kaynak yazı tipini ve değiştirme yazı tipini tanımlayın, yazı tipi değiştirme metodunu çağırın ve değiştirilmiş sunumu PPTX dosyası olarak kaydedin. Bu yaklaşım, sunum boyunca bir yazı tipi ailesinden başka birine kasıtlı olarak geçmek istediğinizde kullanışlıdır.

## **Yazı Tiplerini Değiştir**

Bir yazı tipini kullanma kararınızı değiştirdiğinizde, o yazı tipini başka bir yazı tipiyle değiştirebilirsiniz. Eski yazı tipinin tüm örnekleri yeni yazı tipiyle değiştirilecektir.

Aspose.Slides bu şekilde bir yazı tipini değiştirmeyi sağlar:

1. İlgili sunumu yükleyin.  
2. Değiştirilecek yazı tipini yükleyin.  
3. Yeni yazı tipini yükleyin.  
4. Yazı tipini değiştirin.  
5. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Bu Java kodu yazı tipi değişimini gösterir:

```java
// Bir sunum yükler
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
Belirli koşullarda ne olacağını belirleyen kuralları (örneğin bir yazı tipine erişilemezse) ayarlamak için [**Yazı Tipi Yerine Koyma**](/slides/tr/java/font-substitution/) bölümüne bakın. 
{{% /alert %}}

## **SSS**

**“Yazı tipi değiştirme”, “yazı tipi yerine koyma” ve “yedek yazı tipleri” arasındaki fark nedir?**

Değiştirme, bütün belge boyunca bir aileden başka bir aileye kasıtlı bir geçiştir. [Yerine koyma](/slides/tr/java/font-substitution/) “yazı tipi mevcut değilse X kullanılacak” gibi bir kuraldır. [Yedek](/slides/tr/java/fallback-font/) temel yazı tipi yüklü ancak gereken karakterleri içermediğinde eksik glifler için bireysel olarak uygulanır.

**Değiştirme, ana slaytlar, düzenler, notlar ve yorumlar için geçerli midir?**

Evet. Değiştirme, ana slaytlar ve notlar da dahil olmak üzere orijinal yazı tipini kullanan tüm sunum nesnelerini etkiler; yorumlar da belgenin bir parçasıdır ve yazı tipi motoru tarafından dikkate alınır.

**Gömülü OLE nesneleri (örneğin Excel) içindeki yazı tipi değişecek mi?**

Hayır. [OLE içeriği](/slides/tr/java/manage-ole/) kendi uygulaması tarafından kontrol edilir. Sunumdaki değiştirme, OLE içindeki verileri yeniden biçimlendirmez; OLE içeriği bir resim olarak ya da harici olarak düzenlenebilir bir içerik olarak görüntülenebilir.

**Yazı tipini sadece sunumun bir kısmında (slaytlar veya bölgeler bazında) değiştirebilir miyim?**

Hedefe yönelik değiştirme, tüm belgeye küresel bir değiştirme uygulamak yerine gerekli nesne/alan seviyesinde yazı tipini değiştirerek mümkündür. Render sırasında genel yazı tipi seçim mantığı aynı kalır.

**Sunumun kullandığı tüm yazı tiplerini önceden nasıl belirleyebilirim?**

Sunumun [font manager]((https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsmanager/))'ını kullanın: kullanılan [yazı tipi ailelerinin]((https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsmanager/#getFonts--)) bir listesini ve [yerine koyma/“bilinmeyen” yazı tipleri]((https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsmanager/#getSubstitutions--)) hakkında bilgi verir; bu da değiştirme planlamasına yardımcı olur.

**Yazı tipi değiştirme, PDF/görsellere dönüştürürken çalışır mı?**

Evet. Dışa aktarım sırasında Aspose.Slides aynı [yazı tipi seçim/yerine koyma sırasını](/slides/tr/java/font-selection-sequence/) uygular; önceden yapılan bir değişiklik dönüştürme sırasında da geçerli olur.

**Hedef yazı tipini sisteme kurmam gerekir mi, yoksa bir font klasörü ekleyebilir miyim?**

Kurulum gerekli değildir: Kütüphane, [harici yazı tiplerini](/slides/tr/java/custom-font/) kullanıcı klasörlerinden yükleyerek [render ve dışa aktarma](/slides/tr/java/convert-powerpoint/) sırasında kullanılmasına izin verir.

**Değiştirme, karakterler yerine “tofu” (kareler) sorununu çözer mi?**

Yalnızca hedef yazı tipi gerçekten gereken glifleri içeriyorsa düzeltir. İçermiyorsa, eksik karakterleri kapsamak için [yedek yapılandırın](/slides/tr/java/fallback-font/).