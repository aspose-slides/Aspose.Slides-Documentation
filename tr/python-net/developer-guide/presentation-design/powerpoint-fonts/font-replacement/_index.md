---
title: Sunumlarda Python Kullanarak Yazı Tipi Değişimini Hızlandırma
linktitle: Yazı Tipi Değiştirme
type: docs
weight: 60
url: /tr/python-net/font-replacement/
keywords:
- yazı tipi
- yazı tipi değiştir
- yazı tipi değiştirme
- yazı tipini değiştir
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides Python via .NET içinde yazı tiplerini sorunsuz bir şekilde değiştirerek PowerPoint ve OpenDocument sunumlarında tutarlı tipografi sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunum boyunca bir yazı tipini başka bir yazı tipiyle değiştirmenize olanak tanır. Bir yazı tipi değiştirildiğinde, orijinal yazı tipinin tüm örnekleri yeni yazı tipiyle değiştirilir.

Yazı tipi değişimini gerçekleştirmek için sunumu yükleyin, kaynak yazı tipini ve değiştirilecek yazı tipini tanımlayın, yazı tipi değiştirme yöntemini çağırın ve değiştirilen sunumu PPTX dosyası olarak kaydedin. Bu yaklaşım, sunum boyunca kasıtlı olarak bir yazı tipi ailesinden başka birine geçmek istediğinizde yararlıdır.

## **Yazı Tiplerini Değiştir**

Bir yazı tipini kullanma fikrinizi değiştirirseniz, o yazı tipini başka bir yazı tipiyle değiştirebilirsiniz. Eski yazı tipinin tüm örnekleri yeni yazı tipiyle değiştirilecektir.

Aspose.Slides bu şekilde bir yazı tipini değiştirmenizi sağlar:

1. İlgili sunumu yükleyin. 
2. Değiştirilecek yazı tipini yükleyin. 
3. Yeni yazı tipini yükleyin. 
4. Yazı tipini değiştirin. 
5. Değiştirilen sunumu PPTX dosyası olarak yazın.

Bu Python kodu yazı tipi değişimini gösterir:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Sunumu yüklüyor
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Değiştirilecek kaynak yazı tipini yüklüyor
    sourceFont = slides.FontData("Arial")

    # Yeni yazı tipini yüklüyor
    destFont = slides.FontData("Times New Roman")

    # Yazı tiplerini değiştiriyor
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Sunumu kaydediyor
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 

Belirli koşullarda (örneğin bir yazı tipine erişilemezse) ne olacağını belirleyen kuralları ayarlamak için [**Yazı Tipi Değiştirme**](/slides/tr/python-net/font-substitution/) bölümüne bakın. 

{{% /alert %}}

## **SSS**

**"Yazı tipi değiştirme", "yazı tipi değiştirme (substitution)" ve "yedek (fallback) yazı tipleri" arasındaki fark nedir?**

Değiştirme, tüm belge boyunca bir aileden başka bir aileye kasıtlı bir geçiştir. [Değiştirme (Substitution)](/slides/tr/python-net/font-substitution/) “yazı tipi kullanılamıyorsa X kullan” gibi bir kuraldır. [Yedek (Fallback)](/slides/tr/python-net/fallback-font/) ise temel yazı tipi kurulu ancak gerekli karakterleri içermediğinde eksik glifler için bireysel olarak uygulanır.

**Değiştirme ana slaytlar, düzenler, notlar ve yorumlar için geçerli mi?**

Evet. Değiştirme, ana slaytlar ve notlar da dahil olmak üzere orijinal yazı tipini kullanan tüm sunum nesnelerini etkiler; yorumlar da belgenin bir parçasıdır ve yazı tipi motoru tarafından dikkate alınır.

**Gömülü OLE nesneleri (örneğin Excel) içinde yazı tipi değişecek mi?**

Hayır. [OLE içeriği](/slides/tr/python-net/manage-ole/) kendi uygulaması tarafından kontrol edilir. Sunumdaki değiştirme, iç OLE verilerini yeniden biçimlendirmez; OLE içeriği bir resim olarak veya dışarıdan düzenlenebilir içerik olarak görüntülenebilir.

**Yazı tipini sadece sunumun bir bölümü (slaytlar veya bölgeler) için değiştirebilir miyim?**

Hedeflenmiş değiştirme, tüm belgeye küresel bir değiştirme uygulamak yerine, gerekli nesneler/alanlar düzeyinde yazı tipini değiştirirseniz mümkündür. İşleme sırasında genel yazı tipi seçim mantığı aynı kalır.

**Sunumun kullandığı tüm yazı tiplerini önceden nasıl belirleyebilirim?**

Sunumun [font manager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/) kullanın: bu, kullanımda olan [yazı tipi ailelerinin] (https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_fonts/) bir listesini ve [değiştirmeler/“bilinmeyen” yazı tipleri] (https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_substitutions/) hakkında bilgi sağlar; bu da değiştirme planlamasına yardımcı olur.

**Yazı tipi değiştirme, PDF/görsellere dönüştürürken çalışır mı?**

Evet. Dışa aktarma sırasında Aspose.Slides aynı [yazı tipi seçim/değiştirme sırasını](/slides/tr/python-net/font-selection-sequence/) uygular, bu yüzden önceden yapılan bir değiştirme dönüştürme sırasında da uygulanır.

**Hedef yazı tipini sistemde kurmam gerekiyor mu, yoksa bir font klasörü ekleyebilir miyim?**

Kurulum gerekli değildir: kütüphane, [harici yazı tiplerini](/slides/tr/python-net/custom-font/) kullanıcı klasörlerinden yükleyerek [render ve dışa aktarma](/slides/tr/python-net/convert-powerpoint/) sırasında kullanılmasına olanak tanır.

**Değiştirme, karakterler yerine “tofu” (kareler) sorununu çözer mi?**

Sadece hedef yazı tipi gerçekten gerekli glifleri içeriyorsa işe yarar. İçermiyorsa, eksik karakterleri kapsamak için [yedek yapılandırın](/slides/tr/python-net/fallback-font/).