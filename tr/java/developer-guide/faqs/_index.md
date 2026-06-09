---
title: SSS
type: docs
weight: 340
url: /tr/java/faqs/
keywords:
- SSS
- sunum formatı
- bellek yetersizliği hatası
- slayt boyutu
- metin çıkarma
- metin alma
- paragraf boyutu
- tablo biçimlendirme
- yazı tipi
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java hakkındaki SSS'ye yanıtlar alın, PowerPoint ve OpenDocument desteği, kurulum rehberi, lisanslama ve sorun giderme konularını kapsar."
---
## **Genel Bakış**

Bu SSS, Aspose.Slides ile ilgili yaygın sorulara yanıtlar sağlar. Desteklenen dosya formatları, büyük sunumlarla çalışırken oluşan istisnaların yönetimi, slayt boyutlarının değiştirilmesi, slayt önizleme, sunumlardan metin alma, tablo kenarlıklarını biçimlendirme, resim yerleştirme ve sunumları PDF veya görüntülere dönüştürürken ortaya çıkan yazı tipi ile ilgili sorunların çözülmesini kapsar.

## **Desteklenen Dosya Formatları**

**Q: Aspose.Slides for Java hangi dosya formatlarını destekliyor?**

**A:** Aspose.Slides for Java, [Supported File Formats](/slides/tr/java/supported-file-formats/) sayfasında açıklanan dosya formatlarını destekler.

## **İstisnalar**

**Q: Büyük bir PPT dosyasını resimlerle yüklerken bellek dışı istisna alıyorum. Aspose.Slides’ta dosya boyutu konusunda bir sınırlama var mı?**

**A:** Aspose.Slides tarafından desteklenen sunum boyutunu hesaplamak için belirli bir formül yoktur. Bellekte tüm sunum yapısını ve resimleri barındırabilecek kadar alan olmalıdır. Normalde, bellek içindeki resimler sabit disktekinden daha fazla yer kaplar, özellikle resimlere ek efektler eklendiğinde.

Genel olarak, Aspose.Slides for Java, 4 GB RAM’e sahip bir sunucuda yaklaşık 300 MB boyutundaki sunum dosyalarını kolaylıkla işleyebilir.

## **Slaytlarla Çalışma**

**Q: Bir sunumdaki slaytların boyutunu değiştirebilir miyim?**

**A:** `getSlideSize` metodunu, sunumdaki slaytların boyutunu tanımlamak için [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfı üzerinden kullanabilirsiniz.

**Q: Bir sunumda farklı boyutta slaytlar tanımlamanın bir yolu var mı?**

**A:** Microsoft PowerPoint belgelerinde slayt boyutu sunum seviyesinde tanımlandığından, bunu yapmanın bir yolu yoktur.

**Q: Aspose.Slides for Java, kaydetmeden önce bir slaytı önizlemeyi destekliyor mu?**

**A:** Sunum slaytlarını görüntülere renderlayabilir ve bu görüntüleri slaytları önizlemek için kullanabilirsiniz.

## **Metinle Çalışma**

**Q: Bir sunumdan tüm metni almak mümkün mü?**

**A:** Aspose.Slides for Java, sunumlardan tüm metni almak için çeşitli yöntemler sunan [SlideUtil](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideutil/) sınıfını sağlar.

**Q: Paragraf boyutları Windows ve Linux işletim sistemlerinde neden farklıdır?**

**A:** Paragraf boyutlarının hesabı, ilgili paragrafı temsil eden metin boyutunun hesabına dayanır. Metin boyutu hesabı, PowerPoint sunumunda belirtilen yazı tipinin metriklerine göre yapılır. Belirtilen yazı tipi eksikse, en benzer yazı tipi ile değiştirilir, ancak bu yazı tipinin metrikleri orijinalinden farklıdır. Sonuç olarak, farklı sistemlerdeki paragraf boyutu hesabı, yüklü yazı tipi kümesine bağlı olarak farklı sonuçlar verir. Farklı işletim sistemlerinde aynı sonucu elde etmek için aynı yazı tiplerini sistemlere kurmanız veya bunları çalışma zamanında [external fonts](/slides/tr/java/custom-font/) olarak yüklemeniz gerekir.

## **Biçimlendirme ve Görüntüler**

**Q: Bir tablo kenarlığının rengini nasıl ayarlayabilirim?**

**A:** Tüm tablo kenarlıklarının rengini ya da yalnızca tüm tabloyu çevreleyen kenarlığın rengini değiştirebilirsiniz. Tüm kenarlıkları değiştirmek için lütfen [ICell](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icell/) arayüzündeki `getCellFormat` metodunu kullanın. Tüm tablo kenarlığı için hücreleri döngü ile gezip dış kenarlıkların rengini değiştirmeniz gerekir.

**Q: Aspose.Slides for Java resimleri yerleştirirken hangi ölçüyü kullanır?**

**A:** Slaytlardaki tüm şekillerin koordinatları ve boyutları puan (point) cinsinden ölçülür (72 dpi).

## **Yazı Tipleriyle Çalışma**

**Q: PPT'yi PDF veya görüntülere dönüştürürken, çıktı belgelerindeki yazı tipleri neden farklıdır?**

**A:** Bu sorun, sunumda kullanılan yazı tiplerinin kodun çalıştırıldığı işletim sisteminde bulunmadığını gösterebilir. Yazı tiplerini işletim sistemine kurmalı veya aşağıda gösterildiği gibi [FontsLoader](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/) sınıfını kullanarak dış yazı tipleri olarak yüklemelisiniz:
```cs
var folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```