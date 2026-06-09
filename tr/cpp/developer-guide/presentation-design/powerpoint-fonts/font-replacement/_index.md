---
title: C++ Kullanarak Sunumlarda Yazı Tipi Değişimini Kolaylaştırın
linktitle: Yazı Tipi Değiştirme
type: docs
weight: 60
url: /tr/cpp/font-replacement/
keywords:
- yazı tipi
- yazı tipi değiştirme
- yazı tipi değişimi
- yazı tipi değiştir
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides için C++'da yazı tiplerini sorunsuz bir şekilde değiştirerek PowerPoint ve OpenDocument sunumlarında tutarlı tipografi sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdaki bir yazı tipini başka bir yazı tipiyle değiştirmenize olanak tanır. Bir yazı tipi değiştirildiğinde, orijinal yazı tipinin tüm örnekleri yeni yazı tipine dönüştürülür.

Yazı tipi değişimini gerçekleştirmek için sunumu yükleyin, kaynak yazı tipini ve değiştirilecek yazı tipini tanımlayın, yazı tipi değiştirme metodunu çağırın ve değiştirilmiş sunumu PPTX dosyası olarak kaydedin. Bu yaklaşım, sunum boyunca bir yazı tipi ailesinden başka birine kasıtlı olarak geçmek istediğinizde kullanışlıdır.

## **Yazı Tiplerini Değiştir**

Bir yazı tipini kullanma konusunda fikrinizi değiştirirseniz, o yazı tipini başka bir yazı tipiyle değiştirebilirsiniz. Eski yazı tipinin tüm örnekleri yeni yazı tipiyle değiştirilecektir.

Aspose.Slides, bir yazı tipini şu şekilde değiştirmenize olanak tanır:

1. İlgili sunumu yükleyin.  
2. Değiştirilecek yazı tipini yükleyin.  
3. Yeni yazı tipini yükleyin.  
4. Yazı tipini değiştirin.  
5. Değiştirilmiş sunumu PPTX dosyası olarak yazın.  

Bu C++ kodu, yazı tipi değişimini gösterir:

``` cpp
// Bir sunumu yükler
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Değiştirilecek kaynak yazı tipini yükler
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Yeni yazı tipini yükler
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Yazı tiplerini değiştirir
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Sunumu kaydeder
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Belirli koşullarda (örneğin bir yazı tipine erişilemezse) ne olacağını belirleyen kuralları ayarlamak için, [**Font Substitution**](/slides/tr/cpp/font-substitution/) sayfasına bakın. 
{{% /alert %}}

## **SSS**

**"Yazı tipi değişimi", "yazı tipi ikamesi" ve "geri dönüş (fallback) yazı tipleri" arasındaki fark nedir?**

Değişim, tüm belge boyunca bir aileden diğerine kasıtlı bir geçiştir. [Substitution](/slides/tr/cpp/font-substitution/) “yazı tipi mevcut değilse, X kullanılacak” gibi bir kuraldır. [Fallback](/slides/tr/cpp/fallback-font/) ise temel yazı tipi yüklü olduğunda ancak gerekli karakterleri içermediğinde, eksik glifler için bireysel olarak uygulanır.

**Değişim, ana slaytlara, düzenlere, notlara ve yorumlara uygulanır mı?**

Evet. Değişim, orijinal yazı tipini kullanan tüm sunum nesnelerini etkiler; ana slaytlar ve notlar buna dahildir; yorumlar da belgenin bir parçasıdır ve yazı tipi motoru tarafından dikkate alınır.

**Gömülü OLE nesneleri (örneğin Excel) içindeki yazı tipi değişecek mi?**

Hayır. [OLE content](/slides/tr/cpp/manage-ole/) kendi uygulaması tarafından kontrol edilir. Sunumdaki değişim, iç OLE verilerini yeniden biçimlendirmez; bu veri bir görüntü olarak ya da dışarıdan düzenlenebilir içerik olarak gösterilebilir.

**Yazı tipini sadece sunumun bir kısmında (slaytlar veya bölgeler bazında) değiştirebilir miyim?**

Hedefli değişim, tüm belgeye global bir değişim uygulamak yerine gerekli nesne/arayüz seviyesinde yazı tipini değiştirirseniz mümkündür. İşleme sırasında genel yazı tipi seçim mantığı aynı kalır.

**Sunumun hangi yazı tiplerini kullandığını önceden nasıl belirleyebilirim?**

Sunumun [font manager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/): kullanımdaki [kullanımdaki aileler](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/getfonts/) listesini ve [ikame/"bilinmeyen" yazı tipleri](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/getsubstitutions/) hakkında bilgileri sağlar; bu, değişimi planlamaya yardımcı olur.

**Yazı tipi değişimi PDF/görsellere dönüştürürken çalışır mı?**

Evet. Dışa aktarma sırasında Aspose.Slides aynı [font selection/substitution sequence](/slides/tr/cpp/font-selection-sequence/) uygular, bu nedenle önceden yapılan değişim dönüştürme sırasında da uygulanır.

**Hedef yazı tipini sisteme kurmam gerekiyor mu, yoksa bir fonts klasörü ekleyebilir miyim?**

Kurulum gerekli değildir: kütüphane, kullanıcı klasörlerinden [harici yazı tipleri yükleme](/slides/tr/cpp/custom-font/) izin verir; bu fontlar [renderleme ve dışa aktarma](/slides/tr/cpp/convert-powerpoint/) sırasında kullanılabilir.

**Değişim, karakter yerine "tofu" (kareler) sorununun düzelmesini sağlar mı?**

Yalnızca hedef yazı tipi gerçekten gerekli glifleri içeriyorsa. İçermiyorsa, eksik karakterleri kapsamak için [fallback yapılandırın](/slides/tr/cpp/fallback-font/).