---
title: Python'da Sunumlardan Metin Bölüm Sınırlarını Al
linktitle: Bölüm Sınırları
type: docs
weight: 47
url: /tr/python-net/portion-bounds/
keywords:
- metin bölüm sınırları
- metin bölümü
- metin parçası
- metin koordinatları
- metin konumu
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarında metin bölüm sınırlarını nasıl alacağınızı öğrenin."
---
## **Genel Bakış**

Bir metin bölümü, bir paragraf içindeki belirli bir metin parçasını temsil eder ve bu parçayı çevresindeki içerikten bağımsız olarak çalışmanıza olanak tanır. Aspose.Slides'te, bölümler metin parçasının sınırlarını almak, yalnızca bir paragrafın bir kısmına biçimlendirme uygulamak veya metin davranışını daha ayrıntılı bir seviyede kontrol etmek istediğinizde kullanılabilir.

Bu makale, bir bölümün sınırlayıcı dikdörtgenini [Portion.get_rect](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/get_rect/) kullanarak nasıl alacağınızı gösterir. Ayrıca, bir bölümün başlangıç koordinatlarını [Portion.get_coordinates](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/get_coordinates/) kullanarak nasıl alacağınızı gösterir. Ek olarak, tek bir metin parçasına bir köprü ekleme, biçimlendirmenin bölüm, paragraf, metin çerçevesi ve tema kalıtımı üzerinden nasıl çözümlendiğini anlama ve belirtilen bir yazı tipinin mevcut olmaması durumlarını ele alma gibi yaygın bölümle ilgili senaryoları vurgular.

## **Metin Bölümünün Sınırlayıcı Dikdörtgenini Almak**

Bir metin bölümünün sınırlayıcı dikdörtgenini almak için [Portion.get_rect](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/get_rect/) kullanın:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **Metin Bölümünün Koordinatlarını Almak**

Bir metin bölümünün başlangıç koordinatlarını almak için [Portion.get_coordinates](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/get_coordinates/) kullanın:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **SSS**

**Bir paragraftaki metnin yalnızca bir kısmına köprü ekleyebilir miyim?**

Evet, bireysel bir bölüme [bir köprü atayabilirsiniz](/slides/tr/python-net/manage-hyperlinks/); sadece o parça tıklanabilir olur, tüm paragraf değil.

**Stil kalıtımı nasıl çalışır: bir bölüm neyi geçersiz kılar ve neyi paragraftan veya metin çerçevesinden alır?**

Bölüm seviyesindeki özellikler en yüksek önceliğe sahiptir. Bir özellik [Portion](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/) üzerinde ayarlanmamışsa, Aspose.Slides onu [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) üzerinden alır. Orada da ayarlanmamışsa, Aspose.Slides [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) veya [theme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/theme/) stilini kullanır.

**Bir bölüm için belirtilen yazı tipi hedef makine veya sunucuda eksik olursa ne olur?**

[Yazı tipi değiştirme kuralları](/slides/tr/python-net/font-selection-sequence/) uygulanır. Metin yeniden akışa geçebilir: ölçümler, heceleme ve genişlik değişebilir, bu da kesin konumlandırma için önemlidir.

**Paragrafın geri kalanından bağımsız olarak bölüm-özelliği metin doldurma şeffaflığı veya bir degrade ayarlayabilir miyim?**

Evet, [Portion](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/) seviyesindeki metin rengi, dolgu ve şeffaflık komşu parçalardan farklı olabilir.