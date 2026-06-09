---
title: Sunumlarda Python ile Metin Bölümlerini Yönetme
linktitle: Metin Bölümü
type: docs
weight: 70
url: /tr/python-net/portion/
keywords:
- metin bölümü
- metin parçası
- metin koordinatları
- metin konumu
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarındaki metin bölümlerini yönetmeyi öğrenin, performans ve özelleştirmeyi artırın."
---
## **Giriş**

Metin bölümü, bir paragraftaki belirli bir metin parçasını temsil eder ve bu parçayı çevredeki içerikten bağımsız olarak çalışmanıza olanak tanır. Aspose.Slides içinde, bir metin parçasının konumunu almak, yalnızca bir paragrafın bir bölümüne biçimlendirme uygulamak veya metin davranışını daha ayrıntılı bir seviyede kontrol etmek gerektiğinde bölümler kullanılabilir.

## **Metin Bölümlerinin Koordinatlarını Al**

[get_coordinates](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/get_coordinates/) yöntemi, metin bölümlerinin koordinatlarını almayı sağlayan [Portion](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/) sınıfına eklenmiştir:

```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```

## **SSS**

**Bir paragraftaki metnin yalnızca bir kısmına bir köprü ekleyebilir miyim?**

Evet, tek bir bölüme [bir köprü ata](/slides/tr/python-net/manage-hyperlinks/) atayabilirsiniz; yalnızca o parça tıklanabilir, tüm paragraf değil.

**Stil kalıtımı nasıl çalışır: bir Portion neyi geçersiz kılar ve neyi Paragraph/TextFrame'den alır?**

Portion düzeyindeki özellikler en yüksek önceliğe sahiptir. Bir özellik [Portion](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/) üzerinde ayarlanmamışsa, motor bunu [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) üzerinden alır; eğer orada da ayarlanmamışsa, [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) veya [theme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/theme/) stilinden alınır.

**Bir Portion için belirtilen yazı tipi hedef makine/sunucuda bulunamazsa ne olur?**

[Yazı tipi ikame kuralları](/slides/tr/python-net/font-selection-sequence/) uygulanır. Metin yeniden akabilir: metrikler, heceleme ve genişlik değişebilir, bu da hassas konumlandırma için önemlidir.

**Bir Portion için metin doldurma şeffaflığını veya degradeyi paragrafın geri kalanından bağımsız olarak ayarlayabilir miyim?**

Evet, [Portion](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/) düzeyinde metin rengi, dolgu ve şeffaflık, komşu parçalarla farklı olabilir.