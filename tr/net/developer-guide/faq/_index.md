---
title: SSS
type: docs
weight: 340
url: /tr/net/faqs/
keywords:
- SSS
- PowerPoint
- sunum formatı
- bellek yetersizliği hatası
- slayt boyutu
- metin çıkarma
- metin alma
- paragraf boyutu
- tabloları biçimlendirme
- yazı tipi
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET hakkında SSS yanıtlarını alın; PowerPoint ve OpenDocument desteği, kurulum rehberi, lisanslama ve sorun giderme konularını kapsar."
---
## **Genel Bakış**

Bu SSS, Aspose.Slides ile ilgili yaygın sorulara yanıtlar sağlar. Desteklenen dosya formatlarını, büyük sunumlarla çalışırken istisna yönetimini, slayt boyutlarını değiştirmeyi, slaytları ön izlemeyi, sunumlardan metin almayı, tablo kenarlıklarını biçimlendirmeyi, resim yerleştirmeyi ve sunumları PDF veya görüntülere dönüştürürken ortaya çıkan yazı tipi ile ilgili sorunları çözmeyi kapsar.

## **Desteklenen Dosya Formatları**

**S:** Aspose.Slides for .NET hangi dosya formatlarını destekler?

**C:** Aspose.Slides for .NET, [Desteklenen Dosya Formatları](/slides/tr/net/supported-file-formats/) adresinde açıklanan dosya formatlarını destekler.

## **İstisnalar**

**S:** Büyük bir PPT dosyasını görsellerle yüklerken OutOfMemoryException alıyorum. Aspose.Slides'in dosya boyutu konusunda bir sınırlaması var mı?

**C:** Aspose.Slides tarafından desteklenen sunum boyutunu hesaplamak için belirli bir formül yoktur. Bellekte tüm sunum yapısını ve görselleri barındıracak kadar alan bulunmalıdır. Normalde, bellek içindeki görseller, sabit diskten daha fazla yer kaplar, özellikle görseller ek efektlere sahipse.

Genel olarak, Aspose.Slides for .NET, 4 GB RAM'e sahip bir sunucuda yaklaşık 300 MB civarındaki sunum dosyalarını rahatlıkla işleyebilir.

## **Slaytlarla Çalışma**

**S:** Bir sunumdaki slaytların boyutunu değiştirebilir miyim?

**C:** `SlideSize` özelliğini, sunumdaki slaytların boyutunu tanımlamak için [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı aracılığıyla kullanabilirsiniz.

**S:** Bir sunumda farklı boyutlarda slaytlar tanımlamanın bir yolu var mı?

**C:** Microsoft PowerPoint belgelerinde slayt boyutu sunum seviyesinde tanımlandığından, bunu yapmanın bir yolu yoktur.

**S:** Aspose.Slides for .NET, kaydetmeden önce bir slaytı ön izlemeyi destekliyor mu?

**C:** Sunum slaytlarını görüntülere renderleyebilir ve bu görüntüleri slaytları ön izlemek için kullanabilirsiniz.

## **Metinle Çalışma**

**S:** Bir sunumdan tüm metni almak mümkün mü?

**C:** Aspose.Slides for .NET, sunumlardan bütün metni almak için çeşitli yöntemler sağlayan `Aspose.Slides.Util` ad alanı altında [SlideUtil](https://reference.aspose.com/slides/tr/net/aspose.slides.util/slideutil/) sınıfını sunar.

**S:** Paragraf boyutları Windows ve Linux işletim sistemlerinde neden farklılaşıyor?

**C:** Paragraf boyutlarının hesabı, ilgili paragrafı temsil eden metin boyutunun hesaplamasına dayanır. Metin boyutu hesabı, PowerPoint sunumunda belirtilen yazı tipinin metriklerine göre yapılır. Belirtilen yazı tipi eksikse, en benzer yazı tipi ile değiştirilir; ancak bu yazı tipinin metrikleri orijinalinden farklıdır. Sonuç olarak, farklı sistemlerdeki paragraf boyutu hesaplamaları, yüklü yazı tiplerinin setine bağlı olarak farklı sonuçlar verir. Farklı işletim sistemlerinde aynı sonucu elde etmek için aynı yazı tiplerini sistemlere kurmalı veya bunları çalışma zamanında [harici yazı tipleri](/slides/tr/net/custom-font/) olarak yüklemelisiniz.

## **Biçimlendirme ve Görseller**

**S:** Bir tablo kenarlığının rengini nasıl ayarlayabilirim?

**C:** Tüm tablo kenarlıklarının rengini veya sadece tablonun tamamını çevreleyen kenarlığın rengini değiştirebilirsiniz. Tüm kenarlıkları değiştirmek için, [ICell](https://reference.aspose.com/slides/tr/net/aspose.slides/icell/) arayüzündeki `CellFormat` özelliğini kullanın. Tablonun dış kenarlıkları için hücreleri döngüyle gezerek dış kenarlıkların rengini değiştirmeniz gerekir.

**S:** Aspose.Slides for .NET, resimleri yerleştirirken hangi ölçütü kullanır?

**C:** Slaytlardaki tüm şekillerin koordinatları ve boyutları nokta (point) biriminde ölçülür (72 dpi).

## **Yazı Tipleriyle Çalışma**

**S:** PPT'yi PDF veya görüntülere dönüştürürken, çıktı belgelerindeki yazı tipleri neden farklı çıkıyor?

**C:** Bu sorun, sunumda kullanılan yazı tiplerinin kodun çalıştırıldığı işletim sisteminde bulunmadığını gösterebilir. Yazı tiplerini işletim sistemine kurmalı veya aşağıda gösterildiği gibi [FontsLoader](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/) sınıfını kullanarak harici yazı tipleri olarak yüklemelisiniz:
```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```