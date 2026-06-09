---
title: C++'ta PowerPoint Sunumlarını Animasyonlu GIF'lere Dönüştürme
linktitle: PowerPoint'ten GIF'e
type: docs
weight: 65
url: /tr/cpp/convert-powerpoint-to-animated-gif/
keywords:
- animasyonlu GIF
- PowerPoint'i dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
- PowerPoint'ten GIF'e
- sunumu GIF'e
- slaytı GIF'e
- PPT'yi GIF'e
- PPTX'i GIF'e
- PPT'yi GIF olarak kaydet
- PPTX'i GIF olarak kaydet
- PPT'yi GIF olarak dışa aktar
- PPTX'i GIF olarak dışa aktar
- varsayılan ayarlar
- özel ayarlar
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint sunumlarını (PPT, PPTX) animasyonlu GIF'lere kolayca dönüştürün. Hızlı, yüksek kaliteli sonuçlar."
---
## **Genel Bakış**

Aspose.Slides, sadece birkaç satır kodla PowerPoint sunumlarını animasyonlu GIF dosyalarına dönüştürmenizi sağlar. Bu, slayt içeriğini hafif, yaygın olarak desteklenen animasyonlu bir biçimde web sayfalarına, mesajlaşma uygulamalarına veya belgelere gömmek istediğinizde faydalıdır. Bu makale, bir sunumu GIF olarak varsayılan ayarlarla dışa aktarmayı ve çerçeve boyutu, slayt gecikmesi ve geçiş çerçeve hızı gibi seçenekleri [GifOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/gifoptions/) aracılığıyla nasıl yapılandıracağınızı açıklar.

## **Varsayılan Ayarlarla Sunumları Animasyonlu GIF Olarak Dönüştürme**

Bu C++ örnek kodu, bir sunumu standart ayarlarla animasyonlu GIF'e nasıl dönüştüreceğinizi gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

Animasyonlu GIF, varsayılan parametrelerle oluşturulacaktır. 

{{%  alert  title="TIP"  color="primary"  %}} 
GIF parametrelerini özelleştirmeyi tercih ediyorsanız, [GifOptions](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.gif_options) sınıfını kullanabilirsiniz. Aşağıdaki örnek kodu inceleyin. 
{{% /alert %}} 

## **Özel Ayarlarla Sunumları Animasyonlu GIF Olarak Dönüştürme**

Bu örnek kod, C++'ta özel ayarlarla bir sunumu animasyonlu GIF'e nasıl dönüştüreceğinizi gösterir:

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// Oluşturulan GIF'in boyutu
gifOptions->set_FrameSize(Size(960, 720));
// Her slaytın bir sonraki slayta geçene kadar ne kadar süre gösterileceği
gifOptions->set_DefaultDelay(2000);
// Geçiş animasyon kalitesini artırmak için FPS'i yükseltin
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}
Aspose tarafından geliştirilen ÜCRETSİZ bir [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüye göz atmak isteyebilirsiniz. 
{{% /alert %}}

## **FAQ**

**Sunumda kullanılan yazı tipleri sistemde yüklü değilse ne olur?**

Eksik yazı tiplerini kurun veya [fallback font'ları yapılandırın](/slides/tr/cpp/powerpoint-fonts/). Aspose.Slides bunları yerine koyacaktır, ancak görünüm farklı olabilir. Markalaşma için gerekli tipografilerin kesinlikle mevcut olduğundan emin olun.

**GIF çerçevelerine bir filigran ekleyebilir miyim?**

Evet. Dışa aktarmadan önce ana slayta veya bireysel slaytlara [yarı saydam bir nesne/logo ekleyin](/slides/tr/cpp/watermark/) — filigran her çerçevede görünecektir.