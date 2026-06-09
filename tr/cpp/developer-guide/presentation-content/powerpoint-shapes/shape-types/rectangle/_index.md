---
title: C++ Sunumlarına Dikdörtgen Ekleyin
linktitle: Dikdörtgen
type: docs
weight: 80
url: /tr/cpp/rectangle/
keywords:
- dikdörtgen ekle
- dikdörtgen oluştur
- dikdörtgen şekil
- basit dikdörtgen
- biçimlendirilmiş dikdörtgen
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile dikdörtgen ekleyerek PowerPoint sunumlarınızı geliştirin — şekilleri kolayca programlı olarak tasarlayıp değiştirebilirsiniz."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint slaytlarına dikdörtgen şekilleri eklemeyi gösterir. Basit bir dikdörtgen oluşturmayı, biçimlendirilmiş bir dikdörtgen oluşturmayı ve güncellenmiş sunumu PPTX dosyası olarak kaydetmeyi kapsar.

## **Basit Bir Dikdörtgen Oluşturma**
Önceki konular gibi, bu da bir şekil eklemekle ilgilidir ve bu sefer ele alacağımız şekil Rectangle (Dikdörtgen) dir. Bu konuda, geliştiricilerin Aspose.Slides for C++ kullanarak slaytlarına basit veya biçimlendirilmiş dikdörtgenler ekleyebileceği açıklanmıştır. Sunumun seçili bir slaytına basit bir dikdörtgen eklemek için aşağıdaki adımları izleyin:

1. Bir [Presentation class](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneği oluşturun.
1. Bir slaydın referansını Index kullanarak alın.
1. IShapes nesnesi tarafından sağlanan AddAutoShape yöntemiyle Rectangle tipinde bir IAutoShape ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıda verilen örnekte, sunumun ilk slaytına basit bir dikdörtgen ekledik.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **Biçimlendirilmiş Dikdörtgen Oluşturma**
Bir slayta biçimlendirilmiş bir dikdörtgen eklemek için aşağıdaki adımları izleyin:

1. Bir [Presentation class](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneği oluşturun.
1. Bir slaydın referansını Index kullanarak alın.
1. IShapes nesnesi tarafından sağlanan AddAutoShape yöntemiyle Rectangle tipinde bir IAutoShape ekleyin.
1. Dikdörtgenin Dolgu Türünü Solid (Katı) olarak ayarlayın.
1. IShape nesnesiyle ilişkili FillFormat nesnesi tarafından sunulan SolidFillColor.Color özelliğini kullanarak Dikdörtgenin Rengini ayarlayın.
1. Dikdörtgenin çizgi renklerini ayarlayın.
1. Dikdörtgenin çizgi genişliğini ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak yazın.
Yukarıdaki adımlar aşağıda verilen örnekte uygulanmıştır.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}

## **SSS**

**Yuvarlatılmış köşeli bir dikdörtgen nasıl eklerim?**  
Yuvarlatılmış köşe [shape type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shapetype/) kullanın ve şekil özelliklerinde köşe yarıçapını ayarlayın; yuvarlatma ayrıca geometri ayarlamalarıyla köşe bazında uygulanabilir.

**Bir dikdörtgeni resim (doku) ile nasıl doldururum?**  
Resim [fill type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) seçin, görüntü kaynağını sağlayın ve [stretching/tiling modes](https://reference.aspose.com/slides/tr/cpp/aspose.slides/picturefillmode/) yapılandırın.

**Bir dikdörtgen gölge ve parlama (glow) alabilir mi?**  
Evet. [Outer/inner shadow, glow, and soft edges](/slides/tr/cpp/shape-effect/) ayarlanabilir parametrelerle mevcuttur.

**Bir dikdörtgeni hiperlinkli bir düğmeye dönüştürebilir miyim?**  
Evet. Şekle tıklama (slayta, dosyaya, web adresine veya e-postaya gitme) için [Bir hiperlink ata](/slides/tr/cpp/manage-hyperlinks/) ekleyin.

**Bir dikdörtgeni hareket ve değişikliklerden nasıl korurum?**  
[Şekil kilitlerini kullan](/slides/tr/cpp/applying-protection-to-presentation/): hareket, yeniden boyutlandırma, seçim veya metin düzenlemeyi yasaklayarak düzeni koruyabilirsiniz.

**Bir dikdörtgeni raster görüntüye veya SVG'ye dönüştürebilir miyim?**  
Evet. Şekli belirli bir boyut/ölçekle bir görüntüye [render the shape](http://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/getimage/) edebilir veya vektör kullanım için [export it as SVG](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/writeassvg/) yapabilirsiniz.

**Tema ve kalıtımı dikkate alarak bir dikdörtgenin gerçek (etkin) özelliklerini hızlıca nasıl alırım?**  
[Şeklin etkin özelliklerini kullan](/slides/tr/cpp/shape-effective-properties/): API, tema stilleri, düzen ve yerel ayarları dikkate alan hesaplanmış değerleri döndürür, biçimlendirme analizini basitleştirir.