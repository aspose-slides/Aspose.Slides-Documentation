---
title: SSS
type: docs
weight: 340
url: /tr/cpp/faqs/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile ilgili SSS sorularına yanıtlar alabilirsiniz, PowerPoint ve OpenDocument desteği, kurulum rehberi, lisanslama ve sorun giderme konularını kapsar."
---
## **Genel Bakış**

Bu SSS, Aspose.Slides ile ilgili yaygın sorulara yanıtlar sunar. Desteklenen dosya biçimlerini, büyük sunumlarla çalışırken oluşan istisnaların ele alınmasını, slayt boyutlarının değiştirilmesini, slaytların ön izlenmesini, sunumlardan metin alınmasını, tablo kenarlıklarının biçimlendirilmesini, resim yerleştirilmesini ve sunumların PDF veya görüntülere dönüştürülürken ortaya çıkan yazı tipi ile ilgili sorunların çözülmesini kapsar.

## **Desteklenen Dosya Biçimleri**

**Q: Aspose.Slides for C++ hangi dosya biçimlerini destekliyor?**

**A**: Aspose.Slides for C++ aşağıdaki [Supported File Formats](/slides/tr/cpp/supported-file-formats/) bölümünde açıklanan dosya biçimlerini destekler.

## **İstisnalar**

**Q: Büyük bir PPT dosyasını resimlerle yüklerken bellek yetersizliği (out of memory) istisnası alıyorum. Aspose.Slides'de dosya boyutu ile ilgili bir sınırlama var mı?**

**A**: Aspose.Slides tarafından desteklenen sunum boyutunu hesaplamak için belirli bir formül yoktur. Sunumun tüm yapısı ve görüntülerinin bellekte yer alabilmesi için yeterli alan olmalıdır. Normalde, görüntüler bellekte sabit diske göre daha fazla yer kaplar, özellikle görüntülere ek efektler uygulandığında.

Genel olarak, Aspose.Slides for C++ 4 GB RAM'e sahip bir sunucuda yaklaşık 300 MB civarında sunum dosyalarını sorunsuz şekilde işleyebilir.

## **Slaytlarla Çalışma**

**Q: Bir sunumdaki slaytların boyutunu değiştirebilir miyim?**

**A**: Sunumdaki slaytların boyutunu tanımlamak için [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfı tarafından sunulan `get_SlideSize` metodunu kullanabilirsiniz.

**Q: Bir sunumda farklı boyutlarda slaytlar tanımlamak mümkün mü?**

**A**: Microsoft PowerPoint belgelerinde slayt boyutu sunum düzeyinde tanımlandığından, bunu yapmanın bir yolu yoktur.

**Q: Aspose.Slides for C++ kaydetmeden önce bir slaytı ön izlemesini destekliyor mu?**

**A**: Sunum slaytlarını görüntülere renderlayabilir ve bu görüntüleri slaytların ön izlemesi için kullanabilirsiniz.

## **Metinle Çalışma**

**Q: Bir sunumdan tüm metni almak mümkün mü?**

**A**: Aspose.Slides for C++, `Aspose::Slides::Util` ad alanı altında bulunan [SlideUtil](https://reference.aspose.com/slides/tr/cpp/aspose.slides.util/slideutil/) sınıfı aracılığıyla sunumlardan tüm metni almayı sağlayan çeşitli yöntemler sunar.

**Q: Paragraf boyutları Windows ve Linux işletim sistemlerinde neden farklıdır?**

**A**: Paragraf boyutlarının hesaplanması, ilgili paragrafı temsil eden metin boyutunun hesaplanmasına dayanır. Metin boyutu hesabı, PowerPoint sunumunda belirtilen yazı tipinin metriklerine göre yapılır. Belirtilen yazı tipi eksikse, en benzer yazı tipi ile değiştirilir, ancak bu yazı tipinin metrikleri özgün olanlardan farklıdır. Sonuç olarak, farklı sistemlerde yüklü yazı tipi koleksiyonuna bağlı olarak paragraf boyutu hesaplaması farklı sonuçlar verir. Farklı işletim sistemlerinde aynı sonucu elde etmek için aynı yazı tiplerini sistemlere kurmalı veya çalışma zamanında [external fonts](/slides/tr/cpp/custom-font/) olarak yüklemelisiniz.

## **Biçimlendirme ve Görseller**

**Q: Bir tablo kenarlığının rengini nasıl ayarlayabilirim?**

**A**: Tüm tablo kenarlıklarının rengini veya sadece tüm tabloyu çevreleyen kenarlığın rengini değiştirebilirsiniz. Tüm kenarlıkları değiştirmek için lütfen [ICell](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icell/) arabirimindeki `get_CellFormat` metodunu kullanın. Tüm tablo kenarlığı için hücreleri döngüye alıp dış kenarlıkların rengini değiştirmeniz gerekir.

**Q: Aspose.Slides for C++ resimleri yerleştirirken hangi ölçü birimini kullanır?**

**A**: Slaytlardaki tüm şekillerin koordinatları ve boyutları point biriminde (72 dpi) ölçülür.

## **Yazı Tipleriyle Çalışma**

**Q: PPT'yi PDF veya görüntülere dönüştürürken, çıktı belgelerindeki yazı tipleri neden farklıdır?**

**A**: Bu sorun, sunumda kullanılan yazı tiplerinin kodun çalıştırıldığı işletim sisteminde bulunmadığını gösterebilir. Yazı tiplerini işletim sistemine kurmalı veya aşağıda gösterildiği gibi [FontsLoader](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/) sınıfını kullanarak dış yazı tipleri olarak yüklemelisiniz:
```cpp
auto folders = MakeObject<Array<String>>(1, "path_to_a_folder_with_fonts");
FontsLoader::LoadExternalFonts(folders);
```