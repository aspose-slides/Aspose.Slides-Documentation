---
title: SSS
type: docs
weight: 340
url: /tr/php-java/faqs/
keywords:
- SSS
- sunum formatı
- bellek yetersizliği hatası
- slayt boyutu
- metin çıkartma
- metin alma
- paragraf boyutu
- tablo biçimlendirme
- yazı tipi
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java hakkında SSS cevaplarını alın, PowerPoint ve OpenDocument desteği, kurulum rehberi, lisanslama ve sorun giderme konularını kapsar."
---
## **Genel Bakış**

Bu SSS, Aspose.Slides hakkında yaygın sorulara yanıtlar sağlar. Desteklenen dosya formatlarını, büyük sunumlarla çalışırken istisna işleme, slayt boyutlarını değiştirme, slaytları ön izleme, sunumlardan metin alma, tablo kenarlıklarını biçimlendirme, resim yerleştirme ve sunumları PDF veya görüntülere dönüştürürken ortaya çıkan yazı tipiyle ilgili sorunları ele alır.

## **Desteklenen Dosya Formatları**

**Q: Aspose.Slides for PHP via Java hangi dosya formatlarını destekliyor?**

**A**: Aspose.Slides for PHP via Java, [Desteklenen Dosya Formatları](/slides/tr/php-java/supported-file-formats/) içinde açıklanan dosya formatlarını destekler.

## **İstisnalar**

**Q: Görüntüler içeren büyük bir PPT dosyasını yüklerken bellek yetersizliği istisnası alıyorum. Aspose.Slides'de dosya boyutu ile ilgili bir sınırlama var mı?**

**A**: Aspose.Slides tarafından desteklenen sunum boyutunu hesaplamak için belirli bir formül yoktur. Bellekte tüm sunum yapısını ve görüntüleri barındıracak kadar alan olmalıdır. Normalde, bellekteki görüntüler sabit diskten daha fazla yer kaplar, özellikle görüntülere ek efektler uygulandığında.

Genel olarak, Aspose.Slides for PHP via Java, 4 GB RAM'e sahip bir sunucuda yaklaşık 300 MB civarındaki sunum dosyalarını rahatlıkla işleyebilir.

## **Slaytlarla Çalışma**

**Q: Bir sunumdaki slaytların boyutunu değiştirebilir miyim?**

**A**: Sunumdaki slaytların boyutunu tanımlamak için `getSlideSize` yöntemini [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfından kullanabilirsiniz.

**Q: Bir sunumda farklı boyutlarda slaytlar tanımlamanın bir yolu var mı?**

**A**: Microsoft PowerPoint belgelerinde slayt boyutu sunum seviyesinde tanımlandığından, bunu yapmanın bir yolu yoktur.

**Q: Aspose.Slides for PHP via Java, kaydetmeden önce bir slaytı ön izlemeyi destekliyor mu?**

**A**: Sunum slaytlarını görüntülere renderleyebilir ve bu görüntüleri slaytları ön izlemek için kullanabilirsiniz.

## **Metinle Çalışma**

**Q: Bir sunumdan tüm metni almak mümkün mü?**

**A**: Aspose.Slides for PHP via Java, sunumlardan tüm metni almayı sağlayan çeşitli yöntemler sunan [SlideUtil](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideutil/) sınıfını sağlar.

**Q: Paragraf boyutları Windows ve Linux işletim sistemlerinde neden farklıdır?**

**A**: Paragraf boyutlarının hesaplanması, ilgili paragrafı temsil eden metin boyutunun hesaplamasına dayanır. Metin boyutu hesabı, PowerPoint sunumunda belirtilen yazı tipinin metriklerine dayanır. Belirtilen yazı tipi eksikse, en benzer yazı tipiyle değiştirilir, ancak bu yazı tipinin metrikleri orijinalden farklıdır. Sonuç olarak, farklı sistemlerdeki paragraf boyutu hesaplamaları, yüklü yazı tiplerinin setine bağlı olarak farklı sonuçlar verir. Farklı işletim sistemlerinde aynı sonucu elde etmek için aynı yazı tiplerini sistemlere kurmalı veya bunları çalışma zamanında [harici yazı tipleri](/slides/tr/php-java/custom-font/) olarak yüklemelisiniz.

## **Biçimlendirme ve Görüntüler**

**Q: Bir tablo kenarlığının rengini nasıl ayarlayabilirim?**

**A**: Tüm tablo kenarlıklarının rengini ya da sadece bütün tabloyu çevreleyen kenarlığın rengini değiştirebilirsiniz. Tüm kenarlıkları değiştirmek için [Cell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cell/) sınıfındaki `getCellFormat` yöntemini kullanın. Tüm tablo kenarlığı için hücreleri döngüye alıp dış kenarlıkların rengini değiştirmeniz gerekir.

**Q: Aspose.Slides for PHP via Java, resimleri konumlandırmak için hangi ölçüyü kullanır?**

**A**: Slaytlardaki tüm şekillerin koordinatları ve boyutları nokta (point) cinsinden ölçülür (72 dpi).

## **Yazı Tipleriyle Çalışma**

**Q: PPT'yi PDF veya görüntülere dönüştürürken, çıktı belgelerindeki yazı tipleri neden farklıdır?**

**A**: Bu sorun, sunumda kullanılan yazı tiplerinin kodun çalıştırıldığı işletim sisteminde bulunmadığını gösterebilir. Yazı tiplerini işletim sistemine kurmalı veya aşağıda gösterildiği gibi [FontsLoader](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsloader/) sınıfını kullanarak harici yazı tipleri olarak yüklemelisiniz:
```php
$folders = ["path_to_a_folder_with_fonts"];
FontsLoader::loadExternalFonts($folders);
```