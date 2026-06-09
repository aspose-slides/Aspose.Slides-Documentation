---
title: JavaScript Kullanarak Sunumlarda Yazı Tipi Değişimini Kolaylaştırın
linktitle: Yazı Tipi Değiştirme
type: docs
weight: 60
url: /tr/nodejs-java/font-replacement/
keywords:
- yazı tipi
- yazı tipi değiştir
- yazı tipi değiştirme
- yazı tipini değiştir
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript'te Aspose.Slides for Node.js'i Java aracılığıyla kullanarak yazı tiplerini sorunsuz bir şekilde değiştirin ve PowerPoint ile OpenDocument sunumlarında tutarlı tipografi sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunum boyunca bir yazı tipini başka bir yazı tipiyle değiştirmenizi sağlar. Bir yazı tipi değiştirildiğinde, orijinal yazı tipinin tüm örnekleri yeni yazı tipine dönüştürülür.

Yazı tipi değişimini gerçekleştirmek için sunumu yükleyin, kaynak yazı tipini ve değiştirme yazı tipini tanımlayın, yazı tipi değiştirme yöntemini çağırın ve değiştirilmiş sunumu PPTX dosyası olarak kaydedin. Bu yaklaşım, sunum boyunca bir yazı tipi ailesinden diğerine kasıtlı olarak geçmek istediğinizde kullanışlıdır.

## **Yazı Tipi Değiştirme**

Bir yazı tipini kullanma kararınız değişirse, o yazı tipini başka bir yazı tipiyle değiştirebilirsiniz. Eski yazı tipinin tüm örnekleri yeni yazı tipine dönüştürülür.

Aspose.Slides bu şekilde bir yazı tipini değiştirmenize olanak tanır:

1. İlgili sunumu yükleyin.  
2. Değiştirilecek yazı tipini yükleyin.  
3. Yeni yazı tipini yükleyin.  
4. Yazı tipini değiştirin.  
5. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Bu JavaScript kodu yazı tipi değişimini gösterir:

```javascript
// Bir sunumu yükler
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Değiştirilecek kaynak yazı tipini yükler
    var sourceFont = new aspose.slides.FontData("Arial");
    // Yeni yazı tipini yükler
    var destFont = new aspose.slides.FontData("Times New Roman");
    // Yazı tiplerini değiştirir
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    // Sunumu kaydeder
    pres.save("UpdatedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Not" color="warning" %}}  
Belirli koşullarda ne olacağını belirleyen kuralları (örneğin bir yazı tipine erişilemezse) ayarlamak için [**Yazı Tipi Değiştirme**](/slides/tr/nodejs-java/font-substitution/) bölümüne bakın.  
{{% /alert %}}

## **SSS**

**“Yazı tipi değiştirme”, “yazı tipi yerine koyma” ve “alternatif yazı tipleri” arasındaki fark nedir?**  

Değiştirme, bütün belgede bir aileden diğerine kasıtlı bir geçiştir. [Yazı Tipi Yerine Koyma](/slides/tr/nodejs-java/font-substitution/) “yazı tipi mevcut değilse X’i kullan” gibi bir kuraldır. [Alternatif](/slides/tr/nodejs-java/fallback-font/) temel yazı tipi kurulu ancak gerekli karakterleri içermediğinde eksik glifler için bireysel olarak uygulanır.

**Değiştirme, ana slaytlar, düzenler, notlar ve yorumlar için geçerli midir?**  

Evet. Değiştirme, ana slaytlar ve notlar dahil olmak üzere orijinal yazı tipini kullanan tüm sunum nesnelerini etkiler; yorumlar da belgenin bir parçası olduğundan yazı tipi motoru tarafından dikkate alınır.

**Gömülü OLE nesneleri (örneğin Excel) içindeki yazı tipi değişir mi?**  

Hayır. [OLE içeriği](/slides/tr/nodejs-java/manage-ole/) kendi uygulaması tarafından kontrol edilir. Sunumdaki değişiklik, OLE içindeki verileri yeniden biçimlendirmez; içerik bir görüntü olarak ya da dışarıdan düzenlenebilir bir içerik olarak gösterilebilir.

**Yazı tipini sadece sunumun belirli bir bölümü (slaytlar veya alanlar) için değiştirebilir miyim?**  

Hedeflenmiş değiştirme, tüm belgeye küresel bir değişiklik uygulamak yerine gerekli nesneler/alanlar düzeyinde yazı tipini değiştirerek mümkündür. Render sürecindeki genel yazı tipi seçim mantığı aynı kalır.

**Sunumun hangi yazı tiplerini kullandığını önceden nasıl belirleyebilirim?**  

Sunumun [yazı tipi yöneticisini](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/) kullanın: bu, [kullanımdaki aileler]((https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/getfonts/)) ve [yerine koymalar/"bilinmeyen" yazı tipleri]((https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)) hakkında bilgi verir ve değiştirme planlamasına yardımcı olur.

**Yazı tipi değiştirme, PDF/görsellere dönüştürürken çalışır mı?**  

Evet. Dışa aktarım sırasında Aspose.Slides aynı [yazı tipi seçim/yerine koyma sırasını](/slides/tr/nodejs-java/font-selection-sequence/) uygular; önceden yapılan bir değiştirme dönüştürme sırasında da uygulanır.

**Hedef yazı tipini sistemde kurmam gerekir mi, yoksa bir font klasörü ekleyebilir miyim?**  

Kurulum gerekli değildir: kitaplık, [harici yazı tipleri](/slides/tr/nodejs-java/custom-font/) yüklemeye izin verir; bu, [render ve dışa aktarım](/slides/tr/nodejs-java/convert-powerpoint/) sırasında kullanılabilir.

**Değiştirme, karakterler yerine “tofu” (kareler) sorununu çözer mi?**  

Yalnızca hedef yazı tipi gerçekten gerekli glifleri içeriyorsa çözer. İçermiyorsa, eksik karakterleri kapsamak için [alternatif yapılandırın](/slides/tr/nodejs-java/fallback-font/).