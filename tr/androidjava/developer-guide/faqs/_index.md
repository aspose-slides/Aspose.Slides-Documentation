---
title: SSS
type: docs
weight: 340
url: /tr/androidjava/faqs/
keywords:
- SSS
- sunum formatı
- bellek yetersizliği hatası
- slayt boyutu
- metin çıkarma
- metin alma
- paragraf boyutu
- tabloları biçimlendirme
- yazı tipi
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java hakkındaki SSS cevaplarını alın, PowerPoint ve OpenDocument desteği, kurulum rehberi, lisanslama ve sorun giderme konularını kapsar."
---
## **Genel Bakış**

Bu SSS, Aspose.Slides hakkında sık sorulan sorulara yanıtlar sağlar. Desteklenen dosya formatlarını, büyük sunumlarla çalışırken istisna yönetimini, slayt boyutlarını değiştirmeyi, slaytların önizlemesini, sunumlardan metin almayı, tablo kenarlıklarını biçimlendirmeyi, resim yerleştirmeyi ve sunumları PDF veya görüntülere dönüştürürken ortaya çıkan yazı tipiyle ilgili sorunları çözer.

## **Desteklenen Dosya Formatları**

**Q:** Aspose.Slides for Android via Java hangi dosya formatlarını destekliyor?

**A:** Aspose.Slides for Android via Java, [Desteklenen Dosya Formatları](/slides/tr/androidjava/supported-file-formats/) adresinde açıklanan dosya formatlarını destekler.

## **İstisnalar**

**Q:** Büyük bir PPT dosyasını görsellerle yüklerken bellek dışı istisna alıyorum. Aspose.Slides için dosya boyutu konusunda bir sınırlama var mı?

**A:** Aspose.Slides tarafından desteklenen sunum büyüklüğünü hesaplamak için belirli bir formül yoktur. Bellekte tüm sunum yapısını ve görselleri barındıracak kadar alan bulunmalıdır. Normalde, bellekteki görseller, sabit diskteki yerlerinden daha fazla yer kaplar, özellikle görsellere ek efektler eklendiğinde.

Genel olarak, Aspose.Slides for Android via Java, 4 GB RAM'li bir sunucuda yaklaşık 300 MB civarındaki sunum dosyalarını sorunsuz şekilde işleyebilir.

## **Slaytlarla Çalışma**

**Q:** Sunumdaki slaytların boyutunu değiştirebilir miyim?

**A:** Sunumdaki slaytların boyutunu tanımlamak için [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfı tarafından sunulan `getSlideSize` yöntemini kullanabilirsiniz.

**Q:** Sunum içinde farklı boyutlarda slaytlar tanımlamanın bir yolu var mı?

**A:** Microsoft PowerPoint belgelerinde slayt boyutu sunum seviyesinde tanımlandığı için bunu yapmanın bir yolu yoktur.

**Q:** Aspose.Slides for Android via Java, bir slaytı kaydetmeden önce önizlemeyi destekliyor mu?

**A:** Sunum slaytlarını görüntülere renderlayabilir ve bu görüntüleri slaytların önizlemesi için kullanabilirsiniz.

## **Metinle Çalışma**

**Q:** Bir sunumdaki tüm metni almak mümkün mü?

**A:** Aspose.Slides for Android via Java, sunumlardan tüm metni alabilmek için çeşitli yöntemler sunan [SlideUtil](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideutil/) sınıfını sağlar.

**Q:** PC ve Android'de paragraf boyutları neden farklı?

**A:** Paragraf boyutlarının hesaplanması, verilen paragrafı temsil eden metin boyutunun hesaplanmasına dayanır. Metin boyutu, PowerPoint sunumunda belirtilen yazı tipinin metriklerine göre hesaplanır. Belirtilen yazı tipi eksikse, en benzer yazı tipiyle değiştirilir, ancak bu yazı tipinin metrikleri orijinalinden farklıdır. Sonuç olarak, farklı sistemlerdeki yüklü yazı tipleri kümesine bağlı olarak paragraf boyutu hesaplamaları farklı sonuçlar verir. Farklı işletim sistemlerinde aynı sonucu elde etmek için sistemlere aynı yazı tiplerini yüklemeniz veya bunları çalışma zamanında [harici yazı tipleri](/slides/tr/androidjava/custom-font/) olarak yüklemeniz gerekir.

## **Biçimlendirme ve Görseller**

**Q:** Bir tablo kenarlığının rengini nasıl ayarlayabilirim?

**A:** Tüm tablo kenarlıklarının rengini veya yalnızca tablonun etrafındaki kenarlığın rengini değiştirebilirsiniz. Tüm kenarlıkları değiştirmek için lütfen [ICell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icell/) arayüzünden `getCellFormat` yöntemini kullanın. Tablonun dış kenarlıkları için hücreleri dolaşmalı ve dış kenarlıkların rengini değiştirmelisiniz.

**Q:** Aspose.Slides for Android via Java, resimleri yerleştirirken hangi ölçüyü kullanır?

**A:** Slaytlardaki tüm şekillerin koordinatları ve boyutları nokta (point) cinsinden ölçülür (72 dpi).

## **Yazı Tipleriyle Çalışma**

**Q:** PPT'yi PDF veya görüntülere dönüştürürken, çıkış belgelerindeki yazı tipleri neden farklı?

**A:** Bu sorun, sunumda kullanılan yazı tiplerinin kodun çalıştırıldığı işletim sisteminde bulunmadığını gösterebilir. Yazı tiplerini işletim sistemine kurmalı veya aşağıdaki gibi [FontsLoader](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/) sınıfını kullanarak harici yazı tipleri olarak yüklemelisiniz:
```java
String[] folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```