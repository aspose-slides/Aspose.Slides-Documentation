---
title: SSS
type: docs
weight: 340
url: /tr/python-java/faqs/
keywords:
- SSS
- sunum formatı
- bellek yetersizliği hatası
- slayt boyutu
- metin çıkarma
- paragraf boyutu
- tablo kenarlıkları
- yazı tipi
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java hakkında dosya formatları, bellek kullanımı, slayt boyutları, metin, tablolar, görseller ve yazı tipleri dahil olmak üzere sık sorulan soruların cevaplarını bulun."
---
## **Genel Bakış**

Bu SSS, desteklenen dosya formatlarını, büyük sunumlarda bellek kullanımını, slayt boyutlarını ve ön izlemeleri, metin çıkarımını, tablo kenarlıklarını, resim yerleştirmeyi ve sunumları PDF veya görüntülere dönüştürürken oluşan yazı tipi farklılıklarını kapsar.

## **SSS**

### **Desteklenen Dosya Formatları**

**Aspose.Slides for Python via Java hangi dosya formatlarını destekliyor?**

Desteklenen sunum, belge ve görüntü formatları ile bunların içe ve dışa aktarma yetenekleri için [Desteklenen Dosya Formatları](/slides/tr/python-java/supported-file-formats/) sayfasına bakın.

### **İstisnalar**

**Büyük bir sunumu görüntülerle yüklerken neden bellek yetersizliği hatası alıyorum? Dosya boyutu için bir sınır var mı?**

Sunumun belleğe sığacağını tahmin eden tek bir dosya boyutu eşiği yoktur. Bellek gereksinimleri, sunumun yapısına, sıkıştırılmamış görüntülere, efektlere ve gerçekleştirilen işlemlere bağlıdır. Görüntüler, diskteki sıkıştırılmış boyutlarından çok daha fazla bellek tüketebilir.

Aspose.Slides for Python via Java, JPype aracılığıyla Java motorunu kullandığından, JVM yığını işlemler için yeterli alana sahip olmalıdır. Yalnızca sistem RAM’i, JVM’nin ne kadar bellek kullanabileceğini göstermez. Sunumu kullandıktan sonra [Presentation.dispose](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#dispose) ile serbest bırakın. Ortam kurulumu için [Sistem Gereksinimleri](/slides/tr/python-java/system-requirements/) ve [Kurulum](/slides/tr/python-java/installation/) sayfalarına bakın.

### **Slaytlarla Çalışma**

**Bir sunumdaki slaytların boyutunu değiştirebilir miyim?**

Evet. Sunumun slayt boyutu ayarlarına erişmek için [Presentation.getSlideSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getslidesize) yöntemini kullanın, ardından boyutları ayarlamak ve mevcut içeriğin nasıl ölçekleneceğini seçmek için [SlideSize.setSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesize/#setsize) yöntemini kullanın.

**Aynı sunumdaki slaytlar farklı boyutlarda olabilir mi?**

Hayır. Microsoft PowerPoint belgeleri slayt boyutunu sunum seviyesinde tanımlar, bu nedenle tüm slaytlar aynı boyutları paylaşır.

**Sunumu kaydetmeden bir slaytı önizleyebilir miyim?**

Evet. Slaytı bir görüntüye render edip uygulamanızda bu görüntüyü görüntüleyin. Sunumu önceden kaydetmeniz gerekmez.

### **Metinle Çalışma**

**Bir sunumdan tüm metni alabilir miyim?**

Evet. [SlideUtil](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideutil/) sınıfı, sunumlardan ve tek tek slaytlardan metin almayı sağlayan yöntemler sunar.

**Paragraf boyutları Windows ve Linux’ta neden farklı?**

Paragraf boyutları, metni oluşturan yazı tiplerinin metriklerine bağlıdır. Bir yazı tipi eksikse, yerine kullanılan alternatif farklı karakter genişlikleri ve satır yüksekliği ile sonuçlanabilir; bu da satır kaydırma ve paragraf boyutlarını değiştirir. Her iki sistemde de aynı yazı tiplerini kurun veya sunumları oluşturup yüklemeden önce [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsloader/#loadexternalfonts) ile aynı yazı tipi dosyalarını yükleyin.

### **Biçimlendirme ve Görseller**

**Bir tablo kenarlığının rengini nasıl ayarlarım?**

Her hücrenin kenarlık biçimlendirmesine erişmek ve ilgili kenarlıkların dolgu rengini ayarlamak için [Cell.getCellFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/cell/#getcellformat) yöntemini kullanın. Tüm kenarlıkları değiştirmek için tüm hücreleri işleyin. Yalnızca tablonun dış çerçevesini değiştirmek istiyorsanız, kenar hücrelerinin dışa bakan kenarlıklarını güncelleyin.

**Resimleri konumlandırmak ve boyutlandırmak için hangi birimler kullanılır?**

Şekil koordinatları ve boyutları punto biriminde ölçülür. Bir inç 72 puntoya eşittir; bu değerler piksel koordinatı değildir.

### **Yazı Tipleriyle Çalışma**

**Sunumu PDF ya da görüntülere dönüştürdüğümde yazı tipleri neden değişiyor?**

Dönüştürmeyi yapan makinede gerekli yazı tipleri eksik olabilir. Orijinal yazı tiplerini kurun veya [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsloader/#loadexternalfonts) ile içerdikleri klasörleri ekleyin. Harici yazı tiplerini sunumları oluşturup açmadan önce yükleyin.

Aşağıdaki örnek bir yazı tipi klasörünü kaydeder. Yolunuzu, içinde yazı tipi dosyalarınız olan mevcut bir klasörle değiştirin. Ortamın [Kurulum](/slides/tr/python-java/installation/) sayfasında açıklandığını varsayar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontsLoader

font_folders = jpype.JArray(jpype.JString)(["path_to_a_folder_with_fonts"])
FontsLoader.loadExternalFonts(font_folders)
```

Örnek, sonraki sunum işlemleri için JVM’yi çalışır durumda bırakır. Notebook kullanımı ve JVM yaşam döngüsü kısıtlamaları için [Sınırlamalar ve API Farklılıkları](/slides/tr/python-java/limitations-and-api-differences/) sayfasına bakın.