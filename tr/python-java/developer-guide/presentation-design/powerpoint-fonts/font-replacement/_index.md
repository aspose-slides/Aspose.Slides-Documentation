---
title: Python aracılığıyla Java kullanarak Sunumlarda Yazı Tipi Değişimini Kolaylaştırın
linktitle: Yazı Tipi Değiştirme
type: docs
weight: 60
url: /tr/python-java/font-replacement/
keywords:
- yazı tipi
- yazı tipi değiştir
- yazı tipi değiştirme
- yazı tipini değiştir
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Python üzerinden Java ile Aspose.Slides'te yazı tiplerini sorunsuz bir şekilde değiştirerek PowerPoint ve OpenDocument sunumlarında tutarlı tipografi sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunum boyunca bir yazı tipini başka bir yazı tipi ile değiştirmenize olanak tanır. Bir yazı tipi değiştirildiğinde, orijinal yazı tipinin tüm örnekleri yeni yazı tipine dönüştürülür.

Yazı tipi değişimini gerçekleştirmek için sunumu yükleyin, kaynak yazı tipini ve değiştirme yazı tipini tanımlayın, yazı tipi değişim metodunu çağırın ve değiştirilmiş sunumu PPTX dosyası olarak kaydedin. Bu yaklaşım, sunum boyunca bir yazı tipi ailesinden başka birine bilinçli olarak geçmek istediğinizde faydalıdır.

## **Yazı Tiplerini Değiştir**

Bir yazı tipini kullanma konusunda fikrinizi değiştirirseniz, o yazı tipini başka bir yazı tipiyle değiştirebilirsiniz. Eski yazı tipinin tüm örnekleri yeni yazı tipiyle değiştirilecektir.

Aspose.Slides, bir yazı tipini bu şekilde değiştirmenize olanak tanır:

1. İlgili sunumu yükleyin.  
2. Değiştirilecek yazı tipini yükleyin.  
3. Yeni yazı tipini yükleyin.  
4. Yazı tipini değiştirin.  
5. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Python kodu, yazı tipi değişimini gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat

# Bir sunumu yükle.
presentation = Presentation("Fonts.pptx")
try:
    # Değiştirilecek kaynak yazı tipini yükle.
    source_font = FontData("Arial")

    # Yeni yazı tipini yükle.
    destination_font = FontData("Times New Roman")

    # Yazı tipini değiştir.
    presentation.getFontsManager().replaceFont(source_font, destination_font)

    # Sunumu kaydet.
    presentation.save("UpdatedFont_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Not" color="info" %}} 
Belirli koşullarda (örneğin bir yazı tipine erişilemediğinde) ne olacağını belirleyen kuralları ayarlamak için, [Font Substitution](/slides/tr/python-java/font-substitution/) bölümüne bakın. 
{{% /alert %}}

## **SSS**

**"font replacement", "font substitution" ve "fallback fonts" arasındaki fark nedir?**  

Değiştirme, tüm belge boyunca bir aileden başka bir aileye kasıtlı bir geçiştir. [Substitution](/slides/tr/python-java/font-substitution/) "eğer yazı tipi mevcut değilse, X kullan" gibi bir kuraldır. [Fallback](/slides/tr/python-java/fallback-font/) ise temel yazı tipi yüklü olduğunda ama gerekli karakterleri içermediğinde eksik glyph'lere bireysel olarak uygulanır.

**Değiştirme, ana slaytlara, düzenlere, notlara ve yorumlara uygulanır mı?**  

Evet. Değiştirme, orijinal yazı tipini kullanan tüm sunum nesnelerini etkiler; ana slaytlar ve notlar dahil. Yorumlar da belgenin bir parçasıdır ve yazı tipi motoru tarafından dikkate alınır.

**Gömülü OLE nesneleri içinde (örneğin Excel) yazı tipi değişecek mi?**  

Hayır. [OLE content](/slides/tr/python-java/manage-ole/) kendi uygulaması tarafından kontrol edilir. Sunumdaki değiştirme, iç OLE verilerini yeniden biçimlendirmez; bu veri bir resim olarak ya da dışarıdan düzenlenebilir içerik olarak görüntülenebilir.

**Yazı tipini sadece sunumun bir bölümünde (slaytlar veya bölgeler bazında) değiştirebilir miyim?**  

Hedeflenmiş değiştirme, tüm belgeye küresel bir değiştirme uygulamak yerine, gereken nesne/aralık seviyesinde yazı tipini değiştirirseniz mümkündür. Renderleme sırasında genel yazı tipi seçim mantığı aynı kalır.

**Sunumun önceden hangi yazı tiplerini kullandığını nasıl belirleyebilirim?**  

Sunumun [font manager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/) özelliğini kullanın: bu, kullanılan [font manager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#getFonts) bir listesini ve [font manager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#getSubstitutions) hakkında bilgi verir; bu da değişikliği planlamaya yardımcı olur.

**Yazı tipi değiştirme, PDF/görsellere dönüştürürken çalışır mı?**  

Evet. Dışa aktarım sırasında, Aspose.Slides aynı [font selection/substitution sequence](/slides/tr/python-java/font-selection-sequence/) uygular, bu yüzden önceden yapılan bir değiştirme dönüşüm sırasında uygulanır.

**Hedef yazı tipini sisteme kurmam gerekir mi, yoksa bir fonts klasörü ekleyebilir miyim?**  

Kurulum gerekli değildir: kütüphane, kullanıcı klasörlerinden [loading external fonts](/slides/tr/python-java/custom-font/) yüklemeye izin verir; bu, [rendering and export](/slides/tr/python-java/convert-powerpoint/) sırasında kullanılabilir.

**Değiştirme, karakterler yerine görülen "tofu" (kareler) sorununu çözer mi?**  

Sadece hedef yazı tipi gerçekten gerekli glyph'leri içeriyorsa. İçermiyorsa, eksik karakterleri kapsamak için [configure fallback](/slides/tr/python-java/fallback-font/) yapın.