---
title: C++ ile Sunum Erişilebilirliğini Yönetin
linktitle: Sunum Erişilebilirliği
type: docs
weight: 30
url: /tr/cpp/presentation-accessibility/
keywords:
- sunum erişilebilirliği
- dekoratif olarak işaretle
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ın PPT, PPTX ve ODP dosyalarındaki sunum erişilebilirliği kontrollerini otomatikleştirmeye nasıl yardımcı olduğunu keşfedin—ekran okuyucu deneyimini geliştirin ve uyumluluğu artırın."
---
## **Genel Bakış**

Sunum erişilebilirliği, ekran okuyucuları, braille ekranları veya yalnızca klavye ile gezinme gibi yardımcı teknolojileri kullanan kişilerin, slaytlarınızı görme yeteneği olan ve fare kullanan izleyiciler kadar etkili bir şekilde anlayıp gezinmelerini sağlar. İyi uygulamalar, net okuma sırası, bilgilendirici görseller için anlamlı alternatif metin, yeterli renk kontrastı, okunabilir tipografi, açıklayıcı bağlantı metni ve anlamı yalnızca renk veya konumla iletmeden kaçınmaya odaklanır. Erişilebilirlik baştan planlandığında, daha temiz bir yapı, daha tutarlı görseller ve her izleyiciye ek çözümler gerektirmeden ulaşan içerik elde edilir.

## **Dekoratif Olarak İşaretle**

Dekoratif olarak işaretle, yalnızca süs amaçlı görselleri işaretler, böylece ekran okuyucular bu görselleri atlar, gürültüyü azaltır ve anlamlı içeriğe odaklanmayı sağlar. Bu işareti arka planlara, süslere ve boşluk dolduruculara uygulayın—hiçbir zaman bilgi veren grafiklere, simgelere veya resimlere uygulamayın. Aspose.Slides, bu işareti algılama ve doğrulama için sunar; bu da otomatik erişilebilirlik kontrolleri ve temizlik işlemlerini mümkün kılar.

![Dekoratif Olarak İşaretle](mark_as_decorative.png)

Aşağıdaki kod örneği, bir şeklin dekoratif olarak işaretlenip işaretlenmediğini nasıl belirleyeceğini gösterir.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```