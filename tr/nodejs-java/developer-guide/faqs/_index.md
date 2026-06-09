---
title: SSS
type: docs
weight: 340
url: /tr/nodejs-java/faqs/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java hakkında SSS cevaplarını alın, PowerPoint ve OpenDocument desteğini, kurulum rehberliğini, lisanslamayı ve sorun gidermeyi kapsar."
---
## **Genel Bakış**

Bu SSS, Aspose.Slides ile ilgili yaygın sorulara yanıtlar sağlar. Desteklenen dosya biçimlerini, büyük sunumlarla çalışırken istisnaların ele alınmasını, slayt boyutlarının değiştirilmesini, slaytların ön izlenmesini, sunumlardan metin alınmasını, tablo kenarlıklarının biçimlendirilmesini, resim yerleştirilmesini ve sunumların PDF veya görüntülere dönüştürülürken yazı tipiyle ilgili sorunların çözülmesini kapsar.

## **Desteklenen Dosya Biçimleri**

**Q:** Aspose.Slides for Node.js via Java hangi dosya biçimlerini destekliyor?

**A:** Aspose.Slides for Node.js via Java, [Desteklenen Dosya Biçimleri](/slides/tr/nodejs-java/supported-file-formats/) sayfasında açıklanan dosya biçimlerini destekler.

## **İstisnalar**

**Q:** Büyük bir PPT dosyasını resimlerle yüklerken bellek yetersizliği istisnası alıyorum. Aspose.Slides içinde dosya boyutu ile ilgili bir sınırlama var mı?

**A:** Aspose.Slides tarafından desteklenen sunum boyutunu hesaplamak için belirli bir formül yoktur. Bellekte tüm sunum yapısını ve resimleri barındıracak kadar alan olmalıdır. Normalde, bellek içindeki resimler, özellikle ek efektleri olduğunda, sabit diskin üzerindekinden daha fazla yer kaplar.

Genel olarak, Aspose.Slides for Node.js via Java, 4 GB RAM’e sahip bir sunucuda yaklaşık 300 MB boyutundaki sunum dosyalarını kolayca işleyebilir.

## **Slaytlarla Çalışma**

**Q:** Bir sunumdaki slaytların boyutunu değiştirebilir miyim?

**A:** Bir sunumdaki slaytların boyutunu tanımlamak için [Sunum](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfı tarafından sunulan `getSlideSize` metodunu kullanabilirsiniz.

**Q:** Bir sunumda farklı boyutlarda slaytlar tanımlamak mümkün mü?

**A:** Microsoft PowerPoint belgelerinde slayt boyutu sunum düzeyinde tanımlandığı için bunu yapmanın bir yolu yoktur.

**Q:** Aspose.Slides for Node.js via Java, kaydetmeden önce bir slaytı ön izlemeyi destekliyor mu?

**A:** Sunum slaytlarını görüntülere renderleyebilir ve bu görüntüleri slaytları ön izlemek için kullanabilirsiniz.

## **Metinle Çalışma**

**Q:** Bir sunumdan tüm metni almak mümkün mü?

**A:** Aspose.Slides for Node.js via Java, sunumlardan tüm metni almayı sağlayan çeşitli metodları sunan [SlideUtil](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideutil/) sınıfını sağlar.

**Q:** Paragraf boyutları Windows ve Linux işletim sistemlerinde neden farklıdır?

**A:** Paragraf boyutlarının hesaplanması, verilen paragrafı temsil eden metin boyutunun hesaplamasına dayanır. Metin boyutu hesabı, PowerPoint sunumunda belirtilen yazı tipinin ölçüm değerlerine dayanır. Belirtilen yazı tipi eksikse, en benzer yazı tipi ile değiştirilir, ancak bu yazı tipinin ölçüm değerleri orijinaliyle farklıdır. Sonuç olarak, farklı sistemlerdeki paragraf boyutu hesaplamaları, yüklü yazı tiplerinin setine bağlı olarak farklı sonuçlar verir. Farklı işletim sistemlerinde aynı sonucu elde etmek için aynı yazı tiplerini sistemlere kurmalı veya çalışma zamanında [harici yazı tipleri](/slides/tr/nodejs-java/custom-font/) olarak yüklemelisiniz.

## **Biçimlendirme ve Görüntüler**

**Q:** Bir tablo kenarlığının rengini nasıl ayarlayabilirim?

**A:** Tüm tablo kenarlıklarının rengini veya sadece tüm tabloyu çevreleyen kenarlığın rengini değiştirebilirsiniz. Tüm kenarlıkları değiştirmek için lütfen [Cell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cell/) sınıfından `getCellFormat` metodunu kullanın. Tüm tablo için kenarlık değiştirmek istiyorsanız, hücreleri döngüyle gezerek dış kenarlıkların rengini değiştirmeniz gerekir.

**Q:** Aspose.Slides for Node.js via Java, resimleri yerleştirirken hangi ölçü birimini kullanıyor?

**A:** Tüm şekillerin koordinat ve boyutları slaytlar üzerinde puan (point) birimiyle (72 dpi) ölçülür.

## **Yazı Tipleriyle Çalışma**

**Q:** PPT'yi PDF veya görüntülere dönüştürürken, çıktı belgelerindeki yazı tipleri neden farklıdır?

**A:** Bu sorun, sunumda kullanılan yazı tiplerinin kodun çalıştırıldığı işletim sisteminde bulunmadığını gösterebilir. Yazı tiplerini işletim sistemine kurmalı veya aşağıda gösterildiği gibi [FontsLoader](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsloader/) sınıfını kullanarak harici yazı tipleri olarak yüklemelisiniz:
```javascript
var folders = java.newArray("java.lang.String", ["path_to_a_folder_with_fonts"]));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", folders);
```