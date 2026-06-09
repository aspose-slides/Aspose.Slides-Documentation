---
title: C++'ta Sunumlara Elips Ekle
linktitle: Elips
type: docs
weight: 30
url: /tr/cpp/ellipse/
keywords:
- elips
- şekil
- elips ekle
- elips oluştur
- elips çiz
- biçimlendirilmiş elips
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PPT ve PPTX sunumlarında elips şekillerini oluşturmayı, biçimlendirmeyi ve manipüle etmeyi öğrenin — C++ kod örnekleri dahil."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint slaytlarına elips şekilleri eklemenin nasıl yapılacağını gösterir. Basit bir elips oluşturmayı, biçimlendirilmiş bir elips oluşturmayı ve güncellenmiş sunumu PPTX dosyası olarak kaydetmeyi kapsar. Ayrıca elipsin konumu ve boyutu ile çalışmak, yığın sırasını kontrol etmek ve animasyon efektleri uygulamak gibi ilgili sorulara da değinir.

## **Elips Oluştur**
Bu konuda, geliştiricilere Aspose.Slides for C++ kullanarak slaytlarına elips şekilleri eklemeyi tanıtacağız. Aspose.Slides for C++, sadece birkaç satır kodla farklı şekiller çizmeyi sağlayan daha kolay bir API seti sunar. Sunumun seçili bir slaytına basit bir elips eklemek için aşağıdaki adımları izleyin:

1. Bir [Presentation class](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneği oluşturun
1. Bir slaytın referansını, indeksini kullanarak alın
1. IShapes nesnesi tarafından sunulan AddAutoShape yöntemi ile Ellipse tipinde bir AutoShape ekleyin
1. Değiştirilen sunumu PPTX dosyası olarak yazın

Aşağıdaki örnekte, ilk slayta bir elips ekledik.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}

## **Biçimlendirilmiş Elips Oluştur**
Bir slayta daha iyi biçimlendirilmiş bir elips eklemek için aşağıdaki adımları izleyin:

1. Bir [Presentation class](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneği oluşturun.
1. Bir slaytın referansını, indeksini kullanarak alın.
1. IShapes nesnesi tarafından sunulan AddAutoShape yöntemi ile Ellipse tipinde bir AutoShape ekleyin.
1. Elipsin Doldurma Türünü Solid (katı) olarak ayarlayın.
1. IShape nesnesine bağlı FillFormat nesnesi tarafından sunulan SolidFillColor.Color özelliğini kullanarak elipsin rengini ayarlayın.
1. Elipsin çizgi rengini ayarlayın.
1. Elipsin çizgi kalınlığını ayarlayın.
1. Değiştirilen sunumu PPTX dosyası olarak yazın.

Aşağıdaki örnekte, sunumun ilk slaytına biçimlendirilmiş bir elips ekledik.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}

## **SSS**

**Bir elipsin konumunu ve boyutunu slayt birimlerine göre tam olarak nasıl ayarlarım?**

Koordinatlar ve boyutlar genellikle **point** biriminde belirtilir. Öngörülebilir sonuçlar elde etmek için hesaplamalarınızı slayt boyutuna göre yapın ve değerleri atamadan önce gerekli milimetre veya inçleri point birimine dönüştürün.

**Bir elipsi diğer nesnelerin üzerine veya altına nasıl yerleştiririm (yığın sırasını kontrol etmek)?**

Nesnenin çizim sırasını öne getirerek veya arkaya göndererek ayarlayın. Bu, elipsin diğer nesnelerin üzerine geçmesini veya altındakileri ortaya çıkarmasını sağlar.

**Bir elipsin görünümünü veya vurgusunu nasıl canlandırırım?**

[Apply](/slides/tr/cpp/shape-animation/) giriş, vurgu veya çıkış efektlerini şekle uygulayın ve tetikleyicileri ve zamanlamayı yapılandırarak animasyonun ne zaman ve nasıl oynatılacağını düzenleyin.