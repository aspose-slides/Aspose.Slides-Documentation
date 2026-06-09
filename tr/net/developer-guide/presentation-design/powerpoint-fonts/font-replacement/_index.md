---
title: .NET'te Sunumlarda Yazı Tipi Değişimini Kolaylaştırın
linktitle: Yazı Tipi Değişimi
type: docs
weight: 60
url: /tr/net/font-replacement/
keywords:
- yazı tipi
- yazı tipini değiştir
- yazı tipi değişimi
- yazı tipi değiştir
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te yazı tiplerini sorunsuz bir şekilde değiştirerek PowerPoint ve OpenDocument sunumlarında tutarlı tipografi sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunum boyunca bir yazı tipini başka bir yazı tipiyle değiştirmenizi sağlar. Bir yazı tipi değiştirildiğinde, orijinal yazı tipinin tüm örnekleri yeni yazı tipine dönüştürülür.

Yazı tipi değişimini gerçekleştirmek için sunumu yükleyin, kaynak yazı tipini ve değiştirilecek yazı tipini tanımlayın, yazı tipi değiştirme metodunu çağırın ve değiştirilmiş sunumu PPTX dosyası olarak kaydedin. Bu yaklaşım, bir sunum içinde bir yazı tipi ailesinden başka birine kasıtlı olarak geçmek istediğinizde faydalıdır.

## **Yazı Tiplerini Değiştir**

Bir yazı tipini kullanmak istemediğinizde, o yazı tipini başka bir yazı tipiyle değiştirebilirsiniz. Eski yazı tipinin tüm örnekleri yeni yazı tipiyle yer değiştirir. 

Aspose.Slides bu şekilde bir yazı tipini değiştirmenize olanak tanır:

1. İlgili sunumu yükleyin. 
2. Değiştirilecek yazı tipini yükleyin. 
3. Yeni yazı tipini yükleyin. 
4. Yazı tipini değiştirin. 
5. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Bu C# kodu yazı tipi değişimini gösterir:

```c#
// Bir sunumu yükler
Presentation presentation = new Presentation("Fonts.pptx");

// Değiştirilecek kaynak yazı tipini yükler
IFontData sourceFont = new FontData("Arial");

// Yeni yazı tipini yükler
IFontData destFont = new FontData("Times New Roman");

// Yazı tiplerini değiştirir
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// Sunumu kaydeder
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```

{{% alert title="Note" color="warning" %}} 

Belirli koşullarda ne olacağını belirleyen kuralları ayarlamak için (örneğin bir yazı tipine erişilemezse), bakın [**Yazı Tipi Yerine Koyma**](/slides/tr/net/font-substitution/). 

{{% /alert %}}

## **SSS**

**"Yazı tipi değişimi", "yazı tipi yerine koyma" ve "yedek yazı tipleri" arasındaki fark nedir?**

Değişim, bütün belge boyunca bir aileden başka bir aileye kasıtlı bir geçiştir. [Yerine koyma](/slides/tr/net/font-substitution/) “yazı tipi bulunamazsa X kullanılacak” gibi bir kuraldır. [Yedek](/slides/tr/net/fallback-font/) temel yazı tipi yüklü ama gerekli karakterleri içermediğinde eksik glifler için bireysel olarak uygulanır.

**Değişim ana slaytlar, düzenler, notlar ve yorumlar için geçerli midir?**

Evet. Değişim, orijinal yazı tipini kullanan tüm sunum nesnelerini etkiler; ana slaytlar ve notlar dahil; yorumlar da belgenin bir parçası olduğundan yazı tipi motoru tarafından dikkate alınır.

**Yerleşik OLE nesneleri içinde (örneğin Excel) yazı tipi değişecek mi?**

Hayır. [OLE içeriği](/slides/tr/net/manage-ole/) kendi uygulaması tarafından kontrol edilir. Sunumdaki değişim, iç OLE verilerini yeniden biçimlendirmez; içerik bir resim olarak ya da dışarıdan düzenlenebilir bir içerik olarak gösterilebilir.

**Yazı tipini sadece sunumun bir kısmında (slayt veya bölge bazında) değiştirebilir miyim?**

Hedef odaklı değişim mümkündür; yazı tipini gerektiren nesne/alan seviyesinde değiştirirseniz, belgeye küresel bir değişim uygulamaktan farklı olur. İşleme sırasında kullanılan genel yazı tipi seçimi mantığı aynı kalır.

**Sunumun hangi yazı tiplerini kullandığını önceden nasıl öğrenebilirim?**

Sunumun [yazı tipi yöneticisini](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/) kullanın: bu, kullanılan [yazı tipi ailelerinin]https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/getfonts/) bir listesini ve [yerine koyma/"bilinmeyen" yazı tipleri](/slides/tr/net/font-substitution/) hakkında bilgi sağlar; bu da değişim planlamasına yardımcı olur.

**Yazı tipi değişimi PDF/görsellere dönüştürürken çalışır mı?**

Evet. Dışa aktarım sırasında Aspose.Slides aynı [yazı tipi seçimi/yerine koyma sırasını](/slides/tr/net/font-selection-sequence/) uygular; önceden yapılan bir değişim, dönüştürme sırasında da uygulanır.

**Hedef yazı tipini sisteme kurmam gerekir mi, yoksa bir fonts klasörü ekleyebilir miyim?**

Kurulum gerekmiyor: kütüphane, [harici yazı tiplerini](/slides/tr/net/custom-font/) kullanıcı klasörlerinden yükleyerek [renderleme ve dışa aktarma](/slides/tr/net/convert-powerpoint/) sırasında kullanılmasına imkan verir.

**Değişim, karakterler yerine “tofu” (kareler) sorununu çözer mi?**

Yalnızca hedef yazı tipi gerçekten gerekli glifleri içeriyorsa. İçermiyorsa, eksik karakterleri kapsamak için [yedek yapılandırın](/slides/tr/net/fallback-font/).