---
title: C++ kullanarak Sunumlarda Metin Bölümlerini Yönetme
linktitle: Metin Bölümü
type: docs
weight: 70
url: /tr/cpp/portion/
keywords:
- metin bölümü
- metin parçası
- metin koordinatları
- metin konumu
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint sunumlarında metin bölümlerini nasıl yöneteceğinizi öğrenin, performans ve özelleştirmeyi artırın."
---
## **Giriş**

Metin bölümü, bir paragraf içinde belirli bir metin parçacığını temsil eder ve bu parçacıkla çevredeki içerikten bağımsız olarak çalışmanıza olanak tanır. Aspose.Slides'te, bölümler bir metin parçacığının konumunu almak, yalnızca bir paragrafın bir kısmına biçimlendirme uygulamak veya metin davranışını daha ayrıntılı bir seviyede kontrol etmek istediğinizde kullanılabilir.

## **Metin Bölümünün Koordinatlarını Al**
**GetCoordinates()** yöntemi, IPortion ve Portion sınıfına eklenmiştir ve bölümün başlangıç koordinatlarını almanıza olanak tanır:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```

## **SSS**

**Bir paragraf içindeki metnin yalnızca bir kısmına hiperbağlantı uygulayabilir miyim?**

Evet, bir bölüme [bir hiperbağlantı atayabilirsiniz](/slides/tr/cpp/manage-hyperlinks/); sadece o parçacık tıklanabilir, tüm paragraf değil.

**Stil kalıtımı nasıl çalışır: bir Portion neyi geçersiz kılar ve neyi Paragraph/TextFrame'den alır?**

Portion düzeyindeki özellikler en yüksek önceliğe sahiptir. Bir özellik [Portion](https://reference.aspose.com/slides/tr/cpp/aspose.slides/portion/) üzerinde ayarlanmamışsa, motor onu [Paragraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides/paragraph/) üzerinden alır; orada da ayarlanmamışsa, [TextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/textframe/) veya [theme](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/theme/) stilinden alınır.

**Bir Portion için belirtilen yazı tipi hedef makine/sunucuda eksik olursa ne olur?**

[Yazı tipi ikame kuralları](/slides/tr/cpp/font-selection-sequence/) uygulanır. Metin yeniden akabilir: ölçümler, heceleme ve genişlik değişebilir, bu da kesin konumlandırma için önemlidir.

**Bir Portion'a özgü metin doldurma saydamlığını veya degradeyi paragrafın geri kalanından bağımsız olarak ayarlayabilir miyim?**

Evet, [Portion](https://reference.aspose.com/slides/tr/cpp/aspose.slides/portion/) düzeyinde metin rengi, doldurma ve saydamlık komşu parçacıklardan farklı olabilir.