---
title: C++ Kullanarak Sunumlarda Yazı Tipi Değişimini Kolaylaştırma
linktitle: Yazı Tipi Değiştirme
type: docs
weight: 60
url: /tr/cpp/font-replacement/
keywords:
- yazı tipi
- yazı tipini değiştir
- yazı tipi değiştirme
- yazı tipini değiştir
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarında tutarlı tipografi sağlamak için C++ için Aspose.Slides içinde yazı tiplerini sorunsuz bir şekilde değiştirin."
---
## **Genel Bakış**

Aspose.Slides, bir sunu boyunca bir yazı tipini başka bir yazı tipiyle değiştirmenizi sağlar. Bir yazı tipi değiştirildiğinde, orijinal yazı tipinin tüm örnekleri yeni yazı tipine dönüştürülür.

Yazı tipi değişimini gerçekleştirmek için sunuyu yükleyin, kaynak yazı tipini ve değiştirilmiş yazı tipini tanımlayın, yazı tipi değişim metodunu çağırın ve değiştirilmiş sunuyu PPTX dosyası olarak kaydedin. Bu yaklaşım, bir sunu içinde bir yazı tipi ailesinden diğerine kasıtlı olarak geçmek istediğinizde faydalıdır.

## **Yazı Tipi Değiştirme**

Bir yazı tipini kullanma kararınızı değiştirirseniz, o yazı tipini başka bir yazı tipiyle değiştirebilirsiniz. Eski yazı tipinin tüm örnekleri yeni yazı tipiyle değiştirilecektir.

Aspose.Slides bu şekilde bir yazı tipini değiştirmenizi sağlar:

1. İlgili sunuyu yükleyin.
2. Değiştirilecek yazı tipini yükleyin.
3. Yeni yazı tipini yükleyin.
4. Yazı tipini değiştirin.
5. Değiştirilmiş sunuyu PPTX dosyası olarak yazın.

``` cpp
// Bir sunuyu yükler
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Değiştirilecek kaynak yazı tipini yükler
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Yeni yazı tipini yükler
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Yazı tiplerini değiştirir
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Sunuyu kaydeder
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Belirli koşullarda (örneğin bir yazı tipine erişilemediğinde) ne olacağını belirleyen kuralları ayarlamak için [**Yazı Tipi Değiştirme**](/slides/tr/cpp/font-substitution/) bölümüne bakın.
{{% /alert %}}

## **SSS**

**“font replacement”, “font substitution” ve “fallback fonts” arasındaki fark nedir?**

Replacement, bütün belge boyunca bir aileden diğerine kasıtlı bir geçiştir. [Substitution](/slides/tr/cpp/font-substitution/) “eğer yazı tipi mevcut değilse X'i kullan” gibi bir kuraldır. [Fallback](/slides/tr/cpp/fallback-font/) ise temel yazı tipi kurulu ancak gereken karakterleri içermediğinde, eksik glifler için bireysel olarak uygulanır.

**Değiştirme, master slaytlar, düzenler, notlar ve yorumlar için geçerli mi?**

Evet. Değiştirme, orijinal yazı tipini kullanan tüm sunu nesnelerini etkiler; master slaytlar ve notlar dahil; yorumlar da belgenin bir parçasıdır ve yazı tipi motoru tarafından dikkate alınır.

**Gömülü OLE nesneleri (örneğin Excel) içindeki yazı tipi değişecek mi?**

Hayır. [OLE içeriği](/slides/tr/cpp/manage-ole/) kendi uygulaması tarafından kontrol edilir. Sunuda gerçekleştirilen değiştirme, iç OLE verilerini yeniden biçimlendirmez; OLE, görüntü olarak ya da dışarıdan düzenlenebilir içerik olarak gösterilebilir.

**Sununun sadece bir kısmında (slaytlar veya bölgeler bazında) bir yazı tipini değiştirebilir miyim?**

Hedeflenmiş değiştirme, tüm belgeye küresel bir değişiklik yapmadan, gerekli nesne/alan düzeyinde yazı tipini değiştirerek mümkündür. Render sırasında genel yazı tipi seçim mantığı aynı kalır.

**Sununun hangi yazı tiplerini kullandığını önceden nasıl belirleyebilirim?**

Sununun [font yöneticisini](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/) kullanın: bu, [kullanılan ailelerin] (https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/getfonts/) ve [yerine koyma/"bilinmeyen" yazı tiplerinin] (https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/getsubstitutions/) bir listesini sağlar; bu da değiştirme planlamasına yardımcı olur.

**Yazı tipi değiştirme, PDF/görsellere dönüştürürken çalışır mı?**

Evet. Dışa aktarım sırasında Aspose.Slides aynı [yazı tipi seçim/yerine koyma sırası](/slides/tr/cpp/font-selection-sequence/) uygular; önceden yapılan bir değiştirme dönüşüm sırasında da uygulanır.

**Hedef yazı tipini sistemde kurmam gerekir mi, yoksa bir font klasörü ekleyebilir miyim?**

Kurulum gerekli değildir: kütüphane, [harici yazı tiplerini](/slides/tr/cpp/custom-font/) kullanıcı klasörlerinden yükleyerek [render ve dışa aktarım](/slides/tr/cpp/convert-powerpoint/) sırasında kullanılmasına izin verir.

**Değiştirme, karakter yerine “tofu” (kareler) sorununu çözer mi?**

Yalnızca hedef yazı tipi gerçekten gereken glifleri içeriyorsa. Aksi takdirde eksik karakterleri kapsamak için [fallback](/slides/tr/cpp/fallback-font/) yapılandırın.